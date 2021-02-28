using GestaoTreinamento.Data;
using GestaoTreinamento.Model;
using System;
using System.Web.UI;

namespace GestaoTreinamento
{
    public partial class ParticipanteNew : Page
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
                CarregarPessoas();
                CarregarEspacos();
                CarregarSalas();

                PreencherSala();
            }
        }

        private void CarregarPessoas()
        {
            cbPessoa.DataSource = new PessoaData().BuscarTodosRegistros();
            cbPessoa.DataBind();
        }

        private void CarregarSalas()
        {
            cbSala.DataSource = new SalaData().BuscarTodosRegistros();
            cbSala.DataBind();
        }

        private void CarregarEspacos()
        {
            cbEspaco.DataSource = new EspacoData().BuscarTodosRegistros();
            cbEspaco.DataBind();
        }

        private void PreencherSala()
        {
            var model = new SalaData().BuscarProximaSalaDisponivel();
            if (model != null)
            {
                cbSala.SelectedValue = model.ID.ToString();
            }
            else
            {
                cbSala.Text = "NENHUMA SALA CADASTRADA";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Participante.aspx?id=" + ID.ToString());
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!IsValid)
                return;

            new PessoaTreinamentoData().Criar(new PessoaTreinamentoModel
            {
                Treinamento = ID,
                Pessoa = Convert.ToInt64(cbPessoa.SelectedValue),
                Sala = Convert.ToInt64(cbSala.SelectedValue),
                Espaco = Convert.ToInt64(cbEspaco.SelectedValue),
            });

            Response.Redirect("Participante.aspx?id=" + ID.ToString());
        }
    }
}