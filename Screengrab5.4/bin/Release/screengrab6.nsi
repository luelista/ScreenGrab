;NSIS Modern User Interface
;Basic Example Script
;Written by Joost Verburg
;
;
;
;--------------------------------
;Include Modern UI

  !include "MUI2.nsh"

;--------------------------------
;General


!define MY_PROG_STATE "release"
!define MY_PROG_VER "6.8"


!if ${MY_PROG_STATE} == "release"
!define MY_PROG_NAME "ScreenGrab ${MY_PROG_VER}"
!else
!define MY_PROG_NAME "ScreenGrab ${MY_PROG_VER} ${MY_PROG_STATE}"
!endif

; required NET Framework version
!define DOT_MAJOR "2"
!define DOT_MINOR "0"

  BrandingText "NSIS v2.45 Portable"

  ;Name and file
  Name "${MY_PROG_NAME}"
  OutFile "setups\ScreenGrab${MY_PROG_VER}_${MY_PROG_STATE}.exe"

  ;Default installation folder
  InstallDir "$PROGRAMFILES32\ScreenGrab6\"
  
  ;Get installation folder from registry if available
  InstallDirRegKey HKCU "Software\Wikilab\ScreenGrab" ""
  
  
  ;Request application privileges for Windows Vista
  RequestExecutionLevel admin

!define MUI_FINISHPAGE_RUN "$PROGRAMFILES32\ScreenGrab6\ScreenGrab6.exe"

;--------------------------------
;Interface Settings

  ;!define MUI_ABORTWARNING

; MUI Settings / Icons

        !define MUI_ICON "${NSISDIR}\Contrib\Graphics\Icons\orange-install.ico"
	!define MUI_UNICON "${NSISDIR}\Contrib\Graphics\Icons\orange-uninstall.ico"
 
; MUI Settings / Header
	!define MUI_HEADERIMAGE
	!define MUI_HEADERIMAGE_LEFT
	!define MUI_HEADERIMAGE_BITMAP "${NSISDIR}\Contrib\Graphics\Header\orange.bmp"
	!define MUI_HEADERIMAGE_UNBITMAP "${NSISDIR}\Contrib\Graphics\Header\orange-uninstall.bmp"
 
; MUI Settings / Wizard		
	!define MUI_WELCOMEFINISHPAGE_BITMAP "${NSISDIR}\Contrib\Graphics\Wizard\orange.bmp"
	!define MUI_UNWELCOMEFINISHPAGE_BITMAP "${NSISDIR}\Contrib\Graphics\Wizard\orange-uninstall.bmp"  


;--------------------------------
;Pages

  !define MUI_WELCOMEPAGE_TEXT       "$(PFI_LANG_WELCOME_INFO_TEXT)"
  !insertmacro MUI_PAGE_WELCOME
  ;!insertmacro MUI_PAGE_COMPONENTS
  ;!insertmacro MUI_PAGE_DIRECTORY
  !insertmacro MUI_PAGE_INSTFILES
  !define MUI_FINISHPAGE_TEXT "$(MUI_TEXT_FINISH_INFO_TEXT)$\r$\n$\r$\nEs wurden Verknüpfungen auf dem Desktop und im Startmenü unter (Alle) Programme erstellt. Doppelklicke auf 'ScreenGrab 6' auf dem Desktop, um das Programm zu starten."
  !insertmacro MUI_PAGE_FINISH
  
  !insertmacro MUI_UNPAGE_CONFIRM
  !insertmacro MUI_UNPAGE_INSTFILES
  
  ;  !define MUI_FINISHPAGE_LINK "Datenordner öffnen"
  ;  !define MUI_FINISHPAGE_LINK_LOCATION "C:\StunData\data"
  ;  !define MUI_FINISHPAGE_TEXT "$(MUI_UNTEXT_FINISH_INFO_TEXT)$\r$\n$\r$\n$\r$\n$\r$\n$\r$\nAchtung: Der Datenordner wurde NICHT automatisch gelöscht. Klicken Sie auf den Link unten, um ihn anzuzeigen."
  ;!insertmacro MUI_UNPAGE_FINISH
  
;--------------------------------
;Languages
 
  !insertmacro MUI_LANGUAGE "German"
  ;!insertmacro MUI_LANGUAGE "English"

;--------------------------------
;Installer Sections


Function .onInit

  Call IsDotNetInstalled

FunctionEnd

Section "MWupd 3" SecMain
SectionIn RO

  SetOutPath "$INSTDIR"
  
  CreateDirectory "$INSTDIR"
  File ScreenGrab6.exe
  File ScreenGrab6.exe.manifest
  File VUMLCodeGeneration.exe
  File ConvolutionFilters.txt
  File *.dll
  File *.vbs
  
  createShortCut "$SMPROGRAMS\ScreenGrab.lnk" "$INSTDIR\ScreenGrab6.exe"
  createShortCut "$DESKTOP\ScreenGrab.lnk" "$INSTDIR\ScreenGrab6.exe"
  
!if ${MY_PROG_STATE} != "release"
  createShortCut "$DESKTOP\ScreenGrab deinstallieren.lnk" "$INSTDIR\ScreenGrabUninstall.exe"
!endif

  ;Store installation folder
  WriteRegStr HKCU "Software\Wikilab\ScreenGrab" "" $INSTDIR
  WriteRegStr HKCU "Software\Wikilab\ScreenGrab" "ProgramTitle" "${MY_PROG_NAME}"
  WriteRegStr HKCU "Software\Wikilab\ScreenGrab" "Version" "${MY_PROG_VER}"
  
  ; write uninstall strings
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\ScreenGrab6" "DisplayName" "${MY_PROG_NAME}"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\ScreenGrab6" "UninstallString" '"$PROGRAMFILES32\ScreenGrab6\ScreenGrabUninstall.exe"'

  ;Create uninstaller
  WriteUninstaller "$PROGRAMFILES32\ScreenGrab6\ScreenGrabUninstall.exe"

  ;Exec "$PROGRAMFILES32\ScreenGrab6\ScreenGrab6.exe"
  ;Quit
SectionEnd


;--------------------------------
;Uninstaller Section

Section "Uninstall"

  ;ADD YOUR OWN FILES HERE...
  Delete "$INSTDIR\*.exe"
  Delete "$INSTDIR\*.dll"
  Delete "$INSTDIR\*.vbs"
  Delete "$INSTDIR\*.manifest"
  Delete "$INSTDIR\ConvolutionFilters.txt"
  ;Delete "$INSTDIR\MWupd3.exe"
  ;Delete "$INSTDIR\MWupd3Uninstall.exe"
  
  Delete "$SMPROGRAMS\ScreenGrab.lnk"
  Delete "$DESKTOP\ScreenGrab.lnk"
  Delete "$DESKTOP\ScreenGrab deinstallieren.lnk"
  
  RMDir "$INSTDIR"

  DeleteRegKey /ifempty HKCU "Software\Wikilab\ScreenGrab"
  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\ScreenGrab6"

SectionEnd





  LangString PFI_LANG_WELCOME_INFO_TEXT ${LANG_GERMAN} "Dieses Programm ist Freeware. Die aktuellste Version findest du immer unter folgender Adresse: $\r$\n $\r$\n\
www.max-weller.de/screengrab-6$\r$\n$\r$\n$\r$\n $\r$\n$\r$\n$\r$\n $\r$\n$\r$\n$\r$\n $\r$\n\
Klicken Sie auf $\"Weiter$\", um ${MY_PROG_NAME} zu installieren und zu starten. Es wird eine Verknüpfung auf dem Desktop erstellt.\
"

; Usage
; Define in your script two constants:
;   DOT_MAJOR "(Major framework version)"
;   DOT_MINOR "{Minor framework version)"
; 
; Call IsDotNetInstalled
; This function will abort the installation if the required version 
; or higher version of the .NET Framework is not installed.  Place it in
; either your .onInit function or your first install section before 
; other code.
Function IsDotNetInstalled

  StrCpy $0 "0"
  StrCpy $1 "SOFTWARE\Microsoft\.NETFramework" ;registry entry to look in.
  StrCpy $2 0
 
  StartEnum:
    ;Enumerate the versions installed.
    EnumRegKey $3 HKLM "$1\policy" $2
 
    ;If we don't find any versions installed, it's not here.
    StrCmp $3 "" noDotNet notEmpty
 
    ;We found something.
    notEmpty:
      ;Find out if the RegKey starts with 'v'.  
      ;If it doesn't, goto the next key.
      StrCpy $4 $3 1 0
      StrCmp $4 "v" +1 goNext
      StrCpy $4 $3 1 1
 
      ;It starts with 'v'.  Now check to see how the installed major version
      ;relates to our required major version.
      ;If it's equal check the minor version, if it's greater, 
      ;we found a good RegKey.
      IntCmp $4 ${DOT_MAJOR} +1 goNext yesDotNetReg
      ;Check the minor version.  If it's equal or greater to our requested 
      ;version then we're good.
      StrCpy $4 $3 1 3
      IntCmp $4 ${DOT_MINOR} yesDotNetReg goNext yesDotNetReg
 
    goNext:
      ;Go to the next RegKey.
      IntOp $2 $2 + 1
      goto StartEnum
 
  yesDotNetReg:
    ;Now that we've found a good RegKey, let's make sure it's actually
    ;installed by getting the install path and checking to see if the 
    ;mscorlib.dll exists.
    EnumRegValue $2 HKLM "$1\policy\$3" 0
    ;$2 should equal whatever comes after the major and minor versions 
    ;(ie, v1.1.4322)
    StrCmp $2 "" noDotNet
    ReadRegStr $4 HKLM $1 "InstallRoot"
    ;Hopefully the install root isn't empty.
    StrCmp $4 "" noDotNet
    ;build the actuall directory path to mscorlib.dll.
    StrCpy $4 "$4$3.$2\mscorlib.dll"
    IfFileExists $4 yesDotNet noDotNet
 
  noDotNet:
    ;Nope, something went wrong along the way.  Looks like the 
    ;proper .NET Framework isn't installed.  
    MessageBox MB_YESNO|MB_ICONQUESTION "Das Microsoft .NET Framework muss mindestens in der Version ${DOT_MAJOR}.${DOT_MINOR} installiert sein, um ${MY_PROG_NAME} verwenden zu können. Soll jetzt die Download-Seite geöffnet werden?$\r$\n$\r$\nhttp://go.microsoft.com/fwlink/?linkid=32168" \
    IDYES +2 IDNO +1
    Abort
    ExecShell "open" "http://go.microsoft.com/fwlink/?linkid=32168"
			
    ;MessageBox MB_OK "You must have v${DOT_MAJOR}.${DOT_MINOR} or greater of the .NET Framework installed.  Aborting!"
    Abort
 
  yesDotNet:
    ;Everything checks out.  Go on with the rest of the installation.
 
FunctionEnd

