Imports ScreenGrab6.Vector
Public Class frm_mdiViewer2

  Public Const COLOR_PALETTE_ITEM_SIZE = 18
  Public Const COLOR_PALETTE_ROWS = 8
  Public Const COLOR_PALETTE_COLS = 3

  Public colorPalette(COLOR_PALETTE_ROWS * COLOR_PALETTE_COLS) As Color
  Public toolboxPermanent As Boolean
  Public toolboxLastclick As Long




  'TitleBar verstecken

  Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
    Get
      Dim cp As CreateParams = MyBase.CreateParams
      Const WS_CAPTION As Int32 = &HC00000
      cp.Style = cp.Style And Not WS_CAPTION
      Return cp
    End Get
  End Property

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
    'frm_paletteColor.TopMost = True
    putWinAfter(frm_paletteColor.Handle, New IntPtr(-1))
  End Sub

  Private Sub frm_mdiViewer2_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
    ' Panel1.BackColor = Color.FromKnownColor(KnownColor.InactiveCaption)
    ' Label4.ForeColor = Color.FromKnownColor(KnownColor.InactiveCaptionText)
    putWinAfter(frm_paletteColor.Handle, New IntPtr(-2))
  End Sub

  Private Sub frm_mdiViewer2_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
    If e.Data.GetDataPresent("FileDrop") Then
      Dim pos As Point = vcc.PictureBox1.PointToClient(New Point(e.X, e.Y))

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
            'obj.setBorder(2, Color.RoyalBlue)
            vcc.canvas.addObject(obj)

          Case ".ICO"
            Dim obj As New VImage
            Dim ico As New Icon(fileSpec)
            obj.name = "icon_" + IO.Path.GetFileName(fileSpec) + "_" + Now.Ticks.ToString
            obj.img = ico.ToBitmap
            ico.Dispose()
            obj.source = "FILE:" + fileSpec
            obj.bounds = New Rectangle(pos.X, pos.Y, obj.img.Width, obj.img.Height)
            'obj.setBorder(2, Color.RoyalBlue)
            vcc.canvas.addObject(obj)

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
            vcc.canvas.addObject(obj)

        End Select
      Next

      vcc.PictureBox1.Refresh()
    End If
  End Sub



  Sub addPicClient()
    Dim img = getCompleteImage()
    If img Is Nothing Then Exit Sub
    vcc.canvas.addPicClient(img, "GRAB:" + getDestRect.ToString)
  End Sub

  Private Sub frm_mdiViewer2_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
    If e.Data.GetDataPresent("FileDrop") Then
      e.Effect = DragDropEffects.Copy
    End If
  End Sub

  Private Sub frm_mdiViewer2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    If vcc.CheckFileDirty() = False Then e.Cancel = True : Exit Sub

    hidePaletteWindows()

    glob.para("frm_mdiViewer2__colorDefaultFg") = ColorTranslator.ToHtml(vcc.defaultFg)
    glob.para("frm_mdiViewer2__colorDefaultBg") = ColorTranslator.ToHtml(vcc.defaultBg)
    glob.para("frm_mdiViewer2__lineDefaultWidth") = nudLineWidth.Value
    glob.para("frm_mdiViewer2__arrowDefaultLength") = nudArrowLength.Value
    glob.para("frm_mdiViewer2__lineDefaultStyle") = cmbLineStyle.SelectedIndex
    glob.para("frm_mdiViewer2__textDefaultText") = txtTextDefault.Text
    glob.para("frm_mdiViewer2__textDefaultFontSize") = defaultFont.SizeInPoints
    glob.para("frm_mdiViewer2__textDefaultFontFamily") = defaultFont.Name
    glob.para("frm_mdiViewer2__textDefaultFontStyle") = defaultFont.Style

    FRM.qq_chkAutoCollage.Enabled = False
    FRM.qq_chkAutoCollage.Checked = False
  End Sub

  Private Sub frm_mdiViewer2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    vcc.KeyboardHandler(e)
    If e.Control And e.KeyCode = Keys.S Then
      vcc.saveFile(e.Shift)
    End If
    If e.Control And e.KeyCode = Keys.O Then
      vcc.openFile()
    End If
    If e.Control And e.KeyCode = Keys.G Then
      CodeGenerierenToolStripMenuItem_Click(Nothing, EventArgs.Empty)
    End If
    If e.Control And e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9 Then
      Dim id As Integer = e.KeyCode - Keys.D0
      toolboxButton_Click(pnlToolbox.Controls("btn_tb_" & id), EventArgs.Empty)
    End If
  End Sub
  Private Sub frm_mdiViewer2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    If vcc.multitouch IsNot Nothing Then
      CheckBox1.Visible = True
      CheckBox1.Enabled = True
    End If

    ' addPaletteWindow(frm_paletteProperties)
    addPaletteWindow(frm_paletteFile)
    addPaletteWindow(frm_paletteCursor)

    makeFormGlassReady(Me, Panel1, DockStyle.Top)

    frm_paletteFile.MyCanvas = vcc.canvas

    For i = 0 To COLOR_PALETTE_ROWS * COLOR_PALETTE_COLS - 1
      colorPalette(i) = ColorTranslator.FromHtml(glob.para("frm_mdiViewer2__colorPalette_" & i, "#" + Hex(i + 4) + Hex(i + 4) + Hex(i + 4)))
    Next
    vcc.defaultFg = ColorTranslator.FromHtml(glob.para("frm_mdiViewer2__colorDefaultFg", "#000"))
    vcc.defaultBg = ColorTranslator.FromHtml(glob.para("frm_mdiViewer2__colorDefaultBg", "#fff"))
    nudLineWidth.Value = glob.para("frm_mdiViewer2__lineDefaultWidth", "1")
    nudArrowLength.Value = glob.para("frm_mdiViewer2__arrowDefaultLength", "10")
    cmbLineStyle.SelectedIndex = glob.para("frm_mdiViewer2__lineDefaultStyle", "0")
    txtTextDefault.Text = glob.para("frm_mdiViewer2__textDefaultText", "(Neu Textfeld)")
    vcc.defaultFont = New Font(glob.para("frm_mdiViewer2__textDefaultFontFamily", "Arial"), glob.para("frm_mdiViewer2__textDefaultFontSize", "10"), _
         glob.para("frm_mdiViewer2__textDefaultFontStyle", 0), GraphicsUnit.Point)

    Dim ImHauptfensterLadenToolStripMenuItem As New ToolStripMenuItem("Im Hauptfenster laden")
    AddHandler ImHauptfensterLadenToolStripMenuItem.Click, AddressOf ImHauptfensterLadenToolStripMenuItem_Click
    vcc.cmsCanvas.Items.Insert(5, ImHauptfensterLadenToolStripMenuItem)

    '  vcc.canvas.KeyHandlerControl = Me

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

  Private Sub Panel1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) _
  Handles PictureBox2.MouseDown, Panel1.MouseDown
    FormMoveTricky(Me.Handle)
    If e.Button = Windows.Forms.MouseButtons.Right Then
      frm_paletteCursor.Show()

    End If
  End Sub

  Private Sub ZusatzfensterAnzeigenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZusatzfensterAnzeigenToolStripMenuItem.Click
    showProperties(vcc.canvas.GetFirstSelectedObject, True)
  End Sub

  Sub showProperties(ByVal obj As VObject, Optional ByVal force As Boolean = False)
    If force = True Then
      frm_paletteFile.Show()
      frm_paletteFile.Activate()
    ElseIf force = False And frm_paletteFile.Visible = False Then
      Exit Sub
    End If
    ' frm_paletteFile.MyCanvas = Me
    frm_paletteFile.RefreshItemList()
    frm_paletteFile.SelectedObject = obj
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

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ' vcc.canvas.readHtmlPage()
  End Sub


  Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ' vcc.canvas.createHtmlPage()
  End Sub

  Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    frm_paletteFile.Show()
    frm_paletteFile.Activate()
    repositionPaletteWindows()
    frm_paletteFile.TabControl1.SelectedIndex = 1

  End Sub

  Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
    vcc.canvas.IsMultitouchMode = CheckBox1.Checked
  End Sub


  Private Sub ImHauptfensterLadenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Dim img As VImage = vcc.canvas.GetFirstSelectedObject()
    loadImage(img.img)
  End Sub


  Private Sub pbColorPalette_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbColorPalette.MouseClick
    If e.X >= COLOR_PALETTE_ITEM_SIZE * COLOR_PALETTE_COLS OrElse (e.X Mod COLOR_PALETTE_ITEM_SIZE) > COLOR_PALETTE_ITEM_SIZE - COLOR_PALETTE_ROWS OrElse _
       e.Y >= COLOR_PALETTE_ITEM_SIZE * COLOR_PALETTE_ROWS OrElse (e.Y Mod COLOR_PALETTE_ITEM_SIZE) > COLOR_PALETTE_ITEM_SIZE - COLOR_PALETTE_ROWS _
       Then Return

    Dim clickedIndex As Integer = (e.Y \ COLOR_PALETTE_ITEM_SIZE) * COLOR_PALETTE_COLS + e.X \ COLOR_PALETTE_ITEM_SIZE
    Dim clickedColor As Color = colorPalette(clickedIndex)

    If e.Button = Windows.Forms.MouseButtons.Middle Or isKeyPressed(Keys.ControlKey) Then
      Using cd As New ColorDialog
        cd.Color = clickedColor
        cd.FullOpen = True
        If cd.ShowDialog = Windows.Forms.DialogResult.OK Then
          colorPalette(clickedIndex) = cd.Color
          glob.para("frm_mdiViewer2__colorPalette_" & clickedIndex) = ColorTranslator.ToHtml(cd.Color)
          pbColorPalette.Invalidate()
        End If
      End Using
      Exit Sub
    End If

    If e.Button = Windows.Forms.MouseButtons.Right Then
      If Not showColorPalettteIfNotVisible() Then
        colorPalette(clickedIndex) = frm_paletteColor.GColorPicker1.Value
        pbColorPalette.Invalidate()
      End If
      Exit Sub
    End If

    setCurrentDefaultColor(clickedColor)

  End Sub

  Private Sub PictureBox3_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pbColorPalette.Paint
    For i = 0 To COLOR_PALETTE_ROWS - 1
      For j = 0 To COLOR_PALETTE_COLS - 1
        DrawColorRect(e.Graphics, New SolidBrush(colorPalette(i * COLOR_PALETTE_COLS + j)), j * COLOR_PALETTE_ITEM_SIZE, i * COLOR_PALETTE_ITEM_SIZE, COLOR_PALETTE_ITEM_SIZE - 4, COLOR_PALETTE_ITEM_SIZE - 4)
      Next
    Next
  End Sub

  Sub DrawColorRect(ByVal g As Graphics, ByVal b As Brush, ByVal x As Integer, ByVal y As Integer, ByVal xx As Integer, ByVal yy As Integer)
    g.DrawRectangle(Pens.Black, x, y, xx - 1, yy - 1)
    g.DrawRectangle(Pens.White, x + 1, y + 1, xx - 2, yy - 2)
    g.FillRectangle(b, x + 2, y + 2, xx - 3, yy - 3)
  End Sub

  Private Sub toolboxButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_tb_6.Click, btn_tb_5.Click, btn_tb_3.Click, btn_tb_4.Click, btn_tb_2.Click, btn_tb_1.Click, btn_tb_7.Click, btn_tb_9.Click, btn_tb_0.Click
    Dim elID As Integer = sender.tag
    If elID = vcc.toolboxSelElement And (New TimeSpan(Now.Ticks - toolboxLastclick).TotalMilliseconds < 700) Then
      toolboxPermanent = True
      refreshToolboxButtonColors()
      Exit Sub
    End If
    toolboxLastclick = Now.Ticks
    vcc.toolboxSelElement = elID
    toolboxPermanent = False
    refreshToolboxButtonColors()
  End Sub

  Sub resetToolboxIfTemporary()
    If Not toolboxPermanent Then
      vcc.toolboxSelElement = 1
      refreshToolboxButtonColors()
    End If
  End Sub

  Sub refreshToolboxButtonColors()
    If vcc.toolboxSelElement = 1 Then toolboxPermanent = True
    For Each item As Control In pnlToolbox.Controls
      item.BackColor = If(item.Tag = vcc.toolboxSelElement, If(toolboxPermanent, Color.Black, Color.Yellow), Color.Transparent)
      DirectCast(item, Button).UseVisualStyleBackColor = item.Tag <> vcc.toolboxSelElement
    Next

    vcc.canvas.IsInsertionMode = (vcc.toolboxSelElement <> VCanvasControl.toolboxElement.Cursor)
    vcc.canvas.IsLineDrawingMode = (vcc.toolboxSelElement = VCanvasControl.toolboxElement.Line) Or _
       (vcc.toolboxSelElement = VCanvasControl.toolboxElement.Arrow)

    grpLine.Visible = vcc.toolboxSelElement = VCanvasControl.toolboxElement.Ellipse Or _
      vcc.toolboxSelElement = VCanvasControl.toolboxElement.Line Or _
      vcc.toolboxSelElement = VCanvasControl.toolboxElement.Arrow Or vcc.toolboxSelElement = VCanvasControl.toolboxElement.Rectangle Or _
      (vcc.toolboxSelElement = VCanvasControl.toolboxElement.UmlClass)
    grpText.Visible = vcc.toolboxSelElement = VCanvasControl.toolboxElement.Textbox
    grpArrow.Visible = vcc.toolboxSelElement = VCanvasControl.toolboxElement.Arrow

    If vcc.toolboxSelElement <> VCanvasControl.toolboxElement.Arrow And vcc.defaultColorSelected = -1 Then _
      vcc.defaultColorSelected = 1 : refreshDefaultColorBoxes()
  End Sub

  Sub refreshItemList()
    'cmbElementNames.Items.Clear()
    'For Each v In vcc.canvas.objects
    '  cmbElementNames.Items.Add(v.name)
    '  If v.isSelected Then cmbElementNames.SelectedIndex = cmbElementNames.Items.Count - 1
    'Next
    If vcc.canvas.SelectionCount <> 1 Then cmbElementNames.SelectedIndex = -1
  End Sub

  Function showColorPalettteIfNotVisible() As Boolean
    If frm_paletteColor.Visible = False Then
      frm_paletteColor.Show()
      'addPaletteWindow(frm_paletteColor)
      frm_paletteColor.Top = Me.Top + 200
      frm_paletteColor.Left = Me.Left + Me.Width - frm_paletteColor.Width - 80
      Return True
    End If
    Return False
  End Function

  Private Sub pbDefaultBg_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbDefaultBg.MouseClick
    'canvas.DeselectAll()
    vcc.defaultColorSelected = 2
    refreshDefaultColorBoxes()
    If e.Button = Windows.Forms.MouseButtons.Right Then
      If Not showColorPalettteIfNotVisible() Then
        setCurrentDefaultColor(frm_paletteColor.GColorPicker1.Value)
      End If
    End If
  End Sub
  Private Sub pbDefaultFg_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbDefaultFg.MouseClick
    'canvas.DeselectAll()
    vcc.defaultColorSelected = 1
    refreshDefaultColorBoxes()
    If e.Button = Windows.Forms.MouseButtons.Right Then
      If Not showColorPalettteIfNotVisible() Then
        setCurrentDefaultColor(frm_paletteColor.GColorPicker1.Value)
      End If
    End If
  End Sub

  Private Sub pbDefaultBg_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pbDefaultBg.Paint
    DrawColorRect(e.Graphics, New SolidBrush(vcc.defaultBg), 0, 0, pbDefaultBg.Width, pbDefaultBg.Height)
    If vcc.defaultColorSelected = 2 Then e.Graphics.DrawRectangle(Pens.Red, 0, 0, pbDefaultBg.Width - 1, pbDefaultBg.Height - 1)
  End Sub
  Private Sub pbDefaultFg_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pbDefaultFg.Paint
    DrawColorRect(e.Graphics, New SolidBrush(vcc.defaultFg), 0, 0, pbDefaultFg.Width, pbDefaultFg.Height)
    If vcc.defaultColorSelected = 1 Then e.Graphics.DrawRectangle(Pens.Red, 0, 0, pbDefaultFg.Width - 1, pbDefaultFg.Height - 1)
  End Sub

  Sub refreshDefaultColorBoxes()
    Static isRefreshing As Boolean = False '  StackOverflow verhindern
    If isRefreshing Then Exit Sub
    isRefreshing = True
    pbDefaultBg.Invalidate()
    pbDefaultFg.Invalidate()
    If vcc.defaultColorSelected = -1 Then
      frm_paletteColor.GColorPicker1.Enabled = False
    Else
      frm_paletteColor.GColorPicker1.Enabled = True
      '...dies würde zu einem StackOverflow führen, da ColorChanging wieder einen refresh auslöst:
      frm_paletteColor.GColorPicker1.Value = If(vcc.defaultColorSelected = 1, vcc.defaultFg, vcc.defaultBg)
    End If
    isRefreshing = False
  End Sub

  Sub setDefaultColor(ByVal id As Integer, ByVal newColor As Color)
    If getDefaultColor(id) = newColor Then Return
    Select Case id
      Case 1 : vcc.defaultFg = newColor
      Case 2 : vcc.defaultBg = newColor
    End Select
    refreshDefaultColorBoxes()
  End Sub

  Sub setCurrentDefaultColor(ByVal newColor As Color)
    If getDefaultColor(vcc.defaultColorSelected) = newColor Then Return
    setDefaultColor(vcc.defaultColorSelected, newColor)

    For i = 0 To vcc.canvas.selectedObjects.Count - 1
      Dim obj = vcc.canvas.selectedObjects(i)
      If vcc.defaultColorSelected = 1 Then
        obj.Color1 = newColor
      ElseIf vcc.defaultColorSelected = 2 Then
        obj.Color2 = newColor
      End If
    Next
    vcc.canvas.Invalidate()
  End Sub

  Function getDefaultColor(ByVal id As Integer) As Color
    Select Case id
      Case 1 : Return vcc.defaultFg
      Case 2 : Return vcc.defaultBg
    End Select
  End Function

  Private Sub vcc_ElementInserted() Handles vcc.ElementInserted
    resetToolboxIfTemporary()
  End Sub

  Private Sub vcc_SelectionChanged(ByVal names() As String) Handles vcc.SelectionChanged
    If frm_paletteFile.Visible And vcc.canvas.SelectionCount = 1 Then
      frm_paletteFile.SelectedObject = vcc.canvas.selectedObjects(0)
    End If
    If frm_paletteFile.Visible And vcc.canvas.SelectionCount <> 1 Then
      frm_paletteFile.SelectedObject = Nothing
    End If
    'defaultColorSelected = -1
    'refreshDefaultColorBoxes()

    refreshDefaultColorBoxes()
    cmbElementNames.Text = Join(names, ", ")
    ' cmbElementNames.SelectedIndex = If(canvas.SelectionCount = 1, cmbElementNames.Items.IndexOf(canvas.selectedObjects(0).name), -1)
  End Sub

  Private Sub btnDefaultFontChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDefaultFontChange.Click
    Using fd As New FontDialog
      fd.Font = defaultFont
      fd.FontMustExist = True

      If fd.ShowDialog = Windows.Forms.DialogResult.OK Then
        vcc.defaultFont = fd.Font
      End If
    End Using
  End Sub

  Private Sub RadioButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_tb_8.Click
    openGrabWindow()
  End Sub

  Private Sub btnFileMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFileMenu.Click
    cmsFileMenu.Show(btnFileMenu, 0, btnFileMenu.Height)
  End Sub

  Private Sub SchliessenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SchliessenToolStripMenuItem.Click
    Me.Close()
  End Sub

#Region "Datei-Menü"


  Private Sub NeuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NeuToolStripMenuItem.Click
    If vcc.CheckFileDirty() Then
      vcc.canvas.clearCanvas()
      vcc.FileSpec = ""
      vcc.Dirty = False
    End If
  End Sub

  Private Sub OeffnenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OeffnenToolStripMenuItem.Click
    vcc.openFile()
  End Sub


  Private Sub SpeichernToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpeichernToolStripMenuItem.Click
    vcc.saveFile(False)
  End Sub

  Private Sub SpeichernUnterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpeichernUnterToolStripMenuItem.Click
    vcc.saveFile(True)
  End Sub

  Private Sub CodeGenerierenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CodeGenerierenToolStripMenuItem.Click
    If String.IsNullOrEmpty(vcc.FileSpec) Then
      MsgBox("Die Collage muss vorher abgespeichert werden.", MsgBoxStyle.Information)
      Exit Sub
    End If

    Try
      Process.Start("VUMLCodeGeneration.exe", vcc.FileSpec)
    Catch ex As Exception
      MsgBox("Fehler beim Aufruf des Code-Generators: " + vbNewLine + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Sub

  Private Sub ExportierenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportierenToolStripMenuItem.Click
    MsgBox("Dies ist eine experimentelle Funktion, die evtl. zum Absturz des Programms führen kann. Es wird empfohlen, die Collage vorher zu speichern. Das resultierende PDF-Dokument kann Fehler enthalten. (schlechte Bildqualität, falsche Darstellung von Pfeilen)", MsgBoxStyle.Information, "Du befindest dich im Labor...")
    Using sfd As New SaveFileDialog
      sfd.Title = "Als PDF exportieren ..."
      sfd.Filter = "PDF-Dokument (*.pdf)|*.pdf"
      sfd.AddExtension = True
      If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
        Dim l As New Label : Me.Controls.Add(l) : l.Dock = DockStyle.Fill : l.Text = "Bitte warten, PDF wird erstellt..." : l.Show() : l.BringToFront()
        Application.DoEvents()
        Try
          vcc.canvas.createPdfFile(sfd.FileName)
          l.Text = "Bitte warten, Adobe Reader wird gestartet..." : Application.DoEvents()
          Process.Start(sfd.FileName)
          Threading.Thread.Sleep(500)
        Catch ex As Exception
          MsgBox("Da ist leider was schiefgegangen. Die PDF-Datei konnte nicht erstellt werden. Bitte stelle sicher, dass die Datei nicht im Adobe Reader geöffnet ist." + vbNewLine + vbNewLine + "Fehlermeldung: " + ex.Message, MsgBoxStyle.Exclamation, "Fehler")
        End Try
        Me.Controls.Remove(l)
      End If
    End Using

    'MsgBox("Coming soon..." + vbNewLine + "- SVG" + vbNewLine + "- PDF" + vbNewLine + "- PNG, JPEG, GIF, BMP, TIFF" + vbNewLine + "...")
    'Try
    '  Dim p = Process.GetProcessById(glob.para("procId", "-1"))
    '  p.Kill()
    '  p.WaitForExit()
    '  Threading.Thread.Sleep(100)
    'Catch:End Try

    'glob.para("procId") = Process.Start("C:\test.pdf").Id
  End Sub
#End Region

  Private Sub Panel3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel3.Paint
    Try
      Dim r As New Rectangle(0, 0, Panel3.Width, Panel3.Height)
      Dim bg As New Drawing2D.LinearGradientBrush(r, Color.FromArgb(55, 55, 55), Color.FromArgb(22, 22, 22), Drawing2D.LinearGradientMode.Horizontal)
      e.Graphics.FillRectangle(bg, r)
      bg.Dispose()
    Catch : End Try
  End Sub


  Private Sub vcc_DirtyChanged() Handles vcc.DirtyChanged
    Label9.BackColor = If(vcc.Dirty, Color.Red, Color.Transparent)
  End Sub

  Private Sub nudLineWidth_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudLineWidth.ValueChanged
    vcc.lineWidth = nudLineWidth.Value
  End Sub

  Private Sub cmbLineStyle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLineStyle.SelectedIndexChanged
    vcc.lineStyle = cmbLineStyle.SelectedIndex
  End Sub

  Private Sub vcc_FileSpecChanged() Handles vcc.FileSpecChanged
    Me.Text = IO.Path.GetFileName(vcc.Filespec) + " - ScreenGrab " + My.Application.Info.Version.ToString(2) + " Collage-Modus"
    TextBox1.Text = vcc.FileSpec
  End Sub

  Private Sub txtTextDefault_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTextDefault.TextChanged
    vcc.defaultText = txtTextDefault.Text
  End Sub

  Private Sub nudArrowLength_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudArrowLength.ValueChanged
    vcc.defaultArrowLength = nudArrowLength.Value
  End Sub
End Class