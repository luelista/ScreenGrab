Imports ColorPickerLib.ColorExtensions
Imports System.ComponentModel

<System.Drawing.ToolboxBitmapAttribute(GetType(ComboBox))> _
Public Class gColorComboBox
    Inherits ComboBox

#Region "Events"

    Public Event HoverSelect(ByVal sender As Object, ByVal ColorText As String, ByVal ColorValue As Color)

#End Region

#Region "Initialize"

    Public Sub New()
        MyBase.New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        DrawMode = DrawMode.OwnerDrawFixed
        AddHandler Me.DrawItem, New DrawItemEventHandler(AddressOf List_DrawItem)

        With Me
            .Items.Clear()
            Application.DoEvents()
            Dim cList As New List(Of Color)
            For Each s As String In [Enum].GetNames(GetType(KnownColor))
                If Not Color.FromName(s).IsSystemColor Then
                    cList.Add(Color.FromName(s))
                End If
            Next
            cList.Sort(AddressOf SortColors)
            For Each c As Color In cList
                Items.Add(c.Name)
            Next

            MaxDropDownItems = 20
            .Invalidate()
            .DropDownWidth = 150
            .AutoSize = False
            .Width = 100
            .DropDownStyle = ComboBoxStyle.DropDownList
            .DropDownHeight = 250
        End With
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

#End Region

#Region "Properties"
    Private _selectedColor As Color = Color.Black
    <Category("Appearance")> _
    Public Property SelectedColor() As Color
        Get
            Return _selectedColor
        End Get
        Set(ByVal Value As Color)
            _selectedColor = Color.FromName(GetNearestName(Value))
            Text = _selectedColor.Name
            Refresh()
        End Set
    End Property

    <Browsable(False)> _
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Shadows Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
        End Set
    End Property

    <EditorBrowsableAttribute(EditorBrowsableState.Never)> _
    Public Shadows Property SelectedText() As String
        Get
            Return String.Empty
        End Get
        Set(ByVal value As String)
        End Set
    End Property

    <EditorBrowsableAttribute(EditorBrowsableState.Never)> _
    Public Shadows Property SelectedValue() As Object
        Get
            Return Nothing
        End Get
        Set(ByVal value As Object)
        End Set
    End Property
#End Region

#Region "Draw Item"
    ' Handle the DrawItem event for an owner-drawn List.
    Private Sub List_DrawItem(ByVal sender As Object, _
        ByVal e As DrawItemEventArgs)

        If e.Index = -1 Then Exit Sub

        Dim CBox As ComboBox = CType(sender, ComboBox)
        Dim itemString As String = CType(CBox.Items(e.Index), String)

        Dim rect As Rectangle
        If (e.State And DrawItemState.ComboBoxEdit) = DrawItemState.ComboBoxEdit Then
            e.Graphics.FillRectangle(New SolidBrush(BackColor), e.Bounds)

        ElseIf (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            rect = New Rectangle(e.Bounds.X + 1, e.Bounds.Y, _
                e.Bounds.Width - 3, e.Bounds.Height - 2)
            e.Graphics.FillRectangle(Brushes.Beige, rect)
            e.Graphics.DrawRectangle(Pens.Blue, rect)
            RaiseEvent HoverSelect(Me, itemString, Color.FromName(itemString))

        Else
            e.Graphics.FillRectangle(New SolidBrush(BackColor), e.Bounds)
        End If

        'Draw a Color Swatch
        Using myBrush As New SolidBrush(Color.FromName(itemString))

            e.Graphics.FillRectangle(myBrush, e.Bounds.X + 3, e.Bounds.Y + 2, 20, e.Bounds.Height - 5)
            e.Graphics.DrawRectangle(Pens.Black, e.Bounds.X + 3, e.Bounds.Y + 2, 19, e.Bounds.Height - 6)

            ' Draw the text in the item.
            e.Graphics.DrawString(itemString, New Font("Microsoft Sans Serif", 8.25), _
                Brushes.Black, e.Bounds.X + 25, e.Bounds.Y + 1)
        End Using
    End Sub
#End Region

End Class



