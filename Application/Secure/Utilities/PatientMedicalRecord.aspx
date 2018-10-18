<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../../incl/calendar.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PatientMedicalRecord.aspx.vb"
    Inherits="QIS.Web.Secure.PatientMedicalRecord" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Informasi Rekam Medis Pasien</title>
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
                                        Upload Dokumen Rekam Medis Pasien
                                    </td>
                                </tr>
                                <tr>
                                    <td class="hseparator" style="width: 100%;">
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
                                                    Nomor Rekam Medis
                                                </td>
                                                <td style="width: 500px;">
                                                    <asp:TextBox ID="txtMRN" Width="150" MaxLength="15" runat="server" AutoPostBack="true" />
                                                    (cth. 00-00-00-00)
                                                    <asp:RequiredFieldValidator ID="rfvMRN" runat="server" ControlToValidate="txtMRN"
                                                        ErrorMessage="Nomor Rekam Medis" Display="dynamic" Text="*">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                                <td style="width: 200;" class="right">
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="right" style="background-color: #30CD08; color: #ffffff; width: 200;">
                                                    Nama Pasien
                                                </td>
                                                <td style="width: 500px;">
                                                    <asp:Label ID="txtPatientName" runat="server"></asp:Label>
                                                </td>
                                                <td class="right" style="background-color: #30CD08; color: #ffffff; width: 200;"
                                                    valign="top">
                                                    Alamat
                                                </td>
                                                <td rowspan="2" valign="top">
                                                    <asp:Label ID="lblAddress" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="right" style="background-color: #30CD08; color: #ffffff; width: 200;">
                                                    Tempat & Tgl. Lahir
                                                </td>
                                                <td style="width: 500px;">
                                                    <asp:Label ID="lblPlaceOfBirth" runat="server"></asp:Label>,
                                                    <asp:Label ID="lblDateOfBirth" runat="server"></asp:Label>
                                                </td>
                                                <td style="width: 200;" class="right">
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
                                    <td>
                                        <table width="100%">
                                            <tr>
                                                <td class="right" style="background-color: #30CD08; color: #ffffff; width: 200;">
                                                    Pilih File
                                                </td>
                                                <td style="width: 500px;">
                                                    <asp:TextBox ID="txtFileID" Width="300" MaxLength="500" runat="server" Visible="false">
                                                    </asp:TextBox>
                                                    <input id="txtFileUrl" type="file" name="txtFileUrl" runat="server" class="imguploader"
                                                        style="width: 300px;">
                                                </td>
                                                <td style="width: 200;" class="right">
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="right" style="background-color: #30CD08; color: #ffffff; width: 200;">
                                                    Nama File
                                                </td>
                                                <td style="width: 500px;">
                                                    <asp:TextBox ID="txtFileName" Width="300" MaxLength="500" runat="server">
                                                    </asp:TextBox>
                                                </td>
                                                <td style="width: 200;" class="right">
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="right" style="background-color: #30CD08; color: #ffffff; width: 200;">
                                                    Keterangan
                                                </td>
                                                <td style="width: 500px;">
                                                    <asp:TextBox ID="txtFileDescription" Width="300" MaxLength="500" runat="server">
                                                    </asp:TextBox>
                                                </td>
                                                <td style="width: 200;" class="right">
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="right" style="background-color: #30CD08; color: #ffffff; width: 200;">
                                                </td>
                                                <td style="width: 500px;">
                                                    <asp:Button ID="btnUpload" Width="100" runat="server" Text="Upload"></asp:Button>
                                                </td>
                                                <td style="width: 200;" class="right">
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:DataGrid ID="grdPatientDocument" runat="server" BorderWidth="0" GridLines="None"
                                                        Width="100%" CellPadding="2" CellSpacing="1" ShowHeader="true" ShowFooter="false"
                                                        AutoGenerateColumns="false">
                                                        <HeaderStyle HorizontalAlign="Left" CssClass="gridHeaderStyle" />
                                                        <ItemStyle CssClass="gridItemStyle" />
                                                        <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                        <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                        <Columns>
                                                            <asp:TemplateColumn runat="server" HeaderText="" ItemStyle-Width="50" ItemStyle-VerticalAlign="Top">
                                                                <ItemTemplate>
                                                                    <a href='<%# DataBinder.Eval(Container.DataItem, "FileUrl") %>' target="_blank" title="Preview File">
                                                                        <img src="/qistoollib/images/look.png" border="0" alt="Preview File" />
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn runat="server" HeaderText="Nama Dokumen" ItemStyle-VerticalAlign="Top">
                                                                <ItemTemplate>
                                                                    <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FileID") %>'
                                                                        ID="_lblFileID" Visible="false" />
                                                                    <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FileName") %>'
                                                                        ID="_lblFileName" />
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn runat="server" HeaderText="Tipe" ItemStyle-Width="80" ItemStyle-VerticalAlign="Top">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container.DataItem, "FileExtension")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn runat="server" HeaderText="Keterangan" ItemStyle-VerticalAlign="Top">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container.DataItem, "FileDescription")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn runat="server" HeaderText="Diunggah" ItemStyle-Width="150" ItemStyle-VerticalAlign="Top">
                                                                <ItemTemplate>
                                                                    <%# DataBinder.Eval(Container.DataItem, "UploadByName")%><br />
                                                                    on&nbsp;<%# Format(DataBinder.Eval(Container.DataItem, "UploadDate"),"dd-MMM-yyyy hh:mm")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn runat="server" HeaderText="" ItemStyle-Width="30" ItemStyle-VerticalAlign="Top">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton runat="server" ID="_ibtnDelete" ImageUrl="/qistoollib/images/delete.png"
                                                                        CommandName="Delete" ToolTip="Delete" />
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
