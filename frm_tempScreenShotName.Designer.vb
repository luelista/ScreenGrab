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
    Me.btnComment = New System.Windows.Forms.Button
    Me.PictureBox1 = New System.Windows.Forms.PictureBox
    Me.PictureBox2 = New System.Windows.Forms.PictureBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
    Me.Label3 = New System.Windows.Forms.Label
    Me.TextBox1 = New System.Windows.Forms.TextBox
    Me.Label4 = New System.Windows.Forms.Label
    Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
    Me.PictureBox3 = New System.Windows.Forms.PictureBox
    Me.txtFullURL = New System.Windows.Forms.TextBox
    Me.chkCopyPageLink = New System.Windows.Forms.CheckBox
    Me.txtComment = New System.Windows.Forms.TextBox
    Me.TableLayoutPanel1.SuspendLayout()
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.FlowLayoutPanel1.SuspendLayout()
    CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
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
    Me.TableLayoutPanel1.Controls.Add(Me.btnComment, 0, 0)
    Me.TableLayoutPanel1.Location = New System.Drawing.Point(19, 178)
    Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    Me.TableLayoutPanel1.RowCount = 1
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanel1.Size = New System.Drawing.Size(429, 29)
    Me.TableLayoutPanel1.TabIndex = 2
    '
    'OK_Button
    '
    Me.OK_Button.Dock = System.Windows.Forms.DockStyle.Fill
    Me.OK_Button.Location = New System.Drawing.Point(217, 3)
    Me.OK_Button.Name = "OK_Button"
    Me.OK_Button.Size = New System.Drawing.Size(101, 23)
    Me.OK_Button.TabIndex = 0
    Me.OK_Button.Text = "OK"
    '
    'Cancel_Button
    '
    Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Cancel_Button.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Cancel_Button.Location = New System.Drawing.Point(324, 3)
    Me.Cancel_Button.Name = "Cancel_Button"
    Me.Cancel_Button.Size = New System.Drawing.Size(102, 23)
    Me.Cancel_Button.TabIndex = 1
    Me.Cancel_Button.Text = "Abbrechen"
    '
    'btnComment
    '
    Me.btnComment.Dock = System.Windows.Forms.DockStyle.Fill
    Me.btnComment.Location = New System.Drawing.Point(3, 3)
    Me.btnComment.Name = "btnComment"
    Me.btnComment.Size = New System.Drawing.Size(101, 23)
    Me.btnComment.TabIndex = 2
    Me.btnComment.Text = "Kommentar >"
    Me.btnComment.UseVisualStyleBackColor = True
    '
    'PictureBox1
    '
    Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
    Me.PictureBox1.Location = New System.Drawing.Point(19, 19)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
    Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
    Me.PictureBox1.TabIndex = 1
    Me.PictureBox1.TabStop = False
    '
    'PictureBox2
    '
    Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
    Me.PictureBox2.Location = New System.Drawing.Point(62, 48)
    Me.PictureBox2.Name = "PictureBox2"
    Me.PictureBox2.Size = New System.Drawing.Size(48, 48)
    Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
    Me.PictureBox2.TabIndex = 2
    Me.PictureBox2.TabStop = False
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(134, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(289, 97)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = resources.GetString("Label1.Text")
    '
    'FlowLayoutPanel1
    '
    Me.FlowLayoutPanel1.BackColor = System.Drawing.SystemColors.Window
    Me.FlowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.FlowLayoutPanel1.Controls.Add(Me.Label3)
    Me.FlowLayoutPanel1.Controls.Add(Me.TextBox1)
    Me.FlowLayoutPanel1.Controls.Add(Me.Label4)
    Me.FlowLayoutPanel1.Location = New System.Drawing.Point(22, 124)
    Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
    Me.FlowLayoutPanel1.Size = New System.Drawing.Size(422, 24)
    Me.FlowLayoutPanel1.TabIndex = 0
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(3, 3)
    Me.Label3.Margin = New System.Windows.Forms.Padding(3, 3, 0, 0)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(220, 13)
    Me.Label3.TabIndex = 1
    Me.Label3.Text = "http://snap.teamwiki.net/100109-184607-es-"
    '
    'TextBox1
    '
    Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.TextBox1.Location = New System.Drawing.Point(223, 3)
    Me.TextBox1.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(151, 13)
    Me.TextBox1.TabIndex = 0
    Me.TextBox1.Text = "screenshot"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(374, 3)
    Me.Label4.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(12, 13)
    Me.Label4.TabIndex = 0
    Me.Label4.Text = "/"
    '
    'ProgressBar1
    '
    Me.ProgressBar1.Location = New System.Drawing.Point(23, 180)
    Me.ProgressBar1.Name = "ProgressBar1"
    Me.ProgressBar1.Size = New System.Drawing.Size(318, 24)
    Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
    Me.ProgressBar1.TabIndex = 3
    Me.ProgressBar1.Visible = False
    '
    'PictureBox3
    '
    Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
    Me.PictureBox3.Location = New System.Drawing.Point(10, 12)
    Me.PictureBox3.Name = "PictureBox3"
    Me.PictureBox3.Size = New System.Drawing.Size(437, 108)
    Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
    Me.PictureBox3.TabIndex = 4
    Me.PictureBox3.TabStop = False
    Me.PictureBox3.Visible = False
    '
    'txtFullURL
    '
    Me.txtFullURL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtFullURL.ForeColor = System.Drawing.Color.Blue
    Me.txtFullURL.Location = New System.Drawing.Point(21, 124)
    Me.txtFullURL.Name = "txtFullURL"
    Me.txtFullURL.Size = New System.Drawing.Size(423, 20)
    Me.txtFullURL.TabIndex = 5
    Me.txtFullURL.Visible = False
    '
    'chkCopyPageLink
    '
    Me.chkCopyPageLink.AutoSize = True
    Me.chkCopyPageLink.Checked = True
    Me.chkCopyPageLink.CheckState = System.Windows.Forms.CheckState.Checked
    Me.chkCopyPageLink.Location = New System.Drawing.Point(23, 154)
    Me.chkCopyPageLink.Name = "chkCopyPageLink"
    Me.chkCopyPageLink.Size = New System.Drawing.Size(182, 17)
    Me.chkCopyPageLink.TabIndex = 6
    Me.chkCopyPageLink.Text = "Link zur Übersichtsseite kopieren"
    Me.chkCopyPageLink.UseVisualStyleBackColor = True
    '
    'txtComment
    '
    Me.txtComment.Location = New System.Drawing.Point(24, 218)
    Me.txtComment.Multiline = True
    Me.txtComment.Name = "txtComment"
    Me.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtComment.Size = New System.Drawing.Size(420, 105)
    Me.txtComment.TabIndex = 7
    '
    'frm_tempScreenShotName
    '
    Me.AcceptButton = Me.OK_Button
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.CancelButton = Me.Cancel_Button
    Me.ClientSize = New System.Drawing.Size(459, 216)
    Me.Controls.Add(Me.txtComment)
    Me.Controls.Add(Me.chkCopyPageLink)
    Me.Controls.Add(Me.ProgressBar1)
    Me.Controls.Add(Me.FlowLayoutPanel1)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.PictureBox1)
    Me.Controls.Add(Me.TableLayoutPanel1)
    Me.Controls.Add(Me.PictureBox2)
    Me.Controls.Add(Me.txtFullURL)
    Me.Controls.Add(Me.PictureBox3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frm_tempScreenShotName"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "frm_tempScreenShotName"
    Me.TableLayoutPanel1.ResumeLayout(False)
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
    Me.FlowLayoutPanel1.ResumeLayout(False)
    Me.FlowLayoutPanel1.PerformLayout()
    CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
  Friend WithEvents Cancel_Button As System.Windows.Forms.Button
  Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
  Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
  Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
  Friend WithEvents txtFullURL As System.Windows.Forms.TextBox
  Friend WithEvents btnComment As System.Windows.Forms.Button
  Friend WithEvents chkCopyPageLink As System.Windows.Forms.CheckBox
  Friend WithEvents txtComment As System.Windows.Forms.TextBox

End Class
