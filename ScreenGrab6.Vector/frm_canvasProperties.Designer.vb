<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_canvasProperties
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
    Me.Label1 = New System.Windows.Forms.Label()
    Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
    Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.OK_Button = New System.Windows.Forms.Button()
    Me.Cancel_Button = New System.Windows.Forms.Button()
    Me.TextBox2 = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(12, 15)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(37, 13)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Breite:"
    '
    'NumericUpDown1
    '
    Me.NumericUpDown1.Increment = New Decimal(New Integer() {5, 0, 0, 0})
    Me.NumericUpDown1.Location = New System.Drawing.Point(112, 13)
    Me.NumericUpDown1.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
    Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
    Me.NumericUpDown1.Name = "NumericUpDown1"
    Me.NumericUpDown1.Size = New System.Drawing.Size(124, 20)
    Me.NumericUpDown1.TabIndex = 1
    Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
    '
    'NumericUpDown2
    '
    Me.NumericUpDown2.Increment = New Decimal(New Integer() {5, 0, 0, 0})
    Me.NumericUpDown2.Location = New System.Drawing.Point(112, 39)
    Me.NumericUpDown2.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
    Me.NumericUpDown2.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
    Me.NumericUpDown2.Name = "NumericUpDown2"
    Me.NumericUpDown2.Size = New System.Drawing.Size(124, 20)
    Me.NumericUpDown2.TabIndex = 3
    Me.NumericUpDown2.Value = New Decimal(New Integer() {1, 0, 0, 0})
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(12, 41)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(36, 13)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "Höhe:"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(242, 15)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(29, 13)
    Me.Label3.TabIndex = 4
    Me.Label3.Text = "Pixel"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(242, 41)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(29, 13)
    Me.Label4.TabIndex = 5
    Me.Label4.Text = "Pixel"
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(12, 78)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(89, 13)
    Me.Label5.TabIndex = 6
    Me.Label5.Text = "Hintergrundfarbe:"
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(112, 75)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(124, 20)
    Me.TextBox1.TabIndex = 7
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(245, 73)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(26, 23)
    Me.Button1.TabIndex = 8
    Me.Button1.Text = "..."
    Me.Button1.UseVisualStyleBackColor = True
    '
    'OK_Button
    '
    Me.OK_Button.Location = New System.Drawing.Point(307, 12)
    Me.OK_Button.Name = "OK_Button"
    Me.OK_Button.Size = New System.Drawing.Size(83, 23)
    Me.OK_Button.TabIndex = 0
    Me.OK_Button.Text = "OK"
    '
    'Cancel_Button
    '
    Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Cancel_Button.Location = New System.Drawing.Point(307, 41)
    Me.Cancel_Button.Name = "Cancel_Button"
    Me.Cancel_Button.Size = New System.Drawing.Size(84, 23)
    Me.Cancel_Button.TabIndex = 1
    Me.Cancel_Button.Text = "Abbrechen"
    '
    'TextBox2
    '
    Me.TextBox2.Location = New System.Drawing.Point(112, 110)
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.ReadOnly = True
    Me.TextBox2.Size = New System.Drawing.Size(74, 20)
    Me.TextBox2.TabIndex = 10
    Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(12, 113)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(89, 13)
    Me.Label6.TabIndex = 9
    Me.Label6.Text = "Anzahl Elemente:"
    '
    'frm_canvasProperties
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(402, 142)
    Me.Controls.Add(Me.TextBox2)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.OK_Button)
    Me.Controls.Add(Me.Cancel_Button)
    Me.Controls.Add(Me.Button1)
    Me.Controls.Add(Me.TextBox1)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.NumericUpDown2)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.NumericUpDown1)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frm_canvasProperties"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Zeichenbereich einstellen ..."
    CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
  Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents OK_Button As System.Windows.Forms.Button
  Friend WithEvents Cancel_Button As System.Windows.Forms.Button
  Friend WithEvents TextBox2 As TextBox
  Friend WithEvents Label6 As Label
End Class
