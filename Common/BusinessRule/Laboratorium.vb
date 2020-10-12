Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common
'Imports QIS.Medinfras.Common

Namespace QIS.Common.BussinessRules
    Public Class Laboratorium
        Inherits BRInteractionBase

#Region " Class Member Declarations "

        Private _nolab, _jamdaftar, _kdjmbayar, _kdinstansi, _kdpengirim, _nopengirim, _noreg, _noregbbn, _norm, _normbbn, _
                    _jnpasien, _nmpengirim, _nama, _alamat, _tgllahir, _kdseks, _updater, _statuspasien, _kddokter, _kddokterPengawas, _
                    _usrinsert, _usrvalidasi, _jamselesai, _keterangan, _Catatan As SqlString
        Private _tgldaftar, _Lupdate, _tglinsert, _tglvalidasi, _tglselesai As SqlDateTime
        Private _umurtahun, _umurbulan, _umurhari As SqlInt16
        Private _batal, _posting, _validasi, _IsSemua As SqlBoolean
        Private _Ex As Exception
        Private _IsTransferLIS As Boolean

#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        'Public Overrides Function Insert() As Boolean
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    cmdToExecute.CommandText = "dbo.[splb_TransaksiHDUGD_Insert]"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nolab", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nolab))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tgldaftar", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgldaftar))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@jamdaftar", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jamdaftar))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdjmbayar", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdjmbayar))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdinstansi", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdinstansi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdpengirim", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdpengirim))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nopengirim", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nopengirim))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@batal", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _batal))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noreg))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@noregbbn", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noregbbn))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@norm", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _norm))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@normbbn", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _normbbn))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@jnpasien", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jnpasien))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nmpengirim", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nmpengirim))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nama", SqlDbType.Char, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nama))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@alamat", SqlDbType.Char, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _alamat))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tgllahir", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _tgllahir))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@umurtahun", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _umurtahun))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@umurbulan", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _umurbulan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@umurhari", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _umurhari))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdseks", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdseks))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@posting", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _posting))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Lupdate", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _Lupdate))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@updater", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _updater))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@statuspasien", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _statuspasien))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kddokter", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kddokter))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@keterangan", SqlDbType.NVarChar, 100, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _keterangan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kddokterPengawas", _kddokterPengawas))

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

        'Public Overrides Function Update() As Boolean
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    cmdToExecute.CommandText = "dbo.[splb_TransaksiHDUGD_Update]"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nolab", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nolab))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tgldaftar", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgldaftar))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@jamdaftar", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jamdaftar))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdjmbayar", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdjmbayar))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdinstansi", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdinstansi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdpengirim", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdpengirim))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nopengirim", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nopengirim))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@batal", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _batal))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noreg))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@noregbbn", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noregbbn))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@norm", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _norm))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@normbbn", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _normbbn))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@jnpasien", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jnpasien))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nmpengirim", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nmpengirim))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nama", SqlDbType.Char, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nama))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@alamat", SqlDbType.Char, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _alamat))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tgllahir", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _tgllahir))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@umurtahun", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _umurtahun))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@umurbulan", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _umurbulan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@umurhari", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _umurhari))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdseks", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdseks))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@posting", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _posting))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Lupdate", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _Lupdate))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@updater", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _updater))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@statuspasien", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _statuspasien))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kddokter", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kddokter))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@keterangan", SqlDbType.NVarChar, 100, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _keterangan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kddokterPengawas", _kddokterPengawas))

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

        'Public Function UpdateValidasi(ByVal tbl As DataTable) As Boolean
        '    Dim cn As New SqlConnection(HisConfiguration.ConnectionString)
        '    Dim cmdUpdateHD As SqlCommand = New SqlCommand   'update table header
        '    Dim strSQL_UpdateHD As New Text.StringBuilder
        '    Dim trans As SqlTransaction
        '    Dim iRecCount As Integer

        '    With strSQL_UpdateHD
        '        .Append("splb_TransaksiHDUGD_UpdateValidasi")
        '    End With

        '    With cmdUpdateHD
        '        .CommandText = strSQL_UpdateHD.ToString
        '        .CommandType = CommandType.StoredProcedure

        '        .Connection = cn
        '        .Parameters.Add(New SqlParameter("@nolab", _nolab))
        '        .Parameters.Add(New SqlParameter("@validasi", _validasi))
        '        .Parameters.Add(New SqlParameter("@tglvalidasi", _tglvalidasi))
        '        .Parameters.Add(New SqlParameter("@usrvalidasi", _usrvalidasi))
        '        .Parameters.Add(New SqlParameter("@Catatan", _Catatan))
        '    End With

        '    ' // Open connection.
        '    cn.Open()

        '    trans = cn.BeginTransaction
        '    cmdUpdateHD.Transaction = trans

        '    Try
        '        If _validasi.Value Then
        '            '// Hapus Struktur Pemeriksaan yang tidak terpakai untuk menghemat space record
        '            GetRidOfStructureRD(cn, trans, _nolab.Value)
        '        Else
        '            '// Masukkan kembali struktur yang ada 
        '            ReStructure_StrukturRD(cn, trans, tbl)
        '        End If

        '        ' // field validasi, diupdate duluan... !!
        '        cmdUpdateHD.ExecuteNonQuery()

        '        ' //  Commit the transaction
        '        trans.Commit()

        '        Return True
        '    Catch ex As Exception
        '        ' // Rollback all changes
        '        trans.Rollback()
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        trans.Dispose()
        '        trans = Nothing
        '    End Try
        'End Function

        'Public Function UpdateSelesai() As Boolean
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    cmdToExecute.CommandText = "dbo.[splb_TransaksiHdUGD_UpdateSelesai]"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nolab", _nolab))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tglselesai", _tglselesai))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@jamselesai", _jamselesai))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@updater", _updater))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Catatan", _Catatan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kddokter", _kddokter))

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

        'Public Function UpdateIsSemua() As Boolean
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    cmdToExecute.CommandText = "dbo.[splb_TransaksiHDUGD_UpdateSemua]"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nolab", _nolab))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@IsSemua", _IsSemua))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@updater", _updater))

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

        'Public Function ReStructureRD(ByVal tbl As DataTable) As Boolean
        '    Dim cn As New SqlConnection(HisConfiguration.ConnectionString)
        '    Dim trans As SqlTransaction
        '    Dim iRecCount As Integer

        '    ' // Open connection.
        '    cn.Open()

        '    trans = cn.BeginTransaction

        '    Try
        '        '// Hapus Struktur Pemeriksaan 
        '        GetRidOfStructureRD_All(cn, trans, _nolab.Value)

        '        '// Masukkan kembali struktur 
        '        ReStructure_StrukturRD_All(cn, trans, tbl)

        '        '// Hapus Hasil yang tidak terpakai 
        '        'GetRidOfUnUsedResultsRI_All(cn, trans, _nolab.Value)

        '        ' //  Commit the transaction
        '        trans.Commit()

        '        Return True
        '    Catch ex As Exception
        '        ' // Rollback all changes
        '        trans.Rollback()
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        trans.Dispose()
        '        trans = Nothing
        '    End Try
        'End Function

        'Private Sub GetRidOfStructureRD(ByVal cn As SqlConnection, ByVal trans As SqlTransaction, ByVal nolab As String)
        '    Dim kdtest As String
        '    Dim kdketerangan As String
        '    Dim nmketerangan As String
        '    Dim kdtestakhir As String
        '    Dim kdfraction As String
        '    Dim i As Integer = 1

        '    Dim cmdSelectUnusedStructure As SqlCommand = New SqlCommand

        '    With cmdSelectUnusedStructure
        '        .CommandText = "splb_strukturRD_SelectUnusedStructure"
        '        .CommandType = CommandType.StoredProcedure

        '        .Connection = cn
        '        .Transaction = trans

        '        .Parameters.Add(New SqlParameter("@nolab", SqlDbType.Char, 15, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, New SqlString(Trim(nolab))))
        '    End With

        '    Dim dtD As DataTable = New DataTable("lb_strukturUGD")
        '    Dim adapterD As SqlDataAdapter = New SqlDataAdapter(cmdSelectUnusedStructure)

        '    adapterD.Fill(dtD)

        '    While dtD.Rows.Count >= i
        '        'nolab = Trim(_noTransaksi.Value)
        '        kdtest = Trim(CType(dtD.Rows(i - 1)("kdtest"), String))
        '        'kdketerangan = Trim(CType(dtD.Rows(i - 1)("kdketerangan"), String))
        '        'nmketerangan = Trim(CType(dtD.Rows(i - 1)("nmketerangan"), String))
        '        kdtestakhir = Trim(CType(dtD.Rows(i - 1)("kdtestakhir"), String))
        '        kdfraction = Trim(CType(dtD.Rows(i - 1)("kdfraction"), String))

        '        '// Delete Unused Struktur
        '        Dim cmdDelete As SqlCommand = New SqlCommand
        '        With cmdDelete
        '            .CommandText = "splb_strukturRD_DeleteByNoLabKdTestKdTestAkhirKdFraction"
        '            .CommandType = CommandType.StoredProcedure
        '            .Connection = cn
        '            .Transaction = trans
        '            .Parameters.Add(New SqlParameter("@nolab", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, New SqlString(Trim(nolab))))
        '            .Parameters.Add(New SqlParameter("@kdtest", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, New SqlString(kdtest)))
        '            '.Parameters.Add(New SqlParameter("@kdketerangan", SqlDbType.Text, 18, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, New SqlString(kdketerangan)))
        '            '.Parameters.Add(New SqlParameter("@nmketerangan", SqlDbType.Text, 18, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, New SqlString(nmketerangan)))
        '            .Parameters.Add(New SqlParameter("@kdtestakhir", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, New SqlString(kdtestakhir)))
        '            .Parameters.Add(New SqlParameter("@kdfraction", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, New SqlString(kdfraction)))
        '            .ExecuteNonQuery()
        '        End With

        '        i += 1
        '    End While
        'End Sub

        'Private Sub GetRidOfStructureRD_All(ByVal cn As SqlConnection, ByVal trans As SqlTransaction, ByVal nolab As String)
        '    '// Delete All Struktur By NoLab
        '    Dim cmdDelete As SqlCommand = New SqlCommand
        '    With cmdDelete
        '        .CommandText = "splb_strukturRD_DeleteByNoLab"
        '        .CommandType = CommandType.StoredProcedure
        '        .Connection = cn
        '        .Transaction = trans
        '        .Parameters.Add(New SqlParameter("@nolab", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, New SqlString(Trim(nolab))))
        '        .ExecuteNonQuery()
        '    End With
        'End Sub

        'Private Sub ReStructure_StrukturRD(ByVal cn As SqlConnection, ByVal trans As SqlTransaction, ByVal tbl As DataTable)
        '    Dim nolab As String
        '    Dim kdtest As String
        '    Dim kdketerangan As String
        '    Dim nmketerangan As String
        '    Dim kdtestakhir As String
        '    Dim kdfraction As String
        '    Dim i As Integer = 1

        '    While tbl.Rows.Count >= i
        '        nolab = Trim(_nolab.Value)
        '        kdtest = Trim(CType(tbl.Rows(i - 1)("kdtest"), String))
        '        kdketerangan = Trim(CType(tbl.Rows(i - 1)("kdketerangan"), String))
        '        nmketerangan = Trim(CType(tbl.Rows(i - 1)("nmketerangan"), String))
        '        kdtestakhir = Trim(CType(tbl.Rows(i - 1)("kdtestakhir"), String))
        '        kdfraction = Trim(CType(tbl.Rows(i - 1)("kdfraction"), String))

        '        Dim cmdToExecute As SqlCommand = New SqlCommand
        '        cmdToExecute.CommandText = "splb_strukturRD_SelectByNoLabKdTestKdTestAkhirKdFraction"
        '        cmdToExecute.CommandType = CommandType.StoredProcedure
        '        With cmdToExecute
        '            .Parameters.Add(New SqlParameter("@nolab", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, New SqlString(nolab)))
        '            .Parameters.Add(New SqlParameter("@kdtest", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, New SqlString(kdtest)))
        '            .Parameters.Add(New SqlParameter("@kdtestakhir", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, New SqlString(kdtestakhir)))
        '            .Parameters.Add(New SqlParameter("@kdfraction", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, New SqlString(kdfraction)))
        '        End With
        '        cmdToExecute.Connection = cn
        '        cmdToExecute.Transaction = trans

        '        Dim toReturn As DataTable = New DataTable("lb_strukturUGD")
        '        Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '        ' // Execute query.
        '        adapter.Fill(toReturn)

        '        '// ReInsert Deleted Structure
        '        If toReturn.Rows.Count = 0 Then
        '            '// Insert Into Struktur
        '            Dim cmdInsert As SqlCommand = New SqlCommand
        '            With cmdInsert
        '                .CommandText = "splb_strukturRD_Insert"
        '                .CommandType = CommandType.StoredProcedure
        '                .Connection = cn
        '                .Transaction = trans
        '                .Parameters.Add(New SqlParameter("@nolab", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, New SqlString(nolab)))
        '                .Parameters.Add(New SqlParameter("@kdtest", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, New SqlString(kdtest)))
        '                .Parameters.Add(New SqlParameter("@kdketerangan", SqlDbType.Text, 100, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, New SqlString(kdketerangan)))
        '                .Parameters.Add(New SqlParameter("@nmketerangan", SqlDbType.Text, 100, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, New SqlString(nmketerangan)))
        '                .Parameters.Add(New SqlParameter("@kdtestakhir", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, New SqlString(kdtestakhir)))
        '                .Parameters.Add(New SqlParameter("@kdfraction", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, New SqlString(kdfraction)))
        '                .ExecuteNonQuery()
        '            End With
        '        End If

        '        i += 1
        '    End While
        'End Sub

        'Private Sub ReStructure_StrukturRD_All(ByVal cn As SqlConnection, ByVal trans As SqlTransaction, ByVal tbl As DataTable)
        '    Dim nolab As String
        '    Dim kdtest As String
        '    Dim kdketerangan As String
        '    Dim nmketerangan As String
        '    Dim kdtestakhir As String
        '    Dim kdfraction As String
        '    Dim i As Integer = 1

        '    While tbl.Rows.Count >= i
        '        nolab = Trim(_nolab.Value)
        '        kdtest = Trim(CType(tbl.Rows(i - 1)("kdtest"), String))
        '        kdketerangan = Trim(CType(tbl.Rows(i - 1)("kdketerangan"), String))
        '        nmketerangan = Trim(CType(tbl.Rows(i - 1)("nmketerangan"), String))
        '        kdtestakhir = Trim(CType(tbl.Rows(i - 1)("kdtestakhir"), String))
        '        kdfraction = Trim(CType(tbl.Rows(i - 1)("kdfraction"), String))

        '        '// Insert Into Struktur All
        '        Dim cmdInsert As SqlCommand = New SqlCommand
        '        With cmdInsert
        '            .CommandText = "splb_StrukturRD_Insert"
        '            .CommandType = CommandType.StoredProcedure
        '            .Connection = cn
        '            .Transaction = trans
        '            .Parameters.Add(New SqlParameter("@nolab", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, New SqlString(nolab)))
        '            .Parameters.Add(New SqlParameter("@kdtest", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, New SqlString(kdtest)))
        '            .Parameters.Add(New SqlParameter("@kdketerangan", SqlDbType.Text, 18, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, New SqlString(kdketerangan)))
        '            .Parameters.Add(New SqlParameter("@nmketerangan", SqlDbType.Text, 18, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, New SqlString(nmketerangan)))
        '            .Parameters.Add(New SqlParameter("@kdtestakhir", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, New SqlString(kdtestakhir)))
        '            .Parameters.Add(New SqlParameter("@kdfraction", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, New SqlString(kdfraction)))
        '            .ExecuteNonQuery()
        '        End With

        '        i += 1
        '    End While
        'End Sub

        'Public Overrides Function Delete() As Boolean
        '    Dim cn As SqlConnection = New SqlConnection(ConnectionString)
        '    Dim trans As SqlTransaction
        '    Dim retVal As Boolean

        '    cn.Open()
        '    Try

        '        trans = cn.BeginTransaction

        '        Dim cmdToExecute As SqlCommand = New SqlCommand
        '        With cmdToExecute
        '            .CommandText = "dbo.[splb_TransaksiHDUGD_Delete]"
        '            .CommandType = CommandType.StoredProcedure
        '            .Connection = cn
        '            .Transaction = trans
        '            .Parameters.Add(New SqlParameter("@nolab", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nolab))
        '        End With

        '        Dim cmdToExecuteDt As SqlCommand = New SqlCommand
        '        With cmdToExecuteDt
        '            .CommandText = "dbo.[splb_TransaksiDTUGD_DeleteByNoLab]"
        '            .CommandType = CommandType.StoredProcedure
        '            .Connection = cn
        '            .Transaction = trans
        '            .Parameters.Add(New SqlParameter("@nolab", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nolab))
        '        End With

        '        Dim cmdToExecuteRj As SqlCommand = New SqlCommand
        '        With cmdToExecuteRj
        '            .CommandText = "dbo.[splb_TransaksiRD_Rujukan_DeleteByNoLab]"
        '            .CommandType = CommandType.StoredProcedure
        '            .Connection = cn
        '            .Transaction = trans
        '            .Parameters.Add(New SqlParameter("@nolab", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nolab))
        '        End With

        '        ' // Execute query.
        '        cmdToExecuteDt.ExecuteNonQuery()
        '        cmdToExecuteRj.ExecuteNonQuery()
        '        cmdToExecute.ExecuteNonQuery()

        '        trans.Commit()

        '        retVal = True
        '    Catch ex As Exception
        '        trans.Rollback()
        '        ' // do not throw an exception, just return ..!!
        '        _Ex = ex
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        If Not cn Is Nothing Then
        '            If cn.State = ConnectionState.Open Then
        '                cn.Close()
        '            End If
        '        End If
        '        cn.Dispose()
        '        cn = Nothing
        '    End Try

        '    Return retVal
        'End Function

        'Public Overrides Function SelectOne(Optional ByVal recStatus As QISRecStatus = QISRecStatus.CurrentRecord) As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    Select Case recStatus
        '        Case QISRecStatus.CurrentRecord
        '            cmdToExecute.CommandText = "dbo.[splb_TransaksiHDUGD_SelectOne]"
        '        Case QISRecStatus.NextRecord
        '            cmdToExecute.CommandText = "dbo.[splb_TransaksiHDUGD_SelectOneNext]"
        '        Case QISRecStatus.PreviousRecord
        '            cmdToExecute.CommandText = "dbo.[splb_TransaksiHDUGD_SelectOnePrev]"
        '    End Select

        '    cmdToExecute.CommandType = CommandType.StoredProcedure
        '    Dim toReturn As DataTable = New DataTable("Fraction")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nolab", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nolab))

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        adapter.Fill(toReturn)
        '        If toReturn.Rows.Count > 0 Then
        '            _nolab = New SqlString(CType(toReturn.Rows(0)("nolab"), String))
        '            _tgldaftar = New SqlDateTime(CType(toReturn.Rows(0)("tgldaftar"), DateTime))
        '            _jamdaftar = New SqlString(CType(toReturn.Rows(0)("jamdaftar"), String))
        '            _kdjmbayar = New SqlString(CType(toReturn.Rows(0)("kdjmbayar"), String))
        '            _kdinstansi = New SqlString(CType(toReturn.Rows(0)("kdinstansi"), String))
        '            _kdpengirim = New SqlString(CType(toReturn.Rows(0)("kdpengirim"), String))
        '            _nopengirim = New SqlString(CType(toReturn.Rows(0)("nopengirim"), String))
        '            _batal = New SqlBoolean(CType(toReturn.Rows(0)("batal"), Boolean))
        '            _noreg = New SqlString(CType(toReturn.Rows(0)("noreg"), String))
        '            _noregbbn = New SqlString(CType(toReturn.Rows(0)("noregbbn"), String))
        '            _norm = New SqlString(CType(toReturn.Rows(0)("norm"), String))
        '            _normbbn = New SqlString(CType(toReturn.Rows(0)("normbbn"), String))
        '            _jnpasien = New SqlString(CType(toReturn.Rows(0)("jnpasien"), String))
        '            _nmpengirim = New SqlString(CType(toReturn.Rows(0)("nmpengirim"), String))
        '            _nama = New SqlString(CType(toReturn.Rows(0)("nama"), String))
        '            _alamat = New SqlString(CType(toReturn.Rows(0)("alamat"), String))
        '            _tgllahir = New SqlString(CType(toReturn.Rows(0)("tgllahir"), String))
        '            _umurtahun = New SqlInt16(CType(toReturn.Rows(0)("umurtahun"), Integer))
        '            _umurbulan = New SqlInt16(CType(toReturn.Rows(0)("umurbulan"), Integer))
        '            _umurhari = New SqlInt16(CType(toReturn.Rows(0)("umurhari"), Integer))
        '            _kdseks = New SqlString(CType(toReturn.Rows(0)("kdseks"), String))
        '            _posting = New SqlBoolean(CType(toReturn.Rows(0)("posting"), Boolean))
        '            _Lupdate = New SqlDateTime(CType(toReturn.Rows(0)("Lupdate"), DateTime))
        '            _updater = New SqlString(CType(toReturn.Rows(0)("updater"), String))
        '            _statuspasien = New SqlString(CType(toReturn.Rows(0)("statuspasien"), String))
        '            _kddokter = New SqlString(CType(toReturn.Rows(0)("kddokter"), String))
        '            _kddokterPengawas = New SqlString(CType(toReturn.Rows(0)("kddokterPengawas"), String))
        '            _validasi = New SqlBoolean(CType(toReturn.Rows(0)("validasi"), Boolean))
        '            _tglvalidasi = New SqlDateTime(CType(toReturn.Rows(0)("tglvalidasi"), DateTime))
        '            _usrvalidasi = New SqlString(CType(toReturn.Rows(0)("usrvalidasi"), String))
        '            _tglinsert = New SqlDateTime(CType(toReturn.Rows(0)("tglinsert"), DateTime))
        '            _usrinsert = New SqlString(CType(toReturn.Rows(0)("usrinsert"), String))
        '            _tglselesai = New SqlDateTime(CType(toReturn.Rows(0)("tglselesai"), DateTime))
        '            _jamselesai = New SqlString(CType(toReturn.Rows(0)("jamselesai"), String))
        '            _keterangan = New SqlString(CType(toReturn.Rows(0)("keterangan"), String))
        '            _Catatan = New SqlString(CType(toReturn.Rows(0)("catatan"), String))
        '            _IsSemua = New SqlBoolean(CType(toReturn.Rows(0)("IsSemua"), Boolean))
        '            _IsTransferLIS = CType(toReturn.Rows(0)("IsTransferLIS"), Boolean)
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

        'Public Function SelectTransRujukanGap() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    cmdToExecute.CommandText = "dbo.[splb_TransaksiHDRD_SelectTransRujukanGap]"

        '    cmdToExecute.CommandType = CommandType.StoredProcedure
        '    Dim toReturn As DataTable = New DataTable("Transaksi")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nolab", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nolab))

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

        'Public Function SelectByTglDaftar() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    cmdToExecute.CommandText = "dbo.[splb_TransaksiHDRD_SelectByTglDaftar]"

        '    cmdToExecute.CommandType = CommandType.StoredProcedure
        '    Dim toReturn As DataTable = New DataTable("Transaksi")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tgldaftar", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgldaftar))
        '        'cmdToExecute.Parameters.Add(New SqlParameter("@jnpasien", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jnpasien))

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

        Public Function SelectByNoreg() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "dbo.[splb_TransaksiHD_SelectByNoreg]"

            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("Transaksi")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add(New SqlParameter("@noreg", _noreg))
                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

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

        Public Function SelectForHasil() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "dbo.[splb_Hasil]"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("Hasil")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add(New SqlParameter("@nolab", _nolab))
                cmdToExecute.Parameters.Add(New SqlParameter("@noreg", _noreg))

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

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

        'Public Function SelectForRekalkulasi() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    cmdToExecute.CommandText = "dbo.[splb_ReCalculate_SelectRekapTransRD]"

        '    cmdToExecute.CommandType = CommandType.StoredProcedure
        '    Dim toReturn As DataTable = New DataTable("TransaksiRD")
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

        'Public Function SelectByNoRM() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    cmdToExecute.CommandText = "dbo.[splb_TransaksiHDRD_SelectByNoRM]"

        '    cmdToExecute.CommandType = CommandType.StoredProcedure
        '    Dim toReturn As DataTable = New DataTable("Transaksi")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@NoRM", SqlDbType.VarChar, 15, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _norm))

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

        'Public Function UpdateTranseverbyNoLab() As Boolean
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    cmdToExecute.CommandText = "dbo.[splb_UpdateTransfer_ByNoLab]"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nolab", _nolab))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@usrUpdate", _updater))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@Modul", "RD"))

        '        _mainConnection.Open()
        '        cmdToExecute.ExecuteNonQuery()
        '        Return True
        '    Catch ex As Exception
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '    End Try
        'End Function

#Region " Class Property Declarations "

        'Public ReadOnly Property NewTransactionNumber(ByVal tglTrans As Date) As SqlString
        '    Get
        '        Dim retval As String = ""
        '        Try
        '            retval = Helper.GenerateTransactionNo(_mainConnection, AppConstant.TransactionCode.TRANSAKSI_LABORATORIUM_PASIEN_RAWAT_DARURAT, tglTrans)
        '        Catch ex As Exception
        '            ExceptionManager.Publish(ex)
        '        End Try
        '        Return retval
        '    End Get
        'End Property

        Public Property [NoLab]() As SqlString
            Get
                Return _nolab
            End Get
            Set(ByVal Value As SqlString)
                Dim NoLabTmp As SqlString = Value
                If NoLabTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("NoLab", "NoLab can't be NULL")
                End If
                _nolab = Value
            End Set
        End Property

        Public Property [TglDaftar]() As SqlDateTime
            Get
                Return _tgldaftar
            End Get
            Set(ByVal Value As SqlDateTime)
                Dim TglDaftarTmp As SqlDateTime = Value
                If TglDaftarTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("TglDaftar", "TglDaftar can't be NULL")
                End If
                _tgldaftar = Value
            End Set
        End Property

        Public Property [JamDaftar]() As SqlString
            Get
                Return _jamdaftar
            End Get
            Set(ByVal Value As SqlString)
                Dim JamDaftarTmp As SqlString = Value
                If JamDaftarTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("JamDaftar", "JamDaftar can't be NULL")
                End If
                _jamdaftar = Value
            End Set
        End Property

        Public Property [KdJmBayar]() As SqlString
            Get
                Return _kdjmbayar
            End Get
            Set(ByVal Value As SqlString)
                Dim KdJmBayarTmp As SqlString = Value
                If KdJmBayarTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("KdJmBayar", "KdJmBayar can't be NULL")
                End If
                _kdjmbayar = Value
            End Set
        End Property

        Public Property [KdInstansi]() As SqlString
            Get
                Return _kdinstansi
            End Get
            Set(ByVal Value As SqlString)
                Dim KdInstansiTmp As SqlString = Value
                If KdInstansiTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("KdInstansi", "KdInstansi can't be NULL")
                End If
                _kdinstansi = Value
            End Set
        End Property

        Public Property [KdPengirim]() As SqlString
            Get
                Return _kdpengirim
            End Get
            Set(ByVal Value As SqlString)
                Dim KdPengirimTmp As SqlString = Value
                If KdPengirimTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("KdPengirim", "KdPengirim can't be NULL")
                End If
                _kdpengirim = Value
            End Set
        End Property

        Public Property [NoPengirim]() As SqlString
            Get
                Return _nopengirim
            End Get
            Set(ByVal Value As SqlString)
                Dim NoPengirimTmp As SqlString = Value
                If NoPengirimTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("NoPengirim", "NoPengirim can't be NULL")
                End If
                _nopengirim = Value
            End Set
        End Property

        Public Property [Batal]() As SqlBoolean
            Get
                Return _batal
            End Get
            Set(ByVal Value As SqlBoolean)
                _batal = Value
            End Set
        End Property

        Public Property [NoReg]() As SqlString
            Get
                Return _noreg
            End Get
            Set(ByVal Value As SqlString)
                Dim NoRegTmp As SqlString = Value
                If NoRegTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("NoReg", "NoReg can't be NULL")
                End If
                _noreg = Value
            End Set
        End Property

        Public Property [NoRegBBn]() As SqlString
            Get
                Return _noregbbn
            End Get
            Set(ByVal Value As SqlString)
                Dim NoRegBBnTmp As SqlString = Value
                If NoRegBBnTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("NoRegBBn", "NoRegBBn can't be NULL")
                End If
                _noregbbn = Value
            End Set
        End Property

        Public Property [NoRm]() As SqlString
            Get
                Return _norm
            End Get
            Set(ByVal Value As SqlString)
                Dim NoRmTmp As SqlString = Value
                If NoRmTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("NoRm", "NoRm can't be NULL")
                End If
                _norm = Value
            End Set
        End Property

        Public Property [NoRmBBn]() As SqlString
            Get
                Return _normbbn
            End Get
            Set(ByVal Value As SqlString)
                Dim NoRmBBnTmp As SqlString = Value
                If NoRmBBnTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("NoRmBBn", "NoRmBBn can't be NULL")
                End If
                _normbbn = Value
            End Set
        End Property

        Public Property [JnPasien]() As SqlString
            Get
                Return _jnpasien
            End Get
            Set(ByVal Value As SqlString)
                Dim JnPasienTmp As SqlString = Value
                If JnPasienTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("JnPasien", "JnPasien can't be NULL")
                End If
                _jnpasien = Value
            End Set
        End Property

        Public Property [NmPengirim]() As SqlString
            Get
                Return _nmpengirim
            End Get
            Set(ByVal Value As SqlString)
                Dim NmPengirimTmp As SqlString = Value
                If NmPengirimTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("NmPengirim", "NmPengirim can't be NULL")
                End If
                _nmpengirim = Value
            End Set
        End Property

        Public Property [Nama]() As SqlString
            Get
                Return _nama
            End Get
            Set(ByVal Value As SqlString)
                Dim NamaTmp As SqlString = Value
                If NamaTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Nama", "Nama can't be NULL")
                End If
                _nama = Value
            End Set
        End Property

        Public Property [Alamat]() As SqlString
            Get
                Return _alamat
            End Get
            Set(ByVal Value As SqlString)
                Dim AlamatTmp As SqlString = Value
                If AlamatTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Alamat", "Alamat can't be NULL")
                End If
                _alamat = Value
            End Set
        End Property

        Public Property [TglLahir]() As SqlString
            Get
                Return _tgllahir
            End Get
            Set(ByVal Value As SqlString)
                Dim TglLahirTmp As SqlString = Value
                If TglLahirTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("TglLahir", "TglLahir can't be NULL")
                End If
                _tgllahir = Value
            End Set
        End Property

        Public Property [UmurTahun]() As SqlInt16
            Get
                Return _umurtahun
            End Get
            Set(ByVal Value As SqlInt16)
                Dim UmurTahunTmp As SqlInt16 = Value
                If UmurTahunTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("UmurTahun", "UmurTahun can't be NULL")
                End If
                _umurtahun = Value
            End Set
        End Property

        Public Property [UmurBulan]() As SqlInt16
            Get
                Return _umurbulan
            End Get
            Set(ByVal Value As SqlInt16)
                Dim UmurBulanTmp As SqlInt16 = Value
                If UmurBulanTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("UmurBulan", "UmurBulan can't be NULL")
                End If
                _umurbulan = Value
            End Set
        End Property

        Public Property [UmurHari]() As SqlInt16
            Get
                Return _umurhari
            End Get
            Set(ByVal Value As SqlInt16)
                Dim UmurHariTmp As SqlInt16 = Value
                If UmurHariTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("UmurHari", "UmurHari can't be NULL")
                End If
                _umurhari = Value
            End Set
        End Property

        Public Property [KdSeks]() As SqlString
            Get
                Return _kdseks
            End Get
            Set(ByVal Value As SqlString)
                Dim KdSeksTmp As SqlString = Value
                If KdSeksTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("KdSeks", "KdSeks can't be NULL")
                End If
                _kdseks = Value
            End Set
        End Property

        Public Property [Posting]() As SqlBoolean
            Get
                Return _posting
            End Get
            Set(ByVal Value As SqlBoolean)
                _posting = Value
            End Set
        End Property

        Public Property [Lupdate]() As SqlDateTime
            Get
                Return _Lupdate
            End Get
            Set(ByVal Value As SqlDateTime)
                Dim LupdateTmp As SqlDateTime = Value
                If LupdateTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Lupdate", "Lupdate can't be NULL")
                End If
                _Lupdate = Value
            End Set
        End Property

        Public Property [Updater]() As SqlString
            Get
                Return _updater
            End Get
            Set(ByVal Value As SqlString)
                Dim UpdaterTmp As SqlString = Value
                If UpdaterTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Updater", "Updater can't be NULL")
                End If
                _updater = Value
            End Set
        End Property

        Public Property [StatusPasien]() As SqlString
            Get
                Return _statuspasien
            End Get
            Set(ByVal Value As SqlString)
                Dim StatusPasienTmp As SqlString = Value
                If StatusPasienTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("StatusPasien", "StatusPasien can't be NULL")
                End If
                _statuspasien = Value
            End Set
        End Property

        Public Property [KdDokter]() As SqlString
            Get
                Return _kddokter
            End Get
            Set(ByVal Value As SqlString)
                Dim KdDokterTmp As SqlString = Value
                If KdDokterTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("KdDokter", "KdDokter can't be NULL")
                End If
                _kddokter = Value
            End Set
        End Property
        Public Property [KdDokterPengawas]() As SqlString
            Get
                Return _kddokterPengawas
            End Get
            Set(ByVal Value As SqlString)
                Dim KdDokterPengawasTmp As SqlString = Value
                If KdDokterPengawasTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("KdDokterPengawas", "KdDokterPengawas can't be NULL")
                End If
                _kddokterPengawas = Value
            End Set
        End Property

        Public Property [Validasi]() As SqlBoolean
            Get
                Return _validasi
            End Get
            Set(ByVal Value As SqlBoolean)
                _validasi = Value
            End Set
        End Property

        Public Property [TglValidasi]() As SqlDateTime
            Get
                Return _tglvalidasi
            End Get
            Set(ByVal Value As SqlDateTime)
                Dim TglValidasiTmp As SqlDateTime = Value
                If TglValidasiTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("TglValidasi", "TglValidasi can't be NULL")
                End If
                _tglvalidasi = Value
            End Set
        End Property

        Public Property [UsrValidasi]() As SqlString
            Get
                Return _usrvalidasi
            End Get
            Set(ByVal Value As SqlString)
                Dim UsrValidasiTmp As SqlString = Value
                If UsrValidasiTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("UsrValidasi", "UsrValidasi can't be NULL")
                End If
                _usrvalidasi = Value
            End Set
        End Property

        Public Property [TglInsert]() As SqlDateTime
            Get
                Return _tglinsert
            End Get
            Set(ByVal Value As SqlDateTime)
                Dim tglInsertTmp As SqlDateTime = Value
                If tglInsertTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("tglInsert", "tglInsert can't be NULL")
                End If
                _tglinsert = Value
            End Set
        End Property

        Public Property [UsrInsert]() As SqlString
            Get
                Return _usrinsert
            End Get
            Set(ByVal Value As SqlString)
                Dim UsrInsertTmp As SqlString = Value
                If UsrInsertTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("UsrInsert", "UsrInsert can't be NULL")
                End If
                _usrinsert = Value
            End Set
        End Property

        Public Property tglselesai() As SqlDateTime
            Get
                Return _tglselesai
            End Get
            Set(ByVal Value As SqlDateTime)
                _tglselesai = Value
            End Set
        End Property

        Public Property jamselesai() As SqlString
            Get
                Return _jamselesai
            End Get
            Set(ByVal Value As SqlString)
                _jamselesai = Value
            End Set
        End Property

        Public Property keterangan() As SqlString
            Get
                Return _keterangan
            End Get
            Set(ByVal Value As SqlString)
                _keterangan = Value
            End Set
        End Property

        Public Property [Catatan]() As SqlString
            Get
                Return _Catatan
            End Get
            Set(ByVal Value As SqlString)
                _Catatan = Value
            End Set
        End Property

        Public Property [IsSemua]() As SqlBoolean
            Get
                Return _IsSemua
            End Get
            Set(ByVal Value As SqlBoolean)
                _IsSemua = Value
            End Set
        End Property

        Public Property [IsTransferLIS]() As Boolean
            Get
                Return _IsTransferLIS
            End Get
            Set(ByVal Value As Boolean)
                _IsTransferLIS = Value
            End Set
        End Property

#End Region

    End Class
End Namespace
