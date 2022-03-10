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
        Private _issueID, _projectID, _departmentName, _issueDescription, _NextUpdateRemarks, _issueTypeSCode, _issueStatusSCode, _keywords,
            _renponseID, _responseTypeSCode, _responseTypeName, _responseDescription, _userIDupdateResponse, _userNameUpdateResponse, _userIDprint,
            _userNameprint, _responseDuration, _issuePriorityName, _issueTypeName, _issueConfirmStatusName, _issueStatusName As String
        Private _issuePrioritySCode, _issueConfirmStatusSCode, _reportedBy, _createdBy, _userIDassignedTo, _assignedBy, _patchNo, _responseID, _firmStatusName, _
             _responseTime, _responseTime2 As String
        'Private _issuePrioritySCode, _issueConfirmStatusSCode, _reportedBy, _userIDassignedTo, _assignedBy, _patchNo As String
        Private _reportedDate As DateTime
        Private _userIDinsert, _userIDupdate As String
        Private _insertDate, _updateDate, _assignedDate As DateTime
        Private _estStartDate, _targetDate, _finishDate, _NextUpdateDate, _responseDate, _updateDateResponse As Date
        Private _isUrgent, _isSpecific, _isPlanned As Boolean

        Private _totalIssue, _totalOpen, _totalInProgress, _totalDevFinish, _totalQCPassed, _totalFinish As Decimal
        Private _projectAliasName, _projectName As String
        Private _productRoadmapSCode As String

        Private _PICDev, _IssueType, _IssueStatus, _IssuePriority, _IssueConfirmStatus, _projectDescription As String
        Private _totalreported, _openissue, _progressissue, _needsampleissue, _finishissue, _totalissuefull, _overallprogress, _totalfinished As Decimal

        Private _strArray As String
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
                                        "(issueID, projectID, departmentName, issueDescription, keywords, issueTypeSCode, issueStatusSCode, patchNo, isSpecific, " + _
                                        "issuePrioritySCode, issueConfirmStatusSCode, reportedBy, reportedDate, userIDassignedTo, isUrgent, isPlanned, userIDinsert, userIDupdate, insertDate, updateDate, assignedBy, assignedDate, targetDate, " + _
                                        "estStartDate, productRoadmapSCode) " + _
                                        "VALUES " + _
                                        "(@issueID, @projectID, @departmentName, @issueDescription, @keywords, @issueTypeSCode, @issueStatusSCode, @patchNo, @isSpecific, " + _
                                        "@issuePrioritySCode, @issueConfirmStatusSCode, @reportedBy, @reportedDate, @userIDassignedTo, @isUrgent, @isPlanned, @userIDinsert, @userIDupdate, GETDATE(), GETDATE(), @assignedBy, GETDATE(), @targetDate, " + _
                                        "@estStartDate, @productRoadmapSCode)"
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
                cmdToExecute.Parameters.AddWithValue("@isPlanned", _isPlanned)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)
                cmdToExecute.Parameters.AddWithValue("@assignedBy", _assignedBy)
                cmdToExecute.Parameters.AddWithValue("@targetDate", _targetDate)
                cmdToExecute.Parameters.AddWithValue("@patchNo", _patchNo)
                cmdToExecute.Parameters.AddWithValue("@isSpecific", _isSpecific)
                cmdToExecute.Parameters.AddWithValue("@estStartDate", _estStartDate)
                cmdToExecute.Parameters.AddWithValue("@productRoadmapSCode", _productRoadmapSCode)

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

        'percobaan penambahan panel schedule
        Public Function InsertNextUpdate() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "UPDATE project SET " + _
                                        "NextUpdateDate = @NextUpdateDate, NextUpdateRemarks = @NextUpdateRemarks " + _
                                        "WHERE " + _
                                        "projectID=@projectID"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            'Dim strID As String = ID.GenerateIDNumber("Project", "ProjectID")

            Try
                cmdToExecute.Parameters.AddWithValue("@ProjectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@NextUpdateDate", _NextUpdateDate)
                cmdToExecute.Parameters.AddWithValue("@NextUpdateRemarks", _NextUpdateRemarks)

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
            cmdToExecute.CommandText = "UPDATE Issue " + _
                                        "SET departmentName=@departmentName, issueDescription=@issueDescription, keywords=@keywords, issueTypeSCode=@issueTypeSCode, " + _
                                        "issueStatusSCode=@issueStatusSCode, issuePrioritySCode=@issuePrioritySCode, issueConfirmStatusSCode=@issueConfirmStatusSCode, " + _
                                        "reportedBy=@reportedBy, reportedDate=@reportedDate, userIDassignedTo=@userIDassignedTo, isUrgent=@isUrgent, isPlanned=@isPlanned, userIDupdate=@userIDupdate, updateDate=GETDATE(), " + _
                                        "targetDate=@targetDate, patchNo=@patchNo, isSpecific=@isSpecific, " + _
                                        "estStartDate=@estStartDate, productRoadmapSCode=@productRoadmapSCode " + _
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
                cmdToExecute.Parameters.AddWithValue("@isPlanned", _isPlanned)
                cmdToExecute.Parameters.AddWithValue("@isUrgent", _isUrgent)
                cmdToExecute.Parameters.AddWithValue("@patchNo", _patchNo)
                cmdToExecute.Parameters.AddWithValue("@isSpecific", _isSpecific)
                cmdToExecute.Parameters.AddWithValue("@estStartDate", _estStartDate)
                cmdToExecute.Parameters.AddWithValue("@productRoadmapSCode", _productRoadmapSCode)
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
                                        "SET assignedBy=@assignedBy, AssignedDate=GETDATE(), targetDate=@targetDate " + _
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

        Public Function UpdateStatus() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "UPDATE Issue " + _
                                        "SET issueStatusSCode=@issueStatusSCode,  " + _
                                        "issueConfirmStatusSCode=@issueConfirmStatusSCode, " + _
                                        "patchNo=@patchNo, isSpecific=@isSpecific, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE issueID=@issueID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@issueID", _issueID)
                cmdToExecute.Parameters.AddWithValue("@issueStatusSCode", _issueStatusSCode)
                cmdToExecute.Parameters.AddWithValue("@issueConfirmStatusSCode", _issueConfirmStatusSCode)
                cmdToExecute.Parameters.AddWithValue("@patchNo", _patchNo)
                cmdToExecute.Parameters.AddWithValue("@isSpecific", _isSpecific)
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

        Public Function UpdatePatchNo() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "UPDATE Issue " + _
                                        "SET patchNo=@patchNo, isSpecific=@isSpecific, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE issueID=@issueID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@issueID", _issueID)
                cmdToExecute.Parameters.AddWithValue("@patchNo", _patchNo)
                cmdToExecute.Parameters.AddWithValue("@isSpecific", _isSpecific)
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
                    _isPlanned = CType(toReturn.Rows(0)("isPlanned"), Boolean)
                    _userIDinsert = CType(toReturn.Rows(0)("userIDinsert"), String)
                    _userIDupdate = CType(toReturn.Rows(0)("userIDupdate"), String)
                    _insertDate = CType(toReturn.Rows(0)("insertDate"), DateTime)
                    _updateDate = CType(toReturn.Rows(0)("updateDate"), DateTime)
                    _estStartDate = CType(toReturn.Rows(0)("estStartDate"), DateTime)
                    _targetDate = CType(toReturn.Rows(0)("targetDate"), DateTime)
                    _finishDate = CType(toReturn.Rows(0)("finishDate"), DateTime)
                    _patchNo = CType(toReturn.Rows(0)("patchNo"), String)
                    _isSpecific = CType(toReturn.Rows(0)("isSpecific"), Boolean)
                    _productRoadmapSCode = CType(toReturn.Rows(0)("productRoadmapSCode"), String)
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
        'percobaan ambil response description
        Public Function ambilresponse() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "select ir.issueID, ir.responseDate, ir.responseTimeStart, ir.responseDuration, ir.responseDescription," + _
                                        "ISNULL((select (Isnull(firstName,' ') +' '+ Isnull(middleName,' ')+' '+ Isnull(lastName,' ')) from person where personID=ISNULL(ir.userIDupdate,'')),'') as userNameUpdateResponse  " + _
                                        "from issueResponse ir  " + _
                                        "inner join issue i on i.issueID = ir.issueID  " + _
                                        "where ir.issueID = @issueID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("issueResponse")
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
                    _responseDate = CType(toReturn.Rows(0)("responseDate"), DateTime)
                    _responseTime = CType(toReturn.Rows(0)("responseTimeStart"), DateTime)
                    _responseDuration = CType(toReturn.Rows(0)("responseDuration"), String)
                    _responseDescription = CType(toReturn.Rows(0)("responseDescription"), String)
                    _userNameUpdateResponse = CType(toReturn.Rows(0)("userNameUpdateResponse"), String)
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

        'percobaan ambil response description
        Public Function ambilupdatenameresponse() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "select top 1 ir.issueID, ISNULL((select (Isnull(firstName,' ') +' '+ Isnull(middleName,' ')+' '+ Isnull(lastName,' ')) from person where personID=ISNULL(ir.userIDupdate,'')),'') as userNameUpdateResponse " + _
                                        "from issueResponse ir " + _
                                        "where issueID = @issueID " + _
                                        "order by responseID DESC"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("issueResponse")
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
                    _userNameUpdateResponse = CType(toReturn.Rows(0)("userNameUpdateResponse"), String)
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

        '--percobaan print form issue ticket 
        Public Function PrintTicket() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "srIssueTicketForm"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("IssueTicketForm")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)


            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@issueID", _issueID)
                cmdToExecute.Parameters.AddWithValue("@userIDprint", _userIDprint)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _projectName = CType(toReturn.Rows(0)("projectName"), String)
                    _projectAliasName = CType(toReturn.Rows(0)("projectAliasName"), String)
                    _issueID = CType(toReturn.Rows(0)("issueID"), String)
                    _departmentName = CType(toReturn.Rows(0)("departmentName"), String)
                    _issueDescription = CType(toReturn.Rows(0)("issueDescription"), String)
                    _targetDate = CType(toReturn.Rows(0)("targetDate"), DateTime)
                    _reportedDate = CType(toReturn.Rows(0)("reportedDate"), DateTime)
                    _reportedBy = CType(toReturn.Rows(0)("reportedby"), String)
                    _issuePriorityName = CType(toReturn.Rows(0)("issuePriorityName"), String)
                    _issueTypeName = CType(toReturn.Rows(0)("issueTypeName"), String)
                    _issueStatusName = CType(toReturn.Rows(0)("issueStatusName"), String)
                    _issueConfirmStatusName = CType(toReturn.Rows(0)("issueConfirmStatusName"), String)
                    _userNameUpdateResponse = CType(toReturn.Rows(0)("userNameUpdateResponse"), String)
                    _userIDprint = CType(toReturn.Rows(0)("userIDprint"), String)
                    _userNameprint = CType(toReturn.Rows(0)("userNameprint"), String)
                    _responseDate = CType(toReturn.Rows(0)("responseDate"), DateTime)
                    _responseTime2 = CType(toReturn.Rows(0)("responseTimeStart"), String)
                    _responseTime = CType(toReturn.Rows(0)("responseTimeStart"), String)
                    _responseDuration = CType(toReturn.Rows(0)("responseDuration"), String)
                    _responseDescription = CType(toReturn.Rows(0)("responseDescription"), String)
                    _userNameUpdateResponse = CType(toReturn.Rows(0)("userNameUpdateResponse"), String)
                    _userIDprint = CType(toReturn.Rows(0)("userIDprint"), String)
                    _userNameprint = CType(toReturn.Rows(0)("userNameprint"), String)
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


        '--percobaan print
        Public Function PrintIssue() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "sprpt_ListIssue"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("Print")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)


            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@tglTarget", Date.Today)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _issueID = CType(toReturn.Rows(0)("issueid"), String)
                    _departmentName = CType(toReturn.Rows(0)("departmentName"), String)
                    _issueDescription = CType(toReturn.Rows(0)("issueDescription"), String)
                    _userIDassignedTo = CType(toReturn.Rows(0)("userIDassignedTo"), String)
                    _PICDev = CType(toReturn.Rows(0)("PICDev"), String)
                    _IssueType = CType(toReturn.Rows(0)("IssueType"), String)
                    _IssueStatus = CType(toReturn.Rows(0)("IssueStatus"), String)
                    _IssuePriority = CType(toReturn.Rows(0)("IssuePriority"), String)

                    '_issuePrioritySCode = CType(toReturn.Rows(0)("issuePrioritySCode"), String)
                    '_issueStatusSCode = CType(toReturn.Rows(0)("IssueStatusSCode"), String)
                    _projectID = CType(toReturn.Rows(0)("projectID"), String)
                    '_projectAliasName = CType(toReturn.Rows(0)("projectAliasName"), String)
                    _projectName = CType(toReturn.Rows(0)("projectName"), String)
                    '_issueTypeSCode = CType(toReturn.Rows(0)("issueTypeSCode"), String)
                    '_reportedDate = CType(toReturn.Rows(0)("reportedDate"), DateTime)
                    _reportedBy = CType(toReturn.Rows(0)("reportedby"), String)
                    '_issueConfirmStatusSCode = CType(toReturn.Rows(0)("issueConfirmStatusSCode"), String)
                    '_IssueConfirmStatus = CType(toReturn.Rows(0)("IssueConfirmStatus"), String)
                    '_updateDate = CType(toReturn.Rows(0)("updateDate"), DateTime)
                    '_insertDate = CType(toReturn.Rows(0)("insertDate"), DateTime)
                    '_assignedDate = CType(toReturn.Rows(0)("assignedDate"), DateTime)
                    _targetDate = CType(toReturn.Rows(0)("targetDate"), DateTime)
                    '_finishDate = CType(toReturn.Rows(0)("finishDate"), DateTime)
                    '_isUrgent = CType(toReturn.Rows(0)("isUrgent"), Boolean)
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

        Public Function Hitungtotal() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "sprpt_TotalIssue"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("IssueSummary")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                cmdToExecute.Parameters.AddWithValue("@tglTarget", Date.Today)
                'If IsAssignmentOnly Then
                '    cmdToExecute.Parameters.AddWithValue("@userIDassignedTo", _userIDassignedTo)
                'End If

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _totalreported = CType(toReturn.Rows(0)("totalreported"), Decimal)
                    _openissue = CType(toReturn.Rows(0)("openissue"), Decimal)
                    _progressissue = CType(toReturn.Rows(0)("progressissue"), Decimal)
                    _needsampleissue = CType(toReturn.Rows(0)("needsampleissue"), Decimal)
                    _finishissue = CType(toReturn.Rows(0)("finishissue"), Decimal)
                    _totalissuefull = CType(toReturn.Rows(0)("totalissuefull"), Decimal)
                    _overallprogress = CType(toReturn.Rows(0)("overallprogress"), Decimal)
                    _totalfinished = CType(toReturn.Rows(0)("totalfinished"), Decimal)
                    _totalDevFinish = CType(toReturn.Rows(0)("finishDevissue"), Decimal)

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

        Public Function SummaryisPlanned(ByVal strUserIDAssignedTo As String, ByVal startDate As Date, ByVal endDate As Date, ProjectGroupID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim cmdUserIDAssignedToFilter As String = String.Empty

            If strUserIDAssignedTo.Length > 0 And strUserIDAssignedTo.Trim <> "All" Then
                cmdUserIDAssignedToFilter = " AND i.UserIDAssignedTo = @UserIDAssignedTo "
            End If

            cmdToExecute.CommandText = "SELECT " + _
                "totalIssue = (SELECT COUNT(i.issueID) FROM issue i INNER JOIN project p ON i.projectID = p.projectID WHERE i.targetDate BETWEEN @startDate AND @endDate AND i.IsPlanned=1 AND p.projectGroupID=@projectGroupID " + cmdUserIDAssignedToFilter + "), " + _
                "totalOpen = (SELECT COUNT(i.issueID) FROM issue i INNER JOIN project p ON i.projectID = p.projectID WHERE i.targetDate BETWEEN @startDate AND @endDate AND i.IsPlanned=1 AND p.projectGroupID=@projectGroupID AND i.issueStatusSCode NOT IN ('002','002-1','002-5','003') " + cmdUserIDAssignedToFilter + "), " + _
                "totalInProgress = (SELECT COUNT(i.issueID) FROM issue i INNER JOIN project p ON i.projectID = p.projectID WHERE i.targetDate BETWEEN @startDate AND @endDate AND i.IsPlanned=1 AND p.projectGroupID=@projectGroupID AND i.issueStatusSCode='002' " + cmdUserIDAssignedToFilter + "), " + _
                "totalDevFinish = (SELECT COUNT(i.issueID) FROM issue i INNER JOIN project p ON i.projectID = p.projectID WHERE i.targetDate BETWEEN @startDate AND @endDate AND i.IsPlanned=1 AND p.projectGroupID=@projectGroupID AND i.issueStatusSCode='002-1' " + cmdUserIDAssignedToFilter + "), " + _
                "totalQCPassed = (SELECT COUNT(i.issueID) FROM issue i INNER JOIN project p ON i.projectID = p.projectID WHERE i.targetDate BETWEEN @startDate AND @endDate AND i.IsPlanned=1 AND p.projectGroupID=@projectGroupID AND i.issueStatusSCode='002-5' " + cmdUserIDAssignedToFilter + "), " + _
                "totalFinish = (SELECT COUNT(i.issueID) FROM issue i INNER JOIN project p ON i.projectID = p.projectID WHERE i.targetDate BETWEEN @startDate AND @endDate AND i.IsPlanned=1 AND p.projectGroupID=@projectGroupID AND i.issueStatusSCode='003' " + cmdUserIDAssignedToFilter + ")"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("IssueSummary")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@startDate", startDate)
                cmdToExecute.Parameters.AddWithValue("@endDate", endDate)
                cmdToExecute.Parameters.AddWithValue("@user", strUserIDAssignedTo)
                cmdToExecute.Parameters.AddWithValue("@projectGroupID", ProjectGroupID)
                If cmdUserIDAssignedToFilter.Trim.Length > 0 Then
                    cmdToExecute.Parameters.AddWithValue("@userIDassignedTo", strUserIDAssignedTo)
                End If

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _totalIssue = CType(toReturn.Rows(0)("totalIssue"), Decimal)
                    _totalOpen = CType(toReturn.Rows(0)("totalOpen"), Decimal)
                    _totalInProgress = CType(toReturn.Rows(0)("totalInProgress"), Decimal)
                    _totalDevFinish = CType(toReturn.Rows(0)("totalDevFinish"), Decimal)
                    _totalQCPassed = CType(toReturn.Rows(0)("totalQCPassed"), Decimal)
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

        Public Function SummaryisPlannedOutstanding() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT " + _
                "totalIssue = (SELECT COUNT(i.issueID) FROM issue i INNER JOIN project p ON i.projectID = p.projectID WHERE i.IsPlanned=1 AND i.issueStatusSCode NOT IN ('002-1','002-5','003')), " + _
                "totalOpen = (SELECT COUNT(i.issueID) FROM issue i INNER JOIN project p ON i.projectID = p.projectID WHERE i.IsPlanned=1 AND i.issueStatusSCode NOT IN ('002','002-1','002-5','003')), " + _
                "totalInProgress = (SELECT COUNT(i.issueID) FROM issue i INNER JOIN project p ON i.projectID = p.projectID WHERE i.IsPlanned=1 AND i.issueStatusSCode NOT IN ('002-1','002-5','003') AND i.issueStatusSCode='002'), " + _
                "totalDevFinish = 0, " + _
                "totalQCPassed = 0, " + _
                "totalFinish = 0"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("IssueSummaryOutstanding")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _totalIssue = CType(toReturn.Rows(0)("totalIssue"), Decimal)
                    _totalOpen = CType(toReturn.Rows(0)("totalOpen"), Decimal)
                    _totalInProgress = CType(toReturn.Rows(0)("totalInProgress"), Decimal)
                    _totalDevFinish = CType(toReturn.Rows(0)("totalDevFinish"), Decimal)
                    _totalQCPassed = CType(toReturn.Rows(0)("totalQCPassed"), Decimal)
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
                strFilterOpenOnly = " AND i.issueStatusSCode IN ('','001','002','009','002-6') "
            Else
                strFilterOpenOnly = String.Empty
            End If
            If IsAssignmentOnly = False Then
                cmdToExecute.CommandText = "SELECT i.*, " + _
                                        "(SELECT caption FROM CommonCode WHERE groupCode='ISSUETYPE' AND code=i.issueTypeSCode) AS issueTypeName, " + _
                                        "(SELECT caption FROM CommonCode WHERE groupCode='ISSUESTATUS' AND code=i.issueStatusSCode) AS issueStatusName, " + _
                                        "(SELECT caption FROM CommonCode WHERE groupCode='ISSUEPRIORITY' AND code=i.issuePrioritySCode) AS issuePriorityName, " + _
                                        "(SELECT caption FROM CommonCode WHERE groupCode='ISSUECONFIRMSTS' AND code=i.issueConfirmStatusSCode) AS issueConfirmStatusName, " + _
                                        "(SELECT caption FROM CommonCode WHERE groupCode='PRODUCTROADMAP' AND [value]=i.productRoadmapSCode) AS productRoadmapName," + _
                                        "ISNULL((SELECT COUNT(responseID) FROM issueResponse WHERE issueID=i.issueID),0) AS totalResponse, " + _
                                        "ISNULL((SELECT firstName FROM Person WHERE personID=(SELECT personID FROM [User] WHERE userID=i.userIDAssignedTo)),'') AS userNameAssignedTo, " + _
                                        "ISNULL((SELECT firstName FROM Person WHERE personID=(SELECT personID FROM [User] WHERE userID=i.userIDInsert)),'') AS userNameInsert, " + _
                                        "ISNULL((SELECT firstName FROM Person WHERE personID=(SELECT personID FROM [User] WHERE userID=i.userIDUpdate)),'') AS userNameUpdate, " + _
                                        "isHasAttachment=CASE WHEN((SELECT COUNT(fileID) FROM [File] WHERE tableName='Issue' AND referenceID=i.issueID) > 0) THEN(1) ELSE(0) END " + _
                                        "FROM Issue i WHERE i.projectID=@projectID " + strFilterOpenOnly + _
                                        "ORDER BY i.projectID, i.issueID"
            Else
                cmdToExecute.CommandText = "SELECT i.*, " + _
                                        "(SELECT caption FROM CommonCode WHERE groupCode='ISSUETYPE' AND code=i.issueTypeSCode) AS issueTypeName, " + _
                                        "(SELECT caption FROM CommonCode WHERE groupCode='ISSUESTATUS' AND code=i.issueStatusSCode) AS issueStatusName, " + _
                                        "(SELECT caption FROM CommonCode WHERE groupCode='ISSUEPRIORITY' AND code=i.issuePrioritySCode) AS issuePriorityName, " + _
                                        "(SELECT caption FROM CommonCode WHERE groupCode='ISSUECONFIRMSTS' AND code=i.issueConfirmStatusSCode) AS issueConfirmStatusName, " + _
                                        "(SELECT caption FROM CommonCode WHERE groupCode='PRODUCTROADMAP' AND [value]=i.productRoadmapSCode) AS productRoadmapName," + _
                                        "ISNULL((SELECT COUNT(responseID) FROM issueResponse WHERE issueID=i.issueID),0) AS totalResponse, " + _
                                        "ISNULL((SELECT firstName FROM Person WHERE personID=(SELECT personID FROM [User] WHERE userID=i.userIDAssignedTo)),'') AS userNameAssignedTo, " + _
                                        "ISNULL((SELECT firstName FROM Person WHERE personID=(SELECT personID FROM [User] WHERE userID=i.userIDInsert)),'') AS userNameInsert, " + _
                                        "ISNULL((SELECT firstName FROM Person WHERE personID=(SELECT personID FROM [User] WHERE userID=i.userIDUpdate)),'') AS userNameUpdate, " + _
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

        Public Function SelectByPlanned(ByVal strUserIDAssignedTo As String, ByVal startDate As Date, ByVal endDate As Date, strProjectGroupID As String, strProjectID As String, strIssueStatusSCode As String, Optional ByVal IsGetUsersOnly As Boolean = False) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim cmdGetUsersOnlySTART As String = String.Empty
            Dim cmdGetUsersOnlyEND As String = String.Empty
            Dim cmdProjectFilter As String = String.Empty
            Dim cmdIssueStatusFilter As String = String.Empty
            Dim cmdUserIDAssignedToFilter As String = String.Empty
            Dim cmdOrderBy As String = String.Empty

            cmdGetUsersOnlySTART = "SELECT DISTINCT lst.userIDAssignedTo, lst.userNameAssignedTo FROM ( "
            cmdGetUsersOnlyEND = " ) lst "

            If strProjectID.Length > 0 And strProjectID.Trim <> "All" Then
                cmdProjectFilter = " AND i.projectID = @projectID "
            End If

            If strIssueStatusSCode.Length > 0 And strIssueStatusSCode.Trim <> "All" Then
                cmdIssueStatusFilter = " AND i.issueStatusSCode = @issueStatusSCode "
            End If

            If strUserIDAssignedTo.Length > 0 And strUserIDAssignedTo.Trim <> "All" Then
                cmdUserIDAssignedToFilter = " AND i.UserIDAssignedTo = @UserIDAssignedTo "
            End If

            If IsGetUsersOnly = False Then
                cmdOrderBy = " ORDER BY i.issueID "
            Else
                cmdOrderBy = " ORDER BY lst.userNameAssignedTo "
            End If

            cmdToExecute.CommandText = "SELECT i.*, p.ProjectAliasName, " + _
                "(SELECT caption FROM CommonCode WHERE groupCode='ISSUETYPE' AND code=i.issueTypeSCode) AS issueTypeName, " + _
                "(SELECT caption FROM CommonCode WHERE groupCode='ISSUESTATUS' AND code=i.issueStatusSCode) AS issueStatusName, " + _
                "(SELECT caption FROM CommonCode WHERE groupCode='ISSUEPRIORITY' AND code=i.issuePrioritySCode) AS issuePriorityName, " + _
                "(SELECT caption FROM CommonCode WHERE groupCode='ISSUECONFIRMSTS' AND code=i.issueConfirmStatusSCode) AS issueConfirmStatusName, " + _
                "(SELECT caption FROM CommonCode WHERE groupCode='PRODUCTROADMAP' AND [value]=i.productRoadmapSCode) AS productRoadmapName, " + _
                "ISNULL((SELECT COUNT(responseID) FROM issueResponse WHERE issueID=i.issueID),0) AS totalResponse, " + _
                "ISNULL((SELECT firstName FROM Person WHERE personID=(SELECT personID FROM [User] WHERE userID=i.userIDAssignedTo)),'') AS userNameAssignedTo, " + _
                "ISNULL((SELECT firstName FROM Person WHERE personID=(SELECT personID FROM [User] WHERE userID=i.userIDInsert)),'') AS userNameInsert, " + _
                "ISNULL((SELECT firstName FROM Person WHERE personID=(SELECT personID FROM [User] WHERE userID=i.userIDUpdate)),'') AS userNameUpdate, " + _
                "DATEDIFF(DAY,i.reportedDate,GETDATE()) AS issueAgeInDay, " + _
                "DATEDIFF(DAY,i.targetDate,GETDATE()) AS dueToTargetDateAgeInDay, " + _
                "isHasAttachment=CASE WHEN((SELECT COUNT(fileID) FROM [File] WHERE tableName='Issue' AND referenceID=i.issueID) > 0) THEN(1) ELSE(0) END " + _
                "FROM Issue i INNER JOIN Project p ON i.ProjectID = p.ProjectID WHERE i.targetDate BETWEEN @startDate AND @endDate " + _
                "AND p.ProjectGroupID = @ProjectGroupID AND i.IsPlanned = 1" + cmdProjectFilter + cmdIssueStatusFilter + cmdUserIDAssignedToFilter

            If IsGetUsersOnly = True Then
                cmdToExecute.CommandText = cmdGetUsersOnlySTART + cmdToExecute.CommandText + cmdGetUsersOnlyEND + cmdOrderBy
            Else
                cmdToExecute.CommandText += cmdOrderBy
            End If

            Dim toReturn As DataTable = New DataTable("SelectByPlanned")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@startDate", startDate)
                cmdToExecute.Parameters.AddWithValue("@endDate", endDate)
                cmdToExecute.Parameters.AddWithValue("@projectGroupID", strProjectGroupID)
                cmdToExecute.Parameters.AddWithValue("@projectID", strProjectID)
                cmdToExecute.Parameters.AddWithValue("@issueStatusSCode", strIssueStatusSCode)
                If cmdUserIDAssignedToFilter.Trim.Length > 0 Then
                    cmdToExecute.Parameters.AddWithValue("@userIDassignedTo", strUserIDAssignedTo)
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

        Public Function SelectByPlannedOutstanding() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim cmdOrderBy As String = String.Empty

            cmdToExecute.CommandText = "SELECT i.*, p.ProjectAliasName, " + _
                "(SELECT caption FROM CommonCode WHERE groupCode='ISSUETYPE' AND code=i.issueTypeSCode) AS issueTypeName, " + _
                "(SELECT caption FROM CommonCode WHERE groupCode='ISSUESTATUS' AND code=i.issueStatusSCode) AS issueStatusName, " + _
                "(SELECT caption FROM CommonCode WHERE groupCode='ISSUEPRIORITY' AND code=i.issuePrioritySCode) AS issuePriorityName, " + _
                "(SELECT caption FROM CommonCode WHERE groupCode='ISSUECONFIRMSTS' AND code=i.issueConfirmStatusSCode) AS issueConfirmStatusName, " + _
                "(SELECT caption FROM CommonCode WHERE groupCode='PRODUCTROADMAP' AND [value]=i.productRoadmapSCode) AS productRoadmapName, " + _
                "ISNULL((SELECT COUNT(responseID) FROM issueResponse WHERE issueID=i.issueID),0) AS totalResponse, " + _
                "ISNULL((SELECT firstName FROM Person WHERE personID=(SELECT personID FROM [User] WHERE userID=i.userIDAssignedTo)),'') AS userNameAssignedTo, " + _
                "ISNULL((SELECT firstName FROM Person WHERE personID=(SELECT personID FROM [User] WHERE userID=i.userIDInsert)),'') AS userNameInsert, " + _
                "ISNULL((SELECT firstName FROM Person WHERE personID=(SELECT personID FROM [User] WHERE userID=i.userIDUpdate)),'') AS userNameUpdate, " + _
                "DATEDIFF(DAY,i.reportedDate,GETDATE()) AS issueAgeInDay, " + _
                "DATEDIFF(DAY,i.targetDate,GETDATE()) AS dueToTargetDateAgeInDay, " + _
                "isHasAttachment=CASE WHEN((SELECT COUNT(fileID) FROM [File] WHERE tableName='Issue' AND referenceID=i.issueID) > 0) THEN(1) ELSE(0) END " + _
                "FROM Issue i INNER JOIN Project p ON i.ProjectID = p.ProjectID WHERE i.IsPlanned = 1 " + _
                "AND i.issueStatusSCode NOT IN ('002-1','002-5','003') " + _
                "ORDER BY i.targetDate, i.issueID"

            Dim toReturn As DataTable = New DataTable("SelectByPlannedOutstanding")
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

        Public Function SelectSummaryByProjectID(ByVal IsAssignmentOnly As Boolean) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            If IsAssignmentOnly = False Then
                cmdToExecute.CommandText = "SELECT " + _
                                        "totalIssue = (SELECT COUNT(issueID) FROM issue WHERE projectID=@projectID), " + _
                                        "totalOpen = (SELECT COUNT(issueID) FROM issue WHERE projectID=@projectID AND issueStatusSCode NOT IN ('002','002-1','002-5','003')), " + _
                                        "totalInProgress = (SELECT COUNT(issueID) FROM issue WHERE projectID=@projectID AND issueStatusSCode='002'), " + _
                                        "totalDevFinish = (SELECT COUNT(issueID) FROM issue WHERE projectID=@projectID AND issueStatusSCode='002-1'), " + _
                                        "totalQCPassed = (SELECT COUNT(issueID) FROM issue WHERE projectID=@projectID AND issueStatusSCode='002-5'), " + _
                                        "totalFinish = (SELECT COUNT(issueID) FROM issue WHERE projectID=@projectID AND issueStatusSCode='003')"
            Else
                cmdToExecute.CommandText = "SELECT " + _
                                        "totalIssue = (SELECT COUNT(issueID) FROM issue WHERE projectID=@projectID AND UserIDAssignedTo=@userIDassignedTo), " + _
                                        "totalOpen = (SELECT COUNT(issueID) FROM issue WHERE projectID=@projectID AND UserIDAssignedTo=@userIDassignedTo AND issueStatusSCode NOT IN ('002','002-1','002-5','003')), " + _
                                        "totalInProgress = (SELECT COUNT(issueID) FROM issue WHERE projectID=@projectID AND UserIDAssignedTo=@userIDassignedTo AND issueStatusSCode='002'), " + _
                                        "totalDevFinish = (SELECT COUNT(issueID) FROM issue WHERE projectID=@projectID AND UserIDAssignedTo=@userIDassignedTo AND issueStatusSCode='002-1'), " + _
                                        "totalQCPassed = (SELECT COUNT(issueID) FROM issue WHERE projectID=@projectID AND UserIDAssignedTo=@userIDassignedTo AND issueStatusSCode='002-5'), " + _
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
                    _totalInProgress = CType(toReturn.Rows(0)("totalInProgress"), Decimal)
                    _totalDevFinish = CType(toReturn.Rows(0)("totalDevFinish"), Decimal)
                    _totalQCPassed = CType(toReturn.Rows(0)("totalQCPassed"), Decimal)
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

        Public Function SelectDashboardCustomer(ByVal strDisplayParameter As String, Optional ByVal strFilterParameter As String = "") As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Select Case strDisplayParameter
                Case "ByStatus"
                    cmdToExecute.CommandText = "spGetIssueByStatusCustomer"
                Case "ByType"
                    cmdToExecute.CommandText = "spGetIssueByTypeCustomer"
                Case "ByPriority"
                    cmdToExecute.CommandText = "spGetIssueByPriorityCustomer"
                Case "ByProductRoadmap"
                    cmdToExecute.CommandText = "spGetIssueByRoadmapCustomer"
                Case "ByTypeStatus"
                    cmdToExecute.CommandText = "spGetIssueByTypeStatusCustomer"
                Case "ByAllStatus"
                    cmdToExecute.CommandText = "spGetIssueAllStatusCustomer"
            End Select
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("spGetIssueBy")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@projectID", _projectID)
                Select Case strDisplayParameter
                    Case "ByTypeStatus"
                        cmdToExecute.Parameters.AddWithValue("@issueTypeSCode", strFilterParameter)
                End Select

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _strArray = CType(toReturn.Rows(0)("strArray"), String)
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

        Public Function SelectByFilter(ByVal strProductRoadmap As String, ByVal strProjectID As String, ByVal strIssueType As String, ByVal strIssuePriority As String, ByVal strUserIDAssignedTo As String, ByVal strIssueStatus As String, ByVal strIssueConfirmStatus As String, ByVal isUrgent As Boolean, ByVal isByPeriode As Boolean, ByVal dtStartDate As Date, ByVal dtEndDate As Date) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spSelectIssueByFilter"
            If isByPeriode Then cmdToExecute.CommandText = "spSelectIssueByFilterByPeriod"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("IssueByFilter")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@productRoadmapSCode", strProductRoadmap)
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

        Public Function SelectByFilterCustomer(ByVal strProductRoadmap As String, ByVal strProjectID As String, ByVal strIssueType As String, ByVal strIssuePriority As String, ByVal strUserIDAssignedTo As String, ByVal strIssueStatus As String, ByVal strIssueConfirmStatus As String, ByVal isByPeriode As Boolean, ByVal dtStartDate As Date, ByVal dtEndDate As Date) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spSelectIssueByFilterCustomer"
            If isByPeriode Then cmdToExecute.CommandText = "spSelectIssueByFilterByPeriodCustomer"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("IssueByFilterCustomer")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@productRoadmapSCode", strProductRoadmap)
                cmdToExecute.Parameters.AddWithValue("@projectID", strProjectID)
                cmdToExecute.Parameters.AddWithValue("@issueTypeSCode", strIssueType)
                cmdToExecute.Parameters.AddWithValue("@issuePrioritySCode", strIssuePriority)
                cmdToExecute.Parameters.AddWithValue("@userIDAssignedTo", strUserIDAssignedTo)
                cmdToExecute.Parameters.AddWithValue("@issueStatusSCode", strIssueStatus)
                cmdToExecute.Parameters.AddWithValue("@issueConfirmStatusSCode", strIssueConfirmStatus)
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

        Public Function SelectByUrgent(ByVal strUserIDAssignedTo As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spSelectIssueUrgent"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("IssueByUrgent")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                'cmdToExecute.Parameters.AddWithValue("@projectID", strProjectID)
                cmdToExecute.Parameters.AddWithValue("@userIDAssignedTo", strUserIDAssignedTo)

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
        '--percobaan
        Public Function SelectByMyday(ByVal strUserIDAssignedTo As String, ByVal tglTarget As DateTime) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spSelectIssueMyday"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("IssueByMyday")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@userIDAssignedTo", strUserIDAssignedTo)
                cmdToExecute.Parameters.AddWithValue("@tglTarget", tglTarget)

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

        Public Function SelectByKeywords(ByVal strProjectID As String, ByVal strIssueID As String, ByVal strKeywords As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spSelectIssueByKeywords"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("IssueByKeywords")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@projectID", strProjectID)
                cmdToExecute.Parameters.AddWithValue("@issueID", strIssueID)
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

        Public Function SelectIssueOutstandingByUserID(ByVal IsUrgentIssues As Boolean) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM issue WHERE userIDassignedTo=@UserID AND issueStatusSCode<>'003'"
            If IsUrgentIssues = True Then
                cmdToExecute.CommandText += " AND isUrgent=1"
            End If
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("IssueOutstandingByUserID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@UserID", _userIDassignedTo)

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

        Public Function SelectOneForInformation() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText =
                    "SELECT i.*, p.ProjectAliasName, p.ProjectName " + _
                    "FROM Issue i " + _
                    "INNER JOIN Project p ON i.projectID = p.projectID " + _
                    "WHERE issueID=@issueID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("SelectOneForInformation")
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
                    _patchNo = CType(toReturn.Rows(0)("patchNo"), String)
                    _projectAliasName = CType(toReturn.Rows(0)("projectAliasName"), String)
                    _projectName = CType(toReturn.Rows(0)("projectName"), String)
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

        Public Function SelectByPatchNo() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim strFilterOpenOnly As String = String.Empty
            cmdToExecute.CommandText = "SELECT i.*, pt.IsClosed, " + _
                                        "p.ProjectAliasName, p.ProjectName, i.departmentName AS IssueDepartment, " + _
                                        "(SELECT caption FROM CommonCode WHERE groupCode='ISSUETYPE' AND code=i.issueTypeSCode) AS issueTypeName, " + _
                                        "(SELECT caption FROM CommonCode WHERE groupCode='ISSUESTATUS' AND code=i.issueStatusSCode) AS issueStatusName, " + _
                                        "(SELECT caption FROM CommonCode WHERE groupCode='ISSUEPRIORITY' AND code=i.issuePrioritySCode) AS issuePriorityName, " + _
                                        "(SELECT caption FROM CommonCode WHERE groupCode='ISSUECONFIRMSTS' AND code=i.issueConfirmStatusSCode) AS issueConfirmStatusName, " + _
                                        "ISNULL((SELECT COUNT(responseID) FROM issueResponse WHERE issueID=i.issueID),0) AS totalResponse, " + _
                                        "ISNULL((SELECT firstName FROM Person WHERE personID=(SELECT personID FROM [User] WHERE userID=i.userIDupdate)),'') AS userNameupdate, " + _
                                        "isHasAttachment=CASE WHEN((SELECT COUNT(fileID) FROM [File] WHERE tableName='Issue' AND referenceID=i.issueID) > 0) THEN(1) ELSE(0) END " + _
                                        "FROM Issue i " + _
                                        "INNER JOIN Project p ON i.projectID = p.projectID " + _
                                        "INNER JOIN Patch pt ON i.patchNo=pt.patchNo " + _
                                        "WHERE i.patchNo=@patchNo AND i.patchNo <> '' " + _
                                        "ORDER BY i.projectID, i.issueID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Issue")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@patchNo", _patchNo)

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

        Public Function SelectPlannedByUserAssignedTo(ByVal dtStartDate As Date, ByVal dtEndDate As Date, ByVal strProjectGroupID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spSelectIssueCountByUserID"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("spSelectIssueCountByUserID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@startDate", dtStartDate)
                cmdToExecute.Parameters.AddWithValue("@endDate", dtEndDate)
                cmdToExecute.Parameters.AddWithValue("@projectGroupID", strProjectGroupID)


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

        Public Function SelectPlannedByProject(ByVal dtStartDate As Date, ByVal dtEndDate As Date, ByVal strProjectGroupID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spSelectIssueCountByProjectID"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("spSelectIssueCountByProjectID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@startDate", dtStartDate)
                cmdToExecute.Parameters.AddWithValue("@endDate", dtEndDate)
                cmdToExecute.Parameters.AddWithValue("@projectGroupID", strProjectGroupID)


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

        Public Property [IssueType]() As String
            Get
                Return _IssueType
            End Get
            Set(ByVal Value As String)
                _IssueType = Value
            End Set
        End Property

        Public Property [IssueStatus]() As String
            Get
                Return _IssueStatus
            End Get
            Set(ByVal Value As String)
                _IssueStatus = Value
            End Set
        End Property

        Public Property [PICDev]() As String
            Get
                Return _PICDev
            End Get
            Set(ByVal Value As String)
                _PICDev = Value
            End Set
        End Property

        Public Property [TotalReported]() As String
            Get
                Return _totalreported
            End Get
            Set(ByVal Value As String)
                _totalreported = Value
            End Set
        End Property

        Public Property [OpenIssue]() As String
            Get
                Return _openissue
            End Get
            Set(ByVal Value As String)
                _openissue = Value
            End Set
        End Property

        Public Property [ProgressIssue]() As String
            Get
                Return _progressissue
            End Get
            Set(ByVal Value As String)
                _progressissue = Value
            End Set
        End Property

        Public Property [NeedSampleIssue]() As String
            Get
                Return _needsampleissue
            End Get
            Set(ByVal Value As String)
                _needsampleissue = Value
            End Set
        End Property

        Public Property [FinishIssue]() As String
            Get
                Return _finishissue
            End Get
            Set(ByVal Value As String)
                _finishissue = Value
            End Set
        End Property

        Public Property [TotalIssueFull]() As String
            Get
                Return _totalissuefull
            End Get
            Set(ByVal Value As String)
                _totalissuefull = Value
            End Set
        End Property

        Public Property [OverallProgress]() As String
            Get
                Return _overallprogress
            End Get
            Set(ByVal Value As String)
                _overallprogress = Value
            End Set
        End Property

        Public Property [TotalFinished]() As String
            Get
                Return _totalfinished
            End Get
            Set(ByVal Value As String)
                _totalfinished = Value
            End Set
        End Property

        Public Property [IssuePriority]() As String
            Get
                Return _IssuePriority
            End Get
            Set(ByVal Value As String)
                _IssuePriority = Value
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

        Public Property [isPlanned]() As Boolean
            Get
                Return _isPlanned
            End Get
            Set(ByVal Value As Boolean)
                _isPlanned = Value
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

        Public Property [estStartDate]() As DateTime
            Get
                Return _estStartDate
            End Get
            Set(ByVal Value As DateTime)
                _estStartDate = Value
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

        Public Property [NextUpdateDate]() As DateTime
            Get
                Return _NextUpdateDate
            End Get
            Set(ByVal Value As DateTime)
                _NextUpdateDate = Value
            End Set
        End Property

        Public Property [NextUpdateRemarks]() As String
            Get
                Return _NextUpdateRemarks
            End Get
            Set(ByVal Value As String)
                _NextUpdateRemarks = Value
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

        Public Property [totalInProgress]() As Decimal
            Get
                Return _totalInProgress
            End Get
            Set(ByVal Value As Decimal)
                _totalInProgress = Value
            End Set
        End Property

        Public Property [totalDevFinish]() As Decimal
            Get
                Return _totalDevFinish
            End Get
            Set(ByVal Value As Decimal)
                _totalDevFinish = Value
            End Set
        End Property

        Public Property [totalQCPassed]() As Decimal
            Get
                Return _totalQCPassed
            End Get
            Set(ByVal Value As Decimal)
                _totalQCPassed = Value
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

        Public Property [PatchNo]() As String
            Get
                Return _patchNo
            End Get
            Set(ByVal Value As String)
                _patchNo = Value
            End Set
        End Property

        Public Property [isSpecific]() As Boolean
            Get
                Return _isSpecific
            End Get
            Set(ByVal Value As Boolean)
                _isSpecific = Value
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

        Public Property [ProjectName]() As String
            Get
                Return _projectName
            End Get
            Set(ByVal Value As String)
                _projectName = Value
            End Set
        End Property

        Public Property [ProductRoadmapSCode]() As String
            Get
                Return _productRoadmapSCode
            End Get
            Set(ByVal Value As String)
                _productRoadmapSCode = Value
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

        Public Property [renponseID]() As String
            Get
                Return _renponseID
            End Get
            Set(ByVal Value As String)
                _renponseID = Value
            End Set
        End Property

        Public Property [responseDate]() As DateTime
            Get
                Return _responseDate
            End Get
            Set(ByVal Value As DateTime)
                _responseDate = Value
            End Set
        End Property

        Public Property [responseTime]() As String
            Get
                Return _responseTime
            End Get
            Set(ByVal Value As String)
                _responseTime = Value
            End Set
        End Property

        Public Property [responseDuration]() As String
            Get
                Return _responseDuration
            End Get
            Set(ByVal Value As String)
                _responseDuration = Value
            End Set
        End Property

        Public Property [responseTypeSCode]() As String
            Get
                Return _responseTypeSCode
            End Get
            Set(ByVal Value As String)
                _responseTypeSCode = Value
            End Set
        End Property

        Public Property [responseTypeName]() As String
            Get
                Return _responseTypeName
            End Get
            Set(ByVal Value As String)
                _responseTypeName = Value
            End Set
        End Property

        Public Property [responseDescription]() As String
            Get
                Return _responseDescription
            End Get
            Set(ByVal Value As String)
                _responseDescription = Value
            End Set
        End Property

        Public Property [responseID]() As String
            Get
                Return _responseID
            End Get
            Set(ByVal Value As String)
                _responseID = Value
            End Set
        End Property

        Public Property [userIDupdateResponse]() As String
            Get
                Return _userIDupdateResponse
            End Get
            Set(ByVal Value As String)
                _userIDupdateResponse = Value
            End Set
        End Property

        Public Property [userNameUpdateResponse]() As String
            Get
                Return _userNameUpdateResponse
            End Get
            Set(ByVal Value As String)
                _userNameUpdateResponse = Value
            End Set
        End Property

        Public Property [updateDateResponse]() As DateTime
            Get
                Return _updateDateResponse
            End Get
            Set(ByVal Value As DateTime)
                _updateDateResponse = Value
            End Set
        End Property

        Public Property [userIDprint]() As String
            Get
                Return _userIDprint
            End Get
            Set(ByVal Value As String)
                _userIDprint = Value
            End Set
        End Property

        Public Property [userNameprint]() As String
            Get
                Return _userNameprint
            End Get
            Set(ByVal Value As String)
                _userNameprint = Value
            End Set
        End Property

        Public Property [issuePriorityName]() As String
            Get
                Return _issuePriorityName
            End Get
            Set(ByVal Value As String)
                _issuePriorityName = Value
            End Set
        End Property

        Public Property [issueTypeName]() As String
            Get
                Return _issueTypeName
            End Get
            Set(ByVal Value As String)
                _issueTypeName = Value
            End Set
        End Property

        Public Property [issueStatusName]() As String
            Get
                Return _issueStatusName
            End Get
            Set(ByVal Value As String)
                _issueStatusName = Value
            End Set
        End Property

        Public Property [issueConfirmStatusName]() As String
            Get
                Return _issueConfirmStatusName
            End Get
            Set(ByVal Value As String)
                _issueConfirmStatusName = Value
            End Set
        End Property

        Public Property [strArray]() As String
            Get
                Return _strArray
            End Get
            Set(ByVal Value As String)
                _strArray = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
