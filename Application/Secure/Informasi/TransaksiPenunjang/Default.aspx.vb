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

    Public Class TransaksiPenunjang
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Protected WithEvents ddlPenunjang As System.Web.UI.WebControls.DropDownList
        Protected WithEvents lblNamaPasien As System.Web.UI.WebControls.Label
        Protected WithEvents txtNomorRegistrasi As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkAll As System.Web.UI.WebControls.CheckBox
        Protected WithEvents lbtnRefresh As System.Web.UI.WebControls.LinkButton
        Protected WithEvents gridDetailTransaksi As System.Web.UI.WebControls.DataGrid
        Protected WithEvents ValidationSummary As System.Web.UI.WebControls.ValidationSummary
        Protected WithEvents calTglAwal As QIS.Web.Calendar
        Protected WithEvents calTglAkhir As QIS.Web.Calendar

        Dim strNoreg As String

#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Me.IsPostBack Then
            Else
                Dim fQueryStringExist As Boolean
                fQueryStringExist = ReadQueryString()
                If fQueryStringExist Then
                    txtNomorRegistrasi.Text = strNoreg.Trim
                    Methods.SetDropDownListOtherDiagnosticSupport(ddlPenunjang)
                    prepareScreen()
                    _OpenPasien()
                    UpdateViewGrid()
                End If
                DataBind()
            End If
        End Sub
#End Region

#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
            strNoreg = Request.QueryString("i")

            Return Len(strNoreg.Trim) > 0
        End Function

        Private Sub prepareScreen()
            'calTglAwal.selectedDate = Date.Now
            'calTglAkhir.selectedDate = Date.Now
            'chkAll.Checked = False
        End Sub

        Private Sub UpdateViewGrid()
            Dim brPenunjang As New Common.BussinessRules.PenunjangMedis
            brPenunjang.Noreg = New SqlString(txtNomorRegistrasi.Text.Trim)
            brPenunjang.KdPenunjangMedis = New SqlString(ddlPenunjang.SelectedItem.Value.Trim)
            'brPenunjang.TglAwal = New SqlDateTime(calTglAwal.selectedDate)
            'brPenunjang.TglAkhir = New SqlDateTime(calTglAkhir.selectedDate)
            'brPenunjang.All = New SqlBoolean(chkAll.Checked)

            Dim dt As DataTable
            dt = brPenunjang.SelectForDetilTransaksi()

            gridDetailTransaksi.DataSource = dt.DefaultView
            gridDetailTransaksi.DataBind()
        End Sub

        Private Sub _OpenPasien()
            Dim brReg As New Common.BussinessRules.Registrasi
            brReg.NoReg = New SqlString(txtNomorRegistrasi.Text.Trim)
            If brReg.SelectOne.Rows.Count > 0 Then
                Dim brPasien As New Common.BussinessRules.Pasien
                brPasien.Norm = New SqlString(brReg.NoRM.Value.Trim)
                If brPasien.SelectOne.Rows.Count > 0 Then
                    lblNamaPasien.Text = brPasien.Nama.Value.Trim + " " + brPasien.Marga.Value.Trim
                End If
            End If
        End Sub
#End Region

        Private Sub lbtnRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnRefresh.Click
            UpdateViewGrid()
        End Sub

        Private Sub ddlPenunjang_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPenunjang.SelectedIndexChanged
            UpdateViewGrid()
        End Sub

        Private Sub gridDetailTransaksi_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles gridDetailTransaksi.ItemCommand
            Select Case e.CommandName
                Case "__PrintHasil"
                    Dim language As String = "ind"
                    Dim _lblNobukti As Label = CType(e.Item.FindControl("_lblNoBukti"), Label)
                    Response.Write("<script language=javascript>window.open('" + PageBase.UrlBase + "/secure/informasi/TransaksiPenunjang/Hasil.aspx/?noreg=" + txtNomorRegistrasi.Text.Trim + "&nobukti=" + _lblNobukti.Text.Trim + "','width=900, height=550, status=no,resizable=yes,toolbar=no,menubar=no,location=no;')</script>")
            End Select
        End Sub

    End Class
End Namespace