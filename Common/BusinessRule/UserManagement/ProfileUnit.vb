Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class ProfileUnit
        Inherits BRInteractionBase

#Region " Class Member Declarations "

        Private _profileUnitID, _profileID, _unitID, _departmentID As String

#End Region

        Private Sub init()
            'add more initiation here if any
        End Sub

        Public Sub New()
            ' // Nothing for now.
            init()
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
            init()
        End Sub

#Region "Insert"
        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO ProfileUnit (ProfileUnitID, ProfileID, UnitID, DepartmentID) " & _
                                        "VALUES (@ProfileUnitID, @ProfileID, @UnitID, @DepartmentID)"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Dim strProfileUnitID As String = ID.GenerateIDNumber("ProfileUnit", "ProfileUnitID")

            Try
                cmdToExecute.Parameters.AddWithValue("@ProfileUnitID", strProfileUnitID)
                cmdToExecute.Parameters.AddWithValue("@ProfileID", _profileID)
                cmdToExecute.Parameters.AddWithValue("@UnitID", _unitID)
                cmdToExecute.Parameters.AddWithValue("@DepartmentID", _departmentID)

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

#Region "Delete"
        Public Overrides Function Delete() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "DELETE FROM ProfileUnit WHERE ProfileUnitID=@ProfileUnitID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ProfileUnitID", _profileUnitID)

                ' //Open Connection
                _mainConnection.Open()

                ' //Execute Query
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

#Region "Select All"

#End Region

#Region " Otorisasi Unit "
        Public Function SelectUnitByProfileID(ByVal ProfileID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spSelectProfileUnitByProfileID"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("spSelectProfileUnitByProfileID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ProfileID", ProfileID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                Return toReturn
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                Throw New Exception(ex.Message)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function

        Public Function SelectUnitByProfileIDDepartmentID(ByVal ProfileID As String, ByVal DepartmentID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spSelectProfileUnitByProfileIDDepartmentID"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("spSelectProfileUnitByProfileIDDepartmentID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ProfileID", ProfileID)
                cmdToExecute.Parameters.AddWithValue("@DepartmentID", DepartmentID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                Return toReturn
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                Throw New Exception(ex.Message)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function

        Public Function SelectUnitNotInProfileUnitByProfileIDDepartmentID(ByVal ProfileID As String, ByVal DepartmentID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spSelectUnitNotInProfileUnitByProfileIDDepartmentID"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("spSelectUnitNotInProfileUnitByProfileIDDepartmentID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ProfileID", ProfileID)
                cmdToExecute.Parameters.AddWithValue("@DepartmentID", DepartmentID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                Return toReturn
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                Throw New Exception(ex.Message)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function
#End Region

#Region " Class Property Declarations "

        Public Property [ProfileUnitID]() As String
            Get
                Return _profileUnitID
            End Get
            Set(ByVal Value As String)
                _profileUnitID = Value
            End Set
        End Property

        Public Property [ProfileID]() As String
            Get
                Return _profileID
            End Get
            Set(ByVal Value As String)
                _profileID = Value
            End Set
        End Property

        Public Property [UnitID]() As String
            Get
                Return _unitID
            End Get
            Set(ByVal Value As String)
                _unitID = Value
            End Set
        End Property

        Public Property [DepartmentID]() As String
            Get
                Return _departmentID
            End Get
            Set(ByVal Value As String)
                _departmentID = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
