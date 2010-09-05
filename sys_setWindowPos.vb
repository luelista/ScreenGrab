Module sys_setWindowPos


  Private Const SWP_NOACTIVATE = &H10
  Private Const SWP_NOMOVE = 2
  Private Const SWP_NOSIZE = 1
  Private Const HWND_TOPMOST = -1
  Private Const HWND_NOTOPMOST = -2

  Private Const flags = SWP_NOMOVE Or SWP_NOSIZE
  Private Const FLAGS2 = SWP_NOMOVE Or SWP_NOSIZE Or SWP_NOACTIVATE

  Private Declare Function SetWindowPos Lib "user32" (ByVal h As Integer, ByVal hb As Integer, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal F As Integer) As Integer

  Sub putWinAfter(ByVal win1 As IntPtr, ByVal win2 As IntPtr)
    SetWindowPos(win1, win2, 0, 0, 0, 0, SWP_NOMOVE Or SWP_NOSIZE Or SWP_NOACTIVATE)

  End Sub


End Module
