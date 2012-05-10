<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_teamwikiSaveFileDialog
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
    Me.Label1 = New System.Windows.Forms.Label
    Me.cmbFilename = New System.Windows.Forms.ComboBox
    Me.btnOK = New System.Windows.Forms.Button
    Me.btnCancel = New System.Windows.Forms.Button
    Me.lblDesc = New System.Windows.Forms.Label
    Me.twftv = New ScreenGrab5.TeamWikiFileStoreFTV
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(17, 334)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(61, 13)
    Me.Label1.TabIndex = 1
    Me.Label1.Text = "Dateiname:"
    '
    'cmbFilename
    '
    Me.cmbFilename.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmbFilename.FormattingEnabled = True
    Me.cmbFilename.Location = New System.Drawing.Point(84, 331)
    Me.cmbFilename.Name = "cmbFilename"
    Me.cmbFilename.Size = New System.Drawing.Size(247, 21)
    Me.cmbFilename.TabIndex = 2
    '
    'btnOK
    '
    Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnOK.Location = New System.Drawing.Point(120, 370)
    Me.btnOK.Name = "btnOK"
    Me.btnOK.Size = New System.Drawing.Size(108, 25)
    Me.btnOK.TabIndex = 3
    Me.btnOK.Text = "OK"
    Me.btnOK.UseVisualStyleBackColor = True
    '
    'btnCancel
    '
    Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.btnCancel.Location = New System.Drawing.Point(234, 370)
    Me.btnCancel.Name = "btnCancel"
    Me.btnCancel.Size = New System.Drawing.Size(108, 25)
    Me.btnCancel.TabIndex = 4
    Me.btnCancel.Text = "Abbrechen"
    Me.btnCancel.UseVisualStyleBackColor = True
    '
    'lblDesc
    '
    Me.lblDesc.Location = New System.Drawing.Point(20, 9)
    Me.lblDesc.Name = "lblDesc"
    Me.lblDesc.Size = New System.Drawing.Size(322, 44)
    Me.lblDesc.TabIndex = 5
    Me.lblDesc.Text = "Wähle einen Ordner aus, und gib den Dateinamen an, unter dem die Datei gespeicher" & _
        "t werden soll ..."
    '
    'twftv
    '
    Me.twftv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.twftv.DataSourceURL = "http://teamwiki.net/php/vb/grab5.php?c=get_full_tree"
    Me.twftv.ImageIndex = 0
    Me.twftv.Location = New System.Drawing.Point(14, 56)
    Me.twftv.Name = "twftv"
    Me.twftv.PathSeparator = "/"
    Me.twftv.SelectedImageIndex = 0
    Me.twftv.Size = New System.Drawing.Size(328, 264)
    Me.twftv.TabIndex = 0
    Me.twftv.TeamWikiSessionID = Nothing
    '
    'frm_teamwikiSaveFileDialog
    '
    Me.AcceptButton = Me.btnOK
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.CancelButton = Me.btnCancel
    Me.ClientSize = New System.Drawing.Size(354, 406)
    Me.Controls.Add(Me.lblDesc)
    Me.Controls.Add(Me.btnCancel)
    Me.Controls.Add(Me.btnOK)
    Me.Controls.Add(Me.cmbFilename)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.twftv)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frm_teamwikiSaveFileDialog"
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Datei speichern unter ..."
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents twftv As ScreenGrab5.TeamWikiFileStoreFTV
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents cmbFilename As System.Windows.Forms.ComboBox
  Friend WithEvents btnOK As System.Windows.Forms.Button
  Friend WithEvents btnCancel As System.Windows.Forms.Button
  Friend WithEvents lblDesc As System.Windows.Forms.Label
End Class
