Public Class frm_grab
  Dim ClickPoint As New Point, CurrentTopLeft As New Point, CurrentBottomRight As New Point
  Dim MyPen As Pen = New Pen(Color.Blue, 3)
  Dim EraserPen As Pen = New Pen(Color.FromArgb(255, 255, 192), 3)
  Dim g As Graphics
  Dim MySelRect As Rectangle

  Sub getRect(ByRef X As Integer, ByRef Y As Integer, ByRef XX As Integer, ByRef YY As Integer)
    If MySelRect = Nothing Then
      X = 0 : Y = 0 : XX = 0 : YY = 0 : Exit Sub
    End If
    X = MySelRect.X - grabsch.GetDesktopLeft()
    Y = MySelRect.Y - grabsch.GetDesktopTop()
    XX = MySelRect.Width
    YY = MySelRect.Height
    MySelRect = Nothing
  End Sub

  Private Sub frm_grab_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
    If e.KeyCode = Keys.Escape Then
      grabWindowCancel()

    End If
  End Sub

  Private Sub frm_grab_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
    If MySelRect <> Nothing Then
      ControlPaint.DrawReversibleFrame(MySelRect, Color.Black, FrameStyle.Thick)
    End If
    Me.Hide()
    grabWindowDone()

  End Sub

  Private Sub frm_grab_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
    g = Me.CreateGraphics

    ClickPoint = Cursor.Position
    MySelRect = Nothing
    ' g.Clear(Color.FromArgb(255, 255, 192))

  End Sub

  Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

  End Sub

  Private Sub frm_grab_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
    If e.Button = Windows.Forms.MouseButtons.Left Then

      'Erase the previous rectangle
      If MySelRect <> Nothing Then
        ControlPaint.DrawReversibleFrame(MySelRect, Color.Black, FrameStyle.Thick)
      End If
      'g.DrawRectangle(EraserPen, CurrentTopLeft.X, CurrentTopLeft.Y, CurrentBottomRight.X - CurrentTopLeft.X, CurrentBottomRight.Y - CurrentTopLeft.Y)

      'Calculate X Coordinates
      If Cursor.Position.X < ClickPoint.X Then
        CurrentTopLeft.X = Cursor.Position.X
        CurrentBottomRight.X = ClickPoint.X
      Else
        CurrentTopLeft.X = ClickPoint.X
        CurrentBottomRight.X = Cursor.Position.X
      End If

      'Calculate Y Coordinates
      If Cursor.Position.Y < ClickPoint.Y Then
        CurrentTopLeft.Y = Cursor.Position.Y
        CurrentBottomRight.Y = ClickPoint.Y
      Else
        CurrentTopLeft.Y = ClickPoint.Y
        CurrentBottomRight.Y = Cursor.Position.Y
      End If

      'Draw a new rectangle
      MySelRect = New Rectangle(CurrentTopLeft.X, CurrentTopLeft.Y, CurrentBottomRight.X - CurrentTopLeft.X, CurrentBottomRight.Y - CurrentTopLeft.Y)

      'g.DrawRectangle(Pens.Blue, CurrentTopLeft.X, CurrentTopLeft.Y, CurrentBottomRight.X - CurrentTopLeft.X, CurrentBottomRight.Y - CurrentTopLeft.Y)
      ControlPaint.DrawReversibleFrame(MySelRect, Color.Black, FrameStyle.Thick)

    End If
  End Sub


  Private Sub frm_grab_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


  End Sub
End Class