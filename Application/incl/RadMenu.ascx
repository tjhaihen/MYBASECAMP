<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="RadMenu.ascx.vb" Inherits="QIS.RadMenu" %>
<%@ Register Src="~/Libs/Controls/Menu.ascx" TagName="Menu" TagPrefix="ucMenu" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Import Namespace="QIS.Web" %>
<telerik:RadScriptManager ID="ScriptManager" runat="server" />
<link href="/qistoollib/css/styles_blue.css" type="text/css" rel="Stylesheet" />
<link rel="shortcut icon" type="image/x-icon" href="/qistoollib/images/QISicon.ico" />
<table width="100%" cellpadding="1" cellspacing="0">
    <tr>
        <td class="Menu" align="left" valign="middle" style="width: 95%; padding-left: 5px">
            <table width="100%" cellspacing="0" cellpadding="2">
                <tr>
                    <td class="Menu" style="width: auto;">
                        <a href='<%=PageBase.UrlBase & "/secure/main.aspx"%>' title="Basecamp">
                            <img src="/qistoollib/images/Basecamp_logo_small.png" align="absmiddle" width="100" />
                        </a>
                    </td>
                    <td class="Menu Separator">
                        <img src="/qistoollib/images/separator.png" border="0" alt="" align="absmiddle" />
                    </td>
                    <td class="Menu center" style="width: auto; font-weight: bold;">
                        <asp:Label ID="lblUserFullName" runat="server"></asp:Label>
                    </td>
                    <td class="Menu Separator">
                        <img src="/qistoollib/images/separator.png" border="0" alt="" align="absmiddle" />
                    </td>
                    <td class="Menu center" style="width: auto;">
                        <asp:Label ID="lblProfileName" runat="server"></asp:Label>
                    </td>
                    <td class="Menu" style="width: 50%; padding-right: 5px" align="right">
                        <table cellspacing="0" cellpadding="2">
                            <tr>
                                <td>
                                    <asp:Panel ID="pnlHomeBAS" runat="server">
                                        <a href='<%=PageBase.UrlBase & "/secure/main.aspx"%>'>
                                            <img src="/qistoollib/images/home.png" border="0" alt="" title="Home" align="absmiddle" /></a>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlHomeEMR" runat="server">
                                        <a href='<%=PageBase.UrlBase & "/secure/EMR/main.aspx"%>'>
                                            <img src="/qistoollib/images/home.png" border="0" alt="" title="EMR Home" align="absmiddle" /></a>
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:ImageButton runat="server" ID="btnLogout" ImageUrl="/qistoollib/images/close.png"
                                        ToolTip="Log Out" ImageAlign="AbsMiddle" CausesValidation="false" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="Menu Separator">
                        <img src="/qistoollib/images/separator.png" border="0" alt="" align="absmiddle" />
                    </td>
                    <td class="Menu center" style="width: auto;">
                        <asp:Label ID="lblCompanyName" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td valign="top" colspan="2" class="Menubg">
            <ucMenu:Menu ID="Menu" runat="server" />
        </td>
    </tr>
</table>
