Imports System.Net, System.Net.Sockets
Imports InetCtlsObjects

Module sys_uploadWithPost
  'Dim WithEvents inetPost As Inet
  Public uploadWithPost_HOST As String = "teamwiki.net"
  Public uploadWithPost_PATH As String = "/php/vb/grab5.php?c=upload_file"
  Public twLoginuser, twLoginPass, mtwLoginFullname, twSessID As String
  Public kData() As Byte = {154, 15, 7, 238, 9, 165, 234, 56, 74, 235, 4, 89, 34, 65, 2, 79, 17, 51, 86, 3, 8, 14, 9, 57, 23, 4, 52, 3, 5, 5, 4, 145, 166, 83, 47, 146}
  Public twLoginfbuid As Integer

  'Public Property twLoginFullname() As String
  '  Get
  '    Return mtwLoginFullname
  '  End Get
  '  Set(ByVal value As String)
  '    mtwLoginFullname = value
  '    GlassControlText(FRM.lblLoginName) = value
  '    If value = "" Then
  '      GlassControlText(FRM.lblLoginMode) = "Offlinemodus"
  '      FRM.Text = "ScreenGrab " + My.Application.Info.Version.ToString(3) + "     [ [  Offline-Modus  ] ]"
  '    Else
  '      GlassControlText(FRM.lblLoginMode) = "TeamWiki Login"
  '      FRM.Text = "ScreenGrab " + My.Application.Info.Version.ToString(3) + "     [ [  Login: " + value + "  ] ]"
  '    End If

  '  End Set
  'End Property

  'Sub destroyInetCtrl()
  '  inetPost.Cancel()
  '  System.Runtime.InteropServices.Marshal.ReleaseComObject(inetPost)
  '  ' inetPost = Nothing
  'End Sub

  Function checkIfErrorResult(ByVal LINES() As String) As Boolean
    If LINES.Length < 4 Then MsgBox("Es ist ein Fehler aufgetreten. Der Server hat keine Daten zurückgeliefert.") : Return False
    If LINES(1) <> "" Then MsgBox("Es ist ein Fehler aufgetreten:" + vbNewLine + LINES(1)) : Return False
    Return True
  End Function

  '  Function onChangeLogin() As Boolean
  '    Dim frm As New LoginForm1
  '    frm.UsernameTextBox.Text = twLoginuser
  '    frm.UsernameTextBox.Focus()
  '    frm.UsernameTextBox.SelectAll()

  'nochmal_versuchen:
  '    If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
  '      Return True
  '    Else
  '      Return False
  '    End If
  '  End Function

  '  Function doLogin(ByVal userName As String, ByVal passWord As String, ByVal showError As Boolean) As Boolean
  '    If userName = OFFLINE_USER Then
  '      twLoginuser = OFFLINE_USER : twLoginPass = "" : twLoginFullname = "" : twSessID = ""
  '      Return True
  '    End If

  '    Dim postData As String = "u=" + userName + "&p=" + passWord
  '    Dim RESULT_String = TwAjax.postUrl("https://secure.teamwiki.net/app_login.php", postData)
  '    Dim success As Boolean
  '    Dim RESULT As Hashtable = JSON.JsonDecode(RESULT_String, success)
  '    If success AndAlso RESULT("status") = True Then
  '      twLoginuser = userName : twLoginPass = passWord : twLoginFullname = RESULT("fullname")
  '      twLoginfbuid = RESULT("facebook_uid")
  '      glob.para("user") = RC4StringEncrypt(userName + ":" + passWord, kData)
  '      twSessID = RESULT("session")
  '      Return True
  '    Else
  '      If success Then
  '        If showError And RESULT("code") = "403" Then MsgBox("Ungültige Login-Daten!", MsgBoxStyle.Exclamation)
  '        If RESULT("code") <> "403" Then MsgBox("Unbekannter Fehler:" + vbNewLine + RESULT("reason"), MsgBoxStyle.Exclamation)
  '      Else
  '        MsgBox("Der Server hat keine Daten zurückgeliefert oder du bist nicht mit dem Internet verbunden!", MsgBoxStyle.Exclamation)
  '      End If
  '      Return False
  '    End If
  '  End Function


  'Sub init_inet(ByVal url As String)
  '  ' inetPost.Protocol = ProtocolConstants.icHTTP
  '  ' inetPost.URL = url

  '  ' inetPost.RemoteHost = "mwupd3.teamwiki.net"
  '  'uploadWithPostUrl = url
  'End Sub

  '  ' create sub for making upload post
  Sub upload_file_oldMSINET(ByVal sourceFilespec As String, ByVal sc_name As String, ByVal use_temp As Boolean, ByVal fs_team As String, ByVal fs_dir As String, ByRef errMes As String)
    Dim try_again_count = 0

    Dim myInet As Inet = New Inet()
try_again:
    try_again_count += 1
    Application.DoEvents()

    'myInet.Cancel()
    Debug.Print(myInet.StillExecuting) 'errMes = "ERROR, inetStillExecuting" ': Exit Sub

    Dim strPOST As String = "", Header As String, strBoundary As String, uagent As String
    Dim Idboundary As String   ' id boundary for the site, it may different

    Idboundary = "8998162483566" & Now.Ticks    ' you can generate this number
    strBoundary = Strings.StrDup(27, "-") & Idboundary     ' mutipart post need "-" sign 

    Header = "User-Agent: Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.7.12) MWupd/3.0" & _
             vbCrLf & "Content-Type: multipart/form-data; " & "boundary=" & strBoundary & _
             vbCrLf & "Cookie : twnetSID=" & twSessID & "; "
    'ACHTUNG: Cookie mit Lücke wird benutzt um INET-Control reinzulegen, sonst
    'überschreibt er meine Cookies mit irgendwelchen uralten aus dem Cache

    'strPOST = Header & vbCrLf & vbCrLf
    strPOST &= "--" & strBoundary & vbCrLf
    strPOST &= "Content-Disposition: form-data; name=""sc_name""" & vbCrLf
    strPOST &= vbCrLf & sc_name
    strPOST &= vbCrLf & "--" & strBoundary & vbCrLf
    strPOST &= "Content-Disposition: form-data; name=""use_temp""" & vbCrLf
    strPOST &= vbCrLf & use_temp.ToString
    strPOST &= vbCrLf & "--" & strBoundary & vbCrLf
    strPOST &= "Content-Disposition: form-data; name=""fs_team""" & vbCrLf
    strPOST &= vbCrLf & fs_team
    strPOST &= vbCrLf & "--" & strBoundary & vbCrLf
    strPOST &= "Content-Disposition: form-data; name=""fs_dir""" & vbCrLf
    strPOST &= vbCrLf & fs_dir
    strPOST &= vbCrLf & "--" & strBoundary & vbCrLf
    strPOST &= "Content-Disposition: form-data; name=""screenshot_file""; filename=""screenshot.png""" & vbCrLf
    strPOST &= "Content-Type: application/octet-stream" & vbCrLf
    strPOST &= vbCrLf & IO.File.ReadAllText(sourceFilespec, System.Text.Encoding.Default)
    strPOST &= vbCrLf & "--" & strBoundary & "--"


    Try

      myInet.Execute("http://" + uploadWithPost_HOST + uploadWithPost_PATH, "POST", strPOST, Header)

    Catch ex As Exception
      Debug.Print("Fehler beim Start des Uploads ... (Bug im MSINET-Control)" & try_again_count & ". Versuch")
      'If MsgBox("Fehler beim Start des Uploads ... (Bug im MSINET-Control)" + vbNewLine + vbNewLine + ex.Message, MsgBoxStyle.RetryCancel) = MsgBoxResult.Retry Then
      myInet = New Inet()
      Application.DoEvents()
      Threading.Thread.Sleep(11)
      Application.DoEvents()
      If try_again_count > 5 Then
        MsgBox("Fehler beim Start des Uploads ... (Bug im MSINET-Control)" & vbNewLine & try_again_count & ". Versuch")
        Stop

      End If
      GoTo try_again
      'End If
    End Try
    ' Wait until it finished
    Do Until myInet.StillExecuting = False
      Application.DoEvents()
      Threading.Thread.Sleep(10)

    Loop

    Debug.Print("Header: " & myInet.GetHeader)
    Try
      errMes = myInet.GetHeader("X-Grab5-Result")
    Catch ex As Exception
      errMes = "ERROR, HEADER-DOESNT-EXIST"
    End Try

    myInet.Cancel()
    myInet = Nothing
  End Sub

  '' create sub for making upload post
  'Sub upload_file_SOCKET(ByVal sourceFilespec As String, ByVal sc_name As String, ByVal use_temp As Boolean, ByVal fs_team As String, ByVal fs_dir As String, ByRef errMes As String)

  '  Dim strPOST As New System.Text.StringBuilder, Header As String, strBoundary As String, uagent As String
  '  Dim Idboundary As String   ' id boundary for the site, it may different

  '  Idboundary = "8998162483566" & Now.Ticks    ' you can generate this number
  '  strBoundary = Strings.StrDup(27, "-") & Idboundary     ' mutipart post need "-" sign 

  '  Header = "POST " & uploadWithPost_PATH & " HTTP/1.1" & _
  '           vbCrLf & "Accept: */*" & _
  '           vbCrLf & "Host: " & uploadWithPost_HOST & _
  '           vbCrLf & "Pragma: no-cache" & _
  '           vbCrLf & "User-Agent: Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.7.12) MWupd/3.0" & _
  '           vbCrLf & "Content-Type: multipart/form-data; " & "boundary=" & strBoundary & _
  '           vbCrLf & "Cookie: twnetSID=" & twSessID & "; "

  '  'strPOST = Header & vbCrLf & vbCrLf
  '  strPOST.Append(Header & vbCrLf & vbCrLf)
  '  strPOST.Append("--" & strBoundary & vbCrLf)
  '  strPOST.Append("Content-Disposition: form-data; name=""sc_name""" & vbCrLf)
  '  strPOST.Append(vbCrLf & sc_name)
  '  strPOST.Append(vbCrLf & "--" & strBoundary & vbCrLf)
  '  strPOST.Append("Content-Disposition: form-data; name=""use_temp""" & vbCrLf)
  '  strPOST.Append(vbCrLf & use_temp.ToString)
  '  strPOST.Append(vbCrLf & "--" & strBoundary & vbCrLf)
  '  strPOST.Append("Content-Disposition: form-data; name=""fs_team""" & vbCrLf)
  '  strPOST.Append(vbCrLf & fs_team)
  '  strPOST.Append(vbCrLf & "--" & strBoundary & vbCrLf)
  '  strPOST.Append("Content-Disposition: form-data; name=""fs_dir""" & vbCrLf)
  '  strPOST.Append(vbCrLf & fs_dir)
  '  strPOST.Append(vbCrLf & "--" & strBoundary & vbCrLf)
  '  strPOST.Append("Content-Disposition: form-data; name=""screenshot_file""; filename=""screenshot.png""" & vbCrLf)
  '  strPOST.Append("Content-Type: application/octet-stream" & vbCrLf)
  '  strPOST.Append(vbCrLf)
  '  'strPOST.Append(vbCrLf & IO.File.ReadAllText(sourceFilespec, System.Text.Encoding.Default))
  '  'strPOST.Append(vbCrLf & "--" & strBoundary & "--")


  '  Try
  '    Dim sck As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP)
  '    sck.Connect(uploadWithPost_HOST, 80)

  '    Dim bytes() As Byte

  '    'bytes = System.Text.Encoding.Default.GetBytes(Header)
  '    'sck.Send(bytes)

  '    bytes = System.Text.Encoding.Default.GetBytes(strPOST.ToString)
  '    sck.Send(bytes)

  '    sck.SendFile(sourceFilespec)

  '    bytes = System.Text.Encoding.Default.GetBytes(vbCrLf & "--" & strBoundary & "--")
  '    sck.Send(bytes)

  '    'myInet.Execute(uploadWithPostUrl, "POST", strPOST, Header)

  '    ReDim bytes(1023)
  '    Dim rcpt, offset As Integer
  '    Do
  '      rcpt = sck.Receive(bytes, offset, 1024, SocketFlags.None)
  '      If rcpt = 0 Then Exit Do

  '      offset += rcpt

  '      ReDim Preserve bytes(offset + 1024)
  '    Loop
  '    ReDim Preserve bytes(offset)
  '    sck.Close()

  '    Dim resultString As String = System.Text.Encoding.Default.GetString(bytes)
  '    Dim LINES() = Split(resultString, vbCrLf)
  '    For Each line As String In LINES
  '      If line.StartsWith("X-Grab5-Result:", StringComparison.InvariantCultureIgnoreCase) Then
  '        errMes = line.Substring(15).Trim
  '        Return
  '      End If
  '    Next

  '    errMes = "ERROR, HEADER-DOESNT-EXIST"
  '  Catch ex As Exception
  '    errMes = "ERROR, " + ex.Message
  '  End Try


  'End Sub









  '' create sub for making upload post
  Sub upload_file_NETREQUEST(ByVal sourceFilespec As String, ByVal sc_name As String, ByVal use_temp As Boolean, ByVal fs_team As String, ByVal fs_dir As String, ByRef errMes As String, Optional ByVal sc_ext As String = "")

    '  Dim strPOST As New System.Text.StringBuilder, Header As String, strBoundary As String, uagent As String
    '  Dim Idboundary As String   ' id boundary for the site, it may different

    '  Idboundary = "8998162483566" & Now.Ticks    ' you can generate this number
    '  strBoundary = Strings.StrDup(27, "-") & Idboundary     ' mutipart post need "-" sign 


    '  Try
    '    Dim wrq As HttpWebRequest = HttpWebRequest.Create("http://" + uploadWithPost_HOST + uploadWithPost_PATH)
    '    wrq.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.7.12) MWupd/3.0"
    '    wrq.Method = "POST"
    '    wrq.ContentType = "multipart/form-data; " & "boundary=" & strBoundary
    '    wrq.Headers.Set("Cookie", "twnetSID=" + twSessID)
    '    Dim cred As New NetworkCredential(glob.para("frm_options__txtProxyUN"), glob.para("frm_options__txtProxyPW"))
    '    'cred.Domain = "10.34.0.5" ' glob.para("frm_options__txtProxyDOM")
    '    'Dim proxy As New WebProxy("10.34.0.5", 8080, New String() {}, cred)
    '    'proxy.Credentials = cred
    '    wrq.Credentials = cred
    '    wrq.Proxy.Credentials = cred

    '    'wrq.Proxy = proxy
    '    'wrq.Proxy.Credentials = cred
    '    'wrq.Credentials = cred

    '    Dim str = wrq.GetRequestStream
    '    Dim bytes() As Byte

    '    Dim fieldPart As String = _
    '      "--" & strBoundary & vbCrLf & _
    '      "Content-Disposition: form-data; name=""sc_name""" & vbCrLf & _
    '      vbCrLf & sc_name & _
    '      vbCrLf & "--" & strBoundary & vbCrLf & _
    '      "Content-Disposition: form-data; name=""sc_ext""" & vbCrLf & _
    '      vbCrLf & sc_ext & _
    '      vbCrLf & "--" & strBoundary & vbCrLf & _
    '      "Content-Disposition: form-data; name=""use_temp""" & vbCrLf & _
    '      vbCrLf & use_temp.ToString & _
    '      vbCrLf & "--" & strBoundary & vbCrLf & _
    '      "Content-Disposition: form-data; name=""fs_team""" & vbCrLf & _
    '      vbCrLf & fs_team & _
    '      vbCrLf & "--" & strBoundary & vbCrLf & _
    '      "Content-Disposition: form-data; name=""fs_dir""" & vbCrLf & _
    '      vbCrLf & fs_dir & _
    '      vbCrLf & "--" & strBoundary & vbCrLf & _
    '      "Content-Disposition: form-data; name=""screenshot_file""; filename=""screenshot.png""" & vbCrLf & _
    '      "Content-Type: application/octet-stream" & vbCrLf & vbCrLf
    '    'WICHTIG: Es müssen zwei CRLF sein -- sonst schneidet er den Anfang der Datei ab

    '    bytes = System.Text.Encoding.Default.GetBytes(fieldPart)
    '    str.Write(bytes, 0, bytes.Length)

    '    'read File into Stream
    '    Dim fs As New IO.FileStream(sourceFilespec, IO.FileMode.Open, _
    '                                IO.FileAccess.Read, IO.FileShare.ReadWrite)
    '    Dim fLen As Long = fs.Length
    '    ReDim bytes(fLen)
    '    fs.Read(bytes, 0, fLen)
    '    fs.Close()

    '    str.Write(bytes, 0, fLen)
    '    bytes = Nothing

    '    bytes = System.Text.Encoding.Default.GetBytes(vbCrLf & "--" & strBoundary & "--")
    '    str.Write(bytes, 0, bytes.Length)
    '    str.Close()

    '    Dim wrs = wrq.GetResponse()
    '    errMes = wrs.Headers("X-Grab5-Result")

    '    If errMes = Nothing Then errMes = "ERROR, HEADER-DOESNT-EXIST"

    '  Catch ex As Exception
    '    errMes = "ERROR, " + ex.Message
    '  End Try


  End Sub

  ' create sub for making upload post
  Sub upload_file(ByVal sourceFilespec As String, ByVal sc_name As String, ByVal use_temp As Boolean, ByVal fs_team As String, ByVal fs_dir As String, ByRef errMes As String, Optional ByVal sc_ext As String = "")

    Dim strPOST As New System.Text.StringBuilder, Header As String, strBoundary As String, uagent As String
    Dim Idboundary As String   ' id boundary for the site, it may different

    Idboundary = "8998162483566" & Now.Ticks    ' you can generate this number
    strBoundary = Strings.StrDup(27, "-") & Idboundary     ' mutipart post need "-" sign 


    Try

      

      Dim fieldPart As String = _
        "--" & strBoundary & vbCrLf & _
        "Content-Disposition: form-data; name=""sc_name""" & vbCrLf & _
        vbCrLf & sc_name & _
        vbCrLf & "--" & strBoundary & vbCrLf & _
        "Content-Disposition: form-data; name=""sc_ext""" & vbCrLf & _
        vbCrLf & sc_ext & _
        vbCrLf & "--" & strBoundary & vbCrLf & _
        "Content-Disposition: form-data; name=""use_temp""" & vbCrLf & _
        vbCrLf & use_temp.ToString & _
        vbCrLf & "--" & strBoundary & vbCrLf & _
        "Content-Disposition: form-data; name=""fs_team""" & vbCrLf & _
        vbCrLf & fs_team & _
        vbCrLf & "--" & strBoundary & vbCrLf & _
        "Content-Disposition: form-data; name=""fs_dir""" & vbCrLf & _
        vbCrLf & fs_dir & _
        vbCrLf & "--" & strBoundary & vbCrLf & _
        "Content-Disposition: form-data; name=""screenshot_file""; filename=""screenshot.png""" & vbCrLf & _
        "Content-Type: application/octet-stream" & vbCrLf & vbCrLf & _
        IO.File.ReadAllText(sourceFilespec, System.Text.Encoding.Default) & vbCrLf & vbCrLf & _
      "--" & strBoundary & "--"
      'WICHTIG: Es müssen zwei CRLF sein -- sonst schneidet er den Anfang der Datei ab



      Dim xmlhttp As Object = CreateObject("Msxml2.XMLHTTP.3.0") 'MSXML2.ServerXMLHTTP")
      xmlhttp.Open("POST", "http://" + uploadWithPost_HOST + uploadWithPost_PATH, True)
      xmlhttp.setRequestHeader("Content-Type", "multipart/form-data; " & "boundary=" & strBoundary)
      xmlhttp.setRequestHeader("User-Agent", "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.7.12) MWupd/3.0 ScreenGrab 5.4")
      xmlhttp.setRequestHeader("Cookie", "twnetSID=" + twSessID)
      xmlhttp.send(System.Text.Encoding.Default.GetBytes(fieldPart))



      Dim timer = 0
      While xmlhttp.ReadyState <> 4
        TwAjax.idle()
        If timer > 9000 Then xmlhttp = Nothing : errMes = "ERROR, Timeout" : Return
        timer += 1
      End While


      errMes = xmlhttp.getResponseHeader("X-Grab5-Result")

      If errMes = Nothing Then errMes = "ERROR, HEADER-DOESNT-EXIST"

    Catch ex As Exception
      errMes = "ERROR, " + ex.Message
    End Try


  End Sub

  'Private Sub inetPost_StateChanged(ByVal State As Short) Handles inetPost.StateChanged
  '  Debug.Print("inet State: " & State)
  'End Sub
End Module
