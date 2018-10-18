Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class IssueResponse
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _responseID, _issueID, _responseDescription As String
        Private _responseDate As DateTime
        Private _responseTimeStart, _responseTypeSCode As String
        Private _responseDuration As Integer
        Private _userIDinsert, _userIDupdate As String
        Private _isShared As Boolean
        Private _insertDate, _updateDate As DateTime

        Private _totalIssue, _totalOpen, _totalFinish As Decimal
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
            cmdToExecute.CommandText = "INSERT INTO IssueResponse " + _
                                        "(responseID, issueID, responseDescription, " + _
                                        "responseDate, responseTimeStart, responseDuration, responseTypeSCode, isShared, userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@responseID, @issueID, @responseDescription, " + _
                                        "@responseDate, @responseTimeStart, @responseDuration, @responseTypeSCode, @isShared, @userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("IssueResponse", "responseID")

            Try
                cmdToExecute.Parameters.AddWithValue("@responseID", strID)
                cmdToExecute.Parameters.AddWithValue("@issueID", _issueID)                
                cmdToExecute.Parameters.AddWithValue("@responseDescription", _responseDescription)
                cmdToExecute.Parameters.AddWithValue("@responseDate", _responseDate)
                cmdToExecute.Parameters.AddWithValue("@responseTimeStart", _responseTimeStart)
                cmdToExecute.Parameters.AddWithValue("@responseDuration", _responseDuration)
                cmdToExecute.Parameters.AddWithValue("@responseTypeSCode", _responseTypeSCode)
                cmdToExecute.Parameters.AddWithValue("@isShared", _isShared)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _responseID = strID
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
            cmdToExecute.CommandText = "UPDATE IssueResponse " + _
                                        "SET responseDescription=@responseDescription, responseDate=@responseDate, " + _
                                        "responseTimeStart=@responseTimeStart, responseDuration=@responseDuration, " + _
                                        "responseTypeSCode=@responseTypeSCode, isShared=@isShared, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE responseID=@responseID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@responseID", _responseID)
                cmdToExecute.Parameters.AddWithValue("@responseDescription", _responseDescription)
                cmdToExecute.Parameters.AddWithValue("@responseDate", _responseDate)
                cmdToExecute.Parameters.AddWithValue("@responseTimeStart", _responseTimeStart)
                cmdToExecute.Parameters.AddWithValue("@responseDuration", _responseDuration)
                cmdToExecute.Parameters.AddWithValue("@responseTypeSCode", _responseTypeSCode)
                cmdToExecute.Parameters.AddWithValue("@isShared", _isShared)
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
            cmdToExecute.CommandText = "SELECT * FROM IssueResponse"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("IssueResponse")
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
            cmdToExecute.CommandText = "SELECT * FROM IssueResponse WHERE responseID=@responseID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("IssueRespons")
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
                    _issueID = CType(toReturn.Rows(0)("issueID"), String)
                    _responseDescription = CType(toReturn.Rows(0)("responseDescription"), String)
                    _responseDate = CType(toReturn.Rows(0)("responseDate"), DateTime)
                    _responseTimeStart = CType(toReturn.Rows(0)("responseTimeStart"), String)
                    _responseDuration = CType(toReturn.Rows(0)("responseDuration"), Integer)
                    _responseTypeSCode = CType(toReturn.Rows(0)("responseTypeSCode"), String)
                    _isShared = CType(toReturn.Rows(0)("isShared"), Boolean)
                    _userIDinsert = CType(toReturn.Rows(0)("userIDinsert"), String)
                    _userIDupdate = CType(toReturn.Rows(0)("userIDupdate"), String)
                    _insertDate = CType(toReturn.Rows(0)("insertDate"), DateTime)
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
            cmdToExecute.CommandText = "DELETE FROM IssueResponse " + _
                                        "WHERE responseID=@responseID"
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

#Region " Custom Functions "
        Public Function SelectByIssueID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT i.*, (SELECT firstName FROM Person WHERE personID=u.personID) AS userNameUpdate, " + _
                                        "(SELECT TOP 1 caption FROM CommonCode WHERE groupCode='RESPONSETYPE' AND code=i.responseTypeSCode) AS responseTypeName " + _
                                        "FROM IssueResponse i " + _
                                        "INNER JOIN [User] u ON i.userIDupdate=u.userID " + _
                                        "WHERE i.issueID=@issueID " + _
                                        "ORDER BY i.updateDate DESC"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("IssueResponse")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@issueID", _issueID)

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

        Public Property [IssueID]() As String
            Get
                Return _issueID
            End Get
            Set(ByVal Value As String)
                _issueID = Value
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

        Public Property [ResponseDate]() As DateTime
            Get
                Return _responseDate
            End Get
            Set(ByVal Value As DateTime)
                _responseDate = Value
            End Set
        End Property

        Public Property [ResponseTimeStart]() As String
            Get
                Return _responseTimeStart
            End Get
            Set(ByVal Value As String)
                _responseTimeStart = Value
            End Set
        End Property

        Public Property [ResponseDuration]() As Integer
            Get
                Return _responseDuration
            End Get
            Set(ByVal Value As Integer)
                _responseDuration = Value
            End Set
        End Property

        Public Property [ResponseTypeSCode]() As String
            Get
                Return _responseTypeSCode
            End Get
            Set(ByVal Value As String)
                _responseTypeSCode = Value
            End Set
        End Property

        Public Property [isShared]() As Boolean
            Get
                Return _isShared
            End Get
            Set(ByVal Value As Boolean)
                _isShared = Value
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

        Public Property [userIDupdate]() As String
            Get
                Return _userIDupdate
            End Get
            Set(ByVal Value As String)
                _userIDupdate = Value
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

        Public Property [updateDate]() As DateTime
            Get
                Return _updateDate
            End Get
            Set(ByVal Value As DateTime)
                _updateDate = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
