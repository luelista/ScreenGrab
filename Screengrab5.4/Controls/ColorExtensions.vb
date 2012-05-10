'Modified from GetNearest...
'   http://social.msdn.microsoft.com/Forums/en-US/vbgeneral/thread/b2d491ac-4031-46d6-bccb-8bf9a46c2289
'   http://www.eggheadcafe.com/conversation.aspx?messageid=31472401&threadid=31472286

Imports System.Reflection

Public Module ColorExtensions

    ''' <summary>
    ''' Gets the <see cref="System.Drawing.Color.Name">System.Drawing.Color.Name</see> of the closest matching color.
    ''' </summary>
    ''' <example>
    ''' <code>
    '''    Private Sub Example()
    '''        Dim oColor As Color = Color.FromName(GetNearestName(Color.FromArgb(255, 255, 255, 0)))
    '''        Debug.Assert(oColor.Name = "Yellow")
    '''    End Sub
    ''' </code>
    ''' </example>
    Public Function GetNearestName(ByVal unknownColor As Color) As String

        'short-circut
        If unknownColor.IsNamedColor Then
            Return unknownColor.Name
        End If

        Dim oBestMatch As ColorName = GetNearestNameInternal(unknownColor)

        Return oBestMatch.Name
    End Function

    ''' <summary>
    ''' Gets the <see cref="System.Drawing.KnownColor">System.Drawing.KnownColor</see> of the closest matching known color.
    ''' </summary>
    ''' <example>
    ''' <code>
    '''    Private Sub Example()
    '''        Dim oColor As Color =  Color.FromKnownColor(GetNearestKnownColor(Color.FromArgb(255, 255, 255, 0)))
    '''        Debug.Assert(oColor.Name = "Yellow")
    '''    End Sub
    ''' </code>
    ''' </example>
    Public Function GetNearestKnownColor(ByVal unknownColor As Color) As KnownColor

        'short-circut
        If unknownColor.IsKnownColor Then
            Return unknownColor.ToKnownColor
        End If

        Dim oBestMatch As ColorName = GetNearestKnownColorInternal(unknownColor)

        Return oBestMatch.Color.ToKnownColor
    End Function

    Friend Structure ColorName

        Public Name As String
        Public Color As Color
        Public Distance As Double

        ''' <summary>
        ''' Returns RGB=(212,208,200)
        ''' </summary>
        Public Function ToRGBString() As String
            Return String.Format("RGB=({0},{1},{2})", Color.R, Color.G, Color.B)
        End Function

    End Structure

    Friend Function GetNearestNameInternal(ByVal unknownColor As Color) As ColorName

        Dim oBestMatch As ColorName = Nothing
        Dim nClosestDistance As Double = Double.MaxValue

        Dim oBindingFlags As BindingFlags = _
            BindingFlags.DeclaredOnly Or _
            BindingFlags.Public Or _
            BindingFlags.Static

        For Each oProperty As PropertyInfo In GetType(Color).GetProperties(oBindingFlags)

            Dim oNamedColor As Color = DirectCast(oProperty.GetValue(Nothing, Nothing), Color)
            Dim nDistance As Double

            nDistance = System.Math.Sqrt( _
                (CInt(unknownColor.R) - oNamedColor.R) ^ 2 + _
                (CInt(unknownColor.G) - oNamedColor.G) ^ 2 + _
                (CInt(unknownColor.B) - oNamedColor.B) ^ 2)

            nDistance = System.Math.Sqrt(nDistance / 3)

            If nDistance < nClosestDistance Then
                nClosestDistance = nDistance
                oBestMatch.Name = oProperty.Name
                oBestMatch.Distance = nDistance
                oBestMatch.Color = oNamedColor
            End If

        Next

        Return oBestMatch
    End Function

    Friend Function GetNearestKnownColorInternal(ByVal unknownColor As Color) As ColorName

        Dim oBestMatch As ColorName = Nothing
        Dim nClosestDistance As Double = Double.MaxValue

        For Each sColorName As String In [Enum].GetNames(GetType(KnownColor))

            Dim oNamedColor As Color = Color.FromName(sColorName)
            Dim nDistance As Double

            nDistance = System.Math.Sqrt( _
                (CInt(unknownColor.R) - oNamedColor.R) ^ 2 + _
                (CInt(unknownColor.G) - oNamedColor.G) ^ 2 + _
                (CInt(unknownColor.B) - oNamedColor.B) ^ 2)

            nDistance = System.Math.Sqrt(nDistance / 3)

            If nDistance < nClosestDistance Then
                nClosestDistance = nDistance
                oBestMatch.Name = oNamedColor.Name
                oBestMatch.Distance = nDistance
                oBestMatch.Color = oNamedColor
            End If

        Next

        Return oBestMatch
    End Function

End Module
