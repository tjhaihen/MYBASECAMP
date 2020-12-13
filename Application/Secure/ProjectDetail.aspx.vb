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
    Public Class ProjectDetail
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
            commonFunction.TimeFormat(Response_txtResponseTimeStart)
            If Not Me.IsPostBack Then
                setToolbarVisibleButton()
                prepareDDL()
                PrepareScreen()

                If ReadQueryString() Then
                    _openProject()
                    SetDataGrid()
                End If

                GetTasksByUserID()
            End If
        End Sub

        Private Sub lbtnMyProjects_Click(sender As Object, e As System.EventArgs) Handles lbtnMyProjects.Click, ibtnMyProjects.Click
            Response.Write("<script language=javascript>window.location.replace('" + PageBase.UrlBase + "/secure/Main.aspx" + "')</script>")
        End Sub

        Private Sub lbtnMyDay_Click(sender As Object, e As System.EventArgs) Handles lbtnMyDay.Click, lbtnMyDay.Click
            Response.Write("<script language=javascript>window.location.replace('" + PageBase.UrlBase + "/secure/Myday.aspx')</script>")
        End Sub

        Private Sub lbtnPlanned_Click(sender As Object, e As System.EventArgs) Handles lbtnPlanned.Click, lbtnPlanned.Click
            Response.Write("<script language=javascript>window.location.replace('" + PageBase.UrlBase + "/secure/Planned.aspx')</script>")
        End Sub

        Private Sub lbtnUrgents_Click(sender As Object, e As System.EventArgs) Handles lbtnUrgents.Click, ibtnUrgents.Click
            Response.Write("<script language=javascript>window.location.replace('" + PageBase.UrlBase + "/secure/Urgent.aspx')</script>")
        End Sub

        Private Sub lbtnMyAssignments_Click(sender As Object, e As System.EventArgs) Handles lbtnMyAssignments.Click, ibtnMyAssignments.Click
            Response.Write("<script language=javascript>window.location.replace('" + PageBase.UrlBase + "/secure/Main.aspx?isassignment=True" + "')</script>")
        End Sub

        Private Sub lbtnFollowUpIssue_Click(sender As Object, e As System.EventArgs) Handles lbtnFollowUpIssue.Click, ibtnFollowUpIssue.Click
            Response.Write("<script language=javascript>window.location.replace('" + PageBase.UrlBase + "/secure/FollowUpIssue.aspx')</script>")
        End Sub

        Private Sub lbtnIssueStudy_Click(sender As Object, e As System.EventArgs) Handles lbtnIssueStudy.Click, ibtnIssueStudy.Click
            Response.Write("<script language=javascript>window.location.replace('" + PageBase.UrlBase + "/secure/IssueStudy.aspx')</script>")
        End Sub

        Private Sub txtPatchNo_TextChanged(sender As Object, e As System.EventArgs) Handles txtPatchNo.TextChanged
            txtPatchNo.Text = _openValidatePatch(txtPatchNo.Text.Trim, txtPatchNo)
        End Sub

        Private Sub Response_txtPatchNo_TextChanged(sender As Object, e As System.EventArgs) Handles Response_txtPatchNo.TextChanged
            Response_txtPatchNo.Text = _openValidatePatch(Response_txtPatchNo.Text.Trim, Response_txtPatchNo)
        End Sub

        Private Sub btnUploadIssue_Click(sender As Object, e As System.EventArgs) Handles btnUploadIssue.Click
            Dim oBR As New Common.BussinessRules.Issue
            Dim MyConnection As System.Data.OleDb.OleDbConnection

            If Len(Upload_txtSheetName.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Sheet Name cannot empty.")
                Exit Sub
            End If

            Dim strFileFolder As String = Common.Methods.GetCommonCode("ISSUEUPLDIR", "FILEDIR").Trim
            Dim strFileName As String = Path.GetFileName(Upload_File.Value.Trim).Trim
            Dim strFilePath As String = String.Empty

            strFilePath = strFileFolder + strFileName

            If (Not File.Exists(strFilePath)) Then
                commonFunction.MsgBox(Me, "Upload Failed. File " + strFileName.Trim + " doesn't exist.")
                Exit Sub
            End If

            Dim fs As New FileStream(strFilePath, FileMode.OpenOrCreate, FileAccess.Read)
            Dim b(CInt(fs.Length)) As Byte
            fs.Read(b, 0, CInt(fs.Length))
            fs.Close()

            Try
                '// Fetch Data from Excel
                Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
                Dim DtSet As System.Data.DataSet

                'MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & strFilePath & " '; " & "Extended Properties=Excel 12.0;")
                MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; data source='" & strFilePath & " '; " & "Extended Properties=Excel 8.0;")
                MyCommand = New System.Data.OleDb.OleDbDataAdapter("SELECT * FROM [" + Upload_txtSheetName.Text.Trim + "$]", MyConnection)

                DtSet = New System.Data.DataSet

                MyCommand.Fill(DtSet, "[" + Upload_txtSheetName.Text.Trim + "$]")

                '// -------------------------------------------------------------------------------
                Dim iRecCount As Integer = 0
                While DtSet.Tables(0).Rows.Count > iRecCount
                    With oBR
                        .ProjectID = lblProjectID.Text.Trim
                        If (DtSet.Tables(0).Rows(iRecCount)(1)) Is System.DBNull.Value Then
                            .DepartmentName = String.Empty
                        Else
                            .DepartmentName = CType(DtSet.Tables(0).Rows(iRecCount)(1), String)
                        End If

                        If (DtSet.Tables(0).Rows(iRecCount)(2)) Is System.DBNull.Value Then
                            .IssueDescription = String.Empty
                        Else
                            .IssueDescription = CType(DtSet.Tables(0).Rows(iRecCount)(2), String)
                        End If

                        If (DtSet.Tables(0).Rows(iRecCount)(3)) Is System.DBNull.Value Then
                            Throw New Exception("[Reported_Date] column value for Issue Description: " + .IssueDescription.Trim + " is NULL. Please check your worksheet.")
                        Else
                            Dim strDate As String
                            strDate = CType(DtSet.Tables(0).Rows(iRecCount)(3), String)

                            Try
                                If IsDate(strDate.Trim) Then
                                    .ReportedDate = CDate(strDate.Trim)
                                Else
                                    .ReportedDate = DateSerial(Convert.ToInt32(strDate.Substring(6, 4)), Convert.ToInt32(strDate.Substring(3, 2)), Convert.ToInt32(strDate.Substring(0, 2)))
                                End If
                            Catch
                                Throw New Exception("[Reported_Date] column value for Issue Description: " + .IssueDescription.Trim + " required a [Date] format.")
                            End Try
                        End If

                        If (DtSet.Tables(0).Rows(iRecCount)(5)) Is System.DBNull.Value Then
                            .IssueTypeSCode = String.Empty
                        Else
                            Dim strText As String = CType(DtSet.Tables(0).Rows(iRecCount)(5), String).Trim
                            Select Case strText.Trim
                                Case "Open"
                                    .IssueTypeSCode = Common.Constants.IssueTypeCode.IssueType_Open
                                Case "Bugs"
                                    .IssueTypeSCode = Common.Constants.IssueTypeCode.IssueType_Bugs
                                Case "Data Setting"
                                    .IssueTypeSCode = Common.Constants.IssueTypeCode.IssueType_DataSetting
                                Case "Guidance"
                                    .IssueTypeSCode = Common.Constants.IssueTypeCode.IssueType_Guidance
                                Case "Modifcation"
                                    .IssueTypeSCode = Common.Constants.IssueTypeCode.IssueType_Modification
                                Case Else '// Request
                                    .IssueTypeSCode = Common.Constants.IssueTypeCode.IssueType_Request
                            End Select
                        End If

                        If (DtSet.Tables(0).Rows(iRecCount)(6)) Is System.DBNull.Value Then
                            .IssueStatusSCode = String.Empty
                        Else
                            Dim strText As String = CType(DtSet.Tables(0).Rows(iRecCount)(6), String).Trim
                            Select Case strText.Trim
                                Case "Open"
                                    .IssueStatusSCode = Common.Constants.IssueStatusCode.IssueStatus_Open
                                Case "In Progress"
                                    .IssueStatusSCode = Common.Constants.IssueStatusCode.IssueStatus_InProgress
                                Case "Finish"
                                    .IssueStatusSCode = Common.Constants.IssueStatusCode.IssueStatus_Finish
                                Case Else '// Need Sample
                                    .IssueStatusSCode = Common.Constants.IssueStatusCode.IssueStatus_NeedSample
                            End Select
                        End If

                        If (DtSet.Tables(0).Rows(iRecCount)(7)) Is System.DBNull.Value Then
                            .ReportedBy = String.Empty
                        Else
                            .ReportedBy = CType(DtSet.Tables(0).Rows(iRecCount)(7), String)
                        End If

                        If (DtSet.Tables(0).Rows(iRecCount)(10)) Is System.DBNull.Value Then
                            .IssuePrioritySCode = String.Empty
                        Else
                            Dim strText As String = CType(DtSet.Tables(0).Rows(iRecCount)(10), String).Trim
                            Select Case strText.Trim
                                Case "Low"
                                    .IssuePrioritySCode = Common.Constants.IssuePriorityCode.IssuePriority_Low
                                Case "Medium"
                                    .IssuePrioritySCode = Common.Constants.IssuePriorityCode.IssuePriority_Medium
                                Case Else '// High
                                    .IssuePrioritySCode = Common.Constants.IssuePriorityCode.IssuePriority_High
                            End Select
                        End If

                        If (DtSet.Tables(0).Rows(iRecCount)(11)) Is System.DBNull.Value Then
                            .IssueConfirmStatusSCode = String.Empty
                        Else
                            Dim strText As String = CType(DtSet.Tables(0).Rows(iRecCount)(11), String).Trim
                            Select Case strText.Trim
                                Case "Open"
                                    .IssueConfirmStatusSCode = Common.Constants.IssueConfirmStatsusCode.IssueConfirmStatus_Open
                                Case "In Discussion"
                                    .IssueConfirmStatusSCode = Common.Constants.IssueConfirmStatsusCode.IssueConfirmStatus_InDiscussion
                                Case Else '// Confirmed
                                    .IssueConfirmStatusSCode = Common.Constants.IssueConfirmStatsusCode.IssueConfirmStatus_Confirmed
                            End Select
                        End If

                        .userIDassignedTo = String.Empty
                        .userIDinsert = MyBase.LoggedOnUserID
                        .userIDupdate = MyBase.LoggedOnUserID
                        .assignedBy = String.Empty

                        .Insert()
                        iRecCount = iRecCount + 1
                    End With
                End While
            Catch ex As Exception
                MyConnection.Close()
                Throw ex
            End Try

            SetDataGrid()
        End Sub

        Private Sub btnClose_Click(sender As Object, e As System.EventArgs) Handles btnClose.Click
            PrepareScreenAddNew()
            pnlAddNew.Visible = False
        End Sub

        Private Sub btnSaveOnly_Click(sender As Object, e As System.EventArgs) Handles btnSaveOnly.Click
            _updateIssue()
            SetDataGrid()
        End Sub

        Private Sub btnSaveAndNew_Click(sender As Object, e As System.EventArgs) Handles btnSaveAndNew.Click
            _updateIssue()
            PrepareScreenAddNew()
            SetDataGrid()
        End Sub

        Private Sub btnSaveAndClose_Click(sender As Object, e As System.EventArgs) Handles btnSaveAndClose.Click
            _updateIssue()
            PrepareScreenAddNew()
            pnlAddNew.Visible = False
            SetDataGrid()
        End Sub

        Private Sub btnIssueFileAttach_Click(sender As Object, e As System.EventArgs) Handles btnIssueFileAttach.Click
            AttachIssueFile()
        End Sub

        Private Sub btnIssueFileUpdate_Click(sender As Object, e As System.EventArgs) Handles btnIssueFileUpdate.Click
            _updateFile(txtIssueFileID.Text.Trim, txtIssueFileDescription.Text.Trim)
            PrepareScreenIssueFile()
            SetDataGridIssueFile()
        End Sub

        Private Sub chkIsOpenOnly_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkIsOpenOnly.CheckedChanged
            SetDataGrid()
        End Sub

        Private Sub Response_btnClose_Click(sender As Object, e As System.EventArgs) Handles Response_btnClose.Click
            PrepareScreenIssueResponse()
            pnlIssueResponse.Visible = False
        End Sub

        Private Sub Response_btnSaveAndNew_Click(sender As Object, e As System.EventArgs) Handles Response_btnSaveAndNew.Click
            _updateIssueResponse()
            PrepareScreenIssueResponse()
            SetDataGridIssueResponse()
            SetDataGrid()
        End Sub

        Private Sub Response_btnSaveAndClose_Click(sender As Object, e As System.EventArgs) Handles Response_btnSaveAndClose.Click
            _updateIssueResponse()
            PrepareScreenIssueResponse()
            pnlIssueResponse.Visible = False
            SetDataGridIssueResponse()
            SetDataGrid()
        End Sub

        Private Sub grdIssueByProject_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdIssueByProject.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    Dim _lbtnIssueID As LinkButton = CType(e.Item.FindControl("_lbtnIssueID"), LinkButton)
                    pnlAddNew.Visible = True
                    pnlIssueResponse.Visible = False
                    PrepareScreenAddNew()
                    lblIssueID.Text = _lbtnIssueID.Text.Trim
                    _openIssue()
                    SetDataGridIssueFile()
                Case "IssueReponse"
                    Dim _lbtnIssueID As LinkButton = CType(e.Item.FindControl("_lbtnIssueID"), LinkButton)
                    pnlIssueResponse.Visible = True
                    pnlAddNew.Visible = False
                    Response_lblIssueID.Text = _lbtnIssueID.Text.Trim
                    _openIssueForResponse()
                    PrepareScreenIssueResponse()
                    SetDataGridIssueResponse()

                    'percobaan print issue ticket form
                Case "PrintTicket"
                    Dim _lbtnIssueID As LinkButton = CType(e.Item.FindControl("_lbtnIssueID"), LinkButton)
                    Dim oRpt As New Common.BussinessRules.MyReport
                    With oRpt
                        '.ReportCode = Common.Constants.ReportID.IssueTicketForm_ReportID
                        .AddParameters(_lbtnIssueID.Text.Trim)
                        '.AddParameters(MyBase.LoggedOnUserID.Trim)
                        '.UrlPrint(Context.Request.Url.Host)
                        'Response.Write(.UrlPrintPreview())
                        Response.Write("<script language=javascript>window.location.replace('" + PageBase.UrlBase + "/secure/PrintTicket.aspx/?&idp=" + _lbtnIssueID.Text.Trim + "')</script>")

                    End With
                    oRpt.Dispose()
                    oRpt = Nothing

            End Select

        End Sub

        Private Sub grdIssueResponse_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdIssueResponse.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    Dim _lblResponseID As Label = CType(e.Item.FindControl("_lblResponseID"), Label)
                    pnlIssueResponse.Visible = True
                    pnlAddNew.Visible = False
                    Response_lblResponseID.Text = _lblResponseID.Text.Trim
                    _openIssueResponse()
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
        Private Sub setToolbarVisibleButton()
            With CSSToolbar
                .VisibleButton(CSSToolbarItem.tidSave) = False
                .VisibleButton(CSSToolbarItem.tidDelete) = False
                .VisibleButton(CSSToolbarItem.tidApprove) = False
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidPrint) = False
                .VisibleButton(CSSToolbarItem.tidPrevious) = False
                .VisibleButton(CSSToolbarItem.tidNext) = False
            End With
        End Sub

        Private Sub mdlToolbar_commandBarClick(ByVal sender As Object, ByVal e As CSSToolbarItem) Handles CSSToolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidNew
                    pnlAddNew.Visible = True
                    pnlIssueResponse.Visible = False
                    PrepareScreenAddNew()
            End Select
        End Sub
#End Region

#Region " Private Functions "
        Private Function ReadQueryString() As Boolean
            lblProjectID.Text = Request.QueryString("projectID")
            If Request.QueryString("isassignment") Is Nothing Then
                chkIsMyAssignment.Checked = False
                lblPageTitle.Text = "Project Detail"
            Else
                Dim strIsAssignment As String = Request.QueryString("isassignment")
                If strIsAssignment = "True" Then
                    chkIsMyAssignment.Checked = True
                    lblPageTitle.Text = "Project Detail - My Assignments"
                Else
                    chkIsMyAssignment.Checked = False
                    lblPageTitle.Text = "Project Detail"
                End If
            End If

            Return lblProjectID.Text.Trim.Length > 0
        End Function

        Private Sub SetDataGrid()
            Dim decTotalIssue As Decimal = 0D
            Dim decTotalOpen As Decimal = 0D
            Dim decTotalDevFinish As Decimal = 0D
            Dim decTotalFinish As Decimal = 0D
            Dim decProgress As Decimal = 0D

            Dim oBR As New Common.BussinessRules.Issue
            oBR.ProjectID = lblProjectID.Text.Trim
            oBR.userIDassignedTo = MyBase.LoggedOnUserID.Trim
            grdIssueByProject.DataSource = oBR.SelectByProjectID(chkIsMyAssignment.Checked, chkIsOpenOnly.Checked)
            grdIssueByProject.DataBind()

            If oBR.SelectSummaryByProjectID(chkIsMyAssignment.Checked).Rows.Count > 0 Then
                decTotalIssue = oBR.totalIssue
                decTotalOpen = oBR.totalOpen
                decTotalDevFinish = oBR.totalDevFinish
                decTotalFinish = oBR.totalFinish

                If decTotalIssue = 0 Then
                    decProgress = 100
                Else
                    decProgress = (decTotalFinish / decTotalIssue) * 100
                End If
            End If
            oBR.Dispose()
            oBR = Nothing

            lblTotalIssue.Text = decTotalIssue.ToString.Trim
            lblTotalOpen.Text = decTotalOpen.ToString.Trim
            lblTotalDevFinish.Text = decTotalDevFinish.ToString.Trim
            lblTotalFinish.Text = decTotalFinish.ToString.Trim
            lblProgress.Text = Format(decProgress, "##0")
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
            commonFunction.SetDDL_Table(ddlProductRoadmap, "CommonCode", Common.Constants.GroupCode.ProductRoadmap_SCode, True, "Not Set")
            commonFunction.SetDDL_Table(ddlIssueType, "CommonCode", Common.Constants.GroupCode.IssueType_SCode, True, "Not Set")
            commonFunction.SetDDL_Table(ddlIssueStatus, "CommonCode", Common.Constants.GroupCode.IssueStatus_SCode, True, "Not Set")
            commonFunction.SetDDL_Table(ddlIssuePriority, "CommonCode", Common.Constants.GroupCode.IssuePriority_SCode, True, "Not Set")
            commonFunction.SetDDL_Table(ddlIssueConfirmStatus, "CommonCode", Common.Constants.GroupCode.IssueConfirmStatus_SCode, True, "Not Set")
            commonFunction.SetDDL_Table(Response_ddlResponseType, "CommonCode", Common.Constants.GroupCode.ResponseType_SCode, False)
            commonFunction.SetDDL_Table(Response_ddlIssueStatus, "CommonCode", Common.Constants.GroupCode.IssueStatus_SCode, True, "Not Set")
            commonFunction.SetDDL_Table(Response_ddlIssueConfirmStatus, "CommonCode", Common.Constants.GroupCode.IssueConfirmStatus_SCode, True, "Not Set")
            commonFunction.SetDDL_Table(ddlUserIDAssignedTo, "UserActive", String.Empty, True, "Not Set")
        End Sub

        Private Sub PrepareScreen()
            pnlAddNew.Visible = False
            pnlIssueResponse.Visible = False
            chkIsOpenOnly.Checked = True
        End Sub

        Private Sub PrepareScreenAddNew()
            lblIssueID.Text = String.Empty
            txtDepartmentName.Text = String.Empty
            txtIssueDescription.Text = String.Empty
            txtKeywords.Text = String.Empty
            calReportedDate.selectedDate = Date.Today
            txtReportedBy.Text = String.Empty
            ddlIssueType.SelectedIndex = 0
            ddlIssueStatus.SelectedIndex = 0
            ddlIssuePriority.SelectedIndex = 0
            ddlIssueConfirmStatus.SelectedIndex = 0
            ddlUserIDAssignedTo.SelectedIndex = 0
            calEstStartDate.selectedDate = Date.Today
            calTargetDate.selectedDate = Date.Today
            chkIsUrgent.Checked = False
            chkIsPlanned.Checked = False
            ddlProductRoadmap.SelectedIndex = 0

            txtPatchNo.Text = String.Empty
            chkIsSpecific.Checked = False

            chkIsIncludeInMyWorktime.Checked = False
            txtWorktimeDtDescription.Text = String.Empty
            txtWorkTimeInHour.Text = "0"
            commonFunction.Focus(Me, txtDepartmentName.ClientID)
        End Sub

        Private Sub PrepareScreenIssueResponse()
            Response_lblResponseID.Text = String.Empty
            Response_calResponseDate.selectedDate = Date.Today
            Response_txtResponseTimeStart.Text = Format(Date.Now, "hh:mm")
            Response_txtResponseDuration.Text = "0"
            Response_txtResponseDescription.Text = String.Empty
            Response_chkIsShared.Checked = False

            Response_chkIsUpdateStatus.Checked = False
            Response_txtPatchNo.Text = String.Empty
            Response_chkIsSpecific.Checked = False

            Response_chkIsIncludeInMyWorktime.Checked = False
            Response_txtWorktimeDtDescription.Text = String.Empty
            Response_txtWorkTimeInHour.Text = "0"
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
                                        SetDataGrid()
                                    End If
                                Else
                                    If .Insert() Then
                                        PrepareScreenIssueFile()
                                        SetDataGridIssueFile()
                                        SetDataGrid()
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

        Private Sub GetTasksByUserID()
            Dim intAssignments As Integer = 0
            Dim oBr As New Common.BussinessRules.Issue
            With oBr
                .userIDassignedTo = MyBase.LoggedOnUserID.Trim
                intAssignments = .SelectIssueOutstandingByUserID(False).Rows.Count
            End With
            oBr.Dispose()
            oBr = Nothing

            lblAssignmentsTotal.Text = intAssignments.ToString.Trim
            lblUrgentsTotal.Text = GetUrgentIssuesCount().ToString.Trim
        End Sub

        Private Function GetUrgentIssuesCount() As Integer
            Dim i As Integer = 0
            Dim oBR As New Common.BussinessRules.Issue
            i = oBR.SelectByUrgent(MyBase.LoggedOnUserID.Trim).Rows.Count
            oBR.Dispose()
            oBR = Nothing
            Return i
        End Function
#End Region

#Region " C,R,U,D "
        Private Sub _openProject()
            Dim oBR As New Common.BussinessRules.Project
            With oBR
                .ProjectID = lblProjectID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    lblProjectAliasName.Text = .ProjectAliasName.Trim
                    lblProjectName.Text = .ProjectName.Trim
                    lblProjectDescription.Text = .ProjectDescription.Trim
                    lblLastPatchNo.Text = .lastPatchNo.Trim
                    lblProjectCreatedDate.Text = Format(.insertDate, commonFunction.FORMAT_DATETIME)
                    lblProjectLastUpdatedDate.Text = .lastProjectUpdateDate.Trim
                Else
                    lblProjectAliasName.Text = String.Empty
                    lblProjectName.Text = String.Empty
                    lblProjectDescription.Text = String.Empty
                    lblLastPatchNo.Text = "-"
                    lblProjectCreatedDate.Text = "-"
                    lblProjectLastUpdatedDate.Text = "-"
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub _openIssue()
            Dim oBR As New Common.BussinessRules.Issue
            With oBR
                .IssueID = lblIssueID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    txtDepartmentName.Text = .DepartmentName.Trim
                    txtIssueDescription.Text = .IssueDescription.Trim
                    txtKeywords.Text = .Keywords.Trim
                    calReportedDate.selectedDate = .ReportedDate
                    txtReportedBy.Text = .ReportedBy.Trim
                    ddlProductRoadmap.SelectedValue = .ProductRoadmapSCode.Trim
                    ddlIssueType.SelectedValue = .IssueTypeSCode.Trim
                    ddlIssueStatus.SelectedValue = .IssueStatusSCode.Trim
                    ddlIssuePriority.SelectedValue = .IssuePrioritySCode.Trim
                    ddlIssueConfirmStatus.SelectedValue = .IssueConfirmStatusSCode.Trim
                    If .userIDassignedTo.Trim = String.Empty Then
                        ddlUserIDAssignedTo.SelectedIndex = 0
                    Else
                        ddlUserIDAssignedTo.SelectedValue = .userIDassignedTo.Trim
                    End If
                    calEstStartDate.selectedDate = .estStartDate
                    calTargetDate.selectedDate = .targetDate

                    'percobaan isPlanned
                    chkIsPlanned.Checked = .isPlanned

                    chkIsUrgent.Checked = .isUrgent
                    chkIsPlanned.Checked = .isPlanned
                    txtPatchNo.Text = .PatchNo.Trim
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub _openIssueForResponse()
            Dim oBR As New Common.BussinessRules.Issue
            With oBR
                .IssueID = Response_lblIssueID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    Response_lblDepartmentName.Text = .DepartmentName.Trim
                    Response_lblIssueDescription.Text = .IssueDescription.Trim
                    Response_ddlIssueStatus.SelectedValue = .IssueStatusSCode.Trim
                    Response_ddlIssueConfirmStatus.SelectedValue = .IssueConfirmStatusSCode.Trim
                    Response_txtPatchNo.Text = .PatchNo.Trim
                    Response_chkIsSpecific.Checked = .isSpecific
                Else
                    Response_lblDepartmentName.Text = String.Empty
                    Response_lblIssueDescription.Text = String.Empty
                    Response_ddlIssueStatus.SelectedIndex = 0
                    Response_ddlIssueConfirmStatus.SelectedIndex = 0
                    Response_txtPatchNo.Text = String.Empty
                    Response_chkIsSpecific.Checked = False
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Function _openValidatePatch(ByVal strPatchNo As String, ByVal txtPatch As TextBox) As String
            Dim strPatchNoToReturn As String = String.Empty
            Dim oPatch As New Common.BussinessRules.Patch
            With oPatch
                .PatchNo = strPatchNo.Trim
                If .SelectOne.Rows.Count = 0 Then
                    commonFunction.MsgBox(Me, "Patch No. Not Found. Please try again and input a valid Patch No.")
                    strPatchNoToReturn = String.Empty
                    commonFunction.Focus(Me, txtPatch.ClientID)
                Else
                    strPatchNoToReturn = .PatchNo.Trim
                    commonFunction.Focus(Me, txtPatch.ClientID)
                End If
            End With
            oPatch.Dispose()
            oPatch = Nothing

            Return strPatchNoToReturn.Trim
        End Function

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
                .DepartmentName = txtDepartmentName.Text.Trim
                .IssueDescription = txtIssueDescription.Text.Trim
                .Keywords = txtKeywords.Text.Trim
                .ReportedDate = calReportedDate.selectedDate
                .ReportedBy = txtReportedBy.Text.Trim
                .ProductRoadmapSCode = ddlProductRoadmap.SelectedValue.Trim
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

                .userIDinsert = MyBase.LoggedOnUserID.Trim
                .userIDupdate = MyBase.LoggedOnUserID.Trim
                If fNew Then
                    If .Insert() Then
                        lblIssueID.Text = .IssueID.Trim
                        If chkIsIncludeInMyWorktime.Checked Then
                            InsertWorkTimeHdFromAddEditIssue()
                        End If
                    End If
                Else
                    If .Update() Then
                        If chkIsIncludeInMyWorktime.Checked Then
                            InsertWorkTimeHdFromAddEditIssue()
                        End If
                    End If
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub _updateIssueStatus(ByVal IssueID As String)
            Dim oBR As New Common.BussinessRules.Issue
            With oBR
                .IssueID = IssueID.Trim
                .IssueStatusSCode = Response_ddlIssueStatus.SelectedValue.Trim
                .IssueConfirmStatusSCode = Response_ddlIssueConfirmStatus.SelectedValue.Trim
                .PatchNo = Response_txtPatchNo.Text.Trim
                .isSpecific = Response_chkIsSpecific.Checked
                .userIDupdate = MyBase.LoggedOnUserID.Trim
                .UpdateStatus()
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
                        If Response_chkIsUpdateStatus.Checked Then
                            _updateIssueStatus(Response_lblIssueID.Text.Trim)
                        End If

                        If Response_chkIsIncludeInMyWorktime.Checked Then
                            InsertWorkTimeHdFromAddEditResponse()
                        End If
                        Response_lblResponseID.Text = .ResponseID.Trim
                    End If
                Else
                    If .Update() Then
                        If Response_chkIsUpdateStatus.Checked Then
                            _updateIssueStatus(Response_lblIssueID.Text.Trim)
                        End If

                        If Response_chkIsIncludeInMyWorktime.Checked Then
                            InsertWorkTimeHdFromAddEditResponse()
                        End If
                    End If
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub _openIssueResponse()
            Dim oBR As New Common.BussinessRules.IssueResponse
            With oBR
                .ResponseID = Response_lblResponseID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    Response_calResponseDate.selectedDate = .ResponseDate
                    Response_txtResponseTimeStart.Text = .ResponseTimeStart.Trim
                    Response_txtResponseDuration.Text = .ResponseDuration.ToString.Trim
                    Response_ddlResponseType.SelectedValue = .ResponseTypeSCode.Trim
                    Response_txtResponseDescription.Text = .ResponseDescription.Trim
                    Response_chkIsShared.Checked = .isShared
                Else
                    PrepareScreenIssueResponse()
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
                    SetDataGrid()
                End If
            End With
            oFile.Dispose()
            oFile = Nothing
        End Sub

#Region " Link to My Worktime "
        Private Function IsWorkTimeSubmitted() As Boolean
            Dim ToReturnIsWorkTimeSubmitted As Boolean = False
            Dim oWTHd As New Common.BussinessRules.WorkTimeHd
            oWTHd.UserID = MyBase.LoggedOnUserID.Trim
            oWTHd.WorkTimeDate = Date.Today
            If oWTHd.SelectByUserIDWorkTimeDateSubmitted.Rows.Count > 0 Then
                ToReturnIsWorkTimeSubmitted = True
            Else
                ToReturnIsWorkTimeSubmitted = False
            End If
            oWTHd.Dispose()
            oWTHd = Nothing

            Return ToReturnIsWorkTimeSubmitted
        End Function

        Private Function IsAlreadyAddedToWorkTime(ByVal strIssueID As String) As Boolean
            Dim ToReturnIsAlreadyAddedToWorkTime As Boolean = False
            Dim oWTHd As New Common.BussinessRules.WorkTimeDt
            oWTHd.ProjectID = lblProjectID.Text.Trim
            oWTHd.IssueID = strIssueID.Trim
            If oWTHd.SelectByUserIDWorkTimeDateProjectIDIssueID(MyBase.LoggedOnUserID.Trim, Date.Today).Rows.Count > 0 Then
                ToReturnIsAlreadyAddedToWorkTime = True
            Else
                ToReturnIsAlreadyAddedToWorkTime = False
            End If
            oWTHd.Dispose()
            oWTHd = Nothing

            Return ToReturnIsAlreadyAddedToWorkTime
        End Function

        Private Sub InsertWorkTimeHdFromAddEditIssue()
            '// SHOULD BE CHECKED IF EXISTS BY UserID + IssueID + ProjectID + WorkTimeDate
            If IsWorkTimeSubmitted() = True Then
                commonFunction.MsgBox(Me, "Add failed. You have Submitted your today Worktime.")
                Exit Sub
            End If

            If IsAlreadyAddedToWorkTime(lblIssueID.Text.Trim) = True Then
                commonFunction.MsgBox(Me, "Add failed. You have Add this Issue ID to your today Worktime.")
                Exit Sub
            End If

            If txtWorktimeDtDescription.Text.Trim = String.Empty Then
                commonFunction.MsgBox(Me, "Please type in Worktime Description.")
                Exit Sub
            End If

            If IsNumeric(txtWorkTimeInHour.Text.Trim) = False Then
                commonFunction.MsgBox(Me, "Working time must be a number.")
                Exit Sub
            End If

            If CInt(txtWorkTimeInHour.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Working time must be greater than or equal to 0.")
                Exit Sub
            End If

            Dim isNew As Boolean = True
            Dim oWTHd As New Common.BussinessRules.WorkTimeHd
            oWTHd.UserID = MyBase.LoggedOnUserID.Trim
            oWTHd.WorkTimeDate = Date.Today
            isNew = oWTHd.SelectByUserIDWorkTimeDate.Rows.Count = 0
            oWTHd.Remarks = "Follow Up Basecamp Issue"
            oWTHd.IsSubmitted = False
            If isNew Then
                If oWTHd.Insert() Then
                    InsertUpdateWorkTimeDtFromAddEditIssue(oWTHd.WorkTimeHdID.Trim)
                End If
            Else
                InsertUpdateWorkTimeDtFromAddEditIssue(oWTHd.WorkTimeHdID.Trim)
            End If

            oWTHd.Dispose()
            oWTHd = Nothing
        End Sub

        Private Sub InsertWorkTimeHdFromAddEditResponse()
            '// SHOULD BE CHECKED IF EXISTS BY UserID + IssueID + ProjectID + WorkTimeDate
            If IsWorkTimeSubmitted() = True Then
                commonFunction.MsgBox(Me, "Add failed. You have Submitted your today Worktime.")
                Exit Sub
            End If

            If IsAlreadyAddedToWorkTime(Response_lblIssueID.Text.Trim) = True Then
                commonFunction.MsgBox(Me, "Add failed. You have Add this Issue ID to your today Worktime.")
                Exit Sub
            End If

            If Response_txtWorktimeDtDescription.Text.Trim = String.Empty Then
                commonFunction.MsgBox(Me, "Please type in Worktime Description.")
                Exit Sub
            End If

            If IsNumeric(Response_txtWorkTimeInHour.Text.Trim) = False Then
                commonFunction.MsgBox(Me, "Working time must be a number.")
                Exit Sub
            End If

            If CInt(Response_txtWorkTimeInHour.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Working time must be greater than or equal to 0.")
                Exit Sub
            End If

            Dim isNew As Boolean = True
            Dim oWTHd As New Common.BussinessRules.WorkTimeHd
            oWTHd.UserID = MyBase.LoggedOnUserID.Trim
            oWTHd.WorkTimeDate = Date.Today
            isNew = oWTHd.SelectByUserIDWorkTimeDate.Rows.Count = 0
            oWTHd.Remarks = "Follow Up Basecamp Issue"
            oWTHd.IsSubmitted = False
            If isNew Then
                If oWTHd.Insert() Then
                    InsertUpdateWorkTimeDtFromAddEditResponse(oWTHd.WorkTimeHdID.Trim)
                End If
            Else
                InsertUpdateWorkTimeDtFromAddEditResponse(oWTHd.WorkTimeHdID.Trim)
            End If

            oWTHd.Dispose()
            oWTHd = Nothing
        End Sub

        Private Sub InsertUpdateWorkTimeDtFromAddEditIssue(ByVal strWorktimeHdID As String)
            Dim oWTDt As New Common.BussinessRules.WorkTimeDt
            oWTDt.WorkTimeHdID = strWorktimeHdID.Trim
            oWTDt.ProjectID = lblProjectID.Text.Trim
            oWTDt.IssueID = lblIssueID.Text.Trim
            oWTDt.DetailDescription = txtWorktimeDtDescription.Text.Trim
            oWTDt.WorkTimeInHour = CInt(txtWorkTimeInHour.Text.Trim)
            oWTDt.Insert()
            oWTDt.Dispose()
            oWTDt = Nothing
        End Sub

        Private Sub InsertUpdateWorkTimeDtFromAddEditResponse(ByVal strWorktimeHdID As String)
            Dim oWTDt As New Common.BussinessRules.WorkTimeDt
            oWTDt.WorkTimeHdID = strWorktimeHdID.Trim
            oWTDt.ProjectID = lblProjectID.Text.Trim
            oWTDt.IssueID = Response_lblIssueID.Text.Trim
            oWTDt.DetailDescription = Response_txtWorktimeDtDescription.Text.Trim
            oWTDt.WorkTimeInHour = CInt(Response_txtWorkTimeInHour.Text.Trim)
            oWTDt.Insert()
            oWTDt.Dispose()
            oWTDt = Nothing
        End Sub
#End Region
#End Region

    End Class

End Namespace