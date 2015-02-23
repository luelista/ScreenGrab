' Code generator script for ScreenGrab-Collage-Modus / VUMLCodeGeneration
' Author: Max Weller
' Language: Visual Basic .NET
' SG Version: 5.8

Dim LF : LF = Chr(13)+Chr(10)
Dim trace: Set trace = AddFile("trace.txt")
trace.WriteLine "--> Start Code generation " & Now

For i = 0 To Canvas.ItemCount - 1
  Dim item: Set item = Canvas.Item(i)
  Dim typ: typ = UCase(item.TypeName)
  
  trace.WriteLine("Object of type " & typ & " #" & i & ": " & item.Name)
  
  If typ = "VUMLCLASS" Then
    OutputClass item
  End If
Next

Sub OutputClass(classObject)
  Dim i, out: Set out = AddFile(classObject.ClassName + ".vb")
  trace.WriteLine "Class-Name: " + classObject.ClassName
  out.WriteLine "Public Class " + classObject.ClassName
  out.WriteLine "  "
  trace.WriteLine "------ Attributes -------"
  out.WriteLine "  ' Attribute"
  out.WriteLine "  "
  For i = 0 To classObject.AttributeCount - 1
    Dim attr: Set attr = classObject.Attribute(i)
    out.WriteLine "  " + GetVisibility(attr.Visibility)+ IIF(attr.IsShared, " Shared", "")+" " + attr.Name + " As " + attr.Type
  Next
  out.WriteLine "  "
  out.WriteLine "  "
  trace.WriteLine "------ Properties(1) -------"
  out.WriteLine "  ' Eigenschaften"
  out.WriteLine "  "
  Dim properties: Set properties=CreateObject("Scripting.Dictionary")
  Dim methods:    Set methods=CreateObject("Scripting.Dictionary")
  For i = 0 To classObject.MethodCount - 1
    Dim mName : mName = UCASE(classObject.Method(i).Name)
    If IsProperty(mName) Then
      If Left(mName, 4) = "GET_" Then properties.Item(Mid(mName, 5)) = properties.Item(Mid(mName, 5)) + 1
      If Left(mName, 4) = "SET_" Then properties.Item(Mid(mName, 5)) = properties.Item(Mid(mName, 5)) + 2
    End If
    methods.Add mName, classObject.Method(i)
  Next
  trace.WriteLine "------ Properties(2) -------"
  For Each pName In properties.Keys'i = 0 To properties.Count - 1
    'Dim pName: pName = properties.Keys(i)
    trace.WriteLine "Property: " + pName
    Dim pStat: pStat = properties.Item(pName)
    Dim pTyp, pItem
    If pStat = 1 Or pStat = 3 Then Set pItem = methods.Item("GET_" + pName) : pTyp = pItem.ReturnValue
    If pStat = 2 Then              Set pItem = methods.Item("SET_" + pName) : pTyp = pItem.ParameterType(0)
    
    out.WriteLine "  " + GetVisibility(pItem.Visibility)+ IIF(pItem.IsShared, " Shared", "")+IIF(pStat = 1, " ReadOnly", "")+IIF(pStat = 2, " WriteOnly", "")+" Property " + Mid(pItem.Name, 5) + "() As " + pTyp
    If pStat = 1 Or pStat = 3 Then out.WriteLine "    Get" + LF + "      " + LF + "    End Get"
    If pStat = 2 Or pStat = 3 Then out.WriteLine "    Set(value As " + pTyp + ")" + LF + "      " + LF + "    End Set"
    out.WriteLine "  End Property"
    out.WriteLine "  "
  Next
  trace.WriteLine "------ Methods -------"
  out.WriteLine "  "
  out.WriteLine "  ' Methoden"
  out.WriteLine "  "
  For Each meth In methods.Items
    If Not IsProperty(meth.Name) Then
      trace.WriteLine "Method: " + meth.Name
      If meth.IsVoid Then
        out.WriteLine "  " + GetVisibility(meth.Visibility)+ IIF(meth.IsShared, " Shared", "")+ _
                             " Sub " + meth.Name + "(" + GetParameters(meth) + ")"
        out.WriteLine "    ' to be implemented ..."
        out.WriteLine "    "
        out.WriteLine "  End Sub"
      Else
        out.WriteLine "  " + GetVisibility(meth.Visibility)+ IIF(meth.IsShared, " Shared", "")+ _
                             " Function " + meth.Name + "(" + GetParameters(meth) + ") As " + meth.ReturnValue
        out.WriteLine "    ' to be implemented ..."
        out.WriteLine "    "
        out.WriteLine "  End Function"
      End If
      out.WriteLine "  "
    End If
  Next
  out.WriteLine "End Class"
End Sub

Function IsProperty(mName)
  If Len(mName) > 4 Then
    If UCASE(Left(mName, 4)) = "GET_" Or UCASE(Left(mName, 4)) = "SET_" Then
      IsProperty = True
    End If
  End If
End Function

Function GetParameters(meth)
  Dim i, paras()
  Redim paras(meth.ParameterCount - 1)
  For i = 0 To meth.ParameterCount - 1
    paras(i) = "ByVal " &  meth.ParameterName(i) & " As " & meth.ParameterType(i)
  Next
  GetParameters = Join(paras, ",")
End Function

Function GetVisibility(idx)
  If idx = 0 Then GetVisibility = "Public"
  If idx = 1 Then GetVisibility = "Protected"
  If idx = 2 Then GetVisibility = "Private"
  
End Function

trace.WriteLine("--> Completed Code generation " & Now)

' Diese Zeile auskommentieren, um Trace-Ausgabe zu behalten:
trace.Delete
