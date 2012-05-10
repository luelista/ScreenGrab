Imports System.Drawing.Drawing2D

Public Class frm_setGradient

  Dim canvas As Vector.Canvas

  Sub SetCanvas(ByVal cv As Vector.Canvas)
    canvas = cv
    Dim obj As Vector.VObject = cv.GetFirstSelectedObject
    'If TypeOf obj Is Vector.VTextbox Then
    '  GradientEditPanel1.Gradient = New DrawingEx.ColorManagement.Gradients.Gradient
    'End If
    If Not TypeOf obj Is Vector.VGradientObject Then Return

    Dim gobj As Vector.VGradientObject = obj

    If gobj.Gradient Is Nothing Then
      GradientEditPanel1.Gradient = New DrawingEx.ColorManagement.Gradients.Gradient
    Else
      GradientEditPanel1.Gradient = gobj.Gradient
    End If

  End Sub

  Private Sub frm_rotateElement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    Dim obj As Vector.VObject = canvas.GetFirstSelectedObject
    
    If TypeOf obj Is Vector.VGradientObject Then
      DirectCast(obj, Vector.VGradientObject).Gradient = GradientEditPanel1.Gradient
    End If
    canvas.Invalidate()
    Me.Close()
  End Sub


End Class