﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_options
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()> _
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_options))
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TabPage1 = New System.Windows.Forms.TabPage()
    Me.GroupBox5 = New System.Windows.Forms.GroupBox()
    Me.cmbHotkeyKey = New System.Windows.Forms.ComboBox()
    Me.chkHotkeyWin = New System.Windows.Forms.CheckBox()
    Me.chkHotkeyShift = New System.Windows.Forms.CheckBox()
    Me.chkHotkeyAlt = New System.Windows.Forms.CheckBox()
    Me.chkHotkeyCtrl = New System.Windows.Forms.CheckBox()
    Me.GroupBox8 = New System.Windows.Forms.GroupBox()
    Me.chkCollageHitTestIntersect = New System.Windows.Forms.CheckBox()
    Me.GroupBox7 = New System.Windows.Forms.GroupBox()
    Me.btnShowHistory = New System.Windows.Forms.Button()
    Me.chkEnableHistory = New System.Windows.Forms.CheckBox()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.chk_disp_size_in_tb = New System.Windows.Forms.CheckBox()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.txtMainWinBG = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.checkHideWhileGrab = New System.Windows.Forms.CheckBox()
    Me.btnClose = New System.Windows.Forms.Button()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.lnkExploreDefaultFolder = New System.Windows.Forms.LinkLabel()
    Me.btnChooseDefaultFolder = New System.Windows.Forms.Button()
    Me.chkAlwaysUseDefaultFolder = New System.Windows.Forms.CheckBox()
    Me.txtDefaultFolder = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.jpegQuality = New System.Windows.Forms.NumericUpDown()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.btnDefaultFolder_choose = New System.Windows.Forms.Button()
    Me.TabPage3 = New System.Windows.Forms.TabPage()
    Me.GroupBox6 = New System.Windows.Forms.GroupBox()
    Me.lblImgurLogin = New System.Windows.Forms.Label()
    Me.pnlImgurVerify = New System.Windows.Forms.Panel()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.btnImgurAuth = New System.Windows.Forms.Button()
    Me.rbImgurLogin__on = New System.Windows.Forms.RadioButton()
    Me.rbImgurLogin__off = New System.Windows.Forms.RadioButton()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.txtProxyDOM = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.txtProxyPW = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.txtProxyUN = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
    Me.txtLoginPass = New System.Windows.Forms.TextBox()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.txtLoginUser = New System.Windows.Forms.TextBox()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.PictureBox2 = New System.Windows.Forms.PictureBox()
    Me.imlWidgetIcons = New System.Windows.Forms.ImageList(Me.components)
    Me.ButtonListBar1 = New ButtonListbar.vbAccelerator.Controls.ListBar.ButtonListBar()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ofdChooseIcon = New System.Windows.Forms.OpenFileDialog()
    Me.TabControl1.SuspendLayout()
    Me.TabPage1.SuspendLayout()
    Me.GroupBox5.SuspendLayout()
    Me.GroupBox8.SuspendLayout()
    Me.GroupBox7.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    CType(Me.jpegQuality, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.TabPage3.SuspendLayout()
    Me.GroupBox6.SuspendLayout()
    Me.pnlImgurVerify.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TabControl1
    '
    Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TabControl1.Controls.Add(Me.TabPage1)
    Me.TabControl1.Controls.Add(Me.TabPage3)
    Me.TabControl1.Location = New System.Drawing.Point(100, 0)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(488, 491)
    Me.TabControl1.TabIndex = 0
    '
    'TabPage1
    '
    Me.TabPage1.Controls.Add(Me.GroupBox5)
    Me.TabPage1.Controls.Add(Me.GroupBox8)
    Me.TabPage1.Controls.Add(Me.GroupBox7)
    Me.TabPage1.Controls.Add(Me.GroupBox4)
    Me.TabPage1.Controls.Add(Me.btnClose)
    Me.TabPage1.Controls.Add(Me.GroupBox2)
    Me.TabPage1.Location = New System.Drawing.Point(4, 22)
    Me.TabPage1.Name = "TabPage1"
    Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage1.Size = New System.Drawing.Size(480, 465)
    Me.TabPage1.TabIndex = 4
    Me.TabPage1.Text = "TabPage1"
    Me.TabPage1.UseVisualStyleBackColor = True
    '
    'GroupBox5
    '
    Me.GroupBox5.Controls.Add(Me.cmbHotkeyKey)
    Me.GroupBox5.Controls.Add(Me.chkHotkeyWin)
    Me.GroupBox5.Controls.Add(Me.chkHotkeyShift)
    Me.GroupBox5.Controls.Add(Me.chkHotkeyAlt)
    Me.GroupBox5.Controls.Add(Me.chkHotkeyCtrl)
    Me.GroupBox5.Location = New System.Drawing.Point(17, 10)
    Me.GroupBox5.Name = "GroupBox5"
    Me.GroupBox5.Size = New System.Drawing.Size(444, 56)
    Me.GroupBox5.TabIndex = 19
    Me.GroupBox5.TabStop = False
    Me.GroupBox5.Text = "Tastenkürzel"
    '
    'cmbHotkeyKey
    '
    Me.cmbHotkeyKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cmbHotkeyKey.FormattingEnabled = True
    Me.cmbHotkeyKey.Location = New System.Drawing.Point(223, 22)
    Me.cmbHotkeyKey.Name = "cmbHotkeyKey"
    Me.cmbHotkeyKey.Size = New System.Drawing.Size(197, 21)
    Me.cmbHotkeyKey.TabIndex = 4
    '
    'chkHotkeyWin
    '
    Me.chkHotkeyWin.AutoSize = True
    Me.chkHotkeyWin.Location = New System.Drawing.Point(162, 24)
    Me.chkHotkeyWin.Name = "chkHotkeyWin"
    Me.chkHotkeyWin.Size = New System.Drawing.Size(45, 17)
    Me.chkHotkeyWin.TabIndex = 3
    Me.chkHotkeyWin.Text = "Win"
    Me.chkHotkeyWin.UseVisualStyleBackColor = True
    '
    'chkHotkeyShift
    '
    Me.chkHotkeyShift.AutoSize = True
    Me.chkHotkeyShift.Location = New System.Drawing.Point(109, 24)
    Me.chkHotkeyShift.Name = "chkHotkeyShift"
    Me.chkHotkeyShift.Size = New System.Drawing.Size(47, 17)
    Me.chkHotkeyShift.TabIndex = 2
    Me.chkHotkeyShift.Text = "Shift"
    Me.chkHotkeyShift.UseVisualStyleBackColor = True
    '
    'chkHotkeyAlt
    '
    Me.chkHotkeyAlt.AutoSize = True
    Me.chkHotkeyAlt.Location = New System.Drawing.Point(65, 24)
    Me.chkHotkeyAlt.Name = "chkHotkeyAlt"
    Me.chkHotkeyAlt.Size = New System.Drawing.Size(38, 17)
    Me.chkHotkeyAlt.TabIndex = 1
    Me.chkHotkeyAlt.Text = "Alt"
    Me.chkHotkeyAlt.UseVisualStyleBackColor = True
    '
    'chkHotkeyCtrl
    '
    Me.chkHotkeyCtrl.AutoSize = True
    Me.chkHotkeyCtrl.Location = New System.Drawing.Point(15, 24)
    Me.chkHotkeyCtrl.Name = "chkHotkeyCtrl"
    Me.chkHotkeyCtrl.Size = New System.Drawing.Size(45, 17)
    Me.chkHotkeyCtrl.TabIndex = 0
    Me.chkHotkeyCtrl.Text = "Strg"
    Me.chkHotkeyCtrl.UseVisualStyleBackColor = True
    '
    'GroupBox8
    '
    Me.GroupBox8.Controls.Add(Me.chkCollageHitTestIntersect)
    Me.GroupBox8.Location = New System.Drawing.Point(17, 352)
    Me.GroupBox8.Name = "GroupBox8"
    Me.GroupBox8.Size = New System.Drawing.Size(445, 57)
    Me.GroupBox8.TabIndex = 18
    Me.GroupBox8.TabStop = False
    Me.GroupBox8.Text = "Collage-Modus"
    '
    'chkCollageHitTestIntersect
    '
    Me.chkCollageHitTestIntersect.AutoSize = True
    Me.chkCollageHitTestIntersect.Location = New System.Drawing.Point(17, 26)
    Me.chkCollageHitTestIntersect.Name = "chkCollageHitTestIntersect"
    Me.chkCollageHitTestIntersect.Size = New System.Drawing.Size(213, 17)
    Me.chkCollageHitTestIntersect.TabIndex = 0
    Me.chkCollageHitTestIntersect.Text = "Elemente auswählen mit einzelner Ecke"
    Me.chkCollageHitTestIntersect.UseVisualStyleBackColor = True
    '
    'GroupBox7
    '
    Me.GroupBox7.Controls.Add(Me.btnShowHistory)
    Me.GroupBox7.Controls.Add(Me.chkEnableHistory)
    Me.GroupBox7.Location = New System.Drawing.Point(17, 289)
    Me.GroupBox7.Name = "GroupBox7"
    Me.GroupBox7.Size = New System.Drawing.Size(445, 57)
    Me.GroupBox7.TabIndex = 17
    Me.GroupBox7.TabStop = False
    Me.GroupBox7.Text = "History"
    '
    'btnShowHistory
    '
    Me.btnShowHistory.Location = New System.Drawing.Point(317, 22)
    Me.btnShowHistory.Name = "btnShowHistory"
    Me.btnShowHistory.Size = New System.Drawing.Size(114, 23)
    Me.btnShowHistory.TabIndex = 1
    Me.btnShowHistory.Text = "History anzeigen"
    Me.btnShowHistory.UseVisualStyleBackColor = True
    '
    'chkEnableHistory
    '
    Me.chkEnableHistory.AutoSize = True
    Me.chkEnableHistory.Checked = True
    Me.chkEnableHistory.CheckState = System.Windows.Forms.CheckState.Checked
    Me.chkEnableHistory.Location = New System.Drawing.Point(17, 26)
    Me.chkEnableHistory.Name = "chkEnableHistory"
    Me.chkEnableHistory.Size = New System.Drawing.Size(137, 17)
    Me.chkEnableHistory.TabIndex = 0
    Me.chkEnableHistory.Text = "Upload-Links speichern"
    Me.chkEnableHistory.UseVisualStyleBackColor = True
    '
    'GroupBox4
    '
    Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.GroupBox4.Controls.Add(Me.chk_disp_size_in_tb)
    Me.GroupBox4.Controls.Add(Me.Button1)
    Me.GroupBox4.Controls.Add(Me.txtMainWinBG)
    Me.GroupBox4.Controls.Add(Me.Label8)
    Me.GroupBox4.Controls.Add(Me.checkHideWhileGrab)
    Me.GroupBox4.Location = New System.Drawing.Point(17, 188)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(445, 95)
    Me.GroupBox4.TabIndex = 16
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "Hauptfenster"
    '
    'chk_disp_size_in_tb
    '
    Me.chk_disp_size_in_tb.AutoSize = True
    Me.chk_disp_size_in_tb.Location = New System.Drawing.Point(223, 26)
    Me.chk_disp_size_in_tb.Name = "chk_disp_size_in_tb"
    Me.chk_disp_size_in_tb.Size = New System.Drawing.Size(174, 17)
    Me.chk_disp_size_in_tb.TabIndex = 14
    Me.chk_disp_size_in_tb.Text = "Bildgröße in Titelleiste anzeigen"
    Me.chk_disp_size_in_tb.UseVisualStyleBackColor = True
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(223, 51)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(35, 23)
    Me.Button1.TabIndex = 13
    Me.Button1.Text = "..."
    Me.Button1.UseVisualStyleBackColor = True
    '
    'txtMainWinBG
    '
    Me.txtMainWinBG.Location = New System.Drawing.Point(114, 52)
    Me.txtMainWinBG.Name = "txtMainWinBG"
    Me.txtMainWinBG.Size = New System.Drawing.Size(100, 20)
    Me.txtMainWinBG.TabIndex = 12
    Me.txtMainWinBG.Text = "#EEEEEE"
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(14, 55)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(89, 13)
    Me.Label8.TabIndex = 11
    Me.Label8.Text = "Hintergrundfarbe:"
    '
    'checkHideWhileGrab
    '
    Me.checkHideWhileGrab.AutoSize = True
    Me.checkHideWhileGrab.Location = New System.Drawing.Point(17, 26)
    Me.checkHideWhileGrab.Name = "checkHideWhileGrab"
    Me.checkHideWhileGrab.Size = New System.Drawing.Size(197, 17)
    Me.checkHideWhileGrab.TabIndex = 10
    Me.checkHideWhileGrab.Text = "Fenster verstecken während ""Grab"""
    Me.checkHideWhileGrab.UseVisualStyleBackColor = True
    '
    'btnClose
    '
    Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnClose.Location = New System.Drawing.Point(322, 422)
    Me.btnClose.Name = "btnClose"
    Me.btnClose.Size = New System.Drawing.Size(126, 28)
    Me.btnClose.TabIndex = 3
    Me.btnClose.Text = "OK"
    Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.btnClose.UseVisualStyleBackColor = True
    '
    'GroupBox2
    '
    Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.GroupBox2.Controls.Add(Me.lnkExploreDefaultFolder)
    Me.GroupBox2.Controls.Add(Me.btnChooseDefaultFolder)
    Me.GroupBox2.Controls.Add(Me.chkAlwaysUseDefaultFolder)
    Me.GroupBox2.Controls.Add(Me.txtDefaultFolder)
    Me.GroupBox2.Controls.Add(Me.Label7)
    Me.GroupBox2.Controls.Add(Me.jpegQuality)
    Me.GroupBox2.Controls.Add(Me.Label6)
    Me.GroupBox2.Controls.Add(Me.btnDefaultFolder_choose)
    Me.GroupBox2.Location = New System.Drawing.Point(17, 72)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(445, 110)
    Me.GroupBox2.TabIndex = 0
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Dateiverwaltung"
    '
    'lnkExploreDefaultFolder
    '
    Me.lnkExploreDefaultFolder.AutoSize = True
    Me.lnkExploreDefaultFolder.Location = New System.Drawing.Point(360, 48)
    Me.lnkExploreDefaultFolder.Name = "lnkExploreDefaultFolder"
    Me.lnkExploreDefaultFolder.Size = New System.Drawing.Size(39, 13)
    Me.lnkExploreDefaultFolder.TabIndex = 15
    Me.lnkExploreDefaultFolder.TabStop = True
    Me.lnkExploreDefaultFolder.Text = "Öffnen"
    '
    'btnChooseDefaultFolder
    '
    Me.btnChooseDefaultFolder.Location = New System.Drawing.Point(404, 21)
    Me.btnChooseDefaultFolder.Name = "btnChooseDefaultFolder"
    Me.btnChooseDefaultFolder.Size = New System.Drawing.Size(35, 23)
    Me.btnChooseDefaultFolder.TabIndex = 14
    Me.btnChooseDefaultFolder.Text = "..."
    Me.btnChooseDefaultFolder.UseVisualStyleBackColor = True
    '
    'chkAlwaysUseDefaultFolder
    '
    Me.chkAlwaysUseDefaultFolder.AutoSize = True
    Me.chkAlwaysUseDefaultFolder.Location = New System.Drawing.Point(128, 47)
    Me.chkAlwaysUseDefaultFolder.Name = "chkAlwaysUseDefaultFolder"
    Me.chkAlwaysUseDefaultFolder.Size = New System.Drawing.Size(179, 17)
    Me.chkAlwaysUseDefaultFolder.TabIndex = 13
    Me.chkAlwaysUseDefaultFolder.Text = "Immer diesen Ordner verwenden"
    Me.ToolTip1.SetToolTip(Me.chkAlwaysUseDefaultFolder, "Verhindert, dass beim Speichern ein Dialogfeld erscheint, was nach Ort und Name f" &
        "ragt.")
    Me.chkAlwaysUseDefaultFolder.UseVisualStyleBackColor = True
    '
    'txtDefaultFolder
    '
    Me.txtDefaultFolder.Location = New System.Drawing.Point(128, 23)
    Me.txtDefaultFolder.Name = "txtDefaultFolder"
    Me.txtDefaultFolder.Size = New System.Drawing.Size(271, 20)
    Me.txtDefaultFolder.TabIndex = 5
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(12, 26)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(101, 13)
    Me.Label7.TabIndex = 4
    Me.Label7.Text = "Default-Speicherort:"
    '
    'jpegQuality
    '
    Me.jpegQuality.Location = New System.Drawing.Point(128, 74)
    Me.jpegQuality.Name = "jpegQuality"
    Me.jpegQuality.Size = New System.Drawing.Size(82, 20)
    Me.jpegQuality.TabIndex = 12
    Me.jpegQuality.Value = New Decimal(New Integer() {80, 0, 0, 0})
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(36, 76)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(76, 13)
    Me.Label6.TabIndex = 11
    Me.Label6.Text = "JPEG-Qualität:"
    '
    'btnDefaultFolder_choose
    '
    Me.btnDefaultFolder_choose.Location = New System.Drawing.Point(507, 25)
    Me.btnDefaultFolder_choose.Name = "btnDefaultFolder_choose"
    Me.btnDefaultFolder_choose.Size = New System.Drawing.Size(28, 24)
    Me.btnDefaultFolder_choose.TabIndex = 8
    Me.btnDefaultFolder_choose.Text = ">>"
    Me.btnDefaultFolder_choose.UseVisualStyleBackColor = True
    '
    'TabPage3
    '
    Me.TabPage3.Controls.Add(Me.GroupBox6)
    Me.TabPage3.Controls.Add(Me.GroupBox3)
    Me.TabPage3.Controls.Add(Me.GroupBox1)
    Me.TabPage3.Location = New System.Drawing.Point(4, 22)
    Me.TabPage3.Name = "TabPage3"
    Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage3.Size = New System.Drawing.Size(480, 465)
    Me.TabPage3.TabIndex = 6
    Me.TabPage3.Text = "TabPage3"
    Me.TabPage3.UseVisualStyleBackColor = True
    '
    'GroupBox6
    '
    Me.GroupBox6.Controls.Add(Me.lblImgurLogin)
    Me.GroupBox6.Controls.Add(Me.pnlImgurVerify)
    Me.GroupBox6.Controls.Add(Me.rbImgurLogin__on)
    Me.GroupBox6.Controls.Add(Me.rbImgurLogin__off)
    Me.GroupBox6.Location = New System.Drawing.Point(17, 151)
    Me.GroupBox6.Name = "GroupBox6"
    Me.GroupBox6.Size = New System.Drawing.Size(444, 87)
    Me.GroupBox6.TabIndex = 17
    Me.GroupBox6.TabStop = False
    Me.GroupBox6.Text = "Imgur.com"
    '
    'lblImgurLogin
    '
    Me.lblImgurLogin.Location = New System.Drawing.Point(15, 46)
    Me.lblImgurLogin.Name = "lblImgurLogin"
    Me.lblImgurLogin.Size = New System.Drawing.Size(423, 36)
    Me.lblImgurLogin.TabIndex = 6
    Me.lblImgurLogin.Text = "Label17"
    Me.lblImgurLogin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.lblImgurLogin.Visible = False
    '
    'pnlImgurVerify
    '
    Me.pnlImgurVerify.Controls.Add(Me.TextBox1)
    Me.pnlImgurVerify.Controls.Add(Me.Label16)
    Me.pnlImgurVerify.Controls.Add(Me.btnImgurAuth)
    Me.pnlImgurVerify.Enabled = False
    Me.pnlImgurVerify.Location = New System.Drawing.Point(9, 47)
    Me.pnlImgurVerify.Name = "pnlImgurVerify"
    Me.pnlImgurVerify.Size = New System.Drawing.Size(434, 39)
    Me.pnlImgurVerify.TabIndex = 5
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(218, 7)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(142, 20)
    Me.TextBox1.TabIndex = 4
    '
    'Label16
    '
    Me.Label16.AutoSize = True
    Me.Label16.Location = New System.Drawing.Point(5, 10)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(207, 13)
    Me.Label16.TabIndex = 3
    Me.Label16.Text = "Bitte hier den ""verification code"" einfügen:"
    '
    'btnImgurAuth
    '
    Me.btnImgurAuth.Location = New System.Drawing.Point(366, 5)
    Me.btnImgurAuth.Name = "btnImgurAuth"
    Me.btnImgurAuth.Size = New System.Drawing.Size(54, 23)
    Me.btnImgurAuth.TabIndex = 2
    Me.btnImgurAuth.Text = "OK"
    Me.btnImgurAuth.UseVisualStyleBackColor = True
    '
    'rbImgurLogin__on
    '
    Me.rbImgurLogin__on.AutoSize = True
    Me.rbImgurLogin__on.Location = New System.Drawing.Point(164, 19)
    Me.rbImgurLogin__on.Name = "rbImgurLogin__on"
    Me.rbImgurLogin__on.Size = New System.Drawing.Size(269, 17)
    Me.rbImgurLogin__on.TabIndex = 1
    Me.rbImgurLogin__on.Text = "einloggen und Bilder in eigenen Account hochladen"
    Me.rbImgurLogin__on.UseVisualStyleBackColor = True
    '
    'rbImgurLogin__off
    '
    Me.rbImgurLogin__off.AutoSize = True
    Me.rbImgurLogin__off.Checked = True
    Me.rbImgurLogin__off.Location = New System.Drawing.Point(17, 19)
    Me.rbImgurLogin__off.Name = "rbImgurLogin__off"
    Me.rbImgurLogin__off.Size = New System.Drawing.Size(134, 17)
    Me.rbImgurLogin__off.TabIndex = 0
    Me.rbImgurLogin__off.TabStop = True
    Me.rbImgurLogin__off.Text = "ohne Login verwenden"
    Me.rbImgurLogin__off.UseVisualStyleBackColor = True
    '
    'GroupBox3
    '
    Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.GroupBox3.Controls.Add(Me.txtProxyDOM)
    Me.GroupBox3.Controls.Add(Me.Label5)
    Me.GroupBox3.Controls.Add(Me.txtProxyPW)
    Me.GroupBox3.Controls.Add(Me.Label3)
    Me.GroupBox3.Controls.Add(Me.txtProxyUN)
    Me.GroupBox3.Controls.Add(Me.Label2)
    Me.GroupBox3.Location = New System.Drawing.Point(17, 251)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(445, 88)
    Me.GroupBox3.TabIndex = 15
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Proxy"
    '
    'txtProxyDOM
    '
    Me.txtProxyDOM.Location = New System.Drawing.Point(75, 23)
    Me.txtProxyDOM.Name = "txtProxyDOM"
    Me.txtProxyDOM.Size = New System.Drawing.Size(140, 20)
    Me.txtProxyDOM.TabIndex = 16
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(14, 26)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(47, 13)
    Me.Label5.TabIndex = 15
    Me.Label5.Text = "Host/IP:"
    '
    'txtProxyPW
    '
    Me.txtProxyPW.Location = New System.Drawing.Point(292, 49)
    Me.txtProxyPW.Name = "txtProxyPW"
    Me.txtProxyPW.Size = New System.Drawing.Size(137, 20)
    Me.txtProxyPW.TabIndex = 14
    Me.txtProxyPW.UseSystemPasswordChar = True
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(232, 52)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(56, 13)
    Me.Label3.TabIndex = 13
    Me.Label3.Text = "Password:"
    '
    'txtProxyUN
    '
    Me.txtProxyUN.Location = New System.Drawing.Point(75, 49)
    Me.txtProxyUN.Name = "txtProxyUN"
    Me.txtProxyUN.Size = New System.Drawing.Size(140, 20)
    Me.txtProxyUN.TabIndex = 12
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(11, 52)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(58, 13)
    Me.Label2.TabIndex = 11
    Me.Label2.Text = "Username:"
    '
    'GroupBox1
    '
    Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.GroupBox1.Controls.Add(Me.LinkLabel1)
    Me.GroupBox1.Controls.Add(Me.txtLoginPass)
    Me.GroupBox1.Controls.Add(Me.Label13)
    Me.GroupBox1.Controls.Add(Me.txtLoginUser)
    Me.GroupBox1.Controls.Add(Me.Label15)
    Me.GroupBox1.Controls.Add(Me.PictureBox2)
    Me.GroupBox1.Location = New System.Drawing.Point(17, 13)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(445, 122)
    Me.GroupBox1.TabIndex = 14
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "DropMe.de"
    '
    'LinkLabel1
    '
    Me.LinkLabel1.Location = New System.Drawing.Point(105, 80)
    Me.LinkLabel1.Name = "LinkLabel1"
    Me.LinkLabel1.Size = New System.Drawing.Size(312, 26)
    Me.LinkLabel1.TabIndex = 20
    Me.LinkLabel1.TabStop = True
    Me.LinkLabel1.Text = "Wenn du noch keinen Account hast, klicke hier, um DropMe.de aufzurufen."
    '
    'txtLoginPass
    '
    Me.txtLoginPass.Location = New System.Drawing.Point(223, 52)
    Me.txtLoginPass.Name = "txtLoginPass"
    Me.txtLoginPass.Size = New System.Drawing.Size(155, 20)
    Me.txtLoginPass.TabIndex = 19
    Me.txtLoginPass.UseSystemPasswordChar = True
    '
    'Label13
    '
    Me.Label13.AutoSize = True
    Me.Label13.Location = New System.Drawing.Point(105, 55)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(53, 13)
    Me.Label13.TabIndex = 18
    Me.Label13.Text = "Passwort:"
    '
    'txtLoginUser
    '
    Me.txtLoginUser.Location = New System.Drawing.Point(223, 26)
    Me.txtLoginUser.Name = "txtLoginUser"
    Me.txtLoginUser.Size = New System.Drawing.Size(155, 20)
    Me.txtLoginUser.TabIndex = 17
    '
    'Label15
    '
    Me.Label15.AutoSize = True
    Me.Label15.Location = New System.Drawing.Point(105, 29)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(112, 13)
    Me.Label15.TabIndex = 16
    Me.Label15.Text = "Benutzername/E-Mail:"
    '
    'PictureBox2
    '
    Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
    Me.PictureBox2.Location = New System.Drawing.Point(17, 26)
    Me.PictureBox2.Name = "PictureBox2"
    Me.PictureBox2.Size = New System.Drawing.Size(64, 64)
    Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
    Me.PictureBox2.TabIndex = 15
    Me.PictureBox2.TabStop = False
    '
    'imlWidgetIcons
    '
    Me.imlWidgetIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
    Me.imlWidgetIcons.ImageSize = New System.Drawing.Size(16, 16)
    Me.imlWidgetIcons.TransparentColor = System.Drawing.Color.Transparent
    '
    'ButtonListBar1
    '
    Me.ButtonListBar1.AutoScroll = True
    Me.ButtonListBar1.ButtonWidth = 96
    Me.ButtonListBar1.Dock = System.Windows.Forms.DockStyle.Left
    Me.ButtonListBar1.ImageList = Me.ImageList1
    Me.ButtonListBar1.Location = New System.Drawing.Point(0, 0)
    Me.ButtonListBar1.Name = "ButtonListBar1"
    Me.ButtonListBar1.Size = New System.Drawing.Size(98, 462)
    Me.ButtonListBar1.TabIndex = 1
    Me.ButtonListBar1.ToolTip = Nothing
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "SHELL32_274.ico")
    Me.ImageList1.Images.SetKeyName(1, "icwconn1_200.ico")
    Me.ImageList1.Images.SetKeyName(2, "ieframe_102.ico")
    Me.ImageList1.Images.SetKeyName(3, "moviemk.ico")
    Me.ImageList1.Images.SetKeyName(4, "dfshim_103.ico")
    Me.ImageList1.Images.SetKeyName(5, "gohome.png")
    Me.ImageList1.Images.SetKeyName(6, "pkColorPicker-32.png")
    Me.ImageList1.Images.SetKeyName(7, "SHELL32_303.ico")
    Me.ImageList1.Images.SetKeyName(8, "devenv_6826.ico")
    Me.ImageList1.Images.SetKeyName(9, "download32.ico")
    Me.ImageList1.Images.SetKeyName(10, "devenv_1200.ico")
    Me.ImageList1.Images.SetKeyName(11, "FRONTPG_464.ico")
    '
    'ofdChooseIcon
    '
    Me.ofdChooseIcon.Filter = "Tranparenz-unterstützende Bilddateien (*.png, *.gif)|*.png;*.gif|Alle Bilddateien" &
    " (*.png, *.gif, *.bmp, *.jpg)|*.png;*.gif;*.bmp;*.jpg|Alle Dateien|*"
    Me.ofdChooseIcon.Title = "Icon auswählen (bestenfalls 32x32) ..."
    '
    'frm_options
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(584, 462)
    Me.Controls.Add(Me.ButtonListBar1)
    Me.Controls.Add(Me.TabControl1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.MinimumSize = New System.Drawing.Size(600, 500)
    Me.Name = "frm_options"
    Me.ShowIcon = False
    Me.Text = "Optionen"
    Me.TabControl1.ResumeLayout(False)
    Me.TabPage1.ResumeLayout(False)
    Me.GroupBox5.ResumeLayout(False)
    Me.GroupBox5.PerformLayout()
    Me.GroupBox8.ResumeLayout(False)
    Me.GroupBox8.PerformLayout()
    Me.GroupBox7.ResumeLayout(False)
    Me.GroupBox7.PerformLayout()
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox4.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    CType(Me.jpegQuality, System.ComponentModel.ISupportInitialize).EndInit()
    Me.TabPage3.ResumeLayout(False)
    Me.GroupBox6.ResumeLayout(False)
    Me.GroupBox6.PerformLayout()
    Me.pnlImgurVerify.ResumeLayout(False)
    Me.pnlImgurVerify.PerformLayout()
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents ButtonListBar1 As ButtonListbar.vbAccelerator.Controls.ListBar.ButtonListBar
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
  Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
  Friend WithEvents ofdChooseIcon As System.Windows.Forms.OpenFileDialog
  Friend WithEvents imlWidgetIcons As System.Windows.Forms.ImageList
  Friend WithEvents checkHideWhileGrab As System.Windows.Forms.CheckBox
  Friend WithEvents btnDefaultFolder_choose As System.Windows.Forms.Button
  Friend WithEvents txtDefaultFolder As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents btnClose As System.Windows.Forms.Button
  Friend WithEvents jpegQuality As System.Windows.Forms.NumericUpDown
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
  Friend WithEvents txtProxyPW As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents txtProxyUN As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtProxyDOM As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents txtMainWinBG As System.Windows.Forms.TextBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents txtLoginPass As System.Windows.Forms.TextBox
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents txtLoginUser As System.Windows.Forms.TextBox
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents chk_disp_size_in_tb As System.Windows.Forms.CheckBox
  Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
  Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
  Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
  Friend WithEvents rbImgurLogin__on As System.Windows.Forms.RadioButton
  Friend WithEvents rbImgurLogin__off As System.Windows.Forms.RadioButton
  Friend WithEvents btnImgurAuth As System.Windows.Forms.Button
  Friend WithEvents pnlImgurVerify As System.Windows.Forms.Panel
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents lblImgurLogin As System.Windows.Forms.Label
  Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
  Friend WithEvents chkEnableHistory As System.Windows.Forms.CheckBox
  Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
  Friend WithEvents chkCollageHitTestIntersect As System.Windows.Forms.CheckBox
  Friend WithEvents chkAlwaysUseDefaultFolder As System.Windows.Forms.CheckBox
  Friend WithEvents btnChooseDefaultFolder As System.Windows.Forms.Button
  Friend WithEvents lnkExploreDefaultFolder As System.Windows.Forms.LinkLabel
  Friend WithEvents btnShowHistory As System.Windows.Forms.Button
  Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
  Friend WithEvents cmbHotkeyKey As System.Windows.Forms.ComboBox
  Friend WithEvents chkHotkeyWin As System.Windows.Forms.CheckBox
  Friend WithEvents chkHotkeyShift As System.Windows.Forms.CheckBox
  Friend WithEvents chkHotkeyAlt As System.Windows.Forms.CheckBox
  Friend WithEvents chkHotkeyCtrl As System.Windows.Forms.CheckBox
End Class
