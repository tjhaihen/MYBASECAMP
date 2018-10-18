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

    Public Class BudgetAccount
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
        Private MenuID As String = Common.Constants.MenuID.BudgetAccount_MenuID
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
                SetDataGridBudget()
                DataBind()
            End If
        End Sub

        Private Sub ibtnEdit_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtnEdit.Click
            pnlBudgetSetting.Visible = True
            pnlBudgetRealizations.Visible = False
            lblPageTitle.Text = "Anggaran Perkiraan"
        End Sub

        Private Sub ibtnRealisasi_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtnRealisasi.Click
            pnlBudgetSetting.Visible = False
            pnlBudgetRealizations.Visible = True
            lblPageTitle.Text = "Realisasi Anggaran Perkiraan"
        End Sub

        Private Sub ddlTahunRealisasi_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlTahunRealisasi.SelectedIndexChanged
            commonFunction.SetDDL_Table(ddlBulanRealisasi, "BudgetMonth", ddlTahunRealisasi.SelectedItem.Value.Trim, True, "-- PILIH BULAN --")
        End Sub
#End Region


#Region " Support functions for navigation bar (Controls) "
        Private Sub setToolbarVisibleButton()
            With CSSToolbar
                .VisibleButton(CSSToolbarItem.tidApprove) = False
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidPrint) = False
                .VisibleButton(CSSToolbarItem.tidNext) = False
                .VisibleButton(CSSToolbarItem.tidPrevious) = False
                .VisibleButton(CSSToolbarItem.tidDelete) = False
                .VisibleButton(CSSToolbarItem.tidRefresh) = True
            End With
        End Sub

        Private Sub mdlToolbar_commandBarClick(ByVal sender As Object, ByVal e As CSSToolbarItem) Handles CSSToolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidNew
                    prepareScreen(True)
                    SetDataGridBudget()
                Case CSSToolbarItem.tidSave
                    _update()
                Case CSSToolbarItem.tidRefresh
                    If pnlBudgetSetting.Visible Then
                        If txtBudgetPeriod.Text.Trim.Length = 0 Then
                            commonFunction.MsgBox(Me, "Periode Anggaran harus diisi dengan Tahun.")
                            Exit Sub
                        Else
                            SetDataGridBudget()
                        End If
                    End If

                    If pnlBudgetRealizations.Visible Then
                        Dim err As Integer = 0
                        If txtBudgetPeriodRealization.Text.Trim.Length = 0 Then
                            commonFunction.MsgBox(Me, "Periode Anggaran harus diisi dengan Tahun Anggaran.")
                            err += 1
                            Exit Sub
                        End If

                        If ddlTahunRealisasi.SelectedIndex = 0 Then
                            commonFunction.MsgBox(Me, "Tahun Realisasi harus dipilih.")
                            err += 1
                            Exit Sub
                        End If

                        If ddlBulanRealisasi.SelectedIndex = 0 Then
                            commonFunction.MsgBox(Me, "Bulan Realisasi harus dipilih.")
                            err += 1
                            Exit Sub
                        End If

                        If err = 0 Then
                            SetDataGridBudgetRealization()
                        End If
                    End If
            End Select
        End Sub
#End Region


#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
        End Function

        Private Sub prepareScreen(ByVal isNew As Boolean)
            pnlBudgetSetting.Visible = True
            pnlBudgetRealizations.Visible = False
            lblPageTitle.Text = "Anggaran Perkiraan"
            txtBudgetPeriod.Text = String.Empty
            commonFunction.SetDDL_Table(ddlTahunRealisasi, "BudgetYear", String.Empty, True, "-- PILIH TAHUN --")
            commonFunction.SetDDL_Table(ddlBulanRealisasi, "BudgetMonth", ddlTahunRealisasi.SelectedItem.Value.Trim, True, "-- PILIH BULAN --")
        End Sub

        Private Sub SetDataGridBudget()
            Dim oBudget As New Common.BussinessRules.Budget
            With oBudget
                .BudgetPeriod = txtBudgetPeriod.Text.Trim
                grdBudget.DataSource = oBudget.GetBudgetAccountByPeriod()
                grdBudget.DataBind()
            End With
            oBudget.Dispose()
            oBudget = Nothing
        End Sub

        Private Sub SetDataGridBudgetRealization()
            Dim oBudget As New Common.BussinessRules.Budget
            With oBudget
                .BudgetPeriod = txtBudgetPeriodRealization.Text.Trim
                .BudgetYear = ddlTahunRealisasi.SelectedValue.Trim
                .BudgetMonth = ddlBulanRealisasi.SelectedValue.Trim
                grdBudgetRealization.DataSource = oBudget.GetBudgetAccountRealizationByPeriod()
                grdBudgetRealization.DataBind()
            End With
            oBudget.Dispose()
            oBudget = Nothing
        End Sub
#End Region


#Region " C,R,U,D "
        Private Sub _open(ByVal RecStatus As BussinessRules.QISRecStatus)
            
        End Sub

        Private Sub _update()
            Dim oBudget As New Common.BussinessRules.Budget
            For Each dtItem As DataGridItem In grdBudget.Items
                Dim _lblGLAccountID As Label = CType(dtItem.FindControl("_lblGLAccountID"), Label)
                Dim _txtBudgetAmount As TextBox = CType(dtItem.FindControl("_txtBudgetAmount"), TextBox)

                oBudget.BudgetPeriod = txtBudgetPeriod.Text.Trim
                oBudget.GLAccountID = CInt(_lblGLAccountID.Text.Trim)
                oBudget.BudgetAmount = CDec(_txtBudgetAmount.Text.Trim)
                oBudget.UpsertBudgetAccount()
            Next
            oBudget.Dispose()
            oBudget = Nothing
        End Sub
#End Region

    End Class

End Namespace