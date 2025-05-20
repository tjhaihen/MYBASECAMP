<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../../incl/CSSToolbar.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Hardening.aspx.vb" Inherits="QIS.Web.Hardening" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Medinfras Hardening</title>
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
            background: #606060;
            width: 20px;
            height: 20px;
            margin: 0px;
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
    <table width="100%" cellpadding="2" cellspacing="0">
        <tr>
            <td valign="top" style="width: 100%;">
                <!-- BEGIN PAGE HEADER -->
                <Module:RadMenu ID="RadMenu" runat="server" />
                <!-- END PAGE HEADER -->
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 100%;">
                <table width="100%">
                    <tr>
                        <td class="Heading2" colspan="3">
                            <asp:Label ID="lblPageTitle" runat="server" Text="Hardening Checklist"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="hseparator" colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px;">
                            <Module:CSSToolbar ID="CSSToolbar" runat="server"></Module:CSSToolbar>
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="lbtNoHardening" runat="server" CausesValidation="False" Text ="No. Hardening" ForeColor="blue">
                                        </asp:LinkButton>
                                    </td>
                                    <td>
                                        Perangkat
                                    </td>
                                    <td>
                                        No. Aset
                                    </td>
                                    <td>
                                        Pengguna
                                    </td>
                                    <td>
                                        Catatan
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtNoHardening" runat="server" Width="250" AutoPostBack="true">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlPerangkat" runat="server" Width="150" AutoPostBack="false">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNoAsset" runat="server" Width="250" AutoPostBack="true">
                                        </asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlPengguna" runat="server" Width="200" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtcatatan" runat="server" Width="360"  Height="80" TextMode="MultiLine" AutoPostBack="false">
                                        </asp:TextBox>
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
                            <asp:DataGrid ID="grdHardening" runat="server" BorderWidth="0" GridLines="None"
                                Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="True" ShowFooter="false"
                                AutoGenerateColumns="false">
                                <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                <ItemStyle CssClass="gridItemStyle" />
                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                <Columns>
                                    <asp:TemplateColumn runat="server" HeaderText="KODE" ItemStyle-Width="50"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="txtCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "code") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn runat="server" HeaderText="ITEM PERIKSA" ItemStyle-Width="200"
                                        ItemStyle-HorizontalAlign="LefT" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="txtItem" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Caption") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn runat="server" HeaderText="STANDARD"  ItemStyle-Width="700"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="txtStandard" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "value")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn runat="server" HeaderText="HASIL"  ItemStyle-Width="50"
                                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkHasil" runat="server" Checked='<%# iif(DataBinder.Eval(Container.DataItem, "Hasil")=true, True, false) %>' />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn runat="server" HeaderText="KETERANGAN"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCatatan" runat="server" Width="500" Height="50" TextMode="MultiLine" Text='<%# DataBinder.Eval(Container.DataItem, "Catatan") %>'
                                                ReadOnly='<%# iif(DataBinder.Eval(Container.DataItem, "isPropose")=true, True, False) %>' />
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
            <td valign="bottom">
                <!-- BEGIN PAGE FOOTER-->
                <Module:Copyright ID="mdlCopyRight" runat="server" pathprefix=".."></Module:Copyright>
                <!-- END PAGE FOOTER-->
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
