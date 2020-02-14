<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="Candidates.aspx.cs" Inherits="Candidates_Candidates" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Candidates
      <span style="padding-left:100px">  
          <asp:Label ID="lblMsg" runat="server"  Text=""></asp:Label>
          </span>
    </h1>
    <fieldset>
        <legend>
            Filter Parameters
        </legend>
        <table class="table-form">
            <tr>
                <td class="label" style="width:10%;">Party:</td>
                <td  style="width:20%;">
                    <asp:DropDownList ID="ddlParty" runat="server"></asp:DropDownList>
                </td>
                <td class="label"   style="width:10%;">Name:</td>
                <td   style="width:20%;">
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="Search" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
      <div style="padding-top:10px;">
          
                <asp:GridView ID="grdCandidates" CssClass="td-position table-bordered table-striped" AutoGenerateColumns="false" runat="server" Width="100%" OnRowDataBound="grdCandidates_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Ser">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                               <div class="cand-pic">
                                <div style="float:left;width:80%; text-align:left;">
                                    <asp:Label ID="lblName"  CssClass="hyperlink" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                </div>
                                <div style="float:left;width:20%;position:absolute;right:0;z-index:999999;">
                                    <asp:Image runat="server" ID="candPic" onmouseover="largePic(this)" CssClass="picture"  width="30" height="30"  />
                                </div>
                               </div>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Party">
                            <ItemTemplate>
                                <asp:Label ID="lblParty" runat="server" Text='<%#Bind("PartyName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="NIC">
                            <ItemTemplate>
                                <asp:Label ID="lblNIC" runat="server" Text='<%#Bind("NIC") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Phone">
                            <ItemTemplate>
                                <asp:Label ID="lblPhone" runat="server" Text='<%#Bind("PersonalPhone") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%--<asp:TemplateField HeaderText="Present Address">
                            <ItemTemplate>
                                 <asp:Label ID="lblPresentAddress" runat="server" Text='<%#Bind("PresentAddress") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        
                        <asp:TemplateField HeaderText="Other">
                            <ItemTemplate>
                                <span class="link"  onclick="lnkClick(this,'Father')">Father</span> &nbsp;&nbsp;
                                <span  class="link" onclick="lnkClick(this,'Spouse')">Spouse</span> &nbsp;&nbsp;                        
                                <span  class="link" onclick="lnkClick(this,'Children')">Children</span> &nbsp;&nbsp;
                                <span  class="link" onclick="lnkClick(this,'Business')">Business</span>&nbsp;&nbsp;                        
                                <span  class="link" onclick="lnkClick(this,'CookGurard')">Guard/Cood</span>
                                
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Action" HeaderStyle-Width="100px" >
                      <ItemTemplate>
                          <span class="icon-edit" title="Edit" onclick="lnkClick(this,'Edit')"></span>
                          <span class="icon-details" title="Details" onclick="lnkClick(this,'Details')"></span>

                          <%--<asp:LinkButton ID="lnkEdit" CommandArgument='<%#Bind("CandidateId") %>' OnClick="lnkEdit_Click" runat="server">Edit</asp:LinkButton>--%>
                          &nbsp;&nbsp;                                                   
                          <asp:HiddenField ID="hdnCandidateId" runat="server" Value='<%#Bind("CandidateId") %>'></asp:HiddenField>
                      </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>
                    </Columns>
                </asp:GridView>
              
                    </div>

    <script type="text/javascript">
        function lnkClick(elem,callFrom) {
            
            var candidateId = $.trim($(elem).closest("tr").find("[id*='hdnCandidateId']").val());
            if (callFrom == "Father")
                window.open("../Candidates/Father.aspx?CandId=" + candidateId, "_blank");
            else if (callFrom == "Spouse")
                window.open("../Candidates/Spouse.aspx?CandId=" + candidateId, "_blank");
            else if (callFrom == "Children")
                window.open("../Candidates/Children.aspx?CandId=" + candidateId, "_blank");
            else if (callFrom == "Edit")
                window.open("../Candidates/AddCandidates.aspx?CandId=" + candidateId, "_blank");
            else if (callFrom == "Details")
                window.open("../Candidates/CandidateProfile.aspx?CandId=" + candidateId, "_blank");
            else if (callFrom == "Business")
                window.open("../Candidates/Businesses.aspx?CandId=" + candidateId, "_blank");
            else if (callFrom == "CookGurard")
                window.open("../Candidates/Guard_Cook.aspx?CandId=" + candidateId, "_blank");
            
            
        }
        function largePic(elem) {
            $(elem).stop().animate();
            $(elem).css("height", "120px");
            $(elem).css("width", "120px");
        }
        $(document).ready(function () {
            $(".cand-pic").mouseleave(function () {                
                $(this).find("img").css("height", "30px");
                $(this).find("img").css("width", "30px");
            });
            //$("body").click(function (e) {                
            //    var target = $(e.target);
            //    if ($(target).hasClass("hyperlink")) {
            //        $(".cand-image").hide();
            //        $(target).next(".cand-image").show();
            //    }
            //    else
            //    {
            //        $(".cand-image").hide();
            //    }
            //}); 
            //$(".hyperlink").on("mousemove", function () {
            //    $(this).next(".cand-image").hide();
            //});
        });
    </script>
</asp:Content>

