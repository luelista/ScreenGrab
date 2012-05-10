Module app_interprocHandler

  Public WithEvents oIntWin As sys_interproc


  Sub interproc_init()
    oIntWin = New sys_interproc("grab5")
  End Sub

  Private Sub oIntWin_InitCommandDefinition(ByVal e As sys_interproc.commandDefEventArgs) Handles oIntWin.InitCommandDefinition
    
    e.Add("QUERY", "GetGrabPos", "-", "gibt die aktuelle Screenshot-Position zurück")
    ' e.Add("CMD  ", "PreviewURL", "URL", "")
    ' e.Add("CMD  ", "StartGrab", "-", "GRAB starten")
    e.Add("CMD  ", "DoQuickUpload", "", "Schnellupload ")
  End Sub

  Private Sub oIntWin_DataRequest(ByVal source As String, ByVal cmdString As String, ByVal para As String, ByRef returnValue As String) Handles oIntWin.DataRequest
    
    Select Case cmdString.ToUpper
      Case "GETGRABPOS"
        returnValue = deltaX & "|" & deltaY


    End Select
  End Sub

  Private Sub oIntWin_Message(ByVal source As String, ByVal cmdString As String, ByVal para As String) Handles oIntWin.Message
    
    Select Case cmdString.ToUpper
      Case "PREVIEWURL"
        'frm_viewer.Show()
        'frm_viewer.Activate()
        'frm_viewer.WebBrowser1.Navigate(para)

      Case "STARTGRAB"
        openGrabWindow()


    End Select

  End Sub

End Module
