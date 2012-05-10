<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
    Me.AxScriptControl1 = New AxMSScriptControl.AxScriptControl
    Me.PictureBox1 = New System.Windows.Forms.PictureBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.txtSourcefile = New System.Windows.Forms.TextBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.ComboBox1 = New System.Windows.Forms.ComboBox
    Me.Button1 = New System.Windows.Forms.Button
    Me.btnOK = New System.Windows.Forms.Button
    Me.btnCancel = New System.Windows.Forms.Button
    CType(Me.AxScriptControl1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'AxScriptControl1
    '
    Me.AxScriptControl1.Enabled = True
    Me.AxScriptControl1.Location = New System.Drawing.Point(29, 156)
    Me.AxScriptControl1.Name = "AxScriptControl1"
    Me.AxScriptControl1.OcxState = CType(resources.GetObject("AxScriptControl1.OcxState"), System.Windows.Forms.AxHost.State)
    Me.AxScriptControl1.Size = New System.Drawing.Size(38, 38)
    Me.AxScriptControl1.TabIndex = 0
    '
    'PictureBox1
    '
    Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
    Me.PictureBox1.Location = New System.Drawing.Point(14, 19)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(70, 64)
    Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
    Me.PictureBox1.TabIndex = 1
    Me.PictureBox1.TabStop = False
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(98, 19)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(229, 13)
    Me.Label1.TabIndex = 2
    Me.Label1.Text = "Code-Generierung aus folgender Collage-Datei:"
    '
    'txtSourcefile
    '
    Me.txtSourcefile.Location = New System.Drawing.Point(101, 39)
    Me.txtSourcefile.Name = "txtSourcefile"
    Me.txtSourcefile.ReadOnly = True
    Me.txtSourcefile.Size = New System.Drawing.Size(375, 20)
    Me.txtSourcefile.TabIndex = 3
    Me.txtSourcefile.Text = "C:\_dev\uml-diagramme.html"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(98, 87)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(160, 13)
    Me.Label3.TabIndex = 6
    Me.Label3.Text = "Konvertierungsskript auswählen:"
    '
    'ComboBox1
    '
    Me.ComboBox1.FormattingEnabled = True
    Me.ComboBox1.Location = New System.Drawing.Point(101, 107)
    Me.ComboBox1.Name = "ComboBox1"
    Me.ComboBox1.Size = New System.Drawing.Size(334, 21)
    Me.ComboBox1.TabIndex = 7
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(441, 105)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(35, 23)
    Me.Button1.TabIndex = 8
    Me.Button1.Text = "..."
    Me.Button1.UseVisualStyleBackColor = True
    '
    'btnOK
    '
    Me.btnOK.Location = New System.Drawing.Point(212, 156)
    Me.btnOK.Name = "btnOK"
    Me.btnOK.Size = New System.Drawing.Size(129, 25)
    Me.btnOK.TabIndex = 9
    Me.btnOK.Text = "OK"
    Me.btnOK.UseVisualStyleBackColor = True
    '
    'btnCancel
    '
    Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.btnCancel.Location = New System.Drawing.Point(347, 156)
    Me.btnCancel.Name = "btnCancel"
    Me.btnCancel.Size = New System.Drawing.Size(129, 25)
    Me.btnCancel.TabIndex = 10
    Me.btnCancel.Text = "Abbrechen"
    Me.btnCancel.UseVisualStyleBackColor = True
    '
    'Form1
    '
    Me.AcceptButton = Me.btnOK
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.CancelButton = Me.btnCancel
    Me.ClientSize = New System.Drawing.Size(496, 199)
    Me.Controls.Add(Me.btnCancel)
    Me.Controls.Add(Me.btnOK)
    Me.Controls.Add(Me.Button1)
    Me.Controls.Add(Me.ComboBox1)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.txtSourcefile)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.AxScriptControl1)
    Me.Controls.Add(Me.PictureBox1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "UMLCodeGeneration"
    Me.TopMost = True
    CType(Me.AxScriptControl1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents AxScriptControl1 As AxMSScriptControl.AxScriptControl
  Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents txtSourcefile As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents btnOK As System.Windows.Forms.Button
  Friend WithEvents btnCancel As System.Windows.Forms.Button

End Class
