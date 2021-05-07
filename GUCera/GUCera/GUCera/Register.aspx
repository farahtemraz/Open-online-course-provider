<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="GUCera.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
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
        <div class="container skipmargin">
        
        <asp:Label ID="Label1" runat="server" Text="First Name:"></asp:Label>
            <br />
            <asp:TextBox ID="firstname" runat="server" CssClass="textbox"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator runat="server" id="reqName" ControlToValidate="firstname" errormessage="Please enter your first name!" />
            <br />
        <asp:Label ID="Label2" runat="server" Text="Last Name:"></asp:Label>
            <br />
            <asp:TextBox ID="lastname" runat="server" CssClass="textbox"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" ControlToValidate="lastname" errormessage="Please enter your last name!" />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Password:"></asp:Label>
            <br />
        <asp:TextBox ID="password" runat="server" TextMode= "Password" CssClass="textbox"></asp:TextBox>
            <br />
        <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" ControlToValidate="password" errormessage="Please enter your password" />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Email:"></asp:Label>
        <br />
        <asp:TextBox ID="email" runat="server" CssClass="textbox"></asp:TextBox>
            <br />
        <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator3" ControlToValidate="email" errormessage="Please enter your email" />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Address:"></asp:Label>
        <br />
        <asp:TextBox ID="address" runat="server" CssClass="textbox"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Gender:"></asp:Label>
            <br />
     <asp:RadioButtonList ID="gender" runat="server" RepeatLayout="Flow">
    <asp:ListItem Value="false">Male</asp:ListItem>
    <asp:ListItem Value="true">Female</asp:ListItem>
</asp:RadioButtonList>
            <br />
            <br />
        <asp:Button ID="studentRegister" runat="server" Text="Register as a student" onClick="registerstudent" CssClass="btn btn-md btn-light"/>
        <asp:Button ID="instructorRegister" runat="server" Text="Register as an instructor" onClick="registerinstructor" CssClass="btn btn-md btn-dark" />
            </div>
    </form>
</body>
</html>
