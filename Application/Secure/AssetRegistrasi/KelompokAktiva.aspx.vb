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
    Public Class KelompokAktiva
        Inherits PageBase

#Region " Private Declarations "
        '//add row
        Protected WithEvents txtKodeKelompok As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNamaKelompok As System.Web.UI.WebControls.TextBox
        Protected WithEvents cboxAktif As System.Web.UI.WebControls.CheckBox
        Protected WithEvents btnSave As System.Web.UI.WebControls.Button
        Protected WithEvents btnDone As System.Web.UI.WebControls.Button
        Protected WithEvents btnDelete As System.Web.UI.WebControls.Button
        Protected WithEvents rfvKodeBuku As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents rfvNamaBuku As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents ValidationSummary As System.Web.UI.WebControls.ValidationSummary
        Protected WithEvents panelAddNewRow As System.Web.UI.WebControls.Panel
        Protected WithEvents panelGridKelompokFA As System.Web.UI.WebControls.Panel
        Protected WithEvents lbtnKodeKelompokFa As System.Web.UI.WebControls.LinkButton
        '//grid
        Protected WithEvents gridKelompokFA As System.Web.UI.WebControls.DataGrid

        Private MODULE_ID As String = "97153"
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

#Region " Operation : Open, Save, Update, Delete"
        Private Function OpenKelompokFa(Optional ByVal KdKelompok As String = Nothing) As BussinessRules.FA.KelompokFa
            Dim ObjKlpk As BussinessRules.FA.KelompokFa = New BussinessRules.FA.KelompokFa
            If Not KdKelompok Is Nothing Then
                ObjKlpk.KdKelompokAktiva = New SqlString(KdKelompok.Trim)
                ObjKlpk.SelectOne(BussinessRules.QISRecStatus.CurrentRecord)
            End If
            Return ObjKlpk
        End Function

        Private Sub SetKelompokFaToUI(ByVal ObjKlpFA As BussinessRules.FA.KelompokFa)
            txtKodeKelompok.Text = ObjKlpFA.KdKelompokAktiva.Value.Trim
            txtNamaKelompok.Text = ObjKlpFA.NmKelompokAktiva.Value.Trim

            Try
                cboxAktif.Checked = ProcessNull.GetBoolean(ObjKlpFA.Aktif.Value)
            Catch ex As Exception
                cboxAktif.Checked = True
            End Try
        End Sub

        Private Function SaveKelompokFa() As Boolean
            Dim ObjKlpk As BussinessRules.FA.KelompokFa = New BussinessRules.FA.KelompokFa

            With ObjKlpk
                .KdKelompokAktiva = New SqlString(txtKodeKelompok.Text.Trim)
                Dim IsNew As Boolean = .SelectOne(BussinessRules.QISRecStatus.CurrentRecord).Rows.Count < 1

                .NmKelompokAktiva = New SqlString(txtNamaKelompok.Text.Trim)
                .Aktif = New SqlBoolean(cboxAktif.Checked)
                .Usrupdate = New SqlString(MyBase.LoggedOnUserID)
                .Tglupdate = New SqlDateTime(Date.Now)
                If IsNew Then
                    .Usrinsert = New SqlString(MyBase.LoggedOnUserID)
                    .Tglinsert = New SqlDateTime(Date.Now)
                    SaveKelompokFa = .Insert()
                Else
                    SaveKelompokFa = .Update()
                End If
            End With
        End Function

        Private Function DeleteKelompokFa(ByVal KdKelompok As String)
            Dim ObjKlpk As BussinessRules.FA.KelompokFa = New BussinessRules.FA.KelompokFa
            ObjKlpk.KdKelompokAktiva = New SqlString(KdKelompok.Trim)
            Return ObjKlpk.Delete()
        End Function
#End Region

#Region " Additional Functions "
        Private Sub prepareScreen()
            txtKodeKelompok.Text = String.Empty
            txtNamaKelompok.Text = String.Empty
            cboxAktif.Checked = True

            UpdateViewGrid()
        End Sub

        Private Sub UpdateViewGrid()
            Dim tabel As DataTable = OpenKelompokFa.SelectAll
            gridKelompokFA.DataSource = tabel.DefaultView
            gridKelompokFA.DataBind()
        End Sub
#End Region

#Region " Event Control "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            If Me.IsPostBack Then
            Else

                If Not MyBase.AllowRead(Me.MODULE_ID) Then
                    Throw New Exception(commonFunction.MSG_ACCESS_DENIED)
                End If

                lbtnKodeKelompokFa.Attributes.Add("OnClick", "javascript:showDialogKelompokFa('" + txtKodeKelompok.ClientID + "');")
                txtKodeKelompok.Attributes.Add("OnKeyDown", "javascript:HookKeyCode(urlbKelompokFa,'','" + txtKodeKelompok.ClientID + "','');")

                btnDelete.Attributes.Add("OnClick", "javascript:return dlgDeleteRecordInGrid();")
                btnSave.Attributes.Add("OnClick", "javascript:return dlgSaveData();")

                commonFunction.ShowPanel(panelAddNewRow, False)

                UpdateViewGrid()

                DataBind()
            End If
        End Sub

        Private Sub txtKodeKelompok_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtKodeKelompok.TextChanged
            SetKelompokFaToUI(OpenKelompokFa(txtKodeKelompok.Text))
            commonFunction.Focus(Me, txtNamaKelompok.ClientID)
        End Sub

        Private Sub gridKelompokFA_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles gridKelompokFA.ItemCommand
            Select Case e.CommandName
                Case "_AddNewRow"
                    commonFunction.ShowPanel(panelAddNewRow, True)
                    prepareScreen()
                Case "Edit"
                    commonFunction.ShowPanel(panelAddNewRow, True)
                    Dim _lblKodeKelompokFa As Label = CType(e.Item.FindControl("_lblKodeKelompokFa"), Label)
                    txtKodeKelompok.Text = _lblKodeKelompokFa.Text.Trim
                    txtKodeKelompok_TextChanged(Nothing, Nothing)
            End Select
        End Sub

        Private Sub btn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click, btnDone.Click, btnDelete.Click
            Select Case CType(sender, Button).ID
                Case btnSave.ID
                    Page.Validate()
                    If Not Page.IsValid Then Return
                    SaveKelompokFa()
                    prepareScreen()
                Case btnDone.ID
                    commonFunction.ShowPanel(panelAddNewRow, False)
                Case btnDelete.ID
                    DeleteKelompokFa(txtKodeKelompok.Text)
                    prepareScreen()
            End Select
        End Sub
#End Region

    End Class
End Namespace


