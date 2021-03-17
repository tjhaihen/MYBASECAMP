<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../../incl/calendar.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../../incl/CSSToolbar.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PatchList.aspx.vb" Inherits="QIS.Web.PatchManagement.PatchList" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Medinfras Patch List</title>
    <link rel="title icon" href="/qistoollib/images/favicon.png" />
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href="/qistoollib/css/styles_blue.css" type="text/css" rel="Stylesheet" />
    <script language="javascript" type="text/javascript" src="/qistoollib/scripts/JScript.js"></script>
    <style type="text/css">
        #ulRepDateInMonthDt
        {
            width: 100%;
            margin: 0;
            padding: 0;                     
        }
        #ulRepDateInMonthDt li
        {
            list-style-type: none;
            display: inline-block; /* FF3.6; Chrome10+ */                     
            *display: inline;
            background: #eeeeee;
            width: 280px;
            height: 150px;
            margin: 5px;
        }
        #ulRepDateInMonth
        {
            width: 100%;
            margin: 0;
            padding: 0;                     
        }
        #ulRepDateInMonth li
        {
            list-style-type: none;            
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server">
    <table width="100%" cellpadding="2" cellspacing="0" style="height: 100%;">
        <tr>
            <td width="100%" valign="top" colspan="3">
                <!-- BEGIN PAGE HEADER -->
                <Module:RadMenu ID="RadMenu" runat="server" />
                <!-- END PAGE HEADER -->
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 120px;">
                <table width="150" style="height: 60px;">
                    <tr>
                        <td class="Heading2">
                            Select Patch
                        </td>
                    </tr>
                    <tr>
                        <td class="hseparator">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtSelectPatchNo" runat="server" Width="150" AutoPostBack="true">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DataGrid ID="grdPatchList" runat="server" BorderWidth="0" GridLines="None" Width="100%"
                                CellPadding="2" CellSpacing="1" ShowHeader="false" ShowFooter="false" AutoGenerateColumns="false">
                                <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                <ItemStyle CssClass="gridItemStyle" />
                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                <Columns>
                                    <asp:TemplateColumn runat="server" HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PatchNo") %>'
                                                ID="_lbtnPatchNo" CommandName="SelectPatch" CausesValidation="false" />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn runat="server">
                                        <ItemTemplate>
                                            <asp:Image runat="server" ID="_imgIsClosed" ImageUrl="/qistoollib/images/patchclosed_small.png" Width="8"
                                                ImageAlign="AbsMiddle" Visible='<%# DataBinder.Eval(Container.DataItem, "IsClosed")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                            </asp:DataGrid>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%;" class="hseparator" colspan="2">
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" class="vseparator" style="height: 100%;">
            </td>
            <td valign="top" style="width: 100%;">
                <table width="100%">
                    <tr>
                        <td class="Heading2">
                            <asp:Label ID="lblPageTitle" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="hseparator">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <Module:CSSToolbar ID="CSSToolbar" runat="server"></Module:CSSToolbar>
                        </td>
                    </tr>
                    <tr>
                        <td class="hseparator">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td class="right" style="width: 100;">
                                        Patch No.
                                    </td>
                                    <td style="width: 50%;">
                                        <asp:TextBox ID="txtPatchNo" runat="server" Width="300"></asp:TextBox>
                                    </td>
                                    <td rowspan="3" align="right">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Image ID="imgIsClosed" runat="server" ImageUrl="/qistoollib/images/patchclosed.png"
                                                        ToolTip="Approved" />
                                                </td>
                                                <td valign="bottom">
                                                    <asp:Label ID="lblClosedBy" runat="server" Text="By: -"></asp:Label><br />
                                                    <asp:Label ID="lblClosedDate" runat="server" Text="On: -"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="right" style="width: 100;">
                                        Patch date
                                    </td>
                                    <td>
                                        <Module:Calendar ID="calPatchDate" runat="server" DontResetDate="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="right" style="width: 100;">
                                        Remarks
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRemarks" runat="server" Width="300"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="hseparator" colspan="3">
                                    </td>
                                </tr>
                                <asp:Panel ID="pnlAddNewPatchIssue" runat="server">
                                    <tr>
                                        <td colspan="3">
                                            <table width="100%" class="gridAlternatingItemStyle" cellspacing="1">
                                                <tr>
                                                    <td style="font-weight: bold;">
                                                        .:: Add or Edit Patch Issue (for Issue(s) that have Issue ID)
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100%;" valign="top">
                                                        <table width="100%" class="gridAlternatingItemStyle" cellspacing="1">
                                                            <tr>
                                                                <td class="right" style="width: 100px; background: #ffffff;">
                                                                    Issue ID
                                                                </td>
                                                                <td style="background: #ffffff;">
                                                                    <asp:TextBox ID="txtIssueID" runat="server" Width="300" AutoPostBack="true">
                                                                    </asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvIssueID" runat="server" Display="dynamic" ErrorMessage="Issue ID"
                                                                        ControlToValidate="txtIssueID" CssClass="txterrmsg" Text="required">
                                                                    </asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="right" style="width: 100px; background: #ffffff;">
                                                                </td>
                                                                <td style="background: #ffffff;">
                                                                    <asp:CheckBox ID="chkIsSpecific" runat="server" Text="Is Specific Project?" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="right" style="width: 100px; background: #ffffff;">
                                                                    Information
                                                                </td>
                                                                <td style="background: #ffffff;">
                                                                    <asp:Label ID="lblIssueInformation" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <asp:Panel ID="pnlIssuePatchWarning" runat="server">
                                                                <tr>
                                                                    <td class="right" style="width: 100px;">
                                                                        <img src="/qistoollib/images/warning.png" width="24" />
                                                                    </td>
                                                                    <td style="background: #f5b7b1; color: #000000;">
                                                                        <asp:Label ID="lblIssueAlreadyOnOtherPatch" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </asp:Panel>
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btnAddPatchIssue" runat="server" Text="Save" CssClass="sbttn" Width="100" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:DataGrid ID="grdPatchIssue" runat="server" BorderWidth="0" GridLines="None"
                                                Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                AutoGenerateColumns="false">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                <ItemStyle CssClass="gridItemStyle" />
                                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                <Columns>
                                                    <asp:TemplateColumn runat="server" ItemStyle-Width="30">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="_ibtnDelete" runat="server" ImageUrl="/qistoollib/images/delete.png"
                                                                ImageAlign="AbsMiddle" CommandName="Delete" CausesValidation="false" Visible='<%# NOT(DataBinder.Eval(Container.DataItem, "IsClosed"))%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Department">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "IssueDepartment")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Issue Description">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "IssueDescription")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Issue ID" ItemStyle-Width="120">
                                                        <ItemTemplate>
                                                            <asp:Label ID="_lblIssueID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IssueID")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Project" ItemStyle-Width="80">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "ProjectAliasName")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Is Specific?" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="_chkIsSpecific" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "isSpecific")%>'
                                                                Enabled="false" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Last Update" ItemStyle-Width="120">
                                                        <ItemTemplate>
                                                            <div class="txtweak">
                                                                <%# DataBinder.Eval(Container.DataItem, "UserNameUpdate")%><br />
                                                                <%# Format((DataBinder.Eval(Container.DataItem, "UpdateDate")),"dd-MMM-yyyy hh:mm")%>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                </Columns>
                                            </asp:DataGrid>
                                        </td>
                                    </tr>
                                </asp:Panel>
                                <tr>
                                    <td class="hseparator" colspan="3">
                                    </td>
                                </tr>
                                <asp:Panel ID="pnlAddNewPatchDt" runat="server">
                                    <tr>
                                        <td colspan="3">
                                            <table width="100%" class="gridAlternatingItemStyle" cellspacing="1">
                                                <tr>
                                                    <td style="font-weight: bold;">
                                                        .:: Add or Edit Patch Detail (for Issue(s) that doesn't have Issue ID)
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100%;" valign="top">
                                                        <table width="100%" class="gridAlternatingItemStyle" cellspacing="1">
                                                            <tr>
                                                                <td class="right" style="width: 100px; background: #ffffff;">
                                                                    Remarks
                                                                </td>
                                                                <td style="background: #ffffff;">
                                                                    <asp:TextBox ID="PatchDt_txtPatchDtID" runat="server" Width="300" Visible="false">
                                                                    </asp:TextBox>
                                                                    <asp:TextBox ID="PatchDt_txtRemarks" runat="server" Width="300" TextMode="Multiline"
                                                                        Height="50">
                                                                    </asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="PatchDt_rfvtxtRemarks" runat="server" Display="dynamic"
                                                                        ErrorMessage="Remarks" ControlToValidate="PatchDt_txtRemarks" CssClass="txterrmsg"
                                                                        Text="required">
                                                                    </asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="right" style="width: 100px; background: #ffffff;">
                                                                    Project
                                                                </td>
                                                                <td style="background: #ffffff;">
                                                                    <asp:DropDownList ID="PatchDt_ddlProject" runat="server" Width="300">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="right" style="width: 100px; background: #ffffff;">
                                                                </td>
                                                                <td style="background: #ffffff;">
                                                                    <asp:CheckBox ID="PatchDt_chkIsSpecific" runat="server" Text="Is Specific Project?" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="PatchDt_btnAddPatchDt" runat="server" Text="Save" CssClass="sbttn"
                                                                        Width="100" CausesValidation="false" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:DataGrid ID="grdPatchDt" runat="server" BorderWidth="0" GridLines="None" Width="100%"
                                                CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false" AutoGenerateColumns="false">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                <ItemStyle CssClass="gridItemStyle" />
                                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                <Columns>
                                                    <asp:TemplateColumn runat="server" ItemStyle-Width="30">
                                                        <ItemTemplate>
                                                            <asp:Label ID="grdPatchDt_lblPatchDtID" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "patchDtID")%>' />
                                                            <asp:ImageButton ID="_ibtnEdit" runat="server" ImageUrl="/qistoollib/images/edit.png"
                                                                ImageAlign="AbsMiddle" CommandName="Edit" CausesValidation="false" Visible='<%# NOT(DataBinder.Eval(Container.DataItem, "IsClosed"))%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" ItemStyle-Width="30">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="_ibtnDelete" runat="server" ImageUrl="/qistoollib/images/delete.png"
                                                                ImageAlign="AbsMiddle" CommandName="Delete" CausesValidation="false" Visible='<%# NOT(DataBinder.Eval(Container.DataItem, "IsClosed"))%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Issue Description">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "Remarks")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Project" ItemStyle-Width="80">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "ProjectAliasName")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Is Specific?" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="grdPatchDt_chkIsSpecific" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "isSpecific")%>'
                                                                Enabled="false" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Last Update" ItemStyle-Width="120">
                                                        <ItemTemplate>
                                                            <div class="txtweak">
                                                                <%# DataBinder.Eval(Container.DataItem, "UserNameUpdate")%><br />
                                                                <%# Format((DataBinder.Eval(Container.DataItem, "UpdateDate")),"dd-MMM-yyyy hh:mm")%>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                </Columns>
                                            </asp:DataGrid>
                                        </td>
                                    </tr>
                                </asp:Panel>
                                <tr>
                                    <td class="hseparator" colspan="3">
                                    </td>
                                </tr>
                                <asp:Panel ID="pnlAddNewRowPatchProject" runat="server">
                                    <tr>
                                        <td colspan="3">
                                            <table width="100%" class="gridAlternatingItemStyle" cellspacing="1">
                                                <tr>
                                                    <td style="font-weight: bold;">
                                                        .:: Add or Edit Patch Project (for Project(s) Updated with this Patch No.)
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100%;" valign="top">
                                                        <table width="100%" class="gridAlternatingItemStyle" cellspacing="1">
                                                            <tr>
                                                                <td class="right" style="width: 100px; background: #ffffff;">
                                                                    Project
                                                                </td>
                                                                <td style="background: #ffffff;">
                                                                    <asp:TextBox ID="PatchProject_txtPatchProjectID" runat="server" Visible="false">
                                                                    </asp:TextBox>
                                                                    <asp:DropDownList ID="PatchProject_ddlProject" runat="server" Width="300">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="right" style="width: 100px; background: #ffffff;">
                                                                    Update Date
                                                                </td>
                                                                <td style="background: #ffffff;">
                                                                    <Module:Calendar ID="PatchProject_calUpdateDate" runat="server" DontResetDate="true" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="right" style="width: 100px; background: #ffffff;">
                                                                    Remarks
                                                                </td>
                                                                <td style="background: #ffffff;">
                                                                    <asp:TextBox ID="PatchProject_txtRemarks" runat="server" Width="300" TextMode="Multiline"
                                                                        Height="50">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="PatchProject_btnAddPatchProject" runat="server" Text="Save" CssClass="sbttn"
                                                                        Width="100" CausesValidation="false" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:DataGrid ID="grdPatchProject" runat="server" BorderWidth="0" GridLines="None"
                                                Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                AutoGenerateColumns="false">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                <ItemStyle CssClass="gridItemStyle" />
                                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                <Columns>
                                                    <asp:TemplateColumn runat="server" ItemStyle-Width="30">
                                                        <ItemTemplate>
                                                            <asp:Label ID="grdPatchProject_lblPatchProjectID" runat="server" Visible="false"
                                                                Text='<%# DataBinder.Eval(Container.DataItem, "patchProjectID")%>' />
                                                            <asp:ImageButton ID="_ibtnDelete" runat="server" ImageUrl="/qistoollib/images/delete.png"
                                                                ImageAlign="AbsMiddle" CommandName="Delete" CausesValidation="false" Visible='<%# NOT(DataBinder.Eval(Container.DataItem, "IsClosed"))%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Project" ItemStyle-Width="80">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "ProjectAliasName")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Update Date" ItemStyle-Width="120">
                                                        <ItemTemplate>
                                                            <%# Format((DataBinder.Eval(Container.DataItem, "UpdateDate")),"dd-MMM-yyyy") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn runat="server" HeaderText="Issue Description">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "Remarks")%>
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
            </td>
        </tr>
        <tr>
            <td valign="bottom" colspan="3">
                <!-- BEGIN PAGE FOOTER-->
                <Module:Copyright ID="mdlCopyRight" runat="server" pathprefix=".."></Module:Copyright>
                <!-- END PAGE FOOTER-->
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
