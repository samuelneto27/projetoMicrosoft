using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace View.restrito.colaborador
{
    public partial class dadosColaborador : PageBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["itemSel"] != null)
                {
                    CarregarCombo();
                    Carregar();
                   
                }
            }


        }

        public void Carregar()
        {

            Colaborador c = new Colaborador();
            c.idColaborador = int.Parse(Request.QueryString["itemSel"]);

            c = new ColaboradorController().Listar(c)[0];

            ViewState.Add("itemSel", c);

            nomeColaborador.Text = c.Nome;
            cpfColaborador.Text = c.CPF;
            cmbUnidades.SelectedValue = c.unidade.idUnidade.ToString();


        }



        public void CarregarCombo()
        {

            List<Unidade> lst = new UnidadeController().Listar(new Unidade());

            foreach (Unidade item in lst)
            {
                cmbUnidades.Items.Add(new ListItem(item.nome, item.idUnidade.ToString()));
            }

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["itemSel"] == null)
                Incluir();
            else
                Alterar();


        }

        public void Incluir()
        {

            try
            {

                Colaborador colaborador = new Colaborador();

                colaborador.Nome = nomeColaborador.Text;

                colaborador.CPF = cpfColaborador.Text;

                int idSelecionado = 0;

                if (cmbUnidades.SelectedIndex > 0)
                    idSelecionado = int.Parse(cmbUnidades.SelectedValue);



                colaborador.unidade = new Unidade();

                colaborador.unidade.idUnidade = idSelecionado;

                colaborador.usuario = UsuarioLogado;

                new ColaboradorController().Incluir(colaborador);

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

                Colaborador colaborador = (Colaborador)ViewState["itemSel"];

                colaborador.Nome = nomeColaborador.Text;

                colaborador.CPF = cpfColaborador.Text;

                int idSelecionado = 0;

                if (cmbUnidades.SelectedIndex > 0)
                    idSelecionado = int.Parse(cmbUnidades.SelectedValue);

                colaborador.usuario = UsuarioLogado;

                new ColaboradorController().Atualizar(colaborador);

                Response.Redirect("listaColaborador.aspx");

            }
            catch (ConsistenciaException ex)
            {
                ExibirMensagemAlert(ex.Mensagem);
            }


        }



    }
}