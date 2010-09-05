<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog1
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
    Me.Cancel_Button = New System.Windows.Forms.Button
    Me.WebBrowser1 = New System.Windows.Forms.WebBrowser
    Me.SuspendLayout()
    '
    'Cancel_Button
    '
    Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Cancel_Button.Location = New System.Drawing.Point(270, 280)
    Me.Cancel_Button.Name = "Cancel_Button"
    Me.Cancel_Button.Size = New System.Drawing.Size(147, 23)
    Me.Cancel_Button.TabIndex = 1
    Me.Cancel_Button.Text = "Abbrechen"
    '
    'WebBrowser1
    '
    Me.WebBrowser1.Location = New System.Drawing.Point(8, 9)
    Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
    Me.WebBrowser1.Name = "WebBrowser1"
    Me.WebBrowser1.Size = New System.Drawing.Size(409, 265)
    Me.WebBrowser1.TabIndex = 1
    '
    'Dialog1
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(422, 315)
    Me.Controls.Add(Me.Cancel_Button)
    Me.Controls.Add(Me.WebBrowser1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "Dialog1"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Bitte authentifizieren Sie sich ..."
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Cancel_Button As System.Windows.Forms.Button
  Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser

End Class
