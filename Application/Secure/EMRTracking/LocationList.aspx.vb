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

Namespace QIS.Web.EMRTracking

    Public Class LocationList
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
#End Region


#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Me.IsPostBack Then
            Else
                setToolbarVisibleButton()

                prepareScreen(True)
                SetDataGridLocationGroup()
                DataBind()
            End If
        End Sub

        Private Sub txtEMRlocationGroupCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEMRlocationGroupCode.TextChanged
            _open(BussinessRules.QISRecStatus.CurrentRecord)
            commonFunction.Focus(Me, txtEMRlocationGroupName.ClientID)
        End Sub

        Private Sub grdEMRLocationGroup_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdEMRLocationGroup.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    txtEMRlocationGroupCode.Text = CType(e.Item.FindControl("_lblEMRlocationGroupCode"), Label).Text.Trim
                    _open(BussinessRules.QISRecStatus.CurrentRecord)
            End Select
        End Sub

        Private Sub grdEMRLocation_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdEMRLocation.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    txtEMRLocationCode.Text = CType(e.Item.FindControl("_lblEMRlocationCode"), Label).Text.Trim
                    _openLocation(BussinessRules.QISRecStatus.CurrentRecord)
            End Select
        End Sub

        Private Sub btnSaveLocation_Click(sender As Object, e As System.EventArgs) Handles btnSaveLocation.Click
            _insertupdateLocation()
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
            End With
        End Sub

        Private Sub mdlToolbar_commandBarClick(ByVal sender As Object, ByVal e As CSSToolbarItem) Handles CSSToolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidNew
                    prepareScreen(True)
                    prepareScreenLocation(True)
                    SetDataGridLocation()
                Case CSSToolbarItem.tidSave
                    _insertupdate()
            End Select
        End Sub
#End Region


#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
        End Function

        Private Sub prepareScreen(ByVal isNew As Boolean)
            If isNew Then
                txtEMRlocationGroupCode.Text = String.Empty
                txtEMRlocationGroupName.Text = String.Empty
                chkIsActive.Checked = True
            End If
            commonFunction.Focus(Me, txtEMRlocationGroupName.ClientID)
        End Sub

        Private Sub prepareScreenLocation(ByVal isNew As Boolean)
            If isNew Then
                txtEMRLocationCode.Text = String.Empty
                txtEMRLocationName.Text = String.Empty
                chkIsActiveLocation.Checked = True
            End If
            commonFunction.Focus(Me, txtEMRLocationName.ClientID)
        End Sub

        Private Sub SetDataGridLocationGroup()
            Dim oBR As New Common.BussinessRules.EMRlocationGroup
            grdEMRLocationGroup.DataSource = oBR.SelectAll
            grdEMRLocationGroup.DataBind()
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub SetDataGridLocation()
            Dim oBR As New Common.BussinessRules.EMRlocation
            oBR.LocationGroupCode = txtEMRlocationGroupCode.Text.Trim
            grdEMRLocation.DataSource = oBR.SelectByLocationGroup
            grdEMRLocation.DataBind()
            oBR.Dispose()
            oBR = Nothing
        End Sub
#End Region


#Region " C,R,U,D "
        Private Sub _open(ByVal RecStatus As BussinessRules.QISRecStatus)
            Dim oBR As New Common.BussinessRules.EMRlocationGroup
            With oBR
                .LocationGroupCode = txtEMRlocationGroupCode.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    txtEMRlocationGroupName.Text = .LocationGroupName.Trim
                    chkIsActive.Checked = .IsActive
                Else
                    prepareScreen(True)
                End If
            End With
            oBR.Dispose()
            oBR = Nothing

            SetDataGridLocation()
        End Sub

        Private Sub _openLocation(ByVal RecStatus As BussinessRules.QISRecStatus)
            Dim oBR As New Common.BussinessRules.EMRlocation
            With oBR
                .LocationGroupCode = txtEMRlocationGroupCode.Text.Trim
                .LocationCode = txtEMRLocationCode.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    txtEMRLocationName.Text = .LocationName.Trim
                    chkIsActiveLocation.Checked = .IsActive
                Else
                    prepareScreenLocation(True)
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub _delete()
            Dim oBR As New Common.BussinessRules.EMRlocationGroup
            oBR.LocationGroupCode = txtEMRlocationGroupCode.Text.Trim
            If oBR.Delete() Then
                prepareScreen(True)
            End If
            oBR.Dispose()
            oBR = Nothing
            SetDataGridLocationGroup()
            SetDataGridLocation()
        End Sub

        Private Sub _insertupdate()
            Dim isNew As Boolean = True

            Dim oBR As New Common.BussinessRules.EMRlocationGroup
            With oBR
                .LocationGroupCode = txtEMRlocationGroupCode.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    isNew = False
                Else
                    isNew = True
                End If
                .LocationGroupName = txtEMRlocationGroupName.Text.Trim
                .IsActive = chkIsActive.Checked
                If isNew Then
                    If .Insert() Then txtEMRlocationGroupCode.Text = .LocationGroupCode.Trim
                Else
                    .Update()
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
            prepareScreen(True)
            SetDataGridLocationGroup()
            SetDataGridLocation()
        End Sub

        Private Sub _insertupdateLocation()
            Dim isNew As Boolean = True

            Dim oBR As New Common.BussinessRules.EMRlocation
            With oBR
                .LocationCode = txtEMRLocationCode.Text.Trim
                .LocationGroupCode = txtEMRlocationGroupCode.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    isNew = False
                Else
                    isNew = True
                End If
                .LocationName = txtEMRLocationName.Text.Trim
                .IsActive = chkIsActiveLocation.Checked
                If isNew Then
                    If .Insert() Then txtEMRLocationCode.Text = .LocationCode.Trim
                Else
                    .Update()
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
            prepareScreenLocation(True)
            SetDataGridLocation()
        End Sub
#End Region

    End Class

End Namespace