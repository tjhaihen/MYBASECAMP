Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class WorkTimeHd
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _worktimeHdID, _userID, _remarks As String
        Private _isSubmitted As Boolean
        Private _worktimeDate, _insertDate, _updateDate As DateTime
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
            cmdToExecute.CommandText = "INSERT INTO WorkTimeHd " + _
                                        "(worktimeHdID, userID, remarks, " + _
                                        "isSubmitted, worktimeDate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@worktimeHdID, @userID, @remarks, " + _
                                        "@isSubmitted, @worktimeDate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("WorkTimeHd", "worktimeHdID")

            Try
                cmdToExecute.Parameters.AddWithValue("@worktimeHdID", strID)
                cmdToExecute.Parameters.AddWithValue("@userID", _userID)
                cmdToExecute.Parameters.AddWithValue("@remarks", _remarks)
                cmdToExecute.Parameters.AddWithValue("@isSubmitted", _isSubmitted)
                cmdToExecute.Parameters.AddWithValue("@worktimeDate", _worktimeDate)                

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _worktimeHdID = strID
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
            cmdToExecute.CommandText = "UPDATE WorkTimeHd " + _
                                        "SET remarks=@remarks, workTimeDate=@workTimeDate, isSubmitted=@isSubmitted, updateDate=GETDATE() " + _
                                        "WHERE worktimeHdID=@worktimeHdID"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@worktimeHdID", _worktimeHdID)
                cmdToExecute.Parameters.AddWithValue("@remarks", _remarks)
                cmdToExecute.Parameters.AddWithValue("@isSubmitted", _isSubmitted)
                cmdToExecute.Parameters.AddWithValue("@workTimeDate", _worktimeDate)

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
            cmdToExecute.CommandText = "SELECT * FROM WorkTimeHd"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("WorkTimeHd")
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
            cmdToExecute.CommandText = "SELECT * FROM WorkTimeHd WHERE worktimeHdID=@worktimeHdID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("WorkTimeHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@worktimeHdID", _worktimeHdID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _worktimeHdID = CType(toReturn.Rows(0)("worktimeHdID"), String)
                    _userID = CType(toReturn.Rows(0)("userID"), String)
                    _remarks = CType(toReturn.Rows(0)("remarks"), String)
                    _isSubmitted = CType(toReturn.Rows(0)("isSubmitted"), Boolean)
                    _worktimeDate = CType(toReturn.Rows(0)("worktimeDate"), DateTime)
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
            cmdToExecute.CommandText = "SET XACT_ABORT ON " + _
                                        "BEGIN TRAN " + _
                                        "DELETE FROM WorkTimeDt " + _
                                        "WHERE worktimeHdID=@worktimeHdID " + _
                                        "DELETE FROM WorkTimeHd " + _
                                        "WHERE worktimeHdID=@worktimeHdID " + _
                                        "COMMIT TRAN " + _
                                        "SET XACT_ABORT OFF"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@worktimeHdID", _worktimeHdID)

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

        Public Function SelectByUserIDWorkTimeDate() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM WorkTimeHd WHERE userID=@userID AND workTimeDate=@workTimeDate"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("WorkTimeHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@userID", _userID)
                cmdToExecute.Parameters.AddWithValue("@worktimeDate", _worktimeDate)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _worktimeHdID = CType(toReturn.Rows(0)("worktimeHdID"), String)
                    _userID = CType(toReturn.Rows(0)("userID"), String)
                    _remarks = CType(toReturn.Rows(0)("remarks"), String)
                    _isSubmitted = CType(toReturn.Rows(0)("isSubmitted"), Boolean)
                    _worktimeDate = CType(toReturn.Rows(0)("worktimeDate"), DateTime)
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

        Public Function UpdateSubmit() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "UPDATE WorkTimeHd " + _
                                        "SET isSubmitted=@isSubmitted, updateDate=GETDATE() " + _
                                        "WHERE worktimeHdID=@worktimeHdID"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@worktimeHdID", _worktimeHdID)
                cmdToExecute.Parameters.AddWithValue("@isSubmitted", _isSubmitted)

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
        Public Property [WorkTimeHdID]() As String
            Get
                Return _worktimeHdID
            End Get
            Set(ByVal Value As String)
                _worktimeHdID = Value
            End Set
        End Property

        Public Property [UserID]() As String
            Get
                Return _userID
            End Get
            Set(ByVal Value As String)
                _userID = Value
            End Set
        End Property

        Public Property [WorkTimeDate]() As DateTime
            Get
                Return _worktimeDate
            End Get
            Set(ByVal Value As DateTime)
                _worktimeDate = Value
            End Set
        End Property

        Public Property [Remarks]() As String
            Get
                Return _remarks
            End Get
            Set(ByVal Value As String)
                _remarks = Value
            End Set
        End Property

        Public Property [IsSubmitted]() As Boolean
            Get
                Return _isSubmitted
            End Get
            Set(ByVal Value As Boolean)
                _isSubmitted = Value
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
