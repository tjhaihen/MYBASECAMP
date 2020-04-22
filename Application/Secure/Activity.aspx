<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../incl/calendar.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Activity.aspx.vb" Inherits="QIS.Web.Secure.Activity" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Activity</title>
    <link rel="title icon" href="/qistoollib/images/favicon.png" />
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href='/qistoollib/css/styles_blue.css' type="text/css" rel="Stylesheet" />
    <script language="javascript" type="text/javascript" src="/qistoollib/scripts/JScript.js"></script>
    <script type="text/javascript" language="javascript" src='/qistoollib/scripts/common/common.js'></script>
    <style type="text/css">
        #ulRepProgressPeriod
        {
            width: 100%;
            margin: 0;
            padding: 0;
        }
        #ulRepProgressPeriod li
        {
            list-style-type: none;
        }
    </style>
</head>
<body>
    <form id="frm" runat="server">
    <table border="0" width="100%" cellspacing="2" cellpadding="1" style="height: 100%;">
        <tr>
            <td width="100%" valign="top">
                <!-- BEGIN PAGE HEADER -->
                <Module:RadMenu ID="RadMenu" runat="server" />
                <!-- END PAGE HEADER -->
            </td>
        </tr>
        <tr>
            <td width="100%" height="100%" valign="top">
                <div style="width: 100%; height: 100%; overflow: auto;">
                    <table cellspacing="10" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td align="left">
                                <table cellspacing="0" cellpadding="5" width="100%">
                                    <tr>
                                        <td class="rheader">
                                            Activity
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" style="width: 100%;">
                                        </td>
                                    </tr>
                                    <tr class="rbody">
                                        <td valign="top">
                                            <table width="100%">
                                                <tr>
                                                    <td style="width: 50;">
                                                        <Module:CSSToolbar ID="CSSToolbar" runat="server"></Module:CSSToolbar>
                                                    </td>
                                                    <td style="width: 120;" class="right">
                                                        Review Period
                                                    </td>
                                                    <td style="width: 150;">
                                                        <asp:DropDownList ID="ddlPeriod" runat="server" Width="100%" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:Panel ID="pnlCustomPeriod" runat="server">
                                                            <Module:Calendar ID="calStartDate" runat="server" DontResetDate="true" />
                                                            &nbsp;to&nbsp;
                                                            <Module:Calendar ID="calEndDate" runat="server" DontResetDate="true" />
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" style="width: 100%;">
                                        </td>
                                    </tr>
                                    <tr class="rbody">
                                        <td valign="top">
                                            <asp:Panel ID="pnlDailyActivity" runat="server">
                                                <asp:Repeater ID="repProgressPeriod" runat="server" OnItemDataBound="repProgressPeriod_ItemDataBound">
                                                    <HeaderTemplate>
                                                        <ul id="ulRepProgressPeriod">
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <li>
                                                            <table cellspacing="1" width="100%">
                                                                <tr>
                                                                    <td class="gridHeaderStyle Heading3 center" style="width: 120; height: 30;">
                                                                        <%# DataBinder.Eval(Container.DataItem, "ProgressDateDisplay") %>
                                                                    </td>
                                                                    <td style="background-image: url('/qistoollib/images/timeline_dot.png'); background-repeat: repeat-x;">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Panel ID="pnlProgressDescription" runat="server">
                                                                            <asp:Repeater ID="repProgressPeriod_Contributor" runat="server" OnItemDataBound="repProgressPeriod_Contributor_ItemDataBound">
                                                                                <HeaderTemplate>
                                                                                    <ul id="ulrepProgressPeriod_Contributor">
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <li>
                                                                                        <table cellspacing="1" width="100%">
                                                                                            <tr>
                                                                                                <td class="gridAlternatingItemStyle right" style="width: 120; height: 30; font-weight: bold;">
                                                                                                    <%# DataBinder.Eval(Container.DataItem, "fullName") %>
                                                                                                </td>
                                                                                                <td style="background-image: url('/qistoollib/images/timeline_dot.png'); background-repeat: repeat-x;">
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:Repeater ID="repProgressPeriod_Contributor_Detail" runat="server">
                                                                                                        <HeaderTemplate>
                                                                                                            <ul id="ul1">
                                                                                                        </HeaderTemplate>
                                                                                                        <ItemTemplate>
                                                                                                            <li>
                                                                                                                <table cellspacing="1" width="100%">
                                                                                                                    <tr>
                                                                                                                        <td style="width: 80;" class="txterrmsg center">
                                                                                                                            [<%# DataBinder.Eval(Container.DataItem, "lastUpdateTime") %>]
                                                                                                                        </td>
                                                                                                                        <td>
                                                                                                                            <%# DataBinder.Eval(Container.DataItem, "progressDescription") %>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </li>
                                                                                                        </ItemTemplate>
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
                                                                        <asp:Panel ID="pnlNoActivity" runat="server">
                                                                            <table cellspacing="1" width="100%">
                                                                                <tr>
                                                                                    <td class="center" style="font-size: 14pt; font-weight: bold; color: #cccccc;">
                                                                                        No Activity
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </asp:Panel>
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
                                            <asp:Panel ID="pnlActivityByPeople" runat="server">
                                                <asp:DataGrid ID="grdUser" runat="server" BorderWidth="0" GridLines="None" Width="100%"
                                                    CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false" AutoGenerateColumns="false">
                                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                    <ItemStyle CssClass="gridItemStyle" />
                                                    <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                    <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                    <Columns>
                                                        <asp:TemplateColumn runat="server" HeaderText="Username">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Username") %>'
                                                                    ID="_lblUsername" />
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn runat="server" HeaderText="Username">
                                                            <ItemTemplate>

                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                </asp:DataGrid>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td valign="bottom" style="padding-left: 20px">
                <!-- BEGIN PAGE FOOTER-->
                <Module:Copyright ID="mdlCopyRight" runat="server" PathPrefix=".."></Module:Copyright>
                <!-- END PAGE FOOTER-->
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
