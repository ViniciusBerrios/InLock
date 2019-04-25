using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string StringConexao = "Data Source =.\\SqlExpress; initial catalog = InLock_Games_Tarde; user id = sa; password = 132";

        public void Cadastrar(JogoDomain jogo)
        {
            string QueryInsert = @"INSERT INTO JOGOS (NOMEJOGO, DESCRICAO, DATALANCAMENTO, VALOR, ID_ESTUDIOS)
                                 VALUES (@NOMEJOGO, @DESCRICAO, @DATALANCAMENTO, @VALOR, @ID_ESTUDIOS)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@NOMEJOGO", jogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@DESCRICAO", jogo.Descricao);
                    cmd.Parameters.AddWithValue("@DATALANCAMENTO", jogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@VALOR", jogo.Valor);
                    cmd.Parameters.AddWithValue("@ID_ESTUDIOS", jogo.EstudiosId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogoDomain> Listar()
        {
            List<JogoDomain> listaJogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QuerySelect = "SELECT JOGOID, NOMEJOGO, DESCRICAO, DATALANCAMENTO, VALOR, ID_ESTUDIOS FROM JOGOS";

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    con.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    while(sdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain
                        {
                            JogoId = Convert.ToInt32(sdr["JOGOID"]),
                            NomeJogo = sdr["NOMEJOGO"].ToString(),
                            Descricao = sdr["DESCRICAO"].ToString(),
                            DataLancamento = Convert.ToDateTime(sdr["DATALANCAMENTO"]),
                            Valor = Convert.ToDecimal(sdr["VALOR"]),
                            Estudio = new EstudioDomain
                            {
                                EstudioId = Convert.ToInt32(sdr["ID_ESTUDIOS"])
                                
                            }
                        };

                        listaJogos.Add(jogo);
                    }
                }
            }

            return listaJogos;
        }
    }
}
