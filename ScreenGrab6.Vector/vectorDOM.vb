Public Class vectorDOMWindow

  Private _document As vectorDOMDocument
  Public Property Document() As vectorDOMDocument
    Get
      Return _document
    End Get
    Friend Set(ByVal value As vectorDOMDocument)
      _document = value
    End Set
  End Property

  Public Sub alert(ByVal str As String)
    MsgBox(str, MsgBoxStyle.Exclamation, "Alert")
  End Sub
  Public Function confirm(ByVal str As String) As Boolean
    Return (MsgBox(str, MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Confirm") = MsgBoxResult.Ok)
  End Function

End Class

Public Class vectorDOMDocument

  Dim canv As Canvas

  Public Sub New(ByVal canvasReference As Canvas)
    canv = canvasReference
  End Sub

  Public Function getElementById(ByVal id As String) As VObject
    Return canv.GetObjectByID(id)
  End Function

  Public ReadOnly Property all() As Collections.ObjectModel.ReadOnlyCollection(Of VObject)
    Get
      Return canv.objects
    End Get
  End Property


End Class

