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
    Public Class CustomerMain
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
                setToolbarVisibleButton()
                prepareDDL()
                PrepareScreen()
                _openProject()
                CountTotal()

                SetDataGrid()
                GetTasksByUserID()
            End If
        End Sub

        Private Sub ibtnViewDashboard_Click(sender As Object, e As System.EventArgs) Handles ibtnViewDashboard.Click
            Response.Write("<script language=javascript>window.location.replace('" + PageBase.UrlBase + "/secure/CustomerPage/CustomerDashboard.aspx')</script>")
        End Sub

        Private Sub ibtnViewDetail_Click(sender As Object, e As System.EventArgs) Handles ibtnViewDetail.Click
            Response.Write("<script language=javascript>window.location.replace('" + PageBase.UrlBase + "/secure/CustomerPage/CustomerMain.aspx')</script>")
        End Sub

        'Private Sub ddlPeriod_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlPeriod.SelectedIndexChanged
        '    Select Case ddlPeriod.SelectedValue.Trim
        '        Case "ThisWeek"
        '            calStartDate.selectedDate = GetFirstDayForWeek(Date.Today, False)
        '            calEndDate.selectedDate = Date.Today
        '        Case "LastWeek"
        '            calStartDate.selectedDate = GetFirstDayForWeek(Date.Today, True)
        '            calEndDate.selectedDate = GetLastDayForWeek(Date.Today, True)
        '        Case "ThisMonth"
        '            calStartDate.selectedDate = DateSerial(Date.Today.Year, Date.Today.Month, 1)
        '            calEndDate.selectedDate = DateSerial(Date.Today.Year, Date.Today.Month + 1, 1 - 1)
        '        Case "LastMonth"
        '            calStartDate.selectedDate = DateSerial(Date.Today.Year, Date.Today.Month - 1, 1)
        '            calEndDate.selectedDate = DateSerial(Date.Today.Year, Date.Today.Month - 1 + 1, 1 - 1)
        '        Case Else
        '            pnlCustomPeriod.Visible = True
        '            calStartDate.selectedDate = Date.Today
        '            calEndDate.selectedDate = Date.Today
        '    End Select
        'End Sub

        Private Sub btnClose_Click(sender As Object, e As System.EventArgs) Handles btnClose.Click
            PrepareScreenAddNew()
            pnlAddNew.Visible = False
        End Sub

        Private Sub btnSaveAndNew_Click(sender As Object, e As System.EventArgs) Handles btnSaveAndNew.Click
            _updateIssue()
            PrepareScreenAddNew()
            SetDataGrid()
        End Sub

        Private Sub btnSaveAndClose_Click(sender As Object, e As System.EventArgs) Handles btnSaveAndClose.Click
            _updateIssue()
            PrepareScreenAddNew()
            pnlAddNew.Visible = False
            SetDataGrid()
        End Sub

        Private Sub Response_btnClose_Click(sender As Object, e As System.EventArgs) Handles Response_btnClose.Click
            PrepareScreenIssueResponse(True)
            pnlIssueResponse.Visible = False
        End Sub

        Private Sub Response_btnSaveAndNew_Click(sender As Object, e As System.EventArgs) Handles Response_btnSaveAndNew.Click
            _updateIssueResponse()
            PrepareScreenIssueResponse(True)
            SetDataGridIssueResponse()
            SetDataGrid()
        End Sub

        Private Sub Response_btnSaveAndClose_Click(sender As Object, e As System.EventArgs) Handles Response_btnSaveAndClose.Click
            _updateIssueResponse()
            PrepareScreenIssueResponse(True)
            pnlIssueResponse.Visible = False
            SetDataGridIssueResponse()
            SetDataGrid()
        End Sub

        Private Sub grdIssueByFilter_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdIssueByFilter.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    Dim _lbtnIssueID As LinkButton = CType(e.Item.FindControl("_lbtnIssueID"), LinkButton)
                    pnlAddNew.Visible = True
                    lblIssueID.Text = _lbtnIssueID.Text.Trim
                    _openIssue()
                    SetDataGridIssueFile()

                Case "IssueReponse"
                    Dim _lbtnIssueID As LinkButton = CType(e.Item.FindControl("_lbtnIssueID"), LinkButton)
                    pnlIssueResponse.Visible = True
                    Response_lblIssueID.Text = _lbtnIssueID.Text.Trim
                    _openIssueForResponse()
                    PrepareScreenIssueResponse(False)
                    SetDataGridIssueResponse()
            End Select
        End Sub
#End Region

#Region " Support functions for navigation bar (Controls) "
        Private Sub setToolbarVisibleButton()
            With CSSToolbar
                .VisibleButton(CSSToolbarItem.tidSave) = False
                .VisibleButton(CSSToolbarItem.tidNew) = False
                .VisibleButton(CSSToolbarItem.tidDelete) = False
                .VisibleButton(CSSToolbarItem.tidApprove) = False
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidPrint) = False
                .VisibleButton(CSSToolbarItem.tidPrevious) = False
                .VisibleButton(CSSToolbarItem.tidNext) = False
                .VisibleButton(CSSToolbarItem.tidRefresh) = True
                .VisibleButton(CSSToolbarItem.tidDownload) = True
            End With
        End Sub

        Private Sub mdlToolbar_commandBarClick(ByVal sender As Object, ByVal e As CSSToolbarItem) Handles CSSToolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidRefresh
                    _openProject()
                    SetDataGrid()
                    CountTotal()

                Case CSSToolbarItem.tidDownload
                    Dim oRPT As New Common.BussinessRules.MyReport
                    oRPT.AddParameters(ddlProductRoadmapFilter.SelectedValue.Trim)
                    oRPT.AddParameters(ddlProjectFilter.SelectedValue.Trim)
                    oRPT.AddParameters(ddlIssueTypeFilter.SelectedValue.Trim)
                    oRPT.AddParameters(ddlIssuePriorityFilter.SelectedValue.Trim)
                    oRPT.AddParameters(ddlUserIDAssignedToFilter.SelectedValue.Trim)
                    oRPT.AddParameters(ddlIssueStatusFilter.SelectedValue.Trim)
                    oRPT.AddParameters(ddlIssueConfirmStatusFilter.SelectedValue.Trim)
                    oRPT.AddParameters(chkIsUrgent.Checked.ToString.Trim)
                    oRPT.ReportCode = Common.Constants.ReportID.ClientIssue_ReportID
                    oRPT.GetReportDataByReportCode()
                    If oRPT.ReportFormat = "XLS" Then
                        oRPT.ExportToExcel(oRPT.generateReportDataTable, Response)
                    End If
                    oRPT.Dispose()
                    oRPT = Nothing
            End Select
        End Sub
#End Region

#Region " Private Functions "
        Private Function ReadQueryString() As Boolean

        End Function

        Private Sub SetDataGrid()
            Dim decTotalIssue As Decimal = 0D
            Dim oBR As New Common.BussinessRules.Issue
            Dim oDT As New DataTable
            oDT = oBR.SelectByFilterCustomer(ddlProductRoadmapFilter.SelectedValue.Trim, ddlProjectFilter.SelectedValue.Trim, ddlIssueTypeFilter.SelectedValue.Trim, ddlIssuePriorityFilter.SelectedValue.Trim, _
                                        ddlUserIDAssignedToFilter.SelectedValue.Trim, ddlIssueStatusFilter.SelectedValue.Trim, ddlIssueConfirmStatusFilter.SelectedValue.Trim, _
                                        chkIsFilterByPeriod.Checked, calStartDate.selectedDate, calEndDate.selectedDate)
            grdIssueByFilter.DataSource = oDT
            grdIssueByFilter.DataBind()
            decTotalIssue = oDT.Rows.Count
            oBR.Dispose()
            oBR = Nothing
            lblTotalIssue.Text = decTotalIssue.ToString.Trim
        End Sub

        Private Sub SetDataGridIssueResponse()
            Dim oBR As New Common.BussinessRules.IssueResponse
            oBR.IssueID = Response_lblIssueID.Text.Trim
            grdIssueResponse.DataSource = oBR.SelectByIssueID
            grdIssueResponse.DataBind()
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub SetDataGridIssueFile()
            Dim br As New Common.BussinessRules.File
            Dim dt As New DataTable
            With br
                .referenceID = lblIssueID.Text.Trim
                .tableName = Common.Constants.TableName.IssueTable.Trim
                dt = .GetFileByReferenceID()
            End With

            repIssueFile.DataSource = dt.DefaultView
            repIssueFile.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub prepareDDL()
            'commonFunction.SetDDL_Period(ddlPeriod)
            commonFunction.SetDDL_Table(ddlProductRoadmapFilter, "CommonCode", Common.Constants.GroupCode.ProductRoadmap_SCode, True, "All Roadmap", "All")
            commonFunction.SetDDL_Table(ddlProjectFilter, "ProjectUser", MyBase.LoggedOnUserID.Trim, False)
            commonFunction.SetDDL_Table(ddlIssueTypeFilter, "CommonCode", Common.Constants.GroupCode.IssueType_SCode, True, "All Type", "All")
            commonFunction.SetDDL_Table(ddlIssueStatusFilter, "CommonCode", Common.Constants.GroupCode.IssueStatus_SCode, True, "All Status", "All")
            commonFunction.SetDDL_Table(ddlIssuePriorityFilter, "CommonCode", Common.Constants.GroupCode.IssuePriority_SCode, True, "All Priority", "All")
            commonFunction.SetDDL_Table(ddlIssueConfirmStatusFilter, "CommonCode", Common.Constants.GroupCode.IssueConfirmStatus_SCode, True, "All Confirm Status", "All")
            commonFunction.SetDDL_Table(ddlUserIDAssignedToFilter, "User", String.Empty, True, "Everyone", "Everyone")
            commonFunction.SetDDL_Table(ddlIssueType, "CommonCode", Common.Constants.GroupCode.IssueType_SCode, True, "Not Set")
            commonFunction.SetDDL_Table(ddlIssueStatus, "CommonCode", Common.Constants.GroupCode.IssueStatus_SCode, False)
            commonFunction.SetDDL_Table(ddlIssuePriority, "CommonCode", Common.Constants.GroupCode.IssuePriority_SCode, True, "Not Set")
            commonFunction.SetDDL_Table(ddlIssueConfirmStatus, "CommonCode", Common.Constants.GroupCode.IssueConfirmStatus_SCode, True, "Not Set")
            commonFunction.SetDDL_Table(ddlUserIDAssignedTo, "User", String.Empty)
        End Sub

        Private Sub PrepareScreen()
            lblLastPatchNo.Text = "-"
            pnlAddNew.Visible = False
            pnlIssueResponse.Visible = False
            ddlIssueTypeFilter.SelectedIndex = 0
            ddlIssuePriorityFilter.SelectedIndex = 0
            ddlIssueStatusFilter.SelectedValue = "001" 'OPEN as Default
            ddlIssueConfirmStatusFilter.SelectedIndex = 0
            ddlUserIDAssignedToFilter.SelectedIndex = 0

            chkIsFilterByPeriod.Checked = False
            chkIsUrgent.Checked = False

            'ddlPeriod.SelectedIndex = 0
            pnlCustomPeriod.Visible = True
            calStartDate.selectedDate = GetFirstDayForWeek(Date.Today, False)
            calEndDate.selectedDate = Date.Today
        End Sub

        Private Sub PrepareScreenAddNew()
            lblIssueID.Text = String.Empty
            txtDepartmentName.Text = String.Empty
            txtIssueDescription.Text = String.Empty
            txtKeywords.Text = String.Empty
            lblReportedDate.Text = Format(Date.Today, commonFunction.FORMAT_DATE)
            calReportedDate.selectedDate = Date.Today
            txtReportedBy.Text = String.Empty
            ddlIssueType.SelectedIndex = 0
            ddlIssueStatus.SelectedIndex = 0
            ddlIssuePriority.SelectedIndex = 0
            ddlIssueConfirmStatus.SelectedIndex = 0
            ddlUserIDAssignedTo.SelectedValue = MyBase.LoggedOnUserID.Trim
            commonFunction.Focus(Me, txtDepartmentName.ClientID)
        End Sub

        Private Sub PrepareScreenIssueResponse(ByVal IsNew As Boolean)
            If IsNew = True Then
                Response_lblResponseID.Text = String.Empty
            End If
            Response_calResponseDate.selectedDate = Date.Today
            Response_txtResponseDescription.Text = String.Empty
            commonFunction.Focus(Me, Response_txtResponseDescription.ClientID)
        End Sub

        Private Sub CountTotal()
            Dim decTotalIssue As Decimal = 0D
            Dim decTotalOpen As Decimal = 0D
            Dim decTotalInProgress As Decimal = 0D
            Dim decTotalDevFinish As Decimal = 0D
            Dim decTotalFinish As Decimal = 0D
            Dim decProgress As Decimal = 0D

            Dim oBR As New Common.BussinessRules.Issue
            Dim oDt As New DataTable
            oBR.ProjectID = ddlProjectFilter.SelectedValue.Trim
            oDt = oBR.SelectSummaryByProjectID(False)

            decTotalIssue = oBR.totalIssue
            decTotalOpen = oBR.totalOpen
            decTotalInProgress = oBR.totalInProgress
            decTotalDevFinish = oBR.totalDevFinish
            decTotalFinish = oBR.totalFinish + oBR.totalQCPassed

            If decTotalIssue = 0 Then
                decProgress = 100
            Else
                decProgress = Math.Ceiling((decTotalFinish / decTotalIssue) * 100)
            End If

            oBR.Dispose()
            oBR = Nothing

            oDt.Dispose()
            oDt = Nothing

            lblTotalIssueAll.Text = decTotalIssue.ToString.Trim
            lblTotalOpen.Text = decTotalOpen.ToString.Trim
            lblTotalInProgress.Text = decTotalInProgress.ToString.Trim
            lblTotalDevFinish.Text = decTotalDevFinish.ToString.Trim
            lblTotalFinish.Text = decTotalFinish.ToString.Trim
            lblProgress.Text = Format(decProgress, "##0")
        End Sub

        Private Function GetFirstDayForWeek(ByVal inputDate As DateTime, ByVal isLastWeek As Boolean) As DateTime
            Dim daysFromMonday As Integer = inputDate.DayOfWeek - DayOfWeek.Monday
            Dim daysToLastWeek As Integer = 7
            If isLastWeek = False Then daysToLastWeek = 0
            Return inputDate.AddDays(-daysFromMonday - daysToLastWeek)
        End Function

        Private Function GetLastDayForWeek(ByVal inputDate As DateTime, ByVal isLastWeek As Boolean) As DateTime
            Dim daysFromMonday As Integer = inputDate.DayOfWeek - DayOfWeek.Monday
            Dim daysToLastWeek As Integer = 7
            If isLastWeek = False Then daysToLastWeek = 0
            Dim fistDay As DateTime = inputDate.AddDays(-daysFromMonday - daysToLastWeek)
            Return fistDay.AddDays(6)
        End Function

        Private Sub GetTasksByUserID()
            Dim intAssignments As Integer = 0
            Dim oBr As New Common.BussinessRules.Issue
            With oBr
                .userIDassignedTo = MyBase.LoggedOnUserID.Trim
                intAssignments = .SelectIssueOutstandingByUserID(False).Rows.Count
            End With
            oBr.Dispose()
            oBr = Nothing
        End Sub

        Private Function GetUrgentIssuesCount() As Integer
            Dim i As Integer = 0
            Dim oBR As New Common.BussinessRules.Issue
            i = oBR.SelectByUrgent(MyBase.LoggedOnUserID.Trim).Rows.Count
            oBR.Dispose()
            oBR = Nothing
            Return i
        End Function

        Private Function IsPatchClosed(ByVal strPatchNo As String) As Boolean
            Dim bolToReturn As Boolean = False
            Dim oBR As New Common.BussinessRules.Patch
            With oBR
                .PatchNo = strPatchNo.Trim
                If .SelectOne.Rows.Count > 0 Then
                    bolToReturn = .IsClosed
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
            Return bolToReturn
        End Function
#End Region

#Region " C,R,U,D "
        Private Sub _openProject()
            Dim oBR As New Common.BussinessRules.Project
            With oBR
                .ProjectID = ddlProjectFilter.SelectedValue.Trim
                If .SelectOne.Rows.Count > 0 Then
                    lblLastPatchNo.Text = .lastPatchNo.Trim                    
                Else
                    lblLastPatchNo.Text = "-"
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub _openIssue()
            Dim oBR As New Common.BussinessRules.Issue
            With oBR
                .IssueID = lblIssueID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    lblProjectID.Text = .ProjectID.Trim
                    txtDepartmentName.Text = .DepartmentName.Trim
                    txtIssueDescription.Text = .IssueDescription.Trim
                    txtKeywords.Text = .Keywords.Trim
                    calReportedDate.selectedDate = .ReportedDate
                    lblReportedDate.Text = Format(.ReportedDate, commonFunction.FORMAT_DATE)
                    txtReportedBy.Text = .ReportedBy.Trim
                    ddlIssueType.SelectedValue = .IssueTypeSCode.Trim
                    ddlIssueStatus.SelectedValue = .IssueStatusSCode.Trim
                    ddlIssuePriority.SelectedValue = .IssuePrioritySCode.Trim
                    ddlIssueConfirmStatus.SelectedValue = .IssueConfirmStatusSCode.Trim
                    If .userIDassignedTo.Trim = String.Empty Then
                        ddlUserIDAssignedTo.SelectedValue = MyBase.LoggedOnUserID.Trim
                    Else
                        ddlUserIDAssignedTo.SelectedValue = .userIDassignedTo.Trim
                    End If
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub _openIssueForResponse()
            Dim oBR As New Common.BussinessRules.Issue
            With oBR
                .IssueID = Response_lblIssueID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    Response_lblDepartmentName.Text = .DepartmentName.Trim
                    Response_lblIssueDescription.Text = .IssueDescription.Trim
                Else
                    Response_lblDepartmentName.Text = String.Empty
                    Response_lblIssueDescription.Text = String.Empty
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub _updateIssue()
            Page.Validate()
            If Not Page.IsValid Then Exit Sub

            Dim fNew As Boolean = False
            Dim oBR As New Common.BussinessRules.Issue
            With oBR
                .IssueID = lblIssueID.Text.Trim
                fNew = .SelectOne.Rows.Count = 0
                .ProjectID = lblProjectID.Text.Trim
                .DepartmentName = txtDepartmentName.Text.Trim
                .IssueDescription = txtIssueDescription.Text.Trim
                .Keywords = txtKeywords.Text.Trim
                .ReportedDate = calReportedDate.selectedDate
                .ReportedBy = txtReportedBy.Text.Trim
                .IssueTypeSCode = ddlIssueType.SelectedValue.Trim
                .IssueStatusSCode = ddlIssueStatus.SelectedValue.Trim
                .IssuePrioritySCode = ddlIssuePriority.SelectedValue.Trim
                .IssueConfirmStatusSCode = ddlIssueConfirmStatus.SelectedValue.Trim
                .userIDassignedTo = ddlUserIDAssignedTo.SelectedValue.Trim
                .userIDinsert = MyBase.LoggedOnUserID.Trim
                .userIDupdate = MyBase.LoggedOnUserID.Trim
                If fNew Then
                    If .Insert() Then
                        lblIssueID.Text = .IssueID.Trim
                    End If
                Else
                    .Update()
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub _updateIssueResponse()
            Page.Validate()
            If Not Page.IsValid Then Exit Sub

            Dim fNew As Boolean = False
            Dim oBR As New Common.BussinessRules.IssueResponse
            With oBR
                .ResponseID = Response_lblResponseID.Text.Trim
                fNew = .SelectOne.Rows.Count = 0
                .IssueID = Response_lblIssueID.Text.Trim
                .ResponseDescription = Response_txtResponseDescription.Text.Trim
                .ResponseDate = Response_calResponseDate.selectedDate
                .ResponseTimeStart = Format(Date.Today, commonFunction.FORMAT_TIME)
                .ResponseDuration = 0
                .ResponseTypeSCode = Common.Constants.ResponseTypeCode.ResponseType_Customer
                .isShared = True
                .userIDinsert = MyBase.LoggedOnUserID.Trim
                .userIDupdate = MyBase.LoggedOnUserID.Trim
                If fNew Then
                    If .Insert() Then
                        Response_lblResponseID.Text = .ResponseID.Trim
                    End If
                Else
                    .Update()
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub
#End Region

    End Class

End Namespace