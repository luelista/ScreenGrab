/*
 * (C) 2010 Kees van den Broek: kvdb@kvdb.net
 *          D-centralize: d-centralize.nl
 *          
 * Latest version and examples on: http://kvdb.net/projects/webdav
 * 
 * Feel free to use this code however you like.
 * http://creativecommons.org/license/zero/
 * 
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
/*
// If you want to disable SSL certificate validation
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
*/

namespace net.kvdb.webdav {
    public delegate void ListCompleteDel(List<Item> files, int statusCode);
    public delegate void UploadCompleteDel(int statusCode, object state);
    public delegate void DownloadCompleteDel(int statusCode, object userState, string remoteFilePath, string localFilePath);
    public delegate void CreateDirCompleteDel(int statusCode);
    public delegate void DeleteCompleteDel(int statusCode);

    public class Item : IComparable {
        public string Href { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Etag { get; set; }
        public bool IsHidden { get; set; }
        public bool IsCollection { get; set; }
        public string ContentType { get; set; }
        public DateTime? LastModified { get; set; }
        public string DisplayName { get; set; }
        public int? ContentLength { get; set; }

        public int CompareTo(object obj) {
            if (obj is Item) {
                Item other = (Item)obj;
                return ((this.IsCollection ? -100 : 100)-(other.IsCollection ? -100 : 100) )
                    + String.Compare(this.DisplayName, other.DisplayName);
            } else {
                throw new NotImplementedException();
            }
        }
    }

    public class WebDAVClient {
        public event ListCompleteDel ListComplete;
        public event UploadCompleteDel UploadComplete;
        public event DownloadCompleteDel DownloadComplete;
        public event CreateDirCompleteDel CreateDirComplete;
        public event DeleteCompleteDel DeleteComplete;

        //XXX: submit along with state object.
        HttpWebRequest httpWebRequest;

        #region WebDAV connection parameters
        private String server;
        /// <summary>
        /// Specify the WebDAV hostname (required).
        /// </summary>
        public String Server
        {
            get { return server; }
            set
            {
                value = value.TrimEnd('/');
                server = value;
            }
        }
        private String basePath = "/";
        /// <summary>
        /// Specify the path of a WebDAV directory to use as 'root' (default: /)
        /// </summary>
        public String BasePath
        {
            get { return basePath; }
            set
            {
                value = value.Trim('/');
                basePath = "/" + value + (value==""?"":"/");
            }
        }
        private int? port = null;
        /// <summary>
        /// Specify an port (default: null = auto-detect)
        /// </summary>
        public int? Port
        {
            get { return port; }
            set { port = value; }
        }
        private String user;
        /// <summary>
        /// Specify a username (optional)
        /// </summary>
        public String User
        {
            get { return user; }
            set { user = value; }
        }
        private String pass;
        /// <summary>
        /// Specify a password (optional)
        /// </summary>
        public String Pass
        {
            get { return pass; }
            set { pass = value; }
        }
        private String domain = null;
        public String Domain
        {
            get { return domain; }
            set { domain = value; }
        }

        public Uri URL
        {
            get { return getServerUrl(null, true);  }
            set
            {
                server = value.Scheme + "://" + value.Host;
                port = value.IsDefaultPort ? (value.Scheme=="http"?80:443) : value.Port;
                this.BasePath = value.AbsolutePath;
                if (String.IsNullOrEmpty(ConnectionName)) ConnectionName = value.Host;
            }
        }

        public String ConnectionName { get; set;  }

        public override string ToString() {
            return ConnectionName;
        }

        Uri getServerUrl(String path, Boolean appendTrailingSlash) {
            String completePath = basePath;
            if (path != null) {
                completePath += path.Trim('/');
            }

            if (appendTrailingSlash && completePath.EndsWith("/") == false) { completePath += '/'; }

            if (port.HasValue) {
                return new Uri(server + ":" + port + completePath);
            } else {
                return new Uri(server + completePath);
            }

        }
        #endregion

        #region WebDAV operations
        /// <summary>
        /// List files in the root directory
        /// </summary>
        public void List() {
            // Set default depth to 1. This would prevent recursion (default is infinity).
            List("/", 1);
        }

        /// <summary>
        /// List files in the given directory
        /// </summary>
        /// <param name="path"></param>
        public void List(String path) {
            // Set default depth to 1. This would prevent recursion.
            List(path, 1);
        }

        /// <summary>
        /// List all files present on the server.
        /// </summary>
        /// <param name="remoteFilePath">List only files in this path</param>
        /// <param name="depth">Recursion depth</param>
        /// <returns>A list of files (entries without a trailing slash) and directories (entries with a trailing slash)</returns>
        public void List(String remoteFilePath, int? depth) {
            // Uri should end with a trailing slash
            Uri listUri = getServerUrl(remoteFilePath, true);

            // http://webdav.org/specs/rfc4918.html#METHOD_PROPFIND
            StringBuilder propfind = new StringBuilder();
            propfind.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            propfind.Append("<propfind xmlns=\"DAV:\">");
            propfind.Append("  <allprop/>");
            propfind.Append("</propfind>");

            // Depth header: http://webdav.org/specs/rfc4918.html#rfc.section.9.1.4
            IDictionary<string, string> headers = new Dictionary<string, string>();
            if (depth != null) {
                headers.Add("Depth", depth.ToString());
            }

            AsyncCallback callback = new AsyncCallback(FinishList);
            HTTPRequest(listUri, "PROPFIND", headers, Encoding.UTF8.GetBytes(propfind.ToString()), null, callback, remoteFilePath);
        }


        void FinishList(IAsyncResult result) {
            string remoteFilePath = (string)result.AsyncState;
            int statusCode = 0;
            List<Item> files = new List<Item>();

            using (HttpWebResponse response = (HttpWebResponse)httpWebRequest.EndGetResponse(result)) {
                statusCode = (int)response.StatusCode;
                using (Stream stream = response.GetResponseStream()) {

                    var items = ResponseParser.ParseItems(stream);
                    foreach(var item in items) {
                        if (item.Href == remoteFilePath) continue;
                        files.Add(item);
                    }
                }
            }
            files.Sort();
            if (ListComplete != null) {
                ListComplete(files, statusCode);
            }
        }

        /// <summary>
        /// Upload a file to the server
        /// </summary>
        /// <param name="localFilePath">Local path and filename of the file to upload</param>
        /// <param name="remoteFilePath">Destination path and filename of the file on the server</param>
        public void Upload(String localFilePath, String remoteFilePath) {
            Upload(localFilePath, remoteFilePath, null);
        }

        /// <summary>
        /// Upload a file to the server
        /// </summary>
        /// <param name="localFilePath">Local path and filename of the file to upload</param>
        /// <param name="remoteFilePath">Destination path and filename of the file on the server</param>
        /// <param name="state">Object to pass along with the callback</param>
        public void Upload(String localFilePath, String remoteFilePath, object state) {
            FileInfo fileInfo = new FileInfo(localFilePath);
            long fileSize = fileInfo.Length;

            Uri uploadUri = getServerUrl(remoteFilePath, false);
            string method = WebRequestMethods.Http.Put.ToString();

            AsyncCallback callback = new AsyncCallback(FinishUpload);
            HTTPRequest(uploadUri, method, null, null, localFilePath, callback, state);
        }


        void FinishUpload(IAsyncResult result) {
            int statusCode = 0;

            using (HttpWebResponse response = (HttpWebResponse)httpWebRequest.EndGetResponse(result)) {
                statusCode = (int)response.StatusCode;
            }

            if (UploadComplete != null) {
                UploadComplete(statusCode, result.AsyncState);
            }
        }


        /// <summary>
        /// Download a file from the server
        /// </summary>
        /// <param name="remoteFilePath">Source path and filename of the file on the server</param>
        /// <param name="localFilePath">Destination path and filename of the file to download on the local filesystem</param>
        public void Download(String remoteFilePath, String localFilePath, object userState) {
            // Should not have a trailing slash.
            Uri downloadUri = getServerUrl(remoteFilePath, false);
            string method = WebRequestMethods.Http.Get.ToString();

            AsyncCallback callback = new AsyncCallback(FinishDownload);
            HTTPRequest(downloadUri, method, null, null, null, callback,new object[] { userState, remoteFilePath, localFilePath });
        }


        void FinishDownload(IAsyncResult result) {
            object[] asyncState = (object[])result.AsyncState;
            object userState = asyncState[0];
            string remoteFilePath = (string)asyncState[1];
            string localFilePath = (string)asyncState[2];
            int statusCode = 0;

            using (HttpWebResponse response = (HttpWebResponse)httpWebRequest.EndGetResponse(result)) {
                statusCode = (int)response.StatusCode;
                int contentLength = int.Parse(response.GetResponseHeader("Content-Length"));
                using (Stream s = response.GetResponseStream()) {
                    using (FileStream fs = new FileStream(localFilePath, FileMode.Create, FileAccess.Write)) {
                        byte[] content = new byte[4096];
                        int bytesRead = 0;
                        do {
                            bytesRead = s.Read(content, 0, content.Length);
                            fs.Write(content, 0, bytesRead);
                        } while (bytesRead > 0);
                    }
                }
            }

            if (DownloadComplete != null) {
                DownloadComplete(statusCode, userState, remoteFilePath, localFilePath);
            }
        }


        /// <summary>
        /// Create a directory on the server
        /// </summary>
        /// <param name="remotePath">Destination path of the directory on the server</param>
        public void CreateDir(string remotePath) {
            // Should not have a trailing slash.
            Uri dirUri = getServerUrl(remotePath, false);

            string method = WebRequestMethods.Http.MkCol.ToString();

            AsyncCallback callback = new AsyncCallback(FinishCreateDir);
            HTTPRequest(dirUri, method, null, null, null, callback, null);
        }


        void FinishCreateDir(IAsyncResult result) {
            int statusCode = 0;

            using (HttpWebResponse response = (HttpWebResponse)httpWebRequest.EndGetResponse(result)) {
                statusCode = (int)response.StatusCode;
            }

            if (CreateDirComplete != null) {
                CreateDirComplete(statusCode);
            }
        }


        /// <summary>
        /// Delete a file on the server
        /// </summary>
        /// <param name="remoteFilePath"></param>
        public void Delete(string remoteFilePath) {
            Uri delUri = getServerUrl(remoteFilePath, remoteFilePath.EndsWith("/"));

            AsyncCallback callback = new AsyncCallback(FinishDelete);
            HTTPRequest(delUri, "DELETE", null, null, null, callback, null);
        }


        void FinishDelete(IAsyncResult result) {
            int statusCode = 0;

            using (HttpWebResponse response = (HttpWebResponse)httpWebRequest.EndGetResponse(result)) {
                statusCode = (int)response.StatusCode;
            }

            if (DeleteComplete != null) {
                DeleteComplete(statusCode);
            }
        }
        #endregion

        #region Server communication

        /// <summary>
        /// This class stores the request state of the request.
        /// </summary>
        public class RequestState {
            public WebRequest request;
            // The request either contains actual content...
            public byte[] content;
            // ...or a reference to the file to be added as content.
            public string uploadFilePath;
            // Callback and state to use after handling the request.
            public AsyncCallback userCallback;
            public object userState;
        }

        /// <summary>
        /// Perform the WebDAV call and fire the callback when finished.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="requestMethod"></param>
        /// <param name="headers"></param>
        /// <param name="content"></param>
        /// <param name="uploadFilePath"></param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        void HTTPRequest(Uri uri, string requestMethod, IDictionary<string, string> headers, byte[] content, string uploadFilePath, AsyncCallback callback, object state) {
            httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(uri);

            /*
             * The following line fixes an authentication problem explained here:
             * http://www.devnewsgroups.net/dotnetframework/t9525-http-protocol-violation-long.aspx
             */
            System.Net.ServicePointManager.Expect100Continue = false;

            // If you want to disable SSL certificate validation
            /*
            System.Net.ServicePointManager.ServerCertificateValidationCallback +=
            delegate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors sslError)
            {
                    bool validationResult = true;
                    return validationResult;
            };
            */

            // The server may use authentication
            if (user != null && pass != null) {
                NetworkCredential networkCredential;
                if (domain != null) {
                    networkCredential = new NetworkCredential(user, pass, domain);
                } else {
                    networkCredential = new NetworkCredential(user, pass);
                }
                httpWebRequest.Credentials = networkCredential;
                // Send authentication along with first request.
                httpWebRequest.PreAuthenticate = true;
            }
            httpWebRequest.Method = requestMethod;

            // Need to send along headers?
            if (headers != null) {
                foreach (string key in headers.Keys) {
                    httpWebRequest.Headers.Set(key, headers[key]);
                }
            }

            // Need to send along content?
            if (content != null || uploadFilePath != null) {
                RequestState asyncState = new RequestState();
                asyncState.request = httpWebRequest;
                asyncState.userCallback = callback;
                asyncState.userState = state;

                if (content != null) {
                    // The request either contains actual content...
                    httpWebRequest.ContentLength = content.Length;
                    asyncState.content = content;
                    httpWebRequest.ContentType = "text/xml";
                } else {
                    // ...or a reference to the file to be added as content.
                    httpWebRequest.ContentLength = new FileInfo(uploadFilePath).Length;
                    asyncState.uploadFilePath = uploadFilePath;
                }

                // Perform asynchronous request.
                IAsyncResult r = (IAsyncResult)asyncState.request.BeginGetRequestStream(new AsyncCallback(ReadCallback), asyncState);
            } else {

                // Begin async communications
                httpWebRequest.BeginGetResponse(callback, state);
            }
        }

        /// <summary>
        /// Submit data asynchronously
        /// </summary>
        /// <param name="result"></param>
        private void ReadCallback(IAsyncResult result) {
            RequestState state = (RequestState)result.AsyncState;
            WebRequest request = state.request;

            // End the Asynchronus request.
            using (Stream streamResponse = request.EndGetRequestStream(result)) {
                // Submit content
                if (state.content != null) {
                    streamResponse.Write(state.content, 0, state.content.Length);
                } else {
                    using (FileStream fs = new FileStream(state.uploadFilePath, FileMode.Open, FileAccess.Read)) {
                        byte[] content = new byte[4096];
                        int bytesRead = 0;
                        do {
                            bytesRead = fs.Read(content, 0, content.Length);
                            streamResponse.Write(content, 0, bytesRead);
                        } while (bytesRead > 0);

                        //XXX: perform upload status callback
                    }
                }
            }

            // Done, invoke user callback
            request.BeginGetResponse(state.userCallback, state.userState);
        }
        #endregion
    }


    /// <summary>
    /// Represents the parser for response's results.
    /// </summary>
    internal static class ResponseParser {
        
        /// <summary>
        /// Parses the disk items.
        /// </summary>
        /// <param name="stream">The response text.</param>
        /// <returns>The list of parsed items.</returns>
        public static IEnumerable<Item> ParseItems(Stream stream) {
            var items = new List<Item>();
            using (var reader = XmlReader.Create(stream)) {
                Item itemInfo = null;
                while (reader.Read()) {
                    if (reader.NodeType == XmlNodeType.Element) {
                        switch (reader.LocalName.ToLower()) {
                            case "response":
                                itemInfo = new Item();
                                break;
                            case "href":
                                if (!reader.IsEmptyElement) {
                                    reader.Read();
                                    var value = reader.Value;
                                    value = value.Replace("#", "%23");
                                    itemInfo.Href = value;
                                }
                                break;
                            case "creationdate":
                                if (!reader.IsEmptyElement) {
                                    reader.Read();
                                    DateTime creationdate;
                                    if (DateTime.TryParse(reader.Value, out creationdate))
                                        itemInfo.CreationDate = creationdate;
                                }
                                break;
                            case "getlastmodified":
                                if (!reader.IsEmptyElement) {
                                    reader.Read();
                                    DateTime lastmodified;
                                    if (DateTime.TryParse(reader.Value, out lastmodified))
                                        itemInfo.LastModified = lastmodified;
                                }
                                break;
                            case "displayname":
                                if (!reader.IsEmptyElement) {
                                    reader.Read();
                                    itemInfo.DisplayName = reader.Value;
                                }
                                break;
                            case "getcontentlength":
                                if (!reader.IsEmptyElement) {
                                    reader.Read();
                                    int contentLength;
                                    if (int.TryParse(reader.Value, out contentLength))
                                        itemInfo.ContentLength = contentLength;
                                }
                                break;
                            case "getcontenttype":
                                if (!reader.IsEmptyElement) {
                                    reader.Read();
                                    itemInfo.ContentType = reader.Value;
                                }
                                break;
                            case "getetag":
                                if (!reader.IsEmptyElement) {
                                    reader.Read();
                                    itemInfo.Etag = reader.Value;
                                }
                                break;
                            case "iscollection":
                                if (!reader.IsEmptyElement) {
                                    reader.Read();
                                    bool isCollection;
                                    if (bool.TryParse(reader.Value, out isCollection))
                                        itemInfo.IsCollection = isCollection;
                                    int isCollectionInt;
                                    if (int.TryParse(reader.Value, out isCollectionInt))
                                        itemInfo.IsCollection = isCollectionInt == 1;
                                }
                                break;
                            case "resourcetype":
                                if (!reader.IsEmptyElement) {
                                    reader.Read();
                                    var resourceType = reader.LocalName.ToLower();
                                    if (string.Equals(resourceType, "collection", StringComparison.InvariantCultureIgnoreCase))
                                        itemInfo.IsCollection = true;
                                }
                                break;
                            case "hidden":
                            case "ishidden":
                                itemInfo.IsHidden = true;
                                break;
                            default: {
                                    int a = 0;
                                    break;
                                }
                        }
                    } else if (reader.NodeType == XmlNodeType.EndElement && reader.LocalName.ToLower() == "response") {
                        // Remove trailing / if the item is not a collection
                        var href = itemInfo.Href.TrimEnd('/');
                        if (!itemInfo.IsCollection) {
                            itemInfo.Href = href;
                        }
                        if (string.IsNullOrEmpty(itemInfo.DisplayName)) {
                            var name = href.Substring(href.LastIndexOf('/') + 1);
                            itemInfo.DisplayName = System.Uri.UnescapeDataString(name);
                        }
                        items.Add(itemInfo);
                    }
                }
            }

            return items;
        }


    }
}