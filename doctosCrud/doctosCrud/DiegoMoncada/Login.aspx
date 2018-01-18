<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="doctosCrud.DiegoMoncada.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <a href="DoctorCrud.aspx">Doctors</a>
    <form id="form1" runat="server">
        <div id="login" runat="server">
            <asp:Label runat="server">Username:</asp:Label>
            <asp:TextBox ID="txt_user" runat="server"></asp:TextBox>
            <asp:Label runat="server">Password:</asp:Label>
            <asp:TextBox ID="txt_psw" runat="server"></asp:TextBox>
            <asp:Button text="login" runat="server" OnClick="login_click"/>
            <asp:Label ID="lbl_error" runat="server" ForeColor="Salmon"></asp:Label>
        </div>
        <div id="logout" runat="server" >
            <asp:Label runat="server" ID="lbl_welcome">Welcome </asp:Label>
            <asp:Button text="logout" runat="server" OnClick="logout_click"/>
        </div>
    </form>
</body>
</html>
