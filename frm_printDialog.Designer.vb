<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_printDialog
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_printDialog))
    Me.PrintPreviewControl1 = New System.Windows.Forms.PrintPreviewControl
    Me.pd1 = New System.Drawing.Printing.PrintDocument
    Me.Button1 = New System.Windows.Forms.Button
    Me.Button2 = New System.Windows.Forms.Button
    Me.HScrollBar1 = New System.Windows.Forms.HScrollBar
    Me.VScrollBar1 = New System.Windows.Forms.VScrollBar
    Me.Label1 = New System.Windows.Forms.Label
    Me.CheckBox1 = New System.Windows.Forms.CheckBox
    Me.TrackBar1 = New System.Windows.Forms.TrackBar
    Me.Label3 = New System.Windows.Forms.Label
    Me.lstPrinters = New System.Windows.Forms.ListBox
    Me.btnPreview = New System.Windows.Forms.Button
    Me.rbOrientation__port = New System.Windows.Forms.RadioButton
    Me.rbOrientation__lands = New System.Windows.Forms.RadioButton
    Me.tmrRedraw = New System.Windows.Forms.Timer(Me.components)
    Me.txtZoom = New System.Windows.Forms.TextBox
    Me.Label4 = New System.Windows.Forms.Label
    Me.rbZoom__page = New System.Windows.Forms.RadioButton
    Me.rbZoom__pic = New System.Windows.Forms.RadioButton
    Me.GroupBox1 = New System.Windows.Forms.GroupBox
    Me.GroupBox2 = New System.Windows.Forms.GroupBox
    Me.cmbPaperSource = New System.Windows.Forms.ComboBox
    Me.txtPreviewZoom = New System.Windows.Forms.NumericUpDown
    Me.Label2 = New System.Windows.Forms.Label
    Me.Label5 = New System.Windows.Forms.Label
    CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    CType(Me.txtPreviewZoom, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'PrintPreviewControl1
    '
    Me.PrintPreviewControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.PrintPreviewControl1.AutoZoom = False
    Me.PrintPreviewControl1.Document = Me.pd1
    Me.PrintPreviewControl1.Location = New System.Drawing.Point(271, 0)
    Me.PrintPreviewControl1.Name = "PrintPreviewControl1"
    Me.PrintPreviewControl1.Size = New System.Drawing.Size(560, 550)
    Me.PrintPreviewControl1.TabIndex = 0
    Me.PrintPreviewControl1.Visible = False
    Me.PrintPreviewControl1.Zoom = 0.6
    '
    'pd1
    '
    Me.pd1.DocumentName = "ScreenShot"
    '
    'Button1
    '
    Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
    Me.Button1.Location = New System.Drawing.Point(12, 6)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(132, 43)
    Me.Button1.TabIndex = 1
    Me.Button1.Text = "Drucken"
    Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.Button1.UseVisualStyleBackColor = True
    '
    'Button2
    '
    Me.Button2.Location = New System.Drawing.Point(142, 443)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(118, 28)
    Me.Button2.TabIndex = 2
    Me.Button2.Text = "Abbrechen"
    Me.Button2.UseVisualStyleBackColor = True
    '
    'HScrollBar1
    '
    Me.HScrollBar1.Location = New System.Drawing.Point(44, 21)
    Me.HScrollBar1.Name = "HScrollBar1"
    Me.HScrollBar1.Size = New System.Drawing.Size(204, 24)
    Me.HScrollBar1.TabIndex = 3
    '
    'VScrollBar1
    '
    Me.VScrollBar1.Location = New System.Drawing.Point(9, 21)
    Me.VScrollBar1.Name = "VScrollBar1"
    Me.VScrollBar1.Size = New System.Drawing.Size(31, 128)
    Me.VScrollBar1.TabIndex = 4
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(58, 60)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(93, 26)
    Me.Label1.TabIndex = 5
    Me.Label1.Text = "Abstand einstellen" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  - oder -"
    '
    'CheckBox1
    '
    Me.CheckBox1.AutoSize = True
    Me.CheckBox1.Location = New System.Drawing.Point(60, 93)
    Me.CheckBox1.Name = "CheckBox1"
    Me.CheckBox1.Size = New System.Drawing.Size(72, 17)
    Me.CheckBox1.TabIndex = 6
    Me.CheckBox1.Text = "zentrieren"
    Me.CheckBox1.UseVisualStyleBackColor = True
    '
    'TrackBar1
    '
    Me.TrackBar1.Location = New System.Drawing.Point(55, 19)
    Me.TrackBar1.Maximum = 100
    Me.TrackBar1.Minimum = 5
    Me.TrackBar1.Name = "TrackBar1"
    Me.TrackBar1.Size = New System.Drawing.Size(156, 45)
    Me.TrackBar1.TabIndex = 7
    Me.TrackBar1.TickFrequency = 10
    Me.TrackBar1.Value = 100
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(9, 297)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(48, 13)
    Me.Label3.TabIndex = 9
    Me.Label3.Text = "Drucker:"
    '
    'lstPrinters
    '
    Me.lstPrinters.FormattingEnabled = True
    Me.lstPrinters.Location = New System.Drawing.Point(12, 313)
    Me.lstPrinters.Name = "lstPrinters"
    Me.lstPrinters.Size = New System.Drawing.Size(248, 69)
    Me.lstPrinters.TabIndex = 10
    '
    'btnPreview
    '
    Me.btnPreview.Location = New System.Drawing.Point(150, 6)
    Me.btnPreview.Name = "btnPreview"
    Me.btnPreview.Size = New System.Drawing.Size(110, 43)
    Me.btnPreview.TabIndex = 11
    Me.btnPreview.Text = "<<< Vorschau"
    Me.btnPreview.UseVisualStyleBackColor = True
    '
    'rbOrientation__port
    '
    Me.rbOrientation__port.Image = CType(resources.GetObject("rbOrientation__port.Image"), System.Drawing.Image)
    Me.rbOrientation__port.Location = New System.Drawing.Point(175, 55)
    Me.rbOrientation__port.Name = "rbOrientation__port"
    Me.rbOrientation__port.Size = New System.Drawing.Size(59, 40)
    Me.rbOrientation__port.TabIndex = 12
    Me.rbOrientation__port.UseVisualStyleBackColor = True
    '
    'rbOrientation__lands
    '
    Me.rbOrientation__lands.Image = CType(resources.GetObject("rbOrientation__lands.Image"), System.Drawing.Image)
    Me.rbOrientation__lands.Location = New System.Drawing.Point(175, 93)
    Me.rbOrientation__lands.Name = "rbOrientation__lands"
    Me.rbOrientation__lands.Size = New System.Drawing.Size(59, 40)
    Me.rbOrientation__lands.TabIndex = 13
    Me.rbOrientation__lands.UseVisualStyleBackColor = True
    '
    'tmrRedraw
    '
    Me.tmrRedraw.Interval = 500
    '
    'txtZoom
    '
    Me.txtZoom.Location = New System.Drawing.Point(210, 26)
    Me.txtZoom.Name = "txtZoom"
    Me.txtZoom.Size = New System.Drawing.Size(42, 20)
    Me.txtZoom.TabIndex = 14
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(9, 388)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(71, 13)
    Me.Label4.TabIndex = 15
    Me.Label4.Text = "Papiereinzug:"
    '
    'rbZoom__page
    '
    Me.rbZoom__page.AutoSize = True
    Me.rbZoom__page.Checked = True
    Me.rbZoom__page.Location = New System.Drawing.Point(10, 19)
    Me.rbZoom__page.Name = "rbZoom__page"
    Me.rbZoom__page.Size = New System.Drawing.Size(49, 17)
    Me.rbZoom__page.TabIndex = 17
    Me.rbZoom__page.TabStop = True
    Me.rbZoom__page.Text = "Seite"
    Me.rbZoom__page.UseVisualStyleBackColor = True
    '
    'rbZoom__pic
    '
    Me.rbZoom__pic.AutoSize = True
    Me.rbZoom__pic.Location = New System.Drawing.Point(10, 40)
    Me.rbZoom__pic.Name = "rbZoom__pic"
    Me.rbZoom__pic.Size = New System.Drawing.Size(42, 17)
    Me.rbZoom__pic.TabIndex = 18
    Me.rbZoom__pic.Text = "Bild"
    Me.rbZoom__pic.UseVisualStyleBackColor = True
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.rbZoom__pic)
    Me.GroupBox1.Controls.Add(Me.rbZoom__page)
    Me.GroupBox1.Controls.Add(Me.txtZoom)
    Me.GroupBox1.Controls.Add(Me.TrackBar1)
    Me.GroupBox1.Location = New System.Drawing.Point(12, 222)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(248, 68)
    Me.GroupBox1.TabIndex = 19
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Zoom"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.rbOrientation__lands)
    Me.GroupBox2.Controls.Add(Me.rbOrientation__port)
    Me.GroupBox2.Controls.Add(Me.CheckBox1)
    Me.GroupBox2.Controls.Add(Me.Label1)
    Me.GroupBox2.Controls.Add(Me.VScrollBar1)
    Me.GroupBox2.Controls.Add(Me.HScrollBar1)
    Me.GroupBox2.Location = New System.Drawing.Point(12, 58)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(248, 159)
    Me.GroupBox2.TabIndex = 20
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Position"
    '
    'cmbPaperSource
    '
    Me.cmbPaperSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cmbPaperSource.FormattingEnabled = True
    Me.cmbPaperSource.Location = New System.Drawing.Point(12, 404)
    Me.cmbPaperSource.Name = "cmbPaperSource"
    Me.cmbPaperSource.Size = New System.Drawing.Size(248, 21)
    Me.cmbPaperSource.TabIndex = 21
    '
    'txtPreviewZoom
    '
    Me.txtPreviewZoom.Location = New System.Drawing.Point(113, 507)
    Me.txtPreviewZoom.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
    Me.txtPreviewZoom.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
    Me.txtPreviewZoom.Name = "txtPreviewZoom"
    Me.txtPreviewZoom.Size = New System.Drawing.Size(61, 20)
    Me.txtPreviewZoom.TabIndex = 22
    Me.txtPreviewZoom.Value = New Decimal(New Integer() {60, 0, 0, 0})
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(22, 509)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(85, 13)
    Me.Label2.TabIndex = 23
    Me.Label2.Text = "Zoom Vorschau:"
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(177, 509)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(15, 13)
    Me.Label5.TabIndex = 24
    Me.Label5.Text = "%"
    '
    'frm_printDialog
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(831, 550)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.txtPreviewZoom)
    Me.Controls.Add(Me.cmbPaperSource)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.btnPreview)
    Me.Controls.Add(Me.lstPrinters)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Button1)
    Me.Controls.Add(Me.Button2)
    Me.Controls.Add(Me.PrintPreviewControl1)
    Me.Controls.Add(Me.GroupBox2)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frm_printDialog"
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Druckvorschau"
    CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    CType(Me.txtPreviewZoom, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents PrintPreviewControl1 As System.Windows.Forms.PrintPreviewControl
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents HScrollBar1 As System.Windows.Forms.HScrollBar
  Friend WithEvents VScrollBar1 As System.Windows.Forms.VScrollBar
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
  Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents lstPrinters As System.Windows.Forms.ListBox
  Friend WithEvents pd1 As System.Drawing.Printing.PrintDocument
  Friend WithEvents btnPreview As System.Windows.Forms.Button
  Friend WithEvents rbOrientation__port As System.Windows.Forms.RadioButton
  Friend WithEvents rbOrientation__lands As System.Windows.Forms.RadioButton
  Friend WithEvents tmrRedraw As System.Windows.Forms.Timer
  Friend WithEvents txtZoom As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents rbZoom__page As System.Windows.Forms.RadioButton
  Friend WithEvents rbZoom__pic As System.Windows.Forms.RadioButton
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents cmbPaperSource As System.Windows.Forms.ComboBox
  Friend WithEvents txtPreviewZoom As System.Windows.Forms.NumericUpDown
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
