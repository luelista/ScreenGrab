Imports System.Drawing.Drawing2D

Public Class AboutBox

  Private Sub AboutBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    lblProgVer.Text = My.Application.Info.Version.ToString(2)
  End Sub

  Private Sub Me_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
    Dim rect As New Rectangle(0, 0, Me.Width, Me.Height)
    Dim lgb As New Drawing2D.LinearGradientBrush(rect, Color.OliveDrab, Color.DarkOliveGreen, LinearGradientMode.Vertical)
    e.Graphics.FillRectangle(lgb, rect)
  End Sub

  Private Sub LinkLabel5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.Click, LinkLabel3.Click
    Process.Start(sender.tag)
  End Sub

End Class