Imports ScreenGrab6.vbAccelerator.Components.HotKey
Module app_hotkey

  Dim WithEvents hkForm As New hotKeyForm()

  Sub initHotkeys()
    On Error Resume Next
    hkForm.HotKeys.Add("DoGrab1", Keys.G, HotKey.HotKeyModifiers.MOD_WIN)
    hkForm.HotKeys.Add("DoGrabFullscreen", Keys.G, HotKey.HotKeyModifiers.MOD_WIN Or HotKey.HotKeyModifiers.MOD_SHIFT)
    hkForm.HotKeys.Add("DoGrab2", Keys.S, HotKey.HotKeyModifiers.MOD_WIN)
    hkForm.HotKeys.Add("DoGrabWin", Keys.PrintScreen, HotKey.HotKeyModifiers.MOD_WIN)
    hkForm.HotKeys.Add("DoGrabCurrent", Keys.Q, HotKey.HotKeyModifiers.MOD_WIN)

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
