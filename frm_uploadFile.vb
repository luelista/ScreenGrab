Public Class frm_uploadFile

  Dim folderSpec As String, teamName As String
  Dim teams As New List(Of String)
  
  Structure cbJumpItem
    Dim targetFolder As String
    Dim text As String
    Dim icon As Integer
    Public Sub New(ByVal targetFld As String, ByVal txt As String, ByVal ico As Integer)
      targetFolder = targetFld
      text = txt
      icon = ico
    End Sub
    Public Overrides Function ToString() As String
      Return targetFolder
    End Function
  End Structure

  Function getTeam() As String
    Dim fld() = Split(cmbFolder.Text, "/", 3)
    ReDim Preserve fld(2)
    Return fld(1)
  End Function
  Function getFolder() As String
    Dim fld() = Split(cmbFolder.Text, "/", 3)
    ReDim Preserve fld(2)
    Return fld(2)
  End Function
  Function getFilename() As String
    Return txtFilename.Text
  End Function

  Sub setFilename(ByVal newValue As String)
    txtFilename.Text = newValue
  End Sub

  Sub useLastFilename(ByVal countIdx As Boolean)
    Dim oldFn = glob.para("frm_uploadFile__lastFilename")
    If countIdx Then
      Dim mc = System.Text.RegularExpressions.Regex.Matches(oldFn, "[0-9]+")
      If mc.Count > 0 Then
        Dim m As System.Text.RegularExpressions.Match = mc.Item(mc.Count - 1)
        'letzten Index hochzählen
        Dim val = CInt(m.Value) + 1
        Dim str = val.ToString(New String("0"c, m.Length))
        oldFn = oldFn.Substring(0, m.Index) + str + oldFn.Substring(m.Index + m.Length)
      End If
    End If
    setFilename(oldFn)
  End Sub

  Private _localPicture As Image

  Private _localFilespec() As String = {}
  Public Property UploadLocalFile() As String()
    Get
      Return _localFilespec
    End Get
    Set(ByVal value() As String)
      _localFilespec = value

      If value.Length = 1 Then
        Dim fn = IO.Path.GetFileName(value(0))
        txtFilename.Text = fn
      ElseIf value.Length > 1 Then
        txtFilename.Text = "< mehrere Dateien >"
        txtFilename.Enabled = False
      End If

    End Set
  End Property

  Private _url As String
  Public ReadOnly Property URL() As String
    Get
      Return _url
    End Get
  End Property

  Sub showLocalFilePanel(ByVal fileSpec As String)
    showTopPanel(pnlUploadLocalFile)
    TextBox1.Text = fileSpec
    PictureBox1.Image = Icon.ExtractAssociatedIcon(fileSpec).ToBitmap
  End Sub

  Sub showTopPanel(ByVal pnl As Panel)
    pnlMain.Top = pnl.Height
    pnlMain.Height = Me.ClientSize.Height - pnl.Height
    pnl.Show()
  End Sub

  Sub setPictureToSave(ByVal pic As Image)
    lblPicFormat.Show()
    cmbPicFormat.Show()

    _localPicture = pic
    Dim fileName = glob.fp(IO.Path.GetTempPath(), "grab5_tempfile.")

    pic.Save(fileName + "PNG", Imaging.ImageFormat.Png)
    pic.Save(fileName + "JPG", Imaging.ImageFormat.Jpeg)

  End Sub

  Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
    If lviFolderCont.Items.ContainsKey(LCase(getFilename)) Then
      If MsgBox(LCase(getFilename) & " ist bereits vorhanden. Möchten Sie sie ersetzen?", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, "Speichern unter bestätigen") = MsgBoxResult.No Then
        Exit Sub
      End If
    End If
    If _localFilespec.Length > 0 Then
      addTargetFolder(cmbFolder.Text)
      glob.para("frm_uploadFile__lastFolder") = cmbFolder.Text
      glob.para("frm_uploadFile__lastFilename") = txtFilename.Text
      If _localFilespec.Length = 1 Then
        Dim rErrMes As String
        pnlMain.Enabled = False

        upload_file(_localFilespec(0), getFilename(), False, "", getTeam() + "/" + getFolder(), rErrMes)
        If rErrMes.StartsWith("OK, ") Then
          _url = rErrMes.Substring(3).Trim
          Clipboard.SetText(_url)
          Me.DialogResult = Windows.Forms.DialogResult.OK

        Else
          MsgBox("Die Datei " + IO.Path.GetFileName(_localFilespec(0)) + " konnte nicht hochgeladen werden, da ein Fehler aufgetreten ist." + vbNewLine + vbNewLine + "Zielordner: " + cmbFolder.Text + vbNewLine + "Rückmeldung vom Server: " + rErrMes, MsgBoxStyle.Exclamation, "TeamWiki")
        End If
        pnlMain.Enabled = True
      Else
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Dim uploader As New uploadFiles
        Dim folder = getFolder()
        For Each fn In _localFilespec
          uploader.Add(fn, getTeam() + "/" + getFolder())
        Next
        uploader.Start()
      End If

    Else
      Me.DialogResult = Windows.Forms.DialogResult.OK
    End If
  End Sub

  'Shared Function ShowUploadDialog(ByVal localFilespec As String, ByRef url As String, ByRef errMes As String, Optional ByVal defaultFolder As String = "") As Boolean
  '  Dim frm As New frm_uploadFile
  '  frm.UploadLocalFile = localFilespec
  '  If defaultFolder <> "" Then
  '    frm.cmbFolder.Text = defaultFolder
  '  End If
  '  If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
  '    url = frm.URL
  '    Return True
  '  Else
  '    errMes = "Canceled by user"
  '  End If

  'End Function

  'Shared Sub ShowMultiUploadDialog(ByVal localFilespec() As String)
  '  Dim frm As New frm_uploadFile
  '  'frm.UploadLocalFile = localFilespec
  '  If defaultFolder <> "" Then
  '    frm.cmbFolder.Text = defaultFolder
  '  End If
  '  If frm.ShowDialog = Windows.Forms.DialogResult.OK Then

  '  Else
  '  End If

  'End Sub

  Sub LoadTeamList()
    Dim Data, Lines(), Parts() As String
    Dim indents(10) As TreeNodeCollection, tn As TreeNode
    Data = TwAjax.getUrlContent("http://vb.teamwiki.net/php/vb/grab5.php?c=get_teams", "twnetSID=" + twSessID)
    Lines = Split(Data, vbCrLf)
    If checkIfErrorResult(Lines) = False Then Exit Sub

    teams.Clear()
    For i = 3 To Lines.Length - 1
      Parts = Split(Lines(i), ":")
      If Parts(3) = "ID_TEAM" Then teams.Add(Parts(2))
    Next
  End Sub
  Private Sub frm_uploadFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    
    Show()

    showMain()

  End Sub


  Sub showMain()
    'pnlLogin.Enabled = False
    pnlMain.Enabled = True
    pnlMain.BringToFront()

    LoadTeamList()

    cmbFolder.Text = glob.para("frm_uploadFile__lastFolder", "/" + twLoginuser + "/webspace/")

    cmbFolder.Items.Clear()
    cmbFolder.Items.Add(New cbJumpItem(cmbFolder.Text, cmbFolder.Text, 0))
    cmbFolder.Items.Add(New cbJumpItem("/" + twLoginuser + "/webspace/", "eigener Webspace", 1))
    cmbFolder.Items.Add(New cbJumpItem("", "letzte Ziele:", -1))
    For Each fld In getLastTargets()
      cmbFolder.Items.Add(New cbJumpItem(fld, fld, 0))
    Next
    cmbFolder.Items.Add(New cbJumpItem("", "Teams:", -1))
    For Each team In teams
      cmbFolder.Items.Add(New cbJumpItem("/" + team + "/webspace/", team, 2))
    Next
    loadFolderContents()

  End Sub
  'Private Sub btnLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
  '  twSessID = ""
  '  twLoginPass = ""
  '  glob.para("user") = ""
  '  showLogin()
  'End Sub

  'Private Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs)
  '  If doLogin(txtUser.Text, txtPass.Text) Then
  '    lblLogin.Text = twLoginFullname
  '    showMain()
  '    glob.saveParaFile()
  '  Else
  '    MsgBox("Login-Daten nicht korrekt", MsgBoxStyle.Exclamation, "TeamWiki")
  '    txtUser.Focus()
  '    txtUser.SelectAll()
  '    txtPass.Text = ""
  '  End If
  'End Sub

  Sub loadFolderContents(Optional ByVal forceReload As Boolean = False)
    If cmbFolder.Text = folderSpec And forceReload = False Then Exit Sub
    folderSpec = cmbFolder.Text

    lviFolderCont.Items.Clear()

    cmbFolder.Items(0) = New cbJumpItem(cmbFolder.Text, cmbFolder.Text, 0)
    If cmbFolder.SelectedIndex <> 0 Then cmbFolder.SelectedIndex = 0
    Dim fld() = Split(cmbFolder.Text, "/", 3)
    ReDim Preserve fld(2)
    Dim Data, Lines(), Parts() As String
    Data = TwAjax.getUrlContent("http://secure.teamwiki.net/q/profileservice.php?m=mydocs_getfilelist&format=vbfriendly&user=" + fld(1) + "&f=" + fld(2), "twnetSID=" + twSessID)
    Lines = Split(Data, vbCrLf)

    For i = 0 To Lines.Length - 1
      Parts = Split(Lines(i), "|||")
      If Parts.Length < 4 Then Continue For
      Dim lvi = lviFolderCont.Items.Add(LCase(Parts(1)), Parts(1), CInt(Parts(0)))
      lvi.SubItems.Add(Parts(2))
      lvi.SubItems.Add(Parts(3))
      '  lvi.ImageIndex = Parts(0)
    Next
    refreshUplBtnEnabledState()
  End Sub

  Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    Process.Start("http://teamwiki.net")
  End Sub

  Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    Process.Start("http://start.teamwiki.net/register")
  End Sub

  Dim fnt1 As New System.Drawing.Font("Microsoft Sans Serif", 8, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
  Dim fnt2 As New System.Drawing.Font("Microsoft Sans Serif", 8, Drawing.FontStyle.Italic Or Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)

  Private Sub cmbFolder_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles cmbFolder.DrawItem
   
    If e.Index < 0 Then Exit Sub
    Dim itm As cbJumpItem = cmbFolder.Items(e.Index)
    If itm.icon = -1 Then
      e.Graphics.DrawString(itm.text, fnt2, Drawing.Brushes.DimGray, e.Bounds.X + 2, e.Bounds.Y + 2)
    Else
      e.DrawBackground()
      e.DrawFocusRectangle()
      e.Graphics.DrawImageUnscaled(ImageList2.Images(itm.icon), e.Bounds.X + 2, e.Bounds.Y + 1)
      e.Graphics.DrawString(itm.text, fnt1, New Drawing.SolidBrush(e.ForeColor), e.Bounds.X + 20, e.Bounds.Y + 2)

    End If
  End Sub

  Private Sub cmbFolder_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFolder.Leave
    loadFolderContents()
  End Sub

  Private Sub cmbFolder_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFolder.SelectedIndexChanged
    loadFolderContents()
  End Sub

  Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
    Me.DialogResult = Windows.Forms.DialogResult.Cancel
    Me.Close()
  End Sub

  Private Sub txtUser_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    If e.KeyCode = Keys.Enter Then
      e.SuppressKeyPress = True
      SendKeys.Send("{TAB}")
    End If
  End Sub

  Private Sub lviFolderCont_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lviFolderCont.MouseClick

  End Sub

  Private Sub lviFolderCont_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lviFolderCont.MouseDoubleClick
    If lviFolderCont.SelectedItems.Count <> 1 Then Exit Sub

    Dim itm = lviFolderCont.SelectedItems(0)
    If itm.ImageIndex = 0 Then
      cmbFolder.Text += itm.Text + "/"
      loadFolderContents()
    Else
      If txtFilename.Enabled Then
        txtFilename.Text = itm.Text
      End If
    End If
  End Sub

  Private Sub lviFolderCont_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lviFolderCont.SelectedIndexChanged

  End Sub

  Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
    Dim fld = cmbFolder.Text
    If fld.EndsWith("/") Then fld = fld.Substring(0, fld.Length - 1)
    Dim pos = fld.LastIndexOf("/")
    If pos > -1 Then fld = fld.Substring(0, pos + 1)
    If fld.Length > 0 Then
      cmbFolder.Text = fld
      loadFolderContents()
    End If
  End Sub

  Private Sub txtFilename_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilename.TextChanged
    refreshUplBtnEnabledState()
  End Sub

  Sub refreshUplBtnEnabledState()
    Dim path() = Split(cmbFolder.Text, "/")
    btnUpload.Enabled = txtFilename.Text <> "" And path.Length > 3
  End Sub

  Private Sub btnNewFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewFolder.Click
    Dim fld = InputBox("Neuen Ordner anlegen unter: " + vbNewLine + cmbFolder.Text + vbNewLine + vbNewLine + "Bitte geben Sie den Ordnernamen ein:", "TeamWiki")
    If fld = "" Then Exit Sub

    Dim url = "http://secure.teamwiki.net/q/profileservice.php?m=mydocs_fileaction&action=createfolder&user=" + getTeam() + "&f=" + getFolder() + "&foldername=" + fld
    Dim res = TwAjax.getUrlContent(url)
    If Trim(res) = "1" Then
      loadFolderContents(True)
    Else
      MsgBox("Fehler: " + res, MsgBoxStyle.Critical, "TeamWiki")
    End If

  End Sub
End Class