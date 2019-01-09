Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class NurseAssesment
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _PengkajianID As Integer
        Private _DepartmentID, _RegistrationNo, _RoomCode, _PenjaminBayarCode As String
        Private _AssessmentTypeSCode, _Triage As String
        Private _GCAsalInformasi, _GCAsalInformasiHubungan, _GCJenisAlergi, _GCKesadaran, _GCttvNadiDenyut, _GCNyeriMetode, _GCNyeriKualitas,
            _GCNyeriKarakteristik, _GCNyeriBerkurang, _GCNyeriBertambah, _GCAktivitasMobilisasi, _GCStatusPsikologi,
            _GCStatusMental, _GCStatusPernikahan, _GCStatusTempatTinggal, _GCPekerjaan, _GCPenjaminBayar,
            _GCStatusGizi, _GCSkorPerubahanBeratBadan, _GCPendidikanPasien, _GCBahasaPasien, _GCAgamaPasien,
            _GCCaraBelajarDisukai, _GCInformasiDiinginkan As String
        Private _AsalInformasiNama, _KeluhanUtama, _RiwayatKeluhanSaatIni, _ReaksiAlergi, _NyeriLokasi, _NyeriDurasi, _NyeriSkala,
            _NyeriBerkurangKeterangan, _NyeriBertambahKeterangan, _KategoriResikoJatuh, _StatusPsikologiKeterangan, _StatusMentalKeterangan,
            _HamilGravidKeterangan, _HamilParaKeterangan, _HamilAbortusKeterangan, _HambatanLainnya, _BahasaLainnya,
            _BahasaDaerah, _BudayaPasien, _PerluPenterjemah,
            _isInformasiDiagnosa, _isInformasiNyeri, _isInformasiDietNutrisi, _isInformasiAlatMedis, _isInformasiTerapi,
            _InformasiDiinginkanKeteragan,
            _ReferToHospitalName, _DeathTime As String
        Private _IsRiwayatAlergi, _IsNyeri, _IsResikoDekubitas, _IsHubunganKeluargaPasienBaik, _IsBeribadahTeratur,
            _IsTidakNafsuMakan, _IsPerluKonsultasiGizi, _IsHamil, _IsBersediaMenerimaInformasi, _IsHambatanEdukasi,
            _IsHambatanPendengaran, _IsHambatanPenglihatan, _IsHambatanKognitif, _IsHambatanFisik, _IsHambatanBudaya, _IsHambatanEmosi,
            _IsHambatanBahasa, _IsKIE, _IsObatPulang, _IsFotoRadiologi, _IsLaboratorium, _IsEKG, _IsKIEAPS, _IsTTDAPS, _IsDeath As Boolean
        Private _ttvTekananDarah, _ttvNadi, _ttvSuhu, _ttvPernafasan, _ttvBeratBadan, _ttvTinggiBadan, _ttvIndexMasaTubuh As Decimal
        Private _NyeriSkalaNum, _SkorNutrisi As Integer
        Private _DeathDate, _CreatedDate, _LastUpdatedDate As DateTime
        Private _CreatedBy, _LastUpdatedBy As String
        Private _TglDatang, _TglLayan, _TglDisposisi As Date
        Private _JamDatang, _JamLayan, _JamDisposisi, _keadaanKeluar, _caraKeluar As String

#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

#Region " Patient Resume "
#Region " Insert, Update "
        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spEMRNurseAssesmentInsert"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@DepartmentID", _DepartmentID)
                cmdToExecute.Parameters.AddWithValue("@RegistrationNo", _RegistrationNo)
                cmdToExecute.Parameters.AddWithValue("@RoomCode", _RoomCode)
                cmdToExecute.Parameters.AddWithValue("@PenjaminBayarCode", _PenjaminBayarCode)
                cmdToExecute.Parameters.AddWithValue("@Triage", _Triage)
                cmdToExecute.Parameters.AddWithValue("@AssessmentTypeSCode", _AssessmentTypeSCode)

                cmdToExecute.Parameters.AddWithValue("@GCAsalInformasi", _GCAsalInformasi)
                cmdToExecute.Parameters.AddWithValue("@GCAsalInformasiHubungan", _GCAsalInformasiHubungan)
                cmdToExecute.Parameters.AddWithValue("@GCJenisAlergi", _GCJenisAlergi)
                cmdToExecute.Parameters.AddWithValue("@GCKesadaran", _GCKesadaran)
                cmdToExecute.Parameters.AddWithValue("@GCttvNadiDenyut", _GCttvNadiDenyut)
                cmdToExecute.Parameters.AddWithValue("@GCNyeriMetode", _GCNyeriMetode)
                cmdToExecute.Parameters.AddWithValue("@GCNyeriKualitas", _GCNyeriKualitas)
                cmdToExecute.Parameters.AddWithValue("@GCNyeriKarakteristik", _GCNyeriKarakteristik)
                cmdToExecute.Parameters.AddWithValue("@GCNyeriBerkurang", _GCNyeriBerkurang)
                cmdToExecute.Parameters.AddWithValue("@GCNyeriBertambah", _GCNyeriBertambah)
                cmdToExecute.Parameters.AddWithValue("@GCAktivitasMobilisasi", _GCAktivitasMobilisasi)
                cmdToExecute.Parameters.AddWithValue("@GCStatusPsikologi", _GCStatusPsikologi)
                cmdToExecute.Parameters.AddWithValue("@GCStatusMental", _GCStatusMental)
                cmdToExecute.Parameters.AddWithValue("@GCStatusPernikahan", _GCStatusPernikahan)
                cmdToExecute.Parameters.AddWithValue("@GCStatusTempatTinggal", _GCStatusTempatTinggal)
                cmdToExecute.Parameters.AddWithValue("@GCPekerjaan", _GCPekerjaan)
                cmdToExecute.Parameters.AddWithValue("@GCPenjaminBayar", _GCPenjaminBayar)
                cmdToExecute.Parameters.AddWithValue("@GCStatusGizi", _GCStatusGizi)
                cmdToExecute.Parameters.AddWithValue("@GCSkorPerubahanBeratBadan", _GCSkorPerubahanBeratBadan)
                cmdToExecute.Parameters.AddWithValue("@GCPendidikanPasien", _GCPendidikanPasien)
                cmdToExecute.Parameters.AddWithValue("@GCBahasaPasien", _GCBahasaPasien)
                cmdToExecute.Parameters.AddWithValue("@GCAgamaPasien", _GCAgamaPasien)
                cmdToExecute.Parameters.AddWithValue("@GCCaraBelajarDisukai", _GCCaraBelajarDisukai)

                cmdToExecute.Parameters.AddWithValue("@isInformasiDiagnosa", _isInformasiDiagnosa)
                cmdToExecute.Parameters.AddWithValue("@isInformasiNyeri", _isInformasiNyeri)
                cmdToExecute.Parameters.AddWithValue("@isInformasiDietNutrisi", _isInformasiDietNutrisi)
                cmdToExecute.Parameters.AddWithValue("@isInformasiAlatMedis", _isInformasiAlatMedis)
                cmdToExecute.Parameters.AddWithValue("@isInformasiTerapi", _isInformasiTerapi)
                cmdToExecute.Parameters.AddWithValue("@GCInformasiDiinginkan", _GCInformasiDiinginkan)

                cmdToExecute.Parameters.AddWithValue("@AsalInformasiNama", _AsalInformasiNama)
                cmdToExecute.Parameters.AddWithValue("@KeluhanUtama", _KeluhanUtama)
                cmdToExecute.Parameters.AddWithValue("@RiwayatKeluhanSaatIni", _RiwayatKeluhanSaatIni)
                cmdToExecute.Parameters.AddWithValue("@ReaksiAlergi", _ReaksiAlergi)
                cmdToExecute.Parameters.AddWithValue("@NyeriLokasi", _NyeriLokasi)
                cmdToExecute.Parameters.AddWithValue("@NyeriDurasi", _NyeriDurasi)
                cmdToExecute.Parameters.AddWithValue("@NyeriSkala", _NyeriSkala)
                cmdToExecute.Parameters.AddWithValue("@NyeriBerkurangKeterangan", _NyeriBerkurangKeterangan)
                cmdToExecute.Parameters.AddWithValue("@NyeriBertambahKeterangan", _NyeriBertambahKeterangan)
                cmdToExecute.Parameters.AddWithValue("@KategoriResikoJatuh", _KategoriResikoJatuh)
                cmdToExecute.Parameters.AddWithValue("@StatusPsikologiKeterangan", _StatusPsikologiKeterangan)
                cmdToExecute.Parameters.AddWithValue("@StatusMentalKeterangan", _StatusMentalKeterangan)
                cmdToExecute.Parameters.AddWithValue("@HamilGravidKeterangan", _HamilGravidKeterangan)
                cmdToExecute.Parameters.AddWithValue("@HamilParaKeterangan", _HamilParaKeterangan)
                cmdToExecute.Parameters.AddWithValue("@HamilAbortusKeterangan", _HamilAbortusKeterangan)
                cmdToExecute.Parameters.AddWithValue("@HambatanLainnya", _HambatanLainnya)
                cmdToExecute.Parameters.AddWithValue("@BahasaLainnya", _BahasaLainnya)
                cmdToExecute.Parameters.AddWithValue("@BahasaDaerah", _BahasaDaerah)
                cmdToExecute.Parameters.AddWithValue("@BudayaPasien", _BudayaPasien)
                cmdToExecute.Parameters.AddWithValue("@PerluPenterjemah", _PerluPenterjemah)
                cmdToExecute.Parameters.AddWithValue("@InformasiDiinginkanKeteragan", _InformasiDiinginkanKeteragan)
                cmdToExecute.Parameters.AddWithValue("@ReferToHospitalName", _ReferToHospitalName)
                cmdToExecute.Parameters.AddWithValue("@DeathTime", _DeathTime)

                cmdToExecute.Parameters.AddWithValue("@IsRiwayatAlergi", _IsRiwayatAlergi)
                cmdToExecute.Parameters.AddWithValue("@IsNyeri", _IsNyeri)
                cmdToExecute.Parameters.AddWithValue("@IsResikoDekubitas", _IsResikoDekubitas)
                cmdToExecute.Parameters.AddWithValue("@IsHubunganKeluargaPasienBaik", _IsHubunganKeluargaPasienBaik)
                cmdToExecute.Parameters.AddWithValue("@IsBeribadahTeratur", _IsBeribadahTeratur)
                cmdToExecute.Parameters.AddWithValue("@IsTidakNafsuMakan", _IsTidakNafsuMakan)
                cmdToExecute.Parameters.AddWithValue("@IsPerluKonsultasiGizi", _IsPerluKonsultasiGizi)
                cmdToExecute.Parameters.AddWithValue("@IsHamil", _IsHamil)
                cmdToExecute.Parameters.AddWithValue("@IsBersediaMenerimaInformasi", _IsBersediaMenerimaInformasi)
                cmdToExecute.Parameters.AddWithValue("@IsHambatanEdukasi", _IsHambatanEdukasi)
                cmdToExecute.Parameters.AddWithValue("@IsHambatanPendengaran", _IsHambatanPendengaran)
                cmdToExecute.Parameters.AddWithValue("@IsHambatanPenglihatan", _IsHambatanPenglihatan)
                cmdToExecute.Parameters.AddWithValue("@IsHambatanKognitif", _IsHambatanKognitif)
                cmdToExecute.Parameters.AddWithValue("@IsHambatanFisik", _IsHambatanFisik)
                cmdToExecute.Parameters.AddWithValue("@IsHambatanBudaya", _IsHambatanBudaya)
                cmdToExecute.Parameters.AddWithValue("@IsHambatanEmosi", _IsHambatanEmosi)
                cmdToExecute.Parameters.AddWithValue("@IsHambatanBahasa", _IsHambatanBahasa)
                cmdToExecute.Parameters.AddWithValue("@IsKIE", _IsKIE)
                cmdToExecute.Parameters.AddWithValue("@IsObatPulang", _IsObatPulang)
                cmdToExecute.Parameters.AddWithValue("@IsFotoRadiologi", _IsFotoRadiologi)
                cmdToExecute.Parameters.AddWithValue("@IsLaboratorium", _IsLaboratorium)
                cmdToExecute.Parameters.AddWithValue("@IsEKG", _IsEKG)
                cmdToExecute.Parameters.AddWithValue("@IsKIEAPS", _IsKIEAPS)
                cmdToExecute.Parameters.AddWithValue("@IsTTDAPS", _IsTTDAPS)
                cmdToExecute.Parameters.AddWithValue("@IsDeath", _IsDeath)

                cmdToExecute.Parameters.AddWithValue("@ttvTekananDarah", _ttvTekananDarah)
                cmdToExecute.Parameters.AddWithValue("@ttvNadi", _ttvNadi)
                cmdToExecute.Parameters.AddWithValue("@ttvSuhu", _ttvSuhu)
                cmdToExecute.Parameters.AddWithValue("@ttvPernafasan", _ttvPernafasan)
                cmdToExecute.Parameters.AddWithValue("@ttvBeratBadan", _ttvBeratBadan)
                cmdToExecute.Parameters.AddWithValue("@ttvTinggiBadan", _ttvTinggiBadan)
                cmdToExecute.Parameters.AddWithValue("@ttvIndexMasaTubuh", _ttvIndexMasaTubuh)

                cmdToExecute.Parameters.AddWithValue("@NyeriSkalaNum", _NyeriSkalaNum)
                cmdToExecute.Parameters.AddWithValue("@SkorNutrisi", _SkorNutrisi)
                cmdToExecute.Parameters.AddWithValue("@CreatedBy", _CreatedBy)
                cmdToExecute.Parameters.AddWithValue("@LastUpdatedBy", _LastUpdatedBy)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                ExceptionManager.Publish(ex)
            Finally
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function

        Public Overrides Function Update() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spEMRNurseAssesmentUpdate"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@PengkajianID", _PengkajianID)
                cmdToExecute.Parameters.AddWithValue("@DepartmentID", _DepartmentID)
                cmdToExecute.Parameters.AddWithValue("@RegistrationNo", _RegistrationNo)
                cmdToExecute.Parameters.AddWithValue("@RoomCode", _RoomCode)
                cmdToExecute.Parameters.AddWithValue("@PenjaminBayarCode", _PenjaminBayarCode)

                cmdToExecute.Parameters.AddWithValue("@GCAsalInformasi", _GCAsalInformasi)
                cmdToExecute.Parameters.AddWithValue("@GCAsalInformasiHubungan", _GCAsalInformasiHubungan)
                cmdToExecute.Parameters.AddWithValue("@GCJenisAlergi", _GCJenisAlergi)
                cmdToExecute.Parameters.AddWithValue("@GCKesadaran", _GCKesadaran)
                cmdToExecute.Parameters.AddWithValue("@GCttvNadiDenyut", _GCttvNadiDenyut)
                cmdToExecute.Parameters.AddWithValue("@GCNyeriMetode", _GCNyeriMetode)
                cmdToExecute.Parameters.AddWithValue("@GCNyeriKualitas", _GCNyeriKualitas)
                cmdToExecute.Parameters.AddWithValue("@GCNyeriKarakteristik", _GCNyeriKarakteristik)
                cmdToExecute.Parameters.AddWithValue("@GCNyeriBerkurang", _GCNyeriBerkurang)
                cmdToExecute.Parameters.AddWithValue("@GCNyeriBertambah", _GCNyeriBertambah)
                cmdToExecute.Parameters.AddWithValue("@GCAktivitasMobilisasi", _GCAktivitasMobilisasi)
                cmdToExecute.Parameters.AddWithValue("@GCStatusPsikologi", _GCStatusPsikologi)
                cmdToExecute.Parameters.AddWithValue("@GCStatusMental", _GCStatusMental)
                cmdToExecute.Parameters.AddWithValue("@GCStatusPernikahan", _GCStatusPernikahan)
                cmdToExecute.Parameters.AddWithValue("@GCStatusTempatTinggal", _GCStatusTempatTinggal)
                cmdToExecute.Parameters.AddWithValue("@GCPekerjaan", _GCPekerjaan)
                cmdToExecute.Parameters.AddWithValue("@GCPenjaminBayar", _GCPenjaminBayar)
                cmdToExecute.Parameters.AddWithValue("@GCStatusGizi", _GCStatusGizi)
                cmdToExecute.Parameters.AddWithValue("@GCSkorPerubahanBeratBadan", _GCSkorPerubahanBeratBadan)
                cmdToExecute.Parameters.AddWithValue("@GCPendidikanPasien", _GCPendidikanPasien)
                cmdToExecute.Parameters.AddWithValue("@GCBahasaPasien", _GCBahasaPasien)
                cmdToExecute.Parameters.AddWithValue("@GCAgamaPasien", _GCAgamaPasien)
                cmdToExecute.Parameters.AddWithValue("@GCCaraBelajarDisukai", _GCCaraBelajarDisukai)
                cmdToExecute.Parameters.AddWithValue("@GCInformasiDiinginkan", _GCInformasiDiinginkan)

                cmdToExecute.Parameters.AddWithValue("@AsalInformasiNama", _AsalInformasiNama)
                cmdToExecute.Parameters.AddWithValue("@KeluhanUtama", _KeluhanUtama)
                cmdToExecute.Parameters.AddWithValue("@RiwayatKeluhanSaatIni", _RiwayatKeluhanSaatIni)
                cmdToExecute.Parameters.AddWithValue("@ReaksiAlergi", _ReaksiAlergi)
                cmdToExecute.Parameters.AddWithValue("@NyeriLokasi", _NyeriLokasi)
                cmdToExecute.Parameters.AddWithValue("@NyeriDurasi", _NyeriDurasi)
                cmdToExecute.Parameters.AddWithValue("@NyeriSkala", _NyeriSkala)
                cmdToExecute.Parameters.AddWithValue("@NyeriBerkurangKeterangan", _NyeriBerkurangKeterangan)
                cmdToExecute.Parameters.AddWithValue("@NyeriBertambahKeterangan", _NyeriBertambahKeterangan)
                cmdToExecute.Parameters.AddWithValue("@KategoriResikoJatuh", _KategoriResikoJatuh)
                cmdToExecute.Parameters.AddWithValue("@StatusPsikologiKeterangan", _StatusPsikologiKeterangan)
                cmdToExecute.Parameters.AddWithValue("@StatusMentalKeterangan", _StatusMentalKeterangan)
                cmdToExecute.Parameters.AddWithValue("@HamilGravidKeterangan", _HamilGravidKeterangan)
                cmdToExecute.Parameters.AddWithValue("@HamilParaKeterangan", _HamilParaKeterangan)
                cmdToExecute.Parameters.AddWithValue("@HamilAbortusKeterangan", _HamilAbortusKeterangan)
                cmdToExecute.Parameters.AddWithValue("@HambatanLainnya", _HambatanLainnya)
                cmdToExecute.Parameters.AddWithValue("@BahasaLainnya", _BahasaLainnya)
                cmdToExecute.Parameters.AddWithValue("@BahasaDaerah", _BahasaDaerah)
                cmdToExecute.Parameters.AddWithValue("@BudayaPasien", _BudayaPasien)
                cmdToExecute.Parameters.AddWithValue("@PerluPenterjemah", _PerluPenterjemah)

                cmdToExecute.Parameters.AddWithValue("@isInformasiDiagnosa", _isInformasiDiagnosa)
                cmdToExecute.Parameters.AddWithValue("@isInformasiNyeri", _isInformasiNyeri)
                cmdToExecute.Parameters.AddWithValue("@isInformasiDietNutrisi", _isInformasiDietNutrisi)
                cmdToExecute.Parameters.AddWithValue("@isInformasiAlatMedis", _isInformasiAlatMedis)
                cmdToExecute.Parameters.AddWithValue("@isInformasiTerapi", _isInformasiTerapi)
                cmdToExecute.Parameters.AddWithValue("@InformasiDiinginkanKeteragan", _InformasiDiinginkanKeteragan)

                cmdToExecute.Parameters.AddWithValue("@ReferToHospitalName", _ReferToHospitalName)
                cmdToExecute.Parameters.AddWithValue("@DeathTime", _DeathTime)

                cmdToExecute.Parameters.AddWithValue("@IsRiwayatAlergi", _IsRiwayatAlergi)
                cmdToExecute.Parameters.AddWithValue("@IsNyeri", _IsNyeri)
                cmdToExecute.Parameters.AddWithValue("@IsResikoDekubitas", _IsResikoDekubitas)
                cmdToExecute.Parameters.AddWithValue("@IsHubunganKeluargaPasienBaik", _IsHubunganKeluargaPasienBaik)
                cmdToExecute.Parameters.AddWithValue("@IsBeribadahTeratur", _IsBeribadahTeratur)
                cmdToExecute.Parameters.AddWithValue("@IsTidakNafsuMakan", _IsTidakNafsuMakan)
                cmdToExecute.Parameters.AddWithValue("@IsPerluKonsultasiGizi", _IsPerluKonsultasiGizi)
                cmdToExecute.Parameters.AddWithValue("@IsHamil", _IsHamil)
                cmdToExecute.Parameters.AddWithValue("@IsBersediaMenerimaInformasi", _IsBersediaMenerimaInformasi)
                cmdToExecute.Parameters.AddWithValue("@IsHambatanEdukasi", _IsHambatanEdukasi)
                cmdToExecute.Parameters.AddWithValue("@IsHambatanPendengaran", _IsHambatanPendengaran)
                cmdToExecute.Parameters.AddWithValue("@IsHambatanPenglihatan", _IsHambatanPenglihatan)
                cmdToExecute.Parameters.AddWithValue("@IsHambatanKognitif", _IsHambatanKognitif)
                cmdToExecute.Parameters.AddWithValue("@IsHambatanFisik", _IsHambatanFisik)
                cmdToExecute.Parameters.AddWithValue("@IsHambatanBudaya", _IsHambatanBudaya)
                cmdToExecute.Parameters.AddWithValue("@IsHambatanEmosi", _IsHambatanEmosi)
                cmdToExecute.Parameters.AddWithValue("@IsHambatanBahasa", _IsHambatanBahasa)
                cmdToExecute.Parameters.AddWithValue("@IsKIE", _IsKIE)
                cmdToExecute.Parameters.AddWithValue("@IsObatPulang", _IsObatPulang)
                cmdToExecute.Parameters.AddWithValue("@IsFotoRadiologi", _IsFotoRadiologi)
                cmdToExecute.Parameters.AddWithValue("@IsLaboratorium", _IsLaboratorium)
                cmdToExecute.Parameters.AddWithValue("@IsEKG", _IsEKG)
                cmdToExecute.Parameters.AddWithValue("@IsKIEAPS", _IsKIEAPS)
                cmdToExecute.Parameters.AddWithValue("@IsTTDAPS", _IsTTDAPS)
                cmdToExecute.Parameters.AddWithValue("@IsDeath", _IsDeath)

                cmdToExecute.Parameters.AddWithValue("@ttvTekananDarah", _ttvTekananDarah)
                cmdToExecute.Parameters.AddWithValue("@ttvNadi", _ttvNadi)
                cmdToExecute.Parameters.AddWithValue("@ttvSuhu", _ttvSuhu)
                cmdToExecute.Parameters.AddWithValue("@ttvPernafasan", _ttvPernafasan)
                cmdToExecute.Parameters.AddWithValue("@ttvBeratBadan", _ttvBeratBadan)
                cmdToExecute.Parameters.AddWithValue("@ttvTinggiBadan", _ttvTinggiBadan)
                cmdToExecute.Parameters.AddWithValue("@ttvIndexMasaTubuh", _ttvIndexMasaTubuh)

                cmdToExecute.Parameters.AddWithValue("@NyeriSkalaNum", _NyeriSkalaNum)
                cmdToExecute.Parameters.AddWithValue("@SkorNutrisi", _SkorNutrisi)
                'cmdToExecute.Parameters.AddWithValue("@DeathDate", _DeathDate)
                'cmdToExecute.Parameters.AddWithValue("@LastUpdatedDate", _LastUpdatedDate)
                cmdToExecute.Parameters.AddWithValue("@LastUpdatedBy", _LastUpdatedBy)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                ExceptionManager.Publish(ex)
            Finally
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function

        Public Function UpdateRegistration(ByVal keluar As Boolean) As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            If keluar Then
                cmdToExecute.CommandText = "spEMRNurseRegistrationUpdateDisposisi"
            Else
                cmdToExecute.CommandText = "spEMRNurseRegistrationUpdate"
            End If

            cmdToExecute.CommandType = CommandType.StoredProcedure
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@RegistrationNo", _RegistrationNo)
                cmdToExecute.Parameters.AddWithValue("@TglDatang", _TglDatang)
                cmdToExecute.Parameters.AddWithValue("@TglLayan", _TglLayan)
                cmdToExecute.Parameters.AddWithValue("@JamDatang", _JamDatang)
                cmdToExecute.Parameters.AddWithValue("@JamLayan", _JamLayan)
                cmdToExecute.Parameters.AddWithValue("@Triage", _Triage)
                If keluar Then
                    cmdToExecute.Parameters.AddWithValue("@tgldisposisi", _TglDisposisi)
                    cmdToExecute.Parameters.AddWithValue("@jamdisposisi", _JamDisposisi)
                    cmdToExecute.Parameters.AddWithValue("@kdnkeluar", _keadaanKeluar)
                    cmdToExecute.Parameters.AddWithValue("@carakeluar", _caraKeluar)
                End If


                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                ExceptionManager.Publish(ex)
            Finally
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function
#End Region

#Region " Select "
        Public Function GetNurseAssesmentByRegistrationNo() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spEMRGetNurseAssesmentByRegistrationNo"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("spEMRGetNurseAssesmentByRegistrationNo")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@RegistrationNo", _RegistrationNo)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try

            Return toReturn
        End Function

        Public Function GetNurseAssesmentByMRN(ByVal strMRN As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spEMRGetNurseAssesmentByMRN"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("spEMRGetNurseAssesmentByMRN")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@MRN", strMRN)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try

            Return toReturn
        End Function

        Public Function GetNurseAssesmentByID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spEMRGetNurseAssesmentByID"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("spEMRGetNurseAssesmentByID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@PengkajianID", _PengkajianID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _PengkajianID = CType(toReturn.Rows(0)("PengkajianID"), Integer)
                    _DepartmentID = CType(toReturn.Rows(0)("DepartmentID"), String)
                    _RegistrationNo = CType(toReturn.Rows(0)("RegistrationNo"), String)
                    _Triage = CType(toReturn.Rows(0)("triage"), String)
                    _JamDatang = CType(toReturn.Rows(0)("jamkejadian"), String)
                    _JamLayan = CType(toReturn.Rows(0)("jamlayan"), String)
                    _TglDatang = CType(toReturn.Rows(0)("tglkejadian"), Date)
                    _TglLayan = CType(toReturn.Rows(0)("tgllayan"), Date)
                    _AssessmentTypeSCode = CType(toReturn.Rows(0)("AssessmentTypeSCode"), String)
                    _RoomCode = CType(toReturn.Rows(0)("RoomCode"), String)
                    _PenjaminBayarCode = CType(toReturn.Rows(0)("PenjaminBayarCode"), String)
                    _GCAsalInformasi = CType(toReturn.Rows(0)("GCAsalInformasi"), String)
                    _GCAsalInformasiHubungan = CType(toReturn.Rows(0)("GCAsalInformasiHubungan"), String)
                    _GCJenisAlergi = CType(toReturn.Rows(0)("GCJenisAlergi"), String)
                    _GCKesadaran = CType(toReturn.Rows(0)("GCKesadaran"), String)
                    _GCttvNadiDenyut = CType(toReturn.Rows(0)("GCttvNadiDenyut"), String)
                    _GCNyeriMetode = CType(toReturn.Rows(0)("GCNyeriMetode"), String)
                    _GCNyeriKualitas = CType(toReturn.Rows(0)("GCNyeriKualitas"), String)
                    _GCNyeriKarakteristik = CType(toReturn.Rows(0)("GCNyeriKarakteristik"), String)
                    _GCNyeriBerkurang = CType(toReturn.Rows(0)("GCNyeriBerkurang"), String)
                    _GCNyeriBertambah = CType(toReturn.Rows(0)("GCNyeriBertambah"), String)
                    _GCAktivitasMobilisasi = CType(toReturn.Rows(0)("GCAktivitasMobilisasi"), String)
                    _GCStatusPsikologi = CType(toReturn.Rows(0)("GCStatusPsikologi"), String)
                    _GCStatusMental = CType(toReturn.Rows(0)("GCStatusMental"), String)
                    _GCStatusPernikahan = CType(toReturn.Rows(0)("GCStatusPernikahan"), String)
                    _GCStatusTempatTinggal = CType(toReturn.Rows(0)("GCStatusTempatTinggal"), String)
                    _GCPekerjaan = CType(toReturn.Rows(0)("GCPekerjaan"), String)
                    _GCPenjaminBayar = CType(toReturn.Rows(0)("GCPenjaminBayar"), String)
                    _GCStatusGizi = CType(toReturn.Rows(0)("GCStatusGizi"), String)
                    _GCSkorPerubahanBeratBadan = CType(toReturn.Rows(0)("GCSkorPerubahanBeratBadan"), String)
                    _GCPendidikanPasien = CType(toReturn.Rows(0)("GCPendidikanPasien"), String)
                    _GCBahasaPasien = CType(toReturn.Rows(0)("GCBahasaPasien"), String)
                    _GCAgamaPasien = CType(toReturn.Rows(0)("GCAgamaPasien"), String)
                    _GCCaraBelajarDisukai = CType(toReturn.Rows(0)("GCCaraBelajarDisukai"), String)
                    _isInformasiDiagnosa = CType(toReturn.Rows(0)("isInformasiDiagnosa"), Boolean)
                    _isInformasiNyeri = CType(toReturn.Rows(0)("isInformasiNyeri"), Boolean)
                    _isInformasiDietNutrisi = CType(toReturn.Rows(0)("isInformasiDietNutrisi"), Boolean)
                    _isInformasiAlatMedis = CType(toReturn.Rows(0)("isInformasiAlatMedis"), Boolean)
                    _isInformasiTerapi = CType(toReturn.Rows(0)("isInformasiTerapi"), Boolean)
                    _GCInformasiDiinginkan = CType(toReturn.Rows(0)("GCInformasiDiinginkan"), String)
                    _AsalInformasiNama = CType(toReturn.Rows(0)("AsalInformasiNama"), String)
                    _KeluhanUtama = CType(toReturn.Rows(0)("KeluhanUtama"), String)
                    _RiwayatKeluhanSaatIni = CType(toReturn.Rows(0)("RiwayatKeluhanSaatIni"), String)
                    _ReaksiAlergi = CType(toReturn.Rows(0)("ReaksiAlergi"), String)
                    _NyeriLokasi = CType(toReturn.Rows(0)("NyeriLokasi"), String)
                    _NyeriDurasi = CType(toReturn.Rows(0)("NyeriDurasi"), String)
                    _NyeriSkala = CType(toReturn.Rows(0)("NyeriSkala"), String)
                    _NyeriBerkurangKeterangan = CType(toReturn.Rows(0)("NyeriBerkurangKeterangan"), String)
                    _NyeriBertambahKeterangan = CType(toReturn.Rows(0)("NyeriBertambahKeterangan"), String)
                    _KategoriResikoJatuh = CType(toReturn.Rows(0)("KategoriResikoJatuh"), String)
                    _StatusPsikologiKeterangan = CType(toReturn.Rows(0)("StatusPsikologiKeterangan"), String)
                    _StatusMentalKeterangan = CType(toReturn.Rows(0)("StatusMentalKeterangan"), String)
                    _HamilGravidKeterangan = CType(toReturn.Rows(0)("HamilGravidKeterangan"), String)
                    _HamilParaKeterangan = CType(toReturn.Rows(0)("HamilParaKeterangan"), String)
                    _HamilAbortusKeterangan = CType(toReturn.Rows(0)("HamilAbortusKeterangan"), String)
                    _HambatanLainnya = CType(toReturn.Rows(0)("HambatanLainnya"), String)
                    _BahasaLainnya = CType(toReturn.Rows(0)("BahasaLainnya"), String)
                    _BahasaDaerah = CType(toReturn.Rows(0)("BahasaDaerah"), String)
                    _BudayaPasien = CType(toReturn.Rows(0)("BudayaPasien"), String)
                    _PerluPenterjemah = CType(toReturn.Rows(0)("PerluPenterjemah"), String)
                    _InformasiDiinginkanKeteragan = CType(toReturn.Rows(0)("InformasiDiinginkanKeteragan"), String)
                    _ReferToHospitalName = CType(toReturn.Rows(0)("ReferToHospitalName"), String)
                    _DeathTime = CType(toReturn.Rows(0)("DeathTime"), String)
                    _IsRiwayatAlergi = CType(toReturn.Rows(0)("IsRiwayatAlergi"), Boolean)
                    _IsNyeri = CType(toReturn.Rows(0)("IsNyeri"), Boolean)
                    _IsResikoDekubitas = CType(toReturn.Rows(0)("IsResikoDekubitas"), Boolean)
                    _IsHubunganKeluargaPasienBaik = CType(toReturn.Rows(0)("IsHubunganKeluargaPasienBaik"), Boolean)
                    _IsBeribadahTeratur = CType(toReturn.Rows(0)("IsBeribadahTeratur"), Boolean)
                    _IsTidakNafsuMakan = CType(toReturn.Rows(0)("IsTidakNafsuMakan"), Boolean)
                    _IsPerluKonsultasiGizi = CType(toReturn.Rows(0)("IsPerluKonsultasiGizi"), Boolean)
                    _IsHamil = CType(toReturn.Rows(0)("IsHamil"), Boolean)
                    _IsBersediaMenerimaInformasi = CType(toReturn.Rows(0)("IsBersediaMenerimaInformasi"), Boolean)
                    _IsHambatanEdukasi = CType(toReturn.Rows(0)("IsHambatanEdukasi"), Boolean)
                    _IsHambatanPendengaran = CType(toReturn.Rows(0)("IsHambatanPendengaran"), Boolean)
                    _IsHambatanPenglihatan = CType(toReturn.Rows(0)("IsHambatanPenglihatan"), Boolean)
                    _IsHambatanKognitif = CType(toReturn.Rows(0)("IsHambatanKognitif"), Boolean)
                    _IsHambatanFisik = CType(toReturn.Rows(0)("IsHambatanFisik"), Boolean)
                    _IsHambatanBudaya = CType(toReturn.Rows(0)("IsHambatanBudaya"), Boolean)
                    _IsHambatanEmosi = CType(toReturn.Rows(0)("IsHambatanEmosi"), Boolean)
                    _IsHambatanBahasa = CType(toReturn.Rows(0)("IsHambatanBahasa"), Boolean)
                    _IsKIE = CType(toReturn.Rows(0)("IsKIE"), Boolean)
                    _IsObatPulang = CType(toReturn.Rows(0)("IsObatPulang"), Boolean)
                    _IsFotoRadiologi = CType(toReturn.Rows(0)("IsFotoRadiologi"), Boolean)
                    _IsLaboratorium = CType(toReturn.Rows(0)("IsLaboratorium"), Boolean)
                    _IsEKG = CType(toReturn.Rows(0)("IsEKG"), Boolean)
                    _IsKIEAPS = CType(toReturn.Rows(0)("IsKIEAPS"), Boolean)
                    _IsTTDAPS = CType(toReturn.Rows(0)("IsTTDAPS"), Boolean)
                    _IsDeath = CType(toReturn.Rows(0)("IsDeath"), Boolean)
                    _ttvTekananDarah = CType(toReturn.Rows(0)("ttvTekananDarah"), Decimal)
                    _ttvNadi = CType(toReturn.Rows(0)("ttvNadi"), Decimal)
                    _ttvSuhu = CType(toReturn.Rows(0)("ttvSuhu"), Decimal)
                    _ttvPernafasan = CType(toReturn.Rows(0)("ttvPernafasan"), Decimal)
                    _ttvBeratBadan = CType(toReturn.Rows(0)("ttvBeratBadan"), Decimal)
                    _ttvTinggiBadan = CType(toReturn.Rows(0)("ttvTinggiBadan"), Decimal)
                    _ttvIndexMasaTubuh = CType(toReturn.Rows(0)("ttvIndexMasaTubuh"), Decimal)
                    _NyeriSkalaNum = CType(toReturn.Rows(0)("NyeriSkalaNum"), Integer)
                    _SkorNutrisi = CType(toReturn.Rows(0)("SkorNutrisi"), Integer)
                    _JamDisposisi = CType(toReturn.Rows(0)("jamkeluar"), String)
                    _TglDisposisi = CType(toReturn.Rows(0)("tglkeluar"), Date)
                    _keadaanKeluar = CType(toReturn.Rows(0)("kdkeadaankeluar"), String)
                    _caraKeluar = CType(toReturn.Rows(0)("kdcarakeluar"), String)
                End If
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try

            Return toReturn
        End Function

        Public Function GetNurseAssessmentFirstAssessmentByRegistrationNo() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spEMRGetNurseAssessmentFirstAssessmentByRegistrationNo"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("spEMRGetNurseAssessmentFirstAssessmentByRegistrationNo")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@RegistrationNo", _RegistrationNo)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try

            Return toReturn
        End Function
#End Region
#End Region

#Region " Class Property Declarations "
        Public Property [Triage]() As String
            Get
                Return _Triage
            End Get
            Set(value As String)
                _Triage = value
            End Set
        End Property
        Public Property [PengkajianID]() As Integer
            Get
                Return _PengkajianID
            End Get
            Set(ByVal Value As Integer)
                _PengkajianID = Value
            End Set
        End Property

        Public Property [DepartmentID]() As String
            Get
                Return _DepartmentID
            End Get
            Set(ByVal Value As String)
                _DepartmentID = Value
            End Set
        End Property

        Public Property [RegistrationNo]() As String
            Get
                Return _RegistrationNo
            End Get
            Set(ByVal Value As String)
                _RegistrationNo = Value
            End Set
        End Property

        Public Property [AssessmentTypeSCode]() As String
            Get
                Return _AssessmentTypeSCode
            End Get
            Set(ByVal Value As String)
                _AssessmentTypeSCode = Value
            End Set
        End Property

        Public Property [RoomCode]() As String
            Get
                Return _RoomCode
            End Get
            Set(ByVal Value As String)
                _RoomCode = Value
            End Set
        End Property

        Public Property [PenjaminBayarCode]() As String
            Get
                Return _PenjaminBayarCode
            End Get
            Set(ByVal Value As String)
                _PenjaminBayarCode = Value
            End Set
        End Property

        Public Property [GCAsalInformasi]() As String
            Get
                Return _GCAsalInformasi
            End Get
            Set(ByVal Value As String)
                _GCAsalInformasi = Value
            End Set
        End Property

        Public Property [GCAsalInformasiHubungan]() As String
            Get
                Return _GCAsalInformasiHubungan
            End Get
            Set(ByVal Value As String)
                _GCAsalInformasiHubungan = Value
            End Set
        End Property

        Public Property [GCJenisAlergi]() As String
            Get
                Return _GCJenisAlergi
            End Get
            Set(ByVal Value As String)
                _GCJenisAlergi = Value
            End Set
        End Property

        Public Property [GCKesadaran]() As String
            Get
                Return _GCKesadaran
            End Get
            Set(ByVal Value As String)
                _GCKesadaran = Value
            End Set
        End Property

        Public Property [GCttvNadiDenyut]() As String
            Get
                Return _GCttvNadiDenyut
            End Get
            Set(ByVal Value As String)
                _GCttvNadiDenyut = Value
            End Set
        End Property

        Public Property [GCNyeriMetode]() As String
            Get
                Return _GCNyeriMetode
            End Get
            Set(ByVal Value As String)
                _GCNyeriMetode = Value
            End Set
        End Property

        Public Property [GCNyeriKualitas]() As String
            Get
                Return _GCNyeriKualitas
            End Get
            Set(ByVal Value As String)
                _GCNyeriKualitas = Value
            End Set
        End Property

        Public Property [GCNyeriKarakteristik]() As String
            Get
                Return _GCNyeriKarakteristik
            End Get
            Set(ByVal Value As String)
                _GCNyeriKarakteristik = Value
            End Set
        End Property

        Public Property [GCNyeriBerkurang]() As String
            Get
                Return _GCNyeriBerkurang
            End Get
            Set(ByVal Value As String)
                _GCNyeriBerkurang = Value
            End Set
        End Property

        Public Property [GCNyeriBertambah]() As String
            Get
                Return _GCNyeriBertambah
            End Get
            Set(ByVal Value As String)
                _GCNyeriBertambah = Value
            End Set
        End Property

        Public Property [GCAktivitasMobilisasi]() As String
            Get
                Return _GCAktivitasMobilisasi
            End Get
            Set(ByVal Value As String)
                _GCAktivitasMobilisasi = Value
            End Set
        End Property

        Public Property [GCStatusPsikologi]() As String
            Get
                Return _GCStatusPsikologi
            End Get
            Set(ByVal Value As String)
                _GCStatusPsikologi = Value
            End Set
        End Property

        Public Property [GCStatusMental]() As String
            Get
                Return _GCStatusMental
            End Get
            Set(ByVal Value As String)
                _GCStatusMental = Value
            End Set
        End Property

        Public Property [GCStatusPernikahan]() As String
            Get
                Return _GCStatusPernikahan
            End Get
            Set(ByVal Value As String)
                _GCStatusPernikahan = Value
            End Set
        End Property

        Public Property [GCStatusTempatTinggal]() As String
            Get
                Return _GCStatusTempatTinggal
            End Get
            Set(ByVal Value As String)
                _GCStatusTempatTinggal = Value
            End Set
        End Property

        Public Property [GCPekerjaan]() As String
            Get
                Return _GCPekerjaan
            End Get
            Set(ByVal Value As String)
                _GCPekerjaan = Value
            End Set
        End Property

        Public Property [GCPenjaminBayar]() As String
            Get
                Return _GCPenjaminBayar
            End Get
            Set(ByVal Value As String)
                _GCPenjaminBayar = Value
            End Set
        End Property

        Public Property [GCStatusGizi]() As String
            Get
                Return _GCStatusGizi
            End Get
            Set(ByVal Value As String)
                _GCStatusGizi = Value
            End Set
        End Property

        Public Property [GCSkorPerubahanBeratBadan]() As String
            Get
                Return _GCSkorPerubahanBeratBadan
            End Get
            Set(ByVal Value As String)
                _GCSkorPerubahanBeratBadan = Value
            End Set
        End Property

        Public Property [GCPendidikanPasien]() As String
            Get
                Return _GCPendidikanPasien
            End Get
            Set(ByVal Value As String)
                _GCPendidikanPasien = Value
            End Set
        End Property

        Public Property [GCBahasaPasien]() As String
            Get
                Return _GCBahasaPasien
            End Get
            Set(ByVal Value As String)
                _GCBahasaPasien = Value
            End Set
        End Property

        Public Property [GCAgamaPasien]() As String
            Get
                Return _GCAgamaPasien
            End Get
            Set(ByVal Value As String)
                _GCAgamaPasien = Value
            End Set
        End Property

        Public Property [GCCaraBelajarDisukai]() As String
            Get
                Return _GCCaraBelajarDisukai
            End Get
            Set(ByVal Value As String)
                _GCCaraBelajarDisukai = Value
            End Set
        End Property

        Public Property [GCInformasiDiinginkan]() As String
            Get
                Return _GCInformasiDiinginkan
            End Get
            Set(ByVal Value As String)
                _GCInformasiDiinginkan = Value
            End Set
        End Property

        Public Property [AsalInformasiNama]() As String
            Get
                Return _AsalInformasiNama
            End Get
            Set(ByVal Value As String)
                _AsalInformasiNama = Value
            End Set
        End Property

        Public Property [KeluhanUtama]() As String
            Get
                Return _KeluhanUtama
            End Get
            Set(ByVal Value As String)
                _KeluhanUtama = Value
            End Set
        End Property

        Public Property [RiwayatKeluhanSaatIni]() As String
            Get
                Return _RiwayatKeluhanSaatIni
            End Get
            Set(ByVal Value As String)
                _RiwayatKeluhanSaatIni = Value
            End Set
        End Property

        Public Property [ReaksiAlergi]() As String
            Get
                Return _ReaksiAlergi
            End Get
            Set(ByVal Value As String)
                _ReaksiAlergi = Value
            End Set
        End Property

        Public Property [NyeriLokasi]() As String
            Get
                Return _NyeriLokasi
            End Get
            Set(ByVal Value As String)
                _NyeriLokasi = Value
            End Set
        End Property

        Public Property [NyeriDurasi]() As String
            Get
                Return _NyeriDurasi
            End Get
            Set(ByVal Value As String)
                _NyeriDurasi = Value
            End Set
        End Property

        Public Property [NyeriSkala]() As String
            Get
                Return _NyeriSkala
            End Get
            Set(ByVal Value As String)
                _NyeriSkala = Value
            End Set
        End Property

        Public Property [NyeriBerkurangKeterangan]() As String
            Get
                Return _NyeriBerkurangKeterangan
            End Get
            Set(ByVal Value As String)
                _NyeriBerkurangKeterangan = Value
            End Set
        End Property

        Public Property [NyeriBertambahKeterangan]() As String
            Get
                Return _NyeriBertambahKeterangan
            End Get
            Set(ByVal Value As String)
                _NyeriBertambahKeterangan = Value
            End Set
        End Property

        Public Property [KategoriResikoJatuh]() As String
            Get
                Return _KategoriResikoJatuh
            End Get
            Set(ByVal Value As String)
                _KategoriResikoJatuh = Value
            End Set
        End Property

        Public Property [StatusPsikologiKeterangan]() As String
            Get
                Return _StatusPsikologiKeterangan
            End Get
            Set(ByVal Value As String)
                _StatusPsikologiKeterangan = Value
            End Set
        End Property

        Public Property [StatusMentalKeterangan]() As String
            Get
                Return _StatusMentalKeterangan
            End Get
            Set(ByVal Value As String)
                _StatusMentalKeterangan = Value
            End Set
        End Property

        Public Property [HamilGravidKeterangan]() As String
            Get
                Return _HamilGravidKeterangan
            End Get
            Set(ByVal Value As String)
                _HamilGravidKeterangan = Value
            End Set
        End Property

        Public Property [HamilParaKeterangan]() As String
            Get
                Return _HamilParaKeterangan
            End Get
            Set(ByVal Value As String)
                _HamilParaKeterangan = Value
            End Set
        End Property

        Public Property [HamilAbortusKeterangan]() As String
            Get
                Return _HamilAbortusKeterangan
            End Get
            Set(ByVal Value As String)
                _HamilAbortusKeterangan = Value
            End Set
        End Property

        Public Property [HambatanLainnya]() As String
            Get
                Return _HambatanLainnya
            End Get
            Set(ByVal Value As String)
                _HambatanLainnya = Value
            End Set
        End Property

        Public Property [BahasaLainnya]() As String
            Get
                Return _BahasaLainnya
            End Get
            Set(ByVal Value As String)
                _BahasaLainnya = Value
            End Set
        End Property

        Public Property [BahasaDaerah]() As String
            Get
                Return _BahasaDaerah
            End Get
            Set(ByVal Value As String)
                _BahasaDaerah = Value
            End Set
        End Property

        Public Property [BudayaPasien]() As String
            Get
                Return _BudayaPasien
            End Get
            Set(ByVal Value As String)
                _BudayaPasien = Value
            End Set
        End Property

        Public Property [PerluPenterjemah]() As String
            Get
                Return _PerluPenterjemah
            End Get
            Set(ByVal Value As String)
                _PerluPenterjemah = Value
            End Set
        End Property

        Public Property [InformasiDiinginkanKeteragan]() As String
            Get
                Return _InformasiDiinginkanKeteragan
            End Get
            Set(ByVal Value As String)
                _InformasiDiinginkanKeteragan = Value
            End Set
        End Property

        Public Property [ReferToHospitalName]() As String
            Get
                Return _ReferToHospitalName
            End Get
            Set(ByVal Value As String)
                _ReferToHospitalName = Value
            End Set
        End Property

        Public Property [DeathTime]() As String
            Get
                Return _DeathTime
            End Get
            Set(ByVal Value As String)
                _DeathTime = Value
            End Set
        End Property

        Public Property [IsRiwayatAlergi]() As Boolean
            Get
                Return _IsRiwayatAlergi
            End Get
            Set(ByVal Value As Boolean)
                _IsRiwayatAlergi = Value
            End Set
        End Property

        Public Property [IsNyeri]() As Boolean
            Get
                Return _IsNyeri
            End Get
            Set(ByVal Value As Boolean)
                _IsNyeri = Value
            End Set
        End Property

        Public Property [IsResikoDekubitas]() As Boolean
            Get
                Return _IsResikoDekubitas
            End Get
            Set(ByVal Value As Boolean)
                _IsResikoDekubitas = Value
            End Set
        End Property

        Public Property [IsHubunganKeluargaPasienBaik]() As Boolean
            Get
                Return _IsHubunganKeluargaPasienBaik
            End Get
            Set(ByVal Value As Boolean)
                _IsHubunganKeluargaPasienBaik = Value
            End Set
        End Property

        Public Property [IsBeribadahTeratur]() As Boolean
            Get
                Return _IsBeribadahTeratur
            End Get
            Set(ByVal Value As Boolean)
                _IsBeribadahTeratur = Value
            End Set
        End Property

        Public Property [IsTidakNafsuMakan]() As Boolean
            Get
                Return _IsTidakNafsuMakan
            End Get
            Set(ByVal Value As Boolean)
                _IsTidakNafsuMakan = Value
            End Set
        End Property

        Public Property [IsPerluKonsultasiGizi]() As Boolean
            Get
                Return _IsPerluKonsultasiGizi
            End Get
            Set(ByVal Value As Boolean)
                _IsPerluKonsultasiGizi = Value
            End Set
        End Property

        Public Property [IsHamil]() As Boolean
            Get
                Return _IsHamil
            End Get
            Set(ByVal Value As Boolean)
                _IsHamil = Value
            End Set
        End Property

        Public Property [IsBersediaMenerimaInformasi]() As Boolean
            Get
                Return _IsBersediaMenerimaInformasi
            End Get
            Set(ByVal Value As Boolean)
                _IsBersediaMenerimaInformasi = Value
            End Set
        End Property

        Public Property [IsHambatanEdukasi]() As Boolean
            Get
                Return _IsHambatanEdukasi
            End Get
            Set(ByVal Value As Boolean)
                _IsHambatanEdukasi = Value
            End Set
        End Property

        Public Property [IsHambatanPendengaran]() As Boolean
            Get
                Return _IsHambatanPendengaran
            End Get
            Set(ByVal Value As Boolean)
                _IsHambatanPendengaran = Value
            End Set
        End Property

        Public Property [IsHambatanPenglihatan]() As Boolean
            Get
                Return _IsHambatanPenglihatan
            End Get
            Set(ByVal Value As Boolean)
                _IsHambatanPenglihatan = Value
            End Set
        End Property

        Public Property [IsHambatanKognitif]() As Boolean
            Get
                Return _IsHambatanKognitif
            End Get
            Set(ByVal Value As Boolean)
                _IsHambatanKognitif = Value
            End Set
        End Property

        Public Property [IsHambatanFisik]() As Boolean
            Get
                Return _IsHambatanFisik
            End Get
            Set(ByVal Value As Boolean)
                _IsHambatanFisik = Value
            End Set
        End Property

        Public Property [IsHambatanBudaya]() As Boolean
            Get
                Return _IsHambatanBudaya
            End Get
            Set(ByVal Value As Boolean)
                _IsHambatanBudaya = Value
            End Set
        End Property

        Public Property [IsHambatanEmosi]() As Boolean
            Get
                Return _IsHambatanEmosi
            End Get
            Set(ByVal Value As Boolean)
                _IsHambatanEmosi = Value
            End Set
        End Property

        Public Property [IsHambatanBahasa]() As Boolean
            Get
                Return _IsHambatanBahasa
            End Get
            Set(ByVal Value As Boolean)
                _IsHambatanBahasa = Value
            End Set
        End Property

        Public Property [IsKIE]() As Boolean
            Get
                Return _IsKIE
            End Get
            Set(ByVal Value As Boolean)
                _IsKIE = Value
            End Set
        End Property

        Public Property [IsObatPulang]() As Boolean
            Get
                Return _IsObatPulang
            End Get
            Set(ByVal Value As Boolean)
                _IsObatPulang = Value
            End Set
        End Property

        Public Property [IsFotoRadiologi]() As Boolean
            Get
                Return _IsFotoRadiologi
            End Get
            Set(ByVal Value As Boolean)
                _IsFotoRadiologi = Value
            End Set
        End Property

        Public Property [IsLaboratorium]() As Boolean
            Get
                Return _IsLaboratorium
            End Get
            Set(ByVal Value As Boolean)
                _IsLaboratorium = Value
            End Set
        End Property

        Public Property [IsEKG]() As Boolean
            Get
                Return _IsEKG
            End Get
            Set(ByVal Value As Boolean)
                _IsEKG = Value
            End Set
        End Property

        Public Property [IsKIEAPS]() As Boolean
            Get
                Return _IsKIEAPS
            End Get
            Set(ByVal Value As Boolean)
                _IsKIEAPS = Value
            End Set
        End Property

        Public Property [IsTTDAPS]() As Boolean
            Get
                Return _IsTTDAPS
            End Get
            Set(ByVal Value As Boolean)
                _IsTTDAPS = Value
            End Set
        End Property

        Public Property [IsDeath]() As Boolean
            Get
                Return _IsDeath
            End Get
            Set(ByVal Value As Boolean)
                _IsDeath = Value
            End Set
        End Property

        Public Property [ttvTekananDarah]() As Decimal
            Get
                Return _ttvTekananDarah
            End Get
            Set(ByVal Value As Decimal)
                _ttvTekananDarah = Value
            End Set
        End Property

        Public Property [ttvNadi]() As Decimal
            Get
                Return _ttvNadi
            End Get
            Set(ByVal Value As Decimal)
                _ttvNadi = Value
            End Set
        End Property

        Public Property [ttvSuhu]() As Decimal
            Get
                Return _ttvSuhu
            End Get
            Set(ByVal Value As Decimal)
                _ttvSuhu = Value
            End Set
        End Property

        Public Property [ttvPernafasan]() As Decimal
            Get
                Return _ttvPernafasan
            End Get
            Set(ByVal Value As Decimal)
                _ttvPernafasan = Value
            End Set
        End Property

        Public Property [ttvBeratBadan]() As Decimal
            Get
                Return _ttvBeratBadan
            End Get
            Set(ByVal Value As Decimal)
                _ttvBeratBadan = Value
            End Set
        End Property

        Public Property [ttvTinggiBadan]() As Decimal
            Get
                Return _ttvTinggiBadan
            End Get
            Set(ByVal Value As Decimal)
                _ttvTinggiBadan = Value
            End Set
        End Property

        Public Property [ttvIndexMasaTubuh]() As Decimal
            Get
                Return _ttvIndexMasaTubuh
            End Get
            Set(ByVal Value As Decimal)
                _ttvIndexMasaTubuh = Value
            End Set
        End Property

        Public Property [NyeriSkalaNum]() As Integer
            Get
                Return _NyeriSkalaNum
            End Get
            Set(ByVal Value As Integer)
                _NyeriSkalaNum = Value
            End Set
        End Property

        Public Property [SkorNutrisi]() As Integer
            Get
                Return _SkorNutrisi
            End Get
            Set(ByVal Value As Integer)
                _SkorNutrisi = Value
            End Set
        End Property

        Public Property [DeathDate]() As DateTime
            Get
                Return _DeathDate
            End Get
            Set(ByVal Value As DateTime)
                _DeathDate = Value
            End Set
        End Property

        Public Property [CreatedDate]() As DateTime
            Get
                Return _CreatedDate
            End Get
            Set(ByVal Value As DateTime)
                _CreatedDate = Value
            End Set
        End Property

        Public Property [LastUpdatedDate]() As DateTime
            Get
                Return _LastUpdatedDate
            End Get
            Set(ByVal Value As DateTime)
                _LastUpdatedDate = Value
            End Set
        End Property

        Public Property [CreatedBy]() As String
            Get
                Return _CreatedBy
            End Get
            Set(ByVal Value As String)
                _CreatedBy = Value
            End Set
        End Property

        Public Property [LastUpdatedBy]() As String
            Get
                Return _LastUpdatedBy
            End Get
            Set(ByVal Value As String)
                _LastUpdatedBy = Value
            End Set
        End Property
        Public Property [TglDatang]() As Date
            Get
                Return _TglDatang
            End Get
            Set(value As Date)
                _TglDatang = value
            End Set
        End Property
        Public Property [TglLayan]() As Date
            Get
                Return _TglLayan
            End Get
            Set(value As Date)
                _TglLayan = value
            End Set
        End Property
        Public Property [JamDatang]() As String
            Get
                Return _JamDatang
            End Get
            Set(value As String)
                _JamDatang = value
            End Set
        End Property
        Public Property [JamLayan]() As String
            Get
                Return _JamLayan
            End Get
            Set(value As String)
                _JamLayan = value
            End Set
        End Property
        Public Property [isInformasiDiagnosa]() As Boolean
            Get
                Return _isInformasiDiagnosa
            End Get
            Set(ByVal Value As Boolean)
                _isInformasiDiagnosa = Value
            End Set
        End Property
        Public Property [isInformasiNyeri]() As Boolean
            Get
                Return _isInformasiNyeri
            End Get
            Set(ByVal Value As Boolean)
                _isInformasiNyeri = Value
            End Set
        End Property
        Public Property [isInformasiDietNutrisi]() As Boolean
            Get
                Return _isInformasiDietNutrisi
            End Get
            Set(ByVal Value As Boolean)
                _isInformasiDietNutrisi = Value
            End Set
        End Property
        Public Property [isInformasiAlatMedis]() As Boolean
            Get
                Return _isInformasiAlatMedis
            End Get
            Set(ByVal Value As Boolean)
                _isInformasiAlatMedis = Value
            End Set
        End Property
        Public Property [isInformasiTerapi]() As Boolean
            Get
                Return _isInformasiTerapi
            End Get
            Set(ByVal Value As Boolean)
                _isInformasiTerapi = Value
            End Set
        End Property
        Public Property [TglDisposisi]() As Date
            Get
                Return _TglDisposisi
            End Get
            Set(value As Date)
                _TglDisposisi = value
            End Set
        End Property
        Public Property [JamDisposisi]() As String
            Get
                Return _JamDisposisi
            End Get
            Set(value As String)
                _JamDisposisi = value
            End Set
        End Property
        Public Property [KeadaanKeluar]() As String
            Get
                Return _keadaanKeluar
            End Get
            Set(value As String)
                _keadaanKeluar = value
            End Set
        End Property
        Public Property [CaraKeluar]() As String
            Get
                Return _caraKeluar
            End Get
            Set(value As String)
                _caraKeluar = value
            End Set
        End Property
#End Region

    End Class
End Namespace
