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

Namespace QIS.Web
    Public Class TicketManagement
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
                PrepareScreen()
                CountTotal()
                SetDataGrid()
            End If
        End Sub

        'Private Sub Response_btnClose_Click(sender As Object, e As System.EventArgs) Handles Response_btnClose.Click

        'End Sub

        'Private Sub Response_btnSaveAndNew_Click(sender As Object, e As System.EventArgs) Handles Response_btnSaveAndNew.Click

        'End Sub

        'Private Sub Response_btnSaveAndClose_Click(sender As Object, e As System.EventArgs) Handles Response_btnSaveAndClose.Click

        'End Sub

        Private Sub grdIssueOpen_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdIssueOpen.ItemCommand
            Select Case e.CommandName
                Case "IssueReponse"
                    Dim _lbtnIssueID As LinkButton = CType(e.Item.FindControl("_lbtnIssueID"), LinkButton)
                    'pnlIssueResponse.Visible = True
                    'Response_lblIssueID.Text = _lbtnIssueID.Text.Trim
                    _openIssueForResponse()
                    PrepareScreenIssueResponse(False)
                    SetDataGridIssueResponse()
            End Select
        End Sub
#End Region

#Region " Support functions for navigation bar (Controls) "
        
#End Region

#Region " Private Functions "
        Private Function ReadQueryString() As Boolean

        End Function

        Private Sub SetDataGrid()
            Dim decTotalIssue As Decimal = 0D
            Dim oBR As New Common.BussinessRules.Issue
            Dim oIssueOpen As New DataTable
            oIssueOpen = oBR.SelectByFilter("All", "All", "All", "All", "All", Common.Constants.IssueStatusCode.IssueStatus_Open, "All", False, False, Date.Today, Date.Today, True)
            grdIssueOpen.DataSource = oIssueOpen
            grdIssueOpen.DataBind()
            lblTotalOpen.Text = grdIssueOpen.Items.Count.ToString

            Dim oIssueCRFQuotation As New DataTable
            oIssueCRFQuotation = oBR.SelectByFilter("All", "All", "All", "All", "All", Common.Constants.IssueStatusCode.IssueStatus_CRFQuotation, "All", False, False, Date.Today, Date.Today, True)
            grdIssueCRFQuotation.DataSource = oIssueCRFQuotation
            grdIssueCRFQuotation.DataBind()
            lblTotalCRFQuotation.Text = grdIssueCRFQuotation.Items.Count.ToString

            Dim oIssueInProgress As New DataTable
            oIssueInProgress = oBR.SelectByFilter("All", "All", "All", "All", "All", Common.Constants.IssueStatusCode.IssueStatus_InProgress, "All", False, False, Date.Today, Date.Today, True)
            grdIssueInProgress.DataSource = oIssueInProgress
            grdIssueInProgress.DataBind()
            lblTotalInProgress.Text = grdIssueInProgress.Items.Count.ToString

            Dim oIssueDevFinish As New DataTable
            oIssueDevFinish = oBR.SelectByFilter("All", "All", "All", "All", "All", Common.Constants.IssueStatusCode.IssueStatus_DevFinish, "All", False, False, Date.Today, Date.Today, True)
            grdIssueDevFinish.DataSource = oIssueDevFinish
            grdIssueDevFinish.DataBind()
            lblTotalDevFinish.Text = grdIssueDevFinish.Items.Count.ToString

            decTotalIssue = oIssueOpen.Rows.Count

            oBR.Dispose()
            oBR = Nothing

            oIssueOpen.Dispose()
            oIssueCRFQuotation.Dispose()
            oIssueInProgress.Dispose()
            oIssueDevFinish.Dispose()
        End Sub

        Private Sub SetDataGridIssueResponse()
            'Dim oBR As New Common.BussinessRules.IssueResponse
            'oBR.IssueID = Response_lblIssueID.Text.Trim
            'grdIssueResponse.DataSource = oBR.SelectByIssueID
            'grdIssueResponse.DataBind()
            'oBR.Dispose()
            'oBR = Nothing
        End Sub

        Private Sub prepareDDL()
            
        End Sub

        Private Sub PrepareScreen()
            
        End Sub

        Private Sub PrepareScreenIssueResponse(ByVal IsNew As Boolean)
            'If IsNew = True Then
            '    Response_lblResponseID.Text = String.Empty
            'End If
            'Response_calResponseDate.selectedDate = Date.Today
            'Response_txtResponseDescription.Text = String.Empty
            'commonFunction.Focus(Me, Response_txtResponseDescription.ClientID)
        End Sub

        Private Sub CountTotal()
            'Dim decTotalIssue As Decimal = 0D
            'Dim decTotalOpen As Decimal = 0D
            'Dim decTotalInProgress As Decimal = 0D
            'Dim decTotalCRFQuotation As Decimal = 0D
            'Dim decTotalDevFinish As Decimal = 0D
            'Dim decTotalFinish As Decimal = 0D
            'Dim decTotalCancel As Decimal = 0D
            'Dim decOpenPct As Decimal = 0D
            'Dim decInProgressPct As Decimal = 0D
            'Dim decCRFQuotationPct As Decimal = 0D
            'Dim decDevFinishPct As Decimal = 0D
            'Dim decFinishPct As Decimal = 0D
            'Dim decCancelPct As Decimal = 0D
            'Dim decProgress As Decimal = 0D

            'Dim oBR As New Common.BussinessRules.Issue
            'Dim oDt As New DataTable
            'oBR.ProjectID = ddlProjectFilter.SelectedValue.Trim
            'oDt = oBR.SelectSummaryByProjectID(False)

            'decTotalIssue = oBR.totalIssue
            'decTotalOpen = oBR.totalOpen 'Need Sample, QC Failed, Retention and CRF Quotation
            'decTotalCRFQuotation = oBR.totalCRFQuotation
            'decTotalInProgress = oBR.totalInProgress
            'decTotalDevFinish = oBR.totalDevFinish
            'decTotalFinish = oBR.totalFinish + oBR.totalQCPassed
            'decTotalCancel = oBR.totalCancel 'CRF Rejected, Cancel

            'If decTotalIssue = 0 Then
            '    decProgress = 100
            'Else
            '    decProgress = Math.Ceiling((decTotalFinish / (decTotalIssue - decTotalCancel)) * 100)
            '    decOpenPct = Math.Ceiling((decTotalOpen / (decTotalIssue - decTotalCancel)) * 100)
            '    decCRFQuotationPct = Math.Ceiling((decTotalCRFQuotation / (decTotalIssue - decTotalCancel)) * 100)
            '    decInProgressPct = Math.Ceiling((decTotalInProgress / (decTotalIssue - decTotalCancel)) * 100)
            '    decDevFinishPct = Math.Ceiling((decTotalDevFinish / (decTotalIssue - decTotalCancel)) * 100)
            '    decFinishPct = Math.Ceiling((decTotalFinish / (decTotalIssue - decTotalCancel)) * 100)
            '    decCancelPct = Math.Ceiling((decTotalCancel / (decTotalIssue - decTotalCancel)) * 100)
            'End If

            'oBR.Dispose()
            'oBR = Nothing

            'oDt.Dispose()
            'oDt = Nothing

            'lblTotalIssueAll.Text = decTotalIssue.ToString.Trim
            'lblTotalOpen.Text = decTotalOpen.ToString.Trim
            'lblTotalCRFQuotation.Text = decTotalCRFQuotation.ToString.Trim
            'lblTotalInProgress.Text = decTotalInProgress.ToString.Trim
            'lblTotalDevFinish.Text = decTotalDevFinish.ToString.Trim
            'lblTotalFinish.Text = decTotalFinish.ToString.Trim
            'lblTotalCancel.Text = decTotalCancel.ToString.Trim

            'lblTotalOpenPct.Text = Format(decOpenPct, "##0")
            'lblTotalCRFQuotationPct.Text = Format(decCRFQuotationPct, "##0")
            'lblTotalInProgressPct.Text = Format(decInProgressPct, "##0")
            'lblTotalDevFinishPct.Text = Format(decDevFinishPct, "##0")
            'lblTotalFinishPct.Text = Format(decFinishPct, "##0")
            'lblTotalCancelPct.Text = Format(decCancelPct, "##0")
            'lblProgress.Text = Format(decProgress, "##0")
        End Sub
#End Region

#Region " C,R,U,D "
        Private Sub _openProject()
            'Dim oBR As New Common.BussinessRules.Project
            'With oBR
            '    .ProjectID = ddlProjectFilter.SelectedValue.Trim
            '    If .SelectOne.Rows.Count > 0 Then
            '        lblLastPatchNo.Text = .lastPatchNo.Trim
            '        chkIsOpenForClient.Checked = .IsOpenForClient
            '    Else
            '        lblLastPatchNo.Text = "-"
            '        chkIsOpenForClient.Checked = False
            '    End If
            'End With
            'oBR.Dispose()
            'oBR = Nothing

            'setToolbarVisibleButton()
        End Sub

        Private Sub _openIssue()
            'Dim oBR As New Common.BussinessRules.Issue
            'With oBR
            '    .IssueID = lblIssueID.Text.Trim
            '    If .SelectOne.Rows.Count > 0 Then
            '        lblProjectID.Text = .ProjectID.Trim
            '        txtDepartmentName.Text = .DepartmentName.Trim
            '        txtIssueDescription.Text = .IssueDescription.Trim
            '        txtKeywords.Text = .Keywords.Trim
            '        calReportedDate.selectedDate = .ReportedDate
            '        lblReportedDate.Text = Format(.ReportedDate, commonFunction.FORMAT_DATE)
            '        txtReportedBy.Text = .ReportedBy.Trim
            '        ddlIssueType.SelectedValue = .IssueTypeSCode.Trim
            '        ddlIssueStatus.SelectedValue = .IssueStatusSCode.Trim
            '        ddlIssuePriority.SelectedValue = .IssuePrioritySCode.Trim
            '        ddlIssueConfirmStatus.SelectedValue = .IssueConfirmStatusSCode.Trim
            '        If .userIDassignedTo.Trim = String.Empty Then
            '            ddlUserIDAssignedTo.SelectedValue = MyBase.LoggedOnUserID.Trim
            '        Else
            '            ddlUserIDAssignedTo.SelectedValue = .userIDassignedTo.Trim
            '        End If
            '    End If
            'End With
            'oBR.Dispose()
            'oBR = Nothing

            'If chkIsOpenForClient.Checked = True Then
            '    txtDepartmentName.ReadOnly = False
            '    txtIssueDescription.ReadOnly = False
            '    txtKeywords.ReadOnly = False
            '    txtReportedBy.ReadOnly = False
            '    ddlIssueType.Enabled = True
            '    ddlIssuePriority.Enabled = True
            'Else
            '    txtDepartmentName.ReadOnly = True
            '    txtIssueDescription.ReadOnly = True
            '    txtKeywords.ReadOnly = True
            '    txtReportedBy.ReadOnly = True
            '    ddlIssueType.Enabled = False
            '    ddlIssuePriority.Enabled = False
            'End If
        End Sub

        Private Sub _openIssueForResponse()
            'Dim oBR As New Common.BussinessRules.Issue
            'With oBR
            '    .IssueID = Response_lblIssueID.Text.Trim
            '    If .SelectOne.Rows.Count > 0 Then
            '        Response_lblDepartmentName.Text = .DepartmentName.Trim
            '        Response_lblIssueDescription.Text = .IssueDescription.Trim
            '    Else
            '        Response_lblDepartmentName.Text = String.Empty
            '        Response_lblIssueDescription.Text = String.Empty
            '    End If
            'End With
            'oBR.Dispose()
            'oBR = Nothing
        End Sub

        Private Sub _updateIssueByCustomer()
            'Page.Validate()
            'If Not Page.IsValid Then Exit Sub

            'Dim fNew As Boolean = False
            'Dim oBR As New Common.BussinessRules.Issue
            'With oBR
            '    .IssueID = lblIssueID.Text.Trim
            '    fNew = .SelectOne.Rows.Count = 0
            '    .assignedBy = MyBase.LoggedOnUserID.Trim
            '    If fNew = False Then
            '        If .userIDassignedTo.Trim = String.Empty Then
            '            .UpdateAssigned()
            '        ElseIf .userIDassignedTo.Trim <> ddlUserIDAssignedTo.SelectedValue.Trim Then
            '            .UpdateAssigned()
            '        End If
            '    End If
            '    .ProjectID = ddlProjectFilter.SelectedItem.Value.Trim
            '    .ProductRoadmapSCode = String.Empty
            '    .DepartmentName = txtDepartmentName.Text.Trim
            '    .IssueDescription = txtIssueDescription.Text.Trim
            '    .UserFriendlyIssueDescription = String.Empty
            '    .Keywords = txtKeywords.Text.Trim
            '    .ReportedDate = calReportedDate.selectedDate
            '    .ReportedBy = txtReportedBy.Text.Trim
            '    .IssueTypeSCode = ddlIssueType.SelectedValue.Trim
            '    .IssueStatusSCode = ddlIssueStatus.SelectedValue.Trim
            '    .IssuePrioritySCode = ddlIssuePriority.SelectedValue.Trim
            '    .IssueConfirmStatusSCode = ddlIssueConfirmStatus.SelectedValue.Trim
            '    .userIDassignedTo = ddlUserIDAssignedTo.SelectedValue.Trim
            '    .estStartDate = Date.Today
            '    .targetDate = Date.Today
            '    .isUrgent = False
            '    .isPlanned = False
            '    .PatchNo = String.Empty
            '    .isSpecific = False

            '    .userIDinsert = MyBase.LoggedOnUserID.Trim
            '    .userIDupdate = MyBase.LoggedOnUserID.Trim
            '    If fNew Then
            '        If .Insert() Then
            '            lblIssueID.Text = .IssueID.Trim
            '        End If
            '    Else
            '        .Update()
            '    End If
            'End With
            'oBR.Dispose()
            'oBR = Nothing
        End Sub

        Private Sub _updateIssueResponse()
            'Page.Validate()
            'If Not Page.IsValid Then Exit Sub

            'Dim fNew As Boolean = False
            'Dim oBR As New Common.BussinessRules.IssueResponse
            'With oBR
            '    .ResponseID = Response_lblResponseID.Text.Trim
            '    fNew = .SelectOne.Rows.Count = 0
            '    .IssueID = Response_lblIssueID.Text.Trim
            '    .ResponseDescription = Response_txtResponseDescription.Text.Trim
            '    .ResponseDate = Response_calResponseDate.selectedDate
            '    .ResponseTimeStart = Format(Date.Today, commonFunction.FORMAT_TIME)
            '    .ResponseDuration = 0
            '    .ResponseTypeSCode = Common.Constants.ResponseTypeCode.ResponseType_Customer
            '    .isShared = True
            '    .userIDinsert = MyBase.LoggedOnUserID.Trim
            '    .userIDupdate = MyBase.LoggedOnUserID.Trim
            '    If fNew Then
            '        If .Insert() Then
            '            Response_lblResponseID.Text = .ResponseID.Trim
            '        End If
            '    Else
            '        .Update()
            '    End If
            'End With
            'oBR.Dispose()
            'oBR = Nothing
        End Sub
#End Region

    End Class

End Namespace