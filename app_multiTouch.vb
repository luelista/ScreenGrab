Imports System.Runtime.InteropServices



Public Class TouchHelper
  Inherits NativeWindow

    Dim myForm As Control

  Public Event Touchdown As EventHandler(Of WMTouchEventArgs)
  Public Event Touchmove As EventHandler(Of WMTouchEventArgs)
  Public Event Touchup As EventHandler(Of WMTouchEventArgs)


  Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
    Dim handled As Boolean = False
        Debug.Print(m.Msg)

    Select Case m.Msg
      Case WM_TOUCHDOWN, WM_TOUCHMOVE, WM_TOUCHUP
        handled = DecodeTouch(m)

      Case Else
        handled = False

    End Select

    MyBase.WndProc(m)

    If handled Then
      m.Result = 1


    End If
  End Sub

  Private Sub New(ByVal frm As Control)
    Me.AssignHandle(frm.Handle)
    'Me.AssignHandle(frm_mdiViewer2.PictureBox1.Handle)

    myForm = frm
  End Sub


  Public Shared Function RegisterForTouch(ByVal frm As Control)
    Try
      Dim ulFlags As ULong = 0
      Dim iResult = RegisterTouchWindow(frm.Handle, ulFlags)
      'MsgBox("Register Multitouch??? " & iResult)
      If iResult = True Then
        Return New TouchHelper(frm)
      End If

    Catch ex As Exception
      ' MsgBox("Register Touch Window failed: " + ex.Message)
    End Try
  End Function


  ' EventArgs passed to Touch handlers

  Class WMTouchEventArgs
    Inherits System.EventArgs
    ' Private data members
    Private x As Integer
    ' touch x client coordinate in pixels
    Private y As Integer
    ' touch y client coordinate in pixels
    Private m_id As Integer
    ' contact ID
    Private m_mask As Integer
    ' mask which fields in the structure are valid
    Private m_flags As Integer
    ' flags
    Private m_time As Integer
    ' touch event time
    Private m_contactX As Integer
    ' x size of the contact area in pixels
    Private m_contactY As Integer
    ' y size of the contact area in pixels
    ' Access to data members
    Public Property LocationX() As Integer
      Get
        Return x
      End Get
      Set(ByVal value As Integer)
        x = value
      End Set
    End Property
    Public Property LocationY() As Integer
      Get
        Return y
      End Get
      Set(ByVal value As Integer)
        y = value
      End Set
    End Property
    Public Property Id() As Integer
      Get
        Return m_id
      End Get
      Set(ByVal value As Integer)
        m_id = value
      End Set
    End Property
    Public Property Flags() As Integer
      Get
        Return m_flags
      End Get
      Set(ByVal value As Integer)
        m_flags = value
      End Set
    End Property
    Public Property Mask() As Integer
      Get
        Return m_mask
      End Get
      Set(ByVal value As Integer)
        m_mask = value
      End Set
    End Property
    Public Property Time() As Integer
      Get
        Return m_time
      End Get
      Set(ByVal value As Integer)
        m_time = value
      End Set
    End Property
    Public Property ContactX() As Integer
      Get
        Return m_contactX
      End Get
      Set(ByVal value As Integer)
        m_contactX = value
      End Set
    End Property
    Public Property ContactY() As Integer
      Get
        Return m_contactY
      End Get
      Set(ByVal value As Integer)
        m_contactY = value
      End Set
    End Property
    Public ReadOnly Property IsPrimaryContact() As Boolean
      Get
        Return (m_flags And TOUCHEVENTF_PRIMARY) <> 0
      End Get
    End Property

    ' Constructor
    Public Sub New()
    End Sub
  End Class

  '''////////////////////////////////////////////////////////////////////
  ' Private class definitions, structures, attributes and native fn's
  'Exercise1-Task2-Step2 

  ' Touch event window message constants [winuser.h]
  Public Const WM_TOUCHMOVE As Integer = &H240
  Public Const WM_TOUCHDOWN As Integer = &H241
  Public Const WM_TOUCHUP As Integer = &H242

  ' Touch event flags ((TOUCHINPUT.dwFlags) [winuser.h]
  Public Const TOUCHEVENTF_MOVE As Integer = &H1
  Public Const TOUCHEVENTF_DOWN As Integer = &H2
  Public Const TOUCHEVENTF_UP As Integer = &H4
  Public Const TOUCHEVENTF_INRANGE As Integer = &H8
  Public Const TOUCHEVENTF_PRIMARY As Integer = &H10
  Public Const TOUCHEVENTF_NOCOALESCE As Integer = &H20
  Public Const TOUCHEVENTF_PEN As Integer = &H40

  ' Touch input mask values (TOUCHINPUT.dwMask) [winuser.h]
  Public Const TOUCHINPUTMASKF_TIMEFROMSYSTEM As Integer = &H1
  ' the dwTime field contains a system generated value
  Public Const TOUCHINPUTMASKF_EXTRAINFO As Integer = &H2
  ' the dwExtraInfo field is valid
  Public Const TOUCHINPUTMASKF_CONTACTAREA As Integer = &H4
  ' the cxContact and cyContact fields are valid
  ' Touch API defined structures [winuser.h]
  'Exercise1-Task2-Step4 
  <StructLayout(LayoutKind.Sequential)> _
  Private Structure TOUCHINPUT
    Public x As Integer
    Public y As Integer
    Public hSource As System.IntPtr
    Public dwID As Integer
    Public dwFlags As Integer
    Public dwMask As Integer
    Public dwTime As Integer
    Public dwExtraInfo As System.IntPtr
    Public cxContact As Integer
    Public cyContact As Integer
  End Structure

  <StructLayout(LayoutKind.Sequential)> _
  Private Structure POINTS
    Public x As Short
    Public y As Short
  End Structure

  ' Currently touch/multitouch access is done through unmanaged code
  ' We must p/invoke into user32 [winuser.h]
  'Exercise1-Task2-Step3 
  <DllImport("user32")> _
  Private Shared Function RegisterTouchWindow(ByVal hWnd As System.IntPtr, ByVal ulFlags As ULong) As <MarshalAs(UnmanagedType.Bool)> Boolean
  End Function

  <DllImport("user32")> _
  Private Shared Function GetTouchInputInfo(ByVal hTouchInput As System.IntPtr, ByVal cInputs As Integer, <[In](), Out()> ByVal pInputs As TOUCHINPUT(), ByVal cbSize As Integer) As <MarshalAs(UnmanagedType.Bool)> Boolean
  End Function

  <DllImport("user32")> _
  Private Shared Sub CloseTouchInputHandle(ByVal lParam As System.IntPtr)
  End Sub


  Dim touchInputSize As Integer = Marshal.SizeOf(New TOUCHINPUT)

  ' Extracts lower 16-bit word from an 32-bit int.
  ' in:
  '      number      int
  ' returns:
  '      lower word
  Private Shared Function LoWord(ByVal number As Integer) As Integer
    Return number And &HFFFF
  End Function

  ' Decodes and handles WM_TOUCH* messages.
  ' Unpacks message arguments and invokes appropriate touch events.
  ' in:
  '      m           window message
  ' returns:
  '      flag whether the message has been handled
  Private Function DecodeTouch(ByRef m As Message) As Boolean
    ' More than one touchinput may be associated with a touch message,
    ' so an array is needed to get all event information.
    Dim inputCount As Integer = LoWord(m.WParam.ToInt32())
    ' Number of touch inputs, actual per-contact messages
    Dim inputs As TOUCHINPUT()
    ' Array of TOUCHINPUT structures
    Try
      ' Allocate the storage for the parameters of the per-contact messages
      inputs = New TOUCHINPUT(inputCount - 1) {}
    Catch exception As Exception
      Debug.Print("ERROR: Could not allocate inputs array")
      Debug.Print(exception.ToString())
      Return False
    End Try

    ' Unpack message parameters into the array of TOUCHINPUT structures, each
    ' representing a message for one single contact.
    'Exercise2-Task1-Step3 
    If Not GetTouchInputInfo(m.LParam, inputCount, inputs, touchInputSize) Then
      ' Get touch info failed.
      Return False
    End If

    ' For each contact, dispatch the message to the appropriate message
    ' handler.
    ' Note that for WM_TOUCHDOWN you can get down & move notifications
    ' and for WM_TOUCHUP you can get up & move notifications
    ' WM_TOUCHMOVE will only contain move notifications
    ' and up & down notifications will never come in the same message
    Dim handled As Boolean = False
    ' // Flag, is message handled
    'Exercise2-Task1-Step4
    For i As Integer = 0 To inputCount - 1
      Dim ti As TOUCHINPUT = inputs(i)

      ' Assign a handler to this message.
      Dim handler As EventHandler(Of WMTouchEventArgs) = Nothing
      ' Touch event handler
      

      ' Convert message parameters into touch event arguments and handle the event.
      'If handler IsNot Nothing Then
      ' Convert the raw touchinput message into a touchevent.
      Dim te As WMTouchEventArgs
      ' Touch event arguments
      Try
        te = New WMTouchEventArgs()
      Catch excep As Exception
        Debug.Print("Could not allocate WMTouchEventArgs")
        Debug.Print(excep.ToString())
        Continue For
      End Try

      ' TOUCHINFO point coordinates and contact size is in 1/100 of a pixel; convert it to pixels.
      ' Also convert screen to client coordinates.
      te.ContactY = ti.cyContact / 100
      te.ContactX = ti.cxContact / 100
      te.Id = ti.dwID
      If True Then
                Dim pt As Point = myForm.PointToClient(New Point(ti.x / 100, ti.y / 100))
        te.LocationX = pt.X
        te.LocationY = pt.Y
      End If
      te.Time = ti.dwTime
      te.Mask = ti.dwMask
      te.Flags = ti.dwFlags

      ' Invoke the event handler.
      If (ti.dwFlags And TOUCHEVENTF_DOWN) <> 0 Then
        RaiseEvent Touchdown(Me, te)
      ElseIf (ti.dwFlags And TOUCHEVENTF_UP) <> 0 Then
        RaiseEvent Touchup(Me, te)
      ElseIf (ti.dwFlags And TOUCHEVENTF_MOVE) <> 0 Then
        RaiseEvent Touchmove(Me, te)
      End If

      ' Mark this event as handled.
      handled = True
      'End If
    Next

    CloseTouchInputHandle(m.LParam)

    Return handled
  End Function

End Class




