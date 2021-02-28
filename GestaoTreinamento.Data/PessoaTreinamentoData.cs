using GestaoTreinamento.Data.ClientSQL;
using GestaoTreinamento.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace GestaoTreinamento.Data
{
    /// <summary>
    /// Classe de participantes do treinamento
    /// </summary>
    public class PessoaTreinamentoData : IData<PessoaTreinamentoModel>
    {

        /// <summary>
        /// Atualiza o participante com os dados do model
        /// </summary>
        /// <param name="model"></param>
        public void Atualizar(PessoaTreinamentoModel model)
        {
            var conexao = Connection.GetConexao();
            try
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("UPDATE PESSOATREINAMENTO SET PESSOA = @PESSOA, TREINAMENTO = @TREINAMENTO, SALA = @SALA, ESPACO = @ESPACO WHERE ID = @ID", conexao);
                comando.Parameters.Add(new SqlParameter("PESSOA", model.Pessoa));
                comando.Parameters.Add(new SqlParameter("TREINAMENTO", model.Treinamento));
                comando.Parameters.Add(new SqlParameter("SALA", model.Sala));
                comando.Parameters.Add(new SqlParameter("ESPACO", model.Espaco));
                comando.Parameters.Add(new SqlParameter("ID", model.ID));

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao atualizar participantes. Detalhes: " + erro.Message, erro);
            }
            finally
            {
                conexao.Close();
            }
        }

        /// <summary>
        /// Busca todos os participantes
        /// </summary>
        /// <returns></returns>
        public List<PessoaTreinamentoModel> BuscarTodosRegistros()
        {
            var result = new List<PessoaTreinamentoModel>();

            var conexao = Connection.GetConexao();
            try
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("SELECT ID, PESSOA, TREINAMENTO, SALA, ESPACO FROM PESSOATREINAMENTO", conexao);

                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new PessoaTreinamentoModel
                    {
                        ID = Convert.ToInt64(reader["ID"]),
                        Pessoa = Convert.ToInt64(reader["PESSOA"]),
                        Treinamento = Convert.ToInt64(reader["TREINAMENTO"]),
                        Sala = Convert.ToInt64(reader["SALA"]),
                        Espaco = Convert.ToInt64(reader["ESPACO"]),
                    });
                }

                return result;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao buscar participantes. Detalhes: " + erro.Message, erro);
            }
            finally
            {
                conexao.Close();
            }
        }

        /// <summary>
        /// Busca lista dos participantes pelo id do treinamento
        /// </summary>
        /// <param name="treinamento"></param>
        /// <returns></returns>
        public List<PessoaTreinamentoModel> BuscarTodosRegistrosPeloTreinamento(long treinamento)
        {
            var result = new List<PessoaTreinamentoModel>();

            var conexao = Connection.GetConexao();
            try
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand(@"SELECT A.ID, A.PESSOA, A.TREINAMENTO, A.SALA, A.ESPACO FROM PESSOATREINAMENTO A 
                                                        WHERE A.TREINAMENTO = @TREINAMENTO", conexao);

                comando.Parameters.Add(new SqlParameter("TREINAMENTO", treinamento));

                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new PessoaTreinamentoModel
                    {
                        ID = Convert.ToInt64(reader["ID"]),
                        Pessoa = Convert.ToInt64(reader["PESSOA"]),
                        Treinamento = Convert.ToInt64(reader["TREINAMENTO"]),
                        Sala = Convert.ToInt64(reader["SALA"]),
                        Espaco = Convert.ToInt64(reader["ESPACO"])
                    });
                }

                return result;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao buscar participantes. Detalhes: " + erro.Message, erro);
            }
            finally
            {
                conexao.Close();
            }
        }

        /// <summary>
        /// Busca o participante pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PessoaTreinamentoModel BuscarPeloID(long id)
        {
            var conexao = Connection.GetConexao();
            try
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("SELECT ID, PESSOA, TREINAMENTO, SALA, ESPACO FROM PESSOATREINAMENTO WHERE ID = @ID", conexao);
                comando.Parameters.Add(new SqlParameter("ID", id));

                var reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    return new PessoaTreinamentoModel
                    {
                        ID = Convert.ToInt64(reader["ID"]),
                        Pessoa = Convert.ToInt64(reader["PESSOA"]),
                        Treinamento = Convert.ToInt64(reader["TREINAMENTO"]),
                        Sala = Convert.ToInt64(reader["SALA"]),
                        Espaco = Convert.ToInt64(reader["ESPACO"]),
                    };
                }

                return null;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao buscar participante pelo id. Detalhes: " + erro.Message, erro);
            }
            finally
            {
                conexao.Close();
            }
        }

        /// <summary>
        /// Cria o participante
        /// </summary>
        /// <param name="model"></param>
        public void Criar(PessoaTreinamentoModel model)
        {
            var conexao = Connection.GetConexao();
            try
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("INSERT INTO PESSOATREINAMENTO (ID, PESSOA, TREINAMENTO, SALA, ESPACO) VALUES (@ID, @PESSOA, @TREINAMENTO, @SALA, @ESPACO)", conexao);
                comando.Parameters.Add(new SqlParameter("PESSOA", model.Pessoa));
                comando.Parameters.Add(new SqlParameter("TREINAMENTO", model.Treinamento));
                comando.Parameters.Add(new SqlParameter("SALA", model.Sala));
                comando.Parameters.Add(new SqlParameter("ESPACO", model.Espaco));
                comando.Parameters.Add(new SqlParameter("ID", Uteis.GetNextID("PESSOATREINAMENTO")));

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao criar participantes. Detalhes: " + erro.Message, erro);
            }
            finally
            {
                conexao.Close();
            }
        }

        /// <summary>
        /// Remove o participante
        /// </summary>
        /// <param name="id"></param>
        public void Excluir(long id)
        {
            var conexao = Connection.GetConexao();
            try
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("DELETE FROM PESSOATREINAMENTO WHERE ID = @ID", conexao);
                comando.Parameters.Add(new SqlParameter("ID", id));

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao excluir participantes. Detalhes: " + erro.Message, erro);
            }
            finally
            {
                conexao.Close();
            }
        }

        /// <summary>
        /// Metodo utilizado para as consultas do sistema por pessoa
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        public List<ApoioConsultaPessoasModel> BuscarPessoasConsulta(long pessoa)
        {
            var result = new List<ApoioConsultaPessoasModel>();

            var conexao = Connection.GetConexao();
            try
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand(@"SELECT E.NOME, E.SOBRENOME, B.NOME AS TREINAMENTO, C.NOME AS SALA, D.NOME AS ESPACO
                                                        FROM PESSOATREINAMENTO A
                                                        INNER JOIN TREINAMENTO B ON B.ID = A.TREINAMENTO
                                                        INNER JOIN SALA C ON C.ID = A.SALA
                                                        INNER JOIN ESPACO D ON D.ID = A.ESPACO
                                                        INNER JOIN PESSOA E ON E.ID = A.PESSOA 
                                                        WHERE A.PESSOA = @PESSOA", conexao);

                comando.Parameters.Add(new SqlParameter("PESSOA", pessoa));

                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new ApoioConsultaPessoasModel
                    {
                        Nome = reader["NOME"].ToString(),
                        Sobrenome = reader["SOBRENOME"].ToString(),
                        Treinamento = reader["TREINAMENTO"].ToString(),
                        Sala = reader["SALA"].ToString(),
                        Espaco = reader["ESPACO"].ToString(),
                    });
                }

                return result;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao buscar participantes. Detalhes: " + erro.Message, erro);
            }
            finally
            {
                conexao.Close();
            }
        }

        /// <summary>
        /// Metodo utilizado para as consulta do sistema por sala
        /// </summary>
        /// <param name="sala"></param>
        /// <returns></returns>
        public List<ApoioConsultaSalasModel> BuscarSalasConsulta(long sala)
        {
            var result = new List<ApoioConsultaSalasModel>();

            var conexao = Connection.GetConexao();
            try
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand(@"SELECT E.NOME, B.NOME AS TREINAMENTO, D.NOME AS ESPACO
                                                        FROM PESSOATREINAMENTO A
                                                        INNER JOIN TREINAMENTO B ON B.ID = A.TREINAMENTO
                                                        INNER JOIN SALA C ON C.ID = A.SALA
                                                        INNER JOIN ESPACO D ON D.ID = A.ESPACO
                                                        INNER JOIN PESSOA E ON E.ID = A.PESSOA 
                                                        WHERE A.SALA = @SALA", conexao);

                comando.Parameters.Add(new SqlParameter("SALA", sala));

                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new ApoioConsultaSalasModel
                    {
                        Nome = reader["NOME"].ToString(),
                        Treinamento = reader["TREINAMENTO"].ToString(),
                        Espaco = reader["ESPACO"].ToString(),
                    });
                }

                return result;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao buscar participantes. Detalhes: " + erro.Message, erro);
            }
            finally
            {
                conexao.Close();
            }
        }

        /// <summary>
        /// Troca os participantes de sala, para distribuir o conhecimento
        /// </summary>
        /// <param name="treinamento"></param>
        /// <param name="sala"></param>
        /// <param name="salaNova"></param>
        public void OrganizarParticipantes(long treinamento, long sala, long salaNova)
        {
            var conexao = Connection.GetConexao();
            try
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand(@"UPDATE PESSOATREINAMENTO SET SALA = @SALANOVA WHERE SALA = @SALA", conexao);
                comando.Parameters.Add(new SqlParameter("SALANOVA", salaNova));
                comando.Parameters.Add(new SqlParameter("SALA", sala));

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao organizar participantes. Detalhes: " + erro.Message, erro);
            }
            finally
            {
                conexao.Close();
            }
        }

    }
}