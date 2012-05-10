Imports System.Windows.Forms

Public Class frm_lineStyle
  Dim canvas As Vector.Canvas

  Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

    For Each item In canvas.selectedObjects
      If CheckBox1.Checked Then item.BorderWidth = nudLineWidth.Value
      If CheckBox2.Checked Then item.borderPen.DashStyle = cmbLineStyle.SelectedIndex
      If CheckBox3.Checked Then item.borderPen.Color = labColor.BackColor

    Next

    canvas.Invalidate()

    Me.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.Close()
  End Sub

  Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Close()
  End Sub

  Private Sub frm_lineStyle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub

  Sub ShowForCanvas(ByVal cv As Vector.Canvas)
    canvas = cv
    Dim lastBW As Single = Single.MinValue, lastBS As Integer = -1, lastBC As Color = Nothing, lastEA As String = ""
    Dim hasBW = True, hasBS = True, hasBC = True, hasEA As Boolean = True
    For Each item In cv.selectedObjects
      If lastBW <> Single.MinValue And item.BorderWidth <> lastBW Then hasBW = False
      If lastBS > -1 And item.borderPen.DashStyle <> lastBS Then hasBS = False
      If lastBC <> Nothing And item.borderPen.Color <> lastBC Then hasBC = False
      lastBW = item.BorderWidth
      lastBS = item.borderPen.DashStyle
      lastBC = item.borderPen.Color
    Next

    CheckBox1.Checked = hasBW
    CheckBox2.Checked = hasBS
    CheckBox3.Checked = hasBC

    nudLineWidth.Value = lastBW
    cmbLineStyle.SelectedIndex = lastBS
    labColor.BackColor = lastBC
    labColor.Text = ColorTranslator.ToHtml(lastBC)



  End Sub

  Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
    nudLineWidth.Enabled = CheckBox1.Checked
  End Sub

  Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
    cmbLineStyle.Enabled = CheckBox2.Checked
  End Sub

  Private Sub labColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles labColor.Click
    Using cd As New ColorDialog
      cd.Color = labColor.BackColor
      If cd.ShowDialog = Windows.Forms.DialogResult.OK Then
        labColor.BackColor = cd.Color
        labColor.Text = ColorTranslator.ToHtml(cd.Color)
      End If
    End Using
  End Sub
End Class
