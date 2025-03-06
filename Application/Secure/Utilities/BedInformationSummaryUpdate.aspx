<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../incl/copyright.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BedInformationSummaryUpdate.aspx.vb"
    Inherits="QIS.Web.Secure.BedInformationSummaryUpdate" %>

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
        .style1
        {
            width: 83%;
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
                        <td style="text-align: left; font-size: 14pt;" class="style1">
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
                        <td align="Center" style="width: 100%;" colspan="2">
                            <asp:DataGrid ID="grdKamar" runat="server" BorderWidth="2" GridLines="Horizontal"
                                            Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                            AutoGenerateColumns="false" Font-Size="Large">
                                            <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                            <ItemStyle CssClass="gridItemStyle" />
                                            <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                            <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                <Columns>
                                    <asp:TemplateColumn runat="server" HeaderText="KELAS" HeaderStyle-HorizontalAlign="Left"
                                         ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="Aquamarine" HeaderStyle-Font-Bold="true">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Kelas") %>'
                                                ID="_lblRegistrationNo" ForeColor="Blue"/>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn runat="server" HeaderText="TERISI" HeaderStyle-HorizontalAlign="Right"
                                         ItemStyle-HorizontalAlign="Right" HeaderStyle-BackColor="Aquamarine" HeaderStyle-Font-Bold="true">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Terisi") %>'
                                                ID="_lblTransactionNo" />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn runat="server" HeaderText="TERSEDIA" HeaderStyle-HorizontalAlign="Right"
                                         ItemStyle-HorizontalAlign="Right" HeaderStyle-BackColor="Aquamarine" HeaderStyle-Font-Bold="true">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container.DataItem, "Tersedia")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn runat="server" HeaderText="TOTAL" HeaderStyle-HorizontalAlign="Right"
                                         ItemStyle-HorizontalAlign="Right" HeaderStyle-BackColor="Aquamarine" HeaderStyle-Font-Bold="true">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container.DataItem, "Total")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn runat="server" HeaderText="UPDATE" HeaderStyle-HorizontalAlign="Center"
                                         ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Aquamarine" HeaderStyle-Font-Bold="true">
                                        <ItemTemplate>
                                            <%# Format(DataBinder.Eval(Container.DataItem, "TanggalUpdate"), "dd-MMM-yyyy HH:MM")%>
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
    </form>
</body>
</html>
