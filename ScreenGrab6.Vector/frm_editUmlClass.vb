Imports System.Windows.Forms
Imports ScreenGrab6.Vector

Public Class frm_editUmlClass

  Private cls As VUMLClass

  Sub SetClass(ByVal c As VUMLClass)
    cls = c

    TextBox1.Text = c.ClassName
    TextBox2.Text = c.Subtitle

    rbPrivate.Checked = c.Visibility = VUMLVisibility.Private
    rbProtected.Checked = c.Visibility = VUMLVisibility.Protected
    rbPublic.Checked = c.Visibility = VUMLVisibility.Public

    For Each v In c.Attributes
      With (ListView1.Items.Add(v.Name))
        .Tag = v
        .SubItems.Add(v.Type)
        .SubItems.Add(v.Visibility.ToString)
      End With
    Next
    For Each meth In c.Methods
      addMethod(meth)
    Next

  End Sub

  Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
    If Not (rbPrivate.Checked Or rbProtected.Checked Or rbPublic.Checked) Then MsgBox("Bitte wähle eine Sichtbarkeitseinstellung aus!", MsgBoxStyle.Information) : Exit Sub

    cls.ClassName = TextBox1.Text
    cls.Subtitle = TextBox2.Text
    If rbPrivate.Checked Then cls.Visibility = VUMLVisibility.Private
    If rbProtected.Checked Then cls.Visibility = VUMLVisibility.Protected
    If rbPublic.Checked Then cls.Visibility = VUMLVisibility.Public

    cls.Attributes.Clear()
    cls.Methods.Clear()
    For Each item In ListView1.Items
      cls.Attributes.Add(item.tag)
    Next
    For Each item In ListView2.Items
      cls.Methods.Add(item.tag)
    Next

    Me.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.Close()
  End Sub

  Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Close()
  End Sub

  Private Sub frm_editUmlClass_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    If e.Control Then
      Select Case e.KeyCode
        Case Keys.A
          btnAA_Click(Nothing, Nothing)
        Case Keys.M
          btnMA_Click(Nothing, Nothing)
        Case Keys.P
          btnPA_Click(Nothing, Nothing)
      End Select
    End If
  End Sub

  Private Sub frm_editClassProperties_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub

  Private Sub btnAA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAA.Click
    Dim attr As New VUMLAttribute
    Using dlg As New frm_editUmlMember
      dlg.SetAttribute(attr)
      If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
        With ListView1.Items.Add(attr.Name)
          .Tag = attr
          .SubItems.Add(attr.Type)
          .SubItems.Add(attr.Visibility.ToString)
        End With
      End If
    End Using

  End Sub

  Private Sub btnMA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMA.Click
    Dim meth As New VUMLMethod
    Using dlg As New frm_editUmlMember
      dlg.SetMethod(meth)
      If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
        addMethod(meth)
      End If
    End Using
  End Sub

  Private Sub btnAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAR.Click
    Try
      ListView1.Items.Remove(ListView1.SelectedItems(0))
    Catch ex As Exception

    End Try
  End Sub

  Private Sub btnMR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMR.Click
    Try
      ListView2.Items.Remove(ListView2.SelectedItems(0))
    Catch ex As Exception

    End Try
  End Sub

  Private Sub ListView1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDoubleClick
    Using dlg As New frm_editUmlMember
      Dim attr As VUMLAttribute = ListView1.SelectedItems(0).Tag
      dlg.SetAttribute(attr)
      If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
        ListView1.SelectedItems(0).Text = attr.Name
        ListView1.SelectedItems(0).SubItems(1).Text = attr.Type
        ListView1.SelectedItems(0).SubItems(2).Text = attr.Visibility.ToString
      End If
    End Using
  End Sub

  Private Sub ListView2_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView2.MouseDoubleClick
    Using dlg As New frm_editUmlMember
      Dim meth As VUMLMethod = ListView2.SelectedItems(0).Tag
      dlg.SetMethod(meth)
      If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
        ListView2.SelectedItems(0).Text = meth.Name + "(" + meth.GetParametersString() + ")"
        ListView2.SelectedItems(0).SubItems(1).Text = If(meth.IsVoid, "-", meth.ReturnValue)
        ListView2.SelectedItems(0).SubItems(2).Text = meth.Visibility.ToString
      End If
    End Using
  End Sub

  Sub addMethod(ByVal meth As VUMLMethod)
    With ListView2.Items.Add(meth.Name + "(" + meth.GetParametersString() + ")")
      .Tag = meth
      .SubItems.Add(If(meth.IsVoid, "-", meth.ReturnValue))
      .SubItems.Add(meth.Visibility.ToString)
    End With
  End Sub

  Private Sub ListView2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView2.SelectedIndexChanged, ListView1.SelectedIndexChanged
    btnAR.Enabled = ListView1.SelectedItems.Count = 1
    btnAU.Enabled = ListView1.SelectedItems.Count = 1
    btnAD.Enabled = ListView1.SelectedItems.Count = 1

    btnMR.Enabled = ListView2.SelectedItems.Count = 1
    btnMU.Enabled = ListView2.SelectedItems.Count = 1
    btnMD.Enabled = ListView2.SelectedItems.Count = 1

  End Sub

  Private Sub btnPA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPA.Click
    Dim ib As String = InputBox( _
        "Gib den Name und Typ der Eigenschaft durch Doppelpunkt getrennt ein. Es werden automatisch zwei Methoden angelegt:" + vbNewLine + "+ ? get_NAME() : TYPE" + vbNewLine + "+ ! set_NAME(value : TYPE)", "Neue Eigenschaft erstellen", "NAME : TYPE")
    If String.IsNullOrEmpty(ib) OrElse ib.Contains(":") = False Then Return

    Dim pName = ib.Substring(0, ib.IndexOf(":")).Trim
    Dim pType = ib.Substring(ib.IndexOf(":") + 1).Trim

    Dim meth As VUMLMethod
    meth = New VUMLMethod
    meth.Name = "get_" + pName
    meth.IsVoid = False
    meth.ReturnValue = pType
    addMethod(meth)

    meth = New VUMLMethod
    meth.Name = "set_" + pName
    meth.IsVoid = True
    meth.Parameters.Add(New String() {"value", pType})
    addMethod(meth)

  End Sub
End Class
