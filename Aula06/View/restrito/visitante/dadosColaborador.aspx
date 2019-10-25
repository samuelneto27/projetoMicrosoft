<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dadosColaborador.aspx.cs" Inherits="View.restrito.colaborador.dadosColaborador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Dados do colaborador</h1>
            <br />
            Nome do Colaborador: <br />
            <asp:TextBox ID="nomeColaborador" runat="server" MaxLength="50"></asp:TextBox>
            <br/>
            CPF do Colaborador: <br />
            <asp:TextBox ID="cpfColaborador" runat="server" MaxLength="11"></asp:TextBox>
            <br/>
            Unidade do Colaborador: <br />
            <asp:DropDownList ID="cmbUnidades" runat="server">
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
        </div>
    </form>
</body>
</html>
