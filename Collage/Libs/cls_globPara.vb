Imports System.IO

Public Class cls_globPara

  ': ========== Globale Variablen ==========================================

  Dim m_paraFileSpec As String
  Dim m_content As New Dictionary(Of String, String)
  Const tabDelimiter As String = vbTab

  Public configDir As String

  Public configDirName As String = My.Application.Info.AssemblyName
  Public configFileName As String = My.Application.Info.AssemblyName

  ': ========== Konstruktor + Destruktor ==================================

  Public Sub New(confDirName As String, confFileName As String)
    configDirName = confDirName : configFileName = confFileName
    InitFilespec("")
    readFile()
  End Sub

  Public Sub New(Optional ByVal fileSpec As String = "")
    InitFilespec(fileSpec)
    readFile()
  End Sub
  Private Sub InitFilespec(filespec As String)
    m_paraFileSpec = filespec
    If m_paraFileSpec = "" Then
      m_paraFileSpec = Path.Combine(My.Application.Info.DirectoryPath, configFileName + ".ini")
      If Not File.Exists(m_paraFileSpec) Then
        m_paraFileSpec = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                      configDirName + "\" + configFileName + ".ini")
      End If
    End If
    configDir = My.Computer.FileSystem.GetParentPath(m_paraFileSpec)
    System.IO.Directory.CreateDirectory(configDir)

    Debug.Print("paraFilespec: " + m_paraFileSpec)
  End Sub
  Protected Overrides Sub Finalize()
    saveParaFile()
    MyBase.Finalize()
  End Sub



  ': ========== Haupteigenschaft ========================

  Public Property para(ByVal key As String, Optional ByVal def As String = "") As String
    Get
      If m_content.ContainsKey(key) Then
        para = m_content.Item(key)
      Else
        para = def
      End If
    End Get
    Set(ByVal value As String)
      If m_content.ContainsKey(key) Then
        m_content.Item(key) = value
      Else
        m_content.Add(key, value)
      End If
    End Set
  End Property

  ': ========== Hilfsfunktionen ========================

  Public Sub DeletePara(key As String)
    m_content.Remove(key)
  End Sub
  Public Sub DeleteParaGroup(prefix As String)
    Dim toRemove As New List(Of String)
    For Each key In m_content.Keys
      If key.StartsWith(prefix) Then
        toRemove.Add(key)
      End If
    Next
    For Each key In toRemove
      m_content.Remove(key)
    Next
  End Sub

  Public Function Contains(ByVal key As String) As Boolean
    Contains = m_content.ContainsKey(key)

  End Function

  Public ReadOnly Property Keys As Dictionary(Of String, String).KeyCollection
    Get
      Return m_content.Keys
    End Get
  End Property


  Public Function appPath() As String
    appPath = Path.GetDirectoryName(Application.ExecutablePath)
    If Not appPath.EndsWith("\") Then appPath += "\"
    Return appPath
  End Function


  Enum FormPosFlags
    Pos = 1
    Size = 2
    Both = 3
  End Enum

  ': ========== Form-Tools ========================

  Public Sub readFormPos(ByVal frm As Form, Optional ByVal Flags As FormPosFlags = FormPosFlags.Both)
    Try
      Dim paraName As String = frm.Name.ToLower + "__" + "Rect"
      Dim formPos() As String = Split(Me.para(paraName), ";")
      If (Flags And FormPosFlags.Pos) > 0 Then
        frm.Left = CInt(formPos(0))
        frm.Top = CInt(formPos(1))
      End If
      If (Flags And FormPosFlags.Size) > 0 Then
        frm.Width = CInt(formPos(2))
        frm.Height = CInt(formPos(3))
      End If

    Catch ex As Exception

    End Try
  End Sub

  Public Sub saveFormPos(ByVal frm As Form, Optional ByVal Flags As FormPosFlags = FormPosFlags.Both)
    Dim formPos As String

    With frm
      If .WindowState = FormWindowState.Minimized Then .WindowState = FormWindowState.Normal
      formPos = .Left.ToString + ";" + .Top.ToString _
              + ";" + .Width.ToString + ";" + .Height.ToString
      Dim paraName As String = frm.Name.ToLower + "__" + "Rect"
      Me.para(paraName) = formPos
    End With
  End Sub

  Public Sub readTuttiFrutti(ByVal frm As Form)
    recursive_readTuttiFrutti(frm, frm)
  End Sub

  Public Sub saveTuttiFrutti(ByVal frm As Form)
    recursive_saveTuttiFrutti(frm, frm)
  End Sub

  Public Sub recursive_readTuttiFrutti(ByVal frm As Form, ByVal ctrl As Control)
    Dim typ As String
    Dim prefix As String = frm.Name + "__"
    For Each subctrl As Object In ctrl.Controls
      If subctrl.Controls.Count > 0 Then recursive_readTuttiFrutti(frm, subctrl)
      If Not Contains(prefix + subctrl.Name) Then Continue For

      typ = subctrl.GetType().ToString

      If typ = "System.Windows.Forms.TextBox" Then
        subctrl.Text = Me.para(prefix + subctrl.Name)
      End If
      If typ = "System.Windows.Forms.ComboBox" Then
        subctrl.Text = Me.para(prefix + subctrl.Name)
      End If
      If typ = "System.Windows.Forms.CheckBox" Then
        subctrl.Checked = (Me.para(prefix + subctrl.Name) = "TRUE")
      End If
      If typ = "System.Windows.Forms.NumericUpDown" Then
        subctrl.Value = Val(Me.para(prefix + subctrl.Name))
      End If
      If typ = "System.Windows.Forms.RadioButton" Then
        Dim paras() As String = Split(subctrl.Name, "__")
        If Me.para(prefix + paras(0)) = paras(1) Then
          subctrl.Checked = True
        Else
          subctrl.checked = False
        End If
      End If
    Next
  End Sub
  Public Sub recursive_saveTuttiFrutti(ByVal frm As Form, ByVal ctrl As Control)
    Dim typ As String
    'Stop
    Dim prefix As String = frm.Name + "__"
    For Each subctrl As Control In ctrl.Controls
      typ = subctrl.GetType().ToString

      If typ = "System.Windows.Forms.TextBox" Then
        Me.para(prefix + subctrl.Name) = CType(subctrl, TextBox).Text
      End If
      If typ = "System.Windows.Forms.ComboBox" Then
        Me.para(prefix + subctrl.Name) = CType(subctrl, ComboBox).Text
      End If
      If typ = "System.Windows.Forms.CheckBox" Then
        Me.para(prefix + subctrl.Name) = IIf(CType(subctrl, CheckBox).Checked, "TRUE", "FALSE")
      End If
      If typ = "System.Windows.Forms.NumericUpDown" Then
        Me.para(prefix + subctrl.Name) = CType(subctrl, NumericUpDown).Value
      End If
      If typ = "System.Windows.Forms.RadioButton" Then
        Dim radioBox As RadioButton = subctrl
        If radioBox.Checked AndAlso radioBox.Name.Contains("__") Then
          Dim paras() As String = Split(subctrl.Name, "__")
          Me.para(prefix + paras(0)) = paras(1)
        End If
      End If

      If subctrl.Controls.Count > 0 Then recursive_saveTuttiFrutti(frm, subctrl)
    Next
  End Sub


  ': ========== Private Funktionen ====================

  Private Sub readFile()
    On Error Resume Next
    Err.Clear()

    If Not My.Computer.FileSystem.FileExists(m_paraFileSpec) Then Exit Sub

    Dim cont() As String =
       Split(My.Computer.FileSystem.ReadAllText(m_paraFileSpec), vbNewLine)

    Dim line(), lineString As String
    Dim k, v As String
    For Each lineString In cont
      line = Split(lineString, tabDelimiter)
      If line.Length < 2 Then Continue For
      k = System.Uri.UnescapeDataString(line(0))
      v = System.Uri.UnescapeDataString(line(1))

      m_content.Add(k, v)
      Debug.Print(lineString)
      'Stop
    Next

    If Err.Number <> 0 Then MsgBox("beim Laden der Einstellungen ist ein Fehler aufgetreten:" + vbNewLine + Err.Description + vbNewLine + "(cls_globPara)")


  End Sub

  Sub saveParaFile()
    Dim cont As String = ""
    Dim key, item As String

    For Each key In m_content.Keys
      item = m_content.Item(key)
      item = System.Uri.EscapeDataString(item)
      cont += System.Uri.EscapeDataString(key) + tabDelimiter + item + vbNewLine
    Next
    'MsgBox(cont)
    My.Computer.FileSystem.WriteAllText(m_paraFileSpec, cont, False)
  End Sub




End Class
