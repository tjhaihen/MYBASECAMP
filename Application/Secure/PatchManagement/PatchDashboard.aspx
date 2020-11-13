<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../../incl/calendar.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../../incl/CSSToolbar.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PatchDashboard.aspx.vb"
    Inherits="QIS.Web.PatchManagement.PatchDashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Medinfras Patch Dashboard</title>
    <link rel="title icon" href="/qistoollib/images/favicon.png" />
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href="/qistoollib/css/styles_blue.css" type="text/css" rel="Stylesheet" />
    <script language="javascript" type="text/javascript" src="/qistoollib/scripts/JScript.js"></script>
    <style type="text/css">
        #rcorners1 {
          border-radius: 5px;
          background: #448ef8;
          color: #ffffff;
          padding: 5px;
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server">
    <table width="100%" cellpadding="2" cellspacing="0">
        <tr>
            <td valign="top" style="width: 100%;">
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
                            <asp:Label ID="lblPageTitle" runat="server" Text="Patch Dashboard"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="hseparator">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td style="width: 50;">
                                        <Module:CSSToolbar ID="CSSToolbar" runat="server">
                                        </Module:CSSToolbar>
                                    </td>
                                    <td style="width: 120;" class="right">
                                        Patch Period
                                    </td>
                                    <td>
                                        <Module:Calendar ID="calStartDate" runat="server" DontResetDate="true" />
                                        &nbsp;to&nbsp;
                                        <Module:Calendar ID="calEndDate" runat="server" DontResetDate="true" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="hseparator" style="width: 100%;">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%">
                            <div id="div1" style="overflow: auto; width: 100%;">
                                <asp:DataGrid ID="grdPatchDashboard" runat="server" BorderWidth="0" GridLines="None"
                                    Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="True" ShowFooter="false"
                                    AutoGenerateColumns="true">
                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" Width="150" Wrap="true" />
                                    <ItemStyle CssClass="gridItemStyle" Width="150" Wrap="true" />
                                    <AlternatingItemStyle CssClass="gridAlternatingItemStyle" Width="150" Wrap="true" />
                                </asp:DataGrid>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="bottom">
                <!-- BEGIN PAGE FOOTER-->
                <Module:Copyright ID="mdlCopyRight" runat="server" pathprefix="..">
                </Module:Copyright>
                <!-- END PAGE FOOTER-->
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
