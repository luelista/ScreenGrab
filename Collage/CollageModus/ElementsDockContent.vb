Imports ScreenGrab6.Vector

Public Class ElementsDockContent

  Private Sub ElementsDockContent_Load(sender As Object, e As EventArgs) Handles MyBase.Load

  End Sub
  Sub refreshItemList()
    lstElementNames.Items.Clear()
    If Program.vcc() Is Nothing Then Exit Sub

    For Each v In Program.vcc().canvas.objects
      'lstElementNames.Items.Add(v.name)
      lstElementNames.Items.Add(v)
      'If v.isSelected Then lstElementNames.SetItemChecked(lstElementNames.Items.Count - 1, True)
    Next
    Program.MDI.txtElementName.Text = Join(Program.client.selNames, ", ")
    Program.MDI.txtElementName.Enabled = Program.vcc.canvas.SelectionCount = 1

    ' If vcc.canvas.SelectionCount <> 1 Then lstElementNames.SelectedIndex = -1
  End Sub
  Private Sub lstElementNames_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles lstElementNames.DrawItem
    If e.Index < 0 Then Return
    Dim obj As VObject = lstElementNames.Items(e.Index)

    Windows.Forms.ControlPaint.DrawCheckBox(e.Graphics, e.Bounds.X + 1, e.Bounds.Y + 10, 16, 16, _
                                            If(obj.isSelected, ButtonState.Checked, ButtonState.Normal))

    e.Graphics.DrawImage(obj.GetAsImage(), e.Bounds.X + 20, e.Bounds.Y, e.Bounds.Width - 20, e.Bounds.Height)

  End Sub

  Private Sub lstElementNames_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstElementNames.LostFocus
    ' pnlElements.Hide()
  End Sub

  Private Sub lstElementNames_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstElementNames.MouseDown
    If Program.vcc() Is Nothing Then Return
    If e.Button = Windows.Forms.MouseButtons.Left Then
      Dim idx = lstElementNames.IndexFromPoint(e.Location)
      If idx = -1 Then Return
      'Dim obj = Program.vcc().canvas.GetObjectByID(lstElementNames.Items(idx))
      Dim obj As VObject = lstElementNames.Items(idx)
      obj.isSelected = Not obj.isSelected
      Program.vcc.canvas.OnSelectionChanged()
      Return
    End If

    If e.Button = Windows.Forms.MouseButtons.Right Then
      Dim idx = lstElementNames.IndexFromPoint(e.Location)
      If idx > -1 Then
        Program.vcc.canvas.SelectObject(lstElementNames.Items(idx))
      End If
    End If

    ' pnlElements.Hide()
  End Sub
End Class