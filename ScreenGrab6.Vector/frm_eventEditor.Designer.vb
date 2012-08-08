<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_eventEditor
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_eventEditor))
    Me.TextBox1 = New System.Windows.Forms.TextBox
    Me.FontDialog1 = New System.Windows.Forms.FontDialog
    Me.ListBox1 = New System.Windows.Forms.ListBox
    Me.Button1 = New System.Windows.Forms.Button
    Me.SuspendLayout()
    '
    'TextBox1
    '
    Me.TextBox1.AcceptsReturn = True
    Me.TextBox1.AcceptsTab = True
    Me.TextBox1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox1.Location = New System.Drawing.Point(143, 12)
    Me.TextBox1.Multiline = True
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.TextBox1.Size = New System.Drawing.Size(395, 289)
    Me.TextBox1.TabIndex = 1
    '
    'FontDialog1
    '
    Me.FontDialog1.ShowApply = True
    '
    'ListBox1
    '
    Me.ListBox1.FormattingEnabled = True
    Me.ListBox1.Items.AddRange(New Object() {"onclick", "onmousedown", "onmouseup", "onmouseenter", "onmouseout"})
    Me.ListBox1.Location = New System.Drawing.Point(10, 11)
    Me.ListBox1.Name = "ListBox1"
    Me.ListBox1.Size = New System.Drawing.Size(127, 290)
    Me.ListBox1.TabIndex = 2
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(332, 316)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(206, 23)
    Me.Button1.TabIndex = 3
    Me.Button1.Text = "Speichern"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'frm_eventEditor
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(548, 356)
    Me.Controls.Add(Me.Button1)
    Me.Controls.Add(Me.ListBox1)
    Me.Controls.Add(Me.TextBox1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frm_eventEditor"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Text bearbeiten ..."
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
  Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
  Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
