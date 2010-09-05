Imports ScreenGrab5.vbAccelerator.Components.HotKey
Module app_hotkey

  Dim WithEvents hkForm As New hotKeyForm()

  Sub initHotkeys()
    On Error Resume Next
    hkForm.HotKeys.Add("DoGrab1", Keys.G, HotKey.HotKeyModifiers.MOD_WIN)
    hkForm.HotKeys.Add("DoGrab2", Keys.S, HotKey.HotKeyModifiers.MOD_WIN)
    hkForm.HotKeys.Add("DoGrabWin", Keys.PrintScreen, HotKey.HotKeyModifiers.MOD_WIN)

  End Sub

  Private Sub hkForm_HotKeyPressed(ByVal sender As Object, ByVal e As vbAccelerator.Components.HotKey.HotKeyPressedEventArgs) Handles hkForm.HotKeyPressed
    Dim hkName As String = DirectCast(e.HotKey, HotKey).Name
    If hkName = "DoGrabWin" Then
      grabCurrentWindow()

    Else
      openGrabWindow()

    End If
  End Sub


End Module
