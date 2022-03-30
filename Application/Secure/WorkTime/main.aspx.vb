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

Namespace QIS.Web.WorkTime
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
                setToolbarVisibleButton()
                prepareDDL()
                PrepareScreen()
            End If
        End Sub

        Private Sub ddlMonth_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlMonth.SelectedIndexChanged
            GetDateInMonth()
        End Sub

        Private Sub txtYear_TextChanged(sender As Object, e As System.EventArgs) Handles txtYear.TextChanged
            GetDateInMonth()
        End Sub

        Private Sub grdDateInMonth_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdDateInMonth.ItemCommand
            Select Case e.CommandName
                Case "SelectDate"
                    Dim _lbtnDateInMonth As LinkButton = CType(e.Item.FindControl("_lbtnDateInMonth"), LinkButton)
                    lblSelectedDate.Text = _lbtnDateInMonth.Text.Trim
                    Dim dd As String = Left(lblSelectedDate.Text, 2)
                    Dim yyyy As String = Right(lblSelectedDate.Text, 4)
                    Dim mmm As String = lblSelectedDate.Text.Substring(3, 3)
                    Dim arMonth() As String = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}
                    Dim numbermm As Integer = Array.IndexOf(arMonth, mmm) + 1
                    Dim mm As String = numbermm.ToString
                    Dim stringDate As String = yyyy + "-" + mm + "-" + dd
                    Dim convertedDate As DateTime = DateTime.Parse(stringDate)
                    lblDayOfWeekSelectedDate.Text = convertedDate.DayOfWeek.ToString + ", "
                    OpenWorkTimeHdByUserIDWorkTimeDate()
            End Select
        End Sub

        Private Sub grdWorkTimeDt_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdWorkTimeDt.ItemCommand
            Select Case e.CommandName
                Case "Delete"
                    DeleteWorkTimeDt(CType(e.Item.FindControl("_lblWorkTimeDtID"), Label).Text.Trim)
            End Select
        End Sub
#End Region

#Region " Support functions for navigation bar (Controls) "
        Private Sub setToolbarVisibleButton()
            With CSSToolbar
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidPrint) = False
                .VisibleButton(CSSToolbarItem.tidPrevious) = False
                .VisibleButton(CSSToolbarItem.tidNext) = False
            End With
        End Sub

        Private Sub mdlToolbar_commandBarClick(ByVal sender As Object, ByVal e As CSSToolbarItem) Handles CSSToolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidDelete
                    DeleteWorkTime()
                Case CSSToolbarItem.tidNew
                    PrepareScreenDt()
                Case CSSToolbarItem.tidSave
                    InsertUpdateWorkTimeHd()
                Case CSSToolbarItem.tidApprove
                    UpdateSubmitWorkTimeHd()
                Case CSSToolbarItem.tidDownload
                    If lblWorkTimeHdID.Text.Trim = String.Empty Or lblWorkTimeHdID.Text.Trim = "0" Then
                        commonFunction.MsgBox(Me, "Nothing to be Downloaded. To download worktime, you must Approve your worktime first.")
                    Else
                        Dim oRPT As New Common.BussinessRules.MyReport
                        oRPT.AddParameters(lblWorkTimeHdID.Text.Trim)
                        oRPT.ReportCode = Common.Constants.ReportID.MyWorktime_ReportID
                        oRPT.GetReportDataByReportCode()
                        If oRPT.ReportFormat = "XLS" Then
                            oRPT.ExportToExcel(oRPT.generateReportDataTable, Response)
                        End If
                        oRPT.Dispose()
                        oRPT = Nothing
                    End If                    
            End Select
        End Sub
#End Region

#Region " Private Functions "
        Private Function ReadQueryString() As Boolean
            
        End Function

        Private Sub prepareDDL()
            commonFunction.SetDDL_Table(ddlMonth, "MonthInYear", String.Empty, False)
            commonFunction.SetDDL_Table(ddlWorkLocation, "CommonCode", Common.Constants.GroupCode.WorkLocation_SCode, False)
            commonFunction.SetDDL_Table(ddlProject, "ProjectProfile", MyBase.LoggedOnProfileID.Trim, True, "- Select Project -")
        End Sub

        Private Sub PrepareScreen()
            lblWorkTimeHdID.Text = String.Empty
            lblWorkTimeDtID.Text = String.Empty
            txtYear.Text = Date.Today.Year.ToString.Trim
            ddlMonth.SelectedValue = Date.Today.Month.ToString.Trim
            lblPageTitle.Text = "My Worktime"
            GetDateInMonth()
            lblDayOfWeekSelectedDate.Text = Date.Today.DayOfWeek.ToString + ", "
            lblSelectedDate.Text = Format(Date.Today, commonFunction.FORMAT_DATE)
            txtRemarks.Text = String.Empty
            chkIsSubmitted.Checked = False
            ddlWorkLocation.SelectedIndex = 0
            ddlProject.SelectedIndex = 0
            txtDetailDescription.Text = String.Empty
            txtIssueID.Text = String.Empty
            txtWorkTimeInHour.Text = "0"
            CSSToolbar.VisibleButton(CSSToolbarItem.tidSave) = True
            CSSToolbar.VisibleButton(CSSToolbarItem.tidDelete) = True
            CSSToolbar.VisibleButton(CSSToolbarItem.tidApprove) = True
            CSSToolbar.VisibleButton(CSSToolbarItem.tidDownload) = False
            OpenWorkTimeHdByUserIDWorkTimeDate()
            commonFunction.Focus(Me, txtRemarks.ClientID)
        End Sub

        Private Sub PrepareScreenDt()
            lblWorkTimeDtID.Text = String.Empty
            ddlProject.SelectedIndex = 0
            txtDetailDescription.Text = String.Empty
            txtIssueID.Text = String.Empty
            txtWorkTimeInHour.Text = "0"
        End Sub

        Private Sub PrepareScreenAfterSubmit()
            CSSToolbar.VisibleButton(CSSToolbarItem.tidSave) = False
            CSSToolbar.VisibleButton(CSSToolbarItem.tidDelete) = False
            CSSToolbar.VisibleButton(CSSToolbarItem.tidApprove) = False
            CSSToolbar.VisibleButton(CSSToolbarItem.tidDownload) = True
            UpdateViewGridWorkTimeDt()
        End Sub

        Private Sub GetDateInMonth()
            Dim oPU As New Common.BussinessRules.Utility
            grdDateInMonth.DataSource = oPU.GetDateInMonth(CInt(txtYear.Text.Trim), CInt(ddlMonth.SelectedValue.Trim), MyBase.LoggedOnUserID)
            grdDateInMonth.DataBind()
            oPU.Dispose()
            oPU = Nothing
        End Sub

        Private Sub UpdateViewGridWorkTimeDt()
            Dim oWTDt As New Common.BussinessRules.WorkTimeDt
            oWTDt.WorkTimeHdID = lblWorkTimeHdID.Text.Trim
            grdWorkTimeDt.DataSource = oWTDt.SelectByWorkTimeHdID
            grdWorkTimeDt.DataBind()
            oWTDt.Dispose()
            oWTDt = Nothing
        End Sub
#End Region

#Region " C,R,U,D "
        Private Sub InsertUpdateWorkTimeHd()
            Page.Validate()
            If Not Page.IsValid Then Exit Sub
            Dim isNew As Boolean = True

            If lblSelectedDate.Text = String.Empty Then
                commonFunction.MsgBox(Me, "Please select date.")
                Exit Sub
            End If

            If ddlProject.SelectedIndex = 0 Then
                commonFunction.MsgBox(Me, "Please select project.")
                Exit Sub
            End If

            If txtDetailDescription.Text.Trim = String.Empty Then
                commonFunction.MsgBox(Me, "Please type in description.")
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

            Dim oWTHd As New Common.BussinessRules.WorkTimeHd
            oWTHd.WorkTimeHdID = lblWorkTimeHdID.Text.Trim
            If oWTHd.SelectOne.Rows.Count > 0 Then
                isNew = False
            Else
                isNew = True
            End If
            oWTHd.UserID = MyBase.LoggedOnUserID
            oWTHd.WorkTimeDate = CDate(lblSelectedDate.Text.Trim)
            oWTHd.Remarks = txtRemarks.Text.Trim
            oWTHd.WorkLocationGCID = ddlWorkLocation.SelectedItem.Value.Trim
            oWTHd.IsSubmitted = False
            If isNew Then
                If oWTHd.Insert() Then
                    lblWorkTimeHdID.Text = oWTHd.WorkTimeHdID.Trim
                    InsertUpdateWorkTimeDt(oWTHd.WorkTimeHdID.Trim)
                End If
            Else
                If oWTHd.Update() Then
                    InsertUpdateWorkTimeDt(lblWorkTimeHdID.Text.Trim)
                End If
            End If
            oWTHd.Dispose()
            oWTHd = Nothing
        End Sub

        Private Sub InsertUpdateWorkTimeDt(ByVal strWorktimeHdID As String)
            Dim isNew As Boolean = True

            Dim oWTDt As New Common.BussinessRules.WorkTimeDt
            oWTDt.WorkTimeDtID = lblWorkTimeDtID.Text.Trim
            If oWTDt.SelectOne.Rows.Count > 0 Then
                isNew = False
            Else
                isNew = True
            End If
            oWTDt.WorkTimeHdID = strWorktimeHdID.Trim
            oWTDt.ProjectID = ddlProject.SelectedValue.Trim
            oWTDt.IssueID = txtIssueID.Text.Trim
            oWTDt.DetailDescription = txtDetailDescription.Text.Trim
            oWTDt.WorkTimeInHour = CInt(txtWorkTimeInHour.Text.Trim)
            If isNew Then
                oWTDt.Insert()
            Else
                oWTDt.Update()
            End If
            oWTDt.Dispose()
            oWTDt = Nothing

            PrepareScreenDt()
            UpdateViewGridWorkTimeDt()
        End Sub

        Private Sub UpdateSubmitWorkTimeHd()
            Page.Validate()
            If Not Page.IsValid Then Exit Sub
            
            Dim oWTHd As New Common.BussinessRules.WorkTimeHd
            oWTHd.WorkTimeHdID = lblWorkTimeHdID.Text.Trim
            If oWTHd.SelectOne.Rows.Count = 0 Then
                commonFunction.MsgBox(Me, "Nothing to Submit.")
                Exit Sub
            End If
            oWTHd.UserID = MyBase.LoggedOnUserID
            oWTHd.IsSubmitted = True
            If oWTHd.UpdateSubmit() Then
                PrepareScreenAfterSubmit()
                GetDateInMonth()                
            End If
            oWTHd.Dispose()
            oWTHd = Nothing
        End Sub

        Private Sub OpenWorkTimeHdByUserIDWorkTimeDate()
            Dim oWT As New Common.BussinessRules.WorkTimeHd
            oWT.UserID = MyBase.LoggedOnUserID
            oWT.WorkTimeDate = CDate(lblSelectedDate.Text)
            If oWT.SelectByUserIDWorkTimeDate.Rows.Count > 0 Then
                lblWorkTimeHdID.Text = oWT.WorkTimeHdID.Trim
                txtRemarks.Text = oWT.Remarks.Trim
                ddlWorkLocation.SelectedValue = oWT.WorkLocationGCID.Trim
                chkIsSubmitted.Checked = oWT.IsSubmitted
            Else
                lblWorkTimeHdID.Text = String.Empty
                txtRemarks.Text = String.Empty
                ddlWorkLocation.SelectedIndex = 0
                chkIsSubmitted.Checked = False
            End If
            oWT.Dispose()
            oWT = Nothing
            PrepareScreenDt()
            UpdateViewGridWorkTimeDt()

            If chkIsSubmitted.Checked Then
                CSSToolbar.VisibleButton(CSSToolbarItem.tidSave) = False
                CSSToolbar.VisibleButton(CSSToolbarItem.tidDelete) = False
                CSSToolbar.VisibleButton(CSSToolbarItem.tidApprove) = False
                CSSToolbar.VisibleButton(CSSToolbarItem.tidDownload) = True
            Else
                CSSToolbar.VisibleButton(CSSToolbarItem.tidSave) = True
                CSSToolbar.VisibleButton(CSSToolbarItem.tidDelete) = True
                CSSToolbar.VisibleButton(CSSToolbarItem.tidApprove) = True
                CSSToolbar.VisibleButton(CSSToolbarItem.tidDownload) = False
            End If
        End Sub

        Private Sub DeleteWorkTime()
            Dim oWTHd As New Common.BussinessRules.WorkTimeHd
            oWTHd.WorkTimeHdID = lblWorkTimeHdID.Text.Trim
            oWTHd.Delete()
            oWTHd.Dispose()
            oWTHd = Nothing
            PrepareScreen()
            UpdateViewGridWorkTimeDt()
        End Sub

        Private Sub DeleteWorkTimeDt(ByVal strWorkTimeDtID As String)
            Dim oWTDt As New Common.BussinessRules.WorkTimeDt
            oWTDt.WorkTimeDtID = strWorkTimeDtID.Trim
            oWTDt.Delete()
            oWTDt.Dispose()
            oWTDt = Nothing
            UpdateViewGridWorkTimeDt()
        End Sub
#End Region

    End Class

End Namespace