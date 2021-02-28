using GestaoTreinamento.Data;
using GestaoTreinamento.Model;
using System;
using System.Globalization;
using System.Web.UI;

namespace GestaoTreinamento
{
    public partial class TreinamentoEdit : Page
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
            var model = new TreinamentoData().BuscarPeloID(ID);
            if (model != null)
            {
                txtNome.Text = model.Nome;
                txtInicio.Text = model.DataInicio.ToString();
                txtTermino.Text = model.DataFim.ToString();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!IsValid)
                return;

            new TreinamentoData().Atualizar(new TreinamentoModel
            {
                ID = ID,
                Nome = txtNome.Text,
                DataInicio = Convert.ToDateTime(txtInicio.Text, new CultureInfo("pt-BR", false)),
                DataFim = Convert.ToDateTime(txtTermino.Text, new CultureInfo("pt-BR", false)),
            });

            Response.Redirect("Default");
        }

        protected void btnValidar_Click(object sender, EventArgs e)
        {
            var data = new TreinamentoData();
            data.Validar(data.BuscarPeloID(ID));

            Response.Redirect("Default");
        }

        protected void btnConcluir_Click(object sender, EventArgs e)
        {
            var data = new TreinamentoData();
            data.Concluir(data.BuscarPeloID(ID));

            Response.Redirect("Default");
        }
    }
}