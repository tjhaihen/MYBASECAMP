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

    Public Class ProjectGroup
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

                prepareScreen(True)
                SetDataGridProjectGroup()
                DataBind()
            End If
        End Sub

        Private Sub txtProjectGroupName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProjectGroupName.TextChanged
            _open(BussinessRules.QISRecStatus.CurrentRecord)
            commonFunction.Focus(Me, txtProjectGroupName.ClientID)
        End Sub

        Private Sub grdProjectGroup_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdProjectGroup.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    txtProjectGroupID.Text = CType(e.Item.FindControl("_lblProjectGroupID"), Label).Text.Trim
                    _open(BussinessRules.QISRecStatus.CurrentRecord)
            End Select
        End Sub
#End Region


#Region " Support functions for navigation bar (Controls) "
        Private Sub setToolbarVisibleButton()
            With CSSToolbar
                .VisibleButton(CSSToolbarItem.tidApprove) = False
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidPrint) = False
            End With
        End Sub

        Private Sub mdlToolbar_commandBarClick(ByVal sender As Object, ByVal e As CSSToolbarItem) Handles CSSToolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidDelete
                    _delete()
                Case CSSToolbarItem.tidNew
                    prepareScreen(True)
                Case CSSToolbarItem.tidNext
                    _open(BussinessRules.QISRecStatus.NextRecord)
                Case CSSToolbarItem.tidPrevious
                    _open(BussinessRules.QISRecStatus.PreviousRecord)
                Case CSSToolbarItem.tidSave
                    _update()
            End Select
        End Sub
#End Region


#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
        End Function

        Private Sub prepareScreen(ByVal isNew As Boolean)
            If isNew Then
                txtProjectGroupID.Text = String.Empty                
            End If
            commonFunction.Focus(Me, txtProjectGroupName.ClientID)
        End Sub

        Private Sub SetDataGridProjectGroup()
            Dim oProjectGroup As New Common.BussinessRules.ProjectGroup
            grdProjectGroup.DataSource = oProjectGroup.SelectAll
            grdProjectGroup.DataBind()
            oProjectGroup.Dispose()
            oProjectGroup = Nothing
        End Sub
#End Region


#Region " C,R,U,D "
        Private Sub _open(ByVal RecStatus As BussinessRules.QISRecStatus)
            Dim oProject As New Common.BussinessRules.ProjectGroup
            With oProject
                .ProjectGroupID = txtProjectGroupID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    txtProjectGroupName.Text = .ProjectGroupName.Trim
                    txtDisplaySequence.Text = .Sequence.Trim                    
                Else
                    prepareScreen(True)
                End If
            End With
            oProject.Dispose()
            oProject = Nothing
        End Sub

        Private Sub _delete()
            Dim oProject As New Common.BussinessRules.ProjectGroup
            oProject.ProjectGroupID = txtProjectGroupID.Text.Trim
            If oProject.Delete() Then
                prepareScreen(True)
            End If
            oProject.Dispose()
            oProject = Nothing
            SetDataGridProjectGroup()
        End Sub

        Private Sub _update()
            Dim isNew As Boolean = True

            Dim oProject As New Common.BussinessRules.ProjectGroup
            With oProject
                .ProjectGroupID = txtProjectGroupID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    isNew = False
                Else
                    isNew = True
                End If
                .ProjectGroupName = txtProjectGroupName.Text.Trim
                .Sequence = txtDisplaySequence.Text.Trim
                If isNew Then
                    If .Insert() Then txtProjectGroupID.Text = .ProjectGroupID
                Else
                    .Update()
                End If
            End With
            oProject.Dispose()
            oProject = Nothing
            prepareScreen(True)
            SetDataGridProjectGroup()
        End Sub
#End Region
    End Class

End Namespace