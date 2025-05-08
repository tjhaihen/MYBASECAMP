<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SelItemLG_BatalAsset.aspx.vb" Inherits="QIS.Web.Secure.Master.fa.SelItemLG_BatalAsset"%>
<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../../../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="webcal" Src= "../../../../incl/calendarModule.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<HTML>
	<HEAD>
		<title>Data Item Logistik</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta http-equiv=refresh content=600>
		<LINK href='/qislib/css/styles.css' type="text/css" rel="Stylesheet">
		<script src='/qislib/scripts/GL_/gl___Dlg_rs-v2.js' language="javascript"></script>
		<script src='<%= UrlBase + "/JSDLGGlobalVar.aspx" %>' language="javascript"></script>
	</HEAD>
	
	<body>
		
		<form id="frmItem" runat="server">
			
			<!-- BEGIN PAGE HEADER -->
			<Module:RadMenu ID="RadMenu" runat="server" />
			<!-- END PAGE HEADER -->
			
			<table border="0" width="100%" cellspacing="0" cellpadding="2">
				<tr>
					<td width="100%" valign="top">
						
						<table cellSpacing="10" cellPadding="0" width="100%" border="0">
						
							<tr>
								<td align="left">
																	
										<TABLE cellSpacing="0" cellPadding="5" width="100%">
										
											<TR class="rheader">
												<TD class="rheadercol" align="left" height="25">ITEM LOGISTIK - AKTIVA TETAP
												</TD>
											</TR>
											
											<TR class="rbody">
												<TD class="rbodycol" align="left" height="25">
													<P>Halaman ini untuk memilih data item logistik yang akan diproses sebagai Non-Asset.<br />
													</P>
												</TD>
											</TR>
											
											<TR class="rheader">
												<TD class="rheadercol" align="left" height="2">
											</TD>
											
											
											<TR class="rbody">
												<TD class="rbodycol" align="middle" height="25">
												
													<TABLE width="100%">
														
														<!-- PAGE CONTENT BEGIN HERE -->
																												
														<TR>
															<TD width="100%">
																<TABLE width="100%">
																	<TR>
																		<TD width="50%" align="Left">
																			Total Item Logistik yang belum ada Kode Aktiva Tetap :
																			<asp:Label	id="lblTotal"
																						runat="server"
																						witdh="20%"
																						align="right"/>
																		</TD>
																		<TD width="50%" align="Right">
																			Halaman ini akan <asp:LinkButton	id="lbtnRefresh"
																												runat="server"
																												witdh="20%"
																												text="refresh"
																												CausesValidation="False"/> secara otomatis setiap 10 menit
																		</TD>
																	</TR>
																	
																</TABLE>
															</TD>
														</TR>
																
														<TR>
															<TD width="100%">
																<DIV style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 480px">
																	<TABLE width ="100%">
																		<TR>
																			<TD>
																				<asp:DataGrid	id="gridInformasiItem" 
																								runat="server" 
																								AutoGenerateColumns="False" 
																								CellSpacing="0" 
																								BorderColor=Gainsboro 
																								BorderWidth="1" 
																								GridLines= "Horizontal" 
																								Height="100%"
																								Width="100%"
																								AllowPaging="False"
																								PageSize="20"
																								DataKeyField="counter"
																								ShowFooter=True
																								CellPadding="0">
																			
																					<HeaderStyle	Font-Bold="True" 
																									BackColor=#DEE3E7  
																									Height=20 />
																					
																					<PagerStyle	Mode="NumericPages" 
																								HorizontalAlign="right" />
																					
																
																					<Columns>
																											
																						<asp:TemplateColumn runat="server" 
																											HeaderText="Counter" 
																											HeaderStyle-HorizontalAlign="Left" 
																											ItemStyle-HorizontalAlign="Left"
																											visible="false">
																							<itemtemplate>
																								<asp:label		runat="server" 
																												style="margin-left:5;margin-right:5"
																												Text='<%# DataBinder.Eval(Container.DataItem, "counter") %>' 
																												ID="_lblCounter"/>
																							</itemtemplate>
																						</asp:TemplateColumn >
																																																						
																						<asp:TemplateColumn runat="server" 
																											HeaderText="Nama Item" 
																											HeaderStyle-HorizontalAlign="Left" 
																											ItemStyle-HorizontalAlign="Left">
																							<itemtemplate>
																								<asp:label		runat="server" 
																												style="margin-left:5;margin-right:5"
																												Text='<%# DataBinder.Eval(Container.DataItem, "nmbarang") %>' 
																												ID="_lblNmitem"/>
																							</itemtemplate>
																						</asp:TemplateColumn >
																																						
																						<asp:TemplateColumn		runat="server" 
																												HeaderText="Kode Item" 
																												HeaderStyle-HorizontalAlign="Center" 
																												ItemStyle-HorizontalAlign="Center">
																							<itemtemplate>
																								<asp:Label		runat="server" 
																												cssclass="likelink"
																												Text='<%# DataBinder.Eval(Container.DataItem, "kdbarang") %>' 
																												ID="_lblKdItem" />
																							</itemtemplate>
																						</asp:TemplateColumn >
																						
																						<asp:TemplateColumn		runat="server" 
																												HeaderText="Serial No" 
																												HeaderStyle-HorizontalAlign="Center" 
																												ItemStyle-HorizontalAlign="Center">
																							<itemtemplate>
																								<asp:label		runat="server" 
																												style="margin-left:5;margin-right:5"
																												Text='<%# DataBinder.Eval(Container.DataItem, "serialnumber") %>' 
																												ID="_lblSerialNumber"/>
																							</itemtemplate>
																						</asp:TemplateColumn >
																						
																						<asp:TemplateColumn		runat="server" 
																												HeaderText="No Penerimaan" 
																												HeaderStyle-HorizontalAlign="Center" 
																												ItemStyle-HorizontalAlign="Center">
																							<itemtemplate>
																								<asp:label		runat="server" 
																												style="margin-left:5;margin-right:5"
																												Text='<%# DataBinder.Eval(Container.DataItem, "noterima") %>' 
																												ID="_lblNoBukti"/>
																							</itemtemplate>
																						</asp:TemplateColumn >
																						
																						<asp:TemplateColumn		runat="server" 
																												HeaderText="Tgl Terima" 
																												HeaderStyle-HorizontalAlign="Left" 
																												ItemStyle-HorizontalAlign="Left">
																							<itemtemplate>
																								<asp:label		runat="server" 
																												style="margin-left:5;margin-right:5"
																												Text='<%# Format(DataBinder.Eval(Container.DataItem, "Tglterima"),"dd-MM-yyyy") %>' 
																												ID="_lblTglTerima"/>
																							</itemtemplate>
																						</asp:TemplateColumn >
																						
																						<asp:TemplateColumn>
																							<ItemTemplate>
																								<asp:ImageButton	Runat="server"
																													ID="__ibtnDelete"
																													CausesValidation=False
																													ImageUrl="/qislib/images/delete.png"
																													style="margin-left:0;margin-right:5"
																													alt="Non Assetkan Item ini" 
																													CommandName="__delete" />
																							</ItemTemplate>
																						</asp:TemplateColumn>
																						
																						
																					</Columns>
																		
																				</asp:DataGrid>
																			</TD>
																		</TR>
																	</TABLE>
																</DIV>	
															</TD>
														</TR>
														
														<!-- PAGE CONTENT END HERE -->
														
													</TABLE>
													
												</TD>
											</TR>
											
										</TABLE>
										
										<!-- VALIDATION SUMMARY BEGIN HERE -->
										<TABLE cellSpacing="0" cellPadding="5" width="100%">
											<TR>
												<TD align="left">
													<P>
														<asp:ValidationSummary	id="ValidationSummary" 
																				runat="server" 
																				HeaderText="Field(s) berikut harus diisi atau perlu diperbaiki." />
													</P>
												</TD>
											</TR>
										</TABLE>
										<!-- VALIDATION SUMMARY END HERE -->
										
										
										

								</td>
							</tr>
							
						</table>
						
					</td>
				</tr>
			</table>
		</form>
		
		<script src='/qislib/scripts/common/common.js' language="javascript"></script> 
		<script src='/qislib/scripts/common/common.vbs' language="vbscript"></script>

			
		</form>
		
	</body>
	
</HTML>
