Imports System.Windows.Forms
Imports ScreenGrab6.Vector

Public Class frm_editUmlMember

  Private meth As Vector.VUMLMethod, attr As Vector.VUMLAttribute

  Sub SetMethod(ByVal m As Vector.VUMLMethod)
    meth = m

    TextBox1.Text = m.Name
    TextBox2.Text = m.ReturnValue
    chkIsStatic.Checked = m.IsShared

    rbPrivate.Checked = m.Visibility = VUMLVisibility.Private
    rbProtected.Checked = m.Visibility = VUMLVisibility.Protected
    rbPublic.Checked = m.Visibility = VUMLVisibility.Public

    lstParams.Items.AddRange(m.Parameters.ToArray)

  End Sub

  Sub SetAttribute(ByVal m As Vector.VUMLAttribute)
    attr = m

    TextBox1.Text = m.Name
    TextBox2.Text = m.Type
    chkIsStatic.Checked = m.IsShared

    rbPrivate.Checked = m.Visibility = VUMLVisibility.Private
    rbProtected.Checked = m.Visibility = VUMLVisibility.Protected
    rbPublic.Checked = m.Visibility = VUMLVisibility.Public

    GroupBox1.Enabled = False
  End Sub


  Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
    If Not (rbPrivate.Checked Or rbProtected.Checked Or rbPublic.Checked) Then MsgBox("Bitte wähle eine Sichtbarkeitseinstellung aus!", MsgBoxStyle.Information) : Exit Sub

    If meth IsNot Nothing Then
      meth.Name = TextBox1.Text
      meth.ReturnValue = TextBox2.Text
      meth.IsVoid = String.IsNullOrEmpty(meth.ReturnValue)
      meth.IsShared = chkIsStatic.Checked

      If rbPrivate.Checked Then meth.Visibility = VUMLVisibility.Private
      If rbProtected.Checked Then meth.Visibility = VUMLVisibility.Protected
      If rbPublic.Checked Then meth.Visibility = VUMLVisibility.Public

      meth.Parameters.Clear()
      For Each item In lstParams.Items
        meth.Parameters.Add(item)
      Next
    End If

    If attr IsNot Nothing Then
      attr.Name = TextBox1.Text
      attr.Type = TextBox2.Text
      attr.IsShared = chkIsStatic.Checked

      If rbPrivate.Checked Then attr.Visibility = VUMLVisibility.Private
      If rbProtected.Checked Then attr.Visibility = VUMLVisibility.Protected
      If rbPublic.Checked Then attr.Visibility = VUMLVisibility.Public
    End If

    Me.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.Close()
  End Sub

  Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Close()
  End Sub

  Private Sub btnMA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMA.Click
    Dim ib As String = "NAME : Type"
abfrage:
    ib = InputBox("Parametername und Typ durch Doppelpunkt getrennt eingeben:", "Neuer Parameter", ib, Left + 5, Top + 100)
    If String.IsNullOrEmpty(ib) Then Return

    If ib.Contains(":") = False Then GoTo abfrage

    Dim parts() = Split(ib, ":", 2)
    parts(0) = Trim(parts(0)) : parts(1) = Trim(parts(1))
    meth.Parameters.Add(parts)
    lstParams.Items.Add(parts)

  End Sub

  Private Sub btnMR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMR.Click
    On Error Resume Next
    lstParams.Items.RemoveAt(lstParams.SelectedIndex)

  End Sub

  Private Sub lstParams_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles lstParams.DrawItem
    e.DrawBackground()
    If e.Index > -1 Then
      e.Graphics.DrawString(lstParams.Items(e.Index)(0), lstParams.Font, New SolidBrush(e.ForeColor), New Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width / 2, e.Bounds.Height))
      e.Graphics.DrawString(lstParams.Items(e.Index)(1), lstParams.Font, New SolidBrush(e.ForeColor), New Rectangle(e.Bounds.X + e.Bounds.Width / 2, e.Bounds.Y, e.Bounds.Width / 2, e.Bounds.Height))
    End If
    e.DrawFocusRectangle()
  End Sub

  Private Sub lstParams_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstParams.MouseDoubleClick
    If lstParams.SelectedIndex = -1 Then Exit Sub

    Dim ib As String = Join(lstParams.Items(lstParams.SelectedIndex), " : ")
abfrage:
    ib = InputBox("Parametername und Typ durch Doppelpunkt getrennt eingeben:", "Neuer Parameter", ib, Left + 5, Top + 100)
    If String.IsNullOrEmpty(ib) Then Return

    If ib.Contains(":") = False Then GoTo abfrage

    Dim parts() = Split(ib, ":", 2)
    parts(0) = Trim(parts(0)) : parts(1) = Trim(parts(1))
    meth.Parameters(lstParams.SelectedIndex) = parts
    lstParams.Items(lstParams.SelectedIndex) = parts
  End Sub

End Class
