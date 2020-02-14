<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="CreateLogin.aspx.cs" Inherits="Admin_CreateLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <h1>Create Login
      <span style="padding-left:100px">  
          <asp:Label ID="lblMsg" runat="server"  Text=""></asp:Label>
          </span>
    </h1>
    <table class="table-form" style="width:100%;">  
       
       <tr>
            <td  class="label" style="width:0%">User Name:</td>
            <td  style="width:20%">
                <asp:TextBox ID="txtUserName" runat="server" Width="250px"></asp:TextBox>                
            </td>
           <td  class="label" style="width:0%">Password:</td>
            <td  style="width:20%">
                <asp:TextBox ID="txtPassword" runat="server" Width="250px"></asp:TextBox>                
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
                  <asp:TemplateField HeaderText="User Name">
                      <ItemTemplate>
                          <asp:Label ID="lblUsernmae" runat="server" Text='<%#Bind("UserName") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>   
                  
                  <asp:TemplateField HeaderText="Password">
                      <ItemTemplate>
                          <asp:Label ID="LabelPassword" runat="server" Text='<%#Bind("Password") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>                
                 
                   <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                  <asp:LinkButton ID="del" CausesValidation="false" CssClass="icon-delete" CommandName='<%# Bind("UserID") %>' runat="server" OnClick="deleteRecord"> </asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                
              </Columns>
            </asp:GridView>
                  </div>    
    
</asp:Content>

