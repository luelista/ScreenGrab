﻿Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.Drawing


Public Class Canvas
  Private p_objects As New List(Of VObject)
  Private p_selectionCount As Integer = 0
  Public selectedObjects As New List(Of VObject)

  Public ZIndexMin As Integer = 10000, ZIndexMax As Integer = 10000

  Public mouseDownPnt As Point, rubberBandActive As Boolean, rubberBandRect As Rectangle
  Public origCustom As Integer
  Public isMoveMode As Boolean = False
  Public resizeDirection As VResizeDirection = VResizeDirection.None

  Private WithEvents box As PictureBox
  Private WithEvents ownerForm As Form

  Private WithEvents msgFilter As New VCanvasLocalMessageFilter()

  Private _isInsertionMode As Boolean = False
  Private _isObjectBorderSelectionMode As Boolean = False
  Public IsLineDrawingMode As Boolean = False
  Public IsMultitouchMode As Boolean = False
  Public UseIntersectionForSelection As Boolean = False

  Public isEditMode As Boolean = False
  Public EditObject As VTextbox
  Public WithEvents EditTB As TextBox

  Public Event InsertElement(ByVal rect As Rectangle)
  Public Event ObjectBorderClicked(ByVal obj As VObject, ByVal border As DockStyle, ByVal location As Single)
  Public Event SelectionChanged()
  Public Event ContextMenu()
  Public Event ContentChanged(ByVal inElement As VObject)

  Public window As New vectorDOMWindow
  Dim domDocument As New vectorDOMDocument(Me)
  Public js As New Jint.JintEngine()
  ' Public globalIndexCounter As Long = 1

  Public Sub OnEvent(ByVal eventName As String, ByVal obj As VObject)
    If Not obj.onevent.ContainsKey(eventName) Then Return
    window.Document = domDocument
    Dim eventCode As String = obj.onevent(eventName)
    js.SetParameter("window", window)
    js.SetParameter("target", obj)
    js.SetParameter("eventName", eventName)
    Try
      js.Run(eventCode)
    Catch ex As Exception
      MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "JavaScript Error in """ + eventName + """ Event Handler")
    End Try

  End Sub

  Public Function NextIndex() As Long
    ''...counter müsste auch mit in HTML gespeichert werden - sonst doppelte IDs möglich
    ' Return System.Threading.Interlocked.Increment(globalIndexCounter)
    Return Now.Ticks
  End Function

  Friend Sub OnContentChanged(ByVal inElement As VObject)
    RaiseEvent ContentChanged(inElement)
  End Sub

  Public ReadOnly Property objects() As System.Collections.ObjectModel.ReadOnlyCollection(Of VObject)
    Get
      Return p_objects.AsReadOnly()
    End Get
  End Property
  ReadOnly Property SelectionCount() As Integer
    Get
      Return p_selectionCount
    End Get
  End Property

  Public Property IsInsertionMode() As Boolean
    Get
      Return _isInsertionMode
    End Get
    Set(ByVal value As Boolean)
      _isInsertionMode = value
      If value Then
        If isEditMode Then acceptEditMode()
        DeselectAll()
      End If
    End Set
  End Property
  Public Property IsObjectBorderSelectionMode() As Boolean
    Get
      Return _isObjectBorderSelectionMode
    End Get
    Set(ByVal value As Boolean)
      _isObjectBorderSelectionMode = value
      If value Then
        If isEditMode Then acceptEditMode()
        DeselectAll()
      End If
      Invalidate()
    End Set
  End Property

  Public Property PicBox() As PictureBox
    Get
      Return box
    End Get
    Set(ByVal value As PictureBox)
      box = value
      box.Image = Nothing
      box.BackgroundImage = Nothing
      'Application.RemoveMessageFilter(msgFilter)
      If box Is Nothing Then
        ownerForm = Nothing
      Else
        ownerForm = box.FindForm
        '  Application.AddMessageFilter(msgFilter)
      End If
    End Set
  End Property

  Sub KeyboardHandler(ByVal e As KeyEventArgs)

    If isEditMode Then
      If e.KeyCode = Keys.Escape Then
        cancelEditMode()
      End If
      Exit Sub
    End If

    If e.KeyCode = Keys.Delete Then
      Dim obj = GetFirstSelectedObject()
      If obj IsNot Nothing Then
        removeObject(obj)
      Else
        Beep()
      End If
    End If

    'If (e.Alt And e.KeyCode = Keys.Return) Or (e.Control And e.KeyCode = Keys.P) Then
    '  Dim obj = GetFirstSelectedObject()
    '  If obj IsNot Nothing Then
    '    showProperties(obj)
    '  End If
    'End If

    If e.Control And e.KeyCode = Keys.D Then
      Dim obj = GetFirstSelectedObject()
      If obj IsNot Nothing AndAlso TypeOf obj Is VImage Then
        Dim vi As VImage = obj
        'loadImage(vi.img)
      End If
    End If

    If e.Control And e.KeyCode = Keys.X Then
      CutSelection()
    End If

    If e.Control And e.KeyCode = Keys.C Then
      CopySelection()
    End If

    If e.Control And e.KeyCode = Keys.V Then
      Paste()
    End If

    'If (e.Control And e.KeyCode = Keys.E) Then
    '  Dim obj = GetFirstSelectedObject()
    '  If obj IsNot Nothing And TypeOf obj Is VTextbox Then
    '    showTextEditor(obj)
    '  End If
    'End If

    If Helper.IsArrowKey(e.KeyCode) Then
      Dim deltaX, deltaY As Integer
      Select Case e.KeyCode
        Case Keys.Left : deltaX = -1
        Case Keys.Right : deltaX = +1
        Case Keys.Up : deltaY = -1
        Case Keys.Down : deltaY = +1
      End Select
      If e.Control = True Then deltaX *= 10 : deltaY *= 10
      For i = 0 To p_objects.Count - 1
        If p_objects(i).isSelected Then
          If e.Shift Then
            p_objects(i).Width += deltaX
            p_objects(i).Height += deltaY
          Else
            p_objects(i).Left += deltaX
            p_objects(i).Top += deltaY
          End If
        End If
      Next
      Invalidate()
    End If

    If e.KeyCode = Keys.PageUp Then
      MoveObjectZ(GetFirstSelectedObject(), True, e.Control Or e.Alt)
    End If

    If e.KeyCode = Keys.PageDown Then
      MoveObjectZ(GetFirstSelectedObject(), False, e.Control Or e.Alt)
    End If

    If e.KeyCode = Keys.F12 Then
      Dim f As New frm_eventEditor
      f.setObject(Me, GetFirstSelectedObject)
      f.ShowDialog()
    End If
  End Sub

  Function GetObjectByID(ByVal id As String) As VObject
    If String.IsNullOrEmpty(id) Then Return Nothing
    For i = 0 To p_objects.Count - 1
      If p_objects(i).name = id Then
        Return p_objects(i)
      End If
    Next
    Return Nothing
  End Function

  Function GetObjectAt(ByVal pt As Point) As VObject
    For i = p_objects.Count - 1 To 0 Step -1
      If p_objects(i).HitTest(pt) Then
        Return p_objects(i)
      End If
    Next
    Return Nothing
  End Function

  Function GetFirstSelectedObject() As VObject
    If selectedObjects.Count > 0 Then Return selectedObjects(0)
  End Function

  Sub OnSelectionChanged()
    If isEditMode Then acceptEditMode()

    p_selectionCount = 0 : selectedObjects.Clear()
    For i = 0 To p_objects.Count - 1
      If p_objects(i).isSelected Then p_selectionCount += 1 : selectedObjects.Add(p_objects(i))
    Next

    RaiseEvent SelectionChanged()
    Me.Invalidate()
  End Sub

  Sub SelectObject(ByVal obj As VObject)
    For i = 0 To p_objects.Count - 1
      p_objects(i).isSelected = False
    Next
    obj.isSelected = True
    OnSelectionChanged()
    Invalidate()
  End Sub

  Sub startEditMode(ByVal tb As VTextbox)
    EditTB.Bounds = tb.absoluteBounds
    EditTB.Left -= 1 : EditTB.Top -= 2 : EditTB.Width += 4 : EditTB.Height += 4
    'EditTB.Top += 28
    tb.GetOuterBounds()
    EditTB.Text = tb.Text
    EditTB.Font = tb.Font
    EditTB.Show()
    EditTB.Focus()
    EditObject = tb
    isEditMode = True
  End Sub

  Sub acceptEditMode()
    If Not isEditMode Then Exit Sub
    EditObject.text = EditTB.Text
    EditTB.Hide()
    isEditMode = False
    If EditObject.text = "" Then removeObject(EditObject)
  End Sub

  Sub cancelEditMode()
    If Not isEditMode Then Exit Sub
    EditTB.Hide()
    isEditMode = False
  End Sub

  Function groupSelection() As Boolean
    If SelectionCount < 1 Then Return False
    cleanUpZIndex()
    Dim grp As New VGroup
    grp.name = "group_" & NextIndex()
    grp.subObjects.AddRange(selectedObjects)
    Dim firstObj = GetFirstSelectedObject()
    Dim insPos = p_objects.IndexOf(firstObj)
    DeselectAll()
    grp.ZIndex = firstObj.ZIndex
    Dim groupBounds = firstObj.bounds
    For Each objInGrp In grp.subObjects
      groupBounds = Rectangle.Union(groupBounds, objInGrp.bounds)
      removeObject(objInGrp)
      objInGrp.Parent = Me : objInGrp.Group = grp
    Next
    grp.bounds = groupBounds
    For Each objInGrp In grp.subObjects
      objInGrp.MoveByOffset(-groupBounds.X, -groupBounds.Y)
    Next
    grp.Parent = Me
    SyncLock p_objects
      p_objects.Insert(insPos, grp)
    End SyncLock
    RaiseEvent ContentChanged(grp)
    'addObject(grp)
    SelectObject(grp)
    'orderByZIndex()
  End Function
  Sub ungroupSelection()
    If SelectionCount <> 1 Then Return
    Dim obj = GetFirstSelectedObject()
    If Not TypeOf obj Is VGroup Then Return
    Dim group As VGroup = obj

    SyncLock p_objects
      Dim insPos As Integer = p_objects.IndexOf(group)
      Dim translate = group.bounds.Location
      For i = group.subObjects.Count - 1 To 0 Step -1
        p_objects.Insert(insPos, group.subObjects(i))
        group.subObjects(i).MoveByOffset(translate.X, translate.Y)
        group.subObjects(i).isSelected = True
        group.subObjects(i).Group = Nothing
        OnContentChanged(group.subObjects(i))
      Next
    End SyncLock

    removeObject(group)
    cleanUpZIndex()
    OnSelectionChanged()
    Invalidate()
  End Sub

  Private Sub box_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles box.MouseDoubleClick
    If IsInsertionMode Or IsObjectBorderSelectionMode Or IsLineDrawingMode Then Exit Sub
    Dim selObj = GetFirstSelectedObject()
    If selObj IsNot Nothing Then
      If TypeOf selObj Is VTextbox Then
        startEditMode(selObj)
        Exit Sub
      End If

      If TypeOf selObj Is VGroup Then
        For Each tx In DirectCast(selObj, VGroup).subObjects
          If TypeOf tx Is VTextbox AndAlso tx.HitTest(New Point(e.Location.X, e.Location.Y)) Then
            startEditMode(tx)
            Exit Sub
          End If
        Next
      End If

      Me.OnEvent("ondblclick", selObj)
    End If
  End Sub

  Private Sub box_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles box.MouseDown
    If isEditMode Then acceptEditMode()
    If IsMultitouchMode Then Exit Sub

    mouseDownPnt = e.Location

    isMoveMode = False
    resizeDirection = VResizeDirection.None

    rubberBandActive = False
    rubberBandRect = Nothing

    If IsInsertionMode Or _isObjectBorderSelectionMode Then Exit Sub

    Dim selObj = GetFirstSelectedObject()
    If selObj IsNot Nothing Then
      Dim resize = selObj.HitTestResizer(e.Location)
      resizeDirection = resize
      If resize = VResizeDirection.Rotation Then origCustom = selObj.Rotation
      If resize = VResizeDirection.Custom1 Then origCustom = DirectCast(selObj, ICustomResizableObject).CustomResizableProperty1
      If resize = VResizeDirection.Custom2 Then origCustom = DirectCast(selObj, ICustomResizableObject).CustomResizableProperty2

      ''''    MDI.Text = resizeDirection.ToString
    End If

    If resizeDirection = VResizeDirection.None Then
      'wenn nicht resize, dann vielleicht verschieben???

      Dim clickObj = GetObjectAt(e.Location)
      If clickObj IsNot Nothing Then 'AndAlso clickObj.isSelected
        If isKeyPressed(Keys.ControlKey) Then
          clickObj.isSelected = Not clickObj.isSelected
          OnSelectionChanged()
        Else
          If Not clickObj.isSelected Then SelectObject(clickObj)
          isMoveMode = True

          Me.OnEvent("onmousedown", clickObj)

        End If
      End If
    End If

    
  End Sub

  'window.alert("Hallo Welt");

  Private Sub box_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles box.MouseMove
    If IsMultitouchMode Or _isObjectBorderSelectionMode Then Exit Sub

    If e.Button <> MouseButtons.Left Then Exit Sub

    If isMoveMode Then
      For i = 0 To selectedObjects.Count - 1
        Dim obj = selectedObjects(i)
        If obj.moveTempRect <> Nothing Then
          obj.DrawMoveRect()
        End If
        obj.moveTempRect = obj.bounds
        obj.moveTempRect.Offset(e.Location - mouseDownPnt)
        obj.DrawMoveRect()
      Next

    ElseIf resizeDirection = VResizeDirection.Rotation Then
      Dim delta As Integer = mouseDownPnt.Y - e.Location.Y
      Dim obj = GetFirstSelectedObject()
      If isKeyPressed(Keys.ControlKey) Then
        obj.Rotation = ((origCustom + delta) \ 15) * 15
      Else
        obj.Rotation = (origCustom + delta)
      End If
      Invalidate()

    ElseIf resizeDirection = VResizeDirection.Custom1 Then
      Dim delta As Integer = e.Location.X - mouseDownPnt.X
      Dim obj As ICustomResizableObject = GetFirstSelectedObject()
      obj.CustomResizableProperty1 = origCustom + delta
      Invalidate()

    ElseIf resizeDirection = VResizeDirection.Custom1 Then
      Dim delta As Integer = e.Location.X - mouseDownPnt.X
      Dim obj As ICustomResizableObject = GetFirstSelectedObject()
      obj.CustomResizableProperty2 = origCustom + delta
      Invalidate()

    ElseIf resizeDirection <> VResizeDirection.None Then
      Dim obj = GetFirstSelectedObject()
      If obj.moveTempRect <> Nothing Then
        obj.DrawMoveRect()
      End If
      obj.moveTempRect = Helper.GetResizedRect(obj.bounds, resizeDirection, mouseDownPnt, e.Location)

      obj.DrawMoveRect()


    ElseIf rubberBandActive OrElse Helper.PointDistance(mouseDownPnt, e.Location) > 5 Then
      rubberBandActive = True
      If rubberBandRect <> Nothing Then
        DrawRubberBand()
      End If
      rubberBandRect = Helper.MakeRect(mouseDownPnt.X, mouseDownPnt.Y, e.X, e.Y, IsLineDrawingMode)
      DrawRubberBand()
    End If
  End Sub

  Private Sub DrawRubberBand()
    Dim rr = box.RectangleToScreen(rubberBandRect)
    If IsLineDrawingMode Then
      ControlPaint.DrawReversibleLine(New Point(rr.Left, rr.Top), New Point(rr.Right, rr.Bottom), Color.White)
    Else
      ControlPaint.DrawReversibleFrame(rr, Color.White, FrameStyle.Dashed)
    End If
  End Sub

  Private Sub box_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles box.MouseUp
    If IsMultitouchMode Then Exit Sub

    If IsObjectBorderSelectionMode Then
      Dim obj = GetObjectAt(e.Location)
      If obj IsNot Nothing Then
        Dim x = e.X - obj.Left, y = e.Y - obj.Top
        If x < 10 Then RaiseEvent ObjectBorderClicked(obj, DockStyle.Left, y / obj.Height) : Exit Sub
        If y < 10 Then RaiseEvent ObjectBorderClicked(obj, DockStyle.Top, x / obj.Width) : Exit Sub
        If x > obj.Width - 10 Then RaiseEvent ObjectBorderClicked(obj, DockStyle.Right, y / obj.Height) : Exit Sub
        If y > obj.Height - 10 Then RaiseEvent ObjectBorderClicked(obj, DockStyle.Bottom, x / obj.Width) : Exit Sub
      End If
      Exit Sub
    End If

    If e.Button = MouseButtons.Left Then
      If rubberBandActive Then
        rubberBandActive = False
        If rubberBandRect <> Nothing Then
          ControlPaint.DrawReversibleFrame(box.RectangleToScreen(rubberBandRect), Color.White, FrameStyle.Dashed)
        End If

        Dim rct As Rectangle = rubberBandRect

        If IsInsertionMode Then
          RaiseEvent InsertElement(rct)
          Exit Sub
        End If

        Dim ctrlKey = isKeyPressed(Keys.ControlKey)

        For i = 0 To p_objects.Count - 1          ' if ctrlKey: leave already selected objects selected...
          p_objects(i).isSelected = (ctrlKey And p_objects(i).isSelected) _
                OrElse p_objects(i).HitTestRect(rct, Me.UseIntersectionForSelection)
        Next
        OnSelectionChanged()

      ElseIf isMoveMode Then
        For i = 0 To selectedObjects.Count - 1
          Dim obj = selectedObjects(i)
          If obj.moveTempRect <> Nothing Then
            obj.DrawMoveRect()
            obj.bounds = obj.moveTempRect
            obj.moveTempRect = Nothing
          Else
            Me.OnEvent("onclick", obj)
          End If
          Me.OnEvent("onmouseup", obj)
        Next

      ElseIf resizeDirection <> VResizeDirection.None Then
        Dim obj = GetFirstSelectedObject()
        If obj.moveTempRect <> Nothing Then
          obj.DrawMoveRect()
          obj.bounds = obj.moveTempRect
          obj.moveTempRect = Nothing
        End If


      Else

        'For i = objects.Count - 1 To 0 Step -1
        '  If objects(i).isSelected = False AndAlso objects(i).HitTest(e.Location) Then
        '    SelectObject(objects(i))
        '    Exit For
        '  End If
        'Next

      End If
    End If

    If e.Button = MouseButtons.Right Then
      RaiseEvent ContextMenu()
      'Dim obj = GetObjectAt(e.Location)
      'If obj IsNot Nothing Then
      '  SelectObject(obj)
      '  showProperties(obj, True)
      'End If
    End If
    Invalidate()
  End Sub

  Function GetSelectionType() As String
    Dim selType As String = ""
    For Each item In selectedObjects
      Dim typeName = item.GetType.Name
      If selType <> "" And selType <> typeName Then Return ""
      If selType = "" Then selType = typeName
    Next
    Return selType
  End Function

  Sub SetContext(ByVal items As ToolStripItemCollection)
    Dim selType = GetSelectionType()

    For Each item As ToolStripItem In items
      Dim tag As String = item.Tag
      If String.IsNullOrEmpty(tag) Then Continue For
      If tag.StartsWith("%") Then item.Visible = False : tag = tag.Substring(1) Else item.Enabled = False

      If tag = "Any" AndAlso SelectionCount > 0 Then item.Enabled = True : item.Visible = True
      If tag = "Multi" AndAlso SelectionCount > 1 Then item.Enabled = True : item.Visible = True
      If tag = "Single" AndAlso SelectionCount = 1 Then item.Enabled = True : item.Visible = True
      If tag = "NoSel" AndAlso SelectionCount = 0 Then item.Enabled = True : item.Visible = True
      If selType <> "" AndAlso tag.Contains(selType) Then item.Enabled = True : item.Visible = True

      If item.Enabled And item.Visible And TypeOf item Is ToolStripMenuItem AndAlso DirectCast(item, ToolStripMenuItem).DropDownItems.Count > 0 Then _
        SetContext(DirectCast(item, ToolStripMenuItem).DropDownItems)
    Next
  End Sub

  Sub showTextEditor(ByVal obj As VTextbox, Optional ByVal allowFormat As Boolean = True)
    Dim f As New frm_textEditor
    f.TextBox1.Text = obj.Text
    If allowFormat Then f.setTextboxObject(Me, obj)
    If f.ShowDialog = Windows.Forms.DialogResult.OK Then
      obj.Text = f.TextBox1.Text
      Me.Invalidate()
    End If
  End Sub

  Sub Invalidate()
    If box IsNot Nothing Then box.Invalidate()

    'HACK
    'frm_paletteCursor.Invalidate()

  End Sub

  Sub DeselectAll()
    For i = 0 To p_objects.Count - 1
      p_objects(i).isSelected = False
    Next
    OnSelectionChanged()
  End Sub

  Sub SelectAll()
    For i = 0 To p_objects.Count - 1
      p_objects(i).isSelected = True
    Next
    OnSelectionChanged()
  End Sub

  Private Sub box_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles box.Paint
    For i = 0 To p_objects.Count - 1
      Try
        p_objects(i).DrawObject(e.Graphics)
      Catch ex As Exception
        e.Graphics.FillRectangle(Brushes.Red, p_objects(i).bounds)
        e.Graphics.DrawString(ex.ToString, PicBox.FindForm.Font, Brushes.Black, p_objects(i).bounds.Location)
      End Try
    Next
  End Sub

  Sub cleanUpZIndex()
    For i = 0 To p_objects.Count - 1
      p_objects(i).ZIndex = i + 1
    Next
  End Sub
  Sub orderByZIndex()
    SyncLock p_objects
      Dim curMinIdx As Integer = 0
      Dim curPos As Integer = 0, curObj As VObject

      While curPos < p_objects.Count
        curObj = p_objects(curPos)

        If curObj.ZIndex < curMinIdx Then
          p_objects.RemoveAt(curPos)
          For i = curPos To 0 Step -1
            If p_objects(i).ZIndex < curObj.ZIndex Then
              p_objects.Insert(i, curObj)
              curObj = Nothing : curPos = 0 : Continue While
            End If
          Next
        End If

        curMinIdx = curObj.ZIndex
        curPos += 1
      End While


    End SyncLock
  End Sub

  Sub addObject(ByVal obj As VObject)
    SyncLock p_objects
      If String.IsNullOrEmpty(obj.name) Then obj.name = "o_" & NextIndex()
      p_objects.Add(obj)
      obj.Parent = Me
      Invalidate()
      OnContentChanged(obj)
    End SyncLock
  End Sub

  Sub removeObject(ByVal obj As VObject)
    SyncLock p_objects
      p_objects.Remove(obj)
      If obj.isSelected Then OnSelectionChanged()
      obj.Parent = Nothing
      Invalidate()
      OnContentChanged(Nothing)
    End SyncLock
  End Sub

  Sub clearCanvas()
    For i = p_objects.Count - 1 To 0 Step -1
      removeObject(p_objects(i))
    Next
  End Sub

  Sub MoveObjectZ(ByVal obj As VObject, ByVal dirUp As Boolean, ByVal toEnd As Boolean)
    SyncLock p_objects
      Dim curIdx As Integer = p_objects.IndexOf(obj)
      If curIdx = 0 And dirUp = False Then Exit Sub
      If curIdx = p_objects.Count - 1 And dirUp = True Then Exit Sub

      p_objects.RemoveAt(curIdx)
      If toEnd Then
        If dirUp Then
          p_objects.Add(obj)
        Else
          p_objects.Insert(0, obj)
        End If
      Else
        If dirUp Then
          p_objects.Insert(curIdx + 1, obj)
        Else
          p_objects.Insert(curIdx - 1, obj)
        End If
      End If

      Invalidate()
      OnContentChanged(obj)
    End SyncLock
  End Sub

  Private Sub msgFilter_onKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs) Handles msgFilter.onKeyDown
    If ownerForm Is Nothing OrElse ownerForm IsNot Form.ActiveForm Then Exit Sub

    If isEditMode Then
      If e.KeyCode = Keys.Escape Then
        cancelEditMode()
      End If
      Exit Sub
    End If

    If e.KeyCode = Keys.Delete Then
      Dim obj = GetFirstSelectedObject()
      If obj IsNot Nothing Then
        removeObject(obj)
      Else
        Beep()
      End If
    End If

    'If (e.Alt And e.KeyCode = Keys.Return) Or (e.Control And e.KeyCode = Keys.P) Then
    '  Dim obj = GetFirstSelectedObject()
    '  If obj IsNot Nothing Then
    '    showProperties(obj)
    '  End If
    'End If

    If e.Control And e.KeyCode = Keys.D Then
      Dim obj = GetFirstSelectedObject()
      If obj IsNot Nothing AndAlso TypeOf obj Is VImage Then
        Dim vi As VImage = obj
        'loadImage(vi.img)
      End If
    End If

    If e.Control And e.KeyCode = Keys.X Then
      CutSelection()
    End If

    If e.Control And e.KeyCode = Keys.C Then
      CopySelection()
    End If

    If e.Control And e.KeyCode = Keys.V Then
      Paste()
    End If

    'If (e.Control And e.KeyCode = Keys.E) Then
    '  Dim obj = GetFirstSelectedObject()
    '  If obj IsNot Nothing And TypeOf obj Is VTextbox Then
    '    showTextEditor(obj)
    '  End If
    'End If

    If Helper.IsArrowKey(e.KeyCode) Then
      Dim deltaX, deltaY As Integer
      Select Case e.KeyCode
        Case Keys.Left : deltaX = -1
        Case Keys.Right : deltaX = +1
        Case Keys.Up : deltaY = -1
        Case Keys.Down : deltaY = +1
      End Select
      If e.Control = True Then deltaX *= 10 : deltaY *= 10
      For i = 0 To p_objects.Count - 1
        If p_objects(i).isSelected Then
          If e.Shift Then
            p_objects(i).Width += deltaX
            p_objects(i).Height += deltaY
          Else
            p_objects(i).Left += deltaX
            p_objects(i).Top += deltaY
          End If
        End If
      Next
      Invalidate()
    End If
  End Sub

  Private Sub msgFilter_onKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs) Handles msgFilter.onKeyUp
    If ownerForm Is Nothing OrElse ownerForm IsNot Form.ActiveForm Then Exit Sub

    Debug.Print("keyUP" + e.KeyCode.ToString)

    If e.KeyCode = Keys.PageUp Then
      MoveObjectZ(GetFirstSelectedObject(), True, e.Control Or e.Alt)
    End If

    If e.KeyCode = Keys.PageDown Then
      MoveObjectZ(GetFirstSelectedObject(), False, e.Control Or e.Alt)
    End If


  End Sub

  Function GetPartialImage(ByVal minX As Integer, ByVal minY As Integer, ByVal maxX As Integer, ByVal maxY As Integer, ByVal breakOnElement As VObject) As Image
    Dim bmp As New Bitmap(maxX - minX, maxY - minY, Imaging.PixelFormat.Format32bppPArgb)
    Dim g As Graphics = Graphics.FromImage(bmp)
    g.Clear(Color.White)
    g.TranslateTransform(-minX, -minY)
    For i = 0 To p_objects.Count - 1
      If breakOnElement IsNot Nothing AndAlso p_objects(i) Is breakOnElement Then Exit For
      With p_objects(i)
        '.isSelected = False
        .DrawObject(g)
        '.isSelected = True
      End With
    Next
    g.Dispose()
    Return bmp
  End Function

  Sub CopySelection()
    Clipboard.Clear()
    If SelectionCount = 0 Then Return
    Dim cdo As New DataObject()

    Dim minX, minY, maxX, maxY As Integer
    Dim internalData(SelectionCount) As String
    minX = Integer.MaxValue : minY = Integer.MaxValue
    For Each v In selectedObjects
      Dim r As RECT = v.GetOuterBounds()
      minX = Math.Min(minX, r.Left) : minY = Math.Min(minY, r.Top)
      maxX = Math.Max(maxX, r.Right) : maxY = Math.Max(maxY, r.Bottom)
    Next
    Dim minPoint As Point
    Dim bmp As New Bitmap(maxX - minX, maxY - minY, Imaging.PixelFormat.Format32bppPArgb)
    Dim g As Graphics = Graphics.FromImage(bmp)
    g.Clear(Color.White)
    g.TranslateTransform(-minX, -minY)
    For i = 0 To SelectionCount - 1
      With selectedObjects(i)
        .isSelected = False
        .DrawObject(g)
        .isSelected = True
        internalData(i) = .ToHtml()
      End With
    Next
    g.Dispose()
    cdo.SetData("Bitmap", True, bmp.Clone)


    cdo.SetData("ScreenGrabCollageItemList", False, internalData)

    If SelectionCount = 1 Then
      Select Case GetSelectionType()
        Case "VTextbox"
          cdo.SetText(DirectCast(GetFirstSelectedObject(), VTextbox).Text)
        Case "VImage"
          cdo.SetImage(DirectCast(GetFirstSelectedObject(), VImage).img)
      End Select
    End If

    Clipboard.SetDataObject(cdo, True)
  End Sub

  Sub CutSelection()
    CopySelection()
    'TODO: delete selected
  End Sub

  Sub Paste()
    DeselectAll()
    If Clipboard.ContainsData("ScreenGrabCollageItemList") And Not isKeyPressed(Keys.ShiftKey) Then
      Dim items() As String = Clipboard.GetData("ScreenGrabCollageItemList")
      For Each item As String In items
        If String.IsNullOrEmpty(item) Then Continue For
        Dim v As VObject = VObject.FromHtml(item, Me)
        If v Is Nothing Then MsgBox("Invalid data item" + vbNewLine + item) : Continue For
        v.isSelected = True
        v.name = "paste_" & Now.Ticks
        addObject(v)
      Next
    ElseIf Clipboard.ContainsImage Then
      Dim v As VImage = addPicClient(Clipboard.GetImage, "Clipboard")
      v.isSelected = True
      v.name = "paste_" & Now.Ticks
      '   addObject(v)
    ElseIf Clipboard.ContainsText Then
      Dim v As VTextbox
      v.Top = 100 : v.Left = 100 : v.Width = 200 : v.Height = 100
      v.Font = New Font("Courier New", 10, FontStyle.Regular, GraphicsUnit.Point)
      v.Text = Clipboard.GetText
      v.isSelected = True
      v.name = "paste_" & Now.Ticks
      addObject(v)
    End If
    OnSelectionChanged()

  End Sub

  Function addPicClient(ByVal img As Image, ByVal src As String) As VImage
    Dim obj As New VImage
    obj.name = "screenshot_" & Now.Ticks
    obj.img = img
    obj.source = src
    obj.bounds = New Rectangle(20, 20, obj.img.Width, obj.img.Height)
    'obj.setBorder(2, Color.RoyalBlue)
    Me.addObject(obj)
    PicBox.Refresh()
    Return obj
  End Function

  ' experimentell!
  Sub createPdfFile(ByVal filespec As String)
    Dim doc As New iTextSharp.text.Document(New iTextSharp.text.Rectangle(0, 0, box.Width, box.Height))
    Dim writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, New System.IO.FileStream(filespec, IO.FileMode.Create))
    Dim bf = iTextSharp.text.pdf.BaseFont.CreateFont()
    doc.Open()
    Dim over As iTextSharp.text.pdf.PdfContentByte = writer.DirectContent
    For i = 0 To p_objects.Count - 1
      Dim r As RECT = p_objects(i).GetOuterBounds
      If TypeOf p_objects(i) Is VTextbox Then
        Dim src As VTextbox = p_objects(i)

        'ColumnText can contain paraphraphs as well as be abolsutely positioned
        Dim Col As New iTextSharp.text.pdf.ColumnText(over)

        'Set the x,y,width,height
        Col.SetSimpleColumn(r.Left, box.Height - r.Top, r.Right, box.Height - r.Bottom)

        'Create our paragraph
        Dim P As New iTextSharp.text.Paragraph()
        'Create our base font, assumes you have arial installed in the normal location and that CP1252 works with it
        'Dim BF = BaseFont.CreateFont(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Windows), "Fonts\arial.ttf"), BaseFont.CP1252, False)
        'Add two chunks that will be placed side-by-side but with different font weights
        'P.Add(New iTextSharp.text.Chunk("BOLD TEXT: ", New iTextSharp.text.Font(bf, 10.0, iTextSharp.text.Font.BOLD)))
        Dim fontFilespec As String = Helper.GetFontFilespec(src.Font.FontFamily.Name)
        Dim fnt As iTextSharp.text.Font
        If fontFilespec <> "" Then
          fnt = New iTextSharp.text.Font( _
                  iTextSharp.text.pdf.BaseFont.CreateFont(fontFilespec, iTextSharp.text.pdf.BaseFont.CP1252, False), _
                  src.Font.SizeInPoints, iTextSharp.text.Font.NORMAL)
        Else
          fnt = New iTextSharp.text.Font(bf, src.Font.SizeInPoints, iTextSharp.text.Font.NORMAL)
        End If
        P.Add(New iTextSharp.text.Chunk(src.Text, fnt))
        'Add the paragraph to the ColumnText
        Col.AddText(P)
        'Call to stupid Go() method which actually writes the content to the stream.
        Col.Go()

        '
        'Dim txtbox As New iTextSharp.text.pdf.PdfPCell()

        'Dim f = New iTextSharp.text.Font(bf)
        'f.SetColor(0, 0, 0)
        'over.SetFontAndSize(bf, 10)
        'over.BeginText()
        'over.ShowTextAligned(1, src.Text, r.Left, box.Height - r.Bottom, 0)
        'over.EndText()
      Else
        Dim img = iTextSharp.text.Image.GetInstance(p_objects(i).GetAsImage, System.Drawing.Imaging.ImageFormat.Png)
        img.SetAbsolutePosition(r.Left, box.Height - r.Bottom)
        img.SetDpi(72, 72)
        'doc.Add(img)
        over.AddImage(img)
      End If
    Next
    doc.Close()
  End Sub

  Sub createHtmlPage(ByVal title As String, ByVal sw As System.IO.StreamWriter)
    'Dim fileName As String
    'Using sfd As New SaveFileDialog
    '  sfd.Filter = "HTML-Datei (*.html, *.html, *.htm)|*.html;*.htm"
    '  If sfd.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
    '  fileName = sfd.FileName
    'End Using
    cleanUpZIndex()

    Dim previewImg = GetPartialImage(0, 0, box.Width, box.Height, Nothing).GetThumbnailImage(150, 150, Nothing, IntPtr.Zero)


    sw.WriteLine("<!DOCTYPE HTML>")
    sw.WriteLine("<html>")
    sw.WriteLine("<head>")
    sw.WriteLine("	<title>" + title + "</title>")
    sw.WriteLine("	<!-- ##PREVIEW##" + Helper.ImageToBase64(previewImg) + "##-->")
    sw.WriteLine("	<style type=""text/css"">")
    sw.WriteLine("	div { line-height: 120% !important; }")
    sw.WriteLine("	p { margin: 0; padding: 0; font: 8pt 'Microsoft Sans Serif',sans-serif; }")
    sw.WriteLine("	p.title { line-height: 120% !important; margin-bottom: -4px; }")
    sw.WriteLine("	p.title b { font: bold 12pt 'Microsoft Sans Serif',sans-serif; }")
    sw.WriteLine("	hr { border: 1px solid black; margin: 4px 0; }")
    sw.WriteLine("	html,body { margin:0; padding:0; }")
    sw.WriteLine("	</style>")
    sw.WriteLine("	<meta name=""generator"" content=""ScreenShot 6 Collage"">")
    sw.WriteLine("	<!-- Version: " + My.Application.Info.Version.ToString + " -->")
    sw.WriteLine("	<meta name=""author"" content=""" + My.User.Name + """ />")
    sw.WriteLine("	<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />")
    sw.WriteLine("</head>")
    sw.WriteLine("<body bgcolor=""#888888"">")
    sw.WriteLine("<!-- ##page##" & PicBox.Width & "##" & PicBox.Height & "##" & "##" + Helper.Color2String(PicBox.BackColor) + "## -->")
    sw.WriteLine("<div style=""position: absolute; overflow: hidden; " +
                    "background-color: " + Helper.Color2HTMLString(PicBox.BackColor) + ";" +
                    "border: 1px solid black; width: " & PicBox.Width & "px; height: " & PicBox.Height & "px; "">")

    For Each el In p_objects
      sw.WriteLine(el.ToHtml())
    Next
    sw.WriteLine("</div></body></html>")
    'IO.File.WriteAllText(fileName, sb.ToString)
    'Process.Start(filespec)
  End Sub

  Sub createHtmlPage(ByVal fileSpec As String)
    Using sw As New IO.StreamWriter(fileSpec)
      createHtmlPage(IO.Path.GetFileNameWithoutExtension(fileSpec), sw)
    End Using
  End Sub

  Sub readHtmlPage(ByVal fileSpec As String)
    Dim sr = IO.File.OpenText(fileSpec)

    'clear All ???

    Dim groupStack As New Stack(Of VGroup)

    Dim lineNr = 0, modusCounter As Integer = 0
    Dim line, modus As String, contbuffer As System.Text.StringBuilder
    Dim myObj As VObject, addObj As VObject
    modus = "invalid"
    While sr.EndOfStream = False
      lineNr += 1 : modusCounter += 1
      line = sr.ReadLine
      If line.Contains("ScreenShot 5 Collage") Or line.Contains("ScreenShot 6 Collage") Then
        modus = "valid" : modusCounter = 0
      End If
      If modus = "invalid" Then Continue While

      If line.StartsWith("<!-- ##page##") Then
        Dim para() As String = Split(line, "##")
        Try
          PicBox.BackColor = Helper.String2Color(para(5))
          PicBox.Width = para(2)
          PicBox.Height = para(3)
        Catch : End Try

        Continue While
      End If

      If line.StartsWith("</section>") Then
        groupStack.Pop()
      End If

      If modus = "txt" And line = "</div>" Then
        modus = "valid" : modusCounter = 0
        If TypeOf myObj Is VTextbox Then
          DirectCast(myObj, VTextbox).Text = Trim(contbuffer.ToString).Replace("<br>", vbCrLf).Replace("<br/>", vbCrLf)
        ElseIf TypeOf myObj Is VUMLClass Then
          DirectCast(myObj, VUMLClass).ParseHtmlContent(Trim(contbuffer.ToString))
        End If
        addObj = (myObj)
      End If

      If modus = "txt" And modusCounter >= 1 Then
        contbuffer.AppendLine(line)
      End If

      If modus = "img" And modusCounter >= 1 Then
        If modusCounter = 1 Then line = line.Substring(5) 'src="
        If line.EndsWith(""" />") Then
          modus = "valid" : modusCounter = 0 : line = line.Substring(0, line.Length - 4)
        End If
        contbuffer.AppendLine(line)
        If modus = "valid" Then 'Bild fertig
          Dim img = Helper.Base64ToImage(contbuffer)
          DirectCast(myObj, VImage).img = img
          addObj = (myObj)
        End If
      End If


      If line.StartsWith("<!-- ##img##") Or line.StartsWith("<!-- ##VImage##") Then
        modus = "img" : modusCounter = 0
        Dim para() As String = Split(line, "##")
        myObj = New VImage
        myObj.Deserialize(para)
        contbuffer = New System.Text.StringBuilder()
      End If

      If line.StartsWith("<!-- ##rtf##") Or line.StartsWith("<!-- ##VTextbox##") Then
        modus = "txt" : modusCounter = 0
        Dim para() As String = Split(line, "##")

        myObj = New VTextbox
        myObj.Deserialize(para)
        contbuffer = New System.Text.StringBuilder()
      End If

      If line.StartsWith("<!-- ##VUMLClass##") Then
        modus = "txt" : modusCounter = 0
        Dim para() As String = Split(line, "##")

        myObj = New VUMLClass
        myObj.Deserialize(para)
        contbuffer = New System.Text.StringBuilder()
      End If

      If line.StartsWith("<!-- ##VElipse##") Then
        modus = "valid" : modusCounter = 0
        Dim para() As String = Split(line, "##")

        myObj = New VElipse
        myObj.Deserialize(para)
        addObj = (myObj)
      End If

      If line.StartsWith("<!-- ##VLine##") Then
        modus = "valid" : modusCounter = 0
        Dim para() As String = Split(line, "##")

        myObj = New VLine
        myObj.Deserialize(para)
        addObj = (myObj)
      End If

      If line.StartsWith("<!-- ##VRectangle##") Then
        modus = "valid" : modusCounter = 0
        Dim para() As String = Split(line, "##")

        myObj = New VRectangle
        myObj.Deserialize(para)
        addObj = (myObj)
      End If

      If line.StartsWith("<!-- ##VGroup##") Then
        modus = "valid" : modusCounter = 0
        Dim para() As String = Split(line, "##")

        myObj = New VGroup
        myObj.Deserialize(para)
        addObj = (myObj)
      End If

      If addObj IsNot Nothing Then
        If (groupStack.Count = 0) Then
          addObject(addObj)
        Else
          addObj.Parent = Me : addObj.Group = groupStack.Peek()
          groupStack.Peek().subObjects.Add(addObj)
        End If

        addObj = Nothing
      End If

      If line.StartsWith("<!-- ##VGroup##") Then groupStack.Push(myObj)
    End While

    If modus = "invalid" Then
      MsgBox("Ungültiges Dateiformat.", MsgBoxStyle.Critical)
    End If

    sr.Close()
  End Sub

  Private Sub EditTB_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles EditTB.KeyUp
    If e.KeyCode = Keys.Escape Then
      cancelEditMode()
    End If
    If e.KeyCode = Keys.Enter And (e.Control Or e.Shift) Then
      acceptEditMode()
    End If
    If e.KeyCode = Keys.F And e.Control Then
      EditObject.Font = New Font(EditObject.Font, EditObject.Font.Style Xor FontStyle.Bold)
      EditTB.Font = EditObject.Font
    End If
    If e.KeyCode = Keys.K And e.Control Then
      EditObject.Font = New Font(EditObject.Font, EditObject.Font.Style Xor FontStyle.Italic)
      EditTB.Font = EditObject.Font
    End If
    If e.KeyCode = Keys.U And e.Control Then
      EditObject.Font = New Font(EditObject.Font, EditObject.Font.Style Xor FontStyle.Underline)
      EditTB.Font = EditObject.Font
    End If
    If e.KeyCode = Keys.Oemplus And e.Control Then
      EditObject.Font = New Font(EditObject.Font.FontFamily, EditObject.Font.SizeInPoints + 1, EditObject.Font.Style, GraphicsUnit.Point)
      EditTB.Font = EditObject.Font
    End If
    If e.KeyCode = Keys.OemMinus And e.Control Then
      EditObject.Font = New Font(EditObject.Font.FontFamily, EditObject.Font.SizeInPoints - 1, EditObject.Font.Style, GraphicsUnit.Point)
      EditTB.Font = EditObject.Font
    End If
  End Sub

  Private Sub EditTB_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditTB.TextChanged

  End Sub

End Class


Public Class VCanvasLocalMessageFilter
  Implements IMessageFilter

  Private Const WM_KEYDOWN = &H100
  Private Const WM_KEYUP = &H101
  Event onKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
  Event onKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)

  Sub New()

  End Sub

  Public Function PreFilterMessage(ByRef m As System.Windows.Forms.Message) As Boolean Implements System.Windows.Forms.IMessageFilter.PreFilterMessage
    If m.Msg = WM_KEYDOWN Then
      Dim e As New KeyEventArgs((DirectCast(CInt(CLng(m.WParam)), Keys) Or Control.ModifierKeys))
      RaiseEvent onKeyDown(e)
    ElseIf m.Msg = WM_KEYUP Then
      Dim e As New KeyEventArgs((DirectCast(CInt(CLng(m.WParam)), Keys) Or Control.ModifierKeys))
      RaiseEvent onKeyUp(e)
    End If
  End Function
End Class

