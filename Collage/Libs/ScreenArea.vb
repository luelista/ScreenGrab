'*************************************************************************\
'   Copyright (c) 2008 - Gbtc, James Ritchie Carroll
'   All rights reserved.
'  
'   Redistribution and use in source and binary forms, with or without
'   modification, are permitted provided that the following conditions
'   are met:
'  
'      * Redistributions of source code must retain the above copyright
'        notice, this list of conditions and the following disclaimer.
'       
'      * Redistributions in binary form must reproduce the above
'        copyright notice, this list of conditions and the following
'        disclaimer in the documentation and/or other materials provided
'        with the distribution.
'  
'   THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDER "AS IS" AND ANY
'   EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
'   IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR
'   PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR
'   CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
'   EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
'   PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
'   PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY
'   OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
'   (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
'   OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
'  
'\*************************************************************************


Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Windows.Forms

''' <summary>Returns screen area statistics and capture functionality for all connected screens.</summary>
Public Module ScreenArea

  ''' <summary>
  ''' Gets the least "x" coordinate of all screens on the system
  ''' </summary>
  ''' <returns>The smallest visible "x" screen coordinate</returns>
  Public ReadOnly Property LeftMostBound() As Integer
    Get
      Dim leftBound As Integer = Integer.MaxValue

      ' Return the left-most "x" screen coordinate
      For Each display As Screen In Screen.AllScreens
        If leftBound > display.Bounds.X Then
          leftBound = display.Bounds.X
        End If
      Next

      Return leftBound
    End Get
  End Property

  ''' <summary>
  ''' Gets the greatest "x" coordinate of all screens on the system
  ''' </summary>
  ''' <returns>The largest visible "x" screen coordinate</returns>
  Public ReadOnly Property RightMostBound() As Integer
    Get
      Dim rightBound As Integer = Integer.MinValue

      ' Return the right-most "x" screen coordinate
      For Each display As Screen In Screen.AllScreens
        If rightBound < display.Bounds.X + display.Bounds.Width Then
          rightBound = display.Bounds.X + display.Bounds.Width
        End If
      Next

      Return rightBound
    End Get
  End Property

  ''' <summary>
  ''' Gets the least "y" coordinate of all screens on the system
  ''' </summary>
  ''' <returns>The smallest visible "y" screen coordinate</returns>
  Public ReadOnly Property TopMostBound() As Integer
    Get
      Dim topBound As Integer = Integer.MaxValue

      ' Return the top-most "y" screen coordinate
      For Each display As Screen In Screen.AllScreens
        If topBound > display.Bounds.Y Then
          topBound = display.Bounds.Y
        End If
      Next

      Return topBound
    End Get
  End Property

  ''' <summary>
  ''' Gets the greatest "y" coordinate of all screens on the system
  ''' </summary>
  ''' <returns>The largest visible "y" screen coordinate</returns>
  Public ReadOnly Property BottomMostBound() As Integer
    Get
      Dim bottomBound As Integer = Integer.MinValue

      ' Return the bottom-most "y" screen coordinate
      For Each display As Screen In Screen.AllScreens
        If bottomBound < display.Bounds.Y + display.Bounds.Height Then
          bottomBound = display.Bounds.Y + display.Bounds.Height
        End If
      Next

      Return bottomBound
    End Get
  End Property

  ''' <summary>
  ''' Gets the width of the screen with the highest resolution.
  ''' </summary>
  ''' <returns>The width of the screen with the highest resolution.</returns>
  Public ReadOnly Property MaximumWidth() As Integer
    Get
      Dim maxWidth As Integer = Integer.MinValue

      ' In this case we just get the largest screen height
      For Each display As Screen In Screen.AllScreens
        If maxWidth < display.Bounds.Width Then
          maxWidth = display.Bounds.Width
        End If
      Next

      Return maxWidth
    End Get
  End Property

  ''' <summary>
  ''' Gets the width of the screen with the lowest resolution.
  ''' </summary>
  ''' <returns>The width of the screen with the lowest resolution.</returns>
  Public ReadOnly Property MinimumWidth() As Integer
    Get
      Dim minWidth As Integer = Integer.MaxValue

      ' In this case we just get the smallest screen height
      For Each display As Screen In Screen.AllScreens
        If minWidth > display.Bounds.Width Then
          minWidth = display.Bounds.Width
        End If
      Next

      Return minWidth
    End Get
  End Property

  ''' <summary>
  ''' Gets the height of the screen with the highest resolution.
  ''' </summary>
  ''' <returns>The height of the screen with the highest resolution.</returns>
  Public ReadOnly Property MaximumHeight() As Integer
    Get
      Dim maxHeight As Integer = Integer.MinValue

      ' In this case we just get the largest screen height
      For Each display As Screen In Screen.AllScreens
        If maxHeight < display.Bounds.Height Then
          maxHeight = display.Bounds.Height
        End If
      Next

      Return maxHeight
    End Get
  End Property

  ''' <summary>
  ''' Gets the height of the screen with the lowest resolution.
  ''' </summary>
  ''' <returns>The height of the screen with the lowest resolution.</returns>
  Public ReadOnly Property MinimumHeight() As Integer
    Get
      Dim minHeight As Integer = Integer.MaxValue

      ' In this case we just get the smallest screen height
      For Each display As Screen In Screen.AllScreens
        If minHeight > display.Bounds.Height Then
          minHeight = display.Bounds.Height
        End If
      Next

      Return minHeight
    End Get
  End Property

  ''' <summary>
  ''' Gets the total width of all the screens relative to their arrangement.
  ''' </summary>
  ''' <returns>The total width of all the screens relative to their arrangement.</returns>
  Public ReadOnly Property TotalWidth() As Integer
    Get
      Return RightMostBound - LeftMostBound
    End Get
  End Property

  ''' <summary>
  ''' Gets the total height of all the screens relative to their arrangement.
  ''' </summary>
  ''' <returns>The total height of all the screens relative to their arrangement.</returns>
  Public ReadOnly Property TotalHeight() As Integer
    Get
      Return BottomMostBound - TopMostBound
    End Get
  End Property
End Module
