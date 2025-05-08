<asp:panel	id="panelGridBukuFA" runat="server">
	<TABLE width="100%">
		
		<TR>
			<TD>
			
				<asp:DataGrid	id="gridBukuFA"
								runat="server"
								AutoGenerateColumns="False"
								Cellspacing="0"
								BorderColor=Gainsboro
								BorderWidth="1"
								GridLines="Horizontal"
								Height="100%"
								Width="100%"
								AllowPaging="False"
								PageSize="20"
								DataKeyField=""
								ShowFooter="True"
								Cellpadding="0">
								
							<HeaderStyle CssClass="gridHeaderStyle" />
							
							<AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
							
							
							<Columns>
							    <asp:EditCommandColumn	runat="server"
														HeaderStyle-HorizontalAlign="Center"
														HeaderStyle-Width="40"
														EditText="<img src=/qislib/images/edit.png border=0 align=absmiddle alt='Edit this item'>"
														UpdateText="<img src=/qislib/images/done.png border=0 align=absmiddle alt='Save changes'>"
														CancelText="<img src=/qislib/images/cancel.png border=0 align=absmiddle alt='Cancel editing'>">
									
									<itemStyle HorizontalAlign="center" />
								</asp:EditCommandColumn>
								
								<asp:TemplateColumn runat="server" 
													HeaderText="Kode Kelompok Aktiva Tetap" 
													visible="false"
													HeaderStyle-HorizontalAlign="Left" 
													HeaderStyle-Width="200" 
													ItemStyle-HorizontalAlign="Left">
									<itemtemplate>
										<asp:label	runat="server" 
													style="margin-left:0;margin-right:5"
													Text='<%# DataBinder.Eval(Container.DataItem, "KdBuku") %>' 
													ID="_lblKdBuku"/>
									</itemtemplate>
								</asp:TemplateColumn >
								
								<asp:TemplateColumn runat="server" 
													HeaderText="Kode Kelompok Aktiva Tetap" 
													HeaderStyle-HorizontalAlign="Left" 
													HeaderStyle-Width="200" 
													ItemStyle-HorizontalAlign="Left">
										
										<itemtemplate>
												<asp:label	runat="server" 
													style="margin-left:0;margin-right:5"
													Text='<%# DataBinder.Eval(Container.DataItem, "KdBuku") %>' 
													ID="_lblKodeBuku"/>
													
										</itemtemplate>
								</asp:TemplateColumn>
								
								<asp:TemplateColumn	runat="server" 
													HeaderText="Nama Kelompok Aktiva Tetap" 
													HeaderStyle-HorizontalAlign="Left" 
													ItemStyle-HorizontalAlign="Left">
									<itemtemplate>
										<asp:label	runat="server" 
													style="margin-left:0;margin-right:5"
													Text='<%# DataBinder.Eval(Container.DataItem, "NmBuku") %>' 
													ID="_lblNamaBuku"/>
									</itemtemplate>
									
									<footertemplate>
										
										<asp:linkbutton	runat="server"
														id="_btnAddNewRow"
														CausesValidation="False"
														CommandName="_AddNewRow"
														onMouseOver="window.status='Click here to add new record.'; return true"
														onMouseOut="window.status='';return true;"
														title="Click here to add new record."
														text="Tambah Data" />
									</footertemplate>
								</asp:TemplateColumn>
								
								<asp:TemplateColumn runat="server" 
													HeaderText="Metode Penyusutan" 													
													HeaderStyle-HorizontalAlign="Left" 
													HeaderStyle-Width="500" 
													ItemStyle-HorizontalAlign="Left">
									<itemtemplate>
										<asp:label	runat="server" 
													style="margin-left:0;margin-right:5"
													Text='<%# DataBinder.Eval(Container.DataItem, "KdMtd") %>' 
													ID="_lblKdMtd"/>
									</itemtemplate>
								</asp:TemplateColumn>							
							</Columns>
						
				</asp:DataGrid>
						
			</TD>
					
		</TR>
				
	</TABLE>
</asp:Panel> 							