Class multiUploadJob
  Public Typ As String
  Public TargetFolder As String
  Public FileNamePattern As String
  Public LfdNr As Integer

  Public Caption As String

  Public Server_Name, Server_User, Server_Pass As String


  Public Sub New()
  End Sub

  Public Sub New(ByVal pSerialized As String)
    Me.Ser = pSerialized
  End Sub

  Public Overrides Function ToString() As String
    If String.IsNullOrEmpty(Caption) And String.IsNullOrEmpty(Typ) Then Return "[]"
    If String.IsNullOrEmpty(Caption) Then Return "[" + Typ + "] " + TargetFolder

    Return If(LfdNr > 0, "[" & LfdNr & "]  ", "") & Caption
  End Function

  Sub DoJob(ByVal fileSpec As String)
    Select Case Typ
      Case "Loc"
        DoJob_Local(fileSpec)

      Case "TW"
        DoJob_TeamWiki(fileSpec)

      Case "FTP"


    End Select
  End Sub

  Sub DoJob_TeamWiki(ByVal fileSpec As String)
    Dim pic As System.Drawing.Image = getCompleteImage()
    If pic Is Nothing Then MsgBox("Bitte erst einen Screenshot machen!", MsgBoxStyle.Information) : Exit Sub

    'Zielverzeichnis ermitteln
    Dim scFolder, scFile, autoFilename As String
    If FileNamePattern <> "" Then
      autoFilename = String.Format(FileNamePattern, LfdNr, Now)
      scFile = autoFilename
    End If
    Dim R = ChooseFile_TeamWiki(TargetFolder, scFolder, scFile)
    If R = False Then Exit Sub
    If scFile.Contains(".") = False Then scFile += ".png"

    showUploadInProgress()
    Dim fldParts() = Split(scFolder, "/", 3)
    Dim url As String = ""
    If fldParts.Length = 3 AndAlso fldParts(1) = "webspace" Then
      url = "http://" + fldParts(0) + ".teamwiki.net/docs/" + fldParts(2) + scFile
      Clipboard.Clear()
      Clipboard.SetText(url)
    End If
    frm_tempScreenShotName.txtFullURL.Text = url
    frm_tempScreenShotName.Text = "ScreenShot wird ins TeamWiki hochgeladen ..."

    'Lokal zwischenspeichern
    Dim ext = IO.Path.GetExtension(scFile)
    Dim tempFile = glob.fp(IO.Path.GetTempPath(), "grab5_temp" + ext)
    Try
      SaveImage(tempFile, pic)
    Catch ex As Exception
      MsgBox("Fehler beim Speichern des temporären Bildes!" + vbNewLine + ex.Message, MsgBoxStyle.Exclamation)
      'frm_uploadInProgress.Hide()
      Exit Sub
    End Try

    'hochladen
    Dim errMes As String
    upload_file(tempFile, scFile, False, "", scFolder, errMes)

    frm_tempScreenShotName.Hide()
    If errMes.StartsWith("OK,") Then
      Dim url2 = errMes.Substring(3).Trim
      If url2 <> url Then
        MsgBox("Der Server hat eine andere URL zurückgeliefert als ScreenGrab erwartet. Eventuell ist eine neuere Programmversion verfügbar." + vbNewLine + vbNewLine + "Erwartete URL: " + url + vbNewLine + "Tatsächliche URL: " + url2, MsgBoxStyle.Information)
      End If

    Else
      MsgBox("Fehler beim Hochladen aufgetreten!" + vbNewLine + errMes, MsgBoxStyle.Exclamation)
    End If

    'Lfd. Nr. nur hochzählen, wenn Dateiname nicht abgeändert wurde ...
    If autoFilename = scFile Then LfdNr += 1
  End Sub

  Function ChooseFile_TeamWiki(ByVal initDir As String, ByRef scFolder As String, ByRef scFilename As String) As Boolean
    Dim file As String = Now().ToString("yyMMdd-HHmmss")
    Using sfd As New frm_teamwikiSaveFileDialog
      sfd.Text = "Bild speichern unter ..."
      'sfd.InitialDirectory = initDir
      'sfd.Filter = "PNG - Portable Network Graphics|*.png|JPG - JPG/JPEG Format|*.jpg|GIF - Compuserve GIF|*.gif|BMP - Windows Bitmap|*.bmp|Alle Dateien (*.*)|*.*)"
      If initDir <> "" Then sfd.InitialDirectory = initDir
      If scFilename <> "" Then sfd.FileName = scFilename

      If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
        scFolder = sfd.InitialDirectory
        scFilename = sfd.FileName
        Return True
      Else
        Return False
      End If
    End Using
  End Function

  Sub DoJob_Local(ByVal fileSpec As String)
    Dim pic As System.Drawing.Image = getCompleteImage()
    If pic Is Nothing Then MsgBox("bitte erst einen Screenshot machen!") : Exit Sub

    Dim targetFileSpec As String
    If FileNamePattern <> "" Then
      targetFileSpec = glob.fp(TargetFolder, String.Format(FileNamePattern, LfdNr, Now))
    Else
      targetFileSpec = ChooseFile_Local(TargetFolder)
    End If
    If targetFileSpec = "" Then Exit Sub

    SaveImage(targetFileSpec, pic)

    LfdNr += 1
  End Sub

  Function ChooseFile_Local(ByVal initDir As String) As String
    Dim file As String = Now().ToString("yyMMdd-HHmmss")
    Using sfd As New SaveFileDialog
      sfd.Title = "Bild speichern unter ..."
      sfd.FileName = file
      sfd.Filter = "PNG - Portable Network Graphics|*.png|JPG - JPG/JPEG Format|*.jpg|GIF - Compuserve GIF|*.gif|BMP - Windows Bitmap|*.bmp|Alle Dateien (*.*)|*.*)"
      If initDir <> "" Then sfd.InitialDirectory = initDir

      If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
        Return sfd.FileName
      Else
        Return ""
      End If

    End Using
  End Function


  Property Ser() As String
    Get
      Return "|##|" & Caption & "|##|" & Typ & "|##|" & TargetFolder & "|##|" & FileNamePattern & "|##|" & LfdNr & "|##|" & Server_Name & "|##|" & Server_User & "|##|" & Server_Pass
    End Get
    Set(ByVal value As String)
      Dim Parts() = Split(value, "|##|")
      ReDim Preserve Parts(10)
      Caption = Parts(1)
      Typ = Parts(2)
      TargetFolder = Parts(3)
      FileNamePattern = Parts(4)
      LfdNr = Parts(5)
      Server_Name = Parts(6)
      Server_User = Parts(7)
      Server_Pass = Parts(8)
    End Set
  End Property

End Class
