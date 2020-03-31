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

Namespace QIS.Web.PatchManagement
    Public Class PatchDashboard
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
                PrepareScreen()
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
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidPrint) = False
                .VisibleButton(CSSToolbarItem.tidPrevious) = False
                .VisibleButton(CSSToolbarItem.tidNext) = False
                .VisibleButton(CSSToolbarItem.tidRefresh) = True
                .VisibleButton(CSSToolbarItem.tidDownload) = True
            End With
        End Sub

        Private Sub mdlToolbar_commandBarClick(ByVal sender As Object, ByVal e As CSSToolbarItem) Handles CSSToolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidRefresh
                    UpdateViewGridPatchDashboard()

                Case CSSToolbarItem.tidDownload
                    Dim oRPT As New Common.BussinessRules.MyReport
                    oRPT.AddParameters(calStartDate.selectedDate.ToString.Trim)
                    oRPT.AddParameters(calEndDate.selectedDate.ToString.Trim)
                    oRPT.ReportCode = Common.Constants.ReportID.PatchDashboard_ReportID
                    oRPT.GetReportDataByReportCode()
                    If oRPT.ReportFormat = "XLS" Then
                        oRPT.ExportToExcel(oRPT.generateReportDataTable, Response)
                    End If
                    oRPT.Dispose()
                    oRPT = Nothing
            End Select
        End Sub
#End Region

#Region " Private Functions "
        Private Function ReadQueryString() As Boolean

        End Function

        Private Sub PrepareScreen()
            calStartDate.selectedDate = Date.Today
            calEndDate.selectedDate = Date.Today
            UpdateViewGridPatchDashboard()
        End Sub

        Private Sub UpdateViewGridPatchDashboard()
            Dim oDashboard As New Common.BussinessRules.PatchProject
            grdPatchDashboard.DataSource = oDashboard.SelectForPatchProjectDashboard(calStartDate.selectedDate, calEndDate.selectedDate)
            grdPatchDashboard.DataBind()
            oDashboard.Dispose()
            oDashboard = Nothing
        End Sub
#End Region

    End Class

End Namespace