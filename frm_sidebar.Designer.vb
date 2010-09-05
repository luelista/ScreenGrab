<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_sidebar
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_sidebar))
    Me.TabControl1 = New System.Windows.Forms.TabControl
    Me.TabPage1 = New System.Windows.Forms.TabPage
    Me.Label4 = New System.Windows.Forms.Label
    Me.txtTwPass = New System.Windows.Forms.TextBox
    Me.txtTwUser = New System.Windows.Forms.TextBox
    Me.Panel2 = New System.Windows.Forms.Panel
    Me.TextBox2 = New System.Windows.Forms.TextBox
    Me.Button4 = New System.Windows.Forms.Button
    Me.Button6 = New System.Windows.Forms.Button
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.Button3 = New System.Windows.Forms.Button
    Me.Button2 = New System.Windows.Forms.Button
    Me.TextBox1 = New System.Windows.Forms.TextBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.ComboBox1 = New System.Windows.Forms.ComboBox
    Me.Label2 = New System.Windows.Forms.Label
    Me.Button1 = New System.Windows.Forms.Button
    Me.pnl01 = New System.Windows.Forms.Panel
    Me.labFastUplFilename = New System.Windows.Forms.Label
    Me.Label1 = New System.Windows.Forms.Label
    Me.btnFastUpload = New System.Windows.Forms.Button
    Me.TabPage2 = New System.Windows.Forms.TabPage
    Me.TabPage3 = New System.Windows.Forms.TabPage
    Me.CheckBox1 = New System.Windows.Forms.CheckBox
    Me.tmrSeconds = New System.Windows.Forms.Timer(Me.components)
    Me.INETPOST = New AxInetCtlsObjects.AxInet
    Me.TabControl1.SuspendLayout()
    Me.TabPage1.SuspendLayout()
    Me.Panel2.SuspendLayout()
    Me.Panel1.SuspendLayout()
    Me.pnl01.SuspendLayout()
    CType(Me.INETPOST, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TabControl1
    '
    Me.TabControl1.Controls.Add(Me.TabPage1)
    Me.TabControl1.Controls.Add(Me.TabPage2)
    Me.TabControl1.Controls.Add(Me.TabPage3)
    Me.TabControl1.Location = New System.Drawing.Point(0, 0)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(194, 501)
    Me.TabControl1.TabIndex = 0
    '
    'TabPage1
    '
    Me.TabPage1.Controls.Add(Me.INETPOST)
    Me.TabPage1.Controls.Add(Me.Label4)
    Me.TabPage1.Controls.Add(Me.txtTwPass)
    Me.TabPage1.Controls.Add(Me.txtTwUser)
    Me.TabPage1.Controls.Add(Me.Panel2)
    Me.TabPage1.Controls.Add(Me.Panel1)
    Me.TabPage1.Controls.Add(Me.pnl01)
    Me.TabPage1.Location = New System.Drawing.Point(4, 22)
    Me.TabPage1.Name = "TabPage1"
    Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage1.Size = New System.Drawing.Size(186, 475)
    Me.TabPage1.TabIndex = 0
    Me.TabPage1.Text = "Web"
    Me.TabPage1.UseVisualStyleBackColor = True
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(4, 3)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(143, 13)
    Me.Label4.TabIndex = 11
    Me.Label4.Text = "Benutzer:               Passwort:"
    '
    'txtTwPass
    '
    Me.txtTwPass.Location = New System.Drawing.Point(94, 18)
    Me.txtTwPass.Name = "txtTwPass"
    Me.txtTwPass.Size = New System.Drawing.Size(89, 20)
    Me.txtTwPass.TabIndex = 10
    Me.txtTwPass.UseSystemPasswordChar = True
    '
    'txtTwUser
    '
    Me.txtTwUser.Location = New System.Drawing.Point(2, 18)
    Me.txtTwUser.Name = "txtTwUser"
    Me.txtTwUser.Size = New System.Drawing.Size(89, 20)
    Me.txtTwUser.TabIndex = 9
    '
    'Panel2
    '
    Me.Panel2.BackColor = System.Drawing.Color.MistyRose
    Me.Panel2.Controls.Add(Me.TextBox2)
    Me.Panel2.Controls.Add(Me.Button4)
    Me.Panel2.Controls.Add(Me.Button6)
    Me.Panel2.Location = New System.Drawing.Point(0, 282)
    Me.Panel2.Name = "Panel2"
    Me.Panel2.Size = New System.Drawing.Size(185, 93)
    Me.Panel2.TabIndex = 8
    '
    'TextBox2
    '
    Me.TextBox2.Location = New System.Drawing.Point(8, 64)
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Size = New System.Drawing.Size(173, 20)
    Me.TextBox2.TabIndex = 2
    '
    'Button4
    '
    Me.Button4.BackColor = System.Drawing.Color.LightSalmon
    Me.Button4.ForeColor = System.Drawing.Color.Black
    Me.Button4.Location = New System.Drawing.Point(24, 7)
    Me.Button4.Name = "Button4"
    Me.Button4.Size = New System.Drawing.Size(134, 23)
    Me.Button4.TabIndex = 1
    Me.Button4.Text = "in die Zwischenablage"
    Me.Button4.UseVisualStyleBackColor = False
    '
    'Button6
    '
    Me.Button6.BackColor = System.Drawing.Color.LightSalmon
    Me.Button6.ForeColor = System.Drawing.Color.Black
    Me.Button6.Location = New System.Drawing.Point(24, 35)
    Me.Button6.Name = "Button6"
    Me.Button6.Size = New System.Drawing.Size(134, 23)
    Me.Button6.TabIndex = 0
    Me.Button6.Text = "Speichern unter ..."
    Me.Button6.UseVisualStyleBackColor = False
    '
    'Panel1
    '
    Me.Panel1.BackColor = System.Drawing.Color.LightBlue
    Me.Panel1.Controls.Add(Me.Button3)
    Me.Panel1.Controls.Add(Me.Button2)
    Me.Panel1.Controls.Add(Me.TextBox1)
    Me.Panel1.Controls.Add(Me.Label3)
    Me.Panel1.Controls.Add(Me.ComboBox1)
    Me.Panel1.Controls.Add(Me.Label2)
    Me.Panel1.Controls.Add(Me.Button1)
    Me.Panel1.Location = New System.Drawing.Point(0, 134)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(185, 133)
    Me.Panel1.TabIndex = 2
    '
    'Button3
    '
    Me.Button3.BackColor = System.Drawing.Color.SkyBlue
    Me.Button3.Location = New System.Drawing.Point(166, 54)
    Me.Button3.Name = "Button3"
    Me.Button3.Size = New System.Drawing.Size(15, 20)
    Me.Button3.TabIndex = 7
    Me.Button3.Text = ">"
    Me.Button3.UseVisualStyleBackColor = False
    '
    'Button2
    '
    Me.Button2.BackColor = System.Drawing.Color.SkyBlue
    Me.Button2.Location = New System.Drawing.Point(166, 103)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(15, 20)
    Me.Button2.TabIndex = 5
    Me.Button2.Text = "+"
    Me.Button2.UseVisualStyleBackColor = False
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(8, 104)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(157, 20)
    Me.TextBox1.TabIndex = 4
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(5, 88)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(61, 13)
    Me.Label3.TabIndex = 3
    Me.Label3.Text = "Dateiname:"
    '
    'ComboBox1
    '
    Me.ComboBox1.FormattingEnabled = True
    Me.ComboBox1.Location = New System.Drawing.Point(8, 55)
    Me.ComboBox1.Name = "ComboBox1"
    Me.ComboBox1.Size = New System.Drawing.Size(157, 21)
    Me.ComboBox1.TabIndex = 2
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(5, 39)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(42, 13)
    Me.Label2.TabIndex = 1
    Me.Label2.Text = "Ordner:"
    '
    'Button1
    '
    Me.Button1.BackColor = System.Drawing.Color.RoyalBlue
    Me.Button1.ForeColor = System.Drawing.Color.White
    Me.Button1.Location = New System.Drawing.Point(24, 7)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(134, 23)
    Me.Button1.TabIndex = 0
    Me.Button1.Text = "im Filestore speichern"
    Me.Button1.UseVisualStyleBackColor = False
    '
    'pnl01
    '
    Me.pnl01.BackColor = System.Drawing.Color.Khaki
    Me.pnl01.Controls.Add(Me.labFastUplFilename)
    Me.pnl01.Controls.Add(Me.Label1)
    Me.pnl01.Controls.Add(Me.btnFastUpload)
    Me.pnl01.Location = New System.Drawing.Point(0, 41)
    Me.pnl01.Name = "pnl01"
    Me.pnl01.Size = New System.Drawing.Size(185, 88)
    Me.pnl01.TabIndex = 0
    '
    'labFastUplFilename
    '
    Me.labFastUplFilename.AutoSize = True
    Me.labFastUplFilename.Location = New System.Drawing.Point(2, 65)
    Me.labFastUplFilename.Name = "labFastUplFilename"
    Me.labFastUplFilename.Size = New System.Drawing.Size(38, 13)
    Me.labFastUplFilename.TabIndex = 2
    Me.labFastUplFilename.Text = "Name:"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(2, 33)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(186, 32)
    Me.Label1.TabIndex = 1
    Me.Label1.Text = "Dateien werden nach ca. 2 Monaten automatisch gelöscht."
    '
    'btnFastUpload
    '
    Me.btnFastUpload.BackColor = System.Drawing.Color.Gold
    Me.btnFastUpload.Location = New System.Drawing.Point(24, 7)
    Me.btnFastUpload.Name = "btnFastUpload"
    Me.btnFastUpload.Size = New System.Drawing.Size(134, 23)
    Me.btnFastUpload.TabIndex = 0
    Me.btnFastUpload.Text = "Schnell - Upload"
    Me.btnFastUpload.UseVisualStyleBackColor = False
    '
    'TabPage2
    '
    Me.TabPage2.Location = New System.Drawing.Point(4, 22)
    Me.TabPage2.Name = "TabPage2"
    Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage2.Size = New System.Drawing.Size(186, 475)
    Me.TabPage2.TabIndex = 1
    Me.TabPage2.Text = "Druck"
    Me.TabPage2.UseVisualStyleBackColor = True
    '
    'TabPage3
    '
    Me.TabPage3.Location = New System.Drawing.Point(4, 22)
    Me.TabPage3.Name = "TabPage3"
    Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage3.Size = New System.Drawing.Size(186, 475)
    Me.TabPage3.TabIndex = 2
    Me.TabPage3.Text = "Paint"
    Me.TabPage3.UseVisualStyleBackColor = True
    '
    'CheckBox1
    '
    Me.CheckBox1.AutoSize = True
    Me.CheckBox1.Location = New System.Drawing.Point(150, 0)
    Me.CheckBox1.Name = "CheckBox1"
    Me.CheckBox1.Size = New System.Drawing.Size(41, 17)
    Me.CheckBox1.TabIndex = 1
    Me.CheckBox1.Text = "top"
    Me.CheckBox1.UseVisualStyleBackColor = True
    '
    'tmrSeconds
    '
    Me.tmrSeconds.Enabled = True
    Me.tmrSeconds.Interval = 1000
    '
    'INETPOST
    '
    Me.INETPOST.Enabled = True
    Me.INETPOST.Location = New System.Drawing.Point(48, 418)
    Me.INETPOST.Name = "INETPOST"
    Me.INETPOST.OcxState = CType(resources.GetObject("INETPOST.OcxState"), System.Windows.Forms.AxHost.State)
    Me.INETPOST.Size = New System.Drawing.Size(38, 38)
    Me.INETPOST.TabIndex = 2
    '
    'frm_sidebar
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(194, 501)
    Me.Controls.Add(Me.CheckBox1)
    Me.Controls.Add(Me.TabControl1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
    Me.Name = "frm_sidebar"
    Me.Text = "screenGrab"
    Me.TabControl1.ResumeLayout(False)
    Me.TabPage1.ResumeLayout(False)
    Me.TabPage1.PerformLayout()
    Me.Panel2.ResumeLayout(False)
    Me.Panel2.PerformLayout()
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    Me.pnl01.ResumeLayout(False)
    Me.pnl01.PerformLayout()
    CType(Me.INETPOST, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
  Friend WithEvents pnl01 As System.Windows.Forms.Panel
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents btnFastUpload As System.Windows.Forms.Button
  Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
  Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents Panel2 As System.Windows.Forms.Panel
  Friend WithEvents Button6 As System.Windows.Forms.Button
  Friend WithEvents Button3 As System.Windows.Forms.Button
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
  Friend WithEvents Button4 As System.Windows.Forms.Button
  Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
  Friend WithEvents labFastUplFilename As System.Windows.Forms.Label
  Friend WithEvents tmrSeconds As System.Windows.Forms.Timer
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents txtTwPass As System.Windows.Forms.TextBox
  Friend WithEvents txtTwUser As System.Windows.Forms.TextBox
  Friend WithEvents INETPOST As AxInetCtlsObjects.AxInet
End Class
