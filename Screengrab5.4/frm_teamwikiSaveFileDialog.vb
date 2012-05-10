Public Class frm_teamwikiSaveFileDialog

  Property Description() As String
    Get
      Return lblDesc.Text
    End Get
    Set(ByVal value As String)
      lblDesc.Text = value
    End Set
  End Property

  Property FileName() As String
    Get
      Return cmbFilename.Text
    End Get
    Set(ByVal value As String)
      cmbFilename.Text = value
    End Set
  End Property

  Property FileSpec() As String
    Get
      Return glob.fpUNIX(twftv.SelectedNode.Tag(0), cmbFilename.Text)
    End Get
    Set(ByVal value As String)

    End Set
  End Property

  Property InitialDirectory() As String
    Get
      Return twftv.SelectedNode.Tag(0)
    End Get
    Set(ByVal value As String)
      Dim nod = twftv.Nodes.Find(value, True)
      If nod.Length >= 1 Then twftv.SelectedNode = nod(0)
    End Set
  End Property

  Private Sub frm_teamwikiSaveFileDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    
  End Sub

  Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
    If twftv.SelectedNode Is Nothing Then
      MsgBox("Bitte wähle einen Ordner aus.") : Exit Sub
    End If
    If cmbFilename.Text = "" Then
      MsgBox("Bitte gib einen Dateinamen ein.") : Exit Sub
    End If

    Me.DialogResult = Windows.Forms.DialogResult.OK

    glob.para("teamwikiSaveFileDlg__initialDir") = InitialDirectory

    glob.para("teamwikiSaveFileDlg__lastFileName") = CheckForNumbersAndIncrement(FileName)
  End Sub

  Function CheckForNumbersAndIncrement(ByVal str As String) As String
    Dim abPos = -1, bisPos = -1, i As Integer
    For i = 0 To str.Length - 1
      If Char.IsDigit(str.Chars(i)) Then
        abPos = i
      End If
      If abPos >= 0 And Char.IsDigit(str.Chars(i)) = False Then
        bisPos = i - 1
      End If
    Next
    If abPos = -1 Then Return str
    If abPos >= 0 And bisPos = -1 Then bisPos = str.Length - 1

    Dim nums = str.Substring(abPos, bisPos - abPos)
    nums = CStr(CInt(nums) + 1)
    nums = StrDup(bisPos - abPos - nums.Length, "0") + nums

    Mid(str, abPos, bisPos - abPos) = nums
    Return str
  End Function

  Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
    Me.DialogResult = Windows.Forms.DialogResult.Cancel

    glob.para("teamwikiSaveFileDlg__initialDir") = InitialDirectory
    glob.para("teamwikiSaveFileDlg__lastFileName") = FileName
  End Sub

  Public Sub New()

    ' This call is required by the Windows Form Designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.

    twftv.TeamWikiSessionID = twSessID
    twftv.RefreshTree()
    If twftv.SelectedNode Is Nothing Then
      InitialDirectory = glob.para("teamwikiSaveFileDlg__initialDir")
    End If
    If FileName = "" Then
      FileName = glob.para("teamwikiSaveFileDlg__lastFileName")
    End If
  End Sub
End Class