<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="EditSubCategory.aspx.cs" Inherits="MyShopping.EditSubCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class=" container">
<br /><br /><br /><br /><br /><br />
<div class="well-sm"><h3 class="alert-danger text-center">Edit Sub Category</h3></div>
    <div class="row">
        <div class="col-md-8">
           <div class="row">
               <div class="col-md-3">
               <div class="form-group">
               <label>Enter SubCatID:</label>
                  <asp:TextBox ID="txtID" CssClass="form-control" runat="server" AutoPostBack="true"  ontextchanged="txtID_TextChanged"></asp:TextBox> 
               </div>
                  
                  <div class="form-group">
                      <asp:Button ID="btnUpdateSubCategory" CssClass="btn btn-primary" runat="server" 
                          Text="UPDATE" onclick="btnUpdateSubCategory_Click" />
                  </div>
               </div>
               <div class="col-md-3">
                <label>Select Category:</label>
                   <asp:DropDownList ID="ddlMainCategory" CssClass="form-control" runat="server">
                   </asp:DropDownList>
               </div>
               <div class="col-md-3">
               <label>Sub Category:</label>
                   <asp:TextBox ID="txtSubCategory" CssClass="form-control" runat="server"></asp:TextBox>
               </div>
           
           </div>
        
        </div>
        <div class="col-md-4">
        <div class="row">
                <div class="col-md-12">
                <h4 class="alert-info text-center"> All Category</h4>
                <br />
                 <asp:TextBox ID="txtFilterGrid1Record" style="border:2px solid blue" CssClass="form-control" runat="server" placeholder="Search Category...." onkeyup="Search_Gridview(this)"></asp:TextBox>
                <hr />
                   <div class="table table-responsive">
                       <asp:GridView ID="GridView1" CssClass="table table-condensed table-hover" runat="server" EmptyDataText="Record not found...">
                       </asp:GridView>
                   </div>
                </div>
             </div>
        </div>
    </div>
</div>

<script type="text/javascript">
    function Search_Gridview(strKey) {
        var strData = strKey.value.toLowerCase().split(" ");
        var tblData = document.getElementById("<%=GridView1.ClientID %>");
        var rowData;
        for (var i = 1; i < tblData.rows.length; i++) {
            rowData = tblData.rows[i].innerHTML;
            var styleDisplay = 'none';
            for (var j = 0; j < strData.length; j++) {
                if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                    styleDisplay = '';
                else {
                    styleDisplay = 'none';
                    break;
                }
            }
            tblData.rows[i].style.display = styleDisplay;
        }
    }  
</script>
</asp:Content>