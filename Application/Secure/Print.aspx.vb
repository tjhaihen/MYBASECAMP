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
    Public Class Print
        Inherits PageBase

        Dim idp As String

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
            If Me.IsPostBack Then
            Else
                Dim fQueryStringExist As Boolean
                fQueryStringExist = ReadQueryString()
                If fQueryStringExist Then
                    projectid.Text = idp.Trim
                    _printissue()
                    _HitungTotal()

                End If
            End If
            SetDataGrid()
            'TotalIssue()
        End Sub

#End Region

#Region " Private Functions "
        Private Function ReadQueryString() As Boolean
            If Request.QueryString("idp") Is Nothing Then
                idp = String.Empty
            Else
                idp = Request.QueryString("idp")
            End If
            Return Len(idp.Trim) > 0
        End Function

        Private Sub _printissue()
            Dim oBR As New Common.BussinessRules.Issue
            With oBR
                '.IssueID = lblissueid.Text.Trim
                .ProjectID = projectid.Text.Trim
                If .PrintIssue.Rows.Count > 0 Then
                    projectnama.Text = .ProjectName.Trim
                    time.Text = DateTime.Now.ToString("dddd, dd MMMM, yyyy")
                    'lblissueid.Text = .IssueID.Trim
                    'lblissuedesc.Text = .IssueDescription.Trim
                    'lblissuetype.Text = .IssueType.Trim
                    'lblissuestatus.Text = .IssueStatus.Trim
                    'lblissuepriority.Text = .IssuePriority.Trim
                    'lblpic.Text = .PICDev.Trim
                    'If .userIDassignedTo.Trim = String.Empty Then
                    '    ddlUserIDAssignedTo.SelectedValue = MyBase.LoggedOnUserID.Trim
                    'Else
                    '    ddlUserIDAssignedTo.SelectedValue = .userIDassignedTo.Trim
                    'End If
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub _HitungTotal()
            Dim oBR As New Common.BussinessRules.Issue
            With oBR
                .ProjectID = projectid.Text.Trim
                If .Hitungtotal.Rows.Count > 0 Then
                    totalreported.Text = CStr(.TotalReported)
                    totalfinished.Text = CStr(.TotalFinished)

                    openissue.Text = CStr(.OpenIssue)
                    progressissue.Text = CStr(.ProgressIssue)
                    finishissue.Text = CStr(.FinishIssue)
                    needsampleissue.Text = CStr(.NeedSampleIssue)

                    totalissuefull.Text = CStr(.TotalIssueFull)
                    overallprogress.Text = CStr(.OverallProgress)
                    devfinish.Text = CStr(.totalDevFinish)
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub SetDataGrid()
            Dim oBR As New Common.BussinessRules.Issue
            oBR.ProjectID = projectid.Text.Trim
            grdPrintIssue.DataSource = oBR.PrintIssue()
            grdPrintIssue.DataBind()
            oBR.Dispose()
            oBR = Nothing
        End Sub

        'Private Sub TotalIssue()
        '        Dim oBR As New Common.BussinessRules.Issue
        '    oBR.ProjectID = projectid.Text.Trim
        '    DataGrid1.DataSource = oBR.Hitungtotal()
        '        DataGrid1.DataBind()
        '        oBR.Dispose()
        '        oBR = Nothing
        'End Sub

        'Private Sub jdl()
        '    Dim oBR As New Common.BussinessRules.Issue
        '    With oBR

        '        If .PrintIssue.Rows.Count > 0 Then
        '            projectnama.Text = .ProjectName.Trim
        '        End If
        '    End With
        '    oBR.Dispose()
        '    oBR = Nothing
        'End Sub

#End Region

    End Class

End Namespace

'Public Class Myday
'    Inherits System.Web.UI.Page

'    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

'    End Sub

'End Class

'Public Class Print
'    Inherits System.Web.UI.Page

'    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

'    End Sub

'End Class