<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="NAList.aspx.cs" Inherits="Admin_NAList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <h1>National Assembly
      <span style="padding-left:100px">  
          <asp:Label ID="lblMsg" runat="server"  Text=""></asp:Label>
          </span>
    </h1>
 <table class="table-form">
    <tr>
               <td class="label" style="width:10%;">Province:</td>
                <td  style="width:20%;">
                     <asp:DropDownList ID="ddlDivisions"  runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDivisions_SelectedIndexChanged">
                    
                </asp:DropDownList>

                <asp:DropDownList ID="ddlProvince" Visible="false" runat="server">
                    <asp:ListItem Text="Punjab" Value="4"></asp:ListItem>
                </asp:DropDownList>
                </td>
             
               <td class="label" style="width:10%;">District:</td>
                <td  style="width:20%;">
                    <asp:DropDownList ID="ddlDistrict"   runat="server" ></asp:DropDownList>
                </td>
 
        </tr>
     <tr>
            <td colspan="4" style="text-align: center;">
                <asp:Button ID="btn_search" Text="Search" CssClass="btn" runat="server" OnClick="btnsearch_Click" />
               
                
                <asp:Label ID="LblMeg" runat="server" Text=""></asp:Label>
            </td>
        </tr>
     
     <tr>

            <td align="center" colspan="4">
                <div style="padding-top:10px;">
                <asp:GridView ID="GridView1" CssClass="table-bordered table-striped" AutoGenerateColumns="false" runat="server" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="Ser">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="NA Name">
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Category">
                            <ItemTemplate>
                                <asp:Label ID="lblCategory" runat="server" Text='<%#Bind("Category") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                       <%-- <asp:TemplateField HeaderText="Latitude">
                            <ItemTemplate>
                                <asp:Label ID="lblLatitude" runat="server" Text='<%#Bind("Latitude") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Longitude">
                            <ItemTemplate>
                                <asp:Label ID="lblLongitude" runat="server" Text='<%#Bind("Longitude") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="Famous Place">
                            <ItemTemplate>
                                <asp:Label ID="lblFamousPlace" runat="server" Text='<%#Bind("FamousPlace") %>'></asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>

                        


                    </Columns>
                </asp:GridView>
                    <asp:HiddenField ID="hdID" runat="server" />
                    </div>
            </td>
        </tr>
     </table>
</asp:Content>

