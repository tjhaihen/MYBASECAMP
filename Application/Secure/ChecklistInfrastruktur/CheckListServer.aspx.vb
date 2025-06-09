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

Namespace QIS.Web.WorkTime
    Public Class CheckListServer
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

        Private Sub ddlMonth_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlMonth.SelectedIndexChanged
            GetDateInMonth()
        End Sub

        Private Sub txtYear_TextChanged(sender As Object, e As System.EventArgs) Handles txtYear.TextChanged
            GetDateInMonth()
        End Sub

        Private Sub grdDateInMonth_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdDateInMonth.ItemCommand
            Select Case e.CommandName
                Case "SelectDate"
                    Dim _lbtnDateInMonth As LinkButton = CType(e.Item.FindControl("_lbtnDateInMonth"), LinkButton)
                    lblSelectedDate.Text = _lbtnDateInMonth.Text.Trim
                    Dim dd As String = Left(lblSelectedDate.Text, 2)
                    Dim yyyy As String = Right(lblSelectedDate.Text, 4)
                    Dim mmm As String = lblSelectedDate.Text.Substring(3, 3)
                    Dim arMonth() As String = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}
                    Dim numbermm As Integer = Array.IndexOf(arMonth, mmm) + 1
                    Dim mm As String = numbermm.ToString
                    Dim stringDate As String = yyyy + "-" + mm + "-" + dd
                    Dim convertedDate As DateTime = DateTime.Parse(stringDate)
                    lblDayOfWeekSelectedDate.Text = convertedDate.DayOfWeek.ToString + ", "
                    Open()
            End Select
        End Sub
#End Region

#Region " Support functions for navigation bar (Controls) "
        Private Sub setToolbarVisibleButton()
            With CSSToolbar
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                '.VisibleButton(CSSToolbarItem.tidPrint) = False
                .VisibleButton(CSSToolbarItem.tidPrevious) = False
                .VisibleButton(CSSToolbarItem.tidNext) = False
                .VisibleButton(CSSToolbarItem.tidDownload) = False
                .VisibleButton(CSSToolbarItem.tidNew) = False
                .VisibleButton(CSSToolbarItem.tidDelete) = False
            End With
        End Sub

        Private Sub mdlToolbar_commandBarClick(ByVal sender As Object, ByVal e As CSSToolbarItem) Handles CSSToolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidVoid
                    Dim comm As New Common.BussinessRules.CommonCode
                    Dim oCheck As New Common.BussinessRules.ChecklistInfrastruktur
                    Dim isApprove As Boolean
                    Dim isValidasi As Boolean
                    With oCheck
                        .Tanggal = CDate(lblSelectedDate.Text.Trim)
                        If .SelectOne.Rows.Count > 0 Then
                            isApprove = .isApprove
                            isValidasi = .isValidation
                        Else
                            isApprove = False
                            isValidasi = False
                        End If

                        If isValidasi = True Then
                            With comm
                                .Code = "DIR"
                                .GroupCode = "Direktur"
                                .SelectOne()
                                If .Value = Me.LoggedOnUserID Then
                                    UpdateValidasi(False)
                                Else
                                    Throw New Exception("Data sudah validasi, void hanya dapat dilakukan oleh Direktur")
                                    Exit Sub
                                End If
                            End With
                            comm.Dispose()
                            comm = Nothing
                        ElseIf isApprove = True And isValidasi = False Then
                            With comm
                                .Code = "MGRITS"
                                .GroupCode = "Manager"
                                .SelectOne()
                                If .Value = Me.LoggedOnUserID Then
                                    UpdateValidasi(False)
                                Else
                                    Throw New Exception("Data sudah approval, void hanya dapat dilakukan oleh Manager ITS")
                                    Exit Sub
                                End If
                            End With
                            comm.Dispose()
                            comm = Nothing
                        Else
                            Delete()
                        End If
                    End With
                    oCheck.Dispose()
                    oCheck = Nothing
                Case CSSToolbarItem.tidSave
                    InsertUpdate(False)
                Case CSSToolbarItem.tidApprove
                    Dim comm As New Common.BussinessRules.CommonCode
                    With comm
                        .Code = "MGRITS"
                        .GroupCode = "Manager"
                        .SelectOne()
                        If .Value = Me.LoggedOnUserID Then
                            UpdateValidasi(True)
                        Else
                            Throw New Exception("Approval hanya dapat dilakukan oleh Manager ITS")
                            Exit Sub
                        End If
                    End With
                    comm.Dispose()
                    comm = Nothing
                Case CSSToolbarItem.tidPrint
                    'Dim result As String
                    Dim br As New Common.BussinessRules.MyReport
                    With br
                        .ReportCode = "9001"
                        .AddParameters(txtYear.Text.Trim)
                        .AddParameters(ddlMonth.SelectedValue)
                        Response.Write(.UrlPrintPreview(Context.Request.Url.Host, "", ""))
                    End With
                    br.Dispose()
                    br = Nothing
                Case CSSToolbarItem.tidPropose
                    InsertUpdate(True)
                Case CSSToolbarItem.tidValidation
                    Dim comm As New Common.BussinessRules.CommonCode
                    With comm
                        .Code = "DIR"
                        .GroupCode = "Direktur"
                        .SelectOne()
                        If .Value = Me.LoggedOnUserID Then
                            UpdateValidasi(True)
                        Else
                            Throw New Exception("Validasi hanya dapat dilakukan oleh Direktur")
                            Exit Sub
                        End If
                    End With
                    comm.Dispose()
                    comm = Nothing
            End Select
        End Sub
#End Region

#Region " Private Functions "
        Private Function ReadQueryString() As Boolean

        End Function

        Private Sub prepareDDL()
            commonFunction.SetDDL_Table(ddlMonth, "MonthInYear", String.Empty, False)
        End Sub

        Private Sub PrepareScreen()
            txtYear.Text = Date.Today.Year.ToString.Trim
            ddlMonth.SelectedValue = Date.Today.Month.ToString.Trim
            lblPageTitle.Text = "Checklist Infrastruktur"
            GetDateInMonth()
            lblDayOfWeekSelectedDate.Text = Date.Today.DayOfWeek.ToString + ", "
            lblSelectedDate.Text = Format(Date.Today, commonFunction.FORMAT_DATE)
            Open()
        End Sub

        Private Sub PrepareScreenAfterSubmit()
            Open()
        End Sub

        Private Sub GetDateInMonth()
            Dim oPU As New Common.BussinessRules.Utility
            grdDateInMonth.DataSource = oPU.GetDateInMonthCheckListInfrastruktur(CInt(txtYear.Text.Trim), CInt(ddlMonth.SelectedValue.Trim))
            grdDateInMonth.DataBind()
            oPU.Dispose()
            oPU = Nothing
        End Sub

        Private Sub UpdateViewGrid()
            Dim oChecklistDt As New Common.BussinessRules.ChecklistInfrastruktur
            oChecklistDt.Tanggal = CDate(lblSelectedDate.Text)
            grdCheck.DataSource = oChecklistDt.SelectOne
            grdCheck.DataBind()
            oChecklistDt.Dispose()
            oChecklistDt = Nothing
        End Sub
#End Region

#Region " C,R,U,D "
        Private Sub InsertUpdate(ByRef _isApprove As Boolean)
            Page.Validate()
            If Not Page.IsValid Then Exit Sub
            Dim oChecklist As New Common.BussinessRules.ChecklistInfrastruktur
            Dim isNew As Boolean = True
            Dim gitm As DataGridItem
            For Each gitm In grdCheck.Items
                Dim _pilih As CheckBox = CType(gitm.FindControl("_chkPilih"), CheckBox)
                Dim _kode As Label = CType(gitm.FindControl("txtCode"), Label)
                Dim _keterangan As Label = CType(gitm.FindControl("txtKeterangan"), Label)
                Dim _Status As Label = CType(gitm.FindControl("txtStatus"), Label)
                Dim _catatan As TextBox = CType(gitm.FindControl("txtCatatan"), TextBox)

                Dim oCl As New Common.BussinessRules.ChecklistInfrastruktur
                oCl.Kode = _kode.Text.Trim
                oCl.Tanggal = CDate(lblSelectedDate.Text.Trim)
                If oCl.SelectbyCode.Rows.Count > 0 Then
                    isNew = False
                Else
                    isNew = True
                End If
                oCl.Dispose()
                oCl = Nothing

                With oChecklist
                    .Kode = _kode.Text.Trim
                    .Tanggal = CDate(lblSelectedDate.Text.Trim)
                    .Keterangan = _keterangan.Text.Trim
                    .isCheck = _pilih.Checked
                    .Catatan = _catatan.Text.Trim
                    .isPropose = _isApprove
                    .User = Me.LoggedOnUserID.Trim

                    If isNew Then
                        .Insert()
                    Else
                        .Update()
                    End If
                End With
            Next
            oChecklist.Dispose()
            oChecklist = Nothing
            Open()
        End Sub

        Private Sub UpdateValidasi(ByVal _valid As Boolean)
            Page.Validate()
            If Not Page.IsValid Then Exit Sub
            Dim oChecklist As New Common.BussinessRules.ChecklistInfrastruktur
            With oChecklist
                .isApprove = _valid
                .User = Me.LoggedOnUserID.Trim
                .UpdateValidasi(txtYear.Text.Trim, ddlMonth.SelectedValue.Trim)
            End With
            oChecklist.Dispose()
            oChecklist = Nothing
            Open()
        End Sub

        Private Sub Open()
            Dim oChecklist As New Common.BussinessRules.ChecklistInfrastruktur
            Dim isApprove As Boolean = False
            With oChecklist
                .Tanggal = CDate(lblSelectedDate.Text.Trim)
                If .SelectOne.Rows.Count > 0 Then
                    isApprove = .isApprove
                Else
                    isApprove = False
                End If
                If .isPropose = True And isApprove = True And .isValidation = True Then
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidSave) = False
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidVoid) = True
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidApprove) = False
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidValidation) = False
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidPropose) = False
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidPrint) = True
                ElseIf .isPropose = True And isApprove = True And .isValidation = False Then
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidSave) = False
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidVoid) = True
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidApprove) = False
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidValidation) = True
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidPropose) = False
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidPrint) = True
                ElseIf .isPropose = True And isApprove = False And .isValidation = False Then
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidSave) = False
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidVoid) = True
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidApprove) = True
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidValidation) = False
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidPropose) = False
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidPrint) = False
                Else
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidSave) = True
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidVoid) = True
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidApprove) = False
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidValidation) = False
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidPropose) = True
                    CSSToolbar.VisibleButton(CSSToolbarItem.tidPrint) = False
                End If
            End With
            oChecklist.Dispose()
            oChecklist = Nothing
            UpdateViewGrid()
            GetDateInMonth()
        End Sub

        Private Sub Delete()
            Dim oChecklist As New Common.BussinessRules.ChecklistInfrastruktur
            With oChecklist
                .User = Me.LoggedOnUserID.Trim
                .Tanggal = CDate(lblSelectedDate.Text.Trim)
                .Delete()
            End With
            oChecklist.Dispose()
            oChecklist = Nothing
            Open()
        End Sub
#End Region

    End Class

End Namespace