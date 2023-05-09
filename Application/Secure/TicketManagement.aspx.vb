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

Namespace QIS.Web
    Public Class TicketManagement
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
                _openUserProfile()
                prepareDDL()
                PrepareScreen()
                PrepareScreenForCustomer()
                SetDataGrid(ddlProjectFilter.SelectedValue.Trim)
            End If
        End Sub

        Private Sub ddlProjectFilter_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlProjectFilter.SelectedIndexChanged
            PrepareScreen()
            PrepareScreenForCustomer()
            SetDataGrid(ddlProjectFilter.SelectedValue.Trim)
        End Sub

        Private Sub btnClose_Click(sender As Object, e As System.EventArgs) Handles btnClose.Click
            PrepareScreenAddNew()
            pnlAddNew.Visible = False

            PrepareScreenIssueResponse()
            pnlIssueResponse.Visible = False
        End Sub

        Private Sub btnSaveOnly_Click(sender As Object, e As System.EventArgs) Handles btnSaveOnly.Click
            _updateIssue()
            SetDataGrid(ddlProjectFilter.SelectedValue.Trim)

            PrepareScreenIssueFile()
            SetDataGridIssueFile()
        End Sub

        Private Sub btnSaveAndNew_Click(sender As Object, e As System.EventArgs) Handles btnSaveAndNew.Click
            _updateIssue()
            PrepareScreenAddNew()
            SetDataGrid(ddlProjectFilter.SelectedValue.Trim)

            PrepareScreenIssueFile()
            SetDataGridIssueFile()
        End Sub

        Private Sub btnSaveAndClose_Click(sender As Object, e As System.EventArgs) Handles btnSaveAndClose.Click
            _updateIssue()
            PrepareScreenAddNew()

            PrepareScreenIssueFile()
            SetDataGridIssueFile()

            pnlAddNew.Visible = False
            SetDataGrid(ddlProjectFilter.SelectedValue.Trim)
        End Sub

        Private Sub btnAddResponse_Click(sender As Object, e As System.EventArgs) Handles btnAddResponse.Click
            pnlIssueResponse.Visible = True
            Response_lblIssueID.Text = lblIssueID.Text.Trim
            _openIssueForResponse()
            PrepareScreenIssueResponse()
            SetDataGridIssueResponse()
        End Sub

        Private Sub btnIssueFileAttach_Click(sender As Object, e As System.EventArgs) Handles btnIssueFileAttach.Click
            AttachIssueFile()
        End Sub

        Private Sub btnIssueFileUpdate_Click(sender As Object, e As System.EventArgs) Handles btnIssueFileUpdate.Click
            _updateFile(txtIssueFileID.Text.Trim, txtIssueFileDescription.Text.Trim)
            PrepareScreenIssueFile()
            SetDataGridIssueFile()
        End Sub

        Private Sub Response_btnClose_Click(sender As Object, e As System.EventArgs) Handles Response_btnClose.Click
            PrepareScreenIssueResponse()
            pnlIssueResponse.Visible = False
        End Sub

        Private Sub Response_btnSaveAndNew_Click(sender As Object, e As System.EventArgs) Handles Response_btnSaveAndNew.Click
            _updateIssueResponse()
            PrepareScreenIssueResponse()
            SetDataGridIssueResponse()
            SetDataGrid(ddlProjectFilter.SelectedValue.Trim)
        End Sub

        Private Sub Response_btnSaveAndClose_Click(sender As Object, e As System.EventArgs) Handles Response_btnSaveAndClose.Click
            _updateIssueResponse()
            PrepareScreenIssueResponse()
            pnlIssueResponse.Visible = False
            SetDataGridIssueResponse()
            SetDataGrid(ddlProjectFilter.SelectedValue.Trim)
        End Sub

        Private Sub grdIssue_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdIssueOpen.ItemCommand, grdIssueCRFQuotation.ItemCommand, _
                grdIssueInProgress.ItemCommand, grdIssueDevFinish.ItemCommand
            Select Case e.CommandName
                Case "EditIssue"
                    Dim _lbtnIssueID As LinkButton = CType(e.Item.FindControl("_lbtnIssueID"), LinkButton)
                    pnlAddNew.Visible = True
                    lblIssueID.Text = _lbtnIssueID.Text.Trim
                    _openIssue()
                    PrepareScreenIssueFile()
                    SetDataGridIssueFile()

                    pnlIssueResponse.Visible = False
                    Response_lblIssueID.Text = _lbtnIssueID.Text.Trim
                    _openIssueForResponse()
                    PrepareScreenIssueResponse()
                    SetDataGridIssueResponse()
                    PrepareScreenForCustomer()

                Case "EditResponse"
                    Dim _lbtnIssueID As LinkButton = CType(e.Item.FindControl("_lbtnIssueID"), LinkButton)
                    pnlIssueResponse.Visible = True
                    Response_lblIssueID.Text = _lbtnIssueID.Text.Trim
                    _openIssueForResponse()
                    PrepareScreenIssueResponse()
                    SetDataGridIssueResponse()
                    PrepareScreenForCustomer()
            End Select
        End Sub

        Protected Sub repIssueFile_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs)
            Select Case e.CommandName
                Case "EditFile"
                    Dim _lblFileID As Label = CType(e.Item.FindControl("_lblFileID"), Label)
                    txtIssueFileID.Text = _lblFileID.Text.Trim
                    _openFile(txtIssueFileID, txtIssueFileName, txtIssueFileDescription, btnIssueFileUpdate)

                Case "DeleteFile"
                    Dim _lblFileID As Label = CType(e.Item.FindControl("_lblFileID"), Label)
                    Dim _lblReferenceID As Label = CType(e.Item.FindControl("_lblReferenceID"), Label)
                    Dim _lblFileName As Label = CType(e.Item.FindControl("_lblFileName"), Label)
                    Dim strFileDir As String = String.Empty
                    Dim oCC As New Common.BussinessRules.CommonCode
                    oCC.GroupCode = Common.Constants.GroupCode.FileDirectory_SCode
                    oCC.Code = Common.Constants.FileDirectoryType.FileDirectory_Issue

                    If oCC.SelectOne.Rows.Count > 0 Then
                        strFileDir = oCC.Value.Trim + Common.Constants.TableName.IssueTable.Trim + "_" + _lblReferenceID.Text.Trim + "\" + _lblFileName.Text.Trim
                    Else
                        oCC.Dispose()
                        oCC = Nothing
                        commonFunction.MsgBox(Me, Common.Constants.MessageBoxText.Validate_CommonCodeNotFound)
                        Exit Sub
                    End If
                    oCC.Dispose()
                    oCC = Nothing

                    _deleteFile(_lblFileID.Text.Trim, strFileDir.Trim)
                    SetDataGridIssueFile()
            End Select
        End Sub
#End Region

#Region " Support functions for navigation bar (Controls) "

#End Region

#Region " Private Functions "
        Private Function ReadQueryString() As Boolean

        End Function

        Private Sub SetDataGrid(ByVal strProjectID As String)
            If strProjectID.Trim = String.Empty Then strProjectID = "All"
            Dim decTotalIssue As Decimal = 0D
            Dim oBR As New Common.BussinessRules.Issue
            Dim oIssueOpen As New DataTable
            oIssueOpen = oBR.SelectByFilter("All", strProjectID, "All", "All", "All", Common.Constants.IssueStatusCode.IssueStatus_Open, "All", False, False, Date.Today, Date.Today, True)
            grdIssueOpen.DataSource = oIssueOpen
            grdIssueOpen.DataBind()
            lblTotalOpen.Text = grdIssueOpen.Items.Count.ToString

            Dim oIssueCRFQuotation As New DataTable
            oIssueCRFQuotation = oBR.SelectByFilter("All", strProjectID, "All", "All", "All", Common.Constants.IssueStatusCode.IssueStatus_CRFQuotation, "All", False, False, Date.Today, Date.Today, True)
            grdIssueCRFQuotation.DataSource = oIssueCRFQuotation
            grdIssueCRFQuotation.DataBind()
            lblTotalCRFQuotation.Text = grdIssueCRFQuotation.Items.Count.ToString

            Dim oIssueInProgress As New DataTable
            oIssueInProgress = oBR.SelectByFilter("All", strProjectID, "All", "All", "All", Common.Constants.IssueStatusCode.IssueStatus_InProgress, "All", False, False, Date.Today, Date.Today, True)
            grdIssueInProgress.DataSource = oIssueInProgress
            grdIssueInProgress.DataBind()
            lblTotalInProgress.Text = grdIssueInProgress.Items.Count.ToString

            Dim oIssueDevFinish As New DataTable
            oIssueDevFinish = oBR.SelectByFilter("All", strProjectID, "All", "All", "All", Common.Constants.IssueStatusCode.IssueStatus_DevFinish, "All", False, False, Date.Today, Date.Today, True)
            grdIssueDevFinish.DataSource = oIssueDevFinish
            grdIssueDevFinish.DataBind()
            lblTotalDevFinish.Text = grdIssueDevFinish.Items.Count.ToString

            decTotalIssue = oIssueOpen.Rows.Count

            oBR.Dispose()
            oBR = Nothing

            oIssueOpen.Dispose()
            oIssueCRFQuotation.Dispose()
            oIssueInProgress.Dispose()
            oIssueDevFinish.Dispose()
        End Sub

        Private Sub SetDataGridIssueResponse()
            Dim oBR As New Common.BussinessRules.IssueResponse
            oBR.IssueID = Response_lblIssueID.Text.Trim
            grdIssueResponse.DataSource = oBR.SelectByIssueID
            grdIssueResponse.DataBind()
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub prepareDDL()
            If chkIsCustomerProfile.Checked = True Then
                commonFunction.SetDDL_Table(ddlProjectFilter, "ProjectUserOpenForCustomer", MyBase.LoggedOnUserID.Trim, False)
            Else
                commonFunction.SetDDL_Table(ddlProjectFilter, "ProjectCRMActive", String.Empty, True, "All")
            End If
            commonFunction.SetDDL_Table(ddlProductRoadmap, "CommonCode", Common.Constants.GroupCode.ProductRoadmap_SCode, True, "Not Set")
            commonFunction.SetDDL_Table(ddlIssueType, "CommonCode", Common.Constants.GroupCode.IssueType_SCode, False)
            commonFunction.SetDDL_Table(ddlIssueStatus, "CommonCode", Common.Constants.GroupCode.IssueStatus_SCode, False)
            commonFunction.SetDDL_Table(ddlIssuePriority, "CommonCode", Common.Constants.GroupCode.IssuePriority_SCode, False)
            commonFunction.SetDDL_Table(ddlIssueConfirmStatus, "CommonCode", Common.Constants.GroupCode.IssueConfirmStatus_SCode, False)
            commonFunction.SetDDL_Table(Response_ddlResponseType, "CommonCode", Common.Constants.GroupCode.ResponseType_SCode, False)
            commonFunction.SetDDL_Table(ddlUserIDAssignedTo, "UserActive", String.Empty, True, "Not Set")
        End Sub

        Private Sub PrepareScreen()
            pnlAddNew.Visible = False
            pnlIssueResponse.Visible = False
        End Sub

        Private Sub PrepareScreenAddNew()
            lblProjectID.Text = String.Empty
            lblIssueID.Text = String.Empty
            txtDepartmentName.Text = String.Empty
            txtIssueDescription.Text = String.Empty
            txtUserFriendlyIssueDescription.Text = String.Empty
            txtKeywords.Text = String.Empty
            calReportedDate.selectedDate = Date.Today
            txtReportedBy.Text = String.Empty
            ddlIssueType.SelectedIndex = 0
            ddlIssueStatus.SelectedIndex = 0
            ddlIssuePriority.SelectedIndex = 0
            ddlIssueConfirmStatus.SelectedIndex = 0
            ddlUserIDAssignedTo.Items.Clear()
            commonFunction.SetDDL_Table(ddlUserIDAssignedTo, "UserActive", String.Empty, True, "Not Set")
            ddlUserIDAssignedTo.SelectedIndex = 0
            calEstStartDate.selectedDate = Date.Today
            calTargetDate.selectedDate = Date.Today
            chkIsUrgent.Checked = False
            chkIsPlanned.Checked = False
            ddlProductRoadmap.SelectedIndex = 0

            txtPatchNo.Text = String.Empty
            chkIsSpecific.Checked = False

            btnAddResponse.Enabled = False
            commonFunction.Focus(Me, txtDepartmentName.ClientID)
        End Sub

        Private Sub PrepareScreenIssueResponse()
            Response_lblResponseID.Text = String.Empty
            Response_calResponseDate.selectedDate = Date.Today
            Response_txtResponseTimeStart.Text = Format(Date.Now, "hh:mm")
            Response_txtResponseDuration.Text = "0"
            Response_txtResponseDescription.Text = String.Empty
            Response_chkIsShared.Checked = False

            commonFunction.Focus(Me, Response_txtResponseTimeStart.ClientID)
        End Sub

        Private Sub PrepareScreenIssueFile()
            txtIssueFileID.Text = String.Empty
            txtIssueFileDescription.Text = String.Empty
            txtIssueFileName.Text = String.Empty
            txtIssueFileName.Enabled = True
            btnIssueFileAttach.Enabled = True
            btnIssueFileUpdate.Enabled = False
        End Sub

        Private Sub PrepareScreenForCustomer()
            If chkIsCustomerProfile.Checked = True Then
                btnSaveOnly.Enabled = False
                btnSaveAndNew.Enabled = False
                btnSaveAndClose.Enabled = False
                btnIssueFileAttach.Enabled = False
                btnIssueFileUpdate.Enabled = False
            Else
                btnSaveOnly.Enabled = True
                btnSaveAndNew.Enabled = True
                btnSaveAndClose.Enabled = True
                btnIssueFileAttach.Enabled = True
                btnIssueFileUpdate.Enabled = True
            End If
        End Sub

        Private Sub SetDataGridIssueFile()
            Dim br As New Common.BussinessRules.File
            Dim dt As New DataTable
            With br
                .referenceID = lblIssueID.Text.Trim
                .tableName = Common.Constants.TableName.IssueTable.Trim
                dt = .GetFileByReferenceID()
            End With

            repIssueFile.DataSource = dt.DefaultView
            repIssueFile.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub AttachIssueFile()
            If lblIssueID.Text.Trim.Length = 0 Then Exit Sub

            If txtIssueFileUrl.Value.Trim.Length > 0 Then
                Dim fileExt As String, fileName As String, dirName As String
                Dim oCC As New Common.BussinessRules.CommonCode
                Dim br As New Common.BussinessRules.File
                With br
                    fileExt = Path.GetExtension(txtIssueFileUrl.Value.Trim)
                    fileName = IIf(txtIssueFileName.Text.Trim.Length > 0, txtIssueFileName.Text.Trim + fileExt.Trim, Path.GetFileName(txtIssueFileUrl.Value.Trim)).ToString.Trim
                    .fileID = txtIssueFileID.Text.Trim
                    Dim fNotNew As Boolean = False, fAllowSave As Boolean = False
                    Dim nmFile As String
                    Try
                        If .SelectOne.Rows.Count > 0 Then
                            fNotNew = True
                        Else
                            fNotNew = False
                        End If
                        .fileID = txtIssueFileID.Text.Trim
                        .referenceID = lblIssueID.Text.Trim
                        .tableName = Common.Constants.TableName.IssueTable
                        .fileName = fileName.Trim
                        .fileExtension = fileExt.Trim
                        .fileDescription = txtIssueFileDescription.Text.Trim
                        .UserIDInsert = MyBase.LoggedOnUserID.Trim
                        .UserIDUpdate = MyBase.LoggedOnUserID.Trim

                        oCC.GroupCode = Common.Constants.GroupCode.FileDirectory_SCode
                        oCC.Code = Common.Constants.FileDirectoryType.FileDirectory_Issue

                        '// validate if the file exist
                        If oCC.SelectOne.Rows.Count > 0 Then
                            dirName = oCC.Value.Trim + Common.Constants.TableName.IssueTable.Trim + "_" + lblIssueID.Text.Trim
                            nmFile = dirName + "\" + fileName
                        Else
                            oCC.Dispose()
                            oCC = Nothing
                            fAllowSave = False
                            commonFunction.MsgBox(Me, Common.Constants.MessageBoxText.Validate_CommonCodeNotFound)
                            Exit Sub
                        End If
                        oCC.Dispose()
                        oCC = Nothing

                        If txtIssueFileUrl.Value.Trim.Length > 0 Then
                            If File.Exists(nmFile) Then
                                fAllowSave = False
                                commonFunction.MsgBox(Me, Common.Constants.MessageBoxText.Validate_FileNameAlreadyExist)
                                Exit Sub
                            Else
                                fAllowSave = True
                                If Not Directory.Exists(dirName) Then
                                    Directory.CreateDirectory(dirName)
                                End If
                                txtIssueFileUrl.PostedFile.SaveAs(nmFile)
                            End If

                            If fAllowSave Then
                                If fNotNew Then
                                    If .Update() Then
                                        PrepareScreenIssueFile()
                                        SetDataGridIssueFile()
                                        SetDataGrid(ddlProjectFilter.SelectedValue.Trim)
                                    End If
                                Else
                                    If .Insert() Then
                                        PrepareScreenIssueFile()
                                        SetDataGridIssueFile()
                                        SetDataGrid(ddlProjectFilter.SelectedValue.Trim)
                                    End If
                                End If
                            End If
                        End If
                    Catch ex As Exception
                        commonFunction.MsgBox(Me, "Upload file failed.")
                        Exit Sub
                    End Try
                End With
            Else
                commonFunction.MsgBox(Me, "No file choosen.")
                Exit Sub
            End If
        End Sub

#End Region

#Region " C,R,U,D "
        Private Sub _openUserProfile()
            Dim oBR As New Common.BussinessRules.Profile
            With oBR
                .ProfileID = MyBase.LoggedOnProfileID.Trim
                If .SelectOne.Rows.Count > 0 Then
                    chkIsCustomerProfile.Checked = .IsCustomerProfile
                Else
                    chkIsCustomerProfile.Checked = False
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub _openProject()
            'Dim oBR As New Common.BussinessRules.Project
            'With oBR
            '    .ProjectID = ddlProjectFilter.SelectedValue.Trim
            '    If .SelectOne.Rows.Count > 0 Then
            '        lblLastPatchNo.Text = .lastPatchNo.Trim
            '        chkIsOpenForClient.Checked = .IsOpenForClient
            '    Else
            '        lblLastPatchNo.Text = "-"
            '        chkIsOpenForClient.Checked = False
            '    End If
            'End With
            'oBR.Dispose()
            'oBR = Nothing

            'setToolbarVisibleButton()
        End Sub

        Private Sub _openIssue()
            Dim oBR As New Common.BussinessRules.Issue
            With oBR
                .IssueID = lblIssueID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    lblProjectID.Text = .ProjectID.Trim
                    txtDepartmentName.Text = .DepartmentName.Trim
                    txtIssueDescription.Text = .IssueDescription.Trim
                    txtUserFriendlyIssueDescription.Text = .UserFriendlyIssueDescription.Trim
                    txtKeywords.Text = .Keywords.Trim
                    calReportedDate.selectedDate = .ReportedDate
                    txtReportedBy.Text = .ReportedBy.Trim
                    ddlProductRoadmap.SelectedValue = .ProductRoadmapSCode.Trim
                    ddlIssueType.SelectedValue = .IssueTypeSCode.Trim
                    ddlIssueStatus.SelectedValue = .IssueStatusSCode.Trim
                    ddlIssuePriority.SelectedValue = .IssuePrioritySCode.Trim
                    ddlIssueConfirmStatus.SelectedValue = .IssueConfirmStatusSCode.Trim
                    ddlUserIDAssignedTo.Items.Clear()
                    commonFunction.SetDDL_Table(ddlUserIDAssignedTo, "User", String.Empty, True, "Not Set")
                    If .userIDassignedTo.Trim = String.Empty Then
                        ddlUserIDAssignedTo.SelectedIndex = 0
                    Else
                        ddlUserIDAssignedTo.SelectedValue = .userIDassignedTo.Trim
                    End If
                    calEstStartDate.selectedDate = .estStartDate
                    calTargetDate.selectedDate = .targetDate
                    chkIsPlanned.Checked = .isPlanned
                    chkIsUrgent.Checked = .isUrgent
                    chkIsPlanned.Checked = .isPlanned
                    txtPatchNo.Text = .PatchNo.Trim
                    chkIsSpecific.Checked = .isSpecific
                    btnAddResponse.Enabled = True

                    pnlIssueResponse.Visible = False
                    PrepareScreenIssueResponse()
                    SetDataGridIssueResponse()
                Else
                    btnAddResponse.Enabled = False
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub _openIssueForResponse()
            'Dim oBR As New Common.BussinessRules.Issue
            'With oBR
            '    .IssueID = Response_lblIssueID.Text.Trim
            '    If .SelectOne.Rows.Count > 0 Then
            '        Response_lblDepartmentName.Text = .DepartmentName.Trim
            '        Response_lblIssueDescription.Text = .IssueDescription.Trim
            '    Else
            '        Response_lblDepartmentName.Text = String.Empty
            '        Response_lblIssueDescription.Text = String.Empty
            '    End If
            'End With
            'oBR.Dispose()
            'oBR = Nothing
        End Sub

        Private Sub _updateIssue()
            Page.Validate()
            If Not Page.IsValid Then Exit Sub

            Dim fNew As Boolean = False
            Dim oBR As New Common.BussinessRules.Issue
            With oBR
                .IssueID = lblIssueID.Text.Trim
                fNew = .SelectOne.Rows.Count = 0
                .assignedBy = MyBase.LoggedOnUserID.Trim
                If fNew = False Then
                    If .userIDassignedTo.Trim = String.Empty Then
                        .UpdateAssigned()
                    ElseIf .userIDassignedTo.Trim <> ddlUserIDAssignedTo.SelectedValue.Trim Then
                        .UpdateAssigned()
                    End If
                End If
                .ProjectID = lblProjectID.Text.Trim
                .ProductRoadmapSCode = ddlProductRoadmap.SelectedValue.Trim
                .DepartmentName = txtDepartmentName.Text.Trim
                .IssueDescription = txtIssueDescription.Text.Trim
                .UserFriendlyIssueDescription = txtUserFriendlyIssueDescription.Text.Trim
                .Keywords = txtKeywords.Text.Trim
                .ReportedDate = calReportedDate.selectedDate
                .ReportedBy = txtReportedBy.Text.Trim
                .IssueTypeSCode = ddlIssueType.SelectedValue.Trim
                .IssueStatusSCode = ddlIssueStatus.SelectedValue.Trim
                .IssuePrioritySCode = ddlIssuePriority.SelectedValue.Trim
                .IssueConfirmStatusSCode = ddlIssueConfirmStatus.SelectedValue.Trim
                .userIDassignedTo = ddlUserIDAssignedTo.SelectedValue.Trim
                .estStartDate = calEstStartDate.selectedDate
                .targetDate = calTargetDate.selectedDate
                .isUrgent = chkIsUrgent.Checked
                .isPlanned = chkIsPlanned.Checked
                .PatchNo = txtPatchNo.Text.Trim
                .isSpecific = chkIsSpecific.Checked
                .isFromCustomer = False

                .userIDinsert = MyBase.LoggedOnUserID.Trim
                .userIDupdate = MyBase.LoggedOnUserID.Trim
                If fNew Then
                    If .Insert() Then
                        lblIssueID.Text = .IssueID.Trim
                        btnAddResponse.Enabled = True
                    End If
                Else
                    If .Update() Then
                        btnAddResponse.Enabled = True
                    End If
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub _updateIssueResponse()
            Page.Validate()
            If Not Page.IsValid Then Exit Sub

            Dim fNew As Boolean = False
            Dim oBR As New Common.BussinessRules.IssueResponse
            With oBR
                .ResponseID = Response_lblResponseID.Text.Trim
                fNew = .SelectOne.Rows.Count = 0
                .IssueID = Response_lblIssueID.Text.Trim
                .ResponseDescription = Response_txtResponseDescription.Text.Trim
                .ResponseDate = Response_calResponseDate.selectedDate
                .ResponseTimeStart = Response_txtResponseTimeStart.Text.Trim
                .ResponseDuration = CInt(IIf(IsNumeric(Response_txtResponseDuration.Text.Trim), Response_txtResponseDuration.Text.Trim, 0).ToString.Trim)
                .ResponseTypeSCode = Response_ddlResponseType.SelectedItem.Value.Trim
                .isShared = Response_chkIsShared.Checked
                .userIDinsert = MyBase.LoggedOnUserID.Trim
                .userIDupdate = MyBase.LoggedOnUserID.Trim
                If fNew Then
                    If .Insert() Then
                        Response_lblResponseID.Text = .ResponseID.Trim
                    End If
                Else
                    .Update()
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub _openFile(ByVal txtFileID As TextBox, ByVal txtFileName As TextBox, ByVal txtFileDescription As TextBox, ByVal btnUpdateFile As Button)
            Dim oFile As New Common.BussinessRules.File
            With oFile
                .fileID = txtFileID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    txtFileName.Text = .fileName.Trim
                    txtFileDescription.Text = .fileDescription.Trim
                    txtFileName.Enabled = False
                    btnIssueFileAttach.Enabled = False
                    btnUpdateFile.Enabled = True
                Else
                    txtFileID.Text = String.Empty
                    txtFileName.Text = String.Empty
                    txtFileDescription.Text = String.Empty
                    txtFileName.Enabled = True
                    btnIssueFileAttach.Enabled = True
                    btnUpdateFile.Enabled = False
                End If
            End With
            oFile.Dispose()
            oFile = Nothing
        End Sub

        Private Sub _updateFile(ByVal strFileID As String, ByVal strFileDescription As String)
            Dim oFile As New Common.BussinessRules.File
            With oFile
                .fileID = strFileID.Trim
                If .SelectOne.Rows.Count > 0 Then
                    .fileDescription = strFileDescription.Trim
                    .UserIDUpdate = MyBase.LoggedOnUserID.Trim
                    .Update()
                End If
            End With
            oFile.Dispose()
            oFile = Nothing
        End Sub

        Private Sub _deleteFile(ByVal strFileID As String, ByVal strFileDir As String)
            Dim oFile As New Common.BussinessRules.File
            With oFile
                .fileID = strFileID.Trim
                If .Delete() Then
                    File.Delete(strFileDir)
                    SetDataGrid(ddlProjectFilter.SelectedValue.Trim)
                End If
            End With
            oFile.Dispose()
            oFile = Nothing
        End Sub
#End Region

    End Class

End Namespace