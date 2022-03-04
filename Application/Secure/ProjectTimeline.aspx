<%@ Register TagPrefix="Module" TagName="Copyright" Src="../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../incl/calendar.ascx" %>
<%@ Register TagPrefix="Module" TagName="ProjectBanner" Src="../incl/projectBanner.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ProjectTimeline.aspx.vb"
    Inherits="QIS.Web.ProjectTimeline" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI, Version=1.9.0.0, Culture=neutral, PublicKeyToken=24d65337282035f2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Basecamp - Project Timeline</title>
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
        pre
        {
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
            <td valign="top" width="120">
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
            <td valign="top" width="100%">
                <table width="100%">
                    <tr>
                        <td class="Heading2" colspan="3">
                            <asp:Label ID="lblPageTitle" runat="server" Text="Project Detail"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="hseparator" colspan="3">
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td valign="top" style="width: 50%;">
                            <table>
                                <tr>
                                    <td valign="top" style="width: 100;">
                                        <table>
                                            <tr>
                                                <td>
                                                    <Module:CSSToolbar ID="CSSToolbar" runat="server"></Module:CSSToolbar>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="top">
                                        <table width="100%">
                                            <tr>
                                                <td class="Heading3">
                                                    <asp:Label ID="lblProjectID" runat="server" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblProjectAliasName" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblProjectName" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="txtlessstrong">
                                                    <asp:Label ID="lblProjectDescription" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="hseparator">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="txtlessstrong">
                                                    Last Patch:&nbsp;<asp:Label ID="lblLastPatchNo" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top" class="right">
                            <table style="background: #dddddd;" cellspacing="1" cellpadding="2">
                            </table>
                            <table>
                                <tr>
                                    <td class="txtlessstrong">
                                        Last Activity on:&nbsp;<asp:Label ID="lblProjectLastUpdatedDate" runat="server"></asp:Label>
                                        &nbsp;|&nbsp; Created on:&nbsp;<asp:Label ID="lblProjectCreatedDate" runat="server"></asp:Label>
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
                            <asp:Panel ID="pnlAddNew" runat="server">
                                <table width="100%" class="gridAlternatingItemStyle" cellspacing="1">
                                    <tr>
                                        <td colspan="2" style="font-weight: bold;">
                                            .:: Add or Edit Project Timeline
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 50%;" valign="top">
                                            <table width="100%" class="gridAlternatingItemStyle" cellspacing="1">
                                                <tr>
                                                    <td class="right" style="width: 120px; background: #ffffff;">
                                                        Timeline ID #
                                                    </td>
                                                    <td style="background: #ffffff;" colspan="3">
                                                        <asp:Label ID="lblProjectTimelineID" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="width: 120px; background: #ffffff;">
                                                        Sequence No.
                                                    </td>
                                                    <td style="background: #ffffff;">
                                                        <asp:TextBox ID="txtSequenceNo" runat="server" Width="100">
                                                        </asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvSequenceNo" runat="server" Display="dynamic" ErrorMessage="Sequence No"
                                                            ControlToValidate="txtSequenceNo" CssClass="txterrmsg" Text="required">
                                                        </asp:RequiredFieldValidator>
                                                    </td>
                                                    <td class="right" style="width: 130px; background: #ffffff;">
                                                        Predecessor No.
                                                    </td>
                                                    <td style="background: #ffffff;">
                                                        <asp:TextBox ID="txtPredecessorSequenceNo" runat="server" Width="100">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background: #ffffff;">
                                                        Task
                                                    </td>
                                                    <td style="background: #ffffff;" colspan="3">
                                                        <asp:TextBox ID="txtTask" runat="server" Width="360">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4">
                                                        Scheduled
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background: #ffffff;">
                                                        Start Date & Time
                                                    </td>
                                                    <td style="background: #ffffff;" colspan="3">
                                                        <Module:Calendar ID="calStartDateScheduled" runat="server" DontResetDate="true" />
                                                        &nbsp;&nbsp;
                                                        <asp:TextBox ID="txtStartTimeScheduled" runat="server" Width="100">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background: #ffffff;">
                                                        End Date & Time
                                                    </td>
                                                    <td style="background: #ffffff;" colspan="3">
                                                        <Module:Calendar ID="calEndDateScheduled" runat="server" DontResetDate="true" />
                                                        &nbsp;&nbsp;
                                                        <asp:TextBox ID="txtEndTimeScheduled" runat="server" Width="100">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background: #ffffff;">
                                                        Task Description
                                                    </td>
                                                    <td style="background: #ffffff;" colspan="3">
                                                        <asp:TextBox ID="txtTaskDescription" runat="server" TextMode="MultiLine" Width="360"
                                                            Height="80">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width: 50%;" valign="top">
                                            <table width="100%" class="gridAlternatingItemStyle" cellspacing="1">
                                                <tr>
                                                    <td class="right" style="background: #ffffff;">
                                                        Assign To
                                                    </td>
                                                    <td style="background: #ffffff;">
                                                        <asp:DropDownList ID="ddlUserIDPIC" runat="server" Width="200">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background: #ffffff;">
                                                        Status
                                                    </td>
                                                    <td style="background: #ffffff;">
                                                        <asp:DropDownList ID="ddlTaskStatus" runat="server" Width="200">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2">
                                                        Realized
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background: #ffffff;">
                                                        Start Date & Time
                                                    </td>
                                                    <td style="background: #ffffff;">
                                                        <Module:Calendar ID="calStartDateRealized" runat="server" DontResetDate="true" />
                                                        &nbsp;&nbsp;
                                                        <asp:TextBox ID="txtStartTimeRealized" runat="server" Width="100">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background: #ffffff;">
                                                        End Date & Time
                                                    </td>
                                                    <td style="background: #ffffff;">
                                                        <Module:Calendar ID="calEndDateRealized" runat="server" DontResetDate="true" />
                                                        &nbsp;&nbsp;
                                                        <asp:TextBox ID="txtEndTimeRealized" runat="server" Width="100">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Button ID="btnSaveOnly" runat="server" Text="Save" CssClass="sbttn" Width="100" />
                                                        <asp:Button ID="btnSaveAndNew" runat="server" Text="Save & New" CssClass="sbttn"
                                                            Width="100" />
                                                        <asp:Button ID="btnSaveAndClose" runat="server" Text="Save & Close" CssClass="sbttn"
                                                            Width="100" />
                                                        <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="sbttn" Width="100"
                                                            CausesValidation="false" />
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
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="pnlSubTask" runat="server">
                                <table width="100%" class="gridAlternatingItemStyle" cellspacing="1">
                                    <tr>
                                        <td colspan="2" style="font-weight: bold;">
                                            .:: Add or Edit Sub Task
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%;" valign="top" colspan="2">
                                            <table width="100%" cellpadding="2" cellspacing="0">
                                                <tr>
                                                    <td class="right" style="width: 120; background: #515a5a; color: #ffffff;">
                                                        Timeline ID #:
                                                    </td>
                                                    <td style="background: #515a5a; color: #ffffff;">
                                                        <asp:Label ID="SubTask_lblProjectTimelineID" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="background: #515a5a; color: #ffffff;">
                                                        <strong>Scheduled:</strong>
                                                    </td>
                                                    <td style="background: #515a5a; color: #ffffff;">
                                                        <strong>Realized:</strong>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="width: 120; background: #515a5a; color: #ffffff;">
                                                        No.:
                                                    </td>
                                                    <td style="background: #515a5a; color: #ffffff;">
                                                        <asp:Label ID="SubTask_lblSequenceNo" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="background: #515a5a; color: #ffffff;">
                                                        From:&nbsp;<asp:Label ID="SubTask_lblStartDateScheduled" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="background: #515a5a; color: #ffffff;">
                                                        From:&nbsp;<asp:Label ID="SubTask_lblStartDateRealized" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="width: 120; background: #515a5a; color: #ffffff;">
                                                        Task:
                                                    </td>
                                                    <td style="background: #515a5a; color: #ffffff;">
                                                        <asp:Label ID="SubTask_lblTask" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="background: #515a5a; color: #ffffff;">
                                                        to:&nbsp;<asp:Label ID="SubTask_lblEndDateScheduled" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="background: #515a5a; color: #ffffff;">
                                                        to:&nbsp;<asp:Label ID="SubTask_lblEndDateRealized" runat="server"></asp:Label>
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
                                                        Sub ID #
                                                    </td>
                                                    <td style="background: #ffffff;">
                                                        <asp:Label ID="SubTask_lblProjectTimelineSubTaskID" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background: #ffffff;">
                                                        Sub No.
                                                    </td>
                                                    <td style="background: #ffffff;">
                                                        <asp:TextBox ID="SubTask_txtSequenceNo" runat="server" Width="100">
                                                        </asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="SubTask_rfvSequenceNo" runat="server" Display="dynamic" ErrorMessage="Sequence No"
                                                            ControlToValidate="SubTask_txtSequenceNo" CssClass="txterrmsg" Text="required">
                                                        </asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background: #ffffff;">
                                                        Sub Task
                                                    </td>
                                                    <td style="background: #ffffff;">
                                                        <asp:TextBox ID="SubTask_txtSubTask" runat="server" Width="360">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2">
                                                        Scheduled
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background: #ffffff;">
                                                        Start Date & Time
                                                    </td>
                                                    <td style="background: #ffffff;">
                                                        <Module:Calendar ID="SubTask_calStartDateScheduled" runat="server" DontResetDate="true" />
                                                        &nbsp;&nbsp;
                                                        <asp:TextBox ID="SubTask_txtStartTimeScheduled" runat="server" Width="100">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background: #ffffff;">
                                                        End Date & Time
                                                    </td>
                                                    <td style="background: #ffffff;">
                                                        <Module:Calendar ID="SubTask_calEndDateScheduled" runat="server" DontResetDate="true" />
                                                        &nbsp;&nbsp;
                                                        <asp:TextBox ID="SubTask_txtEndTimeScheduled" runat="server" Width="100">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background: #ffffff;">
                                                        Sub Task Description
                                                    </td>
                                                    <td style="background: #ffffff;">
                                                        <asp:TextBox ID="SubTask_txtSubTaskDescription" runat="server" TextMode="MultiLine" Width="360"
                                                            Height="80">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width: 50%;" valign="top">
                                            <table width="100%" class="gridAlternatingItemStyle" cellspacing="1">
                                                <tr>
                                                    <td class="right" style="background: #ffffff;">
                                                        Assign To
                                                    </td>
                                                    <td style="background: #ffffff;">
                                                        <asp:DropDownList ID="SubTask_ddlUserIDPIC" runat="server" Width="200">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background: #ffffff;">
                                                        Status
                                                    </td>
                                                    <td style="background: #ffffff;">
                                                        <asp:DropDownList ID="SubTask_ddlSubTaskStatus" runat="server" Width="200">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2">
                                                        Realized
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background: #ffffff;">
                                                        Start Date & Time
                                                    </td>
                                                    <td style="background: #ffffff;">
                                                        <Module:Calendar ID="SubTask_calStartDateRealized" runat="server" DontResetDate="true" />
                                                        &nbsp;&nbsp;
                                                        <asp:TextBox ID="SubTask_txtStartTimeRealized" runat="server" Width="100">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background: #ffffff;">
                                                        End Date & Time
                                                    </td>
                                                    <td style="background: #ffffff;">
                                                        <Module:Calendar ID="SubTask_calEndDateRealized" runat="server" DontResetDate="true" />
                                                        &nbsp;&nbsp;
                                                        <asp:TextBox ID="SubTask_txtEndTimeRealized" runat="server" Width="100">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:Button ID="SubTask_btnSaveAndNew" runat="server" Text="Save & New" CssClass="sbttn"
                                                            Width="100" />
                                                        <asp:Button ID="SubTask_btnSaveAndClose" runat="server" Text="Save & Close" CssClass="sbttn"
                                                            Width="100" />
                                                        <asp:Button ID="SubTask_btnClose" runat="server" Text="Close" CssClass="sbttn" Width="100"
                                                            CausesValidation="false" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:DataGrid ID="grdProjectTimelineSubTask" runat="server" BorderWidth="0" GridLines="None"
                                                Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                AutoGenerateColumns="false" Font-Size="Smaller">
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
                                                            <asp:Label ID="_lblProjectTimelineSubTaskID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "projectTimelineSubTaskID")%>'
                                                                Visible="false"></asp:Label>
                                                            <%# Format(DataBinder.Eval(Container.DataItem, "updateDate"), "dd-MMM-yyyy hh:mm:ss")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="No." ItemStyle-Width="60">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "sequenceNo")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Sub Task">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "subTask")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Scheduled Start" ItemStyle-Width="80" ItemStyle-VerticalAlign="Top">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "startDateScheduledInString")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Scheduled End" ItemStyle-Width="80" ItemStyle-VerticalAlign="Top">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "endDateScheduledInString")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Realized Start" ItemStyle-Width="80" ItemStyle-VerticalAlign="Top">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "startDateRealizedInString")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Realized End" ItemStyle-Width="80" ItemStyle-VerticalAlign="Top">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "endDateRealizedInString")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Status" ItemStyle-VerticalAlign="Top">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "subTaskStatusName")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Assigned to" ItemStyle-Width="80"
                                                        ItemStyle-VerticalAlign="Top">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "userNamePIC")%>
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
                        <td colspan="3">
                            <asp:DataGrid ID="grdProjectTimeline" runat="server" BorderWidth="0" GridLines="None"
                                Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                AutoGenerateColumns="false" Font-Size="Smaller">
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
                                    <asp:TemplateColumn runat="server" HeaderText="ID" ItemStyle-Width="100" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "projectTimelineID") %>'
                                                ID="_lbtnProjectTimelineID" CommandName="ProjectTimelineSubTask" ForeColor="blue"
                                                CausesValidation="false" ToolTip="Add or Edit Sub Task" />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn runat="server" HeaderText="Sub" ItemStyle-Width="40" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container.DataItem, "totalProjectTimelineSubTask")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn runat="server" HeaderText="No" ItemStyle-Width="60" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <asp:Label ID="_lblSequenceNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "sequenceNo")%>'></asp:Label>                                            
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn runat="server" HeaderText="Task" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <asp:Label ID="_lblTask" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "taskView")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn runat="server" HeaderText="Scheduled Start" ItemStyle-Width="80" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container.DataItem, "startDateScheduledInString")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn runat="server" HeaderText="Scheduled End" ItemStyle-Width="80" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container.DataItem, "endDateScheduledInString")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn runat="server" HeaderText="Realized Start" ItemStyle-Width="80" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container.DataItem, "startDateRealizedInString")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn runat="server" HeaderText="Realized End" ItemStyle-Width="80" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container.DataItem, "endDateRealizedInString")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn runat="server" HeaderText="Predecessor" ItemStyle-Width="60"
                                        ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container.DataItem, "sequencePredecessorNo")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn runat="server" HeaderText="Status" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container.DataItem, "taskStatusName")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn runat="server" HeaderText="Assigned to" ItemStyle-Width="80"
                                        ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container.DataItem, "userNamePIC")%>
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
