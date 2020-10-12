Option Explicit On 

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class PenunjangMedis
        Inherits BRInteractionBase


#Region " Class Member Declarations "

        Private _cito, _penyulit, _adm, _costshr, _layanvar, _nonaskes, _nonastek, _batal, _
                _posting, _piutinst, _paket, _layandiskon, _all, _bayar, _otomatis As SqlBoolean
        Private _notagih, _usrupdate, _usrinsert, _nobukti, _noreg, _jamtrans, _
                _kddokter, _kdlayan, _nobayar, _nobayar1, _
                _nobayar2, _noresep, _hasil, _kdalsdiskon, _nofoto As SqlString
        Private _tgltrans, _tglupdate, _tglinsert, _tgltagih, _tglawal, _tglakhir As SqlDateTime
        Private _komptr1, _komptr2, _komptr3, _komptr4, _
                _komptr1sl, _komptr2sl, _komptr3sl, _komptr4sl, _
                _komptr1bb, _komptr2bb, _komptr3bb, _komptr4bb, _
                _dkomptr1, _dkomptr2, _dkomptr3, _dkomptr4, _
                _tpasien, _tinstansi, _
                _amtcito, _amtcitosl, _amtcitobb, _
                _amtpenyulit, _amtpenyulitsl, _amtpenyulitbb As SqlMoney
        Private _qty, _counter As SqlDecimal
        Private _kdaktiva, _cndn As SqlString
        Private _realisasi, _IsNotCharged As SqlBoolean
        Private _kdPenunjangMedis As SqlString

#End Region


        Public Sub New()
            ' // Nothing for now.
        End Sub


        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub


        'Public Overrides Function Insert() As Boolean
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    cmdToExecute.CommandText = "dbo.[spmd_dttransaksiRD_Insert]"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nobukti", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nobukti))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noreg))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tgltrans", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgltrans))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@jamtrans", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jamtrans))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kddokter", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kddokter))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdlayan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdlayan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@qty", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 5, 0, "", DataRowVersion.Proposed, _qty))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@komptr1", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _komptr1))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@komptr2", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _komptr2))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@komptr3", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _komptr3))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@komptr4", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _komptr4))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@komptr1sl", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _komptr1sl))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@komptr2sl", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _komptr2sl))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@komptr3sl", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _komptr3sl))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@komptr4sl", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _komptr4sl))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@dkomptr1", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _dkomptr1))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@dkomptr2", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _dkomptr2))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@dkomptr3", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _dkomptr3))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@dkomptr4", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _dkomptr4))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@komptr1bb", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _komptr1bb))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@komptr2bb", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _komptr2bb))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@komptr3bb", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _komptr3bb))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@komptr4bb", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _komptr4bb))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@cito", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _cito))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@penyulit", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _penyulit))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@adm", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _adm))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@costshr", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _costshr))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@layanvar", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _layanvar))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nonaskes", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _nonaskes))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nonastek", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _nonastek))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@batal", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _batal))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@posting", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _posting))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@piutinst", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _piutinst))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@notagih", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _notagih))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tgltagih", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgltagih))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@usrinsert", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _usrinsert))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tpasien", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _tpasien))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tinstansi", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _tinstansi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@amtcito", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _amtcito))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@amtcitosl", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _amtcitosl))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@amtcitobb", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _amtcitobb))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@amtpenyulit", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _amtpenyulit))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@amtpenyulitsl", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _amtpenyulitsl))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@amtpenyulitbb", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _amtpenyulitbb))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@counter", SqlDbType.Decimal, 9, ParameterDirection.Output, True, 18, 0, "", DataRowVersion.Proposed, _counter))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@paket", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _paket))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@layandiskon", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _layandiskon))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@bayar", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _bayar))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@otomatis", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _otomatis))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@hasil", SqlDbType.Text, _hasil.Value.Length, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _hasil))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdalsdiskon", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdalsdiskon))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nofoto", SqlDbType.VarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, String.Empty))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdAktiva", SqlDbType.VarChar, 30, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdaktiva))
        '        cmdToExecute.Parameters.Add("@cndn", _cndn)
        '        cmdToExecute.Parameters.Add("@IsNotCharged", _IsNotCharged)

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        cmdToExecute.ExecuteNonQuery()
        '        '_counter = New SqlDecimal(CType(cmdToExecute.Parameters.Item("@counter").Value, Decimal))
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
        '    cmdToExecute.CommandText = "dbo.[spmd_dttransaksiRD_Update]"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nobukti", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nobukti))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noreg))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tgltrans", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgltrans))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@jamtrans", SqlDbType.Char, 5, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jamtrans))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kddokter", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kddokter))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdlayan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdlayan))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@qty", SqlDbType.Decimal, 5, ParameterDirection.Input, False, 5, 0, "", DataRowVersion.Proposed, _qty))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@komptr1", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _komptr1))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@komptr2", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _komptr2))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@komptr3", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _komptr3))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@komptr1sl", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _komptr1sl))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@komptr2sl", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _komptr2sl))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@komptr3sl", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _komptr3sl))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@dkomptr1", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _dkomptr1))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@dkomptr2", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _dkomptr2))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@dkomptr3", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _dkomptr3))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@komptr1bb", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _komptr1bb))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@komptr2bb", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _komptr2bb))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@komptr3bb", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _komptr3bb))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@cito", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _cito))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@penyulit", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _penyulit))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@adm", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _adm))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@costshr", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _costshr))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@layanvar", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _layanvar))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nonaskes", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _nonaskes))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nonastek", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _nonastek))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@batal", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _batal))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@posting", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _posting))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@piutinst", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _piutinst))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@notagih", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _notagih))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tgltagih", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgltagih))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@usrupdate", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _usrupdate))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tpasien", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _tpasien))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tinstansi", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _tinstansi))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@amtcito", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _amtcito))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@amtcitosl", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _amtcitosl))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@amtcitobb", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _amtcitobb))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@amtpenyulit", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _amtpenyulit))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@amtpenyulitsl", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _amtpenyulitsl))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@amtpenyulitbb", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _amtpenyulitbb))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@counter", SqlDbType.Decimal, 9, ParameterDirection.Input, True, 18, 0, "", DataRowVersion.Proposed, _counter))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@paket", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _paket))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@layandiskon", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _layandiskon))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@bayar", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _bayar))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nobayar", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nobayar))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nobayar1", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nobayar1))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nobayar2", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nobayar2))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@hasil", SqlDbType.Text, _hasil.Value.Length, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _hasil))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdalsdiskon", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdalsdiskon))

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

        'Public Overrides Function Delete() As Boolean
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    cmdToExecute.CommandText = "dbo.[spmd_dttransaksiRD_Delete]"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@counter", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 18, 0, "", DataRowVersion.Proposed, _counter))

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

        'Public Function DeleteDT() As Boolean
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    cmdToExecute.CommandText = "dbo.[spmd_dttransaksiRD_Delete]"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    ' // Open connection.
        '    _mainConnection.Open()

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    cmdToExecute.Parameters.Add(New SqlParameter("@counter", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 18, 0, "", DataRowVersion.Proposed, _counter))

        '    Begintrans()
        '    cmdToExecute.Transaction = _transaction

        '    Try
        '        ' // Execute query.
        '        cmdToExecute.ExecuteNonQuery()

        '        If fHeaderExistsDT() Then
        '            Me.DeleteHdFromDeleteDt()
        '        End If

        '        CommitTrans()
        '        Return True
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        RollBackTrans()
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        _transaction.Dispose()
        '    End Try
        'End Function

        'Public Function fHeaderExistsDT()
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    cmdToExecute.CommandText = "spmd_hdtransaksiRD_SelectOneExistsDT"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    Dim toReturn As DataTable = New DataTable("md_hdtransaksiRD")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection
        '    cmdToExecute.Transaction = _transaction
        '    Try
        '        cmdToExecute.Parameters.Add("@NoBukti", _nobukti)

        '        ' // Execute query.
        '        adapter.Fill(toReturn)

        '        Return (toReturn.Rows.Count = 0)
        '    Catch ex As Exception
        '        Return False
        '    Finally
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function

        'Public Function DeleteHdFromDeleteDt()
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    cmdToExecute.CommandText = "dbo.[spmd_hdtransaksiRD_delete]"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection
        '    cmdToExecute.Transaction = _transaction
        '    Try
        '        cmdToExecute.Parameters.Add("@NoBukti", _nobukti)

        '        cmdToExecute.ExecuteNonQuery()

        '        Return True
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object                
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        cmdToExecute.Dispose()
        '    End Try
        'End Function

        'Public Overrides Function SelectOne(Optional ByVal recStatus As QISRecStatus = QISRecStatus.CurrentRecord) As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    Select Case recStatus
        '        Case QISRecStatus.CurrentRecord
        '            cmdToExecute.CommandText = "dbo.[spmd_dttransaksiRD_SelectOne]"
        '        Case QISRecStatus.NextRecord
        '            cmdToExecute.CommandText = "dbo.[spmd_dttransaksiRD_SelectOneNext]"
        '        Case QISRecStatus.PreviousRecord
        '            cmdToExecute.CommandText = "dbo.[spmd_dttransaksiRD_SelectOnePrev]"
        '    End Select
        '    cmdToExecute.CommandType = CommandType.StoredProcedure
        '    Dim toReturn As DataTable = New DataTable("md_dttransaksiRD")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@counter", SqlDbType.Decimal, 9, ParameterDirection.Input, False, 18, 0, "", DataRowVersion.Proposed, _counter))

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        adapter.Fill(toReturn)
        '        If toReturn.Rows.Count > 0 Then
        '            _counter = New SqlDecimal(CType(toReturn.Rows(0)("counter"), Decimal))
        '            _nobukti = New SqlString(CType(toReturn.Rows(0)("nobukti"), String))
        '            _noreg = New SqlString(CType(toReturn.Rows(0)("noreg"), String))
        '            _tgltrans = New SqlDateTime(CType(toReturn.Rows(0)("tgltrans"), Date))
        '            _jamtrans = New SqlString(CType(toReturn.Rows(0)("jamtrans"), String))
        '            _kddokter = New SqlString(CType(toReturn.Rows(0)("kddokter"), String))
        '            _kdlayan = New SqlString(CType(toReturn.Rows(0)("kdlayan"), String))
        '            _qty = New SqlDecimal(CType(toReturn.Rows(0)("qty"), Decimal))
        '            _komptr1 = New SqlMoney(CType(toReturn.Rows(0)("komptr1"), Decimal))
        '            _komptr2 = New SqlMoney(CType(toReturn.Rows(0)("komptr2"), Decimal))
        '            _komptr3 = New SqlMoney(CType(toReturn.Rows(0)("komptr3"), Decimal))
        '            _komptr4 = New SqlMoney(CType(toReturn.Rows(0)("komptr4"), Decimal))
        '            _komptr1sl = New SqlMoney(CType(toReturn.Rows(0)("komptr1sl"), Decimal))
        '            _komptr2sl = New SqlMoney(CType(toReturn.Rows(0)("komptr2sl"), Decimal))
        '            _komptr3sl = New SqlMoney(CType(toReturn.Rows(0)("komptr3sl"), Decimal))
        '            _komptr4sl = New SqlMoney(CType(toReturn.Rows(0)("komptr4sl"), Decimal))
        '            _dkomptr1 = New SqlMoney(CType(toReturn.Rows(0)("dkomptr1"), Decimal))
        '            _dkomptr2 = New SqlMoney(CType(toReturn.Rows(0)("dkomptr2"), Decimal))
        '            _dkomptr3 = New SqlMoney(CType(toReturn.Rows(0)("dkomptr3"), Decimal))
        '            _dkomptr4 = New SqlMoney(CType(toReturn.Rows(0)("dkomptr4"), Decimal))
        '            _komptr1bb = New SqlMoney(CType(toReturn.Rows(0)("komptr1bb"), Decimal))
        '            _komptr2bb = New SqlMoney(CType(toReturn.Rows(0)("komptr2bb"), Decimal))
        '            _komptr3bb = New SqlMoney(CType(toReturn.Rows(0)("komptr3bb"), Decimal))
        '            _komptr4bb = New SqlMoney(CType(toReturn.Rows(0)("komptr4bb"), Decimal))
        '            _amtcito = New SqlMoney(CType(toReturn.Rows(0)("amtcito"), Decimal))
        '            _amtcitosl = New SqlMoney(CType(toReturn.Rows(0)("amtcitosl"), Decimal))
        '            _amtcitobb = New SqlMoney(CType(toReturn.Rows(0)("amtcitobb"), Decimal))
        '            _amtpenyulit = New SqlMoney(CType(toReturn.Rows(0)("amtpenyulit"), Decimal))
        '            _amtpenyulitsl = New SqlMoney(CType(toReturn.Rows(0)("amtpenyulitsl"), Decimal))
        '            _amtpenyulitbb = New SqlMoney(CType(toReturn.Rows(0)("amtpenyulitbb"), Decimal))
        '            _cito = New SqlBoolean(CType(toReturn.Rows(0)("cito"), Boolean))
        '            _penyulit = New SqlBoolean(CType(toReturn.Rows(0)("penyulit"), Boolean))
        '            _adm = New SqlBoolean(CType(toReturn.Rows(0)("adm"), Boolean))
        '            _costshr = New SqlBoolean(CType(toReturn.Rows(0)("costshr"), Boolean))
        '            _layanvar = New SqlBoolean(CType(toReturn.Rows(0)("layanvar"), Boolean))
        '            _nonaskes = New SqlBoolean(CType(toReturn.Rows(0)("nonaskes"), Boolean))
        '            _nonastek = New SqlBoolean(CType(toReturn.Rows(0)("nonastek"), Boolean))
        '            _batal = New SqlBoolean(CType(toReturn.Rows(0)("batal"), Boolean))
        '            _posting = New SqlBoolean(CType(toReturn.Rows(0)("posting"), Boolean))
        '            _piutinst = New SqlBoolean(CType(toReturn.Rows(0)("piutinst"), Boolean))
        '            _notagih = New SqlString(CType(toReturn.Rows(0)("notagih"), String))
        '            If toReturn.Rows(0)("tgltagih") Is System.DBNull.Value Then
        '                _tgltagih = SqlDateTime.Null
        '            Else
        '                _tgltagih = New SqlDateTime(CType(toReturn.Rows(0)("tgltagih"), Date))
        '            End If
        '            _tglupdate = New SqlDateTime(CType(toReturn.Rows(0)("tglupdate"), Date))
        '            _tglinsert = New SqlDateTime(CType(toReturn.Rows(0)("tglinsert"), Date))
        '            _usrupdate = New SqlString(CType(toReturn.Rows(0)("usrupdate"), String))
        '            _usrinsert = New SqlString(CType(toReturn.Rows(0)("usrinsert"), String))
        '            _tpasien = New SqlMoney(CType(toReturn.Rows(0)("tpasien"), Decimal))
        '            _tinstansi = New SqlMoney(CType(toReturn.Rows(0)("tinstansi"), Decimal))
        '            _paket = New SqlBoolean(CType(toReturn.Rows(0)("paket"), Boolean))
        '            _layandiskon = New SqlBoolean(CType(toReturn.Rows(0)("layandiskon"), Boolean))
        '            If toReturn.Rows(0)("noresep") Is System.DBNull.Value Then
        '                _noresep = SqlString.Null
        '            Else
        '                _noresep = New SqlString(CType(toReturn.Rows(0)("noresep"), String))
        '            End If
        '            _bayar = New SqlBoolean(CType(toReturn.Rows(0)("bayar"), Boolean))
        '            _nobayar = New SqlString(CType(toReturn.Rows(0)("nobayar"), String))
        '            _nobayar1 = New SqlString(CType(toReturn.Rows(0)("nobayar1"), String))
        '            _nobayar2 = New SqlString(CType(toReturn.Rows(0)("nobayar2"), String))
        '            _hasil = New SqlString(CType(toReturn.Rows(0)("hasil"), String))
        '            _kdalsdiskon = New SqlString(CType(toReturn.Rows(0)("kdalsdiskon"), String))
        '            _nofoto = New SqlString(CType(toReturn.Rows(0)("nofoto"), String))
        '            If toReturn.Rows(0)("kdaktiva") Is System.DBNull.Value Then
        '                _kdaktiva = New SqlString(String.Empty)
        '            Else
        '                _kdaktiva = New SqlString(CType(toReturn.Rows(0)("kdaktiva"), String))
        '            End If
        '            _cndn = New SqlString(CType(toReturn.Rows(0)("cndn"), String))
        '            _realisasi = New SqlBoolean(CType(ProcessNull.GetBoolean(toReturn.Rows(0)("realisasi")), Boolean))
        '            _IsNotCharged = New SqlBoolean(CType(ProcessNull.GetBoolean(toReturn.Rows(0)("IsNotCharged")), Boolean))
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
        '    cmdToExecute.CommandText = "dbo.[spmd_dttransaksiRD_SelectAll]"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure
        '    Dim toReturn As DataTable = New DataTable("md_dttransaksiRD")
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

        'Public Function SelectByNoBukti() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    cmdToExecute.CommandText = "dbo.[spmd_dttransaksiRD_SelectByNoBukti]"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure
        '    Dim toReturn As DataTable = New DataTable("md_dttransaksiRD")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nobukti", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nobukti))
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
        'Public Function SelectByNoBuktiKdLayan() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    cmdToExecute.CommandText = "dbo.[spmd_dttransaksiRD_SelectByNoBuktiKdLayan]"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure
        '    Dim toReturn As DataTable = New DataTable("md_dttransaksiRD")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nobukti", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nobukti))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@kdLayan", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdlayan))

        '        ' // Open connection.
        '        _mainConnection.Open()

        '        ' // Execute query.
        '        adapter.Fill(toReturn)
        '        If toReturn.Rows.Count > 0 Then
        '            _counter = New SqlDecimal(CType(toReturn.Rows(0)("counter"), Decimal))
        '            _nobukti = New SqlString(CType(toReturn.Rows(0)("nobukti"), String))
        '            _noreg = New SqlString(CType(toReturn.Rows(0)("noreg"), String))
        '            _tgltrans = New SqlDateTime(CType(toReturn.Rows(0)("tgltrans"), Date))
        '            _jamtrans = New SqlString(CType(toReturn.Rows(0)("jamtrans"), String))
        '            _kddokter = New SqlString(CType(toReturn.Rows(0)("kddokter"), String))
        '            _kdlayan = New SqlString(CType(toReturn.Rows(0)("kdlayan"), String))
        '            _qty = New SqlDecimal(CType(toReturn.Rows(0)("qty"), Decimal))
        '            _komptr1 = New SqlMoney(CType(toReturn.Rows(0)("komptr1"), Decimal))
        '            _komptr2 = New SqlMoney(CType(toReturn.Rows(0)("komptr2"), Decimal))
        '            _komptr3 = New SqlMoney(CType(toReturn.Rows(0)("komptr3"), Decimal))
        '            _komptr4 = New SqlMoney(CType(toReturn.Rows(0)("komptr4"), Decimal))
        '            _komptr1sl = New SqlMoney(CType(toReturn.Rows(0)("komptr1sl"), Decimal))
        '            _komptr2sl = New SqlMoney(CType(toReturn.Rows(0)("komptr2sl"), Decimal))
        '            _komptr3sl = New SqlMoney(CType(toReturn.Rows(0)("komptr3sl"), Decimal))
        '            _komptr4sl = New SqlMoney(CType(toReturn.Rows(0)("komptr4sl"), Decimal))
        '            _dkomptr1 = New SqlMoney(CType(toReturn.Rows(0)("dkomptr1"), Decimal))
        '            _dkomptr2 = New SqlMoney(CType(toReturn.Rows(0)("dkomptr2"), Decimal))
        '            _dkomptr3 = New SqlMoney(CType(toReturn.Rows(0)("dkomptr3"), Decimal))
        '            _dkomptr4 = New SqlMoney(CType(toReturn.Rows(0)("dkomptr4"), Decimal))
        '            _komptr1bb = New SqlMoney(CType(toReturn.Rows(0)("komptr1bb"), Decimal))
        '            _komptr2bb = New SqlMoney(CType(toReturn.Rows(0)("komptr2bb"), Decimal))
        '            _komptr3bb = New SqlMoney(CType(toReturn.Rows(0)("komptr3bb"), Decimal))
        '            _komptr4bb = New SqlMoney(CType(toReturn.Rows(0)("komptr4bb"), Decimal))
        '            _amtcito = New SqlMoney(CType(toReturn.Rows(0)("amtcito"), Decimal))
        '            _amtcitosl = New SqlMoney(CType(toReturn.Rows(0)("amtcitosl"), Decimal))
        '            _amtcitobb = New SqlMoney(CType(toReturn.Rows(0)("amtcitobb"), Decimal))
        '            _amtpenyulit = New SqlMoney(CType(toReturn.Rows(0)("amtpenyulit"), Decimal))
        '            _amtpenyulitsl = New SqlMoney(CType(toReturn.Rows(0)("amtpenyulitsl"), Decimal))
        '            _amtpenyulitbb = New SqlMoney(CType(toReturn.Rows(0)("amtpenyulitbb"), Decimal))
        '            _cito = New SqlBoolean(CType(toReturn.Rows(0)("cito"), Boolean))
        '            _penyulit = New SqlBoolean(CType(toReturn.Rows(0)("penyulit"), Boolean))
        '            _adm = New SqlBoolean(CType(toReturn.Rows(0)("adm"), Boolean))
        '            _costshr = New SqlBoolean(CType(toReturn.Rows(0)("costshr"), Boolean))
        '            _layanvar = New SqlBoolean(CType(toReturn.Rows(0)("layanvar"), Boolean))
        '            _nonaskes = New SqlBoolean(CType(toReturn.Rows(0)("nonaskes"), Boolean))
        '            _nonastek = New SqlBoolean(CType(toReturn.Rows(0)("nonastek"), Boolean))
        '            _batal = New SqlBoolean(CType(toReturn.Rows(0)("batal"), Boolean))
        '            _posting = New SqlBoolean(CType(toReturn.Rows(0)("posting"), Boolean))
        '            _piutinst = New SqlBoolean(CType(toReturn.Rows(0)("piutinst"), Boolean))
        '            _notagih = New SqlString(CType(toReturn.Rows(0)("notagih"), String))
        '            If toReturn.Rows(0)("tgltagih") Is System.DBNull.Value Then
        '                _tgltagih = SqlDateTime.Null
        '            Else
        '                _tgltagih = New SqlDateTime(CType(toReturn.Rows(0)("tgltagih"), Date))
        '            End If
        '            _tglupdate = New SqlDateTime(CType(toReturn.Rows(0)("tglupdate"), Date))
        '            _tglinsert = New SqlDateTime(CType(toReturn.Rows(0)("tglinsert"), Date))
        '            _usrupdate = New SqlString(CType(toReturn.Rows(0)("usrupdate"), String))
        '            _usrinsert = New SqlString(CType(toReturn.Rows(0)("usrinsert"), String))
        '            _tpasien = New SqlMoney(CType(toReturn.Rows(0)("tpasien"), Decimal))
        '            _tinstansi = New SqlMoney(CType(toReturn.Rows(0)("tinstansi"), Decimal))
        '            _paket = New SqlBoolean(CType(toReturn.Rows(0)("paket"), Boolean))
        '            _layandiskon = New SqlBoolean(CType(toReturn.Rows(0)("layandiskon"), Boolean))
        '            If toReturn.Rows(0)("noresep") Is System.DBNull.Value Then
        '                _noresep = SqlString.Null
        '            Else
        '                _noresep = New SqlString(CType(toReturn.Rows(0)("noresep"), String))
        '            End If
        '            _bayar = New SqlBoolean(CType(toReturn.Rows(0)("bayar"), Boolean))
        '            _nobayar = New SqlString(CType(toReturn.Rows(0)("nobayar"), String))
        '            _nobayar1 = New SqlString(CType(toReturn.Rows(0)("nobayar1"), String))
        '            _nobayar2 = New SqlString(CType(toReturn.Rows(0)("nobayar2"), String))
        '            _hasil = New SqlString(CType(toReturn.Rows(0)("hasil"), String))
        '            _kdalsdiskon = New SqlString(CType(toReturn.Rows(0)("kdalsdiskon"), String))
        '            _nofoto = New SqlString(CType(toReturn.Rows(0)("nofoto"), String))
        '            'If toReturn.Rows(0)("kdaktiva") Is System.DBNull.Value Then
        '            '    _kdaktiva = New SqlString(String.Empty)
        '            'Else
        '            '    _kdaktiva = New SqlString(CType(toReturn.Rows(0)("kdaktiva"), String))
        '            'End If
        '            '_cndn = New SqlString(CType(toReturn.Rows(0)("cndn"), String))
        '            _realisasi = New SqlBoolean(CType(ProcessNull.GetBoolean(toReturn.Rows(0)("realisasi")), Boolean))
        '            _IsNotCharged = New SqlBoolean(CType(ProcessNull.GetBoolean(toReturn.Rows(0)("IsNotCharged")), Boolean))
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

        'Public Function SelectByNoreg() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    cmdToExecute.CommandText = "dbo.[spmd_dttransaksiRD_SelectByNoreg]"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure
        '    Dim toReturn As DataTable = New DataTable("md_dttransaksiRD")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.AddWithValue("@noreg", _noreg)
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

        'Public Function SelectByNoRegTglTrans() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    cmdToExecute.CommandText = "dbo.[spmd_dttransaksird_SelectByNoRegTglTrans]"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure
        '    Dim toReturn As DataTable = New DataTable("rd_dttransaksi")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noreg))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@tgltrans", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tgltrans))

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

        'Public Function SelectByNoregBlmByr() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    cmdToExecute.CommandText = "dbo.[spmd_dttransaksiRD_SelectByNoregBlmByr]"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure
        '    Dim toReturn As DataTable = New DataTable("md_dttransaksiRD")
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

        'Public Function SelectByNoregSdhByr() As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    cmdToExecute.CommandText = "dbo.[spmd_dttransaksiRD_SelectByNoregSdhByr]"
        '    cmdToExecute.CommandType = CommandType.StoredProcedure
        '    Dim toReturn As DataTable = New DataTable("md_dttransaksiRD")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        cmdToExecute.Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noreg))
        '        cmdToExecute.Parameters.Add(New SqlParameter("@nobayar", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nobayar))

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

        Public Function SelectForDetilTransaksi() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "dbo.[spmd_dttransaksi_SelectForDetilTransaksiPerPenunjang]"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("md_dttransaksi")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noreg))
                cmdToExecute.Parameters.Add(New SqlParameter("@kdpmedis", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdPenunjangMedis))
                'cmdToExecute.Parameters.Add(New SqlParameter("@tglawal", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tglawal))
                'cmdToExecute.Parameters.Add(New SqlParameter("@tglakhir", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tglakhir))
                'cmdToExecute.Parameters.Add(New SqlParameter("@all", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _all))
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
            cmdToExecute.CommandText = "dbo.[spmd_HasilPenunjang]"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("md_dttransaksi")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add(New SqlParameter("@noreg", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noreg))
                cmdToExecute.Parameters.Add(New SqlParameter("@nobukti", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nobukti))
                'cmdToExecute.Parameters.Add(New SqlParameter("@tglawal", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tglawal))
                'cmdToExecute.Parameters.Add(New SqlParameter("@tglakhir", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, _tglakhir))
                'cmdToExecute.Parameters.Add(New SqlParameter("@all", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _all))
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

        Public Function SelectAllOtherDiagnosticSupport() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "spmd_pnjmedis_SelectAllOtherDiagnosticSupport"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("pnjmedis")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                _mainConnection.Open()

                adapter.Fill(toReturn)

                Return toReturn
            Catch ex As Exception
                ExceptionManager.Publish(ex)
            Finally
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function
#Region " Class Property Declarations "

        Public Property [KdPenunjangMedis]() As SqlString
            Get
                Return _kdPenunjangMedis
            End Get
            Set(ByVal Value As SqlString)
                Dim _temp As SqlString = Value
                If _temp.IsNull Then
                    Throw New ArgumentOutOfRangeException("KdPenunjangMedis", "KdPenunjangMedis can't be NULL")
                End If
                _kdPenunjangMedis = Value
            End Set
        End Property

        Public Property [Otomatis]() As SqlBoolean
            Get
                Return _otomatis
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim _otomatisTmp As SqlBoolean = Value
                If _otomatisTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("otomatis", "otomatis can't be NULL")
                End If
                _otomatis = Value
            End Set
        End Property

        Public Property [LayanDiskon]() As SqlBoolean
            Get
                Return _layandiskon
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim _layandiskonTmp As SqlBoolean = Value
                If _layandiskonTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("LayanDiskon", "LayanDiskon can't be NULL")
                End If
                _layandiskon = Value
            End Set
        End Property

        Public Property [Cito]() As SqlBoolean
            Get
                Return _cito
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim _citoTmp As SqlBoolean = Value
                If _citoTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Cito", "Cito can't be NULL")
                End If
                _cito = Value
            End Set
        End Property

        Public Property [Penyulit]() As SqlBoolean
            Get
                Return _penyulit
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim _penyulitTmp As SqlBoolean = Value
                If _penyulitTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Penyulit", "Penyulit can't be NULL")
                End If
                _penyulit = Value
            End Set
        End Property

        Public Property [Adm]() As SqlBoolean
            Get
                Return _adm
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim _admTmp As SqlBoolean = Value
                If _admTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Adm", "Adm can't be NULL")
                End If
                _adm = Value
            End Set
        End Property

        Public Property [Costshr]() As SqlBoolean
            Get
                Return _costshr
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim _costshrTmp As SqlBoolean = Value
                If _costshrTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Costshr", "Costshr can't be NULL")
                End If
                _costshr = Value
            End Set
        End Property

        Public Property [Layanvar]() As SqlBoolean
            Get
                Return _layanvar
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim _layanvarTmp As SqlBoolean = Value
                If _layanvarTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Layanvar", "Layanvar can't be NULL")
                End If
                _layanvar = Value
            End Set
        End Property

        Public Property [Nonaskes]() As SqlBoolean
            Get
                Return _nonaskes
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim _nonaskesTmp As SqlBoolean = Value
                If _nonaskesTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Nonaskes", "Nonaskes can't be NULL")
                End If
                _nonaskes = Value
            End Set
        End Property

        Public Property [Nonastek]() As SqlBoolean
            Get
                Return _nonastek
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim _nonastekTmp As SqlBoolean = Value
                If _nonastekTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Nonastek", "Nonastek can't be NULL")
                End If
                _nonastek = Value
            End Set
        End Property

        Public Property [Batal]() As SqlBoolean
            Get
                Return _batal
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim _batalTmp As SqlBoolean = Value
                If _batalTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Batal", "Batal can't be NULL")
                End If
                _batal = Value
            End Set
        End Property

        Public Property [Posting]() As SqlBoolean
            Get
                Return _posting
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim _postingTmp As SqlBoolean = Value
                If _postingTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Posting", "Posting can't be NULL")
                End If
                _posting = Value
            End Set
        End Property

        Public Property [Piutinst]() As SqlBoolean
            Get
                Return _piutinst
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim _piutinstTmp As SqlBoolean = Value
                If _piutinstTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Piutinst", "Piutinst can't be NULL")
                End If
                _piutinst = Value
            End Set
        End Property

        Public Property [Paket]() As SqlBoolean
            Get
                Return _paket
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim _paketTmp As SqlBoolean = Value
                If _paketTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Paket", "Paket can't be NULL")
                End If
                _paket = Value
            End Set
        End Property

        Public Property [Notagih]() As SqlString
            Get
                Return _notagih
            End Get
            Set(ByVal Value As SqlString)
                Dim _notagihTmp As SqlString = Value
                If _notagihTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Notagih", "Notagih can't be NULL")
                End If
                _notagih = Value
            End Set
        End Property

        Public Property [Hasil]() As SqlString
            Get
                Return _hasil
            End Get
            Set(ByVal Value As SqlString)
                Dim _HasilTmp As SqlString = Value
                If _HasilTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Hasil", "Hasil can't be NULL")
                End If
                _hasil = Value
            End Set
        End Property

        Public Property [Usrupdate]() As SqlString
            Get
                Return _usrupdate
            End Get
            Set(ByVal Value As SqlString)
                Dim _usrupdateTmp As SqlString = Value
                If _usrupdateTmp.IsNull Then
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
                Dim _usrinsertTmp As SqlString = Value
                If _usrinsertTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Usrinsert", "Usrinsert can't be NULL")
                End If
                _usrinsert = Value
            End Set
        End Property

        Public Property [Nobukti]() As SqlString
            Get
                Return _nobukti
            End Get
            Set(ByVal Value As SqlString)
                Dim _nobuktiTmp As SqlString = Value
                If _nobuktiTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Nobukti", "Nobukti can't be NULL")
                End If
                _nobukti = Value
            End Set
        End Property

        Public Property [Noreg]() As SqlString
            Get
                Return _noreg
            End Get
            Set(ByVal Value As SqlString)
                Dim _noregTmp As SqlString = Value
                If _noregTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Noreg", "Noreg can't be NULL")
                End If
                _noreg = Value
            End Set
        End Property

        Public Property [NoResep]() As SqlString
            Get
                Return _noresep
            End Get
            Set(ByVal Value As SqlString)
                If Not Value.IsNull Then
                    _noresep = Value
                End If
            End Set
        End Property

        Public Property [Jamtrans]() As SqlString
            Get
                Return _jamtrans
            End Get
            Set(ByVal Value As SqlString)
                Dim _jamtransTmp As SqlString = Value
                If _jamtransTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Jamtrans", "Jamtrans can't be NULL")
                End If
                _jamtrans = Value
            End Set
        End Property

        Public Property [Kddokter]() As SqlString
            Get
                Return _kddokter
            End Get
            Set(ByVal Value As SqlString)
                Dim _kddokterTmp As SqlString = Value
                If _kddokterTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Kddokter", "Kddokter can't be NULL")
                End If
                _kddokter = Value
            End Set
        End Property

        Public Property [Kdlayan]() As SqlString
            Get
                Return _kdlayan
            End Get
            Set(ByVal Value As SqlString)
                Dim _kdlayanTmp As SqlString = Value
                If _kdlayanTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Kdlayan", "Kdlayan can't be NULL")
                End If
                _kdlayan = Value
            End Set
        End Property

        Public Property [Tgltrans]() As SqlDateTime
            Get
                Return _tgltrans
            End Get
            Set(ByVal Value As SqlDateTime)
                Dim _tgltransTmp As SqlDateTime = Value
                If _tgltransTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Tgltrans", "Tgltrans can't be NULL")
                End If
                _tgltrans = New SqlDateTime(DateSerial(Value.Value.Year, Value.Value.Month, Value.Value.Day))
            End Set
        End Property

        Public Property [Tglupdate]() As SqlDateTime
            Get
                Return _tglupdate
            End Get
            Set(ByVal Value As SqlDateTime)
                Dim _tglupdateTmp As SqlDateTime = Value
                If _tglupdateTmp.IsNull Then
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
                Dim _tglinsertTmp As SqlDateTime = Value
                If _tglinsertTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Tglinsert", "Tglinsert can't be NULL")
                End If
                _tglinsert = Value
            End Set
        End Property

        Public Property [Tgltagih]() As SqlDateTime
            Get
                Return _tgltagih
            End Get
            Set(ByVal Value As SqlDateTime)
                Dim _tgltagihTmp As SqlDateTime = Value
                If _tgltagihTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Tgltagih", "Tgltagih can't be NULL")
                End If
                _tgltagih = New SqlDateTime(DateSerial(Value.Value.Year, Value.Value.Month, Value.Value.Day))
            End Set
        End Property

        Public Property [Komptr1]() As SqlMoney
            Get
                Return _komptr1
            End Get
            Set(ByVal Value As SqlMoney)
                Dim _komptr1Tmp As SqlMoney = Value
                If _komptr1Tmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Komptr1", "Komptr1 can't be NULL")
                End If
                _komptr1 = Value
            End Set
        End Property

        Public Property [Komptr2]() As SqlMoney
            Get
                Return _komptr2
            End Get
            Set(ByVal Value As SqlMoney)
                Dim _komptr2Tmp As SqlMoney = Value
                If _komptr2Tmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Komptr2", "Komptr2 can't be NULL")
                End If
                _komptr2 = Value
            End Set
        End Property

        Public Property [Komptr3]() As SqlMoney
            Get
                Return _komptr3
            End Get
            Set(ByVal Value As SqlMoney)
                Dim _komptr3Tmp As SqlMoney = Value
                If _komptr3Tmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Komptr3", "Komptr3 can't be NULL")
                End If
                _komptr3 = Value
            End Set
        End Property

        Public Property [Komptr4]() As SqlMoney
            Get
                Return _komptr4
            End Get
            Set(ByVal Value As SqlMoney)
                Dim _komptr4Tmp As SqlMoney = Value
                If _komptr4Tmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Komptr4", "Komptr4 can't be NULL")
                End If
                _komptr4 = Value
            End Set
        End Property

        Public Property [Komptr1sl]() As SqlMoney
            Get
                Return _komptr1sl
            End Get
            Set(ByVal Value As SqlMoney)
                Dim _komptr1slTmp As SqlMoney = Value
                If _komptr1slTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Komptr1sl", "Komptr1sl can't be NULL")
                End If
                _komptr1sl = Value
            End Set
        End Property

        Public Property [Komptr2sl]() As SqlMoney
            Get
                Return _komptr2sl
            End Get
            Set(ByVal Value As SqlMoney)
                Dim _komptr2slTmp As SqlMoney = Value
                If _komptr2slTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Komptr2sl", "Komptr2sl can't be NULL")
                End If
                _komptr2sl = Value
            End Set
        End Property

        Public Property [Komptr4sl]() As SqlMoney
            Get
                Return _komptr4sl
            End Get
            Set(ByVal Value As SqlMoney)
                Dim _komptr4slTmp As SqlMoney = Value
                If _komptr4slTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Komptr4sl", "Komptr4sl can't be NULL")
                End If
                _komptr4sl = Value
            End Set
        End Property

        Public Property [Komptr3bb]() As SqlMoney
            Get
                Return _komptr3bb
            End Get
            Set(ByVal Value As SqlMoney)
                Dim _komptr3bbTmp As SqlMoney = Value
                If _komptr3bbTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Komptr3bb", "Komptr3bb can't be NULL")
                End If
                _komptr3bb = Value
            End Set
        End Property

        Public Property [Komptr1bb]() As SqlMoney
            Get
                Return _komptr1bb
            End Get
            Set(ByVal Value As SqlMoney)
                Dim _komptr1bbTmp As SqlMoney = Value
                If _komptr1bbTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Komptr1bb", "Komptr1bb can't be NULL")
                End If
                _komptr1bb = Value
            End Set
        End Property

        Public Property [Komptr2bb]() As SqlMoney
            Get
                Return _komptr2bb
            End Get
            Set(ByVal Value As SqlMoney)
                Dim _komptr2bbTmp As SqlMoney = Value
                If _komptr2bbTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Komptr2bb", "Komptr2bb can't be NULL")
                End If
                _komptr2bb = Value
            End Set
        End Property

        Public Property [Komptr4bb]() As SqlMoney
            Get
                Return _komptr4bb
            End Get
            Set(ByVal Value As SqlMoney)
                Dim _komptr4bbTmp As SqlMoney = Value
                If _komptr4bbTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Komptr4bb", "Komptr4bb can't be NULL")
                End If
                _komptr4bb = Value
            End Set
        End Property

        Public Property [Komptr3sl]() As SqlMoney
            Get
                Return _komptr3sl
            End Get
            Set(ByVal Value As SqlMoney)
                Dim _komptr3slTmp As SqlMoney = Value
                If _komptr3slTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Komptr3sl", "Komptr3sl can't be NULL")
                End If
                _komptr3sl = Value
            End Set
        End Property

        Public Property [Dkomptr1]() As SqlMoney
            Get
                Return _dkomptr1
            End Get
            Set(ByVal Value As SqlMoney)
                Dim _dkomptr1Tmp As SqlMoney = Value
                If _dkomptr1Tmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Dkomptr1", "Dkomptr1 can't be NULL")
                End If
                _dkomptr1 = Value
            End Set
        End Property

        Public Property [Dkomptr2]() As SqlMoney
            Get
                Return _dkomptr2
            End Get
            Set(ByVal Value As SqlMoney)
                Dim _dkomptr2Tmp As SqlMoney = Value
                If _dkomptr2Tmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Dkomptr2", "Dkomptr2 can't be NULL")
                End If
                _dkomptr2 = Value
            End Set
        End Property

        Public Property [Dkomptr3]() As SqlMoney
            Get
                Return _dkomptr3
            End Get
            Set(ByVal Value As SqlMoney)
                Dim _dkomptr3Tmp As SqlMoney = Value
                If _dkomptr3Tmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Dkomptr3", "Dkomptr3 can't be NULL")
                End If
                _dkomptr3 = Value
            End Set
        End Property

        Public Property [Dkomptr4]() As SqlMoney
            Get
                Return _dkomptr4
            End Get
            Set(ByVal Value As SqlMoney)
                Dim _dkomptr4Tmp As SqlMoney = Value
                If _dkomptr4Tmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Dkomptr4", "Dkomptr4 can't be NULL")
                End If
                _dkomptr4 = Value
            End Set
        End Property

        Public Property [Qty]() As SqlDecimal
            Get
                Return _qty
            End Get
            Set(ByVal Value As SqlDecimal)
                Dim _qtyTmp As SqlDecimal = Value
                If _qtyTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Qty", "Qty can't be NULL")
                End If
                _qty = Value
            End Set
        End Property

        Public Property [Counter]() As SqlDecimal
            Get
                Return _counter
            End Get
            Set(ByVal Value As SqlDecimal)
                Dim _counterTmp As SqlDecimal = Value
                If _counterTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("Counter", "Counter can't be NULL")
                End If
                _counter = Value
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

        Public Property [tinstansi]() As SqlMoney
            Get
                Return _tinstansi
            End Get
            Set(ByVal Value As SqlMoney)
                _tinstansi = Value
            End Set
        End Property

        Public Property [amtcito]() As SqlMoney
            Get
                Return _amtcito
            End Get
            Set(ByVal Value As SqlMoney)
                _amtcito = Value
            End Set
        End Property

        Public Property [amtcitosl]() As SqlMoney
            Get
                Return _amtcitosl
            End Get
            Set(ByVal Value As SqlMoney)
                _amtcitosl = Value
            End Set
        End Property

        Public Property [amtcitobb]() As SqlMoney
            Get
                Return _amtcitobb
            End Get
            Set(ByVal Value As SqlMoney)
                _amtcitobb = Value
            End Set
        End Property

        Public Property [amtpenyulit]() As SqlMoney
            Get
                Return _amtpenyulit
            End Get
            Set(ByVal Value As SqlMoney)
                _amtpenyulit = Value
            End Set
        End Property

        Public Property [amtpenyulitsl]() As SqlMoney
            Get
                Return _amtpenyulitsl
            End Get
            Set(ByVal Value As SqlMoney)
                _amtpenyulitsl = Value
            End Set
        End Property

        Public Property [amtpenyulitbb]() As SqlMoney
            Get
                Return _amtpenyulitbb
            End Get
            Set(ByVal Value As SqlMoney)
                _amtpenyulitbb = Value
            End Set
        End Property

        Public Property [All]() As SqlBoolean
            Get
                Return _all
            End Get
            Set(ByVal Value As SqlBoolean)
                _all = Value
            End Set
        End Property

        Public Property [TglAwal]() As SqlDateTime
            Get
                Return _tglawal
            End Get
            Set(ByVal Value As SqlDateTime)
                _tglawal = New SqlDateTime(DateSerial(Value.Value.Year, Value.Value.Month, Value.Value.Day))
            End Set
        End Property

        Public Property [TglAkhir]() As SqlDateTime
            Get
                Return _tglakhir
            End Get
            Set(ByVal Value As SqlDateTime)
                _tglakhir = New SqlDateTime(DateSerial(Value.Value.Year, Value.Value.Month, Value.Value.Day))
            End Set
        End Property

        Public Property [bayar]() As SqlBoolean
            Get
                Return _bayar
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim _bayarTmp As SqlBoolean = Value
                If _bayarTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("bayar", "bayar can't be NULL")
                End If
                _bayar = Value
            End Set
        End Property

        Public Property [nobayar]() As SqlString
            Get
                Return _nobayar
            End Get
            Set(ByVal Value As SqlString)
                Dim _nobayarTmp As SqlString = Value
                If _nobayarTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("nobayar", "nobayar can't be NULL")
                End If
                _nobayar = Value
            End Set
        End Property

        Public Property [nobayar1]() As SqlString
            Get
                Return _nobayar1
            End Get
            Set(ByVal Value As SqlString)
                Dim _nobayar1Tmp As SqlString = Value
                If _nobayar1Tmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("nobayar1", "nobayar1 can't be NULL")
                End If
                _nobayar1 = Value
            End Set
        End Property

        Public Property [nobayar2]() As SqlString
            Get
                Return _nobayar2
            End Get
            Set(ByVal Value As SqlString)
                Dim _nobayar2Tmp As SqlString = Value
                If _nobayar2Tmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("nobayar2", "nobayar2 can't be NULL")
                End If
                _nobayar2 = Value
            End Set
        End Property

        Public Property [kdalsdiskon]() As SqlString
            Get
                Return _kdalsdiskon
            End Get
            Set(ByVal Value As SqlString)
                Dim _kdalsdiskonTmp As SqlString = Value
                If _kdalsdiskonTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kdalsdiskon", "kdalsdiskon can't be NULL")
                End If
                _kdalsdiskon = Value
            End Set
        End Property

        Public Property [nofoto]() As SqlString
            Get
                Return _nofoto
            End Get
            Set(ByVal Value As SqlString)
                Dim _nofotoTmp As SqlString = Value
                If _nofotoTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("nofoto", "nofoto can't be NULL")
                End If
                _nofoto = Value
            End Set
        End Property

        Public Property [cndn]() As SqlString
            Get
                Return _cndn
            End Get
            Set(ByVal Value As SqlString)
                _cndn = Value
            End Set
        End Property

        Public Property [kdaktiva]() As SqlString
            Get
                Return _kdaktiva
            End Get
            Set(ByVal Value As SqlString)
                _kdaktiva = Value
            End Set
        End Property

        Public Property [realisasi]() As SqlBoolean
            Get
                Return _realisasi
            End Get
            Set(ByVal Value As SqlBoolean)
                _realisasi = Value
            End Set
        End Property

        Public Property [IsNotCharged]() As SqlBoolean
            Get
                Return _IsNotCharged
            End Get
            Set(ByVal Value As SqlBoolean)
                _IsNotCharged = Value
            End Set
        End Property

#End Region


    End Class
End Namespace

