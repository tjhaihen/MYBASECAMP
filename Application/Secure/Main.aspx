﻿<%@ Register TagPrefix="Module" TagName="Copyright" Src="../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../incl/calendar.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../incl/CSSToolbar.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Main.aspx.vb" Inherits="QIS.Web.Main" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>--%>
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
            border-radius: 10px;
            background: #eeeeee;
            width: 320px;
            height: 240px;
            margin: 3px;
            padding: 5px;
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
            <td valign="top" style="width: 120px;">
                <table width="220" style="height: 60px;">
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
                        <td style="width: 100%;" class="hseparator" colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" style="width: 34;">
                            <asp:ImageButton ID="ibtnMyDay" runat="server" ImageUrl="/qistoollib/images/myday.png"
                                alt="My Day" />
                        </td>
                        <td valign="middle">
                            <asp:LinkButton ID="lbtnMyDay" runat="server" Text="My Day" CausesValidation="false"></asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%;" class="hseparator" colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" style="width: 34;">
                            <asp:ImageButton ID="ibtnUrgents" runat="server" ImageUrl="/qistoollib/images/urgents.png"
                                alt="Criticals" />
                        </td>
                        <td valign="middle">
                            <asp:LinkButton ID="lbtnUrgents" runat="server" Text="Criticals" CausesValidation="false"></asp:LinkButton>
                        </td>
                        <td class="right" style="color: red;">
                            <asp:Label ID="lblUrgentsTotal" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%;" class="hseparator" colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" style="width: 34;">
                            <asp:ImageButton ID="ibtnPlanned" runat="server" ImageUrl="/qistoollib/images/planned.png"
                                alt="Planned" />
                        </td>
                        <td valign="middle">
                            <asp:LinkButton ID="lbtnPlanned" runat="server" Text="Planned" CausesValidation="false"></asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%;" class="hseparator" colspan="3">
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
                        <td class="right">
                            <asp:Label ID="lblAssignmentsTotal" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%;" class="hseparator" colspan="3">
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
                        <td style="width: 100%;" class="hseparator" colspan="3">
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
                        <td style="width: 100%;" class="hseparator" colspan="3">
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
                        <td colspan="3">
                            <asp:Panel ID="pnlschedule" runat="server">
                                <table width="100%" class="gridAlternatingItemStyle" cellspacing="1">
                                    <tr>
                                        <td colspan="2" style="font-weight: bold;">
                                            .:: Schedule
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" class="Title" style="background: #ffffff;">
                                            <asp:Label ID="lblProjectID" runat="server" Visible="false"></asp:Label>
                                            Project:&nbsp;<asp:Label ID="lblProjectAliasName" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 50%;" valign="top">
                                            <table width="100%" class="gridAlternatingItemStyle" cellspacing="1">
                                                <tr>
                                                    <td class="right" style="width: 120px; background: #ffffff;">
                                                        Next Update Date
                                                    </td>
                                                    <td style="background: #ffffff;">
                                                        <Module:Calendar ID="calNextUpdateDate" runat="server" DontResetDate="true" />
                                                        <%--<asp:RequiredFieldValidator ID="rfvNextUpdateDate" runat="server" Display="dynamic"
                                                                                    ErrorMessage="NextUpdateDate" ControlToValidate="calNextUpdateDate" CssClass="txterrmsg"
                                                                                    Text="required">
                                                                                </asp:RequiredFieldValidator>--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background: #ffffff;">
                                                        Remarks
                                                    </td>
                                                    <td style="background: #ffffff;">
                                                        <asp:TextBox ID="txtNextUpdateRemarks" runat="server" TextMode="MultiLine" Width="360">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="sbttn" Width="100" />
                                                        <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="sbttn" Width="100"
                                                            CausesValidation="false" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width: 50%;" valign="top">
                                            <table width="100%" class="gridAlternatingItemStyle" cellspacing="1">
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
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
                                                <td class="Heading3" style="width: 300; height: 30; background-color: #4adede; color: #555555;
                                                    padding-left: 10;">
                                                    <%# DataBinder.Eval(Container.DataItem, "ProjectGroupName") %>
                                                </td>
                                                <td class="center" style="width: 100; height: 30; background-color: #787ff6; font-size: 18pt;">
                                                    <table cellspacing="0" class="gridHeaderStyle">
                                                        <tr>
                                                            <td class="center txtweak" style="width: 100; background: #787ff6; color: #ffffff;">
                                                                Total Project
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="background: #787ff6; color: #ffffff;" class="center">
                                                                <asp:Label ID="lblTotalByProjectGroup" runat="server"></asp:Label>
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
                                                                        <td class="Heading3" style="width: 50%;">
                                                                            <asp:Label ID="_lblProjectID" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "ProjectID") %>'></asp:Label>
                                                                            <asp:Label ID="_lblProjectAliasName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProjectAliasName") %>'></asp:Label>                                                                            
                                                                        </td>
                                                                        <%--print--%>
                                                                        <td valign="top" align="right">
                                                                            <asp:ImageButton ID="print" runat="server" ImageUrl="/qistoollib/images/tbprint.png"
                                                                                ToolTip="Print Customer Support Weekly Report" CommandName="rprint" />
                                                                            <asp:ImageButton ID="_ibtnSchedule" runat="server" ImageUrl="/qistoollib/images/schedule.png"
                                                                                ToolTip="Schedule Patch Update" CommandName="schedule" />
                                                                            <asp:ImageButton ID="_ibtnProjectTimeline" runat="server" ImageUrl="/qistoollib/images/timeline.png"
                                                                                ToolTip="View Project Timeline" CommandName="ViewProjectTimeline" />
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
                                                                            Last updated:&nbsp;<%# DataBinder.Eval(Container.DataItem, "lastUpdateDate") %>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="txtweak" colspan="2">
                                                                            <p id="rcorners1">
                                                                                Last Patch:&nbsp;<b><%# DataBinder.Eval(Container.DataItem, "lastPatchNo")%></b>
                                                                                <b>
                                                                                    <%# DataBinder.Eval(Container.DataItem, "lastPatchDate")%></b>
                                                                            </p>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="txtweak" colspan="2">
                                                                            <p id="rcorners2" style="word-wrap: break-word; width: 310px">
                                                                                Scheduled Update:&nbsp;<b><%# DataBinder.Eval(Container.DataItem, "NextUpdateDate")%></b>
                                                                                <br />
                                                                                <%# DataBinder.Eval(Container.DataItem, "NextUpdateRemarks")%>
                                                                            </p>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <table cellspacing="1" class="gridHeaderStyle">
                                                                                <tr>
                                                                                    <td style="width: 50;" class="center txtweak">
                                                                                        Total
                                                                                    </td>
                                                                                    <td style="width: 50;" class="center txtweak">
                                                                                        Open
                                                                                    </td>
                                                                                    <td style="width: 60;" class="center txtweak">
                                                                                        InProgress
                                                                                    </td>
                                                                                    <td style="width: 60;" class="center txtweak">
                                                                                        Dev.Finish
                                                                                    </td>
                                                                                    <td style="width: 60;" class="center txtweak">
                                                                                        QC.Passed
                                                                                    </td>
                                                                                    <td style="width: 50;" class="center txtweak">
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
                                                                                        <%# DataBinder.Eval(Container.DataItem, "totalInProgress") %>
                                                                                    </td>
                                                                                    <td style="background: #eeeeee;" class="center">
                                                                                        <%# DataBinder.Eval(Container.DataItem, "totalDevFinish") %>
                                                                                    </td>
                                                                                    <td style="background: #eeeeee;" class="center">
                                                                                        <%# DataBinder.Eval(Container.DataItem, "totalQCPassed")%>
                                                                                    </td>
                                                                                    <td style="background: #eeeeee;" class="center">
                                                                                        <%# DataBinder.Eval(Container.DataItem, "totalFinish") %>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="background: #eeeeee;" class="center">
                                                                                    </td>
                                                                                    <td style="background: #eeeeee;" class="center">
                                                                                        <%# DataBinder.Eval(Container.DataItem, "totalOpenInPct")%>%
                                                                                    </td>
                                                                                    <td style="background: #eeeeee;" class="center">
                                                                                        <%# DataBinder.Eval(Container.DataItem, "totalInProgressInPct")%>%
                                                                                    </td>
                                                                                    <td style="background: #eeeeee;" class="center">
                                                                                        <%# DataBinder.Eval(Container.DataItem, "totalDevFinishInPct")%>%
                                                                                    </td>
                                                                                    <td style="background: #eeeeee;" class="center">
                                                                                        <%# DataBinder.Eval(Container.DataItem, "totalQCPassedInPct")%>%
                                                                                    </td>
                                                                                    <td style="background: #eeeeee;" class="center">
                                                                                        <%# DataBinder.Eval(Container.DataItem, "progress") %>%
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
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
