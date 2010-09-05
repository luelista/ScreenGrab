Public Class frm_inner
  
  Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

  End Sub

  'Place this code anywhere on your form code
#Region " ClientAreaMove Handling "
  Const WM_NCHITTEST As Integer = &H84
  Const HTCLIENT As Integer = &H1
  Const HTCAPTION As Integer = &H2
  Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
    Select Case m.Msg
      Case WM_NCHITTEST
        MyBase.WndProc(m)
        If m.Result = HTCLIENT Then m.Result = HTCAPTION
        'If m.Result.ToInt32 = HTCLIENT Then m.Result = IntPtr.op_Explicit(HTCAPTION) 'Try this in VS.NET 2002/2003 if the latter line of code doesn't do it... thx to Suhas for the tip.
      Case Else
        'Make sure you pass unhandled messages back to the default message handler.
        MyBase.WndProc(m)
    End Select
  End Sub
#End Region


  Private Sub frm_inner_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    Select Case e.KeyCode
      Case 46
        Me.Dispose()
    End Select
  End Sub

  Private Sub frm_inner_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub
End Class
