<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CloudSaveDialog
  Inherits System.Windows.Forms.Form

  'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

  'Wird vom Windows Form-Designer benötigt.
  Private components As System.ComponentModel.IContainer

  'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
  'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
  'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CloudSaveDialog))
    Me.Label4 = New System.Windows.Forms.Label()
    Me.btnDropMeSave = New System.Windows.Forms.Button()
    Me.txtDropMeSave = New System.Windows.Forms.TextBox()
    Me.PictureBox1 = New System.Windows.Forms.PictureBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.TextBox2 = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(263, 122)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(29, 13)
    Me.Label4.TabIndex = 10
    Me.Label4.Text = ".html"
    '
    'btnDropMeSave
    '
    Me.btnDropMeSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnDropMeSave.Location = New System.Drawing.Point(324, 12)
    Me.btnDropMeSave.Name = "btnDropMeSave"
    Me.btnDropMeSave.Size = New System.Drawing.Size(91, 23)
    Me.btnDropMeSave.TabIndex = 9
    Me.btnDropMeSave.Text = "OK"
    Me.btnDropMeSave.UseVisualStyleBackColor = True
    '
    'txtDropMeSave
    '
    Me.txtDropMeSave.Location = New System.Drawing.Point(69, 118)
    Me.txtDropMeSave.Name = "txtDropMeSave"
    Me.txtDropMeSave.Size = New System.Drawing.Size(194, 20)
    Me.txtDropMeSave.TabIndex = 8
    '
    'PictureBox1
    '
    Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
    Me.PictureBox1.Location = New System.Drawing.Point(17, 12)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
    Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
    Me.PictureBox1.TabIndex = 11
    Me.PictureBox1.TabStop = False
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(66, 102)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(61, 13)
    Me.Label1.TabIndex = 12
    Me.Label1.Text = "Dateiname:"
    '
    'Button1
    '
    Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Button1.Location = New System.Drawing.Point(324, 41)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(91, 23)
    Me.Button1.TabIndex = 13
    Me.Button1.Text = "Abbrechen"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(66, 56)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(93, 13)
    Me.Label2.TabIndex = 14
    Me.Label2.Text = "Onlineverzeichnis:"
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(69, 72)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(236, 20)
    Me.TextBox1.TabIndex = 15
    '
    'TextBox2
    '
    Me.TextBox2.Enabled = False
    Me.TextBox2.Location = New System.Drawing.Point(69, 28)
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Size = New System.Drawing.Size(236, 20)
    Me.TextBox2.TabIndex = 17
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(66, 12)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(41, 13)
    Me.Label3.TabIndex = 16
    Me.Label3.Text = "Server:"
    '
    'CloudSaveDialog
    '
    Me.AcceptButton = Me.btnDropMeSave
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.CancelButton = Me.Button1
    Me.ClientSize = New System.Drawing.Size(427, 152)
    Me.Controls.Add(Me.TextBox2)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TextBox1)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Button1)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.PictureBox1)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.btnDropMeSave)
    Me.Controls.Add(Me.txtDropMeSave)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "CloudSaveDialog"
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.Text = "Datei online speichern ..."
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents PictureBox1 As PictureBox
  Friend WithEvents Label4 As Label
  Friend WithEvents btnDropMeSave As Button
  Friend WithEvents txtDropMeSave As TextBox
  Friend WithEvents Label1 As Label
  Friend WithEvents Button1 As Button
  Friend WithEvents Label2 As Label
  Friend WithEvents TextBox1 As TextBox
  Friend WithEvents TextBox2 As TextBox
  Friend WithEvents Label3 As Label
End Class
