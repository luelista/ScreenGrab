Imports System.IO
Imports System.Drawing.Drawing2D

Public Class frm_options

  Dim skipMultiuplEvents As Boolean = False


  Property confpage() As Integer
    Get
      Return Me.TabControl1.SelectedIndex
    End Get
    Set(ByVal page As Integer)
      Me.Show()
      Me.Activate()
      Me.ButtonListBar1.Items(page).Selected = True
      Me.TabControl1.SelectedIndex = page
    End Set
  End Property

  Private Sub frm_widgetMan_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    saveSettings()
    glob.saveFormPos(Me)
  End Sub


  Sub saveSettings()
    glob.saveTuttiFrutti(Me)


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
    Dim tabs() As String = {"Allgemein", "Sonstige"}

    For i As Integer = 0 To tabs.Length - 1
      ButtonListBar1.Items.Add( _
      New ButtonListbar.vbAccelerator.Controls.ListBar.ButtonListBarItem(tabs(i), i))
    Next

    glob.readFormPos(Me) ', False)

    Show()
    Application.DoEvents()

    glob.readTuttiFrutti(Me)



  End Sub


  Private Sub ButtonListBar1_ItemClick(ByVal sender As Object, ByVal eventArgs As ButtonListbar.vbAccelerator.Controls.ListBar.ItemClickEventArgs) Handles ButtonListBar1.ItemClick
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


  Private Sub btnDefaultFolder_choose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDefaultFolder_choose.Click

    Using f As New FolderBrowserDialog
      f.Description = "Bitte wähle den Ordner aus, in den die Bilder standardmäßig gespeichert werden soll."
      f.SelectedPath = txtDefaultFolder.Text
      If f.ShowDialog = Windows.Forms.DialogResult.OK Then
        txtDefaultFolder.Text = f.SelectedPath
      End If
    End Using
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

  'Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
  '  Dim g = PictureBox2.CreateGraphics
  '  Dim cmbinfo As New COMBOBOXINFO
  '  GetComboBoxInfo(ListBox1.Handle, cmbinfo)

  '  Dim dc = g.GetHdc
  '  SendMessage(ComboBox1.Handle, WindowsMessages.WM_PRINTCLIENT, dc, PRF_CLIENT Or PRF_CHILDREN Or PRF_OWNED)
  '  SendMessage(ListBox1.Handle, WindowsMessages.WM_PRINTCLIENT, dc, PRF_NONCLIENT Or PRF_CLIENT)


  '  g.ReleaseHdc(dc)

  'End Sub

  Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    onChangeLogin()

  End Sub


End Class