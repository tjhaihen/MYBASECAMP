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
    Public Class Hardening
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

                lbtNoHardening.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("HDN", txtNoHardening.ClientID))
                txtNoHardening.Attributes.Add("onKeyDown", commonFunction.JSOpenSearchListWind("HDN", txtNoHardening.ClientID, True))
            End If
        End Sub
#End Region

#Region " Support functions for navigation bar (Controls) "
        Private Sub setToolbarVisibleButton()
            With CSSToolbar
                .VisibleButton(CSSToolbarItem.tidNew) = True
                .VisibleButton(CSSToolbarItem.tidSave) = True
                .VisibleButton(CSSToolbarItem.tidDelete) = False
                .VisibleButton(CSSToolbarItem.tidApprove) = False
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidPrint) = False
                .VisibleButton(CSSToolbarItem.tidPrevious) = False
                .VisibleButton(CSSToolbarItem.tidNext) = False
                .VisibleButton(CSSToolbarItem.tidRefresh) = False
                .VisibleButton(CSSToolbarItem.tidDownload) = False
                .VisibleButton(CSSToolbarItem.tidPropose) = True
                .VisibleButton(CSSToolbarItem.tidValidation) = False
            End With
        End Sub

        Private Sub mdlToolbar_commandBarClick(ByVal sender As Object, ByVal e As CSSToolbarItem) Handles CSSToolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidNew
                    setToolbarVisibleButton()
                    prepareDDL()
                    PrepareScreen()
                Case CSSToolbarItem.tidSave
                    Save(False)
                Case CSSToolbarItem.tidPropose
                    Save(True)
                Case CSSToolbarItem.tidVoid
                    Void()
                Case CSSToolbarItem.tidApprove
                    Dim comm As New Common.BussinessRules.CommonCode
                    With comm
                        .Code = "MGRITS"
                        .GroupCode = "ManagerITS"
                        .SelectOne()
                        If .Value = Me.LoggedOnUserID Then
                            Approve()
                        Else
                            Throw New Exception("Approval hanya dapat dilakukan oleh Manager ITS")
                            Exit Sub
                        End If
                    End With
                Case CSSToolbarItem.tidPrint
                    Dim br As New Common.BussinessRules.MyReport
                    With br
                        .ReportCode = "9002"
                        .AddParameters(txtNoHardening.Text.Trim)
                        Response.Write(.UrlPrintPreview(Context.Request.Url.Host, "", ""))
                    End With
                    br.Dispose()
                    br = Nothing
            End Select
        End Sub
#End Region

#Region " Private Functions "
        Private Function ReadQueryString() As Boolean

        End Function

        Private Sub prepareDDL()
            commonFunction.SetDDL_Table(ddlPerangkat, "CommonCodeCode", Common.Constants.GroupCode.PERANGKAT_SCode, False)
            commonFunction.SetDDL_Table(ddlPengguna, "UserActive", "", True)
        End Sub

        Private Sub PrepareScreen()
            txtNoHardening.Text = String.Empty
            txtNoAsset.Text = String.Empty
            UpdateViewGrid()
        End Sub

        Private Sub UpdateViewGrid()
            Dim oHarden As New Common.BussinessRules.Hardening
            oHarden.NoHardening = txtNoHardening.Text.Trim
            grdHardening.DataSource = oHarden.SelectOne()
            grdHardening.DataBind()
            oHarden.Dispose()
            oHarden = Nothing
        End Sub
#End Region

#Region " C,R,U,D "
        Private Sub Save(ByVal _approve As Boolean)
            If txtNoAsset.Text = String.Empty Then
                Throw New Exception("No. Aset tidak boleh kosong")
            End If

            Dim oHarden As New Common.BussinessRules.Hardening
            Dim fnotnew As Boolean = False
            Dim max As String = String.Empty

            With oHarden
                .NoHardening = txtNoHardening.Text.Trim
                fnotnew = (.SelectbyNoHD.Rows.Count > 0)
                If Len(txtNoHardening.Text.Trim) = 0 Then
                    max = .NewTransactionNumber(Date.Now).Value
                    txtNoHardening.Text = Trim(max)
                    .NoHardening = txtNoHardening.Text.Trim
                Else
                    .NoHardening = txtNoHardening.Text.Trim
                End If
                .NoAset = txtNoAsset.Text.Trim
                .UserPengguna = ddlPengguna.SelectedValue.Trim
                .KodePerangkat = ddlPerangkat.SelectedValue.Trim
                .isPropose = _approve
                .isApprove = False
                .Catatan = txtcatatan.Text.Trim
                .User = Me.LoggedOnUserID
                If fnotnew Then
                    .Update()
                Else
                    .Insert()
                End If
            End With
            oHarden.Dispose()
            oHarden = Nothing
            UpdateDetil()
        End Sub
        Private Sub Open()
            Dim oHarden As New Common.BussinessRules.Hardening
            With oHarden
                .NoHardening = txtNoHardening.Text.Trim
                If .SelectbyNoHD.Rows.Count > 0 Then
                    txtNoAsset.Text = .NoAset.Trim
                    commonFunction.SelectListItem(ddlPengguna, .UserPengguna.Trim)
                    commonFunction.SelectListItem(ddlPerangkat, .KodePerangkat.Trim)
                    txtcatatan.Text = .Catatan.Trim
                    If .isApprove = True And .isPropose = True Then
                        CSSToolbar.VisibleButton(CSSToolbarItem.tidSave) = False
                        CSSToolbar.VisibleButton(CSSToolbarItem.tidVoid) = True
                        CSSToolbar.VisibleButton(CSSToolbarItem.tidApprove) = False
                        CSSToolbar.VisibleButton(CSSToolbarItem.tidPrint) = True
                        CSSToolbar.VisibleButton(CSSToolbarItem.tidPropose) = False
                    ElseIf .isApprove = False And .isPropose = True Then
                        CSSToolbar.VisibleButton(CSSToolbarItem.tidSave) = False
                        CSSToolbar.VisibleButton(CSSToolbarItem.tidVoid) = True
                        CSSToolbar.VisibleButton(CSSToolbarItem.tidApprove) = True
                        CSSToolbar.VisibleButton(CSSToolbarItem.tidPrint) = False
                        CSSToolbar.VisibleButton(CSSToolbarItem.tidPropose) = False
                    Else
                        CSSToolbar.VisibleButton(CSSToolbarItem.tidSave) = True
                        CSSToolbar.VisibleButton(CSSToolbarItem.tidVoid) = False
                        CSSToolbar.VisibleButton(CSSToolbarItem.tidApprove) = False
                        CSSToolbar.VisibleButton(CSSToolbarItem.tidPrint) = False
                        CSSToolbar.VisibleButton(CSSToolbarItem.tidPropose) = True
                    End If
                    UpdateViewGrid()
                Else
                    PrepareScreen()
                    prepareDDL()
                    setToolbarVisibleButton()
                End If
            End With
            oHarden.Dispose()
            oHarden = Nothing
        End Sub
        Private Sub UpdateDetil()
            Dim rowcount As Integer = 0
            Dim fnew As Boolean = False
            Dim oHarden As New Common.BussinessRules.Hardening
            Dim gitm As DataGridItem
            For Each gitm In grdHardening.Items
                Dim _code As Label = CType(gitm.FindControl("txtCode"), Label)
                'Dim _item As Label = CType(gitm.FindControl("txtItem"), Label)
                'Dim _standar As Label = CType(gitm.FindControl("txtStandard"), Label)
                Dim _hasil As CheckBox = CType(gitm.FindControl("chkHasil"), CheckBox)
                Dim _catatan As TextBox = CType(gitm.FindControl("txtCatatan"), TextBox)
                With oHarden
                    .NoHardening = txtNoHardening.Text.Trim
                    .Kode = _code.Text.Trim
                    fnew = (.SelectOneByNoDT.Rows.Count > 0)
                    .isCheck = _hasil.Checked
                    .Catatan = _catatan.Text.Trim
                    If fnew Then
                        .UpdateDT()
                    Else
                        .InsertDT()
                    End If
                End With
            Next
            oHarden.Dispose()
            oHarden = Nothing
            Open()
        End Sub
        Private Sub Void()
            Dim oHarden As New Common.BussinessRules.Hardening

            With oHarden
                .NoHardening = txtNoHardening.Text.Trim
                .SelectOne()
                .User = Me.LoggedOnUserID.Trim
                If .isApprove = True And .isPropose = True Then
                    .isApprove = False
                    .UpdateApprove()
                Else
                    .Delete()
                End If
            End With
            oHarden.Dispose()
            oHarden = Nothing
            Open()
        End Sub
        Private Sub Approve()
            Dim oHarden As New Common.BussinessRules.Hardening

            With oHarden
                .NoHardening = txtNoHardening.Text.Trim
                .User = Me.LoggedOnUserID.Trim
                .isApprove = True
                .UpdateApprove()
            End With
            oHarden.Dispose()
            oHarden = Nothing
            Open()
        End Sub
#End Region

        Private Sub txtNoHardening_TextChanged(sender As Object, e As System.EventArgs) Handles txtNoHardening.TextChanged
            Open()
        End Sub
    End Class

End Namespace