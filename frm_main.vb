Imports System.Windows.Forms

Public Class frm_main

  Private Sub ToolStripButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
    openGrabWindow()

  End Sub

  Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
    ActiveImage_saveToFile()
  End Sub

  Private Sub ToolStripButton5_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.ButtonClick, BildUploadenToolStripMenuItem.Click
    ActiveImage_upload()

  End Sub

  Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
    If Clipboard.ContainsImage Then
      showNewForm().BackgroundImage = Clipboard.GetImage
      If AutoUpload Then ActiveImage_upload()
    End If
  End Sub

  Private Sub EinstellungenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EinstellungenToolStripMenuItem.Click
    'frm_settings.ShowDialog()

  End Sub

  Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
    ActiveImage_copyToClip()
  End Sub

  Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
    Dim result As System.Windows.Forms.DialogResult
    Dim fileSpec As String
    With OpenFileDialog1
      .Title = "Datei ins Screengrab-Fenster öffnen ..."
      result = .ShowDialog()
      fileSpec = .FileName
    End With
    If result = Windows.Forms.DialogResult.OK Then
      Dim img As Image = Image.FromFile(fileSpec)
      showNewForm().BackgroundImage = img
      If AutoUpload Then ActiveImage_upload()
    End If

  End Sub

  Private Sub ToolStripLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    System.Diagnostics.Process.Start("http://develop.teamwiki.de/screengrab_2_0.html")
  End Sub

  Private Sub frm_main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    'Dim resHwnd As Long = _
    'FindWindow(vbNullString, "* ScreenGrab 2.0")

    Status = ""

    
  End Sub

  Private Sub tmrResetStatus_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrResetStatus.Tick
    Status = ""
    tmrResetStatus.Enabled = False

  End Sub

  Private Sub AutoUploadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoUploadToolStripMenuItem.Click
    sender.checked = Not sender.checked
    AutoUpload = sender.checked
  End Sub

  Private Sub ToolStripLabel4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripLabel4.Click
    System.Diagnostics.Process.Start("http://teamwiki.de/twiki/test/sgf_move.php")
  End Sub

  Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
    showNewTextForm()

  End Sub

  Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click
    AboutBox1.ShowDialog()

  End Sub

  Private Sub AusloggenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AusloggenToolStripMenuItem.Click
    Status = "ausgeloggt"
    resetStatusAfter3Seconds()
    labStatLogin.Text = "Ausgeloggt."
    AusloggenToolStripMenuItem.Enabled = False
  End Sub

  Private Sub ImageChatUploadToolStripDropDownButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoUploadToolStripDropDownButton.ButtonClick, Imagechat_AutoUploadToolStripMenuItem.Click
    'ic
    ActiveImage_uploadToImgChat()

  End Sub

  Private Sub UploadToImageChatToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadToImageChatToolStripMenuItem.Click
    sender.checked = Not sender.checked
    AutoUpload2 = sender.checked
  End Sub
End Class
