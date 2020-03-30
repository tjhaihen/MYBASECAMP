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

    Public Class Profile
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
        Private MenuID As String = Common.Constants.MenuID.Profile_MenuID
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
                SetDataGridProfile()
                SetDataGridProfileUnit()
                DataBind()
            End If
        End Sub

        Private Sub txtProfileCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProfileCode.TextChanged
            _Open(BussinessRules.QISRecStatus.CurrentRecord)
            commonFunction.Focus(Me, txtProfileName.ClientID)
        End Sub

        Private Sub grdProfile_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdProfile.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    txtProfileCode.Text = CType(e.Item.FindControl("_lblProfileCode"), Label).Text.Trim
                    _Open(BussinessRules.QISRecStatus.CurrentRecord)
            End Select
        End Sub

#Region " Profile Menu "
        Private Sub btnProfileMenuAdd_Click(sender As Object, e As System.EventArgs) Handles btnProfileMenuAdd.Click
            _updateProfileMenu(False)
        End Sub

        Private Sub btnProfileMenuAddAll_Click(sender As Object, e As System.EventArgs) Handles btnProfileMenuAddAll.Click
            _updateProfileMenu(True)
        End Sub

        Private Sub btnProfileMenuRemove_Click(sender As Object, e As System.EventArgs) Handles btnProfileMenuRemove.Click
            _deleteProfileMenu(False)
        End Sub

        Private Sub btnProfileMenuRemoveAll_Click(sender As Object, e As System.EventArgs) Handles btnProfileMenuRemoveAll.Click
            _deleteProfileMenu(True)
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

#Region " Profile Unit "
        Private Sub btnProfileUnitAdd_Click(sender As Object, e As System.EventArgs) Handles btnProfileUnitAdd.Click
            _updateProfileUnit(False)
        End Sub

        Private Sub btnProfileUnitAddAll_Click(sender As Object, e As System.EventArgs) Handles btnProfileUnitAddAll.Click
            _updateProfileUnit(True)
        End Sub

        Private Sub btnProfileUnitRemove_Click(sender As Object, e As System.EventArgs) Handles btnProfileUnitRemove.Click
            _deleteProfileUnit(False)
        End Sub

        Private Sub btnProfileUnitRemoveAll_Click(sender As Object, e As System.EventArgs) Handles btnProfileUnitRemoveAll.Click
            _deleteProfileUnit(True)
        End Sub

        Private Sub ddlDepartmentFilter_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlDepartmentFilter.SelectedIndexChanged
            SetDataGridProfileUnit()
        End Sub
#End Region

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
                    _Open(BussinessRules.QISRecStatus.NextRecord)
                Case CSSToolbarItem.tidPrevious
                    _Open(BussinessRules.QISRecStatus.PreviousRecord)
                Case CSSToolbarItem.tidSave
                    _update()
            End Select
        End Sub
#End Region


#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
        End Function

        Private Sub prepareScreen(ByVal isNew As Boolean)
            txtProfileID.Text = String.Empty
            txtProfileName.Text = String.Empty
            chkIsActive.Checked = True
            chkIsSystem.Checked = False
            If isNew Then
                txtProfileCode.Text = String.Empty
                commonFunction.Focus(Me, txtProfileCode.ClientID)
            Else
                commonFunction.Focus(Me, txtProfileName.ClientID)
            End If
            SetEnableButton(False)
            SetDataGridProfile()
            SetDataGridProfileMenu()
            SetDataGridProfileProject()
            SetDataGridProfileUnit()
        End Sub

        Private Sub SetEnableButton(ByVal isEnable As Boolean)
            btnProfileMenuAdd.Enabled = isEnable
            btnProfileMenuAddAll.Enabled = isEnable
            btnProfileMenuRemove.Enabled = isEnable
            btnProfileMenuRemoveAll.Enabled = isEnable

            btnProfileUnitAdd.Enabled = isEnable
            btnProfileUnitAddAll.Enabled = isEnable
            btnProfileUnitRemove.Enabled = isEnable
            btnProfileUnitRemoveAll.Enabled = isEnable
        End Sub

        Private Sub SetDataGridProfile()
            Dim oProd As New Common.BussinessRules.Profile
            grdProfile.DataSource = oProd.SelectAll
            grdProfile.DataBind()
            oProd.Dispose()
            oProd = Nothing
        End Sub

        Private Sub SetDataGridProfileMenu()
            Dim oPr As New Common.BussinessRules.ProfileMenu
            grdMenu.DataSource = oPr.SelectMenuNotInProfileMenuByProfileID(txtProfileID.Text.Trim)
            grdMenu.DataBind()
            grdProfileMenu.DataSource = oPr.SelectMenuByProfileID(txtProfileID.Text.Trim)
            grdProfileMenu.DataBind()
            oPr.Dispose()
            oPr = Nothing
        End Sub

        Private Sub SetDataGridProfileProject()
            Dim oPr As New Common.BussinessRules.ProjectProfile
            grdProject.DataSource = oPr.SelectProjectNotInUserProjectByUserID(txtProfileID.Text.Trim)
            grdProject.DataBind()
            grdProjectProfile.DataSource = oPr.SelectProjectByProfileID(txtProfileID.Text.Trim)
            grdProjectProfile.DataBind()
            oPr.Dispose()
            oPr = Nothing
        End Sub

        Private Sub SetDataGridProfileUnit()
            If Common.Methods.GetCommonCode(Common.Constants.SystemSetting.SystemSetting_SYSEMR, Common.Constants.GroupCode.System_SCode).Trim = "1" Then
                Dim oPu As New Common.BussinessRules.ProfileUnit
                grdUnit.DataSource = oPu.SelectUnitNotInProfileUnitByProfileIDDepartmentID(txtProfileID.Text.Trim, ddlDepartmentFilter.SelectedValue.Trim)
                grdUnit.DataBind()
                grdProfileUnit.DataSource = oPu.SelectUnitByProfileIDDepartmentID(txtProfileID.Text.Trim, ddlDepartmentFilter.SelectedValue.Trim)
                grdProfileUnit.DataBind()
                oPu.Dispose()
                oPu = Nothing
            End If            
        End Sub
#End Region


#Region " C,R,U,D "
        Private Sub _Open(ByVal RecStatus As BussinessRules.QISRecStatus)
            Dim oProd As New Common.BussinessRules.Profile
            With oProd
                txtProfileID.Text = Common.BussinessRules.ID.GetFieldValue("Profile", "ProfileCode", txtProfileCode.Text.Trim, "ProfileID")
                .ProfileID = txtProfileID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    txtProfileCode.Text = .ProfileCode.Trim
                    txtProfileName.Text = .ProfileName.Trim
                    chkIsActive.Checked = .IsActive
                    chkIsSystem.Checked = .IsSystem
                    SetEnableButton(True)
                Else
                    prepareScreen(False)
                End If
            End With
            oProd.Dispose()
            oProd = Nothing

            SetDataGridProfileMenu()
            SetDataGridProfileProject()
            SetDataGridProfileUnit()
        End Sub

        Private Sub _delete()
            If Not chkIsSystem.Checked Then
                Dim oProd As New Common.BussinessRules.Profile
                With oProd
                    .ProfileID = txtProfileID.Text.Trim
                    If .Delete() Then
                        prepareScreen(True)
                        SetDataGridProfile()
                    End If
                End With
                oProd.Dispose()
                oProd = Nothing
            Else
                commonFunction.MsgBox(Me, Common.Constants.MessageBoxText.Validate_IsSystem)
                Exit Sub
            End If

            SetDataGridProfileUnit()
            SetDataGridProfileMenu()
            SetDataGridProfile()
        End Sub

        Private Sub _deleteProfileMenu(ByVal isRemoveAll As Boolean)
            Dim oPr As New Common.BussinessRules.ProfileMenu
            With oPr
                For Each item As DataGridItem In grdProfileMenu.Items
                    Dim chkSelect As CheckBox = CType(item.FindControl("chkSelect"), CheckBox)
                    Dim lblProfileMenuID As Label = CType(item.FindControl("_lblProfileMenuID"), Label)
                    .ProfileMenuID = lblProfileMenuID.Text.Trim
                    If isRemoveAll Then
                        .Delete()
                    Else
                        If chkSelect.Checked Then .Delete()
                    End If
                Next
            End With
            oPr.Dispose()
            oPr = Nothing

            SetDataGridProfileMenu()
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

        Private Sub _deleteProfileUnit(ByVal isRemoveAll As Boolean)
            Dim oPr As New Common.BussinessRules.ProfileUnit
            With oPr
                For Each item As DataGridItem In grdProfileUnit.Items
                    Dim chkSelect As CheckBox = CType(item.FindControl("chkSelect"), CheckBox)
                    Dim lblProfileUnitID As Label = CType(item.FindControl("_lblProfileUnitID"), Label)
                    .ProfileUnitID = lblProfileUnitID.Text.Trim
                    If isRemoveAll Then
                        .Delete()
                    Else
                        If chkSelect.Checked Then .Delete()
                    End If
                Next
            End With
            oPr.Dispose()
            oPr = Nothing

            SetDataGridProfileUnit()
        End Sub

        Private Sub _update()
            If Not chkIsSystem.Checked Then
                Page.Validate()
                If Not Page.IsValid Then Exit Sub
                Dim isNew As Boolean = True

                Dim oProd As New Common.BussinessRules.Profile
                With oProd
                    .ProfileID = txtProfileID.Text.Trim
                    If .SelectOne.Rows.Count > 0 Then
                        isNew = False
                    Else
                        isNew = True
                    End If
                    .ProfileCode = txtProfileCode.Text.Trim
                    .ProfileName = txtProfileName.Text.Trim
                    .IsActive = chkIsActive.Checked
                    .IsSystem = False
                    .UserIDInsert = MyBase.LoggedOnUserID
                    .UserIDUpdate = MyBase.LoggedOnUserID
                    If isNew Then
                        If .Insert() Then
                            txtProfileID.Text = .ProfileID
                            SetEnableButton(True)
                        End If
                    Else
                        If .Update() Then SetEnableButton(True)
                    End If
                End With
                oProd.Dispose()
                oProd = Nothing
                'prepareScreen(True)
                SetDataGridProfile()
                SetDataGridProfileMenu()
                SetDataGridProfileUnit()
            Else
                commonFunction.MsgBox(Me, Common.Constants.MessageBoxText.Validate_IsSystem)
                Exit Sub
            End If
        End Sub

        Private Sub _updateProfileMenu(ByVal isAddAll As Boolean)
            Dim oPr As New Common.BussinessRules.ProfileMenu
            With oPr
                For Each item As DataGridItem In grdMenu.Items
                    Dim chkSelect As CheckBox = CType(item.FindControl("chkSelect"), CheckBox)
                    Dim lblMenuID As Label = CType(item.FindControl("_lblMenuID"), Label)
                    .ProfileID = txtProfileID.Text.Trim
                    .MenuID = lblMenuID.Text.Trim
                    .isAllowCreate = True
                    .isAllowDelete = True
                    .isAllowRead = True
                    .isAllowUpdate = True
                    .UserIDInsert = MyBase.LoggedOnUserID
                    If isAddAll Then
                        .Insert()
                    Else
                        If chkSelect.Checked Then .Insert()
                    End If
                Next
            End With
            oPr.Dispose()
            oPr = Nothing
            SetDataGridProfileMenu()
        End Sub

        Private Sub _updateProfileProject(ByVal isAddAll As Boolean)
            Dim oPr As New Common.BussinessRules.ProjectProfile
            With oPr
                For Each item As DataGridItem In grdProject.Items
                    Dim chkSelect As CheckBox = CType(item.FindControl("chkSelect"), CheckBox)
                    Dim lblProjectID As Label = CType(item.FindControl("_lblProjectID"), Label)
                    .ProfileID = txtProfileID.Text.Trim
                    .ProjectID = lblProjectID.Text.Trim
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

        Private Sub _updateProfileUnit(ByVal isAddAll As Boolean)
            Dim oPr As New Common.BussinessRules.ProfileUnit
            With oPr
                For Each item As DataGridItem In grdUnit.Items
                    Dim chkSelect As CheckBox = CType(item.FindControl("chkSelect"), CheckBox)
                    Dim lblUnitID As Label = CType(item.FindControl("_lblUnitID"), Label)
                    .ProfileID = txtProfileID.Text.Trim
                    .UnitID = lblUnitID.Text.Trim
                    .DepartmentID = ddlDepartmentFilter.SelectedValue.Trim                    
                    If isAddAll Then
                        .Insert()
                    Else
                        If chkSelect.Checked Then .Insert()
                    End If
                Next
            End With
            oPr.Dispose()
            oPr = Nothing
            SetDataGridProfileUnit()
        End Sub
#End Region

    End Class

End Namespace