<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../../incl/calendar.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DrugInteractionInfo.aspx.vb"
    Inherits="QIS.Web.Secure.DrugInteractionInfo" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Informasi Interaksi Obat</title>
    <link rel="title icon" href="/qistoollib/images/favicon.png" />
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href='/qistoollib/css/styles_blue.css' type="text/css" rel="Stylesheet" />
    <script language="javascript" type="text/javascript" src="/qistoollib/scripts/JScript.js"></script>
    <script type="text/javascript" language="javascript" src='/qistoollib/scripts/common/common.js'></script>
    <style>
        pre
        {
            font-family: Segoe UI;
            white-space: pre-wrap; /* Since CSS 2.1 */
            white-space: -moz-pre-wrap; /* Mozilla, since 1999 */
            white-space: -pre-wrap; /* Opera 4-6 */
            white-space: -o-pre-wrap; /* Opera 7 */
            word-wrap: break-word; /* Internet Explorer 5.5+ *
        }
</style>
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
                <table cellspacing="10" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td align="left">
                            <table cellspacing="0" cellpadding="5" width="100%">
                                <tr>
                                    <td class="rheader">
                                        Informasi Interaksi Obat
                                    </td>
                                </tr>
                                <tr>
                                    <td class="hseparator" style="width: 100%;">
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle">
                                        <asp:ImageButton ID="ibtnDetail" runat="server" ImageUrl="/qistoollib/images/ico-detail.png"
                                            ToolTip="Informasi Interaksi Obat" Width="32" ImageAlign="AbsMiddle" CausesValidation="false" />
                                        <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="/qistoollib/images/ico-edit.png"
                                            ToolTip="Tambah/Edit Interaksi Obat" Width="32" ImageAlign="AbsMiddle" CausesValidation="false" />
                                    </td>
                                </tr>
                                <asp:Panel ID="pnlInteraksiObat" runat="server">
                                    <tr>
                                        <td>
                                            <Module:CSSToolbar ID="CSSToolbar" runat="server"></Module:CSSToolbar>
                                        </td>
                                    </tr>
                                    <tr class="rbody">
                                        <td valign="top">
                                            <table width="100%">
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:ValidationSummary ID="ValidationSummary" runat="server" HeaderText="Please fill the following Field(s)." />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background-color: #30CD08; color: #ffffff; width: 200;">
                                                        Nama Generik
                                                    </td>
                                                    <td style="width: 500px;">
                                                        <asp:TextBox ID="txtGenericName" Width="300" MaxLength="15" runat="server" />
                                                        <asp:RequiredFieldValidator ID="rfvGenericName" runat="server" ControlToValidate="txtGenericName"
                                                            ErrorMessage="Nama Generik" Display="dynamic" Text="*">
                                                        </asp:RequiredFieldValidator>
                                                    </td>
                                                    <td style="width: 200;" class="right">
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
                                            <table width="100%" border="0" cellspacing="1" cellpadding="2">
                                                <tr>
                                                    <td style="background-color: #cccccc; width: 200; text-align: center;">
                                                        Nama Generik
                                                    </td>
                                                    <td style="background-color: #cccccc; width: 200; text-align: center;">
                                                        Golongan
                                                    </td>
                                                    <td style="background-color: #cccccc; text-align: center;">
                                                        Nama Dagang
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <asp:Label ID="lblGenericName" runat="server"></asp:Label>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:Label ID="lblGenericGroupName" runat="server"></asp:Label>
                                                    </td>
                                                    <td valign="top">
                                                        <asp:Label ID="lblBrandName" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3" style="background-color: #cccccc; text-align: center;">
                                                        Interaksi
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <pre>
                                                        <asp:Label ID="lblInteractionDescription" runat="server"></asp:Label></pre>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="rheader">
                                            Simulasi Interaksi Obat
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" style="width: 100%;">
                                        </td>
                                    </tr>
                                    <tr class="rbody">
                                        <td valign="top">
                                            <table width="100%" border="0" cellspacing="1" cellpadding="2">
                                                <tr>
                                                    <td style="background-color: #cccccc; width: 300;">
                                                        Pilih Obat-1
                                                        <asp:Button ID="btnSearchObat1" runat="server" Text="..." Width="30" CausesValidation="false" />
                                                    </td>
                                                    <td style="background-color: #cccccc; width: 300;">
                                                        Pilih Obat-2
                                                        <asp:Button ID="btnSearchObat2" runat="server" Text="..." Width="30" CausesValidation="false" />
                                                    </td>
                                                    <td style="background-color: #cccccc;">
                                                        <asp:Button ID="btnCheckInteraction" runat="server" Text="Cek Interaksi" CausesValidation="false" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtItemCode1" runat="server" Width="100" AutoPostBack="true"></asp:TextBox>
                                                        <asp:TextBox ID="txtItemName1" runat="server" Width="196" ReadOnly="true" CssClass="txtReadOnly"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtItemCode2" runat="server" Width="100" AutoPostBack="true"></asp:TextBox>
                                                        <asp:TextBox ID="txtItemName2" runat="server" Width="196" ReadOnly="true" CssClass="txtReadOnly"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblCheckInteractionResult" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </asp:Panel>
                                <asp:Panel ID="pnlEditInteraksiObat" runat="server">
                                    <tr class="rbody">
                                        <td>
                                            <asp:ValidationSummary ID="ValidationSummaryEdit" runat="server" HeaderText="Please fill the following Field(s)." />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="rheader">
                                            Tambah/Edit Interaksi Obat
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" style="width: 100%;">
                                        </td>
                                    </tr>
                                    <tr class="rbody">
                                        <td valign="top">
                                            <table width="100%" border="0" cellspacing="1" cellpadding="2">
                                                <tr>
                                                    <td class="right" style="background-color: #30CD08; color: #ffffff; width: 200;">
                                                        Nama Generik
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDrugInteractionHdID" runat="server" Width="300" Visible="false"></asp:TextBox>
                                                        <asp:TextBox ID="txtGenericNameEdit" runat="server" Width="300"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background-color: #30CD08; color: #ffffff; width: 200;">
                                                        Golongan
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtGenericGroupName" runat="server" Width="600"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background-color: #30CD08; color: #ffffff; width: 200;">
                                                        Nama Dagang
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtBrandNames" runat="server" Width="600"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background-color: #30CD08; color: #ffffff; width: 200;">
                                                        Interaksi
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtInteractionDescription" runat="server" TextMode="MultiLine" Height="200"
                                                            Width="600"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background-color: #30CD08; color: #ffffff;">
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnSaveInteraksi" runat="server" Text="Simpan" Width="100" />
                                                        <asp:Button ID="btnNewInteraksi" runat="server" Text="Baru" Width="100" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="hseparator" style="width: 100%;" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="rfieldgroup" colspan="2">
                                                        Interaksi dengan Obat
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background-color: #30CD08; color: #ffffff; width: 200;">
                                                        Nama Generik
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlGenericNameList" runat="server" Width="300">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background-color: #30CD08; color: #ffffff; width: 200;">
                                                        Keterangan Interaksi
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtInteractionDescriptionDt" runat="server" Width="300"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background-color: #30CD08; color: #ffffff;">
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnSaveDt" runat="server" Text="Tambah" Width="100" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background-color: #30CD08; color: #ffffff;">
                                                    </td>
                                                    <td>
                                                        <asp:DataGrid ID="grdDrugInteractionDt" runat="server" BorderWidth="0" GridLines="None"
                                                            Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                            AutoGenerateColumns="false">
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                            <ItemStyle CssClass="gridItemStyle" />
                                                            <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                            <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                            <Columns>
                                                                <asp:TemplateColumn runat="server" ItemStyle-Width="50">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="_ibtnDelete" runat="server" ImageUrl="/qistoollib/images/delete.png"
                                                                            ImageAlign="AbsMiddle" CommandName="Delete" CausesValidation="false" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:TemplateColumn runat="server" HeaderText="Nama Generik">
                                                                    <ItemTemplate>
                                                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DrugInteractionDtID") %>'
                                                                            ID="_lblDrugInteractionDtID" Visible="false" />
                                                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "InteractionGenericName") %>'
                                                                            ID="_lblGenericName" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:TemplateColumn runat="server" HeaderText="Keterangan Interaksi">
                                                                    <ItemTemplate>
                                                                        <%# DataBinder.Eval(Container.DataItem, "InteractionDescriptionDt")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                            </Columns>
                                                        </asp:DataGrid>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="rfieldgroup" colspan="2">
                                                        Daftar Item Obat
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background-color: #30CD08; color: #ffffff; width: 200;">
                                                        Pilih Item Obat
                                                        <asp:Button ID="btnSearchObat" runat="server" Text="..." Width="30" CausesValidation="false" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtItemCode" runat="server" Width="100" AutoPostBack="true"></asp:TextBox>
                                                        <asp:TextBox ID="txtItemName" runat="server" Width="196" ReadOnly="true" CssClass="txtReadOnly"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background-color: #30CD08; color: #ffffff;">
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnAddDrugGenericMtx" runat="server" Text="Tambah" Width="100" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right" style="background-color: #30CD08; color: #ffffff;">
                                                    </td>
                                                    <td>
                                                        <asp:DataGrid ID="grdDrugGenericMtx" runat="server" BorderWidth="0" GridLines="None"
                                                            Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                            AutoGenerateColumns="false">
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                            <ItemStyle CssClass="gridItemStyle" />
                                                            <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                            <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                            <Columns>
                                                                <asp:TemplateColumn runat="server" ItemStyle-Width="50">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="_ibtnDelete" runat="server" ImageUrl="/qistoollib/images/delete.png"
                                                                            ImageAlign="AbsMiddle" CommandName="Delete" CausesValidation="false" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:TemplateColumn runat="server" HeaderText="Kode Item" ItemStyle-Width="120">
                                                                    <ItemTemplate>
                                                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ItemCode") %>'
                                                                            ID="_lblItemCode" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:TemplateColumn runat="server" HeaderText="Nama Item">
                                                                    <ItemTemplate>
                                                                        <%# DataBinder.Eval(Container.DataItem, "ItemName")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                            </Columns>
                                                        </asp:DataGrid>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:DataGrid ID="grdDrugInteractionHd" runat="server" BorderWidth="0" GridLines="None"
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
                                                                <asp:TemplateColumn runat="server" HeaderText="Nama Generik">
                                                                    <ItemTemplate>
                                                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DrugInteractionHdID") %>'
                                                                            ID="_lblDrugInteractionHdID" Visible="false" />
                                                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GenericName") %>'
                                                                            ID="_lblGenericName" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:TemplateColumn runat="server" HeaderText="Golongan">
                                                                    <ItemTemplate>
                                                                        <%# DataBinder.Eval(Container.DataItem, "GenericGroupName")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:TemplateColumn runat="server" HeaderText="Merk Dagang">
                                                                    <ItemTemplate>
                                                                        <%# DataBinder.Eval(Container.DataItem, "brandNames")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                            </Columns>
                                                        </asp:DataGrid>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </asp:Panel>
                            </table>
                        </td>
                    </tr>
                </table>
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
