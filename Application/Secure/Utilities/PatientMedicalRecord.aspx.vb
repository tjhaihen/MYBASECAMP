Option Strict On
Option Explicit On

Imports System
Imports System.Text
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Collections.Generic
Imports System.IO
Imports Microsoft.VisualBasic

Imports System.Data.SqlTypes

Imports QIS.Common

Namespace QIS.Web.Secure

    Public Class PatientMedicalRecord
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
        Private MenuID As String = Common.Constants.MenuID.ProjectGroup_MenuID
#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Me.IsPostBack Then
            Else
                DataBind()
            End If
        End Sub

        Private Sub txtMRN_TextChanged(sender As Object, e As System.EventArgs) Handles txtMRN.TextChanged
            GetPatientData()
            UpdateViewGridPatientDocument()
        End Sub

        Private Sub btnUpload_Click(sender As Object, e As System.EventArgs) Handles btnUpload.Click
            UploadPatientDocument()
        End Sub

        Private Sub grdPatientDocument_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPatientDocument.ItemCommand
            Select Case e.CommandName
                Case "Delete"
                    Dim _lblFileID As Label = CType(e.Item.FindControl("_lblFileID"), Label)
                    Dim _lblFileName As Label = CType(e.Item.FindControl("_lblFileName"), Label)
                    Dim strFileDir As String = String.Empty
                    Dim oCC As New Common.BussinessRules.CommonCode
                    oCC.GroupCode = Common.Constants.GroupCode.FileDirectory_SCode
                    oCC.Code = Common.Constants.FileDirectoryType.FileDirectory_PatientDocuments

                    If oCC.SelectOne.Rows.Count > 0 Then
                        strFileDir = oCC.Value.Trim + "\" + txtMRN.Text.Trim + "\" + _lblFileName.Text.Trim
                    Else
                        oCC.Dispose()
                        oCC = Nothing
                        commonFunction.MsgBox(Me, Common.Constants.MessageBoxText.Validate_CommonCodeNotFound)
                        Exit Sub
                    End If
                    oCC.Dispose()
                    oCC = Nothing

                    DeletePatientDocument(_lblFileID.Text.Trim, strFileDir.Trim)                    
            End Select
        End Sub
#End Region

#Region " Support functions for navigation bar (Controls) "

#End Region

#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
        End Function

        Private Sub PrepareScreenPatientDocument()
            txtFileID.Text = String.Empty
            txtFileName.Text = String.Empty
            txtFileDescription.Text = String.Empty
        End Sub

        Private Sub UpdateViewGridPatientDocument()
            Dim oBR As New Common.BussinessRules.PatientDocument
            With oBR
                .MRN = txtMRN.Text.Trim
                grdPatientDocument.DataSource = .GetPatientDocumentByMRN()
                grdPatientDocument.DataBind()
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub
#End Region

#Region " C,R,U,D "
        Private Sub GetPatientData()
            Dim oBR As New Common.BussinessRules.Patient
            With oBR
                .MRN = txtMRN.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    txtPatientName.Text = .patientName.Trim
                    lblPlaceOfBirth.Text = .placeOfBirth.Trim
                    lblDateOfBirth.Text = Format(.dateOfBirth, "dd-MMM-yyyy")
                    lblAddress.Text = .address.Trim
                Else
                    txtPatientName.Text = String.Empty
                    lblPlaceOfBirth.Text = String.Empty
                    lblDateOfBirth.Text = Format(Date.Today, "dd-MMM-yyyy")
                    lblAddress.Text = String.Empty
                    commonFunction.MsgBox(Me, "Nomor Rekam Medis tidak terdaftar dalam database Pasien.")
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub UploadPatientDocument()
            If txtMRN.Text.Trim.Length = 0 Then Exit Sub

            If txtFileUrl.Value.Trim.Length > 0 Then
                Dim fileExt As String, fileName As String, dirName As String
                Dim oCC As New Common.BussinessRules.CommonCode
                Dim br As New Common.BussinessRules.PatientDocument
                With br
                    fileExt = Path.GetExtension(txtFileUrl.Value.Trim)
                    fileName = IIf(txtFileName.Text.Trim.Length > 0, txtFileName.Text.Trim + fileExt.Trim, Path.GetFileName(txtFileUrl.Value.Trim)).ToString.Trim
                    Dim fNotNew As Boolean = False, fAllowSave As Boolean = False
                    Dim nmFile As String
                    Try
                        .MRN = txtMRN.Text.Trim
                        .fileName = fileName.Trim
                        .fileExtension = fileExt.Trim
                        .fileDescription = txtFileDescription.Text.Trim
                        .uploadBy = MyBase.LoggedOnUserID.Trim

                        oCC.GroupCode = Common.Constants.GroupCode.FileDirectory_SCode
                        oCC.Code = Common.Constants.FileDirectoryType.FileDirectory_PatientDocuments

                        '// validate if the file exist
                        If oCC.SelectOne.Rows.Count > 0 Then
                            dirName = oCC.Value.Trim + txtMRN.Text.Trim
                            nmFile = dirName + "\" + fileName
                        Else
                            oCC.Dispose()
                            oCC = Nothing
                            fAllowSave = False
                            commonFunction.MsgBox(Me, Common.Constants.MessageBoxText.Validate_CommonCodeNotFound)
                            Exit Sub
                        End If
                        oCC.Dispose()
                        oCC = Nothing

                        If txtFileUrl.Value.Trim.Length > 0 Then
                            If File.Exists(nmFile) Then
                                fAllowSave = False
                                commonFunction.MsgBox(Me, Common.Constants.MessageBoxText.Validate_FileNameAlreadyExist)
                                Exit Sub
                            Else
                                fAllowSave = True
                                If Not Directory.Exists(dirName) Then
                                    Directory.CreateDirectory(dirName)
                                End If
                                txtFileUrl.PostedFile.SaveAs(nmFile)
                            End If

                            If fAllowSave Then
                                If .Insert() Then
                                    PrepareScreenPatientDocument()
                                    UpdateViewGridPatientDocument()
                                End If
                            End If
                        End If
                    Catch ex As Exception
                        commonFunction.MsgBox(Me, "Upload file failed.")
                        Exit Sub
                    End Try
                End With
            Else
                commonFunction.MsgBox(Me, "No file choosen.")
                Exit Sub
            End If
        End Sub

        Private Sub DeletePatientDocument(ByVal strFileID As String, ByVal strFileDir As String)
            Dim oFile As New Common.BussinessRules.PatientDocument
            With oFile
                .fileID = CInt(strFileID.Trim)
                If .Delete() Then
                    File.Delete(strFileDir)
                    UpdateViewGridPatientDocument()
                End If
            End With
            oFile.Dispose()
            oFile = Nothing
        End Sub
#End Region

    End Class

End Namespace