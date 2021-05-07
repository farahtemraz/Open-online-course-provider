<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewCertificates.aspx.cs" Inherits="GUCera.viewCertificates" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Certificates</title>
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
        <div class="container">
            <div>
            <asp:Label ID="courseID1" runat="server" Text="Course ID: "></asp:Label>
            <br />
            <asp:TextBox ID="courseID" runat="server" CssClass="textbox"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" ControlToValidate="courseID" errormessage="Please enter the course ID" />
            <br />
            <asp:Button ID="viewCourseCertificates" runat="server" Text="view Certificates" OnClick="viewCourseCertificates_Click" CssClass="btn btn-md btn-outline-dark"></asp:Button>
            <br />
             <br />
            <asp:HyperLink ID="homepage" runat="server" NavigateUrl="home.aspx" CssClass="hyperLink">Skip and go to home</asp:HyperLink>
        </div>
            
        </div>
    </form>
</body>
</html>
