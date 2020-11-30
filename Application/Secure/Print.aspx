<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Print.aspx.vb" Inherits="QIS.Web.Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Content/bootstrap.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
    

    	.jd_kiri{
    		text-align: left;
    	}

    	.jd_kanan{
    		text-align: right;
    	}

    	.time {
    		font-style: italic;
    	}

    	.btnPrint{
    		margin-left: 75%; 
    		margin-top:5%;
    		width: 12%;
    		margin-bottom: 3%
    	}

    	.img-print{
    		 width: 10%; 
    		 margin-right: 10px;
    	}
    	
    	#progressbar
    	{
    	    margin-bottom: 10px;
    	    width: 1100px;
    	    margin: auto;
    	    overflow: hidden;
    	    
    	}
  
.table-condensed
{
margin-left: 9%;
margin-right: 9%;
}


    </style>
    
</head>
<body>

<button type="button" class="btn btn-outline-primary btnPrint"  onclick="printContent('printMe')">
	 <img src="/qistoollib/images/printer.svg" class="img-print">Print Preview</button>


<section id="printMe">
  		<div class="container jdl">
  			<div class="row ">
  				<div class="col-sm-6 jd_kiri">
  					<h5>CUSTOMER SUPPORT WEEKLY REPORT</h5>
                    <h5 class="id_klien"><asp:Label ID="projectid" runat="server"  Visible="false"></asp:Label></h5>
  					<h5 class="nama_klien"><asp:Label ID="projectnama" runat="server" Visible="true"></asp:Label></h5>
  				</div>

  				<div class="col-sm-6 jd_kanan">
  					<p>Status As of <asp:Label ID="time" runat="server" Visible="true"></asp:Label></p>
  					<p class="time">'This week' is equal to last 7 days from 'As of Date''</p>
  				</div>
  			</div>
  		</div>

  			
            
  			<div class="row" id="progressbar">

  					<div class="card" style="width: 13rem;">
					  <div class="card-body" style="text-align: center;">
					    <h6 class="card-title">Total Reported Issue(s) This Week</h6>
					    <h1 class="reported-issue" ><asp:Label ID="totalreported" runat="server" Visible="true" /></h1>
					  </div>
					</div>

  					<div class="card" style="width: 13rem;">
					  <div class="card-body" style="text-align: center;">
					    <h6 class="card-title">Total Finished Issue(s) This Week</h6>
					    <h1 class="finish-issue" ><asp:Label ID="totalfinished" runat="server" Visible="true" /></h1>
					  </div>
					</div>

  					<div class="card" style="width: 12rem;">
					  <div class="card-body" style="text-align: left; margin-left: 20%; ">
					    <small class="card-title">Open</small><br>
					    <small class="card-title">In Progress</small><br>
					    <small class="card-title">Finish</small><br>
					    <small class="card-title">Need Sample</small><br>
                        <small class="card-title">Dev. Finish</small><br>
					  </div>
					</div>

  					<div class="card" style="width: 10rem;">
					  <div class="card-body" style="text-align: right; margin-left: 20%; ">
					    <small class="card-title"><asp:Label ID="openissue" runat="server" Visible="true" /></small><br>
					    <small class="card-title"><asp:Label ID="progressissue" runat="server" Visible="true" /></small><br>
					    <small class="card-title"><asp:Label ID="finishissue" runat="server" Visible="true" /></small><br>
					    <small class="card-title"><asp:Label ID="needsampleissue" runat="server" Visible="true" /></small><br>
                        <small class="card-title"><asp:Label ID="devfinish" runat="server" Visible="true" /></small><br>
					  </div>
					</div>

                 
                    <div class="card" style="width: 13rem;">
					  <div class="card-body" style="text-align: justify;  ">
					    <small class="card-title">Total Issue(s) Reported</small><br>
					    <small class="card-title">Overall Progress</small><br>
					  </div>
					</div>

                 
  					<div class="card" style="width: 7rem;">
					  <div class="card-body" style="text-align: right;">
					    <small class="card-title"><asp:Label ID="totalissuefull" runat="server" Visible="true" /></small><br>
					    <small class="card-title"><asp:Label ID="overallprogress" runat="server" Visible="true" />% </small><br>
					  </div>
					</div>
  			</div>
  
  
        <asp:DataGrid ID="grdPrintIssue" runat="server"  GridLines="None" Width="80%" ShowHeader="true" ShowFooter="false" 
            AutoGenerateColumns="false"  CssClass="table table-condensed table-hover">
                <Columns>
                <asp:TemplateColumn runat="server" HeaderText="Issue ID" ItemStyle-Width="30" ItemStyle-VerticalAlign="Top">
                        <ItemTemplate>

                            <table>
                                    <tr>
                                        <td>
                                         <%# DataBinder.Eval(Container.DataItem, "issueid")%><br>
                                         Reported by: <%# DataBinder.Eval(Container.DataItem, "reportedBy")%>
                                        </td>
                                    </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    

                    <asp:TemplateColumn runat="server" HeaderText="Issue Description" ItemStyle-Width="100" ItemStyle-VerticalAlign="Top">
                        <ItemTemplate>
                        <table>
                                    <tr>
                                        <td>
                                          <%# DataBinder.Eval(Container.DataItem, "issueDescription")%>
                                        </td>
                                    </tr>
                            </table>
                           
                        </ItemTemplate>
                    </asp:TemplateColumn>

                    <asp:TemplateColumn runat="server" HeaderText="Type" ItemStyle-Width="50" ItemStyle-VerticalAlign="Top">
                        <ItemTemplate>
                        <table>
                                    <tr>
                                        <td>
                                          <%# DataBinder.Eval(Container.DataItem, "IssueType")%>
                                        </td>
                                    </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateColumn>

                    <asp:TemplateColumn runat="server" HeaderText="Status" ItemStyle-Width="100" ItemStyle-VerticalAlign="Top">
                        <ItemTemplate>
                        <table>
                                <th>
                                    <tr>
                                        <td>
                                          <%# DataBinder.Eval(Container.DataItem, "IssueStatus")%> <br>
                                         Target Date: <%# DataBinder.Eval(Container.DataItem, "targetDate")%>
                                        </td>
                                    </tr>
                                </th>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateColumn>


                    <asp:TemplateColumn runat="server" HeaderText="Priority" ItemStyle-Width="60" ItemStyle-VerticalAlign="Top">
                        <ItemTemplate>
                        <table>
                                <th>
                                    <tr>
                                        <td>
                                          <%# DataBinder.Eval(Container.DataItem, "IssuePriority")%>
                                        </td>
                                    </tr>
                                </th>
                            </table>
                            
                        </ItemTemplate>
                    </asp:TemplateColumn>

                    <asp:TemplateColumn runat="server" HeaderText="PIC Dev" ItemStyle-Width="60" ItemStyle-VerticalAlign="Top">
                        <ItemTemplate>
                        <table>
                                <th>
                                    <tr>
                                        <td>
                                          <%# DataBinder.Eval(Container.DataItem, "PICDev")%>
                                        </td>
                                    </tr>
                                </th>
                            </table>
                            
                        </ItemTemplate>
                    </asp:TemplateColumn>
                </Columns>
</asp:DataGrid>

  	</section>

    <script src="../../Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../../Scripts/bootstrap.js" type="text/javascript"></script>
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
