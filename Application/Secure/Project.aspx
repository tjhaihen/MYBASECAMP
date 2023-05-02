<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../incl/calendar.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Project.aspx.vb" Inherits="QIS.Web.Secure.Project" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Project</title>
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
                                            Project
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
                                                        Project Alias
                                                    </td>
                                                    <td style="width: 500px;">
                                                        <asp:TextBox ID="txtProjectID" Width="300" runat="server" AutoPostBack="True" Visible="false" />
                                                        <asp:TextBox ID="txtProjectAliasName" Width="300" MaxLength="15" runat="server" AutoPostBack="True" />
                                                        <asp:RequiredFieldValidator ID="rfvProjectAliasName" runat="server" ControlToValidate="txtProjectAliasName"
                                                            ErrorMessage="Project Alias" Display="dynamic" Text="*">
                                                        </asp:RequiredFieldValidator>
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Project Name
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtProjectName" Width="300" MaxLength="500" runat="server" />
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Description
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtProjectDescription" Width="300" MaxLength="500" runat="server" />
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Project Status
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlProjectStatus" Width="300" AutoPostBack="false" runat="server" />
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Project Group
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlProjectGroup" Width="300" AutoPostBack="false" runat="server" />
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        HEX Color
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtHEXColorID" Width="300" MaxLength="7" runat="server" />
                                                    </td>
                                                    <td style="width: 150px;" class="right">
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chkIsOpenForClient" runat="server" Text="Is Open for Customer?"
                                                            Checked="False" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" style="width: 100%;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Heading1">
                                            Profile Project: Assign this Project to which Profile?
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" style="width: 100%;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%;">
                                            <table width="100%" cellspacing="1">
                                                <tr>
                                                    <td valign="top" style="width: 40%;">
                                                        <asp:DataGrid ID="grdProfile" runat="server" BorderWidth="0" GridLines="None" Width="100%"
                                                            CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false" AutoGenerateColumns="false">
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                            <ItemStyle CssClass="gridItemStyle" />
                                                            <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                            <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                            <Columns>
                                                                <asp:TemplateColumn runat="server" ItemStyle-Width="50">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:TemplateColumn runat="server" HeaderText="Profile Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProfileID") %>'
                                                                            ID="_lblProfileID" Visible="false" />
                                                                        <%# DataBinder.Eval(Container.DataItem, "ProfileName")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                            </Columns>
                                                        </asp:DataGrid>
                                                    </td>
                                                    <td valign="top" class="center">
                                                        <asp:Button ID="btnProfileProjectAdd" runat="server" Text="Add >" CssClass="sbttn" Width="100px" /><br />
                                                        <asp:Button ID="btnProfileProjectAddAll" runat="server" Text="Add All >>" CssClass="sbttn"
                                                            Width="100px" /><br />
                                                        <br />
                                                        <asp:Button ID="btnProfileProjectRemoveAll" runat="server" Text="<< Remove All" CssClass="sbttn"
                                                            Width="100px" /><br />
                                                        <asp:Button ID="btnProfileProjectRemove" runat="server" Text="< Remove" CssClass="sbttn"
                                                            Width="100px" />
                                                    </td>
                                                    <td valign="top" style="width: 40%;">
                                                        <asp:DataGrid ID="grdProjectProfile" runat="server" BorderWidth="0" GridLines="None"
                                                            Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                            AutoGenerateColumns="false">
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                            <ItemStyle CssClass="gridItemStyle" />
                                                            <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                            <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                            <Columns>
                                                                <asp:TemplateColumn runat="server" ItemStyle-Width="50">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:TemplateColumn runat="server" HeaderText="Profile Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "projectProfileID") %>'
                                                                            ID="_lblProjectProfileID" Visible="false" />
                                                                        <%# DataBinder.Eval(Container.DataItem, "ProfileName")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                            </Columns>
                                                        </asp:DataGrid>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr class="rbody">
                                        <td valign="top">
                                            <asp:DataGrid ID="grdProject" runat="server" BorderWidth="0" GridLines="None" Width="100%"
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
                                                    <asp:TemplateColumn runat="server" HeaderText="Alias">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProjectAliasName") %>'
                                                                ID="_lblProjectAliasName" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Name">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "ProjectName")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Description">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "ProjectDescription")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Status">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "ProjectStatusName")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Is Shared to Client?">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="_chkIsOpenForClient" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "IsOpenForClient") %>'
                                                                Enabled="false" />
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
