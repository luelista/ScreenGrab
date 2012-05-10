'---- Anfang ScreenshotGenerator.vb ----
Option Explicit On
Option Strict On
Option Compare Binary

Imports System
Imports System.Drawing

' <remarks>
'   Stellt Funktionalität zum Erstellen von
'   Bildschirmfotos bereit.
' </remarks>
Public Class ScreenshotGenerator
#Region " API-Deklarationen "
  Private Declare Function GetDesktopWindow Lib "user32.dll" () As IntPtr

  Private Declare Function GetDC Lib "user32.dll" ( _
      ByVal hWnd As IntPtr) As IntPtr

  Private Declare Function ReleaseDC Lib "user32.dll" ( _
      ByVal hWnd As IntPtr, _
      ByVal hdc As IntPtr) As Int32

  Private Declare Function GetWindowRect Lib "user32.dll" ( _
      ByVal hWnd As IntPtr, _
      ByRef lpRect As RECT) As Int32

  Private Declare Function ScreenToClient Lib "user32.dll" ( _
      ByVal hWnd As IntPtr, _
      ByRef lpPoint As POINTAPI) As Int32

  Private Structure POINTAPI
    Public x As Int32
    Public y As Int32
  End Structure

  Private Structure RECT
    Public Left As Int32
    Public Top As Int32
    Public Right As Int32
    Public Bottom As Int32
  End Structure

  Private Declare Function StretchBlt Lib "gdi32.dll" ( _
      ByVal hdc As IntPtr, _
      ByVal x As Int32, _
      ByVal y As Int32, _
      ByVal nWidth As Int32, _
      ByVal nHeight As Int32, _
      ByVal hSrcDC As IntPtr, _
      ByVal xSrc As Int32, _
      ByVal ySrc As Int32, _
      ByVal nSrcWidth As Int32, _
      ByVal nSrcHeight As Int32, _
      ByVal dwRop As Int32) As Int32

  Private Const SRCCOPY As Int32 = &HCC0020
#End Region

  Private m_intptrWindow As IntPtr


  ' <summary>
  '   Gibt das Handle des zu fotografierenden
  '   Fensters an oder gibt es zurück. Der Wert 0 gibt
  '   an, dass der gesamte Desktop eingefangen werden soll.
  ' </summary>
  ' <value>Handle des zu fotografierenden Fensters.</value>
  Public Property Window() As IntPtr
    Get
      Return m_intptrWindow
    End Get
    Set(ByVal Value As IntPtr)
      m_intptrWindow = Value
    End Set
  End Property

  Public Function CaptureByRect(ByVal left As Integer, ByVal top As Integer, ByVal width As Integer, ByVal height As Integer) As Bitmap

    Dim hWndWindowToCapture As IntPtr
    If Me.Window.Equals(IntPtr.Zero) Then

      ' Handle auf Desktop ermitteln.
      hWndWindowToCapture = GetDesktopWindow()
    Else
      hWndWindowToCapture = Me.Window
    End If

    ' Koordinaten in Client-Koordinaten transformieren.
    Dim pt As POINTAPI
    pt.y = top
    pt.x = left
    ScreenToClient(hWndWindowToCapture, pt)
    left = pt.x
    top = pt.y

    ' Erstellen einer Bitmap, die den Screenshot
    ' aufnehmen kann (in Grösse des Desktops).
    Dim b As Bitmap = New Bitmap(width, height)

    ' Erstellen eines Graphics-Objekts zur Bitmap,
    ' um in sie zu zeichnen.
    Dim g As Graphics = Graphics.FromImage(b)

    ' Erstellen eines Handles auf den Device
    ' Context des Desktops.
    Dim hdcWindow As IntPtr = GetDC(hWndWindowToCapture)

    ' Ermitteln eines Handles auf den Device
    ' Context des Graphics-Objekts
    ' zur Ziel-Bitmap.
    Dim hdc As IntPtr = g.GetHdc()

    ' Zeichnen des Inhalts des Desktop-DCs
    ' in den DC der Bitmap.
    StretchBlt( _
        hdc, _
        0, _
        0, _
        width, _
        height, _
        hdcWindow, _
        left, _
        top, _
        width, _
        height, _
        SRCCOPY _
        )
    
    
    ' Handles freigeben.
    ReleaseDC(hWndWindowToCapture, hdcWindow)
    g.ReleaseHdc(hdc)

    'Dim str As String = "left: " + left.ToString + "top: " + top.ToString + "width: " + width.ToString + "height: " + height.ToString
    'Dim f As New System.Drawing.Font("Arial", 13, FontStyle.Regular, GraphicsUnit.Point)
    'g = Graphics.FromImage(b)
    'g.DrawString(str, f, Brushes.Blue, 5, 5)



    ' Erstellte Grafik zurückgeben.
    Return b
  End Function

  ' <summary>
  '   Gibt eine Bitmap in Grösse des in der
  '   Eigenschaft <c>Window</c> angegebenen Fensters mit
  '   dessen Inhalt zurück.
  ' </summary>
  ' <returns>Bitmap, die ein Bildschirmfoto
  '   eines Fensters enthält.</returns>
  Public Function Capture() As Bitmap
    Dim hWndWindowToCapture As IntPtr
    If Me.Window.Equals(IntPtr.Zero) Then

      ' Handle auf Desktop ermitteln.
      hWndWindowToCapture = GetDesktopWindow()
    Else
      hWndWindowToCapture = Me.Window
    End If

    ' Rechteck mit Massen des Desktops ermitteln.
    Dim rct As RECT
    GetWindowRect(hWndWindowToCapture, rct)

    Dim intWidth As Int32 = rct.Right - rct.Left
    Dim intHeight As Int32 = rct.Bottom - rct.Top


    Return CaptureByRect(rct.Left, rct.Top, intWidth, intHeight)

  End Function
End Class

'----- Ende ScreenshotGenerator.vb -----