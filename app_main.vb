Module app_main
  Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Long

  Public settingsFolder As String = "C:\yPara\ScreenGrab5\"

  Public glob As New cls_globPara(settingsFolder + "MW.ScreenGrab.Para")

  Public Const OFFLINE_USER = "_offline_"

  Public grabsch As New ScreenshotGenerator
  Public m_ChildFormNumber As Integer = 0
  Public m_Username As String
  Public AutoUpload As Boolean
  Public AutoUpload2 As Boolean

  Public FRM As frm_blueScreen

  Public fullDesktopImage As Image

  Public Enum MWSGInfo
    SIG
    SIG2
    reserved1
    url
    reserved2
    UserName
    DestRect
    TextBox1
    txtComment
    reserved3
  End Enum

  Public Const ftproot = "/httpdocs/data/vb-data"

  Sub main()

  End Sub

  Function isOfflineMode() As Boolean
    If twLoginuser = OFFLINE_USER Then
      If MsgBox("Diese Funktion steht im Offlinemodus nicht zur Verfügung. Möchtest du dich jetzt einloggen?", MsgBoxStyle.OkCancel Or MsgBoxStyle.Exclamation, "ScreenGrab im Offline-Modus") = MsgBoxResult.Ok Then
        onChangeLogin()
        If twLoginuser = OFFLINE_USER Then Return True
      Else
        Return True
      End If
    End If
  End Function

  Dim uplForm As frm_uploadingMulti

  Function getUplForm() As frm_uploadingMulti
    If uplForm Is Nothing OrElse uplForm.IsDisposed Then
      uplForm = New frm_uploadingMulti
    End If
    Return uplForm
  End Function

  Function getLastTargets() As String()
    Return Split(glob.para("lastTargets"), "::")
  End Function
  Sub addTargetFolder(ByVal fld As String)
    Dim lst() As String = Split(glob.para("lastTargets"), "::")
    Dim out(10) As String
    out(0) = fld
    Dim outIdx As Integer = 1
    For i = 0 To lst.Length - 1
      If outIdx > 9 Then Exit For
      If LCase(fld) <> LCase(lst(i)) Then out(outIdx) = lst(i) : outIdx += 1
    Next
    glob.para("lastTargets") = Join(out, "::")
    glob.saveParaFile()
  End Sub





  Sub showUploadInProgress()
    frm_tempScreenShotName.Top = frm_blueScreen.Top + (frm_blueScreen.Height - frm_tempScreenShotName.Height) / 2
    frm_tempScreenShotName.Left = frm_blueScreen.Left + (frm_blueScreen.Width - frm_tempScreenShotName.Width) / 2

    frm_tempScreenShotName.ViewUpload = True
    frm_tempScreenShotName.Show()
    frm_tempScreenShotName.Activate()
    Application.DoEvents()

  End Sub


  Function CreateNiceFileSize(ByVal size As Long) As String
    Dim run As Integer = 0
    Dim d As Double = Convert.ToDouble(size)
    Dim sizes As String() = {"B", "KB", "MB", "GB"}
    While d >= 1024
      d /= 1024
      run += 1
    End While

    Dim dou As Double = Math.Round(d, 2)
    Dim sizestring As String = dou.ToString()

    Return (sizestring + " " + sizes(run))
  End Function
  Sub startWebUpdate(ByVal autoUpdate As Boolean)

    Dim updaterFilespec As String = ExePath("mwwebupdate")

    If updaterFilespec = "" OrElse My.Computer.FileSystem.FileExists(updaterFilespec) = False OrElse FileLen(updaterFilespec) < 40000 Then
      If Not autoUpdate Then MsgBox("Der Updater wurde nicht gefunden bzw. du hast eine veraltete Version. " + vbNewLine + "Wenn du die neuste Version hast, starte den Updater einmal von Hand und versuche es nochmals. Ansonsten melde dich bei Max Weller ;-)")
      Exit Sub
    End If

    Dim updaterPara(5) As String
    updaterPara(0) = "screengrab4" 'appID
    updaterPara(1) = glob.appPath 'localFolder
    updaterPara(2) = "/autostart" 'autostart?
    updaterPara(3) = "/autoclose" 'autoclose?
    updaterPara(4) = Application.ExecutablePath 'startAfterUpdate(1)
    updaterPara(5) = "" 'startAfterUpdate(2)
    Dim updaterArguments As String = Join(updaterPara, "#²#")

    ' MsgBox(updaterFilespec + " " + updaterArguments, , "Updater wird aufgerufen...")

    glob.saveParaFile()
    Process.Start(updaterFilespec, updaterArguments)

  End Sub


  Function GetUsername() As String
    Return twLoginuser
  End Function

  'Sub ActiveImage_upload()
  '  If Not frm_main.ActiveMdiChild Is Nothing Then
  '    Dim username As String = GetUsername()
  '    If username = "" Then Exit Sub

  '    Dim pic As System.Drawing.Image = frm_main.ActiveMdiChild.BackgroundImage
  '    Dim filespec As String = System.IO.Path.GetTempPath() + "tmpupload.jpg"
  '    Dim destFilespec As String = "/httpdocs/twiki_temp/u_" + username + ".jpg"
  '    SaveJpeg(filespec, pic, 100)
  '    pic.Save(filespec, System.Drawing.Imaging.ImageFormat.Jpeg)

  '    Dim ftp As New Utilities.FTP.FTPclient("www.teamwiki.de", "vserver3", "lezifato")
  '    Dim ret As Boolean = ftp.Upload(filespec, destFilespec)

  '    Clipboard.SetText("http://teamwiki.de/twiki_temp/u_" + username + ".jpg")
  '    Status = "Hochgeladen. URL: http://teamwiki.de/twiki_temp/u_" + username + ".jpg" + _
  '          "... wurde in die Zwischenablage kopiert!"
  '    resetStatusAfter3Seconds()
  '  End If
  'End Sub

  'Sub ActiveImage_uploadToImgChat()
  '  If Not frm_main.ActiveMdiChild Is Nothing Then
  '    Dim username As String = GetUsername()
  '    If username = "" Then Exit Sub

  '    Dim pic As System.Drawing.Image = frm_main.ActiveMdiChild.BackgroundImage
  '    Dim filespec As String = System.IO.Path.GetTempPath() + "tmpupload.jpg"
  '    Dim actDateTime As String = Now().ToString("yyMMddHHmmss")
  '    Dim destFilespec As String = "/twiki_temp/imgchat_" + actDateTime + "_" + username + ".jpg"

  '    SaveJpeg(filespec, pic, 100)
  '    pic.Save(filespec, System.Drawing.Imaging.ImageFormat.Jpeg)

  '    Dim ftp As New Utilities.FTP.FTPclient("www.teamwiki.de", "vserver3", "lezifato")
  '    Dim ret As Boolean = ftp.Upload(filespec, "/httpdocs" + destFilespec)

  '    Clipboard.SetText("http://teamwiki.de" + destFilespec)
  '    MsgBox("filespec... " + filespec + vbNewLine + "-> destFileSpec... " + destFilespec + _
  '          vbNewLine + "ok?" + ret.ToString + vbNewLine + vbNewLine + _
  '          "URL: http://teamwiki.de" + destFilespec + vbNewLine + _
  '          "... wurde in die Zwischenablage kopiert!")
  '    Status = "Hochgeladen. URL: http://teamwiki.de" + destFilespec + _
  '          "... wurde in die Zwischenablage kopiert!"
  '    resetStatusAfter3Seconds()

  '    Dim requestUrl As String
  '    requestUrl = "http://teamwiki.de/twiki/labs/twChatLib/chatlib.service.php?cmd=append&chatroom=es-chat1&message=|IMG|" + "http://teamwiki.de" + destFilespec
  '    frm_main.WebBrowser1.Navigate(requestUrl)
  '  End If
  'End Sub


  'Sub ActiveImage_copyToClip()
  '  If Not frm_main.ActiveMdiChild Is Nothing Then
  '    Dim pic As System.Drawing.Image = frm_main.ActiveMdiChild.BackgroundImage
  '    Clipboard.SetImage(pic)
  '    Status = "Bild wurde in die Zwischenablage kopiert."
  '  End If
  'End Sub

  'Sub ActiveImage_saveToFile()
  '  If Not frm_main.ActiveMdiChild Is Nothing Then
  '    Dim result As System.Windows.Forms.DialogResult
  '    Dim fileSpec As String
  '    Dim dateTimeSpec As String = Now().ToString("yyyy-MM-dd_hh-mm-ss")
  '    With frm_main.SaveFileDialog1
  '      .Filter = "Bild im JPG-Format (*.jpg)|*.jpg|Alle Dateien (*.*)|*.*"
  '      .FileName = Microsoft.VisualBasic.FileIO.SpecialDirectories.MyPictures + "\screenGrab\grab_" + dateTimeSpec + ".jpg"
  '      result = .ShowDialog()
  '      fileSpec = .FileName
  '    End With
  '    If result = DialogResult.OK Then
  '      Dim pic As System.Drawing.Image = frm_main.ActiveMdiChild.BackgroundImage
  '      Status = "Datei wurde gespeichert."
  '      resetStatusAfter3Seconds()
  '    End If
  '  End If
  'End Sub
  ''labStatus
  ''property 
  'Public Property Status() As String
  '  Get
  '    Return frm_main.labStatus.Text
  '  End Get
  '  Set(ByVal value As String)
  '    If value = "" Then
  '      frm_main.labStatus.Text = "   (c) 2007 by Max Weller        "
  '    Else
  '      frm_main.labStatus.Text = value
  '    End If
  '  End Set
  'End Property

  'Sub resetStatusAfter3Seconds()
  '  frm_main.tmrResetStatus.Enabled = True

  'End Sub


  'Sub noFocus()
  '  frm_main.txtFocusChatcher.Focus()

  'End Sub



End Module
