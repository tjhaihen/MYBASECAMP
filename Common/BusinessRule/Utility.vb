Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports QIS.Common

Namespace QIS.Common.BussinessRules
    Public Class Utility
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _roomCode, _classCode, _className As String
        Private _genericCode, _genericName, _genericGroupName, _brandNames, _interactionDescription As String
        Private _itemCode, _itemName As String
        Private _interactionTypeSCode, _interactionDescriptionDt As String

        '// For Physician Schedule Information        
        Private _specialtyID, _physicianID, _scheduleDay As String
        Private _clinicID, _shiftID As String
        Private _sMON, _eMON As String
        Private _sTUE, _eTUE As String
        Private _sWED, _eWED As String
        Private _sTHU, _eTHU As String
        Private _sFRI, _eFRI As String
        Private _sSAT, _eSAT As String
        Private _sSUN, _eSUN As String
        Private _isAvailable As Boolean
        Private _scrollingText As String
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

#Region " C,R,U,D "
        Public Function GetFirstClass() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetFirstClass"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetFirstClass")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _classCode = CType(toReturn.Rows(0)("classCode"), String)
                    _className = CType(toReturn.Rows(0)("className"), String)
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

        Public Function GetNextClass(ByVal strCurrentClassCode As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetNextClass"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetNextClass")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@CurrentClassCode", strCurrentClassCode)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _classCode = CType(toReturn.Rows(0)("classCode"), String)
                    _className = CType(toReturn.Rows(0)("className"), String)                
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

        Public Function GetBedInformationListForWebDisplayPanelClass() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetBedInformationListForWebDisplayPanelClass"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetBedInformationListForWebDisplayPanelClass")
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

        Public Function GetBedInformationListForWebDisplayPanelRoom() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetBedInformationListForWebDisplayPanelRoom"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetBedInformationListForWebDisplayPanelRoom")
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

        Public Function GetBedInformationListForWebDisplayPanelRoomByClass(ByVal strClassCode As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetBedInformationListForWebDisplayPanelRoomByClass"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetBedInformationListForWebDisplayPanelRoomByClass")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ClassCode", strClassCode)

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

        Public Function GetBedInformationListForWebDisplayPanel() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetBedInformationListForWebDisplayPanel"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetBedInformationListForWebDisplayPanel")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@RoomCode", _roomCode)

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

        Public Function GetBedInformationListForWebDisplayPanelClassUpdate() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetBedInformationListForWebDisplayPanelClassUpdate"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetBedInformationListForWebDisplayPanelClassUpdate")
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

        Public Function GetPhysicianSpecialtyListForWebDisplay() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetPhysicianSpecialtyListForWebDisplay"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetPhysicianSpecialtyListForWebDisplay")
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

        Public Function GetPhysician() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetPhysician"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetPhysician")
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

        Public Function GetClinicByPhysician(ByVal strPhysicianID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetClinicByPhysician"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetClinicByPhysician")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@PhysicianID", strPhysicianID)

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

        Public Function GetShift() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetShift"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetShift")
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

        Public Function GetPhysicianSchedule() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetPhysicianSchedule"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetPhysicianSchedule")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@PhysicianID", _physicianID)
                cmdToExecute.Parameters.AddWithValue("@ClinicID", _clinicID)
                cmdToExecute.Parameters.AddWithValue("@ShiftID", _shiftID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _physicianID = CType(toReturn.Rows(0)("physicianID"), String)
                    _clinicID = CType(toReturn.Rows(0)("clinicID"), String)
                    _shiftID = CType(toReturn.Rows(0)("shift"), String)
                    _sMON = CType(toReturn.Rows(0)("sMon"), String)
                    _eMON = CType(toReturn.Rows(0)("eMon"), String)
                    _sTUE = CType(toReturn.Rows(0)("sTue"), String)
                    _eTUE = CType(toReturn.Rows(0)("eTue"), String)
                    _sWED = CType(toReturn.Rows(0)("sWed"), String)
                    _eWED = CType(toReturn.Rows(0)("eWed"), String)
                    _sTHU = CType(toReturn.Rows(0)("sThu"), String)
                    _eTHU = CType(toReturn.Rows(0)("eThu"), String)
                    _sFRI = CType(toReturn.Rows(0)("sFri"), String)
                    _eFRI = CType(toReturn.Rows(0)("eFri"), String)
                    _sSAT = CType(toReturn.Rows(0)("sSat"), String)
                    _eSAT = CType(toReturn.Rows(0)("eSat"), String)
                    _sSUN = CType(toReturn.Rows(0)("sSun"), String)
                    _eSUN = CType(toReturn.Rows(0)("eSun"), String)
                    _isAvailable = CType(toReturn.Rows(0)("IsAvailable"), Boolean)
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

        Public Function GetPhysicianBySpecialtyListForWebDisplay() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetPhysicianBySpecialtyListForWebDisplay"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetPhysicianBySpecialtyListForWebDisplay")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@SpecialtyID", _specialtyID)

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

        Public Function GetPhysicianScheduleInformationListForWebDisplay() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetPhysicianScheduleInformationListForWebDisplay"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetPhysicianScheduleInformationListForWebDisplay")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@PhysicianID", _physicianID)
                cmdToExecute.Parameters.AddWithValue("@ScheduleDay", _scheduleDay)

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

        Public Function GetPhysicianIsAvailable() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetPhysicianIsAvailable"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetPhysicianIsAvailable")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@PhysicianID", _physicianID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _isAvailable = CType(toReturn.Rows(0)("IsAvailable"), Boolean)
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

        Public Function GetScrollingText() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetScrollingText"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetScrollingText")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _scrollingText = CType(toReturn.Rows(0)("ScrollingText"), String)
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

        Public Function UpdateInsertPhysicianSchedule() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "UpsertPhysicianSchedule"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@physicianID", _physicianID)
                cmdToExecute.Parameters.AddWithValue("@clinicID", _clinicID)
                cmdToExecute.Parameters.AddWithValue("@shiftID", _shiftID)
                cmdToExecute.Parameters.AddWithValue("@sMON", _sMON)
                cmdToExecute.Parameters.AddWithValue("@eMON", _eMON)
                cmdToExecute.Parameters.AddWithValue("@sTUE", _sTUE)
                cmdToExecute.Parameters.AddWithValue("@eTUE", _eTUE)
                cmdToExecute.Parameters.AddWithValue("@sWED", _sWED)
                cmdToExecute.Parameters.AddWithValue("@eWED", _eWED)
                cmdToExecute.Parameters.AddWithValue("@sTHU", _sTHU)
                cmdToExecute.Parameters.AddWithValue("@eTHU", _eTHU)
                cmdToExecute.Parameters.AddWithValue("@sFRI", _sFRI)
                cmdToExecute.Parameters.AddWithValue("@eFRI", _eFRI)
                cmdToExecute.Parameters.AddWithValue("@sSAT", _sSAT)
                cmdToExecute.Parameters.AddWithValue("@eSAT", _eSAT)
                cmdToExecute.Parameters.AddWithValue("@sSUN", _sSUN)
                cmdToExecute.Parameters.AddWithValue("@eSUN", _eSUN)

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

        Public Function UpdatePhysicianIsAvailable() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "UpdatePhysicianIsAvailable"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@physicianID", _physicianID)
                cmdToExecute.Parameters.AddWithValue("@isAvailable", _isAvailable)

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

        Public Function UpdateScrollingText() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "UpdateScrollingText"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ScrollingText", _scrollingText)

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

        Public Function GetDrugInteractionInformation() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetDrugInteractionInformation"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetDrugInteractionInformation")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@GenericName", _genericName)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
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

        Public Function GetItemName() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetItemName"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetItemName")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ItemCode", _itemCode)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _itemCode = CType(toReturn.Rows(0)("itemCode"), String)
                    _itemName = CType(toReturn.Rows(0)("itemName"), String)
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

        Public Function GetDrugInteractionCheckResult(ByVal strItemCode1 As String, ByVal strItemCode2 As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetDrugInteractionCheckResult"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetDrugInteractionCheckResult")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ItemCode1", strItemCode1)
                cmdToExecute.Parameters.AddWithValue("@ItemCode2", strItemCode2)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
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

        Public Function GetRoom() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spLinkGetRoom"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("spLinkGetRoom")
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

        Public Function GetDiagnosticSupportUnit() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spLinkGetDiagnosticSupportUnit"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("spLinkGetDiagnosticSupportUnit")
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

        Public Function GetItemByServiceUnitIDNotInJobOrder(ByVal strServiceUnitID As String, ByVal strJobOrderNo As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spLinkGetItemByServiceUnitIDNotInJobOrder"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("spLinkGetItemByServiceUnitIDNotInJobOrder")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ServiceUnitID", strServiceUnitID)
                cmdToExecute.Parameters.AddWithValue("@JobOrderNo", strJobOrderNo)

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

        Public Function GetItemByServiceUnitIDInJobOrder(ByVal strServiceUnitID As String, ByVal strJobOrderNo As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "spLinkGetItemByServiceUnitIDInJobOrder"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("spLinkGetItemByServiceUnitIDInJobOrder")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ServiceUnitID", strServiceUnitID)
                cmdToExecute.Parameters.AddWithValue("@JobOrderNo", strJobOrderNo)

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

        Public Function GetDateInMonth(ByVal intYear As Integer, ByVal intMonth As Integer, ByVal strUserID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "GetDateInMonth"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("GetDateInMonth")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@Year", intYear)
                cmdToExecute.Parameters.AddWithValue("@Month", intMonth)
                cmdToExecute.Parameters.AddWithValue("@UserID", strUserID)

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
        Public Property [ClassCode]() As String
            Get
                Return _classCode
            End Get
            Set(ByVal Value As String)
                _classCode = Value
            End Set
        End Property

        Public Property [ClassName]() As String
            Get
                Return _className
            End Get
            Set(ByVal Value As String)
                _className = Value
            End Set
        End Property

        Public Property [RoomCode]() As String
            Get
                Return _roomCode
            End Get
            Set(ByVal Value As String)
                _roomCode = Value
            End Set
        End Property

        Public Property [SpecialtyID]() As String
            Get
                Return _specialtyID
            End Get
            Set(ByVal Value As String)
                _specialtyID = Value
            End Set
        End Property

        Public Property [PhysicianID]() As String
            Get
                Return _physicianID
            End Get
            Set(ByVal Value As String)
                _physicianID = Value
            End Set
        End Property

        Public Property [ClinicID]() As String
            Get
                Return _clinicID
            End Get
            Set(ByVal Value As String)
                _clinicID = Value
            End Set
        End Property

        Public Property [ShiftID]() As String
            Get
                Return _shiftID
            End Get
            Set(ByVal Value As String)
                _shiftID = Value
            End Set
        End Property

        Public Property [sMON]() As String
            Get
                Return _sMON
            End Get
            Set(ByVal Value As String)
                _sMON = Value
            End Set
        End Property

        Public Property [eMON]() As String
            Get
                Return _eMON
            End Get
            Set(ByVal Value As String)
                _eMON = Value
            End Set
        End Property

        Public Property [sTUE]() As String
            Get
                Return _sTUE
            End Get
            Set(ByVal Value As String)
                _sTUE = Value
            End Set
        End Property

        Public Property [eTUE]() As String
            Get
                Return _eTUE
            End Get
            Set(ByVal Value As String)
                _eTUE = Value
            End Set
        End Property

        Public Property [sWED]() As String
            Get
                Return _sWED
            End Get
            Set(ByVal Value As String)
                _sWED = Value
            End Set
        End Property

        Public Property [eWED]() As String
            Get
                Return _eWED
            End Get
            Set(ByVal Value As String)
                _eWED = Value
            End Set
        End Property

        Public Property [sTHU]() As String
            Get
                Return _sTHU
            End Get
            Set(ByVal Value As String)
                _sTHU = Value
            End Set
        End Property

        Public Property [eTHU]() As String
            Get
                Return _eTHU
            End Get
            Set(ByVal Value As String)
                _eTHU = Value
            End Set
        End Property

        Public Property [sFRI]() As String
            Get
                Return _sFRI
            End Get
            Set(ByVal Value As String)
                _sFRI = Value
            End Set
        End Property

        Public Property [eFRI]() As String
            Get
                Return _eFRI
            End Get
            Set(ByVal Value As String)
                _eFRI = Value
            End Set
        End Property

        Public Property [sSAT]() As String
            Get
                Return _sSAT
            End Get
            Set(ByVal Value As String)
                _sSAT = Value
            End Set
        End Property

        Public Property [eSAT]() As String
            Get
                Return _eSAT
            End Get
            Set(ByVal Value As String)
                _eSAT = Value
            End Set
        End Property

        Public Property [sSUN]() As String
            Get
                Return _sSUN
            End Get
            Set(ByVal Value As String)
                _sSUN = Value
            End Set
        End Property

        Public Property [eSUN]() As String
            Get
                Return _eSUN
            End Get
            Set(ByVal Value As String)
                _eSUN = Value
            End Set
        End Property

        Public Property [IsAvailable]() As Boolean
            Get
                Return _isAvailable
            End Get
            Set(ByVal Value As Boolean)
                _isAvailable = Value
            End Set
        End Property

        Public Property [ScrollingText]() As String
            Get
                Return _scrollingText
            End Get
            Set(ByVal Value As String)
                _scrollingText = Value
            End Set
        End Property

        Public Property [ScheduleDay]() As String
            Get
                Return _scheduleDay
            End Get
            Set(ByVal Value As String)
                _scheduleDay = Value
            End Set
        End Property

        Public Property [GenericCode]() As String
            Get
                Return _genericCode
            End Get
            Set(ByVal Value As String)
                _genericCode = Value
            End Set
        End Property

        Public Property [GenericName]() As String
            Get
                Return _genericName
            End Get
            Set(ByVal Value As String)
                _genericName = Value
            End Set
        End Property

        Public Property [GenericGroupName]() As String
            Get
                Return _genericGroupName
            End Get
            Set(ByVal Value As String)
                _genericGroupName = Value
            End Set
        End Property

        Public Property [BrandNames]() As String
            Get
                Return _brandNames
            End Get
            Set(ByVal Value As String)
                _brandNames = Value
            End Set
        End Property

        Public Property [InteractionDescription]() As String
            Get
                Return _interactionDescription
            End Get
            Set(ByVal Value As String)
                _interactionDescription = Value
            End Set
        End Property

        Public Property [ItemCode]() As String
            Get
                Return _itemCode
            End Get
            Set(ByVal Value As String)
                _itemCode = Value
            End Set
        End Property

        Public Property [ItemName]() As String
            Get
                Return _itemName
            End Get
            Set(ByVal Value As String)
                _itemName = Value
            End Set
        End Property

        Public Property [InteractionTypeSCode]() As String
            Get
                Return _interactionTypeSCode
            End Get
            Set(ByVal Value As String)
                _interactionTypeSCode = Value
            End Set
        End Property

        Public Property [InteractionDescriptionDt]() As String
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
