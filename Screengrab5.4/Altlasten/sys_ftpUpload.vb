Imports System.Runtime.InteropServices

Module sys_ftpUpload
  Dim ftpHandle As IntPtr
  Dim hInet As IntPtr

  Public Declare Function InternetOpen Lib "wininet.dll" _
   Alias "InternetOpenA" _
  (ByVal lpszAgent As String, _
   ByVal dwAccessType As Integer, _
   ByVal lpszProxyName As IntPtr, _
   ByVal lpszProxyBypass As IntPtr, _
   ByVal dwFlags As Integer) As Integer

  Public Declare Function InternetCloseHandle Lib "wininet.dll" ( _
  ByVal hInet As IntPtr) As Boolean

  Public Declare Auto Function InternetConnect Lib "wininet.dll" ( _
      ByVal hInternetSession As System.IntPtr, _
      ByVal sServerName As String, _
      ByVal nServerPort As Integer, _
      ByVal sUsername As String, _
      ByVal sPassword As String, _
      ByVal lService As Int32, _
      ByVal lFlags As Int32, _
      ByVal lContext As System.IntPtr) As System.IntPtr

  Public Declare Function InternetSetStatusCallback Lib "wininet" _
    (ByVal hInternet As System.IntPtr, _
   <MarshalAs(UnmanagedType.FunctionPtr)> ByVal lpfnInternetCallback As dFtpCallbackStatus) As Long

  'Public Declare Function FtpGetFile Lib "wininet.dll" (ByVal hConnect As IntPtr, _
  '   ByVal remoteFile As String, ByVal newFile As String, _
  '   <MarshalAs(UnmanagedType.Bool)> ByVal failIfExists As Boolean, _
  '   ByVal flagsAndAttributes As Integer, ByVal flags As Integer, _
  '   ByVal context As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
  <DllImport("wininet.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
  Private Function FtpGetFile(ByVal hConnect As IntPtr, ByVal remoteFile As String, ByVal newFile As String, <MarshalAs(UnmanagedType.Bool)> _
  ByVal failIfExists As Boolean, ByVal flagsAndAttributes As Integer, ByVal flags As Integer, _
  ByVal context As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
  End Function

  Public Const INTERNET_OPEN_TYPE_DIRECT = 1                         ' direct to net
  Public Const INTERNET_DEFAULT_FTP_PORT = 21                ' default for FTP servers
  Public Const INTERNET_FLAG_EXISTING_CONNECT = &H20000000   ' FTP: use existing InternetConnect handle for server if possible
  Public Const INTERNET_SERVICE_FTP = 1
  Public Const INTERNET_FLAG_PASSIVE = &H8000000             ' used for FTP connections
  Public Const FTP_TRANSFER_TYPE_BINARY = &H2
  Public Const FILE_ATTRIBUTE_ARCHIVE = &H20
  Public Const INTERNET_FLAG_NO_CACHE_WRITE = &H4000000      ' don't write this item to the cache

  Public Declare Function FtpPutFile Lib "wininet.dll" Alias "FtpPutFileA" (ByVal hFtpSession As IntPtr, ByVal lpszLocalFile As String, ByVal lpszRemoteFile As String, ByVal dwFlags As Integer, ByVal dwContext As Integer) As Boolean

  Delegate Function dFtpCallbackStatus(ByVal hInternet As IntPtr, _
                                  ByVal dwContext As Integer, _
                                  ByVal dwInternetStatus As Integer, _
                                  ByVal lpvStatusInfo As Integer, _
                                  ByVal dwStatusInfoLength As Integer) As Integer

  Sub ftpConnect(ByVal server As String, ByVal user As String, ByVal pass As String)
    hInet = InternetOpen("Mozilla/mw/ftp...screengrab", INTERNET_OPEN_TYPE_DIRECT, IntPtr.Zero, IntPtr.Zero, INTERNET_FLAG_NO_CACHE_WRITE)

    ftpHandle = InternetConnect(hInet, server, INTERNET_DEFAULT_FTP_PORT, _
              user, pass, INTERNET_SERVICE_FTP, _
              INTERNET_FLAG_EXISTING_CONNECT Or INTERNET_FLAG_PASSIVE, IntPtr.Zero)

    InternetSetStatusCallback(ftpHandle, AddressOf FtpCallbackStatus)
  End Sub

  Public Function FtpCallbackStatus(ByVal hInternet As IntPtr, _
                                  ByVal dwContext As Integer, _
                                  ByVal dwInternetStatus As Integer, _
                                  ByVal lpvStatusInfo As Integer, _
                                  ByVal dwStatusInfoLength As Integer) As Integer



  End Function



  Function ftpUpload(ByVal locFile As String, ByVal remoteFile As String) As Integer
    Dim res As Integer

    res = FtpPutFile(ftpHandle, locFile, remoteFile, FTP_TRANSFER_TYPE_BINARY, 0)

    Return res
  End Function
  Function ftpDownload(ByVal locFile As String, ByVal remoteFile As String) As Boolean
    Dim res As Boolean
    IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(locFile))
    If IO.File.Exists(locFile) Then IO.File.Delete(locFile)
    res = FtpGetFile(ftpHandle, remoteFile, locFile, True, FILE_ATTRIBUTE_ARCHIVE, FTP_TRANSFER_TYPE_BINARY, 0)
    Return res
  End Function

  Sub ftpClose()
    InternetCloseHandle(ftpHandle)
    InternetCloseHandle(hInet)

  End Sub

End Module
