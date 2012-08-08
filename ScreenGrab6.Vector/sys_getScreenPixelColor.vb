Imports System.Runtime.InteropServices

Module sys_getScreenPixelColor
  <DllImport("User32.dll", EntryPoint:="GetDC", _
  CallingConvention:=CallingConvention.StdCall, _
  CharSet:=CharSet.Auto, exactspelling:=True)> _
  Private Function GetDC(ByVal hwnd As IntPtr) As IntPtr
  End Function
  <DllImport("gdi32.dll")> _
  Private Function GetPixel(ByVal hdc As IntPtr, ByVal nXPos As Integer, ByVal nYPos As Integer) As UInteger
  End Function
  <DllImport("user32.dll")> _
   Private Function ReleaseDC(ByVal hWnd As IntPtr, ByVal hDC As IntPtr) As Integer
  End Function


  Function getScreenPixelColorFromCursor() As Color
    Dim hdc = GetDC(IntPtr.Zero)
    Dim cur As Point = Cursor.Position
    Dim pixel = GetPixel(hdc, cur.X, cur.Y)
    ReleaseDC(IntPtr.Zero, hdc)
    Return ColorTranslator.FromWin32(pixel)
  End Function



End Module
