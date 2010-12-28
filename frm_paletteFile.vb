Imports ScreenGrab5.Vector

Public Class frm_paletteFile


#Region "Properties"

  Private selObj As Vector.VObject
  Public Property SelectedObject() As Vector.VObject
    Get
      Return selObj
    End Get
    Set(ByVal value As Vector.VObject)
      selObj = Nothing
      If value Is Nothing Then
        pnlProperties.Enabled = False
        Exit Property
      End If
      pnlProperties.Enabled = True

      txtName.Text = value.name
      ComboBox1.Text = value.name
      txtType.Text = value.GetType.Name

      nudX.Value = value.bounds.X
      nudY.Value = value.bounds.Y
      nudXX.Value = value.bounds.Width
      nudYY.Value = value.bounds.Height

      If value.borderPen Is Nothing Then
        nudBorderWidth.Value = 0
        txtBorderColor.Text = ""
      Else
        nudBorderWidth.Value = value.borderPen.Width
        txtBorderColor.Text = "#" + Helper.Color2String(value.borderPen.Color)
      End If

nudRotation.Value=value.rotation

      If TypeOf value Is Vector.VTextbox Then
        pnlFont.Enabled = True
        Dim vt As Vector.VTextbox = value
        Label10.Font = vt.fnt
        If TypeOf vt.brsh Is SolidBrush Then
          Label10.ForeColor = DirectCast(vt.brsh, SolidBrush).Color
          txtTextColor.Text = "#" + Helper.Color2String(DirectCast(vt.brsh, SolidBrush).Color)
        End If
      Else
        pnlFont.Enabled = False
      End If


      selObj = value
    End Set
  End Property

  Private m_Canvas As Vector.Canvas
  Public Property MyCanvas() As Vector.Canvas
    Get
      Return m_Canvas
    End Get
    Set(ByVal value As Vector.Canvas)
      m_Canvas = value
    End Set
  End Property


  Sub RefreshItemList()
    ComboBox1.Items.Clear()
    For Each itm In m_Canvas.objects
      ComboBox1.Items.Add(Trim(itm.name))
    Next

  End Sub

  Private Sub frm_paletteProperties_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    e.Cancel = True
    Me.Hide()
    frm_mdiViewer2.repositionPaletteWindows()
  End Sub
  Private Sub frm_paletteProperties_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
    frm_mdiViewer2.repositionPaletteWindows()
  End Sub
  Private Sub frm_paletteProperties_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub

  Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
    If selObj Is Nothing Or m_Canvas Is Nothing Then Exit Sub
    selObj.name = txtName.Text
  End Sub

  Private Sub nudXY_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
  Handles nudYY.ValueChanged, nudY.ValueChanged, nudXX.ValueChanged, nudX.ValueChanged
    If selObj Is Nothing Or m_Canvas Is Nothing Then Exit Sub
    selObj.bounds = New Rectangle(nudX.Value, nudY.Value, nudXX.Value, nudYY.Value)
    m_Canvas.Invalidate()
  End Sub

  Private Sub txtBorderColor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
  Handles txtBorderColor.TextChanged, nudBorderWidth.ValueChanged
    If selObj Is Nothing Or m_Canvas Is Nothing Then Exit Sub
    Try
      selObj.setBorder(nudBorderWidth.Value, ColorTranslator.FromHtml(txtBorderColor.Text))
      m_Canvas.Invalidate()
    Catch ex As Exception
    End Try
  End Sub
  
  Private Sub nudRotation_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudRotation.ValueChanged
    If selObj Is Nothing Or m_Canvas Is Nothing Then Exit Sub
    selObj.rotation = nudRotation.Value
    m_Canvas.Invalidate()
  End Sub

  Private Sub btnFormat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFormat.Click
    Dim oldFont As Font
    Dim vt As Vector.VTextbox = DirectCast(selObj, Vector.VTextbox)
    FontDialog1.Font = vt.fnt
    oldFont = vt.fnt
    If FontDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
      vt.fnt = FontDialog1.Font
    Else
      vt.fnt = oldFont
    End If
    m_Canvas.Invalidate()
  End Sub

  Private Sub FontDialog1_Apply(ByVal sender As Object, ByVal e As System.EventArgs) Handles FontDialog1.Apply

  End Sub

  Private Sub btnText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnText.Click
    m_Canvas.showTextEditor(selObj, False)
  End Sub

  Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
    Dim obj = frm_mdiViewer2.canvas.GetObjectByID(ComboBox1.SelectedItem)
    If obj Is Nothing Then
      RefreshItemList()
      Exit Sub
    End If
    frm_mdiViewer2.canvas.SelectObject(obj)
  End Sub

  Private Sub txtTextColor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTextColor.TextChanged
    If selObj Is Nothing Or m_Canvas Is Nothing Then Exit Sub
    Dim vt As Vector.VTextbox = DirectCast(selObj, Vector.VTextbox)
    Try
      vt.brsh = New SolidBrush(ColorTranslator.FromHtml(txtTextColor.Text))
      m_Canvas.Invalidate()
    Catch : End Try
  End Sub

  Private Sub btnTextColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTextColor.Click
    ColorDialog1.Color = ColorTranslator.FromHtml(txtTextColor.Text)
    If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
      txtTextColor.Text = "#" + Helper.Color2String(ColorDialog1.Color)
    End If
  End Sub

  Private Sub btnCanvasColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCanvasColor.Click
    ColorDialog1.Color = frm_mdiViewer2.canvas.PicBox.BackColor
    If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
      frm_mdiViewer2.canvas.PicBox.BackColor = ColorDialog1.Color
    End If
  End Sub
#End Region








  Dim localFolder As String

  Private Sub frm_paletteFile_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    e.Cancel = True
    Me.Hide()
    frm_mdiViewer2.repositionPaletteWindows()
  End Sub
  Private Sub frm_paletteFile_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
    frm_mdiViewer2.repositionPaletteWindows()
  End Sub

  Private Sub DriveListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DriveListBox1.SelectedIndexChanged
    Try
      DirListBox1.Path = DriveListBox1.Drive
    Catch ex As Exception

    End Try
  End Sub

  Private Sub DirListBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DirListBox1.DoubleClick

    localFolder = DirListBox1.Path
    glob.para("paletteFile__localFolder") = localFolder
    refreshLocalFilelist()
  End Sub

  Private Sub DirListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DirListBox1.SelectedIndexChanged

  End Sub

  Sub refreshLocalFilelist()
    Dim files() As String = IO.Directory.GetFiles(localFolder)

    ListView2.Items.Clear()
    For Each fileSpec As String In files
      Dim ext As String = IO.Path.GetExtension(fileSpec).ToUpper
      Dim ftype As String = ""
      If ext = ".JPG" Or ext = ".GIF" Or ext = ".BMP" Or ext = ".PNG" Then
        ftype = "image"
      End If
      If ext = ".HTM" Or ext = ".HTML" Then
        ftype = "collage"
      End If

      If ftype <> "" Then
        Dim lvi = ListView2.Items.Add(IO.Path.GetFileName(fileSpec))
        lvi.ImageKey = ftype
        lvi.Tag = fileSpec
      End If
    Next

  End Sub

  Private Sub frm_paletteFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    glob.readFormPos(Me)

    Dim dir = glob.para("paletteFile__localFolder")
    'MsgBox(dir)
    Try
      DriveListBox1.Drive = dir
      DirListBox1.Path = dir
    Catch ex As Exception
      MsgBox("Ordner konnte nicht geöffnet werden." + vbNewLine + ex.Message)
    End Try

    loadIconList()
    loadWebFilelist()
  End Sub

  Sub loadWebFilelist()
    ListView1.Items.Clear()
    Dim fileListResult = TwAjax.getUrlContent("http://snap.teamwiki.net/?format=vbfriendly")
    Dim fileList() = Split(fileListResult, vbNewLine)
    'echo "$type\t$date\t$size\t$user\t$desc\t$f\r\n";
    For Each item In fileList
      Dim parts() = Split(item, vbTab)
      If parts.Length < 5 Then Continue For
      ListView1.Items.Add(parts(5), parts(0))
    Next
  End Sub

  Private Sub btnSaveLocal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveLocal.Click
    Using sfd As New SaveFileDialog
      sfd.Title = "Collage exportieren ..."
      sfd.Filter = "HTML-Dateien (*.htm, *.html)|*.html;*.htm|Alle Dateien|*.*"
      sfd.AddExtension = True
      sfd.InitialDirectory = localFolder
      If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
        frm_mdiViewer2.canvas.createHtmlPage(sfd.FileName)
      End If
    End Using
  End Sub

  Private Sub ListView2_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView2.MouseDoubleClick
    If ListView2.SelectedItems.Count = 1 Then

      Dim fileSpec As String = ListView2.SelectedItems(0).Tag

      If ListView2.SelectedItems(0).ImageKey = "collage" Then
        frm_mdiViewer2.canvas.objects.Clear()
        frm_mdiViewer2.canvas.readHtmlPage(fileSpec)
      Else
        Dim img As Image = Image.FromFile(fileSpec)
        frm_mdiViewer2.addPicClient(img, "FILE")
      End If

    End If
  End Sub

  Private Sub ListView2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView2.SelectedIndexChanged

  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveWeb.Click
    Dim tmp = IO.Path.Combine(IO.Path.GetTempPath, "grab5_collage.htm")
    frm_mdiViewer2.canvas.createHtmlPage(tmp)
    Dim rErrMes As String
    upload_file(tmp, TextBox1.Text, True, "", Now.ToString("yyMMdd-HHmmss"), rErrMes, "htm")
    MsgBox("RESULT:" + vbNewLine + rErrMes)

  End Sub



  Dim pbCount As Integer
  Sub addPb(ByVal filespec As String)
    ' Dim pb As New PictureBox
    If imlIconInsert.Images.ContainsKey(filespec) = False Then
      Try
        If filespec.EndsWith(".cur") Then
          Dim bmp As New Bitmap(32, 32)
          Dim g = Graphics.FromImage(bmp)
          Dim c As New Cursor(filespec)
          c.DrawStretched(g, New Rectangle(0, 0, 32, 32))
          c.Dispose()
          g.Dispose()
          '  pb.Image = bmp
          imlIconInsert.Images.Add(filespec, bmp)
        ElseIf filespec.EndsWith(".ico") Then
          '  pb.Image = New Icon(filespec).ToBitmap
          imlIconInsert.Images.Add(filespec, New Icon(filespec).ToBitmap)
        Else
          imlIconInsert.Images.Add(filespec, Image.FromFile(filespec))
        End If
      Catch ex As Exception
        Try
          Dim bmp As New Bitmap(32, 32)
          Dim g = Graphics.FromImage(bmp)
          g.DrawString(ex.Message, New Font("Arial", 6, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, New Rectangle(0, 0, 32, 32))
          g.Dispose()
          imlIconInsert.Images.Add(filespec, bmp)
        Catch : End Try
      End Try
    End If

    Dim lvi As ListViewItem = ListView3.Items.Add(filespec, IO.Path.GetFileName(filespec), filespec)
    'pb.Left = (pbCount Mod 3) * 34
    'pb.Top = (pbCount \ 3) * 34
    'pb.Tag = filespec
    'pb.Height = 32 : pb.Width = 32
    '  AddHandler pb.MouseDown, AddressOf pb_MouseDown
    ' Me.Controls.Add(pb)
    ' pbCount += 1
  End Sub

  Private Sub listview3_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListView3.DragDrop
    If e.Data.GetDataPresent("FileDrop") Then
      Dim files() As String = e.Data.GetData("FileDrop")
      For Each filespec In files
        addPb(filespec)
      Next
      saveIconList()
    End If
  End Sub

  Private Sub listview3_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListView3.DragEnter
    If e.Data.GetDataPresent("FileDrop") Then
      e.Effect = DragDropEffects.Link
    End If
  End Sub

  Sub saveIconList()
    Dim out(Me.Controls.Count - 1) As String
    For i = 0 To ListView3.Items.Count - 1
      out(i) = ListView3.Items(i).Name
    Next
    glob.para("mdiViewer__cursorList") = Join(out, "|##|")
  End Sub

  Private Sub frm_paletteCursor_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    e.Cancel = True
    Me.Hide()
    glob.saveFormPos(Me)
    frm_mdiViewer2.repositionPaletteWindows()
  End Sub
  Private Sub frm_paletteCursor_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
    frm_mdiViewer2.repositionPaletteWindows()
  End Sub


  Private Sub ListView3_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles ListView3.ItemDrag

    Dim dobj As New DataObject
    dobj.SetData("FileDrop", New String() {e.Item.name})
    Me.DoDragDrop(dobj, DragDropEffects.All)
  End Sub

  Private Sub ListView3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView3.SelectedIndexChanged

  End Sub

  Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
    Using ofd As New OpenFileDialog
      ofd.Filter = "Unterstützte Formate (*.png, *.ico, *.bmp, *.cur, *.gif, *.jpg)|*.png;*.ico;*.bmp;*.cur;*.gif;*.jpg|Alle Dateien|*.*"
      ofd.Multiselect = True
      If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
        For Each fn In ofd.FileNames
          addPb(fn)
        Next
        saveIconList()
      End If
    End Using
  End Sub

  Sub loadIconList()
    ListView3.Items.Clear()
    Select Case TabControl2.SelectedIndex
      Case 1
        Dim files() = Split(glob.para("mdiViewer__cursorList"), "|##|")
        For i = 0 To files.Length - 1
          Dim fileSpec As String = files(i)
          If Trim(fileSpec) <> "" Then addPb(fileSpec)
        Next

      Case 0
        Dim files() = IO.Directory.GetFiles(settingsFolder + "IconCache\", "*", IO.SearchOption.AllDirectories)
        Dim checkFor = "|.png|.ico|.bmp|.cur|.gif|.jpg|"
        Dim searchFor() As String = Split(TextBox2.Text.ToLower, " ")
        For i = 0 To files.Length - 1
          Dim fileSpec As String = files(i)
          Dim lowerFS = fileSpec.ToLower
          For Each sf In searchFor
            If lowerFS.Contains(sf) = False Then GoTo continueOuterFor
            ' der unterstützt kein Continue For(outer)
          Next
          If checkFor.Contains(IO.Path.GetExtension(lowerFS)) Then
            If Trim(fileSpec) <> "" Then addPb(fileSpec)
          End If

continueOuterFor:
        Next


    End Select
  End Sub

  Private Sub TabControl2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl2.SelectedIndexChanged
    loadIconList()
  End Sub

  Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
    Try
      Me.Enabled = False
      Me.Cursor = Cursors.WaitCursor
      Label4.Visible = True
      Label4.Text = "Bitte warten ..."
      Dim fileListResult As String = TwAjax.getUrlContent("http://ajax.teamwiki.net/php/vb/dirlist.php?mode=dirlist&dir=userdata/vbnet/webspace/screengrab_iconlib&dummy=" & Now.Ticks)
      Dim fileList() = Split(fileListResult, vbNewLine)

      For Each file In fileList
        Dim parts() = Split(file, vbTab)
        If parts.Length < 3 Then Continue For
        Dim fileName = parts(1)
        Dim locFileSpec = settingsFolder + "IconCache\" + fileName
        If IO.File.Exists(locFileSpec) = False Then


        End If
      Next

      For Each file In fileList
        Dim parts() = Split(file, vbTab)
        If parts.Length < 3 Then Continue For
        Dim fileName = parts(1)
        Dim locFileSpec = settingsFolder + "IconCache\" + fileName
        If IO.File.Exists(locFileSpec) = False Then
          'download...

          Dim url = "http://vbnet.teamwiki.net/docs/screengrab_iconlib/" + fileName
          Label4.Text = "URL Download: " + vbNewLine + url
          Application.DoEvents()

          URLDownloadToFile(IntPtr.Zero, url, locFileSpec, 0, IntPtr.Zero)



        End If
      Next
    Catch ex As Exception
      MsgBox("Fehler beim Downloaden der Screengrab-Iconlibrary" + vbNewLine + ex.Message, MsgBoxStyle.Exclamation)
    Finally
      Me.Enabled = True
      Me.Cursor = Cursors.Default
      Label4.Hide()
    End Try
  End Sub



  Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
    loadIconList()
  End Sub

  Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
    If ListView1.SelectedItems.Count <> 1 Then Exit Sub
    Try
      Dim fileName = ListView1.SelectedItems(0).Text
      Dim locFS = IO.Path.Combine(IO.Path.GetTempPath, "grab5_dlfile.tmp")
      Dim url = "http://snap.teamwiki.net/" + fileName
      URLDownloadToFile(IntPtr.Zero, url, locFS, 0, IntPtr.Zero)
      If fileName.EndsWith(".htm") Then
        frm_mdiViewer2.canvas.readHtmlPage(locFS)
      Else
        Dim fs As New IO.FileStream(locFS, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.ReadWrite)
        frm_mdiViewer2.addPicClient(New Bitmap(fs), "SNAP-DIR")
        fs.Close()
      End If
    Catch ex As Exception
      MsgBox("Element konnte nicht geöffnet werden: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Sub

  Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
    btnLoadWeb.Enabled = False
    If ListView1.SelectedItems.Count <> 1 Then Exit Sub

    If ListView1.SelectedItems(0).Text.EndsWith(".htm") Then btnLoadWeb.Enabled = True
  End Sub

  Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadWeb.Click
    If ListView1.SelectedItems.Count <> 1 Then Exit Sub
    Try
      frm_mdiViewer2.canvas.objects.Clear()
      Dim fileName = ListView1.SelectedItems(0).Text
      Dim locFS = IO.Path.Combine(IO.Path.GetTempPath, "grab5_dlfile.tmp")
      Dim url = "http://snap.teamwiki.net/" + fileName
      URLDownloadToFile(IntPtr.Zero, url, locFS, 0, IntPtr.Zero)
      frm_mdiViewer2.canvas.readHtmlPage(locFS)
    Catch ex As Exception
      MsgBox("Element konnte nicht geöffnet werden: " + ex.Message, MsgBoxStyle.Exclamation)
    End Try
  End Sub

End Class