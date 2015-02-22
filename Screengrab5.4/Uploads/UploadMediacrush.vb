Public Class UploadMediacrush
  Implements ICommonUploader
  Private errorMsg As String
  Private resultUrl As String
  Private sourceFilespec As String
  Private endpoint As String

  Public Function getErrorMessage() As String Implements ICommonUploader.getErrorMessage
    Return errorMsg
  End Function

  Public Sub setSourceFile(ByVal fileSpec As String) Implements ICommonUploader.setSourceFile
    sourceFilespec = fileSpec
  End Sub

  Public Sub initializeOptions(ByVal optionsPanel As IUploadOptionsPanel) Implements ICommonUploader.initializeOptions
    Dim lastServer As String = glob.para("lastMediacrushAPIServer", "https://chat2.teamwiki.de")
    optionsPanel.addTextbox("url", "Server", lastServer)
  End Sub

  Public Sub runResultGui() Implements ICommonUploader.runResultGui
    glob.para("lastMediacrushAPIServer") = endpoint

    Dim link As String = resultUrl
    Process.Start(link)

    Dim histItem As New frm_blueScreen.HistoryItem
    histItem.isUpload = True : histItem.url = link
    FRM.AddToHistory(histItem)

    Dim text As New System.Text.StringBuilder
    text.AppendLine("<img src=""" + link + """ width=150 align=left><br><br>" + link + "<br style='clear:left'><hr>")

    uploadHistoryAdd(text.ToString)
  End Sub

  Public Function runUpload(ByVal progressReceiver As IUploadOptionsPanel) As Boolean Implements ICommonUploader.runUpload
    Try
      Dim Idboundary = "sg6upload." & Now.Ticks    ' you can generate this number
      Dim strBoundary = Strings.StrDup(27, "-") & Idboundary     ' mutipart post need "-" sign 

      endpoint = progressReceiver.getValue("url")
      Dim upload_uri As String = endpoint + "/api/upload/file"

      Dim hr As System.Net.HttpWebRequest = System.Net.WebRequest.Create(upload_uri)

      hr.Method = "POST"
      hr.ContentType = "multipart/form-data; boundary=" & strBoundary

      Dim ns = hr.GetRequestStream
      Dim fileName = "screenshot-" + Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png"
      Dim fieldPart As String = _
        "--" & strBoundary & vbCrLf & _
        "Content-Disposition: form-data; name=""name""" & vbCrLf & _
        vbCrLf & fileName & _
        vbCrLf & "--" & strBoundary & vbCrLf & _
        "Content-Disposition: form-data; name=""file""; filename=""" + fileName + """" & vbCrLf & _
        "Content-Type: application/octet-stream" & vbCrLf & vbCrLf '& _

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
      Dim data = reader.ReadToEnd

      ' MsgBox(data)

      Dim RESULT2 As Hashtable = JSON.JsonDecode(data)
      If RESULT2 Is Nothing Then
        errorMsg = "Ungültige Serverantwort"
        Return False
      End If

      If RESULT2.ContainsKey("hash") Then
        resultUrl = endpoint + "/" + RESULT2("hash") + ".png"
        Return True
      Else
        errorMsg = "Keine ID zurückgeliefert"
        Return False
      End If

    Catch ex As System.Net.WebException
      errorMsg = ex.Message + vbNewLine + New IO.StreamReader(ex.Response.GetResponseStream).ReadToEnd
      Return False
    Catch ex As Exception
      errorMsg = ex.Message
      Return False
    End Try
  End Function

  Public Overrides Function ToString() As String
    Return "MediaCrush (kompatibel)"
  End Function
End Class
