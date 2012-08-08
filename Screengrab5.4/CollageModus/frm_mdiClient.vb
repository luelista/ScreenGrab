Imports ScreenGrab6.Vector

Public Class frm_mdiClient

  Public selNames() As String

  Private Sub frm_mdiClient_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    vcc.canvas.window = New collageModusDOMWindow

    vcc.canvas.UseIntersectionForSelection = glob.para("frm_options__chkCollageHitTestIntersect", "FALSE") = "TRUE"
    vcc.canvas.IsInsertionMode = False
    vcc.canvas.IsObjectBorderSelectionMode = False

    Dim ImHauptfensterLadenToolStripMenuItem As New ToolStripMenuItem("Im Hauptfenster laden")
    AddHandler ImHauptfensterLadenToolStripMenuItem.Click, AddressOf ImHauptfensterLadenToolStripMenuItem_Click
    vcc.cmsCanvas.Items.Insert(5, ImHauptfensterLadenToolStripMenuItem)

    vcc.defaultFg = ColorTranslator.FromHtml(glob.para("frm_mdiViewer2__colorDefaultFg", "#000"))
    vcc.defaultBg = ColorTranslator.FromHtml(glob.para("frm_mdiViewer2__colorDefaultBg", "#fff"))
    vcc.defaultFont = New Font(glob.para("frm_mdiViewer2__textDefaultFontFamily", "Arial"), glob.para("frm_mdiViewer2__textDefaultFontSize", "10"), _
         glob.para("frm_mdiViewer2__textDefaultFontStyle", 0), GraphicsUnit.Point)

  End Sub

  Private Sub ImHauptfensterLadenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Dim img As VImage = vcc.canvas.GetFirstSelectedObject()
    loadImage(img.img)
  End Sub

  Private Sub vcc_DirtyChanged() Handles vcc.DirtyChanged
    MDI.refreshFileInfo()
  End Sub

  Private Sub vcc_FileSpecChanged() Handles vcc.FileSpecChanged
    Me.Text = IO.Path.GetFileName(vcc.FileSpec)
    MDI.refreshFileInfo()
  End Sub


  Private Sub vcc_ColorPicked() Handles vcc.ColorPicked
    resetToolboxIfTemporary()
  End Sub

  Private Sub vcc_DefaultColorChanged() Handles vcc.DefaultColorChanged
    Static isRefreshing As Boolean = False '  StackOverflow verhindern
    If isRefreshing Then Exit Sub
    isRefreshing = True
    MDI.pbDefaultBg.Invalidate()
    MDI.pbDefaultFg.Invalidate()
    If vcc.DefaultColorSelected = -1 Then
      frm_paletteColor.GColorPicker1.Enabled = False
    Else
      frm_paletteColor.GColorPicker1.Enabled = True
      '...dies würde zu einem StackOverflow führen, da ColorChanging wieder einen refresh auslöst:
      frm_paletteColor.GColorPicker1.Value = If(vcc.DefaultColorSelected = 1, vcc.defaultFg, vcc.defaultBg)
    End If
    isRefreshing = False
  End Sub


  Sub resetToolboxIfTemporary()
    If Not MDI.toolboxPermanent Then
      vcc.toolboxSelElement = 1
      MDI.refreshToolboxButtonColors()
    End If
  End Sub

  Private Sub vcc_ElementInserted() Handles vcc.ElementInserted
    resetToolboxIfTemporary()
  End Sub

  Private Sub vcc_SelectionChanged(ByVal names() As String) Handles vcc.SelectionChanged
    'If frm_paletteFile.Visible And vcc.canvas.SelectionCount = 1 Then
    '  frm_paletteFile.SelectedObject = vcc.canvas.selectedObjects(0)
    'End If
    'If frm_paletteFile.Visible And vcc.canvas.SelectionCount <> 1 Then
    '  frm_paletteFile.SelectedObject = Nothing
    'End If
    'defaultColorSelected = -1
    'refreshDefaultColorBoxes()

    selNames = names
    MDI.refreshItemList()
    ' cmbElementNames.SelectedIndex = If(canvas.SelectionCount = 1, cmbElementNames.Items.IndexOf(canvas.selectedObjects(0).name), -1)
  End Sub




  Private Sub vcc_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles vcc.DragEnter
    If e.Data.GetDataPresent("FileDrop") Then
      Dim files() As String = e.Data.GetData("FileDrop")
      For Each fileSpec In files
        Dim ext As String = IO.Path.GetExtension(fileSpec).ToUpper
        Select Case ext
          Case ".JPG", ".BMP", ".PNG", ".GIF", ".TIF", ".WMF", ".TXT", ".ICO", ".CUR", ".HTM", ".HTML", ".SGCOLLAGE"
            e.Effect = DragDropEffects.Copy
        End Select
      Next
    End If
  End Sub

  Private Sub vcc_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles vcc.DragDrop
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

          Case ".TXT"
            Dim obj As New VTextbox
            obj.name = "txt_" + IO.Path.GetFileName(fileSpec) + "_" + Now.Ticks.ToString
            obj.Text = IO.File.ReadAllText(fileSpec)
            obj.bounds = New Rectangle(pos.X, pos.Y, 200, 200)
            obj.Font = DefaultFont
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

          Case ".HTM", ".HTML", ".SGCOLLAGE"
            Dim newCanvas As New Vector.Canvas()
            newCanvas.readHtmlPage(fileSpec)
            For i = 0 To newCanvas.objects.Count - 1
              newCanvas.objects(i).isSelected = True
            Next
            newCanvas.OnSelectionChanged()
            newCanvas.groupSelection()
            newCanvas.CopySelection()

            vcc.canvas.Paste()
            Dim b As Rectangle = vcc.canvas.GetFirstSelectedObject().bounds
            b.Location = pos
            vcc.canvas.GetFirstSelectedObject().bounds = b
        End Select
      Next

      vcc.PictureBox1.Refresh()
    End If
  End Sub


End Class