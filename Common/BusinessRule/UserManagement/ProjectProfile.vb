Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class ProjectProfile
        Inherits BRInteractionBase

#Region " Class Member Declarations "

        Private _projectProfileID, _projectID, _profileID As String

#End Region

        Public Sub New()
            ConnectionString = SysConfig.ConnectionString
        End Sub

#Region " C,R,U,D "
        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "INSERT INTO projectProfile " + _
                                        "(projectProfileID, projectID, profileID) " + _
                                        "VALUES " + _
                                        "(@projectProfileID, @projectID, @profileID)"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("projectProfile", "projectProfileID")

            Try
                cmdToExecute.Parameters.AddWithValue("@projectProfileID", strID)
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@profileID", _profileID)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _projectProfileID = strID
                Return True
            Catch ex As Exception
                ExceptionManager.Publish(ex)
            Finally
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function

        Public Overrides Function Delete() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "DELETE FROM projectProfile " + _
                                        "WHERE projectProfileID=@projectProfileID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@projectProfileID", _projectProfileID)

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
        Public Function SelectProjectByProfileID(ByVal ProfileID As String, Optional ByVal IsAssignedOnly As Boolean = False) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            If IsAssignedOnly = False Then
                cmdToExecute.CommandText = "SELECT a.* FROM (SELECT up.*, p.projectName, p.projectDescription, p.projectAliasName, p.isOpenForClient, " + _
                                        "(SELECT caption FROM CommonCode WHERE groupCode='PROJECTSTATUS' AND code=p.projectStatusGCID) AS projectStatusName, " + _
                                        "ISNULL((SELECT CONVERT(VARCHAR,MAX(updateDate),106) + ' ' + CONVERT(VARCHAR,MAX(updateDate),108) FROM issue WHERE projectID=p.projectID),'-') AS lastUpdateDate, " + _
                                        "totalIssue = (SELECT COUNT(issueID) FROM issue WHERE projectID=up.projectID), " + _
                                        "totalOpen = (SELECT COUNT(issueID) FROM issue WHERE projectID=up.projectID AND issueStatusSCode<>'003'), " + _
                                        "totalFinish = (SELECT COUNT(issueID) FROM issue WHERE projectID=up.projectID AND issueStatusSCode='003') " + _
                                        "FROM projectProfile up " + _
                                        "INNER JOIN Project p ON up.projectID=p.projectID " + _
                                        "WHERE up.ProfileID=@ProfileID) a " + _
                                        "ORDER BY a.totalOpen DESC"
            Else
                cmdToExecute.CommandText = "SELECT a.* FROM (SELECT up.*, p.projectName, p.projectDescription, p.projectAliasName, p.isOpenForClient, " + _
                                        "(SELECT caption FROM CommonCode WHERE groupCode='PROJECTSTATUS' AND code=p.projectStatusGCID) AS projectStatusName, " + _
                                        "ISNULL((SELECT CONVERT(VARCHAR,MAX(updateDate),106) + ' ' + CONVERT(VARCHAR,MAX(updateDate),108) FROM issue WHERE projectID=p.projectID),'-') AS lastUpdateDate, " + _
                                        "totalIssue = (SELECT COUNT(issueID) FROM issue WHERE projectID=up.projectID AND UserIDAssignedTo=@UserID), " + _
                                        "totalOpen = (SELECT COUNT(issueID) FROM issue WHERE projectID=up.projectID AND UserIDAssignedTo=@UserID AND issueStatusSCode<>'003'), " + _
                                        "totalFinish = (SELECT COUNT(issueID) FROM issue WHERE projectID=up.projectID AND UserIDAssignedTo=@UserID AND issueStatusSCode='003') " + _
                                        "FROM projectProfile up " + _
                                        "INNER JOIN Project p ON up.projectID=p.projectID " + _
                                        "WHERE up.ProfileID=@ProfileID AND up.projectID IN " + _
                                        "(SELECT DISTINCT projectID FROM Issue WHERE UserIDAssignedTo=@UserID)) a " + _
                                        "ORDER BY a.totalOpen DESC"
            End If
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("projectByProfileID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ProfileID", ProfileID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                Return toReturn
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                Throw New Exception(ex.Message)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function

        Public Function SelectProjectNotInUserProjectByUserID(ByVal ProfileID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM Project WHERE projectID NOT IN (SELECT projectID FROM projectProfile WHERE ProfileID=@ProfileID)"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("ProjectNotInUserProjectByProfileID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ProfileID", ProfileID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                Return toReturn
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                Throw New Exception(ex.Message)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function
#End Region

#Region " Class Property Declarations "
        Public Property [ProjectProfileID]() As String
            Get
                Return _projectProfileID
            End Get
            Set(ByVal Value As String)
                _projectProfileID = Value
            End Set
        End Property

        Public Property [ProfileID]() As String
            Get
                Return _profileID
            End Get
            Set(ByVal Value As String)
                _profileID = Value
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
#End Region

    End Class
End Namespace
