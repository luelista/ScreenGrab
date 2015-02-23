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
  Dim i, out: Set out = AddFile("U" + classObject.ClassName + ".pas")
  trace.WriteLine "Class-Name: " + classObject.ClassName
  
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
  
  Dim attr,meth
  
  out.WriteLine "unit U" + classObject.ClassName + ";"
  out.WriteLine ""
  out.WriteLine "interface"
  out.WriteLine ""
  out.WriteLine "type"
  out.WriteLine "  " + classObject.ClassName + " = class"
  out.WriteLine "  private"
  For i = 0 To classObject.AttributeCount - 1
    Set attr = classObject.Attribute(i)
    If attr.Visibility = 2 Then _
    out.WriteLine "    " + attr.Name + " : " + attr.Type + ";"
  Next
  For i = 0 To classObject.MethodCount - 1
    Set meth = classObject.Method(i)
    If meth.Visibility = 2 Then
    If meth.IsVoid Then out.Write "    procedure " Else out.Write "    function  "
    out.Write meth.Name + "(" + GetParameters(meth) + ")"
    If meth.IsVoid Then out.WriteLine ";" Else out.WriteLine " : " + meth.ReturnValue + ";"
    End If
  Next
  out.WriteLine "  protected"
  For i = 0 To classObject.AttributeCount - 1
    Set attr = classObject.Attribute(i)
    If attr.Visibility = 1 Then _
    out.WriteLine "    " + attr.Name + " : " + attr.Type + ";"
  Next
  For i = 0 To classObject.MethodCount - 1
    Set meth = classObject.Method(i)
    If meth.Visibility = 1 Then
    If meth.IsVoid Then out.Write "    procedure " Else out.Write "    function  "
    out.Write meth.Name + "(" + GetParameters(meth) + ")"
    If meth.IsVoid Then out.WriteLine ";" Else out.WriteLine " : " + meth.ReturnValue + ";"
    End If
  Next
  out.WriteLine "  public"
  For i = 0 To classObject.AttributeCount - 1
    Set attr = classObject.Attribute(i)
    If attr.Visibility = 0 Then _
    out.WriteLine "    " + attr.Name + " : " + attr.Type + ";"
  Next
  For i = 0 To classObject.MethodCount - 1
    Set meth = classObject.Method(i)
    If meth.Visibility = 0 Then
    If meth.IsVoid Then out.Write "    procedure " Else out.Write "    function  "
    out.Write meth.Name + "(" + GetParameters(meth) + ")"
    If meth.IsVoid Then out.WriteLine ";" Else out.WriteLine " : " + meth.ReturnValue + ";"
    End If
  Next
  out.WriteLine "  end;"
  out.WriteLine ""
  out.WriteLine "implementation"
  out.WriteLine ""
  For i = 0 To classObject.MethodCount - 1
    Set meth = classObject.Method(i)
    If meth.IsVoid Then out.Write "procedure " Else out.Write "function "
    out.Write classObject.ClassName + "." + meth.Name + "(" + GetParameters(meth) + ")"
    If meth.IsVoid Then out.WriteLine ";" Else out.WriteLine " : " + meth.ReturnValue + ";"
    out.WriteLine "begin"
    out.WriteLine "  "
    out.WriteLine "end;"
    out.WriteLine ""
  Next
  out.WriteLine ""
  out.WriteLine ""
  out.WriteLine "end."
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
    paras(i) = meth.ParameterName(i) & " : " & meth.ParameterType(i)
  Next
  GetParameters = Join(paras, "; ")
End Function


trace.WriteLine("--> Completed Code generation " & Now)

' Diese Zeile auskommentieren, um Trace-Ausgabe zu behalten:
trace.Delete
