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
    Public Class Card
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
                    lblSelectedDateInDate.Text = CDate(_lbtnDateInMonth.Text.Trim).ToString.Trim
                    GetActivePeople()
            End Select
        End Sub

        Protected Sub repWorktimeCard_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repWorktimeCard.ItemDataBound
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim _imgPic As Image = CType(e.Item.FindControl("_imgPic"), Image)
                Dim _imgSubmitted As Image = CType(e.Item.FindControl("_imgSubmitted"), Image)
                Dim _lblGenderName As Label = CType(e.Item.FindControl("_lblGenderName"), Label)
                Dim _grdWorkTimeDt As DataGrid = CType(e.Item.FindControl("_grdWorkTimeDt"), DataGrid)
                Dim _lblUserID As Label = CType(e.Item.FindControl("_lblUserID"), Label)

                If _lblGenderName.Text.Trim = "Male" Then
                    _imgPic.ImageUrl = "/qistoollib/images/mpic.png"
                Else
                    _imgPic.ImageUrl = "/qistoollib/images/fpic.png"
                End If

                Dim oWTHd As New Common.BussinessRules.WorkTimeHd
                oWTHd.UserID = _lblUserID.Text.Trim
                oWTHd.WorkTimeDate = CDate(lblSelectedDateInDate.Text.Trim)
                _imgSubmitted.Visible = oWTHd.SelectByUserIDWorkTimeDateSubmitted.Rows.Count > 0
                oWTHd.Dispose()
                oWTHd = Nothing

                Dim oWTDt As New Common.BussinessRules.WorkTimeDt
                _grdWorkTimeDt.DataSource = oWTDt.SelectByUserIDWorktimeDate(_lblUserID.Text.Trim, CDate(lblSelectedDateInDate.Text.Trim))
                _grdWorkTimeDt.DataBind()
                oWTDt.Dispose()
                oWTDt = Nothing
            End If
        End Sub
#End Region

#Region " Support functions for navigation bar (Controls) "
        
#End Region

#Region " Private Functions "
        Private Function ReadQueryString() As Boolean

        End Function

        Private Sub prepareDDL()
            commonFunction.SetDDL_Table(ddlMonth, "MonthInYear", String.Empty, False)
        End Sub

        Private Sub PrepareScreen()
            txtYear.Text = Date.Today.Year.ToString.Trim
            ddlMonth.SelectedValue = Date.Today.Month.ToString.Trim
            GetDateInMonth()
            lblSelectedDate.Text = Format(Date.Today, commonFunction.FORMAT_DATE)
            lblSelectedDateInDate.Text = Date.Today.ToString.Trim
            GetActivePeople()
        End Sub

        Private Sub GetDateInMonth()
            Dim oPU As New Common.BussinessRules.Utility
            grdDateInMonth.DataSource = oPU.GetDateInMonth(CInt(txtYear.Text.Trim), CInt(ddlMonth.SelectedValue.Trim), MyBase.LoggedOnUserID)
            grdDateInMonth.DataBind()
            oPU.Dispose()
            oPU = Nothing
        End Sub

        Private Sub GetActivePeople()
            Dim oRsrc As New Common.BussinessRules.User
            repWorktimeCard.DataSource = oRsrc.SelectActiveUserPerson(txtYear.Text.Trim, ddlMonth.SelectedValue.Trim)
            repWorktimeCard.DataBind()
            oRsrc.Dispose()
            oRsrc = Nothing
        End Sub
#End Region

#Region " C,R,U,D "
        
#End Region

    End Class

End Namespace