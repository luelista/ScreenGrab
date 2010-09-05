
Class uploadFiles
  Implements IEnumerable, IEnumerable(Of uploadFilesParaItem)
  Class uploadFilesParaItem
    Public fileSpec, folder As String
    Public lvi As ListViewItem
    Function fileName() As String
      Return IO.Path.GetFileName(fileSpec)
    End Function
  End Class

  Dim lst As New List(Of uploadFilesParaItem)
  Sub Add(ByVal localFilespec As String, ByVal folder As String)
    Dim f As New uploadFilesParaItem
    f.fileSpec = localFilespec
    f.folder = folder
    lst.Add(f)
  End Sub

  Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of uploadFilesParaItem) Implements System.Collections.Generic.IEnumerable(Of uploadFilesParaItem).GetEnumerator
    Return lst.GetEnumerator
  End Function

  Public Function GetEnumerator1() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
    Return lst.GetEnumerator
  End Function

  Sub Start()
    Dim frm = getUplForm()
    frm.WorkingItems += 1
    frm.Show()
    frm.Activate()
    For Each fn In lst
      frm.ImageList1.Images.Add(fn.fileSpec, Drawing.Icon.ExtractAssociatedIcon(fn.fileSpec))
      fn.lvi = frm.ListView1.Items.Add(fn.fileSpec, fn.fileName, fn.fileSpec)
      fn.lvi.Tag = fn.fileSpec
    Next

    For Each fn In lst
      Dim rErrMes As String

      fn.lvi.SubItems.Add("hochladen ...")
      upload_file(fn.fileSpec, fn.fileName, False, "", fn.folder, rErrMes)

      If rErrMes.StartsWith("OK, ") Then
        fn.lvi.SubItems(1).Text = rErrMes.Substring(3).Trim
      Else
        fn.lvi.SubItems(1).Text = rErrMes
        fn.lvi.SubItems(1).ForeColor = Drawing.Color.Red
      End If
    Next
    frm.WorkingItems -= 1
    frm.Show()
    frm.Activate()
  End Sub
End Class
