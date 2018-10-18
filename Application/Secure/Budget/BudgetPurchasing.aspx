<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../../incl/calendar.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BudgetPurchasing.aspx.vb"
    Inherits="QIS.Web.Secure.BudgetPurchasing" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Anggaran Pembelian</title>
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
            <td>
                <Module:CSSToolbar ID="CSSToolbar" runat="server"></Module:CSSToolbar>
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
                                            <table width="100%">
                                                <tr>
                                                    <td class="rheader" style="width: 50%;">
                                                        <asp:Label ID="lblPageTitle" runat="server" Text="Anggaran Pembelian"></asp:Label>
                                                    </td>
                                                    <td style="width: 50%; text-align: right;">
                                                        <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="/qistoollib/images/ico-edit.png"
                                                            ToolTip="Edit Anggaran" Width="32" ImageAlign="AbsMiddle" />
                                                        <asp:ImageButton ID="ibtnMapping" runat="server" ImageUrl="/qistoollib/images/ico-summary.png"
                                                            ToolTip="Mapping Anggaran" Width="32" ImageAlign="AbsMiddle" />
                                                        <asp:ImageButton ID="ibtnRealisasi" runat="server" ImageUrl="/qistoollib/images/ico-detail.png"
                                                            ToolTip="Informasi Realisasi Anggaran" Width="32" ImageAlign="AbsMiddle" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" style="width: 100%;">
                                        </td>
                                    </tr>
                                    <asp:Panel ID="pnlBudgetSetting" runat="server">
                                        <tr class="rbody">
                                            <td valign="top">
                                                <table width="100%">
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:ValidationSummary ID="ValidationSummary" runat="server" HeaderText="Please fill the following Field(s)." />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 150px;" class="right">
                                                            Periode Anggaran
                                                        </td>
                                                        <td style="width: 500px;">
                                                            <asp:TextBox ID="txtBudgetPeriod" Width="100" MaxLength="4" runat="server" />
                                                        </td>
                                                        <td style="width: 150px;" class="right">
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="hseparator" style="width: 100%;" colspan="4">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 150px;" class="right">
                                                            Kode Mata Anggaran
                                                        </td>
                                                        <td style="width: 500px;">
                                                            <asp:TextBox ID="txtBudgetCode" Width="300" runat="server" />
                                                        </td>
                                                        <td style="width: 150px;" class="right">
                                                            Harga Satuan
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtUnitPrice" Width="200" runat="server" class="right" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 150px;" class="right">
                                                            Nama Mata Anggaran
                                                        </td>
                                                        <td style="width: 500px;">
                                                            <asp:TextBox ID="txtBudgetName" Width="300" runat="server" />
                                                        </td>
                                                        <td style="width: 150px;" class="right">
                                                            Quantity
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtQuantity" Width="100" runat="server" class="right" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 150px;" class="right">
                                                            Kategori
                                                        </td>
                                                        <td style="width: 500px;">
                                                            <asp:DropDownList ID="ddlPurchaseOrderType" Width="300" runat="server" />
                                                        </td>
                                                        <td style="width: 150px;" class="right">
                                                            Lokasi
                                                        </td>
                                                        <td>
                                                            <telerik:RadComboBox Style="z-index: 0" ID="rcbLocation" runat="server" AutoPostBack="false"
                                                                Skin="Windows7" ShowMoreResultBox="false" AllowCustomText="true" ItemRequestTimeout="200"
                                                                DropDownWidth="500" HighlightTemplatedItems="true" EnableLoadOnDemand="true"
                                                                MarkFirstMatch="true" Width="300" Height="200" ShowDropDownOnTextboxClick="False"
                                                                DataValueField="LocationID" DataTextField="LocationName">
                                                                <HeaderTemplate>
                                                                    <table style="width: 415px; text-align: left;">
                                                                        <tr>
                                                                            <td style="width: 50px;">
                                                                                ID
                                                                            </td>
                                                                            <td>
                                                                                Nama
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <table style="width: 415px; text-align: left;">
                                                                        <tr>
                                                                            <td style="width: 50px;">
                                                                                <%# DataBinder.Eval(Container.DataItem, "LocationID")%>
                                                                            </td>
                                                                            <td>
                                                                                <%# DataBinder.Eval(Container.DataItem, "LocationName")%>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </telerik:RadComboBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 150px;" class="right">
                                                            Kode Akun
                                                        </td>
                                                        <td style="width: 500px;">
                                                            <telerik:RadComboBox Style="z-index: 0" ID="rcbAccount" runat="server" AutoPostBack="false"
                                                                Skin="Windows7" ShowMoreResultBox="false" AllowCustomText="true" ItemRequestTimeout="200"
                                                                DropDownWidth="500" HighlightTemplatedItems="true" EnableLoadOnDemand="true"
                                                                MarkFirstMatch="true" Width="300" Height="200" ShowDropDownOnTextboxClick="False"
                                                                DataValueField="GLAccountID" DataTextField="GLAccountName">
                                                                <HeaderTemplate>
                                                                    <table style="width: 415px; text-align: left;">
                                                                        <tr>
                                                                            <td style="width: 80px;">
                                                                                Kode
                                                                            </td>
                                                                            <td>
                                                                                Nama
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <table style="width: 415px; text-align: left;">
                                                                        <tr>
                                                                            <td style="width: 80px;">
                                                                                <%# DataBinder.Eval(Container.DataItem, "GLAccountNo")%>
                                                                            </td>
                                                                            <td>
                                                                                <%# DataBinder.Eval(Container.DataItem, "GLAccountName")%>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </telerik:RadComboBox>
                                                        </td>
                                                        <td style="width: 150px;" class="right">
                                                        </td>
                                                        <td>
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
                                                <asp:DataGrid ID="grdBudgetPurchasing" runat="server" BorderWidth="0" GridLines="None"
                                                    Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                    AutoGenerateColumns="false">
                                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                    <ItemStyle CssClass="gridItemStyle" />
                                                    <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                    <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                    <Columns>
                                                        <asp:TemplateColumn runat="server" HeaderText="Periode">
                                                            <ItemTemplate>
                                                                <%# DataBinder.Eval(Container.DataItem, "BudgetPeriod")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn runat="server" HeaderText="Kode Mata Anggaran">
                                                            <ItemTemplate>
                                                                <%# DataBinder.Eval(Container.DataItem, "BudgetCode")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn runat="server" HeaderText="Nama Mata Anggaran">
                                                            <ItemTemplate>
                                                                <%# DataBinder.Eval(Container.DataItem, "BudgetName")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn runat="server" HeaderText="Harga Satuan" HeaderStyle-HorizontalAlign="Right"
                                                            ItemStyle-HorizontalAlign="Right">
                                                            <ItemTemplate>
                                                                <%# Format(DataBinder.Eval(Container.DataItem, "UnitPrice"),"#,##0.00")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn runat="server" HeaderText="Quantity" HeaderStyle-HorizontalAlign="Right"
                                                            ItemStyle-HorizontalAlign="Right">
                                                            <ItemTemplate>
                                                                <%# DataBinder.Eval(Container.DataItem, "Quantity")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn runat="server" HeaderText="Jumlah Anggaran" HeaderStyle-HorizontalAlign="Right"
                                                            ItemStyle-HorizontalAlign="Right">
                                                            <ItemTemplate>
                                                                <%# Format(DataBinder.Eval(Container.DataItem, "UnitPrice") * DataBinder.Eval(Container.DataItem, "Quantity"),"#,##0.00")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn runat="server" HeaderText="Kategori">
                                                            <ItemTemplate>
                                                                <%# DataBinder.Eval(Container.DataItem, "PurchaseOrderTypeName")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn runat="server" HeaderText="Lokasi">
                                                            <ItemTemplate>
                                                                <%# DataBinder.Eval(Container.DataItem, "LocationName")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn runat="server" HeaderText="Perkiraan">
                                                            <ItemTemplate>
                                                                <%# DataBinder.Eval(Container.DataItem, "GLAccountNo") + " - " + DataBinder.Eval(Container.DataItem, "GLAccountName")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                </asp:DataGrid>
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlBudgetMapping" runat="server">
                                        <tr class="rbody">
                                            <td valign="top">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 150px;" class="right">
                                                            Periode Anggaran
                                                        </td>
                                                        <td style="width: 500px;">
                                                            <asp:DropDownList ID="ddlYearInBudget" Width="100" runat="server" AutoPostBack="true" />
                                                        </td>
                                                        <td style="width: 150px;" class="right">
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="hseparator" style="width: 100%;" colspan="4">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 150px;" class="right">
                                                            Mata Anggaran
                                                        </td>
                                                        <td style="width: 500px;">
                                                            <asp:DropDownList ID="ddlMataAnggaranMapping" Width="300" runat="server" />
                                                        </td>
                                                        <td style="width: 150px;" class="right">
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td style="width: 40%;" valign="top">
                                                                        <asp:DataGrid ID="grdItemGroupExMapping" runat="server" BorderWidth="0" GridLines="None"
                                                                            Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                            AutoGenerateColumns="false">
                                                                            <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                            <ItemStyle CssClass="gridItemStyle" />
                                                                            <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                            <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                            <Columns>
                                                                                <asp:TemplateColumn runat="server" HeaderText="Pilih">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="_chkSelect" runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                                <asp:TemplateColumn runat="server" HeaderText="Kode Item Group">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="_lblItemGroupID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ItemGroupID")%>'></asp:Label>
                                                                                        <%# DataBinder.Eval(Container.DataItem, "ItemGroupCode")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                                <asp:TemplateColumn runat="server" HeaderText="Nama Item Group">
                                                                                    <ItemTemplate>
                                                                                        <%# DataBinder.Eval(Container.DataItem, "ItemGroupName")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                            </Columns>
                                                                        </asp:DataGrid>
                                                                    </td>
                                                                    <td style="width: 120px;" valign="top" class="center">
                                                                        <asp:Button ID="btnAdd" runat="server" Text="Add >" Width="100" CssClass="sbttn" />
                                                                        <br />
                                                                        <asp:Button ID="btnRemove" runat="server" Text="< Remove" Width="100" CssClass="sbttn" />
                                                                    </td>
                                                                    <td style="width: 40%;" valign="top">
                                                                        <asp:DataGrid ID="grdItemGroupInMapping" runat="server" BorderWidth="0" GridLines="None"
                                                                            Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                            AutoGenerateColumns="false">
                                                                            <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                            <ItemStyle CssClass="gridItemStyle" />
                                                                            <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                            <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                            <Columns>
                                                                                <asp:TemplateColumn runat="server" HeaderText="Pilih">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="_chkSelect" runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                                <asp:TemplateColumn runat="server" HeaderText="Kode Item Group">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="_lblItemGroupID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ItemGroupID")%>'></asp:Label>
                                                                                        <%# DataBinder.Eval(Container.DataItem, "ItemGroupCode")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                                <asp:TemplateColumn runat="server" HeaderText="Nama Item Group">
                                                                                    <ItemTemplate>
                                                                                        <%# DataBinder.Eval(Container.DataItem, "ItemGroupName")%>
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
                                    </asp:Panel>
                                    <asp:Panel ID="pnlBudgetRealizations" runat="server">
                                        <tr class="rbody">
                                            <td valign="top">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 150px;" class="right">
                                                            Periode Anggaran
                                                        </td>
                                                        <td style="width: 500px;">
                                                            <asp:DropDownList ID="ddlBudgetPeriodRealization" Width="100" runat="server" AutoPostBack="true" />
                                                        </td>
                                                        <td style="width: 150px;" class="right">
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="hseparator" style="width: 100%;" colspan="4">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 150px;" class="right">
                                                            Lokasi
                                                        </td>
                                                        <td style="width: 500px;">
                                                            <telerik:RadComboBox Style="z-index: 0" ID="rcbLocationRealization" runat="server" AutoPostBack="false"
                                                                Skin="Windows7" ShowMoreResultBox="false" AllowCustomText="true" ItemRequestTimeout="200"
                                                                DropDownWidth="500" HighlightTemplatedItems="true" EnableLoadOnDemand="true"
                                                                MarkFirstMatch="true" Width="300" Height="200" ShowDropDownOnTextboxClick="False"
                                                                DataValueField="LocationID" DataTextField="LocationName">
                                                                <HeaderTemplate>
                                                                    <table style="width: 415px; text-align: left;">
                                                                        <tr>
                                                                            <td style="width: 50px;">
                                                                                ID
                                                                            </td>
                                                                            <td>
                                                                                Nama
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <table style="width: 415px; text-align: left;">
                                                                        <tr>
                                                                            <td style="width: 50px;">
                                                                                <%# DataBinder.Eval(Container.DataItem, "LocationID")%>
                                                                            </td>
                                                                            <td>
                                                                                <%# DataBinder.Eval(Container.DataItem, "LocationName")%>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </telerik:RadComboBox>
                                                        </td>
                                                        <td style="width: 150px;" class="right">
                                                        </td>
                                                        <td>
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
                                                <asp:DataGrid ID="grdBudgetPurchasingRealization" runat="server" BorderWidth="0" GridLines="None"
                                                    Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                    AutoGenerateColumns="false">
                                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                    <ItemStyle CssClass="gridItemStyle" />
                                                    <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                    <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                    <Columns>
                                                        <asp:TemplateColumn runat="server" HeaderText="Kode Mata Anggaran">
                                                            <ItemTemplate>
                                                                <%# DataBinder.Eval(Container.DataItem, "BudgetCode")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn runat="server" HeaderText="Nama Mata Anggaran">
                                                            <ItemTemplate>
                                                                <%# DataBinder.Eval(Container.DataItem, "BudgetName")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn runat="server" HeaderText="Kategori">
                                                            <ItemTemplate>
                                                                <%# DataBinder.Eval(Container.DataItem, "PurchaseOrderTypeName")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn runat="server" HeaderText="Perkiraan" Visible="false">
                                                            <ItemTemplate>
                                                                <%# DataBinder.Eval(Container.DataItem, "GLAccountNo") + " - " + DataBinder.Eval(Container.DataItem, "GLAccountName")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn runat="server" HeaderText="Harga Satuan" HeaderStyle-HorizontalAlign="Right"
                                                            ItemStyle-HorizontalAlign="Right">
                                                            <ItemTemplate>
                                                                <%# Format(DataBinder.Eval(Container.DataItem, "UnitPrice"),"#,##0.00")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn runat="server" HeaderText="Quantity" HeaderStyle-HorizontalAlign="Right"
                                                            ItemStyle-HorizontalAlign="Right">
                                                            <ItemTemplate>
                                                                <%# DataBinder.Eval(Container.DataItem, "Quantity")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn runat="server" HeaderText="Jumlah Anggaran" HeaderStyle-HorizontalAlign="Right"
                                                            ItemStyle-HorizontalAlign="Right">
                                                            <ItemTemplate>
                                                                <%# Format(DataBinder.Eval(Container.DataItem, "TotalBudgetAmount"), "#,##0.00")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn runat="server" HeaderText="Jumlah Realisasi" HeaderStyle-HorizontalAlign="Right"
                                                            ItemStyle-HorizontalAlign="Right">
                                                            <ItemTemplate>
                                                                <%# Format(DataBinder.Eval(Container.DataItem, "TotalRealizationAmount"), "#,##0.00")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn runat="server" HeaderText="Jumlah Varians" HeaderStyle-HorizontalAlign="Right"
                                                            ItemStyle-HorizontalAlign="Right">
                                                            <ItemTemplate>
                                                                <%# Format(DataBinder.Eval(Container.DataItem, "TotalVarianceAmount"), "#,##0.00")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn runat="server" HeaderText="Persentase Varians" HeaderStyle-HorizontalAlign="Right"
                                                            ItemStyle-HorizontalAlign="Right">
                                                            <ItemTemplate>
                                                                <%# Format(DataBinder.Eval(Container.DataItem, "TotalVariancePercent"), "#,##0.00")%> %
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>                                                        
                                                    </Columns>
                                                </asp:DataGrid>
                                            </td>
                                        </tr>
                                    </asp:Panel>
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
