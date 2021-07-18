<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="HelloWorld._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <div id="container2">

            
                <header><h2>Login</h2></header>
                <br />
                <asp:Label ID="Label1" runat="server" Text="User name"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" Width="90%" BorderColor="SkyBlue" BorderStyle="Dotted" Height="2em"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                <br />
                
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Width="90%" BorderColor="SkyBlue" BorderStyle="Dotted" Height="2em"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="Button1" runat="server" Text="Login" Width="91%" BackColor="SkyBlue" BorderColor="SkyBlue" Height="3em" OnClick="Button1_Click" />

                <br />
                <br />
                <asp:Label ID="Label3" runat="server" ForeColor="Red"></asp:Label>

            </div>

        </div>
    </form>
</body>
</html>
