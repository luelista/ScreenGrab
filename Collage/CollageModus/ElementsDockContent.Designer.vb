<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ElementsDockContent
  Inherits WeifenLuo.WinFormsUI.Docking.DockContent

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ElementsDockContent))
    Me.lstElementNames = New System.Windows.Forms.ListBox()
    Me.SuspendLayout()
    '
    'lstElementNames
    '
    Me.lstElementNames.Dock = System.Windows.Forms.DockStyle.Fill
    Me.lstElementNames.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
    Me.lstElementNames.FormattingEnabled = True
    Me.lstElementNames.IntegralHeight = False
    Me.lstElementNames.ItemHeight = 50
    Me.lstElementNames.Location = New System.Drawing.Point(0, 0)
    Me.lstElementNames.Name = "lstElementNames"
    Me.lstElementNames.Size = New System.Drawing.Size(195, 548)
    Me.lstElementNames.TabIndex = 3
    '
    'ElementsDockContent
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(195, 548)
    Me.Controls.Add(Me.lstElementNames)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.HideOnClose = True
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.Name = "ElementsDockContent"
    Me.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft
    Me.Text = "Elemente"
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents lstElementNames As System.Windows.Forms.ListBox
End Class
