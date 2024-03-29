﻿<%@ Register TagPrefix="Module" TagName="Copyright" Src="../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../incl/calendar.ascx" %>
<%@ Register TagPrefix="Module" TagName="ProjectBanner" Src="../incl/projectBanner.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Planned.aspx.vb" Inherits="QIS.Web.Planned" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI, Version=1.9.0.0, Culture=neutral, PublicKeyToken=24d65337282035f2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Basecamp - Planned</title>
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
            background: #ffffff;
            width: 250px;
            height: 90px;
            margin: 5px;
        }
        #rcorners1 {
          border-radius: 5px;
          background: #ea4032;
          color: #ffffff;
          padding: 5px;
        }
        .style1
        {
            text-align: right;
            padding-right: 5px;
            height: 26px;
        }
        .style2
        {
            height: 26px;
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
                        <td class="Heading2" colspan="3">
                            <asp:Label ID="lblPageTitle" runat="server" Text="Planned"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="hseparator" colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%;">
                            <table width="100%">
                                <tr>
                                    <td style="width: 100;" valign="top">
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
                                                    Target Period
                                                </td>
                                                <td>
                                                    <Module:Calendar ID="calStartDate" runat="server" DontResetDate="true" />
                                                    &nbsp;to&nbsp;
                                                    <Module:Calendar ID="calEndDate" runat="server" DontResetDate="true" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="right">
                                                    Project Group
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlProjectGroupFilter" runat="server" Width="200" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="right">
                                                    Project
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlProjectFilter" runat="server" Width="200" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="right">
                                                    Issue Status
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlIssueStatusFilter" runat="server" Width="200" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="right">
                                                    Assigned to
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlUserIDAssignedToFilter" runat="server" Width="200" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                    <asp:CheckBox ID="chkIsAssignedToMe" runat="server" Text="Me Only" AutoPostBack="true" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="top" align="right">
                                        <table width="100%" style="background: #dddddd;" cellspacing="1" cellpadding="2">
                                            <tr>
                                                <td style="background: #ffffff; width: 100;" class="center">
                                                    Total Issue
                                                </td>
                                                <td style="background: #ffffff; width: 100;" class="center">
                                                    Open
                                                </td>
                                                <td style="background: #ffffff; width: 100;" class="center">
                                                    In Progress
                                                </td>
                                                <td style="background: #ffffff; width: 120;" class="center">
                                                    Dev.Finish
                                                </td>
                                                <td style="background: #ffffff; width: 120;" class="center">
                                                    QC Passed
                                                </td>
                                                <td style="background: #ffffff; width: 100;" class="center">
                                                    Finish
                                                </td>
                                                <td style="background: #ffffff; width: 100; font-weight: bold;" class="center">
                                                    Progress
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="background: #ffffff; width: 100; font-size: 24;" class="center">
                                                    <asp:Label ID="lblTotalIssue" runat="server"></asp:Label>
                                                </td>
                                                <td style="background: #ffffff; width: 100; font-size: 24;" class="center">
                                                    <asp:Label ID="lblTotalOpen" runat="server"></asp:Label>
                                                </td>
                                                <td style="background: #ffffff; width: 100; font-size: 24;" class="center">
                                                    <asp:Label ID="lblTotalInProgress" runat="server"></asp:Label>
                                                </td>
                                                <td style="background: #ffffff; width: 120; font-size: 24;" class="center">
                                                    <asp:Label ID="lblTotalDevFinish" runat="server"></asp:Label>
                                                </td>
                                                <td style="background: #ffffff; width: 120; font-size: 24;" class="center">
                                                    <asp:Label ID="lblTotalQCPassed" runat="server"></asp:Label>
                                                </td>
                                                <td style="background: #ffffff; width: 100; font-size: 24;" class="center">
                                                    <asp:Label ID="lblTotalFinish" runat="server"></asp:Label>
                                                </td>
                                                <td style="background: #ffffff; width: 100; font-size: 24; font-weight: bold;" class="center">
                                                    <asp:Label ID="lblProgress" runat="server"></asp:Label>&nbsp;%
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="100%">
                                            <tr>
                                                <td class="hseparator" colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">
                                                    <asp:CheckBox ID="chkIsShowOutstandingPlanned" runat="server" Text="View All Outstanding Planned Issue(s)" AutoPostBack="true" />
                                                </td>
                                                <td align="right" valign="bottom">
                                                    <asp:ImageButton ID="ibtnViewDetailPlanned" runat="server" ImageUrl="/qistoollib/images/ico-detail.png"
                                                        ToolTip="View Detail Planned" Width="32" />
                                                    <asp:ImageButton ID="ibtnViewPlannedByTeam" runat="server" ImageUrl="/qistoollib/images/ico-teamtask.png"
                                                        ToolTip="View Planned by Team" Width="32" />
                                                    <asp:ImageButton ID="ibtnViewPlannedByProject" runat="server" ImageUrl="/qistoollib/images/ico-edit.png"
                                                        ToolTip="View Planned by Project" Width="32" />
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
                <asp:Panel ID="pnlDetailPlanned" runat="server">
                    <table width="100%">
                        <tr>
                            <td colspan="3">
                                <asp:Panel ID="pnlAddNew" runat="server">
                                    <table width="100%" class="gridAlternatingItemStyle" cellspacing="1">
                                        <tr>
                                            <td colspan="2" style="font-weight: bold; background-color: #d6eaf8;">
                                                .:: Add or Edit Issue
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" class="Title" style="background: #ffffff;">
                                                Issue ID #&nbsp;<asp:Label ID="lblIssueID" runat="server"></asp:Label>
                                                <asp:Label ID="lblProjectID" runat="server" Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 50%;" valign="top">
                                                <table width="100%" class="gridAlternatingItemStyle" cellspacing="1">
                                                    <tr>
                                                        <td class="right" style="background: #ffffff; color: #666666;">
                                                            Product Roadmap
                                                        </td>
                                                        <td style="background: #ffffff;">
                                                            <asp:DropDownList ID="ddlProductRoadmap" runat="server" Width="364">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="right" style="background: #ffffff; color: #666666;">
                                                            Department
                                                        </td>
                                                        <td style="background: #ffffff;">
                                                            <asp:TextBox ID="txtDepartmentName" runat="server" Width="360px" Height="23px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvDepartmentName" runat="server" Display="dynamic"
                                                                ErrorMessage="Department Name" ControlToValidate="txtDepartmentName" CssClass="txterrmsg"
                                                                Text="required">
                                                            </asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="right" style="background: #ffffff; color: #666666;">
                                                            Description
                                                        </td>
                                                        <td style="background: #ffffff;">
                                                            <asp:TextBox ID="txtIssueDescription" runat="server" TextMode="MultiLine" Width="360"
                                                                Height="80">
                                                            </asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvIssueDescription" runat="server" Display="dynamic"
                                                                ErrorMessage="Description" ControlToValidate="txtIssueDescription" CssClass="txterrmsg"
                                                                Text="required">
                                                            </asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="right" style="background: #ffffff; color: #666666;">
                                                            Keywords
                                                        </td>
                                                        <td style="background: #ffffff;">
                                                            <asp:TextBox ID="txtKeywords" runat="server" Width="360">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="right" style="background: #ffffff; color: #666666;">
                                                            Reported Date
                                                        </td>
                                                        <td style="background: #ffffff;">
                                                            <Module:Calendar ID="calReportedDate" runat="server" DontResetDate="true" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="right" style="background: #ffffff; color: #666666;">
                                                            Reported by
                                                        </td>
                                                        <td style="background: #ffffff;">
                                                            <asp:TextBox ID="txtReportedBy" runat="server" Width="360">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width: 50%;" valign="top">
                                                <table width="100%" class="gridAlternatingItemStyle" cellspacing="1">
                                                    <tr>
                                                        <td class="right" style="width: 100; background: #ffffff; color: #666666;">
                                                            Type
                                                        </td>
                                                        <td style="background: #ffffff;">
                                                            <asp:DropDownList ID="ddlIssueType" runat="server" Width="200">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="right" style="width: 100; background: #ffffff; color: #666666;">
                                                            Priority
                                                        </td>
                                                        <td style="background: #ffffff;">
                                                            <asp:DropDownList ID="ddlIssuePriority" runat="server" Width="200">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="right" style="width: 100; background: #ffffff; color: #666666;">
                                                            Assign to
                                                        </td>
                                                        <td style="background: #ffffff;">
                                                            <asp:DropDownList ID="ddlUserIDAssignedTo" runat="server" Width="200">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="right" style="width: 100; background: #ffffff; color: #666666;">
                                                            Status
                                                        </td>
                                                        <td style="background: #ffffff;">
                                                            <asp:DropDownList ID="ddlIssueStatus" runat="server" Width="200">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="right" style="width: 100; background: #ffffff; color: #666666;">
                                                            Confirmed?
                                                        </td>
                                                        <td style="background: #ffffff;">
                                                            <asp:DropDownList ID="ddlIssueConfirmStatus" runat="server" Width="200">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="right" style="background: #d6eaf8;">
                                                            Patch No.
                                                        </td>
                                                        <td style="background: #d6eaf8;">
                                                            <asp:TextBox ID="txtPatchNo" runat="server" Width="200" AutoPostBack="true">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td style="background: #d6eaf8;" colspan="2">
                                                            <asp:CheckBox ID="chkIsSpecific" runat="server" Text="Is Specific Project?" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="right" style="background: #f9e79f;">
                                                        </td>
                                                        <td style="background: #f9e79f;">
                                                            <asp:CheckBox ID="chkIsIncludeInMyWorktime" runat="server" Text="Add to My today Worktime?" />
                                                        </td>
                                                        <td style="background: #f9e79f;" colspan="2">
                                                            *unsubmitted only
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="right" style="background: #f9e79f;">
                                                            Description
                                                        </td>
                                                        <td style="background: #f9e79f;">
                                                            <asp:Label ID="lblWorktimeHdID" runat="server" Visible="true">
                                                            </asp:Label>
                                                            <asp:TextBox ID="txtWorktimeDtDescription" runat="server" Width="200">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td style="width: 100; background: #f9e79f;" class="right">
                                                            <asp:TextBox ID="txtWorkTimeInHour" runat="server" Width="100%">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td style="width: 140; background: #f9e79f;">
                                                            hour
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4">
                                                            <asp:Button ID="btnSaveAndClose" runat="server" Text="Save & Close" CssClass="sbttn"
                                                                Width="100" />
                                                            <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="sbttn" Width="100"
                                                                CausesValidation="false" />
                                                            <asp:Button ID="btnAddResponse" runat="server" Text="Add Response" CssClass="sbttn" Width="100" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="height: 24; width: 100%; background-image: url('/qistoollib/images/timeline_dot.png');
                                                background-repeat: repeat-x;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="font-weight: bold;">
                                                .:: Attachment(s)
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Repeater ID="repIssueFile" runat="server">
                                                    <HeaderTemplate>
                                                        <ul id="ulRepProjects">
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <li>
                                                            <table cellspacing="1" width="100%" title='<%# DataBinder.Eval(Container.DataItem, "fileName")%>'>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <asp:Label ID="_lblFileID" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "fileID") %>'></asp:Label>
                                                                        <asp:Label ID="_lblReferenceID" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "referenceID") %>'></asp:Label>
                                                                        <asp:Label ID="_lblFileName" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "fileName") %>'></asp:Label>
                                                                        <%# DataBinder.Eval(Container.DataItem, "fileDescription")%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="txtweak" colspan="2">
                                                                        File type&nbsp;<%# DataBinder.Eval(Container.DataItem, "fileExtension")%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="txtweak" colspan="2">
                                                                        Attached by&nbsp;<%# DataBinder.Eval(Container.DataItem, "firstName")%>&nbsp;on&nbsp;<%# Format(DataBinder.Eval(Container.DataItem, "insertDate"), "dd-MMM-yyyy HH:mm") %>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="left">
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <a href='<%# DataBinder.Eval(Container.DataItem, "fileUrl") %>' target="_blank" title="Preview File">
                                                                                        <img src="/qistoollib/images/attachment_preview.png" border="0" align="middle" alt="Preview File" />
                                                                                    </a>
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
                                </asp:Panel>
                                <asp:Panel ID="pnlIssueResponse" runat="server">
                                    <table width="100%" class="gridAlternatingItemStyle" cellspacing="1">
                                        <tr>
                                            <td colspan="2" style="font-weight: bold; background-color: #d0ece7;">
                                                .:: Add Response
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <table width="100%" cellpadding="2" cellspacing="1">
                                                    <tr>
                                                        <td class="Title" style="background: #ffffff;" colspan="2">
                                                            Issue ID #&nbsp;<asp:Label ID="Response_lblIssueID" runat="server"></asp:Label>                                                            
                                                            <asp:Label ID="Response_lblProjectID" runat="server" Visible="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="right" style="width: 100; background: #ffffff;">
                                                            Department:
                                                        </td>
                                                        <td style="background: #ffffff;">
                                                            <asp:Label ID="Response_lblDepartmentName" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="right" style="width: 100; background: #ffffff;">
                                                            Description:
                                                        </td>
                                                        <td style="background: #ffffff;">
                                                            <asp:Label ID="Response_lblIssueDescription" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 50%;" valign="top">
                                                <table width="100%" class="gridAlternetingItemStyle" cellspacing="1">
                                                    <tr>
                                                        <td class="right" style="background: #ffffff;">
                                                            Response Date
                                                        </td>
                                                        <td style="background: #ffffff;">
                                                            <Module:Calendar ID="Response_calResponseDate" runat="server" DontResetDate="true" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="right" style="background: #ffffff;">
                                                            Time Start
                                                        </td>
                                                        <td style="background: #ffffff;">
                                                            <ew:MaskedTextBox ID="Response_txtResponseTimeStart" runat="server" Width="100">
                                                            </ew:MaskedTextBox>
                                                            &nbsp;&nbsp;Duration
                                                            <asp:TextBox ID="Response_txtResponseDuration" runat="server" Width="60"></asp:TextBox>
                                                            Minutes
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="right" style="background: #ffffff;">
                                                            Response Type
                                                        </td>
                                                        <td style="background: #ffffff;">
                                                            <asp:DropDownList ID="Response_ddlResponseType" runat="server" Width="360">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="right" style="background: #ffffff;">
                                                            Response Description
                                                        </td>
                                                        <td style="background: #ffffff;">
                                                            <asp:TextBox ID="Response_txtResponseDescription" runat="server" Width="360" TextMode="MultiLine"
                                                                Height="80">
                                                            </asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="Response_rfvResponseDescription" runat="server" Display="dynamic"
                                                                ErrorMessage="Response" ControlToValidate="Response_txtResponseDescription" CssClass="txterrmsg"
                                                                Text="required">
                                                            </asp:RequiredFieldValidator>
                                                            <asp:Label ID="Response_lblResponseID" runat="server" Visible="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="right" style="background: #ffffff;">
                                                            <asp:CheckBox ID="Response_chkIsShared" runat="server" Text="Shared?" />
                                                        </td>
                                                        <td style="background: #ffffff;">
                                                            <font style="color: Red;">Shared response will be printed on Issue Ticket Form</font>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width: 50%;" valign="top">
                                                <table width="100%" class="gridAlternatingItemStyle" cellspacing="1">
                                                    <tr>
                                                        <td class="right" style="background: #ffffff;">
                                                            Issue Status
                                                        </td>
                                                        <td style="background: #ffffff;">
                                                            <asp:DropDownList ID="Response_ddlIssueStatus" runat="server" Width="200">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 200px; background: #ffffff;">
                                                            <asp:CheckBox ID="Response_chkIsUpdateStatus" runat="server" Text="Update Issue & Confirm Status upon saving?" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="right" style="background: #ffffff;">
                                                            Confirmed?
                                                        </td>
                                                        <td style="background: #ffffff;">
                                                            <asp:DropDownList ID="Response_ddlIssueConfirmStatus" runat="server" Width="200">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="background: #ffffff;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="right" style="background: #d6eaf8;">
                                                            Patch No.
                                                        </td>
                                                        <td style="background: #d6eaf8;">
                                                            <asp:TextBox ID="Response_txtPatchNo" runat="server" Width="200" AutoPostBack="true">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td style="width: 200px; background: #d6eaf8;">
                                                            <asp:CheckBox ID="Response_chkIsSpecific" runat="server" Text="Is Specific Project?" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="right" style="background: #f9e79f;">
                                                        </td>
                                                        <td style="background: #f9e79f;">
                                                            <asp:CheckBox ID="Response_chkIsIncludeInMyWorktime" runat="server" Text="Add to My today Worktime?" />
                                                        </td>
                                                        <td style="background: #f9e79f;" colspan="2">
                                                            * for unsubmitted Worktime only
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="right" style="background: #f9e79f;">
                                                            Description
                                                        </td>
                                                        <td style="background: #f9e79f;">
                                                            <asp:Label ID="Response_lblWorktimeHdID" runat="server" Visible="true">
                                                            </asp:Label>
                                                            <asp:TextBox ID="Response_txtWorktimeDtDescription" runat="server" Width="200">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td style="width: 100; background: #f9e79f;" class="right">
                                                            <asp:TextBox ID="Response_txtWorkTimeInHour" runat="server" Width="100%">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td style="width: 140; background: #f9e79f;">
                                                            hour
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:Button ID="Response_btnSaveAndNew" runat="server" Text="Save & New" CssClass="sbttn"
                                                                Width="100" />
                                                            <asp:Button ID="Response_btnSaveAndClose" runat="server" Text="Save & Close" CssClass="sbttn"
                                                                Width="100" />
                                                            <asp:Button ID="Response_btnClose" runat="server" Text="Close" CssClass="sbttn" Width="100"
                                                                CausesValidation="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:DataGrid ID="grdIssueResponse" runat="server" BorderWidth="0" GridLines="None"
                                                    Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                    AutoGenerateColumns="false">
                                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                    <ItemStyle CssClass="gridItemStyle" />
                                                    <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                    <Columns>
                                                        <asp:TemplateColumn runat="server" ItemStyle-Width="30" ItemStyle-HorizontalAlign="center">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="_ibtnEdit" runat="server" ImageUrl="/qistoollib/images/edit.png"
                                                                    ImageAlign="AbsMiddle" CommandName="Edit" CausesValidation="false" />
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn runat="server" HeaderText="Added on" ItemStyle-Width="150">
                                                            <ItemTemplate>
                                                                <asp:Label ID="_lblResponseID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "responseID")%>'
                                                                    Visible="false"></asp:Label>
                                                                <%# Format(DataBinder.Eval(Container.DataItem, "updateDate"),"dd-MMM-yyyy hh:mm:ss")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn runat="server" HeaderText="Added by" ItemStyle-Width="80">
                                                            <ItemTemplate>
                                                                <%# DataBinder.Eval(Container.DataItem, "userNameUpdate")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn runat="server" HeaderText="Response Description">
                                                            <ItemTemplate>
                                                                <%# DataBinder.Eval(Container.DataItem, "responseDescription")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn runat="server" HeaderText="Type" ItemStyle-Width="150">
                                                            <ItemTemplate>
                                                                <%# DataBinder.Eval(Container.DataItem, "responseTypeName") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn runat="server" HeaderText="Response Date" ItemStyle-Width="80">
                                                            <ItemTemplate>
                                                                <%# Format(DataBinder.Eval(Container.DataItem, "responseDate"), "dd-MMM-yyyy") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn runat="server" HeaderText="Time Start" ItemStyle-Width="80">
                                                            <ItemTemplate>
                                                                <%# DataBinder.Eval(Container.DataItem, "responseTimeStart") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn runat="server" HeaderText="Duration (minutes)" ItemStyle-Width="120">
                                                            <ItemTemplate>
                                                                <%# DataBinder.Eval(Container.DataItem, "responseDuration") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn runat="server" HeaderText="Shared?" ItemStyle-Width="60">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="_chkIsShared" runat="server" Enabled="false" Checked='<%# DataBinder.Eval(Container.DataItem, "isShared") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                </asp:DataGrid>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:DataGrid ID="grdIssueByFilter" runat="server" BorderWidth="0" GridLines="None"
                                    Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                    AutoGenerateColumns="false">
                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                    <ItemStyle CssClass="gridItemStyle" />
                                    <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                    <Columns>
                                        <asp:TemplateColumn runat="server" ItemStyle-Width="30" ItemStyle-HorizontalAlign="center"
                                            ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="_ibtnEdit" runat="server" ImageUrl="/qistoollib/images/edit.png"
                                                    ImageAlign="AbsMiddle" CommandName="Edit" CausesValidation="false" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" ItemStyle-Width="30" ItemStyle-HorizontalAlign="center"
                                            ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <asp:Image ID="_imgAttachment" runat="server" ImageUrl="/qistoollib/images/attachment.png"
                                                    ImageAlign="AbsMiddle" Visible='<%# DataBinder.Eval(Container.DataItem, "isHasAttachment") %>' />
                                                <asp:Image ID="_imgIsUrgent" runat="server" ImageUrl="/qistoollib/images/urgent.png"
                                                    Visible='<%# DataBinder.Eval(Container.DataItem, "isUrgent")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="Issue ID" ItemStyle-Width="100" ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:LinkButton runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "issueID") %>'
                                                                ID="_lbtnIssueID" CommandName="IssueReponse" ForeColor="blue" CausesValidation="false"
                                                                ToolTip="Add Response" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="txtweak">
                                                            Response(s):
                                                            <%# DataBinder.Eval(Container.DataItem, "totalResponse")%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="txtweak">
                                                            <%# Format(DataBinder.Eval(Container.DataItem, "updateDate"),"dd-MMM-yyyy hh:mm") %>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="hseparator">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="txtweak">
                                                            Patch No.:&nbsp;<%# DataBinder.Eval(Container.DataItem, "patchNo")%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="Project" ItemStyle-Width="100" ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <table cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <%# DataBinder.Eval(Container.DataItem, "projectAliasName") %>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="hseparator">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Product Roadmap:<br />
                                                            <%# DataBinder.Eval(Container.DataItem, "productRoadmapName")%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="hseparator">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="txtweak">
                                                            <%# DataBinder.Eval(Container.DataItem, "departmentName") %>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="Description" ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "issueDescription")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="Reported By" ItemStyle-Width="100"
                                            ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td class="txtweak">
                                                            <%# DataBinder.Eval(Container.DataItem, "reportedBy")%>
                                                            <br />
                                                            on&nbsp;<%# Format(DataBinder.Eval(Container.DataItem, "reportedDate"),"dd-MMM-yyyy") %>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="hseparator">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="txtweak">
                                                            Created by:&nbsp;<%# DataBinder.Eval(Container.DataItem, "userNameInsert")%><br />
                                                            on&nbsp;<%# Format(DataBinder.Eval(Container.DataItem, "insertDate"),"dd-MMM-yyyy") %>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="hseparator">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="txtweak">
                                                            Updated by:&nbsp;<%# DataBinder.Eval(Container.DataItem, "userNameUpdate")%><br />
                                                            on&nbsp;<%# Format(DataBinder.Eval(Container.DataItem, "updateDate"),"dd-MMM-yyyy") %>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="Type" ItemStyle-Width="60" ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "issueTypeName")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="Priority" ItemStyle-Width="60" ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "issuePriorityName")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="Assigned to" ItemStyle-Width="80"
                                            ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <table cellspacing="0">
                                                    <tr>
                                                        <td colspan="2">
                                                            <%# DataBinder.Eval(Container.DataItem, "userNameAssignedTo")%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="txtweak">
                                                            Target Date:
                                                            <%# Format(DataBinder.Eval(Container.DataItem, "targetDate"),"dd-MMM-yyyy") %>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="txtweak center">
                                                            <p id="rcorners1">
                                                                Due:
                                                                <%# DataBinder.Eval(Container.DataItem, "dueToTargetDateAgeInDay")%>
                                                                d</p>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="Status" ItemStyle-Width="80" ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "issueStatusName")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="Confirmed?" ItemStyle-Width="80" ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "issueConfirmStatusName")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                    </Columns>
                                </asp:DataGrid>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlPlannedByTeam" runat="server">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:DataGrid ID="grdPlannedByTeam" runat="server" BorderWidth="0" GridLines="None"
                                    Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                    AutoGenerateColumns="false">
                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                    <ItemStyle CssClass="gridItemStyle" />
                                    <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                    <Columns>
                                        <asp:TemplateColumn runat="server" HeaderText="Team Name" ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "fullName")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="Total Issue" ItemStyle-VerticalAlign="Top"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "totalIssue")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="Total Open" ItemStyle-VerticalAlign="Top"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "totalOpen")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="Total In Progress" ItemStyle-VerticalAlign="Top"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "totalInProgress")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="Total Dev. Finish" ItemStyle-VerticalAlign="Top"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "totalDevFinish")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="Progress Dev. Finish" ItemStyle-VerticalAlign="Top"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"
                                            ItemStyle-Font-Bold="true">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "progressDevFinish")%>&nbsp;%
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="Total QC Failed" ItemStyle-VerticalAlign="Top"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "totalQCFailed")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="Total QC Passed" ItemStyle-VerticalAlign="Top"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "totalQCPassed")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="Progress QC Passed" ItemStyle-VerticalAlign="Top"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"
                                            ItemStyle-Font-Bold="true">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "progressQCPassed")%>&nbsp;%
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="Total Finish" ItemStyle-VerticalAlign="Top"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "totalFinish")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="Progress Finish" ItemStyle-VerticalAlign="Top"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"
                                            ItemStyle-Font-Bold="true">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "progressFinish")%>&nbsp;%
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                    </Columns>
                                </asp:DataGrid>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

                <asp:Panel ID="pnlPlannedByProject" runat="server">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:DataGrid ID="grdPlannedByProject" runat="server" BorderWidth="0" GridLines="None"
                                    Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                    AutoGenerateColumns="false">
                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                    <ItemStyle CssClass="gridItemStyle" />
                                    <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                    <Columns>
                                        <asp:TemplateColumn runat="server" HeaderText="Project Initial" ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "projectAliasName")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="Project Name" ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "projectName")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="Total Issue" ItemStyle-VerticalAlign="Top"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "totalIssue")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="Total Open" ItemStyle-VerticalAlign="Top"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "totalOpen")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="Total In Progress" ItemStyle-VerticalAlign="Top"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "totalInProgress")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="Total Dev. Finish" ItemStyle-VerticalAlign="Top"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "totalDevFinish")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="Progress Dev. Finish" ItemStyle-VerticalAlign="Top"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"
                                            ItemStyle-Font-Bold="true">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "progressDevFinish")%>&nbsp;%
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="Total QC Failed" ItemStyle-VerticalAlign="Top"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "totalQCFailed")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="Total QC Passed" ItemStyle-VerticalAlign="Top"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "totalQCPassed")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="Progress QC Passed" ItemStyle-VerticalAlign="Top"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"
                                            ItemStyle-Font-Bold="true">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "progressQCPassed")%>&nbsp;%
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="Total Finish" ItemStyle-VerticalAlign="Top"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "totalFinish")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn runat="server" HeaderText="Progress Finish" ItemStyle-VerticalAlign="Top"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true"
                                            ItemStyle-Font-Bold="true">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "progressFinish")%>&nbsp;%
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                    </Columns>
                                </asp:DataGrid>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
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
