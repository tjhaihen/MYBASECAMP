Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class IncidentChronological
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _incidentChronologicalID, _incidentNo, _chronologicalTime, _incidentChronological As String
        Private _chronologicalDate As Date
        Private _isDeleted As Boolean

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
            cmdToExecute.CommandText = "INSERT INTO incidentChronological " + _
                                        "(incidentChronologicalID, incidentNo, chronologicalDate, chronologicalTime, incidentChronological, isDeleted) " + _
                                        "VALUES " + _
                                        "(@incidentChronologicalID, @incidentNo, @chronologicalDate, @chronologicalTime, @incidentChronological, 0)"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("incidentChronological", "incidentChronologicalID")

            Try
                cmdToExecute.Parameters.AddWithValue("@incidentChronologicalID", strID)
                cmdToExecute.Parameters.AddWithValue("@incidentNo", _incidentNo)
                cmdToExecute.Parameters.AddWithValue("@chronologicalDate", _chronologicalDate)
                cmdToExecute.Parameters.AddWithValue("@chronologicalTime", _chronologicalTime)
                cmdToExecute.Parameters.AddWithValue("@incidentChronological", _incidentChronological)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _incidentNo = strID
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
            cmdToExecute.CommandText = "UPDATE incidentChronological " + _
                                        "SET chronologicalDate=@chronologicalDate, chronologicalTime=@chronologicalTime, " + _
                                        "incidentChronological=@incidentChronological " + _
                                        "WHERE incidentChronologicalID=@incidentChronologicalID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@incidentChronologicalID", _incidentChronologicalID)
                cmdToExecute.Parameters.AddWithValue("@chronologicalDate", _chronologicalDate)
                cmdToExecute.Parameters.AddWithValue("@chronologicalTime", _chronologicalTime)
                cmdToExecute.Parameters.AddWithValue("@incidentChronological", _incidentChronological)

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
            cmdToExecute.CommandText = "SELECT * FROM incidentChronological ic"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("incidentChronological")
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
            cmdToExecute.CommandText = "SELECT * FROM incidentChronological WHERE incidentChronologicalID=@incidentChronologicalID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("incidentChronological")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@incidentChronologicalID", _incidentChronologicalID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _incidentChronologicalID = CType(toReturn.Rows(0)("incidentChronologicalID"), String)
                    _incidentNo = CType(toReturn.Rows(0)("incidentNo"), String)
                    _chronologicalDate = CType(toReturn.Rows(0)("chronologicalDate"), Date)
                    _chronologicalTime = CType(toReturn.Rows(0)("chronologicalTime"), String)
                    _incidentChronological = CType(ProcessNull.GetString(toReturn.Rows(0)("incidentChronological")), String)
                    _isDeleted = CType(toReturn.Rows(0)("isDeleted"), Boolean)
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
            cmdToExecute.CommandText = "UPDATE incidentChronological " + _
                                        "SET isDeleted = 1 " + _
                                        "WHERE incidentChronologicalID=@incidentChronologicalID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@incidentChronologicalID", _incidentChronologicalID)

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

        Public Function SelectByIncidentNo() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT ic.*, ii.isApproved FROM incidentChronological ic " + _
                                        "INNER JOIN incidentInvestigation ii ON ic.incidentNo = ii.incidentNo " + _
                                        "WHERE ic.incidentNo=@incidentNo AND ic.IsDeleted=0 AND ii.IsDeleted=0"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("incidentChronological")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@incidentNo", _incidentNo)

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
#End Region

#Region " Class Property Declarations "
        Public Property [incidentChronologicalID]() As String
            Get
                Return _incidentChronologicalID
            End Get
            Set(ByVal Value As String)
                _incidentChronologicalID = Value
            End Set
        End Property

        Public Property [incidentNo]() As String
            Get
                Return _incidentNo
            End Get
            Set(ByVal Value As String)
                _incidentNo = Value
            End Set
        End Property

        Public Property [chronologicalDate]() As Date
            Get
                Return _chronologicalDate
            End Get
            Set(ByVal Value As Date)
                _chronologicalDate = Value
            End Set
        End Property

        Public Property [chronologicalTime]() As String
            Get
                Return _chronologicalTime
            End Get
            Set(ByVal Value As String)
                _chronologicalTime = Value
            End Set
        End Property

        Public Property [incidentChronological]() As String
            Get
                Return _incidentChronological
            End Get
            Set(ByVal Value As String)
                _incidentChronological = Value
            End Set
        End Property

        Public Property [isDeleted]() As Boolean
            Get
                Return _isDeleted
            End Get
            Set(ByVal Value As Boolean)
                _isDeleted = Value
            End Set
        End Property

#End Region

    End Class
End Namespace
