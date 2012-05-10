<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_editUmlMember
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_editUmlMember))
    Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
    Me.OK_Button = New System.Windows.Forms.Button
    Me.Cancel_Button = New System.Windows.Forms.Button
    Me.Label1 = New System.Windows.Forms.Label
    Me.TextBox1 = New System.Windows.Forms.TextBox
    Me.TextBox2 = New System.Windows.Forms.TextBox
    Me.Label2 = New System.Windows.Forms.Label
    Me.rbPublic = New System.Windows.Forms.RadioButton
    Me.rbProtected = New System.Windows.Forms.RadioButton
    Me.rbPrivate = New System.Windows.Forms.RadioButton
    Me.lstParams = New System.Windows.Forms.ListBox
    Me.GroupBox1 = New System.Windows.Forms.GroupBox
    Me.btnMD = New System.Windows.Forms.Button
    Me.btnMU = New System.Windows.Forms.Button
    Me.btnMR = New System.Windows.Forms.Button
    Me.btnMA = New System.Windows.Forms.Button
    Me.chkIsStatic = New System.Windows.Forms.CheckBox
    Me.TableLayoutPanel1.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
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
    Me.TableLayoutPanel1.Location = New System.Drawing.Point(113, 288)
    Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    Me.TableLayoutPanel1.RowCount = 1
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.Size = New System.Drawing.Size(204, 29)
    Me.TableLayoutPanel1.TabIndex = 8
    '
    'OK_Button
    '
    Me.OK_Button.Dock = System.Windows.Forms.DockStyle.Fill
    Me.OK_Button.Location = New System.Drawing.Point(3, 3)
    Me.OK_Button.Name = "OK_Button"
    Me.OK_Button.Size = New System.Drawing.Size(96, 23)
    Me.OK_Button.TabIndex = 0
    Me.OK_Button.Text = "&OK"
    '
    'Cancel_Button
    '
    Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Cancel_Button.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Cancel_Button.Location = New System.Drawing.Point(105, 3)
    Me.Cancel_Button.Name = "Cancel_Button"
    Me.Cancel_Button.Size = New System.Drawing.Size(96, 23)
    Me.Cancel_Button.TabIndex = 1
    Me.Cancel_Button.Text = "Abbrechen"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(27, 24)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(38, 13)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Name:"
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(96, 21)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(216, 20)
    Me.TextBox1.TabIndex = 1
    '
    'TextBox2
    '
    Me.TextBox2.Location = New System.Drawing.Point(96, 47)
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Size = New System.Drawing.Size(216, 20)
    Me.TextBox2.TabIndex = 3
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(27, 50)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(28, 13)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "Typ:"
    '
    'rbPublic
    '
    Me.rbPublic.AutoSize = True
    Me.rbPublic.Location = New System.Drawing.Point(30, 82)
    Me.rbPublic.Name = "rbPublic"
    Me.rbPublic.Size = New System.Drawing.Size(65, 17)
    Me.rbPublic.TabIndex = 4
    Me.rbPublic.TabStop = True
    Me.rbPublic.Text = "&0: public"
    Me.rbPublic.UseVisualStyleBackColor = True
    '
    'rbProtected
    '
    Me.rbProtected.AutoSize = True
    Me.rbProtected.Location = New System.Drawing.Point(118, 82)
    Me.rbProtected.Name = "rbProtected"
    Me.rbProtected.Size = New System.Drawing.Size(82, 17)
    Me.rbProtected.TabIndex = 5
    Me.rbProtected.TabStop = True
    Me.rbProtected.Text = "&1: protected"
    Me.rbProtected.UseVisualStyleBackColor = True
    '
    'rbPrivate
    '
    Me.rbPrivate.AutoSize = True
    Me.rbPrivate.Location = New System.Drawing.Point(218, 82)
    Me.rbPrivate.Name = "rbPrivate"
    Me.rbPrivate.Size = New System.Drawing.Size(69, 17)
    Me.rbPrivate.TabIndex = 6
    Me.rbPrivate.TabStop = True
    Me.rbPrivate.Text = "&2: private"
    Me.rbPrivate.UseVisualStyleBackColor = True
    '
    'lstParams
    '
    Me.lstParams.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
    Me.lstParams.FormattingEnabled = True
    Me.lstParams.IntegralHeight = False
    Me.lstParams.Location = New System.Drawing.Point(10, 22)
    Me.lstParams.Name = "lstParams"
    Me.lstParams.Size = New System.Drawing.Size(226, 100)
    Me.lstParams.TabIndex = 0
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.btnMD)
    Me.GroupBox1.Controls.Add(Me.btnMU)
    Me.GroupBox1.Controls.Add(Me.btnMR)
    Me.GroupBox1.Controls.Add(Me.btnMA)
    Me.GroupBox1.Controls.Add(Me.lstParams)
    Me.GroupBox1.Location = New System.Drawing.Point(30, 137)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(281, 137)
    Me.GroupBox1.TabIndex = 7
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Parameter"
    '
    'btnMD
    '
    Me.btnMD.Enabled = False
    Me.btnMD.Image = CType(resources.GetObject("btnMD.Image"), System.Drawing.Image)
    Me.btnMD.Location = New System.Drawing.Point(242, 97)
    Me.btnMD.Name = "btnMD"
    Me.btnMD.Size = New System.Drawing.Size(30, 25)
    Me.btnMD.TabIndex = 4
    Me.btnMD.UseVisualStyleBackColor = True
    '
    'btnMU
    '
    Me.btnMU.Enabled = False
    Me.btnMU.Image = CType(resources.GetObject("btnMU.Image"), System.Drawing.Image)
    Me.btnMU.Location = New System.Drawing.Point(242, 72)
    Me.btnMU.Name = "btnMU"
    Me.btnMU.Size = New System.Drawing.Size(30, 25)
    Me.btnMU.TabIndex = 3
    Me.btnMU.UseVisualStyleBackColor = True
    '
    'btnMR
    '
    Me.btnMR.Enabled = False
    Me.btnMR.Image = CType(resources.GetObject("btnMR.Image"), System.Drawing.Image)
    Me.btnMR.Location = New System.Drawing.Point(242, 47)
    Me.btnMR.Name = "btnMR"
    Me.btnMR.Size = New System.Drawing.Size(30, 25)
    Me.btnMR.TabIndex = 2
    Me.btnMR.UseVisualStyleBackColor = True
    '
    'btnMA
    '
    Me.btnMA.Image = CType(resources.GetObject("btnMA.Image"), System.Drawing.Image)
    Me.btnMA.Location = New System.Drawing.Point(242, 22)
    Me.btnMA.Name = "btnMA"
    Me.btnMA.Size = New System.Drawing.Size(30, 25)
    Me.btnMA.TabIndex = 1
    Me.btnMA.UseVisualStyleBackColor = True
    '
    'chkIsStatic
    '
    Me.chkIsStatic.AutoSize = True
    Me.chkIsStatic.Location = New System.Drawing.Point(30, 110)
    Me.chkIsStatic.Name = "chkIsStatic"
    Me.chkIsStatic.Size = New System.Drawing.Size(114, 17)
    Me.chkIsStatic.TabIndex = 9
    Me.chkIsStatic.Text = "Statisches Mitglied"
    Me.chkIsStatic.UseVisualStyleBackColor = True
    '
    'frm_editUmlMember
    '
    Me.AcceptButton = Me.OK_Button
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.CancelButton = Me.Cancel_Button
    Me.ClientSize = New System.Drawing.Size(343, 329)
    Me.Controls.Add(Me.chkIsStatic)
    Me.Controls.Add(Me.rbPublic)
    Me.Controls.Add(Me.rbProtected)
    Me.Controls.Add(Me.rbPrivate)
    Me.Controls.Add(Me.TextBox2)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TextBox1)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TableLayoutPanel1)
    Me.Controls.Add(Me.GroupBox1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frm_editUmlMember"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Mitglied bearbeiten ..."
    Me.TableLayoutPanel1.ResumeLayout(False)
    Me.GroupBox1.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents OK_Button As System.Windows.Forms.Button
  Friend WithEvents Cancel_Button As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents rbPublic As System.Windows.Forms.RadioButton
  Friend WithEvents rbProtected As System.Windows.Forms.RadioButton
  Friend WithEvents rbPrivate As System.Windows.Forms.RadioButton
  Friend WithEvents lstParams As System.Windows.Forms.ListBox
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents btnMD As System.Windows.Forms.Button
  Friend WithEvents btnMU As System.Windows.Forms.Button
  Friend WithEvents btnMR As System.Windows.Forms.Button
  Friend WithEvents btnMA As System.Windows.Forms.Button
  Friend WithEvents chkIsStatic As System.Windows.Forms.CheckBox

End Class
