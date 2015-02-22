<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_imageshackUploaded
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
    Me.PictureBox1 = New System.Windows.Forms.PictureBox
    Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
    Me.Label1 = New System.Windows.Forms.Label
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'PictureBox1
    '
    Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(150, 150)
    Me.PictureBox1.TabIndex = 1
    Me.PictureBox1.TabStop = False
    '
    'RichTextBox1
    '
    Me.RichTextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.RichTextBox1.Location = New System.Drawing.Point(168, 12)
    Me.RichTextBox1.Name = "RichTextBox1"
    Me.RichTextBox1.ReadOnly = True
    Me.RichTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
    Me.RichTextBox1.Size = New System.Drawing.Size(296, 226)
    Me.RichTextBox1.TabIndex = 2
    Me.RichTextBox1.Text = ""
    Me.RichTextBox1.WordWrap = False
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(9, 225)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(97, 13)
    Me.Label1.TabIndex = 3
    Me.Label1.Text = "Link wurde kopiert."
    '
    'frm_imageshackUploaded
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(476, 250)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.RichTextBox1)
    Me.Controls.Add(Me.PictureBox1)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frm_imageshackUploaded"
    Me.ShowIcon = False
    Me.Text = "Bild hochgeladen"
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
  Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
