Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class Patch
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _patchNo, _userIDinsert, _userIDclosed, _remarks As String
        Private _patchDate, _insertDate, _closedDate As DateTime
        Private _isClosed As Boolean
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
            cmdToExecute.CommandText = "INSERT INTO Patch " + _
                                        "(patchNo, remarks, userIDinsert, " + _
                                        "patchDate, insertDate) " + _
                                        "VALUES " + _
                                        "(@patchNo, @remarks, @userIDinsert, " + _
                                        "@patchDate, GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@patchNo", _patchNo)
                cmdToExecute.Parameters.AddWithValue("@remarks", _remarks)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@patchDate", _patchDate)

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
            cmdToExecute.CommandText = "UPDATE Patch " + _
                                        "SET remarks=@remarks, patchDate=@patchDate " + _
                                        "WHERE patchNo=@patchNo"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@patchNo", _patchNo)
                cmdToExecute.Parameters.AddWithValue("@remarks", _remarks)
                cmdToExecute.Parameters.AddWithValue("@patchDate", _patchDate)

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
            cmdToExecute.CommandText = "SELECT * FROM Patch ORDER BY PatchNo DESC"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Patch")
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
            cmdToExecute.CommandText = "SELECT * FROM Patch WHERE patchNo=@patchNo"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Patch")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@patchNo", _patchNo)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _patchNo = CType(toReturn.Rows(0)("patchNo"), String)
                    _patchDate = CType(toReturn.Rows(0)("patchDate"), Date)
                    _remarks = CType(toReturn.Rows(0)("remarks"), String)
                    _insertDate = CType(toReturn.Rows(0)("insertDate"), DateTime)
                    _userIDinsert = CType(toReturn.Rows(0)("userIDinsert"), String)
                    _isClosed = CType(toReturn.Rows(0)("isClosed"), Boolean)
                    _userIDclosed = CType(ProcessNull.GetString(toReturn.Rows(0)("userIDclosed")), String)
                    _closedDate = CType(ProcessNull.GetDateTime(toReturn.Rows(0)("closedDate")), DateTime)
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
                                        "DELETE FROM PatchDt " + _
                                        "WHERE patchNo=@patchNo " + _
                                        "DELETE FROM PatchProject " + _
                                        "WHERE patchNo=@patchNo " + _
                                        "UPDATE Issue " + _
                                        "SET patchNo = '', isSpecific=0 " + _
                                        "WHERE patchNo=@patchNo " + _
                                        "DELETE FROM Patch " + _
                                        "WHERE patchNo=@patchNo " + _
                                        "COMMIT TRAN " + _
                                        "SET XACT_ABORT OFF"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@patchNo", _patchNo)

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
        Public Function UpdateIsClosed() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "UPDATE Patch " + _
                                        "SET isClosed=@isClosed, " + _
                                        "userIDclosed=@userIDclosed, " + _
                                        "closedDate=GETDATE() " + _
                                        "WHERE patchNo=@patchNo"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@patchNo", _patchNo)
                cmdToExecute.Parameters.AddWithValue("@isClosed", _isClosed)
                cmdToExecute.Parameters.AddWithValue("@userIDclosed", _userIDclosed)

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
        Public Property [PatchNo]() As String
            Get
                Return _patchNo
            End Get
            Set(ByVal Value As String)
                _patchNo = Value
            End Set
        End Property

        Public Property [PatchDate]() As DateTime
            Get
                Return _patchDate
            End Get
            Set(ByVal Value As DateTime)
                _patchDate = Value
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

        Public Property [IsClosed]() As Boolean
            Get
                Return _isClosed
            End Get
            Set(ByVal Value As Boolean)
                _isClosed = Value
            End Set
        End Property

        Public Property [closedDate]() As DateTime
            Get
                Return _closedDate
            End Get
            Set(ByVal Value As DateTime)
                _closedDate = Value
            End Set
        End Property

        Public Property [userIDclosed]() As String
            Get
                Return _userIDclosed
            End Get
            Set(ByVal Value As String)
                _userIDclosed = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
