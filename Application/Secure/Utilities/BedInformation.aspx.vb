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
Imports Microsoft.VisualBasic


Imports System.Data.SqlTypes

Namespace QIS.Web.Secure
    Public Class BedInformation
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
                lblDateTime.Text = Format(Date.Now, "dd-MMM-yyyy hh:mm")
                GetRoom()
            End If
        End Sub

        Protected Sub repRoom_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repRoom.ItemDataBound
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim row As DataRowView = CType(e.Item.DataItem, DataRowView)
                Dim repBed As Repeater = CType(e.Item.FindControl("repBed"), Repeater)

                Dim lblTotalByRoom As Label = CType(e.Item.FindControl("lblTotalByRoom"), Label)
                Dim lblTotalKOSONGByRoom As Label = CType(e.Item.FindControl("lblTotalKOSONGByRoom"), Label)
                Dim lblTotalDIBERSIHKANByRoom As Label = CType(e.Item.FindControl("lblTotalDIBERSIHKANByRoom"), Label)
                Dim lblTotalTERISIByRoom As Label = CType(e.Item.FindControl("lblTotalTERISIByRoom"), Label)

                Dim dtBed As DataTable = Me.GetBedByRoom(row("RoomCode").ToString.Trim)
                If dtBed.Rows.Count > 0 Then
                    repBed.DataSource = dtBed
                    repBed.DataBind()
                End If

                lblTotalByRoom.Text = row("TotalBed").ToString.Trim
                lblTotalKOSONGByRoom.Text = row("TotalAvailable").ToString.Trim
                lblTotalDIBERSIHKANByRoom.Text = row("TotalCleaning").ToString.Trim
                lblTotalTERISIByRoom.Text = row("TotalOccupied").ToString.Trim
            End If
        End Sub

        Protected Sub repBed_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs)
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim row As DataRowView = CType(e.Item.DataItem, DataRowView)

                Dim pnlHEXColorRoom As Panel = CType(e.Item.FindControl("pnlHEXColorRoom"), Panel)
                Dim pnlHEXColorGender As Panel = CType(e.Item.FindControl("pnlHEXColorGender"), Panel)
                pnlHEXColorRoom.BackColor = System.Drawing.ColorTranslator.FromHtml(row("HEXColorIDRoom").ToString.Trim)
                pnlHEXColorGender.BackColor = System.Drawing.ColorTranslator.FromHtml(row("HEXColorIDGender").ToString.Trim)
            End If
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

        Private Function GetRoom() As DataTable
            Dim oRoom As New Common.BussinessRules.Utility
            repRoom.DataSource = oRoom.GetBedInformationListForWebDisplayPanelRoom
            repRoom.DataBind()
            oRoom.Dispose()
            oRoom = Nothing
        End Function

        Private Function GetBedByRoom(ByVal RoomCode As String) As DataTable
            Dim dt As DataTable
            Dim oBed As New Common.BussinessRules.Utility
            oBed.RoomCode = RoomCode.Trim
            dt = oBed.GetBedInformationListForWebDisplayPanel()
            oBed.Dispose()
            oBed = Nothing
            Return dt
        End Function
#End Region

#Region " C,R,U,D "

#End Region

    End Class

End Namespace