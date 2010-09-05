<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TeamWikiFileStoreFTV
  Inherits TreeView

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TeamWikiFileStoreFTV))
    Me.imlSmallIcons = New System.Windows.Forms.ImageList(Me.components)
    Me.SuspendLayout()
    '
    'imlSmallIcons
    '
    Me.imlSmallIcons.ImageStream = CType(resources.GetObject("imlSmallIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.imlSmallIcons.TransparentColor = System.Drawing.Color.Transparent
    Me.imlSmallIcons.Images.SetKeyName(0, "fldclose")
    Me.imlSmallIcons.Images.SetKeyName(1, "fldopen")
    Me.imlSmallIcons.Images.SetKeyName(2, "ID_TEAM")
    Me.imlSmallIcons.Images.SetKeyName(3, "ID_USER")
    Me.imlSmallIcons.Images.SetKeyName(4, "ID_WEBSPACE")
    Me.imlSmallIcons.Images.SetKeyName(5, "ID_SHARED_DOCS")
    Me.imlSmallIcons.Images.SetKeyName(6, "ID_PRIVATE_DOCS")
    '
    'TeamWikiFileStoreFTV
    '
    Me.ImageIndex = 0
    Me.ImageList = Me.imlSmallIcons
    Me.LineColor = System.Drawing.Color.Black
    Me.SelectedImageIndex = 0
    Me.StateImageList = Me.imlSmallIcons
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents imlSmallIcons As System.Windows.Forms.ImageList

End Class
