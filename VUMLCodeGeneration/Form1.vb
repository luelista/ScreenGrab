Public Class Form1
  Dim sh As New scriptHelperObj()
  Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
    Dim fileSpec = ComboBox1.Text
    If IO.File.Exists(fileSpec) = False Then MsgBox("Die Skriptdatei wurde nicht gefunden.", MsgBoxStyle.Exclamation) : Exit Sub
    If fileSpec.ToUpper.EndsWith(".VBS") Then
      AxScriptControl1.Language = "VBScript"
    Else
      AxScriptControl1.Language = "JScript"
    End If
    Dim filecontent As String = IO.File.ReadAllText(fileSpec)
    AxScriptControl1.Reset()

    Dim cv As New Vector.Canvas
    cv.readHtmlPage(txtSourcefile.Text)

    Form2.Show()
    Form2.TreeView1.Nodes(0).Nodes.Clear()
    Form2.TreeView1.Nodes(0).Text = IO.Path.GetFileName(txtSourcefile.Text)

    AxScriptControl1.AddObject("Canvas", cv, False)
    AxScriptControl1.AddObject("Helper", sh, True)

    Try
      AxScriptControl1.AddCode(filecontent)
    Catch ex As Exception
      With sh.AddFile("script_errors.txt")
        .WriteLine("Script-Fehler #" & AxScriptControl1.Error.Number)
        .WriteLine("Exception Message: " & ex.Message)
        .WriteLine("Line/Col. " & AxScriptControl1.Error.Line & " : " & AxScriptControl1.Error.Column)
        .WriteLine("Beschreibung: " & AxScriptControl1.Error.Description)
        .WriteLine("Text: " & AxScriptControl1.Error.Text)
        .WriteLine("")
        .WriteLine("")
      End With
    End Try

    Form2.TreeView1.Nodes(0).Expand()

    SaveSetting("ScreenGrab", "VUMLCodeGeneration", "SelectedConverter", ComboBox1.Text)
    Me.Close()
  End Sub

  Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
    SaveSetting("ScreenGrab", "VUMLCodeGeneration", "SelectedConverter", ComboBox1.Text)
    Me.Close()
  End Sub

  Private Sub AxScriptControl1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AxScriptControl1.Enter

  End Sub

  Private Sub AxScriptControl1_ErrorEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles AxScriptControl1.ErrorEvent

    With sh.AddFile("script_errors.txt")
      .WriteLine("Script-Fehler #" & AxScriptControl1.Error.Number)
      .WriteLine("Line/Col. " & AxScriptControl1.Error.Line & " : " & AxScriptControl1.Error.Column)
      .WriteLine("Beschreibung: " & AxScriptControl1.Error.Description)
      .WriteLine("Text: " & AxScriptControl1.Error.Text)
      .WriteLine("")
      .WriteLine("")
    End With
  End Sub

  Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    SaveSetting("ScreenGrab", "VUMLCodeGeneration", "SelectedConverter", ComboBox1.Text)
  End Sub

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    IO.Directory.CreateDirectory("C:\yPara\screengrab5\vumlcg_debug\")

    If String.IsNullOrEmpty(Command) Then MsgBox("Dieses Programm wird vom ScreenGrab-Collage-Modus verwendet und kann nicht direkt gestartet werden.", MsgBoxStyle.Critical, "Screengrab") : End
    If IO.File.Exists(Command) = False Then MsgBox("Datei nicht gefunden", MsgBoxStyle.Critical, "Screengrab") : End

    txtSourcefile.Text = Command()

    Dim folder As String = IO.Path.GetDirectoryName(Application.ExecutablePath)
    For Each file In IO.Directory.GetFiles(folder, "*.vbs")
      ComboBox1.Items.Add(file)
    Next
    For Each file In IO.Directory.GetFiles(folder, "*.js")
      ComboBox1.Items.Add(file)
    Next

    ComboBox1.Text = GetSetting("ScreenGrab", "VUMLCodeGeneration", "SelectedConverter")
  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    Using ofd As New OpenFileDialog
      ofd.Filter = "Scriptdatei (*.vbs, *.js)|*.vbs;*.js|Alle Dateien|*.*"
      ofd.FileName = ComboBox1.Text
      If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
        ComboBox1.Text = ofd.FileName
      End If
    End Using
  End Sub
End Class
