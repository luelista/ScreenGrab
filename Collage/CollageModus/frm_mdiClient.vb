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
    
  End Sub

  Private Sub ImHauptfensterLadenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Dim img As VImage = vcc.canvas.GetFirstSelectedObject()
    Dim tmpFilespec As String = IO.Path.Combine(IO.Path.GetTempPath, "SgCollage-to-ScreenGrab.png")
    img.img.Save(tmpFilespec, System.Drawing.Imaging.ImageFormat.Png)
    '  loadImage(img.img)
    oIntWin.SendCommand("grab5", "Load", tmpFilespec)
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
      If isKeyPressed(Keys.Menu) Then
        e.Effect = DragDropEffects.Link
      Else

        Dim files() As String = e.Data.GetData("FileDrop")
        For Each fileSpec In files
          Dim ext As String = IO.Path.GetExtension(fileSpec).ToUpper
          Select Case ext
            Case ".JPG", ".BMP", ".PNG", ".GIF", ".TIF", ".WMF", ".TXT", ".ICO", ".CUR", ".HTM", ".HTML", ".SGCOLLAGE"
              e.Effect = DragDropEffects.Copy
          End Select
        Next
      End If
    Else 'If e.Data.GetDataPresent(DataFormats.Text) Then
      ' e.Effect = DragDropEffects.Copy

    End If
  End Sub

  Function insertShortcut(ByVal filespec As String) As VGroup
    vcc.canvas.DeselectAll()

    'Dim border As New VRectangle
    'border.bounds = New Rectangle(0, 0, 64, 64)
    'border.BorderWidth = 2
    'border.Color1 = Color.Gray
    'border.isSelected = True
    'vcc.canvas.addObject(border)

    Dim icon As New VImage
    icon.bounds = New Rectangle(14, 5, 32, 32)
    icon.img = GetAssociatedIconAsImage(filespec, assoc_iconSize.SHGFI_LARGEICON)
    icon.isSelected = True
    vcc.canvas.addObject(icon)

    Dim txt As New VTextbox
    txt.bounds = New Rectangle(5, 40, 55, 20)
    txt.Color1 = Color.DarkBlue
    txt.Text = IO.Path.GetFileName(filespec)
    txt.Font = New Font("Microsoft Sans Serif", 7, FontStyle.Regular, GraphicsUnit.Point)
    txt.isSelected = True
    vcc.canvas.addObject(txt)

    vcc.canvas.OnSelectionChanged()
    vcc.canvas.groupSelection()

    Dim shortcut As VGroup = vcc.canvas.GetFirstSelectedObject
    shortcut.onevent("ondblclick") = "window.shellExecute(""" + filespec.Replace("\", "\\").Replace("""", "\""") + """);"

    Return shortcut
  End Function

  Private Sub vcc_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles vcc.DragDrop
    Dim pos As Point = vcc.PictureBox1.PointToClient(New Point(e.X, e.Y))
    If e.Data.GetDataPresent("FileDrop") Then
      Dim files() As String = e.Data.GetData("FileDrop")
      If isKeyPressed(Keys.Menu) Then
        Dim fileSpec As String = files(0)
        Dim shortcut As VGroup = insertShortcut(fileSpec)

        shortcut.Left = pos.X - 20
        shortcut.Top = pos.Y - 30

      Else

        For Each fileSpec In files
          Dim ext As String = IO.Path.GetExtension(fileSpec).ToUpper
          Select Case ext
            Case ".JPG", ".BMP", ".PNG", ".GIF", ".TIF", ".WMF"
              Dim obj As New VImage
              obj.name = "img_" + IO.Path.GetFileName(fileSpec) + "_" + Now.Ticks.ToString
              obj.img = Image.FromFile(fileSpec)
              obj.source = "FILE:" + fileSpec
              Dim xx As Integer = obj.img.Width, yy As Integer = obj.img.Height
              If xx > Math.Min(Width, vcc.PictureBox1.Width) Then xx = Math.Min(Width, vcc.PictureBox1.Width) - 100 : yy *= xx / obj.img.Width
              obj.bounds = New Rectangle(pos.X, pos.Y, xx, yy)
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
              If newCanvas.SelectionCount > 1 Then newCanvas.groupSelection()
              newCanvas.CopySelection()

              vcc.canvas.Paste()
              Dim b As Rectangle = vcc.canvas.GetFirstSelectedObject().bounds
              b.Location = pos
              vcc.canvas.GetFirstSelectedObject().bounds = b
          End Select
        Next

      End If

    Else
      Dim tx = ""
      For Each typ In e.Data.GetFormats
        tx += "-" + typ + vbNewLine
        Try : tx += e.Data.GetData(typ) + vbNewLine : Catch : tx += "xxxx" + vbNewLine : End Try
      Next
      Dim obj As New VTextbox
      obj.name = "txt_" + Now.Ticks.ToString
      obj.Text = tx
      obj.bounds = New Rectangle(pos.X, pos.Y, 200, 200)
      obj.Font = DefaultFont
      'obj.setBorder(2, Color.RoyalBlue)
      vcc.canvas.addObject(obj)

    End If
    vcc.PictureBox1.Refresh()
  End Sub


End Class