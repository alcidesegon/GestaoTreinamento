using GestaoTreinamento.Data.ClientSQL;
using System;
using System.Data.SqlClient;

namespace GestaoTreinamento.Data
{
    public class Uteis
    {

        public static long GetNextID(string tabela)
        {
            long result = 1;

            var conexao = Connection.GetConexao();
            try
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand($"SELECT MAX(ID) + 1 ID FROM {tabela}", conexao);

                var reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["ID"] != DBNull.Value)
                        result = Convert.ToInt64(reader["ID"]);
                }

                return result;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao buscar id. Detalhes: " + erro.Message, erro);
            }
            finally
            {
                conexao.Close();
            }
        }

    }
}
