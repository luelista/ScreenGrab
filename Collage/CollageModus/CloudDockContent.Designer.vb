<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CloudDockContent
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
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CloudDockContent))
    Me.pnlSideDropme = New System.Windows.Forms.Panel()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.cmbServer = New System.Windows.Forms.ComboBox()
    Me.cmbFolder = New System.Windows.Forms.ComboBox()
    Me.ListView1 = New System.Windows.Forms.ListView()
    Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.LoeschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.HerunterladenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.pnlSideDropme.SuspendLayout()
    Me.ContextMenuStrip1.SuspendLayout()
    Me.SuspendLayout()
    '
    'pnlSideDropme
    '
    Me.pnlSideDropme.BackColor = System.Drawing.Color.Silver
    Me.pnlSideDropme.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
    Me.pnlSideDropme.Controls.Add(Me.Button2)
    Me.pnlSideDropme.Controls.Add(Me.Button1)
    Me.pnlSideDropme.Controls.Add(Me.cmbServer)
    Me.pnlSideDropme.Controls.Add(Me.cmbFolder)
    Me.pnlSideDropme.Controls.Add(Me.ListView1)
    Me.pnlSideDropme.Dock = System.Windows.Forms.DockStyle.Fill
    Me.pnlSideDropme.Location = New System.Drawing.Point(0, 0)
    Me.pnlSideDropme.Name = "pnlSideDropme"
    Me.pnlSideDropme.Size = New System.Drawing.Size(249, 588)
    Me.pnlSideDropme.TabIndex = 11
    '
    'Button2
    '
    Me.Button2.ImageKey = "PublishToWebHS.png"
    Me.Button2.ImageList = Me.ImageList1
    Me.Button2.Location = New System.Drawing.Point(2, 3)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(28, 23)
    Me.Button2.TabIndex = 23
    Me.Button2.UseVisualStyleBackColor = True
    '
    'Button1
    '
    Me.Button1.ImageKey = "parent"
    Me.Button1.ImageList = Me.ImageList1
    Me.Button1.Location = New System.Drawing.Point(2, 26)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(28, 23)
    Me.Button1.TabIndex = 22
    Me.Button1.UseVisualStyleBackColor = True
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Fuchsia
    Me.ImageList1.Images.SetKeyName(0, "file")
    Me.ImageList1.Images.SetKeyName(1, "dir")
    Me.ImageList1.Images.SetKeyName(2, "parent")
    Me.ImageList1.Images.SetKeyName(3, "PublishToWebHS.png")
    '
    'cmbServer
    '
    Me.cmbServer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cmbServer.FormattingEnabled = True
    Me.cmbServer.Location = New System.Drawing.Point(31, 4)
    Me.cmbServer.Name = "cmbServer"
    Me.cmbServer.Size = New System.Drawing.Size(216, 21)
    Me.cmbServer.TabIndex = 13
    '
    'cmbFolder
    '
    Me.cmbFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmbFolder.FormattingEnabled = True
    Me.cmbFolder.Location = New System.Drawing.Point(31, 28)
    Me.cmbFolder.Name = "cmbFolder"
    Me.cmbFolder.Size = New System.Drawing.Size(216, 21)
    Me.cmbFolder.TabIndex = 0
    '
    'ListView1
    '
    Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
    Me.ListView1.Location = New System.Drawing.Point(1, 51)
    Me.ListView1.Name = "ListView1"
    Me.ListView1.Size = New System.Drawing.Size(246, 536)
    Me.ListView1.SmallImageList = Me.ImageList1
    Me.ListView1.TabIndex = 19
    Me.ListView1.UseCompatibleStateImageBehavior = False
    Me.ListView1.View = System.Windows.Forms.View.Details
    '
    'ColumnHeader1
    '
    Me.ColumnHeader1.Text = "Name"
    Me.ColumnHeader1.Width = 164
    '
    'ColumnHeader2
    '
    Me.ColumnHeader2.Text = "Größe"
    Me.ColumnHeader2.Width = 68
    '
    'ColumnHeader3
    '
    Me.ColumnHeader3.Text = "Letzte Änderung"
    Me.ColumnHeader3.Width = 91
    '
    'ContextMenuStrip1
    '
    Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HerunterladenToolStripMenuItem, Me.LoeschenToolStripMenuItem})
    Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
    Me.ContextMenuStrip1.Size = New System.Drawing.Size(153, 70)
    '
    'LoeschenToolStripMenuItem
    '
    Me.LoeschenToolStripMenuItem.Name = "LoeschenToolStripMenuItem"
    Me.LoeschenToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
    Me.LoeschenToolStripMenuItem.Text = "Löschen"
    '
    'HerunterladenToolStripMenuItem
    '
    Me.HerunterladenToolStripMenuItem.Name = "HerunterladenToolStripMenuItem"
    Me.HerunterladenToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
    Me.HerunterladenToolStripMenuItem.Text = "Herunterladen"
    '
    'CloudDockContent
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(249, 588)
    Me.Controls.Add(Me.pnlSideDropme)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.HideOnClose = True
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.Name = "CloudDockContent"
    Me.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft
    Me.Text = "Cloud storage"
    Me.pnlSideDropme.ResumeLayout(False)
    Me.ContextMenuStrip1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents pnlSideDropme As System.Windows.Forms.Panel
  Friend WithEvents cmbFolder As System.Windows.Forms.ComboBox
  Friend WithEvents cmbServer As ComboBox
  Friend WithEvents ListView1 As ListView
  Friend WithEvents ColumnHeader1 As ColumnHeader
  Friend WithEvents ColumnHeader2 As ColumnHeader
  Friend WithEvents ColumnHeader3 As ColumnHeader
  Friend WithEvents Button2 As Button
  Friend WithEvents Button1 As Button
  Friend WithEvents ImageList1 As ImageList
  Friend WithEvents ColumnHeader4 As ColumnHeader
  Friend WithEvents ColumnHeader5 As ColumnHeader
  Friend WithEvents ColumnHeader6 As ColumnHeader
  Friend WithEvents ColumnHeader7 As ColumnHeader
  Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
  Friend WithEvents LoeschenToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents HerunterladenToolStripMenuItem As ToolStripMenuItem
End Class
