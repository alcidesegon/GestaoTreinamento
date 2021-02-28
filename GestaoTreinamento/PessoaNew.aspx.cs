using GestaoTreinamento.Data;
using GestaoTreinamento.Model;
using System;
using System.Web.UI;

namespace GestaoTreinamento
{
    public partial class PessoaNew : Page
    {
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pessoa");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!IsValid)
                return;

            new PessoaData().Criar(new PessoaModel
            {
                Nome = txtNome.Text,
                Sobrenome = txtSobrenome.Text
            });

            Response.Redirect("Pessoa");
        }
    }
}