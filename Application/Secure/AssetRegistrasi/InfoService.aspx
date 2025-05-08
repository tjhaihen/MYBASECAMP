<%@ Page Language="vb" AutoEventWireup="false" Codebehind="InfoService.aspx.vb" Inherits="QIS.Web.Secure.Master.InfoService" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Info Service Aktiva Tetap</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/qislib/css/styles.css" type="text/css" rel="Stylesheet">
		<script language="javascript" src="/qislib/scripts/gl_/gl___dlg_rs-v2.js"></script>
		<script language="javascript" src="/qislib/scripts/common/util.js"></script>
		<SCRIPT language=javascript src='<%= UrlBase + "/JSDLGGlobalVar.aspx" %>'></SCRIPT>
	</HEAD>
	<BODY>
		<form id="frmAssets" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td vAlign="top" width="100%">
						<table cellSpacing="10" cellPadding="0" width="100%" border="0">
							<tr>
								<td align="left">
									<TABLE cellSpacing="0" cellPadding="5" width="100%">
										<TR class="rheader">
											<TD class="rheadercol" align="left" height="25">AKTIVA TETAP&nbsp;- SERVICE
											</TD>
										</TR>
										<TR class="rbody">
											<TD class="rbodycol" align="left" height="25">
												<P>Halaman ini untuk melihat data service untuk aktiva tetap.
												</P>
											</TD>
										</TR>
										<TR class="rheader">
											<TD class="rheadercol" align="left" height="2"></TD>
										<TR class="rbody">
											<TD class="rbodycol" align="center" height="25"><TABLE width="100%">
													<!-- PAGE CONTENT BEGIN HERE -->
													<TR class="rbody">
														<TD class="rbodycol" align="center" height="25">
															<TABLE width="100%">
																<TR>
																	<TD style="WIDTH: 148px"><asp:linkbutton id="lbtnAktivaTetap" runat="server">Aktiva Tetap</asp:linkbutton></TD>
																	<TD><asp:textbox id="txtKdAktiva" runat="server" Width="230px"></asp:textbox>&nbsp;
																		<asp:textbox id="txtNmAktiva" runat="server" Width="294px"></asp:textbox>&nbsp;&nbsp;<asp:linkbutton id="lbtnGo" runat="server">Refresh</asp:linkbutton></TD>
																	<td align="right">&nbsp;
																		<asp:Button id="btnClose" runat="server" Text="Close" CssClass="sbttn"></asp:Button></td>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR class="rbody">
														<TD class="rbodycol" align="center" height="25">
															<!-- <DIV id="GridAkumulasiFA" style="OVERFLOW: auto; WIDTH: 99.56%; HEIGHT: 376px"> -->
															<TABLE width="100%">
																<TR>
																	<TD width="50%">
																		<!-- start of datagrid -->
																		<asp:datagrid id="gridService" runat="server" Width="100%" Cellpadding="0" ShowFooter="True" DataKeyField=""
																			PageSize="20" AllowPaging="False" Height="100%" GridLines="Horizontal" BorderWidth="1" BorderColor="Gainsboro"
																			Cellspacing="0" AutoGenerateColumns="False">
																			<HeaderStyle Font-Bold="True" Height="20px" BackColor="#DEE3E7"></HeaderStyle>
																			<EditItemStyle Font-Bold="True"></EditItemStyle>
																			<AlternatingItemStyle BackColor="WhiteSmoke"></AlternatingItemStyle>
																			<ItemStyle Font-Size="8pt"></ItemStyle>
																			<Columns>
																				<asp:TemplateColumn HeaderText="Tgl.Service">
																					<HeaderStyle HorizontalAlign="Left" Width="100px"></HeaderStyle>
																					<ItemStyle HorizontalAlign="Left"></ItemStyle>
																					<ItemTemplate>
																						<asp:label runat="server" style="margin-left:0;margin-right:5" Text='<%# DataBinder.Eval(Container.DataItem, "tglservice") %>' ID="_lblTglService"/>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="Nama Service">
																					<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
																					<ItemStyle HorizontalAlign="Left"></ItemStyle>
																					<ItemTemplate>
																						<asp:label runat="server" style="margin-left:0;margin-right:5" Text='<%# DataBinder.Eval(Container.DataItem, "nmservice") %>' ID="_lblNmService"/>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="Pelaksana">
																					<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
																					<ItemStyle HorizontalAlign="Left"></ItemStyle>
																					<ItemTemplate>
																						<asp:label runat="server" style="margin-left:0;margin-right:5" Text='<%# DataBinder.Eval(Container.DataItem, "pelaksana") %>' ID="_lblPelaksana"/>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																			</Columns>
																		</asp:datagrid>
																		<!-- end of datagrid -->
																	</TD>
																</TR>
															</TABLE>
															<!-- </DIV> -->
														</TD>
													</TR>
													<!-- PAGE CONTENT END HERE --></TABLE>
											</TD>
										</TR>
									</TABLE>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
		<script language="javascript" src="/qislib/scripts/common/common.js"></script>
		<script language="javascript" src="/qislib/scripts/common/FormatNumber.js"></script>
		<script language="vbscript" src="/qislib/scripts/common/common.vbs"></script>
		</FORM>
	</BODY>
</HTML>
