Imports System.Drawing.Imaging

Public Class frm_mdiViewer

  Dim actZIndexMax As Integer = 500
  Dim actZIndexMin As Integer = 500



  Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
    Dim msg As WindowsMessages = m.Msg
    If msg = WindowsMessages.WM_SYSCOMMAND Then
      Dim itemIdx As Integer = m.WParam
      If itemIdx >= &H770 AndAlso itemIdx < &H770 + ContextMenuStrip1.Items.Count Then
        Dim item = ContextMenuStrip1.Items(itemIdx - &H770)
        item.PerformClick()


      End If
      Debug.Print(msg.ToString + vbTab + Hex(m.WParam.ToInt32))

    End If

    MyBase.WndProc(m)
  End Sub


  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    addPicClient()
  End Sub

  Sub setCtrlZIndex(ByVal ctl As Control, ByVal index As Integer)
    ctl.Tag = index
    actZIndexMax = Math.Max(actZIndexMax, index)
    actZIndexMin = Math.Min(actZIndexMin, index)
  End Sub

  Function addPicClient(ByVal img As Image) As PictureBox
    Dim pic As New PictureBox
    With pic
      .BackgroundImageLayout = ImageLayout.Stretch
      If img IsNot Nothing Then
        .BackgroundImage = img
        .Size = .BackgroundImage.Size
      End If
      Me.Controls.Add(pic)
      AddHandler .MouseDown, AddressOf PIC_MouseDown
      AddHandler .MouseMove, AddressOf PIC_MouseMove
      AddHandler .MouseUp, AddressOf PIC_MouseUp
      If RahmenAnzeigenToolStripMenuItem.Checked Then
        .BorderStyle = BorderStyle.FixedSingle
      Else
        .BorderStyle = BorderStyle.None
      End If
      .BringToFront()
      setCtrlZIndex(pic, actZIndexMax + 1)

    End With
    Return pic
  End Function

  Sub addPicClient()
    Dim img = getCompleteImage()
    If img Is Nothing Then Exit Sub
    addPicClient(img)
  End Sub

  Function addRtfClient() As RichTextBox
    Dim txt As New RichTextBox
    Me.Controls.Add(txt)
    AddHandler txt.MouseDown, AddressOf PIC_MouseDown
    AddHandler txt.MouseMove, AddressOf PIC_MouseMove
    AddHandler txt.MouseUp, AddressOf PIC_MouseUp
    If RahmenAnzeigenToolStripMenuItem.Checked Then
      txt.BorderStyle = BorderStyle.FixedSingle
    Else
      txt.BorderStyle = BorderStyle.None
    End If
    txt.BringToFront()
    setCtrlZIndex(txt, actZIndexMax + 1)
    Return txt
  End Function

  Private Sub TextboxEinfuegenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextboxEinfuegenToolStripMenuItem.Click
    addRtfClient()
  End Sub

  Private Sub PIC_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    If TypeOf sender Is RichTextBox And isKeyPressed(Keys.Menu) = False Then Exit Sub
    If e.Button = Windows.Forms.MouseButtons.Left Then
      sender.BringToFront()
      setCtrlZIndex(sender, actZIndexMax + 1)
      If e.X > sender.Width - 15 And e.Y > sender.Height - 15 Then
        FormResizeTricky(sender.Handle, HitTestValues.HTBOTTOMRIGHT)
      Else
        FormMoveTricky(sender.Handle)
      End If
    ElseIf e.Button = Windows.Forms.MouseButtons.Middle Then
      sender.sendtoback()
      setCtrlZIndex(sender, actZIndexMin - 1)
    End If
  End Sub

  Private Sub PIC_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    If TypeOf sender Is RichTextBox And isKeyPressed(Keys.Menu) = False Then sender.Cursor = Cursors.IBeam : Exit Sub
    If e.X > sender.Width - 15 And e.Y > sender.Height - 15 Then
      sender.Cursor = Cursors.SizeNWSE
    Else
      sender.Cursor = Cursors.SizeAll
    End If
  End Sub

  Private Sub PIC_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    'If TypeOf sender Is RichTextBox And isKeyPressed(Keys.Menu) = False Then Exit Sub

    If e.Button = Windows.Forms.MouseButtons.Right And TypeOf sender Is PictureBox Then
      cmsPicBox.Tag = sender
      cmsPicBox.Show(sender, e.Location)
      '  Dim pic As PictureBox = sender
      '  Me.Controls.Remove(pic)
      '  pic.Dispose()
    End If
  End Sub


  Private Sub frm_mdiViewer_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
    addPicClient()
  End Sub

  Private Sub frm_mdiViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    glob.saveFormPos(Me)
  End Sub

  Private Sub frm_mdiViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    glob.readFormPos(Me)

    Me.BackColor = ColorTranslator.FromHtml(glob.para("frm_mdiViewer__Backcolor", "#EFEFEF"))
    onBgColorChanged()

    AutomatischEinfuegenToolStripMenuItem.Checked = glob.para("frm_mdiViewer__autoInsert", "TRUE") = "TRUE"
    RahmenAnzeigenToolStripMenuItem.Checked = glob.para("frm_mdiViewer__border", "FALSE") = "TRUE"

    
    appendToSysMenu(ContextMenuStrip1)
  End Sub

  Sub appendToSysMenu(ByVal cms As ContextMenuStrip)
    Dim hMenu = GetSystemMenu(Me.Handle, False)
    For i = 0 To cms.Items.Count - 1
      If TypeOf cms.Items(i) Is ToolStripSeparator Then
        InsertMenu(hMenu, i, MenuFlags.MF_SEPARATOR Or MenuFlags.MF_BYPOSITION, &H0, "")
      Else
        InsertMenu(hMenu, i, 0 Or MenuFlags.MF_BYPOSITION, &H770 + i, cms.Items(i).Text)
      End If
    Next
    InsertMenu(hMenu, ContextMenuStrip1.Items.Count, MenuFlags.MF_SEPARATOR Or MenuFlags.MF_BYPOSITION, &H0, "")

  End Sub

  Sub onBgColorChanged()
    'For Each ctl As Control In Me.Controls
    '  If TypeOf ctl Is MdiClient Then
    '    ctl.BackColor = Me.BackColor
    '    Exit For
    '  End If
    'Next
  End Sub

  Private Sub frm_mdiViewer_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
    If RahmenlosTransparentToolStripMenuItem.Checked Then Exit Sub
    Dim rect As New Rectangle(0, 0, Me.Width, Me.Height)
    Dim brsh As New Drawing2D.LinearGradientBrush(rect, Color.White, Me.BackColor, Drawing2D.LinearGradientMode.Vertical)
    Dim g As Graphics = Me.CreateGraphics
    g.FillRectangle(brsh, rect)
  End Sub

  Private Sub HintergrundfarbeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HintergrundfarbeToolStripMenuItem.Click
    ColorDialog1.Color = Me.BackColor
    If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
      Me.BackColor = ColorDialog1.Color
      glob.para("frm_mdiViewer__Backcolor") = ColorTranslator.ToHtml(Me.BackColor)
      onBgColorChanged()
    End If
  End Sub

  Private Sub AutomatischEinfuegenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutomatischEinfuegenToolStripMenuItem.Click
    glob.para("frm_mdiViewer__autoInsert") = If(AutomatischEinfuegenToolStripMenuItem.Checked, "TRUE", "FALSE")
  End Sub

  Private Sub RahmenAnzeigenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RahmenAnzeigenToolStripMenuItem.Click
    glob.para("frm_mdiViewer__border") = If(RahmenAnzeigenToolStripMenuItem.Checked, "TRUE", "FALSE")

    For Each ctl In Me.Controls
      If TypeOf ctl Is PictureBox Or TypeOf ctl Is RichTextBox Then
        If RahmenAnzeigenToolStripMenuItem.Checked Then
          ctl.BorderStyle = BorderStyle.FixedSingle
        Else
          ctl.BorderStyle = BorderStyle.None
        End If
      End If
    Next
  End Sub
  Private Sub HTMLSeiteErzeugenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HTMLSeiteErzeugenToolStripMenuItem.Click
    createHtmlPage()
  End Sub

  Sub createHtmlPage()
    Dim fileName As String
    Using sfd As New SaveFileDialog
      sfd.Filter = "HTML-Datei (*.html, *.html, *.htm)|*.html;*.htm"
      If sfd.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
      fileName = sfd.FileName
    End Using

    Dim bgColor = ColorTranslator.ToHtml(Me.BackColor)

    Dim sb As New System.Text.StringBuilder()
    sb.AppendLine("<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01 Transitional//EN"" " + _
                  """http://www.w3.org/TR/html4/loose.dtd"">")
    sb.AppendLine("<html>")
    sb.AppendLine("<head>")
    sb.AppendLine("	<title>" + IO.Path.GetFileNameWithoutExtension(fileName) + "</title>")
    sb.AppendLine("	<meta name=""generator"" content=""ScreenShot 5 Collage"">")
    sb.AppendLine("</head>")
    sb.AppendLine("<body bgcolor=""#888888"">")
    sb.AppendLine("<!-- ##page##" & Me.ClientSize.Width & "##" & Me.ClientSize.Height & "##" & "##" + bgColor.Substring(1) + "## -->")
    sb.AppendLine("<div style=""margin: 10px auto; overflow: hidden; " + _
                  "background-color: " + ColorTranslator.ToHtml(Me.BackColor) + ";" + _
                  "border: 1px solid black; width: " & Me.ClientSize.Width & "px; height: " & Me.ClientSize.Height & "px; "">")

    For Each ch In Me.Controls
      If TypeOf ch Is PictureBox Then
        Dim pic As PictureBox = ch
        Dim img = pic.BackgroundImage
        Dim base64 = ImageToBase64(img)
        sb.Append("<!-- ##img##" & pic.Left & "##" & pic.Top & "##" & pic.Width & "##" & pic.Height & "## -->")
        sb.AppendLine("<img alt=""Screenshot"" style=""position: absolute; z-index: " & _
                      pic.Tag & "; margin-top: " & pic.Top & "px; margin-left: " & pic.Left & "px; height: " & pic.Height & "px; width: " & pic.Width & "px; """)
        sb.Append("src=""")
        sb.Append(base64)
        sb.AppendLine(""" />")
      End If
      If TypeOf ch Is RichTextBox Then
        Dim rtf As RichTextBox = ch
        sb.Append("<!-- ##rtf##" & rtf.Left & "##" & rtf.Top & "##" & rtf.Width & "##" & rtf.Height & "## -->")
        sb.AppendLine("<div style=""position: absolute; background: #fff; z-index: " & _
                      rtf.Tag & "; margin-top: " & rtf.Top & "px; margin-left: " & rtf.Left & "px; height: " & rtf.Height & "px; width: " & rtf.Width & "px; "">")
        sb.AppendLine(Replace(Replace(rtf.Text, vbNewLine, vbLf), vbLf, "<br>"))
        sb.AppendLine("</div>")

      End If
    Next
    sb.AppendLine("</div></body></html>")

    IO.File.WriteAllText(fileName, sb.ToString)
    Process.Start(fileName)
  End Sub

  Function ImageToBase64(ByVal img As Image) As String
    If img Is Nothing Then Return ""
    Dim ms As New IO.MemoryStream()
    img.Save(ms, ImageFormat.Png)
    'img.Save(ms, ImageFormat.Gif)

    ms.Seek(0, IO.SeekOrigin.Begin)
    Dim buf(ms.Length - 1) As Byte
    ms.Read(buf, 0, ms.Length - 1)

    ImageToBase64 = "data:image/png;base64," + Convert.ToBase64String(buf, Base64FormattingOptions.InsertLineBreaks)
    'ImageToBase64 = "data:image/gif;base64," + Convert.ToBase64String(buf, Base64FormattingOptions.InsertLineBreaks)

  End Function

  Function Base64ToImage(ByVal str As System.Text.StringBuilder) As Image
    Dim modus As Integer = 0, datTyp As String = "", abPos As Integer
    Debug.Print(str.ToString)
    For i = 0 To str.Length - 1
      If str.Chars(i) = ":"c Then modus = 1 : Continue For
      If str.Chars(i) = ";"c Then modus = 2 : Continue For
      If str.Chars(i) = ","c Then modus = 3 : abPos = i + 1 : Exit For
      If modus = 1 Then
        datTyp += str.Chars(i)
      End If
    Next

    Dim byt() = Convert.FromBase64String(str.ToString(abPos, str.Length - abPos - 1))
    Dim ms As New IO.MemoryStream(byt)
    Base64ToImage = Image.FromStream(ms)
    ms.Close()
  End Function

  Sub readHtmlPage()
    Dim fileName As String
    Using sfd As New OpenFileDialog
      sfd.Filter = "HTML-Datei (*.html, *.htm)|*.html;*.htm"
      If sfd.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
      fileName = sfd.FileName
    End Using

    Dim sr = IO.File.OpenText(fileName)

    For Each ctrl In Me.Controls
      If TypeOf ctrl Is PictureBox Or TypeOf ctrl Is RichTextBox Then Me.Controls.Remove(ctrl)
    Next

    Dim lineNr = 0, modusCounter As Integer = 0
    Dim line, modus As String, contbuffer As System.Text.StringBuilder
    Dim selClient As Object
    modus = "invalid"
    While sr.EndOfStream = False
      lineNr += 1 : modusCounter += 1
      line = sr.ReadLine
      If line.Contains("ScreenShot 5 Collage") Then
        modus = "valid" : modusCounter = 0
      End If
      If modus = "invalid" Then Continue While

      If line.StartsWith("<!-- ##page##") Then
        Dim para() As String = Split(line, "##")
        Me.BackColor = ColorTranslator.FromHtml("#" + para(5))
        Me.Width = para(2)
        Me.Height = para(3)

        Continue While
      End If
      
      If modus = "rtf" And line = "</div>" Then
        modus = "valid" : modusCounter = 0
      End If

      If modus = "img" And modusCounter >= 1 Then
        If modusCounter = 1 Then line = line.Substring(5) 'src="
        If line.EndsWith(""" />") Then
          modus = "valid" : modusCounter = 0 : line = line.Substring(0, line.Length - 4)
        End If
        contbuffer.AppendLine(line)
        If modus = "valid" Then 'Bild fertig
          Dim img = Base64ToImage(contbuffer)
          selClient.Image = img
        End If
      End If


      If line.StartsWith("<!-- ##img##") Then
        modus = "img" : modusCounter = 0
        Dim para() As String = Split(line, "##")
        selClient = addPicClient(Nothing)
        selClient.Bounds = New Rectangle(para(2), para(3), para(4), para(5))
        contbuffer = New System.Text.StringBuilder()
      End If

      If line.StartsWith("<!-- ##rtf##") Then
        modus = "txt" : modusCounter = 0
        contbuffer = New System.Text.StringBuilder()
      End If


    End While

    If modus = "invalid" Then
      MsgBox("Ungültiges Dateiformat.", MsgBoxStyle.Critical)
    End If

    sr.Close()
  End Sub

  Private Sub EinlesenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EinlesenToolStripMenuItem.Click
    readHtmlPage()
  End Sub

  Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Me.BringToFront()

  End Sub

  Private Sub RahmenlosTransparentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RahmenlosTransparentToolStripMenuItem.Click
    If RahmenlosTransparentToolStripMenuItem.Checked Then
      Me.TransparencyKey = Color.FromArgb(255, 255, 188, 253)
      Me.BackColor = Color.FromArgb(255, 255, 188, 253)
      Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
      Me.Text = ""
      Me.ControlBox = False
      lblMoveme.Visible = True
    Else
      Me.TransparencyKey = Nothing
      Me.BackColor = ColorTranslator.FromHtml(glob.para("frm_mdiViewer__Backcolor", "#EFEFEF"))
      Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
      Me.Text = "ScreenGrab 5 Collage-Modus"
      Me.ControlBox = True
      appendToSysMenu(ContextMenuStrip1)
      lblMoveme.Visible = False
    End If
  End Sub


  Private Sub lblMoveme_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblMoveme.MouseDown
    FormMoveTricky(Me.Handle)
  End Sub

  Private Sub BringToFrontToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BringToFrontToolStripMenuItem.Click
    Dim pic As PictureBox = cmsPicBox.Tag
    pic.BringToFront()
    setCtrlZIndex(pic, actZIndexMax + 1)
  End Sub

  Private Sub SendToBackToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendToBackToolStripMenuItem.Click
    Dim pic As PictureBox = cmsPicBox.Tag
    pic.SendToBack()
    setCtrlZIndex(pic, actZIndexMin - 1)
  End Sub

  Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
    Dim pic As PictureBox = cmsPicBox.Tag
    Me.Controls.Remove(pic)
    pic.Dispose()
  End Sub

  Private Sub CopyImageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyImageToolStripMenuItem.Click
    Dim pic As PictureBox = cmsPicBox.Tag
    Clipboard.Clear()
    Clipboard.SetImage(pic.BackgroundImage)
  End Sub

  Private Sub OpenImageInMainWindowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenImageInMainWindowToolStripMenuItem.Click
    Dim pic As PictureBox = cmsPicBox.Tag
    loadImage(pic.BackgroundImage)
  End Sub
End Class