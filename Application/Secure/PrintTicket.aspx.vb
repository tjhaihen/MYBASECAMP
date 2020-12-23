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
    Public Class PrintTicket
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
                    issueid.Text = idp.Trim
                    _printticket()
                    _userupdateresponse()

                End If
            End If

            SetDataGrid()
        End Sub

        '--percobaan print ticket
        Private Sub _printticket()
            Dim oBR As New Common.BussinessRules.Issue
            With oBR
                .IssueID = issueid.Text.Trim
                .userIDprint = MyBase.LoggedOnUserID.Trim
                If .PrintTicket.Rows.Count > 0 Then
                    issueid.Text = .IssueID.Trim
                    projectaliasname.Text = .ProjectAliasName.Trim
                    projectName.Text = .ProjectName.Trim
                    departmentName.Text = .DepartmentName.Trim
                    reportedBy.Text = .ReportedBy.Trim
                    reportedDate.Text = .ReportedDate.ToString("dd-MMMM-yyyy").Trim
                    issueDescription.Text = .IssueDescription.Trim
                    targetdate.Text = .targetDate.ToString("dd-MMMM-yyyy").Trim
                    issuePriorityName.Text = .issuePriorityName.Trim
                    issueStatus.Text = .issueStatusName.Trim
                    issueType.Text = .issueTypeName.Trim
                    datenow.Text = DateTime.Now.ToString("dd-MMMM-yyyy hh\:mm")
                    userprint.Text = .userNameprint.Trim
                    'medinfrasteam.Text = .userNameUpdateResponse.Trim
                    'responseDate.Text = .responseDate.ToString("dd-MMMM-yyyy").Trim
                    'responseTime.Text = .responseTime.ToString.Trim
                    'responseDuration.Text = .responseDuration.Trim
                    'responseDescription.Text = .responseDescription.Trim
                    'responseBy.Text = .userNameUpdateResponse.Trim
                    datenow.Text = DateTime.Now.ToString("dd-MMMM-yyyy hh\:mm")
                    userprint.Text = .userNameprint.Trim
                    medinfrasteam.Text = .userNameUpdateResponse.Trim
                    issueConfirmStatus.Text = .issueConfirmStatusName.Trim
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        '--percobaan print ticket
        Private Sub _userupdateresponse()
            Dim oBR As New Common.BussinessRules.Issue
            With oBR
                .IssueID = issueid.Text.Trim
                .userIDprint = MyBase.LoggedOnUserID.Trim 'userIDprint.Text.Trim
                If .ambilupdatenameresponse.Rows.Count > 0 Then
                    medinfrasteam.Text = .userNameUpdateResponse.Trim
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub SetDataGrid()
            Dim oBR As New Common.BussinessRules.Issue
            oBR.IssueID = issueid.Text.Trim
            grdPrintIssueResponse.DataSource = oBR.ambilresponse()
            grdPrintIssueResponse.DataBind()
            oBR.Dispose()
            oBR = Nothing
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

#End Region

    End Class

End Namespace

