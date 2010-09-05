<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_paletteProperties
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
    Me.Label1 = New System.Windows.Forms.Label
    Me.nudX = New System.Windows.Forms.NumericUpDown
    Me.nudY = New System.Windows.Forms.NumericUpDown
    Me.Label2 = New System.Windows.Forms.Label
    Me.nudYY = New System.Windows.Forms.NumericUpDown
    Me.Label3 = New System.Windows.Forms.Label
    Me.nudXX = New System.Windows.Forms.NumericUpDown
    Me.Label4 = New System.Windows.Forms.Label
    Me.Label5 = New System.Windows.Forms.Label
    Me.nudBorderWidth = New System.Windows.Forms.NumericUpDown
    Me.txtBorderColor = New System.Windows.Forms.TextBox
    Me.Label6 = New System.Windows.Forms.Label
    Me.txtName = New System.Windows.Forms.TextBox
    Me.Label7 = New System.Windows.Forms.Label
    Me.Label8 = New System.Windows.Forms.Label
    Me.txtType = New System.Windows.Forms.TextBox
    Me.Label9 = New System.Windows.Forms.Label
    Me.ComboBox1 = New System.Windows.Forms.ComboBox
    Me.btnFormat = New System.Windows.Forms.Button
    Me.Label10 = New System.Windows.Forms.Label
    Me.btnText = New System.Windows.Forms.Button
    Me.pnlFont = New System.Windows.Forms.Panel
    Me.FontDialog1 = New System.Windows.Forms.FontDialog
    Me.pnlProperties = New System.Windows.Forms.Panel
    Me.TextBox1 = New System.Windows.Forms.TextBox
    CType(Me.nudX, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.nudY, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.nudYY, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.nudXX, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.nudBorderWidth, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.pnlFont.SuspendLayout()
    Me.pnlProperties.SuspendLayout()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(3, 57)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(28, 13)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Loc:"
    '
    'nudX
    '
    Me.nudX.Location = New System.Drawing.Point(46, 55)
    Me.nudX.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
    Me.nudX.Minimum = New Decimal(New Integer() {9999, 0, 0, -2147483648})
    Me.nudX.Name = "nudX"
    Me.nudX.Size = New System.Drawing.Size(47, 20)
    Me.nudX.TabIndex = 1
    '
    'nudY
    '
    Me.nudY.Location = New System.Drawing.Point(109, 55)
    Me.nudY.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
    Me.nudY.Minimum = New Decimal(New Integer() {9999, 0, 0, -2147483648})
    Me.nudY.Name = "nudY"
    Me.nudY.Size = New System.Drawing.Size(47, 20)
    Me.nudY.TabIndex = 2
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(95, 59)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(12, 13)
    Me.Label2.TabIndex = 3
    Me.Label2.Text = "x"
    '
    'nudYY
    '
    Me.nudYY.Location = New System.Drawing.Point(109, 75)
    Me.nudYY.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
    Me.nudYY.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
    Me.nudYY.Name = "nudYY"
    Me.nudYY.Size = New System.Drawing.Size(47, 20)
    Me.nudYY.TabIndex = 5
    Me.nudYY.Value = New Decimal(New Integer() {1, 0, 0, 0})
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(95, 79)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(12, 13)
    Me.Label3.TabIndex = 6
    Me.Label3.Text = "x"
    '
    'nudXX
    '
    Me.nudXX.Location = New System.Drawing.Point(46, 75)
    Me.nudXX.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
    Me.nudXX.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
    Me.nudXX.Name = "nudXX"
    Me.nudXX.Size = New System.Drawing.Size(47, 20)
    Me.nudXX.TabIndex = 4
    Me.nudXX.Value = New Decimal(New Integer() {1, 0, 0, 0})
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(3, 77)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(30, 13)
    Me.Label4.TabIndex = 7
    Me.Label4.Text = "Size:"
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(3, 107)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(41, 13)
    Me.Label5.TabIndex = 8
    Me.Label5.Text = "Border:"
    '
    'nudBorderWidth
    '
    Me.nudBorderWidth.Location = New System.Drawing.Point(46, 105)
    Me.nudBorderWidth.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
    Me.nudBorderWidth.Name = "nudBorderWidth"
    Me.nudBorderWidth.Size = New System.Drawing.Size(43, 20)
    Me.nudBorderWidth.TabIndex = 9
    '
    'txtBorderColor
    '
    Me.txtBorderColor.Location = New System.Drawing.Point(93, 105)
    Me.txtBorderColor.Name = "txtBorderColor"
    Me.txtBorderColor.Size = New System.Drawing.Size(62, 20)
    Me.txtBorderColor.TabIndex = 10
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(3, 6)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(38, 13)
    Me.Label6.TabIndex = 11
    Me.Label6.Text = "Name:"
    '
    'txtName
    '
    Me.txtName.Location = New System.Drawing.Point(46, 3)
    Me.txtName.Name = "txtName"
    Me.txtName.Size = New System.Drawing.Size(110, 20)
    Me.txtName.TabIndex = 12
    '
    'Label7
    '
    Me.Label7.BackColor = System.Drawing.SystemColors.ButtonShadow
    Me.Label7.Location = New System.Drawing.Point(7, 36)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(150, 1)
    Me.Label7.TabIndex = 13
    '
    'Label8
    '
    Me.Label8.BackColor = System.Drawing.SystemColors.ButtonShadow
    Me.Label8.Location = New System.Drawing.Point(6, 134)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(150, 1)
    Me.Label8.TabIndex = 14
    '
    'txtType
    '
    Me.txtType.Enabled = False
    Me.txtType.Location = New System.Drawing.Point(46, 25)
    Me.txtType.Name = "txtType"
    Me.txtType.Size = New System.Drawing.Size(110, 20)
    Me.txtType.TabIndex = 16
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(3, 28)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(34, 13)
    Me.Label9.TabIndex = 15
    Me.Label9.Text = "Type:"
    '
    'ComboBox1
    '
    Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.ComboBox1.FormattingEnabled = True
    Me.ComboBox1.Location = New System.Drawing.Point(7, 6)
    Me.ComboBox1.Name = "ComboBox1"
    Me.ComboBox1.Size = New System.Drawing.Size(150, 21)
    Me.ComboBox1.TabIndex = 17
    '
    'btnFormat
    '
    Me.btnFormat.Location = New System.Drawing.Point(3, 41)
    Me.btnFormat.Name = "btnFormat"
    Me.btnFormat.Size = New System.Drawing.Size(108, 23)
    Me.btnFormat.TabIndex = 18
    Me.btnFormat.Text = "Format..."
    Me.btnFormat.UseVisualStyleBackColor = True
    '
    'Label10
    '
    Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.Label10.Location = New System.Drawing.Point(3, 3)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(150, 35)
    Me.Label10.TabIndex = 19
    Me.Label10.Text = "Schriftart"
    Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'btnText
    '
    Me.btnText.Location = New System.Drawing.Point(3, 70)
    Me.btnText.Name = "btnText"
    Me.btnText.Size = New System.Drawing.Size(108, 23)
    Me.btnText.TabIndex = 20
    Me.btnText.Text = "Text..."
    Me.btnText.UseVisualStyleBackColor = True
    '
    'pnlFont
    '
    Me.pnlFont.Controls.Add(Me.btnText)
    Me.pnlFont.Controls.Add(Me.Label10)
    Me.pnlFont.Controls.Add(Me.btnFormat)
    Me.pnlFont.Enabled = False
    Me.pnlFont.Location = New System.Drawing.Point(3, 144)
    Me.pnlFont.Name = "pnlFont"
    Me.pnlFont.Size = New System.Drawing.Size(162, 102)
    Me.pnlFont.TabIndex = 21
    '
    'FontDialog1
    '
    Me.FontDialog1.ShowApply = True
    '
    'pnlProperties
    '
    Me.pnlProperties.Controls.Add(Me.pnlFont)
    Me.pnlProperties.Controls.Add(Me.txtType)
    Me.pnlProperties.Controls.Add(Me.Label9)
    Me.pnlProperties.Controls.Add(Me.Label8)
    Me.pnlProperties.Controls.Add(Me.txtName)
    Me.pnlProperties.Controls.Add(Me.Label6)
    Me.pnlProperties.Controls.Add(Me.txtBorderColor)
    Me.pnlProperties.Controls.Add(Me.nudBorderWidth)
    Me.pnlProperties.Controls.Add(Me.Label5)
    Me.pnlProperties.Controls.Add(Me.Label4)
    Me.pnlProperties.Controls.Add(Me.nudYY)
    Me.pnlProperties.Controls.Add(Me.Label3)
    Me.pnlProperties.Controls.Add(Me.nudXX)
    Me.pnlProperties.Controls.Add(Me.nudY)
    Me.pnlProperties.Controls.Add(Me.Label2)
    Me.pnlProperties.Controls.Add(Me.nudX)
    Me.pnlProperties.Controls.Add(Me.Label1)
    Me.pnlProperties.Location = New System.Drawing.Point(1, 42)
    Me.pnlProperties.Name = "pnlProperties"
    Me.pnlProperties.Size = New System.Drawing.Size(173, 263)
    Me.pnlProperties.TabIndex = 22
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(4, 312)
    Me.TextBox1.Multiline = True
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(152, 177)
    Me.TextBox1.TabIndex = 23
    '
    'frm_paletteProperties
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(169, 502)
    Me.Controls.Add(Me.TextBox1)
    Me.Controls.Add(Me.pnlProperties)
    Me.Controls.Add(Me.ComboBox1)
    Me.Controls.Add(Me.Label7)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
    Me.Name = "frm_paletteProperties"
    Me.Text = "Eigenschaften"
    CType(Me.nudX, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.nudY, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.nudYY, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.nudXX, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.nudBorderWidth, System.ComponentModel.ISupportInitialize).EndInit()
    Me.pnlFont.ResumeLayout(False)
    Me.pnlProperties.ResumeLayout(False)
    Me.pnlProperties.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents nudX As System.Windows.Forms.NumericUpDown
  Friend WithEvents nudY As System.Windows.Forms.NumericUpDown
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents nudYY As System.Windows.Forms.NumericUpDown
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents nudXX As System.Windows.Forms.NumericUpDown
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents nudBorderWidth As System.Windows.Forms.NumericUpDown
  Friend WithEvents txtBorderColor As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents txtName As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents txtType As System.Windows.Forms.TextBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
  Friend WithEvents btnFormat As System.Windows.Forms.Button
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents btnText As System.Windows.Forms.Button
  Friend WithEvents pnlFont As System.Windows.Forms.Panel
  Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
  Friend WithEvents pnlProperties As System.Windows.Forms.Panel
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
