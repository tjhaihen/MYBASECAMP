Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class Pasien
        Inherits BRInteractionBase

#Region " Class Member Declarations "

        Private _member, _blacklist, _aktif, _pse, _pasien, _statfilerj, _statfileri, _statfilerd As SqlBoolean
        Private _nopasport, _kdinstansi, _nomember, _kdwarganegara, _kdpekerjaan, _alergi, _StatusPasien, _
                _noktpsim, _catatan, _kantorNoTelp, _kantorKota, _email, _golongandarah, _namaKantor, _
                _updater, _alamatKantor2, _alamatKantor1, _kdpendidikan, _rw, _rt, _nohp, _notelepon, _
                _jalan, _tmplahir, _kdseks, _gang, _kdpropinsi, _kdpos, _kdstkawin, _kdagama, _kota, _
                _marga, _norm, _title, _kdrakstatusRJ, _kdrakstatusRI, _kdrakstatusRD, _kdsuku, _
                _namaayah, _kdpekerjaanayah, _namaibu, _kdpekerjaanibu, _nofoto, _noPesertaBPJS As SqlString
        Private _tgllahir, _lupdate, _tglexpired, _tglakhkunjunganRJ, _tglakhrawatRI, _tglrawatakhir, _tglakhkunjunganRD As SqlDateTime
        Private _kunjunganRJke, _rawatRIke, _kunjunganRDke, _tb, _bb As SqlDecimal
        Private _nama, _huruf, _oldnorm, _usrupdate, _strtgllahir As SqlString
        Private _umurhari, _umurtahun, _umurbulan, _umurayah, _umuribu, _jumlahrawat As SqlInt16
        Private _jmlKunjunganRiRjRd As SqlDouble
        Private _descpekerjaan, _descpekerjaanayah, _descpekerjaanibu As SqlString
        Private _Photo, _NmPhoto, _NmFile As SqlString

        Private _NmEContact, _AlmtEContact, _HubEContact, _TelpEContact, _gelar As SqlString
        Private _alasan As String

#End Region


        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

#Region "Select"
        Public Overrides Function SelectOne(Optional ByVal recStatus As QISRecStatus = QISRecStatus.CurrentRecord) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Select Case recStatus
                Case QISRecStatus.CurrentRecord
                    cmdToExecute.CommandText = "sprd_Pasien_SelectOne"
                Case QISRecStatus.NextRecord
                    cmdToExecute.CommandText = "sprd_Pasien_SelectOneNext"
                Case QISRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "sprd_Pasien_SelectOnePrev"
            End Select
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("Pasien")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add(New SqlParameter("@norm", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _norm))

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)
                If toReturn.Rows.Count > 0 Then
                    _norm = New SqlString(CType(toReturn.Rows(0)("norm"), String))
                    If toReturn.Rows(0)("title") Is System.DBNull.Value Then
                        _title = New SqlString(String.Empty)
                    Else
                        _title = New SqlString(CType(toReturn.Rows(0)("title"), String))
                    End If
                    _nama = New SqlString(CType(toReturn.Rows(0)("nama"), String))
                    If toReturn.Rows(0)("marga") Is System.DBNull.Value Then
                        _marga = New SqlString(String.Empty)
                    Else
                        _marga = New SqlString(CType(toReturn.Rows(0)("marga"), String))
                    End If
                    _kdseks = New SqlString(CType(toReturn.Rows(0)("kdseks"), String))
                    If toReturn.Rows(0)("tmplahir") Is System.DBNull.Value Then
                        _tmplahir = New SqlString(String.Empty)
                    Else
                        _tmplahir = New SqlString(CType(toReturn.Rows(0)("tmplahir"), String))
                    End If
                    If toReturn.Rows(0)("tgllahir") Is System.DBNull.Value Then
                        _tgllahir = New SqlDateTime(String.Empty)
                    Else
                        _tgllahir = New SqlDateTime(CType(toReturn.Rows(0)("tgllahir"), Date))
                    End If
                    If toReturn.Rows(0)("umurtahun") Is System.DBNull.Value Then
                        _umurtahun = SqlInt16.Null
                    Else
                        _umurtahun = New SqlInt16(CType(toReturn.Rows(0)("umurtahun"), Short))
                    End If
                    If toReturn.Rows(0)("umurbulan") Is System.DBNull.Value Then
                        _umurbulan = SqlInt16.Null
                    Else
                        _umurbulan = New SqlInt16(CType(toReturn.Rows(0)("umurbulan"), Short))
                    End If
                    If toReturn.Rows(0)("umurhari") Is System.DBNull.Value Then
                        _umurhari = SqlInt16.Null
                    Else
                        _umurhari = New SqlInt16(CType(toReturn.Rows(0)("umurhari"), Short))
                    End If
                    If toReturn.Rows(0)("jalan") Is System.DBNull.Value Then
                        _jalan = New SqlString(String.Empty)
                    Else
                        _jalan = New SqlString(CType(toReturn.Rows(0)("jalan"), String))
                    End If
                    If toReturn.Rows(0)("gang") Is System.DBNull.Value Then
                        _gang = New SqlString(String.Empty)
                    Else
                        _gang = New SqlString(CType(toReturn.Rows(0)("gang"), String))
                    End If
                    If toReturn.Rows(0)("rt") Is System.DBNull.Value Then
                        _rt = New SqlString(String.Empty)
                    Else
                        _rt = New SqlString(CType(toReturn.Rows(0)("rt"), String))
                    End If
                    If toReturn.Rows(0)("rw") Is System.DBNull.Value Then
                        _rw = New SqlString(String.Empty)
                    Else
                        _rw = New SqlString(CType(toReturn.Rows(0)("rw"), String))
                    End If
                    If toReturn.Rows(0)("notelepon") Is System.DBNull.Value Then
                        _notelepon = New SqlString(String.Empty)
                    Else
                        _notelepon = New SqlString(CType(toReturn.Rows(0)("notelepon"), String))
                    End If
                    If toReturn.Rows(0)("nohp") Is System.DBNull.Value Then
                        _nohp = New SqlString(String.Empty)
                    Else
                        _nohp = New SqlString(CType(toReturn.Rows(0)("nohp"), String))
                    End If
                    If toReturn.Rows(0)("kota") Is System.DBNull.Value Then
                        _kota = New SqlString(String.Empty)
                    Else
                        _kota = New SqlString(CType(toReturn.Rows(0)("kota"), String))
                    End If
                    If toReturn.Rows(0)("kdpos") Is System.DBNull.Value Then
                        _kdpos = New SqlString(String.Empty)
                    Else
                        _kdpos = New SqlString(CType(toReturn.Rows(0)("kdpos"), String))
                    End If
                    If toReturn.Rows(0)("kdpropinsi") Is System.DBNull.Value Then
                        _kdpropinsi = New SqlString(String.Empty)
                    Else
                        _kdpropinsi = New SqlString(CType(toReturn.Rows(0)("kdpropinsi"), String))
                    End If
                    If toReturn.Rows(0)("kdagama") Is System.DBNull.Value Then
                        _kdagama = New SqlString(String.Empty)
                    Else
                        _kdagama = New SqlString(CType(toReturn.Rows(0)("kdagama"), String))
                    End If
                    If toReturn.Rows(0)("kdstkawin") Is System.DBNull.Value Then
                        _kdstkawin = New SqlString(String.Empty)
                    Else
                        _kdstkawin = New SqlString(CType(toReturn.Rows(0)("kdstkawin"), String))
                    End If
                    If toReturn.Rows(0)("kdpendidikan") Is System.DBNull.Value Then
                        _kdpendidikan = New SqlString(String.Empty)
                    Else
                        _kdpendidikan = New SqlString(CType(toReturn.Rows(0)("kdpendidikan"), String))
                    End If
                    If toReturn.Rows(0)("kdpekerjaan") Is System.DBNull.Value Then
                        _kdpekerjaan = New SqlString(String.Empty)
                    Else
                        _kdpekerjaan = New SqlString(CType(toReturn.Rows(0)("kdpekerjaan"), String))
                    End If
                    If toReturn.Rows(0)("kdwarganegara") Is System.DBNull.Value Then
                        _kdwarganegara = New SqlString(String.Empty)
                    Else
                        _kdwarganegara = New SqlString(CType(toReturn.Rows(0)("kdwarganegara"), String))
                    End If
                    If toReturn.Rows(0)("alergi") Is System.DBNull.Value Then
                        _alergi = New SqlString(String.Empty)
                    Else
                        _alergi = New SqlString(CType(toReturn.Rows(0)("alergi"), String))
                    End If
                    If toReturn.Rows(0)("Status") Is System.DBNull.Value Then
                        _StatusPasien = New SqlString(String.Empty)
                    Else
                        _StatusPasien = New SqlString(CType(toReturn.Rows(0)("Status"), String))
                    End If
                    If toReturn.Rows(0)("catatan") Is System.DBNull.Value Then
                        _catatan = New SqlString(String.Empty)
                    Else
                        _catatan = New SqlString(CType(toReturn.Rows(0)("catatan"), String))
                    End If
                    If toReturn.Rows(0)("kunjunganRJke") Is System.DBNull.Value Then
                        _kunjunganRJke = New SqlDecimal(0D)
                    Else
                        _kunjunganRJke = New SqlDecimal(CType(toReturn.Rows(0)("kunjunganRJke"), Decimal))
                    End If
                    If toReturn.Rows(0)("tglakhkunjunganRJ") Is System.DBNull.Value Then
                        _tglakhkunjunganRJ = SqlDateTime.Null
                    Else
                        _tglakhkunjunganRJ = New SqlDateTime(CType(toReturn.Rows(0)("tglakhkunjunganRJ"), Date))
                    End If
                    If toReturn.Rows(0)("noktpsim") Is System.DBNull.Value Then
                        _noktpsim = New SqlString(String.Empty)
                    Else
                        _noktpsim = New SqlString(CType(toReturn.Rows(0)("noktpsim"), String))
                    End If
                    If toReturn.Rows(0)("tglexpired") Is System.DBNull.Value Then
                        _tglexpired = SqlDateTime.Null
                    Else
                        _tglexpired = New SqlDateTime(CType(toReturn.Rows(0)("tglexpired"), Date))
                    End If
                    If toReturn.Rows(0)("nopasport") Is System.DBNull.Value Then
                        _nopasport = New SqlString(String.Empty)
                    Else
                        _nopasport = New SqlString(CType(toReturn.Rows(0)("nopasport"), String))
                    End If
                    _aktif = New SqlBoolean(CType(toReturn.Rows(0)("aktif"), Boolean))
                    If toReturn.Rows(0)("nomember") Is System.DBNull.Value Then
                        _nomember = New SqlString(String.Empty)
                    Else
                        _nomember = New SqlString(CType(toReturn.Rows(0)("nomember"), String))
                    End If
                    If toReturn.Rows(0)("blacklist") Is System.DBNull.Value Then
                        _blacklist = New SqlBoolean(False)
                    Else
                        _blacklist = New SqlBoolean(CType(toReturn.Rows(0)("blacklist"), Boolean))
                    End If
                    If toReturn.Rows(0)("pse") Is System.DBNull.Value Then
                        _pse = New SqlBoolean(False)
                    Else
                        _pse = New SqlBoolean(CType(toReturn.Rows(0)("pse"), Boolean))
                    End If
                    If toReturn.Rows(0)("lupdate") Is System.DBNull.Value Then
                        _lupdate = SqlDateTime.Null
                    Else
                        _lupdate = New SqlDateTime(CType(toReturn.Rows(0)("lupdate"), Date))
                    End If
                    If toReturn.Rows(0)("updater") Is System.DBNull.Value Then
                        _updater = New SqlString(String.Empty)
                    Else
                        _updater = New SqlString(CType(toReturn.Rows(0)("updater"), String))
                    End If
                    If toReturn.Rows(0)("Member") Is System.DBNull.Value Then
                        _member = New SqlBoolean(False)
                    Else
                        _member = New SqlBoolean(CType(toReturn.Rows(0)("Member"), Boolean))
                    End If
                    If toReturn.Rows(0)("NamaKantor") Is System.DBNull.Value Then
                        _namaKantor = New SqlString(String.Empty)
                    Else
                        _namaKantor = New SqlString(CType(toReturn.Rows(0)("NamaKantor"), String))
                    End If
                    If toReturn.Rows(0)("AlamatKantor1") Is System.DBNull.Value Then
                        _alamatKantor1 = New SqlString(String.Empty)
                    Else
                        _alamatKantor1 = New SqlString(CType(toReturn.Rows(0)("AlamatKantor1"), String))
                    End If
                    If toReturn.Rows(0)("AlamatKantor2") Is System.DBNull.Value Then
                        _alamatKantor2 = New SqlString(String.Empty)
                    Else
                        _alamatKantor2 = New SqlString(CType(toReturn.Rows(0)("AlamatKantor2"), String))
                    End If
                    If toReturn.Rows(0)("KantorKota") Is System.DBNull.Value Then
                        _kantorKota = New SqlString(String.Empty)
                    Else
                        _kantorKota = New SqlString(CType(toReturn.Rows(0)("KantorKota"), String))
                    End If
                    If toReturn.Rows(0)("KantorNoTelp") Is System.DBNull.Value Then
                        _kantorNoTelp = New SqlString(String.Empty)
                    Else
                        _kantorNoTelp = New SqlString(CType(toReturn.Rows(0)("KantorNoTelp"), String))
                    End If
                    If toReturn.Rows(0)("golongandarah") Is System.DBNull.Value Then
                        _golongandarah = New SqlString(String.Empty)
                    Else
                        _golongandarah = New SqlString(CType(toReturn.Rows(0)("golongandarah"), String))
                    End If
                    If toReturn.Rows(0)("email") Is System.DBNull.Value Then
                        _email = New SqlString(String.Empty)
                    Else
                        _email = New SqlString(CType(toReturn.Rows(0)("email"), String))
                    End If
                    If toReturn.Rows(0)("pasien") Is System.DBNull.Value Then
                        _pasien = New SqlBoolean(False)
                    Else
                        _pasien = New SqlBoolean(CType(toReturn.Rows(0)("pasien"), Boolean))
                    End If
                    If toReturn.Rows(0)("statfileRJ") Is System.DBNull.Value Then
                        _statfilerj = New SqlBoolean(False)
                    Else
                        _statfilerj = New SqlBoolean(CType(toReturn.Rows(0)("statfileRJ"), Boolean))
                    End If
                    If toReturn.Rows(0)("statfileRI") Is System.DBNull.Value Then
                        _statfileri = New SqlBoolean(False)
                    Else
                        _statfileri = New SqlBoolean(CType(toReturn.Rows(0)("statfileRI"), Boolean))
                    End If
                    If toReturn.Rows(0)("statfileRD") Is System.DBNull.Value Then
                        _statfilerd = New SqlBoolean(False)
                    Else
                        _statfilerd = New SqlBoolean(CType(toReturn.Rows(0)("statfileRD"), Boolean))
                    End If
                    If toReturn.Rows(0)("kdinstansi") Is System.DBNull.Value Then
                        _kdinstansi = New SqlString(String.Empty)
                    Else
                        _kdinstansi = New SqlString(CType(toReturn.Rows(0)("kdinstansi"), String))
                    End If
                    If toReturn.Rows(0)("rawatRIke") Is System.DBNull.Value Then
                        _rawatRIke = New SqlDecimal(0D)
                    Else
                        _rawatRIke = New SqlDecimal(CType(toReturn.Rows(0)("rawatRIke"), Decimal))
                    End If
                    If toReturn.Rows(0)("tglakhrawatRI") Is System.DBNull.Value Then
                        _tglakhrawatRI = SqlDateTime.Null
                    Else
                        _tglakhrawatRI = New SqlDateTime(CType(toReturn.Rows(0)("tglakhrawatRI"), Date))
                    End If
                    If toReturn.Rows(0)("kdrakstatusRJ") Is System.DBNull.Value Then
                        _kdrakstatusRJ = New SqlString(String.Empty)
                    Else
                        _kdrakstatusRJ = New SqlString(CType(toReturn.Rows(0)("kdrakstatusRJ"), String))
                    End If
                    If toReturn.Rows(0)("kdrakstatusRI") Is System.DBNull.Value Then
                        _kdrakstatusRI = New SqlString("01")
                    Else
                        _kdrakstatusRI = New SqlString(CType(toReturn.Rows(0)("kdrakstatusRI"), String))
                    End If
                    If toReturn.Rows(0)("kdrakstatusRD") Is System.DBNull.Value Then
                        _kdrakstatusRD = New SqlString("01")
                    Else
                        _kdrakstatusRD = New SqlString(CType(toReturn.Rows(0)("kdrakstatusRD"), String))
                    End If
                    If toReturn.Rows(0)("kdsuku") Is System.DBNull.Value Then
                        _kdsuku = New SqlString(String.Empty)
                    Else
                        _kdsuku = New SqlString(CType(toReturn.Rows(0)("kdsuku"), String))
                    End If
                    If toReturn.Rows(0)("namaayah") Is System.DBNull.Value Then
                        _namaayah = New SqlString(String.Empty)
                    Else
                        _namaayah = New SqlString(CType(toReturn.Rows(0)("namaayah"), String))
                    End If
                    If toReturn.Rows(0)("kdpekerjaanayah") Is System.DBNull.Value Then
                        _kdpekerjaanayah = New SqlString(String.Empty)
                    Else
                        _kdpekerjaanayah = New SqlString(CType(toReturn.Rows(0)("kdpekerjaanayah"), String))
                    End If
                    If toReturn.Rows(0)("umurayah") Is System.DBNull.Value Then
                        _umurayah = New SqlInt16(0)
                    Else
                        _umurayah = New SqlInt16(CType(toReturn.Rows(0)("umurayah"), Short))
                    End If
                    If toReturn.Rows(0)("namaibu") Is System.DBNull.Value Then
                        _namaibu = New SqlString(String.Empty)
                    Else
                        _namaibu = New SqlString(CType(toReturn.Rows(0)("namaibu"), String))
                    End If
                    If toReturn.Rows(0)("kdpekerjaanibu") Is System.DBNull.Value Then
                        _kdpekerjaanibu = New SqlString(String.Empty)
                    Else
                        _kdpekerjaanibu = New SqlString(CType(toReturn.Rows(0)("kdpekerjaanibu"), String))
                    End If
                    If toReturn.Rows(0)("umuribu") Is System.DBNull.Value Then
                        _umuribu = New SqlInt16(0)
                    Else
                        _umuribu = New SqlInt16(CType(toReturn.Rows(0)("umuribu"), Short))
                    End If
                    If toReturn.Rows(0)("nofoto") Is System.DBNull.Value Then
                        _nofoto = New SqlString(String.Empty)
                    Else
                        _nofoto = New SqlString(CType(toReturn.Rows(0)("nofoto"), String))
                    End If

                    If toReturn.Rows(0)("kunjunganRDke") Is System.DBNull.Value Then
                        _kunjunganRDke = New SqlDecimal(0D)
                    Else
                        _kunjunganRDke = New SqlDecimal(CType(toReturn.Rows(0)("kunjunganRDke"), Decimal))
                    End If
                    If toReturn.Rows(0)("tglakhkunjunganRD") Is System.DBNull.Value Then
                        _tglakhkunjunganRD = SqlDateTime.Null
                    Else
                        _tglakhkunjunganRD = New SqlDateTime(CType(toReturn.Rows(0)("tglakhkunjunganRD"), Date))
                    End If
                    _descpekerjaan = New SqlString(CType(ProcessNull.GetString(toReturn.Rows(0)("descpekerjaan")), String))
                    _descpekerjaanayah = New SqlString(CType(ProcessNull.GetString(toReturn.Rows(0)("descpekerjaanayah")), String))
                    _descpekerjaanibu = New SqlString(CType(ProcessNull.GetString(toReturn.Rows(0)("descpekerjaanibu")), String))
                    If toReturn.Rows(0)("photourl") Is System.DBNull.Value Then
                        _Photo = New SqlString(String.Empty)
                    Else
                        _Photo = New SqlString(CType(toReturn.Rows(0)("photourl"), String))
                    End If
                    If toReturn.Rows(0)("nmfile") Is System.DBNull.Value Or toReturn.Rows(0)("nmfile") = "" Then
                        _NmFile = New SqlString(String.Empty)
                    Else
                        _NmFile = New SqlString(CType(toReturn.Rows(0)("nmfile"), String))
                    End If

                    If toReturn.Rows(0)("nmEmergencyContact") Is System.DBNull.Value Then
                        _NmEContact = New SqlString(String.Empty)
                    Else
                        _NmEContact = New SqlString(CType(toReturn.Rows(0)("nmEmergencyContact"), String))
                    End If
                    If toReturn.Rows(0)("almtEmergencyContact") Is System.DBNull.Value Then
                        _AlmtEContact = New SqlString(String.Empty)
                    Else
                        _AlmtEContact = New SqlString(CType(toReturn.Rows(0)("almtEmergencyContact"), String))
                    End If
                    If toReturn.Rows(0)("hubEmergencyContact") Is System.DBNull.Value Then
                        _HubEContact = New SqlString(String.Empty)
                    Else
                        _HubEContact = New SqlString(CType(toReturn.Rows(0)("hubEmergencyContact"), String))
                    End If
                    If toReturn.Rows(0)("telpEmergencyContact") Is System.DBNull.Value Then
                        _TelpEContact = New SqlString(String.Empty)
                    Else
                        _TelpEContact = New SqlString(CType(toReturn.Rows(0)("telpEmergencyContact"), String))
                    End If

                    If toReturn.Rows(0)("nmEmergencyContact") Is System.DBNull.Value Then
                        _NmEContact = New SqlString(String.Empty)
                    Else
                        _NmEContact = New SqlString(CType(toReturn.Rows(0)("nmEmergencyContact"), String))
                    End If
                    If toReturn.Rows(0)("almtEmergencyContact") Is System.DBNull.Value Then
                        _AlmtEContact = New SqlString(String.Empty)
                    Else
                        _AlmtEContact = New SqlString(CType(toReturn.Rows(0)("almtEmergencyContact"), String))
                    End If
                    If toReturn.Rows(0)("hubEmergencyContact") Is System.DBNull.Value Then
                        _HubEContact = New SqlString(String.Empty)
                    Else
                        _HubEContact = New SqlString(CType(toReturn.Rows(0)("hubEmergencyContact"), String))
                    End If
                    If toReturn.Rows(0)("telpEmergencyContact") Is System.DBNull.Value Then
                        _TelpEContact = New SqlString(String.Empty)
                    Else
                        _TelpEContact = New SqlString(CType(toReturn.Rows(0)("telpEmergencyContact"), String))
                    End If
                    If toReturn.Rows(0)("gelar") Is System.DBNull.Value Then
                        _gelar = New SqlString(String.Empty)
                    Else
                        _gelar = New SqlString(CType(toReturn.Rows(0)("gelar"), String))
                    End If
                    _pse = New SqlBoolean(CType(toReturn.Rows(0)("pse"), Boolean))
                    _alasan = (CType(toReturn.Rows(0)("alasan"), String))
                    _noPesertaBPJS = (CType(toReturn.Rows(0)("nopesertabpjs"), String))
                    '_tb = New SqlDecimal(CType(toReturn.Rows(0)("tb"), Decimal))
                    '_bb = New SqlDecimal(CType(toReturn.Rows(0)("bb"), Decimal))
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

        'Public Function SelectNoTelpPasien() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprs_SelectNoTelpPasien"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("rd_reg")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@norm", _norm))

        '        _mainConnection.Open()
        '        adapter.Fill(toReturn)
        '        If toReturn.Rows.Count > 0 Then
        '            If toReturn.Rows(0)("nohp") Is System.DBNull.Value Then
        '                _nohp = New SqlString(String.Empty)
        '            Else
        '                _nohp = New SqlString(CType(toReturn.Rows(0)("nohp"), String))
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

        'Public Function SelectOne_SudahLunasPiutang() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_Pasien_SelectSudahLunasPiutang"
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

        'Public Function SelectOne_SudahProsesPembayaran() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "sprd_Pasien_SelectSudahProsesPembayaran"
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

        'Public Function SelectOne_JumlahKunjunganRiRjRd() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    cmdToExecute.CommandText = "sprs_Pasien_SelectOne_JumlahKunjunganRiRjRd"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("pasien")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add("@norm", Me.Norm)

        '        _mainConnection.Open()

        '        adapter.Fill(toReturn)

        '        If toReturn.Rows.Count > 0 Then
        '            _jmlKunjunganRiRjRd = New SqlDouble(CType(toReturn.Rows(0)("jmkunjungan"), Double))
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
        'Public Function SelectOne_is_New(ByVal norm As String) As Boolean
        '    'Ini menentukan apakah pasien ini merupakan pasien baru atau tidak 
        '    'untuk menentukan apakah pasien ini langsung atau tidak adalah jumlah kunjungannya 
        '    'jika kunjungannya lebih dari satu maka di anggap pasien lama
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    Dim countRM As Integer
        '    cmdToExecute.CommandText = "sprs_Pasien_is_Register"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("pasien")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add("@norm", norm)
        '        cmdToExecute.Parameters.Add("@CountRM", SqlDbType.Int)


        '        _mainConnection.Open()

        '        cmdToExecute.Parameters("@CountRM").Direction = ParameterDirection.Output


        '        cmdToExecute.ExecuteNonQuery()
        '        countRM = Convert.ToInt32(cmdToExecute.Parameters("@CountRM").Value)
        '        If countRM > 1 Then
        '            Return False
        '        Else
        '            Return True
        '        End If

        '    Catch ex As Exception
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function
        'Public Function SelectDataRegistrasi_ByNorm() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    cmdToExecute.CommandText = "sprs_Pasien_SelectDataRegistrasi_ByNoRM"

        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("pasien")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add("@norm", Me.Norm)

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

        '#Region "Delete"
        '        Public Overrides Function Delete() As Boolean
        '            Dim cmdToExecute As SqlCommand = New SqlCommand
        '            cmdToExecute.CommandText = "sprd_pasien_delete"
        '            cmdToExecute.CommandType = CommandType.StoredProcedure
        '            cmdToExecute.Connection = _mainConnection

        '            Dim cmdToUpdateRDNorm As SqlCommand = New SqlCommand
        '            cmdToUpdateRDNorm.CommandText = "sprd_registrasi_updateNoRM"
        '            cmdToUpdateRDNorm.CommandType = CommandType.StoredProcedure
        '            cmdToUpdateRDNorm.Connection = _mainConnection

        '            _mainConnection.Open()
        '            cmdToExecute.Parameters.Add(New SqlParameter("@norm", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _norm))


        '            cmdToUpdateRDNorm.Parameters.Add(New SqlParameter("@noRMLama", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _oldnorm))
        '            cmdToUpdateRDNorm.Parameters.Add(New SqlParameter("@noRMBaru", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _norm))
        '            Try
        '                ' //Execute Query
        '                cmdToExecute.ExecuteNonQuery()
        '                cmdToUpdateRDNorm.ExecuteNonQuery()
        '                Return True
        '            Catch ex As Exception
        '                ' // some error occured. Bubble it to caller and encapsulate Exception object
        '                ExceptionManager.Publish(ex)
        '            Finally
        '                ' // Close connection.
        '                _mainConnection.Close()
        '                cmdToExecute.Dispose()
        '            End Try
        '        End Function
        '#End Region

        '#Region "Insert"
        '        Public Overrides Function Insert() As Boolean
        '            Dim cmdToExecute As SqlCommand = New SqlCommand
        '            cmdToExecute.CommandText = "dbo.[sprd_pasien_Insert]"
        '            cmdToExecute.CommandType = CommandType.StoredProcedure

        '            ' // Use base class' connection object
        '            cmdToExecute.Connection = _mainConnection

        '            Try
        '                cmdToExecute.Parameters.Add(New SqlParameter("@norm", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _norm))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@title", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _title))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@nama", SqlDbType.Char, 120, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nama))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@marga", SqlDbType.Char, 120, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _marga))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kdseks", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdseks))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@tmplahir", SqlDbType.Char, 20, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _tmplahir))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@tgllahir", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgllahir))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@umurtahun", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _umurtahun))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@umurbulan", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _umurbulan))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@umurhari", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _umurhari))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@jalan", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jalan))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@gang", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _gang))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@rt", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _rt))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@rw", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _rw))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@notelepon", _notelepon))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@nohp", _nohp))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kota", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kota))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kdpos", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdpos))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kdpropinsi", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdpropinsi))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kdagama", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdagama))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kdstkawin", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdstkawin))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kdpendidikan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdpendidikan))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kdpekerjaan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdpekerjaan))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kdwarganegara", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdwarganegara))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@alergi", SqlDbType.NVarChar, 120, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _alergi))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@catatan", SqlDbType.NVarChar, 120, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _catatan))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@noktpsim", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noktpsim))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@tglexpired", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tglexpired))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@nopasport", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nopasport))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@aktif", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _aktif))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@nomember", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nomember))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@blacklist", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _blacklist))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@pse", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _pse))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@lupdate", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _lupdate))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@updater", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _updater))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@member", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _member))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@namakantor", SqlDbType.NVarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _namaKantor))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@alamatkantor1", SqlDbType.NVarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _alamatKantor1))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@alamatkantor2", SqlDbType.NVarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _alamatKantor2))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kantorkota", SqlDbType.NVarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kantorKota))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kantorNotelp", _kantorNoTelp))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@golongandarah", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _golongandarah))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@email", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _email))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@pasien", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _pasien))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@statfilerd", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _statfilerd))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kdinstansi", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdinstansi))
        '                If Not _kdrakstatusRD.IsNull Then
        '                    cmdToExecute.Parameters.Add(New SqlParameter("@kdrakstatusRD", SqlDbType.Char, 10, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _kdrakstatusRD))
        '                End If
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kdsuku", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdsuku))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@namaayah", SqlDbType.Char, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _namaayah))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kdpekerjaanayah", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdpekerjaanayah))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@umurayah", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _umurayah))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@namaibu", SqlDbType.Char, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _namaibu))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kdpekerjaanibu", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdpekerjaanibu))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@umuribu", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _umuribu))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@nofoto", SqlDbType.NVarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nofoto))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@descpekerjaan", SqlDbType.VarChar, 100, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _descpekerjaan))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@descpekerjaanayah", SqlDbType.VarChar, 100, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _descpekerjaanayah))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@descpekerjaanibu", SqlDbType.VarChar, 100, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _descpekerjaanibu))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@Status", _StatusPasien))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@nmEmergencyContact", _NmEContact))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@almtEmergencyContact", _AlmtEContact))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@hubEmergencyContact", _HubEContact))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@telpEmergencyContact", _TelpEContact))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@gelar", _gelar))

        '                ' // Open connection.
        '                _mainConnection.Open()

        '                ' // Execute query.
        '                cmdToExecute.ExecuteNonQuery()
        '                Return True
        '            Catch ex As Exception
        '                ' // some error occured. Bubble it to caller and encapsulate Exception object
        '                ExceptionManager.Publish(ex)
        '            Finally
        '                ' // Close connection.
        '                _mainConnection.Close()
        '                cmdToExecute.Dispose()
        '            End Try
        '        End Function
        '#End Region

        '#Region "Update"
        '        Public Overrides Function Update() As Boolean
        '            Dim cmdToExecute As SqlCommand = New SqlCommand

        '            cmdToExecute.CommandText = "sprd_pasien_Update"
        '            cmdToExecute.CommandType = CommandType.StoredProcedure

        '            ' // Use base class' connection object
        '            cmdToExecute.Connection = _mainConnection

        '            Try
        '                cmdToExecute.Parameters.Add(New SqlParameter("@norm", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _norm))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@title", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _title))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@nama", SqlDbType.Char, 120, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nama))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@marga", SqlDbType.Char, 120, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _marga))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kdseks", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdseks))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@tmplahir", SqlDbType.Char, 20, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _tmplahir))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@tgllahir", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgllahir))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@umurtahun", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _umurtahun))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@umurbulan", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _umurbulan))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@umurhari", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _umurhari))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@jalan", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jalan))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@gang", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _gang))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@rt", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _rt))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@rw", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _rw))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@notelepon", _notelepon))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@nohp", _nohp))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kota", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kota))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kdpos", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdpos))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kdpropinsi", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdpropinsi))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kdagama", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdagama))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kdstkawin", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdstkawin))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kdpendidikan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdpendidikan))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kdpekerjaan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdpekerjaan))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kdwarganegara", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdwarganegara))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@alergi", SqlDbType.NVarChar, 120, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _alergi))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@catatan", SqlDbType.NVarChar, 120, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _catatan))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@rawatke", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _rawatke))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@tglakhrawat", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tglakhrawat))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@noktpsim", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noktpsim))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@tglexpired", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tglexpired))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@nopasport", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nopasport))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@aktif", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _aktif))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@nomember", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nomember))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@blacklist", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _blacklist))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@pse", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _pse))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@lupdate", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _lupdate))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@updater", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _updater))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@member", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _member))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@namakantor", SqlDbType.NVarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _namaKantor))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@alamatkantor1", SqlDbType.NVarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _alamatKantor1))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@alamatkantor2", SqlDbType.NVarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _alamatKantor2))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kantorkota", SqlDbType.NVarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kantorKota))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kantorNotelp", _kantorNoTelp))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@golongandarah", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _golongandarah))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@email", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _email))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@pasien", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _pasien))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@statfilerd", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _statfilerd))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kdinstansi", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdinstansi))
        '                If Not _kdrakstatusRD.IsNull Then
        '                    cmdToExecute.Parameters.Add(New SqlParameter("@kdrakstatusRD", SqlDbType.Char, 10, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _kdrakstatusRD))
        '                End If
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kdsuku", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdsuku))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@namaayah", SqlDbType.Char, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _namaayah))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kdpekerjaanayah", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdpekerjaanayah))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@umurayah", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _umurayah))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@namaibu", SqlDbType.Char, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _namaibu))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kdpekerjaanibu", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdpekerjaanibu))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@umuribu", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _umuribu))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@nofoto", SqlDbType.NVarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nofoto))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@descpekerjaan", SqlDbType.VarChar, 100, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _descpekerjaan))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@descpekerjaanayah", SqlDbType.VarChar, 100, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _descpekerjaanayah))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@descpekerjaanibu", SqlDbType.VarChar, 100, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _descpekerjaanibu))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@Status", _StatusPasien))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@nmEmergencyContact", _NmEContact))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@almtEmergencyContact", _AlmtEContact))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@hubEmergencyContact", _HubEContact))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@telpEmergencyContact", _TelpEContact))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@gelar", _gelar))

        '                ' // Open connection.
        '                _mainConnection.Open()

        '                ' // Execute query.
        '                cmdToExecute.ExecuteNonQuery()

        '                Return True
        '            Catch ex As Exception
        '                ' // some error occured. Bubble it to caller and encapsulate Exception object
        '                ExceptionManager.Publish(ex)
        '            Finally
        '                ' // Close connection.
        '                _mainConnection.Close()
        '                cmdToExecute.Dispose()
        '            End Try
        '        End Function

        '        Public Function UpdatePasienFromRegistrasi() As Boolean
        '            Dim cmdToExecute As SqlCommand = New SqlCommand

        '            cmdToExecute.CommandText = "sprd_pasien_UpdatePasienFromRegistrasi"
        '            cmdToExecute.CommandType = CommandType.StoredProcedure

        '            ' // Use base class' connection object
        '            cmdToExecute.Connection = _mainConnection

        '            Try
        '                cmdToExecute.Parameters.Add(New SqlParameter("@norm", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _norm))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@title", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _title))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@nama", SqlDbType.Char, 120, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nama))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@marga", SqlDbType.Char, 120, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _marga))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kdseks", SqlDbType.Char, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdseks))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@tmplahir", SqlDbType.Char, 20, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _tmplahir))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@tgllahir", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgllahir))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@umurtahun", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _umurtahun))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@umurbulan", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _umurbulan))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@umurhari", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _umurhari))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@jalan", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jalan))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@gang", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _gang))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@rt", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _rt))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@rw", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _rw))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@notelepon", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _notelepon))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@nohp", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nohp))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@kota", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kota))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kdpos", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdpos))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@kdpropinsi", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdpropinsi))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@kdagama", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdagama))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@kdstkawin", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdstkawin))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@kdpendidikan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdpendidikan))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@kdpekerjaan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdpekerjaan))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@kdwarganegara", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdwarganegara))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@alergi", SqlDbType.NVarChar, 120, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _alergi))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@catatan", SqlDbType.NVarChar, 120, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _catatan))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@noktpsim", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noktpsim))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@tglexpired", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tglexpired))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@nopasport", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nopasport))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@aktif", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _aktif))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@nomember", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nomember))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@blacklist", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _blacklist))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@lupdate", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _lupdate))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@updater", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _updater))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@member", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _member))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@namakantor", SqlDbType.NVarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _namaKantor))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@alamatkantor1", SqlDbType.NVarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _alamatKantor1))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@alamatkantor2", SqlDbType.NVarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _alamatKantor2))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@kantorkota", SqlDbType.NVarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kantorKota))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@kantorNotelp", SqlDbType.NVarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kantorNoTelp))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@golongandarah", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _golongandarah))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@email", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _email))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@pasien", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _pasien))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@statfilerd", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _statfilerd))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kdinstansi", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdinstansi))
        '                'If Not _kdrakstatusRD.IsNull Then
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@kdrakstatusRD", SqlDbType.Char, 10, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _kdrakstatusRD))
        '                'End If
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kdsuku", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdsuku))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@namaayah", SqlDbType.Char, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _namaayah))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@kdpekerjaanayah", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdpekerjaanayah))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@umurayah", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _umurayah))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@namaibu", SqlDbType.Char, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _namaibu))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@kdpekerjaanibu", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdpekerjaanibu))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@umuribu", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _umuribu))
        '                'cmdToExecute.Parameters.Add(New SqlParameter("@nofoto", SqlDbType.NVarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nofoto))

        '                ' // Open connection.
        '                _mainConnection.Open()

        '                ' // Execute query.
        '                cmdToExecute.ExecuteNonQuery()

        '                Return True
        '            Catch ex As Exception
        '                ' // some error occured. Bubble it to caller and encapsulate Exception object
        '                ExceptionManager.Publish(ex)
        '            Finally
        '                ' // Close connection.
        '                _mainConnection.Close()
        '                cmdToExecute.Dispose()
        '            End Try
        '        End Function

        '        Public Function UpdateByID_FileRM() As Boolean
        '            Dim cmdToExecute As SqlCommand = New SqlCommand

        '            cmdToExecute.CommandText = "sprd_Pasien_Update_Statfile"
        '            cmdToExecute.CommandType = CommandType.StoredProcedure

        '            ' // Use base class' connection object
        '            cmdToExecute.Connection = _mainConnection

        '            Try
        '                cmdToExecute.Parameters.Add(New SqlParameter("@norm", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _norm))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@statfilerd", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _statfilerd))

        '                ' // Open connection.
        '                _mainConnection.Open()

        '                ' // Execute query.
        '                cmdToExecute.ExecuteNonQuery()

        '                Return True
        '            Catch ex As Exception
        '                ' // some error occured. Bubble it to caller and encapsulate Exception object
        '                ExceptionManager.Publish(ex)
        '            Finally
        '                ' // Close connection.
        '                _mainConnection.Close()
        '                cmdToExecute.Dispose()
        '            End Try
        '        End Function

        '        Public Function Update_rakstatusRD() As Boolean
        '            Dim cmdToExecute As SqlCommand = New SqlCommand

        '            cmdToExecute.CommandText = "sprd_Pasien_Update_RakStatusRD"
        '            cmdToExecute.CommandType = CommandType.StoredProcedure

        '            ' // Use base class' connection object
        '            cmdToExecute.Connection = _mainConnection

        '            Try

        '                cmdToExecute.Parameters.Add(New SqlParameter("@norm", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Proposed, _norm))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@kdrakstatusRD", SqlDbType.Char, 10, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _kdrakstatusRD))


        '                ' // Open connection.
        '                _mainConnection.Open()

        '                ' // Execute query.
        '                cmdToExecute.ExecuteNonQuery()

        '                Return True
        '            Catch ex As Exception
        '                ' // some error occured. Bubble it to caller and encapsulate Exception object
        '                ExceptionManager.Publish(ex)
        '            Finally
        '                ' // Close connection.
        '                _mainConnection.Close()
        '                cmdToExecute.Dispose()
        '            End Try
        '        End Function

        '        Public Function Update_blacklist() As Boolean
        '            Dim cmdToExecute As SqlCommand = New SqlCommand

        '            cmdToExecute.CommandText = "sprd_Pasien_Update_Blacklist"
        '            cmdToExecute.CommandType = CommandType.StoredProcedure

        '            ' // Use base class' connection object
        '            cmdToExecute.Connection = _mainConnection

        '            Try

        '                cmdToExecute.Parameters.Add(New SqlParameter("@norm", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Proposed, Me.Norm))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@blacklist", SqlDbType.Bit, 1, ParameterDirection.Input, True, 0, 0, Nothing, DataRowVersion.Proposed, Me.Blacklist))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@pse", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _pse))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@alasan", SqlDbType.VarChar, 150, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _alasan))

        '                ' // Open connection.
        '                _mainConnection.Open()

        '                ' // Execute query.
        '                cmdToExecute.ExecuteNonQuery()

        '                Return True
        '            Catch ex As Exception
        '                ' // some error occured. Bubble it to caller and encapsulate Exception object
        '                ExceptionManager.Publish(ex)
        '            Finally
        '                ' // Close connection.
        '                _mainConnection.Close()
        '                cmdToExecute.Dispose()
        '            End Try
        '        End Function
        '        Public Function Update_KunjunganRD() As Boolean
        '            Dim cmdToExecute As SqlCommand = New SqlCommand

        '            cmdToExecute.CommandText = "sprd_Pasien_updateKunjunganRD"
        '            cmdToExecute.CommandType = CommandType.StoredProcedure

        '            ' // Use base class' connection object
        '            cmdToExecute.Connection = _mainConnection

        '            Try

        '                cmdToExecute.Parameters.Add("@norm", _norm)
        '                cmdToExecute.Parameters.Add("@kunjunganRDke", _kunjunganRDke)


        '                ' // Open connection.
        '                _mainConnection.Open()

        '                ' // Execute query.
        '                cmdToExecute.ExecuteNonQuery()

        '                Return True
        '            Catch ex As Exception
        '                ' // some error occured. Bubble it to caller and encapsulate Exception object
        '                ExceptionManager.Publish(ex)
        '            Finally
        '                ' // Close connection.
        '                _mainConnection.Close()
        '                cmdToExecute.Dispose()
        '            End Try
        '        End Function

        '        Public Function IsNameExist() As Boolean
        '            Dim cmd As New SqlCommand

        '            cmd.CommandType = CommandType.StoredProcedure
        '            cmd.CommandText = "sprs_IsNameExist"

        '            'use base class to connection 
        '            cmd.Connection = _mainconnection

        '            Try
        '                cmd.Parameters.Add("@NAMA", _nama)
        '                cmd.Parameters.Add("@MARGA ", _marga)
        '                cmd.Parameters.Add("@TGLLAHIR", _strtgllahir)

        '                _mainconnection.Open()

        '                Dim adapter As New SqlDataAdapter(cmd)
        '                Dim tblPasien As New DataTable("Pasien")

        '                adapter.Fill(tblPasien)

        '                If tblPasien.Rows.Count >= 1 Then
        '                    Return True
        '                Else
        '                    Return False
        '                End If


        '                adapter.Dispose()
        '                tblPasien.Dispose()

        '            Catch ex As Exception
        '                ' // some error occured. Bubble it to caller and encapsulate Exception object
        '                ExceptionManager.Publish(ex)
        '            Finally
        '                ' // Close connection.
        '                _mainConnection.Close()
        '                cmd.Dispose()
        '            End Try
        '        End Function

        '        Public Function Update_noPesertaBPJS() As Boolean
        '            Dim cmdToExecute As SqlCommand = New SqlCommand

        '            cmdToExecute.CommandText = "sprd_Pasien_UpdateNoPesertaBPJS"
        '            cmdToExecute.CommandType = CommandType.StoredProcedure

        '            ' // Use base class' connection object
        '            cmdToExecute.Connection = _mainConnection

        '            Try

        '                cmdToExecute.Parameters.Add(New SqlParameter("@norm", _norm))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@noPesertaBPJS", _noPesertaBPJS))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@NIK", _noktpsim))

        '                ' // Open connection.
        '                _mainConnection.Open()

        '                ' // Execute query.
        '                cmdToExecute.ExecuteNonQuery()

        '                Return True
        '            Catch ex As Exception
        '                ' // some error occured. Bubble it to caller and encapsulate Exception object
        '                ExceptionManager.Publish(ex)
        '            Finally
        '                ' // Close connection.
        '                _mainConnection.Close()
        '                cmdToExecute.Dispose()
        '            End Try
        '        End Function
        '#End Region

        '#Region "Photo"
        '        Public Function UpdatePhoto()
        '            Dim cmdToExecute As SqlCommand = New SqlCommand

        '            cmdToExecute.CommandText = "Sprs_photo_pasien_update"
        '            cmdToExecute.CommandType = CommandType.StoredProcedure

        '            ' // Use base class' connection object
        '            cmdToExecute.Connection = _mainConnection

        '            Try
        '                cmdToExecute.Parameters.Add(New SqlParameter("@norm", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _norm))
        '                cmdToExecute.Parameters.Add(New SqlParameter("@Photo", _NmPhoto))
        '                ' // Open connection.
        '                _mainConnection.Open()

        '                ' // Execute query.
        '                cmdToExecute.ExecuteNonQuery()

        '                Return True
        '            Catch ex As Exception
        '                ' // some error occured. Bubble it to caller and encapsulate Exception object
        '                ExceptionManager.Publish(ex)
        '            Finally
        '                ' // Close connection.
        '                _mainConnection.Close()
        '                cmdToExecute.Dispose()
        '            End Try
        '        End Function
        '#End Region

#Region " Class Property Declarations "
        'Public ReadOnly Property [NewNorm]() As SqlString
        '    Get
        '        Dim reader As SqlDataReader
        '        Dim retval As String = String.Empty
        '        Dim str1 As String = String.Empty
        '        Dim str2 As String = String.Empty
        '        Dim str3 As String = String.Empty
        '        Dim str4 As String = String.Empty
        '        Dim str5 As String = String.Empty
        '        Dim strmaxnorm As String
        '        Dim formatnorm As String
        '        Dim sv As New SetVar
        '        formatnorm = sv.GetValue("format_norm", "RS_").Trim

        '        Dim cmdToExecute As SqlCommand = New SqlCommand
        '        Dim sRetVal As String

        '        Try
        '            cmdToExecute.CommandText = "sprs_pasien_maxnorm"
        '            cmdToExecute.CommandType = CommandType.StoredProcedure
        '            cmdToExecute.Connection = _mainConnection

        '            ' // Open connection.
        '            If _mainconnection.State = ConnectionState.Closed Then
        '                _mainConnection.Open()
        '            End If

        '            ' // Execute query.
        '            reader = cmdToExecute.ExecuteReader
        '            If reader.Read Then
        '                retval = ProcessNull.GetString(reader("maxnorm"))
        '            End If

        '            Select Case formatnorm.Trim
        '                Case "99-99-99-99"
        '                    If retval.Length = 0 Then
        '                        retval = "00-00-00-00"
        '                        strmaxnorm = retval
        '                    Else
        '                        str1 = retval.Remove(2, 1)
        '                        str1 = str1.Remove(4, 1)
        '                        str1 = str1.Remove(6, 1)
        '                        str1 = Format(Right(CInt(str1), 8) + 1, "0000000#")

        '                        Dim strIsNormIncYear As String = "0"
        '                        strIsNormIncYear = ProcessNull.GetString(Common.Methods.GetSettingParameter("IsNormIncYear", Common.Constants.ModuleID.MEDICAL_RECORD))

        '                        If strIsNormIncYear = "1" Then
        '                            str2 = Right(DatePart(DateInterval.Year, Today).ToString.Trim, 2)
        '                        Else
        '                            str2 = str1.Substring(0, 2)
        '                        End If
        '                        str3 = str1.Substring(2, 2)
        '                        str4 = str1.Substring(4, 2)
        '                        str5 = str1.Substring(6, 2)

        '                        strmaxnorm = str2 & "-" & str3 & "-" & str4 & "-" & str5
        '                    End If

        '                Case "999-999-999"
        '                    If retval.Length = 0 Then
        '                        retval = "000-000-000"
        '                        strmaxnorm = retval
        '                    Else
        '                        str1 = retval.Remove(3, 1)
        '                        str1 = str1.Remove(6, 1)
        '                        str1 = Format(Right(CInt(str1), 9) + 1, "00000000#")

        '                        str2 = str1.Substring(0, 3)
        '                        str3 = str1.Substring(3, 3)
        '                        str4 = str1.Substring(6, 3)

        '                        strmaxnorm = str2 & "-" & str3 & "-" & str4
        '                    End If
        '            End Select

        '            Return New SqlString(strmaxnorm)
        '        Catch ex As Exception
        '            ' // some error occured. Bubble it to caller and encapsulate Exception object
        '            ExceptionManager.Publish(ex)
        '        Finally
        '            ' // Close connection.
        '            _mainConnection.Close()
        '            cmdToExecute.Dispose()
        '            reader.Close()
        '            reader = Nothing
        '        End Try
        '    End Get
        'End Property

        'Public ReadOnly Property [NewNorm]() As SqlString
        '    Get
        '        Dim cmdToExecute As SqlCommand = New SqlCommand
        '        Dim sRetVal As String

        '        cmdToExecute.CommandText = "sprs_pasien_maxnorm"
        '        cmdToExecute.CommandType = CommandType.StoredProcedure

        '        Dim toReturn As DataTable = New DataTable("maxnorm")
        '        Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '        cmdToExecute.Connection = _mainConnection

        '        Try

        '            ' // Open connection.
        '            _mainConnection.Open()

        '            ' // Execute query.
        '            adapter.Fill(toReturn)

        '            If toReturn.Rows.Count > 0 Then
        '                Dim iNorm As String
        '                iNorm = ProcessNull.GetString(toReturn.Rows(0)("maxnorm"))

        '                If Len(Trim(iNorm)) > 0 Then
        '                    sRetVal = Format(Right(CInt(iNorm.Trim), 8) + 1, "0000000#")
        '                End If

        '                Return New SqlString(sRetVal)
        '            End If
        '        Catch ex As Exception
        '            ' // some error occured. Bubble it to caller and encapsulate Exception object
        '            ExceptionManager.Publish(ex)
        '        Finally
        '            ' // Close connection.
        '            _mainConnection.Close()
        '            cmdToExecute.Dispose()
        '            adapter.Dispose()
        '        End Try
        '    End Get
        'End Property

        Public Property [noPesertaBPJS]() As SqlString
            Get
                Return _noPesertaBPJS
            End Get
            Set(ByVal Value As SqlString)
                _noPesertaBPJS = Value
            End Set
        End Property

        Public Property [huruf]() As SqlString
            Get
                Return _huruf
            End Get
            Set(ByVal Value As SqlString)
                _huruf = Value
            End Set
        End Property


        Public Property [Norm]() As SqlString
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


        Public Property [OldNorm]() As SqlString
            Get
                Return _oldnorm
            End Get
            Set(ByVal Value As SqlString)
                Dim normTmp As SqlString = Value
                If normTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Norm", "Norm can't be NULL")
                End If
                _oldnorm = Value
            End Set
        End Property


        Public Property [UsrUpdate]() As SqlString
            Get
                Return _usrupdate
            End Get
            Set(ByVal Value As SqlString)
                Dim usrupdateTmp As SqlString = Value
                If usrupdateTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Usr Update", "Usr Update can't be NULL")
                End If
                _usrupdate = Value
            End Set
        End Property


        Public Property [Title]() As SqlString
            Get
                Return _title
            End Get
            Set(ByVal Value As SqlString)
                _title = Value
            End Set
        End Property


        Public Property [Nama]() As SqlString
            Get
                Return _nama
            End Get
            Set(ByVal Value As SqlString)
                Dim namaTmp As SqlString = Value
                If namaTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Nama", "Nama can't be NULL")
                End If
                _nama = Value
            End Set
        End Property


        Public Property [Marga]() As SqlString
            Get
                Return _marga
            End Get
            Set(ByVal Value As SqlString)
                _marga = Value
            End Set
        End Property


        Public Property [Kdseks]() As SqlString
            Get
                Return _kdseks
            End Get
            Set(ByVal Value As SqlString)
                Dim kdseksTmp As SqlString = Value
                If kdseksTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Kdseks", "Kdseks can't be NULL")
                End If
                _kdseks = Value
            End Set
        End Property


        Public Property [Tmplahir]() As SqlString
            Get
                Return _tmplahir
            End Get
            Set(ByVal Value As SqlString)
                _tmplahir = Value
            End Set
        End Property


        Public Property [Tgllahir]() As SqlDateTime
            Get
                Return _tgllahir
            End Get
            Set(ByVal Value As SqlDateTime)
                _tgllahir = Value
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
        Public Property [NMFile]() As SqlString
            Get
                Return _NmFile
            End Get
            Set(ByVal Value As SqlString)
                _NmFile = Value
            End Set
        End Property

        Public Property [Jalan]() As SqlString
            Get
                Return _jalan
            End Get
            Set(ByVal Value As SqlString)
                _jalan = Value
            End Set
        End Property


        Public Property [Gang]() As SqlString
            Get
                Return _gang
            End Get
            Set(ByVal Value As SqlString)
                _gang = Value
            End Set
        End Property


        Public Property [Rt]() As SqlString
            Get
                Return _rt
            End Get
            Set(ByVal Value As SqlString)
                _rt = Value
            End Set
        End Property


        Public Property [Rw]() As SqlString
            Get
                Return _rw
            End Get
            Set(ByVal Value As SqlString)
                _rw = Value
            End Set
        End Property


        Public Property [Notelepon]() As SqlString
            Get
                Return _notelepon
            End Get
            Set(ByVal Value As SqlString)
                _notelepon = Value
            End Set
        End Property


        Public Property [Nohp]() As SqlString
            Get
                Return _nohp
            End Get
            Set(ByVal Value As SqlString)
                _nohp = Value
            End Set
        End Property


        Public Property [Kota]() As SqlString
            Get
                Return _kota
            End Get
            Set(ByVal Value As SqlString)
                _kota = Value
            End Set
        End Property


        Public Property [Kdpos]() As SqlString
            Get
                Return _kdpos
            End Get
            Set(ByVal Value As SqlString)
                _kdpos = Value
            End Set
        End Property


        Public Property [Kdpropinsi]() As SqlString
            Get
                Return _kdpropinsi
            End Get
            Set(ByVal Value As SqlString)
                _kdpropinsi = Value
            End Set
        End Property


        Public Property [Kdagama]() As SqlString
            Get
                Return _kdagama
            End Get
            Set(ByVal Value As SqlString)
                _kdagama = Value
            End Set
        End Property


        Public Property [Kdstkawin]() As SqlString
            Get
                Return _kdstkawin
            End Get
            Set(ByVal Value As SqlString)
                _kdstkawin = Value
            End Set
        End Property


        Public Property [Kdpendidikan]() As SqlString
            Get
                Return _kdpendidikan
            End Get
            Set(ByVal Value As SqlString)
                _kdpendidikan = Value
            End Set
        End Property


        Public Property [Kdpekerjaan]() As SqlString
            Get
                Return _kdpekerjaan
            End Get
            Set(ByVal Value As SqlString)
                _kdpekerjaan = Value
            End Set
        End Property


        Public Property [Kdwarganegara]() As SqlString
            Get
                Return _kdwarganegara
            End Get
            Set(ByVal Value As SqlString)
                _kdwarganegara = Value
            End Set
        End Property


        Public Property [Alergi]() As SqlString
            Get
                Return _alergi
            End Get
            Set(ByVal Value As SqlString)
                _alergi = Value
            End Set
        End Property

        Public Property [StatusPasien]() As SqlString
            Get
                Return _StatusPasien
            End Get
            Set(ByVal Value As SqlString)
                _StatusPasien = Value
            End Set
        End Property

        Public Property [Catatan]() As SqlString
            Get
                Return _catatan
            End Get
            Set(ByVal Value As SqlString)
                _catatan = Value
            End Set
        End Property


        Public Property [KunjunganRjke]() As SqlDecimal
            Get
                Return _kunjunganRJke
            End Get
            Set(ByVal Value As SqlDecimal)
                _kunjunganRJke = Value
            End Set
        End Property

        Public Property [kunjunganRDke]() As SqlDecimal
            Get
                Return _kunjunganRDke
            End Get
            Set(ByVal Value As SqlDecimal)
                _kunjunganRDke = Value
            End Set
        End Property

        Public Property [TglakhKunjunganRJ]() As SqlDateTime
            Get
                Return _tglakhkunjunganRJ
            End Get
            Set(ByVal Value As SqlDateTime)
                _tglakhkunjunganRJ = Value
            End Set
        End Property


        Public Property [Noktpsim]() As SqlString
            Get
                Return _noktpsim
            End Get
            Set(ByVal Value As SqlString)
                _noktpsim = Value
            End Set
        End Property


        Public Property [Tglexpired]() As SqlDateTime
            Get
                Return _tglexpired
            End Get
            Set(ByVal Value As SqlDateTime)
                If Not Value.IsNull Then
                    _tglexpired = Value
                End If
            End Set
        End Property


        Public Property [Nopasport]() As SqlString
            Get
                Return _nopasport
            End Get
            Set(ByVal Value As SqlString)
                _nopasport = Value
            End Set
        End Property


        Public Property [Aktif]() As SqlBoolean
            Get
                Return _aktif
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim aktifTmp As SqlBoolean = Value
                If aktifTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Aktif", "Aktif can't be NULL")
                End If
                _aktif = Value
            End Set
        End Property


        Public Property [Nomember]() As SqlString
            Get
                Return _nomember
            End Get
            Set(ByVal Value As SqlString)
                _nomember = Value
            End Set
        End Property


        Public Property [Blacklist]() As SqlBoolean
            Get
                Return _blacklist
            End Get
            Set(ByVal Value As SqlBoolean)
                _blacklist = Value
            End Set
        End Property


        Public Property [PSE]() As SqlBoolean
            Get
                Return _pse
            End Get
            Set(ByVal Value As SqlBoolean)
                _pse = Value
            End Set
        End Property


        Public Property [LUpdate]() As SqlDateTime
            Get
                Return _lupdate
            End Get
            Set(ByVal Value As SqlDateTime)
                _lupdate = Value
            End Set
        End Property


        Public Property [Updater]() As SqlString
            Get
                Return _updater
            End Get
            Set(ByVal Value As SqlString)
                _updater = Value
            End Set
        End Property


        Public Property [Member]() As SqlBoolean
            Get
                Return _member
            End Get
            Set(ByVal Value As SqlBoolean)
                _member = Value
            End Set
        End Property


        Public Property [NamaKantor]() As SqlString
            Get
                Return _namaKantor
            End Get
            Set(ByVal Value As SqlString)
                _namaKantor = Value
            End Set
        End Property


        Public Property [AlamatKantor1]() As SqlString
            Get
                Return _alamatKantor1
            End Get
            Set(ByVal Value As SqlString)
                _alamatKantor1 = Value
            End Set
        End Property


        Public Property [AlamatKantor2]() As SqlString
            Get
                Return _alamatKantor2
            End Get
            Set(ByVal Value As SqlString)
                _alamatKantor2 = Value
            End Set
        End Property


        Public Property [KantorKota]() As SqlString
            Get
                Return _kantorKota
            End Get
            Set(ByVal Value As SqlString)
                _kantorKota = Value
            End Set
        End Property


        Public Property [KantorNoTelp]() As SqlString
            Get
                Return _kantorNoTelp
            End Get
            Set(ByVal Value As SqlString)
                _kantorNoTelp = Value
            End Set
        End Property


        Public Property [GolonganDarah]() As SqlString
            Get
                Return _golongandarah
            End Get
            Set(ByVal Value As SqlString)
                _golongandarah = Value
            End Set
        End Property


        Public Property [Email]() As SqlString
            Get
                Return _email
            End Get
            Set(ByVal Value As SqlString)
                _email = Value
            End Set
        End Property


        Public Property [Pasien]() As SqlBoolean
            Get
                Return _pasien
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim pasienTmp As SqlBoolean = Value
                If pasienTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Pasien", "Pasien can't be NULL")
                End If
                _pasien = Value
            End Set
        End Property


        Public Property [StatfileRJ]() As SqlBoolean
            Get
                Return _statfilerj
            End Get
            Set(ByVal Value As SqlBoolean)
                _statfilerj = Value
            End Set
        End Property


        Public Property [StatfileRI]() As SqlBoolean
            Get
                Return _statfileri
            End Get
            Set(ByVal Value As SqlBoolean)
                _statfileri = Value
            End Set
        End Property

        Public Property [StatfileRD]() As SqlBoolean
            Get
                Return _statfilerd
            End Get
            Set(ByVal Value As SqlBoolean)
                _statfilerd = Value
            End Set
        End Property


        Public Property [Kdinstansi]() As SqlString
            Get
                Return _kdinstansi
            End Get
            Set(ByVal Value As SqlString)
                _kdinstansi = Value
            End Set
        End Property


        Public Property [RawatRIke]() As SqlDecimal
            Get
                Return _rawatRIke
            End Get
            Set(ByVal Value As SqlDecimal)
                _rawatRIke = Value
            End Set
        End Property


        Public Property [TglakhrawatRI]() As SqlDateTime
            Get
                Return _tglakhrawatRI
            End Get
            Set(ByVal Value As SqlDateTime)
                _tglakhrawatRI = Value
            End Set
        End Property
        Public Property [tglakhkunjunganRD]() As SqlDateTime
            Get
                Return _tglakhkunjunganRD
            End Get
            Set(ByVal Value As SqlDateTime)
                _tglakhkunjunganRD = Value
            End Set
        End Property

        Public Property [kdrakstatusRJ]() As SqlString
            Get
                Return _kdrakstatusRJ
            End Get
            Set(ByVal Value As SqlString)
                _kdrakstatusRJ = Value
            End Set
        End Property


        Public Property [kdrakstatusRI]() As SqlString
            Get
                Return _kdrakstatusRI
            End Get
            Set(ByVal Value As SqlString)
                _kdrakstatusRI = Value
            End Set
        End Property

        Public Property [kdrakstatusRD]() As SqlString
            Get
                Return _kdrakstatusRD
            End Get
            Set(ByVal Value As SqlString)
                _kdrakstatusRD = Value
            End Set
        End Property


        Public Property [Rakstatus]() As SqlString
            Get
                Return _kdrakstatusRI
            End Get
            Set(ByVal Value As SqlString)
                _kdrakstatusRI = Value
            End Set
        End Property


        Public Property [kdsuku]() As SqlString
            Get
                Return _kdsuku
            End Get
            Set(ByVal Value As SqlString)
                If Not Value.IsNull Then
                    _kdsuku = Value
                End If
            End Set
        End Property


        Public Property [namaayah]() As SqlString
            Get
                Return _namaayah
            End Get
            Set(ByVal Value As SqlString)
                If Not Value.IsNull Then
                    _namaayah = Value
                End If
            End Set
        End Property


        Public Property [kdpekerjaanAyah]() As SqlString
            Get
                Return _kdpekerjaanayah
            End Get
            Set(ByVal Value As SqlString)
                If Not Value.IsNull Then
                    _kdpekerjaanayah = Value
                End If
            End Set
        End Property


        Public Property [UmurAyah]() As SqlInt16
            Get
                Return _umurayah
            End Get
            Set(ByVal Value As SqlInt16)
                _umurayah = Value
            End Set
        End Property


        Public Property NamaIbu() As SqlString
            Get
                Return _namaibu
            End Get
            Set(ByVal Value As SqlString)
                Dim nmibutmp As SqlString = Value
                If nmibutmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("NamaIbu", "Nama Ibu can't be NULL")
                End If
                _namaibu = Value
            End Set
        End Property


        Public Property [kdpekerjaanIbu]() As SqlString
            Get
                Return _kdpekerjaanibu
            End Get
            Set(ByVal Value As SqlString)
                If Not Value.IsNull Then
                    _kdpekerjaanibu = Value
                End If
            End Set
        End Property


        Public Property [UmurIbu]() As SqlInt16
            Get
                Return _umuribu
            End Get
            Set(ByVal Value As SqlInt16)
                _umuribu = Value
            End Set
        End Property


        Public Property [nofoto]() As SqlString
            Get
                Return _nofoto
            End Get
            Set(ByVal Value As SqlString)
                If Not Value.IsNull Then
                    _nofoto = Value
                End If
            End Set
        End Property


        Public Property [JumlahRawat]() As SqlInt16
            Get
                Return _jumlahrawat
            End Get
            Set(ByVal Value As SqlInt16)
                _jumlahrawat = Value
            End Set
        End Property


        Public Property [Tglrawatakhir]() As SqlDateTime
            Get
                Return _tglrawatakhir
            End Get
            Set(ByVal Value As SqlDateTime)
                _tglrawatakhir = Value
            End Set
        End Property

        Public Property [jmlKunjunganRiRjRd]() As SqlDouble
            Get
                Return _jmlKunjunganRiRjRd
            End Get
            Set(ByVal Value As SqlDouble)
                _jmlKunjunganRiRjRd = Value
            End Set
        End Property

        Public Property [descpekerjaan]() As SqlString
            Get
                Return _descpekerjaan
            End Get
            Set(ByVal Value As SqlString)
                _descpekerjaan = Value
            End Set
        End Property
        Public Property [Photo]() As SqlString
            Get
                Return _Photo
            End Get
            Set(ByVal Value As SqlString)
                _Photo = Value
            End Set
        End Property
        Public Property [NmPhoto]() As SqlString
            Get
                Return _NmPhoto
            End Get
            Set(ByVal Value As SqlString)
                _NmPhoto = Value
            End Set
        End Property
        Public Property [descpekerjaanayah]() As SqlString
            Get
                Return _descpekerjaanayah
            End Get
            Set(ByVal Value As SqlString)
                _descpekerjaanayah = Value
            End Set
        End Property

        Public Property [descpekerjaanibu]() As SqlString
            Get
                Return _descpekerjaanibu
            End Get
            Set(ByVal Value As SqlString)
                _descpekerjaanibu = Value
            End Set
        End Property
        Public Property [strtgllahir]() As SqlString
            Get
                Return _strtgllahir
            End Get
            Set(ByVal Value As SqlString)
                _strtgllahir = Value
            End Set
        End Property

        Public Property [NmEContact]() As SqlString
            Get
                Return _NmEContact
            End Get
            Set(ByVal Value As SqlString)
                _NmEContact = Value
            End Set
        End Property
        Public Property [AlmtEContact]() As SqlString
            Get
                Return _AlmtEContact
            End Get
            Set(ByVal Value As SqlString)
                _AlmtEContact = Value
            End Set
        End Property
        Public Property [HubEContact]() As SqlString
            Get
                Return _HubEContact
            End Get
            Set(ByVal Value As SqlString)
                _HubEContact = Value
            End Set
        End Property
        Public Property [TelpEContact]() As SqlString
            Get
                Return _TelpEContact
            End Get
            Set(ByVal Value As SqlString)
                _TelpEContact = Value
            End Set
        End Property

        Public Property [Gelar]() As SqlString
            Get
                Return _gelar
            End Get
            Set(ByVal Value As SqlString)
                _gelar = Value
            End Set
        End Property

        Public Property [Alasan]() As String
            Get
                Return _alasan
            End Get
            Set(ByVal Value As String)
                _alasan = Value
            End Set
        End Property
        Public Property TinggiBadan() As SqlDecimal
            Get
                Return _tb
            End Get
            Set(value As SqlDecimal)
                _tb = value
            End Set
        End Property
        Public Property BeratBadan() As SqlDecimal
            Get
                Return _bb
            End Get
            Set(value As SqlDecimal)
                _bb = value
            End Set
        End Property
#End Region

    End Class
End Namespace
