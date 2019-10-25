using Model;
using System;
using System.Web.UI;

namespace View
{
    public class PageBase : System.Web.UI.Page
    {

        public Usuario UsuarioLogado
        {
            get
            {
                return (Usuario)Session["UsuarioLogado"];
            }
            set
            {
                Session.Add("UsuarioLogado", value);
            }
        }

        protected override void OnLoad(EventArgs e)
        {

            if (!Page.IsPostBack)
                ValidarAcesso();

            base.OnLoad(e);

        }

        protected override void OnError(EventArgs e)
        { 

            Exception ex = Server.GetLastError();

            Response.Redirect("~/publico/erro.aspx");

            base.OnError(e);

        }

        public void ExibirMensagemAlert(String textoMensagem)
        {
            ScriptManager.RegisterStartupScript(this.Page, GetType(), "mensagemAlert", String.Format("alert('{0}')", textoMensagem), true);
        }

        public void ValidarAcesso()
        {

            bool acesso = false;

            for (int i = 0; i < UsuarioLogado.listaPaginaAcesso.Count; i++)
            {

                if (UsuarioLogado.listaPaginaAcesso[i].url != null)
                {

                    String aux = UsuarioLogado.listaPaginaAcesso[i].url;

                    aux = aux.Substring(aux.IndexOf('/'));

                    if (Page.AppRelativeVirtualPath.Contains(aux))
                    {
                        acesso = true;
                    }

                }
                
            }

            if (!acesso)
                Response.Redirect("../menu.aspx");

        }

    }
}