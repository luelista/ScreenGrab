<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_tempScreenShotName
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_tempScreenShotName))
    Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
    Me.OK_Button = New System.Windows.Forms.Button
    Me.Cancel_Button = New System.Windows.Forms.Button
    Me.Label1 = New System.Windows.Forms.Label
    Me.TextBox1 = New System.Windows.Forms.TextBox
    Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
    Me.PictureBox3 = New System.Windows.Forms.PictureBox
    Me.txtFullURL = New System.Windows.Forms.TextBox
    Me.chkOpenInBrowser = New System.Windows.Forms.CheckBox
    Me.txtComment = New System.Windows.Forms.TextBox
    Me.Label2 = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    Me.Label4 = New System.Windows.Forms.Label
    Me.chkPublicListable = New System.Windows.Forms.CheckBox
    Me.PictureBox1 = New System.Windows.Forms.PictureBox
    Me.chkShare = New System.Windows.Forms.CheckBox
    Me.TableLayoutPanel1.SuspendLayout()
    CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TableLayoutPanel1
    '
    Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TableLayoutPanel1.ColumnCount = 4
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
    Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 2, 0)
    Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 3, 0)
    Me.TableLayoutPanel1.Location = New System.Drawing.Point(23, 321)
    Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    Me.TableLayoutPanel1.RowCount = 1
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanel1.Size = New System.Drawing.Size(456, 29)
    Me.TableLayoutPanel1.TabIndex = 2
    '
    'OK_Button
    '
    Me.OK_Button.Dock = System.Windows.Forms.DockStyle.Fill
    Me.OK_Button.Location = New System.Drawing.Point(231, 3)
    Me.OK_Button.Name = "OK_Button"
    Me.OK_Button.Size = New System.Drawing.Size(108, 23)
    Me.OK_Button.TabIndex = 0
    Me.OK_Button.Text = "OK"
    '
    'Cancel_Button
    '
    Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Cancel_Button.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Cancel_Button.Location = New System.Drawing.Point(345, 3)
    Me.Cancel_Button.Name = "Cancel_Button"
    Me.Cancel_Button.Size = New System.Drawing.Size(108, 23)
    Me.Cancel_Button.TabIndex = 1
    Me.Cancel_Button.Text = "Abbrechen"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(134, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(341, 36)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Mit dieser Funktion kannst du einen Screenshot schnell unter einer URL zur Verfüg" & _
        "ung stellen." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(98, 112)
    Me.TextBox1.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(222, 20)
    Me.TextBox1.TabIndex = 0
    Me.TextBox1.Text = "screenshot"
    '
    'ProgressBar1
    '
    Me.ProgressBar1.Location = New System.Drawing.Point(23, 323)
    Me.ProgressBar1.Name = "ProgressBar1"
    Me.ProgressBar1.Size = New System.Drawing.Size(342, 24)
    Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
    Me.ProgressBar1.TabIndex = 3
    Me.ProgressBar1.Visible = False
    '
    'PictureBox3
    '
    Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
    Me.PictureBox3.Location = New System.Drawing.Point(10, 12)
    Me.PictureBox3.Name = "PictureBox3"
    Me.PictureBox3.Size = New System.Drawing.Size(465, 88)
    Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
    Me.PictureBox3.TabIndex = 4
    Me.PictureBox3.TabStop = False
    Me.PictureBox3.Visible = False
    '
    'txtFullURL
    '
    Me.txtFullURL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtFullURL.ForeColor = System.Drawing.Color.Blue
    Me.txtFullURL.Location = New System.Drawing.Point(98, 137)
    Me.txtFullURL.Name = "txtFullURL"
    Me.txtFullURL.ReadOnly = True
    Me.txtFullURL.Size = New System.Drawing.Size(377, 20)
    Me.txtFullURL.TabIndex = 5
    '
    'chkOpenInBrowser
    '
    Me.chkOpenInBrowser.AutoSize = True
    Me.chkOpenInBrowser.Checked = True
    Me.chkOpenInBrowser.CheckState = System.Windows.Forms.CheckState.Checked
    Me.chkOpenInBrowser.Location = New System.Drawing.Point(98, 298)
    Me.chkOpenInBrowser.Name = "chkOpenInBrowser"
    Me.chkOpenInBrowser.Size = New System.Drawing.Size(176, 17)
    Me.chkOpenInBrowser.TabIndex = 6
    Me.chkOpenInBrowser.Text = "Nach Upload im Browser öffnen"
    Me.chkOpenInBrowser.UseVisualStyleBackColor = True
    '
    'txtComment
    '
    Me.txtComment.AcceptsReturn = True
    Me.txtComment.AcceptsTab = True
    Me.txtComment.Location = New System.Drawing.Point(98, 163)
    Me.txtComment.Multiline = True
    Me.txtComment.Name = "txtComment"
    Me.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtComment.Size = New System.Drawing.Size(377, 105)
    Me.txtComment.TabIndex = 7
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(20, 115)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(61, 13)
    Me.Label2.TabIndex = 8
    Me.Label2.Text = "Dateiname:"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(20, 140)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(32, 13)
    Me.Label3.TabIndex = 9
    Me.Label3.Text = "URL:"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(20, 166)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(75, 13)
    Me.Label4.TabIndex = 10
    Me.Label4.Text = "Beschreibung:"
    '
    'chkPublicListable
    '
    Me.chkPublicListable.AutoSize = True
    Me.chkPublicListable.Checked = True
    Me.chkPublicListable.CheckState = System.Windows.Forms.CheckState.Checked
    Me.chkPublicListable.Location = New System.Drawing.Point(297, 298)
    Me.chkPublicListable.Name = "chkPublicListable"
    Me.chkPublicListable.Size = New System.Drawing.Size(113, 17)
    Me.chkPublicListable.TabIndex = 11
    Me.chkPublicListable.Text = "Öffentlich auflisten"
    Me.chkPublicListable.UseVisualStyleBackColor = True
    '
    'PictureBox1
    '
    Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
    Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(115, 90)
    Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
    Me.PictureBox1.TabIndex = 13
    Me.PictureBox1.TabStop = False
    '
    'chkShare
    '
    Me.chkShare.AutoSize = True
    Me.chkShare.Location = New System.Drawing.Point(98, 274)
    Me.chkShare.Name = "chkShare"
    Me.chkShare.Size = New System.Drawing.Size(206, 17)
    Me.chkShare.TabIndex = 14
    Me.chkShare.Text = "Diesen Screenshot in Facebook teilen"
    Me.chkShare.UseVisualStyleBackColor = True
    '
    'frm_tempScreenShotName
    '
    Me.AcceptButton = Me.OK_Button
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.CancelButton = Me.Cancel_Button
    Me.ClientSize = New System.Drawing.Size(490, 361)
    Me.Controls.Add(Me.chkShare)
    Me.Controls.Add(Me.PictureBox1)
    Me.Controls.Add(Me.chkPublicListable)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.txtComment)
    Me.Controls.Add(Me.TextBox1)
    Me.Controls.Add(Me.chkOpenInBrowser)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.txtFullURL)
    Me.Controls.Add(Me.PictureBox3)
    Me.Controls.Add(Me.ProgressBar1)
    Me.Controls.Add(Me.TableLayoutPanel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frm_tempScreenShotName"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "frm_tempScreenShotName"
    Me.TableLayoutPanel1.ResumeLayout(False)
    CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents OK_Button As System.Windows.Forms.Button
  Friend WithEvents Cancel_Button As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
  Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
  Friend WithEvents txtFullURL As System.Windows.Forms.TextBox
  Friend WithEvents chkOpenInBrowser As System.Windows.Forms.CheckBox
  Friend WithEvents txtComment As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents chkPublicListable As System.Windows.Forms.CheckBox
  Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
  Friend WithEvents chkShare As System.Windows.Forms.CheckBox

End Class
