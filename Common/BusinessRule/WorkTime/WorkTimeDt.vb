Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class WorkTimeDt
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _worktimeDtID, _worktimeHdID, _projectID, _issueID, _detailDescription As String
        Private _worktimeinhour As Integer
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
            cmdToExecute.CommandText = "INSERT INTO WorkTimeDt " + _
                                        "(worktimeDtID, worktimeHdID, projectID, issueID, detailDescription, worktimeinhour) " + _
                                        "VALUES " + _
                                        "(@worktimeDtID, @worktimeHdID, @projectID, @issueID, @detailDescription, @worktimeinhour) "
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("WorkTimeDt", "worktimeDtID")

            Try
                cmdToExecute.Parameters.AddWithValue("@worktimeDtID", strID)
                cmdToExecute.Parameters.AddWithValue("@worktimeHdID", _worktimeHdID)
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@issueID", _issueID)
                cmdToExecute.Parameters.AddWithValue("@detailDescription", _detailDescription)
                cmdToExecute.Parameters.AddWithValue("@worktimeinhour", _worktimeinhour)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _worktimeDtID = strID
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
            cmdToExecute.CommandText = "UPDATE WorkTimeDt " + _
                                        "SET projectID=@projectID, issueID=@issueID, " + _
                                        "detailDescription=@detailDescription, worktimeinhour=@worktimeinhour " + _
                                        "WHERE worktimeDtID=@worktimeDtID"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@worktimeDtID", _worktimeDtID)
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@issueID", _issueID)
                cmdToExecute.Parameters.AddWithValue("@detailDescription", _detailDescription)
                cmdToExecute.Parameters.AddWithValue("@worktimeinhour", _worktimeinhour)

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
            cmdToExecute.CommandText = "SELECT * FROM WorkTimeDt"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("WorkTimeDt")
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
            cmdToExecute.CommandText = "SELECT * FROM WorkTimeDt WHERE worktimeDtID=@worktimeDtID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("WorkTimeDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@worktimeDtID", _worktimeDtID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _worktimeDtID = CType(toReturn.Rows(0)("worktimeDtID"), String)
                    _worktimeHdID = CType(toReturn.Rows(0)("worktimeHdID"), String)
                    _projectID = CType(toReturn.Rows(0)("projectID"), String)
                    _issueID = CType(toReturn.Rows(0)("issueID"), String)
                    _detailDescription = CType(toReturn.Rows(0)("detailDescription"), String)
                    _worktimeinhour = CType(toReturn.Rows(0)("worktimeinhour"), Integer)
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
            cmdToExecute.CommandText = "DELETE FROM WorkTimeDt " + _
                                        "WHERE worktimeDtID=@worktimeDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@worktimeDtID", _worktimeDtID)

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

        Public Function SelectByWorkTimeHdID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT d.*, p.projectAliasName, p.projectName, h.IsSubmitted FROM WorkTimeDt d " + _
                "INNER JOIN Project p ON d.projectID = p.projectID " + _
                "INNER JOIN WorkTimeHd h ON d.WorkTimeHdID = h.WorkTimeHdID " + _
                "WHERE d.worktimeHdID=@worktimeHdID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("WorkTimeDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@worktimeHdID", _worktimeHdID)

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

        Public Function SelectByUserIDWorktimeDate(ByVal strUserID As String, ByVal dtDate As Date) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT d.*, p.projectAliasName, p.projectName, h.IsSubmitted FROM WorkTimeDt d " + _
                "INNER JOIN Project p ON d.projectID = p.projectID " + _
                "INNER JOIN WorkTimeHd h ON d.WorkTimeHdID = h.WorkTimeHdID " + _
                "WHERE h.userID=@userID AND h.worktimeDate=@worktimeDate"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("SelectByUserIDWorktimeDate")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@userID", strUserID)
                cmdToExecute.Parameters.AddWithValue("@worktimeDate", dtDate)

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

        Public Function SelectByUserIDWorkTimeDateProjectIDIssueID(ByVal strUserID As String, ByVal dtWorktimeDate As Date) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM WorkTimeDt d " + _
                    "INNER JOIN WorkTimeHd h ON d.worktimeHdID=h.worktimeHdID " + _
                    "WHERE h.userID=@userID " + _
                    "AND h.workTimeDate=@workTimeDate " + _
                    "AND d.projectID=@projectID AND d.issueID=@issueID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("SelectByUserIDWorkTimeDateProjectIDIssueID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@userID", strUserID)
                cmdToExecute.Parameters.AddWithValue("@worktimeDate", dtWorktimeDate)
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
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
        Public Property [WorkTimeDtID]() As String
            Get
                Return _worktimeDtID
            End Get
            Set(ByVal Value As String)
                _worktimeDtID = Value
            End Set
        End Property

        Public Property [WorkTimeHdID]() As String
            Get
                Return _worktimeHdID
            End Get
            Set(ByVal Value As String)
                _worktimeHdID = Value
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

        Public Property [DetailDescription]() As String
            Get
                Return _detailDescription
            End Get
            Set(ByVal Value As String)
                _detailDescription = Value
            End Set
        End Property

        Public Property [WorkTimeInHour]() As Integer
            Get
                Return _worktimeinhour
            End Get
            Set(ByVal Value As Integer)
                _worktimeinhour = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
