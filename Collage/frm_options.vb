Public Class frm_options

  Dim skipMultiuplEvents As Boolean = False
  Dim imgurToken, imgurTokenSecret As String

  Property confpage() As Integer
    Get
      Return Me.TabControl1.SelectedIndex
    End Get
    Set(ByVal page As Integer)
      Me.Show()
      Me.Activate()
      Me.TabControl1.SelectedIndex = page
    End Set
  End Property

  Private Sub frm_widgetMan_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    saveSettings()

  End Sub


  Sub saveSettings()
    Program.glob.saveTuttiFrutti(Me)
  End Sub


  Private Sub frm_widgetMan_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
    If e.KeyCode = Keys.Escape Then
      e.SuppressKeyPress = True
      If TabControl1.SelectedTab.Text = "TabPage1" Then
        Me.Close()
      Else
        Me.confpage = 0
      End If
    End If
  End Sub


  Private Sub frm_widgetMan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Program.glob.readFormPos(Me) ', False)

    Show()
    Application.DoEvents()

    Program.glob.readTuttiFrutti(Me)
  End Sub


  Private Sub ButtonListBar1_ItemClick(ByVal sender As Object, ByVal eventArgs As ButtonListbar.vbAccelerator.Controls.ListBar.ItemClickEventArgs)
    Dim idx As Integer
    idx = eventArgs.Item.IconIndex
    TabControl1.SelectedIndex = idx
  End Sub


  Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
    Application.DoEvents()
    Select Case TabControl1.SelectedIndex
      Case 1
        'If igInstalled.Rows.Count = 0 Then initInstalledList(True)
      Case 2
        'labDownloadInfo.Text = "Updates suchen ..."
        'checkForGadgetUpdate()
      Case 3

    End Select
  End Sub


  Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
    saveSettings()
    Close()
  End Sub


  Public Sub New()

    ' This call is required by the Windows Form Designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.

    '.......................  TabControl1.Top = -22

  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    saveSettings()

  End Sub

  Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Program.glob.saveTuttiFrutti(Me)
  End Sub

  Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    Process.Start("https://www.facebook.com/apps/application.php?id=109707115775453&sk=wall")
  End Sub

  Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    Process.Start("http://dropme.de/?source=sg_settings_reglink")
  End Sub

End Class