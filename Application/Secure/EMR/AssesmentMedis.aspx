<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../../incl/calendar.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AssesmentMedis.aspx.vb"
    Inherits="QIS.Web.EMR.AssesmentMedis" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>EMR - Assesment Medis</title>
    <link rel="title icon" href="/qistoollib/images/favicon.png" />
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href="/qistoollib/css/styles_blue.css" type="text/css" rel="Stylesheet" />
    <script language="javascript" type="text/javascript" src="/qistoollib/scripts/JScript.js"></script>
    <style type="text/css">
        #ulRepProjects
        {
            width: 100%;
            margin: 0;
            padding: 0;                     
        }
        #ulRepProjects li
        {
            list-style-type: none;
            display: inline-block; /* FF3.6; Chrome10+ */                     
            *display: inline;
            background: #eeeeee;
            width: 280px;
            height: 150px;
            margin: 5px;
        }
        #ulRepProjectGroup
        {
            width: 100%;
            margin: 0;
            padding: 0;                     
        }
        #ulRepProjectGroup li
        {
            list-style-type: none;            
        }
        .img-patientImage
        {
            border-radius: 50%;
            background-color: #eeeeee;
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server">
    <table width="100%" cellpadding="2" cellspacing="0">
        <tr>
            <td width="100%" valign="top">
                <!-- BEGIN PAGE HEADER -->
                <Module:RadMenu ID="RadMenu" runat="server" />
                <!-- END PAGE HEADER -->
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td class="rheader">
                Asesmen Medis
                        </td>
                    </tr>
                    <tr>
                        <td class="hseparator" style="width: 100%;">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <asp:Panel ID="pnlDashboard" runat="server">
            <tr>
                <td width="100%" valign="top">
                    <table style="margin: 0 30 0 0;">
                        <tr>
                            <td>
                                <table width="200" cellpadding="10" cellspacing="0">
                                    <tr>
                                        <td rowspan="2" style="background-color: #CD1A57; color: #ffffff; width: 40; text-align: center;
                                            font-weight: bold;">
                                            <asp:Label ID="lblTotalPasienIGD" runat="server"></asp:Label>
                                        </td>
                                        <td style="background-color: #E91E63; color: #ffffff;">
                                            Pasien IGD
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <table width="200" cellpadding="10" cellspacing="0">
                                    <tr>
                                        <td rowspan="2" style="background-color: #00A5BA; color: #ffffff; width: 40; text-align: center;
                                            font-weight: bold;">
                                            <asp:Label ID="lblTotalPasienRawatJalan" runat="server"></asp:Label>
                                        </td>
                                        <td style="background-color: #00BCD4; color: #ffffff;">
                                            Pasien Rawat Jalan
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <table width="200" cellpadding="10" cellspacing="0">
                                    <tr>
                                        <td rowspan="2" style="background-color: #7AAB41; color: #ffffff; width: 40; text-align: center;
                                            font-weight: bold;">
                                            <asp:Label ID="lblTotalPasienRawatInap" runat="server"></asp:Label>
                                        </td>
                                        <td style="background-color: #8BC34A; color: #ffffff;">
                                            Pasien Rawat Inap
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td align="right">
                                <asp:LinkButton runat="server" ID="lbtnBackToPatientList" ToolTip="Kembali ke Daftar Pasien"
                                    CausesValidation="false" Width="48"><img src="/qistoollib/images/tbback.png" alt="" border="0" /></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </asp:Panel>
        <tr>
            <td width="100%" valign="top">
                <asp:TextBox ID="txtLinkParamedicID" runat="server" Visible="false"></asp:TextBox>
                <asp:CheckBox ID="chkIsPhysician" runat="server" Visible="false"></asp:CheckBox>
                <telerik:RadTabStrip RenderMode="Lightweight" ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1"
                    Skin="Windows7" SelectedIndex="0" AutoPostBack="true">
                    <Tabs>
                        <telerik:RadTab Text="Pasien Saya">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Perjanjian Saya" Visible="false">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage ID="RadMultiPage1" CssClass="RadMultiPage" runat="server" SelectedIndex="0">
                    <telerik:RadPageView ID="RadPageView1" runat="server">
                        <asp:Panel ID="pnlPatientList" runat="server">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <telerik:RadTabStrip RenderMode="Lightweight" ID="RadTabStrip2" runat="server" MultiPageID="RadMultiPage2"
                                            Skin="Windows7" SelectedIndex="0" AutoPostBack="true">
                                            <Tabs>
                                                <telerik:RadTab Text="Pasien Hari Ini">
                                                </telerik:RadTab>
                                                <telerik:RadTab Text="Data Rekam Medis">
                                                </telerik:RadTab>
                                            </Tabs>
                                        </telerik:RadTabStrip>
                                        <telerik:RadMultiPage ID="RadMultiPage2" CssClass="RadMultiPage" runat="server" SelectedIndex="0">
                                            <telerik:RadPageView ID="RadPageView3" runat="server">
                                                <table cellpadding="2" width="100%">
                                                    <tr>
                                                        <td class="right">
                                                             Tanggal
                                                        </td>
                                                        <td>
                                                            <Module:Calendar ID="calTgl" runat="server" DontResetDate="true"></Module:Calendar>
                                                        </td>
                                                         <td class="right">
                                                            Cari Pasien
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtSearchPatient" runat="server" Width="300"></asp:TextBox>
                                                            <asp:Button ID="btnSearchPatient" runat="server" Text="Cari" Width="100" />
                                                        </td>
                                                        <td class="right">
                                                            Departemen
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlDepartmentFilter" runat="server" Width="200" AutoPostBack="true">
                                                                <asp:ListItem Value="OUTPATIENT" Text="RAWAT JALAN"></asp:ListItem>
                                                                <asp:ListItem Value="EMERGENCY" Text="RAWAT DARURAT"></asp:ListItem>
                                                                <asp:ListItem Value="INPATIENT" Text="RAWAT INAP"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:DataGrid ID="grdTodayPatient" runat="server" BorderWidth="0" GridLines="None"
                                                                Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                AutoGenerateColumns="false">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                <ItemStyle CssClass="gridItemStyle" />
                                                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                <Columns>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Selesai" ItemStyle-Width="50" ItemStyle-VerticalAlign="top">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="_chkIsDischarged" Enabled="false" Checked='<%# DataBinder.Eval(Container.DataItem, "IsDischarged")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Jam" ItemStyle-Width="50" ItemStyle-VerticalAlign="top">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "RegistrationTime")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="No. Registrasi" ItemStyle-Width="120"
                                                                        ItemStyle-VerticalAlign="top">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RegistrationNo") %>'
                                                                                ID="_lbtnRegistrationNo" ForeColor="Blue" CommandName="GetRegistration" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="No. Transaksi" ItemStyle-Width="120"
                                                                        ItemStyle-VerticalAlign="top">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TransactionNo") %>'
                                                                                ID="_lblTransactionNo" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Nama Pasien" ItemStyle-VerticalAlign="top">
                                                                        <ItemTemplate>
                                                                            <table cellpadding="1" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <%# DataBinder.Eval(Container.DataItem, "PatientName")%>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="txtweak">
                                                                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PhysicianName") %>'
                                                                                            ID="_lblPhysicianName" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="No. MR" ItemStyle-Width="120" ItemStyle-VerticalAlign="top">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "MRN")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="L/P" ItemStyle-Width="50" ItemStyle-VerticalAlign="top">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "PatientGender")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Tgl. Lahir" ItemStyle-Width="80" ItemStyle-VerticalAlign="top">
                                                                        <ItemTemplate>
                                                                            <%# Format(DataBinder.Eval(Container.DataItem, "PatientDOB"), "dd-MMM-yyyy")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Unit Pelayanan" ItemStyle-VerticalAlign="top">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "ServiceUnitName")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Penjamin" ItemStyle-VerticalAlign="top">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "BusinessPartnerName")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                </Columns>
                                                            </asp:DataGrid>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="RadPageView4" runat="server">
                                                <table cellpadding="2" width="100%">
                                                    <tr>
                                                        <td class="right" style="width: 150;">
                                                            Nomor Rekam Medis
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtMedicalNoHistory" runat="server" Width="150"></asp:TextBox>
                                                            <asp:Button ID="btnShowHistory" runat="server" Text="Tampilkan" Width="100" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="projectbanner projectbanner_heading1" colspan="4">
                                                            <table width="100%" cellpadding="3" cellspacing="1">
                                                                <tr>
                                                                    <td rowspan="3" style="background: #eeeeee; width: 60;" class="center">
                                                                        <asp:Image ID="imgPBPatientHistory" runat="server" BorderStyle="None" Width="60" />
                                                                    </td>
                                                                    <td class="projectbanner_heading1">
                                                                        <asp:Label runat="server" ID="lblPBPatientNameHistory"></asp:Label>
                                                                        &nbsp;(<asp:Label runat="server" ID="lblPBPatientGenderHistory"></asp:Label>)
                                                                    </td>
                                                                    <td class="projectbanner">
                                                                        Alamat:
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="projectbanner_heading1">
                                                                        <asp:Label runat="server" ID="lblPBMRNHistory"></asp:Label>
                                                                    </td>
                                                                    <td class="projectbanner">
                                                                        <asp:Label runat="server" ID="lblPBAddressHistory"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="projectbanner">
                                                                        Tanggal Lahir: &nbsp;<asp:Label runat="server" ID="lblPBPatientDOBHistory" Font-Bold="true"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4">
                                                            <asp:DataGrid ID="grdPatientResumeHistoryMR" runat="server" BorderWidth="0" GridLines="None"
                                                                Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                AutoGenerateColumns="false">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                <ItemStyle CssClass="gridItemStyle" />
                                                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                <Columns>
                                                                    <asp:TemplateColumn runat="server" HeaderText="" ItemStyle-Width="30" ItemStyle-VerticalAlign="Top">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblID" Text='<%# DataBinder.Eval(Container.DataItem, "ID")%>'
                                                                                Visible="false"></asp:Label>
                                                                            <asp:ImageButton runat="server" ID="_ibtnEdit" ImageUrl="/qistoollib/images/edit.png"
                                                                                CommandName="Revise" ToolTip="Revisi" Visible='<%# NOT DataBinder.Eval(Container.DataItem, "IsRevised")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Informasi Kunjungan" ItemStyle-Width="250"
                                                                        ItemStyle-VerticalAlign="Top">
                                                                        <ItemTemplate>
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td style="width: 50px;" valign="top">
                                                                                        Tanggal
                                                                                    </td>
                                                                                    <td valign="top">
                                                                                        :&nbsp;<%# Format(DataBinder.Eval(Container.DataItem, "CreatedDate"), "dd-MMM-yyyy hh:mm")%>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 50px;" valign="top">
                                                                                        Unit
                                                                                    </td>
                                                                                    <td valign="top">
                                                                                        :&nbsp;<%# DataBinder.Eval(Container.DataItem, "ServiceUnitName")%>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 50px;" valign="top">
                                                                                        Dokter
                                                                                    </td>
                                                                                    <td valign="top">
                                                                                        :&nbsp;<%# DataBinder.Eval(Container.DataItem, "PhysicianName")%>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 50px;" valign="top">
                                                                                        Asesmen
                                                                                    </td>
                                                                                    <td valign="top">
                                                                                        :&nbsp;<b><%# DataBinder.Eval(Container.DataItem, "AssessmentTypeName")%></b>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" valign="top">
                                                                                        <asp:Panel runat="server" ID="_pnlRevised" Visible='<%# DataBinder.Eval(Container.DataItem, "IsRevised")%>'>
                                                                                            <table cellpadding="2" cellspacing="1" style="background-color: Red;">
                                                                                                <tr>
                                                                                                    <td style="color: White;">
                                                                                                        REVISED
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="txtweak" style="background-color: White;">
                                                                                                        on
                                                                                                        <%# Format(DataBinder.Eval(Container.DataItem, "LastUpdatedDate"), "dd-MMM-yyyy hh:mm")%><br />
                                                                                                        by
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "LastUpdatedByUserName")%>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </asp:Panel>
                                                                                        <asp:Panel runat="server" ID="_pnlCreated" Visible='<%# NOT DataBinder.Eval(Container.DataItem, "IsRevised")%>'>
                                                                                            <table cellpadding="2" cellspacing="1" style="background-color: Olive;">
                                                                                                <tr>
                                                                                                    <td style="color: White;">
                                                                                                        CREATED
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="txtweak" style="background-color: White;">
                                                                                                        on
                                                                                                        <%# Format(DataBinder.Eval(Container.DataItem, "CreatedDate"), "dd-MMM-yyyy hh:mm")%><br />
                                                                                                        by
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "CreatedByUserName")%>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </asp:Panel>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Subjective" ItemStyle-VerticalAlign="Top"
                                                                        ItemStyle-Width="250">
                                                                        <ItemTemplate>
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td>
                                                                                        Anamnesis:<br />
                                                                                        <asp:TextBox ID="_txtChiefComplaintText" runat="server" TextMode="MultiLine" Font-Names="Segoe-UI,Arial"
                                                                                            Width="100%" Height="100" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "ChiefComplaint")%>'></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <br />
                                                                                        Riwayat Kesehatan:<br />
                                                                                        <asp:TextBox ID="_txtHistoryOfPresentIllnessText" runat="server" TextMode="MultiLine"
                                                                                            Font-Names="Segoe-UI,Arial" Width="100%" Height="100" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "HistoryOfPresentIllness")%>'></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Diagnosa" ItemStyle-VerticalAlign="Top"
                                                                        ItemStyle-Width="250">
                                                                        <ItemTemplate>
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td>
                                                                                        Diagnosa Utama:<br />
                                                                                        <asp:TextBox ID="_txtMainDiagnosisText" runat="server" TextMode="MultiLine" Font-Names="Segoe-UI,Arial"
                                                                                            Width="100%" Height="100" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "MainDiagnosisText")%>'></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <br />
                                                                                        Diagnosa Sekunder:<br />
                                                                                        <asp:TextBox ID="_txtSecondaryDiagnosisText" runat="server" TextMode="MultiLine"
                                                                                            Font-Names="Segoe-UI,Arial" Width="100%" Height="100" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "SecondaryDiagnosisText")%>'></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Prosedur" ItemStyle-VerticalAlign="Top"
                                                                        ItemStyle-Width="300">
                                                                        <ItemTemplate>
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td>
                                                                                        Prosedur:<br />
                                                                                        <asp:TextBox ID="_txtProcedureText" runat="server" TextMode="MultiLine" Font-Names="Segoe-UI,Arial"
                                                                                            Width="100%" Height="100" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "ProcedureText")%>'></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Terapi" ItemStyle-VerticalAlign="Top"
                                                                        ItemStyle-Width="350">
                                                                        <ItemTemplate>
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td>
                                                                                        Terapi:<br />
                                                                                        <asp:TextBox ID="_txtTherapyText" runat="server" TextMode="MultiLine" Font-Names="Segoe-UI,Arial"
                                                                                            Font-Size="Small" Width="100%" Height="194" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "TherapyText")%>'></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="_lblTherapyHISOrderNo" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "TherapyHISOrderNo")%>'></asp:Label>
                                                                                        <asp:Panel runat="server" ID="_pnlOrder" Visible='<%# DataBinder.Eval(Container.DataItem, "TherapyHISOrderNo") <> "" and DataBinder.Eval(Container.DataItem, "TherapyHISOrderStatus") = "Order" %>'>
                                                                                            <table cellpadding="2" cellspacing="1" style="background-color: #2e86c1;" width="100%">
                                                                                                <tr>
                                                                                                    <td style="color: White;">
                                                                                                        Order#:
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "TherapyHISOrderNo")%>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="txtweak" style="background-color: White;">
                                                                                                        Status:
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "TherapyHISOrderStatus")%>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </asp:Panel>
                                                                                        <asp:Panel runat="server" ID="_pnlCancel" Visible='<%# DataBinder.Eval(Container.DataItem, "TherapyHISOrderNo") <> "" and DataBinder.Eval(Container.DataItem, "TherapyHISOrderStatus") = "Batal" %>'>
                                                                                            <table cellpadding="2" cellspacing="1" style="background-color: Red;" width="100%">
                                                                                                <tr>
                                                                                                    <td style="color: White;">
                                                                                                        Order#:
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "TherapyHISOrderNo")%>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="txtweak" style="background-color: White;">
                                                                                                        Status:
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "TherapyHISOrderStatus")%>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </asp:Panel>
                                                                                        <asp:Panel runat="server" ID="_pnlRealisasi" Visible='<%# DataBinder.Eval(Container.DataItem, "TherapyHISOrderNo") <> "" and DataBinder.Eval(Container.DataItem, "TherapyHISOrderStatus") = "Realisasi" %>'>
                                                                                            <table cellpadding="2" cellspacing="1" style="background-color: Olive;" width="100%">
                                                                                                <tr>
                                                                                                    <td style="color: White;">
                                                                                                        Order#:
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "TherapyHISOrderNo")%>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="txtweak" style="background-color: White;">
                                                                                                        Status:
                                                                                                        <asp:Label runat="server" ID="_lblTherapyHISOrderStatus" Text='<%# DataBinder.Eval(Container.DataItem, "TherapyHISOrderStatus")%>'></asp:Label><br />
                                                                                                        on
                                                                                                        <%# Format(DataBinder.Eval(Container.DataItem, "TherapyHISOrderStatusUpdatedDate"), "dd-MMM-yyyy hh:mm")%><br />
                                                                                                        by
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "TherapyHISOrderStatusUpdatedBy")%>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </asp:Panel>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Tgl. Penghentian Pengobatan" ItemStyle-VerticalAlign="Top">
                                                                        <ItemTemplate>
                                                                            <pre><%# DataBinder.Eval(Container.DataItem, "TherapyStopDate")%></pre>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Keterangan" ItemStyle-Width="200"
                                                                        ItemStyle-VerticalAlign="Top">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "Notes")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                </Columns>
                                                            </asp:DataGrid>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                        </telerik:RadMultiPage>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="pnlPatientRecord" runat="server">
                            <table cellpadding="0" width="100%">
                                <tr>
                                    <td class="projectbanner projectbanner_heading1">
                                        <table width="100%" cellpadding="1" cellspacing="1">
                                            <tr>
                                                <td rowspan="3" style="width: 80; background-color: #eeeeee;" class="center">
                                                    <asp:Image ID="imgPBPatient" runat="server" BorderStyle="None" Width="60" />
                                                </td>
                                                <td class="projectbanner_heading1 right">
                                                    Pasien:
                                                </td>
                                                <td class="projectbanner_heading1">
                                                    <asp:Label runat="server" ID="lblPBPatientName"></asp:Label>
                                                    &nbsp;(<asp:Label runat="server" ID="lblPBPatientGender"></asp:Label>)
                                                </td>
                                                <td class="projectbanner right">
                                                    Tanggal & Jam Daftar:
                                                </td>
                                                <td class="projectbanner">
                                                    <asp:Label runat="server" ID="lblPBRegistrationDate" Font-Bold="true"></asp:Label>
                                                    &nbsp;<asp:Label runat="server" ID="lblPBRegistrationTime" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td class="projectbanner right">
                                                    Departemen:
                                                </td>
                                                <td class="projectbanner">
                                                    <asp:Label runat="server" ID="lblPBDepartmentName" Font-Bold="true"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="projectbanner_heading1 right">
                                                    Reg#|RM#:
                                                </td>
                                                <td class="projectbanner_heading1">
                                                    <asp:Label runat="server" ID="lblPBRegistrationNo"></asp:Label>
                                                    |&nbsp;<asp:Label runat="server" ID="lblPBMRN"></asp:Label>
                                                </td>
                                                <td class="projectbanner right">
                                                    Tanggal Lahir:
                                                </td>
                                                <td class="projectbanner">
                                                    <asp:Label runat="server" ID="lblPBPatientDOB" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td class="projectbanner right">
                                                    Unit:
                                                </td>
                                                <td class="projectbanner">
                                                    <asp:Label runat="server" ID="lblPBServiceUnitName" Font-Bold="true"></asp:Label>
                                                    <asp:Label runat="server" ID="lblPBServiceUnitID" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="projectbanner_heading1 right">
                                                    Txn#:
                                                </td>
                                                <td class="projectbanner_heading1">
                                                    <asp:Label runat="server" ID="lblPBTransactionNo"></asp:Label>
                                                </td>
                                                <td class="projectbanner right">
                                                    Dokter:
                                                </td>
                                                <td class="projectbanner">
                                                    <asp:Label runat="server" ID="lblPBPhysicianName" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td class="projectbanner right">
                                                    Penjamin:
                                                </td>
                                                <td class="projectbanner">
                                                    <asp:Label runat="server" ID="lblPBBusinessPartnerName" Font-Bold="true"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <telerik:RadTabStrip RenderMode="Lightweight" ID="RadTabStrip3" runat="server" MultiPageID="RadMultiPage3"
                                            Skin="Windows7" SelectedIndex="0" AutoPostBack="true">
                                            <Tabs>
                                                <telerik:RadTab Text="Resume Medis Pasien">
                                                </telerik:RadTab>
                                                <telerik:RadTab Text="Riwayat Resume Medis Pasien">
                                                </telerik:RadTab>
                                                <telerik:RadTab Text="Dokumen Pasien">
                                                </telerik:RadTab>
                                                <telerik:RadTab Text="Tindakan & Evaluasi">
                                                </telerik:RadTab>
                                                <telerik:RadTab Text="CPPT">
                                                </telerik:RadTab>
                                            </Tabs>
                                        </telerik:RadTabStrip>
                                        <telerik:RadMultiPage ID="RadMultiPage3" CssClass="RadMultiPage" runat="server" SelectedIndex="0">
                                            <telerik:RadPageView ID="RadPageView5" runat="server">
                                                <asp:Panel ID="pnlPatientResume" runat="server">
                                                    <table class="ToolbarM" cellpadding="1" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td class="left padding-LR-5">
                                                                <asp:LinkButton runat="server" ID="lbtnNewSOAP" ToolTip="Tambah" CausesValidation="false"
                                                                    Width="48"><img src="/qistoollib/images/tbnew.png" alt="" border="0" /></asp:LinkButton>
                                                                <asp:LinkButton runat="server" ID="lbtnSaveSOAP" ToolTip="Simpan" CausesValidation="false"
                                                                    Width="48"><img src="/qistoollib/images/tbsave.png" alt="" border="0" /></asp:LinkButton>
                                                                <asp:LinkButton runat="server" ID="lbtnDischarge" ToolTip="Simpan dan Selesai Pelayanan"
                                                                    CausesValidation="false" Width="48"><img src="/qistoollib/images/tbdone.png" alt="" border="0" /></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="hseparator" style="width: 100%;">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="2" width="100%">
                                                        <tr>
                                                            <td style="width: 50%" class="Heading2" colspan="3">
                                                                Tipe Asesmen
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 50%" colspan="2">
                                                                <asp:DropDownList ID="ddlAssessmentType" runat="server" Width="200">
                                                                </asp:DropDownList>
                                                                <asp:TextBox ID="txtPatientResumeID" runat="server" Visible="false"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 50%">
                                                                <asp:CheckBox ID="chkIsDischarged" runat="server" Text="Selesai Pelayanan" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="hseparator" style="width: 100%;" colspan="3">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td rowspan="2" style="width: 30px; background-color: #2e86c1; color: #ffffff; text-align: center;
                                                                font-size: 16pt; font-weight: bold;">
                                                                S
                                                            </td>
                                                            <td style="width: 50%" class="Heading2">
                                                                Anamnesis (Keluhan Utama)
                                                            </td>
                                                            <td style="width: 50%" class="Heading2">
                                                                Riwayat Kesehatan
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 50%">
                                                                <asp:TextBox ID="txtChiefComplaint" runat="server" TextMode="MultiLine" Font-Names="Segoe-UI,Arial"
                                                                    Width="100%" Height="50"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 50%">
                                                                <asp:TextBox ID="txtHistoryOfPresentIllness" runat="server" TextMode="MultiLine"
                                                                    Font-Names="Segoe-UI,Arial" Width="100%" Height="50"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="hseparator" style="width: 100%;" colspan="3">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td rowspan="2" style="width: 30px; background-color: #2e86c1; color: #ffffff; text-align: center;
                                                                font-size: 16pt; font-weight: bold;">
                                                                O
                                                            </td>
                                                            <td style="width: 50%" class="Heading2">
                                                                Pemeriksaan Fisik dan Tanda Vital
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 50%">
                                                                <asp:TextBox ID="txtObjectiveText" runat="server" TextMode="MultiLine" Font-Names="Segoe-UI,Arial"
                                                                    Width="100%" Height="50"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="hseparator" style="width: 100%;" colspan="3">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td rowspan="5" style="width: 30px; background-color: #2e86c1; color: #ffffff; text-align: center;
                                                                font-size: 16pt; font-weight: bold;">
                                                                A
                                                            </td>
                                                            <td style="width: 50%" class="Heading2">
                                                                Diagnosa Utama
                                                            </td>
                                                            <td style="width: 50%" class="Heading2">
                                                                Diagnosa Sekunder
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 50%">
                                                                <asp:TextBox ID="txtID" runat="server" Visible="false"></asp:TextBox>
                                                                <asp:TextBox ID="txtMainDiagnosisText" runat="server" TextMode="MultiLine" Font-Names="Segoe-UI,Arial"
                                                                    Width="100%" Height="50"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 50%">
                                                                <asp:TextBox ID="txtSecondaryDiagnosisText" runat="server" TextMode="MultiLine" Font-Names="Segoe-UI,Arial"
                                                                    Width="100%" Height="50"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="Heading1" valign="top">
                                                                Prosedur
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtProcedureText" runat="server" TextMode="MultiLine" Font-Names="Segoe-UI,Arial"
                                                                    Width="100%" Height="50"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="hseparator" style="width: 100%;" colspan="3">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td rowspan="4" style="width: 30px; background-color: #2e86c1; color: #ffffff; text-align: center;
                                                                font-size: 16pt; font-weight: bold;">
                                                                P
                                                            </td>
                                                            <td class="Heading1" valign="top">
                                                                <table width="100%" class="Heading1">
                                                                    <tr>
                                                                        <td style="width: 20%;">
                                                                            Terapi
                                                                        </td>
                                                                        <td style="width: 80%;" class="right">
                                                                            <asp:CheckBox ID="chkIsCreateOrder" runat="server" Text="Kirim Order Resep ke Farmasi" />
                                                                            &nbsp;<asp:CheckBox ID="chkIsRealized" runat="server" Text="Realisasi" Enabled="false" />
                                                                            &nbsp;#<asp:Label ID="lblTherapyHISOrderNo" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td class="Heading1" valign="top">
                                                                <table width="100%" class="Heading1">
                                                                    <tr>
                                                                        <td style="width: 20%;">
                                                                            Sasaran Terukur
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                <asp:TextBox ID="txtTherapyText" runat="server" TextMode="MultiLine" Font-Names="Segoe-UI,Arial"
                                                                    Width="100%" Height="50"></asp:TextBox>
                                                            </td>
                                                            <td valign="top">
                                                                <asp:TextBox ID="txtMeasurableTargetText" runat="server" TextMode="MultiLine" Font-Names="Segoe-UI,Arial"
                                                                    Width="100%" Height="50"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                <table>
                                                                    <tr>
                                                                        <td style="width: 200px;">
                                                                            Tanggal Penghentian Pengobatan
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtTherapyStopDate" runat="server" Width="150"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                <table>
                                                                    <tr>
                                                                        <td style="width: 200px;">
                                                                            Order Penunjang Medis
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="btnDiagnosticSupportOrder" runat="server" CssClass="sbttn" Width="150"
                                                                                Text="Order Pemeriksaan"></asp:Button>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="hseparator" style="width: 100%;" colspan="3">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="Heading1" valign="top" colspan="3">
                                                                Keterangan
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" Font-Names="Segoe-UI,Arial"
                                                                    Width="100%" Height="50"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="hseparator" style="width: 100%;" colspan="3">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="Heading1" valign="top" colspan="2">
                                                                Catatan S-O-A-P
                                                            </td>
                                                            <td class="Heading1" valign="top">
                                                                <asp:Button ID="btnGenerateSOAPNotes" runat="server" Text="Generate" Width="100" />
                                                                <asp:Button ID="btnUpdateSOAPNotes" runat="server" Text="Update S-O-A-P" Width="150" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                <asp:TextBox ID="txtSOAPNotes" runat="server" TextMode="MultiLine" Font-Names="Segoe-UI,Arial"
                                                                    Width="100%" Height="100"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="hseparator" style="width: 100%;" colspan="3">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="2" width="100%">
                                                        <tr>
                                                            <td>
                                                                <asp:DataGrid ID="grdPatientResume" runat="server" BorderWidth="0" GridLines="None"
                                                                    Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                    AutoGenerateColumns="false">
                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                    <ItemStyle CssClass="gridItemStyle" />
                                                                    <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                    <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                    <Columns>
                                                                        <asp:TemplateColumn runat="server" HeaderText="" ItemStyle-Width="30" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="_lblID" Text='<%# DataBinder.Eval(Container.DataItem, "ID")%>'
                                                                                    Visible="false"></asp:Label>
                                                                                <asp:ImageButton runat="server" ID="_ibtnEdit" ImageUrl="/qistoollib/images/edit.png"
                                                                                    CommandName="Revise" ToolTip="Revisi" Visible='<%# NOT DataBinder.Eval(Container.DataItem, "IsRevised")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Informasi Kunjungan" ItemStyle-Width="250"
                                                                            ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td style="width: 50px;" valign="top">
                                                                                            Tanggal
                                                                                        </td>
                                                                                        <td valign="top">
                                                                                            :&nbsp;<%# Format(DataBinder.Eval(Container.DataItem, "CreatedDate"), "dd-MMM-yyyy hh:mm")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 50px;" valign="top">
                                                                                            Unit
                                                                                        </td>
                                                                                        <td valign="top">
                                                                                            :&nbsp;<%# DataBinder.Eval(Container.DataItem, "ServiceUnitName")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 50px;" valign="top">
                                                                                            Dokter
                                                                                        </td>
                                                                                        <td valign="top">
                                                                                            :&nbsp;<%# DataBinder.Eval(Container.DataItem, "PhysicianName")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 50px;" valign="top">
                                                                                            Asesmen
                                                                                        </td>
                                                                                        <td valign="top">
                                                                                            :&nbsp;<b><%# DataBinder.Eval(Container.DataItem, "AssessmentTypeName")%></b>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 50px;" valign="top">
                                                                                            S-O-A-P
                                                                                        </td>
                                                                                        <td valign="top">
                                                                                            :&nbsp;<asp:CheckBox ID="_chkIsSOAPNotes" runat="server" Enabled="false" Checked='<%# DataBinder.Eval(Container.DataItem, "IsSOAPNotes")%>' />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" valign="top">
                                                                                            <asp:Panel runat="server" ID="_pnlRevised" Visible='<%# DataBinder.Eval(Container.DataItem, "IsRevised")%>'>
                                                                                                <table cellpadding="2" cellspacing="1" style="background-color: Red;">
                                                                                                    <tr>
                                                                                                        <td style="color: White;">
                                                                                                            REVISED
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td class="txtweak" style="background-color: White;">
                                                                                                            on
                                                                                                            <%# Format(DataBinder.Eval(Container.DataItem, "LastUpdatedDate"), "dd-MMM-yyyy hh:mm")%><br />
                                                                                                            by
                                                                                                            <%# DataBinder.Eval(Container.DataItem, "LastUpdatedByUserName")%>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </asp:Panel>
                                                                                            <asp:Panel runat="server" ID="_pnlCreated" Visible='<%# NOT DataBinder.Eval(Container.DataItem, "IsRevised")%>'>
                                                                                                <table cellpadding="2" cellspacing="1" style="background-color: Olive;">
                                                                                                    <tr>
                                                                                                        <td style="color: White;">
                                                                                                            CREATED
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td class="txtweak" style="background-color: White;">
                                                                                                            on
                                                                                                            <%# Format(DataBinder.Eval(Container.DataItem, "CreatedDate"), "dd-MMM-yyyy hh:mm")%><br />
                                                                                                            by
                                                                                                            <%# DataBinder.Eval(Container.DataItem, "CreatedByUserName")%>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </asp:Panel>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Subjective" ItemStyle-VerticalAlign="Top"
                                                                            ItemStyle-Width="250">
                                                                            <ItemTemplate>
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td>
                                                                                            Anamnesis:<br />
                                                                                            <asp:TextBox ID="_txtChiefComplaintText" runat="server" TextMode="MultiLine" Font-Names="Segoe-UI,Arial"
                                                                                                Width="100%" Height="100" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "ChiefComplaint")%>'></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            Riwayat Kesehatan:<br />
                                                                                            <asp:TextBox ID="_txtHistoryOfPresentIllnessText" runat="server" TextMode="MultiLine"
                                                                                                Font-Names="Segoe-UI,Arial" Width="100%" Height="100" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "HistoryOfPresentIllness")%>'></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Objective" ItemStyle-VerticalAlign="Top"
                                                                            ItemStyle-Width="250">
                                                                            <ItemTemplate>
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td>
                                                                                            Pemeriksaan Fisik:<br />
                                                                                            <asp:TextBox ID="_txtObjectiveText" runat="server" TextMode="MultiLine" Font-Names="Segoe-UI,Arial"
                                                                                                Width="100%" Height="100" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "ObjectiveText")%>'></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Assessment" ItemStyle-VerticalAlign="Top"
                                                                            ItemStyle-Width="500">
                                                                            <ItemTemplate>
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td>
                                                                                            Diagnosa Utama:<br />
                                                                                            <asp:TextBox ID="_txtMainDiagnosisText" runat="server" TextMode="MultiLine" Font-Names="Segoe-UI,Arial"
                                                                                                Width="100%" Height="100" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "MainDiagnosisText")%>'></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            Prosedur:<br />
                                                                                            <asp:TextBox ID="_txtProcedureText" runat="server" TextMode="MultiLine" Font-Names="Segoe-UI,Arial"
                                                                                                Width="100%" Height="100" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "ProcedureText")%>'></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            Diagnosa Sekunder:<br />
                                                                                            <asp:TextBox ID="_txtSecondaryDiagnosisText" runat="server" TextMode="MultiLine"
                                                                                                Font-Names="Segoe-UI,Arial" Width="100%" Height="100" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "SecondaryDiagnosisText")%>'></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Planning" ItemStyle-VerticalAlign="Top"
                                                                            ItemStyle-Width="550">
                                                                            <ItemTemplate>
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td rowspan="2" valign="top">
                                                                                            Terapi:<br />
                                                                                            <asp:TextBox ID="_txtTherapyText" runat="server" TextMode="MultiLine" Font-Names="Segoe-UI,Arial"
                                                                                                Font-Size="Small" Width="100%" Height="224" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "TherapyText")%>'></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            Sasaran Terukur:<br />
                                                                                            <asp:TextBox ID="_txtMeasurableTargetText" runat="server" TextMode="MultiLine" Font-Names="Segoe-UI,Arial"
                                                                                                Width="100%" Height="100" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "MeasurableTargetText")%>'></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            Keterangan:<br />
                                                                                            <asp:TextBox ID="_txtKeterangan" runat="server" TextMode="MultiLine" Font-Names="Segoe-UI,Arial"
                                                                                                Width="100%" Height="100" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "Notes")%>'></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td valign="top">
                                                                                            <asp:Label runat="server" ID="_lblTherapyHISOrderNo" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "TherapyHISOrderNo")%>'></asp:Label>
                                                                                            <asp:Panel runat="server" ID="_pnlOrder" Visible='<%# DataBinder.Eval(Container.DataItem, "TherapyHISOrderNo") <> "" and DataBinder.Eval(Container.DataItem, "TherapyHISOrderStatus") = "Order" %>'>
                                                                                                <table cellpadding="2" cellspacing="1" style="background-color: #2e86c1;" width="100%">
                                                                                                    <tr>
                                                                                                        <td style="color: White;">
                                                                                                            Order#:
                                                                                                            <%# DataBinder.Eval(Container.DataItem, "TherapyHISOrderNo")%>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td class="txtweak" style="background-color: White;">
                                                                                                            Status:
                                                                                                            <%# DataBinder.Eval(Container.DataItem, "TherapyHISOrderStatus")%>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </asp:Panel>
                                                                                            <asp:Panel runat="server" ID="_pnlCancel" Visible='<%# DataBinder.Eval(Container.DataItem, "TherapyHISOrderNo") <> "" and DataBinder.Eval(Container.DataItem, "TherapyHISOrderStatus") = "Batal" %>'>
                                                                                                <table cellpadding="2" cellspacing="1" style="background-color: Red;" width="100%">
                                                                                                    <tr>
                                                                                                        <td style="color: White;">
                                                                                                            Order#:
                                                                                                            <%# DataBinder.Eval(Container.DataItem, "TherapyHISOrderNo")%>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td class="txtweak" style="background-color: White;">
                                                                                                            Status:
                                                                                                            <%# DataBinder.Eval(Container.DataItem, "TherapyHISOrderStatus")%>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </asp:Panel>
                                                                                            <asp:Panel runat="server" ID="_pnlRealisasi" Visible='<%# DataBinder.Eval(Container.DataItem, "TherapyHISOrderNo") <> "" and DataBinder.Eval(Container.DataItem, "TherapyHISOrderStatus") = "Realisasi" %>'>
                                                                                                <table cellpadding="2" cellspacing="1" style="background-color: Olive;" width="100%">
                                                                                                    <tr>
                                                                                                        <td style="color: White;">
                                                                                                            Order#:
                                                                                                            <%# DataBinder.Eval(Container.DataItem, "TherapyHISOrderNo")%>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td class="txtweak" style="background-color: White;">
                                                                                                            Status:
                                                                                                            <asp:Label runat="server" ID="_lblTherapyHISOrderStatus" Text='<%# DataBinder.Eval(Container.DataItem, "TherapyHISOrderStatus")%>'></asp:Label><br />
                                                                                                            on
                                                                                                            <%# Format(DataBinder.Eval(Container.DataItem, "TherapyHISOrderStatusUpdatedDate"), "dd-MMM-yyyy hh:mm")%><br />
                                                                                                            by
                                                                                                            <%# DataBinder.Eval(Container.DataItem, "TherapyHISOrderStatusUpdatedBy")%>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </asp:Panel>
                                                                                        </td>
                                                                                        <td valign="top" rowspan="2">
                                                                                            <asp:DataGrid ID="_grdJobOrderList" runat="server" BorderWidth="0" GridLines="None"
                                                                                                Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                                                AutoGenerateColumns="false">
                                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                                                <ItemStyle CssClass="gridItemStyle" />
                                                                                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                                                <Columns>
                                                                                                    <asp:TemplateColumn runat="server" HeaderText="Order Pemeriksaan">
                                                                                                        <ItemTemplate>
                                                                                                            <%# DataBinder.Eval(Container.DataItem, "DiagnosticSupportUnitName")%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateColumn>
                                                                                                    <asp:TemplateColumn runat="server" HeaderText="Qty">
                                                                                                        <ItemTemplate>
                                                                                                            <%# DataBinder.Eval(Container.DataItem, "JobOrderQty")%>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateColumn>
                                                                                                </Columns>
                                                                                            </asp:DataGrid>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            Tgl. Penghentian:<br />
                                                                                            <%# DataBinder.Eval(Container.DataItem, "TherapyStopDate")%>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </Columns>
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlJobOrderEntry" runat="server">
                                                    <table class="ToolbarM" cellpadding="1" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td class="left padding-LR-5">
                                                                <asp:LinkButton runat="server" ID="lbtnOrderNew" ToolTip="Tambah Order" CausesValidation="false"
                                                                    Width="48"><img src="/qistoollib/images/tbnew.png" alt="" border="0" /></asp:LinkButton>
                                                                <asp:LinkButton runat="server" ID="lbtnOrderDone" ToolTip="Selesai Order dan kembali ke Resume Medis Pasien"
                                                                    CausesValidation="false" Width="48"><img src="/qistoollib/images/tbdone.png" alt="" border="0" /></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="hseparator" style="width: 100%;">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table cellpadding="2" width="100%">
                                                        <tr>
                                                            <td style="width: 100%" class="Heading2" colspan="3">
                                                                Order Penunjang Medis
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="hseparator" style="width: 100%;" colspan="3">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 200;" valign="top">
                                                                <table>
                                                                    <tr>
                                                                        <td valign="top" style="width: 40%;" class="rheadercol">
                                                                            Daftar Order Pemeriksaan
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <asp:DataGrid ID="grdJobOrderList" runat="server" BorderWidth="0" GridLines="None"
                                                                                Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                                AutoGenerateColumns="false">
                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                                <ItemStyle CssClass="gridItemStyle" />
                                                                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                                <Columns>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Job Order">
                                                                                        <ItemTemplate>
                                                                                            <table cellpadding="0" cellspacing="0">
                                                                                                <tr>
                                                                                                    <td>
                                                                                                       <asp:LinkButton runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "JobOrderNo") %>'
                                                                                                            ID="_lbtnJobOrderNo" CommandName="SelectJobOrder" ForeColor="Blue"
                                                                                                            enabled='<%# iif(DataBinder.Eval(Container.DataItem, "DiagnosticSupportUnitName")="Farmasi", "False", "True") %>'>
                                                                                                        </asp:LinkButton>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "DiagnosticSupportUnitName")%>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "JobOrderDateTime")%>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:TemplateColumn runat="server" HeaderText="Status">
                                                                                        <ItemTemplate>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "StatusName")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                </Columns>
                                                                            </asp:DataGrid>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td valign="top" class="vseparator" style="height: 100%;">
                                                            </td>
                                                            <td valign="top">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td style="width: 100" class="right">
                                                                            Penunjang
                                                                        </td>
                                                                        <td style="width: 200">
                                                                            <asp:DropDownList ID="ddlDiagnosticSupportUnit" runat="server" Width="300" AutoPostBack="true">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td style="width: 100" class="right">
                                                                            Nomor Order
                                                                        </td>
                                                                        <td style="width: 200">
                                                                            <asp:TextBox ID="txtJobOrderNo" runat="server" Width="150" ReadOnly="true" CssClass="txtReadOnly"></asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 20%;">
                                                                            Status:&nbsp;<asp:Label ID="lblJobOrderStatus" runat="server"></asp:Label>                                                                            
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100" class="right">
                                                                            Catatan Klinis
                                                                        </td>
                                                                        <td style="width: 200">
                                                                            <asp:TextBox ID="txtClinicalNotes" runat="server" Width="300"></asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 100" class="right">
                                                                            Nomor Transaksi
                                                                        </td>
                                                                        <td style="width: 200">
                                                                            <asp:TextBox ID="txtTransactionNo" runat="server" Width="150" ReadOnly="true" CssClass="txtReadOnly"></asp:TextBox>
                                                                        </td>
                                                                        <td style="width: 20%;">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100">
                                                                        </td>
                                                                        <td style="width: 200">
                                                                            <asp:CheckBox ID="chkIsCito" runat="server" Text="Cito" />
                                                                        </td>
                                                                        <td style="width: 100" class="right">
                                                                        </td>
                                                                        <td style="width: 200">
                                                                        </td>
                                                                        <td style="width: 20%;">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="hseparator" style="width: 100%;" colspan="5">
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="display: none;">
                                                                        <td style="width: 100" class="right">
                                                                            Kelompok Pemeriksaan
                                                                        </td>
                                                                        <td style="width: 200">
                                                                            <asp:DropDownList ID="ddlGroupItem" runat="server" Width="300" AutoPostBack="true">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="5">
                                                                            <table width="100%" cellspacing="1">
                                                                                <tr>
                                                                                    <td valign="top" style="width: 40%;" class="rheader">
                                                                                        Pilih Pemeriksaan
                                                                                    </td>
                                                                                    <td valign="top" class="center">
                                                                                    </td>
                                                                                    <td valign="top" style="width: 40%;" class="rheader">
                                                                                        Pemeriksaan Dipilih
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top" style="width: 40%;">
                                                                                        <asp:DataGrid ID="grdItem" runat="server" BorderWidth="0" GridLines="None" Width="100%"
                                                                                            CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false" AutoGenerateColumns="false">
                                                                                            <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                                            <ItemStyle CssClass="gridItemStyle" />
                                                                                            <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                                            <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                                            <Columns>
                                                                                                <asp:TemplateColumn runat="server" ItemStyle-Width="50">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateColumn>
                                                                                                <asp:TemplateColumn runat="server" HeaderText="Nama Pemeriksaan">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ItemID") %>'
                                                                                                            ID="_lblItemID" Visible="false" />
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "ItemName")%>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateColumn>
                                                                                                <asp:TemplateColumn runat="server" HeaderText="Kelompok">
                                                                                                    <ItemTemplate>
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "GroupName")%>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateColumn>
                                                                                            </Columns>
                                                                                        </asp:DataGrid>
                                                                                    </td>
                                                                                    <td valign="top" class="center">
                                                                                        <asp:Button ID="btnJobOrderAdd" runat="server" Text="Add >" CssClass="sbttn" Width="100px" />
                                                                                        <br />
                                                                                        <br />
                                                                                        <asp:Button ID="btnJobOrderRemove" runat="server" Text="< Remove" CssClass="sbttn"
                                                                                            Width="100px" />
                                                                                    </td>
                                                                                    <td valign="top" style="width: 40%;">
                                                                                        <asp:DataGrid ID="grdItemOrder" runat="server" BorderWidth="0" GridLines="None" Width="100%"
                                                                                            CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false" AutoGenerateColumns="false">
                                                                                            <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                                            <ItemStyle CssClass="gridItemStyle" />
                                                                                            <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                                            <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                                            <Columns>
                                                                                                <asp:TemplateColumn runat="server" ItemStyle-Width="50">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateColumn>
                                                                                                <asp:TemplateColumn runat="server" HeaderText="Nama Pemeriksaan">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "JobOrderNo") %>'
                                                                                                            ID="_lblJobOrderNo" Visible="false" />
                                                                                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ItemID") %>'
                                                                                                            ID="_lblItemID" Visible="false" />
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "ItemName") %>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateColumn>
                                                                                                <asp:TemplateColumn runat="server" HeaderText="Kelompok">
                                                                                                    <ItemTemplate>
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "GroupName")%>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateColumn>
                                                                                            </Columns>
                                                                                        </asp:DataGrid>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="RadPageView10" runat="server">
                                                <table cellpadding="2" width="100%">
                                                    <tr>
                                                        <td>
                                                            <asp:DataGrid ID="grdPatientResumeHistory" runat="server" BorderWidth="0" GridLines="None"
                                                                Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                AutoGenerateColumns="false">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                <ItemStyle CssClass="gridItemStyle" />
                                                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                <Columns>
                                                                    <asp:TemplateColumn runat="server" HeaderText="" ItemStyle-Width="30" ItemStyle-VerticalAlign="Top">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblID" Text='<%# DataBinder.Eval(Container.DataItem, "ID")%>'
                                                                                Visible="false"></asp:Label>
                                                                            <asp:ImageButton runat="server" ID="_ibtnEdit" ImageUrl="/qistoollib/images/edit.png"
                                                                                CommandName="Revise" ToolTip="Revisi" Visible='<%# NOT DataBinder.Eval(Container.DataItem, "IsRevised")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Informasi Kunjungan" ItemStyle-Width="250"
                                                                        ItemStyle-VerticalAlign="Top">
                                                                        <ItemTemplate>
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td style="width: 50px;" valign="top">
                                                                                        Tanggal
                                                                                    </td>
                                                                                    <td valign="top">
                                                                                        :&nbsp;<%# Format(DataBinder.Eval(Container.DataItem, "CreatedDate"), "dd-MMM-yyyy hh:mm")%>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 50px;" valign="top">
                                                                                        Unit
                                                                                    </td>
                                                                                    <td valign="top">
                                                                                        :&nbsp;<%# DataBinder.Eval(Container.DataItem, "ServiceUnitName")%>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 50px;" valign="top">
                                                                                        Dokter
                                                                                    </td>
                                                                                    <td valign="top">
                                                                                        :&nbsp;<%# DataBinder.Eval(Container.DataItem, "PhysicianName")%>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 50px;" valign="top">
                                                                                        Asesmen
                                                                                    </td>
                                                                                    <td valign="top">
                                                                                        :&nbsp;<b><%# DataBinder.Eval(Container.DataItem, "AssessmentTypeName")%></b>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 50px;" valign="top">
                                                                                        S-O-A-P
                                                                                    </td>
                                                                                    <td valign="top">
                                                                                        :&nbsp;<asp:CheckBox ID="_chkIsSOAPNotes" runat="server" Enabled="false" Checked='<%# DataBinder.Eval(Container.DataItem, "IsSOAPNotes")%>' />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" valign="top">
                                                                                        <asp:Panel runat="server" ID="_pnlRevised" Visible='<%# DataBinder.Eval(Container.DataItem, "IsRevised")%>'>
                                                                                            <table cellpadding="2" cellspacing="1" style="background-color: Red;">
                                                                                                <tr>
                                                                                                    <td style="color: White;">
                                                                                                        REVISED
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="txtweak" style="background-color: White;">
                                                                                                        on
                                                                                                        <%# Format(DataBinder.Eval(Container.DataItem, "LastUpdatedDate"), "dd-MMM-yyyy hh:mm")%><br />
                                                                                                        by
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "LastUpdatedByUserName")%>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </asp:Panel>
                                                                                        <asp:Panel runat="server" ID="_pnlCreated" Visible='<%# NOT DataBinder.Eval(Container.DataItem, "IsRevised")%>'>
                                                                                            <table cellpadding="2" cellspacing="1" style="background-color: Olive;">
                                                                                                <tr>
                                                                                                    <td style="color: White;">
                                                                                                        CREATED
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="txtweak" style="background-color: White;">
                                                                                                        on
                                                                                                        <%# Format(DataBinder.Eval(Container.DataItem, "CreatedDate"), "dd-MMM-yyyy hh:mm")%><br />
                                                                                                        by
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "CreatedByUserName")%>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </asp:Panel>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Subjective" ItemStyle-VerticalAlign="Top"
                                                                        ItemStyle-Width="250">
                                                                        <ItemTemplate>
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td>
                                                                                        Anamnesis:<br />
                                                                                        <asp:TextBox ID="_txtChiefComplaintText" runat="server" TextMode="MultiLine" Font-Names="Segoe-UI,Arial"
                                                                                            Width="100%" Height="100" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "ChiefComplaint")%>'></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        Riwayat Kesehatan:<br />
                                                                                        <asp:TextBox ID="_txtHistoryOfPresentIllnessText" runat="server" TextMode="MultiLine"
                                                                                            Font-Names="Segoe-UI,Arial" Width="100%" Height="100" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "HistoryOfPresentIllness")%>'></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Objective" ItemStyle-VerticalAlign="Top"
                                                                        ItemStyle-Width="250">
                                                                        <ItemTemplate>
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td>
                                                                                        Pemeriksaan Fisik:<br />
                                                                                        <asp:TextBox ID="_txtObjectiveText" runat="server" TextMode="MultiLine" Font-Names="Segoe-UI,Arial"
                                                                                            Width="100%" Height="100" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "ObjectiveText")%>'></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Assessment" ItemStyle-VerticalAlign="Top"
                                                                        ItemStyle-Width="500">
                                                                        <ItemTemplate>
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td>
                                                                                        Diagnosa Utama:<br />
                                                                                        <asp:TextBox ID="_txtMainDiagnosisText" runat="server" TextMode="MultiLine" Font-Names="Segoe-UI,Arial"
                                                                                            Width="100%" Height="100" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "MainDiagnosisText")%>'></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        Prosedur:<br />
                                                                                        <asp:TextBox ID="_txtProcedureText" runat="server" TextMode="MultiLine" Font-Names="Segoe-UI,Arial"
                                                                                            Width="100%" Height="100" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "ProcedureText")%>'></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        Diagnosa Sekunder:<br />
                                                                                        <asp:TextBox ID="_txtSecondaryDiagnosisText" runat="server" TextMode="MultiLine"
                                                                                            Font-Names="Segoe-UI,Arial" Width="100%" Height="100" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "SecondaryDiagnosisText")%>'></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Planning" ItemStyle-VerticalAlign="Top"
                                                                        ItemStyle-Width="550">
                                                                        <ItemTemplate>
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td rowspan="2" valign="top">
                                                                                        Terapi:<br />
                                                                                        <asp:TextBox ID="_txtTherapyText" runat="server" TextMode="MultiLine" Font-Names="Segoe-UI,Arial"
                                                                                            Font-Size="Small" Width="100%" Height="224" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "TherapyText")%>'></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        Sasaran Terukur:<br />
                                                                                        <asp:TextBox ID="_txtMeasurableTargetText" runat="server" TextMode="MultiLine" Font-Names="Segoe-UI,Arial"
                                                                                            Width="100%" Height="100" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "MeasurableTargetText")%>'></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        Keterangan:<br />
                                                                                        <asp:TextBox ID="_txtKeterangan" runat="server" TextMode="MultiLine" Font-Names="Segoe-UI,Arial"
                                                                                            Width="100%" Height="100" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "Notes")%>'></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="_lblTherapyHISOrderNo" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "TherapyHISOrderNo")%>'></asp:Label>
                                                                                        <asp:Panel runat="server" ID="_pnlOrder" Visible='<%# DataBinder.Eval(Container.DataItem, "TherapyHISOrderNo") <> "" and DataBinder.Eval(Container.DataItem, "TherapyHISOrderStatus") = "Order" %>'>
                                                                                            <table cellpadding="2" cellspacing="1" style="background-color: #2e86c1;" width="100%">
                                                                                                <tr>
                                                                                                    <td style="color: White;">
                                                                                                        Order#:
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "TherapyHISOrderNo")%>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="txtweak" style="background-color: White;">
                                                                                                        Status:
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "TherapyHISOrderStatus")%>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </asp:Panel>
                                                                                        <asp:Panel runat="server" ID="_pnlCancel" Visible='<%# DataBinder.Eval(Container.DataItem, "TherapyHISOrderNo") <> "" and DataBinder.Eval(Container.DataItem, "TherapyHISOrderStatus") = "Batal" %>'>
                                                                                            <table cellpadding="2" cellspacing="1" style="background-color: Red;" width="100%">
                                                                                                <tr>
                                                                                                    <td style="color: White;">
                                                                                                        Order#:
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "TherapyHISOrderNo")%>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="txtweak" style="background-color: White;">
                                                                                                        Status:
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "TherapyHISOrderStatus")%>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </asp:Panel>
                                                                                        <asp:Panel runat="server" ID="_pnlRealisasi" Visible='<%# DataBinder.Eval(Container.DataItem, "TherapyHISOrderNo") <> "" and DataBinder.Eval(Container.DataItem, "TherapyHISOrderStatus") = "Realisasi" %>'>
                                                                                            <table cellpadding="2" cellspacing="1" style="background-color: Olive;" width="100%">
                                                                                                <tr>
                                                                                                    <td style="color: White;">
                                                                                                        Order#:
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "TherapyHISOrderNo")%>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="txtweak" style="background-color: White;">
                                                                                                        Status:
                                                                                                        <asp:Label runat="server" ID="_lblTherapyHISOrderStatus" Text='<%# DataBinder.Eval(Container.DataItem, "TherapyHISOrderStatus")%>'></asp:Label><br />
                                                                                                        on
                                                                                                        <%# Format(DataBinder.Eval(Container.DataItem, "TherapyHISOrderStatusUpdatedDate"), "dd-MMM-yyyy hh:mm")%><br />
                                                                                                        by
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "TherapyHISOrderStatusUpdatedBy")%>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </asp:Panel>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        Tgl. Penghentian:<br />
                                                                                        <%# DataBinder.Eval(Container.DataItem, "TherapyStopDate")%>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                </Columns>
                                                            </asp:DataGrid>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="RadPageView6" runat="server">
                                                <table cellpadding="2" width="100%">
                                                    <tr>
                                                        <td class="Heading1" valign="top" colspan="2">
                                                            Dokumen Pasien
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="hseparator" style="width: 100%;" colspan="2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" colspan="2">
                                                            <asp:DataGrid ID="grdPatientDocument" runat="server" BorderWidth="0" GridLines="None"
                                                                Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                AutoGenerateColumns="false">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                <ItemStyle CssClass="gridItemStyle" />
                                                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                <Columns>
                                                                    <asp:TemplateColumn runat="server" HeaderText="" ItemStyle-Width="50" ItemStyle-VerticalAlign="Top">
                                                                        <ItemTemplate>
                                                                            <a href='<%# DataBinder.Eval(Container.DataItem, "FileUrl") %>' target="_blank" title="Preview File">
                                                                                <img src="/qistoollib/images/look.png" border="0" align="middle" alt="Preview File" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Nama Dokumen" ItemStyle-VerticalAlign="Top">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FileID") %>'
                                                                                ID="_lblFileID" Visible="false" />
                                                                            <%# DataBinder.Eval(Container.DataItem, "FileName")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Tipe" ItemStyle-Width="100" ItemStyle-VerticalAlign="Top">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FileExtension")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Keterangan" ItemStyle-VerticalAlign="Top">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FileDescription")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="No. Registrasi" ItemStyle-VerticalAlign="Top">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "RegistrationNo")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Diunggah" ItemStyle-Width="150" ItemStyle-VerticalAlign="Top">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "UploadByName")%><br />
                                                                            on&nbsp;<%# Format(DataBinder.Eval(Container.DataItem, "UploadDate"),"dd-MMM-yyyy hh:mm")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                </Columns>
                                                            </asp:DataGrid>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Heading1" valign="top" colspan="2">
                                                            Dokumen Pasien untuk Kunjungan ini
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="hseparator" style="width: 100%;" colspan="2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" colspan="2">
                                                            <asp:DataGrid ID="grdPatientDocumentByRegistration" runat="server" BorderWidth="0"
                                                                GridLines="None" Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true"
                                                                ShowFooter="false" AutoGenerateColumns="false">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                <ItemStyle CssClass="gridItemStyle" />
                                                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                <Columns>
                                                                    <asp:TemplateColumn runat="server" HeaderText="" ItemStyle-Width="50" ItemStyle-VerticalAlign="Top">
                                                                        <ItemTemplate>
                                                                            <a href='<%# DataBinder.Eval(Container.DataItem, "FileUrl") %>' target="_blank" title="Preview File">
                                                                                <img src="/qistoollib/images/look.png" border="0" align="middle" alt="Preview File" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Nama Dokumen" ItemStyle-VerticalAlign="Top">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FileID") %>'
                                                                                ID="_lblFileID" Visible="false" />
                                                                            <%# DataBinder.Eval(Container.DataItem, "FileName")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Tipe" ItemStyle-Width="100" ItemStyle-VerticalAlign="Top">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FileExtension")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Keterangan" ItemStyle-VerticalAlign="Top">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "FileDescription")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="No. Registrasi" ItemStyle-VerticalAlign="Top">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "RegistrationNo")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Diunggah" ItemStyle-Width="150" ItemStyle-VerticalAlign="Top">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "UploadByName")%><br />
                                                                            on&nbsp;<%# Format(DataBinder.Eval(Container.DataItem, "UploadDate"),"dd-MMM-yyyy hh:mm")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                </Columns>
                                                            </asp:DataGrid>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="RadPageView7" runat="server">
                                                <table class="ToolbarM" cellpadding="1" cellspacing="0" border="0" width="100%">
                                                    <tr>
                                                        <td class="left padding-LR-5">
                                                            <asp:LinkButton runat="server" ID="lbtnNewIE" ToolTip="Tambah" CausesValidation="false"
                                                                Width="48"><img src="/qistoollib/images/tbnew.png" alt="" border="0" /></asp:LinkButton>
                                                            <asp:LinkButton runat="server" ID="lbtnSaveIE" ToolTip="Simpan" CausesValidation="false"
                                                                Width="48"><img src="/qistoollib/images/tbsave.png" alt="" border="0" /></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="hseparator" style="width: 100%;">
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table cellpadding="2" width="100%">
                                                    <tr>
                                                        <td class="Heading1" valign="top" colspan="2">
                                                            Permasalahan
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="hseparator" style="width: 100%;" colspan="2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 50%">
                                                            <asp:TextBox ID="txtIDIE" runat="server" Visible="false"></asp:TextBox>
                                                            <asp:TextBox ID="txtComplainTextIE" runat="server" TextMode="MultiLine" Font-Names="Segoe-UI,Arial"
                                                                Width="100%" Height="50"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="Heading1" valign="top">
                                                            Intervensi/Tindakan
                                                        </td>
                                                        <td class="Heading1" valign="top">
                                                            Evaluasi
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="hseparator" style="width: 100%;" colspan="2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="txtInterventionTextIE" runat="server" TextMode="MultiLine" Font-Names="Segoe-UI,Arial"
                                                                Width="100%" Height="50"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtEvaluationTextIE" runat="server" TextMode="MultiLine" Font-Names="Segoe-UI,Arial"
                                                                Width="100%" Height="50"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:DataGrid ID="grdPatientInterventionEvaluation" runat="server" BorderWidth="0"
                                                                GridLines="None" Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true"
                                                                ShowFooter="false" AutoGenerateColumns="false">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                <ItemStyle CssClass="gridItemStyle" />
                                                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                <Columns>
                                                                    <asp:TemplateColumn runat="server" HeaderText="" ItemStyle-Width="30" ItemStyle-VerticalAlign="Top">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblID" Text='<%# DataBinder.Eval(Container.DataItem, "ID")%>'
                                                                                Visible="false"></asp:Label>
                                                                            <asp:ImageButton runat="server" ID="_ibtnEdit" ImageUrl="/qistoollib/images/edit.png"
                                                                                CommandName="Revise" ToolTip="Revisi" Visible='<%# NOT DataBinder.Eval(Container.DataItem, "IsRevised")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Informasi Intervensi" ItemStyle-Width="250"
                                                                        ItemStyle-VerticalAlign="Top">
                                                                        <ItemTemplate>
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td style="width: 50px;" valign="top">
                                                                                        Tanggal
                                                                                    </td>
                                                                                    <td valign="top">
                                                                                        :&nbsp;<%# Format(DataBinder.Eval(Container.DataItem, "CreatedDate"), "dd-MMM-yyyy hh:mm")%>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 50px;" valign="top">
                                                                                        Unit
                                                                                    </td>
                                                                                    <td valign="top">
                                                                                        :&nbsp;<%# DataBinder.Eval(Container.DataItem, "ServiceUnitName")%>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 50px;" valign="top">
                                                                                        Paramedis
                                                                                    </td>
                                                                                    <td valign="top">
                                                                                        :&nbsp;<%# DataBinder.Eval(Container.DataItem, "ParamedicName")%>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" valign="top">
                                                                                        <asp:Panel runat="server" ID="_pnlRevised" Visible='<%# DataBinder.Eval(Container.DataItem, "IsRevised")%>'>
                                                                                            <table cellpadding="2" cellspacing="1" style="background-color: Red;">
                                                                                                <tr>
                                                                                                    <td style="color: White;">
                                                                                                        REVISED
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="txtweak" style="background-color: White;">
                                                                                                        on
                                                                                                        <%# Format(DataBinder.Eval(Container.DataItem, "LastUpdatedDate"), "dd-MMM-yyyy hh:mm")%><br />
                                                                                                        by
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "LastUpdatedByUserName")%>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </asp:Panel>
                                                                                        <asp:Panel runat="server" ID="_pnlCreated" Visible='<%# NOT DataBinder.Eval(Container.DataItem, "IsRevised")%>'>
                                                                                            <table cellpadding="2" cellspacing="1" style="background-color: Olive;">
                                                                                                <tr>
                                                                                                    <td style="color: White;">
                                                                                                        CREATED
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="txtweak" style="background-color: White;">
                                                                                                        on
                                                                                                        <%# Format(DataBinder.Eval(Container.DataItem, "CreatedDate"), "dd-MMM-yyyy hh:mm")%><br />
                                                                                                        by
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "CreatedByUserName")%>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </asp:Panel>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Permasalahan" ItemStyle-VerticalAlign="Top"
                                                                        ItemStyle-Width="250">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="_txtComplainIE" runat="server" TextMode="MultiLine" Font-Names="Segoe-UI,Arial"
                                                                                Width="100%" Height="100" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "ComplainText")%>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Intervensi/Tindakan" ItemStyle-VerticalAlign="Top"
                                                                        ItemStyle-Width="300">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="_txtInterventionIE" runat="server" TextMode="MultiLine" Font-Names="Segoe-UI,Arial"
                                                                                Width="100%" Height="100" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "InterventionText")%>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Evaluasi" ItemStyle-Width="200" ItemStyle-VerticalAlign="Top">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="_txtEvaluationIE" runat="server" TextMode="MultiLine" Font-Names="Segoe-UI,Arial"
                                                                                Width="100%" Height="100" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "EvaluationText")%>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                </Columns>
                                                            </asp:DataGrid>
                                                        </td>
                                                    </tr>
                                                    <tr style="display: none;">
                                                        <td colspan="2">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td style="width: 50%" valign="top">
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td class="right" style="width: 100;">
                                                                                    Procedure
                                                                                </td>
                                                                                <td>
                                                                                    <telerik:RadComboBox Style="z-index: 0" ID="RadComboBox2" runat="server" AutoPostBack="false"
                                                                                        Skin="Windows7" ShowMoreResultBox="false" AllowCustomText="true" ItemRequestTimeout="200"
                                                                                        DropDownWidth="500" HighlightTemplatedItems="true" EnableLoadOnDemand="true"
                                                                                        MarkFirstMatch="true" Width="200" Height="200" ShowDropDownOnTextboxClick="False">
                                                                                        <HeaderTemplate>
                                                                                            <table style="width: 415px; text-align: left;">
                                                                                                <tr>
                                                                                                    <td style="width: 125px;">
                                                                                                        Code
                                                                                                    </td>
                                                                                                    <td style="width: 250px;">
                                                                                                        Name
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <table style="width: 415px; text-align: left;">
                                                                                                <tr>
                                                                                                    <td style="width: 125px;">
                                                                                                    </td>
                                                                                                    <td style="width: 250px;">
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </ItemTemplate>
                                                                                    </telerik:RadComboBox>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                            <telerik:RadPageView ID="RadPageView8" runat="server">
                                                <table cellpadding="2" cellspacing="1" width="100%" style="background-color: #DFE9F5;">
                                                    <tr>
                                                        <td class="rheader" style="background-color: #ffffff;">
                                                            Catatan Medis
                                                        </td>
                                                        <td class="rheader" style="background-color: #ffffff;">
                                                            Catatan Perawat
                                                        </td>
                                                        <td class="rheader" style="background-color: #ffffff;">
                                                            Catatan Unit Lainnya
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" class="rheader" style="background-color: #ffffff;">
                                                            <asp:DataGrid ID="grdCatatanMedis" runat="server" BorderWidth="0" GridLines="None"
                                                                Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="false" ShowFooter="false"
                                                                AutoGenerateColumns="false">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                <ItemStyle CssClass="gridItemStyle" />
                                                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                <Columns>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Informasi Kunjungan" ItemStyle-Width="250"
                                                                        ItemStyle-VerticalAlign="Top">
                                                                        <ItemTemplate>
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td style="width: 50px; font-weight: bold;" valign="top">
                                                                                        Tanggal
                                                                                    </td>
                                                                                    <td valign="top" style="font-weight: bold;">
                                                                                        :&nbsp;<%# Format(DataBinder.Eval(Container.DataItem, "CreatedDate"), "dd-MMM-yyyy hh:mm")%>
                                                                                    </td>
                                                                                    <td style="width: 100;" align="right">
                                                                                        <asp:Panel runat="server" ID="_pnlRevised" Visible='<%# DataBinder.Eval(Container.DataItem, "IsRevised")%>'>
                                                                                            <table cellpadding="2" cellspacing="1" style="background-color: Red;">
                                                                                                <tr>
                                                                                                    <td style="color: White;">
                                                                                                        REVISED
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </asp:Panel>
                                                                                        <asp:Panel runat="server" ID="_pnlCreated" Visible='<%# NOT DataBinder.Eval(Container.DataItem, "IsRevised")%>'>
                                                                                            <table cellpadding="2" cellspacing="1" style="background-color: Olive;">
                                                                                                <tr>
                                                                                                    <td style="color: White;">
                                                                                                        CREATED
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </asp:Panel>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 50px; font-weight: bold;" valign="top">
                                                                                        Unit
                                                                                    </td>
                                                                                   <td valign="top" style="font-weight: bold;" colspan="2">
                                                                                         :&nbsp;<%# DataBinder.Eval(Container.DataItem, "ServiceUnitName")%>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 50px; font-weight: bold;" valign="top">
                                                                                        Dokter
                                                                                    </td>
                                                                                    <td valign="top" style="font-weight: bold;" colspan="2">
                                                                                        :&nbsp;<%# DataBinder.Eval(Container.DataItem, "PhysicianName")%>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 50px; font-weight: bold;" valign="top">
                                                                                        Asesmen
                                                                                    </td>
                                                                                    <td valign="top" style="font-weight: bold;" colspan="2">
                                                                                        :&nbsp;<b><%# DataBinder.Eval(Container.DataItem, "AssessmentTypeName")%></b>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top" colspan="3">
                                                                                        <asp:TextBox ID="_txtSOAPNotes" runat="server" TextMode="MultiLine" Text='<%# DataBinder.Eval(Container.DataItem, "SOAPNotes") %>'
                                                                                            Width="100%" Height="150" ReadOnly="true" Font-Names="Segoe UI" BorderStyle="None"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                </Columns>
                                                            </asp:DataGrid>
                                                        </td>
                                                        <td valign="top" class="rheader" style="background-color: #ffffff;">
                                                            <asp:DataGrid ID="grdCatatanPerawatNurseNotes" runat="server" BorderWidth="0" GridLines="None"
                                                                Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="false" ShowFooter="false"
                                                                AutoGenerateColumns="false">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                <ItemStyle CssClass="gridItemStyle" />
                                                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                <Columns>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Informasi Kunjungan" ItemStyle-Width="250"
                                                                        ItemStyle-VerticalAlign="Top">
                                                                        <ItemTemplate>
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td style="width: 50px; font-weight: bold;" valign="top">
                                                                                        Tanggal
                                                                                    </td>
                                                                                    <td valign="top" style="font-weight: bold;">
                                                                                        :&nbsp;<%# Format(DataBinder.Eval(Container.DataItem, "CreatedDate"), "dd-MMM-yyyy hh:mm")%>
                                                                                    </td>
                                                                                    <td style="width: 150;" align="right">
                                                                                        <asp:Panel runat="server" ID="_pnlRevised" Visible='<%# DataBinder.Eval(Container.DataItem, "IsRevised")%>'>
                                                                                            <table cellpadding="2" cellspacing="1" style="background-color: Red;">
                                                                                                <tr>
                                                                                                    <td style="color: White;">
                                                                                                        REVISED
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </asp:Panel>
                                                                                        <asp:Panel runat="server" ID="_pnlCreated" Visible='<%# NOT DataBinder.Eval(Container.DataItem, "IsRevised")%>'>
                                                                                            <table cellpadding="2" cellspacing="1" style="background-color: Olive;">
                                                                                                <tr>
                                                                                                    <td style="color: White;">
                                                                                                        CREATED
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </asp:Panel>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 50px; font-weight: bold;" valign="top">
                                                                                        Unit
                                                                                    </td>
                                                                                   <td valign="top" style="font-weight: bold;" colspan="2">
                                                                                         :&nbsp;<%# DataBinder.Eval(Container.DataItem, "ServiceUnitName")%>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 50px; font-weight: bold;" valign="top">
                                                                                        Perawat
                                                                                    </td>
                                                                                    <td valign="top" style="font-weight: bold;">
                                                                                        :&nbsp;<%# DataBinder.Eval(Container.DataItem, "CreatedByUserName")%>
                                                                                    </td>
                                                                                    <td valign="top" style="font-weight: bold; text-align: right;">
                                                                                        <asp:TextBox ID="_txtNurseNotesID" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "ID") %>'></asp:TextBox>
                                                                                        <asp:CheckBox ID="_chkIsPhysicianConfirmed" runat="server" Enabled="false" Checked='<%# DataBinder.Eval(Container.DataItem, "IsPhysicianConfirmed")%>' />
                                                                                        <asp:Button ID="_btnPhysicianConfirmation" runat="server" Text="Konfirmasi Dokter"
                                                                                            CssClass="sbttn" Width="120" CommandName="PhysicianConfirmed" Enabled='<%# NOT DataBinder.Eval(Container.DataItem, "IsPhysicianConfirmed") AND NOT DataBinder.Eval(Container.DataItem, "IsRevised")%>' />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="3">
                                                                                        <asp:TextBox ID="_txtNurseNotes" runat="server" TextMode="MultiLine" Text='<%# DataBinder.Eval(Container.DataItem, "NurseNotes") %>'
                                                                                            Width="100%" Height="150" ReadOnly="true" Font-Names="Segoe UI" BorderStyle="None"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                </Columns>
                                                            </asp:DataGrid>
                                                            <asp:DataGrid ID="grdCatatanPerawat" runat="server" BorderWidth="0" GridLines="None"
                                                                Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="false" ShowFooter="false"
                                                                AutoGenerateColumns="false" Visible="false">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                <ItemStyle CssClass="gridItemStyle" />
                                                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                <Columns>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Informasi Kunjungan" ItemStyle-Width="250"
                                                                        ItemStyle-VerticalAlign="Top">
                                                                        <ItemTemplate>
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td style="width: 50px; font-weight: bold;" valign="top">
                                                                                        Tanggal
                                                                                    </td>
                                                                                    <td valign="top" style="font-weight: bold;">
                                                                                        :&nbsp;<%# Format(DataBinder.Eval(Container.DataItem, "CreatedDate"), "dd-MMM-yyyy hh:mm")%>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 50px; font-weight: bold;" valign="top">
                                                                                        Perawat
                                                                                    </td>
                                                                                    <td valign="top" style="font-weight: bold;">
                                                                                        :&nbsp;<%# DataBinder.Eval(Container.DataItem, "UserName")%>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top" colspan="2">
                                                                                        Anamnesis (Keluhan Utama):
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top" colspan="2">
                                                                                        <asp:TextBox ID="_txtKeluhanUtama" runat="server" TextMode="MultiLine" Text='<%# DataBinder.Eval(Container.DataItem, "KeluhanUtama") %>'
                                                                                            Height="80" ReadOnly="true" Font-Names="Segoe UI" BorderStyle="None"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top" colspan="2">
                                                                                        Riwayat Kesehatan:
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top" colspan="2">
                                                                                        <asp:TextBox ID="_txtHistoryOfPresentIllness" runat="server" TextMode="MultiLine"
                                                                                            Text='<%# DataBinder.Eval(Container.DataItem, "RiwayatKeluhanSaatIni") %>' Height="80"
                                                                                            ReadOnly="true" Font-Names="Segoe UI" BorderStyle="None"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top" colspan="2">
                                                                                        Tanda Vital:
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top" colspan="2">
                                                                                        <table cellspacing="0" cellpadding="0">
                                                                                            <tr>
                                                                                                <td>
                                                                                                    Tekanan darah:
                                                                                                    <%# DataBinder.Eval(Container.DataItem, "ttvTekananDarah")%>
                                                                                                </td>
                                                                                                <td>
                                                                                                    Berat badan:
                                                                                                    <%# DataBinder.Eval(Container.DataItem, "ttvBeratBadan")%>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    Nadi:
                                                                                                    <%# DataBinder.Eval(Container.DataItem, "ttvNadi")%>
                                                                                                </td>
                                                                                                <td>
                                                                                                    Tinggi badan:
                                                                                                    <%# DataBinder.Eval(Container.DataItem, "ttvTinggiBadan")%>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    Suhu:
                                                                                                    <%# DataBinder.Eval(Container.DataItem, "ttvSuhu")%>
                                                                                                </td>
                                                                                                <td>
                                                                                                    IMT:
                                                                                                    <%# DataBinder.Eval(Container.DataItem, "ttvIndexMasaTubuh")%>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top" colspan="2">
                                                                                        Skala Nyeri:
                                                                                        <%# DataBinder.Eval(Container.DataItem, "NyeriSkala")%>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top" colspan="2">
                                                                                        Resiko Jatuh:
                                                                                        <%# DataBinder.Eval(Container.DataItem, "KategoriResikoJatuh")%>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                </Columns>
                                                            </asp:DataGrid>
                                                        </td>
                                                        <td class="rheader" style="background-color: #ffffff;">
                                                            <asp:DataGrid ID="grdCatatanUnitLainnya" runat="server">
                                                            </asp:DataGrid>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </telerik:RadPageView>
                                        </telerik:RadMultiPage>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
