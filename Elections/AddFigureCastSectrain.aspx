<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="AddFigureCastSectrain.aspx.cs" Inherits="Figures_AddFigureCastSectrain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h1>PA Figures
     
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
               <asp:DropDownList ID="ddlDivisions"  runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDivisions_SelectedIndexChanged">
                    
                </asp:DropDownList>

                <asp:DropDownList ID="ddlProvince" Visible="false" runat="server">
                    <asp:ListItem Text="Punjab" Value="4"></asp:ListItem>
                </asp:DropDownList>
            </td>

        </tr>
        <tr>
            <td class="label" style="width: 10%;">District:</td>
            <td style="width: 30%;">
                <asp:DropDownList ID="ddlDistrict" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList>
            </td>
            <td class="label">NA:</td>
            <td>
                <asp:DropDownList ID="ddlNA" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlNA_SelectedIndexChanged"></asp:DropDownList>
            </td>

        </tr>

        <tr>
            <td class="label" style="width: 10%;">PA:</td>
            <td style="width: 30%;">
                <asp:DropDownList ID="ddlPA" AutoPostBack="true" runat="server"></asp:DropDownList>
            </td>
            <td colspan="2" style="text-align: center;">
                <asp:Button ID="btn_save" Text="Search" CssClass="btn" runat="server" OnClick="btn_save_Click" />

            </td>
        </tr>

        <tr>
            <td align="center" colspan="4">
                <div style="padding-top: 10px;">
                </div>
            </td>
        </tr>
    </table>

    <div id="dvAccordian" style="width: 100%">
        <h3>Add Figure</h3>
        <div style="display: inline; width: 100%">
            <table class="table-form" style="width: 100%">
                <tr>
                    <td class="label">Male Polling Station:</td>

                    <td>
                        <asp:TextBox ID="txtMalePStation" runat="server"></asp:TextBox>
                    </td>

                    <td class="label">Femael Polling Station:</td>
                    <td>
                        <asp:TextBox ID="txtFeMalePStation" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="label">Male Voters:</td>

                    <td>
                        <asp:TextBox ID="txtMaleVoters" runat="server"></asp:TextBox>
                    </td>

                    <td class="label">Female Voters:</td>
                    <td>
                        <asp:TextBox ID="txtFemaleVoters" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td colspan="4" style="text-align: center">
                        <asp:Button ID="btnSaveVoters" Text="Save" CssClass="btn" runat="server" OnClick="btnSaveVoters_Click" />
                        <asp:HiddenField ID="hdnFigureId" runat="server" Value="0" />
                    </td>
                </tr>
            </table>
        </div>

        <h3>Add Cast</h3>
        <div id="dvAccordianCast" style="width: 100%; display: inline">
            <table>
                <tr>
                    <td style="width: 50%;">

                        <table class="table-form">
                            <tr>
                                <td class="label" style="width:20%;">
                                    Cast:
                                </td>   
                                <td>
                                     <asp:DropDownList  ID="ddlCast" runat="server"></asp:DropDownList>
                                </td>

                            </tr>
                            <tr>
                                <td  class="label">
                                    Percentage:
                                    </td>
                                <td>
                                    <asp:TextBox  ID="txtboxCastPercentage" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: center">
                                    <asp:Button ID="btnSaveCast" Text="Save" CssClass="btn" runat="server" OnClick="btnSaveCast_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 50%; vertical-align:top; text-align:center">

                        <asp:GridView ID="grdCasts" CssClass="table-bordered table-striped" AutoGenerateColumns="False" runat="server" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="Ser">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Cast">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCast" runat="server" Text='<%#Bind("CastName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Percentage">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPercentage" runat="server" Text='<%#Bind("Percentage") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>                                        
                                        <asp:LinkButton ID="lnkdeleteCasts" OnClientClick="return confirmDelete()" CssClass="icon-delete"  OnClick="lnkdeleteCasts_Click" runat="server"></asp:LinkButton>

                                        <asp:HiddenField ID="hdnPAId" Value='<%#Bind("PAId") %>' runat="server" />
                                        <asp:HiddenField ID="hdnCastId" Value='<%#Bind("CastId") %>' runat="server" />
                                        <asp:HiddenField ID="hdnElectionId" Value='<%#Bind("ElectionId") %>' runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        <h3>Add Sectarian</h3>
        <div id="dvAccordianSectrain" style="width: 100%; display: inline">
           <table>
                <tr>
                    <td style="width: 50%;">

             <table class="table-form" style="width: 100%">
                <tr>
                    <td style="width:20%;">
                        sectarian:
                        </td>
                    <td>
                        <asp:DropDownList  ID="ddlSectrain" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Percentage:
                        </td>
                        <td>
                        <asp:TextBox ID="txtboxSectainPercentage" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Button ID="btnSaveSectrain" Text="Save" CssClass="btn" runat="server" OnClick="btnSaveSectrain_Click" />
                    </td>
                </tr>
            </table>
                        </td>
                    <td style="vertical-align:top;text-align:center;">
                        <asp:GridView ID="grdSectarian" CssClass="table-bordered table-striped" AutoGenerateColumns="False" runat="server" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="Ser">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Sectarian Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSectarian" runat="server" Text='<%#Bind("SectrainName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Percentage">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPercentage" runat="server" Text='<%#Bind("Percentage") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>                                        
                                        <asp:LinkButton ID="lnkdelete" OnClientClick="return confirmDelete()" CssClass="icon-delete"  OnClick="lnkdelete_Click" runat="server"></asp:LinkButton>

                                        <asp:HiddenField ID="hdnPAId" Value='<%#Bind("PAId") %>' runat="server" />
                                        <asp:HiddenField ID="hdnSectrainID" Value='<%#Bind("SectrainID") %>' runat="server" />
                                        <asp:HiddenField ID="hdnElectionId" Value='<%#Bind("ElectionId") %>' runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                    </tr>
               </table>
        </div>

    </div>

    
    <script type="text/javascript" src="../Scripts/jquery-ui.js"></script>
    <link href="../Content/jquery-ui.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript">
        $(document).ready(function () {
            var tabs = $("#dvAccordian").accordion({
                heightStyle: "content",
                activate: function (event, ui) {
                    localStorage.setItem("accIndex", $(this).accordion("option", "active"))
                },
                active: parseInt(localStorage.getItem("accIndex"))
            });
        });
        function confirmDelete() {
            if(window.confirm("Do you want to delete?"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    </script>

</asp:Content>

