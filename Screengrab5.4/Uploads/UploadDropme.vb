Public Class UploadDropme
  Inherits AbstractUploader

  Dim postData As String = "key=8b95f50a-959f-4684-8918-f3ab6fc7968a&username=" + glob.para("frm_options__txtLoginUser") + "&password=" + glob.para("frm_options__txtLoginPass")
  Dim url As String

  Public Overrides Function ToString() As String
    Return "DropMe"
  End Function

  Public Overrides Sub initializeOptions(ByVal optionsPanel As IUploadOptionsPanel)
    Dim RESULT As Hashtable = TryLoadJSON("https://app.dropme.de/api/clipboards/last", postData)
    If RESULT Is Nothing Then Return
    If RESULT("success") <> True Then
      If MsgBox("Der Server hat eine Fehlermeldung zurückgeliefert. Bitte überprüfe, ob die Verbindung mit dem Internet hergestellt ist und die richtigen Logindaten für DropMe.de eingetragen sind." + vbNewLine + vbNewLine + "Fehlermeldung: " + RESULT("error") + vbNewLine + vbNewLine + "Sollen die Einstellungen geöffnet werden, um die Logindaten zu überprüfen?", MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Fehler") = MsgBoxResult.Yes Then
        frm_options.Show()
      End If
      Return
    End If

    Dim LIST As ArrayList = RESULT("last_used")
    Dim dropdownList(LIST.Count - 1) As String, i As Integer = 0
    For Each item As Hashtable In LIST
      If item("owner") = "" Then
        dropdownList(i) = item("name")
      Else
        dropdownList(i) = item("owner") + "/" + item("name")
      End If
      i = i + 1
    Next
    Dim defFilename = Now.ToString("yyyy-MM-dd-HHmmss") + ".png"

    optionsPanel.addCombobox("clipboard", "Clipboard", dropdownList)
    optionsPanel.addTextbox("filename", "Dateiname", defFilename)

  End Sub

  Public Overrides Sub runResultGui()
    'OK
    Clipboard.Clear()
    Clipboard.SetText(url)
    Dim histItem As New frm_blueScreen.HistoryItem
    histItem.isUpload = True : histItem.url = url
    FRM.AddToHistory(histItem)

    uploadHistoryAdd("<a href=""" + url + """>" + url + "</a>")

    Beep()
  End Sub

  Public Overrides Function runUpload(ByVal progressReceiver As IUploadOptionsPanel) As Boolean
    Dim filename As String = progressReceiver.getValue("filename")
    If filename.ToLower.EndsWith(".png") = False Then filename += ".png"

    Try
      Dim selClip = Split(progressReceiver.getValue("clipboard"), "/", 2)
      If selClip.Length = 1 Then selClip = New String() {"", selClip(0)}
      Dim RESULT As Hashtable = TryLoadJSON("https://app.dropme.de/api/info?owner=" + selClip(0) + "&name=" + selClip(1), postData)
      If RESULT Is Nothing Then
        errorMsg = "Invalid Clipboard"
        Return False
      End If

      Dim cbid As String = RESULT("cbid")

      Dim Idboundary = "sg6dropmeupload" & Now.Ticks    ' you can generate this number
      Dim strBoundary = Strings.StrDup(27, "-") & Idboundary     ' mutipart post need "-" sign 

      Dim fieldPart As String = _
        "--" & strBoundary & vbCrLf & _
        "Content-Disposition: form-data; name=""key""" & vbCrLf & _
        vbCrLf & "8b95f50a-959f-4684-8918-f3ab6fc7968a" & _
        vbCrLf & "--" & strBoundary & vbCrLf & _
        "Content-Disposition: form-data; name=""key""" & vbCrLf & _
        vbCrLf & "8b95f50a-959f-4684-8918-f3ab6fc7968a" & _
        vbCrLf & "--" & strBoundary & vbCrLf & _
        "Content-Disposition: form-data; name=""username""" & vbCrLf & _
        vbCrLf & glob.para("frm_options__txtLoginUser") & _
        vbCrLf & "--" & strBoundary & vbCrLf & _
        "Content-Disposition: form-data; name=""password""" & vbCrLf & _
        vbCrLf & glob.para("frm_options__txtLoginPass") & _
        vbCrLf & "--" & strBoundary & vbCrLf & _
        "Content-Disposition: form-data; name=""uploaded""; filename=""" + filename + """" & vbCrLf & _
        "Content-Type: application/octet-stream" & vbCrLf & vbCrLf '& _

      Dim cl As Integer = FileLen(sourceFilespec) + fieldPart.Length + 8 + strBoundary.Length

      Dim uri As String = "https://app.dropme.de/api/write/" & cbid
      Dim hr As System.Net.HttpWebRequest = System.Net.WebRequest.Create(uri)

      hr.Method = "POST"
      hr.ContentType = "multipart/form-data; boundary=" & strBoundary

      Dim ns = hr.GetRequestStream

      'Dim header() As Byte = System.Text.Encoding.Default.GetBytes(headerPart)
      'ns.Write(header, 0, header.Length)

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

      header = System.Text.Encoding.Default.GetBytes(vbCrLf & vbCrLf & "--" & strBoundary & "--")
      ns.Write(header, 0, header.Length)

      ns.Close()

      Dim RES = hr.GetResponse   '      T E S T  !!!
      Dim recv = RES.GetResponseStream
      Dim reader As New System.IO.StreamReader(recv)
      Dim data = reader.ReadToEnd

      Dim RESULT2 As Hashtable = JSON.JsonDecode(data)
      If RESULT2 Is Nothing Then
        errorMsg = "Ungültige Serverantwort"
        Return False
      End If

      If RESULT2("success") <> True Then
        errorMsg = RESULT2("error")
        Return False
      End If


      Me.url = RESULT2("new_item")("url")
      Return True

    Catch ex As System.Net.WebException
      errorMsg = ex.Message + vbNewLine + New IO.StreamReader(ex.Response.GetResponseStream).ReadToEnd
      Return False
    Catch ex As Exception
      errorMsg = ex.Message
      Return False
    End Try
  End Function

  Public Function TryLoadJSON(ByVal uri As String, Optional ByVal post As String = Nothing) As Hashtable
    Dim RESULT_String As String, success As Boolean
    If post = Nothing Then
      RESULT_String = TwAjax.getUrlContent(uri)
    Else
      RESULT_String = TwAjax.postUrl(uri, post)
    End If
    Dim RESULT As Hashtable = JSON.JsonDecode(RESULT_String, success)
    If success = False Then
      MsgBox("Es konnte keine Verbindung zum Server aufgebaut werden. Bitte überprüfe, ob die Verbindung mit dem Internet hergestellt ist.", MsgBoxStyle.Critical, "Fehler")
      Return Nothing
    End If
    Return RESULT
  End Function
End Class
