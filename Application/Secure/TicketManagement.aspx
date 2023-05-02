<%@ Register TagPrefix="Module" TagName="Copyright" Src="../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../incl/calendar.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../incl/CSSToolbar.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TicketManagement.aspx.vb"
    Inherits="QIS.Web.TicketManagement" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI, Version=1.9.0.0, Culture=neutral, PublicKeyToken=24d65337282035f2" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>--%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Medinfras Basecamp - Change Request Management</title>
    <link rel="title icon" href="/qistoollib/images/favicon.png" />
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href="/qistoollib/css/styles_blue.css" type="text/css" rel="Stylesheet" />
    <script language="javascript" type="text/javascript" src="/qistoollib/scripts/JScript.js"></script>
    <style type="text/css">
        #rcorners1
        {
            border-radius: 5px;
            background: #b5d0f8;
            color: #000000;
            padding: 5px;
        }
        #rcorners2
        {
            border-radius: 5px;
            background: #acefe8;
            color: #000000;
            padding: 5px;
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server">
    <table width="100%" cellpadding="2" cellspacing="0">
        <tr>
            <td width="100%" valign="top">
                <!-- BEGIN PAGE HEADER -->
                <Module:RadMenu ID="RadMenu" runat="server" />
                <!-- END PAGE HEADER -->
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 100%;">
                <table width="100%">
                    <tr>
                        <td class="Heading2" style="width: 70%;">
                            Change Request Management
                        </td>
                        <td class="right" style="width:30%; padding-right: 0;">
                            <table width="100%">
                                <tr>
                                    <td style="width: 120;" class="right">
                                        Project
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlProjectFilter" runat="server" Width="200" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="hseparator">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="width: 100%;">
                            <table width="100%">
                                <tr>
                                    <td colspan="4">
                                        <asp:Panel ID="pnlAddNew" runat="server">
                                            <table width="100%" class="gridAlternatingItemStyle" cellspacing="1">
                                                <tr>
                                                    <td colspan="2" style="font-weight: bold; background-color: #d6eaf8;">
                                                        .:: Add or Edit Issue
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="Title" style="background: #ffffff;">
                                                        <asp:Label ID="lblProjectID" runat="server" Visible="false"></asp:Label>
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
                                                                    Description (User Friendly)
                                                                </td>
                                                                <td style="background: #ffffff;">
                                                                    <asp:TextBox ID="txtUserFriendlyIssueDescription" runat="server" TextMode="MultiLine"
                                                                        Width="360" Height="80">
                                                                    </asp:TextBox>
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
                                                                    <asp:CheckBox ID="chkIsUrgent" runat="server" Text="Critical" ForeColor="Red" />
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
                                                                <td colspan="4">
                                                                    <asp:Button ID="btnSaveOnly" runat="server" Text="Save" CssClass="sbttn" Width="100" />
                                                                    <asp:Button ID="btnSaveAndNew" runat="server" Text="Save & New" CssClass="sbttn"
                                                                        Width="100" />
                                                                    <asp:Button ID="btnAddResponse" runat="server" Text="Add Response" CssClass="sbttn"
                                                                        Width="100" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4">
                                                                    <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="sbttn" Width="100"
                                                                        CausesValidation="false" />
                                                                    <asp:Button ID="btnSaveAndClose" runat="server" Text="Save & Close" CssClass="sbttn"
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
                                                    <td colspan="2" style="font-weight: bold; background-color: #d0ece7;">
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
                                    <td style="width: 25%;">
                                        <table width="100%" style="background: #fdedec; border-radius: 10px;" cellpadding="3">
                                            <tr>
                                                <td>
                                                    Open
                                                </td>
                                                <td class="right">
                                                    Total:&nbsp;<asp:Label ID="lblTotalOpen" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 25%;">
                                        <table width="100%" style="background: #d0ece7; border-radius: 10px;" cellpadding="3">
                                            <tr>
                                                <td>
                                                    CRF Quotation
                                                </td>
                                                <td class="right">
                                                    Total:&nbsp;<asp:Label ID="lblTotalCRFQuotation" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 25%;">
                                        <table width="100%" style="background: #fcf3cf; border-radius: 10px;" cellpadding="3">
                                            <tr>
                                                <td>
                                                    In Progress
                                                </td>
                                                <td class="right">
                                                    Total:&nbsp;<asp:Label ID="lblTotalInProgress" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 25%;">
                                        <table width="100%" style="background: #d6eaf8; border-radius: 10px;" cellpadding="3">
                                            <tr>
                                                <td>
                                                    Dev. Finish
                                                </td>
                                                <td class="right">
                                                    Total:&nbsp;<asp:Label ID="lblTotalDevFinish" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 25%; background: #f5f5f5; border-radius: 10px;" valign="top">
                                        <table width="100%">
                                            <tr>
                                                <td style="width: 100%;">
                                                    <asp:DataGrid ID="grdIssueOpen" runat="server" BorderWidth="0" GridLines="None" Width="100%"
                                                        CellPadding="2" CellSpacing="1" ShowHeader="false" ShowFooter="false" AutoGenerateColumns="false">
                                                        <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                        <ItemStyle CssClass="gridItemStyle" />
                                                        <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                        <Columns>
                                                            <asp:TemplateColumn runat="server">
                                                                <ItemTemplate>
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:LinkButton runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "issueID") %>'
                                                                                    ID="_lbtnIssueID" CommandName="EditIssue" ForeColor="blue" CausesValidation="false"
                                                                                    ToolTip="Edit" />
                                                                            </td>
                                                                            <td class="right" style="padding-right: 0;">
                                                                                <table cellpadding="2" cellspacing="0" align="right">
                                                                                    <tr>
                                                                                        <td class="right">
                                                                                            <asp:Image ID="_imgAttachment" runat="server" ImageUrl="/qistoollib/images/attachment_large.png"
                                                                                                Width="16" ImageAlign="AbsMiddle" Visible='<%# DataBinder.Eval(Container.DataItem, "isHasAttachment") %>' ToolTip="Has Attachment(s)" />
                                                                                        </td>
                                                                                        <td class="right">
                                                                                            <asp:Image ID="_imgIsUrgent" runat="server" ImageUrl="/qistoollib/images/critical.png"
                                                                                                Width="16" Visible='<%# DataBinder.Eval(Container.DataItem, "isUrgent")%>' ToolTip="Critical" />
                                                                                        </td>
                                                                                        <td class="right">
                                                                                            <asp:ImageButton ID="_imgResponse" runat="server" ImageUrl="/qistoollib/images/response.png"
                                                                                                Width="16" ImageAlign="AbsMiddle" CommandName="EditResponse" ToolTip="Edit Response" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <%# DataBinder.Eval(Container.DataItem, "projectAliasName") %>
                                                                            </td>
                                                                            <td class="txtweak right">
                                                                                Response(s):&nbsp;<%# DataBinder.Eval(Container.DataItem, "totalResponse")%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" class="txtweak">
                                                                                <%# DataBinder.Eval(Container.DataItem, "reportedBy")%>
                                                                                &nbsp;on&nbsp;<%# Format(DataBinder.Eval(Container.DataItem, "reportedDate"),"dd-MMM-yyyy") %>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" class="hseparator">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="txtweak">
                                                                                <%# DataBinder.Eval(Container.DataItem, "issueTypeName")%>
                                                                            </td>
                                                                            <td class="txtweak right">
                                                                                <%# DataBinder.Eval(Container.DataItem, "issuePriorityName")%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" class="txtweak">
                                                                                <%# DataBinder.Eval(Container.DataItem, "issueDescription")%>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                        </Columns>
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 25%; background: #f5f5f5; border-radius: 10px;" valign="top">
                                        <table width="100%">
                                            <tr>
                                                <td style="width: 100%;">
                                                    <asp:DataGrid ID="grdIssueCRFQuotation" runat="server" BorderWidth="0" GridLines="None"
                                                        Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="false" ShowFooter="false"
                                                        AutoGenerateColumns="false">
                                                        <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                        <ItemStyle CssClass="gridItemStyle" />
                                                        <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                        <Columns>
                                                            <asp:TemplateColumn runat="server">
                                                                <ItemTemplate>
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:LinkButton runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "issueID") %>'
                                                                                    ID="_lbtnIssueID" CommandName="EditIssue" ForeColor="blue" CausesValidation="false"
                                                                                    ToolTip="Edit" />
                                                                            </td>
                                                                            <td class="right" style="padding-right: 0;">
                                                                                <table cellpadding="2" cellspacing="0" align="right">
                                                                                    <tr>
                                                                                        <td class="right">
                                                                                            <asp:Image ID="_imgAttachment" runat="server" ImageUrl="/qistoollib/images/attachment_large.png"
                                                                                                Width="16" ImageAlign="AbsMiddle" Visible='<%# DataBinder.Eval(Container.DataItem, "isHasAttachment") %>' ToolTip="Has Attachment(s)" />
                                                                                        </td>
                                                                                        <td class="right">
                                                                                            <asp:Image ID="_imgIsUrgent" runat="server" ImageUrl="/qistoollib/images/critical.png"
                                                                                                Width="16" Visible='<%# DataBinder.Eval(Container.DataItem, "isUrgent")%>' ToolTip="Critical" />
                                                                                        </td>
                                                                                        <td class="right">
                                                                                            <asp:ImageButton ID="_imgResponse" runat="server" ImageUrl="/qistoollib/images/response.png"
                                                                                                Width="16" ImageAlign="AbsMiddle" CommandName="EditResponse" ToolTip="Edit Response" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <%# DataBinder.Eval(Container.DataItem, "projectAliasName") %>
                                                                            </td>
                                                                            <td class="txtweak right">
                                                                                Response(s):&nbsp;<%# DataBinder.Eval(Container.DataItem, "totalResponse")%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" class="txtweak">
                                                                                <%# DataBinder.Eval(Container.DataItem, "reportedBy")%>
                                                                                &nbsp;on&nbsp;<%# Format(DataBinder.Eval(Container.DataItem, "reportedDate"),"dd-MMM-yyyy") %>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" class="hseparator">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="txtweak">
                                                                                <%# DataBinder.Eval(Container.DataItem, "issueTypeName")%>
                                                                            </td>
                                                                            <td class="txtweak right">
                                                                                <%# DataBinder.Eval(Container.DataItem, "issuePriorityName")%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" class="txtweak">
                                                                                <%# DataBinder.Eval(Container.DataItem, "issueDescription")%>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                        </Columns>
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 25%; background: #f5f5f5; border-radius: 10px;" valign="top">
                                        <table width="100%">
                                            <tr>
                                                <td style="width: 100%;">
                                                    <asp:DataGrid ID="grdIssueInProgress" runat="server" BorderWidth="0" GridLines="None"
                                                        Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="false" ShowFooter="false"
                                                        AutoGenerateColumns="false">
                                                        <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                        <ItemStyle CssClass="gridItemStyle" />
                                                        <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                        <Columns>
                                                            <asp:TemplateColumn runat="server">
                                                                <ItemTemplate>
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:LinkButton runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "issueID") %>'
                                                                                    ID="_lbtnIssueID" CommandName="EditIssue" ForeColor="blue" CausesValidation="false"
                                                                                    ToolTip="Edit" />
                                                                            </td>
                                                                            <td class="right" style="padding-right: 0;">
                                                                                <table cellpadding="2" cellspacing="0" align="right">
                                                                                    <tr>
                                                                                        <td class="right">
                                                                                            <asp:Image ID="_imgAttachment" runat="server" ImageUrl="/qistoollib/images/attachment_large.png"
                                                                                                Width="16" ImageAlign="AbsMiddle" Visible='<%# DataBinder.Eval(Container.DataItem, "isHasAttachment") %>' ToolTip="Has Attachment(s)" />
                                                                                        </td>
                                                                                        <td class="right">
                                                                                            <asp:Image ID="_imgIsUrgent" runat="server" ImageUrl="/qistoollib/images/critical.png"
                                                                                                Width="16" Visible='<%# DataBinder.Eval(Container.DataItem, "isUrgent")%>' ToolTip="Critical" />
                                                                                        </td>
                                                                                        <td class="right">
                                                                                            <asp:ImageButton ID="_imgResponse" runat="server" ImageUrl="/qistoollib/images/response.png"
                                                                                                Width="16" ImageAlign="AbsMiddle" CommandName="EditResponse" ToolTip="Edit Response" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <%# DataBinder.Eval(Container.DataItem, "projectAliasName") %>
                                                                            </td>
                                                                            <td class="txtweak right">
                                                                                Response(s):&nbsp;<%# DataBinder.Eval(Container.DataItem, "totalResponse")%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" class="txtweak">
                                                                                <%# DataBinder.Eval(Container.DataItem, "reportedBy")%>
                                                                                &nbsp;on&nbsp;<%# Format(DataBinder.Eval(Container.DataItem, "reportedDate"),"dd-MMM-yyyy") %>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" class="hseparator">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="txtweak">
                                                                                <%# DataBinder.Eval(Container.DataItem, "issueTypeName")%>
                                                                            </td>
                                                                            <td class="txtweak right">
                                                                                <%# DataBinder.Eval(Container.DataItem, "issuePriorityName")%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" class="txtweak">
                                                                                <%# DataBinder.Eval(Container.DataItem, "issueDescription")%>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                        </Columns>
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 25%; background: #f5f5f5; border-radius: 10px;" valign="top">
                                        <table width="100%">
                                            <tr>
                                                <td style="width: 100%;">
                                                    <asp:DataGrid ID="grdIssueDevFinish" runat="server" BorderWidth="0" GridLines="None"
                                                        Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="false" ShowFooter="false"
                                                        AutoGenerateColumns="false">
                                                        <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                        <ItemStyle CssClass="gridItemStyle" />
                                                        <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                        <Columns>
                                                            <asp:TemplateColumn runat="server">
                                                                <ItemTemplate>
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:LinkButton runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "issueID") %>'
                                                                                    ID="_lbtnIssueID" CommandName="EditIssue" ForeColor="blue" CausesValidation="false"
                                                                                    ToolTip="Edit" />
                                                                            </td>
                                                                            <td class="right" style="padding-right: 0;">
                                                                                <table cellpadding="2" cellspacing="0" align="right">
                                                                                    <tr>
                                                                                        <td class="right">
                                                                                            <asp:Image ID="_imgAttachment" runat="server" ImageUrl="/qistoollib/images/attachment_large.png"
                                                                                                Width="16" ImageAlign="AbsMiddle" Visible='<%# DataBinder.Eval(Container.DataItem, "isHasAttachment") %>' ToolTip="Has Attachment(s)" />
                                                                                        </td>
                                                                                        <td class="right">
                                                                                            <asp:Image ID="_imgIsUrgent" runat="server" ImageUrl="/qistoollib/images/critical.png"
                                                                                                Width="16" Visible='<%# DataBinder.Eval(Container.DataItem, "isUrgent")%>' ToolTip="Critical" />
                                                                                        </td>
                                                                                        <td class="right">
                                                                                            <asp:ImageButton ID="_imgResponse" runat="server" ImageUrl="/qistoollib/images/response.png"
                                                                                                Width="16" ImageAlign="AbsMiddle" CommandName="EditResponse" ToolTip="Edit Response" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <%# DataBinder.Eval(Container.DataItem, "projectAliasName") %>
                                                                            </td>
                                                                            <td class="txtweak right">
                                                                                Response(s):&nbsp;<%# DataBinder.Eval(Container.DataItem, "totalResponse")%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" class="txtweak">
                                                                                <%# DataBinder.Eval(Container.DataItem, "reportedBy")%>
                                                                                &nbsp;on&nbsp;<%# Format(DataBinder.Eval(Container.DataItem, "reportedDate"),"dd-MMM-yyyy") %>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" class="hseparator">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="txtweak">
                                                                                <%# DataBinder.Eval(Container.DataItem, "issueTypeName")%>
                                                                            </td>
                                                                            <td class="txtweak right">
                                                                                <%# DataBinder.Eval(Container.DataItem, "issuePriorityName")%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" class="txtweak">
                                                                                <%# DataBinder.Eval(Container.DataItem, "issueDescription")%>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                        </Columns>
                                                    </asp:DataGrid>
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
        <tr>
            <td valign="bottom">
                <!-- BEGIN PAGE FOOTER-->
                <!-- END PAGE FOOTER-->
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
