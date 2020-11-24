<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Print.aspx.vb" Inherits=".Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Content/bootstrap.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
    	
    	.jdl {
    		margin-top: 3%;
    	}

    	.card-title{
    		margin-top: 10%
    	}

    	.jd_kiri{
    		text-align: left;
    	}

    	.jd_kanan{
    		text-align: right;
    	}

    	.time {
    		font-style: italic;
    	}

    	.card {
    		width: 18rem; 
    		height: 9rem;
    		text-align: center;
    	}

    	.btnPrint{
    		margin-left: 75%; 
    		margin-bottom: 20px;
    	}

    	.img-print{
    		 width: 15%; 
    		 margin-right: 10px;
    	}
    </style>
    
</head>
<body>
<section id="printMe">
  		<div class="container jdl">
  			<div class="row ">
  				<div class="col-md-6 jd_kiri">
  					<h5>CUSTOMER SUPPORT WEEKLY REPORT</h5>
  					<h5>RS BINTANG LAUT [v1.1] - RSBL</h5>
  				</div>

  				<div class="col-md-6 jd_kanan">
  					<p>Status As of Monday, 5 October, 2020</p>
  					<p class="time">'This week' is equal to last 7 days from 'As of Date''</p>
  				</div>
  			</div>
  		</div>


  		<div class="container"> 
  			<div class="row">
  				<div class="col-md-3">
  					<div class="card">
					  <div class="card-body">
					    <h6 class="card-title">Total Reported Issue(s) This Week</h6>
					    <p class="reported-issue">1</p>
					  </div>
					</div>
  				</div>	
  				<div class="col-md-3">
  					<div class="card">
					  <div class="card-body">
					    <h6 class="card-title">Total Finished Issue(s) This Week</h6>
					    <p class="finish-issue">0</p>
					  </div>
					</div>
  				</div>
  				<div class="col-md-3">
  					<div class="card">
					  <div class="card-body">
					    <small class="card-title">Open &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
					    								 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 1</small><br>
					    <small class="card-title">In Progress &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : 
					    										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 2</small><br>
					    <small class="card-title">Finish &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : 
					    									&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 		125</small><br>
					    <small class="card-title">Need Sample &nbsp;&nbsp; : 
					    									&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 0</small>
					  </div>
					</div>
  				</div>
  				<div class="col-md-3">
  					<div class="card">
					  <div class="card-body">
					    <small class="card-title">Total Issue(s) Reported : 129</small><br>
					    <small class="card-title">Overall Progress : 97 %</small><br>
					  </div>
					</div>
  				</div>
  			</div>
  		</div>

  		<div class="container">
  			<div class="row">
  				<table class="table table-hover" style="width: 100%" >
				  <thead>
				    <tr>
				      <th >No.</th>
				      <th >Issue ID</th>
				      <th >Issue Description</th>
				      <th >Type</th>
				      <th >Status</th>
				      <th >Priority</th>
				      <th >PIC Dev</th>
				    </tr>
				  </thead>
				  <tbody>
				    <tr>
				      <th class="no" id="no">1</th>
				      <td class="issue-id" id="issue-id">202009170000002 <br>
				      									 Reported by:
														 Puspa Marianti</td>
				      <td class="issue-desc" id="issue-desc">Minta tolong ditambahkan laporan penjualan OTC di Farmasi</td>
				      <td class="type" id="type">Request</td>
				      <td class="status" id="status">Dev. Finish <br>
				      								 Target Date: 15-Oct-2020
				      </td>
				      <td class="priority" id="priority">Medium</td>
				      <td class="pic" id="pic">Daniel Prasetyo</td>
				    </tr>

				    <tr>
				      <th >2</th>
				      <td>202009170000002 <br>
				      	Reported by:
						Puspa Marianti</td>
				      <td>Minta tolong ditambahkan laporan penjualan OTC di Farmasi</td>
				      <td>Request</td>
				      <td>Dev. Finish <br>
				      	Target Date: 15-Oct-2020
				      </td>
				      <td>Medium</td>
				      <td>Daniel Prasetyo</td>
				    </tr>

				    <tr>
				      <th >3</th>
				      <td>202009170000002 <br>
				      	Reported by:
						Puspa Marianti</td>
				      <td>Minta tolong ditambahkan laporan penjualan OTC di Farmasi</td>
				      <td>Request</td>
				      <td>Dev. Finish <br>
				      	Target Date: 15-Oct-2020
				      </td>
				      <td>Medium</td>
				      <td>Daniel Prasetyo</td>
				    </tr>

				  </tbody>
				</table>
  			</div>
  		</div>
  	</section>


	 <button type="button" class="btn btn-outline-primary btnPrint"  onclick="printContent('printMe')">
	 <img src="printer.svg" class="img-print">Print</button>

    <script src="../Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Scripts/bootstrap.js" type="text/javascript"></script>
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
