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
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Math
Imports System.IO
Imports Microsoft.VisualBasic


Imports System.Data.SqlTypes

Namespace QIS.Web.EMR
    Public Class Main
        Inherits PageBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Me.IsPostBack Then
                ReadQueryString()

                txtLinkParamedicID.Text = MyBase.LoggedOnLinkParamedicID
                chkIsPhysician.Checked = IsUserPhysician(MyBase.LoggedOnUserID)

                PrepareScreen()
            End If
        End Sub

        Private Sub grdTodayPatient_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdTodayPatient.ItemCommand
            Select Case e.CommandName
                Case "GetRegistration"
                    Dim _lbtnRegistrationNo As LinkButton = CType(e.Item.FindControl("_lbtnRegistrationNo"), LinkButton)
                    Dim _lblTransactionNo As Label = CType(e.Item.FindControl("_lblTransactionNo"), Label)
                    lblPBRegistrationNo.Text = _lbtnRegistrationNo.Text.Trim
                    lblPBTransactionNo.Text = _lblTransactionNo.Text.Trim
                    OpenRegistration(ddlDepartmentFilter.SelectedValue.Trim, lblPBRegistrationNo.Text.Trim, lblPBTransactionNo.Text.Trim)
            End Select
        End Sub

        Private Sub grdPatientResume_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPatientResume.ItemCommand
            Select Case e.CommandName
                Case "Revise"
                    Dim _lblID As Label = CType(e.Item.FindControl("_lblID"), Label)
                    Dim _lblTherapyHISOrderStatus As Label = CType(e.Item.FindControl("_lblTherapyHISOrderStatus"), Label)
                    Dim _lblTherapyHISOrderNo As Label = CType(e.Item.FindControl("_lblTherapyHISOrderNo"), Label)
                    txtID.Text = _lblID.Text.Trim
                    OpenPatientResume(CInt(txtID.Text))
                    lblTherapyHISOrderNo.Text = _lblTherapyHISOrderNo.Text.Trim
                    If _lblTherapyHISOrderStatus.Text.Trim = "Realisasi" Then
                        chkIsRealized.Checked = True
                        txtTherapyText.Enabled = False
                        chkIsCreateOrder.Checked = False
                        chkIsCreateOrder.Enabled = False
                    Else
                        chkIsRealized.Checked = False
                        txtTherapyText.Enabled = True
                        chkIsCreateOrder.Checked = True
                        chkIsCreateOrder.Enabled = True
                    End If
            End Select
        End Sub

        Private Sub grdPatientInterventionEvaluation_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPatientInterventionEvaluation.ItemCommand
            Select Case e.CommandName
                Case "Revise"
                    Dim _lblID As Label = CType(e.Item.FindControl("_lblID"), Label)
                    txtIDIE.Text = _lblID.Text.Trim
                    OpenPatientIntervention(CInt(txtIDIE.Text))
            End Select
        End Sub

        Private Sub lbtnBack_Click(sender As Object, e As System.EventArgs) Handles lbtnBack.Click
            PrepareScreenPatientResume()
            pnlPatientList.Visible = True
            pnlPatientRecord.Visible = False
            UpdateViewGridTodayPatient(String.Empty)
        End Sub

        Private Sub lbtnNewSOAP_Click(sender As Object, e As System.EventArgs) Handles lbtnNewSOAP.Click
            PrepareScreenPatientResume()
            commonFunction.Focus(Me, txtMainDiagnosisText.ClientID)
        End Sub

        Private Sub lbtnSaveSOAP_Click(sender As Object, e As System.EventArgs) Handles lbtnSaveSOAP.Click
            If txtID.Text.Trim = String.Empty Or IsNumeric(txtID.Text.Trim) = False Then
                InsertPatientResume()
                PrepareScreenPatientResume()
            Else
                UpdatePatientResume()
                PrepareScreenPatientResume()
            End If            
        End Sub

        Private Sub lbtnDischarge_Click(sender As Object, e As System.EventArgs) Handles lbtnDischarge.Click
            If txtMainDiagnosisText.Text.Trim = String.Empty Then
                commonFunction.MsgBox(Me, "Diagnosa Utama harus diisi.")
                Exit Sub
            End If

            If txtID.Text.Trim = String.Empty Or IsNumeric(txtID.Text.Trim) = False Then
                InsertPatientResume()
            Else
                UpdatePatientResume()
            End If

            UpdatePatientDischarge()
            PrepareScreenPatientResume()
            pnlPatientList.Visible = True
            pnlPatientRecord.Visible = False
            UpdateViewGridTodayPatient(String.Empty)
        End Sub

        Private Sub lbtnBackIE_Click(sender As Object, e As System.EventArgs) Handles lbtnBackIE.Click
            PrepareScreenPatientIntervention()
            pnlPatientList.Visible = True
            pnlPatientRecord.Visible = False
            UpdateViewGridTodayPatient(String.Empty)
        End Sub

        Private Sub lbtnNewIE_Click(sender As Object, e As System.EventArgs) Handles lbtnNewIE.Click
            PrepareScreenPatientIntervention()
            commonFunction.Focus(Me, txtComplainTextIE.ClientID)
        End Sub

        Private Sub lbtnSaveIE_Click(sender As Object, e As System.EventArgs) Handles lbtnSaveIE.Click
            If txtIDIE.Text.Trim = String.Empty Or IsNumeric(txtIDIE.Text.Trim) = False Then
                InsertPatientIntervention()
                PrepareScreenPatientIntervention()
            Else
                UpdatePatientIntervention()
                PrepareScreenPatientIntervention()
            End If            
        End Sub

        Private Sub btnSearchPatient_Click(sender As Object, e As System.EventArgs) Handles btnSearchPatient.Click
            UpdateViewGridTodayPatient(txtSearchPatient.Text.Trim)
        End Sub

        Private Sub btnShowHistory_Click(sender As Object, e As System.EventArgs) Handles btnShowHistory.Click
            OpenPatientHistory(txtMedicalNoHistory.Text.Trim)
        End Sub
#End Region

#Region " Support functions for navigation bar (Controls) "

#End Region

#Region " Private Functions "
        Private Function ReadQueryString() As Boolean

        End Function

        Private Sub PrepareScreen()
            txtTodayDate.Text = Format(Date.Today, commonFunction.FORMAT_DATE)
            pnlPhysicianOnly.Visible = chkIsPhysician.Checked
            pnlPatientList.Visible = True
            pnlPatientRecord.Visible = False
            txtSearchPatient.Text = String.Empty
            UpdateViewGridTodayPatient(String.Empty)
            PrepareScreenDashboard()

            chkIsCreateOrder.Checked = True
            chkIsRealized.Checked = False
            lblTherapyHISOrderNo.Text = String.Empty

            pnlInfoForPhysician.Visible = chkIsPhysician.Checked
            pnlPatientIntervention.Visible = Not chkIsPhysician.Checked
        End Sub

        Private Sub PrepareScreenPatientResume()
            txtID.Text = String.Empty
            txtChiefComplaint.Text = String.Empty
            txtHistoryOfPresentIllness.Text = String.Empty
            txtMainDiagnosisText.Text = String.Empty
            txtSecondaryDiagnosisText.Text = String.Empty
            txtProcedureText.Text = String.Empty
            txtTherapyText.Text = String.Empty
            txtTherapyStopDate.Text = String.Empty
            txtNotes.Text = String.Empty
            UpdateViewGridPatientResume()
            UpdateViewGridPatientDocument()

            chkIsCreateOrder.Checked = True
            chkIsRealized.Checked = False
            lblTherapyHISOrderNo.Text = String.Empty
        End Sub

        Private Sub PrepareScreenPatientIntervention()
            txtIDIE.Text = String.Empty
            txtComplainTextIE.Text = String.Empty
            txtInterventionTextIE.Text = String.Empty
            txtEvaluationTextIE.Text = String.Empty
            UpdateViewGridPatientIntervention()
        End Sub

        Private Sub PrepareScreenPatientHistory()
            txtMedicalNoHistory.Text = String.Empty
            UpdateViewGridPatientResumeHistoryMR()
        End Sub

        Private Sub PrepareScreenDashboard()
            Dim dt As New DataTable
            Dim oBR As New Common.BussinessRules.EMR
            With oBR
                .PhysicianID = txtLinkParamedicID.Text.Trim
                .DepartmentID = "OUTPATIENT"
                If chkIsPhysician.Checked Then
                    dt = .GetPatientPhysicianIDToday(String.Empty)
                Else
                    dt = .GetPatientToday(String.Empty)
                End If
                lblTotalPasienRawatJalan.Text = dt.Rows.Count.ToString.Trim

                .DepartmentID = "EMERGENCY"
                If chkIsPhysician.Checked Then
                    dt = .GetPatientPhysicianIDToday(String.Empty)
                Else
                    dt = .GetPatientToday(String.Empty)
                End If
                lblTotalPasienIGD.Text = dt.Rows.Count.ToString.Trim

                .DepartmentID = "INPATIENT"
                If chkIsPhysician.Checked Then
                    dt = .GetPatientPhysicianIDToday(String.Empty)
                Else
                    dt = .GetPatientToday(String.Empty)
                End If
                lblTotalPasienRawatInap.Text = dt.Rows.Count.ToString.Trim
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub UpdateViewGridTodayPatient(ByVal strSearch As String)
            Dim dt As New DataTable
            Dim oBR As New Common.BussinessRules.EMR
            With oBR
                .DepartmentID = ddlDepartmentFilter.SelectedValue.Trim
                .PhysicianID = txtLinkParamedicID.Text.Trim

                If chkIsPhysician.Checked Then
                    dt = .GetPatientPhysicianIDToday(strSearch)
                Else
                    dt = .GetPatientToday(strSearch)
                End If

                grdTodayPatient.DataSource = dt
                grdTodayPatient.DataBind()
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub UpdateViewGridPatientResume()
            Dim oBR As New Common.BussinessRules.EMR
            With oBR
                .MRN = lblPBMRN.Text.Trim
                grdPatientResume.DataSource = .GetPatientResumeByMRN()
                grdPatientResume.DataBind()
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub UpdateViewGridPatientResumeHistoryMR()
            Dim oBR As New Common.BussinessRules.EMR
            With oBR
                .MRN = txtMedicalNoHistory.Text.Trim
                grdPatientResumeHistoryMR.DataSource = .GetPatientResumeByMRN()
                grdPatientResumeHistoryMR.DataBind()
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub UpdateViewGridPatientIntervention()
            Dim oBR As New Common.BussinessRules.EMR
            With oBR
                .MRN = lblPBMRN.Text.Trim
                grdPatientInterventionEvaluation.DataSource = .GetPatientInterventionByMRN()
                grdPatientInterventionEvaluation.DataBind()
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub UpdateViewGridPatientDocument()
            Dim oBR As New Common.BussinessRules.PatientDocument
            With oBR
                .MRN = lblPBMRN.Text.Trim
                grdPatientDocument.DataSource = .GetPatientDocumentByMRN()
                grdPatientDocument.DataBind()
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub UpdateViewGridCatatanMedis()
            Dim oBR As New Common.BussinessRules.EMR
            With oBR
                .RegistrationNo = lblPBRegistrationNo.Text.Trim
                grdCatatanMedis.DataSource = .GetPatientResumeByRegistrationNo()
                grdCatatanMedis.DataBind()
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub UpdateViewGridCatatanPerawat()
            Dim oBR As New Common.BussinessRules.NurseAssesment
            With oBR
                .RegistrationNo = lblPBRegistrationNo.Text.Trim
                grdCatatanPerawat.DataSource = .GetNurseAssesmentByRegistrationNo()
                grdCatatanPerawat.DataBind()
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub
#End Region

#Region " C,R,U,D "
        Private Function IsUserPhysician(ByVal strUserID As String) As Boolean
            Dim bolIsPhysician As Boolean = False
            Dim oBR As New Common.BussinessRules.User
            With oBR
                .UserID = strUserID.Trim
                If .SelectOne.Rows.Count > 0 Then
                    bolIsPhysician = .isPhysician
                Else
                    bolIsPhysician = False
                End If
            End With
            oBR.Dispose()
            oBR = Nothing

            Return bolIsPhysician
        End Function

        Private Sub OpenRegistration(ByVal DepartmentID As String, ByVal RegistrationNo As String, ByVal TransactionNo As String)
            Dim oBR As New Common.BussinessRules.EMR
            With oBR
                .DepartmentID = DepartmentID.Trim
                .RegistrationNo = RegistrationNo.Trim
                .TransactionNo = TransactionNo.Trim
                If .GetRegistration.Rows.Count > 0 Then
                    pnlPatientList.Visible = False
                    pnlPatientRecord.Visible = True
                    lblPBMRN.Text = .MRN.Trim
                    lblPBPatientName.Text = .PatientName.Trim
                    lblPBPatientGender.Text = .PatientGender.Trim
                    lblPBPatientDOB.Text = Format(.PatientDOB, commonFunction.FORMAT_DATE)
                    lblPBRegistrationNo.Text = .RegistrationNo.Trim
                    lblPBTransactionNo.Text = .TransactionNo.Trim
                    lblPBRegistrationDate.Text = Format(.RegistrationDate, commonFunction.FORMAT_DATE)
                    lblPBRegistrationTime.Text = .RegistrationTime.Trim
                    lblPBServiceUnitID.Text = .ServiceUnitID.Trim
                    lblPBServiceUnitName.Text = .ServiceUnitName.Trim
                    lblPBBusinessPartnerName.Text = .BusinessPartnerName.Trim
                    chkIsDischarged.Checked = .IsDischarged
                    If lblPBPatientGender.Text = "P" Then
                        imgPBPatient.ImageUrl = "/qistoollib/images/person-female.png"
                    Else
                        imgPBPatient.ImageUrl = "/qistoollib/images/person-male.png"
                    End If
                Else
                    pnlPatientList.Visible = True
                    pnlPatientRecord.Visible = False
                    lblPBMRN.Text = String.Empty
                    lblPBPatientName.Text = String.Empty
                    lblPBPatientGender.Text = String.Empty
                    lblPBPatientDOB.Text = String.Empty
                    lblPBRegistrationNo.Text = String.Empty
                    lblPBTransactionNo.Text = String.Empty
                    lblPBRegistrationDate.Text = String.Empty
                    lblPBRegistrationTime.Text = String.Empty
                    lblPBServiceUnitID.Text = String.Empty
                    lblPBServiceUnitName.Text = String.Empty
                    lblPBBusinessPartnerName.Text = String.Empty
                    chkIsDischarged.Checked = False
                End If
            End With
            oBR.Dispose()
            oBR = Nothing

            PrepareScreenPatientResume()
            PrepareScreenPatientIntervention()

            UpdateViewGridCatatanMedis()
            UpdateViewGridCatatanPerawat()
        End Sub

        Private Sub OpenPatientResume(ByVal ID As Integer)
            Dim oBR As New Common.BussinessRules.EMR
            With oBR
                .ID = ID
                If .GetPatientResumeByID.Rows.Count > 0 Then
                    txtChiefComplaint.Text = .ChiefComplaint.Trim
                    txtHistoryOfPresentIllness.Text = .HistoryOfPresentIllness.Trim
                    txtMainDiagnosisText.Text = .MainDiagnosisText.Trim
                    txtSecondaryDiagnosisText.Text = .SecondaryDiagnosisText.Trim
                    txtProcedureText.Text = .ProcedureText.Trim
                    txtTherapyText.Text = .TherapyText.Trim
                    txtTherapyStopDate.Text = .TherapyStopDate.Trim
                    chkIsDischarged.Checked = .IsDischarged
                    txtNotes.Text = .Notes.Trim
                Else
                    txtID.Text = String.Empty
                    txtChiefComplaint.Text = String.Empty
                    txtHistoryOfPresentIllness.Text = String.Empty
                    txtMainDiagnosisText.Text = String.Empty
                    txtSecondaryDiagnosisText.Text = String.Empty
                    txtProcedureText.Text = String.Empty
                    txtTherapyText.Text = String.Empty
                    txtTherapyStopDate.Text = String.Empty
                    chkIsDischarged.Checked = False
                    txtNotes.Text = String.Empty
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub OpenPatientHistory(ByVal strMRN As String)
            Dim strFormattedMRN As String = String.Empty
            strFormattedMRN = Right("00000000" + strMRN.Replace("-", "").Trim, 8).Trim
            strFormattedMRN = Left(strFormattedMRN, 2) + "-" + Mid(strFormattedMRN, 3, 2) + "-" + Mid(strFormattedMRN, 5, 2) + "-" + Right(strFormattedMRN, 2)
            txtMedicalNoHistory.Text = strFormattedMRN

            Dim oBR As New Common.BussinessRules.Patient
            With oBR
                .MRN = txtMedicalNoHistory.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    lblPBPatientNameHistory.Text = .patientName.Trim
                    lblPBPatientGenderHistory.Text = .gender.Trim
                    lblPBMRNHistory.Text = .MRN.Trim
                    lblPBPatientDOBHistory.Text = Format(.dateOfBirth, commonFunction.FORMAT_DATE)
                    lblPBAddressHistory.Text = .address.Trim
                    If lblPBPatientGenderHistory.Text = "P" Then
                        imgPBPatientHistory.ImageUrl = "/qistoollib/images/person-female.png"
                    Else
                        imgPBPatientHistory.ImageUrl = "/qistoollib/images/person-male.png"
                    End If
                Else
                    lblPBPatientNameHistory.Text = String.Empty
                    lblPBPatientGenderHistory.Text = String.Empty
                    lblPBMRNHistory.Text = String.Empty
                    lblPBPatientDOBHistory.Text = String.Empty
                    lblPBAddressHistory.Text = String.Empty
                    commonFunction.MsgBox(Me, "Nomor Rekam Medis tidak terdaftar. Silahkan masukkan Nomor Rekam Medis yang benar.")
                End If
            End With
            oBR.Dispose()
            oBR = Nothing

            UpdateViewGridPatientResumeHistoryMR()
        End Sub

        Private Sub InsertPatientResume()
            If txtMainDiagnosisText.Text.Trim = String.Empty Then
                commonFunction.MsgBox(Me, "Diagnosa Utama harus diisi.")
                Exit Sub
            End If
            Dim oBR As New Common.BussinessRules.EMR
            With oBR
                .DepartmentID = ddlDepartmentFilter.SelectedValue.Trim
                .ServiceUnitID = lblPBServiceUnitID.Text.Trim
                .RegistrationNo = lblPBRegistrationNo.Text.Trim
                .MRN = lblPBMRN.Text.Trim
                .PhysicianID = txtLinkParamedicID.Text.Trim
                .ChiefComplaint = txtChiefComplaint.Text.Trim
                .HistoryOfPresentIllness = txtHistoryOfPresentIllness.Text.Trim
                .MainDiagnosisText = txtMainDiagnosisText.Text.Trim
                .SecondaryDiagnosisText = txtSecondaryDiagnosisText.Text.Trim
                .ProcedureText = txtProcedureText.Text.Trim
                .TherapyText = txtTherapyText.Text.Trim
                .TherapyStopDate = txtTherapyStopDate.Text.Trim
                .Notes = txtNotes.Text.Trim
                .CreatedBy = MyBase.LoggedOnUserID.Trim
                .LastUpdatedBy = MyBase.LoggedOnUserID.Trim
                .IsDischarged = chkIsDischarged.Checked
                If chkIsCreateOrder.Checked Then
                    .TherapyHISOrderNo = SaveWorklistPrescriptionText().Trim
                Else
                    .TherapyHISOrderNo = String.Empty
                End If
                .Insert()
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub UpdatePatientResume()
            Dim oBR As New Common.BussinessRules.EMR
            With oBR
                .ID = CInt(txtID.Text.Trim)
                .DepartmentID = ddlDepartmentFilter.SelectedValue.Trim
                .ServiceUnitID = lblPBServiceUnitID.Text.Trim
                .RegistrationNo = lblPBRegistrationNo.Text.Trim
                .MRN = lblPBMRN.Text.Trim
                .PhysicianID = txtLinkParamedicID.Text.Trim
                .ChiefComplaint = txtChiefComplaint.Text.Trim
                .HistoryOfPresentIllness = txtHistoryOfPresentIllness.Text.Trim
                .MainDiagnosisText = txtMainDiagnosisText.Text.Trim
                .SecondaryDiagnosisText = txtSecondaryDiagnosisText.Text.Trim
                .ProcedureText = txtProcedureText.Text.Trim
                .TherapyText = txtTherapyText.Text.Trim
                .TherapyStopDate = txtTherapyStopDate.Text.Trim
                .Notes = txtNotes.Text.Trim
                .CreatedBy = MyBase.LoggedOnUserID.Trim
                .LastUpdatedBy = MyBase.LoggedOnUserID.Trim
                .IsDischarged = chkIsDischarged.Checked
                If chkIsCreateOrder.Checked Then
                    If chkIsRealized.Checked = False Then
                        UpdateCancelWorklist()
                    End If
                    .TherapyHISOrderNo = SaveWorklistPrescriptionText().Trim
                Else
                    If chkIsRealized.Checked = True Then
                        .TherapyHISOrderNo = lblTherapyHISOrderNo.Text.Trim
                    Else
                        .TherapyHISOrderNo = String.Empty
                    End If
                End If
                .Update()
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub UpdatePatientDischarge()
            Dim oBR As New Common.BussinessRules.EMR
            With oBR
                .DepartmentID = ddlDepartmentFilter.SelectedValue.Trim
                .ServiceUnitID = lblPBServiceUnitID.Text.Trim
                .RegistrationNo = lblPBRegistrationNo.Text.Trim
                .IsDischarged = True
                .UpdateDischarge()
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Function SaveWorklistPrescriptionText() As String
            Dim strOrderNoToReturn As String = String.Empty

            Me.Validate()
            If Not Me.IsValid Then Exit Function

            Dim oBR As New Common.BussinessRules.Worklist
            With oBR
                '//Header
                strOrderNoToReturn = .NewOrderNo()
                .OrderNo = strOrderNoToReturn.Trim

                .TransactionNo = lblPBTransactionNo.Text.Trim
                .RegistrationNo = lblPBRegistrationNo.Text.Trim
                .MRN = lblPBMRN.Text.Trim
                .ModuleID = "RJ"
                .SupportingUnitID = Common.Methods.GetCommonCode(Common.Constants.SystemSetting.SystemSetting_HISPHUNITID, Common.Constants.GroupCode.System_SCode).Trim
                .ServiceUnitID = lblPBServiceUnitID.Text.Trim
                .ClinicalNotes = String.Empty
                .CreatedBy = MyBase.LoggedOnUserID.Trim
                .LastUpdatedBy = MyBase.LoggedOnUserID.Trim

                '// Detail
                .ItemID = Common.Methods.GetCommonCode(Common.Constants.SystemSetting.SystemSetting_HISPHITEMID, Common.Constants.GroupCode.System_SCode).Trim
                .StatusID = "01" '// Order
                .PrescriptionNotes = txtTherapyText.Text.Trim
                .IsValidate = False

                If .InsertHD() Then
                    .InsertDT()
                End If
            End With

            oBR.Dispose()
            oBR = Nothing

            Return strOrderNoToReturn.Trim
        End Function

        Private Sub UpdateCancelWorklist()
            Dim oBR As New Common.BussinessRules.Worklist
            With oBR
                .OrderNo = lblTherapyHISOrderNo.Text.Trim
                .ItemID = Common.Methods.GetCommonCode(Common.Constants.SystemSetting.SystemSetting_HISPHITEMID, Common.Constants.GroupCode.System_SCode).Trim
                .LastUpdatedBy = MyBase.LoggedOnUserID.Trim
                .UpdateCancelDT()
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub OpenPatientIntervention(ByVal ID As Integer)
            Dim oBR As New Common.BussinessRules.EMR
            With oBR
                .ID = ID
                If .GetPatientInterventionByID.Rows.Count > 0 Then
                    txtComplainTextIE.Text = .ComplainText.Trim
                    txtInterventionTextIE.Text = .InterventionText.Trim
                    txtEvaluationTextIE.Text = .EvaluationText.Trim
                Else
                    txtIDIE.Text = String.Empty
                    txtComplainTextIE.Text = String.Empty
                    txtInterventionTextIE.Text = String.Empty
                    txtEvaluationTextIE.Text = String.Empty
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub InsertPatientIntervention()
            If txtComplainTextIE.Text.Trim = String.Empty Then
                commonFunction.MsgBox(Me, "Permasalahan harus diisi.")
                Exit Sub
            End If
            Dim oBR As New Common.BussinessRules.EMR
            With oBR
                .DepartmentID = ddlDepartmentFilter.SelectedValue.Trim
                .ServiceUnitID = lblPBServiceUnitID.Text.Trim
                .RegistrationNo = lblPBRegistrationNo.Text.Trim
                .MRN = lblPBMRN.Text.Trim
                .PhysicianID = txtLinkParamedicID.Text.Trim
                .ParamedicID = txtLinkParamedicID.Text.Trim
                .ComplainText = txtComplainTextIE.Text.Trim
                .InterventionText = txtInterventionTextIE.Text.Trim
                .EvaluationText = txtEvaluationTextIE.Text.Trim
                .CreatedBy = MyBase.LoggedOnUserID.Trim
                .LastUpdatedBy = MyBase.LoggedOnUserID.Trim
                .InsertEMRPatientIntervention()
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub UpdatePatientIntervention()
            Dim oBR As New Common.BussinessRules.EMR
            With oBR
                .ID = CInt(txtIDIE.Text.Trim)
                .DepartmentID = ddlDepartmentFilter.SelectedValue.Trim
                .ServiceUnitID = lblPBServiceUnitID.Text.Trim
                .RegistrationNo = lblPBRegistrationNo.Text.Trim
                .MRN = lblPBMRN.Text.Trim
                .PhysicianID = txtLinkParamedicID.Text.Trim
                .ParamedicID = txtLinkParamedicID.Text.Trim
                .ComplainText = txtComplainTextIE.Text.Trim
                .InterventionText = txtInterventionTextIE.Text.Trim
                .EvaluationText = txtEvaluationTextIE.Text.Trim
                .CreatedBy = MyBase.LoggedOnUserID.Trim
                .LastUpdatedBy = MyBase.LoggedOnUserID.Trim
                .UpdateEMRPatientIntervention()
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub
#End Region

    End Class

End Namespace