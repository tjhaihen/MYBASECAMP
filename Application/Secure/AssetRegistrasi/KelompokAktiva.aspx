<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../../../../incl/RadMenu.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="KelompokAktiva.aspx.vb"
    Inherits="QIS.Web.Secure.Master.KelompokAktiva" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Sub Kelompok Aktiva Tetap</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href='/qislib/css/styles.css' type="text/css" rel="Stylesheet">

    <script src='/qislib/scripts/gl_/gl___dlg_rs-v2.js' language="javascript"></script>

    <script src='<%= UrlBase + "/JSDLGGlobalVar.aspx" %>' language="javascript"></script>

</head>
<body>
    <form id="frmAssets" runat="server">
    <table border="0" width="100%" cellspacing="0" cellpadding="2" style="height: 100%;">
        <tr>
            <td width="100%" valign="top">
                <!-- BEGIN PAGE HEADER -->
                <Module:RadMenu ID="RadMenu" runat="server" />
                <!-- END PAGE HEADER -->
            </td>
        </tr>
        <tr>
            <td width="100%" valign="top" style="height: 100%;">
                <div style="width: 100%; height: 100%; overflow: auto;">
                    <table cellspacing="10" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td align="left">
                                <table cellspacing="0" cellpadding="5" width="100%">
                                    <tr class="rheader">
                                        <td class="rheadercol" align="left" height="25">
                                            Sub Kelompok Aktiva Tetap
                                        </td>
                                    </tr>
                                    <tr class="rbody">
                                        <td class="rbodycol" align="center" height="25">
                                            <table width="100%">
                                                <!-- PAGE CONTENT BEGIN HERE -->
                                                <tr class="rbody">
                                                    <td class="rbodycol" align="center" height="25">
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <!-- BEGIN ADDNEW ROW -->
                                                                    <!-- #include file="KelompokFa_AddNewRow.incl.aspx" -->
                                                                    <!-- END ADDNEW ROW -->
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <!-- BEGIN ADDNEW ROW -->
                                                                    <!-- #include file="KelompokFa_DataGrid.incl.aspx" -->
                                                                    <!-- END ADDNEWROW -->
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <!-- PAGE CONTENT END HERE -->
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
    </table>
    </form>

    <script src='/qislib/scripts/common/common.js' language="javascript"></script>

    <script src='/qislib/scripts/common/common.vbs' language="vbscript"></script>

</body>
</html>
