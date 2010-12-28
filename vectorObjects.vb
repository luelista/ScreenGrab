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

  Public Class Helper
    Public Shared Function PointDistance(ByVal pt1 As Point, ByVal pt2 As Point) As Single
      Return Math.Sqrt((Math.Abs(pt1.X - pt2.X) ^ 2) + (Math.Abs(pt1.Y - pt2.Y) ^ 2))
    End Function

    Public Shared Function MakeRect(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer) As Rectangle
      Dim lx = Math.Min(x1, x2), ly = Math.Min(y1, y2)
      Return New Rectangle(lx, ly, Math.Max(x1, x2) - lx, Math.Max(y1, y2) - ly)
    End Function

    Public Shared Function IsArrowKey(ByVal kc As Keys) As Boolean
      Return kc >= 37 And kc <= 40
    End Function

    Public Shared Function GetResizedRect(ByVal sourceRect As Rectangle, ByVal direction As VResizeDirection, ByVal startPoint As Point, ByVal curPoint As Point) As Rectangle
      Dim deltaX = curPoint.X - sourceRect.X, deltaY = curPoint.Y - sourceRect.Y
      GetResizedRect = sourceRect
      Dim resizes = ""
      If direction = VResizeDirection.TopLeft Or direction = VResizeDirection.TopRight Then
        resizes += "TOP "        'top resize
        GetResizedRect.Y += deltaY
        GetResizedRect.Height -= deltaY
      End If

      If direction = VResizeDirection.TopLeft Or direction = VResizeDirection.BottomLeft Then
        resizes += "LEFT "     'left resize
        GetResizedRect.X += deltaX
        GetResizedRect.Width -= deltaX
      End If

      If direction = VResizeDirection.BottomLeft Or direction = VResizeDirection.BottomRight Then
        resizes += "BTM "     'bottom resize
        GetResizedRect.Height = deltaY
      End If

      If direction = VResizeDirection.TopRight Or direction = VResizeDirection.BottomRight Then
        resizes += "RGT "    'right resize
        GetResizedRect.Width = deltaX
      End If

      Debug.Print(resizes)
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

  End Class




  Public Class Canvas
    Public objects As New List(Of VObject)
    Public selectionCount As Integer = 0
    Public selectedObjects As New List(Of VObject)

    Public ZIndexMin As Integer = 10000, ZIndexMax As Integer = 10000

    Public mouseDownPnt As Point, rubberBandActive As Boolean, rubberBandRect As Rectangle
    Public isMoveMode As Boolean = False
    Public resizeDirection As VResizeDirection = VResizeDirection.None

    Private WithEvents box As PictureBox
    Private WithEvents ownerForm As Form

    Private WithEvents msgFilter As New VCanvasLocalMessageFilter()

    Public IsMultitouchMode As Boolean = False

    Public isEditMode As Boolean = False
    Public EditObject As VTextbox
    Public WithEvents EditTB As TextBox

    Public Property PicBox() As PictureBox
      Get
        Return box
      End Get
      Set(ByVal value As PictureBox)
        box = value
        box.Image = Nothing
        box.BackgroundImage = Nothing
        Application.RemoveMessageFilter(msgFilter)
        If box Is Nothing Then
          ownerForm = Nothing
        Else
          ownerForm = box.FindForm
          Application.AddMessageFilter(msgFilter)
        End If
      End Set
    End Property

    Function GetObjectByID(ByVal id As String) As VObject
      For i = 0 To objects.Count - 1
        If objects(i).name = id Then
          Return objects(i)
        End If
      Next
      Return Nothing
    End Function

    Function GetObjectAt(ByVal pt As Point) As VObject
      For i = objects.Count - 1 To 0 Step -1
        If objects(i).HitTest(pt) Then
          Return objects(i)
        End If
      Next
      Return Nothing
    End Function

    Function GetFirstSelectedObject() As VObject
      If selectedObjects.Count > 0 Then Return selectedObjects(0)
    End Function

    Sub OnSelectionChanged()
      If isEditMode Then acceptEditMode()

      selectionCount = 0 : selectedObjects.Clear()
      For i = 0 To objects.Count - 1
        If objects(i).isSelected Then selectionCount += 1 : selectedObjects.Add(objects(i))
      Next
      If frm_paletteFile.Visible And selectionCount = 1 Then
        frm_paletteFile.SelectedObject = selectedObjects(0)
      End If
      If frm_paletteFile.Visible And selectionCount <> 1 Then
        frm_paletteFile.SelectedObject = Nothing
      End If
    End Sub

    Sub SelectObject(ByVal obj As VObject)
      For i = 0 To objects.Count - 1
        objects(i).isSelected = False
      Next
      obj.isSelected = True
      OnSelectionChanged()
      Invalidate()
    End Sub

    Sub startEditMode(ByVal tb As VTextbox)
      EditTB.Bounds = New Rectangle(tb.Left - 2, tb.Top + 28, tb.Width + 4, tb.Height + 4)
      'EditTB.Top += 28

      EditTB.Text = tb.text
      EditTB.Font = tb.fnt
      EditTB.Show()
      EditObject = tb
      isEditMode = True
    End Sub

    Sub acceptEditMode()
      If Not isEditMode Then Exit Sub
      EditObject.text = EditTB.Text
      EditTB.Hide()
      isEditMode = False
    End Sub

    Sub cancelEditMode()
      If Not isEditMode Then Exit Sub
      EditTB.Hide()
      isEditMode = False
    End Sub

    Private Sub box_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles box.MouseDoubleClick
      Dim selObj = GetFirstSelectedObject()
      If selObj IsNot Nothing AndAlso TypeOf selObj Is VTextbox Then
        startEditMode(selObj)

      End If
    End Sub

    Private Sub box_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles box.MouseDown
      If isEditMode Then acceptEditMode()
      If IsMultitouchMode Then Exit Sub

      mouseDownPnt = e.Location

      isMoveMode = False
      resizeDirection = VResizeDirection.None

      Dim selObj = GetFirstSelectedObject()
      If selObj IsNot Nothing Then
        Dim resize = selObj.HitTestResizer(e.Location)
        resizeDirection = resize
        ''''    frm_mdiViewer2.Text = resizeDirection.ToString
      End If

      If resizeDirection = VResizeDirection.None Then
        'wenn nicht resize, dann vielleicht verschieben???

        Dim clickObj = GetObjectAt(e.Location)
        If clickObj IsNot Nothing Then 'AndAlso clickObj.isSelected
          If Not clickObj.isSelected Then DeselectAll() : SelectObject(clickObj)
          isMoveMode = True
        End If
      End If

      rubberBandActive = False
      rubberBandRect = Nothing
    End Sub

    Private Sub box_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles box.MouseMove
      If IsMultitouchMode Then Exit Sub

      If e.Button <> MouseButtons.Left Then Exit Sub

      If isMoveMode Then
        For i = 0 To selectedObjects.Count - 1
          Dim obj = selectedObjects(i)
          If obj.moveTempRect <> Nothing Then
            ControlPaint.DrawReversibleFrame(box.RectangleToScreen(obj.moveTempRect), Color.White, FrameStyle.Dashed)
          End If
          obj.moveTempRect = obj.bounds
          obj.moveTempRect.Offset(e.Location - mouseDownPnt)
          ControlPaint.DrawReversibleFrame(box.RectangleToScreen(obj.moveTempRect), Color.White, FrameStyle.Dashed)
        Next

      ElseIf resizeDirection <> VResizeDirection.None Then
        Dim obj = GetFirstSelectedObject()
        If obj.moveTempRect <> Nothing Then
          ControlPaint.DrawReversibleFrame(box.RectangleToScreen(obj.moveTempRect), Color.White, FrameStyle.Dashed)
        End If
        obj.moveTempRect = Helper.GetResizedRect(obj.bounds, resizeDirection, mouseDownPnt, e.Location)

        ControlPaint.DrawReversibleFrame(box.RectangleToScreen(obj.moveTempRect), Color.White, FrameStyle.Dashed)


      ElseIf rubberBandActive OrElse Helper.PointDistance(mouseDownPnt, e.Location) > 5 Then
        rubberBandActive = True
        If rubberBandRect <> Nothing Then
          ControlPaint.DrawReversibleFrame(box.RectangleToScreen(rubberBandRect), Color.White, FrameStyle.Dashed)
        End If
        rubberBandRect = Helper.MakeRect(mouseDownPnt.X, mouseDownPnt.Y, e.X, e.Y)
        ControlPaint.DrawReversibleFrame(box.RectangleToScreen(rubberBandRect), Color.White, FrameStyle.Dashed)
      End If
    End Sub

    Private Sub box_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles box.MouseUp
      If IsMultitouchMode Then Exit Sub

      If e.Button = MouseButtons.Left Then
        If rubberBandActive Then
          rubberBandActive = False
          If rubberBandRect <> Nothing Then
            ControlPaint.DrawReversibleFrame(box.RectangleToScreen(rubberBandRect), Color.White, FrameStyle.Dashed)
          End If

          Dim rct As Rectangle = rubberBandRect

          For i = 0 To objects.Count - 1
            objects(i).isSelected = objects(i).HitTestRect(rct)
          Next
          OnSelectionChanged()

        ElseIf isMoveMode Then
          For i = 0 To selectedObjects.Count - 1
            Dim obj = selectedObjects(i)
            If obj.moveTempRect <> Nothing Then
              ControlPaint.DrawReversibleFrame(box.RectangleToScreen(obj.moveTempRect), Color.White, FrameStyle.Dashed)
              obj.bounds = obj.moveTempRect
              obj.moveTempRect = Nothing
            End If
          Next

        ElseIf resizeDirection <> VResizeDirection.None Then
          Dim obj = GetFirstSelectedObject()
          If obj.moveTempRect <> Nothing Then
            ControlPaint.DrawReversibleFrame(box.RectangleToScreen(obj.moveTempRect), Color.White, FrameStyle.Dashed)
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
        Dim obj = GetObjectAt(e.Location)
        If obj IsNot Nothing Then
          SelectObject(obj)
          showProperties(obj, True)
        End If
      End If
      Invalidate()
    End Sub

    Sub showProperties(ByVal obj As VObject, Optional ByVal force As Boolean = False)
      If force = True Then
        frm_paletteFile.Show()
        frm_paletteFile.Activate()
      ElseIf force = False And frm_paletteFile.Visible = False Then
        Exit Sub
      End If
      ' frm_paletteFile.MyCanvas = Me
      frm_paletteFile.RefreshItemList()
      frm_paletteFile.SelectedObject = obj
    End Sub

    Sub showTextEditor(ByVal obj As VTextbox, Optional ByVal allowFormat As Boolean = True)
      Dim f As New frm_textEditor
      f.TextBox1.Text = obj.text
      If allowFormat Then f.setTextboxObject(Me, obj)
      If f.ShowDialog = Windows.Forms.DialogResult.OK Then
        obj.text = f.TextBox1.Text
        Me.Invalidate()
      End If
    End Sub

    Sub Invalidate()
      box.Invalidate()

      'HACK
      frm_paletteCursor.Invalidate()

    End Sub

    Sub DeselectAll()
      For i = 0 To objects.Count - 1
        objects(i).isSelected = False
      Next
      OnSelectionChanged()
    End Sub

    Private Sub box_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles box.Paint
      For i = 0 To objects.Count - 1
        objects(i).DrawObject(e.Graphics)
      Next
    End Sub

    Sub orderByZIndex()

      Dim curMinIdx As Integer = 0
      Dim curPos As Integer = 0, curObj As VObject

      While curPos < objects.Count
        curObj = objects(curPos)

        If curObj.ZIndex < curMinIdx Then
          objects.RemoveAt(curPos)
          For i = curPos To 0 Step -1
            If objects(i).ZIndex < curObj.ZIndex Then
              objects.Insert(i, curObj)
              curObj = Nothing : curPos = 0 : Continue While
            End If
          Next
        End If

        curMinIdx = curObj.ZIndex
        curPos += 1
      End While



    End Sub

    Sub addObject(ByVal obj As VObject)
      objects.Add(obj)
      Invalidate()
    End Sub

    Sub removeObject(ByVal obj As VObject)
      objects.Remove(obj)
      Invalidate()
    End Sub

    Sub MoveObjectZ(ByVal obj As VObject, ByVal dirUp As Boolean)
      Dim curIdx As Integer = objects.IndexOf(obj)
      If curIdx = 0 And dirUp = False Then Exit Sub
      If curIdx = objects.Count - 1 And dirUp = True Then Exit Sub

      objects.RemoveAt(curIdx)
      If dirUp Then
        objects.Insert(curIdx + 1, obj)
      Else
        objects.Insert(curIdx - 1, obj)
      End If
      Invalidate()
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

      If (e.Alt And e.KeyCode = Keys.Return) Or (e.Control And e.KeyCode = Keys.P) Then
        Dim obj = GetFirstSelectedObject()
        If obj IsNot Nothing Then
          showProperties(obj)
        End If
      End If

      If e.Control And e.KeyCode = Keys.D Then
        Dim obj = GetFirstSelectedObject()
        If obj IsNot Nothing AndAlso TypeOf obj Is VImage Then
          Dim vi As VImage = obj
          loadImage(vi.img)
        End If
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
        For i = 0 To objects.Count - 1
          If objects(i).isSelected Then
            If e.Shift Then
              objects(i).Width += deltaX
              objects(i).Height += deltaY
            Else
              objects(i).Left += deltaX
              objects(i).Top += deltaY
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
        MoveObjectZ(GetFirstSelectedObject(), True)
      End If

      If e.KeyCode = Keys.PageDown Then
        MoveObjectZ(GetFirstSelectedObject(), False)
      End If


    End Sub


    Sub createHtmlPage(ByVal fileSpec As String)
      'Dim fileName As String
      'Using sfd As New SaveFileDialog
      '  sfd.Filter = "HTML-Datei (*.html, *.html, *.htm)|*.html;*.htm"
      '  If sfd.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
      '  fileName = sfd.FileName
      'End Using


      Dim sw As New IO.StreamWriter(fileSpec)
      sw.WriteLine("<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01 Transitional//EN"" " + _
                    """http://www.w3.org/TR/html4/loose.dtd"">")
      sw.WriteLine("<html>")
      sw.WriteLine("<head>")
      sw.WriteLine("	<title>" + IO.Path.GetFileNameWithoutExtension(fileSpec) + "</title>")
      sw.WriteLine("	<meta name=""generator"" content=""ScreenShot 5 Collage"">")
      sw.WriteLine("</head>")
      sw.WriteLine("<body bgcolor=""#888888"">")
      sw.WriteLine("<!-- ##page##" & PicBox.Width & "##" & PicBox.Height & "##" & "##" + Helper.Color2String(PicBox.BackColor) + "## -->")
      sw.WriteLine("<div style=""margin: 10px auto; overflow: hidden; " + _
                    "background-color: " + Helper.Color2HTMLString(PicBox.BackColor) + ";" + _
                    "border: 1px solid black; width: " & PicBox.Width & "px; height: " & PicBox.Height & "px; "">")

      For Each el In objects
        Dim border As String = ""
        If el.borderPen IsNot Nothing Then border = " border: " & el.borderPen.Width & "px solid " & Helper.Color2HTMLString(el.borderPen.Color) & "; "

        If TypeOf el Is VImage Then
          Dim pic As VImage = el
          Dim img = pic.img
          Dim base64 = ImageToBase64(img)
          sw.Write("<!-- " + Join(pic.Serialize(), "##") + "## -->")
          sw.WriteLine("<img alt=""Screenshot"" style=""position: absolute; " & border & _
                        "z-index: " & pic.ZIndex & "; margin-left: " & pic.bounds.X & "px; margin-top: " & pic.bounds.Y & "px; height: " & pic.bounds.Height & "px; width: " & pic.bounds.Width & "px; """)
          sw.Write("src=""")
          sw.Write(base64)
          sw.WriteLine(""" />")
        End If
        If TypeOf el Is VTextbox Then
          Dim txt As VTextbox = el
          sw.Write("<!-- " + Join(txt.Serialize(), "##") + "## -->")
          sw.WriteLine("<div style=""position: absolute; " & border & _
                        "z-index: " & txt.ZIndex & "; margin-left: " & txt.bounds.X & "px; margin-top: " & txt.bounds.Y & "px; height: " & txt.bounds.Height & "px; width: " & txt.bounds.Width & "px; " & _
                        "font-family: '" & txt.fnt.FontFamily.Name & "'; font-size: " & Replace(txt.fnt.SizeInPoints, ",", ".") & "pt; color: " & Helper.Color2HTMLString(DirectCast(txt.brsh, SolidBrush).Color) & "; "">")
          sw.WriteLine(Replace(Replace(txt.text, vbNewLine, vbLf), vbLf, "<br>"))
          sw.WriteLine("</div>")

        End If
        If TypeOf el Is VElipse Then
          Dim eli As VElipse = el
          sw.Write("<!-- " + Join(eli.Serialize(), "##") + "## -->")
          sw.WriteLine("<div style=""position: absolute; " & border & _
                        "z-index: " & eli.ZIndex & "; margin-left: " & eli.bounds.X & "px; margin-top: " & eli.bounds.Y & "px; height: " & eli.bounds.Height & "px; width: " & eli.bounds.Width & "px; "">")
          sw.WriteLine("Ellipse ;-)")
          sw.WriteLine("</div>")

        End If
      Next
      sw.WriteLine("</div></body></html>")
      sw.Close()
      'IO.File.WriteAllText(fileName, sb.ToString)
      'Process.Start(filespec)
    End Sub

    Function ImageToBase64(ByVal img As Image) As String
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

    Function Base64ToImage(ByVal str As System.Text.StringBuilder) As Image
      Dim modus As Integer = 0, datTyp As String = "", abPos As Integer
      Debug.Print(str.ToString)
      For i = 0 To str.Length - 1
        If str.Chars(i) = ":"c Then modus = 1 : Continue For
        If str.Chars(i) = ";"c Then modus = 2 : Continue For
        If str.Chars(i) = ","c Then modus = 3 : abPos = i + 1 : Exit For
        If modus = 1 Then
          datTyp += str.Chars(i)
        End If
      Next

      Dim byt() = Convert.FromBase64String(str.ToString(abPos, str.Length - abPos - 1))
      Dim ms As New IO.MemoryStream(byt)
      Base64ToImage = Image.FromStream(ms)
      ms.Close()
    End Function

    Sub readHtmlPage(ByVal fileSpec As String)
      Dim sr = IO.File.OpenText(fileSpec)

      'clear All ???

      Dim lineNr = 0, modusCounter As Integer = 0
      Dim line, modus As String, contbuffer As System.Text.StringBuilder
      Dim myObj As VObject
      modus = "invalid"
      While sr.EndOfStream = False
        lineNr += 1 : modusCounter += 1
        line = sr.ReadLine
        If line.Contains("ScreenShot 5 Collage") Then
          modus = "valid" : modusCounter = 0
        End If
        If modus = "invalid" Then Continue While

        If line.StartsWith("<!-- ##page##") Then
          Dim para() As String = Split(line, "##")
          PicBox.BackColor = Helper.String2Color(para(5))
          'Me.Width = para(2)
          'Me.Height = para(3)

          Continue While
        End If

        If modus = "txt" And line = "</div>" Then
          modus = "valid" : modusCounter = 0
          DirectCast(myObj, VTextbox).text = Trim(contbuffer.ToString).Replace("<br>", vbCrLf)
          addObject(myObj)
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
            Dim img = Base64ToImage(contbuffer)
            DirectCast(myObj, VImage).img = img
            addObject(myObj)
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

        If line.StartsWith("<!-- ##VElipse##") Then
          modus = "valid" : modusCounter = 0
          Dim para() As String = Split(line, "##")

          myObj = New VElipse
          myObj.Deserialize(para)
          addObject(myObj)
        End If


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
    End Sub

    Private Sub EditTB_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditTB.TextChanged

    End Sub

  End Class


  Public Class VCanvasLocalMessageFilter
    Implements IMessageFilter

    Event onKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
    Event onKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)


    Sub New()

    End Sub

    Public Function PreFilterMessage(ByRef m As System.Windows.Forms.Message) As Boolean Implements System.Windows.Forms.IMessageFilter.PreFilterMessage
      If m.Msg = WindowsMessages.WM_KEYDOWN Then
        Dim e As New KeyEventArgs((DirectCast(CInt(CLng(m.WParam)), Keys) Or Control.ModifierKeys))
        RaiseEvent onKeyDown(e)
      ElseIf m.Msg = WindowsMessages.WM_KEYUP Then
        Dim e As New KeyEventArgs((DirectCast(CInt(CLng(m.WParam)), Keys) Or Control.ModifierKeys))
        RaiseEvent onKeyUp(e)
      End If
    End Function
  End Class


  '---------------------------------------------------------------------------------------


  Public MustInherit Class VObject

    Public name As String
    Public created As String

    Public ZIndex As Integer

    Private m_bounds As Rectangle
    Private m_resizeBounds(3) As Rectangle

    Public MustOverride Sub DrawObject(ByVal g As Graphics)

    Public moveTempRect As Rectangle
    Public moveOrigRect As Rectangle
    Public isSelected As Boolean
    Public borderPen As Pen

    Public Shared selectionRectPen As New Pen(Color.Black, 1) With {.DashStyle = Drawing2D.DashStyle.Dash}

    Public Shared CommonDataOffset As Integer = 19
    Public Shared ResizerWidth As Integer = 5
    Public Shared ResizerBrsh As New SolidBrush(Color.Gray)

    Public rotation As Integer

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
      m_resizeBounds(0) = New Rectangle(m_bounds.X - ResizerWidth, m_bounds.Y - ResizerWidth, ResizerWidth * 2, ResizerWidth * 2)
      m_resizeBounds(1) = New Rectangle(bounds.Right - ResizerWidth, bounds.Y - ResizerWidth, ResizerWidth * 2, ResizerWidth * 2)
      m_resizeBounds(2) = New Rectangle(bounds.X - ResizerWidth, bounds.Bottom - ResizerWidth, ResizerWidth * 2, ResizerWidth * 2)
      m_resizeBounds(3) = New Rectangle(bounds.Right - ResizerWidth, bounds.Bottom - ResizerWidth, ResizerWidth * 2, ResizerWidth * 2)
    End Sub

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
      data(12) = rotation
      data(13) = "" 'reserve
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
        borderPen = New Pen(Helper.String2Color(Data(10)), Val(Data(9)))
      Else
        borderPen = Nothing
      End If
      If Data(11) = "V2" Then
        offset = 19
        rotation = Val(Data(12))
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

    Sub setBorder(ByVal width As Integer, ByVal color As Color)
      If width = 0 Then borderPen = Nothing : Exit Sub
      borderPen = New Pen(color, width)
    End Sub

    Public Sub DrawBorder(ByVal g As Graphics)
      If borderPen IsNot Nothing Then
        g.DrawRectangle(borderPen, bounds)
      End If
    End Sub
    Public Sub DrawSelection(ByVal g As Graphics)
      If isSelected Then
        g.DrawRectangle(selectionRectPen, bounds)
        For i = 0 To 3
          g.FillRectangle(ResizerBrsh, m_resizeBounds(i))
        Next
      End If
    End Sub
  End Class

  '---------------------------------------------------------------------------------------

  Public Class VImage
    Inherits VObject
    Public img As Image
    Public source As String

    Public Overrides Sub DrawObject(ByVal g As System.Drawing.Graphics)
      Dim oldm As Matrix
      If rotation > 0 Then
        Dim m As New Matrix
        m.RotateAt(rotation, New PointF(Me.bounds.X + Me.bounds.Width / 2, Me.bounds.Y + Me.bounds.Height / 2))
        oldm = g.Transform
        g.Transform = m
      End If
      g.DrawImage(img, bounds)
      DrawBorder(g)
      If rotation > 0 Then
        g.Transform = oldm
      End If
      DrawSelection(g)

    End Sub

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

  Public Class VTextbox
    Inherits VObject
    Public text As String
    Public fnt As Font
    Public brsh As Brush

    Public Overrides Sub DrawObject(ByVal g As System.Drawing.Graphics)
      g.DrawString(text, fnt, brsh, bounds) ', New StringFormat(StringFormatFlags.NoClip))
      DrawBorder(g)
      DrawSelection(g)
    End Sub

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

  Public Class VElipse
    Inherits VObject
    'Public color As Color

    Public Overrides Sub DrawObject(ByVal g As System.Drawing.Graphics)
      g.DrawEllipse(borderPen, bounds)
      DrawSelection(g)
    End Sub
  End Class
End Namespace