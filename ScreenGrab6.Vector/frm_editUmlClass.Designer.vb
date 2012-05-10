<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_editUmlClass
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_editUmlClass))
    Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
    Me.OK_Button = New System.Windows.Forms.Button
    Me.Cancel_Button = New System.Windows.Forms.Button
    Me.PictureBox1 = New System.Windows.Forms.PictureBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.TextBox1 = New System.Windows.Forms.TextBox
    Me.rbPrivate = New System.Windows.Forms.RadioButton
    Me.rbProtected = New System.Windows.Forms.RadioButton
    Me.rbPublic = New System.Windows.Forms.RadioButton
    Me.Label2 = New System.Windows.Forms.Label
    Me.ListView1 = New System.Windows.Forms.ListView
    Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
    Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
    Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
    Me.ListView2 = New System.Windows.Forms.ListView
    Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
    Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
    Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
    Me.Label3 = New System.Windows.Forms.Label
    Me.btnAA = New System.Windows.Forms.Button
    Me.btnAR = New System.Windows.Forms.Button
    Me.btnAU = New System.Windows.Forms.Button
    Me.btnAD = New System.Windows.Forms.Button
    Me.btnMD = New System.Windows.Forms.Button
    Me.btnMU = New System.Windows.Forms.Button
    Me.btnMR = New System.Windows.Forms.Button
    Me.btnMA = New System.Windows.Forms.Button
    Me.TextBox2 = New System.Windows.Forms.TextBox
    Me.Label4 = New System.Windows.Forms.Label
    Me.btnPA = New System.Windows.Forms.Button
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.TableLayoutPanel1.SuspendLayout()
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TableLayoutPanel1
    '
    Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TableLayoutPanel1.ColumnCount = 2
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
    Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
    Me.TableLayoutPanel1.Location = New System.Drawing.Point(257, 458)
    Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    Me.TableLayoutPanel1.RowCount = 1
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.Size = New System.Drawing.Size(175, 29)
    Me.TableLayoutPanel1.TabIndex = 17
    '
    'OK_Button
    '
    Me.OK_Button.Dock = System.Windows.Forms.DockStyle.Fill
    Me.OK_Button.Location = New System.Drawing.Point(3, 3)
    Me.OK_Button.Name = "OK_Button"
    Me.OK_Button.Size = New System.Drawing.Size(81, 23)
    Me.OK_Button.TabIndex = 0
    Me.OK_Button.Text = "&OK"
    '
    'Cancel_Button
    '
    Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Cancel_Button.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Cancel_Button.Location = New System.Drawing.Point(90, 3)
    Me.Cancel_Button.Name = "Cancel_Button"
    Me.Cancel_Button.Size = New System.Drawing.Size(82, 23)
    Me.Cancel_Button.TabIndex = 1
    Me.Cancel_Button.Text = "Abbrechen"
    '
    'PictureBox1
    '
    Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
    Me.PictureBox1.Location = New System.Drawing.Point(23, 19)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
    Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
    Me.PictureBox1.TabIndex = 1
    Me.PictureBox1.TabStop = False
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(98, 22)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(73, 13)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Klassenname:"
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(189, 19)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(238, 20)
    Me.TextBox1.TabIndex = 1
    '
    'rbPrivate
    '
    Me.rbPrivate.AutoSize = True
    Me.rbPrivate.Location = New System.Drawing.Point(291, 73)
    Me.rbPrivate.Name = "rbPrivate"
    Me.rbPrivate.Size = New System.Drawing.Size(69, 17)
    Me.rbPrivate.TabIndex = 6
    Me.rbPrivate.TabStop = True
    Me.rbPrivate.Text = "&2: private"
    Me.rbPrivate.UseVisualStyleBackColor = True
    '
    'rbProtected
    '
    Me.rbProtected.AutoSize = True
    Me.rbProtected.Location = New System.Drawing.Point(189, 73)
    Me.rbProtected.Name = "rbProtected"
    Me.rbProtected.Size = New System.Drawing.Size(82, 17)
    Me.rbProtected.TabIndex = 5
    Me.rbProtected.TabStop = True
    Me.rbProtected.Text = "&1: protected"
    Me.rbProtected.UseVisualStyleBackColor = True
    '
    'rbPublic
    '
    Me.rbPublic.AutoSize = True
    Me.rbPublic.Location = New System.Drawing.Point(101, 73)
    Me.rbPublic.Name = "rbPublic"
    Me.rbPublic.Size = New System.Drawing.Size(65, 17)
    Me.rbPublic.TabIndex = 4
    Me.rbPublic.TabStop = True
    Me.rbPublic.Text = "&0: public"
    Me.rbPublic.UseVisualStyleBackColor = True
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(23, 100)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(49, 13)
    Me.Label2.TabIndex = 7
    Me.Label2.Text = "Attribute:"
    '
    'ListView1
    '
    Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
    Me.ListView1.Location = New System.Drawing.Point(23, 121)
    Me.ListView1.MultiSelect = False
    Me.ListView1.Name = "ListView1"
    Me.ListView1.Size = New System.Drawing.Size(369, 128)
    Me.ListView1.TabIndex = 8
    Me.ListView1.UseCompatibleStateImageBehavior = False
    Me.ListView1.View = System.Windows.Forms.View.Details
    '
    'ColumnHeader1
    '
    Me.ColumnHeader1.Text = "Name"
    Me.ColumnHeader1.Width = 146
    '
    'ColumnHeader2
    '
    Me.ColumnHeader2.Text = "Typ"
    Me.ColumnHeader2.Width = 129
    '
    'ColumnHeader3
    '
    Me.ColumnHeader3.Text = "Sichtbarkeit"
    Me.ColumnHeader3.Width = 69
    '
    'ListView2
    '
    Me.ListView2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
    Me.ListView2.Location = New System.Drawing.Point(23, 286)
    Me.ListView2.MultiSelect = False
    Me.ListView2.Name = "ListView2"
    Me.ListView2.Size = New System.Drawing.Size(369, 161)
    Me.ListView2.TabIndex = 14
    Me.ListView2.UseCompatibleStateImageBehavior = False
    Me.ListView2.View = System.Windows.Forms.View.Details
    '
    'ColumnHeader4
    '
    Me.ColumnHeader4.Text = "Name"
    Me.ColumnHeader4.Width = 183
    '
    'ColumnHeader5
    '
    Me.ColumnHeader5.Text = "Typ"
    Me.ColumnHeader5.Width = 88
    '
    'ColumnHeader6
    '
    Me.ColumnHeader6.Text = "Sichtbarkeit"
    Me.ColumnHeader6.Width = 69
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(23, 265)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(58, 13)
    Me.Label3.TabIndex = 13
    Me.Label3.Text = "Methoden:"
    '
    'btnAA
    '
    Me.btnAA.Image = CType(resources.GetObject("btnAA.Image"), System.Drawing.Image)
    Me.btnAA.Location = New System.Drawing.Point(398, 121)
    Me.btnAA.Name = "btnAA"
    Me.btnAA.Size = New System.Drawing.Size(30, 25)
    Me.btnAA.TabIndex = 9
    Me.ToolTip1.SetToolTip(Me.btnAA, "Neues Attribut (Strg+A)")
    Me.btnAA.UseVisualStyleBackColor = True
    '
    'btnAR
    '
    Me.btnAR.Enabled = False
    Me.btnAR.Image = CType(resources.GetObject("btnAR.Image"), System.Drawing.Image)
    Me.btnAR.Location = New System.Drawing.Point(399, 174)
    Me.btnAR.Name = "btnAR"
    Me.btnAR.Size = New System.Drawing.Size(30, 25)
    Me.btnAR.TabIndex = 10
    Me.btnAR.UseVisualStyleBackColor = True
    '
    'btnAU
    '
    Me.btnAU.Enabled = False
    Me.btnAU.Image = CType(resources.GetObject("btnAU.Image"), System.Drawing.Image)
    Me.btnAU.Location = New System.Drawing.Point(399, 199)
    Me.btnAU.Name = "btnAU"
    Me.btnAU.Size = New System.Drawing.Size(30, 25)
    Me.btnAU.TabIndex = 11
    Me.btnAU.UseVisualStyleBackColor = True
    '
    'btnAD
    '
    Me.btnAD.Enabled = False
    Me.btnAD.Image = CType(resources.GetObject("btnAD.Image"), System.Drawing.Image)
    Me.btnAD.Location = New System.Drawing.Point(399, 224)
    Me.btnAD.Name = "btnAD"
    Me.btnAD.Size = New System.Drawing.Size(30, 25)
    Me.btnAD.TabIndex = 12
    Me.btnAD.UseVisualStyleBackColor = True
    '
    'btnMD
    '
    Me.btnMD.Enabled = False
    Me.btnMD.Image = CType(resources.GetObject("btnMD.Image"), System.Drawing.Image)
    Me.btnMD.Location = New System.Drawing.Point(399, 422)
    Me.btnMD.Name = "btnMD"
    Me.btnMD.Size = New System.Drawing.Size(30, 25)
    Me.btnMD.TabIndex = 18
    Me.btnMD.UseVisualStyleBackColor = True
    '
    'btnMU
    '
    Me.btnMU.Enabled = False
    Me.btnMU.Image = CType(resources.GetObject("btnMU.Image"), System.Drawing.Image)
    Me.btnMU.Location = New System.Drawing.Point(399, 397)
    Me.btnMU.Name = "btnMU"
    Me.btnMU.Size = New System.Drawing.Size(30, 25)
    Me.btnMU.TabIndex = 17
    Me.btnMU.UseVisualStyleBackColor = True
    '
    'btnMR
    '
    Me.btnMR.Enabled = False
    Me.btnMR.Image = CType(resources.GetObject("btnMR.Image"), System.Drawing.Image)
    Me.btnMR.Location = New System.Drawing.Point(399, 372)
    Me.btnMR.Name = "btnMR"
    Me.btnMR.Size = New System.Drawing.Size(30, 25)
    Me.btnMR.TabIndex = 16
    Me.btnMR.UseVisualStyleBackColor = True
    '
    'btnMA
    '
    Me.btnMA.Image = CType(resources.GetObject("btnMA.Image"), System.Drawing.Image)
    Me.btnMA.Location = New System.Drawing.Point(398, 286)
    Me.btnMA.Name = "btnMA"
    Me.btnMA.Size = New System.Drawing.Size(30, 25)
    Me.btnMA.TabIndex = 15
    Me.ToolTip1.SetToolTip(Me.btnMA, "Neue Methode (Strg+M)")
    Me.btnMA.UseVisualStyleBackColor = True
    '
    'TextBox2
    '
    Me.TextBox2.Location = New System.Drawing.Point(189, 45)
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Size = New System.Drawing.Size(238, 20)
    Me.TextBox2.TabIndex = 3
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(98, 48)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(42, 13)
    Me.Label4.TabIndex = 2
    Me.Label4.Text = "Zusatz:"
    '
    'btnPA
    '
    Me.btnPA.Image = CType(resources.GetObject("btnPA.Image"), System.Drawing.Image)
    Me.btnPA.Location = New System.Drawing.Point(398, 311)
    Me.btnPA.Name = "btnPA"
    Me.btnPA.Size = New System.Drawing.Size(30, 25)
    Me.btnPA.TabIndex = 19
    Me.ToolTip1.SetToolTip(Me.btnPA, "Neue Eigenschaft (Strg+P)")
    Me.btnPA.UseVisualStyleBackColor = True
    '
    'frm_editUmlClass
    '
    Me.AcceptButton = Me.OK_Button
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.CancelButton = Me.Cancel_Button
    Me.ClientSize = New System.Drawing.Size(447, 499)
    Me.Controls.Add(Me.btnPA)
    Me.Controls.Add(Me.TextBox2)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.btnMD)
    Me.Controls.Add(Me.btnMU)
    Me.Controls.Add(Me.btnMR)
    Me.Controls.Add(Me.btnMA)
    Me.Controls.Add(Me.btnAD)
    Me.Controls.Add(Me.btnAU)
    Me.Controls.Add(Me.btnAR)
    Me.Controls.Add(Me.btnAA)
    Me.Controls.Add(Me.ListView2)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.ListView1)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.rbPublic)
    Me.Controls.Add(Me.rbProtected)
    Me.Controls.Add(Me.rbPrivate)
    Me.Controls.Add(Me.TextBox1)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.PictureBox1)
    Me.Controls.Add(Me.TableLayoutPanel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frm_editUmlClass"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Klasse bearbeiten ..."
    Me.TableLayoutPanel1.ResumeLayout(False)
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents OK_Button As System.Windows.Forms.Button
  Friend WithEvents Cancel_Button As System.Windows.Forms.Button
  Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents rbPrivate As System.Windows.Forms.RadioButton
  Friend WithEvents rbProtected As System.Windows.Forms.RadioButton
  Friend WithEvents rbPublic As System.Windows.Forms.RadioButton
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents ListView1 As System.Windows.Forms.ListView
  Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
  Friend WithEvents ListView2 As System.Windows.Forms.ListView
  Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents btnAA As System.Windows.Forms.Button
  Friend WithEvents btnAR As System.Windows.Forms.Button
  Friend WithEvents btnAU As System.Windows.Forms.Button
  Friend WithEvents btnAD As System.Windows.Forms.Button
  Friend WithEvents btnMD As System.Windows.Forms.Button
  Friend WithEvents btnMU As System.Windows.Forms.Button
  Friend WithEvents btnMR As System.Windows.Forms.Button
  Friend WithEvents btnMA As System.Windows.Forms.Button
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents btnPA As System.Windows.Forms.Button
  Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

End Class
