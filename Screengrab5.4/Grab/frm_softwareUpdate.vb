Public Class frm_softwareUpdate

  Public shutdownOnClose As Boolean
  Dim updateFileSpec As String

  Public Sub startDownload()
    Label1.Text = "ScreenGrab " + updateNewVersion + " ist jetzt verfügbar!"
    updateFileSpec = IO.Path.Combine(IO.Path.GetTempPath(), "screengrab_update_" & Now.Ticks & ".exe")
    BackgroundWorker1.RunWorkerAsync()
  End Sub

  Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
    URLDownloadToFile(IntPtr.Zero, updateDownloadURL, updateFileSpec, 0, IntPtr.Zero)

  End Sub

  Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
    If IO.File.Exists(updateFileSpec) = False Then
      MsgBox("Update konnte nicht heruntergeladen werden.", MsgBoxStyle.Exclamation)
    Else
      ProgressBar1.Hide()
      btnStartInstaller.Show()
      Label2.Text = updateInfoText
    End If
  End Sub

  Private Sub btnStartInstaller_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartInstaller.Click
    Process.Start(updateFileSpec)
    Application.Exit()
    Process.GetCurrentProcess.Kill()
  End Sub

  Private Sub frm_softwareUpdate_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    If shutdownOnClose Then
      Application.Exit()
      Process.GetCurrentProcess.Kill()
    End If
  End Sub

  Private Sub frm_softwareUpdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub
End Class