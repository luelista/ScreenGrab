Public Class vectorDOMWindow

  Private allowShellEx As Boolean = False

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

  Public Sub shellExecute(ByVal filespec As String, Optional ByVal para As String = "")
    If allowShellEx OrElse MsgBoxResult.Ok = MsgBox("Achtung! Ein Skript in diesem Dokument möchte folgenden Befehl ausführen:" + vbNewLine + vbNewLine + filespec + " " + para + vbNewLine + vbNewLine + "Klicken Sie auf OK, um den Befehl auszuführen und diesen Dialog bis zum Schließen des Dokuments nicht mehr anzuzeigen." + vbNewLine + "Klicken Sie auf Abbrechen, um den Befehl nicht auszuführen.", MsgBoxStyle.OkCancel Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Exclamation, "ShellExecute") Then

      allowShellEx = True
      Process.Start(filespec, para)
    End If
  End Sub

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

