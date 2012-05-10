Imports System.Windows.Forms

Public Class frm_tempScreenShotName

  Dim datePart As String
  Dim deltaY As Integer = Me.Height - Me.ClientSize.Height

  Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
    Dim pic As System.Drawing.Image = getCompleteImage()
    If pic Is Nothing Then MsgBox("bitte erst einen Screenshot machen!") : Me.Close()

    glob.para("lastTempUploadPublic") = If(chkPublicListable.Checked, "TRUE", "FALSE")
    glob.para("lastTempUploadName") = TextBox1.Text

    ' Dim url = Label3.Text
    ' If TextBox1.Text = "" Then url = url.Substring(0, url.Length - 1)
    ' url += TextBox1.Text + Label4.Text
    ' txtFullURL.Text = url
    Clipboard.SetText(txtFullURL.Text)

    ViewUpload = True

    Dim tempFile = glob.fp(IO.Path.GetTempPath(), "grab5_temp.png")
    SaveImage(tempFile, pic)

    Dim infoBlock(10) As String
    infoBlock(0) = "mwSG;"
    infoBlock(1) = "screenshot_description1"
    infoBlock(2) = ""
    infoBlock(3) = "http://snap.teamwiki.net" 'txtFullURL.Text
    infoBlock(4) = ""
    infoBlock(5) = My.User.Name
    infoBlock(6) = getDestRect.ToString
    infoBlock(7) = TextBox1.Text
    infoBlock(8) = txtComment.Text
    infoBlock(9) = ""

    IO.File.AppendAllText(tempFile, Join(infoBlock, "|##|"))

    Dim errMes As String
    upload_file(tempFile, TextBox1.Text, True, "", datePart, errMes)

    If errMes.StartsWith("OK") Then
      Try
        My.Computer.Audio.Play("C:\Windows\Media\start.wav")
        glob.para("lastTempUploadOpen") = If(chkOpenInBrowser.Checked, "TRUE", "FALSE")
        If chkOpenInBrowser.Checked Then
          Process.Start(txtFullURL.Text)
        End If
      Catch ex As Exception
        My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Asterisk)
      End Try
    Else
      ViewUpload = False
      MsgBox("Fehler beim Hochladen aufgetreten!" + vbNewLine + errMes, MsgBoxStyle.Exclamation)
      Exit Sub
    End If

    Me.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.Close()
  End Sub

  Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
    glob.para("lastTempUploadOpen") = If(chkOpenInBrowser.Checked, "TRUE", "FALSE")
    glob.para("lastTempUploadPublic") = If(chkPublicListable.Checked, "TRUE", "FALSE")
    glob.para("lastTempUploadName") = TextBox1.Text
    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Close()
  End Sub

  Sub initTempUpload()
    ViewUpload = False
    datePart = Now.ToString("yyMMdd-HHmmss")
    ' Label3.Text = "http://snap.teamwiki.net/" + datePart + "-" + twLoginuser + "-"
    TextBox1.Text = glob.para("lastTempUploadName", "")
    txtComment.Text = ""
    chkOpenInBrowser.Checked = glob.para("lastTempUploadOpen", "TRUE") = "TRUE"
    chkPublicListable.Checked = glob.para("lastTempUploadPublic", "TRUE") = "TRUE"
    updateLink()
    chkShare.Enabled = twLoginfbuid > 0
    chkShare.Checked = False
    Text = "Screenshot temporär hochladen ..."
    Me.ShowDialog()
  End Sub

  Property ViewUpload() As Boolean
    Get

    End Get
    Set(ByVal value As Boolean)
      PictureBox3.Visible = value
      ' FlowLayoutPanel1.Visible = Not value
      TextBox1.Enabled = Not value
      txtComment.Enabled = Not value
      chkPublicListable.Enabled = Not value
      chkShare.Enabled = twLoginfbuid > 0 And Not value
      ' txtFullURL.Visible = value
      OK_Button.Visible = Not value
      ProgressBar1.Visible = value

      If value Then
        PictureBox3.BringToFront()
        ProgressBar1.BringToFront()
      Else

      End If
    End Set
  End Property

  Private Sub frm_tempScreenShotName_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
    'If FlowLayoutPanel1.Visible Then
    TextBox1.Focus()

    'End If
  End Sub

  Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
    If Char.IsControl(e.KeyChar) Then Exit Sub
    If Char.IsUpper(e.KeyChar) Then
      e.KeyChar = Char.ToLower(e.KeyChar)
    End If
    If (Char.IsLetterOrDigit(e.KeyChar) = False And e.KeyChar <> "."c) Or e.KeyChar > Chr(128) Then
      e.KeyChar = "-"c
    End If
  End Sub

  Private Sub FlowLayoutPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

  End Sub


  Private Sub chkCopyPageLink_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOpenInBrowser.CheckedChanged
    updateLink()
  End Sub
  Sub updateLink()
    txtFullURL.Text = "http://snap.teamwiki.net/image/" + datePart + "-" + twLoginuser + "-" + TextBox1.Text
  End Sub

  Private Sub frm_tempScreenShotName_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub

  Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
    updateLink()
  End Sub
End Class
