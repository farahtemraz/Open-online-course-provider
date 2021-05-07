<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="studentCreditCards.aspx.cs" Inherits="GUCera.studentCreditCards" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Credit Card</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous"/>
    <link rel="icon" href="db.ico"/>
    <link rel="stylesheet" runat="server" media="screen" href="loginStylesheet.css" />
    <link rel="stylesheet" runat="server" media="screen" href="coreStylesheet.css" />
    <link rel="preconnect" href="https://fonts.gstatic.com"/>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;500;700;900&display=swap" rel="stylesheet"/>
    <script src="https://kit.fontawesome.com/c4110beaca.js" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container scc">
            <asp:Label ID="Label1" runat="server" Text="Cardholder Name:"></asp:Label>
            <br />
            <asp:TextBox ID="cardName" runat="server" CssClass="textbox"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" ControlToValidate="cardName" errormessage="Please enter the cardholder name" />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Card Number:"></asp:Label>
            <br />
            <asp:TextBox ID="cardNumber" runat="server" MaxLength="15" CssClass="textbox"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" ControlToValidate="cardNumber" errormessage="Please enter your card number" />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Expiration Date:"></asp:Label>
            <br />
            <asp:Calendar ID="expirationDate" runat="server" CssClass="Calendar"></asp:Calendar>
            <br />
            <asp:Label ID="Label4" runat="server" Text="CVV: "></asp:Label>
            <br />
            <asp:TextBox ID="cvv" runat="server" MaxLength="3" CssClass="textbox"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator3" ControlToValidate="cvv" errormessage="Please enter the 3-Digit CVV" />
            <br />
            <asp:Button ID="addAnotherCreditCard" runat="server" Text="Submit and add another card" OnClick="addAnotherCreditCard_Click" CssClass="btn btn-md btn-light"/>
            <asp:Button ID="homepage" runat="server" Text="Submit and go home" OnClick="homepage_Click" CssClass="btn btn-md btn-dark"/>
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="home.aspx" CssClass="hyperLink">Skip and go to home</asp:HyperLink>
        </div>
        
    </form>
</body>
</html>
