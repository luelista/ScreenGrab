Public Class frm_imgurUploaded

  Public Shared albumList As Hashtable
  Dim hash, picPage As String

  Public Shared Sub DisplayInfo(ByVal para As Hashtable)
    Try
      Dim links As Hashtable = para("links")
      Dim frm As New frm_imgurUploaded
      For Each key As String In links.Keys
        frm.ListView1.Items.Add(key).SubItems.Add(links(key))
      Next
      frm.Text = "Imgur - " + para("image")("name")
      frm.PictureBox1.ImageLocation = links("small_square")
      frm.hash = para("image")("hash")
      frm.picPage = para("links")("imgur_page")
      If glob.para("imgur_account_url") <> "" And glob.para("imgur_token") <> "" Then
        If albumList Is Nothing Then
          Dim authLib As New OAuth.OAuthBase(), normURL, normParams, sig, RESULT As String
          sig = authLib.GenerateSignature(New Uri("http://api.imgur.com/2/account/albums.json"), IMGUR_CONSUMER_KEY, IMGUR_CONSUMER_SECRET, glob.para("imgur_token"), glob.para("imgur_token_secret"), "GET", authLib.GenerateTimeStamp(), authLib.GenerateNonce(), OAuth.OAuthBase.SignatureTypes.HMACSHA1, normURL, normParams)
          RESULT = TwAjax.getUrlContent(normURL + "?" + normParams + "&oauth_signature=" + sig)
          albumList = JSON.JsonDecode(RESULT)
        End If
        For Each album As Hashtable In albumList("albums")
          frm.lstAlbums.Items.Add(album("title"))
        Next
      Else
        frm.lstAlbums.Enabled = False : frm.Label1.Enabled = False
      End If
      frm.Show()
    Catch ex As Exception
      MsgBox("Imgur-Upload hat ungültige Daten zurückgeliefert. Bitte erneut versuchen.")
    End Try
  End Sub

  Private Sub ListView1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDoubleClick
    If ListView1.SelectedItems.Count = 1 Then
      Clipboard.Clear()
      Clipboard.SetText(ListView1.SelectedItems(0).SubItems(1).Text)
    End If
  End Sub

  Private Sub lstAlbums_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles lstAlbums.ItemCheck
    If e.CurrentValue = e.NewValue Then Return
    Dim params As String = ""
    If e.NewValue = CheckState.Checked Then
      params = "add_images=" + hash
    Else
      params = "del_images=" + hash
    End If
    Dim albumId As String = albumList("albums")(e.Index)("id")
    Dim authLib As New OAuth.OAuthBase(), normURL, normParams, sig, RESULT As String
    sig = authLib.GenerateSignature(New Uri("http://api.imgur.com/2/account/albums/" + albumId + ".json"), IMGUR_CONSUMER_KEY, IMGUR_CONSUMER_SECRET, glob.para("imgur_token"), glob.para("imgur_token_secret"), "POST", authLib.GenerateTimeStamp(), authLib.GenerateNonce(), params, OAuth.OAuthBase.SignatureTypes.HMACSHA1, normURL, normParams)
    RESULT = TwAjax.postUrl(normURL + "?" + normParams + "&oauth_signature=" + sig, params)

  End Sub

  Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
    Process.Start(picPage)
  End Sub
End Class