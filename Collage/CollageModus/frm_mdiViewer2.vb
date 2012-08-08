Imports ScreenGrab6.Vector
Imports System.Runtime.InteropServices

Public Class frm_mdiViewer2
  Dim dropme_postData As String = "key=8b95f50a-959f-4684-8918-f3ab6fc7968a&username=" + glob.para("frm_options__txtLoginUser") + "&password=" + glob.para("frm_options__txtLoginPass")

  Dim dropme_cacheDir As String = IO.Path.Combine(IO.Path.GetTempPath, "SgCollageDropmeFiles\")
  Dim dropme_sourceFilespec As String

  Public Const COLOR_PALETTE_ITEM_SIZE = 18
  Public Const COLOR_PALETTE_ROWS = 8
  Public Const COLOR_PALETTE_COLS = 3

  Public colorPalette(COLOR_PALETTE_ROWS * COLOR_PALETTE_COLS) As Color
  Public toolboxPermanent As Boolean
  Public toolboxLastclick As Long

  Public untitledCounter As Integer = 1

  Public titleBarGradient As New Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(0, 30), Color.DarkOliveGreen, Color.YellowGreen)

  Private ClientControl As MdiClient
  Public Sub New()
    ' This call is required by the Windows Form Designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.
    ClientControl = Nothing
    For Each Ctl As Control In Me.Controls
      ClientControl = TryCast(Ctl, MdiClient)
      If ClientControl IsNot Nothing Then Exit For
    Next
  End Sub


  Public Function newClient() As frm_mdiClient
    Dim f As New frm_mdiClient
    'f.MdiParent = Me
    'f.Show()
    'f.Activate()
    f.Text = String.Format("Unbenannt {0}", untitledCounter)
    untitledCounter += 1
    TabControl1.TabPages.Add(f)
    'f.Left = 0 : f.Top = 0 : f.Width = ClientControl.Width - 5 : f.Height = ClientControl.Height - 5
    While Not TabControl1.SelectedForm Is f
      Application.DoEvents()
    End While
    Return f
  End Function
  Public Function vcc() As Vector.VCanvasControl
    Dim c = client()
    If c Is Nothing Then Return Nothing
    Return c.vcc
  End Function
  Public Function client() As frm_mdiClient
    ' If ActiveMdiChild Is Nothing Then newClient()
    ' Return ActiveMdiChild
    Return TabControl1.SelectedForm
  End Function

  Private Sub frm_mdiViewer2_MdiChildActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MdiChildActivate
    refreshToolboxButtonColors()
    refreshFileInfo()
    refreshItemList()
  End Sub


#Region "TitleBar verstecken"

  Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
    Get
      Dim cp As CreateParams = MyBase.CreateParams
      Const WS_CAPTION As Int32 = &HC00000
      cp.Style = cp.Style And Not WS_CAPTION
      Return cp
    End Get
  End Property

#End Region

#Region "Taskbar bei maximize behalten"
  Private Structure MINMAXINFO
    Public ptReserved As Point
    Public ptMaxSize As Size
    Public ptMaxPosition As Point
    Public ptMinTrackSize As Size
    Public ptMaxTrackSize As Size
  End Structure

  Const WM_GETMINMAXINFO As Integer = &H24

  'Protected Overrides Sub WndProc(ByRef m As Message)
  '  If m.Msg = WM_GETMINMAXINFO Then
  '    Dim mmi As MINMAXINFO = CType(Marshal.PtrToStructure(m.LParam, GetType(MINMAXINFO)), MINMAXINFO)
  '    mmi.ptMaxSize = Screen.GetWorkingArea(Me).Size
  '    Debug.Print(mmi.ptMaxSize.ToString + " ----- " & Me.Width)
  '    Marshal.StructureToPtr(mmi, m.LParam, False)
  '    m.Result = IntPtr.Zero
  '    Return
  '  End If
  '  MyBase.WndProc(m)
  'End Sub

  ' '' ''  <DllImport("user32")> _
  ' '' ''Private Shared Function GetMonitorInfo(ByVal hMonitor As IntPtr, ByRef lpmi As MonitorInfo) As Boolean
  ' '' ''  End Function
  ' '' ''  <DllImport("User32")> _
  ' '' ''  Private Shared Function MonitorFromWindow(ByVal handle As IntPtr, ByVal flags As Integer) As IntPtr
  ' '' ''  End Function
  ' '' ''  <StructLayout(LayoutKind.Sequential)> _
  ' '' ''Private Structure MonitorInfo
  ' '' ''    Public Size As Integer
  ' '' ''    Public rcMonitor As RECT
  ' '' ''    Public rcWork As RECT
  ' '' ''    Public Flags As UInteger
  ' '' ''    Public Sub Init()
  ' '' ''      Me.Size = 40
  ' '' ''    End Sub
  ' '' ''  End Structure
  ' '' ''  <StructLayout(LayoutKind.Sequential)> _
  ' '' ''  Private Structure MINMAXINFO
  ' '' ''    Dim ptReserved As Point
  ' '' ''    Dim ptMaxSize As Point
  ' '' ''    Dim ptMaxPosition As Point
  ' '' ''    Dim ptMinTrackSize As Point
  ' '' ''    Dim ptMaxTrackSize As Point
  ' '' ''  End Structure

  ' '' ''  Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
  ' '' ''    Select Case m.Msg
  ' '' ''      Case &H24
  ' '' ''        WmGetMinMaxInfo(m.HWnd, m.LParam)
  ' '' ''      Case Else

  ' '' ''        MyBase.WndProc(m)
  ' '' ''    End Select
  ' '' ''  End Sub

  ' '' ''  Private Shared Sub WmGetMinMaxInfo(ByVal hwnd As System.IntPtr, ByVal lParam As System.IntPtr)
  ' '' ''    Dim mmi As MINMAXINFO = DirectCast(Marshal.PtrToStructure(lParam, GetType(MINMAXINFO)), MINMAXINFO)

  ' '' ''    ' Adjust the maximized size and position to fit the work area of the correct monitor
  ' '' ''    Dim MONITOR_DEFAULTTONEAREST As Integer = &H2
  ' '' ''    Dim monitor As System.IntPtr = MonitorFromWindow(hwnd, MONITOR_DEFAULTTONEAREST)

  ' '' ''    If monitor <> System.IntPtr.Zero Then

  ' '' ''      Dim monitorInfo As New MonitorInfo() : monitorInfo.Init()
  ' '' ''      GetMonitorInfo(monitor, monitorInfo)
  ' '' ''      Dim rcWorkArea As RECT = monitorInfo.rcWork
  ' '' ''      Dim rcMonitorArea As RECT = monitorInfo.rcMonitor
  ' '' ''      mmi.ptMaxPosition.x = Math.Abs(rcWorkArea.Left - rcMonitorArea.Left)
  ' '' ''      mmi.ptMaxPosition.y = Math.Abs(rcWorkArea.Top - rcMonitorArea.Top)
  ' '' ''      mmi.ptMaxSize.x = Math.Abs(rcWorkArea.Right - rcWorkArea.Left)
  ' '' ''      mmi.ptMaxSize.y = Math.Abs(rcWorkArea.Bottom - rcWorkArea.Top)
  ' '' ''    End If

  ' '' ''    Marshal.StructureToPtr(mmi, lParam, True)
  ' '' ''  End Sub
#End Region


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

  'Sub addPicClient()
  '  Dim img = getCompleteImage()
  '  If img Is Nothing Then Exit Sub
  '  If vcc() Is Nothing Then newClient()
  '  vcc.canvas.addPicClient(img, "GRAB:" + getDestRect.ToString)
  'End Sub


  Private Sub frm_mdiViewer2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    For Each v As MdiTabControl.TabPage In TabControl1.TabPages
      If DirectCast(v.Form, frm_mdiClient).vcc.CheckFileDirty() = False Then e.Cancel = True : Exit Sub
    Next

    hidePaletteWindows()

    If vcc() IsNot Nothing Then
      glob.para("frm_mdiViewer2__colorDefaultFg") = ColorTranslator.ToHtml(vcc.defaultFg)
      glob.para("frm_mdiViewer2__colorDefaultBg") = ColorTranslator.ToHtml(vcc.defaultBg)
    End If
    glob.para("frm_mdiViewer2__lineDefaultWidth") = nudLineWidth.Value
    glob.para("frm_mdiViewer2__arrowDefaultLength") = nudArrowLength.Value
    glob.para("frm_mdiViewer2__lineDefaultStyle") = cmbLineStyle.SelectedIndex
    glob.para("frm_mdiViewer2__textDefaultText") = txtTextDefault.Text
    glob.para("frm_mdiViewer2__textDefaultFontSize") = DefaultFont.SizeInPoints
    glob.para("frm_mdiViewer2__textDefaultFontFamily") = DefaultFont.Name
    glob.para("frm_mdiViewer2__textDefaultFontStyle") = DefaultFont.Style

    glob.saveFormPos(Me)

    'FRM.qq_chkAutoCollage.Enabled = False
    'FRM.qq_chkAutoCollage.Checked = False
  End Sub

  Private Sub frm_mdiViewer2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

    If e.Control And e.KeyCode = Keys.O Then
      vcc.openFile()
    End If

    If vcc() Is Nothing Then Return

    vcc.KeyboardHandler(e)
    If e.KeyCode = Keys.F1 Then
      Dim chh = MdiChildren
      Dim pos = Array.IndexOf(chh, ActiveMdiChild) - 1
      If pos < 0 Then pos = chh.Length - 1
      chh(pos).Activate()
    End If
    If e.KeyCode = Keys.F2 Then
      Dim chh = MdiChildren
      Dim pos = Array.IndexOf(chh, ActiveMdiChild)
      chh((pos + 1) Mod chh.Length).Activate()
    End If
    If e.Control And e.KeyCode = Keys.S Then
      vcc.saveFile(e.Shift)
    End If
    If e.Control And e.KeyCode = Keys.G Then
      CodeGenerierenToolStripMenuItem_Click(Nothing, EventArgs.Empty)
    End If
    If e.Control And e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9 Then
      Dim id As Integer = e.KeyCode - Keys.D0
      toolboxButton_Click(pnlToolbox.Controls("btn_tb_" & id), EventArgs.Empty)
    End If
    If e.KeyCode = Keys.Escape Then
      vcc.toolboxSelElement = VCanvasControl.toolboxElement.None
    End If
  End Sub
  Private Sub frm_mdiViewer2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MDI = Me
    'If vcc.multitouch IsNot Nothing Then
    '  CheckBox1.Visible = True
    '  CheckBox1.Enabled = True
    'End If

    pnlLeft.Width = 6

    'vcc.canvas.UseIntersectionForSelection = glob.para("frm_options__chkCollageHitTestIntersect", "FALSE") = "TRUE"
    'vcc.canvas.IsInsertionMode = False
    'vcc.canvas.IsObjectBorderSelectionMode = False

    ' addPaletteWindow(frm_paletteProperties)
    'addPaletteWindow(frm_paletteFile)
    'addPaletteWindow(frm_paletteCursor)
    interproc_init()

    mwRegisterSelf()
    glob.readFormPos(Me)

    makeFormGlassReady(Me, Panel1, DockStyle.Top)

    'frm_paletteFile.MyCanvas = vcc.canvas

    For i = 0 To COLOR_PALETTE_ROWS * COLOR_PALETTE_COLS - 1
      colorPalette(i) = ColorTranslator.FromHtml(glob.para("frm_mdiViewer2__colorPalette_" & i, "#" + Hex(i + 4) + Hex(i + 4) + Hex(i + 4)))
    Next
    nudLineWidth.Value = glob.para("frm_mdiViewer2__lineDefaultWidth", "1")
    nudArrowLength.Value = glob.para("frm_mdiViewer2__arrowDefaultLength", "10")
    cmbLineStyle.SelectedIndex = glob.para("frm_mdiViewer2__lineDefaultStyle", "0")
    txtTextDefault.Text = glob.para("frm_mdiViewer2__textDefaultText", "(Neu Textfeld)")
    VCanvasControl.defaultFont = New Font(glob.para("frm_mdiViewer2__textDefaultFontFamily", "Arial"), glob.para("frm_mdiViewer2__textDefaultFontSize", "10"), _
          glob.para("frm_mdiViewer2__textDefaultFontStyle", 0), GraphicsUnit.Point)

    btnNav01.Text = IO.Path.GetFileName(glob.para("frm_mdiViewer2__quickNavBtn__btnNav01"))
    btnNav02.Text = IO.Path.GetFileName(glob.para("frm_mdiViewer2__quickNavBtn__btnNav02"))
    btnNav03.Text = IO.Path.GetFileName(glob.para("frm_mdiViewer2__quickNavBtn__btnNav03"))
    FolderBrowser1.SelectPath(glob.para("frm_mdiViewer2__folderSel", "C:\"), True)

    'Dim ImHauptfensterLadenToolStripMenuItem As New ToolStripMenuItem("Im Hauptfenster laden")
    'AddHandler ImHauptfensterLadenToolStripMenuItem.Click, AddressOf ImHauptfensterLadenToolStripMenuItem_Click
    'vcc.cmsCanvas.Items.Insert(5, ImHauptfensterLadenToolStripMenuItem)

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
    pnlSideLocFiles.BringToFront()

    Show()


  End Sub

  Private Sub Panel1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) _
  Handles PictureBox2.MouseDown, Panel1.MouseDown, lblFilename.MouseDown
    If e.Button = Windows.Forms.MouseButtons.Left Then

      FormMoveTricky(Me.Handle)
    ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
      Clipboard.SetText(lblFilename.Text)
      lblFilename.BackColor = Color.BlueViolet
      Application.DoEvents()
      Threading.Thread.Sleep(500)
      lblFilename.BackColor = Color.Transparent
    End If
    'If e.Button = Windows.Forms.MouseButtons.Right Then
    '  frm_paletteCursor.Show()

    'End If
  End Sub

  'Private Sub ZusatzfensterAnzeigenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZusatzfensterAnzeigenToolStripMenuItem.Click
  '  showProperties(vcc.canvas.GetFirstSelectedObject, True)
  'End Sub

  'Sub showProperties(ByVal obj As VObject, Optional ByVal force As Boolean = False)
  '  If force = True Then
  '    frm_paletteFile.Show()
  '    frm_paletteFile.Activate()
  '  ElseIf force = False And frm_paletteFile.Visible = False Then
  '    Exit Sub
  '  End If
  '  ' frm_paletteFile.MyCanvas = Me
  '  frm_paletteFile.RefreshItemList()
  '  frm_paletteFile.SelectedObject = obj
  'End Sub

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



  Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
    vcc.canvas.IsMultitouchMode = CheckBox1.Checked
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

    vcc.setCurrentDefaultColor(clickedColor)

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


  Sub refreshToolboxButtonColors()
    If vcc.toolboxSelElement = 1 Then toolboxPermanent = True
    For Each item As Control In pnlToolbox.Controls
      item.BackColor = If(item.Tag = vcc.toolboxSelElement, If(toolboxPermanent, Color.Black, Color.Yellow), Color.Transparent)
      DirectCast(item, Button).UseVisualStyleBackColor = item.Tag <> vcc.toolboxSelElement
    Next

    vcc.canvas.IsInsertionMode = (vcc.toolboxSelElement <> VCanvasControl.toolboxElement.Cursor) And _
        (vcc.toolboxSelElement <> VCanvasControl.toolboxElement.ColorPicker)
    vcc.canvas.IsLineDrawingMode = (vcc.toolboxSelElement = VCanvasControl.toolboxElement.Line) Or _
       (vcc.toolboxSelElement = VCanvasControl.toolboxElement.Arrow)

    grpLine.Visible = vcc.toolboxSelElement = VCanvasControl.toolboxElement.Ellipse Or _
      vcc.toolboxSelElement = VCanvasControl.toolboxElement.Line Or _
      vcc.toolboxSelElement = VCanvasControl.toolboxElement.Arrow Or vcc.toolboxSelElement = VCanvasControl.toolboxElement.Rectangle Or _
      (vcc.toolboxSelElement = VCanvasControl.toolboxElement.UmlClass)
    grpText.Visible = vcc.toolboxSelElement = VCanvasControl.toolboxElement.Textbox
    grpArrow.Visible = vcc.toolboxSelElement = VCanvasControl.toolboxElement.Arrow

    If vcc.toolboxSelElement <> VCanvasControl.toolboxElement.Arrow And vcc.DefaultColorSelected = -1 Then _
      vcc.DefaultColorSelected = 1
  End Sub

  Sub refreshItemList()
    lstElementNames.Items.Clear()
    For Each v In vcc.canvas.objects
      'lstElementNames.Items.Add(v.name)
      lstElementNames.Items.Add(v)
      'If v.isSelected Then lstElementNames.SetItemChecked(lstElementNames.Items.Count - 1, True)
    Next
    txtElementName.Text = Join(client.selnames, ", ")
    txtElementName.Enabled = vcc.canvas.SelectionCount = 1

    ' If vcc.canvas.SelectionCount <> 1 Then lstElementNames.SelectedIndex = -1
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
    If vcc() Is Nothing Then Return
    'canvas.DeselectAll()
    vcc.DefaultColorSelected = 2
    If e.Button = Windows.Forms.MouseButtons.Right Then
      If Not showColorPalettteIfNotVisible() Then
        vcc.setCurrentDefaultColor(frm_paletteColor.GColorPicker1.Value)
      End If
    End If
  End Sub
  Private Sub pbDefaultFg_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbDefaultFg.MouseClick
    If vcc() Is Nothing Then Return
    'canvas.DeselectAll()
    vcc.DefaultColorSelected = 1
    If e.Button = Windows.Forms.MouseButtons.Right Then
      If Not showColorPalettteIfNotVisible() Then
        vcc.setCurrentDefaultColor(frm_paletteColor.GColorPicker1.Value)
      End If
    End If
  End Sub

  Private Sub pbDefaultBg_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pbDefaultBg.Paint
    If vcc() Is Nothing Then Return
    DrawColorRect(e.Graphics, New SolidBrush(vcc.defaultBg), 0, 0, pbDefaultBg.Width, pbDefaultBg.Height)
    If vcc.DefaultColorSelected = 2 Then e.Graphics.DrawRectangle(Pens.Red, 0, 0, pbDefaultBg.Width - 1, pbDefaultBg.Height - 1)
  End Sub
  Private Sub pbDefaultFg_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pbDefaultFg.Paint
    If vcc() Is Nothing Then Return
    DrawColorRect(e.Graphics, New SolidBrush(vcc.defaultFg), 0, 0, pbDefaultFg.Width, pbDefaultFg.Height)
    If vcc.DefaultColorSelected = 1 Then e.Graphics.DrawRectangle(Pens.Red, 0, 0, pbDefaultFg.Width - 1, pbDefaultFg.Height - 1)
  End Sub

  Private Sub btnDefaultFontChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDefaultFontChange.Click
    Using fd As New FontDialog
      fd.Font = VCanvasControl.defaultFont
      fd.FontMustExist = True

      If fd.ShowDialog = Windows.Forms.DialogResult.OK Then
        VCanvasControl.defaultFont = fd.Font
      End If
    End Using
  End Sub

  Private Sub RadioButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_tb_8.Click
    'openGrabWindow()
    Try
      Process.Start(ExePath("Screengrab6"), "/grab-to-collage")
    Catch ex As Exception
      MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Screenshot einfügen")
    End Try

  End Sub

  Private Sub btnFileMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFileMenu.Click
    cmsFileMenu.Show(btnFileMenu, 0, btnFileMenu.Height)
  End Sub

  Private Sub SchliessenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SchliessenToolStripMenuItem.Click
    Me.Close()
  End Sub

#Region "Datei-Menü"


  Private Sub NeuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NeuToolStripMenuItem.Click
    'If vcc.CheckFileDirty() Then
    '  vcc.canvas.clearCanvas()
    '  vcc.FileSpec = ""
    '  vcc.Dirty = False
    'End If
    newClient()
  End Sub

  Private Sub OeffnenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OeffnenToolStripMenuItem.Click
    'vcc.openFile()

    Using ofd As New OpenFileDialog
      ofd.InitialDirectory = lblCurPath.Text
      ofd.Filter = "Alle unterstützten Dateiformate (*.html, *.htm, *.sgcollage)|*.html;*.htm;*.sgcollage|HTML-Dateien (*.html, *.htm)|*.html;*.htm|Screengrab-Collagen (*.sgcollage)|*.sgcollage|Alle Dateien|*.*"
      If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
        Dim c = newClient()
        c.vcc.openFile(ofd.FileName)
      End If
    End Using
  End Sub


  Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
    If vcc() Is Nothing Then Return
    vcc.saveFile(False)
  End Sub
  Private Sub SpeichernToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpeichernToolStripMenuItem.Click
    If vcc() Is Nothing Then Return
    vcc.saveFile(False)
  End Sub

  Private Sub SpeichernUnterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpeichernUnterToolStripMenuItem.Click
    If vcc() Is Nothing Then Return
    vcc.saveFile(True)
  End Sub

  Private Sub CodeGenerierenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CodeGenerierenToolStripMenuItem.Click
    If vcc() Is Nothing Then Return
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
    If vcc() Is Nothing Then Return
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
      Dim bg As New Drawing2D.LinearGradientBrush(r, Color.FromArgb(66, 66, 66), Color.FromArgb(11, 11, 11), Drawing2D.LinearGradientMode.Horizontal)
      e.Graphics.FillRectangle(bg, r)
      bg.Dispose()
    Catch : End Try
  End Sub



  Private Sub nudLineWidth_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudLineWidth.ValueChanged
    VCanvasControl.lineWidth = nudLineWidth.Value
  End Sub

  Private Sub cmbLineStyle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLineStyle.SelectedIndexChanged
    VCanvasControl.lineStyle = cmbLineStyle.SelectedIndex
  End Sub

  Public Sub refreshFileInfo()
    If vcc() Is Nothing Then Return
    Dim filename As String = vcc.FileSpec
    If String.IsNullOrEmpty(filename) Then filename = client.Text
    Me.Text = IO.Path.GetFileName(filename) + " - ScreenGrab " + My.Application.Info.Version.ToString(2) + " Collage-Modus"
    lblFilename.Text = filename

    Label9.BackColor = If(vcc.Dirty, Color.Red, Color.Transparent)
    btnSave.Enabled = vcc.Dirty
  End Sub

  Private Sub txtTextDefault_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTextDefault.TextChanged
    VCanvasControl.defaultText = txtTextDefault.Text
  End Sub

  Private Sub nudArrowLength_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudArrowLength.ValueChanged
    VCanvasControl.defaultArrowLength = nudArrowLength.Value
  End Sub

  Private Sub Panel1_Paint_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
    e.Graphics.FillRectangle(titleBarGradient, sender.Bounds)

  End Sub

  Private Sub btnShowElementList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    pnlSideElements.Visible = Not pnlSideElements.Visible
    If pnlSideElements.Visible Then lstElementNames.Focus()
  End Sub

  Private Sub lstElementNames_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles lstElementNames.DrawItem
    If e.Index < 0 Then Return
    Dim obj As VObject = lstElementNames.Items(e.Index)

    Windows.Forms.ControlPaint.DrawCheckBox(e.Graphics, e.Bounds.X + 1, e.Bounds.Y + 10, 16, 16, _
                                            If(obj.isSelected, ButtonState.Checked, ButtonState.Normal))

    e.Graphics.DrawImage(obj.GetAsImage(), e.Bounds.X + 20, e.Bounds.Y, e.Bounds.Width - 20, e.Bounds.Height)

  End Sub

  Private Sub lstElementNames_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstElementNames.LostFocus
    ' pnlElements.Hide()
  End Sub

  Private Sub lstElementNames_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstElementNames.MouseDown
    If vcc() Is Nothing Then Return
    If e.Button = Windows.Forms.MouseButtons.Left Then
      Dim idx = lstElementNames.IndexFromPoint(e.Location)
      If idx = -1 Then Return
      'Dim obj = vcc.canvas.GetObjectByID(lstElementNames.Items(idx))
      Dim obj As VObject = lstElementNames.Items(idx)
      obj.isSelected = Not obj.isSelected
      vcc.canvas.OnSelectionChanged()
      Return
    End If

    If e.Button = Windows.Forms.MouseButtons.Right Then
      Dim idx = lstElementNames.IndexFromPoint(e.Location)
      If idx > -1 Then
        vcc.canvas.SelectObject(lstElementNames.Items(idx))
      End If
    End If

    ' pnlElements.Hide()
  End Sub

  Private Sub Label2_MouseEnter(ByVal sender As Label, ByVal e As System.EventArgs) Handles Label3.MouseEnter, Label2.MouseEnter, Label1.MouseEnter
    sender.BackColor = Color.White
  End Sub

  Private Sub Label2_MouseLeave(ByVal sender As Label, ByVal e As System.EventArgs) Handles Label3.MouseLeave, Label2.MouseLeave, Label1.MouseLeave
    sender.BackColor = Color.Transparent
  End Sub


  Private Sub lblToggleLeftPanel_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblToggleLeftPanel.MouseDown
    If e.Button = Windows.Forms.MouseButtons.Left Then
      pnlLeft.Width = If(pnlLeft.Width = 6, 232, 6)
    ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
      Me.TopMost = Not Me.TopMost
      lblToggleLeftPanel.BackColor = If(Me.TopMost, Color.CornflowerBlue, Color.OliveDrab)
    ElseIf e.Button = Windows.Forms.MouseButtons.Middle Then
      lstTrace.BringToFront()
      ' lstTrace.Visible = Not lstTrace.Visible
    End If
  End Sub


  Dim lstFileListMouseDownPoint As Point

  Private Sub ListBox1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox1.MouseDoubleClick
    Dim fileSpecSel As String = IO.Path.Combine(lblCurPath.Text, ListBox1.SelectedItem)
    Dim c = newClient()
    c.vcc.openFile(fileSpecSel)
  End Sub
  Private Sub ListBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox1.MouseDown
    ListBox1.SelectedIndex = ListBox1.IndexFromPoint(e.Location)
    lstFileListMouseDownPoint = e.Location
  End Sub

  Private Sub ListBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox1.MouseMove
    If e.Button = Windows.Forms.MouseButtons.Left AndAlso ListBox1.SelectedIndex > -1 _
        AndAlso lstFileListMouseDownPoint <> Nothing _
        AndAlso (Math.Abs(lstFileListMouseDownPoint.X - e.Location.X) > 2 Or Math.Abs(lstFileListMouseDownPoint.Y - e.Location.Y) > 2) Then
      lstFileListMouseDownPoint = Nothing
      Dim fileSpecSel As String = IO.Path.Combine(lblCurPath.Text, ListBox1.SelectedItem)
      Dim datObj As New DataObject("FileDrop", New String() {fileSpecSel})
      ListBox1.DoDragDrop(datObj, DragDropEffects.Copy)
    End If
  End Sub

  Private Sub ListBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox1.MouseUp
    If isKeyPressed(Keys.ControlKey) Then
      Dim fileSpecSel As String = IO.Path.Combine(lblCurPath.Text, ListBox1.SelectedItem)
      Dim c = newClient()
      c.vcc.openFile(fileSpecSel)
    ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
      If vcc() Is Nothing Then Return
      Dim fileSpecSel As String = IO.Path.Combine(lblCurPath.Text, ListBox1.SelectedItem)
      vcc.openFile(fileSpecSel)
    End If
  End Sub

  Private Sub Button1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnNav03.MouseUp, btnNav02.MouseUp, btnNav01.MouseUp, btnNav04.MouseUp
    If e.Button = Windows.Forms.MouseButtons.Right Then
      glob.para("frm_mdiViewer2__quickNavBtn__" + sender.name) = lblCurPath.Text
      sender.text = IO.Path.GetFileName(lblCurPath.Text)
    Else
      FolderBrowser1.SelectPath(glob.para("frm_mdiViewer2__quickNavBtn__" + sender.name), True)
    End If
  End Sub

  Private Sub FolderBrowser1_SelectedFolderChanged(ByVal sender As System.Object, ByVal e As DirectoryBrowser.SelectedFolderChangedEventArgs) Handles FolderBrowser1.SelectedFolderChanged

    ListBox1.Items.Clear()
    glob.para("frm_mdiViewer2__folderSel") = e.Path
    lblCurPath.Text = e.Path
    If vcc() IsNot Nothing Then vcc.FileDialogInitialDirectory = e.Path
    Dim files() As String = IO.Directory.GetFiles(e.Path)
    For Each file In files
      ListBox1.Items.Add(IO.Path.GetFileName(file))
    Next

  End Sub

  Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
    If ListBox1.SelectedIndex > -1 Then
      Dim fileSpecSel As String = IO.Path.Combine(lblCurPath.Text, ListBox1.SelectedItem)

      Select Case IO.Path.GetExtension(fileSpecSel).ToUpper
        Case ".BMP", ".GIF", ".JPG", ".PNG"
          pbPreview.Image = Image.FromFile(fileSpecSel)
        Case ".SGCOLLAGE", ".HTML", ".HTM"

      End Select

    End If

  End Sub

  Private Sub TabControl1_TabPaintBorder(ByVal sender As Object, ByVal e As MdiTabControl.TabControl.TabPaintEventArgs) Handles TabControl1.TabPaintBorder
    If e.Selected Or e.Hot Then
      e.Handled = False
      e.Graphics.FillRectangle(Brushes.Orange, 0, 0, e.TabWidth, 3)
    End If
  End Sub



  Private Sub vcc_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragEnter
    If e.Data.GetDataPresent("FileDrop") Then
      Dim files() As String = e.Data.GetData("FileDrop")
      For Each fileSpec In files
        Dim ext As String = IO.Path.GetExtension(fileSpec).ToUpper
        Select Case ext
          Case ".HTM", ".HTML", ".SGCOLLAGE"
            e.Effect = DragDropEffects.Copy
        End Select
      Next
    End If
  End Sub

  Private Sub vcc_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragDrop
    If e.Data.GetDataPresent("FileDrop") Then
      Dim pos As Point = vcc.PictureBox1.PointToClient(New Point(e.X, e.Y))

      Dim files() As String = e.Data.GetData("FileDrop")
      For Each fileSpec In files
        Dim ext As String = IO.Path.GetExtension(fileSpec).ToUpper
        Select Case ext
          Case ".HTM", ".HTML", ".SGCOLLAGE"
            Dim c = newClient()
            c.vcc.openFile(fileSpec)
        End Select
      Next

      vcc.PictureBox1.Refresh()
    End If
  End Sub


#Region "Sidebar"

  Private Sub lstTrace_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstTrace.MouseUp
    If e.Button = Windows.Forms.MouseButtons.Middle Then
      lstTrace.Items.Clear()
    End If
    If e.Button = Windows.Forms.MouseButtons.Right Then
      TextBox1.Visible = Not TextBox1.Visible
      TextBox1.Height = Me.ClientSize.Height - 50

    End If
    TextBox1.Text = lstTrace.SelectedItem
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
      lstTrace.Items.Add("errMes : " + RESULT_String)
      MsgBox("Es konnte keine Verbindung zum Server aufgebaut werden. Bitte überprüfe, ob die Verbindung mit dem Internet hergestellt ist.", MsgBoxStyle.Critical, "Fehler")
      Return Nothing
    End If
    Return RESULT
  End Function


  Private Sub llSidebar2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llSidebar2.LinkClicked
    InitDropme()
  End Sub
  Sub InitDropme()
    Dim RESULT As Hashtable = TryLoadJSON("http://dropme.de/api/clipboards/favtag/fav", dropme_postData)
    If RESULT Is Nothing Then Return
    If RESULT("success") <> True Then
      If MsgBox("Der Server hat eine Fehlermeldung zurückgeliefert. Bitte überprüfe, ob die Verbindung mit dem Internet hergestellt ist und die richtigen Logindaten für DropMe.de eingetragen sind." + vbNewLine + vbNewLine + "Fehlermeldung: " + RESULT("error") + vbNewLine + vbNewLine + "Sollen die Einstellungen geöffnet werden, um die Logindaten zu überprüfen?", MsgBoxStyle.Critical Or MsgBoxStyle.YesNo, "Fehler") = MsgBoxResult.Yes Then
        frm_options.Show()
      End If
      Return
    End If

    cmbDropmeClipboard.Items.Clear()
    Dim LIST As ArrayList = RESULT("list")
    For Each item As Hashtable In LIST
      If item("owner") = "" Then
        cmbDropmeClipboard.Items.Add(item("name"))
      Else
        cmbDropmeClipboard.Items.Add(item("owner") + "/" + item("name"))
      End If
    Next
    If cmbDropmeClipboard.Items.Count > 0 Then cmbDropmeClipboard.SelectedIndex = 0
  End Sub

  Dim loadDropmeThumbnails_CANCEL_FLAG As Boolean = False
  Dim loadDropmeThumbnails_RUNNING_FLAG As Boolean = False

  Private Sub cmbDropmeClipboard_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDropmeClipboard.SelectedIndexChanged
    loadDropmeThumbnails_CANCEL_FLAG = True

    Dim selClip = Split(DirectCast(cmbDropmeClipboard.Text, String), "/", 2)
    If selClip.Length = 1 Then selClip = New String() {"", selClip(0)}
    Dim RESULT As Hashtable = TryLoadJSON("http://dropme.de/api/info?owner=" + selClip(0) + "&name=" + selClip(1), dropme_postData)
    If RESULT Is Nothing Then
      MsgBox("Invalid Clipboard")
      Return
    End If

    Dim RESULT2 As Hashtable = TryLoadJSON("http://dropme.de/api/items/" + RESULT("cbid"), dropme_postData)
    If RESULT2 Is Nothing Then
      MsgBox("Invalid Clipboard.")
      Return
    End If

    ImageList1.Images.Clear()
    ListView1.Items.Clear()
    For Each item As Hashtable In RESULT2("item_list")
      Dim lvi = ListView1.Items.Add(CStr(item("filename")))
      lvi.Tag = item
    Next


    'While loadDropmeThumbnails_RUNNING_FLAG
    '  Beep()
    '  Threading.Thread.Sleep(150)
    '  Application.DoEvents()
    'End While

    loadDropmeThumbnails_CANCEL_FLAG = False
    Dim t As New Threading.Thread(AddressOf loadDropmeThumbnailsThread)
    t.Start(RESULT2("item_list"))
  End Sub


  Private Sub loadDropmeThumbnailsThread(ByVal arrayList As Object)
    loadDropmeThumbnails_RUNNING_FLAG = True
    Try
      Dim tempFolder = IO.Path.Combine(IO.Path.GetTempPath, "SgCollageDropmeThumbs")
      IO.Directory.CreateDirectory(tempFolder)
      For i = 0 To arrayList.Count - 1
        Dim tempFile = IO.Path.Combine(tempFolder, arrayList(i)("cid") + ".jpg")
        If (IO.File.Exists(tempFile)) Then
          Me.Invoke(dloadDropmeThumbnailsCallback, i, Image.FromFile(tempFile))
        Else

          Dim img = ImageFromWeb("http://dropme.de/api/preview_image/" + arrayList(i)("cid") + "/256", dropme_postData)
          If loadDropmeThumbnails_CANCEL_FLAG Then GoTo exit_Sub
          If img IsNot Nothing Then
            img.Save(tempFile, System.Drawing.Imaging.ImageFormat.Jpeg)
            Me.Invoke(dloadDropmeThumbnailsCallback, i, img)
          End If
        End If

        If loadDropmeThumbnails_CANCEL_FLAG Then GoTo exit_Sub

      Next
    Catch ex As Exception
      MsgBox("error in loadDropmeThumbnailsThread" + vbNewLine + ex.Message)
    End Try
exit_Sub:
    loadDropmeThumbnails_CANCEL_FLAG = False
    loadDropmeThumbnails_RUNNING_FLAG = False
  End Sub

  Private dloadDropmeThumbnailsCallback As New dddloadDropmeThumbnailsCallback(AddressOf loadDropmeThumbnailsCallback)
  Private Delegate Sub dddloadDropmeThumbnailsCallback(ByVal index As Integer, ByVal payload As Image)
  Private Sub loadDropmeThumbnailsCallback(ByVal index As Integer, ByVal payload As Image)
    Try
      ImageList1.Images.Add("i_" & index, payload)
      ListView1.Items(index).ImageKey = "i_" & index

    Catch : loadDropmeThumbnails_CANCEL_FLAG = True : End Try
  End Sub

  Private Sub llSidebar3_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles llSidebar3.MouseDown, llSidebar2.MouseDown, llSidebar1.MouseDown, llSidebar4.MouseDown
    llSidebar1.BackColor = Color.DarkGray : llSidebar2.BackColor = Color.DarkGray : llSidebar3.BackColor = Color.DarkGray : llSidebar4.BackColor = Color.DarkGray
    sender.backcolor = Color.Gainsboro
    If sender Is llSidebar1 Then pnlSideLocFiles.BringToFront()
    If sender Is llSidebar2 Then pnlSideDropme.BringToFront()
    If sender Is llSidebar3 Then lstTrace.BringToFront()
    If sender Is llSidebar4 Then pnlSideElements.BringToFront()

  End Sub

  Private Sub txtDropMeSave_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDropMeSave.KeyDown
    If e.KeyCode = Keys.Enter Then
      btnDropMeSave_Click(Nothing, Nothing)
    End If
  End Sub


  Dim WithEvents bwUploadDropme As New System.ComponentModel.BackgroundWorker

  Private Sub btnDropMeSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDropMeSave.Click
    pnlDropMeSave.Enabled = False

    dropme_sourceFilespec = dropme_cacheDir + txtDropMeSave.Text + ".html"
    IO.Directory.CreateDirectory(dropme_cacheDir)
    vcc.FileSpec = dropme_sourceFilespec
    vcc.saveFile(False)

    ProgressBar1.Maximum = FileLen(dropme_sourceFilespec)
    ProgressBar1.Show()

    bwUploadDropme.WorkerReportsProgress = True
    bwUploadDropme.WorkerSupportsCancellation = True
    bwUploadDropme.RunWorkerAsync(cmbDropmeClipboard.Text)

    Enabled = True
  End Sub



  Private Sub bwUploadDropme_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwUploadDropme.DoWork
    Try
      Dim selClip = Split(DirectCast(e.Argument, String), "/", 2)
      If selClip.Length = 1 Then selClip = New String() {"", selClip(0)}
      Dim RESULT As Hashtable = TryLoadJSON("http://dropme.de/api/info?owner=" + selClip(0) + "&name=" + selClip(1), dropme_postData)
      If RESULT Is Nothing Then
        e.Result = New Object() {0, "Invalid Clipboard"}
        Return
      End If

      Dim cbid As String = RESULT("cbid")

      Dim Idboundary = "sg6collagedropmeupload" & Now.Ticks    ' you can generate this number
      Dim strBoundary = Strings.StrDup(27, "-") & Idboundary     ' mutipart post need "-" sign 

      Dim fieldPart As String = _
        "--" & strBoundary & vbCrLf & _
        "Content-Disposition: form-data; name=""force""" & vbCrLf & _
        vbCrLf & "1" & _
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
        "Content-Disposition: form-data; name=""uploaded""; filename=""" + txtDropMeSave.Text + ".html""" & vbCrLf & _
        "Content-Type: application/octet-stream" & vbCrLf & vbCrLf '& _

      Dim cl As Integer = FileLen(dropme_sourceFilespec) + fieldPart.Length + 8 + strBoundary.Length

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

      Dim fileStream As New IO.FileStream(dropme_sourceFilespec, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
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
        e.Result = New Object() {0, "Ungültige Serverantwort", data}
        Return
      End If

      If RESULT2("success") <> True Then
        e.Result = New Object() {0, RESULT2("error"), data}
        Return
      End If


      e.Result = New Object() {1, RESULT2("new_item")("url")}


    Catch ex As System.Net.WebException
      e.Result = New Object() {0, ex.Message, New IO.StreamReader(ex.Response.GetResponseStream).ReadToEnd}

    Catch ex As Exception
      e.Result = New Object() {0, ex.Message, ex.ToString}
      Return
    End Try
  End Sub

  Private Sub bwUploadDropme_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bwUploadDropme.ProgressChanged
    ProgressBar1.Value = e.ProgressPercentage
  End Sub

  Private Sub bwUploadDropme_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwUploadDropme.RunWorkerCompleted
    ProgressBar1.Hide()
    pnlDropMeSave.Enabled = True

    If e.Result(0) = 0 Then
      'Fehler
      lstTrace.Items.Add("errMes     : " + e.Result(1))
      lstTrace.Items.Add("errDetails : " + e.Result(2))
      MsgBox(e.Result(1), MsgBoxStyle.Exclamation)
    Else
      'OK
      PictureBox1.Hide()

      Clipboard.Clear()
      Clipboard.SetText(e.Result(1))

      lstTrace.Items.Add("success : " + e.Result(1))

      My.Computer.Audio.Play("C:\windows\media\chimes.wav")

      cmbDropmeClipboard_SelectedIndexChanged(Nothing, Nothing) 'refresh list

      Application.DoEvents()
      Threading.Thread.Sleep(300)
      PictureBox1.Show()
      Application.DoEvents()
      Threading.Thread.Sleep(300)
      PictureBox1.Hide()
      Application.DoEvents()
      Threading.Thread.Sleep(300)
      PictureBox1.Show()
    End If
  End Sub


#End Region

  Private Sub OptionenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionenToolStripMenuItem.Click
    frm_options.Show() : frm_options.Activate()
  End Sub

  Private Sub ListView1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDoubleClick
    If ListView1.SelectedItems.Count = 1 Then
      Dim ht As Hashtable = ListView1.SelectedItems(0).Tag
      Dim dlFilespec As String = dropme_cacheDir + ht("filename")
      ProgressBar1.Show()
      ProgressBar1.Style = ProgressBarStyle.Marquee
      Application.DoEvents() : Application.DoEvents()
      URLDownloadToFile(IntPtr.Zero, ht("data_url"), dlFilespec, 0, IntPtr.Zero)
      Application.DoEvents() : Application.DoEvents()

      Dim c = newClient()
      c.vcc.openFile(dlFilespec)
      txtDropMeSave.Text = IO.Path.GetFileNameWithoutExtension(ht("filename"))
      ProgressBar1.Style = ProgressBarStyle.Continuous
      ProgressBar1.Hide()
    End If
  End Sub

  Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

  End Sub
End Class