<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_trace
    Inherits System.Windows.Forms.Form

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
    Me.components = New System.ComponentModel.Container
    Me.lstTrace = New System.Windows.Forms.ListBox
    Me.TextBox1 = New System.Windows.Forms.TextBox
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
    Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.LeerenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    Me.ContextMenuStrip1.SuspendLayout()
    Me.SuspendLayout()
    '
    'lstTrace
    '
    Me.lstTrace.ContextMenuStrip = Me.ContextMenuStrip1
    Me.lstTrace.Dock = System.Windows.Forms.DockStyle.Fill
    Me.lstTrace.FormattingEnabled = True
    Me.lstTrace.IntegralHeight = False
    Me.lstTrace.Location = New System.Drawing.Point(0, 0)
    Me.lstTrace.Name = "lstTrace"
    Me.lstTrace.Size = New System.Drawing.Size(580, 376)
    Me.lstTrace.TabIndex = 10
    '
    'TextBox1
    '
    Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TextBox1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox1.Location = New System.Drawing.Point(0, 0)
    Me.TextBox1.Multiline = True
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(580, 144)
    Me.TextBox1.TabIndex = 17
    Me.TextBox1.Visible = False
    '
    'SplitContainer1
    '
    Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer1.Name = "SplitContainer1"
    Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'SplitContainer1.Panel1
    '
    Me.SplitContainer1.Panel1.Controls.Add(Me.lstTrace)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox1)
    Me.SplitContainer1.Size = New System.Drawing.Size(580, 524)
    Me.SplitContainer1.SplitterDistance = 376
    Me.SplitContainer1.TabIndex = 18
    '
    'ContextMenuStrip1
    '
    Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LeerenToolStripMenuItem})
    Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
    Me.ContextMenuStrip1.Size = New System.Drawing.Size(110, 26)
    '
    'LeerenToolStripMenuItem
    '
    Me.LeerenToolStripMenuItem.Name = "LeerenToolStripMenuItem"
    Me.LeerenToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
    Me.LeerenToolStripMenuItem.Text = "Leeren"
    '
    'frm_trace
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(580, 524)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Name = "frm_trace"
    Me.Text = "frm_trace"
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    Me.SplitContainer1.Panel2.PerformLayout()
    Me.SplitContainer1.ResumeLayout(False)
    Me.ContextMenuStrip1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents lstTrace As System.Windows.Forms.ListBox
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
  Friend WithEvents LeerenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
