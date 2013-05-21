Imports System.Runtime.InteropServices
Module sys_assocIcon

  Private Structure SHFILEINFO
    Public hIcon As IntPtr            ' : icon
    Public iIcon As Integer           ' : icondex
    Public dwAttributes As Integer    ' : SFGAO_ flags
    <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> _
    Public szDisplayName As String
    <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> _
    Public szTypeName As String
  End Structure

  Private Declare Auto Function SHGetFileInfo Lib "shell32.dll" _
          (ByVal pszPath As String, _
           ByVal dwFileAttributes As Integer, _
           ByRef psfi As SHFILEINFO, _
           ByVal cbFileInfo As Integer, _
           ByVal uFlags As Integer) As IntPtr

  Private Const SHGFI_ICON = &H100
  Enum assoc_iconSize
    SHGFI_SMALLICON = &H1
    SHGFI_LARGEICON = &H0    ' Large icon
  End Enum

  Function GetAssociatedIcon(ByVal fileSpec As String, _
                             Optional ByVal iconSize As assoc_iconSize = assoc_iconSize.SHGFI_LARGEICON _
                             ) As Icon

    Dim hImg As IntPtr  'The handle to the system image list.
    Dim shinfo As SHFILEINFO
    shinfo = New SHFILEINFO()

    hImg = SHGetFileInfo(fileSpec, 0, shinfo, _
                    Marshal.SizeOf(shinfo), _
                    SHGFI_ICON Or iconSize)

    'The icon is returned in the hIcon member of the
    'shinfo struct.
    Dim myIcon As System.Drawing.Icon
    If shinfo.hIcon = 0 Then Return frm_mdiClient.Icon
    myIcon = System.Drawing.Icon.FromHandle(shinfo.hIcon)

    Return myIcon
  End Function
  Function GetAssociatedIconAsImage(ByVal fileSpec As String, _
                             Optional ByVal iconSize As assoc_iconSize = assoc_iconSize.SHGFI_LARGEICON _
                             ) As Image

    Dim hImg As IntPtr  'The handle to the system image list.
    Dim shinfo As SHFILEINFO
    shinfo = New SHFILEINFO()

    hImg = SHGetFileInfo(fileSpec, 0, shinfo, _
                    Marshal.SizeOf(shinfo), _
                    SHGFI_ICON Or iconSize)

    'The icon is returned in the hIcon member of the
    'shinfo struct.
    Dim myIcon As System.Drawing.Icon
    If shinfo.hIcon = 0 Then Return frm_mdiClient.Icon.ToBitmap
    myIcon = System.Drawing.Icon.FromHandle(shinfo.hIcon)

    Return myIcon.ToBitmap
  End Function

End Module
