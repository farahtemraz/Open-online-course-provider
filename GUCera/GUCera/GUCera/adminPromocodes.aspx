<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminPromocodes.aspx.cs" Inherits="GUCera.adminPromocodes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Promocodes</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous"/>
    <link rel="icon" href="db.ico"/>
    <link rel="stylesheet" runat="server" media="screen" href="coreStylesheet.css" />
    <link rel="preconnect" href="https://fonts.gstatic.com"/>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;500;700;900&display=swap" rel="stylesheet"/>
    <script src="https://kit.fontawesome.com/c4110beaca.js" crossorigin="anonymous"></script>
</head>
<body>
    <form id="promocodes" runat="server">
        <div class="container table">
            <asp:Table ID="promocodesTable" runat="server" Width="100%" BackColor="#48426d" ForeColor="White">
                <asp:TableHeaderRow runat="server" BackColor="#312c51" ForeColor="White">
                        <asp:TableHeaderCell Text="Code" Width="20%"></asp:TableHeaderCell>
                        <asp:TableHeaderCell Text="Issue Date" Width="20%"></asp:TableHeaderCell>
                        <asp:TableHeaderCell Text="Expiry Date" Width="20%"></asp:TableHeaderCell>
                        <asp:TableHeaderCell Text="Discount" Width="20%"></asp:TableHeaderCell>
                        <asp:TableHeaderCell Text="Action" Width="20%"></asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                <asp:TableRow runat="server">
                    <asp:TableCell Width="20%">
                        <asp:TextBox ID="promo" runat="server" MaxLength="6" CssClass="textbox"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell Width="20%">
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Width="20%">
                        <asp:Calendar ID="expiryDate" runat="server" CssClass="Calendar"></asp:Calendar>
                    </asp:TableCell>
                    <asp:TableCell Width="20%">
                        <asp:TextBox ID="discount" runat="server" MaxLength="5" CssClass="textbox"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell Width="20%">
                        <asp:Button ID="addPromo" runat="server" Text="add promocode" OnClick="addPromo_Click" CssClass="btn btn-md btn-outline-light" />
                    </asp:TableCell>
                </asp:TableRow>
             </asp:Table>
            <br />
            <br />
            <br />
             <asp:HyperLink ID="homepage" runat="server" NavigateUrl="adminHome.aspx" CssClass="hyperLink">Skip and go to home</asp:HyperLink>
        </div>
    </form>
</body>
</html>
