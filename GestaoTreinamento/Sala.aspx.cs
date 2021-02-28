using GestaoTreinamento.Data;
using System;
using System.Web.UI;

namespace GestaoTreinamento
{
    public partial class Sala : Page
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
            gridSalas.DataSource = new SalaData().BuscarTodosRegistros();
            gridSalas.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("SalaNew");
        }

        protected void gridSalas_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            Response.Redirect("SalaEdit?id=" + gridSalas.Rows[e.RowIndex].Cells[0].Text);
        }

        protected void gridSalas_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            new SalaData().Excluir(Convert.ToInt64(gridSalas.Rows[e.RowIndex].Cells[0].Text));
            CarregarDados();
        }
    }
}