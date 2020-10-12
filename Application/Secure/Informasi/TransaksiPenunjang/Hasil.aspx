<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../../../incl/RadMenu.ascx" %>
<%--<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../../../incl/CSSToolbar.ascx" %>--%>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Hasil.aspx.vb"
    Inherits="QIS.Web.Secure.Hasil" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Hasil Pemeriksaan</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1" />
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <meta http-equiv="refresh" content="600" />
    <link href='/qistoollib/css/styles.css' type="text/css" rel="Stylesheet" />
<%--
    <script src='/qislib/scripts/MD_/md___Dlg_rs-v2.js' language="javascript"></script>

    <link href="/qislib/calendar/calWebStyles_V40.css" rel="stylesheet" />

    <script src='<%= UrlBase + "/JSDLGGlobalVar.aspx" %>' language="javascript"></script>--%>

</head>
<body ms_positioning="GridLayout">
    <form id="frmHasil" runat="server">
    <table border="0" width="100%" style="height: 100%;" cellspacing="0" cellpadding="2">
        <tr>
            <%--<td width="100%" valign="top">
                <Module:RadMenu ID="RadMenu" runat="server" />
            </td>--%>
        </tr>
        <tr>
            <td width="100%" style="height: 100%;" valign="top">
                <div style="width: 100%; height: 100%; overflow: auto;">
                    <table cellspacing="10" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td align="left">
                                <asp:Panel ID="pnl_1" runat="server">
                                    <table cellspacing="0" cellpadding="5" width="100%">
                                        <tr class="rheader">
                                            <td class="rheadercol" align="left" height="25">
                                                Hasil Pemeriksaan
                                            </td>
                                        </tr>
                                        <tr class="rbody">
                                            <td class="rbodycol" align="center" height="25">
                                                <div style="overflow: auto; width: 100%">
                                                    <table cellspacing="0" cellpadding="5" width="100%">
                                                        <tr>
                                                            <td width="100%">
                                                                <asp:DataGrid ID="grdHasil" runat="server" Width="100%" style="Height:400px" CellPadding="0" ShowFooter="True"
                                                                    DataKeyField="" PageSize="20" AllowPaging="False" GridLines="Horizontal" BorderWidth="1"
                                                                    BorderColor="Gainsboro" CellSpacing="0" AutoGenerateColumns="False" AllowSorting="True">
                                                                    <HeaderStyle CssClass="gridHeaderStyle" />
                                                                    <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                    <EditItemStyle Font-Bold="false" />
                                                                    <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                    <Columns>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Pelayanan"
                                                                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <table>
                                                                                    <tr>
                                                                                        <td style="color: #000000;">
                                                                                            <asp:Label runat="server" Style="margin-right: 5" Text='<%# DataBinder.Eval(Container.DataItem, "nmlayan") %>'
                                                                                                ID="_lblnmlayan" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="txtweak">
                                                                                            <asp:Label runat="server" Style="margin-right: 5" Text='<%# DataBinder.Eval(Container.DataItem, "KdLayan") %>'
                                                                                                ID="_lblkdlayan" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Hasil Pemeriksaan"
                                                                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"  ItemStyle-VerticalAlign="Top" 
                                                                            ItemStyle-Width="65%" HeaderStyle-Width="65%">
                                                                            <ItemTemplate>
                                                                                <table >
                                                                                    <tr>
                                                                                        <td style="color: #000000;" valign="top">
                                                                                            <asp:TextBox ID="_txtresult" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "result") %>'
                                                                                                TextMode="MultiLine" Width="700px" style="Height:400px" Enabled="false" BorderStyle="None"></asp:TextBox>
                                                                                            <%--<asp:Label runat="server" Style="margin-right: 5" Text='<%# DataBinder.Eval(Container.DataItem, "result") %>'
                                                                                                ID="_lblresult" Visible="false" />--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Petugas"
                                                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                            ItemStyle-Width="230">
                                                                            <ItemTemplate>
                                                                                <table>
                                                                                    <tr>
                                                                                        <td style="width: 110px; font-style: italic; text-align: right;" valign="top">
                                                                                            Created by :
                                                                                        </td>
                                                                                        <td style="color: #000000;" valign="top">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "usrinsert") %>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 110px; font-style: italic; text-align: right;" valign="top">
                                                                                            on :
                                                                                        </td>
                                                                                        <td style="color: #000000;" valign="top">
                                                                                            <%# Format(DataBinder.Eval(Container.DataItem, "tglinsert"), "dd-MMM-yyyy HH:mm") %>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 110px; font-style: italic; text-align: right;" valign="top">
                                                                                            Last update by :
                                                                                        </td>
                                                                                        <td style="color: #000000;" valign="top">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "usrupdate") %>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 110px; font-style: italic; text-align: right;" valign="top">
                                                                                            on :
                                                                                        </td>
                                                                                        <td style="color: #000000;" valign="top">
                                                                                            <%# Format(DataBinder.Eval(Container.DataItem, "tglupdate"), "dd-MMM-yyyy HH:mm") %>
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
                                                    <!--GRID END HERE-->
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
