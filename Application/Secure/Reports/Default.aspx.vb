

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

    Public Class Reports
        Inherits PageBase


#Region " Private Variables (web form designer generated code and user code) "
        Protected WithEvents trvReport As TreeView
        Protected WithEvents CSSToolbar As CSSToolbar
        Protected WithEvents lblReportDesc As Label

        Protected WithEvents btnPreview As Button
        Protected WithEvents btnPreview1 As Button
        Protected WithEvents pd96 As Panel
        Protected WithEvents ddlMataUang As DropDownList
        Protected WithEvents pd84 As Panel
        Protected WithEvents ddlktr As DropDownList
        Protected WithEvents pd1 As Panel
        Protected WithEvents pd3 As Panel 'panel medis
        Protected WithEvents pd4 As Panel
        Protected WithEvents pd5 As Panel
        Protected WithEvents pd92 As Panel
        Protected WithEvents pd59 As Panel ' instansi di tagihkan
        Protected WithEvents pd8 As Panel 'nama user
        Protected WithEvents pd11 As Panel 'panel kode DTD
        Protected WithEvents pd12 As Panel 'panel kode poliklinik
        Protected WithEvents pd17 As Panel 'panel option type
        Protected WithEvents pd18 As Panel 'panel report type

        Protected WithEvents pd22 As Panel 'panel Desc Asc
        Protected WithEvents pd89 As Panel 'panel Desc Asc
        Protected WithEvents pd24 As Panel

        Protected WithEvents pd58 As Panel ' pd no rekam medis

        Protected WithEvents pd20 As Panel 'panel Kode Diagnosa
        Protected WithEvents pd21 As Panel 'panel SortBy bln,nmin,total piutang windhyz
        Protected WithEvents pd23 As Panel 'panel SortBy namapasien, totalpiutang
        Protected WithEvents Pd90 As Panel
        Protected WithEvents Pd99 As Panel
        Protected WithEvents pd25 As Panel
        Protected WithEvents pd26 As Panel

        'tarifgroup

        'tarifgroup awal n akhir

        'kdlayan

        'modules
        Protected WithEvents ddlmoduleS As DropDownList
        Protected WithEvents pd91 As Panel

        'modules mcu lb
        Protected WithEvents ddlmoduleSMCULB As DropDownList
        Protected WithEvents Pd87 As Panel

        ' linkbutton testgroup

        Protected WithEvents pd86 As Panel ' linkbutton kdtest

        Protected WithEvents pd85 As Panel ' ddl buat item
        Protected WithEvents Pd93 As Panel
        Protected WithEvents pd83 As Panel ' ddl buat pd RI n RJ aja

        Protected WithEvents Pd27 As Panel 'kdbuku
        Protected WithEvents Pd57 As Panel 'kdcoa
        Protected WithEvents lbtnKdcoaawal As LinkButton
        Protected WithEvents txtKdcoaawal As TextBox
        Protected WithEvents lbtnKdcoaakhir As LinkButton
        Protected WithEvents txtKdcoaakhir As TextBox

        Protected WithEvents Pd28 As Panel
        Protected WithEvents Pd29 As Panel
        Protected WithEvents Pd30 As Panel
        Protected WithEvents Pd31 As Panel
        Protected WithEvents Pd32 As Panel
        Protected WithEvents Pd33 As Panel
        Protected WithEvents Pd34 As Panel
        Protected WithEvents Pd35 As Panel
        Protected WithEvents Pd36 As Panel

        'panel untuk kode pos
        'panel untuk Pengirim
        'panel untuk Tindakan
        'panel untuk bank
        'panel untuk Morfologi
        'panel untuk Penunjang Medis
        'panel untuk SMF
        'panel untuk Ruang Rawat
        'panel untuk kelas
        Protected WithEvents pd190 As Panel 'panel untuk piutang instansi pasien
        Protected WithEvents pd37 As Panel 'panel untuk tanggal
        Protected WithEvents pd38 As Panel 'panel untuk jasa medis
        Protected WithEvents pd39 As Panel 'panel untuk jenis transaksi
        Protected WithEvents Pd40 As Panel 'panel untuk supplier
        Protected WithEvents pd46 As Panel 'panel untuk module
        Protected WithEvents pd48 As Panel 'panel untuk semua/sudah/belum
        Protected WithEvents pdchkAllPending As Panel 'panel untuk checkbox pending jasa medis
        Protected WithEvents Pd51 As Panel
        Protected WithEvents pd52 As Panel
        Protected WithEvents pd53 As Panel

        Protected WithEvents calStart As QIS.Web.Calendar
        Protected WithEvents calEnd As QIS.Web.Calendar
        Protected WithEvents lbtndrMulai As LinkButton
        Protected WithEvents lbtndrSampai As LinkButton
        Protected WithEvents linkKodeDokterMulai As LinkButton
        Protected WithEvents txtKodeDokterMulai As TextBox
        Protected WithEvents linkKodeDokterSampai As LinkButton
        Protected WithEvents txtKodeDokterSampai As TextBox

        Protected WithEvents lbtnKodeInstansi As LinkButton
        Protected WithEvents txtKodeInstansi As TextBox
        Protected WithEvents lblNamaInstansi As Label


        Protected WithEvents lbtnKdBuku As LinkButton
        Protected WithEvents txtKdBuku As TextBox
        Protected WithEvents lblKdBuku As Label


        Protected WithEvents lbtnKodeInstansiMulai As LinkButton
        Protected WithEvents txtKodeInstansiMulai As TextBox
        Protected WithEvents lbtnKodeInstansiSampai As LinkButton
        Protected WithEvents txtKodeInstansiSampai As TextBox

        Protected WithEvents pdJnsInstansi As Panel
        Protected WithEvents ddlJnsInstansi As DropDownList
        Protected WithEvents chksmuaInstansi As CheckBox

        Protected WithEvents lbtnKodeInstansiditagihkanMulai As LinkButton
        Protected WithEvents txtKodeInstansiditagihkanMulai As TextBox
        Protected WithEvents lbtnKodeInstansiditagihkanSampai As LinkButton
        Protected WithEvents txtKodeInstansiditagihkanSampai As TextBox


        Protected WithEvents lbtnnormMulai As LinkButton
        Protected WithEvents txtnormMulai As TextBox
        Protected WithEvents lbtnnormSampai As LinkButton
        Protected WithEvents txtnormSampai As TextBox


        Protected WithEvents lbtnkdlayanawal As LinkButton
        Protected WithEvents txtkdlayanawal As TextBox
        Protected WithEvents lbtnkdlayanakhir As LinkButton
        Protected WithEvents txtkdlayanakhir As TextBox

        Protected WithEvents lbtnkdtestawal As LinkButton
        Protected WithEvents txtkdtestawal As TextBox
        Protected WithEvents lbtnkdtestakhir As LinkButton
        Protected WithEvents txtkdtestakhir As TextBox

        Protected WithEvents lbtnNoInvoiceMulai As LinkButton
        Protected WithEvents txtNoInvoiceMulai As TextBox
        Protected WithEvents lbtnNoInvoiceSampai As LinkButton
        Protected WithEvents txtNoInvoiceSampai As TextBox


        Protected WithEvents panelMain As Panel
        Protected WithEvents txtInvNumStart As TextBox
        Protected WithEvents txtInvNumEnd As TextBox
        Protected WithEvents txtUser As TextBox
        Protected WithEvents linkDTDStart As LinkButton
        Protected WithEvents linkDTDEnd As LinkButton
        'Protected WithEvents txtTanggal As TextBox
        Protected WithEvents txtDTDStart As TextBox
        Protected WithEvents txtDTDEnd As TextBox
        Protected WithEvents linkPoliStart As LinkButton
        Protected WithEvents linkPoliEnd As LinkButton
        Protected WithEvents linkDiagnosaStart As LinkButton
        Protected WithEvents linkDiagnosaEnd As LinkButton
        Protected WithEvents lbtnkodeposmulai As LinkButton
        Protected WithEvents lbtnkodepossampai As LinkButton
        Protected WithEvents lbtnKodePengirimmulai As LinkButton
        Protected WithEvents lbtnkodepengirimsampai As LinkButton
        Protected WithEvents lbtnTindakanmulai As LinkButton
        Protected WithEvents lbtnTindakansampai As LinkButton
        Protected WithEvents lbtnBankmulai As LinkButton
        Protected WithEvents lbtnbanksampai As LinkButton
        Protected WithEvents lbtnMorfologimulai As LinkButton
        Protected WithEvents lbtnmorfologisampai As LinkButton
        Protected WithEvents lbtnPenunjangMedismulai As LinkButton
        Protected WithEvents lbtnpenunjangmedissampai As LinkButton
        Protected WithEvents lbtnSMFmulai As LinkButton
        Protected WithEvents lbtnSMFsampai As LinkButton
        Protected WithEvents lbtnkelasmulai As LinkButton
        Protected WithEvents lbtnkelassampai As LinkButton
        Protected WithEvents lbtnruangrawatmulai As LinkButton
        Protected WithEvents lbtnRuangrawatsampai As LinkButton
        Protected WithEvents lbtnSupplierAwal As LinkButton
        Protected WithEvents lbtnSupplierAkhir As LinkButton
        Protected WithEvents txtPoliStart As TextBox
        Protected WithEvents txtPoliEnd As TextBox
        Protected WithEvents txtDiagnosaStart As TextBox
        Protected WithEvents txtDiagnosaEnd As TextBox
        Protected WithEvents txtMemberStart As TextBox
        Protected WithEvents txtMemberEnd As TextBox

        Protected WithEvents txtYear As TextBox
        Protected WithEvents txtdrMulai As TextBox
        Protected WithEvents txtdrSampai As TextBox
        Protected WithEvents txtkodeposmulai As TextBox
        Protected WithEvents Txtkodepossampai As TextBox
        Protected WithEvents TxtkodeTindakansampai As TextBox
        Protected WithEvents txtkodetindakanmulai As TextBox
        Protected WithEvents Txtkodepengirimsampai As TextBox
        Protected WithEvents txtkodepengirimmulai As TextBox
        Protected WithEvents Txtkodebanksampai As TextBox
        Protected WithEvents txtkodebankmulai As TextBox
        Protected WithEvents Txtmorfologisampai As TextBox
        Protected WithEvents txtmorfologimulai As TextBox
        Protected WithEvents Txtpenunjangmedissampai As TextBox
        Protected WithEvents txtpenunjangmedismulai As TextBox
        Protected WithEvents Txtsmfsampai As TextBox
        Protected WithEvents txtsmfmulai As TextBox
        Protected WithEvents Txtkelassampai As TextBox
        Protected WithEvents txtKelasmulai As TextBox
        Protected WithEvents Txtruangrawatsampai As TextBox
        Protected WithEvents txtruangrawatmulai As TextBox
        Protected WithEvents txtSupplierAwal As TextBox
        Protected WithEvents txtSupplierAkhir As TextBox
        Protected WithEvents cal As QIS.Web.Calendar
        Protected WithEvents ddlJasaMedis As DropDownList
        Protected WithEvents ddlPiutangInstansi As DropDownList
        Protected WithEvents ddlPiutangInstansiRIRJ As DropDownList
        Protected WithEvents ddlJenisTransaksi As DropDownList
        Protected WithEvents ddlmodule As DropDownList
        Protected WithEvents ddlPnjlnItem As DropDownList
        Protected WithEvents ddlsmrirjrdmdmculb As DropDownList
        Protected WithEvents ddlSortBy As DropDownList
        Protected WithEvents ddlSortByPribadi As DropDownList

        Protected WithEvents ddlsemuaasalpasien As DropDownList

        Protected WithEvents chkAllPending As CheckBox
        'Protected WithEvents btnPreview1 As Button
        Protected WithEvents StrukLengkap As CheckBox
        Protected WithEvents ResumeMedis As CheckBox
        Protected WithEvents SuratJaminan As CheckBox
        Protected WithEvents SuratInformasiPenagihanPiutang As CheckBox
        Protected WithEvents KwitansiAsli As CheckBox
        Protected WithEvents RincianSelisihBiayaKamarPerKelas As CheckBox



        'Protected WithEvents RequiredFieldValidatorTglMulai As RequiredFieldValidator
        'Protected WithEvents RequiredFieldValidatorTglSampai As RequiredFieldValidator
        Protected WithEvents RequiredFieldValidatorKodeDokterMulai As RequiredFieldValidator
        Protected WithEvents RequiredFieldValidatorKodeDokterSampai As RequiredFieldValidator
        Protected WithEvents RequiredFieldValidatorKodeInstansi As RequiredFieldValidator

        Protected WithEvents RequiredFieldValidatorKodeInstansiMulai As RequiredFieldValidator
        Protected WithEvents RequiredFieldValidatorKodeInstansiSampai As RequiredFieldValidator

        Protected WithEvents RequiredFieldValidatorNoInvoiceMulai As RequiredFieldValidator
        Protected WithEvents RequiredFieldValidatorNoInvoiceSampai As RequiredFieldValidator

        Protected WithEvents ValidationSummaryDlg1 As ValidationSummary
        Protected WithEvents RequiredFieldValidatorGrpStart As RequiredFieldValidator
        Protected WithEvents RequiredFieldValidatorGrpEnd As RequiredFieldValidator
        'Protected WithEvents RequiredFieldValidatorTanggal As RequiredFieldValidator
        Protected WithEvents RequiredFieldDTDStart As RequiredFieldValidator
        Protected WithEvents RequiredFieldDTDEnd As RequiredFieldValidator
        Protected WithEvents RequiredFieldPoliStart As RequiredFieldValidator
        Protected WithEvents RequiredFieldPoliEnd As RequiredFieldValidator
        Protected WithEvents RequiredFieldDiagnosaStart As RequiredFieldValidator
        Protected WithEvents RequiredFieldDiagnosaEnd As RequiredFieldValidator

        Protected WithEvents OptionType As CheckBoxList
        Protected WithEvents rbReportType As RadioButtonList

        Protected WithEvents AscDesc As RadioButtonList
        Protected WithEvents DIBAYAR As RadioButtonList
        Protected WithEvents DdlShift As DropDownList

        Protected WithEvents rbReportTypeSSB As RadioButtonList
        Protected WithEvents rbAuthorizationType As RadioButtonList


        Private _searchKey As Boolean
        Private _currentBrowseType As String

        Protected WithEvents calTglMulai As QIS.Web.Calendar
        Protected WithEvents calTglSampai As QIS.Web.Calendar
        Protected WithEvents Pd41 As Panel

        'panel untuk cabang / customer
        Protected WithEvents ddlCabangAwal As DropDownList
        Protected WithEvents ddlCabangAkhir As DropDownList
        Protected WithEvents chkAllCabang As CheckBox

        Protected WithEvents pd42 As Panel 'panel untuk validasi
        Protected WithEvents chkValid As CheckBox

        Protected WithEvents pd43 As Panel 'panel untuk validasi
        Protected WithEvents chkSemuaSupplier As CheckBox

        Protected WithEvents pd44 As Panel 'panel untuk tanggal 1
        Protected WithEvents calTanggal As QIS.Web.Calendar
        Protected WithEvents Pd45 As Panel

        'panel untuk supplier 1
        Protected WithEvents lbtnKodeSupplier As LinkButton
        Protected WithEvents txtKodeSupplier As TextBox
        Protected WithEvents lblNamaSupplier As Label
        Protected WithEvents Pd47 As Panel

        'panel untuk User
        Protected WithEvents lbtnUser As LinkButton
        Protected WithEvents txtUser1 As TextBox
        Protected WithEvents lblUser1 As Label

        'tarifgroup
        Protected WithEvents lbtntarifgroup As LinkButton
        Protected WithEvents txttarifgroup As TextBox
        Protected WithEvents lbltarifgroup As Label

        'tarifgroupawal
        Protected WithEvents lbtntarifgroupawal As LinkButton
        Protected WithEvents txttarifgroupawal As TextBox
        Protected WithEvents lbltarifgroupawal As Label

        'tarifgroupakhir
        Protected WithEvents lbtntarifgroupakhir As LinkButton
        Protected WithEvents txttarifgroupakhir As TextBox
        Protected WithEvents lbltarifgroupakhir As Label

        'Testgroup

        Protected WithEvents lbtnTestgroup As LinkButton
        Protected WithEvents txtTestgroup As TextBox
        Protected WithEvents lblTestgroup As Label

        Protected WithEvents pd49 As Panel 'panel authorization type

        Protected WithEvents lbtnMenuAwal As LinkButton
        Protected WithEvents txtMenuAwal As TextBox
        Protected WithEvents lbtnMenuAkhir As LinkButton
        Protected WithEvents txtMenuAkhir As TextBox
        Protected WithEvents rfldModule As RequiredFieldValidator

        Protected WithEvents pd50 As Panel
        Protected WithEvents txtGrpStart As TextBox
        Protected WithEvents txtGrpEnd As TextBox
        Protected WithEvents pd7 As Panel
        Protected WithEvents pd9 As Panel
        Protected WithEvents ddlAlphabet As DropDownList
        Protected WithEvents pd13 As Panel
        Protected WithEvents ddlYear As DropDownList
        Protected WithEvents pd19 As Panel
        Protected WithEvents panel1 As Panel

        'Deklarasi componentUI panel60 (pd60)  
        Protected WithEvents pd60 As Panel
        Protected WithEvents ddlBulan As DropDownList
        Protected WithEvents ddlTahun As DropDownList

        'Deklarasi componentUI panel61 (pd61)  
        Protected WithEvents pd61 As Panel
        Protected WithEvents ddlthn As DropDownList

        'Deklarasi componentUI panel62 (pd62) untuk Periode Bulan dan Tahun
        Protected WithEvents pd62 As Panel
        Protected WithEvents ddlBln1 As DropDownList
        Protected WithEvents ddlThn1 As DropDownList
        Protected WithEvents ddlBln2 As DropDownList
        Protected WithEvents ddlThn2 As DropDownList


        'Deklarasi componentUI panel64 (pd64) untuk Link Button KD Dokter
        Protected WithEvents pd64 As Panel
        Protected WithEvents lbtnkddokter As LinkButton
        Protected WithEvents TxtKddokter As TextBox
        Protected WithEvents Lblnmdokter As Label
        Protected WithEvents chkAllDok As CheckBox
        Protected WithEvents RincianSelisihBiayaKamarPerKls As CheckBox
        Protected WithEvents lbtnKodePiutangNonOprMulai As LinkButton
        Protected WithEvents txtKodePiutangMulai As TextBox
        Protected WithEvents RequiredFieldValidatorKodePiutangMulai As RequiredFieldValidator
        Protected WithEvents lbtnKodePiutangSampai As LinkButton
        Protected WithEvents txtKodePiutangSampai As TextBox
        Protected WithEvents RequiredFieldValidatorKodePiutangSampai As RequiredFieldValidator
        Protected WithEvents pd54 As Panel
        Protected WithEvents txtKodePiutangNonOprMulai As TextBox
        Protected WithEvents RequiredFieldValidatorKodePiutangNonOprMulai As RequiredFieldValidator
        Protected WithEvents lbtnKodePiutangNonOprSampai As LinkButton
        Protected WithEvents txtKodePiutangNonOprSampai As TextBox
        Protected WithEvents RequiredFieldValidatorKodePiutangNonOprSampai As RequiredFieldValidator
        Protected WithEvents RequiredFieldValidatorkdlayanawal As RequiredFieldValidator
        Protected WithEvents RequiredFieldValidatorkdlayanakhir As RequiredFieldValidator
        Protected WithEvents RequiredFieldValidatorkdtestawal As RequiredFieldValidator
        Protected WithEvents RequiredFieldValidatorkdtestakhir As RequiredFieldValidator
        Protected WithEvents RequiredFieldValidatorKodeInstansiditagihkanMulai As RequiredFieldValidator
        Protected WithEvents RequiredFieldValidatorKodeInstansiditagihkanSampai As RequiredFieldValidator
        Protected WithEvents RequiredFieldValidatorKodeBuku As RequiredFieldValidator
        Protected WithEvents RequiredFieldValidatorKodeCoaawal As RequiredFieldValidator
        Protected WithEvents RequiredFieldValidatorKodeCoaakhir As RequiredFieldValidator
        Protected WithEvents RequiredFieldValidatornormMulai As RequiredFieldValidator
        Protected WithEvents RequiredFieldValidatornormSampai As RequiredFieldValidator
        Protected WithEvents ddlSignature As DropDownList
        Protected WithEvents pd55 As Panel


        'Deklarasi componentUI panel65 (pd65) untuk chekbox semua dokter 
        'Protected WithEvents pd65 As Panel


        Protected WithEvents chkLunas As CheckBox

        Protected WithEvents pdExternal As Panel
        Protected WithEvents Chkformat As CheckBox

        Protected WithEvents pdJam As Panel
        Protected WithEvents ddlShiftJam As DropDownList
        Protected WithEvents txtJamDari As eWorld.UI.MaskedTextBox
        Protected WithEvents txtJamSampai As eWorld.UI.MaskedTextBox

        Protected WithEvents pdTagihan As Panel
        Protected WithEvents txtTagihanMin As TextBox

        Protected WithEvents pdVoid As Panel
        Protected WithEvents ddlVoid As DropDownList

        Protected WithEvents pdPMedisUser As Panel
        Protected WithEvents ddlPMedisUser As DropDownList

#End Region


        Private Class SessionID

            Public Const rpt As String = "Cache:RptAspx:rpt:"
            Public Const par As String = "Cache:RptAspx:par:"
            Public Const returnUrl As String = "Cache:RptAspx:returnUrl:"
            Public Const reportCaption As String = "Cache:RptAspx:reportCaption:"
            Public Const UserName As String = "Cache:RptAspx:UserName:"
            Public Const user As String = "Cache:RptAspx:useUser:"
        End Class

        Public Property Session_rpt() As String
            Get
                Try
                    Return CType(Session.Item(SessionID.rpt), String)
                Catch
                    Return String.Empty
                End Try
            End Get
            Set(ByVal Value As String)
                If Value = Nothing Then
                    Session.Remove(SessionID.rpt)
                Else
                    Session(SessionID.rpt) = Value
                End If
            End Set
        End Property

        Public Property Session_par() As String
            Get
                Try
                    Return CType(Session.Item(SessionID.par), String)
                Catch
                    Return String.Empty
                End Try
            End Get
            Set(ByVal Value As String)
                If Value = Nothing Then
                    Session.Remove(SessionID.par)
                Else
                    Session(SessionID.par) = Value
                End If
            End Set
        End Property

        Public Property Session_ReportCaption() As String
            Get
                Try
                    Return CType(Session.Item(SessionID.reportCaption), String)
                Catch
                    Return String.Empty
                End Try
            End Get
            Set(ByVal Value As String)
                If Value = Nothing Then
                    Session.Remove(SessionID.reportCaption)
                Else
                    Session(SessionID.reportCaption) = Value
                End If
            End Set
        End Property

        Public Property Session_ReturnUrl() As String
            Get
                Try
                    Return CType(Session.Item(SessionID.returnUrl), String)
                Catch
                    Return String.Empty
                End Try
            End Get
            Set(ByVal Value As String)
                If Value = Nothing Then
                    Session.Remove(SessionID.returnUrl)
                Else
                    Session(SessionID.returnUrl) = Value
                End If
            End Set
        End Property

        Public Property Session_useUser() As String
            Get
                Try
                    Return CType(Session.Item(SessionID.user), String)
                Catch
                    Return String.Empty
                End Try

            End Get
            Set(ByVal Value As String)
                If Value = Nothing Then
                    Session.Remove(SessionID.user)
                Else
                    Session(SessionID.user) = Value
                End If
            End Set
        End Property

        Private Sub ReadQueryString()
            Try
                pd1.Visible = (Request.QueryString("pd1") = "True")

                If pd1.Visible Then
                    calStart.selectedDate = Date.Now
                    calEnd.selectedDate = Date.Now
                End If
            Catch
            End Try

            'Try
            '    pdJam.Visible = (Request.QueryString("pdJam") = "True")

            '    If pdJam.Visible Then
            '        ddlShiftJam_SelectedIndexChanged(Nothing, Nothing)
            '        txtJamDari.Text = String.Empty
            '        txtJamSampai.Text = String.Empty
            '    End If
            'Catch
            'End Try

            Try
                pd3.Visible = (Request.QueryString("pd3") = "True")

                If pd3.Visible Then
                    txtdrMulai.Text = "000"
                    txtdrSampai.Text = "ZZZ"

                    lbtndrMulai.Attributes.Add("OnClick", "ShowDialogMedis('" + txtdrMulai.ClientID + "');")
                    txtdrMulai.Attributes.Add("OnKeyDown", "HookKeyCode(urlbmedis,document.getElementById('" + txtdrMulai.ClientID + "').value,'" + txtdrMulai.ClientID + "','nama');")
                    lbtndrSampai.Attributes.Add("OnClick", "ShowDialogMedis('" + txtdrSampai.ClientID + "');")
                    txtdrSampai.Attributes.Add("OnKeyDown", "HookKeyCode(urlbmedis,document.getElementById('" + txtdrSampai.ClientID + "').value,'" + txtdrSampai.ClientID + "','nama');")
                End If
            Catch
            End Try

            Try
                'Read period parameter
                pdPMedisUser.Visible = CType(Request.QueryString("pdPMedisUser"), Boolean)
            Catch
            End Try

            Try
                pd5.Visible = (Request.QueryString("pd5") = "True")

                If pd5.Visible Then
                    txtKodeInstansiMulai.Text = "000"
                    txtKodeInstansiSampai.Text = "ZZZ"

                    lbtnKodeInstansiMulai.Attributes.Add("OnClick", "ShowDialogInstansi('" + txtKodeInstansiMulai.ClientID + "');")
                    lbtnKodeInstansiSampai.Attributes.Add("OnClick", "ShowDialogInstansi('" + txtKodeInstansiSampai.ClientID + "');")
                End If
            Catch
            End Try

            'Try
            '    pdJnsInstansi.Visible = (Request.QueryString("pdJnsInstansi") = "True")
            '    If pdJnsInstansi.Visible Then
            '        commonFunction.SetDropDownLisToStdData(ddlJnsInstansi, "JNINSTANSI", False)
            '        chksmuaInstansi_CheckedChanged(Nothing, Nothing)
            '    End If
            'Catch
            'End Try


            Try
                pd59.Visible = (Request.QueryString("pd59") = "True")

                If pd59.Visible Then
                    txtKodeInstansiditagihkanMulai.Text = "000"
                    txtKodeInstansiditagihkanSampai.Text = "ZZZ"

                    lbtnKodeInstansiditagihkanMulai.Attributes.Add("OnClick", "ShowDialogInstansi('" + txtKodeInstansiditagihkanMulai.ClientID + "');")
                    lbtnKodeInstansiditagihkanSampai.Attributes.Add("OnClick", "ShowDialogInstansi('" + txtKodeInstansiditagihkanSampai.ClientID + "');")
                End If
            Catch
            End Try


            Try
                pd58.Visible = (Request.QueryString("pd58") = "True")

                If pd58.Visible Then
                    txtnormMulai.Text = "000"
                    txtnormSampai.Text = "ZZZ"

                    lbtnnormMulai.Attributes.Add("OnClick", "ShowDialogRekamMedis('" + txtnormMulai.ClientID + "');")
                    lbtnnormSampai.Attributes.Add("OnClick", "ShowDialogRekamMedis('" + txtnormSampai.ClientID + "');")
                End If
            Catch
            End Try


            Try
                Pd25.Visible = (Request.QueryString("pd25") = "True")

                If Pd25.Visible Then
                    txtkdlayanawal.Text = "000"
                    txtkdlayanakhir.Text = "ZZZ"

                    lbtnkdlayanawal.Attributes.Add("OnClick", "ShowDialogTarifPelayanan('" + txtkdlayanawal.ClientID + "');")
                    'txtkdlayanawal.Attributes.Add("OnClick", "ShowDialogTarifPelayanan('" + txtkdlayanawal.ClientID + "');")
                    lbtnkdlayanakhir.Attributes.Add("OnClick", "ShowDialogTarifPelayanan('" + txtkdlayanakhir.ClientID + "');")
                    'txtkdlayanakhir.Attributes.Add("OnClick", "ShowDialogTarifPelayanan('" + txtkdlayanakhir.ClientID + "');")
                End If
            Catch
            End Try


            Try
                pd86.Visible = (Request.QueryString("pd86") = "True")

                If pd86.Visible Then
                    txtkdtestawal.Text = "000"
                    txtkdtestakhir.Text = "ZZZ"

                    lbtnkdtestawal.Attributes.Add("OnClick", "ShowDialogkdtest('" + txtkdtestawal.ClientID + "');")
                    'txtkdtestawal.Attributes.Add("OnClick", "ShowDialogkdtest('" + txtkdtestawal.ClientID + "');")
                    lbtnkdtestakhir.Attributes.Add("OnClick", "ShowDialogkdtest('" + txtkdtestakhir.ClientID + "');")
                    'txtkdtestakhir.Attributes.Add("OnClick", "ShowDialogkdtest('" + txtkdtestakhir.ClientID + "');")
                End If
            Catch
            End Try


            Try
                pd53.Visible = (Request.QueryString("pd53") = "True")

                If pd53.Visible Then
                    txtNoInvoiceMulai.Text = "000"
                    txtNoInvoiceSampai.Text = "ZZZ"

                    lbtnNoInvoiceMulai.Attributes.Add("OnClick", "ShowDialogPiutangInstansi('" + txtNoInvoiceMulai.ClientID + "',document.getElementById('" + txtKodeInstansi.ClientID + "').value);")
                    '                    txtNoInvoiceMulai.Attributes.Add("OnClick", "ShowDialogPiutangInstansi('" + txtNoInvoiceMulai.ClientID + "');")
                    lbtnNoInvoiceSampai.Attributes.Add("OnClick", "ShowDialogPiutangInstansi('" + txtNoInvoiceSampai.ClientID + "',document.getElementById('" + txtKodeInstansi.ClientID + "').value);")
                    '                  txtNoInvoiceSampai.Attributes.Add("OnClick", "ShowDialogPiutangInstansi('" + txtNoInvoiceSampai.ClientID + "');")
                End If
            Catch
            End Try

            Try
                pd54.Visible = (Request.QueryString("pd54") = "True")

                If pd54.Visible Then
                    txtKodePiutangNonOprMulai.Text = "000"
                    txtKodePiutangNonOprSampai.Text = "ZZZ"

                    lbtnKodePiutangNonOprMulai.Attributes.Add("OnClick", "ShowDialogPiutangNonOperasionalAktif('" + txtKodePiutangNonOprMulai.ClientID + "');")
                    lbtnKodePiutangNonOprSampai.Attributes.Add("OnClick", "ShowDialogPiutangNonOperasionalAktif('" + txtKodePiutangNonOprSampai.ClientID + "');")
                End If
            Catch
            End Try

            Try
                pd8.Visible = (Request.QueryString("pd8") = "True")
                If pd8.Visible Then
                    txtUser.Text = MyBase.PB_UserID.Trim
                End If
            Catch
            End Try

            Try
                pd11.Visible = (Request.QueryString("pd11") = "True")
                If pd11.Visible Then
                    txtDTDStart.Text = "000"
                    txtDTDEnd.Text = "ZZZ"
                    linkDTDStart.Attributes.Add("OnClick", "ShowDialogDTD('" + txtDTDStart.ClientID + "');")
                    linkDTDEnd.Attributes.Add("OnClick", "ShowDialogDTD('" + txtDTDEnd.ClientID + "');")
                End If
            Catch
            End Try

            Try
                pd12.Visible = (Request.QueryString("pd12") = "True")
                If pd12.Visible Then
                    txtPoliStart.Text = "000"
                    txtPoliEnd.Text = "ZZZ"
                    linkPoliStart.Attributes.Add("OnClick", "ShowDialogPoliklinik('" + txtPoliStart.ClientID + "');")
                    linkPoliEnd.Attributes.Add("OnClick", "ShowDialogPoliklinik('" + txtPoliEnd.ClientID + "');")
                End If
            Catch
            End Try

            Try
                pd17.Visible = (Request.QueryString("pd17") = "True")
            Catch
            End Try

            Try
                pd18.Visible = (Request.QueryString("pd18") = "True")
            Catch

            End Try


            Try
                pd22.Visible = (Request.QueryString("pd22") = "True")
            Catch

            End Try

            Try
                pd89.Visible = (Request.QueryString("pd89") = "True")
            Catch

            End Try

            Try
                pd48.Visible = (Request.QueryString("pd48") = "True")
            Catch

            End Try

            Try
                pd20.Visible = (Request.QueryString("pd20") = "True")
                If pd20.Visible Then
                    txtDiagnosaStart.Text = "000"
                    txtDiagnosaEnd.Text = "ZZZ"
                    linkDiagnosaStart.Attributes.Add("OnClick", "ShowDialogDiagnosa('" + txtDiagnosaStart.ClientID + "');")
                    linkDiagnosaEnd.Attributes.Add("OnClick", "ShowDialogDiagnosa('" + txtDiagnosaEnd.ClientID + "');")
                End If
            Catch
            End Try


            'Try
            '    pd21.Visible = (Request.QueryString("pd21") = "True")
            '    If pd21.Visible Then
            '        commonFunction.SetDropDownLisToSortBy(ddlSortBy, False)
            '    End If
            'Catch ex As Exception

            'End Try


            'Try
            '    pd24.Visible = (Request.QueryString("pd24") = "True")
            '    If pd24.Visible Then
            '        commonFunction.SetDropDownLisToShift(DdlShift, True)
            '    End If
            'Catch ex As Exception

            'End Try



            'Try
            '    pd23.Visible = (Request.QueryString("pd23") = "True")
            '    If pd23.Visible Then
            '        commonFunction.SetDropDownLisToSortByPribadi(ddlSortByPribadi, False)
            '    End If
            'Catch ex As Exception

            'End Try

            Try
                Pd28.Visible = (Request.QueryString("pd28") = "True")
                If Pd28.Visible Then
                    txtkodeposmulai.Text = "000"
                    Txtkodepossampai.Text = "ZZZ"
                    lbtnkodeposmulai.Attributes.Add("OnClick", "ShowDialogKodePos('" + txtkodeposmulai.ClientID + "');")
                    txtkodeposmulai.Attributes.Add("OnKeyDown", "HookKeyCode(urlbkodepos,document.getElementById('" + txtkodeposmulai.ClientID + "').value,'" + txtkodeposmulai.ClientID + "','kodepos');")
                    lbtnkodepossampai.Attributes.Add("OnClick", "ShowDialogKodePos('" + Txtkodepossampai.ClientID + "');")
                    Txtkodepossampai.Attributes.Add("OnKeyDown", "HookKeyCode(urlbkodepos,document.getElementById('" + Txtkodepossampai.ClientID + "').value,'" + Txtkodepossampai.ClientID + "','');")
                End If
            Catch ex As Exception

            End Try

            Try
                Pd29.Visible = (Request.QueryString("pd29") = "True")
                If Pd29.Visible Then
                    txtkodepengirimmulai.Text = "000"
                    Txtkodepengirimsampai.Text = "ZZZ"
                    lbtnKodePengirimmulai.Attributes.Add("OnClick", "ShowDialogPengirim('" + txtkodepengirimmulai.ClientID + "');")
                    txtkodepengirimmulai.Attributes.Add("OnKeyDown", "HookKeyCode(urlbpengirim,document.getElementById('" + txtkodepengirimmulai.ClientID + "').value,'" + txtkodepengirimmulai.ClientID + "','');")
                    lbtnkodepengirimsampai.Attributes.Add("OnClick", "ShowDialogPengirim('" + Txtkodepengirimsampai.ClientID + "');")
                    Txtkodepengirimsampai.Attributes.Add("OnKeyDown", "HookKeyCode(urlbpengirim,document.getElementById('" + Txtkodepengirimsampai.ClientID + "').value,'" + Txtkodepengirimsampai.ClientID + "','');")

                End If
            Catch ex As Exception

            End Try

            Try
                Pd30.Visible = (Request.QueryString("pd30") = "True")
                If Pd30.Visible Then
                    txtkodetindakanmulai.Text = "000"
                    TxtkodeTindakansampai.Text = "ZZZ"
                    lbtnTindakanmulai.Attributes.Add("OnClick", "ShowDialogTindakan('" + txtkodetindakanmulai.ClientID + "');")
                    txtkodetindakanmulai.Attributes.Add("OnKeyDown", "HookKeyCode(urlbtindakan,document.getElementById('" + txtkodetindakanmulai.ClientID + "').value,'" + txtkodetindakanmulai.ClientID + "','');")
                    lbtnTindakansampai.Attributes.Add("OnClick", "ShowDialogTindakan('" + TxtkodeTindakansampai.ClientID + "');")
                    TxtkodeTindakansampai.Attributes.Add("OnKeyDown", "HookKeyCode(urlbtindakan,document.getElementById('" + TxtkodeTindakansampai.ClientID + "').value,'" + TxtkodeTindakansampai.ClientID + "','');")
                End If
            Catch ex As Exception

            End Try
            Try
                Pd31.Visible = (Request.QueryString("pd31") = "True")
                If Pd31.Visible Then
                    txtkodebankmulai.Text = "000"
                    Txtkodebanksampai.Text = "ZZZ"
                    lbtnBankmulai.Attributes.Add("OnClick", "ShowDialogBank('" + txtkodebankmulai.ClientID + "');")
                    txtkodebankmulai.Attributes.Add("OnKeyDown", "HookKeyCode(urlbbank,document.getElementById('" + txtkodebankmulai.ClientID + "').value,'" + txtkodebankmulai.ClientID + "','');")
                    lbtnbanksampai.Attributes.Add("OnClick", "ShowDialogBank('" + Txtkodebanksampai.ClientID + "');")
                    Txtkodebanksampai.Attributes.Add("OnKeyDown", "HookKeyCode(urlbbank,document.getElementById('" + Txtkodebanksampai.ClientID + "').value,'" + Txtkodebanksampai.ClientID + "','');")

                End If
            Catch ex As Exception

            End Try

            Try
                Pd32.Visible = (Request.QueryString("pd32") = "True")
                If Pd32.Visible Then
                    txtmorfologimulai.Text = "000"
                    Txtmorfologisampai.Text = "ZZZ"
                    lbtnMorfologimulai.Attributes.Add("OnClick", "ShowDialogMorfologi('" + txtmorfologimulai.ClientID + "');")
                    txtmorfologimulai.Attributes.Add("OnKeyDown", "HookKeyCode(urlbmorfologi,document.getElementById('" + txtmorfologimulai.ClientID + "').value,'" + txtmorfologimulai.ClientID + "','');")
                    lbtnmorfologisampai.Attributes.Add("OnClick", "ShowDialogMorfologi('" + Txtmorfologisampai.ClientID + "');")
                    Txtmorfologisampai.Attributes.Add("OnKeyDown", "HookKeyCode(urlbmorfologi,document.getElementById('" + Txtmorfologisampai.ClientID + "').value,'" + Txtmorfologisampai.ClientID + "','');")

                End If
            Catch ex As Exception

            End Try

            Try
                Pd33.Visible = (Request.QueryString("pd33") = "True")
                If Pd33.Visible Then
                    txtpenunjangmedismulai.Text = "000"
                    Txtpenunjangmedissampai.Text = "ZZZ"
                    lbtnPenunjangMedismulai.Attributes.Add("OnClick", " ShowDialogPnjMedis('" + txtpenunjangmedismulai.ClientID + "');")
                    txtpenunjangmedismulai.Attributes.Add("OnKeyDown", "HookKeyCode(urlbpnjmedis,document.getElementById('" + txtpenunjangmedismulai.ClientID + "').value,'" + txtpenunjangmedismulai.ClientID + "','');")
                    lbtnpenunjangmedissampai.Attributes.Add("OnClick", " ShowDialogPnjMedis('" + Txtpenunjangmedissampai.ClientID + "');")
                    Txtpenunjangmedissampai.Attributes.Add("OnKeyDown", "HookKeyCode(urlbpnjmedis,document.getElementById('" + Txtpenunjangmedissampai.ClientID + "').value,'" + Txtpenunjangmedissampai.ClientID + "','');")

                End If
            Catch ex As Exception

            End Try

            Try
                Pd34.Visible = (Request.QueryString("pd34") = "True")
                If Pd34.Visible Then
                    txtsmfmulai.Text = "000"
                    Txtsmfsampai.Text = "ZZZ"
                    lbtnSMFmulai.Attributes.Add("OnClick", " ShowDialogSMF('" + txtsmfmulai.ClientID + "');")
                    txtsmfmulai.Attributes.Add("OnKeyDown", "HookKeyCode(urlbsmf,document.getElementById('" + txtsmfmulai.ClientID + "').value,'" + txtsmfmulai.ClientID + "','');")
                    lbtnSMFsampai.Attributes.Add("OnClick", " ShowDialogSMF('" + Txtsmfsampai.ClientID + "');")
                    Txtsmfsampai.Attributes.Add("OnKeyDown", "HookKeyCode(urlbsmf,document.getElementById('" + Txtsmfsampai.ClientID + "').value,'" + Txtsmfsampai.ClientID + "','');")
                End If
            Catch ex As Exception

            End Try


            Try
                Pd35.Visible = (Request.QueryString("pd35") = "True")
                If Pd35.Visible Then
                    txtruangrawatmulai.Text = "000"
                    Txtruangrawatsampai.Text = "ZZZ"
                    lbtnruangrawatmulai.Attributes.Add("OnClick", " ShowDialogRuang('" + txtruangrawatmulai.ClientID + "');")
                    txtruangrawatmulai.Attributes.Add("OnKeyDown", "HookKeyCode(urlbruang,document.getElementById('" + txtruangrawatmulai.ClientID + "').value,'" + txtruangrawatmulai.ClientID + "','');")
                    lbtnRuangrawatsampai.Attributes.Add("OnClick", " ShowDialogRuang('" + Txtruangrawatsampai.ClientID + "');")
                    Txtruangrawatsampai.Attributes.Add("OnKeyDown", "HookKeyCode(urlbruang,document.getElementById('" + Txtruangrawatsampai.ClientID + "').value,'" + Txtruangrawatsampai.ClientID + "','');")
                End If
            Catch ex As Exception

            End Try


            Try
                Pd36.Visible = (Request.QueryString("pd36") = "True")
                If Pd36.Visible Then
                    txtKelasmulai.Text = "000"
                    Txtkelassampai.Text = "ZZZ"
                    lbtnkelasmulai.Attributes.Add("OnClick", " ShowDialogKelas('" + txtKelasmulai.ClientID + "');")
                    txtKelasmulai.Attributes.Add("OnKeyDown", "HookKeyCode(urlbkelas,document.getElementById('" + txtKelasmulai.ClientID + "').value,'" + txtKelasmulai.ClientID + "','');")
                    lbtnkelassampai.Attributes.Add("OnClick", " ShowDialogKelas('" + Txtkelassampai.ClientID + "');")
                    Txtkelassampai.Attributes.Add("OnKeyDown", "HookKeyCode(urlbkelas,document.getElementById('" + Txtkelassampai.ClientID + "').value,'" + Txtkelassampai.ClientID + "','');")
                End If
            Catch ex As Exception

            End Try

            Try
                pd37.Visible = (Request.QueryString("pd37") = "True")
                If pd37.Visible Then
                    cal.selectedDate = Date.Now
                End If
            Catch ex As Exception

            End Try

            'Try
            '    pd38.Visible = (Request.QueryString("pd38") = "True")
            '    If pd38.Visible Then
            '        commonFunction.SetDropDownLisToJM(ddlJasaMedis, False)
            '    End If
            'Catch ex As Exception

            'End Try

            'Try
            '    pd85.Visible = (Request.QueryString("pd85") = "True")
            '    If pd85.Visible Then
            '        commonFunction.SetDropDownLisToModuleS(ddlPnjlnItem, True, True, True, True, True, False, True, False)
            '    End If
            'Catch ex As Exception

            'End Try

            'Try
            '    Pd93.Visible = (Request.QueryString("pd93") = "True")
            '    If Pd93.Visible Then
            '        pd86.Visible = False
            '        pd25.Visible = False
            '        commonFunction.SetDropDownLisToModuleS(ddlsmrirjrdmdmculb, True, True, True, True, True, True, False, True)
            '    End If
            'Catch ex As Exception

            'End Try

            'Try
            '    pd92.Visible = (Request.QueryString("pd92") = "True")
            '    If pd92.Visible Then
            '        commonFunction.SetDropDownLisToModuleS(ddlsemuaasalpasien, True, True, True, True, True, True, True, True)
            '    End If
            'Catch ex As Exception

            'End Try

            'Try
            '    pd83.Visible = (Request.QueryString("pd83") = "True")
            '    If pd83.Visible Then
            '        commonFunction.SetDropDownLisToModuleS(ddlPiutangInstansiRIRJ, True, True, True, False, False, False, False, False)
            '    End If
            'Catch ex As Exception

            'End Try


            'Try
            '    pd26.Visible = (Request.QueryString("pd26") = "True")
            '    If pd26.Visible Then
            '        commonFunction.SetDropDownLisToModuleS(ddlmoduleS, True, True, True, True, True, True, True, True)
            '    End If
            'Catch ex As Exception

            'End Try

            'Try
            '    pd91.Visible = (Request.QueryString("pd91") = "True")
            '    If pd91.Visible Then
            '        commonFunction.SetDropDownLisToModuleS(ddlmoduleSMCULB, True, False, False, False, False, True, False, True)
            '    End If
            'Catch ex As Exception

            'End Try

            'Try
            '    pd190.Visible = (Request.QueryString("pd190") = "True")
            '    If pd190.Visible Then
            '        commonFunction.SetDropDownLisToPiutangInstansiPasien(ddlPiutangInstansi, True)
            '    End If
            'Catch ex As Exception

            'End Try

            'Try
            '    pd39.Visible = (Request.QueryString("pd39") = "True")
            '    If pd39.Visible Then
            '        commonFunction.SetDropDownLisToApp3(ddlJenisTransaksi)
            '    End If
            'Catch ex As Exception

            'End Try

            Try
                Pd40.Visible = (Request.QueryString("pd40") = "True")
                If Pd40.Visible Then
                    txtSupplierAwal.Text = "000"
                    txtSupplierAkhir.Text = "ZZZ"
                    lbtnSupplierAwal.Attributes.Add("OnClick", "ShowDialogSupplier('" + txtSupplierAwal.ClientID + "');")
                    txtSupplierAwal.Attributes.Add("OnKeyDown", "HookKeyCode(urlbsupplier,document.getElementById('" + txtSupplierAwal.ClientID + "').value,'" + txtSupplierAwal.ClientID + "','kdsupplier');")
                    lbtnSupplierAkhir.Attributes.Add("OnClick", "ShowDialogSupplier('" + txtSupplierAkhir.ClientID + "');")
                    txtSupplierAkhir.Attributes.Add("OnKeyDown", "HookKeyCode(urlbsupplier,document.getElementById('" + txtSupplierAkhir.ClientID + "').value,'" + txtSupplierAkhir.ClientID + "','kdsupplier');")
                End If
            Catch ex As Exception

            End Try

            'Try
            '    Pd41.Visible = (Request.QueryString("pd41") = "True")
            '    If Pd41.Visible Then
            '        commonFunction.SetDropDownListCabang(ddlCabangAwal, False)
            '        commonFunction.SetDropDownListCabang(ddlCabangAkhir, False)
            '        chkAllCabang_CheckedChanged(Nothing, Nothing)
            '    End If
            'Catch ex As Exception
            'End Try

            Try
                Pd51.Visible = (Request.QueryString("pd51") = "True")
            Catch ex As Exception


            End Try

            Try
                pd52.Visible = (Request.QueryString("pd52") = "True")
                If pd52.Visible Then
                    lbtnKodeInstansi.Attributes.Add("OnClick", "ShowDialogInstansi('" + txtKodeInstansi.ClientID + "');")
                    txtKodeInstansi.Attributes.Add("OnKeyDown", "HookKeyCode(urlbinstansi,document.getElementById('" + txtKodeInstansi.ClientID + "').value,'" + txtKodeInstansi.ClientID + "','Kdinstansi');")
                End If
            Catch ex As Exception

            End Try

            Try
                Pd27.Visible = (Request.QueryString("pd27") = "True")
                If Pd27.Visible Then
                    lbtnKdBuku.Attributes.Add("OnClick", "ShowDialogBukuTreasury('" + txtKdBuku.ClientID + "');")
                    txtKdBuku.Attributes.Add("OnKeyDown", "HookKeyCode(urlbBukuTreasury,document.getElementById('" + txtKdBuku.ClientID + "').value,'" + txtKdBuku.ClientID + "','KdBuku');")
                End If
            Catch ex As Exception

            End Try

            Try
                Pd57.Visible = (Request.QueryString("pd57") = "True")
                If Pd57.Visible Then
                    txtKdcoaawal.Text = "000"
                    txtKdcoaakhir.Text = "ZZZ"
                    lbtnKdcoaawal.Attributes.Add("OnClick", "ShowDialogKodeCoa('" + txtKdcoaawal.ClientID + "');")
                    lbtnKdcoaakhir.Attributes.Add("OnClick", "ShowDialogKodeCoa('" + txtKdcoaakhir.ClientID + "');")
                End If
            Catch ex As Exception
            End Try

            Try
                pd42.Visible = (Request.QueryString("pd42") = "True")
            Catch ex As Exception
            End Try

            Try
                pd43.Visible = (Request.QueryString("pd43") = "True")
            Catch ex As Exception
            End Try

            Try
                pd44.Visible = (Request.QueryString("pd44") = "True")
                If pd44.Visible Then
                    calTanggal.selectedDate = Date.Now
                End If
            Catch ex As Exception
            End Try

            Try
                Pd45.Visible = (Request.QueryString("pd45") = "True")
                If Pd45.Visible Then
                    lbtnKodeSupplier.Attributes.Add("OnClick", "ShowDialogSupplier('" + txtKodeSupplier.ClientID + "');")
                    txtKodeSupplier.Attributes.Add("OnKeyDown", "HookKeyCode(urlbsupplier,document.getElementById('" + txtKodeSupplier.ClientID + "').value,'" + txtKodeSupplier.ClientID + "','kdsupplier');")
                    txtKodeSupplier.Text = String.Empty
                End If
            Catch ex As Exception
            End Try

            'Try
            '    pd46.Visible = (Request.QueryString("pd46") = "True")
            '    If pd46.Visible Then
            '        commonFunction.SetDropDownLisToModuleAPP(ddlmodule)
            '        lbtnMenuAwal.Attributes.Add("OnClick", "ShowDialogMenu('" + txtMenuAwal.ClientID + "', document.getElementById('" + ddlmodule.ClientID + "').value);")
            '        txtMenuAwal.Attributes.Add("OnKeyDown", "HookKeyCode(urlbmenu,document.getElementById('" + txtMenuAwal.ClientID + "').value,'" + txtMenuAwal.ClientID + "','moduleid', '&mdl='+document.getElementById('" + ddlmodule.ClientID + "').value);")
            '        lbtnMenuAkhir.Attributes.Add("OnClick", "ShowDialogMenu('" + txtMenuAkhir.ClientID + "', document.getElementById('" + ddlmodule.ClientID + "').value);")
            '        txtMenuAkhir.Attributes.Add("OnKeyDown", "HookKeyCode(urlbMenu,document.getElementById('" + txtMenuAkhir.ClientID + "').value,'" + txtMenuAkhir.ClientID + "','moduleid', '&mdl='+document.getElementById('" + ddlmodule.ClientID + "').value);")
            '        txtMenuAwal.Text = "000"
            '        txtMenuAkhir.Text = "ZZZ"
            '    End If
            'Catch ex As Exception
            'End Try

            Try
                pdVoid.Visible = (Request.QueryString("pdVoid") = "True")
            Catch ex As Exception
            End Try

            Try
                Pd47.Visible = (Request.QueryString("pd47") = "True")
                If Pd47.Visible Then
                    lbtnUser.Attributes.Add("OnClick", "ShowDialogUser('" + txtUser1.ClientID + "');")
                    txtUser1.Attributes.Add("OnKeyDown", "HookKeyCode(urlbuser,document.getElementById('" + txtUser1.ClientID + "').value,'" + txtUser1.ClientID + "','UserID');")
                    txtUser1.Text = String.Empty
                End If
            Catch ex As Exception
            End Try

            Try
                Pd90.Visible = (Request.QueryString("pd90") = "True")
                If Pd90.Visible Then
                    lbtntarifgroup.Attributes.Add("OnClick", "ShowDialogTarifGroup('" + txttarifgroup.ClientID + "');")
                    txttarifgroup.Attributes.Add("OnKeyDown", "HookKeyCode(urlbtarifgroup,document.getElementById('" + txttarifgroup.ClientID + "').value,'" + txttarifgroup.ClientID + "','UserID');")
                    txttarifgroup.Text = String.Empty
                End If
            Catch ex As Exception
            End Try

            Try
                Pd99.Visible = (Request.QueryString("pd99") = "True")
                If Pd99.Visible Then
                    lbtntarifgroupawal.Attributes.Add("OnClick", "ShowDialogTarifGroup('" + txttarifgroupawal.ClientID + "');")
                    txttarifgroupawal.Attributes.Add("OnKeyDown", "HookKeyCode(urlbtarifgroup,document.getElementById('" + txttarifgroupawal.ClientID + "').value,'" + txttarifgroupawal.ClientID + "','UserID');")
                    txttarifgroupawal.Text = "000"
                    lbtntarifgroupakhir.Attributes.Add("OnClick", "ShowDialogTarifGroup('" + txttarifgroupakhir.ClientID + "');")
                    txttarifgroupakhir.Attributes.Add("OnKeyDown", "HookKeyCode(urlbtarifgroup,document.getElementById('" + txttarifgroupakhir.ClientID + "').value,'" + txttarifgroupakhir.ClientID + "','UserID');")
                    txttarifgroupakhir.Text = "ZZZ"
                End If
            Catch ex As Exception
            End Try

            Try
                Pd87.Visible = (Request.QueryString("pd87") = "True")
                If Pd87.Visible Then
                    lbtnTestgroup.Attributes.Add("OnClick", "ShowDialogTestGroup('" + txtTestgroup.ClientID + "');")
                    txtTestgroup.Attributes.Add("OnKeyDown", "HookKeyCode(urlbTestgroup,document.getElementById('" + txtTestgroup.ClientID + "').value,'" + txtTestgroup.ClientID + "','UserID');")
                    txtTestgroup.Text = String.Empty
                End If
            Catch ex As Exception
            End Try

            Try
                pd49.Visible = (Request.QueryString("pd49") = "True")
            Catch
            End Try

            Try
                pd50.Visible = (Request.QueryString("pd50") = "True")
            Catch
            End Try

            Try
                pd60.Visible = (Request.QueryString("pd60") = "True")
            Catch
            End Try

            Try
                pd61.Visible = (Request.QueryString("pd61") = "True")
            Catch
            End Try

            Try
                pd62.Visible = (Request.QueryString("pd62") = "True")
            Catch
            End Try

            Try
                pd64.Visible = (Request.QueryString("pd64") = "True")
                If pd64.Visible Then
                    lbtnkddokter.Attributes.Add("OnClick", "ShowDialogMedis('" + TxtKddokter.ClientID + "');")
                    TxtKddokter.Attributes.Add("OnKeyDown", "HookKeyCode(urlbmedis,document.getElementById('" + TxtKddokter.ClientID + "').value,'" + TxtKddokter.ClientID + "','nama');")
                    TxtKddokter.Text = String.Empty
                End If
            Catch ex As Exception
            End Try

            Try
                pdchkAllPending.Visible = (Request.QueryString("pdchkAllPending") = "True")
            Catch ex As Exception
            End Try

            'Try
            '    'Read period parameter
            '    pd55.Visible = CType(Request.QueryString("pd55"), Boolean)
            '    If pd55.Visible Then
            '        commonFunction.SetDropDownLisToStdData(ddlSignature, "RS_SURATJT", False)
            '    End If
            'Catch
            'End Try

            'Try
            '    'Read period parameter
            '    pd96.Visible = CType(Request.QueryString("pd96"), Boolean)
            '    If pd96.Visible Then
            '        commonFunction.SetDropDownLisToStdData(ddlMataUang, "MATAUANG", False)
            '    End If
            'Catch
            'End Try

            'Try
            '    'Read period parameter
            '    pd84.Visible = CType(Request.QueryString("pd84"), Boolean)
            '    If pd84.Visible Then
            '        commonFunction.SetDropDownLisToModuleS(ddlktr, False, True, True, True, True, True, False, True)
            '    End If
            'Catch
            'End Try

            Try
                pdExternal.Visible = CType(Request.QueryString("pdExternal"), Boolean)
            Catch
            End Try

            Try
                pdTagihan.Visible = CType(Request.QueryString("pdTagihan"), Boolean)
            Catch
            End Try

            Try
                'Read designated ASP file
                If Not CType(Request.QueryString("returnUrl"), String) Is Nothing Then
                    Session_ReturnUrl = CType(Request.QueryString("returnUrl"), String)
                End If
            Catch
            End Try

            Try
                'Read report caption
                If Not CType(Request.QueryString("rc"), String) Is Nothing Then
                    Session_ReportCaption = CType(Request.QueryString("rc"), String)
                End If
            Finally
                lblReportDesc.Text = CType(Request.QueryString("rc"), String)
            End Try


            Try
                'Read ReportID
                'Session_rpt = Nothing
                Session_useUser = CType(Request.QueryString("pdUser"), String)
            Catch
            End Try

            Try
                'Read ReportID
                If Not CType(Request.QueryString("rpt"), String) Is Nothing Then
                    Session_rpt = CType(Request.QueryString("rpt"), String)
                End If
            Catch
            End Try

            Try
                'Read ReportParam
                If Not CType(Request.QueryString("par"), String) Is Nothing Then
                    Session_par = CType(Request.QueryString("par"), String)
                End If
            Catch
            End Try
        End Sub

        Private Sub btnPreview1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPreview1.Click
            Dim url As New StringBuilder
            Dim strMonth As String

            With url
                '.Append("http://" + Context.Request.Url.Host + Common.HisConfiguration.ReportsFolder + Session_ReturnUrl)
                ' #1 modified by bang_t dec 30 2009 
                ' untuk melewatkan parameter tanpa melalui PD
                If url.ToString.IndexOf("?") < 0 Then
                    .Append("?")
                Else
                    .Append("&")
                End If
                ' end of #1

                If pd1.Visible Then
                    'period paramater is visible, then send out date parameter
                    .Append("tl=" + Format(calStart.selectedDate, "MM/dd/yyyy"))
                    .Append("&tr=" + Format(calEnd.selectedDate, "MM/dd/yyyy"))
                    .Append("&")
                End If
                If pd3.Visible Then
                    .Append("dl=" + txtdrMulai.Text.Trim)
                    .Append("&")
                    .Append("dr=" + txtdrSampai.Text.Trim)
                    .Append("&")
                End If


                If pd59.Visible Then
                    .Append("ildt=" + txtKodeInstansiditagihkanMulai.Text.Trim)
                    .Append("&irdt=" + txtKodeInstansiditagihkanSampai.Text.Trim)
                    .Append("&")
                End If

                If pd58.Visible Then
                    .Append("normaw=" + txtnormMulai.Text.Trim)
                    .Append("&normak=" + txtnormSampai.Text.Trim)
                    .Append("&")
                End If

                If pd25.Visible Then
                    .Append("lyaw=" + txtkdlayanawal.Text.Trim)
                    .Append("&lyak=" + txtkdlayanakhir.Text.Trim)
                    .Append("&")
                End If

                If pd86.Visible Then
                    .Append("tsaw=" + txtkdtestawal.Text.Trim)
                    .Append("&tsak=" + txtkdtestakhir.Text.Trim)
                    .Append("&")
                End If

                If pd53.Visible Then
                    .Append("NoInvS=" + txtNoInvoiceMulai.Text.Trim)
                    .Append("&NoInvE=" + txtNoInvoiceSampai.Text.Trim)
                    .Append("&userid=" + MyBase.PB_UserID.Trim)
                    .Append("&")
                End If
                If pd54.Visible Then
                    .Append("pnl=" + txtKodePiutangNonOprMulai.Text.Trim)
                    .Append("&pnr=" + txtKodePiutangNonOprSampai.Text.Trim)
                    .Append("&")
                End If

                If pd8.Visible Then
                    .Append("usr=" + txtUser.Text.Trim)
                    .Append("&")
                End If
                If pd11.Visible Then
                    .Append("ds=" & txtDTDStart.Text.Trim)
                    .Append("&")
                    .Append("de=" & txtDTDEnd.Text.Trim)
                    .Append("&")
                End If

                If pd17.Visible Then
                    If OptionType.Items(0).Selected = True Then
                        .Append("optnama=nama")
                        .Append("&")
                    End If
                    If OptionType.Items(1).Selected = True Then
                        .Append("optalamat=Alamat")
                        .Append("&")
                    End If
                    If OptionType.Items(2).Selected = True Then
                        .Append("opttgllahir=Tgllahir")
                        .Append("&")
                    End If
                End If
                If pd18.Visible Then
                    If rbReportType.Items(0).Selected = True Then
                        .Append("rt=sum")
                        .Append("&")
                    Else
                        .Append("rt=det")
                        .Append("&")
                    End If
                End If

                If pd48.Visible Then
                    If rbReportTypeSSB.Items(1).Selected = True Then
                        .Append("rtssb=sudah")
                        .Append("&")
                    ElseIf rbReportTypeSSB.Items(2).Selected = True Then
                        .Append("rtssb=belum")
                        .Append("&")
                    Else
                        .Append("rtssb=semua")
                        .Append("&")
                    End If
                End If

                If pd49.Visible Then
                    If rbAuthorizationType.Items(0).Selected = True Then
                        .Append("rt=user")
                        .Append("&")
                    Else
                        .Append("rt=module")
                        .Append("&")
                    End If
                End If
                If pd20.Visible Then
                    .Append("dis=" & txtDiagnosaStart.Text.Trim)
                    .Append("&")
                    .Append("die=" & txtDiagnosaEnd.Text.Trim)
                    .Append("&")
                End If


                If pd21.Visible Then
                    .Append("SortBy=" & ddlSortBy.SelectedItem.Value)
                    .Append("&")
                End If


                If pd23.Visible Then
                    .Append("SortByPribadi=" & ddlSortByPribadi.SelectedItem.Value)
                    .Append("&")
                End If

                If pd24.Visible Then
                    .Append("Shift=" & DdlShift.SelectedItem.Value)
                    .Append("&")
                End If

                If pd22.Visible Then
                    If AscDesc.Items(0).Selected = True Then
                        .Append("AD=Asc")
                        .Append("&")
                    Else
                        .Append("AD=Desc")
                        .Append("&")
                    End If
                End If

                If pd89.Visible Then
                    If DIBAYAR.Items(0).Selected = True Then
                        .Append("FIUH=1")
                        .Append("&")
                    Else
                        .Append("FIUH=0")
                        .Append("&")
                    End If
                End If


                If Pd28.Visible Then
                    .Append("km=" & txtkodeposmulai.Text.Trim)
                    .Append("&")
                    .Append("ks=" & Txtkodepossampai.Text.Trim)
                    .Append("&")
                End If

                If Pd29.Visible Then
                    .Append("pm=" & txtkodepengirimmulai.Text.Trim)
                    .Append("&")
                    .Append("ps=" & Txtkodepengirimsampai.Text.Trim)
                    .Append("&")
                End If


                If Pd30.Visible Then
                    .Append("sg=" & txtkodetindakanmulai.Text.Trim)
                    .Append("&")
                    .Append("eg=" & TxtkodeTindakansampai.Text.Trim)
                    .Append("&")
                End If

                If Pd31.Visible Then
                    .Append("skb=" & txtkodebankmulai.Text.Trim)
                    .Append("&")
                    .Append("ekb=" & Txtkodebanksampai.Text.Trim)
                    .Append("&")
                End If

                If Pd32.Visible Then
                    .Append("skm=" & txtmorfologimulai.Text.Trim)
                    .Append("&")
                    .Append("ekm=" & Txtmorfologisampai.Text.Trim)
                    .Append("&")
                End If



                If Pd34.Visible Then
                    .Append("sks=" & txtsmfmulai.Text.Trim)
                    .Append("&")
                    .Append("eks=" & Txtsmfsampai.Text.Trim)
                    .Append("&")
                End If

                If Pd35.Visible Then
                    .Append("skr=" & txtruangrawatmulai.Text.Trim)
                    .Append("&")
                    .Append("ekr=" & Txtruangrawatsampai.Text.Trim)
                    .Append("&")
                End If

                If Pd36.Visible Then
                    .Append("skk=" & txtKelasmulai.Text.Trim)
                    .Append("&")
                    .Append("ekk=" & Txtkelassampai.Text.Trim)
                    .Append("&")
                End If

                If pd37.Visible Then
                    .Append("tgl=" & cal.selectedDate)
                    .Append("&")
                End If



                If pd85.Visible Then
                    .Append("mdlpnjln=" & ddlPnjlnItem.SelectedItem.Value)
                    .Append("&")
                End If

                If Pd93.Visible Then
                    .Append("mdlsmrirjrdmdmculb=" & ddlsmrirjrdmdmculb.SelectedItem.Value)
                    .Append("&")
                End If

                If pd92.Visible Then
                    .Append("mdlaslpsnall=" & ddlsemuaasalpasien.SelectedItem.Value)
                    .Append("&")
                End If

                If pd83.Visible Then
                    .Append("mdlpiRIRJ=" & ddlPiutangInstansiRIRJ.SelectedItem.Value)
                    .Append("&")
                End If

                If pd91.Visible Then
                    .Append("mdlmculb=" & ddlmoduleSMCULB.SelectedItem.Value)
                    .Append("&")
                End If

                If pd38.Visible Then
                    .Append("jm=" & ddlJasaMedis.SelectedItem.Value)
                    .Append("&")
                End If



                If pd39.Visible Then
                    .Append("jt=" & ddlJenisTransaksi.SelectedItem.Value)
                    .Append("&")
                End If



                If Pd41.Visible Then
                    .Append("cab1=" & ddlCabangAwal.SelectedItem.Value.Trim)
                    .Append("&")
                    .Append("cab2=" & ddlCabangAkhir.SelectedItem.Value.Trim)
                    .Append("&")

                    If chkAllCabang.Checked = True Then
                        .Append("allcab=y")
                        .Append("&")
                    Else
                        .Append("allcab=n")
                        .Append("&")
                    End If

                    '.Append("cab2=" & txtSupplierAkhir.Text.Trim)
                    '.Append("&")
                End If

                If Pd51.Visible Then
                    If StrukLengkap.Checked = True Then
                        .Append("SL=y")
                        .Append("&")
                    Else
                        .Append("SL=n")
                        .Append("&")
                    End If

                    If ResumeMedis.Checked = True Then
                        .Append("RM=y")
                        .Append("&")
                    Else
                        .Append("RM=n")
                        .Append("&")
                    End If

                    If SuratJaminan.Checked = True Then
                        .Append("SJ=y")
                        .Append("&")
                    Else
                        .Append("SJ=n")
                        .Append("&")
                    End If

                    If SuratInformasiPenagihanPiutang.Checked = True Then
                        .Append("SIPP=y")
                        .Append("&")
                    Else
                        .Append("SIPP=n")
                        .Append("&")
                    End If

                    If KwitansiAsli.Checked = True Then
                        .Append("KA=y")
                        .Append("&")
                    Else
                        .Append("KA=n")
                        .Append("&")
                    End If

                    If RincianSelisihBiayaKamarPerKelas.Checked = True Then
                        .Append("RSBKPK=y")
                        .Append("&")
                    Else
                        .Append("RSBKPK=n")
                        .Append("&")
                    End If

                End If

                If pd52.Visible Then
                    .Append("il=" + txtKodeInstansi.Text.Trim)
                    .Append("&")
                End If

                If Pd27.Visible Then
                    .Append("kdbk=" + txtKdBuku.Text.Trim)
                    .Append("&")
                End If

                If Pd57.Visible Then
                    .Append("kdcoal=" + txtKdcoaawal.Text.Trim)
                    .Append("&")
                    .Append("kdcoar=" + txtKdcoaakhir.Text.Trim)
                    .Append("&")
                End If

                If pd42.Visible Then
                    If chkValid.Checked = True Then
                        .Append("val=1")
                        .Append("&")
                    Else
                        .Append("val=0")
                        .Append("&")
                    End If
                End If

                If pd43.Visible Then
                    If chkSemuaSupplier.Checked = True Then
                        .Append("allsupp=1")
                        .Append("&")
                    Else
                        .Append("allsupp=0")
                        .Append("&")
                    End If
                End If



                If Pd45.Visible Then
                    .Append("supp=" + txtKodeSupplier.Text.Trim)
                    .Append("&")
                End If

                If Pd47.Visible Then
                    .Append("us=" + txtUser1.Text.Trim)
                    .Append("&")
                End If

                If Pd90.Visible Then
                    .Append("trfgrp=" + txttarifgroup.Text.Trim)
                    .Append("&")
                End If

                If Pd99.Visible Then
                    .Append("trfgrpawal=" + txttarifgroupawal.Text.Trim)
                    .Append("&")
                    .Append("trfgrpakhir=" + txttarifgroupakhir.Text.Trim)
                    .Append("&")
                End If

                If Pd87.Visible Then
                    .Append("tstgrp=" + txtTestgroup.Text.Trim)
                    .Append("&")
                End If

                If pd46.Visible Then
                    'Module and menu is visible, then send out module parameter
                    .Append("mo=" & ddlmodule.SelectedItem.Value)
                    .Append("&")
                    If ddlmodule.SelectedItem.Value <> "1" Then
                        .Append("usw=" & txtMenuAwal.Text.Trim)
                        .Append("&")
                        .Append("usk=" & txtMenuAkhir.Text.Trim)
                        .Append("&")
                    End If

                End If

                If pd50.Visible Then
                    If chkLunas.Checked = True Then
                        .Append("lns=0")
                        .Append("&")
                    Else
                        .Append("lns=1")
                        .Append("&")
                    End If
                End If

                If pd60.Visible Then
                    .Append("mon=" & ddlBulan.SelectedValue.Trim)
                    .Append("&yr=" & ddlTahun.SelectedItem.Value.Trim)
                    .Append("&")
                End If

                If pd61.Visible Then
                    .Append("yr=" & ddlthn.SelectedItem.Value.Trim)
                    .Append("&")
                End If

                If pd62.Visible Then
                    .Append("mon1=" + ddlBln1.SelectedValue.Trim)
                    .Append("&mon2=" + ddlBln2.SelectedValue.Trim)
                    .Append("&thn1=" + ddlThn1.SelectedItem.Value.Trim)
                    .Append("&thn2=" + ddlThn2.SelectedItem.Value.Trim)
                    .Append("&")
                End If



                'If pd65.Visible Then
                '    If chkAllDokter.Checked = True Then
                '        .Append("alldok=1")
                '        .Append("&")
                '    Else
                '        .Append("alldok=0")
                '        .Append("&")
                '    End If
                'End If

                If pd55.Visible Then
                    .Append("si=" + ddlSignature.SelectedItem.Value.Trim)
                    .Append("&")
                End If

                If pd96.Visible Then
                    .Append("MU=" + ddlMataUang.SelectedItem.Value.Trim)
                    .Append("&")
                End If

                If pd84.Visible Then
                    .Append("rirdrjmculbmd=" + ddlktr.SelectedItem.Value.Trim)
                    .Append("&")
                End If

                If pdchkAllPending.Visible Then
                    .Append("&ap=" & chkAllPending.Checked)
                    .Append("&")
                End If

                If pdExternal.Visible Then
                    .Append("xtrnl=" & Chkformat.Checked)
                    .Append("&")
                End If

                If pdJnsInstansi.Visible Then
                    .Append("ji=" & ddlJnsInstansi.SelectedItem.Value)
                    .Append("&")
                    If chksmuaInstansi.Checked = True Then
                        .Append("allinst=1")
                        .Append("&")
                    Else
                        .Append("allinst=0")
                        .Append("&")
                    End If
                End If

                .Remove(.Length - 1, 1)
            End With
            'open the report window
            Response.Write("<script language=javascript>window.open('" + url.ToString + "',null,'status=no,resizable=yes,toolbar=no,menubar=no,location=no;')</script>")

        End Sub

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            If Not Me.IsPostBack Then
                'Dim fQueryStringExist As Boolean
                commonFunction.SelectListItem(ddlBulan, Date.Now.Month.ToString)
                commonFunction.SelectListItem(ddlTahun, Date.Now.Year.ToString)
                ReadQueryString()
                setBulanTahun()
                If pd85.Visible Then
                    pd12.Visible = False
                    Pd35.Visible = False
                    Pd33.Visible = False
                End If

                setToolbarVisibleButton()
                GenerateReportExplorer()
                'SetDropDownListItem()
                'FormatMaskedTextBox()
            End If
        End Sub

        'Private Sub FormatMaskedTextBox()
        '    Dim formatJAM As String
        '    formatJAM = Common.Methods.GetSettingParameter("format_jam", Common.Constants.ModuleID.SYSTEM_SETUP).Trim

        '    txtJamDari.Mask = formatJAM
        '    txtJamSampai.Mask = formatJAM
        'End Sub

        'Private Sub SetDropDownListItem()
        '    commonFunction.SetDropDownLisToStdDataAktiv(ddlShiftJam, "SHIFT")
        '    commonFunction.SetDropDownLisToPenunjangMedisByUser(ddlPMedisUser, True, MyBase.LoggedOnUserID)
        'End Sub

        Private Sub chkAllCabang_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAllCabang.CheckedChanged
            If chkAllCabang.Checked = True Then
                ddlCabangAwal.Enabled = False
                ddlCabangAkhir.Enabled = False
            Else
                ddlCabangAwal.Enabled = True
                ddlCabangAkhir.Enabled = True
            End If
        End Sub
        Private Sub chksmuaInstansi_CheckedChanged(sender As Object, e As System.EventArgs) Handles chksmuaInstansi.CheckedChanged
            If chksmuaInstansi.Checked Then
                ddlJnsInstansi.Enabled = False
            Else
                ddlJnsInstansi.Enabled = True
            End If
        End Sub

        'Private Sub txtKodeSupplier_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtKodeSupplier.TextChanged
        '    Dim osupp As New BussinessRules.Supplier
        '    With osupp
        '        .kdsupplier = New SqlString(txtKodeSupplier.Text.Trim)
        '        If .SelectOne.Rows.Count > 0 Then
        '            lblNamaSupplier.Text = .namasupplier.Value.Trim
        '        Else
        '            lblNamaSupplier.Text = String.Empty
        '        End If
        '    End With
        '    osupp.Dispose()
        '    osupp = Nothing
        'End Sub

        'Private Sub txtKodeInstansi_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtKodeInstansi.TextChanged
        '    Dim oins As New BussinessRules.Instansi
        '    With oins
        '        .Kdinstansi = New SqlString(txtKodeInstansi.Text.Trim)
        '        If .SelectOne.Rows.Count > 0 Then
        '            lblNamaInstansi.Text = .Nminstansi.Value.Trim
        '        Else
        '            lblNamaInstansi.Text = String.Empty
        '        End If
        '    End With
        '    oins.Dispose()
        '    oins = Nothing
        'End Sub

        'Private Sub txtUser1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUser1.TextChanged
        '    Dim osupp As New BussinessRules.Security.User

        '    With osupp
        '        .UserID = New SqlString(txtUser1.Text.Trim)
        '        If .SelectOne.Rows.Count > 0 Then
        '            lblUser1.Text = .UserName.Value.Trim
        '        Else
        '            lblUser1.Text = String.Empty
        '        End If
        '    End With
        '    osupp.Dispose()
        '    osupp = Nothing
        'End Sub

        Private Sub setBulanTahun()
            Dim i As Integer
            Dim li As ListItem

            For i = 1 To 12
                li = New ListItem(MonthName(i), i.ToString.Trim)
                ddlBulan.Items.Add(li)
            Next

            For i = 1 To 50
                ddlTahun.Items.Add(((Year(Now) + 1) - i).ToString)
            Next

            For i = 1 To 50
                ddlthn.Items.Add(((Year(Now) + 1) - i).ToString)
            Next

            For i = 1 To 12
                li = New ListItem(MonthName(i), i.ToString.Trim)
                ddlBln1.Items.Add(li)
            Next

            For i = 1 To 12
                li = New ListItem(MonthName(i), i.ToString.Trim)
                ddlBln2.Items.Add(li)
            Next

            For i = 1 To 50
                ddlThn1.Items.Add(((Year(Now) + 1) - i).ToString)
            Next

            For i = 1 To 50
                ddlThn2.Items.Add(((Year(Now) + 1) - i).ToString)
            Next

        End Sub

        'Private Sub txtKdDokter_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtKddokter.TextChanged
        '    Dim odok As New BussinessRules.Medis
        '    With odok
        '        .Kode = New SqlString(TxtKddokter.Text.Trim)
        '        If .SelectOne.Rows.Count > 0 Then
        '            Lblnmdokter.Text = .Nama.Value.Trim
        '        Else
        '            Lblnmdokter.Text = String.Empty
        '        End If
        '    End With
        '    odok.Dispose()
        '    odok = Nothing
        'End Sub

        Private Sub InitializeComponent()

        End Sub

        Private Sub ddlPnjlnItem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPnjlnItem.SelectedIndexChanged
            If ddlPnjlnItem.SelectedItem.Value = "" Then
                pd12.Visible = False
                Pd35.Visible = False
                Pd33.Visible = False
            ElseIf ddlPnjlnItem.SelectedItem.Value = "RI_" Then
                txtruangrawatmulai.Text = "000"
                Txtruangrawatsampai.Text = "ZZZ"
                pd12.Visible = False
                Pd35.Visible = True
                Pd33.Visible = False
            ElseIf ddlPnjlnItem.SelectedItem.Value = "RJ_" Then
                txtPoliStart.Text = "000"
                txtPoliEnd.Text = "ZZZ"
                pd12.Visible = True
                Pd35.Visible = False
                Pd33.Visible = False
            ElseIf ddlPnjlnItem.SelectedItem.Value = "RD_" Then
                pd12.Visible = False
                Pd35.Visible = False
                Pd33.Visible = False
            ElseIf ddlPnjlnItem.SelectedItem.Value = "MD_" Then
                txtpenunjangmedismulai.Text = "000"
                Txtpenunjangmedissampai.Text = "ZZZ"
                pd12.Visible = False
                Pd35.Visible = False
                Pd33.Visible = True
            ElseIf ddlPnjlnItem.SelectedItem.Value = "FM_" Then
                pd12.Visible = False
                Pd35.Visible = False
                Pd33.Visible = False
            End If
        End Sub

        Private Sub ddlsmrirjrdmdmculb_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlsmrirjrdmdmculb.SelectedIndexChanged
            If ddlsmrirjrdmdmculb.SelectedItem.Value = "" Then
                txtkdlayanawal.Text = "000"
                txtkdlayanakhir.Text = "ZZZ"
                pd86.Visible = False
                pd25.Visible = True
            ElseIf ddlsmrirjrdmdmculb.SelectedItem.Value = "RI_" Then
                txtkdlayanawal.Text = "000"
                txtkdlayanakhir.Text = "ZZZ"
                pd86.Visible = False
                pd25.Visible = True
            ElseIf ddlsmrirjrdmdmculb.SelectedItem.Value = "RJ_" Then
                txtkdlayanawal.Text = "000"
                txtkdlayanakhir.Text = "ZZZ"
                pd86.Visible = False
                pd25.Visible = True
            ElseIf ddlsmrirjrdmdmculb.SelectedItem.Value = "RD_" Then
                txtkdlayanawal.Text = "000"
                txtkdlayanakhir.Text = "ZZZ"
                pd86.Visible = False
                pd25.Visible = True
            ElseIf ddlsmrirjrdmdmculb.SelectedItem.Value = "MD_" Then
                txtkdlayanawal.Text = "000"
                txtkdlayanakhir.Text = "ZZZ"
                pd86.Visible = False
                pd25.Visible = True
            ElseIf ddlsmrirjrdmdmculb.SelectedItem.Value = "LB_" Then
                txtkdtestawal.Text = "000"
                txtkdtestakhir.Text = "ZZZ"
                pd86.Visible = True
                pd25.Visible = False
            ElseIf ddlsmrirjrdmdmculb.SelectedItem.Value = "MCU_" Then
                pd86.Visible = False
                pd25.Visible = False
            End If
        End Sub

        'Private Sub ddlShiftJam_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlShiftJam.SelectedIndexChanged
        '    Dim KodeShiftPagi, KodeShiftSore, KodeShiftMalam As String
        '    Dim JamMulaiShiftPagi, JamMulaiShiftSore, JamMulaiShiftMalam As String

        '    KodeShiftPagi = Common.Methods.GetSettingParameter("shiftpagi", Common.Constants.ModuleID.SYSTEM_SETUP).Trim
        '    KodeShiftSore = Common.Methods.GetSettingParameter("shiftsore", Common.Constants.ModuleID.SYSTEM_SETUP).Trim
        '    KodeShiftMalam = Common.Methods.GetSettingParameter("shiftmalam", Common.Constants.ModuleID.SYSTEM_SETUP).Trim

        '    JamMulaiShiftPagi = Common.Methods.GetSettingParameter("shiftpagi", Common.Constants.ModuleID.OUT_PATIENT).Trim
        '    JamMulaiShiftSore = Common.Methods.GetSettingParameter("shiftsore", Common.Constants.ModuleID.OUT_PATIENT).Trim
        '    JamMulaiShiftMalam = Common.Methods.GetSettingParameter("shiftmalam", Common.Constants.ModuleID.OUT_PATIENT).Trim

        '    Select Case ddlShiftJam.SelectedValue.Trim
        '        Case KodeShiftPagi
        '            txtJamDari.Text = JamMulaiShiftPagi
        '            txtJamSampai.Text = Right(("0" + CStr(CDec(Left(JamMulaiShiftSore, 2)) - 1)), 2) + ":59"

        '        Case KodeShiftSore
        '            txtJamDari.Text = JamMulaiShiftSore
        '            txtJamSampai.Text = Right(("0" + CStr(CDec(Left(JamMulaiShiftMalam, 2)) - 1)), 2) + ":59"

        '        Case KodeShiftMalam
        '            txtJamDari.Text = JamMulaiShiftMalam
        '            txtJamSampai.Text = Right(("0" + CStr(CDec(Left(JamMulaiShiftPagi, 2)) - 1)), 2) + ":59"

        '        Case Else
        '            txtJamDari.Text = String.Empty
        '            txtJamSampai.Text = String.Empty
        '    End Select
        'End Sub

#Region " Toolbar "
        Private Sub setToolbarVisibleButton()
            With CSSToolbar
                .VisibleButton(CSSToolbarItem.tidNew) = False
                .VisibleButton(CSSToolbarItem.tidSave) = False
                .VisibleButton(CSSToolbarItem.tidDelete) = False
                .VisibleButton(CSSToolbarItem.tidApprove) = False
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidPrevious) = False
                .VisibleButton(CSSToolbarItem.tidNext) = False
            End With
        End Sub

        Private Sub CSSToolbar_CSSToolbarItemClick(ByVal sender As Object, ByVal e As CSSToolbarItem) Handles CSSToolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidPrint
                    Dim br As New Common.BussinessRules.MyReport
                    Dim url As New StringBuilder

                    If Session_rpt = Nothing Or Len(Session_rpt) = 0 Then
                        commonFunction.MsgBox(Me, "Anda belum memilih Laporan dari Daftar Laporan yang ada.")
                        Exit Sub
                    Else
                        br.ReportCode = Session_rpt.Trim
                    End If

                    '// Periode
                    If pd1.Visible Then
                        br.AddParameters(Format(calStart.selectedDate, "yyyyMMdd"))
                        br.AddParameters(Format(calEnd.selectedDate, "yyyyMMdd"))
                    End If

                    If pd3.Visible Then
                        br.AddParameters(txtdrMulai.Text.Trim)
                        br.AddParameters(txtdrSampai.Text.Trim)
                    End If

                    If pd12.Visible Then
                        br.AddParameters(txtPoliStart.Text.Trim)
                        br.AddParameters(txtPoliEnd.Text.Trim)
                    End If

                    If pd26.Visible Then
                        br.AddParameters(ddlmoduleS.SelectedValue)
                    End If

                    If Pd33.Visible Then
                        br.AddParameters(txtpenunjangmedismulai.Text.Trim)
                        br.AddParameters(Txtpenunjangmedissampai.Text.Trim)
                    End If

                    If pdPMedisUser.Visible Then
                        br.AddParameters(ddlPMedisUser.SelectedItem.Value.Trim)
                    End If

                    If pd44.Visible Then
                        br.AddParameters(Format(calTanggal.selectedDate, "yyyyMMdd"))
                    End If

                    If pd48.Visible Then
                        If rbReportTypeSSB.Items(1).Selected = True Then
                            br.AddParameters("Sudah")

                        ElseIf rbReportTypeSSB.Items(2).Selected = True Then
                            br.AddParameters("Belum")
                        Else
                            br.AddParameters("Semua")
                        End If
                    End If

                    If Pd40.Visible Then
                        br.AddParameters(txtSupplierAwal.Text.Trim)
                        br.AddParameters(txtSupplierAkhir.Text.Trim)
                    End If

                    If pd5.Visible Then
                        br.AddParameters(txtKodeInstansiMulai.Text.Trim)
                        br.AddParameters(txtKodeInstansiSampai.Text.Trim)
                    End If

                    If pd64.Visible Then
                        If chkAllDok.Checked Then
                            br.AddParameters("%")
                        Else
                            br.AddParameters(TxtKddokter.Text.Trim)
                        End If
                    End If

                    If pd190.Visible Then
                        br.AddParameters(ddlPiutangInstansi.SelectedItem.Value)
                    End If

                    If pd92.Visible Then
                        br.AddParameters(ddlsemuaasalpasien.SelectedValue)
                    End If
                    '// Jam
                    If pdJam.Visible Then
                        br.AddParameters(txtJamDari.Text.Trim)
                        br.AddParameters(txtJamSampai.Text.Trim)
                    End If

                    If Pd47.Visible Then
                        br.AddParameters(txtUser1.Text.Trim)
                    End If

                    If pdJnsInstansi.Visible Then
                        br.AddParameters(ddlJnsInstansi.SelectedItem.Value)
                        If chksmuaInstansi.Checked Then
                            br.AddParameters("1")
                        Else
                            br.AddParameters("0")
                        End If
                    End If

                    'br.AddParameters(MyBase.LoggedOnUserID.Trim)
                    If Session_useUser <> String.Empty Then
                        br.AddParameters(MyBase.LoggedOnUserID.Trim)
                    End If

                    If pdVoid.Visible Then
                        br.AddParameters(ddlVoid.SelectedItem.Value)
                    End If

                    If pdTagihan.Visible Then
                        br.AddParameters(txtTagihanMin.Text.Trim)
                    End If

                    br.GetReportDataByReportCode()
                    If br.ReportFormat = "XLS" Then
                        'br.ExportToExcel(br.generateReportDataTable, Response)
                    Else
                        Response.Write(br.UrlPrintPreview(Context.Request.Url.Host, "finance"))
                    End If

                    br.Dispose()
                    br = Nothing
            End Select
        End Sub
#End Region

#Region " Report Explorer "
        Private Sub GenerateReportExplorer()
            '// Get UserGroupID from User
            Dim strUserGroupID As String = String.Empty
            Dim oUser As New Common.BussinessRules.User

            'oUser.UserID = MyBase.LoggedOnUserID.Trim
            'If oUser.SelectOne.Rows.Count > 0 Then
            '    strUserGroupID = oUser.UserGroupID.Trim
            'Else
            '    strUserGroupID = String.Empty
            'End If
            'oUser.Dispose()
            'oUser = Nothing

            '// Get Report By UserGroupID from UserGroupReport
            Dim dt As DataTable
            Dim br As New Common.BussinessRules.Report
            br.UserGroupID = strUserGroupID.Trim
            br.AppID = "BAS"
            dt = br.SelectRootReportByUserGroupID
            br.Dispose()
            br = Nothing

            PopulateNodes(dt, trvReport.Nodes)
        End Sub

        Private Sub PopulateNodes(ByVal dt As DataTable, ByVal nodes As TreeNodeCollection)
            For Each dr As DataRow In dt.Rows
                Dim tn As New TreeNode()
                tn.Text = dr("ReportCaption").ToString()
                tn.Value = dr("ReportID").ToString()
                If Not (CInt(dr("ChildCount")) > 0) Then
                    tn.NavigateUrl = PageBase.UrlBase + "/secure/" + dr("Url").ToString()
                Else
                    tn.SelectAction = TreeNodeSelectAction.Expand
                End If
                nodes.Add(tn)

                'If node has child nodes, then enable on-demand populating
                tn.PopulateOnDemand = (CInt(dr("ChildCount")) > 0)
            Next
        End Sub

        Private Sub PopulateSubLevel(ByVal parentid As Integer, ByVal parentNode As TreeNode)
            Dim br As New Common.BussinessRules.Report
            br.ParentReportID = parentid
            br.UserGroupID = Me.LoggedOnProfileID
            br.AppID = "BAS"
            Dim dt As DataTable
            dt = br.SelectChildReportByUserGroupID
            br.Dispose()
            br = Nothing
            PopulateNodes(dt, parentNode.ChildNodes)
        End Sub

        Protected Sub trvReport_TreeNodePopulate(ByVal sender As Object, ByVal e As TreeNodeEventArgs) Handles trvReport.TreeNodePopulate
            PopulateSubLevel(CInt(e.Node.Value), e.Node)
        End Sub
#End Region

       
    End Class
End Namespace
