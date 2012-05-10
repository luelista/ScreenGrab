<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_softwareUpdate
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_softwareUpdate))
    Me.Label1 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
    Me.btnStartInstaller = New System.Windows.Forms.Button
    Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
    Me.Label3 = New System.Windows.Forms.Label
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(12, 18)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(344, 25)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "ScreenGrab X.X ist jetzt verfügbar!"
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(15, 47)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(345, 81)
    Me.Label2.TabIndex = 1
    Me.Label2.Text = "Die neueste Version wird gerade heruntergeladen, bitte hab" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "einen Moment Geduld ." & _
        ".."
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'ProgressBar1
    '
    Me.ProgressBar1.Location = New System.Drawing.Point(17, 133)
    Me.ProgressBar1.Name = "ProgressBar1"
    Me.ProgressBar1.Size = New System.Drawing.Size(339, 23)
    Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
    Me.ProgressBar1.TabIndex = 2
    '
    'btnStartInstaller
    '
    Me.btnStartInstaller.Location = New System.Drawing.Point(242, 133)
    Me.btnStartInstaller.Name = "btnStartInstaller"
    Me.btnStartInstaller.Size = New System.Drawing.Size(114, 23)
    Me.btnStartInstaller.TabIndex = 3
    Me.btnStartInstaller.Text = "Weiter"
    Me.btnStartInstaller.UseVisualStyleBackColor = True
    Me.btnStartInstaller.Visible = False
    '
    'BackgroundWorker1
    '
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(15, 138)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(212, 13)
    Me.Label3.TabIndex = 4
    Me.Label3.Text = "Klicke Weiter, um das Update auszuführen."
    '
    'frm_softwareUpdate
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(374, 181)
    Me.Controls.Add(Me.btnStartInstaller)
    Me.Controls.Add(Me.ProgressBar1)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.Label3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frm_softwareUpdate"
    Me.Text = "Neue Version verfügbar - ScreenGrab"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
  Friend WithEvents btnStartInstaller As System.Windows.Forms.Button
  Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
  Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
