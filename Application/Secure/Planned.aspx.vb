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
    Public Class Planned
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
            commonFunction.TimeFormat(Response_txtResponseTimeStart)
            If Not Me.IsPostBack Then
                setToolbarVisibleButton()
                prepareDDL()
                PrepareScreen()

                SetDataGrid()
                prepareDDLUserIDAssignedToFilter()

                pnlAddNew.Visible = False
                pnlIssueResponse.Visible = False
                GetTasksByUserID()
            End If
        End Sub

        Private Sub lbtnMyProjects_Click(sender As Object, e As System.EventArgs) Handles lbtnMyProjects.Click, ibtnMyProjects.Click
            Response.Write("<script language=javascript>window.location.replace('" + PageBase.UrlBase + "/secure/Main.aspx" + "')</script>")
        End Sub

        Private Sub lbtnMyDay_Click(sender As Object, e As System.EventArgs) Handles lbtnMyDay.Click, ibtnMyDay.Click
            Response.Write("<script language=javascript>window.location.replace('" + PageBase.UrlBase + "/secure/Myday.aspx')</script>")
        End Sub

        Private Sub lbtnUrgents_Click(sender As Object, e As System.EventArgs) Handles lbtnUrgents.Click, ibtnUrgents.Click
            Response.Write("<script language=javascript>window.location.replace('" + PageBase.UrlBase + "/secure/Urgent.aspx')</script>")
        End Sub

        Private Sub lbtnMyAssignments_Click(sender As Object, e As System.EventArgs) Handles lbtnMyAssignments.Click, ibtnMyAssignments.Click
            Response.Write("<script language=javascript>window.location.replace('" + PageBase.UrlBase + "/secure/Main.aspx?isassignment=True" + "')</script>")
        End Sub

        Private Sub lbtnFollowUpIssue_Click(sender As Object, e As System.EventArgs) Handles lbtnFollowUpIssue.Click, ibtnFollowUpIssue.Click
            Response.Write("<script language=javascript>window.location.replace('" + PageBase.UrlBase + "/secure/FollowUpIssue.aspx')</script>")
        End Sub

        Private Sub lbtnIssueStudy_Click(sender As Object, e As System.EventArgs) Handles lbtnIssueStudy.Click, ibtnIssueStudy.Click
            Response.Write("<script language=javascript>window.location.replace('" + PageBase.UrlBase + "/secure/IssueStudy.aspx')</script>")
        End Sub

        Private Sub ddlProjectGroupFilter_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlProjectGroupFilter.SelectedIndexChanged
            SetDataGrid()
            prepareDDLUserIDAssignedToFilter()
        End Sub

        Private Sub ddlIssueStatusFilter_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlIssueStatusFilter.SelectedIndexChanged
            SetDataGrid()
        End Sub

        Private Sub ddlUserIDAssignedToFilter_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlUserIDAssignedToFilter.SelectedIndexChanged
            SetDataGrid()
        End Sub

        Private Sub btnClose_Click(sender As Object, e As System.EventArgs) Handles btnClose.Click
            PrepareScreenAddNew()
            'SetDataGrid()
            pnlAddNew.Visible = False
        End Sub

        Private Sub btnSaveAndClose_Click(sender As Object, e As System.EventArgs) Handles btnSaveAndClose.Click
            If IsPatchClosed(txtPatchNo.Text.Trim) = True Then
                commonFunction.MsgBox(Me, "Cannot add to Patch No. " + txtPatchNo.Text.Trim + ". It is already Closed.")
                Exit Sub
            End If

            _updateIssue()
            PrepareScreenAddNew()
            pnlAddNew.Visible = False
            SetDataGrid()
        End Sub

        Private Sub chkIsAssignedToMe_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkIsAssignedToMe.CheckedChanged
            If chkIsAssignedToMe.Checked Then
                If ddlUserIDAssignedToFilter.Items.FindByValue(MyBase.LoggedOnUserID.Trim) Is Nothing Then
                    commonFunction.MsgBox(Me, "There is no assignment for you.")
                    chkIsAssignedToMe.Checked = False
                Else
                    ddlUserIDAssignedToFilter.SelectedValue = MyBase.LoggedOnUserID.Trim
                    SetDataGrid()
                End If
            Else
                ddlUserIDAssignedToFilter.SelectedIndex = 0
                SetDataGrid()
            End If
        End Sub

        Private Sub ibtnViewDetailPlanned_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtnViewDetailPlanned.Click
            pnlDetailPlanned.Visible = True
            pnlPlannedByTeam.Visible = False
        End Sub

        Private Sub ibtnViewPlannedByTeam_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtnViewPlannedByTeam.Click
            pnlDetailPlanned.Visible = False
            pnlPlannedByTeam.Visible = True
            SetDataGridPlannedByTeam()
        End Sub

        Private Sub Response_btnClose_Click(sender As Object, e As System.EventArgs) Handles Response_btnClose.Click
            PrepareScreenIssueResponse()
            pnlIssueResponse.Visible = False
        End Sub

        Private Sub Response_btnSaveAndNew_Click(sender As Object, e As System.EventArgs) Handles Response_btnSaveAndNew.Click
            If IsPatchClosed(Response_txtPatchNo.Text.Trim) = True Then
                commonFunction.MsgBox(Me, "Cannot add to Patch No. " + Response_txtPatchNo.Text.Trim + ". It is already Closed.")
                Exit Sub
            End If

            _updateIssueResponse()
            PrepareScreenIssueResponse()
            SetDataGridIssueResponse()
            SetDataGrid()
        End Sub

        Private Sub Response_btnSaveAndClose_Click(sender As Object, e As System.EventArgs) Handles Response_btnSaveAndClose.Click
            If IsPatchClosed(Response_txtPatchNo.Text.Trim) = True Then
                commonFunction.MsgBox(Me, "Cannot add to Patch No. " + Response_txtPatchNo.Text.Trim + ". It is already Closed.")
                Exit Sub
            End If

            _updateIssueResponse()
            PrepareScreenIssueResponse()
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
                    pnlAddNew.Visible = False
                    Response_lblIssueID.Text = _lbtnIssueID.Text.Trim
                    _openIssueForResponse()
                    PrepareScreenIssueResponse()
                    SetDataGridIssueResponse()
            End Select
        End Sub

        Private Sub grdIssueResponse_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdIssueResponse.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    Dim _lblResponseID As Label = CType(e.Item.FindControl("_lblResponseID"), Label)
                    pnlIssueResponse.Visible = True
                    pnlAddNew.Visible = False
                    Response_lblResponseID.Text = _lblResponseID.Text.Trim
                    _openIssueResponse()
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
                .VisibleButton(CSSToolbarItem.tidDownload) = False
            End With
        End Sub

        Private Sub mdlToolbar_commandBarClick(ByVal sender As Object, ByVal e As CSSToolbarItem) Handles CSSToolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidRefresh
                    pnlAddNew.Visible = False
                    pnlIssueResponse.Visible = False
                    SetDataGrid()
                    SetDataGridPlannedByTeam()
                    prepareDDLUserIDAssignedToFilter()
            End Select
        End Sub
#End Region

#Region " Private Functions "
        Private Function ReadQueryString() As Boolean

        End Function

        Private Sub SetDataGrid()
            Dim oBR As New Common.BussinessRules.Issue
            Dim oDT As New DataTable
            oDT = oBR.SelectByPlanned(ddlUserIDAssignedToFilter.SelectedValue.Trim, calStartDate.selectedDate, calEndDate.selectedDate, ddlProjectGroupFilter.SelectedValue.Trim, ddlIssueStatusFilter.SelectedValue.Trim)
            grdIssueByFilter.DataSource = oDT
            grdIssueByFilter.DataBind()
            oBR.Dispose()
            oBR = Nothing

            TotalPlanned()
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

        Private Sub SetDataGridPlannedByTeam()
            Dim oBR As New Common.BussinessRules.Issue
            Dim oDT As New DataTable
            oDT = oBR.SelectPlannedByUserAssignedTo(calStartDate.selectedDate, calEndDate.selectedDate, ddlProjectGroupFilter.SelectedValue.Trim)
            grdPlannedByTeam.DataSource = oDT
            grdPlannedByTeam.DataBind()
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub prepareDDL()
            commonFunction.SetDDL_Table(ddlProjectGroupFilter, "ProjectGroup", MyBase.LoggedOnUserID.Trim, False)
            commonFunction.SetDDL_Table(ddlIssueStatusFilter, "CommonCode", Common.Constants.GroupCode.IssueStatus_SCode, True, "All Issue Status", "All")
            commonFunction.SetDDL_Table(ddlProductRoadmap, "CommonCode", Common.Constants.GroupCode.ProductRoadmap_SCode, True, "Not Set")
            commonFunction.SetDDL_Table(ddlIssueType, "CommonCode", Common.Constants.GroupCode.IssueType_SCode, True, "Not Set", "All")
            commonFunction.SetDDL_Table(ddlIssueStatus, "CommonCode", Common.Constants.GroupCode.IssueStatus_SCode, True, "Not Set", "All")
            commonFunction.SetDDL_Table(ddlIssuePriority, "CommonCode", Common.Constants.GroupCode.IssuePriority_SCode, True, "Not Set", "All")
            commonFunction.SetDDL_Table(ddlIssueConfirmStatus, "CommonCode", Common.Constants.GroupCode.IssueConfirmStatus_SCode, True, "Not Set", "All")
            commonFunction.SetDDL_Table(ddlUserIDAssignedTo, "UserActive", String.Empty)
            commonFunction.SetDDL_Table(Response_ddlResponseType, "CommonCode", Common.Constants.GroupCode.ResponseType_SCode, False)
            commonFunction.SetDDL_Table(Response_ddlIssueStatus, "CommonCode", Common.Constants.GroupCode.IssueStatus_SCode, True, "Not Set")
            commonFunction.SetDDL_Table(Response_ddlIssueConfirmStatus, "CommonCode", Common.Constants.GroupCode.IssueConfirmStatus_SCode, True, "Not Set")
        End Sub

        Private Sub prepareDDLUserIDAssignedToFilter()
            commonFunction.SetDDL_UserIDAssignedPlanned(ddlUserIDAssignedToFilter, calStartDate.selectedDate, calEndDate.selectedDate, ddlProjectGroupFilter.SelectedValue.Trim, True, "Everyone", "All")
        End Sub

        Private Sub PrepareScreen()
            calStartDate.selectedDate = GetFirstDayForWeek(Date.Today, False)
            calEndDate.selectedDate = GetLastDayForWeek(Date.Today, False)
            chkIsAssignedToMe.Checked = False
        End Sub

        Private Sub PrepareScreenAddNew()
            lblIssueID.Text = String.Empty
            txtDepartmentName.Text = String.Empty
            txtIssueDescription.Text = String.Empty
            txtKeywords.Text = String.Empty
            calReportedDate.selectedDate = Date.Today
            txtReportedBy.Text = String.Empty
            ddlIssueType.SelectedIndex = 0
            ddlIssueStatus.SelectedIndex = 0
            ddlIssuePriority.SelectedIndex = 0
            ddlIssueConfirmStatus.SelectedIndex = 0
            ddlUserIDAssignedTo.SelectedValue = MyBase.LoggedOnUserID.Trim
            txtPatchNo.Text = String.Empty
            chkIsSpecific.Checked = False
            commonFunction.Focus(Me, txtDepartmentName.ClientID)
        End Sub

        Private Sub PrepareScreenIssueResponse()
            Response_lblResponseID.Text = String.Empty
            Response_calResponseDate.selectedDate = Date.Today
            Response_txtResponseTimeStart.Text = Format(Date.Now, "hh:mm")
            Response_txtResponseDuration.Text = "0"
            Response_txtResponseDescription.Text = String.Empty
            Response_chkIsShared.Checked = False

            Response_chkIsUpdateStatus.Checked = False
            Response_txtPatchNo.Text = String.Empty
            Response_chkIsSpecific.Checked = False

            Response_chkIsIncludeInMyWorktime.Checked = False
            Response_txtWorktimeDtDescription.Text = String.Empty
            Response_txtWorkTimeInHour.Text = "0"
            commonFunction.Focus(Me, Response_txtResponseTimeStart.ClientID)
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

            lblAssignmentsTotal.Text = intAssignments.ToString.Trim
            lblUrgentsTotal.Text = GetUrgentIssuesCount().ToString.Trim
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
        Private Sub _openIssue()
            Dim oBR As New Common.BussinessRules.Issue
            With oBR
                .IssueID = lblIssueID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    lblProjectID.Text = .ProjectID.Trim
                    ddlProductRoadmap.SelectedValue = .ProductRoadmapSCode.Trim
                    txtDepartmentName.Text = .DepartmentName.Trim
                    txtIssueDescription.Text = .IssueDescription.Trim
                    txtKeywords.Text = .Keywords.Trim
                    calReportedDate.selectedDate = .ReportedDate
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
                    txtPatchNo.Text = .PatchNo.Trim
                    chkIsSpecific.Checked = .isSpecific
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
                    Response_lblProjectID.Text = .ProjectID.Trim
                    Response_lblDepartmentName.Text = .DepartmentName.Trim
                    Response_lblIssueDescription.Text = .IssueDescription.Trim
                    Response_ddlIssueStatus.SelectedValue = .IssueStatusSCode.Trim
                    Response_ddlIssueConfirmStatus.SelectedValue = .IssueConfirmStatusSCode.Trim
                    Response_txtPatchNo.Text = .PatchNo.Trim
                    Response_chkIsSpecific.Checked = .isSpecific
                Else
                    Response_lblProjectID.Text = String.Empty
                    Response_lblDepartmentName.Text = String.Empty
                    Response_lblIssueDescription.Text = String.Empty
                    Response_ddlIssueStatus.SelectedIndex = 0
                    Response_ddlIssueConfirmStatus.SelectedIndex = 0
                    Response_txtPatchNo.Text = String.Empty
                    Response_chkIsSpecific.Checked = False
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub _openIssueResponse()
            Dim oBR As New Common.BussinessRules.IssueResponse
            With oBR
                .ResponseID = Response_lblResponseID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    Response_calResponseDate.selectedDate = .ResponseDate
                    Response_txtResponseTimeStart.Text = .ResponseTimeStart.Trim
                    Response_txtResponseDuration.Text = .ResponseDuration.ToString.Trim
                    Response_ddlResponseType.SelectedValue = .ResponseTypeSCode.Trim
                    Response_txtResponseDescription.Text = .ResponseDescription.Trim
                    Response_chkIsShared.Checked = .isShared
                Else
                    PrepareScreenIssueResponse()
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub _updateIssue()
            Page.Validate()
            If Not Page.IsValid Then Exit Sub

            If IsPatchClosed(txtPatchNo.Text.Trim) = True Then
                commonFunction.MsgBox(Me, "Cannot add to Patch No. " + txtPatchNo.Text.Trim + ". It is already Closed.")
                Exit Sub
            End If

            Dim fNew As Boolean = False
            Dim oBR As New Common.BussinessRules.Issue
            With oBR
                .IssueID = lblIssueID.Text.Trim
                fNew = .SelectOne.Rows.Count = 0
                .ProjectID = lblProjectID.Text.Trim
                .ProductRoadmapSCode = ddlProductRoadmap.SelectedValue.Trim
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
                .PatchNo = txtPatchNo.Text.Trim
                .isSpecific = chkIsSpecific.Checked
                .userIDinsert = MyBase.LoggedOnUserID.Trim
                .userIDupdate = MyBase.LoggedOnUserID.Trim
                If fNew Then
                    If .Insert() Then
                        lblIssueID.Text = .IssueID.Trim
                        If chkIsIncludeInMyWorktime.Checked Then
                            InsertWorkTimeHdFromAddEditIssue()
                        End If
                    End If
                Else
                    If .Update() Then
                        If chkIsIncludeInMyWorktime.Checked Then
                            InsertWorkTimeHdFromAddEditIssue()
                        End If
                    End If
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub _updateIssueStatus(ByVal IssueID As String)
            Dim oBR As New Common.BussinessRules.Issue
            With oBR
                .IssueID = IssueID.Trim
                .IssueStatusSCode = Response_ddlIssueStatus.SelectedValue.Trim
                .IssueConfirmStatusSCode = Response_ddlIssueConfirmStatus.SelectedValue.Trim
                .PatchNo = Response_txtPatchNo.Text.Trim
                .isSpecific = Response_chkIsSpecific.Checked
                .userIDupdate = MyBase.LoggedOnUserID.Trim
                .UpdateStatus()
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
                .ResponseTimeStart = Response_txtResponseTimeStart.Text.Trim
                .ResponseDuration = CInt(IIf(IsNumeric(Response_txtResponseDuration.Text.Trim), Response_txtResponseDuration.Text.Trim, 0).ToString.Trim)
                .ResponseTypeSCode = Response_ddlResponseType.SelectedItem.Value.Trim
                .isShared = Response_chkIsShared.Checked
                .userIDinsert = MyBase.LoggedOnUserID.Trim
                .userIDupdate = MyBase.LoggedOnUserID.Trim
                If fNew Then
                    If .Insert() Then
                        If Response_chkIsUpdateStatus.Checked Then
                            _updateIssueStatus(Response_lblIssueID.Text.Trim)
                        End If

                        If Response_chkIsIncludeInMyWorktime.Checked Then
                            InsertWorkTimeHdFromAddEditResponse()
                        End If
                        Response_lblResponseID.Text = .ResponseID.Trim
                    End If
                Else
                    If .Update() Then
                        If Response_chkIsUpdateStatus.Checked Then
                            _updateIssueStatus(Response_lblIssueID.Text.Trim)
                        End If

                        If Response_chkIsIncludeInMyWorktime.Checked Then
                            InsertWorkTimeHdFromAddEditResponse()
                        End If
                    End If
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub TotalPlanned()
            Dim decTotalIssue As Decimal = 0D
            Dim decTotalOpen As Decimal = 0D
            Dim decTotalInProgress As Decimal = 0D
            Dim decTotalDevFinish As Decimal = 0D
            Dim decTotalQCPassed As Decimal = 0D
            Dim decTotalFinish As Decimal = 0D
            Dim decProgress As Decimal = 0D
            Dim decPICAssigned As Decimal = 0D

            Dim oBR As New Common.BussinessRules.Issue
            If oBR.SummaryisPlanned(ddlUserIDAssignedToFilter.SelectedValue.Trim, calStartDate.selectedDate, calEndDate.selectedDate, ddlProjectGroupFilter.SelectedValue.Trim).Rows.Count > 0 Then
                decTotalIssue = oBR.totalIssue
                decTotalOpen = oBR.totalOpen
                decTotalInProgress = oBR.totalInProgress
                decTotalDevFinish = oBR.totalDevFinish
                decTotalQCPassed = oBR.totalQCPassed
                decTotalFinish = oBR.totalFinish

                If decTotalIssue = 0 Then
                    decProgress = 100
                Else
                    decProgress = ((decTotalDevFinish + decTotalQCPassed + decTotalFinish) / decTotalIssue) * 100
                End If
            End If
            oBR.Dispose()
            oBR = Nothing

            lblTotalIssue.Text = decTotalIssue.ToString.Trim
            lblTotalOpen.Text = decTotalOpen.ToString.Trim
            lblTotalInProgress.Text = decTotalInProgress.ToString.Trim
            lblTotalDevFinish.Text = decTotalDevFinish.ToString.Trim
            lblTotalQCPassed.Text = decTotalQCPassed.ToString.Trim
            lblTotalFinish.Text = decTotalFinish.ToString.Trim
            lblProgress.Text = Format(decProgress, "##0")
        End Sub

#Region " Link to My Worktime "
        Private Function IsWorkTimeSubmitted() As Boolean
            Dim ToReturnIsWorkTimeSubmitted As Boolean = False
            Dim oWTHd As New Common.BussinessRules.WorkTimeHd
            oWTHd.UserID = MyBase.LoggedOnUserID.Trim
            oWTHd.WorkTimeDate = Date.Today
            If oWTHd.SelectByUserIDWorkTimeDateSubmitted.Rows.Count > 0 Then
                ToReturnIsWorkTimeSubmitted = True
            Else
                ToReturnIsWorkTimeSubmitted = False
            End If
            oWTHd.Dispose()
            oWTHd = Nothing

            Return ToReturnIsWorkTimeSubmitted
        End Function

        Private Function IsAlreadyAddedToWorkTime(ByVal strIssueID As String) As Boolean
            Dim ToReturnIsAlreadyAddedToWorkTime As Boolean = False
            Dim oWTHd As New Common.BussinessRules.WorkTimeDt
            oWTHd.ProjectID = lblProjectID.Text.Trim
            oWTHd.IssueID = strIssueID.Trim
            If oWTHd.SelectByUserIDWorkTimeDateProjectIDIssueID(MyBase.LoggedOnUserID.Trim, Date.Today).Rows.Count > 0 Then
                ToReturnIsAlreadyAddedToWorkTime = True
            Else
                ToReturnIsAlreadyAddedToWorkTime = False
            End If
            oWTHd.Dispose()
            oWTHd = Nothing

            Return ToReturnIsAlreadyAddedToWorkTime
        End Function

        Private Sub InsertWorkTimeHdFromAddEditIssue()
            '// SHOULD BE CHECKED IF EXISTS BY UserID + IssueID + ProjectID + WorkTimeDate
            If IsWorkTimeSubmitted() = True Then
                commonFunction.MsgBox(Me, "Add failed. You have Submitted your today Worktime.")
                Exit Sub
            End If

            If IsAlreadyAddedToWorkTime(lblIssueID.Text.Trim) = True Then
                commonFunction.MsgBox(Me, "Add failed. You have Add this Issue ID to your today Worktime.")
                Exit Sub
            End If

            If txtWorktimeDtDescription.Text.Trim = String.Empty Then
                commonFunction.MsgBox(Me, "Please type in Worktime Description.")
                Exit Sub
            End If

            If IsNumeric(txtWorkTimeInHour.Text.Trim) = False Then
                commonFunction.MsgBox(Me, "Working time must be a number.")
                Exit Sub
            End If

            If CInt(txtWorkTimeInHour.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Working time must be greater than or equal to 0.")
                Exit Sub
            End If

            Dim isNew As Boolean = True
            Dim oWTHd As New Common.BussinessRules.WorkTimeHd
            oWTHd.UserID = MyBase.LoggedOnUserID.Trim
            oWTHd.WorkTimeDate = Date.Today
            isNew = oWTHd.SelectByUserIDWorkTimeDate.Rows.Count = 0
            oWTHd.Remarks = "Follow Up Basecamp Issue"
            oWTHd.IsSubmitted = False
            If isNew Then
                If oWTHd.Insert() Then
                    InsertUpdateWorkTimeDtFromAddEditIssue(oWTHd.WorkTimeHdID.Trim)
                End If
            Else
                InsertUpdateWorkTimeDtFromAddEditIssue(oWTHd.WorkTimeHdID.Trim)
            End If

            oWTHd.Dispose()
            oWTHd = Nothing
        End Sub

        Private Sub InsertWorkTimeHdFromAddEditResponse()
            '// SHOULD BE CHECKED IF EXISTS BY UserID + IssueID + ProjectID + WorkTimeDate
            If IsWorkTimeSubmitted() = True Then
                commonFunction.MsgBox(Me, "Add failed. You have Submitted your today Worktime.")
                Exit Sub
            End If

            If IsAlreadyAddedToWorkTime(Response_lblIssueID.Text.Trim) = True Then
                commonFunction.MsgBox(Me, "Add failed. You have Add this Issue ID to your today Worktime.")
                Exit Sub
            End If

            If Response_txtWorktimeDtDescription.Text.Trim = String.Empty Then
                commonFunction.MsgBox(Me, "Please type in Worktime Description.")
                Exit Sub
            End If

            If IsNumeric(Response_txtWorkTimeInHour.Text.Trim) = False Then
                commonFunction.MsgBox(Me, "Working time must be a number.")
                Exit Sub
            End If

            If CInt(Response_txtWorkTimeInHour.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Working time must be greater than or equal to 0.")
                Exit Sub
            End If

            Dim isNew As Boolean = True
            Dim oWTHd As New Common.BussinessRules.WorkTimeHd
            oWTHd.UserID = MyBase.LoggedOnUserID.Trim
            oWTHd.WorkTimeDate = Date.Today
            isNew = oWTHd.SelectByUserIDWorkTimeDate.Rows.Count = 0
            oWTHd.Remarks = "Follow Up Basecamp Issue"
            oWTHd.IsSubmitted = False
            If isNew Then
                If oWTHd.Insert() Then
                    InsertUpdateWorkTimeDtFromAddEditResponse(oWTHd.WorkTimeHdID.Trim)
                End If
            Else
                InsertUpdateWorkTimeDtFromAddEditResponse(oWTHd.WorkTimeHdID.Trim)
            End If

            oWTHd.Dispose()
            oWTHd = Nothing
        End Sub

        Private Sub InsertUpdateWorkTimeDtFromAddEditIssue(ByVal strWorktimeHdID As String)
            Dim oWTDt As New Common.BussinessRules.WorkTimeDt
            oWTDt.WorkTimeHdID = strWorktimeHdID.Trim
            oWTDt.ProjectID = lblProjectID.Text.Trim
            oWTDt.IssueID = lblIssueID.Text.Trim
            oWTDt.DetailDescription = txtWorktimeDtDescription.Text.Trim
            oWTDt.WorkTimeInHour = CInt(txtWorkTimeInHour.Text.Trim)
            oWTDt.Insert()
            oWTDt.Dispose()
            oWTDt = Nothing
        End Sub

        Private Sub InsertUpdateWorkTimeDtFromAddEditResponse(ByVal strWorktimeHdID As String)
            Dim oWTDt As New Common.BussinessRules.WorkTimeDt
            oWTDt.WorkTimeHdID = strWorktimeHdID.Trim
            oWTDt.ProjectID = Response_lblProjectID.Text.Trim
            oWTDt.IssueID = Response_lblIssueID.Text.Trim
            oWTDt.DetailDescription = Response_txtWorktimeDtDescription.Text.Trim
            oWTDt.WorkTimeInHour = CInt(Response_txtWorkTimeInHour.Text.Trim)
            oWTDt.Insert()
            oWTDt.Dispose()
            oWTDt = Nothing
        End Sub
#End Region
#End Region

    End Class

End Namespace