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
Imports Telerik.Web.UI
Imports QIS.Common

Namespace QIS.Web.Secure
    Public Class HasilLab
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Protected WithEvents gridDetail As DataGrid
        Dim strNoreg As String
        Dim strNoLab As String

#End Region

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here

            If Me.IsPostBack Then
            Else
                Dim fQueryStringExist As Boolean
                fQueryStringExist = ReadQueryString()
                If fQueryStringExist Then
                    Preparescreen()
                End If
            End If

        End Sub
#End Region

#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
            strNoreg = Request.QueryString("Noreg")
            strNoLab = Request.QueryString("Nolab")

            Return Len(strNoreg.Trim) > 0
        End Function

        Private Sub Preparescreen()
            UpdateViewGrid()
        End Sub
#End Region

#Region " Main Function: Open, Save Delete Data "
#End Region

#Region "Data Grid"

        Private Sub UpdateViewGrid()

            Dim dt As DataTable
            Dim obj As New Common.BussinessRules.Laboratorium
            obj.Noreg = New SqlString(strNoreg.Trim)
            obj.NoLab = New SqlString(strNoLab.Trim)

            dt = obj.SelectForHasil()

            gridDetail.DataSource = dt.DefaultView
            gridDetail.DataBind()

            Session("DictatedDV") = dt.DefaultView
            obj.Dispose()
            obj = Nothing

        End Sub

#End Region

#Region "Object Function"
#End Region

        Private Sub grdTempResult_SortCommand(ByVal source As Object, ByVal e As DataGridSortCommandEventArgs) Handles gridDetail.SortCommand
            Dim sortExpression As String = CType(Session("SortExp"), String)
            Dim sortDirection As String = CType(Session("SortDir"), String)

            If (sortExpression <> e.SortExpression) Then

                sortExpression = e.SortExpression
                sortDirection = "asc"
            Else
                If (sortDirection = "asc") Then
                    sortDirection = "desc"
                Else
                    sortDirection = "asc"
                End If
            End If

            Session("SortExp") = sortExpression
            Session("SortDir") = sortDirection
            BindDataGrid(sortExpression + " " + sortDirection)
        End Sub

        Private Sub BindDataGrid(ByVal sortExpression As String)
            '// reset the dataview, else it will be undefined value!
            Dim dv As DataView = CType(Session("DictatedDV"), DataView)
            If (sortExpression.Length > 0) Then
                dv.Sort = sortExpression
                '// save the dataview in stateless environment
                Session("DictatedDV") = dv
            End If
            gridDetail.DataSource = dv
            gridDetail.DataBind()
        End Sub

    End Class

End Namespace
