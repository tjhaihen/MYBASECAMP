Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class aktiva
        Inherits BRInteractionBase

#Region " Class Member Declarations "

        Private _coa_eliminasi, _subl_aktiva, _subl_penyusutan, _coa_biaya, _coa_depresiasi, _coa_tanggungan, _coa_pendapatan, _subl_eliminasi, _usrupdate, _usrinsert, _subl_biaya, _subl_depresiasi, _subl_tanggungan, _subl_pendapatan, _coa_penyusutan, _kdBuku, _kdBukuOld, _kdAktiva As SqlString
        Private _tglBeli, _tglinsert, _tglupdate, _tglHitung, _tglJual As SqlDateTime
        Private _umur, _qtybeli As SqlInt32
        Private _jml_jual, _jml_beli, _Jml_akhir As SqlMoney
        Private _nmAktiva, _nov_penjualan, _coa_aktiva, _nov_pembelian, _kdMtd, _kdMtdOld, _nov_penyusutan, _keterangan, _kdlokasi, _satuan, _serialnumber As SqlString
        Private _noterima As SqlString
        Private _counterterima As SqlGuid
        Private _KSO As SqlBoolean
        Private _nmVendor, _noKontrak, _kdKelompokAktiva As SqlString

#End Region


        Public Sub New()
            ' // Nothing for now.
        End Sub


        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub


        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "dbo.[spfa_aktiva_Insert]"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add(New SqlParameter("@kdAktiva", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdAktiva))
                cmdToExecute.Parameters.Add(New SqlParameter("@nmAktiva", SqlDbType.NVarChar, 500, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nmAktiva))
                cmdToExecute.Parameters.Add(New SqlParameter("@kdBuku", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdBuku))
                cmdToExecute.Parameters.Add(New SqlParameter("@kdMtd", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdMtd))
                cmdToExecute.Parameters.Add(New SqlParameter("@nov_penyusutan", SqlDbType.NVarChar, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nov_penyusutan))
                cmdToExecute.Parameters.Add(New SqlParameter("@nov_pembelian", SqlDbType.NVarChar, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nov_pembelian))
                cmdToExecute.Parameters.Add(New SqlParameter("@nov_penjualan", SqlDbType.NVarChar, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nov_penjualan))
                cmdToExecute.Parameters.Add(New SqlParameter("@tglBeli", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tglBeli))
                cmdToExecute.Parameters.Add(New SqlParameter("@tglHitung", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tglHitung))
                cmdToExecute.Parameters.Add(New SqlParameter("@tglJual", SqlDbType.DateTime, 8, ParameterDirection.Input, True, 23, 3, "", DataRowVersion.Proposed, _tglJual))
                cmdToExecute.Parameters.Add(New SqlParameter("@jml_beli", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _jml_beli))
                cmdToExecute.Parameters.Add(New SqlParameter("@umur", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _umur))
                cmdToExecute.Parameters.Add(New SqlParameter("@jml_jual", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _jml_jual))
                cmdToExecute.Parameters.Add(New SqlParameter("@jml_akhir", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _Jml_akhir))
                cmdToExecute.Parameters.Add(New SqlParameter("@coa_aktiva", SqlDbType.Char, 35, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _coa_aktiva))
                cmdToExecute.Parameters.Add(New SqlParameter("@coa_penyusutan", SqlDbType.Char, 35, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _coa_penyusutan))
                cmdToExecute.Parameters.Add(New SqlParameter("@coa_depresiasi", SqlDbType.Char, 35, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _coa_depresiasi))
                cmdToExecute.Parameters.Add(New SqlParameter("@coa_tanggungan", SqlDbType.Char, 35, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _coa_tanggungan))
                cmdToExecute.Parameters.Add(New SqlParameter("@coa_pendapatan", SqlDbType.Char, 35, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _coa_pendapatan))
                cmdToExecute.Parameters.Add(New SqlParameter("@coa_biaya", SqlDbType.Char, 35, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _coa_biaya))
                cmdToExecute.Parameters.Add(New SqlParameter("@coa_eliminasi", SqlDbType.Char, 35, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _coa_eliminasi))
                cmdToExecute.Parameters.Add(New SqlParameter("@subl_aktiva", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _subl_aktiva))
                cmdToExecute.Parameters.Add(New SqlParameter("@subl_penyusutan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _subl_penyusutan))
                cmdToExecute.Parameters.Add(New SqlParameter("@subl_depresiasi", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _subl_depresiasi))
                cmdToExecute.Parameters.Add(New SqlParameter("@subl_tanggungan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _subl_tanggungan))
                cmdToExecute.Parameters.Add(New SqlParameter("@subl_pendapatan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _subl_pendapatan))
                cmdToExecute.Parameters.Add(New SqlParameter("@subl_biaya", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _subl_biaya))
                cmdToExecute.Parameters.Add(New SqlParameter("@subl_eliminasi", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _subl_eliminasi))
                'cmdToExecute.Parameters.Add(New SqlParameter("@tglupdate", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tglupdate))
                'cmdToExecute.Parameters.Add(New SqlParameter("@tglinsert", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tglinsert))
                cmdToExecute.Parameters.Add(New SqlParameter("@usrupdate", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _usrupdate))
                'cmdToExecute.Parameters.Add(New SqlParameter("@usrinsert", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _usrinsert))
                cmdToExecute.Parameters.Add(New SqlParameter("@keterangan", SqlDbType.NVarChar, 500, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _keterangan))
                cmdToExecute.Parameters.Add(New SqlParameter("@qtybeli", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _qtybeli))
                cmdToExecute.Parameters.Add(New SqlParameter("@kdlokasi", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdlokasi))
                cmdToExecute.Parameters.Add(New SqlParameter("@satuan", SqlDbType.NVarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _satuan))
                cmdToExecute.Parameters.Add(New SqlParameter("@serialnumber", SqlDbType.VarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _serialnumber))
                cmdToExecute.Parameters.Add(New SqlParameter("@KSO", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _KSO))
                '
                cmdToExecute.Parameters.Add(New SqlParameter("@nmvendor", SqlDbType.VarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nmVendor))
                cmdToExecute.Parameters.Add(New SqlParameter("@nokontrak", SqlDbType.VarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noKontrak))
                cmdToExecute.Parameters.Add(New SqlParameter("@kdKelompokAktiva", SqlDbType.VarChar, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdKelompokAktiva))

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                cmdToExecute.ExecuteNonQuery()
                Return True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function

        Public Function InsertAktivaDanLogistik() As Boolean
            'Dim cn As New SqlConnection(HisConfiguration.ConnectionString)
            Dim trans As SqlTransaction
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim cmdToExecute2 As SqlCommand = New SqlCommand

            With cmdToExecute
                .CommandText = "spfa_aktiva_Insert"
                .CommandType = CommandType.StoredProcedure
                '.Connection = cn
                .Parameters.Add(New SqlParameter("@kdAktiva", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdAktiva))
                .Parameters.Add(New SqlParameter("@nmAktiva", SqlDbType.NVarChar, 500, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nmAktiva))
                .Parameters.Add(New SqlParameter("@kdBuku", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdBuku))
                .Parameters.Add(New SqlParameter("@kdMtd", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdMtd))
                .Parameters.Add(New SqlParameter("@nov_penyusutan", SqlDbType.NVarChar, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nov_penyusutan))
                .Parameters.Add(New SqlParameter("@nov_pembelian", SqlDbType.NVarChar, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nov_pembelian))
                .Parameters.Add(New SqlParameter("@nov_penjualan", SqlDbType.NVarChar, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nov_penjualan))
                .Parameters.Add(New SqlParameter("@tglBeli", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tglBeli))
                .Parameters.Add(New SqlParameter("@tglHitung", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tglHitung))
                .Parameters.Add(New SqlParameter("@tglJual", SqlDbType.DateTime, 8, ParameterDirection.Input, True, 23, 3, "", DataRowVersion.Proposed, _tglJual))
                .Parameters.Add(New SqlParameter("@jml_beli", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _jml_beli))
                .Parameters.Add(New SqlParameter("@umur", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _umur))
                .Parameters.Add(New SqlParameter("@jml_jual", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _jml_jual))
                .Parameters.Add(New SqlParameter("@jml_akhir", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _Jml_akhir))
                .Parameters.Add(New SqlParameter("@coa_aktiva", SqlDbType.Char, 35, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _coa_aktiva))
                .Parameters.Add(New SqlParameter("@coa_penyusutan", SqlDbType.Char, 35, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _coa_penyusutan))
                .Parameters.Add(New SqlParameter("@coa_depresiasi", SqlDbType.Char, 35, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _coa_depresiasi))
                .Parameters.Add(New SqlParameter("@coa_tanggungan", SqlDbType.Char, 35, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _coa_tanggungan))
                .Parameters.Add(New SqlParameter("@coa_pendapatan", SqlDbType.Char, 35, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _coa_pendapatan))
                .Parameters.Add(New SqlParameter("@coa_biaya", SqlDbType.Char, 35, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _coa_biaya))
                .Parameters.Add(New SqlParameter("@coa_eliminasi", SqlDbType.Char, 35, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _coa_eliminasi))
                .Parameters.Add(New SqlParameter("@subl_aktiva", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _subl_aktiva))
                .Parameters.Add(New SqlParameter("@subl_penyusutan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _subl_penyusutan))
                .Parameters.Add(New SqlParameter("@subl_depresiasi", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _subl_depresiasi))
                .Parameters.Add(New SqlParameter("@subl_tanggungan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _subl_tanggungan))
                .Parameters.Add(New SqlParameter("@subl_pendapatan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _subl_pendapatan))
                .Parameters.Add(New SqlParameter("@subl_biaya", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _subl_biaya))
                .Parameters.Add(New SqlParameter("@subl_eliminasi", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _subl_eliminasi))
                .Parameters.Add(New SqlParameter("@usrupdate", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _usrupdate))
                .Parameters.Add(New SqlParameter("@keterangan", SqlDbType.NVarChar, 500, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _keterangan))
                .Parameters.Add(New SqlParameter("@qtybeli", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _qtybeli))
                .Parameters.Add(New SqlParameter("@satuan", SqlDbType.Char, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _satuan))
                .Parameters.Add(New SqlParameter("@kdlokasi", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdlokasi))
                .Parameters.Add(New SqlParameter("@serialnumber", SqlDbType.VarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _serialnumber))
                .Parameters.Add(New SqlParameter("@KSO", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _KSO))
                '
                cmdToExecute.Parameters.Add(New SqlParameter("@nmvendor", SqlDbType.VarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nmVendor))
                cmdToExecute.Parameters.Add(New SqlParameter("@nokontrak", SqlDbType.VarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noKontrak))
                cmdToExecute.Parameters.Add(New SqlParameter("@kdKelompokAktiva", SqlDbType.VarChar, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdKelompokAktiva))

            End With

            With cmdToExecute2
                .CommandText = "spfa_dtterimalogistik_Update"
                .CommandType = CommandType.StoredProcedure
                '.Connection = cn
                .Parameters.Add(New SqlParameter("@noterima", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noterima))
                .Parameters.Add(New SqlParameter("@counterterima", SqlDbType.UniqueIdentifier, 16, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _counterterima))
                .Parameters.Add(New SqlParameter("@kdAktiva", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdAktiva))

            End With

            ' // Open connection.
            cn.Open()
            ' // Begin Transaction
            trans = cn.BeginTransaction()

            cmdToExecute.Transaction = trans
            cmdToExecute2.Transaction = trans

            Try

                ' // Execute query.
                cmdToExecute.ExecuteNonQuery()
                cmdToExecute2.ExecuteNonQuery()

                '// Commit Transaction
                trans.Commit()
            Catch ex As Exception
                ' // Rollback all changes
                trans.Rollback()
                ExceptionManager.Publish(ex)
            Finally
                cmdToExecute.Dispose()
                cmdToExecute2.Dispose()
                'cn.Close()
                trans.Dispose()
                trans = Nothing
            End Try
        End Function

        Public Overrides Function Update() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "dbo.[spfa_aktiva_Update]"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add(New SqlParameter("@kdAktiva", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdAktiva))
                cmdToExecute.Parameters.Add(New SqlParameter("@nmAktiva", SqlDbType.NVarChar, 500, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nmAktiva))
                cmdToExecute.Parameters.Add(New SqlParameter("@kdBuku", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdBuku))
                cmdToExecute.Parameters.Add(New SqlParameter("@kdMtd", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdMtd))
                cmdToExecute.Parameters.Add(New SqlParameter("@nov_penyusutan", SqlDbType.NVarChar, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nov_penyusutan))
                cmdToExecute.Parameters.Add(New SqlParameter("@nov_pembelian", SqlDbType.NVarChar, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nov_pembelian))
                cmdToExecute.Parameters.Add(New SqlParameter("@nov_penjualan", SqlDbType.NVarChar, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nov_penjualan))
                cmdToExecute.Parameters.Add(New SqlParameter("@tglBeli", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tglBeli))
                cmdToExecute.Parameters.Add(New SqlParameter("@tglHitung", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tglHitung))
                cmdToExecute.Parameters.Add(New SqlParameter("@tglJual", SqlDbType.DateTime, 8, ParameterDirection.Input, True, 23, 3, "", DataRowVersion.Proposed, _tglJual))
                cmdToExecute.Parameters.Add(New SqlParameter("@jml_beli", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _jml_beli))
                cmdToExecute.Parameters.Add(New SqlParameter("@umur", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _umur))
                cmdToExecute.Parameters.Add(New SqlParameter("@jml_jual", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _jml_jual))
                cmdToExecute.Parameters.Add(New SqlParameter("@jml_akhir", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _Jml_akhir))
                cmdToExecute.Parameters.Add(New SqlParameter("@coa_aktiva", SqlDbType.Char, 35, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _coa_aktiva))
                cmdToExecute.Parameters.Add(New SqlParameter("@coa_penyusutan", SqlDbType.Char, 35, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _coa_penyusutan))
                cmdToExecute.Parameters.Add(New SqlParameter("@coa_depresiasi", SqlDbType.Char, 35, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _coa_depresiasi))
                cmdToExecute.Parameters.Add(New SqlParameter("@coa_tanggungan", SqlDbType.Char, 35, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _coa_tanggungan))
                cmdToExecute.Parameters.Add(New SqlParameter("@coa_pendapatan", SqlDbType.Char, 35, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _coa_pendapatan))
                cmdToExecute.Parameters.Add(New SqlParameter("@coa_biaya", SqlDbType.Char, 35, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _coa_biaya))
                cmdToExecute.Parameters.Add(New SqlParameter("@coa_eliminasi", SqlDbType.Char, 35, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _coa_eliminasi))
                cmdToExecute.Parameters.Add(New SqlParameter("@subl_aktiva", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _subl_aktiva))
                cmdToExecute.Parameters.Add(New SqlParameter("@subl_penyusutan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _subl_penyusutan))
                cmdToExecute.Parameters.Add(New SqlParameter("@subl_depresiasi", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _subl_depresiasi))
                cmdToExecute.Parameters.Add(New SqlParameter("@subl_tanggungan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _subl_tanggungan))
                cmdToExecute.Parameters.Add(New SqlParameter("@subl_pendapatan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _subl_pendapatan))
                cmdToExecute.Parameters.Add(New SqlParameter("@subl_biaya", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _subl_biaya))
                cmdToExecute.Parameters.Add(New SqlParameter("@subl_eliminasi", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _subl_eliminasi))
                cmdToExecute.Parameters.Add(New SqlParameter("@usrupdate", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _usrupdate))
                cmdToExecute.Parameters.Add(New SqlParameter("@keterangan", SqlDbType.NVarChar, 500, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _keterangan))
                cmdToExecute.Parameters.Add(New SqlParameter("@satuan", SqlDbType.Char, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _satuan))
                cmdToExecute.Parameters.Add(New SqlParameter("@qtybeli", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _qtybeli))
                cmdToExecute.Parameters.Add(New SqlParameter("@kdlokasi", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdlokasi))
                cmdToExecute.Parameters.Add(New SqlParameter("@serialnumber", SqlDbType.VarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _serialnumber))
                cmdToExecute.Parameters.Add(New SqlParameter("@KSO", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _KSO))
                '
                cmdToExecute.Parameters.Add(New SqlParameter("@nmvendor", SqlDbType.VarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nmVendor))
                cmdToExecute.Parameters.Add(New SqlParameter("@nokontrak", SqlDbType.VarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noKontrak))
                cmdToExecute.Parameters.Add(New SqlParameter("@kdKelompokAktiva", SqlDbType.VarChar, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdKelompokAktiva))

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                cmdToExecute.ExecuteNonQuery()


                Return True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function

        Public Function UpdateAktivaDanLogistik() As Boolean
            Dim cn As New SqlConnection(HisConfiguration.ConnectionString)
            Dim trans As SqlTransaction
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim cmdToExecute2 As SqlCommand = New SqlCommand

            With cmdToExecute
                .CommandText = "spfa_aktiva_Update"
                .CommandType = CommandType.StoredProcedure
                .Connection = cn
                .Parameters.Add(New SqlParameter("@kdAktiva", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdAktiva))
                .Parameters.Add(New SqlParameter("@nmAktiva", SqlDbType.NVarChar, 500, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nmAktiva))
                .Parameters.Add(New SqlParameter("@kdBuku", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdBuku))
                .Parameters.Add(New SqlParameter("@kdMtd", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdMtd))
                .Parameters.Add(New SqlParameter("@nov_penyusutan", SqlDbType.NVarChar, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nov_penyusutan))
                .Parameters.Add(New SqlParameter("@nov_pembelian", SqlDbType.NVarChar, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nov_pembelian))
                .Parameters.Add(New SqlParameter("@nov_penjualan", SqlDbType.NVarChar, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nov_penjualan))
                .Parameters.Add(New SqlParameter("@tglBeli", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tglBeli))
                .Parameters.Add(New SqlParameter("@tglHitung", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tglHitung))
                .Parameters.Add(New SqlParameter("@tglJual", SqlDbType.DateTime, 8, ParameterDirection.Input, True, 23, 3, "", DataRowVersion.Proposed, _tglJual))
                .Parameters.Add(New SqlParameter("@jml_beli", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _jml_beli))
                .Parameters.Add(New SqlParameter("@umur", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _umur))
                .Parameters.Add(New SqlParameter("@jml_jual", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _jml_jual))
                .Parameters.Add(New SqlParameter("@jml_akhir", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _Jml_akhir))
                .Parameters.Add(New SqlParameter("@coa_aktiva", SqlDbType.Char, 35, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _coa_aktiva))
                .Parameters.Add(New SqlParameter("@coa_penyusutan", SqlDbType.Char, 35, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _coa_penyusutan))
                .Parameters.Add(New SqlParameter("@coa_depresiasi", SqlDbType.Char, 35, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _coa_depresiasi))
                .Parameters.Add(New SqlParameter("@coa_tanggungan", SqlDbType.Char, 35, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _coa_tanggungan))
                .Parameters.Add(New SqlParameter("@coa_pendapatan", SqlDbType.Char, 35, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _coa_pendapatan))
                .Parameters.Add(New SqlParameter("@coa_biaya", SqlDbType.Char, 35, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _coa_biaya))
                .Parameters.Add(New SqlParameter("@coa_eliminasi", SqlDbType.Char, 35, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _coa_eliminasi))
                .Parameters.Add(New SqlParameter("@subl_aktiva", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _subl_aktiva))
                .Parameters.Add(New SqlParameter("@subl_penyusutan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _subl_penyusutan))
                .Parameters.Add(New SqlParameter("@subl_depresiasi", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _subl_depresiasi))
                .Parameters.Add(New SqlParameter("@subl_tanggungan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _subl_tanggungan))
                .Parameters.Add(New SqlParameter("@subl_pendapatan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _subl_pendapatan))
                .Parameters.Add(New SqlParameter("@subl_biaya", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _subl_biaya))
                .Parameters.Add(New SqlParameter("@subl_eliminasi", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _subl_eliminasi))
                .Parameters.Add(New SqlParameter("@usrupdate", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _usrupdate))
                .Parameters.Add(New SqlParameter("@keterangan", SqlDbType.NVarChar, 500, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _keterangan))
                .Parameters.Add(New SqlParameter("@qtybeli", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _qtybeli))
                .Parameters.Add(New SqlParameter("@satuan", SqlDbType.Char, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _satuan))
                .Parameters.Add(New SqlParameter("@kdlokasi", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdlokasi))
                .Parameters.Add(New SqlParameter("@serialnumber", SqlDbType.VarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _serialnumber))
                '
                cmdToExecute.Parameters.Add(New SqlParameter("@nmvendor", SqlDbType.VarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nmVendor))
                cmdToExecute.Parameters.Add(New SqlParameter("@nokontrak", SqlDbType.VarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noKontrak))
                cmdToExecute.Parameters.Add(New SqlParameter("@kdKelompokAktiva", SqlDbType.VarChar, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdKelompokAktiva))

            End With

            With cmdToExecute2
                .CommandText = "spfa_dtterimalogistik_Update"
                .CommandType = CommandType.StoredProcedure
                .Connection = cn
                .Parameters.Add(New SqlParameter("@noterima", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noterima))
                .Parameters.Add(New SqlParameter("@counterterima", SqlDbType.UniqueIdentifier, 16, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _counterterima))
                .Parameters.Add(New SqlParameter("@kdAktiva", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdAktiva))

            End With

            ' // Open connection.
            cn.Open()
            ' // Begin Transaction
            trans = cn.BeginTransaction()

            cmdToExecute.Transaction = trans
            cmdToExecute2.Transaction = trans

            Try

                ' // Execute query.
                cmdToExecute.ExecuteNonQuery()
                cmdToExecute2.ExecuteNonQuery()

                '// Commit Transaction
                trans.Commit()
            Catch ex As Exception
                ' // Rollback all changes
                trans.Rollback()
                ExceptionManager.Publish(ex)
            Finally
                cmdToExecute.Dispose()
                cmdToExecute2.Dispose()
                cn.Close()
                trans.Dispose()
                trans = Nothing
            End Try
        End Function

        Public Overrides Function Delete() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "dbo.[spfa_aktiva_Delete]"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add(New SqlParameter("@kdAktiva", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdAktiva))

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                cmdToExecute.ExecuteNonQuery()
                Return True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function

        Public Function DeleteAkumulasiFAAktivaByKdAktiva() As Boolean
            Dim cmdDeleteAkumulasi As SqlCommand = New SqlCommand
            cmdDeleteAkumulasi.CommandText = "dbo.[spfa_akumulasi_DeleteByKdAktiva]"
            cmdDeleteAkumulasi.CommandType = CommandType.StoredProcedure

            Dim cmdDeleteAktiva As SqlCommand = New SqlCommand
            cmdDeleteAktiva.CommandText = "dbo.[spfa_aktiva_Delete]"
            cmdDeleteAktiva.CommandType = CommandType.StoredProcedure

            Dim cmdDeleteKdAktivaLG As SqlCommand = New SqlCommand
            cmdDeleteKdAktivaLG.CommandText = "dbo.[spfa_dtterimalogistik_Delete]"
            cmdDeleteKdAktivaLG.CommandType = CommandType.StoredProcedure

            ' // Open connection.
            _mainConnection.Open()

            ' // Use base class' connection object
            cmdDeleteAkumulasi.Connection = _mainConnection
            cmdDeleteAktiva.Connection = _mainConnection
            cmdDeleteKdAktivaLG.Connection = _mainConnection

            Me.Begintrans()
            Try
                cmdDeleteAkumulasi.Parameters.Add(New SqlParameter("@kdAktiva", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdAktiva))
                cmdDeleteAkumulasi.Transaction = _transaction

                ' // Execute query.
                cmdDeleteAkumulasi.ExecuteNonQuery()

                cmdDeleteAktiva.Parameters.Add(New SqlParameter("@kdAktiva", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdAktiva))
                cmdDeleteAktiva.Transaction = _transaction

                ' // Execute query.
                cmdDeleteAktiva.ExecuteNonQuery()


                cmdDeleteKdAktivaLG.Parameters.Add(New SqlParameter("@kdAktiva", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdAktiva))

                cmdDeleteKdAktivaLG.Transaction = _transaction

                ' // Execute query.
                cmdDeleteKdAktivaLG.ExecuteNonQuery()

                Me.CommitTrans()
                Return True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                Me.RollBackTrans()
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdDeleteAkumulasi.Dispose()
                cmdDeleteAktiva.Dispose()
                cmdDeleteKdAktivaLG.Dispose()
            End Try
        End Function


        Public Overrides Function SelectOne(Optional ByVal recStatus As QISRecStatus = QISRecStatus.CurrentRecord) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Select Case recStatus
                Case QISRecStatus.CurrentRecord
                    cmdToExecute.CommandText = "dbo.[bas_AsetRegister_SelectOne]"
                Case QISRecStatus.NextRecord
                    cmdToExecute.CommandText = "dbo.[bas_AsetRegister_SelectOneNext]"
                Case QISRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "dbo.[bas_AsetRegister_SelectOnePrev]"
            End Select

            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("fa_aktiva")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add(New SqlParameter("@kdAktiva", SqlDbType.Char, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdAktiva))

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)
                If toReturn.Rows.Count > 0 Then
                    _kdAktiva = New SqlString(CType(toReturn.Rows(0)("kdAktiva"), String))
                    _nmAktiva = New SqlString(CType(toReturn.Rows(0)("nmAktiva"), String))
                    '_kdBuku = New SqlString(CType(toReturn.Rows(0)("kdBuku"), String))
                    '_kdMtd = New SqlString(CType(toReturn.Rows(0)("kdMtd"), String))
                    '_nov_penyusutan = New SqlString(CType(toReturn.Rows(0)("nov_penyusutan"), String))
                    '_nov_pembelian = New SqlString(CType(toReturn.Rows(0)("nov_pembelian"), String))
                    '_nov_penjualan = New SqlString(CType(toReturn.Rows(0)("nov_penjualan"), String))
                    _tglBeli = New SqlDateTime(CType(toReturn.Rows(0)("tglBeli"), Date))
                    '_tglHitung = New SqlDateTime(CType(toReturn.Rows(0)("tglHitung"), Date))
                    'If toReturn.Rows(0)("tglJual") Is System.DBNull.Value Then
                    '    _tglJual = SqlDateTime.Null
                    'Else
                    '    _tglJual = New SqlDateTime(CType(toReturn.Rows(0)("tglJual"), Date))
                    'End If
                    '_jml_beli = New SqlMoney(CType(toReturn.Rows(0)("jml_beli"), Decimal))
                    _umur = New SqlInt32(CType(toReturn.Rows(0)("umur"), Integer))
                    '_jml_jual = New SqlMoney(CType(toReturn.Rows(0)("jml_jual"), Decimal))
                    '_Jml_akhir = New SqlMoney(CType(toReturn.Rows(0)("jml_akhir"), Decimal))
                    '_coa_aktiva = New SqlString(CType(toReturn.Rows(0)("coa_aktiva"), String))
                    '_coa_penyusutan = New SqlString(CType(toReturn.Rows(0)("coa_penyusutan"), String))
                    '_coa_depresiasi = New SqlString(CType(toReturn.Rows(0)("coa_depresiasi"), String))
                    '_coa_tanggungan = New SqlString(CType(toReturn.Rows(0)("coa_tanggungan"), String))
                    '_coa_pendapatan = New SqlString(CType(toReturn.Rows(0)("coa_pendapatan"), String))
                    '_coa_biaya = New SqlString(CType(toReturn.Rows(0)("coa_biaya"), String))
                    '_coa_eliminasi = New SqlString(CType(toReturn.Rows(0)("coa_eliminasi"), String))
                    '_subl_aktiva = New SqlString(CType(toReturn.Rows(0)("subl_aktiva"), String))
                    '_subl_penyusutan = New SqlString(CType(toReturn.Rows(0)("subl_penyusutan"), String))
                    '_subl_depresiasi = New SqlString(CType(toReturn.Rows(0)("subl_depresiasi"), String))
                    '_subl_tanggungan = New SqlString(CType(toReturn.Rows(0)("subl_tanggungan"), String))
                    '_subl_pendapatan = New SqlString(CType(toReturn.Rows(0)("subl_pendapatan"), String))
                    '_subl_biaya = New SqlString(CType(toReturn.Rows(0)("subl_biaya"), String))
                    '_subl_eliminasi = New SqlString(CType(toReturn.Rows(0)("subl_eliminasi"), String))
                    _tglupdate = New SqlDateTime(CType(toReturn.Rows(0)("tglupdate"), Date))
                    _tglinsert = New SqlDateTime(CType(toReturn.Rows(0)("tglinsert"), Date))
                    _usrupdate = New SqlString(CType(toReturn.Rows(0)("usrupdate"), String))
                    _usrinsert = New SqlString(CType(toReturn.Rows(0)("usrinsert"), String))
                    _keterangan = New SqlString(CType(toReturn.Rows(0)("keterangan"), String))
                    '_qtybeli = New SqlInt32(CType(toReturn.Rows(0)("qtybeli"), Integer))
                    _kdlokasi = New SqlString(CType(toReturn.Rows(0)("kdlokasi"), String))
                    '_satuan = New SqlString(CType(toReturn.Rows(0)("satuan"), String))
                    _serialnumber = New SqlString(CType(toReturn.Rows(0)("serialnumber"), String))
                    '_KSO = New SqlBoolean(CType(toReturn.Rows(0)("KSO"), Boolean))
                    ''
                    '_nmVendor = New SqlString(CType(ProcessNull.GetString(toReturn.Rows(0)("nmvendor")), String))
                    '_noKontrak = New SqlString(CType(ProcessNull.GetString(toReturn.Rows(0)("nokontrak")), String))
                    '_kdKelompokAktiva = New SqlString(CType(ProcessNull.GetString(toReturn.Rows(0)("kdKelompokAktiva")), String))
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


        Public Overrides Function SelectAll() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "dbo.[spfa_aktiva_SelectAll]"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("fa_aktiva")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try

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


        Public Function SelectByKdBuku() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "dbo.[spfa_aktiva_SelectByKdBuku]"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("fa_aktiva")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add(New SqlParameter("@kdBuku", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdBuku))

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


        Public Function SelectByKdMtd() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "dbo.[spfa_aktiva_SelectByKdMtd]"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("fa_aktiva")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add(New SqlParameter("@kdMtd", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdMtd))

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

        Public Function SelectByMaxTglUpdate() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "dbo.[spfa_aktiva_SelectByMaxTglUpdate]"

            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("fa_aktiva")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)
                If toReturn.Rows.Count > 0 Then
                    _kdAktiva = New SqlString(CType(toReturn.Rows(0)("kdAktiva"), String))
                    _nmAktiva = New SqlString(CType(toReturn.Rows(0)("nmAktiva"), String))
                    _kdBuku = New SqlString(CType(toReturn.Rows(0)("kdBuku"), String))
                    _kdMtd = New SqlString(CType(toReturn.Rows(0)("kdMtd"), String))
                    _nov_penyusutan = New SqlString(CType(toReturn.Rows(0)("nov_penyusutan"), String))
                    _nov_pembelian = New SqlString(CType(toReturn.Rows(0)("nov_pembelian"), String))
                    _nov_penjualan = New SqlString(CType(toReturn.Rows(0)("nov_penjualan"), String))
                    _tglBeli = New SqlDateTime(CType(toReturn.Rows(0)("tglBeli"), Date))
                    _tglHitung = New SqlDateTime(CType(toReturn.Rows(0)("tglHitung"), Date))
                    If toReturn.Rows(0)("tglJual") Is System.DBNull.Value Then
                        _tglJual = SqlDateTime.Null
                    Else
                        _tglJual = New SqlDateTime(CType(toReturn.Rows(0)("tglJual"), Date))
                    End If
                    _jml_beli = New SqlMoney(CType(toReturn.Rows(0)("jml_beli"), Decimal))
                    _umur = New SqlInt32(CType(toReturn.Rows(0)("umur"), Integer))
                    _jml_jual = New SqlMoney(CType(toReturn.Rows(0)("jml_jual"), Decimal))
                    _Jml_akhir = New SqlMoney(CType(toReturn.Rows(0)("jml_akhir"), Decimal))
                    _coa_aktiva = New SqlString(CType(toReturn.Rows(0)("coa_aktiva"), String))
                    _coa_penyusutan = New SqlString(CType(toReturn.Rows(0)("coa_penyusutan"), String))
                    _coa_depresiasi = New SqlString(CType(toReturn.Rows(0)("coa_depresiasi"), String))
                    _coa_tanggungan = New SqlString(CType(toReturn.Rows(0)("coa_tanggungan"), String))
                    _coa_pendapatan = New SqlString(CType(toReturn.Rows(0)("coa_pendapatan"), String))
                    _coa_biaya = New SqlString(CType(toReturn.Rows(0)("coa_biaya"), String))
                    _coa_eliminasi = New SqlString(CType(toReturn.Rows(0)("coa_eliminasi"), String))
                    _subl_aktiva = New SqlString(CType(toReturn.Rows(0)("subl_aktiva"), String))
                    _subl_penyusutan = New SqlString(CType(toReturn.Rows(0)("subl_penyusutan"), String))
                    _subl_depresiasi = New SqlString(CType(toReturn.Rows(0)("subl_depresiasi"), String))
                    _subl_tanggungan = New SqlString(CType(toReturn.Rows(0)("subl_tanggungan"), String))
                    _subl_pendapatan = New SqlString(CType(toReturn.Rows(0)("subl_pendapatan"), String))
                    _subl_biaya = New SqlString(CType(toReturn.Rows(0)("subl_biaya"), String))
                    _subl_eliminasi = New SqlString(CType(toReturn.Rows(0)("subl_eliminasi"), String))
                    _tglupdate = New SqlDateTime(CType(toReturn.Rows(0)("tglupdate"), Date))
                    _tglinsert = New SqlDateTime(CType(toReturn.Rows(0)("tglinsert"), Date))
                    _usrupdate = New SqlString(CType(toReturn.Rows(0)("usrupdate"), String))
                    _usrinsert = New SqlString(CType(toReturn.Rows(0)("usrinsert"), String))
                    _keterangan = New SqlString(CType(toReturn.Rows(0)("keterangan"), String))
                    _qtybeli = New SqlInt32(CType(toReturn.Rows(0)("qtybeli"), Integer))
                    _kdlokasi = New SqlString(CType(toReturn.Rows(0)("kdlokasi"), String))
                    _satuan = New SqlString(CType(toReturn.Rows(0)("satuan"), String))
                    _serialnumber = New SqlString(CType(toReturn.Rows(0)("serialnumber"), String))
                    '
                    _nmVendor = New SqlString(CType(toReturn.Rows(0)("nmvendor"), String))
                    _noKontrak = New SqlString(CType(toReturn.Rows(0)("nokontrak"), String))
                    _kdKelompokAktiva = New SqlString(CType(toReturn.Rows(0)("kdKelompokAktiva"), String))
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

        Public ReadOnly Property NewTransactionNumber(ByVal kdPerush As String, ByVal tgbeli As Date) As SqlString
            Get
                Dim cmdToExecute As SqlCommand = New SqlCommand
                Dim strSQL As New Text.StringBuilder
                Dim sRetVal, b As String
                Dim tglbeli As Date

                cmdToExecute.CommandText = "spfa_Aktiva_GetMaxKdAktivaByKdBuku"
                cmdToExecute.CommandType = CommandType.StoredProcedure

                Dim toReturn As DataTable = New DataTable("lg_hdterima")
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

                ' // Use base class' connection object
                cmdToExecute.Connection = _mainConnection

                Try
                    cmdToExecute.Parameters.Add(New SqlParameter("@kdPerush", SqlDbType.Char, 10, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, kdPerush))
                    cmdToExecute.Parameters.Add(New SqlParameter("@kdbuku", SqlDbType.Char, 10, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _kdBuku))
                    'cmdToExecute.Parameters.Add(New SqlParameter("@kdlokasi", SqlDbType.Char, 15, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _kdlokasi))
                    cmdToExecute.Parameters.Add(New SqlParameter("@tglbeli", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tglBeli))

                    ' // Open connection.
                    _mainConnection.Open()

                    ' // Execute query.
                    adapter.Fill(toReturn)

                    If toReturn.Rows.Count > 0 Then
                        b = CType(toReturn.Rows(0)("KdAktivaMax"), String)
                        tglbeli = _tglBeli.Value

                        'If Len(Trim(b)) > 0 Then
                        '    sRetVal = kdPerush + "/" + _kdBuku.Value.Trim + "/" + _kdlokasi.Value.Trim + "/" + Format(tglbeli, "MM") + Format(tglbeli, "yy") + "/" + Format(CInt(Right(b, 6)) + 1, "0#####")
                        'Else
                        '    sRetVal = kdPerush + "/" + _kdBuku.Value.Trim + "/" + _kdlokasi.Value.Trim + "/" + Format(tglbeli, "MM") + Format(tglbeli, "yy") + "/" + Format(1, "0#####")
                        'End If

                        If Len(Trim(b)) > 0 Then
                            sRetVal = "PK4/" + Format(tglbeli, "MM") + Format(tglbeli, "yy") + "/" + Format(CInt(Right(b, 3)) + 1, "0##")
                        Else
                            sRetVal = "PK4/" + Format(tglbeli, "MM") + Format(tglbeli, "yy") + "/" + Format(1, "0##")
                        End If

                        Return New SqlString(sRetVal)
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

            End Get

        End Property

#Region " Class Property Declarations "

        Public Property [KdAktiva]() As SqlString
            Get
                Return _kdAktiva
            End Get
            Set(ByVal Value As SqlString)
                Dim kdAktivaTmp As SqlString = Value
                If kdAktivaTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("KdAktiva", "KdAktiva can't be NULL")
                End If
                _kdAktiva = Value
            End Set
        End Property


        Public Property [NmAktiva]() As SqlString
            Get
                Return _nmAktiva
            End Get
            Set(ByVal Value As SqlString)
                Dim nmAktivaTmp As SqlString = Value
                If nmAktivaTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("NmAktiva", "NmAktiva can't be NULL")
                End If
                _nmAktiva = Value
            End Set
        End Property


        Public Property [KdBuku]() As SqlString
            Get
                Return _kdBuku
            End Get
            Set(ByVal Value As SqlString)
                Dim kdBukuTmp As SqlString = Value
                If kdBukuTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("KdBuku", "KdBuku can't be NULL")
                End If
                _kdBuku = Value
            End Set
        End Property
        Public Property [KdBukuOld]() As SqlString
            Get
                Return _kdBukuOld
            End Get
            Set(ByVal Value As SqlString)
                Dim kdBukuOldTmp As SqlString = Value
                If kdBukuOldTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("KdBukuOld", "KdBukuOld can't be NULL")
                End If
                _kdBukuOld = Value
            End Set
        End Property


        Public Property [KdMtd]() As SqlString
            Get
                Return _kdMtd
            End Get
            Set(ByVal Value As SqlString)
                Dim kdMtdTmp As SqlString = Value
                If kdMtdTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("KdMtd", "KdMtd can't be NULL")
                End If
                _kdMtd = Value
            End Set
        End Property
        Public Property [KdMtdOld]() As SqlString
            Get
                Return _kdMtdOld
            End Get
            Set(ByVal Value As SqlString)
                Dim kdMtdOldTmp As SqlString = Value
                If kdMtdOldTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("KdMtdOld", "KdMtdOld can't be NULL")
                End If
                _kdMtdOld = Value
            End Set
        End Property


        Public Property [Nov_penyusutan]() As SqlString
            Get
                Return _nov_penyusutan
            End Get
            Set(ByVal Value As SqlString)
                Dim nov_penyusutanTmp As SqlString = Value
                If nov_penyusutanTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Nov_penyusutan", "Nov_penyusutan can't be NULL")
                End If
                _nov_penyusutan = Value
            End Set
        End Property


        Public Property [Nov_pembelian]() As SqlString
            Get
                Return _nov_pembelian
            End Get
            Set(ByVal Value As SqlString)
                Dim nov_pembelianTmp As SqlString = Value
                If nov_pembelianTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Nov_pembelian", "Nov_pembelian can't be NULL")
                End If
                _nov_pembelian = Value
            End Set
        End Property


        Public Property [Nov_penjualan]() As SqlString
            Get
                Return _nov_penjualan
            End Get
            Set(ByVal Value As SqlString)
                Dim nov_penjualanTmp As SqlString = Value
                If nov_penjualanTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Nov_penjualan", "Nov_penjualan can't be NULL")
                End If
                _nov_penjualan = Value
            End Set
        End Property


        Public Property [TglBeli]() As SqlDateTime
            Get
                Return _tglBeli
            End Get
            Set(ByVal Value As SqlDateTime)
                Dim tglBeliTmp As SqlDateTime = Value
                If tglBeliTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("TglBeli", "TglBeli can't be NULL")
                End If
                _tglBeli = Value
            End Set
        End Property


        Public Property [TglHitung]() As SqlDateTime
            Get
                Return _tglHitung
            End Get
            Set(ByVal Value As SqlDateTime)
                Dim tglHitungTmp As SqlDateTime = Value
                If tglHitungTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("TglHitung", "TglHitung can't be NULL")
                End If
                _tglHitung = Value
            End Set
        End Property


        Public Property [TglJual]() As SqlDateTime
            Get
                Return _tglJual
            End Get
            Set(ByVal Value As SqlDateTime)
                _tglJual = Value
            End Set
        End Property


        Public Property [Jml_beli]() As SqlMoney
            Get
                Return _jml_beli
            End Get
            Set(ByVal Value As SqlMoney)
                Dim jml_beliTmp As SqlMoney = Value
                If jml_beliTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Jml_beli", "Jml_beli can't be NULL")
                End If
                _jml_beli = Value
            End Set
        End Property


        Public Property [Umur]() As SqlInt32
            Get
                Return _umur
            End Get
            Set(ByVal Value As SqlInt32)
                Dim umurTmp As SqlInt32 = Value
                If umurTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Umur", "Umur can't be NULL")
                End If
                _umur = Value
            End Set
        End Property


        Public Property [Jml_jual]() As SqlMoney
            Get
                Return _jml_jual
            End Get
            Set(ByVal Value As SqlMoney)
                Dim jml_jualTmp As SqlMoney = Value
                If jml_jualTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Jml_jual", "Jml_jual can't be NULL")
                End If
                _jml_jual = Value
            End Set
        End Property

        Public Property [Jml_akhir]() As SqlMoney
            Get
                Return _Jml_akhir
            End Get
            Set(ByVal Value As SqlMoney)
                Dim Jml_akhirTmp As SqlMoney = Value
                If Jml_akhirTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Jml_akhir", "Jml_akhir can't be NULL")
                End If
                _Jml_akhir = Value
            End Set
        End Property


        Public Property [Coa_aktiva]() As SqlString
            Get
                Return _coa_aktiva
            End Get
            Set(ByVal Value As SqlString)
                Dim coa_aktivaTmp As SqlString = Value
                If coa_aktivaTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Coa_aktiva", "Coa_aktiva can't be NULL")
                End If
                _coa_aktiva = Value
            End Set
        End Property


        Public Property [Coa_penyusutan]() As SqlString
            Get
                Return _coa_penyusutan
            End Get
            Set(ByVal Value As SqlString)
                Dim coa_penyusutanTmp As SqlString = Value
                If coa_penyusutanTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Coa_penyusutan", "Coa_penyusutan can't be NULL")
                End If
                _coa_penyusutan = Value
            End Set
        End Property


        Public Property [Coa_depresiasi]() As SqlString
            Get
                Return _coa_depresiasi
            End Get
            Set(ByVal Value As SqlString)
                Dim coa_depresiasiTmp As SqlString = Value
                If coa_depresiasiTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Coa_depresiasi", "Coa_depresiasi can't be NULL")
                End If
                _coa_depresiasi = Value
            End Set
        End Property


        Public Property [Coa_tanggungan]() As SqlString
            Get
                Return _coa_tanggungan
            End Get
            Set(ByVal Value As SqlString)
                Dim coa_tanggunganTmp As SqlString = Value
                If coa_tanggunganTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Coa_tanggungan", "Coa_tanggungan can't be NULL")
                End If
                _coa_tanggungan = Value
            End Set
        End Property


        Public Property [Coa_pendapatan]() As SqlString
            Get
                Return _coa_pendapatan
            End Get
            Set(ByVal Value As SqlString)
                Dim coa_pendapatanTmp As SqlString = Value
                If coa_pendapatanTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Coa_pendapatan", "Coa_pendapatan can't be NULL")
                End If
                _coa_pendapatan = Value
            End Set
        End Property


        Public Property [Coa_biaya]() As SqlString
            Get
                Return _coa_biaya
            End Get
            Set(ByVal Value As SqlString)
                Dim coa_biayaTmp As SqlString = Value
                If coa_biayaTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Coa_biaya", "Coa_biaya can't be NULL")
                End If
                _coa_biaya = Value
            End Set
        End Property


        Public Property [Coa_eliminasi]() As SqlString
            Get
                Return _coa_eliminasi
            End Get
            Set(ByVal Value As SqlString)
                Dim coa_eliminasiTmp As SqlString = Value
                If coa_eliminasiTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Coa_eliminasi", "Coa_eliminasi can't be NULL")
                End If
                _coa_eliminasi = Value
            End Set
        End Property


        Public Property [Subl_aktiva]() As SqlString
            Get
                Return _subl_aktiva
            End Get
            Set(ByVal Value As SqlString)
                Dim subl_aktivaTmp As SqlString = Value
                If subl_aktivaTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Subl_aktiva", "Subl_aktiva can't be NULL")
                End If
                _subl_aktiva = Value
            End Set
        End Property


        Public Property [Subl_penyusutan]() As SqlString
            Get
                Return _subl_penyusutan
            End Get
            Set(ByVal Value As SqlString)
                Dim subl_penyusutanTmp As SqlString = Value
                If subl_penyusutanTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Subl_penyusutan", "Subl_penyusutan can't be NULL")
                End If
                _subl_penyusutan = Value
            End Set
        End Property


        Public Property [Subl_depresiasi]() As SqlString
            Get
                Return _subl_depresiasi
            End Get
            Set(ByVal Value As SqlString)
                Dim subl_depresiasiTmp As SqlString = Value
                If subl_depresiasiTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Subl_depresiasi", "Subl_depresiasi can't be NULL")
                End If
                _subl_depresiasi = Value
            End Set
        End Property


        Public Property [Subl_tanggungan]() As SqlString
            Get
                Return _subl_tanggungan
            End Get
            Set(ByVal Value As SqlString)
                Dim subl_tanggunganTmp As SqlString = Value
                If subl_tanggunganTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Subl_tanggungan", "Subl_tanggungan can't be NULL")
                End If
                _subl_tanggungan = Value
            End Set
        End Property


        Public Property [Subl_pendapatan]() As SqlString
            Get
                Return _subl_pendapatan
            End Get
            Set(ByVal Value As SqlString)
                Dim subl_pendapatanTmp As SqlString = Value
                If subl_pendapatanTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Subl_pendapatan", "Subl_pendapatan can't be NULL")
                End If
                _subl_pendapatan = Value
            End Set
        End Property


        Public Property [Subl_biaya]() As SqlString
            Get
                Return _subl_biaya
            End Get
            Set(ByVal Value As SqlString)
                Dim subl_biayaTmp As SqlString = Value
                If subl_biayaTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Subl_biaya", "Subl_biaya can't be NULL")
                End If
                _subl_biaya = Value
            End Set
        End Property


        Public Property [Subl_eliminasi]() As SqlString
            Get
                Return _subl_eliminasi
            End Get
            Set(ByVal Value As SqlString)
                Dim subl_eliminasiTmp As SqlString = Value
                If subl_eliminasiTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Subl_eliminasi", "Subl_eliminasi can't be NULL")
                End If
                _subl_eliminasi = Value
            End Set
        End Property


        Public Property [Tglupdate]() As SqlDateTime
            Get
                Return _tglupdate
            End Get
            Set(ByVal Value As SqlDateTime)
                Dim tglupdateTmp As SqlDateTime = Value
                If tglupdateTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Tglupdate", "Tglupdate can't be NULL")
                End If
                _tglupdate = Value
            End Set
        End Property


        Public Property [Tglinsert]() As SqlDateTime
            Get
                Return _tglinsert
            End Get
            Set(ByVal Value As SqlDateTime)
                Dim tglinsertTmp As SqlDateTime = Value
                If tglinsertTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Tglinsert", "Tglinsert can't be NULL")
                End If
                _tglinsert = Value
            End Set
        End Property


        Public Property [Usrupdate]() As SqlString
            Get
                Return _usrupdate
            End Get
            Set(ByVal Value As SqlString)
                Dim usrupdateTmp As SqlString = Value
                If usrupdateTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Usrupdate", "Usrupdate can't be NULL")
                End If
                _usrupdate = Value
            End Set
        End Property


        Public Property [Usrinsert]() As SqlString
            Get
                Return _usrinsert
            End Get
            Set(ByVal Value As SqlString)
                Dim usrinsertTmp As SqlString = Value
                If usrinsertTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Usrinsert", "Usrinsert can't be NULL")
                End If
                _usrinsert = Value
            End Set
        End Property

        Public Property [keterangan]() As SqlString
            Get
                Return _keterangan
            End Get
            Set(ByVal Value As SqlString)
                _keterangan = Value
            End Set
        End Property

        Public Property [QtyBeli]() As SqlInt32
            Get
                Return _qtybeli
            End Get
            Set(ByVal Value As SqlInt32)
                Dim qtybeliTmp As SqlInt32 = Value
                If qtybeliTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("QtyBeli", "QtyBeli can't be NULL")
                End If
                _qtybeli = Value
            End Set
        End Property

        Public Property [KdLokasi]() As SqlString
            Get
                Return _kdlokasi
            End Get
            Set(ByVal Value As SqlString)
                _kdlokasi = Value
            End Set
        End Property

        Public Property [Satuan]() As SqlString
            Get
                Return _satuan
            End Get
            Set(ByVal Value As SqlString)
                _satuan = Value
            End Set
        End Property

        Public Property [serialnumber]() As SqlString
            Get
                Return _serialnumber
            End Get
            Set(ByVal Value As SqlString)
                _serialnumber = Value
            End Set
        End Property

        Public Property [noterima]() As SqlString
            Get
                Return _noterima
            End Get
            Set(ByVal Value As SqlString)
                Dim noterimaTmp As SqlString = Value
                If noterimaTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("noterima", "noterima can't be NULL")
                End If
                _noterima = Value
            End Set
        End Property

        Public Property [counterTerima]() As SqlGuid
            Get
                Return _counterterima
            End Get
            Set(ByVal Value As SqlGuid)
                _counterterima = Value
            End Set
        End Property
        Public Property [KSO]() As SqlBoolean
            Get
                Return _KSO
            End Get
            Set(ByVal Value As SqlBoolean)
                _KSO = Value
            End Set
        End Property
        Public Property [NmVendor]() As SqlString
            Get
                Return _nmVendor
            End Get
            Set(ByVal Value As SqlString)
                _nmVendor = Value
            End Set
        End Property
        Public Property [NoKontrak]() As SqlString
            Get
                Return _noKontrak
            End Get
            Set(ByVal Value As SqlString)
                _noKontrak = Value
            End Set
        End Property
        Public Property [KdKelompokAktiva]() As SqlString
            Get
                Return _kdKelompokAktiva
            End Get
            Set(ByVal Value As SqlString)
                _kdKelompokAktiva = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
