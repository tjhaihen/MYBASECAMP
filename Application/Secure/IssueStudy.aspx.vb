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
    Public Class IssueStudy
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
                GetTasksByUserID()
            End If
        End Sub

        Private Sub lbtnMyProjects_Click(sender As Object, e As System.EventArgs) Handles lbtnMyProjects.Click, ibtnMyProjects.Click
            Response.Write("<script language=javascript>window.location.replace('" + PageBase.UrlBase + "/secure/Main.aspx" + "')</script>")
        End Sub

        Private Sub lbtnMyDay_Click(sender As Object, e As System.EventArgs) Handles lbtnMyDay.Click, ibtnMyDay.Click
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

        Protected Sub repIssue_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repIssue.ItemDataBound
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim row As DataRowView = CType(e.Item.DataItem, DataRowView)
                Dim repIssueResponse As Repeater = CType(e.Item.FindControl("repIssueResponse"), Repeater)
                Dim pnlIssueResponse As Panel = CType(e.Item.FindControl("pnlIssueResponse"), Panel)
                Dim pnlNoResponse As Panel = CType(e.Item.FindControl("pnlNoResponse"), Panel)

                Dim dtIssueResponse As DataTable = Me.GetIssueResponse_Level2(row("issueID").ToString.Trim)
                If dtIssueResponse.Rows.Count > 0 Then
                    pnlIssueResponse.Visible = True
                    pnlNoResponse.Visible = False
                    repIssueResponse.DataSource = dtIssueResponse
                    repIssueResponse.DataBind()
                Else
                    pnlIssueResponse.Visible = False
                    pnlNoResponse.Visible = True
                End If
            End If
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
                    GetIssueStudy_Level1(txtIssueID.Text.Trim, txtKeywords.Text.Trim)
            End Select
        End Sub
#End Region

#Region " Private Functions "
        Private Sub prepareDDL()
            commonFunction.SetDDL_Table(ddlProjectFilter, "ProjectUser", MyBase.LoggedOnUserID.Trim, True, "All Project")            
        End Sub

        Private Sub PrepareScreen()
            txtIssueID.Text = String.Empty
            txtKeywords.Text = String.Empty
            commonFunction.Focus(Me, txtIssueID.ClientID)
        End Sub

        Private Sub GetIssueStudy_Level1(ByVal strIssueID As String, ByVal strKeywords As String)
            If txtIssueID.Text.Trim = String.Empty And txtKeywords.Text.Trim = String.Empty Then
                commonFunction.MsgBox(Me, "Nothing to search for. Please type on Issue ID or Keywords first.")
                Exit Sub
            End If
            Dim oBR As New Common.BussinessRules.Issue
            repIssue.DataSource = oBR.SelectByKeywords(ddlProjectFilter.SelectedValue.Trim, strIssueID.Trim, strKeywords.Trim)
            repIssue.DataBind()
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Function GetIssueResponse_Level2(ByVal strIssueID As String) As DataTable
            Dim dt As New DataTable
            Dim oBR As New Common.BussinessRules.IssueResponse
            oBR.IssueID = strIssueID.Trim
            dt = oBR.SelectByIssueID()
            oBR.Dispose()
            oBR = Nothing
            Return dt
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
        
#End Region

    End Class

End Namespace