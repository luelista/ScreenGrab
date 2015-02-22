Imports System.IO
Imports System.Drawing.Drawing2D

Public Class frm_options

  Dim skipMultiuplEvents As Boolean = False
  Dim imgurToken, imgurTokenSecret As String

  Property confpage() As Integer
    Get
      Return Me.TabControl1.SelectedIndex
    End Get
    Set(ByVal page As Integer)
      Me.Show()
      Me.Activate()
      Me.ButtonListBar1.Items(page).Selected = True
      Me.TabControl1.SelectedIndex = page
    End Set
  End Property

  Private Sub frm_widgetMan_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    saveSettings()
    glob.saveFormPos(Me)
  End Sub


  Sub saveSettings()
    glob.saveTuttiFrutti(Me)
    Try
      FRM.pnlViewPartial.BackColor = ColorTranslator.FromHtml(txtMainWinBG.Text)
    Catch :End Try

    ' FRM.chkViewHist.Checked = (glob.para("frm_options__chkEnableHistory", "FALSE") = "TRUE")
    ' FRM.chkViewHist.Visible = (glob.para("frm_options__chkEnableHistory", "FALSE") = "TRUE")
  End Sub


  Private Sub frm_widgetMan_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
    If e.KeyCode = Keys.Escape Then
      e.SuppressKeyPress = True
      If TabControl1.SelectedTab.Text = "TabPage1" Then
        Me.Close()
      Else
        Me.confpage = 0
      End If
    End If
  End Sub


  Private Sub frm_widgetMan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim tabs() As String = {"Allgemein", "Accounts && Internet", "Livestream", "Info"}

    For i As Integer = 0 To tabs.Length - 1
      ButtonListBar1.Items.Add( _
      New ButtonListbar.vbAccelerator.Controls.ListBar.ButtonListBarItem(tabs(i), i))
    Next

    glob.readFormPos(Me) ', False)

    Show()
    Application.DoEvents()

    glob.readTuttiFrutti(Me)

    If glob.para("imgur_account_url") <> "" Then
      rbImgurLogin__on.Checked = True
      lblImgurLogin.Show() : lblImgurLogin.Text = "Eingeloggt als " + glob.para("imgur_account_url")
    Else
      rbImgurLogin__off.Checked = True
    End If

    TabControl1.Top = -25

    lblProgVer.Text = My.Application.Info.Version.ToString(2)
  End Sub


  Private Sub ButtonListBar1_ItemClick(ByVal sender As Object, ByVal eventArgs As ButtonListbar.vbAccelerator.Controls.ListBar.ItemClickEventArgs) Handles ButtonListBar1.ItemClick
    Dim idx As Integer
    idx = eventArgs.Item.IconIndex
    TabControl1.SelectedIndex = idx
  End Sub


  Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
    Application.DoEvents()
    Select Case TabControl1.SelectedIndex
      Case 1
        'If igInstalled.Rows.Count = 0 Then initInstalledList(True)
      Case 2
        'labDownloadInfo.Text = "Updates suchen ..."
        'checkForGadgetUpdate()
      Case 3

    End Select
  End Sub


  Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
    saveSettings()
    Close()
  End Sub


  Private Sub btnDefaultFolder_choose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDefaultFolder_choose.Click

    Using f As New FolderBrowserDialog
      f.Description = "Bitte wähle den Ordner aus, in den die Bilder standardmäßig gespeichert werden soll."
      f.SelectedPath = txtDefaultFolder.Text
      If f.ShowDialog = Windows.Forms.DialogResult.OK Then
        txtDefaultFolder.Text = f.SelectedPath
      End If
    End Using
  End Sub


  Public Sub New()

    ' This call is required by the Windows Form Designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.

    '.......................  TabControl1.Top = -22

  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    saveSettings()

  End Sub

  'Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
  '  Dim g = PictureBox2.CreateGraphics
  '  Dim cmbinfo As New COMBOBOXINFO
  '  GetComboBoxInfo(ListBox1.Handle, cmbinfo)

  '  Dim dc = g.GetHdc
  '  SendMessage(ComboBox1.Handle, WindowsMessages.WM_PRINTCLIENT, dc, PRF_CLIENT Or PRF_CHILDREN Or PRF_OWNED)
  '  SendMessage(ListBox1.Handle, WindowsMessages.WM_PRINTCLIENT, dc, PRF_NONCLIENT Or PRF_CLIENT)


  '  g.ReleaseHdc(dc)

  'End Sub



  Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    Using cd As New ColorDialog
      Try
        cd.Color = ColorTranslator.FromHtml(txtMainWinBG.Text)
      Catch : End Try
      If cd.ShowDialog = Windows.Forms.DialogResult.OK Then
        txtMainWinBG.Text = ColorTranslator.ToHtml(cd.Color)
      End If
    End Using
  End Sub

  Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLSInfo.TextChanged

  End Sub

  Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click

  End Sub

  Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
    glob.saveTuttiFrutti(Me)
    FRM.chk_streaming.Visible = True
  End Sub



  Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
    Process.Start("http://dropme.de/?source=sg_settings_reglink")
  End Sub

  Private Sub rbImgurLogin__on_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbImgurLogin__on.Click
    lblImgurLogin.Hide()
    Dim authLib As New OAuth.OAuthBase()
    Dim timestamp As String = Now.Ticks
    Randomize()
    Dim nonce As String = String.Format("{0:x20}", CLng(Now.Ticks * Rnd()))
    Dim normURL, normParams, sig As String
    sig = authLib.GenerateSignature(New Uri("https://api.imgur.com/oauth/request_token"), IMGUR_CONSUMER_KEY, IMGUR_CONSUMER_SECRET, "", "", "GET", timestamp, nonce, OAuth.OAuthBase.SignatureTypes.HMACSHA1, normURL, normParams)
    Dim RESULT As String
    RESULT = TwAjax.getUrlContent(normURL + "?" + normParams + "&oauth_signature=" + sig)
    Dim nvc = Web.HttpUtility.ParseQueryString(RESULT)
    imgurToken = nvc("oauth_token")
    imgurTokenSecret = nvc("oauth_token_secret")
    Dim authURL = "https://api.imgur.com/oauth/authorize?oauth_token=" + imgurToken
    Dim ie = CreateObject("InternetExplorer.Application")
    ie.visible = True
    ie.menubar = False
    ie.statusbar = False
    ie.width = 768
    ie.height = 600
    ie.addressbar = False
    ie.navigate(authURL)


    pnlImgurVerify.Enabled = True
  End Sub

  Private Sub btnImgurAuth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImgurAuth.Click
    Dim authLib As New OAuth.OAuthBase()
    Dim normURL, normParams, sig As String
    sig = authLib.GenerateSignature(New Uri("https://api.imgur.com/oauth/access_token?oauth_verifier=" + TextBox1.Text), IMGUR_CONSUMER_KEY, IMGUR_CONSUMER_SECRET, imgurToken, imgurTokenSecret, "GET", authLib.GenerateTimeStamp(), authLib.GenerateNonce(), OAuth.OAuthBase.SignatureTypes.HMACSHA1, normURL, normParams)
    Dim RESULT As String
    RESULT = TwAjax.getUrlContent(normURL + "?" + normParams + "&oauth_signature=" + sig)
    Dim nvc = Web.HttpUtility.ParseQueryString(RESULT)
    If nvc("oauth_token") IsNot Nothing Then
      glob.para("imgur_token") = nvc("oauth_token")
      glob.para("imgur_token_secret") = nvc("oauth_token_secret")
      pnlImgurVerify.Enabled = False

      sig = authLib.GenerateSignature(New Uri("http://api.imgur.com/2/account.json"), IMGUR_CONSUMER_KEY, IMGUR_CONSUMER_SECRET, glob.para("imgur_token"), glob.para("imgur_token_secret"), "GET", authLib.GenerateTimeStamp(), authLib.GenerateNonce(), OAuth.OAuthBase.SignatureTypes.HMACSHA1, normURL, normParams)
      RESULT = TwAjax.getUrlContent(normURL + "?" + normParams + "&oauth_signature=" + sig)
      Dim account As Hashtable = JSON.JsonDecode(RESULT)
      For Each key In account("account")
        glob.para("imgur_account_" + key.key) = key.value 'account("account")(key)
      Next
      'sig = authLib.GenerateSignature(New Uri("http://api.imgur.com/2/account/images_count.json"), IMGUR_CONSUMER_KEY, IMGUR_CONSUMER_SECRET, glob.para("imgur_token"), glob.para("imgur_token_secret"), "GET", authLib.GenerateTimeStamp(), authLib.GenerateNonce(), OAuth.OAuthBase.SignatureTypes.HMACSHA1, normURL, normParams)
      'RESULT = TwAjax.getUrlContent(normURL + "?" + normParams + "&oauth_signature=" + sig)
      'Dim imgCount As Hashtable = JSON.JsonDecode(RESULT)

      lblImgurLogin.Show() : lblImgurLogin.Text = "Eingeloggt als " + glob.para("imgur_account_url")

      MsgBox("Du bist jetzt eingeloggt.", MsgBoxStyle.Information)
    Else
      MsgBox("Der eingegebene Verification code wurde von imgur.com abgelehnt. Bitte versuche es erneut.", MsgBoxStyle.Exclamation)
      rbImgurLogin__on_Click(Nothing, Nothing)
    End If
  End Sub

  Private Sub rbImgurLogin__off_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbImgurLogin__off.Click
    lblImgurLogin.Hide()
    pnlImgurVerify.Enabled = False
    glob.para("imgur_token") = ""
    glob.para("imgur_token_secret") = ""
    glob.para("imgur_account_url") = ""

  End Sub

  Private Sub TabPage4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage4.Click

  End Sub

  Private Sub TabPage4_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TabPage4.Paint
    Dim rect As New Rectangle(0, 0, TabPage4.Width, TabPage4.Height)
    Dim lgb As New Drawing2D.LinearGradientBrush(rect, Color.DodgerBlue, Color.RoyalBlue, LinearGradientMode.Vertical)
    e.Graphics.FillRectangle(lgb, rect)
  End Sub

  Private Sub LinkLabel5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked, LinkLabel4.LinkClicked, LinkLabel3.LinkClicked
    Process.Start(sender.tag)
  End Sub

  Private Sub btnUpdateCheckNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateCheckNow.Click
    btnUpdateCheckNow.Enabled = False
    If checkForUpdate() Then
      frm_softwareUpdate.Show()
      frm_softwareUpdate.startDownload()
    End If
    btnUpdateCheckNow.Enabled = True
  End Sub

  Private Sub btnChooseDefaultFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChooseDefaultFolder.Click
    Using fbd As New FolderBrowserDialog
      fbd.SelectedPath = txtDefaultFolder.Text
      If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
        txtDefaultFolder.Text = fbd.SelectedPath
      End If
    End Using
  End Sub

  Private Sub lnkExploreDefaultFolder_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkExploreDefaultFolder.LinkClicked
    Process.Start("explorer", "/e,""" + txtDefaultFolder.Text + """")
  End Sub

  Private Sub btnShowHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowHistory.Click
    uploadHistoryOpen()
  End Sub

  Private Sub chkCollageHitTestIntersect_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCollageHitTestIntersect.CheckedChanged

  End Sub
End Class