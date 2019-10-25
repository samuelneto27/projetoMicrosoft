<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="View.inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Digite o CPF:
            <asp:TextBox ID="txtCpf" runat="server" MaxLength="11"></asp:TextBox>
            <br />
            Digite a Senha:
            <asp:TextBox ID="txtSenha" runat="server" MaxLength="45" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Button ID="btnOk" runat="server" Text="OK" OnClick="btnOk_Click"/>
            <br />
            <asp:Label ID="lblMensagem" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
