Public Class frm_sidebar

  Public twUsername As String
  Public twPassword As String

  Private Sub tmrSeconds_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrSeconds.Tick
    labFastUplFilename.Text = "Name: " + txtTwUser.Text + "-" + Now().ToString("yyMMdd-HHmmss") + ".png"
  End Sub

  ' create sub for making upload post
  Private Function upload_file(ByVal sourceFile As String, ByVal targetFileName As String, ByVal Para As String) As String

    Dim strPOST As String, Header As String, strBoundary As String, uagent As String
    Dim Idboundary As String   ' id boundary for the site, it may different


    INETPOST.RemoteHost = "www.teamwiki.net"

    Idboundary = "12936540000" & Now.Ticks    ' you can generate this number
    strBoundary = Strings.StrDup(27, "-") & Idboundary     ' mutipart post need "-" sign 

    Header = "User-Agent: Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.7.12) ScreenGrabFileUpload/5.0" & _
             vbCrLf & "Content-Type: multipart/form-data; " & "boundary=" & strBoundary

    strPOST = "--" & strBoundary & vbCrLf
    strPOST &= "Content-Disposition: form-data; name=""extraPara""" & vbCrLf
    strPOST &= vbCrLf & Para
    strPOST &= vbCrLf & "--" & strBoundary & vbCrLf
    strPOST &= "Content-Disposition: form-data; name=""screenshot_file""; filename=""" & targetFileName & """" & vbCrLf
    strPOST &= "Content-Type: application/octet-stream" & vbCrLf
    strPOST &= vbCrLf & IO.File.ReadAllText(sourceFile, System.Text.Encoding.Default)
    strPOST &= vbCrLf & "--" & strBoundary & "--"


    ''  strPOST = "--" & Boundary & vbCrLf & _
    ''  "Content-Disposition: form-data; name=""myfile""" & vbCrLf & vbCrLf & _
    ''  "" & IO.File.ReadAllText(sourceFile) & "" & vbCrLf & _
    ''"--" & Boundary & vbCrLf & _
    ''"Content-Disposition: form-data; name=""upload""" & vbCrLf & vbCrLf & _
    ''"Upload File" & vbCrLf & _
    ''"--" & Boundary & "--" & vbCrLf

    INETPOST.Execute("http://www.teamwiki.net/php/vb/screengrab_upload.php", "POST", strPOST, Header)

    ' Wait untill it finished
    Do Until INETPOST.StillExecuting = False : Application.DoEvents() : Loop
    Return INETPOST.GetHeader("X-Mw-Uploaded-To-URL")
  End Function

  Private Sub frm_sidebar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub

  Private Sub btnFastUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFastUpload.Click
    Dim tempFilespec As String = System.IO.Path.GetTempPath() + "tmpupload.png"
    Dim RES = frm_blueScreen.savePicture(tempFilespec)
    Dim fileName As String = Now().ToString("yyMMdd-HHmmss")
    upload_file(tempFilespec, fileName, "name=" + fileName + "&target=screen-tmp" + "&user=" + txtTwUser.Text + "&pass=" + txtTwPass.Text)
  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

  End Sub

  Private Sub txtTwPass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTwPass.TextChanged

  End Sub
End Class