Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class Budget
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _GLAccountID, _LocationID, _ItemGroupID As Integer
        Private _BudgetPeriod, _BudgetYear, _BudgetMonth As String
        Private _BudgetAmount, _UnitPrice, _Quantity As Decimal

        Private _BudgetCode, _BudgetName, _GCPurchaseOrderType As String

#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

#Region " C,R,U,D "
        Public Function UpsertBudgetAccount() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "UpsertBudgetAccount"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@BudgetPeriod", _BudgetPeriod)
                cmdToExecute.Parameters.AddWithValue("@GLAccountID", _GLAccountID)
                cmdToExecute.Parameters.AddWithValue("@BudgetAmount", _BudgetAmount)
                
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

        Public Function UpsertBudgetPurchasing() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "UpsertBudgetPurchasing"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@BudgetPeriod", _BudgetPeriod)
                cmdToExecute.Parameters.AddWithValue("@BudgetCode", _BudgetCode)
                cmdToExecute.Parameters.AddWithValue("@BudgetName", _BudgetName)
                cmdToExecute.Parameters.AddWithValue("@UnitPrice", _UnitPrice)
                cmdToExecute.Parameters.AddWithValue("@Quantity", _Quantity)
                cmdToExecute.Parameters.AddWithValue("@GCPurchaseOrderType", _GCPurchaseOrderType)
                cmdToExecute.Parameters.AddWithValue("@GLAccountID", _GLAccountID)
                cmdToExecute.Parameters.AddWithValue("@LocationID", _LocationID)

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

        Public Function InsertBudgetPurchasingMapping() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "InsertBudgetPurchasingMapping"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@BudgetPeriod", _BudgetPeriod)
                cmdToExecute.Parameters.AddWithValue("@BudgetCode", _BudgetCode)
                cmdToExecute.Parameters.AddWithValue("@ItemGroupID", _ItemGroupID)
                
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

        Public Function DeleteBudgetPurchasingMapping() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "DeleteBudgetPurchasingMapping"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@BudgetPeriod", _BudgetPeriod)
                cmdToExecute.Parameters.AddWithValue("@BudgetCode", _BudgetCode)
                cmdToExecute.Parameters.AddWithValue("@ItemGroupID", _ItemGroupID)

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

        Public Function GetBudgetAccountByPeriod() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetBudgetAccountByPeriod"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetBudgetAccountByPeriod")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@BudgetPeriod", _BudgetPeriod)

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

        Public Function GetBudgetAccountRealizationByPeriod() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetBudgetAccountRealizationByPeriod"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetBudgetAccountRealizationByPeriod")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@BudgetPeriod", _BudgetPeriod)
                cmdToExecute.Parameters.AddWithValue("@BudgetYear", _BudgetYear)
                cmdToExecute.Parameters.AddWithValue("@BudgetMonth", _BudgetMonth)

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

        Public Function GetBudgetYear() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetBudgetYear"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetBudgetYear")
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

        Public Function GetBudgetMonth(ByVal strBudgetYear As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetBudgetMonth"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetBudgetMonth")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@BudgetYear", strBudgetYear)

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

        Public Function GetActiveLocation() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetActiveLocation"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetActiveLocation")
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

        Public Function GetStandardCode(ByVal strParentID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetStandardCode"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetStandardCode")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ParentID", strParentID)

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

        Public Function GetBudgetPurchasingByPeriod() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetBudgetPurchasingByPeriod"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetBudgetPurchasingByPeriod")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@BudgetPeriod", _BudgetPeriod)

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

        Public Function GetBudgetPurchasingRealization() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetBudgetPurchasingRealization"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetBudgetPurchasingRealization")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@BudgetPeriod", _BudgetPeriod)
                cmdToExecute.Parameters.AddWithValue("@LocationID", _LocationID)

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

        Public Function GetItemGroupMapping(ByVal isExMapping As Boolean) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            If isExMapping Then
                cmdToExecute.CommandText = "GetItemGroupExMapping"
            Else
                cmdToExecute.CommandText = "GetItemGroupInMapping"
            End If
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetItemGroupMapping")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@BudgetPeriod", _BudgetPeriod)
                cmdToExecute.Parameters.AddWithValue("@BudgetCode", _BudgetCode)

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

        Public Function GetBudgetPurchasingYear() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetBudgetPurchasingYear"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetBudgetPurchasingYear")
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

        Public Function GetBudgetPurchasingByPeriodForDropDown(ByVal strBudgetPeriod As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetBudgetPurchasingByPeriodForDropDown"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetBudgetPurchasingByPeriodForDropDown")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@BudgetPeriod", strBudgetPeriod)

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
        Public Property [GLAccountID]() As Integer
            Get
                Return _GLAccountID
            End Get
            Set(ByVal Value As Integer)
                _GLAccountID = Value
            End Set
        End Property

        Public Property [LocationID]() As Integer
            Get
                Return _LocationID
            End Get
            Set(ByVal Value As Integer)
                _LocationID = Value
            End Set
        End Property

        Public Property [ItemGroupID]() As Integer
            Get
                Return _ItemGroupID
            End Get
            Set(ByVal Value As Integer)
                _ItemGroupID = Value
            End Set
        End Property

        Public Property [BudgetPeriod]() As String
            Get
                Return _BudgetPeriod
            End Get
            Set(ByVal Value As String)
                _BudgetPeriod = Value
            End Set
        End Property

        Public Property [BudgetYear]() As String
            Get
                Return _BudgetYear
            End Get
            Set(ByVal Value As String)
                _BudgetYear = Value
            End Set
        End Property

        Public Property [BudgetMonth]() As String
            Get
                Return _BudgetMonth
            End Get
            Set(ByVal Value As String)
                _BudgetMonth = Value
            End Set
        End Property

        Public Property [BudgetAmount]() As Decimal
            Get
                Return _BudgetAmount
            End Get
            Set(ByVal Value As Decimal)
                _BudgetAmount = Value
            End Set
        End Property

        Public Property [UnitPrice]() As Decimal
            Get
                Return _UnitPrice
            End Get
            Set(ByVal Value As Decimal)
                _UnitPrice = Value
            End Set
        End Property

        Public Property [Quantity]() As Decimal
            Get
                Return _Quantity
            End Get
            Set(ByVal Value As Decimal)
                _Quantity = Value
            End Set
        End Property

        Public Property [BudgetCode]() As String
            Get
                Return _BudgetCode
            End Get
            Set(ByVal Value As String)
                _BudgetCode = Value
            End Set
        End Property

        Public Property [BudgetName]() As String
            Get
                Return _BudgetName
            End Get
            Set(ByVal Value As String)
                _BudgetName = Value
            End Set
        End Property

        Public Property [GCPurchaseOrderType]() As String
            Get
                Return _GCPurchaseOrderType
            End Get
            Set(ByVal Value As String)
                _GCPurchaseOrderType = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
