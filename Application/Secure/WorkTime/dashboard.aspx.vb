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
    Public Class Dashboard
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

        Private Sub txtYear_TextChanged(sender As Object, e As System.EventArgs) Handles txtYear.TextChanged
            UpdateViewGridActivePeople()
        End Sub

        Private Sub ddlMonth_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlMonth.SelectedIndexChanged
            UpdateViewGridActivePeople()
        End Sub

        Private Sub grdActivePeople_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdActivePeople.ItemDataBound
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim _repDateInMonthByPeople As Repeater = CType(e.Item.FindControl("_repDateInMonthByPeople"), Repeater)
                Dim _lblUserID As Label = CType(e.Item.FindControl("_lblUserID"), Label)
                Dim oPU As New Common.BussinessRules.Utility
                _repDateInMonthByPeople.DataSource = oPU.GetDateInMonth(CInt(ddlMonth.SelectedValue.Trim), _lblUserID.Text.Trim)
                _repDateInMonthByPeople.DataBind()
                oPU.Dispose()
                oPU = Nothing
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
                    UpdateViewGridActivePeople()

                Case CSSToolbarItem.tidDownload
                    Dim oRPT As New Common.BussinessRules.MyReport
                    oRPT.AddParameters(txtYear.Text.Trim)
                    oRPT.AddParameters(ddlMonth.SelectedValue.Trim)
                    oRPT.ReportCode = ddlWorktimeTypeDownload.SelectedValue.Trim
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

        Private Sub prepareDDL()
            commonFunction.SetDDL_Table(ddlMonth, "MonthInYear", String.Empty, False)
            commonFunction.SetDDL_Table(ddlWorktimeTypeDownload, "CommonCode", Common.Constants.GroupCode.WorktimeReport_SCode, False)
        End Sub

        Private Sub PrepareScreen()
            txtYear.Text = Date.Today.Year.ToString.Trim
            ddlMonth.SelectedValue = Date.Today.Month.ToString.Trim
            UpdateViewGridActivePeople()
        End Sub

        Private Sub UpdateViewGridActivePeople()
            Dim oRsrc As New Common.BussinessRules.User
            grdActivePeople.DataSource = oRsrc.SelectActiveUserPerson(txtYear.Text.Trim, ddlMonth.SelectedValue.Trim)
            grdActivePeople.DataBind()
            oRsrc.Dispose()
            oRsrc = Nothing
        End Sub
#End Region

#Region " C,R,U,D "
        
#End Region

    End Class

End Namespace