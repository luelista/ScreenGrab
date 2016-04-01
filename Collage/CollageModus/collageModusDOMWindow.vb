Imports ScreenGrab6.Vector

Public Class collageModusDOMWindow
  Inherits vectorDOMWindow

  Public ReadOnly location As New collageModusDOMLocationObject()

  Sub trace(ByVal str As String)
    sys_mwTrace.Trace("Collage", str)
  End Sub

  Sub open(ByVal filespec As String)
    Dim c = Program.newClient()
    c.vcc.openFile(filespec)
  End Sub


End Class

Public Class collageModusDOMLocationObject

  Public Property href() As String
    Get
      Return Program.vcc().FileSpec
    End Get
    Set(ByVal value As String)
      Program.vcc().openFile(value)
    End Set
  End Property

End Class
