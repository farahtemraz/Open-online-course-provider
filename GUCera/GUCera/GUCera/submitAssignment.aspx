<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="submitAssignment.aspx.cs" Inherits="GUCera.submitAssignment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Submit Assignment</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous"/>
    <link rel="icon" href="db.ico"/>
    <link rel="stylesheet" runat="server" media="screen" href="loginStylesheet.css" />
    <link rel="stylesheet" runat="server" media="screen" href="coreStylesheet.css" />
    <link rel="preconnect" href="https://fonts.gstatic.com"/>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;500;700;900&display=swap" rel="stylesheet"/>
    <script src="https://kit.fontawesome.com/c4110beaca.js" crossorigin="anonymous"></script>
</head>
<body>
    <form id="submitAssignments" runat="server">
        <div class="container">
            <asp:Label ID="courseID1" runat="server" Text="Course ID: "></asp:Label>
            <br />
            <asp:TextBox ID="courseID" runat="server" CssClass="textbox"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" ControlToValidate="courseID" errormessage="Please enter the course ID" />
            <br />
            <asp:Label ID="assignmentNumber1" runat="server" Text="Assignment Number: "></asp:Label>
            <br />
            <asp:TextBox ID="assignmentNumber" runat="server" CssClass="textbox"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" ControlToValidate="assignmentNumber" errormessage="Please enter the assignment number" />
            <br />
            <asp:Label ID="assignmentType1" runat="server" Text="Assignment Type: "></asp:Label>
            <br />
            <asp:DropDownList ID="typeOfAssignment" runat="server" CssClass="textbox">
                <asp:ListItem Text="Quiz" Value="Quiz" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Project" Value="Project"></asp:ListItem>
                <asp:ListItem Text="Exam" Value="Exam"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="submit" runat="server" Text="Submit and add another assignment" OnClick="submit_Click" CssClass="btn btn-md btn-dark"></asp:Button>
            <asp:Button ID="goToHome" runat="server" Text="Submit and go home" OnClick="goToHome_Click" CssClass="btn btn-md btn-outline-light"></asp:Button>
            <br />
            <br />
             <asp:HyperLink ID="homepage" runat="server" NavigateUrl="home.aspx" CssClass="hyperLink">Skip and go to home</asp:HyperLink>
        </div>
        
    </form>
</body>
</html>
