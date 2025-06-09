<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PermintaanPembelian.aspx.vb"
    Inherits="QIS.Web.PermintaanPembelian" %>

<%@ Register TagPrefix="Module" TagName="RadMenu" Src="../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="CSSToolbar" Src="../../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="webcal" Src="../../incl/calendar.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Permintaan Pembelian</title>
    <link rel="title icon" href="/qistoollib/images/favicon.png" />
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href="/qistoollib/css/styles_blue.css" type="text/css" rel="Stylesheet" />
    <script language="javascript" type="text/javascript" src="/qistoollib/scripts/JScript.js"></script>
    <style type="text/css">
        #ulRepDateInMonthDt
        {
            width: 100%;
            margin: 0;
            padding: 0;                     
        }
        #ulRepDateInMonthDt li
        {
            list-style-type: none;
            display: inline-block; /* FF3.6; Chrome10+ */                     
            *display: inline;
            background: #606060;
            width: 20px;
            height: 20px;
            margin: 0px;
        }
        #ulRepDateInMonth
        {
            width: 100%;
            margin: 0;
            padding: 0;                     
        }
        #ulRepDateInMonth li
        {
            list-style-type: none;            
        }
    </style>
</head>
<body onload="ShowPosting();fokus();">
    <form id="frmPermintaanPembelian" runat="server">
    <table width="100%" cellspacing="0" cellpadding="2">
        <tr>
            <td valign="top" style="width: 100%;">
                <Module:RadMenu ID="RadMenu" runat="server"></Module:RadMenu>
            </td>
        </tr>
        <tr>
            <td class="hseparator" colspan="3">
            </td>
        </tr>
        <tr>
            <td width="100%" valign="top">
                <Module:CSSToolbar ID="CSSToolbar" runat="server"></Module:CSSToolbar>
            </td>
        </tr>
        <tr>
            <td class="hseparator" colspan="3">
            </td>
        </tr>
        <tr>
            <td width="100%" height="100%" valign="top">
                <div style="width: 100%; height: 100%; overflow: auto;">
                    <table cellspacing="10" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td align="left">
                                <table cellspacing="0" cellpadding="5" width="100%">
                                    <tr class="rbody">
                                        <td class="rbodycol" align="center" height="25">
                                            <table width="100%">
                                                <tr>
                                                    <td width="50%" valign="TOP">
                                                        <table width="100%">
                                                            <tr>
                                                                <td width="30%">
                                                                    <asp:linkbutton id="lbtnNoBukti" runat="server" causesvalidation="False" text="No. Permintaan" ForeColor="blue">
						                                            </asp:linkbutton>
                                                                </td>
                                                                <td>
                                                                    <asp:textbox id="txtNoBukti" runat="server" autopostback="True" width="40%">
						                                            </asp:textbox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="30%">
                                                                    Tanggal Permintaan
                                                                </td>
                                                                <td>
                                                                    <module:webcal id="calTglMinta" runat="server" dontresetdate="true">
						                                            </module:webcal>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="50%">
                                                        <table width="100%">
                                                            <tr>
                                                                <td width="30%">
                                                                    Ke Departemen
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList id="ddlDepTujuan" runat="server" autopostback="True" width="50%">
						                                            </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="30%">
                                                                    Dari Departemen
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList id="ddlDepAsal" runat="server" autopostback="True" width="50%">
						                                            </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="30%" valign="top">
                                                                    Keterangan
                                                                </td>
                                                                <td>
                                                                    <asp:textbox id="txtKeterangan" runat="server" autopostback="False" textmode="MultiLine"
                                                                        width="95%">
						                                            </asp:textbox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:Panel ID="panelPermintaanAddNewRow" runat="server">
                                                <table class="rBodyAddNew" cellspacing="0" bordercolordark="#98aab1" cellpadding="5"
                                                    width="100%">
                                                    <tr class="rheader">
                                                        <td class="rheadercol">
                                                            <asp:Label ID="lblMinta" runat="server" Text="Edit atau Tambah Item Permintaan Pembelian" ForeColor="White"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td class="rBodyAddNewFld" valign="top" width="50%">
                                                                        <table cellspacing="1" cellpadding="1" width="100%">
                                                                            <tr>
                                                                                <td class="rBodyAddNewFld" width="30%">
                                                                                </td>
                                                                                <td class="rBodyAddNewFld">
                                                                                    <asp:TextBox ID="Permintaan_AddNewRow_txtCounter" runat="server" Visible="False"
                                                                                        Width="95%">
                                                                                    </asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rBodyAddNewFld" width="30%">
                                                                                    Nama Item
                                                                                </td>
                                                                                <td class="rBodyAddNewFld">
                                                                                    <asp:TextBox ID="Permintaan_AddNewRow_txtNamaItem" runat="server" Width="95%">
                                                                                    </asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="rfvPermintaan_AddNewRow_txtNamaItem" runat="server"
                                                                                        Display="dynamic" ErrorMessage="Nama Item" ControlToValidate="Permintaan_AddNewRow_txtNamaItem">** 
                                                                                    </asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rBodyAddNewFld" width="30%">
                                                                                    Kuantitas
                                                                                </td>
                                                                                <td class="rBodyAddNewFld">
                                                                                    <asp:TextBox ID="Permintaan_AddNewRow_txtKuantitas" runat="server" text="0.00"
                                                                                        Width="35%" style="text-align: right;">
                                                                                    </asp:TextBox>
                                                                                    <asp:CompareValidator ID="cvKuantitas1" runat="server" ControlToValidate="Permintaan_AddNewRow_txtKuantitas"
                                                                                        Operator="GreaterThan" Type="Double" ValueToCompare="0.00" ErrorMessage="Kuantitas"
                                                                                        Display="Dynamic">** Harus berupa angka & lebih dari 0.00 
                                                                                    </asp:CompareValidator>
                                                                                    <asp:RequiredFieldValidator ID="rfvPermintaan_AddNewRow_txtKuantitas" runat="server"
                                                                                        Display="dynamic" ErrorMessage="Kuantitas" ControlToValidate="Permintaan_AddNewRow_txtKuantitas">** 
                                                                                    </asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rBodyAddNewFld" width="30%">
                                                                                    Saldo
                                                                                </td>
                                                                                <td class="rBodyAddNewFld">
                                                                                    <asp:TextBox ID="Permintaan_AddNewRow_txtSaldo" runat="server"
                                                                                        Width="35%" Text="0.00" style="text-align: right;">
                                                                                    </asp:TextBox>
                                                                                    **Diisi Oleh Sekretariat/Bagian Keuangan
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td class="rBodyAddNewFld" valign="top">
                                                                        <table cellspacing="1" cellpadding="1" width="100%">
                                                                            <tr>
                                                                                <td width="30%">
                                                                                    Tanggal Dibutuhkan
                                                                                </td>
                                                                                <td>
                                                                                    <module:webcal id="Permintaan_AddNewRow_calTglButuh" runat="server" dontresetdate="true"></module:webcal>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="rBodyAddNewFld" width="30%" valign="top">
                                                                                    Spesifikasi/Catatan
                                                                                </td>
                                                                                <td class="rBodyAddNewFld">
                                                                                    <asp:TextBox ID="Permintaan_AddNewRow_txtKeterangan" runat="server" AutoPostBack="False" TextMode="MultiLine"
                                                                                        Wrap="True" Width="95%" Height="50">
                                                                                    </asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="Permintaan_btnAddNewRow" runat="server" Text="Save" CssClass="sbttn"
                                                                            Width="100" AccessKey="V"></asp:Button>
                                                                        <asp:Button ID="Permintaan_btnDone" runat="server" text="Close" CausesValidation="False"
                                                                            CssClass="sbttn" Width="100" AccessKey="D"></asp:Button>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <table width="100%">
                                                <tr>
                                                    <td width="100%" height="100%">
                                                        <asp:datagrid id="gridPermintaan" runat="server" width="100%" autogeneratecolumns="False"
                                                            cellspacing="0" bordercolor="Gainsboro" borderwidth="1" gridlines="Horizontal"
                                                            height="100%" datakeyfield="counter" showfooter="True" cellpadding="0" allowsorting="True">
				                                            <HeaderStyle CssClass="gridHeaderStyle" />
                                                            <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                            <EditItemStyle Font-Bold="false" />
                                                            <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                            <SelectedItemStyle BackColor="CornflowerBlue" />
				                                            <COLUMNS>
					                                            <ASP:EDITCOMMANDCOLUMN 
						                                            RUNAT="server" 
						                                            EDITTEXT="<img src=/qislib/images/edit.png border=0 align=absmiddle alt='Edit this item'>"
						                                            UPDATETEXT="<img src=/qislib/images/done.png border=0 align=absmiddle alt='Save changes'>" 
						                                            CANCELTEXT="<img src=/qislib/images/cancel.png border=0 align=absmiddle alt='Cancel editing'>">
						                                            <ITEMSTYLE HORIZONTALALIGN="center" width="26px"></ITEMSTYLE>
					                                            </ASP:EDITCOMMANDCOLUMN>
					                                            <ASP:TEMPLATECOLUMN ItemStyle-WIdth="26px">
						                                            <ITEMTEMPLATE>
							                                            <ASP:IMAGEBUTTON 
								                                            RUNAT="server" 
								                                            ID="__ibtnDelete" 
								                                            CAUSESVALIDATION="False" 
								                                            IMAGEURL="/qislib/images/delete.png"
								                                            ALTERNATETEXT="Delete this item" 
								                                            COMMANDNAME="__delete"
                                                                            Visible='<%# iif(DataBinder.Eval(Container.DataItem, "posting")=true, false, true) %>' 
								                                            style="margin-top:2">
							                                            </ASP:IMAGEBUTTON>
						                                            </ITEMTEMPLATE>
					                                            </ASP:TEMPLATECOLUMN>
					                                            <ASP:BOUNDCOLUMN DATAFIELD="nominta" VISIBLE="False"></ASP:BOUNDCOLUMN>
					                                            <ASP:TEMPLATECOLUMN 
						                                            RUNAT="server" 
						                                            HEADERTEXT="Counter" 
						                                            HEADERSTYLE-HORIZONTALALIGN="Center" 
						                                            ITEMSTYLE-HORIZONTALALIGN="Left"
						                                            VISIBLE="False">
						                                            <ITEMTEMPLATE>
							                                            <ASP:LABEL
								                                            RUNAT="server"	
								                                            STYLE="margin-left:5;margin-right:5" 
								                                            TEXT='<%# DataBinder.Eval(Container.DataItem, "counter") %>' 
								                                            ID="_lblCounter">
							                                            </ASP:LABEL>
						                                            </ITEMTEMPLATE>
					                                            </ASP:TEMPLATECOLUMN>
					                                            <asp:TemplateColumn		SortExpression="usrupdate"
											                                            runat="server"
											                                            HeaderText="Petugas" 
											                                            HeaderStyle-HorizontalAlign="Left" 
											                                            ItemStyle-HorizontalAlign="Left"> 
						                                            <itemtemplate>
							                                            <asp:label		runat="server" 
											                                            style="margin-left:5;margin-right:5"
											                                            Text='<%# DataBinder.Eval(Container.DataItem, "nmuser") %>' 
											                                            ID="_lblPetugas"/>
						                                            </itemtemplate>
					                                            </asp:TemplateColumn >
					                                            <ASP:TEMPLATECOLUMN 
						                                            SortExpression="nmbarang1" 
						                                            RUNAT="server" 
						                                            HEADERTEXT="Nama Item" 
						                                            ITEMSTYLE-HORIZONTALALIGN="Left" 
						                                            HEADERSTYLE-HORIZONTALALIGN="Left">
						                                            <ITEMTEMPLATE>
							                                            <ASP:LABEL
								                                            RUNAT="server"	
								                                            STYLE="margin-left:5;margin-right:5" 
								                                            TEXT='<%# DataBinder.Eval(Container.DataItem, "nmbarang") %>' 
								                                            ID="_lblNamaItem">
							                                            </ASP:LABEL>
						                                            </ITEMTEMPLATE>
						                                            <FOOTERTEMPLATE>
							                                            <ASP:LINKBUTTON 
								                                            RUNAT="server" 
								                                            ID="_btnAddNewRow" 
								                                            CAUSESVALIDATION="True" 
								                                            COMMANDNAME="_AddNewRow"
								                                            ONMOUSEOVER="window.status='Click here to add new record.';return true" 
								                                            ONMOUSEOUT="window.status='';return true;"
								                                            TITLE="Click here to add new record." 
								                                            Text="Tambah Data" 
								                                            ACCESSKEY="A"
                                                                             ForeColor="blue">
							                                            </ASP:LINKBUTTON>
						                                            </FOOTERTEMPLATE>
					                                            </ASP:TEMPLATECOLUMN>
					                                            <ASP:TEMPLATECOLUMN 
						                                            SortExpression="qty" 
						                                            RUNAT="server" 
						                                            HEADERTEXT="Kuantitas" 
						                                            ITEMSTYLE-HORIZONTALALIGN="Right" 
						                                            HEADERSTYLE-HORIZONTALALIGN="Right">
						                                            <ITEMTEMPLATE>
							                                            <ASP:LABEL
								                                            RUNAT="server" 
								                                            STYLE="margin-left:5;margin-right:5" 
								                                            TEXT='<%# DataBinder.Eval(Container.DataItem, "qty") %>' 
								                                            ID="_lblKuantitas">
							                                            </ASP:LABEL>
						                                            </ITEMTEMPLATE>
					                                            </ASP:TEMPLATECOLUMN>	
                                                                <ASP:TEMPLATECOLUMN 
						                                            SortExpression="saldo" 
						                                            RUNAT="server" 
						                                            HEADERTEXT="Saldo" 
						                                            ITEMSTYLE-HORIZONTALALIGN="Center" 
						                                            HEADERSTYLE-HORIZONTALALIGN="Center">
						                                            <ITEMTEMPLATE>
							                                            <ASP:Label
								                                            RUNAT="server" 
								                                            STYLE="margin-left:5;margin-right:5" 
								                                            TEXT='<%# DataBinder.Eval(Container.DataItem, "saldo") %> ' 
								                                            ID="_lblSaldo">
							                                            </ASP:Label>
						                                            </ITEMTEMPLATE>
					                                            </ASP:TEMPLATECOLUMN>	
					                                            <ASP:TEMPLATECOLUMN 
						                                            SortExpression="tglButuh" 
						                                            RUNAT="server" 
						                                            HEADERTEXT="Tgl. Dibutuhkan" 
						                                            ITEMSTYLE-HORIZONTALALIGN="Right" 
						                                            HEADERSTYLE-HORIZONTALALIGN="Right">
						                                            <ITEMTEMPLATE>
							                                            <ASP:LABEL
								                                            RUNAT="server" 
								                                            STYLE="margin-left:5;margin-right:5" 
								                                            TEXT='<%# Format(DataBinder.Eval(Container.DataItem, "tgldibutuhkan"), "dd-MM-yyyy")%>'
								                                            ID="_lblTglButuh">
							                                            </ASP:LABEL>
						                                            </ITEMTEMPLATE>
					                                            </ASP:TEMPLATECOLUMN>	
					                                            <ASP:TEMPLATECOLUMN 
						                                            SortExpression="Keterangan" 
						                                            RUNAT="server" 
						                                            HEADERTEXT="Spesifikasi/Catatan" 
						                                            ITEMSTYLE-HORIZONTALALIGN="Right" 
						                                            HEADERSTYLE-HORIZONTALALIGN="Right">
						                                            <ITEMTEMPLATE>
							                                            <ASP:LABEL
								                                            RUNAT="server" 
								                                            STYLE="margin-left:5;margin-right:5" 
								                                            TEXT='<%# DataBinder.Eval(Container.DataItem, "Keterangan") %>' 
								                                            ID="_lblKeterangan">
							                                            </ASP:LABEL>
						                                            </ITEMTEMPLATE>
					                                            </ASP:TEMPLATECOLUMN>	
				                                            </COLUMNS>
			                                            </asp:datagrid>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <table cellspacing="0" cellpadding="5" width="100%">
                                    <tr>
                                        <td align="left">
                                            <p>
                                                <asp:ValidationSummary ID="ValidationSummary" runat="server" HeaderText="Field(s) berikut harus diisi atau perlu diperbaiki.">
                                                </asp:ValidationSummary>
                                            </p>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>

    </form>
    <script language="javascript" src="/qislib/scripts/common/common.js"></script>
    <script language="vbscript" src="/qislib/scripts/common/common.vbs"></script>
    <script language="vbscript">
			Public Function ditrim(ByVal x)
				ditrim = Trim(x)			
			End Function			
    </script>
</body>
</html>
