<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="Map.aspx.cs" Inherits="Elections_Map" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="map" style="width: 100%; height: 500px; margin: 10px 0"></div>

    <script>

        (function () {

            window.onload = function () {

                // Creating a new map
                var map = new google.maps.Map(document.getElementById("map"), {
                    center: new google.maps.LatLng(32.273894, 72.914446),
                    zoom: 6,
                    mapTypeId: google.maps.MapTypeId.ROADMAP
                });


                $.ajax({
                    type: "POST",
                    url: "Map.aspx/GetMapData",
                    data: {},
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (result) {
                        var mapData = result.d;
                        var listDivisions = mapData[0].listDivisions;
                        var listNA = mapData[0].listNA;
                        var listPA = mapData[0].listPA;
                        var infoData = "";

                        // Creating a global infoWindow object that will be reused by all markers

                        var infoWindow = new google.maps.InfoWindow({ maxWidth: 200 });

                        // Looping through the JSON data
                        for (var d = 0; d < listDivisions.length; d++) {

                            var lt = eval(listDivisions[d].Latitude);
                            var ln = eval(listDivisions[d].Longitude);
                            var divisionName = listDivisions[d].Division;
                            var divisionId = listDivisions[d].DivisionId;

                            var divisionWiseNA = jQuery.grep(listNA, function (n, i) {
                                return (n.DivisionId == divisionId.trim());
                            });
                            var naHtml = "";
                            for (var n = 0; n < divisionWiseNA.length; n++) {
                                var naId = divisionWiseNA[n].NAId;
                                var naName = "";

                                naName = divisionWiseNA[n].NAName;

                                var paHtml = "";
                                var naWisePA = jQuery.grep(listPA, function (n, i) {
                                    return (n.NAId == naId);
                                });
                                
                                for (var p = 0; p < naWisePA.length; p++) {
                                    var paName = "", paId = "0";

                                    paName = naWisePA[p].PAName;
                                    paId = naWisePA[p].PAId;

                                    if (p == 0)
                                        paHtml += '<span  onclick="showStatsPA(' + naId + ',' + paId + ',\'' + paName + '\');">' + paName + '</span>';
                                    else
                                        paHtml += ' , <span  onclick="showStatsPA(' + naId + ',' + paId + ',\'' + paName + '\');">' + paName + '</span>';

                                }

                                paHtml = "<div class='mapPA'>" + paHtml + "</div>";
                                naHtml += '<div class="mapNA"><span  onclick="showStatsNA(' + naId + ',\'' + naName + '\');">' + naName + '</span>' + paHtml + '</div>';
                                //naHtml += "<div class='mapNA'><span onclick='showStatsNA(" + naId + ",'" + naName + "')'>" + naName + "</span>" + paHtml + "</div>";

                            }

                            infoData = "<div>" + naHtml + "</div>";

                            var data = { "title": divisionName, "lat": lt, "lng": ln, "description": infoData };
                            var latLng = new google.maps.LatLng(data.lat, data.lng);
                            // Creating a marker and putting it on the map
                            var marker = new google.maps.Marker({
                                position: latLng,
                                map: map,
                                title: data.title
                            });

                            // Creating a closure to retain the correct data, notice how I pass the current data in the loop into the closure (marker, data)
                            (function (marker, data) {
                                // Attaching a click event to the current marker
                                google.maps.event.addListener(marker, "click", function (e) {
                                    infoWindow.setContent(data.description);
                                    infoWindow.open(map, marker);
                                });
                            })(marker, data);
                        }
                    }
                });

            }

        })();

        function showStatsPA(naId,paId,name) {
            window.open("../Elections/ElectionsSummaryPA.aspx?NAId=" + naId + "&PAId=" + paId + "&Type=PA&Title=" + name, '_blank');
        }

        function showStatsNA(naId, name) {
            window.open("../Elections/ElectionsSummary.aspx?NAId=" + naId + "&PAId=0&Type=NA&Title=" + name, '_blank');
        }

    </script>
    <%--<script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyC-tyEsVlz5ztPV7Q74pggkyJ6CoTitRbk&sensor=false">
    </script>--%>
    <script  src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDAVu93iLS_wvDq-xEGoQ7_I6PdOs-OXUY&sensor=false"></script>
    <%--<script src="../Scripts/jquery.googlemap.js"></script>--%>
</asp:Content>

