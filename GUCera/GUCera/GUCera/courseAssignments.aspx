<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="courseAssignments.aspx.cs" Inherits="GUCera.courseAssignments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Course Assignments</title>
    <link rel="icon" href="db.ico"/>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous"/>
    <link rel="icon" href="db.ico"/>
    <link rel="stylesheet" runat="server" media="screen" href="coreStylesheet.css" />
    <link rel="preconnect" href="https://fonts.gstatic.com"/>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;500;700;900&display=swap" rel="stylesheet"/>
    <script src="https://kit.fontawesome.com/c4110beaca.js" crossorigin="anonymous"></script>
</head>
<body>
    <form id="courseAssignment" runat="server">
        <div class="container table">
            <asp:Table ID="courseAssignmentsTable" runat="server" Width="100%" BackColor="#48426d" ForeColor="White">
             
                <asp:TableHeaderRow runat="server" BackColor="#312c51" ForeColor="White">
                    <asp:TableHeaderCell Text="Type" Width="10%"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Text="Number" Width="10%"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Text="Full Grade" Width="10%"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Text="Weight" Width="10%"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Text="Content" Width="30%"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Text="Deadline" Width="30%"></asp:TableHeaderCell>
                </asp:TableHeaderRow>
                </asp:Table>
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="home.aspx" CssClass="hyperLink">Back to home</asp:HyperLink>
            </div>
    </form>
</body>
</html>
