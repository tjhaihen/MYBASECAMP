<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Aktiva.aspx.vb" Inherits="QIS.Web.Aktiva" %>

<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../../incl/calendar.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Aset Register</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href='/qistoollib/css/styles.css' type="text/css" rel="Stylesheet">

    <script src='/qistoollib/scripts/gl_/gl___dlg_rs-v2.js' language="javascript"></script>

    <script src='/qistoollib/scripts/common/util.js' language="javascript"></script>

    <script src='<%= UrlBase + "/JSDLGGlobalVar.aspx" %>' language="javascript"></script>

    <script language="javascript">
        function Done() {
            var url = '<%= UrlBase + "/secure/Master/fa/Assets/SelItem.aspx" %>';
            window.location.href = url;
        }
    </script>

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
            <td width="100%" valign="top">
                <Module:CSSToolbar ID="CSSToolbar" runat="server"></Module:CSSToolbar>
            </td>
        </tr>
        <tr>
            <td width="100%" valign="top" style="height: 100%;">
                <div style="width: 100%; height: 100%; overflow: auto;">
                    <table cellspacing="10" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td align="left">
                                <table cellspacing="0" cellpadding="5" width="100%">
                                    <%--<tr class="rheader">
                                        <td class="rheadercol" align="left" height="25" colspan="2">
                                            <a href="javascript:Done();">
                                                <img src="/qislib/images/back.png" alt="Kembali ke halaman Daftar Aktiva Tetap" align="absmiddle" border="0" />
                                            </a>
                                            &nbsp;&nbsp;
                                            Detil Aktiva Tetap
                                        </td>
                                    </tr>--%>
                                    <tr class="rbody">
                                        <td class="rbodycol" align="middle" height="25" colspan="2">
                                            <table width="100%">
                                                <!-- PAGE CONTENT BEGIN HERE -->
                                                <tr class="rbody">
                                                    <td class="rbodycol" align="middle" height="25">
                                                        <table width="100%">
                                                            <tr>
                                                                <td>
                                                                    <!-- BEGIN ADDNEW ROW -->
                                                                    <!-- #include file="Aktiva_AddNewRow.incl.aspx" -->
                                                                    <!-- END ADDNEW ROW -->
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr class="rbody">
                                                    <td class="rbodycol" align="middle" height="25">
                                                        <table width="100%">
                                                            <tr>
                                                                <td colspan="2">
                                                                    <!-- BEGIN DATA GRID -->
                                                                    <!-- #include file="Aktiva_DataGrid.incl.aspx" -->
                                                                    <!-- END DATA GRID -->
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

    <script src='/qislib/scripts/common/FormatNumber.js' language="javascript"></script>

    <script src='/qislib/scripts/common/common.vbs' language="vbscript"></script>

</body>
</html>
