Imports System.Drawing.Drawing2D

Namespace Vector

  Public Enum VResizeDirection
    None = 0
    TopLeft
    TopRight
    BottomLeft
    BottomRight
    Top
    Left
    Bottom
    Right
  End Enum

  <Microsoft.VisualBasic.ComClass()> Public Class Helper
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

  '---------------------------------------------------------------------------------------

  Public MustInherit Class VObject


    Private p_name As String
    Public Property Name() As String
      Get
        Return p_name
      End Get
      Set(ByVal value As String)
        p_name = value
      End Set
    End Property

    Public created As String

    Public ZIndex As Integer

    Private m_bounds As Rectangle
    Private m_rotatedBounds As Rectangle
    Protected m_resizeBounds(3) As Rectangle
    Protected m_resizeBoundsTransformed(3) As Rectangle

    Protected MustOverride Sub DrawObjectInternal(ByVal g As Graphics)

    Friend moveTempRect As Rectangle
    Friend moveOrigRect As Rectangle
    Friend isSelected As Boolean
    Friend borderPen As Pen = New Pen(Color.Black, 0)

    Public Shared selectionRectPen As New Pen(Color.Black, 1) With {.DashStyle = Drawing2D.DashStyle.Dash}

    Public Shared CommonDataOffset As Integer = 19
    Public Shared ResizerWidth As Integer = 5
    Public Shared ResizerBrsh As New SolidBrush(Color.Gray)

    Private p_rotation As Integer

    Public Parent As Canvas

    '  Public HasAttachedArrows As Boolean --- optionale Optimierung

    Public ReadOnly Property TypeName() As String
      Get
        Return Me.GetType.Name
      End Get
    End Property

    Public Overridable Property Rotation() As Integer
      Get
        Return p_rotation
      End Get
      Set(ByVal value As Integer)
        p_rotation = value
      End Set
    End Property

    Public Overridable Sub DrawMoveRect()
      ControlPaint.DrawReversibleFrame(Parent.PicBox.RectangleToScreen(Me.moveTempRect), Color.White, FrameStyle.Dashed)
    End Sub

    Public Sub DrawObject(ByVal g As Graphics)
      Dim m, oldm As Matrix
      If Rotation > 0 Then
        m = New Matrix
        m.RotateAt(Rotation, New PointF(Me.bounds.X + Me.bounds.Width / 2, Me.bounds.Y + Me.bounds.Height / 2))
        oldm = g.Transform
        g.Transform = m
      End If
      DrawObjectInternal(g)
      If Rotation > 0 Then
        g.Transform = oldm
        m.Dispose()
      End If
      DrawSelection(g)
    End Sub

    Public Property bounds() As Rectangle
      Get
        Return m_bounds
      End Get
      Set(ByVal value As Rectangle)
        m_bounds = value
        OnBoundsChanged()
      End Set
    End Property

    Private Sub OnBoundsChanged()
      Dim m As New Matrix()
      m.RotateAt(Rotation, New PointF(Me.bounds.X + Me.bounds.Width / 2, Me.bounds.Y + Me.bounds.Height / 2))
      Dim pt() As Point = {New Point(m_bounds.X, m_bounds.Y), New Point(m_bounds.Right, m_bounds.Bottom)}
      m.TransformPoints(pt)
      m_rotatedBounds = New Rectangle(pt(0).X, pt(0).Y, pt(1).X - pt(0).X, pt(1).Y - pt(0).Y)
      m.Dispose()
      m_resizeBoundsTransformed = GetResizeBounds(m_rotatedBounds)
      m_resizeBounds = GetResizeBounds(m_bounds)
      OnContentChanged()
      If Parent IsNot Nothing Then
        For I = 0 To Parent.ItemCount - 1
          Dim v = Parent.Item(I)
          If TypeOf v Is VLine AndAlso (DirectCast(v, VLine).startObject = name Or DirectCast(v, VLine).endObject = name) Then DirectCast(v, VLine).EnforceDockPosition()
        Next
      End If
    End Sub

    Private Function GetResizeBounds(ByVal rct As Rectangle) As Rectangle()
      Return New Rectangle() { _
          New Rectangle(rct.X - ResizerWidth, rct.Y - ResizerWidth, ResizerWidth * 2, ResizerWidth * 2), _
          New Rectangle(rct.Right - ResizerWidth, rct.Y - ResizerWidth, ResizerWidth * 2, ResizerWidth * 2), _
          New Rectangle(rct.X - ResizerWidth, rct.Bottom - ResizerWidth, ResizerWidth * 2, ResizerWidth * 2), _
          New Rectangle(rct.Right - ResizerWidth, rct.Bottom - ResizerWidth, ResizerWidth * 2, ResizerWidth * 2) _
      }
    End Function

    Protected Sub OnContentChanged()
      If Parent IsNot Nothing Then Parent.OnContentChanged(Me)
    End Sub

    Public Overridable Property Color1() As Color
      Get
        Return borderPen.Color
      End Get
      Set(ByVal value As Color)
        borderPen.Color = value
        OnContentChanged()
      End Set
    End Property

    Public Overridable Property Color2() As Color
      Get

      End Get
      Set(ByVal value As Color)

      End Set
    End Property

    Public Property BorderWidth() As Single
      Get
        Return borderPen.Width
      End Get
      Set(ByVal value As Single)
        borderPen.Width = value
        OnContentChanged()
      End Set
    End Property

#Region "Left,Top,Width,Height Properties"
    Public Property Left() As Integer
      Get
        Return m_bounds.X
      End Get
      Set(ByVal value As Integer)
        m_bounds.X = value
        OnBoundsChanged()
      End Set
    End Property
    Public Property Top() As Integer
      Get
        Return m_bounds.Y
      End Get
      Set(ByVal value As Integer)
        m_bounds.Y = value
        OnBoundsChanged()
      End Set
    End Property
    Public Property Width() As Integer
      Get
        Return m_bounds.Width
      End Get
      Set(ByVal value As Integer)
        m_bounds.Width = value
        OnBoundsChanged()
      End Set
    End Property
    Public Property Height() As Integer
      Get
        Return m_bounds.Height
      End Get
      Set(ByVal value As Integer)
        m_bounds.Height = value
        OnBoundsChanged()
      End Set
    End Property
#End Region

    Overridable Function ToHtml() As String
      Return "<!-- " + Join(Me.Serialize(), "##") + "## -->"
    End Function

    Public Shared Function FromHtml(ByVal input As String) As VObject
      If String.IsNullOrEmpty(input) Then Return Nothing
      Dim posIdx1, posIdx2 As Integer
      posIdx1 = input.IndexOf("<!-- ##")
      If posIdx1 = -1 Then Return Nothing
      input = input.Substring(posIdx1)
      Dim para() As String = Split(input, "##")
      Select Case UCase(para(1))
        Case "IMG", "VIMAGE"
          Dim myobj As New VImage
          myobj.Deserialize(para)
          posIdx1 = input.IndexOf("src=""") + 5
          posIdx2 = input.IndexOf("""", posIdx1)
          If posIdx1 < 5 Or posIdx2 = -1 Or posIdx2 < posIdx1 Then Return Nothing
          Dim img = Helper.Base64ToImage(New System.Text.StringBuilder(input.Substring(posIdx1, posIdx2 - posIdx1)))
          DirectCast(myobj, VImage).img = img
          Return myobj
        Case "RTF", "VTEXTBOX"
          Dim myobj As New VTextbox
          myobj.Deserialize(para)
          posIdx1 = input.IndexOf(vbNewLine) + 2
          posIdx2 = input.LastIndexOf("</div>")
          If posIdx1 < 2 Or posIdx2 = -1 Or posIdx2 < posIdx1 Then Return Nothing
          DirectCast(myobj, VTextbox).Text = Helper.StripHtmlTags(input.Substring(posIdx1, posIdx2 - posIdx1).Replace("<br>", vbNewLine).Replace("<br/>", vbNewLine)).Replace("&lt;", "<").Replace("&gt;", ">")
          Return myobj
        Case "UMLCLASS"
          Dim myobj As New VUMLClass
          myobj.Deserialize(para)
          posIdx1 = input.IndexOf(vbNewLine) + 2
          posIdx2 = input.LastIndexOf("</div>")
          If posIdx1 < 2 Or posIdx2 = -1 Or posIdx2 < posIdx1 Then Return Nothing
          myobj.ParseHtmlContent(input.Substring(posIdx1, posIdx2 - posIdx1))
          Return myobj
        Case "VRECTANGLE"
          Dim myobj As New VRectangle
          myobj.Deserialize(para)
          Return myobj
        Case "VELIPSE"
          Dim myobj As New VElipse
          myobj.Deserialize(para)
          Return myobj
        Case "VLINE"
          Dim myobj As New VLine
          myobj.Deserialize(para)
          Return myobj
        Case Else
          Return Nothing
      End Select
    End Function

    Function GetHtmlBorder() As String
      If Me.borderPen IsNot Nothing Then Return " border: " & Me.borderPen.Width & "px solid " & Helper.Color2HTMLString(Me.borderPen.Color) & "; "
      Return ""
    End Function
    Function GetHtmlRotation() As String
      If Me.Rotation <> 0 Then Return "transform: rotate(" & Rotation & "deg); -moz-transform: rotate(" & Rotation & "deg); -webkit-transform: rotate(" & Rotation & "deg); -o-transform: rotate(" & Rotation & "deg); "
      Return ""
    End Function

    Overridable Function Serialize() As String()
      Dim data(18) As String
      data(1) = Me.GetType.Name
      data(2) = bounds.X
      data(3) = bounds.Y
      data(4) = bounds.Width
      data(5) = bounds.Height
      data(6) = ZIndex
      data(7) = name
      data(8) = created
      If borderPen IsNot Nothing Then
        data(9) = borderPen.Width
        data(10) = Helper.Color2String(borderPen.Color)
      End If
      data(11) = "V2" 'reserve
      data(12) = Rotation
      data(13) = borderPen.DashStyle 'reserve
      data(14) = "" 'reserve
      data(15) = "" 'reserve
      data(16) = "" 'reserve
      data(17) = "" 'reserve
      data(18) = "" 'reserve
      Return data
    End Function
    Overridable Sub Deserialize(ByVal Data() As String, ByRef offset As Integer)
      ReDim Preserve Data(19)
      m_bounds.X = Data(2)
      m_bounds.Y = Data(3)
      m_bounds.Width = Data(4)
      m_bounds.Height = Data(5)
      OnBoundsChanged()
      ZIndex = Data(6)
      name = Data(7)
      created = Data(8)
      If Val(Data(9)) > 0 Then
        BorderWidth = Val(Data(9))
        borderPen.Color = Helper.String2Color(Data(10))
      End If
      If Data(11) = "V2" Then
        offset = 19
        Rotation = Val(Data(12))
        borderPen.DashStyle = Val(Data(13))
      Else
        offset = 11
      End If
    End Sub
    Overridable Sub Deserialize(ByVal Data() As String)
      Deserialize(Data, 0)
    End Sub

    Public Overridable Function HitTest(ByVal pnt As Point) As Boolean
      Return bounds.Contains(pnt)
    End Function

    Public Overridable Function HitTestResizer(ByVal pnt As Point) As VResizeDirection
      For i = 0 To 3
        If m_resizeBounds(i).Contains(pnt) Then Return i + 1
      Next
      Return VResizeDirection.None
    End Function

    Public Overridable Function HitTestRect(ByVal rct As Rectangle) As Boolean
      Return rct.Contains(bounds)
    End Function

    ' Sub setBorder(ByVal width As Integer, ByVal color As Color)
    '   If width = 0 Then borderPen = Nothing : Exit Sub
    '   borderPen = New Pen(color, width)
    ' End Sub

    Public Function HasBorder() As Boolean
      Return borderPen IsNot Nothing AndAlso borderPen.Width > 0
    End Function

    Public Sub DrawBorder(ByVal g As Graphics)
      If HasBorder() Then
        g.DrawRectangle(borderPen, bounds)
      End If
    End Sub
    Public Overridable Sub DrawSelection(ByVal g As Graphics)
      If isSelected Then
        g.DrawRectangle(selectionRectPen, bounds)
        For i = 0 To 3
          g.FillRectangle(ResizerBrsh, m_resizeBounds(i))
        Next
      End If
      If Parent.IsObjectBorderSelectionMode Then
        For i = 0 To 9
          g.DrawRectangle(Pens.Red, CSng(Left + Width * i / 10), Top + 1, 3, 3)
          g.DrawRectangle(Pens.Red, CSng(Left + Width * i / 10), bounds.Bottom - 4, 3, 3)
        Next
        For i = 0 To 9
          g.DrawRectangle(Pens.Red, Left + 1, CSng(Top + Height * i / 10), 3, 3)
          g.DrawRectangle(Pens.Red, bounds.Right - 4, CSng(Top + Height * i / 10), 3, 3)
        Next
      End If
    End Sub

  End Class

  '---------------------------------------------------------------------------------------

  <Microsoft.VisualBasic.ComClass()> Public Class VImage
    Inherits VObject
    Public img As Image
    Public source As String

    Protected Overrides Sub DrawObjectInternal(ByVal g As System.Drawing.Graphics)
      g.DrawImage(img, bounds)
      ' DrawBorder(g)
      'DrawSelection(g)
    End Sub

    Overrides Function ToHtml() As String
      Dim base64 = Helper.ImageToBase64(Me.img)
      Return MyBase.ToHtml & _
             "<img id=""" + name + """ alt=""Screenshot"" style=""position: absolute; " & GetHtmlRotation() & _
             "z-index: " & Me.ZIndex & "; margin-left: " & Me.bounds.X & "px; margin-top: " & Me.bounds.Y & "px; height: " & Me.bounds.Height & "px; width: " & Me.bounds.Width & "px; """ & _
             vbNewLine & "src=""" & base64 & """ />"
    End Function

    Public Overrides Sub Deserialize(ByVal Data() As String)
      Dim rOffset As Integer
      MyBase.Deserialize(Data, rOffset)
      ReDim Preserve Data(rOffset + 1)
      source = Data(rOffset + 0)
    End Sub

    Public Overrides Function Serialize() As String()
      Dim data() = MyBase.Serialize()
      ReDim Preserve data(CommonDataOffset + 1)
      data(CommonDataOffset + 0) = source
      Return data
    End Function

  End Class

  '---------------------------------------------------------------------------------------

  <Microsoft.VisualBasic.ComClass()> Public Class VTextbox
    Inherits VObject
    Private p_text As String
    Private fnt As Font
    Private brsh As SolidBrush = New SolidBrush(Color.Black)

    Property Text() As String
      Get
        Return p_text
      End Get
      Set(ByVal value As String)
        p_text = value
        OnContentChanged()
      End Set
    End Property

    Property Font() As Font
      Get
        Return fnt
      End Get
      Set(ByVal value As Font)
        fnt = value
        OnContentChanged()
      End Set
    End Property

    Protected Overrides Sub DrawObjectInternal(ByVal g As System.Drawing.Graphics)
      g.DrawString(Text, fnt, brsh, bounds) ', New StringFormat(StringFormatFlags.NoClip))
      'DrawBorder(g)
      'DrawSelection(g)
    End Sub

    Public Overrides Property Color1() As System.Drawing.Color
      Get
        Return brsh.Color
      End Get
      Set(ByVal value As System.Drawing.Color)
        brsh = New SolidBrush(value)
        OnContentChanged()
      End Set
    End Property

    Public Overrides Function ToHtml() As String
      Dim fontInfo = "font: "
      If fnt.Italic Then fontInfo &= "italic "
      If fnt.Bold Then fontInfo &= "bold "
      fontInfo &= Replace(Me.fnt.SizeInPoints, ",", ".") & "pt '" & Me.fnt.FontFamily.Name & "'"
      If fnt.Underline Or fnt.Strikeout Then fontInfo &= "; text-decoration:"
      If fnt.Underline Then fontInfo &= " underline"
      If fnt.Strikeout Then fontInfo &= " line-through"
      fontInfo &= ";"
      Dim htmlText = Me.Text
      htmlText = Replace(htmlText, "<", "&lt;")
      htmlText = Replace(htmlText, ">", "&gt;")
      htmlText = Replace(htmlText, vbNewLine, "<br/>")
      htmlText = Replace(htmlText, vbNewLine, "<br/>")
      Dim regx As New System.Text.RegularExpressions.Regex("http://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&amp;\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
      Dim matches = regx.Matches(htmlText)
      For Each match In matches
        htmlText = htmlText.Replace(match.Value, "<a href='" & match.Value & "'>" & match.Value & "</a>")
      Next

      Return MyBase.ToHtml() + "<div id=""" + name + """ style=""position: absolute; " & GetHtmlRotation() & _
                        "z-index: " & Me.ZIndex & "; margin-left: " & Me.bounds.X & "px; margin-top: " & Me.bounds.Y & "px; height: " & Me.bounds.Height & "px; width: " & Me.bounds.Width & "px; " & _
                        "" & fontInfo & " color: " & Helper.Color2HTMLString(DirectCast(Me.brsh, SolidBrush).Color) & "; "">" & _
      vbNewLine & htmlText & vbNewLine & "</div>"
    End Function

    Public Overrides Sub Deserialize(ByVal Data() As String)
      Dim rOffset As Integer
      MyBase.Deserialize(Data, rOffset)
      ReDim Preserve Data(rOffset + 5)
      Me.fnt = New Font(Data(rOffset + 0), Data(rOffset + 1), Data(rOffset + 2), GraphicsUnit.Point)
      Me.brsh = New SolidBrush(Helper.String2Color(Data(rOffset + 3)))
    End Sub

    Public Overrides Function Serialize() As String()
      Dim data() = MyBase.Serialize()
      ReDim Preserve data(CommonDataOffset + 5)
      data(CommonDataOffset + 0) = fnt.FontFamily.Name
      data(CommonDataOffset + 1) = fnt.SizeInPoints
      data(CommonDataOffset + 2) = CInt(fnt.Style)
      data(CommonDataOffset + 3) = Helper.Color2String(DirectCast(brsh, SolidBrush).Color)
      Return data
    End Function


  End Class

  '---------------------------------------------------------------------------------------

  <Microsoft.VisualBasic.ComClass()> Public Class VRectangle
    Inherits VObject
    Public fill As Brush = New SolidBrush(Color.Transparent)

    Protected Overrides Sub DrawObjectInternal(ByVal g As System.Drawing.Graphics)
      g.FillRectangle(fill, bounds)
      DrawBorder(g)
      'DrawSelection(g)
    End Sub

    Public Overrides Property Color2() As System.Drawing.Color
      Get
        Return DirectCast(fill, SolidBrush).Color
      End Get
      Set(ByVal value As System.Drawing.Color)
        DirectCast(fill, SolidBrush).Color = value
        OnContentChanged()
      End Set
    End Property

    Public Overrides Function ToHtml() As String
      Return MyBase.ToHtml() + "<div id=""" + name + """ style=""position: absolute; " & GetHtmlBorder() & GetHtmlRotation() & " background-color: " & Helper.Color2HTMLString(DirectCast(fill, SolidBrush).Color) & "; " & _
                        "z-index: " & Me.ZIndex & "; margin-left: " & Me.bounds.X & "px; margin-top: " & Me.bounds.Y & "px; height: " & Me.bounds.Height & "px; width: " & Me.bounds.Width & "px; " & _
                        """>" & "</div>"
    End Function

    Public Overrides Sub Deserialize(ByVal Data() As String)
      Dim rOffset As Integer
      MyBase.Deserialize(Data, rOffset)
      ReDim Preserve Data(rOffset + 1)
      Me.fill = New SolidBrush(Helper.String2Color(Data(rOffset + 0)))
    End Sub

    Public Overrides Function Serialize() As String()
      Dim data() = MyBase.Serialize()
      ReDim Preserve data(CommonDataOffset + 1)
      data(CommonDataOffset + 0) = Helper.Color2String(DirectCast(fill, SolidBrush).Color)
      Return data
    End Function


  End Class

  '---------------------------------------------------------------------------------------

  <Microsoft.VisualBasic.ComClass()> Public Class VLine
    Inherits VObject

    Private _linesStartCap, _linesEndCap As String

    Public startObject, endObject As String
    Public startDock, endDock As DockStyle
    Public startLocation, endLocation As Single

    Public Sub EnforceDockPosition()
      Dim so As VObject = Parent.GetObjectByID(startObject)
      If so IsNot Nothing Then
        Select Case startDock
          Case DockStyle.Top : SetStartLocation(so.Left + so.Width * startLocation, so.Top)
          Case DockStyle.Bottom : SetStartLocation(so.Left + so.Width * startLocation, so.bounds.Bottom)
          Case DockStyle.Left : SetStartLocation(so.Left, so.Top + so.Height * startLocation)
          Case DockStyle.Right : SetStartLocation(so.bounds.Right, so.Top + so.Height * startLocation)
        End Select
      End If
      Dim eo As VObject = Parent.GetObjectByID(endObject)
      If eo IsNot Nothing Then
        Select Case endDock
          Case DockStyle.Top : SetEndLocation(eo.Left + eo.Width * endLocation, eo.Top)
          Case DockStyle.Bottom : SetEndLocation(eo.Left + eo.Width * endLocation, eo.bounds.Bottom)
          Case DockStyle.Left : SetEndLocation(eo.Left, eo.Top + eo.Height * endLocation)
          Case DockStyle.Right : SetEndLocation(eo.bounds.Right, eo.Top + eo.Height * endLocation)
        End Select
      End If
    End Sub

    Public Sub SetStartLocation(ByVal x As Integer, ByVal y As Integer)
      Width += Left - x
      Height += Top - y
      Left = x
      Top = y
    End Sub
    Public Sub SetEndLocation(ByVal x As Integer, ByVal y As Integer)
      Width = -(Left - x)
      Height = -(Top - y)
    End Sub

    Public Overrides Property Rotation() As Integer
      Get
        Return 0
      End Get
      Set(ByVal value As Integer)
      End Set
    End Property

    Public Property LinesStartCap() As String
      Get
        Return _linesStartCap
      End Get
      Set(ByVal value As String)
        _linesStartCap = value
        If String.IsNullOrEmpty(value) Then
          borderPen.StartCap = LineCap.Flat
        Else
          borderPen.CustomStartCap = GetLineCapByString(value)
        End If
      End Set
    End Property
    Public Property LinesEndCap() As String
      Get
        Return _linesEndCap
      End Get
      Set(ByVal value As String)
        _linesEndCap = value
        If String.IsNullOrEmpty(value) Then
          borderPen.EndCap = LineCap.Flat
        Else
          borderPen.CustomEndCap = GetLineCapByString(value)
        End If
      End Set
    End Property

    Private Function GetLineCapByString(ByVal s As String) As Drawing2D.CustomLineCap
      Dim gp As New GraphicsPath
      Dim lines() As String = Split(s, "/")
      For Each line In lines
        Dim points() As String = Split(line, ";")
        ReDim Preserve points(4)
        gp.AddLine(CSng(Val(points(0))), CSng(Val(points(1))), CSng(Val(points(2))), CSng(Val(points(3))))
      Next
      Return New Drawing2D.CustomLineCap(Nothing, gp)
    End Function

    Public Overrides Function ToHtml() As String
      Dim len As Integer = Math.Sqrt((Width ^ 2) + (Height ^ 2))
      Dim lineAngle = GetLineAngle()
      Return MyBase.ToHtml() + "<div id=""" + name + """ style=""position: absolute; background-color: " & Helper.Color2HTMLString(borderPen.Color) & "; " & _
                        "z-index: " & Me.ZIndex & "; margin-left: " & Me.bounds.X & "px; margin-top: " & CInt(Me.bounds.Y - (BorderWidth / 2)) & "px; height: " & borderPen.Width & "px; width: " & len & "px; " & _
                        "transform: rotate(" & lineAngle & "deg); -moz-transform: rotate(" & lineAngle & "deg); -webkit-transform: rotate(" & lineAngle & "deg); -o-transform: rotate(" & lineAngle & "deg); " & _
                        "transform-origin: left top; -moz-transform-origin: left top; -webkit-transform-origin: left top; -o-transform-origin: left top; "">" & "</div>"
    End Function

    Public Function GetLineAngle() As Integer
      Return Math.Atan2(Height, Width) * (180 / Math.PI)   'Radiant->Grad

    End Function

    Protected Overrides Sub DrawObjectInternal(ByVal g As System.Drawing.Graphics)
      g.DrawLine(borderPen, bounds.X, bounds.Y, bounds.Right, bounds.Bottom)
      'DrawSelection(g)
      '  g.DrawString(GetLineAngle() & "°", FRM.Font, Brushes.Black, Left, Top)
    End Sub

    Public Overrides Sub DrawSelection(ByVal g As Graphics)
      If isSelected Then
        'g.DrawRectangle(selectionRectPen, bounds)
        g.FillRectangle(ResizerBrsh, m_resizeBounds(0))
        g.FillRectangle(ResizerBrsh, m_resizeBounds(3))
      End If
    End Sub

    Public Overrides Sub DrawMoveRect()
      Dim mr = Parent.PicBox.RectangleToScreen(Me.moveTempRect)
      ControlPaint.DrawReversibleLine(New Point(mr.Left, mr.Top), New Point(mr.Right, mr.Bottom), Color.White)
    End Sub

    Public Overrides Function HitTest(ByVal pnt As System.Drawing.Point) As Boolean
      If Math.Min(bounds.Left, bounds.Right) - borderPen.Width < pnt.X And Math.Max(bounds.Left, bounds.Right) + borderPen.Width > pnt.X And _
        Math.Min(bounds.Top, bounds.Bottom) - borderPen.Width < pnt.Y And Math.Max(bounds.Top, bounds.Bottom) + borderPen.Width > pnt.Y Then

        Dim dist = DistancePointLine(pnt.X, pnt.Y, bounds.Left, bounds.Top, bounds.Right, bounds.Bottom)
        If dist < 5 Then Return True
      End If
    End Function

    Public Overridable Function HitTestResizer(ByVal pnt As Point) As VResizeDirection
      If m_resizeBounds(0).Contains(pnt) Then Return 0 + 1
      If m_resizeBounds(3).Contains(pnt) Then Return 3 + 1
      Return VResizeDirection.None
    End Function

    Public Overrides Sub Deserialize(ByVal Data() As String)
      Dim rOffset As Integer
      MyBase.Deserialize(Data, rOffset)
      ReDim Preserve Data(rOffset + 8)
      LinesStartCap = Data(rOffset + 0)
      LinesEndCap = Data(rOffset + 1)
      startObject = Data(rOffset + 2)
      startDock = Val(Data(rOffset + 3))
      startLocation = Data(rOffset + 4)
      endObject = Data(rOffset + 5)
      endDock = Data(rOffset + 6)
      endLocation = Data(rOffset + 7)
    End Sub

    Public Overrides Function Serialize() As String()
      Dim data() = MyBase.Serialize()
      ReDim Preserve data(CommonDataOffset + 8)
      data(CommonDataOffset + 0) = LinesStartCap
      data(CommonDataOffset + 1) = LinesEndCap
      data(CommonDataOffset + 2) = startObject
      data(CommonDataOffset + 3) = startDock
      data(CommonDataOffset + 4) = startLocation
      data(CommonDataOffset + 5) = endObject
      data(CommonDataOffset + 6) = endDock
      data(CommonDataOffset + 7) = endLocation
      Return data
    End Function

    Private Function DistancePointLine(ByVal px As Integer, ByVal py As Integer, ByVal lx0 As Integer, ByVal ly0 As Integer, ByVal lx1 As Integer, ByVal ly1 As Integer) As Integer
      Return Math.Abs( _
             ((ly0 - ly1) * px + (lx1 - lx0) * py + (lx0 * ly1 - lx1 * ly0)) _
              / _
             (Math.Sqrt( _
                        (lx1 - lx0) ^ 2 + (ly1 - ly0) ^ 2 _
                        ) _
             ))
    End Function

  End Class

  '---------------------------------------------------------------------------------------

  <Microsoft.VisualBasic.ComClass()> Public Class VElipse
    Inherits VObject
    'Public color As Color
    Public fill As Brush = New SolidBrush(Color.Transparent)

    Public Overrides Property Color2() As System.Drawing.Color
      Get
        Return DirectCast(fill, SolidBrush).Color
      End Get
      Set(ByVal value As System.Drawing.Color)
        DirectCast(fill, SolidBrush).Color = value
        OnContentChanged()
      End Set
    End Property
    Public Overrides Function ToHtml() As String
      Return MyBase.ToHtml() + "<div style=""position: absolute; " & GetHtmlBorder() & _
                        "z-index: " & Me.ZIndex & "; margin-left: " & Me.bounds.X & "px; margin-top: " & Me.bounds.Y & "px; height: " & Me.bounds.Height & "px; width: " & Me.bounds.Width & "px; "">" & _
      vbNewLine & "Ellipse ;-)" & "</div>"
    End Function

    Protected Overrides Sub DrawObjectInternal(ByVal g As System.Drawing.Graphics)
      g.FillEllipse(fill, bounds)
      g.DrawEllipse(borderPen, bounds)
      'DrawSelection(g)
    End Sub

    Public Overrides Sub Deserialize(ByVal Data() As String)
      Dim rOffset As Integer
      MyBase.Deserialize(Data, rOffset)
      ReDim Preserve Data(rOffset + 1)
      Me.fill = New SolidBrush(Helper.String2Color(Data(rOffset + 0)))
    End Sub

    Public Overrides Function Serialize() As String()
      Dim data() = MyBase.Serialize()
      ReDim Preserve data(CommonDataOffset + 1)
      data(CommonDataOffset + 0) = Helper.Color2String(DirectCast(fill, SolidBrush).Color)
      Return data
    End Function
  End Class

  '---------------------------------------------------------------------------------------

  Public Enum VUMLVisibility
    [Public]
    [Protected]
    [Private]
  End Enum
  <Microsoft.VisualBasic.ComClass()> Public Class VUMLMethod
    Private p_IsShared As Boolean
    Private p_Name As String
    Private p_IsVoid As Boolean
    Private p_ReturnValue As String
    Private p_Parameters As New List(Of String())
    Private p_Visibility As VUMLVisibility
    Public Property IsShared() As Boolean
      Get
        Return p_IsShared
      End Get
      Set(ByVal value As Boolean)
        p_IsShared = value
      End Set
    End Property

    Public Property Name() As String
      Get
        Return p_Name
      End Get
      Set(ByVal value As String)
        p_Name = value
      End Set
    End Property
    Public Property IsVoid() As Boolean
      Get
        Return p_IsVoid
      End Get
      Set(ByVal value As Boolean)
        p_IsVoid = value
      End Set
    End Property
    Public Property ReturnValue() As String
      Get
        Return p_ReturnValue
      End Get
      Set(ByVal value As String)
        p_ReturnValue = value
      End Set
    End Property
    Public ReadOnly Property Parameters() As List(Of String())
      Get
        Return p_Parameters
      End Get
    End Property
    Public Property Visibility() As VUMLVisibility
      Get
        Return p_Visibility
      End Get
      Set(ByVal value As VUMLVisibility)
        p_Visibility = value
      End Set
    End Property

    Public ReadOnly Property ParameterName(ByVal idx As Integer) As String
      Get
        Return Parameters(idx)(0)
      End Get
    End Property
    Public ReadOnly Property ParameterType(ByVal idx As Integer) As String
      Get
        Return Parameters(idx)(1)
      End Get
    End Property
    Public ReadOnly Property ParameterCount() As Integer
      Get
        Return Parameters.Count
      End Get
    End Property
    Public Overrides Function ToString() As String
      Return If(Visibility = VUMLVisibility.Public, "+", If(Visibility = VUMLVisibility.Private, "-", "#")) + _
             "  " + If(IsVoid, "!", "?") + "  " + Name + " (" + GetParametersString() + ") " + If(IsVoid, "", " : " + ReturnValue)
    End Function
    Public Function GetParametersString() As String
      Dim para(Parameters.Count - 1) As String
      For i = 0 To para.Length - 1
        para(i) = Join(Parameters(i), " : ")
      Next
      Return Join(para, ", ")
    End Function
    Public Shared Function FromString(ByVal str As String) As VUMLMethod
      Dim d = System.Text.RegularExpressions.Regex.Match(str, "^\s*([+#-])\s*(\$?)\s*([\!\?])\s*([a-zA-Z0-9_-]+)\s*\(([^)]*)\)(\s*:\s*([a-zA-Z0-9_<>\[\]()-]+))?\s*$")
      If d.Success = False Then Return Nothing
      ' For Each xxxx In d.Groups
      ' Debug.Print(xxxx.index & " = " & xxxx.value)
      ' Next
      Dim m As New VUMLMethod
      Select Case d.Groups(1).Value
        Case "+" : m.Visibility = VUMLVisibility.Public
        Case "#" : m.Visibility = VUMLVisibility.Protected
        Case "-" : m.Visibility = VUMLVisibility.Private
      End Select
      m.Name = d.Groups(4).Value
      If d.Groups(3).Value = "?" And d.Groups(6).Success Then _
      m.ReturnValue = d.Groups(7).Value Else m.IsVoid = True
      If d.Groups(2).Value = "$" Then m.IsShared = True
      Dim params() As String = Split(d.Groups(5).Value, ",")
      For Each para In params
        Dim splitted() = Split(para, ":")
        If splitted.Length <> 2 Then Continue For
        splitted(0) = Trim(splitted(0)) : splitted(1) = Trim(splitted(1))
        m.Parameters.Add(splitted)
      Next
      Return m
    End Function
  End Class
  <Microsoft.VisualBasic.ComClass()> Public Class VUMLAttribute
    Private p_IsShared As Boolean
    Private p_Name As String
    Private p_Type As String
    Private p_Visibility As VUMLVisibility

    Public Property IsShared() As Boolean
      Get
        Return p_IsShared
      End Get
      Set(ByVal value As Boolean)
        p_IsShared = value
      End Set
    End Property

    Public Property Name() As String
      Get
        Return p_Name
      End Get
      Set(ByVal value As String)
        p_Name = value
      End Set
    End Property
    Public Property Type() As String
      Get
        Return p_Type
      End Get
      Set(ByVal value As String)
        p_Type = value
      End Set
    End Property
    Public Property Visibility() As VUMLVisibility
      Get
        Return p_Visibility
      End Get
      Set(ByVal value As VUMLVisibility)
        p_Visibility = value
      End Set
    End Property

    Public Overrides Function ToString() As String
      Return If(Visibility = VUMLVisibility.Public, "+", If(Visibility = VUMLVisibility.Private, "-", "#")) + _
             "  " + Name + " : " + Type
    End Function
    Public Shared Function FromString(ByVal str As String) As VUMLAttribute
      Dim d = System.Text.RegularExpressions.Regex.Match(str, "^\s*([+#-])\s*(\$?)\s*([a-zA-Z0-9_()\[\]-]+)\s*:\s*([a-zA-Z0-9_<>\[\]()-]+)\s*$")
      If d.Success = False Then Return Nothing
      Dim a As New VUMLAttribute
      Select Case d.Groups(1).Value
        Case "+" : a.Visibility = VUMLVisibility.Public
        Case "#" : a.Visibility = VUMLVisibility.Protected
        Case "-" : a.Visibility = VUMLVisibility.Private
      End Select
      If d.Groups(2).Value = "$" Then a.IsShared = True
      a.Name = d.Groups(3).Value
      a.Type = d.Groups(4).Value
      Return a
    End Function
  End Class

  <Microsoft.VisualBasic.ComClass()> Public Class VUMLClass
    Inherits VObject
    Public fill As Brush = New SolidBrush(Color.Transparent)

    Public Visibility As VUMLVisibility
    Public ClassName As String
    Public Methods As New List(Of VUMLMethod)
    Public Attributes As New List(Of VUMLAttribute)
    Public Subtitle As String

    Private Shared font1 As New Font("Microsoft Sans Serif", 12, FontStyle.Bold, GraphicsUnit.Point)
    Private Shared font2 As New Font("Microsoft Sans Serif", 8, FontStyle.Regular, GraphicsUnit.Point)

    Public ReadOnly Property Method(ByVal idx As Integer) As VUMLMethod
      Get
        Return Methods(idx)
      End Get
    End Property
    Public ReadOnly Property MethodCount() As Integer
      Get
        Return Methods.Count
      End Get
    End Property
    Public ReadOnly Property Attribute(ByVal idx As Integer) As VUMLAttribute
      Get
        Return Attributes(idx)
      End Get
    End Property
    Public ReadOnly Property AttributeCount() As Integer
      Get
        Return Attributes.Count
      End Get
    End Property

    Protected Overrides Sub DrawObjectInternal(ByVal g As System.Drawing.Graphics)
      Dim box1Height As Integer = 30 + If(String.IsNullOrEmpty(Subtitle), 0, 15)
      g.FillRectangle(Brushes.White, bounds)
      g.FillRectangle(fill, Left, Top, Width, box1Height)

      If HasBorder() Then g.DrawLine(borderPen, Left, Top + box1Height, bounds.Right, Top + box1Height)
      DrawBorder(g)

      g.DrawString(ClassName, font1, Brushes.White, Left + 3, Top + 3)
      g.DrawString(Subtitle, font2, Brushes.White, Left + 3, Top + 20)

      Dim yy = Top + box1Height + 4

      For Each v In Attributes
        Dim siz = g.MeasureString(v.ToString, font2, Width - 10)
        g.DrawString(v.ToString, font2, Brushes.Black, New Rectangle(Left + 3, yy, Width, siz.Height))
        yy += siz.Height + 3

      Next

      yy += 5
      If HasBorder() Then g.DrawLine(borderPen, Left, yy, bounds.Right, yy)
      yy += 5

      For Each v In Methods
        Dim siz = g.MeasureString(v.ToString, font2, Width - 10)
        g.DrawString(v.ToString, font2, Brushes.Black, New Rectangle(Left + 3, yy, Width, siz.Height))
        yy += siz.Height + 3

      Next

      'DrawSelection(g)
    End Sub

    Public Overrides Property Color2() As System.Drawing.Color
      Get
        Return DirectCast(fill, SolidBrush).Color
      End Get
      Set(ByVal value As System.Drawing.Color)
        DirectCast(fill, SolidBrush).Color = value
        OnContentChanged()
      End Set
    End Property

    Public Sub ParseHtmlContent(ByVal str As String)
      Dim LINES() = Split(str, vbNewLine)
      Dim block As Integer = 0
      For i = 0 To LINES.Length - 1
        Dim line = Helper.DecodeHtmlTags(Helper.StripHtmlTags(LINES(i)))

        If LINES(i).Contains("<!--Attr-->") Then block = 1
        If LINES(i).Contains("<!--Meth-->") Then block = 2

        If String.IsNullOrEmpty(line) Then Continue For

        If LINES(i).Contains("<!--Class-->") Then ClassName = line
        If LINES(i).Contains("<!--Subtitle-->") Then Subtitle = line


        If block = 1 Then
          Dim a = VUMLAttribute.FromString(line)
          If a IsNot Nothing Then Attributes.Add(a)
        End If
        If block = 2 Then
          Dim m = VUMLMethod.FromString(line)
          If m IsNot Nothing Then Methods.Add(m)
        End If

      Next
    End Sub

    Public Overrides Function ToHtml() As String
      Dim out As New System.Text.StringBuilder
      out.Append(MyBase.ToHtml)
      out.AppendLine("<div id=""" + name + """ style=""position: absolute; " & GetHtmlBorder() & GetHtmlRotation() & "  " & _
                        "z-index: " & Me.ZIndex & "; margin-left: " & Me.bounds.X & "px; margin-top: " & Me.bounds.Y & "px; height: " & Me.bounds.Height & "px; width: " & Me.bounds.Width & "px; " & _
                        """>")
      out.AppendLine("<p class='title' style='color:white; background-color: " & Helper.Color2HTMLString(DirectCast(fill, SolidBrush).Color) & ";'>")
      out.AppendLine("<!--Class--><b>" + Helper.EncodeHtmlTags(ClassName) + "</b>")
      out.AppendLine(If(Not String.IsNullOrEmpty(Subtitle), "<!--Subtitle--><br/>" + Helper.EncodeHtmlTags(Subtitle), ""))
      out.AppendLine("</p>")
      out.AppendLine("<!--Attr--><hr />")

      For Each v In Attributes
        out.AppendLine("<p>" + Helper.EncodeHtmlTags(v.ToString()) + "</p>")
      Next

      out.AppendLine("<!--Meth--><hr />")

      For Each v In Methods
        out.AppendLine("<p>" + Helper.EncodeHtmlTags(v.ToString()) + "</p>")
      Next
      out.AppendLine("</div>")
      Return out.ToString()
    End Function

    Public Overrides Sub Deserialize(ByVal Data() As String)
      Dim rOffset As Integer
      MyBase.Deserialize(Data, rOffset)
      ReDim Preserve Data(rOffset + 1)
      Me.fill = New SolidBrush(Helper.String2Color(Data(rOffset + 0)))
    End Sub

    Public Overrides Function Serialize() As String()
      Dim data() = MyBase.Serialize()
      ReDim Preserve data(CommonDataOffset + 1)
      data(CommonDataOffset + 0) = Helper.Color2String(DirectCast(fill, SolidBrush).Color)
      Return data
    End Function


  End Class



End Namespace