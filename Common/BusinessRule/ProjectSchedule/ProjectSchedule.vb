Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class ProjectSchedule
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _projectScheduleID, _projectID As String
        Private _sequenceNo, _sequencePredecessorNo, _task, _taskDescription, _userIDPIC As String
        Private _startTimeScheduled, _endTimeScheduled, _startTimeRealized, _endTimeRealized As String
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
            cmdToExecute.CommandText = "INSERT INTO projectSchedule " + _
                                        "(projectScheduleID, projectID, sequenceNo, sequencePredecessorNo, task, taskDescription, " + _
                                        "userIDPIC, startDateScheduled, endDateScheduled, startDateRealized, endDateRealized, " + _
                                        "startTimeScheduled, endTimeScheduled, startTimeRealized, endTimeRealized, userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@projectScheduleID, @projectID, @sequenceNo, @sequencePredecessorNo, @task, @taskDescription, " + _
                                        "@userIDPIC, @startDateScheduled, @endDateScheduled, @startDateRealized, @endDateRealized, " + _
                                        "@startTimeScheduled, @endTimeScheduled, @startTimeRealized, @endTimeRealized, @userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strProjectScheduleID As String = ID.GenerateIDNumber("ProjectSchedule", "ProjectScheduleID")

            Try
                cmdToExecute.Parameters.AddWithValue("@projectScheduleID", strProjectScheduleID)
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@sequenceNo", _sequenceNo)
                cmdToExecute.Parameters.AddWithValue("@sequencePredecessorNo", _sequencePredecessorNo)
                cmdToExecute.Parameters.AddWithValue("@task", _task)
                cmdToExecute.Parameters.AddWithValue("@taskDescription", _taskDescription)
                cmdToExecute.Parameters.AddWithValue("@userIDPIC", _userIDPIC)
                cmdToExecute.Parameters.AddWithValue("@startDateScheduled", _startDateScheduled)
                cmdToExecute.Parameters.AddWithValue("@endDateScheduled", _endDateScheduled)
                cmdToExecute.Parameters.AddWithValue("@startDateRealized", _startDateRealized)
                cmdToExecute.Parameters.AddWithValue("@endDateRealized", _endDateRealized)
                cmdToExecute.Parameters.AddWithValue("@startTimeScheduled", _startTimeScheduled)
                cmdToExecute.Parameters.AddWithValue("@endTimeScheduled", _endTimeScheduled)
                cmdToExecute.Parameters.AddWithValue("@startTimeRealized", _startTimeRealized)
                cmdToExecute.Parameters.AddWithValue("@endTimeRealized", _endTimeRealized)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _projectScheduleID = strProjectScheduleID
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
            cmdToExecute.CommandText = "UPDATE projectSchedule " + _
                                        "SET sequenceNo=@sequenceNo, sequencePredecessorNo=@sequencePredecessorNo, task=@task, " + _
                                        "taskDescription=@taskDescription, userIDPIC=@userIDPIC, startDateScheduled=@startDateScheduled, " + _
                                        "endDateScheduled=@endDateScheduled, startDateRealized=@startDateRealized, endDateRealized=@endDateRealized, " + _
                                        "startTimeScheduled=@startTimeScheduled, endTimeRealized=@endTimeRealized, userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE ProjectScheduleID=@ProjectScheduleID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@projectScheduleID", _projectScheduleID)
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@sequenceNo", _sequenceNo)
                cmdToExecute.Parameters.AddWithValue("@sequencePredecessorNo", _sequencePredecessorNo)
                cmdToExecute.Parameters.AddWithValue("@task", _task)
                cmdToExecute.Parameters.AddWithValue("@taskDescription", _taskDescription)
                cmdToExecute.Parameters.AddWithValue("@userIDPIC", _userIDPIC)
                cmdToExecute.Parameters.AddWithValue("@startDateScheduled", _startDateScheduled)
                cmdToExecute.Parameters.AddWithValue("@endDateScheduled", _endDateScheduled)
                cmdToExecute.Parameters.AddWithValue("@startDateRealized", _startDateRealized)
                cmdToExecute.Parameters.AddWithValue("@endDateRealized", _endDateRealized)
                cmdToExecute.Parameters.AddWithValue("@startTimeScheduled", _startTimeScheduled)
                cmdToExecute.Parameters.AddWithValue("@endTimeScheduled", _endTimeScheduled)
                cmdToExecute.Parameters.AddWithValue("@startTimeRealized", _startTimeRealized)
                cmdToExecute.Parameters.AddWithValue("@endTimeRealized", _endTimeRealized)
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
                                        "FROM ProjectSchedule p " + _
                                        "ORDER BY p.sequenceNo"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ProjectSchedule")
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
                                        "FROM ProjectSchedule p WHERE p.ProjectScheduleID=@ProjectScheduleID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ProjectSchedule")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ProjectScheduleID", _projectScheduleID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _projectScheduleID = CType(toReturn.Rows(0)("ProjectScheduleID"), String)
                    _projectID = CType(toReturn.Rows(0)("ProjectID"), String)
                    _sequenceNo = CType(toReturn.Rows(0)("sequenceNo"), String)
                    _sequencePredecessorNo = CType(toReturn.Rows(0)("sequencePredecessorNo"), String)
                    _task = CType(toReturn.Rows(0)("task"), String)
                    _taskDescription = CType(toReturn.Rows(0)("taskDescription"), String)
                    _userIDPIC = CType(toReturn.Rows(0)("userIDPIC"), String)
                    _startDateScheduled = CType(toReturn.Rows(0)("startDateScheduled"), Date)
                    _endDateScheduled = CType(toReturn.Rows(0)("endDateScheduled"), Date)
                    _startDateRealized = CType(toReturn.Rows(0)("startDateRealized"), Date)
                    _endDateRealized = CType(toReturn.Rows(0)("endDateRealized"), Date)
                    _startTimeScheduled = CType(toReturn.Rows(0)("startTimeScheduled"), String)
                    _endTimeScheduled = CType(toReturn.Rows(0)("endTimeScheduled"), String)
                    _startTimeRealized = CType(toReturn.Rows(0)("startTimeRealized"), String)
                    _endTimeRealized = CType(toReturn.Rows(0)("endTimeRealized"), String)
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
            cmdToExecute.CommandText = "DELETE FROM ProjectSchedule " + _
                                        "WHERE ProjectScheduleID=@ProjectScheduleID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ProjectScheduleID", _projectScheduleID)

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
        Public Property [ProjectScheduleID]() As String
            Get
                Return _projectScheduleID
            End Get
            Set(ByVal Value As String)
                _projectScheduleID = Value
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

        Public Property [EndDateRealized]() As Date
            Get
                Return _endDateRealized
            End Get
            Set(ByVal Value As Date)
                _endDateRealized = Value
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
