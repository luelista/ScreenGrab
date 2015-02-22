Public Class UploadImgur
  Inherits AbstractUploader
  Dim result As Hashtable

  Public Overrides Function ToString() As String
    Return "Imgur"
  End Function

  Public Overrides Sub initializeOptions(ByVal optionsPanel As IUploadOptionsPanel)
    optionsPanel.addTextbox("title", "Title", "")
    optionsPanel.addTextbox("caption", "Description", "")
  End Sub

  Public Overrides Sub runResultGui()
    frm_imgurUploaded.DisplayInfo(result)
    Dim histItem As New frm_blueScreen.HistoryItem
    histItem.isUpload = True : histItem.url = result("links")("imgur_page")
    FRM.AddToHistory(histItem)

    Dim text As New System.Text.StringBuilder
    text.AppendLine("<img src=""" + result("links")("small_square") + """ align=""left"">")
    For Each k As String In result("links").Keys
      text.AppendLine(k + ": " + "<a href=""" + result("links")(k) + """>" + result("links")(k) + "</a><br>")
    Next
    uploadHistoryAdd(text.ToString)

  End Sub

  Public Overrides Function runUpload(ByVal progressReceiver As IUploadOptionsPanel) As Boolean
    Try
      Dim Idboundary = "sg6imgurupload." & Now.Ticks    ' you can generate this number
      Dim strBoundary = Strings.StrDup(27, "-") & Idboundary     ' mutipart post need "-" sign 

      Dim uri As String
      If glob.para("imgur_account_url") <> "" And glob.para("imgur_token") <> "" Then
        Dim authLib As New OAuth.OAuthBase(), normURL, normParams, sig As String
        sig = authLib.GenerateSignature(New Uri("http://api.imgur.com/2/account/images.json"), IMGUR_CONSUMER_KEY, IMGUR_CONSUMER_SECRET, glob.para("imgur_token"), glob.para("imgur_token_secret"), "POST", authLib.GenerateTimeStamp(), authLib.GenerateNonce(), OAuth.OAuthBase.SignatureTypes.HMACSHA1, normURL, normParams)
        uri = normURL + "?" + normParams + "&oauth_signature=" + sig
      Else
        uri = "http://api.imgur.com/2/upload.json"
      End If

      Dim hr As System.Net.HttpWebRequest = System.Net.WebRequest.Create(uri)

      hr.Method = "POST"
      hr.ContentType = "multipart/form-data; boundary=" & strBoundary

      Dim ns = hr.GetRequestStream
      Dim fileName = "screenshot-" + Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png"
      Dim fieldPart As String = _
        "--" & strBoundary & vbCrLf & _
        "Content-Disposition: form-data; name=""key""" & vbCrLf & _
        vbCrLf & "98e3dbd5ba713245d72bce038055d742" & _
        vbCrLf & "--" & strBoundary & vbCrLf & _
        "Content-Disposition: form-data; name=""type""" & vbCrLf & _
        vbCrLf & "file" & _
        vbCrLf & "--" & strBoundary & vbCrLf & _
        "Content-Disposition: form-data; name=""name""" & vbCrLf & _
        vbCrLf & fileName & _
        vbCrLf & "--" & strBoundary & vbCrLf & _
        "Content-Disposition: form-data; name=""title""" & vbCrLf & _
        vbCrLf & progressReceiver.getValue("title") & _
        vbCrLf & "--" & strBoundary & vbCrLf & _
        "Content-Disposition: form-data; name=""caption""" & vbCrLf & _
        vbCrLf & progressReceiver.getValue("caption") & _
        vbCrLf & "--" & strBoundary & vbCrLf & _
        "Content-Disposition: form-data; name=""image""; filename=""" + fileName + """" & vbCrLf & _
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

      If RESULT2.ContainsKey("upload") Then
        result = RESULT2("upload")
        Return True
      ElseIf RESULT2.ContainsKey("images") Then
        result = RESULT2("images")
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
End Class
