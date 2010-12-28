Public Class LoginForm1


  Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
    lblWronglogin.Visible = False
    Me.Enabled = False
    If doLogin(UsernameTextBox.Text, PasswordTextBox.Text, False) Then
      Me.Enabled = True
      DialogResult = Windows.Forms.DialogResult.OK
    Else
      lblWronglogin.Visible = True
      Application.DoEvents()
      Threading.Thread.Sleep(900)
      Me.Enabled = True
      PasswordTextBox.Text = "" : PasswordTextBox.Focus()
    End If


  End Sub

  Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
    DialogResult = Windows.Forms.DialogResult.Cancel
  End Sub

  Private Sub LoginForm1_HelpButtonClicked(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked
    e.Cancel = True
    ' If helpfilePath = "" Then MsgBox("Hilfedatei nicht gefunden!", MsgBoxStyle.Critical, "Fehler") : Exit Sub
    ' Help.ShowHelp(Me, helpfilePath, "mwupd3-upload/login.htm")
  End Sub

  Private Sub LoginForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    If glob.para("user") = "" Then
      '  btnLogoff.Enabled = False

    End If
  End Sub

  Private Sub btnLogoff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    
  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    doLogin(OFFLINE_USER, Nothing, False)
    DialogResult = Windows.Forms.DialogResult.OK
  End Sub
End Class
