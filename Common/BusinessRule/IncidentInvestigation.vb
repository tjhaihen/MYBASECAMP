Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class IncidentInvestigation
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _incidentNo, _incidentSubject, _incidentLocation, _incidentTime As String
        Private _severitySCode, _incidentType, _incidentDescription, _incidentWitness As String
        Private _incidentConsequence, _incidentConsequenceEst, _incidentTrigger, _correctiveAction As String
        Private _recommendationFromDeptMgr, _reviewByName, _userIDinsert, _userIDupdate, _userIDdelete As String
        Private _reportDate, _incidentDate, _insertDate, _updateDate, _deleteDate As Date
        Private _isApproved, _isDeleted As Boolean

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
            cmdToExecute.CommandText = "INSERT INTO incidentInvestigation " + _
                                        "(incidentNo, reportDate, incidentSubject, incidentLocation, incidentDate, " + _
                                        "incidentTime, severitySCode, incidentType, incidentDescription, incidentWitness, incidentConsequence, incidentConsequenceEst, " + _
                                        "incidentTrigger, correctiveAction, recommendationFromDeptMgr, reviewByName, isApproved, userIDinsert, userIDupdate, insertDate, " + _
                                        "updateDate, isDeleted, userIDdelete, deleteDate) " + _
                                        "VALUES " + _
                                        "(@incidentNo, @reportDate, @incidentSubject, @incidentLocation, @incidentDate, " + _
                                        "@incidentTime, @severitySCode, @incidentType, @incidentDescription, @incidentWitness, @incidentConsequence, @incidentConsequenceEst, " + _
                                        "@incidentTrigger, @correctiveAction, @recommendationFromDeptMgr, NULL, 0, @userIDinsert, NULL, GETDATE(), " + _
                                        "NULL, 0, NULL, NULL)"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strID As String = ID.GenerateIDNumber("incidentInvestigation", "incidentNo", "IR-")

            Try
                cmdToExecute.Parameters.AddWithValue("@incidentNo", strID)
                cmdToExecute.Parameters.AddWithValue("@reportDate", _reportDate)
                cmdToExecute.Parameters.AddWithValue("@incidentSubject", _incidentSubject)
                cmdToExecute.Parameters.AddWithValue("@incidentLocation", _incidentLocation)
                cmdToExecute.Parameters.AddWithValue("@incidentDate", _incidentDate)
                cmdToExecute.Parameters.AddWithValue("@incidentTime", _incidentTime)
                cmdToExecute.Parameters.AddWithValue("@severitySCode", _severitySCode)
                cmdToExecute.Parameters.AddWithValue("@incidentType", _incidentType)
                cmdToExecute.Parameters.AddWithValue("@incidentDescription", _incidentDescription)
                cmdToExecute.Parameters.AddWithValue("@incidentWitness", _incidentWitness)
                cmdToExecute.Parameters.AddWithValue("@incidentConsequence", _incidentConsequence)
                cmdToExecute.Parameters.AddWithValue("@incidentConsequenceEst", _incidentConsequenceEst)
                cmdToExecute.Parameters.AddWithValue("@incidentTrigger", _incidentTrigger)
                cmdToExecute.Parameters.AddWithValue("@correctiveAction", _correctiveAction)
                cmdToExecute.Parameters.AddWithValue("@recommendationFromDeptMgr", _recommendationFromDeptMgr)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)                

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _incidentNo = strID
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
            cmdToExecute.CommandText = "UPDATE incidentInvestigation " + _
                                        "SET incidentSubject=@incidentSubject, incidentLocation=@incidentLocation, incidentDate=@incidentDate, " + _
                                        "incidentTime=@incidentTime, severitySCode=@severitySCode, incidentType=@incidentType, " + _
                                        "incidentDescription=@incidentDescription, incidentWitness=@incidentWitness, incidentConsequence=@incidentConsequence, " + _
                                        "incidentConsequenceEst=@incidentConsequenceEst, incidentTrigger=@incidentTrigger, correctiveAction=@correctiveAction, recommendationFromDeptMgr=@recommendationFromDeptMgr, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE incidentNo=@incidentNo"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@incidentNo", _incidentNo)
                cmdToExecute.Parameters.AddWithValue("@incidentSubject", _incidentSubject)
                cmdToExecute.Parameters.AddWithValue("@incidentLocation", _incidentLocation)
                cmdToExecute.Parameters.AddWithValue("@incidentDate", _incidentDate)
                cmdToExecute.Parameters.AddWithValue("@incidentTime", _incidentTime)
                cmdToExecute.Parameters.AddWithValue("@severitySCode", _severitySCode)
                cmdToExecute.Parameters.AddWithValue("@incidentType", _incidentType)
                cmdToExecute.Parameters.AddWithValue("@incidentDescription", _incidentDescription)
                cmdToExecute.Parameters.AddWithValue("@incidentWitness", _incidentWitness)
                cmdToExecute.Parameters.AddWithValue("@incidentConsequence", _incidentConsequence)
                cmdToExecute.Parameters.AddWithValue("@incidentConsequenceEst", _incidentConsequenceEst)
                cmdToExecute.Parameters.AddWithValue("@incidentTrigger", _incidentTrigger)
                cmdToExecute.Parameters.AddWithValue("@correctiveAction", _correctiveAction)
                cmdToExecute.Parameters.AddWithValue("@recommendationFromDeptMgr", _recommendationFromDeptMgr)
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
            cmdToExecute.CommandText = "SELECT * FROM incidentInvestigation i " + _
                                        "ORDER BY i.incidentNo"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("incidentInvestigation")
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
            cmdToExecute.CommandText = "SELECT * FROM incidentInvestigation WHERE incidentNo=@incidentNo"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("incidentInvestigation")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@incidentNo", _incidentNo)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _incidentNo = CType(toReturn.Rows(0)("incidentNo"), String)
                    _reportDate = CType(toReturn.Rows(0)("reportDate"), Date)
                    _incidentSubject = CType(toReturn.Rows(0)("incidentSubject"), String)
                    _incidentLocation = CType(toReturn.Rows(0)("incidentLocation"), String)
                    _incidentDate = CType(toReturn.Rows(0)("incidentDate"), Date)
                    _incidentTime = CType(toReturn.Rows(0)("incidentTime"), String)
                    _severitySCode = CType(toReturn.Rows(0)("severitySCode"), String)
                    _incidentType = CType(toReturn.Rows(0)("incidentType"), String)
                    _incidentDescription = CType(ProcessNull.GetString(toReturn.Rows(0)("incidentDescription")), String)
                    _incidentWitness = CType(ProcessNull.GetString(toReturn.Rows(0)("incidentWitness")), String)
                    _incidentConsequence = CType(ProcessNull.GetString(toReturn.Rows(0)("incidentConsequence")), String)
                    _incidentConsequenceEst = CType(ProcessNull.GetString(toReturn.Rows(0)("incidentConsequenceEst")), String)
                    _incidentTrigger = CType(ProcessNull.GetString(toReturn.Rows(0)("incidentTrigger")), String)
                    _correctiveAction = CType(ProcessNull.GetString(toReturn.Rows(0)("correctiveAction")), String)
                    _recommendationFromDeptMgr = CType(ProcessNull.GetString(toReturn.Rows(0)("recommendationFromDeptMgr")), String)
                    _reviewByName = CType(ProcessNull.GetString(toReturn.Rows(0)("reviewByName")), String)
                    _isApproved = CType(toReturn.Rows(0)("isApproved"), Boolean)
                    _isDeleted = CType(toReturn.Rows(0)("isDeleted"), Boolean)
                    _userIDinsert = CType(toReturn.Rows(0)("userIDinsert"), String)
                    _userIDupdate = CType(ProcessNull.GetString(toReturn.Rows(0)("userIDupdate")), String)
                    _userIDdelete = CType(ProcessNull.GetString(toReturn.Rows(0)("userIDdelete")), String)
                    _insertDate = CType(toReturn.Rows(0)("insertDate"), DateTime)
                    _updateDate = CType(ProcessNull.GetDateTime(toReturn.Rows(0)("updateDate")), DateTime)
                    _deleteDate = CType(ProcessNull.GetDateTime(toReturn.Rows(0)("deleteDate")), DateTime)
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
            cmdToExecute.CommandText = "UPDATE incidentInvestigation " + _
                                        "SET isDeleted = 1, userIDdelete=@userIDdelete, deleteDate=GETDATE() " + _
                                        "WHERE incidentNo=@incidentNo"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@incidentNo", _incidentNo)
                cmdToExecute.Parameters.AddWithValue("@userIDdelete", _userIDdelete)

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

        Public Function UpdateApproval(ByVal struserNameApproval As String) As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "UPDATE incidentInvestigation " + _
                                        "SET reviewByName=@userNameApproval, isApproved=1, userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE incidentNo=@incidentNo"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@incidentNo", _incidentNo)
                cmdToExecute.Parameters.AddWithValue("@userNameApproval", struserNameApproval)
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

        Public Function SelectByYear(ByVal intYear As Integer) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM incidentInvestigation WHERE YEAR(ReportDate) = @Year AND IsDeleted=0"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("incidentInvestigationSelectByYear")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@Year", intYear)

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
        Public Property [incidentNo]() As String
            Get
                Return _incidentNo
            End Get
            Set(ByVal Value As String)
                _incidentNo = Value
            End Set
        End Property

        Public Property [reportDate]() As Date
            Get
                Return _reportDate
            End Get
            Set(ByVal Value As Date)
                _reportDate = Value
            End Set
        End Property

        Public Property [incidentSubject]() As String
            Get
                Return _incidentSubject
            End Get
            Set(ByVal Value As String)
                _incidentSubject = Value
            End Set
        End Property

        Public Property [incidentLocation]() As String
            Get
                Return _incidentLocation
            End Get
            Set(ByVal Value As String)
                _incidentLocation = Value
            End Set
        End Property

        Public Property [incidentDate]() As Date
            Get
                Return _incidentDate
            End Get
            Set(ByVal Value As Date)
                _incidentDate = Value
            End Set
        End Property

        Public Property [incidentTime]() As String
            Get
                Return _incidentTime
            End Get
            Set(ByVal Value As String)
                _incidentTime = Value
            End Set
        End Property

        Public Property [severitySCode]() As String
            Get
                Return _severitySCode
            End Get
            Set(ByVal Value As String)
                _severitySCode = Value
            End Set
        End Property

        Public Property [incidentType]() As String
            Get
                Return _incidentType
            End Get
            Set(ByVal Value As String)
                _incidentType = Value
            End Set
        End Property

        Public Property [incidentDescription]() As String
            Get
                Return _incidentDescription
            End Get
            Set(ByVal Value As String)
                _incidentDescription = Value
            End Set
        End Property

        Public Property [incidentWitness]() As String
            Get
                Return _incidentWitness
            End Get
            Set(ByVal Value As String)
                _incidentWitness = Value
            End Set
        End Property

        Public Property [incidentConsequence]() As String
            Get
                Return _incidentConsequence
            End Get
            Set(ByVal Value As String)
                _incidentConsequence = Value
            End Set
        End Property

        Public Property [incidentConsequenceEst]() As String
            Get
                Return _incidentConsequenceEst
            End Get
            Set(ByVal Value As String)
                _incidentConsequenceEst = Value
            End Set
        End Property

        Public Property [incidentTrigger]() As String
            Get
                Return _incidentTrigger
            End Get
            Set(ByVal Value As String)
                _incidentTrigger = Value
            End Set
        End Property

        Public Property [correctiveAction]() As String
            Get
                Return _correctiveAction
            End Get
            Set(ByVal Value As String)
                _correctiveAction = Value
            End Set
        End Property

        Public Property [recommendationFromDeptMgr]() As String
            Get
                Return _recommendationFromDeptMgr
            End Get
            Set(ByVal Value As String)
                _recommendationFromDeptMgr = Value
            End Set
        End Property

        Public Property [reviewByName]() As String
            Get
                Return _reviewByName
            End Get
            Set(ByVal Value As String)
                _reviewByName = Value
            End Set
        End Property

        Public Property [isApproved]() As Boolean
            Get
                Return _isApproved
            End Get
            Set(ByVal Value As Boolean)
                _isApproved = Value
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

        Public Property [isDeleted]() As Boolean
            Get
                Return _isDeleted
            End Get
            Set(ByVal Value As Boolean)
                _isDeleted = Value
            End Set
        End Property

        Public Property [userIDdelete]() As String
            Get
                Return _userIDdelete
            End Get
            Set(ByVal Value As String)
                _userIDdelete = Value
            End Set
        End Property

        Public Property [deleteDate]() As DateTime
            Get
                Return _deleteDate
            End Get
            Set(ByVal Value As DateTime)
                _deleteDate = Value
            End Set
        End Property

#End Region

    End Class
End Namespace
