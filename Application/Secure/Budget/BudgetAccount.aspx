<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../../incl/calendar.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BudgetAccount.aspx.vb"
    Inherits="QIS.Web.Secure.BudgetAccount" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Anggaran Berdasarkan Perkiraan</title>
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
                                                        <asp:Label ID="lblPageTitle" runat="server" Text="Anggaran Perkiraan"></asp:Label>
                                                    </td>
                                                    <td style="width: 50%; text-align: right;">
                                                        <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="/qistoollib/images/ico-edit.png"
                                                            ToolTip="Edit Anggaran" Width="32" ImageAlign="AbsMiddle" />
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
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="hseparator" style="width: 100%;">
                                            </td>
                                        </tr>
                                        <tr class="rbody">
                                            <td valign="top">
                                                <asp:DataGrid ID="grdBudget" runat="server" BorderWidth="0" GridLines="None" Width="100%"
                                                    CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false" AutoGenerateColumns="false">
                                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                    <ItemStyle CssClass="gridItemStyle" />
                                                    <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                    <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                    <Columns>
                                                        <asp:TemplateColumn runat="server" HeaderText="Kode Akun">
                                                            <ItemTemplate>
                                                                <asp:Label ID="_lblGLAccountID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GLAccountID")%>'
                                                                    Visible="false"></asp:Label>
                                                                <%# DataBinder.Eval(Container.DataItem, "GLAccountNo")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn runat="server" HeaderText="Nama Akun">
                                                            <ItemTemplate>
                                                                <%# DataBinder.Eval(Container.DataItem, "GLAccountName")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn runat="server" HeaderText="Jumlah Anggaran">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="_txtBudgetAmount" runat="server" Text='<%# Format(DataBinder.Eval(Container.DataItem, "BudgetAmount"),"#,##0.00")%>'
                                                                    Width="200" Class="right"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                </asp:DataGrid>
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
                                                            <asp:TextBox ID="txtBudgetPeriodRealization" Width="100" MaxLength="4" runat="server" />
                                                        </td>
                                                        <td style="width: 150px;" class="right">
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 150px;" class="right">
                                                            Periode Realisasi sampai
                                                        </td>
                                                        <td style="width: 500px;">
                                                            <asp:DropDownList ID="ddlTahunRealisasi" Width="100" runat="server" AutoPostBack="true" />
                                                            <asp:DropDownList ID="ddlBulanRealisasi" Width="150" runat="server" />
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
                                                <asp:DataGrid ID="grdBudgetRealization" runat="server" BorderWidth="0" GridLines="None"
                                                    Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                    AutoGenerateColumns="false">
                                                    <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                    <ItemStyle CssClass="gridItemStyle" />
                                                    <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                    <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                    <Columns>
                                                        <asp:TemplateColumn runat="server" HeaderText="Kode Akun">
                                                            <ItemTemplate>
                                                                <asp:Label ID="_lblGLAccountID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GLAccountID")%>'
                                                                    Visible="false"></asp:Label>
                                                                <%# DataBinder.Eval(Container.DataItem, "GLAccountNo")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn runat="server" HeaderText="Nama Akun">
                                                            <ItemTemplate>
                                                                <%# DataBinder.Eval(Container.DataItem, "GLAccountName")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn runat="server" HeaderText="Jumlah Anggaran">
                                                            <ItemTemplate>
                                                                <asp:Label ID="_lblBudgetAmount" runat="server" Text='<%# Format(DataBinder.Eval(Container.DataItem, "BudgetAmount"),"#,##0.00")%>'
                                                                    Class="right"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn runat="server" HeaderText="Jumlah Realisasi">
                                                            <ItemTemplate>
                                                                <asp:Label ID="_lblRealizationAmount" runat="server" Text='<%# Format(DataBinder.Eval(Container.DataItem, "RealizationAmount"),"#,##0.00")%>'
                                                                    Class="right"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn runat="server" HeaderText="Nilai Varians">
                                                            <ItemTemplate>
                                                                <asp:Label ID="_lblDiffAmount" runat="server" Text='<%# Format(DataBinder.Eval(Container.DataItem, "VarianceAmount"),"#,##0.00")%>'
                                                                    Class="right"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn runat="server" HeaderText="Persentase Varians">
                                                            <ItemTemplate>
                                                                <%# Format(DataBinder.Eval(Container.DataItem, "VariancePercentage"),"#,##0.00")%> %
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
