<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="LBElectionYears.aspx.cs" Inherits="Admin_LBElectionYears" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <h1>Add LB Election Year
      <span style="padding-left:100px">  
          <asp:Label ID="lblMsg" runat="server"  Text=""></asp:Label>
          </span>
    </h1>
    <table class="table-form" style="width:50%;">  
       
       <tr>
            <td  class="label" style="width:20%">LB Election Year:</td>
            <td  style="width:20%">
                <asp:TextBox ID="txtLBElecYear" runat="server" Width="250px"></asp:TextBox>                
            </td>
            <td>
              <asp:Button ID="Button1" Text="Save" CssClass="btn"  runat="server" OnClick="btn_save_Click" />
              <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
          </td>
        </tr>

    

  </table> 
              <div style="width:70%; margin:0 auto;margin-top:20px;">
                <asp:GridView  ID="GridView1" CssClass="table-striped table-bordered" AutoGenerateColumns="false" runat="server"  Width="100%">
              <Columns>
                  <asp:TemplateField HeaderText="Ser">
                      <ItemTemplate>
                          <%#Container.DataItemIndex+1 %>
                      </ItemTemplate>
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="LB Election Year">
                      <ItemTemplate>
                          <asp:Label ID="lblid" runat="server" Text='<%#Bind("LBElectionYear") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>                  
                    <asp:TemplateField HeaderText="Action" >
                      <ItemTemplate>
                          
                          <span  class="link" onclick="lnkClick(this,'Results')">Add Results</span> &nbsp;&nbsp;                        
                                               

                          <asp:HiddenField ID="hdnLBElectionId" runat="server" Value='<%#Bind("LBElectionId") %>'></asp:HiddenField>
                      </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Delete">
                      <ItemTemplate>
                          <asp:LinkButton ID="LinkButton1" CssClass="icon-delete" CommandArgument='<%#Bind("LBElectionId") %>' OnClick="LinkButton1_Click" runat="server"></asp:LinkButton>
                      </ItemTemplate>
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>
              </Columns>
            </asp:GridView>
                  </div>    
    <script type="text/javascript">
        function lnkClick(elem,callFrom) {
            
            var LBelectionId = $.trim($(elem).closest("tr").find("[id*='hdnLBElectionId']").val());
           
             (callFrom == "Results")
             window.open("../Elections/LBElectionResults.aspx?ElecnId=" + LBelectionId, "_blank");
           
        }
        
    </script>
</asp:Content>

