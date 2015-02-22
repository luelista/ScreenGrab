Imports System.Web

Public Class frm_commonUpload
  Implements IUploadOptionsPanel

  Public sourceFilespec As String

  Dim WithEvents bwUpload As New System.ComponentModel.BackgroundWorker

  Dim uploader As ICommonUploader
  Dim fileSize As Integer

#Region "Common"

  Private Sub frm_dropmeUpload_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    bwUpload.WorkerReportsProgress = True
    bwUpload.WorkerSupportsCancellation = True

    cmbSelectUploadTarget.Items.Add(New UploadMediacrush())
    cmbSelectUploadTarget.Items.Add(New UploadDropme())
    cmbSelectUploadTarget.Items.Add(New UploadWebDAV())
    cmbSelectUploadTarget.Items.Add(New UploadImgur())
    cmbSelectUploadTarget.Items.Add(New UploadImageshack())

    cmbSelectUploadTarget.SelectedIndex = glob.para("frm_dropmeUpload__uploadTarget", "0")
  End Sub

  Private Sub cmbSelectUploadTarget_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSelectUploadTarget.SelectedIndexChanged
    onTargetSelected()
  End Sub

  Sub onTargetSelected()
    Dim obj As Object = cmbSelectUploadTarget.SelectedItem
    If obj IsNot Nothing AndAlso TypeOf obj Is ICommonUploader Then
      uploader = obj
      pnlOptions.Show()

      Me.clearOptionsPanel()
      uploader.initializeOptions(Me)

      pnlOptions.Height = optionsCtrlY
      btnUpload.Enabled = True
    Else
      pnlOptions.Hide()
      btnUpload.Enabled = False
    End If

    Dim deltaY = Me.Height - Me.ClientSize.Height
    Me.Height = deltaY + If(pnlOptions.Visible, pnlOptions.Height, 0) + pnlOptions.Top + pnlButtons.Height
    
    glob.para("frm_dropmeUpload__uploadTarget") = cmbSelectUploadTarget.SelectedIndex
  End Sub

#End Region





  Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
    pbProgress.Show()

    pnlButtons.Enabled = False : cmbSelectUploadTarget.Enabled = False
    pnlOptions.Enabled = False

    fileSize = FileLen(sourceFilespec)

    fetchOptionValues()
    bwUpload.RunWorkerAsync()
  End Sub

  Private Sub bwUpload_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwUpload.DoWork
    Dim ok As Boolean
    uploader.setSourceFile(sourceFilespec)
    ok = uploader.runUpload(Me)
    e.Result = ok
  End Sub

  Private Sub bwUpload_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bwUpload.ProgressChanged
    pbProgress.Value = e.ProgressPercentage / fileSize * 100
  End Sub

  Private Sub bwUpload_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwUpload.RunWorkerCompleted
    If e.Result = False Then
      MsgBox(uploader.getErrorMessage(), MsgBoxStyle.Critical)
      pnlButtons.Enabled = True : cmbSelectUploadTarget.Enabled = True
    Else
      uploader.runResultGui()
      Close()
    End If
  End Sub




  Private Sub clearOptionsPanel()
    pnlOptions.Controls.Clear()
    optionsCtrlY = 1
  End Sub

  Dim optionValues As New Hashtable
  Dim optionsCtrlY As Integer
  Private Sub addControlLabel(ByVal label As String)
    Dim l As New Label
    l.Text = label : l.TextAlign = ContentAlignment.MiddleRight
    l.Top = optionsCtrlY : l.Left = 10 : l.Width = 150 : l.Height = 20
    l.BackColor = Color.BurlyWood
    pnlOptions.Controls.Add(l)
  End Sub

  Public Sub addCombobox(ByVal name As String, ByVal label As String, ByVal options() As String) Implements IUploadOptionsPanel.addCombobox
    addControlLabel(label)
    Dim c As New ComboBox() : c.Name = "field_" + name
    c.Items.AddRange(options)
    c.Top = optionsCtrlY : c.Left = 170 : c.Width = 360
    If c.Items.Count > 0 Then c.SelectedIndex = 0

    optionsCtrlY += 30
    pnlOptions.Controls.Add(c)
  End Sub

  Public Sub addTextbox(ByVal name As String, ByVal label As String, ByVal defaultValue As String) Implements IUploadOptionsPanel.addTextbox
    addControlLabel(label)
    Dim c As New TextBox() : c.Name = "field_" + name
    c.Text = defaultValue
    c.Top = optionsCtrlY : c.Left = 170 : c.Width = 360
    optionsCtrlY += 30
    pnlOptions.Controls.Add(c)
  End Sub

  Public Function getPanel() As System.Windows.Forms.Control Implements IUploadOptionsPanel.getPanel
    Return pnlOptions
  End Function

  Public Sub reportProgress(ByVal percentage As Integer) Implements IUploadOptionsPanel.reportProgress
    bwUpload.ReportProgress(percentage)
  End Sub

  Private Sub fetchOptionValues()
    optionValues.Clear()
    For Each ctrl As Control In pnlOptions.Controls
      If ctrl.Name.StartsWith("field_") Then optionValues(ctrl.Name) = ctrl.Text
    Next
  End Sub
  Public Function getValue(ByVal name As String) As String Implements IUploadOptionsPanel.getValue
    Return optionValues("field_" + name)
  End Function

  Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
    Close()
  End Sub
End Class