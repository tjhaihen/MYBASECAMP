Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class DrugGenericMtx
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _drugInteractionHdID As Decimal
        Private _itemCode As String        
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
            cmdToExecute.CommandText = "INSERT INTO [MS_RSSM]..DrugGenericMtx " + _
                                        "(itemCode, drugInteractionHdID) " + _
                                        "VALUES " + _
                                        "(@itemCode, @drugInteractionHdID) "
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@itemCode", _itemCode)
                cmdToExecute.Parameters.AddWithValue("@drugInteractionHdID", _drugInteractionHdID)

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
            cmdToExecute.CommandText = "DELETE FROM [MS_RSSM]..DrugGenericMtx " + _
                                        "WHERE itemCode=@itemCode " + _
                                        "AND drugInteractionHdID=@drugInteractionHdID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@itemCode", _itemCode)
                cmdToExecute.Parameters.AddWithValue("@drugInteractionHdID", _drugInteractionHdID)

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
            cmdToExecute.CommandText = "SELECT * FROM [MS_RSSM]..DrugGenericMtx WHERE ItemCode=@ItemCode AND DrugInteractionHdID=@DrugInteractionHdID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DrugGenericMtx")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@itemCode", _itemCode)
                cmdToExecute.Parameters.AddWithValue("@drugInteractionHdID", _drugInteractionHdID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _itemCode = CType(toReturn.Rows(0)("itemCode"), String)
                    _drugInteractionHdID = CType(toReturn.Rows(0)("drugInteractionHdID"), Decimal)                    
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

        Public Function SelectByDrugInteractionHdID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT dt.DrugInteractionHdID, dt.ItemCode, i.nmdesc1 AS ItemName FROM [MS_RSSM]..DrugGenericMtx dt " + _
                                        "INNER JOIN [MS_RSSM]..fm_item i ON dt.ItemCode = i.kdbarang " + _
                                        "WHERE dt.DrugInteractionHdID=@DrugInteractionHdID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DrugGenericMtxByDrugInteractionHdID")
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

        Public Property [itemCode]() As String
            Get
                Return _itemCode
            End Get
            Set(ByVal Value As String)
                _itemCode = Value
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
#End Region

    End Class
End Namespace
