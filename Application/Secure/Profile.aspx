﻿<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../incl/copyright.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Profile.aspx.vb" Inherits="QIS.Web.Secure.Profile" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Profile</title>
    <link rel="title icon" href="/qistoollib/images/favicon.png" />
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href='/qistoollib/css/styles_blue.css' type="text/css" rel="Stylesheet" />
    <script type="text/javascript" language="javascript" src='/qistoollib/scripts/common/common.js'></script>
</head>
<body>
    <form id="frm" runat="server">
    <table border="0" width="100%" height="100%" cellspacing="2" cellpadding="1">
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
                                            Profile
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
                                                <!-- PAGE CONTENT BEGIN HERE -->
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:ValidationSummary ID="ValidationSummary" runat="server" HeaderText="Please fill the following Field(s)." />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 150px;" class="right">
                                                        Profile Code
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtProfileID" Width="300" runat="server" AutoPostBack="True" Visible="false" />
                                                        <asp:TextBox ID="txtProfileCode" Width="300" MaxLength="15" runat="server" AutoPostBack="True" />
                                                        <asp:RequiredFieldValidator ID="rfvProfileCode" runat="server" ControlToValidate="txtProfileCode"
                                                            ErrorMessage="Profile Code" Display="dynamic" Text="*">																
                                                        </asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="right">
                                                        Profile Name
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtProfileName" Width="300" MaxLength="50" runat="server" />
                                                        <asp:RequiredFieldValidator ID="rfvProfileName" runat="server" ControlToValidate="txtProfileName"
                                                            ErrorMessage="Profile Name" Display="dynamic" Text="*">																
                                                        </asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chkIsActive" runat="server" Text="Is Active?" Checked="False" />
                                                        <asp:CheckBox ID="chkIsSystem" runat="server" Text="Is System?" Checked="False" Visible="false" />
                                                        <asp:CheckBox ID="chkIsCustomerProfile" runat="server" Text="Is Customer Profile?" Checked="False" />
                                                    </td>
                                                </tr>
                                                <!-- PAGE CONTENT END HERE -->
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Heading1">
                                            Profile Menu
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" style="width: 100%;">
                                        </td>
                                    </tr>
                                    <div id="ProfileMenu">
                                    <tr>
                                        <td style="width: 100%;">
                                            <table width="100%" cellspacing="1">
                                                <tr>
                                                    <td valign="top" style="width: 40%;">
                                                        <asp:DataGrid ID="grdMenu" runat="server" BorderWidth="0" GridLines="None" Width="100%"
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
                                                                <asp:TemplateColumn runat="server" HeaderText="Menu Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MenuID") %>'
                                                                            ID="_lblMenuID" Visible="false" />
                                                                        <%# DataBinder.Eval(Container.DataItem, "Description") %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                            </Columns>
                                                        </asp:DataGrid>
                                                    </td>
                                                    <td valign="top" class="center">
                                                        <asp:Button ID="btnProfileMenuAdd" runat="server" Text="Add >" CssClass="sbttn" Width="100px" /><br />
                                                        <asp:Button ID="btnProfileMenuAddAll" runat="server" Text="Add All >>" CssClass="sbttn"
                                                            Width="100px" /><br />
                                                        <br />
                                                        <asp:Button ID="btnProfileMenuRemoveAll" runat="server" Text="<< Remove All" CssClass="sbttn"
                                                            Width="100px" /><br />
                                                        <asp:Button ID="btnProfileMenuRemove" runat="server" Text="< Remove" CssClass="sbttn"
                                                            Width="100px" />
                                                    </td>
                                                    <td valign="top" style="width: 40%;">
                                                        <asp:DataGrid ID="grdProfileMenu" runat="server" BorderWidth="0" GridLines="None"
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
                                                                <asp:TemplateColumn runat="server" HeaderText="Menu Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProfileMenuID") %>'
                                                                            ID="_lblProfileMenuID" Visible="false" />
                                                                        <%# DataBinder.Eval(Container.DataItem, "Description") %>
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
                                        <td class="hseparator" style="width: 100%;">
                                        </td>
                                    </tr>
                                    </div>
                                    <tr>
                                        <td class="Heading1">
                                            Profile Project
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
                                                        <asp:DataGrid ID="grdProject" runat="server" BorderWidth="0" GridLines="None" Width="100%"
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
                                                                <asp:TemplateColumn runat="server" HeaderText="Project Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProjectID") %>'
                                                                            ID="_lblProjectID" Visible="false" />
                                                                        <%# DataBinder.Eval(Container.DataItem, "ProjectName")%>
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
                                                                <asp:TemplateColumn runat="server" HeaderText="Project Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "projectProfileID") %>'
                                                                            ID="_lblProjectProfileID" Visible="false" />
                                                                        <%# DataBinder.Eval(Container.DataItem, "ProjectName") %>
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
                                        <td class="hseparator" style="width: 100%;">
                                        </td>
                                    </tr>
                                    <tr class="rbody">
                                        <td valign="top">
                                            <asp:DataGrid ID="grdUser" runat="server" BorderWidth="0" GridLines="None" Width="100%"
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
                                                    <asp:TemplateColumn runat="server" HeaderText="Username">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Username") %>'
                                                                ID="_lblUsername" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Fisrt Name">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "FirstName") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Middle Name">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "MiddleName") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Last Name">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "LastName") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Gender">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "GenderName") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Phone">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "Phone")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Mobile">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "Mobile") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Is Active?">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="_chkIsActive" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "IsActive") %>'
                                                                Enabled="false" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>                                                    
                                                </Columns>
                                            </asp:DataGrid>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" style="width: 100%;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Heading1">
                                            Profile Unit
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" style="width: 100%;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%;">
                                            <table>
                                                <tr>
                                                    <td class="right">
                                                    Departemen
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlDepartmentFilter" runat="server" Width="200" AutoPostBack="true">
                                                        <asp:ListItem Value="OUTPATIENT" Text="RAWAT JALAN"></asp:ListItem>
                                                        <asp:ListItem Value="EMERGENCY" Text="RAWAT DARURAT"></asp:ListItem>
                                                        <asp:ListItem Value="INPATIENT" Text="RAWAT INAP"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%;">
                                            <table width="100%" cellspacing="1">
                                                <tr>
                                                    <td valign="top" style="width: 40%;">
                                                        <asp:DataGrid ID="grdUnit" runat="server" BorderWidth="0" GridLines="None" Width="100%"
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
                                                                <asp:TemplateColumn runat="server" HeaderText="Unit Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UnitID") %>'
                                                                            ID="_lblUnitID" Visible="false" />
                                                                        <%# DataBinder.Eval(Container.DataItem, "UnitName")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                            </Columns>
                                                        </asp:DataGrid>
                                                    </td>
                                                    <td valign="top" class="center">
                                                        <asp:Button ID="btnProfileUnitAdd" runat="server" Text="Add >" CssClass="sbttn" Width="100px" /><br />
                                                        <asp:Button ID="btnProfileUnitAddAll" runat="server" Text="Add All >>" CssClass="sbttn"
                                                            Width="100px" /><br />
                                                        <br />
                                                        <asp:Button ID="btnProfileUnitRemoveAll" runat="server" Text="<< Remove All" CssClass="sbttn"
                                                            Width="100px" /><br />
                                                        <asp:Button ID="btnProfileUnitRemove" runat="server" Text="< Remove" CssClass="sbttn"
                                                            Width="100px" />
                                                    </td>
                                                    <td valign="top" style="width: 40%;">
                                                        <asp:DataGrid ID="grdProfileUnit" runat="server" BorderWidth="0" GridLines="None"
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
                                                                <asp:TemplateColumn runat="server" HeaderText="Unit Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProfileUnitID") %>'
                                                                            ID="_lblProfileUnitID" Visible="false" />
                                                                        <%# DataBinder.Eval(Container.DataItem, "UnitName") %>
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
                                        <td class="hseparator" style="width: 100%;">
                                        </td>
                                    </tr>
                                    <tr class="rbody">
                                        <td valign="top">
                                            <asp:DataGrid ID="grdProfile" runat="server" BorderWidth="0" GridLines="None" Width="100%"
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
                                                    <asp:TemplateColumn runat="server" HeaderText="Code">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ProfileCode") %>'
                                                                ID="_lblProfileCode" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Name">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "ProfileName")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Is Active?">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="_chkIsActive" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "IsActive") %>'
                                                                Enabled="false" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Is System?">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="_chkIsSystem" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "IsSystem") %>'
                                                                Enabled="false" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Is Customer?">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="_chkIsCustomerProfile" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "IsCustomerProfile") %>'
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
