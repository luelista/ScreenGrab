<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_main
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_main))
    Me.StatusStrip = New System.Windows.Forms.StatusStrip
    Me.labStatLogin = New System.Windows.Forms.ToolStripStatusLabel
    Me.labStatus = New System.Windows.Forms.ToolStripStatusLabel
    Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar
    Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
    Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton
    Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
    Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton
    Me.ToolStrip = New System.Windows.Forms.ToolStrip
    Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
    Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel
    Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
    Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton
    Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton
    Me.ToolStripButton5 = New System.Windows.Forms.ToolStripSplitButton
    Me.BildUploadenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
    Me.AutoUploadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
    Me.AusloggenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.EinstellungenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.AutoUploadToolStripDropDownButton = New System.Windows.Forms.ToolStripSplitButton
    Me.Imagechat_AutoUploadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.UploadToImageChatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
    Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
    Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
    Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
    Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel
    Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
    Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
    Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton
    Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.InDieZwischenablageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.HochladenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.SpeichernToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
    Me.SchließenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
    Me.tmrResetStatus = New System.Windows.Forms.Timer(Me.components)
    Me.txtFocusChatcher = New System.Windows.Forms.TextBox
    Me.WebBrowser1 = New System.Windows.Forms.WebBrowser
    Me.StatusStrip.SuspendLayout()
    Me.ToolStrip.SuspendLayout()
    Me.ContextMenuStrip1.SuspendLayout()
    Me.SuspendLayout()
    '
    'StatusStrip
    '
    Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.labStatLogin, Me.labStatus, Me.ToolStripProgressBar1})
    Me.StatusStrip.Location = New System.Drawing.Point(0, 444)
    Me.StatusStrip.Name = "StatusStrip"
    Me.StatusStrip.Size = New System.Drawing.Size(636, 22)
    Me.StatusStrip.TabIndex = 7
    Me.StatusStrip.Text = "StatusStrip"
    '
    'labStatLogin
    '
    Me.labStatLogin.AutoSize = False
    Me.labStatLogin.Name = "labStatLogin"
    Me.labStatLogin.Size = New System.Drawing.Size(90, 17)
    Me.labStatLogin.Text = "Ausgeloggt."
    '
    'labStatus
    '
    Me.labStatus.AutoSize = False
    Me.labStatus.Name = "labStatus"
    Me.labStatus.Size = New System.Drawing.Size(379, 17)
    Me.labStatus.Spring = True
    Me.labStatus.Text = "panel_labStatus"
    Me.labStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'ToolStripProgressBar1
    '
    Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
    Me.ToolStripProgressBar1.Size = New System.Drawing.Size(150, 16)
    '
    'SaveToolStripButton
    '
    Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
    Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
    Me.SaveToolStripButton.Name = "SaveToolStripButton"
    Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
    Me.SaveToolStripButton.Text = "Speichern"
    '
    'ToolStripSeparator1
    '
    Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
    Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
    '
    'PrintToolStripButton
    '
    Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.PrintToolStripButton.Enabled = False
    Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
    Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Black
    Me.PrintToolStripButton.Name = "PrintToolStripButton"
    Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
    Me.PrintToolStripButton.Text = "Drucken"
    '
    'ToolStrip
    '
    Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripLabel3, Me.ToolStripButton2, Me.ToolStripButton7, Me.ToolStripSeparator1, Me.SaveToolStripButton, Me.ToolStripButton6, Me.ToolStripButton5, Me.AutoUploadToolStripDropDownButton, Me.PrintToolStripButton, Me.ToolStripSeparator2, Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripLabel2, Me.ToolStripLabel4, Me.ToolStripLabel1, Me.ToolStripSeparator4, Me.ToolStripButton8})
    Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
    Me.ToolStrip.Name = "ToolStrip"
    Me.ToolStrip.Size = New System.Drawing.Size(636, 25)
    Me.ToolStrip.TabIndex = 6
    Me.ToolStrip.Text = "ToolStrip"
    '
    'ToolStripButton1
    '
    Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
    Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton1.Name = "ToolStripButton1"
    Me.ToolStripButton1.Size = New System.Drawing.Size(73, 22)
    Me.ToolStripButton1.Text = " G R A B !"
    Me.ToolStripButton1.ToolTipText = "ScreenGrab erstellen ..."
    '
    'ToolStripLabel3
    '
    Me.ToolStripLabel3.Name = "ToolStripLabel3"
    Me.ToolStripLabel3.Size = New System.Drawing.Size(13, 22)
    Me.ToolStripLabel3.Text = "  "
    '
    'ToolStripButton2
    '
    Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
    Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton2.Name = "ToolStripButton2"
    Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
    Me.ToolStripButton2.Text = "from clip"
    Me.ToolStripButton2.ToolTipText = "Aus der Zwischenablage holen"
    '
    'ToolStripButton7
    '
    Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
    Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton7.Name = "ToolStripButton7"
    Me.ToolStripButton7.Size = New System.Drawing.Size(23, 22)
    Me.ToolStripButton7.Text = "from file"
    Me.ToolStripButton7.ToolTipText = "Datei öffnen ..."
    '
    'ToolStripButton6
    '
    Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
    Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton6.Name = "ToolStripButton6"
    Me.ToolStripButton6.Size = New System.Drawing.Size(23, 22)
    Me.ToolStripButton6.Text = "ToolStripButton6"
    '
    'ToolStripButton5
    '
    Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.ToolStripButton5.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BildUploadenToolStripMenuItem, Me.ToolStripMenuItem2, Me.AutoUploadToolStripMenuItem, Me.ToolStripMenuItem1, Me.AusloggenToolStripMenuItem, Me.EinstellungenToolStripMenuItem})
    Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
    Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton5.Name = "ToolStripButton5"
    Me.ToolStripButton5.Size = New System.Drawing.Size(32, 22)
    Me.ToolStripButton5.Text = "Bild hochladen"
    '
    'BildUploadenToolStripMenuItem
    '
    Me.BildUploadenToolStripMenuItem.Name = "BildUploadenToolStripMenuItem"
    Me.BildUploadenToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
    Me.BildUploadenToolStripMenuItem.Text = "Bild hochladen"
    '
    'ToolStripMenuItem2
    '
    Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
    Me.ToolStripMenuItem2.Size = New System.Drawing.Size(157, 6)
    '
    'AutoUploadToolStripMenuItem
    '
    Me.AutoUploadToolStripMenuItem.Name = "AutoUploadToolStripMenuItem"
    Me.AutoUploadToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
    Me.AutoUploadToolStripMenuItem.Text = "Auto-Upload"
    '
    'ToolStripMenuItem1
    '
    Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
    Me.ToolStripMenuItem1.Size = New System.Drawing.Size(157, 6)
    '
    'AusloggenToolStripMenuItem
    '
    Me.AusloggenToolStripMenuItem.Enabled = False
    Me.AusloggenToolStripMenuItem.Name = "AusloggenToolStripMenuItem"
    Me.AusloggenToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
    Me.AusloggenToolStripMenuItem.Text = "Ausloggen"
    '
    'EinstellungenToolStripMenuItem
    '
    Me.EinstellungenToolStripMenuItem.Image = CType(resources.GetObject("EinstellungenToolStripMenuItem.Image"), System.Drawing.Image)
    Me.EinstellungenToolStripMenuItem.Name = "EinstellungenToolStripMenuItem"
    Me.EinstellungenToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
    Me.EinstellungenToolStripMenuItem.Text = "Einstellungen..."
    '
    'AutoUploadToolStripDropDownButton
    '
    Me.AutoUploadToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.AutoUploadToolStripDropDownButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Imagechat_AutoUploadToolStripMenuItem, Me.UploadToImageChatToolStripMenuItem})
    Me.AutoUploadToolStripDropDownButton.Image = CType(resources.GetObject("AutoUploadToolStripDropDownButton.Image"), System.Drawing.Image)
    Me.AutoUploadToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.AutoUploadToolStripDropDownButton.Name = "AutoUploadToolStripDropDownButton"
    Me.AutoUploadToolStripDropDownButton.Size = New System.Drawing.Size(32, 22)
    Me.AutoUploadToolStripDropDownButton.Text = "ToolStripSplitButton1"
    '
    'Imagechat_AutoUploadToolStripMenuItem
    '
    Me.Imagechat_AutoUploadToolStripMenuItem.Name = "Imagechat_AutoUploadToolStripMenuItem"
    Me.Imagechat_AutoUploadToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
    Me.Imagechat_AutoUploadToolStripMenuItem.Text = "Upload to Image Chat"
    '
    'UploadToImageChatToolStripMenuItem
    '
    Me.UploadToImageChatToolStripMenuItem.Name = "UploadToImageChatToolStripMenuItem"
    Me.UploadToImageChatToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
    Me.UploadToImageChatToolStripMenuItem.Text = "AutoUpload"
    '
    'ToolStripSeparator2
    '
    Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
    Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
    '
    'ToolStripButton3
    '
    Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
    Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton3.Name = "ToolStripButton3"
    Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
    Me.ToolStripButton3.Text = "Text einfügen"
    '
    'ToolStripButton4
    '
    Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.ToolStripButton4.Enabled = False
    Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
    Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton4.Name = "ToolStripButton4"
    Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
    Me.ToolStripButton4.Text = "Bild einfügen"
    '
    'ToolStripLabel2
    '
    Me.ToolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
    Me.ToolStripLabel2.Name = "ToolStripLabel2"
    Me.ToolStripLabel2.Size = New System.Drawing.Size(19, 22)
    Me.ToolStripLabel2.Text = "    "
    '
    'ToolStripLabel4
    '
    Me.ToolStripLabel4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
    Me.ToolStripLabel4.IsLink = True
    Me.ToolStripLabel4.Name = "ToolStripLabel4"
    Me.ToolStripLabel4.Size = New System.Drawing.Size(87, 22)
    Me.ToolStripLabel4.Text = "Bilderverwaltung"
    Me.ToolStripLabel4.ToolTipText = "Hier kannst du das letzte hochgeladene Bild betrachten, kopieren und in Seiten ei" & _
        "nbinden."
    '
    'ToolStripLabel1
    '
    Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
    Me.ToolStripLabel1.IsLink = True
    Me.ToolStripLabel1.Name = "ToolStripLabel1"
    Me.ToolStripLabel1.Size = New System.Drawing.Size(58, 22)
    Me.ToolStripLabel1.Text = "Homepage"
    '
    'ToolStripSeparator4
    '
    Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
    Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
    '
    'ToolStripButton8
    '
    Me.ToolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.ToolStripButton8.Image = CType(resources.GetObject("ToolStripButton8.Image"), System.Drawing.Image)
    Me.ToolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton8.Name = "ToolStripButton8"
    Me.ToolStripButton8.Size = New System.Drawing.Size(23, 22)
    Me.ToolStripButton8.Text = "ToolStripButton8"
    '
    'ContextMenuStrip1
    '
    Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InDieZwischenablageToolStripMenuItem, Me.HochladenToolStripMenuItem, Me.SpeichernToolStripMenuItem, Me.ToolStripSeparator3, Me.SchließenToolStripMenuItem})
    Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
    Me.ContextMenuStrip1.Size = New System.Drawing.Size(136, 98)
    '
    'InDieZwischenablageToolStripMenuItem
    '
    Me.InDieZwischenablageToolStripMenuItem.Name = "InDieZwischenablageToolStripMenuItem"
    Me.InDieZwischenablageToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
    Me.InDieZwischenablageToolStripMenuItem.Text = "Kopieren"
    '
    'HochladenToolStripMenuItem
    '
    Me.HochladenToolStripMenuItem.Name = "HochladenToolStripMenuItem"
    Me.HochladenToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
    Me.HochladenToolStripMenuItem.Text = "Hochladen"
    '
    'SpeichernToolStripMenuItem
    '
    Me.SpeichernToolStripMenuItem.Name = "SpeichernToolStripMenuItem"
    Me.SpeichernToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
    Me.SpeichernToolStripMenuItem.Text = "Speichern"
    '
    'ToolStripSeparator3
    '
    Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
    Me.ToolStripSeparator3.Size = New System.Drawing.Size(132, 6)
    '
    'SchließenToolStripMenuItem
    '
    Me.SchließenToolStripMenuItem.Name = "SchließenToolStripMenuItem"
    Me.SchließenToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
    Me.SchließenToolStripMenuItem.Text = "Schließen"
    '
    'OpenFileDialog1
    '
    Me.OpenFileDialog1.FileName = "OpenFileDialog1"
    '
    'tmrResetStatus
    '
    Me.tmrResetStatus.Interval = 3000
    '
    'txtFocusChatcher
    '
    Me.txtFocusChatcher.Location = New System.Drawing.Point(-1000, 126)
    Me.txtFocusChatcher.Name = "txtFocusChatcher"
    Me.txtFocusChatcher.Size = New System.Drawing.Size(88, 20)
    Me.txtFocusChatcher.TabIndex = 9
    '
    'WebBrowser1
    '
    Me.WebBrowser1.Location = New System.Drawing.Point(353, 341)
    Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
    Me.WebBrowser1.Name = "WebBrowser1"
    Me.WebBrowser1.Size = New System.Drawing.Size(95, 44)
    Me.WebBrowser1.TabIndex = 11
    Me.WebBrowser1.Visible = False
    '
    'frm_main
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(636, 466)
    Me.ContextMenuStrip = Me.ContextMenuStrip1
    Me.Controls.Add(Me.txtFocusChatcher)
    Me.Controls.Add(Me.WebBrowser1)
    Me.Controls.Add(Me.ToolStrip)
    Me.Controls.Add(Me.StatusStrip)
    Me.IsMdiContainer = True
    Me.Name = "frm_main"
    Me.Text = "ScreenGrab 3.0"
    Me.StatusStrip.ResumeLayout(False)
    Me.StatusStrip.PerformLayout()
    Me.ToolStrip.ResumeLayout(False)
    Me.ToolStrip.PerformLayout()
    Me.ContextMenuStrip1.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
  Friend WithEvents labStatus As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
  Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
  Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
  Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
  Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
  Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
  Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripSplitButton
  Friend WithEvents BildUploadenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents AutoUploadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
  Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
  Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents EinstellungenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
  Friend WithEvents InDieZwischenablageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents HochladenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents SpeichernToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents SchließenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
  Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
  Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
  Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
  Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
  Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
  Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
  Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
  Friend WithEvents tmrResetStatus As System.Windows.Forms.Timer
  Friend WithEvents labStatLogin As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
  Friend WithEvents txtFocusChatcher As System.Windows.Forms.TextBox
  Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents ToolStripButton8 As System.Windows.Forms.ToolStripButton
  Friend WithEvents AusloggenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
  Friend WithEvents AutoUploadToolStripDropDownButton As System.Windows.Forms.ToolStripSplitButton
  Friend WithEvents Imagechat_AutoUploadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents UploadToImageChatToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
