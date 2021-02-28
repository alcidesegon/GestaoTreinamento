using GestaoTreinamento.Data;
using GestaoTreinamento.Model;
using System;
using System.Globalization;
using System.Web.UI;

namespace GestaoTreinamento
{
    public partial class TreinamentoNew : Page
    {

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!IsValid)
                return;

            new TreinamentoData().Criar(new TreinamentoModel
            {
                Nome = txtNome.Text,
                DataInicio = Convert.ToDateTime(txtInicio.Text, new CultureInfo("pt-BR", false)),
                DataFim = Convert.ToDateTime(txtTermino.Text, new CultureInfo("pt-BR", false)),
                Situacao = SituacaoEnum.Cadastrado
            });

            Response.Redirect("Default");
        }
    }
}