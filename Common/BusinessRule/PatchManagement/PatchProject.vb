Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class PatchProject
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _patchProjectID, _patchNo, _projectID, _remarks, _userIDinsert As String
        Private _updateDate, _insertDate As DateTime
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
            cmdToExecute.CommandText = "INSERT INTO PatchProject " + _
                                        "(patchProjectID, patchNo, projectID, updateDate, remarks, " + _
                                        " userIDinsert, insertDate) " + _
                                        "VALUES " + _
                                        "(@patchProjectID, @patchNo, @projectID, @updateDate, @remarks, " + _
                                        " @userIDinsert, GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("PatchProject", "patchProjectID")

            Try
                cmdToExecute.Parameters.AddWithValue("@patchProjectID", strID)
                cmdToExecute.Parameters.AddWithValue("@patchNo", _patchNo)
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@updateDate", _updateDate)
                cmdToExecute.Parameters.AddWithValue("@remarks", _remarks)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _patchProjectID = strID
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
            cmdToExecute.CommandText = "SELECT * FROM PatchProject ORDER BY PatchNo, PatchProjectID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PatchProject")
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
            cmdToExecute.CommandText = "SELECT * FROM PatchProject WHERE patchProjectID=@patchProjectID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PatchProject")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@patchProjectID", _patchProjectID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _patchProjectID = CType(toReturn.Rows(0)("patchProjectID"), String)
                    _patchNo = CType(toReturn.Rows(0)("patchNo"), String)
                    _projectID = CType(toReturn.Rows(0)("projectID"), String)
                    _updateDate = CType(toReturn.Rows(0)("updateDate"), DateTime)
                    _remarks = CType(toReturn.Rows(0)("remarks"), String)
                    _insertDate = CType(toReturn.Rows(0)("insertDate"), DateTime)
                    _userIDinsert = CType(toReturn.Rows(0)("userIDinsert"), String)
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
            cmdToExecute.CommandText = "DELETE FROM PatchProject WHERE patchProjectID=@patchProjectID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@patchProjectID", _patchProjectID)

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

        Public Function SelectByPatchNo() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT pd.*, ph.IsClosed, ISNULL(p.projectAliasName,'') AS projectAliasName, " + _
                    "ISNULL((SELECT firstName FROM Person WHERE personID=(SELECT personID FROM [User] WHERE userID=pd.userIDinsert)),'') AS userNameinsert " + _
                    "FROM PatchProject pd " + _
                    "INNER JOIN Project p ON pd.projectID = p.projectID " + _
                    "INNER JOIN Patch ph ON pd.patchNo=ph.patchNo " + _
                    "WHERE pd.PatchNo=@PatchNo"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("SelectByPatchNo")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@PatchNo", _patchNo)

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

        Public Function SelectForPatchProjectDashboard(ByVal dtStartDate As Date, ByVal dtEndDate As Date) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spSelectPatchForDashboard"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("SelectForPatchProjectDashboard")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@StartDate", dtStartDate)
                cmdToExecute.Parameters.AddWithValue("@EndDate", dtEndDate)

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
        Public Property [PatchProjectID]() As String
            Get
                Return _patchProjectID
            End Get
            Set(ByVal Value As String)
                _patchProjectID = Value
            End Set
        End Property

        Public Property [PatchNo]() As String
            Get
                Return _patchNo
            End Get
            Set(ByVal Value As String)
                _patchNo = Value
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

        Public Property [ProjectID]() As String
            Get
                Return _projectID
            End Get
            Set(ByVal Value As String)
                _projectID = Value
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
#End Region

    End Class
End Namespace
