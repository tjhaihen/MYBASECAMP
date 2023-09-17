<%@ Register TagPrefix="Module" TagName="Copyright" Src="../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../incl/calendar.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="IncidentInvestigation.aspx.vb"
    Inherits="QIS.Web.IncidentInvestigation" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Medinfras Incident Investigation</title>
    <link rel="title icon" href="/qistoollib/images/favicon.png" />
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href="/qistoollib/css/styles_blue.css" type="text/css" rel="Stylesheet" />
    <script language="javascript" type="text/javascript" src="/qistoollib/scripts/JScript.js"></script>
    <style type="text/css">
        #ulRepDateInMonthDt
        {
            width: 100%;
            margin: 0;
            padding: 0;                     
        }
        #ulRepDateInMonthDt li
        {
            list-style-type: none;
            display: inline-block; /* FF3.6; Chrome10+ */                     
            *display: inline;
            background: #eeeeee;
            width: 280px;
            height: 150px;
            margin: 5px;
        }
        #ulRepDateInMonth
        {
            width: 100%;
            margin: 0;
            padding: 0;                     
        }
        #ulRepDateInMonth li
        {
            list-style-type: none;            
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server">
    <table width="100%" cellpadding="2" cellspacing="0" style="height: 100%;">
        <tr>
            <td width="100%" valign="top" colspan="3">
                <!-- BEGIN PAGE HEADER -->
                <Module:RadMenu ID="RadMenu" runat="server" />
                <!-- END PAGE HEADER -->
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 120px;">
                <table width="150" style="height: 60px;">
                    <tr>
                        <td class="Heading2">
                            Tahun
                        </td>
                    </tr>
                    <tr>
                        <td class="hseparator">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtYear" runat="server" Width="150" AutoPostBack="true">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DataGrid ID="grdIncidentInvestigation" runat="server" BorderWidth="0" GridLines="None"
                                Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="false" ShowFooter="false"
                                AutoGenerateColumns="false">
                                <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                <ItemStyle CssClass="gridItemStyle" />
                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                <Columns>
                                    <asp:TemplateColumn runat="server" HeaderText="Report No.">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="_lbtnReportNo" runat="server" CommandName="SelectData" Text='<%# DataBinder.Eval(Container.DataItem, "IncidentNo") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn runat="server" HeaderText="IsApproved">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "IsApproved") %>'
                                                ID="_chkIsApproved" Enabled="false" />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                            </asp:DataGrid>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%;" class="hseparator" colspan="2">
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" class="vseparator" style="height: 100%;">
            </td>
            <td valign="top" style="width: 100%;">
                <table width="100%">
                    <tr>
                        <td class="Heading2" colspan="2">
                            <asp:Label ID="lblPageTitle" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="hseparator" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <Module:CSSToolbar ID="CSSToolbar" runat="server"></Module:CSSToolbar>
                        </td>
                        <td align="right">
                            <table width="100%">
                                <tr>
                                    <td class="right">
                                        Dibuat oleh:
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCreatedBy" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="right">
                                        Review/Approval oleh:
                                    </td>
                                    <td>
                                        <asp:Label ID="lblReviewBy" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="hseparator" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td valign="top" class="right" style="width: 180; background: #eeeeee;">
                                        Nomor Laporan
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtReportNo" runat="server" Width="300" ReadOnly="true" CssClass="txtReadOnly"></asp:TextBox>
                                        <asp:CheckBox ID="chkIsApproved" runat="server" Visible="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="right" style="background: #eeeeee;">
                                        Tanggal Laporan
                                    </td>
                                    <td>
                                        <Module:Calendar ID="calReportDate" runat="server" DontResetDate="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="right" style="background: #eeeeee;">
                                        Judul Insiden
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtincidentSubject" runat="server" Width="100%" MaxLength="500"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="hseparator" colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="right" style="background: #eeeeee;">
                                        Tempat Insiden
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtincidentLocation" runat="server" Width="100%" MaxLength="500"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="right" style="background: #eeeeee;">
                                        Tanggal & Waktu Kejadian
                                    </td>
                                    <td>
                                        <Module:Calendar ID="calincidentDate" runat="server" DontResetDate="true" />
                                        &nbsp;<asp:TextBox ID="txtincidentTime" runat="server" Width="100" MaxLength="5"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="right" style="background: #eeeeee;">
                                        Tingkat Potensi Keparahan
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlseveritySCode" runat="server" Width="300">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="hseparator" colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btnIncidentInvestigation" runat="server" Text="Isi Investigasi" Width="184" />
                                        <asp:Button ID="btnIncidentChronological" runat="server" Text="Isi Kronologis" Width="184" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="hseparator" colspan="2">
                                    </td>
                                </tr>
                            </table>
                            <asp:Panel ID="pnlInvestigation" runat="server">
                                <table width="100%">
                                    <tr>
                                        <td valign="top" colspan="2">
                                            Jenis Insiden (contoh: Kehilangan Informasi, Kerusakan Infrastruktur IT, Virus,
                                            Kehilangan Aset, Kerusakan Aset, dll.)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtincidentType" runat="server" Width="100%" Height="50" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" colspan="2">
                                            Deskripsi Insiden (Apa, Siapa, Kapan, Dimana, Bagaimana, dll.)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtincidentDescription" runat="server" Width="100%" Height="50"
                                                TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" colspan="2">
                                            Saksi-saksi Insiden
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtincidentWitness" runat="server" Width="100%" Height="50" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" colspan="2">
                                            Kerusakan Akibat Insiden
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtincidentConsequence" runat="server" Width="100%" Height="50"
                                                TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" colspan="2">
                                            Taksiran Kerusakan Akibat Insiden
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtincidentConsequenceEst" runat="server" Width="100%" Height="50"
                                                TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" colspan="2">
                                            Penyebab Insiden
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtincidentTrigger" runat="server" Width="100%" Height="50" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" colspan="2">
                                            Tindakan Perbaikan
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtcorrectiveAction" runat="server" Width="100%" Height="50" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" colspan="2">
                                            Saran/Rekomendasi Manajer Departemen
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtrecommendationFromDeptMgr" runat="server" Width="100%" Height="50"
                                                TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="pnlChronological" runat="server">
                                <table width="100%">
                                    <tr>
                                        <td class="rheader" valign="top">
                                            Kronologis Insiden
                                        </td>
                                        <td class="right">
                                            <asp:Button ID="btnAddIncidentChronological" runat="server" Text="Add" Width="100" /> 
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="right" style="background: #eeeeee; width: 180px;">
                                            Tanggal & Jam Kejadian
                                        </td>
                                        <td>
                                            <Module:Calendar ID="calChronologicalDate" runat="server" DontResetDate="true" />
                                            &nbsp;<asp:TextBox ID="txtChronologicalTime" runat="server" Width="100" MaxLength="5"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            Peristiwa/Kejadian
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtIncidentChronological" runat="server" Width="100%" Height="50"
                                                TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:DataGrid ID="grdIncidentChronological" runat="server" BorderWidth="0" GridLines="None"
                                                Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                AutoGenerateColumns="false">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                <ItemStyle CssClass="gridItemStyle" />
                                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                <Columns>
                                                    <asp:TemplateColumn runat="server" ItemStyle-Width="50">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="_ibtnDelete" runat="server" ImageUrl="/qistoollib/images/delete.png"
                                                                ImageAlign="AbsMiddle" CommandName="Delete" CausesValidation="false" Visible='<%# NOT(DataBinder.Eval(Container.DataItem, "IsApproved"))%>' />
                                                            <asp:Label ID="_lblincidentChronologicalID" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "incidentChronologicalID")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Tanggal" ItemStyle-Width="100">
                                                        <ItemTemplate>
                                                            <%# Format(DataBinder.Eval(Container.DataItem, "chronologicalDate"), "dd-MMM-yyyy")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Jam" ItemStyle-Width="60">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "chronologicalTime")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Peristiwa/Kejadian">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="_txtIncidentChronological" runat="server" Width="100%" Height="50"
                                                                Text='<%# DataBinder.Eval(Container.DataItem, "incidentChronological")%>' TextMode="MultiLine"
                                                                ReadOnly="true"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                </Columns>
                                            </asp:DataGrid>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="bottom" colspan="3">
                <!-- BEGIN PAGE FOOTER-->
                <Module:Copyright ID="mdlCopyRight" runat="server" pathprefix=".."></Module:Copyright>
                <!-- END PAGE FOOTER-->
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
