<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="OnGoiningResults.aspx.cs" Inherits="Elections_OnGoiningResults" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h1>Ongoining Election Results
     
        <span style="padding-left: 100px">
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </span>
    </h1>
    <table class="table-form">

        
          <tr>
            <td class="label" style="width: 10%;">Year:</td>
            <td style="width: 30%;">
                <asp:DropDownList ID="ddlYear" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlDivisions_SelectedIndexChanged"></asp:DropDownList>
            </td>
            <td class="label" style="width: 10%;">Division:</td>
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

            <td class="label">Select Type :</td>
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
                <asp:DropDownList ID="ddlNA" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlNA_SelectedIndexChanged"></asp:DropDownList>
            </td>
            <td class="label" id="tdPA1" runat="server" style="display: none;">PA:</td>
            <td id="tdPA2" runat="server" style="display: none;">
                <asp:DropDownList ID="ddlPA"  AutoPostBack="true" OnSelectedIndexChanged="ddlPA_SelectedIndexChanged" runat="server"></asp:DropDownList>
            </td>

        </tr>              

        <tr>

            <td align="center" colspan="4">
                <div style="padding-top: 10px;">
                    <asp:GridView ID="GridView1" CssClass="table-bordered table-striped" AutoGenerateColumns="false" runat="server" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="Ser">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Election Year">
                                <ItemTemplate>
                                    <asp:Label ID="lblElectionYear" runat="server" Text='<%#Bind("ElectionYear") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Party Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblPartyName" runat="server" Text='<%#Bind("PartyName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Candidate">
                                <ItemTemplate>
                                    <asp:Label ID="lblCandidate" runat="server" Text='<%#Bind("Candidate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Votes">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_result" runat="server" Text=''></asp:TextBox>                                    
                                </ItemTemplate>
                            </asp:TemplateField>                           
                             <asp:TemplateField HeaderText="Polling Station">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_PollingStation" runat="server" Text=''></asp:TextBox>                                    
                                </ItemTemplate>
                            </asp:TemplateField>    
                                <asp:TemplateField HeaderText="Remarks">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_remarks" runat="server" Text=''></asp:TextBox>

                                    <asp:HiddenField ID="NAId" runat="server" Value='<%#Bind("NAId") %>' />
                                    <asp:HiddenField ID="PAId" runat="server" Value='<%#Bind("PAId") %>' />
                                    <asp:HiddenField ID="DivisionId" runat="server" Value='<%#Bind("DivisionId") %>' />
                                    <asp:HiddenField ID="Districtid" runat="server" Value='<%#Bind("Districtid") %>' />
                                    <asp:HiddenField ID="ElectionId" runat="server" Value='<%#Bind("ElectionId") %>' />
                                    <asp:HiddenField ID="CandidateId" runat="server" Value='<%#Bind("CandidateId") %>' />
                                    
                                </ItemTemplate>
                            </asp:TemplateField> 
                        </Columns>
                    </asp:GridView>

                </div>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center;">
                <asp:Button ID="Btn_Save" Text="Save Result" CssClass="btn" runat="server" OnClick="Btn_Save_Click" Visible="false" />

            </td>
        </tr>
    </table>
</asp:Content>

