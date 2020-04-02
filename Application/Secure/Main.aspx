<%@ Register TagPrefix="Module" TagName="Copyright" Src="../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../incl/CSSToolbar.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Main.aspx.vb" Inherits="QIS.Web.Main" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Medinfras Basecamp - Home</title>
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
            width: 300px;
            height: 150px;
            margin: 3px;
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
                        <td colspan="2">
                            <table width="100%" style="background-color: #f0f0f0; color: #000000; font-size: 9pt;" cellspacing="0" cellpadding="1">
                                <tr>
                                    <td colspan="3">
                                        <b>My Tasks</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%;" class="hseparator" colspan="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chkWorktime" runat="server" Enabled="false" />
                                    </td>
                                    <td>
                                        Today Worktime
                                    </td>
                                    <td class="right">
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chkAssignments" runat="server" Enabled="false" />
                                    </td>
                                    <td>
                                        Assignments
                                    </td>
                                    <td class="right">
                                        <asp:Label ID="lblAssignmentsTotal" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chkUrgents" runat="server" Enabled="false" />
                                    </td>
                                    <td style="color: red;">
                                        Urgents
                                    </td>
                                    <td class="right" style="color: red;">
                                        <asp:Label ID="lblUrgentsTotal" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" style="width: 34;">
                            <asp:ImageButton ID="ibtnMyProjects" runat="server" ImageUrl="/qistoollib/images/myprojects.png"
                                alt="My Projects" />
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
                            <asp:ImageButton ID="ibtnMyAssignments" runat="server" ImageUrl="/qistoollib/images/myassignments.png"
                                alt="My Assignments" />
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
                            <asp:ImageButton ID="ibtnFollowUpIssue" runat="server" ImageUrl="/qistoollib/images/followupissue.png"
                                alt="Follow Up Issue" />
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
                            <asp:ImageButton ID="ibtnIssueStudy" runat="server" ImageUrl="/qistoollib/images/issuestudy.png"
                                alt="Issue Study" />
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
                        <td class="Heading2">
                            <asp:Label ID="lblPageTitle" runat="server"></asp:Label>
                            <asp:CheckBox ID="chkIsMyAssignment" runat="server" Visible="false"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="hseparator">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Repeater ID="repMyProjectGroups" runat="server">
                                <HeaderTemplate>
                                    <ul id="ulRepProjectGroup">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <table cellspacing="1" width="100%">
                                            <tr>
                                                <td class="Heading3" style="width: 300; height: 30; background-color: #A9E2F3;">
                                                    <%# DataBinder.Eval(Container.DataItem, "ProjectGroupName") %>
                                                </td>
                                                <td class="center" style="width: 200; height: 30; background-color: #eeeeee; font-size: 18pt;">
                                                    <table cellspacing="1" class="gridHeaderStyle">
                                                        <tr>
                                                            <td style="width: 50; background: #eeeeee;" class="center txtweak">
                                                                Total
                                                            </td>
                                                            <td style="width: 50; background: #eeeeee;" class="center txtweak">
                                                                Open
                                                            </td>
                                                            <td style="width: 50; background: #eeeeee;" class="center txtweak">
                                                                Finish
                                                            </td>
                                                            <td style="width: 50; background: #eeeeee;" class="center txtweak">
                                                                Progress
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="background: #eeeeee;" class="center">
                                                                <asp:Label ID="lblTotalByProjectGroup" runat="server"></asp:Label>
                                                            </td>
                                                            <td style="background: #eeeeee;" class="center">
                                                                <asp:Label ID="lblTotalOpenByProjectGroup" runat="server"></asp:Label>
                                                            </td>
                                                            <td style="background: #eeeeee;" class="center">
                                                                <asp:Label ID="lblTotalFinishByProjectGroup" runat="server"></asp:Label>
                                                            </td>
                                                            <td style="background: #eeeeee;" class="center">
                                                                <asp:Label ID="lblProgressByProjectGroup" runat="server"></asp:Label>%
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="background-image: url('/qistoollib/images/timeline_dot.png'); background-repeat: repeat-x;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:Repeater ID="repMyProjects" runat="server" OnItemCommand="repMyProjects_ItemCommand"
                                                        OnItemDataBound="repMyProjects_ItemDataBound">
                                                        <HeaderTemplate>
                                                            <ul id="ulRepProjects">
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <li>
                                                                <table cellspacing="1" width="100%">
                                                                    <tr>
                                                                        <td colspan="2" style="height: 4;">
                                                                            <asp:Panel ID="pnlHEXColor" runat="server" Width="100%" Height="5" BackColor="#666666">
                                                                            </asp:Panel>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="Heading3">
                                                                            <asp:Label ID="_lblProjectID" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "ProjectID") %>'></asp:Label>
                                                                            <%# DataBinder.Eval(Container.DataItem, "ProjectAliasName") %>
                                                                        </td>
                                                                        <td valign="top" align="right">
                                                                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/qistoollib/images/tbprint.png"
                                                                                ToolTip="Print Customer Support Weekly Report" CommandName="Print" />
                                                                            <asp:ImageButton ID="_ibtnGoToProjectDetailPage" runat="server" ImageUrl="/qistoollib/images/viewDetail.png"
                                                                                ToolTip="View Project Detail" CommandName="ViewDetail" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="txtlessstrong">
                                                                            <%# DataBinder.Eval(Container.DataItem, "ProjectName") %>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="txtweak" colspan="2">
                                                                            <%# DataBinder.Eval(Container.DataItem, "ProjectDescription") %>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="txtweak" colspan="2">
                                                                            Last updated&nbsp;<%# DataBinder.Eval(Container.DataItem, "lastUpdateDate") %>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <table cellspacing="1" class="gridHeaderStyle">
                                                                                <tr>
                                                                                    <td style="width: 50; background: #eeeeee;" class="center txtweak">
                                                                                        Total
                                                                                    </td>
                                                                                    <td style="width: 50; background: #eeeeee;" class="center txtweak">
                                                                                        Open
                                                                                    </td>
                                                                                    <td style="width: 50; background: #eeeeee;" class="center txtweak">
                                                                                        Dev.Finish
                                                                                    </td>
                                                                                    <td style="width: 50; background: #eeeeee;" class="center txtweak">
                                                                                        Finish
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="background: #eeeeee;" class="center">
                                                                                        <%# DataBinder.Eval(Container.DataItem, "totalIssue") %>
                                                                                    </td>
                                                                                    <td style="background: #eeeeee;" class="center">
                                                                                        <%# DataBinder.Eval(Container.DataItem, "totalOpen") %>
                                                                                    </td>
                                                                                    <td style="background: #eeeeee;" class="center">
                                                                                        <%# DataBinder.Eval(Container.DataItem, "totalDevFinish") %>
                                                                                    </td>
                                                                                    <td style="background: #eeeeee;" class="center">
                                                                                        <%# DataBinder.Eval(Container.DataItem, "totalFinish") %>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td style="font-size: 18pt;" align="right" valign="bottom">
                                                                            <%# DataBinder.Eval(Container.DataItem, "progress") %>%
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
