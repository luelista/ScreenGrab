<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_grab
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
    Me.components = New System.ComponentModel.Container
    Me.tmrMousemove = New System.Windows.Forms.Timer(Me.components)
    Me.SuspendLayout()
    '
    'tmrMousemove
    '
    Me.tmrMousemove.Interval = 111
    '
    'frm_grab
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.SystemColors.Control
    Me.ClientSize = New System.Drawing.Size(332, 259)
    Me.ControlBox = False
    Me.Cursor = System.Windows.Forms.Cursors.Cross
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.Name = "frm_grab"
    Me.ShowInTaskbar = False
    Me.TopMost = True
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents tmrMousemove As System.Windows.Forms.Timer
End Class
