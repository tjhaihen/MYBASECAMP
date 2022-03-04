<%@ Register TagPrefix="Module" TagName="Copyright" Src="../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../incl/calendar.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../incl/CSSToolbar.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TicketManagement.aspx.vb"
    Inherits="QIS.Web.TicketManagement" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>--%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Medinfras Basecamp - Ticket Management</title>
    <link rel="title icon" href="/qistoollib/images/favicon.png" />
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href="/qistoollib/css/styles_blue.css" type="text/css" rel="Stylesheet" />
    <script language="javascript" type="text/javascript" src="/qistoollib/scripts/JScript.js"></script>
    <style type="text/css">
        #ulRepTicketByStatus
        {
            width: 100%;
            margin: 0;
            padding: 0;
        }
        #ulRepTicketByStatus li
        {
            list-style-type: none;
            display: inline-block; /* FF3.6; Chrome10+ */                     
            *display: inline;
            border-radius: 10px;
            background: #eeeeee;
            width: 320px;
            height: 240px;
            margin: 3px;
            padding: 5px;
        }
        #rcorners1 {
          border-radius: 5px;
          background: #b5d0f8;
          color: #000000;
          padding: 5px;
        }
        #rcorners2 {
          border-radius: 5px;
          background: #acefe8;
          color: #000000;
          padding: 5px;
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
                            <asp:Label ID="lblPageTitle" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="hseparator">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Repeater ID="repTicketByStatus" runat="server" OnItemCommand="repTicketByStatus_ItemCommand"
                                OnItemDataBound="repTicketByStatus_ItemDataBound">
                                <HeaderTemplate>
                                    <ul id="ulRepTicketByStatus">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <table cellspacing="1" width="100%">
                                            <tr>
                                                <td class="Heading3" style="width: 50%;">
                                                    <asp:Label ID="_lblTicketStatusSCode" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "TicketStatusSCode") %>'></asp:Label>
                                                    <asp:Label ID="_lblTicketStatusName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TicketStatusName") %>'></asp:Label>
                                                </td>
                                                <%--print--%>
                                                <td valign="top" align="right">
                                                    <asp:ImageButton ID="_ibtnGoToProjectDetailPage" runat="server" ImageUrl="/qistoollib/images/viewDetail.png"
                                                        ToolTip="View Project Detail" CommandName="ViewDetail" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="height: 4;">
                                                    <asp:Panel ID="pnlHEXColor" runat="server" Width="100%" Height="5" BackColor="#666666">
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="txtlessstrong" colspan="2">
                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="txtweak" colspan="2">
                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="txtweak" colspan="2">
                                                    Last updated:&nbsp;<%# DataBinder.Eval(Container.DataItem, "lastUpdateDate") %>
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
