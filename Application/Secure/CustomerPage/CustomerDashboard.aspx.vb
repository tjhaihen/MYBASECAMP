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
    Public Class CustomerDashboard
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
                PrepareDDL()
                _openProject()
                CountTotal()
            End If
        End Sub

        Private Sub ibtnViewDashboard_Click(sender As Object, e As System.EventArgs) Handles ibtnViewDashboard.Click
            Response.Write("<script language=javascript>window.location.replace('" + PageBase.UrlBase + "/secure/CustomerPage/CustomerDashboard.aspx')</script>")
        End Sub

        Private Sub ibtnViewDetail_Click(sender As Object, e As System.EventArgs) Handles ibtnViewDetail.Click
            Response.Write("<script language=javascript>window.location.replace('" + PageBase.UrlBase + "/secure/CustomerPage/CustomerMain.aspx')</script>")
        End Sub

        Private Sub ddlProjectFilter_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlProjectFilter.SelectedIndexChanged
            _openProject()
            CountTotal()
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
                    _openProject()
                    CountTotal()
            End Select
        End Sub
#End Region

#Region " Private Functions "
        Private Function ReadQueryString() As Boolean

        End Function

        Private Sub PrepareDDL()
            commonFunction.SetDDL_Table(ddlProjectFilter, "ProjectUser", MyBase.LoggedOnUserID.Trim, False)
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

        Protected Function GetIssueBy(ByVal strDisplayParameter As String, Optional ByVal strFilterParameter As String = "") As String
            Dim strToReturn As String = String.Empty
            Dim oBR As New Common.BussinessRules.Issue
            oBR.ProjectID = ddlProjectFilter.SelectedValue.Trim
            If oBR.SelectDashboardCustomer(strDisplayParameter.Trim, strFilterParameter.Trim).Rows.Count > 0 Then
                strToReturn = oBR.strArray.Trim
                strToReturn = Replace(strToReturn, "$", "'")
                strToReturn = Replace(strToReturn, "^", "[")
                strToReturn = Replace(strToReturn, "@", "]")
            End If

            oBR.Dispose()
            oBR = Nothing

            Return strToReturn.Trim
        End Function

        Protected Function GetIssueByPriority() As String
            Dim strToReturn As String = String.Empty
            Dim oBR As New Common.BussinessRules.Issue
            oBR.ProjectID = ddlProjectFilter.SelectedValue.Trim
            If oBR.SelectDashboardCustomer("ByPriority").Rows.Count > 0 Then
                strToReturn = oBR.strArray.Trim
                strToReturn = Replace(strToReturn, "$", "'")
                strToReturn = Replace(strToReturn, "^", "[")
                strToReturn = Replace(strToReturn, "@", "]")
            End If

            oBR.Dispose()
            oBR = Nothing

            Return strToReturn.Trim
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
#End Region

    End Class

End Namespace