Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class AccountingBalance
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _GLAccountID As Integer
        Private _BalanceYear, _BalanceMonth, _PeriodNo As String
        Private _BalanceBEGIN As Decimal
        Private _IsApproved As Boolean
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

#Region " C,R,U,D "
        Public Function UpsertGLBalanceBEGIN() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "UpsertGLBalanceBEGIN"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@PeriodNo", _PeriodNo)
                cmdToExecute.Parameters.AddWithValue("@GLAccountID", _GLAccountID)
                cmdToExecute.Parameters.AddWithValue("@BalanceBEGIN", _BalanceBEGIN)
                cmdToExecute.Parameters.AddWithValue("@IsApproved", _IsApproved)

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

        Public Function ApproveGLBalanceBEGIN() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "ApproveGLBalanceBEGIN"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@PeriodNo", _PeriodNo)
                cmdToExecute.Parameters.AddWithValue("@IsApproved", _IsApproved)

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

        Public Function GetGLBalanceBEGIN() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetGLBalanceBEGIN"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetGLBalanceBEGIN")
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

        Public Function GetActiveAccount() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetActiveAccount"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetActiveAccount")
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
#End Region

#Region " Class Property Declarations "
        Public Property [PeriodNo]() As String
            Get
                Return _PeriodNo
            End Get
            Set(ByVal Value As String)
                _PeriodNo = Value
            End Set
        End Property

        Public Property [GLAccountID]() As Integer
            Get
                Return _GLAccountID
            End Get
            Set(ByVal Value As Integer)
                _GLAccountID = Value
            End Set
        End Property

        Public Property [BalanceBEGIN]() As Decimal
            Get
                Return _BalanceBEGIN
            End Get
            Set(ByVal Value As Decimal)
                _BalanceBEGIN = Value
            End Set
        End Property

        Public Property [IsApproved]() As Boolean
            Get
                Return _IsApproved
            End Get
            Set(ByVal Value As Boolean)
                _IsApproved = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
