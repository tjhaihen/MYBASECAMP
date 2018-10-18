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

    Public Class DrugInteractionInfo
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
        Private MenuID As String = Common.Constants.MenuID.ProjectGroup_MenuID
#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Me.IsPostBack Then
            Else
                CSSToolbar.ProfileID = MyBase.LoggedOnProfileID
                CSSToolbar.MenuID = MenuID.Trim
                CSSToolbar.setAuthorizationToolbar()
                setToolbarVisibleButton()

                btnSearchObat1.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("ItemDrug", txtItemCode1.ClientID))
                btnSearchObat2.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("ItemDrug", txtItemCode2.ClientID))
                btnSearchObat.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("ItemDrug", txtItemCode.ClientID))

                prepareScreen(True)
                prepareScreenEdit()
                DataBind()
            End If
        End Sub

        Private Sub ibtnDetail_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtnDetail.Click
            pnlInteraksiObat.Visible = True
            pnlEditInteraksiObat.Visible = False
        End Sub

        Private Sub ibtnEdit_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtnEdit.Click
            pnlInteraksiObat.Visible = False
            pnlEditInteraksiObat.Visible = True
        End Sub

        Private Sub txtItemCode1_TextChanged(sender As Object, e As System.EventArgs) Handles txtItemCode1.TextChanged
            txtItemName1.Text = GetDrugName(txtItemCode1.Text.Trim)
        End Sub

        Private Sub txtItemCode2_TextChanged(sender As Object, e As System.EventArgs) Handles txtItemCode2.TextChanged
            txtItemName2.Text = GetDrugName(txtItemCode2.Text.Trim)
        End Sub

        Private Sub txtItemCode_TextChanged(sender As Object, e As System.EventArgs) Handles txtItemCode.TextChanged
            txtItemName.Text = GetDrugName(txtItemCode.Text.Trim)
        End Sub

        Private Sub btnCheckInteraction_Click(sender As Object, e As System.EventArgs) Handles btnCheckInteraction.Click
            GetDrugInteractionCheckResult()
        End Sub

        Private Sub btnSaveInteraksi_Click(sender As Object, e As System.EventArgs) Handles btnSaveInteraksi.Click
            InsertUpdateDrugInteractionHd()
        End Sub

        Private Sub btnNewInteraksi_Click(sender As Object, e As System.EventArgs) Handles btnNewInteraksi.Click
            prepareScreenEdit()
        End Sub

        Private Sub btnSaveDt_Click(sender As Object, e As System.EventArgs) Handles btnSaveDt.Click
            InsertDrugInteractionDt()
        End Sub

        Private Sub btnAddDrugGenericMtx_Click(sender As Object, e As System.EventArgs) Handles btnAddDrugGenericMtx.Click
            InsertDrugGenericMtx()
        End Sub

        Private Sub grdDrugInteractionHd_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdDrugInteractionHd.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    Dim _lblDrugInteractionHdID As Label = CType(e.Item.FindControl("_lblDrugInteractionHdID"), Label)
                    txtDrugInteractionHdID.Text = _lblDrugInteractionHdID.Text.Trim
                    GetDrugInteractionHd()
                Case "Delete"
                    Dim _lblDrugInteractionHdID As Label = CType(e.Item.FindControl("_lblDrugInteractionHdID"), Label)
                    txtDrugInteractionHdID.Text = _lblDrugInteractionHdID.Text.Trim
            End Select
        End Sub

        Private Sub grdDrugInteractionDt_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdDrugInteractionDt.ItemCommand
            Select Case e.CommandName
                Case "Delete"
                    Dim _lblDrugInteractionDtID As Label = CType(e.Item.FindControl("_lblDrugInteractionDtID"), Label)
                    DeleteDrugInteractionDt(CDec(_lblDrugInteractionDtID.Text.Trim))
            End Select
        End Sub

        Private Sub grdDrugGenericMtx_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdDrugGenericMtx.ItemCommand
            Select Case e.CommandName
                Case "Delete"
                    Dim _lblItemCode As Label = CType(e.Item.FindControl("_lblItemCode"), Label)
                    DeleteDrugGenericMtx(_lblItemCode.Text.Trim)
            End Select
        End Sub
#End Region

#Region " Support functions for navigation bar (Controls) "
        Private Sub setToolbarVisibleButton()
            With CSSToolbar
                .VisibleButton(CSSToolbarItem.tidRefresh) = True
                .VisibleButton(CSSToolbarItem.tidApprove) = False
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidPrint) = False
                .VisibleButton(CSSToolbarItem.tidDelete) = False
                .VisibleButton(CSSToolbarItem.tidNew) = False
                .VisibleButton(CSSToolbarItem.tidNext) = False
                .VisibleButton(CSSToolbarItem.tidPrevious) = False
                .VisibleButton(CSSToolbarItem.tidSave) = False
            End With
        End Sub

        Private Sub mdlToolbar_commandBarClick(ByVal sender As Object, ByVal e As CSSToolbarItem) Handles CSSToolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidRefresh
                    GetDrugInteractionInformation()
            End Select
        End Sub
#End Region

#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
        End Function

        Private Sub setDropDownListData()
            commonFunction.SetDDL_Table(ddlGenericNameList, "DrugInteractionHd", String.Empty)
        End Sub

        Private Sub prepareScreen(ByVal isNew As Boolean)
            pnlInteraksiObat.Visible = True
            pnlEditInteraksiObat.Visible = False

            txtGenericName.Text = String.Empty
            lblBrandName.Text = String.Empty
            lblGenericGroupName.Text = String.Empty
            lblGenericName.Text = String.Empty
            lblInteractionDescription.Text = String.Empty

            txtItemCode1.Text = String.Empty
            txtItemCode2.Text = String.Empty
            txtItemName1.Text = String.Empty
            txtItemName2.Text = String.Empty
        End Sub

        Private Sub prepareScreenEdit()            
            txtDrugInteractionHdID.Text = "0"
            txtGenericNameEdit.Text = String.Empty
            txtGenericGroupName.Text = String.Empty
            txtBrandNames.Text = String.Empty
            txtInteractionDescription.Text = String.Empty
            updateViewGridDrugInteractionHd()

            ddlGenericNameList.Items.Clear()
            ddlGenericNameList.Enabled = False
            txtInteractionDescriptionDt.Text = String.Empty
            txtInteractionDescriptionDt.Enabled = False
            btnSaveDt.Enabled = False
            updateViewGridDrugInteractionDt()

            txtItemCode.Text = String.Empty
            txtItemName.Text = String.Empty
            btnAddDrugGenericMtx.Enabled = False
            updateViewGridDrugGenericMtx()
        End Sub

        Private Sub prepareScreenEditInteraction()
            ddlGenericNameList.Enabled = True
            txtInteractionDescriptionDt.Enabled = True
            commonFunction.SetDDL_Table(ddlGenericNameList, "DrugInteractionHd", String.Empty)
            txtInteractionDescriptionDt.Text = String.Empty
            btnSaveDt.Enabled = True
            updateViewGridDrugInteractionDt()
        End Sub

        Private Sub prepareScreenEditDrugGenericMtx()
            txtItemCode.Text = String.Empty
            txtItemName.Text = String.Empty
            btnAddDrugGenericMtx.Enabled = True
            updateViewGridDrugGenericMtx()
        End Sub

        Private Sub updateViewGridDrugInteractionHd()
            Dim oBR As New Common.BussinessRules.DrugInteractionHd
            grdDrugInteractionHd.DataSource = oBR.SelectAll
            grdDrugInteractionHd.DataBind()
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub updateViewGridDrugInteractionDt()
            Dim decID As Decimal = 0
            If IsNumeric(txtDrugInteractionHdID.Text.Trim) Then
                decID = CDec(txtDrugInteractionHdID.Text.Trim)
            Else
                decID = 0
            End If
            Dim oBR As New Common.BussinessRules.DrugInteractionDt
            oBR.drugInteractionHdID = decID
            grdDrugInteractionDt.DataSource = oBR.SelectByHdID
            grdDrugInteractionDt.DataBind()
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub updateViewGridDrugGenericMtx()
            Dim decID As Decimal = 0
            If IsNumeric(txtDrugInteractionHdID.Text.Trim) Then
                decID = CDec(txtDrugInteractionHdID.Text.Trim)
            Else
                decID = 0
            End If
            Dim oBR As New Common.BussinessRules.DrugGenericMtx
            oBR.drugInteractionHdID = decID
            grdDrugGenericMtx.DataSource = oBR.SelectByDrugInteractionHdID
            grdDrugGenericMtx.DataBind()
            oBR.Dispose()
            oBR = Nothing
        End Sub
#End Region

#Region " C,R,U,D "
        Private Sub GetDrugInteractionInformation()
            Page.Validate()
            If Not Page.IsValid Then Exit Sub
            Dim oBR As New Common.BussinessRules.Utility
            With oBR
                .GenericName = txtGenericName.Text.Trim
                If .GetDrugInteractionInformation.Rows.Count > 0 Then
                    lblBrandName.Text = .BrandNames.Trim
                    lblGenericGroupName.Text = .GenericGroupName.Trim
                    lblGenericName.Text = .GenericName.Trim
                    lblInteractionDescription.Text = .InteractionDescription.Trim
                Else
                    prepareScreen(True)
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Function GetDrugName(ByVal strItemCode As String) As String
            Dim strItemName As String = String.Empty
            Dim oBR As New Common.BussinessRules.Utility
            oBR.ItemCode = strItemCode.Trim
            If oBR.GetItemName.Rows.Count > 0 Then
                strItemName = oBR.ItemName.Trim
            Else
                strItemName = String.Empty
            End If
            oBR.Dispose()
            oBR = Nothing
            Return strItemName.Trim
        End Function

        Private Sub GetDrugInteractionCheckResult()
            If txtItemName1.Text.Trim = String.Empty Or txtItemName2.Text.Trim = String.Empty Then
                commonFunction.MsgBox(Me, "Item Obat-1 atau Obat-2 ada yang belum dipilih.")
                Exit Sub
            End If

            Dim oBR As New Common.BussinessRules.Utility
            With oBR
                If .GetDrugInteractionCheckResult(txtItemCode1.Text.Trim, txtItemCode2.Text.Trim).Rows.Count > 0 Then
                    lblCheckInteractionResult.Text = "TERDAPAT INTERAKSI antara obat " + txtItemName1.Text.Trim + " dengan obat " + txtItemName2.Text.Trim + vbCrLf + _
                        "Jenis Interaksi: " + oBR.InteractionTypeSCode.Trim + vbCrLf + _
                        ". Keterangan Interaksi: " + oBR.InteractionDescriptionDt.Trim
                    lblCheckInteractionResult.ForeColor = Color.Red
                    lblCheckInteractionResult.Font.Bold = True
                Else
                    lblCheckInteractionResult.Text = "TIDAK ADA INTERAKSI antara obat " + txtItemName1.Text.Trim + " dengan obat " + txtItemName2.Text.Trim
                    lblCheckInteractionResult.ForeColor = Color.Black
                    lblCheckInteractionResult.Font.Bold = False
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub GetDrugInteractionHd()
            Dim decID As Decimal = 0
            If IsNumeric(txtDrugInteractionHdID.Text.Trim) Then
                decID = CDec(txtDrugInteractionHdID.Text.Trim)
            Else
                decID = 0
            End If
            Dim oBR As New Common.BussinessRules.DrugInteractionHd
            With oBR
                .drugInteractionHdID = decID
                If .SelectOne.Rows.Count > 0 Then
                    txtGenericNameEdit.Text = .genericName.Trim
                    txtGenericGroupName.Text = .genericGroupName.Trim
                    txtBrandNames.Text = .brandNames.Trim
                    txtInteractionDescription.Text = .interactionDescription.Trim
                    prepareScreenEditInteraction()
                    prepareScreenEditDrugGenericMtx()
                Else
                    prepareScreenEdit()
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub InsertUpdateDrugInteractionHd()
            Dim decID As Decimal = 0
            If IsNumeric(txtDrugInteractionHdID.Text.Trim) Then
                decID = CDec(txtDrugInteractionHdID.Text.Trim)
            Else
                decID = 0
            End If
            Dim fNotNew As Boolean = False
            Dim oBR As New Common.BussinessRules.DrugInteractionHd
            With oBR
                .drugInteractionHdID = decID
                fNotNew = .SelectOne.Rows.Count > 0                
                .genericName = txtGenericNameEdit.Text.Trim
                .genericGroupName = txtGenericGroupName.Text.Trim
                .brandNames = txtBrandNames.Text.Trim
                .interactionDescription = txtInteractionDescription.Text.Trim
                If fNotNew Then
                    If .Update() Then
                        updateViewGridDrugInteractionHd()
                        prepareScreenEditInteraction()
                    End If
                Else
                    If .Insert() Then
                        updateViewGridDrugInteractionHd()
                        prepareScreenEditInteraction()
                    End If                    
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub InsertDrugInteractionDt()
            Dim decID As Decimal = 0
            If IsNumeric(txtDrugInteractionHdID.Text.Trim) Then
                decID = CDec(txtDrugInteractionHdID.Text.Trim)
            Else
                decID = 0
            End If
            Dim oBR As New Common.BussinessRules.DrugInteractionDt
            With oBR
                .drugInteractionHdID = decID
                .interactionGenericCode = ddlGenericNameList.SelectedValue.Trim
                .interactionTypeSCode = "DRUG"
                .interactionDescriptionDt = txtInteractionDescriptionDt.Text.Trim
                If .Insert() Then prepareScreenEditInteraction()
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub InsertDrugGenericMtx()
            Dim decID As Decimal = 0
            If IsNumeric(txtDrugInteractionHdID.Text.Trim) Then
                decID = CDec(txtDrugInteractionHdID.Text.Trim)
            Else
                decID = 0
            End If
            Dim oBR As New Common.BussinessRules.DrugGenericMtx
            With oBR
                .drugInteractionHdID = decID
                .itemCode = txtItemCode.Text.Trim                
                If .Insert() Then prepareScreenEditDrugGenericMtx()
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub DeleteDrugInteractionDt(ByVal decID As Decimal)
            Dim oBR As New Common.BussinessRules.DrugInteractionDt
            With oBR
                .drugInteractionDtID = decID
                If .Delete() Then updateViewGridDrugInteractionDt()
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub DeleteDrugGenericMtx(ByVal strItemCode As String)
            Dim decID As Decimal = 0
            If IsNumeric(txtDrugInteractionHdID.Text.Trim) Then
                decID = CDec(txtDrugInteractionHdID.Text.Trim)
            Else
                decID = 0
            End If

            Dim oBR As New Common.BussinessRules.DrugGenericMtx
            With oBR
                .itemCode = txtItemCode.Text.Trim
                .drugInteractionHdID = decID
                If .Delete() Then updateViewGridDrugGenericMtx()
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

#End Region

    End Class

End Namespace