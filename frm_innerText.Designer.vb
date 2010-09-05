<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_innerText
  Inherits System.Windows.Forms.Form

  'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
  <System.Diagnostics.DebuggerNonUserCode()> _
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    If disposing AndAlso components IsNot Nothing Then
      components.Dispose()
    End If
    MyBase.Dispose(disposing)
  End Sub

  'Wird vom Windows Form-Designer benötigt.
  Private components As System.ComponentModel.IContainer

  'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
  'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
  'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
    Me.SuspendLayout()
    '
    'RichTextBox1
    '
    Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.RichTextBox1.Location = New System.Drawing.Point(0, 0)
    Me.RichTextBox1.Name = "RichTextBox1"
    Me.RichTextBox1.Size = New System.Drawing.Size(292, 266)
    Me.RichTextBox1.TabIndex = 0
    Me.RichTextBox1.Text = ""
    '
    'frm_innerText
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(292, 266)
    Me.Controls.Add(Me.RichTextBox1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
    Me.Name = "frm_innerText"
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
End Class
