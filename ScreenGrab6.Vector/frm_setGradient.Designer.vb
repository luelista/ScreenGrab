<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_setGradient
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_setGradient))
    Me.Button1 = New System.Windows.Forms.Button
    Me.Label3 = New System.Windows.Forms.Label
    Me.Label4 = New System.Windows.Forms.Label
    Me.GradientEditPanel1 = New DrawingEx.ColorManagement.Gradients.GradientEditPanel
    Me.SuspendLayout()
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(349, 244)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(83, 23)
    Me.Button1.TabIndex = 0
    Me.Button1.Text = "OK"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'Label3
    '
    Me.Label3.BackColor = System.Drawing.Color.Yellow
    Me.Label3.Location = New System.Drawing.Point(0, 0)
    Me.Label3.Name = "Label3"
    Me.Label3.Padding = New System.Windows.Forms.Padding(40, 2, 0, 0)
    Me.Label3.Size = New System.Drawing.Size(432, 33)
    Me.Label3.TabIndex = 4
    Me.Label3.Text = "Achtung: Diese Funktion ist experimentell und kann zu unvorhersehbaren Effekten f" & _
        "ühren! Farbverläufe werden noch nicht gespeichert!"
    '
    'Label4
    '
    Me.Label4.BackColor = System.Drawing.Color.Yellow
    Me.Label4.Image = CType(resources.GetObject("Label4.Image"), System.Drawing.Image)
    Me.Label4.Location = New System.Drawing.Point(14, 5)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(24, 24)
    Me.Label4.TabIndex = 5
    '
    'GradientEditPanel1
    '
    Me.GradientEditPanel1.Location = New System.Drawing.Point(8, 47)
    Me.GradientEditPanel1.MinimumSize = New System.Drawing.Size(357, 154)
    Me.GradientEditPanel1.Name = "GradientEditPanel1"
    Me.GradientEditPanel1.Size = New System.Drawing.Size(426, 191)
    Me.GradientEditPanel1.TabIndex = 6
    '
    'frm_setGradient
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(444, 279)
    Me.Controls.Add(Me.GradientEditPanel1)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Button1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frm_setGradient"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Farbverlauf zuweisen"
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents GradientEditPanel1 As DrawingEx.ColorManagement.Gradients.GradientEditPanel
End Class
