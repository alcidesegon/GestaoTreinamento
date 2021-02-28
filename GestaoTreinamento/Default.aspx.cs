using GestaoTreinamento.Data;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestaoTreinamento
{
    public partial class _Default : Page
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
            gridTreinamentos.DataSource = new TreinamentoData().BuscarTodosRegistros();
            gridTreinamentos.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("TreinamentoNew");
        }

        protected void gridTreinamentos_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            Response.Redirect("TreinamentoEdit?id=" + gridTreinamentos.Rows[e.RowIndex].Cells[0].Text);
        }

        protected void gridTreinamentos_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            new TreinamentoData().Excluir(Convert.ToInt64(gridTreinamentos.Rows[e.RowIndex].Cells[0].Text));

            CarregarDados();
        }

        protected void gridTreinamentos_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandArgument.ToString() == "")
                return;

            int index = Convert.ToInt32(e.CommandArgument);
            var id = gridTreinamentos.Rows[index].Cells[0].Text;

            Response.Redirect("Participante?id=" + id);
        }

        protected void gridTreinamentos_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                switch (e.Row.Cells[4].Text)
                {
                    case "1":
                        e.Row.Cells[1].Text = "Cadastrado";
                        break;
                    case "2":
                        e.Row.Cells[1].Text = "Válido";
                        break;
                    case "3":
                        e.Row.Cells[1].Text = "Concluído";
                        break;
                }                
            }
        }
    }
}