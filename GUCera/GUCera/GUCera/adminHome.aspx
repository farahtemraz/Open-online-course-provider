<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminHome.aspx.cs" Inherits="GUCera.adminHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous"/>
    <link rel="icon" href="db.ico"/>
    <link rel="stylesheet" runat="server" media="screen" href="coreStylesheet.css" />
    <link rel="preconnect" href="https://fonts.gstatic.com"/>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;500;700;900&display=swap" rel="stylesheet"/>
    <script src="https://kit.fontawesome.com/c4110beaca.js" crossorigin="anonymous"></script>
</head>
<body>
    <form id="adminLandingPage" runat="server">
        <div class="container buttons">
            <asp:Button ID="listOfCourses" runat="server" Text="All Courses" OnClick="listOfCourses_Click" CssClass="btn btn-md btn-outline-dark paddingb" />
            <asp:Button ID="pendingCourses" runat="server" Text="Pending Courses" OnClick="pendingCourses_Click" CssClass="btn btn-md btn-outline-dark paddingb"/>
            <asp:Button ID="promocodes" runat="server" Text="Create/Issue Promocode" OnClick="promocodes_Click" CssClass="btn btn-md btn-outline-dark paddingb"/>
        </div>
    </form>
    <div class="align">
            <asp:HyperLink ID="home" runat="server" NavigateUrl="Login.aspx" CssClass="hyperLink">Sign Out</asp:HyperLink>
        </div>
</body>
</html>
