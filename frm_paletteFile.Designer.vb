<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_paletteFile
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_paletteFile))
    Me.TabControl1 = New System.Windows.Forms.TabControl
    Me.TabPage1 = New System.Windows.Forms.TabPage
    Me.Label2 = New System.Windows.Forms.Label
    Me.Label1 = New System.Windows.Forms.Label
    Me.TextBox1 = New System.Windows.Forms.TextBox
    Me.ListView1 = New System.Windows.Forms.ListView
    Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
    Me.Button2 = New System.Windows.Forms.Button
    Me.Button1 = New System.Windows.Forms.Button
    Me.TabPage2 = New System.Windows.Forms.TabPage
    Me.Label3 = New System.Windows.Forms.Label
    Me.ListView2 = New System.Windows.Forms.ListView
    Me.DirListBox1 = New Microsoft.VisualBasic.Compatibility.VB6.DirListBox
    Me.DriveListBox1 = New Microsoft.VisualBasic.Compatibility.VB6.DriveListBox
    Me.btnOpenLocal = New System.Windows.Forms.Button
    Me.btnSaveLocal = New System.Windows.Forms.Button
    Me.TabPage3 = New System.Windows.Forms.TabPage
    Me.pnlIcons = New System.Windows.Forms.Panel
    Me.Label4 = New System.Windows.Forms.Label
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.TabControl1.SuspendLayout()
    Me.TabPage1.SuspendLayout()
    Me.TabPage2.SuspendLayout()
    Me.TabPage3.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabControl1
    '
    Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
    Me.TabControl1.Controls.Add(Me.TabPage1)
    Me.TabControl1.Controls.Add(Me.TabPage2)
    Me.TabControl1.Controls.Add(Me.TabPage3)
    Me.TabControl1.ImageList = Me.ImageList1
    Me.TabControl1.Location = New System.Drawing.Point(-2, 0)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.ShowToolTips = True
    Me.TabControl1.Size = New System.Drawing.Size(183, 427)
    Me.TabControl1.TabIndex = 0
    '
    'TabPage1
    '
    Me.TabPage1.Controls.Add(Me.Label2)
    Me.TabPage1.Controls.Add(Me.Label1)
    Me.TabPage1.Controls.Add(Me.TextBox1)
    Me.TabPage1.Controls.Add(Me.ListView1)
    Me.TabPage1.Controls.Add(Me.Button2)
    Me.TabPage1.Controls.Add(Me.Button1)
    Me.TabPage1.ImageIndex = 0
    Me.TabPage1.Location = New System.Drawing.Point(4, 42)
    Me.TabPage1.Name = "TabPage1"
    Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage1.Size = New System.Drawing.Size(175, 381)
    Me.TabPage1.TabIndex = 0
    Me.TabPage1.ToolTipText = "Web"
    Me.TabPage1.UseVisualStyleBackColor = True
    '
    'Label2
    '
    Me.Label2.BackColor = System.Drawing.Color.DarkGray
    Me.Label2.Location = New System.Drawing.Point(0, 0)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(168, 16)
    Me.Label2.TabIndex = 5
    Me.Label2.Text = "Lesen und Speichern im Web"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(3, 359)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(122, 13)
    Me.Label1.TabIndex = 4
    Me.Label1.Text = "Einfügen per Drag+Drop"
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(3, 58)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(161, 20)
    Me.TextBox1.TabIndex = 3
    '
    'ListView1
    '
    Me.ListView1.Location = New System.Drawing.Point(3, 82)
    Me.ListView1.Name = "ListView1"
    Me.ListView1.Size = New System.Drawing.Size(161, 276)
    Me.ListView1.SmallImageList = Me.ImageList2
    Me.ListView1.TabIndex = 2
    Me.ListView1.UseCompatibleStateImageBehavior = False
    Me.ListView1.View = System.Windows.Forms.View.SmallIcon
    '
    'ImageList2
    '
    Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList2.Images.SetKeyName(0, "collage")
    Me.ImageList2.Images.SetKeyName(1, "image")
    '
    'Button2
    '
    Me.Button2.Location = New System.Drawing.Point(89, 20)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(75, 37)
    Me.Button2.TabIndex = 1
    Me.Button2.Text = "Öffnen"
    Me.Button2.UseVisualStyleBackColor = True
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(3, 20)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(84, 37)
    Me.Button1.TabIndex = 0
    Me.Button1.Text = "Speichern"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'TabPage2
    '
    Me.TabPage2.Controls.Add(Me.Label3)
    Me.TabPage2.Controls.Add(Me.ListView2)
    Me.TabPage2.Controls.Add(Me.DirListBox1)
    Me.TabPage2.Controls.Add(Me.DriveListBox1)
    Me.TabPage2.Controls.Add(Me.btnOpenLocal)
    Me.TabPage2.Controls.Add(Me.btnSaveLocal)
    Me.TabPage2.ImageIndex = 1
    Me.TabPage2.Location = New System.Drawing.Point(4, 42)
    Me.TabPage2.Name = "TabPage2"
    Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage2.Size = New System.Drawing.Size(175, 381)
    Me.TabPage2.TabIndex = 1
    Me.TabPage2.ToolTipText = "Lokal"
    Me.TabPage2.UseVisualStyleBackColor = True
    '
    'Label3
    '
    Me.Label3.BackColor = System.Drawing.Color.DarkGray
    Me.Label3.Location = New System.Drawing.Point(0, 0)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(168, 16)
    Me.Label3.TabIndex = 7
    Me.Label3.Text = "Lokale Dateien"
    '
    'ListView2
    '
    Me.ListView2.Location = New System.Drawing.Point(3, 200)
    Me.ListView2.Name = "ListView2"
    Me.ListView2.Size = New System.Drawing.Size(160, 177)
    Me.ListView2.SmallImageList = Me.ImageList2
    Me.ListView2.TabIndex = 6
    Me.ListView2.UseCompatibleStateImageBehavior = False
    Me.ListView2.View = System.Windows.Forms.View.List
    '
    'DirListBox1
    '
    Me.DirListBox1.FormattingEnabled = True
    Me.DirListBox1.IntegralHeight = False
    Me.DirListBox1.Location = New System.Drawing.Point(3, 81)
    Me.DirListBox1.Name = "DirListBox1"
    Me.DirListBox1.Size = New System.Drawing.Size(160, 117)
    Me.DirListBox1.TabIndex = 5
    '
    'DriveListBox1
    '
    Me.DriveListBox1.FormattingEnabled = True
    Me.DriveListBox1.Location = New System.Drawing.Point(3, 59)
    Me.DriveListBox1.Name = "DriveListBox1"
    Me.DriveListBox1.Size = New System.Drawing.Size(160, 21)
    Me.DriveListBox1.TabIndex = 4
    '
    'btnOpenLocal
    '
    Me.btnOpenLocal.Location = New System.Drawing.Point(89, 20)
    Me.btnOpenLocal.Name = "btnOpenLocal"
    Me.btnOpenLocal.Size = New System.Drawing.Size(73, 37)
    Me.btnOpenLocal.TabIndex = 3
    Me.btnOpenLocal.Text = "Öffnen"
    Me.btnOpenLocal.UseVisualStyleBackColor = True
    '
    'btnSaveLocal
    '
    Me.btnSaveLocal.Location = New System.Drawing.Point(3, 20)
    Me.btnSaveLocal.Name = "btnSaveLocal"
    Me.btnSaveLocal.Size = New System.Drawing.Size(84, 37)
    Me.btnSaveLocal.TabIndex = 2
    Me.btnSaveLocal.Text = "Speichern"
    Me.btnSaveLocal.UseVisualStyleBackColor = True
    '
    'TabPage3
    '
    Me.TabPage3.Controls.Add(Me.pnlIcons)
    Me.TabPage3.Controls.Add(Me.Label4)
    Me.TabPage3.ImageIndex = 2
    Me.TabPage3.Location = New System.Drawing.Point(4, 42)
    Me.TabPage3.Name = "TabPage3"
    Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage3.Size = New System.Drawing.Size(175, 381)
    Me.TabPage3.TabIndex = 2
    Me.TabPage3.ToolTipText = "Insert"
    Me.TabPage3.UseVisualStyleBackColor = True
    '
    'pnlIcons
    '
    Me.pnlIcons.Location = New System.Drawing.Point(1, 20)
    Me.pnlIcons.Name = "pnlIcons"
    Me.pnlIcons.Size = New System.Drawing.Size(165, 356)
    Me.pnlIcons.TabIndex = 9
    '
    'Label4
    '
    Me.Label4.BackColor = System.Drawing.Color.DarkGray
    Me.Label4.Location = New System.Drawing.Point(0, 0)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(168, 16)
    Me.Label4.TabIndex = 8
    Me.Label4.Text = "Icons einfügen"
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "iexplore_32542.ico")
    Me.ImageList1.Images.SetKeyName(1, "SETUPAPI_7.ico")
    Me.ImageList1.Images.SetKeyName(2, "wmploc_621.ico")
    '
    'frm_paletteFile
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(171, 423)
    Me.Controls.Add(Me.TabControl1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
    Me.Name = "frm_paletteFile"
    Me.Text = "Dateiverwaltung"
    Me.TabControl1.ResumeLayout(False)
    Me.TabPage1.ResumeLayout(False)
    Me.TabPage1.PerformLayout()
    Me.TabPage2.ResumeLayout(False)
    Me.TabPage3.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents ListView1 As System.Windows.Forms.ListView
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents btnOpenLocal As System.Windows.Forms.Button
  Friend WithEvents btnSaveLocal As System.Windows.Forms.Button
  Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
  Friend WithEvents ListView2 As System.Windows.Forms.ListView
  Friend WithEvents DirListBox1 As Microsoft.VisualBasic.Compatibility.VB6.DirListBox
  Friend WithEvents DriveListBox1 As Microsoft.VisualBasic.Compatibility.VB6.DriveListBox
  Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents pnlIcons As System.Windows.Forms.Panel
End Class
