<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="VotersComparison.aspx.cs" Inherits="Reports_VotersComparison" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h1>Election Winner
      <span style="padding-left: 100px">
          <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
      </span>
    </h1>
    
                <div style="padding-top: 10px;">
              <div id="VotersComparison" style="width: 50%;"></div>
                    <div id="container" style="width: 50%;"></div>
                </div>

    <script src="../Scripts/highcharts.js"></script>
      <script language="JavaScript" type="text/javascript">
          Highcharts.chart('container', {
              chart: {
                  type: 'bar'
              },
              title: {
                  text: 'Historic World Population by Region'
              },
              subtitle: {
                  text: 'Source: <a href="https://en.wikipedia.org/wiki/World_population">Wikipedia.org</a>'
              },
              xAxis: {
                  categories: ['Africa', 'America', 'Asia', 'Europe', 'Oceania'],
                  title: {
                      text: null
                  }
              },
              yAxis: {
                  min: 0,
                  title: {
                      text: 'Population (millions)',
                      align: 'high'
                  },
                  labels: {
                      overflow: 'justify'
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
                  name: '2008',
                  data: [5, 3, 4, 7, 2]                  
              }, {
                  name: '2013',
                  data: [3, 4, 4, 2, 5]
              }
              ]
          });

          chart.addSeries({
              name: 'ADBE',
              data: ADBE
          }, false);

          $(document).ready(function() {
              getVotersComparison();
          })
          function getVotersComparison() {                                     
              $.ajax({
                  type: "POST",
                  url: "VotersComparison.aspx/GetData",
                  data: {},
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  success: function (response) {
                      debugger;
                      var result = response.d;
                      var chartData = result.split('- ');
                      var arrProvince = JSON.parse(chartData[0]);
                      var arrVoters = JSON.parse(chartData[1]);                      
                      var arrYears = JSON.parse(chartData[2]);


                      Highcharts.chart('VotersComparison', {
                          chart: {
                              type: 'column'
                          },
                          title: {
                              text: 'Registered Voters Comparison'
                          },
                          xAxis: {
                              categories: arrProvince,
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
                              name: arrYears,
                              data: arrVoters
                          }]
                      });

                  }
              });

          }
    </script>
</asp:Content>

