using GestaoTreinamento.Data;
using GestaoTreinamento.Model;
using System;
using System.Web.UI;

namespace GestaoTreinamento
{
    public partial class PessoaEdit : Page
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
            var model = new PessoaData().BuscarPeloID(ID);
            if (model != null)
            {
                txtNome.Text = model.Nome;
                txtSobrenome.Text = model.Sobrenome;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pessoa");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!IsValid)
                return;

            new PessoaData().Atualizar(new PessoaModel
            {
                ID = ID,
                Nome = txtNome.Text,
                Sobrenome = txtSobrenome.Text
            });

            Response.Redirect("Pessoa");
        }
    }
}