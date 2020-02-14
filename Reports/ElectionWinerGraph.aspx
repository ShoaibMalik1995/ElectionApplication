<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="ElectionWinerGraph.aspx.cs" Inherits="Reports_ElectionWinerGraph" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h1>Election Winner
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
            <td class="label" style="width: 10%;">Province:</td>
            <td style="width: 30%;">
                <asp:DropDownList ID="ddlProvince" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"></asp:DropDownList>
            </td>
           
        </tr>
        <tr>
             <td class="label" style="width: 10%;">District:</td>
            <td style="width: 30%;">
                <asp:DropDownList ID="ddlDistrict" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList>
            </td>
            <td></td>  
            <td>
                <asp:RadioButtonList ID="rdoType" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdoType_SelectedIndexChanged">
                    <asp:ListItem Text="NA" Value="NA" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="PA" Value="PA"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
         

        </tr>        
        <tr>
               <td class="label">NA:</td>
            <td>
                <asp:DropDownList ID="ddlNA"  OnSelectedIndexChanged="ddlNA_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
            </td>
            <td  class="label" id="tdPA1" runat="server" style="display:none;">PA:</td>
            <td  id="tdPA2" runat="server" style="display:none;">
                <asp:DropDownList ID="ddlPA" runat="server"></asp:DropDownList>
            </td>

        </tr>
        <tr>
            <td colspan="4" style="text-align: center;">                
                <input type="button" value="Search" class="btn" onclick="getWinner()" />
            </td>
        </tr>

        <tr>

            <td align="center" colspan="4">
                <div style="padding-top: 10px;">
              <div id="WinnerChart" style="width: 50%;"></div>
                </div>
            </td>
        </tr>
    </table>
    <script src="../Scripts/highcharts.js"></script>
      <script language="JavaScript" type="text/javascript">
          function getWinner() {              
              var naId = $("[id$='ddlNA']").val();
              if (naId == null || naId == "") {
                  alert("Please select NA or PA");
                  return false;
              }
              var paId = $("[id$='ddlPA']").val();
              if (paId == null || paId == "")
                  paId = "0";

              var obj = {};
              obj.electionId = $("[id$='ddlYear']").val();
              obj.naId = naId;
              obj.paId = paId;
              obj.type = $("[id$='rdoType'] :checked").val();
            
              $.ajax({
                  type: "POST",
                  url: "ElectionWinerGraph.aspx/GetData",
                  data: JSON.stringify(obj),
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  success: function (response) {                      
                      var result = response.d;
                      var chartData = result.split('- ');
                      var arrComponent = JSON.parse(chartData[0]);
                      var arrData = JSON.parse(chartData[1]);


                      Highcharts.chart('WinnerChart', {
                          chart: {
                              type: 'column'
                          },
                          title: {
                              text: 'Top 3 Winners'
                          },
                          xAxis: {
                              categories: arrComponent,
                              title: {
                                  text: null
                              }
                          },
                          yAxis: {
                              min: 0,
                              labels: {
                                  formatter: function () {
                                      return this.value
                                  }, style: {
                                      color: '#008d4c',
                                      'font-weight': 'bold',
                                  }
                              },
                              title: {
                                  text: 'Votes Obtained', style: {
                                      color: '#008d4c',
                                      'font-weight': 'bold',
                                  }
                              }
                          },
                          tooltip: {
                              valueSuffix: ' millions'
                          },
                          plotOptions: {
                              bar: {
                                  dataLabels: {
                                      enabled: true
                                  }
                              }
                          },
                          legend: {
                              layout: 'vertical',
                              align: 'right',                              
                              verticalAlign: 'top',
                              x: -40,
                              y: 80,
                              floating: true,
                              borderWidth: 1,
                              backgroundColor: ((Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF'),
                              shadow: true
                          },
                          credits: {
                              enabled: false
                          },
                          series: [{
                              name: $("[id$='ddlYear'] :selected").text(),
                              data: arrData
                          }]
                      });

                  }
              });

          }
    </script>
</asp:Content>

