<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_mdiClient
  Inherits WeifenLuo.WinFormsUI.Docking.DockContent

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
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_mdiClient))
    Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
    Me.BearbeitenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.AusschneidenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.KopierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.EinfuegenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.DuplizierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.LoeschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
    Me.AllesAuswählenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.AuswahlAufhebenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
    Me.ZeichenbereichToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.vcc = New ScreenGrab6.Vector.VCanvasControl()
    Me.MenuStrip1.SuspendLayout()
    Me.SuspendLayout()
    '
    'MenuStrip1
    '
    Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BearbeitenToolStripMenuItem})
    Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
    Me.MenuStrip1.Name = "MenuStrip1"
    Me.MenuStrip1.Size = New System.Drawing.Size(682, 24)
    Me.MenuStrip1.TabIndex = 1
    Me.MenuStrip1.Text = "MenuStrip1"
    Me.MenuStrip1.Visible = False
    '
    'BearbeitenToolStripMenuItem
    '
    Me.BearbeitenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AusschneidenToolStripMenuItem, Me.KopierenToolStripMenuItem, Me.EinfuegenToolStripMenuItem, Me.DuplizierenToolStripMenuItem, Me.LoeschenToolStripMenuItem, Me.ToolStripMenuItem1, Me.AllesAuswählenToolStripMenuItem, Me.AuswahlAufhebenToolStripMenuItem, Me.ToolStripMenuItem2, Me.ZeichenbereichToolStripMenuItem})
    Me.BearbeitenToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert
    Me.BearbeitenToolStripMenuItem.MergeIndex = 1
    Me.BearbeitenToolStripMenuItem.Name = "BearbeitenToolStripMenuItem"
    Me.BearbeitenToolStripMenuItem.Size = New System.Drawing.Size(75, 20)
    Me.BearbeitenToolStripMenuItem.Text = "Bearbeiten"
    '
    'AusschneidenToolStripMenuItem
    '
    Me.AusschneidenToolStripMenuItem.Image = CType(resources.GetObject("AusschneidenToolStripMenuItem.Image"), System.Drawing.Image)
    Me.AusschneidenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
    Me.AusschneidenToolStripMenuItem.Name = "AusschneidenToolStripMenuItem"
    Me.AusschneidenToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
    Me.AusschneidenToolStripMenuItem.Tag = "Any"
    Me.AusschneidenToolStripMenuItem.Text = "Ausschneiden"
    '
    'KopierenToolStripMenuItem
    '
    Me.KopierenToolStripMenuItem.Image = CType(resources.GetObject("KopierenToolStripMenuItem.Image"), System.Drawing.Image)
    Me.KopierenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
    Me.KopierenToolStripMenuItem.Name = "KopierenToolStripMenuItem"
    Me.KopierenToolStripMenuItem.ShortcutKeyDisplayString = ""
    Me.KopierenToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
    Me.KopierenToolStripMenuItem.Tag = "Any"
    Me.KopierenToolStripMenuItem.Text = "Kopieren"
    '
    'EinfuegenToolStripMenuItem
    '
    Me.EinfuegenToolStripMenuItem.Image = CType(resources.GetObject("EinfuegenToolStripMenuItem.Image"), System.Drawing.Image)
    Me.EinfuegenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
    Me.EinfuegenToolStripMenuItem.Name = "EinfuegenToolStripMenuItem"
    Me.EinfuegenToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
    Me.EinfuegenToolStripMenuItem.Tag = "NoSel"
    Me.EinfuegenToolStripMenuItem.Text = "Einfügen"
    '
    'DuplizierenToolStripMenuItem
    '
    Me.DuplizierenToolStripMenuItem.Enabled = False
    Me.DuplizierenToolStripMenuItem.Name = "DuplizierenToolStripMenuItem"
    Me.DuplizierenToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl D"
    Me.DuplizierenToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
    Me.DuplizierenToolStripMenuItem.Tag = "Any"
    Me.DuplizierenToolStripMenuItem.Text = "Duplizieren"
    '
    'LoeschenToolStripMenuItem
    '
    Me.LoeschenToolStripMenuItem.Image = CType(resources.GetObject("LoeschenToolStripMenuItem.Image"), System.Drawing.Image)
    Me.LoeschenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
    Me.LoeschenToolStripMenuItem.Name = "LoeschenToolStripMenuItem"
    Me.LoeschenToolStripMenuItem.ShortcutKeyDisplayString = "Entf"
    Me.LoeschenToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
    Me.LoeschenToolStripMenuItem.Tag = "Any"
    Me.LoeschenToolStripMenuItem.Text = "Löschen"
    '
    'ToolStripMenuItem1
    '
    Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
    Me.ToolStripMenuItem1.Size = New System.Drawing.Size(169, 6)
    '
    'AllesAuswählenToolStripMenuItem
    '
    Me.AllesAuswählenToolStripMenuItem.Name = "AllesAuswählenToolStripMenuItem"
    Me.AllesAuswählenToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
    Me.AllesAuswählenToolStripMenuItem.Text = "Alles auswählen"
    '
    'AuswahlAufhebenToolStripMenuItem
    '
    Me.AuswahlAufhebenToolStripMenuItem.Name = "AuswahlAufhebenToolStripMenuItem"
    Me.AuswahlAufhebenToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
    Me.AuswahlAufhebenToolStripMenuItem.Tag = "Any"
    Me.AuswahlAufhebenToolStripMenuItem.Text = "Auswahl aufheben"
    '
    'ToolStripMenuItem2
    '
    Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
    Me.ToolStripMenuItem2.Size = New System.Drawing.Size(169, 6)
    '
    'ZeichenbereichToolStripMenuItem
    '
    Me.ZeichenbereichToolStripMenuItem.Image = CType(resources.GetObject("ZeichenbereichToolStripMenuItem.Image"), System.Drawing.Image)
    Me.ZeichenbereichToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
    Me.ZeichenbereichToolStripMenuItem.Name = "ZeichenbereichToolStripMenuItem"
    Me.ZeichenbereichToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
    Me.ZeichenbereichToolStripMenuItem.Tag = ""
    Me.ZeichenbereichToolStripMenuItem.Text = "Zeichenbereich ..."
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
    Me.Controls.Add(Me.MenuStrip1)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MainMenuStrip = Me.MenuStrip1
    Me.Name = "frm_mdiClient"
    Me.Text = "Unbenannt"
    Me.MenuStrip1.ResumeLayout(False)
    Me.MenuStrip1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Public WithEvents vcc As ScreenGrab6.Vector.VCanvasControl
  Friend WithEvents MenuStrip1 As MenuStrip
  Friend WithEvents BearbeitenToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents ZeichenbereichToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents AusschneidenToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents KopierenToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents EinfuegenToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents DuplizierenToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents LoeschenToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
  Friend WithEvents AllesAuswählenToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
  Friend WithEvents AuswahlAufhebenToolStripMenuItem As ToolStripMenuItem
End Class
