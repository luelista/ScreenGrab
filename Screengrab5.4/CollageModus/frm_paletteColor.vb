Public Class frm_paletteColor

  Private Sub GColorPicker1_ColorChanging(ByVal sender As Object, ByVal CurrentColor As System.Drawing.Color, ByVal ClosestColorName As String) Handles GColorPicker1.ColorChanging
    frm_mdiViewer2.setCurrentDefaultColor(CurrentColor)
  End Sub

  Private Sub GColorPicker1_ColorPicked(ByVal sender As System.Object, ByVal CurrentColor As System.Drawing.Color, ByVal ClosestColorName As System.String) Handles GColorPicker1.ColorPicked

  End Sub

  Private Sub frm_paletteColor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub
End Class