Public Class UploadImageshack
  Inherits AbstractUploader
  Dim result As String

  Public Overrides Sub initializeOptions(ByVal optionsPanel As IUploadOptionsPanel)

  End Sub

  Public Overrides Sub runResultGui()
    Dim str As New IO.StringReader(result)
    Dim xmlRead As Xml.XmlReader = Xml.XmlReader.Create(str)
    Dim foundLinks As Boolean = False
    Dim linkList As New Hashtable
    While xmlRead.Read
      Select Case xmlRead.NodeType
        Case Xml.XmlNodeType.Element
          If foundLinks Then
            Dim name As String = xmlRead.LocalName
            xmlRead.MoveToContent()
            linkList.Add(name, xmlRead.ReadString)
          ElseIf xmlRead.LocalName.ToLower = "links" Then
            foundLinks = True
          End If

      End Select
    End While

    Dim frmInfo As New frm_imageshackUploaded
    frmInfo.Show()
    frmInfo.setInfo(linkList)

    Dim text As New System.Text.StringBuilder
    text.AppendLine("<div style='height:140px;overflow:auto;max-width:550px;font:status-bar;'>")
    text.AppendLine("<img src=""" + linkList("thumb_link") + """ align=""left"">")
    For Each k As String In linkList.Keys
      text.AppendLine("<b>" + k + "</b>: ")
      If k.EndsWith("_link") Then
        text.AppendLine("<a href=""" + linkList(k) + """>" + linkList(k) + "</a><br>")
      Else
        text.AppendLine("<span style='font-size:7pt'>" + Replace(linkList(k), "<", "&lt;") + "</span><br>")
      End If
    Next
    text.AppendLine("</div>")
    uploadHistoryAdd(text.ToString)

    'Dim para As Hashtable = e.Result(1)
    'frm_imgurUploaded.DisplayInfo(para)
    'Dim histItem As New frm_blueScreen.HistoryItem
    'histItem.isUpload = True : histItem.url = para("links")("imgur_page")
    'FRM.AddToHistory(histItem)
  End Sub

  Public Overrides Function runUpload(ByVal progressReceiver As IUploadOptionsPanel) As Boolean
    Try
      Dim Idboundary = "sg6shackupload." & Now.Ticks    ' you can generate this number
      Dim strBoundary = Strings.StrDup(27, "-") & Idboundary     ' mutipart post need "-" sign 

      Dim uri As String = "http://www.imageshack.us/upload_api.php"

      Dim hr As System.Net.HttpWebRequest = System.Net.WebRequest.Create(uri)

      hr.Method = "POST"
      hr.ContentType = "multipart/form-data; boundary=" & strBoundary

      Dim ns = hr.GetRequestStream
      Dim fileName = "snap-" + Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png"
      Dim fieldPart As String = _
        "--" & strBoundary & vbCrLf & _
        "Content-Disposition: form-data; name=""key""" & vbCrLf & _
        vbCrLf & "0568HIJM74235d425405d9711d77d398a02d3bf7" & _
        vbCrLf & "--" & strBoundary & vbCrLf & _
        "Content-Disposition: form-data; name=""public""" & vbCrLf & _
        vbCrLf & "no" & _
        vbCrLf & "--" & strBoundary & vbCrLf & _
        "Content-Disposition: form-data; name=""fileupload""; filename=""" + fileName + """" & vbCrLf & _
        "Content-Type: image/png" & vbCrLf & vbCrLf '& _

      Dim header() As Byte = System.Text.Encoding.Default.GetBytes(fieldPart)
      ns.Write(header, 0, header.Length)

      Dim fileStream As New IO.FileStream(sourceFilespec, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
      Dim bytesSize As Integer, buffer(2048) As Byte, bytesCount As Integer
      bytesSize = fileStream.Read(buffer, 0, buffer.Length)
      While bytesSize > 0
        ns.Write(buffer, 0, bytesSize)
        bytesSize = fileStream.Read(buffer, 0, buffer.Length)
        bytesCount += bytesSize : progressReceiver.reportProgress(bytesCount)
      End While
      fileStream.Close()

      header = System.Text.Encoding.Default.GetBytes(vbCrLf & vbCrLf & "--" & strBoundary & "--" & vbCrLf & vbCrLf)
      ns.Write(header, 0, header.Length)

      ns.Close()

      'Dim sr As New System.IO.StreamReader(ns, System.Text.Encoding.ASCII)
      'Dim data As String = sr.ReadToEnd

      Dim RES = hr.GetResponse()   '      T E S T  !!!

      Dim recv = RES.GetResponseStream
      Dim reader As New System.IO.StreamReader(recv)
      result = reader.ReadToEnd
      Return True
    Catch ex As System.Net.WebException
      errorMsg = ex.Message + vbNewLine + New IO.StreamReader(ex.Response.GetResponseStream).ReadToEnd
      Return False
    Catch ex As Exception
      errorMsg = ex.Message
      Return False
    End Try
  End Function

  Public Overrides Function ToString() As String
    Return "ImageShack"
  End Function

End Class
