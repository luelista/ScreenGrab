Public Module sys_mwTrace

  Public Sub Trace(ByVal para1 As String, Optional ByVal para2 As String = "", Optional ByVal typ As String = "trace", Optional ByVal pcodeLink As String = "")


    Program.traceWin.onTraceWrite(para1, para2, typ, pcodeLink)
  End Sub


End Module
