Imports System.Runtime.InteropServices
Imports WeifenLuo.WinFormsUI.Docking

Public Class Program
  Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Long

  Public Shared settingsFolder As String = "C:\yPara\ScreenGrab5\"

  Public Shared glob As New cls_globPara("Weller IT\ScreenGrab", "Collage")

  Public Shared MDI As MainWindow
  Public Shared traceWin As frm_trace

  Public Shared sbElements As ElementsDockContent
  Public Shared sbFiles As FilesDockContent
  Public Shared sbTemplates As TemplatesDockContent
  Public Shared sbCloud As CloudDockContent
  Public Shared sbColor As frm_paletteColor

  'Your consumer key:
  Public Const IMGUR_CONSUMER_KEY = "61738ac8d372a889fce4a5729ef43f0c04e9573f2"
  'Your consumer secret:
  Public Const IMGUR_CONSUMER_SECRET = "319690a9c959d2bd94a8fd7ee1b7e64e"

  <StructLayout(LayoutKind.Sequential)> _
  Public Structure RECT
    Public Left As Integer
    Public Top As Integer
    Public Right As Integer
    Public Bottom As Integer

    Public Sub New(ByVal pLeft As Integer, ByVal pTop As Integer, ByVal pRight As Integer, ByVal pBottom As Integer)
      Left = pLeft
      Top = pTop
      Right = pRight
      Bottom = pBottom
    End Sub
    Public Sub New(ByVal managedRect As Rectangle)
      Left = managedRect.Left
      Top = managedRect.Top
      Right = managedRect.Right
      Bottom = managedRect.Bottom
    End Sub
  End Structure

  Public Enum MWSGInfo
    SIG
    SIG2
    reserved1
    url
    reserved2
    UserName
    DestRect
    TextBox1
    txtComment
    reserved3
  End Enum



  Public Shared Function newClient() As frm_mdiClient
    Dim f As New frm_mdiClient
    'f.MdiParent = Me
    'f.Show()
    'f.Activate()
    f.Text = String.Format("Unbenannt {0}", untitledCounter)
    untitledCounter += 1
    f.Show(MDI.DockPanel1, DockState.Document)
    'f.Left = 0 : f.Top = 0 : f.Width = ClientControl.Width - 5 : f.Height = ClientControl.Height - 5
    'While Not TabControl1.SelectedForm Is f
    '  Application.DoEvents()
    'End While
    Return f
  End Function


  Private Shared untitledCounter As Integer = 1

  Public Shared Function vcc() As Vector.VCanvasControl
    Dim c = client()
    If c Is Nothing Then Return Nothing
    Return c.vcc
  End Function
  Public Shared Function client() As frm_mdiClient
    If MDI.DockPanel1.ActiveDocument Is Nothing OrElse TypeOf MDI.DockPanel1.ActiveDocument IsNot frm_mdiClient Then Return Nothing
    ' Return ActiveMdiChild
    Return DirectCast(MDI.DockPanel1.ActiveDocument, frm_mdiClient)
  End Function

  Shared Function CreateNiceFileSize(ByVal size As Long) As String
    Dim run As Integer = 0
    Dim d As Double = Convert.ToDouble(size)
    Dim sizes As String() = {"B", "KB", "MB", "GB"}
    While d >= 1024
      d /= 1024
      run += 1
    End While

    Dim dou As Double = Math.Round(d, 2)
    Dim sizestring As String = dou.ToString()

    Return (sizestring + " " + sizes(run))
  End Function



End Class
