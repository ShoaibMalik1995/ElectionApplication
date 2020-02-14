<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="PartiesVotes.aspx.cs" Inherits="Reports_PartiesVotes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h1>Parties Votes
      <span style="padding-left: 100px">
          <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
      </span>
    </h1>
    <table class="table-form">

        <tr>
            <td class="label" style="width: 10%;">Year:</td>
            <td style="width: 30%;">
                <asp:DropDownList ID="ddlYear"  runat="server"></asp:DropDownList>
            </td>
               <td  style="text-align: left;">                
                <input type="button" value="Search" class="btn" onclick="getPartiesVotes()" />
            </td>
        </tr>       
        <tr>
            <td align="center" colspan="3">
                <div style="padding-top: 10px;">
              
                <div id="PartiesVotes" style="width: 50%;"></div>
                </div>
            </td>
        </tr>
    </table>
    <script src="../Scripts/highcharts.js"></script>
      <script language="JavaScript" type="text/javascript">
          function getPartiesVotes() {             
              var obj = {};
              obj.electionId = $("[id$='ddlYear']").val();
            
              $.ajax({
                  type: "POST",
                  url: "PartiesVotes.aspx/GetData",
                  data: JSON.stringify(obj),
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  success: function (response) {                      
                      var result = response.d;
                      var chartData = result.split('-');
                      var arrParty = JSON.parse(chartData[0]);
                      var arrVotes = JSON.parse(chartData[1]);
                     
                      var chart = Highcharts.chart('PartiesVotes', {
                          chart: {
                              plotBackgroundColor: null,
                              plotBorderWidth: null,
                              plotShadow: false,
                              type: 'pie'
                          },
                          title: {
                              text: 'Parties Vote Sharing'
                          },                          
                          plotOptions: {
                              pie: {
                                  allowPointSelect: true,
                                  cursor: 'pointer',
                                  dataLabels: {
                                      enabled: true,
                                      format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                                      style: {
                                          color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                                      }
                                  }
                              }
                          },
                          series: [{                              
                              data: (function () {                                  
                                  var data = [];
                                  for (i = 0; i <= arrParty.length; i++) {                                    
                                      data.push({
                                          name: arrParty[i],
                                          y: arrVotes[i]
                                      });
                                  }
                                  return data;
                              }())
                          }]
                      });

                  }
              });

          }
    </script>
</asp:Content>

