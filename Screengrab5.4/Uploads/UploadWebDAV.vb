Public Class UploadWebDAV
  Inherits AbstractUploader

  Public Overrides Function ToString() As String
    Return "WebDAV (z.B. OwnCloud)"
  End Function

  Public Overrides Sub initializeOptions(ByVal optionsPanel As IUploadOptionsPanel)
    optionsPanel.addTextbox("url", "WebDAV Folder URL", glob.para("UploadWebDAV__url", ""))
    optionsPanel.addTextbox("username", "Username", glob.para("UploadWebDAV__username", ""))
    optionsPanel.addTextbox("password", "Password", glob.para("UploadWebDAV__password", ""))
    CType(optionsPanel.getPanel().Controls("field_password"), TextBox).UseSystemPasswordChar = True

    Dim fileName = "screenshot-" + Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png"
    optionsPanel.addTextbox("filename", "File Name", filename)

  End Sub

  Public Overrides Sub runResultGui()
    MsgBox("Upload zu WebDAV erfolgreich")
  End Sub

  Public Overrides Function runUpload(ByVal handle As IUploadOptionsPanel) As Boolean
    Try
      Dim Idboundary = "sg6upload." & Now.Ticks    ' you can generate this number
      Dim strBoundary = Strings.StrDup(27, "-") & Idboundary     ' mutipart post need "-" sign 

      Dim upload_uri As String = handle.getValue("url") + handle.getValue("filename")

      Dim hr As System.Net.HttpWebRequest = System.Net.WebRequest.Create(upload_uri)

      glob.para("UploadWebDAV__url") = handle.getValue("url")
      glob.para("UploadWebDAV__username") = handle.getValue("username")
      glob.para("UploadWebDAV__password") = handle.getValue("password")

      hr.Method = "PUT"
      hr.ContentType = "multipart/form-data; boundary=" & strBoundary
      hr.Credentials = New System.Net.NetworkCredential(handle.getValue("username"), handle.getValue("password"))

      Dim ns = hr.GetRequestStream
      Dim fileStream As New IO.FileStream(sourceFilespec, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
      Dim bytesSize As Integer, buffer(2048) As Byte, bytesCount As Integer
      bytesSize = fileStream.Read(buffer, 0, buffer.Length)
      While bytesSize > 0
        ns.Write(buffer, 0, bytesSize)
        bytesSize = fileStream.Read(buffer, 0, buffer.Length)
        bytesCount += bytesSize : handle.reportProgress(bytesCount)
      End While
      fileStream.Close()
      ns.Close()

      Dim RES = hr.GetResponse()   '      T E S T  !!!

      Dim recv = RES.GetResponseStream
      Dim reader As New System.IO.StreamReader(recv)
      Dim data = reader.ReadToEnd

      'MsgBox(data)
      Return True
      
    Catch ex As System.Net.WebException
      errorMsg = ex.Message + vbNewLine + New IO.StreamReader(ex.Response.GetResponseStream).ReadToEnd
      Return False
    Catch ex As Exception
      errorMsg = ex.Message
      Return False
    End Try
  End Function
End Class
