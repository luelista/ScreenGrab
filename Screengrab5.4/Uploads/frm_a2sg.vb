Imports System.Windows.Forms

Public Class frm_a2sg


  Delegate Sub dloadImage(ByVal img As Image)
  Public Delegate Sub dhandleConnection(ByVal tcp As System.Net.Sockets.TcpClient)

  Shared Sub handleConnection(ByVal tcp As System.Net.Sockets.TcpClient)
    Dim dialog As New frm_a2sg
    Try
      Dim recvd As UInt64 = 0, recdat As Integer = 0
      Dim str = tcp.GetStream()
      Dim buf(1024) As Byte
      'Dim red As New System.IO.BinaryReader(str)
      Dim bin As New System.IO.BinaryWriter(str)
      'bin.Write(New Char() {"S", "S", "F", "P"})
      'bin.Write(CInt(&H10000))
      'bin.Write(CByte(1))
      str.Read(buf, 0, 9)
      'red.ReadInt32() 'should be SSFP
      'red.ReadInt32()
      'red.ReadByte()
      bin.Write(CInt(&H54465353))


      'Dim fnlen As Short = red.ReadInt16()
      str.Read(buf, 0, 2)
      Dim fnlen As Short = BitConverter.ToInt16(buf, 0)
      If fnlen < 0 Or fnlen > 1024 Then
        bin.Write(CType(1, UInt64)) : bin.Write(CByte(1))
        bin.Flush() : tcp.Close() : Return
      End If

      str.Read(buf, 0, fnlen * 2)
      Dim fn As String = System.Text.Encoding.Unicode.GetString(buf, 0, fnlen * 2)

      str.Read(buf, 0, 8)
      Dim fsiz As UInt64 = BitConverter.ToUInt64(buf, 0)  ' red.ReadInt64

      Dim fext As String = "XXX"
      If fnlen > 3 Then fext = fn.Substring(fnlen - 3).ToUpper

      dialog.Label2.Text = fn
      dialog.Label3.Text = "(" & fsiz & " Byte)"
      dialog.lblSource.Text = If(fext <> "PNG" And fext <> "JPG", "Quelle: " & tcp.Client.RemoteEndPoint.ToString, "")
      dialog.lblDownloadDir.Visible = fext <> "PNG" And fext <> "JPG"
      dialog.chkAlways.Visible = Not (fext <> "PNG" And fext <> "JPG")
      dialog.chkAlways.Text = "Bilder von " & tcp.Client.RemoteEndPoint.ToString & " immer annehmen"
      If (dialog.ShowDialog() = Windows.Forms.DialogResult.Cancel) Then
        bin.Write(CType(1, UInt64)) : str.Read(buf, 0, 16) : bin.Write(CByte(1))
        bin.Flush() : tcp.Close()
        dialog.Close() : dialog.Dispose()
        Return
      End If
      dialog.Show()
      dialog.chkAlways.Hide()

      bin.Write(CType(0, UInt64))
      dialog.ProgressBar1.Show() : dialog.ProgressBar1.Maximum = fsiz

      If fext <> "PNG" And fext <> "JPG" Then
        Dim dlDir As String = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Downloads")
        System.IO.Directory.CreateDirectory(dlDir)
        Dim targetFile As String = System.IO.Path.Combine(dlDir, fn)
        If targetFile.StartsWith(dlDir) = False Then
          tcp.Close() : Return
        End If
        Dim fout As New System.IO.FileStream(targetFile, IO.FileMode.CreateNew)
        While recvd < fsiz
          recdat = str.Read(buf, 0, Math.Min(1024, fsiz - recvd))
          recvd += recdat
          fout.Write(buf, 0, recdat)
          dialog.ProgressBar1.Value = recvd : Application.DoEvents()
        End While
        fout.Close()
        tcp.Close()

        Return
      End If


      Dim buf2() As Byte = New Byte(fsiz) {}
      While recvd < fsiz
        recdat = str.Read(buf2, recvd, Math.Min(1024, fsiz - recvd))
        recvd += recdat
        dialog.ProgressBar1.Value = recvd : Application.DoEvents()
      End While

      Dim img As Image = Image.FromStream(New System.IO.MemoryStream(buf2))
      FRM.Invoke(New dloadImage(AddressOf loadImage), img)

      'loadImage(img)
    Catch ex As Exception
      MsgBox("Error in file recv" + vbNewLine + ex.Message)
    Finally

      Try : tcp.Close() : dialog.Close() : Catch : End Try
      FRM.a2sg_receiver.BeginAcceptTcpClient(AddressOf FRM.onA2SGConnection, Nothing)
    End Try
  End Sub

  Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

    'Me.DialogResult = System.Windows.Forms.DialogResult.OK
    'Me.Close()
  End Sub

  Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
    'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    'Me.Close()
  End Sub

  Private Sub frm_a2sg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    'TextBox1.Text = glob.para("android_dev_id")
  End Sub

  Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    Process.Start("http://android-to-screengrab.0815team.de/download.html")

  End Sub
End Class
