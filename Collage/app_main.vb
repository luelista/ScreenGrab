Imports System.Runtime.InteropServices

Public Module app_main
  Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Long

  Public settingsFolder As String = "C:\yPara\ScreenGrab5\"

  Public glob As New cls_globPara(settingsFolder + "Collage.Para")

  Public MDI As frm_mdiViewer2

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


  Function CreateNiceFileSize(ByVal size As Long) As String
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



End Module
