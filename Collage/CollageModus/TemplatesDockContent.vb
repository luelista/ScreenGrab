Imports ScreenGrab6.Vector

Public Class TemplatesDockContent

  Dim templateFolder As String = "C:\yPara\ScreenGrab5\Collagetemplates\"

  Private Sub TemplatesDockContent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    IO.Directory.CreateDirectory(templateFolder)
    loadtemplateList()
  End Sub
  Sub loadtemplateList()
    Dim templateFolder As String = "C:\yPara\ScreenGrab5\Collagetemplates\"
    IO.Directory.CreateDirectory(templateFolder)

    Dim files() = IO.Directory.GetFiles(templateFolder, "*.html")
    ImageList2.Images.Clear()
    lvTemplates.Items.Clear()
    For Each filespec In files
      Dim lvi = lvTemplates.Items.Add(IO.Path.GetFileNameWithoutExtension(filespec))
      lvi.Tag = filespec
      ImageList2.Images.Add(Helper.extractThumbnail(filespec))
      lvi.ImageIndex = ImageList2.Images.Count - 1
    Next
  End Sub

  Private Sub btnTemplateAddSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTemplateAddSel.Click
    If Program.vcc.canvas.SelectionCount <> 1 OrElse Not (TypeOf Program.vcc().canvas.GetFirstSelectedObject Is VGroup) Then
      MsgBox("Bitte stellen Sie sicher, dass eine Objektgruppe selektiert ist.", MsgBoxStyle.Critical, "Templateerstellung fehlgeschlagen")
      Exit Sub
    End If

    Program.vcc.canvas.CopySelection()
    Dim cvs As New Canvas()
    cvs.PicBox = New PictureBox
    cvs.Paste()
    Dim o = cvs.GetFirstSelectedObject
    o.Top = 0 : o.Left = 0
    cvs.PicBox.Width = o.Width : cvs.PicBox.Height = o.Height
    cvs.createHtmlPage(templateFolder + Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".html")
    loadtemplateList()
  End Sub

  Private Sub lvTemplates_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles lvTemplates.ItemDrag

    Dim filespec() As String = New String() {e.Item.tag}
    Dim d As New DataObject("FileDrop", filespec)
    lvTemplates.DoDragDrop(d, DragDropEffects.Copy)
  End Sub

  Private Sub llSidebar5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    loadtemplateList()
  End Sub

End Class