<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../../incl/calendar.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PatchGroup.aspx.vb" Inherits="QIS.Web.Secure.PatchGroup" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Patch Group</title>
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
                                            Patch Group
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
                                                    <td style="width: 150px;" class="right">
                                                        Patch Group Name
                                                    </td>
                                                    <td style="width: 500px;">
                                                        <asp:TextBox ID="txtPatchGroupID" Width="300" runat="server" AutoPostBack="True" Visible="false" />
                                                        <asp:TextBox ID="txtPatchGroupName" Width="300" MaxLength="15" runat="server" AutoPostBack="True" />
                                                        <asp:RequiredFieldValidator ID="rfvPatchGroupName" runat="server" ControlToValidate="txtPatchGroupName"
                                                            ErrorMessage="Patch Group Name" Display="dynamic" Text="*">
                                                        </asp:RequiredFieldValidator>
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Display Sequence
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDisplaySequence" Width="300" MaxLength="500" runat="server" />
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
                                            <asp:DataGrid ID="grdPatchGroup" runat="server" BorderWidth="0" GridLines="None" Width="100%"
                                                CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false" AutoGenerateColumns="false">
                                                <headerstyle horizontalalign="Left" cssclass="gridHeaderStyle" />
                                                <itemstyle cssclass="gridItemStyle" />
                                                <alternatingitemstyle cssclass="gridAlternatingItemStyle" />
                                                <pagerstyle mode="NumericPages" horizontalalign="right" />
                                                <columns>
                                                    <asp:TemplateColumn runat="server" ItemStyle-Width="50">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="_ibtnEdit" runat="server" ImageUrl="/qistoollib/images/edit.png"
                                                                ImageAlign="AbsMiddle" CommandName="Edit" CausesValidation="false" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Patch Group Name">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PatchGroupID") %>'
                                                                ID="_lblPatchGroupID" Visible="false" />
                                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PatchGroupName") %>'
                                                                ID="_lblPatchGroupName" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Sequence">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "sequence")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                </columns>
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
