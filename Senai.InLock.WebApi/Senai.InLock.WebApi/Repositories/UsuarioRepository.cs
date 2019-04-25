using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = @"Data Source = .\SqlExpress; initial catalog = InLock_Games_Tarde; user id = sa; password = 132";

        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QuerySelect = "SELECT USUARIOID, EMAIL, SENHA, TIPOUSUARIO FROM USUARIOS WHERE EMAIL = @EMAIL AND SENHA = @SENHA";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    cmd.Parameters.AddWithValue("@EMAIL", email);
                    cmd.Parameters.AddWithValue("@SENHA", senha);

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if(sdr.HasRows)
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain();
                        while(sdr.Read())
                        {
                            usuarioBuscado.USUARIOID = Convert.ToInt32(sdr["USUARIOID"]);
                            usuarioBuscado.EMAIL = sdr["EMAIL"].ToString();
                            usuarioBuscado.SENHA = sdr["SENHA"].ToString();
                            usuarioBuscado.TIPOUSUARIO = sdr["TIPOUSUARIO"].ToString();
                        }
                        return usuarioBuscado;
                    }
                    return null;
                }
            }
        }
    }
}
