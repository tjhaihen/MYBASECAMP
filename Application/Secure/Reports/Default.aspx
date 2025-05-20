<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="QIS.Web.Reports" %>

<%@ Register TagPrefix="Module" TagName="webcal" Src="../../../incl/calendar.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../../../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI, Version=1.9.0.0, Culture=neutral, PublicKeyToken=24d65337282035f2" %>
<%@ Import Namespace="QIS.Web" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Laporan</title>
    <meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
    <meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="/qislib/css/styles.css" type="text/css" rel="Stylesheet">
    <script language="javascript" src='<%= UrlBase + "/JSDLGGlobalVar.aspx" %>'></script>
    <script language="javascript" src="/qislib/scripts/rs_/rs___Dlg_Rs-v2.js"></script>
    <script type="text/javascript">
        $(function () {
            $('.treenode').hover(function () {
                $('.treenode').css("font-underline", "false");
            });
        });
    </script>
    <style type="text/css">
        .treenode
        {
            text-decoration: none;
        }
    </style>
</head>
<body>
    <form id="frmRpt" runat="server">
    <table cellspacing="0" cellpadding="2" width="100%" style="height: 100%;" border="0">
        <tr>
            <td width="100%" valign="top" colspan="3">
                <!-- BEGIN PAGE HEADER -->
                <Module:RadMenu ID="RadMenu" runat="server" />
                <!-- END PAGE HEADER -->
            </td>
        </tr>
        <tr>
            <td width="100%" valign="top" colspan="3">
                <Module:CSSToolbar ID="CSSToolbar" runat="server"></Module:CSSToolbar>
            </td>
        </tr>
        <tr>
            <td valign="top" height="100%" width="25%">
                <table cellspacing="5" cellpadding="0" style="height: 100%;" width="100%" border="0">
                    <tr>
                        <td valign="top">
                            <table cellspacing="0" cellpadding="6" width="100%" style="height: 100%;">
                                <tr class="rheader">
                                    <td class="rheadercol" align="left" height="25">
                                        Daftar Laporan
                                    </td>
                                </tr>
                                <tr class="rbody">
                                    <td style="height: 100%;">
                                        <div style="height: 100%; overflow: auto;">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:TreeView runat="server" ID="trvReport" Width="100%" Height="100%" ExpandDepth="-1"
                                                            ShowLines="true" ShowExpandCollapse="true">
                                                            <NodeStyle ForeColor="Black" CssClass="treenode" />
                                                        </asp:TreeView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" style="height: 100%;" width="1px" bgcolor="#999999">
            </td>
            <td valign="top" width="75%" style="height: 100%;">
                <table cellspacing="5" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td valign="top" align="left" style="height: 100%;">
                            <asp:Panel ID="panel1" runat="server">
                                <table cellspacing="0" cellpadding="6" width="100%" style="height: 100%;">
                                    <tr class="rheader">
                                        <td class="rheadercol" align="left" height="32">
                                            <asp:Label ID="lblReportDesc" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="rbody">
                                        <td class="rbodycol" style="height: 1px" align="left">
                                            <!-- pd1: Periode -->
                                            <asp:Panel ID="pd1" runat="server" Visible="False">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td colspan="2" class="rheaderexpable" style="height: 24">
                                                            Periode
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            Tanggal dari
                                                        </td>
                                                        <td width="60%">
                                                            <Module:webcal ID="calStart" runat="server"></Module:webcal>
                                                            &nbsp;s/d&nbsp;
                                                            <Module:webcal ID="calEnd" runat="server"></Module:webcal>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- pdJam: Jam -->
                                            <asp:Panel ID="pdJam" runat="server" Visible="False">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td colspan="2" class="rheaderexpable" style="height: 24">
                                                            Jam
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            Shift
                                                        </td>
                                                        <td width="60%">
                                                            <asp:DropDownList ID="ddlShiftJam" runat="server" Width="100" AutoPostBack="true">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            Jam dari
                                                        </td>
                                                        <td width="60%">
                                                            <ew:MaskedTextBox ID="txtJamDari" runat="server" Width="100px" />
                                                            &nbsp;s/d&nbsp;
                                                            <ew:MaskedTextBox ID="txtJamSampai" runat="server" Width="100px" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pdDokterSingle" runat="server" Visible="False">
                                                <table width="100%">
                                                    <tr>
                                                        <td colspan="2" class="rheaderexpable" style="height: 24px;">
                                                            Kode Gudang
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="20%">
                                                            Gudang
                                                        </td>
                                                        <td width="60%">
                                                            <asp:DropDownList runat="server" ID="ddlDokterSingle" Width="60%" AutoPostBack="false">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox runat="server" ID="chkAllDokter" Text="Semua Gudang" AutoPostBack="false" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!--Tanggal Tunggal-->
                                            <asp:Panel ID="pd44" runat="server" Visible="False">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            Tanggal
                                                        </td>
                                                        <td width="60%">
                                                            <Module:webcal ID="calTanggal" runat="server"></Module:webcal>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!--DOKTER MULAI/ SAMPAI DENGAN-->
                                            <asp:Panel ID="pd3" runat="server" Visible="False">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td colspan="2" class="rheaderexpable" style="height: 24">
                                                            Dokter
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtndrMulai" runat="server" CausesValidation="False" Text="Dokter dari"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtdrMulai" runat="server" MaxLength="10" Width="100"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:LinkButton ID="lbtndrSampai" runat="server" CausesValidation="False" Text="sampai Dokter"></asp:LinkButton>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtdrSampai" runat="server" MaxLength="10" Width="100"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- INSTANSI MULAI/SAMPAI DENGAN -->
                                            <asp:Panel ID="pd5" runat="server" Visible="False">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td colspan="2" class="rheaderexpable" style="height: 24">
                                                            Rekanan / Instansi
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnKodeInstansiMulai" runat="server" CausesValidation="False"
                                                                Text="Instansi dari"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtKodeInstansiMulai" runat="server" MaxLength="15" Width="80%"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorKodeInstansiMulai" runat="server"
                                                                Display="dynamic" ErrorMessage="Instansi dari" ControlToValidate="txtKodeInstansiMulai">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnKodeInstansiSampai" runat="server" CausesValidation="False"
                                                                Text="sampai Instansi"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtKodeInstansiSampai" runat="server" MaxLength="15" Width="80%"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorKodeInstansiSampai" runat="server"
                                                                Display="dynamic" ErrorMessage="sampai Instansi" ControlToValidate="txtKodeInstansiSampai">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pdJnsInstansi" runat="server" Visible="False">
                                                <table width="100%">
                                                    <tr>
                                                        <td colspan="2" class="rheaderexpable" style="height: 24">
                                                            Jenis Instansi
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="20%">
                                                            Jenis Instansi
                                                        </td>
                                                        <td width="60%">
                                                            <asp:DropDownList ID="ddlJnsInstansi" runat="server">
                                                            </asp:DropDownList>
                                                           
                                                        </td>
                                                      
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                          <asp:CheckBox ID="chksmuaInstansi" runat="server" Text="Semua" AutoPostBack="true"  Checked="False">
                                                            </asp:CheckBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pd26" runat="server" Visible="false">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            Asal Pasien
                                                        </td>
                                                        <td width="60%">
                                                            <asp:DropDownList ID="ddlmoduleS" runat="server" Width="80%">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pd85" runat="server" Visible="false">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            Asal Pasien
                                                        </td>
                                                        <td width="60%">
                                                            <asp:DropDownList ID="ddlPnjlnItem" runat="server" Width="80%" AutoPostBack="True">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pd93" runat="server" Visible="false">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            Asal Pasien
                                                        </td>
                                                        <td width="60%">
                                                            <asp:DropDownList ID="ddlsmrirjrdmdmculb" runat="server" Width="80%" AutoPostBack="True">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pd84" runat="server" Visible="false">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            Asal Pasien
                                                        </td>
                                                        <td width="60%">
                                                            <asp:DropDownList ID="ddlktr" runat="server" Width="80%" AutoPostBack="True">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pd92" runat="server" Visible="false">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td colspan="2" class="rheaderexpable" style="height: 24">
                                                            Asal Pasien
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            Asal Pasien
                                                        </td>
                                                        <td width="60%">
                                                            <asp:DropDownList ID="ddlsemuaasalpasien" runat="server" Width="80%">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pd83" runat="server" Visible="false">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            Asal Pasien
                                                        </td>
                                                        <td width="60%">
                                                            <asp:DropDownList ID="ddlPiutangInstansiRIRJ" runat="server" Width="80%">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pd91" runat="server" Visible="false">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            Asal Pasien
                                                        </td>
                                                        <td width="60%">
                                                            <asp:DropDownList ID="ddlmoduleSMCULB" runat="server" Width="80%">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- LAYAN MULAI/SAMPAI DENGAN -->
                                            <asp:Panel ID="pd25" runat="server" Visible="False">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td colspan="2" class="rheaderexpable">
                                                            Pelayanan
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnkdlayanawal" runat="server" CausesValidation="False" Text="Pelayanan dari"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtkdlayanawal" runat="server" MaxLength="20" Width="80%"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorkdlayanawal" runat="server"
                                                                Display="dynamic" ErrorMessage="Pelayanan dari" ControlToValidate="txtkdlayanawal">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnkdlayanakhir" runat="server" CausesValidation="False" Text="sampai Pelayanan"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtkdlayanakhir" runat="server" MaxLength="20" Width="80%"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorkdlayanakhir" runat="server"
                                                                Display="dynamic" ErrorMessage="sampai Pelayanan" ControlToValidate="txtkdlayanakhir">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- test MULAI/SAMPAI DENGAN -->
                                            <asp:Panel ID="pd86" runat="server" Visible="False">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td colspan="2" class="rheaderexpable">
                                                            Pemeriksaan Laboratorium
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnkdtestawal" runat="server" CausesValidation="False" Text="Pemeriksaan dari"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtkdtestawal" runat="server" MaxLength="20" Width="80%"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorkdtestawal" runat="server"
                                                                Display="dynamic" ErrorMessage="Pemeriksaan dari" ControlToValidate="txtkdtestawal">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnkdtestakhir" runat="server" CausesValidation="False" Text="sampai Pemeriksaan"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtkdtestakhir" runat="server" MaxLength="20" Width="80%"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorkdtestakhir" runat="server"
                                                                Display="dynamic" ErrorMessage="sampai Pemeriksaan" ControlToValidate="txtkdtestakhir">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- INSTANSI ditagihkan MULAI/SAMPAI DENGAN -->
                                            <asp:Panel ID="pd59" runat="server" Visible="False">
                                                
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td colspan="2" class="rheaderexpable" style="height: 24">
                                                            Kode Instansi Ditagihkan
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnKodeInstansiditagihkanMulai" runat="server" CausesValidation="False"
                                                                Text="Ditagihkan Ke Instansi Mulai"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtKodeInstansiditagihkanMulai" runat="server" MaxLength="20" Width="80%"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorKodeInstansiditagihkanMulai"
                                                                runat="server" Display="dynamic" ErrorMessage="Ditagihkan Ke Instansi Mulai"
                                                                ControlToValidate="txtKodeInstansiditagihkanMulai">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnKodeInstansiditagihkanSampai" runat="server" CausesValidation="False"
                                                                Text="Ditagihkan Ke Instansi Sampai"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtKodeInstansiditagihkanSampai" runat="server" MaxLength="20" Width="80%"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorKodeInstansiditagihkanSampai"
                                                                runat="server" Display="dynamic" ErrorMessage="Ditagihkan Ke Instansi Sampai"
                                                                ControlToValidate="txtKodeInstansiditagihkanSampai">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- INSTANSI -->
                                            <asp:Panel ID="pd52" runat="server" Visible="False">
                                                KODE INSTANSI
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnKodeInstansi" runat="server" CausesValidation="False" Text="Instansi"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtKodeInstansi" runat="server" MaxLength="15" Width="80%" AutoPostBack="true"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorKodeInstansi" runat="server"
                                                                Display="dynamic" ErrorMessage="Instansi" ControlToValidate="txtKodeInstansi">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                        </td>
                                                        <td width="60%">
                                                            <asp:Label ID="lblNamaInstansi" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- Buku Treasury -->
                                            <asp:Panel ID="Pd27" runat="server" Visible="False">
                                                KODE BUKU
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnKdBuku" runat="server" CausesValidation="False" Text="Kode Buku"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtKdBuku" runat="server" MaxLength="20" Width="80%" AutoPostBack="true"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorKodeBuku" runat="server" Display="dynamic"
                                                                ErrorMessage="KODE BUKU" ControlToValidate="txtKdBuku">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                        </td>
                                                        <td width="60%">
                                                            <asp:Label ID="lblKdBuku" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- kode coa -->
                                            <asp:Panel ID="Pd57" runat="server" Visible="False">
                                                KODE COA
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnKdcoaawal" runat="server" CausesValidation="False" Text="Kode COA Mulai"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtKdcoaawal" runat="server" MaxLength="50" Width="80%" AutoPostBack="true"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorKodeCoaawal" runat="server"
                                                                Display="dynamic" ErrorMessage="Kode COA Mulai" ControlToValidate="txtKdcoaawal">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnKdcoaakhir" runat="server" CausesValidation="False" Text="Kode COA Akhir"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtKdcoaakhir" runat="server" MaxLength="50" Width="80%" AutoPostBack="true"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorKodeCoaakhir" runat="server"
                                                                Display="dynamic" ErrorMessage="Kode COA Akhir" ControlToValidate="txtKdcoaakhir">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- norm ditagihkan MULAI/SAMPAI DENGAN -->
                                            <asp:Panel ID="pd58" runat="server" Visible="False">
                                                NO REKAM MEDIS
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnnormMulai" runat="server" CausesValidation="False" Text="No Rekam Medis Awal"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtnormMulai" runat="server" MaxLength="20" Width="80%"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatornormMulai" runat="server" Display="dynamic"
                                                                ErrorMessage="No Rekam Medis Awal" ControlToValidate="txtnormMulai">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnnormSampai" runat="server" CausesValidation="False" Text="No Rekam Medis Akhir"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtnormSampai" runat="server" MaxLength="20" Width="80%"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatornormSampai" runat="server"
                                                                Display="dynamic" ErrorMessage="No Rekam Medis Akhir" ControlToValidate="txtnormSampai">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- NoInvoice MULAI/SAMPAI DENGAN -->
                                            <asp:Panel ID="pd53" runat="server" Visible="False">
                                                NO INVOICE
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnNoInvoiceMulai" runat="server" CausesValidation="False" Text="No Invoice Mulai"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtNoInvoiceMulai" runat="server" MaxLength="15" Width="80%" AutoPostBack="true"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorNoInvoiceMulai" runat="server"
                                                                Display="dynamic" ErrorMessage="No Invoice Mulai" ControlToValidate="txtNoInvoiceMulai">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnNoInvoiceSampai" runat="server" CausesValidation="False"
                                                                Text="No Invoice Sampai"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtNoInvoiceSampai" runat="server" MaxLength="15" Width="80%" AutoPostBack="true"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorNoInvoiceSampai" runat="server"
                                                                Display="dynamic" ErrorMessage="No Invoice Sampai" ControlToValidate="txtNoInvoiceSampai">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- Piutang Non Operasional -->
                                            <asp:Panel ID="pd54" runat="server" Visible="False">
                                                KODE PIUTANG NON OPERASIONAL
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnKodePiutangNonOprMulai" runat="server" CausesValidation="False"
                                                                Text="Piutang Mulai"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtKodePiutangNonOprMulai" runat="server" MaxLength="15" Width="80%"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorKodePiutangNonOprMulai" runat="server"
                                                                Display="dynamic" ErrorMessage="Piutang Mulai" ControlToValidate="txtKodePiutangNonOprMulai">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnKodePiutangNonOprSampai" runat="server" CausesValidation="False"
                                                                Text="Piutang Sampai"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtKodePiutangNonOprSampai" runat="server" MaxLength="15" Width="80%"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorKodePiutangNonOprSampai" runat="server"
                                                                Display="dynamic" ErrorMessage="Piutang Sampai" ControlToValidate="txtKodePiutangNonOprSampai">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- GROUP PELAYANAN MULAI/SAMPAI DENGAN -->
                                            <asp:Panel ID="pd7" runat="server" Visible="False">
                                                GROUP PELAYANAN
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            Group Pelayanan Mulai
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtGrpStart" runat="server" MaxLength="10" Width="80%"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorGrpStart" runat="server" Display="dynamic"
                                                                ErrorMessage="Group Pelayanan Mulai" ControlToValidate="txtGrpStart">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            Group Pelayanan Sampai
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtGrpEnd" runat="server" MaxLength="10" Width="80%"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorGrpEnd" runat="server" Display="dynamic"
                                                                ErrorMessage="Sampai Group Pelayanan" ControlToValidate="txtGrpEnd">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- USER NAME -->
                                            <asp:Panel ID="pd8" Style="display: none" runat="server" Visible="False">
                                                NAMA USER
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            Nama User
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtUser" runat="server" MaxLength="15" Width="80%" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- PERIODE -->
                                            <asp:Panel ID="pd9" runat="server" Visible="False">
                                                TANGGAL
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            Tanggal Mulai
                                                        </td>
                                                        <td width="60%">
                                                            <Module:webcal ID="calTanggalmulai" runat="server"></Module:webcal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            Tanggal Sampai
                                                        </td>
                                                        <td width="60%">
                                                            <Module:webcal ID="calTanggalsampai" runat="server"></Module:webcal>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- KODE DTD -->
                                            <asp:Panel ID="pd11" runat="server" Visible="false">
                                                KODE DTD
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="linkDTDStart" runat="server" CausesValidation="False" Text="Kode DTD Mulai"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtDTDStart" runat="server" MaxLength="10" Width="80%"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldDTDStart" runat="server" Display="dynamic"
                                                                ErrorMessage="Kode DTD" ControlToValidate="txtDTDStart">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="linkDTDEnd" runat="server" CausesValidation="False" Text="Kode DTD Sampai"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtDTDEnd" runat="server" MaxLength="10" Width="80%"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldDTDEnd" runat="server" Display="dynamic"
                                                                ErrorMessage="Kode DTD" ControlToValidate="txtDTDEnd">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- KODE POLIKLINIK -->
                                            <asp:Panel ID="pd12" runat="server" Visible="false">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td colspan="2" class="rheaderexpable" style="height: 24">
                                                            Poliklinik
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="linkPoliStart" runat="server" CausesValidation="False" Text="Kode Poliklinik Mulai"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtPoliStart" runat="server" MaxLength="10" Width="80%"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldPoliStart" runat="server" Display="dynamic"
                                                                ErrorMessage="Kode Poliklinik" ControlToValidate="txtPoliStart">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="linkPoliEnd" runat="server" CausesValidation="False" Text="Kode Poliklinik Sampai"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtPoliEnd" runat="server" MaxLength="10" Width="80%"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldPoliEnd" runat="server" Display="dynamic"
                                                                ErrorMessage="Kode Poliklinik" ControlToValidate="txtPoliEnd">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- ALPHABET -->
                                            <asp:Panel ID="pd13" runat="server" Visible="false">
                                                <strong>URUTAN ALFABET</strong>
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            Huruf Depan Nama Pasien
                                                        </td>
                                                        <td width="60%">
                                                            <asp:DropDownList ID="ddlAlphabet" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- Option Type (Nama, Alamat, TglLahir) -->
                                            <asp:Panel ID="pd17" runat="server" Visible="false">
                                                <table width="100%" cellpadding="2">
                                                    <p>
                                                        <tbody>
                                                            <tr>
                                                                <td valign="top" width="20%">
                                                                    Pencarian Data Pasien Yang Sama Berdasarkan :
                                                                </td>
                                                                <td valign="top" width="60%">
                                                                    <asp:CheckBoxList ID="OptionType" runat="server">
                                                                        <asp:ListItem Value="Nama" Selected="True">Nama</asp:ListItem>
                                                                        <asp:ListItem Value="Alamat" Selected="True">Alamat</asp:ListItem>
                                                                        <asp:ListItem Value="Tgllahir" Selected="True">Tanggal Lahir</asp:ListItem>
                                                                    </asp:CheckBoxList>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </p>
                                                </table>
                                            </asp:Panel>
                                            <!-- JUMLAH TAHUN -->
                                            <asp:Panel ID="pd19" runat="server" Visible="false">
                                                JUMLAH TAHUN
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            Jumlah Tahun
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlYear" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- KODE Diagnosa -->
                                            <asp:Panel ID="pd20" runat="server" Visible="false">
                                                KODE DIAGNOSA
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="linkDiagnosaStart" runat="server" CausesValidation="False" Text="Kode Diagnosa Mulai"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtDiagnosaStart" runat="server" MaxLength="10" Width="80%"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldDiagnosaStart" runat="server" Display="dynamic"
                                                                ErrorMessage="Kode Diagnosa" ControlToValidate="txtDiagnosaStart">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="linkDiagnosaEnd" runat="server" CausesValidation="False" Text="Kode Diagnosa Sampai"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtDiagnosaEnd" runat="server" MaxLength="10" Width="80%"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldDiagnosaEnd" runat="server" Display="dynamic"
                                                                ErrorMessage="Kode Diagnosa" ControlToValidate="txtDiagnosaEnd">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pd21" runat="server" Visible="false">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            Urutan Berdasarkan
                                                        </td>
                                                        <td width="60%">
                                                            <asp:DropDownList ID="ddlSortBy" runat="server" Width="80%">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pd23" runat="server" Visible="false">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            Urutan Berdasarkan
                                                        </td>
                                                        <td width="60%">
                                                            <asp:DropDownList ID="ddlSortByPribadi" runat="server" Width="80%">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pd24" runat="server" Visible="false">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            Shift
                                                        </td>
                                                        <td width="60%">
                                                            <asp:DropDownList ID="DdlShift" runat="server" Width="80%">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!--Kode Pos-->
                                            <asp:Panel ID="Pd28" runat="server" Visible="False">
                                                KODE POS
                                                <table width="100%" cellpadding="2">
                                                    <tbody>
                                                        <tr>
                                                            <td width="10%">
                                                                <asp:LinkButton ID="lbtnkodeposmulai" runat="server" Text="Kode Pos Mulai" CausesValidation="False"></asp:LinkButton>
                                                            </td>
                                                            <td width="60%">
                                                                <asp:TextBox ID="txtkodeposmulai" runat="server" Width="80%" MaxLength="10"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="10%">
                                                                <asp:LinkButton ID="lbtnkodepossampai" runat="server" Text="Kode Pos Sampai" CausesValidation="False"></asp:LinkButton>
                                                            </td>
                                                            <td width="60%">
                                                                <asp:TextBox ID="Txtkodepossampai" runat="server" Width="80%" MaxLength="10"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </asp:Panel>
                                            <!--Pengirim-->
                                            <asp:Panel ID="Pd29" runat="server" Visible="False">
                                                PENGIRIM
                                                <table width="100%" cellpadding="2">
                                                    <tbody>
                                                        <tr>
                                                            <td width="10%">
                                                                <asp:LinkButton ID="lbtnKodePengirimmulai" runat="server" Text="Kode Pengirim Mulai"
                                                                    CausesValidation="False"></asp:LinkButton>
                                                            </td>
                                                            <td width="60%">
                                                                <asp:TextBox ID="txtkodepengirimmulai" runat="server" Width="80%" MaxLength="10"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="10%">
                                                                <asp:LinkButton ID="lbtnkodepengirimsampai" runat="server" Text="Kode Pengirim Sampai"
                                                                    CausesValidation="False"></asp:LinkButton>
                                                            </td>
                                                            <td width="60%">
                                                                <asp:TextBox ID="Txtkodepengirimsampai" runat="server" Width="80%" MaxLength="10"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </asp:Panel>
                                            <!--Tindakan-->
                                            <asp:Panel ID="Pd30" runat="server" Visible="False">
                                                TINDAKAN
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnTindakanmulai" runat="server" CausesValidation="False" Text="Kode Tindakan Mulai"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtkodetindakanmulai" runat="server" MaxLength="10" Width="80%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnTindakansampai" runat="server" CausesValidation="False" Text="Kode Tindakan Sampai"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="TxtkodeTindakansampai" runat="server" MaxLength="10" Width="80%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!--BANK-->
                                            <asp:Panel ID="Pd31" runat="server" Visible="False">
                                                BANK
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnBankmulai" runat="server" CausesValidation="False" Text="Kode Bank Mulai"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtkodebankmulai" runat="server" MaxLength="10" Width="80%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnbanksampai" runat="server" CausesValidation="False" Text="Kode Bank Sampai"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="Txtkodebanksampai" runat="server" MaxLength="10" Width="80%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!--Morfologi-->
                                            <asp:Panel ID="Pd32" runat="server" Visible="False">
                                                MORFOLOGI
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnMorfologimulai" runat="server" CausesValidation="False" Text="Kode Morfologi Mulai"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtmorfologimulai" runat="server" MaxLength="10" Width="80%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnmorfologisampai" runat="server" CausesValidation="False"
                                                                Text="Kode morfologi Sampai"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="Txtmorfologisampai" runat="server" MaxLength="10" Width="80%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!--Penunjang Medis -->
                                            <asp:Panel ID="Pd33" runat="server" Visible="False">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td colspan="2" class="rheaderexpable" style="height: 24">
                                                            Penunjang Medis
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnPenunjangMedismulai" runat="server" CausesValidation="False"
                                                                Text="Kode Penunjang Medis Mulai"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtpenunjangmedismulai" runat="server" MaxLength="10" Width="80%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnpenunjangmedissampai" runat="server" CausesValidation="False"
                                                                Text="Kode Penunjang Medis  Sampai"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="Txtpenunjangmedissampai" runat="server" MaxLength="10" Width="80%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pdPMedisUser" runat="server" Visible="false">
                                                <table width="100%">
                                                    <tr>
                                                        <td colspan="2" class="rheaderexpable" style="height: 24">
                                                            Penunjang Medis
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="20%">
                                                            Penunjang Medis
                                                        </td>
                                                        <td width="60%">
                                                            <asp:DropDownList ID="ddlPMedisUser" runat="server" Width="300px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!--SMF -->
                                            <asp:Panel ID="Pd34" runat="server" Visible="False">
                                                SMF
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnSMFmulai" runat="server" CausesValidation="False" Text="Kode SMF Mulai"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtsmfmulai" runat="server" MaxLength="10" Width="80%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnSMFsampai" runat="server" CausesValidation="False" Text="Kode SMF Sampai"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="Txtsmfsampai" runat="server" MaxLength="10" Width="80%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- Ruang Rawat -->
                                            <asp:Panel ID="Pd35" runat="server" Visible="False">
                                                RUANG RAWAT
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnruangrawatmulai" runat="server" CausesValidation="False"
                                                                Text="Kode Ruang Rawat Mulai"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtruangrawatmulai" runat="server" MaxLength="10" Width="80%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnRuangrawatsampai" runat="server" CausesValidation="False"
                                                                Text="Kode Ruang Rawat Sampai"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="Txtruangrawatsampai" runat="server" MaxLength="10" Width="80%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- kelas -->
                                            <asp:Panel ID="Pd36" runat="server" Visible="False">
                                                KELAS
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnkelasmulai" runat="server" CausesValidation="False" Text="Kode Kelas Mulai"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtKelasmulai" runat="server" MaxLength="10" Width="80%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnkelassampai" runat="server" CausesValidation="False" Text="Kode Kelas Sampai"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="Txtkelassampai" runat="server" MaxLength="10" Width="80%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pd37" runat="server" Visible="False">
                                                TANGGAL
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            Tanggal
                                                        </td>
                                                        <td width="60%">
                                                            <Module:webcal ID="cal" runat="server"></Module:webcal>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pd38" runat="server" Visible="false">
                                                JASA MEDIS
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            Jasa Medis
                                                        </td>
                                                        <td width="60%">
                                                            <asp:DropDownList ID="ddlJasaMedis" runat="server" Width="80%">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pd190" runat="server" Visible="True">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td colspan="2" class="rheaderexpable" style="height: 24">
                                                            App
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            App
                                                        </td>
                                                        <td width="60%">
                                                            <asp:DropDownList ID="ddlPiutangInstansi" runat="server" Width="80%">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- Supplier -->
                                            <asp:Panel ID="Pd40" runat="server" Visible="False">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td colspan="2" class="rheaderexpable">
                                                            Supplier / Pemasok
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnSupplierAwal" runat="server" CausesValidation="False" Text="Supplier dari"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtSupplierAwal" runat="server" MaxLength="10" Width="80%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnSupplierAkhir" runat="server" CausesValidation="False" Text="sampai Supplier"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtSupplierAkhir" runat="server" MaxLength="10" Width="80%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pd43" runat="server" Visible="False">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                        </td>
                                                        <td width="60%">
                                                            <asp:CheckBox ID="chkSemuaSupplier" runat="server" Text="Semua" Checked="False">
                                                            </asp:CheckBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- Supplier -->
                                            <asp:Panel ID="Pd45" runat="server" Visible="False">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnKodeSupplier" runat="server" CausesValidation="False" Text="Supplier"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtKodeSupplier" runat="server" MaxLength="10" AutoPostBack="true"></asp:TextBox>
                                                            <asp:Label ID="lblNamaSupplier" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- Cabang -->
                                            <asp:Panel ID="Pd41" runat="server" Visible="False">
                                                CABANG
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            Cabang
                                                        </td>
                                                        <td width="60%">
                                                            <asp:DropDownList ID="ddlCabangAwal" runat="server" Width="40%">
                                                            </asp:DropDownList>
                                                            s/d
                                                            <asp:DropDownList ID="ddlCabangAkhir" runat="server" Width="40%">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                        </td>
                                                        <td width="60%">
                                                            <asp:CheckBox ID="chkAllCabang" runat="server" Text="Semua" AutoPostBack="true" Checked="False">
                                                            </asp:CheckBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- CheckBox Hanya yang valid -->
                                            <asp:Panel ID="pd42" runat="server" Visible="False">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                        </td>
                                                        <td width="60%">
                                                            <asp:CheckBox ID="chkValid" runat="server" Text="Hanya Mencetak Yang Sudah Divalidasi"
                                                                Checked="False"></asp:CheckBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pd39" runat="server" Visible="false">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            Jenis Transaksi
                                                        </td>
                                                        <td width="60%">
                                                            <asp:DropDownList ID="ddlJenisTransaksi" runat="server" Width="80%">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pd96" runat="server" Visible="False">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            Mata Uang
                                                        </td>
                                                        <td width="60%">
                                                            <asp:DropDownList ID="ddlMataUang" runat="server" Width="60%">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>

                                            <!-- pd46 : Module & Menu awal/akhir -->
                                            <asp:Panel ID="pd46" runat="server" Visible="False">
                                                Module
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            Module
                                                        </td>
                                                        <td width="60%">
                                                            <asp:DropDownList ID="ddlmodule" runat="server" Width="80%" AutoPostBack="True">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnMenuAwal" runat="server" CausesValidation="False" Text="Menu Awal"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtMenuAwal" runat="server" MaxLength="10" Width="80%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnMenuAkhir" runat="server" CausesValidation="False" Text="Menu Akhir"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtMenuAkhir" runat="server" MaxLength="10" Width="80%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>

                                            <asp:Panel ID="pdVoid" runat="server" Visible="False">
                                                <table width="100%" border="0">
                                                    <tr>
                                                        <td width="20%">
                                                            Status :
                                                        </td>
                                                        <td width="60%">
                                                            <asp:DropDownList ID="ddlVoid" runat="server"  Width="20%" AutoPostBack="True">
                                                                <asp:ListItem Value="01">Semua</asp:ListItem>
                                                                <asp:ListItem Value="02">Batal</asp:ListItem>
                                                                <asp:ListItem Value="03">Tidak Batal</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- User //suplier-->
                                            <asp:Panel ID="Pd47" runat="server" Visible="False">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnUser" runat="server" CausesValidation="False" Text="User"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtUser1" runat="server" MaxLength="10" AutoPostBack="true"></asp:TextBox>
                                                            <asp:Label ID="lblUser1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- tarif group-->
                                            <asp:Panel ID="Pd99" runat="server" Visible="False">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtntarifgroupawal" runat="server" CausesValidation="False" Text="Kode Group Awal"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txttarifgroupawal" runat="server" MaxLength="20" AutoPostBack="true"></asp:TextBox>
                                                            <asp:Label ID="lbltarifgroupawal" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtntarifgroupakhir" runat="server" CausesValidation="False"
                                                                Text="Kode Group Akhir"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txttarifgroupakhir" runat="server" MaxLength="20" AutoPostBack="true"></asp:TextBox>
                                                            <asp:Label ID="lbltarifgroupakhir" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- tarif group awal dan akhir-->
                                            <asp:Panel ID="Pd90" runat="server" Visible="False">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtntarifgroup" runat="server" CausesValidation="False" Text="Kode Group"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txttarifgroup" runat="server" MaxLength="20" AutoPostBack="true"></asp:TextBox>
                                                            <asp:Label ID="lbltarifgroup" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- test group-->
                                            <asp:Panel ID="Pd87" runat="server" Visible="False">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnTestgroup" runat="server" CausesValidation="False" Text="Kode Test Group"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="txtTestgroup" runat="server" MaxLength="20" AutoPostBack="true"></asp:TextBox>
                                                            <asp:Label ID="lblTestgroup" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- Authorization TYPE (By User/By Module) -->
                                            <asp:Panel ID="pd49" runat="server" Visible="false">
                                                <table id="Table3" width="100%">
                                                    <tr>
                                                        <td width="10%">
                                                        </td>
                                                        <td width="60%">
                                                            <asp:RadioButtonList ID="rbAuthorizationType" runat="server">
                                                                <asp:ListItem Value="ByUser" Selected="True">ByUser</asp:ListItem>
                                                                <asp:ListItem Value="ByModule">ByModule</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pd50" runat="server" Visible="False">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                        </td>
                                                        <td width="60%">
                                                            <asp:CheckBox ID="chkLunas" runat="server" Text="Hanya Mencetak Yang Belum Lunas"
                                                                Checked="False"></asp:CheckBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- pd60: periode dengan menggunakan dropdownlist dan hanya bulan dan tahun -->
                                            <asp:Panel ID="pd60" runat="server" Visible="false">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                        </td>
                                                        <td width="70%">
                                                            Bulan
                                                            <asp:DropDownList ID="ddlBulan" runat="server">
                                                            </asp:DropDownList>
                                                            &nbsp;&nbsp; Tahun
                                                            <asp:DropDownList ID="ddlTahun" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!--pd61: ddlthn -->
                                            <asp:Panel ID="pd61" runat="server" Visible="false">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="30%">
                                                        </td>
                                                        <td width="60%">
                                                            Tahun
                                                            <asp:DropDownList ID="ddlthn" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- pd62: periode dengan menggunakan dropdownlist dan hanya bulan dan tahun -->
                                            <asp:Panel ID="pd62" runat="server" Visible="false">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                        </td>
                                                        <td width="70%">
                                                            Bulan
                                                            <asp:DropDownList ID="ddlBln1" runat="server">
                                                            </asp:DropDownList>
                                                            &nbsp;&nbsp; Tahun
                                                            <asp:DropDownList ID="ddlThn1" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                        </td>
                                                        <td width="70%">
                                                            Bulan
                                                            <asp:DropDownList ID="ddlBln2" runat="server">
                                                            </asp:DropDownList>
                                                            &nbsp;&nbsp; Tahun
                                                            <asp:DropDownList ID="ddlThn2" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- CheckBox AllPending -->
                                            <asp:Panel ID="pdchkAllPending" runat="server" Visible="False">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                        </td>
                                                        <td width="60%">
                                                            <asp:CheckBox ID="chkAllPending" runat="server" Text="All Pending" Checked="False">
                                                            </asp:CheckBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- Dokter -->
                                            <asp:Panel ID="pd64" runat="server" Visible="False">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td colspan="2" class="rheaderexpable">
                                                            Dokter
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:LinkButton ID="lbtnkddokter" runat="server" CausesValidation="False" Text="Dokter"></asp:LinkButton>
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox ID="TxtKddokter" runat="server" MaxLength="10" AutoPostBack="true"></asp:TextBox>
                                                            <asp:Label ID="Lblnmdokter" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="30%">
                                                        </td>
                                                        <td width="60%">
                                                            <asp:CheckBox ID="chkAllDok" runat="server" Text="Semua Dokter" Checked="False">
                                                            </asp:CheckBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- REPORT TYPE (semua/sudah/belum) -->
                                            <asp:Panel ID="pd48" runat="server" Visible="false">
                                                <table id="Table1" width="100%">
                                                    <tr>
                                                        <td colspan="2" class="rheaderexpable" style="height: 24">
                                                            Kondisi Piutang
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                        </td>
                                                        <td width="60%">
                                                            <asp:RadioButtonList ID="rbReportTypeSSB" runat="server">
                                                                <asp:ListItem Value="semua" Selected="True">Semua</asp:ListItem>
                                                                <asp:ListItem Value="sudah">Sudah</asp:ListItem>
                                                                <asp:ListItem Value="belum">Belum</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- REPORT TYPE tanda terima (Lampiran) -->
                                            <asp:Panel ID="Pd51" runat="server" Visible="False">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td align="left" colspan="2">
                                                            LAMPIRAN
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                        </td>
                                                        <td width="60%">
                                                            <asp:CheckBox ID="StrukLengkap" runat="server" Text="Struk Lengkap" AutoPostBack="true"
                                                                Checked="False"></asp:CheckBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                        </td>
                                                        <td width="60%">
                                                            <asp:CheckBox ID="ResumeMedis" runat="server" Text="Resume Medis" AutoPostBack="true"
                                                                Checked="False"></asp:CheckBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                        </td>
                                                        <td width="60%">
                                                            <asp:CheckBox ID="SuratJaminan" runat="server" Text="Surat Jaminan" AutoPostBack="true"
                                                                Checked="False"></asp:CheckBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                        </td>
                                                        <td width="60%">
                                                            <asp:CheckBox ID="SuratInformasiPenagihanPiutang" runat="server" Text="Surat Informasi Penagihan Piutang"
                                                                AutoPostBack="true" Checked="False"></asp:CheckBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                        </td>
                                                        <td width="60%">
                                                            <asp:CheckBox ID="KwitansiAsli" runat="server" Text="Kwitansi Asli" AutoPostBack="true"
                                                                Checked="False"></asp:CheckBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%">
                                                        </td>
                                                        <td width="60%">
                                                            <asp:CheckBox ID="RincianSelisihBiayaKamarPerKelas" runat="server" Text="Rincian Selisih Biaya Kamar / Kelas"
                                                                AutoPostBack="true" Checked="False"></asp:CheckBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- REPORT TYPE (Asc/Desc) -->
                                            <asp:Panel ID="pd22" runat="server" Visible="false">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                        </td>
                                                        <td width="60%">
                                                            <asp:RadioButtonList ID="AscDesc" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Value="Asc" Selected="True">Ascending</asp:ListItem>
                                                                <asp:ListItem Value="Desc">Descending</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pd55" runat="server" Visible="False">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                            Signature
                                                        </td>
                                                        <td width="60%">
                                                            <asp:DropDownList ID="ddlSignature" runat="server" Width="80%">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- REPORT TYPE (Sudah Dibayar/Belum Dibayar) -->
                                            <asp:Panel ID="pd89" runat="server" Visible="false">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                        </td>
                                                        <td width="60%">
                                                            <asp:RadioButtonList ID="DIBAYAR" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Value="1" Selected="True">Sudah Dibayar</asp:ListItem>
                                                                <asp:ListItem Value="0">Belum Dibayar</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <!-- REPORT TYPE (SUMMARY/DETAIL) -->
                                            <asp:Panel ID="pd18" runat="server" Visible="false">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                        </td>
                                                        <td width="60%">
                                                            <asp:RadioButtonList ID="rbReportType" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Value="Summary" Selected="True">Rekap</asp:ListItem>
                                                                <asp:ListItem Value="Detail">Detil</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pdExternal" runat="server" Visible="False">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td width="10%">
                                                        </td>
                                                        <td width="60%">
                                                            <asp:CheckBox ID="Chkformat" runat="server" Text="Untuk External"></asp:CheckBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="pdTagihan" runat="server" Visible="False">
                                                <table width="100%" cellpadding="2">
                                                    <tr>
                                                        <td colspan="2" class="rheaderexpable">
                                                            Nilai Tagihan
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="30%">
                                                            Jumlah tagihan lebih dari
                                                        </td>
                                                        <td width="60%">
                                                            <asp:TextBox runat="server" ID="txtTagihanMin" Width="200" CssClass="right" Text="0"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                              <asp:Panel ID="pdJnsTransaksi" runat="server" Visible="false">
                                                <table width="100%" cellpadding="2">
                                                    <p>
                                                        <tbody>
                                                            <tr>
                                                                <td valign="top" width="20%">
                                                                    Jenis Transaksi :
                                                                </td>
                                                                <td valign="top" width="60%">
                                                                    <asp:CheckBoxList ID="chkJnsTrans" runat="server">
                                                                        <asp:ListItem Value="" Selected="True">Semua</asp:ListItem>
                                                                        <asp:ListItem Value="01" Selected="True">Valid</asp:ListItem>
                                                                        <asp:ListItem Value="02" Selected="True">Batal</asp:ListItem>
                                                                    </asp:CheckBoxList>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </p>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                   
                                    <tr style="display: none">
                                        <td>
                                            <table width="100%" cellpadding="2">
                                                <tr>
                                                    <td align="left" width="20">
                                                        <asp:Button class="sbttn" ID="btnPreview1" runat="server" Text="  Print.."></asp:Button>
                                                    </td>
                                                    <td align="right" width="*">
                                                        <input class="sbttn" onclick="window.close();" type="button" value="Close">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
