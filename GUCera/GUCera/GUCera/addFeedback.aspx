<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addFeedback.aspx.cs" Inherits="GUCera.addFeedback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Feedback</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous"/>
    <link rel="icon" href="db.ico"/>
    <link rel="stylesheet" runat="server" media="screen" href="loginStylesheet.css" />
    <link rel="stylesheet" runat="server" media="screen" href="coreStylesheet.css" />
    <link rel="preconnect" href="https://fonts.gstatic.com"/>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;500;700;900&display=swap" rel="stylesheet"/>
    <script src="https://kit.fontawesome.com/c4110beaca.js" crossorigin="anonymous"></script>
</head>
<body>
    <form id="addComment" runat="server">
        <div class="container">
            <asp:Label ID="courseID1" runat="server" Text="Course ID: "></asp:Label>
            <br />
            <asp:TextBox ID="courseID" runat="server" CssClass="textbox"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" ControlToValidate="courseID" errormessage="Please enter course ID" />
            <br />
            <asp:Label ID="comment1" runat="server" Text="Comment: "></asp:Label>
            <br />
            <asp:TextBox ID="comment" runat="server" MaxLength="100" CssClass="textbox"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" ControlToValidate="comment" errormessage="Please enter your feedback" />
            <br />
            <asp:Button ID="feedbackSubmit" runat="server" Text="Add Feedback" OnClick="feedbackSubmit_Click" CssClass="btn btn-md btn-outline-dark"></asp:Button>
            <br />
            <br />
             <asp:HyperLink ID="homepage" runat="server" NavigateUrl="home.aspx" CssClass="hyperLink">Skip and go to home</asp:HyperLink>
        </div>
    </form>
</body>
</html>
