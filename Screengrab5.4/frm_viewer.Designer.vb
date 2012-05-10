<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_viewer
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_viewer))
    Me.WebBrowser1 = New System.Windows.Forms.WebBrowser
    Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
    Me.tssl1 = New System.Windows.Forms.ToolStripStatusLabel
    Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
    Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
    Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
    Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox
    Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
    Me.ImHauptfensterÖffnenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ZurCollageHinzufügenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.SpeichernUnterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.InDieZwischenablageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.StatusStrip1.SuspendLayout()
    Me.ToolStrip1.SuspendLayout()
    Me.SuspendLayout()
    '
    'WebBrowser1
    '
    Me.WebBrowser1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.WebBrowser1.Location = New System.Drawing.Point(0, 26)
    Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
    Me.WebBrowser1.Name = "WebBrowser1"
    Me.WebBrowser1.Size = New System.Drawing.Size(767, 564)
    Me.WebBrowser1.TabIndex = 0
    Me.WebBrowser1.WebBrowserShortcutsEnabled = False
    '
    'StatusStrip1
    '
    Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssl1})
    Me.StatusStrip1.Location = New System.Drawing.Point(0, 591)
    Me.StatusStrip1.Name = "StatusStrip1"
    Me.StatusStrip1.Size = New System.Drawing.Size(768, 22)
    Me.StatusStrip1.TabIndex = 1
    Me.StatusStrip1.Text = "StatusStrip1"
    '
    'tssl1
    '
    Me.tssl1.Name = "tssl1"
    Me.tssl1.Size = New System.Drawing.Size(13, 17)
    Me.tssl1.Text = "  "
    '
    'ToolStrip1
    '
    Me.ToolStrip1.AutoSize = False
    Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripTextBox1, Me.ToolStripDropDownButton1})
    Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
    Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
    Me.ToolStrip1.Name = "ToolStrip1"
    Me.ToolStrip1.Size = New System.Drawing.Size(768, 25)
    Me.ToolStrip1.TabIndex = 5
    Me.ToolStrip1.Text = "ToolStrip1"
    '
    'ToolStripButton1
    '
    Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
    Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton1.Name = "ToolStripButton1"
    Me.ToolStripButton1.Size = New System.Drawing.Size(64, 20)
    Me.ToolStripButton1.Text = "Zurück"
    '
    'ToolStripButton2
    '
    Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
    Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton2.Name = "ToolStripButton2"
    Me.ToolStripButton2.Size = New System.Drawing.Size(97, 20)
    Me.ToolStripButton2.Text = "URL kopieren"
    '
    'ToolStripTextBox1
    '
    Me.ToolStripTextBox1.AutoSize = False
    Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
    Me.ToolStripTextBox1.Size = New System.Drawing.Size(100, 25)
    '
    'ToolStripDropDownButton1
    '
    Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImHauptfensterÖffnenToolStripMenuItem, Me.ZurCollageHinzufügenToolStripMenuItem, Me.SpeichernUnterToolStripMenuItem, Me.InDieZwischenablageToolStripMenuItem})
    Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
    Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
    Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(117, 20)
    Me.ToolStripDropDownButton1.Text = "Bild verwenden"
    '
    'ImHauptfensterÖffnenToolStripMenuItem
    '
    Me.ImHauptfensterÖffnenToolStripMenuItem.Name = "ImHauptfensterÖffnenToolStripMenuItem"
    Me.ImHauptfensterÖffnenToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
    Me.ImHauptfensterÖffnenToolStripMenuItem.Text = "Im Hauptfenster öffnen"
    '
    'ZurCollageHinzufügenToolStripMenuItem
    '
    Me.ZurCollageHinzufügenToolStripMenuItem.Name = "ZurCollageHinzufügenToolStripMenuItem"
    Me.ZurCollageHinzufügenToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
    Me.ZurCollageHinzufügenToolStripMenuItem.Text = "Zur Collage hinzufügen"
    '
    'SpeichernUnterToolStripMenuItem
    '
    Me.SpeichernUnterToolStripMenuItem.Name = "SpeichernUnterToolStripMenuItem"
    Me.SpeichernUnterToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
    Me.SpeichernUnterToolStripMenuItem.Text = "Speichern unter ..."
    '
    'InDieZwischenablageToolStripMenuItem
    '
    Me.InDieZwischenablageToolStripMenuItem.Name = "InDieZwischenablageToolStripMenuItem"
    Me.InDieZwischenablageToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
    Me.InDieZwischenablageToolStripMenuItem.Text = "In die Zwischenablage"
    '
    'frm_viewer
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(768, 613)
    Me.Controls.Add(Me.ToolStrip1)
    Me.Controls.Add(Me.WebBrowser1)
    Me.Controls.Add(Me.StatusStrip1)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.KeyPreview = True
    Me.Name = "frm_viewer"
    Me.Text = "Screenshot-Directory"
    Me.StatusStrip1.ResumeLayout(False)
    Me.StatusStrip1.PerformLayout()
    Me.ToolStrip1.ResumeLayout(False)
    Me.ToolStrip1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
  Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
  Friend WithEvents tssl1 As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
  Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
  Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
  Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
  Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
  Friend WithEvents ImHauptfensterÖffnenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ZurCollageHinzufügenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents SpeichernUnterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents InDieZwischenablageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
