<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_lineStyle
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
    Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
    Me.OK_Button = New System.Windows.Forms.Button
    Me.Cancel_Button = New System.Windows.Forms.Button
    Me.grpLine = New System.Windows.Forms.GroupBox
    Me.labColor = New System.Windows.Forms.Label
    Me.CheckBox3 = New System.Windows.Forms.CheckBox
    Me.CheckBox2 = New System.Windows.Forms.CheckBox
    Me.CheckBox1 = New System.Windows.Forms.CheckBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.cmbLineStyle = New System.Windows.Forms.ComboBox
    Me.nudLineWidth = New System.Windows.Forms.NumericUpDown
    Me.GroupBox1 = New System.Windows.Forms.GroupBox
    Me.CheckBox4 = New System.Windows.Forms.CheckBox
    Me.txtEndArrow = New System.Windows.Forms.TextBox
    Me.Label2 = New System.Windows.Forms.Label
    Me.TableLayoutPanel1.SuspendLayout()
    Me.grpLine.SuspendLayout()
    CType(Me.nudLineWidth, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
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
    Me.TableLayoutPanel1.Location = New System.Drawing.Point(73, 225)
    Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    Me.TableLayoutPanel1.RowCount = 1
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.Size = New System.Drawing.Size(175, 29)
    Me.TableLayoutPanel1.TabIndex = 0
    '
    'OK_Button
    '
    Me.OK_Button.Dock = System.Windows.Forms.DockStyle.Fill
    Me.OK_Button.Location = New System.Drawing.Point(3, 3)
    Me.OK_Button.Name = "OK_Button"
    Me.OK_Button.Size = New System.Drawing.Size(81, 23)
    Me.OK_Button.TabIndex = 0
    Me.OK_Button.Text = "OK"
    '
    'Cancel_Button
    '
    Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Cancel_Button.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Cancel_Button.Location = New System.Drawing.Point(90, 3)
    Me.Cancel_Button.Name = "Cancel_Button"
    Me.Cancel_Button.Size = New System.Drawing.Size(82, 23)
    Me.Cancel_Button.TabIndex = 1
    Me.Cancel_Button.Text = "Abbrechen"
    '
    'grpLine
    '
    Me.grpLine.Controls.Add(Me.labColor)
    Me.grpLine.Controls.Add(Me.CheckBox3)
    Me.grpLine.Controls.Add(Me.CheckBox2)
    Me.grpLine.Controls.Add(Me.CheckBox1)
    Me.grpLine.Controls.Add(Me.Label1)
    Me.grpLine.Controls.Add(Me.cmbLineStyle)
    Me.grpLine.Controls.Add(Me.nudLineWidth)
    Me.grpLine.Location = New System.Drawing.Point(12, 13)
    Me.grpLine.Name = "grpLine"
    Me.grpLine.Size = New System.Drawing.Size(234, 135)
    Me.grpLine.TabIndex = 4
    Me.grpLine.TabStop = False
    Me.grpLine.Text = "Linie"
    '
    'labColor
    '
    Me.labColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.labColor.Location = New System.Drawing.Point(79, 100)
    Me.labColor.Name = "labColor"
    Me.labColor.Size = New System.Drawing.Size(120, 22)
    Me.labColor.TabIndex = 11
    Me.labColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'CheckBox3
    '
    Me.CheckBox3.AutoSize = True
    Me.CheckBox3.Location = New System.Drawing.Point(13, 104)
    Me.CheckBox3.Name = "CheckBox3"
    Me.CheckBox3.Size = New System.Drawing.Size(56, 17)
    Me.CheckBox3.TabIndex = 10
    Me.CheckBox3.Text = "Farbe:"
    Me.CheckBox3.UseVisualStyleBackColor = True
    '
    'CheckBox2
    '
    Me.CheckBox2.AutoSize = True
    Me.CheckBox2.Location = New System.Drawing.Point(13, 67)
    Me.CheckBox2.Name = "CheckBox2"
    Me.CheckBox2.Size = New System.Drawing.Size(43, 17)
    Me.CheckBox2.TabIndex = 8
    Me.CheckBox2.Text = "Stil:"
    Me.CheckBox2.UseVisualStyleBackColor = True
    '
    'CheckBox1
    '
    Me.CheckBox1.AutoSize = True
    Me.CheckBox1.Location = New System.Drawing.Point(13, 30)
    Me.CheckBox1.Name = "CheckBox1"
    Me.CheckBox1.Size = New System.Drawing.Size(60, 17)
    Me.CheckBox1.TabIndex = 7
    Me.CheckBox1.Text = "Stärke:"
    Me.CheckBox1.UseVisualStyleBackColor = True
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(185, 31)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(29, 13)
    Me.Label1.TabIndex = 6
    Me.Label1.Text = "Pixel"
    '
    'cmbLineStyle
    '
    Me.cmbLineStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cmbLineStyle.FormattingEnabled = True
    Me.cmbLineStyle.Items.AddRange(New Object() {"Solid", "---  Gestrichelt", "...    Gepunktet", "-.    StrichPunkt", "-..   StrichPunktPunkt"})
    Me.cmbLineStyle.Location = New System.Drawing.Point(79, 65)
    Me.cmbLineStyle.Name = "cmbLineStyle"
    Me.cmbLineStyle.Size = New System.Drawing.Size(135, 21)
    Me.cmbLineStyle.TabIndex = 5
    '
    'nudLineWidth
    '
    Me.nudLineWidth.Location = New System.Drawing.Point(79, 29)
    Me.nudLineWidth.Name = "nudLineWidth"
    Me.nudLineWidth.Size = New System.Drawing.Size(100, 20)
    Me.nudLineWidth.TabIndex = 3
    Me.nudLineWidth.Value = New Decimal(New Integer() {2, 0, 0, 0})
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.Label2)
    Me.GroupBox1.Controls.Add(Me.txtEndArrow)
    Me.GroupBox1.Controls.Add(Me.CheckBox4)
    Me.GroupBox1.Enabled = False
    Me.GroupBox1.Location = New System.Drawing.Point(12, 159)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(234, 52)
    Me.GroupBox1.TabIndex = 5
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Pfeil"
    '
    'CheckBox4
    '
    Me.CheckBox4.AutoSize = True
    Me.CheckBox4.Location = New System.Drawing.Point(13, 26)
    Me.CheckBox4.Name = "CheckBox4"
    Me.CheckBox4.Size = New System.Drawing.Size(54, 17)
    Me.CheckBox4.TabIndex = 10
    Me.CheckBox4.Text = "Ende:"
    Me.CheckBox4.UseVisualStyleBackColor = True
    '
    'txtEndArrow
    '
    Me.txtEndArrow.Location = New System.Drawing.Point(13, 49)
    Me.txtEndArrow.Multiline = True
    Me.txtEndArrow.Name = "txtEndArrow"
    Me.txtEndArrow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtEndArrow.Size = New System.Drawing.Size(201, 55)
    Me.txtEndArrow.TabIndex = 11
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(135, 27)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(79, 13)
    Me.Label2.TabIndex = 12
    Me.Label2.Text = "...coming soon!"
    '
    'frm_lineStyle
    '
    Me.AcceptButton = Me.OK_Button
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.CancelButton = Me.Cancel_Button
    Me.ClientSize = New System.Drawing.Size(260, 266)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.grpLine)
    Me.Controls.Add(Me.TableLayoutPanel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frm_lineStyle"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Linie formatieren ..."
    Me.TableLayoutPanel1.ResumeLayout(False)
    Me.grpLine.ResumeLayout(False)
    Me.grpLine.PerformLayout()
    CType(Me.nudLineWidth, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents OK_Button As System.Windows.Forms.Button
  Friend WithEvents Cancel_Button As System.Windows.Forms.Button
  Friend WithEvents grpLine As System.Windows.Forms.GroupBox
  Friend WithEvents cmbLineStyle As System.Windows.Forms.ComboBox
  Friend WithEvents nudLineWidth As System.Windows.Forms.NumericUpDown
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
  Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
  Friend WithEvents labColor As System.Windows.Forms.Label
  Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents txtEndArrow As System.Windows.Forms.TextBox
  Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
  Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
