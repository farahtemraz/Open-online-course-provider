<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="defineAssignment.aspx.cs" Inherits="GUCera.registerproc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Define Assignment</title>
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
            <asp:Label runat="server" Text="Assignment Number:"></asp:Label>
            <br />
            <asp:TextBox ID="assignmentNumber" runat="server" CssClass="textbox"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" ControlToValidate="assignmentNumber" errormessage="Please enter the assignment number" />
            <br />
            <asp:Label runat="server" Text="Assignment Type:"></asp:Label>
            <br />
            <asp:DropDownList ID="assignmentType" runat="server" CssClass="textbox">
                <asp:ListItem Text="Quiz" Value="Quiz" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Project" Value="Project"></asp:ListItem>
                <asp:ListItem Text="Exam" Value="Exam"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label runat="server" Text="Content:"></asp:Label>
            <br />
            <asp:TextBox ID="content" runat="server" MaxLength="200" CssClass="textbox"></asp:TextBox>
            <br />
            <asp:Label runat="server" Text="Weight: "></asp:Label>
            <br />
            <asp:TextBox ID="weight" runat="server" CssClass="textbox"></asp:TextBox>
            <br />
            <asp:Label runat="server" Text="Full Grade: "></asp:Label>
            <br />
            <asp:TextBox ID="fullGrade" runat="server" CssClass="textbox"></asp:TextBox>
            <br />
            <asp:Label runat="server" Text="Deadline: "></asp:Label>
            <br />
            <asp:Calendar ID="calendar" runat="server" CssClass="Calendar"></asp:Calendar>
            <br />
            <br />
            <asp:Button ID="define" runat="server" Text="Define Assignment" OnClick="define_Click" CssClass="btn btn-md btn-dark"></asp:Button>
            <br />
            <br />
            <asp:HyperLink ID="homepage" runat="server" NavigateUrl="instructorsCourses.aspx" CssClass="hyperLink">Back to your courses</asp:HyperLink>
            <br />
        </div>
    </form>
</body>
</html>
