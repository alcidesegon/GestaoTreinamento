using GestaoTreinamento.Data;
using System;
using System.Web.UI;

namespace GestaoTreinamento
{
    public partial class Espaco : Page
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
            gridEspacos.DataSource = new EspacoData().BuscarTodosRegistros();
            gridEspacos.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("EspacoNew");
        }

        protected void gridEspacos_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            Response.Redirect("EspacoEdit?id=" + gridEspacos.Rows[e.RowIndex].Cells[0].Text);
        }

        protected void gridEspacos_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            new EspacoData().Excluir(Convert.ToInt64(gridEspacos.Rows[e.RowIndex].Cells[0].Text));
            CarregarDados();
        }
    }
}