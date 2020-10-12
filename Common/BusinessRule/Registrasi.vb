Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common
'Imports QIS.Medinfras.Common

Namespace QIS.Common.BussinessRules
    Public Class Registrasi
        Inherits BRInteractionBase

#Region "Class Member Declarations"

        'SqlString
        Private _noreg, _norm, _jamdatang, _jamlayan, _jamkejadian, _kddokter, _kdpengirim, _
                _nopengirim, _kdmasukrs, _tpkejadian, _rwkejadian, _jnkasus, _kdkdndatang, _kdalasan, _
                _kddetail, _kddeskripsi, _Pgtsbl, _Anamnesa, _jnpasien, _triage, _kdjmbayar, _kdperusahaan, _ketinstansi, _
                _cvl, _mata, _bicara, _gerak, _jlnnapas, _grknapas, _pernapasan, _bunyinapaskiri, _
                _bunyinapaskanan, _kualitasnadi, _kulit, _bunyijantung, _dpupilkiri, _dpupilkanan, _
                _rpupilkiri, _rpupilkanan, _kpllhr, _toraks, _tdkterapi, _abdomen, _ekstremitas, _
                _ketdiagnosa, _kddiagnosa, _kdanestesi, _jamdisposisi, _kdnkeluar, _crkeluar, _dokterrawat, _
                _usrupdater, _usrinsert, _usrbatal, _tdklanjut, _NoBayarPendaftaran, _nomember, _
                _kdplafon, _usrbiaya, _kddtd, _kdIcd, _kdIcdkc, _catatan, _shift, _reviewOfSystemText, _App As SqlString

        Private _bscMata, _bscBicara, _bscGerak As SqlString
        Private _ruang, _kdRuang, _kelas, _kdkelas As SqlString
        Private _txtJnsOperasi, _txtJamMknAkhir As SqlString
        Private _CatatanPerkembangan, _PrnthSdhnDT, _jenisTarif As SqlString

        'SqlDatetime
        Private _tgldatang, _tgllayan, _tglkejadian, _tgldisposisi, _tglupdater, _tglinsert, _tgltutup, _
                _tglbatal, _tglbiaya, _tglshift, _tgllahir As SqlDateTime

        'SqlDecimal
        Private _nadi, _berat, _suhu, _suhuaxilla, _suhurectal, _suhuAuritula, _
                _systole, _dyastole, _jmlnapas, _voldarah As SqlDecimal

        Private _plafon, _sisaplafon, _tinstansi, _tpasien As SqlMoney

        Private _umurtahun, _umurbulan, _umurhari As SqlInt16

        Private _Tinggi As SqlDecimal

        'sqlmoney
        Private _diskonTagihan As SqlMoney

        'SqlBoolean
        Private _retraksidada, _chkdarah, _tutup, _batal, _biayapendaftaran, _
                _kunjunganbaru, _kartu, _fplafonperhari As SqlBoolean

        Private _chkAsma, _chkDiabetes, _chkHipertensi, _chkSakitJantung, _chkStroke, _
                _chkSakitGinjal, _chkSakitLever, _chkRiwayatOperasi, _
                _chkGigiPalsu, _chkProtesis, _chkLensaKontak As SqlBoolean

        Private _chkAlergi, _chkPerintahSederhana, _chkBernapas As SqlBoolean

        Private _IsServiced As SqlBoolean

        'add
        Private _noregri, _nott As SqlString

        Private _GDS, _Spo2, _IsiKuku, _RR As SqlString
        Private _KdKeadaanUmum As SqlString

        Private _NmDokter, _Nama, _Marga, _kdseks As SqlString
        Private _pasienbaru, _IsExamined As SqlBoolean

        Private _kdterminal, _UserExamination As SqlString
        Private _LastExaminationDate As DateTime

#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

#Region "Insert"

        'Public Overrides Function Insert() As Boolean
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    cmdToExecute.CommandText = "dbo.[sprd_registrasi_Insert]"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure


        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noreg))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@norm", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _norm))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tgldatang", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgldatang))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@jamdatang", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jamdatang))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@shift", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _shift))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tglshift", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tglshift))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tgllayan", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgllayan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@jamlayan", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jamlayan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tglkejadian", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tglkejadian))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@jamkejadian", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jamkejadian))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kddokter", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kddokter))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdpengirim", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdpengirim))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nopengirim", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nopengirim))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdmasukrs", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdmasukrs))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tpkejadian", SqlDbType.NVarChar, 75, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _tpkejadian))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@rwkejadian", SqlDbType.NVarChar, 200, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _rwkejadian))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@jnkasus", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jnkasus))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdkdndatang", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdkdndatang))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdalasan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdalasan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kddetail", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kddetail))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kddeskripsi", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kddeskripsi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Pgtsbl", SqlDbType.NVarChar, 200, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _Pgtsbl))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Anamnesa", SqlDbType.Text, _Anamnesa.Value.Length, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _Anamnesa))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@jnpasien", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jnpasien))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@triage", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _triage))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdjmbayar", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdjmbayar))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdperusahaan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdperusahaan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdplafon", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdplafon))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@plafon", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _plafon))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@sisaplafon", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _sisaplafon))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@fplafonperhari", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _fplafonperhari))
        '        cmdToExecute.Parameters.AddWithValue("@nadi", _nadi)
        '        cmdToExecute.Parameters.Add(New SqlParameter("@berat", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 8, 2, "", DataRowVersion.Proposed, _berat))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@suhu", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 8, 2, "", DataRowVersion.Proposed, _suhu))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@suhuaxilla", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 8, 2, "", DataRowVersion.Proposed, _suhuaxilla))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@suhurectal", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 8, 2, "", DataRowVersion.Proposed, _suhurectal))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@suhuauritula", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 8, 2, "", DataRowVersion.Proposed, _suhuAuritula))
        '        cmdToExecute.Parameters.AddWithValue("@systole", _systole)
        '        cmdToExecute.Parameters.AddWithValue("@dyastole", _dyastole)
        '        cmdToExecute.Parameters.Add(New SqlParameter("@cvl", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _cvl))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@mata", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _mata))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@bicara", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _bicara))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@gerak", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _gerak))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@bscmata", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _bscMata))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@bscbicara", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _bscBicara))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@bscgerak", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _bscGerak))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@jmlnapas", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 8, 2, "", DataRowVersion.Proposed, _jmlnapas))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@jlnnapas", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jlnnapas))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@grknapas", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _grknapas))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@pernapasan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _pernapasan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@bunyinapaskiri", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _bunyinapaskiri))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@bunyinapaskanan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _bunyinapaskanan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@retraksidada", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _retraksidada))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kualitasnadi", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kualitasnadi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kulit", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kulit))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@bunyijantung", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _bunyijantung))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@voldarah", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 8, 2, "", DataRowVersion.Proposed, _voldarah))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@chkdarah", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _chkdarah))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@dpupilkiri", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _dpupilkiri))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@dpupilkanan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _dpupilkanan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@rpupilkiri", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _rpupilkiri))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@rpupilkanan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _rpupilkanan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kpllhr", SqlDbType.Text, _kpllhr.Value.Length, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kpllhr))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@toraks", SqlDbType.Text, _toraks.Value.Length, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _toraks))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tdkterapi", SqlDbType.Text, _tdkterapi.Value.Length, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _tdkterapi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@abdomen", SqlDbType.Text, _abdomen.Value.Length, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _abdomen))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@ekstremitas", SqlDbType.Text, _ekstremitas.Value.Length, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _ekstremitas))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@ketdiagnosa", SqlDbType.Text, _ketdiagnosa.Value.Length, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _ketdiagnosa))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kddiagnosa", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kddiagnosa))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdanestesi", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdanestesi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tgldisposisi", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgldisposisi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@jamdisposisi", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jamdisposisi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdnkeluar", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdnkeluar))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@crkeluar", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _crkeluar))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tdklanjut", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _tdklanjut))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@dokterrawat", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _dokterrawat))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@usrupdater", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _usrupdater))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tglupdater", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tglupdater))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@usrinsert", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _usrinsert))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tglinsert", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tglinsert))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@umurtahun", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _umurtahun))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@umurbulan", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _umurbulan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@umurhari", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _umurhari))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@catatan", SqlDbType.Text, _catatan.Value.Length, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _catatan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kunjunganbaru", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kunjunganbaru))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kartu", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kartu))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nomember", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nomember))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@ketinstansi", SqlDbType.NVarChar, 100, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _ketinstansi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Asma", _chkAsma))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Diabetes", _chkDiabetes))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Hipertensi", _chkHipertensi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@SakitJantung", _chkSakitJantung))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Stroke", _chkStroke))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@SakitGinjal", _chkSakitGinjal))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@SakitLever", _chkSakitLever))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@RiwayatOperasi", _chkRiwayatOperasi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@GigiPalsu", _chkGigiPalsu))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Protesis", _chkProtesis))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@LensaKontak", _chkLensaKontak))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@JnsOperasi", _txtJnsOperasi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@JamMknAkhir", _txtJamMknAkhir))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Tinggi", _Tinggi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Alergi", _chkAlergi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@PerintahSederhana", _chkPerintahSederhana))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Bernapas", _chkBernapas))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@GDS", _GDS))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Spo2", _Spo2))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@IsiKuku", _IsiKuku))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@CatatanPerkembangan", _CatatanPerkembangan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@PrnthSdhnDT", _PrnthSdhnDT))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@RR", _RR))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@KdKeadaanUmum", _KdKeadaanUmum))

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        cmdToExecute.ExecuteNonQuery()

        '        Return True
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '    End Try
        'End Function

        'Public Function InsertDiagnosa() As Boolean
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    cmdToExecute.CommandText = "dbo.[sprd_registrasi_InsertDiagnosa]"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noreg))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdDtd", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kddtd))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdIcd", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdIcd))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdIcdkc", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdIcdkc))
        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        cmdToExecute.ExecuteNonQuery()
        '        Return True
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '    End Try
        'End Function

#End Region

#Region "Update"
        'Public Overrides Function Update() As Boolean
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_registrasi_Update"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noreg))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@norm", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _norm))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@tgldatang", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgldatang))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@jamdatang", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jamdatang))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@shift", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _shift))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tglshift", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tglshift))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tgllayan", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgllayan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@jamlayan", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jamlayan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tglkejadian", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tglkejadian))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@jamkejadian", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jamkejadian))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kddokter", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kddokter))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdpengirim", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdpengirim))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nopengirim", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nopengirim))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdmasukrs", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdmasukrs))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tpkejadian", SqlDbType.NVarChar, 75, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _tpkejadian))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@rwkejadian", SqlDbType.NVarChar, 200, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _rwkejadian))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@jnkasus", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jnkasus))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdkdndatang", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdkdndatang))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdalasan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdalasan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kddetail", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kddetail))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kddeskripsi", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kddeskripsi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Pgtsbl", SqlDbType.NVarChar, 200, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _Pgtsbl))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@ReviewOfSystemText", SqlDbType.NVarChar, 4000, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _reviewOfSystemText))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Anamnesa", SqlDbType.Text, _Anamnesa.Value.Length, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _Anamnesa))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@jnpasien", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jnpasien))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@triage", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _triage))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdjmbayar", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdjmbayar))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdperusahaan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdperusahaan))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@kdplafon", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdplafon))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@plafon", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _plafon))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@sisaplafon", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _sisaplafon))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@fplafonperhari", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _fplafonperhari))
        '        cmdToExecute.Parameters.AddWithValue("@nadi", _nadi)
        '        cmdToExecute.Parameters.Add(New SqlParameter("@berat", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 8, 2, "", DataRowVersion.Proposed, _berat))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@suhu", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 8, 2, "", DataRowVersion.Proposed, _suhu))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@suhuaxilla", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 8, 2, "", DataRowVersion.Proposed, _suhuaxilla))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@suhurectal", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 8, 2, "", DataRowVersion.Proposed, _suhurectal))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@suhuauritula", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 8, 2, "", DataRowVersion.Proposed, _suhuAuritula))
        '        cmdToExecute.Parameters.AddWithValue("@systole", _systole)
        '        cmdToExecute.Parameters.AddWithValue("@dyastole", _dyastole)
        '        cmdToExecute.Parameters.Add(New SqlParameter("@cvl", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _cvl))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@mata", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _mata))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@bicara", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _bicara))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@gerak", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _gerak))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@bscmata", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _bscMata))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@bscbicara", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _bscBicara))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@bscgerak", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _bscGerak))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@jmlnapas", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 8, 2, "", DataRowVersion.Proposed, _jmlnapas))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@jlnnapas", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jlnnapas))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@grknapas", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _grknapas))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@pernapasan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _pernapasan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@bunyinapaskiri", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _bunyinapaskiri))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@bunyinapaskanan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _bunyinapaskanan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@retraksidada", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _retraksidada))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kualitasnadi", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kualitasnadi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kulit", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kulit))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@bunyijantung", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _bunyijantung))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@voldarah", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 8, 2, "", DataRowVersion.Proposed, _voldarah))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@chkdarah", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _chkdarah))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@dpupilkiri", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _dpupilkiri))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@dpupilkanan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _dpupilkanan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@rpupilkiri", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _rpupilkiri))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@rpupilkanan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _rpupilkanan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kpllhr", SqlDbType.Text, _kpllhr.Value.Length, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kpllhr))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@toraks", SqlDbType.Text, _toraks.Value.Length, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _toraks))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tdkterapi", SqlDbType.Text, _tdkterapi.Value.Length, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _tdkterapi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@abdomen", SqlDbType.Text, _abdomen.Value.Length, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _abdomen))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@ekstremitas", SqlDbType.Text, _ekstremitas.Value.Length, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _ekstremitas))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@ketdiagnosa", SqlDbType.Text, _ketdiagnosa.Value.Length, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _ketdiagnosa))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kddiagnosa", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kddiagnosa))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdanestesi", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdanestesi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tgldisposisi", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgldisposisi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@jamdisposisi", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jamdisposisi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdnkeluar", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdnkeluar))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@crkeluar", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _crkeluar))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tdklanjut", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _tdklanjut))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@dokterrawat", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _dokterrawat))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@usrupdater", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _usrupdater))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tglupdater", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tglupdater))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@umurtahun", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _umurtahun))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@umurbulan", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _umurbulan))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@umurhari", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _umurhari))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@catatan", SqlDbType.Text, _catatan.Value.Length, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _catatan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nomember", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nomember))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@ketinstansi", SqlDbType.NVarChar, 100, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _ketinstansi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Asma", _chkAsma))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Diabetes", _chkDiabetes))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Hipertensi", _chkHipertensi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@SakitJantung", _chkSakitJantung))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Stroke", _chkStroke))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@SakitGinjal", _chkSakitGinjal))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@SakitLever", _chkSakitLever))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@RiwayatOperasi", _chkRiwayatOperasi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@GigiPalsu", _chkGigiPalsu))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Protesis", _chkProtesis))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@LensaKontak", _chkLensaKontak))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@JnsOperasi", _txtJnsOperasi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@JamMknAkhir", _txtJamMknAkhir))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Tinggi", _Tinggi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Alergi", _chkAlergi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@PerintahSederhana", _chkPerintahSederhana))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Bernapas", _chkBernapas))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@GDS", _GDS))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Spo2", _Spo2))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@IsiKuku", _IsiKuku))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@CatatanPerkembangan", _CatatanPerkembangan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@PrnthSdhnDT", _PrnthSdhnDT))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@RR", _RR))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@KdKeadaanUmum", _KdKeadaanUmum))

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        cmdToExecute.ExecuteNonQuery()

        '        Return True
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '    End Try
        'End Function

        'Public Function UpdateKetPasien() As Boolean
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_registrasi_UpdateKetPasien"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noreg))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@norm", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _norm))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@tgldatang", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgldatang))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@jamdatang", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jamdatang))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tgllayan", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgllayan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@jamlayan", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jamlayan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tglkejadian", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tglkejadian))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@jamkejadian", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jamkejadian))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@kddokter", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kddokter))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@kdpengirim", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdpengirim))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@nopengirim", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nopengirim))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdmasukrs", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdmasukrs))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tpkejadian", SqlDbType.NVarChar, 75, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _tpkejadian))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@rwkejadian", SqlDbType.NVarChar, 200, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _rwkejadian))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@jnkasus", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jnkasus))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdkdndatang", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdkdndatang))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdalasan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdalasan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kddetail", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kddetail))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kddeskripsi", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kddeskripsi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Pgtsbl", SqlDbType.NVarChar, 200, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _Pgtsbl))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Anamnesa", SqlDbType.Text, _Anamnesa.Value.Length, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _Anamnesa))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@jnpasien", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jnpasien))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@triage", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _triage))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@kdjmbayar", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdjmbayar))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@kdperusahaan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdperusahaan))
        '        cmdToExecute.Parameters.AddWithValue("@nadi", _nadi)
        '        cmdToExecute.Parameters.Add(New SqlParameter("@berat", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 8, 2, "", DataRowVersion.Proposed, _berat))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@suhu", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 8, 2, "", DataRowVersion.Proposed, _suhu))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@suhuaxilla", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 8, 2, "", DataRowVersion.Proposed, _suhuaxilla))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@suhurectal", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 8, 2, "", DataRowVersion.Proposed, _suhurectal))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@suhuauritula", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 8, 2, "", DataRowVersion.Proposed, _suhuAuritula))
        '        cmdToExecute.Parameters.AddWithValue("@systole", _systole)
        '        cmdToExecute.Parameters.AddWithValue("@dyastole", _dyastole)
        '        cmdToExecute.Parameters.Add(New SqlParameter("@cvl", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _cvl))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@mata", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _mata))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@bicara", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _bicara))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@gerak", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _gerak))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@bscMata", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _bscMata))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@bscBicara", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _bscBicara))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@bscGerak", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _bscGerak))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@jmlnapas", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 8, 2, "", DataRowVersion.Proposed, _jmlnapas))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@jlnnapas", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jlnnapas))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@grknapas", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _grknapas))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@pernapasan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _pernapasan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@bunyinapaskiri", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _bunyinapaskiri))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@bunyinapaskanan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _bunyinapaskanan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@retraksidada", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _retraksidada))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kualitasnadi", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kualitasnadi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kulit", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kulit))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@bunyijantung", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _bunyijantung))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@voldarah", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 8, 2, "", DataRowVersion.Proposed, _voldarah))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@chkdarah", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _chkdarah))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@dpupilkiri", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _dpupilkiri))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@dpupilkanan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _dpupilkanan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@rpupilkiri", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _rpupilkiri))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@rpupilkanan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _rpupilkanan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kpllhr", SqlDbType.Text, _kpllhr.Value.Length, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kpllhr))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@toraks", SqlDbType.Text, _toraks.Value.Length, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _toraks))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tdkterapi", SqlDbType.Text, _tdkterapi.Value.Length, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _tdkterapi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@abdomen", SqlDbType.Text, _abdomen.Value.Length, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _abdomen))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@ekstremitas", SqlDbType.Text, _ekstremitas.Value.Length, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _ekstremitas))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@ketdiagnosa", SqlDbType.Text, _ketdiagnosa.Value.Length, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _ketdiagnosa))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kddiagnosa", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kddiagnosa))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdanestesi", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdanestesi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tgldisposisi", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgldisposisi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@jamdisposisi", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jamdisposisi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdnkeluar", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdnkeluar))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@crkeluar", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _crkeluar))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tdklanjut", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _tdklanjut))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@dokterrawat", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _dokterrawat))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@usrupdater", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _usrupdater))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tglupdater", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tglupdater))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@umurtahun", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _umurtahun))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@umurbulan", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _umurbulan))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@umurhari", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _umurhari))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@catatan", SqlDbType.Text, _catatan.Value.Length, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _catatan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Asma", _chkAsma))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Diabetes", _chkDiabetes))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Hipertensi", _chkHipertensi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@SakitJantung", _chkSakitJantung))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Stroke", _chkStroke))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@SakitGinjal", _chkSakitGinjal))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@SakitLever", _chkSakitLever))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@RiwayatOperasi", _chkRiwayatOperasi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@GigiPalsu", _chkGigiPalsu))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Protesis", _chkProtesis))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@LensaKontak", _chkLensaKontak))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@JnsOperasi", _txtJnsOperasi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@JamMknAkhir", _txtJamMknAkhir))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Tinggi", _Tinggi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Alergi", _chkAlergi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@PerintahSederhana", _chkPerintahSederhana))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Bernapas", _chkBernapas))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@GDS", _GDS))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Spo2", _Spo2))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@IsiKuku", _IsiKuku))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@CatatanPerkembangan", _CatatanPerkembangan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@RR", _RR))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@KdKeadaanUmum", _KdKeadaanUmum))

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        cmdToExecute.ExecuteNonQuery()

        '        Return True
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '    End Try
        'End Function

        'Public Function UpdateKetRegistrasi() As Boolean
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_registrasi_UpdateKetRegistrasi"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noreg))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@norm", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _norm))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@tgldatang", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgldatang))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@jamdatang", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jamdatang))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@tgllayan", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgllayan))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@jamlayan", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jamlayan))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@tglkejadian", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tglkejadian))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@jamkejadian", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jamkejadian))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kddokter", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kddokter))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdpengirim", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdpengirim))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nopengirim", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nopengirim))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@kdmasukrs", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdmasukrs))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@tpkejadian", SqlDbType.NVarChar, 75, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _tpkejadian))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@rwkejadian", SqlDbType.NVarChar, 200, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _rwkejadian))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@jnkasus", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jnkasus))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@kdkdndatang", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdkdndatang))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@kdalasan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdalasan))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@kddetail", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kddetail))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@kddeskripsi", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kddeskripsi))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@Pgtsbl", SqlDbType.NVarChar, 200, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _Pgtsbl))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@Anamnesa", SqlDbType.Text, _Anamnesa.Value.Length, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _Anamnesa))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@jnpasien", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jnpasien))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@triage", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _triage))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdjmbayar", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdjmbayar))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdperusahaan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdperusahaan))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@nadi", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 8, 2, "", DataRowVersion.Proposed, _nadi))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@suhu", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 8, 2, "", DataRowVersion.Proposed, _suhu))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@systole", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 8, 2, "", DataRowVersion.Proposed, _systole))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@dyastole", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 8, 2, "", DataRowVersion.Proposed, _dyastole))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@cvl", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _cvl))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@mata", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _mata))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@bicara", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _bicara))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@gerak", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _gerak))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@jmlnapas", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 8, 2, "", DataRowVersion.Proposed, _jmlnapas))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@jlnnapas", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jlnnapas))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@grknapas", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _grknapas))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@pernapasan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _pernapasan))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@bunyinapaskiri", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _bunyinapaskiri))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@bunyinapaskanan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _bunyinapaskanan))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@retraksidada", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _retraksidada))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@kualitasnadi", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kualitasnadi))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@kulit", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kulit))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@bunyijantung", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _bunyijantung))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@voldarah", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 8, 2, "", DataRowVersion.Proposed, _voldarah))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@chkdarah", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _chkdarah))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@dpupilkiri", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _dpupilkiri))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@dpupilkanan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _dpupilkanan))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@rpupilkiri", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _rpupilkiri))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@rpupilkanan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _rpupilkanan))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@kpllhr", SqlDbType.Text, _kpllhr.Value.Length, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kpllhr))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@toraks", SqlDbType.Text, _toraks.Value.Length, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _toraks))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@tdkterapi", SqlDbType.Text, _tdkterapi.Value.Length, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _tdkterapi))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@abdomen", SqlDbType.Text, _abdomen.Value.Length, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _abdomen))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@ekstremitas", SqlDbType.Text, _ekstremitas.Value.Length, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _ekstremitas))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@ketdiagnosa", SqlDbType.Text, _ketdiagnosa.Value.Length, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _ketdiagnosa))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@kddiagnosa", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kddiagnosa))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@kdanestesi", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdanestesi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tgldisposisi", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgldisposisi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@jamdisposisi", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jamdisposisi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdnkeluar", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdnkeluar))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@crkeluar", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _crkeluar))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tdklanjut", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _tdklanjut))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@dokterrawat", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _dokterrawat))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@usrupdater", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _usrupdater))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tglupdater", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tglupdater))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@umurtahun", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _umurtahun))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@umurbulan", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _umurbulan))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@umurhari", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _umurhari))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@catatan", SqlDbType.Text, _catatan.Value.Length, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _catatan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@ketinstansi", SqlDbType.NVarChar, 100, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _ketinstansi))

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        cmdToExecute.ExecuteNonQuery()

        '        Return True
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '    End Try
        'End Function

        'Public Function UpdateBatal() As Boolean
        '    _mainConnection.Open()
        '    Begintrans()

        '    Try
        '        '// Update Flag Batal di rd_reg
        '        With New SqlCommand
        '            .CommandText = "sprd_registrasi_updateBatal"
        '            .CommandType = CommandType.StoredProcedure
        '            .Connection = _mainConnection
        '            .Transaction = _transaction
        '            .Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noreg))
        '            .Parameters.Add(New SqlParameter("@batal", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _batal))
        '            .Parameters.Add(New SqlParameter("@usrbatal", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _usrbatal))
        '            .Parameters.Add(New SqlParameter("@tglbatal", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tglbatal))
        '            .Parameters.Add(New SqlParameter("@usrupdater", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _usrupdater))
        '            .Parameters.Add(New SqlParameter("@tglupdater", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tglupdater))
        '            .ExecuteNonQuery()
        '        End With

        '        If Len(_NoBayarPendaftaran.Value.Trim) > 0 Then
        '            '// Update Flag Batal di rd_bayar untuk Transaksi Otomatis
        '            With New SqlCommand
        '                .CommandText = "sprd_bayar_UpdateBatal"
        '                .CommandType = CommandType.StoredProcedure
        '                .Connection = _mainConnection
        '                .Transaction = _transaction
        '                .Parameters.Add(New SqlParameter("@nobayar", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _NoBayarPendaftaran))
        '                .Parameters.Add(New SqlParameter("@usrupdate", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _usrupdater))
        '                .ExecuteNonQuery()
        '            End With
        '        End If

        '        '// Delete di rd_PemeriksaanPenunjang berdasarkan noreg yg dibatalkan
        '        With New SqlCommand
        '            .CommandText = "sprd_PemeriksaanPenunjang_DeleteByNoreg"
        '            .CommandType = CommandType.StoredProcedure
        '            .Connection = _mainConnection
        '            .Transaction = _transaction
        '            .Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noreg))
        '            .ExecuteNonQuery()
        '        End With

        '        '// Delete di rd_penjaminbayar berdasarkan noreg yg dibatalkan

        '        With New SqlCommand
        '            .CommandText = "sprd_penjaminbayar_deleteByNoreg"
        '            .CommandType = CommandType.StoredProcedure
        '            .Connection = _mainConnection
        '            .Transaction = _transaction
        '            .Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noreg))
        '            .ExecuteNonQuery()
        '        End With

        '        '// Delete di rd_penanggungjawab berdasarkan noreg yg dibatalkan

        '        With New SqlCommand
        '            .CommandText = "sprd_penanggungjawab_delete"
        '            .CommandType = CommandType.StoredProcedure
        '            .Connection = _mainConnection
        '            .Transaction = _transaction
        '            .Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noreg))
        '            .ExecuteNonQuery()
        '        End With

        '        CommitTrans()
        '        Return True
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '        RollBackTrans()
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        _transaction.Dispose()
        '    End Try
        'End Function

        'Public Function UpdateDiagnosa() As Boolean
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_registrasi_UpdateDiagnosa"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection
        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noreg))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdDtd", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kddtd))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdIcd", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdIcd))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdIcdkc", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdIcdkc))

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        cmdToExecute.ExecuteNonQuery()

        '        Return True
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '    End Try
        'End Function

        'Public Function UpdateTutup() As Boolean
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_registrasi_UpdateTutup"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection
        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noreg))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tutup", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _tutup))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@usrupdater", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _usrupdater))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tgltutup", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgltutup))

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        cmdToExecute.ExecuteNonQuery()

        '        Return True
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '    End Try
        'End Function

        'Public Function UpdateJmBayar() As Boolean
        '    _mainConnection.Open()
        '    Begintrans()

        '    Try
        '        '// Update Flag Batal di rd_reg
        '        With New SqlCommand
        '            .CommandText = "sprd_registrasi_UpdateJmBayar"
        '            .CommandType = CommandType.StoredProcedure
        '            .Connection = _mainConnection
        '            .Transaction = _transaction
        '            .Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noreg))
        '            .Parameters.Add(New SqlParameter("@kdjmbayar", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdjmbayar))
        '            .Parameters.Add(New SqlParameter("@kdperusahaan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdperusahaan))
        '            .Parameters.Add(New SqlParameter("@ketinstansi", SqlDbType.NVarChar, 100, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _ketinstansi))
        '            .Parameters.Add(New SqlParameter("@plafon", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _plafon))
        '            .Parameters.Add(New SqlParameter("@usrupdater", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _usrupdater))

        '            .ExecuteNonQuery()
        '        End With

        '        If Len(_kdperusahaan.Value.Trim) > 0 Then
        '            '// Update Flag Batal di rd_reg
        '            With New SqlCommand
        '                .CommandText = "sprd_piutanginst_UpdateKdInstansi"
        '                .CommandType = CommandType.StoredProcedure
        '                .Connection = _mainConnection
        '                .Transaction = _transaction
        '                .Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noreg))
        '                .Parameters.Add(New SqlParameter("@kdperusahaan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdperusahaan))
        '                .Parameters.Add(New SqlParameter("@usrupdater", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _usrupdater))

        '                .ExecuteNonQuery()
        '            End With
        '        End If

        '        CommitTrans()
        '        Return True
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '        RollBackTrans()
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        _transaction.Dispose()
        '    End Try
        'End Function

        'Public Function UpdateKeadaanKeluar() As Boolean
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_registrasi_UpdateKeadaanKeluar"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection
        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noreg))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tgldisposisi", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgldisposisi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@jamdisposisi", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jamdisposisi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@dokterrawat", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _dokterrawat))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdnkeluar", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdnkeluar))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@crkeluar", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _crkeluar))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tdklanjut", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _tdklanjut))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@catatan", SqlDbType.Text, _catatan.Value.Length, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _catatan))

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        cmdToExecute.ExecuteNonQuery()

        '        Return True
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '    End Try
        'End Function

        'Public Function UpdateNorm() As Boolean
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_registrasi_UpdateNoRM"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection
        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noreg))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@norm", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _norm))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@usrupdater", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _usrupdater))

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        cmdToExecute.ExecuteNonQuery()

        '        Return True
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '    End Try
        'End Function

        'Public Function UpdatePengirim() As Boolean
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_registrasi_UpdatePengirim"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection
        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noreg))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdpengirim", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdpengirim))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nopengirim", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nopengirim))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@jnkasus", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jnkasus))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@usrupdater", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _usrupdater))

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        cmdToExecute.ExecuteNonQuery()

        '        Return True
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '    End Try
        'End Function

        'Public Function UpdatePengirimDanDescPengirim() As Boolean
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_Registrasi_UpdatePengirimDanDescPengirim"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@noreg", _noreg))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdpengirim", _kdpengirim))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nopengirim", _nopengirim))


        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        cmdToExecute.ExecuteNonQuery()


        '        Return True
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '    End Try
        'End Function

        'Public Function UpdateBatalBiayaPendaftaran() As Boolean
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_registrasi_UpdateBatalBiayaPendaftaran"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection
        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noreg))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nobayar", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _NoBayarPendaftaran))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@biayapendaftaran", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _biayapendaftaran))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tglbiaya", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, SqlDateTime.Null))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@usrbiaya", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _usrbiaya))

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        cmdToExecute.ExecuteNonQuery()

        '        Return True
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '    End Try
        'End Function

        'Public Function Update_CloseStatus() As Boolean
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_Registrasi_Update_CloseStatus"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try

        '        cmdToExecute.Parameters.Add(New SqlParameter("@NoReg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Proposed, _noreg))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Tutup", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Proposed, _tutup))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@usrupdate", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Proposed, _usrupdater))

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        cmdToExecute.ExecuteNonQuery()

        '        Return True
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '    End Try
        'End Function

        'Public Function UpdateNilaiPLafon() As Boolean
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_registrasi_UpdateNilaiPLafon"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection
        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noreg))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdplafon", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdplafon))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@plafon", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _plafon))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@sisaplafon", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _sisaplafon))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@fplafonperhari", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _fplafonperhari))

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        cmdToExecute.ExecuteNonQuery()

        '        Return True
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '    End Try
        'End Function

        ''// add by bang_t: 20/10/09
        'Public Function UpdateNilaiDiskonTagihan() As Boolean
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_registrasi_UpdateNilaiDiskonTagihan"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection
        '    Try
        '        cmdToExecute.Parameters.Add("@NoReg", _noreg)
        '        cmdToExecute.Parameters.Add("@DiskonTagihan", _diskonTagihan)

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        cmdToExecute.ExecuteNonQuery()

        '        Return True
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '    End Try
        'End Function
        'Public Function updatekdterminal() As Boolean
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_registrasi_updatekdterminal"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection
        '    _mainConnection.Open()
        '    Begintrans()

        '    cmdToExecute.Transaction = _transaction
        '    Try
        '        cmdToExecute.Parameters.Add("@NoReg", _noreg)
        '        cmdToExecute.Parameters.Add("@kdterminal", _kdterminal)


        '        ' // Open connection.


        '        ' // Execute query.
        '        cmdToExecute.ExecuteNonQuery()
        '        CommitTrans()
        '        Return True
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '        RollBackTrans()
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        _transaction.Dispose()
        '    End Try
        'End Function
#End Region

#Region "Select"

        Public Overrides Function SelectOne(Optional ByVal recStatus As QISRecStatus = QISRecStatus.CurrentRecord) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Select Case recStatus
                Case QISRecStatus.CurrentRecord
                    cmdToExecute.CommandText = "sprd_registrasi_SelectOne "
                Case QISRecStatus.NextRecord
                    cmdToExecute.CommandText = "sprd_registrasi_SelectOneNext"
                Case QISRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "sprd_registrasi_SelectOnePrev"
            End Select

            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("rd_reg")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noreg))

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _noreg = New SqlString(CType(toReturn.Rows(0)("noreg"), String))
                    _norm = New SqlString(CType(toReturn.Rows(0)("norm"), String))
                    _tgldatang = New SqlDateTime(CType(toReturn.Rows(0)("tgldatang"), Date))
                    '_jamdatang = New SqlString(CType(toReturn.Rows(0)("jamdatang"), String))
                    '_tgllayan = New SqlDateTime(CType(toReturn.Rows(0)("tgllayan"), Date))
                    '_jamlayan = New SqlString(CType(toReturn.Rows(0)("jamlayan"), String))
                    '_tglkejadian = New SqlDateTime(CType(toReturn.Rows(0)("tglkejadian"), Date))
                    '_jamkejadian = New SqlString(CType(toReturn.Rows(0)("jamkejadian"), String))
                    '_kddokter = New SqlString(CType(toReturn.Rows(0)("kddokter"), String))
                    '_kdpengirim = New SqlString(CType(toReturn.Rows(0)("kdpengirim"), String))
                    '_nopengirim = New SqlString(CType(toReturn.Rows(0)("nopengirim"), String))
                    '_kdmasukrs = New SqlString(CType(toReturn.Rows(0)("kdmasukrs"), String))
                    '_tpkejadian = New SqlString(CType(toReturn.Rows(0)("tpkejadian"), String))
                    '_rwkejadian = New SqlString(CType(toReturn.Rows(0)("rwkejadian"), String))
                    '_jnkasus = New SqlString(CType(toReturn.Rows(0)("jnkasus"), String))
                    '_kdkdndatang = New SqlString(CType(toReturn.Rows(0)("kdkdndatang"), String))
                    '_KdKeadaanUmum = New SqlString(CType(toReturn.Rows(0)("kdkeadaanumum"), String))
                    '_kdalasan = New SqlString(CType(toReturn.Rows(0)("kdalasan"), String))
                    '_kddetail = New SqlString(CType(toReturn.Rows(0)("kddetail"), String))
                    '_kddeskripsi = New SqlString(CType(toReturn.Rows(0)("kddeskripsi"), String))
                    '_Pgtsbl = New SqlString(CType(toReturn.Rows(0)("Pgtsbl"), String))
                    '_Anamnesa = New SqlString(CType(toReturn.Rows(0)("Anamnesa"), String))
                    '_jnpasien = New SqlString(CType(toReturn.Rows(0)("jnpasien"), String))
                    '_triage = New SqlString(CType(toReturn.Rows(0)("triage"), String))
                    '_kdjmbayar = New SqlString(CType(toReturn.Rows(0)("kdjmbayar"), String))
                    '_kdperusahaan = New SqlString(CType(toReturn.Rows(0)("kdperusahaan"), String))
                    '_kdplafon = New SqlString(CType(toReturn.Rows(0)("kdplafon"), String))
                    '_plafon = New SqlMoney(CType(toReturn.Rows(0)("plafon"), Decimal))
                    '_sisaplafon = New SqlMoney(CType(toReturn.Rows(0)("sisaplafon"), Decimal))
                    '_fplafonperhari = New SqlBoolean(CType(toReturn.Rows(0)("fplafonperhari"), Boolean))
                    '_nadi = New SqlDecimal(CType(toReturn.Rows(0)("nadi"), Decimal))
                    '_berat = New SqlDecimal(CType(toReturn.Rows(0)("berat"), Decimal))
                    '_suhu = New SqlDecimal(CType(toReturn.Rows(0)("suhu"), Decimal))
                    '_suhuaxilla = New SqlDecimal(CType(toReturn.Rows(0)("suhuaxilla"), Decimal))
                    '_suhurectal = New SqlDecimal(CType(toReturn.Rows(0)("suhurectal"), Decimal))
                    '_suhuAuritula = New SqlDecimal(CType(toReturn.Rows(0)("suhuauritula"), Decimal))
                    '_systole = New SqlDecimal(CType(toReturn.Rows(0)("systole"), Decimal))
                    '_dyastole = New SqlDecimal(CType(toReturn.Rows(0)("dyastole"), Decimal))
                    '_cvl = New SqlString(CType(toReturn.Rows(0)("cvl"), String))
                    '_mata = New SqlString(CType(toReturn.Rows(0)("mata"), String))
                    '_bicara = New SqlString(CType(toReturn.Rows(0)("bicara"), String))
                    '_gerak = New SqlString(CType(toReturn.Rows(0)("gerak"), String))
                    '_bscMata = New SqlString(CType(toReturn.Rows(0)("bscMata"), String))
                    '_bscBicara = New SqlString(CType(toReturn.Rows(0)("bscBicara"), String))
                    '_bscGerak = New SqlString(CType(toReturn.Rows(0)("bscGerak"), String))
                    '_jmlnapas = New SqlDecimal(CType(toReturn.Rows(0)("jmlnapas"), Decimal))
                    '_jlnnapas = New SqlString(CType(toReturn.Rows(0)("jlnnapas"), String))
                    '_grknapas = New SqlString(CType(toReturn.Rows(0)("grknapas"), String))
                    '_pernapasan = New SqlString(CType(toReturn.Rows(0)("pernapasan"), String))
                    '_bunyinapaskiri = New SqlString(CType(toReturn.Rows(0)("bunyinapaskiri"), String))
                    '_bunyinapaskanan = New SqlString(CType(toReturn.Rows(0)("bunyinapaskanan"), String))
                    '_retraksidada = New SqlBoolean(CType(toReturn.Rows(0)("retraksidada"), Boolean))
                    '_kualitasnadi = New SqlString(CType(toReturn.Rows(0)("kualitasnadi"), String))
                    '_kulit = New SqlString(CType(toReturn.Rows(0)("kulit"), String))
                    '_bunyijantung = New SqlString(CType(toReturn.Rows(0)("bunyijantung"), String))
                    '_voldarah = New SqlDecimal(CType(toReturn.Rows(0)("voldarah"), Decimal))
                    '_chkdarah = New SqlBoolean(CType(toReturn.Rows(0)("chkdarah"), Boolean))
                    '_dpupilkiri = New SqlString(CType(toReturn.Rows(0)("dpupilkiri"), String))
                    '_dpupilkanan = New SqlString(CType(toReturn.Rows(0)("dpupilkanan"), String))
                    '_rpupilkiri = New SqlString(CType(toReturn.Rows(0)("rpupilkiri"), String))
                    '_rpupilkanan = New SqlString(CType(toReturn.Rows(0)("rpupilkanan"), String))
                    '_kpllhr = New SqlString(CType(toReturn.Rows(0)("kpllhr"), String))
                    '_toraks = New SqlString(CType(toReturn.Rows(0)("toraks"), String))
                    '_tdkterapi = New SqlString(CType(toReturn.Rows(0)("tdkterapi"), String))
                    '_abdomen = New SqlString(CType(toReturn.Rows(0)("abdomen"), String))
                    '_ekstremitas = New SqlString(CType(toReturn.Rows(0)("ekstremitas"), String))
                    '_ketdiagnosa = New SqlString(CType(toReturn.Rows(0)("ketdiagnosa"), String))
                    '_kddiagnosa = New SqlString(CType(toReturn.Rows(0)("kddiagnosa"), String))
                    '_kdanestesi = New SqlString(CType(toReturn.Rows(0)("kdanestesi"), String))
                    '_tgldisposisi = New SqlDateTime(CType(toReturn.Rows(0)("tgldisposisi"), Date))
                    '_jamdisposisi = New SqlString(CType(toReturn.Rows(0)("jamdisposisi"), String))
                    '_kdnkeluar = New SqlString(CType(toReturn.Rows(0)("kdnkeluar"), String))
                    '_crkeluar = New SqlString(CType(toReturn.Rows(0)("crkeluar"), String))
                    '_dokterrawat = New SqlString(CType(toReturn.Rows(0)("dokterrawat"), String))
                    '_biayapendaftaran = New SqlBoolean(CType(ProcessNull.GetBoolean(toReturn.Rows(0)("biayapendaftaran")), Boolean))
                    '_NoBayarPendaftaran = New SqlString(CType(ProcessNull.GetString(toReturn.Rows(0)("nobayarpendaftaran")), String))
                    '_nomember = New SqlString(CType(ProcessNull.GetString(toReturn.Rows(0)("nomember")), String))
                    '_tutup = New SqlBoolean(CType(ProcessNull.GetBoolean(toReturn.Rows(0)("tutup")), Boolean))
                    '_tgltutup = New SqlDateTime(CType(ProcessNull.GetDateTime(toReturn.Rows(0)("tgltutup")), Date))
                    '_batal = New SqlBoolean(CType(ProcessNull.GetBoolean(toReturn.Rows(0)("batal")), Boolean))
                    '_reviewOfSystemText = New SqlString(CType(ProcessNull.GetString(toReturn.Rows(0)("reviewOfSystemText")), String))
                    '_tglbatal = New SqlDateTime(CType(ProcessNull.GetDateTime(toReturn.Rows(0)("tglbatal")), Date))
                    '_usrbatal = New SqlString(CType(ProcessNull.GetString(toReturn.Rows(0)("usrbatal")), String))
                    '_tglupdater = New SqlDateTime(CType(ProcessNull.GetDateTime(toReturn.Rows(0)("tglupdater")), Date))
                    '_usrupdater = New SqlString(CType(ProcessNull.GetString(toReturn.Rows(0)("usrupdater")), String))
                    '_usrinsert = New SqlString(CType(toReturn.Rows(0)("usrinsert"), String))
                    '_tglinsert = New SqlDateTime(CType(toReturn.Rows(0)("tglinsert"), Date))
                    '_usrbiaya = New SqlString(CType(ProcessNull.GetString(toReturn.Rows(0)("usrbiaya")), String))
                    '_tglbiaya = New SqlDateTime(CType(ProcessNull.GetDateTime(toReturn.Rows(0)("tglbiaya")), Date))
                    '_PrnthSdhnDT = New SqlString(CType(toReturn.Rows(0)("prnthsdhnDT"), String))
                    ''_kddtd = New SqlString(CType(toReturn.Rows(0)("kddtd"), String))
                    'If toReturn.Rows(0)("kddtd") Is System.DBNull.Value Then
                    '    _kddtd = New SqlString(String.Empty)
                    'Else
                    '    _kddtd = New SqlString(CType(toReturn.Rows(0)("kddtd"), String))
                    'End If
                    'If toReturn.Rows(0)("kdIcd") Is System.DBNull.Value Then
                    '    _kdIcd = New SqlString(String.Empty)
                    'Else
                    '    _kdIcd = New SqlString(CType(toReturn.Rows(0)("kdIcd"), String))
                    'End If
                    'If toReturn.Rows(0)("kdIcdkc") Is System.DBNull.Value Then
                    '    _kdIcdkc = New SqlString(String.Empty)
                    'Else
                    '    _kdIcdkc = New SqlString(CType(toReturn.Rows(0)("kdIcdkc"), String))
                    'End If

                    '_umurtahun = New SqlInt16(CType(toReturn.Rows(0)("umurtahun"), Short))
                    '_umurbulan = New SqlInt16(CType(toReturn.Rows(0)("umurbulan"), Short))
                    '_umurhari = New SqlInt16(CType(toReturn.Rows(0)("umurhari"), Short))
                    '_catatan = New SqlString(CType(toReturn.Rows(0)("catatan"), String))
                    '_tdklanjut = New SqlString(CType(toReturn.Rows(0)("tdklanjut"), String))
                    '_kunjunganbaru = New SqlBoolean(CType(ProcessNull.GetBoolean(toReturn.Rows(0)("kunjunganbaru")), Boolean))
                    'If toReturn.Rows(0)("kartu") Is DBNull.Value Then
                    '    _kartu = New SqlBoolean(False)
                    'Else
                    '    _kartu = New SqlBoolean(CType(toReturn.Rows(0)("kartu"), Boolean))
                    'End If
                    'If toReturn.Rows(0)("ketinstansi") Is DBNull.Value Then
                    '    _ketinstansi = New SqlString(String.Empty)
                    'Else
                    '    _ketinstansi = New SqlString(CType(toReturn.Rows(0)("ketinstansi"), String))
                    'End If
                    'If toReturn.Rows(0)("shift") Is DBNull.Value Then
                    '    _shift = New SqlString(String.Empty)
                    'Else
                    '    _shift = New SqlString(CType(toReturn.Rows(0)("shift"), String))
                    'End If
                    '_tglshift = New SqlDateTime(CType(toReturn.Rows(0)("tglshift"), Date))

                    '_chkAsma = New SqlBoolean(CType(toReturn.Rows(0)("Asma"), Boolean))
                    '_chkDiabetes = New SqlBoolean(CType(toReturn.Rows(0)("Diabetes"), Boolean))
                    '_chkHipertensi = New SqlBoolean(CType(toReturn.Rows(0)("Hipertensi"), Boolean))
                    '_chkSakitJantung = New SqlBoolean(CType(toReturn.Rows(0)("SakitJantung"), Boolean))
                    '_chkStroke = New SqlBoolean(CType(toReturn.Rows(0)("Stroke"), Boolean))
                    '_chkSakitGinjal = New SqlBoolean(CType(toReturn.Rows(0)("SakitGinjal"), Boolean))
                    '_chkSakitLever = New SqlBoolean(CType(toReturn.Rows(0)("SakitLiver"), Boolean))
                    '_chkRiwayatOperasi = New SqlBoolean(CType(toReturn.Rows(0)("RiwayatOperasi"), Boolean))
                    '_chkGigiPalsu = New SqlBoolean(CType(toReturn.Rows(0)("GigiPalsu"), Boolean))
                    '_chkProtesis = New SqlBoolean(CType(toReturn.Rows(0)("Protesis"), Boolean))
                    '_chkLensaKontak = New SqlBoolean(CType(toReturn.Rows(0)("LensaKontak"), Boolean))
                    '_txtJnsOperasi = New SqlString(CType(toReturn.Rows(0)("JnsOperasi"), String))
                    '_txtJamMknAkhir = New SqlString(CType(toReturn.Rows(0)("JamMknTerakhir"), String))
                    '_Tinggi = New SqlDecimal(CType(toReturn.Rows(0)("Tinggi"), Decimal))
                    '_chkAlergi = New SqlBoolean(CType(toReturn.Rows(0)("Alergi"), Boolean))
                    '_chkPerintahSederhana = New SqlBoolean(CType(toReturn.Rows(0)("PerintahSederhana"), Boolean))
                    '_chkBernapas = New SqlBoolean(CType(toReturn.Rows(0)("Bernapas"), Boolean))
                    '_GDS = New SqlString(CType(toReturn.Rows(0)("GDS"), String))
                    '_Spo2 = New SqlString(CType(toReturn.Rows(0)("Spo2"), String))
                    '_RR = New SqlString(CType(toReturn.Rows(0)("RR"), String))

                    'If toReturn.Rows(0)("IsiKuku") Is DBNull.Value Then
                    '    _IsiKuku = New SqlString(String.Empty)
                    'Else
                    '    _IsiKuku = New SqlString(CType(toReturn.Rows(0)("IsiKuku"), String))
                    'End If

                    '_CatatanPerkembangan = New SqlString(CType(toReturn.Rows(0)("CatatanPerkembangan"), String))

                    '_IsServiced = New SqlBoolean(CType(toReturn.Rows(0)("IsServiced"), Boolean))
                    '_IsExamined = New SqlBoolean(CType(toReturn.Rows(0)("IsExamined"), Boolean))
                    ''_jenisTarif = CType(toReturn.Rows(0)("JenisTarif"), String)
                    '_diskonTagihan = New SqlMoney(CType(toReturn.Rows(0)("DiskonTagihan"), Decimal))
                End If
                Return toReturn
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function

        'Public Function Select_TransaksiSudahBayar_ForPlafon() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_select_register_txnsudahbayar_platfon"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("transaksi")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, Me.NoReg))

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        adapter.Fill(toReturn)

        '        If toReturn.Rows.Count > 0 Then
        '            _noreg = New SqlString(CType(toReturn.Rows(0)("noreg"), String))
        '            _tinstansi = New SqlMoney(CType(toReturn.Rows(0)("tinstansi"), Decimal))
        '        End If

        '        Return toReturn
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function
        'Public Overrides Function SelectAll() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    cmdToExecute.CommandText = "dbo.[sprd_registrasi_SelectAll]"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure
        '    Dim toReturn As DataTable = New DataTable("rd_registrasi")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        adapter.Fill(toReturn)
        '        Return toReturn
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function

        'Public Function SelectByPasien() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_registrasi_selectByPasien"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("rd_reg")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noreg))

        '        _mainConnection.Open()
        '        adapter.Fill(toReturn)

        '        Return toReturn
        '    Catch ex As Exception
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function

        'Public Function SelectForCetakLabel() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    cmdToExecute.CommandText = "sprm_LembarLabelKecil"

        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("sprj_Registrasi_SelectForCetakTracer")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add("@appId", _App)
        '        cmdToExecute.Parameters.Add("@noreg", _noreg)

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        adapter.Fill(toReturn)

        '        If toReturn.Rows.Count > 0 Then
        '            _noreg = New SqlString(CType(toReturn.Rows(0)("noreg"), String))
        '            _norm = New SqlString(CType(toReturn.Rows(0)("norm"), String))
        '            _tgllahir = New SqlString(CType(toReturn.Rows(0)("tgllahir"), String))
        '            _Nama = New SqlString(CType(toReturn.Rows(0)("nmpasien"), String))
        '            _umurtahun = New SqlInt32(CType(toReturn.Rows(0)("umurtahun"), Integer))
        '            _umurbulan = New SqlInt32(CType(toReturn.Rows(0)("umurbulan"), Integer))
        '            _umurhari = New SqlInt32(CType(toReturn.Rows(0)("umurhari"), Integer))
        '            _kdseks = New SqlString(CType(toReturn.Rows(0)("kdseks"), String))
        '            _ketinstansi = New SqlString(CType(toReturn.Rows(0)("nmpenjamin"), String))
        '            _kdRuang = New SqlString(CType(toReturn.Rows(0)("kdunit"), String))
        '            _ruang = New SqlString(CType(toReturn.Rows(0)("nmunit"), String))
        '        End If

        '        Return toReturn
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function

        'Public Function SelectNoregrdInRIreg_RItransaksi(ByVal noregistrasi) As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprdri_noregistrasi_in_RIreg_RItransaksi"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("rd_reg")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@noreg", noregistrasi))

        '        _mainConnection.Open()
        '        adapter.Fill(toReturn)

        '        Return toReturn
        '    Catch ex As Exception
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function

        'Public Function SelectForOutstandingTransaction(ByVal noregistrasi) As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_Registrasi_HasOutstandingTrx"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("rd_reg")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@noreg", noregistrasi))

        '        _mainConnection.Open()
        '        adapter.Fill(toReturn)

        '        Return toReturn
        '    Catch ex As Exception
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function


        'Public Function SelectForCekRegistrasi() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_registrasi_selectForCekRegistrasi"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("rd_reg")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@norm", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _norm))

        '        _mainConnection.Open()
        '        adapter.Fill(toReturn)

        '        Return toReturn
        '    Catch ex As Exception
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function

        'Public Function SelectForCekRegistrasiByTglDatang() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_registrasi_selectForCekRegistrasiByTanggal"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("sprd_registrasi_selectForCekRegistrasiByTanggal")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add("@norm", _norm)
        '        cmdToExecute.Parameters.Add("@tgldatang", _tgldatang)

        '        _mainConnection.Open()
        '        adapter.Fill(toReturn)

        '        Return toReturn
        '    Catch ex As Exception
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function

        'Public Function SelectByNorm() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_registrasi_SelectByNorm"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("rd_reg")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@norm", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _norm))

        '        _mainConnection.Open()
        '        adapter.Fill(toReturn)

        '        Return toReturn
        '    Catch ex As Exception
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function

        'Public Function SelectByNormNotBatal() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_registrasi_SelectByNormNotBatal"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("rd_reg")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@norm", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _norm))

        '        _mainConnection.Open()
        '        adapter.Fill(toReturn)

        '        Return toReturn
        '    Catch ex As Exception
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function

        'Public Function SelectByTglDatang() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_registrasi_selectByTglDatang"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("rd_reg")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tgldatang", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgldatang))

        '        _mainConnection.Open()
        '        adapter.Fill(toReturn)

        '        Return toReturn
        '    Catch ex As Exception
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function

        'Public Function SelectByTglDatangForSelReg() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_registrasi_selectByTglDatangForSelReg"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("sprd_registrasi_selectByTglDatangForSelReg")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tgldatang", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgldatang))

        '        _mainConnection.Open()
        '        adapter.Fill(toReturn)

        '        Return toReturn
        '    Catch ex As Exception
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function

        'Public Function SelectByTglDatangForInfoReg() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_registrasi_selectByTglDatangForInfoReg"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("rd_reg")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tgldatang", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgldatang))

        '        _mainConnection.Open()
        '        adapter.Fill(toReturn)

        '        Return toReturn
        '    Catch ex As Exception
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function

        'Public Function SelectByAllTglDatang() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_registrasi_selectAllByTglDatang"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("rd_reg")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tgldatang", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgldatang))

        '        _mainConnection.Open()
        '        adapter.Fill(toReturn)

        '        Return toReturn
        '    Catch ex As Exception
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function

        'Public Function SelectByAllTutupTglDatang() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_registrasi_selectAllTutupByTglDatang"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("rd_reg")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tgldatang", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgldatang))

        '        _mainConnection.Open()
        '        adapter.Fill(toReturn)

        '        Return toReturn
        '    Catch ex As Exception
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function

        'Public Function SelectByNoregTglDatang() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_registrasi_selectByNoregTglDatang"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("rd_reg")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noreg))
        '        '   cmdToExecute.Parameters.Add(New SqlParameter("@tgldatang", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgldatang))

        '        _mainConnection.Open()
        '        adapter.Fill(toReturn)

        '        Return toReturn
        '    Catch ex As Exception
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function

        'Public Function SelectByAllTutupNoregTglDatang() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_registrasi_selectByAllTutupNoregTglDatang"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("rd_reg")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noreg))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tgldatang", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgldatang))

        '        _mainConnection.Open()
        '        adapter.Fill(toReturn)

        '        Return toReturn
        '    Catch ex As Exception
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function

        'Public Function CekPembayaran_ByNoreg() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_Registrasi_CekPembayaran_ByNoreg"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("rd_registrasi")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, Me.NoReg))

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        adapter.Fill(toReturn)

        '        Return toReturn
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function

        'Public Function Select_SudahLunasByNoreg() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_Registrasi_SelectSudahLunas_ByNoreg"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("rd_registrasi")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, Me.NoReg))

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        adapter.Fill(toReturn)

        '        Return toReturn
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function

        'Public Function SelectByNewNorm() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_pasien_SelectByNewNorm"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("pasien")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@norm", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _norm))

        '        _mainConnection.Open()
        '        adapter.Fill(toReturn)

        '        Return toReturn
        '    Catch ex As Exception
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function

        'Public Function Select_ForCloseRegistrasi() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_Registrasi_SelectForCloseRegistrasi"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("rd_reg")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tgldatang", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgldatang))

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        adapter.Fill(toReturn)

        '        Return toReturn
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function

        'Public Function SelectCloseByTgl() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_Registrasi_SelectCloseByTgl"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("rd_reg")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tgldatang", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgldatang))

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        adapter.Fill(toReturn)

        '        Return toReturn
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function

        'Public Function Select_SudahLunasByTgl() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_Registrasi_SelectSudahLunas_ByTgl"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("rd_registrasi")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tgldatang", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, Me.tgldatang))

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        adapter.Fill(toReturn)

        '        Return toReturn
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function

        'Public Function SelectOne_ForBayar() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_Registrasi_SelectOne_ForBayar"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("rd_registrasi")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noreg))

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        adapter.Fill(toReturn)


        '        Return toReturn
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function

        'Public Function SelectForCekDisposisi() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_registrasi_selectForCekDisposisi"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("rd_reg")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add("@noreg", _noreg)

        '        _mainConnection.Open()
        '        adapter.Fill(toReturn)

        '        Return toReturn
        '    Catch ex As Exception
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function
        'Public Function Get_RuangandKelas() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_getRuang_onInap"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("transaksi")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, Me.NoReg))

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        adapter.Fill(toReturn)

        '        If toReturn.Rows.Count > 0 Then
        '            _noregri = New SqlString(CType(toReturn.Rows(0)("noreg"), String))
        '            _ruang = New SqlString(CType(toReturn.Rows(0)("nmruang"), String))
        '            _kdRuang = New SqlString(CType(toReturn.Rows(0)("kdruangrawat"), String))
        '            _kelas = New SqlString(CType(toReturn.Rows(0)("nmkelas"), String))
        '            _kdkelas = New SqlString(CType(toReturn.Rows(0)("kdkelas"), String))
        '            _kddokter = New SqlString(CType(toReturn.Rows(0)("kddokter"), String))
        '            _nott = New SqlString(CType(toReturn.Rows(0)("nott"), String))
        '        End If

        '        Return toReturn
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function

        'Public Function IsUsedToReg(ByVal norm As String) As Boolean
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprs_isRegNormUsedTo"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("transaksi")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@norm", norm))

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        adapter.Fill(toReturn)

        '        If toReturn.Rows.Count >= 0 Then
        '            Return True
        '        Else
        '            Return False
        '        End If
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function

        'Public Function SelectForCetakTracer() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    cmdToExecute.CommandText = "sprd_Registrasi_SelectForCetakTracer"

        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("sprd_Registrasi_SelectForCetakTracer")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add("@noreg", _noreg)

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        adapter.Fill(toReturn)

        '        If toReturn.Rows.Count > 0 Then
        '            _noreg = New SqlString(CType(toReturn.Rows(0)("noreg"), String))
        '            _norm = New SqlString(CType(toReturn.Rows(0)("norm"), String))
        '            _tgldatang = New SqlDateTime(CType(toReturn.Rows(0)("TglDatang"), DateTime))
        '            _jamdatang = New SqlString(CType(toReturn.Rows(0)("jamdatang"), String))
        '            _kddokter = New SqlString(CType(toReturn.Rows(0)("kddokter"), String))
        '            _NmDokter = New SqlString(CType(toReturn.Rows(0)("nmdokter"), String))
        '            _Nama = New SqlString(CType(toReturn.Rows(0)("nama"), String))
        '            _Marga = New SqlString(CType(toReturn.Rows(0)("marga"), String))
        '            _pasienbaru = New SqlBoolean(CType(toReturn.Rows(0)("pasienbaru"), Boolean))
        '            _usrupdater = New SqlString(CType(toReturn.Rows(0)("usrupdater"), String))
        '            _kdseks = New SqlString(CType(toReturn.Rows(0)("kdseks"), String))
        '            _jnkasus = New SqlString(CType(toReturn.Rows(0)("jnkasus"), String))
        '        End If

        '        Return toReturn
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function
        'Public Function SelectterminalByNoreg() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    cmdToExecute.CommandText = "sprd_registrasi_selectterminalByNoreg"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("registrasi")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add("@noreg", _noreg)

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        adapter.Fill(toReturn)

        '        If toReturn.Rows.Count > 0 Then
        '            _noreg = New SqlString(CType(toReturn.Rows(0)("noreg"), String))
        '            _kdterminal = New SqlString(CType(toReturn.Rows(0)("kdterminal"), String))
        '        End If

        '        Return toReturn

        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function
#End Region

#Region "Delete"

        'Public Overrides Function Delete() As Boolean
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    cmdToExecute.CommandText = "dbo.[sprd_registrasi_Delete]"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noreg))

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        cmdToExecute.ExecuteNonQuery()
        '        Return True
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '    End Try
        'End Function



#End Region

#Region "Log PRinter Otomatis"
        'Public Sub InsertLogPrint(ByVal app As String, ByVal type As String, ByVal noreg As String, ByVal THeader As String, ByVal TBody As String, ByVal TFooter As String, ByVal TFull As String, ByVal UserInsert As String)
        '    Dim cmdToExecute As New SqlCommand

        '    cmdToExecute.CommandType = CommandType.StoredProcedure
        '    cmdToExecute.CommandText = "sprs_PrintOtomatisInsert"

        '    cmdToExecute.Parameters.Add(New SqlParameter("@App", app))
        '    cmdToExecute.Parameters.Add(New SqlParameter("@Type", type))
        '    cmdToExecute.Parameters.Add(New SqlParameter("@Noreg", noreg))
        '    cmdToExecute.Parameters.Add(New SqlParameter("@THeader", THeader))
        '    cmdToExecute.Parameters.Add(New SqlParameter("@TBody", TBody))
        '    cmdToExecute.Parameters.Add(New SqlParameter("@TFooter", TFooter))
        '    cmdToExecute.Parameters.Add(New SqlParameter("@TFull", TFull))
        '    cmdToExecute.Parameters.Add(New SqlParameter("@UsrInsert", UserInsert))


        '    Try
        '        cmdToExecute.Connection = _mainConnection

        '        _mainConnection.Open()

        '        cmdToExecute.ExecuteNonQuery()

        '    Catch ex As Exception

        '        ' // some error occured. Bubble it   to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)

        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '    End Try

        'End Sub
#End Region

#Region "Select For Total Transaksi"
        'Public Function SelectForTotalTransaksiPlafon() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_dttransaksi_SelectForTotalTransaksiPlafon"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("transaksi")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add("@noreg", _noreg)

        '        _mainConnection.Open()
        '        adapter.Fill(toReturn)

        '        If toReturn.Rows.Count > 0 Then
        '            If toReturn.Rows(0)("tpasien") Is System.DBNull.Value Then
        '                _tpasien = New SqlMoney(0)
        '            Else
        '                _tpasien = New SqlMoney(CType(toReturn.Rows(0)("tpasien"), Decimal))
        '            End If
        '            If toReturn.Rows(0)("tinstansi") Is System.DBNull.Value Then
        '                _tinstansi = New SqlMoney(0)
        '            Else
        '                _tinstansi = New SqlMoney(CType(toReturn.Rows(0)("tinstansi"), Decimal))
        '            End If
        '        End If

        '        Return toReturn
        '    Catch ex As Exception
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function

        'Public Function SelectForTotalTransaksiNonPlafon() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_dttransaksi_SelectForTotalTransaksiNonPlafon"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("transaksi")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add("@noreg", _noreg)

        '        _mainConnection.Open()
        '        adapter.Fill(toReturn)

        '        If toReturn.Rows.Count > 0 Then
        '            If toReturn.Rows(0)("tpasien") Is System.DBNull.Value Then
        '                _tpasien = New SqlMoney(0)
        '            Else
        '                _tpasien = New SqlMoney(CType(toReturn.Rows(0)("tpasien"), Decimal))
        '            End If
        '            If toReturn.Rows(0)("tinstansi") Is System.DBNull.Value Then
        '                _tinstansi = New SqlMoney(0)
        '            Else
        '                _tinstansi = New SqlMoney(CType(toReturn.Rows(0)("tinstansi"), Decimal))
        '            End If
        '        End If

        '        Return toReturn
        '    Catch ex As Exception
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function
#End Region

#Region " Other Select "
        'Public Function GetPaymentByNoreg() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_Registrasi_GetPaymentByNoreg"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("sprd_Registrasi_GetPaymentByNoreg")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.AddWithValue("@noreg", NoReg)

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        adapter.Fill(toReturn)

        '        Return toReturn
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function
#End Region

        'Public Function GetHistoryRekamMedis(ByVal NoRM As String) As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    cmdToExecute.CommandText = "sprs_RekammedisHistory"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("RekammedisHistory")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add("@NoRM", NoRM)

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        adapter.Fill(toReturn)

        '        Return toReturn
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function

        'Function UpdateExaminationStatus() As Boolean
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    cmdToExecute.CommandText = "dbo.[sprd_UpdateExaminationStatus]"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@noreg", _noreg))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@isExamined", _IsExamined))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@user", _UserExamination))

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        cmdToExecute.ExecuteNonQuery()
        '        Return True
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '    End Try
        'End Function

#Region "Class Property Declarations"
        'Public ReadOnly Property [NewNoReg]() As SqlString
        '    Get
        '        Dim retval As String = ""
        '        Try
        '            retval = Helper.GenerateTransactionNo(_mainConnection, AppConstant.TransactionCode.REGISTRASI_RAWAT_DARURAT, _tglshift)
        '        Catch ex As Exception
        '            ExceptionManager.Publish(ex)
        '        End Try
        '        Return retval
        '    End Get
        'End Property

        Public Property [ReviewOfSystemText]() As SqlString
            Get
                Return _reviewOfSystemText
            End Get
            Set(ByVal Value As SqlString)
                _reviewOfSystemText = Value
            End Set
        End Property

        Public Property JenisTarif() As SqlString
            Get
                Return _jenisTarif
            End Get
            Set(value As SqlString)
                _jenisTarif = value
            End Set
        End Property
        Public Property [NoReg]() As SqlString
            Get
                Return _noreg
            End Get
            Set(ByVal Value As SqlString)
                Dim noregTmp As SqlString = Value
                If noregTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("NoReg", "NoReg can't be NULL")
                End If
                _noreg = Value
            End Set
        End Property
        Public Property [Ruang]() As SqlString
            Get
                Return _ruang
            End Get
            Set(ByVal Value As SqlString)
                Dim ruangTmp As SqlString = Value
                If ruangTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("ruang", "ruang can't be NULL")
                End If
                _ruang = Value
            End Set
        End Property
        Public Property [KDRuang]() As SqlString
            Get
                Return _kdRuang
            End Get
            Set(ByVal Value As SqlString)
                Dim kdruangTmp As SqlString = Value
                If kdruangTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kdruang", "kdruang can't be NULL")
                End If
                _kdRuang = Value
            End Set
        End Property
        Public Property [Kelas]() As SqlString
            Get
                Return _kelas
            End Get
            Set(ByVal Value As SqlString)
                Dim kelasTmp As SqlString = Value
                If kelasTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kelas", "kelas can't be NULL")
                End If
                _kelas = Value
            End Set
        End Property
        Public Property [KdKelas]() As SqlString
            Get
                Return _kdkelas
            End Get
            Set(ByVal Value As SqlString)
                Dim kdkelasTmp As SqlString = Value
                If kdkelasTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kdkelas", "kdkelas can't be NULL")
                End If
                _kdkelas = Value
            End Set
        End Property
        Public Property [NoRM]() As SqlString
            Get
                Return _norm
            End Get
            Set(ByVal Value As SqlString)
                Dim normTmp As SqlString = Value
                If normTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Norm", "Norm can't be NULL")
                End If
                _norm = Value
            End Set
        End Property

        Public Property [jamdatang]() As SqlString
            Get
                Return _jamdatang
            End Get
            Set(ByVal Value As SqlString)
                Dim jamdatangTmp As SqlString = Value
                If jamdatangTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("jamdatang", "jamdatang can't be NULL")
                End If
                _jamdatang = Value
            End Set
        End Property

        Public Property [Catatan]() As SqlString
            Get
                Return _catatan
            End Get
            Set(ByVal Value As SqlString)
                Dim catatanTmp As SqlString = Value
                If catatanTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("catatan", "catatan can't be NULL")
                End If
                _catatan = Value
            End Set
        End Property

        Public Property [jamlayan]() As SqlString
            Get
                Return _jamlayan
            End Get
            Set(ByVal Value As SqlString)
                Dim jamlayanTmp As SqlString = Value
                If jamlayanTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("jamlayan", "jamlayan can't be NULL")
                End If
                _jamlayan = Value
            End Set
        End Property

        Public Property [jamkejadian]() As SqlString
            Get
                Return _jamkejadian
            End Get
            Set(ByVal Value As SqlString)
                Dim jamkejadianTmp As SqlString = Value
                If jamkejadianTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("jamkejadian", "jamkejadian can't be NULL")
                End If
                _jamkejadian = Value
            End Set
        End Property

        Public Property [kddokter]() As SqlString
            Get
                Return _kddokter
            End Get
            Set(ByVal Value As SqlString)
                Dim kddokterTmp As SqlString = Value
                If kddokterTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kddokter", "kddokter can't be NULL")
                End If
                _kddokter = Value
            End Set
        End Property

        Public Property [tdklanjut]() As SqlString
            Get
                Return _tdklanjut
            End Get
            Set(ByVal Value As SqlString)
                Dim tdklanjutTmp As SqlString = Value
                If tdklanjutTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("tdklanjut", "tdklanjut can't be NULL")
                End If
                _tdklanjut = Value
            End Set
        End Property

        Public Property [kdpengirim]() As SqlString
            Get
                Return _kdpengirim
            End Get
            Set(ByVal Value As SqlString)
                Dim kdpengirimTmp As SqlString = Value
                If kdpengirimTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kdpengirim", "kdpengirim can't be NULL")
                End If
                _kdpengirim = Value
            End Set
        End Property

        Public Property [nopengirim]() As SqlString
            Get
                Return _nopengirim
            End Get
            Set(ByVal Value As SqlString)
                Dim nopengirimTmp As SqlString = Value
                If nopengirimTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("nopengirim", "nopengirim can't be NULL")
                End If
                _nopengirim = Value
            End Set
        End Property

        Public Property [kdmasukrs]() As SqlString
            Get
                Return _kdmasukrs
            End Get
            Set(ByVal Value As SqlString)
                Dim kdmasukrsTmp As SqlString = Value
                If kdmasukrsTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kdmasukrs", "kdmasukrs can't be NULL")
                End If
                _kdmasukrs = Value
            End Set
        End Property

        Public Property [tpkejadian]() As SqlString
            Get
                Return _tpkejadian
            End Get
            Set(ByVal Value As SqlString)
                Dim tpkejadianTmp As SqlString = Value
                If tpkejadianTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("tpkejadian", "tpkejadian can't be NULL")
                End If
                _tpkejadian = Value
            End Set
        End Property

        Public Property [rwkejadian]() As SqlString
            Get
                Return _rwkejadian
            End Get
            Set(ByVal Value As SqlString)
                Dim rwkejadianTmp As SqlString = Value
                If rwkejadianTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("rwkejadian", "rwkejadian can't be NULL")
                End If
                _rwkejadian = Value
            End Set
        End Property
        Public Property [tinstansi]() As SqlMoney
            Get
                Return _tinstansi
            End Get
            Set(ByVal Value As SqlMoney)
                Dim tinstansiTmp As SqlMoney = Value
                If tinstansiTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("TInstansi", "Total Instansi can't be NULL")
                End If
                _tinstansi = Value
            End Set
        End Property
        Public Property [jnkasus]() As SqlString
            Get
                Return _jnkasus
            End Get
            Set(ByVal Value As SqlString)
                Dim jnkasusTmp As SqlString = Value
                If jnkasusTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("jnkasus", "jnkasus can't be NULL")
                End If
                _jnkasus = Value
            End Set
        End Property

        Public Property [kdkdndatang]() As SqlString
            Get
                Return _kdkdndatang
            End Get
            Set(ByVal Value As SqlString)
                Dim kdkdndatangTmp As SqlString = Value
                If kdkdndatangTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kdkdndatang", "kdkdndatang can't be NULL")
                End If
                _kdkdndatang = Value
            End Set
        End Property

        Public Property [KdKeadaanUmum]() As SqlString
            Get
                Return _KdKeadaanUmum
            End Get
            Set(ByVal Value As SqlString)
                _KdKeadaanUmum = Value
            End Set
        End Property

        Public Property [kdalasan]() As SqlString
            Get
                Return _kdalasan
            End Get
            Set(ByVal Value As SqlString)
                Dim kdalasanTmp As SqlString = Value
                If kdalasanTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kdalasan", "kdalasan can't be NULL")
                End If
                _kdalasan = Value
            End Set
        End Property

        Public Property [kddetail]() As SqlString
            Get
                Return _kddetail
            End Get
            Set(ByVal Value As SqlString)
                Dim kddetailTmp As SqlString = Value
                If kddetailTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kddetail", "kddetail can't be NULL")
                End If
                _kddetail = Value
            End Set
        End Property

        Public Property [kddeskripsi]() As SqlString
            Get
                Return _kddeskripsi
            End Get
            Set(ByVal Value As SqlString)
                Dim kddeskripsiTmp As SqlString = Value
                If kddeskripsiTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kddeskripsi", "kddeskripsi can't be NULL")
                End If
                _kddeskripsi = Value
            End Set
        End Property

        Public Property [Pgtsbl]() As SqlString
            Get
                Return _Pgtsbl
            End Get
            Set(ByVal Value As SqlString)
                Dim PgtsblTmp As SqlString = Value
                If PgtsblTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Pgtsbl", "Pgtsbl can't be NULL")
                End If
                _Pgtsbl = Value
            End Set
        End Property

        Public Property [Anamnesa]() As SqlString
            Get
                Return _Anamnesa
            End Get
            Set(ByVal Value As SqlString)
                Dim AnamnesaTmp As SqlString = Value
                If AnamnesaTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Anamnesa", "Anamnesa can't be NULL")
                End If
                _Anamnesa = Value
            End Set
        End Property

        Public Property [jnpasien]() As SqlString
            Get
                Return _jnpasien
            End Get
            Set(ByVal Value As SqlString)
                Dim jnpasienTmp As SqlString = Value
                If jnpasienTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("jnpasien", "jnpasien can't be NULL")
                End If
                _jnpasien = Value
            End Set
        End Property

        Public Property [triage]() As SqlString
            Get
                Return _triage
            End Get
            Set(ByVal Value As SqlString)
                Dim triageTmp As SqlString = Value
                If triageTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("triage", "triage can't be NULL")
                End If
                _triage = Value
            End Set
        End Property

        Public Property [kdjmbayar]() As SqlString
            Get
                Return _kdjmbayar
            End Get
            Set(ByVal Value As SqlString)
                Dim kdjmbayarTmp As SqlString = Value
                If kdjmbayarTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kdjmbayar", "kdjmbayar can't be NULL")
                End If
                _kdjmbayar = Value
            End Set
        End Property

        Public Property [kdperusahaan]() As SqlString
            Get
                Return _kdperusahaan
            End Get
            Set(ByVal Value As SqlString)
                Dim kdperusahaanTmp As SqlString = Value
                If kdperusahaanTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kdperusahaan", "kdperusahaan can't be NULL")
                End If
                _kdperusahaan = Value
            End Set
        End Property

        Public Property [kdplafon]() As SqlString
            Get
                Return _kdplafon
            End Get
            Set(ByVal Value As SqlString)
                Dim kdplafonTmp As SqlString = Value
                If kdplafonTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kdplafon", "kdplafon can't be NULL")
                End If
                _kdplafon = Value
            End Set
        End Property

        Public Property [plafon]() As SqlMoney
            Get
                Return _plafon
            End Get
            Set(ByVal Value As SqlMoney)
                Dim plafonTmp As SqlMoney = Value
                If plafonTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("plafon", "plafon can't be NULL")
                End If
                _plafon = Value
            End Set
        End Property

        Public Property [sisaplafon]() As SqlMoney
            Get
                Return _sisaplafon
            End Get
            Set(ByVal Value As SqlMoney)
                Dim sisaplafonTmp As SqlMoney = Value
                If sisaplafonTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("sisaplafon", "sisaplafon can't be NULL")
                End If
                _sisaplafon = Value
            End Set
        End Property

        Public Property [fplafonperhari]() As SqlBoolean
            Get
                Return _fplafonperhari
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim fplafonperhariTmp As SqlBoolean = Value
                If fplafonperhariTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("fplafonperhari", "fplafonperhari can't be NULL")
                End If
                _fplafonperhari = Value
            End Set
        End Property

        Public Property [cvl]() As SqlString
            Get
                Return _cvl
            End Get
            Set(ByVal Value As SqlString)
                Dim cvlTmp As SqlString = Value
                If cvlTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("cvl", "cvl can't be NULL")
                End If
                _cvl = Value
            End Set
        End Property

        Public Property [mata]() As SqlString
            Get
                Return _mata
            End Get
            Set(ByVal Value As SqlString)
                Dim mataTmp As SqlString = Value
                If mataTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("mata", "mata can't be NULL")
                End If
                _mata = Value
            End Set
        End Property

        Public Property [bicara]() As SqlString
            Get
                Return _bicara
            End Get
            Set(ByVal Value As SqlString)
                Dim bicaraTmp As SqlString = Value
                If bicaraTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("bicara", "bicara can't be NULL")
                End If
                _bicara = Value
            End Set
        End Property

        Public Property [gerak]() As SqlString
            Get
                Return _gerak
            End Get
            Set(ByVal Value As SqlString)
                Dim gerakTmp As SqlString = Value
                If gerakTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("gerak", "gerak can't be NULL")
                End If
                _gerak = Value
            End Set
        End Property

        Public Property [bscMata]() As SqlString
            Get
                Return _bscMata
            End Get
            Set(ByVal Value As SqlString)
                Dim bscMataTmp As SqlString = Value
                If bscMataTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("bscMata", "bscMata can't be NULL")
                End If
                _bscMata = Value
            End Set
        End Property

        Public Property [bscBicara]() As SqlString
            Get
                Return _bscBicara
            End Get
            Set(ByVal Value As SqlString)
                Dim bscBicaraTmp As SqlString = Value
                If bscBicaraTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("bscBicara", "bscBicara can't be NULL")
                End If
                _bscBicara = Value
            End Set
        End Property

        Public Property [bscGerak]() As SqlString
            Get
                Return _bscGerak
            End Get
            Set(ByVal Value As SqlString)
                Dim bscGerakTmp As SqlString = Value
                If bscGerakTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("bscgerak", "bscgerak can't be NULL")
                End If
                _bscGerak = Value
            End Set
        End Property

        Public Property [jlnnapas]() As SqlString
            Get
                Return _jlnnapas
            End Get
            Set(ByVal Value As SqlString)
                Dim jlnnapasTmp As SqlString = Value
                If jlnnapasTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("jlnnapas", "jlnnapas can't be NULL")
                End If
                _jlnnapas = Value
            End Set
        End Property

        Public Property [grknapas]() As SqlString
            Get
                Return _grknapas
            End Get
            Set(ByVal Value As SqlString)
                Dim grknapasTmp As SqlString = Value
                If grknapasTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("grknapas", "grknapas can't be NULL")
                End If
                _grknapas = Value
            End Set
        End Property

        Public Property [pernapasan]() As SqlString
            Get
                Return _pernapasan
            End Get
            Set(ByVal Value As SqlString)
                Dim pernapasanTmp As SqlString = Value
                If pernapasanTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("pernapasan", "pernapasan can't be NULL")
                End If
                _pernapasan = Value
            End Set
        End Property

        Public Property [bunyinapaskiri]() As SqlString
            Get
                Return _bunyinapaskiri
            End Get
            Set(ByVal Value As SqlString)
                Dim bunyinapaskiriTmp As SqlString = Value
                If bunyinapaskiriTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("bunyinapaskiri", "bunyinapaskiri can't be NULL")
                End If
                _bunyinapaskiri = Value
            End Set
        End Property

        Public Property [bunyinapaskanan]() As SqlString
            Get
                Return _bunyinapaskanan
            End Get
            Set(ByVal Value As SqlString)
                Dim bunyinapaskananTmp As SqlString = Value
                If bunyinapaskananTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("bunyinapaskanan", "bunyinapaskanan can't be NULL")
                End If
                _bunyinapaskanan = Value
            End Set
        End Property

        Public Property [kualitasnadi]() As SqlString
            Get
                Return _kualitasnadi
            End Get
            Set(ByVal Value As SqlString)
                Dim kualitasnadiTmp As SqlString = Value
                If kualitasnadiTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kualitasnadi", "kualitasnadi can't be NULL")
                End If
                _kualitasnadi = Value
            End Set
        End Property

        Public Property [kulit]() As SqlString
            Get
                Return _kulit
            End Get
            Set(ByVal Value As SqlString)
                Dim kulitTmp As SqlString = Value
                If kulitTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kulit", "kulit can't be NULL")
                End If
                _kulit = Value
            End Set
        End Property

        Public Property [bunyijantung]() As SqlString
            Get
                Return _bunyijantung
            End Get
            Set(ByVal Value As SqlString)
                Dim bunyijantungTmp As SqlString = Value
                If bunyijantungTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("bunyijantung", "bunyijantung can't be NULL")
                End If
                _bunyijantung = Value
            End Set
        End Property

        Public Property [dpupilkiri]() As SqlString
            Get
                Return _dpupilkiri
            End Get
            Set(ByVal Value As SqlString)
                Dim dpupilkiriTmp As SqlString = Value
                If dpupilkiriTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("dpupilkiri", "dpupilkiri can't be NULL")
                End If
                _dpupilkiri = Value
            End Set
        End Property

        Public Property [dpupilkanan]() As SqlString
            Get
                Return _dpupilkanan
            End Get
            Set(ByVal Value As SqlString)
                Dim dpupilkananTmp As SqlString = Value
                If dpupilkananTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("dpupilkanan", "dpupilkanan can't be NULL")
                End If
                _dpupilkanan = Value
            End Set
        End Property

        Public Property [rpupilkanan]() As SqlString
            Get
                Return _rpupilkanan
            End Get
            Set(ByVal Value As SqlString)
                Dim rpupilkananTmp As SqlString = Value
                If rpupilkananTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("rpupilkanan", "rpupilkanan can't be NULL")
                End If
                _rpupilkanan = Value
            End Set
        End Property

        Public Property [rpupilkiri]() As SqlString
            Get
                Return _rpupilkiri
            End Get
            Set(ByVal Value As SqlString)
                Dim rpupilkiriTmp As SqlString = Value
                If rpupilkiriTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("rpupilkiri", "rpupilkiri can't be NULL")
                End If
                _rpupilkiri = Value
            End Set
        End Property

        Public Property [kpllhr]() As SqlString
            Get
                Return _kpllhr
            End Get
            Set(ByVal Value As SqlString)
                Dim kpllhrTmp As SqlString = Value
                If kpllhrTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kpllhr", "kpllhr can't be NULL")
                End If
                _kpllhr = Value
            End Set
        End Property

        Public Property [toraks]() As SqlString
            Get
                Return _toraks
            End Get
            Set(ByVal Value As SqlString)
                Dim toraksTmp As SqlString = Value
                If toraksTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("toraks", "kpllhr can't be NULL")
                End If
                _toraks = Value
            End Set
        End Property

        Public Property [tdkterapi]() As SqlString
            Get
                Return _tdkterapi
            End Get
            Set(ByVal Value As SqlString)
                Dim tdkterapiTmp As SqlString = Value
                If tdkterapiTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("tdkterapi", "tdkterapi can't be NULL")
                End If
                _tdkterapi = Value
            End Set
        End Property

        Public Property [abdomen]() As SqlString
            Get
                Return _abdomen
            End Get
            Set(ByVal Value As SqlString)
                Dim abdomenTmp As SqlString = Value
                If abdomenTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("abdomen", "abdomen can't be NULL")
                End If
                _abdomen = Value
            End Set
        End Property

        Public Property [ekstremitas]() As SqlString
            Get
                Return _ekstremitas
            End Get
            Set(ByVal Value As SqlString)
                Dim ekstremitasTmp As SqlString = Value
                If ekstremitasTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("ekstremitas", "ekstremitas can't be NULL")
                End If
                _ekstremitas = Value
            End Set
        End Property

        Public Property [ketdiagnosa]() As SqlString
            Get
                Return _ketdiagnosa
            End Get
            Set(ByVal Value As SqlString)
                Dim ketdiagnosaTmp As SqlString = Value
                If ketdiagnosaTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("ketdiagnosa", "ketdiagnosa can't be NULL")
                End If
                _ketdiagnosa = Value
            End Set
        End Property

        Public Property [kddiagnosa]() As SqlString
            Get
                Return _kddiagnosa
            End Get
            Set(ByVal Value As SqlString)
                Dim kddiagnosaTmp As SqlString = Value
                If kddiagnosaTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kddiagnosa", "kddiagnosa can't be NULL")
                End If
                _kddiagnosa = Value
            End Set
        End Property

        Public Property [kdanestesi]() As SqlString
            Get
                Return _kdanestesi
            End Get
            Set(ByVal Value As SqlString)
                Dim kdanestesiTmp As SqlString = Value
                If kdanestesiTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kdanestesi", "kdanestesi can't be NULL")
                End If
                _kdanestesi = Value
            End Set
        End Property

        Public Property [jamdisposisi]() As SqlString
            Get
                Return _jamdisposisi
            End Get
            Set(ByVal Value As SqlString)
                Dim jamdisposisiTmp As SqlString = Value
                If jamdisposisiTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("jamdisposisi", "jamdisposisi can't be NULL")
                End If
                _jamdisposisi = Value
            End Set
        End Property

        Public Property [kdnkeluar]() As SqlString
            Get
                Return _kdnkeluar
            End Get
            Set(ByVal Value As SqlString)
                Dim kdnkeluarTmp As SqlString = Value
                If kdnkeluarTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kdnkeluar", "kdnkeluar can't be NULL")
                End If
                _kdnkeluar = Value
            End Set
        End Property

        Public Property [crkeluar]() As SqlString
            Get
                Return _crkeluar
            End Get
            Set(ByVal Value As SqlString)
                Dim crkeluarTmp As SqlString = Value
                If crkeluarTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("crkeluar", "crkeluar can't be NULL")
                End If
                _crkeluar = Value
            End Set
        End Property

        Public Property [dokterrawat]() As SqlString
            Get
                Return _dokterrawat
            End Get
            Set(ByVal Value As SqlString)
                Dim dokterrawatTmp As SqlString = Value
                If dokterrawatTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("dokterrawat", "dokterrawat can't be NULL")
                End If
                _dokterrawat = Value
            End Set
        End Property

        Public Property [usrupdater]() As SqlString
            Get
                Return _usrupdater
            End Get
            Set(ByVal Value As SqlString)
                Dim usrupdaterTmp As SqlString = Value
                If usrupdaterTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("usrupdater", "usrupdater can't be NULL")
                End If
                _usrupdater = Value
            End Set
        End Property

        Public Property [usrinsert]() As SqlString
            Get
                Return _usrinsert
            End Get
            Set(ByVal Value As SqlString)
                Dim usrinsertTmp As SqlString = Value
                If usrinsertTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("usrinsert", "usrinsert can't be NULL")
                End If
                _usrinsert = Value
            End Set
        End Property

        Public Property [usrbatal]() As SqlString
            Get
                Return _usrbatal
            End Get
            Set(ByVal Value As SqlString)
                Dim usrbatalTmp As SqlString = Value
                If usrbatalTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("usrbatal", "usrbatal can't be NULL")
                End If
                _usrbatal = Value
            End Set
        End Property



        Public Property [NoBayarPendaftaran]() As SqlString
            Get
                Return _NoBayarPendaftaran
            End Get
            Set(ByVal Value As SqlString)
                Dim NoBayarPendaftaranTmp As SqlString = Value
                If NoBayarPendaftaranTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("NoBayarPendaftaran", "NoBayarPendaftaran can't be NULL")
                End If
                _NoBayarPendaftaran = Value
            End Set
        End Property

        Public Property [nomember]() As SqlString
            Get
                Return _nomember
            End Get
            Set(ByVal Value As SqlString)
                Dim nomemberTmp As SqlString = Value
                If nomemberTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("nomember", "nomember can't be NULL")
                End If
                _nomember = Value
            End Set
        End Property

        Public Property [usrbiaya]() As SqlString
            Get
                Return _usrbiaya
            End Get
            Set(ByVal Value As SqlString)
                Dim usrbiayaTmp As SqlString = Value
                If usrbiayaTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("usrbiaya", "usrbiaya can't be NULL")
                End If
                _usrbiaya = Value
            End Set
        End Property

        Public Property [tgldatang]() As SqlDateTime
            Get
                Return _tgldatang
            End Get
            Set(ByVal Value As SqlDateTime)
                Dim tgldatangTmp As SqlDateTime = Value
                If tgldatangTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("tgldatang", "tgldatang can't be NULL")
                End If
                _tgldatang = Value
            End Set
        End Property

        Public Property [tgllayan]() As SqlDateTime
            Get
                Return _tgllayan
            End Get
            Set(ByVal Value As SqlDateTime)
                Dim tgllayanTmp As SqlDateTime = Value
                If tgllayanTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("tgllayan", "tgllayan can't be NULL")
                End If
                _tgllayan = Value
            End Set
        End Property

        Public Property [tglkejadian]() As SqlDateTime
            Get
                Return _tglkejadian
            End Get
            Set(ByVal Value As SqlDateTime)
                Dim tglkejadianTmp As SqlDateTime = Value
                If tglkejadianTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("tglkejadian", "tglkejadian can't be NULL")
                End If
                _tglkejadian = Value
            End Set
        End Property

        Public Property [tgldisposisi]() As SqlDateTime
            Get
                Return _tgldisposisi
            End Get
            Set(ByVal Value As SqlDateTime)
                Dim tgldisposisiTmp As SqlDateTime = Value
                If tgldisposisiTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("tgldisposisi", "tgldisposisi can't be NULL")
                End If
                _tgldisposisi = Value
            End Set
        End Property

        Public Property [tglupdater]() As SqlDateTime
            Get
                Return _tglupdater
            End Get
            Set(ByVal Value As SqlDateTime)
                Dim tglupdaterTmp As SqlDateTime = Value
                If tglupdaterTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("tglupdater", "tglupdater can't be NULL")
                End If
                _tglupdater = Value
            End Set
        End Property

        Public Property [tglinsert]() As SqlDateTime
            Get
                Return _tglinsert
            End Get
            Set(ByVal Value As SqlDateTime)
                Dim tglinsertTmp As SqlDateTime = Value
                If tglinsertTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("tglinsert", "tglinsert can't be NULL")
                End If
                _tglinsert = Value
            End Set
        End Property

        Public Property [tgltutup]() As SqlDateTime
            Get
                Return _tgltutup
            End Get
            Set(ByVal Value As SqlDateTime)
                'Dim tgltutupTmp As SqlDateTime = Value
                'If tgltutupTmp.IsNull Then
                '    Throw New ArgumentOutOfRangeException("tgltutup", "tgltutup can't be NULL")
                'End If
                _tgltutup = Value
            End Set
        End Property

        Public Property [tglbatal]() As SqlDateTime
            Get
                Return _tglbatal
            End Get
            Set(ByVal Value As SqlDateTime)
                Dim tglbatalTmp As SqlDateTime = Value
                If tglbatalTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("tglbatal", "tglbatal can't be NULL")
                End If
                _tglbatal = Value
            End Set
        End Property

        Public Property [tglbiaya]() As SqlDateTime
            Get
                Return _tglbiaya
            End Get
            Set(ByVal Value As SqlDateTime)
                Dim tglbiayaTmp As SqlDateTime = Value
                If tglbiayaTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("tglbiaya", "tglbiaya can't be NULL")
                End If
                _tglbiaya = Value
            End Set
        End Property

        Public Property [nadi]() As SqlDecimal
            Get
                Return _nadi
            End Get
            Set(ByVal Value As SqlDecimal)
                Dim nadiTmp As SqlDecimal = Value
                If nadiTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("nadi", "nadi can't be NULL")
                End If
                _nadi = Value
            End Set
        End Property

        Public Property [berat]() As SqlDecimal
            Get
                Return _berat
            End Get
            Set(ByVal Value As SqlDecimal)
                Dim beratTmp As SqlDecimal = Value
                If beratTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("berat", "berat can't be NULL")
                End If
                _berat = Value
            End Set
        End Property

        Public Property [suhu]() As SqlDecimal
            Get
                Return _suhu
            End Get
            Set(ByVal Value As SqlDecimal)
                Dim suhuTmp As SqlDecimal = Value
                If suhuTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("suhu", "suhu can't be NULL")
                End If
                _suhu = Value
            End Set
        End Property

        Public Property [suhuaxilla]() As SqlDecimal
            Get
                Return _suhuaxilla
            End Get
            Set(ByVal Value As SqlDecimal)
                Dim suhuaxillaTmp As SqlDecimal = Value
                If suhuaxillaTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("suhuaxilla", "suhuaxilla can't be NULL")
                End If
                _suhuaxilla = Value
            End Set
        End Property

        Public Property [suhurectal]() As SqlDecimal
            Get
                Return _suhurectal
            End Get
            Set(ByVal Value As SqlDecimal)
                Dim suhurectalTmp As SqlDecimal = Value
                If suhurectalTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("suhurectal", "suhu rectal can't be NULL")
                End If
                _suhurectal = Value
            End Set
        End Property
        Public Property [suhuAuritula]() As SqlDecimal
            Get
                Return _suhuAuritula
            End Get
            Set(ByVal Value As SqlDecimal)
                Dim suhuAuritulaTmp As SqlDecimal = Value
                If suhuAuritulaTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("suhuAuritula", "suhu auritula can't be NULL")
                End If
                _suhuAuritula = Value
            End Set
        End Property

        Public Property [systole]() As SqlDecimal
            Get
                Return _systole
            End Get
            Set(ByVal Value As SqlDecimal)
                Dim systoleTmp As SqlDecimal = Value
                If systoleTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("systole", "systole can't be NULL")
                End If
                _systole = Value
            End Set
        End Property

        Public Property [dyastole]() As SqlDecimal
            Get
                Return _dyastole
            End Get
            Set(ByVal Value As SqlDecimal)
                Dim dyastoleTmp As SqlDecimal = Value
                If dyastoleTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("dyastole", "dyastole can't be NULL")
                End If
                _dyastole = Value
            End Set
        End Property

        Public Property [jmlnapas]() As SqlDecimal
            Get
                Return _jmlnapas
            End Get
            Set(ByVal Value As SqlDecimal)
                Dim jmlnapasTmp As SqlDecimal = Value
                If jmlnapasTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("jmlnapas", "jmlnapas can't be NULL")
                End If
                _jmlnapas = Value
            End Set
        End Property

        Public Property [voldarah]() As SqlDecimal
            Get
                Return _voldarah
            End Get
            Set(ByVal Value As SqlDecimal)
                Dim voldarahTmp As SqlDecimal = Value
                If voldarahTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("voldarah", "voldarah can't be NULL")
                End If
                _voldarah = Value
            End Set
        End Property

        Public Property [retraksidada]() As SqlBoolean
            Get
                Return _retraksidada
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim retraksidadaTmp As SqlBoolean = Value
                If retraksidadaTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("retraksidada", "retraksidada can't be NULL")
                End If
                _retraksidada = Value
            End Set
        End Property

        Public Property [chkdarah]() As SqlBoolean
            Get
                Return _chkdarah
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim chkdarahTmp As SqlBoolean = Value
                If chkdarahTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("chkdarah", "chkdarah can't be NULL")
                End If
                _chkdarah = Value
            End Set
        End Property

        Public Property [chkAsma]() As SqlBoolean
            Get
                Return _chkAsma
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim chkAsmaTmp As SqlBoolean = Value
                If chkAsmaTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("chkAsma", "chkAsma can't be NULL")
                End If
                _chkAsma = Value
            End Set
        End Property

        Public Property [chkDiabetes]() As SqlBoolean
            Get
                Return _chkDiabetes
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim chkDiabetesTmp As SqlBoolean = Value
                If chkDiabetesTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("chkDiabetes", "chkDiabetes can't be NULL")
                End If
                _chkDiabetes = Value
            End Set
        End Property

        Public Property [chkHipertensi]() As SqlBoolean
            Get
                Return _chkHipertensi
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim chkHipertensiTmp As SqlBoolean = Value
                If chkHipertensiTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("chkHipertensi", "chkHipertensi can't be NULL")
                End If
                _chkHipertensi = Value
            End Set
        End Property

        Public Property [chkSakitJantung]() As SqlBoolean
            Get
                Return _chkSakitJantung
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim chkSakitJantungTmp As SqlBoolean = Value
                If chkSakitJantungTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("chkSakitJantung", "chkSakitJantung can't be NULL")
                End If
                _chkSakitJantung = Value
            End Set
        End Property

        Public Property [chkStroke]() As SqlBoolean
            Get
                Return _chkStroke
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim chkStrokeTmp As SqlBoolean = Value
                If chkStrokeTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("chkStroke", "chkStroke can't be NULL")
                End If
                _chkStroke = Value
            End Set
        End Property

        Public Property [chkSakitGinjal]() As SqlBoolean
            Get
                Return _chkSakitGinjal
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim chkSakitGinjalTmp As SqlBoolean = Value
                If chkSakitGinjalTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("chkSakitGinjal", "chkSakitGinjal can't be NULL")
                End If
                _chkSakitGinjal = Value
            End Set
        End Property

        Public Property [chkSakitLever]() As SqlBoolean
            Get
                Return _chkSakitLever
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim chkSakitLeverTmp As SqlBoolean = Value
                If chkSakitLeverTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("chkSakitLever", "chkSakitLever can't be NULL")
                End If
                _chkSakitLever = Value
            End Set
        End Property

        Public Property [chkRiwayatOperasi]() As SqlBoolean
            Get
                Return _chkRiwayatOperasi
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim chkRiwayatOperasiTmp As SqlBoolean = Value
                If chkRiwayatOperasiTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("chkRiwayatOperasi", "chkRiwayatOperasi can't be NULL")
                End If
                _chkRiwayatOperasi = Value
            End Set
        End Property

        Public Property [chkGigiPalsu]() As SqlBoolean
            Get
                Return _chkGigiPalsu
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim chkGigiPalsuTmp As SqlBoolean = Value
                If chkGigiPalsuTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("chkGigiPalsu", "chkGigiPalsu can't be NULL")
                End If
                _chkGigiPalsu = Value
            End Set
        End Property

        Public Property [chkProtesis]() As SqlBoolean
            Get
                Return _chkProtesis
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim chkProtesisTmp As SqlBoolean = Value
                If chkProtesisTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("chkProtesis", "chkProtesis can't be NULL")
                End If
                _chkProtesis = Value
            End Set
        End Property

        Public Property [chkLensaKontak]() As SqlBoolean
            Get
                Return _chkLensaKontak
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim chkLensaKontakTmp As SqlBoolean = Value
                If chkLensaKontakTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("chkLensaKontak", "chkLensaKontak can't be NULL")
                End If
                _chkLensaKontak = Value
            End Set
        End Property

        Public Property [txtJnsOperasi]() As SqlString
            Get
                Return _txtJnsOperasi
            End Get
            Set(ByVal Value As SqlString)
                Dim txtJnsOperasiTmp As SqlString = Value
                If txtJnsOperasiTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("txtJnsOperasi", "txtJnsOperasi can't be NULL")
                End If
                _txtJnsOperasi = Value
            End Set
        End Property

        Public Property [txtJamMknAkhir]() As SqlString
            Get
                Return _txtJamMknAkhir
            End Get
            Set(ByVal Value As SqlString)
                Dim txtJamMknAkhirTmp As SqlString = Value
                If txtJamMknAkhirTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("txtJamMknAkhir", "txtJamMknAkhir can't be NULL")
                End If
                _txtJamMknAkhir = Value
            End Set
        End Property

        Public Property [Tinggi]() As SqlDecimal
            Get
                Return _Tinggi
            End Get
            Set(ByVal Value As SqlDecimal)
                Dim TinggiTmp As SqlDecimal = Value
                If TinggiTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Tinggi", "Tinggi can't be NULL")
                End If
                _Tinggi = Value
            End Set
        End Property

        Public Property [Alergi]() As SqlBoolean
            Get
                Return _chkAlergi
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim chkAlergiTmp As SqlBoolean = Value
                If chkAlergiTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("chkAlergi", "chkAlergi can't be NULL")
                End If
                _chkAlergi = Value
            End Set
        End Property

        Public Property [PerintahSederhana]() As SqlBoolean
            Get
                Return _chkPerintahSederhana
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim chkPerintahSederhanaTmp As SqlBoolean = Value
                If chkPerintahSederhanaTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("chkPerintahSederhana", "chkPerintahSederhana can't be NULL")
                End If
                _chkPerintahSederhana = Value
            End Set
        End Property

        Public Property [Bernapas]() As SqlBoolean
            Get
                Return _chkBernapas
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim chkBernapasTmp As SqlBoolean = Value
                If chkBernapasTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("chkBernapas", "chkBernapas can't be NULL")
                End If
                _chkBernapas = Value
            End Set
        End Property

        Public Property [Spo2]() As SqlString
            Get
                Return _Spo2
            End Get
            Set(ByVal Value As SqlString)
                Dim Spo2Tmp As SqlString = Value
                If Spo2Tmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Spo2", "Spo2 can't be NULL")
                End If
                _Spo2 = Value
            End Set
        End Property

        Public Property [GDS]() As SqlString
            Get
                Return _GDS
            End Get
            Set(ByVal Value As SqlString)
                Dim GDSTmp As SqlString = Value
                If GDSTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("GDS", "GDS can't be NULL")
                End If
                _GDS = Value
            End Set
        End Property

        Public Property [IsiKuku]() As SqlString
            Get
                Return _IsiKuku
            End Get
            Set(ByVal Value As SqlString)
                Dim IsiKukuTmp As SqlString = Value
                If IsiKukuTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("IsiKuku", "IsiKuku can't be NULL")
                End If
                _IsiKuku = Value
            End Set
        End Property

        Public Property [CatatanPerkembangan]() As SqlString
            Get
                Return _CatatanPerkembangan
            End Get
            Set(ByVal Value As SqlString)
                Dim CatatanPerkembanganTmp As SqlString = Value
                If CatatanPerkembanganTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("CatatanPerkembangan", "CatatanPerkembangan can't be NULL")
                End If
                _CatatanPerkembangan = Value
            End Set
        End Property

        Public Property [tutup]() As SqlBoolean
            Get
                Return _tutup
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim tutupTmp As SqlBoolean = Value
                If tutupTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("tutup", "tutup can't be NULL")
                End If
                _tutup = Value
            End Set
        End Property

        Public Property [batal]() As SqlBoolean
            Get
                Return _batal
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim batalTmp As SqlBoolean = Value
                If batalTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("batal", "batal can't be NULL")
                End If
                _batal = Value
            End Set
        End Property

        Public Property [biayapendaftaran]() As SqlBoolean
            Get
                Return _biayapendaftaran
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim biayapendaftaranTmp As SqlBoolean = Value
                If biayapendaftaranTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("biayapendaftaran", "biayapendaftaran can't be NULL")
                End If
                _biayapendaftaran = Value
            End Set
        End Property

        Public Property [KunjunganBaru]() As SqlBoolean
            Get
                Return _kunjunganbaru
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim kunjunganbaruTmp As SqlBoolean = Value
                If kunjunganbaruTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kunjunganbaru", "kunjunganbaru can't be NULL")
                End If
                _kunjunganbaru = Value
            End Set
        End Property

        Public Property [Kartu]() As SqlBoolean
            Get
                Return _kartu
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim kartuTmp As SqlBoolean = Value
                If kartuTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kartu", "kartu can't be NULL")
                End If
                _kartu = Value
            End Set
        End Property

        Public Property [KdIcd]() As SqlString
            Get
                Return _kdIcd
            End Get
            Set(ByVal Value As SqlString)
                Dim kdIcdTmp As SqlString = Value
                If kdIcdTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kdicd", "KdIcd can't be NULL")
                End If
                _kdIcd = Value
            End Set
        End Property

        Public Property [KdDTD]() As SqlString
            Get
                Return _kddtd
            End Get
            Set(ByVal Value As SqlString)
                Dim kddtdTmp As SqlString = Value
                If kddtdTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kddtd", "KdDTD can't be NULL")
                End If
                _kddtd = Value
            End Set
        End Property

        Public Property [KdIcdkc]() As SqlString
            Get
                Return _kdIcdkc
            End Get
            Set(ByVal Value As SqlString)
                Dim kdicdkcTmp As SqlString = Value
                If kdicdkcTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kdicdkc", "KdIcd kecelakaan can't be NULL")
                End If
                _kdIcdkc = Value
            End Set
        End Property

        Public Property [Umurtahun]() As SqlInt16
            Get
                Return _umurtahun
            End Get
            Set(ByVal Value As SqlInt16)
                _umurtahun = Value
            End Set
        End Property

        Public Property [Umurbulan]() As SqlInt16
            Get
                Return _umurbulan
            End Get
            Set(ByVal Value As SqlInt16)
                _umurbulan = Value
            End Set
        End Property

        Public Property [Umurhari]() As SqlInt16
            Get
                Return _umurhari
            End Get
            Set(ByVal Value As SqlInt16)
                _umurhari = Value
            End Set
        End Property

        Public Property [KetInstansi]() As SqlString
            Get
                Return _ketinstansi
            End Get
            Set(ByVal Value As SqlString)
                _ketinstansi = Value
            End Set
        End Property

        Public Property [Shift]() As SqlString
            Get
                Return _shift
            End Get
            Set(ByVal Value As SqlString)
                _shift = Value
            End Set
        End Property

        Public Property [TglShift]() As SqlDateTime
            Get
                Return _tglshift
            End Get
            Set(ByVal Value As SqlDateTime)
                _tglshift = Value
            End Set
        End Property

        Public Property [NoRegRI]() As SqlString
            Get
                Return _noregri
            End Get
            Set(ByVal Value As SqlString)
                _noregri = Value
            End Set
        End Property

        Public Property [NoTT]() As SqlString
            Get
                Return _nott
            End Get
            Set(ByVal Value As SqlString)
                _nott = Value
            End Set
        End Property

        Public Property [tpasien]() As SqlMoney
            Get
                Return _tpasien
            End Get
            Set(ByVal Value As SqlMoney)
                _tpasien = Value
            End Set
        End Property
        Public Property [PrnthSdhnDT]() As SqlString
            Get
                Return _PrnthSdhnDT
            End Get
            Set(ByVal Value As SqlString)
                _PrnthSdhnDT = Value
            End Set
        End Property

        Public Property [IsServiced]() As SqlBoolean
            Get
                Return _IsServiced
            End Get
            Set(ByVal Value As SqlBoolean)
                _IsServiced = Value
            End Set
        End Property

        Public Property [RR]() As SqlString
            Get
                Return _RR
            End Get
            Set(ByVal Value As SqlString)
                _RR = Value
            End Set
        End Property

        Public Property [NmDokter]() As SqlString
            Get
                Return _NmDokter
            End Get
            Set(ByVal Value As SqlString)
                _NmDokter = Value
            End Set
        End Property

        Public Property [Nama]() As SqlString
            Get
                Return _Nama
            End Get
            Set(ByVal Value As SqlString)
                _Nama = Value
            End Set
        End Property

        Public Property [Marga]() As SqlString
            Get
                Return _Marga
            End Get
            Set(ByVal Value As SqlString)
                _Marga = Value
            End Set
        End Property

        Public Property [KdSeks]() As SqlString
            Get
                Return _kdseks
            End Get
            Set(ByVal Value As SqlString)
                _kdseks = Value
            End Set
        End Property

        Public Property [pasienbaru]() As SqlBoolean
            Get
                Return _pasienbaru
            End Get
            Set(ByVal Value As SqlBoolean)
                _pasienbaru = Value
            End Set
        End Property

        Public Property [IsExamined]() As SqlBoolean
            Get
                Return _IsExamined
            End Get
            Set(ByVal Value As SqlBoolean)
                _IsExamined = Value
            End Set
        End Property

        Public Property DiskonTagihan() As SqlMoney
            Get
                Return _diskonTagihan
            End Get
            Set(ByVal Value As SqlMoney)
                _diskonTagihan = Value
            End Set
        End Property
        Public Property kdterminal() As SqlString
            Get
                Return _kdterminal
            End Get
            Set(ByVal Value As SqlString)
                _kdterminal = Value
            End Set
        End Property

        Public Property LastExaminationDate() As DateTime
            Get
                Return _LastExaminationDate
            End Get
            Set(ByVal Value As DateTime)
                _LastExaminationDate = Value
            End Set
        End Property

        Public Property UserExamination() As SqlString
            Get
                Return _UserExamination
            End Get
            Set(ByVal Value As SqlString)
                _UserExamination = Value
            End Set
        End Property

        Public Property App() As SqlString
            Get
                Return _App
            End Get
            Set(ByVal Value As SqlString)
                _App = Value
            End Set
        End Property
        Public Property [tgllahir]() As SqlDateTime
            Get
                Return _tgllahir
            End Get
            Set(ByVal Value As SqlDateTime)
                Dim tgllahirTmp As SqlDateTime = Value
                If tgllahirTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("tgllahir", "tgllahir can't be NULL")
                End If
                _tgllahir = Value
            End Set
        End Property
#End Region



    End Class
End Namespace