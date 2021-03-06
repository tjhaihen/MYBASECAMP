Option Strict On
Option Explicit On

Imports System
Imports System.Text
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.Security
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.IO
Imports Microsoft.VisualBasic

Imports System.Data.SqlTypes

Imports QIS.Common

Namespace QIS.Web.Secure

    Public Class User
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
        Private MenuID As String = Common.Constants.MenuID.People_MenuID
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
                SetDataGridUser()
                DataBind()
            End If
        End Sub

        Private Sub txtUsername_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUserName.TextChanged
            _open(BussinessRules.QISRecStatus.CurrentRecord)            
        End Sub

        Private Sub grdUser_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdUser.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    txtUserName.Text = CType(e.Item.FindControl("_lblUsername"), Label).Text.Trim
                    _open(BussinessRules.QISRecStatus.CurrentRecord)
            End Select
        End Sub

#Region " User Profile "
        Private Sub btnUserProfileAdd_Click(sender As Object, e As System.EventArgs) Handles btnUserProfileAdd.Click
            _updateUserProfile(False)
        End Sub

        Private Sub btnUserProfileAddAll_Click(sender As Object, e As System.EventArgs) Handles btnUserProfileAddAll.Click
            _updateUserProfile(True)
        End Sub

        Private Sub btnUserProfileRemove_Click(sender As Object, e As System.EventArgs) Handles btnUserProfileRemove.Click
            _deleteUserProfile(False)
        End Sub

        Private Sub btnUserProfileRemoveAll_Click(sender As Object, e As System.EventArgs) Handles btnUserProfileRemoveAll.Click
            _deleteUserProfile(True)
        End Sub
#End Region

#Region " User Project "
        Private Sub btnUserProjectAdd_Click(sender As Object, e As System.EventArgs) Handles btnUserProjectAdd.Click
            _updateUserProject(False)
        End Sub

        Private Sub btnUserProjectAddAll_Click(sender As Object, e As System.EventArgs) Handles btnUserProjectAddAll.Click
            _updateUserProject(True)
        End Sub

        Private Sub btnUserProjectRemove_Click(sender As Object, e As System.EventArgs) Handles btnUserProjectRemove.Click
            _deleteUserProject(False)
        End Sub

        Private Sub btnUserProjectRemoveAll_Click(sender As Object, e As System.EventArgs) Handles btnUserProjectRemoveAll.Click
            _deleteUserProject(True)
        End Sub
#End Region

#End Region


#Region " Support functions for navigation bar (Controls) "
        Private Sub setToolbarVisibleButton()
            With CSSToolbar
                .VisibleButton(CSSToolbarItem.tidDelete) = False
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
            commonFunction.SetDDL_Table(ddlSex, "CommonCode", Common.Constants.GroupCode.Sex_SCode)
            commonFunction.SetDDL_Table(ddlGender, "CommonCode", Common.Constants.GroupCode.Sex_SCode)
            commonFunction.SetDDL_Table(ddlReligion, "CommonCode", Common.Constants.GroupCode.Religion_SCode)
            commonFunction.SetDDL_Table(ddlNationality, "CommonCode", Common.Constants.GroupCode.Nationality_SCode)
        End Sub

        Private Sub prepareScreen(ByVal isNew As Boolean)
            txtLinkParamedicID.Text = String.Empty
            chkIsPhysician.Checked = False
            pnlEMR.Visible = False
            If Common.Methods.GetCommonCode(Common.Constants.SystemSetting.SystemSetting_SYSEMR, Common.Constants.GroupCode.System_SCode).Trim = "1" Then
                pnlEMR.Visible = True
            End If
            txtUserID.Text = String.Empty
            txtPersonID.Text = String.Empty
            chkIsActive.Checked = True
            chkResetPassword.Checked = False
            If isNew Then
                txtUserName.Text = String.Empty
                commonFunction.Focus(Me, txtUserName.ClientID)
            End If
            txtInitial.Text = String.Empty
            txtDepartment.Text = String.Empty
            prepareScreenPerson()
            SetEnableButton(False)
            SetDataGridUserProfile()
            SetDataGridUserProject()
        End Sub

        Private Sub prepareScreenPerson()
            txtPersonID.Text = String.Empty
            txtSalutation.Text = String.Empty
            txtFirstName.Text = String.Empty
            txtMiddleName.Text = String.Empty
            txtLastName.Text = String.Empty
            txtAcademicTitle.Text = String.Empty
            ddlSex.SelectedIndex = 0
            ddlGender.SelectedIndex = 0
            ddlReligion.SelectedIndex = 0
            ddlNationality.SelectedIndex = 0
            txtAddress1.Text = String.Empty
            txtAddress2.Text = String.Empty
            txtAddress3.Text = String.Empty
            txtCity.Text = String.Empty
            txtPostalCode.Text = String.Empty
            txtPhone.Text = String.Empty
            txtMobile.Text = String.Empty
            txtFax.Text = String.Empty
            txtEmail.Text = String.Empty
            txtUrl.Text = String.Empty
        End Sub

        Private Sub SetEnableButton(ByVal isEnable As Boolean)
            btnUserProfileAdd.Enabled = isEnable
            btnUserProfileAddAll.Enabled = isEnable
            btnUserProfileRemove.Enabled = isEnable
            btnUserProfileRemoveAll.Enabled = isEnable

            btnUserProjectAdd.Enabled = isEnable
            btnUserProjectAddAll.Enabled = isEnable
            btnUserProjectRemove.Enabled = isEnable
            btnUserProjectRemoveAll.Enabled = isEnable
        End Sub

        Private Sub SetDataGridUser()
            Dim oRsrc As New Common.BussinessRules.User
            grdUser.DataSource = oRsrc.SelectUserPerson
            grdUser.DataBind()
            oRsrc.Dispose()
            oRsrc = Nothing
        End Sub

        Private Sub SetDataGridUserProfile()
            Dim oPr As New Common.BussinessRules.UserProfile
            grdProfile.DataSource = oPr.SelectProfileNotInUserProfileByUserID(txtUserID.Text.Trim)
            grdProfile.DataBind()
            grdUserProfile.DataSource = oPr.SelectProfileByUserID(txtUserID.Text.Trim)
            grdUserProfile.DataBind()
            oPr.Dispose()
            oPr = Nothing
        End Sub

        Private Sub SetDataGridUserProject()
            Dim oPr As New Common.BussinessRules.ProjectUser
            grdProject.DataSource = oPr.SelectProjectNotInUserProjectByUserID(txtUserID.Text.Trim)
            grdProject.DataBind()
            grdProjectUser.DataSource = oPr.SelectProjectByUserID(txtUserID.Text.Trim)
            grdProjectUser.DataBind()
            oPr.Dispose()
            oPr = Nothing
        End Sub
#End Region


#Region " C,R,U,D "
        Private Sub _open(ByVal RecStatus As BussinessRules.QISRecStatus)
            Dim oRsrc As New Common.BussinessRules.User
            With oRsrc
                txtUserID.Text = Common.BussinessRules.ID.GetFieldValue("User", "Username", txtUserName.Text.Trim, "UserID")
                .UserID = txtUserID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    txtUserName.Text = .UserName.Trim
                    txtPersonID.Text = .personID.Trim
                    _openPerson()
                    chkIsActive.Checked = .isActive
                    txtLinkParamedicID.Text = .LinkParamedicID.Trim
                    chkIsPhysician.Checked = .isPhysician
                    txtInitial.Text = .Initial.Trim
                    txtDepartment.Text = .Department.Trim
                    SetEnableButton(True)
                Else
                    prepareScreen(False)                    
                    commonFunction.Focus(Me, txtPassword.ClientID)
                End If
            End With
            oRsrc.Dispose()
            oRsrc = Nothing

            SetDataGridUserProfile()
            SetDataGridUserProject()
        End Sub

        Private Sub _openPerson()
            Dim oPerson As New Common.BussinessRules.Person
            With oPerson
                .PersonID = txtPersonID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    txtSalutation.Text = .Salutation.Trim
                    txtFirstName.Text = .FirstName.Trim
                    txtMiddleName.Text = .MiddleName.Trim
                    txtLastName.Text = .LastName.Trim
                    txtAcademicTitle.Text = .AcademicTitle.Trim
                    ddlSex.SelectedValue = .SexSCode.Trim
                    ddlGender.SelectedValue = .GenderSCode.Trim
                    ddlReligion.SelectedValue = .ReligionSCode.Trim
                    ddlNationality.SelectedValue = .NationalitySCode.Trim
                    txtAddress1.Text = .Address1.Trim
                    txtAddress2.Text = .Address2.Trim
                    txtAddress3.Text = .Address3.Trim
                    txtCity.Text = .City.Trim
                    txtPostalCode.Text = .PostalCode.Trim
                    txtPhone.Text = .Phone.Trim
                    txtMobile.Text = .Mobile.Trim
                    txtFax.Text = .Fax.Trim
                    txtEmail.Text = .Email.Trim
                    txtUrl.Text = .Url.Trim
                Else
                    prepareScreenPerson()
                End If
            End With
            oPerson.Dispose()
            oPerson = Nothing
        End Sub

        Private Sub _delete()
            Dim oPerson As New Common.BussinessRules.Person
            oPerson.PersonID = txtPersonID.Text.Trim
            If oPerson.Delete() Then
                Dim oProd As New Common.BussinessRules.User
                oProd.UserID = txtUserID.Text.Trim
                If oProd.Delete() Then
                    prepareScreen(True)
                End If
                oProd.Dispose()
                oProd = Nothing
            End If
            oPerson.Dispose()
            oPerson = Nothing
            SetDataGridUser()
        End Sub

        Private Sub _deleteUserProfile(ByVal isRemoveAll As Boolean)
            Dim oPr As New Common.BussinessRules.UserProfile
            With oPr
                For Each item As DataGridItem In grdUserProfile.Items
                    Dim chkSelect As CheckBox = CType(item.FindControl("chkSelect"), CheckBox)
                    Dim lblUserProfileID As Label = CType(item.FindControl("_lblUserProfileID"), Label)
                    .UserProfileID = lblUserProfileID.Text.Trim
                    If isRemoveAll Then
                        .Delete()
                    Else
                        If chkSelect.Checked Then .Delete()
                    End If
                Next
            End With
            oPr.Dispose()
            oPr = Nothing

            SetDataGridUserProfile()
        End Sub

        Private Sub _deleteUserProject(ByVal isRemoveAll As Boolean)
            Dim oPr As New Common.BussinessRules.ProjectUser
            With oPr
                For Each item As DataGridItem In grdProjectUser.Items
                    Dim chkSelect As CheckBox = CType(item.FindControl("chkSelect"), CheckBox)
                    Dim lblProjectUserID As Label = CType(item.FindControl("_lblProjectUserID"), Label)
                    .ProjectUserID = lblProjectUserID.Text.Trim
                    If isRemoveAll Then
                        .Delete()
                    Else
                        If chkSelect.Checked Then .Delete()
                    End If
                Next
            End With
            oPr.Dispose()
            oPr = Nothing

            SetDataGridUserProject()
        End Sub

        Private Sub _update()
            _updatePerson()
            Dim isNew As Boolean = True

            Dim oRsrc As New Common.BussinessRules.User
            With oRsrc
                .UserID = txtUserID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    isNew = False
                Else
                    isNew = True
                End If
                .UserName = txtUserName.Text.Trim
                .Password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim, "sha1")
                .AuthorizePassword = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim, "sha1")
                .PersonID = txtPersonID.Text.Trim
                .isActive = chkIsActive.Checked
                .UserIDInsert = MyBase.LoggedOnUserID
                .UserIDUpdate = MyBase.LoggedOnUserID
                .LinkParamedicID = txtLinkParamedicID.Text.Trim
                .isPhysician = chkIsPhysician.Checked
                .Initial = txtInitial.Text.Trim
                .Department = txtDepartment.Text.Trim
                If isNew Then
                    If .Insert() Then
                        txtUserID.Text = .UserID
                        SetEnableButton(True)
                    End If
                Else
                    If .UpdateAll(chkResetPassword.Checked, False) Then SetEnableButton(True)
                End If
            End With
            oRsrc.Dispose()
            oRsrc = Nothing
            SetDataGridUser()
        End Sub

        Private Sub _updatePerson()
            Page.Validate()
            If Not Page.IsValid Then Exit Sub
            Dim isNew As Boolean = True

            Dim oPerson As New Common.BussinessRules.Person
            With oPerson
                .PersonID = txtPersonID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    isNew = False
                Else
                    isNew = True
                End If
                .Salutation = txtSalutation.Text.Trim
                .FirstName = txtFirstName.Text.Trim
                .MiddleName = txtMiddleName.Text.Trim
                .LastName = txtLastName.Text.Trim
                .AcademicTitle = txtAcademicTitle.Text.Trim
                .SexSCode = ddlSex.SelectedValue.Trim
                .GenderSCode = ddlGender.SelectedValue.Trim
                .ReligionSCode = ddlReligion.SelectedValue.Trim
                .NationalitySCode = ddlNationality.SelectedValue.Trim
                .Address1 = txtAddress1.Text.Trim
                .Address2 = txtAddress2.Text.Trim
                .Address3 = txtAddress3.Text.Trim
                .City = txtCity.Text.Trim
                .PostalCode = txtPostalCode.Text.Trim
                .Phone = txtPhone.Text.Trim
                .Mobile = txtMobile.Text.Trim
                .Fax = txtFax.Text.Trim
                .Email = txtEmail.Text.Trim
                .Url = txtUrl.Text.Trim
                .userIDinsert = MyBase.LoggedOnUserID
                .userIDupdate = MyBase.LoggedOnUserID
                If isNew Then
                    If .Insert() Then txtPersonID.Text = .PersonID
                Else
                    .Update()
                End If
            End With
            oPerson.Dispose()
            oPerson = Nothing
        End Sub

        Private Sub _updateUserProfile(ByVal isAddAll As Boolean)
            Dim oPr As New Common.BussinessRules.UserProfile
            With oPr
                For Each item As DataGridItem In grdProfile.Items
                    Dim chkSelect As CheckBox = CType(item.FindControl("chkSelect"), CheckBox)
                    Dim lblProfileID As Label = CType(item.FindControl("_lblProfileID"), Label)
                    .UserID = txtUserID.Text.Trim
                    .ProfileID = lblProfileID.Text.Trim
                    .IsDefault = False
                    .UserIDInsert = MyBase.LoggedOnUserID
                    .UserIDUpdate = MyBase.LoggedOnUserID
                    If isAddAll Then
                        .Insert()
                    Else
                        If chkSelect.Checked Then .Insert()
                    End If
                Next
            End With
            oPr.Dispose()
            oPr = Nothing

            SetDataGridUserProfile()
        End Sub

        Private Sub _updateUserProject(ByVal isAddAll As Boolean)
            Dim oPr As New Common.BussinessRules.ProjectUser
            With oPr
                For Each item As DataGridItem In grdProject.Items
                    Dim chkSelect As CheckBox = CType(item.FindControl("chkSelect"), CheckBox)
                    Dim lblProjectID As Label = CType(item.FindControl("_lblProjectID"), Label)
                    .UserID = txtUserID.Text.Trim
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

            SetDataGridUserProject()
        End Sub

#End Region

    End Class

End Namespace