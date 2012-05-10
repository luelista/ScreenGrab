<Microsoft.VisualBasic.ComClass()> Public Class scriptHelperObj

  Function AddFile(ByVal name As String) As scriptHelperFile
    Dim f As New scriptHelperFile(name)


    With Form2.TreeView1.Nodes(0).Nodes
      If .ContainsKey(UCase(name)) Then
        Return .Item(UCase(name)).Tag
      Else
        .Add(UCase(name), name).Tag = f
        Return f
      End If
    End With

  End Function

  'Function MsgBox(ByVal prompt As String, Optional ByVal options As MsgBoxStyle = MsgBoxStyle.OkOnly, Optional ByVal title As String = "")
  '  Microsoft.VisualBasic.MsgBox(prompt, options, title)
  'End Function

  Function IIF(ByVal q As Boolean, ByVal truePart As Object, ByVal falsePart As Object) As Object
    Return Microsoft.VisualBasic.IIf(q, truePart, falsePart)
  End Function

End Class
<Microsoft.VisualBasic.ComClass()> Public Class scriptHelperFile

  Dim out As New System.Text.StringBuilder
  Dim _fileName As String

  Dim writer As System.IO.StreamWriter

  Friend Sub New(ByVal filename As String)
    _fileName = filename
    writer = New System.IO.StreamWriter("C:\yPara\screengrab5\vumlcg_debug\" + filename)
  End Sub

  Sub WriteLine(ByVal str As String)
    writer.WriteLine(str)
    writer.Flush()
    out.AppendLine(str)
  End Sub

  Sub Write(ByVal str As String)
    writer.Write(str)
    writer.Flush()
    out.Append(str)
  End Sub

  Public Overrides Function ToString() As String
    Return out.ToString()
  End Function

  ReadOnly Property Filename() As String
    Get
      Return _fileName
    End Get
  End Property

  Sub Delete()
    With Form2.TreeView1.Nodes(0).Nodes
      If .ContainsKey(UCase(_fileName)) Then .RemoveByKey(UCase(_fileName))
    End With
  End Sub

End Class