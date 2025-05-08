<asp:panel id="panelGridKelompokFA" runat="server">
	<TABLE width="100%">
		<TR>
			<TD>
				<asp:DataGrid id="gridKelompokFA" runat="server" Cellpadding="0" ShowFooter="True" DataKeyField=""
					PageSize="20" AllowPaging="False" Width="100%" Height="100%" GridLines="Horizontal" BorderWidth="1"
					BorderColor="Gainsboro" Cellspacing="0" AutoGenerateColumns="False">
					<HeaderStyle CssClass="gridHeaderStyle" />
                    <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                    <EditItemStyle Font-Bold="false" />
                    <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
					<Columns>
					    <asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img src=/qislib/images/done.png border=0 align=absmiddle alt='Save changes'&gt;"
							CancelText="&lt;img src=/qislib/images/cancel.png border=0 align=absmiddle alt='Cancel editing'&gt;"
							EditText="&lt;img src=/qislib/images/edit.png border=0 align=absmiddle alt='Edit this item'&gt;">
							<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
						</asp:EditCommandColumn>
						<asp:TemplateColumn HeaderText="Kode">
							<HeaderStyle HorizontalAlign="Left" Width="250px"></HeaderStyle>
							<ItemStyle HorizontalAlign="Left"></ItemStyle>
							<ItemTemplate>
								<asp:label runat="server" style="margin-left:0;margin-right:5" Text='<%# DataBinder.Eval(Container.DataItem, "kdKelompokAktiva") %>' ID="_lblKodeKelompokFa"/>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Nama">
							<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
							<ItemStyle HorizontalAlign="Left"></ItemStyle>
							<ItemTemplate>
								<asp:label runat="server" style="margin-left:0;margin-right:5" Text='<%# DataBinder.Eval(Container.DataItem, "NmKelompokAktiva") %>' ID="_lblNamaKelompokFa"/>
							</ItemTemplate>
							<FooterTemplate>
								<asp:linkbutton runat="server" id="_btnAddNewRow" CausesValidation="False" CommandName="_AddNewRow"
									onMouseOver="window.status='Click here to add new record.'; return true" onMouseOut="window.status='';return true;"
									title="Click here to add new record." text="Tambah Data" />
							</FooterTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="Aktif">
							<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
							<ItemStyle HorizontalAlign="Left"></ItemStyle>
							<itemTemplate>
								<asp:checkbox runat="server" id="_chkaktif" enabled="false" checked='<%# DataBinder.Eval(Container.DataItem, "aktif") %>'/>
							</itemTemplate>
						</asp:TemplateColumn>
						
					</Columns>
				</asp:DataGrid></TD>
		</TR>
	</TABLE>
</asp:panel>
