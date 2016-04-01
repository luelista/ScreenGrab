<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_paletteColor
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

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
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.GColorPicker1 = New ScreenGrab6.Collage.gColorPicker()
    CType(Me.GColorPicker1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(5, 160)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(40, 13)
    Me.Label1.TabIndex = 1
    Me.Label1.Text = "HTML:"
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(47, 157)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(76, 20)
    Me.TextBox1.TabIndex = 2
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.ForeColor = System.Drawing.Color.Gray
    Me.Label2.Location = New System.Drawing.Point(129, 161)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(230, 13)
    Me.Label2.TabIndex = 3
    Me.Label2.Text = "Farbe zuweisen: rechtsklick auf Paletteneintrag"
    '
    'GColorPicker1
    '
    Me.GColorPicker1.FlyOut = ScreenGrab6.Collage.gColorPicker.eFlyOut.Click
    Me.GColorPicker1.HideRGB = False
    Me.GColorPicker1.Location = New System.Drawing.Point(0, 1)
    Me.GColorPicker1.Name = "GColorPicker1"
    Me.GColorPicker1.Size = New System.Drawing.Size(355, 179)
    Me.GColorPicker1.TabIndex = 0
    Me.GColorPicker1.Value = System.Drawing.Color.Red
    '
    'frm_paletteColor
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(358, 181)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TextBox1)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.GColorPicker1)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
    Me.Name = "frm_paletteColor"
    Me.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Float
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.Text = "Farbe"
    Me.TopMost = True
    CType(Me.GColorPicker1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents GColorPicker1 As gColorPicker
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
