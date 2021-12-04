<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../../incl/calendar.ascx" %>
<%@ Register TagPrefix="Module" TagName="ProjectBanner" Src="../../incl/projectBanner.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CustomerDashboard.aspx.vb"
    Inherits="QIS.Web.CustomerDashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Basecamp - Customer Dashboard</title>
    <link rel="title icon" href="/qistoollib/images/favicon.png" />
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href="/qistoollib/css/styles_blue.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
        // Load google charts
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);

        // Draw the chart and set the chart values
        function drawChart() {
            var oByType = <%=GetIssueBy("ByType") %>
            var dataByType = google.visualization.arrayToDataTable(oByType);

            // Optional; add a title and set the width and height of the chart
            var optionsByType = { 'title': 'By Type', 'width': 350, 'height': 300 };

            // Display the chart inside the <div> element
            var chartByType = new google.visualization.PieChart(document.getElementById('issuebytype'));
            chartByType.draw(dataByType, optionsByType);

            var oByPriority = <%=GetIssueBy("ByPriority") %>
            var dataByPriority = google.visualization.arrayToDataTable(oByPriority);

            // Optional; add a title and set the width and height of the chart
            var optionsByPriority = { 'title': 'By Priority', 'width': 350, 'height': 300, 'pieHole': 0.4 };

            // Display the chart inside the <div> element
            var chartByPriority = new google.visualization.PieChart(document.getElementById('issuebypriority'));
            chartByPriority.draw(dataByPriority, optionsByPriority);

            var oByRoadmap = <%=GetIssueBy("ByProductRoadmap") %>
            var dataByRoadmap = google.visualization.arrayToDataTable(oByRoadmap);

            // Optional; add a title and set the width and height of the chart
            var optionsByRoadmap = { 'title': 'By Product Roadmap', 'width': 550, 'height': 300, legend: { position: "none" } };

            // Display the chart inside the <div> element
            var chartByRoadmap = new google.visualization.BarChart(document.getElementById('issuebyproductroadmap'));
            chartByRoadmap.draw(dataByRoadmap, optionsByRoadmap);
        }
    </script>
    <table width="100%" cellpadding="2" cellspacing="0">
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
                        <td class="Heading2" colspan="2">
                            <asp:Label ID="lblPageTitle" runat="server" Text="Customer Page: Dashboard"></asp:Label>
                        </td>
                        <td class="right">
                            <asp:ImageButton ID="ibtnViewDashboard" runat="server" ImageUrl="/qistoollib/images/ico-dashboard.png"
                                ToolTip="Dashboard" Width="32" />
                            <asp:ImageButton ID="ibtnViewDetail" runat="server" ImageUrl="/qistoollib/images/ico-detail.png"
                                ToolTip="Detail" Width="32" />
                        </td>
                    </tr>
                    <tr>
                        <td class="hseparator" colspan="3">
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td style="width: 100%;">
                            <table width="100%" cellspacing="0">
                                <tr style="background-image: linear-gradient(#E0FCFB, #ffffff);">
                                    <td style="width: 150;">
                                        <table>
                                            <tr>
                                                <td>
                                                    <Module:CSSToolbar ID="CSSToolbar" runat="server"></Module:CSSToolbar>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="middle">
                                        <table width="100%">
                                            <tr>
                                                <td style="width: 120;" class="right">
                                                    Project
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlProjectFilter" runat="server" Width="200">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td class="txtlessstrong">
                                                    Current Patch:&nbsp;<asp:Label ID="lblLastPatchNo" runat="server" Font-Bold="true"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="middle" class="right">
                                        <table cellspacing="1" cellpadding="2" width="100%" style="background-color: #CDF4F3;">
                                            <tr>
                                                <td style="background: #ffffff; width: 120; opacity: 0.7;" class="center">
                                                    Total Issue
                                                </td>
                                                <td style="background: #ffffff; width: 120; opacity: 0.7" class="center">
                                                    Total Open
                                                </td>
                                                <td style="background: #ffffff; width: 120; opacity: 0.7" class="center">
                                                    Total In Progress
                                                </td>
                                                <td style="background: #ffffff; width: 120; opacity: 0.7" class="center">
                                                    Total Dev.Finish
                                                </td>
                                                <td style="background: #ffffff; width: 120; opacity: 0.7" class="center">
                                                    Total Finish
                                                </td>
                                                <td style="background: #ffffff; width: 120; opacity: 0.7; font-weight: bold;" class="center">
                                                    Progress
                                                </td>
                                            </tr>
                                            <tr style="font-size: large;">
                                                <td style="background: #ffffff; width: 120; font-size: 24;" class="center">
                                                    <asp:Label ID="lblTotalIssueAll" runat="server"></asp:Label>
                                                </td>
                                                <td style="background: #ffffff; width: 120; font-size: 24;" class="center">
                                                    <asp:Label ID="lblTotalOpen" runat="server"></asp:Label>
                                                </td>
                                                <td style="background: #ffffff; width: 120; font-size: 24;" class="center">
                                                    <asp:Label ID="lblTotalInProgress" runat="server"></asp:Label>
                                                </td>
                                                <td style="background: #ffffff; width: 120; font-size: 24;" class="center">
                                                    <asp:Label ID="lblTotalDevFinish" runat="server"></asp:Label>
                                                </td>
                                                <td style="background: #ffffff; width: 120; font-size: 24;" class="center">
                                                    <asp:Label ID="lblTotalFinish" runat="server"></asp:Label>
                                                </td>
                                                <td style="background: #ffffff; width: 120; font-size: 24; font-weight: bold;" class="center">
                                                    <asp:Label ID="lblProgress" runat="server"></asp:Label>&nbsp;%
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="hseparator" colspan="3">
                        </td>
                    </tr>
                </table>
                <table width="100%" cellpadding="5">
                    <tr>
                        <td style="background-color: #eeeeee;" colspan="3">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <div id="issuebytype">
                                        </div>
                                    </td>
                                    <td>
                                        <div id="issuebypriority">
                                        </div>
                                    </td>
                                    <td>
                                        <div id="issuebyproductroadmap">
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
