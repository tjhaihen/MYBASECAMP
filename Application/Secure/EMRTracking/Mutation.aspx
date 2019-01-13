<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../../incl/calendar.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Mutation.aspx.vb"
    Inherits="QIS.Web.EMRTracking.Mutation" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>EMR Mutation</title>
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
                                            Mutasi Bekas Rekam Medik
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
                                                    <td colspan="2">
                                                        <asp:ValidationSummary ID="ValidationSummary" runat="server" HeaderText="Please fill the following Field(s)." />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="80%" valign="top">
                                                        <table width="100%">
                                                            <tr>
                                                                <td style="width: 150px;" class="right">
                                                                    Lokasi
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlEMRLocation" runat="server" Width="300" Font-Size="Larger"></asp:DropDownList>
                                                                    <asp:DropDownList ID="ddlProcessType" runat="server" Width="300" Font-Size="Larger">
                                                                        <asp:ListItem Text="OUT - Kirim Berkas" Value="OUT"></asp:ListItem>
                                                                        <asp:ListItem Text="IN - Terima Berkas" Value="IN"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 150px;" class="right">
                                                                    Nomor Rekam Medis
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtMedicalNo" Width="300" runat="server" Font-Size="X-Large" AutoPostBack="True" />
                                                                    <asp:Button ID="btnGetData" runat="server" Text="Tampilkan" Font-Size="X-Large" />
                                                                    <asp:Button ID="btnAccept" runat="server" Text="Proses Berkas" Font-Size="X-Large" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 150px;" class="right">
                                                                    Lokasi Asal
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtCurrentLocationName" runat="server" Font-Size="Larger" ReadOnly="true" CssClass="txtReadOnly" Width="300"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="20%" valign="top">
                                                        <asp:ImageButton ID="ibtnLockUnlock" runat="server" ImageUrl="/qistoollib/images/big_unlock.png" ImageAlign="AbsMiddle" />
                                                        <asp:CheckBox ID="chkIsLock" runat="server" Visible="false"></asp:CheckBox>
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
                                            <table width="100%">
                                                <tr>
                                                    <td colspan="2" class="rheader">
                                                        Data Pasien
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="50%" valign="top">
                                                        <table width="100%">
                                                            <tr>
                                                                <td style="width: 150px;" class="right">
                                                                    <font style="color: #003399">Nomor Rekam Medis</font>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblMedicalNo" runat="server" Font-Size="Larger"></asp:Label>
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
                                                            <tr>
                                                                <td style="width: 150px;" class="right">
                                                                    <font style="color: #003399">Golongan Darah</font>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblBloodType" runat="server" Font-Size="Larger"></asp:Label>&nbsp;
                                                                    <asp:Label ID="lblBloodRhesus" runat="server" Font-Size="Larger"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="50%" valign="top">
                                                        <table width="100%" style="background-color: #eeeeee;">
                                                            <tr>
                                                                <td style="width: 150px;" class="right">
                                                                    <font style="color: #003399">Status</font>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblStatus" runat="server" Font-Size="Larger"></asp:Label>
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
                                                            <tr>
                                                                <td style="width: 150px;" class="right">
                                                                    <font style="color: #003399">Lokasi Sekarang</font>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblCurrentLocationNameProcess" runat="server" Font-Size="Larger"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table width="100%">
                                                            <tr>
                                                                <td style="width: 150px;" class="right">
                                                                    <font style="color: #003399">Catatan</font>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtRemarks" runat="server" Width="400" TextMode="MultiLine" Height="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                    </td>
                                                </tr>
                                            </table>
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
