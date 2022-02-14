Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class PatchGroup
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _PatchGroupID, _PatchGroupName, _sequence, _UserIDInsert As String
        Private _InsertDate As DateTime
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
            cmdToExecute.CommandText = "INSERT INTO PatchGroup " + _
                                        "(PatchGroupID, PatchGroupName, sequence, UserIDInsert, InsertDate) " + _
                                        "VALUES " + _
                                        "(@PatchGroupID, @PatchGroupName, @sequence, @UserIDInsert, GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("PatchGroup", "PatchGroupID")

            Try
                cmdToExecute.Parameters.AddWithValue("@PatchGroupID", strID)
                cmdToExecute.Parameters.AddWithValue("@PatchGroupName", _PatchGroupName)
                cmdToExecute.Parameters.AddWithValue("@sequence", _sequence)
                cmdToExecute.Parameters.AddWithValue("@UserIDInsert", _UserIDInsert)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _PatchGroupID = strID
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
            cmdToExecute.CommandText = "UPDATE PatchGroup " + _
                                        "SET PatchGroupName=@PatchGroupName, sequence=@sequence " + _
                                        "WHERE PatchGroupID=@PatchGroupID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@PatchGroupID", _PatchGroupID)
                cmdToExecute.Parameters.AddWithValue("@PatchGroupName", _PatchGroupName)
                cmdToExecute.Parameters.AddWithValue("@sequence", _sequence)

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
            cmdToExecute.CommandText = "SELECT * FROM PatchGroup " + _
                                        "ORDER BY sequence"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PatchGroup")
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
            cmdToExecute.CommandText = "SELECT * FROM PatchGroup WHERE PatchGroupID=@PatchGroupID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PatchGroup")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@PatchGroupID", _PatchGroupID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _PatchGroupID = CType(toReturn.Rows(0)("PatchGroupID"), String)
                    _PatchGroupName = CType(toReturn.Rows(0)("PatchGroupName"), String)
                    _sequence = CType(toReturn.Rows(0)("sequence"), String)
                    _UserIDInsert = CType(toReturn.Rows(0)("UserIDInsert"), String)
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
            cmdToExecute.CommandText = "DELETE FROM PatchGroup " + _
                                        "WHERE PatchGroupID=@PatchGroupID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@PatchGroupID", _PatchGroupID)

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
        Public Property [PatchGroupID]() As String
            Get
                Return _PatchGroupID
            End Get
            Set(ByVal Value As String)
                _PatchGroupID = Value
            End Set
        End Property

        Public Property [PatchGroupName]() As String
            Get
                Return _PatchGroupName
            End Get
            Set(ByVal Value As String)
                _PatchGroupName = Value
            End Set
        End Property

        Public Property [Sequence]() As String
            Get
                Return _sequence
            End Get
            Set(ByVal Value As String)
                _sequence = Value
            End Set
        End Property

        Public Property [UserIDInsert]() As String
            Get
                Return _UserIDInsert
            End Get
            Set(ByVal Value As String)
                _UserIDInsert = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
