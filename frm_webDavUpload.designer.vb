<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_webDavUpload
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_webDavUpload))
    Me.txtUrl = New System.Windows.Forms.TextBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.txtPort = New System.Windows.Forms.TextBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.txtUserName = New System.Windows.Forms.TextBox
    Me.Label4 = New System.Windows.Forms.Label
    Me.txtPassword = New System.Windows.Forms.TextBox
    Me.Button1 = New System.Windows.Forms.Button
    Me.pb = New System.Windows.Forms.ProgressBar
    Me.Label5 = New System.Windows.Forms.Label
    Me.txtFileToUpload = New System.Windows.Forms.TextBox
    Me.PictureBox1 = New System.Windows.Forms.PictureBox
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'txtUrl
    '
    Me.txtUrl.Location = New System.Drawing.Point(81, 89)
    Me.txtUrl.Name = "txtUrl"
    Me.txtUrl.Size = New System.Drawing.Size(381, 20)
    Me.txtUrl.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
    Me.Label1.Location = New System.Drawing.Point(78, 73)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(284, 13)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Enter the URL to a directory on the (https) WebDAV server"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
    Me.Label2.Location = New System.Drawing.Point(78, 131)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(147, 13)
    Me.Label2.TabIndex = 4
    Me.Label2.Text = "Enter the port (HTTPS is 443)"
    '
    'txtPort
    '
    Me.txtPort.Location = New System.Drawing.Point(249, 128)
    Me.txtPort.Name = "txtPort"
    Me.txtPort.Size = New System.Drawing.Size(144, 20)
    Me.txtPort.TabIndex = 5
    Me.txtPort.Text = "80"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
    Me.Label3.Location = New System.Drawing.Point(78, 160)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(106, 13)
    Me.Label3.TabIndex = 6
    Me.Label3.Text = "Enter the User Name"
    '
    'txtUserName
    '
    Me.txtUserName.Location = New System.Drawing.Point(81, 176)
    Me.txtUserName.Name = "txtUserName"
    Me.txtUserName.Size = New System.Drawing.Size(144, 20)
    Me.txtUserName.TabIndex = 7
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
    Me.Label4.Location = New System.Drawing.Point(246, 160)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(99, 13)
    Me.Label4.TabIndex = 8
    Me.Label4.Text = "Enter the Password"
    '
    'txtPassword
    '
    Me.txtPassword.Location = New System.Drawing.Point(249, 176)
    Me.txtPassword.Name = "txtPassword"
    Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.txtPassword.Size = New System.Drawing.Size(144, 20)
    Me.txtPassword.TabIndex = 9
    '
    'Button1
    '
    Me.Button1.BackColor = System.Drawing.SystemColors.Control
    Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
    Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.Button1.Location = New System.Drawing.Point(81, 221)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(144, 30)
    Me.Button1.TabIndex = 10
    Me.Button1.Text = "Upload"
    Me.Button1.UseVisualStyleBackColor = False
    '
    'pb
    '
    Me.pb.BackColor = System.Drawing.SystemColors.Control
    Me.pb.ForeColor = System.Drawing.Color.Red
    Me.pb.Location = New System.Drawing.Point(81, 275)
    Me.pb.Name = "pb"
    Me.pb.Size = New System.Drawing.Size(381, 20)
    Me.pb.TabIndex = 11
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
    Me.Label5.Location = New System.Drawing.Point(78, 14)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(167, 13)
    Me.Label5.TabIndex = 2
    Me.Label5.Text = "Enter the path to the file to upload"
    '
    'txtFileToUpload
    '
    Me.txtFileToUpload.Location = New System.Drawing.Point(81, 30)
    Me.txtFileToUpload.Name = "txtFileToUpload"
    Me.txtFileToUpload.Size = New System.Drawing.Size(381, 20)
    Me.txtFileToUpload.TabIndex = 3
    '
    'PictureBox1
    '
    Me.PictureBox1.Location = New System.Drawing.Point(0, -3)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(100, 318)
    Me.PictureBox1.TabIndex = 12
    Me.PictureBox1.TabStop = False
    '
    'frm_webDavUpload
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.White
    Me.ClientSize = New System.Drawing.Size(474, 315)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.txtFileToUpload)
    Me.Controls.Add(Me.pb)
    Me.Controls.Add(Me.Button1)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.txtPassword)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.txtUserName)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.txtPort)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.txtUrl)
    Me.Controls.Add(Me.PictureBox1)
    Me.Name = "frm_webDavUpload"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "WebDAV File Upload Demo"
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents txtUrl As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtPort As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents txtUserName As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents txtPassword As System.Windows.Forms.TextBox
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents pb As System.Windows.Forms.ProgressBar
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents txtFileToUpload As System.Windows.Forms.TextBox
  Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

End Class
