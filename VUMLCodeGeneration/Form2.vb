Public Class Form2

  Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
    Me.Close()
  End Sub

  Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
    If e.Node IsNot Nothing AndAlso e.Node.Tag IsNot Nothing AndAlso TypeOf e.Node.Tag Is scriptHelperFile Then
      RichTextBox1.Text = DirectCast(e.Node.Tag, scriptHelperFile).ToString()
      Me.Text = e.Node.Text + " - VUMLCodeGeneration Result"
    End If
  End Sub

  Private Sub Form2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    Application.Exit()
  End Sub

  Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    TreeView1.Nodes(0).Expand()

  End Sub
End Class