Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class Worklist
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _OrderNo, _TransactionNo, _RegistrationNo, _MRN As String
        Private _ModuleID, _ServiceUnitID, _SupportingUnitID, _CreatedBy, _LastUpdatedBy As String
        Private _ClinicalNotes, _PrescriptionNotes As String
        Private _IsValidate, _IsAutoPayment, _IsClosed, _IsServiced, _IsCito As Boolean
        Private _ItemID, _StatusID, _StatusName As String
        Private _OrderDate, _PlannedDate, _RealizationDate, _CreateDate, _LastUpdatedDate As DateTime
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

#Region " Insert, Update "
        Public Function InsertTransactionOrderHD() As String
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spEMRTransactionOrderHd"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("spEMRTransactionOrderHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@RegistrationNo", _RegistrationNo)
                'cmdToExecute.Parameters.AddWithValue("@TransactionNo", _TransactionNo)
                cmdToExecute.Parameters.AddWithValue("@DepartmentID", _ModuleID)
                cmdToExecute.Parameters.AddWithValue("@ServiceUnitUnitID", _SupportingUnitID)
                cmdToExecute.Parameters.AddWithValue("@CreatedBy", _CreatedBy)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _TransactionNo = CType(toReturn.Rows(0)("TransactionNo"), String)
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

            Return _TransactionNo
        End Function

        Public Function InsertHD() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "spEMRePrescriptionTextOrderHd"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@NoJO", _OrderNo)
                cmdToExecute.Parameters.AddWithValue("@NoBukti", _TransactionNo)
                cmdToExecute.Parameters.AddWithValue("@NoReg", _RegistrationNo)
                cmdToExecute.Parameters.AddWithValue("@NoRM", _MRN)
                cmdToExecute.Parameters.AddWithValue("@App", _ModuleID)
                cmdToExecute.Parameters.AddWithValue("@KdUnit", _ServiceUnitID)
                cmdToExecute.Parameters.AddWithValue("@KdPMedis", _SupportingUnitID)
                cmdToExecute.Parameters.AddWithValue("@Validasi", _IsValidate)
                cmdToExecute.Parameters.AddWithValue("@CatatanKlinis", _ClinicalNotes)
                cmdToExecute.Parameters.AddWithValue("@IsCito", _IsCito)
                cmdToExecute.Parameters.AddWithValue("@UsrInsert", _CreatedBy)
                cmdToExecute.Parameters.AddWithValue("@UsrUpdate", _LastUpdatedBy)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                cmdToExecute.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function

        Public Function InsertDT() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "spEMRePrescriptionTextOrderDt"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@NoJO", _OrderNo)
                cmdToExecute.Parameters.AddWithValue("@KdLayan", _ItemID)
                cmdToExecute.Parameters.AddWithValue("@Resep", _PrescriptionNotes)
                cmdToExecute.Parameters.AddWithValue("@KdStatus", _StatusID)
                cmdToExecute.Parameters.AddWithValue("@Cito", _IsCito)
                cmdToExecute.Parameters.AddWithValue("@UsrInsert", _CreatedBy)
                cmdToExecute.Parameters.AddWithValue("@UsrUpdate", _LastUpdatedBy)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                cmdToExecute.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function

        Public Function InsertPatientResumeJobOrder(ByVal intPatientResumeID As Integer) As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "spEMRInsertPatientResumeJobOrder"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@PatientResumeID", intPatientResumeID)
                cmdToExecute.Parameters.AddWithValue("@JobOrderNo", _OrderNo)
                cmdToExecute.Parameters.AddWithValue("@CreatedBy", _CreatedBy)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                cmdToExecute.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function

        Public Function UpdateCancelDT() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "spEMRePrescriptionTextOrderDtUpdateCancel"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@NoJO", _OrderNo)
                cmdToExecute.Parameters.AddWithValue("@KdLayan", _ItemID)
                cmdToExecute.Parameters.AddWithValue("@UsrUpdate", _LastUpdatedBy)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                cmdToExecute.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function
#End Region

#Region " Select One "
        Public Function SelectOrderHd() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetJobOrderHd"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetJobOrderHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@OrderNo", _OrderNo)
                '//soon... PatientResumeID

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _OrderNo = CType(toReturn.Rows(0)("JobOrderNo"), String)
                    _TransactionNo = CType(toReturn.Rows(0)("TransactionNo"), String)
                    _SupportingUnitID = CType(toReturn.Rows(0)("DiagnosticSupportUnitID"), String)
                    _ClinicalNotes = CType(toReturn.Rows(0)("ClinicalNotes"), String)
                    _IsCito = CType(toReturn.Rows(0)("IsCito"), Boolean)
                    _StatusName = CType(toReturn.Rows(0)("StatusName"), String)
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

        Public Function getOrderValid() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "getNoBuktiRI"

            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("hdtansaksi")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add(New SqlParameter("@nobukti", _TransactionNo))
                cmdToExecute.Parameters.Add(New SqlParameter("@noreg", _RegistrationNo))

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _TransactionNo = (CType(toReturn.Rows(0)("nobukti"), String))
                End If
                Return toReturn
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function
#End Region

#Region " Custom "
        Public Function GetJobOrderListByRegistrationNo() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetJobOrderListByRegistrationNo"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetJobOrderListByRegistrationNo")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@RegistrationNo", _RegistrationNo)
                '//soon... PatientResumeID

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

        Public Function GetJobOrderListByPatientResumeID(ByVal intPatientResumeID As Integer) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetJobOrderListByPatientResumeID"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetJobOrderListByPatientResumeID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@PatientResumeID", intPatientResumeID)
                '//soon... PatientResumeID

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

        Public Function GetJobOrderDetailByPatientResumeID(ByVal intPatientResumeID As Integer) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetJobOrderDetailByPatientResumeID"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetJobOrderDetailByPatientResumeID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@PatientResumeID", intPatientResumeID)
                '//soon... PatientResumeID

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

        Public Function GetJobOrderDetailByPatientResumeIDByUnitID(ByVal intPatientResumeID As Integer, ByVal strUnitID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetJobOrderDetailByPatientResumeIDByUnitID"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetJobOrderDetailByPatientResumeIDByUnitID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@PatientResumeID", intPatientResumeID)
                cmdToExecute.Parameters.AddWithValue("@DiagnosticSupportUnitiD", strUnitID)

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

        Public ReadOnly Property [NewOrderNo]() As String
            Get
                Dim cmdToExecute As SqlCommand = New SqlCommand
                Dim sRetVal As String

                cmdToExecute.CommandText = "spEMRePrescriptionTextOrderHdMaxOrderNo"
                cmdToExecute.CommandType = CommandType.StoredProcedure

                Dim toReturn As DataTable = New DataTable(cmdToExecute.CommandText)
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)
                cmdToExecute.Connection = _mainConnection

                Try
                    ' // Open connection.
                    _mainConnection.Open()

                    ' // Execute query.
                    adapter.Fill(toReturn)

                    If toReturn.Rows.Count > 0 Then
                        Dim iNoJO As String
                        Dim currentDate As DateTime
                        Dim delimiter As String = Common.Methods.GetCommonCode(Common.Constants.Delimiter.Delimiter_HISJO, Common.Constants.GroupCode.Delimiter_SCode).Trim

                        iNoJO = ProcessNull.GetString(toReturn.Rows(0)("NoJOMax"))
                        currentDate = Convert.ToDateTime(toReturn.Rows(0)("CurrentDate"))

                        If Len(Trim(iNoJO)) > 0 Then
                            If Format(currentDate, "yyyyMMdd") = Left(iNoJO, 8) Then
                                sRetVal = Format(currentDate, "yyyyMMdd") + delimiter.Trim + Format(CInt(Right(iNoJO, 4)) + 1, "0###")
                            Else
                                sRetVal = Format(currentDate, "yyyyMMdd") + delimiter.Trim + Format(1, "0###")
                            End If
                        Else
                            sRetVal = Format(currentDate, "yyyyMMdd") + delimiter.Trim + Format(1, "0###")
                        End If

                        Return sRetVal
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
            End Get
        End Property

        Public Property [OrderNo]() As String
            Get
                Return _OrderNo
            End Get
            Set(ByVal Value As String)
                _OrderNo = Value
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

        Public Property [RegistrationNo]() As String
            Get
                Return _RegistrationNo
            End Get
            Set(ByVal Value As String)
                _RegistrationNo = Value
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

        Public Property [ModuleID]() As String
            Get
                Return _ModuleID
            End Get
            Set(ByVal Value As String)
                _ModuleID = Value
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

        Public Property [SupportingUnitID]() As String
            Get
                Return _SupportingUnitID
            End Get
            Set(ByVal Value As String)
                _SupportingUnitID = Value
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

        Public Property [ClinicalNotes]() As String
            Get
                Return _ClinicalNotes
            End Get
            Set(ByVal Value As String)
                _ClinicalNotes = Value
            End Set
        End Property

        Public Property [PrescriptionNotes]() As String
            Get
                Return _PrescriptionNotes
            End Get
            Set(ByVal Value As String)
                _PrescriptionNotes = Value
            End Set
        End Property

        Public Property [ItemID]() As String
            Get
                Return _ItemID
            End Get
            Set(ByVal Value As String)
                _ItemID = Value
            End Set
        End Property

        Public Property [StatusID]() As String
            Get
                Return _StatusID
            End Get
            Set(ByVal Value As String)
                _StatusID = Value
            End Set
        End Property

        Public Property [StatusName]() As String
            Get
                Return _StatusName
            End Get
            Set(ByVal Value As String)
                _StatusName = Value
            End Set
        End Property

        Public Property [IsValidate]() As Boolean
            Get
                Return _IsValidate
            End Get
            Set(ByVal Value As Boolean)
                _IsValidate = Value
            End Set
        End Property

        Public Property [IsAutoPayment]() As Boolean
            Get
                Return _IsAutoPayment
            End Get
            Set(ByVal Value As Boolean)
                _IsAutoPayment = Value
            End Set
        End Property

        Public Property [IsClosed]() As Boolean
            Get
                Return _IsClosed
            End Get
            Set(ByVal Value As Boolean)
                _IsClosed = Value
            End Set
        End Property

        Public Property [IsServiced]() As Boolean
            Get
                Return _IsServiced
            End Get
            Set(ByVal Value As Boolean)
                _IsServiced = Value
            End Set
        End Property

        Public Property [IsCito]() As Boolean
            Get
                Return _IsCito
            End Get
            Set(ByVal Value As Boolean)
                _IsCito = Value
            End Set
        End Property

        Public Property [OrderDate]() As Date
            Get
                Return _OrderDate
            End Get
            Set(ByVal Value As Date)
                _OrderDate = Value
            End Set
        End Property

        Public Property [PlannedDate]() As Date
            Get
                Return _PlannedDate
            End Get
            Set(ByVal Value As Date)
                _PlannedDate = Value
            End Set
        End Property

        Public Property [RealizationDate]() As Date
            Get
                Return _RealizationDate
            End Get
            Set(ByVal Value As Date)
                _RealizationDate = Value
            End Set
        End Property

        Public Property [CreateDate]() As Date
            Get
                Return _CreateDate
            End Get
            Set(ByVal Value As Date)
                _CreateDate = Value
            End Set
        End Property

        Public Property [LastUpdatedDate]() As Date
            Get
                Return _LastUpdatedDate
            End Get
            Set(ByVal Value As Date)
                _LastUpdatedDate = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
