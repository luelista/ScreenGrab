Imports System.Windows.Forms
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Net.Sockets
Imports System.Drawing
Imports System.Management

Module app_mjpegServer

  Dim minX, minY, maxX, maxY, gesamtXX, gesamtYY As Integer

  Dim sock As Sockets.Socket

  Dim remoteEP As IPEndPoint
  Dim requestFilespec As String
  Dim queryString As String
  Dim recvData As String, recvLen As Integer

  Dim stopListening As Boolean = False
  Dim FormRef As Object

  Dim serverName As String = "Server: screengrab-live-server/" + My.Application.Info.Version.ToString
  Dim wwwRoot As String = "C:/yPara/ScreenGrab5/www/"
  Dim bindToIP As String = getIPAddress() '"192.168.178.27"
  Dim bindToPort As Integer = 8080

  Dim session As New System.Collections.Generic.Dictionary(Of String, String)

  Dim th As Thread

  Property MJPEGListenerActive() As Boolean
    Get
      If th IsNot Nothing AndAlso th.IsAlive Then Return True
    End Get
    Set(ByVal value As Boolean)
      If value Then
        If th Is Nothing OrElse th.IsAlive = False Then
          th = New Thread(AddressOf listenerThread)
          th.Start()
          getScreensizes()
        End If
      Else
        If th IsNot Nothing AndAlso th.IsAlive Then
          th.Abort()
          th = Nothing
        End If
      End If
      stopListening = Not value
    End Set
  End Property

  Delegate Sub dAppendLog(ByVal str As String)
  Sub AppendLog(ByVal str As String)
    If frm_options.InvokeRequired Then
      frm_options.Invoke(New dAppendLog(AddressOf AppendLog), str)
    Else
      frm_options.ListBox1.Items.Add(str)
    End If
  End Sub

  Sub listenerThread()
    Try
      Dim ep = New IPEndPoint(IPAddress.Parse(bindToIP), bindToPort)
      sock = New Sockets.Socket(Sockets.AddressFamily.InterNetwork, Sockets.SocketType.Stream, Sockets.ProtocolType.IP)
      sock.ExclusiveAddressUse = False
      sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ExclusiveAddressUse, False)
      sock.Bind(ep)
      sock.Listen(20)
      MsgBox("Going to listen on IP " + bindToIP + " at port " + bindToPort.ToString + " ...")
      Dim acceptSock As Sockets.Socket
      Dim buf(2048) As Byte
      Dim headerBytes() As Byte
      Do
        acceptSock = sock.Accept()
        remoteEP = acceptSock.RemoteEndPoint
        Dim ip = remoteEP.Address.ToString
        recvData = ""
        requestFilespec = "" : queryString = ""
        ReDim headerBytes(0)
        Do
          recvLen = acceptSock.Receive(buf, 2048, Sockets.SocketFlags.Partial)
          recvData += Encoding.ASCII.GetString(buf, 0, recvLen)
        Loop Until acceptSock.Available = 0 Or recvLen = 0
        Dim lines() = Split(recvData, vbCrLf)

        AppendLog(lines(0))
        If lines(0).StartsWith("GET ") Or lines(0).StartsWith("POST ") Then
          Dim cmd() = Split(lines(0), " ")
          If cmd(1).Contains("?") Then queryString = cmd(1).Substring(cmd(1).IndexOf("?")) : cmd(1) = cmd(1).Substring(0, cmd(1).IndexOf("?"))
          If cmd(1) = "/" Then cmd(1) = "/index.html"
          requestFilespec = wwwRoot + "/" + cmd(1)
          If cmd(1) = "/ScreenShot.jpg" Then
            Dim contentType = "Content-Type: multipart/x-mixed-replace; boundary=--wg45asd98dfa034ga4"
            Dim header = "HTTP/1.0 200 OK" + vbCrLf + contentType + vbCrLf + _
                         serverName + vbCrLf + vbCrLf

            headerBytes = Encoding.ASCII.GetBytes(header)
            acceptSock.Send(headerBytes)

            Dim del As New ParameterizedThreadStart(AddressOf motionStreamThread)
            Dim th As New Thread(del)
            th.Start(acceptSock)

            Continue Do 'nicht socket schließen!
          ElseIf cmd(1) = "/index.html" Then
            Dim header = "HTTP/1.0 200 OK" + vbCrLf + serverName + vbCrLf + "Content-Type: text/html" + vbCrLf + vbCrLf + _
                         "<html><head><title>Screenshot</title>" + _
                         "<style> @import url(/style.css); </style></head><body>" + _
                         "<div id='Header'><h2>ScreenGrab " + My.Application.Info.Version.ToString(2) + " Livestream Server</h2></div>" + _
                         "<div id='Content'><img src=""/ScreenShot.jpg"" /></div>" + _
                         "<div id='Footer'>" + glob.para("frm_options__txtLSFooter", "Footer-Text kann in den Einstellungen bearbeitet werden.") + "</div>" + _
                         "</body></html>"

            headerBytes = Encoding.ASCII.GetBytes(header)
            acceptSock.Send(headerBytes)

          ElseIf cmd(1) = "/style.css" Then
            Dim header = "HTTP/1.0 200 OK" + vbCrLf + serverName + vbCrLf + "Content-Type: text/css" + vbCrLf + vbCrLf + _
                         "/* STYLE-SHEET */" + vbCrLf + _
                         "#Header { padding: 10px 100px; border-bottom: 1px solid #333; background-color: #77f; }" + _
                         "html,body { margin: 0; padding: 0; font: 10pt 'Segoe UI',sans-serif; }" + _
                         "#Content { padding: 10px; text-align: center; }" + _
                         "#Content IMG { border: 3px outset #666; }" + _
                         "#Footer { padding: 10px 100px; color: #555; border-top: 1px solid #999; }"

            headerBytes = Encoding.ASCII.GetBytes(header)
            acceptSock.Send(headerBytes)

          Else
            Dim header = "HTTP/1.0 404 Not Found" + vbCrLf + serverName + vbCrLf + vbCrLf + _
                         "<html><head><title>Screenshot</title>" + _
                         "<style> @import url(/style.css); </style></head><body>" + _
                         "<div id='Header'><h2>ScreenGrab " + My.Application.Info.Version.ToString(2) + " Livestream Server</h2></div>" + _
                         "<div id='Content'>FEHLER: Die Seite kann nicht angezeigt werden!</div>" + _
                         "</body></html>"

            headerBytes = Encoding.ASCII.GetBytes(header)
            acceptSock.Send(headerBytes)
          End If
        End If
        acceptSock.Close()
      Loop While stopListening = False
      sock.Close()
    Catch ex As Exception
      MsgBox("Listener thread exited with exception" + vbNewLine + ex.Message, MsgBoxStyle.Critical)
    End Try
  End Sub


  Sub motionStreamThread(ByVal obj)
    Try
      Dim acceptSock As Socket = obj
      While acceptSock.Connected And stopListening = False
        Dim arr() As Byte = getScreenshotAsByteArray()
        acceptSock.Send(Encoding.ASCII.GetBytes(vbCrLf + "--wg45asd98dfa034ga4" + vbCrLf + _
                            "Content-Type: image/jpeg" + vbCrLf + "Content-Length: " + arr.Length.ToString + vbCrLf + vbCrLf))
        acceptSock.Send(arr)
        acceptSock.Send(Encoding.ASCII.GetBytes(vbCrLf + "--wg45asd98dfa034ga4"))
        Threading.Thread.Sleep(500)
      End While
    Catch : End Try
  End Sub

  Sub getScreensizes()
    Dim scr = Screen.AllScreens
    Dim max = scr.Length - 1
    
    For i = 0 To max
      minX = Math.Min(minX, scr(i).Bounds.X)
      minY = Math.Min(minY, scr(i).Bounds.Y)
      maxX = Math.Max(maxX, scr(i).Bounds.Right)
      maxY = Math.Max(maxY, scr(i).Bounds.Bottom)
    Next

    gesamtXX = maxX - minX
    gesamtYY = maxY - minY
  End Sub

  Function getScreenshotAsByteArray() As Byte()
    Dim wdth, hght As Integer
    If Not Integer.TryParse(glob.para("frm_options__txtLSWidth"), wdth) Then wdth = 400
    If Not Integer.TryParse(glob.para("frm_options__txtLSHeight"), hght) Then hght = 400

    Dim bounds As Rectangle
    Dim screenshot As System.Drawing.Bitmap
    Dim graph As Graphics
    bounds = Screen.PrimaryScreen.Bounds
    'screenshot = New System.Drawing.Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb) 
    screenshot = New System.Drawing.Bitmap(wdth, hght, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
    graph = Graphics.FromImage(screenshot)
    Dim xPos = Math.Max(minX, Math.Min(maxX - wdth, Cursor.Position.X - wdth \ 2))
    Dim yPos = Math.Max(minY, Math.Min(maxY - hght, Cursor.Position.Y - hght \ 2))

    'graph.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy) 
    graph.CopyFromScreen(xPos, yPos, 0, 0, New Size(wdth, hght), CopyPixelOperation.SourceCopy)

    If Not String.IsNullOrEmpty(glob.para("frm_options__txtLSInfo")) Then
      graph.DrawString(glob.para("frm_options__txtLSInfo"), New Font("Comic Sans MS", 14, FontStyle.Bold, GraphicsUnit.Point), Brushes.White, 3, 3)
      graph.DrawString(glob.para("frm_options__txtLSInfo"), New Font("Comic Sans MS", 14, FontStyle.Bold, GraphicsUnit.Point), Brushes.Black, 5, 5)
    End If

    Dim ms As New System.IO.MemoryStream()
    screenshot.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)

    getScreenshotAsByteArray = ms.GetBuffer()
    ms.Close() : graph.Dispose() : screenshot.Dispose()
  End Function

  Function getIPAddress() As String
    Dim mc As ManagementClass
    Dim mo As ManagementObject
    Dim out As String = ""
    mc = New ManagementClass("Win32_NetworkAdapterConfiguration")
    Dim moc As ManagementObjectCollection = mc.GetInstances()
    For Each mo In moc
      If mo.Item("IPEnabled") = True Then
        Return mo.Item("IPAddress")(0)

      End If
    Next
  End Function


End Module
