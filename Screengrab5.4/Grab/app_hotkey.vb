Imports ScreenGrab6.vbAccelerator.Components.HotKey
Module app_hotkey

  Dim WithEvents hkForm As New hotKeyForm()

  Function hotkeyToString(ByVal hkKey As Keys, ByVal modif As HotKey.HotKeyModifiers) As String
    Dim modifiersStr As String = ""
    If (modif And HotKey.HotKeyModifiers.MOD_CONTROL) > 0 Then modifiersStr += "Ctrl-"
    If (modif And HotKey.HotKeyModifiers.MOD_ALT) > 0 Then modifiersStr += "Alt-"
    If (modif And HotKey.HotKeyModifiers.MOD_SHIFT) > 0 Then modifiersStr += "Shift-"
    If (modif And HotKey.HotKeyModifiers.MOD_WIN) > 0 Then modifiersStr += "Win-"
    modifiersStr += hkKey.ToString
    Return modifiersStr
  End Function

  Sub initHotkeys()
    hkForm.HotKeys.Clear()

    '  On Error Resume Next
    ' hkForm.HotKeys.Add("DoGrab1", Keys.G, HotKey.HotKeyModifiers.MOD_WIN)
    Try
      hkForm.HotKeys.Add("DoGrabFullscreen", Keys.G, HotKey.HotKeyModifiers.MOD_WIN Or HotKey.HotKeyModifiers.MOD_SHIFT)
    Catch ex As Exception
      'MsgBox("Kann Hotkey WIN+Shift+G nicht registrieren.", MsgBoxStyle.Critical, "Fehler")
    End Try
    ' hkForm.HotKeys.Add("DoGrab2", Keys.S, HotKey.HotKeyModifiers.MOD_WIN)
    ' windows 10 blockiert Win-S und Win-G
    Dim hkKey As Keys = glob.para("HotkeyKey", CType(Keys.G, Integer))
    Dim hkMod As HotKey.HotKeyModifiers = glob.para("HotkeyModifier", "8")
    Try
      hkForm.HotKeys.Add("DoGrab3", hkKey, hkMod)
    Catch ex As Exception
      MsgBox("Kann Hotkey " + hotkeyToString(hkKey, hkMod) + " nicht registrieren. Bitte wählen Sie in den Einstellungen einen anderen Hotkey.", MsgBoxStyle.Critical, "Fehler")
    End Try
    Try
      hkForm.HotKeys.Add("DoGrabWin", Keys.PrintScreen, HotKey.HotKeyModifiers.MOD_WIN)
    Catch ex As Exception
      'MsgBox("Kann Hotkey WIN+Druck nicht registrieren.", MsgBoxStyle.Critical, "Fehler")
    End Try
    Try
      hkForm.HotKeys.Add("DoGrabCurrent", Keys.Q, HotKey.HotKeyModifiers.MOD_WIN)
    Catch ex As Exception
      'MsgBox("Kann Hotkey Win+Q nicht registrieren.", MsgBoxStyle.Critical, "Fehler")
    End Try

  End Sub

  Private Sub hkForm_HotKeyPressed(ByVal sender As Object, ByVal e As vbAccelerator.Components.HotKey.HotKeyPressedEventArgs) Handles hkForm.HotKeyPressed
    Dim hkName As String = DirectCast(e.HotKey, HotKey).Name
    If hkName = "DoGrabWin" Then
      grabCurrentWindow()

    ElseIf hkName = "DoGrabFullscreen" Then
      grabFullScreen()

    ElseIf hkName = "DoGrabCurrent" Then
      screenGrab()
      updatePartialView()
      onScreenshotTaken()

    Else
      openGrabWindow()

    End If
  End Sub


End Module
