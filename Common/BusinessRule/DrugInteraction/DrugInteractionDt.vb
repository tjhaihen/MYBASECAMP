Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class DrugInteractionDt
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _drugInteractionHdID, _drugInteractionDtID As Decimal
        Private _interactionGenericCode, _interactionTypeSCode As String
        Private _interactionDescriptionDt As String
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
            cmdToExecute.CommandText = "INSERT INTO [MS_RSSM]..DrugInteractionDt " + _
                                        "(drugInteractionHdID, interactionGenericCode, interactionTypeSCode, interactionDescriptionDt) " + _
                                        "VALUES " + _
                                        "(@drugInteractionHdID, @interactionGenericCode, @interactionTypeSCode, @interactionDescriptionDt) "
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@drugInteractionHdID", _drugInteractionHdID)
                cmdToExecute.Parameters.AddWithValue("@interactionGenericCode", _interactionGenericCode)
                cmdToExecute.Parameters.AddWithValue("@interactionTypeSCode", _interactionTypeSCode)
                cmdToExecute.Parameters.AddWithValue("@interactionDescriptionDt", _interactionDescriptionDt)

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
            cmdToExecute.CommandText = "UPDATE [MS_RSSM]..DrugInteractionDt " + _
                                        "SET interactionGenericCode=@interactionGenericCode, interactionTypeSCode=@interactionTypeSCode, " + _
                                        "interactionDescriptionDt=@interactionDescriptionDt " + _
                                        "WHERE drugInteractionDtID=@drugInteractionDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@drugInteractionDtID", _drugInteractionDtID)
                cmdToExecute.Parameters.AddWithValue("@interactionGenericCode", _interactionGenericCode)
                cmdToExecute.Parameters.AddWithValue("@interactionTypeSCode", _interactionTypeSCode)
                cmdToExecute.Parameters.AddWithValue("@interactionDescriptionDt", _interactionDescriptionDt)

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

        Public Overrides Function Delete() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "DELETE FROM [MS_RSSM]..DrugInteractionDt " + _
                                        "WHERE drugInteractionDtID=@drugInteractionDtID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@drugInteractionDtID", _drugInteractionDtID)
                
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

#Region " Select Data "
        Public Overrides Function SelectOne(Optional ByVal recStatus As QISRecStatus = QISRecStatus.CurrentRecord) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM [MS_RSSM]..DrugInteractionDt WHERE DrugInteractionDtID=@DrugInteractionDtID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DrugInteractionDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@drugInteractionDtID", _drugInteractionDtID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _drugInteractionDtID = CType(toReturn.Rows(0)("drugInteractionDtID"), Decimal)
                    _drugInteractionHdID = CType(toReturn.Rows(0)("drugInteractionHdID"), Decimal)
                    _interactionGenericCode = CType(toReturn.Rows(0)("interactionGenericCode"), String)
                    _interactionTypeSCode = CType(toReturn.Rows(0)("interactionTypeSCode"), String)
                    _interactionDescriptionDt = CType(toReturn.Rows(0)("interactionDescriptionDt"), String)
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

        Public Function SelectByHdID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT dt.*, hd.GenericName AS InteractionGenericName FROM [MS_RSSM]..DrugInteractionDt dt " + _
                                        "INNER JOIN [MS_RSSM]..DrugInteractionHd hd ON dt.InteractionGenericCode = hd.DrugInteractionHdID " + _
                                        "WHERE dt.DrugInteractionHdID=@DrugInteractionHdID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DrugInteractionDtByHdID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@drugInteractionHdID", _drugInteractionHdID)

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

        Public Property [drugInteractionDtID]() As Decimal
            Get
                Return _drugInteractionDtID
            End Get
            Set(ByVal Value As Decimal)
                _drugInteractionDtID = Value
            End Set
        End Property

        Public Property [drugInteractionHdID]() As Decimal
            Get
                Return _drugInteractionHdID
            End Get
            Set(ByVal Value As Decimal)
                _drugInteractionHdID = Value
            End Set
        End Property

        Public Property [interactionGenericCode]() As String
            Get
                Return _interactionGenericCode
            End Get
            Set(ByVal Value As String)
                _interactionGenericCode = Value
            End Set
        End Property

        Public Property [interactionTypeSCode]() As String
            Get
                Return _interactionTypeSCode
            End Get
            Set(ByVal Value As String)
                _interactionTypeSCode = Value
            End Set
        End Property

        Public Property [interactionDescriptionDt]() As String
            Get
                Return _interactionDescriptionDt
            End Get
            Set(ByVal Value As String)
                _interactionDescriptionDt = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
