<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../../incl/CSSToolbar.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="card.aspx.vb" Inherits="QIS.Web.WorkTime.Card" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Medinfras Worktime Card</title>
    <link rel="title icon" href="/qistoollib/images/favicon.png" />
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href="/qistoollib/css/styles_blue.css" type="text/css" rel="Stylesheet" />
    <script language="javascript" type="text/javascript" src="/qistoollib/scripts/JScript.js"></script>
    <style type="text/css">
        #ulRepWorktimeCard
        {
            width: 100%;
            margin: 0;
            padding: 0;                     
        }
        #ulRepWorktimeCard li
        {
            list-style-type: none;
            display: inline-block; /* FF3.6; Chrome10+ */                     
            *display: inline;
            border-radius: 10px;
            background: #eeeeee;
            width: 45%;
            height: 250px;
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
                <table width="150" style="height: 60px;">
                    <tr>
                        <td class="Heading2">
                            Select Date
                        </td>
                    </tr>
                    <tr>
                        <td class="hseparator">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtYear" runat="server" Width="150" AutoPostBack="true">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlMonth" runat="server" Width="150" AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DataGrid ID="grdDateInMonth" runat="server" BorderWidth="0" GridLines="None"
                                Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="false" ShowFooter="false"
                                AutoGenerateColumns="false">
                                <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                <ItemStyle CssClass="gridItemStyle" />
                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                <Columns>
                                    <asp:TemplateColumn runat="server" HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DateInMonth") %>'
                                                ID="_lbtnDateInMonth" CommandName="SelectDate" />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                            </asp:DataGrid>
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
                            <asp:Label ID="lblPageTitle" runat="server" Text="Worktime Card"></asp:Label>&nbsp;
                            <asp:Label ID="lblSelectedDate" runat="server"></asp:Label>
                            <asp:Label ID="lblSelectedDateInDate" runat="server" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="hseparator">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td style="width: 100%;">
                                        <asp:Repeater ID="repWorktimeCard" runat="server" OnItemDataBound="repWorktimeCard_ItemDataBound">
                                            <HeaderTemplate>
                                                <ul id="ulRepWorktimeCard">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <li>
                                                    <table cellspacing="1" width="100%">
                                                        <tr>
                                                            <td style="width: 70;" rowspan="3">
                                                                <asp:Image ID="_imgPic" runat="server" ImageUrl="/qistoollib/images/mpic.png" ImageAlign="Top" />                                                                
                                                            </td>
                                                            <td class="Heading3">
                                                                <asp:Label ID="_lblUserID" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "UserID") %>'></asp:Label>
                                                                <asp:Label ID="_lblFullName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FullName") %>'></asp:Label>
                                                                <asp:Label ID="_lblGenderName" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "SexName") %>'></asp:Label>
                                                            </td>
                                                            <td align="right">
                                                                <asp:Image ID="_imgSubmitted" runat="server" ImageUrl="/qistoollib/images/submitted.png" ToolTip="Submitted Worktime" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="hseparator" colspan="2">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                This Month Summary. Total Count:
                                                                <asp:Label ID="_lblTotalCountWorktime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalCountWorktime") %>'></asp:Label>&nbsp;|
                                                                Total Hour:
                                                                <asp:Label ID="_lblTotalSumWorktime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalSumWorktime") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                <div id="div1" style="overflow: auto; width: 100%; height: 180px;">
                                                                    <asp:DataGrid ID="_grdWorkTimeDt" runat="server" BorderWidth="0" GridLines="None"
                                                                        Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                        AutoGenerateColumns="false">
                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                        <ItemStyle CssClass="gridItemStyle" />
                                                                        <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                        <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                        <Columns>
                                                                            <asp:TemplateColumn runat="server" HeaderText="Project">
                                                                                <ItemTemplate>
                                                                                    <div class="txtweak"><%# DataBinder.Eval(Container.DataItem, "projectAliasName")%></div>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateColumn>
                                                                            <asp:TemplateColumn runat="server" HeaderText="Description">
                                                                                <ItemTemplate>
                                                                                    <div class="txtweak"><%# DataBinder.Eval(Container.DataItem, "DetailDescription")%></div>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateColumn>
                                                                            <asp:TemplateColumn runat="server" HeaderText="Issue#">
                                                                                <ItemTemplate>
                                                                                    <div class="txtweak"><%# DataBinder.Eval(Container.DataItem, "IssueID")%></div>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateColumn>
                                                                            <asp:TemplateColumn runat="server" HeaderText="Hour">
                                                                                <ItemTemplate>
                                                                                    <div class="txtweak"><%# DataBinder.Eval(Container.DataItem, "WorkTimeInHour")%></div>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateColumn>
                                                                        </Columns>
                                                                    </asp:DataGrid>
                                                                </div>
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
