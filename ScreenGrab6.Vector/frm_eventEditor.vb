Imports System.Windows.Forms

Public Class frm_eventEditor
  Public vt As Vector.VObject, cvs As Vector.Canvas

  Sub setObject(ByVal canvas As Vector.Canvas, ByVal box As Vector.VObject)
    cvs = canvas : vt = box

  End Sub

  Private Sub ListBox1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox1.MouseClick
    If vt.onevent.ContainsKey(ListBox1.SelectedItem) Then
      TextBox1.Text = vt.onevent(ListBox1.SelectedItem)
    Else
      TextBox1.Text = ""
    End If
  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    vt.onevent(ListBox1.SelectedItem) = TextBox1.Text
  End Sub

End Class
