Module app_interprocHandler

  Public WithEvents oIntWin As sys_interproc


  Sub interproc_init()
    oIntWin = New sys_interproc("collage")
  End Sub

  Private Sub oIntWin_InitCommandDefinition(ByVal e As sys_interproc.commandDefEventArgs) Handles oIntWin.InitCommandDefinition
    
    e.Add("CMD  ", "AddImage", "filespec", "Add image at filespec to current collage ")
    e.Add("CMD  ", "Open", "filespec", "Open the specified collage as new tab")
    e.Add("CMD  ", "Load", "filespec", "Open the specified collage in current tab")

  End Sub

  Private Sub oIntWin_DataRequest(ByVal source As String, ByVal cmdString As String, ByVal para As String, ByRef returnValue As String) Handles oIntWin.DataRequest
    Select Case cmdString.ToUpper

    End Select
  End Sub

  Private Sub oIntWin_Message(ByVal source As String, ByVal cmdString As String, ByVal para As String) Handles oIntWin.Message
    
    Select Case cmdString.ToUpper
      Case "ADDIMAGE"
        
      Case "OPEN"



    End Select

  End Sub

End Module
