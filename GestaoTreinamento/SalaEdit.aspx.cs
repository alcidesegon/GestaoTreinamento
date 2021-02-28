using GestaoTreinamento.Data;
using GestaoTreinamento.Model;
using System;
using System.Web.UI;

namespace GestaoTreinamento
{
    public partial class SalaEdit : Page
    {

        public long ID
        {
            get
            {
                if (Request["id"] != null)
                {
                    return Convert.ToInt64(Request["id"]);
                }
                return 0;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarDados();
            }
        }

        private void CarregarDados()
        {
            var model = new SalaData().BuscarPeloID(ID);
            if (model != null)
            {
                txtNome.Text = model.Nome;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sala");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!IsValid)
                return;

            new SalaData().Atualizar(new SalaModel
            {
                ID = ID,
                Nome = txtNome.Text,
            });

            Response.Redirect("Sala");
        }
    }
}