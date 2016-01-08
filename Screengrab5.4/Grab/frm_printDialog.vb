Public Class frm_printDialog
  Public showimg As Image

  Private Sub frm_printDialog_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    glob.para("frm_printDialog__selPrinter") = lstPrinters.SelectedIndex
    glob.para("frm_printDialog__selPaperTray") = cmbPaperSource.SelectedIndex
    glob.para("frm_printDialog__landscape") = If(rbOrientation__lands.Checked, "TRUE", "FALSE")
    glob.para("frm_printDialog__left") = HScrollBar1.Value
    glob.para("frm_printDialog__top") = VScrollBar1.Value
    glob.para("frm_printDialog__zoom") = TrackBar1.Value
    glob.para("frm_printDialog__center") = If(CheckBox1.Checked, "TRUE", "FALSE")

    glob.saveFormPos(Me)
  End Sub



  Private Sub frm_printDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    On Error Resume Next

    For Each prn As String In Printing.PrinterSettings.InstalledPrinters
      lstPrinters.Items.Add(prn)
    Next
    If lstPrinters.Items.Count = 0 Then
      MsgBox("Keine Drucker installiert.")
      Close()
      Exit Sub
    End If

    lstPrinters.SelectedIndex = glob.para("frm_printDialog__selPrinter", "0")
    cmbPaperSource.SelectedIndex = glob.para("frm_printDialog__selPaperTray", "0")
    rbOrientation__lands.Checked = glob.para("frm_printDialog__landscape", "FALSE") = "TRUE"
    rbOrientation__port.Checked = glob.para("frm_printDialog__landscape", "FALSE") = "FALSE"
    rbZoom__pic.Checked = glob.para("frm_printDialog__pageZoom", "TRUE") = "TRUE"
    rbZoom__page.Checked = glob.para("frm_printDialog__pageZoom", "TRUE") = "FALSE"

    CheckBox1.Checked = glob.para("frm_printDialog__center", "FALSE") = "True"

    HScrollBar1.Value = glob.para("frm_printDialog__left", "0")
    VScrollBar1.Value = glob.para("frm_printDialog__top", "0")
    TrackBar1.Value = glob.para("frm_printDialog__zoom", "100")

    glob.readFormPos(Me, cls_globPara.FormPosFlags.Pos)
    If glob.para("frm_printDialog__mode", "small") = "small" Then
      PreviewVisible = False
    Else
      PreviewVisible = True
    End If
  End Sub

  Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    Me.Close()

  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    pd1.PrinterSettings.PrinterName = lstPrinters.SelectedItem
    pd1.PrinterSettings.DefaultPageSettings.PaperSource.SourceName = cmbPaperSource.SelectedItem
    pd1.Print()


    Me.Close()

  End Sub



  Private Sub PrintPreviewControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewControl1.Click

  End Sub

  Private Sub pd1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pd1.PrintPage
    If showimg Is Nothing Then
      e.Cancel = True
      Exit Sub
    End If

    Dim g = e.Graphics
    g.PageUnit = GraphicsUnit.Display


    'Dim availwidth = e.MarginBounds.Width, availheight = e.MarginBounds.Height
    'Dim offsetx = e.MarginBounds.Left, offsety = e.MarginBounds.Top
    Dim offsetx = e.PageSettings.HardMarginX, offsety = e.PageSettings.HardMarginY
    Dim availwidth = e.PageBounds.Width - offsetx * 2, availheight = e.PageBounds.Height - offsety * 2
    Dim nleft, ntop, nwidth, nheight As Single

    If rbZoom__pic.Checked Then
      nwidth = showimg.Width * TrackBar1.Value / 100
      nheight = showimg.Height * TrackBar1.Value / 100
      '* e.PageSettings.PrinterResolution.Y 

    Else
      If showimg.Width > showimg.Height Then
        Dim sizefactor As Single = showimg.Width / showimg.Height
        nwidth = availwidth * TrackBar1.Value / 100
        nheight = nwidth / sizefactor
      Else
        Dim sizefactor As Single = showimg.Width / showimg.Height
        nheight = availheight * TrackBar1.Value / 100
        nwidth = nheight * sizefactor
      End If

    End If
    If CheckBox1.Checked Then
      nleft = (availwidth - nwidth) / 2
      ntop = (availheight - nheight) / 2
    Else
      nleft = (availwidth - nwidth) * HScrollBar1.Value / 100
      ntop = (availheight - nheight) * VScrollBar1.Value / 100
    End If

    g.DrawImage(showimg, offsetx + nleft, offsety + ntop, nwidth, nheight)
    e.HasMorePages = False

  End Sub

  Property PreviewVisible() As Boolean
    Get
      Return Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
    End Get
    Set(ByVal value As Boolean)
      If value Then
        glob.para("frm_printDialog__mode") = "big"
        Me.Size = New Size(850, 650)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        btnPreview.Text = "<<< Vorschau"
        redrawpreview()
      Else
        glob.para("frm_printDialog__mode") = "small"
        Me.Size = New Size(290, 513)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        btnPreview.Text = "Vorschau >>>"
      End If
      PrintPreviewControl1.Visible = value
    End Set
  End Property

  Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
    If btnPreview.Text = "<<< Vorschau" Then
      PreviewVisible = False
    Else
      PreviewVisible = True
    End If
  End Sub

  Sub redrawpreview()
    On Error Resume Next
    If glob.para("frm_printDialog__mode", "small") = "small" Then Exit Sub

    pd1.DefaultPageSettings.PaperSize.RawKind = Printing.PaperKind.A4
    pd1.DefaultPageSettings.Landscape = rbOrientation__lands.Checked

    PrintPreviewControl1.InvalidatePreview()
  End Sub

  Private Sub rbOrientation__port_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
  Handles rbOrientation__port.Click, rbOrientation__lands.Click, CheckBox1.Click, _
  rbZoom__page.Click, rbZoom__pic.Click
    VScrollBar1.Enabled = Not CheckBox1.Checked
    HScrollBar1.Enabled = Not CheckBox1.Checked

    redrawpreview()
  End Sub

  Private Sub HScrollBar1_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) _
  Handles VScrollBar1.ValueChanged, TrackBar1.ValueChanged, HScrollBar1.ValueChanged
    tmrRedraw.Stop()
    tmrRedraw.Start()
    txtZoom.Text = TrackBar1.Value
  End Sub

  Private Sub tmrRedraw_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrRedraw.Tick
    tmrRedraw.Stop()
    redrawpreview()
  End Sub

  Private Sub txtZoom_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtZoom.TextChanged
    On Error Resume Next
    TrackBar1.Value = Val(txtZoom.Text)
  End Sub

  Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstPrinters.SelectedIndexChanged
    Cursor = Cursors.WaitCursor

    Dim ps As New Printing.PrinterSettings()
    ps.PrinterName = lstPrinters.SelectedItem
    cmbPaperSource.Items.Clear()
    If ps.PaperSources.Count = 0 Then Cursor = Cursors.Default : Exit Sub

    For Each sourc As Printing.PaperSource In ps.PaperSources
      cmbPaperSource.Items.Add(sourc.SourceName)
    Next
    cmbPaperSource.SelectedIndex = 0

    Cursor = Cursors.Default
  End Sub

  Private Sub txtPreviewZoom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPreviewZoom.ValueChanged
    PrintPreviewControl1.Zoom = txtPreviewZoom.Value / 100

  End Sub
End Class