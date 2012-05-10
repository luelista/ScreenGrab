Public Class frm_uploadingMulti


  Private _working As Integer
  Public Property WorkingItems() As Integer
    Get
      Return _working
    End Get
    Set(ByVal value As Integer)
      _working = value
      Button1.Enabled = _working = 0
      Button2.Enabled = _working = 0

    End Set
  End Property


  Private Sub frm_uploadingMulti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    glob.readFormPos(Me)
  End Sub

  Private Sub URLKopierenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles URLKopierenToolStripMenuItem.Click
    Clipboard.Clear()
    Clipboard.SetText(ListView1.SelectedItems(0).SubItems(1).Text)
  End Sub

  Private Sub openExplorerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles openExplorerToolStripMenuItem.Click
    Process.Start("explorer.exe", "/select," + ListView1.SelectedItems(0).Tag)
  End Sub

  Private Sub openBrowserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles openBrowserToolStripMenuItem.Click
    Process.Start(ListView1.SelectedItems(0).SubItems(1).Text)
  End Sub

  Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    ListView1.Items.Clear()
    ImageList1.Images.Clear()
  End Sub

  Private Sub ListView1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseUp
    If e.Button = Windows.Forms.MouseButtons.Right Then
      Dim it = ListView1.GetItemAt(e.X, e.Y)
      If it IsNot Nothing Then
        it.Selected = True
        ContextMenuStrip1.Show(sender, e.Location)
      End If
    End If
    
  End Sub

  Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    Me.Hide()
    glob.saveFormPos(Me)
    glob.saveParaFile()
  End Sub
End Class