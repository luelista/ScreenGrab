<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutBox1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub


    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutBox1))
    Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
    Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
    Me.OKButton = New System.Windows.Forms.Button
    Me.LabelVersion = New System.Windows.Forms.Label
    Me.LabelProductName = New System.Windows.Forms.Label
    Me.LogoPictureBox = New System.Windows.Forms.PictureBox
    Me.LabelCompanyName = New System.Windows.Forms.Label
    Me.LabelCopyright = New System.Windows.Forms.Label
    Me.TextBox1 = New System.Windows.Forms.TextBox
    CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'LinkLabel2
    '
    Me.LinkLabel2.AutoSize = True
    Me.LinkLabel2.Location = New System.Drawing.Point(142, 136)
    Me.LinkLabel2.Name = "LinkLabel2"
    Me.LinkLabel2.Size = New System.Drawing.Size(148, 13)
    Me.LinkLabel2.TabIndex = 2
    Me.LinkLabel2.TabStop = True
    Me.LinkLabel2.Text = "http://maxweller.teamwiki.de/"
    '
    'LinkLabel1
    '
    Me.LinkLabel1.AutoSize = True
    Me.LinkLabel1.Location = New System.Drawing.Point(142, 159)
    Me.LinkLabel1.Name = "LinkLabel1"
    Me.LinkLabel1.Size = New System.Drawing.Size(239, 13)
    Me.LinkLabel1.TabIndex = 1
    Me.LinkLabel1.TabStop = True
    Me.LinkLabel1.Text = "http://develop.teamwiki.de/screengrab_2_0.html"
    '
    'OKButton
    '
    Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.OKButton.Location = New System.Drawing.Point(286, 208)
    Me.OKButton.Name = "OKButton"
    Me.OKButton.Size = New System.Drawing.Size(95, 24)
    Me.OKButton.TabIndex = 0
    Me.OKButton.Text = "&OK"
    '
    'LabelVersion
    '
    Me.LabelVersion.Location = New System.Drawing.Point(142, 54)
    Me.LabelVersion.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
    Me.LabelVersion.MaximumSize = New System.Drawing.Size(0, 17)
    Me.LabelVersion.Name = "LabelVersion"
    Me.LabelVersion.Size = New System.Drawing.Size(0, 17)
    Me.LabelVersion.TabIndex = 0
    Me.LabelVersion.Text = "Version"
    Me.LabelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LabelProductName
    '
    Me.LabelProductName.Location = New System.Drawing.Point(142, 27)
    Me.LabelProductName.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
    Me.LabelProductName.MaximumSize = New System.Drawing.Size(0, 17)
    Me.LabelProductName.Name = "LabelProductName"
    Me.LabelProductName.Size = New System.Drawing.Size(0, 17)
    Me.LabelProductName.TabIndex = 0
    Me.LabelProductName.Text = "ScreenGrab 2.0"
    Me.LabelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LogoPictureBox
    '
    Me.LogoPictureBox.Image = CType(resources.GetObject("LogoPictureBox.Image"), System.Drawing.Image)
    Me.LogoPictureBox.Location = New System.Drawing.Point(12, 12)
    Me.LogoPictureBox.Name = "LogoPictureBox"
    Me.LogoPictureBox.Size = New System.Drawing.Size(124, 229)
    Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.LogoPictureBox.TabIndex = 1
    Me.LogoPictureBox.TabStop = False
    '
    'LabelCompanyName
    '
    Me.LabelCompanyName.Location = New System.Drawing.Point(142, 110)
    Me.LabelCompanyName.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
    Me.LabelCompanyName.MaximumSize = New System.Drawing.Size(0, 17)
    Me.LabelCompanyName.Name = "LabelCompanyName"
    Me.LabelCompanyName.Size = New System.Drawing.Size(0, 17)
    Me.LabelCompanyName.TabIndex = 3
    Me.LabelCompanyName.Text = "TeamWiki.de"
    Me.LabelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LabelCopyright
    '
    Me.LabelCopyright.Location = New System.Drawing.Point(142, 81)
    Me.LabelCopyright.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
    Me.LabelCopyright.MaximumSize = New System.Drawing.Size(0, 17)
    Me.LabelCopyright.Name = "LabelCopyright"
    Me.LabelCopyright.Size = New System.Drawing.Size(0, 17)
    Me.LabelCopyright.TabIndex = 4
    Me.LabelCopyright.Text = "Copyright (c) 2007 by Max Weller"
    Me.LabelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(144, 14)
    Me.TextBox1.Multiline = True
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.ReadOnly = True
    Me.TextBox1.Size = New System.Drawing.Size(237, 112)
    Me.TextBox1.TabIndex = 5
    Me.TextBox1.Text = "ScreenGrab 2.0" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Version 2.0.0.6" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Copyright © 2007 by Max Weller" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "TeamWiki.d" & _
        "e"
    '
    'AboutBox1
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(396, 254)
    Me.Controls.Add(Me.TextBox1)
    Me.Controls.Add(Me.OKButton)
    Me.Controls.Add(Me.LabelProductName)
    Me.Controls.Add(Me.LabelCopyright)
    Me.Controls.Add(Me.LabelVersion)
    Me.Controls.Add(Me.LabelCompanyName)
    Me.Controls.Add(Me.LogoPictureBox)
    Me.Controls.Add(Me.LinkLabel1)
    Me.Controls.Add(Me.LinkLabel2)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "AboutBox1"
    Me.Padding = New System.Windows.Forms.Padding(9)
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Info über ScreenGrab 2.0"
    CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
  Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
  Friend WithEvents OKButton As System.Windows.Forms.Button
  Friend WithEvents LabelVersion As System.Windows.Forms.Label
  Friend WithEvents LabelProductName As System.Windows.Forms.Label
  Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
  Friend WithEvents LabelCompanyName As System.Windows.Forms.Label
  Friend WithEvents LabelCopyright As System.Windows.Forms.Label
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox

End Class
