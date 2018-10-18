<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../incl/copyright.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PhysicianScheduleInformation.aspx.vb"
    Inherits="QIS.Web.Secure.PhysicianScheduleInformation" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Physician Schedule Information</title>
    <link rel="title icon" href="/qistoollib/images/favicon.png" />
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta http-equiv="refresh" content="600">
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href='/qistoollib/css/styles_custom.css' type="text/css" rel="Stylesheet" />
    <script language="javascript" type="text/javascript" src="/qistoollib/scripts/JScript.js"></script>
    <script type="text/javascript" language="javascript" src='/qistoollib/scripts/common/common.js'></script>
    <style type="text/css">
        #container {
    
        }
        #bottomline {
            position: absolute;
            bottom: 10;
        }
        #ulrepSpecialty
        {
            width: 100%;
            margin: 0;
            padding: 0;                                           
        }
        #ulrepSpecialty li
        {
            list-style-type: none;
            display: inline-block; /* FF3.6; Chrome10+ */                     
            *display: inline;
            width: 100%;
            margin: 1px;
        }
        #ulrepSpecialtySum
        {
            width: 100%;
            margin: 0;
            padding: 0;                                                       
        }
        #ulrepSpecialtySum li
        {
            list-style-type: none;
            margin: 1px;
            vertical-align: top;
        }
        #ulRepPhysician
        {
            width: 100%;
            margin: 0 0 5 0;
            padding: 0;                                           
        }
        div#multicolumn 
        {
            -moz-column-count: 3;
            -moz-column-gap: 10px;
            -webkit-column-count: 3;
            -webkit-column-gap: 10px;
            column-count: 3;
            column-gap: 10px;
        }
    </style>
</head>
<body>
    <form id="frm" runat="server" style="background-image: url('/qistoollib/images/background.png');">
    <table border="0" width="100%" cellspacing="2" cellpadding="1" height="100%">
        <tr>
            <td width="100%" valign="top">
            </td>
        </tr>
        <tr>
            <td width="100%" height="100%" valign="top">
                <table cellspacing="2" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td class="rheader" colspan="2">
                            <table width="100%" style="font-family: Dekar, Arial, Tahoma;">
                                <td style="width: 60;" valign="middle">
                                    <img src="/qistoollib/images/clientCompanyLogo.png" width="50" alt="" border="" />
                                </td>
                                <td style="font-size: 20pt; font-family: Dekar, Arial, Tahoma; color: #004F7B;" valign="middle">
                                    <asp:Label ID="lblCompanyName" runat="server"></asp:Label><br />
                                    <asp:Label ID="lblCompanyAddress" runat="server" Font-Size="Medium"></asp:Label>
                                </td>
                                <td class="rheader" style="text-align: right; font-size: 24pt;" valign="middle">
                                    <asp:Label ID="lblPageTitle" runat="server" Text="INFORMASI JADWAL PRAKTEK DOKTER"></asp:Label>
                                </td>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="hseparator" style="width: 100%;" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 50%;" valign="middle">
                            <asp:ImageButton ID="ibtnSummary" runat="server" ImageUrl="/qistoollib/images/ico-summary.png"
                                ToolTip="Informasi Jadwal Dokter Hari Ini" Width="32" ImageAlign="AbsMiddle" />
                            <asp:ImageButton ID="ibtnDetail" runat="server" ImageUrl="/qistoollib/images/ico-detail.png"
                                ToolTip="Informasi Jadwal Dokter" Width="32" ImageAlign="AbsMiddle" />
                            <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="/qistoollib/images/ico-edit.png"
                                ToolTip="Edit Informasi Jadwal Dokter" Width="32" ImageAlign="AbsMiddle" />
                        </td>
                        <td class="rheader" style="width: 50%; text-align: right; font-size: 18pt;">
                            <asp:Label ID="lblDateTime" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="hseparator" style="width: 100%;" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="left" colspan="2">
                            <asp:Panel ID="pnlSummary" runat="server">
                                <div id="container">
                                    <div id="multicolumn">
                                        <asp:Repeater ID="repSpecialtySum" runat="server" OnItemDataBound="repSpecialtySum_ItemDataBound">
                                            <HeaderTemplate>
                                                <ul id="ulrepSpecialtySum">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <li>
                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td valign="top" style="width: 100%; height: 30;" colspan="2">
                                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                                    <tr>
                                                                        <td class="Heading3" style="width: 200; height: 30; padding-left: 5;">
                                                                            <%# DataBinder.Eval(Container.DataItem, "SpecialtyName")%>
                                                                        </td>
                                                                        <td valign="bottom" style="height: 30; background-color: #BABBBD; font-size: 12pt;">
                                                                            <table cellspacing="1" width="100%">
                                                                                <tr>
                                                                                    <td style="background-color: #30CD08; color: #ffffff; border-width: 1; border-color: White;
                                                                                        border-style: dotted;" class="center">
                                                                                        JAM PRAKTEK
                                                                                    </td>
                                                                                    <td style="width: 80px; background-color: #FF9900; color: #ffffff; border-width: 1;
                                                                                        border-color: White; border-style: dotted;" class="center">
                                                                                        PRAKTEK
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" style="width: 100%; height: 30;" colspan="2">
                                                                <asp:Repeater ID="repPhysicianBySpecialtySum" runat="server" OnItemDataBound="repPhysicianBySpecialtySum_ItemDataBound">
                                                                    <HeaderTemplate>
                                                                        <ul id="ulRepPhysician">
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <li style="background-color: #BBCCCC; width: 100%;">
                                                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                                                <tr>
                                                                                    <td style="width: 200; height: 30; padding-left: 5;">
                                                                                        <%# DataBinder.Eval(Container.DataItem, "PhysicianName") %>
                                                                                    </td>
                                                                                    <td style="height: 30; font-size: 12pt;">
                                                                                        <table cellspacing="1" width="100%">
                                                                                            <tr>
                                                                                                <td style="border-width: 1; border-color: White; border-style: dotted;" class="center">
                                                                                                    <asp:ListView ID="lvwTIME" runat="server">
                                                                                                        <ItemTemplate>
                                                                                                            <li style="width: 100%">
                                                                                                                <%# DataBinder.Eval(Container.DataItem, "NotesDisplay")%>
                                                                                                                <%# DataBinder.Eval(Container.DataItem, "ScheduleTimeDisplay")%></li>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:ListView>
                                                                                                </td>
                                                                                                <td style="width: 80px; border-width: 1; border-color: White; border-style: dotted;"
                                                                                                    class="center">
                                                                                                    <%# DataBinder.Eval(Container.DataItem, "IsAvailable") %>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </li>
                                                                    </ItemTemplate>
                                                                    <AlternatingItemTemplate>
                                                                        <li style="background-color: #E3E4E6; width: 100%;">
                                                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                                                <tr>
                                                                                    <td style="width: 200; height: 30; padding-left: 5;">
                                                                                        <%# DataBinder.Eval(Container.DataItem, "PhysicianName") %>
                                                                                    </td>
                                                                                    <td style="height: 30; font-size: 12pt;">
                                                                                        <table cellspacing="1" width="100%">
                                                                                            <tr>
                                                                                                <td style="border-width: 1; border-color: White; border-style: dotted;" class="center">
                                                                                                    <asp:ListView ID="lvwTIME" runat="server">
                                                                                                        <ItemTemplate>
                                                                                                            <li style="width: 100%">
                                                                                                                <%# DataBinder.Eval(Container.DataItem, "NotesDisplay")%>
                                                                                                                <%# DataBinder.Eval(Container.DataItem, "ScheduleTimeDisplay")%></li>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:ListView>
                                                                                                </td>
                                                                                                <td style="width: 80px; border-width: 1; border-color: White; border-style: dotted;"
                                                                                                    class="center">
                                                                                                    <%# DataBinder.Eval(Container.DataItem, "IsAvailable")%>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </li>
                                                                    </AlternatingItemTemplate>
                                                                    <FooterTemplate>
                                                                        </ul>
                                                                    </FooterTemplate>
                                                                </asp:Repeater>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </li>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </ul>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <div id="bottomline" style="width: 100%;">
                                        <table width="100%">
                                            <tr>
                                                <td class="hseparator" style="width: 100%;" colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <marquee direction="left"><asp:Label ID="lblScrollingText" runat="server" Text="THIS IS SCROLLING TEXT..." Font-Bold="true" Font-Size="Large"></asp:Label></marquee>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlDetail" runat="server">
                                <asp:Repeater ID="repSpecialty" runat="server" OnItemDataBound="repSpecialty_ItemDataBound">
                                    <HeaderTemplate>
                                        <ul id="ulrepSpecialty">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <li>
                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td valign="top" style="width: 100%; height: 30;" colspan="2">
                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td class="Heading3" style="width: 250px; height: 30; padding-left: 5;">
                                                                    <%# DataBinder.Eval(Container.DataItem, "SpecialtyName")%>
                                                                </td>
                                                                <td valign="bottom" style="width: 900px; height: 30; background-color: #BABBBD; font-size: 12pt;">
                                                                    <table cellspacing="1">
                                                                        <tr>
                                                                            <td style="width: 150px; background-color: #30CD08; color: #ffffff; border-width: 1;
                                                                                border-color: White; border-style: dotted;" class="center">
                                                                                SENIN
                                                                            </td>
                                                                            <td style="width: 150px; background-color: #30CD08; color: #ffffff; border-width: 1;
                                                                                border-color: White; border-style: dotted;" class="center">
                                                                                SELASA
                                                                            </td>
                                                                            <td style="width: 150px; background-color: #30CD08; color: #ffffff; border-width: 1;
                                                                                border-color: White; border-style: dotted;" class="center">
                                                                                RABU
                                                                            </td>
                                                                            <td style="width: 150px; background-color: #30CD08; color: #ffffff; border-width: 1;
                                                                                border-color: White; border-style: dotted;" class="center">
                                                                                KAMIS
                                                                            </td>
                                                                            <td style="width: 150px; background-color: #30CD08; color: #ffffff; border-width: 1;
                                                                                border-color: White; border-style: dotted;" class="center">
                                                                                JUMAT
                                                                            </td>
                                                                            <td style="width: 150px; background-color: #30CD08; color: #ffffff; border-width: 1;
                                                                                border-color: White; border-style: dotted;" class="center">
                                                                                SABTU
                                                                            </td>
                                                                            <td style="width: 150px; background-color: #FF9900; color: #ffffff; border-width: 1;
                                                                                border-color: White; border-style: dotted;" class="center">
                                                                                MINGGU
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" style="width: 100%; height: 30;" colspan="2">
                                                        <asp:Repeater ID="repPhysicianBySpecialty" runat="server" OnItemDataBound="repPhysicianBySpecialty_ItemDataBound">
                                                            <HeaderTemplate>
                                                                <ul id="ulRepPhysician">
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <li style="background-color: #BBCCCC; width: 100%;">
                                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td style="width: 250px; height: 30; padding-left: 5;">
                                                                                <%# DataBinder.Eval(Container.DataItem, "PhysicianName") %>
                                                                            </td>
                                                                            <td style="width: 900px; height: 30; font-size: 12pt;">
                                                                                <table cellspacing="1">
                                                                                    <tr>
                                                                                        <td style="width: 150px; border-width: 1; border-color: White; border-style: dotted;"
                                                                                            class="center">
                                                                                            <asp:ListView ID="lvwMONi" runat="server">
                                                                                                <ItemTemplate>
                                                                                                    <li>
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "NotesDisplay")%>
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "ScheduleTimeDisplay")%></li>
                                                                                                </ItemTemplate>
                                                                                            </asp:ListView>
                                                                                        </td>
                                                                                        <td style="width: 150px; border-width: 1; border-color: White; border-style: dotted;"
                                                                                            class="center">
                                                                                            <asp:ListView ID="lvwTUEi" runat="server">
                                                                                                <ItemTemplate>
                                                                                                    <li>
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "NotesDisplay")%>
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "ScheduleTimeDisplay")%></li>
                                                                                                </ItemTemplate>
                                                                                            </asp:ListView>
                                                                                        </td>
                                                                                        <td style="width: 150px; border-width: 1; border-color: White; border-style: dotted;"
                                                                                            class="center">
                                                                                            <asp:ListView ID="lvwWEDi" runat="server">
                                                                                                <ItemTemplate>
                                                                                                    <li>
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "NotesDisplay")%>
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "ScheduleTimeDisplay")%></li>
                                                                                                </ItemTemplate>
                                                                                            </asp:ListView>
                                                                                        </td>
                                                                                        <td style="width: 150px; border-width: 1; border-color: White; border-style: dotted;"
                                                                                            class="center">
                                                                                            <asp:ListView ID="lvwTHUi" runat="server">
                                                                                                <ItemTemplate>
                                                                                                    <li>
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "NotesDisplay")%>
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "ScheduleTimeDisplay")%></li>
                                                                                                </ItemTemplate>
                                                                                            </asp:ListView>
                                                                                        </td>
                                                                                        <td style="width: 150px; border-width: 1; border-color: White; border-style: dotted;"
                                                                                            class="center">
                                                                                            <asp:ListView ID="lvwFRIi" runat="server">
                                                                                                <ItemTemplate>
                                                                                                    <li>
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "NotesDisplay")%>
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "ScheduleTimeDisplay")%></li>
                                                                                                </ItemTemplate>
                                                                                            </asp:ListView>
                                                                                        </td>
                                                                                        <td style="width: 150px; border-width: 1; border-color: White; border-style: dotted;"
                                                                                            class="center">
                                                                                            <asp:ListView ID="lvwSATi" runat="server">
                                                                                                <ItemTemplate>
                                                                                                    <li>
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "NotesDisplay")%>
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "ScheduleTimeDisplay")%></li>
                                                                                                </ItemTemplate>
                                                                                            </asp:ListView>
                                                                                        </td>
                                                                                        <td style="width: 150px; border-width: 1; border-color: White; border-style: dotted;"
                                                                                            class="center">
                                                                                            <asp:ListView ID="lvwSUNi" runat="server">
                                                                                                <ItemTemplate>
                                                                                                    <li>
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "NotesDisplay")%>
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "ScheduleTimeDisplay")%></li>
                                                                                                </ItemTemplate>
                                                                                            </asp:ListView>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </li>
                                                            </ItemTemplate>
                                                            <AlternatingItemTemplate>
                                                                <li style="background-color: #E3E4E6; width: 100%;">
                                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td style="width: 250px; height: 30; padding-left: 5;">
                                                                                <%# DataBinder.Eval(Container.DataItem, "PhysicianName") %>
                                                                            </td>
                                                                            <td style="width: 900px; height: 30; font-size: 12pt;">
                                                                                <table cellspacing="1">
                                                                                    <tr>
                                                                                        <td style="width: 150px; border-width: 1; border-color: White; border-style: dotted;"
                                                                                            class="center">
                                                                                            <asp:ListView ID="lvwMONi" runat="server">
                                                                                                <ItemTemplate>
                                                                                                    <li>
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "NotesDisplay")%>
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "ScheduleTimeDisplay")%></li>
                                                                                                </ItemTemplate>
                                                                                            </asp:ListView>
                                                                                        </td>
                                                                                        <td style="width: 150px; border-width: 1; border-color: White; border-style: dotted;"
                                                                                            class="center">
                                                                                            <asp:ListView ID="lvwTUEi" runat="server">
                                                                                                <ItemTemplate>
                                                                                                    <li>
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "NotesDisplay")%>
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "ScheduleTimeDisplay")%></li>
                                                                                                </ItemTemplate>
                                                                                            </asp:ListView>
                                                                                        </td>
                                                                                        <td style="width: 150px; border-width: 1; border-color: White; border-style: dotted;"
                                                                                            class="center">
                                                                                            <asp:ListView ID="lvwWEDi" runat="server">
                                                                                                <ItemTemplate>
                                                                                                    <li>
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "NotesDisplay")%>
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "ScheduleTimeDisplay")%></li>
                                                                                                </ItemTemplate>
                                                                                            </asp:ListView>
                                                                                        </td>
                                                                                        <td style="width: 150px; border-width: 1; border-color: White; border-style: dotted;"
                                                                                            class="center">
                                                                                            <asp:ListView ID="lvwTHUi" runat="server">
                                                                                                <ItemTemplate>
                                                                                                    <li>
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "NotesDisplay")%>
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "ScheduleTimeDisplay")%></li>
                                                                                                </ItemTemplate>
                                                                                            </asp:ListView>
                                                                                        </td>
                                                                                        <td style="width: 150px; border-width: 1; border-color: White; border-style: dotted;"
                                                                                            class="center">
                                                                                            <asp:ListView ID="lvwFRIi" runat="server">
                                                                                                <ItemTemplate>
                                                                                                    <li>
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "NotesDisplay")%>
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "ScheduleTimeDisplay")%></li>
                                                                                                </ItemTemplate>
                                                                                            </asp:ListView>
                                                                                        </td>
                                                                                        <td style="width: 150px; border-width: 1; border-color: White; border-style: dotted;"
                                                                                            class="center">
                                                                                            <asp:ListView ID="lvwSATi" runat="server">
                                                                                                <ItemTemplate>
                                                                                                    <li>
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "NotesDisplay")%>
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "ScheduleTimeDisplay")%></li>
                                                                                                </ItemTemplate>
                                                                                            </asp:ListView>
                                                                                        </td>
                                                                                        <td style="width: 150px; border-width: 1; border-color: White; border-style: dotted;"
                                                                                            class="center">
                                                                                            <asp:ListView ID="lvwSUNi" runat="server">
                                                                                                <ItemTemplate>
                                                                                                    <li>
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "NotesDisplay")%>
                                                                                                        <%# DataBinder.Eval(Container.DataItem, "ScheduleTimeDisplay")%></li>
                                                                                                </ItemTemplate>
                                                                                            </asp:ListView>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </li>
                                                            </AlternatingItemTemplate>
                                                            <FooterTemplate>
                                                                </ul>
                                                            </FooterTemplate>
                                                        </asp:Repeater>
                                                    </td>
                                                </tr>
                                            </table>
                                        </li>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </ul>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </asp:Panel>
                            <asp:Panel ID="pnlEdit" runat="server">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <table width="100%" cellspacing="1" cellpadding="1">
                                                <tr>
                                                    <td class="right" style="background-color: #FF9900; color: #ffffff; width: 150;">
                                                        Dokter
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlPhysician" runat="server" Width="300" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    <tr>
                                        <td class="Heading2">
                                            Edit Jadwal Praktek Dokter
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%" cellspacing="1" cellpadding="1">
                                                <tr>
                                                    <td class="right" style="background-color: #30CD08; color: #ffffff; width: 150;">
                                                        Klinik
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlClinic" runat="server" Width="300" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background-color: #30CD08; color: #ffffff;">
                                                        Shift
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlShift" runat="server" Width="300" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background-color: #30CD08; color: #ffffff;">
                                                        Jadwal Praktek<br />
                                                        (format hh:mm)
                                                    </td>
                                                    <td>
                                                        <table cellspacing="1">
                                                            <tr>
                                                                <td class="center" style="background-color: #30CD08; color: #ffffff; width: 200;">
                                                                    SENIN
                                                                </td>
                                                                <td class="center" style="background-color: #30CD08; color: #ffffff; width: 200;">
                                                                    SELASA
                                                                </td>
                                                                <td class="center" style="background-color: #30CD08; color: #ffffff; width: 200;">
                                                                    RABU
                                                                </td>
                                                                <td class="center" style="background-color: #30CD08; color: #ffffff; width: 200;">
                                                                    KAMIS
                                                                </td>
                                                                <td class="center" style="background-color: #30CD08; color: #ffffff; width: 200;">
                                                                    JUMAT
                                                                </td>
                                                                <td class="center" style="background-color: #30CD08; color: #ffffff; width: 200;">
                                                                    SABTU
                                                                </td>
                                                                <td class="center" style="background-color: #FF9900; color: #ffffff; width: 200;">
                                                                    MINGGU
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox ID="txtsMON" runat="server" Width="80"></asp:TextBox>
                                                                    <asp:TextBox ID="txteMON" runat="server" Width="80"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtsTUE" runat="server" Width="80"></asp:TextBox>
                                                                    <asp:TextBox ID="txteTUE" runat="server" Width="80"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtsWED" runat="server" Width="80"></asp:TextBox>
                                                                    <asp:TextBox ID="txteWED" runat="server" Width="80"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtsTHU" runat="server" Width="80"></asp:TextBox>
                                                                    <asp:TextBox ID="txteTHU" runat="server" Width="80"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtsFRI" runat="server" Width="80"></asp:TextBox>
                                                                    <asp:TextBox ID="txteFRI" runat="server" Width="80"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtsSAT" runat="server" Width="80"></asp:TextBox>
                                                                    <asp:TextBox ID="txteSAT" runat="server" Width="80"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtsSUN" runat="server" Width="80"></asp:TextBox>
                                                                    <asp:TextBox ID="txteSUN" runat="server" Width="80"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background-color: #30CD08; color: #ffffff;">
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnSaveJadwal" runat="server" Text="Simpan" Width="100" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Heading2">
                                            Edit Dokter Praktek
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%" cellspacing="1" cellpadding="1">
                                                <tr>
                                                    <td class="right" style="background-color: #30CD08; color: #ffffff;">
                                                        Hari ini Praktek?
                                                    </td>
                                                    <td>
                                                        <asp:RadioButtonList ID="rbtnIsAvailable" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="YA" Value="True"></asp:ListItem>
                                                            <asp:ListItem Text="TIDAK" Value="False"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background-color: #30CD08; color: #ffffff; width: 150;">
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnSavePraktek" runat="server" Text="Simpan" Width="100" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Heading2">
                                            Edit Teks Berjalan
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%" cellspacing="1" cellpadding="1">
                                                <tr>
                                                    <td class="right" style="background-color: #30CD08; color: #ffffff; width: 150;">
                                                        Teks Berjalan
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtScrollingText" runat="server" Width="600"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background-color: #30CD08; color: #ffffff;">
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnSaveScrollingText" runat="server" Text="Simpan" Width="100" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
