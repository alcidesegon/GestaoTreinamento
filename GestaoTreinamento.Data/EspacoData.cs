using GestaoTreinamento.Data.ClientSQL;
using GestaoTreinamento.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace GestaoTreinamento.Data
{
    public class EspacoData : IData<EspacoModel>
    {

        /// <summary>
        /// Atualiza o espaço com os dados do model
        /// </summary>
        /// <param name="model"></param>
        public void Atualizar(EspacoModel model)
        {
            var conexao = Connection.GetConexao();
            try
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("UPDATE ESPACO SET NOME = @NOME WHERE ID = @ID", conexao);
                comando.Parameters.Add(new SqlParameter("NOME", model.Nome));
                comando.Parameters.Add(new SqlParameter("ID", model.ID));

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao atualizar espaços. Detalhes: " + erro.Message, erro);
            }
            finally
            {
                conexao.Close();
            }
        }

        /// <summary>
        /// Busca todos os dados dos espaços
        /// </summary>
        /// <returns></returns>
        public List<EspacoModel> BuscarTodosRegistros()
        {
            var result = new List<EspacoModel>();

            var conexao = Connection.GetConexao();
            try
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("SELECT ID, NOME FROM ESPACO", conexao);

                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new EspacoModel
                    {
                        ID = Convert.ToInt64(reader["ID"]),
                        Nome = reader["NOME"].ToString(),
                    });
                }

                return result;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao buscar espaços. Detalhes: " + erro.Message, erro);
            }
            finally
            {
                conexao.Close();
            }
        }

        /// <summary>
        /// Busca o espaço pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EspacoModel BuscarPeloID(long id)
        {
            var conexao = Connection.GetConexao();
            try
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("SELECT ID, NOME FROM ESPACO WHERE ID = @ID", conexao);
                comando.Parameters.Add(new SqlParameter("ID", id));

                var reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    return new EspacoModel
                    {
                        ID = Convert.ToInt64(reader["ID"]),
                        Nome = reader["NOME"].ToString(),
                    };
                }

                return null;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao buscar espaço pelo id. Detalhes: " + erro.Message, erro);
            }
            finally
            {
                conexao.Close();
            }
        }

        /// <summary>
        /// Cria o espaço de café
        /// </summary>
        /// <param name="model"></param>
        public void Criar(EspacoModel model)
        {
            var conexao = Connection.GetConexao();
            try
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("INSERT INTO ESPACO (ID, NOME) VALUES (@ID, @NOME)", conexao);
                comando.Parameters.Add(new SqlParameter("NOME", model.Nome));
                comando.Parameters.Add(new SqlParameter("ID", Uteis.GetNextID("ESPACO")));

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao criar espaços. Detalhes: " + erro.Message, erro);
            }
            finally
            {
                conexao.Close();
            }
        }

        /// <summary>
        /// Remove o espaço de café
        /// </summary>
        /// <param name="id"></param>
        public void Excluir(long id)
        {
            var conexao = Connection.GetConexao();
            try
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("DELETE FROM ESPACO WHERE ID = @ID", conexao);
                comando.Parameters.Add(new SqlParameter("ID", id));

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao excluir espaços. Detalhes: " + erro.Message, erro);
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}