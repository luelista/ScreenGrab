Public Class frm_innerText

  Private Sub RichTextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RichTextBox1.KeyDown
    If e.Control Then
      If e.KeyCode = 13 Then
        If Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
          Me.FormBorderStyle = Windows.Forms.FormBorderStyle.SizableToolWindow
        Else
          Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
          noFocus()

        End If
        e.SuppressKeyPress = True


      End If
    End If
  End Sub

  Private Sub RichTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox1.TextChanged

  End Sub
End Class