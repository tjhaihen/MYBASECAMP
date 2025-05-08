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


Namespace QIS.Web.Secure.Master.fa

    Public Class SelItemLG_BatalAsset
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
        Protected WithEvents CSSToolbar As CSSToolbar
        Protected WithEvents gridInformasiItem As System.Web.UI.WebControls.DataGrid
        Protected WithEvents lblTotal As System.Web.UI.WebControls.Label
        Protected WithEvents ValidationSummary As System.Web.UI.WebControls.ValidationSummary
        Protected WithEvents lbtnRefresh As System.Web.UI.WebControls.LinkButton

        Private MODULE_ID As String = "J019"

#End Region


#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim txtScript As New System.Text.StringBuilder

            txtScript.Append("<script language=JavaScript> function openEntriTransaksi(scounter){" + Environment.NewLine)
            txtScript.Append("var url = '" + MyBase.UrlBase + "/secure/master/fa/Assets/Aktiva.aspx" + "?i='+scounter;" + Environment.NewLine)
            txtScript.Append("window.location.href = url;}<")
            txtScript.Append("/")
            txtScript.Append("script>")

            If Not Page.IsClientScriptBlockRegistered("OpenTransaksi") Then
                Page.RegisterClientScriptBlock("OpenTransaksi", txtScript.ToString)
            End If

            If Me.IsPostBack Then
            Else
                Dim fQueryStringExist As Boolean

                If Not MyBase.AllowRead(Me.MODULE_ID) Then
                    Throw New Exception(commonFunction.MSG_ACCESS_DENIED)
                End If

                fQueryStringExist = ReadQueryString()

                If fQueryStringExist Then

                Else
                    prepareScreen()
                End If

                _UpdateGridView()

                DataBind()
            End If
        End Sub
#End Region


#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean

        End Function

        Private Sub prepareScreen()
            lblTotal.Text = "0"

        End Sub

        Private Sub gridInformasiItem_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles gridInformasiItem.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.AlternatingItem, ListItemType.Item
                    ' // Dialog save or not when the imagebutton clicked by user ..
                    Dim _ImageButton As ImageButton = CType(e.Item.FindControl("__ibtnDelete"), ImageButton)

                    If Not _ImageButton Is Nothing Then
                        _ImageButton.Attributes.Add("OnClick", "javascript:return dlgDeleteRecordInGrid();")
                    End If

            End Select
        End Sub

        Private Sub gridInformasiItem_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles gridInformasiItem.ItemCommand
            Select Case e.CommandName
               
                Case "__delete"

                    Dim br As New BussinessRules.LG.penerimaanDT
                    Dim counter As String
                    With br
                        counter = CType(gridInformasiItem.DataKeys(e.Item.ItemIndex), Guid).ToString
                        .counter = New SqlGuid(counter)
                        If (.SelectOneItemLG.Rows.Count > 0) Then
                            If .updateItemJadiNonAsset() = True Then
                                commonFunction.MsgBox(Me, "Item telah di non assetkan.")
                            End If
                        Else
                            commonFunction.MsgBox(Me, "Maaf, Item ini tidak terdaftar sebagai asset")
                        End If
                    End With

                    _UpdateGridView()

                    br.Dispose()
                    br = Nothing

            End Select
        End Sub

#End Region


#Region " Main Function: Open, Save Delete Data "
        Private Sub _UpdateGridView()
            Dim osv As New Common.SetVar

            Dim olg As New BussinessRules.LG.penerimaanDT
            Dim dt As DataTable
            Dim totPasien As Integer

            dt = olg.SelectItemLgHaveNoKdAktiva

            totPasien = dt.Rows.Count
            lblTotal.Text = totPasien.ToString

            gridInformasiItem.DataSource = dt.DefaultView
            gridInformasiItem.DataBind()

            olg.Dispose()
            olg = Nothing

        End Sub
#End Region


        Private Sub lbtnRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnRefresh.Click
            _UpdateGridView()
        End Sub

        
    End Class

End Namespace