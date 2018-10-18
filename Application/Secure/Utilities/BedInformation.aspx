<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../incl/copyright.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BedInformation.aspx.vb"
    Inherits="QIS.Web.Secure.BedInformation" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Bed Information</title>
    <link rel="title icon" href="/qistoollib/images/favicon.png" />
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href='/qistoollib/css/styles_blue.css' type="text/css" rel="Stylesheet" />
    <script language="javascript" type="text/javascript" src="/qistoollib/scripts/JScript.js"></script>
    <script type="text/javascript" language="javascript" src='/qistoollib/scripts/common/common.js'></script>
    <script>
        (function () {
            'use strict';

            var dbh, sto, num = 50, temp = 0, scrolldelay = 100;

            function init() {
                dbh = document.body.offsetHeight;
                pageScroll();
            }

            function pageScroll() {
                window.scrollBy(0, 1);
                scrolldelay = setTimeout(pageScroll, 120);                
            }
            window.addEventListener ?
            window.addEventListener('load', init, false) :
            window.attachEvent('onload', init);
        })();

        window.onscroll = function (ev) {
            if ((window.innerHeight + window.scrollY) >= document.body.offsetHeight) {
                window.scrollTo(0, 0);
            }
        };

        setTimeout(function () {
            window.location.reload(1);            
        }, 60000);
    </script>
    <style type="text/css">
        #ulRepBed
        {
            width: 100%;
            margin: 0;
            padding: 0;                     
        }
        #ulRepBed li
        {
            list-style-type: none;
            display: inline-block; /* FF3.6; Chrome10+ */                     
            *display: inline;
            background: #eeeeee;
            width: 150px;
            height: 46px;
        }
        #ulRepRoom
        {
            width: 100%;
            margin: 0;            
            padding: 0;                                            
        }
        #ulRepRoom li
        {
            list-style-type: none;            
        }
    </style>
</head>
<body>
    <form id="frm" runat="server" style="background-image: url('/qistoollib/images/background.png');">
    <table border="0" width="100%" cellspacing="2" cellpadding="1">
        <tr>
            <td width="100%" valign="top">
            </td>
        </tr>
        <tr>
            <td width="100%" height="100%" valign="top">
                <table cellspacing="10" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td class="rheader" colspan="2">
                            <table width="100%" style="font-family: Dekar, Arial, Tahoma;">
                                <td style="width: 100;">
                                    <img src="/qistoollib/images/clientCompanyLogo.png" width="40" alt="" border="" />
                                </td>
                                <td style="font-size: 24pt;">
                                    <asp:Label ID="lblCompanyName" runat="server"></asp:Label>
                                </td>
                                <td class="rheader" style="text-align: right; font-size: 24pt;">
                                    INFORMASI TEMPAT TIDUR
                                </td>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="hseparator" style="width: 100%;" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 50%; text-align: left; font-size: 14pt;">
                            <asp:Label ID="lblCompanyAddress" runat="server"></asp:Label>
                        </td>
                        <td style="width: 50%; text-align: right; font-size: 14pt;">
                            <asp:Label ID="lblDateTime" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="hseparator" style="width: 100%;" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2">
                            <asp:Repeater ID="repRoom" runat="server" OnItemDataBound="repRoom_ItemDataBound">
                                <HeaderTemplate>
                                    <ul id="ulRepRoom">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <table cellspacing="1" width="100%">
                                            <tr>
                                                <td valign="middle" class="Heading3" style="width: 80%; height: 30; background-color: #A1C934;
                                                    opacity: 0.7; padding-left: 10; font-size: 16pt;">
                                                    <%# DataBinder.Eval(Container.DataItem, "RoomName")%>
                                                </td>
                                                <td style="background-image: url('/qistoollib/images/timeline_dot.png'); background-repeat: repeat-x;">
                                                </td>
                                                <td class="center" style="width: 400; height: 30; background-color: #666666; font-size: 18pt;">
                                                    <table cellspacing="1" class="gridHeaderStyle">
                                                        <tr>
                                                            <td style="width: 100; background-color: #666666; color: #ffffff;" class="center">
                                                                TOTAL
                                                            </td>
                                                            <td style="width: 100; background-color: #666666; color: #ffffff;" class="center">
                                                                TERSEDIA
                                                            </td>
                                                            <td style="width: 100; background-color: #666666; color: #ffffff;" class="center">
                                                                DIBERSIHKAN
                                                            </td>
                                                            <td style="width: 100; background-color: #666666; color: #ffffff;" class="center">
                                                                TERISI
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="background: #333333; color: #ffffff; font-size: 16pt;" class="center">
                                                                <asp:Label ID="lblTotalByRoom" runat="server"></asp:Label>
                                                            </td>
                                                            <td style="background: #1F872E; color: #ffffff; font-size: 16pt;" class="center">
                                                                <asp:Label ID="lblTotalKOSONGByRoom" runat="server"></asp:Label>
                                                            </td>
                                                            <td style="background: #FF9900; color: #ffffff; font-size: 16pt;" class="center">
                                                                <asp:Label ID="lblTotalDIBERSIHKANByRoom" runat="server"></asp:Label>
                                                            </td>
                                                            <td style="background: #FF0000; color: #ffffff; font-size: 16pt;" class="center">
                                                                <asp:Label ID="lblTotalTERISIByRoom" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:Repeater ID="repBed" runat="server" OnItemDataBound="repBed_ItemDataBound">
                                                        <HeaderTemplate>
                                                            <ul id="ulRepBed">
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <li>
                                                                <table cellspacing="0" width="100%">
                                                                    <tr>
                                                                        <td style="width: 60%; background-color: #333333;">
                                                                            <asp:Panel ID="pnlHEXColorRoom" runat="server" Width="100%" BackColor="#333333">
                                                                                <table width="100%" style="height: 46px; color: #ffffff; text-align: center;">
                                                                                    <tr>
                                                                                        <td valign="middle">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "ClassName") %>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </asp:Panel>
                                                                        </td>
                                                                        <td style="width: 40%; text-align: right; background-color: #333333;">
                                                                            <asp:Panel ID="pnlHEXColorGender" runat="server" Width="100%" BackColor="#666666">
                                                                                <table width="100%" style="height: 46px; color: #ffffff; text-align: center;">
                                                                                    <tr>
                                                                                        <td valign="middle">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "BedNo") %>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </asp:Panel>
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
                                            <tr>
                                                <td colspan="3" style="height: 15;">
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
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
