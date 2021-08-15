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

    Public Class Project
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
        Private MenuID As String = Common.Constants.MenuID.Project_MenuID
#End Region


#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Me.IsPostBack Then
            Else
                CSSToolbar.ProfileID = MyBase.LoggedOnProfileID
                CSSToolbar.MenuID = MenuID.Trim
                CSSToolbar.setAuthorizationToolbar()
                setToolbarVisibleButton()

                prepareDDL()
                prepareScreen(True)
                SetDataGridProject()
                DataBind()
            End If
        End Sub

        Private Sub txtProjectAliasName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProjectAliasName.TextChanged
            _open(BussinessRules.QISRecStatus.CurrentRecord)
            commonFunction.Focus(Me, txtProjectName.ClientID)
        End Sub

        Private Sub grdProject_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdProject.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    txtProjectAliasName.Text = CType(e.Item.FindControl("_lblProjectAliasName"), Label).Text.Trim
                    _open(BussinessRules.QISRecStatus.CurrentRecord)
            End Select
        End Sub
#End Region

#Region " Profile Project "
        Private Sub btnProfileProjectAdd_Click(sender As Object, e As System.EventArgs) Handles btnProfileProjectAdd.Click
            _updateProfileProject(False)
        End Sub

        Private Sub btnProfileProjectAddAll_Click(sender As Object, e As System.EventArgs) Handles btnProfileProjectAddAll.Click
            _updateProfileProject(True)
        End Sub

        Private Sub btnProfileProjectRemove_Click(sender As Object, e As System.EventArgs) Handles btnProfileProjectRemove.Click
            _deleteProfileProject(False)
        End Sub

        Private Sub btnProfileProjectRemoveAll_Click(sender As Object, e As System.EventArgs) Handles btnProfileProjectRemoveAll.Click
            _deleteProfileProject(True)
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

        Private Sub prepareDDL()
            commonFunction.SetDDL_Table(ddlProjectStatus, "CommonCode", Common.Constants.GroupCode.ProjectStatus_SCode)
            commonFunction.SetDDL_Table(ddlProjectGroup, "ProjectGroup", String.Empty)
        End Sub

        Private Sub prepareScreen(ByVal isNew As Boolean)
            txtProjectID.Text = String.Empty
            txtProjectName.Text = String.Empty
            txtProjectDescription.Text = String.Empty
            ddlProjectStatus.SelectedIndex = 0
            chkIsOpenForClient.Checked = False
            txtHEXColorID.Text = "#666666"
            If isNew Then
                txtProjectAliasName.Text = String.Empty
                commonFunction.Focus(Me, txtProjectAliasName.ClientID)
            Else
                commonFunction.Focus(Me, txtProjectName.ClientID)
            End If
            SetDataGridProfileProject()
            SetEnableButton(False)
        End Sub

        Private Sub SetEnableButton(ByVal isEnable As Boolean)
            btnProfileProjectAdd.Enabled = isEnable
            btnProfileProjectAddAll.Enabled = isEnable
            btnProfileProjectRemove.Enabled = isEnable
            btnProfileProjectRemoveAll.Enabled = isEnable
        End Sub

        Private Sub SetDataGridProject()
            Dim oProject As New Common.BussinessRules.Project
            grdProject.DataSource = oProject.SelectAll
            grdProject.DataBind()
            oProject.Dispose()
            oProject = Nothing
        End Sub

        Private Sub SetDataGridProfileProject()
            Dim oPr As New Common.BussinessRules.ProjectProfile
            grdProfile.DataSource = oPr.SelectProfileNotInProjectProfileByProjectID(txtProjectID.Text.Trim)
            grdProfile.DataBind()
            grdProjectProfile.DataSource = oPr.SelectProfileByProjectID(txtProjectID.Text.Trim)
            grdProjectProfile.DataBind()
            oPr.Dispose()
            oPr = Nothing
        End Sub
#End Region


#Region " C,R,U,D "
        Private Sub _open(ByVal RecStatus As BussinessRules.QISRecStatus)
            Dim oProject As New Common.BussinessRules.Project
            With oProject
                txtProjectID.Text = Common.BussinessRules.ID.GetFieldValue("Project", "ProjectAliasName", txtProjectAliasName.Text.Trim, "ProjectID")
                .ProjectID = txtProjectID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    txtProjectAliasName.Text = .ProjectAliasName.Trim
                    txtProjectName.Text = .ProjectName.Trim
                    txtProjectDescription.Text = .ProjectDescription.Trim
                    ddlProjectStatus.SelectedValue = .ProjectStatusGCID.Trim
                    ddlProjectGroup.SelectedValue = .ProjectGroupID.Trim
                    txtHEXColorID.Text = .HexColorID.Trim
                    chkIsOpenForClient.Checked = .IsOpenForClient

                    SetDataGridProfileProject()
                    SetEnableButton(True)
                Else
                    prepareScreen(False)
                End If
            End With
            oProject.Dispose()
            oProject = Nothing
        End Sub

        Private Sub _delete()
            Dim oProject As New Common.BussinessRules.Project
            oProject.ProjectID = txtProjectID.Text.Trim
            If oProject.Delete() Then
                prepareScreen(True)
            End If
            oProject.Dispose()
            oProject = Nothing
            SetDataGridProject()
        End Sub

        Private Sub _deleteProfileProject(ByVal isRemoveAll As Boolean)
            Dim oPr As New Common.BussinessRules.ProjectProfile
            With oPr
                For Each item As DataGridItem In grdProjectProfile.Items
                    Dim chkSelect As CheckBox = CType(item.FindControl("chkSelect"), CheckBox)
                    Dim lblProjectProfileID As Label = CType(item.FindControl("_lblProjectProfileID"), Label)
                    .ProjectProfileID = lblProjectProfileID.Text.Trim
                    If isRemoveAll Then
                        .Delete()
                    Else
                        If chkSelect.Checked Then .Delete()
                    End If
                Next
            End With
            oPr.Dispose()
            oPr = Nothing

            SetDataGridProfileProject()
        End Sub

        Private Sub _update()
            Dim isNew As Boolean = True

            Dim oProject As New Common.BussinessRules.Project
            With oProject
                .ProjectID = txtProjectID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    isNew = False
                Else
                    isNew = True
                End If
                .ProjectAliasName = txtProjectAliasName.Text.Trim
                .ProjectName = txtProjectName.Text.Trim
                .ProjectDescription = txtProjectDescription.Text.Trim
                .ProjectStatusGCID = ddlProjectStatus.SelectedValue.Trim
                .ProjectGroupID = ddlProjectGroup.SelectedValue.Trim
                .HexColorID = txtHEXColorID.Text.Trim
                .IsOpenForClient = chkIsOpenForClient.Checked
                .userIDinsert = MyBase.LoggedOnUserID
                .userIDupdate = MyBase.LoggedOnUserID
                If isNew Then
                    If .Insert() Then
                        txtProjectID.Text = .ProjectID
                        SetDataGridProject()
                        SetEnableButton(True)
                        SetDataGridProfileProject()
                    End If
                Else
                    If .Update() Then
                        SetDataGridProfileProject()
                    End If
                End If
            End With
            oProject.Dispose()
            oProject = Nothing
        End Sub

        Private Sub _updateProfileProject(ByVal isAddAll As Boolean)
            Dim oPr As New Common.BussinessRules.ProjectProfile
            With oPr
                For Each item As DataGridItem In grdProfile.Items
                    Dim chkSelect As CheckBox = CType(item.FindControl("chkSelect"), CheckBox)
                    Dim lblProfileID As Label = CType(item.FindControl("_lblProfileID"), Label)
                    .ProjectID = txtProjectID.Text.Trim
                    .ProfileID = lblProfileID.Text.Trim
                    If isAddAll Then
                        .Insert()
                    Else
                        If chkSelect.Checked Then .Insert()
                    End If
                Next
            End With
            oPr.Dispose()
            oPr = Nothing

            SetDataGridProfileProject()
        End Sub
#End Region
    End Class

End Namespace