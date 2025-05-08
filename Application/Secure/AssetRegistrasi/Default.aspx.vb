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

    Public Class AssetsGroup
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
        '//TextBox pada Add New Row...
        Protected WithEvents txtKodeBuku As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNamaBuku As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtKodeMetode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNamaMetode As System.Web.UI.WebControls.TextBox
        '//LinkButton pada Add New Row...
        Protected WithEvents lbtnKodeBuku As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnKodeMetode As System.Web.UI.WebControls.LinkButton
        '//Required Field Validator
        Protected WithEvents rfvKodeBuku As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents rfvNamaBuku As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents rfvKodeMetode As System.Web.UI.WebControls.RequiredFieldValidator
        '//TextBox Kode Perkriaan
        Protected WithEvents txtCOA1 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCOA2 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCOA3 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCOA4 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCOA5 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCOA6 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCOA7 As System.Web.UI.WebControls.TextBox
        '//TextBox Nama Perkiraan
        Protected WithEvents txtNamaCOA1 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNamaCOA2 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNamaCOA3 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNamaCOA4 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNamaCOA5 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNamaCOA6 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNamaCOA7 As System.Web.UI.WebControls.TextBox
        '//TextBox Kode Group SubLedger
        Protected WithEvents txtGroupSubl1 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGroupSubl2 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGroupSubl3 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGroupSubl4 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGroupSubl5 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGroupSubl6 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGroupSubl7 As System.Web.UI.WebControls.TextBox
        '//TextBox Kode Subledger
        Protected WithEvents txtSubl1 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSubl2 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSubl3 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSubl4 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSubl5 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSubl6 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSubl7 As System.Web.UI.WebControls.TextBox
        '//TextBox Nama SubLedger
        Protected WithEvents txtNamaSubL1 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNamaSubL2 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNamaSubL3 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNamaSubL4 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNamaSubL5 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNamaSubL6 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNamaSubL7 As System.Web.UI.WebControls.TextBox
        '//TextBox General atau detil
        Protected WithEvents txtGd1 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGd2 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGd3 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGd4 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGd5 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGd6 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGd7 As System.Web.UI.WebControls.TextBox
        '//linkbutton kode perkiraan
        Protected WithEvents lbtnCOAAktiva As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnCOAPenyusutan As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnCOADepresiasi As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnCOATanggungan As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnCOAPendapatan As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnCOABiaya As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnCOAEliminasi As System.Web.UI.WebControls.LinkButton
        '//linkbutton kode subledger by group subledger
        Protected WithEvents lbtnSublAktiva As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnSublPenyusutan As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnSublDepresiasi As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnSublTanggungan As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnSublPendapatan As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnSublBiaya As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnSublEliminasi As System.Web.UI.WebControls.LinkButton
        '//Button Save, Done, dan Delete, dan Proses
        Protected WithEvents btnSave As System.Web.UI.WebControls.Button
        Protected WithEvents btnDone As System.Web.UI.WebControls.Button
        Protected WithEvents btnDelete As System.Web.UI.WebControls.Button
        Protected WithEvents btnProses As System.Web.UI.WebControls.Button
        '//Required Field Validator
        Protected WithEvents rfvNamaSubL1 As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents rfvNamaSubL2 As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents rfvNamaSubL3 As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents rfvNamaSubL4 As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents rfvNamaSubL5 As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents rfvNamaSubL6 As System.Web.UI.WebControls.RequiredFieldValidator
        Protected WithEvents rfvNamaSubL7 As System.Web.UI.WebControls.RequiredFieldValidator

        Protected WithEvents ValidationSummary As System.Web.UI.WebControls.ValidationSummary
        Protected WithEvents panelAddNewRow As System.Web.UI.WebControls.Panel
        Protected WithEvents panelGridBukuFA As System.Web.UI.WebControls.Panel
        Protected WithEvents gridBukuFA As System.Web.UI.WebControls.DataGrid

        Private MODULE_ID As String = "97152"
#End Region


#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

                lbtnKodeBuku.Attributes.Add("OnClick", "javascript:showDialogBuku('" + txtKodeBuku.ClientID + "');")
                txtKodeBuku.Attributes.Add("OnKeyDown", "javascript:HookKeyCode(urlbBuku,'','" + txtKodeBuku.ClientID + "','');")

                lbtnKodeMetode.Attributes.Add("OnClick", "javascript:showDialogMetode('" + txtKodeMetode.ClientID + "');")
                txtKodeMetode.Attributes.Add("OnKeyDown", "javascript:HookKeyCode(urlbMetode,'','" + txtKodeMetode.ClientID + "','');")

                lbtnCOAAktiva.Attributes.Add("OnClick", "javascript:showDialogNopekDetil('" + txtCOA1.ClientID + "');")
                txtCOA1.Attributes.Add("OnKeyDown", "javascript:HookKeyCode(urlbNopekDetil,'','" + txtCOA1.ClientID + "','');")

                lbtnCOAPenyusutan.Attributes.Add("OnClick", "javascript:showDialogNopekDetil('" + txtCOA2.ClientID + "');")
                txtCOA2.Attributes.Add("OnKeyDown", "javascript:HookKeyCode(urlbNopekDetil,'','" + txtCOA2.ClientID + "','');")

                lbtnCOADepresiasi.Attributes.Add("OnClick", "javascript:showDialogNopekDetil('" + txtCOA3.ClientID + "');")
                txtCOA3.Attributes.Add("OnKeyDown", "javascript:HookKeyCode(urlbNopekDetil,'','" + txtCOA3.ClientID + "','');")

                lbtnCOATanggungan.Attributes.Add("OnClick", "javascript:showDialogNopekDetil('" + txtCOA4.ClientID + "');")
                txtCOA4.Attributes.Add("OnKeyDown", "javascript:HookKeyCode(urlbNopekDetil,'','" + txtCOA4.ClientID + "','');")

                lbtnCOAPendapatan.Attributes.Add("OnClick", "javascript:showDialogNopekDetil('" + txtCOA5.ClientID + "');")
                txtCOA5.Attributes.Add("OnKeyDown", "javascript:HookKeyCode(urlbNopekDetil,'','" + txtCOA5.ClientID + "','');")

                lbtnCOABiaya.Attributes.Add("OnClick", "javascript:showDialogNopekDetil('" + txtCOA6.ClientID + "');")
                txtCOA6.Attributes.Add("OnKeyDown", "javascript:HookKeyCode(urlbNopekDetil,'','" + txtCOA6.ClientID + "','');")

                lbtnCOAEliminasi.Attributes.Add("OnClick", "javascript:showDialogNopekDetil('" + txtCOA7.ClientID + "');")
                txtCOA7.Attributes.Add("OnKeyDown", "javascript:HookKeyCode(urlbNopekDetil,'','" + txtCOA7.ClientID + "','');")

                lbtnSublAktiva.Attributes.Add("OnClick", "javascript:showDialogSubLedgerByGroup('" + txtSubl1.ClientID + "',document.getElementById('" + txtGroupSubl1.ClientID + "').value);")

                lbtnSublPenyusutan.Attributes.Add("OnClick", "javascript:showDialogSubLedgerByGroup('" + txtSubl2.ClientID + "',document.getElementById('" + txtGroupSubl2.ClientID + "').value);")

                lbtnSublDepresiasi.Attributes.Add("OnClick", "javascript:showDialogSubLedgerByGroup('" + txtSubl3.ClientID + "',document.getElementById('" + txtGroupSubl3.ClientID + "').value);")

                lbtnSublTanggungan.Attributes.Add("OnClick", "javascript:showDialogSubLedgerByGroup('" + txtSubl4.ClientID + "',document.getElementById('" + txtGroupSubl4.ClientID + "').value);")

                lbtnSublPendapatan.Attributes.Add("OnClick", "javascript:showDialogSubLedgerByGroup('" + txtSubl5.ClientID + "',document.getElementById('" + txtGroupSubl5.ClientID + "').value);")

                lbtnSublBiaya.Attributes.Add("OnClick", "javascript:showDialogSubLedgerByGroup('" + txtSubl6.ClientID + "',document.getElementById('" + txtGroupSubl6.ClientID + "').value);")

                lbtnSublEliminasi.Attributes.Add("OnClick", "javascript:showDialogSubLedgerByGroup('" + txtSubl7.ClientID + "',document.getElementById('" + txtGroupSubl7.ClientID + "').value);")

                btnDelete.Attributes.Add("OnClick", "javascript:return dlgDeleteRecordInGrid();")
                btnSave.Attributes.Add("OnClick", "javascript:return dlgSaveData();")
                btnProses.Attributes.Add("OnClick", "javascript:return dlgSaveData();")

                commonFunction.ShowPanel(panelAddNewRow, False)

                UpdateViewGrid()

                DataBind()
            End If
        End Sub

        Private Sub gridBukuFA_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles gridBukuFA.ItemCommand
            Dim _lblKodeBuku As System.Web.UI.WebControls.Label

            Select Case e.CommandName

                Case "_AddNewRow"
                    commonFunction.ShowPanel(panelAddNewRow, True)
                    prepareScreen()

                Case "Edit"
                    commonFunction.ShowPanel(panelAddNewRow, True)

                    _lblKodeBuku = CType(e.Item.FindControl("_lblKodeBuku"), Label)
                    txtKodeBuku.Text = _lblKodeBuku.Text.Trim

                    _Open(BussinessRules.QISRecStatus.CurrentRecord)

            End Select
        End Sub

        Private Sub btn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click, btnDone.Click, btnDelete.Click, btnProses.Click
            Select Case CType(sender, Button).ID
                Case btnSave.ID
                    _update()
                Case btnDone.ID
                    commonFunction.ShowPanel(panelAddNewRow, False)
                Case btnDelete.ID
                    _delete()
                Case btnProses.ID
                    If _prosesAkumulasiFAByKdBukuKdAktiva() = True Then
                        commonFunction.MsgBox(Me, "Proses Akumulasi Penyusutan Fixed Assets berhasil.")
                    End If
            End Select
        End Sub

        Private Sub txtKode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtKodeBuku.TextChanged, txtKodeMetode.TextChanged
            Select Case CType(sender, TextBox).ClientID
                Case "txtKodeBuku"
                    _Open(BussinessRules.QISRecStatus.CurrentRecord)
                Case "txtKodeMetode"
                    _OpenNamaMetodeFA(BussinessRules.QISRecStatus.CurrentRecord)
            End Select
        End Sub

        Private Sub txtCOA_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCOA1.TextChanged, txtCOA2.TextChanged, txtCOA3.TextChanged, txtCOA4.TextChanged, txtCOA5.TextChanged, txtCOA6.TextChanged, txtCOA7.TextChanged
            Select Case CType(sender, TextBox).ClientID
                Case "txtCOA1"
                    _OpenNamaCOA(txtCOA1)
                    txtSubl1.Text = String.Empty
                    txtNamaSubL1.Text = String.Empty
                Case "txtCOA2"
                    _OpenNamaCOA(txtCOA2)
                    txtSubl2.Text = String.Empty
                    txtNamaSubL2.Text = String.Empty
                Case "txtCOA3"
                    _OpenNamaCOA(txtCOA3)
                    txtSubl3.Text = String.Empty
                    txtNamaSubL3.Text = String.Empty
                Case "txtCOA4"
                    _OpenNamaCOA(txtCOA4)
                    txtSubl4.Text = String.Empty
                    txtNamaSubL4.Text = String.Empty
                Case "txtCOA5"
                    _OpenNamaCOA(txtCOA5)
                    txtSubl5.Text = String.Empty
                    txtNamaSubL5.Text = String.Empty
                Case "txtCOA6"
                    _OpenNamaCOA(txtCOA6)
                    txtSubl6.Text = String.Empty
                    txtNamaSubL6.Text = String.Empty
                Case "txtCOA7"
                    _OpenNamaCOA(txtCOA7)
                    txtSubl7.Text = String.Empty
                    txtNamaSubL7.Text = String.Empty
            End Select
        End Sub

        Private Sub txtSubL_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSubl1.TextChanged, txtSubl2.TextChanged, txtSubl3.TextChanged, txtSubl4.TextChanged, txtSubl5.TextChanged, txtSubl6.TextChanged, txtSubl7.TextChanged
            _OpenNamaSubL(CType(sender, TextBox))
        End Sub
#End Region


#Region " Support functions for navigation bar (Controls) "

#End Region


#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
        End Function

        Private Sub prepareScreen()
            txtKodeBuku.Text = String.Empty
            txtNamaBuku.Text = String.Empty
            txtKodeMetode.Text = "SL"
            _OpenNamaMetodeFA(BussinessRules.QISRecStatus.CurrentRecord)

            txtCOA1.Text = String.Empty
            txtCOA2.Text = String.Empty
            txtCOA3.Text = String.Empty
            txtCOA4.Text = String.Empty
            txtCOA5.Text = String.Empty
            txtCOA6.Text = String.Empty
            txtCOA7.Text = String.Empty

            txtNamaCOA1.Text = String.Empty
            txtNamaCOA2.Text = String.Empty
            txtNamaCOA3.Text = String.Empty
            txtNamaCOA4.Text = String.Empty
            txtNamaCOA5.Text = String.Empty
            txtNamaCOA6.Text = String.Empty
            txtNamaCOA7.Text = String.Empty

            txtSubl1.Text = String.Empty
            txtSubl2.Text = String.Empty
            txtSubl3.Text = String.Empty
            txtSubl4.Text = String.Empty
            txtSubl5.Text = String.Empty
            txtSubl6.Text = String.Empty
            txtSubl7.Text = String.Empty

            txtSubl1.Enabled = False
            txtSubl2.Enabled = False
            txtSubl3.Enabled = False
            txtSubl4.Enabled = False
            txtSubl5.Enabled = False
            txtSubl6.Enabled = False
            txtSubl7.Enabled = False

            txtNamaSubL1.Text = String.Empty
            txtNamaSubL2.Text = String.Empty
            txtNamaSubL3.Text = String.Empty
            txtNamaSubL4.Text = String.Empty
            txtNamaSubL5.Text = String.Empty
            txtNamaSubL6.Text = String.Empty
            txtNamaSubL7.Text = String.Empty

            rfvNamaSubL1.Enabled = False
            rfvNamaSubL2.Enabled = False
            rfvNamaSubL3.Enabled = False
            rfvNamaSubL4.Enabled = False
            rfvNamaSubL5.Enabled = False
            rfvNamaSubL6.Enabled = False
            rfvNamaSubL7.Enabled = False

            UpdateViewGrid()
        End Sub

        Private Sub UpdateViewGrid()
            Dim br As New BussinessRules.FA.buku

            gridBukuFA.DataSource = br.SelectAll
            gridBukuFA.DataBind()

            br.Dispose()
            br = Nothing
        End Sub
#End Region


#Region " Main Function: Open, Save Delete Data "
        Private Sub _Open(ByVal RecStatus As BussinessRules.QISRecStatus)
            If Len(txtKodeBuku.Text.Trim) = 0 Then Exit Sub

            Dim br As New BussinessRules.FA.buku

            With br
                .KdBuku = New SqlString(Trim(txtKodeBuku.Text))

                If .SelectOne(RecStatus).Rows.Count > 0 Then
                    If Not RecStatus = BussinessRules.QISRecStatus.CurrentRecord Then txtKodeBuku.Text = .KdBuku.Value
                    txtNamaBuku.Text = .NmBuku.Value.Trim
                    txtKodeMetode.Text = .KdMtd.Value.Trim
                    txtCOA1.Text = .Coa_aktiva.Value.Trim
                    txtCOA2.Text = .Coa_penyusutan.Value.Trim
                    txtCOA3.Text = .Coa_depresiasi.Value.Trim
                    txtCOA4.Text = .Coa_tanggungan.Value.Trim
                    txtCOA5.Text = .Coa_pendapatan.Value.Trim
                    txtCOA6.Text = .Coa_biaya.Value.Trim
                    txtCOA7.Text = .Coa_eliminasi.Value.Trim
                    txtSubl1.Text = .Subl_aktiva.Value.Trim
                    txtSubl2.Text = .Subl_penyusutan.Value.Trim
                    txtSubl3.Text = .Subl_depresiasi.Value.Trim
                    txtSubl4.Text = .Subl_tanggungan.Value.Trim
                    txtSubl5.Text = .Subl_pendapatan.Value.Trim
                    txtSubl6.Text = .Subl_biaya.Value.Trim
                    txtSubl7.Text = .Subl_eliminasi.Value.Trim

                    '//open nama metode FA
                    _OpenNamaMetodeFA(BussinessRules.QISRecStatus.CurrentRecord)
                    '//open nama coa1
                    _OpenNamaCOA(txtCOA1)
                    '//open nama coa2
                    _OpenNamaCOA(txtCOA2)
                    '//open nama coa3
                    _OpenNamaCOA(txtCOA3)
                    '//open nama coa4
                    _OpenNamaCOA(txtCOA4)
                    '//open nama coa5
                    _OpenNamaCOA(txtCOA5)
                    '//open nama coa6
                    _OpenNamaCOA(txtCOA6)
                    '//open nama coa7
                    _OpenNamaCOA(txtCOA7)
                    '//open nama SubL1
                    _OpenNamaSubL(txtSubl1)
                    '//open nama SubL2
                    _OpenNamaSubL(txtSubl2)
                    '//open nama SubL3
                    _OpenNamaSubL(txtSubl3)
                    '//open nama SubL4
                    _OpenNamaSubL(txtSubl4)
                    '//open nama SubL5
                    _OpenNamaSubL(txtSubl5)
                    '//open nama SubL6
                    _OpenNamaSubL(txtSubl6)
                    '//open nama SubL7
                    _OpenNamaSubL(txtSubl7)

                Else
                    If Not RecStatus = BussinessRules.QISRecStatus.CurrentRecord Then Exit Sub
                    txtNamaBuku.Text = String.Empty
                    txtKodeMetode.Text = "SL"
                    _OpenNamaMetodeFA(BussinessRules.QISRecStatus.CurrentRecord)
                    txtCOA1.Text = String.Empty
                    txtCOA2.Text = String.Empty
                    txtCOA3.Text = String.Empty
                    txtCOA4.Text = String.Empty
                    txtCOA5.Text = String.Empty
                    txtCOA6.Text = String.Empty
                    txtCOA7.Text = String.Empty
                    txtNamaCOA1.Text = String.Empty
                    txtNamaCOA2.Text = String.Empty
                    txtNamaCOA3.Text = String.Empty
                    txtNamaCOA4.Text = String.Empty
                    txtNamaCOA5.Text = String.Empty
                    txtNamaCOA6.Text = String.Empty
                    txtNamaCOA7.Text = String.Empty
                    txtSubl1.Text = String.Empty
                    txtSubl2.Text = String.Empty
                    txtSubl3.Text = String.Empty
                    txtSubl4.Text = String.Empty
                    txtSubl5.Text = String.Empty
                    txtSubl6.Text = String.Empty
                    txtSubl7.Text = String.Empty
                    txtSubl1.Enabled = False
                    txtSubl2.Enabled = False
                    txtSubl3.Enabled = False
                    txtSubl4.Enabled = False
                    txtSubl5.Enabled = False
                    txtSubl6.Enabled = False
                    txtSubl7.Enabled = False
                    txtNamaSubL1.Text = String.Empty
                    txtNamaSubL2.Text = String.Empty
                    txtNamaSubL3.Text = String.Empty
                    txtNamaSubL4.Text = String.Empty
                    txtNamaSubL5.Text = String.Empty
                    txtNamaSubL6.Text = String.Empty
                    txtNamaSubL7.Text = String.Empty
                End If
            End With
            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, txtNamaBuku.ClientID)
        End Sub

        Private Sub _OpenNamaCOA(ByVal txt As TextBox)
            Dim txtCOA As TextBox = CType(Me.FindControl("txtCOA" + Right(txt.ID, 1)), TextBox)
            Dim txtNamaCOA As TextBox = CType(Me.FindControl("txtNamaCOA" + Right(txt.ID, 1)), TextBox)
            Dim txtGroupSubL As TextBox = CType(Me.FindControl("txtGroupSubL" + Right(txt.ID, 1)), TextBox)
            Dim txtSubL As TextBox = CType(Me.FindControl("txtSubL" + Right(txt.ID, 1)), TextBox)
            Dim txtNamaSubL As TextBox = CType(Me.FindControl("txtNamaSubL" + Right(txt.ID, 1)), TextBox)
            Dim txtGd As TextBox = CType(Me.FindControl("txtGd" + Right(txt.ID, 1)), TextBox)
            Dim rfvNamaSubL As RequiredFieldValidator = CType(Me.FindControl("rfvNamaSubL" + Right(txt.ID, 1)), RequiredFieldValidator)

            If Len(txt.Text.Trim) = 0 Then
                txtNamaCOA.Text = String.Empty
                txtGroupSubL.Text = String.Empty
                txtSubL.Text = String.Empty
                txtNamaSubL.Text = String.Empty
                txtSubL.Enabled = False
                txtNamaSubL.Enabled = False
                rfvNamaSubL.Enabled = False
                Exit Sub
            End If

            Dim br As New BussinessRules.GL.coa
            With br
                .KdCoa = txt.Text.Trim

                If .SelectOne().Rows.Count > 0 Then
                    txtNamaCOA.Text = .Napek.Trim
                    txtGroupSubL.Text = .KdGsl.Trim
                    txtGd.Text = .Gd.ToString.Trim
                    If (txtGd.Text = "1") Then
                        '//Kalau kode perkiraan yang dipilih adalah general
                        commonFunction.MsgBox(Me, "Kode perkiraan general tidak dapat dijurnal.")
                        txtCOA.Text = String.Empty
                        txtNamaCOA.Text = String.Empty
                        txtGroupSubL.Text = String.Empty
                        txtSubL.Text = String.Empty
                        txtNamaSubL.Text = String.Empty
                        txtSubL.Enabled = False
                        txtNamaSubL.Enabled = False
                        rfvNamaSubL.Enabled = False
                    Else
                        If (txtGroupSubL.Text = "none") Then
                            '//Kalau kode perkiraan yang dipilih tidak memiliki GroupSubLedger
                            txtSubL.Enabled = False
                            txtNamaSubL.Enabled = False
                            txtSubL.Text = String.Empty
                            txtNamaSubL.Text = String.Empty
                            rfvNamaSubL.Enabled = False
                        Else
                            txtSubL.Enabled = True
                            txtNamaSubL.Enabled = True
                            rfvNamaSubL.Enabled = True
                        End If '//If (txtGroupSubL.Text = "none") Then
                    End If '//If (txtGd.Text = "1") Then
                Else
                    txtCOA.Text = String.Empty
                    txtNamaCOA.Text = String.Empty
                    txtGroupSubL.Text = String.Empty
                    txtSubL.Text = String.Empty
                    txtNamaSubL.Text = String.Empty
                    txtSubL.Enabled = False
                    txtNamaSubL.Enabled = False
                    rfvNamaSubL.Enabled = False
                End If '//If .SelectOne().Rows.Count > 0 Then
            End With
            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _OpenNamaSubL(ByVal txt As TextBox)
            Dim txtSubL As TextBox = CType(Me.FindControl("txtSubL" + Right(txt.ID, 1)), TextBox)
            Dim txtNamaSubL As TextBox = CType(Me.FindControl("txtNamaSubL" + Right(txt.ID, 1)), TextBox)

            If Len(txt.Text.Trim) = 0 Then
                txtNamaSubL.Text = String.Empty
                Exit Sub
            End If

            Dim br As New BussinessRules.GL.subLedger
            With br
                .kdSubLedger = New SqlString(txt.Text.Trim)

                If .SelectOne().Rows.Count > 0 Then
                    txtNamaSubL.Text = .nmSubLedger.Value.Trim
                Else
                    '//kalau kode yang diinput user tidak ada di database maka txtKode dan Nama SubL dikosongkan
                    txtSubL.Text = String.Empty
                    txtNamaSubL.Text = String.Empty
                End If
            End With
            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _OpenNamaMetodeFA(ByVal RecStatus As BussinessRules.QISRecStatus)
            Dim br As New BussinessRules.FA.metode

            With br
                .KdMtd = New SqlString(txtKodeMetode.Text)
                If .SelectOne(RecStatus).Rows.Count > 0 Then
                    txtNamaMetode.Text = .NmMtd.Value.Trim
                Else
                    txtKodeMetode.Text = String.Empty
                    txtNamaMetode.Text = String.Empty
                End If
            End With
            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _delete()
            If Len(txtKodeBuku.Text.Trim) = 0 Then Exit Sub

            Dim br As New BussinessRules.FA.buku

            With br
                .KdBuku = New SqlString(Trim(txtKodeBuku.Text))
                If .Delete Then
                    prepareScreen()
                End If
            End With
            br.Dispose()
            br = Nothing

            prepareScreen()
        End Sub

        Private Sub _update()
            Page.Validate()
            If Not Page.IsValid Then Exit Sub

            Dim br As New BussinessRules.FA.buku

            Dim fNotNew As Boolean = False

            With br
                .KdBuku = New SqlString(txtKodeBuku.Text.Trim)

                fNotNew = (.SelectOne.Rows.Count > 0)

                .NmBuku = New SqlString(txtNamaBuku.Text.Trim)
                .KdMtd = New SqlString(txtKodeMetode.Text.Trim)
                .Coa_aktiva = New SqlString(txtCOA1.Text.Trim)
                .Coa_penyusutan = New SqlString(txtCOA2.Text.Trim)
                .Coa_depresiasi = New SqlString(txtCOA3.Text.Trim)
                .Coa_tanggungan = New SqlString(txtCOA4.Text.Trim)
                .Coa_pendapatan = New SqlString(txtCOA5.Text.Trim)
                .Coa_biaya = New SqlString(txtCOA6.Text.Trim)
                .Coa_eliminasi = New SqlString(txtCOA7.Text.Trim)
                .Subl_aktiva = New SqlString(txtSubl1.Text.Trim)
                .Subl_penyusutan = New SqlString(txtSubl2.Text.Trim)
                .Subl_depresiasi = New SqlString(txtSubl3.Text.Trim)
                .Subl_tanggungan = New SqlString(txtSubl4.Text.Trim)
                .Subl_pendapatan = New SqlString(txtSubl5.Text.Trim)
                .Subl_biaya = New SqlString(txtSubl6.Text.Trim)
                .Subl_eliminasi = New SqlString(txtSubl7.Text.Trim)
                .Usrinsert = New SqlString(MyBase.LoggedOnUserID)
                .Usrupdate = New SqlString(MyBase.LoggedOnUserID)
                .Tglinsert = New SqlDateTime(Date.Now)
                .Tglupdate = New SqlDateTime(Date.Now)

                If fNotNew Then
                    .Update()
                Else
                    .Insert()
                End If
            End With
            br.Dispose()
            br = Nothing

            prepareScreen()
            commonFunction.Focus(Me, txtKodeBuku.ClientID)
        End Sub

        'Private Sub _prosesAkumulasiFAByKdBukuKdAktiva()
        '    Page.Validate()
        '    If Not Page.IsValid Then Exit Sub

        '    Dim br As New BussinessRules.FA.akumulasi

        '    Dim fNotNew As Boolean = False

        '    br.ProsesAkumulasiFAByKdBukuKdAktiva(txtKodeBuku.Text.Trim, "")

        '    br.Dispose()
        '    br = Nothing
        'End Sub

        Private Function _prosesAkumulasiFAByKdBukuKdAktiva() As Boolean
            Page.Validate()
            If Not Page.IsValid Then Exit Function

            Dim br As New BussinessRules.FA.akumulasi
            Dim sv As New SetVar
            Dim b As Boolean

            Dim fNotNew As Boolean = False

            sv.app = New SqlString("GL_")

            If Common.Methods.GetSettingParameter("fa_fAkmPenyHarian", "GL_") = "1" Then
                '//Proses akumulasi penyusutan FA harian
                If br.ProsesAkumulasiFAByKdBukuKdAktivaPerHari(txtKodeBuku.Text.Trim, "") = True Then
                    b = True
                Else
                    b = False
                End If
            Else
                '//Proses akumulasi penyusutan FA bulanan
                If br.ProsesAkumulasiFAByKdBukuKdAktivaSLDD(txtKodeBuku.Text.Trim, "") = True Then
                    b = True
                Else
                    b = False
                End If
            End If

            br.Dispose()
            br = Nothing

            Return b
        End Function
#End Region


    End Class

End Namespace