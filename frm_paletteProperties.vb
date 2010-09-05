Public Class frm_paletteProperties

  Private selObj As Vector.VObject
  Public Property SelectedObject() As Vector.VObject
    Get
      Return selObj
    End Get
    Set(ByVal value As Vector.VObject)
      selObj = Nothing
      If value Is Nothing Then
        pnlProperties.Enabled = False
        Exit Property
      End If
      pnlProperties.Enabled = True

      txtName.Text = value.name
      ComboBox1.Text = value.name
      txtType.Text = value.GetType.Name

      nudX.Value = value.bounds.X
      nudY.Value = value.bounds.Y
      nudXX.Value = value.bounds.Width
      nudYY.Value = value.bounds.Height

      If value.borderPen Is Nothing Then
        nudBorderWidth.Value = 0
        txtBorderColor.Text = ""
      Else
        nudBorderWidth.Value = value.borderPen.Width
        txtBorderColor.Text = ColorTranslator.ToHtml(value.borderPen.Color)
      End If

      If TypeOf value Is Vector.VTextbox Then
        pnlFont.Enabled = True
        Dim vt As Vector.VTextbox = value
        Label10.Font = vt.fnt
        If TypeOf vt.brsh Is SolidBrush Then
          Label10.ForeColor = DirectCast(vt.brsh, SolidBrush).Color

        End If
      Else
        pnlFont.Enabled = False
      End If


      selObj = value
    End Set
  End Property

  Private m_Canvas As Vector.Canvas
  Public Property MyCanvas() As Vector.Canvas
    Get
      Return m_Canvas
    End Get
    Set(ByVal value As Vector.Canvas)
      m_Canvas = value
    End Set
  End Property


  Sub RefreshItemList()
    ComboBox1.Items.Clear()
    For Each itm In m_Canvas.objects
      ComboBox1.Items.Add(Trim(itm.name))
    Next

  End Sub

  Private Sub frm_paletteProperties_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    e.Cancel = True
    Me.Hide()
    frm_mdiViewer2.repositionPaletteWindows()
  End Sub
  Private Sub frm_paletteProperties_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
    frm_mdiViewer2.repositionPaletteWindows()
  End Sub
  Private Sub frm_paletteProperties_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub

  Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
    If selObj Is Nothing Or m_Canvas Is Nothing Then Exit Sub
    selObj.name = txtName.Text
  End Sub

  Private Sub nudXY_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
  Handles nudYY.ValueChanged, nudY.ValueChanged, nudXX.ValueChanged, nudX.ValueChanged
    If selObj Is Nothing Or m_Canvas Is Nothing Then Exit Sub
    selObj.bounds = New Rectangle(nudX.Value, nudY.Value, nudXX.Value, nudYY.Value)
    m_Canvas.Invalidate()
  End Sub

  Private Sub txtBorderColor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
  Handles txtBorderColor.TextChanged, nudBorderWidth.ValueChanged
    If selObj Is Nothing Or m_Canvas Is Nothing Then Exit Sub
    Try
      selObj.setBorder(nudBorderWidth.Value, ColorTranslator.FromHtml(txtBorderColor.Text))
      m_Canvas.Invalidate()
    Catch ex As Exception
    End Try
  End Sub

  Private Sub btnFormat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFormat.Click
    Dim oldFont As Font
    Dim vt As Vector.VTextbox = DirectCast(selObj, Vector.VTextbox)
    FontDialog1.Font = vt.fnt
    oldFont = vt.fnt
    If FontDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
      vt.fnt = FontDialog1.Font
    Else
      vt.fnt = oldFont
    End If
    m_Canvas.Invalidate()
  End Sub

  Private Sub FontDialog1_Apply(ByVal sender As Object, ByVal e As System.EventArgs) Handles FontDialog1.Apply
    Dim vt As Vector.VTextbox = DirectCast(selObj, Vector.VTextbox)
    vt.fnt = FontDialog1.Font
    m_Canvas.Invalidate()
  End Sub

  Private Sub btnText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnText.Click
    m_Canvas.showTextEditor(selObj, False)
  End Sub

  Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
    Dim obj = frm_mdiViewer2.canvas.GetObjectByID(ComboBox1.SelectedItem)
    If obj Is Nothing Then
      RefreshItemList()
      Exit Sub
    End If
    frm_mdiViewer2.canvas.SelectObject(obj)
  End Sub
End Class