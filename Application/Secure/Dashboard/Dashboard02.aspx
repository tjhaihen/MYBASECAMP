<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../incl/copyright.ascx" %>
<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Calendar" Src="../../incl/calendar.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../../incl/CSSToolbar.ascx" %>


<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>--%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Medinfras Basecamp - Weekly Activity</title>
    <link rel="title icon" href="/qistoollib/images/favicon.png" />
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href="/qistoollib/css/styles_blue.css" type="text/css" rel="Stylesheet" />
    <script language="javascript" type="text/javascript" src="/qistoollib/scripts/JScript.js"></script>
    <style type="text/css">
        #ulRepProjects
        {
            width: 100%;
            margin: 0;
            padding: 0;
        }
        #ulRepProjects li
        {
            list-style-type: none;
            display: inline-block; /* FF3.6; Chrome10+ */                     
            *display: inline;
            border-radius: 10px;
            background: #eeeeee;
            width: 320px;
            height: 240px;
            margin: 3px;
            padding: 5px;
        }
        #ulRepMyCalendar
        {
            width: 100%;
            margin: 0;
            padding: 0;
        }
        #ulRepMyCalendar li
        {
            list-style-type: none;            
        }
        #rcorners1 {
          border-radius: 5px;
          background: #b5d0f8;
          color: #000000;
          padding: 5px;
        }
        #rcorners2 {
          border-radius: 5px;
          background: #acefe8;
          color: #000000;
          padding: 5px;
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server">
    <table width="100%" cellpadding="2" cellspacing="0">
        <tr>
            <td width="100%" valign="top" colspan="3">
                <!-- BEGIN PAGE HEADER -->
                <Module:RadMenu ID="RadMenu" runat="server" />
                <!-- END PAGE HEADER -->
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 100%;">
                <table width="100%">
                    <tr>
                        <td class="Heading2">
                            <asp:Label ID="lblPageTitle" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="hseparator">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="width: 100%;">
                            <table width="100%" style="background-color: #EEEEEE;" cellspacing="5">
                                <tr>
                                    <td style="background-color: #ffffff;">
                                        Monday
                                    </td>
                                    <td style="background-color: #ffffff;">
                                        Tuesday
                                    </td>
                                    <td style="background-color: #ffffff;">
                                        Wednesday
                                    </td>
                                    <td style="background-color: #ffffff;">
                                        Thursday
                                    </td>
                                    <td style="background-color: #ffffff;">
                                        Friday
                                    </td>
                                    <td style="background-color: #ffffff;">
                                        Saturday
                                    </td>
                                    <td style="background-color: #ffffff;">
                                        Sunday
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="7" class="Heading2" style="background-color: #3498db; color: #ffffff; border-radius: 5px; padding: 5px;">
                                        THIS WEEK
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background-color: #ffffff;">
                                        <div ID="rcorners1">
                                            TEST
                                        </div>
                                    </td>
                                    <td style="background-color: #ffffff;">
                                        
                                    </td>
                                    <td style="background-color: #ffffff;">
                                        
                                    </td>
                                    <td style="background-color: #ffffff;">
                                        
                                    </td>
                                    <td style="background-color: #ffffff;">
                                        
                                    </td>
                                    <td style="background-color: #ffffff;">
                                        
                                    </td>
                                    <td style="background-color: #ffffff;">
                                        
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
