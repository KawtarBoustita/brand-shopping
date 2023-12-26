<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="payement.aspx.cs" Inherits="MyShopping.payement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HiddenField ID="hdCartAmount" runat="server" />
    <asp:HiddenField ID="hdCartDiscount" runat="server" />
    <asp:HiddenField ID="hdTotalPayed" runat="server" />
    <asp:HiddenField ID="hdPidSizeID" runat="server" />

    <br />
    <br />
      <br />
    <br />
     <div class="col-md-3" runat="server" id="divPriceDetails">
             <div style="border-bottom: 1px solid #eaeaec;">
                <h5 class="proNameViewCart">PRICE DETAILS</h5>
                <div>
                    <label>Cart Total</label>
                    <span class="float-right priceGray" id="spanCartTotal" runat="server"></span>
                </div>
                <div>
                    <label>Cart Discount</label>
                    <span class="float-right priceGreen" id="spanDiscount" runat="server"></span>
                </div>
            </div>

            <div>
                <div class="proPriceView">
                    <label>Total</label>
                    <span class="float-right" id="spanTotal" runat="server"></span>
                </div>
            </div>
        </div>
      <br />
    <br />
    <button id="btnCart2" runat="server" class="btn btn-primary navbar-btn pull-right" onserverclick="btnCart2_ServerClick" type="button">
                        Cart <span id="CartBadge" runat="server" class="badge">0</span>
                    </button>
     

     
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <h1 class="mt-4">Payment Form</h1>
                <div class="card p-4">
                    <div class="payment-methods">
                        <img src="/Images/visa (2).png" alt="Visa Logo" class="payment-logo">
                        <img src="/Images/card (3).png" alt="Visa Logo" class="payment-logo">
                        <img src="/Images/paypal (4).png" alt="PayPal Logo" class="payment-logo">
                    </div>
                    <form>
                        <div class="form-group">
                            <label for="card-number">Card Number</label>                         
                            <asp:TextBox ID="txtPinCode" CssClass="form-control" runat="server" placeholder="1234 5678 9012 3456"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="txtPinCode"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="txtName">Name</label>                           
                            <asp:TextBox ID="txtName" CssClass="form-control" runat="server" placeholder="Name"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator7" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="txtMobileNumber">Mobile Number </label>                           
                            <asp:TextBox ID="txtMobileNumber" CssClass="form-control" runat="server" placeholder="06 12 34 56 78"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="txtMobileNumber"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="card-number"> Address</label>                          
                             <asp:TextBox ID="txtAddress"  CssClass="form-control" runat="server" placeholder="Address"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <label for="expiration-date">Expiration Date</label>                              
                                  <asp:TextBox ID="date"  CssClass="form-control" runat="server" placeholder="MM/YY"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator8" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="date"></asp:RequiredFieldValidator>
                            </div>
                          <div class="form-group col-md-6">
                                <label for="cvv">CVV</label>                              
                                <asp:TextBox ID="cvv"  CssClass="form-control" runat="server" placeholder="123"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="cvv"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                       
                        <button id="BtnPayNow" runat="server" class="btn btn-primary" Font-Size="Large"  onserverclick="BtnPayNow_ServerClick" type="submit" formtarget="_self" style="width: 150px; height: 50px">Pay Now &raquo</button>
                    </form>
                </div>
            </div>
        </div>
         <div>
                                <asp:GridView ID="gvProducts" runat="server" CssClass="col-md-12"  AutoGenerateColumns="False" Visible="False" CellPadding="6"
                                    ForeColor="#333333" GridLines="None" style="height: 120px">
                                    <AlternatingRowStyle BackColor="White" />
                                    <EditRowStyle BackColor="#7C6F57" />
                                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#E3EAEB" />
                                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                                    <Columns>
                                        <asp:BoundField DataField="PID" HeaderText="Product ID" />
                                        <asp:BoundField DataField="PName" HeaderText="Product Name" />
                                        <asp:BoundField DataField="Qty" HeaderText="Quantity" />
                                    </Columns>
                                </asp:GridView>                                
                            </div>
    </div>       
    

  

        <div class="col-md-12">
  <h3>Choose Payment Mode</h3>
            <hr />
            <ul class="nav nav-tabs">
                <li class="nav-item"><a class="nav-link active" data-toggle="tab" href="#wallets">WALLETS</a></li>
                <li class="nav-item"><a class="nav-link" data-toggle="tab" href="#cards">CREDIT/DEBIT CARDS</a></li>
                <li class="nav-item"><a class="nav-link" data-toggle="tab" href="#cod">COD</a></li>
            </ul>
             <div class="tab-content">
                <div id="wallets" class="tab-pane fade show active">
                    <h3>HOME</h3>
                    <p>Some content.</p>
                    <asp:Button ID="btnPaytm" OnClick="btnPaytm_Click" runat="server" Text="Pay with Paytm" />
                </div>
                <div id="cards" class="tab-pane fade">
                    <h3>Menu 1</h3>
                    <p>Some content in menu 1.</p>
                </div>
                <div id="cod" class="tab-pane fade">
                    <h3>Menu 2</h3>
                    <p>Some content in menu 2.</p>
                </div>
            </div>

             <div class="tab-content">
                                <div id="PlaceNPay" class="tab-pane fade in active">
                                    <h3>Place your order and Pay using our <a href="acceptedpayments" target="_blank">Accepted Payments</a> channels, Your order will be dispatched upon receiving full payment.</h3>
                                   <!-- <Button ID="BtnPlaceNPay" CssClass=" btn btn-info" Font-Size="Large" ValidationGroup="PaymentPage" runat="server" Onclick="BtnPlaceNPay_Click" Text="Checkout &raquo;" />-->
                                </div>
                                <div id="EasyPaisa" class="tab-pane fade">
                                    <h3 class="center1">EasyPaisa Payment Gateway Coming Soon</h3>
                                    <h4 class="center1">Until that you can send amount @ 0311 0000193</h4>
                                    <!--  <asp:Button ID="btnEasyPaisa" CssClass=" btn btn-success" Font-Size="Large" runat="server" Text="Pay with EasyPaisa &raquo;" /> -->
                                </div>
                                <div id="JazzCash" class="tab-pane fade">
                                    <h3 class="center1">JazzCash Payment Gateway Coming Soon</h3>
                                    <h4 class="center1">Until that you can send amount @ 0300 1888193</h4>
                                    <!-- <asp:Button ID="btnJazzCash" CssClass="btn btn-danger" runat="server" Font-Size="Large" Text="Pay with JazzCash &raquo;" /> -->
                                </div>
                                <div id="Div1" class="tab-pane fade">
                                    <h3 class="center1">Cash on Delivery - Coming Soon</h3>
                                    <!-- <asp:Button ID="btnCOD" CssClass="btn btn-primary" runat="server" Text="CheckOut &raquo;" Font-Size="Large" /> -->
                                </div>
                            </div>


 </div>

</asp:Content>
