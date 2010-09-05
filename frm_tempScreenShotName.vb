Imports System.Windows.Forms

Public Class frm_tempScreenShotName

  Dim datePart As String
  Dim deltaY As Integer = Me.Height - Me.ClientSize.Height

  Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
    Dim pic As System.Drawing.Image = getCompleteImage()
    If pic Is Nothing Then MsgBox("bitte erst einen Screenshot machen!") : Me.Close()

    glob.para("lastTempUploadLink") = If(chkCopyPageLink.Checked, "PAGE", "IMAGE")
    glob.para("lastTempUploadName") = TextBox1.Text

    Dim url = Label3.Text
    If TextBox1.Text = "" Then url = url.Substring(0, url.Length - 1)
    url += TextBox1.Text + Label4.Text
    txtFullURL.Text = url
    Clipboard.SetText(url)

    ViewUpload = True

    Dim tempFile = glob.fp(IO.Path.GetTempPath(), "grab5_temp.png")
    SaveImage(tempFile, pic)

    Dim infoBlock(10) As String
    infoBlock(0) = "mwSG;"
    infoBlock(1) = "screenshot_description1"
    infoBlock(2) = ""
    infoBlock(3) = url
    infoBlock(4) = ""
    infoBlock(5) = My.User.Name
    infoBlock(6) = getDestRect.ToString
    infoBlock(7) = TextBox1.Text
    infoBlock(8) = txtComment.Text
    infoBlock(9) = ""

    IO.File.AppendAllText(tempFile, Join(infoBlock, "|##|"))
    ' IO.File.AppendAllText(tempFile, "mwSC;|##|screenshot_comment1|##||##|")'


    Dim errMes As String
    upload_file(tempFile, TextBox1.Text, True, "", datePart, errMes)

    If errMes.StartsWith("OK") Then
      My.Computer.Audio.Play("C:\Windows\Media\start.wav")
    Else
      ViewUpload = False
      MsgBox("Fehler beim Hochladen aufgetreten!" + vbNewLine + errMes, MsgBoxStyle.Exclamation)
      Exit Sub
    End If

    Me.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.Close()
  End Sub

  Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
    glob.para("lastTempUploadLink") = If(chkCopyPageLink.Checked, "PAGE", "IMAGE")
    glob.para("lastTempUploadName") = TextBox1.Text
    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Close()
  End Sub

  Sub initTempUpload()
    ViewUpload = False
    datePart = Now.ToString("yyMMdd-HHmmss")
    ' Label3.Text = "http://snap.teamwiki.net/" + datePart + "-" + twLoginuser + "-"
    TextBox1.Text = glob.para("lastTempUploadName", "")
    chkCopyPageLink.Checked = glob.para("lastTempUploadLink", "PAGE") = "PAGE"
    updateLink()
    Text = "Screenshot temporär hochladen ..."
    Me.ShowDialog()
  End Sub

  Property ViewUpload() As Boolean
    Get

    End Get
    Set(ByVal value As Boolean)
      PictureBox3.Visible = value
      FlowLayoutPanel1.Visible = Not value
      txtFullURL.Visible = value
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
    If FlowLayoutPanel1.Visible Then
      TextBox1.Focus()

    End If
  End Sub

  Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
    If Char.IsControl(e.KeyChar) Then Exit Sub
    If Char.IsUpper(e.KeyChar) Then
      e.KeyChar = Char.ToLower(e.KeyChar)
    End If
    If Char.IsLetterOrDigit(e.KeyChar) = False And e.KeyChar <> "."c Then
      e.KeyChar = "-"c
    End If
  End Sub

  Private Sub FlowLayoutPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles FlowLayoutPanel1.Paint

  End Sub

  Private Sub btnComment_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnComment.Click
    If btnComment.Text = "Kommentar >" Then
      btnComment.Text = "< Kommentar"
      Me.Height = deltaY + 340

    Else
      btnComment.Text = "Kommentar >"
      Me.Height = deltaY + 206

    End If
  End Sub

  Private Sub chkCopyPageLink_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCopyPageLink.CheckedChanged
    updateLink()
  End Sub
  Sub updateLink()
    If chkCopyPageLink.Checked Then
      Label3.Text = "http://snap.teamwiki.net/image.php?file=" + datePart + "-" + twLoginuser + ""
      Label4.Text = ""
    Else
      Label3.Text = "http://snap.teamwiki.net/" + datePart + "-" + twLoginuser + "-"
      Label4.Text = ".png"
    End If
  End Sub

  Private Sub frm_tempScreenShotName_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub
End Class
