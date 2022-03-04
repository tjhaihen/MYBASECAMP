Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class Tickets
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _ticketID, _projectID, _issueID, _ticketStatusSCode, _ticketDescription As String
        Private _customerReportedByname, _customerAckByname, _userIDinsert, _userIDupdate, _userIDdeleted As String
        Private _ticketDateTime, _insertDate, _updateDate, _deletedDate As DateTime
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
            cmdToExecute.CommandText = "INSERT INTO Tickets " + _
                                        "(ticketID, projectID, ticketStatusSCode, ticketDateTime, " + _
                                        "ticketDescription, customerReportedByname, customerAckByname, " + _
                                        "userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@ticketID, @projectID, @ticketStatusSCode, GETDATE(), " + _
                                        "@ticketDescription, @customerReportedByname, @customerAckByname, " + _
                                        "@userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ticketID", _ticketID)
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@ticketStatusSCode", _ticketStatusSCode)
                cmdToExecute.Parameters.AddWithValue("@ticketDescription", _ticketDescription)
                cmdToExecute.Parameters.AddWithValue("@customerReportedByname", _customerReportedByname)
                cmdToExecute.Parameters.AddWithValue("@customerAckByname", _customerAckByname)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

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
            cmdToExecute.CommandText = "UPDATE Tickets " + _
                                        "SET ticketStatusSCode=@ticketStatusSCode, ticketDescription=@ticketDescription, " + _
                                        "customerReportedByname=@customerReportedByname, customerAckByName=@customerAckByName, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE ticketID=@ticketID"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ticketID", _ticketID)
                cmdToExecute.Parameters.AddWithValue("@ticketStatusSCode", _ticketStatusSCode)
                cmdToExecute.Parameters.AddWithValue("@ticketDescription", _ticketDescription)
                cmdToExecute.Parameters.AddWithValue("@customerReportedByname", _customerReportedByname)
                cmdToExecute.Parameters.AddWithValue("@customerAckByname", _customerAckByname)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

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
            cmdToExecute.CommandText = "SELECT * FROM Tickets ORDER BY ticketID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Tickets")
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
            cmdToExecute.CommandText = "SELECT * FROM Tickets WHERE ticketID=@ticketID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Tickets")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ticketID", _ticketID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _ticketID = CType(toReturn.Rows(0)("ticketID"), String)
                    _projectID = CType(toReturn.Rows(0)("projectID"), String)
                    _issueID = CType(toReturn.Rows(0)("issueID"), String)
                    _ticketStatusSCode = CType(toReturn.Rows(0)("ticketStatusSCode"), String)
                    _ticketDateTime = CType(toReturn.Rows(0)("ticketDateTime"), DateTime)
                    _ticketDescription = CType(toReturn.Rows(0)("ticketDescription"), String)
                    _customerReportedByname = CType(toReturn.Rows(0)("customerReportedByname"), String)
                    _customerAckByname = CType(toReturn.Rows(0)("customerAckByname"), String)
                    _userIDinsert = CType(toReturn.Rows(0)("userIDinsert"), String)
                    _insertDate = CType(toReturn.Rows(0)("insertDate"), DateTime)
                    _userIDupdate = CType(toReturn.Rows(0)("userIDupdate"), String)
                    _updateDate = CType(toReturn.Rows(0)("updateDate"), DateTime)
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
            cmdToExecute.CommandText = "SET XACT_ABORT ON " + _
                                        "BEGIN TRAN " + _
                                        "UPDATE TicketsResponse " + _
                                        "SET isDeleted=1, deletedDate=GETDATE(), userIDdeleted=@userIDdeleted " + _
                                        "WHERE ticketID=@ticketID AND isDeleted=0 " + _
                                        "UPDATE Tickets " + _
                                        "SET isDeleted=1, deletedDate=GETDATE(), userIDdeleted=@userIDdeleted " + _
                                        "WHERE ticketID=@ticketID AND isDeleted=0 " + _
                                        "COMMIT TRAN " + _
                                        "SET XACT_ABORT OFF"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ticketID", _ticketID)

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

#Region " Custom Function "
        Public Function SelectByProjectID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM Tickets " + _
                "WHERE projectID = @projectID " + _
                "ORDER BY ticketID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("SelectByProjectID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)

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

        Public Function UpdateTicketStatusSCode() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "UPDATE Tickets " + _
                                        "SET ticketStatusSCode=@ticketStatusSCode, " + _
                                        "userIDupdate=@userIDupdate, " + _
                                        "updateDate=GETDATE() " + _
                                        "WHERE ticketID=@ticketID"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ticketID", _ticketID)
                cmdToExecute.Parameters.AddWithValue("@ticketStatusSCode", _ticketStatusSCode)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

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
        Public Property [TicketID]() As String
            Get
                Return _ticketID
            End Get
            Set(ByVal Value As String)
                _ticketID = Value
            End Set
        End Property

        Public Property [ProjectID]() As String
            Get
                Return _projectID
            End Get
            Set(ByVal Value As String)
                _projectID = Value
            End Set
        End Property

        Public Property [IssueID]() As String
            Get
                Return _issueID
            End Get
            Set(ByVal Value As String)
                _issueID = Value
            End Set
        End Property

        Public Property [TicketDateTime]() As DateTime
            Get
                Return _ticketDateTime
            End Get
            Set(ByVal Value As DateTime)
                _ticketDateTime = Value
            End Set
        End Property

        Public Property [TicketStatusSCode]() As String
            Get
                Return _ticketStatusSCode
            End Get
            Set(ByVal Value As String)
                _ticketStatusSCode = Value
            End Set
        End Property

        Public Property [TicketDescription]() As String
            Get
                Return _ticketDescription
            End Get
            Set(ByVal Value As String)
                _ticketDescription = Value
            End Set
        End Property

        Public Property [CustomerReportedByname]() As String
            Get
                Return _customerReportedByname
            End Get
            Set(ByVal Value As String)
                _customerReportedByname = Value
            End Set
        End Property

        Public Property [CustomerAckByname]() As String
            Get
                Return _customerAckByname
            End Get
            Set(ByVal Value As String)
                _customerAckByname = Value
            End Set
        End Property

        Public Property [insertDate]() As DateTime
            Get
                Return _insertDate
            End Get
            Set(ByVal Value As DateTime)
                _insertDate = Value
            End Set
        End Property

        Public Property [userIDinsert]() As String
            Get
                Return _userIDinsert
            End Get
            Set(ByVal Value As String)
                _userIDinsert = Value
            End Set
        End Property

        Public Property [IsDeleted]() As Boolean
            Get
                Return _isDeleted
            End Get
            Set(ByVal Value As Boolean)
                _isDeleted = Value
            End Set
        End Property

        Public Property [deletedDate]() As DateTime
            Get
                Return _deletedDate
            End Get
            Set(ByVal Value As DateTime)
                _deletedDate = Value
            End Set
        End Property

        Public Property [userIDdeleted]() As String
            Get
                Return _userIDdeleted
            End Get
            Set(ByVal Value As String)
                _userIDdeleted = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
