'Module app_multiSelectRubberband

'  Public multiSelectionActive As Boolean = False
'  Public multiSelection_selCtrls As New List(Of Control)
'  Private m_Drawing As Boolean
'  Private m_StartX, m_StartY, m_CurX, m_CurY As Single

'  Sub pnl_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
'    m_Drawing = True
'    m_StartX = e.X
'    m_StartY = e.Y
'    m_CurX = e.X
'    m_CurY = e.Y
'  End Sub

'  Sub pnl_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
'    If Not m_Drawing Then Exit Sub

'    m_CurX = e.X
'    m_CurY = e.Y

'    frm_grab.Invalidate()
'  End Sub

'  Sub pnl_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
'    m_Drawing = False

'    Dim new_rect As New Rectangle( _
'        Math.Min(m_StartX, m_CurX), _
'        Math.Min(m_StartY, m_CurY), _
'        Math.Abs(m_StartX - m_CurX), _
'        Math.Abs(m_StartY - m_CurY))


'    frm_grab.Invalidate()
'  End Sub

'  Sub stopMultiSelectionMode()
'    multiSelection_selCtrls.Clear()
'    multiSelectionActive = False
'    For Each ctrl As Control In MAIN.pnlJumboContent.Controls
'      If Not TypeOf ctrl Is Button Then Continue For
'      Dim btn As Button = DirectCast(ctrl, Button)
'      btn.UseVisualStyleBackColor = True
'      RemoveHandler btn.MouseDown, AddressOf rubberBandBtn_MouseDown
'    Next
'    MAIN.labEditMode.Text = "E D I T - M O D E"
'  End Sub


'  Private Sub rubberBandBtn_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
'    If Not multiSelectionActive Then Exit Sub
'    Dim t() As String = sender.Tag
'    If e.Button = MouseButtons.Left Then
'      Dim oldTop As Integer = sender.top, oldLeft As Integer = sender.left

'      FormMoveTricky(sender.Handle)

'      sender.left = (sender.left \ raster1) * raster1 + raster2 : sender.top = (sender.top \ raster1) * raster1 + raster2

'      For Each btn As Button In multiSelection_selCtrls
'        If btn Is sender Then Continue For
'        btn.Top += sender.top - oldTop
'        btn.Left += sender.left - oldLeft
'        btn.Tag(BTAG.top) = btn.Top : btn.Tag(BTAG.left) = btn.Left
'      Next
'      t(BTAG.top) = sender.top : t(BTAG.left) = sender.left

'      DIRTY = True
'    End If
'  End Sub

'  Sub pnl_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
'    ' Draw the existing rectangles.
'    e.Graphics.Clear(MAIN.BackColor)


'    ' Draw the new rectangle.
'    If m_Drawing Then
'      Dim dashed_pen As New Pen(Color.Blue, 1)
'      dashed_pen.DashStyle = Drawing2D.DashStyle.Dash
'      Dim new_rect As New Rectangle( _
'        Math.Min(m_StartX, m_CurX), _
'        Math.Min(m_StartY, m_CurY), _
'        Math.Abs(m_StartX - m_CurX), _
'        Math.Abs(m_StartY - m_CurY))
'      e.Graphics.DrawRectangle(dashed_pen, new_rect)
'      dashed_pen.Dispose()
'    End If
'  End Sub


'End Module
