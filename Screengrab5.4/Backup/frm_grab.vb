Public Class frm_grab
  Dim moved As Integer = 0


  Private Sub frm_grab_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
    Me.Hide()
    grabWindowDone()

  End Sub

  Private Sub tmrMousemove_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrMousemove.Tick
    If moved < 3 Then Exit Sub
    Dim cursorX As Integer = System.Windows.Forms.Cursor.Position.X
    Dim cursorY As Integer = System.Windows.Forms.Cursor.Position.Y
    
    labAuswahl.Width = cursorX - labAuswahl.Left
    labAuswahl.Height = cursorY - labAuswahl.Top

    moved = 0
  End Sub

  Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
    labAuswahl.Location = e.Location
    tmrMousemove.Enabled = True
    labAuswahl.Show()

  End Sub

  Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

  End Sub

  Private Sub frm_grab_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
    moved += 1

  End Sub

  Private Sub frm_grab_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub
End Class