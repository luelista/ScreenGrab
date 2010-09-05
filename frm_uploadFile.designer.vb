<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_uploadFile
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_uploadFile))
    Me.btnUpload = New System.Windows.Forms.Button
    Me.btnCancel = New System.Windows.Forms.Button
    Me.Label1 = New System.Windows.Forms.Label
    Me.cmbFolder = New System.Windows.Forms.ComboBox
    Me.lviFolderCont = New System.Windows.Forms.ListView
    Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
    Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
    Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.btnUp = New System.Windows.Forms.Button
    Me.Label2 = New System.Windows.Forms.Label
    Me.txtFilename = New System.Windows.Forms.TextBox
    Me.pnlMain = New System.Windows.Forms.Panel
    Me.btnNewFolder = New System.Windows.Forms.Button
    Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
    Me.lblPicFormat = New System.Windows.Forms.Label
    Me.cmbPicFormat = New System.Windows.Forms.ComboBox
    Me.pnlUploadLocalFile = New System.Windows.Forms.Panel
    Me.Label4 = New System.Windows.Forms.Label
    Me.PictureBox1 = New System.Windows.Forms.PictureBox
    Me.TextBox1 = New System.Windows.Forms.TextBox
    Me.pnlMain.SuspendLayout()
    Me.pnlUploadLocalFile.SuspendLayout()
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'btnUpload
    '
    Me.btnUpload.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnUpload.Enabled = False
    Me.btnUpload.Location = New System.Drawing.Point(386, 327)
    Me.btnUpload.Name = "btnUpload"
    Me.btnUpload.Size = New System.Drawing.Size(101, 23)
    Me.btnUpload.TabIndex = 0
    Me.btnUpload.Text = "Hochladen"
    Me.btnUpload.UseVisualStyleBackColor = True
    '
    'btnCancel
    '
    Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.btnCancel.Location = New System.Drawing.Point(386, 353)
    Me.btnCancel.Name = "btnCancel"
    Me.btnCancel.Size = New System.Drawing.Size(101, 23)
    Me.btnCancel.TabIndex = 1
    Me.btnCancel.Text = "Abbrechen"
    Me.btnCancel.UseVisualStyleBackColor = True
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(3, 11)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(42, 13)
    Me.Label1.TabIndex = 2
    Me.Label1.Text = "Ordner:"
    '
    'cmbFolder
    '
    Me.cmbFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmbFolder.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
    Me.cmbFolder.DropDownHeight = 400
    Me.cmbFolder.FormattingEnabled = True
    Me.cmbFolder.IntegralHeight = False
    Me.cmbFolder.ItemHeight = 17
    Me.cmbFolder.Location = New System.Drawing.Point(51, 6)
    Me.cmbFolder.Name = "cmbFolder"
    Me.cmbFolder.Size = New System.Drawing.Size(374, 23)
    Me.cmbFolder.TabIndex = 3
    '
    'lviFolderCont
    '
    Me.lviFolderCont.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lviFolderCont.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader4, Me.ColumnHeader3})
    Me.lviFolderCont.Location = New System.Drawing.Point(4, 37)
    Me.lviFolderCont.Name = "lviFolderCont"
    Me.lviFolderCont.Size = New System.Drawing.Size(483, 286)
    Me.lviFolderCont.SmallImageList = Me.ImageList1
    Me.lviFolderCont.TabIndex = 4
    Me.lviFolderCont.UseCompatibleStateImageBehavior = False
    Me.lviFolderCont.View = System.Windows.Forms.View.Details
    '
    'ColumnHeader2
    '
    Me.ColumnHeader2.Text = "Name"
    Me.ColumnHeader2.Width = 254
    '
    'ColumnHeader4
    '
    Me.ColumnHeader4.Text = "Größe"
    Me.ColumnHeader4.Width = 73
    '
    'ColumnHeader3
    '
    Me.ColumnHeader3.Text = "Letzte Änderung"
    Me.ColumnHeader3.Width = 109
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "SHELL32_4-16.png")
    Me.ImageList1.Images.SetKeyName(1, "rundll32_100.ico")
    '
    'btnUp
    '
    Me.btnUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnUp.Image = CType(resources.GetObject("btnUp.Image"), System.Drawing.Image)
    Me.btnUp.Location = New System.Drawing.Point(431, 6)
    Me.btnUp.Name = "btnUp"
    Me.btnUp.Size = New System.Drawing.Size(28, 23)
    Me.btnUp.TabIndex = 6
    Me.btnUp.UseVisualStyleBackColor = True
    '
    'Label2
    '
    Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(3, 331)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(61, 13)
    Me.Label2.TabIndex = 7
    Me.Label2.Text = "Dateiname:"
    '
    'txtFilename
    '
    Me.txtFilename.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtFilename.Location = New System.Drawing.Point(70, 328)
    Me.txtFilename.Name = "txtFilename"
    Me.txtFilename.Size = New System.Drawing.Size(310, 20)
    Me.txtFilename.TabIndex = 8
    '
    'pnlMain
    '
    Me.pnlMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.pnlMain.Controls.Add(Me.cmbPicFormat)
    Me.pnlMain.Controls.Add(Me.btnCancel)
    Me.pnlMain.Controls.Add(Me.lblPicFormat)
    Me.pnlMain.Controls.Add(Me.btnNewFolder)
    Me.pnlMain.Controls.Add(Me.txtFilename)
    Me.pnlMain.Controls.Add(Me.Label2)
    Me.pnlMain.Controls.Add(Me.btnUp)
    Me.pnlMain.Controls.Add(Me.btnUpload)
    Me.pnlMain.Controls.Add(Me.lviFolderCont)
    Me.pnlMain.Controls.Add(Me.cmbFolder)
    Me.pnlMain.Controls.Add(Me.Label1)
    Me.pnlMain.Enabled = False
    Me.pnlMain.Location = New System.Drawing.Point(7, 2)
    Me.pnlMain.Name = "pnlMain"
    Me.pnlMain.Size = New System.Drawing.Size(496, 380)
    Me.pnlMain.TabIndex = 10
    '
    'btnNewFolder
    '
    Me.btnNewFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnNewFolder.Image = CType(resources.GetObject("btnNewFolder.Image"), System.Drawing.Image)
    Me.btnNewFolder.Location = New System.Drawing.Point(459, 6)
    Me.btnNewFolder.Name = "btnNewFolder"
    Me.btnNewFolder.Size = New System.Drawing.Size(28, 23)
    Me.btnNewFolder.TabIndex = 10
    Me.btnNewFolder.UseVisualStyleBackColor = True
    '
    'ImageList2
    '
    Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList2.Images.SetKeyName(0, "SHELL32_4-16.png")
    Me.ImageList2.Images.SetKeyName(1, "iexplore_32536-16.png")
    Me.ImageList2.Images.SetKeyName(2, "shell32_269-16.png")
    '
    'lblPicFormat
    '
    Me.lblPicFormat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.lblPicFormat.AutoSize = True
    Me.lblPicFormat.Location = New System.Drawing.Point(8, 356)
    Me.lblPicFormat.Name = "lblPicFormat"
    Me.lblPicFormat.Size = New System.Drawing.Size(56, 13)
    Me.lblPicFormat.TabIndex = 11
    Me.lblPicFormat.Text = "Bildformat:"
    Me.lblPicFormat.Visible = False
    '
    'cmbPicFormat
    '
    Me.cmbPicFormat.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.cmbPicFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cmbPicFormat.FormattingEnabled = True
    Me.cmbPicFormat.Location = New System.Drawing.Point(70, 353)
    Me.cmbPicFormat.Name = "cmbPicFormat"
    Me.cmbPicFormat.Size = New System.Drawing.Size(261, 21)
    Me.cmbPicFormat.TabIndex = 12
    Me.cmbPicFormat.Visible = False
    '
    'pnlUploadLocalFile
    '
    Me.pnlUploadLocalFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.pnlUploadLocalFile.BackColor = System.Drawing.Color.Gainsboro
    Me.pnlUploadLocalFile.Controls.Add(Me.TextBox1)
    Me.pnlUploadLocalFile.Controls.Add(Me.PictureBox1)
    Me.pnlUploadLocalFile.Controls.Add(Me.Label4)
    Me.pnlUploadLocalFile.Location = New System.Drawing.Point(0, 0)
    Me.pnlUploadLocalFile.Name = "pnlUploadLocalFile"
    Me.pnlUploadLocalFile.Size = New System.Drawing.Size(510, 76)
    Me.pnlUploadLocalFile.TabIndex = 11
    Me.pnlUploadLocalFile.Visible = False
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(18, 10)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(173, 13)
    Me.Label4.TabIndex = 0
    Me.Label4.Text = "Hochladen der lokalen Datei:"
    '
    'PictureBox1
    '
    Me.PictureBox1.Location = New System.Drawing.Point(22, 31)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
    Me.PictureBox1.TabIndex = 1
    Me.PictureBox1.TabStop = False
    '
    'TextBox1
    '
    Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TextBox1.BackColor = System.Drawing.Color.Gainsboro
    Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.TextBox1.Location = New System.Drawing.Point(63, 32)
    Me.TextBox1.Multiline = True
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(416, 38)
    Me.TextBox1.TabIndex = 2
    '
    'frm_uploadFile
    '
    Me.AcceptButton = Me.btnUpload
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.CancelButton = Me.btnCancel
    Me.ClientSize = New System.Drawing.Size(510, 383)
    Me.Controls.Add(Me.pnlUploadLocalFile)
    Me.Controls.Add(Me.pnlMain)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frm_uploadFile"
    Me.Text = "Datei hochladen nach ..."
    Me.pnlMain.ResumeLayout(False)
    Me.pnlMain.PerformLayout()
    Me.pnlUploadLocalFile.ResumeLayout(False)
    Me.pnlUploadLocalFile.PerformLayout()
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents btnUpload As System.Windows.Forms.Button
  Friend WithEvents btnCancel As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents cmbFolder As System.Windows.Forms.ComboBox
  Friend WithEvents lviFolderCont As System.Windows.Forms.ListView
  Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
  Friend WithEvents btnUp As System.Windows.Forms.Button
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtFilename As System.Windows.Forms.TextBox
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents pnlMain As System.Windows.Forms.Panel
  Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
  Friend WithEvents btnNewFolder As System.Windows.Forms.Button
  Friend WithEvents cmbPicFormat As System.Windows.Forms.ComboBox
  Friend WithEvents lblPicFormat As System.Windows.Forms.Label
  Friend WithEvents pnlUploadLocalFile As System.Windows.Forms.Panel
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
