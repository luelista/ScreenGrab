<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_commonUpload
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_commonUpload))
    Me.cmbSelectUploadTarget = New System.Windows.Forms.ComboBox
    Me.pnlButtons = New System.Windows.Forms.Panel
    Me.pbProgress = New System.Windows.Forms.ProgressBar
    Me.btnCancel = New System.Windows.Forms.Button
    Me.btnUpload = New System.Windows.Forms.Button
    Me.pnlOptions = New System.Windows.Forms.Panel
    Me.pnlButtons.SuspendLayout()
    Me.SuspendLayout()
    '
    'cmbSelectUploadTarget
    '
    Me.cmbSelectUploadTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cmbSelectUploadTarget.FormattingEnabled = True
    Me.cmbSelectUploadTarget.Location = New System.Drawing.Point(23, 12)
    Me.cmbSelectUploadTarget.Name = "cmbSelectUploadTarget"
    Me.cmbSelectUploadTarget.Size = New System.Drawing.Size(506, 21)
    Me.cmbSelectUploadTarget.TabIndex = 0
    '
    'pnlButtons
    '
    Me.pnlButtons.Controls.Add(Me.pbProgress)
    Me.pnlButtons.Controls.Add(Me.btnCancel)
    Me.pnlButtons.Controls.Add(Me.btnUpload)
    Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom
    Me.pnlButtons.Location = New System.Drawing.Point(0, 156)
    Me.pnlButtons.Name = "pnlButtons"
    Me.pnlButtons.Size = New System.Drawing.Size(544, 48)
    Me.pnlButtons.TabIndex = 5
    '
    'pbProgress
    '
    Me.pbProgress.Location = New System.Drawing.Point(22, 12)
    Me.pbProgress.Name = "pbProgress"
    Me.pbProgress.Size = New System.Drawing.Size(256, 22)
    Me.pbProgress.TabIndex = 4
    Me.pbProgress.Visible = False
    '
    'btnCancel
    '
    Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.btnCancel.Location = New System.Drawing.Point(291, 12)
    Me.btnCancel.Name = "btnCancel"
    Me.btnCancel.Size = New System.Drawing.Size(95, 23)
    Me.btnCancel.TabIndex = 6
    Me.btnCancel.Text = "Abbrechen"
    Me.btnCancel.UseVisualStyleBackColor = True
    '
    'btnUpload
    '
    Me.btnUpload.Location = New System.Drawing.Point(392, 12)
    Me.btnUpload.Name = "btnUpload"
    Me.btnUpload.Size = New System.Drawing.Size(137, 23)
    Me.btnUpload.TabIndex = 5
    Me.btnUpload.Text = "Speichern"
    Me.btnUpload.UseVisualStyleBackColor = True
    '
    'pnlOptions
    '
    Me.pnlOptions.Location = New System.Drawing.Point(0, 40)
    Me.pnlOptions.Name = "pnlOptions"
    Me.pnlOptions.Size = New System.Drawing.Size(544, 48)
    Me.pnlOptions.TabIndex = 6
    '
    'frm_commonUpload
    '
    Me.AcceptButton = Me.btnUpload
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.CancelButton = Me.btnCancel
    Me.ClientSize = New System.Drawing.Size(544, 204)
    Me.Controls.Add(Me.pnlOptions)
    Me.Controls.Add(Me.pnlButtons)
    Me.Controls.Add(Me.cmbSelectUploadTarget)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frm_commonUpload"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Datei im Web speichern ..."
    Me.pnlButtons.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents cmbSelectUploadTarget As System.Windows.Forms.ComboBox
  Friend WithEvents pnlButtons As System.Windows.Forms.Panel
  Friend WithEvents pbProgress As System.Windows.Forms.ProgressBar
  Friend WithEvents btnCancel As System.Windows.Forms.Button
  Friend WithEvents btnUpload As System.Windows.Forms.Button
  Friend WithEvents pnlOptions As System.Windows.Forms.Panel
End Class
