<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VCanvasControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VCanvasControl))
    Me.txtEditTB = New System.Windows.Forms.TextBox
    Me.Panel2 = New System.Windows.Forms.Panel
    Me.lblResizeVert = New System.Windows.Forms.Label
    Me.lblResizeDiag = New System.Windows.Forms.Label
    Me.lblResizeHorz = New System.Windows.Forms.Label
    Me.PictureBox1 = New System.Windows.Forms.PictureBox
    Me.cmsCanvas = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.KlasseneigenschaftenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.BeziehungHerstellenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ISTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.HATToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.KENNTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.AttributAddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.MethodeAddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ZeichenbereichToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.SchriftartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.LinieFormatierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.FarbverlaufZuweisenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.OriginalgroesseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.BeziehungsanfangAendernToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.BeziehungsendeAendernToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ConvolutionFiltersexperimentellToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator
    Me.GruppierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.GruppierungAufhebenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.DrehenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.AnordnungToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.LeftsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.CentersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.RightsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.TopsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.MiddlesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.BottomsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
    Me.MakeSameWidthToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.MakeSameHeightToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
    Me.EqualHorizontalSpacingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.EqualVerticalSpacingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator
    Me.BringToFrontToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.SendToBackToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator
    Me.AusschneidenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.KopierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.EinfuegenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.DuplizierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.LoeschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.cmsAddRelationMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.ISTToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
    Me.HATToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
    Me.KENNTToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
    Me.cmsAddUmlItemMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripMenuItem
    Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripMenuItem
    Me.PEigenschaftHinzufügenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.Panel2.SuspendLayout()
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.cmsCanvas.SuspendLayout()
    Me.cmsAddRelationMenu.SuspendLayout()
    Me.cmsAddUmlItemMenu.SuspendLayout()
    Me.SuspendLayout()
    '
    'txtEditTB
    '
    Me.txtEditTB.BackColor = System.Drawing.Color.LemonChiffon
    Me.txtEditTB.Location = New System.Drawing.Point(41, 58)
    Me.txtEditTB.Multiline = True
    Me.txtEditTB.Name = "txtEditTB"
    Me.txtEditTB.Size = New System.Drawing.Size(178, 83)
    Me.txtEditTB.TabIndex = 13
    Me.txtEditTB.Visible = False
    '
    'Panel2
    '
    Me.Panel2.AutoScroll = True
    Me.Panel2.BackColor = System.Drawing.Color.Gray
    Me.Panel2.Controls.Add(Me.lblResizeVert)
    Me.Panel2.Controls.Add(Me.lblResizeDiag)
    Me.Panel2.Controls.Add(Me.lblResizeHorz)
    Me.Panel2.Controls.Add(Me.PictureBox1)
    Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Panel2.Location = New System.Drawing.Point(0, 0)
    Me.Panel2.Name = "Panel2"
    Me.Panel2.Size = New System.Drawing.Size(711, 474)
    Me.Panel2.TabIndex = 12
    '
    'lblResizeVert
    '
    Me.lblResizeVert.BackColor = System.Drawing.Color.Gainsboro
    Me.lblResizeVert.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblResizeVert.Cursor = System.Windows.Forms.Cursors.SizeNS
    Me.lblResizeVert.Location = New System.Drawing.Point(2048, 2048)
    Me.lblResizeVert.Name = "lblResizeVert"
    Me.lblResizeVert.Size = New System.Drawing.Size(11, 12)
    Me.lblResizeVert.TabIndex = 11
    '
    'lblResizeDiag
    '
    Me.lblResizeDiag.BackColor = System.Drawing.Color.Gainsboro
    Me.lblResizeDiag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblResizeDiag.Cursor = System.Windows.Forms.Cursors.SizeNWSE
    Me.lblResizeDiag.Location = New System.Drawing.Point(2048, 2048)
    Me.lblResizeDiag.Name = "lblResizeDiag"
    Me.lblResizeDiag.Size = New System.Drawing.Size(11, 12)
    Me.lblResizeDiag.TabIndex = 10
    '
    'lblResizeHorz
    '
    Me.lblResizeHorz.BackColor = System.Drawing.Color.Gainsboro
    Me.lblResizeHorz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblResizeHorz.Cursor = System.Windows.Forms.Cursors.SizeWE
    Me.lblResizeHorz.Location = New System.Drawing.Point(2048, 203)
    Me.lblResizeHorz.Name = "lblResizeHorz"
    Me.lblResizeHorz.Size = New System.Drawing.Size(11, 12)
    Me.lblResizeHorz.TabIndex = 9
    '
    'PictureBox1
    '
    Me.PictureBox1.BackColor = System.Drawing.Color.White
    Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(2048, 2048)
    Me.PictureBox1.TabIndex = 0
    Me.PictureBox1.TabStop = False
    '
    'cmsCanvas
    '
    Me.cmsCanvas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KlasseneigenschaftenToolStripMenuItem, Me.BeziehungHerstellenToolStripMenuItem, Me.AttributAddToolStripMenuItem, Me.MethodeAddToolStripMenuItem, Me.ZeichenbereichToolStripMenuItem, Me.SchriftartToolStripMenuItem, Me.LinieFormatierenToolStripMenuItem, Me.FarbverlaufZuweisenToolStripMenuItem, Me.OriginalgroesseToolStripMenuItem, Me.BeziehungsanfangAendernToolStripMenuItem, Me.BeziehungsendeAendernToolStripMenuItem, Me.ConvolutionFiltersexperimentellToolStripMenuItem, Me.ToolStripMenuItem4, Me.GruppierenToolStripMenuItem, Me.GruppierungAufhebenToolStripMenuItem, Me.DrehenToolStripMenuItem, Me.AnordnungToolStripMenuItem, Me.ToolStripMenuItem5, Me.AusschneidenToolStripMenuItem, Me.KopierenToolStripMenuItem, Me.EinfuegenToolStripMenuItem, Me.DuplizierenToolStripMenuItem, Me.LoeschenToolStripMenuItem})
    Me.cmsCanvas.Name = "ContextMenuStrip1"
    Me.cmsCanvas.Size = New System.Drawing.Size(248, 478)
    '
    'KlasseneigenschaftenToolStripMenuItem
    '
    Me.KlasseneigenschaftenToolStripMenuItem.Image = CType(resources.GetObject("KlasseneigenschaftenToolStripMenuItem.Image"), System.Drawing.Image)
    Me.KlasseneigenschaftenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
    Me.KlasseneigenschaftenToolStripMenuItem.Name = "KlasseneigenschaftenToolStripMenuItem"
    Me.KlasseneigenschaftenToolStripMenuItem.ShortcutKeyDisplayString = ""
    Me.KlasseneigenschaftenToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
    Me.KlasseneigenschaftenToolStripMenuItem.Tag = "%VUMLClass"
    Me.KlasseneigenschaftenToolStripMenuItem.Text = "Klasseneigenschaften ..."
    '
    'BeziehungHerstellenToolStripMenuItem
    '
    Me.BeziehungHerstellenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ISTToolStripMenuItem, Me.HATToolStripMenuItem, Me.KENNTToolStripMenuItem})
    Me.BeziehungHerstellenToolStripMenuItem.Name = "BeziehungHerstellenToolStripMenuItem"
    Me.BeziehungHerstellenToolStripMenuItem.ShortcutKeyDisplayString = "Alt B"
    Me.BeziehungHerstellenToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
    Me.BeziehungHerstellenToolStripMenuItem.Tag = "%VUMLClass"
    Me.BeziehungHerstellenToolStripMenuItem.Text = "Beziehung herstellen"
    '
    'ISTToolStripMenuItem
    '
    Me.ISTToolStripMenuItem.Name = "ISTToolStripMenuItem"
    Me.ISTToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
    Me.ISTToolStripMenuItem.Tag = "1"
    Me.ISTToolStripMenuItem.Text = "&IST"
    '
    'HATToolStripMenuItem
    '
    Me.HATToolStripMenuItem.Name = "HATToolStripMenuItem"
    Me.HATToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
    Me.HATToolStripMenuItem.Tag = "2"
    Me.HATToolStripMenuItem.Text = "&HAT"
    '
    'KENNTToolStripMenuItem
    '
    Me.KENNTToolStripMenuItem.Name = "KENNTToolStripMenuItem"
    Me.KENNTToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
    Me.KENNTToolStripMenuItem.Tag = "3"
    Me.KENNTToolStripMenuItem.Text = "&KENNT"
    '
    'AttributAddToolStripMenuItem
    '
    Me.AttributAddToolStripMenuItem.Name = "AttributAddToolStripMenuItem"
    Me.AttributAddToolStripMenuItem.ShortcutKeyDisplayString = "Alt +, A"
    Me.AttributAddToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
    Me.AttributAddToolStripMenuItem.Tag = "%VUMLClass"
    Me.AttributAddToolStripMenuItem.Text = "Attribut hinzufügen ..."
    '
    'MethodeAddToolStripMenuItem
    '
    Me.MethodeAddToolStripMenuItem.Name = "MethodeAddToolStripMenuItem"
    Me.MethodeAddToolStripMenuItem.ShortcutKeyDisplayString = "Alt +, M"
    Me.MethodeAddToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
    Me.MethodeAddToolStripMenuItem.Tag = "%VUMLClass"
    Me.MethodeAddToolStripMenuItem.Text = "Methode hinzufügen ..."
    '
    'ZeichenbereichToolStripMenuItem
    '
    Me.ZeichenbereichToolStripMenuItem.Image = CType(resources.GetObject("ZeichenbereichToolStripMenuItem.Image"), System.Drawing.Image)
    Me.ZeichenbereichToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
    Me.ZeichenbereichToolStripMenuItem.Name = "ZeichenbereichToolStripMenuItem"
    Me.ZeichenbereichToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
    Me.ZeichenbereichToolStripMenuItem.Tag = "%NoSel"
    Me.ZeichenbereichToolStripMenuItem.Text = "Zeichenbereich ..."
    '
    'SchriftartToolStripMenuItem
    '
    Me.SchriftartToolStripMenuItem.Image = CType(resources.GetObject("SchriftartToolStripMenuItem.Image"), System.Drawing.Image)
    Me.SchriftartToolStripMenuItem.Name = "SchriftartToolStripMenuItem"
    Me.SchriftartToolStripMenuItem.ShortcutKeyDisplayString = "Alt Enter"
    Me.SchriftartToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
    Me.SchriftartToolStripMenuItem.Tag = "%VTextbox"
    Me.SchriftartToolStripMenuItem.Text = "Schriftart ..."
    '
    'LinieFormatierenToolStripMenuItem
    '
    Me.LinieFormatierenToolStripMenuItem.Image = CType(resources.GetObject("LinieFormatierenToolStripMenuItem.Image"), System.Drawing.Image)
    Me.LinieFormatierenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
    Me.LinieFormatierenToolStripMenuItem.Name = "LinieFormatierenToolStripMenuItem"
    Me.LinieFormatierenToolStripMenuItem.ShortcutKeyDisplayString = "Alt L"
    Me.LinieFormatierenToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
    Me.LinieFormatierenToolStripMenuItem.Tag = "%VRectangle,VLine,VElipse,VUMLClass"
    Me.LinieFormatierenToolStripMenuItem.Text = "Linie formatieren ..."
    '
    'FarbverlaufZuweisenToolStripMenuItem
    '
    Me.FarbverlaufZuweisenToolStripMenuItem.Image = CType(resources.GetObject("FarbverlaufZuweisenToolStripMenuItem.Image"), System.Drawing.Image)
    Me.FarbverlaufZuweisenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
    Me.FarbverlaufZuweisenToolStripMenuItem.Name = "FarbverlaufZuweisenToolStripMenuItem"
    Me.FarbverlaufZuweisenToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
    Me.FarbverlaufZuweisenToolStripMenuItem.Text = "Farbverlauf zuweisen ..."
    '
    'OriginalgroesseToolStripMenuItem
    '
    Me.OriginalgroesseToolStripMenuItem.Image = CType(resources.GetObject("OriginalgroesseToolStripMenuItem.Image"), System.Drawing.Image)
    Me.OriginalgroesseToolStripMenuItem.Name = "OriginalgroesseToolStripMenuItem"
    Me.OriginalgroesseToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
    Me.OriginalgroesseToolStripMenuItem.Tag = "%VImage"
    Me.OriginalgroesseToolStripMenuItem.Text = "Originalgröße"
    '
    'BeziehungsanfangAendernToolStripMenuItem
    '
    Me.BeziehungsanfangAendernToolStripMenuItem.Name = "BeziehungsanfangAendernToolStripMenuItem"
    Me.BeziehungsanfangAendernToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
    Me.BeziehungsanfangAendernToolStripMenuItem.Tag = "%VLine"
    Me.BeziehungsanfangAendernToolStripMenuItem.Text = "Beziehungsanfang ändern"
    '
    'BeziehungsendeAendernToolStripMenuItem
    '
    Me.BeziehungsendeAendernToolStripMenuItem.Name = "BeziehungsendeAendernToolStripMenuItem"
    Me.BeziehungsendeAendernToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
    Me.BeziehungsendeAendernToolStripMenuItem.Tag = "%VLine"
    Me.BeziehungsendeAendernToolStripMenuItem.Text = "Beziehungsende ändern"
    '
    'ConvolutionFiltersexperimentellToolStripMenuItem
    '
    Me.ConvolutionFiltersexperimentellToolStripMenuItem.Name = "ConvolutionFiltersexperimentellToolStripMenuItem"
    Me.ConvolutionFiltersexperimentellToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
    Me.ConvolutionFiltersexperimentellToolStripMenuItem.Tag = "%VImage,VFilter"
    Me.ConvolutionFiltersexperimentellToolStripMenuItem.Text = "Bildeffekte / Filter"
    '
    'ToolStripMenuItem4
    '
    Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
    Me.ToolStripMenuItem4.Size = New System.Drawing.Size(244, 6)
    '
    'GruppierenToolStripMenuItem
    '
    Me.GruppierenToolStripMenuItem.Name = "GruppierenToolStripMenuItem"
    Me.GruppierenToolStripMenuItem.ShortcutKeyDisplayString = "F7"
    Me.GruppierenToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
    Me.GruppierenToolStripMenuItem.Tag = "Multi"
    Me.GruppierenToolStripMenuItem.Text = "Gruppieren"
    '
    'GruppierungAufhebenToolStripMenuItem
    '
    Me.GruppierungAufhebenToolStripMenuItem.Name = "GruppierungAufhebenToolStripMenuItem"
    Me.GruppierungAufhebenToolStripMenuItem.ShortcutKeyDisplayString = "F8"
    Me.GruppierungAufhebenToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
    Me.GruppierungAufhebenToolStripMenuItem.Tag = "%VGroup"
    Me.GruppierungAufhebenToolStripMenuItem.Text = "Gruppierung aufheben"
    '
    'DrehenToolStripMenuItem
    '
    Me.DrehenToolStripMenuItem.Image = CType(resources.GetObject("DrehenToolStripMenuItem.Image"), System.Drawing.Image)
    Me.DrehenToolStripMenuItem.Name = "DrehenToolStripMenuItem"
    Me.DrehenToolStripMenuItem.ShortcutKeyDisplayString = "Alt R"
    Me.DrehenToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
    Me.DrehenToolStripMenuItem.Tag = "Any"
    Me.DrehenToolStripMenuItem.Text = "Drehen ..."
    '
    'AnordnungToolStripMenuItem
    '
    Me.AnordnungToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LeftsToolStripMenuItem, Me.CentersToolStripMenuItem, Me.RightsToolStripMenuItem, Me.TopsToolStripMenuItem, Me.MiddlesToolStripMenuItem, Me.BottomsToolStripMenuItem, Me.ToolStripMenuItem1, Me.MakeSameWidthToolStripMenuItem, Me.MakeSameHeightToolStripMenuItem, Me.ToolStripMenuItem2, Me.EqualHorizontalSpacingToolStripMenuItem, Me.EqualVerticalSpacingToolStripMenuItem, Me.ToolStripMenuItem3, Me.BringToFrontToolStripMenuItem, Me.SendToBackToolStripMenuItem})
    Me.AnordnungToolStripMenuItem.Name = "AnordnungToolStripMenuItem"
    Me.AnordnungToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
    Me.AnordnungToolStripMenuItem.Tag = "Any"
    Me.AnordnungToolStripMenuItem.Text = "Anordnung"
    '
    'LeftsToolStripMenuItem
    '
    Me.LeftsToolStripMenuItem.Image = CType(resources.GetObject("LeftsToolStripMenuItem.Image"), System.Drawing.Image)
    Me.LeftsToolStripMenuItem.Name = "LeftsToolStripMenuItem"
    Me.LeftsToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
    Me.LeftsToolStripMenuItem.Tag = "Multi"
    Me.LeftsToolStripMenuItem.Text = "Lefts"
    '
    'CentersToolStripMenuItem
    '
    Me.CentersToolStripMenuItem.Image = CType(resources.GetObject("CentersToolStripMenuItem.Image"), System.Drawing.Image)
    Me.CentersToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
    Me.CentersToolStripMenuItem.Name = "CentersToolStripMenuItem"
    Me.CentersToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
    Me.CentersToolStripMenuItem.Tag = "Multi"
    Me.CentersToolStripMenuItem.Text = "Centers"
    Me.CentersToolStripMenuItem.Visible = False
    '
    'RightsToolStripMenuItem
    '
    Me.RightsToolStripMenuItem.Image = CType(resources.GetObject("RightsToolStripMenuItem.Image"), System.Drawing.Image)
    Me.RightsToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
    Me.RightsToolStripMenuItem.Name = "RightsToolStripMenuItem"
    Me.RightsToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
    Me.RightsToolStripMenuItem.Tag = "Multi"
    Me.RightsToolStripMenuItem.Text = "Rights"
    '
    'TopsToolStripMenuItem
    '
    Me.TopsToolStripMenuItem.Image = CType(resources.GetObject("TopsToolStripMenuItem.Image"), System.Drawing.Image)
    Me.TopsToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
    Me.TopsToolStripMenuItem.Name = "TopsToolStripMenuItem"
    Me.TopsToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
    Me.TopsToolStripMenuItem.Tag = "Multi"
    Me.TopsToolStripMenuItem.Text = "Tops"
    '
    'MiddlesToolStripMenuItem
    '
    Me.MiddlesToolStripMenuItem.Image = CType(resources.GetObject("MiddlesToolStripMenuItem.Image"), System.Drawing.Image)
    Me.MiddlesToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
    Me.MiddlesToolStripMenuItem.Name = "MiddlesToolStripMenuItem"
    Me.MiddlesToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
    Me.MiddlesToolStripMenuItem.Tag = "Multi"
    Me.MiddlesToolStripMenuItem.Text = "Middles"
    Me.MiddlesToolStripMenuItem.Visible = False
    '
    'BottomsToolStripMenuItem
    '
    Me.BottomsToolStripMenuItem.Image = CType(resources.GetObject("BottomsToolStripMenuItem.Image"), System.Drawing.Image)
    Me.BottomsToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
    Me.BottomsToolStripMenuItem.Name = "BottomsToolStripMenuItem"
    Me.BottomsToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
    Me.BottomsToolStripMenuItem.Tag = "Multi"
    Me.BottomsToolStripMenuItem.Text = "Bottoms"
    '
    'ToolStripMenuItem1
    '
    Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
    Me.ToolStripMenuItem1.Size = New System.Drawing.Size(212, 6)
    Me.ToolStripMenuItem1.Tag = "Multi"
    '
    'MakeSameWidthToolStripMenuItem
    '
    Me.MakeSameWidthToolStripMenuItem.Name = "MakeSameWidthToolStripMenuItem"
    Me.MakeSameWidthToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
    Me.MakeSameWidthToolStripMenuItem.Tag = "Multi"
    Me.MakeSameWidthToolStripMenuItem.Text = "Make same width"
    '
    'MakeSameHeightToolStripMenuItem
    '
    Me.MakeSameHeightToolStripMenuItem.Name = "MakeSameHeightToolStripMenuItem"
    Me.MakeSameHeightToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
    Me.MakeSameHeightToolStripMenuItem.Tag = "Multi"
    Me.MakeSameHeightToolStripMenuItem.Text = "Make same height"
    '
    'ToolStripMenuItem2
    '
    Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
    Me.ToolStripMenuItem2.Size = New System.Drawing.Size(212, 6)
    Me.ToolStripMenuItem2.Tag = "Multi"
    '
    'EqualHorizontalSpacingToolStripMenuItem
    '
    Me.EqualHorizontalSpacingToolStripMenuItem.Image = CType(resources.GetObject("EqualHorizontalSpacingToolStripMenuItem.Image"), System.Drawing.Image)
    Me.EqualHorizontalSpacingToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
    Me.EqualHorizontalSpacingToolStripMenuItem.Name = "EqualHorizontalSpacingToolStripMenuItem"
    Me.EqualHorizontalSpacingToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
    Me.EqualHorizontalSpacingToolStripMenuItem.Tag = "Multi"
    Me.EqualHorizontalSpacingToolStripMenuItem.Text = "Equal horizontal spacing"
    Me.EqualHorizontalSpacingToolStripMenuItem.Visible = False
    '
    'EqualVerticalSpacingToolStripMenuItem
    '
    Me.EqualVerticalSpacingToolStripMenuItem.Image = CType(resources.GetObject("EqualVerticalSpacingToolStripMenuItem.Image"), System.Drawing.Image)
    Me.EqualVerticalSpacingToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
    Me.EqualVerticalSpacingToolStripMenuItem.Name = "EqualVerticalSpacingToolStripMenuItem"
    Me.EqualVerticalSpacingToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
    Me.EqualVerticalSpacingToolStripMenuItem.Tag = "Multi"
    Me.EqualVerticalSpacingToolStripMenuItem.Text = "Equal vertical spacing"
    Me.EqualVerticalSpacingToolStripMenuItem.Visible = False
    '
    'ToolStripMenuItem3
    '
    Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
    Me.ToolStripMenuItem3.Size = New System.Drawing.Size(212, 6)
    Me.ToolStripMenuItem3.Tag = "Multi"
    Me.ToolStripMenuItem3.Visible = False
    '
    'BringToFrontToolStripMenuItem
    '
    Me.BringToFrontToolStripMenuItem.Image = CType(resources.GetObject("BringToFrontToolStripMenuItem.Image"), System.Drawing.Image)
    Me.BringToFrontToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
    Me.BringToFrontToolStripMenuItem.Name = "BringToFrontToolStripMenuItem"
    Me.BringToFrontToolStripMenuItem.ShortcutKeyDisplayString = "Strg BildAuf"
    Me.BringToFrontToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
    Me.BringToFrontToolStripMenuItem.Tag = "Any"
    Me.BringToFrontToolStripMenuItem.Text = "Bring to front"
    '
    'SendToBackToolStripMenuItem
    '
    Me.SendToBackToolStripMenuItem.Image = CType(resources.GetObject("SendToBackToolStripMenuItem.Image"), System.Drawing.Image)
    Me.SendToBackToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
    Me.SendToBackToolStripMenuItem.Name = "SendToBackToolStripMenuItem"
    Me.SendToBackToolStripMenuItem.ShortcutKeyDisplayString = "Strg BildAb"
    Me.SendToBackToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
    Me.SendToBackToolStripMenuItem.Tag = "Any"
    Me.SendToBackToolStripMenuItem.Text = "Send to back"
    '
    'ToolStripMenuItem5
    '
    Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
    Me.ToolStripMenuItem5.Size = New System.Drawing.Size(244, 6)
    '
    'AusschneidenToolStripMenuItem
    '
    Me.AusschneidenToolStripMenuItem.Image = CType(resources.GetObject("AusschneidenToolStripMenuItem.Image"), System.Drawing.Image)
    Me.AusschneidenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
    Me.AusschneidenToolStripMenuItem.Name = "AusschneidenToolStripMenuItem"
    Me.AusschneidenToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
    Me.AusschneidenToolStripMenuItem.Tag = "Any"
    Me.AusschneidenToolStripMenuItem.Text = "Ausschneiden"
    '
    'KopierenToolStripMenuItem
    '
    Me.KopierenToolStripMenuItem.Image = CType(resources.GetObject("KopierenToolStripMenuItem.Image"), System.Drawing.Image)
    Me.KopierenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
    Me.KopierenToolStripMenuItem.Name = "KopierenToolStripMenuItem"
    Me.KopierenToolStripMenuItem.ShortcutKeyDisplayString = ""
    Me.KopierenToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
    Me.KopierenToolStripMenuItem.Tag = "Any"
    Me.KopierenToolStripMenuItem.Text = "Kopieren"
    '
    'EinfuegenToolStripMenuItem
    '
    Me.EinfuegenToolStripMenuItem.Image = CType(resources.GetObject("EinfuegenToolStripMenuItem.Image"), System.Drawing.Image)
    Me.EinfuegenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
    Me.EinfuegenToolStripMenuItem.Name = "EinfuegenToolStripMenuItem"
    Me.EinfuegenToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
    Me.EinfuegenToolStripMenuItem.Tag = "NoSel"
    Me.EinfuegenToolStripMenuItem.Text = "Einfügen"
    '
    'DuplizierenToolStripMenuItem
    '
    Me.DuplizierenToolStripMenuItem.Enabled = False
    Me.DuplizierenToolStripMenuItem.Name = "DuplizierenToolStripMenuItem"
    Me.DuplizierenToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl D"
    Me.DuplizierenToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
    Me.DuplizierenToolStripMenuItem.Tag = "Any"
    Me.DuplizierenToolStripMenuItem.Text = "Duplizieren"
    '
    'LoeschenToolStripMenuItem
    '
    Me.LoeschenToolStripMenuItem.Image = CType(resources.GetObject("LoeschenToolStripMenuItem.Image"), System.Drawing.Image)
    Me.LoeschenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
    Me.LoeschenToolStripMenuItem.Name = "LoeschenToolStripMenuItem"
    Me.LoeschenToolStripMenuItem.ShortcutKeyDisplayString = "Entf"
    Me.LoeschenToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
    Me.LoeschenToolStripMenuItem.Tag = "Any"
    Me.LoeschenToolStripMenuItem.Text = "Löschen"
    '
    'cmsAddRelationMenu
    '
    Me.cmsAddRelationMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ISTToolStripMenuItem1, Me.HATToolStripMenuItem1, Me.KENNTToolStripMenuItem1})
    Me.cmsAddRelationMenu.Name = "cmsAddRelationMenu"
    Me.cmsAddRelationMenu.Size = New System.Drawing.Size(113, 70)
    '
    'ISTToolStripMenuItem1
    '
    Me.ISTToolStripMenuItem1.Name = "ISTToolStripMenuItem1"
    Me.ISTToolStripMenuItem1.Size = New System.Drawing.Size(112, 22)
    Me.ISTToolStripMenuItem1.Tag = "1"
    Me.ISTToolStripMenuItem1.Text = "&IST"
    '
    'HATToolStripMenuItem1
    '
    Me.HATToolStripMenuItem1.Name = "HATToolStripMenuItem1"
    Me.HATToolStripMenuItem1.Size = New System.Drawing.Size(112, 22)
    Me.HATToolStripMenuItem1.Tag = "2"
    Me.HATToolStripMenuItem1.Text = "&HAT"
    '
    'KENNTToolStripMenuItem1
    '
    Me.KENNTToolStripMenuItem1.Name = "KENNTToolStripMenuItem1"
    Me.KENNTToolStripMenuItem1.Size = New System.Drawing.Size(112, 22)
    Me.KENNTToolStripMenuItem1.Tag = "3"
    Me.KENNTToolStripMenuItem1.Text = "&KENNT"
    '
    'cmsAddUmlItemMenu
    '
    Me.cmsAddUmlItemMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem8, Me.ToolStripMenuItem9, Me.PEigenschaftHinzufügenToolStripMenuItem})
    Me.cmsAddUmlItemMenu.Name = "cmsAddRelationMenu"
    Me.cmsAddUmlItemMenu.Size = New System.Drawing.Size(215, 70)
    '
    'ToolStripMenuItem8
    '
    Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
    Me.ToolStripMenuItem8.ShortcutKeyDisplayString = ""
    Me.ToolStripMenuItem8.Size = New System.Drawing.Size(214, 22)
    Me.ToolStripMenuItem8.Tag = "%VUMLClass"
    Me.ToolStripMenuItem8.Text = "&A: Attribut hinzufügen ..."
    '
    'ToolStripMenuItem9
    '
    Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
    Me.ToolStripMenuItem9.ShortcutKeyDisplayString = ""
    Me.ToolStripMenuItem9.Size = New System.Drawing.Size(214, 22)
    Me.ToolStripMenuItem9.Tag = "%VUMLClass"
    Me.ToolStripMenuItem9.Text = "&M: Methode hinzufügen ..."
    '
    'PEigenschaftHinzufügenToolStripMenuItem
    '
    Me.PEigenschaftHinzufügenToolStripMenuItem.Enabled = False
    Me.PEigenschaftHinzufügenToolStripMenuItem.Name = "PEigenschaftHinzufügenToolStripMenuItem"
    Me.PEigenschaftHinzufügenToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
    Me.PEigenschaftHinzufügenToolStripMenuItem.Text = "&P: Eigenschaft hinzufügen"
    '
    'VCanvasControl
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.Controls.Add(Me.txtEditTB)
    Me.Controls.Add(Me.Panel2)
    Me.Name = "VCanvasControl"
    Me.Size = New System.Drawing.Size(711, 474)
    Me.Panel2.ResumeLayout(False)
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.cmsCanvas.ResumeLayout(False)
    Me.cmsAddRelationMenu.ResumeLayout(False)
    Me.cmsAddUmlItemMenu.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents txtEditTB As System.Windows.Forms.TextBox
  Friend WithEvents Panel2 As System.Windows.Forms.Panel
  Friend WithEvents lblResizeVert As System.Windows.Forms.Label
  Friend WithEvents lblResizeDiag As System.Windows.Forms.Label
  Friend WithEvents lblResizeHorz As System.Windows.Forms.Label
  Friend WithEvents KlasseneigenschaftenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents BeziehungHerstellenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ISTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents HATToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents KENNTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents AttributAddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents MethodeAddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ZeichenbereichToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents SchriftartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents LinieFormatierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents FarbverlaufZuweisenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents OriginalgroesseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents BeziehungsanfangAendernToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents BeziehungsendeAendernToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents DrehenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents AnordnungToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents LeftsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents CentersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents RightsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents TopsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents MiddlesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents BottomsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents MakeSameWidthToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents MakeSameHeightToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents EqualHorizontalSpacingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents EqualVerticalSpacingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents BringToFrontToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents SendToBackToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents AusschneidenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents KopierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents EinfuegenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents DuplizierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents LoeschenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ConvolutionFiltersexperimentellToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents cmsAddRelationMenu As System.Windows.Forms.ContextMenuStrip
  Friend WithEvents ISTToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents HATToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents KENNTToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents cmsAddUmlItemMenu As System.Windows.Forms.ContextMenuStrip
  Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents PEigenschaftHinzufügenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Public WithEvents cmsCanvas As System.Windows.Forms.ContextMenuStrip
  Public WithEvents PictureBox1 As System.Windows.Forms.PictureBox
  Friend WithEvents GruppierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents GruppierungAufhebenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
