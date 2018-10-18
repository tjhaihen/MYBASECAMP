Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class DrugInteractionHd
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _drugInteractionHdID As Decimal
        Private _genericCode, _genericName As String
        Private _genericGroupName, _brandNames, _interactionDescription As String
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

#Region " Insert, Update "
        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spDrugInteractionHdInsert"
            cmdToExecute.CommandType = CommandType.StoredProcedure
                        
            cmdToExecute.Connection = _mainConnection
            Try
                cmdToExecute.Parameters.AddWithValue("@genericName", _genericName)
                cmdToExecute.Parameters.AddWithValue("@genericGroupName", _genericGroupName)
                cmdToExecute.Parameters.AddWithValue("@brandNames", _brandNames)
                cmdToExecute.Parameters.AddWithValue("@interactionDescription", _interactionDescription)

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
            cmdToExecute.CommandText = "UPDATE [MS_RSSM]..DrugInteractionHd " + _
                                        "SET genericCode=@genericCode, genericName=@genericName, " + _
                                        "genericGroupName=@genericGroupName, brandNames=@brandNames, interactionDescription=@interactionDescription " + _
                                        "WHERE drugInteractionHdID=@drugInteractionHdID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@drugInteractionHdID", _drugInteractionHdID)
                cmdToExecute.Parameters.AddWithValue("@genericCode", _genericCode)
                cmdToExecute.Parameters.AddWithValue("@genericName", _genericName)
                cmdToExecute.Parameters.AddWithValue("@genericGroupName", _genericGroupName)
                cmdToExecute.Parameters.AddWithValue("@brandNames", _brandNames)
                cmdToExecute.Parameters.AddWithValue("@interactionDescription", _interactionDescription)

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

#Region " Select One "
        Public Overrides Function SelectAll() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM [MS_RSSM]..DrugInteractionHd ORDER BY GenericName"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DrugInteractionHd")
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
            cmdToExecute.CommandText = "SELECT * FROM [MS_RSSM]..DrugInteractionHd WHERE DrugInteractionHdID=@DrugInteractionHdID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DrugInteractionHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@drugInteractionHdID", _drugInteractionHdID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _drugInteractionHdID = CType(toReturn.Rows(0)("drugInteractionHdID"), Decimal)
                    _genericCode = CType(toReturn.Rows(0)("genericCode"), String)
                    _genericName = CType(toReturn.Rows(0)("genericName"), String)
                    _genericGroupName = CType(toReturn.Rows(0)("genericGroupName"), String)
                    _brandNames = CType(toReturn.Rows(0)("brandNames"), String)
                    _interactionDescription = CType(toReturn.Rows(0)("interactionDescription"), String)
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

        Public Property [drugInteractionHdID]() As Decimal
            Get
                Return _drugInteractionHdID
            End Get
            Set(ByVal Value As Decimal)
                _drugInteractionHdID = Value
            End Set
        End Property

        Public Property [genericCode]() As String
            Get
                Return _genericCode
            End Get
            Set(ByVal Value As String)
                _genericCode = Value
            End Set
        End Property

        Public Property [genericName]() As String
            Get
                Return _genericName
            End Get
            Set(ByVal Value As String)
                _genericName = Value
            End Set
        End Property

        Public Property [genericGroupName]() As String
            Get
                Return _genericGroupName
            End Get
            Set(ByVal Value As String)
                _genericGroupName = Value
            End Set
        End Property

        Public Property [brandNames]() As String
            Get
                Return _brandNames
            End Get
            Set(ByVal Value As String)
                _brandNames = Value
            End Set
        End Property

        Public Property [interactionDescription]() As String
            Get
                Return _interactionDescription
            End Get
            Set(ByVal Value As String)
                _interactionDescription = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
