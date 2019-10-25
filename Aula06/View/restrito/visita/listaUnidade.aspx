<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="listaUnidade.aspx.cs" Inherits="View.restrito.unidade.listaUnidade" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Lista de unidades</h1>
            <br/>
            <asp:GridView ID="dgvLista" runat="server" BackColor="LightGoldenrodYellow"
                BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None"
                AutoGenerateColumns="false" OnRowCommand="dgvLista_RowCommand">
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <FooterStyle BackColor="Tan" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <SortedAscendingCellStyle BackColor="#FAFAE7" />
                <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                <SortedDescendingCellStyle BackColor="#E1DB9C" />
                <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                <Columns>
                    <asp:BoundField DataField="idUnidade" HeaderText="ID" ItemStyle-Height="16px" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="nome" HeaderText="Nome" ItemStyle-Height="16px" ItemStyle-Width="240px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" ItemStyle-Height="16px" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="usuario.Nome" HeaderText="Ult alteração" ItemStyle-Height="16px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" />
                    <asp:ButtonField CommandName="alterar" ButtonType="Image" ImageUrl="~/publico/imagens/16alterar.png" HeaderText="Alterar" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center"  />
                    <asp:ButtonField CommandName="excluir" ButtonType="Image" ImageUrl="~/publico/imagens/16delete.png" HeaderText="Excluir" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
        </div>
    </form>
</body>
</html>
