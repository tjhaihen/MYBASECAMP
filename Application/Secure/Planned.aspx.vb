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
            If Not Me.IsPostBack Then
                setToolbarVisibleButton()
                prepareDDL()
                PrepareScreen()

                SetDataGrid()
                TotalPlanned()
                'If ReadQueryString() Then

                pnlAddNew.Visible = False
                pnlIssueResponse.Visible = False
                GetTasksByUserID()
                'End If
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

        '--percobaan
        Private Sub btnClose_Click(sender As Object, e As System.EventArgs) Handles btnClose.Click
            PrepareScreenAddNew()
            'SetDataGrid()
            pnlAddNew.Visible = False
        End Sub

        '--percobaan
        Private Sub btnSaveAndClose_Click(sender As Object, e As System.EventArgs) Handles btnSaveAndClose.Click
            _updateIssue()
            PrepareScreenAddNew()
            pnlAddNew.Visible = False
            SetDataGrid()
        End Sub

        '--percobaan
        Private Sub Response_btnClose_Click(sender As Object, e As System.EventArgs) Handles Response_btnClose.Click
            PrepareScreenIssueResponse()
            'SetDataGrid()
            pnlIssueResponse.Visible = False
        End Sub

        '--percobaan
        Private Sub Response_btnSaveAndClose_Click(sender As Object, e As System.EventArgs) Handles Response_btnSaveAndClose.Click
            _updateIssueResponse()
            PrepareScreenIssueResponse()
            pnlIssueResponse.Visible = False
            SetDataGridIssueResponse()
            SetDataGrid()
        End Sub

        '--percobaan 
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
                    PrepareScreenIssueResponse()
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
                .VisibleButton(CSSToolbarItem.tidDownload) = False
            End With
        End Sub

        Private Sub mdlToolbar_commandBarClick(ByVal sender As Object, ByVal e As CSSToolbarItem) Handles CSSToolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidRefresh
                    SetDataGrid()
            End Select
        End Sub
#End Region

#Region " Private Functions "
        Private Function ReadQueryString() As Boolean

        End Function

        Private Sub SetDataGrid()
            'Dim decTotalIssue As Decimal = 0D
            'Dim decTotalOpen As Decimal = 0D
            'Dim decTotalDevFinish As Decimal = 0D
            'Dim decTotalFinish As Decimal = 0D
            'Dim decProgress As Decimal = 0D

            Dim oBR As New Common.BussinessRules.Issue
            Dim oDT As New DataTable
            grdIssueByFilter.DataSource = oBR.SelectByPlanned(Me.LoggedOnUserID.Trim, calStartDate.selectedDate, calEndDate.selectedDate, chkIsAssignedToMe.Checked)
            grdIssueByFilter.DataBind()
            oBR.Dispose()
            oBR = Nothing

            'If oBR.SummaryisPlanned(calStartDate.selectedDate, calEndDate.selectedDate, chkIsAssignedToMe.Checked).Rows.Count > 0 Then
            '    decTotalIssue = oBR.totalIssue
            '    decTotalOpen = oBR.totalOpen
            '    decTotalDevFinish = oBR.totalDevFinish
            '    decTotalFinish = oBR.totalFinish

            '    If decTotalIssue = 0 Then
            '        decProgress = 100
            '    Else
            '        decProgress = (decTotalFinish / decTotalIssue) * 100
            '    End If
            'End If
            'oBR.Dispose()
            'oBR = Nothing

            'lblTotalIssue.Text = decTotalIssue.ToString.Trim
            'lblTotalOpen.Text = decTotalOpen.ToString.Trim
            'lblTotalDevFinish.Text = decTotalDevFinish.ToString.Trim
            'lblTotalFinish.Text = decTotalFinish.ToString.Trim
            'lblProgress.Text = Format(decProgress, "##0")
        End Sub

        'Private Sub chkIsAssignedToMe_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkIsAssignedToMe.CheckedChanged
        '    SetDataGrid()
        'End Sub

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
            'commonFunction.SetDDL_Table(ddlProjectFilter, "ProjectUser", MyBase.LoggedOnUserID.Trim, True, "All Project", "All")
            'commonFunction.SetDDL_Table(ddlIssueTypeFilter, "CommonCode", Common.Constants.GroupCode.IssueType_SCode, True, "All Type", "All")
            'commonFunction.SetDDL_Table(ddlIssueStatusFilter, "CommonCode", Common.Constants.GroupCode.IssueStatus_SCode, True, "All Status", "All")
            'commonFunction.SetDDL_Table(ddlIssuePriorityFilter, "CommonCode", Common.Constants.GroupCode.IssuePriority_SCode, True, "All Priority", "All")
            'commonFunction.SetDDL_Table(ddlIssueConfirmStatusFilter, "CommonCode", Common.Constants.GroupCode.IssueConfirmStatus_SCode, True, "All Confirm Status", "All")
            'commonFunction.SetDDL_Table(ddlUserIDAssignedToFilter, "User", String.Empty, True, "Everyone", "All")
            commonFunction.SetDDL_Table(ddlIssueType, "CommonCode", Common.Constants.GroupCode.IssueType_SCode, True, "Not Set", "All")
            commonFunction.SetDDL_Table(ddlIssueStatus, "CommonCode", Common.Constants.GroupCode.IssueStatus_SCode, True, "Not Set", "All")
            commonFunction.SetDDL_Table(ddlIssuePriority, "CommonCode", Common.Constants.GroupCode.IssuePriority_SCode, True, "Not Set", "All")
            commonFunction.SetDDL_Table(ddlIssueConfirmStatus, "CommonCode", Common.Constants.GroupCode.IssueConfirmStatus_SCode, True, "Not Set", "All")
            commonFunction.SetDDL_Table(ddlUserIDAssignedTo, "User", String.Empty)
        End Sub

        Private Sub PrepareScreen()
            calStartDate.selectedDate = GetFirstDayForWeek(Date.Today, False)
            calEndDate.selectedDate = GetLastDayForWeek(Date.Today, False)
            chkIsAssignedToMe.Checked = False
        End Sub

        '--percobaan
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
            commonFunction.Focus(Me, txtDepartmentName.ClientID)
        End Sub

        Private Sub PrepareScreenIssueResponse()
            Response_calResponseDate.selectedDate = Date.Today
            Response_txtResponseDescription.Text = String.Empty
            commonFunction.Focus(Me, Response_txtResponseDescription.ClientID)
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
#End Region

#Region " C,R,U,D "
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

        '--percobaan
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

        '--percobaan
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

        '--percobaan
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

        Private Sub TotalPlanned()
            Dim decTotalIssue As Decimal = 0D
            Dim decTotalOpen As Decimal = 0D
            Dim decTotalDevFinish As Decimal = 0D
            Dim decTotalFinish As Decimal = 0D
            Dim decProgress As Decimal = 0D
            Dim decPICAssigned As Decimal = 0D

            Dim oBR As New Common.BussinessRules.Issue
            If oBR.SummaryisPlanned(Me.LoggedOnUserID.Trim, calStartDate.selectedDate, calEndDate.selectedDate, chkIsAssignedToMe.Checked).Rows.Count > 0 Then
                decTotalIssue = oBR.totalIssue
                decTotalOpen = oBR.totalOpen
                decTotalDevFinish = oBR.totalDevFinish
                decTotalFinish = oBR.totalFinish
                decPICAssigned = oBR.PICAssigned


                If decTotalIssue = 0 Then
                    decProgress = 100
                Else
                    decProgress = (decTotalFinish / decTotalIssue) * 100
                End If
            End If
            oBR.Dispose()
            oBR = Nothing

            lblTotalIssue.Text = decTotalIssue.ToString.Trim
            lblTotalOpen.Text = decTotalOpen.ToString.Trim
            lblTotalDevFinish.Text = decTotalDevFinish.ToString.Trim
            lblTotalFinish.Text = decTotalFinish.ToString.Trim
            lblProgress.Text = Format(decProgress, "##0")
            lblPICAssigned.Text = decPICAssigned.ToString.Trim
        End Sub
#End Region

        Private Sub chkIsAssignedToMe_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkIsAssignedToMe.CheckedChanged
            SetDataGrid()
            TotalPlanned()
        End Sub
    End Class

End Namespace

'Public Class Myday
'    Inherits System.Web.UI.Page

'    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

'    End Sub

'End Class