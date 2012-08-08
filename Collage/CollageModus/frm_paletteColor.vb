Public Class frm_paletteColor

  Private Sub GColorPicker1_ColorChanging(ByVal sender As Object, ByVal CurrentColor As System.Drawing.Color, ByVal ClosestColorName As String) Handles GColorPicker1.ColorChanging
    MDI.vcc.setCurrentDefaultColor(CurrentColor)
    TextBox1.Text = ColorTranslator.ToHtml(CurrentColor)
  End Sub

  Private Sub GColorPicker1_ColorPicked(ByVal sender As System.Object, ByVal CurrentColor As System.Drawing.Color, ByVal ClosestColorName As System.String) Handles GColorPicker1.ColorPicked

  End Sub

  Private Sub frm_paletteColor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub

  Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
    On Error Resume Next
    GColorPicker1.Value = ColorTranslator.FromHtml(TextBox1.Text)
  End Sub
End Class