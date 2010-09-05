Public Class frm_viewer
  Dim targetFolder As String = ""

  Private Sub WebBrowser1_CanGoBackChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles WebBrowser1.CanGoBackChanged

    ToolStripButton1.Enabled = WebBrowser1.CanGoBack
  End Sub

  Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
    Dim url = WebBrowser1.Url.ToString
    Dim isPicture As Boolean = url.Length > 25
    ToolStripButton2.Enabled = isPicture
    ToolStripDropDownButton1.Enabled = isPicture
    ToolStripTextBox1.Text = url
  End Sub

  Private Sub WebBrowser1_StatusTextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles WebBrowser1.StatusTextChanged
    tssl1.Text = WebBrowser1.StatusText
  End Sub


  Private Sub frm_viewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    WebBrowser1.Navigate("http://snap.teamwiki.net/")

  End Sub

  Private Sub frm_viewer_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
    ToolStripTextBox1.Width = ToolStrip1.Width - 350

  End Sub

  Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click

    Clipboard.SetText(WebBrowser1.Url.ToString)
  End Sub

  Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
    WebBrowser1.GoBack()
  End Sub

  Private Sub ImHauptfensterÖffnenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImHauptfensterÖffnenToolStripMenuItem.Click

  End Sub
End Class