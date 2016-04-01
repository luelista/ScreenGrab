<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutBox
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
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutBox))
    Me.qq_TextBox2 = New System.Windows.Forms.TextBox()
    Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
    Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
    Me.Label18 = New System.Windows.Forms.Label()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.btnUpdateCheckNow = New System.Windows.Forms.Button()
    Me.chkAutoUpdate = New System.Windows.Forms.CheckBox()
    Me.lblProgVer = New System.Windows.Forms.Label()
    Me.lblProgName = New System.Windows.Forms.Label()
    Me.PictureBox1 = New System.Windows.Forms.PictureBox()
    Me.Button1 = New System.Windows.Forms.Button()
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'qq_TextBox2
    '
    Me.qq_TextBox2.Location = New System.Drawing.Point(25, 199)
    Me.qq_TextBox2.Multiline = True
    Me.qq_TextBox2.Name = "qq_TextBox2"
    Me.qq_TextBox2.ReadOnly = True
    Me.qq_TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.qq_TextBox2.Size = New System.Drawing.Size(435, 98)
    Me.qq_TextBox2.TabIndex = 23
    Me.qq_TextBox2.Text = resources.GetString("qq_TextBox2.Text")
    '
    'LinkLabel4
    '
    Me.LinkLabel4.AutoSize = True
    Me.LinkLabel4.BackColor = System.Drawing.Color.Transparent
    Me.LinkLabel4.LinkColor = System.Drawing.Color.White
    Me.LinkLabel4.Location = New System.Drawing.Point(87, 115)
    Me.LinkLabel4.Name = "LinkLabel4"
    Me.LinkLabel4.Size = New System.Drawing.Size(196, 13)
    Me.LinkLabel4.TabIndex = 19
    Me.LinkLabel4.TabStop = True
    Me.LinkLabel4.Tag = "http://www.max-weller.de/screengrab-6"
    Me.LinkLabel4.Text = "http://www.max-weller.de/screengrab-6"
    '
    'LinkLabel3
    '
    Me.LinkLabel3.AutoSize = True
    Me.LinkLabel3.BackColor = System.Drawing.Color.Transparent
    Me.LinkLabel3.LinkColor = System.Drawing.Color.White
    Me.LinkLabel3.Location = New System.Drawing.Point(87, 92)
    Me.LinkLabel3.Name = "LinkLabel3"
    Me.LinkLabel3.Size = New System.Drawing.Size(150, 13)
    Me.LinkLabel3.TabIndex = 18
    Me.LinkLabel3.TabStop = True
    Me.LinkLabel3.Tag = "http://screengrab.teamwiki.de"
    Me.LinkLabel3.Text = "http://screengrab.teamwiki.de"
    '
    'Label18
    '
    Me.Label18.AutoSize = True
    Me.Label18.BackColor = System.Drawing.Color.Transparent
    Me.Label18.ForeColor = System.Drawing.Color.White
    Me.Label18.Location = New System.Drawing.Point(23, 92)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(62, 13)
    Me.Label18.TabIndex = 17
    Me.Label18.Text = "Homepage:"
    '
    'Label17
    '
    Me.Label17.AutoSize = True
    Me.Label17.BackColor = System.Drawing.Color.Transparent
    Me.Label17.ForeColor = System.Drawing.Color.White
    Me.Label17.Location = New System.Drawing.Point(23, 155)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(190, 52)
    Me.Label17.TabIndex = 16
    Me.Label17.Text = "Copyright (c) 2009-2016 by Max Weller" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Credits:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
    '
    'btnUpdateCheckNow
    '
    Me.btnUpdateCheckNow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.btnUpdateCheckNow.BackColor = System.Drawing.SystemColors.Control
    Me.btnUpdateCheckNow.Location = New System.Drawing.Point(25, 339)
    Me.btnUpdateCheckNow.Name = "btnUpdateCheckNow"
    Me.btnUpdateCheckNow.Size = New System.Drawing.Size(159, 23)
    Me.btnUpdateCheckNow.TabIndex = 15
    Me.btnUpdateCheckNow.Text = "Auf Updates prüfen"
    Me.btnUpdateCheckNow.UseVisualStyleBackColor = True
    '
    'chkAutoUpdate
    '
    Me.chkAutoUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.chkAutoUpdate.AutoSize = True
    Me.chkAutoUpdate.BackColor = System.Drawing.Color.Transparent
    Me.chkAutoUpdate.Checked = True
    Me.chkAutoUpdate.CheckState = System.Windows.Forms.CheckState.Checked
    Me.chkAutoUpdate.ForeColor = System.Drawing.Color.White
    Me.chkAutoUpdate.Location = New System.Drawing.Point(25, 316)
    Me.chkAutoUpdate.Name = "chkAutoUpdate"
    Me.chkAutoUpdate.Size = New System.Drawing.Size(203, 17)
    Me.chkAutoUpdate.TabIndex = 14
    Me.chkAutoUpdate.Text = "Beim Beenden nach Updates suchen"
    Me.chkAutoUpdate.UseVisualStyleBackColor = False
    '
    'lblProgVer
    '
    Me.lblProgVer.AutoSize = True
    Me.lblProgVer.BackColor = System.Drawing.Color.Transparent
    Me.lblProgVer.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblProgVer.ForeColor = System.Drawing.Color.White
    Me.lblProgVer.Location = New System.Drawing.Point(160, 7)
    Me.lblProgVer.Name = "lblProgVer"
    Me.lblProgVer.Size = New System.Drawing.Size(139, 73)
    Me.lblProgVer.TabIndex = 13
    Me.lblProgVer.Text = "X.X"
    '
    'lblProgName
    '
    Me.lblProgName.AutoSize = True
    Me.lblProgName.BackColor = System.Drawing.Color.Transparent
    Me.lblProgName.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblProgName.ForeColor = System.Drawing.Color.White
    Me.lblProgName.Location = New System.Drawing.Point(22, 35)
    Me.lblProgName.Name = "lblProgName"
    Me.lblProgName.Size = New System.Drawing.Size(143, 29)
    Me.lblProgName.TabIndex = 12
    Me.lblProgName.Text = "ScreenGrab"
    '
    'PictureBox1
    '
    Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
    Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
    Me.PictureBox1.Location = New System.Drawing.Point(332, 14)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(128, 128)
    Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
    Me.PictureBox1.TabIndex = 20
    Me.PictureBox1.TabStop = False
    '
    'Button1
    '
    Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Button1.BackColor = System.Drawing.SystemColors.Control
    Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.Button1.Location = New System.Drawing.Point(332, 339)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(128, 23)
    Me.Button1.TabIndex = 24
    Me.Button1.Text = "OK"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'AboutBox
    '
    Me.AcceptButton = Me.Button1
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.RoyalBlue
    Me.CancelButton = Me.Button1
    Me.ClientSize = New System.Drawing.Size(485, 377)
    Me.Controls.Add(Me.Button1)
    Me.Controls.Add(Me.qq_TextBox2)
    Me.Controls.Add(Me.LinkLabel4)
    Me.Controls.Add(Me.LinkLabel3)
    Me.Controls.Add(Me.Label18)
    Me.Controls.Add(Me.Label17)
    Me.Controls.Add(Me.btnUpdateCheckNow)
    Me.Controls.Add(Me.chkAutoUpdate)
    Me.Controls.Add(Me.lblProgVer)
    Me.Controls.Add(Me.lblProgName)
    Me.Controls.Add(Me.PictureBox1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "AboutBox"
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Info"
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents qq_TextBox2 As TextBox
  Friend WithEvents LinkLabel4 As LinkLabel
  Friend WithEvents LinkLabel3 As LinkLabel
  Friend WithEvents Label18 As Label
  Friend WithEvents Label17 As Label
  Friend WithEvents btnUpdateCheckNow As Button
  Friend WithEvents chkAutoUpdate As CheckBox
  Friend WithEvents lblProgVer As Label
  Friend WithEvents lblProgName As Label
  Friend WithEvents PictureBox1 As PictureBox
  Friend WithEvents Button1 As Button
End Class
