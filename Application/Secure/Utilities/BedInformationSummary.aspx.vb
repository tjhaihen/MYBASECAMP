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
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Math
Imports System.IO
Imports System.Globalization
Imports Microsoft.VisualBasic


Imports System.Data.SqlTypes

Namespace QIS.Web.Secure
    Public Class BedInformationSummary
        Inherits PageBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Me.IsPostBack Then
                initCompanyInfo()
                lblDateTime.Text = CultureInfo.GetCultureInfo("id-ID").DateTimeFormat.GetDayName(Date.Today.DayOfWeek) + ", " + Format(Date.Now, "dd-MMM-yyyy") + " " + Left(DateTime.Now.TimeOfDay.ToString(), 8)
                GetClass()
                GetFirstClass()
                GetRoomByClass(lblClassCode.Text.Trim)
            End If
        End Sub

        Protected Sub TimerRefreshPage_Tick(ByVal sender As Object, ByVal e As EventArgs)
            GetClass()
            GetNextClass()
            GetRoomByClass(lblClassCode.Text.Trim)            
        End Sub

        Protected Sub TimerDateTime_Tick(ByVal sender As Object, ByVal e As EventArgs)
            lblDateTime.Text = CultureInfo.GetCultureInfo("id-ID").DateTimeFormat.GetDayName(Date.Today.DayOfWeek) + ", " + Format(Date.Now, "dd-MMM-yyyy") + " " + Left(DateTime.Now.TimeOfDay.ToString(), 8)
        End Sub
#End Region

#Region " Support functions for navigation bar (Controls) "

#End Region

#Region " Private Functions "
        Private Sub initCompanyInfo()
            Dim br As New Common.BussinessRules.Company
            With br
                If .SelectOne.Rows.Count > 0 Then
                    lblCompanyName.Text = .companyName.Trim
                    lblCompanyAddress.Text = .address1.Trim
                Else
                    lblCompanyName.Text = "[Company]"
                    lblCompanyAddress.Text = "[Address]"
                End If
            End With
            br.Dispose()
            br = Nothing
        End Sub

        Private Function GetClass() As DataTable
            Dim oClass As New Common.BussinessRules.Utility
            repClass.DataSource = oClass.GetBedInformationListForWebDisplayPanelClass
            repClass.DataBind()
            oClass.Dispose()
            oClass = Nothing
        End Function

        Private Function GetFirstClass() As DataTable
            Dim oClass As New Common.BussinessRules.Utility
            If oClass.GetFirstClass().Rows.Count > 0 Then
                lblClassCode.Text = oClass.ClassCode.Trim
                lblClassName.Text = oClass.ClassName.Trim
            End If
            oClass.Dispose()
            oClass = Nothing
        End Function

        Private Function GetNextClass() As DataTable
            Dim oClass As New Common.BussinessRules.Utility
            If oClass.GetNextClass(lblClassCode.Text.Trim).Rows.Count > 0 Then
                lblClassCode.Text = oClass.ClassCode.Trim
                lblClassName.Text = oClass.ClassName.Trim
            Else
                GetFirstClass()
            End If
            oClass.Dispose()
            oClass = Nothing
        End Function

        Private Sub GetRoomByClass(ByVal strClassCode As String)
            Dim oRoom As New Common.BussinessRules.Utility
            grdDetailByClass.DataSource = oRoom.GetBedInformationListForWebDisplayPanelRoomByClass(strClassCode.Trim)
            grdDetailByClass.DataBind()
            oRoom.Dispose()
            oRoom = Nothing
        End Sub
#End Region

#Region " C,R,U,D "

#End Region

    End Class

End Namespace