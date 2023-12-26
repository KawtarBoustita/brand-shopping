<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="AddColor.aspx.cs" Inherits="MyShopping.AddColor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class ="container ">
            <div class ="form-horizontal ">
                <br />
                <br />

                <h2>Add Color</h2>
                <hr />

                <div class ="form-group">
                    <asp:Label ID="Label1" CssClass ="col-md-2 control-label " runat="server" Text="Color Name"></asp:Label>
                    <div class ="col-md-3 ">

                        <asp:TextBox ID="txtColor" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorColor" runat="server" CssClass ="text-danger " ErrorMessage="*plz Enter Color" ControlToValidate="txtColor" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                 <div class ="form-group">
                    <asp:Label ID="Label3" CssClass ="col-md-2 control-label " runat="server" Text="Brand"></asp:Label>
                    <div class ="col-md-3 ">

                        <asp:DropDownList ID="ddlBrand" CssClass ="form-control" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorddlBrand" runat="server" CssClass ="text-danger " ErrorMessage="*plz Enter Main CategoryID" ControlToValidate="ddlBrand" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                 <div class ="form-group">
                    <asp:Label ID="Label4" CssClass ="col-md-2 control-label " runat="server" Text="Category"></asp:Label>
                    <div class ="col-md-3 ">

                        <asp:DropDownList ID="ddlCategory" CssClass ="form-control" runat="server" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCategory" runat="server" CssClass ="text-danger " ErrorMessage="*plz Enter  Category" ControlToValidate="ddlCategory" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                

                 <div class ="form-group">
                    <asp:Label ID="Label2" CssClass ="col-md-2 control-label " runat="server" Text="Sub Category"></asp:Label>
                    <div class ="col-md-3 ">

                        <asp:DropDownList ID="ddlSubCategory" CssClass ="form-control" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorSubCategory" runat="server" CssClass ="text-danger " ErrorMessage="*plz Enter Sub Category" ControlToValidate="ddlSubCategory" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                 <div class ="form-group">
                    <asp:Label ID="Label5" CssClass ="col-md-2 control-label " runat="server" Text="Gender"></asp:Label>
                    <div class ="col-md-3 ">

                        <asp:DropDownList ID="ddlGender" CssClass ="form-control" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorGender" runat="server" CssClass ="text-danger " ErrorMessage="*plz Enter Gender" ControlToValidate="ddlGender" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class ="form-group">
                    <asp:Label ID="Label6" CssClass ="col-md-2 control-label " runat="server" Text="Size"></asp:Label>
                    <div class ="col-md-3 ">

                        <asp:DropDownList ID="dllSize" CssClass ="form-control" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass ="text-danger " ErrorMessage="*plz Enter Size" ControlToValidate="dllSize" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                
                


                <div class ="form-group">
                    <div class ="col-md-2 "> </div>
                    <div class ="col-md-6 ">

                        <asp:Button ID="btnAddColor" CssClass ="btn btn-success " runat="server" Text="Add Color" OnClick="btnAddColor_Click"   />
                        
                    </div>
                </div>
                

            </div>

<h1>Size</h1>
        <hr />

 <div class="panel panel-default">

               <div class="panel-heading"> All Color</div>


     <asp:repeater ID="rptrColor" runat="server">

         <HeaderTemplate>
             <table class="table table-hover">
                  <thead>
                    <tr>
                        <th>#</th>
                        <th>Color</th>
                        <th>Size</th>
                        <th>Brand</th>
                        <th>Category</th>
                         <th>Sub Category</th>
                         <th>Gender</th>
                        

                    </tr>

                </thead>



            <tbody>
         </HeaderTemplate>


         <ItemTemplate>
             <tr>
                  <th> <%# Eval("ColorID") %> </th>
                    <th> <%# Eval("SizeID") %> </th>
                    <td><%# Eval("ColorName") %>   </td>
                  <td><%# Eval("Name") %>   </td>
                  <td><%# Eval("CatName") %>   </td>
                   <td><%# Eval("SubCatName") %>   </td>
                   <td><%# Eval("GenderName") %>   </td>
                    
                </tr>
         </ItemTemplate>


         <FooterTemplate>
             </tbody>

              </table>
         </FooterTemplate>

     </asp:repeater>

              
                
            

   
</div>


        </div>
</asp:Content>
