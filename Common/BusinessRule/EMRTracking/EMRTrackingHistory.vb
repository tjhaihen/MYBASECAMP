Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class EMRTrackingHistory
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _trackingID, _locationCode, _remarks, _processType, _userIDprocess As String
        Private _MRN, _registrationID As Integer
        Private _mutationDate, _processDate As Date
        Private _isActive, _isCurrentPosition As Boolean

        Private _medicalNo, _patientName, _registrationNo, _userNameProcess, _locationName, _locationGroupName As String

        Private _cityOfBirth, _cfDateOfBirth, _sex, _bloodType, _bloodRhesus, _religion As String
        Private _streetName, _county, _district, _city, _zipCodeID, _phoneNo1, _phoneNo2, _mobilePhone1, _mobilePhone2 As String
        Private _currentLocationName As String

        Private _MRNCount, _TotalMRNCount, _TotalMRNoutCount As Integer
        Private _LastMedicalNo, _LastPatientName As String
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
            cmdToExecute.CommandText = "spEMRTrackingHistoryInsert"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@MedicalNo", _medicalNo)
                cmdToExecute.Parameters.AddWithValue("@registrationID", _registrationID)
                cmdToExecute.Parameters.AddWithValue("@locationCode", _locationCode)
                cmdToExecute.Parameters.AddWithValue("@remarks", _remarks)
                cmdToExecute.Parameters.AddWithValue("@userIDprocess", _userIDprocess)

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

        Public Function InsertByProcessType() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spEMRTrackingHistoryInsertByProcessType"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@MedicalNo", _medicalNo)
                cmdToExecute.Parameters.AddWithValue("@registrationID", _registrationID)
                cmdToExecute.Parameters.AddWithValue("@locationCode", _locationCode)
                cmdToExecute.Parameters.AddWithValue("@remarks", _remarks)
                cmdToExecute.Parameters.AddWithValue("@processType", _processType)
                cmdToExecute.Parameters.AddWithValue("@userIDprocess", _userIDprocess)

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

        Public Function SelectByMedicalNo(ByVal bolIsCurrentPosition As Boolean) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            If bolIsCurrentPosition = False Then
                cmdToExecute.CommandText = "spEMRTrackingHistoryByMRN"
            Else
                cmdToExecute.CommandText = "spEMRTrackingHistoryByMRNCurrentPosition"
            End If
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("spEMRTrackingHistoryByMRN")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@MedicalNo", _medicalNo)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 And bolIsCurrentPosition = True Then
                    _mutationDate = CType(toReturn.Rows(0)("mutationDate"), Date)
                    _MRN = CType(toReturn.Rows(0)("MRN"), Integer)
                    _medicalNo = CType(toReturn.Rows(0)("medicalNo"), String)
                    _patientName = CType(toReturn.Rows(0)("patientName"), String)
                    _registrationID = CType(toReturn.Rows(0)("registrationID"), Integer)
                    _registrationNo = CType(toReturn.Rows(0)("registrationNo"), String)
                    _remarks = CType(toReturn.Rows(0)("remarks"), String)
                    _processType = CType(toReturn.Rows(0)("processType"), String)
                    _userIDprocess = CType(toReturn.Rows(0)("userIDprocess"), String)
                    _userNameProcess = CType(toReturn.Rows(0)("userNameprocess"), String)
                    _locationCode = CType(toReturn.Rows(0)("locationCode"), String)
                    _locationName = CType(toReturn.Rows(0)("locationName"), String)
                    _locationGroupName = CType(toReturn.Rows(0)("locationGroupName"), String)
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

        Public Function SelectByLocation() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spEMRTrackingHistoryByLocation"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("spEMRTrackingHistoryByLocation")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@LocationCode", _locationCode)

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

        Public Function SelectSummaryByLocation(ByVal strLocationGroupCode As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spEMRSummayByLocation"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("spEMRSummayByLocation")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@LocationGroupCode", strLocationGroupCode)

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

        Public Function SelectSummaryByLocationGroup(ByVal strLocationGroupCode As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spEMRSummayByLocationGroup"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("spEMRSummayByLocationGroup")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@LocationGroupCode", strLocationGroupCode)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _locationGroupName = CType(toReturn.Rows(0)("locationGroupName"), String)
                    _MRNCount = CType(toReturn.Rows(0)("MRNCount"), Integer)
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

        Public Function SelectSummary() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spEMRTrackingHistorySummary"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("spEMRTrackingHistorySummary")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _TotalMRNCount = CType(toReturn.Rows(0)("TotalMRNCount"), Integer)
                    _TotalMRNoutCount = CType(toReturn.Rows(0)("TotalMRNoutCount"), Integer)
                    _LastMedicalNo = CType(toReturn.Rows(0)("LastMedicalNo"), String)
                    _LastPatientName = CType(toReturn.Rows(0)("LastPatientName"), String)
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

        Public Function SelectPatientData() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spEMRGetPatientData"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("spEMRGetPatientData")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@MedicalNo", _medicalNo)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _MRN = CType(toReturn.Rows(0)("MRN"), Integer)
                    _medicalNo = CType(toReturn.Rows(0)("medicalNo"), String)
                    _patientName = CType(toReturn.Rows(0)("patientName"), String)
                    _sex = CType(toReturn.Rows(0)("sex"), String)
                    _cfDateOfBirth = CType(toReturn.Rows(0)("cfDateOfBirth"), String)
                    _streetName = CType(toReturn.Rows(0)("streetName"), String)
                    _county = CType(toReturn.Rows(0)("county"), String)
                    _district = CType(toReturn.Rows(0)("district"), String)
                    _city = CType(toReturn.Rows(0)("city"), String)
                    _zipCodeID = CType(toReturn.Rows(0)("zipCodeID"), String)
                    _religion = CType(toReturn.Rows(0)("religion"), String)
                    _bloodType = CType(toReturn.Rows(0)("bloodType"), String)
                    _bloodRhesus = CType(toReturn.Rows(0)("BloodRhesus"), String)
                    _currentLocationName = CType(toReturn.Rows(0)("currentLocationName"), String)
                    _userNameProcess = CType(toReturn.Rows(0)("userNameProcess"), String)
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
#End Region

#Region " Class Property Declarations "
        Public Property [TrackingID]() As String
            Get
                Return _trackingID
            End Get
            Set(ByVal Value As String)
                _trackingID = Value
            End Set
        End Property

        Public Property [MutationDate]() As Date
            Get
                Return _mutationDate
            End Get
            Set(ByVal Value As Date)
                _mutationDate = Value
            End Set
        End Property

        Public Property [MRN]() As Integer
            Get
                Return _MRN
            End Get
            Set(ByVal Value As Integer)
                _MRN = Value
            End Set
        End Property

        Public Property [RegistrationID]() As Integer
            Get
                Return _registrationID
            End Get
            Set(ByVal Value As Integer)
                _registrationID = Value
            End Set
        End Property

        Public Property [LocationCode]() As String
            Get
                Return _locationCode
            End Get
            Set(ByVal Value As String)
                _locationCode = Value
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

        Public Property [ProcessType]() As String
            Get
                Return _processType
            End Get
            Set(ByVal Value As String)
                _processType = Value
            End Set
        End Property

        Public Property [UserIDProcess]() As String
            Get
                Return _userIDprocess
            End Get
            Set(ByVal Value As String)
                _userIDprocess = Value
            End Set
        End Property

        Public Property [ProcessDate]() As DateTime
            Get
                Return _processDate
            End Get
            Set(ByVal Value As DateTime)
                _processDate = Value
            End Set
        End Property

        Public Property [MedicalNo]() As String
            Get
                Return _medicalNo
            End Get
            Set(ByVal Value As String)
                _medicalNo = Value
            End Set
        End Property

        Public Property [PatientName]() As String
            Get
                Return _patientName
            End Get
            Set(ByVal Value As String)
                _patientName = Value
            End Set
        End Property

        Public Property [RegistrationNo]() As String
            Get
                Return _registrationNo
            End Get
            Set(ByVal Value As String)
                _registrationNo = Value
            End Set
        End Property

        Public Property [UserNameProcess]() As String
            Get
                Return _userNameProcess
            End Get
            Set(ByVal Value As String)
                _userNameProcess = Value
            End Set
        End Property

        Public Property [LocationName]() As String
            Get
                Return _locationName
            End Get
            Set(ByVal Value As String)
                _locationName = Value
            End Set
        End Property

        Public Property [LocationGroupName]() As String
            Get
                Return _locationGroupName
            End Get
            Set(ByVal Value As String)
                _locationGroupName = Value
            End Set
        End Property

        Public Property [Sex]() As String
            Get
                Return _sex
            End Get
            Set(ByVal Value As String)
                _sex = Value
            End Set
        End Property

        Public Property [cfDateOfBirth]() As String
            Get
                Return _cfDateOfBirth
            End Get
            Set(ByVal Value As String)
                _cfDateOfBirth = Value
            End Set
        End Property

        Public Property [streetName]() As String
            Get
                Return _streetName
            End Get
            Set(ByVal Value As String)
                _streetName = Value
            End Set
        End Property

        Public Property [county]() As String
            Get
                Return _county
            End Get
            Set(ByVal Value As String)
                _county = Value
            End Set
        End Property

        Public Property [district]() As String
            Get
                Return _district
            End Get
            Set(ByVal Value As String)
                _district = Value
            End Set
        End Property

        Public Property [city]() As String
            Get
                Return _city
            End Get
            Set(ByVal Value As String)
                _city = Value
            End Set
        End Property

        Public Property [zipCodeID]() As String
            Get
                Return _zipCodeID
            End Get
            Set(ByVal Value As String)
                _zipCodeID = Value
            End Set
        End Property

        Public Property [religion]() As String
            Get
                Return _religion
            End Get
            Set(ByVal Value As String)
                _religion = Value
            End Set
        End Property

        Public Property [bloodType]() As String
            Get
                Return _bloodType
            End Get
            Set(ByVal Value As String)
                _bloodType = Value
            End Set
        End Property

        Public Property [bloodRhesus]() As String
            Get
                Return _bloodRhesus
            End Get
            Set(ByVal Value As String)
                _bloodRhesus = Value
            End Set
        End Property

        Public Property [CurrentLocationName]() As String
            Get
                Return _currentLocationName
            End Get
            Set(ByVal Value As String)
                _currentLocationName = Value
            End Set
        End Property

        Public Property [MRNCount]() As Integer
            Get
                Return _MRNCount
            End Get
            Set(ByVal Value As Integer)
                _MRNCount = Value
            End Set
        End Property

        Public Property [TotalMRNCount]() As Integer
            Get
                Return _TotalMRNCount
            End Get
            Set(ByVal Value As Integer)
                _TotalMRNCount = Value
            End Set
        End Property

        Public Property [TotalMRNoutCount]() As Integer
            Get
                Return _TotalMRNoutCount
            End Get
            Set(ByVal Value As Integer)
                _TotalMRNoutCount = Value
            End Set
        End Property

        Public Property [LastMedicalNo]() As String
            Get
                Return _LastMedicalNo
            End Get
            Set(ByVal Value As String)
                _LastMedicalNo = Value
            End Set
        End Property

        Public Property [LastPatientName]() As String
            Get
                Return _LastPatientName
            End Get
            Set(ByVal Value As String)
                _LastPatientName = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
