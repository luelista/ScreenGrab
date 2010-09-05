<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_saveFile
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_saveFile))
    Me.Label1 = New System.Windows.Forms.Label
    Me.TextBox1 = New System.Windows.Forms.TextBox
    Me.opt_Temp_overwrite = New System.Windows.Forms.RadioButton
    Me.opt_temp_timestamp = New System.Windows.Forms.RadioButton
    Me.opt_perma = New System.Windows.Forms.RadioButton
    Me.btnUpload = New System.Windows.Forms.Button
    Me.check_clipboardURL = New System.Windows.Forms.CheckBox
    Me.check_skype = New System.Windows.Forms.CheckBox
    Me.cmb_SkypeChats = New System.Windows.Forms.ComboBox
    Me.btnSaveAs = New System.Windows.Forms.Button
    Me.lstFilelist = New System.Windows.Forms.ListBox
    Me.Label2 = New System.Windows.Forms.Label
    Me.checkOverwriteFile = New System.Windows.Forms.CheckBox
    Me.btnCancel = New System.Windows.Forms.Button
    Me.GroupBox1 = New System.Windows.Forms.GroupBox
    Me.GroupBox2 = New System.Windows.Forms.GroupBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.Label5 = New System.Windows.Forms.Label
    Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
    Me.labNamePrefix = New System.Windows.Forms.Label
    Me.PictureBox2 = New System.Windows.Forms.PictureBox
    Me.btnClip = New System.Windows.Forms.Button
    Me.txtURL = New System.Windows.Forms.TextBox
    Me.PictureBox1 = New System.Windows.Forms.PictureBox
    Me.bgw_ftpUpload = New System.ComponentModel.BackgroundWorker
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.TableLayoutPanel1.SuspendLayout()
    CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(13, 31)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(61, 13)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Dateiname:"
    '
    'TextBox1
    '
    Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TextBox1.Location = New System.Drawing.Point(36, 3)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(290, 20)
    Me.TextBox1.TabIndex = 1
    '
    'opt_Temp_overwrite
    '
    Me.opt_Temp_overwrite.AutoSize = True
    Me.opt_Temp_overwrite.Location = New System.Drawing.Point(12, 16)
    Me.opt_Temp_overwrite.Name = "opt_Temp_overwrite"
    Me.opt_Temp_overwrite.Size = New System.Drawing.Size(231, 17)
    Me.opt_Temp_overwrite.TabIndex = 2
    Me.opt_Temp_overwrite.TabStop = True
    Me.opt_Temp_overwrite.Text = "Temporär: mit nächster Datei überschreiben"
    Me.opt_Temp_overwrite.UseVisualStyleBackColor = True
    '
    'opt_temp_timestamp
    '
    Me.opt_temp_timestamp.AutoSize = True
    Me.opt_temp_timestamp.Location = New System.Drawing.Point(12, 39)
    Me.opt_temp_timestamp.Name = "opt_temp_timestamp"
    Me.opt_temp_timestamp.Size = New System.Drawing.Size(333, 17)
    Me.opt_temp_timestamp.TabIndex = 3
    Me.opt_temp_timestamp.TabStop = True
    Me.opt_temp_timestamp.Text = "Temporär: Zeitstempel / Name -- wird nach 1-2 Monaten gelöscht"
    Me.opt_temp_timestamp.UseVisualStyleBackColor = True
    '
    'opt_perma
    '
    Me.opt_perma.AutoSize = True
    Me.opt_perma.Location = New System.Drawing.Point(12, 62)
    Me.opt_perma.Name = "opt_perma"
    Me.opt_perma.Size = New System.Drawing.Size(219, 17)
    Me.opt_perma.TabIndex = 4
    Me.opt_perma.TabStop = True
    Me.opt_perma.Text = "permanent speichern im User-Verzeichnis"
    Me.opt_perma.UseVisualStyleBackColor = True
    '
    'btnUpload
    '
    Me.btnUpload.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnUpload.Image = CType(resources.GetObject("btnUpload.Image"), System.Drawing.Image)
    Me.btnUpload.Location = New System.Drawing.Point(18, 82)
    Me.btnUpload.Name = "btnUpload"
    Me.btnUpload.Size = New System.Drawing.Size(145, 28)
    Me.btnUpload.TabIndex = 5
    Me.btnUpload.Text = "  --  O K  --"
    Me.btnUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.btnUpload.UseVisualStyleBackColor = True
    '
    'check_clipboardURL
    '
    Me.check_clipboardURL.AutoSize = True
    Me.check_clipboardURL.Checked = True
    Me.check_clipboardURL.CheckState = System.Windows.Forms.CheckState.Checked
    Me.check_clipboardURL.Location = New System.Drawing.Point(11, 17)
    Me.check_clipboardURL.Name = "check_clipboardURL"
    Me.check_clipboardURL.Size = New System.Drawing.Size(130, 17)
    Me.check_clipboardURL.TabIndex = 6
    Me.check_clipboardURL.Text = "Link ins Clipboard (F6)"
    Me.check_clipboardURL.UseVisualStyleBackColor = True
    '
    'check_skype
    '
    Me.check_skype.AutoSize = True
    Me.check_skype.Location = New System.Drawing.Point(144, 17)
    Me.check_skype.Name = "check_skype"
    Me.check_skype.Size = New System.Drawing.Size(196, 17)
    Me.check_skype.TabIndex = 7
    Me.check_skype.Text = "im aktuellen Skype-Chat posten (F7)"
    Me.check_skype.UseVisualStyleBackColor = True
    '
    'cmb_SkypeChats
    '
    Me.cmb_SkypeChats.DropDownHeight = 220
    Me.cmb_SkypeChats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cmb_SkypeChats.DropDownWidth = 330
    Me.cmb_SkypeChats.FormattingEnabled = True
    Me.cmb_SkypeChats.IntegralHeight = False
    Me.cmb_SkypeChats.Location = New System.Drawing.Point(99, 38)
    Me.cmb_SkypeChats.Name = "cmb_SkypeChats"
    Me.cmb_SkypeChats.Size = New System.Drawing.Size(238, 21)
    Me.cmb_SkypeChats.TabIndex = 8
    '
    'btnSaveAs
    '
    Me.btnSaveAs.Location = New System.Drawing.Point(18, 339)
    Me.btnSaveAs.Name = "btnSaveAs"
    Me.btnSaveAs.Size = New System.Drawing.Size(158, 25)
    Me.btnSaveAs.TabIndex = 9
    Me.btnSaveAs.Text = "Lokal speichern unter ... (F2)"
    Me.btnSaveAs.UseVisualStyleBackColor = True
    '
    'lstFilelist
    '
    Me.lstFilelist.FormattingEnabled = True
    Me.lstFilelist.Location = New System.Drawing.Point(387, 126)
    Me.lstFilelist.Name = "lstFilelist"
    Me.lstFilelist.Size = New System.Drawing.Size(206, 238)
    Me.lstFilelist.TabIndex = 10
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(384, 111)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(53, 13)
    Me.Label2.TabIndex = 11
    Me.Label2.Text = "Dateiliste:"
    '
    'checkOverwriteFile
    '
    Me.checkOverwriteFile.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(66, Byte), Integer))
    Me.checkOverwriteFile.Location = New System.Drawing.Point(147, 30)
    Me.checkOverwriteFile.Name = "checkOverwriteFile"
    Me.checkOverwriteFile.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
    Me.checkOverwriteFile.Size = New System.Drawing.Size(191, 16)
    Me.checkOverwriteFile.TabIndex = 12
    Me.checkOverwriteFile.Text = "Datei wirklich überschreiben? (F9)"
    Me.checkOverwriteFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.checkOverwriteFile.UseVisualStyleBackColor = False
    Me.checkOverwriteFile.Visible = False
    '
    'btnCancel
    '
    Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.btnCancel.Location = New System.Drawing.Point(280, 339)
    Me.btnCancel.Name = "btnCancel"
    Me.btnCancel.Size = New System.Drawing.Size(95, 25)
    Me.btnCancel.TabIndex = 13
    Me.btnCancel.Text = "Abbrechen"
    Me.btnCancel.UseVisualStyleBackColor = True
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.opt_perma)
    Me.GroupBox1.Controls.Add(Me.opt_temp_timestamp)
    Me.GroupBox1.Controls.Add(Me.opt_Temp_overwrite)
    Me.GroupBox1.Location = New System.Drawing.Point(18, 125)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(354, 88)
    Me.GroupBox1.TabIndex = 14
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Ziel (F1)"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.cmb_SkypeChats)
    Me.GroupBox2.Controls.Add(Me.check_skype)
    Me.GroupBox2.Controls.Add(Me.check_clipboardURL)
    Me.GroupBox2.Location = New System.Drawing.Point(18, 227)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(354, 70)
    Me.GroupBox2.TabIndex = 15
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Danach"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(15, 311)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(62, 13)
    Me.Label3.TabIndex = 16
    Me.Label3.Text = "Dateigröße:"
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(345, 56)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(28, 13)
    Me.Label5.TabIndex = 19
    Me.Label5.Text = ".png"
    '
    'TableLayoutPanel1
    '
    Me.TableLayoutPanel1.ColumnCount = 2
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
    Me.TableLayoutPanel1.Controls.Add(Me.labNamePrefix, 0, 0)
    Me.TableLayoutPanel1.Controls.Add(Me.TextBox1, 1, 0)
    Me.TableLayoutPanel1.Location = New System.Drawing.Point(17, 50)
    Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    Me.TableLayoutPanel1.RowCount = 1
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanel1.Size = New System.Drawing.Size(329, 26)
    Me.TableLayoutPanel1.TabIndex = 20
    '
    'labNamePrefix
    '
    Me.labNamePrefix.AutoSize = True
    Me.labNamePrefix.Location = New System.Drawing.Point(3, 0)
    Me.labNamePrefix.Name = "labNamePrefix"
    Me.labNamePrefix.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
    Me.labNamePrefix.Size = New System.Drawing.Size(27, 18)
    Me.labNamePrefix.TabIndex = 0
    Me.labNamePrefix.Text = "xyz/"
    '
    'PictureBox2
    '
    Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
    Me.PictureBox2.Location = New System.Drawing.Point(387, 8)
    Me.PictureBox2.Name = "PictureBox2"
    Me.PictureBox2.Size = New System.Drawing.Size(206, 96)
    Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.PictureBox2.TabIndex = 22
    Me.PictureBox2.TabStop = False
    '
    'btnClip
    '
    Me.btnClip.Location = New System.Drawing.Point(177, 339)
    Me.btnClip.Name = "btnClip"
    Me.btnClip.Size = New System.Drawing.Size(102, 25)
    Me.btnClip.TabIndex = 23
    Me.btnClip.Text = "Bild kopieren (F3)"
    Me.btnClip.UseVisualStyleBackColor = True
    '
    'txtURL
    '
    Me.txtURL.Location = New System.Drawing.Point(17, 5)
    Me.txtURL.Name = "txtURL"
    Me.txtURL.ReadOnly = True
    Me.txtURL.Size = New System.Drawing.Size(357, 20)
    Me.txtURL.TabIndex = 24
    '
    'PictureBox1
    '
    Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(74, Byte), Integer))
    Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
    Me.PictureBox1.Location = New System.Drawing.Point(218, 125)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(211, 134)
    Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
    Me.PictureBox1.TabIndex = 25
    Me.PictureBox1.TabStop = False
    Me.PictureBox1.Visible = False
    '
    'frm_saveFile
    '
    Me.AcceptButton = Me.btnUpload
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.CancelButton = Me.btnCancel
    Me.ClientSize = New System.Drawing.Size(605, 376)
    Me.Controls.Add(Me.PictureBox1)
    Me.Controls.Add(Me.txtURL)
    Me.Controls.Add(Me.btnClip)
    Me.Controls.Add(Me.PictureBox2)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.btnCancel)
    Me.Controls.Add(Me.checkOverwriteFile)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.lstFilelist)
    Me.Controls.Add(Me.btnSaveAs)
    Me.Controls.Add(Me.btnUpload)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TableLayoutPanel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frm_saveFile"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Datei hochladen / speichern"
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.TableLayoutPanel1.ResumeLayout(False)
    Me.TableLayoutPanel1.PerformLayout()
    CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents opt_Temp_overwrite As System.Windows.Forms.RadioButton
  Friend WithEvents opt_temp_timestamp As System.Windows.Forms.RadioButton
  Friend WithEvents opt_perma As System.Windows.Forms.RadioButton
  Friend WithEvents btnUpload As System.Windows.Forms.Button
  Friend WithEvents check_clipboardURL As System.Windows.Forms.CheckBox
  Friend WithEvents check_skype As System.Windows.Forms.CheckBox
  Friend WithEvents cmb_SkypeChats As System.Windows.Forms.ComboBox
  Friend WithEvents btnSaveAs As System.Windows.Forms.Button
  Friend WithEvents lstFilelist As System.Windows.Forms.ListBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents checkOverwriteFile As System.Windows.Forms.CheckBox
  Friend WithEvents btnCancel As System.Windows.Forms.Button
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents labNamePrefix As System.Windows.Forms.Label
  Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
  Friend WithEvents btnClip As System.Windows.Forms.Button
  Friend WithEvents txtURL As System.Windows.Forms.TextBox
  Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
  Friend WithEvents bgw_ftpUpload As System.ComponentModel.BackgroundWorker
End Class
