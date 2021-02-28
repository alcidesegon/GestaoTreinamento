using GestaoTreinamento.Data.ClientSQL;
using GestaoTreinamento.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace GestaoTreinamento.Data
{
    public class SalaData : IData<SalaModel>
    {

        public void Atualizar(SalaModel model)
        {
            var conexao = Connection.GetConexao();
            try
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("UPDATE SALA SET NOME = @NOME WHERE ID = @ID", conexao);
                comando.Parameters.Add(new SqlParameter("NOME", model.Nome));
                comando.Parameters.Add(new SqlParameter("ID", model.ID));

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao atualizar salas. Detalhes: " + erro.Message, erro);
            }
            finally
            {
                conexao.Close();
            }
        }

        public List<SalaModel> BuscarTodosRegistros()
        {
            var result = new List<SalaModel>();

            var conexao = Connection.GetConexao();
            try
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("SELECT ID, NOME FROM SALA", conexao);

                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new SalaModel
                    {
                        ID = Convert.ToInt64(reader["ID"]),
                        Nome = reader["NOME"].ToString(),
                    });
                }

                return result;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao buscar salas. Detalhes: " + erro.Message, erro);
            }
            finally
            {
                conexao.Close();
            }
        }

        public SalaModel BuscarPeloID(long id)
        {
            var conexao = Connection.GetConexao();
            try
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("SELECT ID, NOME FROM SALA WHERE ID = @ID", conexao);
                comando.Parameters.Add(new SqlParameter("ID", id));

                var reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    return new SalaModel
                    {
                        ID = Convert.ToInt64(reader["ID"]),
                        Nome = reader["NOME"].ToString(),
                    };
                }

                return null;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao buscar sala pelo id. Detalhes: " + erro.Message, erro);
            }
            finally
            {
                conexao.Close();
            }
        }

        public SalaModel BuscarPeloIDDiferente(long id)
        {
            var conexao = Connection.GetConexao();
            try
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("SELECT ID, NOME FROM SALA WHERE ID <> @ID", conexao);
                comando.Parameters.Add(new SqlParameter("ID", id));

                var reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    return new SalaModel
                    {
                        ID = Convert.ToInt64(reader["ID"]),
                        Nome = reader["NOME"].ToString(),
                    };
                }

                return null;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao buscar sala pelo id. Detalhes: " + erro.Message, erro);
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Criar(SalaModel model)
        {
            var conexao = Connection.GetConexao();
            try
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("INSERT INTO SALA (ID, NOME) VALUES (@ID, @NOME)", conexao);
                comando.Parameters.Add(new SqlParameter("NOME", model.Nome));
                comando.Parameters.Add(new SqlParameter("ID", Uteis.GetNextID("SALA")));

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao criar salas. Detalhes: " + erro.Message, erro);
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Excluir(long id)
        {
            var conexao = Connection.GetConexao();
            try
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand("DELETE FROM SALA WHERE ID = @ID", conexao);
                comando.Parameters.Add(new SqlParameter("ID", id));

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao excluir salas. Detalhes: " + erro.Message, erro);
            }
            finally
            {
                conexao.Close();
            }
        }

        public SalaModel BuscarProximaSalaDisponivel()
        {
            var listaApoio = new List<ApoioQuantidadeSalaModel>();

            // obtem as salas
            var salas = BuscarTodosRegistros();
            if (salas.Count > 0)
            {
                // obtem a quantidade de participantes da sala
                foreach (SalaModel sala in salas)
                {
                    int quantidade = BuscarQuantidadeParticipantes(sala.ID);

                    listaApoio.Add(new ApoioQuantidadeSalaModel
                    {
                        Sala = sala.ID,
                        Quantidade = quantidade
                    });
                }

                // ordenar a lista 
                var l = listaApoio.OrderBy(o => o.Quantidade).ToList();

                return BuscarPeloID(l.First().Sala);
            }
            return null;
        }

        public int BuscarQuantidadeParticipantes(long id)
        {
            var conexao = Connection.GetConexao();
            try
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand(@"SELECT COUNT(*) QTDE FROM PESSOATREINAMENTO A
                                                        WHERE A.SALA = @ID
                                                        GROUP BY A.SALA ", conexao);
                comando.Parameters.Add(new SqlParameter("ID", id));

                var reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    return Convert.ToInt32(reader["QTDE"]);
                }

                return 0;
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao buscar quantidade de participantes da sala. Detalhes: " + erro.Message, erro);
            }
            finally
            {
                conexao.Close();
            }
        }

        sealed class ApoioQuantidadeSalaModel
        {
            public long Sala { get; set; }
            public int Quantidade { get; set; }
        }
    }
}