Imports System.Runtime.InteropServices

Module sys_forceForegroundWindow

  Private Declare Function SetForegroundWindow Lib "user32" (ByVal hwnd As IntPtr) As Long

  <DllImport("user32.dll", SetLastError:=True)> _
  Private Function GetForegroundWindow() As IntPtr
  End Function
  <DllImport("user32.dll", SetLastError:=True)> _
  Public Function GetWindowThreadProcessId(ByVal hwnd As IntPtr, _
                          ByRef lpdwProcessId As Integer) As Integer
  End Function

  <DllImport("user32.dll")> _
  Private Function AttachThreadInput(ByVal idAttach As System.UInt32, ByVal idAttachTo As System.UInt32, ByVal fAttach As Boolean) As Boolean
  End Function

  Private Declare Auto Function IsIconic Lib "user32.dll" (ByVal hwnd As IntPtr) As Boolean
  <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
  Private Function ShowWindow(ByVal hwnd As IntPtr, ByVal nCmdShow As Int32) As Boolean
  End Function
  Private Const SW_SHOW = 5
  Private Const SW_RESTORE = 9

  Public Function ForceForegroundWindow(ByVal hWnd As Long) As Boolean
    Dim ThreadID1 As Long
    Dim ThreadID2 As Long
    Dim nRet As Long

    ' Nothing to do if already in foreground.
    If hWnd = GetForegroundWindow() Then
      ForceForegroundWindow = True
    Else
      ' First need to get the thread responsible for this window,
      ' and the thread for the foreground window.
      ThreadID1 = GetWindowThreadProcessId(GetForegroundWindow, 0&)
      ThreadID2 = GetWindowThreadProcessId(hWnd, 0&)

      ' By sharing input state, threads share their concept of
      ' the active window.
      If ThreadID1 <> ThreadID2 Then
        Call AttachThreadInput(ThreadID1, ThreadID2, True)
        nRet = SetForegroundWindow(hWnd)
        Call AttachThreadInput(ThreadID1, ThreadID2, False)
      Else
        nRet = SetForegroundWindow(hWnd)
      End If
      '
      ' Restore and repaint
      '
      If IsIconic(hWnd) Then
        Call ShowWindow(hWnd, SW_RESTORE)
      Else
        Call ShowWindow(hWnd, SW_SHOW)
      End If

      ' SetForegroundWindow return success.
      ForceForegroundWindow = CBool(nRet)
    End If
  End Function



  'Sub ForceForegroundWindow(ByVal hWnd As IntPtr)
  '  If GetForegroundWindow() <> hWnd Then
  '    SetForegroundWindow(hWnd)
  '  End If
  'End Sub



End Module
