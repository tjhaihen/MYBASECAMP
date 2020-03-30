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
    Public Class AssesmentMedis
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

                prepareDDL()
                PrepareScreen()
            End If
        End Sub

#Region " Main Menu "
        Private Sub ddlDepartmentFilter_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlDepartmentFilter.SelectedIndexChanged
            UpdateViewGridTodayPatient(String.Empty, calTgl.selectedDate)
        End Sub

        Private Sub grdTodayPatient_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdTodayPatient.ItemCommand
            Select Case e.CommandName
                Case "GetRegistration"
                    Dim _lbtnRegistrationNo As LinkButton = CType(e.Item.FindControl("_lbtnRegistrationNo"), LinkButton)
                    Dim _lblTransactionNo As Label = CType(e.Item.FindControl("_lblTransactionNo"), Label)
                    Dim _lblPhysicianName As Label = CType(e.Item.FindControl("_lblPhysicianName"), Label)
                    lblPBRegistrationNo.Text = _lbtnRegistrationNo.Text.Trim
                    lblPBTransactionNo.Text = _lblTransactionNo.Text.Trim
                    lblPBPhysicianName.Text = _lblPhysicianName.Text.Trim
                    OpenRegistration(ddlDepartmentFilter.SelectedValue.Trim, lblPBRegistrationNo.Text.Trim, lblPBTransactionNo.Text.Trim, ddlDepartmentFilter.SelectedItem.Text.Trim)
            End Select
        End Sub

        Private Sub btnSearchPatient_Click(sender As Object, e As System.EventArgs) Handles btnSearchPatient.Click
            UpdateViewGridTodayPatient(txtSearchPatient.Text.Trim, calTgl.selectedDate)
        End Sub

        Private Sub btnShowHistory_Click(sender As Object, e As System.EventArgs) Handles btnShowHistory.Click
            OpenPatientHistory(txtMedicalNoHistory.Text.Trim)
        End Sub

        Private Sub RadTabStrip3_TabClick(sender As Object, e As Telerik.Web.UI.RadTabStripEventArgs) Handles RadTabStrip3.TabClick
            UpdateViewGridCatatanMedis()
            UpdateViewGridCatatanPerawat()
        End Sub
#End Region

#Region " Patient Resume "
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

        Private Sub grdPatientResume_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdPatientResume.ItemDataBound
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim _grdJobOrderList As DataGrid = CType(e.Item.FindControl("_grdJobOrderList"), DataGrid)
                Dim _lblID As Label = CType(e.Item.FindControl("_lblID"), Label)
                Dim intID As Integer = 0
                If _lblID.Text.Trim = String.Empty Or _lblID.Text = Nothing Then intID = 0 Else intID = CInt(_lblID.Text.Trim)
                UpdateViewGridJobOrderListOnPatientResume(intID, _grdJobOrderList)
            End If
        End Sub

        Private Sub lbtnBackToPatientList_Click(sender As Object, e As System.EventArgs) Handles lbtnBackToPatientList.Click
            PrepareScreenPatientResume()
            pnlPatientList.Visible = True
            pnlPatientRecord.Visible = False
            lbtnBackToPatientList.Visible = False
            UpdateViewGridTodayPatient(String.Empty, calTgl.selectedDate)
        End Sub

        Private Sub lbtnNewSOAP_Click(sender As Object, e As System.EventArgs) Handles lbtnNewSOAP.Click
            PrepareScreenPatientResume()
            commonFunction.Focus(Me, txtMainDiagnosisText.ClientID)
        End Sub

        Private Sub lbtnSaveSOAP_Click(sender As Object, e As System.EventArgs) Handles lbtnSaveSOAP.Click
            If txtID.Text.Trim = String.Empty Or IsNumeric(txtID.Text.Trim) = False Then
                InsertPatientResume()
                btnDiagnosticSupportOrder.Enabled = True
                'PrepareScreenPatientResume()
            Else
                UpdatePatientResume()
                btnDiagnosticSupportOrder.Enabled = True
                'PrepareScreenPatientResume()
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
            UpdateViewGridTodayPatient(String.Empty, calTgl.selectedDate)
        End Sub

        Private Sub btnGenerateSOAPNotes_Click(sender As Object, e As System.EventArgs) Handles btnGenerateSOAPNotes.Click
            If txtChiefComplaint.Text.Trim = String.Empty Then
                commonFunction.MsgBox(Me, "Anamneis (Keluhan Utama) harus diisi.")
                Exit Sub
            End If
            If txtMainDiagnosisText.Text.Trim = String.Empty Then
                commonFunction.MsgBox(Me, "Diagnosa Utama harus diisi.")
                Exit Sub
            End If
            Dim strSOAPNotes As String = String.Empty
            strSOAPNotes = "Subjective:" + vbCrLf
            strSOAPNotes += "Keluhan utama: " + txtChiefComplaint.Text.Trim + vbCrLf
            If txtHistoryOfPresentIllness.Text.Trim.Length > 0 Then
                strSOAPNotes += "Riwayat kesehatan: " + txtHistoryOfPresentIllness.Text.Trim + vbCrLf
            End If
            strSOAPNotes += vbCrLf
            strSOAPNotes += "Objective:" + vbCrLf
            strSOAPNotes += txtObjectiveText.Text.Trim + vbCrLf
            strSOAPNotes += vbCrLf
            strSOAPNotes += "Assessment:" + vbCrLf
            strSOAPNotes += "Diagnosa utama: " + txtMainDiagnosisText.Text.Trim + vbCrLf
            If txtSecondaryDiagnosisText.Text.Trim.Length > 0 Then
                strSOAPNotes += "Diagnosa sekunder: " + txtSecondaryDiagnosisText.Text.Trim + vbCrLf
            End If
            strSOAPNotes += vbCrLf
            strSOAPNotes += "Planning:" + vbCrLf
            strSOAPNotes += "Terapi:" + vbCrLf
            strSOAPNotes += txtTherapyText.Text.Trim + vbCrLf

            Dim intPatientResumeID As Integer = 0
            If txtID.Text.Trim = String.Empty Or txtID.Text = Nothing Then intPatientResumeID = 0 Else intPatientResumeID = CInt(txtID.Text.Trim)
            Dim oUnit As New Common.BussinessRules.Worklist
            Dim oItem As New Common.BussinessRules.Worklist
            Dim tblUnit As DataTable = oUnit.GetJobOrderListByPatientResumeID(intPatientResumeID)

            Dim rowsUnit As DataRow() = tblUnit.Select("DiagnosticSupportUnitID <> ''", "DiagnosticSupportUnitID")
            If (rowsUnit.Length > 0) Then
                Dim strUnitID As String = String.Empty
                Dim strUnitName As String = String.Empty

                For iUnit As Integer = 0 To rowsUnit.Length - 1
                    Dim rowUnit As DataRow = rowsUnit(iUnit)
                    strUnitID = rowUnit("DiagnosticSupportUnitID").ToString.Trim
                    strUnitName = rowUnit("DiagnosticSupportUnitName").ToString.Trim

                    strSOAPNotes += vbCrLf
                    strSOAPNotes += strUnitName + ":" + vbCrLf

                    Dim tblItem As DataTable = oUnit.GetJobOrderDetailByPatientResumeIDByUnitID(intPatientResumeID, strUnitID.Trim)
                    Dim rowsItem As DataRow() = tblItem.Select("ItemID <> ''", "ItemID")
                    If (rowsItem.Length > 0) Then
                        Dim strItemID As String = String.Empty
                        Dim strItemName As String = String.Empty

                        For iItem As Integer = 0 To rowsItem.Length - 1
                            Dim rowItem As DataRow = rowsItem(iItem)
                            strItemID = rowItem("ItemID").ToString.Trim
                            strItemName = rowItem("ItemName").ToString.Trim

                            strSOAPNotes += strItemName + vbCrLf
                        Next
                    End If
                Next
            End If
            oUnit.Dispose()
            oUnit = Nothing
            oItem.Dispose()
            oItem = Nothing

            txtSOAPNotes.Text = strSOAPNotes

            commonFunction.Focus(Me, txtSOAPNotes.ClientID)
        End Sub

        Private Sub btnUpdateSOAPNotes_Click(sender As Object, e As System.EventArgs) Handles btnUpdateSOAPNotes.Click
            UpdateSOAPNotes()
        End Sub
#End Region

#Region " Worklist / Job Order "
        Private Sub grdJobOrderList_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdJobOrderList.ItemCommand
            Select Case e.CommandName
                Case "SelectJobOrder"
                    Dim _lbtnJobOrderNo As LinkButton = CType(e.Item.FindControl("_lbtnJobOrderNo"), LinkButton)
                    OpenJobOrderEntry(_lbtnJobOrderNo.Text.Trim)
            End Select
        End Sub

        Private Sub btnDiagnosticSupportOrder_Click(sender As Object, e As System.EventArgs) Handles btnDiagnosticSupportOrder.Click
            pnlPatientResume.Visible = False
            pnlJobOrderEntry.Visible = True
        End Sub

        Private Sub lbtnOrderNew_Click(sender As Object, e As System.EventArgs) Handles lbtnOrderNew.Click
            PrepareScreenJobOrderEntry()
        End Sub

        Private Sub lbtnOrderDone_Click(sender As Object, e As System.EventArgs) Handles lbtnOrderDone.Click
            PrepareScreenJobOrderEntry()
            pnlJobOrderEntry.Visible = False
            pnlPatientResume.Visible = True
            UpdateViewGridPatientResume()
        End Sub

        Private Sub ddlDiagnosticSupportUnit_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlDiagnosticSupportUnit.SelectedIndexChanged
            PrepareScreenJobOrderEntry()
        End Sub

        Private Sub btnJobOrderAdd_Click(sender As Object, e As System.EventArgs) Handles btnJobOrderAdd.Click
            txtJobOrderNo.Text = SaveWorklistJobOrderEntry()
            InsertPatientResumeJobOrder()
            UpdateViewGridJobOrderEntry()
            UpdateViewGridJobOrderList()
        End Sub

        Private Sub btnJobOrderRemove_Click(sender As Object, e As System.EventArgs) Handles btnJobOrderRemove.Click
            UpdateWorklistJobOrder()
            UpdateViewGridJobOrderEntry()
            UpdateViewGridJobOrderList()
        End Sub
#End Region

#Region " Patient Intervention "
        Private Sub grdPatientInterventionEvaluation_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPatientInterventionEvaluation.ItemCommand
            Select Case e.CommandName
                Case "Revise"
                    Dim _lblID As Label = CType(e.Item.FindControl("_lblID"), Label)
                    txtIDIE.Text = _lblID.Text.Trim
                    OpenPatientIntervention(CInt(txtIDIE.Text))
            End Select
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
#End Region

#Region " CPPT "
        Private Sub grdCatatanPerawatNurseNotes_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdCatatanPerawatNurseNotes.ItemCommand
            Select Case e.CommandName
                Case "PhysicianConfirmed"
                    Dim _txtNurseNotesID As TextBox = CType(e.Item.FindControl("_txtNurseNotesID"), TextBox)
                    UpdateNurseNotesPhysicianConfirmed(CInt(_txtNurseNotesID.Text.Trim))
                    UpdateViewGridCatatanPerawat()
            End Select
        End Sub
#End Region

#End Region

#Region " Support functions for navigation bar (Controls) "

#End Region

#Region " Private Functions "

#Region " Main Menu "
        Private Function ReadQueryString() As Boolean

        End Function

        Private Sub prepareDDL()
            commonFunction.SetDDL_Table(ddlAssessmentType, "CommonCode", Common.Constants.GroupCode.EMRAssessmentType_SCode)
            commonFunction.SetDDL_Table(ddlDiagnosticSupportUnit, "DiagnosticSupportUnit", String.Empty)
        End Sub

        Private Sub PrepareScreen()
            ' txtTodayDate.Text = Format(Date.Today, commonFunction.FORMAT_DATE)

            pnlPatientList.Visible = True
            pnlPatientRecord.Visible = False
            txtSearchPatient.Text = String.Empty
            calTgl.selectedDate = Date.Now
            UpdateViewGridTodayPatient(String.Empty, calTgl.selectedDate)
            PrepareScreenDashboard()

            chkIsCreateOrder.Checked = True
            chkIsRealized.Checked = False
            lblTherapyHISOrderNo.Text = String.Empty

            lbtnBackToPatientList.Visible = False
        End Sub

        Private Sub UpdateViewGridTodayPatient(ByVal strSearch As String, ByVal tanggal As Date)
            Dim dt As New DataTable
            Dim oBR As New Common.BussinessRules.EMR
            With oBR
                .DepartmentID = ddlDepartmentFilter.SelectedValue.Trim
                .PhysicianID = txtLinkParamedicID.Text.Trim

                If chkIsPhysician.Checked Then
                    dt = .GetPatientPhysicianIDToday(strSearch, tanggal)
                Else
                    dt = .GetPatientToday(strSearch, tanggal)
                End If

                grdTodayPatient.DataSource = dt
                grdTodayPatient.DataBind()
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub PrepareScreenDashboard()
            Dim dt As New DataTable
            Dim oBR As New Common.BussinessRules.EMR
            With oBR
                .PhysicianID = txtLinkParamedicID.Text.Trim
                .DepartmentID = "OUTPATIENT"
                dt = .GetPatientPhysicianIDToday(String.Empty, calTgl.selectedDate)
                lblTotalPasienRawatJalan.Text = dt.Rows.Count.ToString.Trim

                .DepartmentID = "EMERGENCY"
                dt = .GetPatientPhysicianIDToday(String.Empty, calTgl.selectedDate)
                lblTotalPasienIGD.Text = dt.Rows.Count.ToString.Trim

                .DepartmentID = "INPATIENT"
                dt = .GetPatientPhysicianIDToday(String.Empty, calTgl.selectedDate)
                lblTotalPasienRawatInap.Text = dt.Rows.Count.ToString.Trim
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub
#End Region

#Region " Patient Resume "
        Private Sub PrepareScreenPatientResume()
            txtID.Text = String.Empty
            ddlAssessmentType.Enabled = True
            txtChiefComplaint.Text = String.Empty
            txtHistoryOfPresentIllness.Text = String.Empty
            txtMainDiagnosisText.Text = String.Empty
            txtSecondaryDiagnosisText.Text = String.Empty
            txtProcedureText.Text = String.Empty
            txtTherapyText.Text = String.Empty
            txtTherapyStopDate.Text = String.Empty
            txtNotes.Text = String.Empty
            txtSOAPNotes.Text = String.Empty
            txtObjectiveText.Text = String.Empty
            txtMeasurableTargetText.Text = String.Empty
            UpdateViewGridPatientResume()
            UpdateViewGridPatientResumeHistory()
            UpdateViewGridPatientDocument()

            chkIsCreateOrder.Checked = True
            chkIsRealized.Checked = False
            lblTherapyHISOrderNo.Text = String.Empty

            lbtnBackToPatientList.Visible = True
            pnlPatientResume.Visible = True
            pnlJobOrderEntry.Visible = False
            btnDiagnosticSupportOrder.Enabled = False

            PrepareScreenJobOrderEntry()

            CheckFirstAssessmentByRegistrationNo()
        End Sub

        Private Sub PrepareScreenPatientHistory()
            txtMedicalNoHistory.Text = String.Empty
            UpdateViewGridPatientResumeHistoryMR()
        End Sub

        Private Function CheckFirstAssessmentByRegistrationNo() As Boolean
            Dim bolFA As Boolean = False
            Dim oBr As New Common.BussinessRules.EMR
            With oBr
                .MRN = lblPBMRN.Text.Trim
                .RegistrationNo = lblPBRegistrationNo.Text.Trim
                If .GetPatientResumeFirstAssessmentByRegistrationNo.Rows.Count > 0 Then
                    ddlAssessmentType.SelectedIndex = 1
                    bolFA = True
                Else
                    ddlAssessmentType.SelectedIndex = 0
                    bolFA = False
                End If
            End With
            oBr.Dispose()
            oBr = Nothing

            Return bolFA
        End Function

        Private Sub UpdateViewGridPatientResume()
            Dim oBR As New Common.BussinessRules.EMR
            With oBR
                .RegistrationNo = lblPBRegistrationNo.Text.Trim
                grdPatientResume.DataSource = .GetPatientResumeByRegistrationNo()
                grdPatientResume.DataBind()
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub UpdateViewGridPatientResumeHistory()
            Dim oBR As New Common.BussinessRules.EMR
            With oBR
                .MRN = lblPBMRN.Text.Trim
                grdPatientResumeHistory.DataSource = .GetPatientResumeByMRN()
                grdPatientResumeHistory.DataBind()
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

        Private Sub UpdateViewGridPatientDocument()
            Dim oBR As New Common.BussinessRules.PatientDocument
            With oBR
                .MRN = lblPBMRN.Text.Trim
                grdPatientDocument.DataSource = .GetPatientDocumentByMRN()
                grdPatientDocument.DataBind()

                .RegistrationNo = lblPBRegistrationNo.Text.Trim
                grdPatientDocumentByRegistration.DataSource = .GetPatientDocumentByMRNRegistrationNo()
                grdPatientDocumentByRegistration.DataBind()
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub UpdateViewGridJobOrderListOnPatientResume(ByVal intPatientResumeID As Integer, ByVal dtgJobOrderList As DataGrid)
            Dim oBR As New Common.BussinessRules.Worklist
            dtgJobOrderList.DataSource = oBR.GetJobOrderListByPatientResumeID(intPatientResumeID)
            dtgJobOrderList.DataBind()
            oBR.Dispose()
            oBR = Nothing
        End Sub
#End Region

#Region " Worklist / Job Order "
        Private Sub PrepareScreenJobOrderEntry()
            txtJobOrderNo.Text = String.Empty
            txtTransactionNo.Text = String.Empty
            txtClinicalNotes.Text = String.Empty
            chkIsCito.Checked = False
            UpdateViewGridJobOrderList()
            UpdateViewGridJobOrderEntry()
        End Sub

        Private Sub UpdateViewGridJobOrderEntry()
            Dim oBR As New Common.BussinessRules.Utility
            grdItem.DataSource = oBR.GetItemByServiceUnitIDNotInJobOrder(ddlDiagnosticSupportUnit.SelectedValue.Trim, txtJobOrderNo.Text.Trim)
            grdItem.DataBind()
            grdItemOrder.DataSource = oBR.GetItemByServiceUnitIDInJobOrder(ddlDiagnosticSupportUnit.SelectedValue.Trim, txtJobOrderNo.Text.Trim)
            grdItemOrder.DataBind()
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub UpdateViewGridJobOrderList()
            Dim oBR As New Common.BussinessRules.Worklist
            With oBR
                .RegistrationNo = lblPBRegistrationNo.Text.Trim
                '// soon... PatientResumeID
                grdJobOrderList.DataSource = .GetJobOrderListByRegistrationNo()
                grdJobOrderList.DataBind()
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub
#End Region

#Region " Patient Intervention "
        Private Sub PrepareScreenPatientIntervention()
            txtIDIE.Text = String.Empty
            txtComplainTextIE.Text = String.Empty
            txtInterventionTextIE.Text = String.Empty
            txtEvaluationTextIE.Text = String.Empty
            UpdateViewGridPatientIntervention()
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
#End Region

#Region " CPPT "
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

            Dim oBRNN As New Common.BussinessRules.EMR
            With oBRNN
                .RegistrationNo = lblPBRegistrationNo.Text.Trim
                grdCatatanPerawatNurseNotes.DataSource = .GetNurseNotesByRegistrationNo()
                grdCatatanPerawatNurseNotes.DataBind()
            End With
            oBRNN.Dispose()
            oBRNN = Nothing
        End Sub
#End Region

#End Region

#Region " C,R,U,D "

#Region " Main Menu "
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

        Private Sub OpenRegistration(ByVal DepartmentID As String, ByVal RegistrationNo As String, ByVal TransactionNo As String, ByVal DepartmentName As String)
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
                    lblPBDepartmentName.Text = DepartmentName.Trim
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
                    lblPBDepartmentName.Text = String.Empty
                    chkIsDischarged.Checked = False
                End If
            End With
            oBR.Dispose()
            oBR = Nothing

            'If DepartmentID.Trim = "OUTPATIENT" Then
            '    RadTabStrip3.Tabs.Item(4).Visible = False
            'Else
            '    RadTabStrip3.Tabs.Item(4).Visible = True
            'End If

            PrepareScreenPatientResume()
            PrepareScreenPatientIntervention()

            UpdateViewGridCatatanMedis()
            UpdateViewGridCatatanPerawat()

            lbtnBackToPatientList.Visible = True
        End Sub
#End Region        

#Region " Patient Resume "
        Private Sub OpenPatientResume(ByVal ID As Integer)
            Dim oBR As New Common.BussinessRules.EMR
            With oBR
                .ID = ID
                If .GetPatientResumeByID.Rows.Count > 0 Then
                    ddlAssessmentType.SelectedValue = .AssessmentTypeSCode.Trim
                    ddlAssessmentType.Enabled = False
                    txtChiefComplaint.Text = .ChiefComplaint.Trim
                    txtHistoryOfPresentIllness.Text = .HistoryOfPresentIllness.Trim
                    txtMainDiagnosisText.Text = .MainDiagnosisText.Trim
                    txtSecondaryDiagnosisText.Text = .SecondaryDiagnosisText.Trim
                    txtProcedureText.Text = .ProcedureText.Trim
                    txtTherapyText.Text = .TherapyText.Trim
                    txtTherapyStopDate.Text = .TherapyStopDate.Trim
                    chkIsDischarged.Checked = .IsDischarged
                    txtNotes.Text = .Notes.Trim
                    txtSOAPNotes.Text = .SOAPNotes.Trim
                    txtObjectiveText.Text = .ObjectiveText.Trim
                    txtMeasurableTargetText.Text = .MeasurableTargetText.Trim
                    btnDiagnosticSupportOrder.Enabled = True
                Else
                    txtID.Text = String.Empty
                    ddlAssessmentType.Enabled = True
                    txtChiefComplaint.Text = String.Empty
                    txtHistoryOfPresentIllness.Text = String.Empty
                    txtMainDiagnosisText.Text = String.Empty
                    txtSecondaryDiagnosisText.Text = String.Empty
                    txtProcedureText.Text = String.Empty
                    txtTherapyText.Text = String.Empty
                    txtTherapyStopDate.Text = String.Empty
                    chkIsDischarged.Checked = False
                    txtNotes.Text = String.Empty
                    txtSOAPNotes.Text = String.Empty
                    txtObjectiveText.Text = String.Empty
                    txtMeasurableTargetText.Text = String.Empty
                    btnDiagnosticSupportOrder.Enabled = False
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
            If CheckFirstAssessmentByRegistrationNo() = True And ddlAssessmentType.SelectedValue = "01" Then
                commonFunction.MsgBox(Me, "Sudah ada asesmen Awal. Silahkan lanjutkan dengan memilih tipe asesmen Lanjutan.")
                Exit Sub
            End If
            Dim oBR As New Common.BussinessRules.EMR
            With oBR
                .DepartmentID = ddlDepartmentFilter.SelectedValue.Trim
                .ServiceUnitID = lblPBServiceUnitID.Text.Trim
                .RegistrationNo = lblPBRegistrationNo.Text.Trim
                .MRN = lblPBMRN.Text.Trim
                .PhysicianID = txtLinkParamedicID.Text.Trim
                .AssessmentTypeSCode = ddlAssessmentType.SelectedValue.Trim
                .ChiefComplaint = txtChiefComplaint.Text.Trim
                .HistoryOfPresentIllness = txtHistoryOfPresentIllness.Text.Trim
                .MainDiagnosisText = txtMainDiagnosisText.Text.Trim
                .SecondaryDiagnosisText = txtSecondaryDiagnosisText.Text.Trim
                .ProcedureText = txtProcedureText.Text.Trim
                .TherapyText = txtTherapyText.Text.Trim
                .TherapyStopDate = txtTherapyStopDate.Text.Trim
                .Notes = txtNotes.Text.Trim
                .SOAPNotes = txtSOAPNotes.Text.Trim
                .ObjectiveText = txtObjectiveText.Text.Trim
                .MeasurableTargetText = txtMeasurableTargetText.Text.Trim
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
                .AssessmentTypeSCode = ddlAssessmentType.SelectedValue.Trim
                .ChiefComplaint = txtChiefComplaint.Text.Trim
                .HistoryOfPresentIllness = txtHistoryOfPresentIllness.Text.Trim
                .MainDiagnosisText = txtMainDiagnosisText.Text.Trim
                .SecondaryDiagnosisText = txtSecondaryDiagnosisText.Text.Trim
                .ProcedureText = txtProcedureText.Text.Trim
                .TherapyText = txtTherapyText.Text.Trim
                .TherapyStopDate = txtTherapyStopDate.Text.Trim
                .Notes = txtNotes.Text.Trim
                .SOAPNotes = txtSOAPNotes.Text.Trim
                .ObjectiveText = txtObjectiveText.Text.Trim
                .MeasurableTargetText = txtMeasurableTargetText.Text.Trim
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

        Private Sub UpdateSOAPNotes()
            If txtID.Text = String.Empty Then
                txtID.Text = CStr(0D)
            End If
            Dim oBR As New Common.BussinessRules.EMR
            With oBR
                .ID = CInt(txtID.Text.Trim)
                .SOAPNotes = txtSOAPNotes.Text.Trim
                .LastUpdatedBy = MyBase.LoggedOnUserID.Trim
                .UpdateSOAPNotes()
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
#End Region

#Region " Worklist / Job Order "
        Private Function SaveWorklistPrescriptionText() As String
            Dim strOrderNoToReturn As String = String.Empty

            Me.Validate()
            If Not Me.IsValid Then Exit Function

            If ddlDepartmentFilter.SelectedValue.Trim = "INPATIENT" Then
                If txtJobOrderNo.Text.Trim = String.Empty And txtTransactionNo.Text.Trim = String.Empty Then
                    '// New Record
                    Dim oBR As New Common.BussinessRules.Worklist
                    With oBR
                        '//Transaction Header
                        .RegistrationNo = lblPBRegistrationNo.Text.Trim
                        Select Case ddlDepartmentFilter.SelectedValue.Trim
                            Case "OUTPATIENT"
                                .ModuleID = "RJ"
                            Case "EMERGENCY"
                                .ModuleID = "RD"
                            Case "INPATIENT"
                                .ModuleID = "RI"
                        End Select
                        .SupportingUnitID = ddlDiagnosticSupportUnit.SelectedValue.Trim
                        .CreatedBy = "EMRModule"
                        .LastUpdatedBy = "EMRModule"

                        txtTransactionNo.Text = .InsertTransactionOrderHD()
                        lblPBTransactionNo.Text = txtTransactionNo.Text
                    End With
                    oBR.Dispose()
                    oBR = Nothing
                End If
            End If

            Dim oBR2 As New Common.BussinessRules.Worklist
            With oBR2
                '//Header
                If Common.Methods.GetCommonCode(Common.Constants.SystemSetting.SystemSetting_VERSIAPP, "VersiAPP").Trim = "1" Then
                    strOrderNoToReturn = .NewNoJO(ddlDepartmentFilter.SelectedValue.Trim)
                Else
                    strOrderNoToReturn = .NewOrderNo()
                End If
                .OrderNo = strOrderNoToReturn.Trim

                .RegistrationNo = lblPBRegistrationNo.Text.Trim
                .MRN = lblPBMRN.Text.Trim
                Select Case ddlDepartmentFilter.SelectedValue.Trim
                    Case "OUTPATIENT"
                        .ModuleID = "RJ"
                    Case "EMERGENCY"
                        .ModuleID = "RD"
                    Case "INPATIENT"
                        .ModuleID = "RI"
                End Select
                .SupportingUnitID = Common.Methods.GetCommonCode(Common.Constants.SystemSetting.SystemSetting_HISPHUNITID, Common.Constants.GroupCode.System_SCode).Trim
                .ServiceUnitID = lblPBServiceUnitID.Text.Trim
                .ClinicalNotes = String.Empty
                .IsCito = False
                .CreatedBy = MyBase.LoggedOnUserID.Trim
                .LastUpdatedBy = MyBase.LoggedOnUserID.Trim
                txtTransactionNo.Text = .InsertTransactionOrderHD()
                .TransactionNo = txtTransactionNo.Text 'lblPBTransactionNo.Text.Trim

                '// Detail
                .ItemID = Common.Methods.GetCommonCode(Common.Constants.SystemSetting.SystemSetting_HISPHITEMID, Common.Constants.GroupCode.System_SCode).Trim
                .StatusID = "01" '// Order
                .PrescriptionNotes = txtTherapyText.Text.Trim
                .IsValidate = False

                If .InsertHD() Then
                    .InsertDT()
                End If
            End With

            oBR2.Dispose()
            oBR2 = Nothing


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

        Private Sub OpenJobOrderEntry(ByVal strJobOrderNo As String)
            Dim oBR As New Common.BussinessRules.Worklist
            With oBR
                .OrderNo = strJobOrderNo.Trim
                If .SelectOrderHd.Rows.Count > 0 Then
                    ddlDiagnosticSupportUnit.SelectedValue = .SupportingUnitID.Trim
                    txtClinicalNotes.Text = .ClinicalNotes.Trim
                    txtJobOrderNo.Text = .OrderNo.Trim
                    txtTransactionNo.Text = .TransactionNo.Trim
                    lblJobOrderStatus.Text = .StatusName.Trim
                    If lblJobOrderStatus.Text = "SELESAI" Then
                        btnJobOrderAdd.Enabled = False
                        btnJobOrderRemove.Enabled = False
                    Else
                        btnJobOrderAdd.Enabled = True
                        btnJobOrderRemove.Enabled = True
                    End If
                Else
                    txtClinicalNotes.Text = String.Empty
                    txtJobOrderNo.Text = String.Empty
                    txtTransactionNo.Text = String.Empty
                    lblJobOrderStatus.Text = String.Empty
                End If
            End With
            oBR.Dispose()
            oBR = Nothing

            UpdateViewGridJobOrderEntry()
        End Sub

        Private Function SaveWorklistJobOrderEntry() As String
            Dim strOrderNoToReturn As String = String.Empty
            Me.Validate()
            If Not Me.IsValid Then Exit Function

            If txtJobOrderNo.Text.Trim = String.Empty And txtTransactionNo.Text.Trim = String.Empty Then
                '// New Record
                Dim oBR As New Common.BussinessRules.Worklist
                With oBR
                    '//Transaction Header
                    .RegistrationNo = lblPBRegistrationNo.Text.Trim
                    Select Case ddlDepartmentFilter.SelectedValue.Trim
                        Case "OUTPATIENT"
                            .ModuleID = "RJ"
                        Case "EMERGENCY"
                            .ModuleID = "RD"
                        Case "INPATIENT"
                            .ModuleID = "RI"
                    End Select
                    .SupportingUnitID = ddlDiagnosticSupportUnit.SelectedValue.Trim
                    .CreatedBy = "EMRModule"
                    .LastUpdatedBy = "EMRModule"

                    If ddlDepartmentFilter.SelectedValue.Trim <> "INPATIENT" Then
                        txtTransactionNo.Text = lblPBTransactionNo.Text.Trim
                    End If
                    If ddlDepartmentFilter.SelectedValue.Trim = "INPATIENT" Then
                        txtTransactionNo.Text = .InsertTransactionOrderHD()
                    End If

                    If txtTransactionNo.Text.Trim <> String.Empty Then
                        '//Order Header
                        If Common.Methods.GetCommonCode(Common.Constants.SystemSetting.SystemSetting_VERSIAPP, "VersiAPP").Trim = "1" Then
                            strOrderNoToReturn = .NewNoJO(ddlDepartmentFilter.SelectedValue.Trim)
                        Else
                            strOrderNoToReturn = .NewOrderNo()
                        End If
                        'strOrderNoToReturn = .NewOrderNo()
                        .OrderNo = strOrderNoToReturn.Trim
                        .TransactionNo = txtTransactionNo.Text
                        .MRN = lblPBMRN.Text.Trim
                        .ServiceUnitID = lblPBServiceUnitID.Text.Trim
                        .ClinicalNotes = "Order menggunakan EMR"
                        .IsCito = chkIsCito.Checked

                        .InsertHD()

                        '// Order Detail
                        .PrescriptionNotes = String.Empty
                        .StatusID = "01" '// Order

                        For Each item As DataGridItem In grdItem.Items
                            Dim chkSelect As CheckBox = CType(item.FindControl("chkSelect"), CheckBox)
                            Dim _lblItemID As Label = CType(item.FindControl("_lblItemID"), Label)

                            .ItemID = _lblItemID.Text.Trim

                            If chkSelect.Checked Then .InsertDT()
                        Next
                    End If
                End With

                oBR.Dispose()
                oBR = Nothing
            Else
                '// Add Detail Only
                Dim oBR As New Common.BussinessRules.Worklist
                With oBR
                    '// Order Detail
                    strOrderNoToReturn = txtJobOrderNo.Text.Trim
                    .OrderNo = strOrderNoToReturn
                    .PrescriptionNotes = String.Empty
                    .StatusID = "01" '// Order
                    .IsCito = chkIsCito.Checked
                    .CreatedBy = "EMRModule"
                    .LastUpdatedBy = "EMRModule"

                    For Each item As DataGridItem In grdItem.Items
                        Dim chkSelect As CheckBox = CType(item.FindControl("chkSelect"), CheckBox)
                        Dim _lblItemID As Label = CType(item.FindControl("_lblItemID"), Label)

                        .ItemID = _lblItemID.Text.Trim

                        If chkSelect.Checked Then .InsertDT()
                    Next
                End With

                oBR.Dispose()
                oBR = Nothing
            End If
            lblJobOrderStatus.Text = "ORDER"

            Return strOrderNoToReturn.Trim
        End Function

        Private Function UpdateWorklistJobOrder() As String
            Dim oBR As New Common.BussinessRules.Worklist
            With oBR
                .OrderNo = txtJobOrderNo.Text.Trim
                .LastUpdatedBy = MyBase.LoggedOnUserID.Trim
                For Each item As DataGridItem In grdItemOrder.Items
                    Dim chkSelect As CheckBox = CType(item.FindControl("chkSelect"), CheckBox)
                    Dim _lblItemID As Label = CType(item.FindControl("_lblItemID"), Label)

                    .ItemID = _lblItemID.Text.Trim

                    If chkSelect.Checked Then .UpdateCancelDT()
                Next
            End With
            oBR.Dispose()
            oBR = Nothing
        End Function

        Private Sub InsertPatientResumeJobOrder()
            If txtID.Text = String.Empty Then
                txtID.Text = CStr(0D)
            End If
            Dim oBR As New Common.BussinessRules.Worklist
            With oBR
                .OrderNo = txtJobOrderNo.Text.Trim
                .CreatedBy = MyBase.LoggedOnUserID.Trim
                .InsertPatientResumeJobOrder(CInt(txtID.Text.Trim))
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub
#End Region

#Region " Patient Intervention "
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

#Region " CPPT "
        Private Sub UpdateNurseNotesPhysicianConfirmed(ByVal intNurseNotesID As Integer)
            Dim oBR As New Common.BussinessRules.EMR
            With oBR
                .NurseNotesID = intNurseNotesID
                .IsPhysicianConfirmed = True
                .LastUpdatedBy = MyBase.LoggedOnUserID.Trim
                .UpdateNurseNotesPhysicianConfirmed()
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub
#End Region

#End Region

       
    End Class

End Namespace