Public Class frm_rotateElement

  Dim canvas As Vector.Canvas

  Sub SetCanvas(ByVal cv As Vector.Canvas)
    canvas = cv
    Dim rot As Integer = cv.GetFirstSelectedObject.rotation
    If rot > 180 Then rot = -(180 - (rot - 180))
    TrackBar1.Value = rot
    Label2.Text = rot & " °"
    Select Case cv.GetSelectionType().ToUpper
      Case "VLINE", "VARROW"
        Label1.Text = "Linien und Pfeile dürfen nicht gedreht werden."
        TrackBar1.Enabled = False
        Label2.Enabled = False
    End Select
  End Sub

  Private Sub frm_rotateElement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    Me.Close()
  End Sub

  Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
    Dim rot As Integer = TrackBar1.Value
    Label2.Text = rot & " °"
    If rot < 0 Then rot = 360 + rot
    For Each v In canvas.selectedObjects
      v.rotation = rot
    Next
    canvas.Invalidate()
  End Sub
End Class