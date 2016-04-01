Imports net.kvdb.webdav


Public Class CloudSaveDialog

  Dim WithEvents Server As WebDAVClient
  Dim LocalFile As String

  Public Sub init(localFile As String, theServer As WebDAVClient, theFolder As String, theFilename As String)
    Me.Server = theServer
    TextBox2.Text = server.URL.ToString()
    TextBox1.Text = theFolder
    txtDropMeSave.Text =If( theFilename,"").Replace(".html", "")
    Me.LocalFile = localFile
  End Sub

  Private Sub btnDropMeSave_Click(sender As Object, e As EventArgs) Handles btnDropMeSave.Click
    If Not TextBox1.Text.EndsWith("/") Then TextBox1.Text += "/"
    Server.Upload(Me.LocalFile, TextBox1.Text + txtDropMeSave.Text + ".html")
  End Sub

  Sub onSaveDone(statusCode As Integer, state As Object) Handles Server.UploadComplete
    If InvokeRequired Then Me.Invoke(New UploadCompleteDel(AddressOf onSaveDone), statusCode, state) : Return

    DialogResult = DialogResult.OK

  End Sub

End Class