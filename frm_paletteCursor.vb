Public Class frm_paletteCursor
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
    frm_mdiViewer2.repositionPaletteWindows()
  End Sub
  Private Sub frm_paletteCursor_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
    frm_mdiViewer2.repositionPaletteWindows()
  End Sub

  Private Sub frm_paletteCursor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim files() = Split(glob.para("mdiViewer__cursorList"), "|##|")
    For i = 0 To files.Length - 1
      Dim fileSpec As String = files(i)
      If Trim(fileSpec) <> "" Then addPb(fileSpec)
    Next
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

End Class