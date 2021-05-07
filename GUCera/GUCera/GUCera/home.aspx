<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="GUCera.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
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
        <div class="container buttons">
            <asp:Button ID="profile" runat="server" Text="View Profile" OnClick="profile_Click" CssClass="btn btn-md btn-outline-dark paddingb" />
            <asp:Button ID="viewCourses" runat="server" Text="Available Courses" OnClick="viewCourses_Click" CssClass="btn btn-md btn-outline-dark paddingb" />
            <asp:Button ID="viewCreditCards" runat="server" Text="Add Credit Card" OnClick="viewCreditCards_Click" CssClass="btn btn-md btn-outline-dark paddingb" />
            <asp:Button ID="promocodes" runat="server" Text="Promocodes" OnClick="promocodes_Click" CssClass="btn btn-md btn-outline-dark paddingb"/>
            <asp:Button ID="yourCourses" runat="server" OnClick="yourCourses_Click" Text="Your Courses" CssClass="btn btn-md btn-outline-dark paddingb"/>
            <asp:Button ID="submitAssignment" runat="server" Text="Submit Assignment" OnClick="submitAssignment_Click" CssClass="btn btn-md btn-outline-dark paddingb"/>
            <asp:Button ID="viewGrades" runat="server" Text="View Grades" OnClick="viewGrades_Click" CssClass="btn btn-md btn-outline-dark paddingb"/>
            <asp:Button ID="addFeedback" runat="server" Text="Add Feedback" OnClick="addFeedback_Click" CssClass="btn btn-md btn-outline-dark paddingb"/>
            <asp:Button ID="viewCertificates" runat="server" Text="View Certificates" OnClick="viewCertificates_Click" CssClass="btn btn-md btn-outline-dark paddingb"/>
            <asp:Button ID="addMobileNumber" runat="server" Text="Add Mobile Number" OnClick="addMobileNumber_Click" CssClass="btn btn-md btn-outline-dark paddingb"/>

        </div>
        <div class="align">
            <asp:HyperLink ID="home1" runat="server" NavigateUrl="Login.aspx" CssClass="hyperLink">Sign Out</asp:HyperLink>
        </div>
    </form>
</body>
</html>
