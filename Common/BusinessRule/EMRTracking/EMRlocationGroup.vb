Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class EMRlocationGroup
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _locationGroupCode, _locationGroupName As String
        Private _isActive As Boolean
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
            cmdToExecute.CommandText = "INSERT INTO EMRLocationGroup " + _
                                        "(locationGroupCode, locationGroupName, isActive) " + _
                                        "VALUES " + _
                                        "(@locationGroupCode, @locationGroupName, @isActive)"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strLocationGroupCode As String = ID.GenerateIDNumber("EMRlocationGroup", "locationGroupCode")

            Try
                cmdToExecute.Parameters.AddWithValue("@locationGroupCode", strLocationGroupCode)
                cmdToExecute.Parameters.AddWithValue("@locationGroupName", _locationGroupName)
                cmdToExecute.Parameters.AddWithValue("@isActive", _isActive)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _locationGroupCode = strLocationGroupCode
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
            cmdToExecute.CommandText = "UPDATE EMRlocationGroup " + _
                                        "SET locationGroupName=@locationGroupName, isActive=@isActive " + _
                                        "WHERE locationGroupCode=@locationGroupCode"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@locationGroupCode", _locationGroupCode)
                cmdToExecute.Parameters.AddWithValue("@locationGroupName", _locationGroupName)
                cmdToExecute.Parameters.AddWithValue("@isActive", _isActive)

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
            cmdToExecute.CommandText = "SELECT * FROM EMRlocationGroup"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("EMRlocationGroup")
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
            cmdToExecute.CommandText = "SELECT * FROM EMRlocationGroup WHERE locationGroupCode=@locationGroupCode"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("EMRlocationGroup")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@locationGroupCode", _locationGroupCode)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _locationGroupCode = CType(toReturn.Rows(0)("locationGroupCode"), String)
                    _locationGroupName = CType(toReturn.Rows(0)("locationGroupName"), String)
                    _isActive = CType(toReturn.Rows(0)("isActive"), Boolean)
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
            cmdToExecute.CommandText = "DELETE FROM EMRlocationGroup " + _
                                        "WHERE locationGroupCode=@locationGroupCode"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@locationGroupCode", _locationGroupCode)

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
        Public Property [LocationGroupCode]() As String
            Get
                Return _locationGroupCode
            End Get
            Set(ByVal Value As String)
                _locationGroupCode = Value
            End Set
        End Property

        Public Property [LocationGroupName]() As String
            Get
                Return _locationGroupName
            End Get
            Set(ByVal Value As String)
                _locationGroupName = Value
            End Set
        End Property

        Public Property [IsActive]() As Boolean
            Get
                Return _isActive
            End Get
            Set(ByVal Value As Boolean)
                _isActive = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
