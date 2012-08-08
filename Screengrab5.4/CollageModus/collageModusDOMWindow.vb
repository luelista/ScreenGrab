Public Class collageModusDOMWindow
  Inherits Vector.vectorDOMWindow

  Public ReadOnly location As New collageModusDOMLocationObject()

  Sub trace(ByVal str As String)
    MDI.lstTrace.Items.Add(str)
    MDI.lstTrace.SelectedIndex = MDI.lstTrace.Items.Count - 1
  End Sub

  Sub open(ByVal filespec As String)
    Dim c = MDI.newClient
    c.vcc.openFile(filespec)
  End Sub


End Class

Public Class collageModusDOMLocationObject

  Public Property href() As String
    Get
      Return MDI.vcc.FileSpec
    End Get
    Set(ByVal value As String)
      MDI.vcc.openFile(value)
    End Set
  End Property

End Class
