Imports System.Drawing
Imports System.Windows.Forms

Public Class frm_canvasProperties

  Dim canvas As Vector.Canvas

  Sub SetCanvas(ByVal cv As Vector.Canvas)
    canvas = cv
    NumericUpDown1.Value = cv.PicBox.Width
    NumericUpDown2.Value = cv.PicBox.Height
    TextBox1.Text = ColorTranslator.ToHtml(cv.PicBox.BackColor)

  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    Using cd As New ColorDialog
      cd.Color = TextBox1.BackColor
      If cd.ShowDialog = Windows.Forms.DialogResult.OK Then
        TextBox1.Text = ColorTranslator.ToHtml(cd.Color)
      End If
    End Using
  End Sub

  Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
    On Error Resume Next
    TextBox1.BackColor = ColorTranslator.FromHtml(TextBox1.Text)
  End Sub

  Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
    canvas.PicBox.Width = NumericUpDown1.Value
    canvas.PicBox.Height = NumericUpDown2.Value
    canvas.PicBox.BackColor = ColorTranslator.FromHtml(TextBox1.Text)
    Me.Close()
  End Sub

  Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
    Me.Close()
  End Sub
End Class