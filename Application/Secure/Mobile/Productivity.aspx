<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../incl/copyright.ascx" %>


<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Productivity</title>
    <link rel="title icon" href="/qistoollib/images/favicon.png" />
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href='/qistoollib/css/styles_blue.css' type="text/css" rel="Stylesheet" />
    <script type="text/javascript" language="javascript" src='/qistoollib/scripts/common/common.js'></script>
    <style type="text/css">
        .bodyText 
            {
                background-color: #ffffff;
                color: #000000;
                font-size: 12pt;
            }
    </style>
</head>
<body>
    <form id="frm" runat="server">
    <table border="0" width="100%" cellspacing="1" cellpadding="1">
        <tr>
            <td width="100%" valign="top">
                <!-- BEGIN PAGE HEADER -->
                
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
                                            Productivity Summary
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="hseparator" style="width: 100%;">
                                        </td>
                                    </tr>
                                    <tr class="rbody">
                                        <td valign="top">
                                            <table width="100%">
                                                <!-- PAGE CONTENT BEGIN HERE -->
                                                <tr>
                                                    <td style="width: 50%;">
                                                        <table width="100%" cellspacing="1" cellpadding="0" class="rheaderexpable">
                                                            <tr>
                                                                <td style="width: 100%;" class="rheaderexpable center">
                                                                    OPEN
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100%;" class="bodyText center">
                                                                    <table cellspacing="1" class="rheaderexpable center" width="100%">
                                                                        <tr>
                                                                            <td style="width: 50%;" class="bodyText center">
                                                                                <asp:Label ID="lblSummaryOPEN" runat="server" Text="150"></asp:Label>
                                                                            </td>    
                                                                            <td style="width: 50%;" class="bodyText center">
                                                                                <asp:Label ID="lblSummaryOPENpct" runat="server" Text="35%"></asp:Label>
                                                                            </td>    
                                                                        </tr>
                                                                    </table>                                                                    
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td style="width: 50%;">
                                                        <table width="100%" cellspacing="1" cellpadding="0" class="rheaderexpable">
                                                            <tr>
                                                                <td style="width: 100%;" class="rheaderexpable center">
                                                                    IN PROGRESS
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100%;" class="bodyText center">
                                                                    <table cellspacing="1" class="rheaderexpable center" width="100%">
                                                                        <tr>
                                                                            <td style="width: 50%;" class="bodyText center">
                                                                                <asp:Label ID="Label1" runat="server" Text="150"></asp:Label>
                                                                            </td>    
                                                                            <td style="width: 50%;" class="bodyText center">
                                                                                <asp:Label ID="Label2" runat="server" Text="35%"></asp:Label>
                                                                            </td>    
                                                                        </tr>
                                                                    </table>                                                                    
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 50%;">
                                                        <table width="100%" cellspacing="1" cellpadding="0" class="rheaderexpable">
                                                            <tr>
                                                                <td style="width: 100%;" class="rheaderexpable center">
                                                                    NEED SAMPLE
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100%;" class="bodyText center">
                                                                    <table cellspacing="1" class="rheaderexpable center" width="100%">
                                                                        <tr>
                                                                            <td style="width: 50%;" class="bodyText center">
                                                                                <asp:Label ID="Label3" runat="server" Text="150"></asp:Label>
                                                                            </td>    
                                                                            <td style="width: 50%;" class="bodyText center">
                                                                                <asp:Label ID="Label4" runat="server" Text="35%"></asp:Label>
                                                                            </td>    
                                                                        </tr>
                                                                    </table>                                                                    
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td style="width: 50%;">
                                                        <table width="100%" cellspacing="1" cellpadding="0" class="Menu_Gray">
                                                            <tr>
                                                                <td style="width: 100%;" class="Menu_Gray center">
                                                                    FINISH
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100%;" class="bodyText center">
                                                                    <table cellspacing="1" class="Menu_Gray center" width="100%">
                                                                        <tr>
                                                                            <td style="width: 50%;" class="bodyText center">
                                                                                <asp:Label ID="Label5" runat="server" Text="150"></asp:Label>
                                                                            </td>    
                                                                            <td style="width: 50%;" class="bodyText center">
                                                                                <asp:Label ID="Label6" runat="server" Text="35%"></asp:Label>
                                                                            </td>    
                                                                        </tr>
                                                                    </table>                                                                    
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
</body>
</html>
