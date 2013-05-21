Imports ScreenGrab6.Vector

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
        Dim vcc = MDI.vcc
        If vcc Is Nothing Then
          vcc = MDI.newClient.vcc
        End If
        Dim obj As New VImage
        obj.name = "img_" + IO.Path.GetFileName(para) + "_" + Now.Ticks.ToString
        obj.img = LoadImage(para)
        obj.source = "FILE:" + para
        obj.bounds = New Rectangle(100, 100, obj.img.Width, obj.img.Height)
        'obj.setBorder(2, Color.RoyalBlue)
        vcc.canvas.addObject(obj)

      Case "OPEN"
        Dim f = MDI.newClient
        f.vcc.openFile(para)


    End Select

  End Sub

End Module
