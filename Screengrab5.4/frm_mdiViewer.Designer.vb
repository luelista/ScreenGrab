<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_mdiViewer
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_mdiViewer))
    Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.HintergrundfarbeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.AutomatischEinfuegenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.RahmenAnzeigenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.RahmenlosTransparentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
    Me.TextboxEinfuegenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.HTMLSeiteErzeugenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.EinlesenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
    Me.lblMoveme = New System.Windows.Forms.Label
    Me.cmsPicBox = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.BringToFrontToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.SendToBackToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.CopyImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.OpenImageInMainWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ContextMenuStrip1.SuspendLayout()
    Me.cmsPicBox.SuspendLayout()
    Me.SuspendLayout()
    '
    'ContextMenuStrip1
    '
    Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HintergrundfarbeToolStripMenuItem, Me.AutomatischEinfuegenToolStripMenuItem, Me.RahmenAnzeigenToolStripMenuItem, Me.RahmenlosTransparentToolStripMenuItem, Me.ToolStripMenuItem1, Me.TextboxEinfuegenToolStripMenuItem, Me.HTMLSeiteErzeugenToolStripMenuItem, Me.EinlesenToolStripMenuItem})
    Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
    Me.ContextMenuStrip1.Size = New System.Drawing.Size(213, 164)
    '
    'HintergrundfarbeToolStripMenuItem
    '
    Me.HintergrundfarbeToolStripMenuItem.Name = "HintergrundfarbeToolStripMenuItem"
    Me.HintergrundfarbeToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
    Me.HintergrundfarbeToolStripMenuItem.Text = "Hintergrundfarbe ..."
    '
    'AutomatischEinfuegenToolStripMenuItem
    '
    Me.AutomatischEinfuegenToolStripMenuItem.Checked = True
    Me.AutomatischEinfuegenToolStripMenuItem.CheckOnClick = True
    Me.AutomatischEinfuegenToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
    Me.AutomatischEinfuegenToolStripMenuItem.Name = "AutomatischEinfuegenToolStripMenuItem"
    Me.AutomatischEinfuegenToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
    Me.AutomatischEinfuegenToolStripMenuItem.Text = "Automatisch einfügen"
    '
    'RahmenAnzeigenToolStripMenuItem
    '
    Me.RahmenAnzeigenToolStripMenuItem.CheckOnClick = True
    Me.RahmenAnzeigenToolStripMenuItem.Name = "RahmenAnzeigenToolStripMenuItem"
    Me.RahmenAnzeigenToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
    Me.RahmenAnzeigenToolStripMenuItem.Text = "Rahmen anzeigen"
    '
    'RahmenlosTransparentToolStripMenuItem
    '
    Me.RahmenlosTransparentToolStripMenuItem.CheckOnClick = True
    Me.RahmenlosTransparentToolStripMenuItem.Name = "RahmenlosTransparentToolStripMenuItem"
    Me.RahmenlosTransparentToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
    Me.RahmenlosTransparentToolStripMenuItem.Text = "Rahmenlos && Transparent"
    '
    'ToolStripMenuItem1
    '
    Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
    Me.ToolStripMenuItem1.Size = New System.Drawing.Size(209, 6)
    '
    'TextboxEinfuegenToolStripMenuItem
    '
    Me.TextboxEinfuegenToolStripMenuItem.Name = "TextboxEinfuegenToolStripMenuItem"
    Me.TextboxEinfuegenToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
    Me.TextboxEinfuegenToolStripMenuItem.Text = "Textbox einfügen ..."
    '
    'HTMLSeiteErzeugenToolStripMenuItem
    '
    Me.HTMLSeiteErzeugenToolStripMenuItem.Name = "HTMLSeiteErzeugenToolStripMenuItem"
    Me.HTMLSeiteErzeugenToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
    Me.HTMLSeiteErzeugenToolStripMenuItem.Text = "Speichern unter ..."
    '
    'EinlesenToolStripMenuItem
    '
    Me.EinlesenToolStripMenuItem.Name = "EinlesenToolStripMenuItem"
    Me.EinlesenToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
    Me.EinlesenToolStripMenuItem.Text = "Datei öffnen"
    '
    'ColorDialog1
    '
    Me.ColorDialog1.Color = System.Drawing.Color.WhiteSmoke
    '
    'lblMoveme
    '
    Me.lblMoveme.BackColor = System.Drawing.Color.LightGray
    Me.lblMoveme.Cursor = System.Windows.Forms.Cursors.SizeAll
    Me.lblMoveme.Location = New System.Drawing.Point(9, 1)
    Me.lblMoveme.Name = "lblMoveme"
    Me.lblMoveme.Size = New System.Drawing.Size(62, 19)
    Me.lblMoveme.TabIndex = 1
    Me.lblMoveme.Text = "|  |  |  |  |"
    Me.lblMoveme.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    Me.lblMoveme.Visible = False
    '
    'cmsPicBox
    '
    Me.cmsPicBox.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BringToFrontToolStripMenuItem, Me.SendToBackToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.CopyImageToolStripMenuItem, Me.OpenImageInMainWindowToolStripMenuItem})
    Me.cmsPicBox.Name = "cmsPicBox"
    Me.cmsPicBox.Size = New System.Drawing.Size(230, 114)
    '
    'BringToFrontToolStripMenuItem
    '
    Me.BringToFrontToolStripMenuItem.Name = "BringToFrontToolStripMenuItem"
    Me.BringToFrontToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
    Me.BringToFrontToolStripMenuItem.Text = "Bring To Front"
    '
    'SendToBackToolStripMenuItem
    '
    Me.SendToBackToolStripMenuItem.Name = "SendToBackToolStripMenuItem"
    Me.SendToBackToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
    Me.SendToBackToolStripMenuItem.Text = "Send To Back"
    '
    'DeleteToolStripMenuItem
    '
    Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
    Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
    Me.DeleteToolStripMenuItem.Text = "Delete"
    '
    'CopyImageToolStripMenuItem
    '
    Me.CopyImageToolStripMenuItem.Name = "CopyImageToolStripMenuItem"
    Me.CopyImageToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
    Me.CopyImageToolStripMenuItem.Text = "Copy Image"
    '
    'OpenImageInMainWindowToolStripMenuItem
    '
    Me.OpenImageInMainWindowToolStripMenuItem.Name = "OpenImageInMainWindowToolStripMenuItem"
    Me.OpenImageInMainWindowToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
    Me.OpenImageInMainWindowToolStripMenuItem.Text = "Open Image In Main Window"
    '
    'frm_mdiViewer
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.WhiteSmoke
    Me.ClientSize = New System.Drawing.Size(621, 590)
    Me.ContextMenuStrip = Me.ContextMenuStrip1
    Me.Controls.Add(Me.lblMoveme)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.Name = "frm_mdiViewer"
    Me.Text = "ScreenGrab 5 Collage-Modus"
    Me.ContextMenuStrip1.ResumeLayout(False)
    Me.cmsPicBox.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
  Friend WithEvents HintergrundfarbeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents AutomatischEinfuegenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents RahmenAnzeigenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
  Friend WithEvents HTMLSeiteErzeugenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents EinlesenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents TextboxEinfuegenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents RahmenlosTransparentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents lblMoveme As System.Windows.Forms.Label
  Friend WithEvents cmsPicBox As System.Windows.Forms.ContextMenuStrip
  Friend WithEvents BringToFrontToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents SendToBackToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents CopyImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents OpenImageInMainWindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
End Class
