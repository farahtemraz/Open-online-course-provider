<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="courseInformation.aspx.cs" Inherits="GUCera.courseInformation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Course Information</title>
    <link rel="icon" href="db.ico"/>
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
    <form id="courseInfo" runat="server">
            <asp:Label ID="courseID1" runat="server" Text="Course ID: "></asp:Label>
            <asp:Label ID="courseID" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="courseName1" runat="server" Text="Course Name: "></asp:Label>
            <asp:Label ID="courseName" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="creditHours1" runat="server" Text="Credit Hours: "></asp:Label>
            <asp:Label ID="creditHours" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="description1" runat="server" Text="Description: "></asp:Label>
            <asp:Label ID="description" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="instructorFirstName1" runat="server" Text="Instructor First Name: "></asp:Label>
            <asp:Label ID="instructorFirstName" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="instructorLastName1" runat="server" Text="Instructor Last Name: "></asp:Label>
            <asp:Label ID="instructorLastName" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="price1" runat="server" Text="Price: "></asp:Label>
            <asp:Label ID="price" runat="server" Text=""></asp:Label>
        <br />
        <br />
            <asp:Button ID="enroll" runat="server" Text="Enroll in course" OnClick="enroll_Click" CssClass="btn btn-md btn-dark" />
        <br />
        <asp:Label ID="chooseYourInstructor" runat="server" Text=""></asp:Label>
        <br />
            <asp:DropDownList ID="instructorsList" OnSelectedIndexChanged="instructorsList_SelectedIndexChanged" runat="server" AutoPostBack="true" CssClass="textbox"></asp:DropDownList>
        <br />
        <br />
            <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="submit_Click" CssClass="btn btn-md btn-outline-dark"/>
        <br />
        <br />
         <asp:HyperLink ID="homepage" runat="server" NavigateUrl="home.aspx" CssClass="hyperLink">Skip and go to home</asp:HyperLink>
    </form>
        </div>
</body>
</html>
