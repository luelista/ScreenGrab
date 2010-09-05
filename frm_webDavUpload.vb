
Imports System.Net
Imports System.Net.WebRequestMethods

Public Class frm_webDavUpload


  Private Sub Button1_Click(ByVal sender As System.Object, _
                            ByVal e As System.EventArgs) Handles Button1.Click

    UploadFile()

  End Sub


  Public Sub UploadFile()

    'C:  The first thing we can do is get the path of the file, and it's length.

    Dim fileToUpload As String = Me.txtFileToUpload.Text.Trim()
    Dim fileLength As Long = My.Computer.FileSystem.GetFileInfo(fileToUpload).Length



    'C:  Next, get our URL and port, and then combine them if a port was provided.

    Dim url As String = Me.txtUrl.Text.Trim()
    Dim port As String = Me.txtPort.Text.Trim()

    'If the port was provided, then insert it into the url.
    If port <> "" Then

      'Insert the port into the Url
      'https://www.example.com:80/directory
      Dim u As New Uri(url)

      'Get the host (example: www.example.com)
      Dim host As String = u.Host

      'Replace the host with the host:port
      url = url.Replace(host, host & ":" & port)

    End If



    'C:  Add the name of the file we are uploading to the end of the url
    '    This creates a "target" file name

    url = url.TrimEnd("/"c) & "/" & IO.Path.GetFileName(fileToUpload)



    'C:  Request a stream from the WebDAV server for the file we want to upload.

    'Create the request
    Dim request As HttpWebRequest = _
        DirectCast(System.Net.HttpWebRequest.Create(url), HttpWebRequest)

    'Set the User Name and Password
    request.Credentials = New NetworkCredential(Me.txtUserName.Text.Trim(), Me.txtPassword.Text.Trim())

    'Let the server know we want to "put" a file on it
    request.Method = WebRequestMethods.Http.Put

    'Set the length of the content (file) we are sending
    request.ContentLength = fileLength


    '*** This is required for our WebDav server ***
    request.SendChunked = True
    request.Headers.Add("Translate: f")
    request.AllowWriteStreamBuffering = True


    Dim s As IO.Stream = Nothing

    Try
      'Send the request to the server, and get the 
      '  server's (file) Stream in return.
      s = request.GetRequestStream()

    Catch ex As Exception

      MessageBox.Show("An error occurred while attempting to connect to the remote server.  " & _
                          "The following error occurred while attempting to connect:" & vbCrLf & _
                          vbCrLf & ex.Message)

    End Try



    'C:  After the server has given us a stream, we can begin to write to it.
    '
    '    Note:  The data is not actually being sent to the server
    '    here, it is written to a stream in memory.
    '    The data is actually sent below when the Response is retrieved
    '    from the server.


    'Open the file so we can read the data from it
    Dim fs As New IO.FileStream(fileToUpload, IO.FileMode.Open, IO.FileAccess.Read)

    'Create the buffer for storing the bytes read from the file
    Dim byteTransferRate As Integer = 1024
    Dim bytes(byteTransferRate - 1) As Byte
    Dim bytesRead As Integer = 0
    Dim totalBytesRead As Long = 0

    'Configure the ProgressBar
    pb.Minimum = 0
    pb.Maximum = CInt(fileLength \ byteTransferRate)
    pb.Value = 0

    'Read from the file and write it to the server's stream.
    Do
      'Read from the file
      bytesRead = fs.Read(bytes, 0, bytes.Length)

      If bytesRead > 0 Then

        totalBytesRead += bytesRead

        'Write to stream
        s.Write(bytes, 0, bytesRead)

        'Update progress
        pb.Value = CInt(totalBytesRead \ byteTransferRate)

        If pb.Value Mod 500 = 0 Then _
            Application.DoEvents()

      End If

    Loop While bytesRead > 0

    'Close the server stream
    s.Close()
    s.Dispose()
    s = Nothing

    'Close the file
    fs.Close()
    fs.Dispose()
    fs = Nothing



    'C:  Although we have finished writing the file to the stream, the file
    '    has not been uploaded yet.  If we exited here without continuing,
    '    the file would not be uploaded.



    'C:  Now we have to send the data to the server

    Dim response As HttpWebResponse = Nothing

    Try
      '***  Send the data to the server
      '  Note:  When we get the response from the server, we
      '  are actually sending the data to the server, and receiving
      '  the server's response to it in return.
      '
      '  If we did not perform this step, the file would not be uploaded.
      response = DirectCast(request.GetResponse(), HttpWebResponse)



      'C:  Finally, after we have uploaded the file, perform a little 
      '    validation just to make sure everything worked as expected.

      'Get the StatusCode from the server's Response
      Dim code As HttpStatusCode = response.StatusCode

      'Close the response
      response.Close()
      response = Nothing

      'Validate the uploaded file:
      '  Check the totalBytesRead and the fileLength.  Both must be an exact match.
      '
      '  Check the StatusCode from the server and make sure the file was "Created"
      '    Note:  There are many different possible status codes.  You can choose
      '    which ones you want to test for by looking at the "HttpStatusCode" enumerator.
      If totalBytesRead = fileLength AndAlso _
          code = HttpStatusCode.Created Then

        MessageBox.Show("The file has uploaded successfully!", "Uploade Complete", _
                        MessageBoxButtons.OK, MessageBoxIcon.Information)

      Else

        MessageBox.Show("The file did not upload successfully.", _
                        "Upload failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)

      End If

    Catch ex As Exception

      MessageBox.Show("An error occurred while attempting to Upload the file.  " & _
                      "The specific error message is:  " & vbCrLf & vbCrLf & ex.Message)

    End Try

  End Sub


#Region " Misc"

  Private Sub Panel1_Paint(ByVal sender As System.Object, _
                           ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint

    Dim linGrBrush As New System.Drawing.Drawing2D.LinearGradientBrush( _
        New Point(0, 0), _
        New Point(Me.PictureBox1.Width, 0), _
        Drawing.Color.Silver, Color.White)

    'Create 2 single variable arrays to store the Blend Factors and Blend Positions
    Dim relativeIntensities As Single() = {0.0F, 0.0F, 1.0F}
    Dim relativePositions As Single() = {0.0F, 0.3F, 1.0F}  '{0.0F, 0.2F, 1.0F}

    'Create a blend and set it's factors and positions to the variable arrays created above.
    Dim blend As New System.Drawing.Drawing2D.Blend()
    blend.Factors = relativeIntensities
    blend.Positions = relativePositions

    'Set the blend we created to the LinearGradientBrush.Blend property
    linGrBrush.Blend = blend

    'Fill the OMSBar (Panel1) background with the colors we configured above.
    e.Graphics.FillRectangle(linGrBrush, 0, 0, Me.PictureBox1.Width, Me.PictureBox1.Height)

  End Sub

#End Region  'Misc

End Class
