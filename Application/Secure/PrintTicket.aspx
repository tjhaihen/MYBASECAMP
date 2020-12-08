<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PrintTicket.aspx.vb" Inherits="QIS.Web.PrintTicket" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Print_Issue_Ticket</title>
    <%--<link href="../Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Content/bootstrap.css" rel="stylesheet" type="text/css" />--%>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous">

    <style type="text/css">
        .btnPrint{
    		margin-left: 75%; 
    		width: 11%;
    		margin-bottom: 3%
    	}
    </style>
</head>
<body style="margin-top: 3%; margin-bottom: 3%">

<button type="button" class="btn btn-outline-primary btnPrint"  onclick="printContent('printMe')">
	 <img src="/qistoollib/images/printer.svg" class="img-print" style="width:15%"> Print Preview</button>


<section id="printMe">
    <div class="container">
    	<div class="row">
    		<div class="col-md-6"><h4>FORMULIR ISSUE TIKET</h4></div>
    		<div class="col-md-6" style="text-align: right;"><h4>Issue ID # <asp:Label ID="issueid" runat="server"  Visible="true"></asp:Label> | 
                                                                            <asp:Label ID="projectaliasname" runat="server"  Visible="true"></asp:Label></h4></div>
                                                                            <asp:Label ID="userIDprint" runat="server"  Visible="false"></asp:Label>
    	</div>

    	<hr>

    	<div class="row" style="margin-bottom: 1%">
    		<div class="col-md-6">
    			<table>
    				<tr>
    					<td><b>Nama RS</b></td>
    					<td>:</td>
    					<td><asp:Label ID="projectName" runat="server"  Visible="true"></asp:Label></td>
    				</tr>
    				<tr>
    					<td><b>Tanggal Lapor</b></td>
    					<td>:</td>
    					<td><asp:Label ID="reportedDate" runat="server"  Visible="true"></asp:Label></td>
    				</tr>
    			</table>
    		</div>
    		<div class="col-md-6">
    			<table>
    				<tr>
    					<td><b>Dari Departemen</b> </td>
    					<td>:</td>
    					<td><asp:Label ID="departmentName" runat="server"  Visible="true"></asp:Label></td>
    				</tr>
    				<tr>
    					<td><b>Dilaporkan Oleh</b></td>
    					<td>:</td>
    					<td><asp:Label ID="reportedBy" runat="server"  Visible="true"></asp:Label></td>
    				</tr>
    			</table>
    		</div>
    	</div>

    	<table class="table">
	   		<thead>
    			<th colspan="10" class="table-info">Masalah Dilaporkan</th>
    		</thead>
    		<tr>
    			<td>Deskripsi</td>
    			<td>:</td>
    			<td colspan="7"><asp:Label ID="issueDescription" runat="server"  Visible="true"></asp:Label></td>
    		</tr>
    		<tr>
    			<td width="20%">Prioritas</td>
    			<td>:</td>
    			<td  width="50%"><asp:Label ID="issuePriorityName" runat="server"  Visible="true"></asp:Label></td>
    			<td width="20%">Status Masalah</td>
    			<td>:</td>
    			<td><asp:Label ID="issueStatus" runat="server"  Visible="true"></asp:Label></td>
    		</tr>
    		<tr>
    			<td width="20%">Tipe</td>
    			<td>:</td>
    			<td width="50%"><asp:Label ID="issueType" runat="server"  Visible="true"></asp:Label></td>
    			<td width="20%">Konfirmasi Status</td>
    			<td>:</td>
    			<td><asp:Label ID="issueConfirmStatus" runat="server"  Visible="true"></asp:Label></td>
    		</tr>
    	</table>

   <table class="table">
	   	<thead>
	   		<th colspan="5" class="table-info">Tanggapan Masalah</th>
	   		<th colspan="5" style="text-align: right" class="table-info">Tanggapan atas masalah yang dilaporkan dari Tim Medinfras</th>
	   	</thead>
	   <tr>
	   		<td width="20%"><b>Tanggal dan Waktu</b></td>
	   		<td colspan="8"><b>Deskripsi Tanggapan</b></td>
	   		<td width="17%"><b>Tanggapan Oleh</b></td>
	   	</tr>
	   	<tr>
	   		<td width="15%"><asp:Label ID="responseDate" runat="server"  Visible="true"></asp:Label> <br>  
                            <asp:Label ID="responseTime" runat="server"  Visible="true"></asp:Label> - <asp:Label ID="responseDuration" runat="server"  Visible="true"></asp:Label> min.
            </td>
	   		<td colspan="8"><asp:Label ID="responseDescription" runat="server"  Visible="true"></asp:Label></td>
	   		<td width="15%"><asp:Label ID="responseBy" runat="server"  Visible="true"></asp:Label></td>
	   	</tr>
   </table>

 <table class="table">
  	<tr>
  		<td width="70%">Tercetak : <asp:Label ID="datenow" runat="server"  Visible="true"></asp:Label> by: <asp:Label ID="userprint" runat="server"  Visible="true"></asp:Label></td>
  		<td width="15%"><b>Tim Medinfras :</b></td>
  		<td width="15%"><b>Diakui oleh :</b></td>
  	</tr>
  	<tr>
  		<td width="70%"><b>Catatan Lainnya :</b></td>
  		<td width="15%"></td>
  		<td width="15%"></td>
  	</tr>
  	<tr>
  		<td width="70%"></td>
  		<td width="15%"><asp:Label ID="medinfrasteam" runat="server"  Visible="true"></asp:Label></td>
  		<td width="15%"></td>
  	</tr>
  </table>

    	<hr>

    	<div class="row">
    		<div class="col-md-7">
    			<b>Untuk informasi lebih lanjut, Anda dapat menghubungi kami di :</b> <br>
    			Quantum Infra Solusindo, PT <br>
    			Ruko Golden 8 Blok H No. 40 <br>
				Gading Serpong, Tangerang 15810
    		</div>
    		<div class="col-md-5">
    			<table>
    				<tr>
    					<td>Telepon</td>
    					<td>:</td>
    					<td><b>(021) 2941 9116</b></td>
    				</tr>
    				<tr>
    					<td>Fax</td>
    					<td>:</td>
    					<td><b>021) 2923 9817</b></td>
    				</tr>
    				<tr>
    					<td>Email</td>
    					<td>:</td>
    					<td><b>support@medinfras.com</b></td>
    				</tr>
    			</table>
    		</div>
    	</div>


    </div>


  	</section>


    <%--<script src="../../Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../../Scripts/bootstrap.js" type="text/javascript"></script>--%>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ho+j7jyWK8fNQe+A12Hb8AhRq26LrZ/JpcUGGOn+Y7RsweNrtN/tE3MoK7ZeZDyx" crossorigin="anonymous"></script>
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script type="text/javascript">
        function printContent(el) {
            var restorepage = document.body.innerHTML;
            var printcontent = document.getElementById(el).innerHTML;
            document.body.innerHTML = printcontent;
            window.print();
            document.body.innerHTML = restorepage;
        }
	</script>
</body>
</html>
