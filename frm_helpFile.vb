Public Class frm_helpFile

  Private Sub frm_helpFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    WebBrowser1.Navigate("http://snap.teamwiki.net/screengrab_help.php?lang=de&user=" + My.User.Name)

  End Sub

  Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

  End Sub

  Private Sub WebBrowser1_StatusTextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles WebBrowser1.StatusTextChanged
    tssl1.Text = WebBrowser1.StatusText
  End Sub
End Class