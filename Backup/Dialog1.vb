Imports System.Windows.Forms

Public Class Dialog1


    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

  Private Sub Dialog1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    WebBrowser1.Navigate("http://teamwiki.de/twiki/external_auth.php?df=screengrab2.0&dv=5")

  End Sub

  Private Sub WebBrowser1_DocumentCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
    Dim url As String = e.Url.AbsoluteUri
    Dim io As Integer = url.IndexOf("/-/")
    If io > -1 Then
      Dim parts() As String = Split(url, "/-/")
      If parts(1) = "ok" Then
        m_Username = parts(2)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
        Status = "Eingeloggt als " + m_Username
        frm_main.labStatLogin.Text = m_Username
        frm_main.AusloggenToolStripMenuItem.Enabled = True
        resetStatusAfter3Seconds()
      ElseIf parts(1) = "error" Then
        MsgBox("Fehlerhafte Logindaten!")
        Status = "Fehlerhafte Logindaten!"
        frm_main.labStatLogin.Text = "Ausgeloggt."
        resetStatusAfter3Seconds()
        frm_main.AusloggenToolStripMenuItem.Enabled = False
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
      ElseIf parts(1) = "openwin" Then
        If parts(2) = "homepage" Then
          System.Diagnostics.Process.Start("http://develop.teamwiki.de/screengrab_2_0.html")
          If MsgBox("Soll das Programm jetzt beendet werden?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Update") _
              = MsgBoxResult.Yes Then System.Environment.Exit(55)
          Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
          Me.Close()
        End If
      Else
        MsgBox("Sorry, es ist ein interner Serverfehler aufgetreten!")
        Status = "Fehlerhafte Logindaten oder Serverfehler!"
        resetStatusAfter3Seconds()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
      End If
    End If

  End Sub
End Class
