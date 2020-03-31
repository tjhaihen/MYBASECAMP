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

Namespace QIS.Web.PatchManagement
    Public Class PatchList
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
                setToolbarVisibleButton()
                PrepareDDL()
                PrepareDDL_PatchProject_ddlProject(txtPatchNo.Text.Trim)
                PrepareScreen()
            End If
        End Sub

        Private Sub txtIssueID_TextChanged(sender As Object, e As System.EventArgs) Handles txtIssueID.TextChanged
            OpenIssue()
        End Sub

        Private Sub btnAddPatchIssue_Click(sender As Object, e As System.EventArgs) Handles btnAddPatchIssue.Click
            InsertUpdatePatchIssue(txtIssueID.Text.Trim, False)
            PrepareScreenPatchIssue()
        End Sub

        Private Sub PatchDt_btnAddPatchDt_Click(sender As Object, e As System.EventArgs) Handles PatchDt_btnAddPatchDt.Click
            InsertUpdatePatchDt()
            PrepareScreenPatchIssue()            
        End Sub

        Private Sub PatchProject_btnAddPatchProject_Click(sender As Object, e As System.EventArgs) Handles PatchProject_btnAddPatchProject.Click
            InsertPatchProject()
            PrepareScreenPatchIssue()
        End Sub

        Private Sub grdPatchList_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPatchList.ItemCommand
            Select Case e.CommandName
                Case "SelectPatch"
                    Dim _lbtnPatchNo As LinkButton = CType(e.Item.FindControl("_lbtnPatchNo"), LinkButton)
                    txtPatchNo.Text = _lbtnPatchNo.Text.Trim
                    OpenPatch(txtPatchNo.Text.Trim)
            End Select
        End Sub

        Private Sub grdPatchIssue_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPatchIssue.ItemCommand
            Select Case e.CommandName
                Case "Delete"
                    rfvIssueID.Enabled = False
                    Dim _lblIssueID As Label = CType(e.Item.FindControl("_lblIssueID"), Label)
                    InsertUpdatePatchIssue(_lblIssueID.Text.Trim, True)
                    PrepareScreenPatchIssue()
            End Select
        End Sub

        Private Sub grdPatchDt_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPatchDt.ItemCommand
            Select Case e.CommandName
                Case "Edit"
                    Dim grdPatchDt_lblPatchDtID As Label = CType(e.Item.FindControl("grdPatchDt_lblPatchDtID"), Label)
                    PatchDt_txtPatchDtID.Text = grdPatchDt_lblPatchDtID.Text.Trim
                    OpenPatchDt(PatchDt_txtPatchDtID.Text.Trim)

                Case "Delete"
                    rfvIssueID.Enabled = False
                    Dim grdPatchDt_lblPatchDtID As Label = CType(e.Item.FindControl("grdPatchDt_lblPatchDtID"), Label)
                    DeletePatchDt(grdPatchDt_lblPatchDtID.Text.Trim)
                    PrepareScreenPatchIssue()
            End Select
        End Sub

        Private Sub grdPatchProject_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPatchProject.ItemCommand
            Select Case e.CommandName
                Case "Delete"
                    rfvIssueID.Enabled = False
                    Dim grdPatchProject_lblPatchProjectID As Label = CType(e.Item.FindControl("grdPatchProject_lblPatchProjectID"), Label)
                    DeletePatchProject(grdPatchProject_lblPatchProjectID.Text.Trim)
                    PrepareScreenPatchIssue()
            End Select
        End Sub
#End Region

#Region " Support functions for navigation bar (Controls) "
        Private Sub setToolbarVisibleButton()
            With CSSToolbar
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidPrint) = False
                .VisibleButton(CSSToolbarItem.tidApprove) = False
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidPrevious) = False
                .VisibleButton(CSSToolbarItem.tidNext) = False
                .VisibleButton(CSSToolbarItem.tidDownload) = True
            End With
        End Sub

        Private Sub mdlToolbar_commandBarClick(ByVal sender As Object, ByVal e As CSSToolbarItem) Handles CSSToolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidDelete
                    DeletePatch()
                    PrepareScreen()

                Case CSSToolbarItem.tidNew
                    PrepareScreen()

                Case CSSToolbarItem.tidSave
                    InsertUpdatePatch()
                    PrepareScreenPatchIssue()
                    UpdateViewGridPatchList()

                Case CSSToolbarItem.tidDownload
                    Dim oRPT As New Common.BussinessRules.MyReport
                    oRPT.AddParameters(txtPatchNo.Text.Trim)
                    oRPT.ReportCode = Common.Constants.ReportID.PatchDetail_ReportID
                    oRPT.GetReportDataByReportCode()
                    If oRPT.ReportFormat = "XLS" Then
                        oRPT.ExportToExcel(oRPT.generateReportDataTable, Response)
                    End If
                    oRPT.Dispose()
                    oRPT = Nothing
            End Select
        End Sub
#End Region

#Region " Private Functions "
        Private Function ReadQueryString() As Boolean

        End Function

        Private Sub PrepareDDL()
            commonFunction.SetDDL_Table(PatchDt_ddlProject, "ProjectUser", MyBase.LoggedOnUserID.Trim, True, "All Project")            
        End Sub

        Private Sub PrepareDDL_PatchProject_ddlProject(ByVal strPatchNo As String)
            commonFunction.SetDDL_Table(PatchProject_ddlProject, "ProjectNotInPatchProject", strPatchNo.Trim)
        End Sub

        Private Sub PrepareScreen()
            lblPageTitle.Text = "Patch List"
            txtPatchNo.Text = String.Empty
            calPatchDate.selectedDate = Date.Today
            txtRemarks.Text = String.Empty

            txtIssueID.Text = String.Empty
            txtIssueID.Enabled = False
            lblIssueInformation.Text = String.Empty
            rfvIssueID.Enabled = False
            chkIsSpecific.Checked = False
            lblIssueAlreadyOnOtherPatch.Text = String.Empty
            pnlIssuePatchWarning.Visible = False
            btnAddPatchIssue.Enabled = False

            PatchDt_txtPatchDtID.Text = String.Empty
            PatchDt_txtRemarks.Text = String.Empty
            PatchDt_ddlProject.SelectedIndex = 0
            PatchDt_chkIsSpecific.Checked = False
            PatchDt_btnAddPatchDt.Enabled = False

            PatchProject_txtPatchProjectID.Text = String.Empty
            PatchProject_ddlProject.SelectedIndex = 0
            PatchProject_calUpdateDate.selectedDate = Date.Today
            PatchProject_txtRemarks.Text = String.Empty
            PatchProject_btnAddPatchProject.Enabled = False

            UpdateViewGridPatchList()
            UpdateViewGridPatchIssue()
            UpdateViewGridPatchDt()
            UpdateViewGridPatchProject()
            commonFunction.Focus(Me, txtPatchNo.ClientID)
        End Sub

        Private Sub PrepareScreenPatchIssue()
            txtIssueID.Text = String.Empty
            txtIssueID.Enabled = True
            lblIssueInformation.Text = String.Empty
            rfvIssueID.Enabled = True
            chkIsSpecific.Checked = False
            lblIssueAlreadyOnOtherPatch.Text = String.Empty
            pnlIssuePatchWarning.Visible = False
            btnAddPatchIssue.Enabled = False

            PatchDt_txtPatchDtID.Text = String.Empty
            PatchDt_txtRemarks.Text = String.Empty
            PatchDt_ddlProject.SelectedIndex = 0
            PatchDt_chkIsSpecific.Checked = False
            PatchDt_btnAddPatchDt.Enabled = True

            PrepareDDL_PatchProject_ddlProject(txtPatchNo.Text.Trim)
            PatchProject_txtPatchProjectID.Text = String.Empty
            PatchProject_ddlProject.SelectedIndex = 0
            PatchProject_calUpdateDate.selectedDate = Date.Today
            PatchProject_txtRemarks.Text = String.Empty
            PatchProject_btnAddPatchProject.Enabled = True

            UpdateViewGridPatchIssue()
            UpdateViewGridPatchDt()
            UpdateViewGridPatchProject()
        End Sub

        Private Sub UpdateViewGridPatchList()
            Dim oPatch As New Common.BussinessRules.Patch
            grdPatchList.DataSource = oPatch.SelectAll
            grdPatchList.DataBind()
            oPatch.Dispose()
            oPatch = Nothing
        End Sub

        Private Sub UpdateViewGridPatchIssue()
            'If txtPatchNo.Text.Trim = String.Empty Then Exit Sub
            Dim oIssue As New Common.BussinessRules.Issue
            With oIssue
                oIssue.PatchNo = txtPatchNo.Text.Trim
                grdPatchIssue.DataSource = oIssue.SelectByPatchNo()
                grdPatchIssue.DataBind()
            End With
            oIssue.Dispose()
            oIssue = Nothing
        End Sub

        Private Sub UpdateViewGridPatchDt()
            'If txtPatchNo.Text.Trim = String.Empty Then Exit Sub
            Dim oPatchDt As New Common.BussinessRules.PatchDt
            With oPatchDt
                .PatchNo = txtPatchNo.Text.Trim
                grdPatchDt.DataSource = oPatchDt.SelectByPatchNo()
                grdPatchDt.DataBind()
            End With
            oPatchDt.Dispose()
            oPatchDt = Nothing
        End Sub

        Private Sub UpdateViewGridPatchProject()
            'If txtPatchNo.Text.Trim = String.Empty Then Exit Sub
            Dim oPatchPr As New Common.BussinessRules.PatchProject
            With oPatchPr
                .PatchNo = txtPatchNo.Text.Trim
                grdPatchProject.DataSource = oPatchPr.SelectByPatchNo()
                grdPatchProject.DataBind()
            End With
            oPatchPr.Dispose()
            oPatchPr = Nothing
        End Sub
#End Region

#Region " C,R,U,D "
        Private Sub OpenPatch(ByVal strPatchNo As String)
            Dim oPatch As New Common.BussinessRules.Patch
            With oPatch
                .PatchNo = strPatchNo.Trim
                If .SelectOne.Rows.Count > 0 Then
                    calPatchDate.selectedDate = .PatchDate
                    txtRemarks.Text = .Remarks.Trim
                    PrepareScreenPatchIssue()
                Else
                    PrepareScreen()
                End If
            End With
            oPatch.Dispose()
            oPatch = Nothing
        End Sub

        Private Sub OpenPatchDt(ByVal strPatchDtID As String)
            Dim oPatchDt As New Common.BussinessRules.PatchDt
            With oPatchDt
                .PatchDtID = strPatchDtID.Trim
                If .SelectOne.Rows.Count > 0 Then
                    PatchDt_txtRemarks.Text = .Remarks.Trim
                    PatchDt_ddlProject.SelectedValue = .ProjectID.Trim
                    PatchDt_chkIsSpecific.Checked = .IsSpecific
                Else
                    PrepareScreenPatchIssue()
                End If
            End With
            oPatchDt.Dispose()
            oPatchDt = Nothing
        End Sub

        Private Sub OpenIssue()
            Dim oIssue As New Common.BussinessRules.Issue
            With oIssue
                .IssueID = txtIssueID.Text.Trim
                If .SelectOneForInformation.Rows.Count > 0 Then
                    lblIssueInformation.Text = "Project: " + .ProjectAliasName.Trim + " | " + .IssueDescription.Trim
                    btnAddPatchIssue.Enabled = True
                    If .PatchNo.Trim.Length > 0 Then
                        pnlIssuePatchWarning.Visible = True
                        lblIssueAlreadyOnOtherPatch.Text = "This Issue ID already in this current Patch No.: " + .PatchNo.Trim + ". By clicking Add button will move this Issue ID into this Patch No.: " + txtPatchNo.Text.Trim + ". Continue?"
                    Else
                        pnlIssuePatchWarning.Visible = False
                        lblIssueAlreadyOnOtherPatch.Text = String.Empty
                    End If
                Else
                    lblIssueInformation.Text = "Issue ID Not Found."
                    btnAddPatchIssue.Enabled = False
                End If
            End With
            oIssue.Dispose()
            oIssue = Nothing
        End Sub

        Private Sub InsertUpdatePatch()
            Page.Validate()
            If Not Page.IsValid Then Exit Sub
            Dim isNew As Boolean = True

            Dim oPatch As New Common.BussinessRules.Patch
            With oPatch
                .PatchNo = txtPatchNo.Text.Trim
                isNew = .SelectOne.Rows.Count = 0
                .PatchDate = calPatchDate.selectedDate
                .Remarks = txtRemarks.Text.Trim
                .userIDinsert = MyBase.LoggedOnUserID.Trim
                If isNew Then
                    .Insert()
                Else
                    .Update()
                End If
            End With
            oPatch.Dispose()
            oPatch = Nothing
        End Sub

        Private Sub InsertUpdatePatchIssue(ByVal strIssueID As String, ByVal isDelete As Boolean)
            Page.Validate()
            If Not Page.IsValid Then Exit Sub

            Dim oIssue As New Common.BussinessRules.Issue
            With oIssue
                .IssueID = strIssueID.Trim
                If Not isDelete Then
                    .PatchNo = txtPatchNo.Text.Trim
                    .isSpecific = chkIsSpecific.Checked
                Else
                    .PatchNo = String.Empty
                    .isSpecific = False
                End If
                .userIDupdate = MyBase.LoggedOnUserID.Trim
                .UpdatePatchNo()
            End With
            oIssue.Dispose()
            oIssue = Nothing
        End Sub

        Private Sub InsertUpdatePatchDt()
            If PatchDt_txtRemarks.Text = String.Empty Then Exit Sub
            Dim isNew As Boolean = True

            Dim oPatchDt As New Common.BussinessRules.PatchDt
            With oPatchDt
                .PatchDtID = PatchDt_txtPatchDtID.Text.Trim
                isNew = .SelectOne.Rows.Count = 0
                .PatchNo = txtPatchNo.Text.Trim
                .Remarks = PatchDt_txtRemarks.Text.Trim
                .ProjectID = PatchDt_ddlProject.SelectedItem.Value.Trim
                .IsSpecific = PatchDt_chkIsSpecific.Checked
                .userIDinsert = MyBase.LoggedOnUserID.Trim
                .userIDupdate = MyBase.LoggedOnUserID.Trim
                If isNew Then
                    .Insert()
                Else
                    .Update()
                End If
            End With
            oPatchDt.Dispose()
            oPatchDt = Nothing
        End Sub

        Private Sub InsertPatchProject()
            Dim oPatchPr As New Common.BussinessRules.PatchProject
            With oPatchPr
                .PatchProjectID = PatchProject_txtPatchProjectID.Text.Trim
                .PatchNo = txtPatchNo.Text.Trim
                .ProjectID = PatchProject_ddlProject.SelectedItem.Value.Trim
                .updateDate = PatchProject_calUpdateDate.selectedDate
                .Remarks = PatchProject_txtRemarks.Text.Trim
                .userIDinsert = MyBase.LoggedOnUserID.Trim
                .Insert()
            End With
            oPatchPr.Dispose()
            oPatchPr = Nothing
        End Sub

        Private Sub DeletePatch()
            Page.Validate()
            If Not Page.IsValid Then Exit Sub

            Dim oPatch As New Common.BussinessRules.Patch
            With oPatch
                .PatchNo = txtPatchNo.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    .Delete()
                Else
                    commonFunction.MsgBox(Me, "Delete failed. Patch No. Not Found.")
                End If
            End With
            oPatch.Dispose()
            oPatch = Nothing
        End Sub

        Private Sub DeletePatchDt(ByVal strPatchDtID As String)
            Dim oPatchDt As New Common.BussinessRules.PatchDt
            With oPatchDt
                .PatchDtID = strPatchDtID.Trim
                .Delete()
            End With
            oPatchDt.Dispose()
            oPatchDt = Nothing
        End Sub

        Private Sub DeletePatchProject(ByVal strPatchProjectID As String)
            Dim oPatchPr As New Common.BussinessRules.PatchProject
            With oPatchPr
                .PatchProjectID = strPatchProjectID.Trim
                .Delete()
            End With
            oPatchPr.Dispose()
            oPatchPr = Nothing
        End Sub
#End Region

    End Class

End Namespace