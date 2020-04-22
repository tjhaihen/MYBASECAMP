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

Namespace QIS.Web.Secure

    Public Class Activity
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
        Private MenuID As String = Common.Constants.MenuID.Progress_MenuID
#End Region


#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Me.IsPostBack Then
            Else
                CSSToolbar.ProfileID = MyBase.LoggedOnProfileID
                CSSToolbar.MenuID = MenuID.Trim
                CSSToolbar.setAuthorizationToolbar()
                setToolbarVisibleButton()

                prepareDDL()
                prepareScreen(True)
                DataBind()
            End If
        End Sub

        Private Sub ddlPeriod_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlPeriod.SelectedIndexChanged
            Select Case ddlPeriod.SelectedValue.Trim
                Case "ThisWeek"
                    'pnlCustomPeriod.Visible = False
                    calStartDate.selectedDate = GetFirstDayForWeek(Date.Today, False)
                    calEndDate.selectedDate = Date.Today
                Case "LastWeek"
                    'pnlCustomPeriod.Visible = False
                    calStartDate.selectedDate = GetFirstDayForWeek(Date.Today, True)
                    calEndDate.selectedDate = GetLastDayForWeek(Date.Today, True)
                Case "ThisMonth"
                    'pnlCustomPeriod.Visible = False
                    calStartDate.selectedDate = DateSerial(Date.Today.Year, Date.Today.Month, 1)
                    calEndDate.selectedDate = DateSerial(Date.Today.Year, Date.Today.Month + 1, 1 - 1)
                Case "LastMonth"
                    'pnlCustomPeriod.Visible = False
                    calStartDate.selectedDate = DateSerial(Date.Today.Year, Date.Today.Month - 1, 1)
                    calEndDate.selectedDate = DateSerial(Date.Today.Year, Date.Today.Month - 1 + 1, 1 - 1)
                Case Else
                    pnlCustomPeriod.Visible = True
                    calStartDate.selectedDate = Date.Today
                    calEndDate.selectedDate = Date.Today
            End Select
        End Sub

        Protected Sub repProgressPeriod_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repProgressPeriod.ItemDataBound
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim row As DataRowView = CType(e.Item.DataItem, DataRowView)
                Dim repProgressPeriod_Contributor As Repeater = CType(e.Item.FindControl("repProgressPeriod_Contributor"), Repeater)
                Dim pnlProgressDescription As Panel = CType(e.Item.FindControl("pnlProgressDescription"), Panel)
                Dim pnlNoActivity As Panel = CType(e.Item.FindControl("pnlNoActivity"), Panel)

                Dim dtProgressPeriodContributor As DataTable = Me.GetProgressPeriod_Level2(row("ProgressDate").ToString.Trim)
                If dtProgressPeriodContributor.Rows.Count > 0 Then
                    pnlProgressDescription.Visible = True
                    pnlNoActivity.Visible = False
                    repProgressPeriod_Contributor.DataSource = dtProgressPeriodContributor
                    repProgressPeriod_Contributor.DataBind()
                Else
                    pnlProgressDescription.Visible = False
                    pnlNoActivity.Visible = True
                End If
            End If
        End Sub

        Protected Sub repProgressPeriod_Contributor_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs)
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim row As DataRowView = CType(e.Item.DataItem, DataRowView)
                Dim repProgressPeriod_Contributor_Detail As Repeater = CType(e.Item.FindControl("repProgressPeriod_Contributor_Detail"), Repeater)

                Dim dtProgressPeriodContributorDetail As DataTable = Me.GetProgressPeriod_Level3(row("ProgressDate").ToString.Trim, row("userID").ToString.Trim)
                If dtProgressPeriodContributorDetail.Rows.Count > 0 Then
                    repProgressPeriod_Contributor_Detail.DataSource = dtProgressPeriodContributorDetail
                    repProgressPeriod_Contributor_Detail.DataBind()
                End If
            End If
        End Sub
#End Region


#Region " Support functions for navigation bar (Controls) "
        Private Sub setToolbarVisibleButton()
            With CSSToolbar
                .VisibleButton(CSSToolbarItem.tidNew) = False
                .VisibleButton(CSSToolbarItem.tidSave) = False
                .VisibleButton(CSSToolbarItem.tidDelete) = False
                .VisibleButton(CSSToolbarItem.tidApprove) = False
                .VisibleButton(CSSToolbarItem.tidPropose) = False
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidPrint) = False
                .VisibleButton(CSSToolbarItem.tidPrevious) = False
                .VisibleButton(CSSToolbarItem.tidNext) = False
                .VisibleButton(CSSToolbarItem.tidRefresh) = True
            End With
        End Sub

        Private Sub mdlToolbar_commandBarClick(ByVal sender As Object, ByVal e As CSSToolbarItem) Handles CSSToolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidRefresh
                    GetProgressPeriod_Level1(calStartDate.selectedDate, calEndDate.selectedDate)
            End Select
        End Sub
#End Region


#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
        End Function

        Private Sub prepareDDL()
            commonFunction.SetDDL_Period(ddlPeriod)
        End Sub

        Private Sub prepareScreen(ByVal isNew As Boolean)
            ddlPeriod.SelectedIndex = 0
            pnlCustomPeriod.Visible = True
            calStartDate.selectedDate = GetFirstDayForWeek(Date.Today, False)
            calEndDate.selectedDate = Date.Today
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

        Private Sub GetProgressPeriod_Level1(ByVal dtStartDate As Date, ByVal dtEndDate As Date)
            Dim tblDateInSelectedPeriod As New DataTable
            With tblDateInSelectedPeriod
                .Columns.Add("ProgressDate", System.Type.GetType("System.DateTime"))
                .Columns.Add("ProgressDateDisplay", System.Type.GetType("System.String"))
            End With
            Dim dtDate As Date = dtEndDate
            Dim strDate As String = String.Empty
            While dtDate >= dtStartDate
                strDate = Format(dtDate, commonFunction.FORMAT_DATE)
                If dtDate = Date.Today Then strDate = "Today"
                If dtDate = Date.Today.AddDays(-1) Then strDate = "Yesterday"
                Dim newRow As DataRow = tblDateInSelectedPeriod.NewRow
                newRow("ProgressDate") = dtDate
                newRow("ProgressDateDisplay") = strDate
                tblDateInSelectedPeriod.Rows.Add(newRow)
                dtDate = dtDate.AddDays(-1)
            End While
            repProgressPeriod.DataSource = tblDateInSelectedPeriod
            repProgressPeriod.DataBind()
        End Sub

        Private Function GetProgressPeriod_Level2(ByVal dtDate As String) As DataTable
            Dim dt As DataTable
            Dim oBR As New Common.BussinessRules.Issue
            dt = oBR.SelectProgressPeriod_Level2(CDate(dtDate))
            oBR.Dispose()
            oBR = Nothing
            Return dt
        End Function

        Private Function GetProgressPeriod_Level3(ByVal dtDate As String, ByVal userID As String) As DataTable
            Dim dt As DataTable
            Dim oBR As New Common.BussinessRules.Issue
            dt = oBR.SelectProgressPeriod_Level3(CDate(dtDate), userID.Trim)
            oBR.Dispose()
            oBR = Nothing
            Return dt
        End Function
#End Region


#Region " C,R,U,D "

#End Region
    End Class

End Namespace