<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../../incl/calendar.ascx" %>
<%@ Register TagPrefix="Module" TagName="ProjectBanner" Src="../../incl/projectBanner.ascx" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Basecamp - Dashboard 01</title>
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
    <table width="100%" cellpadding="2" cellspacing="0">
        <tr>
            <td valign="top" style="width: 100%;">
                <table width="100%">
                    <tr>
                        <td class="Heading2">
                            <asp:Label ID="lblCurrentMonth" runat="server" Text="This Month: April 2022"></asp:Label>
                        </td>
                        <td class="right">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="right">
                                        Project Group
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlProjectGroupFilter" runat="server" Width="200">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="right" style="width: 100;">
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
                        <td style="background-color: #eeeeee;">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <table cellspacing="5">
                                            <tr>
                                                <td style="background-color:#ffffff; width: 200; height: 50; text-align: center; vertical-align:middle;">
                                                    <asp:Label ID="lblCOUNTIssueFinish" runat="server" Text="125" Font-Size="X-Large"></asp:Label><br />
                                                    Issues Finished<br />
                                                    <asp:Image ID="imgCOUNTIssueFinishDiff" runat="server" />
                                                    <asp:Label ID="lblCOUNTIssueFinishDiff" runat="server" Text="10" Font-Size="Large"></asp:Label>&nbsp;from
                                                    last month
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="background-color:#ffffff; width: 200; height: 50; text-align: center; vertical-align:middle;">
                                                    <asp:Label ID="Label1" runat="server" Text="83" Font-Size="X-Large"></asp:Label><br />
                                                    Issues Reported<br />
                                                    <asp:Image ID="Image1" runat="server" />
                                                    <asp:Label ID="Label2" runat="server" Text="2" Font-Size="Large"></asp:Label>&nbsp;from
                                                    last month
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="background-color:#ffffff; width: 200; height: 50; text-align: center; vertical-align:middle;">
                                                    <asp:Label ID="Label3" runat="server" Text="1205/897" Font-Size="X-Large"></asp:Label><br />
                                                    Total Issues Reported/Finished<br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="background-color:#ffffff; width: 200; height: 50; text-align: center; vertical-align:middle;">
                                                    GAUGE<br />
                                                    Target >- 75%<br />
                                                    Percentage of Finished Issues
                                                </td>
                                            </tr>
                                        </table>
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
