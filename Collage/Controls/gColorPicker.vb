Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design

'Article Text http://www.codeproject.com/KB/miscctrl/ColorPickerControl.aspx
'Version 1.0 - October 2008. 
'Version 1.1 - October 2008.
'   Moved RaiseEvent ColorChanging(Me) out of the Sub UpdateColor and into the Value Set Property block
'   and removed the unnecessary code from the Sub UpdateColor to catch holes in the ColorChanging Event
'Version 1.2 - December 2008
'   Updated Code to comply with Option Strict turned On
'   Fixed small glitch in Initializing the control
'   Updated Mouse Events
'Version 1.3 - April 2009 
'   Added new custom RGB Trackbar Sliders 
'Version 1.4 - September 2011
'   Added CurrentColor and ClosestColorName to ColorPicked Event
'   Auto set Sat and Bright to 100 when color is black and Hue is Clicked
'   Removed the hardcoded KnownColor list and use the new SortColors function
'Version 1.5 - September 2011
'   Added Custom Cursor option to the EyeDropper
'Version 1.6 - September 2011
'   Added Demonstration of how to add gColorPicker to a ToolStrip

<ToolboxItem(True), ToolboxBitmap(GetType(gColorPicker), "ColorPickerLib.gColorPicker.bmp")> _
<Designer(GetType(ColorPickerDesigner))> _
<DefaultEvent("ColorPicked")> _
Public Class gColorPicker
    Implements ISupportInitialize

#Region "Declarations"
    Private ReadOnly ValueDisplay As Rectangle = New Rectangle(12, 5, 200, 25)
    Private ReadOnly bmpColorBar As Bitmap = New Bitmap(186, 26)
    Private bmpImg As Bitmap = New Bitmap(200, 25)
    Private ReadOnly bmpBrightBar As Image = New Bitmap(206, 26)
    Private CurrColor As Color = Color.Red
    Private ptColorPaint As Point
    Private ReadOnly ptColor As Point = New Point(12, 49)
    Private ReadOnly szColor As Size = New Size(180, 20)
    Private ptSatPaint As Point
    Private ReadOnly ptSat As Point = New Point(12, 88)
    Private ReadOnly szSat As Size = New Size(200, 20)
    Private ptBrightPaint As Point
    Private ReadOnly ptBright As Point = New Point(12, 126)
    Private ReadOnly szBright As Size = New Size(200, 20)
    Private blnMouseDnColor As Boolean
    Private blnMouseDnSat As Boolean
    Private blnMouseDnBright As Boolean
    Private blnMouseDnAlpha As Boolean
    Private sngXColor As Single = ptColor.X
    Private sngXSat As Single = (200 + ptSat.X)
    Private sngXBright As Single = (200 + ptBright.X)
    Private sngXAlpha As Single = (200 + ValueDisplay.X)
    Private AlphaColor As Color = Color.Transparent
    Private HideCursor As Cursor
    Private blnOnHold As Boolean = True
    Private Initializing As Boolean

#End Region

#Region "Events"

    Public Event ColorPicked(ByVal sender As Object, _
        ByVal CurrentColor As Color, ByVal ClosestColorName As String)

    Public Event ColorChanging(ByVal sender As Object, _
        ByVal CurrentColor As Color, ByVal ClosestColorName As String)

#End Region

#Region "Init"
    Private Sub BeginInit() Implements ISupportInitialize.BeginInit
        Initializing = True
    End Sub

    Private Sub EndInit() Implements ISupportInitialize.EndInit
        Initializing = False
    End Sub
#End Region

#Region "Initialize"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SetStyle(ControlStyles.DoubleBuffer, True)
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        CType(Me, ISupportInitialize).BeginInit()
        Value = Color.Red
        CType(Me, ISupportInitialize).EndInit()

        nudAlpha.Font = Control.DefaultFont
        nudHue.Font = Control.DefaultFont
        nudSat.Font = Control.DefaultFont
        nudBright.Font = Control.DefaultFont
        panSwatches2.Visible = False
        panSwatches.Width = 6
        Width = 266
    End Sub

    Private Sub ColorPicker_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        ptColorPaint = ptColor
        ptColorPaint.Offset(-3, -3)
        ptSatPaint = ptSat
        ptSatPaint.Offset(-3, -3)
        ptBrightPaint = ptBright
        ptBrightPaint.Offset(-3, -3)

        'Create the Hue Color Bar
        Dim colr As Color
        Dim g As Graphics = Graphics.FromImage(bmpColorBar)
        Dim cl As Integer = 3
        For c As Integer = 0 To 359 Step 2
            colr = HSBtoColor(c, 1, 1)
            g.DrawLine(New Pen(colr, 1), cl, 3, cl, szColor.Height + 2)
            cl += 1
        Next
        g.DrawRectangle(Pens.DarkGray, New Rectangle(0, 0, _
          szColor.Width + 5, szColor.Height + 5))

        'Create the Brightness Color Bar
        g = Graphics.FromImage(bmpBrightBar)
        Using br As LinearGradientBrush = New LinearGradientBrush(New Rectangle(2, 3, szBright.Width + 1, szBright.Height), _
          Color.Black, Color.White, LinearGradientMode.Horizontal)
            g.FillRectangle(br, New Rectangle(3, 3, szBright.Width, szBright.Height))
            g.DrawRectangle(Pens.DarkGray, New Rectangle(0, 0, szBright.Width + 5, szBright.Height + 5))
        End Using

        g.Dispose()
        blnOnHold = True

        ColorBox.DrawMode = DrawMode.OwnerDrawFixed
        AddHandler ColorBox.DrawItem, AddressOf ColorBox_DrawItem
        With ColorBox
            .Items.Clear()
            'Application.DoEvents()
            Dim cList As New List(Of Color)
            For Each s As String In [Enum].GetNames(GetType(KnownColor))
                If Not Color.FromName(s).IsSystemColor Then
                    cList.Add(Color.FromName(s))
                End If
            Next
            cList.Sort(AddressOf SortColors)
            For Each c As Color In cList
                .Items.Add(c.Name)
            Next
        End With

        ColorBox.SelectedIndex = 1

        'get the blank cursor to make the it dissapear when dragging
        Dim assem As Reflection.Assembly = Me.GetType().Assembly
        Dim my_namespace As String = assem.GetName().Name
        Dim mystream As IO.Stream
        Try
            mystream = assem.GetManifestResourceStream(my_namespace & ".HideCursor.cur")
            HideCursor = New Cursor(mystream)

        Catch ex As Exception
            HideCursor = Cursors.Cross
        End Try
        Try
            mystream = assem.GetManifestResourceStream(my_namespace & ".Lizardsml.jpg")
            bmpImg = CType(Image.FromStream(mystream), Bitmap)
        Catch ex As Exception
            Using hb As HatchBrush = New HatchBrush(HatchStyle.Shingle, Color.Black, Color.Transparent)
                Dim bmI As Graphics = Graphics.FromImage(bmpImg)
                bmI.FillRectangle(hb, 0, 0, 210, 30)
                bmI.Dispose()
            End Using
        End Try

    'AutoFlyOutToolStripMenuItem.Checked = CBool(_FlyOut)

        blnOnHold = False
    End Sub

    Private Function SortColors(ByVal x As Color, ByVal y As Color) As Integer
        'To use it first add all non-system colors to a List(Of Color), 
        'sort it by calling colors.Sort(AddressOf SortColors), 
        'then add all the list colors to the combo Items. 
        Dim huecompare As Integer = x.GetHue.CompareTo(y.GetHue)
        Dim satcompare As Integer = x.GetSaturation.CompareTo(y.GetSaturation)
        Dim brightcompare As Integer = x.GetBrightness.CompareTo(y.GetBrightness)
        If huecompare <> 0 Then
            Return huecompare
        ElseIf satcompare <> 0 Then
            Return satcompare
        ElseIf brightcompare <> 0 Then
            Return brightcompare
        Else
            Return 0
        End If
    End Function

#End Region 'Initialize

#Region "Properties"

    Private _Value As Color
    <Category("Appearance ColorPicker")> _
    <Description("The current Color selected")> _
    Public Property Value() As Color
        Get
            Return _Value
        End Get
        Set(ByVal value As Color)
            UpdateHSB(value)
            UpdateRGB(value)
            nudAlpha.Value = value.A
            _Value = value
            Invalidate(ValueDisplay)
            If Not Initializing Then
                RaiseEvent ColorChanging(Me, _Value, GetNearestName(_Value))
            End If
        End Set
    End Property

    Private _HideRGB As Boolean = True
    <Category("Appearance ColorPicker")> _
    <Description("Shows or Hides the RGB control box")> _
    Public Property HideRGB() As Boolean
        Get
            Return _HideRGB
        End Get

        Set(ByVal value As Boolean)
            _HideRGB = value
            If value = True Then
                Width = 266
            Else
                Width = 355
            End If
            Invalidate()
        End Set
    End Property

    Enum eFlyOut
        Auto = -1
        Click = 0
    End Enum
    Private _FlyOut As eFlyOut = eFlyOut.Auto
    <Category("Appearance ColorPicker")> _
    <Description("Does the FlyOut open on MouseOver or Click")> _
    <DefaultValue(eFlyOut.Auto)> _
    Public Property FlyOut() As eFlyOut
        Get
            Return _FlyOut
        End Get
        Set(ByVal value As eFlyOut)
            _FlyOut = value
        End Set
    End Property

#End Region 'Properties

#Region "Color Helpers"
    'Special thanks to Guillaume Leparmentier for his Great article
    'Manipulating colors in .NET - Part 1  http://www.codeproject.com/KB/recipes/colorspace1.aspx
    'I used some of his RGB/HSB code here with little modification

#Region "Color Structures"

    Public Structure RGB
#Region "Fields"

        Private _Red As Integer
        Private _Green As Integer
        Private _Blue As Integer

#End Region

#Region "Operators"

        Public Shared Operator =(ByVal item1 As RGB, ByVal item2 As RGB) As Boolean
            Return item1.Red = item2.Red AndAlso _
                   item1.Green = item2.Green AndAlso _
                   item1.Blue = item2.Blue
        End Operator

        Public Shared Operator <>(ByVal item1 As RGB, ByVal item2 As RGB) As Boolean
            Return item1.Red <> item2.Red OrElse _
                   item1.Green <> item2.Green OrElse _
                   item1.Blue <> item2.Blue
        End Operator

#End Region

#Region "Accessors"

        Public Property Red() As Integer
            Get
                Return _Red
            End Get
            Set(ByVal value As Integer)
                If value > 255 Then
                    _Red = 255
                Else
                    If value < 0 Then
                        _Red = 0
                    Else
                        _Red = value
                    End If
                End If
            End Set
        End Property

        Public Property Green() As Integer
            Get
                Return _Green
            End Get
            Set(ByVal value As Integer)
                If value > 255 Then
                    _Green = 255
                Else
                    If value < 0 Then
                        _Green = 0
                    Else
                        _Green = value
                    End If
                End If
            End Set
        End Property

        Public Property Blue() As Integer
            Get
                Return _Blue
            End Get
            Set(ByVal value As Integer)
                If value > 255 Then
                    _Blue = 255
                Else
                    If value < 0 Then
                        _Blue = 0
                    Else
                        _Blue = value
                    End If
                End If
            End Set
        End Property

#End Region

        ' Creates an instance of a RGB structure.
        Public Sub New(ByVal r As Integer, ByVal g As Integer, ByVal b As Integer)
            Red = r
            Green = g
            Blue = b
        End Sub

#Region "Methods"

        Public Overrides Function Equals(ByVal obj As Object) As Boolean
            If (obj Is Nothing) Or (Me.GetType() IsNot obj.GetType()) Then Return False
            Return (Me = CType(obj, RGB))
        End Function

        Public Overrides Function GetHashCode() As Integer
            Return CInt(Red.GetHashCode() ^ Green.GetHashCode() ^ Blue.GetHashCode())
        End Function

#End Region

    End Structure

    Public Structure HSB

#Region "Fields"

        Private _Hue As Double
        Private _Saturation As Double
        Private _Brightness As Double

#End Region

#Region "Operators"

        Public Shared Operator =(ByVal item1 As HSB, ByVal item2 As HSB) As Boolean
            Return item1.Hue = item2.Hue AndAlso _
                   item1.Saturation = item2.Saturation AndAlso _
                   item1.Brightness = item2.Brightness
        End Operator

        Public Shared Operator <>(ByVal item1 As HSB, ByVal item2 As HSB) As Boolean
            Return item1.Hue <> item2.Hue OrElse _
                   item1.Saturation <> item2.Saturation OrElse _
                   item1.Brightness <> item2.Brightness
        End Operator

#End Region

#Region "Accessors"

        Public Property Hue() As Double
            Get
                Return _Hue
            End Get
            Set(ByVal value As Double)
                If value > 360 Then
                    _Hue = 360
                Else
                    If value < 0 Then
                        _Hue = 0
                    Else
                        _Hue = value
                    End If
                End If
            End Set
        End Property

        Public Property Saturation() As Double
            Get
                Return _Saturation
            End Get
            Set(ByVal value As Double)
                If value > 1 Then
                    _Saturation = 1
                Else
                    If value < 0 Then
                        _Saturation = 0
                    Else
                        _Saturation = value
                    End If
                End If
            End Set
        End Property

        Public Property Brightness() As Double
            Get
                Return _Brightness
            End Get
            Set(ByVal value As Double)
                If value > 1 Then
                    _Brightness = 1
                Else
                    If value < 0 Then
                        _Brightness = 0
                    Else
                        _Brightness = value
                    End If
                End If
            End Set
        End Property

#End Region

        ' Creates an instance of a HSB structure.
        Public Sub New(ByVal h As Double, ByVal s As Double, ByVal b As Double)
            Hue = h
            Saturation = s
            Brightness = b
        End Sub

#Region "Methods"

        Public Overrides Function Equals(ByVal obj As Object) As Boolean
            If (obj Is Nothing) Or (Me.GetType() IsNot obj.GetType()) Then Return False
            Return (Me = CType(obj, HSB))
        End Function

        Public Overrides Function GetHashCode() As Integer
            Return CInt(Hue.GetHashCode() ^ Saturation.GetHashCode() ^ Brightness.GetHashCode())
        End Function

#End Region

    End Structure

#End Region 'Color Structures

#Region "RGBtoHSB"

    ' Converts RGB to a HSB.
    Public Shared Function RGBtoHSB(ByVal red As Integer, ByVal green As Integer, ByVal blue As Integer) As HSB

        Dim h As Double = 0.0
        Dim s As Double = 0.0

        ' normalizes red-green-blue values
        Dim nRed As Double = CDbl(red) / 255.0
        Dim nGreen As Double = CDbl(green) / 255.0
        Dim nBlue As Double = CDbl(blue) / 255.0

        Dim max As Double = Math.Max(nRed, Math.Max(nGreen, nBlue))
        Dim min As Double = Math.Min(nRed, Math.Min(nGreen, nBlue))

        ' Hue
        If (max = nRed) And (nGreen >= nBlue) Then
            If (max - min = 0) Then
                h = 0.0
            Else
                h = 60 * (nGreen - nBlue) / (max - min)
            End If
        ElseIf (max = nRed) And (nGreen < nBlue) Then
            h = 60 * (nGreen - nBlue) / (max - min) + 360
        ElseIf (max = nGreen) Then
            h = 60 * (nBlue - nRed) / (max - min) + 120
        ElseIf (max = nBlue) Then
            h = 60 * (nRed - nGreen) / (max - min) + 240
        End If

        If h > 359 Then h = 359

        ' Saturation
        If (max = 0) Then
            s = 0.0
        Else
            s = 1.0 - (min / max)
        End If

        Return New HSB(h, s, max)

    End Function

#End Region 'RGBtoHSB

#Region "HSBtoRGB"

    ' Converts HSB to RGB.
    Public Shared Function HSBtoRGB(ByVal HSB As HSB) As RGB
        Return HSBtoRGB(HSB.Hue, HSB.Saturation, HSB.Brightness)
    End Function

    ' Converts HSB to RGB.
    Public Shared Function HSBtoRGB(ByVal h As Integer, ByVal s As Integer, ByVal b As Integer) As RGB
        Return HSBtoRGB(CDbl(h), CDbl(s / 100.0), CDbl(b / 100.0))
    End Function

    ' Converts HSB to a RGB.
    Public Shared Function HSBtoRGB(ByVal h As Double, ByVal s As Double, ByVal b As Double) As RGB

        Dim red As Double = 0.0
        Dim green As Double = 0.0
        Dim blue As Double = 0.0

        If (s = 0) Then

            red = b
            green = b
            blue = b

        Else

            ' the color wheel consists of 6 sectors. Figure out which sector you're in.
            Dim sectorPos As Double = h / 60.0
            Dim sectorNumber As Integer = CInt(Math.Floor(sectorPos))
            ' get the fractional part of the sector
            Dim fractionalSector As Double = sectorPos - sectorNumber

            ' calculate values for the three axes of the color. 
            Dim p As Double = b * (1.0 - s)
            Dim q As Double = b * (1.0 - (s * fractionalSector))
            Dim t As Double = b * (1.0 - (s * (1 - fractionalSector)))

            ' assign the fractional colors to r, g, and b based on the sector the angle is in.
            Select Case sectorNumber
                Case 0
                    red = b
                    green = t
                    blue = p
                Case 1
                    red = q
                    green = b
                    blue = p
                Case 2
                    red = p
                    green = b
                    blue = t
                Case 3
                    red = p
                    green = q
                    blue = b
                Case 4
                    red = t
                    green = p
                    blue = b
                Case 5
                    red = b
                    green = p
                    blue = q
            End Select

        End If

        'Return New RGB(cint((Math.Ceiling(T(0) * 255.0)), _
        '               cint((Math.Ceiling(T(1) * 255.0)), _
        '               cint((Math.Ceiling(T(2) * 255.0)))

        Return New RGB(CInt(Double.Parse(String.Format("{0:0.00}", red * 255.0))), _
                       CInt(Double.Parse(String.Format("{0:0.00}", green * 255.0))), _
                       CInt(Double.Parse(String.Format("{0:0.00}", blue * 255.0))))


    End Function

#End Region 'HSBtoRGB

#Region "HSBtoColor"

    ' Converts HSB to .Net Color.
    Public Shared Function HSBtoColor(ByVal HSB As HSB) As Color
        Return HSBtoColor(HSB.Hue, HSB.Saturation, HSB.Brightness)
    End Function

    ' Converts HSB to a .Net Color.
    Public Shared Function HSBtoColor(ByVal h As Double, ByVal s As Double, ByVal b As Double) As Color
        Dim rgb As RGB = HSBtoRGB(h, s, b)
        Return Color.FromArgb(rgb.Red, rgb.Green, rgb.Blue)
    End Function

#End Region 'HSBtoColor

#End Region 'Color Helpers

#Region "Mouse Events"

    Private Sub ColorPicker_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseDown

        'Is the mouse clicked within one of the Color Bars or Alpha Pointer
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If ValueDisplay.Contains(e.Location) Then
                RaiseEvent ColorPicked(Me, _Value, GetNearestName(_Value))
            Else
                If New Rectangle(ptColor, szColor).Contains(e.Location) Then
                    blnMouseDnColor = True
                    If nudBright.Value = 0 AndAlso nudSat.Value = 0 AndAlso nudHue.Value = 0 Then
                        nudBright.Value = 100
                        nudSat.Value = 100
                    End If
                ElseIf New Rectangle(ptSat, szSat).Contains(e.Location) Then
                    blnMouseDnSat = True

                ElseIf New Rectangle(ptBright, szBright).Contains(e.Location) Then
                    blnMouseDnBright = True

                ElseIf GetAlphaPath(sngXAlpha).IsVisible(e.Location) Then
                    blnMouseDnAlpha = True
                End If
            End If

        End If
        MouseUpdate(e)
    End Sub

    Private Sub ColorPicker_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseMove

        'Switch the cursor to Hand if it is over the Color Display Rectangle
        If Cursor <> HideCursor AndAlso ValueDisplay.Contains(e.Location) Then
            Cursor = Cursors.Hand
        Else
            Cursor = Cursors.Default
        End If

        'If the mouse is over the Alpha Pointer fill with the Current Color
        If Not blnMouseDnAlpha Then
            If GetAlphaPath(sngXAlpha).IsVisible(e.Location) Then
                AlphaColor = Color.FromArgb(255, _Value.R, _Value.G, _Value.B)
                Invalidate(GetAlphaRect(sngXAlpha))
            Else
                AlphaColor = Color.Transparent
                Invalidate(GetAlphaRect(sngXAlpha))
            End If
        End If

        'Check to see if any of the Parts need to be Updated and Update if needed
        MouseUpdate(e)
    End Sub

    Private Sub ColorPicker_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseUp
        Cursor = Cursors.Default

        If blnMouseDnColor Then
            Invalidate(New Rectangle(ptSat.X - 4, ptSat.Y - 4, szSat.Width + 8, szSat.Height + 8))
        End If
        blnMouseDnColor = False
        blnMouseDnSat = False
        blnMouseDnBright = False
        blnMouseDnAlpha = False
    End Sub

    Sub MouseUpdate(ByVal e As MouseEventArgs)
        If blnMouseDnAlpha Then
            UpdateAlpha(e.X)
            nudAlpha.Value = CDec((sngXAlpha - ValueDisplay.X) / (ValueDisplay.Width / 255))
            UpdateColor()
        End If

        If blnMouseDnColor AndAlso nudBright.Value > 0 AndAlso nudSat.Value > 0 Then
            If New Rectangle(ptColor, szColor).Contains(e.Location) Then
                Cursor = HideCursor
                UpdateColorBar(e.X)
                nudHue.Value = CDec((sngXColor - ptColor.X) * 2)
            End If
            panHueSwatch.BackColor = HSBtoColor(nudHue.Value, 1, 1)
            UpdateColor()
        End If

        If blnMouseDnSat And nudBright.Value > 0 Then
            If New Rectangle(ptSat, szSat).Contains(e.Location) Then
                Cursor = HideCursor
                UpdateSatBar(e.X)
                nudSat.Value = CDec((sngXSat - ptSat.X) / 2)
            End If
            UpdateColor()
        End If

        If blnMouseDnBright Then
            If New Rectangle(ptBright, szBright).Contains(e.Location) Then
                Cursor = HideCursor
                UpdateBrightBar(e.X)
                nudBright.Value = CDec((sngXBright - ptBright.X) / 2)
            End If
            UpdateColor()
        End If

    End Sub

#End Region 'Mouse Events

#Region "Drawing"

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)

        Dim g As Graphics = e.Graphics

        'Draw Color Value
        g.FillRectangle(New TextureBrush(bmpImg, WrapMode.Tile), ValueDisplay)
        g.FillRectangle(New SolidBrush(Color.FromArgb(CInt(nudAlpha.Value), _
            _Value)), ValueDisplay)

        'Draw a rectangle around the ValueDisplay
        g.DrawRectangle(Pens.DarkGray, ValueDisplay.Location.X - 3, _
            ValueDisplay.Location.Y - 3, ValueDisplay.Width + 5, _
            ValueDisplay.Height + 5)

        'Draw the Alpha Pointer
        g.FillPath(New SolidBrush(AlphaColor), GetAlphaPath(sngXAlpha))
        g.DrawPath(Pens.Blue, GetAlphaPath(sngXAlpha))

        'Draw Hue Color Bar
        g.DrawImage(bmpColorBar, ptColorPaint)
        DrawSelector(g, New Rectangle(ptColor, szColor), _
            sngXColor, panHueSwatch.BackColor)

        'Draw Saturation Color Bar
        Using br As LinearGradientBrush = New LinearGradientBrush _
          (New Rectangle(ptSatPaint.X + 3, ptSatPaint.Y + 3, _
          szSat.Width, szSat.Height), _
          Color.White, CurrColor, LinearGradientMode.Horizontal)
            g.FillRectangle(br, New Rectangle( _
                ptSatPaint.X + 3, ptSatPaint.Y + 3, szSat.Width, szSat.Height))
            g.DrawRectangle(Pens.DarkGray, New Rectangle( _
                ptSatPaint.X, ptSatPaint.Y, szSat.Width + 5, szSat.Height + 5))
        End Using

        'DrawSelector
        DrawSelector(g, New Rectangle(ptSat, szSat), sngXSat, _
            HSBtoColor(nudHue.Value, nudSat.Value / 100, 1))

        'Draw Brightness Color Bar
        g.DrawImage(bmpBrightBar, ptBrightPaint)
        DrawSelector(g, New Rectangle(ptBright, szBright), sngXBright, _
            HSBtoColor(0, 0, nudBright.Value / 100))

    End Sub

    Private Sub UpdateColor()
        If Not blnOnHold Then

            Value = Color.FromArgb(CInt(nudAlpha.Value), HSBtoColor(nudHue.Value, nudSat.Value / 100, nudBright.Value / 100))
        End If
    End Sub

    Private Sub UpdateColorBar(ByVal xPos As Integer)
        InvalSelector(sngXColor, xPos, ptColor, szColor)
        If sngXColor > 179.5 + ptColor.X Then sngXColor = CSng(179.5 + ptColor.X)
        CurrColor = HSBtoColor((sngXColor - ptColor.X) * 2, 1, 1)
    End Sub

    Private Sub UpdateSatBar(ByVal xPos As Integer)
        InvalSelector(sngXSat, xPos, ptSat, szSat)
    End Sub

    Private Sub UpdateBrightBar(ByVal xPos As Integer)
        InvalSelector(sngXBright, xPos, ptBright, szBright)
    End Sub

    Private Sub InvalSelector(ByRef xPos1 As Single, ByVal xPos2 As Single, ByVal pt As Point, ByVal sz As Size)
        'Invalidate the old selector position, 
        'Check the current position, 
        'and Invalidate the new selector
        Invalidate(Rectangle.Union(Rectangle.Union( _
            New Rectangle(CInt(xPos1 - 3), pt.Y - 5, 6, 5), _
            New Rectangle(CInt(xPos1), pt.Y, 1, sz.Height)), _
            New Rectangle(CInt(xPos1 - 3), pt.Y + sz.Height, 6, 5)))

        If xPos2 < pt.X Then xPos2 = pt.X
        If xPos2 > pt.X + sz.Width Then xPos2 = pt.X + sz.Width
        xPos1 = xPos2

        Invalidate(Rectangle.Union(Rectangle.Union( _
            New Rectangle(CInt(xPos2 - 4), pt.Y - 5, 8, 5), _
            New Rectangle(CInt(xPos2), pt.Y, 1, sz.Height)), _
            New Rectangle(CInt(xPos2 - 4), pt.Y + sz.Height, 8, 5)))
    End Sub

    Private Sub DrawSelector(ByRef g As Graphics, ByRef rect As Rectangle, ByVal xPos As Single, ByVal fill As Color)
        g.DrawLine(Pens.White, xPos, rect.Top, xPos, rect.Bottom)
        g.FillEllipse(New SolidBrush(fill), xPos - 2, rect.Top - 5, 4, 4)
        g.DrawEllipse(Pens.Black, xPos - 2, rect.Top - 5, 4, 4)
        g.FillEllipse(New SolidBrush(fill), xPos - 2, rect.Bottom, 4, 4)
        g.DrawEllipse(Pens.Black, xPos - 2, rect.Bottom, 4, 4)
    End Sub

    Private Sub UpdateAlpha(ByVal xPos As Integer)
        Dim rect As Rectangle = GetAlphaRect(sngXAlpha)
        rect.Inflate(10, 10)
        rect.Offset(-5, -5)
        sngXAlpha = xPos
        If sngXAlpha - ValueDisplay.X < 0 Then sngXAlpha = ValueDisplay.X
        If sngXAlpha - ValueDisplay.X > 200 Then sngXAlpha = 200 + ValueDisplay.X
        Invalidate(rect)
    End Sub

    Private Function GetAlphaRect(ByVal xPos As Single) As Rectangle
        Return New Rectangle(CInt(xPos - 5), ValueDisplay.Bottom, 10, 8)
    End Function

    Private Function GetAlphaPath(ByVal xPos As Single) As GraphicsPath
        Dim rect As RectangleF = GetAlphaRect(xPos)
        Dim gp As New GraphicsPath
        gp.AddLine(rect.X + (rect.Width / 2), rect.Y, rect.X + rect.Width, rect.Y + rect.Height)
        gp.AddLine(rect.X + rect.Width, rect.Y + rect.Height, rect.X, rect.Y + rect.Height)
        gp.AddLine(rect.X, rect.Y + rect.Height, rect.X + (rect.Width / 2), rect.Y)
        gp.CloseFigure()
        Return gp
    End Function


#End Region 'Drawing

#Region "Control Events"

    Private Sub UpdateRGB(ByVal c As Color)
        GTBarRed.Value = c.R
        GTBarGreen.Value = c.G
        GTBarBlue.Value = c.B

    End Sub

    Private Sub UpdateHSB(ByVal c As Color)
        Dim cHSB As HSB = RGBtoHSB(c.R, c.G, c.B)
        'Dim br As Decimal = CDec(c.GetBrightness)
        nudHue.Value = CDec(cHSB.Hue)
        nudSat.Value = CDec(cHSB.Saturation * 100)
        nudBright.Value = CDec(cHSB.Brightness * 100)
        Invalidate(New Rectangle(ptSat.X - 4, ptSat.Y - 4, szSat.Width + 8, szSat.Height + 8))

    End Sub

    Private Sub ColorBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ColorBox.SelectedIndexChanged
        If Not blnOnHold Then
            UpdateRGB(Color.FromName(ColorBox.Text))
            UpdateHSB(Color.FromName(ColorBox.Text))
            panSwatches.Width = 6
            panSwatches.BorderStyle = Windows.Forms.BorderStyle.None
            panSwatches2.Visible = False
        End If
    End Sub

    Private Sub ColorPanels_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles Panel4.Click, Panel7.Click, Panel8.Click, Panel9.Click, Panel10.Click, Panel11.Click, _
        Panel12.Click, Panel13.Click, Panel20.Click, Panel19.Click, Panel14.Click, Panel15.Click, Panel16.Click, _
        Panel17.Click, Panel21.Click, Panel18.Click, Panel28.Click, Panel27.Click, Panel26.Click, Panel25.Click, _
        Panel24.Click, Panel23.Click, Panel6.Click, Panel29.Click, Panel5.Click, Panel48.Click, Panel47.Click, _
        Panel46.Click, Panel45.Click, Panel44.Click, Panel43.Click, Panel42.Click, Panel41.Click, Panel40.Click, _
        Panel22.Click, Panel39.Click, Panel38.Click, Panel37.Click, Panel36.Click, Panel35.Click, Panel34.Click, _
        Panel33.Click, Panel32.Click, Panel31.Click, Panel30.Click, Panel3.Click, Panel2.Click, Panel1.Click

        Dim pnl As Panel = CType(sender, Panel)
        UpdateRGB(pnl.BackColor)
        UpdateHSB(pnl.BackColor)
        panSwatches.Width = 6
        panSwatches.BorderStyle = Windows.Forms.BorderStyle.None
        panSwatches2.Visible = False
    End Sub

    Private CurrSwatch As Panel
    Private Sub ColorPanels_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) _
        Handles Panel5.MouseEnter, Panel7.MouseEnter, Panel8.MouseEnter, Panel9.MouseEnter, Panel3.MouseEnter, Panel11.MouseEnter, _
        Panel12.MouseEnter, Panel13.MouseEnter, Panel20.MouseEnter, Panel19.MouseEnter, Panel14.MouseEnter, Panel15.MouseEnter, _
         Panel16.MouseEnter, Panel17.MouseEnter, Panel21.MouseEnter, Panel18.MouseEnter, Panel28.MouseEnter, Panel27.MouseEnter, _
         Panel26.MouseEnter, Panel25.MouseEnter, Panel24.MouseEnter, Panel23.MouseEnter, Panel6.MouseEnter, Panel29.MouseEnter, _
         Panel22.MouseEnter, Panel48.MouseEnter, Panel47.MouseEnter, Panel46.MouseEnter, Panel45.MouseEnter, Panel44.MouseEnter, _
         Panel43.MouseEnter, Panel42.MouseEnter, Panel41.MouseEnter, Panel40.MouseEnter, Panel4.MouseEnter, Panel39.MouseEnter, _
         Panel38.MouseEnter, Panel37.MouseEnter, Panel36.MouseEnter, Panel35.MouseEnter, Panel34.MouseEnter, Panel33.MouseEnter, _
         Panel32.MouseEnter, Panel31.MouseEnter, Panel30.MouseEnter, Panel10.MouseEnter, Panel2.MouseEnter, Panel1.MouseEnter

        Dim pnl As Panel = CType(sender, Panel)
        Try
            CurrSwatch.BorderStyle = Windows.Forms.BorderStyle.Fixed3D
        Catch ex As Exception
        End Try
        CurrSwatch = pnl
        CurrSwatch.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
    End Sub

    Private Sub nudHue_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) _
        Handles nudHue.MouseUp, nudSat.MouseUp, nudBright.MouseUp
        UpdateColor()
    End Sub

    Private Sub nudHue_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudHue.ValueChanged
        If Not blnMouseDnColor Then
            blnOnHold = True
            UpdateColorBar(CInt(((nudHue.Value / 2) + ptColor.X)))
            Invalidate(New Rectangle(ptSat.X - 4, ptSat.Y - 4, szSat.Width + 8, szSat.Height + 8))
            panHueSwatch.BackColor = HSBtoColor(nudHue.Value, 1, 1)
            blnOnHold = False
        End If
    End Sub

    Private Sub nudSat_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudSat.ValueChanged
        If Not blnMouseDnSat Then
            blnOnHold = True
            UpdateSatBar(CInt(((nudSat.Value) * 2) + ptSat.X))
            blnOnHold = False
        End If
    End Sub

    Private Sub nudBright_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudBright.ValueChanged
        If Not blnMouseDnBright Then
            blnOnHold = True
            UpdateBrightBar(CInt(((nudBright.Value) * 2) + ptBright.X))
            blnOnHold = False
        End If
    End Sub

    Private Sub nudAlpha_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles nudAlpha.ValueChanged
        If Not blnMouseDnAlpha Then
            UpdateAlpha(CInt((nudAlpha.Value + ValueDisplay.X) * (ValueDisplay.Width / 255)))
        End If
        Dim rect As Rectangle = GetAlphaRect(sngXAlpha)
        rect.Inflate(10, 10)
        rect.Offset(-5, -5)
        Invalidate(rect)
        Invalidate(ValueDisplay)

    End Sub

    Private Sub tbar_Scroll(ByVal sender As Object, ByVal e As EventArgs) _
        Handles GTBarRed.ValueChanged, GTBarGreen.ValueChanged, GTBarBlue.ValueChanged

        If Not blnOnHold AndAlso Not blnMouseDnColor AndAlso Not blnMouseDnBright AndAlso Not blnMouseDnSat Then
            blnOnHold = True
            UpdateHSB(Color.FromArgb(GTBarRed.Value, CInt(GTBarGreen.Value), CInt(GTBarBlue.Value)))
            blnOnHold = False
        End If
        UpdateColor()
    End Sub

    'Private Sub nudRGB_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    '    Handles nudGreen.ValueChanged, nudBlue.ValueChanged
    '    tbarRed.Value = CInt(nudRed.Value)
    '    tbarGreen.Value = CInt(nudGreen.Value)
    '    tbarBlue.Value = CInt(nudBlue.Value)

    '    If Not blnOnHold AndAlso Not blnMouseDnColor AndAlso Not blnMouseDnBright AndAlso Not blnMouseDnSat Then
    '        blnOnHold = True
    '        UpdateHSB(Color.FromArgb(CInt(nudRed.Value), CInt(nudGreen.Value), CInt(nudBlue.Value)))
    '        blnOnHold = False
    '    End If
    'End Sub

    Private Sub panSwatches_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles panSwatches.Click
        If _FlyOut = eFlyOut.Click And panSwatches.Width = 6 Then
            OpenSwatchPanel()
        End If
    End Sub

    Private Sub panSwatches_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) Handles panSwatches.MouseEnter
        If _FlyOut = eFlyOut.Auto And panSwatches.Width = 6 Then
            OpenSwatchPanel()
        End If

    End Sub

    Private Sub OpenSwatchPanel()
        panSwatches2.Visible = True
        panSwatches.Width = 217
        panSwatches.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
        blnOnHold = True
        ColorBox.Text = ColorExtensions.GetNearestName(_Value)
        blnOnHold = False
    End Sub

    Private Sub CloseSwatchPanel()
        panSwatches.Width = 6
        panSwatches2.Visible = False
        panSwatches.BorderStyle = Windows.Forms.BorderStyle.None

    End Sub

    Private Sub butSwatchClose_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles butSwatchClose.Click
        CloseSwatchPanel()
    End Sub

    Private Sub panSwatches_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles panSwatches.Paint
        If panSwatches.Width = 6 Then

            Dim g As Graphics = panSwatches.CreateGraphics
            g.SmoothingMode = SmoothingMode.AntiAlias
            Dim gp As New GraphicsPath
            Dim rect As Rectangle = New Rectangle(0, 0, panSwatches.Width, panSwatches.Height)
            Using lgbr As LinearGradientBrush = New LinearGradientBrush(rect, Color.DarkBlue, Color.Transparent, LinearGradientMode.Horizontal)
                g.FillRectangle(lgbr, rect)
            End Using
            Dim pts() As Point = New Point() { _
                New Point(0, CInt((panSwatches.Height / 2) - 5)), _
                New Point(5, CInt((panSwatches.Height / 2))), _
                New Point(0, CInt((panSwatches.Height / 2) + 6)) _
                }
            g.FillPolygon(Brushes.White, pts)
            g.DrawPolygon(Pens.DarkBlue, pts)
            g.Dispose()
            gp.Dispose()
        End If
    End Sub

    Private Sub butSwatchClose_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles butSwatchClose.Paint
        e.Graphics.DrawString("X", butSwatchClose.Font, Brushes.White, 2, 1)
    End Sub

  'Private Sub AutoFlyOutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles AutoFlyOutToolStripMenuItem.Click
  '    AutoFlyOutToolStripMenuItem.Checked = Not AutoFlyOutToolStripMenuItem.Checked
  '    _FlyOut = CType(AutoFlyOutToolStripMenuItem.Checked, eFlyOut)
  'End Sub
#End Region

#Region "ColorBox - Custom Draw ListBoxItems"

    Private Sub ColorBox_DrawItem(ByVal sender As Object, _
        ByVal e As DrawItemEventArgs)

        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.Bounds)
        Else
            e.Graphics.FillRectangle(Brushes.White, e.Bounds)
        End If

        Dim cbox As ListBox = CType(sender, ListBox)
        Dim itemString As String = CStr(cbox.Items(e.Index))
        Dim rect As Rectangle = New Rectangle( _
            e.Bounds.X + 3, e.Bounds.Y + 2, _
            20, e.Bounds.Height - 5)

        Using MyFont As Font = New Font("Microsoft Sans Serif", 8.25), _
          myBrush As New SolidBrush(Color.FromName(itemString))
            'Draw a Color Swatch
            e.Graphics.FillRectangle(myBrush, rect)
            e.Graphics.DrawRectangle(Pens.Black, rect)
            ' Draw the text in the item.
            e.Graphics.DrawString(itemString, MyFont, Brushes.Black, _
                e.Bounds.X + 25, e.Bounds.Y + 1)
            ' Draw the focus rectangle around the selected item.
            e.DrawFocusRectangle()
        End Using
    End Sub

#End Region 'ColorBox

#Region "EyeDropper Events"

    Private Sub EyeDropper1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles EyeDropper1.MouseDown
        If chkAsCursor.Checked Then
            CloseSwatchPanel()
        End If
    End Sub

    Private Sub EyeDropper1_SelectedColorChanged(ByVal sender As Object, ByVal CurrColor As Color) Handles EyeDropper1.SelectedColorChanged
        Value = CurrColor
        CloseSwatchPanel()
    End Sub

    Private Sub EyeDropper1_SelectedColorChanging(ByVal sender As Object, ByVal CurrColor As Color) Handles EyeDropper1.SelectedColorChanging
        panEyedropper.BackColor = CurrColor
    End Sub

#End Region 'EyeDropper Events

    Private Sub chkAsCursor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAsCursor.CheckedChanged
        If chkAsCursor.Checked Then
            EyeDropper1.ZoomWindowType = gEyeDropper.eZoomWindowType.ShowOnCursor
            EyeDropper1.ShowSelectedSwatch = True
        Else
            EyeDropper1.ZoomWindowType = gEyeDropper.eZoomWindowType.ShowInPlace
            EyeDropper1.ShowSelectedSwatch = False
        End If
    End Sub

End Class

#Region "ColorPickerDesigner"

Public Class ColorPickerDesigner

    Inherits ControlDesigner

    Public Overrides ReadOnly Property SelectionRules() _
      As SelectionRules
        Get
            Return Windows.Forms.Design.SelectionRules.Visible _
                   Or Windows.Forms.Design.SelectionRules.Moveable
        End Get
    End Property


#Region "ActionLists"

    Private _Lists As DesignerActionListCollection

    Public Overrides ReadOnly Property ActionLists() As DesignerActionListCollection
        Get
            If _Lists Is Nothing Then
                _Lists = New DesignerActionListCollection
                _Lists.Add(New ColorPickerActionList(Component))
            End If
            Return _Lists
        End Get
    End Property

#End Region 'ActionLists

End Class

#Region "ColorPickerActionList"

Public Class ColorPickerActionList
    Inherits DesignerActionList

    Private ReadOnly _ColorPickerSelector As gColorPicker
    Private ReadOnly _DesignerService As DesignerActionUIService

    Public Sub New(ByVal component As IComponent)
        MyBase.New(component)

        ' Save a reference to the control we are designing.
        _ColorPickerSelector = DirectCast(component, gColorPicker)

        ' Save a reference to the DesignerActionUIService
        _DesignerService = _
            CType(GetService(GetType(DesignerActionUIService)), _
            DesignerActionUIService)

        'Makes the Smart Tags open automatically 
        AutoShow = True
    End Sub

#Region "Smart Tag Items"

#Region "Properties"

    Public Property Value() As Color
        Get
            Return _ColorPickerSelector.Value
        End Get
        Set(ByVal value As Color)
            SetControlProperty("Value", value)
        End Set
    End Property

    Public Property BackColor() As Color
        Get
            Return _ColorPickerSelector.BackColor
        End Get
        Set(ByVal value As Color)
            SetControlProperty("BackColor", value)
        End Set
    End Property

    Public Property HideRGB() As Boolean
        Get
            Return _ColorPickerSelector.HideRGB
        End Get
        Set(ByVal value As Boolean)
            SetControlProperty("HideRGB", value)
            _DesignerService.Refresh(_ColorPickerSelector)

        End Set
    End Property

    Public Property FlyOut() As gColorPicker.eFlyOut
        Get
            Return _ColorPickerSelector.FlyOut
        End Get
        Set(ByVal value As gColorPicker.eFlyOut)
            SetControlProperty("FlyOut", value)
        End Set
    End Property

#End Region 'Properties

    ' Set a control property. This method makes Undo/Redo
    ' work properly and marks the form as modified in the IDE.
    Private Sub SetControlProperty(ByVal property_name As String, ByVal value As Object)
        TypeDescriptor.GetProperties(_ColorPickerSelector) _
            (property_name).SetValue(_ColorPickerSelector, value)
    End Sub

#End Region ' Smart Tag Items

    ' Return the smart tag action items.
    Public Overrides Function GetSortedActionItems() As DesignerActionItemCollection
        Dim items As New DesignerActionItemCollection()

        items.Add( _
            New DesignerActionPropertyItem( _
                "HideRGB", _
                "Hide RGB Panel", _
                "Color Picker", _
                "Show or Hide RGB Panel"))
        items.Add( _
            New DesignerActionPropertyItem( _
                "FlyOut", _
                "Auto Color Flyout", _
                "Color Picker", _
                "Show FlyOut Automatically or with a MouseClick"))
        items.Add( _
            New DesignerActionPropertyItem( _
                "BackColor", _
                "Background Color", _
                "Color Picker", _
                "The Background Color of the Control"))

        items.Add( _
            New DesignerActionHeaderItem("Value"))
        items.Add( _
            New DesignerActionPropertyItem( _
                "Value", _
                "Current Value", _
                "Selected Color Value", _
                "The color currently selected"))

        'Add Text Item 
        items.Add( _
            New DesignerActionTextItem( _
                Space(28) & "Gonzo Diver", _
                " "))
        Return items
    End Function

End Class

#End Region 'DDPActionList

#End Region 'EyeDropper