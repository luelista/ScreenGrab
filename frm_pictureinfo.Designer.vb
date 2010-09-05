<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_pictureinfo
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_pictureinfo))
    Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
    Me.tsbGetfilesize = New System.Windows.Forms.ToolStripButton
    Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
    Me.ListView1 = New System.Windows.Forms.ListView
    Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
    Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
    Me.ToolStrip1.SuspendLayout()
    Me.SuspendLayout()
    '
    'ToolStrip1
    '
    Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbGetfilesize, Me.ToolStripButton1})
    Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
    Me.ToolStrip1.Name = "ToolStrip1"
    Me.ToolStrip1.Size = New System.Drawing.Size(288, 25)
    Me.ToolStrip1.TabIndex = 22
    Me.ToolStrip1.Text = "ToolStrip1"
    '
    'tsbGetfilesize
    '
    Me.tsbGetfilesize.Image = CType(resources.GetObject("tsbGetfilesize.Image"), System.Drawing.Image)
    Me.tsbGetfilesize.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsbGetfilesize.Name = "tsbGetfilesize"
    Me.tsbGetfilesize.Size = New System.Drawing.Size(120, 22)
    Me.tsbGetfilesize.Text = "Bildinfo neuladen"
    '
    'ToolStripButton1
    '
    Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
    Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
    Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton1.Name = "ToolStripButton1"
    Me.ToolStripButton1.Size = New System.Drawing.Size(55, 22)
    Me.ToolStripButton1.Text = "OK    "
    '
    'ListView1
    '
    Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
    Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
    Me.ListView1.Location = New System.Drawing.Point(4, 26)
    Me.ListView1.Name = "ListView1"
    Me.ListView1.Size = New System.Drawing.Size(280, 95)
    Me.ListView1.TabIndex = 23
    Me.ListView1.UseCompatibleStateImageBehavior = False
    Me.ListView1.View = System.Windows.Forms.View.Details
    '
    'ColumnHeader1
    '
    Me.ColumnHeader1.Width = 101
    '
    'ColumnHeader2
    '
    Me.ColumnHeader2.Width = 175
    '
    'frm_pictureinfo
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(288, 124)
    Me.Controls.Add(Me.ListView1)
    Me.Controls.Add(Me.ToolStrip1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frm_pictureinfo"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
    Me.Text = "Bildinfo"
    Me.ToolStrip1.ResumeLayout(False)
    Me.ToolStrip1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
  Friend WithEvents tsbGetfilesize As System.Windows.Forms.ToolStripButton
  Friend WithEvents ListView1 As System.Windows.Forms.ListView
  Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
  Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
End Class
