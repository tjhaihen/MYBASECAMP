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
Imports Telerik.Web.UI

Imports System.Data.SqlTypes

Imports QIS.Common

Namespace QIS.Web.Secure

    Public Class BudgetPurchasing
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
        Private MenuID As String = Common.Constants.MenuID.BudgetPurchasing_MenuID
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
                SetDataGridBudgetPurchasing()
                DataBind()
            End If
        End Sub

        Private Sub ibtnEdit_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtnEdit.Click
            pnlBudgetSetting.Visible = True
            pnlBudgetMapping.Visible = False
            pnlBudgetRealizations.Visible = False
            lblPageTitle.Text = "Anggaran Pembelian"
        End Sub

        Private Sub ibtnMapping_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtnMapping.Click
            pnlBudgetSetting.Visible = False
            pnlBudgetMapping.Visible = True
            pnlBudgetRealizations.Visible = False
            lblPageTitle.Text = "Mapping Mata Anggaran Pembelian"
        End Sub

        Private Sub ibtnRealisasi_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtnRealisasi.Click
            pnlBudgetSetting.Visible = False
            pnlBudgetMapping.Visible = False
            pnlBudgetRealizations.Visible = True
            lblPageTitle.Text = "Realisasi Anggaran Pembelian"
        End Sub

        Private Sub rcbLocation_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles rcbLocation.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadLocation(e.Text)
        End Sub

        Private Sub rcbLocation_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles rcbLocation.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("LocationName").ToString()
        End Sub

        Private Sub rcbAccount_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles rcbAccount.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadAccount(e.Text)
        End Sub

        Private Sub rcbAccount_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles rcbAccount.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("GLAccountNo").ToString() + " - " + CType(e.Item.DataItem, DataRowView)("GLAccountName").ToString()
        End Sub

        Private Sub rcbLocationRealization_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles rcbLocationRealization.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadLocationRealization(e.Text)
        End Sub

        Private Sub rcbLocationRealization_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles rcbLocationRealization.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("LocationName").ToString()
        End Sub

        Private Sub ddlYearInBudget_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlYearInBudget.SelectedIndexChanged
            commonFunction.SetDDL_Table(ddlMataAnggaranMapping, "BudgetPurchasingByPeriod", ddlYearInBudget.SelectedValue.Trim, True, "-- PILIH MATA ANGGARAN --")
            SetDataGridBudgetPurchasingMapping()
        End Sub

        Private Sub btnAdd_Click(sender As Object, e As System.EventArgs) Handles btnAdd.Click
            _AddRemoveMapping(True)
        End Sub

        Private Sub btnRemove_Click(sender As Object, e As System.EventArgs) Handles btnRemove.Click
            _AddRemoveMapping(False)
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
                    prepareScreenEditAnggaran()
                Case CSSToolbarItem.tidSave
                    _update()
                    prepareScreenEditAnggaran()
                Case CSSToolbarItem.tidRefresh
                    If pnlBudgetSetting.Visible Then
                        SetDataGridBudgetPurchasing()
                    End If
                    If pnlBudgetMapping.Visible Then
                        SetDataGridBudgetPurchasingMapping()
                    End If
                    If pnlBudgetRealizations.Visible Then
                        SetDataGridBudgetPurchasingRealization()
                    End If
            End Select
        End Sub
#End Region


#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
        End Function

        Private Sub prepareScreen(ByVal isNew As Boolean)
            pnlBudgetSetting.Visible = True
            pnlBudgetMapping.Visible = False
            pnlBudgetRealizations.Visible = False
            lblPageTitle.Text = "Anggaran Pembelian"
            txtBudgetPeriod.Text = String.Empty
            txtBudgetCode.Text = String.Empty
            txtBudgetName.Text = String.Empty
            txtUnitPrice.Text = "0.00"
            txtQuantity.Text = "0"
            commonFunction.SetDDL_Table(ddlPurchaseOrderType, "StandardCode", Common.Constants.StandardCode.PurchaseOrderType_SCode, True, "-- PILIH KATEGORI --")
            commonFunction.SetDDL_Table(ddlYearInBudget, "BudgetPurchasingYear", String.Empty, False)
            commonFunction.SetDDL_Table(ddlMataAnggaranMapping, "BudgetPurchasingByPeriod", ddlYearInBudget.SelectedValue.Trim, True, "-- PILIH MATA ANGGARAN --")
            commonFunction.SetDDL_Table(ddlBudgetPeriodRealization, "BudgetPurchasingYear", String.Empty, False)
        End Sub

        Private Sub prepareScreenEditAnggaran()
            txtBudgetCode.Text = String.Empty
            txtBudgetName.Text = String.Empty
            txtUnitPrice.Text = "0.00"
            txtQuantity.Text = "0"
            ddlPurchaseOrderType.SelectedIndex = 0
            rcbLocation.SelectedIndex = 0
            rcbLocation.Text = String.Empty
            rcbAccount.SelectedIndex = 0
            rcbAccount.Text = String.Empty
            SetDataGridBudgetPurchasing()
        End Sub

        Private Sub SetDataGridBudgetPurchasing()
            Dim oBudget As New Common.BussinessRules.Budget
            With oBudget
                .BudgetPeriod = txtBudgetPeriod.Text.Trim
                grdBudgetPurchasing.DataSource = oBudget.GetBudgetPurchasingByPeriod()
                grdBudgetPurchasing.DataBind()
            End With
            oBudget.Dispose()
            oBudget = Nothing
        End Sub

        Private Sub SetDataGridBudgetPurchasingMapping()
            Dim oBudget As New Common.BussinessRules.Budget
            With oBudget
                .BudgetPeriod = ddlYearInBudget.SelectedValue.Trim
                .BudgetCode = ddlMataAnggaranMapping.SelectedValue.Trim
                grdItemGroupExMapping.DataSource = .GetItemGroupMapping(True)
                grdItemGroupExMapping.DataBind()
                grdItemGroupInMapping.DataSource = .GetItemGroupMapping(False)
                grdItemGroupInMapping.DataBind()
            End With
            oBudget.Dispose()
            oBudget = Nothing
        End Sub

        Private Sub SetDataGridBudgetPurchasingRealization()
            Dim oBudget As New Common.BussinessRules.Budget
            With oBudget
                .BudgetPeriod = txtBudgetPeriod.Text.Trim
                .LocationID = CInt(rcbLocationRealization.SelectedValue.Trim)
                grdBudgetPurchasingRealization.DataSource = oBudget.GetBudgetPurchasingRealization()
                grdBudgetPurchasingRealization.DataBind()
            End With
            oBudget.Dispose()
            oBudget = Nothing
        End Sub

        Private Sub LoadLocation(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New Common.BussinessRules.Budget

            dt = br.GetActiveLocation

            Dim dv As DataView = dt.DefaultView

            dv.RowFilter = "LocationName LIKE '%" + Filter.Trim + "%'"

            rcbLocation.DataSource = dv
            rcbLocation.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadLocationRealization(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New Common.BussinessRules.Budget

            dt = br.GetActiveLocation

            Dim dv As DataView = dt.DefaultView

            dv.RowFilter = "LocationName LIKE '%" + Filter.Trim + "%'"

            rcbLocationRealization.DataSource = dv
            rcbLocationRealization.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadAccount(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New Common.BussinessRules.Budget

            dt = br.GetActiveAccount

            Dim dv As DataView = dt.DefaultView

            dv.RowFilter = "GLAccountName LIKE '%" + Filter.Trim + "%' OR GLAccountNo LIKE '%" + Filter.Trim + "%'"

            rcbAccount.DataSource = dv
            rcbAccount.DataBind()

            br.Dispose()
            br = Nothing
        End Sub
#End Region


#Region " C,R,U,D "
        Private Sub _update()
            Dim oBudget As New Common.BussinessRules.Budget
            With oBudget
                .BudgetPeriod = txtBudgetPeriod.Text.Trim
                .BudgetCode = txtBudgetCode.Text.Trim
                .BudgetName = txtBudgetName.Text.Trim
                .GCPurchaseOrderType = ddlPurchaseOrderType.SelectedValue.Trim
                .GLAccountID = CInt(rcbAccount.SelectedValue.Trim)
                .LocationID = CInt(rcbLocation.SelectedValue.Trim)
                .UnitPrice = CDec(txtUnitPrice.Text.Trim)
                .Quantity = CDec(txtQuantity.Text.Trim)
                .UpsertBudgetPurchasing()
            End With
            oBudget.Dispose()
            oBudget = Nothing
        End Sub

        Private Sub _AddRemoveMapping(ByVal isAdd As Boolean)
            Dim oBudget As New Common.BussinessRules.Budget
            If isAdd Then
                For Each dtItem As DataGridItem In grdItemGroupExMapping.Items
                    Dim _chkSelect As CheckBox = CType(dtItem.FindControl("_chkSelect"), CheckBox)
                    Dim _lblItemGroupID As Label = CType(dtItem.FindControl("_lblItemGroupID"), Label)

                    If _chkSelect.Checked Then
                        oBudget.BudgetPeriod = ddlYearInBudget.SelectedValue.Trim
                        oBudget.BudgetCode = ddlMataAnggaranMapping.SelectedValue.Trim
                        oBudget.ItemGroupID = CInt(_lblItemGroupID.Text.Trim)
                        oBudget.InsertBudgetPurchasingMapping()
                    End If                    
                Next
            Else
                For Each dtItem As DataGridItem In grdItemGroupInMapping.Items
                    Dim _chkSelect As CheckBox = CType(dtItem.FindControl("_chkSelect"), CheckBox)
                    Dim _lblItemGroupID As Label = CType(dtItem.FindControl("_lblItemGroupID"), Label)

                    If _chkSelect.Checked Then
                        oBudget.BudgetPeriod = ddlYearInBudget.SelectedValue.Trim
                        oBudget.BudgetCode = ddlMataAnggaranMapping.SelectedValue.Trim
                        oBudget.ItemGroupID = CInt(_lblItemGroupID.Text.Trim)
                        oBudget.DeleteBudgetPurchasingMapping()
                    End If                    
                Next
            End If            
            oBudget.Dispose()
            oBudget = Nothing
            SetDataGridBudgetPurchasingMapping()
        End Sub
#End Region

    End Class

End Namespace