Imports Microsoft.Win32

Module sys_mwRegistry

  Public ReadOnly Property ApplicationExecutableDir As String
    Get
      Return System.IO.Path.GetDirectoryName(Application.ExecutablePath)
    End Get
  End Property

  Public Sub registerAppPath()
    Dim exePath As String = Application.ExecutablePath
    Dim exeName As String = System.IO.Path.GetFileName(exePath)
    Using key = Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\App Paths\" & exeName)
      key.SetValue(Nothing, exePath)
    End Using
  End Sub

  Public Function ExePath(ByVal appName As String) As String
    On Error Resume Next
    appName = appName.Replace(".exe", "")
    Dim path As String
    Using key = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\App Paths\" & appName)
      path = key.GetValue(Nothing)
      If path IsNot Nothing Then Return path
    End Using
    path = System.IO.Path.Combine(ApplicationExecutableDir, appName + ".exe")
    If IO.File.Exists(path) Then Return path
    Return Nothing
  End Function

End Module
