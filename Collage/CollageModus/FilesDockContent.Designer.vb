<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FilesDockContent
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FilesDockContent))
    Me.btnNav04 = New System.Windows.Forms.Button()
    Me.btnNav01 = New System.Windows.Forms.Button()
    Me.btnNav03 = New System.Windows.Forms.Button()
    Me.btnNav02 = New System.Windows.Forms.Button()
    Me.ListView1 = New System.Windows.Forms.ListView()
    Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.imlLarge = New System.Windows.Forms.ImageList(Me.components)
    Me.imlSmall = New System.Windows.Forms.ImageList(Me.components)
    Me.chkThumbs = New System.Windows.Forms.CheckBox()
    Me.cmbPath = New System.Windows.Forms.ComboBox()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.Button1 = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'btnNav04
    '
    Me.btnNav04.Location = New System.Drawing.Point(222, 1)
    Me.btnNav04.Name = "btnNav04"
    Me.btnNav04.Size = New System.Drawing.Size(57, 23)
    Me.btnNav04.TabIndex = 17
    Me.btnNav04.UseVisualStyleBackColor = True
    '
    'btnNav01
    '
    Me.btnNav01.Location = New System.Drawing.Point(54, 1)
    Me.btnNav01.Name = "btnNav01"
    Me.btnNav01.Size = New System.Drawing.Size(57, 23)
    Me.btnNav01.TabIndex = 12
    Me.btnNav01.UseVisualStyleBackColor = True
    '
    'btnNav03
    '
    Me.btnNav03.Location = New System.Drawing.Point(166, 1)
    Me.btnNav03.Name = "btnNav03"
    Me.btnNav03.Size = New System.Drawing.Size(57, 23)
    Me.btnNav03.TabIndex = 14
    Me.btnNav03.UseVisualStyleBackColor = True
    '
    'btnNav02
    '
    Me.btnNav02.Location = New System.Drawing.Point(110, 1)
    Me.btnNav02.Name = "btnNav02"
    Me.btnNav02.Size = New System.Drawing.Size(57, 23)
    Me.btnNav02.TabIndex = 13
    Me.btnNav02.UseVisualStyleBackColor = True
    '
    'ListView1
    '
    Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
    Me.ListView1.LargeImageList = Me.imlLarge
    Me.ListView1.Location = New System.Drawing.Point(1, 53)
    Me.ListView1.Name = "ListView1"
    Me.ListView1.Size = New System.Drawing.Size(277, 531)
    Me.ListView1.SmallImageList = Me.imlSmall
    Me.ListView1.TabIndex = 18
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
    'imlLarge
    '
    Me.imlLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
    Me.imlLarge.ImageSize = New System.Drawing.Size(150, 115)
    Me.imlLarge.TransparentColor = System.Drawing.Color.Transparent
    '
    'imlSmall
    '
    Me.imlSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
    Me.imlSmall.ImageSize = New System.Drawing.Size(16, 16)
    Me.imlSmall.TransparentColor = System.Drawing.Color.Transparent
    '
    'chkThumbs
    '
    Me.chkThumbs.Appearance = System.Windows.Forms.Appearance.Button
    Me.chkThumbs.ImageKey = "ThumbnailView.bmp"
    Me.chkThumbs.ImageList = Me.ImageList1
    Me.chkThumbs.Location = New System.Drawing.Point(27, 1)
    Me.chkThumbs.Name = "chkThumbs"
    Me.chkThumbs.Size = New System.Drawing.Size(28, 23)
    Me.chkThumbs.TabIndex = 19
    Me.chkThumbs.UseVisualStyleBackColor = True
    '
    'cmbPath
    '
    Me.cmbPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmbPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
    Me.cmbPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories
    Me.cmbPath.FormattingEnabled = True
    Me.cmbPath.Location = New System.Drawing.Point(1, 26)
    Me.cmbPath.Name = "cmbPath"
    Me.cmbPath.Size = New System.Drawing.Size(277, 21)
    Me.cmbPath.TabIndex = 20
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Magenta
    Me.ImageList1.Images.SetKeyName(0, "ThumbnailView.bmp")
    Me.ImageList1.Images.SetKeyName(1, "GoToParentFolder.bmp")
    '
    'Button1
    '
    Me.Button1.ImageKey = "GoToParentFolder.bmp"
    Me.Button1.ImageList = Me.ImageList1
    Me.Button1.Location = New System.Drawing.Point(0, 1)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(28, 23)
    Me.Button1.TabIndex = 21
    Me.Button1.UseVisualStyleBackColor = True
    '
    'FilesDockContent
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(279, 584)
    Me.Controls.Add(Me.Button1)
    Me.Controls.Add(Me.cmbPath)
    Me.Controls.Add(Me.chkThumbs)
    Me.Controls.Add(Me.ListView1)
    Me.Controls.Add(Me.btnNav04)
    Me.Controls.Add(Me.btnNav01)
    Me.Controls.Add(Me.btnNav03)
    Me.Controls.Add(Me.btnNav02)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.HideOnClose = True
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.Name = "FilesDockContent"
    Me.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft
    Me.Text = "Dateien"
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents btnNav04 As System.Windows.Forms.Button
    Friend WithEvents btnNav01 As System.Windows.Forms.Button
  Friend WithEvents btnNav03 As System.Windows.Forms.Button
  Friend WithEvents btnNav02 As System.Windows.Forms.Button
  Friend WithEvents ListView1 As ListView
  Friend WithEvents ColumnHeader1 As ColumnHeader
  Friend WithEvents ColumnHeader2 As ColumnHeader
  Friend WithEvents ColumnHeader3 As ColumnHeader
  Friend WithEvents imlLarge As ImageList
  Friend WithEvents imlSmall As ImageList
  Friend WithEvents chkThumbs As CheckBox
  Friend WithEvents cmbPath As ComboBox
  Friend WithEvents ImageList1 As ImageList
  Friend WithEvents Button1 As Button
End Class
