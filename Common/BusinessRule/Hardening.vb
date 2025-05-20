Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class Hardening
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _kode, _keterangan, _status, _catatan, _user, _NoHardening, _UserPengguna, _KodePerangkat, _NoAset As String
        Private _isHasil, _isApprove, _isPropose, _isValidation As Boolean
        Private _tanggal As DateTime
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

#Region " C,R,U,D "
        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "sp_HardeningHD_Insert"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@NoHardening", _NoHardening)
                cmdToExecute.Parameters.AddWithValue("@NoAset", _NoAset)
                cmdToExecute.Parameters.AddWithValue("@UsrPengguna", _UserPengguna)
                cmdToExecute.Parameters.AddWithValue("@KodePerangkat", _KodePerangkat)
                cmdToExecute.Parameters.AddWithValue("@isPropose", _isPropose)
                cmdToExecute.Parameters.AddWithValue("@isApprove", _isApprove)
                cmdToExecute.Parameters.AddWithValue("@Catatan", _catatan)
                cmdToExecute.Parameters.AddWithValue("@user", _user)

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
            cmdToExecute.CommandText = "sp_HardeningHD_Update"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@NoHardening", _NoHardening)
                cmdToExecute.Parameters.AddWithValue("@NoAset", _NoAset)
                cmdToExecute.Parameters.AddWithValue("@UsrPengguna", _UserPengguna)
                cmdToExecute.Parameters.AddWithValue("@KodePerangkat", _KodePerangkat)
                cmdToExecute.Parameters.AddWithValue("@isPropose", _isPropose)
                cmdToExecute.Parameters.AddWithValue("@Catatan", _catatan)
                cmdToExecute.Parameters.AddWithValue("@user", _user)

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

        Public Overrides Function SelectAll() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = ""
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("Hardening")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
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

        Public Overrides Function SelectOne(Optional ByVal recStatus As QISRecStatus = QISRecStatus.CurrentRecord) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "sp_Hardening_SelectOne"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("Hardening")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@NoHardening", _NoHardening)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)
                If toReturn.Rows.Count > 0 Then
                    _kode = CType(toReturn.Rows(0)("code"), String)
                    _keterangan = CType(toReturn.Rows(0)("caption"), String)
                    _status = CType(toReturn.Rows(0)("value"), String)
                    _isHasil = CType(toReturn.Rows(0)("Hasil"), Boolean)
                    _catatan = CType(toReturn.Rows(0)("Catatan"), String)
                    _isPropose = CType(toReturn.Rows(0)("isPropose"), Boolean)
                    _isApprove = CType(toReturn.Rows(0)("isApprove"), Boolean)
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

        Public Function SelectbyNoHD() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "sp_HardeningHD_SelectByNo"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("Hardening")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@NoHardening", _NoHardening)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)
                If toReturn.Rows.Count > 0 Then
                    _NoAset = CType(toReturn.Rows(0)("NoAset"), String)
                    _UserPengguna = CType(toReturn.Rows(0)("UsrPengguna"), String)
                    _KodePerangkat = CType(toReturn.Rows(0)("KodePerangkat"), String)
                    _isPropose = CType(toReturn.Rows(0)("isPropose"), Boolean)
                    _isApprove = CType(toReturn.Rows(0)("isApprove"), Boolean)
                    _catatan = CType(toReturn.Rows(0)("Catatan"), String)
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

        Public Overrides Function Delete() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "sp_HardeningHD_Void"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@NoHardening", _NoHardening)
                cmdToExecute.Parameters.AddWithValue("@user", _user)

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

        Public Function UpdateApprove() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "sp_HardeningHD_UpdateApprove"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@NoHardening", _NoHardening)
                cmdToExecute.Parameters.AddWithValue("@isApprove", _isApprove)
                cmdToExecute.Parameters.AddWithValue("@usrapprove", _user)

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

#Region "Detil"
        Public Function InsertDT() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "sp_HardeningDT_Insert"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@NoHardening", _NoHardening)
                cmdToExecute.Parameters.AddWithValue("@KodeHardening", _kode)
                cmdToExecute.Parameters.AddWithValue("@isHasil", _isHasil)
                cmdToExecute.Parameters.AddWithValue("@Catatan", _catatan)

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

        Public Function UpdateDT() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "sp_HardeningDT_Update"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@NoHardening", _NoHardening)
                cmdToExecute.Parameters.AddWithValue("@KodeHardening", _kode)
                cmdToExecute.Parameters.AddWithValue("@isHasil", _isHasil)
                cmdToExecute.Parameters.AddWithValue("@Catatan", _catatan)

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

        Public Function SelectOneByNoDT() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "sp_HardeningDT_SelectByNo"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("Hardening")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@NoHardening", _NoHardening)
                cmdToExecute.Parameters.AddWithValue("@code", _kode)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)
                If toReturn.Rows.Count > 0 Then
                    _kode = CType(toReturn.Rows(0)("KodeHardening"), String)
                    _isHasil = CType(toReturn.Rows(0)("ishasil"), Boolean)
                    _catatan = CType(toReturn.Rows(0)("Catatan"), String)
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
#End Region

#Region " Class Property Declarations "

        Public ReadOnly Property NewTransactionNumber(ByVal tglTrans As Date) As SqlString
            Get
                Dim cmdToExecute As SqlCommand = New SqlCommand
                Dim strSQL As New Text.StringBuilder
                Dim sRetVal, b As String

                cmdToExecute.CommandText = "sp_HardeningHD_GetMaxNo"
                cmdToExecute.CommandType = CommandType.StoredProcedure

                Dim toReturn As DataTable = New DataTable("Hardening")
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
                        b = CType(toReturn.Rows(0)("noHardenMax"), String)

                        If Len(Trim(b)) > 0 Then
                            sRetVal = "HDN" + Format(tglTrans, "yyyy") + Format(tglTrans, "MM") + Format(tglTrans, "dd") + Format(CInt(Right(b.Trim, 4)) + 1, "0###")
                        Else
                            sRetVal = "HDN" + Format(tglTrans, "yyyy") + Format(tglTrans, "MM") + Format(tglTrans, "dd") + Format(1, "0###")
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

        Public Property [Kode]() As String
            Get
                Return _kode
            End Get
            Set(ByVal Value As String)
                _kode = Value
            End Set
        End Property

        Public Property [KodePerangkat]() As String
            Get
                Return _KodePerangkat
            End Get
            Set(ByVal Value As String)
                _KodePerangkat = Value
            End Set
        End Property

        Public Property [NoAset]() As String
            Get
                Return _NoAset
            End Get
            Set(ByVal Value As String)
                _NoAset = Value
            End Set
        End Property

        Public Property [UserPengguna]() As String
            Get
                Return _UserPengguna
            End Get
            Set(ByVal Value As String)
                _UserPengguna = Value
            End Set
        End Property

        Public Property [Keterangan]() As String
            Get
                Return _keterangan
            End Get
            Set(ByVal Value As String)
                _keterangan = Value
            End Set
        End Property

        Public Property [NoHardening]() As String
            Get
                Return _NoHardening
            End Get
            Set(ByVal Value As String)
                _NoHardening = Value
            End Set
        End Property

        Public Property [Status]() As String
            Get
                Return _status
            End Get
            Set(ByVal Value As String)
                _status = Value
            End Set
        End Property

        Public Property [Catatan]() As String
            Get
                Return _catatan
            End Get
            Set(ByVal Value As String)
                _catatan = Value
            End Set
        End Property

        Public Property [User]() As String
            Get
                Return _user
            End Get
            Set(ByVal Value As String)
                _user = Value
            End Set
        End Property

        Public Property [isCheck]() As Boolean
            Get
                Return _isHasil
            End Get
            Set(ByVal Value As Boolean)
                _isHasil = Value
            End Set
        End Property

        Public Property [isPropose]() As Boolean
            Get
                Return _isPropose
            End Get
            Set(ByVal Value As Boolean)
                _isPropose = Value
            End Set
        End Property

        Public Property [isApprove]() As Boolean
            Get
                Return _isApprove
            End Get
            Set(ByVal Value As Boolean)
                _isApprove = Value
            End Set
        End Property

        Public Property [isValidation]() As Boolean
            Get
                Return _isValidation
            End Get
            Set(ByVal Value As Boolean)
                _isValidation = Value
            End Set
        End Property

        Public Property [Tanggal]() As DateTime
            Get
                Return _tanggal
            End Get
            Set(value As DateTime)
                _tanggal = value
            End Set
        End Property
#End Region

    End Class
End Namespace
