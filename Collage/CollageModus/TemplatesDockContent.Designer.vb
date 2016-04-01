<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TemplatesDockContent
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TemplatesDockContent))
    Me.Panel2 = New System.Windows.Forms.Panel()
    Me.TextBox2 = New System.Windows.Forms.TextBox()
    Me.btnTemplateAddSel = New System.Windows.Forms.Button()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.lvTemplates = New System.Windows.Forms.ListView()
    Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
    Me.Panel2.SuspendLayout()
    Me.SuspendLayout()
    '
    'Panel2
    '
    Me.Panel2.BackColor = System.Drawing.Color.DarkOrange
    Me.Panel2.Controls.Add(Me.TextBox2)
    Me.Panel2.Controls.Add(Me.btnTemplateAddSel)
    Me.Panel2.Controls.Add(Me.Label10)
    Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
    Me.Panel2.Location = New System.Drawing.Point(0, 536)
    Me.Panel2.Name = "Panel2"
    Me.Panel2.Size = New System.Drawing.Size(231, 44)
    Me.Panel2.TabIndex = 8
    '
    'TextBox2
    '
    Me.TextBox2.Location = New System.Drawing.Point(7, 18)
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Size = New System.Drawing.Size(126, 20)
    Me.TextBox2.TabIndex = 5
    Me.TextBox2.Text = "such..."
    '
    'btnTemplateAddSel
    '
    Me.btnTemplateAddSel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnTemplateAddSel.Location = New System.Drawing.Point(171, 5)
    Me.btnTemplateAddSel.Name = "btnTemplateAddSel"
    Me.btnTemplateAddSel.Size = New System.Drawing.Size(55, 35)
    Me.btnTemplateAddSel.TabIndex = 3
    Me.btnTemplateAddSel.Text = "+++"
    Me.btnTemplateAddSel.UseVisualStyleBackColor = True
    '
    'Label10
    '
    Me.Label10.BackColor = System.Drawing.Color.Transparent
    Me.Label10.Location = New System.Drawing.Point(4, 4)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(99, 17)
    Me.Label10.TabIndex = 4
    Me.Label10.Text = "Element-Vorlagen"
    '
    'lvTemplates
    '
    Me.lvTemplates.Dock = System.Windows.Forms.DockStyle.Fill
    Me.lvTemplates.LargeImageList = Me.ImageList2
    Me.lvTemplates.Location = New System.Drawing.Point(0, 0)
    Me.lvTemplates.Name = "lvTemplates"
    Me.lvTemplates.Size = New System.Drawing.Size(231, 536)
    Me.lvTemplates.TabIndex = 7
    Me.lvTemplates.UseCompatibleStateImageBehavior = False
    '
    'ImageList2
    '
    Me.ImageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
    Me.ImageList2.ImageSize = New System.Drawing.Size(150, 150)
    Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
    '
    'TemplatesDockContent
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(231, 580)
    Me.Controls.Add(Me.lvTemplates)
    Me.Controls.Add(Me.Panel2)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.HideOnClose = True
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.Name = "TemplatesDockContent"
    Me.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft
    Me.Text = "Vorlagen"
    Me.Panel2.ResumeLayout(False)
    Me.Panel2.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Panel2 As System.Windows.Forms.Panel
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
  Friend WithEvents btnTemplateAddSel As System.Windows.Forms.Button
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents lvTemplates As System.Windows.Forms.ListView
  Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
End Class
