Module app_insertWord

  Dim wordApp, wordDoc As Object

  Function IsWordInitialised() As Boolean
    Return wordApp IsNot Nothing And wordDoc IsNot Nothing
  End Function

  Sub CreateWordInstance()
    Try
      wordApp = System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application")
    Catch
      wordApp = CreateObject("Word.Application")
    End Try
    If wordApp.documents.count > 0 Then
      wordDoc = wordApp.activedocument
    Else
      wordDoc = wordApp.documents.add()
    End If
    wordApp.visible = True

  End Sub

  Sub InsertImage(ByVal img As Image)
try_again:
    Try
      Dim MyRange1 = wordDoc.Paragraphs.Add.Range
      With MyRange1
        .Font.Name = "Arial"
        .Font.Size = "8"
        .Font.Italic = True
        .InsertBefore(vbCrLf & "Eingefügt mit ScreenGrab " & My.Application.Info.Version.ToString(2) & " am " & Now.ToShortDateString & " um " & Now.ToLongTimeString)
      End With

      Dim fileName = IO.Path.Combine(IO.Path.GetTempPath, "wordImage.png")
      img.Save(fileName, System.Drawing.Imaging.ImageFormat.Png)

      MyRange1.InlineShapes.AddPicture(fileName)
      IO.File.Delete(fileName)

    Catch ex As Exception
      If MsgBoxResult.Retry = MsgBox("Beim Einfügen des Screenshots in das aktuelle Word-Dokument ist ein Fehler aufgetreten." + vbNewLine + vbNewLine + ex.Message + vbNewLine + vbNewLine + "Falls das Dokument zwischenzeitlich geschlossen wurde, klicke auf Wiederholen, um ein neues Dokument zu erstellen.", MsgBoxStyle.RetryCancel Or MsgBoxStyle.Exclamation, "Fehler") Then
        CreateWordInstance()
        GoTo try_again
      End If
    End Try
  End Sub

End Module
