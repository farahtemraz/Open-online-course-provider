<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="issueCertificate.aspx.cs" Inherits="GUCera.issueCertificate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Issue Certificate</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous"/>
    <link rel="icon" href="db.ico"/>
    <link rel="stylesheet" runat="server" media="screen" href="loginStylesheet.css" />
    <link rel="stylesheet" runat="server" media="screen" href="coreStylesheet.css" />
    <link rel="preconnect" href="https://fonts.gstatic.com"/>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;500;700;900&display=swap" rel="stylesheet"/>
    <script src="https://kit.fontawesome.com/c4110beaca.js" crossorigin="anonymous"></script>
</head>
<body>
    <form id="issueACertificate" runat="server">
        <div class="container">
            <asp:Label runat="server" Text="Student ID:"></asp:Label>
            <br />
            <asp:TextBox ID="studentID" runat="server" CssClass="textbox"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" ControlToValidate="studentID" errormessage="Please enter the Student ID" />
            <br />
            <asp:Button ID="issue" runat="server" Text="Issue Certificate" OnClick="issue_Click" CssClass="btn btn-md btn-dark"/>
            <br />
            <br />
             <asp:HyperLink ID="homepage" runat="server" NavigateUrl="instructorsCourses.aspx" CssClass="hyperLink">Back to your courses</asp:HyperLink>
        </div>
        
    </form>
</body>
</html>
