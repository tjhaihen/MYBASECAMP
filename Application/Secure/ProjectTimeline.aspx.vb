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
    Public Class ProjectTimeline
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

                If ReadQueryString() Then
                    _openProject()
                    SetDataGrid()
                End If
            End If
        End Sub

        Private Sub lbtnMyProjects_Click(sender As Object, e As System.EventArgs) Handles lbtnMyProjects.Click, ibtnMyProjects.Click
            Response.Write("<script language=javascript>window.location.replace('" + PageBase.UrlBase + "/secure/Main.aspx" + "')</script>")
        End Sub

        Private Sub lbtnMyDay_Click(sender As Object, e As System.EventArgs) Handles lbtnMyDay.Click, lbtnMyDay.Click
            Response.Write("<script language=javascript>window.location.replace('" + PageBase.UrlBase + "/secure/Myday.aspx')</script>")
        End Sub

        Private Sub lbtnPlanned_Click(sender As Object, e As System.EventArgs) Handles lbtnPlanned.Click, lbtnPlanned.Click
            Response.Write("<script language=javascript>window.location.replace('" + PageBase.UrlBase + "/secure/Planned.aspx')</script>")
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

        Private Sub btnClose_Click(sender As Object, e As System.EventArgs) Handles btnClose.Click
            PrepareScreenAddNew()
            pnlAddNew.Visible = False
            SetDataGrid()
        End Sub

        Private Sub btnSaveOnly_Click(sender As Object, e As System.EventArgs) Handles btnSaveOnly.Click
            _updateProjectTimeline()
            SetDataGrid()
        End Sub

        Private Sub btnSaveAndNew_Click(sender As Object, e As System.EventArgs) Handles btnSaveAndNew.Click
            _updateProjectTimeline()
            PrepareScreenAddNew()
            SetDataGrid()
        End Sub

        Private Sub btnSaveAndClose_Click(sender As Object, e As System.EventArgs) Handles btnSaveAndClose.Click
            _updateProjectTimeline()
            PrepareScreenAddNew()

            pnlAddNew.Visible = False
            SetDataGrid()
        End Sub

        Private Sub SubTask_btnClose_Click(sender As Object, e As System.EventArgs) Handles SubTask_btnClose.Click
            PrepareScreenSubTask()
            pnlSubTask.Visible = False
            SetDataGridSubTask(SubTask_lblProjectTimelineID.Text.Trim)
            SetDataGrid()
        End Sub

        Private Sub SubTask_btnSaveAndNew_Click(sender As Object, e As System.EventArgs) Handles SubTask_btnSaveAndNew.Click
            _updateSubTask()
            PrepareScreenSubTask()
            SetDataGridSubTask(SubTask_lblProjectTimelineID.Text.Trim)
            SetDataGrid()
        End Sub

        Private Sub SubTask_btnSaveAndClose_Click(sender As Object, e As System.EventArgs) Handles SubTask_btnSaveAndClose.Click
            _updateSubTask()
            PrepareScreenSubTask()

            pnlSubTask.Visible = False
            SetDataGridSubTask(SubTask_lblProjectTimelineID.Text.Trim)
            SetDataGrid()
        End Sub

        Private Sub grdProjectTimeline_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdProjectTimeline.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    PrepareScreenSubTask()
                    pnlSubTask.Visible = False

                    Dim _lbtnProjectTimelineID As LinkButton = CType(e.Item.FindControl("_lbtnProjectTimelineID"), LinkButton)
                    pnlAddNew.Visible = True
                    PrepareScreenAddNew()
                    lblProjectTimelineID.Text = _lbtnProjectTimelineID.Text.Trim
                    _openProjectTimeline(lblProjectTimelineID.Text.Trim)
                    SetDataGrid()

                Case "ProjectTimelineSubTask"
                    PrepareScreenAddNew()
                    pnlAddNew.Visible = False

                    Dim _lbtnProjectTimelineID As LinkButton = CType(e.Item.FindControl("_lbtnProjectTimelineID"), LinkButton)
                    pnlSubTask.Visible = True
                    PrepareScreenSubTask()
                    SubTask_lblProjectTimelineID.Text = _lbtnProjectTimelineID.Text.Trim
                    _openProjectTimeline(SubTask_lblProjectTimelineID.Text.Trim, True)
                    SetDataGridSubTask(_lbtnProjectTimelineID.Text.Trim)

            End Select
        End Sub

        Private Sub grdProjectTimeline_ItemCreated(sender As Object, e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdProjectTimeline.ItemCreated
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim _lblSequenceNo As Label = CType(e.Item.FindControl("_lblSequenceNo"), Label)
                Dim _lblTask As Label = CType(e.Item.FindControl("_lblTask"), Label)
                Dim drv As DataRowView = CType(e.Item.DataItem, DataRowView)
                If Not drv Is Nothing Then
                    Dim dr As DataRow = drv.Row
                    If Not dr Is Nothing Then
                        Dim IsHasChild As Boolean = CBool(dr("IsHasChild"))

                        If IsHasChild Then
                            _lblSequenceNo.Font.Bold = True
                            _lblTask.Font.Bold = True
                        Else
                            _lblSequenceNo.Font.Bold = False
                            _lblTask.Font.Bold = False
                        End If
                    End If
                End If
            End If
        End Sub

        Private Sub grdProjectTimelineSubTask_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdProjectTimelineSubTask.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    Dim _lblProjectTimelineSubTaskID As Label = CType(e.Item.FindControl("_lblProjectTimelineSubTaskID"), Label)
                    SubTask_lblProjectTimelineSubTaskID.Text = _lblProjectTimelineSubTaskID.Text.Trim
                    _openSubTask(SubTask_lblProjectTimelineSubTaskID.Text.Trim)

            End Select
        End Sub
#End Region

#Region " Support functions for navigation bar (Controls) "
        Private Sub setToolbarVisibleButton()
            With CSSToolbar
                .VisibleButton(CSSToolbarItem.tidSave) = False
                .VisibleButton(CSSToolbarItem.tidDelete) = False
                .VisibleButton(CSSToolbarItem.tidApprove) = False
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidPrint) = False
                .VisibleButton(CSSToolbarItem.tidPrevious) = False
                .VisibleButton(CSSToolbarItem.tidNext) = False
            End With
        End Sub

        Private Sub mdlToolbar_commandBarClick(ByVal sender As Object, ByVal e As CSSToolbarItem) Handles CSSToolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidNew
                    pnlAddNew.Visible = True
                    PrepareScreenAddNew()
                    PrepareScreenSubTask()
                    pnlSubTask.Visible = False
            End Select
        End Sub
#End Region

#Region " Private Functions "
        Private Function ReadQueryString() As Boolean
            lblProjectID.Text = Request.QueryString("projectID")
            lblPageTitle.Text = "Project Timeline"
            Return lblProjectID.Text.Trim.Length > 0
        End Function

        Private Sub SetDataGrid()
            Dim oBR As New Common.BussinessRules.ProjectTimeline
            oBR.ProjectID = lblProjectID.Text.Trim
            grdProjectTimeline.DataSource = oBR.SelectByProjectID()
            grdProjectTimeline.DataBind()
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub SetDataGridSubTask(ByVal strProjectTimelineID As String)
            Dim oBR As New Common.BussinessRules.ProjectTimelineSubTask
            oBR.ProjectTimelineID = strProjectTimelineID.Trim
            grdProjectTimelineSubTask.DataSource = oBR.SelectByProjectTimelineID()
            grdProjectTimelineSubTask.DataBind()
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub prepareDDL()
            commonFunction.SetDDL_Table(ddlUserIDPIC, "UserActive", String.Empty, True, "Not Set")
            commonFunction.SetDDL_Table(ddlTaskStatus, "CommonCode", Common.Constants.GroupCode.IssueStatus_SCode, True, "Not Set")
            commonFunction.SetDDL_Table(SubTask_ddlUserIDPIC, "UserActive", String.Empty, True, "Not Set")
            commonFunction.SetDDL_Table(SubTask_ddlSubTaskStatus, "CommonCode", Common.Constants.GroupCode.IssueStatus_SCode, True, "Not Set")
        End Sub

        Private Sub PrepareScreen()
            PrepareScreenAddNew()
            pnlAddNew.Visible = False
            pnlSubTask.Visible = False
            SetDataGrid()
        End Sub

        Private Sub PrepareScreenAddNew()
            lblProjectTimelineID.Text = String.Empty
            txtSequenceNo.Text = String.Empty
            txtPredecessorSequenceNo.Text = String.Empty
            txtTask.Text = String.Empty
            txtTaskDescription.Text = String.Empty
            calStartDateScheduled.selectedDate = Date.Today
            calEndDateScheduled.selectedDate = Date.Today
            txtStartTimeScheduled.Text = "00:00"
            txtEndTimeScheduled.Text = "00:00"
            calStartDateRealized.selectedDate = Nothing
            calEndDateRealized.selectedDate = Nothing
            txtStartTimeRealized.Text = "00:00"
            txtEndTimeRealized.Text = "00:00"
            ddlUserIDPIC.SelectedIndex = 0
            ddlTaskStatus.SelectedIndex = 0

            commonFunction.Focus(Me, txtSequenceNo.ClientID)
        End Sub

        Private Sub PrepareScreenSubTask()
            SubTask_lblProjectTimelineSubTaskID.Text = String.Empty
            SubTask_txtSequenceNo.Text = String.Empty
            SubTask_txtSubTask.Text = String.Empty
            SubTask_txtSubTaskDescription.Text = String.Empty
            SubTask_calStartDateScheduled.selectedDate = Date.Today
            SubTask_calEndDateScheduled.selectedDate = Date.Today
            SubTask_txtStartTimeScheduled.Text = "00:00"
            SubTask_txtEndTimeScheduled.Text = "00:00"
            SubTask_calStartDateRealized.selectedDate = Nothing
            SubTask_calEndDateRealized.selectedDate = Nothing
            SubTask_txtStartTimeRealized.Text = "00:00"
            SubTask_txtEndTimeRealized.Text = "00:00"
            SubTask_ddlUserIDPIC.SelectedIndex = 0
            SubTask_ddlSubTaskStatus.SelectedIndex = 0

            commonFunction.Focus(Me, SubTask_txtSequenceNo.ClientID)
        End Sub

        Private Function IsPredecessorProjectTimelineExist(ByVal strProjectID As String, ByVal strSequenceNo As String) As Boolean
            Dim isExist As Boolean = False
            Dim oBr As New Common.BussinessRules.ProjectTimeline
            With oBr
                .ProjectID = lblProjectID.Text.Trim
                .SequenceNo = txtPredecessorSequenceNo.Text.Trim
                If .SelectByProjectIDSequenceNo.Rows.Count > 0 Then
                    isExist = True
                Else
                    isExist = False
                End If
            End With
            oBr.Dispose()
            oBr = Nothing
            Return isExist
        End Function
#End Region

#Region " C,R,U,D "
        Private Sub _openProject()
            Dim oBR As New Common.BussinessRules.Project
            With oBR
                .ProjectID = lblProjectID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    lblProjectAliasName.Text = .ProjectAliasName.Trim
                    lblProjectName.Text = .ProjectName.Trim
                    lblProjectDescription.Text = .ProjectDescription.Trim
                    lblLastPatchNo.Text = .lastPatchNo.Trim
                    lblProjectCreatedDate.Text = Format(.insertDate, commonFunction.FORMAT_DATETIME)
                    lblProjectLastUpdatedDate.Text = .lastProjectUpdateDate.Trim
                Else
                    lblProjectAliasName.Text = String.Empty
                    lblProjectName.Text = String.Empty
                    lblProjectDescription.Text = String.Empty
                    lblLastPatchNo.Text = "-"
                    lblProjectCreatedDate.Text = "-"
                    lblProjectLastUpdatedDate.Text = "-"
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub _openProjectTimeline(ByVal strProjectTimelineID As String, Optional ByVal IsSubTask As Boolean = False)
            Dim oBr As New Common.BussinessRules.ProjectTimeline
            With oBr
                .ProjectTimelineID = strProjectTimelineID.Trim
                If .SelectOne.Rows.Count > 0 Then
                    If IsSubTask = False Then
                        txtSequenceNo.Text = .SequenceNo.Trim
                        txtPredecessorSequenceNo.Text = .SequencePredecessorNo.Trim
                        txtTask.Text = .Task.Trim
                        txtTaskDescription.Text = .TaskDescription.Trim
                        calStartDateScheduled.selectedDate = .StartDateScheduled
                        calEndDateScheduled.selectedDate = .EndDateScheduled
                        txtStartTimeScheduled.Text = .StartTimeScheduled.Trim
                        txtEndTimeScheduled.Text = .EndTimeScheduled.Trim
                        ddlUserIDPIC.SelectedValue = .UserIDPIC.Trim
                        ddlTaskStatus.SelectedValue = .TaskStatusSCode.Trim
                        commonFunction.Focus(Me, txtTask.ClientID)
                    Else
                        SubTask_lblSequenceNo.Text = .SequenceNo.Trim
                        SubTask_lblTask.Text = .Task.Trim
                        SubTask_lblStartDateScheduled.Text = Format(.StartDateScheduled, commonFunction.FORMAT_DATE)
                        SubTask_lblEndDateScheduled.Text = Format(.EndDateScheduled, commonFunction.FORMAT_DATE)
                        SubTask_lblStartDateRealized.Text = .StartDateRealizedInString.Trim
                        SubTask_lblEndDateRealized.Text = .EndDateRealizedInString.Trim
                        commonFunction.Focus(Me, SubTask_txtSequenceNo.ClientID)
                    End If                    
                Else
                    If IsSubTask = False Then
                        PrepareScreenAddNew()
                    Else
                        PrepareScreenSubTask()
                    End If
                End If
            End With
            oBr.Dispose()
            oBr = Nothing
        End Sub

        Private Sub _updateProjectTimeline()
            Page.Validate()
            If Not Page.IsValid Then Exit Sub

            If txtPredecessorSequenceNo.Text.Trim <> String.Empty And IsPredecessorProjectTimelineExist(lblProjectID.Text.Trim, txtPredecessorSequenceNo.Text.Trim) = False Then
                commonFunction.MsgBox(Me, "The predecessor you entered does not exists.")
                commonFunction.Focus(Me, txtPredecessorSequenceNo.ClientID)
                Exit Sub
            End If

            '... more validations should be in here...
            '... start and end date scheduled must be validated within predecessor            

            Dim fNew As Boolean = False
            Dim oBr As New Common.BussinessRules.ProjectTimeline
            With oBr
                .ProjectTimelineID = lblProjectTimelineID.Text.Trim
                fNew = .SelectOne.Rows.Count = 0
                .ProjectID = lblProjectID.Text.Trim
                .SequenceNo = txtSequenceNo.Text.Trim
                .SequencePredecessorNo = txtPredecessorSequenceNo.Text.Trim
                .Task = txtTask.Text.Trim
                .TaskDescription = txtTaskDescription.Text.Trim
                .StartDateScheduled = calStartDateScheduled.selectedDate
                .StartTimeScheduled = txtStartTimeScheduled.Text.Trim
                .EndDateScheduled = calEndDateScheduled.selectedDate
                .EndTimeScheduled = txtEndTimeScheduled.Text.Trim
                If calStartDateRealized.selectedDate = Nothing Then
                    .StartDateRealized = Nothing
                Else
                    .StartDateRealized = calStartDateRealized.selectedDate
                End If
                If txtStartTimeRealized.Text.Trim = String.Empty Then
                    .StartTimeRealized = Nothing
                Else
                    .StartTimeRealized = txtStartTimeRealized.Text.Trim
                End If
                If calEndDateRealized.selectedDate = Nothing Then
                    .EndDateRealized = Nothing
                Else
                    .EndDateRealized = calEndDateRealized.selectedDate
                End If
                If txtEndTimeRealized.Text.Trim = String.Empty Then
                    .EndTimeRealized = Nothing
                Else
                    .EndTimeRealized = txtEndTimeRealized.Text.Trim
                End If
                .UserIDPIC = ddlUserIDPIC.SelectedValue.Trim
                .TaskStatusSCode = ddlTaskStatus.SelectedValue.Trim
                .userIDinsert = MyBase.LoggedOnUserID.Trim
                .userIDupdate = MyBase.LoggedOnUserID.Trim
                If fNew Then
                    .Insert()
                Else
                    .Update()
                End If
            End With
            oBr.Dispose()
            oBr = Nothing
        End Sub

        Private Sub _openSubTask(ByVal strProjectTimelineSubTaskID As String)
            Dim oBr As New Common.BussinessRules.ProjectTimelineSubTask
            With oBr
                .ProjectTimelineSubTaskID = strProjectTimelineSubTaskID.Trim
                If .SelectOne.Rows.Count > 0 Then
                    SubTask_txtSequenceNo.Text = .SequenceNo.Trim
                    SubTask_txtSubTask.Text = .SubTask.Trim
                    SubTask_txtSubTaskDescription.Text = .SubTaskDescription.Trim
                    SubTask_calStartDateScheduled.selectedDate = .StartDateScheduled
                    SubTask_calEndDateScheduled.selectedDate = .EndDateScheduled
                    SubTask_txtStartTimeScheduled.Text = .StartTimeScheduled.Trim
                    SubTask_txtEndTimeScheduled.Text = .EndTimeScheduled.Trim
                    SubTask_ddlUserIDPIC.SelectedValue = .UserIDPIC.Trim
                    SubTask_ddlSubTaskStatus.SelectedValue = .SubTaskStatusSCode.Trim
                    commonFunction.Focus(Me, SubTask_txtSubTask.ClientID)
                Else
                    PrepareScreenSubTask()
                End If
            End With
            oBr.Dispose()
            oBr = Nothing
        End Sub

        Private Sub _updateSubTask()
            Page.Validate()
            If Not Page.IsValid Then Exit Sub

            '... more validations should be in here...
            '... start and end date scheduled must be validated (only >= StartDateScheduled from Timeline)
            If SubTask_calStartDateScheduled.selectedDate < CDate(SubTask_lblStartDateScheduled.Text.Trim) Then
                commonFunction.MsgBox(Me, "Sub Task cannot be started earlier than main task.")
                commonFunction.Focus(Me, SubTask_txtSequenceNo.ClientID)
                Exit Sub
            End If

            Dim fNew As Boolean = False
            Dim oBr As New Common.BussinessRules.ProjectTimelineSubTask
            With oBr
                .ProjectTimelineSubTaskID = SubTask_lblProjectTimelineSubTaskID.Text.Trim
                fNew = .SelectOne.Rows.Count = 0
                .ProjectTimelineID = SubTask_lblProjectTimelineID.Text.Trim
                .SequenceNo = SubTask_txtSequenceNo.Text.Trim
                .SubTask = SubTask_txtSubTask.Text.Trim
                .SubTaskDescription = SubTask_txtSubTaskDescription.Text.Trim
                .StartDateScheduled = SubTask_calStartDateScheduled.selectedDate
                .StartTimeScheduled = SubTask_txtStartTimeScheduled.Text.Trim
                .EndDateScheduled = SubTask_calEndDateScheduled.selectedDate
                .EndTimeScheduled = SubTask_txtEndTimeScheduled.Text.Trim
                If SubTask_calStartDateRealized.selectedDate = Nothing Then
                    .StartDateRealized = Nothing
                Else
                    .StartDateRealized = SubTask_calStartDateRealized.selectedDate
                End If
                If SubTask_txtStartTimeRealized.Text.Trim = String.Empty Then
                    .StartTimeRealized = Nothing
                Else
                    .StartTimeRealized = SubTask_txtStartTimeRealized.Text.Trim
                End If
                If SubTask_calEndDateRealized.selectedDate = Nothing Then
                    .EndDateRealized = Nothing
                Else
                    .EndDateRealized = SubTask_calEndDateRealized.selectedDate
                End If
                If SubTask_txtEndTimeRealized.Text.Trim = String.Empty Then
                    .EndTimeRealized = Nothing
                Else
                    .EndTimeRealized = SubTask_txtEndTimeRealized.Text.Trim
                End If
                .UserIDPIC = SubTask_ddlUserIDPIC.SelectedValue.Trim
                .SubTaskStatusSCode = SubTask_ddlSubTaskStatus.SelectedValue.Trim
                .userIDinsert = MyBase.LoggedOnUserID.Trim
                .userIDupdate = MyBase.LoggedOnUserID.Trim
                If fNew Then
                    .Insert()
                Else
                    .Update()
                End If
            End With
            oBr.Dispose()
            oBr = Nothing
        End Sub
#End Region
    End Class

End Namespace