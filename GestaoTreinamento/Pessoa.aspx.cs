using GestaoTreinamento.Data;
using System;
using System.Web.UI;

namespace GestaoTreinamento
{
    public partial class Pessoa : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarDados();
            }
        }

        private void CarregarDados()
        {
            gridPessoas.DataSource = new PessoaData().BuscarTodosRegistros();
            gridPessoas.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("PessoaNew");
        }
        
        protected void gridPessoas_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            Response.Redirect("PessoaEdit?id=" + gridPessoas.Rows[e.RowIndex].Cells[0].Text);
        }

        protected void gridPessoas_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            new PessoaData().Excluir(Convert.ToInt64(gridPessoas.Rows[e.RowIndex].Cells[0].Text));
            CarregarDados();
        }
    }
}