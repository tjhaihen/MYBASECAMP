<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../incl/copyright.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BedInformationSummary.aspx.vb"
    Inherits="QIS.Web.Secure.BedInformationSummary" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Bed Information Summary</title>
    <link rel="title icon" href="/qistoollib/images/favicon.png" />
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href='/qistoollib/css/styles_blue.css' type="text/css" rel="Stylesheet" />
    <script language="javascript" type="text/javascript" src="/qistoollib/scripts/JScript.js"></script>
    <script type="text/javascript" language="javascript" src='/qistoollib/scripts/common/common.js'></script>
    <style type="text/css">
        #ulRepClass
        {
            width: 100%;
            margin: 0;
            padding: 0;                     
        }
        #ulRepClass li
        {
            list-style-type: none;
            display: inline-block; /* FF3.6; Chrome10+ */                     
            *display: inline;
            background: #eeeeee;
            width: 160px;
            height: 100px;
        }
    </style>
</head>
<body>
    <form id="frm" runat="server" style="background-image: url('/qistoollib/images/background.png');">
    <table border="0" width="100%" cellspacing="2" cellpadding="1" style="height: 100%;">
        <tr>
            <td width="100%" valign="top">
            </td>
        </tr>
        <tr>
            <td width="100%" height="100%" valign="top">
                <table cellspacing="10" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td class="rheader" colspan="2">
                            <table width="100%" style="font-family: Dekar, Arial, Tahoma;">
                                <td style="width: 100;">
                                    <img src="/qistoollib/images/clientCompanyLogo.png" width="40" alt="" border="" />
                                </td>
                                <td style="font-size: 24pt;">
                                    <asp:Label ID="lblCompanyName" runat="server"></asp:Label>
                                </td>
                                <td class="rheader" style="text-align: right; font-size: 24pt;">
                                    INFORMASI TEMPAT TIDUR
                                </td>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="hseparator" style="width: 100%;" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 50%; text-align: left; font-size: 14pt;">
                            <asp:ScriptManager ID="ScriptManager1" runat="server" />
                            <asp:Timer ID="TimerRefreshPage" runat="server" Interval="10000" OnTick="TimerRefreshPage_Tick">
                            </asp:Timer>
                            <asp:Timer ID="TimerDateTime" runat="server" Interval="1000" OnTick="TimerDateTime_Tick">
                            </asp:Timer>
                            <asp:Label ID="lblCompanyAddress" runat="server"></asp:Label>
                        </td>
                        <td style="width: 50%; text-align: right; font-size: 14pt;">
                            <asp:UpdatePanel ID="MyPanel" runat="server" UpdateMode="Conditional">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="TimerDateTime" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:Label ID="lblDateTime" runat="server"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>                            
                        </td>
                    </tr>
                    <tr>
                        <td class="hseparator" style="width: 100%;" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="rheaderexpable center" style="padding: 5 5 5 5;">
                            TEMPAT TIDUR TERSEDIA BERDASARKAN KELAS
                        </td>
                        <td class="rheaderexpable center" style="padding: 5 5 5 5;">
                            TEMPAT TIDUR TERSEDIA BERDASARKAN KELAS DAN RUANG
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 50%;">
                            <asp:Repeater ID="repClass" runat="server">
                                <HeaderTemplate>
                                    <ul id="ulRepClass">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <table cellspacing="1" width="100%">
                                            <tr>
                                                <td valign="middle" class="Heading3 center" style="background-color: #A1C934; padding-left: 0;
                                                    font-size: 20pt;">
                                                    <%# DataBinder.Eval(Container.DataItem, "ClassName")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="middle" class="center" style="font-size: 24pt; height: 60;">
                                                    <%# DataBinder.Eval(Container.DataItem, "TotalAvailable")%>
                                                </td>
                                            </tr>
                                        </table>
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ul>
                                </FooterTemplate>
                            </asp:Repeater>
                        </td>
                        <td align="left" valign="top" style="width: 50%;">
                            <table cellspacing="1" width="100%">
                                <tr>
                                    <td class="Heading3" style="background: #A1C934; padding: 5 5 5 5;">
                                        <asp:Label ID="lblClassCode" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblClassName" runat="server" Text="CLASS NAME"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DataGrid ID="grdDetailByClass" runat="server" BorderWidth="0" GridLines="None"
                                            Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                            AutoGenerateColumns="false" Font-Size="Large">
                                            <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                            <ItemStyle CssClass="gridItemStyle" />
                                            <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                            <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                            <Columns>
                                                <asp:TemplateColumn runat="server" HeaderText="Ruang">
                                                    <ItemTemplate>
                                                        <%# DataBinder.Eval(Container.DataItem, "RoomName")%>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn runat="server" HeaderText="Kapasitas" HeaderStyle-HorizontalAlign="Center"
                                                    ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <%# DataBinder.Eval(Container.DataItem, "TotalBed")%>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn runat="server" HeaderText="Tersedia" HeaderStyle-HorizontalAlign="Center"
                                                    ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <%# DataBinder.Eval(Container.DataItem, "TotalAvailable")%>
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
    </table>
    </form>
</body>
</html>
