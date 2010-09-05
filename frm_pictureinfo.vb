Public Class frm_pictureinfo

  Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
    Me.Close()

  End Sub

  Private Sub tsbGetfilesize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGetfilesize.Click
    frm_blueScreen.showpicinfo()

  End Sub

  Private Sub frm_pictureinfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub
End Class