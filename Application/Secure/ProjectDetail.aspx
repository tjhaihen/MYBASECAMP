<%@ Register TagPrefix="Module" TagName="Copyright" Src="../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../incl/calendar.ascx" %>
<%@ Register TagPrefix="Module" TagName="ProjectBanner" Src="../incl/projectBanner.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ProjectDetail.aspx.vb"
    Inherits="QIS.Web.ProjectDetail" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI, Version=1.9.0.0, Culture=neutral, PublicKeyToken=24d65337282035f2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Basecamp - Project Detail</title>
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
                                alt="Urgents" />
                        </td>
                        <td valign="middle">
                            <asp:LinkButton ID="lbtnUrgents" runat="server" Text="Urgents" CausesValidation="false"></asp:LinkButton>
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
                            <asp:CheckBox ID="chkIsMyAssignment" runat="server" Visible="false"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="hseparator" colspan="3">
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td valign="top" style="width: 40%;">
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
                                <tr>
                                    <td style="background: #ffffff; width: 100;" class="center">
                                        Total
                                    </td>
                                    <td style="background: #ffffff; width: 100;" class="center">
                                        Open
                                    </td>
                                    <td style="background: #ffffff; width: 120;" class="center">
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
                                    <td style="background: #ffffff; width: 100;" class="center">
                                        Display
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background: #ffffff; width: 100; font-size: large;" class="center">
                                        <asp:Label ID="lblTotalIssue" runat="server"></asp:Label>
                                    </td>
                                    <td style="background: #ffffff; width: 100; font-size: large;" class="center">
                                        <asp:Label ID="lblTotalOpen" runat="server"></asp:Label>
                                    </td>
                                    <td style="background: #ffffff; width: 100; font-size: large;" class="center">
                                        <asp:Label ID="lblTotalInProgress" runat="server"></asp:Label>
                                    </td>
                                    <td style="background: #ffffff; width: 100; font-size: large;" class="center">
                                        <asp:Label ID="lblTotalDevFinish" runat="server"></asp:Label>
                                    </td>
                                    <td style="background: #ffffff; width: 100; font-size: large;" class="center">
                                        <asp:Label ID="lblTotalQCPassed" runat="server"></asp:Label>
                                    </td>
                                    <td style="background: #ffffff; width: 120; font-size: large;" class="center">
                                        <asp:Label ID="lblTotalFinish" runat="server"></asp:Label>
                                    </td>
                                    <td style="background: #ffffff; width: 100; font-size: large; font-weight: bold;" class="center">
                                        <asp:Label ID="lblProgress" runat="server"></asp:Label>&nbsp;%
                                    </td>
                                    <td style="background: #ffffff; width: 100;" class="center">
                                        <asp:CheckBox ID="chkIsOpenOnly" runat="server" Text="Open" AutoPostBack="true" />
                                    </td>
                                </tr>
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
                            <table width="100%">
                                <tr>
                                    <td class="gridHeaderStyle center" style="width: 70%;">
                                        Upload Data - Spreadsheet File
                                    </td>
                                    <td class="gridHeaderStyle center" style="width: 25%;">
                                        Sheet Name
                                    </td>
                                    <td class="gridHeaderStyle center" style="width: 100;">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <input id="Upload_File" type="file" runat="server" autopostback="True" name="Upload_File"
                                            size="85" class="imguploader" style="width: 100%;">
                                        <input id="Upload_FileDetail" type="file" runat="server" autopostback="True" name="Upload_FileDetail"
                                            size="85" class="imguploader" style="width: 100%; display: none;">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Upload_txtSheetName" runat="server" Width="100%" Text="Sheet1">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnUploadIssue" runat="server" Text="Upload" Width="100" CssClass="sbttn" />
                                    </td>
                                </tr>
                            </table>
                            <asp:Panel ID="pnlAddNew" runat="server">
                                <table width="100%" class="gridAlternatingItemStyle" cellspacing="1">
                                    <tr>
                                        <td colspan="2" style="font-weight: bold;">
                                            .:: Add or Edit Issue
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" class="Title" style="background: #ffffff;">
                                            Issue ID #&nbsp;<asp:Label ID="lblIssueID" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 50%;" valign="top">
                                            <table width="100%" class="gridAlternatingItemStyle" cellspacing="1">
                                                <tr>
                                                    <td class="right" style="width: 120px; background: #ffffff;">
                                                        Product Roadmap
                                                    </td>
                                                    <td style="background: #ffffff;">
                                                        <asp:DropDownList ID="ddlProductRoadmap" runat="server" Width="360">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="width: 120px; background: #ffffff;">
                                                        Department
                                                    </td>
                                                    <td style="background: #ffffff;">
                                                        <asp:TextBox ID="txtDepartmentName" runat="server" Width="360">
                                                        </asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvDepartmentName" runat="server" Display="dynamic"
                                                            ErrorMessage="Department Name" ControlToValidate="txtDepartmentName" CssClass="txterrmsg"
                                                            Text="required">
                                                        </asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background: #ffffff;">
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
                                                    <td class="right" style="background: #ffffff;">
                                                        Keywords
                                                    </td>
                                                    <td style="background: #ffffff;">
                                                        <asp:TextBox ID="txtKeywords" runat="server" Width="360">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background: #ffffff;">
                                                        Reported Date
                                                    </td>
                                                    <td style="background: #ffffff;">
                                                        <Module:Calendar ID="calReportedDate" runat="server" DontResetDate="true" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background: #ffffff;">
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
                                                    <td class="right" style="width: 120; background: #ffffff;">
                                                        Type
                                                    </td>
                                                    <td style="background: #ffffff;" colspan="3">
                                                        <asp:DropDownList ID="ddlIssueType" runat="server" Width="200">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background: #ffffff;">
                                                        Priority
                                                    </td>
                                                    <td style="background: #ffffff;">
                                                        <asp:DropDownList ID="ddlIssuePriority" runat="server" Width="200">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 100; background: #ffffff;">
                                                        <asp:CheckBox ID="chkIsUrgent" runat="server" Text="Urgent" ForeColor="Red" />
                                                    </td>
                                                    <td style="width: 140; background: #ffffff;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background: #ffffff;">
                                                        Assign to
                                                    </td>
                                                    <td style="background: #ffffff;">
                                                        <asp:DropDownList ID="ddlUserIDAssignedTo" runat="server" Width="200">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 100; background: #ffffff;" class="right">
                                                    </td>
                                                    <td style="width: 140; background: #ffffff;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background: #ffffff;">
                                                        Est. Start Date
                                                    </td>
                                                    <td style="background: #ffffff;">
                                                        <Module:Calendar ID="calEstStartDate" runat="server" DontResetDate="true" />
                                                    </td>
                                                    <td style="width: 100; background: #ffffff;" class="right">
                                                    </td>
                                                    <td style="width: 140; background: #ffffff;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background: #ffffff;">
                                                        Target Date
                                                    </td>
                                                    <td style="background: #ffffff;">
                                                        <Module:Calendar ID="calTargetDate" runat="server" DontResetDate="true" />
                                                    </td>
                                                    <%--tambah checkbox is planned--%>
                                                    <td style="width: 100; background: #ffffff;">
                                                        <asp:CheckBox ID="chkIsPlanned" runat="server" Text="Planned" ForeColor="Red" />
                                                    </td>
                                                    <td style="width: 140; background: #ffffff;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background: #ffffff;">
                                                        Status
                                                    </td>
                                                    <td style="background: #ffffff;" colspan="3">
                                                        <asp:DropDownList ID="ddlIssueStatus" runat="server" Width="200">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background: #ffffff;">
                                                        Confirmed?
                                                    </td>
                                                    <td style="background: #ffffff;" colspan="3">
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
                                    <tr>
                                        <td colspan="2" style="font-weight: bold;">
                                            .:: Attachment(s)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 50%;" valign="top">
                                            <table width="100%" class="gridAlternatingItemStyle" cellspacing="1">
                                                <tr>
                                                    <td class="right" style="width: 120px; background: #ffffff;">
                                                        Choose File
                                                    </td>
                                                    <td style="background: #ffffff;">
                                                        <asp:TextBox ID="txtIssueFileID" Width="360" runat="server" Visible="false">
                                                        </asp:TextBox>
                                                        <input id="txtIssueFileUrl" type="file" name="txtIssueFileUrl" runat="server" class="imguploader"
                                                            style="width: 360px;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background: #ffffff;">
                                                        File Description
                                                    </td>
                                                    <td style="background: #ffffff;">
                                                        <asp:TextBox ID="txtIssueFileDescription" Width="360" MaxLength="500" runat="server">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width: 50%;" valign="top">
                                            <table width="100%" class="gridAlternatingItemStyle" cellspacing="1">
                                                <tr>
                                                    <td class="right" style="width: 120; background: #ffffff;">
                                                        Rename File To
                                                    </td>
                                                    <td style="background: #ffffff;">
                                                        <asp:TextBox ID="txtIssueFileName" Width="360" MaxLength="500" runat="server">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:Button ID="btnIssueFileAttach" runat="server" Text="Attach" CssClass="sbttn"
                                                            Width="100" />
                                                        <asp:Button ID="btnIssueFileUpdate" runat="server" Text="Update" CssClass="sbttn"
                                                            Width="100" />
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
                                        <td colspan="2">
                                            <asp:Repeater ID="repIssueFile" runat="server" OnItemCommand="repIssueFile_ItemCommand">
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
                                                                            <td>
                                                                                <asp:ImageButton ID="_ibtnEditFile" runat="server" ImageUrl="/qistoollib/images/attachment_edit.png"
                                                                                    ToolTip="Edit File Description" CommandName="EditFile" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td class="right">
                                                                    <asp:ImageButton ID="_ibtnDeleteFile" runat="server" ImageUrl="/qistoollib/images/attachment_delete.png"
                                                                        ToolTip="Delete File" CommandName="DeleteFile" />
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
                                        <td colspan="2" style="font-weight: bold;">
                                            .:: Add Response
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <table width="100%" cellpadding="2" cellspacing="1">
                                                <tr>
                                                    <td class="right Title" style="width: 100; background: #ffffff;">
                                                        Issue ID #
                                                    </td>
                                                    <td class="Title" style="background: #ffffff;">
                                                        <asp:Label ID="Response_lblIssueID" runat="server"></asp:Label>
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
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:DataGrid ID="grdIssueByProject" runat="server" BorderWidth="0" GridLines="None"
                                Width="100%" CellPadding="3" CellSpacing="1" ShowHeader="true" ShowFooter="false"
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
                                            <asp:ImageButton ID="_ibtnPrint" runat="server" ImageUrl="/qistoollib/images/print.png"
                                                ImageAlign="AbsMiddle" CommandName="PrintTicket" CausesValidation="false" ToolTip="Print Issue Ticket Form" />
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
                                                            ToolTip="Add or Edit Response" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="txtlessstrong">
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
                                    <asp:TemplateColumn runat="server" HeaderText="Department" ItemStyle-Width="120"
                                        ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <table>
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
                                                    <td>
                                                        <%# DataBinder.Eval(Container.DataItem, "departmentName") %>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn runat="server" HeaderText="Description" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <pre><%# DataBinder.Eval(Container.DataItem, "issueDescription")%></pre>
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
                                                        Created by:&nbsp;<%# DataBinder.Eval(Container.DataItem, "userNameInsert")%>
                                                        <br />
                                                        on&nbsp;<%# Format(DataBinder.Eval(Container.DataItem, "insertDate"),"dd-MMM-yyyy") %>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="hseparator">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="txtweak">
                                                        Updated by:&nbsp;<%# DataBinder.Eval(Container.DataItem, "userNameUpdate")%>
                                                        <br />
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
                                            <div>
                                                <%# DataBinder.Eval(Container.DataItem, "userNameAssignedTo")%>
                                                <br />
                                                <div class="txtweak">
                                                    Target Date:<br />
                                                    <%# Format(DataBinder.Eval(Container.DataItem, "targetDate"), "dd-MMM-yyyy")%></div>
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
