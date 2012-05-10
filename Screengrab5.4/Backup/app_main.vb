Imports System.Drawing.Imaging
Module app_main
  Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Long

  Public grabsch As New ScreenshotGenerator
  Public m_ChildFormNumber As Integer = 0
  Public m_Username As String
  Public AutoUpload As Boolean
  Public AutoUpload2 As Boolean

  Sub main()

  End Sub

  Function GetUsername() As String
    If m_Username = "" Then
      Dialog1.ShowDialog()
    End If
    Return m_Username
  End Function

  Sub openGrabWindow()
    Dim pic As Bitmap = grabsch.Capture()
    'frm_grab.PictureBox1.Image = pic
    frm_grab.BackgroundImage = pic

    frm_grab.labAuswahl.Hide()
    frm_grab.tmrMousemove.Enabled = False

    frm_grab.Show()

    frm_grab.Left = 0
    frm_grab.Top = 0
    frm_grab.WindowState = FormWindowState.Maximized
  End Sub

  Function showNewForm() As frm_inner
    ' Neue Instanz des untergeordneten Formulars erstellen.
    Dim ChildForm As New frm_inner
    ' Vor der Anzeige dem MDI-Formular unterordnen.
    ChildForm.MdiParent = frm_main

    'ChildForm.PictureBox1.Image = pic
    'ChildForm.BackgroundImage = pic
    m_ChildFormNumber += 1
    'ChildForm.Text = "Fenster " & m_ChildFormNumber

    ChildForm.Show()
    Return ChildForm
  End Function

  Function showNewTextForm() As frm_innerText
    Dim ChildForm As New frm_innerText
    ChildForm.MdiParent = frm_main

    m_ChildFormNumber += 1

    ChildForm.Show()
    Return ChildForm
  End Function

  Sub grabWindowDone()
    Dim x, y, XX, YY As Integer
    With frm_grab.labAuswahl
      x = .Left
      y = .Top
      XX = .Width
      YY = .Height
    End With
    System.Windows.Forms.Application.DoEvents()

    Dim pic As Bitmap = grabsch.CaptureByRect(x, y, XX, YY)
    showNewForm().BackgroundImage = pic

    If AutoUpload Then ActiveImage_upload()
    If AutoUpload2 Then ActiveImage_uploadToImgChat()

  End Sub

  Sub ActiveImage_upload()
    If Not frm_main.ActiveMdiChild Is Nothing Then
      Dim username As String = GetUsername()
      If username = "" Then Exit Sub

      Dim pic As System.Drawing.Image = frm_main.ActiveMdiChild.BackgroundImage
      Dim filespec As String = System.IO.Path.GetTempPath() + "tmpupload.jpg"
      Dim destFilespec As String = "/httpdocs/twiki_temp/u_" + username + ".jpg"
      SaveJpeg(filespec, pic, 100)
      pic.Save(filespec, System.Drawing.Imaging.ImageFormat.Jpeg)

      Dim ftp As New Utilities.FTP.FTPclient("www.teamwiki.de", "vserver3", "lezifato")
      Dim ret As Boolean = ftp.Upload(filespec, destFilespec)

      Clipboard.SetText("http://teamwiki.de/twiki_temp/u_" + username + ".jpg")
      Status = "Hochgeladen. URL: http://teamwiki.de/twiki_temp/u_" + username + ".jpg" + _
            "... wurde in die Zwischenablage kopiert!"
      resetStatusAfter3Seconds()
    End If
  End Sub

  Sub ActiveImage_uploadToImgChat()
    If Not frm_main.ActiveMdiChild Is Nothing Then
      Dim username As String = GetUsername()
      If username = "" Then Exit Sub

      Dim pic As System.Drawing.Image = frm_main.ActiveMdiChild.BackgroundImage
      Dim filespec As String = System.IO.Path.GetTempPath() + "tmpupload.jpg"
      Dim actDateTime As String = Now().ToString("yyMMddHHmmss")
      Dim destFilespec As String = "/twiki_temp/imgchat_" + actDateTime + "_" + username + ".jpg"

      SaveJpeg(filespec, pic, 100)
      pic.Save(filespec, System.Drawing.Imaging.ImageFormat.Jpeg)

      Dim ftp As New Utilities.FTP.FTPclient("www.teamwiki.de", "vserver3", "lezifato")
      Dim ret As Boolean = ftp.Upload(filespec, "/httpdocs" + destFilespec)

      Clipboard.SetText("http://teamwiki.de" + destFilespec)
      MsgBox("filespec... " + filespec + vbNewLine + "-> destFileSpec... " + destFilespec + _
            vbNewLine + "ok?" + ret.ToString + vbNewLine + vbNewLine + _
            "URL: http://teamwiki.de" + destFilespec + vbNewLine + _
            "... wurde in die Zwischenablage kopiert!")
      Status = "Hochgeladen. URL: http://teamwiki.de" + destFilespec + _
            "... wurde in die Zwischenablage kopiert!"
      resetStatusAfter3Seconds()

      Dim requestUrl As String
      requestUrl = "http://teamwiki.de/twiki/labs/twChatLib/chatlib.service.php?cmd=append&chatroom=es-chat1&message=|IMG|" + "http://teamwiki.de" + destFilespec
      frm_main.WebBrowser1.Navigate(requestUrl)
    End If
  End Sub


  Sub ActiveImage_copyToClip()
    If Not frm_main.ActiveMdiChild Is Nothing Then
      Dim pic As System.Drawing.Image = frm_main.ActiveMdiChild.BackgroundImage
      Clipboard.SetImage(pic)
      Status = "Bild wurde in die Zwischenablage kopiert."
    End If
  End Sub

  Sub ActiveImage_saveToFile()
    If Not frm_main.ActiveMdiChild Is Nothing Then
      Dim result As System.Windows.Forms.DialogResult
      Dim fileSpec As String
      Dim dateTimeSpec As String = Now().ToString("yyyy-MM-dd_hh-mm-ss")
      With frm_main.SaveFileDialog1
        .Filter = "Bild im JPG-Format (*.jpg)|*.jpg|Alle Dateien (*.*)|*.*"
        .FileName = Microsoft.VisualBasic.FileIO.SpecialDirectories.MyPictures + "\screenGrab\grab_" + dateTimeSpec + ".jpg"
        result = .ShowDialog()
        fileSpec = .FileName
      End With
      If result = DialogResult.OK Then
        Dim pic As System.Drawing.Image = frm_main.ActiveMdiChild.BackgroundImage
        Status = "Datei wurde gespeichert."
        resetStatusAfter3Seconds()
      End If
    End If
  End Sub
  'labStatus
  'property 
  Public Property Status() As String
    Get
      Return frm_main.labStatus.Text
    End Get
    Set(ByVal value As String)
      If value = "" Then
        frm_main.labStatus.Text = "   (c) 2007 by Max Weller        "
      Else
        frm_main.labStatus.Text = value
      End If
    End Set
  End Property

  Sub resetStatusAfter3Seconds()
    frm_main.tmrResetStatus.Enabled = True

  End Sub


  Sub noFocus()
    frm_main.txtFocusChatcher.Focus()

  End Sub

  ' Please do not remove :) 
  ' Written by Kourosh Derakshan 
  ' 

  ' Saves an image as a jpeg image, with the given quality 
  ' Gets:
  '   path   - Path to which the image would be saved.
  '   quality - An integer from 0 to 100, with 100 being the 
  '           highest quality
  Public Sub SaveJpeg(ByVal path As String, ByVal img As Image, ByVal quality As Long)
    If ((quality < 0) OrElse (quality > 100)) Then
      Throw New ArgumentOutOfRangeException("quality must be between 0 and 100.")
    End If

    ' Encoder parameter for image quality
    Dim qualityParam As New EncoderParameter(Encoder.Quality, quality)
    ' Jpeg image codec 
    Dim jpegCodec As ImageCodecInfo = GetEncoderInfo("image/jpeg")

    Dim encoderParams As New EncoderParameters(1)
    encoderParams.Param(0) = qualityParam
    img.Save(path, jpegCodec, encoderParams)
  End Sub



  ' Returns the image codec with the given mime type 
  Private Function GetEncoderInfo(ByVal mimeType As String) As ImageCodecInfo
    ' Get image codecs for all image formats 
    Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageEncoders()

    ' Find the correct image codec 
    For i As Integer = 0 To codecs.Length - 1
      If (codecs(i).MimeType = mimeType) Then
        Return codecs(i)
      End If
    Next i

    Return Nothing
  End Function


End Module
