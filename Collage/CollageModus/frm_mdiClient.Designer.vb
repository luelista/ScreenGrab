<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_mdiClient
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
    Me.components = New System.ComponentModel.Container
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_mdiClient))
    Me.vcc = New ScreenGrab6.Vector.VCanvasControl
    Me.SuspendLayout()
    '
    'vcc
    '
    Me.vcc.AllowDrop = True
    Me.vcc.Dock = System.Windows.Forms.DockStyle.Fill
    Me.vcc.Location = New System.Drawing.Point(0, 0)
    Me.vcc.Name = "vcc"
    Me.vcc.Size = New System.Drawing.Size(682, 443)
    Me.vcc.TabIndex = 0
    '
    'frm_mdiClient
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(682, 443)
    Me.Controls.Add(Me.vcc)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.Name = "frm_mdiClient"
    Me.Text = "Unbenannt"
    Me.ResumeLayout(False)

  End Sub
  Public WithEvents vcc As ScreenGrab6.Vector.VCanvasControl
End Class
