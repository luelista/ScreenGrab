Imports Microsoft.VisualBasic.ApplicationServices
Imports ScreenGrab6.Vector
Imports System.IO

Namespace My
  ' Für MyApplication sind folgende Ereignisse verfügbar:
  ' Startup: Wird beim Starten der Anwendung noch vor dem Erstellen des Startformulars ausgelöst.
  ' Shutdown: Wird nach dem Schließen aller Anwendungsformulare ausgelöst. Dieses Ereignis wird nicht ausgelöst, wenn die Anwendung mit einem Fehler beendet wird.
  ' UnhandledException: Wird bei einem Ausnahmefehler ausgelöst.
  ' StartupNextInstance: Wird beim Starten einer Einzelinstanzanwendung ausgelöst, wenn die Anwendung bereits aktiv ist. 
  ' NetworkAvailabilityChanged: Wird beim Herstellen oder Trennen der Netzwerkverbindung ausgelöst.
  Partial Friend Class MyApplication

    Protected Overrides Sub OnStartupNextInstance(eventArgs As StartupNextInstanceEventArgs)
      eventArgs.BringToForeground = True

      Try
        Dim para(eventArgs.CommandLine.Count) As String
        eventArgs.CommandLine.CopyTo(para, 0)
        handleCommandLine(para)
      Catch ex As Exception
        MessageBox.Show(ex.Message, "Fehlerhafte Parameter", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

      MyBase.OnStartupNextInstance(eventArgs)
    End Sub


    Public Shared Sub handleCommandLine(cmd As String())
      For i As Integer = 1 To cmd.Length - 1
        Select Case cmd(i).ToUpper
          Case "/ADDIMAGE"
            If i = cmd.Length - 1 Then Throw New Exception("Missing command line parameter for /ADDIMAGE")
            Dim imgPara As String = cmd(i + 1)
            i = i + 1

            Dim vcc = Program.vcc()
            If vcc Is Nothing Then
              vcc = Program.newClient().vcc
            End If
            Dim obj As New VImage()
            obj.name = "img_" + IO.Path.GetFileName(imgPara) + "_" + Now.Ticks.ToString
            obj.img = LoadImage(imgPara)
            obj.source = "FILE:" + imgPara
            obj.bounds = New Rectangle(100, 100, obj.img.Width, obj.img.Height)
            'obj.setBorder(2, Color.RoyalBlue)
            vcc.canvas.addObject(obj)

          Case "/OPEN"
            If i = cmd.Length - 1 Then Throw New Exception("Missing command line parameter for /ADDIMAGE")
            Dim imgPara As String = cmd(i + 1)
            i = i + 1

            If Not File.Exists(imgPara) Then Throw New Exception("Could not find file " + imgPara)
            Dim f = Program.newClient()
            f.vcc.openFile(imgPara)

          Case Else
            If Not File.Exists(cmd(i)) Then Throw New Exception("Could not find file " + cmd(i))

            Dim f = Program.newClient()
            f.vcc.openFile(cmd(i))


        End Select
      Next i

    End Sub

  End Class
End Namespace
