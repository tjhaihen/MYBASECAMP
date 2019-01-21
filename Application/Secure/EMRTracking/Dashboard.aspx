<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../../incl/calendar.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Dashboard.aspx.vb" Inherits="QIS.Web.EMRTracking.Dashboard" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>EMR Dashboard</title>
    <link rel="title icon" href="/qistoollib/images/favicon.png" />
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href='/qistoollib/css/styles_blue.css' type="text/css" rel="Stylesheet" />
    <script language="javascript" type="text/javascript" src="/qistoollib/scripts/JScript.js"></script>
    <script type="text/javascript" language="javascript" src='/qistoollib/scripts/common/common.js'></script>
    <style type="text/css">
        #ulRepLocationGroup
        {
            width: 100%;
            margin: 0;
            padding: 0;                     
        }
        
        #ulRepLocationGroup li
        {
            list-style-type: none;
            display: inline-block; /* FF3.6; Chrome10+ */                     
            *display: inline;
            background: #BBD5F2;
            width: 220px;
            height: 220px;
            margin: 5px;            
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
                <div style="width: 100%; height: 100%; overflow: auto;">
                    <table cellspacing="10" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td align="left">
                                <table cellspacing="0" cellpadding="5" width="100%">
                                    <tr>
                                        <td class="rheader">
                                            Dashboard Bekas Rekam Medik
                                        </td>
                                        <td class="rheader" align="right">
                                            <asp:ImageButton ID="ibtnHistory" runat="server" ImageUrl="/qistoollib/images/ico-detail.png"
                                                Width="32" ToolTip="History" />
                                            <asp:ImageButton ID="ibtnSummary" runat="server" ImageUrl="/qistoollib/images/ico-summary.png"
                                                Width="32" ToolTip="Summary" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" style="width: 100%;" colspan="2">
                                        </td>
                                    </tr>
                                    <asp:Panel ID="pnlHistory" runat="server">
                                        <tr class="rbody">
                                            <td valign="top" colspan="2">
                                                <table width="100%">
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:ValidationSummary ID="ValidationSummary" runat="server" HeaderText="Please fill the following Field(s)." />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="50%" valign="top">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td style="width: 150px;" class="right">
                                                                        Nomor Rekam Medis
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtMedicalNo" Width="200" runat="server" Font-Size="Larger" AutoPostBack="True" />
                                                                        <asp:Button ID="btnGetData" runat="server" Text="Tampilkan" Font-Size="Larger" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 150px;" class="right">
                                                                        <font style="color: #003399">Nama</font>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblPatientName" runat="server" Font-Size="Larger"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 150px;" class="right">
                                                                        <font style="color: #003399">Jenis Kelamin</font>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblSex" runat="server" Font-Size="Larger"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 150px;" class="right">
                                                                        <font style="color: #003399">Tanggal Lahir</font>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblDOB" runat="server" Font-Size="Larger"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td width="50%" valign="top">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td style="width: 150px;" class="right">
                                                                        <font style="color: #003399">Alamat</font>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblStreetName" runat="server" Font-Size="Larger"></asp:Label><br />
                                                                        <asp:Label ID="lblCity" runat="server" Font-Size="Larger"></asp:Label>&nbsp;
                                                                        <asp:Label ID="lblZipCodeID" runat="server" Font-Size="Larger"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 150px;" class="right">
                                                                        <font style="color: #003399">Agama</font>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblReligion" runat="server" Font-Size="Larger"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="hseparator" style="width: 100%;" colspan="2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="50%" valign="top">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td style="width: 150px;" class="right">
                                                                        <font style="color: #003399">Lokasi Sekarang</font>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblCurrentLocationNameProcess" runat="server" Font-Size="Larger"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 150px;" class="right">
                                                                        <font style="color: #003399">Diproses Oleh</font>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblUserNameProcess" runat="server" Font-Size="Larger"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="hseparator" style="width: 100%;" colspan="2">
                                            </td>
                                        </tr>
                                        <tr class="rbody">
                                            <td valign="top" colspan="2">
                                                <table width="100%">
                                                    <tr>
                                                        <td class="rheader">
                                                            History Mutasi Berkas Rekam Medik
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="100%" valign="top">
                                                            <asp:DataGrid ID="grdEMRTrackingHistory" runat="server" BorderWidth="0" GridLines="None"
                                                                Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                AutoGenerateColumns="false">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                <ItemStyle CssClass="gridItemStyle" />
                                                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                <Columns>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Tanggal dan Jam Mutasi">
                                                                        <ItemTemplate>
                                                                            <%# Format(DataBinder.Eval(Container.DataItem, "processDate"), "dd-MMM-yyyy HH:mm")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Kelompok Lokasi">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "locationGroupName")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Lokasi">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "locationName")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Catatan">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "remarks")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="IN - OUT">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "processType")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Petugas">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "userNameProcess")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Lokasi Sekarang">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="_chkIsCurrentPosition" runat="server" Enabled="false" Checked='<%# DataBinder.Eval(Container.DataItem, "isCurrentPosition")%>' />
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
                                    <asp:Panel ID="pnlSummary" runat="server">
                                        <tr class="rbody">
                                            <td valign="top" width="100%" colspan="2">
                                                <table cellspacing="5" cellpadding="2">
                                                    <tr>
                                                        <td style="width: 150; background-color: #ACE8DC;">
                                                            <strong>Total Berkas:<br />
                                                                <div class="Heading3"><asp:Label ID="lblTotalMRN" runat="server"></asp:Label></div></strong>
                                                        </td>
                                                        <td style="width: 150; background-color: #F8C1BA;">
                                                            <strong>Total Berkas Keluar:<br />
                                                                <div class="Heading3"><asp:Label ID="lblTotalMRNout" runat="server"></asp:Label></div></strong>
                                                        </td>
                                                        <td style="width: 250; background-color: #FAEBA6;">
                                                            <strong>Nomor Rekam Medis terakhir:</strong><br />
                                                                <asp:Label ID="lblLastMedicalNo" runat="server"></asp:Label><br />
                                                                <asp:Label ID="lblLastPatientName" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr class="rbody">
                                            <td valign="top" width="70%">
                                                <asp:Repeater ID="repLocationGroup" runat="server" OnItemDataBound="repLocationGroup_ItemDataBound">
                                                    <HeaderTemplate>
                                                        <ul id="ulRepLocationGroup">
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <li>
                                                            <asp:Panel ID="pnlHEXColor" runat="server" Height="100%">
                                                                <div class="Heading3">
                                                                    <%# DataBinder.Eval(Container.DataItem, "LocationGroupName")%>
                                                                </div>
                                                                <div style="text-align: right; font-weight: bold;">
                                                                    Total:&nbsp;<asp:Label ID="_lblTotalMRNCount" runat="server"></asp:Label>
                                                                </div>
                                                                <div class="hseparator"></div>
                                                                <div>
                                                                    <asp:DataGrid ID="_grdLocation" runat="server" BorderWidth="0" GridLines="Horizontal"
                                                                        Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                        AutoGenerateColumns="false" OnItemCommand="_grdLocation_ItemCommand">
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                        <ItemStyle />
                                                                        <AlternatingItemStyle />
                                                                        <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                        <Columns>
                                                                            <asp:TemplateColumn runat="server" HeaderText="Lokasi">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="_lbtnLocationName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "locationName")%>'
                                                                                        ToolTip='<%# DataBinder.Eval(Container.DataItem, "locationCode")%>' CommandName="SelectByLocation"></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateColumn>
                                                                            <asp:TemplateColumn runat="server" HeaderText="#Berkas" HeaderStyle-HorizontalAlign="Right"
                                                                                ItemStyle-HorizontalAlign="Right">
                                                                                <ItemTemplate>
                                                                                    <%# DataBinder.Eval(Container.DataItem, "MRNcount")%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateColumn>
                                                                        </Columns>
                                                                    </asp:DataGrid>
                                                                </div>                                                                
                                                            </asp:Panel>
                                                        </li>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </ul>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                            </td>
                                            <td valign="top" width=20%">
                                                <table width="100%">
                                                    <tr>
                                                        <td>
                                                            <b><asp:Label ID="lblLocationNameSelected" runat="server"></asp:Label></b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DataGrid ID="grdMRNByLocation" runat="server" BorderWidth="0" GridLines="none"
                                                                Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                                AutoGenerateColumns="false">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                                <ItemStyle CssClass="gridItemStyle" />
                                                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                <Columns>
                                                                    <asp:TemplateColumn runat="server" HeaderText="#" ItemStyle-VerticalAlign="Top">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "RowNumber")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Pasien" ItemStyle-VerticalAlign="Top">
                                                                        <ItemTemplate>
                                                                            <table cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <strong><%# DataBinder.Eval(Container.DataItem, "medicalNo")%></strong>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <%# DataBinder.Eval(Container.DataItem, "PatientName")%>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>                                                                            
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Petugas" ItemStyle-VerticalAlign="Top">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "UserNameProcess")%>
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
