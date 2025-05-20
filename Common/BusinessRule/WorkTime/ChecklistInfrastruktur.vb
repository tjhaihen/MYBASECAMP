Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class ChecklistInfrastruktur
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _kode, _keterangan, _status, _catatan, _user As String
        Private _worktimeinhour As Integer
        Private _isCheck, _isApprove, _isPropose, _isValidation As Boolean
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
            cmdToExecute.CommandText = "sp_CheckListInfrastruktur_Insert"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@Kode", _kode)
                cmdToExecute.Parameters.AddWithValue("@Tanggal", _tanggal)
                cmdToExecute.Parameters.AddWithValue("@isCheck", _isCheck)
                cmdToExecute.Parameters.AddWithValue("@Catatan", _catatan)
                cmdToExecute.Parameters.AddWithValue("@isPropose", _isPropose)
                cmdToExecute.Parameters.AddWithValue("@usrinsert", _user)

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
            cmdToExecute.CommandText = "sp_CheckListInfrastruktur_Update"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@Kode", _kode)
                cmdToExecute.Parameters.AddWithValue("@Tanggal", _tanggal)
                cmdToExecute.Parameters.AddWithValue("@isCheck", _isCheck)
                cmdToExecute.Parameters.AddWithValue("@Catatan", _catatan)
                cmdToExecute.Parameters.AddWithValue("@isPropose", _isPropose)
                cmdToExecute.Parameters.AddWithValue("@usrinsert", _user)

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

            Dim toReturn As DataTable = New DataTable("CheckListInfrastruktur")
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
            cmdToExecute.CommandText = "sp_CheckListInfrastruktur_SelectByDate"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("CheckListInfrastruktur")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                'cmdToExecute.Parameters.AddWithValue("@usrinsert", _user)
                cmdToExecute.Parameters.AddWithValue("@tgl", _tanggal)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)
                If toReturn.Rows.Count > 0 Then
                    _kode = CType(toReturn.Rows(0)("code"), String)
                    _keterangan = CType(toReturn.Rows(0)("caption"), String)
                    _status = CType(toReturn.Rows(0)("value"), String)
                    _isCheck = CType(toReturn.Rows(0)("isCheck"), Boolean)
                    _catatan = CType(toReturn.Rows(0)("Catatan"), String)
                    _isPropose = CType(toReturn.Rows(0)("isPropose"), Boolean)
                    _isApprove = CType(toReturn.Rows(0)("isApprove"), Boolean)
                    _isValidation = CType(toReturn.Rows(0)("isValidation"), Boolean)
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

        Public Function SelectbyCode() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "sp_CheckListInfrastruktur_SelectByCodeDate"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("CheckListInfrastruktur")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@kode", _kode)
                cmdToExecute.Parameters.AddWithValue("@tgl", _tanggal)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)
                If toReturn.Rows.Count > 0 Then
                    _kode = CType(toReturn.Rows(0)("code"), String)
                    _keterangan = CType(toReturn.Rows(0)("caption"), String)
                    _status = CType(toReturn.Rows(0)("value"), String)
                    _isCheck = CType(toReturn.Rows(0)("isCheck"), Boolean)
                    _catatan = CType(toReturn.Rows(0)("Catatan"), String)
                    _isPropose = CType(toReturn.Rows(0)("isPropose"), Boolean)
                    _isApprove = CType(toReturn.Rows(0)("isApprove"), Boolean)
                    _isValidation = CType(toReturn.Rows(0)("isValidation"), Boolean)
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
            cmdToExecute.CommandText = "sp_CheckListInfrastruktur_Delete"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@usrinsert", _user)
                cmdToExecute.Parameters.AddWithValue("@Tanggal", _tanggal)

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

        Public Function UpdateValidasi(ByVal _tahun As String, _bulan As String) As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "sp_CheckListInfrastruktur_UpdateValidasi"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@isApprove", _isApprove)
                cmdToExecute.Parameters.AddWithValue("@tahun", _tahun)
                cmdToExecute.Parameters.AddWithValue("@bulan", _bulan)
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
#End Region

#Region " Class Property Declarations "
        Public Property [Kode]() As String
            Get
                Return _kode
            End Get
            Set(ByVal Value As String)
                _kode = Value
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
                Return _isCheck
            End Get
            Set(ByVal Value As Boolean)
                _isCheck = Value
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

        Public Property [Tanggal]() As DateTime
            Get
                Return _tanggal
            End Get
            Set(value As DateTime)
                _tanggal = value
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

        Public Property [isValidation]() As Boolean
            Get
                Return _isValidation
            End Get
            Set(ByVal Value As Boolean)
                _isValidation = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
