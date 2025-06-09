Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient

Imports QIS.Common

Namespace QIS.Common.BussinessRules

    Public Class PermintaanBeli
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        '----Header----
        Private _nominta, _unitminta, _unittujuan, _keterangan, _user As SqlString
        Private _tglminta, _tglapprove, _tglvalidasi As SqlDateTime
        Private _posting, _approve, _validasi As SqlBoolean

        '----Detail----
        Private _nmbarang As SqlString
        Private _qty, _saldo As SqlDecimal
        Private _tgldibutuhkan, _tglproses As SqlDateTime
        Private _proses As SqlBoolean
        Private _counter As SqlGuid
#End Region

#Region " Constructor "
        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub
#End Region

#Region " INSERT "
        Public Overloads Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "sp_hdMintaBeli_insert"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                With cmdToExecute.Parameters
                    .Add(New SqlParameter("@nominta", _nominta))
                    .Add(New SqlParameter("@unitminta", _unitminta))
                    .Add(New SqlParameter("@unittujuan", _unittujuan))
                    .Add(New SqlParameter("@tglminta", _tglminta))
                    .Add(New SqlParameter("@keterangan", _keterangan))
                    .Add(New SqlParameter("@posting", _posting))
                    .Add(New SqlParameter("@approve", _approve))
                    .Add(New SqlParameter("@validasi", _validasi))
                    .Add(New SqlParameter("@user", _user))
                End With
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

        Public Function InsertDT() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "sp_dtMintaBeli_insert"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                With cmdToExecute.Parameters
                    .Add(New SqlParameter("@nominta", _nominta))
                    '.Add(New SqlParameter("@counter", _counter))
                    .Add(New SqlParameter("@nmbarang", _nmbarang))
                    .Add(New SqlParameter("@qty", _qty))
                    .Add(New SqlParameter("@saldo", _saldo))
                    .Add(New SqlParameter("@keterangan", _keterangan))
                    .Add(New SqlParameter("@tgldibutuhkan", _tgldibutuhkan))
                    .Add(New SqlParameter("@proses", _proses))
                    .Add(New SqlParameter("@user", _user))
                End With
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
#End Region

#Region " UPDATE "
        Public Overrides Function Update() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "sp_hdMintaBeli_update"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                With cmdToExecute.Parameters
                    .Add(New SqlParameter("@nominta", _nominta))
                    .Add(New SqlParameter("@unitminta", _unitminta))
                    .Add(New SqlParameter("@unittujuan", _unittujuan))
                    .Add(New SqlParameter("@tglminta", _tglminta))
                    .Add(New SqlParameter("@keterangan", _keterangan))
                    .Add(New SqlParameter("@posting", _posting))
                    .Add(New SqlParameter("@approve", _approve))
                    .Add(New SqlParameter("@validasi", _validasi))
                    .Add(New SqlParameter("@user", _user))
                End With
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

        'Public Function UpdateStatusPosting() As Boolean
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    Dim strSQL As New Text.StringBuilder

        '    cmdToExecute.CommandText = "splg_PermintaanBeliHD_UpdatePosting"

        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        With cmdToExecute.Parameters
        '            .Add(New SqlParameter("@nomintab", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nominta))
        '            .Add(New SqlParameter("@posting", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _posting))
        '            .Add(New SqlParameter("@user", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _user))
        '        End With

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

        'Public Function UpdateStatusPostingBeli() As Boolean
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    Dim strSQL As New Text.StringBuilder

        '    cmdToExecute.CommandText = "splg_PermintaanBeliHD_UpdatePostingBeli"

        '    cmdToExecute.CommandType = CommandType.StoredProcedure

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        With cmdToExecute.Parameters
        '            .Add(New SqlParameter("@nominta", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nominta))
        '            .Add(New SqlParameter("@postingbeli", SqlDbType.Bit, 1, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _postingbeli))
        '            .Add(New SqlParameter("@user", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _user))
        '        End With

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

        Public Function UpdateDT() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "sp_dtMintaBeli_update"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                With cmdToExecute.Parameters
                    .Add(New SqlParameter("@nominta", _nominta))
                    .Add(New SqlParameter("@counter", _counter))
                    .Add(New SqlParameter("@nmbarang", _nmbarang))
                    .Add(New SqlParameter("@qty", _qty))
                    .Add(New SqlParameter("@saldo", _saldo))
                    .Add(New SqlParameter("@keterangan", _keterangan))
                    .Add(New SqlParameter("@tgldibutuhkan", _tgldibutuhkan))
                    .Add(New SqlParameter("@proses", _proses))
                    .Add(New SqlParameter("@user", _user))
                End With
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

        Public Function UpdateValidasi() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "sp_hdMintaBeli_Post"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                With cmdToExecute.Parameters
                    .Add(New SqlParameter("@nominta", _nominta))
                    .Add(New SqlParameter("@isapprove", _approve))
                    .Add(New SqlParameter("@user", _user))
                End With
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

#End Region

#Region " DELETE "

        Public Overrides Function Delete() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "sp_hdMintaBeli_delete"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add(New SqlParameter("@nominta", _nominta))

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

        Public Function DeleteDT() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "sp_dtMintaBeli_delete"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add(New SqlParameter("@counter", _counter))

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
#End Region

#Region " SELECT "
        Public Overrides Function SelectOne(Optional ByVal recStatus As QISRecStatus = QISRecStatus.CurrentRecord) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            Select Case recStatus
                Case QISRecStatus.CurrentRecord
                    cmdToExecute.CommandText = "sp_hdMintaBeli_SelectOne"

                Case QISRecStatus.NextRecord
                    cmdToExecute.CommandText = "sp_hdMintaBeli_SelectOne"

                Case QISRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "sp_hdMintaBeli_SelectOne"
            End Select

            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("hdminta")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add(New SqlParameter("@nominta", _nominta))

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _nominta = New SqlString(CType(toReturn.Rows(0)("nominta"), String))
                    _tglminta = New SqlDateTime(CType(toReturn.Rows(0)("tglminta"), Date))
                    _unitminta = New SqlString(CType(toReturn.Rows(0)("unitminta"), String))
                    _unittujuan = New SqlString(CType(toReturn.Rows(0)("unittujuan"), String))
                    _keterangan = New SqlString(CType(toReturn.Rows(0)("keterangan"), String))
                    _posting = New SqlBoolean(CType(toReturn.Rows(0)("posting"), Boolean))
                    _approve = New SqlBoolean(CType(toReturn.Rows(0)("approve"), Boolean))
                    _validasi = New SqlBoolean(CType(toReturn.Rows(0)("validasi"), Boolean))
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

            cmdToExecute.CommandText = "splg_PermintaanBeliHD_SelectAll"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("lg_hdminta")
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

        Public Function SelectOneDT() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "sp_dtMintaBeli_SelectOne"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("dtminta")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add(New SqlParameter("@counter", _counter))

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _nominta = New SqlString(CType(toReturn.Rows(0)("nominta"), String))
                    _counter = New SqlGuid(CType(toReturn.Rows(0)("counter"), Guid))
                    _nmbarang = New SqlString(CType(toReturn.Rows(0)("nmbarang"), String))
                    _keterangan = New SqlString(CType(toReturn.Rows(0)("keterangan"), String))
                    _qty = New SqlDecimal(CType(toReturn.Rows(0)("qty"), Decimal))
                    _saldo = New SqlDecimal(CType(toReturn.Rows(0)("saldo"), Decimal))
                    _tgldibutuhkan = New SqlDateTime(CType(toReturn.Rows(0)("tgldibutuhkan"), Date))
                    _proses = New SqlBoolean(CType(toReturn.Rows(0)("proses"), Boolean))
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

        Public Function SelectByNo() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "sp_MintaBeli_SelectByNo"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("minta")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add(New SqlParameter("@nominta", _nominta))

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _nominta = New SqlString(CType(toReturn.Rows(0)("nominta"), String))
                    _counter = New SqlGuid(CType(toReturn.Rows(0)("counter"), Guid))
                    _nmbarang = New SqlString(CType(toReturn.Rows(0)("nmbarang"), String))
                    _keterangan = New SqlString(CType(toReturn.Rows(0)("keterangan"), String))
                    _qty = New SqlDecimal(CType(toReturn.Rows(0)("qty"), Decimal))
                    _saldo = New SqlDecimal(CType(toReturn.Rows(0)("saldo"), Decimal))
                    _tgldibutuhkan = New SqlDateTime(CType(toReturn.Rows(0)("tgldibutuhkan"), Date))
                    _proses = New SqlBoolean(CType(toReturn.Rows(0)("proses"), Boolean))
                    _user = New SqlString(CType(toReturn.Rows(0)("nmuser"), String))
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

        Public Function SelectByNoProses() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "sp_MintaBeli_SelectByNoProses"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("mintabeli")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add(New SqlParameter("@nominta", _nominta))

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

#End Region

#Region " Class Property Declarations "
        Public ReadOnly Property NewTransactionNumber(ByVal tglTrans As Date) As SqlString
            Get
                Dim cmdToExecute As SqlCommand = New SqlCommand
                Dim strSQL As New Text.StringBuilder
                Dim sRetVal, b As String

                cmdToExecute.CommandText = "sp_MintaBeli_GetMaxNoMinta"
                cmdToExecute.CommandType = CommandType.StoredProcedure

                Dim toReturn As DataTable = New DataTable("lg_hdminta")
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

                ' // Use base class' connection object
                cmdToExecute.Connection = _mainConnection

                Try
                    cmdToExecute.Parameters.Add(New SqlParameter("@datgltrans", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 23, 3, "", DataRowVersion.Proposed, tglTrans))

                    ' // Open connection.
                    _mainConnection.Open()

                    ' // Execute query.
                    adapter.Fill(toReturn)

                    If toReturn.Rows.Count > 0 Then
                        b = CType(toReturn.Rows(0)("noMintaMax"), String)

                        If Len(Trim(b)) > 0 Then
                            sRetVal = "PP/QIS/" + Format(tglTrans, "yyyy") + "/" + Format(tglTrans, "MM") + "/" + Format(CInt(Right(b, 3)) + 1, "0##")
                        Else
                            sRetVal = "PP/QIS/" + Format(tglTrans, "yyyy") + "/" + Format(tglTrans, "MM") + "/" + Format(1, "0##")
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

        Public Property [nominta]() As SqlString
            Get
                Return _nominta
            End Get
            Set(ByVal Value As SqlString)
                Dim nomintaTmp As SqlString = Value
                If nomintaTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("nominta", "nominta can't be NULL")
                End If
                _nominta = Value
            End Set
        End Property

        Public Property [tglminta]() As SqlDateTime
            Get
                Return _tglminta
            End Get
            Set(ByVal Value As SqlDateTime)
                Dim tglmintaTmp As SqlDateTime = Value
                If tglmintaTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("tglminta", "tglminta can't be NULL")
                End If
                _tglminta = Value
            End Set
        End Property

        Public Property [UnitMinta]() As SqlString
            Get
                Return _unitminta
            End Get
            Set(ByVal Value As SqlString)
                Dim unitmintaTmp As SqlString = Value
                If unitmintaTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("unitminta", "unitminta can't be NULL")
                End If
                _unitminta = Value
            End Set
        End Property

        Public Property [unittujuan]() As SqlString
            Get
                Return _unittujuan
            End Get
            Set(ByVal Value As SqlString)
                Dim unittujuanTmp As SqlString = Value
                If unittujuanTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("unittujuan", "unittujuan can't be NULL")
                End If
                _unittujuan = Value
            End Set
        End Property

        Public Property [Keterangan]() As SqlString
            Get
                Return _keterangan
            End Get
            Set(ByVal Value As SqlString)
                _keterangan = Value
            End Set
        End Property

        Public Property [User]() As SqlString
            Get
                Return _user
            End Get
            Set(ByVal Value As SqlString)
                Dim userTmp As SqlString = Value
                If userTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("user", "user can't be NULL")
                End If
                _user = Value
            End Set
        End Property

        Public Property [posting]() As SqlBoolean
            Get
                Return _posting
            End Get
            Set(ByVal Value As SqlBoolean)
                _posting = Value
            End Set
        End Property

        Public Property [Approve]() As SqlBoolean
            Get
                Return _approve
            End Get
            Set(ByVal Value As SqlBoolean)
                _approve = Value
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

        Public Property [Counter]() As SqlGuid
            Get
                Return _counter
            End Get
            Set(ByVal Value As SqlGuid)
                _counter = Value
            End Set
        End Property

        Public Property [NamaBarang]() As SqlString
            Get
                Return _nmbarang
            End Get
            Set(ByVal Value As SqlString)
                _nmbarang = Value
            End Set
        End Property

        Public Property [QTY]() As SqlDecimal
            Get
                Return _qty
            End Get
            Set(ByVal Value As SqlDecimal)
                _qty = Value
            End Set
        End Property

        Public Property [Saldo]() As SqlDecimal
            Get
                Return _saldo
            End Get
            Set(ByVal Value As SqlDecimal)
                _saldo = Value
            End Set
        End Property

        Public Property [TglDibutuhkan]() As SqlDateTime
            Get
                Return _tgldibutuhkan
            End Get
            Set(ByVal Value As SqlDateTime)
                _tgldibutuhkan = Value
            End Set
        End Property

        Public Property [Proses]() As SqlBoolean
            Get
                Return _proses
            End Get
            Set(ByVal Value As SqlBoolean)
                _proses = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
