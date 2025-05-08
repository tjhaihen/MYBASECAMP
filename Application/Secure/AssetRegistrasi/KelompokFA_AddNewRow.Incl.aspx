<asp:panel id="panelAddNewRow" Runat="server">
	<TABLE width="100%">
		<TR>
			<TD>
				<TABLE class="rBodyAddNew" cellSpacing="0" borderColorDark="#98aab1" cellPadding="5" width="100%">
					<TR class="rheader">
						<TD class="rheadercol" align="left" height="25">Edit atau Tambah Sub Kelompok Aktiva Tetap							
						</TD>
					</TR>
					<TR>
						<TD>
							<TABLE cellSpacing="1" cellPadding="1" width="100%">
								<TR>
									<TD class="rBodyAddNewFld" width="15%">
										<asp:linkbutton id="lbtnKodeKelompokFa" runat="server" CausesValidation="false">Kode</asp:linkbutton></TD>
									<TD class="rBodyAddNewFld" width="25%">
										<asp:TextBox id="txtKodeKelompok" Runat="server" MaxLength="10" Width="100%" AutoPostBack="True"></asp:TextBox></TD>
									<TD class="rBodyAddNewFld" width="60%">
										<asp:RequiredFieldValidator id="rfvKodeBuku" runat="server" controlToValidate="txtKodeKelompok" errormessage="Kode Kelompok"
											display="dynamic">**</asp:RequiredFieldValidator></TD>
								</TR>
								<TR>
									<TD class="rBodyAddNewFld" width="15%">Nama</TD>
									<TD class="rBodyAddNewFld" width="25%">
										<asp:TextBox id="txtNamaKelompok" Runat="server" MaxLength="50" Width="100%"></asp:TextBox></TD>
									<TD class="rBodyAddNewFld" width="60%">
										<asp:RequiredFieldValidator id="rfvNamaBuku" runat="server" controlToValidate="txtNamaKelompok" errormessage="Nama Kelompok"
											display="dynamic">**</asp:RequiredFieldValidator></TD>
								</TR>
								<TR>
									<TD class="rBodyAddNewFld" width="15%"></TD>
									<TD class="rBodyAddNewFld" width="25%">
										<asp:CheckBox id="cboxAktif" runat="server" Checked="True" text="Aktif"></asp:CheckBox></TD>
									<TD class="rBodyAddNewFld" width="60%"></TD>
								</TR>
							</TABLE>
							<TABLE width="100%">
								<TR>
									<TD align="left" width="50%">
										<asp:Button id="btnSave" runat="server" text="Save" CssClass="sbttn" width="100"></asp:Button>
										<asp:Button id="btnDone" runat="server" CausesValidation="False" text="Close" CssClass="sbttn"
											width="100"></asp:Button>
										<asp:Button id="btnDelete" runat="server" CausesValidation="False" text="Delete" CssClass="sbttn"
											width="100"></asp:Button></TD>
									<TD align="right" width="50%"></TD>
								</TR>
							</TABLE> <!-- VALIDATION SUMMARY BEGIN HERE -->
							<TABLE cellSpacing="0" cellPadding="5" width="100%">
								<TR>
									<TD align="left">
										<P>
											<asp:ValidationSummary id="ValidationSummary" runat="server" HeaderText="Field(s) berikut harus diisi atau perlu diperbaiki."></asp:ValidationSummary></P>
									</TD>
								</TR>
							</TABLE> <!-- VALIDATION SUMMARY END HERE --></TD>
					</TR>
					<TR vAlign="bottom" bgColor="white">
						<TD align="left" height="25">
							<P align="right">Data yang sudah ada...
							</P>
						</TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
	</TABLE>
</asp:panel>
