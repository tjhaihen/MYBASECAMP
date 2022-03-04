Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class TicketsResponse
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _responseID, _ticketID, _ticketStatusSCode, _responseDescription As String
        Private _issueTypeSCode As String
        Private _responseFollowUpSCode, _quotationNo, _userIDresponse, _userIDdeleted As String
        Private _responseDateTime, _deletedDate As DateTime
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
            cmdToExecute.CommandText = "INSERT INTO TicketsResponse " + _
                                        "(responseID, ticketID, ticketStatusSCode, responseDateTime, " + _
                                        "responseDescription, issueTypeSCode, responseFollowUpSCode, " + _
                                        "quotationNo, userIDresponse) " + _
                                        "VALUES " + _
                                        "(@responseID, @ticketID, @ticketStatusSCode, GETDATE(), " + _
                                        "@responseDescription, @issueTypeSCode, @responseFollowUpSCode, " + _
                                        "@quotationNo, @userIDresponse)"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@responseID", _responseID)
                cmdToExecute.Parameters.AddWithValue("@ticketID", _ticketID)
                cmdToExecute.Parameters.AddWithValue("@ticketStatusSCode", _ticketStatusSCode)
                cmdToExecute.Parameters.AddWithValue("@responseDateTime", _responseDateTime)
                cmdToExecute.Parameters.AddWithValue("@responseDescription", _responseDescription)
                cmdToExecute.Parameters.AddWithValue("@issueTypeSCode", _issueTypeSCode)
                cmdToExecute.Parameters.AddWithValue("@responseFollowUpSCode", _responseFollowUpSCode)
                cmdToExecute.Parameters.AddWithValue("@quotationNo", _quotationNo)
                cmdToExecute.Parameters.AddWithValue("@userIDresponse", _userIDresponse)

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
            cmdToExecute.CommandText = "SELECT * FROM TicketsResponse ORDER BY ticketID, responseID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("TicketsResponse")
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
            cmdToExecute.CommandText = "SELECT * FROM TicketsResponse WHERE responseID=@responseID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("TicketsResponse")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@responseID", _responseID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _responseID = CType(toReturn.Rows(0)("responseID"), String)
                    _ticketID = CType(toReturn.Rows(0)("ticketID"), String)
                    _responseDateTime = CType(toReturn.Rows(0)("responseDateTime"), DateTime)
                    _ticketStatusSCode = CType(toReturn.Rows(0)("ticketStatusSCode"), String)
                    _issueTypeSCode = CType(toReturn.Rows(0)("issueTypeSCode"), String)
                    _responseDescription = CType(toReturn.Rows(0)("responseDescription"), String)
                    _responseFollowUpSCode = CType(toReturn.Rows(0)("responseFollowUpSCode"), String)
                    _quotationNo = CType(toReturn.Rows(0)("quotationNo"), String)
                    _userIDresponse = CType(toReturn.Rows(0)("userIDresponse"), String)
                    _isDeleted = CType(toReturn.Rows(0)("isDeleted"), Boolean)
                    _userIDdeleted = CType(toReturn.Rows(0)("userIDdeleted"), String)
                    _deletedDate = CType(toReturn.Rows(0)("deletedDate"), DateTime)
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
            cmdToExecute.CommandText = "UPDATE TicketsResponse " + _
                                        "SET isDeleted=1, deletedDate=GETDATE(), userIDdeleted=@userIDdeleted " + _
                                        "WHERE ticketID=@ticketID AND isDeleted=0"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@responseID", _responseID)

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
        Public Function SelectByTicketID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM TicketsResponse " + _
                "WHERE ticketID = @ticketID " + _
                "ORDER BY responseID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("SelectByTicketID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ticketID", _ticketID)

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
        Public Property [ResponseID]() As String
            Get
                Return _responseID
            End Get
            Set(ByVal Value As String)
                _responseID = Value
            End Set
        End Property

        Public Property [TicketID]() As String
            Get
                Return _ticketID
            End Get
            Set(ByVal Value As String)
                _ticketID = Value
            End Set
        End Property

        Public Property [ResponseDateTime]() As DateTime
            Get
                Return _responseDateTime
            End Get
            Set(ByVal Value As DateTime)
                _responseDateTime = Value
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

        Public Property [ResponseDescription]() As String
            Get
                Return _responseDescription
            End Get
            Set(ByVal Value As String)
                _responseDescription = Value
            End Set
        End Property

        Public Property [ResponseFollowUpSCode]() As String
            Get
                Return _responseFollowUpSCode
            End Get
            Set(ByVal Value As String)
                _responseFollowUpSCode = Value
            End Set
        End Property

        Public Property [quotationNo]() As String
            Get
                Return _quotationNo
            End Get
            Set(ByVal Value As String)
                _quotationNo = Value
            End Set
        End Property

        Public Property [IssueTypeSCode]() As String
            Get
                Return _issueTypeSCode
            End Get
            Set(ByVal Value As String)
                _issueTypeSCode = Value
            End Set
        End Property

        Public Property [userIDresponse]() As String
            Get
                Return _userIDresponse
            End Get
            Set(ByVal Value As String)
                _userIDresponse = Value
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
