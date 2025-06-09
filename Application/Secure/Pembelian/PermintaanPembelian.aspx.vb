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

Namespace QIS.Web
    Public Class PermintaanPembelian
        Inherits PageBase

#Region " Web Form Designer Generated Code "

        'This calTglButuhl is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method calTglButuhl is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

#Region " Private Variables (web form designer generated code and user code) "
        Private MODULE_ID As String = "92102"
        Protected WithEvents CSSToolbar As CSSToolbar
        Protected WithEvents calTglMinta As QIS.Web.Calendar
        Protected WithEvents lbtnNoBukti As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtNoBukti As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtKeterangan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTglMinta As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlDepTujuan As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlDepAsal As System.Web.UI.WebControls.DropDownList
        Protected WithEvents Permintaan_AddNewRow_txtCounter As System.Web.UI.WebControls.TextBox
        Protected WithEvents rfvPermintaan_AddNewRow_txtNamaItem As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents Permintaan_AddNewRow_txtNamaItem As System.Web.UI.WebControls.TextBox
        Protected WithEvents Permintaan_AddNewRow_txtKuantitas As System.Web.UI.WebControls.TextBox
        Protected WithEvents Permintaan_AddNewRow_txtSaldo As System.Web.UI.WebControls.TextBox
        Protected WithEvents Permintaan_AddNewRow_txtKeterangan As System.Web.UI.WebControls.TextBox
        Protected WithEvents Permintaan_AddNewRow_calTglButuh As QIS.Web.Calendar
        Protected WithEvents cvKuantitas As System.Web.UI.WebControls.CompareValidator
        Protected WithEvents cvKuantitas1 As System.Web.UI.WebControls.CompareValidator
        Protected WithEvents rfvPermintaan_AddNewRow_txtKuantitas As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents Permintaan_btnAddNewRow As System.Web.UI.WebControls.Button
        Protected WithEvents Permintaan_btnDone As System.Web.UI.WebControls.Button
        Protected WithEvents panelPermintaanAddNewRow As System.Web.UI.WebControls.Panel
        Protected WithEvents gridPermintaan As System.Web.UI.WebControls.DataGrid
        Protected WithEvents ValidationSummary As System.Web.UI.WebControls.ValidationSummary
        Private _searchKey As Boolean
        Private _currentBrowseType As String
        Private _post As Boolean
#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            If Me.IsPostBack Then
            Else
                setToolbarVisibleButton()
                InitField()
                commonFunction.ShowPanel(panelPermintaanAddNewRow, False)
                _Open()
                
                lbtnNoBukti.Attributes.Add("onClick", commonFunction.JSOpenSearchListWind("PP", txtNoBukti.ClientID))
                txtNoBukti.Attributes.Add("onKeyDown", commonFunction.JSOpenSearchListWind("PP", txtNoBukti.ClientID, True))
                DataBind()
            End If
        End Sub

        Private Sub txtNoBukti_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNoBukti.TextChanged
            commonFunction.ShowPanel(panelPermintaanAddNewRow, False)
            _Open()
        End Sub

        Private Sub Permintaan_btnDone_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Permintaan_btnDone.Click
            commonFunction.ShowPanel(panelPermintaanAddNewRow, False)
            clearAddNewRow()
        End Sub

        Private Sub Permintaan_btnAddNewRow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Permintaan_btnAddNewRow.Click
            AddNewPermintaan()
        End Sub

        Private Sub gridPermintaan_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles gridPermintaan.ItemCommand
            System.Diagnostics.Debug.WriteLine(e.CommandName)

            Select Case e.CommandName
                Case "_AddNewRow"
                    commonFunction.ShowPanel(panelPermintaanAddNewRow, True)
                    clearAddNewRow()
                Case "__delete"
                    Dim _lblCounter As Label = CType(e.Item.FindControl("_lblCounter"), Label)
                    If Not _lblCounter Is Nothing Then
                        _deletePermintaanDT(_lblCounter.Text)
                    End If
                Case "Edit"
                    commonFunction.ShowPanel(panelPermintaanAddNewRow, True)

                    'Dim _lblNamaItem As Label = CType(e.Item.FindControl("_lblNamaItem"), Label)
                    'Dim _lblKuantitas As Label = CType(e.Item.FindControl("_lblKuantitas"), Label)
                    'Dim _lblSaldo As Label = CType(e.Item.FindControl("_lblSaldo"), Label)
                    'Dim _lblTglButuh As Label = CType(e.Item.FindControl("_lblTglButuh"), Label)
                    'Dim _lblKeterangan As Label = CType(e.Item.FindControl("_lblKeterangan"), Label)
                    Dim odt As New Common.BussinessRules.PermintaanBeli
                    With odt
                        Permintaan_AddNewRow_txtCounter.Text = CType(gridPermintaan.DataKeys(e.Item.ItemIndex), Guid).ToString
                        .Counter = CType(gridPermintaan.DataKeys(e.Item.ItemIndex), Guid)
                        If .SelectOneDT.Rows.Count > 0 Then
                            Permintaan_AddNewRow_txtNamaItem.Text = .NamaBarang.Value.Trim
                            Permintaan_AddNewRow_txtKuantitas.Text = CStr(.QTY)
                            Permintaan_AddNewRow_txtSaldo.Text = CStr(.Saldo)
                            Permintaan_AddNewRow_calTglButuh.selectedDate = CDate(.TglDibutuhkan)
                            Permintaan_AddNewRow_txtKeterangan.Text = .Keterangan.Value.Trim
                        Else
                            Permintaan_AddNewRow_txtNamaItem.Text = String.Empty
                            Permintaan_AddNewRow_txtKuantitas.Text = "0.00"
                            Permintaan_AddNewRow_txtSaldo.Text = "0.00"
                            Permintaan_AddNewRow_calTglButuh.selectedDate = Date.Now
                            Permintaan_AddNewRow_txtKeterangan.Text = String.Empty
                        End If
                    End With
            End Select
        End Sub

        Private Sub gridPermintaan_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles gridPermintaan.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.AlternatingItem, ListItemType.Item

                    ' // Dialog save or not when the imagebutton clicked by user ..
                    Dim _ImageButton As ImageButton = CType(e.Item.FindControl("__ibtnDelete"), ImageButton)

                    If Not _ImageButton Is Nothing Then
                        _ImageButton.Attributes.Add("OnClick", "javascript:return dlgDeleteRecordInGrid();")
                    End If
            End Select
        End Sub

#End Region

#Region " Support functions for navigation bar (Controls)  "

        Private Sub setToolbarVisibleButton()
            With CSSToolbar
                .VisibleButton(CSSToolbarItem.tidNew) = True
                .VisibleButton(CSSToolbarItem.tidApprove) = False
                .VisibleButton(CSSToolbarItem.tidPropose) = False
                .VisibleButton(CSSToolbarItem.tidValidation) = False
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidSave) = True
                .VisibleButton(CSSToolbarItem.tidDelete) = False
                .VisibleButton(CSSToolbarItem.tidPrint) = False
                .VisibleButton(CSSToolbarItem.tidNext) = False
                .VisibleButton(CSSToolbarItem.tidPrevious) = False
            End With
            Permintaan_btnAddNewRow.Enabled = True
        End Sub

        Private Sub mdlToolbar_commandBarClick(ByVal sender As Object, ByVal e As CSSToolbarItem) Handles CSSToolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidApprove
                    Dim comm As New Common.BussinessRules.CommonCode
                    With comm
                        .GroupCode = "MANAGER"
                        .Value = Me.LoggedOnUserID.Trim
                        If .SelectByGroupCodeValue.Rows.Count > 0 Then
                            UpdateValidasi(True)
                        Else
                            Throw New Exception("Approve hanya dapat dilakukan oleh Manager")
                            Exit Sub
                        End If
                    End With
                    comm.Dispose()
                    comm = Nothing
                Case CSSToolbarItem.tidVoid
                    If Len(Trim(txtNoBukti.Text)) = 0 Then Exit Sub
                    Dim oPP As New Common.BussinessRules.PermintaanBeli
                    Dim comm As New Common.BussinessRules.CommonCode
                    With oPP
                        .nominta = txtNoBukti.Text.Trim
                        If .SelectByNoProses.Rows.Count > 0 Then
                            Throw New Exception("Transaksi sudah diproses, tidak bisa dibatalkan.")
                            Exit Sub
                        Else
                            .nominta = txtNoBukti.Text.Trim
                            If .SelectOne.Rows.Count > 0 Then
                                If .Validasi = True Then
                                    With comm
                                        .Code = "DIR"
                                        .GroupCode = "Direktur"
                                        .SelectOne()
                                        If .Value = Me.LoggedOnUserID Then
                                            UpdateValidasi(False)
                                        Else
                                            .GroupCode = "SEKERTARIAT"
                                            .Value = Me.LoggedOnUserID.Trim
                                            If .SelectByGroupCodeValue.Rows.Count > 0 Then
                                                UpdateValidasi(False)
                                            Else
                                                Throw New Exception("Transaksi sudah di validasi, Void hanya dapat dilakukan oleh Manager atau Sekertariat")
                                                Exit Sub
                                            End If
                                        End If
                                    End With
                                    comm.Dispose()
                                    comm = Nothing
                                ElseIf .Approve = True Then
                                    With comm
                                        .GroupCode = "MANAGER"
                                        .Value = Me.LoggedOnUserID.Trim
                                        If .SelectByGroupCodeValue.Rows.Count > 0 Then
                                            UpdateValidasi(False)
                                        Else
                                            Throw New Exception("Transaksi sudah di approve, void hanya dapat dilakukan oleh Manager")
                                            Exit Sub
                                        End If
                                    End With
                                    comm.Dispose()
                                    comm = Nothing
                                Else
                                    _save()
                                End If
                            End If
                        End If
                    End With
                    oPP.Dispose()
                    oPP = Nothing
                Case CSSToolbarItem.tidDelete
                    _deleteNoBukti()
                    commonFunction.ShowPanel(panelPermintaanAddNewRow, False)
                    prepareScreen()
                Case CSSToolbarItem.tidNew
                    commonFunction.ShowPanel(panelPermintaanAddNewRow, False)
                    prepareScreen()
                Case CSSToolbarItem.tidPropose
                    _save(True)
                Case CSSToolbarItem.tidSave
                    _save()
                Case CSSToolbarItem.tidPrint
                    Dim br As New Common.BussinessRules.MyReport
                    With br
                        .ReportCode = "4001"
                        .AddParameters(txtNoBukti.Text.Trim)
                        Response.Write(.UrlPrintPreview(Context.Request.Url.Host))
                    End With
                    br.Dispose()
                    br = Nothing
                Case CSSToolbarItem.tidValidation
                    Dim comm As New Common.BussinessRules.CommonCode
                    With comm
                        .Code = "DIR"
                        .GroupCode = "Direktur"
                        .SelectOne()
                        If .Value = Me.LoggedOnUserID Then
                            UpdateValidasi(True)
                        Else
                            .GroupCode = "SEKERTARIAT"
                            .Value = Me.LoggedOnUserID.Trim
                            If .SelectByGroupCodeValue.Rows.Count > 0 Then
                                UpdateValidasi(True)
                            Else
                                Throw New Exception("Validasi hanya dapat dilakukan oleh Manager atau Sekertariat")
                                Exit Sub
                            End If
                        End If
                    End With
                    comm.Dispose()
                    comm = Nothing
            End Select
        End Sub

#End Region

#Region " Additional: Private Function "

        Private Function ReadQueryString() As Boolean
            Dim id As String = Request.QueryString("ID")
            Return (Len(Trim(id)) > 0)
        End Function

        Private Sub InitField()
            commonFunction.SetDDL_Table(ddlDepAsal, "CommonCodeCode", Common.Constants.GroupCode.Unit, False)
            commonFunction.SetDDL_Table(ddlDepTujuan, "CommonCodeCode", Common.Constants.GroupCode.Unit, False)
        End Sub

        Private Sub prepareScreen()
            txtNoBukti.Text = String.Empty
            calTglMinta.selectedDate = Date.Now
            commonFunction.SelectListItem(ddlDepAsal, "ITS")
            commonFunction.SelectListItem(ddlDepTujuan, "ITS")
            txtKeterangan.Text = String.Empty
            clearAddNewRow()
            UpdateViewGridPermintaan()
            setToolbarVisibleButton()
        End Sub

        Private Sub clearAddNewRow()
            Permintaan_AddNewRow_txtCounter.Text = String.Empty
            Permintaan_AddNewRow_txtNamaItem.Text = String.Empty
            Permintaan_AddNewRow_txtKuantitas.Text = "0.00"
            Permintaan_AddNewRow_txtSaldo.text = "0.00"
            Permintaan_AddNewRow_calTglButuh.selectedDate = Date.Now
            Permintaan_AddNewRow_txtKeterangan.Text = String.Empty

            Dim odt As New Common.BussinessRules.PermintaanBeli
            With odt
                .nominta = txtNoBukti.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    If .posting = True Then
                        Permintaan_btnAddNewRow.Enabled = False
                    Else
                        Permintaan_btnAddNewRow.Enabled = True
                    End If
                End If
            End With
            odt.Dispose()
            odt = Nothing
        End Sub

#End Region

#Region " Main Function: Open, Save, Delete Data "

#Region " Permintaan Header "

        Private Sub _Open()

            Dim oNoBukti As New Common.BussinessRules.PermintaanBeli

            With oNoBukti
                .nominta = txtNoBukti.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    txtNoBukti.Text = .nominta.Value
                    calTglMinta.selectedDate = CDate(.tglminta)
                    commonFunction.SelectListItem(ddlDepAsal, .UnitMinta.Value)
                    commonFunction.SelectListItem(ddlDepTujuan, .unittujuan.Value)
                    txtKeterangan.Text = .Keterangan.Value
                    If .Validasi = True Then
                        With CSSToolbar
                            .VisibleButton(CSSToolbarItem.tidNew) = True
                            .VisibleButton(CSSToolbarItem.tidApprove) = False
                            .VisibleButton(CSSToolbarItem.tidPropose) = False
                            .VisibleButton(CSSToolbarItem.tidValidation) = False
                            .VisibleButton(CSSToolbarItem.tidVoid) = True
                            .VisibleButton(CSSToolbarItem.tidSave) = False
                            .VisibleButton(CSSToolbarItem.tidDelete) = False
                            .VisibleButton(CSSToolbarItem.tidPrint) = True
                        End With
                        Permintaan_btnAddNewRow.Enabled = False
                    ElseIf .Approve = True Then
                        With CSSToolbar
                            .VisibleButton(CSSToolbarItem.tidNew) = True
                            .VisibleButton(CSSToolbarItem.tidApprove) = False
                            .VisibleButton(CSSToolbarItem.tidPropose) = False
                            .VisibleButton(CSSToolbarItem.tidValidation) = True
                            .VisibleButton(CSSToolbarItem.tidVoid) = True
                            .VisibleButton(CSSToolbarItem.tidSave) = False
                            .VisibleButton(CSSToolbarItem.tidDelete) = False
                            .VisibleButton(CSSToolbarItem.tidPrint) = True
                        End With
                        Permintaan_btnAddNewRow.Enabled = False
                    ElseIf .posting = True Then
                        With CSSToolbar
                            .VisibleButton(CSSToolbarItem.tidNew) = True
                            .VisibleButton(CSSToolbarItem.tidApprove) = True
                            .VisibleButton(CSSToolbarItem.tidPropose) = False
                            .VisibleButton(CSSToolbarItem.tidValidation) = False
                            .VisibleButton(CSSToolbarItem.tidVoid) = True
                            .VisibleButton(CSSToolbarItem.tidSave) = False
                            .VisibleButton(CSSToolbarItem.tidDelete) = False
                            .VisibleButton(CSSToolbarItem.tidPrint) = False
                        End With
                        Permintaan_btnAddNewRow.Enabled = False
                    Else
                        With CSSToolbar
                            .VisibleButton(CSSToolbarItem.tidNew) = True
                            .VisibleButton(CSSToolbarItem.tidApprove) = False
                            .VisibleButton(CSSToolbarItem.tidPropose) = True
                            .VisibleButton(CSSToolbarItem.tidValidation) = False
                            .VisibleButton(CSSToolbarItem.tidVoid) = False
                            .VisibleButton(CSSToolbarItem.tidSave) = True
                            .VisibleButton(CSSToolbarItem.tidDelete) = True
                            .VisibleButton(CSSToolbarItem.tidPrint) = False
                        End With
                        Permintaan_btnAddNewRow.Enabled = True
                    End If
                Else
                    prepareScreen()
                End If
            End With

            oNoBukti.Dispose()
            oNoBukti = Nothing

            Page.DataBind()
            'clearAddNewRow()
            UpdateViewGridPermintaan()
        End Sub

        Private Sub _deleteNoBukti()
            If Len(txtNoBukti.Text.Trim) = 0 Then Exit Sub
            _deleteAllPermintaan()
        End Sub

        Private Sub _save(Optional ByVal fposting As Boolean = False)
            Page.Validate()
            If Not Page.IsValid Then Exit Sub

            Dim oPP As New Common.BussinessRules.PermintaanBeli

            Dim Max As String = ""
            Dim InitNo As Integer = 1
            Dim fNotNew As Boolean = False

            With oPP
                .nominta = txtNoBukti.Text.Trim
                fNotNew = (.SelectOne.Rows.Count > 0)
                If Len(txtNoBukti.Text.Trim) = 0 Then
                    Max = .NewTransactionNumber(calTglMinta.selectedDate).Value
                    .nominta = Max.Trim
                    txtNoBukti.Text = Max.Trim
                Else
                    .nominta = txtNoBukti.Text.Trim
                End If
                .tglminta = calTglMinta.selectedDate
                .UnitMinta = ddlDepAsal.SelectedValue.Trim
                .unittujuan = ddlDepTujuan.SelectedValue.Trim
                .Keterangan = txtKeterangan.Text.Trim
                .posting = fposting
                .Approve = False
                .Validasi = False
                .User = Me.LoggedOnUserID
                If fNotNew Then
                    .Update()
                Else
                    .Insert()
                End If
            End With
            oPP.Dispose()
            oPP = Nothing
            _Open()
        End Sub

        Private Sub UpdateValidasi(ByVal _valid As Boolean)
            Page.Validate()
            If Not Page.IsValid Then Exit Sub
            Dim oChecklist As New Common.BussinessRules.PermintaanBeli
            With oChecklist
                .nominta = txtNoBukti.Text.Trim
                .Approve = _valid
                .User = Me.LoggedOnUserID.Trim
                .UpdateValidasi()
            End With
            oChecklist.Dispose()
            oChecklist = Nothing
            _Open()
        End Sub
#End Region

#Region " Permintaan Detail "

        Private Sub _deletePermintaanDT(ByVal counter As String)
            Dim oPermintaan As New Common.BussinessRules.PermintaanBeli

            With oPermintaan
                .Counter = New SqlGuid(counter.Trim)
                .DeleteDT()
            End With

            oPermintaan.Dispose()
            oPermintaan = Nothing

            ' // refresh the screen 
            clearAddNewRow()
            UpdateViewGridPermintaan()
        End Sub

        Private Sub _deleteAllPermintaan()
            Dim oPermintaanAll As New Common.BussinessRules.PermintaanBeli

            With oPermintaanAll
                .nominta = New SqlString(Trim(txtNoBukti.Text))

                .Delete()
            End With

            oPermintaanAll.Dispose()
            oPermintaanAll = Nothing
        End Sub

        Private Sub AddNewPermintaan()
            Page.Validate()
            If Not Page.IsValid Then Exit Sub

            _save()

            Dim oPermintaan As New Common.BussinessRules.PermintaanBeli
            Dim fSucceed As Boolean = False
            Dim fNotNew As Boolean = False

            With oPermintaan
                .nominta = New SqlString(txtNoBukti.Text.Trim)
                If Len(Trim(Permintaan_AddNewRow_txtCounter.Text)) = 0 Then
                    fNotNew = False
                Else
                    .Counter = New SqlGuid(Permintaan_AddNewRow_txtCounter.Text.Trim)
                    fNotNew = (.SelectOne.Rows.Count > 0)
                End If
                .nominta = New SqlString(txtNoBukti.Text.Trim)
                .NamaBarang = Permintaan_AddNewRow_txtNamaItem.Text.Trim
                .QTY = CDec(Permintaan_AddNewRow_txtKuantitas.Text.Trim)
                .Saldo = CDec(Permintaan_AddNewRow_txtSaldo.Text.Trim)
                .Keterangan = Permintaan_AddNewRow_txtKeterangan.Text.Trim
                .TglDibutuhkan = Permintaan_AddNewRow_calTglButuh.selectedDate
                .Proses = False
                .User = New SqlString(MyBase.LoggedOnUserID.Trim.ToUpper)

                If fNotNew Then
                    .Counter = New SqlGuid(Permintaan_AddNewRow_txtCounter.Text)
                    fSucceed = .UpdateDT()
                Else
                    fSucceed = .InsertDT()
                End If

                If fSucceed Then
                    UpdateViewGridPermintaan()
                    clearAddNewRow()
                End If
            End With

            oPermintaan.Dispose()
            oPermintaan = Nothing

        End Sub

        Private Function createTmpTable() As DataTable
            Dim tbl As DataTable = New DataTable

            With tbl
                .Columns.Add("nominta", System.Type.GetType("System.String"))
                .Columns.Add("kdbarang", System.Type.GetType("System.String"))
                .Columns.Add("qtyproses", System.Type.GetType("System.Double"))
            End With

            Return tbl
        End Function

        Private Sub UpdateViewGridPermintaan()
            Dim dt As DataTable
            Dim oPermintaan As New Common.BussinessRules.PermintaanBeli

            With oPermintaan
                .nominta = New SqlString(txtNoBukti.Text.Trim)
                dt = .SelectByNo()
            End With

            gridPermintaan.DataSource = dt.DefaultView
            gridPermintaan.DataBind()

            oPermintaan.Dispose()
            oPermintaan = Nothing

            Session("DictatedDV") = dt.DefaultView
        End Sub

#End Region

#End Region

#Region "Sorting Grid"

        Private Sub gridPermintaan_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles gridPermintaan.SortCommand
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
            gridPermintaan.DataSource = dv
            gridPermintaan.DataBind()
        End Sub

#End Region
    End Class
End Namespace