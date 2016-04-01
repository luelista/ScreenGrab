<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_options
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
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_options))
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TabPage1 = New System.Windows.Forms.TabPage()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.chkProportionalResize = New System.Windows.Forms.CheckBox()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.txtProxyDOM = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.txtProxyPW = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.txtProxyUN = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.GroupBox8 = New System.Windows.Forms.GroupBox()
    Me.chkCollageHitTestIntersect = New System.Windows.Forms.CheckBox()
    Me.imlWidgetIcons = New System.Windows.Forms.ImageList(Me.components)
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ofdChooseIcon = New System.Windows.Forms.OpenFileDialog()
    Me.btnClose = New System.Windows.Forms.Button()
    Me.TabControl1.SuspendLayout()
    Me.TabPage1.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox8.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabControl1
    '
    Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TabControl1.Controls.Add(Me.TabPage1)
    Me.TabControl1.Location = New System.Drawing.Point(12, 12)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(446, 406)
    Me.TabControl1.TabIndex = 0
    '
    'TabPage1
    '
    Me.TabPage1.Controls.Add(Me.GroupBox1)
    Me.TabPage1.Controls.Add(Me.GroupBox3)
    Me.TabPage1.Controls.Add(Me.GroupBox8)
    Me.TabPage1.Location = New System.Drawing.Point(4, 22)
    Me.TabPage1.Name = "TabPage1"
    Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage1.Size = New System.Drawing.Size(438, 380)
    Me.TabPage1.TabIndex = 4
    Me.TabPage1.Text = "Allgemein"
    Me.TabPage1.UseVisualStyleBackColor = True
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.chkProportionalResize)
    Me.GroupBox1.Location = New System.Drawing.Point(13, 75)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(407, 79)
    Me.GroupBox1.TabIndex = 19
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Bilder"
    '
    'chkProportionalResize
    '
    Me.chkProportionalResize.Location = New System.Drawing.Point(17, 20)
    Me.chkProportionalResize.Name = "chkProportionalResize"
    Me.chkProportionalResize.Size = New System.Drawing.Size(331, 32)
    Me.chkProportionalResize.TabIndex = 0
    Me.chkProportionalResize.Text = "Proportionen beibehalten bei Größenanpassung (Umschalten mit Umschalt-Taste)"
    Me.chkProportionalResize.UseVisualStyleBackColor = True
    '
    'GroupBox3
    '
    Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.GroupBox3.Controls.Add(Me.txtProxyDOM)
    Me.GroupBox3.Controls.Add(Me.Label5)
    Me.GroupBox3.Controls.Add(Me.txtProxyPW)
    Me.GroupBox3.Controls.Add(Me.Label3)
    Me.GroupBox3.Controls.Add(Me.txtProxyUN)
    Me.GroupBox3.Controls.Add(Me.Label2)
    Me.GroupBox3.Location = New System.Drawing.Point(13, 160)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(407, 111)
    Me.GroupBox3.TabIndex = 15
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Proxy"
    '
    'txtProxyDOM
    '
    Me.txtProxyDOM.Location = New System.Drawing.Point(102, 23)
    Me.txtProxyDOM.Name = "txtProxyDOM"
    Me.txtProxyDOM.Size = New System.Drawing.Size(180, 20)
    Me.txtProxyDOM.TabIndex = 16
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(11, 26)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(47, 13)
    Me.Label5.TabIndex = 15
    Me.Label5.Text = "Host/IP:"
    '
    'txtProxyPW
    '
    Me.txtProxyPW.Location = New System.Drawing.Point(102, 75)
    Me.txtProxyPW.Name = "txtProxyPW"
    Me.txtProxyPW.Size = New System.Drawing.Size(180, 20)
    Me.txtProxyPW.TabIndex = 14
    Me.txtProxyPW.UseSystemPasswordChar = True
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(11, 78)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(56, 13)
    Me.Label3.TabIndex = 13
    Me.Label3.Text = "Password:"
    '
    'txtProxyUN
    '
    Me.txtProxyUN.Location = New System.Drawing.Point(102, 49)
    Me.txtProxyUN.Name = "txtProxyUN"
    Me.txtProxyUN.Size = New System.Drawing.Size(180, 20)
    Me.txtProxyUN.TabIndex = 12
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(11, 52)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(58, 13)
    Me.Label2.TabIndex = 11
    Me.Label2.Text = "Username:"
    '
    'GroupBox8
    '
    Me.GroupBox8.Controls.Add(Me.chkCollageHitTestIntersect)
    Me.GroupBox8.Location = New System.Drawing.Point(13, 12)
    Me.GroupBox8.Name = "GroupBox8"
    Me.GroupBox8.Size = New System.Drawing.Size(407, 57)
    Me.GroupBox8.TabIndex = 18
    Me.GroupBox8.TabStop = False
    Me.GroupBox8.Text = "Auswahl"
    '
    'chkCollageHitTestIntersect
    '
    Me.chkCollageHitTestIntersect.AutoSize = True
    Me.chkCollageHitTestIntersect.Location = New System.Drawing.Point(17, 26)
    Me.chkCollageHitTestIntersect.Name = "chkCollageHitTestIntersect"
    Me.chkCollageHitTestIntersect.Size = New System.Drawing.Size(213, 17)
    Me.chkCollageHitTestIntersect.TabIndex = 0
    Me.chkCollageHitTestIntersect.Text = "Elemente auswählen mit einzelner Ecke"
    Me.chkCollageHitTestIntersect.UseVisualStyleBackColor = True
    '
    'imlWidgetIcons
    '
    Me.imlWidgetIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
    Me.imlWidgetIcons.ImageSize = New System.Drawing.Size(16, 16)
    Me.imlWidgetIcons.TransparentColor = System.Drawing.Color.Transparent
    '
    'ofdChooseIcon
    '
    Me.ofdChooseIcon.Filter = "Tranparenz-unterstützende Bilddateien (*.png, *.gif)|*.png;*.gif|Alle Bilddateien" &
    " (*.png, *.gif, *.bmp, *.jpg)|*.png;*.gif;*.bmp;*.jpg|Alle Dateien|*"
    Me.ofdChooseIcon.Title = "Icon auswählen (bestenfalls 32x32) ..."
    '
    'btnClose
    '
    Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.btnClose.Location = New System.Drawing.Point(332, 426)
    Me.btnClose.Name = "btnClose"
    Me.btnClose.Size = New System.Drawing.Size(126, 26)
    Me.btnClose.TabIndex = 3
    Me.btnClose.Text = "OK"
    Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.btnClose.UseVisualStyleBackColor = True
    '
    'frm_options
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(470, 462)
    Me.Controls.Add(Me.TabControl1)
    Me.Controls.Add(Me.btnClose)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frm_options"
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Optionen"
    Me.TabControl1.ResumeLayout(False)
    Me.TabPage1.ResumeLayout(False)
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.GroupBox8.ResumeLayout(False)
    Me.GroupBox8.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
  Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
  Friend WithEvents ofdChooseIcon As System.Windows.Forms.OpenFileDialog
  Friend WithEvents imlWidgetIcons As System.Windows.Forms.ImageList
  Friend WithEvents btnClose As System.Windows.Forms.Button
  Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
  Friend WithEvents chkCollageHitTestIntersect As System.Windows.Forms.CheckBox
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents txtProxyDOM As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents txtProxyPW As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents txtProxyUN As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents GroupBox1 As GroupBox
  Friend WithEvents chkProportionalResize As CheckBox
End Class
