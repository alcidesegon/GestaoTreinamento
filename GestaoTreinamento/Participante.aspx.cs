using GestaoTreinamento.Data;
using GestaoTreinamento.Model;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestaoTreinamento
{
    public partial class Participante : Page
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

        public string Treinamento { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarDados();
                CarregarTreinamento();
            }
        }

        private void CarregarTreinamento()
        {
            var model = new TreinamentoData().BuscarPeloID(ID);
            if (model != null)
            {
                Treinamento = model.Nome;
            }
        }

        private void CarregarDados()
        {
            gridParticipantes.DataSource = new PessoaTreinamentoData().BuscarTodosRegistrosPeloTreinamento(ID);
            gridParticipantes.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("ParticipanteNew.aspx?id=" + ID.ToString());
        }
        
        protected void gridParticipantes_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            new PessoaTreinamentoData().Excluir(Convert.ToInt64(gridParticipantes.Rows[e.RowIndex].Cells[0].Text));

            CarregarDados();
        }

        protected void gridParticipantes_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var modelPessoa = new PessoaData().BuscarPeloID(Convert.ToInt64(e.Row.Cells[1].Text));
                if (modelPessoa != null)
                {
                    e.Row.Cells[1].Text = modelPessoa.Nome;
                }

                var modelSala = new SalaData().BuscarPeloID(Convert.ToInt64(e.Row.Cells[2].Text));
                if (modelSala != null)
                {
                    e.Row.Cells[2].Text = modelSala.Nome;
                }
            }
        }

        protected void btnReorganizar_Click(object sender, EventArgs e)
        {
            var dataParticipante = new PessoaTreinamentoData();
            var dataSala = new SalaData();

            var lista = dataParticipante.BuscarTodosRegistrosPeloTreinamento(ID);

            foreach (PessoaTreinamentoModel item in lista)
            {
                var modelSala = dataSala.BuscarPeloIDDiferente(item.Sala);
                if (modelSala != null)
                {
                    dataParticipante.OrganizarParticipantes(ID, item.Sala, modelSala.ID);
                }
            }

            CarregarDados();
        }
    }
}