Option Strict Off
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

Namespace QIS.Web.Secure.Master
    Public Class InfoService
        Inherits PageBase 'Aktiva

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        '<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        'End Sub
        Protected WithEvents lbtnAktivaTetap As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtKdAktiva As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNmAktiva As System.Web.UI.WebControls.TextBox
        Protected WithEvents gridService As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnClose As System.Web.UI.WebControls.Button
        Protected WithEvents lbtnGo As System.Web.UI.WebControls.LinkButton

        'Private MODULE_ID As String = "J022"
        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        'Private designerPlaceholderDeclaration As System.Object

        'Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        '    'CODEGEN: This method call is required by the Web Form Designer
        '    'Do not modify it using the code editor.
        '    InitializeComponent()
        'End Sub

#End Region

#Region " Event Control "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            If Me.IsPostBack Then
            Else


                'If Not MyBase.AllowRead(Me.MODULE_ID_) Then
                '    Throw New Exception(commonFunction.MSG_ACCESS_DENIED)
                'End If

                Dim fQueryStringExist As Boolean
                txtKdAktiva.Text = Request.QueryString("fa")
                txtKdAktiva_TextChanged(txtKdAktiva, Nothing)
                RefreshGridView()

                lbtnAktivaTetap.Attributes.Add("OnClick", "javascript:showDialogAktiva('" + txtKdAktiva.ClientID + "');")
                txtKdAktiva.Attributes.Add("OnKeyDown", "javascript:HookKeyCode(urlbAktiva,'','" + txtKdAktiva.ClientID + "','');")
                btnClose.Attributes.Add("OnClick", "javascript:self.close()")
            End If
        End Sub

        Private Sub lbtnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtnGo.Click
            txtKdAktiva_TextChanged(sender, Nothing)
        End Sub

        Private Sub txtKdAktiva_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtKdAktiva.TextChanged
            txtNmAktiva.Text = OpenNamaAktiva(txtKdAktiva.Text.Trim)
            RefreshGridView()
        End Sub
#End Region

#Region " Open, Save "
        Private Function OpenNamaAktiva(ByVal KdAktiva As String) As String
            Dim Asset As New BussinessRules.FA.aktiva
            Asset.KdAktiva = New SqlString(KdAktiva)
            If Asset.SelectOne().Rows.Count > 0 Then
                Return Asset.NmAktiva.Value
            Else
                Return Nothing
            End If
        End Function

        Private Function OpenServiceAktiva(ByVal KdAktiva As String) As DataTable
            Dim service As New BussinessRules.LG.servicehd
            Return service.SelectByAktiva(KdAktiva.Trim)
        End Function

        Private Sub RefreshGridView()
            Session("dtv") = OpenServiceAktiva(txtKdAktiva.Text.Trim).DefaultView
            gridService.DataSource = CType(Session("dtv"), DataView)
            gridService.DataBind()
        End Sub
#End Region


        Private Sub InitializeComponent()

        End Sub
    End Class
End Namespace


