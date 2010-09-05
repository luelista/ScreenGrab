Public Class frm_paletteFile

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
    MsgBox(dir)
    DriveListBox1.Drive = dir
    DirListBox1.Path = dir

    Dim files() = Split(glob.para("mdiViewer__cursorList"), "|##|")
    For i = 0 To files.Length - 1
      Dim fileSpec As String = files(i)
      If Trim(fileSpec) <> "" Then addPb(fileSpec)
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
        frm_mdiViewer2.canvas.readHtmlPage(fileSpec)
      Else
        Dim img As Image = Image.FromFile(fileSpec)
        frm_mdiViewer2.addPicClient(img, "FILE")
      End If

    End If
  End Sub

  Private Sub ListView2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView2.SelectedIndexChanged

  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    Dim tmp = IO.Path.Combine(IO.Path.GetTempPath, "grab5_collage.htm")
    frm_mdiViewer2.canvas.createHtmlPage(tmp)
    Dim rErrMes As String
    upload_file(tmp, TextBox1.Text, True, "", Now.ToString("yyMMdd-HHmmss"), rErrMes, "htm")
    MsgBox("RESULT:" + vbNewLine + rErrMes)

  End Sub



  Dim pbCount As Integer
  Sub addPb(ByVal filespec As String)
    Dim pb As New PictureBox
    If filespec.EndsWith(".cur") Then
      Dim bmp As New Bitmap(32, 32)
      Dim g = Graphics.FromImage(bmp)
      Try
        Dim c As New Cursor(filespec)
        c.DrawStretched(g, New Rectangle(0, 0, 32, 32))
        c.Dispose()
      Catch ex As Exception
        g.DrawString(ex.Message, New Font("Arial", 6, FontStyle.Regular, GraphicsUnit.Point), Brushes.Black, New Rectangle(0, 0, 32, 32))
      End Try
      g.Dispose()
      pb.Image = bmp

    Else

      pb.Image = New Icon(filespec).ToBitmap
    End If
    pb.Left = (pbCount Mod 3) * 34
    pb.Top = (pbCount \ 3) * 34
    pb.Tag = filespec
    pb.Height = 32 : pb.Width = 32
    AddHandler pb.MouseDown, AddressOf pb_MouseDown
    Me.Controls.Add(pb)
    pbCount += 1
  End Sub

  Private Sub frm_paletteCursor_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
    If e.Data.GetDataPresent("FileDrop") Then
      Dim files() As String = e.Data.GetData("FileDrop")
      For Each filespec In files
        addPb(filespec)
      Next
      saveIconList()
    End If
  End Sub

  Private Sub frm_paletteCursor_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
    If e.Data.GetDataPresent("FileDrop") Then
      e.Effect = DragDropEffects.Link
    End If
  End Sub

  Sub saveIconList()
    Dim out(Me.Controls.Count - 1) As String
    For i = 0 To Me.Controls.Count - 1
      out(i) = Me.Controls(i).Tag
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

  
  Private Sub pb_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    If e.Button = Windows.Forms.MouseButtons.Right Then
      Me.Controls.Remove(sender)
      saveIconList()
    Else

      Dim dobj As New DataObject
      dobj.SetData("FileDrop", New String() {sender.tag})
      Me.DoDragDrop(dobj, DragDropEffects.All)
    End If
  End Sub

  Private Sub pnlIcons_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlIcons.Paint

  End Sub
End Class