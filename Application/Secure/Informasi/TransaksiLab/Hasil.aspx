<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../../../incl/RadMenu.ascx" %>
<%--<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../../../incl/CSSToolbar.ascx" %>--%>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Hasil.aspx.vb"
    Inherits="QIS.Web.Secure.HasilLab" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Hasil Pemeriksaan Laboratorium</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1" />
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <meta http-equiv="refresh" content="600" />
    <link href='/qistoollib/css/styles.css' type="text/css" rel="Stylesheet" />
<%--
    <script src='/qislib/scripts/MD_/md___Dlg_rs-v2.js' language="javascript"></script>

    <link href="/qislib/calendar/calWebStyles_V40.css" rel="stylesheet" />

    <script src='<%= UrlBase + "/JSDLGGlobalVar.aspx" %>' language="javascript"></script>--%>

</head>
<body ms_positioning="GridLayout">
    <form id="frmHasilLab" runat="server">
    <table border="0" width="100%" style="height: 100%;" cellspacing="0" cellpadding="2">
        <tr>
        </tr>
        <tr>
            <td width="100%" style="height: 100%;" valign="top">
                <div style="width: 100%; height: 100%; overflow: auto;">
                    <table cellspacing="10" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td align="left">
                                <asp:Panel ID="pnl_1" runat="server">
                                    <table cellspacing="0" cellpadding="5" width="100%">
                                        <tr class="rheader">
                                            <td class="rheadercol" align="left" height="25">
                                                Hasil Pemeriksaan Laboratorium
                                            </td>
                                        </tr>
                                        <tr class="rbody">
                                            <td class="rbodycol" align="center" height="25">
                                                <div style="overflow: auto; width: 100%">
                                                    <table cellspacing="0" cellpadding="5" width="100%">
                                                        <tr>
                                                            <td width="100%">
                                                                <asp:datagrid id="gridDetail" runat="server" autogeneratecolumns="False" cellspacing="0"
                                                                    bordercolor="Gainsboro" borderwidth="1" gridlines="Horizontal" height="100%"
                                                                    width="100%" datakeyfield="kdfraction" showfooter="True" cellpadding="0" allowsorting="True">				
                                                                    <HeaderStyle CssClass="gridHeaderStyle" />
                                                                    <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                    <EditItemStyle Font-Bold="false" />
                                                                    <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
				                                                    <Columns>
					                                                    <asp:TemplateColumn runat="server" HeaderText="Counter" visible="false">
						                                                    <itemtemplate>
							                                                    <asp:label runat="server" style="margin-left:5;margin-right:5" Text='<%# DataBinder.Eval(Container.DataItem, "counter") %>' ID="_lblcounter" />
						                                                    </itemtemplate>
					                                                    </asp:TemplateColumn>
					                                                    <asp:TemplateColumn runat="server" HeaderText="No. Transaksi" Visible="False">
						                                                    <itemtemplate>
							                                                    <asp:label runat="server" style="margin-left:5;margin-right:5" Text='<%# DataBinder.Eval(Container.DataItem, "nolab") %>' ID="_lblNoTransaksi"/>
						                                                    </itemtemplate>
					                                                    </asp:TemplateColumn>
					                                                    <asp:templatecolumn runat="server" HeaderText="Kode Test">
						                                                    <itemtemplate>
							                                                    <asp:label runat="server" style="margin-left:5;margin-right:5" Text='<%# DataBinder.Eval(Container.DataItem, "kdtest") %>' ID ="_lblkdtest" />
						                                                    </itemtemplate>
					                                                    </asp:templatecolumn>
					                                                    <asp:TemplateColumn runat="server" HeaderText="Kode Fraction">
						                                                    <itemtemplate>
							                                                    <asp:label runat="server" style="margin-left:5;margin-right:5" Text='<%# DataBinder.Eval(Container.DataItem, "kdfraction") %>' ID="lblKdFraction"/>
						                                                    </itemtemplate>
					                                                    </asp:TemplateColumn>
					                                                    <asp:TemplateColumn runat="server" HeaderText="Nama Fraction">
						                                                    <itemtemplate>
							                                                    <asp:label runat="server" style="margin-left:5;margin-right:5" Text='<%# DataBinder.Eval(Container.DataItem, "nmfraction") %>' ID="_lblNmFraction"/>
						                                                    </itemtemplate>
					                                                    </asp:TemplateColumn>
					                                                    <asp:TemplateColumn runat="server" HeaderText="Hasil Value" Visible="True">
						                                                    <itemtemplate>
							                                                    <asp:label runat="server" style="margin-left:5;margin-right:5" Text='<%# DataBinder.Eval(Container.DataItem, "nhasil") %>' ID="_lblNHasil"/>
						                                                    </itemtemplate>
					                                                    </asp:TemplateColumn>
					                                                    <asp:TemplateColumn runat="server" HeaderText="Hasil Text" Visible="True">
						                                                    <itemtemplate>
							                                                    <asp:label runat="server" style="margin-left:5;margin-right:5" Text='<%# DataBinder.Eval(Container.DataItem, "chasil") %>' ID="_lblCHasil"/>
						                                                    </itemtemplate>
					                                                    </asp:TemplateColumn>
					
						                                                    <asp:TemplateColumn												
												                                                    runat="server"
												                                                    HeaderText="Petugas" 
												                                                    HeaderStyle-HorizontalAlign="Right" 
												                                                    ItemStyle-HorizontalAlign="Right"> 
							                                                    <itemtemplate>
								                                                    <asp:label		runat="server" 
												                                                    style="margin-left:5;margin-right:5"
												                                                    Text='<%# DataBinder.Eval(Container.DataItem, "updater") %>' 
												                                                    ID="_lblPetugas"/>
							                                                    </itemtemplate>
						                                                    </asp:TemplateColumn >
					
				                                                    </Columns>
			                                                    </asp:datagrid>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <!--GRID END HERE-->
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
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
