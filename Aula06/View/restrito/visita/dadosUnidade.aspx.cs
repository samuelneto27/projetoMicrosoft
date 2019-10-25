using Controller;
using Model;
using System;
using System.Web.UI;

namespace View.restrito.unidade
{
    public partial class dadosUnidade : PageBase
    {

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        { 

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["itemSel"] != null)
                {
                    Carregar();
                }
            }

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["itemSel"] == null)
                Incluir();
            else
                Alterar();
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {

            if (Request.QueryString["itemSel"] == null)
                Response.Redirect("../menu.aspx");
            else
                Response.Redirect("listaUnidade.aspx");

        }

        #endregion

        #region Métodos

        public void Carregar()
        {

            Unidade u = new Unidade();
            u.idUnidade = int.Parse(Request.QueryString["itemSel"]);

            u = new UnidadeController().Listar(u)[0];

            ViewState.Add("itemSel", u);

            txtNome.Text = u.nome;
            cmbEstados.Text = u.estado;

        }

        public void Incluir()
        {

            try
            {

                Unidade unidade = new Unidade();

                unidade.nome = txtNome.Text;

                if (cmbEstados.SelectedIndex > 0)
                    unidade.estado = cmbEstados.Text;

                unidade.usuario = UsuarioLogado;

                new UnidadeController().Incluir(unidade);

                Response.Redirect("../menu.aspx");

            }
            catch (ConsistenciaException ex)
            {
                ExibirMensagemAlert(ex.Mensagem);
            }

        }

        public void Alterar()
        {

            try
            {

                Unidade unidade = (Unidade)ViewState["itemSel"];

                unidade.nome = txtNome.Text;

                if (cmbEstados.SelectedIndex > 0)
                    unidade.estado = cmbEstados.Text;

                unidade.usuario = UsuarioLogado;

                new UnidadeController().Atualizar(unidade);

                Response.Redirect("listaUnidade.aspx");

            }
            catch (ConsistenciaException ex)
            {
                ExibirMensagemAlert(ex.Mensagem);
            }

        }

        #endregion

    }
}