Public Class frm_mdiViewerClient

  Private Sub frm_mdiViewerClient_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub

  Private Sub frm_mdiViewerClient_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
    If e.Button = Windows.Forms.MouseButtons.Left Then
      If e.X > Me.Width - 15 And e.Y > Me.Height - 15 Then
        FormResizeTricky(Me.Handle, HitTestValues.HTBOTTOMRIGHT)
      Else
        FormMoveTricky(Me.Handle)
      End If
    End If
  End Sub

  Private Sub frm_mdiViewerClient_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
    If e.X > Me.Width - 15 And e.Y > Me.Height - 15 Then
      Cursor = Cursors.SizeNWSE
    Else
      Cursor = Cursors.SizeAll
    End If
  End Sub

  Private Sub frm_mdiViewerClient_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
    If e.Button = Windows.Forms.MouseButtons.Right Then
      Me.Close()
    End If
  End Sub
End Class