using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace View
{
    public partial class menu : System.Web.UI.Page
    {

        Usuario usuarioLogado;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                CarregarMenu();
        }

        public void CarregarMenu()
        {

            usuarioLogado = (Usuario)Session["usuarioLogado"];

            // Gera os primeiros itens, os Pais do Menu (no caso os pais possuem código 0)
            List<Pagina> itemsPai = (from x in usuarioLogado.listaPaginaAcesso
                                        where x.idPai == null
                                        select x).ToList();

            foreach (Pagina item in itemsPai)
            {

                // Cria o menuItem para o PAI 
                MenuItem menuItem = new MenuItem(item.descricao, item.idPagina.ToString(), string.Empty, item.url, string.Empty);

                // Inicializa a recursão com o item pai e seu menuItem. 
                CarregarItemMenu(item, menuItem);

                // Adiciona o menuItem e seus filhos à treew view 
                menuCascata.Items.Add(menuItem);

            }

            menuCascata.DataBind();

        }

        protected void CarregarItemMenu(Pagina pai, MenuItem menuItemPai)
        {

            // Recupera os itens do Menu que são do ITEM (pai) passado como parâmetro para a função 
            List<Pagina> temp = (from x in usuarioLogado.listaPaginaAcesso
                                 where x.idPai == pai.idPagina
                                    select x).ToList();

            // Para cada filho encontrado 
            foreach (Pagina item in temp)
            {

                // Cria um novo "MenuItem" para o menu atribuindo nome, código e url 
                MenuItem menuItem = new MenuItem(item.descricao, item.idPagina.ToString(), string.Empty, item.url, string.Empty);

                // Chama a função recursivamente para o novo MenuItem criado. 
                CarregarItemMenu(item, menuItem);

                // Adiciona ao MenuItem pai o seu filho 
                menuItemPai.ChildItems.Add(menuItem);

            }

        }

    }
}