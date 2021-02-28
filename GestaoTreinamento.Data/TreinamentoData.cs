using GestaoTreinamento.Data.ClientSQL;
using GestaoTreinamento.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace GestaoTreinamento.Data
{
    public class TreinamentoData : IData<TreinamentoModel>
    {

        /// <summary>
        /// Atualiza o treinamento
        /// </summary>
        /// <param name="model"></param>
        public void Atualizar(TreinamentoModel model)
        {
            var conexao = Connection.GetConexao();
            try
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("UPDATE TREINAMENTO SET NOME = @NOME, DATAINICIO = @DATAINICIO, DATAFIM = @DATAFIM, SITUACAO = @SITUACAO WHERE ID = @ID", conexao);
                comando.Parameters.Add(new SqlParameter("NOME", model.Nome));
                comando.Parameters.Add(new SqlParameter("DATAINICIO", model.DataInicio));
                comando.Parameters.Add(new SqlParameter("DATAFIM", model.DataFim));
                comando.Parameters.Add(new SqlParameter("SITUACAO", model.Situacao));
                comando.Parameters.Add(new SqlParameter("ID", model.ID));

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao atualizar treinamentos. Detalhes: " + erro.Message, erro);
            }
            finally
            {
                conexao.Close();
            }
        }

        /// <summary>
        /// Busca os treinamentos cadastrados
        /// </summary>
        /// <returns></returns>
        public List<TreinamentoModel> BuscarTodosRegistros()
        {
            var result = new List<TreinamentoModel>();

            var conexao = Connection.GetConexao();
            try
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("SELECT ID, NOME, DATAINICIO, DATAFIM, SITUACAO FROM TREINAMENTO", conexao);

                var cultureInfo = new CultureInfo("pr-BR", false);

                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new TreinamentoModel
                    {
                        ID = Convert.ToInt64(reader["ID"]),
                        Nome = reader["NOME"].ToString(),
                        DataInicio = Convert.ToDateTime(reader["DATAINICIO"].ToString(), cultureInfo),
                        DataFim = Convert.ToDateTime(reader["DATAFIM"].ToString(), cultureInfo),
                        Situacao = (SituacaoEnum)Convert.ToInt32(reader["SITUACAO"])
                    });
                }

                return result;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao buscar treinamentos. Detalhes: " + erro.Message, erro);
            }
            finally
            {
                conexao.Close();
            }
        }

        /// <summary>
        /// Busca o treinamento pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TreinamentoModel BuscarPeloID(long id)
        {
            var conexao = Connection.GetConexao();
            try
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("SELECT ID, NOME, DATAINICIO, DATAFIM FROM TREINAMENTO WHERE ID = @ID", conexao);
                comando.Parameters.Add(new SqlParameter("ID", id));

                var cultureInfo = new CultureInfo("pr-BR", false);

                var reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    return new TreinamentoModel
                    {
                        ID = Convert.ToInt64(reader["ID"]),
                        Nome = reader["NOME"].ToString(),
                        DataInicio = Convert.ToDateTime(reader["DATAINICIO"].ToString(), cultureInfo),
                        DataFim = Convert.ToDateTime(reader["DATAFIM"].ToString(), cultureInfo),
                    };
                }

                return null;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao buscar treinamento pelo id. Detalhes: " + erro.Message, erro);
            }
            finally
            {
                conexao.Close();
            }
        }

        /// <summary>
        /// Cria o treinamento
        /// </summary>
        /// <param name="model"></param>
        public void Criar(TreinamentoModel model)
        {
            var conexao = Connection.GetConexao();
            try
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("INSERT INTO TREINAMENTO (ID, NOME, DATAINICIO, DATAFIM, SITUACAO) VALUES (@ID, @NOME, @DATAINICIO, @DATAFIM, @SITUACAO)", conexao);
                comando.Parameters.Add(new SqlParameter("NOME", model.Nome));
                comando.Parameters.Add(new SqlParameter("DATAINICIO", model.DataInicio));
                comando.Parameters.Add(new SqlParameter("DATAFIM", model.DataFim));
                comando.Parameters.Add(new SqlParameter("ID", Uteis.GetNextID("TREINAMENTO")));
                comando.Parameters.Add(new SqlParameter("SITUACAO", (int)model.Situacao));

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao criar treinamentos. Detalhes: " + erro.Message, erro);
            }
            finally
            {
                conexao.Close();
            }
        }

        /// <summary>
        /// Remove o treinamento
        /// </summary>
        /// <param name="id"></param>
        public void Excluir(long id)
        {
            var conexao = Connection.GetConexao();
            try
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("DELETE FROM TREINAMENTO WHERE ID = @ID", conexao);
                comando.Parameters.Add(new SqlParameter("ID", id));

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao excluir treinamentos. Detalhes: " + erro.Message, erro);
            }
            finally
            {
                conexao.Close();
            }
        }

        /// <summary>
        /// Atualiza o treinamento para concluido
        /// </summary>
        /// <param name="model"></param>
        public void Concluir(TreinamentoModel model)
        {
            model.Situacao = SituacaoEnum.Concluido;

            Atualizar(model);
        }

        /// <summary>
        /// Verifica se o treinamento eh valido e atualiza a situação
        /// </summary>
        /// <param name="model"></param>
        public void Validar(TreinamentoModel model)
        {
            var listaSalas = new SalaData().BuscarTodosRegistros();
            if (!PossuiDuasSalasCadastradas(listaSalas))
            {
                return;
            }

            var listaEspacos = new EspacoData().BuscarTodosRegistros();
            if (!PossuiDoisEspacosCadastrados(listaEspacos))
            {
                return;
            }

            model.Situacao = SituacaoEnum.Valido;

            Atualizar(model);
        }

        /// <summary>
        /// Verifica se existem duas salas cadastradas
        /// </summary>
        /// <param name="salas"></param>
        /// <returns></returns>
        public bool PossuiDuasSalasCadastradas(List<SalaModel> salas)
        {
            return salas.Count >= 2;
        }

        /// <summary>
        /// Verifica se existem dois espaços cadastrados
        /// </summary>
        /// <param name="espacos"></param>
        /// <returns></returns>
        public bool PossuiDoisEspacosCadastrados(List<EspacoModel> espacos)
        {
            return espacos.Count >= 2;
        }

    }
}