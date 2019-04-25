using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private string StringConexao = "Data Source= .\\SqlExpress; initial catalog = InLock_Games_Tarde; user id = sa; password = 132 ";

        public List<EstudioDomain> Listar()
        {
            List<EstudioDomain> listaEstudios = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QuerySelect = "SELECT ESTUDIOID ,NOMEESTUDIO FROM ESTUDIOS";

            using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
            {
                con.Open();

                SqlDataReader sdr = cmd.ExecuteReader();

                while(sdr.Read())
                {
                        EstudioDomain estudio = new EstudioDomain
                        {
                            EstudioId = Convert.ToInt32(sdr["ESTUDIOID"]),
                            NomeEstudio = sdr["NOMEESTUDIO"].ToString()
                        };

                    listaEstudios.Add(estudio);
                }
               }
             }
        return listaEstudios;
        }
    }
}
