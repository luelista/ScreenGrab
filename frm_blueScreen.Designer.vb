<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_blueScreen
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
  '<System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_blueScreen))
    Me.IGrid1Col0CellStyle = New TenTec.Windows.iGridLib.iGCellStyle(True)
    Me.IGrid1Col0ColHdrStyle = New TenTec.Windows.iGridLib.iGColHdrStyle(True)
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.pic_viewPartial = New System.Windows.Forms.PictureBox
    Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.GrabToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator
    Me.SchnellUploadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ImTeamWikiSpeichernToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.SpeichernUnterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.DruckenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.KopierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator
    Me.EinfügenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
    Me.MDIToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ViewerÖffnenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
    Me.ImmerImVordergrundToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.AusloggenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.OptionenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.tmr_checkAsyncKeyState = New System.Windows.Forms.Timer(Me.components)
    Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog
    Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
    Me.cmbZoom = New System.Windows.Forms.ComboBox
    Me.txtImageSizeHeight = New System.Windows.Forms.TextBox
    Me.txtImageSizeWidth = New System.Windows.Forms.TextBox
    Me.tbrZoom = New System.Windows.Forms.TrackBar
    Me.imlBrowseListviewPreview = New System.Windows.Forms.ImageList(Me.components)
    Me.tmr_asyncUpdatePartialView = New System.Windows.Forms.Timer(Me.components)
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
    Me.fntdialog_insertText = New System.Windows.Forms.FontDialog
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
    Me.bgwImageUpload = New System.ComponentModel.BackgroundWorker
    Me.tmrBogusProgressbar = New System.Windows.Forms.Timer(Me.components)
    Me.Button1 = New System.Windows.Forms.Button
    Me.btnPrint = New System.Windows.Forms.Button
    Me.btnUploadFile = New System.Windows.Forms.Button
    Me.btnSaveLocal = New System.Windows.Forms.Button
    Me.btnGrab = New System.Windows.Forms.Button
    Me.btnPaste = New System.Windows.Forms.Button
    Me.btnCopy = New System.Windows.Forms.Button
    Me.chk_blueScreenMode = New System.Windows.Forms.CheckBox
    Me.btnQuickUpload = New System.Windows.Forms.Button
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.Button3 = New System.Windows.Forms.Button
    Me.btnLogin = New System.Windows.Forms.Button
    Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
    Me.pnlViewPartial = New System.Windows.Forms.Panel
    Me.pnlSidebar = New System.Windows.Forms.Panel
    Me.lblLoginName = New System.Windows.Forms.Label
    Me.lblLoginMode = New System.Windows.Forms.Label
    Me.btnSaveToWeb = New System.Windows.Forms.Button
    Me.Label3 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.IGrid1DefaultCellStyle = New TenTec.Windows.iGridLib.iGCellStyle(True)
    Me.IGrid1DefaultColHdrStyle = New TenTec.Windows.iGridLib.iGColHdrStyle(True)
    Me.IGrid1RowTextColCellStyle = New TenTec.Windows.iGridLib.iGCellStyle(True)
    Me.pnlOpenedFile = New System.Windows.Forms.Panel
    Me.lnkCloseFileBar = New System.Windows.Forms.Label
    Me.lnkAddcolfile = New System.Windows.Forms.LinkLabel
    Me.lnkOpenfile = New System.Windows.Forms.LinkLabel
    Me.lnkUploadfile = New System.Windows.Forms.LinkLabel
    Me.txtOpenedFile = New System.Windows.Forms.TextBox
    Me.picOpenedFile = New System.Windows.Forms.PictureBox
    Me.Label4 = New System.Windows.Forms.Label
    CType(Me.pic_viewPartial, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.ContextMenuStrip1.SuspendLayout()
    CType(Me.tbrZoom, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.pnlViewPartial.SuspendLayout()
    Me.pnlSidebar.SuspendLayout()
    Me.pnlOpenedFile.SuspendLayout()
    CType(Me.picOpenedFile, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'IGrid1Col0CellStyle
    '
    Me.IGrid1Col0CellStyle.TextTrimming = TenTec.Windows.iGridLib.iGStringTrimming.None
    '
    'Panel1
    '
    Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.Panel1.Location = New System.Drawing.Point(651, 35)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(130, 225)
    Me.Panel1.TabIndex = 7
    Me.Panel1.Visible = False
    '
    'pic_viewPartial
    '
    Me.pic_viewPartial.BackColor = System.Drawing.Color.White
    Me.pic_viewPartial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
    Me.pic_viewPartial.Location = New System.Drawing.Point(0, 0)
    Me.pic_viewPartial.Name = "pic_viewPartial"
    Me.pic_viewPartial.Size = New System.Drawing.Size(595, 400)
    Me.pic_viewPartial.TabIndex = 8
    Me.pic_viewPartial.TabStop = False
    '
    'ContextMenuStrip1
    '
    Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GrabToolStripMenuItem, Me.ToolStripMenuItem4, Me.SchnellUploadToolStripMenuItem, Me.ImTeamWikiSpeichernToolStripMenuItem, Me.SpeichernUnterToolStripMenuItem, Me.DruckenToolStripMenuItem, Me.MDIToolStripMenuItem, Me.ToolStripMenuItem3, Me.KopierenToolStripMenuItem, Me.EinfügenToolStripMenuItem, Me.ToolStripMenuItem2, Me.ViewerÖffnenToolStripMenuItem, Me.ToolStripMenuItem1, Me.ImmerImVordergrundToolStripMenuItem, Me.AusloggenToolStripMenuItem, Me.OptionenToolStripMenuItem})
    Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
    Me.ContextMenuStrip1.Size = New System.Drawing.Size(255, 292)
    '
    'GrabToolStripMenuItem
    '
    Me.GrabToolStripMenuItem.Image = CType(resources.GetObject("GrabToolStripMenuItem.Image"), System.Drawing.Image)
    Me.GrabToolStripMenuItem.Name = "GrabToolStripMenuItem"
    Me.GrabToolStripMenuItem.ShortcutKeyDisplayString = "F2"
    Me.GrabToolStripMenuItem.Size = New System.Drawing.Size(254, 22)
    Me.GrabToolStripMenuItem.Text = "Grab"
    '
    'ToolStripMenuItem4
    '
    Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
    Me.ToolStripMenuItem4.Size = New System.Drawing.Size(251, 6)
    '
    'SchnellUploadToolStripMenuItem
    '
    Me.SchnellUploadToolStripMenuItem.Name = "SchnellUploadToolStripMenuItem"
    Me.SchnellUploadToolStripMenuItem.ShortcutKeyDisplayString = "Strg+ZS"
    Me.SchnellUploadToolStripMenuItem.Size = New System.Drawing.Size(254, 22)
    Me.SchnellUploadToolStripMenuItem.Text = "Schnell-Upload"
    '
    'ImTeamWikiSpeichernToolStripMenuItem
    '
    Me.ImTeamWikiSpeichernToolStripMenuItem.Name = "ImTeamWikiSpeichernToolStripMenuItem"
    Me.ImTeamWikiSpeichernToolStripMenuItem.ShortcutKeyDisplayString = "Strg+U"
    Me.ImTeamWikiSpeichernToolStripMenuItem.Size = New System.Drawing.Size(254, 22)
    Me.ImTeamWikiSpeichernToolStripMenuItem.Text = "Im TeamWiki speichern ..."
    '
    'SpeichernUnterToolStripMenuItem
    '
    Me.SpeichernUnterToolStripMenuItem.Image = CType(resources.GetObject("SpeichernUnterToolStripMenuItem.Image"), System.Drawing.Image)
    Me.SpeichernUnterToolStripMenuItem.Name = "SpeichernUnterToolStripMenuItem"
    Me.SpeichernUnterToolStripMenuItem.ShortcutKeyDisplayString = "Strg+S"
    Me.SpeichernUnterToolStripMenuItem.Size = New System.Drawing.Size(254, 22)
    Me.SpeichernUnterToolStripMenuItem.Text = "Lokal speichern ..."
    '
    'DruckenToolStripMenuItem
    '
    Me.DruckenToolStripMenuItem.Image = CType(resources.GetObject("DruckenToolStripMenuItem.Image"), System.Drawing.Image)
    Me.DruckenToolStripMenuItem.Name = "DruckenToolStripMenuItem"
    Me.DruckenToolStripMenuItem.ShortcutKeyDisplayString = "Strg+P"
    Me.DruckenToolStripMenuItem.Size = New System.Drawing.Size(254, 22)
    Me.DruckenToolStripMenuItem.Text = "Drucken"
    '
    'KopierenToolStripMenuItem
    '
    Me.KopierenToolStripMenuItem.Name = "KopierenToolStripMenuItem"
    Me.KopierenToolStripMenuItem.ShortcutKeyDisplayString = "Strg+C"
    Me.KopierenToolStripMenuItem.Size = New System.Drawing.Size(254, 22)
    Me.KopierenToolStripMenuItem.Text = "Kopieren"
    '
    'ToolStripMenuItem3
    '
    Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
    Me.ToolStripMenuItem3.Size = New System.Drawing.Size(251, 6)
    '
    'EinfügenToolStripMenuItem
    '
    Me.EinfügenToolStripMenuItem.Name = "EinfügenToolStripMenuItem"
    Me.EinfügenToolStripMenuItem.ShortcutKeyDisplayString = "Strg+V"
    Me.EinfügenToolStripMenuItem.Size = New System.Drawing.Size(254, 22)
    Me.EinfügenToolStripMenuItem.Text = "Einfügen"
    '
    'ToolStripMenuItem2
    '
    Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
    Me.ToolStripMenuItem2.Size = New System.Drawing.Size(251, 6)
    '
    'MDIToolStripMenuItem
    '
    Me.MDIToolStripMenuItem.Image = CType(resources.GetObject("MDIToolStripMenuItem.Image"), System.Drawing.Image)
    Me.MDIToolStripMenuItem.Name = "MDIToolStripMenuItem"
    Me.MDIToolStripMenuItem.ShortcutKeyDisplayString = "Strg+T"
    Me.MDIToolStripMenuItem.Size = New System.Drawing.Size(254, 22)
    Me.MDIToolStripMenuItem.Text = "Collage"
    '
    'ViewerÖffnenToolStripMenuItem
    '
    Me.ViewerÖffnenToolStripMenuItem.Name = "ViewerÖffnenToolStripMenuItem"
    Me.ViewerÖffnenToolStripMenuItem.Size = New System.Drawing.Size(254, 22)
    Me.ViewerÖffnenToolStripMenuItem.Text = "Screenshot-Directory öffnen"
    '
    'ToolStripMenuItem1
    '
    Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
    Me.ToolStripMenuItem1.Size = New System.Drawing.Size(251, 6)
    '
    'ImmerImVordergrundToolStripMenuItem
    '
    Me.ImmerImVordergrundToolStripMenuItem.CheckOnClick = True
    Me.ImmerImVordergrundToolStripMenuItem.Name = "ImmerImVordergrundToolStripMenuItem"
    Me.ImmerImVordergrundToolStripMenuItem.Size = New System.Drawing.Size(254, 22)
    Me.ImmerImVordergrundToolStripMenuItem.Text = "Immer im Vordergrund"
    '
    'AusloggenToolStripMenuItem
    '
    Me.AusloggenToolStripMenuItem.Name = "AusloggenToolStripMenuItem"
    Me.AusloggenToolStripMenuItem.Size = New System.Drawing.Size(254, 22)
    Me.AusloggenToolStripMenuItem.Text = "Login ..."
    '
    'OptionenToolStripMenuItem
    '
    Me.OptionenToolStripMenuItem.Image = CType(resources.GetObject("OptionenToolStripMenuItem.Image"), System.Drawing.Image)
    Me.OptionenToolStripMenuItem.Name = "OptionenToolStripMenuItem"
    Me.OptionenToolStripMenuItem.Size = New System.Drawing.Size(254, 22)
    Me.OptionenToolStripMenuItem.Text = "Optionen"
    '
    'tmr_checkAsyncKeyState
    '
    Me.tmr_checkAsyncKeyState.Enabled = True
    '
    'PrintDialog1
    '
    Me.PrintDialog1.UseEXDialog = True
    '
    'cmbZoom
    '
    Me.cmbZoom.ForeColor = System.Drawing.Color.Black
    Me.cmbZoom.FormattingEnabled = True
    Me.cmbZoom.Items.AddRange(New Object() {"50%", "60%", "70%", "80%", "90%", "100%", "150%", "200%", "300%"})
    Me.cmbZoom.Location = New System.Drawing.Point(3, 118)
    Me.cmbZoom.Name = "cmbZoom"
    Me.cmbZoom.Size = New System.Drawing.Size(64, 21)
    Me.cmbZoom.TabIndex = 26
    Me.cmbZoom.Text = "100%"
    '
    'txtImageSizeHeight
    '
    Me.txtImageSizeHeight.ForeColor = System.Drawing.Color.Black
    Me.txtImageSizeHeight.Location = New System.Drawing.Point(41, 408)
    Me.txtImageSizeHeight.Name = "txtImageSizeHeight"
    Me.txtImageSizeHeight.Size = New System.Drawing.Size(36, 20)
    Me.txtImageSizeHeight.TabIndex = 28
    '
    'txtImageSizeWidth
    '
    Me.txtImageSizeWidth.ForeColor = System.Drawing.Color.Black
    Me.txtImageSizeWidth.Location = New System.Drawing.Point(41, 382)
    Me.txtImageSizeWidth.Name = "txtImageSizeWidth"
    Me.txtImageSizeWidth.Size = New System.Drawing.Size(36, 20)
    Me.txtImageSizeWidth.TabIndex = 20
    '
    'tbrZoom
    '
    Me.tbrZoom.Location = New System.Drawing.Point(-5, 93)
    Me.tbrZoom.Maximum = 500
    Me.tbrZoom.Minimum = 10
    Me.tbrZoom.Name = "tbrZoom"
    Me.tbrZoom.Size = New System.Drawing.Size(92, 45)
    Me.tbrZoom.TabIndex = 24
    Me.tbrZoom.TickFrequency = 0
    Me.tbrZoom.TickStyle = System.Windows.Forms.TickStyle.None
    Me.tbrZoom.Value = 100
    '
    'imlBrowseListviewPreview
    '
    Me.imlBrowseListviewPreview.ImageStream = CType(resources.GetObject("imlBrowseListviewPreview.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.imlBrowseListviewPreview.TransparentColor = System.Drawing.Color.Transparent
    Me.imlBrowseListviewPreview.Images.SetKeyName(0, "kblackbox.png")
    '
    'tmr_asyncUpdatePartialView
    '
    Me.tmr_asyncUpdatePartialView.Interval = 300
    '
    'fntdialog_insertText
    '
    Me.fntdialog_insertText.ShowColor = True
    '
    'OpenFileDialog1
    '
    Me.OpenFileDialog1.FileName = "OpenFileDialog1"
    '
    'Button1
    '
    Me.Button1.BackColor = System.Drawing.Color.LightSteelBlue
    Me.Button1.Location = New System.Drawing.Point(2, 308)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(81, 23)
    Me.Button1.TabIndex = 30
    Me.Button1.Text = "Collage"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'btnPrint
    '
    Me.btnPrint.BackColor = System.Drawing.Color.LightSteelBlue
    Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
    Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.btnPrint.Location = New System.Drawing.Point(2, 143)
    Me.btnPrint.Name = "btnPrint"
    Me.btnPrint.Size = New System.Drawing.Size(81, 53)
    Me.btnPrint.TabIndex = 27
    Me.btnPrint.Text = "Drucken"
    Me.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.ToolTip1.SetToolTip(Me.btnPrint, "Uploaden und die URL in die Zwischenablage kopieren" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Achtung: Diese Bilder sind t" & _
            "emporär und werden nach 1-2 Monaten gelöscht!")
    Me.btnPrint.UseVisualStyleBackColor = True
    '
    'btnUploadFile
    '
    Me.btnUploadFile.BackColor = System.Drawing.Color.LightSteelBlue
    Me.btnUploadFile.Enabled = False
    Me.btnUploadFile.Location = New System.Drawing.Point(2, 331)
    Me.btnUploadFile.Name = "btnUploadFile"
    Me.btnUploadFile.Size = New System.Drawing.Size(81, 37)
    Me.btnUploadFile.TabIndex = 26
    Me.btnUploadFile.Text = "Datei" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "hochladen"
    Me.btnUploadFile.UseVisualStyleBackColor = True
    '
    'btnSaveLocal
    '
    Me.btnSaveLocal.BackColor = System.Drawing.Color.LightSteelBlue
    Me.btnSaveLocal.Location = New System.Drawing.Point(2, 285)
    Me.btnSaveLocal.Name = "btnSaveLocal"
    Me.btnSaveLocal.Size = New System.Drawing.Size(81, 23)
    Me.btnSaveLocal.TabIndex = 25
    Me.btnSaveLocal.Text = "Speichern"
    Me.btnSaveLocal.UseVisualStyleBackColor = True
    '
    'btnGrab
    '
    Me.btnGrab.BackColor = System.Drawing.Color.LightSteelBlue
    Me.btnGrab.Image = CType(resources.GetObject("btnGrab.Image"), System.Drawing.Image)
    Me.btnGrab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.btnGrab.Location = New System.Drawing.Point(2, 23)
    Me.btnGrab.Name = "btnGrab"
    Me.btnGrab.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
    Me.btnGrab.Size = New System.Drawing.Size(81, 24)
    Me.btnGrab.TabIndex = 6
    Me.btnGrab.Text = "G R A B"
    Me.btnGrab.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.ToolTip1.SetToolTip(Me.btnGrab, "Bildschirmausschnitt per Auswahlrechteck wählen")
    Me.btnGrab.UseVisualStyleBackColor = True
    '
    'btnPaste
    '
    Me.btnPaste.BackColor = System.Drawing.Color.LightSteelBlue
    Me.btnPaste.Image = CType(resources.GetObject("btnPaste.Image"), System.Drawing.Image)
    Me.btnPaste.Location = New System.Drawing.Point(40, 242)
    Me.btnPaste.Name = "btnPaste"
    Me.btnPaste.Size = New System.Drawing.Size(43, 39)
    Me.btnPaste.TabIndex = 4
    Me.btnPaste.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.ToolTip1.SetToolTip(Me.btnPaste, "Einfügen")
    Me.btnPaste.UseVisualStyleBackColor = True
    '
    'btnCopy
    '
    Me.btnCopy.BackColor = System.Drawing.Color.LightSteelBlue
    Me.btnCopy.Image = CType(resources.GetObject("btnCopy.Image"), System.Drawing.Image)
    Me.btnCopy.Location = New System.Drawing.Point(2, 242)
    Me.btnCopy.Name = "btnCopy"
    Me.btnCopy.Size = New System.Drawing.Size(40, 39)
    Me.btnCopy.TabIndex = 3
    Me.btnCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.ToolTip1.SetToolTip(Me.btnCopy, "Kopieren")
    Me.btnCopy.UseVisualStyleBackColor = True
    '
    'chk_blueScreenMode
    '
    Me.chk_blueScreenMode.ForeColor = System.Drawing.Color.White
    Me.chk_blueScreenMode.Location = New System.Drawing.Point(3, 2)
    Me.chk_blueScreenMode.Name = "chk_blueScreenMode"
    Me.chk_blueScreenMode.Size = New System.Drawing.Size(80, 20)
    Me.chk_blueScreenMode.TabIndex = 0
    Me.chk_blueScreenMode.Text = "blueScreen"
    Me.chk_blueScreenMode.UseVisualStyleBackColor = True
    '
    'btnQuickUpload
    '
    Me.btnQuickUpload.BackColor = System.Drawing.Color.LightSteelBlue
    Me.btnQuickUpload.Image = CType(resources.GetObject("btnQuickUpload.Image"), System.Drawing.Image)
    Me.btnQuickUpload.Location = New System.Drawing.Point(2, 48)
    Me.btnQuickUpload.Name = "btnQuickUpload"
    Me.btnQuickUpload.Size = New System.Drawing.Size(81, 43)
    Me.btnQuickUpload.TabIndex = 1
    Me.btnQuickUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.ToolTip1.SetToolTip(Me.btnQuickUpload, "Schnell-Upload:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Uploaden und die URL in die Zwischenablage kopieren" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Achtung: Di" & _
            "ese Bilder sind temporär und werden nach 1-2 Monaten gelöscht!")
    Me.btnQuickUpload.UseVisualStyleBackColor = True
    '
    'Button3
    '
    Me.Button3.BackColor = System.Drawing.Color.LightSteelBlue
    Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
    Me.Button3.Location = New System.Drawing.Point(2, 444)
    Me.Button3.Name = "Button3"
    Me.Button3.Size = New System.Drawing.Size(81, 41)
    Me.Button3.TabIndex = 36
    Me.ToolTip1.SetToolTip(Me.Button3, "Hilfe")
    Me.Button3.UseVisualStyleBackColor = True
    '
    'btnLogin
    '
    Me.btnLogin.BackColor = System.Drawing.Color.LightSteelBlue
    Me.btnLogin.Image = CType(resources.GetObject("btnLogin.Image"), System.Drawing.Image)
    Me.btnLogin.Location = New System.Drawing.Point(2, 507)
    Me.btnLogin.Name = "btnLogin"
    Me.btnLogin.Size = New System.Drawing.Size(81, 44)
    Me.btnLogin.TabIndex = 40
    Me.ToolTip1.SetToolTip(Me.btnLogin, "Hilfe")
    Me.btnLogin.UseVisualStyleBackColor = True
    '
    'NotifyIcon1
    '
    Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
    Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
    Me.NotifyIcon1.Text = "ScreenGrab 5"
    Me.NotifyIcon1.Visible = True
    '
    'pnlViewPartial
    '
    Me.pnlViewPartial.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.pnlViewPartial.AutoScroll = True
    Me.pnlViewPartial.BackColor = System.Drawing.Color.WhiteSmoke
    Me.pnlViewPartial.ContextMenuStrip = Me.ContextMenuStrip1
    Me.pnlViewPartial.Controls.Add(Me.pic_viewPartial)
    Me.pnlViewPartial.Location = New System.Drawing.Point(88, 0)
    Me.pnlViewPartial.Name = "pnlViewPartial"
    Me.pnlViewPartial.Size = New System.Drawing.Size(713, 591)
    Me.pnlViewPartial.TabIndex = 24
    '
    'pnlSidebar
    '
    Me.pnlSidebar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(78, Byte), Integer))
    Me.pnlSidebar.Controls.Add(Me.btnLogin)
    Me.pnlSidebar.Controls.Add(Me.lblLoginName)
    Me.pnlSidebar.Controls.Add(Me.lblLoginMode)
    Me.pnlSidebar.Controls.Add(Me.Button3)
    Me.pnlSidebar.Controls.Add(Me.btnSaveToWeb)
    Me.pnlSidebar.Controls.Add(Me.Button1)
    Me.pnlSidebar.Controls.Add(Me.btnPrint)
    Me.pnlSidebar.Controls.Add(Me.cmbZoom)
    Me.pnlSidebar.Controls.Add(Me.btnUploadFile)
    Me.pnlSidebar.Controls.Add(Me.btnSaveLocal)
    Me.pnlSidebar.Controls.Add(Me.txtImageSizeHeight)
    Me.pnlSidebar.Controls.Add(Me.btnGrab)
    Me.pnlSidebar.Controls.Add(Me.txtImageSizeWidth)
    Me.pnlSidebar.Controls.Add(Me.btnPaste)
    Me.pnlSidebar.Controls.Add(Me.btnCopy)
    Me.pnlSidebar.Controls.Add(Me.chk_blueScreenMode)
    Me.pnlSidebar.Controls.Add(Me.btnQuickUpload)
    Me.pnlSidebar.Controls.Add(Me.tbrZoom)
    Me.pnlSidebar.Controls.Add(Me.Label3)
    Me.pnlSidebar.Controls.Add(Me.Label2)
    Me.pnlSidebar.Location = New System.Drawing.Point(0, -2)
    Me.pnlSidebar.Name = "pnlSidebar"
    Me.pnlSidebar.Size = New System.Drawing.Size(88, 600)
    Me.pnlSidebar.TabIndex = 23
    '
    'lblLoginName
    '
    Me.lblLoginName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblLoginName.Location = New System.Drawing.Point(2, 573)
    Me.lblLoginName.Name = "lblLoginName"
    Me.lblLoginName.Size = New System.Drawing.Size(81, 19)
    Me.lblLoginName.TabIndex = 39
    Me.lblLoginName.Text = "Username"
    Me.lblLoginName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'lblLoginMode
    '
    Me.lblLoginMode.Location = New System.Drawing.Point(2, 555)
    Me.lblLoginMode.Name = "lblLoginMode"
    Me.lblLoginMode.Size = New System.Drawing.Size(81, 14)
    Me.lblLoginMode.TabIndex = 38
    Me.lblLoginMode.Text = "Offline" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Modus"
    Me.lblLoginMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'btnSaveToWeb
    '
    Me.btnSaveToWeb.BackColor = System.Drawing.Color.LightSteelBlue
    Me.btnSaveToWeb.Location = New System.Drawing.Point(2, 199)
    Me.btnSaveToWeb.Name = "btnSaveToWeb"
    Me.btnSaveToWeb.Size = New System.Drawing.Size(81, 41)
    Me.btnSaveToWeb.TabIndex = 35
    Me.btnSaveToWeb.Text = "Im TeamWiki" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "speichern"
    Me.btnSaveToWeb.UseVisualStyleBackColor = True
    '
    'Label3
    '
    Me.Label3.ForeColor = System.Drawing.Color.White
    Me.Label3.Location = New System.Drawing.Point(3, 385)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(37, 13)
    Me.Label3.TabIndex = 34
    Me.Label3.Text = "Breite:"
    '
    'Label2
    '
    Me.Label2.ForeColor = System.Drawing.Color.White
    Me.Label2.Location = New System.Drawing.Point(3, 411)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(38, 20)
    Me.Label2.TabIndex = 33
    Me.Label2.Text = "Höhe:"
    '
    'pnlOpenedFile
    '
    Me.pnlOpenedFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.pnlOpenedFile.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(225, Byte), Integer))
    Me.pnlOpenedFile.Controls.Add(Me.lnkCloseFileBar)
    Me.pnlOpenedFile.Controls.Add(Me.lnkAddcolfile)
    Me.pnlOpenedFile.Controls.Add(Me.lnkOpenfile)
    Me.pnlOpenedFile.Controls.Add(Me.lnkUploadfile)
    Me.pnlOpenedFile.Controls.Add(Me.txtOpenedFile)
    Me.pnlOpenedFile.Controls.Add(Me.picOpenedFile)
    Me.pnlOpenedFile.Controls.Add(Me.Label4)
    Me.pnlOpenedFile.Location = New System.Drawing.Point(88, 0)
    Me.pnlOpenedFile.Name = "pnlOpenedFile"
    Me.pnlOpenedFile.Size = New System.Drawing.Size(713, 91)
    Me.pnlOpenedFile.TabIndex = 25
    Me.pnlOpenedFile.Visible = False
    '
    'lnkCloseFileBar
    '
    Me.lnkCloseFileBar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lnkCloseFileBar.Cursor = System.Windows.Forms.Cursors.Hand
    Me.lnkCloseFileBar.Image = CType(resources.GetObject("lnkCloseFileBar.Image"), System.Drawing.Image)
    Me.lnkCloseFileBar.Location = New System.Drawing.Point(677, 9)
    Me.lnkCloseFileBar.Name = "lnkCloseFileBar"
    Me.lnkCloseFileBar.Size = New System.Drawing.Size(24, 24)
    Me.lnkCloseFileBar.TabIndex = 6
    '
    'lnkAddcolfile
    '
    Me.lnkAddcolfile.AutoSize = True
    Me.lnkAddcolfile.Location = New System.Drawing.Point(251, 69)
    Me.lnkAddcolfile.Name = "lnkAddcolfile"
    Me.lnkAddcolfile.Size = New System.Drawing.Size(113, 13)
    Me.lnkAddcolfile.TabIndex = 5
    Me.lnkAddcolfile.TabStop = True
    Me.lnkAddcolfile.Text = "Zu Collage hinzufügen"
    '
    'lnkOpenfile
    '
    Me.lnkOpenfile.AutoSize = True
    Me.lnkOpenfile.Location = New System.Drawing.Point(119, 69)
    Me.lnkOpenfile.Name = "lnkOpenfile"
    Me.lnkOpenfile.Size = New System.Drawing.Size(115, 13)
    Me.lnkOpenfile.TabIndex = 4
    Me.lnkOpenfile.TabStop = True
    Me.lnkOpenfile.Text = "Im Hauptfenster öffnen"
    '
    'lnkUploadfile
    '
    Me.lnkUploadfile.AutoSize = True
    Me.lnkUploadfile.Location = New System.Drawing.Point(19, 69)
    Me.lnkUploadfile.Name = "lnkUploadfile"
    Me.lnkUploadfile.Size = New System.Drawing.Size(85, 13)
    Me.lnkUploadfile.TabIndex = 3
    Me.lnkUploadfile.TabStop = True
    Me.lnkUploadfile.Text = "Datei hochladen"
    '
    'txtOpenedFile
    '
    Me.txtOpenedFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtOpenedFile.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(225, Byte), Integer))
    Me.txtOpenedFile.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.txtOpenedFile.Location = New System.Drawing.Point(63, 31)
    Me.txtOpenedFile.Multiline = True
    Me.txtOpenedFile.Name = "txtOpenedFile"
    Me.txtOpenedFile.Size = New System.Drawing.Size(619, 30)
    Me.txtOpenedFile.TabIndex = 2
    '
    'picOpenedFile
    '
    Me.picOpenedFile.Location = New System.Drawing.Point(22, 30)
    Me.picOpenedFile.Name = "picOpenedFile"
    Me.picOpenedFile.Size = New System.Drawing.Size(32, 32)
    Me.picOpenedFile.TabIndex = 1
    Me.picOpenedFile.TabStop = False
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(18, 9)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(223, 13)
    Me.Label4.TabIndex = 0
    Me.Label4.Text = "Die folgende Datei wurde ausgewählt:"
    '
    'frm_blueScreen
    '
    Me.AllowDrop = True
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(801, 591)
    Me.Controls.Add(Me.pnlOpenedFile)
    Me.Controls.Add(Me.pnlSidebar)
    Me.Controls.Add(Me.Panel1)
    Me.Controls.Add(Me.pnlViewPartial)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.KeyPreview = True
    Me.Name = "frm_blueScreen"
    Me.Text = "ScreenGrab 5"
    CType(Me.pic_viewPartial, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ContextMenuStrip1.ResumeLayout(False)
    CType(Me.tbrZoom, System.ComponentModel.ISupportInitialize).EndInit()
    Me.pnlViewPartial.ResumeLayout(False)
    Me.pnlSidebar.ResumeLayout(False)
    Me.pnlSidebar.PerformLayout()
    Me.pnlOpenedFile.ResumeLayout(False)
    Me.pnlOpenedFile.PerformLayout()
    CType(Me.picOpenedFile, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents pic_viewPartial As System.Windows.Forms.PictureBox
  Friend WithEvents tmr_checkAsyncKeyState As System.Windows.Forms.Timer
  Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
  Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
  Friend WithEvents txtImageSizeWidth As System.Windows.Forms.TextBox
  Friend WithEvents tmr_asyncUpdatePartialView As System.Windows.Forms.Timer
  Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
  Friend WithEvents imlBrowseListviewPreview As System.Windows.Forms.ImageList
  Friend WithEvents txtImageSizeHeight As System.Windows.Forms.TextBox
  Friend WithEvents fntdialog_insertText As System.Windows.Forms.FontDialog
  Friend WithEvents cmbZoom As System.Windows.Forms.ComboBox
  Friend WithEvents tbrZoom As System.Windows.Forms.TrackBar
  Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
  Friend WithEvents bgwImageUpload As System.ComponentModel.BackgroundWorker
  Friend WithEvents tmrBogusProgressbar As System.Windows.Forms.Timer
  Friend WithEvents btnQuickUpload As System.Windows.Forms.Button
  Friend WithEvents chk_blueScreenMode As System.Windows.Forms.CheckBox
  Friend WithEvents btnGrab As System.Windows.Forms.Button
  Friend WithEvents btnPaste As System.Windows.Forms.Button
  Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
  Friend WithEvents btnCopy As System.Windows.Forms.Button
  Friend WithEvents btnUploadFile As System.Windows.Forms.Button
  Friend WithEvents btnSaveLocal As System.Windows.Forms.Button
  Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
  Friend WithEvents btnPrint As System.Windows.Forms.Button
  Friend WithEvents GrabToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents SchnellUploadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents SpeichernUnterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents KopierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents EinfügenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ViewerÖffnenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents MDIToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ImmerImVordergrundToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents AusloggenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents OptionenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents DruckenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
  Friend WithEvents pnlViewPartial As System.Windows.Forms.Panel
  Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents pnlSidebar As System.Windows.Forms.Panel
  Friend WithEvents IGrid1DefaultCellStyle As TenTec.Windows.iGridLib.iGCellStyle
  Friend WithEvents IGrid1DefaultColHdrStyle As TenTec.Windows.iGridLib.iGColHdrStyle
  Friend WithEvents IGrid1RowTextColCellStyle As TenTec.Windows.iGridLib.iGCellStyle
  Friend WithEvents IGrid1Col0CellStyle As TenTec.Windows.iGridLib.iGCellStyle
  Friend WithEvents IGrid1Col0ColHdrStyle As TenTec.Windows.iGridLib.iGColHdrStyle
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents btnSaveToWeb As System.Windows.Forms.Button
  Friend WithEvents pnlOpenedFile As System.Windows.Forms.Panel
  Friend WithEvents txtOpenedFile As System.Windows.Forms.TextBox
  Friend WithEvents picOpenedFile As System.Windows.Forms.PictureBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents lnkAddcolfile As System.Windows.Forms.LinkLabel
  Friend WithEvents lnkOpenfile As System.Windows.Forms.LinkLabel
  Friend WithEvents lnkUploadfile As System.Windows.Forms.LinkLabel
  Friend WithEvents lnkCloseFileBar As System.Windows.Forms.Label
  Friend WithEvents Button3 As System.Windows.Forms.Button
  Friend WithEvents lblLoginName As System.Windows.Forms.Label
  Friend WithEvents lblLoginMode As System.Windows.Forms.Label
  Friend WithEvents btnLogin As System.Windows.Forms.Button
  Friend WithEvents ImTeamWikiSpeichernToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
