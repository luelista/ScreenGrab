Module app_softwareUpdate

  Public updateCheckURL As String = "https://downloads.max-weller.de/screengrab/versionInfo.txt"
  Public updateDownloadURL As String
  Public updateInfoText As String
  Public updateNewVersion As String

  Function checkForUpdate() As Boolean
    Dim RESULT As String = TwAjax.getUrlContent(updateCheckURL & "?" & Now.Ticks)
    Dim lines() As String = Split(RESULT, vbNewLine)
    If lines.Length < 3 Then Return False

    Dim ver() As String = Split(lines(0), ".", 2)
    Dim major, minor As Integer
    If Integer.TryParse(ver(0), major) And Integer.TryParse(ver(1), minor) Then
      If major > My.Application.Info.Version.Major Or minor > My.Application.Info.Version.Minor Then
        updateNewVersion = lines(0)
        updateDownloadURL = lines(1)
        updateInfoText = lines(2)

        Return True
      End If
    End If

    Return False
  End Function

End Module
