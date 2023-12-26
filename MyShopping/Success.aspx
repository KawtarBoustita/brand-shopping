<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Success.aspx.cs" Inherits="MyShopping.Success" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Order Placed</title>
    <link href="Styles.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <div>
            <div class="container">
                <div class="center">
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    
                    <h1>Congrats! Order Placed Successfully...</h1>
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Font-Size="Large" Text="Back To Products" OnClick="Button1_Click" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
