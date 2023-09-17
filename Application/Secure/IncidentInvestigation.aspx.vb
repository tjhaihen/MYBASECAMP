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
    Public Class IncidentInvestigation
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
                prepareDDL()
                PrepareScreen()
            End If
        End Sub

        Private Sub txtYear_TextChanged(sender As Object, e As System.EventArgs) Handles txtYear.TextChanged
            UpdateViewGridList()
        End Sub

        Private Sub btnIncidentInvestigation_Click(sender As Object, e As System.EventArgs) Handles btnIncidentInvestigation.Click
            pnlInvestigation.Visible = True
            pnlChronological.Visible = False
            btnIncidentInvestigation.Enabled = False
            btnIncidentChronological.Enabled = True
        End Sub

        Private Sub btnIncidentChronological_Click(sender As Object, e As System.EventArgs) Handles btnIncidentChronological.Click
            pnlInvestigation.Visible = False
            pnlChronological.Visible = True
            btnIncidentInvestigation.Enabled = True
            btnIncidentChronological.Enabled = False
        End Sub

        Private Sub btnAddIncidentChronological_Click(sender As Object, e As System.EventArgs) Handles btnAddIncidentChronological.Click
            InsertUpdateDt(txtReportNo.Text.Trim)
        End Sub

        Private Sub grdIncidentInvestigation_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdIncidentInvestigation.ItemCommand
            Select Case e.CommandName
                Case "SelectData"
                    Dim _lbtnReportNo As LinkButton = CType(e.Item.FindControl("_lbtnReportNo"), LinkButton)
                    Open(_lbtnReportNo.Text.Trim)
            End Select
        End Sub

        Private Sub grdIncidentChronological_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdIncidentChronological.ItemCommand
            Select Case e.CommandName
                Case "Delete"
                    Dim _lblincidentChronologicalID As Label = CType(e.Item.FindControl("_lblincidentChronologicalID"), Label)
                    DeleteDt(_lblincidentChronologicalID.Text.Trim)
            End Select
        End Sub
#End Region

#Region " Support functions for navigation bar (Controls) "
        Private Sub setToolbarVisibleButton()
            With CSSToolbar
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidPrint) = False
                .VisibleButton(CSSToolbarItem.tidPrevious) = False
                .VisibleButton(CSSToolbarItem.tidNext) = False
            End With
        End Sub

        Private Sub mdlToolbar_commandBarClick(ByVal sender As Object, ByVal e As CSSToolbarItem) Handles CSSToolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidDelete
                    Delete()
                Case CSSToolbarItem.tidNew
                    PrepareScreen()
                Case CSSToolbarItem.tidSave
                    InsertUpdate()
                Case CSSToolbarItem.tidApprove
                    UpdateApproval()
            End Select
        End Sub
#End Region

#Region " Private Functions "
        Private Function ReadQueryString() As Boolean

        End Function

        Private Sub prepareDDL()
            commonFunction.SetDDL_Table(ddlseveritySCode, "CommonCode", Common.Constants.GroupCode.IncidentSeverity_SCode, False)
        End Sub

        Private Sub PrepareScreen()
            lblPageTitle.Text = "Laporan Investigasi Insiden"

            chkIsApproved.Checked = False
            txtReportNo.Text = String.Empty
            calReportDate.selectedDate = Date.Today
            txtincidentSubject.Text = String.Empty
            txtincidentLocation.Text = String.Empty
            calincidentDate.selectedDate = Date.Today
            txtincidentTime.Text = Format(Date.Now, "hh:mm").Trim
            ddlseveritySCode.SelectedIndex = 0
            txtincidentType.Text = String.Empty
            txtincidentDescription.Text = String.Empty
            txtincidentWitness.Text = String.Empty
            txtincidentConsequence.Text = String.Empty
            txtincidentConsequenceEst.Text = String.Empty
            txtincidentTrigger.Text = String.Empty
            txtcorrectiveAction.Text = String.Empty
            txtrecommendationFromDeptMgr.Text = String.Empty

            lblCreatedBy.Text = "-"
            lblReviewBy.Text = "-"
            
            CSSToolbar.VisibleButton(CSSToolbarItem.tidSave) = True
            CSSToolbar.VisibleButton(CSSToolbarItem.tidDelete) = True
            CSSToolbar.VisibleButton(CSSToolbarItem.tidApprove) = True

            btnIncidentInvestigation.Enabled = False
            btnIncidentChronological.Enabled = False
            pnlInvestigation.Visible = True
            pnlChronological.Visible = False

            PrepareScreenDt()
            txtYear.Text = Year(Date.Today).ToString.Trim
            UpdateViewGridList()

            commonFunction.Focus(Me, txtincidentSubject.ClientID)
        End Sub

        Private Sub PrepareScreenDt()
            calChronologicalDate.selectedDate = Date.Today
            txtChronologicalTime.Text = Format(Date.Now, "hh:mm").Trim
            txtIncidentChronological.Text = String.Empty

            UpdateViewGridChronological()
        End Sub

        Private Sub PrepareScreenAfterApproval()
            CSSToolbar.VisibleButton(CSSToolbarItem.tidSave) = False
            CSSToolbar.VisibleButton(CSSToolbarItem.tidDelete) = False
            CSSToolbar.VisibleButton(CSSToolbarItem.tidApprove) = False
        End Sub

        Private Sub UpdateViewGridList()
            Dim intYear As Integer = Year(Date.Today)
            If IsNumeric(txtYear.Text.Trim) = True Then
                intYear = CInt(txtYear.Text.Trim)
            Else
                commonFunction.MsgBox(Me, "Format Tahun tidak sesuai. Mohon isi Tahun dengan format yang sesuai.")
                Exit Sub
            End If

            Dim oBr As New Common.BussinessRules.IncidentInvestigation
            grdIncidentInvestigation.DataSource = oBr.SelectByYear(intYear)
            grdIncidentInvestigation.DataBind()
            oBr.Dispose()
            oBr = Nothing
        End Sub

        Private Sub UpdateViewGridChronological()
            Dim oBr As New Common.BussinessRules.IncidentChronological
            oBr.incidentNo = txtReportNo.Text.Trim
            grdIncidentChronological.DataSource = oBr.SelectByIncidentNo
            grdIncidentChronological.DataBind()
            oBr.Dispose()
            oBr = Nothing
        End Sub
#End Region

#Region " C,R,U,D "
        Private Sub InsertUpdate()
            Page.Validate()
            If Not Page.IsValid Then Exit Sub
            Dim isNew As Boolean = True

            Dim oBR As New Common.BussinessRules.IncidentInvestigation
            oBR.incidentNo = txtReportNo.Text.Trim
            If oBR.SelectOne.Rows.Count > 0 Then
                isNew = False
            Else
                isNew = True
            End If

            oBR.reportDate = calReportDate.selectedDate
            oBR.incidentSubject = txtincidentSubject.Text.Trim
            oBR.incidentLocation = txtincidentLocation.Text.Trim
            oBR.incidentDate = calincidentDate.selectedDate
            oBR.incidentTime = txtincidentTime.Text.Trim
            oBR.severitySCode = ddlseveritySCode.SelectedValue.Trim
            oBR.incidentType = txtincidentType.Text.Trim
            oBR.incidentDescription = txtincidentDescription.Text.Trim
            oBR.incidentWitness = txtincidentWitness.Text.Trim
            oBR.incidentConsequence = txtincidentConsequence.Text.Trim
            oBR.incidentConsequenceEst = txtincidentConsequenceEst.Text.Trim
            oBR.incidentTrigger = txtincidentTrigger.Text.Trim
            oBR.correctiveAction = txtcorrectiveAction.Text.Trim
            oBR.recommendationFromDeptMgr = txtrecommendationFromDeptMgr.Text.Trim
            oBR.userIDinsert = MyBase.LoggedOnUserID.Trim
            oBR.userIDupdate = MyBase.LoggedOnUserID.Trim

            If isNew Then
                If oBR.Insert() Then
                    txtReportNo.Text = oBR.incidentNo.Trim
                    Open(txtReportNo.Text.Trim)
                End If
            Else
                If oBR.Update() Then
                End If
            End If
            oBR.Dispose()
            oBR = Nothing

            UpdateViewGridList()
        End Sub

        Private Sub InsertUpdateDt(ByVal strReportNo As String)
            Dim isNew As Boolean = True
            Dim oBr As New Common.BussinessRules.IncidentChronological
            oBr.incidentNo = strReportNo.Trim
            oBr.chronologicalDate = calChronologicalDate.selectedDate
            oBr.chronologicalTime = txtChronologicalTime.Text.Trim
            oBr.incidentChronological = txtIncidentChronological.Text.Trim
            If isNew Then
                oBr.Insert()
            Else
                oBr.Update()
            End If
            oBr.Dispose()
            oBr = Nothing
            PrepareScreenDt()
        End Sub

        Private Sub Open(ByVal strReportNo As String)
            Dim oBR As New Common.BussinessRules.IncidentInvestigation
            oBR.incidentNo = strReportNo.Trim
            If oBR.SelectOne.Rows.Count > 0 Then
                txtReportNo.Text = oBR.incidentNo.Trim
                calReportDate.selectedDate = oBR.reportDate
                txtincidentSubject.Text = oBR.incidentSubject.Trim
                txtincidentLocation.Text = oBR.incidentLocation.Trim
                calincidentDate.selectedDate = oBR.incidentDate
                txtincidentTime.Text = oBR.incidentTime.Trim
                ddlseveritySCode.SelectedValue = oBR.severitySCode.Trim
                txtincidentType.Text = oBR.incidentType.Trim
                txtincidentDescription.Text = oBR.incidentDescription.Trim
                txtincidentWitness.Text = oBR.incidentWitness.Trim
                txtincidentConsequence.Text = oBR.incidentConsequence.Trim
                txtincidentConsequenceEst.Text = oBR.incidentConsequenceEst.Trim
                txtincidentTrigger.Text = oBR.incidentTrigger.Trim
                txtcorrectiveAction.Text = oBR.correctiveAction.Trim
                txtrecommendationFromDeptMgr.Text = oBR.recommendationFromDeptMgr.Trim
                chkIsApproved.Checked = oBR.isApproved
                btnIncidentChronological.Enabled = True

                Dim strPersonName As String = String.Empty
                Dim oUS As New Common.BussinessRules.User
                oUS.UserID = oBR.userIDinsert.Trim
                If oUS.SelectOne.Rows.Count > 0 Then
                    Dim oPR As New Common.BussinessRules.Person
                    oPR.PersonID = oUS.PersonID.Trim
                    If oPR.SelectOne.Rows.Count > 0 Then
                        strPersonName = (oPR.FirstName.Trim + " " + oPR.MiddleName.Trim + " " + oPR.LastName.Trim).Trim
                    End If
                    oPR.Dispose()
                    oPR = Nothing
                End If
                oUS.Dispose()
                oUS = Nothing

                UpdateViewGridChronological()

                lblCreatedBy.Text = strPersonName.Trim + "|" + Format(oBR.insertDate, "dd-MMM-yyyy hh:mm")
                lblReviewBy.Text = oBR.reviewByName.Trim
            Else
                PrepareScreen()
            End If
            oBR.Dispose()
            oBR = Nothing
            PrepareScreenDt()

            If chkIsApproved.Checked Then
                CSSToolbar.VisibleButton(CSSToolbarItem.tidSave) = False
                CSSToolbar.VisibleButton(CSSToolbarItem.tidDelete) = False
                CSSToolbar.VisibleButton(CSSToolbarItem.tidApprove) = False
                btnAddIncidentChronological.Enabled = False
            Else
                CSSToolbar.VisibleButton(CSSToolbarItem.tidSave) = True
                CSSToolbar.VisibleButton(CSSToolbarItem.tidDelete) = True
                CSSToolbar.VisibleButton(CSSToolbarItem.tidApprove) = True
                btnAddIncidentChronological.Enabled = True
            End If
        End Sub

        Private Sub Delete()
            Dim oBR As New Common.BussinessRules.IncidentInvestigation
            oBR.incidentNo = txtReportNo.Text.Trim
            If oBR.SelectOne.Rows.Count > 0 Then
                oBR.userIDdelete = MyBase.LoggedOnUserID.Trim
                oBR.Delete()
            Else
                oBR.Dispose()
                oBR = Nothing
                commonFunction.MsgBox(Me, "Nomor Laporan Tidak Terdaftar. Mohon Pastikan Nomor Laporan yang Benar.")
                Exit Sub
            End If

            oBR.Dispose()
            oBR = Nothing

            UpdateViewGridList()
        End Sub

        Private Sub DeleteDt(ByVal strincidentChronologicalID As String)
            Dim oBr As New Common.BussinessRules.IncidentChronological
            oBr.incidentChronologicalID = strincidentChronologicalID.Trim
            oBr.Delete()
            oBr.Dispose()
            oBr = Nothing

            UpdateViewGridChronological()
        End Sub

        Private Sub UpdateApproval()
            Dim strPersonName As String = String.Empty
            Dim oUS As New Common.BussinessRules.User
            oUS.UserID = MyBase.LoggedOnUserID.Trim
            If oUS.SelectOne.Rows.Count > 0 Then
                Dim oPR As New Common.BussinessRules.Person
                oPR.PersonID = oUS.PersonID.Trim
                If oPR.SelectOne.Rows.Count > 0 Then
                    strPersonName = (oPR.FirstName.Trim + " " + oPR.MiddleName.Trim + " " + oPR.LastName.Trim).Trim
                End If
                oPR.Dispose()
                oPR = Nothing
            End If
            oUS.Dispose()
            oUS = Nothing

            Dim oBR As New Common.BussinessRules.IncidentInvestigation
            oBR.incidentNo = txtReportNo.Text.Trim
            If oBR.SelectOne.Rows.Count > 0 Then
                oBR.userIDupdate = MyBase.LoggedOnUserID.Trim
                If oBR.UpdateApproval(strPersonName.Trim) Then
                    Open(txtReportNo.Text.Trim)
                    UpdateViewGridList()
                End If
            Else
                oBR.Dispose()
                oBR = Nothing
                commonFunction.MsgBox(Me, "Nomor Laporan Tidak Terdaftar. Mohon Pastikan Nomor Laporan yang Benar.")
                Exit Sub
            End If

            oBR.Dispose()
            oBR = Nothing
        End Sub
#End Region

    End Class

End Namespace