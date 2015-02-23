!include MUI2.nsh
!addplugindir .\setups

!getdllversion "bin\Release\ScreenGrab6.exe" progv_
  !define PROG_NAME "ScreenGrab"
  !define VERSION "${progv_1}.${progv_2}"

!define /date DATE "%Y-%m-%d %H:%M:%S"
!define /date VERDATE "%Y.%m%d.%H%M.%S"

Function LicensePageShow

FindWindow $R1 `#32770` `` $HWNDPARENT
GetDlgItem $R0 $R1 1000
System::Call 'USER32::SetWindowPos(i,i,i,i,i,i,i) b ($R0,0,0,0,410,225,0)'

GetDlgItem $R0 $R1 1006
ShowWindow $R0 ${SW_HIDE}
GetDlgItem $R0 $R1 1040
ShowWindow $R0 ${SW_HIDE}

FunctionEnd

Name "ScreenGrab"
OutFile "setups\ScreenGrab${VERSION}_release.exe"

  VIProductVersion "${VERSION}.0.0" 
  VIFileVersion "${VERSION}.0.0" 
  VIAddVersionKey "ProductVersion" "${VERSION}.0.0"
  VIAddVersionKey "FileVersion" "${VERSION}.0.0"
  VIAddVersionKey "ProductName" "${PROG_NAME}"
  VIAddVersionKey "FileDescription" "Setup für ${PROG_NAME}"
  VIAddVersionKey "LegalCopyright" "Copyright (c) 2010-2015 Max Weller"
  VIAddVersionKey "Comments" "${DATE}"
  VIAddVersionKey "OriginalFilename" "ScreenGrab${VERSION}_release.exe"
  VIAddVersionKey "LegalTrademarks" "Build time: ${DATE}"

InstallDir "$PROGRAMFILES\ScreenGrab6"
InstallDirRegKey HKCU "Software\Wikilab\ScreenGrab" ""
RequestExecutionLevel admin

ShowInstDetails show

!insertmacro MUI_PAGE_WELCOME
  ;!define MUI_PAGE_HEADER_TEXT "Welcome to the ScreenGrab ${VERSION} installer"
  ;!define MUI_PAGE_HEADER_SUBTEXT "Please take note of the below readme file and license information"
  !define MUI_LICENSEPAGE_TEXT_TOP ""
  !define MUI_LICENSEPAGE_TEXT_BOTTOM "-	"
  !define MUI_LICENSEPAGE_BUTTON "Next"
  !define MUI_PAGE_CUSTOMFUNCTION_SHOW LicensePageShow
!insertmacro MUI_PAGE_LICENSE "Setups\InstallerReadme.txt"

!insertmacro MUI_PAGE_COMPONENTS
!insertmacro MUI_PAGE_INSTFILES

  !insertmacro MUI_UNPAGE_CONFIRM
  !insertmacro MUI_UNPAGE_INSTFILES
  
  !insertmacro MUI_LANGUAGE "English"


Section "Program Files" SecProgFiles 
  SectionIn RO

  SetOutPath "$INSTDIR"
  ExecWait "taskkill.exe /im ScreenGrab6.exe /f"
  Sleep 500

  File "bin\Release\*.manifest"
  File "bin\Release\*.exe"
  File "bin\Release\*.dll"
  File "Collage\ConvolutionFilters.txt"
  File "VUMLCodeGeneration\scripts\*.vbs"
  

  CreateShortcut "$DESKTOP\ScreenGrab.lnk" "$INSTDIR\ScreenGrab6.exe"
  CreateShortcut "$SMPROGRAMS\ScreenGrab.lnk" "$INSTDIR\ScreenGrab6.exe"
  WriteUninstaller "$INSTDIR\ScreenGrabUninstall.exe"
  
SectionEnd

Section "Uninstall"
  
  Delete "$INSTDIR\*.exe"
  Delete "$INSTDIR\*.dll"
  Delete "$INSTDIR\*.txt"
  RMDir "$INSTDIR"
  Delete "$DESKTOP\ScreenGrab.lnk"
  Delete "$SMPROGRAMS\ScreenGrab.lnk"
  

SectionEnd




