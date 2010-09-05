Imports System.Drawing.Imaging

Module app_grabWindow

  Dim grabTempScreenshot As Image
  Dim isGrabWindowVisible As Boolean

  <Runtime.InteropServices.DllImport("user32.dll", SetLastError:=True)> _
  Private Function GetForegroundWindow() As IntPtr
  End Function

  Sub grabCurrentWindow()
    grabsch.Window = GetForegroundWindow()

    Dim bmp = grabsch.Capture
    loadImage(bmp)

    grabsch.Window = IntPtr.Zero

    FRM.Show()
    FRM.Activate()
  End Sub

  Sub openGrabWindow()
    If isGrabWindowVisible Then Exit Sub

    If glob.para("frm_options__checkHideWhileGrab", "TRUE") = "TRUE" Then
      FRM.Hide()
      Application.DoEvents()
      Application.DoEvents()
      Application.DoEvents()
      Threading.Thread.Sleep(333)
      Application.DoEvents()
      Application.DoEvents()
      Application.DoEvents()
    End If

    grabTempScreenshot = grabsch.ScreenCapture()

    frm_grab.BackgroundImage = grabTempScreenshot

    isGrabWindowVisible = True
    SetWindowPos(frm_grab.Handle, IntPtr.Zero, ScreenArea.LeftMostBound, ScreenArea.TopMostBound, _
                 ScreenArea.TotalWidth, ScreenArea.TotalWidth, SWPFlags.SWP_NOREDRAW)

    SetWindowPos(frm_grab.Handle, IntPtr.Zero, 0, 0, 0, 0, SWPFlags.SWP_SHOWWINDOW Or _
                 SWPFlags.SWP_NOREDRAW Or SWPFlags.SWP_NOMOVE Or SWPFlags.SWP_NOSIZE)

  End Sub


  Sub grabWindowCancel()
    ' wird sowohl beim Abbrechen als auch nach einem normalen Grab aufgerufen

    grabTempScreenshot.Dispose()
    grabTempScreenshot = Nothing
    frm_grab.Hide()
    isGrabWindowVisible = False

    FRM.Show() : FRM.WindowState = FormWindowState.Normal : FRM.Activate()
  End Sub

  Sub grabWindowDone()
    Dim x, y, XX, YY As Integer
    frm_grab.getRect(x, y, XX, YY) 'ByREF

    If XX = 0 Or YY = 0 Then grabWindowCancel() : Exit Sub
    fullDesktopImage = grabTempScreenshot.Clone()
    
    deltaX = x
    deltaY = y

    Dim resizeWindow = FRM.chk_blueScreenMode.Checked
    setImageSize(XX, YY, resizeWindow)

    FRM.Show() : FRM.WindowState = FormWindowState.Normal : FRM.Activate()

    'verschiedene Automatiken

    If frm_mdiViewer2.Visible AndAlso frm_mdiViewer.AutomatischEinfuegenToolStripMenuItem.Checked Then
      frm_mdiViewer2.addPicClient()

    End If

    grabWindowCancel()
  End Sub

  Public Sub SaveImage(ByVal path As String, ByVal img As Image)
    Dim ext = IO.Path.GetExtension(path).ToUpper
    If ext = ".PNG" Then
      img.Save(path, ImageFormat.Png)
      Return
    End If
    If ext = ".BMP" Then
      img.Save(path, ImageFormat.Bmp)
      Return
    End If
    If ext = ".GIF" Then
      img.Save(path, ImageFormat.Gif)
      Return
    End If
    If ext = ".JPG" Or ext = ".JPEG" Then
      SaveJpeg(path, img, glob.para("jpegQuality", "80"))
      Return
    End If
    Throw New InvalidExpressionException("Ungültiges Bild-Datei-Format, bitte PNG, GIF, JPG oder BMP verwenden!")
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
    Dim qualityParam As New EncoderParameter(Encoder.Quality, 0)

    '// EncoderParameters ep = new EncoderParameters();
    '//            ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)QualityPercentage);

    ' Jpeg image codec 
    Dim jpegCodec As ImageCodecInfo = GetEncoderInfo("image/jpeg")

    'Dim encoderParams As New EncoderParameters(1)
    Dim encoderParams As New EncoderParameters()

    'encoderParams.Param(0) = qualityParam
    Dim qual As Integer = 100
    encoderParams.Param(0) = New EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qual)
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

  'Function showNewForm() As frm_inner
  '  ' Neue Instanz des untergeordneten Formulars erstellen.
  '  Dim ChildForm As New frm_inner
  '  ' Vor der Anzeige dem MDI-Formular unterordnen.
  '  ChildForm.MdiParent = frm_main

  '  'ChildForm.PictureBox1.Image = pic
  '  'ChildForm.BackgroundImage = pic
  '  m_ChildFormNumber += 1
  '  'ChildForm.Text = "Fenster " & m_ChildFormNumber

  '  ChildForm.Show()
  '  Return ChildForm
  'End Function

  'Function showNewTextForm() As frm_innerText
  '  Dim ChildForm As New frm_innerText
  '  ChildForm.MdiParent = frm_main

  '  m_ChildFormNumber += 1

  '  ChildForm.Show()
  '  Return ChildForm
  'End Function
End Module
