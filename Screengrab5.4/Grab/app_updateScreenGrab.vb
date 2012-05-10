Module app_updateScreenGrab

  Public deltaX, deltaY As Integer

  Public partialImageSize As Size

  Sub loadImage(ByVal im As Image)
    frm.pic_viewPartial.Image = Nothing
    fullDesktopImage = im

    deltaX = 0 : deltaY = 0
    Dim resizeWindow = FRM.chk_blueScreenMode.Checked
    setImageSize(im.Width, im.Height, resizeWindow)

    'updatePartialView(frm)
  End Sub


  Function getCompleteImage() As Image
    Dim siz As Size = getDestSize()
    Dim res As New Bitmap(siz.Width, siz.Height)

    Dim g As Graphics = Graphics.FromImage(res)
    g.Clear(Color.Transparent)

    Dim bg_image As Image = frm.pic_viewPartial.BackgroundImage
    If bg_image Is Nothing Then Return Nothing
    g.DrawImage(bg_image, 0, 0)

    If frm.pic_viewPartial.Image IsNot Nothing Then
      g.DrawImage(frm.pic_viewPartial.Image, 0, 0)

    End If

    Return res
  End Function

  Sub onTimerEvent()
    ' GetAsyncKeyState(Keys.ShiftKey) 'puffer leeren
    ' GetAsyncKeyState(Keys.ControlKey) 'puffer leeren

    If isKeyPressed(Keys.ShiftKey) And isKeyPressed(Keys.ControlKey) Then
      If FRM.chk_blueScreenMode.Checked Then
        screenGrab()
        updateCursorPos()
        updatePartialView()
      End If
    End If

  End Sub

  Sub setImageSize(ByVal width As Integer, ByVal height As Integer, ByVal updateWindowSize As Boolean)
    If width < 1 Or height < 1 Then Return
    FRM.txtImageSizeWidth.Text = width.ToString
    FRM.txtImageSizeHeight.Text = height.ToString
    If updateWindowSize And FRM.chk_blueScreenMode.Checked Then
      FRM.Width = width + FRM.Width - FRM.pic_viewPartial.Width
      FRM.Height = height + FRM.Height - FRM.pic_viewPartial.Height
    End If
    If Not FRM.chk_blueScreenMode.Checked Then
      FRM.pic_viewPartial.Width = width * FRM.tbrZoom.Value / 100
      FRM.pic_viewPartial.Height = height * FRM.tbrZoom.Value / 100
    End If
    If glob.para("frm_options__chk_disp_size_in_tb", "FALSE") = "TRUE" Then
      FRM.Text = "[" & width & "x" & height & "] ScreenGrab " + My.Application.Info.Version.ToString(2)
    End If
    partialImageSize = New Size(width, height)
    ' updateImageSize(frm)
    updatePartialView()
  End Sub

  'Sub updateImageSize(ByVal frm As frm_blueScreen)

  '  updatePartialView(frm)
  'End Sub

  Sub updateCursorPos()
    Dim cursorPosX As Integer = System.Windows.Forms.Cursor.Position.X
    Dim cursorPosY As Integer = System.Windows.Forms.Cursor.Position.Y

    'frm.tsl_Debug1.Text = "X = " + cursorPosX.ToString + ", Y = " + cursorPosY.ToString

    deltaX = cursorPosX - grabsch.GetDesktopLeft()
    deltaY = cursorPosY - grabsch.GetDesktopTop()

  End Sub

  Sub screenGrab()
    fullDesktopImage = grabsch.ScreenCapture

  End Sub

  Function getDestRect() As Rectangle
    Try
      getDestRect.Width = FRM.txtImageSizeWidth.Text
      getDestRect.Height = FRM.txtImageSizeHeight.Text
      If Not FRM.chk_blueScreenMode.Checked Then
        getDestRect.Width *= FRM.tbrZoom.Value / 100
        getDestRect.Height *= FRM.tbrZoom.Value / 100
      End If

      getDestRect.X = deltaX
      getDestRect.Y = deltaY

    Catch ex As Exception
      getDestRect = New Rectangle(New Point(0, 0), FRM.pic_viewPartial.Size)
    End Try
  End Function

  Function getDestSize() As Size
    Try
      getDestSize.Width = frm.txtImageSizeWidth.Text
      getDestSize.Height = FRM.txtImageSizeHeight.Text
      If Not FRM.chk_blueScreenMode.Checked Then
        getDestSize.Width *= FRM.tbrZoom.Value / 100
        getDestSize.Height *= FRM.tbrZoom.Value / 100

      End If
    Catch ex As Exception
      getDestSize = frm.pic_viewPartial.Size
    End Try
  End Function

  Sub updatePartialView()
    With frm
      Dim destSize = getDestSize()

      If fullDesktopImage Is Nothing Then Exit Sub
      If .pic_viewPartial.Width = 0 Or .pic_viewPartial.Height = 0 Then Exit Sub
      Dim bmp As New Bitmap(destSize.Width, destSize.Height)

      Dim g As Graphics = Graphics.FromImage(bmp)

      g.Clear(Color.Transparent)


      Dim intSourceWidth, intSourceHeight, intZoom As Single
      intZoom = frm.tbrZoom.Value
      'frm.tsl_Debug1.Text = "zoom: " + intZoom.ToString
      intSourceWidth = destSize.Width / intZoom * 100
      intSourceHeight = destSize.Height / intZoom * 100

      Dim srcRect As New Rectangle(deltaX, deltaY, intSourceWidth, intSourceHeight)
      Dim destRect As New Rectangle(0, 0, destSize.Width, destSize.Height)


      g.DrawImage(fullDesktopImage, destRect, srcRect, GraphicsUnit.Pixel)

      .pic_viewPartial.SuspendLayout()
      .pic_viewPartial.BackgroundImage = bmp

      .pic_viewPartial.ResumeLayout()


    End With
  End Sub



End Module
