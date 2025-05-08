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

Namespace QIS.Web

    Public Class Aktiva
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
        Private MODULE_ID As String = "7001"
        Protected WithEvents CSSToolbar As CSSToolbar
        '//TextBox pada Add New Row...
        Protected WithEvents txtKodeAktiva As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNamaAktiva As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHargaBeli As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtNamaBuku As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtKodeMetode As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtNamaMetode As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtNvPenyusutan As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtNvPembelian As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtNvPenjualan As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtJmlhBeli As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtUmur As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtJmlhJual As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtNilaiAkhir As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtQtyBeli As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtSatuan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtKeterangan As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtKodeLokasi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNamaLokasi As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtKodeUser As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNamaUser As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtserialnumber As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtTglPemusnahan As System.Web.UI.WebControls.TextBox

        ''Protected WithEvents chkKSO As System.Web.UI.WebControls.CheckBox

        '//LinkButton pada Add New Row...
        Protected WithEvents lbtnKodeAktiva As System.Web.UI.WebControls.LinkButton
        'Protected WithEvents lbtnKodeBuku As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnKodeUser As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnKodeLokasi As System.Web.UI.WebControls.LinkButton

        '//WebCalendar pada Add New Row...
        Protected WithEvents calTglBeli As QIS.Web.Calendar
        'Protected WithEvents calTglHitung As QIS.Web.calendar
        'Protected WithEvents calTglJual As QIS.Web.calendarModule

        '//Required Field Validator pada Add New Row...
        Protected WithEvents rfvKodeAktiva As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents rfvNamaAktiva As System.Web.UI.WebControls.RequiredFieldValidator
        'Protected WithEvents rfvKodeBuku As System.Web.UI.WebControls.RequiredFieldValidator
        'Protected WithEvents rfvKodeMetode As System.Web.UI.WebControls.RequiredFieldValidator
        'Protected WithEvents rfvJmlhBeli As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents rfvUmur As System.Web.UI.WebControls.RequiredFieldValidator
        'Protected WithEvents rfvNamaSubL1 As System.Web.UI.WebControls.RequiredFieldValidator
        'Protected WithEvents rfvNamaSubL2 As System.Web.UI.WebControls.RequiredFieldValidator
        'Protected WithEvents rfvNamaSubL3 As System.Web.UI.WebControls.RequiredFieldValidator
        'Protected WithEvents rfvNamaSubL4 As System.Web.UI.WebControls.RequiredFieldValidator
        'Protected WithEvents rfvNamaSubL5 As System.Web.UI.WebControls.RequiredFieldValidator
        'Protected WithEvents rfvNamaSubL6 As System.Web.UI.WebControls.RequiredFieldValidator
        'Protected WithEvents rfvNamaSubL7 As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents rfvKodeLokasi As System.Web.UI.WebControls.RequiredFieldValidator

        '//TextBox Kode Perkiraan
        'Protected WithEvents txtCOA1 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtCOA2 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtCOA3 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtCOA4 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtCOA5 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtCOA6 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtCOA7 As System.Web.UI.WebControls.TextBox

        '//TextBox Nama Perkiraan
        'Protected WithEvents txtNamaCOA1 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtNamaCOA2 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtNamaCOA3 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtNamaCOA4 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtNamaCOA5 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtNamaCOA6 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtNamaCOA7 As System.Web.UI.WebControls.TextBox

        '//TextBox Kode Group SubLedger
        'Protected WithEvents txtGroupSubL1 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtGroupSubL2 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtGroupSubL3 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtGroupSubL4 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtGroupSubL5 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtGroupSubL6 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtGroupSubL7 As System.Web.UI.WebControls.TextBox

        '//TextBox Kode SubLedger
        'Protected WithEvents txtSubl1 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtSubl2 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtSubl3 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtSubl4 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtSubl5 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtSubl6 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtSubl7 As System.Web.UI.WebControls.TextBox

        '//TextBox Nama SubLedger
        'Protected WithEvents txtNamaSubL1 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtNamaSubL2 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtNamaSubL3 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtNamaSubL4 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtNamaSubL5 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtNamaSubL6 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtNamaSubL7 As System.Web.UI.WebControls.TextBox

        '//TextBox General atau Detil
        'Protected WithEvents txtGd1 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtGd2 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtGd3 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtGd4 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtGd5 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtGd6 As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtGd7 As System.Web.UI.WebControls.TextBox

        ''//LinkButton Kode Perkiraan
        'Protected WithEvents lbtnCOAAktiva As System.Web.UI.WebControls.LinkButton
        'Protected WithEvents lbtnCOAPenyusutan As System.Web.UI.WebControls.LinkButton
        'Protected WithEvents lbtnCOADepresiasi As System.Web.UI.WebControls.LinkButton
        'Protected WithEvents lbtnCOATanggungan As System.Web.UI.WebControls.LinkButton
        'Protected WithEvents lbtnCOAPendapatan As System.Web.UI.WebControls.LinkButton
        'Protected WithEvents lbtnCOABiaya As System.Web.UI.WebControls.LinkButton
        'Protected WithEvents lbtnCOAEliminasi As System.Web.UI.WebControls.LinkButton

        ''//LinkButton Kode SubLedger By Group SubLedger
        'Protected WithEvents lbtnSublAktiva As System.Web.UI.WebControls.LinkButton
        'Protected WithEvents lbtnSublPenyusutan As System.Web.UI.WebControls.LinkButton
        'Protected WithEvents lbtnSublDepresiasi As System.Web.UI.WebControls.LinkButton
        'Protected WithEvents lbtnSublTanggungan As System.Web.UI.WebControls.LinkButton
        'Protected WithEvents lbtnSublPendapatan As System.Web.UI.WebControls.LinkButton
        'Protected WithEvents lbtnSublBiaya As System.Web.UI.WebControls.LinkButton
        'Protected WithEvents lbtnSublEliminasi As System.Web.UI.WebControls.LinkButton

        ''//Button Save dan Delete
        'Protected WithEvents btnSave As System.Web.UI.WebControls.Button
        'Protected WithEvents btnDelete As System.Web.UI.WebControls.Button
        'Protected WithEvents btnProses As System.Web.UI.WebControls.Button
        'Protected WithEvents btnBatalProses As System.Web.UI.WebControls.Button

        'Protected WithEvents ValidationSummary As System.Web.UI.WebControls.ValidationSummary
        Protected WithEvents panelAddNewRow As System.Web.UI.WebControls.Panel
        Protected WithEvents panelGridAkumulasiFA As System.Web.UI.WebControls.Panel
        'Protected WithEvents gridAkumulasiFA As System.Web.UI.WebControls.DataGrid

        'Protected WithEvents txtcounterpenerimaan As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtnoterima As System.Web.UI.WebControls.TextBox

        'Protected WithEvents lbtnKodeKelompok As System.Web.UI.WebControls.LinkButton
        'Protected WithEvents txtKodeKelompok As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtNamaKelompok As System.Web.UI.WebControls.TextBox

        'Protected WithEvents txtNamaVendor As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtNoKontrak As System.Web.UI.WebControls.TextBox

        'Protected WithEvents ddlTypePemusnahan As System.Web.UI.WebControls.DropDownList
        'Protected WithEvents txtNilaiBuku As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtSelisih As System.Web.UI.WebControls.TextBox
        'Protected WithEvents txtKeteranganPemusnahan As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkPosting As System.Web.UI.WebControls.CheckBox

        'Private _counter As Guid
        'Private _counterstr As String

#End Region


#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Me.IsPostBack Then
            Else
                Dim fQueryStringExist As Boolean

                'If Not MyBase.AllowRead(Me.MODULE_ID) Then
                '    Throw New Exception(commonFunction.MSG_ACCESS_DENIED)
                'End If

                fQueryStringExist = ReadQueryString()

                'If fQueryStringExist Then
                '    '_OpenFAItemLG(_counter)
                '    _OpenFAItemLGTest(_counterstr)
                'Else
                prepareScreen()
                'End If

                'Dim ovar As New SetVar
                'If Common.Methods.GetSettingParameter("fKdAktivaCreateOtomatis", Common.Constants.ModuleID.GENERAL_LEDGER) = "1" Then
                '    rfvKodeAktiva.Enabled = False
                'Else
                '    rfvKodeAktiva.Enabled = True
                'End If

                lbtnKodeAktiva.Attributes.Add("OnClick", commonFunction.JSOpenSearchListWind("kdAktiva", txtKodeAktiva.ClientID))
                txtKodeAktiva.Attributes.Add("OnKeyDown", commonFunction.JSOpenSearchListWind("kdAktiva", txtKodeAktiva.ClientID))

                'lbtnKodeBuku.Attributes.Add("OnClick", "javascript:showDialogBuku('" + txtKodeBuku.ClientID + "');")
                'txtKodeBuku.Attributes.Add("OnKeyDown", "javascript:HookKeyCode(urlbBuku,'','" + txtKodeBuku.ClientID + "','');")

                lbtnKodeLokasi.Attributes.Add("OnClick", commonFunction.JSOpenSearchListWind("kdLokasi", txtKodeLokasi.ClientID))
                txtKodeLokasi.Attributes.Add("OnKeyDown", commonFunction.JSOpenSearchListWind("kdLokasi", txtKodeLokasi.ClientID))

                lbtnKodeUser.Attributes.Add("OnClick", commonFunction.JSOpenSearchListWind("kduser", txtKodeUser.ClientID))
                txtKodeUser.Attributes.Add("OnKeyDown", commonFunction.JSOpenSearchListWind("kduser", txtKodeUser.ClientID))

                'lbtnKodeMetode.Attributes.Add("OnClick", "javascript:showDialogMetode('" + txtKodeMetode.ClientID + "');")
                'txtKodeMetode.Attributes.Add("OnKeyDown", "javascript:HookKeyCode(urlbMetode,'','" + txtKodeMetode.ClientID + "','');")

                'lbtnKodeKelompok.Attributes.Add("OnClick", "javascript:showDialogKelompokFa('" + txtKodeKelompok.ClientID + "');")
                'txtKodeKelompok.Attributes.Add("OnKeyDown", "javascript:HookKeyCode(urlbKelompokFa,'','" + txtKodeKelompok.ClientID + "','');")

                'lbtnCOAAktiva.Attributes.Add("OnClick", "javascript:showDialogNopekDetil('" + txtCOA1.ClientID + "');")
                'txtCOA1.Attributes.Add("OnKeyDown", "javascript:HookKeyCode(urlbNopekDetil,'','" + txtCOA1.ClientID + "','');")

                'lbtnCOAPenyusutan.Attributes.Add("OnClick", "javascript:showDialogNopekDetil('" + txtCOA2.ClientID + "');")
                'txtCOA2.Attributes.Add("OnKeyDown", "javascript:HookKeyCode(urlbNopekDetil,'','" + txtCOA2.ClientID + "','');")

                'lbtnCOADepresiasi.Attributes.Add("OnClick", "javascript:showDialogNopekDetil('" + txtCOA3.ClientID + "');")
                'txtCOA3.Attributes.Add("OnKeyDown", "javascript:HookKeyCode(urlbNopekDetil,'','" + txtCOA3.ClientID + "','');")

                'lbtnCOATanggungan.Attributes.Add("OnClick", "javascript:showDialogNopekDetil('" + txtCOA4.ClientID + "');")
                'txtCOA4.Attributes.Add("OnKeyDown", "javascript:HookKeyCode(urlbNopekDetil,'','" + txtCOA4.ClientID + "','');")

                'lbtnCOAPendapatan.Attributes.Add("OnClick", "javascript:showDialogNopekDetil('" + txtCOA5.ClientID + "');")
                'txtCOA5.Attributes.Add("OnKeyDown", "javascript:HookKeyCode(urlbNopekDetil,'','" + txtCOA5.ClientID + "','');")

                'lbtnCOABiaya.Attributes.Add("OnClick", "javascript:showDialogNopekDetil('" + txtCOA6.ClientID + "');")
                'txtCOA6.Attributes.Add("OnKeyDown", "javascript:HookKeyCode(urlbNopekDetil,'','" + txtCOA6.ClientID + "','');")

                'lbtnCOAEliminasi.Attributes.Add("OnClick", "javascript:showDialogNopekDetil('" + txtCOA7.ClientID + "');")
                'txtCOA7.Attributes.Add("OnKeyDown", "javascript:HookKeyCode(urlbNopekDetil,'','" + txtCOA7.ClientID + "','');")

                'lbtnSublAktiva.Attributes.Add("OnClick", "javascript:showDialogSubLedgerByGroup('" + txtSubl1.ClientID + "',document.getElementById('" + txtGroupSubL1.ClientID + "').value);")

                'lbtnSublPenyusutan.Attributes.Add("OnClick", "javascript:showDialogSubLedgerByGroup('" + txtSubl2.ClientID + "',document.getElementById('" + txtGroupSubL2.ClientID + "').value);")

                'lbtnSublDepresiasi.Attributes.Add("OnClick", "javascript:showDialogSubLedgerByGroup('" + txtSubl3.ClientID + "',document.getElementById('" + txtGroupSubL3.ClientID + "').value);")

                'lbtnSublTanggungan.Attributes.Add("OnClick", "javascript:showDialogSubLedgerByGroup('" + txtSubl4.ClientID + "',document.getElementById('" + txtGroupSubL4.ClientID + "').value);")

                'lbtnSublPendapatan.Attributes.Add("OnClick", "javascript:showDialogSubLedgerByGroup('" + txtSubl5.ClientID + "',document.getElementById('" + txtGroupSubL5.ClientID + "').value);")

                'lbtnSublBiaya.Attributes.Add("OnClick", "javascript:showDialogSubLedgerByGroup('" + txtSubl6.ClientID + "',document.getElementById('" + txtGroupSubL6.ClientID + "').value);")

                'lbtnSublEliminasi.Attributes.Add("OnClick", "javascript:showDialogSubLedgerByGroup('" + txtSubl7.ClientID + "',document.getElementById('" + txtGroupSubL7.ClientID + "').value);")

                '// format currency untuk textbox 
                'txtJmlhBeli.Attributes.Add("onblur", "javascript:FormatCurrency(this);")
                'txtJmlhJual.Attributes.Add("onblur", "javascript:FormatCurrency(this);")
                'txtNilaiAkhir.Attributes.Add("onblur", "javascript:FormatCurrency(this);")

                'btnProses.Attributes.Add("OnClick", "javascript:return dlgSaveData();")
                'btnBatalProses.Attributes.Add("OnClick", "javascript:return dlgDeleteRecordInGrid();")

                'commonFunction.SetDropDownLisToStdData(ddlTypePemusnahan, "GL_TPPEMUSNAHAN", True)

                commonFunction.ShowPanel(panelAddNewRow, True)

                InitToolbar()

                '_OpenByMaxTglUpdate()

                DataBind()
            End If
        End Sub

        'Private Sub grid_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles gridAkumulasiFA.ItemCreated
        '    If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
        '        Dim _chkPilih As CheckBox = CType(e.Item.FindControl(CType(sender, DataGrid).ID + "_chkPilih"), CheckBox)

        '        _chkPilih.Attributes.Add("OnClick", "javascript:colorRowv2(this,'cbxSelectAllAkumulasi');")

        '    End If
        'End Sub

        'Private Sub btn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProses.Click, btnBatalProses.Click
        '    Select Case CType(sender, Button).ID
        '        Case btnProses.ID
        '            If _prosesAkumulasiFAByKdBukuKdAktiva() = True Then
        '                commonFunction.MsgBox(Me, "Proses Akumulasi Penyusutan Fixed Assets berhasil.")
        '            End If
        '        Case btnBatalProses.ID
        '            _batalProsesJurnalFA()
        '    End Select
        'End Sub

        Private Sub txt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtKodeAktiva.TextChanged
            Select Case CType(sender, TextBox).ClientID
                Case "txtKodeAktiva"
                    '//open data aktiva...
                    _Open(BussinessRules.QISRecStatus.CurrentRecord)
                    'Case "txtKodeBuku"
                    '    '//open nama buku Fixed Asset...
                    '    _OpenNamaBukuFA(BussinessRules.QISRecStatus.CurrentRecord)
                    'Case "txtKodeMetode"
                    '    '//open nama metode Fixed Asset...
                    '    _OpenNamaMetodeFA(BussinessRules.QISRecStatus.CurrentRecord)
                    'Case "txtKodeKelompok"
                    '    _OpenKelompokFA()
            End Select

        End Sub

        'Private Sub txtCOA_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCOA1.TextChanged, txtCOA2.TextChanged, txtCOA3.TextChanged, txtCOA4.TextChanged, txtCOA5.TextChanged, txtCOA6.TextChanged, txtCOA7.TextChanged
        '    Select Case CType(sender, TextBox).ClientID
        '        Case "txtCOA1"
        '            _OpenNamaCOA(txtCOA1)
        '            txtSubl1.Text = String.Empty
        '            txtNamaSubL1.Text = String.Empty
        '        Case "txtCOA2"
        '            _OpenNamaCOA(txtCOA2)
        '            txtSubl2.Text = String.Empty
        '            txtNamaSubL2.Text = String.Empty
        '        Case "txtCOA3"
        '            _OpenNamaCOA(txtCOA3)
        '            txtSubl3.Text = String.Empty
        '            txtNamaSubL3.Text = String.Empty
        '        Case "txtCOA4"
        '            _OpenNamaCOA(txtCOA4)
        '            txtSubl4.Text = String.Empty
        '            txtNamaSubL4.Text = String.Empty
        '        Case "txtCOA5"
        '            _OpenNamaCOA(txtCOA5)
        '            txtSubl5.Text = String.Empty
        '            txtNamaSubL5.Text = String.Empty
        '        Case "txtCOA6"
        '            _OpenNamaCOA(txtCOA6)
        '            txtSubl6.Text = String.Empty
        '            txtNamaSubL6.Text = String.Empty
        '        Case "txtCOA7"
        '            _OpenNamaCOA(txtCOA7)
        '            txtSubl7.Text = String.Empty
        '            txtNamaSubL7.Text = String.Empty
        '    End Select
        'End Sub

        'Private Sub txtSubL_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSubl1.TextChanged, txtSubl2.TextChanged, txtSubl3.TextChanged, txtSubl4.TextChanged, txtSubl5.TextChanged, txtSubl6.TextChanged, txtSubl7.TextChanged
        '    _OpenNamaSubL(CType(sender, TextBox))
        'End Sub

        Private Sub txtKodeLokasi_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtKodeLokasi.TextChanged
            'Dim br As New BussinessRules.FA.lokasi
            'With br
            '    .KdLokasi = New SqlString(txtKodeLokasi.Text.Trim)
            '    If .SelectOne.Rows.Count > 0 Then
            '        txtNamaLokasi.Text = .NmLokasi.Value.Trim
            '    Else
            '        txtNamaLokasi.Text = String.Empty
            '    End If
            'End With
        End Sub
#End Region


#Region " Support functions for navigation bar (Controls) "

        Private Sub InitToolbar()
            With CSSToolbar
                .VisibleButton(CSSToolbarItem.tidApprove) = False
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidNew) = True

                .VisibleButton(CSSToolbarItem.tidPrevious) = True
                .VisibleButton(CSSToolbarItem.tidNext) = True
                .VisibleButton(CSSToolbarItem.tidSave) = True 'AllowEdit(MODULE_ID)
                .VisibleButton(CSSToolbarItem.tidDelete) = False 'AllowDelete(MODULE_ID)
                .VisibleButton(CSSToolbarItem.tidPrint) = True
            End With

        End Sub

        Private Sub CSSToolbar_commandBarClick(ByVal sender As Object, ByVal e As CSSToolbarItem) Handles CSSToolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidVoid
                    'Case CSSToolbarItem.tidDelete
                    '    If txtKodeAktiva.Text = String.Empty Then Exit Select
                    '    Dim br As New BussinessRules.FA.akumulasi

                    '    With br
                    '        If .ProsesCheck(txtKodeAktiva.Text.Trim) = False Then
                    '            '//berarti sudah ada data akumulasi FA yang sudah dijurnal...
                    '            commonFunction.MsgBox(Me, "Data tidak dapat dihapus karena ada data akumulasi Fixed Asset yang sudah dijurnal.")
                    '        Else
                    '            '//berarti belum ada data akumulasi FA yang sudah dijurnal, boleh dihapus...
                    '            _deleteAkumulasiFAAktivaByKdAktiva()
                    '        End If
                    '    End With

                    '    br.Dispose()
                    '    br = Nothing
                Case CSSToolbarItem.tidNew
                    prepareScreen()
                Case CSSToolbarItem.tidNext
                    _Open(BussinessRules.QISRecStatus.NextRecord)
                Case CSSToolbarItem.tidPrevious
                    _Open(BussinessRules.QISRecStatus.PreviousRecord)
                Case CSSToolbarItem.tidSave
                    If txtUmur.Text <> "0" Then
                        _update()
                    Else
                        commonFunction.MsgBox(Me, "Umur harus diisi.")
                    End If
                Case CSSToolbarItem.tidPrint
                    PrinterZebra()

            End Select
        End Sub

#End Region


#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
            '_counterstr = Request.QueryString("i")

            'Return Len(Request.QueryString("i")) > 0
        End Function

        Private Sub prepareScreen()
            'txtKodeBuku.Text = String.Empty
            'txtNamaBuku.Text = String.Empty
            txtKodeAktiva.Text = String.Empty
            txtNamaAktiva.Text = String.Empty
            'txtKodeMetode.Text = "SL"
            '_OpenNamaMetodeFA(BussinessRules.QISRecStatus.CurrentRecord)
            'txtNvPenyusutan.Text = String.Empty
            'txtNvPembelian.Text = String.Empty
            'txtNvPenjualan.Text = String.Empty
            txtHargaBeli.Text = "0.00"
            txtUmur.Text = "0"
            'txtJmlhJual.Text = "0.00"
            'txtNilaiAkhir.Text = "0.00"

            calTglBeli.selectedDate = Date.Now
            'calTglHitung.selectedDate = Date.Now
            'calTglJual.selectedDate = Nothing
            'txtTglPemusnahan.Text = String.Empty

            'txtCOA1.Text = String.Empty
            'txtCOA2.Text = String.Empty
            'txtCOA3.Text = String.Empty
            'txtCOA4.Text = String.Empty
            'txtCOA5.Text = String.Empty
            'txtCOA6.Text = String.Empty
            'txtCOA7.Text = String.Empty

            'txtNamaCOA1.Text = String.Empty
            'txtNamaCOA2.Text = String.Empty
            'txtNamaCOA3.Text = String.Empty
            'txtNamaCOA4.Text = String.Empty
            'txtNamaCOA5.Text = String.Empty
            'txtNamaCOA6.Text = String.Empty
            'txtNamaCOA7.Text = String.Empty

            'txtSubl1.Text = String.Empty
            'txtSubl2.Text = String.Empty
            'txtSubl3.Text = String.Empty
            'txtSubl4.Text = String.Empty
            'txtSubl5.Text = String.Empty
            'txtSubl6.Text = String.Empty
            'txtSubl7.Text = String.Empty

            'txtSubl1.Enabled = False
            'txtSubl2.Enabled = False
            'txtSubl3.Enabled = False
            'txtSubl4.Enabled = False
            'txtSubl5.Enabled = False
            'txtSubl6.Enabled = False
            'txtSubl7.Enabled = False

            'txtNamaSubL1.Text = String.Empty
            'txtNamaSubL2.Text = String.Empty
            'txtNamaSubL3.Text = String.Empty
            'txtNamaSubL4.Text = String.Empty
            'txtNamaSubL5.Text = String.Empty
            'txtNamaSubL6.Text = String.Empty
            'txtNamaSubL7.Text = String.Empty

            'rfvNamaSubL1.Enabled = False
            'rfvNamaSubL2.Enabled = False
            'rfvNamaSubL3.Enabled = False
            'rfvNamaSubL4.Enabled = False
            'rfvNamaSubL5.Enabled = False
            'rfvNamaSubL6.Enabled = False
            'rfvNamaSubL7.Enabled = False

            txtKeterangan.Text = String.Empty
            'txtQtyBeli.Text = "1"
            'txtSatuan.Text = String.Empty
            txtKodeLokasi.Text = String.Empty
            txtNamaLokasi.Text = String.Empty
            txtKodeUser.Text = String.Empty
            txtNamaUser.Text = String.Empty
            txtserialnumber.Text = String.Empty

            'txtKodeKelompok.Text = String.Empty
            'txtNamaKelompok.Text = String.Empty
            'txtNamaVendor.Text = String.Empty
            'txtNoKontrak.Text = String.Empty

            'chkKSO.Checked = False

            'txtTglPemusnahan.Text = String.Empty
            'ddlTypePemusnahan.SelectedIndex = 0
            'txtJmlhJual.Text = "0.00"
            'txtNilaiBuku.Text = "0.00"
            'txtSelisih.Text = "0.00"
            txtKeterangan.Text = String.Empty
            'chkPosting.Checked = False

            UpdateViewGrid()
        End Sub

        Private Sub UpdateViewGrid()
            'Dim br As New BussinessRules.FA.akumulasi

            'br.KdAktiva = New SqlString(txtKodeAktiva.Text.Trim)

            'With gridAkumulasiFA
            '    .DataSource = br.SelectByKdAktiva
            '    .DataBind()
            'End With

            'br.Dispose()
            'br = Nothing
        End Sub
#End Region


#Region " Main Function: Open, Save Delete Data "
        'Private Sub _OpenByMaxTglUpdate()
        '    Dim br As New BussinessRules.FA.aktiva

        '    With br
        '        If .SelectByMaxTglUpdate().Rows.Count > 0 Then
        '            txtKodeAktiva.Text = .KdAktiva.Value.Trim
        '            txtNamaAktiva.Text = .NmAktiva.Value.Trim
        '            txtKodeBuku.Text = .KdBuku.Value.Trim
        '            txtKodeMetode.Text = .KdMtd.Value.Trim
        '            txtNvPenyusutan.Text = .Nov_penyusutan.Value.Trim
        '            txtNvPembelian.Text = .Nov_pembelian.Value.Trim
        '            txtNvPenjualan.Text = .Nov_penjualan.Value.Trim
        '            calTglBeli.selectedDate = .TglBeli.Value
        '            calTglHitung.selectedDate = .TglHitung.Value

        '            If .TglJual.IsNull = True Then
        '                'calTglJual.selectedDate = Nothing
        '                txtTglPemusnahan.Text = String.Empty
        '            Else
        '                'calTglJual.selectedDate = .TglJual.Value
        '                txtTglPemusnahan.Text = Format(.TglJual.Value, commonFunction.FORMAT_DATE)
        '            End If

        '            txtJmlhBeli.Text = Format(.Jml_beli.Value, commonFunction.FORMAT_CURRENCY)
        '            txtUmur.Text = .Umur.ToString.Trim

        '            If .Jml_jual.IsNull = True Then
        '                txtJmlhJual.Text = "0.00"
        '            Else
        '                txtJmlhJual.Text = Format(.Jml_jual.Value, commonFunction.FORMAT_CURRENCY)
        '            End If

        '            If .Jml_akhir.IsNull = True Then
        '                txtNilaiAkhir.Text = "0.00"
        '            Else
        '                txtNilaiAkhir.Text = Format(.Jml_akhir.Value, commonFunction.FORMAT_CURRENCY)
        '            End If

        '            '//open nama buku Fixed Asset...
        '            _OpenNamaBukuFA(BussinessRules.QISRecStatus.CurrentRecord)

        '            txtCOA1.Text = .Coa_aktiva.Value.Trim
        '            txtCOA2.Text = .Coa_penyusutan.Value.Trim
        '            txtCOA3.Text = .Coa_depresiasi.Value.Trim
        '            txtCOA4.Text = .Coa_tanggungan.Value.Trim
        '            txtCOA5.Text = .Coa_pendapatan.Value.Trim
        '            txtCOA6.Text = .Coa_biaya.Value.Trim
        '            txtCOA7.Text = .Coa_eliminasi.Value.Trim
        '            txtSubl1.Text = .Subl_aktiva.Value.Trim
        '            txtSubl2.Text = .Subl_penyusutan.Value.Trim
        '            txtSubl3.Text = .Subl_depresiasi.Value.Trim
        '            txtSubl4.Text = .Subl_tanggungan.Value.Trim
        '            txtSubl5.Text = .Subl_pendapatan.Value.Trim
        '            txtSubl6.Text = .Subl_biaya.Value.Trim
        '            txtSubl7.Text = .Subl_eliminasi.Value.Trim

        '            txtKeterangan.Text = .keterangan.Value.Trim

        '            txtQtyBeli.Text = .QtyBeli.ToString.Trim
        '            txtSatuan.Text = .Satuan.Value.Trim

        '            txtKodeLokasi.Text = .KdLokasi.ToString.Trim
        '            txtserialnumber.Text = .serialnumber.ToString.Trim


        '            '//open nama Metode Fixed Asset...
        '            _OpenNamaMetodeFA(BussinessRules.QISRecStatus.CurrentRecord)
        '            '//open nama coa1
        '            _OpenNamaCOA(txtCOA1)
        '            '//open nama coa2
        '            _OpenNamaCOA(txtCOA2)
        '            '//open nama coa3
        '            _OpenNamaCOA(txtCOA3)
        '            '//open nama coa4
        '            _OpenNamaCOA(txtCOA4)
        '            '//open nama coa5
        '            _OpenNamaCOA(txtCOA5)
        '            '//open nama coa6
        '            _OpenNamaCOA(txtCOA6)
        '            '//open nama coa7
        '            _OpenNamaCOA(txtCOA7)
        '            '//open nama SubL1
        '            _OpenNamaSubL(txtSubl1)
        '            '//open nama SubL2
        '            _OpenNamaSubL(txtSubl2)
        '            '//open nama SubL3
        '            _OpenNamaSubL(txtSubl3)
        '            '//open nama SubL4
        '            _OpenNamaSubL(txtSubl4)
        '            '//open nama SubL5
        '            _OpenNamaSubL(txtSubl5)
        '            '//open nama SubL6
        '            _OpenNamaSubL(txtSubl6)
        '            '//open nama SubL7
        '            _OpenNamaSubL(txtSubl7)

        '            _OpenNamaLokasiFA()

        '            _OpenPemusnahanFA()
        '        Else
        '            txtKodeAktiva.Text = String.Empty
        '            txtNamaAktiva.Text = String.Empty
        '            txtKodeBuku.Text = String.Empty
        '            txtNamaBuku.Text = String.Empty
        '            txtKodeMetode.Text = "SL"
        '            _OpenNamaMetodeFA(BussinessRules.QISRecStatus.CurrentRecord)
        '            txtNvPenyusutan.Text = String.Empty
        '            txtNvPembelian.Text = String.Empty
        '            txtNvPenjualan.Text = String.Empty
        '            calTglBeli.selectedDate = Date.Now
        '            calTglHitung.selectedDate = Date.Now
        '            'calTglJual.selectedDate = Nothing
        '            txtTglPemusnahan.Text = String.Empty
        '            txtJmlhBeli.Text = "0.00"
        '            txtUmur.Text = "0"
        '            txtJmlhJual.Text = "0.00"
        '            txtNilaiAkhir.Text = "0.00"
        '            txtCOA1.Text = String.Empty
        '            txtCOA2.Text = String.Empty
        '            txtCOA3.Text = String.Empty
        '            txtCOA4.Text = String.Empty
        '            txtCOA5.Text = String.Empty
        '            txtCOA6.Text = String.Empty
        '            txtCOA7.Text = String.Empty
        '            txtNamaCOA1.Text = String.Empty
        '            txtNamaCOA2.Text = String.Empty
        '            txtNamaCOA3.Text = String.Empty
        '            txtNamaCOA4.Text = String.Empty
        '            txtNamaCOA5.Text = String.Empty
        '            txtNamaCOA6.Text = String.Empty
        '            txtNamaCOA7.Text = String.Empty
        '            txtSubl1.Text = String.Empty
        '            txtSubl2.Text = String.Empty
        '            txtSubl3.Text = String.Empty
        '            txtSubl4.Text = String.Empty
        '            txtSubl5.Text = String.Empty
        '            txtSubl6.Text = String.Empty
        '            txtSubl7.Text = String.Empty
        '            txtSubl1.Enabled = False
        '            txtSubl2.Enabled = False
        '            txtSubl3.Enabled = False
        '            txtSubl4.Enabled = False
        '            txtSubl5.Enabled = False
        '            txtSubl6.Enabled = False
        '            txtSubl7.Enabled = False
        '            txtNamaSubL1.Text = String.Empty
        '            txtNamaSubL2.Text = String.Empty
        '            txtNamaSubL3.Text = String.Empty
        '            txtNamaSubL4.Text = String.Empty
        '            txtNamaSubL5.Text = String.Empty
        '            txtNamaSubL6.Text = String.Empty
        '            txtNamaSubL7.Text = String.Empty
        '            txtKeterangan.Text = String.Empty
        '            txtQtyBeli.Text = "1"
        '            txtSatuan.Text = String.Empty
        '            txtKodeLokasi.Text = String.Empty
        '            txtNamaLokasi.Text = String.Empty
        '            txtserialnumber.Text = String.Empty

        '            txtTglPemusnahan.Text = String.Empty
        '            ddlTypePemusnahan.SelectedIndex = 0
        '            txtJmlhJual.Text = "0.00"
        '            txtNilaiBuku.Text = "0.00"
        '            txtSelisih.Text = "0.00"
        '            txtKeterangan.Text = String.Empty
        '        End If
        '    End With
        '    br.Dispose()
        '    br = Nothing

        '    UpdateViewGrid()
        '    commonFunction.Focus(Me, txtKodeAktiva.ClientID)
        'End Sub

        Private Sub _Open(ByVal RecStatus As BussinessRules.QISRecStatus)
            'If Len(txtKodeAktiva.Text.Trim) = 0 Then Exit Sub

            ' ''Dim br As New BussinessRules.FA.aktiva

            'With br
            '    .KdAktiva = New SqlString(Trim(txtKodeAktiva.Text))

            '    If .SelectOne(RecStatus).Rows.Count > 0 Then
            '        If Not RecStatus = BussinessRules.QISRecStatus.CurrentRecord Then txtKodeAktiva.Text = .KdAktiva.Value
            '        txtNamaAktiva.Text = .NmAktiva.Value.Trim
            '        'txtKodeBuku.Text = .KdBuku.Value.Trim
            '        'txtKodeMetode.Text = .KdMtd.Value.Trim
            '        'txtNvPenyusutan.Text = .Nov_penyusutan.Value.Trim
            '        'txtNvPembelian.Text = .Nov_pembelian.Value.Trim
            '        'txtNvPenjualan.Text = .Nov_penjualan.Value.Trim
            '        calTglBeli.selectedDate = .TglBeli.Value
            '        'calTglHitung.selectedDate = .TglHitung.Value

            '        'If .TglJual.IsNull = True Then
            '        '    'calTglJual.selectedDate = Nothing
            '        '    txtTglPemusnahan.Text = String.Empty
            '        'Else
            '        '    'calTglJual.selectedDate = .TglJual.Value
            '        '    txtTglPemusnahan.Text = Format(.TglJual.Value, commonFunction.FORMAT_DATE)
            '        'End If

            '        'txtJmlhBeli.Text = Format(.Jml_beli.Value, commonFunction.FORMAT_CURRENCY)
            '        txtUmur.Text = .Umur.ToString.Trim

            '        'If .Jml_jual.IsNull = True Then
            '        '    txtJmlhJual.Text = "0.00"
            '        'Else
            '        '    txtJmlhJual.Text = Format(.Jml_jual.Value, commonFunction.FORMAT_CURRENCY)
            '        'End If

            '        'If .Jml_akhir.IsNull = True Then
            '        '    txtNilaiAkhir.Text = "0.00"
            '        'Else
            '        '    txtNilaiAkhir.Text = Format(.Jml_akhir.Value, commonFunction.FORMAT_CURRENCY)
            '        'End If

            '        '//open nama buku Fixed Asset...
            '        '_OpenNamaBukuFA(BussinessRules.QISRecStatus.CurrentRecord)

            '        'txtCOA1.Text = .Coa_aktiva.Value.Trim
            '        'txtCOA2.Text = .Coa_penyusutan.Value.Trim
            '        'txtCOA3.Text = .Coa_depresiasi.Value.Trim
            '        'txtCOA4.Text = .Coa_tanggungan.Value.Trim
            '        'txtCOA5.Text = .Coa_pendapatan.Value.Trim
            '        'txtCOA6.Text = .Coa_biaya.Value.Trim
            '        'txtCOA7.Text = .Coa_eliminasi.Value.Trim
            '        'txtSubl1.Text = .Subl_aktiva.Value.Trim
            '        'txtSubl2.Text = .Subl_penyusutan.Value.Trim
            '        'txtSubl3.Text = .Subl_depresiasi.Value.Trim
            '        'txtSubl4.Text = .Subl_tanggungan.Value.Trim
            '        'txtSubl5.Text = .Subl_pendapatan.Value.Trim
            '        'txtSubl6.Text = .Subl_biaya.Value.Trim
            '        'txtSubl7.Text = .Subl_eliminasi.Value.Trim

            '        txtKeterangan.Text = .keterangan.Value.Trim

            '        'txtQtyBeli.Text = .QtyBeli.ToString.Trim
            '        txtKodeLokasi.Text = .KdLokasi.Value.Trim
            '        'txtSatuan.Text = .Satuan.Value.Trim
            '        txtserialnumber.Text = .serialnumber.ToString.Trim

            '        'chkKSO.Checked = .KSO.Value

            '        'txtKodeKelompok.Text = .KdKelompokAktiva.Value.Trim
            '        'txtNamaVendor.Text = .NmVendor.Value.Trim
            '        'txtNoKontrak.Text = .NoKontrak.Value.Trim

            '        ''//open nama Metode Fixed Asset...
            '        '_OpenNamaMetodeFA(BussinessRules.QISRecStatus.CurrentRecord)
            '        ''//open nama coa1
            '        '_OpenNamaCOA(txtCOA1)
            '        ''//open nama coa2
            '        '_OpenNamaCOA(txtCOA2)
            '        ''//open nama coa3
            '        '_OpenNamaCOA(txtCOA3)
            '        ''//open nama coa4
            '        '_OpenNamaCOA(txtCOA4)
            '        ''//open nama coa5
            '        '_OpenNamaCOA(txtCOA5)
            '        ''//open nama coa6
            '        '_OpenNamaCOA(txtCOA6)
            '        ''//open nama coa7
            '        '_OpenNamaCOA(txtCOA7)
            '        ''//open nama SubL1
            '        '_OpenNamaSubL(txtSubl1)
            '        ''//open nama SubL2
            '        '_OpenNamaSubL(txtSubl2)
            '        ''//open nama SubL3
            '        '_OpenNamaSubL(txtSubl3)
            '        ''//open nama SubL4
            '        '_OpenNamaSubL(txtSubl4)
            '        ''//open nama SubL5
            '        '_OpenNamaSubL(txtSubl5)
            '        ''//open nama SubL6
            '        '_OpenNamaSubL(txtSubl6)
            '        ''//open nama SubL7
            '        '_OpenNamaSubL(txtSubl7)
            '        ''//open nama lokasi FA
            '        '_OpenNamaLokasiFA()
            '        ''//open nama Kelompok FA
            '        '_OpenKelompokFA()

            '        '_OpenPemusnahanFA()
            '    Else
            '        If Not RecStatus = BussinessRules.QISRecStatus.CurrentRecord Then Exit Sub
            '        txtNamaAktiva.Text = String.Empty
            '        'txtKodeBuku.Text = String.Empty
            '        'txtNamaBuku.Text = String.Empty
            '        'txtKodeMetode.Text = "SL"
            '        '_OpenNamaMetodeFA(BussinessRules.QISRecStatus.CurrentRecord)
            '        'txtNvPenyusutan.Text = String.Empty
            '        'txtNvPembelian.Text = String.Empty
            '        'txtNvPenjualan.Text = String.Empty
            '        calTglBeli.selectedDate = Date.Now
            '        'calTglHitung.selectedDate = Date.Now
            '        'calTglJual.selectedDate = Nothing
            '        'txtTglPemusnahan.Text = String.Empty
            '        'txtJmlhBeli.Text = "0.00"
            '        txtUmur.Text = "0"
            '        'txtJmlhJual.Text = "0.00"
            '        'txtNilaiAkhir.Text = "0.00"
            '        'txtCOA1.Text = String.Empty
            '        'txtCOA2.Text = String.Empty
            '        'txtCOA3.Text = String.Empty
            '        'txtCOA4.Text = String.Empty
            '        'txtCOA5.Text = String.Empty
            '        'txtCOA6.Text = String.Empty
            '        'txtCOA7.Text = String.Empty
            '        'txtNamaCOA1.Text = String.Empty
            '        'txtNamaCOA2.Text = String.Empty
            '        'txtNamaCOA3.Text = String.Empty
            '        'txtNamaCOA4.Text = String.Empty
            '        'txtNamaCOA5.Text = String.Empty
            '        'txtNamaCOA6.Text = String.Empty
            '        'txtNamaCOA7.Text = String.Empty
            '        'txtSubl1.Text = String.Empty
            '        'txtSubl2.Text = String.Empty
            '        'txtSubl3.Text = String.Empty
            '        'txtSubl4.Text = String.Empty
            '        'txtSubl5.Text = String.Empty
            '        'txtSubl6.Text = String.Empty
            '        'txtSubl7.Text = String.Empty
            '        'txtSubl1.Enabled = False
            '        'txtSubl2.Enabled = False
            '        'txtSubl3.Enabled = False
            '        'txtSubl4.Enabled = False
            '        'txtSubl5.Enabled = False
            '        'txtSubl6.Enabled = False
            '        'txtSubl7.Enabled = False
            '        'txtNamaSubL1.Text = String.Empty
            '        'txtNamaSubL2.Text = String.Empty
            '        'txtNamaSubL3.Text = String.Empty
            '        'txtNamaSubL4.Text = String.Empty
            '        'txtNamaSubL5.Text = String.Empty
            '        'txtNamaSubL6.Text = String.Empty
            '        'txtNamaSubL7.Text = String.Empty
            '        txtKeterangan.Text = String.Empty
            '        'txtQtyBeli.Text = "1"
            '        'txtSatuan.Text = String.Empty
            '        txtKodeLokasi.Text = String.Empty
            '        txtNamaLokasi.Text = String.Empty
            '        txtserialnumber.Text = String.Empty
            '        'chkKSO.Checked = False

            '        'txtTglPemusnahan.Text = String.Empty
            '        'ddlTypePemusnahan.SelectedIndex = 0
            '        'txtJmlhJual.Text = "0.00"
            '        'txtNilaiBuku.Text = "0.00"
            '        'txtSelisih.Text = "0.00"
            '        'txtKeterangan.Text = String.Empty
            '        'chkPosting.Checked = False
            '    End If
            'End With
            'br.Dispose()
            'br = Nothing

            UpdateViewGrid()
            commonFunction.Focus(Me, txtNamaAktiva.ClientID)
        End Sub

        'Private Sub _OpenNamaBukuFA(ByVal RecStatus As BussinessRules.QISRecStatus)
        '    Dim br As New BussinessRules.FA.buku

        '    With br
        '        .KdBuku = New SqlString(txtKodeBuku.Text)
        '        If .SelectOne(RecStatus).Rows.Count > 0 Then
        '            txtNamaBuku.Text = .NmBuku.Value.Trim
        '            txtKodeMetode.Text = .KdMtd.Value.Trim
        '            txtCOA1.Text = .Coa_aktiva.Value.Trim
        '            txtCOA2.Text = .Coa_penyusutan.Value.Trim
        '            txtCOA3.Text = .Coa_depresiasi.Value.Trim
        '            txtCOA4.Text = .Coa_tanggungan.Value.Trim
        '            txtCOA5.Text = .Coa_pendapatan.Value.Trim
        '            txtCOA6.Text = .Coa_biaya.Value.Trim
        '            txtCOA7.Text = .Coa_eliminasi.Value.Trim
        '            txtSubl1.Text = .Subl_aktiva.Value.Trim
        '            txtSubl2.Text = .Subl_penyusutan.Value.Trim
        '            txtSubl3.Text = .Subl_depresiasi.Value.Trim
        '            txtSubl4.Text = .Subl_tanggungan.Value.Trim
        '            txtSubl5.Text = .Subl_pendapatan.Value.Trim
        '            txtSubl6.Text = .Subl_biaya.Value.Trim
        '            txtSubl7.Text = .Subl_eliminasi.Value.Trim
        '            _OpenNamaMetodeFA(BussinessRules.QISRecStatus.CurrentRecord)
        '            _OpenNamaCOA(txtCOA1)
        '            _OpenNamaCOA(txtCOA2)
        '            _OpenNamaCOA(txtCOA3)
        '            _OpenNamaCOA(txtCOA4)
        '            _OpenNamaCOA(txtCOA5)
        '            _OpenNamaCOA(txtCOA6)
        '            _OpenNamaCOA(txtCOA7)
        '            _OpenNamaSubL(txtSubl1)
        '            _OpenNamaSubL(txtSubl2)
        '            _OpenNamaSubL(txtSubl3)
        '            _OpenNamaSubL(txtSubl4)
        '            _OpenNamaSubL(txtSubl5)
        '            _OpenNamaSubL(txtSubl6)
        '            _OpenNamaSubL(txtSubl7)
        '        Else
        '            txtKodeBuku.Text = String.Empty
        '            txtNamaBuku.Text = String.Empty
        '            txtKodeMetode.Text = "SL"
        '            'txtNamaMetode.Text = String.Empty
        '            _OpenNamaMetodeFA(BussinessRules.QISRecStatus.CurrentRecord)
        '            txtCOA1.Text = String.Empty
        '            txtCOA2.Text = String.Empty
        '            txtCOA3.Text = String.Empty
        '            txtCOA4.Text = String.Empty
        '            txtCOA5.Text = String.Empty
        '            txtCOA6.Text = String.Empty
        '            txtCOA7.Text = String.Empty
        '            txtSubl1.Text = String.Empty
        '            txtSubl2.Text = String.Empty
        '            txtSubl3.Text = String.Empty
        '            txtSubl4.Text = String.Empty
        '            txtSubl5.Text = String.Empty
        '            txtSubl6.Text = String.Empty
        '            txtSubl7.Text = String.Empty
        '            txtNamaCOA1.Text = String.Empty
        '            txtNamaCOA2.Text = String.Empty
        '            txtNamaCOA3.Text = String.Empty
        '            txtNamaCOA4.Text = String.Empty
        '            txtNamaCOA5.Text = String.Empty
        '            txtNamaCOA6.Text = String.Empty
        '            txtNamaCOA7.Text = String.Empty
        '            txtNamaSubL1.Text = String.Empty
        '            txtNamaSubL2.Text = String.Empty
        '            txtNamaSubL3.Text = String.Empty
        '            txtNamaSubL4.Text = String.Empty
        '            txtNamaSubL5.Text = String.Empty
        '            txtNamaSubL6.Text = String.Empty
        '            txtNamaSubL7.Text = String.Empty
        '        End If
        '    End With
        '    br.Dispose()
        '    br = Nothing
        'End Sub

        'Private Sub _OpenNamaMetodeFA(ByVal RecStatus As BussinessRules.QISRecStatus)
        '    Dim br As New BussinessRules.FA.metode

        '    With br
        '        .KdMtd = New SqlString(txtKodeMetode.Text)
        '        If .SelectOne(RecStatus).Rows.Count > 0 Then
        '            txtNamaMetode.Text = .NmMtd.Value.Trim
        '        Else
        '            txtKodeMetode.Text = String.Empty
        '            txtNamaMetode.Text = String.Empty
        '        End If
        '    End With
        '    br.Dispose()
        '    br = Nothing
        'End Sub

        Private Sub _OpenNamaLokasiFA()
            'Dim br As New BussinessRules.FA.lokasi

            'With br
            '    .KdLokasi = New SqlString(txtKodeLokasi.Text)
            '    If .SelectOne().Rows.Count > 0 Then
            '        txtNamaLokasi.Text = .NmLokasi.Value.Trim
            '    Else
            '        txtKodeLokasi.Text = String.Empty
            '        txtNamaLokasi.Text = String.Empty
            '    End If
            'End With
            'br.Dispose()
            'br = Nothing
        End Sub

        'Private Sub _OpenKelompokFA()
        '    Dim br As New BussinessRules.FA.KelompokFa

        '    With br
        '        .KdKelompokAktiva = New SqlString(txtKodeKelompok.Text.Trim)
        '        If .SelectOne.Rows.Count > 0 Then
        '            txtNamaKelompok.Text = .NmKelompokAktiva.Value.Trim
        '        Else
        '            txtKodeKelompok.Text = String.Empty
        '            txtNamaKelompok.Text = String.Empty
        '        End If
        '    End With

        '    br.Dispose()
        '    br = Nothing
        'End Sub

        'Private Sub _OpenNamaCOA(ByVal txt As TextBox)
        '    Dim txtCOA As TextBox = CType(Me.FindControl("txtCOA" + Right(txt.ID, 1)), TextBox)
        '    Dim txtNamaCOA As TextBox = CType(Me.FindControl("txtNamaCOA" + Right(txt.ID, 1)), TextBox)
        '    Dim txtGroupSubL As TextBox = CType(Me.FindControl("txtGroupSubL" + Right(txt.ID, 1)), TextBox)
        '    Dim txtSubL As TextBox = CType(Me.FindControl("txtSubL" + Right(txt.ID, 1)), TextBox)
        '    Dim txtNamaSubL As TextBox = CType(Me.FindControl("txtNamaSubL" + Right(txt.ID, 1)), TextBox)
        '    Dim txtGd As TextBox = CType(Me.FindControl("txtGd" + Right(txt.ID, 1)), TextBox)
        '    Dim rfvNamaSubL As RequiredFieldValidator = CType(Me.FindControl("rfvNamaSubL" + Right(txt.ID, 1)), RequiredFieldValidator)

        '    If Len(txt.Text.Trim) = 0 Then
        '        txtNamaCOA.Text = String.Empty
        '        txtGroupSubL.Text = String.Empty
        '        txtSubL.Text = String.Empty
        '        txtNamaSubL.Text = String.Empty
        '        txtSubL.Enabled = False
        '        txtNamaSubL.Enabled = False
        '        rfvNamaSubL.Enabled = False
        '        Exit Sub
        '    End If

        '    Dim br As New BussinessRules.GL.coa
        '    With br
        '        .KdCoa = txt.Text.Trim

        '        If .SelectOne().Rows.Count > 0 Then
        '            txtNamaCOA.Text = .Napek.Trim
        '            txtGroupSubL.Text = .KdGsl.Trim
        '            txtGd.Text = .Gd.ToString.Trim
        '            If (txtGd.Text = "1") Then
        '                '//Kalau kode perkiraan yang dimasukkan adalah general
        '                commonFunction.MsgBox(Me, "Kode perkiraan general tidak dapat dijurnal.")
        '                txtCOA.Text = String.Empty
        '                txtNamaCOA.Text = String.Empty
        '                txtGroupSubL.Text = String.Empty
        '                txtSubL.Text = String.Empty
        '                txtNamaSubL.Text = String.Empty
        '                txtSubL.Enabled = False
        '                txtNamaSubL.Enabled = False
        '                rfvNamaSubL.Enabled = False
        '            Else
        '                If (txtGroupSubL.Text = "none") Then
        '                    '//Kalau kode perkiraan yang dimasukkan tidak memiliki GroupSubLedger
        '                    txtSubL.Enabled = False
        '                    txtNamaSubL.Enabled = False
        '                    txtSubL.Text = String.Empty
        '                    txtNamaSubL.Text = String.Empty
        '                    rfvNamaSubL.Enabled = False
        '                Else
        '                    txtSubL.Enabled = True
        '                    txtNamaSubL.Enabled = True
        '                    rfvNamaSubL.Enabled = True
        '                End If '//If (txtGroupSubL.Text = "none") Then
        '            End If '//If (txtGd.Text = "1") Then
        '        Else
        '            txtCOA.Text = String.Empty
        '            txtNamaCOA.Text = String.Empty
        '            txtGroupSubL.Text = String.Empty
        '            txtSubL.Text = String.Empty
        '            txtNamaSubL.Text = String.Empty
        '            txtSubL.Enabled = False
        '            txtNamaSubL.Enabled = False
        '            rfvNamaSubL.Enabled = False
        '        End If '//If .SelectOne().Rows.Count > 0 Then
        '    End With
        '    br.Dispose()
        '    br = Nothing
        'End Sub

        'Private Sub _OpenNamaSubL(ByVal txt As TextBox)
        '    Dim txtSubL As TextBox = CType(Me.FindControl("txtSubL" + Right(txt.ID, 1)), TextBox)
        '    Dim txtNamaSubL As TextBox = CType(Me.FindControl("txtNamaSubL" + Right(txt.ID, 1)), TextBox)

        '    If Len(txt.Text.Trim) = 0 Then
        '        txtNamaSubL.Text = String.Empty
        '        Exit Sub
        '    End If

        '    Dim br As New BussinessRules.GL.subLedger
        '    With br
        '        .kdSubLedger = New SqlString(txt.Text.Trim)

        '        If .SelectOne().Rows.Count > 0 Then
        '            txtNamaSubL.Text = .nmSubLedger.Value.Trim
        '        Else
        '            txtSubL.Text = String.Empty
        '            txtNamaSubL.Text = String.Empty
        '        End If
        '    End With
        '    br.Dispose()
        '    br = Nothing
        'End Sub

        'Private Sub _OpenPemusnahanFA()
        '    '// Open Informasi Pemusnahan Aktiva Tetap
        '    Dim oEliminasi As New BussinessRules.FA.Pemusnahan

        '    oEliminasi.kdAktiva = txtKodeAktiva.Text.Trim
        '    If oEliminasi.SelectOne.Rows.Count > 0 Then
        '        txtTglPemusnahan.Text = Format(oEliminasi.TglPemusnahan, commonFunction.FORMAT_DATE)
        '        commonFunction.SelectListItem(ddlTypePemusnahan, oEliminasi.TypePemusnahan.Trim)
        '        txtJmlhJual.Text = Format(oEliminasi.NilaiPemusnahan, commonFunction.FORMAT_CURRENCY)
        '        txtNilaiBuku.Text = Format(oEliminasi.NilaiBuku, commonFunction.FORMAT_CURRENCY)
        '        txtSelisih.Text = Format(oEliminasi.Selisih, commonFunction.FORMAT_CURRENCY)
        '        txtKeteranganPemusnahan.Text = oEliminasi.keterangan.Trim
        '        chkPosting.Checked = oEliminasi.Posting
        '    Else
        '        txtTglPemusnahan.Text = String.Empty
        '        ddlTypePemusnahan.SelectedIndex = 0
        '        txtJmlhJual.Text = "0.00"
        '        txtNilaiBuku.Text = "0.00"
        '        txtSelisih.Text = "0.00"
        '        txtKeteranganPemusnahan.Text = String.Empty
        '        chkPosting.Checked = False
        '    End If

        '    oEliminasi.Dispose()
        '    oEliminasi = Nothing
        'End Sub

        Private Sub _delete()
            'If Len(txtKodeAktiva.Text.Trim) = 0 Then Exit Sub

            'Dim br As New BussinessRules.FA.aktiva

            'With br
            '    .KdAktiva = New SqlString(Trim(txtKodeAktiva.Text))
            '    If .Delete Then
            '        prepareScreen()
            '    End If
            'End With
            'br.Dispose()
            'br = Nothing

            prepareScreen()
        End Sub

        'Private Sub _deleteAkumulasiFAAktivaByKdAktiva()
        '    If Len(txtKodeAktiva.Text.Trim) = 0 Then Exit Sub

        '    Dim br As New BussinessRules.FA.aktiva

        '    With br
        '        .KdAktiva = New SqlString(Trim(txtKodeAktiva.Text))

        '        If .DeleteAkumulasiFAAktivaByKdAktiva Then
        '            prepareScreen()
        '        End If
        '    End With
        '    br.Dispose()
        '    br = Nothing

        '    prepareScreen()
        'End Sub

        Private Sub _update()
            Page.Validate()
            If Not Page.IsValid Then Exit Sub

            'Dim br As New BussinessRules.FA.aktiva
            'Dim fNotNew As Boolean = False

            'Dim ovar As New SetVar

            'With br
            '    .KdAktiva = New SqlString(txtKodeAktiva.Text.Trim)

            '    fNotNew = (.SelectOne.Rows.Count > 0)

            '    .NmAktiva = New SqlString(txtNamaAktiva.Text.Trim)
            '    '.KdBuku = New SqlString(txtKodeBuku.Text.Trim)
            '    '.KdMtd = New SqlString(txtKodeMetode.Text.Trim)
            '    '.Nov_penyusutan = New SqlString(txtNvPenyusutan.Text.Trim)
            '    '.Nov_pembelian = New SqlString(txtNvPembelian.Text.Trim)
            '    '.Nov_penjualan = New SqlString(txtNvPenjualan.Text.Trim)
            '    .TglBeli = New SqlDateTime(calTglBeli.selectedDate)
            '    '.TglHitung = New SqlDateTime(calTglHitung.selectedDate)
            '    'If calTglJual.selectedDate = Nothing Then
            '    '    .TglJual = SqlDateTime.Null
            '    'Else
            '    '    .TglJual = New SqlDateTime(calTglJual.selectedDate)
            '    'End If
            '    'If txtTglPemusnahan.Text = String.Empty Then
            '    '    .TglJual = SqlDateTime.Null
            '    'Else
            '    '    .TglJual = New SqlDateTime(CDate(Right(txtTglPemusnahan.Text.Trim, 4) + Mid(txtTglPemusnahan.Text.Trim, 4, 2) + Left(txtTglPemusnahan.Text.Trim, 2)))
            '    'End If
            '    '.Jml_beli = New SqlMoney(CDec(txtJmlhBeli.Text.Trim))
            '    .Umur = New SqlInt32(CInt(txtUmur.Text.Trim))
            '    '.Jml_jual = New SqlMoney(CDec(txtJmlhJual.Text.Trim))
            '    '.Jml_akhir = New SqlMoney(CDec(txtNilaiAkhir.Text.Trim))
            '    '.Coa_aktiva = New SqlString(txtCOA1.Text.Trim)
            '    '.Coa_penyusutan = New SqlString(txtCOA2.Text.Trim)
            '    '.Coa_depresiasi = New SqlString(txtCOA3.Text.Trim)
            '    '.Coa_tanggungan = New SqlString(txtCOA4.Text.Trim)
            '    '.Coa_pendapatan = New SqlString(txtCOA5.Text.Trim)
            '    '.Coa_biaya = New SqlString(txtCOA6.Text.Trim)
            '    '.Coa_eliminasi = New SqlString(txtCOA7.Text.Trim)
            '    '.Subl_aktiva = New SqlString(txtSubl1.Text.Trim)
            '    '.Subl_penyusutan = New SqlString(txtSubl2.Text.Trim)
            '    '.Subl_depresiasi = New SqlString(txtSubl3.Text.Trim)
            '    '.Subl_tanggungan = New SqlString(txtSubl4.Text.Trim)
            '    '.Subl_pendapatan = New SqlString(txtSubl5.Text.Trim)
            '    '.Subl_biaya = New SqlString(txtSubl6.Text.Trim)
            '    '.Subl_eliminasi = New SqlString(txtSubl7.Text.Trim)
            '    .Usrinsert = New SqlString(MyBase.LoggedOnUserID)
            '    .Usrupdate = New SqlString(MyBase.LoggedOnUserID)
            '    .Tglinsert = New SqlDateTime(Date.Now)
            '    .Tglupdate = New SqlDateTime(Date.Now)
            '    .keterangan = New SqlString(txtKeterangan.Text.Trim)
            '    ''.QtyBeli = New SqlInt32(CInt(txtQtyBeli.Text.Trim))
            '    .KdLokasi = New SqlString(txtKodeLokasi.Text.Trim)
            '    '.Satuan = New SqlString(txtSatuan.Text.Trim)
            '    .serialnumber = New SqlString(txtserialnumber.Text)
            '    '.KSO = New SqlBoolean(chkKSO.Checked)
            '    'If Not (txtnoterima.Text.Trim = String.Empty) Then
            '    '    .noterima = New SqlString(txtnoterima.Text.Trim)
            '    '    .counterTerima = New SqlGuid(txtcounterpenerimaan.Text)
            '    'End If

            '    Dim Max As String = ""

            '    ' // set the new value
            '    'If Common.Methods.GetSettingParameter("fKdAktivaCreateOtomatis", Common.Constants.ModuleID.GENERAL_LEDGER) = "1" Then
            '    '    rfvKodeAktiva.Enabled = False
            '    '    If Len(Trim(txtKodeAktiva.Text)) = 0 Then
            '    '        Max = .NewTransactionNumber(Common.Methods.GetSettingParameter("Prefix_KodeRS_KdAktiva", Common.Constants.ModuleID.GENERAL_LEDGER), commonFunction.CDate(CType(calTglBeli.selectedDate, String))).Value
            '    '        .KdAktiva = New SqlString(Trim(Max))
            '    '        txtKodeAktiva.Text = Trim(Max)
            '    '    Else
            '    '        .KdAktiva = New SqlString(Trim(txtKodeAktiva.Text))
            '    '    End If
            '    'Else
            '    '    rfvKodeAktiva.Enabled = True
            '    '    .KdAktiva = New SqlString(Trim(txtKodeAktiva.Text))
            '    'End If

            '    ''.KdKelompokAktiva = New SqlString(txtKodeKelompok.Text.Trim)
            '    ''.NmVendor = New SqlString(txtNamaVendor.Text.Trim)
            '    ''.NoKontrak = New SqlString(txtNoKontrak.Text.Trim)

            '    If fNotNew Then
            '        .Update()
            '    Else
            '        'If Not (txtnoterima.Text.Trim = String.Empty) Then
            '        '    .InsertAktivaDanLogistik()
            '        'Else
            '        .Insert()
            '        'End If
            '    End If
            'End With
            'br.Dispose()
            'br = Nothing

            'prepareScreen()
            commonFunction.Focus(Me, txtKodeAktiva.ClientID)
        End Sub

        'Private Function _prosesAkumulasiFAByKdBukuKdAktiva() As Boolean
        '    Page.Validate()
        '    If Not Page.IsValid Then Exit Function

        '    Dim br As New BussinessRules.FA.akumulasi
        '    Dim sv As New SetVar
        '    Dim b As Boolean

        '    Dim fNotNew As Boolean = False

        '    sv.app = New SqlString("GL_")

        '    '// liat di SetVar untuk kode: fa_fAkmPenyHarian
        '    If Common.Methods.GetSettingParameter("fa_fAkmPenyHarian", "GL_") = "1" Then
        '        '// Proses Akumulasi Penyusutan FA per hari
        '        If br.ProsesAkumulasiFAByKdBukuKdAktivaPerHari("", txtKodeAktiva.Text.Trim) = True Then
        '            b = True
        '        Else
        '            b = False
        '        End If
        '    Else
        '        '// Proses Akumulasi Penyusutan FA per bulan
        '        If br.ProsesAkumulasiFAByKdBukuKdAktivaSLDD("", txtKodeAktiva.Text.Trim) = True Then
        '            b = True
        '        Else
        '            b = False
        '        End If
        '    End If

        '    br.Dispose()
        '    br = Nothing

        '    UpdateViewGrid()

        '    Return b
        'End Function

        'Private Sub _batalProsesJurnalFA()
        '    Page.Validate()
        '    If Not Page.IsValid Then Exit Sub

        '    Dim i As Integer = 0
        '    Dim totalRowSelected As Integer = 0
        '    Dim tblTmp As New DataTable

        '    With tblTmp
        '        .Columns.Add("counterJurnalHeader", System.Type.GetType("System.String"))
        '        .Columns.Add("counter", System.Type.GetType("System.String"))
        '    End With

        '    Dim _item As DataGridItem

        '    For Each _item In gridAkumulasiFA.Items
        '        Dim _chkPesan As CheckBox = CType(_item.FindControl("gridAkumulasiFA_chkPilih"), CheckBox)
        '        Dim _lblCounterJurnalHeader As Label = CType(_item.FindControl("_lblCounterJurnalHeader"), Label)
        '        Dim _lblCounter As Label = CType(_item.FindControl("_lblCounter"), Label)

        '        If _chkPesan.Checked = True Then
        '            totalRowSelected += 1

        '            Dim row As DataRow = tblTmp.NewRow

        '            row("counterJurnalHeader") = _lblCounterJurnalHeader.Text.Trim
        '            row("counter") = _lblCounter.Text.Trim

        '            tblTmp.Rows.Add(row)
        '        End If
        '    Next

        '    Dim br As New BussinessRules.GL.jurnalHeader
        '    Dim fa As New BussinessRules.FA.akumulasi

        '    With br
        '        For Each row As DataRow In tblTmp.Rows
        '            .Counter = ProcessNull.GetDecimal(row("counterJurnalHeader"))
        '            .CounterAkumulasiFA = ProcessNull.GetDecimal(row("counter"))
        '            '//cek status postingnya apakh True atau False berdasarkan counterAkumulasi
        '            .SelectStatusPostingAkumulasiFA()
        '            If (.FPosting.Value = True) Then
        '                '//berarti jurnalnya sudah di-Posting dan tidak dapat dibatalkan prosesnya
        '                commonFunction.MsgBox(Me, "Jurnal sudah di-Posting.")
        '                Exit For
        '            Else
        '                '//jurnalnya belum di-Posting dan boleh dibatalkan prosesnya
        '                .DeleteJurnalHeaderDetilByCounterHeaderAkumulasiToNull()
        '            End If
        '        Next
        '    End With

        '    fa.Dispose()
        '    fa = Nothing

        '    br.Dispose()
        '    br = Nothing

        '    UpdateViewGrid()
        'End Sub

        'Private Sub _OpenFAItemLG(ByVal counter As Guid)
        '    Dim br As New BussinessRules.LG.penerimaanDT

        '    With br
        '        .counter = New SqlGuid(counter)
        '        If .SelectOneItemLG.Rows.Count > 0 Then
        '            prepareScreen()

        '            txtcounterpenerimaan.Text = .counter.ToString
        '            txtNamaAktiva.Text = .nmBarang.Value.Trim
        '            txtJmlhBeli.Text = .qtyTerima.ToString.Trim
        '            txtQtyBeli.Text = .qtyTerima.ToString.Trim
        '            txtSatuan.Text = .satuan.Value.Trim
        '            txtserialnumber.Text = .serialnumber.Value.Trim
        '            txtnoterima.Text = .noTerima.Value.Trim


        '        End If
        '    End With
        '    br.Dispose()
        '    br = Nothing
        'End Sub

        'Private Sub _OpenFAItemLGTest(ByVal counter As String)
        '    Dim br As New BussinessRules.LG.penerimaanDT

        '    With br
        '        .counter = New SqlGuid(counter)
        '        '.noTerima = New SqlString(txtnoterima.Text.Trim)
        '        If .SelectOneItemLG.Rows.Count > 0 Then
        '            prepareScreen()

        '            txtcounterpenerimaan.Text = .counter.ToString
        '            txtNamaAktiva.Text = .nmBarang.Value.Trim
        '            txtJmlhBeli.Text = Format(((.harga2.Value - .diskonRp.Value - .diskonRp2.Value) * .kurs.Value), commonFunction.FORMAT_CURRENCY).Trim
        '            txtQtyBeli.Text = .qtyTerima.ToString.Trim
        '            txtSatuan.Text = .satuan.Value.Trim
        '            txtserialnumber.Text = .serialnumber.Value.Trim
        '            txtnoterima.Text = .noTerima.Value.Trim
        '            calTglBeli.selectedDate = .tglterima.Value
        '            calTglHitung.selectedDate = .tglterima.Value
        '            txtNvPembelian.Text = .noTerima.Value.Trim

        '        End If
        '    End With
        '    br.Dispose()
        '    br = Nothing
        'End Sub
#End Region

#Region "Printer Zebra"
        Private Sub PrinterZebra()
            Dim print As New Web.Secure.Master.fa.assets.PrintOtomatis
            Dim IsBoolean As Boolean
            IsBoolean = print.PrintLabelFA(txtKodeAktiva.Text.Trim)

            print.dispose()
        End Sub
#End Region

    End Class

End Namespace