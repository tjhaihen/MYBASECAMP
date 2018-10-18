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

    Public Class AccountingBalance
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
        Private MenuID As String = Common.Constants.MenuID.AccountingBalance_MenuID
#End Region


#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Me.IsPostBack Then
            Else
                CSSToolbar.ProfileID = MyBase.LoggedOnProfileID
                CSSToolbar.MenuID = MenuID.Trim
                CSSToolbar.setAuthorizationToolbar()
                setToolbarVisibleButton()

                prepareScreen(True)
                SetDataGridAccountingBalance()
                DataBind()
            End If
        End Sub

        Private Sub txtBalanceYear_TextChanged(sender As Object, e As System.EventArgs) Handles txtBalanceYear.TextChanged
            commonFunction.SetDDL_Table(ddlBalanceMonth, "MonthInYear", txtBalanceYear.Text.Trim, False)
        End Sub
#End Region


#Region " Support functions for navigation bar (Controls) "
        Private Sub setToolbarVisibleButton()
            With CSSToolbar
                .VisibleButton(CSSToolbarItem.tidApprove) = True
                .VisibleButton(CSSToolbarItem.tidNew) = False
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidPrint) = False
                .VisibleButton(CSSToolbarItem.tidNext) = False
                .VisibleButton(CSSToolbarItem.tidPrevious) = False
                .VisibleButton(CSSToolbarItem.tidDelete) = False
                .VisibleButton(CSSToolbarItem.tidRefresh) = False
            End With
        End Sub

        Private Sub mdlToolbar_commandBarClick(ByVal sender As Object, ByVal e As CSSToolbarItem) Handles CSSToolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidSave
                    _update()
                Case CSSToolbarItem.tidApprove
                    _approve()
            End Select
        End Sub
#End Region


#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
        End Function

        Private Sub prepareScreen(ByVal isNew As Boolean)
            txtBalanceYear.Text = String.Empty
            commonFunction.SetDDL_Table(ddlBalanceMonth, "MonthInYear", txtBalanceYear.Text.Trim, False)
        End Sub

        Private Sub SetDataGridAccountingBalance()
            Dim oBalance As New Common.BussinessRules.AccountingBalance
            With oBalance
                grdBalance.DataSource = oBalance.GetGLBalanceBEGIN()
                grdBalance.DataBind()
            End With
            oBalance.Dispose()
            oBalance = Nothing
        End Sub
#End Region


#Region " C,R,U,D "
        Private Sub _update()
            Dim oBalance As New Common.BussinessRules.AccountingBalance
            For Each dtItem As DataGridItem In grdBalance.Items
                Dim _lblGLAccountID As Label = CType(dtItem.FindControl("_lblGLAccountID"), Label)
                Dim _txtBalanceBEGIN As TextBox = CType(dtItem.FindControl("_txtBalanceBEGIN"), TextBox)

                oBalance.PeriodNo = txtBalanceYear.Text.Trim + Right(("0" + ddlBalanceMonth.SelectedValue.Trim), 2)
                oBalance.GLAccountID = CInt(_lblGLAccountID.Text.Trim)
                oBalance.BalanceBEGIN = CDec(_txtBalanceBEGIN.Text.Trim)
                oBalance.IsApproved = False
                oBalance.UpsertGLBalanceBEGIN()
            Next
            oBalance.Dispose()
            oBalance = Nothing
        End Sub

        Private Sub _approve()
            Dim oBalance As New Common.BussinessRules.AccountingBalance
            oBalance.PeriodNo = txtBalanceYear.Text.Trim + Right(("0" + ddlBalanceMonth.SelectedValue.Trim), 2)
            oBalance.IsApproved = True
            oBalance.ApproveGLBalanceBEGIN()
            oBalance.Dispose()
            oBalance = Nothing
        End Sub
#End Region

        
    End Class

End Namespace