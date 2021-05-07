<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mobile.aspx.cs" Inherits="GUCera.mobile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Mobile Number</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous"/>
    <link rel="icon" href="db.ico"/>
    <link rel="stylesheet" runat="server" media="screen" href="loginStylesheet.css" />
    <link rel="stylesheet" runat="server" media="screen" href="coreStylesheet.css" />
    <link rel="preconnect" href="https://fonts.gstatic.com"/>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;500;700;900&display=swap" rel="stylesheet"/>
    <script src="https://kit.fontawesome.com/c4110beaca.js" crossorigin="anonymous"></script>
</head>
<body>
    <div class="container">
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Your Mobile Number:"></asp:Label>
        <br />
        <asp:TextBox ID="number" runat="server" CssClass="textbox"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="addmobile" runat="server" Text="Submit and add another number" OnClick="addmobile_Click" CssClass="btn btn-md btn-dark" />
        <asp:Button ID="go" runat="server" Text="Submit and go to Homepage" OnClick="go_Click" CssClass="btn btn-md btn-light"/>
       <br />
        <br /> 
        <asp:Button ID="homepage" runat="server" Text="Skip and go to homepage" OnClick="homepage_Click"  CssClass="btn btn-md btn-outline-dark"/>

    </form>
        </div>
</body>
</html>
