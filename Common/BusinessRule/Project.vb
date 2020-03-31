Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class Project
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _projectID, _projectGroupID, _projectName, _projectDescription, _projectAliasName, _projectStatusGCID, _hexColorID As String
        Private _isOpenForClient As Boolean
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
            cmdToExecute.CommandText = "INSERT INTO project " + _
                                        "(projectID, projectGroupID, projectName, projectDescription, projectAliasName, projectStatusGCID, hexColorID, " + _
                                        "isOpenForClient, userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@projectID, @projectGroupID, @projectName, @projectDescription, @projectAliasName, @projectStatusGCID, @hexColorID, " + _
                                        "@isOpenForClient, @userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strProjectID As String = ID.GenerateIDNumber("Project", "ProjectID")

            Try
                cmdToExecute.Parameters.AddWithValue("@projectID", strProjectID)
                cmdToExecute.Parameters.AddWithValue("@projectGroupID", _projectGroupID)
                cmdToExecute.Parameters.AddWithValue("@projectName", _projectName)
                cmdToExecute.Parameters.AddWithValue("@projectDescription", _projectDescription)
                cmdToExecute.Parameters.AddWithValue("@projectAliasName", _projectAliasName)
                cmdToExecute.Parameters.AddWithValue("@projectStatusGCID", _projectStatusGCID)
                cmdToExecute.Parameters.AddWithValue("@hexColorID", _hexColorID)
                cmdToExecute.Parameters.AddWithValue("@isOpenForClient", _isOpenForClient)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _ProjectID = strProjectID
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
            cmdToExecute.CommandText = "UPDATE Project " + _
                                        "SET projectGroupID=@projectGroupID, projectName=@projectName, projectDescription=@projectDescription, projectAliasName=@projectAliasName, " + _
                                        "projectStatusGCID=@projectStatusGCID, hexColorID=@hexColorID, isOpenForClient=@isOpenForClient, userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE ProjectID=@ProjectID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ProjectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@ProjectGroupID", _projectGroupID)
                cmdToExecute.Parameters.AddWithValue("@projectName", _projectName)
                cmdToExecute.Parameters.AddWithValue("@projectDescription", _projectDescription)
                cmdToExecute.Parameters.AddWithValue("@projectAliasName", _projectAliasName)
                cmdToExecute.Parameters.AddWithValue("@projectStatusGCID", _projectStatusGCID)
                cmdToExecute.Parameters.AddWithValue("@hexColorID", _hexColorID)
                cmdToExecute.Parameters.AddWithValue("@isOpenForClient", _isOpenForClient)
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
            cmdToExecute.CommandText = "SELECT p.*, (SELECT caption FROM CommonCode WHERE groupCode='PROJECTSTATUS' AND code=p.projectStatusGCID) AS projectStatusName, " + _
                                        "(SELECT projectGroupName FROM projectGroup WHERE projectGroupID=p.projectGroupID) AS projectGroupName FROM Project p " + _
                                        "ORDER BY p.projectAliasName"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Project")
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
            cmdToExecute.CommandText = "SELECT * FROM Project WHERE ProjectID=@ProjectID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Project")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ProjectID", _ProjectID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _projectID = CType(toReturn.Rows(0)("ProjectID"), String)
                    _projectGroupID = CType(toReturn.Rows(0)("ProjectGroupID"), String)
                    _projectName = CType(toReturn.Rows(0)("ProjectName"), String)
                    _projectDescription = CType(toReturn.Rows(0)("ProjectDescription"), String)
                    _projectAliasName = CType(toReturn.Rows(0)("ProjectAliasName"), String)
                    _projectStatusGCID = CType(toReturn.Rows(0)("projectStatusGCID"), String)
                    _hexColorID = CType(toReturn.Rows(0)("hexColorID"), String)
                    _isOpenForClient = CType(toReturn.Rows(0)("isOpenForClient"), Boolean)
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
            cmdToExecute.CommandText = "DELETE FROM Project " + _
                                        "WHERE ProjectID=@ProjectID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ProjectID", _ProjectID)

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

        Public Function SelectProjectNotInPatchProject(ByVal strPatchNo As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT p.*, (SELECT caption FROM CommonCode WHERE groupCode='PROJECTSTATUS' AND code=p.projectStatusGCID) AS projectStatusName, " + _
                                        "(SELECT projectGroupName FROM projectGroup WHERE projectGroupID=p.projectGroupID) AS projectGroupName FROM Project p " + _
                                        "WHERE p.projectID NOT IN (SELECT projectID FROM PatchProject WHERE PatchNo=@PatchNo) " + _
                                        "ORDER BY p.projectAliasName"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("SelectProjectNotInPatchProject")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@PatchNo", strPatchNo)

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
        Public Property [ProjectID]() As String
            Get
                Return _projectID
            End Get
            Set(ByVal Value As String)
                _projectID = Value
            End Set
        End Property

        Public Property [ProjectGroupID]() As String
            Get
                Return _projectGroupID
            End Get
            Set(ByVal Value As String)
                _projectGroupID = Value
            End Set
        End Property

        Public Property [ProjectName]() As String
            Get
                Return _projectName
            End Get
            Set(ByVal Value As String)
                _projectName = Value
            End Set
        End Property

        Public Property [ProjectDescription]() As String
            Get
                Return _projectDescription
            End Get
            Set(ByVal Value As String)
                _projectDescription = Value
            End Set
        End Property

        Public Property [ProjectAliasName]() As String
            Get
                Return _projectAliasName
            End Get
            Set(ByVal Value As String)
                _projectAliasName = Value
            End Set
        End Property

        Public Property [ProjectStatusGCID]() As String
            Get
                Return _projectStatusGCID
            End Get
            Set(ByVal Value As String)
                _projectStatusGCID = Value
            End Set
        End Property

        Public Property [HexColorID]() As String
            Get
                Return _hexColorID
            End Get
            Set(ByVal Value As String)
                _hexColorID = Value
            End Set
        End Property

        Public Property [IsOpenForClient]() As Boolean
            Get
                Return _isOpenForClient
            End Get
            Set(ByVal Value As Boolean)
                _isOpenForClient = Value
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
