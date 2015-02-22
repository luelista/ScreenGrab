Option Explicit On

Public Interface ICommonUploader
  Sub initializeOptions(ByVal optionsPanel As IUploadOptionsPanel)
  Function runUpload(ByVal progressReceiver As IUploadOptionsPanel) As Boolean
  Function getErrorMessage() As String
  Sub setSourceFile(ByVal fileSpec As String)
  Sub runResultGui()

End Interface
Public Interface IUploadOptionsPanel
  Function getPanel() As Control
  Sub addTextbox(ByVal name As String, ByVal label As String, ByVal defaultValue As String)
  Sub addCombobox(ByVal name As String, ByVal label As String, ByVal options() As String)
  Function getValue(ByVal name As String) As String
  Sub reportProgress(ByVal percentage As Integer)

End Interface
Public MustInherit Class AbstractUploader
  Implements ICommonUploader

  Protected errorMsg As String
  Protected sourceFilespec As String

  Public Function getErrorMessage() As String Implements ICommonUploader.getErrorMessage
    Return errorMsg
  End Function
  Public Sub setSourceFile(ByVal fileSpec As String) Implements ICommonUploader.setSourceFile
    sourceFilespec = fileSpec
  End Sub

  Public MustOverride Sub initializeOptions(ByVal optionsPanel As IUploadOptionsPanel) Implements ICommonUploader.initializeOptions
  Public MustOverride Sub runResultGui() Implements ICommonUploader.runResultGui
  Public MustOverride Function runUpload(ByVal progressReceiver As IUploadOptionsPanel) As Boolean Implements ICommonUploader.runUpload


End Class