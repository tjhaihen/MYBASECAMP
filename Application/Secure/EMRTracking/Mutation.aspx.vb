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
Imports Microsoft.VisualBasic
Imports System.Data.SqlTypes

Imports QIS.Common

Namespace QIS.Web.EMRTracking

    Public Class Mutation
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
#End Region


#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Me.IsPostBack Then
            Else
                prepareScreen(True)
                DataBind()
            End If
        End Sub

        Private Sub ibtnLockUnlock_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtnLockUnlock.Click
            chkIsLock.Checked = Not chkIsLock.Checked
            If chkIsLock.Checked Then
                ibtnLockUnlock.ImageUrl = "/qistoollib/images/big_lock.png"
                ddlEMRLocation.Enabled = False
            Else
                ibtnLockUnlock.ImageUrl = "/qistoollib/images/big_unlock.png"
                ddlEMRLocation.Enabled = True
            End If            
        End Sub

        Private Sub txtMedicalNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMedicalNo.TextChanged
            _openPatientData(txtMedicalNo.Text.Trim, False)
        End Sub

        Private Sub btnGetData_Click(sender As Object, e As System.EventArgs) Handles btnGetData.Click
            _openPatientData(txtMedicalNo.Text.Trim, False)
        End Sub

        Private Sub btnAccept_Click(sender As Object, e As System.EventArgs) Handles btnAccept.Click
            _insertupdate()
        End Sub
#End Region


#Region " Support functions for navigation bar (Controls) "
        
#End Region


#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
        End Function

        Private Sub prepareScreen(ByVal isNew As Boolean)
            prepareDDL()
            chkIsLock.Checked = False
            ibtnLockUnlock.ImageUrl = "/qistoollib/images/big_unlock.png"
            lblStatus.Text = String.Empty
            txtRemarks.Text = "Tracking Berkas Rekam Medik"
            commonFunction.Focus(Me, txtMedicalNo.ClientID)

            If Common.Methods.GetCommonCode(Common.Constants.Tracking.Tracking_IN, Common.Constants.GroupCode.Tracking_SCode).Trim = "1" Then
                ddlProcessType.SelectedValue = "IN"
                ddlProcessType.Enabled = False
            Else
                ddlProcessType.Enabled = True
            End If
        End Sub

        Private Sub prepareDDL()
            commonFunction.SetDDL_Table(ddlEMRLocation, "EMRLocation", String.Empty)
        End Sub

        Private Function validateMutation() As Boolean
            Dim bolValid As Boolean = True
            If Common.Methods.GetCommonCode(Common.Constants.Tracking.Tracking_IN, Common.Constants.GroupCode.Tracking_SCode).Trim = "1" Then
                bolValid = True
            Else
                Dim oBR As New Common.BussinessRules.EMRTrackingHistory
                oBR.MedicalNo = txtMedicalNo.Text.Trim
                If oBR.SelectByMedicalNo(True).Rows.Count > 0 Then
                    If oBR.ProcessType = "OUT" And ddlProcessType.SelectedValue.Trim = "OUT" Then
                        commonFunction.MsgBox(Me, "Status Berkas sekarang adalah [OUT]. Silahkan pilih jenis proses [IN - Terima Berkas].")
                        bolValid = False
                    End If

                    If oBR.ProcessType = "IN" And ddlProcessType.SelectedValue.Trim = "IN" Then
                        commonFunction.MsgBox(Me, "Status Berkas sekarang adalah [IN]. Silahkan pilih jenis proses [OUT - Kirim Berkas].")
                        bolValid = False
                    End If

                    If oBR.ProcessType = "IN" And ddlProcessType.SelectedValue.Trim = "OUT" And oBR.LocationCode.Trim <> ddlEMRLocation.SelectedValue.Trim Then
                        commonFunction.MsgBox(Me, "Status Berkas sekarang belum diproses [OUT] dari lokasi: " + oBR.LocationName.Trim + ".")
                        bolValid = False
                    End If
                Else
                    bolValid = True
                End If
                oBR.Dispose()
                oBR = Nothing
            End If
            
            Return bolValid
        End Function
#End Region


#Region " C,R,U,D "
        Private Sub _openPatientData(ByVal strMedicalNo As String, ByVal isFromInsert As Boolean)
            Dim strFormattedMRN As String = String.Empty
            strFormattedMRN = Right("00000000" + strMedicalNo.Replace("-", "").Trim, 8).Trim
            strFormattedMRN = Left(strFormattedMRN, 2) + "-" + Mid(strFormattedMRN, 3, 2) + "-" + Mid(strFormattedMRN, 5, 2) + "-" + Right(strFormattedMRN, 2)
            txtMedicalNo.Text = strFormattedMRN

            Dim oBR As New Common.BussinessRules.EMRTrackingHistory
            With oBR
                .MedicalNo = txtMedicalNo.Text.Trim
                If .SelectPatientData.Rows.Count > 0 Then
                    lblMedicalNo.Text = .MedicalNo.Trim
                    lblPatientName.Text = .PatientName.Trim
                    lblSex.Text = .Sex.Trim
                    lblDOB.Text = .cfDateOfBirth.Trim
                    lblStreetName.Text = .streetName.Trim
                    lblCity.Text = .city.Trim
                    lblReligion.Text = .religion.Trim
                    lblBloodType.Text = .bloodType.Trim
                    lblBloodRhesus.Text = .bloodRhesus.Trim
                    txtCurrentLocationName.Text = .CurrentLocationName.Trim
                    lblUserNameProcess.Text = .UserNameProcess.Trim
                    lblCurrentLocationNameProcess.Text = .CurrentLocationName.Trim
                Else
                    commonFunction.MsgBox(Me, "Data Rekam Medis tidak terdaftar.")
                    lblMedicalNo.Text = String.Empty
                    txtMedicalNo.Text = String.Empty
                    lblPatientName.Text = String.Empty
                    lblSex.Text = String.Empty
                    lblDOB.Text = String.Empty
                    lblStreetName.Text = String.Empty
                    lblCity.Text = String.Empty
                    lblReligion.Text = String.Empty
                    lblBloodType.Text = String.Empty
                    lblBloodRhesus.Text = String.Empty
                    txtCurrentLocationName.Text = String.Empty
                    lblUserNameProcess.Text = String.Empty
                    lblStatus.Text = String.Empty
                    lblCurrentLocationNameProcess.Text = String.Empty
                End If
            End With
            oBR.Dispose()
            oBR = Nothing

            If isFromInsert Then
                txtMedicalNo.Text = String.Empty
                txtCurrentLocationName.Text = String.Empty
            End If           
            commonFunction.Focus(Me, txtMedicalNo.ClientID)
        End Sub

        Private Sub _insertupdate()
            If validateMutation() = True Then
                Dim oBR As New Common.BussinessRules.EMRTrackingHistory
                With oBR
                    .MedicalNo = txtMedicalNo.Text.Trim
                    .RegistrationID = Nothing
                    .LocationCode = ddlEMRLocation.SelectedValue.Trim
                    .Remarks = txtRemarks.Text.Trim
                    .ProcessType = ddlProcessType.SelectedValue.Trim
                    .UserIDProcess = MyBase.LoggedOnUserID.Trim
                    If Common.Methods.GetCommonCode(Common.Constants.Tracking.Tracking_IN, Common.Constants.GroupCode.Tracking_SCode).Trim = "1" Then
                        If .Insert() Then
                            If ddlProcessType.SelectedValue.Trim = "OUT" Then
                                lblStatus.Text = "Berkas Dikirim"
                            Else
                                lblStatus.Text = "Berkas Diterima"
                            End If
                        End If
                    Else
                        If .InsertByProcessType() Then
                            If ddlProcessType.SelectedValue.Trim = "OUT" Then
                                lblStatus.Text = "Berkas Dikirim"
                            Else
                                lblStatus.Text = "Berkas Diterima"
                            End If
                        End If
                    End If
                End With
                oBR.Dispose()
                oBR = Nothing
                _openPatientData(txtMedicalNo.Text.Trim, True)
            End If            
        End Sub
#End Region

    End Class

End Namespace