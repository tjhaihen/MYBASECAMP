<asp:Panel id="panelGridAkumulasiFA" Runat="server">
		<TABLE width ="100%">
			<%--<TR>
				<TD width="50%" align="left">
					<asp:Button id="btnProses" runat="server" text="Proses Akumulasi Penyusutan" CausesValidation="False" CssClass="sbttn" width="300"/>																			
				</TD>																		
				<TD width="50%" align="right">
					<asp:Button id="btnBatalProses" runat="server" text="Batal Proses Jurnal Penyusutan" CausesValidation="False" CssClass="sbttn" width="300"/>
				</TD>																		
			</TR>--%>
			<TR>
				<TD colspan="2">
						
						<asp:DataGrid	id="gridAkumulasiFA" 
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
										DataKeyField=""
										ShowFooter="True"
										CellPadding="0">
								
                                <HeaderStyle CssClass="gridHeaderStyle" />
                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                <EditItemStyle Font-Bold="false" />
                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />								

								<Columns>
								
										<asp:TemplateColumn runat="server" 
															HeaderText="User ID" 
															visible="false"
															HeaderStyle-HorizontalAlign="Left" 
															HeaderStyle-Width="75" 
															ItemStyle-HorizontalAlign="Left">
											<itemtemplate>
												<asp:label		runat="server" 
																style="margin-left:0;margin-right:5"
																Text='<%# DataBinder.Eval(Container.DataItem, "userid") %>' 
																ID="_lblUserID"/>
											</itemtemplate>
										</asp:TemplateColumn >																				
					
										<asp:TemplateColumn runat="server" 
															HeaderText="Nama" 
															HeaderStyle-HorizontalAlign="Left" 
															ItemStyle-HorizontalAlign="Left"
															HeaderStyle-Width="100"
															ItemStyle-Width="100">
											<itemtemplate>
												<asp:label		runat="server" 
																style="margin-left:0;margin-right:5"
																Text='<%# DataBinder.Eval(Container.DataItem, "Nama") %>' 
																ID="_lblNama"/>
											</itemtemplate>
										</asp:TemplateColumn >
										
										
										<asp:TemplateColumn		runat="server" 
																HeaderText="Tanggal Serah Terima" 
																HeaderStyle-HorizontalAlign="Left" 
																ItemStyle-HorizontalAlign="Left"
																HeaderStyle-Width="100"
																ItemStyle-Width="100">
											<itemtemplate>
												<asp:label		runat="server" 
																style="margin-left:0;margin-right:0"
																Text='<%# Format(DataBinder.Eval(Container.DataItem, "tgl"), "dd-MM-yyyy") %>' 
																ID="_lblTgl"/>
											</itemtemplate>																						
										</asp:TemplateColumn >
										
										<%--<asp:TemplateColumn runat="server" 
															HeaderText="Nilai Buku" 
															HeaderStyle-HorizontalAlign="Right" 
															ItemStyle-HorizontalAlign="Right"
															HeaderStyle-Width="150"
															ItemStyle-Width="150">
											<itemtemplate>
												<asp:label		runat="server" 
																style="margin-left:0;margin-right:0"
																 																
																Text='<%# Format(DataBinder.Eval(Container.DataItem, "NilaiBuku"), "#,##0.00") %>' 
																ID="_lblNilaiBuku"/>
											</itemtemplate>											
										</asp:TemplateColumn >--%>
										
										
										<%--<asp:TemplateColumn runat="server" 
															HeaderText="Nilai Susut" 
															HeaderStyle-HorizontalAlign="Right" 
															ItemStyle-HorizontalAlign="Right"
															FooterStyle-HorizontalAlign="Right"
															HeaderStyle-Width="150"
															ItemStyle-Width="150">
											<itemtemplate>
												<asp:label		runat="server" 
																style="margin-left:5;margin-right:0"
																Text='<%# Format(DataBinder.Eval(Container.DataItem, "NilaiSusut"), "#,##0.00") %>' 
																ID="_lblNilaiSusut"/>
											</itemtemplate>											
										</asp:TemplateColumn >
										
										
										<asp:TemplateColumn runat="server" 
															HeaderText="Akumulasi" 
															HeaderStyle-HorizontalAlign="Right" 
															ItemStyle-HorizontalAlign="Right"
															FooterStyle-HorizontalAlign="Right"
															HeaderStyle-Width="150"
															ItemStyle-Width="150">
											<itemtemplate>
												<asp:label		runat="server" 
																style="margin-left:5;margin-right:0"
																Text='<%# Format(DataBinder.Eval(Container.DataItem, "Akumulasi"), "#,##0.00") %>' 
																ID="_lblAkumulasi"/>
											</itemtemplate>											
										</asp:TemplateColumn>	
										
										<asp:TemplateColumn runat="server" 
															HeaderText="CounterJurnalHeader" 
															HeaderStyle-HorizontalAlign="Right" 
															ItemStyle-HorizontalAlign="Right"
															FooterStyle-HorizontalAlign="Right"
															HeaderStyle-Width="150"
															Visible="false"
															ItemStyle-Width="150">
											<itemtemplate>
												<asp:label		runat="server" 
																style="margin-left:5;margin-right:0"
																Text='<%# Format(DataBinder.Eval(Container.DataItem, "CounterJurnalHeader"), "#,##0.00") %>' 
																ID="_lblCounterJurnalHeader"/>
											</itemtemplate>											
										</asp:TemplateColumn>																		
										
										<asp:TemplateColumn		runat="server" 
																HeaderText="Jurnal" 
																HeaderStyle-HorizontalAlign="center" 
																ItemStyle-HorizontalAlign="center"
																HeaderStyle-Width="150"
																ItemStyle-Width="150">
											<itemtemplate>																
												<asp:CheckBox	runat="server" 
																enabled="False"
																checked='<%# DataBinder.Eval(Container.DataItem, "CounterJurnalHeader") <> 0%>' 																
																ID="_chkJurnal"/>
											</itemtemplate>
										</asp:TemplateColumn>	
										
										<asp:TemplateColumn		runat="server" 
																HeaderText="Pilih" 
																HeaderStyle-HorizontalAlign="Center" 
																ItemStyle-HorizontalAlign="Center"
																HeaderStyle-Width="100"
																ItemStyle-Width="100">
																
											<itemtemplate>
												<asp:CheckBox	runat="server" 
																enabled="True"
																Checked="False"
																visible='<%# DataBinder.Eval(Container.DataItem, "CounterJurnalHeader") <> 0%>'
																ID="gridAkumulasiFA_chkPilih"/>
											</itemtemplate>
											
											<HeaderTemplate >
												<input	name="cbxSelectAllAkumulasi"
														ID="cbxSelectAllAkumulasi"
														type="checkbox" 
														onclick="javascript:checkAllv2(this.form,'gridAkumulasiFA_chkPilih', 'cbxSelectAllAkumulasi');">
											</HeaderTemplate>
											
										</asp:TemplateColumn >	--%>																																																
								</Columns>
						</asp:DataGrid>				
				</TD>
			</TR>
			
		</TABLE>
</asp:Panel>