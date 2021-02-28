using System;
using System.Configuration;
using System.Data.SqlClient;

namespace GestaoTreinamento.Data.ClientSQL
{

    public class Connection
    {
        public static SqlConnection GetConexao()
        {
            try
            {
                string dbConnection = ConfigurationSettings.AppSettings["DBConnection"];

                SqlConnection conexao = new SqlConnection(dbConnection);

                return conexao;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao obter conexão do banco de dados. Detalhes: " + erro.Message, erro);
            }
        }
    }
}
