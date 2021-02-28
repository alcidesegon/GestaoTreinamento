using GestaoTreinamento.Data;
using GestaoTreinamento.Model;
using System;
using System.Web.UI;

namespace GestaoTreinamento
{
    public partial class EspacoNew : Page
    {
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Espaco");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!IsValid)
                return;

            new EspacoData().Criar(new EspacoModel
            {
                Nome = txtNome.Text,
            });

            Response.Redirect("Espaco");
        }
    }
}