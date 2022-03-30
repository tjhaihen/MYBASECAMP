<%@ Register TagPrefix="Module" TagName="Copyright" Src="../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../incl/calendar.ascx" %>
<%@ Register TagPrefix="Module" TagName="ProjectBanner" Src="../incl/projectBanner.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FollowUpIssue.aspx.vb"
    Inherits="QIS.Web.FollowUpIssue" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Basecamp - Follow Up Issue</title>
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
                            <asp:Label ID="lblPageTitle" runat="server" Text="Follow Up Issue"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="hseparator" colspan="3">
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td style="width: 90%;">
                            <table width="100%">
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
                                                    <asp:CheckBox ID="chkIsFilterByPeriod" runat="server" Text="Update Period" />
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlPeriod" runat="server" Width="200" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </td>
                                                <td colspan="2">
                                                    <asp:Panel ID="pnlCustomPeriod" runat="server">
                                                        <Module:Calendar ID="calStartDate" runat="server" DontResetDate="true" />
                                                        &nbsp;to&nbsp;
                                                        <Module:Calendar ID="calEndDate" runat="server" DontResetDate="true" />
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 120;" class="right">
                                                    Product Roadmap
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlProductRoadmapFilter" runat="server" Width="200">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="hseparator" colspan="4"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 120;" class="right">
                                                    Project
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlProjectFilter" runat="server" Width="200">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 120;" class="right">
                                                    Assign to
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlUserIDAssignedToFilter" runat="server" Width="200">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 120;" class="right">
                                                    Type
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlIssueTypeFilter" runat="server" Width="200">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 120;" class="right">
                                                    Status
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlIssueStatusFilter" runat="server" Width="200">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="chkIsUrgent" runat="server" Text="Urgent" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 120;" class="right">
                                                    Priority
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlIssuePriorityFilter" runat="server" Width="200">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 120;" class="right">
                                                    Confirmed?
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlIssueConfirmStatusFilter" runat="server" Width="200">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="middle" class="right">
                            <table style="background: #dddddd;" cellspacing="1" cellpadding="2">
                                <tr>
                                    <td style="background: #ffffff; width: 100;" class="center">
                                        Total Issue
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background: #ffffff; width: 100; font-size: 24;" class="center">
                                        <asp:Label ID="lblTotalIssue" runat="server"></asp:Label>
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
                                                    <td colspan="2">
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
                                                                    File type&nbsp;<%# DataBinder.Eval(Container.DataItem, "fileExtension")%></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txtweak" colspan="2">
                                                                    Attached by&nbsp;<%# DataBinder.Eval(Container.DataItem, "firstName")%>&nbsp;on&nbsp;<%# Format(DataBinder.Eval(Container.DataItem, "insertDate"), "dd-MMM-yyyy HH:mm") %></td>
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
                                        <td colspan="2" style="font-weight: bold;">
                                            .:: Add Response
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <table width="100%" cellpadding="2" cellspacing="1">
                                                <tr>
                                                    <td colspan="2" class="Title" style="background: #ffffff;">
                                                        Issue ID #&nbsp;<asp:Label ID="Response_lblIssueID" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="width: 100; background: #ffffff; color: #666666;">
                                                        Department:
                                                    </td>
                                                    <td style="background: #ffffff;">
                                                        <asp:Label ID="Response_lblDepartmentName" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="width: 100; background: #ffffff; color: #666666;">
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
                                            <table width="100%" class="gridAlternatingItemStyle" cellspacing="1">
                                                <tr style="display: none;">
                                                    <td class="right" style="background: #ffffff; color: #666666;">
                                                        Response Date
                                                    </td>
                                                    <td style="background: #ffffff;">
                                                        <Module:Calendar ID="Response_calResponseDate" runat="server" DontResetDate="true" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="width: 100; background: #ffffff; color: #666666;">
                                                        Response
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
                                            </table>
                                        </td>
                                        <td style="width: 50%;" valign="top">
                                            <table width="100%" class="gridAlternatingItemStyle" cellspacing="1">
                                                <tr>
                                                    <td>
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
                                                    <asp:TemplateColumn runat="server" HeaderText="Added on" ItemStyle-Width="150">
                                                        <ItemTemplate>
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
                            <asp:DataGrid ID="grdIssueByFilter" runat="server" BorderWidth="0" GridLines="None"
                                Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                AutoGenerateColumns="false">
                                <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                <ItemStyle CssClass="gridItemStyle" />
                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                <Columns>
                                    <asp:TemplateColumn runat="server" ItemStyle-Width="30" ItemStyle-HorizontalAlign="center" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="_ibtnEdit" runat="server" ImageUrl="/qistoollib/images/edit.png"
                                                ImageAlign="AbsMiddle" CommandName="Edit" CausesValidation="false" />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn runat="server" ItemStyle-Width="30" ItemStyle-HorizontalAlign="center" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <asp:Image ID="_imgAttachment" runat="server" ImageUrl="/qistoollib/images/attachment.png"
                                                ImageAlign="AbsMiddle" Visible='<%# DataBinder.Eval(Container.DataItem, "isHasAttachment") %>' />
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
                                                <tr style="display: none;">
                                                    <td class="txtweak">
                                                        Age (day):
                                                        <%# DataBinder.Eval(Container.DataItem, "issueAgeInDay")%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="hseparator"></td>
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
                                            <table>
                                                <tr>
                                                    <td colspan="2">
                                                        <%# DataBinder.Eval(Container.DataItem, "projectAliasName") %>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        Roadmap:<br />
                                                        <%# DataBinder.Eval(Container.DataItem, "productRoadmapName")%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="hseparator" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Image ID="_imgIsUrgent" runat="server" ImageUrl="/qistoollib/images/urgent.png"
                                                            Visible='<%# DataBinder.Eval(Container.DataItem, "isUrgent")%>' />
                                                    </td>
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
                                    <asp:TemplateColumn runat="server" HeaderText="Reported By" ItemStyle-Width="100" ItemStyle-VerticalAlign="Top">
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
                                    <asp:TemplateColumn runat="server" HeaderText="Assigned to" ItemStyle-Width="80" ItemStyle-VerticalAlign="Top">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container.DataItem, "userNameAssignedTo")%>
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
                <Module:Copyright ID="mdlCopyRight" runat="server" PathPrefix=".."></Module:Copyright>
                <!-- END PAGE FOOTER-->
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
