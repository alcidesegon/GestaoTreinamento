using GestaoTreinamento.Data;
using System;
using System.Web.UI;

namespace GestaoTreinamento
{
    public partial class Consulta : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarPessoas();
                CarregarSalas();
            }
        }

        private void CarregarPessoas()
        {
            cbPessoas.DataSource = new PessoaData().BuscarTodosRegistros();
            cbPessoas.DataBind();
        }

        private void CarregarSalas()
        {
            cbSala.DataSource = new SalaData().BuscarTodosRegistros();
            cbSala.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("PessoaNew");
        }

        protected void btnBuscarPessoas_Click(object sender, EventArgs e)
        {
            long pessoa = Convert.ToInt64(cbPessoas.SelectedValue);

            gridPessoas.DataSource = new PessoaTreinamentoData().BuscarPessoasConsulta(pessoa);
            gridPessoas.DataBind();
        }

        protected void btnBuscarSala_Click(object sender, EventArgs e)
        {
            long sala = Convert.ToInt64(cbSala.SelectedValue);

            gridSalas.DataSource = new PessoaTreinamentoData().BuscarSalasConsulta(sala);
            gridSalas.DataBind();
        }
    }
}