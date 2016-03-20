Public Class frm_trace

  Sub New()

    ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
    InitializeComponent()

    ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

    AddHandler sys_mwTrace.TraceWrite, AddressOf onTraceWrite
  End Sub

  Sub onTraceWrite(ByVal para1 As String, ByVal para2 As String, ByVal type As String, ByVal codeLink As String)
    MDI.traceWin.lstTrace.Items.Add(para1 + "\t" + para2)
    MDI.traceWin.lstTrace.SelectedIndex = MDI.traceWin.lstTrace.Items.Count - 1
  End Sub


  Private Sub lstTrace_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstTrace.SelectedIndexChanged
    Try
      TextBox1.Text = lstTrace.SelectedItem
    Catch : TextBox1.Text = "" : End Try
  End Sub

  Private Sub LeerenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeerenToolStripMenuItem.Click
    lstTrace.Items.Clear() : TextBox1.Text = ""
  End Sub

  Private Sub frm_trace_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
    If e.CloseReason = CloseReason.UserClosing Then
      Hide()
      e.Cancel = True
    End If
  End Sub
End Class