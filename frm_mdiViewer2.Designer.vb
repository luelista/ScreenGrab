<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_mdiViewer2
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_mdiViewer2))
    Me.PictureBox1 = New System.Windows.Forms.PictureBox
    Me.PictureBox2 = New System.Windows.Forms.PictureBox
    Me.Label4 = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.Label1 = New System.Windows.Forms.Label
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.Button6 = New System.Windows.Forms.Button
    Me.Button4 = New System.Windows.Forms.Button
    Me.Button3 = New System.Windows.Forms.Button
    Me.CheckBox1 = New System.Windows.Forms.CheckBox
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Panel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'PictureBox1
    '
    Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.PictureBox1.Location = New System.Drawing.Point(0, 30)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(644, 483)
    Me.PictureBox1.TabIndex = 0
    Me.PictureBox1.TabStop = False
    '
    'PictureBox2
    '
    Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
    Me.PictureBox2.Location = New System.Drawing.Point(3, 0)
    Me.PictureBox2.Name = "PictureBox2"
    Me.PictureBox2.Size = New System.Drawing.Size(32, 28)
    Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
    Me.PictureBox2.TabIndex = 4
    Me.PictureBox2.TabStop = False
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(38, 3)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(156, 21)
    Me.Label4.TabIndex = 3
    Me.Label4.Text = "ScreenGrab Collage-Modus"
    Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Label3
    '
    Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Label3.Font = New System.Drawing.Font("Webdings", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
    Me.Label3.Location = New System.Drawing.Point(579, 5)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(20, 20)
    Me.Label3.TabIndex = 2
    Me.Label3.Text = "0"
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Label2
    '
    Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Label2.Font = New System.Drawing.Font("Webdings", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
    Me.Label2.Location = New System.Drawing.Point(599, 5)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(20, 20)
    Me.Label2.TabIndex = 1
    Me.Label2.Text = "1"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Label1
    '
    Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Label1.Font = New System.Drawing.Font("Webdings", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
    Me.Label1.Location = New System.Drawing.Point(619, 5)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(20, 20)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "r"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Panel1
    '
    Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
    Me.Panel1.Controls.Add(Me.Button6)
    Me.Panel1.Controls.Add(Me.Button4)
    Me.Panel1.Controls.Add(Me.Button3)
    Me.Panel1.Controls.Add(Me.PictureBox2)
    Me.Panel1.Controls.Add(Me.Label2)
    Me.Panel1.Controls.Add(Me.Label1)
    Me.Panel1.Controls.Add(Me.Label3)
    Me.Panel1.Controls.Add(Me.Label4)
    Me.Panel1.Controls.Add(Me.CheckBox1)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(644, 30)
    Me.Panel1.TabIndex = 7
    '
    'Button6
    '
    Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
    Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.Button6.Location = New System.Drawing.Point(200, 2)
    Me.Button6.Name = "Button6"
    Me.Button6.Size = New System.Drawing.Size(100, 24)
    Me.Button6.TabIndex = 14
    Me.Button6.Text = "Datei ..."
    Me.Button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.Button6.UseVisualStyleBackColor = True
    '
    'Button4
    '
    Me.Button4.Location = New System.Drawing.Point(407, 2)
    Me.Button4.Name = "Button4"
    Me.Button4.Size = New System.Drawing.Size(100, 24)
    Me.Button4.TabIndex = 12
    Me.Button4.Text = "Kreis einfügen"
    Me.Button4.UseVisualStyleBackColor = True
    '
    'Button3
    '
    Me.Button3.Location = New System.Drawing.Point(303, 2)
    Me.Button3.Name = "Button3"
    Me.Button3.Size = New System.Drawing.Size(100, 24)
    Me.Button3.TabIndex = 11
    Me.Button3.Text = "Text einfügen"
    Me.Button3.UseVisualStyleBackColor = True
    '
    'CheckBox1
    '
    Me.CheckBox1.Location = New System.Drawing.Point(513, 3)
    Me.CheckBox1.Name = "CheckBox1"
    Me.CheckBox1.Size = New System.Drawing.Size(86, 24)
    Me.CheckBox1.TabIndex = 15
    Me.CheckBox1.Text = "Multitouch"
    Me.CheckBox1.UseVisualStyleBackColor = True
    Me.CheckBox1.Visible = False
    '
    'frm_mdiViewer2
    '
    Me.AllowDrop = True
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.White
    Me.ClientSize = New System.Drawing.Size(644, 513)
    Me.ControlBox = False
    Me.Controls.Add(Me.PictureBox1)
    Me.Controls.Add(Me.Panel1)
    Me.Name = "frm_mdiViewer2"
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Panel1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Button4 As System.Windows.Forms.Button
  Friend WithEvents Button3 As System.Windows.Forms.Button
  Friend WithEvents Button6 As System.Windows.Forms.Button
  Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class
