Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class Issue
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _issueID, _projectID, _departmentName, _issueDescription, _issueTypeSCode, _issueStatusSCode, _keywords As String
        Private _issuePrioritySCode, _issueConfirmStatusSCode, _reportedBy, _userIDassignedTo, _assignedBy As String
        Private _reportedDate As DateTime
        Private _userIDinsert, _userIDupdate As String
        Private _insertDate, _updateDate, _assignedDate As DateTime
        Private _targetDate, _finishDate As Date
        Private _isUrgent As Boolean

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
            cmdToExecute.CommandText = "INSERT INTO Issue " + _
                                        "(issueID, projectID, departmentName, issueDescription, keywords, issueTypeSCode, issueStatusSCode, " + _
                                        "issuePrioritySCode, issueConfirmStatusSCode, reportedBy, reportedDate, userIDassignedTo, isUrgent, userIDinsert, userIDupdate, insertDate, updateDate, assignedBy, assignedDate, targetDate) " + _
                                        "VALUES " + _
                                        "(@issueID, @projectID, @departmentName, @issueDescription, @keywords, @issueTypeSCode, @issueStatusSCode, " + _
                                        "@issuePrioritySCode, @issueConfirmStatusSCode, @reportedBy, @reportedDate, @userIDassignedTo, @isUrgent, @userIDinsert, @userIDupdate, GETDATE(), GETDATE(), @assignedBy, GETDATE(), @targetDate)"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("Issue", "issueID")

            Try
                cmdToExecute.Parameters.AddWithValue("@issueID", strID)
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@departmentName", _departmentName)
                cmdToExecute.Parameters.AddWithValue("@issueDescription", _issueDescription)
                cmdToExecute.Parameters.AddWithValue("@keywords", _keywords)
                cmdToExecute.Parameters.AddWithValue("@issueTypeSCode", _issueTypeSCode)
                cmdToExecute.Parameters.AddWithValue("@issueStatusSCode", _issueStatusSCode)
                cmdToExecute.Parameters.AddWithValue("@issuePrioritySCode", _issuePrioritySCode)
                cmdToExecute.Parameters.AddWithValue("@issueConfirmStatusSCode", _issueConfirmStatusSCode)
                cmdToExecute.Parameters.AddWithValue("@reportedBy", _reportedBy)
                cmdToExecute.Parameters.AddWithValue("@reportedDate", _reportedDate)
                cmdToExecute.Parameters.AddWithValue("@userIDassignedTo", _userIDassignedTo)
                cmdToExecute.Parameters.AddWithValue("@isUrgent", _isUrgent)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)
                cmdToExecute.Parameters.AddWithValue("@assignedBy", _assignedBy)
                cmdToExecute.Parameters.AddWithValue("@targetDate", _targetDate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _issueID = strID
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
            cmdToExecute.CommandText = "UPDATE Issue " + _
                                        "SET departmentName=@departmentName, issueDescription=@issueDescription, keywords=@keywords, issueTypeSCode=@issueTypeSCode, " + _
                                        "issueStatusSCode=@issueStatusSCode, issuePrioritySCode=@issuePrioritySCode, issueConfirmStatusSCode=@issueConfirmStatusSCode, " + _
                                        "reportedBy=@reportedBy, reportedDate=@reportedDate, userIDassignedTo=@userIDassignedTo, isUrgent=@isUrgent, userIDupdate=@userIDupdate, updateDate=GETDATE(), " + _
                                        "targetDate=@targetDate " + _
                                        "WHERE issueID=@issueID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@issueID", _issueID)                
                cmdToExecute.Parameters.AddWithValue("@departmentName", _departmentName)
                cmdToExecute.Parameters.AddWithValue("@issueDescription", _issueDescription)
                cmdToExecute.Parameters.AddWithValue("@keywords", _keywords)
                cmdToExecute.Parameters.AddWithValue("@issueTypeSCode", _issueTypeSCode)
                cmdToExecute.Parameters.AddWithValue("@issueStatusSCode", _issueStatusSCode)
                cmdToExecute.Parameters.AddWithValue("@issuePrioritySCode", _issuePrioritySCode)
                cmdToExecute.Parameters.AddWithValue("@issueConfirmStatusSCode", _issueConfirmStatusSCode)
                cmdToExecute.Parameters.AddWithValue("@reportedBy", _reportedBy)
                cmdToExecute.Parameters.AddWithValue("@reportedDate", _reportedDate)
                cmdToExecute.Parameters.AddWithValue("@userIDassignedTo", _userIDassignedTo)
                cmdToExecute.Parameters.AddWithValue("@targetDate", _targetDate)
                cmdToExecute.Parameters.AddWithValue("@isUrgent", _isUrgent)
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

        Public Function UpdateAssigned() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "UPDATE Issue " + _
                                        "SET assignedBy = @assignedBy, AssignedDate = GETDATE(), targetDate=@targetDate " + _
                                        "WHERE issueID=@issueID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@issueID", _issueID)
                cmdToExecute.Parameters.AddWithValue("@assignedBy", _assignedBy)
                cmdToExecute.Parameters.AddWithValue("@targetDate", _targetDate)

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
            cmdToExecute.CommandText = "SELECT i.*, " + _
                                        "(SELECT caption FROM CommonCode WHERE groupCode='ISSUETYPE' AND code=i.issueTypeSCode) AS issueTypeName, " + _
                                        "(SELECT caption FROM CommonCode WHERE groupCode='ISSUESTATUS' AND code=i.issueStatusSCode) AS issueStatusName, " + _
                                        "(SELECT caption FROM CommonCode WHERE groupCode='ISSUEPRIORITY' AND code=i.issuePrioritySCode) AS issuePriorityName, " + _
                                        "(SELECT caption FROM CommonCode WHERE groupCode='ISSUECONFIRMSTS' AND code=i.issueConfirmStatusSCode) AS issueConfirmStatusName " + _
                                        "FROM Issue i " + _
                                        "ORDER BY i.projectID, i.issueID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Issue")
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
            cmdToExecute.CommandText = "SELECT * FROM Issue WHERE issueID=@issueID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Issue")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@issueID", _issueID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _issueID = CType(toReturn.Rows(0)("issueID"), String)
                    _projectID = CType(toReturn.Rows(0)("ProjectID"), String)
                    _departmentName = CType(toReturn.Rows(0)("departmentName"), String)
                    _issueDescription = CType(toReturn.Rows(0)("issueDescription"), String)
                    _keywords = CType(toReturn.Rows(0)("keywords"), String)
                    _issueTypeSCode = CType(toReturn.Rows(0)("issueTypeSCode"), String)
                    _issueStatusSCode = CType(toReturn.Rows(0)("issueStatusSCode"), String)
                    _issuePrioritySCode = CType(toReturn.Rows(0)("issuePrioritySCode"), String)
                    _issueConfirmStatusSCode = CType(toReturn.Rows(0)("issueConfirmStatusSCode"), String)
                    _reportedBy = CType(toReturn.Rows(0)("reportedBy"), String)
                    _reportedDate = CType(toReturn.Rows(0)("reportedDate"), DateTime)
                    _userIDassignedTo = CType(toReturn.Rows(0)("userIDassignedTo"), String)
                    _isUrgent = CType(toReturn.Rows(0)("isUrgent"), Boolean)
                    _userIDinsert = CType(toReturn.Rows(0)("userIDinsert"), String)
                    _userIDupdate = CType(toReturn.Rows(0)("userIDupdate"), String)
                    _insertDate = CType(toReturn.Rows(0)("insertDate"), DateTime)
                    _updateDate = CType(toReturn.Rows(0)("updateDate"), DateTime)
                    _targetDate = CType(toReturn.Rows(0)("targetDate"), DateTime)
                    _finishDate = CType(toReturn.Rows(0)("finishDate"), DateTime)
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
            cmdToExecute.CommandText = "DELETE FROM Issue " + _
                                        "WHERE issueID=@issueID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@issueID", _issueID)

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
        Public Function SelectByProjectID(ByVal IsAssignmentOnly As Boolean, ByVal IsOpenOnly As Boolean) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim strFilterOpenOnly As String = String.Empty
            If IsOpenOnly Then
                strFilterOpenOnly = " AND i.issueStatusSCode<>'003' "
            Else
                strFilterOpenOnly = String.Empty
            End If
            If IsAssignmentOnly = False Then
                cmdToExecute.CommandText = "SELECT i.*, " + _
                                        "(SELECT caption FROM CommonCode WHERE groupCode='ISSUETYPE' AND code=i.issueTypeSCode) AS issueTypeName, " + _
                                        "(SELECT caption FROM CommonCode WHERE groupCode='ISSUESTATUS' AND code=i.issueStatusSCode) AS issueStatusName, " + _
                                        "(SELECT caption FROM CommonCode WHERE groupCode='ISSUEPRIORITY' AND code=i.issuePrioritySCode) AS issuePriorityName, " + _
                                        "(SELECT caption FROM CommonCode WHERE groupCode='ISSUECONFIRMSTS' AND code=i.issueConfirmStatusSCode) AS issueConfirmStatusName, " + _
                                        "ISNULL((SELECT COUNT(responseID) FROM issueResponse WHERE issueID=i.issueID),0) AS totalResponse, " + _
                                        "ISNULL((SELECT firstName FROM Person WHERE personID=(SELECT personID FROM [User] WHERE userID=i.userIDAssignedTo)),'') AS userNameAssignedTo, " + _
                                        "isHasAttachment=CASE WHEN((SELECT COUNT(fileID) FROM [File] WHERE tableName='Issue' AND referenceID=i.issueID) > 0) THEN(1) ELSE(0) END " + _
                                        "FROM Issue i WHERE i.projectID=@projectID " + strFilterOpenOnly + _
                                        "ORDER BY i.projectID, i.issueID"
            Else
                cmdToExecute.CommandText = "SELECT i.*, " + _
                                        "(SELECT caption FROM CommonCode WHERE groupCode='ISSUETYPE' AND code=i.issueTypeSCode) AS issueTypeName, " + _
                                        "(SELECT caption FROM CommonCode WHERE groupCode='ISSUESTATUS' AND code=i.issueStatusSCode) AS issueStatusName, " + _
                                        "(SELECT caption FROM CommonCode WHERE groupCode='ISSUEPRIORITY' AND code=i.issuePrioritySCode) AS issuePriorityName, " + _
                                        "(SELECT caption FROM CommonCode WHERE groupCode='ISSUECONFIRMSTS' AND code=i.issueConfirmStatusSCode) AS issueConfirmStatusName, " + _
                                        "ISNULL((SELECT COUNT(responseID) FROM issueResponse WHERE issueID=i.issueID),0) AS totalResponse, " + _
                                        "ISNULL((SELECT firstName FROM Person WHERE personID=(SELECT personID FROM [User] WHERE userID=i.userIDAssignedTo)),'') AS userNameAssignedTo, " + _
                                        "isHasAttachment=CASE WHEN((SELECT COUNT(fileID) FROM [File] WHERE tableName='Issue' AND referenceID=i.issueID) > 0) THEN(1) ELSE(0) END " + _
                                        "FROM Issue i WHERE i.projectID=@projectID " + strFilterOpenOnly + _
                                        "AND i.UserIDAssignedTo=@UserIDAssignedTo " + _
                                        "ORDER BY i.projectID, i.issueID"
            End If
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Issue")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                If IsAssignmentOnly Then
                    cmdToExecute.Parameters.AddWithValue("@userIDassignedTo", _userIDassignedTo)
                End If

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

        Public Function SelectSummaryByProjectID(ByVal IsAssignmentOnly As Boolean) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            If IsAssignmentOnly = False Then
                cmdToExecute.CommandText = "SELECT " + _
                                        "totalIssue = (SELECT COUNT(issueID) FROM issue WHERE projectID=@projectID), " + _
                                        "totalOpen = (SELECT COUNT(issueID) FROM issue WHERE projectID=@projectID AND issueStatusSCode<>'003'), " + _
                                        "totalFinish = (SELECT COUNT(issueID) FROM issue WHERE projectID=@projectID AND issueStatusSCode='003')"
            Else
                cmdToExecute.CommandText = "SELECT " + _
                                        "totalIssue = (SELECT COUNT(issueID) FROM issue WHERE projectID=@projectID AND UserIDAssignedTo=@userIDassignedTo), " + _
                                        "totalOpen = (SELECT COUNT(issueID) FROM issue WHERE projectID=@projectID AND UserIDAssignedTo=@userIDassignedTo AND issueStatusSCode<>'003'), " + _
                                        "totalFinish = (SELECT COUNT(issueID) FROM issue WHERE projectID=@projectID AND UserIDAssignedTo=@userIDassignedTo AND issueStatusSCode='003')"
            End If            
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("IssueSummary")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                If IsAssignmentOnly Then
                    cmdToExecute.Parameters.AddWithValue("@userIDassignedTo", _userIDassignedTo)
                End If

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _totalIssue = CType(toReturn.Rows(0)("totalIssue"), Decimal)
                    _totalOpen = CType(toReturn.Rows(0)("totalOpen"), Decimal)
                    _totalFinish = CType(toReturn.Rows(0)("totalFinish"), Decimal)
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

        Public Function SelectByFilter(ByVal strProjectID As String, ByVal strIssueType As String, ByVal strIssuePriority As String, ByVal strUserIDAssignedTo As String, ByVal strIssueStatus As String, ByVal strIssueConfirmStatus As String, ByVal isUrgent As Boolean, ByVal isByPeriode As Boolean, ByVal dtStartDate As Date, ByVal dtEndDate As Date) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spSelectIssueByFilter"
            If isByPeriode Then cmdToExecute.CommandText = "spSelectIssueByFilterByPeriod"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("IssueByFilter")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@projectID", strProjectID)
                cmdToExecute.Parameters.AddWithValue("@issueTypeSCode", strIssueType)
                cmdToExecute.Parameters.AddWithValue("@issuePrioritySCode", strIssuePriority)
                cmdToExecute.Parameters.AddWithValue("@userIDAssignedTo", strUserIDAssignedTo)
                cmdToExecute.Parameters.AddWithValue("@issueStatusSCode", strIssueStatus)
                cmdToExecute.Parameters.AddWithValue("@issueConfirmStatusSCode", strIssueConfirmStatus)
                cmdToExecute.Parameters.AddWithValue("@isUrgent", isUrgent)
                If isByPeriode Then
                    cmdToExecute.Parameters.AddWithValue("@startDate", dtStartDate)
                    cmdToExecute.Parameters.AddWithValue("@endDate", dtEndDate)
                End If

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

        Public Function SelectProgressPeriod_Level2(ByVal dtDate As Date) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spSelectProgressPeriod_Level2"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("ProgressPeriod_Level2")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@dtDate", dtDate)

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

        Public Function SelectProgressPeriod_Level3(ByVal dtDate As Date, ByVal userID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spSelectProgressPeriod_Level3"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("ProgressPeriod_Level3")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@dtDate", dtDate)
                cmdToExecute.Parameters.AddWithValue("@userID", userID)

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

        Public Function SelectByKeywords(ByVal strProjectID As String, ByVal strKeywords As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spSelectIssueByKeywords"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("IssueByKeywords")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@projectID", strProjectID)
                cmdToExecute.Parameters.AddWithValue("@keywords", strKeywords)

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
        Public Property [IssueID]() As String
            Get
                Return _issueID
            End Get
            Set(ByVal Value As String)
                _issueID = Value
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

        Public Property [DepartmentName]() As String
            Get
                Return _departmentName
            End Get
            Set(ByVal Value As String)
                _departmentName = Value
            End Set
        End Property

        Public Property [IssueDescription]() As String
            Get
                Return _issueDescription
            End Get
            Set(ByVal Value As String)
                _issueDescription = Value
            End Set
        End Property

        Public Property [Keywords]() As String
            Get
                Return _keywords
            End Get
            Set(ByVal Value As String)
                _keywords = Value
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

        Public Property [IssueStatusSCode]() As String
            Get
                Return _issueStatusSCode
            End Get
            Set(ByVal Value As String)
                _issueStatusSCode = Value
            End Set
        End Property

        Public Property [IssuePrioritySCode]() As String
            Get
                Return _issuePrioritySCode
            End Get
            Set(ByVal Value As String)
                _issuePrioritySCode = Value
            End Set
        End Property

        Public Property [IssueConfirmStatusSCode]() As String
            Get
                Return _issueConfirmStatusSCode
            End Get
            Set(ByVal Value As String)
                _issueConfirmStatusSCode = Value
            End Set
        End Property

        Public Property [ReportedBy]() As String
            Get
                Return _reportedBy
            End Get
            Set(ByVal Value As String)
                _reportedBy = Value
            End Set
        End Property

        Public Property [ReportedDate]() As DateTime
            Get
                Return _reportedDate
            End Get
            Set(ByVal Value As DateTime)
                _reportedDate = Value
            End Set
        End Property

        Public Property [userIDassignedTo]() As String
            Get
                Return _userIDassignedTo
            End Get
            Set(ByVal Value As String)
                _userIDassignedTo = Value
            End Set
        End Property

        Public Property [isUrgent]() As Boolean
            Get
                Return _isUrgent
            End Get
            Set(ByVal Value As Boolean)
                _isUrgent = Value
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

        Public Property [assignedDate]() As DateTime
            Get
                Return _assignedDate
            End Get
            Set(ByVal Value As DateTime)
                _assignedDate = Value
            End Set
        End Property

        Public Property [assignedBy]() As String
            Get
                Return _assignedBy
            End Get
            Set(ByVal Value As String)
                _assignedBy = Value
            End Set
        End Property

        Public Property [targetDate]() As DateTime
            Get
                Return _targetDate
            End Get
            Set(ByVal Value As DateTime)
                _targetDate = Value
            End Set
        End Property

        Public Property [finishDate]() As DateTime
            Get
                Return _finishDate
            End Get
            Set(ByVal Value As DateTime)
                _finishDate = Value
            End Set
        End Property

        Public Property [totalIssue]() As Decimal
            Get
                Return _totalIssue
            End Get
            Set(ByVal Value As Decimal)
                _totalIssue = Value
            End Set
        End Property

        Public Property [totalOpen]() As Decimal
            Get
                Return _totalOpen
            End Get
            Set(ByVal Value As Decimal)
                _totalOpen = Value
            End Set
        End Property

        Public Property [totalFinish]() As Decimal
            Get
                Return _totalFinish
            End Get
            Set(ByVal Value As Decimal)
                _totalFinish = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
