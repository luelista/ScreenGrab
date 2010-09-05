<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_helpFile
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_helpFile))
    Me.WebBrowser1 = New System.Windows.Forms.WebBrowser
    Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
    Me.tssl1 = New System.Windows.Forms.ToolStripStatusLabel
    Me.StatusStrip1.SuspendLayout()
    Me.SuspendLayout()
    '
    'WebBrowser1
    '
    Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.WebBrowser1.Location = New System.Drawing.Point(0, 0)
    Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
    Me.WebBrowser1.Name = "WebBrowser1"
    Me.WebBrowser1.Size = New System.Drawing.Size(719, 550)
    Me.WebBrowser1.TabIndex = 2
    Me.WebBrowser1.WebBrowserShortcutsEnabled = False
    '
    'StatusStrip1
    '
    Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssl1})
    Me.StatusStrip1.Location = New System.Drawing.Point(0, 550)
    Me.StatusStrip1.Name = "StatusStrip1"
    Me.StatusStrip1.Size = New System.Drawing.Size(719, 22)
    Me.StatusStrip1.TabIndex = 3
    Me.StatusStrip1.Text = "StatusStrip1"
    '
    'tssl1
    '
    Me.tssl1.Name = "tssl1"
    Me.tssl1.Size = New System.Drawing.Size(704, 17)
    Me.tssl1.Spring = True
    Me.tssl1.Text = "  "
    '
    'frm_helpFile
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(719, 572)
    Me.Controls.Add(Me.WebBrowser1)
    Me.Controls.Add(Me.StatusStrip1)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.Name = "frm_helpFile"
    Me.Text = "ScreenGrab 5.0 Hilfe"
    Me.StatusStrip1.ResumeLayout(False)
    Me.StatusStrip1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
  Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
  Friend WithEvents tssl1 As System.Windows.Forms.ToolStripStatusLabel
End Class
