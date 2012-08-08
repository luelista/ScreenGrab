<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
    Me.components = New System.ComponentModel.Container
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_options))
    Me.TabControl1 = New System.Windows.Forms.TabControl
    Me.TabPage1 = New System.Windows.Forms.TabPage
    Me.GroupBox8 = New System.Windows.Forms.GroupBox
    Me.chkCollageHitTestIntersect = New System.Windows.Forms.CheckBox
    Me.btnClose = New System.Windows.Forms.Button
    Me.TabPage4 = New System.Windows.Forms.TabPage
    Me.qq_TextBox2 = New System.Windows.Forms.TextBox
    Me.LinkLabel5 = New System.Windows.Forms.LinkLabel
    Me.Label19 = New System.Windows.Forms.Label
    Me.PictureBox1 = New System.Windows.Forms.PictureBox
    Me.LinkLabel4 = New System.Windows.Forms.LinkLabel
    Me.LinkLabel3 = New System.Windows.Forms.LinkLabel
    Me.Label18 = New System.Windows.Forms.Label
    Me.Label17 = New System.Windows.Forms.Label
    Me.lblProgVer = New System.Windows.Forms.Label
    Me.lblProgName = New System.Windows.Forms.Label
    Me.imlWidgetIcons = New System.Windows.Forms.ImageList(Me.components)
    Me.ButtonListBar1 = New ButtonListbar.vbAccelerator.Controls.ListBar.ButtonListBar
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ofdChooseIcon = New System.Windows.Forms.OpenFileDialog
    Me.PictureBox2 = New System.Windows.Forms.PictureBox
    Me.Label15 = New System.Windows.Forms.Label
    Me.txtLoginUser = New System.Windows.Forms.TextBox
    Me.Label13 = New System.Windows.Forms.Label
    Me.txtLoginPass = New System.Windows.Forms.TextBox
    Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
    Me.GroupBox1 = New System.Windows.Forms.GroupBox
    Me.Label2 = New System.Windows.Forms.Label
    Me.txtProxyUN = New System.Windows.Forms.TextBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.txtProxyPW = New System.Windows.Forms.TextBox
    Me.Label5 = New System.Windows.Forms.Label
    Me.txtProxyDOM = New System.Windows.Forms.TextBox
    Me.GroupBox3 = New System.Windows.Forms.GroupBox
    Me.TabControl1.SuspendLayout()
    Me.TabPage1.SuspendLayout()
    Me.GroupBox8.SuspendLayout()
    Me.TabPage4.SuspendLayout()
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabControl1
    '
    Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TabControl1.Controls.Add(Me.TabPage1)
    Me.TabControl1.Controls.Add(Me.TabPage4)
    Me.TabControl1.Location = New System.Drawing.Point(100, 0)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(488, 491)
    Me.TabControl1.TabIndex = 0
    '
    'TabPage1
    '
    Me.TabPage1.Controls.Add(Me.GroupBox3)
    Me.TabPage1.Controls.Add(Me.GroupBox8)
    Me.TabPage1.Controls.Add(Me.btnClose)
    Me.TabPage1.Controls.Add(Me.GroupBox1)
    Me.TabPage1.Location = New System.Drawing.Point(4, 22)
    Me.TabPage1.Name = "TabPage1"
    Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage1.Size = New System.Drawing.Size(480, 465)
    Me.TabPage1.TabIndex = 4
    Me.TabPage1.Text = "TabPage1"
    Me.TabPage1.UseVisualStyleBackColor = True
    '
    'GroupBox8
    '
    Me.GroupBox8.Controls.Add(Me.chkCollageHitTestIntersect)
    Me.GroupBox8.Location = New System.Drawing.Point(18, 20)
    Me.GroupBox8.Name = "GroupBox8"
    Me.GroupBox8.Size = New System.Drawing.Size(445, 57)
    Me.GroupBox8.TabIndex = 18
    Me.GroupBox8.TabStop = False
    Me.GroupBox8.Text = "Auswahl"
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
    'btnClose
    '
    Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
    Me.btnClose.Location = New System.Drawing.Point(322, 422)
    Me.btnClose.Name = "btnClose"
    Me.btnClose.Size = New System.Drawing.Size(126, 31)
    Me.btnClose.TabIndex = 3
    Me.btnClose.Text = "Schließen"
    Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.btnClose.UseVisualStyleBackColor = True
    '
    'TabPage4
    '
    Me.TabPage4.BackColor = System.Drawing.Color.DarkOliveGreen
    Me.TabPage4.Controls.Add(Me.qq_TextBox2)
    Me.TabPage4.Controls.Add(Me.LinkLabel5)
    Me.TabPage4.Controls.Add(Me.Label19)
    Me.TabPage4.Controls.Add(Me.PictureBox1)
    Me.TabPage4.Controls.Add(Me.LinkLabel4)
    Me.TabPage4.Controls.Add(Me.LinkLabel3)
    Me.TabPage4.Controls.Add(Me.Label18)
    Me.TabPage4.Controls.Add(Me.Label17)
    Me.TabPage4.Controls.Add(Me.lblProgVer)
    Me.TabPage4.Controls.Add(Me.lblProgName)
    Me.TabPage4.Location = New System.Drawing.Point(4, 22)
    Me.TabPage4.Name = "TabPage4"
    Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage4.Size = New System.Drawing.Size(480, 465)
    Me.TabPage4.TabIndex = 7
    Me.TabPage4.Text = "TabPage4"
    '
    'qq_TextBox2
    '
    Me.qq_TextBox2.Location = New System.Drawing.Point(39, 227)
    Me.qq_TextBox2.Multiline = True
    Me.qq_TextBox2.Name = "qq_TextBox2"
    Me.qq_TextBox2.ReadOnly = True
    Me.qq_TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.qq_TextBox2.Size = New System.Drawing.Size(415, 64)
    Me.qq_TextBox2.TabIndex = 11
    Me.qq_TextBox2.Text = resources.GetString("qq_TextBox2.Text")
    '
    'LinkLabel5
    '
    Me.LinkLabel5.AutoSize = True
    Me.LinkLabel5.BackColor = System.Drawing.Color.Transparent
    Me.LinkLabel5.LinkColor = System.Drawing.Color.White
    Me.LinkLabel5.Location = New System.Drawing.Point(101, 156)
    Me.LinkLabel5.Name = "LinkLabel5"
    Me.LinkLabel5.Size = New System.Drawing.Size(77, 13)
    Me.LinkLabel5.TabIndex = 10
    Me.LinkLabel5.TabStop = True
    Me.LinkLabel5.Tag = "https://www.facebook.com/apps/application.php?id=109707115775453&sk=wall"
    Me.LinkLabel5.Text = "Seite anzeigen"
    Me.ToolTip1.SetToolTip(Me.LinkLabel5, "https://www.facebook.com/apps/application.php?id=109707115775453&sk=wall")
    '
    'Label19
    '
    Me.Label19.AutoSize = True
    Me.Label19.BackColor = System.Drawing.Color.Transparent
    Me.Label19.ForeColor = System.Drawing.Color.White
    Me.Label19.Location = New System.Drawing.Point(37, 156)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(58, 13)
    Me.Label19.TabIndex = 9
    Me.Label19.Text = "Facebook:"
    '
    'PictureBox1
    '
    Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
    Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
    Me.PictureBox1.Location = New System.Drawing.Point(326, 21)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(128, 128)
    Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
    Me.PictureBox1.TabIndex = 8
    Me.PictureBox1.TabStop = False
    '
    'LinkLabel4
    '
    Me.LinkLabel4.AutoSize = True
    Me.LinkLabel4.BackColor = System.Drawing.Color.Transparent
    Me.LinkLabel4.LinkColor = System.Drawing.Color.White
    Me.LinkLabel4.Location = New System.Drawing.Point(101, 128)
    Me.LinkLabel4.Name = "LinkLabel4"
    Me.LinkLabel4.Size = New System.Drawing.Size(196, 13)
    Me.LinkLabel4.TabIndex = 7
    Me.LinkLabel4.TabStop = True
    Me.LinkLabel4.Tag = "http://www.max-weller.de/screengrab-6"
    Me.LinkLabel4.Text = "http://www.max-weller.de/screengrab-6"
    '
    'LinkLabel3
    '
    Me.LinkLabel3.AutoSize = True
    Me.LinkLabel3.BackColor = System.Drawing.Color.Transparent
    Me.LinkLabel3.LinkColor = System.Drawing.Color.White
    Me.LinkLabel3.Location = New System.Drawing.Point(101, 105)
    Me.LinkLabel3.Name = "LinkLabel3"
    Me.LinkLabel3.Size = New System.Drawing.Size(103, 13)
    Me.LinkLabel3.TabIndex = 6
    Me.LinkLabel3.TabStop = True
    Me.LinkLabel3.Tag = "http://screengrab.tk"
    Me.LinkLabel3.Text = "http://screengrab.tk"
    '
    'Label18
    '
    Me.Label18.AutoSize = True
    Me.Label18.BackColor = System.Drawing.Color.Transparent
    Me.Label18.ForeColor = System.Drawing.Color.White
    Me.Label18.Location = New System.Drawing.Point(37, 105)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(62, 13)
    Me.Label18.TabIndex = 5
    Me.Label18.Text = "Homepage:"
    '
    'Label17
    '
    Me.Label17.AutoSize = True
    Me.Label17.BackColor = System.Drawing.Color.Transparent
    Me.Label17.ForeColor = System.Drawing.Color.White
    Me.Label17.Location = New System.Drawing.Point(37, 184)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(190, 52)
    Me.Label17.TabIndex = 4
    Me.Label17.Text = "Copyright (c) 2009-2012 by Max Weller" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Credits:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
    '
    'lblProgVer
    '
    Me.lblProgVer.AutoSize = True
    Me.lblProgVer.BackColor = System.Drawing.Color.Transparent
    Me.lblProgVer.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblProgVer.ForeColor = System.Drawing.Color.White
    Me.lblProgVer.Location = New System.Drawing.Point(136, 21)
    Me.lblProgVer.Name = "lblProgVer"
    Me.lblProgVer.Size = New System.Drawing.Size(139, 73)
    Me.lblProgVer.TabIndex = 1
    Me.lblProgVer.Text = "X.X"
    '
    'lblProgName
    '
    Me.lblProgName.AutoSize = True
    Me.lblProgName.BackColor = System.Drawing.Color.Transparent
    Me.lblProgName.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblProgName.ForeColor = System.Drawing.Color.White
    Me.lblProgName.Location = New System.Drawing.Point(36, 44)
    Me.lblProgName.Name = "lblProgName"
    Me.lblProgName.Size = New System.Drawing.Size(97, 29)
    Me.lblProgName.TabIndex = 0
    Me.lblProgName.Text = "Collage"
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
    Me.ImageList1.Images.SetKeyName(2, "moviemk.ico")
    Me.ImageList1.Images.SetKeyName(3, "dfshim_103.ico")
    Me.ImageList1.Images.SetKeyName(4, "ieframe_102.ico")
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
    Me.ofdChooseIcon.Filter = "Tranparenz-unterstützende Bilddateien (*.png, *.gif)|*.png;*.gif|Alle Bilddateien" & _
        " (*.png, *.gif, *.bmp, *.jpg)|*.png;*.gif;*.bmp;*.jpg|Alle Dateien|*"
    Me.ofdChooseIcon.Title = "Icon auswählen (bestenfalls 32x32) ..."
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
    'Label15
    '
    Me.Label15.AutoSize = True
    Me.Label15.Location = New System.Drawing.Point(105, 29)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(112, 13)
    Me.Label15.TabIndex = 16
    Me.Label15.Text = "Benutzername/E-Mail:"
    '
    'txtLoginUser
    '
    Me.txtLoginUser.Location = New System.Drawing.Point(223, 26)
    Me.txtLoginUser.Name = "txtLoginUser"
    Me.txtLoginUser.Size = New System.Drawing.Size(155, 20)
    Me.txtLoginUser.TabIndex = 17
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
    'txtLoginPass
    '
    Me.txtLoginPass.Location = New System.Drawing.Point(223, 52)
    Me.txtLoginPass.Name = "txtLoginPass"
    Me.txtLoginPass.Size = New System.Drawing.Size(155, 20)
    Me.txtLoginPass.TabIndex = 19
    Me.txtLoginPass.UseSystemPasswordChar = True
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
    Me.GroupBox1.Location = New System.Drawing.Point(18, 92)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(445, 122)
    Me.GroupBox1.TabIndex = 14
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "DropMe.de"
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
    'txtProxyUN
    '
    Me.txtProxyUN.Location = New System.Drawing.Point(75, 49)
    Me.txtProxyUN.Name = "txtProxyUN"
    Me.txtProxyUN.Size = New System.Drawing.Size(140, 20)
    Me.txtProxyUN.TabIndex = 12
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
    'txtProxyPW
    '
    Me.txtProxyPW.Location = New System.Drawing.Point(292, 49)
    Me.txtProxyPW.Name = "txtProxyPW"
    Me.txtProxyPW.Size = New System.Drawing.Size(137, 20)
    Me.txtProxyPW.TabIndex = 14
    Me.txtProxyPW.UseSystemPasswordChar = True
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
    'txtProxyDOM
    '
    Me.txtProxyDOM.Location = New System.Drawing.Point(75, 23)
    Me.txtProxyDOM.Name = "txtProxyDOM"
    Me.txtProxyDOM.Size = New System.Drawing.Size(140, 20)
    Me.txtProxyDOM.TabIndex = 16
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
    Me.GroupBox3.Location = New System.Drawing.Point(18, 229)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(445, 88)
    Me.GroupBox3.TabIndex = 15
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Proxy"
    '
    'frm_options
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(584, 462)
    Me.Controls.Add(Me.ButtonListBar1)
    Me.Controls.Add(Me.TabControl1)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.MinimumSize = New System.Drawing.Size(600, 500)
    Me.Name = "frm_options"
    Me.Text = "Optionen"
    Me.TabControl1.ResumeLayout(False)
    Me.TabPage1.ResumeLayout(False)
    Me.GroupBox8.ResumeLayout(False)
    Me.GroupBox8.PerformLayout()
    Me.TabPage4.ResumeLayout(False)
    Me.TabPage4.PerformLayout()
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents ButtonListBar1 As ButtonListbar.vbAccelerator.Controls.ListBar.ButtonListBar
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
  Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
  Friend WithEvents ofdChooseIcon As System.Windows.Forms.OpenFileDialog
  Friend WithEvents imlWidgetIcons As System.Windows.Forms.ImageList
  Friend WithEvents btnClose As System.Windows.Forms.Button
  Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
  Friend WithEvents chkCollageHitTestIntersect As System.Windows.Forms.CheckBox
  Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
  Friend WithEvents LinkLabel4 As System.Windows.Forms.LinkLabel
  Friend WithEvents LinkLabel3 As System.Windows.Forms.LinkLabel
  Friend WithEvents Label18 As System.Windows.Forms.Label
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents lblProgVer As System.Windows.Forms.Label
  Friend WithEvents lblProgName As System.Windows.Forms.Label
  Friend WithEvents LinkLabel5 As System.Windows.Forms.LinkLabel
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
  Friend WithEvents qq_TextBox2 As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents txtProxyDOM As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents txtProxyPW As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents txtProxyUN As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
  Friend WithEvents txtLoginPass As System.Windows.Forms.TextBox
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents txtLoginUser As System.Windows.Forms.TextBox
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
End Class
