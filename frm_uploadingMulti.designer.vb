<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_uploadingMulti
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_uploadingMulti))
    Me.ListView1 = New System.Windows.Forms.ListView
    Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
    Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.Button1 = New System.Windows.Forms.Button
    Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.URLKopierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.openExplorerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.openBrowserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.Button2 = New System.Windows.Forms.Button
    Me.ContextMenuStrip1.SuspendLayout()
    Me.SuspendLayout()
    '
    'ListView1
    '
    Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
    Me.ListView1.FullRowSelect = True
    Me.ListView1.Location = New System.Drawing.Point(11, 9)
    Me.ListView1.MultiSelect = False
    Me.ListView1.Name = "ListView1"
    Me.ListView1.Size = New System.Drawing.Size(426, 238)
    Me.ListView1.SmallImageList = Me.ImageList1
    Me.ListView1.TabIndex = 0
    Me.ListView1.TileSize = New System.Drawing.Size(300, 30)
    Me.ListView1.UseCompatibleStateImageBehavior = False
    Me.ListView1.View = System.Windows.Forms.View.Details
    '
    'ColumnHeader1
    '
    Me.ColumnHeader1.Text = "Dateiname"
    Me.ColumnHeader1.Width = 113
    '
    'ColumnHeader2
    '
    Me.ColumnHeader2.Text = "URL"
    Me.ColumnHeader2.Width = 289
    '
    'ImageList1
    '
    Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
    Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    '
    'Button1
    '
    Me.Button1.Enabled = False
    Me.Button1.Location = New System.Drawing.Point(317, 253)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(120, 23)
    Me.Button1.TabIndex = 1
    Me.Button1.Text = "Schließen"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'ContextMenuStrip1
    '
    Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.URLKopierenToolStripMenuItem, Me.openExplorerToolStripMenuItem, Me.openBrowserToolStripMenuItem})
    Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
    Me.ContextMenuStrip1.Size = New System.Drawing.Size(179, 70)
    '
    'URLKopierenToolStripMenuItem
    '
    Me.URLKopierenToolStripMenuItem.Name = "URLKopierenToolStripMenuItem"
    Me.URLKopierenToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
    Me.URLKopierenToolStripMenuItem.Text = "URL kopieren"
    '
    'openExplorerToolStripMenuItem
    '
    Me.openExplorerToolStripMenuItem.Name = "openExplorerToolStripMenuItem"
    Me.openExplorerToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
    Me.openExplorerToolStripMenuItem.Text = "Explorer öffnen"
    '
    'openBrowserToolStripMenuItem
    '
    Me.openBrowserToolStripMenuItem.Name = "openBrowserToolStripMenuItem"
    Me.openBrowserToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
    Me.openBrowserToolStripMenuItem.Text = "Webbrowser öffnen"
    '
    'Button2
    '
    Me.Button2.Enabled = False
    Me.Button2.Location = New System.Drawing.Point(12, 253)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(120, 23)
    Me.Button2.TabIndex = 3
    Me.Button2.Text = "Liste leeren"
    Me.Button2.UseVisualStyleBackColor = True
    '
    'frm_uploadingMulti
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(449, 287)
    Me.Controls.Add(Me.Button2)
    Me.Controls.Add(Me.Button1)
    Me.Controls.Add(Me.ListView1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frm_uploadingMulti"
    Me.Text = "Dateien werden hochgeladen ..."
    Me.ContextMenuStrip1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents ListView1 As System.Windows.Forms.ListView
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
  Friend WithEvents URLKopierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents openExplorerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents openBrowserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
