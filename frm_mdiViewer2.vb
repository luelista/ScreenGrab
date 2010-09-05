Imports ScreenGrab5.Vector
Public Class frm_mdiViewer2

  Public canvas As Vector.Canvas
  Public WithEvents multitouch As TouchHelper


  Dim paletteWindows As New List(Of Form)
  Sub addPaletteWindow(ByVal frm As Form)
    paletteWindows.Add(frm)
    repositionPaletteWindows()
  End Sub
  Sub repositionPaletteWindows()
    Dim left, top As Integer

    left = Me.Left + Me.Width + 10
    Dim s = Screen.FromControl(Me)
    'If left > s.Bounds.Right - 175 Then left -= 185

    top = Me.Top
    For i = 0 To paletteWindows.Count - 1
      With paletteWindows(i)
        If .Visible = False Then Continue For
        .Left = left
        .Top = top
        top += .Height
        If top > Me.Top + Me.Height Then top = Me.Top : left += 185
      End With

    Next
  End Sub
  Sub hidePaletteWindows()
    For i = 0 To paletteWindows.Count - 1
      With paletteWindows(i)
        .Hide()
      End With
    Next
  End Sub

  Sub activateToolWindows()
    For i = 0 To paletteWindows.Count - 1
      With paletteWindows(i).Visible
        putWinAfter(paletteWindows(i).Handle, Me.Handle)
      End With
    Next
  End Sub

  Private Sub frm_mdiViewer2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    ' Panel1.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption)
    ' Label4.ForeColor = Color.FromKnownColor(KnownColor.ActiveCaptionText)
    activateToolWindows()
  End Sub

  Private Sub frm_mdiViewer2_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
    ' Panel1.BackColor = Color.FromKnownColor(KnownColor.InactiveCaption)
    ' Label4.ForeColor = Color.FromKnownColor(KnownColor.InactiveCaptionText)
  End Sub

  Private Sub frm_mdiViewer2_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
    If e.Data.GetDataPresent("FileDrop") Then
      Dim pos As Point = PictureBox1.PointToClient(New Point(e.X, e.Y))

      Dim files() As String = e.Data.GetData("FileDrop")
      For Each fileSpec In files
        Dim ext As String = IO.Path.GetExtension(fileSpec).ToUpper
        Select Case ext
          Case ".JPG", ".BMP", ".PNG", ".GIF", ".TIF", ".WMF"
            Dim obj As New VImage
            obj.name = "img_" + IO.Path.GetFileName(fileSpec) + "_" + Now.Ticks.ToString
            obj.img = Image.FromFile(fileSpec)
            obj.source = "FILE:" + fileSpec
            obj.bounds = New Rectangle(pos.X, pos.Y, obj.img.Width, obj.img.Height)
            obj.setBorder(2, Color.RoyalBlue)
            canvas.objects.Add(obj)

          Case ".ICO"
            Dim obj As New VImage
            Dim ico As New Icon(fileSpec)
            obj.name = "icon_" + IO.Path.GetFileName(fileSpec) + "_" + Now.Ticks.ToString
            obj.img = ico.ToBitmap
            ico.Dispose()
            obj.source = "FILE:" + fileSpec
            obj.bounds = New Rectangle(pos.X, pos.Y, obj.img.Width, obj.img.Height)
            'obj.setBorder(2, Color.RoyalBlue)
            canvas.objects.Add(obj)

          Case ".CUR"
            Dim obj As New VImage
            Dim bmp As New Bitmap(32, 32)
            obj.name = "cursor_" + IO.Path.GetFileName(fileSpec) + "_" + Now.Ticks.ToString
            Dim g = Graphics.FromImage(bmp)
            Try
              Dim c As New Cursor(fileSpec)
              c.DrawStretched(g, New Rectangle(0, 0, 32, 32))
              c.Dispose()
            Catch ex As Exception
              g.DrawString(ex.Message, New Font("Arial", 6, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, New Rectangle(0, 0, 32, 32))
            End Try
            g.Dispose()
            obj.img = bmp
            obj.source = "FILE:" + fileSpec
            obj.bounds = New Rectangle(pos.X, pos.Y, obj.img.Width, obj.img.Height)
            'obj.setBorder(2, Color.RoyalBlue)
            canvas.objects.Add(obj)

        End Select
      Next

      PictureBox1.Refresh()
    End If
  End Sub


  Function addPicClient(ByVal img As Image, ByVal src As String) As VImage
    Dim obj As New VImage
    obj.name = "screenshot_" & Now.Ticks
    obj.img = img
    obj.source = src
    obj.bounds = New Rectangle(20, 20, obj.img.Width, obj.img.Height)
    obj.setBorder(2, Color.RoyalBlue)
    canvas.objects.Add(obj)
    PictureBox1.Refresh()
    Return obj
  End Function

  Sub addPicClient()
    Dim img = getCompleteImage()
    If img Is Nothing Then Exit Sub
    addPicClient(img, "GRAB:" + getDestRect.ToString)
  End Sub

  Private Sub frm_mdiViewer2_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
    If e.Data.GetDataPresent("FileDrop") Then
      e.Effect = DragDropEffects.Copy
    End If
  End Sub

  Private Sub frm_mdiViewer2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    hidePaletteWindows()
  End Sub


  Private Sub frm_mdiViewer2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    multitouch = TouchHelper.RegisterForTouch(Me.PictureBox1)
    If multitouch IsNot Nothing Then
      CheckBox1.Visible = True
      CheckBox1.Enabled = True
    End If

    addPaletteWindow(frm_paletteProperties)
    addPaletteWindow(frm_paletteFile)
    addPaletteWindow(frm_paletteCursor)

    makeFormGlassReady(Me, Panel1, DockStyle.Top)

    canvas = New Vector.Canvas
    Dim obj As VObject
    canvas.PicBox = PictureBox1
    '  canvas.KeyHandlerControl = Me

    'obj = New VImage()
    'obj.name = "test_image"
    'obj.bounds = New Rectangle(20, 20, 300, 200)
    'obj.setBorder(8, Color.Green)
    'DirectCast(obj, VImage).img = grabsch.ScreenCapture
    'canvas.objects.Add(obj)

    'obj = New VElipse()
    'obj.name = "test_elipse"
    'obj.bounds = New Rectangle(100, 100, 50, 80)
    'obj.setBorder(4, Color.Red)
    'canvas.objects.Add(obj)

  End Sub

  Private Sub Panel1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseDown, Label4.MouseDown, Panel1.MouseDown
    FormMoveTricky(Me.Handle)
  End Sub


  Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

  End Sub

  Private Sub frm_mdiViewer2_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
    repositionPaletteWindows()
  End Sub

  Private Sub frm_mdiViewer2_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
    If Me.WindowState = FormWindowState.Maximized Then
      Label2.Text = "2"
    Else
      Label2.Text = "1"
    End If
    repositionPaletteWindows()
  End Sub

  Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
    If Me.WindowState = FormWindowState.Maximized Then
      Me.WindowState = FormWindowState.Normal
    Else
      Me.WindowState = FormWindowState.Maximized
    End If
  End Sub

  Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
    Me.Close()
  End Sub

  Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
    Me.WindowState = FormWindowState.Minimized
  End Sub



  Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
    Dim obj As New VTextbox
    obj.name = "textbox_" & Now.Ticks
    obj.fnt = Me.Font
    obj.text = "Textbox 123"
    obj.bounds = New Rectangle(20, 20, 200, 100)
    obj.setBorder(2, Color.RoyalBlue)
    obj.brsh = Brushes.Black
    canvas.addObject(obj)
  End Sub

  Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
    Dim obj As New VElipse
    obj.name = "elipse_" & Now.Ticks
    obj.bounds = New Rectangle(20, 20, 200, 100)
    obj.setBorder(5, Color.SandyBrown)
    canvas.addObject(obj)
  End Sub

  Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    frm_paletteCursor.Show()
    frm_paletteCursor.Activate()
  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ' canvas.readHtmlPage()
  End Sub


  Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ' canvas.createHtmlPage()
  End Sub

  Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
    frm_paletteFile.Show()
    frm_paletteFile.Activate()
    repositionPaletteWindows()

  End Sub

  Dim touchDownPoints(10) As Point
  Dim touchLastPoints(10) As Point
  Dim myObject As VObject

  Private Sub multitouch_Touchdown(ByVal sender As Object, ByVal e As TouchHelper.WMTouchEventArgs) Handles multitouch.Touchdown
    PrintMultitouchDebug("DOWN", e)
    If canvas.IsMultitouchMode = False Then Exit Sub

    Dim obj = canvas.GetObjectAt(New Point(e.LocationX, e.LocationY))
    If obj IsNot Nothing Then
      myObject = obj
      myObject.moveOrigRect = myObject.bounds
    End If

    touchDownPoints(e.Id) = New Point(e.LocationX, e.LocationY)
    touchLastPoints(e.Id) = New Point(e.LocationX, e.LocationY)



  End Sub

  Private Sub multitouch_Touchmove(ByVal sender As Object, ByVal e As TouchHelper.WMTouchEventArgs) Handles multitouch.Touchmove
    PrintMultitouchDebug("MOVE", e)
    If canvas.IsMultitouchMode = False Then Exit Sub
    If myObject Is Nothing Then Exit Sub

    touchLastPoints(e.Id) = New Point(e.LocationX, e.LocationY)

    Dim firstID As Integer = -1
    For i = 0 To touchDownPoints.Length - 1
      If touchDownPoints(i) = Nothing Then Continue For

      If firstID = -1 Then firstID = i : Continue For

      'If firstID <> -1 Then

      Dim dp1 = touchDownPoints(firstID)
      Dim dp2 = touchDownPoints(i)
      Dim lp1 = touchLastPoints(firstID)
      Dim lp2 = touchLastPoints(i)

      Dim distDP = Distance(dp1, dp2)
      Dim distLP = Distance(lp1, lp2)

      Dim distFactor = distLP / distDP

      Dim rct = myObject.moveOrigRect

      rct.Height *= distFactor
      rct.Width *= distFactor
      rct.X -= (rct.Width - myObject.moveOrigRect.Width) / 2
      rct.Y -= (rct.Height - myObject.moveOrigRect.Height) / 2
      myObject.bounds = rct
      PictureBox1.Refresh()


      'If myObject.moveTempRect <> Nothing Then
      '  ControlPaint.DrawReversibleFrame(PictureBox1.RectangleToScreen(myObject.moveTempRect), Color.White, FrameStyle.Dashed)
      'End If
      'myObject.moveTempRect = myObject.bounds
      'myObject.moveTempRect.Height *= distFactor
      'myObject.moveTempRect.Width *= distFactor
      'myObject.moveTempRect.X -= (myObject.moveTempRect.Width - myObject.Width) / 2
      'myObject.moveTempRect.Y -= (myObject.moveTempRect.Height - myObject.Height) / 2

      frm_paletteProperties.TextBox1.Text = dp1.ToString + vbNewLine + dp2.ToString + vbNewLine + lp1.ToString + vbNewLine + lp2.ToString + vbNewLine + vbNewLine + distDP.ToString + vbNewLine + distLP.ToString + vbNewLine + vbNewLine + distFactor.ToString

      '      ControlPaint.DrawReversibleFrame(PictureBox1.RectangleToScreen(myObject.moveTempRect), Color.White, FrameStyle.Dashed)

      Exit Sub
    Next

    If firstID > -1 Then
      Dim dp1 = touchDownPoints(firstID)
      Dim lp1 = touchLastPoints(firstID)

      Dim deltaX = dp1.X - lp1.X
      Dim deltaY = dp1.Y - lp1.Y

      Dim rct = myObject.moveOrigRect

      rct.X -= deltaX
      rct.Y -= deltaY

      myObject.bounds = rct
      PictureBox1.Refresh()



    End If

  End Sub

  Private Sub multitouch_Touchup(ByVal sender As Object, ByVal e As TouchHelper.WMTouchEventArgs) Handles multitouch.Touchup
    PrintMultitouchDebug("UP", e)
    If canvas.IsMultitouchMode = False Then Exit Sub
    'If myObject Is Nothing Then Exit Sub


    touchDownPoints(e.Id) = Nothing
    touchLastPoints(e.Id) = Nothing

    If myObject IsNot Nothing Then
      myObject.moveOrigRect = myObject.bounds
    End If
  End Sub

  Function Distance(ByVal p1 As Point, ByVal p2 As Point) As Integer
    Return Math.Sqrt((p1.X - p2.X) ^ 2 + (p1.Y - p2.Y) ^ 2)
  End Function

  Sub PrintMultitouchDebug(ByVal eventName As String, ByVal e As TouchHelper.WMTouchEventArgs)
    Dim graph As Graphics = PictureBox1.CreateGraphics

    Dim c1 As New Pen(ColorTranslator.FromOle(QBColor(e.Id)), 10)
    graph.DrawEllipse(c1, e.LocationX - 4, e.LocationY - 4, 8, 8)
    c1.Dispose()

    Dim flags As String
    If (e.Flags And TouchHelper.TOUCHEVENTF_MOVE) <> 0 Then flags += "MOVE "
    If (e.Flags And TouchHelper.TOUCHEVENTF_DOWN) <> 0 Then flags += "DOWN "
    If (e.Flags And TouchHelper.TOUCHEVENTF_UP) <> 0 Then flags += "UP "
    If (e.Flags And TouchHelper.TOUCHEVENTF_INRANGE) <> 0 Then flags += "INRANGE "
    If (e.Flags And TouchHelper.TOUCHEVENTF_PRIMARY) <> 0 Then flags += "PRIMARY "
    If (e.Flags And TouchHelper.TOUCHEVENTF_NOCOALESCE) <> 0 Then flags += "NOCOALESCE "
    If (e.Flags And TouchHelper.TOUCHEVENTF_PEN) <> 0 Then flags += "PEN "
    flags += ";"


    Dim info = "Location: " & e.LocationX & "x" & e.LocationY & vbNewLine & "Event: " & eventName & vbNewLine & "ID: " & e.Id & vbNewLine & "Flags: 0x" & Hex(e.Flags) & "  " & flags & vbNewLine & "Primary: " & e.IsPrimaryContact & vbNewLine & "Mask: " & e.Mask & vbNewLine & "Time: " & e.Time
    Dim size = graph.MeasureString(info, Me.Font)
    Dim rct As New Rectangle(e.LocationX + 20, e.LocationY + 20, size.Width, size.Height)
    Dim brshInfobox As New Drawing2D.LinearGradientBrush(rct, Color.AntiqueWhite, Color.LightYellow, Drawing2D.LinearGradientMode.BackwardDiagonal)
    graph.FillRectangle(brshInfobox, rct)
    brshInfobox.Dispose()
    graph.DrawString(info, Me.Font, Brushes.Black, e.LocationX + 20, e.LocationY + 20)

    'frm_paletteProperties.TextBox1.Text = info

    graph.Dispose()
  End Sub
  Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
    canvas.IsMultitouchMode = CheckBox1.Checked
  End Sub

  Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

  End Sub
End Class