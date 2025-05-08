<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../../incl/CSSToolbar.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CheckListServer.aspx.vb" Inherits="QIS.Web.WorkTime.CheckListServer" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>CHECKLIST INFRASTRUKTUR</title>
    <link rel="title icon" href="/qistoollib/images/favicon.png" />
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href="/qistoollib/css/styles_blue.css" type="text/css" rel="Stylesheet" />
    <script language="javascript" type="text/javascript" src="/qistoollib/scripts/JScript.js"></script>
    <style type="text/css">
        #ulRepDateInMonthDt
        {
            width: 100%;
            margin: 0;
            padding: 0;                     
        }
        #ulRepDateInMonthDt li
        {
            list-style-type: none;
            display: inline-block; /* FF3.6; Chrome10+ */                     
            *display: inline;
            background: #eeeeee;
            width: 280px;
            height: 150px;
            margin: 5px;
        }
        #ulRepDateInMonth
        {
            width: 100%;
            margin: 0;
            padding: 0;                     
        }
        #ulRepDateInMonth li
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
                                    <asp:TemplateColumn runat="server" HeaderText="IsChecked">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "IsChecked") %>'
                                                ID="_chkIsChecked" Enabled="false" />
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
                            <asp:Label ID="lblPageTitle" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="hseparator">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <Module:CSSToolbar ID="CSSToolbar" runat="server"></Module:CSSToolbar>
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
                                    <td class="right" style="width: 100;">
                                        Tanggal
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDayOfWeekSelectedDate" runat="server" Font-Bold="True"></asp:Label>
                                        <asp:Label ID="lblSelectedDate" runat="server" Font-Bold="true"></asp:Label>
                                       <%-- <asp:Label ID="lblWorkTimeHdID" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblWorkTimeDtID" runat="server" Visible="false"></asp:Label>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:DataGrid ID="grdCheck" runat="server" BorderWidth="0" GridLines="None"
                                            Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                            AutoGenerateColumns="false">
                                            <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                            <ItemStyle CssClass="gridItemStyle" />
                                            <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                            <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                            <Columns>
                                                <asp:TemplateColumn runat="server" HeaderText="Kode" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="txtCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "code")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn runat="server" HeaderText="Keterangan">
                                                    <ItemTemplate>
                                                        <asp:Label ID="txtKeterangan" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Caption")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn runat="server" HeaderText="Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="txtStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Value")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn runat="server" HeaderText="Pilih #">
                                                    <ItemTemplate>
                                                        <asp:CheckBox runat="server" Checked='<%# iif(DataBinder.Eval(Container.DataItem, "isCheck")=true, True, False) %>' ID="_chkPilih" />
                                                    </ItemTemplate>
                                                    <HeaderTemplate>
                                                        <input name="cbxSelectAll" type="checkbox" onclick="javascript:checkAll(this.form,'_chkPilih');">
                                                    </HeaderTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn runat="server" HeaderText="Catatan">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtCatatan" runat="server" Width="100%" Text='<%# DataBinder.Eval(Container.DataItem, "Catatan") %>'
                                                         ReadOnly='<%# iif(DataBinder.Eval(Container.DataItem, "isApprove")=true, True, False) %>' />
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
