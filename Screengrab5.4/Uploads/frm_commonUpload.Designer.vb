<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_commonUpload
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_commonUpload))
    Me.txtDropmeFilename = New System.Windows.Forms.TextBox
    Me.Label4 = New System.Windows.Forms.Label
    Me.cmbDropmeClipboard = New System.Windows.Forms.ComboBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.btnUploadDropme = New System.Windows.Forms.Button
    Me.btnCancel1 = New System.Windows.Forms.Button
    Me.pbDropme = New System.Windows.Forms.ProgressBar
    Me.lblDropmeError = New System.Windows.Forms.Label
    Me.cmbSelectUploadTarget = New System.Windows.Forms.ComboBox
    Me.pnlDropme = New System.Windows.Forms.Panel
    Me.pnlImgur = New System.Windows.Forms.Panel
    Me.pbImgur = New System.Windows.Forms.ProgressBar
    Me.btnCancel3 = New System.Windows.Forms.Button
    Me.btnUploadImgur = New System.Windows.Forms.Button
    Me.txtImgurCaption = New System.Windows.Forms.TextBox
    Me.Label8 = New System.Windows.Forms.Label
    Me.txtImgurTitle = New System.Windows.Forms.TextBox
    Me.Label7 = New System.Windows.Forms.Label
    Me.pnlFtp = New System.Windows.Forms.Panel
    Me.txtFtpFilename = New System.Windows.Forms.TextBox
    Me.Label10 = New System.Windows.Forms.Label
    Me.txtFtpDir = New System.Windows.Forms.TextBox
    Me.Label9 = New System.Windows.Forms.Label
    Me.txtFtpPass = New System.Windows.Forms.TextBox
    Me.txtFtpUser = New System.Windows.Forms.TextBox
    Me.Label6 = New System.Windows.Forms.Label
    Me.txtFtpHost = New System.Windows.Forms.TextBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.pbFtp = New System.Windows.Forms.ProgressBar
    Me.btnCancel4 = New System.Windows.Forms.Button
    Me.btnUploadFtp = New System.Windows.Forms.Button
    Me.pnlImageshack = New System.Windows.Forms.Panel
    Me.pbImageshack = New System.Windows.Forms.ProgressBar
    Me.btnCancel5 = New System.Windows.Forms.Button
    Me.btnUploadImageshack = New System.Windows.Forms.Button
    Me.pnlMediacrush = New System.Windows.Forms.Panel
    Me.ComboBox1 = New System.Windows.Forms.ComboBox
    Me.Label11 = New System.Windows.Forms.Label
    Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
    Me.Button1 = New System.Windows.Forms.Button
    Me.btnUploadMediacrush = New System.Windows.Forms.Button
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.cmbWebdavServer = New System.Windows.Forms.ComboBox
    Me.Label2 = New System.Windows.Forms.Label
    Me.ProgressBar2 = New System.Windows.Forms.ProgressBar
    Me.Button2 = New System.Windows.Forms.Button
    Me.Button3 = New System.Windows.Forms.Button
    Me.Label5 = New System.Windows.Forms.Label
    Me.TextBox1 = New System.Windows.Forms.TextBox
    Me.Label12 = New System.Windows.Forms.Label
    Me.pnlDropme.SuspendLayout()
    Me.pnlImgur.SuspendLayout()
    Me.pnlFtp.SuspendLayout()
    Me.pnlImageshack.SuspendLayout()
    Me.pnlMediacrush.SuspendLayout()
    Me.Panel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'txtDropmeFilename
    '
    Me.txtDropmeFilename.Location = New System.Drawing.Point(137, 48)
    Me.txtDropmeFilename.Name = "txtDropmeFilename"
    Me.txtDropmeFilename.Size = New System.Drawing.Size(392, 20)
    Me.txtDropmeFilename.TabIndex = 3
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(19, 51)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(61, 13)
    Me.Label4.TabIndex = 2
    Me.Label4.Text = "Dateiname:"
    '
    'cmbDropmeClipboard
    '
    Me.cmbDropmeClipboard.FormattingEnabled = True
    Me.cmbDropmeClipboard.Location = New System.Drawing.Point(137, 6)
    Me.cmbDropmeClipboard.Name = "cmbDropmeClipboard"
    Me.cmbDropmeClipboard.Size = New System.Drawing.Size(392, 21)
    Me.cmbDropmeClipboard.TabIndex = 1
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(19, 6)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(109, 26)
    Me.Label3.TabIndex = 0
    Me.Label3.Text = "Clipboard auswählen" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "oder Name eingeben:"
    '
    'btnUploadDropme
    '
    Me.btnUploadDropme.Location = New System.Drawing.Point(392, 86)
    Me.btnUploadDropme.Name = "btnUploadDropme"
    Me.btnUploadDropme.Size = New System.Drawing.Size(137, 23)
    Me.btnUploadDropme.TabIndex = 6
    Me.btnUploadDropme.Text = "Speichern"
    Me.btnUploadDropme.UseVisualStyleBackColor = True
    '
    'btnCancel1
    '
    Me.btnCancel1.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.btnCancel1.Location = New System.Drawing.Point(291, 86)
    Me.btnCancel1.Name = "btnCancel1"
    Me.btnCancel1.Size = New System.Drawing.Size(95, 23)
    Me.btnCancel1.TabIndex = 5
    Me.btnCancel1.Text = "Abbrechen"
    Me.btnCancel1.UseVisualStyleBackColor = True
    '
    'pbDropme
    '
    Me.pbDropme.Location = New System.Drawing.Point(23, 86)
    Me.pbDropme.Name = "pbDropme"
    Me.pbDropme.Size = New System.Drawing.Size(256, 22)
    Me.pbDropme.TabIndex = 4
    Me.pbDropme.Visible = False
    '
    'lblDropmeError
    '
    Me.lblDropmeError.ForeColor = System.Drawing.Color.Red
    Me.lblDropmeError.Location = New System.Drawing.Point(25, 89)
    Me.lblDropmeError.Name = "lblDropmeError"
    Me.lblDropmeError.Size = New System.Drawing.Size(254, 39)
    Me.lblDropmeError.TabIndex = 5
    Me.lblDropmeError.Text = "Label1"
    Me.lblDropmeError.Visible = False
    '
    'cmbSelectUploadTarget
    '
    Me.cmbSelectUploadTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cmbSelectUploadTarget.FormattingEnabled = True
    Me.cmbSelectUploadTarget.Items.AddRange(New Object() {"--- bitte auswählen ---", "MediaCrush (kompatibel)", "DropMe", "WebDAV", "Imgur", "FTP", "Imageshack"})
    Me.cmbSelectUploadTarget.Location = New System.Drawing.Point(23, 12)
    Me.cmbSelectUploadTarget.Name = "cmbSelectUploadTarget"
    Me.cmbSelectUploadTarget.Size = New System.Drawing.Size(506, 21)
    Me.cmbSelectUploadTarget.TabIndex = 0
    '
    'pnlDropme
    '
    Me.pnlDropme.Controls.Add(Me.pbDropme)
    Me.pnlDropme.Controls.Add(Me.lblDropmeError)
    Me.pnlDropme.Controls.Add(Me.txtDropmeFilename)
    Me.pnlDropme.Controls.Add(Me.btnCancel1)
    Me.pnlDropme.Controls.Add(Me.Label4)
    Me.pnlDropme.Controls.Add(Me.btnUploadDropme)
    Me.pnlDropme.Controls.Add(Me.cmbDropmeClipboard)
    Me.pnlDropme.Controls.Add(Me.Label3)
    Me.pnlDropme.Enabled = False
    Me.pnlDropme.Location = New System.Drawing.Point(0, 40)
    Me.pnlDropme.Name = "pnlDropme"
    Me.pnlDropme.Size = New System.Drawing.Size(544, 123)
    Me.pnlDropme.TabIndex = 1
    '
    'pnlImgur
    '
    Me.pnlImgur.Controls.Add(Me.pbImgur)
    Me.pnlImgur.Controls.Add(Me.btnCancel3)
    Me.pnlImgur.Controls.Add(Me.btnUploadImgur)
    Me.pnlImgur.Controls.Add(Me.txtImgurCaption)
    Me.pnlImgur.Controls.Add(Me.Label8)
    Me.pnlImgur.Controls.Add(Me.txtImgurTitle)
    Me.pnlImgur.Controls.Add(Me.Label7)
    Me.pnlImgur.Location = New System.Drawing.Point(0, 495)
    Me.pnlImgur.Name = "pnlImgur"
    Me.pnlImgur.Size = New System.Drawing.Size(544, 106)
    Me.pnlImgur.TabIndex = 3
    '
    'pbImgur
    '
    Me.pbImgur.Location = New System.Drawing.Point(22, 67)
    Me.pbImgur.Name = "pbImgur"
    Me.pbImgur.Size = New System.Drawing.Size(256, 22)
    Me.pbImgur.TabIndex = 4
    Me.pbImgur.Visible = False
    '
    'btnCancel3
    '
    Me.btnCancel3.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.btnCancel3.Location = New System.Drawing.Point(291, 67)
    Me.btnCancel3.Name = "btnCancel3"
    Me.btnCancel3.Size = New System.Drawing.Size(95, 23)
    Me.btnCancel3.TabIndex = 6
    Me.btnCancel3.Text = "Abbrechen"
    Me.btnCancel3.UseVisualStyleBackColor = True
    '
    'btnUploadImgur
    '
    Me.btnUploadImgur.Location = New System.Drawing.Point(392, 67)
    Me.btnUploadImgur.Name = "btnUploadImgur"
    Me.btnUploadImgur.Size = New System.Drawing.Size(137, 23)
    Me.btnUploadImgur.TabIndex = 5
    Me.btnUploadImgur.Text = "Speichern"
    Me.btnUploadImgur.UseVisualStyleBackColor = True
    '
    'txtImgurCaption
    '
    Me.txtImgurCaption.Location = New System.Drawing.Point(137, 41)
    Me.txtImgurCaption.Name = "txtImgurCaption"
    Me.txtImgurCaption.Size = New System.Drawing.Size(392, 20)
    Me.txtImgurCaption.TabIndex = 3
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(20, 44)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(75, 13)
    Me.Label8.TabIndex = 2
    Me.Label8.Text = "Beschreibung:"
    '
    'txtImgurTitle
    '
    Me.txtImgurTitle.Location = New System.Drawing.Point(137, 15)
    Me.txtImgurTitle.Name = "txtImgurTitle"
    Me.txtImgurTitle.Size = New System.Drawing.Size(392, 20)
    Me.txtImgurTitle.TabIndex = 1
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(20, 18)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(30, 13)
    Me.Label7.TabIndex = 0
    Me.Label7.Text = "Titel:"
    '
    'pnlFtp
    '
    Me.pnlFtp.Controls.Add(Me.txtFtpFilename)
    Me.pnlFtp.Controls.Add(Me.Label10)
    Me.pnlFtp.Controls.Add(Me.txtFtpDir)
    Me.pnlFtp.Controls.Add(Me.Label9)
    Me.pnlFtp.Controls.Add(Me.txtFtpPass)
    Me.pnlFtp.Controls.Add(Me.txtFtpUser)
    Me.pnlFtp.Controls.Add(Me.Label6)
    Me.pnlFtp.Controls.Add(Me.txtFtpHost)
    Me.pnlFtp.Controls.Add(Me.Label1)
    Me.pnlFtp.Controls.Add(Me.pbFtp)
    Me.pnlFtp.Controls.Add(Me.btnCancel4)
    Me.pnlFtp.Controls.Add(Me.btnUploadFtp)
    Me.pnlFtp.Enabled = False
    Me.pnlFtp.Location = New System.Drawing.Point(0, 602)
    Me.pnlFtp.Name = "pnlFtp"
    Me.pnlFtp.Size = New System.Drawing.Size(544, 148)
    Me.pnlFtp.TabIndex = 4
    '
    'txtFtpFilename
    '
    Me.txtFtpFilename.Location = New System.Drawing.Point(137, 89)
    Me.txtFtpFilename.Name = "txtFtpFilename"
    Me.txtFtpFilename.Size = New System.Drawing.Size(392, 20)
    Me.txtFtpFilename.TabIndex = 18
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Location = New System.Drawing.Point(19, 92)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(61, 13)
    Me.Label10.TabIndex = 17
    Me.Label10.Text = "Dateiname:"
    '
    'txtFtpDir
    '
    Me.txtFtpDir.Location = New System.Drawing.Point(137, 63)
    Me.txtFtpDir.Name = "txtFtpDir"
    Me.txtFtpDir.Size = New System.Drawing.Size(392, 20)
    Me.txtFtpDir.TabIndex = 16
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(19, 66)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(57, 13)
    Me.Label9.TabIndex = 15
    Me.Label9.Text = "Zielordner:"
    '
    'txtFtpPass
    '
    Me.txtFtpPass.Location = New System.Drawing.Point(339, 37)
    Me.txtFtpPass.Name = "txtFtpPass"
    Me.txtFtpPass.Size = New System.Drawing.Size(190, 20)
    Me.txtFtpPass.TabIndex = 14
    Me.txtFtpPass.UseSystemPasswordChar = True
    '
    'txtFtpUser
    '
    Me.txtFtpUser.Location = New System.Drawing.Point(137, 37)
    Me.txtFtpUser.Name = "txtFtpUser"
    Me.txtFtpUser.Size = New System.Drawing.Size(196, 20)
    Me.txtFtpUser.TabIndex = 13
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(19, 40)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(86, 13)
    Me.Label6.TabIndex = 12
    Me.Label6.Text = "User / Passwort:"
    '
    'txtFtpHost
    '
    Me.txtFtpHost.Location = New System.Drawing.Point(137, 11)
    Me.txtFtpHost.Name = "txtFtpHost"
    Me.txtFtpHost.Size = New System.Drawing.Size(392, 20)
    Me.txtFtpHost.TabIndex = 11
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(19, 14)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(64, 13)
    Me.Label1.TabIndex = 10
    Me.Label1.Text = "FTP-Server:"
    '
    'pbFtp
    '
    Me.pbFtp.Location = New System.Drawing.Point(22, 119)
    Me.pbFtp.Name = "pbFtp"
    Me.pbFtp.Size = New System.Drawing.Size(256, 22)
    Me.pbFtp.TabIndex = 7
    Me.pbFtp.Visible = False
    '
    'btnCancel4
    '
    Me.btnCancel4.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.btnCancel4.Location = New System.Drawing.Point(291, 119)
    Me.btnCancel4.Name = "btnCancel4"
    Me.btnCancel4.Size = New System.Drawing.Size(95, 23)
    Me.btnCancel4.TabIndex = 9
    Me.btnCancel4.Text = "Abbrechen"
    Me.btnCancel4.UseVisualStyleBackColor = True
    '
    'btnUploadFtp
    '
    Me.btnUploadFtp.Location = New System.Drawing.Point(392, 119)
    Me.btnUploadFtp.Name = "btnUploadFtp"
    Me.btnUploadFtp.Size = New System.Drawing.Size(137, 23)
    Me.btnUploadFtp.TabIndex = 8
    Me.btnUploadFtp.Text = "Speichern"
    Me.btnUploadFtp.UseVisualStyleBackColor = True
    '
    'pnlImageshack
    '
    Me.pnlImageshack.Controls.Add(Me.pbImageshack)
    Me.pnlImageshack.Controls.Add(Me.btnCancel5)
    Me.pnlImageshack.Controls.Add(Me.btnUploadImageshack)
    Me.pnlImageshack.Location = New System.Drawing.Point(0, 178)
    Me.pnlImageshack.Name = "pnlImageshack"
    Me.pnlImageshack.Size = New System.Drawing.Size(544, 48)
    Me.pnlImageshack.TabIndex = 5
    '
    'pbImageshack
    '
    Me.pbImageshack.Location = New System.Drawing.Point(22, 12)
    Me.pbImageshack.Name = "pbImageshack"
    Me.pbImageshack.Size = New System.Drawing.Size(256, 22)
    Me.pbImageshack.TabIndex = 4
    Me.pbImageshack.Visible = False
    '
    'btnCancel5
    '
    Me.btnCancel5.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.btnCancel5.Location = New System.Drawing.Point(291, 12)
    Me.btnCancel5.Name = "btnCancel5"
    Me.btnCancel5.Size = New System.Drawing.Size(95, 23)
    Me.btnCancel5.TabIndex = 6
    Me.btnCancel5.Text = "Abbrechen"
    Me.btnCancel5.UseVisualStyleBackColor = True
    '
    'btnUploadImageshack
    '
    Me.btnUploadImageshack.Location = New System.Drawing.Point(392, 12)
    Me.btnUploadImageshack.Name = "btnUploadImageshack"
    Me.btnUploadImageshack.Size = New System.Drawing.Size(137, 23)
    Me.btnUploadImageshack.TabIndex = 5
    Me.btnUploadImageshack.Text = "Speichern"
    Me.btnUploadImageshack.UseVisualStyleBackColor = True
    '
    'pnlMediacrush
    '
    Me.pnlMediacrush.Controls.Add(Me.ComboBox1)
    Me.pnlMediacrush.Controls.Add(Me.Label11)
    Me.pnlMediacrush.Controls.Add(Me.ProgressBar1)
    Me.pnlMediacrush.Controls.Add(Me.Button1)
    Me.pnlMediacrush.Controls.Add(Me.btnUploadMediacrush)
    Me.pnlMediacrush.Location = New System.Drawing.Point(0, 241)
    Me.pnlMediacrush.Name = "pnlMediacrush"
    Me.pnlMediacrush.Size = New System.Drawing.Size(544, 87)
    Me.pnlMediacrush.TabIndex = 6
    '
    'ComboBox1
    '
    Me.ComboBox1.FormattingEnabled = True
    Me.ComboBox1.Items.AddRange(New Object() {"https://chat2.teamwiki.net"})
    Me.ComboBox1.Location = New System.Drawing.Point(136, 11)
    Me.ComboBox1.Name = "ComboBox1"
    Me.ComboBox1.Size = New System.Drawing.Size(392, 21)
    Me.ComboBox1.TabIndex = 8
    Me.ComboBox1.Text = "https://chat2.teamwiki.net"
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(19, 14)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(41, 13)
    Me.Label11.TabIndex = 7
    Me.Label11.Text = "Server:"
    '
    'ProgressBar1
    '
    Me.ProgressBar1.Location = New System.Drawing.Point(22, 47)
    Me.ProgressBar1.Name = "ProgressBar1"
    Me.ProgressBar1.Size = New System.Drawing.Size(256, 22)
    Me.ProgressBar1.TabIndex = 4
    Me.ProgressBar1.Visible = False
    '
    'Button1
    '
    Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Button1.Location = New System.Drawing.Point(291, 47)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(95, 23)
    Me.Button1.TabIndex = 6
    Me.Button1.Text = "Abbrechen"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'btnUploadMediacrush
    '
    Me.btnUploadMediacrush.Location = New System.Drawing.Point(392, 47)
    Me.btnUploadMediacrush.Name = "btnUploadMediacrush"
    Me.btnUploadMediacrush.Size = New System.Drawing.Size(137, 23)
    Me.btnUploadMediacrush.TabIndex = 5
    Me.btnUploadMediacrush.Text = "Speichern"
    Me.btnUploadMediacrush.UseVisualStyleBackColor = True
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.TextBox1)
    Me.Panel1.Controls.Add(Me.Label12)
    Me.Panel1.Controls.Add(Me.Label5)
    Me.Panel1.Controls.Add(Me.cmbWebdavServer)
    Me.Panel1.Controls.Add(Me.Label2)
    Me.Panel1.Controls.Add(Me.ProgressBar2)
    Me.Panel1.Controls.Add(Me.Button2)
    Me.Panel1.Controls.Add(Me.Button3)
    Me.Panel1.Location = New System.Drawing.Point(0, 333)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(544, 136)
    Me.Panel1.TabIndex = 7
    '
    'cmbWebdavServer
    '
    Me.cmbWebdavServer.FormattingEnabled = True
    Me.cmbWebdavServer.Location = New System.Drawing.Point(136, 11)
    Me.cmbWebdavServer.Name = "cmbWebdavServer"
    Me.cmbWebdavServer.Size = New System.Drawing.Size(392, 21)
    Me.cmbWebdavServer.TabIndex = 8
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(19, 14)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(32, 13)
    Me.Label2.TabIndex = 7
    Me.Label2.Text = "URL:"
    '
    'ProgressBar2
    '
    Me.ProgressBar2.Location = New System.Drawing.Point(22, 99)
    Me.ProgressBar2.Name = "ProgressBar2"
    Me.ProgressBar2.Size = New System.Drawing.Size(256, 22)
    Me.ProgressBar2.TabIndex = 4
    Me.ProgressBar2.Visible = False
    '
    'Button2
    '
    Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Button2.Location = New System.Drawing.Point(291, 99)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(95, 23)
    Me.Button2.TabIndex = 6
    Me.Button2.Text = "Abbrechen"
    Me.Button2.UseVisualStyleBackColor = True
    '
    'Button3
    '
    Me.Button3.Location = New System.Drawing.Point(392, 99)
    Me.Button3.Name = "Button3"
    Me.Button3.Size = New System.Drawing.Size(137, 23)
    Me.Button3.TabIndex = 5
    Me.Button3.Text = "Speichern"
    Me.Button3.UseVisualStyleBackColor = True
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(133, 35)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(390, 13)
    Me.Label5.TabIndex = 9
    Me.Label5.Text = "Format: https://benutzername@passwort:webdav.example.com/ein/unterordner/"
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(135, 66)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(392, 20)
    Me.TextBox1.TabIndex = 11
    '
    'Label12
    '
    Me.Label12.AutoSize = True
    Me.Label12.Location = New System.Drawing.Point(17, 69)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(61, 13)
    Me.Label12.TabIndex = 10
    Me.Label12.Text = "Dateiname:"
    '
    'frm_commonUpload
    '
    Me.AcceptButton = Me.btnUploadDropme
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(544, 752)
    Me.Controls.Add(Me.Panel1)
    Me.Controls.Add(Me.pnlMediacrush)
    Me.Controls.Add(Me.pnlImageshack)
    Me.Controls.Add(Me.pnlFtp)
    Me.Controls.Add(Me.pnlImgur)
    Me.Controls.Add(Me.cmbSelectUploadTarget)
    Me.Controls.Add(Me.pnlDropme)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frm_commonUpload"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Datei im Web speichern ..."
    Me.pnlDropme.ResumeLayout(False)
    Me.pnlDropme.PerformLayout()
    Me.pnlImgur.ResumeLayout(False)
    Me.pnlImgur.PerformLayout()
    Me.pnlFtp.ResumeLayout(False)
    Me.pnlFtp.PerformLayout()
    Me.pnlImageshack.ResumeLayout(False)
    Me.pnlMediacrush.ResumeLayout(False)
    Me.pnlMediacrush.PerformLayout()
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents txtDropmeFilename As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents cmbDropmeClipboard As System.Windows.Forms.ComboBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents btnUploadDropme As System.Windows.Forms.Button
  Friend WithEvents btnCancel1 As System.Windows.Forms.Button
  Friend WithEvents pbDropme As System.Windows.Forms.ProgressBar
  Friend WithEvents lblDropmeError As System.Windows.Forms.Label
  Friend WithEvents cmbSelectUploadTarget As System.Windows.Forms.ComboBox
  Friend WithEvents pnlDropme As System.Windows.Forms.Panel
  Friend WithEvents pnlImgur As System.Windows.Forms.Panel
  Friend WithEvents btnCancel3 As System.Windows.Forms.Button
  Friend WithEvents btnUploadImgur As System.Windows.Forms.Button
  Friend WithEvents txtImgurCaption As System.Windows.Forms.TextBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents txtImgurTitle As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents pbImgur As System.Windows.Forms.ProgressBar
  Friend WithEvents pnlFtp As System.Windows.Forms.Panel
  Friend WithEvents pbFtp As System.Windows.Forms.ProgressBar
  Friend WithEvents btnCancel4 As System.Windows.Forms.Button
  Friend WithEvents btnUploadFtp As System.Windows.Forms.Button
  Friend WithEvents txtFtpFilename As System.Windows.Forms.TextBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents txtFtpDir As System.Windows.Forms.TextBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents txtFtpPass As System.Windows.Forms.TextBox
  Friend WithEvents txtFtpUser As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents txtFtpHost As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents pnlImageshack As System.Windows.Forms.Panel
  Friend WithEvents pbImageshack As System.Windows.Forms.ProgressBar
  Friend WithEvents btnCancel5 As System.Windows.Forms.Button
  Friend WithEvents btnUploadImageshack As System.Windows.Forms.Button
  Friend WithEvents pnlMediacrush As System.Windows.Forms.Panel
  Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents btnUploadMediacrush As System.Windows.Forms.Button
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents cmbWebdavServer As System.Windows.Forms.ComboBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
