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
    Public Class PhysicianScheduleInformation
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
                initScreen()
                lblDateTime.Text = CultureInfo.GetCultureInfo("id-ID").DateTimeFormat.GetDayName(Date.Today.DayOfWeek) + ", " + Format(Date.Now, "dd-MMM-yyyy")
                GetSpecialty()
                OpenScrollingText()
            End If
        End Sub

        Private Sub ibtnSummary_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtnSummary.Click
            pnlSummary.Visible = True
            pnlDetail.Visible = False
            pnlEdit.Visible = False
            lblPageTitle.Text = "INFORMASI JADWAL PRAKTEK DOKTER HARI INI"
            GetSpecialty()
            OpenScrollingText()
        End Sub

        Private Sub ibtnDetail_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtnDetail.Click
            pnlSummary.Visible = False
            pnlDetail.Visible = True
            pnlEdit.Visible = False
            lblPageTitle.Text = "INFORMASI JADWAL PRAKTEK DOKTER"
            GetSpecialty()
            OpenScrollingText()
        End Sub

        Private Sub ibtEdit_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ibtnEdit.Click
            pnlSummary.Visible = False
            pnlDetail.Visible = False
            pnlEdit.Visible = True
            lblPageTitle.Text = "EDIT INFORMASI JADWAL PRAKTEK DOKTER"
            OpenScrollingText()
        End Sub

        Protected Sub repSpecialty_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repSpecialty.ItemDataBound
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim row As DataRowView = CType(e.Item.DataItem, DataRowView)
                Dim repPhysicianBySpecialty As Repeater = CType(e.Item.FindControl("repPhysicianBySpecialty"), Repeater)

                Dim dtPhysician As DataTable = Me.GetPhysicianBySpecialty(row("SpecialtyID").ToString.Trim)
                If dtPhysician.Rows.Count > 0 Then
                    repPhysicianBySpecialty.DataSource = dtPhysician
                    repPhysicianBySpecialty.DataBind()
                End If
            End If
        End Sub

        Protected Sub repSpecialtySum_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles repSpecialtySum.ItemDataBound
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim row As DataRowView = CType(e.Item.DataItem, DataRowView)
                Dim repPhysicianBySpecialtySum As Repeater = CType(e.Item.FindControl("repPhysicianBySpecialtySum"), Repeater)

                Dim dtPhysician As DataTable = Me.GetPhysicianBySpecialty(row("SpecialtyID").ToString.Trim)
                If dtPhysician.Rows.Count > 0 Then
                    repPhysicianBySpecialtySum.DataSource = dtPhysician
                    repPhysicianBySpecialtySum.DataBind()
                End If
            End If
        End Sub

        Protected Sub repPhysicianBySpecialty_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs)
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim row As DataRowView = CType(e.Item.DataItem, DataRowView)
                Dim lvwMONi As ListView = CType(e.Item.FindControl("lvwMONi"), ListView)
                Dim lvwTUEi As ListView = CType(e.Item.FindControl("lvwTUEi"), ListView)
                Dim lvwWEDi As ListView = CType(e.Item.FindControl("lvwWEDi"), ListView)
                Dim lvwTHUi As ListView = CType(e.Item.FindControl("lvwTHUi"), ListView)
                Dim lvwFRIi As ListView = CType(e.Item.FindControl("lvwFRIi"), ListView)
                Dim lvwSATi As ListView = CType(e.Item.FindControl("lvwSATi"), ListView)
                Dim lvwSUNi As ListView = CType(e.Item.FindControl("lvwSUNi"), ListView)

                Dim dtScheduleMon As DataTable = Me.GetPhysicianSchedule(row("PhysicianID").ToString.Trim, "MON")
                Dim dtScheduleTue As DataTable = Me.GetPhysicianSchedule(row("PhysicianID").ToString.Trim, "TUE")
                Dim dtScheduleWed As DataTable = Me.GetPhysicianSchedule(row("PhysicianID").ToString.Trim, "WED")
                Dim dtScheduleThu As DataTable = Me.GetPhysicianSchedule(row("PhysicianID").ToString.Trim, "THU")
                Dim dtScheduleFri As DataTable = Me.GetPhysicianSchedule(row("PhysicianID").ToString.Trim, "FRI")
                Dim dtScheduleSat As DataTable = Me.GetPhysicianSchedule(row("PhysicianID").ToString.Trim, "SAT")
                Dim dtScheduleSun As DataTable = Me.GetPhysicianSchedule(row("PhysicianID").ToString.Trim, "SUN")

                If dtScheduleMon.Rows.Count > 0 Then
                    lvwMONi.DataSource = dtScheduleMon
                End If
                If dtScheduleTue.Rows.Count > 0 Then
                    lvwTUEi.DataSource = dtScheduleTue
                End If
                If dtScheduleWed.Rows.Count > 0 Then
                    lvwWEDi.DataSource = dtScheduleWed
                End If
                If dtScheduleThu.Rows.Count > 0 Then
                    lvwTHUi.DataSource = dtScheduleThu
                End If
                If dtScheduleFri.Rows.Count > 0 Then
                    lvwFRIi.DataSource = dtScheduleFri
                End If
                If dtScheduleSat.Rows.Count > 0 Then
                    lvwSATi.DataSource = dtScheduleSat
                End If
                If dtScheduleSun.Rows.Count > 0 Then
                    lvwSUNi.DataSource = dtScheduleSun
                End If

                lvwMONi.DataBind()
                lvwTUEi.DataBind()
                lvwWEDi.DataBind()
                lvwTHUi.DataBind()
                lvwFRIi.DataBind()
                lvwSATi.DataBind()
                lvwSUNi.DataBind()
            End If
        End Sub

        Protected Sub repPhysicianBySpecialtySum_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs)
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim row As DataRowView = CType(e.Item.DataItem, DataRowView)
                Dim lvwTIME As ListView = CType(e.Item.FindControl("lvwTIME"), ListView)
                
                Dim dtSchedule As DataTable = Me.GetPhysicianSchedule(row("PhysicianID").ToString.Trim, Left(Date.Today.DayOfWeek.ToString.Trim, 3).ToUpper)
                lvwTIME.DataSource = dtSchedule
                lvwTIME.DataBind()                
            End If
        End Sub

        Private Sub ddlPhysician_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlPhysician.SelectedIndexChanged
            commonFunction.SetDDL_Table(ddlClinic, "ClinicByPhysician", ddlPhysician.SelectedItem.Value.Trim, True, "-- PILIH KLINIK --")
            OpenPhysicianSchedule()
            OpenPhysicianIsAvailable()
        End Sub

        Private Sub ddlClinic_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlClinic.SelectedIndexChanged
            OpenPhysicianSchedule()
        End Sub

        Private Sub ddlShift_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlShift.SelectedIndexChanged
            OpenPhysicianSchedule()
        End Sub

        Private Sub btnSaveJadwal_Click(sender As Object, e As System.EventArgs) Handles btnSaveJadwal.Click
            If ddlPhysician.SelectedIndex = 0 Then
                commonFunction.MsgBox(Me, "Dokter harus dipilih.")
                commonFunction.Focus(Me, ddlPhysician.ClientID)
                Exit Sub
            End If
            If ddlClinic.SelectedIndex = 0 Then
                commonFunction.MsgBox(Me, "Klinik harus dipilih.")
                commonFunction.Focus(Me, ddlClinic.ClientID)
                Exit Sub
            End If
            If ddlShift.SelectedIndex = 0 Then
                commonFunction.MsgBox(Me, "Shift harus dipilih.")
                commonFunction.Focus(Me, ddlShift.ClientID)
                Exit Sub
            End If

            Dim oPS As New Common.BussinessRules.Utility
            With oPS
                .PhysicianID = ddlPhysician.SelectedItem.Value.Trim
                .ClinicID = ddlClinic.SelectedItem.Value.Trim
                .ShiftID = ddlShift.SelectedItem.Value.Trim
                .sMON = txtsMON.Text.Trim
                .eMON = txteMON.Text.Trim
                .sTUE = txtsTUE.Text.Trim
                .eTUE = txteTUE.Text.Trim
                .sWED = txtsWED.Text.Trim
                .eWED = txteWED.Text.Trim
                .sTHU = txtsTHU.Text.Trim
                .eTHU = txteTHU.Text.Trim
                .sFRI = txtsFRI.Text.Trim
                .eFRI = txteFRI.Text.Trim
                .sSAT = txtsSAT.Text.Trim
                .eSAT = txteSAT.Text.Trim
                .sSUN = txtsSUN.Text.Trim
                .eSUN = txteSUN.Text.Trim
                .UpdateInsertPhysicianSchedule()
            End With
            oPS.Dispose()
            oPS = Nothing
        End Sub

        Private Sub btnSavePraktek_Click(sender As Object, e As System.EventArgs) Handles btnSavePraktek.Click
            Dim oPS As New Common.BussinessRules.Utility
            With oPS
                .PhysicianID = ddlPhysician.SelectedItem.Value.Trim
                .IsAvailable = CType(rbtnIsAvailable.SelectedValue.Trim, Boolean)
                .UpdatePhysicianIsAvailable()
            End With
            oPS.Dispose()
            oPS = Nothing
        End Sub

        Private Sub btnSaveScrollingText_Click(sender As Object, e As System.EventArgs) Handles btnSaveScrollingText.Click
            Dim oPS As New Common.BussinessRules.Utility
            With oPS
                .ScrollingText = txtScrollingText.Text.Trim
                .UpdateScrollingText()
            End With
            oPS.Dispose()
            oPS = Nothing
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

        Private Sub initScreen()
            lblPageTitle.Text = "INFORMASI JADWAL PRAKTEK DOKTER HARI INI"
            pnlSummary.Visible = True
            pnlDetail.Visible = False
            pnlEdit.Visible = False

            commonFunction.SetDDL_Table(ddlPhysician, "Physician", String.Empty, True, "-- PILIH DOKTER --")
            commonFunction.SetDDL_Table(ddlClinic, "ClinicByPhysician", ddlPhysician.SelectedItem.Value.Trim, True, "-- PILIH KLINIK --")
            commonFunction.SetDDL_Table(ddlShift, "Shift", String.Empty, True, "-- PILIH SHIFT --")
            txtsMON.Text = "--:--"
            txteMON.Text = "--:--"
            txtsTUE.Text = "--:--"
            txteTUE.Text = "--:--"
            txtsWED.Text = "--:--"
            txteWED.Text = "--:--"
            txtsTHU.Text = "--:--"
            txteTHU.Text = "--:--"
            txtsFRI.Text = "--:--"
            txteFRI.Text = "--:--"
            txtsSAT.Text = "--:--"
            txteSAT.Text = "--:--"
            txtsSUN.Text = "--:--"
            txteSUN.Text = "--:--"
            rbtnIsAvailable.SelectedIndex = 0
        End Sub

        Private Function GetSpecialty() As DataTable
            Dim oSpecialty As New Common.BussinessRules.Utility
            repSpecialty.DataSource = oSpecialty.GetPhysicianSpecialtyListForWebDisplay
            repSpecialty.DataBind()

            repSpecialtySum.DataSource = oSpecialty.GetPhysicianSpecialtyListForWebDisplay
            repSpecialtySum.DataBind()

            oSpecialty.Dispose()
            oSpecialty = Nothing
        End Function

        Private Function GetPhysicianBySpecialty(ByVal SpecialtyID As String) As DataTable
            Dim dt As DataTable
            Dim oPhysician As New Common.BussinessRules.Utility
            oPhysician.SpecialtyID = SpecialtyID.Trim
            dt = oPhysician.GetPhysicianBySpecialtyListForWebDisplay()
            oPhysician.Dispose()
            oPhysician = Nothing
            Return dt
        End Function

        Private Function GetPhysicianSchedule(ByVal PhysicianID As String, ByVal ScheduleDay As String) As DataTable
            Dim dt As DataTable
            Dim oSchedule As New Common.BussinessRules.Utility
            oSchedule.PhysicianID = PhysicianID.Trim
            oSchedule.ScheduleDay = ScheduleDay.Trim
            dt = oSchedule.GetPhysicianScheduleInformationListForWebDisplay
            oSchedule.Dispose()
            oSchedule = Nothing
            Return dt
        End Function
#End Region

#Region " C,R,U,D "
        Private Sub OpenPhysicianSchedule()
            Dim oPS As New Common.BussinessRules.Utility
            With oPS
                .PhysicianID = ddlPhysician.SelectedItem.Value.Trim
                .ClinicID = ddlClinic.SelectedItem.Value.Trim
                .ShiftID = ddlShift.SelectedItem.Value.Trim
                If .GetPhysicianSchedule.Rows.Count > 0 Then
                    txtsMON.Text = .sMON.Trim
                    txteMON.Text = .eMON.Trim
                    txtsTUE.Text = .sTUE.Trim
                    txteTUE.Text = .eTUE.Trim
                    txtsWED.Text = .sWED.Trim
                    txteWED.Text = .eWED.Trim
                    txtsTHU.Text = .sTHU.Trim
                    txteTHU.Text = .eTHU.Trim
                    txtsFRI.Text = .sFRI.Trim
                    txteFRI.Text = .eFRI.Trim
                    txtsSAT.Text = .sSAT.Trim
                    txteSAT.Text = .eSAT.Trim
                    txtsSUN.Text = .sSUN.Trim
                    txteSUN.Text = .eSUN.Trim
                    If .IsAvailable Then
                        rbtnIsAvailable.SelectedValue = "True"
                    Else
                        rbtnIsAvailable.SelectedValue = "False"
                    End If
                Else
                    txtsMON.Text = "--:--"
                    txteMON.Text = "--:--"
                    txtsTUE.Text = "--:--"
                    txteTUE.Text = "--:--"
                    txtsWED.Text = "--:--"
                    txteWED.Text = "--:--"
                    txtsTHU.Text = "--:--"
                    txteTHU.Text = "--:--"
                    txtsFRI.Text = "--:--"
                    txteFRI.Text = "--:--"
                    txtsSAT.Text = "--:--"
                    txteSAT.Text = "--:--"
                    txtsSUN.Text = "--:--"
                    txteSUN.Text = "--:--"
                    rbtnIsAvailable.SelectedIndex = 0
                End If
            End With
            oPS.Dispose()
            oPS = Nothing
        End Sub

        Private Sub OpenPhysicianIsAvailable()
            Dim oPS As New Common.BussinessRules.Utility
            With oPS
                .PhysicianID = ddlPhysician.SelectedItem.Value.Trim
                If .GetPhysicianIsAvailable.Rows.Count > 0 Then
                    If .IsAvailable Then
                        rbtnIsAvailable.SelectedValue = "True"
                    Else
                        rbtnIsAvailable.SelectedValue = "False"
                    End If
                Else
                    rbtnIsAvailable.SelectedIndex = 0
                End If
            End With
            oPS.Dispose()
            oPS = Nothing
        End Sub

        Private Sub OpenScrollingText()
            Dim oSC As New Common.BussinessRules.Utility
            If oSC.GetScrollingText().Rows.Count > 0 Then
                lblScrollingText.Text = oSC.ScrollingText.Trim
                txtScrollingText.Text = oSC.ScrollingText.Trim
            Else
                lblScrollingText.Text = lblCompanyName.Text.Trim
                txtScrollingText.Text = String.Empty
            End If
            oSC.Dispose()
            oSC = Nothing
        End Sub
#End Region

    End Class

End Namespace