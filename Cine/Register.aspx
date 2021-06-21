<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Cine.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="/Content/bootstrap.css" rel="stylesheet">
    <title>Admin - Register</title>
</head>
<body class="bg-dark">
    <form class="form" id="form1" runat="server">
        <div class="container text-light">
            <h4 class="card-title pt-5">Register a new admin</h4>
        <hr />
        <p>
            <asp:Literal runat="server" ID="StatusMessage" />
        </p>                
        <div class="form-group p-1">
            <asp:Label runat="server" AssociatedControlID="UserName">User name</asp:Label>
            <div class="text-body">
                <asp:TextBox runat="server" ID="UserName" />                
            </div>
        </div>
        <div class="form-group p-1">
            <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="Password" TextMode="Password" />                
            </div>
        </div>
        <div class="form-group p-1">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword">Confirm password</asp:Label>
            <div>
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />                
            </div>
        </div>
        <div class="form-group p-1">
            <div>
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" />
            </div>
        </div>
        </div>
    </form>
</body>
</html>
