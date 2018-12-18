Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class EMR
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _DepartmentID, _PhysicianID, _PhysicianName, _RegistrationNo, _TransactionNo As String
        Private _ServiceUnitID, _ServiceUnitName, _MRN, _PatientName, _PatientGender, _PatientPhone, _PatientMobile As String
        Private _RegistrationTime, _BusinessPartnerName As String
        Private _RegistrationDate, _PatientDOB As Date

        Private _ID, _RevisedSourceID As Integer
        Private _ChiefComplaint, _HistoryOfPresentIllness As String
        Private _MainDiagnosisText, _SecondaryDiagnosisText, _ProcedureText, _TherapyText, _TherapyStopDate, _Notes As String
        Private _TherapyHISOrderNo As String
        Private _IsRevised, _IsDischarged As Boolean
        Private _CreatedBy, _LastUpdatedBy As String
        Private _CreatedDate, _LastUpdatedDate As DateTime

        Private _ComplainText, _InterventionText, _EvaluationText, _ParamedicID As String
        Private _AssessmentTypeSCode, _SOAPNotes, _ObjectiveText, _MeasurableTargetText As String

        '// for NurseNotes (Catatan Perawat)
        Private _NurseNotesID As Integer
        Private _NurseNotes As String
        Private _IsPhysicianConfirmed As Boolean

#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

#Region " Patient Resume "
#Region " Insert, Update "
        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spEMRPatientResumeInsert"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@DepartmentID", _DepartmentID)
                cmdToExecute.Parameters.AddWithValue("@ServiceUnitID", _ServiceUnitID)
                cmdToExecute.Parameters.AddWithValue("@MRN", _MRN)
                cmdToExecute.Parameters.AddWithValue("@RegistrationNo", _RegistrationNo)
                cmdToExecute.Parameters.AddWithValue("@PhysicianID", _PhysicianID)
                cmdToExecute.Parameters.AddWithValue("@AssessmentTypeSCode", _AssessmentTypeSCode)
                cmdToExecute.Parameters.AddWithValue("@ChiefComplaint", _ChiefComplaint)
                cmdToExecute.Parameters.AddWithValue("@HistoryOfPresentIllness", _HistoryOfPresentIllness)
                cmdToExecute.Parameters.AddWithValue("@MainDiagnosisText", _MainDiagnosisText)
                cmdToExecute.Parameters.AddWithValue("@SecondaryDiagnosisText", _SecondaryDiagnosisText)
                cmdToExecute.Parameters.AddWithValue("@ProcedureText", _ProcedureText)
                cmdToExecute.Parameters.AddWithValue("@TherapyText", _TherapyText)
                cmdToExecute.Parameters.AddWithValue("@TherapyStopDate", _TherapyStopDate)
                cmdToExecute.Parameters.AddWithValue("@Notes", _Notes)
                cmdToExecute.Parameters.AddWithValue("@CreatedBy", _CreatedBy)
                cmdToExecute.Parameters.AddWithValue("@LastUpdatedBy", _LastUpdatedBy)
                cmdToExecute.Parameters.AddWithValue("@IsDischarged", _IsDischarged)
                cmdToExecute.Parameters.AddWithValue("@TherapyHISOrderNo", _TherapyHISOrderNo)
                cmdToExecute.Parameters.AddWithValue("@SOAPNotes", _SOAPNotes)
                cmdToExecute.Parameters.AddWithValue("@ObjectiveText", _ObjectiveText)
                cmdToExecute.Parameters.AddWithValue("@MeasurableTargetText", _MeasurableTargetText)

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
            cmdToExecute.CommandText = "spEMRPatientResumeUpdate"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ID", _ID)
                cmdToExecute.Parameters.AddWithValue("@DepartmentID", _DepartmentID)
                cmdToExecute.Parameters.AddWithValue("@ServiceUnitID", _ServiceUnitID)
                cmdToExecute.Parameters.AddWithValue("@MRN", _MRN)
                cmdToExecute.Parameters.AddWithValue("@RegistrationNo", _RegistrationNo)
                cmdToExecute.Parameters.AddWithValue("@PhysicianID", _PhysicianID)
                cmdToExecute.Parameters.AddWithValue("@AssessmentTypeSCode", _AssessmentTypeSCode)
                cmdToExecute.Parameters.AddWithValue("@ChiefComplaint", _ChiefComplaint)
                cmdToExecute.Parameters.AddWithValue("@HistoryOfPresentIllness", _HistoryOfPresentIllness)
                cmdToExecute.Parameters.AddWithValue("@MainDiagnosisText", _MainDiagnosisText)
                cmdToExecute.Parameters.AddWithValue("@SecondaryDiagnosisText", _SecondaryDiagnosisText)
                cmdToExecute.Parameters.AddWithValue("@ProcedureText", _ProcedureText)
                cmdToExecute.Parameters.AddWithValue("@TherapyText", _TherapyText)
                cmdToExecute.Parameters.AddWithValue("@TherapyStopDate", _TherapyStopDate)
                cmdToExecute.Parameters.AddWithValue("@Notes", _Notes)
                cmdToExecute.Parameters.AddWithValue("@CreatedBy", _CreatedBy)
                cmdToExecute.Parameters.AddWithValue("@LastUpdatedBy", _LastUpdatedBy)
                cmdToExecute.Parameters.AddWithValue("@IsDischarged", _IsDischarged)
                cmdToExecute.Parameters.AddWithValue("@TherapyHISOrderNo", _TherapyHISOrderNo)
                cmdToExecute.Parameters.AddWithValue("@SOAPNotes", _SOAPNotes)
                cmdToExecute.Parameters.AddWithValue("@ObjectiveText", _ObjectiveText)
                cmdToExecute.Parameters.AddWithValue("@MeasurableTargetText", _MeasurableTargetText)

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

        Public Function UpdateSOAPNotes() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "UPDATE EMRPatientResume SET " + _
                                        "SOAPNotes=@SOAPNotes, LastUpdatedBy=@LastUpdatedBy, LastUpdatedDate=GETDATE() " + _
                                        "WHERE ID=@ID"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ID", _ID)
                cmdToExecute.Parameters.AddWithValue("@SOAPNotes", _SOAPNotes)
                cmdToExecute.Parameters.AddWithValue("@LastUpdatedBy", _LastUpdatedBy)

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

        Public Function UpdateDischarge() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spEMRPatientDischargeUpdate"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@DepartmentID", _DepartmentID)
                cmdToExecute.Parameters.AddWithValue("@ServiceUnitID", _ServiceUnitID)
                cmdToExecute.Parameters.AddWithValue("@RegistrationNo", _RegistrationNo)
                cmdToExecute.Parameters.AddWithValue("@IsDischarged", _IsDischarged)

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

#Region " Select "
        Public Function GetRegistration() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spEMRGetRegistration"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("spEMRGetRegistration")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@DepartmentID", _DepartmentID)
                cmdToExecute.Parameters.AddWithValue("@RegistrationNo", _RegistrationNo)
                cmdToExecute.Parameters.AddWithValue("@TransactionNo", _TransactionNo)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _DepartmentID = CType(toReturn.Rows(0)("DepartmentID"), String)
                    _RegistrationNo = CType(toReturn.Rows(0)("RegistrationNo"), String)
                    _TransactionNo = CType(toReturn.Rows(0)("TransactionNo"), String)
                    _RegistrationDate = CType(toReturn.Rows(0)("RegistrationDate"), Date)
                    _RegistrationTime = CType(toReturn.Rows(0)("RegistrationTime"), String)
                    _PhysicianID = CType(toReturn.Rows(0)("PhysicianID"), String)
                    _PhysicianName = CType(toReturn.Rows(0)("PhysicianName"), String)
                    _ServiceUnitID = CType(toReturn.Rows(0)("ServiceUnitID"), String)
                    _ServiceUnitName = CType(toReturn.Rows(0)("ServiceUnitName"), String)
                    _MRN = CType(toReturn.Rows(0)("MRN"), String)
                    _PatientName = CType(toReturn.Rows(0)("PatientName"), String)
                    _PatientDOB = CType(toReturn.Rows(0)("PatientDOB"), Date)
                    _PatientGender = CType(toReturn.Rows(0)("PatientGender"), String)
                    _PatientPhone = CType(toReturn.Rows(0)("PatientPhone"), String)
                    _PatientMobile = CType(toReturn.Rows(0)("PatientMobile"), String)
                    _BusinessPartnerName = CType(toReturn.Rows(0)("BusinessPartnerName"), String)
                    _IsDischarged = CType(toReturn.Rows(0)("IsDischarged"), Boolean)
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

        Public Function GetPatientPhysicianIDToday(ByVal strSearch As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            If strSearch.Trim = String.Empty Then
                cmdToExecute.CommandText = "spEMRGetPatientByPhysicianToday"
            Else
                cmdToExecute.CommandText = "spEMRGetPatientByPhysicianTodaySearch"
            End If
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("spEMRGetPatientByPhysicianToday")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@DepartmentID", _DepartmentID)
                cmdToExecute.Parameters.AddWithValue("@PhysicianID", _PhysicianID)
                If strSearch.Trim <> String.Empty Then
                    cmdToExecute.Parameters.AddWithValue("@SearchText", strSearch)
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

        Public Function GetPatientToday(ByVal strSearch As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            If strSearch.Trim = String.Empty Then
                cmdToExecute.CommandText = "spEMRGetPatientToday"
            Else
                cmdToExecute.CommandText = "spEMRGetPatientTodaySearch"
            End If
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("spEMRGetPatientToday")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@DepartmentID", _DepartmentID)
                If strSearch.Trim <> String.Empty Then
                    cmdToExecute.Parameters.AddWithValue("@SearchText", strSearch)
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

        Public Function GetPatientTodayByUnit(ByVal strSearch As String, ByVal strUnitID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            If strSearch.Trim = String.Empty Then
                cmdToExecute.CommandText = "spEMRGetPatientTodayByUnit"
            Else
                cmdToExecute.CommandText = "spEMRGetPatientTodayByUnitSearch"
            End If
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("spEMRGetPatientTodayByUnit")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@DepartmentID", _DepartmentID)
                cmdToExecute.Parameters.AddWithValue("@UnitID", strUnitID)
                If strSearch.Trim <> String.Empty Then
                    cmdToExecute.Parameters.AddWithValue("@SearchText", strSearch)
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

        Public Function GetPatientResumeByRegistrationNo() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spEMRGetPatientResumeByRegistrationNo"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("spEMRGetPatientResumeByRegistrationNo")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@RegistrationNo", _RegistrationNo)

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

        Public Function GetPatientResumeByMRN() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spEMRGetPatientResumeByMRN"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("spEMRGetPatientResumeByMRN")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@MRN", _MRN)

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

        Public Function GetPatientResumeFirstAssessmentByRegistrationNo() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spEMRGetPatientResumeFirstAssessmentByRegistrationNo"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("spEMRGetPatientResumeFirstAssessmentByRegistrationNo")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@MRN", _MRN)
                cmdToExecute.Parameters.AddWithValue("@RegistrationNo", _RegistrationNo)

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

        Public Function GetPatientResumeByID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spEMRGetPatientResumeByID"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("spEMRGetPatientResumeByID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ID", _ID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _AssessmentTypeSCode = CType(toReturn.Rows(0)("AssessmentTypeSCode"), String)
                    _ChiefComplaint = CType(toReturn.Rows(0)("ChiefComplaint"), String)
                    _HistoryOfPresentIllness = CType(toReturn.Rows(0)("HistoryOfPresentIllness"), String)
                    _MainDiagnosisText = CType(toReturn.Rows(0)("MainDiagnosisText"), String)
                    _SecondaryDiagnosisText = CType(toReturn.Rows(0)("SecondaryDiagnosisText"), String)
                    _ProcedureText = CType(toReturn.Rows(0)("ProcedureText"), String)
                    _TherapyText = CType(toReturn.Rows(0)("TherapyText"), String)
                    _TherapyStopDate = CType(toReturn.Rows(0)("TherapyStopDate"), String)
                    _Notes = CType(toReturn.Rows(0)("Notes"), String)
                    _SOAPNotes = CType(toReturn.Rows(0)("SOAPNotes"), String)
                    _ObjectiveText = CType(toReturn.Rows(0)("ObjectiveText"), String)
                    _MeasurableTargetText = CType(toReturn.Rows(0)("MeasurableTargetText"), String)
                    _ID = CType(toReturn.Rows(0)("ID"), Integer)
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

        Public Function GetPatientPhysicianIDChartOutpatient() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spEMRGetPatientByPhysicianChartOutpatient"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("spEMRGetPatientByPhysicianChartOutpatient")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@PhysicianID", _PhysicianID)

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

        Public Function GetPatientPhysicianIDBusinessPartnerChartOutpatient() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spEMRGetPatientByPhysicianBusinessPartnerChartOutpatient"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("spEMRGetPatientByPhysicianBusinessPartnerChartOutpatient")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@PhysicianID", _PhysicianID)

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
#End Region

#Region " Nurse Notes "
#Region " Insert, Update"
        Public Function InsertNurseNotes() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spEMRNurseNotesInsert"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@DepartmentID", _DepartmentID)
                cmdToExecute.Parameters.AddWithValue("@ServiceUnitID", _ServiceUnitID)
                cmdToExecute.Parameters.AddWithValue("@MRN", _MRN)
                cmdToExecute.Parameters.AddWithValue("@RegistrationNo", _RegistrationNo)
                cmdToExecute.Parameters.AddWithValue("@NurseNotes", _NurseNotes)
                cmdToExecute.Parameters.AddWithValue("@CreatedBy", _CreatedBy)
                cmdToExecute.Parameters.AddWithValue("@LastUpdatedBy", _LastUpdatedBy)                

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

        Public Function UpdateNurseNotes() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spEMRNurseNotesUpdate"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ID", _NurseNotesID)
                cmdToExecute.Parameters.AddWithValue("@DepartmentID", _DepartmentID)
                cmdToExecute.Parameters.AddWithValue("@ServiceUnitID", _ServiceUnitID)
                cmdToExecute.Parameters.AddWithValue("@MRN", _MRN)
                cmdToExecute.Parameters.AddWithValue("@RegistrationNo", _RegistrationNo)
                cmdToExecute.Parameters.AddWithValue("@NurseNotes", _NurseNotes)
                cmdToExecute.Parameters.AddWithValue("@CreatedBy", _CreatedBy)
                cmdToExecute.Parameters.AddWithValue("@LastUpdatedBy", _LastUpdatedBy)

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

        Public Function UpdateNurseNotesPhysicianConfirmed() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spEMRNurseNotesUpdatePhysicianConfirmed"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ID", _NurseNotesID)
                cmdToExecute.Parameters.AddWithValue("@IsPhysicianConfirmed", _IsPhysicianConfirmed)
                cmdToExecute.Parameters.AddWithValue("@LastUpdatedBy", _LastUpdatedBy)

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

#Region " Select "
        Public Function GetNurseNotesByRegistrationNo() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spEMRGetNurseNotesByRegistrationNo"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("spEMRGetNurseNotesByRegistrationNo")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@RegistrationNo", _RegistrationNo)

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

        Public Function GetNurseNotesByID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spEMRGetNurseNotesByID"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("spEMRGetNurseNotesByID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ID", _NurseNotesID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _NurseNotes = CType(toReturn.Rows(0)("NurseNotes"), String)
                    _IsPhysicianConfirmed = CType(toReturn.Rows(0)("IsPhysicianConfirmed"), Boolean)
                    _ID = CType(toReturn.Rows(0)("ID"), Integer)
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
#End Region

#Region " Patient Intervention "
#Region " Insert, Update "
        Public Function InsertEMRPatientIntervention() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spEMRPatientInterventionInsert"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@DepartmentID", _DepartmentID)
                cmdToExecute.Parameters.AddWithValue("@ServiceUnitID", _ServiceUnitID)
                cmdToExecute.Parameters.AddWithValue("@MRN", _MRN)
                cmdToExecute.Parameters.AddWithValue("@RegistrationNo", _RegistrationNo)
                cmdToExecute.Parameters.AddWithValue("@PhysicianID", _PhysicianID)
                cmdToExecute.Parameters.AddWithValue("@ParamedicID", _ParamedicID)
                cmdToExecute.Parameters.AddWithValue("@ComplainText", _ComplainText)
                cmdToExecute.Parameters.AddWithValue("@InterventionText", _InterventionText)
                cmdToExecute.Parameters.AddWithValue("@EvaluationText", _EvaluationText)
                cmdToExecute.Parameters.AddWithValue("@CreatedBy", _CreatedBy)
                cmdToExecute.Parameters.AddWithValue("@LastUpdatedBy", _LastUpdatedBy)

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

        Public Function UpdateEMRPatientIntervention() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spEMRPatientInterventionUpdate"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ID", _ID)
                cmdToExecute.Parameters.AddWithValue("@DepartmentID", _DepartmentID)
                cmdToExecute.Parameters.AddWithValue("@ServiceUnitID", _ServiceUnitID)
                cmdToExecute.Parameters.AddWithValue("@MRN", _MRN)
                cmdToExecute.Parameters.AddWithValue("@RegistrationNo", _RegistrationNo)
                cmdToExecute.Parameters.AddWithValue("@PhysicianID", _PhysicianID)
                cmdToExecute.Parameters.AddWithValue("@ParamedicID", _ParamedicID)
                cmdToExecute.Parameters.AddWithValue("@ComplainText", _ComplainText)
                cmdToExecute.Parameters.AddWithValue("@InterventionText", _InterventionText)
                cmdToExecute.Parameters.AddWithValue("@EvaluationText", _EvaluationText)
                cmdToExecute.Parameters.AddWithValue("@CreatedBy", _CreatedBy)
                cmdToExecute.Parameters.AddWithValue("@LastUpdatedBy", _LastUpdatedBy)

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

#Region " Select "
        Public Function GetPatientInterventionByMRN() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spEMRGetPatientInterventionByMRN"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("spEMRGetPatientInterventionByMRN")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@MRN", _MRN)

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

        Public Function GetPatientInterventionByID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spEMRGetPatientInterventionByID"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("spEMRGetPatientInterventionByID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ID", _ID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _ComplainText = CType(toReturn.Rows(0)("ComplainText"), String)
                    _InterventionText = CType(toReturn.Rows(0)("InterventionText"), String)
                    _EvaluationText = CType(toReturn.Rows(0)("EvaluationText"), String)
                    _ID = CType(toReturn.Rows(0)("ID"), Integer)
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
#End Region

#Region " Class Property Declarations "

        Public Property [ID]() As Integer
            Get
                Return _ID
            End Get
            Set(ByVal Value As Integer)
                _ID = Value
            End Set
        End Property

        Public Property [DepartmentID]() As String
            Get
                Return _DepartmentID
            End Get
            Set(ByVal Value As String)
                _DepartmentID = Value
            End Set
        End Property

        Public Property [PhysicianID]() As String
            Get
                Return _PhysicianID
            End Get
            Set(ByVal Value As String)
                _PhysicianID = Value
            End Set
        End Property

        Public Property [PhysicianName]() As String
            Get
                Return _PhysicianName
            End Get
            Set(ByVal Value As String)
                _PhysicianName = Value
            End Set
        End Property

        Public Property [RegistrationNo]() As String
            Get
                Return _RegistrationNo
            End Get
            Set(ByVal Value As String)
                _RegistrationNo = Value
            End Set
        End Property

        Public Property [TransactionNo]() As String
            Get
                Return _TransactionNo
            End Get
            Set(ByVal Value As String)
                _TransactionNo = Value
            End Set
        End Property

        Public Property [RegistrationDate]() As Date
            Get
                Return _RegistrationDate
            End Get
            Set(ByVal Value As Date)
                _RegistrationDate = Value
            End Set
        End Property

        Public Property [RegistrationTime]() As String
            Get
                Return _RegistrationTime
            End Get
            Set(ByVal Value As String)
                _RegistrationTime = Value
            End Set
        End Property

        Public Property [MRN]() As String
            Get
                Return _MRN
            End Get
            Set(ByVal Value As String)
                _MRN = Value
            End Set
        End Property

        Public Property [PatientName]() As String
            Get
                Return _PatientName
            End Get
            Set(ByVal Value As String)
                _PatientName = Value
            End Set
        End Property

        Public Property [PatientGender]() As String
            Get
                Return _PatientGender
            End Get
            Set(ByVal Value As String)
                _PatientGender = Value
            End Set
        End Property

        Public Property [PatientDOB]() As Date
            Get
                Return _PatientDOB
            End Get
            Set(ByVal Value As Date)
                _PatientDOB = Value
            End Set
        End Property

        Public Property [PatientPhone]() As String
            Get
                Return _PatientPhone
            End Get
            Set(ByVal Value As String)
                _PatientPhone = Value
            End Set
        End Property

        Public Property [PatientMobile]() As String
            Get
                Return _PatientMobile
            End Get
            Set(ByVal Value As String)
                _PatientMobile = Value
            End Set
        End Property

        Public Property [ServiceUnitID]() As String
            Get
                Return _ServiceUnitID
            End Get
            Set(ByVal Value As String)
                _ServiceUnitID = Value
            End Set
        End Property

        Public Property [ServiceUnitName]() As String
            Get
                Return _ServiceUnitName
            End Get
            Set(ByVal Value As String)
                _ServiceUnitName = Value
            End Set
        End Property

        Public Property [BusinessPartnerName]() As String
            Get
                Return _BusinessPartnerName
            End Get
            Set(ByVal Value As String)
                _BusinessPartnerName = Value
            End Set
        End Property

        Public Property [AssessmentTypeSCode]() As String
            Get
                Return _AssessmentTypeSCode
            End Get
            Set(ByVal Value As String)
                _AssessmentTypeSCode = Value
            End Set
        End Property

        Public Property [ChiefComplaint]() As String
            Get
                Return _ChiefComplaint
            End Get
            Set(ByVal Value As String)
                _ChiefComplaint = Value
            End Set
        End Property

        Public Property [HistoryOfPresentIllness]() As String
            Get
                Return _HistoryOfPresentIllness
            End Get
            Set(ByVal Value As String)
                _HistoryOfPresentIllness = Value
            End Set
        End Property

        Public Property [MainDiagnosisText]() As String
            Get
                Return _MainDiagnosisText
            End Get
            Set(ByVal Value As String)
                _MainDiagnosisText = Value
            End Set
        End Property

        Public Property [SecondaryDiagnosisText]() As String
            Get
                Return _SecondaryDiagnosisText
            End Get
            Set(ByVal Value As String)
                _SecondaryDiagnosisText = Value
            End Set
        End Property

        Public Property [ProcedureText]() As String
            Get
                Return _ProcedureText
            End Get
            Set(ByVal Value As String)
                _ProcedureText = Value
            End Set
        End Property

        Public Property [TherapyText]() As String
            Get
                Return _TherapyText
            End Get
            Set(ByVal Value As String)
                _TherapyText = Value
            End Set
        End Property

        Public Property [TherapyStopDate]() As String
            Get
                Return _TherapyStopDate
            End Get
            Set(ByVal Value As String)
                _TherapyStopDate = Value
            End Set
        End Property

        Public Property [Notes]() As String
            Get
                Return _Notes
            End Get
            Set(ByVal Value As String)
                _Notes = Value
            End Set
        End Property

        Public Property [SOAPNotes]() As String
            Get
                Return _SOAPNotes
            End Get
            Set(ByVal Value As String)
                _SOAPNotes = Value
            End Set
        End Property

        Public Property [ObjectiveText]() As String
            Get
                Return _ObjectiveText
            End Get
            Set(ByVal Value As String)
                _ObjectiveText = Value
            End Set
        End Property

        Public Property [MeasurableTargetText]() As String
            Get
                Return _MeasurableTargetText
            End Get
            Set(ByVal Value As String)
                _MeasurableTargetText = Value
            End Set
        End Property

        Public Property [IsRevised]() As Boolean
            Get
                Return _IsRevised
            End Get
            Set(ByVal Value As Boolean)
                _IsRevised = Value
            End Set
        End Property

        Public Property [IsDischarged]() As Boolean
            Get
                Return _IsDischarged
            End Get
            Set(ByVal Value As Boolean)
                _IsDischarged = Value
            End Set
        End Property

        Public Property [CreatedBy]() As String
            Get
                Return _CreatedBy
            End Get
            Set(ByVal Value As String)
                _CreatedBy = Value
            End Set
        End Property

        Public Property [LastUpdatedBy]() As String
            Get
                Return _LastUpdatedBy
            End Get
            Set(ByVal Value As String)
                _LastUpdatedBy = Value
            End Set
        End Property

        Public Property [TherapyHISOrderNo]() As String
            Get
                Return _TherapyHISOrderNo
            End Get
            Set(ByVal Value As String)
                _TherapyHISOrderNo = Value
            End Set
        End Property

        Public Property [ComplainText]() As String
            Get
                Return _ComplainText
            End Get
            Set(ByVal Value As String)
                _ComplainText = Value
            End Set
        End Property

        Public Property [InterventionText]() As String
            Get
                Return _InterventionText
            End Get
            Set(ByVal Value As String)
                _InterventionText = Value
            End Set
        End Property

        Public Property [EvaluationText]() As String
            Get
                Return _EvaluationText
            End Get
            Set(ByVal Value As String)
                _EvaluationText = Value
            End Set
        End Property

        Public Property [ParamedicID]() As String
            Get
                Return _ParamedicID
            End Get
            Set(ByVal Value As String)
                _ParamedicID = Value
            End Set
        End Property

        Public Property [NurseNotesID]() As Integer
            Get
                Return _NurseNotesID
            End Get
            Set(ByVal Value As Integer)
                _NurseNotesID = Value
            End Set
        End Property

        Public Property [NurseNotes]() As String
            Get
                Return _NurseNotes
            End Get
            Set(ByVal Value As String)
                _NurseNotes = Value
            End Set
        End Property

        Public Property [IsPhysicianConfirmed]() As Boolean
            Get
                Return _IsPhysicianConfirmed
            End Get
            Set(ByVal Value As Boolean)
                _IsPhysicianConfirmed = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
