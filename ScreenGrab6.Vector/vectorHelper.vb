Imports System.Drawing
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Public Enum VResizeDirection
  None = 0
  TopLeft
  TopRight
  BottomLeft
  BottomRight
  Rotation
  Custom1
  Custom2
  Top
  Left
  Bottom
  Right
End Enum

<StructLayout(LayoutKind.Sequential)> _
  Public Structure RECT
  Public Left As Integer
  Public Top As Integer
  Public Right As Integer
  Public Bottom As Integer

  Public Sub New(ByVal pLeft As Integer, ByVal pTop As Integer, ByVal pRight As Integer, ByVal pBottom As Integer)
    Left = pLeft
    Top = pTop
    Right = pRight
    Bottom = pBottom
  End Sub
  Public Sub New(ByVal managedRect As Rectangle)
    Left = managedRect.Left
    Top = managedRect.Top
    Right = managedRect.Right
    Bottom = managedRect.Bottom
  End Sub
End Structure
Public Class Helper

  ''' <summary>
  ''' Gets the physical location of a font family from the registry
  ''' </summary>
  ''' <param name="fontName">Font family name</param>
  ''' <returns>File path or String.Empty</returns>
  ''' <remarks></remarks>
  Public Shared Function GetFontFilespec(ByVal fontName As String) As String
    GetFontFilespec = String.Empty
    Try
      Using rkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts", False)
        Dim fontFilespec As String = ""
        For Each d As String In rkey.GetValueNames
          If d.StartsWith(fontName) Then fontFilespec = rkey.GetValue(d)
        Next
        If IO.File.Exists(fontFilespec) = False Then fontFilespec = IO.Path.Combine(System.Environment.GetEnvironmentVariable("WINDIR"), fontFilespec)
        If IO.File.Exists(fontFilespec) Then Return fontFilespec
      End Using
    Catch : End Try
  End Function

  Public Shared Function PointDistance(ByVal pt1 As Point, ByVal pt2 As Point) As Single
    Return Math.Sqrt((Math.Abs(pt1.X - pt2.X) ^ 2) + (Math.Abs(pt1.Y - pt2.Y) ^ 2))
  End Function

  Public Shared Function StripHtmlTags(ByVal str As String) As String
    Return System.Text.RegularExpressions.Regex.Replace(str, "<(.|\n)*?>", "")
  End Function

  Public Shared Function EncodeHtmlTags(ByVal str As String) As String
    Return Replace(Replace(str, "<", "&lt;"), ">", "&gt;")
  End Function

  Public Shared Function DecodeHtmlTags(ByVal str As String) As String
    Return Replace(Replace(str, "&lt;", "<"), "&gt;", ">")
  End Function

  Public Shared Function MakeRect(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, Optional ByVal DirectMode As Boolean = False) As Rectangle
    If DirectMode Then Return New Rectangle(x1, y1, x2 - x1, y2 - y1)
    Dim lx = Math.Min(x1, x2), ly = Math.Min(y1, y2)
    Return New Rectangle(lx, ly, Math.Max(x1, x2) - lx, Math.Max(y1, y2) - ly)
  End Function

  Public Shared Function IsArrowKey(ByVal kc As Keys) As Boolean
    Return kc >= 37 And kc <= 40
  End Function

  Public Shared Function GetResizedRect(ByVal sourceRect As Rectangle, ByVal direction As VResizeDirection, ByVal startPoint As Point, ByVal curPoint As Point) As Rectangle
    Dim deltaX = curPoint.X - sourceRect.X, deltaY = curPoint.Y - sourceRect.Y
    GetResizedRect = sourceRect
    'Dim resizes = ""
    If direction = VResizeDirection.TopLeft Or direction = VResizeDirection.TopRight Then
      'resizes += "TOP "        'top resize
      GetResizedRect.Y += deltaY
      GetResizedRect.Height -= deltaY
    End If

    If direction = VResizeDirection.TopLeft Or direction = VResizeDirection.BottomLeft Then
      'resizes += "LEFT "     'left resize
      GetResizedRect.X += deltaX
      GetResizedRect.Width -= deltaX
    End If

    If direction = VResizeDirection.BottomLeft Or direction = VResizeDirection.BottomRight Then
      'resizes += "BTM "     'bottom resize
      GetResizedRect.Height = deltaY
    End If

    If direction = VResizeDirection.TopRight Or direction = VResizeDirection.BottomRight Then
      'resizes += "RGT "    'right resize
      GetResizedRect.Width = deltaX
    End If

    'Debug.Print(resizes)
  End Function


  Public Shared Function Color2String(ByVal c As Color) As String
    Return String.Format("{0:X2}{1:X2}{2:X2}{3:X2}", c.A, c.R, c.G, c.B)
  End Function

  Public Shared Function Color2HTMLString(ByVal c As Color) As String
    If c.A < 255 Then
      Return String.Format(Globalization.CultureInfo.InvariantCulture.NumberFormat, "rgba({1},{2},{3},{0:0.00})", c.A / 255, c.R, c.G, c.B)
    Else
      Return String.Format("rgb({1},{2},{3})", c.A, c.R, c.G, c.B)
    End If
  End Function

  Public Shared Function String2Color(ByVal c As String) As Color
    If c.Length <> 8 Then Return Color.Black
    Return Color.FromArgb(Convert.ToByte(c.Substring(0, 2), 16), Convert.ToByte(c.Substring(2, 2), 16), Convert.ToByte(c.Substring(4, 2), 16), Convert.ToByte(c.Substring(6, 2), 16))
  End Function

  Public Shared Function ImageToBase64(ByVal img As Image) As String
    If img Is Nothing Then Return ""
    Dim ms As New IO.MemoryStream()
    img.Save(ms, Imaging.ImageFormat.Png)
    'img.Save(ms, ImageFormat.Gif)

    ms.Seek(0, IO.SeekOrigin.Begin)
    Dim buf(ms.Length - 1) As Byte
    ms.Read(buf, 0, ms.Length)

    ImageToBase64 = "data:image/png;base64," + Convert.ToBase64String(buf, Base64FormattingOptions.None)
    'ImageToBase64 = "data:image/gif;base64," + Convert.ToBase64String(buf, Base64FormattingOptions.InsertLineBreaks)

  End Function

  Public Shared Function Base64ToImage(ByVal str As System.Text.StringBuilder) As Image
    'abschneiden des Vorspanns und extrahieren des Datentyps ("data:" + type + ";base64,")
    Dim modus As Integer = 0, datTyp As String = "", abPos As Integer
    For i = 0 To str.Length - 1
      If str.Chars(i) = ":"c Then modus = 1 : Continue For
      If str.Chars(i) = ";"c Then modus = 2 : Continue For
      If str.Chars(i) = ","c Then modus = 3 : abPos = i + 1 : Exit For
      If modus = 1 Then
        datTyp += str.Chars(i)
      End If
    Next
    Dim img = str.ToString(abPos, str.Length - abPos)
    Dim byt() = Convert.FromBase64String(img)
    Dim ms As New IO.MemoryStream(byt)
    Base64ToImage = Image.FromStream(ms)
    ms.Close()
  End Function

End Class