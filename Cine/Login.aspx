<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Cine.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="/Content/bootstrap.css" rel="stylesheet">
   <title>Admin - Login</title>
</head>
<body class="bg-dark">
   <form class="form" id="form1" runat="server">
      <div class="container text-light">
         <h4 class="card-title pt-5">Log In</h4>
         <hr />
         <asp:PlaceHolder runat="server" ID="LoginStatus" Visible="false">
            <p>
               <asp:Literal runat="server" ID="StatusText" />
            </p>
         </asp:PlaceHolder>
         <asp:PlaceHolder runat="server" ID="LoginForm" Visible="false">
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
               <div>
                  <asp:Button runat="server" OnClick="SignIn" Text="Log in" />
               </div>
            </div>
         </asp:PlaceHolder>
         <asp:PlaceHolder runat="server" ID="LogoutButton" Visible="false">
            <div class="form-group p-1">
               <div>
                  <asp:Button runat="server" OnClick="SignOut" Text="Log out" />
               </div>
            </div>
         </asp:PlaceHolder>
         <asp:PlaceHolder runat="server" ID="Redirector" Visible="false">
            <div class="form-group p-1">
               <div>
                    <asp:Button runat="server" OnClick="Redirect" Text="Go to Admin" />
               </div>
            </div>
         </asp:PlaceHolder>
          
          <asp:PlaceHolder runat="server" ID="BeforeLogin" Visible="false">
              <div class="form-group p-1">
                   <div>
                      <asp:Button runat="server" OnClick="NotAdmin" Text="Not An Admin" />
                   </div>
               </div>

              <div class="form-group p-1">
                   <div>
                      <asp:Button runat="server" OnClick="Register" Text="Register New Admin" />
                   </div>
               </div>
             </asp:PlaceHolder>
      </div>
   </form>
</body>
</html>