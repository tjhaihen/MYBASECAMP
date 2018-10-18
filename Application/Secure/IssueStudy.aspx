<%@ Register TagPrefix="Module" TagName="Copyright" Src="../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../incl/calendar.ascx" %>
<%@ Register TagPrefix="Module" TagName="ProjectBanner" Src="../incl/projectBanner.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="IssueStudy.aspx.vb" Inherits="QIS.Web.IssueStudy" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Basecamp - Issue Study</title>
    <link rel="title icon" href="/qistoollib/images/favicon.png" />
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href="/qistoollib/css/styles_blue.css" type="text/css" rel="Stylesheet" />
    <script language="javascript" type="text/javascript" src="/qistoollib/scripts/JScript.js"></script>
    <style type="text/css">
        #ulRepStudy
        {
            width: 100%;
            margin: 0;
            padding: 0;
        }
        #ulRepStudy li
        {
            list-style-type: none;
        }
        #ulRepResponse
        {
            width: 100%;
            margin: 0;
            padding: 0;
        }
        pre
        {
            max-width: 750;
            font-family: Segoe UI;
            white-space: pre-wrap; /* Since CSS 2.1 */
            white-space: -moz-pre-wrap; /* Mozilla, since 1999 */
            white-space: -pre-wrap; /* Opera 4-6 */
            white-space: -o-pre-wrap; /* Opera 7 */
            word-wrap: break-word; /* Internet Explorer 5.5+ *
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
                        <td valign="middle" style="width: 34;">
                            <asp:ImageButton ID="ibtnMyProjects" runat="server" ImageUrl="/qistoollib/images/myprojects.png" alt="My Projects" />
                        </td>
                        <td valign="middle">
                            <asp:LinkButton ID="lbtnMyProjects" runat="server" Text="My Projects" CausesValidation="false"></asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%;" class="hseparator" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" style="width: 34;">
                            <asp:ImageButton ID="ibtnMyAssignments" runat="server" ImageUrl="/qistoollib/images/myassignments.png" alt="My Assignments" />
                        </td>
                        <td valign="middle">
                            <asp:LinkButton ID="lbtnMyAssignments" runat="server" Text="My Assignments" CausesValidation="false"></asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%;" class="hseparator" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" style="width: 34;">
                            <asp:ImageButton ID="ibtnFollowUpIssue" runat="server" ImageUrl="/qistoollib/images/followupissue.png" alt="Follow Up Issue" />
                        </td>
                        <td valign="middle">
                            <asp:LinkButton ID="lbtnFollowUpIssue" runat="server" Text="Follow Up Issue" CausesValidation="false"></asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%;" class="hseparator" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" style="width: 34;">
                            <asp:ImageButton ID="ibtnIssueStudy" runat="server" ImageUrl="/qistoollib/images/issuestudy.png" alt="Issue Study" />
                        </td>
                        <td valign="middle">
                            <asp:LinkButton ID="lbtnIssueStudy" runat="server" Text="Issue Study" CausesValidation="false"></asp:LinkButton>
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
                        <td class="Heading2" colspan="3">
                            <asp:Label ID="lblPageTitle" runat="server" Text="Issue Study"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="hseparator" colspan="3">
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td style="width: 60%;">
                            <table>
                                <tr>
                                    <td style="width: 100;">
                                        <table>
                                            <tr>
                                                <td>
                                                    <Module:CSSToolbar ID="CSSToolbar" runat="server"></Module:CSSToolbar>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td style="width: 120;" class="right">
                                                    Keywords
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtKeywords" runat="server" Width="300"></asp:TextBox>
                                                </td>
                                                <td style="width: 120;" class="right">
                                                    Search in
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlProjectFilter" runat="server" Width="200">
                                                    </asp:DropDownList>
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
                    <tr>
                        <td colspan="3">
                            <asp:Repeater ID="repIssue" runat="server" OnItemDataBound="repIssue_ItemDataBound">
                                <HeaderTemplate>
                                    <ul id="ulRepStudy">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <table cellspacing="1">
                                            <tr>
                                                <td style="width: 750; min-width: 750; font-size: 11pt;" valign="top">
                                                    <pre><%# DataBinder.Eval(Container.DataItem, "issueDescription")%></pre>
                                                </td>
                                                <td style="width: 400;" class="txtweak" valign="top">
                                                    <%# DataBinder.Eval(Container.DataItem, "departmentName")%>
                                                    &nbsp;|&nbsp;<%# DataBinder.Eval(Container.DataItem, "reportedBy")%>&nbsp;on&nbsp;<%# Format(DataBinder.Eval(Container.DataItem, "reportedDate"),"dd-MMM-yyyy") %>
                                                    &nbsp;|&nbsp;Type:&nbsp;<%# DataBinder.Eval(Container.DataItem, "issueTypeName")%>
                                                    <br />
                                                    <%# DataBinder.Eval(Container.DataItem, "projectGroupName") %>&nbsp;|&nbsp;<%# DataBinder.Eval(Container.DataItem, "projectAliasName") %>&nbsp;|&nbsp;
                                                    Status:
                                                    <%# DataBinder.Eval(Container.DataItem, "issueStatusName")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="padding-left: 50;">
                                                    <asp:Panel ID="pnlIssueResponse" runat="server" Width="100%">
                                                        <asp:Repeater ID="repIssueResponse" runat="server">
                                                            <HeaderTemplate>
                                                                <ul id="ulRepResponse">
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <li>
                                                                    <table cellspacing="1" width="100%">
                                                                        <tr>
                                                                            <td class="hseparator">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="font-size: 9pt;" class="txterrmsg" valign="top">
                                                                                <%# Format(DataBinder.Eval(Container.DataItem, "updateDate"),"dd-MMM-yyyy hh:mm")%>&nbsp;|&nbsp;<%# DataBinder.Eval(Container.DataItem, "userNameUpdate")%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td valign="top">
                                                                                <asp:TextBox ID="txtResponseDescription" runat="server" TextMode="MultiLine" Text='<%# DataBinder.Eval(Container.DataItem, "responseDescription") %>'
                                                                                    Height="80" Width="800" ReadOnly="true" Font-Names="Segoe UI" BorderStyle="None"></asp:TextBox>
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
                                                    <asp:Panel ID="pnlNoResponse" runat="server">
                                                        <table cellspacing="1" width="100%">
                                                            <tr>
                                                                <td class="hseparator">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="font-size: 14pt; font-weight: bold; color: #cccccc;">
                                                                    No Response
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="hseparator" colspan="3">
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
                <Module:Copyright ID="mdlCopyRight" runat="server" PathPrefix=".."></Module:Copyright>
                <!-- END PAGE FOOTER-->
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
