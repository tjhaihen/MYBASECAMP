Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class ProjectGroup
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _projectGroupID, _projectGroupName, _sequence As String
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
            cmdToExecute.CommandText = "INSERT INTO projectGroup " + _
                                        "(projectGroupID, projectGroupName, sequence) " + _
                                        "VALUES " + _
                                        "(@projectGroupID, @projectGroupName, @sequence)"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("ProjectGroup", "ProjectGroupID")

            Try
                cmdToExecute.Parameters.AddWithValue("@projectGroupID", strID)
                cmdToExecute.Parameters.AddWithValue("@projectGroupName", _projectGroupName)
                cmdToExecute.Parameters.AddWithValue("@sequence", _sequence)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _projectGroupID = strID
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
            cmdToExecute.CommandText = "UPDATE ProjectGroup " + _
                                        "SET projectGroupName=@projectGroupName, sequence=@sequence " + _
                                        "WHERE ProjectGroupID=@ProjectGroupID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ProjectGroupID", _projectGroupID)
                cmdToExecute.Parameters.AddWithValue("@projectGroupName", _projectGroupName)
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
            cmdToExecute.CommandText = "SELECT * FROM ProjectGroup " + _
                                        "ORDER BY sequence"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ProjectGroup")
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
            cmdToExecute.CommandText = "SELECT * FROM ProjectGroup WHERE ProjectGroupID=@ProjectGroupID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ProjectGroup")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ProjectGroupID", _projectGroupID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _projectGroupID = CType(toReturn.Rows(0)("ProjectGroupID"), String)
                    _projectGroupName = CType(toReturn.Rows(0)("ProjectGroupName"), String)
                    _sequence = CType(toReturn.Rows(0)("sequence"), String)                    
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
            cmdToExecute.CommandText = "DELETE FROM ProjectGroup " + _
                                        "WHERE ProjectGroupID=@ProjectGroupID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ProjectGroupID", _projectGroupID)

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
        Public Property [ProjectGroupID]() As String
            Get
                Return _projectGroupID
            End Get
            Set(ByVal Value As String)
                _projectGroupID = Value
            End Set
        End Property

        Public Property [ProjectGroupName]() As String
            Get
                Return _projectGroupName
            End Get
            Set(ByVal Value As String)
                _projectGroupName = Value
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
#End Region

    End Class
End Namespace
