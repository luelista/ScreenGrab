Imports System.Windows.Forms

Public Class frm_fbLogin

  Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Me.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.Close()
  End Sub

  Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Close()
  End Sub

  Private Sub frm_fbLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Label1.Show()
    Label1.Text = "Bitte warten ..."
    WebBrowser1.Navigate("https://www.facebook.com/dialog/oauth?client_id=109707115775453&redirect_uri=https://www.facebook.com/connect/login_success.html&scope=publish_stream,offline_access,user_photos,manage_pages&response_type=token&display=popup")

  End Sub

  Private Sub WebBrowser1_DocumentCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
    If e.Url.LocalPath = "/connect/login_success.html" Then

      'MsgBox(e.Url.ToString)
      If e.Url.Fragment.StartsWith("#access_token") Then
        Label1.Show()
        Label1.Text = "Verbunden. Bitte warten ..."
        glob.para("facebook_access_token_2") = e.Url.Fragment.Substring(1)
        Application.DoEvents()
        Threading.Thread.Sleep(1000)
        Close()
      Else
        Label1.Show()
        Label1.Text = "Fehler. Fenster wird geschlossen ..."
        Application.DoEvents()
        Threading.Thread.Sleep(1000)
        Close()
      End If
    Else
      Label1.Hide()
    End If
  End Sub
End Class
