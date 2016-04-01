Imports ScreenGrab6.Vector
Imports System.Runtime.InteropServices
Imports WeifenLuo.WinFormsUI.Docking

Public Class MainWindow

  Public Const COLOR_PALETTE_ITEM_SIZE = 18
  Public Const COLOR_PALETTE_ROWS = 8
  Public Const COLOR_PALETTE_COLS = 3

  Public colorPalette(COLOR_PALETTE_ROWS * COLOR_PALETTE_COLS) As Color
  Public toolboxPermanent As Boolean
  Public toolboxLastclick As Long

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

  Private Sub frm_mdiViewer2_MdiChildActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MdiChildActivate
    refreshToolboxButtonColors()
    refreshFileInfo()
    Program.sbElements.refreshItemList()
  End Sub


#Region "TitleBar verstecken"

  'Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
  '  Get
  '    Dim cp As CreateParams = MyBase.CreateParams
  '    Const WS_CAPTION As Int32 = &HC00000
  '    cp.Style = cp.Style And Not WS_CAPTION
  '    Return cp
  '  End Get
  'End Property

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


  'Sub addPicClient()
  '  Dim img = getCompleteImage()
  '  If img Is Nothing Then Exit Sub
  '  If Program.vcc()() Is Nothing Then newClient()
  '  Program.vcc().canvas.addPicClient(img, "GRAB:" + getDestRect.ToString)
  'End Sub


  Private Sub frm_mdiViewer2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    For Each v As DockContent In DockPanel1.Documents
      v.BringToFront()
      If DirectCast(v, frm_mdiClient).vcc.CheckFileDirty() = False Then e.Cancel = True : Exit Sub
    Next

    If Program.vcc() IsNot Nothing Then
      Program.glob.para("frm_mdiViewer2__colorDefaultFg") = ColorTranslator.ToHtml(Program.vcc().defaultFg)
      Program.glob.para("frm_mdiViewer2__colorDefaultBg") = ColorTranslator.ToHtml(Program.vcc().defaultBg)
    End If
    Program.glob.para("frm_mdiViewer2__lineDefaultWidth") = nudLineWidth.Value
    Program.glob.para("frm_mdiViewer2__arrowDefaultLength") = nudArrowLength.Value
    Program.glob.para("frm_mdiViewer2__lineDefaultStyle") = cmbLineStyle.SelectedIndex
    Program.glob.para("frm_mdiViewer2__textDefaultText") = txtTextDefault.Text
    Program.glob.para("frm_mdiViewer2__textDefaultFontSize") = DefaultFont.SizeInPoints
    Program.glob.para("frm_mdiViewer2__textDefaultFontFamily") = DefaultFont.Name
    Program.glob.para("frm_mdiViewer2__textDefaultFontStyle") = DefaultFont.Style

    Program.glob.saveFormPos(Me)

    'FRM.qq_chkAutoCollage.Enabled = False
    'FRM.qq_chkAutoCollage.Checked = False
  End Sub

  Private Sub frm_mdiViewer2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

    If e.Control And e.KeyCode = Keys.O Then
      OeffnenToolStripMenuItem_Click(Nothing, Nothing)
    End If
    If e.Control And e.KeyCode = Keys.N Then
      NeuToolStripMenuItem_Click(Nothing, Nothing)
    End If

    If Program.vcc() Is Nothing Then Return

    Program.vcc.KeyboardHandler(e)
    'If e.KeyCode = Keys.F1 Then
    '  Dim chh = MdiChildren
    '  Dim pos = Array.IndexOf(chh, ActiveMdiChild) - 1
    '  If pos < 0 Then pos = chh.Length - 1
    '  chh(pos).Activate()
    'End If
    'If e.KeyCode = Keys.F2 Then
    '  Dim chh = MdiChildren
    '  Dim pos = Array.IndexOf(chh, ActiveMdiChild)
    '  chh((pos + 1) Mod chh.Length).Activate()
    'End If
    If e.Control And e.KeyCode = Keys.S Then
      Program.vcc.saveFile(e.Shift)
    End If
    If e.Control And e.KeyCode = Keys.G Then
      CodeGenerierenToolStripMenuItem_Click(Nothing, EventArgs.Empty)
    End If
    If e.Control And e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9 Then
      Dim id As Integer = e.KeyCode - Keys.D0
      toolboxButton_Click(pnlToolbox.Controls("btn_tb_" & id), EventArgs.Empty)
    End If
    If e.KeyCode = Keys.Escape Then
      Program.vcc.toolboxSelElement = VCanvasControl.toolboxElement.Cursor
    End If
  End Sub
  Private Sub frm_mdiViewer2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Program.MDI = Me
    'If Program.vcc().multitouch IsNot Nothing Then
    '  CheckBox1.Visible = True
    '  CheckBox1.Enabled = True
    'End If

    Program.traceWin = New frm_trace()



    'vcc.canvas.UseIntersectionForSelection = glob.para("frm_options__chkCollageHitTestIntersect", "FALSE") = "TRUE"
    'vcc.canvas.IsInsertionMode = False
    'vcc.canvas.IsObjectBorderSelectionMode = False

    ' addPaletteWindow(frm_paletteProperties)
    'addPaletteWindow(frm_paletteFile)
    'addPaletteWindow(frm_paletteCursor)


    registerAppPath()
    Program.glob.readFormPos(Me)
    'frm_paletteFile.MyCanvas = Program.vcc().canvas

    For i = 0 To COLOR_PALETTE_ROWS * COLOR_PALETTE_COLS - 1
      colorPalette(i) = ColorTranslator.FromHtml(Program.glob.para("frm_mdiViewer2__colorPalette_" & i, "#" + Hex(i + 4) + Hex(i + 4) + Hex(i + 4)))
    Next
    nudLineWidth.Value = Program.glob.para("frm_mdiViewer2__lineDefaultWidth", "1")
    nudArrowLength.Value = Program.glob.para("frm_mdiViewer2__arrowDefaultLength", "10")
    cmbLineStyle.SelectedIndex = Program.glob.para("frm_mdiViewer2__lineDefaultStyle", "0")
    txtTextDefault.Text = Program.glob.para("frm_mdiViewer2__textDefaultText", "(Neu Textfeld)")
    VCanvasControl.defaultFont = New Font(Program.glob.para("frm_mdiViewer2__textDefaultFontFamily", "Arial"), Program.glob.para("frm_mdiViewer2__textDefaultFontSize", "10"), _
          Program.glob.para("frm_mdiViewer2__textDefaultFontStyle", 0), GraphicsUnit.Point)

    'Dim ImHauptfensterLadenToolStripMenuItem As New ToolStripMenuItem("Im Hauptfenster laden")
    'AddHandler ImHauptfensterLadenToolStripMenuItem.Click, AddressOf ImHauptfensterLadenToolStripMenuItem_Click
    'vcc.cmsCanvas.Items.Insert(5, ImHauptfensterLadenToolStripMenuItem)

    '  Program.vcc().canvas.KeyHandlerControl = Me
    
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

    Program.sbColor = New frm_paletteColor
    Program.sbFiles = New FilesDockContent
    Program.sbElements = New ElementsDockContent
    Program.sbElements.Show(DockPanel1, DockState.DockLeft)
    Program.sbFiles.Show(DockPanel1, DockState.DockLeft)

    Show()

    My.MyApplication.handleCommandLine(Environment.GetCommandLineArgs())
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

  Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    If Me.WindowState = FormWindowState.Maximized Then
      Me.WindowState = FormWindowState.Normal
    Else
      Me.WindowState = FormWindowState.Maximized
    End If
  End Sub

  Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Me.Close()
  End Sub

  Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Me.WindowState = FormWindowState.Minimized
  End Sub



  Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
    Program.vcc.canvas.IsMultitouchMode = CheckBox1.Checked
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
          Program.glob.para("frm_mdiViewer2__colorPalette_" & clickedIndex) = ColorTranslator.ToHtml(cd.Color)
          pbColorPalette.Invalidate()
        End If
      End Using
      Exit Sub
    End If

    If e.Button = Windows.Forms.MouseButtons.Right Then
      If Program.sbColor.Visible Then
        colorPalette(clickedIndex) = frm_paletteColor.GColorPicker1.Value
        pbColorPalette.Invalidate()
      End If
      Program.sbColor.Show(DockPanel1)
      Exit Sub
    End If

    Program.vcc().setCurrentDefaultColor(clickedColor)

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
    If elID = Program.vcc.toolboxSelElement And (New TimeSpan(Now.Ticks - toolboxLastclick).TotalMilliseconds < 700) Then
      toolboxPermanent = True
      refreshToolboxButtonColors()
      Exit Sub
    End If
    toolboxLastclick = Now.Ticks
    Program.vcc.toolboxSelElement = elID
    toolboxPermanent = False
    refreshToolboxButtonColors()
  End Sub


  Sub refreshToolboxButtonColors()
    Dim vcc As VCanvasControl = Program.vcc
    If vcc Is Nothing Then Return
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




  Private Sub pbDefaultBg_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbDefaultBg.MouseClick
    If Program.vcc() Is Nothing Then Return
    'canvas.DeselectAll()
    Program.vcc.DefaultColorSelected = 2
    If e.Button = Windows.Forms.MouseButtons.Right Then
      Program.sbColor.Show(DockPanel1)
    End If
  End Sub
  Private Sub pbDefaultFg_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbDefaultFg.MouseClick
    If Program.vcc() Is Nothing Then Return
    'canvas.DeselectAll()
    Program.vcc.DefaultColorSelected = 1
    If e.Button = Windows.Forms.MouseButtons.Right Then
      Program.sbColor.Show(DockPanel1)
    End If
  End Sub

  Private Sub pbDefaultBg_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pbDefaultBg.Paint
    If Program.vcc() Is Nothing Then Return
    DrawColorRect(e.Graphics, New SolidBrush(Program.vcc.defaultBg), 0, 0, pbDefaultBg.Width, pbDefaultBg.Height)
    If Program.vcc().DefaultColorSelected = 2 Then e.Graphics.DrawRectangle(Pens.Red, 0, 0, pbDefaultBg.Width - 1, pbDefaultBg.Height - 1)
  End Sub
  Private Sub pbDefaultFg_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pbDefaultFg.Paint
    If Program.vcc() Is Nothing Then Return
    DrawColorRect(e.Graphics, New SolidBrush(Program.vcc.defaultFg), 0, 0, pbDefaultFg.Width, pbDefaultFg.Height)
    If Program.vcc.DefaultColorSelected = 1 Then e.Graphics.DrawRectangle(Pens.Red, 0, 0, pbDefaultFg.Width - 1, pbDefaultFg.Height - 1)
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

  Private Sub SchliessenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem12.Click
    Me.Close()
  End Sub

#Region "Datei-Menü"


  Private Sub NeuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
    'If Program.vcc().CheckFileDirty() Then
    '  Program.vcc().canvas.clearCanvas()
    '  Program.vcc().FileSpec = ""
    '  Program.vcc().Dirty = False
    'End If
    Program.newClient()
  End Sub

  Private Sub OeffnenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
    'vcc.openFile()

    Using ofd As New OpenFileDialog
      'ofd.InitialDirectory = lblCurPath.Text
      ofd.Filter = "Alle unterstützten Dateiformate (*.html, *.htm, *.sgcollage)|*.html;*.htm;*.sgcollage|HTML-Dateien (*.html, *.htm)|*.html;*.htm|Screengrab-Collagen (*.sgcollage)|*.sgcollage|Alle Dateien|*.*"
      If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
        Dim c = Program.newClient()
        c.vcc.openFile(ofd.FileName)
      End If
    End Using
  End Sub


  Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    If Program.vcc() Is Nothing Then Return
    Program.vcc.saveFile(False)
  End Sub
  Private Sub SpeichernToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpeichernToolStripMenuItem.Click
    If Program.vcc() Is Nothing Then Return
    Program.vcc.saveFile(False)
  End Sub

  Private Sub SpeichernUnterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
    If Program.vcc() Is Nothing Then Return
    Program.vcc.saveFile(True)
  End Sub

  Private Sub CodeGenerierenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem9.Click
    If Program.vcc() Is Nothing Then Return
    If String.IsNullOrEmpty(Program.vcc().FileSpec) Then
      MsgBox("Die Collage muss vorher abgespeichert werden.", MsgBoxStyle.Information)
      Exit Sub
    End If

    Try
      Process.Start("VUMLCodeGeneration.exe", Program.vcc().FileSpec)
    Catch ex As Exception
      MsgBox("Fehler beim Aufruf des Code-Generators: " + vbNewLine + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Sub

  Private Sub ExportierenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem8.Click
    If Program.vcc() Is Nothing Then Return
    MsgBox("Dies ist eine experimentelle Funktion, die evtl. zum Absturz des Programms führen kann. Es wird empfohlen, die Collage vorher zu speichern. Das resultierende PDF-Dokument kann Fehler enthalten. (schlechte Bildqualität, falsche Darstellung von Pfeilen)", MsgBoxStyle.Information, "Du befindest dich im Labor...")
    Using sfd As New SaveFileDialog
      sfd.Title = "Als PDF exportieren ..."
      sfd.Filter = "PDF-Dokument (*.pdf)|*.pdf"
      sfd.AddExtension = True
      If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
        Dim l As New Label : Me.Controls.Add(l) : l.Dock = DockStyle.Fill : l.Text = "Bitte warten, PDF wird erstellt..." : l.Show() : l.BringToFront()
        Application.DoEvents()
        Try
          Program.vcc().canvas.createPdfFile(sfd.FileName)
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
    If Program.vcc() Is Nothing Then Return
    Dim filename As String = Program.vcc.FileSpec
    If String.IsNullOrEmpty(filename) Then filename = Program.client.Text
    Me.Text = IO.Path.GetFileName(filename) + " - ScreenGrab " + My.Application.Info.Version.ToString(2) + " Collage-Modus"
    'lblFilename.Text = filename

    Label9.BackColor = If(Program.vcc.Dirty, Color.Red, Color.Transparent)
    SpeichernToolStripMenuItem.Enabled = Program.vcc.Dirty
  End Sub

  Private Sub txtTextDefault_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTextDefault.TextChanged
    VCanvasControl.defaultText = txtTextDefault.Text
  End Sub

  Private Sub nudArrowLength_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudArrowLength.ValueChanged
    VCanvasControl.defaultArrowLength = nudArrowLength.Value
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
      Dim pos As Point = Program.vcc.PictureBox1.PointToClient(New Point(e.X, e.Y))

      Dim files() As String = e.Data.GetData("FileDrop")
      For Each fileSpec In files
        Dim ext As String = IO.Path.GetExtension(fileSpec).ToUpper
        Select Case ext
          Case ".HTM", ".HTML", ".SGCOLLAGE"
            Dim c = Program.newClient()
            c.vcc.openFile(fileSpec)
        End Select
      Next

      Program.vcc.PictureBox1.Refresh()
    End If
  End Sub

  Private Sub OptionenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem11.Click
    frm_options.Show() : frm_options.Activate()
  End Sub



  Private Sub DebugfensterAnzeigenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DebugfensterAnzeigenToolStripMenuItem.Click
    Program.traceWin.Show()
    Program.traceWin.Activate()

  End Sub

  Private Sub SidebarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SidebarToolStripMenuItem.Click
    Program.sbFiles.Show()
  End Sub

  Private Sub VorlagenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VorlagenToolStripMenuItem.Click
    If Program.sbTemplates Is Nothing Then Program.sbTemplates = New TemplatesDockContent
    Program.sbTemplates.Show(DockPanel1, DockState.DockLeft)
  End Sub

  Private Sub OnlinespeicherToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OnlinespeicherToolStripMenuItem.Click
    If Program.sbCloud Is Nothing Then Program.sbCloud = New CloudDockContent
    Program.sbCloud.Show(DockPanel1, DockState.DockLeft)
  End Sub

  Private Sub ElementlisteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ElementlisteToolStripMenuItem.Click
    Program.sbElements.Show()
  End Sub

  Private Sub OnlineSpeichernToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OnlineSpeichernToolStripMenuItem.Click
    Dim client As frm_mdiClient = Program.client()
    If client Is Nothing Then Return
    If client.remoteServer Is Nothing Then
      If Program.sbCloud Is Nothing OrElse Program.sbCloud.GetServer() Is Nothing Then
        OnlinespeicherToolStripMenuItem_Click(Nothing, Nothing)
        MsgBox("Bitte zuerst mit einem Server verbinden")
        Return
      End If
      client.remoteServer = Program.sbCloud.GetServer()
      client.remotePath = Program.sbCloud.GetPath()
      client.vcc.FileSpec = System.IO.Path.GetTempFileName()
    End If
    Using f As New CloudSaveDialog
      client.vcc.saveFile(False)
      f.init(client.vcc.FileSpec, client.remoteServer, client.remotePath, client.remoteFilename)
      If f.ShowDialog() = DialogResult.OK Then
      Else
        client.vcc.Dirty = False
      End If
    End Using
  End Sub

  Private Sub InfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InfoToolStripMenuItem.Click
    Using f As New AboutBox
      f.showDialog()
    End Using
  End Sub
End Class