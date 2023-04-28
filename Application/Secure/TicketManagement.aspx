<%@ Register TagPrefix="Module" TagName="Copyright" Src="../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../incl/calendar.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../incl/CSSToolbar.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TicketManagement.aspx.vb"
    Inherits="QIS.Web.TicketManagement" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
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
                        <td class="Heading2">
                            Change Request Management
                        </td>
                    </tr>
                    <tr>
                        <td class="hseparator">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%;">
                            <table width="100%">
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
                                                                                    ID="_lbtnIssueID" CommandName="IssueReponse" ForeColor="blue" CausesValidation="false"
                                                                                    ToolTip="Add Response" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <%# DataBinder.Eval(Container.DataItem, "projectAliasName") %>
                                                                            </td>
                                                                        </tr>
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
                                                                                <%# DataBinder.Eval(Container.DataItem, "issueTypeName")%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="txtweak">
                                                                                <%# DataBinder.Eval(Container.DataItem, "issuePriorityName")%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="txtweak">
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
                                                                                    ID="_lbtnIssueID" CommandName="IssueReponse" ForeColor="blue" CausesValidation="false"
                                                                                    ToolTip="Add Response" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <%# DataBinder.Eval(Container.DataItem, "projectAliasName") %>
                                                                            </td>
                                                                        </tr>
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
                                                                                <%# DataBinder.Eval(Container.DataItem, "issueTypeName")%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="txtweak">
                                                                                <%# DataBinder.Eval(Container.DataItem, "issuePriorityName")%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="txtweak">
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
                                                                                    ID="_lbtnIssueID" CommandName="IssueReponse" ForeColor="blue" CausesValidation="false"
                                                                                    ToolTip="Add Response" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <%# DataBinder.Eval(Container.DataItem, "projectAliasName") %>
                                                                            </td>
                                                                        </tr>
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
                                                                                <%# DataBinder.Eval(Container.DataItem, "issueTypeName")%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="txtweak">
                                                                                <%# DataBinder.Eval(Container.DataItem, "issuePriorityName")%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="txtweak">
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
                                                                                    ID="_lbtnIssueID" CommandName="IssueReponse" ForeColor="blue" CausesValidation="false"
                                                                                    ToolTip="Add Response" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <%# DataBinder.Eval(Container.DataItem, "projectAliasName") %>
                                                                            </td>
                                                                        </tr>
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
                                                                                <%# DataBinder.Eval(Container.DataItem, "issueTypeName")%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="txtweak">
                                                                                <%# DataBinder.Eval(Container.DataItem, "issuePriorityName")%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="txtweak">
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
