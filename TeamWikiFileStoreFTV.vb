Public Class TeamWikiFileStoreFTV

  Event FolderSelected(ByVal FolderPath As String)


  'http://teamwiki.net/php/vb/grab5.php?c=get_full_tree
  Private _dataURL As String
  Public Property DataSourceURL() As String
    Get
      Return _dataURL
    End Get
    Set(ByVal value As String)
      _dataURL = value
    End Set
  End Property



  Private _twsessid As String
  Public Property TeamWikiSessionID() As String
    Get
      Return _twsessid
    End Get
    Set(ByVal value As String)
      _twsessid = value
    End Set
  End Property


  Sub RefreshTree()
    Dim Data, Lines(), Parts() As String
    Dim indents(10) As TreeNodeCollection, tn As TreeNode
    Data = getUrlContent(DataSourceURL, "twnetSID=" + _twsessid)
    Lines = Split(Data, vbCrLf)
    If checkIfErrorResult(Lines) = False Then Exit Sub

    Me.Nodes.Clear()
    indents(0) = Me.Nodes
    For i = 3 To Lines.Length - 1
      Parts = Split(Lines(i), ":")
      Dim ind As Integer = Val(Parts(1))
      If ind > 9 Then ind = 9 'maximum

      tn = indents(ind).Add(Parts(0), Parts(2))
      tn.Tag = Parts

      setImageForNode(tn)
      indents(ind + 1) = tn.Nodes
    Next
  End Sub

  Private Sub setImageForNode(ByVal tn As TreeNode)
    Dim Data() As String = tn.Tag
    
    If imlSmallIcons.Images.ContainsKey(Data(3)) Then
      tn.ImageKey = Data(3)
      tn.SelectedImageKey = Data(3)
      '  tn.StateImageKey = Data(3)
    Else 'ID_DIR
      tn.ImageKey = "fldclose"
      '  tn.StateImageKey = "fldopen"
    End If

  End Sub

  Function checkIfErrorResult(ByVal LINES() As String) As Boolean
    If LINES.Length < 4 Then MsgBox("Es ist ein Fehler aufgetreten. Der Server hat keine Daten zurückgeliefert.") : Return False
    If LINES(1) <> "" Then MsgBox("Es ist ein Fehler aufgetreten:" + vbNewLine + LINES(1)) : Return False
    Return True
  End Function
  Public Shared Function getUrlContent(ByVal url As String, Optional ByVal cookies As String = "") As String
    Dim xmlhttp As Object = CreateObject("Msxml2.XMLHTTP.3.0") 'MSXML2.ServerXMLHTTP")
    xmlhttp.Open("GET", url, True)
    If cookies <> "" Then xmlhttp.setRequestHeader("Cookie", cookies)
    xmlhttp.send("")

    Dim timer = 0
    While xmlhttp.ReadyState <> 4
      System.Threading.Thread.Sleep(10) 'idle
      Application.DoEvents()
      If timer > 1000 Then xmlhttp = Nothing : Return ""
      timer += 1
    End While

    getUrlContent = xmlhttp.ResponseText
    xmlhttp = Nothing
  End Function

  Public Sub New()

    ' This call is required by the Windows Form Designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.
    Me.PathSeparator = "/"
  End Sub

  Private Sub TeamWikiFileStoreFTV_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles Me.AfterSelect
    RaiseEvent FolderSelected(e.Node.Tag(0))
  End Sub
End Class
