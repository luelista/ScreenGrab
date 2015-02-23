' Code generator script for ScreenGrab-Collage-Modus / VUMLCodeGeneration
' Author: Max Weller
' Language: Java
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
  Dim i, out: Set out = AddFile(classObject.ClassName + ".java")
  trace.WriteLine "Class-Name: " + classObject.ClassName
  out.WriteLine "public class " + classObject.ClassName + " {"
  out.WriteLine "  "
  out.WriteLine "  // Attribute"
  out.WriteLine "  "
  For i = 0 To classObject.AttributeCount - 1
    Dim attr: Set attr = classObject.Attribute(i)
    out.WriteLine "  " + GetVisibility(attr.Visibility)+ " " + attr.Type + " " + attr.Name + ";"
  Next
  out.WriteLine "  "
  out.WriteLine "  "
  out.WriteLine "  // Methoden"
  out.WriteLine "  "
  For i = 0 To classObject.MethodCount - 1
    Dim meth: Set meth = classObject.Method(i)
    If meth.IsVoid Then meth.ReturnValue = "void"
    trace.WriteLine "Method: " + meth.Name + " (AS "+meth.ReturnValue+")"
    out.WriteLine "  " + GetVisibility(meth.Visibility) + " " + meth.ReturnValue + " " + meth.Name + "(" + GetParameters(meth) + ") {"
    out.WriteLine "    // to be implemented ..."
    out.WriteLine "    "
    out.WriteLine "  } // End Function"
    out.WriteLine "  "
  Next
  out.WriteLine "} //end Class"
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
    paras(i) = meth.ParameterType(i) & " " &  meth.ParameterName(i)
  Next
  GetParameters = Join(paras, ", ")
End Function

Function GetVisibility(idx)
  If idx = 0 Then GetVisibility = "public"
  If idx = 1 Then GetVisibility = "protected"
  If idx = 2 Then GetVisibility = "private"
  
End Function

trace.WriteLine("--> Completed Code generation " & Now)

' Diese Zeile auskommentieren, um Trace-Ausgabe zu behalten:
trace.Delete
