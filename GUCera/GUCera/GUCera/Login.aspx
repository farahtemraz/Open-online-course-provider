<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GUCera.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
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
        <div class="container">
        <asp:Label ID="Label1" runat="server" Text="ID:" CssClass="label"></asp:Label>
            <br />
            <asp:TextBox ID="username" runat="server" CssClass="textbox"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" ControlToValidate="username" errormessage="Please enter your ID" />
            <br />
            <br />
        <asp:Label ID="Label2" runat="server" Text="Password:" CssClass="label"></asp:Label>
            <br />
        <asp:TextBox ID="password" runat="server" TextMode="Password" CssClass="textbox"></asp:TextBox>
            <br />
        <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" ControlToValidate="password" errormessage="Please enter your password" />
            <br />
            <br />
            <asp:Button ID="signin" runat="server" OnClick="Signin_Click" Text="Login" CssClass="btn btn-dark" />
            <br />
            <br />
        <asp:HyperLink ID="register" runat="server" NavigateUrl="Register.aspx" CssClass="hyperLink">Register</asp:HyperLink>
            </div>
    </form>
       
</body>
</html>
