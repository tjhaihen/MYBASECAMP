<asp:Panel id="panelAddNewRow" Runat="server">
	<TABLE width="100%">
		<TR>
			<TD>
				<!-- VALIDATION SUMMARY BEGIN HERE -->
				<TABLE cellSpacing="0" cellPadding="5" width="100%">
					<TR>
						<TD align="left">
							<P>
								<asp:ValidationSummary id="ValidationSummary" runat="server" HeaderText="Field(s) berikut harus diisi atau perlu diperbaiki."></asp:ValidationSummary></P>
						</TD>
					</TR>
				</TABLE> 
				<!-- VALIDATION SUMMARY END HERE -->
				<TABLE cellSpacing="0" borderColorDark="#98aab1" cellPadding="2" width="100%">
					<TR>
						<TD width="50%" valign="top">							
							<TABLE cellSpacing="1" cellPadding="2" width="100%" border="0">
								<TR class="rheader">
									<TD colspan="2" class="rheaderexpable" align="left" height="20">
										Data Aset Register
									</TD>
								</TR>
								<TR>
									<TD width="15%">
										<asp:linkbutton id="lbtnKodeAktiva" runat="server" CausesValidation="false" Text="Kode Aktiva Tetap"></asp:linkbutton>
										<font color="red">*</font></TD>
									<TD width="40%">
										<asp:TextBox id="txtKdAktiva" Runat="server" MaxLength="30" Width="95%" Visible="false"></asp:TextBox>
										<asp:TextBox id="txtKodeAktiva" Runat="server" MaxLength="30" Width="95%" AutoPostBack="True"></asp:TextBox>
										<asp:RequiredFieldValidator id="rfvKodeAktiva" runat="server" controlToValidate="txtKodeAktiva" errormessage="Kode Aktiva"
											enabled="false" display="dynamic">**</asp:RequiredFieldValidator>
											
										<asp:textbox id="txtcounterpenerimaan" Runat="server" Width="69%" Visible="false"></asp:textbox>
										<asp:textbox id="txtnoterima" Runat="server" Width="30%" Visible="false"></asp:textbox>	
									</TD>									
								</TR>
								<TR>
									<TD width="15%">Nama Aset <font color="red">*</font>
									</TD>
									<TD width="40%">
										<asp:TextBox id="txtNamaAktiva" Runat="server" MaxLength="500" Width="95%" TextMode="MultiLine"
											Height="40px"></asp:TextBox>
										<asp:RequiredFieldValidator id="rfvNamaAktiva" runat="server" controlToValidate="txtNamaAktiva" errormessage="Nama Aktiva"
											display="dynamic">**</asp:RequiredFieldValidator>
									</TD>									
								</TR>
								<TR>
									<TD width="15%">Nomor Seri
									</TD>
									<TD width="40%">
										<asp:TextBox id="txtserialnumber" Runat="server" MaxLength="500" Width="95%"></asp:TextBox>
									</TD>																	
								</TR>
								<%--<TR>
									<TD width="15%">
										<asp:linkbutton id="lbtnKodeBuku" runat="server" CausesValidation="false" Text="Buku Aktiva Tetap"></asp:linkbutton>
										<font color="red">*</font></TD>
									<TD width="40%">
										<asp:TextBox id="txtKodeBuku" Runat="server" MaxLength="10" Width="25%" AutoPostBack="true"></asp:TextBox>
										<asp:TextBox id="txtNamaBuku" Runat="server" MaxLength="50" Width="69%" ReadOnly="True" CssClass="txtsummary"></asp:TextBox>
										<asp:RequiredFieldValidator id="rfvKodeBuku" runat="server" controlToValidate="txtKodeBuku" errormessage="Kode Buku"
											display="dynamic">**</asp:RequiredFieldValidator>
									</TD>									
								</TR>--%>								
								<TR>
									<TD width="15%">
										<asp:linkbutton id="lbtnKodeLokasi" runat="server" CausesValidation="false" Text="Lokasi Aktiva Tetap"></asp:linkbutton>
										<font color="red">*</font></TD>
									<TD width="40%">
										<asp:TextBox id="txtKodeLokasi" Runat="server" MaxLength="15" Width="25%" AutoPostBack="true"></asp:TextBox>
										<asp:TextBox id="txtNamaLokasi" Runat="server" MaxLength="500" Width="69%" ReadOnly="True" CssClass="txtsummary"></asp:TextBox>
										<asp:RequiredFieldValidator id="rfvKodeLokasi" runat="server" controlToValidate="txtKodeLokasi" errormessage="Kode Lokasi"
											enabled="true" display="dynamic">**</asp:RequiredFieldValidator>
									</TD>									
								</TR>								
								<TR>
									<TD width="15%"><asp:linkbutton id="lbtnKodeUser" runat="server" CausesValidation="false" Text="User Pengguna"></asp:linkbutton></TD>
									<TD width="40%">
										<asp:TextBox id="txtKodeUser" Runat="server" MaxLength="10" Width="25%" AutoPostBack="true"></asp:TextBox>
										<asp:TextBox id="txtNamaUser" Runat="server" MaxLength="50" Width="69%" ReadOnly="True" CssClass="txtsummary"></asp:TextBox>
									</TD>									
								</TR>																																															
								<TR>
									<TD width="15%">Keterangan
									</TD>
									<TD width="40%">
										<asp:textbox id="txtKeterangan" runat="server" MaxLength="500" Width="95%" TextMode="MultiLine"
											Height="40px"></asp:textbox>
									</TD>									
								</TR>
								<%--<TR>
									<TD width="15%">Vendor
									</TD>
									<TD width="40%">
										<asp:TextBox id="txtNamaVendor" Runat="server" MaxLength="50" Width="95%"></asp:TextBox>
									</TD>																	
								</TR>--%>
								<%--<TR>
									<TD width="15%">No. Kontrak
									</TD>
									<TD width="40%">
										<asp:TextBox id="txtNoKontrak" Runat="server" MaxLength="50" Width="95%"></asp:TextBox>
									</TD>																	
								</TR>--%>
							</TABLE>							
						</TD>
						
						<TD width="50%" valign="top">
							<TABLE cellSpacing="1" cellPadding="2" width="100%" border="0">
								<TR class="rheader">
									<TD colspan="2" class="rheaderexpable" align="left" height="20">
										Data Perolehan Aset
									</TD>
								</TR>
								<%--<TR>
									<TD width="15%">No. Voucher Perolehan
									</TD>
									<TD width="40%">
										<asp:TextBox id="txtNvPenyusutan" Runat="server" MaxLength="30" Width="100%" visible="false"></asp:TextBox>
										<asp:TextBox id="txtNvPembelian" Runat="server" MaxLength="30" Width="50%"></asp:TextBox>
									</TD>									
								</TR>--%>
								<TR>
									<TD width="15%">Tanggal Perolehan <font color="red">*</font>
									</TD>
									<TD width="40%">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD width="10%">
													<Module:Calendar id="calTglBeli" runat="server" dontResetDate="true" width="100%"></module:Calendar>
                                                </TD>
												<TD width="10%">													
												</TD>
											</TR>
										</TABLE>
									</TD>									
								</TR>
								<TR>
									<TD width="15%">Nilai Perolehan <font color="red">*</font>
									</TD>
									<TD width="40%">
										<asp:textbox id="txtHargaBeli" style="TEXT-ALIGN: right" onfocus="javascript:this.select();" runat="server" Width="50%"></asp:textbox>
										<asp:RequiredFieldValidator id="rfvtxtHargaBeli" runat="server" controlToValidate="txtHargaBeli" errormessage="Harga Beli" display="dynamic">** </asp:RequiredFieldValidator>										
									</TD>									
								</TR>
								<%--<TR>
									<TD width="15%">Qty. Perolehan
									</TD>
									<TD width="40%">
										<asp:textbox id="txtQtyBeli" style="TEXT-ALIGN: right" runat="server" Width="10%" AutoPostBack="False"></asp:textbox>
										&nbsp;&nbsp;Satuan
										<asp:textbox id="txtSatuan" runat="server" Width="29.5%" AutoPostBack="False"></asp:textbox>
										&nbsp;&nbsp;
										<asp:CheckBox id="chkKSO" runat="server" text="KSO" checked="false" />
									</TD>									
								</TR>--%>	
								<%--<TR>
									<TD colspan="2" height="20">
										
									</TD>
								</TR>							
								<TR class="rheader">
									<TD colspan="2" class="rheaderexpable" align="left" height="20">
										Data Perhitungan Penyusutan Aktiva Tetap
									</TD>
								</TR>
								<TR>
									<TD width="15%">
										<asp:linkbutton id="lbtnKodeMetode" runat="server" CausesValidation="false" Text="Metode Penyusutan"></asp:linkbutton>
										<font color="red">*</font></TD>
									<TD width="40%">
										<asp:TextBox id="txtKodeMetode" Runat="server" MaxLength="10" Width="25%" AutoPostBack="true"></asp:TextBox>
										<asp:TextBox id="txtNamaMetode" Runat="server" MaxLength="50" Width="69%" ReadOnly="True" CssClass="txtsummary"></asp:TextBox>
										<asp:RequiredFieldValidator id="rfvKodeMetode" runat="server" controlToValidate="txtKodeMetode" errormessage="Kode Metode"
											display="dynamic">**</asp:RequiredFieldValidator>
									</TD>									
								</TR>
								<TR>
									<TD width="15%">Tanggal Hitung <font color="red">*</font>
									</TD>
									<TD width="40%">
										<MODULE:WEBCAL id="calTglHitung" runat="server" dontResetDate="true" width="100%"></MODULE:WEBCAL></MODULE:WEBCAL>										
									</TD>									
								</TR>--%>
								<TR>
									<TD width="15%">Estimasi Umur <font color="red">*</font>
									</TD>
									<TD width="40%">
										<asp:textbox id="txtUmur" style="TEXT-ALIGN: right" runat="server" Width="10%"></asp:textbox>&nbsp;&nbsp;Tahun
										<asp:RequiredFieldValidator id="rfvUmur" runat="server" controlToValidate="txtUmur" errormessage="Umur" display="dynamic">**
										</asp:RequiredFieldValidator>
									</TD>									
								</TR>
								<%--<TR>
									<TD width="15%">Nilai Akhir
									</TD>
									<TD width="40%">
										<asp:textbox id="txtNilaiAkhir" style="TEXT-ALIGN: right" onfocus="javascript:this.select();" runat="server" Width="50%"></asp:textbox>
									</TD>									
								</TR>--%>								
							</TABLE>
						</TD>
					</TR>
					<%--<TR class="rheader">
						<TD colspan="2" class="rheaderexpable" align="left" height="20">
							Pengaturan Perkiraan untuk Aktiva Tetap
						</TD>
					</TR>
					<TR>
						<TD width="50%" valign="top">
							<TABLE cellSpacing="1" cellPadding="2" width="100%" border="0">
								<!-- 1 -->
								<TR>
									<TD width="15%">
										<asp:linkbutton id="lbtnCOAAktiva" runat="server" CausesValidation="False" text="Aktiva Tetap"></asp:linkbutton>
									</TD>
									<TD width="40%">
										<asp:TextBox id="txtGd1" style="DISPLAY: none" Runat="server" Width="100%" readonly="true" CssClass="txtsummary"></asp:TextBox>
										<asp:textbox id="txtCOA1" runat="server" MaxLength="35" Width="25%" AutoPostBack="True"></asp:textbox>
										<asp:textbox id="txtNamaCOA1" runat="server" MaxLength="50" Width="69%" ReadOnly="true" CssClass="txtsummary"></asp:textbox>
									</TD>									
								</TR>
								
								<!-- 2 -->
								<TR>
									<TD width="15%">
										<asp:linkbutton id="lbtnCOAPenyusutan" runat="server" CausesValidation="False" text="Akumulasi Penyusutan"></asp:linkbutton>
									</TD>
									<TD width="40%">
										<asp:TextBox id="txtGd2" style="DISPLAY: none" Runat="server" Width="100%" readonly="true" CssClass="txtsummary"></asp:TextBox>
										<asp:textbox id="txtCOA2" runat="server" MaxLength="35" Width="25%" AutoPostBack="True"></asp:textbox>
										<asp:textbox id="txtNamaCOA2" runat="server" MaxLength="50" Width="69%" ReadOnly="true" CssClass="txtsummary"></asp:textbox>
									</TD>									
								</TR>
								
								<!-- 3 -->
								<TR>
									<TD width="15%">
										<asp:linkbutton id="lbtnCOADepresiasi" runat="server" CausesValidation="False" text="Beban Penyusutan"></asp:linkbutton>
									</TD>
									<TD width="40%">
										<asp:TextBox id="txtGd3" style="DISPLAY: none" Runat="server" Width="100%" readonly="true" CssClass="txtsummary"></asp:TextBox>
										<asp:textbox id="txtCOA3" runat="server" MaxLength="35" Width="25%" AutoPostBack="True"></asp:textbox>
										<asp:textbox id="txtNamaCOA3" runat="server" MaxLength="50" Width="69%" ReadOnly="true" CssClass="txtsummary"></asp:textbox>
									</TD>									
								</TR>
								
								<!-- 4 -->
								<TR style="display:none">
									<TD width="15%">
										<asp:linkbutton id="lbtnCOATanggungan" runat="server" CausesValidation="False" text="Tanggungan"></asp:linkbutton>
									</TD>
									<TD width="40%">
										<asp:TextBox id="txtGd4" style="DISPLAY: none" Runat="server" Width="100%" readonly="true" CssClass="txtsummary"></asp:TextBox>
										<asp:textbox id="txtCOA4" runat="server" MaxLength="35" Width="25%" AutoPostBack="True"></asp:textbox>
										<asp:textbox id="txtNamaCOA4" runat="server" MaxLength="50" Width="69%" ReadOnly="true" CssClass="txtsummary"></asp:textbox>
									</TD>									
								</TR>
								
								<!-- 5 -->
								<TR>
									<TD width="15%">
										<asp:linkbutton id="lbtnCOAPendapatan" runat="server" CausesValidation="False" text="Keuntungan Penjualan"></asp:linkbutton>
									</TD>
									<TD width="40%">
										<asp:TextBox id="txtGd5" style="DISPLAY: none" Runat="server" Width="100%" readonly="true" CssClass="txtsummary"></asp:TextBox>
										<asp:textbox id="txtCOA5" runat="server" MaxLength="35" Width="25%" AutoPostBack="True"></asp:textbox>
										<asp:textbox id="txtNamaCOA5" runat="server" MaxLength="50" Width="69%" ReadOnly="true" CssClass="txtsummary"></asp:textbox>
									</TD>									
								</TR>
								
								<!-- 6 -->
								<TR>
									<TD width="15%">
										<asp:linkbutton id="lbtnCOABiaya" runat="server" CausesValidation="False" text="Kerugian Penjualan"></asp:linkbutton>
									</TD>
									<TD width="40%">
										<asp:TextBox id="txtGd6" style="DISPLAY: none" Runat="server" Width="100%" readonly="true" CssClass="txtsummary"></asp:TextBox>
										<asp:textbox id="txtCOA6" runat="server" MaxLength="35" Width="25%" AutoPostBack="True"></asp:textbox>
										<asp:textbox id="txtNamaCOA6" runat="server" MaxLength="50" Width="69%" ReadOnly="true" CssClass="txtsummary"></asp:textbox>
									</TD>									
								</TR>
								
								<!-- 7 -->
								<TR style="display:none">
									<TD width="15%">
										<asp:linkbutton id="lbtnCOAEliminasi" runat="server" CausesValidation="False" text="Pemusnahan"></asp:linkbutton>
									</TD>
									<TD width="40%">
										<asp:TextBox id="txtGd7" style="DISPLAY: none" Runat="server" Width="100%" readonly="true" CssClass="txtsummary"></asp:TextBox>
										<asp:textbox id="txtCOA7" runat="server" MaxLength="35" Width="25%" AutoPostBack="True"></asp:textbox>
										<asp:textbox id="txtNamaCOA7" runat="server" MaxLength="50" Width="69%" ReadOnly="true" CssClass="txtsummary"></asp:textbox>
									</TD>									
								</TR>
							</TABLE>
						</TD>
						
						<TD width="50%" valign="top">
							<TABLE cellSpacing="1" cellPadding="2" width="100%" border="0">
								<!-- 1 -->
								<TR>
									<TD width="15%">
										<asp:linkbutton id="lbtnSublAktiva" runat="server" CausesValidation="False" text="Sub"></asp:linkbutton>
									</TD>
									<TD width="40%">
										<asp:TextBox id="txtGroupSubL1" style="DISPLAY: none" Runat="server" Width="100%" readonly="true" CssClass="txtsummary"></asp:TextBox>
										<asp:textbox id="txtSubl1" runat="server" MaxLength="10" Width="25%" AutoPostBack="True" Enabled="False"></asp:textbox>
										<asp:textbox id="txtNamaSubL1" runat="server" MaxLength="50" Width="69%" ReadOnly="true" CssClass="txtsummary"></asp:textbox>
										<asp:RequiredFieldValidator id="rfvNamaSubL1" runat="server" controlToValidate="txtNamaSubL1" errormessage="SubLedger Aktiva"
											display="dynamic">**</asp:RequiredFieldValidator>
									</TD>									
								</TR>
								
								<!-- 2 -->
								<TR>
									<TD width="15%">
										<asp:linkbutton id="lbtnSublPenyusutan" runat="server" CausesValidation="False" text="Sub"></asp:linkbutton>
									</TD>
									<TD width="40%">
										<asp:TextBox id="txtGroupSubL2" style="DISPLAY: none" Runat="server" Width="100%" readonly="true" CssClass="txtsummary"></asp:TextBox>
										<asp:textbox id="txtSubl2" runat="server" MaxLength="10" Width="25%" AutoPostBack="True" Enabled="False"></asp:textbox>
										<asp:textbox id="txtNamaSubL2" runat="server" MaxLength="50" Width="69%" ReadOnly="true" CssClass="txtsummary"></asp:textbox>
										<asp:RequiredFieldValidator id="rfvNamaSubL2" runat="server" controlToValidate="txtNamaSubL2" errormessage="SubLedger Akm. Penyusutan"
											display="dynamic">**</asp:RequiredFieldValidator>
									</TD>									
								</TR>
								
								<!-- 3 -->
								<TR>
									<TD width="15%">
										<asp:linkbutton id="lbtnSublDepresiasi" runat="server" CausesValidation="False" text="Sub"></asp:linkbutton>
									</TD>
									<TD width="40%">
										<asp:TextBox id="txtGroupSubL3" style="DISPLAY: none" Runat="server" Width="100%" readonly="true" CssClass="txtsummary"></asp:TextBox>
										<asp:textbox id="txtSubl3" runat="server" MaxLength="10" Width="25%" AutoPostBack="True" Enabled="False"></asp:textbox>
										<asp:textbox id="txtNamaSubL3" runat="server" MaxLength="50" Width="69%" ReadOnly="true" CssClass="txtsummary"></asp:textbox>
										<asp:RequiredFieldValidator id="rfvNamaSubL3" runat="server" controlToValidate="txtNamaSubL3" errormessage="SubLedger Beban Penyusutan"
											display="dynamic">**</asp:RequiredFieldValidator>
									</TD>									
								</TR>
								
								<!-- 4 -->
								<TR style="display:none">
									<TD width="15%">
										<asp:linkbutton id="lbtnSublTanggungan" runat="server" CausesValidation="False" text="Sub"></asp:linkbutton>
									</TD>
									<TD width="40%">
										<asp:TextBox id="txtGroupSubL4" style="DISPLAY: none" Runat="server" Width="100%" readonly="true" CssClass="txtsummary"></asp:TextBox>
										<asp:textbox id="txtSubl4" runat="server" MaxLength="10" Width="25%" AutoPostBack="True" Enabled="False"></asp:textbox>
										<asp:textbox id="txtNamaSubL4" runat="server" MaxLength="50" Width="69%" ReadOnly="true" CssClass="txtsummary"></asp:textbox>
										<asp:RequiredFieldValidator id="rfvNamaSubL4" runat="server" controlToValidate="txtNamaSubL4" errormessage="SubLedger Tanggungan"
											display="dynamic">**</asp:RequiredFieldValidator>
									</TD>									
								</TR>
								
								<!-- 5 -->
								<TR>
									<TD width="15%">
										<asp:linkbutton id="lbtnSublPendapatan" runat="server" CausesValidation="False" text="Sub"></asp:linkbutton>
									</TD>
									<TD width="40%">
										<asp:TextBox id="txtGroupSubL5" style="DISPLAY: none" Runat="server" Width="100%" readonly="true" CssClass="txtsummary"></asp:TextBox>
										<asp:textbox id="txtSubl5" runat="server" MaxLength="10" Width="25%" AutoPostBack="True" Enabled="False"></asp:textbox>
										<asp:textbox id="txtNamaSubL5" runat="server" MaxLength="50" Width="69%" ReadOnly="true" CssClass="txtsummary"></asp:textbox>
										<asp:RequiredFieldValidator id="rfvNamaSubL5" runat="server" controlToValidate="txtNamaSubL5" errormessage="SubLedger Pendapatan Penj."
											display="dynamic">**</asp:RequiredFieldValidator>
									</TD>									
								</TR>
								
								<!-- 6 -->
								<TR>
									<TD width="15%">
										<asp:linkbutton id="lbtnSublBiaya" runat="server" CausesValidation="False" text="Sub"></asp:linkbutton>
									</TD>
									<TD width="40%">
										<asp:TextBox id="txtGroupSubL6" style="DISPLAY: none" Runat="server" Width="100%" readonly="true" CssClass="txtsummary"></asp:TextBox>
										<asp:textbox id="txtSubl6" runat="server" MaxLength="10" Width="25%" AutoPostBack="True" Enabled="False"></asp:textbox>
										<asp:textbox id="txtNamaSubL6" runat="server" MaxLength="50" Width="69%" ReadOnly="true" CssClass="txtsummary"></asp:textbox>
										<asp:RequiredFieldValidator id="rfvNamaSubL6" runat="server" controlToValidate="txtNamaSubL6" errormessage="SubLedger Kerugian Penj."
											display="dynamic">**</asp:RequiredFieldValidator>
									</TD>									
								</TR>
								
								<!-- 7 -->
								<TR style="display:none">
									<TD width="15%">
										<asp:linkbutton id="lbtnSublEliminasi" runat="server" CausesValidation="False" text="Sub"></asp:linkbutton>
									</TD>
									<TD width="40%">
										<asp:TextBox id="txtGroupSubL7" style="DISPLAY: none" Runat="server" Width="100%" readonly="true" CssClass="txtsummary"></asp:TextBox>
										<asp:textbox id="txtSubl7" runat="server" MaxLength="10" Width="25%" AutoPostBack="True" Enabled="False"></asp:textbox>
										<asp:textbox id="txtNamaSubL7" runat="server" MaxLength="50" Width="69%" ReadOnly="true" CssClass="txtsummary"></asp:textbox>
										<asp:RequiredFieldValidator id="rfvNamaSubL7" runat="server" controlToValidate="txtNamaSubL7" errormessage="SubLedger Pemusnahan"
											display="dynamic">**</asp:RequiredFieldValidator>
									</TD>									
								</TR>
							</TABLE>
						</TD>												
					</TR>
					
					<TR class="rheader">
						<TD colspan="2" class="rheaderexpable" align="left" height="20">
							Data Pemusnahan Aktiva Tetap
						</TD>
					</TR>
					
					<TR>
						<TD width="50%" valign="top">
							<TABLE cellSpacing="1" cellPadding="2" width="100%" border="0">
								<TR>
									<TD width="15%">No. Voucher Pemusnahan
									</TD>
									<TD width="40%">
										<asp:TextBox id="txtNvPenjualan" Runat="server" MaxLength="30" Width="50%"></asp:TextBox>
									</TD>									
								</TR>
								<TR>
									<TD width="15%">Tanggal Pemusnahan
									</TD>
									<TD width="40%">
										<asp:TextBox id="txtTglPemusnahan" Runat="server" ReadOnly="True" CssClass="txtsummary" Style="text-align:center" Width="50%"></asp:TextBox>										
									</TD>									
								</TR>
								<TR>
									<TD width="15%">Tipe Pemusnahan
									</TD>
									<TD width="40%">
										<asp:dropdownlist id="ddlTypePemusnahan" Width="50%" Enabled="False" runat="server" />
									</TD>									
								</TR>	
								<TR>
									<TD width="15%">Nilai Pemusnahan
									</TD>
									<TD width="40%">
										<asp:textbox id="txtJmlhJual" style="TEXT-ALIGN: right" ReadOnly="True" CssClass="txtsummary" runat="server" Width="50%"></asp:textbox>
									</TD>									
								</TR>
							</TABLE>
						</TD>
						
						<TD width="50%" valign="top">
							<TABLE cellSpacing="1" cellPadding="2" width="100%" border="0">
								<TR>
									<TD width="15%">Nilai Buku Saat Pemusnahan
									</TD>
									<TD width="40%">
										<asp:textbox id="txtNilaiBuku" style="TEXT-ALIGN: right" onfocus="javascript:this.select();" ReadOnly="True" CssClass="txtsummary" runat="server" Width="50%"></asp:textbox>										
									</TD>									
								</TR>
								<TR>
									<TD width="15%">Selisih
									</TD>
									<TD width="40%">
										<asp:textbox id="txtSelisih" style="TEXT-ALIGN: right" onfocus="javascript:this.select();" ReadOnly="True" CssClass="txtsummary" runat="server" Width="50%"></asp:textbox>
										&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:checkbox id="chkPosting" runat="server" text="Posting" Enabled="False" />
									</TD>									
								</TR>
								<TR>
									<TD width="15%">Keterangan Pemusnahan
									</TD>
									<TD width="40%">
										<asp:textbox id="txtKeteranganPemusnahan" runat="server" ReadOnly="True" CssClass="txtsummary" MaxLength="500" Width="95%" TextMode="MultiLine"
											Height="40px"></asp:textbox>
									</TD>									
								</TR>
							</TABLE>
						</TD>
					</TR>
					
					<TR>
						<TD colspan="2" align="left" height="20">
							
						</TD>
					</TR>
					
					<TR class="rheader">
						<TD colspan="2" class="rheaderexpable" align="left" height="20">
							Data Akumulasi Penyusutan Aktiva Tetap
						</TD>
					</TR>--%>
				</TABLE>
			</TD>
		</TR>
	</TABLE>
</asp:Panel>
