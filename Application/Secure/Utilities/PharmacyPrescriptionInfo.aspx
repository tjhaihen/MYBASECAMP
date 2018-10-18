<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../incl/copyright.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PharmacyPrescriptionInfo.aspx.vb"
    Inherits="QIS.Web.Secure.PharmacyPrescriptionInfo" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Pharmacy Prescription Information</title>
    <link rel="title icon" href="/qistoollib/images/favicon.png" />
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta http-equiv="refresh" content="600">
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href='/qistoollib/css/styles_custom.css' type="text/css" rel="Stylesheet" />
    <script language="javascript" type="text/javascript" src="/qistoollib/scripts/JScript.js"></script>
    <script type="text/javascript" language="javascript" src='/qistoollib/scripts/common/common.js'></script>
    <style type="text/css">
        #container {
    
        }
        #bottomline {
            position: absolute;
            bottom: 10;
        }
        #ulrepSpecialty
        {
            width: 100%;
            margin: 0;
            padding: 0;                                           
        }
        #ulrepSpecialty li
        {
            list-style-type: none;
            display: inline-block; /* FF3.6; Chrome10+ */                     
            *display: inline;
            width: 100%;
            margin: 1px;
        }
        #ulrepSpecialtySum
        {
            width: 100%;
            margin: 0;
            padding: 0;                                                       
        }
        #ulrepSpecialtySum li
        {
            list-style-type: none;
            margin: 1px;
            vertical-align: top;
        }
        #ulRepPhysician
        {
            width: 100%;
            margin: 0 0 5 0;
            padding: 0;                                           
        }
        div#multicolumn 
        {
            -moz-column-count: 3;
            -moz-column-gap: 10px;
            -webkit-column-count: 3;
            -webkit-column-gap: 10px;
            column-count: 3;
            column-gap: 10px;
        }
    </style>
</head>
<body>
    <form id="frm" runat="server" style="background-image: url('/qistoollib/images/background.png');">
    <table border="0" width="100%" cellspacing="2" cellpadding="1" height="100%">
        <tr>
            <td width="100%" valign="top">
            </td>
        </tr>
        <tr>
            <td width="100%" height="100%" valign="top">
                <table cellspacing="2" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td class="rheader" colspan="2">
                            <table width="100%" style="font-family: Dekar, Arial, Tahoma;">
                                <td style="width: 60;" valign="middle">
                                    <img src="/qistoollib/images/clientCompanyLogo.png" width="50" alt="" border="" />
                                </td>
                                <td style="font-size: 20pt; font-family: Dekar, Arial, Tahoma; color: #004F7B;" valign="middle">
                                    <asp:Label ID="lblCompanyName" runat="server"></asp:Label><br />
                                    <asp:Label ID="lblCompanyAddress" runat="server" Font-Size="Medium"></asp:Label>
                                </td>
                                <td class="rheader" style="text-align: right; font-size: 24pt;" valign="middle">
                                    <asp:Label ID="lblPageTitle" runat="server" Text="INFORMASI STATUS RESEP"></asp:Label>
                                </td>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="hseparator" style="width: 100%;" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 50%;" valign="middle">
                            <asp:ImageButton ID="ibtnSummary" runat="server" ImageUrl="/qistoollib/images/ico-summary.png"
                                ToolTip="Informasi Jadwal Dokter Hari Ini" Width="32" ImageAlign="AbsMiddle" />
                            <asp:ImageButton ID="ibtnDetail" runat="server" ImageUrl="/qistoollib/images/ico-detail.png"
                                ToolTip="Informasi Jadwal Dokter" Width="32" ImageAlign="AbsMiddle" />
                            <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="/qistoollib/images/ico-edit.png"
                                ToolTip="Edit Informasi Jadwal Dokter" Width="32" ImageAlign="AbsMiddle" />
                        </td>
                        <td class="rheader" style="width: 50%; text-align: right; font-size: 18pt;">
                            <asp:Label ID="lblDateTime" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="hseparator" style="width: 100%;" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="left" colspan="2">
                            <asp:Panel ID="pnlSummary" runat="server">
                                <div id="container">
                                    <div id="multicolumn">
                                        Kolom untuk daftar resep pasien yang sudah selesai dan siap diambil
                                    </div>
                                    <div id="bottomline" style="width: 100%;">
                                        <table width="100%">
                                            <tr>
                                                <td class="hseparator" style="width: 100%;" colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <marquee direction="left"><asp:Label ID="lblScrollingText" runat="server" Text="THIS IS SCROLLING TEXT..." Font-Bold="true" Font-Size="Large"></asp:Label></marquee>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlDetail" runat="server">
                                
                            </asp:Panel>
                            <asp:Panel ID="pnlEdit" runat="server">
                                
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
