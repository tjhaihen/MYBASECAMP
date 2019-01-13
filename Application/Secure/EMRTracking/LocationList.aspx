<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../../incl/calendar.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LocationList.aspx.vb"
    Inherits="QIS.Web.EMRTracking.LocationList" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>EMR Location</title>
    <link rel="title icon" href="/qistoollib/images/favicon.png" />
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href='/qistoollib/css/styles_blue.css' type="text/css" rel="Stylesheet" />
    <script language="javascript" type="text/javascript" src="/qistoollib/scripts/JScript.js"></script>
    <script type="text/javascript" language="javascript" src='/qistoollib/scripts/common/common.js'></script>
</head>
<body>
    <form id="frm" runat="server">
    <table border="0" width="100%" cellspacing="2" cellpadding="1" style="height: 100%;">
        <tr>
            <td width="100%" valign="top">
                <!-- BEGIN PAGE HEADER -->
                <Module:RadMenu ID="RadMenu" runat="server" />
                <!-- END PAGE HEADER -->
            </td>
        </tr>
        <tr>
            <td width="100%" height="100%" valign="top">
                <div style="width: 100%; height: 100%; overflow: auto;">
                    <table cellspacing="10" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td align="left">
                                <table cellspacing="0" cellpadding="5" width="100%">
                                    <tr>
                                        <td class="rheader">
                                            Lokasi Tracking Bekas Rekam Medik
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" style="width: 100%;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <Module:CSSToolbar ID="CSSToolbar" runat="server"></Module:CSSToolbar>
                                        </td>
                                    </tr>
                                    <tr class="rbody">
                                        <td valign="top">
                                            <table width="100%">
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:ValidationSummary ID="ValidationSummary" runat="server" HeaderText="Please fill the following Field(s)." />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="50%" valign="top">
                                                        <table width="100%">
                                                            <tr>
                                                                <td style="width: 150px;" class="right">
                                                                    Kode Kelompok Lokasi
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtEMRlocationGroupCode" Width="300" runat="server" AutoPostBack="True"
                                                                        ReadOnly="true" CssClass="txtReadOnly" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 150px;" class="right">
                                                                    Nama Kelompok Lokasi
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtEMRlocationGroupName" Width="300" MaxLength="50" runat="server" />
                                                                    <asp:RequiredFieldValidator ID="rfvEMRlocationGroupName" runat="server" ControlToValidate="txtEMRlocationGroupName"
                                                                        ErrorMessage="Nama Kelompok Lokasi" Display="dynamic" Text="*">
                                                                    </asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkIsActive" runat="server" Text="Aktif?" Checked="True" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="50%" valign="top">
                                                        <table width="100%" bgcolor="#eeeeee">
                                                            <tr>
                                                                <td style="width: 150px;" class="right">
                                                                    Kode Lokasi
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtEMRLocationCode" Width="300" runat="server" AutoPostBack="True"
                                                                        ReadOnly="true" CssClass="txtReadOnly" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 150px;" class="right">
                                                                    Nama Lokasi
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtEMRLocationName" Width="300" MaxLength="50" runat="server" />
                                                                    <asp:Button ID="btnSaveLocation" runat="server" Text="Save" CssClass="sbttn" CausesValidation="true" />
                                                                    <asp:RequiredFieldValidator ID="rfvEMRlocationName" runat="server" ControlToValidate="txtEMRLocationName"
                                                                        ErrorMessage="Nama Lokasi" Display="dynamic" Text="*">
                                                                    </asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkIsActiveLocation" runat="server" Text="Aktif?" Checked="True" />
                                                                </td>
                                                            </tr>
                                                            <tr class="rbody">
                                                                <td valign="top" colspan="2">
                                                                    <asp:DataGrid ID="grdEMRLocation" runat="server" BorderWidth="0" GridLines="None" Width="100%"
                                                                        CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false" AutoGenerateColumns="false">
                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                        <ItemStyle CssClass="gridItemStyle" />
                                                                        <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                        <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                        <Columns>
                                                                            <asp:TemplateColumn runat="server" ItemStyle-Width="50">
                                                                                <ItemTemplate>
                                                                                    <asp:ImageButton ID="_ibtnEdit" runat="server" ImageUrl="/qistoollib/images/edit.png"
                                                                                        ImageAlign="AbsMiddle" CommandName="Edit" CausesValidation="false" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateColumn>
                                                                            <asp:TemplateColumn runat="server" HeaderText="Kode">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "locationGroupCode") %>'
                                                                                        ID="_lblEMRlocationGroupCode" Visible="false" />
                                                                                    <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "locationCode") %>'
                                                                                        ID="_lblEMRlocationCode" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateColumn>
                                                                            <asp:TemplateColumn runat="server" HeaderText="Name">
                                                                                <ItemTemplate>
                                                                                    <%# DataBinder.Eval(Container.DataItem, "locationName")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateColumn>
                                                                            <asp:TemplateColumn runat="server" HeaderText="Aktif?">
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="_chkIsActive" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "IsActive") %>'
                                                                                        Enabled="false" />
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
                                        <td class="hseparator" style="width: 100%;">
                                        </td>
                                    </tr>
                                    <tr class="rbody">
                                        <td valign="top">
                                            <asp:DataGrid ID="grdEMRLocationGroup" runat="server" BorderWidth="0" GridLines="None"
                                                Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                AutoGenerateColumns="false">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                <ItemStyle CssClass="gridItemStyle" />
                                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                <Columns>
                                                    <asp:TemplateColumn runat="server" ItemStyle-Width="50">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="_ibtnEdit" runat="server" ImageUrl="/qistoollib/images/edit.png"
                                                                ImageAlign="AbsMiddle" CommandName="Edit" CausesValidation="false" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Kode">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "locationGroupCode") %>'
                                                                ID="_lblEMRlocationGroupCode" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Name">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "locationGroupName")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Aktif?">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="_chkIsActive" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "IsActive") %>'
                                                                Enabled="false" />
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
                </div>
            </td>
        </tr>
        <tr>
            <td valign="bottom" style="padding-left: 20px">
                <!-- BEGIN PAGE FOOTER-->
                <Module:Copyright ID="mdlCopyRight" runat="server" PathPrefix=".."></Module:Copyright>
                <!-- END PAGE FOOTER-->
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
