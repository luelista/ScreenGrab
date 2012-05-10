<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_rotateElement
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_rotateElement))
    Me.Button1 = New System.Windows.Forms.Button
    Me.TrackBar1 = New System.Windows.Forms.TrackBar
    Me.Label1 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    Me.Label4 = New System.Windows.Forms.Label
    CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(240, 128)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(83, 23)
    Me.Button1.TabIndex = 0
    Me.Button1.Text = "OK"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'TrackBar1
    '
    Me.TrackBar1.LargeChange = 45
    Me.TrackBar1.Location = New System.Drawing.Point(13, 77)
    Me.TrackBar1.Maximum = 180
    Me.TrackBar1.Minimum = -179
    Me.TrackBar1.Name = "TrackBar1"
    Me.TrackBar1.Size = New System.Drawing.Size(310, 45)
    Me.TrackBar1.TabIndex = 1
    Me.TrackBar1.TickFrequency = 10
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(16, 46)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(257, 13)
    Me.Label1.TabIndex = 2
    Me.Label1.Text = "Ziehe den Schieberegler, um das Element zu drehen:"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(16, 131)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(49, 16)
    Me.Label2.TabIndex = 3
    Me.Label2.Text = "Label2"
    '
    'Label3
    '
    Me.Label3.BackColor = System.Drawing.Color.Yellow
    Me.Label3.Location = New System.Drawing.Point(0, 0)
    Me.Label3.Name = "Label3"
    Me.Label3.Padding = New System.Windows.Forms.Padding(40, 2, 0, 0)
    Me.Label3.Size = New System.Drawing.Size(334, 33)
    Me.Label3.TabIndex = 4
    Me.Label3.Text = "Achtung: Diese Funktion ist experimentell und kann zu unvorhersehbaren Effekten f" & _
        "ühren!"
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
    'frm_rotateElement
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(335, 160)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TrackBar1)
    Me.Controls.Add(Me.Button1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frm_rotateElement"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Drehen ..."
    CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
