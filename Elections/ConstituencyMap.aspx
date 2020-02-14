<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="ConstituencyMap.aspx.cs" Inherits="Elections_ConstituencyMap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table class="table-form" style="width:30%;">
        <tr>
            <td class="label">Select Type :</td>
            <td>
                <asp:RadioButtonList ID="rdoType" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="NA" Value="NA" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="PA" Value="PA"></asp:ListItem>
                </asp:RadioButtonList>
            </td>

            <td style="text-align: center;">
                <input type="button" value="Search" class="btn" onclick="getMapData()" />
            </td>
        </tr>
    </table>

    <div id="map" style="width: 100%; height: 500px; margin: 10px 0"></div>

    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDAVu93iLS_wvDq-xEGoQ7_I6PdOs-OXUY"></script>
    <script src="../Scripts/jquery.googlemap.js"></script>
    <script>
        $(document).ready(function () {
            getMapData();
        });
        function getMapData() {
            
            var obj = {};
            obj.ProvinceId = $("[id$='ddlProvince']").val();
            obj.DistrictId = $("[id$='ddlDistrict']").val();
            obj.Type = $("[id$='rdoType'] :checked").val();

            $.ajax({
                type: "POST",
                url: "ConstituencyMap.aspx/GetMapData",
                data: JSON.stringify(obj),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    var mapData = result.d;
                    $("#map").googleMap();

                    for (var b = 0; b < mapData.length; b++) {

                        var lt = mapData[b].Latitude;
                        var ln = mapData[b].Longitude;
                        var markerTitle = mapData[b].Name;
                        var candiDateName = mapData[b].CandidateName;                        
                        var Picture = mapData[b].Picture;
                        
                        if (candiDateName != "")
                            markerTitle = markerTitle + "(" + candiDateName + ")";                        

                        $("#map").addMarker({
                            coords: [lt, ln],
                            url: 'http://localhost:17713/Elections/ElectionsSummary.aspx?Id=' + mapData[b].Id + '&&Type=' + $("[id$='rdoType'] :checked").val() + '&&Title=' + mapData[b].Name,
                            id: 'marker1'                            
                        });

                    }
                }
            });
        }

    </script>
</asp:Content>

