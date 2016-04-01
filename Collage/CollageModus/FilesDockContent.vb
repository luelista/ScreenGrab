Imports System.IO

Public Class FilesDockContent

  Private Sub FilesDockContent_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    btnNav01.Text = IO.Path.GetFileName(Program.glob.para("frm_mdiViewer2__quickNavBtn__btnNav01"))
    btnNav02.Text = IO.Path.GetFileName(Program.glob.para("frm_mdiViewer2__quickNavBtn__btnNav02"))
    btnNav03.Text = IO.Path.GetFileName(Program.glob.para("frm_mdiViewer2__quickNavBtn__btnNav03"))
    btnNav04.Text = IO.Path.GetFileName(Program.glob.para("frm_mdiViewer2__quickNavBtn__btnNav04"))

    cmbPath.Text = Program.glob.para("frm_mdiViewer2__folderSel", Environment.GetFolderPath(Environment.SpecialFolder.MyPictures))
  End Sub

  Sub loadDirList()
    imlLarge.Images.Clear() : imlSmall.Images.Clear() : ListView1.Items.Clear()
    Try
      Dim dirInfo As New DirectoryInfo(cmbPath.Text)
      Dim files() As FileSystemInfo = dirInfo.GetFileSystemInfos()
      For Each fsi In files
        Dim item = ListView1.Items.Add(fsi.Name)
        item.Tag = fsi
        loadIcon(fsi)
        item.ImageKey = fsi.FullName

        Dim file As FileInfo = TryCast(fsi, FileInfo)

        If file IsNot Nothing Then
          item.SubItems.Add(file.Length)
          item.SubItems.Add(file.LastWriteTime.ToString("yyyy-MM-dd"))
        End If

      Next
    Catch ex As FileNotFoundException

    Catch ex As Exception
      MsgBox(ex.Message,MsgBoxStyle.Exclamation,"Fehler")
    End Try
  End Sub

  Sub loadIcon(file As FileSystemInfo)
    If ListView1.View = View.LargeIcon Then
      Dim bmp As New Bitmap(imlLarge.ImageSize.Width, imlLarge.ImageSize.Height)
      Using g = Graphics.FromImage(bmp)
        g.FillRectangle(Brushes.White, 0, 0, bmp.Width, bmp.Height)
        g.DrawRectangle(Pens.LightGray, 0, 0, bmp.Width - 1, bmp.Height - 1)
        Dim ext As String = Path.GetExtension(file.Name).ToUpper()
        If ext = ".BMP" Or ext = ".JPG" Or ext = ".PNG" Or ext = ".GIF" Then
          Using i = Image.FromFile(file.FullName)
            Dim x, y As Single
            GetRealXY(i.Width - 2, i.Height - 2, bmp.Width, bmp.Height, x, y)
            ' Dim thumb = i.GetThumbnailImage(x, y, Nothing, IntPtr.Zero)
            g.DrawImage(i, (bmp.Width - x) / 2 + 1, (bmp.Height - y) / 2 + 1, x, y)
          End Using
        Else
          Using i = GetAssociatedIcon(file.FullName)
            g.DrawIcon(i, (bmp.Width - i.Width) / 2 + 1, (bmp.Height - i.Height) / 2 + 1)
          End Using
        End If
      End Using
      imlLarge.Images.Add(file.FullName, bmp)
    Else
      imlSmall.Images.Add(file.FullName, GetAssociatedIcon(file.FullName, assoc_iconSize.SHGFI_SMALLICON))
    End If
  End Sub

  Private Shared Sub GetRealXY(imgX As Single, imgY As Single, targetX As Single, targetY As Single, ByRef realX As Single, ByRef realY As Single)
    Dim xScale As Single = imgX / targetX
    Dim yScale As Single = imgY / targetY

    ' Do not enlarge image
    If yScale < 1 Then
      yScale = 1
    End If
    If xScale < 1 Then
      xScale = 1
    End If

    If yScale > xScale Then
      ' Image has to be shrinked based on height
      realX = imgX * 1 / yScale
      realY = imgY * 1 / yScale
    Else
      ' xScale &gt; yScale // Image has to be shrinked based on width
      realX = imgX * 1 / xScale
      realY = imgY * 1 / xScale
    End If
  End Sub

  Function getFSI(lvi As ListViewItem) As FileSystemInfo
    Return CType(lvi.Tag, FileSystemInfo)
  End Function

  Private Sub ListView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDoubleClick
    Dim lvi As ListViewItem = ListView1.GetItemAt(e.X, e.Y)
    If lvi Is Nothing Then Exit Sub
    Dim fsi = getFSI(lvi)
    Dim fileSpecSel As String = fsi.FullName
    If TypeOf fsi Is DirectoryInfo Then
      cmbPath.Text = fileSpecSel
      loadDirList()
    Else
      Dim c = Program.newClient()
      c.vcc.openFile(fileSpecSel)
    End If
  End Sub

  Private Sub ListView1_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles ListView1.ItemDrag
    Dim fileSpecSel As String = getFSI(e.Item).FullName
    Dim datObj As New DataObject("FileDrop", New String() {fileSpecSel})
    ListView1.DoDragDrop(datObj, DragDropEffects.Copy Or DragDropEffects.Link)
  End Sub

  Private Sub Button1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnNav03.MouseUp, btnNav02.MouseUp, btnNav01.MouseUp, btnNav04.MouseUp
    If e.Button = Windows.Forms.MouseButtons.Right Then
      Program.glob.para("frm_mdiViewer2__quickNavBtn__" + sender.name) = cmbPath.Text
      sender.text = IO.Path.GetFileName(cmbPath.Text)
    Else
      cmbPath.Text = Program.glob.para("frm_mdiViewer2__quickNavBtn__" + sender.name)
      loadDirList()
    End If
  End Sub

  Private Sub chkThumbs_CheckedChanged(sender As Object, e As EventArgs) Handles chkThumbs.CheckedChanged
    ListView1.View = If(chkThumbs.Checked, View.LargeIcon, View.Details)
    loadDirList()
  End Sub

  Private Sub cmbPath_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbPath.KeyDown
    If e.KeyCode = Keys.Enter Then
      loadDirList()
    End If
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    cmbPath.Text = Path.GetDirectoryName(cmbPath.Text)
    loadDirList()
  End Sub
End Class