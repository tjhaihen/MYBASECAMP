Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class EMRlocation
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _locationGroupCode, _locationCode, _locationName As String
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
            cmdToExecute.CommandText = "INSERT INTO EMRLocation " + _
                                        "(locationGroupCode, locationCode, locationName, isActive) " + _
                                        "VALUES " + _
                                        "(@locationGroupCode, @locationCode, @locationName, @isActive)"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strLocationCode As String = ID.GenerateIDNumber("EMRlocation", "locationCode")

            Try
                cmdToExecute.Parameters.AddWithValue("@locationCode", strLocationCode)
                cmdToExecute.Parameters.AddWithValue("@locationGroupCode", _locationGroupCode)
                cmdToExecute.Parameters.AddWithValue("@locationName", _locationName)
                cmdToExecute.Parameters.AddWithValue("@isActive", _isActive)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _locationCode = strLocationCode
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
            cmdToExecute.CommandText = "UPDATE EMRlocation " + _
                                        "SET locationName=@locationName, isActive=@isActive " + _
                                        "WHERE locationCode=@locationCode AND locationGroupCode=@locationGroupCode"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@locationCode", _locationCode)
                cmdToExecute.Parameters.AddWithValue("@locationGroupCode", _locationGroupCode)
                cmdToExecute.Parameters.AddWithValue("@locationName", _locationName)
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
            cmdToExecute.CommandText = "SELECT * FROM EMRlocation"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("EMRlocation")
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
            cmdToExecute.CommandText = "SELECT * FROM EMRlocation WHERE locationCode=@locationCode AND locationGroupCode=@locationGroupCode"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("EMRlocation")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@locationCode", _locationCode)
                cmdToExecute.Parameters.AddWithValue("@locationGroupCode", _locationGroupCode)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _locationCode = CType(toReturn.Rows(0)("locationCode"), String)
                    _locationGroupCode = CType(toReturn.Rows(0)("locationGroupCode"), String)
                    _locationName = CType(toReturn.Rows(0)("locationName"), String)
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

        Public Function SelectByLocationGroup() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM EMRlocation WHERE locationGroupCode=@locationGroupCode"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("SelectByLocationGroup")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@locationGroupCode", _locationGroupCode)

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

        Public Overrides Function Delete() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "DELETE FROM EMRlocation " + _
                                        "WHERE locationCode=@locationCode AND locationGroupCode=@locationGroupCode"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@locationCode", _locationCode)
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
        Public Property [LocationCode]() As String
            Get
                Return _locationCode
            End Get
            Set(ByVal Value As String)
                _locationCode = Value
            End Set
        End Property

        Public Property [LocationGroupCode]() As String
            Get
                Return _locationGroupCode
            End Get
            Set(ByVal Value As String)
                _locationGroupCode = Value
            End Set
        End Property

        Public Property [LocationName]() As String
            Get
                Return _locationName
            End Get
            Set(ByVal Value As String)
                _locationName = Value
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
