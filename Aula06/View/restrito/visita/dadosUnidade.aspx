<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dadosUnidade.aspx.cs" Inherits="View.restrito.unidade.dadosUnidade" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Dados da unidade</h1>
            <br />
            Nome da unidade: <br />
            <asp:TextBox ID="txtNome" runat="server" MaxLength="50"></asp:TextBox>
            <br/>
            <br />
            Estado: <br />
            <asp:DropDownList ID="cmbEstados" runat="server">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>AC</asp:ListItem>
                <asp:ListItem>AL</asp:ListItem>
                <asp:ListItem>AP</asp:ListItem>
                <asp:ListItem>AM</asp:ListItem>
                <asp:ListItem>BA</asp:ListItem>
                <asp:ListItem>CE</asp:ListItem>
                <asp:ListItem>DF</asp:ListItem>
                <asp:ListItem>ES</asp:ListItem>
                <asp:ListItem>GO</asp:ListItem>
                <asp:ListItem>MA</asp:ListItem>
                <asp:ListItem>MT</asp:ListItem>
                <asp:ListItem>MS</asp:ListItem>
                <asp:ListItem>MG</asp:ListItem>
                <asp:ListItem>PA</asp:ListItem>
                <asp:ListItem>PB</asp:ListItem>
                <asp:ListItem>PR</asp:ListItem>
                <asp:ListItem>PE</asp:ListItem>
                <asp:ListItem>PI</asp:ListItem>
                <asp:ListItem>RJ</asp:ListItem>
                <asp:ListItem>RN</asp:ListItem>
                <asp:ListItem>RS</asp:ListItem>
                <asp:ListItem>RO</asp:ListItem>
                <asp:ListItem>RR</asp:ListItem>
                <asp:ListItem>SC</asp:ListItem>
                <asp:ListItem>SP</asp:ListItem>
                <asp:ListItem>SE</asp:ListItem>
                <asp:ListItem>TO</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
            &nbsp;
            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
        </div>
    </form>
</body>
</html>
