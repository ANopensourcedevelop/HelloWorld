<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="HelloWorld.account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="style.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="labelHeader">
            <header>
                <h2>
                    <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="whitesmoke"></asp:Label>
                </h2>
            </header>
        </div>
        <section>
            <div id="nav">
                <asp:Label ID="Label3" runat="server" Text="Players" ForeColor="SkyBlue"></asp:Label> <br />

                <br />
                <table cellpadding="2" cellspacing="0" class="auto-style1">
                    <asp:Repeater ID="ornRepeater" runat="server">
                        <HeaderTemplate>
                            <tr style="background-color:skyblue">
                                <td>
                                    <strong>Name</strong>
                                </td>
                                <td>
                                    <strong>Right answer</strong>
                                </td>
                                <td>
                                    <strong>Wrong answer</strong>
                                </td>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%#Eval("Name") %>
                                </td>
                                <td>
                                    <%#Eval("RightA") %>
                                </td>
                                <td>
                                    <%#Eval("WrongA") %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>

            </div>
            <article>
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="XX-Large"></asp:Label>

                <br />
                <br />

                <div id="answer1">
                    <asp:RadioButton ID="RadioButton1" runat="server" GroupName="answer" />
                </div>
                <div id="answer2">
                    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="answer" />
                </div>


                
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
               
                <div id="status">
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Italic="True" Font-Overline="True" Font-Size="Large" ForeColor="SkyBlue"></asp:Label>
                </div>
                <div id="nextButton">
                    <asp:Button ID="Button1" runat="server" Text="Next" BackColor="SkyBlue" BorderColor="Red" BorderStyle="Solid" Font-Italic="True" Font-Overline="False" Font-Strikeout="False" Font-Underline="True" Height="45px" OnClick="Button1_Click" Width="20%" />
                </div>
            </article>
        </section>
        <footer>
            <h2 style="color: whitesmoke"> SIGLA.COM</h2>
        </footer>
    </form>
</body>
</html>
