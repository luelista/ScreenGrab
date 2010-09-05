<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class LoginForm1
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
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents UsernameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginForm1))
    Me.LogoPictureBox = New System.Windows.Forms.PictureBox
    Me.UsernameLabel = New System.Windows.Forms.Label
    Me.PasswordLabel = New System.Windows.Forms.Label
    Me.UsernameTextBox = New System.Windows.Forms.TextBox
    Me.PasswordTextBox = New System.Windows.Forms.TextBox
    Me.OK = New System.Windows.Forms.Button
    Me.Cancel = New System.Windows.Forms.Button
    Me.btnLogoff = New System.Windows.Forms.Button
    Me.Label6 = New System.Windows.Forms.Label
    Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
    Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
    Me.PictureBox2 = New System.Windows.Forms.PictureBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.Label1 = New System.Windows.Forms.Label
    CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'LogoPictureBox
    '
    Me.LogoPictureBox.Image = CType(resources.GetObject("LogoPictureBox.Image"), System.Drawing.Image)
    Me.LogoPictureBox.Location = New System.Drawing.Point(0, 0)
    Me.LogoPictureBox.Name = "LogoPictureBox"
    Me.LogoPictureBox.Size = New System.Drawing.Size(320, 60)
    Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
    Me.LogoPictureBox.TabIndex = 0
    Me.LogoPictureBox.TabStop = False
    '
    'UsernameLabel
    '
    Me.UsernameLabel.Location = New System.Drawing.Point(12, 144)
    Me.UsernameLabel.Name = "UsernameLabel"
    Me.UsernameLabel.Size = New System.Drawing.Size(79, 23)
    Me.UsernameLabel.TabIndex = 0
    Me.UsernameLabel.Text = "&Benutzername:"
    Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'PasswordLabel
    '
    Me.PasswordLabel.Location = New System.Drawing.Point(12, 177)
    Me.PasswordLabel.Name = "PasswordLabel"
    Me.PasswordLabel.Size = New System.Drawing.Size(79, 23)
    Me.PasswordLabel.TabIndex = 2
    Me.PasswordLabel.Text = "&Kennwort:"
    Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'UsernameTextBox
    '
    Me.UsernameTextBox.Location = New System.Drawing.Point(97, 146)
    Me.UsernameTextBox.Name = "UsernameTextBox"
    Me.UsernameTextBox.Size = New System.Drawing.Size(212, 20)
    Me.UsernameTextBox.TabIndex = 1
    '
    'PasswordTextBox
    '
    Me.PasswordTextBox.Location = New System.Drawing.Point(97, 179)
    Me.PasswordTextBox.Name = "PasswordTextBox"
    Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.PasswordTextBox.Size = New System.Drawing.Size(212, 20)
    Me.PasswordTextBox.TabIndex = 3
    '
    'OK
    '
    Me.OK.Location = New System.Drawing.Point(137, 227)
    Me.OK.Name = "OK"
    Me.OK.Size = New System.Drawing.Size(83, 23)
    Me.OK.TabIndex = 4
    Me.OK.Text = "OK"
    '
    'Cancel
    '
    Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Cancel.Location = New System.Drawing.Point(226, 227)
    Me.Cancel.Name = "Cancel"
    Me.Cancel.Size = New System.Drawing.Size(83, 23)
    Me.Cancel.TabIndex = 5
    Me.Cancel.Text = "Abbrechen"
    '
    'btnLogoff
    '
    Me.btnLogoff.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.btnLogoff.Location = New System.Drawing.Point(8, 227)
    Me.btnLogoff.Name = "btnLogoff"
    Me.btnLogoff.Size = New System.Drawing.Size(98, 23)
    Me.btnLogoff.TabIndex = 7
    Me.btnLogoff.Text = "Ausloggen"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(93, 391)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(9, 13)
    Me.Label6.TabIndex = 10
    Me.Label6.Text = "|"
    '
    'LinkLabel2
    '
    Me.LinkLabel2.AutoSize = True
    Me.LinkLabel2.Location = New System.Drawing.Point(101, 391)
    Me.LinkLabel2.Name = "LinkLabel2"
    Me.LinkLabel2.Size = New System.Drawing.Size(69, 13)
    Me.LinkLabel2.TabIndex = 9
    Me.LinkLabel2.TabStop = True
    Me.LinkLabel2.Text = "Mehr Infos ..."
    '
    'LinkLabel1
    '
    Me.LinkLabel1.AutoSize = True
    Me.LinkLabel1.Location = New System.Drawing.Point(5, 391)
    Me.LinkLabel1.Name = "LinkLabel1"
    Me.LinkLabel1.Size = New System.Drawing.Size(89, 13)
    Me.LinkLabel1.TabIndex = 8
    Me.LinkLabel1.TabStop = True
    Me.LinkLabel1.Text = "Account erstellen"
    '
    'PictureBox2
    '
    Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
    Me.PictureBox2.Location = New System.Drawing.Point(8, 276)
    Me.PictureBox2.Name = "PictureBox2"
    Me.PictureBox2.Size = New System.Drawing.Size(301, 107)
    Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.PictureBox2.TabIndex = 7
    Me.PictureBox2.TabStop = False
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(12, 70)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(308, 62)
    Me.Label3.TabIndex = 1
    Me.Label3.Text = "Bitte logge dich mit deinen TeamWiki.net-Zugangsdaten ein, um Dateien in deinen W" & _
        "ebspace laden zu können." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Als Benutzername kann auch die E-Mail-Adresse oder die" & _
        " Domain des Wikis verwendet werden."
    '
    'Label1
    '
    Me.Label1.BackColor = System.Drawing.SystemColors.ButtonShadow
    Me.Label1.Location = New System.Drawing.Point(8, 262)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(301, 1)
    Me.Label1.TabIndex = 11
    '
    'LoginForm1
    '
    Me.AcceptButton = Me.OK
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.CancelButton = Me.Cancel
    Me.ClientSize = New System.Drawing.Size(321, 412)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.LinkLabel2)
    Me.Controls.Add(Me.btnLogoff)
    Me.Controls.Add(Me.LinkLabel1)
    Me.Controls.Add(Me.Cancel)
    Me.Controls.Add(Me.PictureBox2)
    Me.Controls.Add(Me.OK)
    Me.Controls.Add(Me.PasswordTextBox)
    Me.Controls.Add(Me.UsernameTextBox)
    Me.Controls.Add(Me.PasswordLabel)
    Me.Controls.Add(Me.UsernameLabel)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.LogoPictureBox)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.HelpButton = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "LoginForm1"
    Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "TeamWiki.net Login"
    CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents btnLogoff As System.Windows.Forms.Button
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
  Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
  Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
