Public Class frm_paletteCursor



  Private Sub frm_paletteCursor_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
    For i = 0 To frm_mdiViewer2.vcc.canvas.objects.Count - 1
      e.Graphics.DrawString(i & ": " & frm_mdiViewer2.vcc.canvas.objects(i).name, Font, Brushes.Black, 2, i * 15)


    Next
  End Sub
End Class