<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Admin_ChangePassword" %>

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
                <td width="40%" align="right">
                    User Login :
                </td>
                <td width="60%">
                    <asp:Label ID="Label_user_name" runat="server" Style="color: #C00; font-weight: bold;
                        font-size: 13px;"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Old Password :
                </td>
                <td>
                    <asp:TextBox ID="TextBox_old_passward" runat="server" TextMode="Password"></asp:TextBox>
                    
                </td>
            </tr>
            <tr>
                <td align="right">
                    New Password :
                </td>
                <td>
                    <asp:TextBox ID="TextBox_new_passward" runat="server" TextMode="Password"></asp:TextBox>
                   
                     </td>
            </tr>
            <tr>
                <td align="right">
                    Confirm Password:
                </td>
                <td>
                    <asp:TextBox ID="TextBox_confirm_new_passward" runat="server" TextMode="Password"></asp:TextBox>
                  
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="Button_Change_Password" runat="server" Text="Save" OnClick="Button_Change_Password_Click"    />
                </td>
            </tr>
        </table>
        <asp:Label ID="Label_Note" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
    </div>

   
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
                 
                
              </Columns>
            </asp:GridView>
           </div> 
     <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ElecConnection %>"
        DeleteCommand="DELETE FROM [Login] WHERE [UserID] = @UserID"
        InsertCommand="INSERT INTO [Login] ([Password]) VALUES (@Password)"
        SelectCommand="SELECT [UserID], [Password] FROM [Login]" UpdateCommand="UPDATE Login SET  Password = @Password WHERE (UserID = @UserID)"
        ProviderName="<%$ ConnectionStrings:ElecConnection.ProviderName %>">
        <DeleteParameters>
            <asp:Parameter Name="UserID" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:ControlParameter ControlID="HiddenField_NewPass" Name="Password" PropertyName="Value" />
            <asp:SessionParameter Name="UserID" SessionField="UserID" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="Password" />
        </InsertParameters>
    </asp:SqlDataSource>  
    <asp:HiddenField ID="HiddenField_NewPass" runat="server" /> 
    
</asp:Content>

