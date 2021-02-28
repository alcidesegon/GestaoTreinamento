using GestaoTreinamento.Data;
using GestaoTreinamento.Model;
using System;
using System.Web.UI;

namespace GestaoTreinamento
{
    public partial class SalaNew : Page
    {
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sala");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!IsValid)
                return;

            new SalaData().Criar(new SalaModel
            {
                Nome = txtNome.Text,
            });

            Response.Redirect("Sala");
        }
    }
}