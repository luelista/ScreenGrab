Public Class frm_saveFile
  Dim lcfilelist As String = "|"
  Dim targetFolder As String
  Dim tempFilespec As String
  Public urlMode As Boolean
  Dim diz As String

  Private Sub frm_saveFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    CheckForIllegalCrossThreadCalls = False

    'standardWerte
    glob.readTuttiFrutti(Me)
    'TextBox1.Text = glob.para("saveFile__lastFilename", "")
    'opt_temp_timestamp.Checked = True
    'check_clipboardURL.Checked = True
    'check_skype.Checked = glob.para("saveFile__skype", "FALSE") = "TRUE"
    'checkOverwriteFile.Checked = False : txtURL.Visible = urlMode : Me.Enabled = True
    If TextBox1.Text <> "" And IsNumeric(Strings.Right(TextBox1.Text, 1)) Then

    End If

    PictureBox1.Hide()
    diz = GetUsername()

    'tempDatei speichern (für Upload und um Dateigröße zu ermitteln)
    tempFilespec = System.IO.Path.GetTempPath() + "tmpupload.png"

    If urlMode Then
      txtURL.Text = Clipboard.GetText()
      Show() : Application.DoEvents()
      If txtURL.Text <> "" Then
        PictureBox1.Show()
        Dim pic As Image = ImageFromWeb(txtURL.Text)
        PictureBox1.Hide()
        If pic Is Nothing Then MsgBox("Fehler beim Download, ist eine URL im ClipBoard?") : Exit Sub
        pic.Save(tempFilespec, Imaging.ImageFormat.Png)
      Else
        txtURL.Focus()
      End If
    Else
      Dim RES = frm_blueScreen.savePicture(tempFilespec)
      If Not RES Then Me.Close()
    End If
    Label3.Text = "Dateigröße: " + CreateNiceFileSize(FileLen(tempFilespec))
    PictureBox2.ImageLocation = tempFilespec
  End Sub

  Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
    If Not (Char.IsLetter(e.KeyChar) Or Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar) Or _
            e.KeyChar = "_"c Or e.KeyChar = "."c Or e.KeyChar = "-"c) Then
      e.Handled = True : Exit Sub
    End If

  End Sub

  Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
  Handles TextBox1.TextChanged, labNamePrefix.TextChanged

    If lcfilelist.Contains("|" + labNamePrefix.Text.ToLower + TextBox1.Text.ToLower + ".png|") Then
      checkOverwriteFile.Visible = True
      checkOverwriteFile.Checked = False
      btnUpload.Enabled = False
    ElseIf TextBox1.Text = "" Then
      btnUpload.Enabled = False
    Else
      btnUpload.Enabled = True
      checkOverwriteFile.Visible = False
    End If
  End Sub

  Private Sub opt_Temp_overwrite_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_Temp_overwrite.CheckedChanged
    targetFolder = "clip"
    labNamePrefix.Text = ""
    TextBox1.ReadOnly = True
    TextBox1.Text = "u-" + diz
    refreshFileList()
  End Sub

  Private Sub opt_temp_timestamp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_temp_timestamp.CheckedChanged
    targetFolder = "tmp"
    labNamePrefix.Text = Now.ToString("yyyymmdd-HHmmss") + "-" + diz + "-"
    TextBox1.ReadOnly = False
    If TextBox1.Text = "u-" + diz Then TextBox1.Text = ""
    TextBox1.Focus()
    refreshFileList()
  End Sub

  Sub refreshFileList()
    If targetFolder = "" Then Exit Sub
    Dim RES As String = TwAjax.getUrlContent("http://ajax.teamwiki.net/php/vb/dirlist.php?mode=simple&d=[scr]" + targetFolder + "/")
    Dim files() = Split(RES, vbNewLine)

    lcfilelist = "|" + RES.ToLower.Replace(vbNewLine, "|") + "|"

    lstFilelist.Items.Clear()
    lstFilelist.Items.AddRange(files)
  End Sub

  Private Sub opt_perma_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_perma.CheckedChanged
    targetFolder = "img"
    labNamePrefix.Text = diz + "--"
    If TextBox1.Text = "u-" + diz Then TextBox1.Text = ""
    TextBox1.Focus()
    TextBox1.SelectAll()
    refreshFileList()
  End Sub

  Private Sub checkOverwriteFile_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkOverwriteFile.CheckedChanged
    btnUpload.Enabled = checkOverwriteFile.Checked Or Not checkOverwriteFile.Visible
  End Sub

  Private Sub lstFilelist_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstFilelist.Click
    'TextBox1.Text = lstFilelist.SelectedItem
    PictureBox2.ImageLocation = "http://screen-" + targetFolder + ".teamwiki.net/" + lstFilelist.SelectedItem
  End Sub

  Private Sub lstFilelist_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstFilelist.DoubleClick
    Process.Start("http://screen-" + targetFolder + ".teamwiki.net/" + lstFilelist.SelectedItem)
  End Sub

  Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
    If TextBox1.Text.Contains(" ") Then MsgBox("Dateiname darf keine Leerzeichen enthalten") : Exit Sub
    TextBox1.Text = TextBox1.Text.ToLower

    glob.saveTuttiFrutti(Me)

    btnUpload.Enabled = False

    PictureBox1.Show()
    Application.DoEvents()
    Me.Enabled = False

    Dim fileName As String = labNamePrefix.Text + TextBox1.Text + ".png"
    fileName = fileName.Replace("ä", "ae").Replace("ö", "oe").Replace("ü", "ue") _
               .Replace("Ä", "Ae").Replace("Ö", "Oe").Replace("Ü", "Ue")
    Dim fileSpec = ftproot + "/screengrab/" + targetFolder + "/" + fileName
    Dim url = "http://screen-" + targetFolder + ".teamwiki.net/" + fileName

    If check_clipboardURL.Checked Then
      Clipboard.Clear()
      Clipboard.SetText(url)
    End If

    bgw_ftpUpload.RunWorkerAsync(fileName)
  End Sub

  Private Sub frm_saveFile_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    Select Case e.KeyCode
      Case Keys.F1
        If opt_perma.Checked Then
          opt_Temp_overwrite.Checked = True
        ElseIf opt_Temp_overwrite.Checked Then
          opt_temp_timestamp.Checked = True
        ElseIf opt_temp_timestamp.Checked Then
          opt_perma.Checked = True
        End If
      Case Keys.F2
        btnSaveAs_Click(Nothing, Nothing)
      Case Keys.F6
        check_clipboardURL.Checked = Not check_clipboardURL.Checked
      Case Keys.F7
        check_skype.Checked = Not check_skype.Checked
      Case Keys.F9
        If checkOverwriteFile.Visible Then
          checkOverwriteFile.Checked = Not checkOverwriteFile.Checked
        Else
          Beep()
        End If
    End Select
  End Sub


  Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
    Me.Close()
  End Sub

  Private Sub check_skype_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles check_skype.CheckedChanged
    On Error Resume Next
    If check_skype.Checked Then
      Dim t = check_skype.Text
      check_skype.Text = "BITTE VERBINDUNG ZU SKYPE ERLAUBEN!"
      With CreateObject("Skype4COM.Skype")
        cmb_SkypeChats.Items.Clear()
        cmb_SkypeChats.DropDownWidth = 444
        For Each oChat As Object In .activeChats '.RecentChats
          cmb_SkypeChats.Items.Add(oChat.dialogPartner + "     " + oChat.friendlyName + Space(100) + "|##|" + oChat.Name)
        Next
        If cmb_SkypeChats.Items.Count = 0 Then
          MsgBox("bitte öffne ein Skype-Chatfenster!")
          check_skype.Checked = False
        Else
          cmb_SkypeChats.SelectedIndex = 0
        End If
      End With
      check_skype.Text = t
    End If
    cmb_SkypeChats.Enabled = check_skype.Checked
  End Sub

  Private Sub btnSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAs.Click
    Using sfd As New SaveFileDialog
      sfd.Filter = "Portable Network Graphics (*.png)|*.png|Alle Dateien|*.*"
      sfd.FileName = TextBox1.Text + ".png"

      If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
        glob.saveTuttiFrutti(Me)
        Try
          IO.File.Copy(tempFilespec, sfd.FileName, True)
          Me.Close()
        Catch ex As Exception
          MsgBox("Fehler beim Speichern der Datei" + vbNewLine + "Dateiname: " + sfd.FileName + vbNewLine + vbNewLine + ex.Message, MsgBoxStyle.Exclamation)
        End Try
      End If

    End Using
  End Sub

  Private Sub lstFilelist_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstFilelist.LostFocus
    PictureBox2.ImageLocation = tempFilespec
  End Sub

  Private Sub PictureBox2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.DoubleClick
    Process.Start(tempFilespec)

  End Sub

  Private Sub txtURL_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtURL.KeyUp
    If (e.KeyCode = Keys.V And e.Control) Or e.KeyCode = Keys.Enter Then
      txtURL.Text = Clipboard.GetText
      PictureBox1.Show()
      Dim pic As Image = ImageFromWeb(txtURL.Text)
      PictureBox1.Hide()
      If pic Is Nothing Then MsgBox("Fehler beim Download, ist eine URL im ClipBoard?") : Exit Sub
      pic.Save(tempFilespec, Imaging.ImageFormat.Png)
      PictureBox2.ImageLocation = tempFilespec
    End If
  End Sub

  Private Sub txtURL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtURL.TextChanged
    On Error Resume Next
    Dim tx As String = txtURL.Text
    Dim startpos As Integer = tx.LastIndexOf("/") + 1
    Dim endpos As Integer = tx.IndexOf("?", startpos)
    If endpos = -1 Then endpos = tx.Length
    TextBox1.Text = tx.Substring(startpos, endpos - startpos)
  End Sub

  Private Sub bgw_ftpUpload_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgw_ftpUpload.DoWork
    Dim fileName = e.Argument
    Dim fileSpec = ftproot + "/screengrab/" + targetFolder + "/" + fileName
    Dim url = "http://screen-" + targetFolder + ".teamwiki.net/" + fileName

    ftpConnect("teamwiki.net", "ftp-tw", "uremitak22")
    ftpUpload(tempFilespec, fileSpec)

    TwAjax.SaveFile("screengrab", "lastscreenshot.txt", diz + vbNewLine + targetFolder + vbNewLine + fileName)

    If check_skype.Checked And cmb_SkypeChats.SelectedIndex > -1 Then
      Dim chatName() = Split(cmb_SkypeChats.SelectedItem, "|##|")
      If chatName.Length = 2 Then
        Dim skyp = CreateObject("Skype4COM.Skype")
        Dim chat = skyp.Chat(chatName(1))
        chat.SendMessage("ScreenShot: " + url)
      End If
    End If

    My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Question)
    
  End Sub

  Private Sub bgw_ftpUpload_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_ftpUpload.RunWorkerCompleted
    Me.Close()

  End Sub
End Class