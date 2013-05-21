<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_a2sg
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_a2sg))
    Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
    Me.OK_Button = New System.Windows.Forms.Button
    Me.Cancel_Button = New System.Windows.Forms.Button
    Me.PictureBox1 = New System.Windows.Forms.PictureBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    Me.chkAlways = New System.Windows.Forms.CheckBox
    Me.lblSource = New System.Windows.Forms.Label
    Me.lblDownloadDir = New System.Windows.Forms.Label
    Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
    Me.TableLayoutPanel1.SuspendLayout()
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TableLayoutPanel1
    '
    Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TableLayoutPanel1.ColumnCount = 2
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
    Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
    Me.TableLayoutPanel1.Location = New System.Drawing.Point(284, 153)
    Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    Me.TableLayoutPanel1.RowCount = 1
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
    Me.TableLayoutPanel1.TabIndex = 0
    '
    'OK_Button
    '
    Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.OK_Button.Location = New System.Drawing.Point(3, 3)
    Me.OK_Button.Name = "OK_Button"
    Me.OK_Button.Size = New System.Drawing.Size(67, 23)
    Me.OK_Button.TabIndex = 0
    Me.OK_Button.Text = "OK"
    '
    'Cancel_Button
    '
    Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
    Me.Cancel_Button.Name = "Cancel_Button"
    Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
    Me.Cancel_Button.TabIndex = 1
    Me.Cancel_Button.Text = "Cancel"
    '
    'PictureBox1
    '
    Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
    Me.PictureBox1.Location = New System.Drawing.Point(15, 16)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(104, 120)
    Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
    Me.PictureBox1.TabIndex = 1
    Me.PictureBox1.TabStop = False
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(139, 20)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(198, 13)
    Me.Label1.TabIndex = 2
    Me.Label1.Text = "Möchten Sie folgende Datei annehmen?"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(139, 47)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(39, 13)
    Me.Label2.TabIndex = 3
    Me.Label2.Text = "Label2"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(139, 68)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(39, 13)
    Me.Label3.TabIndex = 4
    Me.Label3.Text = "Label3"
    '
    'chkAlways
    '
    Me.chkAlways.AutoSize = True
    Me.chkAlways.Location = New System.Drawing.Point(142, 113)
    Me.chkAlways.Name = "chkAlways"
    Me.chkAlways.Size = New System.Drawing.Size(174, 17)
    Me.chkAlways.TabIndex = 5
    Me.chkAlways.Text = "Bilder von xxx immer annehmen"
    Me.chkAlways.UseVisualStyleBackColor = True
    '
    'lblSource
    '
    Me.lblSource.AutoSize = True
    Me.lblSource.Location = New System.Drawing.Point(139, 121)
    Me.lblSource.Name = "lblSource"
    Me.lblSource.Size = New System.Drawing.Size(39, 13)
    Me.lblSource.TabIndex = 6
    Me.lblSource.Text = "Label4"
    '
    'lblDownloadDir
    '
    Me.lblDownloadDir.AutoSize = True
    Me.lblDownloadDir.Location = New System.Drawing.Point(139, 90)
    Me.lblDownloadDir.Name = "lblDownloadDir"
    Me.lblDownloadDir.Size = New System.Drawing.Size(291, 26)
    Me.lblDownloadDir.TabIndex = 7
    Me.lblDownloadDir.Text = "Die Datei wird unter Eigene Dateien\Downloads abgelegt." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Bitte nehmen Sie nur Dat" & _
        "eien an, die Sie angefordert haben!"
    Me.lblDownloadDir.Visible = False
    '
    'ProgressBar1
    '
    Me.ProgressBar1.Location = New System.Drawing.Point(16, 155)
    Me.ProgressBar1.Name = "ProgressBar1"
    Me.ProgressBar1.Size = New System.Drawing.Size(411, 27)
    Me.ProgressBar1.TabIndex = 8
    Me.ProgressBar1.Visible = False
    '
    'frm_a2sg
    '
    Me.AcceptButton = Me.OK_Button
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.CancelButton = Me.Cancel_Button
    Me.ClientSize = New System.Drawing.Size(442, 194)
    Me.Controls.Add(Me.ProgressBar1)
    Me.Controls.Add(Me.lblSource)
    Me.Controls.Add(Me.chkAlways)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.PictureBox1)
    Me.Controls.Add(Me.TableLayoutPanel1)
    Me.Controls.Add(Me.lblDownloadDir)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frm_a2sg"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Datei empfangen"
    Me.TableLayoutPanel1.ResumeLayout(False)
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents OK_Button As System.Windows.Forms.Button
  Friend WithEvents Cancel_Button As System.Windows.Forms.Button
  Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents chkAlways As System.Windows.Forms.CheckBox
  Friend WithEvents lblSource As System.Windows.Forms.Label
  Friend WithEvents lblDownloadDir As System.Windows.Forms.Label
  Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar

End Class
