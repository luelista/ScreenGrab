Imports System.Windows.Forms

Public Class frm_textEditor
  Public vt As Vector.VTextbox, cvs As Vector.Canvas

  Sub setTextboxObject(ByVal canvas As Vector.Canvas, ByVal box As Vector.VTextbox)
    cvs = canvas : vt = box
    TextBox1.Font = vt.fnt
    btnFormat.Enabled = True
  End Sub

  Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
    Me.DialogResult = System.Windows.Forms.DialogResult.OK
    '  Me.Close()
  End Sub

  Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Close()
  End Sub

  Private Sub frm_testEditor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub


  Private Sub btnFormat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFormat.Click
    Dim oldFont As Font
    FontDialog1.Font = vt.fnt
    oldFont = vt.fnt
    If FontDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
      vt.fnt = FontDialog1.Font
    Else
      vt.fnt = oldFont
    End If
    cvs.Invalidate()
  End Sub

  Private Sub FontDialog1_Apply(ByVal sender As Object, ByVal e As System.EventArgs) Handles FontDialog1.Apply
    vt.fnt = FontDialog1.Font
    cvs.Invalidate()
  End Sub
End Class
