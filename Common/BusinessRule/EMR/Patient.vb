Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class Patient
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _MRN As String
        Private _patientName, _gender, _placeOfBirth, _address As String
        Private _dateOfBirth As Date
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

#Region " Insert, Update "
        
#End Region

#Region " Select One "
        Public Overrides Function SelectOne(Optional ByVal recStatus As QISRecStatus = QISRecStatus.CurrentRecord) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetPatientData"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("Patient")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@MRN", _MRN)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _patientName = CType(toReturn.Rows(0)("patientName"), String)
                    _placeOfBirth = CType(toReturn.Rows(0)("placeOfBirth"), String)
                    _dateOfBirth = CType(toReturn.Rows(0)("dateOfBirth"), Date)
                    _gender = CType(toReturn.Rows(0)("gender"), String)
                    _address = CType(toReturn.Rows(0)("address"), String)                    
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

        Public Property [MRN]() As String
            Get
                Return _MRN
            End Get
            Set(ByVal Value As String)
                _MRN = Value
            End Set
        End Property

        Public Property [patientName]() As String
            Get
                Return _patientName
            End Get
            Set(ByVal Value As String)
                _patientName = Value
            End Set
        End Property

        Public Property [gender]() As String
            Get
                Return _gender
            End Get
            Set(ByVal Value As String)
                _gender = Value
            End Set
        End Property

        Public Property [placeOfBirth]() As String
            Get
                Return _placeOfBirth
            End Get
            Set(ByVal Value As String)
                _placeOfBirth = Value
            End Set
        End Property

        Public Property [address]() As String
            Get
                Return _address
            End Get
            Set(ByVal Value As String)
                _address = Value
            End Set
        End Property

        Public Property [dateOfBirth]() As Date
            Get
                Return _dateOfBirth
            End Get
            Set(ByVal Value As Date)
                _dateOfBirth = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
