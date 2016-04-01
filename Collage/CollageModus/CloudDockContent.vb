Imports net.kvdb.webdav
Imports ScreenGrab6.HelperLib
Imports ScreenGrab6.Vector

Public Class CloudDockContent

  Public WithEvents theClient As WebDAVClient

  Public Function GetServer() As WebDAVClient
    Return theClient
  End Function
  Public Function GetPath() As String
    Return cmbFolder.Text
  End Function

  Private Sub CloudDockContent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    loadHosts()
  End Sub

  Sub loadHosts()
    cmbServer.Items.Clear()

    For Each item In Program.glob.Keys
      If item.StartsWith("davHosts__") Then
        Dim dc As New WebDAVClient
        Dim content = Split(Program.glob.para(item), "|||")
        dc.ConnectionName = content(0)
        dc.URL = New Uri(content(1))
        dc.User = content(2)
        dc.Pass = content(3)
        cmbServer.Items.Add(dc)
      End If
    Next
    cmbServer.Items.Add("Neuer Server ...")
  End Sub
  Sub saveHosts()
    Program.glob.DeleteParaGroup("davHosts__")
    Dim i As Integer = 1
    For Each item In cmbServer.Items
      If TypeOf item Is WebDAVClient Then
        Dim dc As WebDAVClient = CType(item, WebDAVClient)
        Program.glob.para("davHosts__" + i.ToString()) = dc.ConnectionName + "|||" +
          dc.URL.ToString() + "|||" + dc.User + "|||" + dc.Pass
        i = i + 1
      End If
    Next
  End Sub

  Private Sub cmbServer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbServer.SelectedIndexChanged
    If cmbServer.SelectedIndex < 0 Then Return
    If TypeOf cmbServer.SelectedItem Is String Then
      ' Neuer Server
      Dim d As New WebDavConnectionDialog
      If d.ShowDialog() = DialogResult.OK Then
        cmbServer.Items.Insert(cmbServer.Items.Count - 1, d.Client)
        cmbServer.SelectedIndex = cmbServer.Items.Count - 2
        saveHosts()
        Program.glob.saveParaFile()
      Else
        cmbServer.SelectedIndex = -1
      End If
    ElseIf TypeOf cmbServer.SelectedItem Is WebDAVClient Then
      theClient = CType(cmbServer.SelectedItem, WebDAVClient)
      ListView1.Items.Clear()
      cmbFolder.Text = "/"
      theClient.List(cmbFolder.Text)
    End If
  End Sub

  Sub onListLoaded(files As List(Of Item), statusCode As Integer) Handles theClient.ListComplete
    If InvokeRequired Then
      Invoke(New ListCompleteDel(AddressOf onListLoaded), files, statusCode)
      Return
    End If
    ListView1.Items.Clear()
    For Each file In files
      Dim item = ListView1.Items.Add(file.DisplayName)
      item.ImageKey = If(file.IsCollection, "dir", "file")
      item.SubItems.Add(file.ContentLength.ToString())
      item.SubItems.Add(file.LastModified.ToString())
      item.SubItems.Add(file.ContentType)
      item.SubItems.Add(If(file.IsHidden, "Hidden ", ""))
      item.SubItems.Add(file.CreationDate.ToString())
      item.SubItems.Add(file.Etag)


      item.Tag = file
    Next
  End Sub
  Sub onDownloaded(statusCode As Integer, userState As Object, remoteFilePath As String, localFilePath As String) Handles theClient.DownloadComplete
    If InvokeRequired Then
      Invoke(New DownloadCompleteDel(AddressOf onDownloaded), statusCode, userState, remoteFilePath, localFilePath)
      Return
    End If

    If userState = False Then
      Process.Start("explorer.exe", "/e,/select,""" + localFilePath + """")
      Return
    End If

    Dim img As Image
    Try
      img = LoadImage(localFilePath)

      Dim vcc = Program.vcc()
      If vcc Is Nothing Then
        vcc = Program.newClient().vcc
      End If
      Dim obj As New VImage()
      obj.name = "img_" + IO.Path.GetFileName(localFilePath) + "_" + Now.Ticks.ToString
      obj.img = img
      obj.source = "FILE:" + localFilePath
      obj.bounds = New Rectangle(100, 100, obj.img.Width, obj.img.Height)
      'obj.setBorder(2, Color.RoyalBlue)
      vcc.canvas.addObject(obj)

    Catch ex As Exception

      Dim c = Program.newClient()
      c.remoteServer = theClient
      c.remotePath = cmbFolder.Text
      c.remoteFilename = IO.Path.GetFileNameWithoutExtension(remoteFilePath)
      c.vcc.openFile(localFilePath)

    End Try


  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    Dim d As New WebDavConnectionDialog
    d.Client = theClient
    If d.ShowDialog() = DialogResult.OK Then
      saveHosts()
      Program.glob.saveParaFile()
    End If
  End Sub

  Private Sub ListView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDoubleClick
    If cmbFolder.Text.EndsWith("/") = False Then cmbFolder.Text += "/"
    Dim item As ListViewItem = ListView1.GetItemAt(e.X, e.Y)
    If item Is Nothing Then Return
    If item.ImageKey = "dir" Then
      cmbFolder.Text += item.Text + "/"
      theClient.List(cmbFolder.Text)
    Else
      Dim tempFilename As String = IO.Path.GetTempFileName()
      theClient.Download(cmbFolder.Text + item.Text, tempFilename, True)
    End If
  End Sub
  Private Sub LoeschenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoeschenToolStripMenuItem.Click
    If MsgBox("Datei " + contextItem.Href + " löschen?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
      theClient.Delete(contextItem.Href)
    End If
  End Sub
  Private Sub HerunterladenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HerunterladenToolStripMenuItem.Click
    Using sfd As New SaveFileDialog()
      sfd.FileName = contextItem.DisplayName
      If sfd.ShowDialog() = DialogResult.OK Then
        theClient.Download(contextItem.Href, sfd.FileName, False)
      End If
    End Using
  End Sub

  Dim contextItem As Item
  Private Sub ListView1_MouseUp(sender As Object, e As MouseEventArgs) Handles ListView1.MouseUp
    If e.Button = MouseButtons.Right Then
      Dim item As ListViewItem = ListView1.GetItemAt(e.X, e.Y)
      If item Is Nothing Then Return
      contextItem = TryCast(item.Tag, Item)
      If contextItem Is Nothing Then Return
      ContextMenuStrip1.Show(sender, e.X, e.Y)
    End If
  End Sub

  Private Sub cmbFolder_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbFolder.KeyPress
    If e.KeyChar = vbCr Then
      theClient.List(cmbFolder.Text)
    End If
  End Sub

End Class