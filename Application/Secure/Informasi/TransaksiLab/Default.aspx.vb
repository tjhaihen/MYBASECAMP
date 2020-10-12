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
    Public Class TransaksiLab
        Inherits PageBase

#Region "Private Variables (web form designer generated code and user code)"
        Dim strNoreg As String
#End Region

#Region "Control Events"
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Me.IsPostBack Then
            Else
                Dim fQueryStringExist As Boolean
                fQueryStringExist = ReadQueryString()
                If fQueryStringExist Then
                    txtNomorRegistrasi.Text = strNoreg.Trim
                    _OpenPasien()
                    UpdateViewGrid()
                End If
                DataBind()
            End If
        End Sub
#End Region
#Region "Additional: Private Function"
        Private Function ReadQueryString() As Boolean
            strNoreg = Request.QueryString("i")
            Return Len(strNoreg.Trim) > 0
        End Function

        Private Sub _OpenPasien()
            Dim brReg As New Common.BussinessRules.Registrasi
            brReg.NoReg = New SqlString(txtNomorRegistrasi.Text.Trim)
            If brReg.SelectOne.Rows.Count > 0 Then
                Dim brPasien As New Common.BussinessRules.Pasien
                brPasien.Norm = New SqlString(brReg.NoRM.Value.Trim)
                If brPasien.SelectOne.Rows.Count > 0 Then
                    lblNamaPasien.Text = brPasien.Nama.Value.Trim + "" + brPasien.Marga.Value.Trim
                End If
            End If
        End Sub

        Private Sub UpdateViewGrid()
            Dim brLab As New Common.BussinessRules.Laboratorium
            brLab.NoReg = New SqlString(txtNomorRegistrasi.Text.Trim)
            Dim dt As DataTable
            dt = brLab.SelectByNoreg()
            grdDetailTransaksi.DataSource = dt.DefaultView
            grdDetailTransaksi.DataBind()
        End Sub

        Private Sub grdDetailTransaksi_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdDetailTransaksi.ItemCommand
            Select Case e.CommandName
                Case "__PrintHasil"
                    Dim NoLab As Label = CType(e.Item.FindControl("_lblNoLab"), Label)
                    Response.Write("<script language=javascript>window.open('" + PageBase.UrlBase + "/secure/informasi/TransaksiLab/Hasil.aspx/?noreg=" + txtNomorRegistrasi.Text.Trim + "&nolab=" + NoLab.Text.Trim + "','width=900, height=550, status=no,resizable=yes,toolbar=no,menubar=no,location=no;')</script>")
            End Select
        End Sub
#End Region
    End Class
End Namespace
