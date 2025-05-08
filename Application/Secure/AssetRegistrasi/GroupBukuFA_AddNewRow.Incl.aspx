<asp:Panel id="panelAddNewRow" Runat="server">
	<table width="100%">

		<tr>
			<td>

				<TABLE class="rBodyAddNew" cellSpacing="0" borderColorDark="#98aab1" cellPadding="5" width="100%">

					<TR class="rheader">
						<TD class="rheadercol" align="left" height="25">Edit atau Tambah Kelompok Aktiva Tetap
						</TD>
					</TR>

					<TR>
						<TD>
							<TABLE cellSpacing="1" cellPadding="1" width="100%">
								<TR>	 
									<TD width="15%" class="rBodyAddNewFld">            
										<asp:linkbutton id="lbtnKodeBuku"
														runat="server"
														CausesValidation="false"
														Text="Kode Kelompok Aktiva Tetap" />
									</TD>
									<TD class="rBodyAddNewFld">
										<asp:TextBox	id="txtKodeBuku" 
														Runat="server"
														MaxLength="10"
														Width="100" 
														AutoPostBack="True" />
									</TD>
									<TD width="5%" class="rBodyAddNewFld">
										<asp:RequiredFieldValidator id="rfvKodeBuku" 
																	runat="server" 
																	controlToValidate="txtKodeBuku" 
																	errormessage="Kode Kelompok Aktiva Tetap" 
																	display="dynamic">**</asp:RequiredFieldValidator>
									</TD>
									<TD width="40%" class="rBodyAddNewFld">
									</TD>
									<TD width="5%" class="rBodyAddNewFld">																														
									</TD>
								</TR>	

								<TR>	 
									<TD class="rBodyAddNewFld">            
										Nama Kelompok Aktiva Tetap
									</TD>
									<TD class="rBodyAddNewFld">
										<asp:TextBox	id="txtNamaBuku" 
														Runat="server"
														MaxLength="50"
														Width="404" />
									</TD>
									<TD class="rBodyAddNewFld">
										<asp:RequiredFieldValidator id="rfvNamaBuku" 
																	runat="server" 
																	controlToValidate="txtNamaBuku" 
																	errormessage="Nama Kelompok Aktiva Tetap" 
																	display="dynamic">**</asp:RequiredFieldValidator>
									</TD>
									<TD class="rBodyAddNewFld">
									</TD>
									<TD class="rBodyAddNewFld">									
									</TD>
								</TR>
								<TR>	 
									<TD class="rBodyAddNewFld">            
										<asp:linkbutton id="lbtnKodeMetode"
														runat="server"
														CausesValidation="false"
														Text="Metode Penyusutan" />
									</TD>
									<TD class="rBodyAddNewFld">
										<asp:TextBox	id="txtKodeMetode" 
														Runat="server"
														MaxLength="10"
														Width="100"
														AutoPostBack="true" />
										<asp:TextBox	id="txtNamaMetode" 
														Runat="server"
														MaxLength="10"
														Width="300"
														ReadOnly="true"
														CssClass="txtsummary" />
									</TD>
									<TD class="rBodyAddNewFld">
										<asp:RequiredFieldValidator id="rfvKodeMetode" 
																	runat="server" 
																	controlToValidate="txtKodeMetode" 
																	errormessage="Metode Penyusutan" 
																	display="dynamic">**</asp:RequiredFieldValidator>
									</TD>
									<TD class="rBodyAddNewFld">
									</TD>
									<TD class="rBodyAddNewFld">										
									</TD>
								</TR>
								<tr>
								    <td colspan="5" class="rheaderexpable" style="height: 24px;">
								        Pengaturan Perkiraan untuk Kelompok Aktiva
								    </td>
								</tr>
								<TR>	 
									<TD class="rBodyAddNewFld">            
										<asp:linkbutton id="lbtnCOAAktiva"
														runat="server"
														Text="Aktiva Tetap"
														CausesValidation="False" />
									</TD>
									<TD class="rBodyAddNewFld">
										<asp:TextBox	id="txtGd1" 
														Runat="server"
														Width="100" 
														Style="display:none;"
														ReadOnly="true" CssClass="txtsummary" />
									
										<asp:TextBox	id="txtCOA1" 
														Runat="server"
														MaxLength="10"
														Width="100"
														AutoPostBack="True" />														
										<asp:TextBox	id="txtNamaCOA1" 
														Runat="server"
														MaxLength="50"
														Width="300"
														ReadOnly="true"
														CssClass="txtsummary" />
									</TD>
									<TD width="5%" class="rBodyAddNewFld">
										<asp:linkbutton id="lbtnSubLAktiva"
														Runat="server"
														Text="Sub"
														CausesValidation="False" />
									</TD>
									<TD width="40%" class="rBodyAddNewFld" colspan="0">
										<asp:TextBox	id="txtGroupSubL1" 
														Runat="server"
														Width="100" 
														Style="display:none;"
														ReadOnly="true" CssClass="txtsummary" />
									
										<asp:TextBox	id="txtSubl1"
														runat="server"
														MaxLength="10"
														Width="100"
														Enabled="false"
														AutoPostBack="True" />														
										<asp:TextBox	id="txtNamaSubL1" 
														Runat="server"
														MaxLength="50"
														Width="300"
														ReadOnly="true"
														CssClass="txtsummary" />
														
										<asp:RequiredFieldValidator id="rfvNamaSubL1" 
																	runat="server" 
																	controlToValidate="txtNamaSubL1" 
																	errormessage="Sub Perkiraan Aktiva Tetap" 
																	display="dynamic">**</asp:RequiredFieldValidator>
									</TD>
									<TD width="5%" class="rBodyAddNewFld">
									</TD>
								</TR>
								<TR>	 
									<TD width="15%" class="rBodyAddNewFld">            
										<asp:linkbutton id="lbtnCOAPenyusutan"
														runat="server"
														Text="Akumulasi Penyusutan"
														CausesValidation="False" />
									</TD>
									<TD width="40%" class="rBodyAddNewFld">
										<asp:TextBox	id="txtGd2" 
														Runat="server"
														Width="100" 
														Style="display:none;"
														ReadOnly="true" CssClass="txtsummary" />
									
										<asp:TextBox	id="txtCOA2" 
														Runat="server"
														MaxLength="10"
														Width="100"
														AutoPostBack="True" />														
										<asp:TextBox	id="txtNamaCOA2" 
														Runat="server"
														MaxLength="50"
														Width="300"
														ReadOnly="true"
														CssClass="txtsummary" />
									</TD>
									<TD width="5%" class="rBodyAddNewFld">
										<asp:linkbutton id="lbtnSubLPenyusutan"
														Runat="server"
														Text="Sub"
														CausesValidation="False" />
									</TD>
									<TD width="40%" class="rBodyAddNewFld" colspan="0">
										<asp:TextBox	id="txtGroupSubL2" 
														Runat="server"
														Width="100" 
														Style="display:none;"
														ReadOnly="true" CssClass="txtsummary" />
									
										<asp:TextBox	id="txtSubl2"
														runat="server"
														MaxLength="10"
														Width="100"
														Enabled="false"
														AutoPostBack="True" />										
										<asp:TextBox	id="txtNamaSubL2" 
														Runat="server"
														MaxLength="50"
														Width="300"
														ReadOnly="true" CssClass="txtsummary" />
														
										<asp:RequiredFieldValidator id="rfvNamaSubL2" 
																	runat="server" 
																	controlToValidate="txtNamaSubL2" 
																	errormessage="Sub Perkiraan Akumulasi Penyusutan" 
																	display="dynamic">**</asp:RequiredFieldValidator>
									</TD>
									<TD width="5%" class="rBodyAddNewFld">
									</TD>
								</TR>
								<TR>	 
									<TD width="15%" class="rBodyAddNewFld">            
										<asp:linkbutton id="lbtnCOADepresiasi"
														runat="server"
														Text="Biaya Penyusutan"
														CausesValidation="False" />
									</TD>
									<TD width="40%" class="rBodyAddNewFld">
										<asp:TextBox	id="txtGd3" 
														Runat="server"
														Width="100" 
														Style="display:none;"
														ReadOnly="true" CssClass="txtsummary" />
									
										<asp:TextBox	id="txtCOA3" 
														Runat="server"
														MaxLength="10"
														Width="100"
														AutoPostBack="True" />														
										<asp:TextBox	id="txtNamaCOA3" 
														Runat="server"
														MaxLength="50"
														Width="300"
														ReadOnly="true"
														CssClass="txtsummary" />
									</TD>
									<TD width="5%" class="rBodyAddNewFld">
										<asp:linkbutton id="lbtnSubLDepresiasi"
														Runat="server"
														Text="Sub"
														CausesValidation="False" />
									</TD>
									<TD width="40%" class="rBodyAddNewFld" colspan="0">
										<asp:TextBox	id="txtGroupSubL3" 
														Runat="server"
														Width="100" 
														Style="display:none;"
														ReadOnly="true" CssClass="txtsummary" />
									
										<asp:TextBox	id="txtSubl3"
														runat="server"
														MaxLength="10"
														Width="100"
														Enabled="false"
														AutoPostBack="True" />														
										<asp:TextBox	id="txtNamaSubL3" 
														Runat="server"
														MaxLength="50"
														Width="300"
														ReadOnly="true" CssClass="txtsummary" />
														
										<asp:RequiredFieldValidator id="rfvNamaSubL3" 
																	runat="server" 
																	controlToValidate="txtNamaSubL3" 
																	errormessage="Sub Perkiraan Biaya Penyusutan" 
																	display="dynamic">**</asp:RequiredFieldValidator>
									</TD>
									<TD width="5%" class="rBodyAddNewFld">
									</TD>
								</TR>
								<TR style="display:none">	 
									<TD width="15%" class="rBodyAddNewFld">            
										<asp:linkbutton id="lbtnCOATanggungan"
														runat="server"
														Text="Tanggungan"
														CausesValidation="False" />
									</TD>
									<TD width="40%" class="rBodyAddNewFld">
										<asp:TextBox	id="txtGd4" 
														Runat="server"
														Width="100%" 
														Style="display:none;"
														ReadOnly="true" CssClass="txtsummary" />
									
										<asp:TextBox	id="txtCOA4" 
														Runat="server"
														MaxLength="10"
														Width="100"
														AutoPostBack="True" />
														
										<asp:TextBox	id="txtNamaCOA4" 
														Runat="server"
														MaxLength="50"
														Width="300"
														ReadOnly="true" CssClass="txtsummary" />
									</TD>
									<TD width="5%" class="rBodyAddNewFld">
										<asp:linkbutton id="lbtnSubLTanggungan"
														Runat="server"
														Text="Sub"
														CausesValidation="False" />
									</TD>
									<TD width="40%" class="rBodyAddNewFld" colspan="0">
										<asp:TextBox	id="txtGroupSubL4" 
														Runat="server"
														Width="100%" 
														Style="display:none;"
														ReadOnly="true" CssClass="txtsummary" />
									
										<asp:TextBox	id="txtSubl4"
														runat="server"
														MaxLength="10"
														Width="100"
														Enabled="false"
														AutoPostBack="True" />
														
										<asp:TextBox	id="txtNamaSubL4" 
														Runat="server"
														MaxLength="50"
														Width="300"
														ReadOnly="true" CssClass="txtsummary" />
														
										<asp:RequiredFieldValidator id="rfvNamaSubL4" 
																	runat="server" 
																	controlToValidate="txtNamaSubL4" 
																	errormessage="Sub Perkiraan Tanggungan" 
																	display="dynamic">**</asp:RequiredFieldValidator>
									</TD>
									<TD width="5%" class="rBodyAddNewFld">
									</TD>
								</TR>
								<TR>	 
									<TD width="15%" class="rBodyAddNewFld">            
										<asp:linkbutton id="lbtnCOAPendapatan"
														runat="server"
														Text="Keuntungan Penjualan"
														CausesValidation="False" />
									</TD>
									<TD width="40%" class="rBodyAddNewFld">
										<asp:TextBox	id="txtGd5" 
														Runat="server"
														Width="100%" 
														Style="display:none;"
														ReadOnly="true" CssClass="txtsummary" />
									
										<asp:TextBox	id="txtCOA5" 
														Runat="server"
														MaxLength="10"
														Width="100"
														AutoPostBack="True" />
														
										<asp:TextBox	id="txtNamaCOA5" 
														Runat="server"
														MaxLength="50"
														Width="300"
														ReadOnly="true" CssClass="txtsummary" />
									</TD>
									<TD width="5%" class="rBodyAddNewFld">
										<asp:linkbutton id="lbtnSubLPendapatan"
														Runat="server"
														Text="Sub"
														CausesValidation="False" />
									</TD>
									<TD width="40%" class="rBodyAddNewFld" colspan="0">
										<asp:TextBox	id="txtGroupSubL5" 
														Runat="server"
														Width="100%" 
														Style="display:none;"
														ReadOnly="true" CssClass="txtsummary" />
									
										<asp:TextBox	id="txtSubl5"
														runat="server"
														MaxLength="10"
														Width="100"
														Enabled="false"
														AutoPostBack="True" />														
										<asp:TextBox	id="txtNamaSubL5" 
														Runat="server"
														MaxLength="50"
														Width="300"
														ReadOnly="true" CssClass="txtsummary" />
														
										<asp:RequiredFieldValidator id="rfvNamaSubL5" 
																	runat="server" 
																	controlToValidate="txtNamaSubL5" 
																	errormessage="Sub Perkiraan Pendapatan Penjualan" 
																	display="dynamic">**</asp:RequiredFieldValidator>
									</TD>
									<TD width="5%" class="rBodyAddNewFld">
									</TD>
								</TR>
								<TR>	 
									<TD width="15%" class="rBodyAddNewFld">            
										<asp:linkbutton id="lbtnCOABiaya"
														runat="server"
														Text="Kerugian Penjualan"
														CausesValidation="False" />
									</TD>
									<TD width="40%" class="rBodyAddNewFld">
										<asp:TextBox	id="txtGd6" 
														Runat="server"
														Width="100%" 
														Style="display:none;"
														ReadOnly="true" CssClass="txtsummary" />
									
										<asp:TextBox	id="txtCOA6" 
														Runat="server"
														MaxLength="10"
														Width="100"
														AutoPostBack="True" />														
										<asp:TextBox	id="txtNamaCOA6" 
														Runat="server"
														MaxLength="50"
														Width="300"
														ReadOnly="true" CssClass="txtsummary" />
									</TD>
									<TD width="5%" class="rBodyAddNewFld">
										<asp:linkbutton id="lbtnSubLBiaya"
														Runat="server"
														Text="Sub"
														CausesValidation="False" />
									</TD>
									<TD width="40%" class="rBodyAddNewFld" colspan="0">
										<asp:TextBox	id="txtGroupSubL6" 
														Runat="server"
														Width="100%" 
														Style="display:none;"
														ReadOnly="true" CssClass="txtsummary" />
									
										<asp:TextBox	id="txtSubl6"
														runat="server"
														MaxLength="10"
														Width="100"
														Enabled="false"
														AutoPostBack="True" />														
										<asp:TextBox	id="txtNamaSubL6" 
														Runat="server"
														MaxLength="50"
														Width="300"
														ReadOnly="true" CssClass="txtsummary" />
														
										<asp:RequiredFieldValidator id="rfvNamaSubL6" 
																	runat="server" 
																	controlToValidate="txtNamaSubL6" 
																	errormessage="Sub Perkiraan Kerugian Penjualan" 
																	display="dynamic">**</asp:RequiredFieldValidator>
									</TD>
									<TD width="5%" class="rBodyAddNewFld">
									</TD>
								</TR>
								<TR>	 
									<TD width="15%" class="rBodyAddNewFld">            
										<asp:linkbutton id="lbtnCOAEliminasi"
														runat="server"
														Text="Pemusnahan"
														CausesValidation="False" />
									</TD>
									<TD width="40%" class="rBodyAddNewFld">
										<asp:TextBox	id="txtGd7" 
														Runat="server"
														Width="100%" 
														Style="display:none;"
														ReadOnly="true" CssClass="txtsummary" />
									
										<asp:TextBox	id="txtCOA7" 
														Runat="server"
														MaxLength="10"
														Width="100"
														AutoPostBack="True" />
														
										<asp:TextBox	id="txtNamaCOA7" 
														Runat="server"
														MaxLength="50"
														Width="300"
														ReadOnly="true" CssClass="txtsummary" />
									</TD>
									<TD width="5%" class="rBodyAddNewFld">
										<asp:linkbutton id="lbtnSubLEliminasi"
														Runat="server"
														Text="Sub"
														CausesValidation="False" />
									</TD>
									<TD width="40%" class="rBodyAddNewFld" colspan="0">
										<asp:TextBox	id="txtGroupSubL7" 
														Runat="server"
														Width="100%" 
														Style="display:none;"
														ReadOnly="true" CssClass="txtsummary" />
									
										<asp:TextBox	id="txtSubl7"
														runat="server"
														MaxLength="10"
														Width="100"
														Enabled="false"
														AutoPostBack="True" />
														
										<asp:TextBox	id="txtNamaSubL7" 
														Runat="server"
														MaxLength="50"
														Width="300"
														ReadOnly="true" CssClass="txtsummary" />
														
										<asp:RequiredFieldValidator id="rfvNamaSubL7" 
																	runat="server" 
																	controlToValidate="txtNamaSubL7" 
																	errormessage="Sub Perkiraan Pemusnahan" 
																	display="dynamic">**</asp:RequiredFieldValidator>
									</TD>
									<TD width="5%" class="rBodyAddNewFld">
									</TD>
								</TR>
								
							</TABLE>

							<TABLE width="100%">
								<TR>
									<TD width="50%" align="left">
										<asp:Button id="btnSave" runat="server" text="Save" CssClass="sbttn"  Width="100" />
										<asp:Button id="btnDone" runat="server" text="Close" CausesValidation="False" CssClass="sbttn" Width="100" />
										<asp:Button id="btnDelete" runat="server" text="Delete" CausesValidation="False" CssClass="sbttn" Width="100" />																								
									</TD>
									<TD width="50%" align="right">
										<asp:Button id="btnProses" runat="server" text="Proses Akumulasi Penyusutan Aktiva Tetap" CausesValidation="False" CssClass="sbttn" width="300"/>
									</TD>
								</TR>
							</TABLE>

							<!-- VALIDATION SUMMARY BEGIN HERE -->
							<TABLE cellSpacing="0" cellPadding="5" width="100%">
								<TR>
									<TD align="left">
										<P>
											<asp:ValidationSummary id="ValidationSummary" runat="server" HeaderText="Field(s) berikut harus diisi atau perlu diperbaiki." />
										</P>
									</TD>
								</TR>
							</TABLE>
							<!-- VALIDATION SUMMARY END HERE -->

						</TD>
					</TR>

					<TR vAlign="bottom" bgColor="white">
						<TD align="left" height="25">
							<P align="right">Data yang sudah ada...
							</P>
						</TD>
					</TR>

				</TABLE>

			</td>
		</tr>

	</table>
</asp:Panel>