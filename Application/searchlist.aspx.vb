﻿Option Strict On
Option Explicit On

Imports System
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlTypes
Imports Microsoft.VisualBasic

Imports QIS
Imports QIS.Web
Imports QIS.Common
Imports QIS.SystemFramework

Namespace QIS
    Partial Public Class SearchList
        Inherits PageBase

#Region " Control Events "
        'Protected WithEvents grdSearchList As System.Web.UI.WebControls.DataGrid
        'Protected WithEvents btnApplyFilter As System.Web.UI.WebControls.Button
        'Protected WithEvents txtFilterValue As System.Web.UI.WebControls.TextBox
        'Protected WithEvents linkApplyFilter As System.Web.UI.WebControls.LinkButton
        'Protected WithEvents lblSearchCode As System.Web.UI.WebControls.Label
        'Protected WithEvents lblSearchResults As System.Web.UI.WebControls.Label
        'Protected WithEvents lblSearchProcedure As System.Web.UI.WebControls.Label
        'Protected WithEvents txtMaxRecord As System.Web.UI.WebControls.TextBox
        'Protected WithEvents litSearchList As System.Web.UI.WebControls.Literal

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Me.IsPostBack Then
            Else
                Dim fQueryStringExist As Boolean

                fQueryStringExist = ReadQueryString()

                If fQueryStringExist Then
                    prepareScreen()
                End If
            End If
        End Sub

        Private Sub grdSearchList_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdSearchList.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem
                    Dim _drv As DataRowView = CType(e.Item.DataItem, DataRowView)
                    If _drv Is Nothing Then Exit Sub

                    Dim s1 As String = CType(_drv.Row.Item(0), String).Trim

                    Dim a As String = "'"

                    s1 = Replace(s1, "'", " ")
                    s1 = Replace(s1, """", " ")

                    e.Item.Attributes.Add("onmouseover", "javascript:this.style.backgroundColor='#ffd27a';this.style.Color='#000000';this.focus;this.style.cursor='pointer';")
                    If e.Item.ItemType = ListItemType.Item Then
                        e.Item.Attributes.Add("onmouseout", "javascript:this.style.backgroundColor='#eeeeee';this.style.Color='#000000'")
                    Else
                        e.Item.Attributes.Add("onmouseout", "javascript:this.style.backgroundColor='#dddddd';this.style.Color='#000000'")
                    End If
                    e.Item.Attributes.Add("onclick", "closeWindowPostBackReturnValue('" + s1 + "', '" + Trim(Request.QueryString("ctrlID")) + "')")
            End Select
        End Sub

        Private Sub btnApplyFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApplyFilter.Click
            UpdateViewGrid(txtFilterValue.Text.Trim, Trim(Request.QueryString("param").ToString))
        End Sub

        Protected Sub linkApplyFilter_Click(ByVal sender As Object, ByVal e As EventArgs) Handles linkApplyFilter.Click
            btnApplyFilter_Click(Nothing, Nothing)
        End Sub
#End Region

#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
            Dim b As Boolean = (Len(Trim(Request.QueryString("cd"))) > 0) And (Len(Trim(Request.QueryString("ctrlID"))) > 0)
            Return b
        End Function

        Private Sub prepareScreen()
            txtFilterValue.Text = CType(IIf(Trim(Request.QueryString("fvalue")) = Nothing, "", Trim(Request.QueryString("fvalue"))), String)
            lblSearchCode.Text = Trim(Request.QueryString("cd"))
            _OpenSearch()
            UpdateViewGrid(txtFilterValue.Text.Trim, Trim(Request.QueryString("param").ToString))
        End Sub

        Private Sub UpdateViewGrid(Optional ByVal FilterValue As String = "", Optional ByVal Param As String = "")
            Dim br As New Common.BussinessRules.SearchList
            Param = CType(IIf(Param.Trim = Nothing, "", Param.Trim.Replace(commonFunction.EqualSL, "=")), String)
            Param = CType(IIf(Param.Trim = Nothing, "", Param.Trim.Replace(commonFunction.QuoteSL, "'")), String)

            If IsNumeric(txtMaxRecord.Text.Trim) Then
                If CInt(txtMaxRecord.Text.Trim) <= 0 Then
                    txtMaxRecord.Text = "650"
                Else
                    txtMaxRecord.Text = CStr(CInt(txtMaxRecord.Text.Trim))
                End If
            Else
                txtMaxRecord.Text = "650"
            End If

            br.SearchID = CStr(Trim(Request.QueryString("cd")))
            grdSearchList.DataSource = br.SelectSearchList(CInt(txtMaxRecord.Text), Param.Trim, FilterValue.Trim).DefaultView
            grdSearchList.DataBind()

            '// display record count
            lblSearchResults.Text = grdSearchList.Items.Count.ToString.Trim

            br = Nothing
        End Sub
#End Region


#Region " Main Function: Open, Save Delete Data "
        Private Sub _OpenSearch()
            If Len(Trim(Request.QueryString("cd"))) = 0 Then Exit Sub

            Dim br As New Common.BussinessRules.SearchList

            With br
                .SearchID = CStr(Trim(Request.QueryString("cd")))

                If (.SelectOne.Rows.Count > 0) Then
                    litSearchList.Text = .SearchCaption.Trim
                    lblSearchProcedure.Text = .SearchProcedure.Trim
                Else
                    litSearchList.Text = String.Empty
                    lblSearchProcedure.Text = String.Empty
                End If
            End With

            br = Nothing
        End Sub
#End Region

    End Class
End Namespace
