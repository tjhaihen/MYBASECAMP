Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class ProjectTimeline
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _projectTimelineID, _projectID As String
        Private _sequenceNo, _sequencePredecessorNo, _task, _taskDescription, _userIDPIC, _taskStatusSCode As String
        Private _startTimeScheduled, _endTimeScheduled, _startTimeRealized, _endTimeRealized As String
        Private _startDateRealizedInString, _endDateRealizedInString As String
        Private _startDateScheduled, _endDateScheduled, _startDateRealized, _endDateRealized As Date
        Private _userIDinsert, _userIDupdate As String
        Private _insertDate, _updateDate As DateTime
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
            cmdToExecute.CommandText = "INSERT INTO projectTimeline " + _
                                        "(projectTimelineID, projectID, sequenceNo, sequencePredecessorNo, task, taskDescription, taskStatusSCode, " + _
                                        "userIDPIC, startDateScheduled, endDateScheduled, startTimeScheduled, endTimeScheduled, " + _
                                        "startDateRealized, endDateRealized, startTimeRealized, endTimeRealized, " + _
                                        "userIDinsert, insertDate, userIDupdate, updateDate) " + _
                                        "VALUES " + _
                                        "(@projectTimelineID, @projectID, @sequenceNo, @sequencePredecessorNo, @task, @taskDescription, @taskStatusSCode, " + _
                                        "@userIDPIC, @startDateScheduled, @endDateScheduled, @startTimeScheduled, @endTimeScheduled, " + _
                                        "@startDateRealized, @endDateRealized, @startTimeRealized, @endTimeRealized, " + _
                                        "@userIDinsert, GETDATE(), @userIDupdate, GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strProjectTimelineID As String = ID.GenerateIDNumber("ProjectTimeline", "ProjectTimelineID")

            Try
                cmdToExecute.Parameters.AddWithValue("@projectTimelineID", strProjectTimelineID)
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@sequenceNo", _sequenceNo)
                cmdToExecute.Parameters.AddWithValue("@sequencePredecessorNo", _sequencePredecessorNo)
                cmdToExecute.Parameters.AddWithValue("@task", _task)
                cmdToExecute.Parameters.AddWithValue("@taskDescription", _taskDescription)
                cmdToExecute.Parameters.AddWithValue("@taskStatusSCode", _taskStatusSCode)
                cmdToExecute.Parameters.AddWithValue("@userIDPIC", _userIDPIC)
                cmdToExecute.Parameters.AddWithValue("@startDateScheduled", _startDateScheduled)
                cmdToExecute.Parameters.AddWithValue("@endDateScheduled", _endDateScheduled)
                If _startDateRealized = Nothing Then
                    cmdToExecute.Parameters.AddWithValue("@startDateRealized", DBNull.Value)
                Else
                    cmdToExecute.Parameters.AddWithValue("@startDateRealized", _startDateRealized)
                End If
                If _endDateRealized = Nothing Then
                    cmdToExecute.Parameters.AddWithValue("@endDateRealized", DBNull.Value)
                Else
                    cmdToExecute.Parameters.AddWithValue("@endDateRealized", _endDateRealized)
                End If
                cmdToExecute.Parameters.AddWithValue("@startTimeScheduled", _startTimeScheduled)
                cmdToExecute.Parameters.AddWithValue("@endTimeScheduled", _endTimeScheduled)
                If _startTimeRealized = Nothing Then
                    cmdToExecute.Parameters.AddWithValue("@startTimeRealized", DBNull.Value)
                Else
                    cmdToExecute.Parameters.AddWithValue("@startTimeRealized", _startTimeRealized)
                End If
                If _endTimeRealized = Nothing Then
                    cmdToExecute.Parameters.AddWithValue("@endTimeRealized", DBNull.Value)
                Else
                    cmdToExecute.Parameters.AddWithValue("@endTimeRealized", _endTimeRealized)
                End If
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _projectTimelineID = strProjectTimelineID
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
            cmdToExecute.CommandText = "UPDATE projectTimeline " + _
                                        "SET sequenceNo=@sequenceNo, sequencePredecessorNo=@sequencePredecessorNo, task=@task, " + _
                                        "taskDescription=@taskDescription, taskStatusSCode=@taskStatusSCode, userIDPIC=@userIDPIC, startDateScheduled=@startDateScheduled, " + _
                                        "endDateScheduled=@endDateScheduled, startDateRealized=@startDateRealized, endDateRealized=@endDateRealized, " + _
                                        "startTimeScheduled=@startTimeScheduled, endTimeRealized=@endTimeRealized, userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE ProjectTimelineID=@ProjectTimelineID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@projectTimelineID", _projectTimelineID)
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@sequenceNo", _sequenceNo)
                cmdToExecute.Parameters.AddWithValue("@sequencePredecessorNo", _sequencePredecessorNo)
                cmdToExecute.Parameters.AddWithValue("@task", _task)
                cmdToExecute.Parameters.AddWithValue("@taskDescription", _taskDescription)
                cmdToExecute.Parameters.AddWithValue("@taskStatusSCode", _taskStatusSCode)
                cmdToExecute.Parameters.AddWithValue("@userIDPIC", _userIDPIC)
                cmdToExecute.Parameters.AddWithValue("@startDateScheduled", _startDateScheduled)
                cmdToExecute.Parameters.AddWithValue("@endDateScheduled", _endDateScheduled)
                If _startDateRealized = Nothing Then
                    cmdToExecute.Parameters.AddWithValue("@startDateRealized", DBNull.Value)
                Else
                    cmdToExecute.Parameters.AddWithValue("@startDateRealized", _startDateRealized)
                End If
                If _endDateRealized = Nothing Then
                    cmdToExecute.Parameters.AddWithValue("@endDateRealized", DBNull.Value)
                Else
                    cmdToExecute.Parameters.AddWithValue("@endDateRealized", _endDateRealized)
                End If
                cmdToExecute.Parameters.AddWithValue("@startTimeScheduled", _startTimeScheduled)
                cmdToExecute.Parameters.AddWithValue("@endTimeScheduled", _endTimeScheduled)
                If _startTimeRealized = Nothing Then
                    cmdToExecute.Parameters.AddWithValue("@startTimeRealized", DBNull.Value)
                Else
                    cmdToExecute.Parameters.AddWithValue("@startTimeRealized", _startTimeRealized)
                End If
                If _endTimeRealized = Nothing Then
                    cmdToExecute.Parameters.AddWithValue("@endTimeRealized", DBNull.Value)
                Else
                    cmdToExecute.Parameters.AddWithValue("@endTimeRealized", _endTimeRealized)
                End If
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
            cmdToExecute.CommandText = "SELECT p.* " + _
                                        "FROM ProjectTimeline p " + _
                                        "ORDER BY p.sequenceNo"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ProjectTimeline")
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
            cmdToExecute.CommandText = "SELECT p.* " + _
                                        "FROM ProjectTimeline p WHERE p.ProjectTimelineID=@ProjectTimelineID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ProjectTimeline")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ProjectTimelineID", _projectTimelineID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _projectTimelineID = CType(toReturn.Rows(0)("ProjectTimelineID"), String)
                    _projectID = CType(toReturn.Rows(0)("ProjectID"), String)
                    _sequenceNo = CType(toReturn.Rows(0)("sequenceNo"), String)
                    _sequencePredecessorNo = CType(toReturn.Rows(0)("sequencePredecessorNo"), String)
                    _task = CType(toReturn.Rows(0)("task"), String)
                    _taskDescription = CType(toReturn.Rows(0)("taskDescription"), String)
                    _taskStatusSCode = CType(toReturn.Rows(0)("taskStatusSCode"), String)
                    _userIDPIC = CType(toReturn.Rows(0)("userIDPIC"), String)
                    _startDateScheduled = CType(toReturn.Rows(0)("startDateScheduled"), Date)
                    _endDateScheduled = CType(toReturn.Rows(0)("endDateScheduled"), Date)
                    _startDateRealized = CType(ProcessNull.GetDateTime(toReturn.Rows(0)("startDateRealized")), Date)
                    If IsDBNull(toReturn.Rows(0)("startDateRealized")) = True Then
                        _startDateRealizedInString = String.Empty
                    Else
                        _startDateRealizedInString = Format(CType(toReturn.Rows(0)("startDateRealized"), Date), "dd-MMM-yyyy")
                    End If
                    _endDateRealized = CType(ProcessNull.GetDateTime(toReturn.Rows(0)("endDateRealized")), Date)
                    If IsDBNull(toReturn.Rows(0)("endDateRealized")) = True Then
                        _endDateRealizedInString = String.Empty
                    Else
                        _endDateRealizedInString = Format(CType(toReturn.Rows(0)("endDateRealized"), Date), "dd-MMM-yyyy")
                    End If
                    _startTimeScheduled = CType(toReturn.Rows(0)("startTimeScheduled"), String)
                    _endTimeScheduled = CType(toReturn.Rows(0)("endTimeScheduled"), String)
                    _startTimeRealized = CType(ProcessNull.GetString(toReturn.Rows(0)("startTimeRealized")), String)
                    _endTimeRealized = CType(ProcessNull.GetString(toReturn.Rows(0)("endTimeRealized")), String)
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
            cmdToExecute.CommandText = "DELETE FROM ProjectTimeline " + _
                                        "WHERE ProjectTimelineID=@ProjectTimelineID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ProjectTimelineID", _projectTimelineID)

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

#Region " Custom Functions "
        Public Function SelectByProjectID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spSelectProjectTimelineByProjectID"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("ProjectTimelineSelectByProjectID")
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

        Public Function SelectByProjectIDSequenceNo() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM projectTimeline " + _
                                        "WHERE projectID=@projectID AND sequenceNo=@sequenceNo"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ProjectTimelineSelectByProjectIDSequenceNo")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@sequenceNo", _sequenceNo)

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
#End Region

#Region " Class Property Declarations "
        Public Property [ProjectTimelineID]() As String
            Get
                Return _projectTimelineID
            End Get
            Set(ByVal Value As String)
                _projectTimelineID = Value
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

        Public Property [SequenceNo]() As String
            Get
                Return _sequenceNo
            End Get
            Set(ByVal Value As String)
                _sequenceNo = Value
            End Set
        End Property

        Public Property [SequencePredecessorNo]() As String
            Get
                Return _sequencePredecessorNo
            End Get
            Set(ByVal Value As String)
                _sequencePredecessorNo = Value
            End Set
        End Property

        Public Property [Task]() As String
            Get
                Return _task
            End Get
            Set(ByVal Value As String)
                _task = Value
            End Set
        End Property

        Public Property [TaskDescription]() As String
            Get
                Return _taskDescription
            End Get
            Set(ByVal Value As String)
                _taskDescription = Value
            End Set
        End Property

        Public Property [TaskStatusSCode]() As String
            Get
                Return _taskStatusSCode
            End Get
            Set(ByVal Value As String)
                _taskStatusSCode = Value
            End Set
        End Property

        Public Property [UserIDPIC]() As String
            Get
                Return _userIDPIC
            End Get
            Set(ByVal Value As String)
                _userIDPIC = Value
            End Set
        End Property

        Public Property [StartDateScheduled]() As Date
            Get
                Return _startDateScheduled
            End Get
            Set(ByVal Value As Date)
                _startDateScheduled = Value
            End Set
        End Property

        Public Property [EndDateScheduled]() As Date
            Get
                Return _endDateScheduled
            End Get
            Set(ByVal Value As Date)
                _endDateScheduled = Value
            End Set
        End Property

        Public Property [StartDateRealized]() As Date
            Get
                Return _startDateRealized
            End Get
            Set(ByVal Value As Date)
                _startDateRealized = Value
            End Set
        End Property

        Public Property [StartDateRealizedInString]() As String
            Get
                Return _startDateRealizedInString
            End Get
            Set(ByVal Value As String)
                _startDateRealizedInString = Value
            End Set
        End Property

        Public Property [EndDateRealized]() As Date
            Get
                Return _endDateRealized
            End Get
            Set(ByVal Value As Date)
                _endDateRealized = Value
            End Set
        End Property

        Public Property [EndDateRealizedInString]() As String
            Get
                Return _endDateRealizedInString
            End Get
            Set(ByVal Value As String)
                _endDateRealizedInString = Value
            End Set
        End Property

        Public Property [StartTimeScheduled]() As String
            Get
                Return _startTimeScheduled
            End Get
            Set(ByVal Value As String)
                _startTimeScheduled = Value
            End Set
        End Property

        Public Property [EndTimeScheduled]() As String
            Get
                Return _endTimeScheduled
            End Get
            Set(ByVal Value As String)
                _endTimeScheduled = Value
            End Set
        End Property

        Public Property [StartTimeRealized]() As String
            Get
                Return _startTimeRealized
            End Get
            Set(ByVal Value As String)
                _startTimeRealized = Value
            End Set
        End Property

        Public Property [EndTimeRealized]() As String
            Get
                Return _endTimeRealized
            End Get
            Set(ByVal Value As String)
                _endTimeRealized = Value
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
