Imports System.Web

Public Class frm_commonUpload

  'Common
  Public sourceFilespec As String

  'DropMe
  Dim WithEvents bwUploadDropme As New System.ComponentModel.BackgroundWorker
  Dim postData As String = "key=8b95f50a-959f-4684-8918-f3ab6fc7968a&username=" + glob.para("frm_options__txtLoginUser") + "&password=" + glob.para("frm_options__txtLoginPass")

  'facebook
  Dim WithEvents bwUploadFacebook As New System.ComponentModel.BackgroundWorker
  Dim facebookUpload_msg, facebookUpload_account() As String
  Dim facebookUpload_accountList As New List(Of String())

  'ImgUr
  Dim WithEvents bwUploadImgur As New System.ComponentModel.BackgroundWorker

  'ImageShack
  Dim WithEvents bwUploadImageshack As New System.ComponentModel.BackgroundWorker


#Region "Common"

  Private Sub frm_dropmeUpload_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    pnlDropme.Location = New Point(0, 40)
    pnlMediacrush.Location = New Point(0, 40)
    pnlImgur.Location = New Point(0, 40)
    pnlFtp.Location = New Point(0, 40)
    pnlImageshack.Location = New Point(0, 40)
    cmbSelectUploadTarget.SelectedIndex = glob.para("frm_dropmeUpload__uploadTarget", "0")
  End Sub

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

  Private Sub cmbSelectUploadTarget_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSelectUploadTarget.SelectedIndexChanged
    onTargetSelected()
  End Sub

  Sub onTargetSelected()
    pnlDropme.Hide() : pnlMediacrush.Hide() : pnlImgur.Hide() : pnlFtp.Hide() : pnlImageshack.Hide()
    Dim deltaY = Me.Height - Me.ClientSize.Height
    Select Case cmbSelectUploadTarget.SelectedIndex
      Case 1 : pnlDropme.Show() : Me.Height = pnlDropme.Top + pnlDropme.Height + deltaY : Me.AcceptButton = btnUploadDropme : InitDropme()
      Case 2 : pnlMediacrush.Show() : Me.Height = pnlMediacrush.Top + pnlMediacrush.Height + deltaY : Me.AcceptButton = btnUploadMediacrush : InitMediacrush()
      Case 3 : pnlImgur.Show() : Me.Height = pnlImgur.Top + pnlImgur.Height + deltaY : Me.AcceptButton = btnUploadImgur
      Case 4 : pnlFtp.Show() : Me.Height = pnlFtp.Top + pnlFtp.Height + deltaY : Me.AcceptButton = btnUploadFtp
      Case 5 : pnlImageshack.Show() : Me.Height = pnlImageshack.Top + pnlImageshack.Height + deltaY : Me.AcceptButton = btnUploadImageshack
      Case Else : Me.Height = pnlImgur.Top + deltaY + 5
    End Select
    glob.para("frm_dropmeUpload__uploadTarget") = cmbSelectUploadTarget.SelectedIndex
  End Sub

#End Region



#Region "DropMe"

  Sub InitDropme()
    If pnlDropme.Enabled Then Return

    Dim RESULT As Hashtable = TryLoadJSON("http://dropme.de/api/clipboards/last", postData)
    If RESULT Is Nothing Then Return
    If RESULT("success") <> True Then
      If MsgBox("Der Server hat eine Fehlermeldung zurückgeliefert. Bitte überprüfe, ob die Verbindung mit dem Internet hergestellt ist und die richtigen Logindaten für DropMe.de eingetragen sind." + vbNewLine + vbNewLine + "Fehlermeldung: " + RESULT("error") + vbNewLine + vbNewLine + "Sollen die Einstellungen geöffnet werden, um die Logindaten zu überprüfen?", MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Fehler") = MsgBoxResult.Yes Then
        frm_options.Show()
      End If
      Return
    End If

    Dim LIST As ArrayList = RESULT("last_used")
    For Each item As Hashtable In LIST
      If item("owner") = "" Then
        cmbDropmeClipboard.Items.Add(item("name"))
      Else
        cmbDropmeClipboard.Items.Add(item("owner") + "/" + item("name"))
      End If
    Next
    If cmbDropmeClipboard.Items.Count > 0 Then cmbDropmeClipboard.SelectedIndex = 0

    txtDropmeFilename.Text = Now.ToString("yyyy-MM-dd-HHmmss") + ".png"
    txtDropmeFilename.Focus()
    txtDropmeFilename.SelectAll()
    pnlDropme.Enabled = True
  End Sub


  Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUploadDropme.Click
    pnlDropme.Enabled = False : cmbSelectUploadTarget.Enabled = False

    If txtDropmeFilename.Text.ToLower.EndsWith(".png") = False Then txtDropmeFilename.Text += ".png"

    pbDropme.Maximum = FileLen(sourceFilespec)
    pbDropme.Show()

    bwUploadDropme.WorkerReportsProgress = True
    bwUploadDropme.WorkerSupportsCancellation = True
    bwUploadDropme.RunWorkerAsync(cmbDropmeClipboard.Text)

    Enabled = True
  End Sub

  Private Sub bwUploadDropme_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwUploadDropme.DoWork
    Try
      Dim selClip = Split(DirectCast(e.Argument, String), "/", 2)
      If selClip.Length = 1 Then selClip = New String() {"", selClip(0)}
      Dim RESULT As Hashtable = TryLoadJSON("http://dropme.de/api/info?owner=" + selClip(0) + "&name=" + selClip(1), postData)
      If RESULT Is Nothing Then
        e.Result = New Object() {0, "Invalid Clipboard"}
        Return
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
        "Content-Disposition: form-data; name=""uploaded""; filename=""" + txtDropmeFilename.Text + """" & vbCrLf & _
        "Content-Type: application/octet-stream" & vbCrLf & vbCrLf '& _

      Dim cl As Integer = FileLen(sourceFilespec) + fieldPart.Length + 8 + strBoundary.Length

      'Dim headerPart As String = _
      '  "POST /api/write/" & cbid & " HTTP/1.1" & vbCrLf & _
      '  "Host: dropme.de" & vbCrLf & _
      '  "User-Agent: ScreenGrab/" & My.Application.Info.Version.ToString & vbCrLf & _
      '  "Content-Type: multipart/form-data; boundary=" & strBoundary & vbCrLf & _
      '  "Content-Length: " & cl & vbCrLf & vbCrLf

      ' IO.File.ReadAllText(sourceFilespec, System.Text.Encoding.ASCII) & vbCrLf & vbCrLf & _
      '"--" & strBoundary & "--"
      'WICHTIG: Es müssen zwei CRLF sein -- sonst schneidet er den Anfang der Datei ab

      'Dim sock As New System.Net.Sockets.TcpClient("localhost", 880) 
      'Dim sock As New System.Net.Sockets.TcpClient("dropme.de", 80)
      Dim uri As String = "http://dropme.de/api/write/" & cbid
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
        bytesCount += bytesSize : bwUploadDropme.ReportProgress(bytesCount)
      End While
      fileStream.Close()

      header = System.Text.Encoding.Default.GetBytes(vbCrLf & vbCrLf & "--" & strBoundary & "--")
      ns.Write(header, 0, header.Length)

      'Dim sr As New System.IO.StreamReader(ns, System.Text.Encoding.ASCII)
      'Dim data As String = sr.ReadToEnd

      'Dim recv(sock.ReceiveBufferSize) As Byte
      'Dim count = ns.Read(recv, 0, sock.ReceiveBufferSize)
      'Dim data = System.Text.Encoding.ASCII.GetString(recv)

      ns.Close()
      'sock.Close()

      Dim RES = hr.GetResponse   '      T E S T  !!!
      Dim recv = RES.GetResponseStream
      Dim reader As New System.IO.StreamReader(recv)
      Dim data = reader.ReadToEnd

      'MsgBox(data)

      'Dim httpParts() = Split(data, vbCrLf & vbCrLf, 2)
      'If httpParts.Length = 1 Then
      '  e.Result = New Object() {0, "HTTP Fehler"}
      '  Return
      'End If

      Dim RESULT2 As Hashtable = JSON.JsonDecode(data)
      If RESULT2 Is Nothing Then
        e.Result = New Object() {0, "Ungültige Serverantwort"}
        Return
      End If

      If RESULT2("success") <> True Then
        e.Result = New Object() {0, RESULT2("error")}
        Return
      End If


      e.Result = New Object() {1, RESULT2("new_item")("url")}


    Catch ex As System.Net.WebException
      e.Result = New Object() {0, ex.Message + vbNewLine + New IO.StreamReader(ex.Response.GetResponseStream).ReadToEnd}

    Catch ex As Exception
      e.Result = New Object() {0, ex.Message}
      Return
    End Try
  End Sub

  Private Sub bwUploadDropme_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bwUploadDropme.ProgressChanged
    pbDropme.Value = e.ProgressPercentage
  End Sub

  Private Sub bwUploadDropme_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwUploadDropme.RunWorkerCompleted
    If e.Result(0) = 0 Then
      'Fehler
      pbDropme.Hide()
      pnlDropme.Enabled = True : cmbSelectUploadTarget.Enabled = True
      lblDropmeError.Text = e.Result(1)
      lblDropmeError.Show()
    Else
      'OK
      Clipboard.Clear()
      Clipboard.SetText(e.Result(1))
      Dim histItem As New frm_blueScreen.HistoryItem
      histItem.isUpload = True : histItem.url = e.Result(1)
      FRM.AddToHistory(histItem)

      uploadHistoryAdd("<a href=""" + e.Result(1) + """>" + e.Result(1) + "</a>")

      Beep()
      Close()
    End If
  End Sub

#End Region


#Region "Mediacrush"
  Sub InitMediacrush()

  End Sub



#End Region

#Region "Imgur"

  Private Sub btnUploadImgur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUploadImgur.Click
    pbImgur.Maximum = FileLen(sourceFilespec)
    pbImgur.Show()

    pnlImgur.Enabled = False : cmbSelectUploadTarget.Enabled = False

    bwUploadImgur.WorkerReportsProgress = True
    bwUploadImgur.WorkerSupportsCancellation = True
    bwUploadImgur.RunWorkerAsync(New String() {txtImgurTitle.Text, txtImgurCaption.Text})
  End Sub

  Private Sub bwUploadImgur_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwUploadImgur.DoWork
    Try
      Dim args() As String = e.Argument
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
        vbCrLf & args(0) & _
        vbCrLf & "--" & strBoundary & vbCrLf & _
        "Content-Disposition: form-data; name=""caption""" & vbCrLf & _
        vbCrLf & args(1) & _
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
        bytesCount += bytesSize : bwUploadImgur.ReportProgress(bytesCount)
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
        e.Result = New Object() {0, "Ungültige Serverantwort"}
        Return
      End If

      If RESULT2.ContainsKey("upload") Then
        e.Result = New Object() {1, RESULT2("upload")}
        Return
      ElseIf RESULT2.ContainsKey("images") Then
        e.Result = New Object() {1, RESULT2("images")}
        Return
      Else
        e.Result = New Object() {0, "Keine ID zurückgeliefert"}
      End If

    Catch ex As System.Net.WebException
      e.Result = New Object() {0, ex.Message + vbNewLine + New IO.StreamReader(ex.Response.GetResponseStream).ReadToEnd}

    Catch ex As Exception
      e.Result = New Object() {0, ex.Message}
      Return
    End Try
  End Sub

  Private Sub bwUploadImgur_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bwUploadImgur.ProgressChanged
    pbImgur.Value = e.ProgressPercentage
  End Sub

  Private Sub bwUploadImgur_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwUploadImgur.RunWorkerCompleted
    If e.Result(0) = 0 Then
      MsgBox(e.Result(1), MsgBoxStyle.Critical)
      pnlImgur.Enabled = True : cmbSelectUploadTarget.Enabled = True
    Else
      Dim para As Hashtable = e.Result(1)
      frm_imgurUploaded.DisplayInfo(para)
      Dim histItem As New frm_blueScreen.HistoryItem
      histItem.isUpload = True : histItem.url = para("links")("imgur_page")
      FRM.AddToHistory(histItem)

      Dim text As New System.Text.StringBuilder
      text.AppendLine("<img src=""" + para("links")("small_square") + """ align=""left"">")
      For Each k As String In para("links").Keys
        text.AppendLine(k + ": " + "<a href=""" + para("links")(k) + """>" + para("links")(k) + "</a><br>")
      Next
      uploadHistoryAdd(text.ToString)

      Close()
    End If
  End Sub

#End Region

#Region "Imageshack"

  Private Sub btnUploadImageshack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUploadImageshack.Click
    pbImageshack.Show()
    pbImageshack.Maximum = FileLen(sourceFilespec)

    pnlImageshack.Enabled = False : cmbSelectUploadTarget.Enabled = False

    bwUploadImageshack.WorkerReportsProgress = True
    bwUploadImageshack.RunWorkerAsync()
  End Sub

  Private Sub bwUploadImageshack_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwUploadImageshack.DoWork
    Try
      Dim args() As String = e.Argument
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
        bytesCount += bytesSize : bwUploadImageshack.ReportProgress(bytesCount)
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

      e.Result = New Object() {1, data}

    Catch ex As System.Net.WebException
      e.Result = New Object() {0, ex.Message + vbNewLine + New IO.StreamReader(ex.Response.GetResponseStream).ReadToEnd}

    Catch ex As Exception
      e.Result = New Object() {0, ex.Message}
      Return
    End Try
  End Sub

  Private Sub bwUploadImageshack_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bwUploadImageshack.ProgressChanged
    pbImageshack.Value = e.ProgressPercentage
  End Sub

  Private Sub bwUploadImageshack_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwUploadImageshack.RunWorkerCompleted
    If e.Result(0) = 0 Then
      MsgBox(e.Result(1), MsgBoxStyle.Critical)
      pnlImageshack.Enabled = True : cmbSelectUploadTarget.Enabled = True
    Else
      Dim str As New IO.StringReader(e.Result(1))
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
      Close()
    End If
  End Sub


#End Region


End Class