Imports System.Runtime.InteropServices

Public Class Form1


  Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    If isKeyPressed(Keys.PrintScreen) = True And isKeyPressed(Keys.ControlKey) = True Then
      startScreenshot()
      Clipboard.Clear()
      Clipboard.SetImage(PictureBox1.Image)
      Dim folder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\Screengrabs\"
      IO.Directory.CreateDirectory(folder)
      PictureBox1.Image.Save(folder + Now.ToString("yyyy-MM-dd HH-mm-ss") + ".png", System.Drawing.Imaging.ImageFormat.Png)

    End If
  End Sub

End Class
