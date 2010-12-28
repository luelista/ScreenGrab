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
    Me.GroupBox3 = New System.Windows.Forms.GroupBox
    Me.txtProxyDOM = New System.Windows.Forms.TextBox
    Me.Label5 = New System.Windows.Forms.Label
    Me.txtProxyPW = New System.Windows.Forms.TextBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.txtProxyUN = New System.Windows.Forms.TextBox
    Me.Label2 = New System.Windows.Forms.Label
    Me.checkHideWhileGrab = New System.Windows.Forms.CheckBox
    Me.GroupBox1 = New System.Windows.Forms.GroupBox
    Me.PictureBox2 = New System.Windows.Forms.PictureBox
    Me.Button2 = New System.Windows.Forms.Button
    Me.Label13 = New System.Windows.Forms.Label
    Me.PictureBox1 = New System.Windows.Forms.PictureBox
    Me.Label4 = New System.Windows.Forms.Label
    Me.btnClose = New System.Windows.Forms.Button
    Me.GroupBox2 = New System.Windows.Forms.GroupBox
    Me.txtDefaultFolder = New System.Windows.Forms.TextBox
    Me.Label7 = New System.Windows.Forms.Label
    Me.jpegQuality = New System.Windows.Forms.NumericUpDown
    Me.Label6 = New System.Windows.Forms.Label
    Me.btnDefaultFolder_choose = New System.Windows.Forms.Button
    Me.TabPage2 = New System.Windows.Forms.TabPage
    Me.Label1 = New System.Windows.Forms.Label
    Me.imlWidgetIcons = New System.Windows.Forms.ImageList(Me.components)
    Me.ButtonListBar1 = New ButtonListbar.vbAccelerator.Controls.ListBar.ButtonListBar
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ofdChooseIcon = New System.Windows.Forms.OpenFileDialog
    Me.GroupBox4 = New System.Windows.Forms.GroupBox
    Me.Label8 = New System.Windows.Forms.Label
    Me.txtMainWinBG = New System.Windows.Forms.TextBox
    Me.Button1 = New System.Windows.Forms.Button
    Me.TabControl1.SuspendLayout()
    Me.TabPage1.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox2.SuspendLayout()
    CType(Me.jpegQuality, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.TabPage2.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabControl1
    '
    Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TabControl1.Controls.Add(Me.TabPage1)
    Me.TabControl1.Controls.Add(Me.TabPage2)
    Me.TabControl1.Location = New System.Drawing.Point(100, 0)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(588, 588)
    Me.TabControl1.TabIndex = 0
    '
    'TabPage1
    '
    Me.TabPage1.Controls.Add(Me.GroupBox4)
    Me.TabPage1.Controls.Add(Me.GroupBox3)
    Me.TabPage1.Controls.Add(Me.GroupBox1)
    Me.TabPage1.Controls.Add(Me.PictureBox1)
    Me.TabPage1.Controls.Add(Me.Label4)
    Me.TabPage1.Controls.Add(Me.btnClose)
    Me.TabPage1.Controls.Add(Me.GroupBox2)
    Me.TabPage1.Location = New System.Drawing.Point(4, 22)
    Me.TabPage1.Name = "TabPage1"
    Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage1.Size = New System.Drawing.Size(580, 562)
    Me.TabPage1.TabIndex = 4
    Me.TabPage1.Text = "TabPage1"
    Me.TabPage1.UseVisualStyleBackColor = True
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
    Me.GroupBox3.Location = New System.Drawing.Point(20, 193)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(545, 88)
    Me.GroupBox3.TabIndex = 15
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Sonstiges"
    '
    'txtProxyDOM
    '
    Me.txtProxyDOM.Location = New System.Drawing.Point(110, 23)
    Me.txtProxyDOM.Name = "txtProxyDOM"
    Me.txtProxyDOM.Size = New System.Drawing.Size(149, 20)
    Me.txtProxyDOM.TabIndex = 16
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(25, 26)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(75, 13)
    Me.Label5.TabIndex = 15
    Me.Label5.Text = "Proxy Domain:"
    '
    'txtProxyPW
    '
    Me.txtProxyPW.Location = New System.Drawing.Point(377, 49)
    Me.txtProxyPW.Name = "txtProxyPW"
    Me.txtProxyPW.Size = New System.Drawing.Size(149, 20)
    Me.txtProxyPW.TabIndex = 14
    Me.txtProxyPW.UseSystemPasswordChar = True
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(289, 52)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(85, 13)
    Me.Label3.TabIndex = 13
    Me.Label3.Text = "Proxy Password:"
    '
    'txtProxyUN
    '
    Me.txtProxyUN.Location = New System.Drawing.Point(110, 49)
    Me.txtProxyUN.Name = "txtProxyUN"
    Me.txtProxyUN.Size = New System.Drawing.Size(149, 20)
    Me.txtProxyUN.TabIndex = 12
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(13, 52)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(87, 13)
    Me.Label2.TabIndex = 11
    Me.Label2.Text = "Proxy Username:"
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
    'GroupBox1
    '
    Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.GroupBox1.Controls.Add(Me.PictureBox2)
    Me.GroupBox1.Controls.Add(Me.Button2)
    Me.GroupBox1.Controls.Add(Me.Label13)
    Me.GroupBox1.Location = New System.Drawing.Point(20, 287)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(545, 109)
    Me.GroupBox1.TabIndex = 14
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "TeamWiki Login"
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
    'Button2
    '
    Me.Button2.Location = New System.Drawing.Point(95, 71)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(134, 25)
    Me.Button2.TabIndex = 13
    Me.Button2.Text = "Login wechseln ..."
    Me.Button2.UseVisualStyleBackColor = True
    '
    'Label13
    '
    Me.Label13.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Label13.Location = New System.Drawing.Point(95, 25)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(434, 50)
    Me.Label13.TabIndex = 14
    Me.Label13.Text = "Um den eingeloggten Benutzer zu wechseln, oder die gespeicherten Benutzerdaten zu" & _
        " löschen (""ausloggen""), klicke auf den Button ""Login wechseln""."
    '
    'PictureBox1
    '
    Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
    Me.PictureBox1.Location = New System.Drawing.Point(20, 19)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
    Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
    Me.PictureBox1.TabIndex = 9
    Me.PictureBox1.TabStop = False
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Font = New System.Drawing.Font("Comic Sans MS", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.ForeColor = System.Drawing.Color.MidnightBlue
    Me.Label4.Location = New System.Drawing.Point(88, 23)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(323, 38)
    Me.Label4.TabIndex = 0
    Me.Label4.Text = "ScreenGrab - Optionen"
    '
    'btnClose
    '
    Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
    Me.btnClose.Location = New System.Drawing.Point(422, 519)
    Me.btnClose.Name = "btnClose"
    Me.btnClose.Size = New System.Drawing.Size(126, 31)
    Me.btnClose.TabIndex = 3
    Me.btnClose.Text = "Schließen"
    Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.btnClose.UseVisualStyleBackColor = True
    '
    'GroupBox2
    '
    Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.GroupBox2.Controls.Add(Me.txtDefaultFolder)
    Me.GroupBox2.Controls.Add(Me.Label7)
    Me.GroupBox2.Controls.Add(Me.jpegQuality)
    Me.GroupBox2.Controls.Add(Me.Label6)
    Me.GroupBox2.Controls.Add(Me.btnDefaultFolder_choose)
    Me.GroupBox2.Location = New System.Drawing.Point(20, 87)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(545, 94)
    Me.GroupBox2.TabIndex = 0
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Dateiverwaltung"
    '
    'txtDefaultFolder
    '
    Me.txtDefaultFolder.Location = New System.Drawing.Point(128, 28)
    Me.txtDefaultFolder.Name = "txtDefaultFolder"
    Me.txtDefaultFolder.Size = New System.Drawing.Size(373, 20)
    Me.txtDefaultFolder.TabIndex = 5
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(12, 31)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(101, 13)
    Me.Label7.TabIndex = 4
    Me.Label7.Text = "Default-Speicherort:"
    '
    'jpegQuality
    '
    Me.jpegQuality.Location = New System.Drawing.Point(128, 54)
    Me.jpegQuality.Name = "jpegQuality"
    Me.jpegQuality.Size = New System.Drawing.Size(82, 20)
    Me.jpegQuality.TabIndex = 12
    Me.jpegQuality.Value = New Decimal(New Integer() {80, 0, 0, 0})
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(36, 56)
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
    'TabPage2
    '
    Me.TabPage2.Controls.Add(Me.Label1)
    Me.TabPage2.Location = New System.Drawing.Point(4, 22)
    Me.TabPage2.Name = "TabPage2"
    Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage2.Size = New System.Drawing.Size(580, 458)
    Me.TabPage2.TabIndex = 5
    Me.TabPage2.Text = "TabPage2"
    Me.TabPage2.UseVisualStyleBackColor = True
    '
    'Label1
    '
    Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(30, 394)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(312, 24)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "... weitere Optionen -- Coming Soon"
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
    Me.ButtonListBar1.Size = New System.Drawing.Size(98, 559)
    Me.ButtonListBar1.TabIndex = 1
    Me.ButtonListBar1.ToolTip = Nothing
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "SHELL32_274.ico")
    Me.ImageList1.Images.SetKeyName(1, "ieframe_102.ico")
    Me.ImageList1.Images.SetKeyName(2, "dfshim_103.ico")
    Me.ImageList1.Images.SetKeyName(3, "gohome.png")
    Me.ImageList1.Images.SetKeyName(4, "pkColorPicker-32.png")
    Me.ImageList1.Images.SetKeyName(5, "SHELL32_303.ico")
    Me.ImageList1.Images.SetKeyName(6, "devenv_6826.ico")
    Me.ImageList1.Images.SetKeyName(7, "download32.ico")
    Me.ImageList1.Images.SetKeyName(8, "devenv_1200.ico")
    Me.ImageList1.Images.SetKeyName(9, "FRONTPG_464.ico")
    '
    'ofdChooseIcon
    '
    Me.ofdChooseIcon.Filter = "Tranparenz-unterstützende Bilddateien (*.png, *.gif)|*.png;*.gif|Alle Bilddateien" & _
        " (*.png, *.gif, *.bmp, *.jpg)|*.png;*.gif;*.bmp;*.jpg|Alle Dateien|*"
    Me.ofdChooseIcon.Title = "Icon auswählen (bestenfalls 32x32) ..."
    '
    'GroupBox4
    '
    Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.GroupBox4.Controls.Add(Me.Button1)
    Me.GroupBox4.Controls.Add(Me.txtMainWinBG)
    Me.GroupBox4.Controls.Add(Me.Label8)
    Me.GroupBox4.Controls.Add(Me.checkHideWhileGrab)
    Me.GroupBox4.Location = New System.Drawing.Point(20, 402)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(545, 95)
    Me.GroupBox4.TabIndex = 16
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "Hauptfenster"
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
    'txtMainWinBG
    '
    Me.txtMainWinBG.Location = New System.Drawing.Point(114, 52)
    Me.txtMainWinBG.Name = "txtMainWinBG"
    Me.txtMainWinBG.Size = New System.Drawing.Size(100, 20)
    Me.txtMainWinBG.TabIndex = 12
    Me.txtMainWinBG.Text = "#EEEEEE"
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
    'frm_options
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(684, 559)
    Me.Controls.Add(Me.ButtonListBar1)
    Me.Controls.Add(Me.TabControl1)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.MinimumSize = New System.Drawing.Size(700, 595)
    Me.Name = "frm_options"
    Me.Text = "ScreenGrab 5      [ [  Optionen  ] ]"
    Me.TabControl1.ResumeLayout(False)
    Me.TabPage1.ResumeLayout(False)
    Me.TabPage1.PerformLayout()
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    CType(Me.jpegQuality, System.ComponentModel.ISupportInitialize).EndInit()
    Me.TabPage2.ResumeLayout(False)
    Me.TabPage2.PerformLayout()
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox4.PerformLayout()
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
  Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
  Friend WithEvents btnDefaultFolder_choose As System.Windows.Forms.Button
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents txtDefaultFolder As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents btnClose As System.Windows.Forms.Button
  Friend WithEvents jpegQuality As System.Windows.Forms.NumericUpDown
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
  Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
  Friend WithEvents Label1 As System.Windows.Forms.Label
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
End Class
