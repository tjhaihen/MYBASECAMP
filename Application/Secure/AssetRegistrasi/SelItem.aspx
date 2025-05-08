<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SelItem.aspx.vb" Inherits="QIS.Web.Secure.Master.fa.SelItem" %>

<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../../../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="webcal" Src="../../../../incl/calendarModule.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Daftar Aktiva Tetap</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <meta http-equiv="refresh" content="600">
    <link href='/qislib/css/styles.css' type="text/css" rel="Stylesheet">

    <script src='/qislib/scripts/GL_/gl___Dlg_rs-v2.js' language="javascript"></script>

    <script src='<%= UrlBase + "/JSDLGGlobalVar.aspx" %>' language="javascript"></script>
    
    <script language="javascript">
        function Next() {
            var url = '<%= UrlBase + "/secure/master/fa/Assets/Aktiva.aspx?i=" %>';
            window.location.href = url;
        }

    </script>
</head>
<body>
    <form id="frmItem" runat="server">
    <table border="0" width="100%" cellspacing="0" cellpadding="2" style="height: 100%;">
        <tr>
            <td width="100%" valign="top">
                <!-- BEGIN PAGE HEADER -->
                <Module:RadMenu ID="RadMenu" runat="server" />
                <!-- END PAGE HEADER -->
            </td>
        </tr>
        <tr>
            <td width="100%" valign="top" style="height: 100%;">
                <table cellspacing="10" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td align="left">
                            <table cellspacing="0" cellpadding="5" width="100%">
                                <tr class="rheader">
                                    <td class="rheadercol" align="left" height="25">
                                        Daftar Aktiva Tetap
                                    </td>
                                    <td class="rheadercol" align="right" height="25" style="padding-right: 5px;">
                                        Ke halaman Detil Aktiva Tetap
                                        &nbsp;&nbsp;
                                        <a href="javascript:Next();">
                                            <img src="/qislib/images/next.png" border="0" align="absmiddle" alt="Ke halaman Detil Aktiva Tetap" /></a>
                                    </td>
                                </tr>
                                <tr class="rbody">
                                    <td class="rbodycol" align="middle" colspan="2">
                                        <table width="100%">
                                            <!-- PAGE CONTENT BEGIN HERE -->
                                            <tr>
                                                <td width="100%">
                                                    <table width="100%">
                                                        <tr style="display: none;">
                                                            <td width="50%" align="Left">
                                                                <asp:Button ID="btnNew" runat="server" Text="Buka Daftar Aktiva Tetap" CausesValidation="False"
                                                                    CssClass="sbttn" Width="200" />
                                                            </td>
                                                            <td width="50%">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="50%" align="Left">
                                                                Halaman ini akan
                                                                <asp:LinkButton ID="lbtnRefresh" runat="server" witdh="20%" Text="[refresh]" CausesValidation="False" />
                                                                setiap 10 menit
                                                            </td>
                                                            <td width="50%" align="Right">
                                                                [Total Item :
                                                                <asp:Label ID="lblTotal" runat="server" witdh="20%" align="right" />]
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="100%" class="rheaderexpable" style="height: 25; padding-left: 5px;">
                                                    Daftar Barang Umum Non-Stock yang belum dikodekan sebagai Aktiva Tetap
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="100%">
                                                    <div style="overflow: auto; width: 100%; height: 480px">
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:DataGrid ID="gridInformasiItem" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                                                                        BorderColor="Gainsboro" BorderWidth="1" GridLines="Horizontal" Height="100%"
                                                                        Width="100%" AllowPaging="False" PageSize="20" DataKeyField="counter" ShowFooter="True"
                                                                        CellPadding="0">
                                                                        <HeaderStyle CssClass="gridHeaderStyle" />
                                                                        <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                        <EditItemStyle Font-Bold="false" />
                                                                        <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                        <Columns>
                                                                            <asp:TemplateColumn runat="server" HeaderText="Counter" HeaderStyle-HorizontalAlign="Left"
                                                                                ItemStyle-HorizontalAlign="Left" Visible="false">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" Style="margin-left: 5; margin-right: 5" Text='<%# DataBinder.Eval(Container.DataItem, "counter") %>'
                                                                                        ID="_lblCounter" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateColumn>
                                                                            <asp:TemplateColumn runat="server" HeaderText="Nama Item" HeaderStyle-HorizontalAlign="Left"
                                                                                ItemStyle-HorizontalAlign="Left">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" Style="margin-left: 5; margin-right: 5" Text='<%# DataBinder.Eval(Container.DataItem, "nmbarang") %>'
                                                                                        ID="_lblNmitem" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateColumn>
                                                                            <asp:TemplateColumn runat="server" HeaderText="Kode Item" HeaderStyle-HorizontalAlign="Center"
                                                                                ItemStyle-HorizontalAlign="Center">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" CssClass="likelink" Text='<%# DataBinder.Eval(Container.DataItem, "kdbarang") %>'
                                                                                        ID="_lblKdItem" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateColumn>
                                                                            <asp:TemplateColumn runat="server" HeaderText="Serial No" HeaderStyle-HorizontalAlign="Center"
                                                                                ItemStyle-HorizontalAlign="Center">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" Style="margin-left: 5; margin-right: 5" Text='<%# DataBinder.Eval(Container.DataItem, "serialnumber") %>'
                                                                                        ID="_lblSerialNumber" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateColumn>
                                                                            <asp:TemplateColumn runat="server" HeaderText="No Penerimaan" HeaderStyle-HorizontalAlign="Center"
                                                                                ItemStyle-HorizontalAlign="Center">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" Style="margin-left: 5; margin-right: 5" Text='<%# DataBinder.Eval(Container.DataItem, "noterima") %>'
                                                                                        ID="_lblNoBukti" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateColumn>
                                                                            <asp:TemplateColumn runat="server" HeaderText="Tgl Terima" HeaderStyle-HorizontalAlign="Left"
                                                                                ItemStyle-HorizontalAlign="Left">
                                                                                <ItemTemplate>
                                                                                    <asp:Label runat="server" Style="margin-left: 5; margin-right: 5" Text='<%# Format(DataBinder.Eval(Container.DataItem, "Tglterima"),"dd-MM-yyyy") %>'
                                                                                        ID="_lblTglTerima" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateColumn>
                                                                            <asp:TemplateColumn>
                                                                                <ItemTemplate>
                                                                                    <asp:ImageButton runat="server" ID="__ibtnDelete" CausesValidation="False" ImageUrl="/qislib/images/delete.png"
                                                                                        Style="margin-left: 0; margin-right: 5" alt="Non-Asset-kan Item ini" CommandName="__delete" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateColumn>
                                                                        </Columns>
                                                                    </asp:DataGrid>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                            <!-- PAGE CONTENT END HERE -->
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <!-- VALIDATION SUMMARY BEGIN HERE -->
                            <table cellspacing="0" cellpadding="5" width="100%">
                                <tr>
                                    <td align="left">
                                        <p>
                                            <asp:ValidationSummary ID="ValidationSummary" runat="server" HeaderText="Field(s) berikut harus diisi atau perlu diperbaiki." />
                                        </p>
                                    </td>
                                </tr>
                            </table>
                            <!-- VALIDATION SUMMARY END HERE -->
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>

    <script src='/qislib/scripts/common/common.js' language="javascript"></script>

    <script src='/qislib/scripts/common/common.vbs' language="vbscript"></script>

    </form>
</body>
</html>
