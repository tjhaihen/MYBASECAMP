Option Strict On
Option Explicit On

Imports System
Imports System.Text
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.Data.SqlTypes

Imports QIS.Common

Namespace QIS.Web.EMRTracking

    Public Class Dashboard
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
#End Region


#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Me.IsPostBack Then
            Else
                prepareScreen(True)
                GetLocationGroup()
                DataBind()
            End If
        End Sub

        Private Sub txtMedicalNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMedicalNo.TextChanged
            _openPatientData(txtMedicalNo.Text.Trim)
        End Sub

        Private Sub btnGetData_Click(sender As Object, e As System.EventArgs) Handles btnGetData.Click
            _openPatientData(txtMedicalNo.Text.Trim)            
        End Sub

        Protected Sub repLocationGroup_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs)
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim row As DataRowView = CType(e.Item.DataItem, DataRowView)

                Dim pnlHEXColor As Panel = CType(e.Item.FindControl("pnlHEXColor"), Panel)
                pnlHEXColor.BackColor = System.Drawing.ColorTranslator.FromHtml(row("HEXColorID").ToString.Trim)

                Dim oBR As New Common.BussinessRules.EMRTrackingHistory
                Dim _grdLocation As DataGrid = CType(e.Item.FindControl("_grdLocation"), DataGrid)
                _grdLocation.DataSource = oBR.SelectSummaryByLocation(row("locationGroupCode").ToString.Trim)
                _grdLocation.DataBind()
                oBR.Dispose()
                oBR = Nothing
            End If
        End Sub
#End Region


#Region " Support functions for navigation bar (Controls) "

#End Region


#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
        End Function

        Private Sub prepareScreen(ByVal isNew As Boolean)
            commonFunction.Focus(Me, txtMedicalNo.ClientID)
        End Sub

        Private Sub SetDataGridEMRTrackingHistory()
            Dim oBR As New Common.BussinessRules.EMRTrackingHistory
            oBR.MedicalNo = txtMedicalNo.Text.Trim
            grdEMRTrackingHistory.DataSource = oBR.SelectByMedicalNo(False)
            grdEMRTrackingHistory.DataBind()
            oBR.Dispose()
            oBR = Nothing
        End Sub

        Private Sub GetLocationGroup()
            Dim oBr As New Common.BussinessRules.EMRlocationGroup
            repLocationGroup.DataSource = oBr.SelectAll
            repLocationGroup.DataBind()
            oBr.Dispose()
            oBr = Nothing
        End Sub
#End Region


#Region " C,R,U,D "
        Private Sub _openPatientData(ByVal strMedicalNo As String)
            Dim strFormattedMRN As String = String.Empty
            strFormattedMRN = Right("00000000" + strMedicalNo.Replace("-", "").Trim, 8).Trim
            strFormattedMRN = Left(strFormattedMRN, 2) + "-" + Mid(strFormattedMRN, 3, 2) + "-" + Mid(strFormattedMRN, 5, 2) + "-" + Right(strFormattedMRN, 2)
            txtMedicalNo.Text = strFormattedMRN

            Dim oBR As New Common.BussinessRules.EMRTrackingHistory
            With oBR
                .MedicalNo = txtMedicalNo.Text.Trim
                If .SelectPatientData.Rows.Count > 0 Then
                    lblPatientName.Text = .PatientName.Trim
                    lblSex.Text = .Sex.Trim
                    lblDOB.Text = .cfDateOfBirth.Trim
                    lblStreetName.Text = .streetName.Trim
                    lblCity.Text = .city.Trim
                    lblReligion.Text = .religion.Trim
                    lblUserNameProcess.Text = .UserNameProcess.Trim
                    lblCurrentLocationNameProcess.Text = .CurrentLocationName.Trim
                Else
                    commonFunction.MsgBox(Me, "Data Rekam Medis tidak terdaftar.")
                    txtMedicalNo.Text = String.Empty
                    lblPatientName.Text = String.Empty
                    lblSex.Text = String.Empty
                    lblDOB.Text = String.Empty
                    lblStreetName.Text = String.Empty
                    lblCity.Text = String.Empty
                    lblReligion.Text = String.Empty
                    lblUserNameProcess.Text = String.Empty
                    lblCurrentLocationNameProcess.Text = String.Empty
                End If
            End With
            oBR.Dispose()
            oBR = Nothing
            commonFunction.Focus(Me, txtMedicalNo.ClientID)
            SetDataGridEMRTrackingHistory()
        End Sub
#End Region

    End Class

End Namespace