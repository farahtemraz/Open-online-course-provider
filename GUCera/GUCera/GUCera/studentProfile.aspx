<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="studentProfile.aspx.cs" Inherits="GUCera.studentProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Profile</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous"/>
    <link rel="icon" href="db.ico"/>
    <link rel="stylesheet" runat="server" media="screen" href="coreStylesheet.css" />
    <link rel="preconnect" href="https://fonts.gstatic.com"/>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;500;700;900&display=swap" rel="stylesheet"/>
    <script src="https://kit.fontawesome.com/c4110beaca.js" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container studentProfileContainer">
            <asp:Label ID="studentID1" runat="server" Text="ID:"></asp:Label>
            <asp:Label ID="studentID" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="studentFirstName1" runat="server" Text="First Name:"></asp:Label>
            <asp:Label ID="studentFirstName" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="studentLastName1" runat="server" Text="Last Name:"></asp:Label>
            <asp:Label ID="studentLastName" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="studentPassword1" runat="server" Text="Password:"></asp:Label>
            <asp:Label ID="studentPassword" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="studentAddress1" runat="server" Text="Address:"></asp:Label>
            <asp:Label ID="studentAddress" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="studentGender1" runat="server" Text="Gender:"></asp:Label>
            <asp:Label ID="studentGender" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="studentEmail1" runat="server" Text="Email:"></asp:Label>
            <asp:Label ID="studentEmail" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="studentGPA1" runat="server" Text="GPA:"></asp:Label>
            <asp:Label ID="studentGPA" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="home.aspx" CssClass="hyperLink">Skip and go to home</asp:HyperLink>
        </div>
    </form>
</body>
</html>
