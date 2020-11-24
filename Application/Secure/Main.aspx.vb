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
                Dim isEMR As Boolean = False
                If Common.Methods.GetCommonCode(Common.Constants.SystemSetting.SystemSetting_SYSEMR, Common.Constants.GroupCode.System_SCode).Trim = "1" Then
                    Response.Redirect(PageBase.UrlBase + "/secure/EMR/main.aspx")
                End If
                ReadQueryString()
                GetProjectsByUserID(chkIsMyAssignment.Checked)
                GetTasksByUserID()
            End If
        End Sub

        Protected Sub repMyProjectGroups_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repMyProjectGroups.ItemDataBound
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim row As DataRowView = CType(e.Item.DataItem, DataRowView)
                Dim repMyProjects As Repeater = CType(e.Item.FindControl("repMyProjects"), Repeater)

                Dim lblTotalByProjectGroup As Label = CType(e.Item.FindControl("lblTotalByProjectGroup"), Label)
                Dim lblTotalOpenByProjectGroup As Label = CType(e.Item.FindControl("lblTotalOpenByProjectGroup"), Label)
                Dim lblTotalFinishByProjectGroup As Label = CType(e.Item.FindControl("lblTotalFinishByProjectGroup"), Label)
                Dim lblProgressByProjectGroup As Label = CType(e.Item.FindControl("lblProgressByProjectGroup"), Label)

                Dim dtMyProjects As DataTable = Me.GetProjectByProjectGroupID(row("projectGroupID").ToString.Trim, chkIsMyAssignment.Checked)
                If dtMyProjects.Rows.Count > 0 Then
                    repMyProjects.DataSource = dtMyProjects
                    repMyProjects.DataBind()
                End If

                Dim oMyProjectsSummary As New Common.BussinessRules.ProjectUser
                If oMyProjectsSummary.SelectProjectProgressByProjectGroupID(row("projectGroupID").ToString.Trim, MyBase.LoggedOnUserID.Trim, chkIsMyAssignment.Checked).Rows.Count > 0 Then
                    lblTotalByProjectGroup.Text = oMyProjectsSummary.TotalIssue.ToString.Trim
                    lblTotalOpenByProjectGroup.Text = oMyProjectsSummary.TotalIssueOpen.ToString.Trim
                    lblTotalFinishByProjectGroup.Text = oMyProjectsSummary.TotalIssueFinish.ToString.Trim
                    lblProgressByProjectGroup.Text = oMyProjectsSummary.Progress.ToString.Trim
                End If
                oMyProjectsSummary.Dispose()
                oMyProjectsSummary = Nothing
            End If
        End Sub

        Protected Sub repMyProjects_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs)
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim row As DataRowView = CType(e.Item.DataItem, DataRowView)

                Dim pnlHEXColor As Panel = CType(e.Item.FindControl("pnlHEXColor"), Panel)
                pnlHEXColor.BackColor = System.Drawing.ColorTranslator.FromHtml(row("HEXColorID").ToString.Trim)
            End If
        End Sub

        '--print beneran
        'Protected Sub repMyProjects_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs)
        '    Select Case e.CommandName
        '        Case "ViewDetail"
        '            Dim _lblProjectID As Label = CType(e.Item.FindControl("_lblProjectID"), Label)
        '            Response.Write("<script language=javascript>window.location.replace('" + PageBase.UrlBase + "https://www.google.com/?hl=id" + chkIsMyAssignment.Checked.ToString.Trim + "&userID=" + MyBase.LoggedOnUserID.Trim + "&projectID=" + _lblProjectID.Text.Trim + "')</script>")
        '        Case "Print"
        '            Dim _lblProjectID As Label = CType(e.Item.FindControl("_lblProjectID"), Label)
        '            Dim oRpt As New Common.BussinessRules.MyReport
        '            With oRpt
        '                .ReportCode = Common.Constants.ReportID.CustomerSupportWeeklyReport_ReportID
        '                .AddParameters(_lblProjectID.Text.Trim)
        '                Response.Write(.UrlPrintPreview(Context.Request.Url.Host))
        '            End With
        '            oRpt.Dispose()
        '            oRpt = Nothing
        '    End Select
        'End Sub

        '--print percobaan
        Protected Sub repMyProjects_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs)
            Select Case e.CommandName
                'Case "ViewDetail"
                '    Dim _lblProjectID As Label = CType(e.Item.FindControl("_lblProjectID"), Label)
                '    Response.Write("<script language=javascript>window.location.replace('" + PageBase.UrlBase + "https://www.google.com/?hl=id" + chkIsMyAssignment.Checked.ToString.Trim + "&userID=" + MyBase.LoggedOnUserID.Trim + "&projectID=" + _lblProjectID.Text.Trim + "')</script>")
                'Case "Print"
                '    Dim _lblProjectID As Label = CType(e.Item.FindControl("_lblProjectID"), Label)
                '    Dim oRpt As New Common.BussinessRules.MyReport
                '    With oRpt
                '        .ReportCode = Common.Constants.ReportID.CustomerSupportWeeklyReport_ReportID
                '        .AddParameters(_lblProjectID.Text.Trim)
                '        Response.Write(.UrlPrintPreview(Context.Request.Url.Host))
                '    End With
                '    oRpt.Dispose()
                '    oRpt = Nothing
                Case "rprint"
                    'Dim _lblProjectID As Label = CType(e.Item.FindControl("_lblProjectID"), Label)
                    Response.Write("<script language=javascript>window.location.replace('" + PageBase.UrlBase + "/secure/Print.aspx')</script>")

            End Select
        End Sub
        Private Sub lbtnMyProjects_Click(sender As Object, e As System.EventArgs) Handles lbtnMyProjects.Click, ibtnMyProjects.Click
            lblPageTitle.Text = "My Projects"
            chkIsMyAssignment.Checked = False
            GetProjectsByUserID(False)
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
            lblPageTitle.Text = "My Assignments"
            chkIsMyAssignment.Checked = True
            GetProjectsByUserID(True)
        End Sub

        Private Sub lbtnFollowUpIssue_Click(sender As Object, e As System.EventArgs) Handles lbtnFollowUpIssue.Click, ibtnFollowUpIssue.Click
            Response.Write("<script language=javascript>window.location.replace('" + PageBase.UrlBase + "/secure/FollowUpIssue.aspx')</script>")
        End Sub

        Private Sub lbtnIssueStudy_Click(sender As Object, e As System.EventArgs) Handles lbtnIssueStudy.Click, ibtnIssueStudy.Click
            Response.Write("<script language=javascript>window.location.replace('" + PageBase.UrlBase + "/secure/IssueStudy.aspx')</script>")
        End Sub


#End Region

#Region " Support functions for navigation bar (Controls) "
        
#End Region

#Region " Private Functions "
        Private Function ReadQueryString() As Boolean
            If Request.QueryString("isassignment") Is Nothing Then
                chkIsMyAssignment.Checked = False
                lblPageTitle.Text = "My Projects"
            Else
                Dim strIsAssignment As String = Request.QueryString("isassignment")
                If strIsAssignment = "True" Then
                    chkIsMyAssignment.Checked = True
                    lblPageTitle.Text = "My Assignments"
                Else
                    chkIsMyAssignment.Checked = False
                    lblPageTitle.Text = "My Projects"
                End If
            End If            
        End Function

        Private Sub PrepareScreen()
            lblPageTitle.Text = "My Projects"
            chkIsMyAssignment.Checked = False
            lblAssignmentsTotal.Text = "0"
            lblUrgentsTotal.Text = "0"
        End Sub

        Private Sub GetProjectsByUserID(ByVal IsAssignedOnly As Boolean)
            Dim oBr As New Common.BussinessRules.ProjectUser
            repMyProjectGroups.DataSource = oBr.SelectProjectGroupByUserID(MyBase.LoggedOnUserID.Trim, IsAssignedOnly)
            repMyProjectGroups.DataBind()
            oBr.Dispose()
            oBr = Nothing
        End Sub

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

        Private Function GetProjectByProjectGroupID(ByVal ProjectGroupID As String, ByVal IsAssignedOnly As Boolean) As DataTable
            Dim dt As DataTable
            Dim oPU As New Common.BussinessRules.ProjectUser
            dt = oPU.SelectProjectByProjectGroupID(ProjectGroupID, MyBase.LoggedOnUserID.Trim, IsAssignedOnly)
            oPU.Dispose()
            oPU = Nothing
            Return dt
        End Function

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