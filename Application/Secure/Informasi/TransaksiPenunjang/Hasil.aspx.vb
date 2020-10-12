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
    Public Class Hasil
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        'Protected WithEvents pnl_1 As Panel
        'Protected WithEvents ddlPnjMedis As DropDownList
        'Protected WithEvents lbtnPelayananPnjMedis_KodePelayanan As LinkButton
        'Protected WithEvents txtPelayananPnjMedis_KodePelayanan As TextBox
        'Protected WithEvents txtPelayananPnjMedis_NamaPelayanan As TextBox

        'Protected WithEvents lbtnPelayananPnjMedis_KodeDokter As LinkButton
        'Protected WithEvents txtPelayananPnjMedis_KodeDokter As TextBox
        'Protected WithEvents txtPelayananPnjMedis_NamaDokter As TextBox

        'Protected WithEvents btnSave As Button
        'Protected WithEvents btnDone As Button
        'Protected WithEvents panelTempResultAddNewRow As Panel

        Protected WithEvents grdHasil As DataGrid
        'Protected WithEvents grdTempResult_buttonNewRow As LinkButton

        'Protected WithEvents txtKodePenunjang As TextBox
        'Protected WithEvents txtNamaPenunjang As TextBox
        'Protected WithEvents txtKodeDokter As TextBox
        'Protected WithEvents txtNamaDokter As TextBox
        'Protected WithEvents txtKodePelayanan As TextBox
        'Protected WithEvents txtNamaPelayanan As TextBox
        'Protected WithEvents lbtnKodedokter As LinkButton

        'Protected WithEvents txtCounter As TextBox
        'Protected WithEvents txtKdkls As TextBox

        'Protected WithEvents txtusr As TextBox
        'Protected WithEvents ValidationSummary As ValidationSummary
        'Protected WithEvents rfvGroupHasilPnj As RequiredFieldValidator
        'Protected WithEvents rfvResult As RequiredFieldValidator

        'Protected WithEvents ddlGroupHasilPnj As DropDownList
        'Protected WithEvents ddlGroupHasilPnjAddNewRow As DropDownList

        'Private OtorisasiPMedis As Boolean
        'Private _PnjMedis, _Layan, _KdDokter As String
        'Protected WithEvents txtPelayananPnjMedis_KodeGroup As TextBox
        'Protected WithEvents radeResult As RadEditor
        'Protected WithEvents txtResult As TextBox

        ''// add by hendy
        'Protected WithEvents rdbInd As RadioButton
        'Protected WithEvents rdbEng As RadioButton
        'Protected WithEvents pnlInd As Panel
        'Protected WithEvents pnlEng As Panel
        'Protected WithEvents txtResultEng As TextBox

        'Protected WithEvents txtResultTitle As TextBox

        'Private ModuleId As String = "53001"
        Dim strNoreg As String
        Dim strNoBukti As String

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
                    'If Not MyBase.AllowRead(Me.ModuleId) Then
                    '    Throw New Exception(commonFunction.MSG_ACCESS_DENIED)
                    'End If
                    'commonFunction.SetDropDownLisToPenunjangMedis(ddlPnjMedis, False)
                    'commonFunction.SetDropDownLisToStdData(ddlGroupHasilPnj, "MDGroupHasil")
                    'commonFunction.SetDropDownLisToStdData(ddlGroupHasilPnjAddNewRow, "MDGroupHasil")
                    'OtorisasiPMedis = AuthorizedUserForPMedis(ddlPnjMedis.SelectedItem.Value.Trim)

                    Preparescreen()
                    '_PnjMedis = ddlPnjMedis.SelectedItem.Value.Trim
                    'txtKodePelayanan.Text = _Layan.Trim
                    'txtCounter.Text = _counter.Trim
                End If
                End If

        End Sub

        'Private Sub rdbInd_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbInd.CheckedChanged
        '    rdbEng.Checked = Not rdbInd.Checked
        '    commonFunction.ShowPanel(pnlInd, rdbInd.Checked)
        '    commonFunction.ShowPanel(pnlEng, Not rdbInd.Checked)
        'End Sub

        'Private Sub rdbEng_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbEng.CheckedChanged
        '    rdbInd.Checked = Not rdbEng.Checked
        '    commonFunction.ShowPanel(pnlInd, Not rdbEng.Checked)
        '    commonFunction.ShowPanel(pnlEng, rdbEng.Checked)
        'End Sub
#End Region

#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
            strNoreg = Request.QueryString("Noreg")
            strNoBukti = Request.QueryString("Nobukti")

            Return Len(strNoreg.Trim) > 0
        End Function

        Private Sub Preparescreen()
            '    txtCounter.Text = "0"
            '    ddlGroupHasilPnj.SelectedIndex = 0
            '    txtKodePelayanan.Text = String.Empty
            '    txtNamaPelayanan.Text = String.Empty
            '    txtKodeDokter.Text = String.Empty
            '    txtNamaDokter.Text = String.Empty
            '    txtNamaPelayanan.Text = String.Empty
            '    txtKodePenunjang.Text = String.Empty
            '    txtNamaPenunjang.Text = String.Empty
            '    radeResult.Html = String.Empty
            '    txtResult.Text = String.Empty
            '    txtResultEng.Text = String.Empty
            '    txtResultTitle.Text = String.Empty

            '    commonFunction.ShowPanel(pnlEng, False)
            '    rdbInd.Checked = True
            '    rdbEng.Checked = False

            '    commonFunction.ShowPanel(panelTempResultAddNewRow, False)

            UpdateViewGrid()

        End Sub

        'Private Function AuthorizedUserForPMedis(ByVal kdpmedis As String) As Boolean
        '    Dim br As New Common.BussinessRules.User

        '    With br
        '        .UserID = MyBase.LoggedOnUserID
        '        'TODO Otorisasi User
        '        'If (.GetGudangLokasiFromUser.Rows.Count > 0) Then
        '        '    If kdpmedis = .KdPMedis.Value.Trim Then
        '        '        '// User penunjang medis tersebut, boleh akses
        '        '        OtorisasiPMedis = True
        '        '    Else
        '        '        If (.KdPMedis.Value.Trim = String.Empty) Or (.KdPMedis.IsNull = True) Then
        '        '            '// User boleh akses ke semua penunjang medis
        '        '            OtorisasiPMedis = True
        '        '        Else
        '        '            '// user hanya boleh akses ke penunjang medis yang sudah didefinisikan di "users"
        '        '            OtorisasiPMedis = False
        '        '        End If
        '        '    End If
        '        'End If
        '    End With

        '    br.Dispose()
        '    br = Nothing

        '    Return OtorisasiPMedis
        'End Function
#End Region

#Region " Main Function: Open, Save Delete Data "

        'Private Sub save()
        '    Dim brsave As New BussinessRules.TemplateResult
        '    Dim fnew As Boolean
        '    With brsave

        '        If Len(txtCounter.Text.Trim) > 0 Then
        '            .counter = New SqlDecimal(CDec(txtCounter.Text.Trim))
        '        End If

        '        fnew = CBool(.SelectOne(BussinessRules.QISRecStatus.CurrentRecord).Rows.Count)

        '        .kdPnjMedis = New SqlString(txtKodePenunjang.Text.Trim)
        '        .kdGroupHasil = New SqlString(ddlGroupHasilPnj.SelectedItem.Value.Trim)
        '        .kdLayan = New SqlString(txtKodePelayanan.Text.Trim)
        '        .kdDokter = New SqlString(txtKodeDokter.Text.Trim)
        '        .resultTitle = New SqlString(txtResultTitle.Text.Trim)
        '        .result = New SqlString(txtResult.Text.Trim)
        '        .result2 = New SqlString(txtResultEng.Text.Trim)
        '        '.result = New SqlString(radeResult.Html)
        '        .usrinsert = New SqlString(MyBase.LoggedOnUserID.Trim)

        '        If fnew Then
        '            .Update()
        '        Else
        '            .Insert()
        '        End If

        '        commonFunction.ShowPanel(panelTempResultAddNewRow, False)
        '        UpdateViewGrid()

        '    End With
        'End Sub

        'Private Sub Delete(ByVal counter As String)
        '    Dim brdelete As New BussinessRules.TemplateResult
        '    With brdelete

        '        .counter = New SqlDecimal(CDec(counter))

        '        If CBool(.SelectOne(BussinessRules.QISRecStatus.CurrentRecord).Rows.Count) Then
        '            .Delete()
        '        End If
        '    End With
        '    brdelete.Dispose()
        '    brdelete = Nothing
        'End Sub

        'Private Sub OpenPenunjang()
        '    Dim brpnj As New BussinessRules.pnjmedis
        '    brpnj.KdpMedis = New SqlString(txtKodePenunjang.Text.Trim)
        '    If brpnj.SelectOne(BussinessRules.QISRecStatus.CurrentRecord).Rows.Count > 0 Then
        '        txtNamaPenunjang.Text = brpnj.NmpMedis.Value.Trim
        '    End If
        '    brpnj.Dispose()
        '    brpnj = Nothing
        'End Sub

        'Private Sub OpenLayan()
        '    Dim brlyn As New BussinessRules.tarifpelayanan
        '    brlyn.kdlayan = New SqlString(txtKodePelayanan.Text.Trim)
        '    If brlyn.SelectOne(BussinessRules.QISRecStatus.CurrentRecord).Rows.Count > 0 Then
        '        txtNamaPelayanan.Text = brlyn.nmlayan.Value.Trim
        '    End If
        '    brlyn.Dispose()
        '    brlyn = Nothing
        'End Sub

        'Private Sub OpenDokter()
        '    Dim br As New BussinessRules.medis
        '    br.Kode = New SqlString(txtKodeDokter.Text.Trim)
        '    If br.SelectOne(BussinessRules.QISRecStatus.CurrentRecord).Rows.Count > 0 Then
        '        txtNamaDokter.Text = br.Nama.Value.Trim
        '    Else
        '        txtNamaDokter.Text = String.Empty
        '    End If
        '    br.Dispose()
        '    br = Nothing
        'End Sub

#End Region

#Region "Data Grid"

        Private Sub UpdateViewGrid()

            Dim dt As DataTable
            Dim obj As New Common.BussinessRules.PenunjangMedis
            obj.Noreg = New SqlString(strNoreg.Trim)
            obj.Nobukti = New SqlString(strNoBukti.Trim)

            dt = obj.SelectForHasil()

            grdHasil.DataSource = dt.DefaultView
            grdHasil.DataBind()

            Session("DictatedDV") = dt.DefaultView
            obj.Dispose()
            obj = Nothing

        End Sub

        'Private Sub grdTempResult_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles grdTempResult.ItemCommand
        'Select Case e.CommandName
        '    Case "_Edit"
        '        commonFunction.ShowPanel(panelTempResultAddNewRow, True)

        '        Dim _lblcounter As Label = CType(e.Item.FindControl("_lblcounter"), Label)
        '        Dim _lblkdlayan As Label = CType(e.Item.FindControl("_lblkdlayan"), Label)
        '        Dim _lblresultTitle As Label = CType(e.Item.FindControl("_lblresultTitle"), Label)
        '        Dim _lblresult As Label = CType(e.Item.FindControl("_lblresult"), Label)
        '        Dim _lblresult2 As Label = CType(e.Item.FindControl("_lblresult2"), Label)

        '        txtCounter.Text = _lblcounter.Text.Trim

        '        commonFunction.SelectListItem(ddlGroupHasilPnjAddNewRow, ddlGroupHasilPnj.SelectedItem.Value.Trim)

        '        If Len(_lblkdlayan.Text.Trim) > 0 Then
        '            txtKodePelayanan.Text = _lblkdlayan.Text.Trim
        '        End If

        '        'If Len(_lblresult.Text.Trim) > 0 Then
        '        '    txtResult.Text = _lblresult.Text.Trim
        '        '    'radeResult.Html = _lblresult.Text.Trim
        '        'End If

        '        txtResultTitle.Text = _lblresultTitle.Text.Trim
        '        txtResult.Text = _lblresult.Text.Trim

        '        'If Len(_lblresult2.Text.Trim) > 0 Then
        '        '    txtResultEng.Text = _lblresult2.Text.Trim
        '        'End If

        '        txtResultEng.Text = _lblresult2.Text.Trim

        '        commonFunction.ShowPanel(pnlInd, True)
        '        commonFunction.ShowPanel(pnlEng, False)
        '        rdbInd.Checked = True
        '        rdbEng.Checked = False

        '    Case "_Delete"
        '        Dim _lblcounter As Label = CType(e.Item.FindControl("_lblcounter"), Label)
        '        Delete(_lblcounter.Text)
        '        UpdateViewGrid()

        'End Select
        'End Sub

#End Region

#Region "Object Function"

        'Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        '    'save()
        'End Sub

        'Private Sub btnDone_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDone.Click
        '    'commonFunction.ShowPanel(panelTempResultAddNewRow, False)
        '    'commonFunction.ShowPanel(pnl_gridLayanTempResult, False)
        'End Sub

        'Public Sub grdTempResult_buttonNewRow_OnAddNewRow(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdTempResult_buttonNewRow.Click
        '    'txtCounter.Text = "0"
        '    ''radeResult.Html = String.Empty
        '    'txtResultTitle.Text = String.Empty
        '    'txtResult.Text = String.Empty
        '    'txtResultEng.Text = String.Empty
        '    'UpdateViewGrid()
        '    'commonFunction.ShowPanel(panelTempResultAddNewRow, True)
        '    ''commonFunction.ShowPanel(pnl_gridLayanTempResult, True)

        '    'commonFunction.ShowPanel(pnlInd, True)
        '    'commonFunction.ShowPanel(pnlEng, False)
        '    'rdbInd.Checked = True
        '    'rdbEng.Checked = False
        'End Sub

        'Private Sub txtKodePenunjang_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtKodePenunjang.TextChanged
        '    'OpenPenunjang()
        'End Sub

        'Private Sub txtKodePelayanan_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtKodePelayanan.TextChanged
        '    'OpenLayan()
        'End Sub

        'Private Sub txtKodeDokter_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtKodeDokter.TextChanged
        '    'OpenDokter()
        'End Sub

        'Private Sub txtPelayananPnjMedis_KodePelayanan_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPelayananPnjMedis_KodePelayanan.TextChanged
        '    'Dim brlyn As New BussinessRules.tarifpelayanan
        '    'brlyn.kdlayan = New SqlString(txtPelayananPnjMedis_KodePelayanan.Text.Trim)
        '    'If brlyn.SelectOne(BussinessRules.QISRecStatus.CurrentRecord).Rows.Count > 0 Then
        '    '    txtPelayananPnjMedis_NamaPelayanan.Text = brlyn.nmlayan.Value.Trim
        '    'Else
        '    '    txtPelayananPnjMedis_NamaPelayanan.Text = String.Empty
        '    'End If
        '    'brlyn.Dispose()
        '    'brlyn = Nothing
        '    'UpdateViewGrid()
        'End Sub

        'Private Sub txtPelayananPnjMedis_KodeDokter_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPelayananPnjMedis_KodeDokter.TextChanged
        '    'Dim br As New BussinessRules.medis
        '    'br.Kode = New SqlString(txtPelayananPnjMedis_KodeDokter.Text.Trim)
        '    'If br.SelectOne(BussinessRules.QISRecStatus.CurrentRecord).Rows.Count > 0 Then
        '    '    txtPelayananPnjMedis_NamaDokter.Text = br.Nama.Value.Trim
        '    'Else
        '    '    txtPelayananPnjMedis_NamaDokter.Text = String.Empty
        '    'End If
        '    'br.Dispose()
        '    'br = Nothing
        '    'UpdateViewGrid()
        'End Sub

        'Private Sub ddlGroupHasilPnj_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGroupHasilPnj.SelectedIndexChanged
        '    'UpdateViewGrid()
        'End Sub

#End Region

        Private Sub grdTempResult_SortCommand(ByVal source As Object, ByVal e As DataGridSortCommandEventArgs) Handles grdHasil.SortCommand
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
            grdHasil.DataSource = dv
            grdHasil.DataBind()
        End Sub

    End Class

End Namespace
