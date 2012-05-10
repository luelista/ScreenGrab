Imports System.Runtime.InteropServices

Module Module1

  <DllImport("user32.dll", SetLastError:=True)> _
  Private Function GetForegroundWindow() As IntPtr
  End Function
  <DllImport("user32.dll")> _
  Private Function GetWindowRect(ByVal hWnd As IntPtr, ByRef lpRect As RECT) As Boolean
  End Function

  <DllImport("user32.dll", SetLastError:=True)> _
  Private Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, _
                                ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, _
                                ByVal uFlags As SetWindowPosFlags) As Boolean
  End Function

  <StructLayout(LayoutKind.Sequential)> _
  Public Structure RECT
    Public Left As Integer, Top As Integer, Right As Integer, Bottom As Integer

    Public Sub New(ByVal pLeft As Integer, ByVal pTop As Integer, ByVal pRight As Integer, ByVal pBottom As Integer)
      Left = pLeft
      Top = pTop
      Right = pRight
      Bottom = pBottom
    End Sub
  End Structure

  Sub startScreenshot()
    Dim window As IntPtr = GetForegroundWindow()

    Dim rct As New RECT
    GetWindowRect(window, rct)

    Dim delta = 15
    rct.Left -= delta : rct.Right += delta
    rct.Top -= delta : rct.Bottom += delta


    Dim sg As New ScreenshotGenerator()

    Dim frm As New Form
    frm.FormBorderStyle = FormBorderStyle.None
    frm.CreateControl()
    frm.BackColor = Color.White
    SetWindowPos(frm.Handle, window, rct.Left, rct.Top, rct.Right - rct.Left, rct.Bottom - rct.Top, SetWindowPosFlags.DoNotActivate Or SetWindowPosFlags.ShowWindow)

    Application.DoEvents()
    Threading.Thread.Sleep(10)
    Application.DoEvents()

    Dim bmp1 = sg.CaptureByRect(rct.Left, rct.Top, rct.Right - rct.Left, rct.Bottom - rct.Top)
    Threading.Thread.Sleep(10)

    frm.BackColor = Color.Black

    Application.DoEvents()
    Threading.Thread.Sleep(10)
    Application.DoEvents()
    Dim bmp2 = sg.CaptureByRect(rct.Left, rct.Top, rct.Right - rct.Left, rct.Bottom - rct.Top)
    'Threading.Thread.Sleep(1000)

    frm.Dispose()

    ScreenGrab6.CSharpFilters.BitmapFilter.CalculateAlpha(bmp1, bmp2, Nothing)

    'For x = 0 To bmp1.Width - 1
    '  For y = 0 To bmp1.Height - 1
    '    Dim c1 = bmp1.GetPixel(x, y)
    '    Dim c2 = bmp2.GetPixel(x, y)

    '    Dim diff As Integer = Math.Abs((CInt(c1.R) + c1.G + c1.B) / 3 - (CInt(c2.R) + c2.G + c2.B) / 3)

    '    bmp2.SetPixel(x, y, Color.FromArgb(255 - diff, (CInt(c1.R) + c2.R) / 2, (CInt(c1.B) + c2.B) / 2, (CInt(c1.B) + c2.B) / 2))

    '  Next
    'Next


    Form1.PictureBox1.Image = bmp2

  End Sub

  <Flags()> _
  Private Enum SetWindowPosFlags As UInteger
    ''' <summary>If the calling thread and the thread that owns the window are attached to different input queues, 
    ''' the system posts the request to the thread that owns the window. This prevents the calling thread from 
    ''' blocking its execution while other threads process the request.</summary>
    ''' <remarks>SWP_ASYNCWINDOWPOS</remarks>
    SynchronousWindowPosition = &H4000
    ''' <summary>Prevents generation of the WM_SYNCPAINT message.</summary>
    ''' <remarks>SWP_DEFERERASE</remarks>
    DeferErase = &H2000
    ''' <summary>Draws a frame (defined in the window's class description) around the window.</summary>
    ''' <remarks>SWP_DRAWFRAME</remarks>
    DrawFrame = &H20
    ''' <summary>Applies new frame styles set using the SetWindowLong function. Sends a WM_NCCALCSIZE message to 
    ''' the window, even if the window's size is not being changed. If this flag is not specified, WM_NCCALCSIZE 
    ''' is sent only when the window's size is being changed.</summary>
    ''' <remarks>SWP_FRAMECHANGED</remarks>
    FrameChanged = &H20
    ''' <summary>Hides the window.</summary>
    ''' <remarks>SWP_HIDEWINDOW</remarks>
    HideWindow = &H80
    ''' <summary>Does not activate the window. If this flag is not set, the window is activated and moved to the 
    ''' top of either the topmost or non-topmost group (depending on the setting of the hWndInsertAfter 
    ''' parameter).</summary>
    ''' <remarks>SWP_NOACTIVATE</remarks>
    DoNotActivate = &H10
    ''' <summary>Discards the entire contents of the client area. If this flag is not specified, the valid 
    ''' contents of the client area are saved and copied back into the client area after the window is sized or 
    ''' repositioned.</summary>
    ''' <remarks>SWP_NOCOPYBITS</remarks>
    DoNotCopyBits = &H100
    ''' <summary>Retains the current position (ignores X and Y parameters).</summary>
    ''' <remarks>SWP_NOMOVE</remarks>
    IgnoreMove = &H2
    ''' <summary>Does not change the owner window's position in the Z order.</summary>
    ''' <remarks>SWP_NOOWNERZORDER</remarks>
    DoNotChangeOwnerZOrder = &H200
    ''' <summary>Does not redraw changes. If this flag is set, no repainting of any kind occurs. This applies to 
    ''' the client area, the nonclient area (including the title bar and scroll bars), and any part of the parent 
    ''' window uncovered as a result of the window being moved. When this flag is set, the application must 
    ''' explicitly invalidate or redraw any parts of the window and parent window that need redrawing.</summary>
    ''' <remarks>SWP_NOREDRAW</remarks>
    DoNotRedraw = &H8
    ''' <summary>Same as the SWP_NOOWNERZORDER flag.</summary>
    ''' <remarks>SWP_NOREPOSITION</remarks>
    DoNotReposition = &H200
    ''' <summary>Prevents the window from receiving the WM_WINDOWPOSCHANGING message.</summary>
    ''' <remarks>SWP_NOSENDCHANGING</remarks>
    DoNotSendChangingEvent = &H400
    ''' <summary>Retains the current size (ignores the cx and cy parameters).</summary>
    ''' <remarks>SWP_NOSIZE</remarks>
    IgnoreResize = &H1
    ''' <summary>Retains the current Z order (ignores the hWndInsertAfter parameter).</summary>
    ''' <remarks>SWP_NOZORDER</remarks>
    IgnoreZOrder = &H4
    ''' <summary>Displays the window.</summary>
    ''' <remarks>SWP_SHOWWINDOW</remarks>
    ShowWindow = &H40
  End Enum
End Module
