Imports System.Drawing.Drawing2D

Public Class AboutBox
  Private Sub AboutBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    glob.readTuttiFrutti(Me)
    lblProgVer.Text = My.Application.Info.Version.ToString(2)
  End Sub

  Private Sub TabPage4_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
    Dim rect As New Rectangle(0, 0, Me.Width, Me.Height)
    Dim lgb As New Drawing2D.LinearGradientBrush(rect, Color.DodgerBlue, Color.RoyalBlue, LinearGradientMode.Vertical)
    e.Graphics.FillRectangle(lgb, rect)
  End Sub

  Private Sub LinkLabel5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked, LinkLabel3.LinkClicked
    Process.Start(sender.tag)
  End Sub

  Private Sub btnUpdateCheckNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateCheckNow.Click
    btnUpdateCheckNow.Enabled = False
    If checkForUpdate() Then
      frm_softwareUpdate.Show()
      frm_softwareUpdate.startDownload()
    End If
    btnUpdateCheckNow.Enabled = True
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    glob.saveTuttiFrutti(Me)
  End Sub
End Class