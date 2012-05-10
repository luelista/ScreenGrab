Module app_uploadHistory
  Dim uploadHistoryFilename As String = _
        settingsFolder + "uploadHistory.html"

  Sub uploadHistoryAdd(ByVal text As String)
    If glob.para("frm_options__chkEnableHistory", "TRUE") = _
                          "FALSE" Then Exit Sub
    IO.File.AppendAllText(uploadHistoryFilename, _
                          text + vbNewLine + vbNewLine + _
                          "<hr>" + vbNewLine + vbNewLine)
  End Sub

  Sub uploadHistoryOpen()
    Process.Start(uploadHistoryFilename)
  End Sub

End Module
