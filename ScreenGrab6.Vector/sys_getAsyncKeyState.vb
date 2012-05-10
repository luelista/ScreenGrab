Imports system.Runtime.InteropServices
Imports System.Windows.Forms

Module sys_getAsyncKeyState
  <DllImport("user32.dll")> _
  Public Function GetAsyncKeyState(ByVal vKey As Integer) As Short
  End Function

  'Function isKeyPressed(ByVal key As Keys) As Boolean
  '  isKeyPressed = False
  '  Dim stat As Short
  '  'GetAsyncKeyState(key) 'puffer leeren
  '  stat = GetAsyncKeyState(key)
  '  'Debug.Print(key.ToString + vbTab + stat.ToString)
  '  If stat <> 0 Then
  '    isKeyPressed = True
  '  End If
  'End Function

  Function isKeyPressed(ByVal key As Keys) As Boolean
    isKeyPressed = False
    Dim stat As Short
    'GetAsyncKeyState(key) 'puffer leeren
    stat = GetAsyncKeyState(key)

    'Debug.Print(key.ToString + vbTab + stat.ToString)
    If stat And -32768 Then
      isKeyPressed = True
    End If
  End Function

  Function isShiftControl() As Boolean
    isShiftControl = False
    If isKeyPressed(Keys.ShiftKey) And isKeyPressed(Keys.ControlKey) Then
      isShiftControl = True
    End If
  End Function


End Module
