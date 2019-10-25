using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace View.restrito.unidade
{
    public partial class listaUnidade : PageBase
    {

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                Carregar();
        }

        protected void dgvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "alterar":
                    {

                        int id = int.Parse(dgvLista.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text);

                        Response.Redirect("dadosUnidade.aspx?itemSel="+id);

                    }
                    break;

                case "excluir":
                    {

                        Unidade u = new Unidade();
                        u.idUnidade = int.Parse(dgvLista.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text);

                        new UnidadeController().Excluir(u);
                        Carregar();

                    }
                    break;
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../menu.aspx");
        }

        #endregion

        #region Métodos

        public void Carregar()
        {
            List<Unidade> unidades = new UnidadeController().Listar(new Unidade());

            dgvLista.DataSource = unidades;

            dgvLista.DataBind();
        }

        #endregion

    }
}