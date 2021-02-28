using GestaoTreinamento.Data.ClientSQL;
using GestaoTreinamento.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace GestaoTreinamento.Data
{
    public class PessoaData : IData<PessoaModel>
    {
        /// <summary>
        /// Atualiza a pessoa com os dados do model
        /// </summary>
        /// <param name="model"></param>
        public void Atualizar(PessoaModel model)
        {
            var conexao = Connection.GetConexao();
            try
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("UPDATE PESSOA SET NOME = @NOME, SOBRENOME = @SOBRENOME WHERE ID = @ID", conexao);
                comando.Parameters.Add(new SqlParameter("NOME", model.Nome));
                comando.Parameters.Add(new SqlParameter("SOBRENOME", model.Sobrenome));
                comando.Parameters.Add(new SqlParameter("ID", model.ID));

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao atualizar pessoas. Detalhes: " + erro.Message, erro);
            }
            finally
            {
                conexao.Close();
            }
        }

        /// <summary>
        /// Busca todos as pessoas existentes
        /// </summary>
        /// <returns></returns>
        public List<PessoaModel> BuscarTodosRegistros()
        {
            var result = new List<PessoaModel>();

            var conexao = Connection.GetConexao();
            try
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("SELECT ID, NOME, SOBRENOME FROM PESSOA", conexao);

                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new PessoaModel
                    {
                        ID = Convert.ToInt64(reader["ID"]),
                        Nome = reader["NOME"].ToString(),
                        Sobrenome = reader["SOBRENOME"].ToString(),
                    });
                }

                return result;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao buscar pessoas. Detalhes: " + erro.Message, erro);
            }
            finally
            {
                conexao.Close();
            }
        }

        /// <summary>
        /// Busca a pessoa pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PessoaModel BuscarPeloID(long id)
        {
            var conexao = Connection.GetConexao();
            try
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("SELECT ID, NOME, SOBRENOME FROM PESSOA WHERE ID = @ID", conexao);
                comando.Parameters.Add(new SqlParameter("ID", id));

                var reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    return new PessoaModel
                    {
                        ID = Convert.ToInt64(reader["ID"]),
                        Nome = reader["NOME"].ToString(),
                        Sobrenome = reader["SOBRENOME"].ToString(),
                    };
                }

                return null;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao buscar pessoa pelo id. Detalhes: " + erro.Message, erro);
            }
            finally
            {
                conexao.Close();
            }
        }

        /// <summary>
        /// Cria a pessoa
        /// </summary>
        /// <param name="model"></param>
        public void Criar(PessoaModel model)
        {
            var conexao = Connection.GetConexao();
            try
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("INSERT INTO PESSOA (ID, NOME, SOBRENOME) VALUES (@ID, @NOME, @SOBRENOME)", conexao);
                comando.Parameters.Add(new SqlParameter("NOME", model.Nome));
                comando.Parameters.Add(new SqlParameter("SOBRENOME", model.Sobrenome));
                comando.Parameters.Add(new SqlParameter("ID", Uteis.GetNextID("PESSOA")));

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao criar pessoas. Detalhes: " + erro.Message, erro);
            }
            finally
            {
                conexao.Close();
            }
        }

        /// <summary>
        /// Remove a pessoa
        /// </summary>
        /// <param name="id"></param>
        public void Excluir(long id)
        {
            var conexao = Connection.GetConexao();
            try
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("DELETE FROM PESSOA WHERE ID = @ID", conexao);
                comando.Parameters.Add(new SqlParameter("ID", id));

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao excluir pessoas. Detalhes: " + erro.Message, erro);
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
