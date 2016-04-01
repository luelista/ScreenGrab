Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Public Class VCanvasControl

  Protected WithEvents _canvas As Vector.Canvas

  <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
  Public WithEvents multitouch As TouchHelper

  Public insertRelationType As Integer, insertRelationStartObject As VObject, insertRelationStartPosition As Single, insertRelationStartDock As DockStyle
  Public modifyRelationObject As VLine
  Public borderSelectionMode As BorderSelMode

  Private _defaultColorSelected As Integer
  Public Shared defaultFont As Font
  Public defaultFg, defaultBg As Color
  Public toolboxSelElement As toolboxElement

  Public FileDialogInitialDirectory As String

  Event DirtyChanged()
  Event ElementInserted()
  Event ColorPicked()
  Event SelectionChanged(ByVal names() As String)
  Event FileSpecChanged()
  Event DefaultColorChanged()
  Event DocumentSaved()


  Public Shared lineWidth As Integer
  Public Shared lineStyle As DashStyle
  Public Shared defaultText As String
  Public Shared defaultArrowLength As Integer

  ReadOnly Property canvas() As Vector.Canvas
    Get
      Return _canvas
    End Get
  End Property

  Private _globAktFileSpec As String
  <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
  Public Property FileSpec() As String
    Get
      Return _globAktFileSpec
    End Get
    Set(ByVal value As String)
      _globAktFileSpec = value
      RaiseEvent FileSpecChanged()
    End Set
  End Property

  Enum BorderSelMode
    InsertRelationStart
    InsertRelationEnd
    ModifyRelationStart
    ModifyRelationEnd
  End Enum

  Private _dirty As Boolean
  <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
  Public Property Dirty() As Boolean
    Get
      Return _dirty
    End Get
    Set(ByVal value As Boolean)
      _dirty = value
      RaiseEvent DirtyChanged()
    End Set
  End Property

  Function CheckFileDirty() As Boolean
    If Dirty Then
      Select Case MsgBox("In diesem Dokument befinden sich ungespeicherte Änderungen. Möchten Sie diese jetzt speichern?", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Question)
        Case MsgBoxResult.Yes
          saveFile(False)
          Return Not Dirty
        Case MsgBoxResult.No
          Return True
        Case MsgBoxResult.Cancel
          Return False
      End Select
    Else
      Return True
    End If
  End Function


  Public Enum toolboxElement
    None
    Cursor = 1
    Textbox = 2
    Line = 3
    GaussianBlur = 4
    Rectangle = 5
    ColorPicker = 6
    Ellipse = 7
    Arrow = 8
    UmlClass = 9
  End Enum

  Public Sub New()

    ' This call is required by the Windows Form Designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.
    _canvas = New Vector.Canvas
    _canvas.PicBox = PictureBox1
    _canvas.EditTB = txtEditTB

    Try
      Dim filters() As String = IO.File.ReadAllLines("ConvolutionFilters.txt")
      For Each filterData In filters
        Dim d() As String = Split(filterData, vbTab)
        If d.Length < 12 Then Continue For
        Dim item As New ToolStripMenuItem(d(0))
        item.Tag = d
        AddHandler item.Click, AddressOf GaussianBlurToolStripMenuItem_Click
        ConvolutionFiltersexperimentellToolStripMenuItem.DropDownItems.Add(item)
      Next
    Catch ex As Exception

    End Try

    PictureBox1.Width = 2048 'Panel2.Width - 50
    PictureBox1.Height = 2048 'Panel2.Height - 50

    multitouch = TouchHelper.RegisterForTouch(Me.PictureBox1)
  End Sub
  Private Sub VCanvasControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    canvas.PicBox = PictureBox1
  End Sub



#Region "Canvas Events"

  Private Sub canvas_SelectionChanged() Handles _canvas.SelectionChanged

    Dim names(canvas.SelectionCount - 1) As String
    If canvas.SelectionCount > 0 Then
      Dim clr1, clr2 As Color
      clr1 = canvas.selectedObjects(0).Color1 : clr2 = canvas.selectedObjects(0).Color2
      For i = 0 To canvas.SelectionCount - 1
        names(i) = canvas.selectedObjects(i).name
        If clr1 <> canvas.selectedObjects(i).Color1 Then clr1 = Nothing
        If clr2 <> canvas.selectedObjects(i).Color2 Then clr2 = Nothing
      Next
      If clr1 = Nothing Then
        If DefaultColorSelected = 1 Then DefaultColorSelected = -1
        defaultFg = Color.Transparent
      Else
        If DefaultColorSelected = -1 Then DefaultColorSelected = 1
        defaultFg = clr1
      End If
      If clr2 = Nothing Then
        If DefaultColorSelected = 2 Then DefaultColorSelected = -1
        defaultBg = Color.Transparent
      Else
        If DefaultColorSelected = -1 Then DefaultColorSelected = 2
        defaultBg = clr2
      End If
    Else
      DefaultColorSelected = -1
    End If
    RaiseEvent DefaultColorChanged()
    RaiseEvent SelectionChanged(names)
    ' cmbElementNames.SelectedIndex = If(canvas.SelectionCount = 1, cmbElementNames.Items.IndexOf(canvas.selectedObjects(0).name), -1)
  End Sub

  Private Sub canvas_ContentChanged(ByVal inElement As Vector.VObject) Handles _canvas.ContentChanged
    Dirty = True
  End Sub

  Private Sub canvas_ContextMenu() Handles _canvas.ContextMenu
    canvas.SetContext(cmsCanvas.Items)
    cmsCanvas.Show(Cursor.Position)
  End Sub


  Private Sub canvas_ObjectBorderClicked(ByVal obj As Vector.VObject, ByVal border As System.Windows.Forms.DockStyle, ByVal location As Single) Handles _canvas.ObjectBorderClicked
    If borderSelectionMode = BorderSelMode.InsertRelationStart Then
      If obj IsNot insertRelationStartObject Then Exit Sub
      insertRelationStartPosition = location
      insertRelationStartDock = border
      borderSelectionMode = BorderSelMode.InsertRelationEnd

    ElseIf borderSelectionMode = BorderSelMode.InsertRelationEnd Then
      Dim line As New VLine
      line.name = "arrow_" & canvas.NextIndex()
      line.Color1 = defaultFg
      line.Color2 = defaultBg
      line.BorderWidth = 3
      line.borderPen.DashStyle = lineStyle

      line.LinesEndCap = Replace("0;0;-X;-X/0;0;X;-X/-X;-X;X;-X", "X", 3)

      line.startObject = insertRelationStartObject.name
      line.startDock = insertRelationStartDock
      line.startLocation = insertRelationStartPosition

      line.endObject = obj.name
      line.endDock = border
      line.endLocation = location

      canvas.addObject(line)
      RaiseEvent ElementInserted()

      line.EnforceDockPosition()
      canvas.IsObjectBorderSelectionMode = False

    ElseIf borderSelectionMode = BorderSelMode.ModifyRelationStart Then
      If obj Is modifyRelationObject Then Exit Sub
      modifyRelationObject.startObject = obj.name
      modifyRelationObject.startDock = border
      modifyRelationObject.startLocation = location
      modifyRelationObject.EnforceDockPosition()
      canvas.IsObjectBorderSelectionMode = False

    ElseIf borderSelectionMode = BorderSelMode.ModifyRelationEnd Then
      If obj Is modifyRelationObject Then Exit Sub
      modifyRelationObject.endObject = obj.name
      modifyRelationObject.endDock = border
      modifyRelationObject.endLocation = location
      modifyRelationObject.EnforceDockPosition()
      canvas.IsObjectBorderSelectionMode = False

    End If
  End Sub

  Private Sub canvas_InsertElement(ByVal rect As System.Drawing.Rectangle) Handles _canvas.InsertElement
    Select Case toolboxSelElement
      Case toolboxElement.Rectangle
        Dim obj As New VRectangle
        obj.name = "rect_" & canvas.NextIndex()
        obj.Color1 = defaultFg
        obj.Color2 = defaultBg
        obj.BorderWidth = lineWidth
        obj.borderPen.DashStyle = lineStyle
        obj.bounds = rect
        canvas.addObject(obj)
        RaiseEvent ElementInserted()

      Case toolboxElement.UmlClass
        Dim obj As New VUMLClass
        obj.name = "umlc_" & canvas.NextIndex()
        obj.Color1 = defaultFg
        obj.Color2 = defaultBg
        obj.BorderWidth = lineWidth
        obj.borderPen.DashStyle = lineStyle
        obj.bounds = rect
        Using dlg As New frm_editUmlClass
          dlg.SetClass(obj)
          If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            canvas.addObject(obj)
            canvas.Invalidate()
          End If
        End Using
        RaiseEvent ElementInserted()

      Case toolboxElement.Ellipse
        Dim obj As New VElipse
        obj.name = "eli_" & canvas.NextIndex()
        obj.Color1 = defaultFg
        obj.Color2 = defaultBg
        obj.BorderWidth = lineWidth
        obj.borderPen.DashStyle = lineStyle
        obj.bounds = rect
        canvas.addObject(obj)
        RaiseEvent ElementInserted()

      Case toolboxElement.Textbox
        Dim obj As New VTextbox
        obj.name = "textbox_" & canvas.NextIndex()
        obj.Color1 = defaultFg
        obj.Color2 = defaultBg
        obj.Font = defaultFont
        obj.Text = defaultText
        obj.bounds = rect
        canvas.addObject(obj)
        RaiseEvent ElementInserted()
        If canvas.IsInsertionMode = False Then canvas.startEditMode(obj)

      Case toolboxElement.Line
        Dim obj As New VLine
        obj.name = "line_" & canvas.NextIndex()
        obj.Color1 = defaultFg
        obj.Color2 = defaultBg
        obj.BorderWidth = lineWidth
        obj.borderPen.DashStyle = lineStyle
        obj.bounds = rect
        canvas.addObject(obj)
        RaiseEvent ElementInserted()

      Case toolboxElement.GaussianBlur
        Dim obj As New VFilter
        obj.name = "filter_" & canvas.NextIndex()
        obj.Color1 = defaultFg
        obj.Color2 = defaultBg
        obj.BorderWidth = lineWidth
        obj.borderPen.DashStyle = lineStyle
        obj.bounds = rect
        canvas.addObject(obj)
        'obj.ApplyMatrix(conv
        RaiseEvent ElementInserted()

      Case toolboxElement.Arrow
        Dim obj As New VLine
        obj.name = "arrow_" & canvas.NextIndex()
        obj.Color1 = defaultFg
        obj.Color2 = defaultBg
        obj.BorderWidth = lineWidth
        obj.borderPen.DashStyle = lineStyle

        Dim len As Single = defaultArrowLength
        If obj.BorderWidth = 1 And len < 8 Then len = 8
        If obj.BorderWidth = 2 And len < 5 Then len = 5
        If obj.BorderWidth = 3 And len < 4 Then len = 4
        If obj.BorderWidth = 4 And len < 3 Then len = 3
        obj.LinesEndCap = Replace("0;0;-X;-X/0;0;X;-X", "X", len)
        obj.bounds = rect
        canvas.addObject(obj)
        RaiseEvent ElementInserted()


    End Select
  End Sub

#End Region


#Region "Kontext-Menü"

  Private Sub insertRelation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ISTToolStripMenuItem.Click, KENNTToolStripMenuItem.Click, HATToolStripMenuItem.Click, KENNTToolStripMenuItem1.Click, ISTToolStripMenuItem1.Click, HATToolStripMenuItem1.Click
    borderSelectionMode = BorderSelMode.InsertRelationStart
    insertRelationStartObject = canvas.GetFirstSelectedObject
    canvas.IsObjectBorderSelectionMode = True
    insertRelationType = sender.tag
  End Sub
  Private Sub BeziehungsanfangAendernToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BeziehungsanfangAendernToolStripMenuItem.Click
    borderSelectionMode = BorderSelMode.ModifyRelationStart
    modifyRelationObject = canvas.GetFirstSelectedObject
    canvas.IsObjectBorderSelectionMode = True
  End Sub
  Private Sub BeziehungsendeAendernToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BeziehungsendeAendernToolStripMenuItem.Click
    borderSelectionMode = BorderSelMode.ModifyRelationEnd
    modifyRelationObject = canvas.GetFirstSelectedObject
    canvas.IsObjectBorderSelectionMode = True
  End Sub


  Private Sub LinieFormatierenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinieFormatierenToolStripMenuItem.Click
    For Each item In canvas.selectedObjects
      If LinieFormatierenToolStripMenuItem.Tag.contains(item.GetType.Name) = False Then MsgBox("Elemente vom Typ " + item.GetType.Name + " besitzen keine Linie.", MsgBoxStyle.Information) : Exit Sub
    Next
    Using ld As New frm_lineStyle
      ld.ShowForCanvas(canvas)
      ld.ShowDialog()
    End Using
  End Sub

  Private Sub SchriftartToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SchriftartToolStripMenuItem.Click
    Using fd As New FontDialog
      Try
        fd.Font = DirectCast(canvas.GetFirstSelectedObject(), VTextbox).Font
        If fd.ShowDialog = Windows.Forms.DialogResult.OK Then
          For i = 0 To canvas.selectedObjects.Count - 1
            DirectCast(canvas.selectedObjects(i), VTextbox).Font = fd.Font
          Next
          canvas.Invalidate()
        End If
      Catch ex As Exception
        MsgBox(ex.Message, MsgBoxStyle.Information, "Schriftart")
      End Try
    End Using
  End Sub

  Private Sub KopierenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KopierenToolStripMenuItem.Click
    canvas.CopySelection()
  End Sub

  Private Sub AusschneidenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AusschneidenToolStripMenuItem.Click
    canvas.CutSelection()
  End Sub

  Private Sub EinfügenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EinfuegenToolStripMenuItem.Click
    canvas.Paste()
  End Sub

  Private Sub DuplizierenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DuplizierenToolStripMenuItem.Click
    canvas.CopySelection()
    canvas.Paste()
  End Sub

  Private Sub LoeschenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoeschenToolStripMenuItem.Click
    While canvas.SelectionCount > 0
      canvas.removeObject(canvas.GetFirstSelectedObject())
    End While
  End Sub

  Private Sub KlasseneigenschaftenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KlasseneigenschaftenToolStripMenuItem.Click
    If canvas.GetSelectionType <> "VUMLClass" Or canvas.SelectionCount <> 1 Then Exit Sub
    Using dlg As New frm_editUmlClass
      dlg.SetClass(canvas.GetFirstSelectedObject())
      dlg.ShowDialog()
      canvas.Invalidate()
    End Using
  End Sub

  Private Sub AttributAddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AttributAddToolStripMenuItem.Click, ToolStripMenuItem8.Click
    If canvas.GetSelectionType <> "VUMLClass" Or canvas.SelectionCount <> 1 Then Exit Sub
    Using dlg As New frm_editUmlMember
      Dim v As VUMLClass = canvas.GetFirstSelectedObject()
      Dim a As New VUMLAttribute
      dlg.SetAttribute(a)
      If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
        v.Attributes.Add(a)
        canvas.Invalidate()
      End If
    End Using
  End Sub

  Private Sub MethodeAddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MethodeAddToolStripMenuItem.Click, ToolStripMenuItem9.Click
    If canvas.GetSelectionType <> "VUMLClass" Or canvas.SelectionCount <> 1 Then Exit Sub
    Using dlg As New frm_editUmlMember
      Dim v As VUMLClass = canvas.GetFirstSelectedObject()
      Dim m As New VUMLMethod
      dlg.SetMethod(m)
      If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
        v.Methods.Add(m)
        canvas.Invalidate()
      End If
    End Using
  End Sub

  Private Sub DrehenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrehenToolStripMenuItem.Click
    If canvas.SelectionCount = 0 Then Exit Sub
    Using dlg As New frm_rotateElement
      dlg.SetCanvas(canvas)
      dlg.ShowDialog()
    End Using
  End Sub

  Private Sub ZeichenbereichgrößeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZeichenbereichToolStripMenuItem.Click
    ShowCanvasProperties()
  End Sub

  Public Sub ShowCanvasProperties()
    Using dlg As New frm_canvasProperties
      dlg.SetCanvas(canvas)
      dlg.ShowDialog()
    End Using
    PictureBox1.Top = 0
    PictureBox1.Left = 0
    Panel2.ScrollControlIntoView(PictureBox1)
    Panel2.AutoScroll = False
    Panel2.AutoScroll = True

  End Sub

  Private Sub OriginalgroesseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OriginalgroesseToolStripMenuItem.Click
    For Each v In canvas.selectedObjects
      v.Width = DirectCast(v, VImage).img.Width
      v.Height = DirectCast(v, VImage).img.Height
    Next
  End Sub

  Private Sub BringToFrontToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BringToFrontToolStripMenuItem.Click
    canvas.MoveObjectZ(canvas.GetFirstSelectedObject, True, True)
  End Sub

  Private Sub SendToBackToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendToBackToolStripMenuItem.Click
    canvas.MoveObjectZ(canvas.GetFirstSelectedObject, False, True)
  End Sub

  Private Sub GruppierenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GruppierenToolStripMenuItem.Click
    canvas.groupSelection()
  End Sub

  Private Sub GruppierungAufhebenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GruppierungAufhebenToolStripMenuItem.Click
    canvas.ungroupSelection()
  End Sub

  Private Sub FarbverlaufZuweisenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FarbverlaufZuweisenToolStripMenuItem.Click
    Using f As New frm_setGradient
      f.SetCanvas(canvas)
      f.ShowDialog()
    End Using
  End Sub

  Private Sub GaussianBlurToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Try
      Dim img As IFilterableVectorObject = canvas.GetFirstSelectedObject()
      Dim m As New CSharpFilters.ConvMatrix()
      Dim inte(9) As Integer
      For i = 0 To 8 : inte(i) = sender.tag(i + 1) : Next
      m.SetAll(inte)
      m.Factor = sender.tag(10)
      m.Offset = sender.tag(11)
      img.ApplyMatrix(m)
      canvas.Invalidate()
    Catch ex As Exception
      MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Nicht möglich")
    End Try
  End Sub

#End Region


#Region "Alignment"
  Private Sub LeftsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeftsToolStripMenuItem.Click
    Dim pos As Integer = Integer.MinValue
    For Each item As VObject In canvas.selectedObjects
      If pos = Integer.MinValue Then pos = item.Left
      item.Left = pos
    Next
    canvas.Invalidate()
  End Sub

  Private Sub RightsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RightsToolStripMenuItem.Click
    Dim pos As Integer = Integer.MinValue
    For Each item As VObject In canvas.selectedObjects
      If pos = Integer.MinValue Then pos = item.bounds.Right
      item.Left = pos - item.Width
    Next
    canvas.Invalidate()
  End Sub

  Private Sub TopsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TopsToolStripMenuItem.Click
    Dim pos As Integer = Integer.MinValue
    For Each item As VObject In canvas.selectedObjects
      If pos = Integer.MinValue Then pos = item.Top
      item.Top = pos
    Next
    canvas.Invalidate()
  End Sub

  Private Sub BottomsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BottomsToolStripMenuItem.Click
    Dim pos As Integer = Integer.MinValue
    For Each item As VObject In canvas.selectedObjects
      If pos = Integer.MinValue Then pos = item.bounds.Bottom
      item.Top = pos - item.Height
    Next
    canvas.Invalidate()
  End Sub

  Private Sub MakeSameWidthToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MakeSameWidthToolStripMenuItem.Click
    Dim siz As Integer = Integer.MinValue
    For Each item As VObject In canvas.selectedObjects
      If siz = Integer.MinValue Then siz = item.Width
      item.Width = siz
    Next
    canvas.Invalidate()
  End Sub

  Private Sub MakeSameHeightToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MakeSameHeightToolStripMenuItem.Click
    Dim siz As Integer = Integer.MinValue
    For Each item As VObject In canvas.selectedObjects
      If siz = Integer.MinValue Then siz = item.Height
      item.Height = siz
    Next
    canvas.Invalidate()
  End Sub
#End Region

  Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
    If (toolboxSelElement = toolboxElement.ColorPicker) Then
      setCurrentDefaultColor(getScreenPixelColorFromCursor())
    End If
  End Sub
  Private Sub PictureBox1_Mouseup(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
    If (toolboxSelElement = toolboxElement.ColorPicker) Then
      RaiseEvent ColorPicked()
    End If
  End Sub

#Region "Default Color Management"

  <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
  Property DefaultColorSelected() As Integer
    Get
      Return _defaultColorSelected
    End Get
    Set(ByVal value As Integer)
      _defaultColorSelected = value
      RaiseEvent DefaultColorChanged()
    End Set
  End Property

  Sub setDefaultColor(ByVal id As Integer, ByVal newColor As Color)
    If getDefaultColor(id) = newColor Then Return
    Select Case id
      Case 1 : defaultFg = newColor
      Case 2 : Me.defaultBg = newColor
    End Select
    RaiseEvent DefaultColorChanged()
  End Sub

  Sub setCurrentDefaultColor(ByVal newColor As Color)
    If getDefaultColor(Me.DefaultColorSelected) = newColor Then Return
    setDefaultColor(Me.DefaultColorSelected, newColor)

    For i = 0 To Me.canvas.selectedObjects.Count - 1
      Dim obj = Me.canvas.selectedObjects(i)
      If Me.DefaultColorSelected = 1 Then
        obj.Color1 = newColor
      ElseIf Me.DefaultColorSelected = 2 Then
        obj.Color2 = newColor
      End If
    Next
    Me.canvas.Invalidate()
  End Sub

  Function getDefaultColor(ByVal id As Integer) As Color
    Select Case id
      Case 1 : Return Me.defaultFg
      Case 2 : Return Me.defaultBg
    End Select
  End Function
#End Region


  Private Sub PictureBox1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.Resize
    lblResizeHorz.Location = New Point(PictureBox1.Width + PictureBox1.Left, PictureBox1.Height / 2 - 6 + PictureBox1.Top)
    lblResizeVert.Location = New Point(PictureBox1.Width / 2 - 6 + PictureBox1.Left, PictureBox1.Height + PictureBox1.Top)
    lblResizeDiag.Location = New Point(PictureBox1.Width + PictureBox1.Left, PictureBox1.Height + PictureBox1.Top)
  End Sub

  'Private Sub lblResizeHorz_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblResizeHorz.MouseDown
  '  FormResizeTricky(PictureBox1.Handle, HitTestValues.HTRIGHT)
  '  PictureBox1.Top = 0
  '  PictureBox1.Left = 0
  '  Panel2.ScrollControlIntoView(PictureBox1)
  'End Sub

  'Private Sub lblResizeDiag_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblResizeDiag.MouseDown
  '  FormResizeTricky(PictureBox1.Handle, HitTestValues.HTBOTTOMRIGHT)
  '  PictureBox1.Top = 0
  '  PictureBox1.Left = 0
  '  Panel2.ScrollControlIntoView(PictureBox1)
  'End Sub

  'Private Sub lblResizeVert_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblResizeVert.MouseDown
  '  FormResizeTricky(PictureBox1.Handle, HitTestValues.HTBOTTOM)
  '  PictureBox1.Top = 0
  '  PictureBox1.Left = 0
  '  Panel2.ScrollControlIntoView(PictureBox1)
  'End Sub


#Region "Multitouch"

  Dim touchDownPoints(10) As Point
  Dim touchLastPoints(10) As Point
  Dim myObject As VObject

  Private Sub multitouch_Touchdown(ByVal sender As Object, ByVal e As TouchHelper.WMTouchEventArgs) Handles multitouch.Touchdown
    PrintMultitouchDebug("DOWN", e)
    If canvas.IsMultitouchMode = False Then Exit Sub

    Dim obj = canvas.GetObjectAt(New Point(e.LocationX, e.LocationY))
    If obj IsNot Nothing Then
      myObject = obj
      myObject.moveOrigRect = myObject.bounds
    End If

    touchDownPoints(e.Id) = New Point(e.LocationX, e.LocationY)
    touchLastPoints(e.Id) = New Point(e.LocationX, e.LocationY)



  End Sub

  Private Sub multitouch_Touchmove(ByVal sender As Object, ByVal e As TouchHelper.WMTouchEventArgs) Handles multitouch.Touchmove
    PrintMultitouchDebug("MOVE", e)
    If canvas.IsMultitouchMode = False Then Exit Sub
    If myObject Is Nothing Then Exit Sub

    touchLastPoints(e.Id) = New Point(e.LocationX, e.LocationY)

    Dim firstID As Integer = -1
    For i = 0 To touchDownPoints.Length - 1
      If touchDownPoints(i) = Nothing Then Continue For

      If firstID = -1 Then firstID = i : Continue For

      'If firstID <> -1 Then

      Dim dp1 = touchDownPoints(firstID)
      Dim dp2 = touchDownPoints(i)
      Dim lp1 = touchLastPoints(firstID)
      Dim lp2 = touchLastPoints(i)

      Dim distDP = Distance(dp1, dp2)
      Dim distLP = Distance(lp1, lp2)

      Dim distFactor = distLP / distDP

      Dim rct = myObject.moveOrigRect

      rct.Height *= distFactor
      rct.Width *= distFactor
      rct.X -= (rct.Width - myObject.moveOrigRect.Width) / 2
      rct.Y -= (rct.Height - myObject.moveOrigRect.Height) / 2
      myObject.bounds = rct
      PictureBox1.Refresh()


      'If myObject.moveTempRect <> Nothing Then
      '  ControlPaint.DrawReversibleFrame(PictureBox1.RectangleToScreen(myObject.moveTempRect), Color.White, FrameStyle.Dashed)
      'End If
      'myObject.moveTempRect = myObject.bounds
      'myObject.moveTempRect.Height *= distFactor
      'myObject.moveTempRect.Width *= distFactor
      'myObject.moveTempRect.X -= (myObject.moveTempRect.Width - myObject.Width) / 2
      'myObject.moveTempRect.Y -= (myObject.moveTempRect.Height - myObject.Height) / 2

      'frm_paletteFile.TextBox1.Text = dp1.ToString + vbNewLine + dp2.ToString + vbNewLine + lp1.ToString + vbNewLine + lp2.ToString + vbNewLine + vbNewLine + distDP.ToString + vbNewLine + distLP.ToString + vbNewLine + vbNewLine + distFactor.ToString

      '      ControlPaint.DrawReversibleFrame(PictureBox1.RectangleToScreen(myObject.moveTempRect), Color.White, FrameStyle.Dashed)

      Exit Sub
    Next

    If firstID > -1 Then
      Dim dp1 = touchDownPoints(firstID)
      Dim lp1 = touchLastPoints(firstID)

      Dim deltaX = dp1.X - lp1.X
      Dim deltaY = dp1.Y - lp1.Y

      Dim rct = myObject.moveOrigRect

      rct.X -= deltaX
      rct.Y -= deltaY

      myObject.bounds = rct
      PictureBox1.Refresh()



    End If

  End Sub

  Private Sub multitouch_Touchup(ByVal sender As Object, ByVal e As TouchHelper.WMTouchEventArgs) Handles multitouch.Touchup
    PrintMultitouchDebug("UP", e)
    If canvas.IsMultitouchMode = False Then Exit Sub
    'If myObject Is Nothing Then Exit Sub


    touchDownPoints(e.Id) = Nothing
    touchLastPoints(e.Id) = Nothing

    If myObject IsNot Nothing Then
      myObject.moveOrigRect = myObject.bounds
    End If
  End Sub

  Function Distance(ByVal p1 As Point, ByVal p2 As Point) As Integer
    Return Math.Sqrt((p1.X - p2.X) ^ 2 + (p1.Y - p2.Y) ^ 2)
  End Function

  Sub PrintMultitouchDebug(ByVal eventName As String, ByVal e As TouchHelper.WMTouchEventArgs)
    Dim graph As Graphics = PictureBox1.CreateGraphics

    Dim c1 As New Pen(ColorTranslator.FromOle(QBColor(e.Id)), 10)
    graph.DrawEllipse(c1, e.LocationX - 4, e.LocationY - 4, 8, 8)
    c1.Dispose()

    Dim flags As String
    If (e.Flags And TouchHelper.TOUCHEVENTF_MOVE) <> 0 Then flags += "MOVE "
    If (e.Flags And TouchHelper.TOUCHEVENTF_DOWN) <> 0 Then flags += "DOWN "
    If (e.Flags And TouchHelper.TOUCHEVENTF_UP) <> 0 Then flags += "UP "
    If (e.Flags And TouchHelper.TOUCHEVENTF_INRANGE) <> 0 Then flags += "INRANGE "
    If (e.Flags And TouchHelper.TOUCHEVENTF_PRIMARY) <> 0 Then flags += "PRIMARY "
    If (e.Flags And TouchHelper.TOUCHEVENTF_NOCOALESCE) <> 0 Then flags += "NOCOALESCE "
    If (e.Flags And TouchHelper.TOUCHEVENTF_PEN) <> 0 Then flags += "PEN "
    flags += ";"


    Dim info = "Location: " & e.LocationX & "x" & e.LocationY & vbNewLine & "Event: " & eventName & vbNewLine & "ID: " & e.Id & vbNewLine & "Flags: 0x" & Hex(e.Flags) & "  " & flags & vbNewLine & "Primary: " & e.IsPrimaryContact & vbNewLine & "Mask: " & e.Mask & vbNewLine & "Time: " & e.Time
    Dim size = graph.MeasureString(info, Me.Font)
    Dim rct As New Rectangle(e.LocationX + 20, e.LocationY + 20, size.Width, size.Height)
    Dim brshInfobox As New Drawing2D.LinearGradientBrush(rct, Color.AntiqueWhite, Color.LightYellow, Drawing2D.LinearGradientMode.BackwardDiagonal)
    graph.FillRectangle(brshInfobox, rct)
    brshInfobox.Dispose()
    graph.DrawString(info, Me.Font, Brushes.Black, e.LocationX + 20, e.LocationY + 20)

    'frm_paletteProperties.TextBox1.Text = info

    graph.Dispose()
  End Sub
#End Region

  Sub KeyboardHandler(ByVal e As KeyEventArgs)
    canvas.KeyboardHandler(e)

    If e.Alt And e.KeyCode = Keys.R Then
      DrehenToolStripMenuItem_Click(Nothing, EventArgs.Empty)
    End If
    If e.Alt And e.KeyCode = Keys.Enter Then
      Select Case canvas.GetSelectionType
        Case "VUMLClass"
          If canvas.SelectionCount = 1 Then KlasseneigenschaftenToolStripMenuItem_Click(Nothing, EventArgs.Empty)
        Case "VTextbox"
          SchriftartToolStripMenuItem_Click(Nothing, EventArgs.Empty)
      End Select
    End If
    If e.Alt And e.KeyCode = Keys.B Then
      If canvas.SelectionCount = 1 And canvas.GetSelectionType = "VUMLClass" Then
        cmsAddRelationMenu.Show(canvas.PicBox, canvas.GetFirstSelectedObject.bounds.Location)
      End If
    End If
    If e.Alt And (e.KeyCode = Keys.Add Or e.KeyCode = Keys.Oemplus) Then
      If canvas.SelectionCount = 1 And canvas.GetSelectionType = "VUMLClass" Then
        cmsAddUmlItemMenu.Show(canvas.PicBox, canvas.GetFirstSelectedObject.bounds.Location)
      End If
    End If
    If e.Alt And e.KeyCode = Keys.L Then
      LinieFormatierenToolStripMenuItem_Click(Nothing, EventArgs.Empty)
    End If
    If e.KeyCode = Keys.Escape Then
      canvas.DeselectAll()

    End If
    If e.KeyCode = Keys.F7 Then
      canvas.groupSelection()
    End If
    If e.KeyCode = Keys.F8 Then
      canvas.ungroupSelection()
    End If
    If e.KeyCode = Keys.F9 Then

    End If
  End Sub


  Sub openFile()
    If CheckFileDirty() Then
      Using ofd As New OpenFileDialog
        If String.IsNullOrEmpty(FileSpec) = False Then ofd.InitialDirectory = IO.Path.GetDirectoryName(FileSpec) Else ofd.InitialDirectory = FileDialogInitialDirectory
        ofd.Filter = "Alle unterstützten Dateiformate (*.html, *.htm, *.sgcollage)|*.html;*.htm;*.sgcollage|HTML-Dateien (*.html, *.htm)|*.html;*.htm|Screengrab-Collagen (*.sgcollage)|*.sgcollage|Alle Dateien|*.*"
        If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
          canvas.clearCanvas()
          FileSpec = ofd.FileName
          canvas.readHtmlPage(ofd.FileName)
        End If
      End Using
      Dirty = False
    End If
  End Sub
  Sub openFile(ByVal fileSpecToOpen As String)
    If CheckFileDirty() Then
      canvas.clearCanvas()
      FileSpec = fileSpecToOpen
      canvas.readHtmlPage(fileSpecToOpen)
      Dirty = False
    End If
  End Sub
  Function saveFile(ByVal saveAs As Boolean) As Boolean
    If String.IsNullOrEmpty(FileSpec) Or saveAs Then
      Using sfd As New SaveFileDialog
        '' If String.IsNullOrEmpty(FileSpec) = False Then sfd.FileName = FileSpec Else sfd.InitialDirectory = FileDialogInitialDirectory
        sfd.Filter = "Screengrab-Collagen (*.sgcollage)|*.sgcollage|HTML-Dateien (*.html, *.htm)|*.html;*.htm|Alle Dateien|*.*"
        If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
          FileSpec = sfd.FileName
        Else
          Exit Function
        End If
      End Using
    End If

    Try
      canvas.createHtmlPage(FileSpec)
      Dirty = False
      RaiseEvent DocumentSaved()

      'Catch ex As Win32Exception
      '  Dirty = True
      '  MsgBox("Beim Speichern des Dokuments ist ein Fehler aufgetreten." + vbNewLine + vbNewLine + ex.Message + " (0x" + ex.ErrorCode.ToString("x8") + ")", MsgBoxStyle.Critical)
    Catch ex As Exception
      Dirty = True
      MsgBox("Beim Speichern des Dokuments ist ein Fehler aufgetreten." + vbNewLine + vbNewLine + ex.tostring, MsgBoxStyle.Critical)
    End Try

  End Function


End Class
