<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../incl/copyright.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Documents.aspx.vb" Inherits="QIS.Web.Secure.Documents" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Documents</title>
    <link rel="title icon" href="/qistoollib/images/favicon.png" />
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href="/qistoollib/css/styles_blue.css" type="text/css" rel="Stylesheet" />
    <script language="javascript" type="text/javascript" src="/qistoollib/scripts/JScript.js"></script>
    <style type="text/css">
        #ulRepDocumentType
        {
            width: 100%;
            margin: 0;
            padding: 0;                     
        }
        #ulRepDocumentType li
        {
            list-style-type: none;            
        }
        #ulrepDocuments
        {
            width: 100%;
            margin: 0;
            padding: 0;                     
        }
        #ulrepDocuments li
        {
            list-style-type: none;
            display: inline-block; /* FF3.6; Chrome10+ */                     
            *display: inline;
            border-radius: 5px;
            background: #eeeeee;
            width: 220px;
            height: 120px;
            margin: 5px;
        }
    </style>
</head>
<body>
    <form id="frm" runat="server">
    <table border="0" width="100%" height="100%" cellspacing="2" cellpadding="1">
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
                                        Documents
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
                                                <td>
                                                    <!-- PAGE CONTENT BEGIN HERE -->
                                                    <asp:Repeater ID="repDocumentType" runat="server" OnItemDataBound="repDocumentType_ItemDataBound">
                                                        <HeaderTemplate>
                                                            <ul id="ulRepDocumentType">
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <li>
                                                                <table cellspacing="1" width="100%">
                                                                    <tr>
                                                                        <td class="Heading3" style="width: 300; height: 30; background-color: #A9E2F3;">
                                                                            <%# DataBinder.Eval(Container.DataItem, "caption") %>
                                                                        </td>
                                                                        <td style="background-image: url('/qistoollib/images/timeline_dot.png'); background-repeat: repeat-x;">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <asp:Repeater ID="repDocuments" runat="server">
                                                                                <HeaderTemplate>
                                                                                    <ul id="ulrepDocuments">
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <li>
                                                                                        <table cellspacing="1" width="100%" title='<%# DataBinder.Eval(Container.DataItem, "fileName")%>'>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Label ID="_lblDocumentID" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "documentID") %>'></asp:Label>
                                                                                                    <asp:Label ID="_lblFileName" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "fileName") %>'></asp:Label>
                                                                                                    <%# DataBinder.Eval(Container.DataItem, "documentDescription")%>
                                                                                                </td>
                                                                                                <td class="right" valign="top">
                                                                                                    <a href='<%# DataBinder.Eval(Container.DataItem, "fileUrl") %>' target="_blank" title="Download File">
                                                                                                        <img src="/qistoollib/images/attachment_download.png" border="0" align="middle" alt="Download File" />
                                                                                                    </a>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="txtweak" colspan="2">
                                                                                                    File type&nbsp;<%# DataBinder.Eval(Container.DataItem, "fileExtension")%>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="txtweak" colspan="2">
                                                                                                    Upload date:&nbsp;<%# Format(DataBinder.Eval(Container.DataItem, "insertDate"), "dd-MMM-yyyy HH:mm") %>
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
                                                                    </tr>
                                                                </table>
                                                            </li>
                                                        </ItemTemplate>
                                                    </asp:Repeater>                                                    
                                                    <!-- PAGE CONTENT END HERE -->
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
