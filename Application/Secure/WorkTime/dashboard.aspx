<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../../incl/CSSToolbar.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="dashboard.aspx.vb" Inherits="QIS.Web.WorkTime.Dashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Medinfras Worktime Dashboard</title>
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
            background: #606060;
            width: 20px;
            height: 20px;
            margin: 0px;
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
            <td valign="top" style="width: 100%;">
                <table width="100%">
                    <tr>
                        <td class="Heading2">
                            <asp:Label ID="lblPageTitle" runat="server" Text="Worktime Dashboard"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="hseparator">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <Module:CSSToolbar ID="CSSToolbar" runat="server"></Module:CSSToolbar>
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
                            <asp:DropDownList ID="ddlMonth" runat="server" Width="150" AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DataGrid ID="grdActivePeople" runat="server" BorderWidth="0" GridLines="None"
                                Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="True" ShowFooter="false"
                                AutoGenerateColumns="false">
                                <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                <ItemStyle CssClass="gridItemStyle" />
                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                <Columns>
                                    <asp:TemplateColumn runat="server" HeaderText="Team Name" ItemStyle-Width="200">
                                        <ItemTemplate>
                                            <asp:Label ID="_lblUserID" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "userID") %>'></asp:Label>
                                            <%# DataBinder.Eval(Container.DataItem, "fullName") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn runat="server" HeaderText="Worktime">
                                        <ItemTemplate>
                                            <asp:Repeater ID="_repDateInMonthByPeople" runat="server">
                                                <HeaderTemplate>
                                                    <ul id="ulRepDateInMonthDt">
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <li>
                                                        <asp:Panel ID="pnlHEXColor" runat="server" Width="100%" BackColor="#606060" ForeColor="#FFFFFF" CssClass="center" Visible='<%# DataBinder.Eval(Container.DataItem, "IsChecked")=0 %>'>
                                                            <%# Left(Format(DataBinder.Eval(Container.DataItem, "DateInMonth"), "{0:dd/MM/yyyy}"),2) %>
                                                        </asp:Panel>
                                                        <asp:Panel ID="pnlHEXColorFilled" runat="server" Width="100%" BackColor="#017BCD" ForeColor="#FFFFFF" CssClass="center" Visible='<%# DataBinder.Eval(Container.DataItem, "IsChecked") %>'>
                                                            <%# Left(Format(DataBinder.Eval(Container.DataItem, "DateInMonth"), "{0:dd/MM/yyyy}"),2) %>
                                                        </asp:Panel>
                                                    </li>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    </ul>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                            </asp:DataGrid>
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
