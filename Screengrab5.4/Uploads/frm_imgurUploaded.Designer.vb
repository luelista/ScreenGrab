<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_imgurUploaded
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
    Me.PictureBox1 = New System.Windows.Forms.PictureBox
    Me.ListView1 = New System.Windows.Forms.ListView
    Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
    Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
    Me.Label1 = New System.Windows.Forms.Label
    Me.lstAlbums = New System.Windows.Forms.CheckedListBox
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'PictureBox1
    '
    Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
    Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(90, 90)
    Me.PictureBox1.TabIndex = 0
    Me.PictureBox1.TabStop = False
    '
    'ListView1
    '
    Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
    Me.ListView1.FullRowSelect = True
    Me.ListView1.HideSelection = False
    Me.ListView1.Location = New System.Drawing.Point(12, 108)
    Me.ListView1.Name = "ListView1"
    Me.ListView1.Size = New System.Drawing.Size(390, 148)
    Me.ListView1.TabIndex = 1
    Me.ListView1.UseCompatibleStateImageBehavior = False
    Me.ListView1.View = System.Windows.Forms.View.Details
    '
    'ColumnHeader1
    '
    Me.ColumnHeader1.Text = "Beschreibung"
    Me.ColumnHeader1.Width = 81
    '
    'ColumnHeader2
    '
    Me.ColumnHeader2.Text = "URL (Doppelklick zum kopieren)"
    Me.ColumnHeader2.Width = 285
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(108, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(110, 13)
    Me.Label1.TabIndex = 2
    Me.Label1.Text = "Zu Album hinzufügen:"
    '
    'lstAlbums
    '
    Me.lstAlbums.FormattingEnabled = True
    Me.lstAlbums.IntegralHeight = False
    Me.lstAlbums.Location = New System.Drawing.Point(111, 32)
    Me.lstAlbums.Name = "lstAlbums"
    Me.lstAlbums.Size = New System.Drawing.Size(290, 70)
    Me.lstAlbums.TabIndex = 3
    '
    'frm_imgurUploaded
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(417, 267)
    Me.Controls.Add(Me.lstAlbums)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.ListView1)
    Me.Controls.Add(Me.PictureBox1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.Name = "frm_imgurUploaded"
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
  Friend WithEvents ListView1 As System.Windows.Forms.ListView
  Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents lstAlbums As System.Windows.Forms.CheckedListBox
End Class
