<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addCourse.aspx.cs" Inherits="GUCera.addCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Course</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous"/>
    <link rel="icon" href="db.ico"/>
    <link rel="stylesheet" runat="server" media="screen" href="loginStylesheet.css" />
    <link rel="stylesheet" runat="server" media="screen" href="coreStylesheet.css" />
    <link rel="preconnect" href="https://fonts.gstatic.com"/>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;500;700;900&display=swap" rel="stylesheet"/>
    <script src="https://kit.fontawesome.com/c4110beaca.js" crossorigin="anonymous"></script>
</head>
<body>
    <form id="addCourses" runat="server">
        <div class="container">
            <asp:Label runat="server" Text="Name:"></asp:Label>
            <br />
            <asp:TextBox ID="courseName" runat="server" MaxLength="10" CssClass="textbox"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" ControlToValidate="courseName" errormessage="Please enter the course name" />
            <br />
            <asp:Label runat="server" Text="Credit Hours: "></asp:Label>
            <br />
            <asp:TextBox ID="creditHours" runat="server" CssClass="textbox"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" ControlToValidate="creditHours" errormessage="Please enter the course credit hours" />
            <br />
            <asp:Label runat="server" Text="Price: "></asp:Label>
            <br />
            <asp:TextBox ID="coursePrice" runat="server" CssClass="textbox"></asp:TextBox>
            <br />
                <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator3" ControlToValidate="coursePrice" errormessage="Please enter the course price" />
             <br />
            <asp:Label runat="server" Text="Description: "></asp:Label>
            <br />
             <asp:TextBox ID="courseDescription" runat="server" CssClass="textbox"></asp:TextBox>
            <br />
                <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator4" ControlToValidate="courseDescription" errormessage="Please enter the course description" />
            <br />
            <asp:Label runat="server" Text="Content: "></asp:Label>
            <br />
              <asp:TextBox ID="courseContent" runat="server" CssClass="textbox"></asp:TextBox>
            <br />
                <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator5" ControlToValidate="courseContent" errormessage="Please enter the course content" />
            <br />
            <br />
            <asp:Button ID="add" runat="server" Text="Add Course" OnClick="add_Click" CssClass="btn btn-md btn-dark"></asp:Button>
            <br />
            <br />
            <asp:HyperLink ID="homepage" runat="server" NavigateUrl="homeOfInstructors.aspx" CssClass="hyperLink">Skip and go to home</asp:HyperLink>
   
        </div>
    </form>
</body>
</html>
