Namespace vbAccelerator.Components.HotKey

    Public Class HotKeyForm
        Inherits System.Windows.Forms.Form

        Private m_hotKeys As HotKeyCollection

        Public Event HotKeyPressed As HotKeyPressedEventHandler
        Public Event PrintWindowPressed As PrintWindowPressedEventHandler
        Public Event PrintDesktopPressed As PrintDesktopPressedEventHandler

        Public ReadOnly Property HotKeys() As HotKeyCollection
            Get
                HotKeys = m_hotKeys
            End Get
        End Property

        Public Sub RestoreAndActivate()
            If Not (UnmanagedMethods.IsWindowVisible(Me.Handle)) Then
                UnmanagedMethods.ShowWindow(Me.Handle, UnmanagedMethods.SW_SHOW)
            End If
            If (UnmanagedMethods.IsIconic(Me.Handle)) Then
                UnmanagedMethods.SendMessage(Me.Handle, UnmanagedMethods.WM_SYSCOMMAND, _
                    UnmanagedMethods.SC_RESTORE, IntPtr.Zero)
            End If
            UnmanagedMethods.SetForegroundWindow(Me.Handle)
        End Sub

        Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
            MyBase.WndProc(m)
            If (m.Msg = UnmanagedMethods.WM_HOTKEY) Then
                Dim hotKeyId As Integer = m.WParam.ToInt32()
                Select Case hotKeyId
                    Case UnmanagedMethods.IDHOT_SNAPDESKTOP
                        Dim e As System.EventArgs = New System.EventArgs()
                        RaiseEvent PrintDesktopPressed(Me, e)

                    Case UnmanagedMethods.IDHOT_SNAPWINDOW
                        Dim e As System.EventArgs = New System.EventArgs()
                        RaiseEvent PrintWindowPressed(Me, e)

                    Case Else
                        Dim htk As HotKey
                        For Each htk In m_hotKeys
                            If (htk.AtomId.Equals(m.WParam)) Then
                                Dim e As HotKeyPressedEventArgs = New HotKeyPressedEventArgs(htk)
                                RaiseEvent HotKeyPressed(Me, e)
                            End If
                        Next
                End Select

            End If
        End Sub

        Protected Overrides Sub OnClosed(ByVal e As System.EventArgs)
            hotKeys.Clear()
            MyBase.OnClosed(e)
        End Sub

        Public Sub New()
            MyBase.New()
            m_hotKeys = New HotKeyCollection(Me)
        End Sub

    Private Sub InitializeComponent()
      Me.SuspendLayout()
      '
      'HotKeyForm
      '
      Me.ClientSize = New System.Drawing.Size(292, 266)
      Me.Name = "HotKeyForm"
      Me.ResumeLayout(False)

    End Sub
  End Class

    Public Delegate Sub HotKeyPressedEventHandler(ByVal sender As Object, ByVal e As HotKeyPressedEventArgs)
    Public Delegate Sub PrintWindowPressedEventHandler(ByVal sender As Object, ByVal e As EventArgs)
    Public Delegate Sub PrintDesktopPressedEventHandler(ByVal sender As Object, ByVal e As EventArgs)

    Public Class HotKeyPressedEventArgs
        Inherits EventArgs
        Private m_hotKey As HotKey

        Public ReadOnly Property HotKey()
            Get
                HotKey = m_hotKey
            End Get
        End Property

        Friend Sub New(ByVal hotKey As HotKey)
            m_hotKey = hotKey
        End Sub

    End Class

    Public Class HotKeyCollection
        Inherits System.Collections.CollectionBase

        Private ownerForm As System.Windows.Forms.Form

        Protected Overrides Sub OnClear()
            Dim htk As HotKey
            For Each htk In Me.InnerList
                RemoveHotKey(htk)
            Next
            MyBase.OnClear()
        End Sub

        Protected Overrides Sub OnInsert(ByVal index As Integer, ByVal item As Object)
            ' validate item is a hot key:
            Dim htk As HotKey = New HotKey()
            If (item.GetType().IsInstanceOfType(htk)) Then
                ' check if the name, keycode and modifiers have been set up:
                htk = item
                ' throws ArgumentException if there is a problem:
                htk.Validate()
                ' throws Unable to add HotKeyException:
                AddHotKey(htk)
                ' ok
                MyBase.OnInsert(index, item)
            Else
                Throw New InvalidCastException("Invalid object.")
            End If

        End Sub


        Protected Overrides Sub OnRemove(ByVal index As Integer, ByVal item As Object)
            ' get the item to be removed:
            Dim htk As HotKey = item
            RemoveHotKey(htk)
            MyBase.OnRemove(index, item)
        End Sub

        Protected Overrides Sub OnSet(ByVal index As Integer, ByVal oldItem As Object, ByVal newItem As Object)
            ' remove old hot key:
            Dim htk As HotKey = oldItem
            RemoveHotKey(htk)

            ' add new hotkey:
            htk = newItem
            AddHotKey(htk)

            MyBase.OnSet(index, oldItem, newItem)
        End Sub

        Protected Overrides Sub OnValidate(ByVal item As Object)
            Dim htk As HotKey = item
            htk.Validate()
        End Sub

    Public Sub Add(ByVal hotKey As HotKey)
      ' throws argument exception:
      hotKey.Validate()
      ' throws unable to add hot key exception:
      AddHotKey(hotKey)
      ' assuming all is well:
      Me.InnerList.Add(hotKey)
    End Sub

    Public Sub Add(ByVal name As String, ByVal keyCode As Keys, _
            ByVal modifiers As Components.HotKey.HotKey.HotKeyModifiers)
      Dim hotKey As New HotKey(name, keyCode, modifiers)
      ' throws argument exception:
      hotKey.Validate()
      ' throws unable to add hot key exception:
      AddHotKey(hotKey)
      ' assuming all is well:
      Me.InnerList.Add(hotKey)
    End Sub

        Default Public ReadOnly Property Item(ByVal index As Integer) As Integer
            Get
                Item = Me.InnerList.Item(index)
            End Get
        End Property

        Private Sub RemoveHotKey(ByVal hotKey As HotKey)
            '// remove the hot key:
            UnmanagedMethods.UnregisterHotKey(ownerForm.Handle, hotKey.AtomId.ToInt32())
            '// unregister the atom:
            UnmanagedMethods.GlobalDeleteAtom(hotKey.AtomId)
        End Sub


        Private Sub AddHotKey(ByVal hotKey As HotKey)
            ' generate the id:
            Dim atomName As String = hotKey.Name + "_" + UnmanagedMethods.GetTickCount().ToString()
            If (atomName.Length > 255) Then
                atomName = atomName.Substring(0, 255)
            End If
            ' Create a new atom:
            Dim id As IntPtr = UnmanagedMethods.GlobalAddAtom(atomName)
            If (id.Equals(IntPtr.Zero)) Then
                ' failed
                Throw New HotKeyAddException("Failed to add GlobalAtom for HotKey")
            Else
                ' succeeded:
                Dim ret As Boolean = UnmanagedMethods.RegisterHotKey( _
                  ownerForm.Handle, _
                  id.ToInt32(), _
                  hotKey.Modifiers, _
                  hotKey.KeyCode)
                If Not (ret) Then
                    ' Remove the atom:
                    UnmanagedMethods.GlobalDeleteAtom(id)
                    ' failed
                    Throw New HotKeyAddException("Failed to register HotKey")
                Else
                    hotKey.AtomName = atomName
                    hotKey.AtomId = id
                End If
            End If
        End Sub


        Public Sub New(ByVal ownerForm As System.Windows.Forms.Form)
            Me.ownerForm = ownerForm
        End Sub

    End Class

    Public Class HotKeyAddException
        Inherits System.Exception

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub

        Public Sub New(ByVal message As String, ByVal innerException As System.Exception)
            MyBase.New(message, innerException)
        End Sub
    End Class

    Public Class HotKey
        '[Flags]
        Public Enum HotKeyModifiers As Integer
            MOD_ALT = &H1
            MOD_CONTROL = &H2
            MOD_SHIFT = &H4
            MOD_WIN = &H8
        End Enum
        Private m_name As String
        Private m_atomName As String
        Private m_atomId As IntPtr
        Private m_keyCode As Keys
        Private m_modifiers As HotKeyModifiers

        Friend Property AtomId() As IntPtr
            Get
                AtomId = m_atomId
            End Get
            Set(ByVal Value As IntPtr)
                m_atomId = Value
            End Set
        End Property

        Friend Property AtomName() As String
            Get
                AtomName = m_atomName
            End Get
            Set(ByVal Value As String)
                m_atomName = Value
            End Set
        End Property

        Public Property Name() As String
            Get
                Name = m_name
            End Get
            Set(ByVal Value As String)
                m_name = Value
            End Set
        End Property

        Public Property KeyCode() As Keys
            Get
                KeyCode = m_keyCode
            End Get
            Set(ByVal Value As Keys)
                m_keyCode = Value
            End Set
        End Property

        Public Property Modifiers() As HotKeyModifiers
            Get
                Modifiers = m_modifiers
            End Get
            Set(ByVal Value As HotKeyModifiers)
                m_modifiers = Value
            End Set
        End Property

        Public Sub Validate()
            Dim msg As String = ""
            'If (Name Is Null) Then
            'msg = "Name parameter cannot be null"
            'End If
            If (m_name.Trim().Length = 0) Then
                msg = "Name parameter cannot be zero length"
            End If
            If ((KeyCode = Keys.Alt) Or _
             (KeyCode = Keys.Control) Or _
             (KeyCode = Keys.Shift) Or _
             (KeyCode = Keys.ShiftKey) Or _
             (KeyCode = Keys.ControlKey)) Then
                msg = "KeyCode cannot be set to a modifier key"
            End If
            If (msg.Length > 0) Then
                Throw New ArgumentException(msg)
            End If
        End Sub

        Public Sub New()

        End Sub

        Public Sub New( _
            ByVal name As String, _
            ByVal keyCode As Keys, _
            ByVal modifiers As HotKeyModifiers _
            )
            m_name = name
            m_keyCode = keyCode
            m_modifiers = modifiers
        End Sub

    End Class

    Friend Class UnmanagedMethods

        Friend Const IDHOT_SNAPWINDOW As Integer = -1 '/* SHIFT-PRINTSCRN  */
        Friend Const IDHOT_SNAPDESKTOP As Integer = -2         '/* PRINTSCRN        */
        Friend Const WM_HOTKEY As Integer = &H312

        Public Declare Auto Function RegisterHotKey Lib "user32" _
            (ByVal hWnd As IntPtr, _
            ByVal id As Integer, _
            ByVal fsModifiers As Integer, _
            ByVal vk As Integer _
            ) As Boolean
        Public Declare Auto Function UnregisterHotKey Lib "user32" _
            (ByVal hWnd As IntPtr, _
            ByVal id As Integer _
            ) As Boolean
        Public Declare Auto Function GlobalAddAtom Lib "kernel32" _
            (ByVal lpString As String _
            ) As IntPtr
        Public Declare Auto Function GlobalDeleteAtom Lib "kernel32" _
            (ByVal nAtom As IntPtr _
            ) As IntPtr
        Public Declare Auto Function GetTickCount Lib "kernel32" () As Integer
        Public Declare Auto Function SendMessage Lib "user32" _
            (ByVal hWnd As IntPtr, _
            ByVal wMsg As Integer, _
            ByVal wParam As Integer, _
            ByVal lParam As IntPtr _
            ) As Integer
        Friend Const WM_SYSCOMMAND As Integer = &H112
        Friend Const SC_RESTORE As Integer = &HF120

        Public Declare Auto Function IsIconic Lib "user32" _
            (ByVal hWnd As IntPtr) As Boolean
        Public Declare Auto Function IsWindowVisible Lib "user32" _
            (ByVal hWnd As IntPtr) As Boolean
        Public Declare Auto Function SetForegroundWindow Lib "user32" _
            (ByVal hWnd As IntPtr) As Boolean
        Public Declare Auto Function ShowWindow Lib "user32" _
            (ByVal hWnd As IntPtr, ByVal nCmdShow As Integer) As Integer
        Friend Const SW_SHOW As Integer = 5

    End Class


End Namespace