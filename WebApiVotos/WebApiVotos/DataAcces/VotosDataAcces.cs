using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApiVotos.Models;

namespace WebApiVotos.DataAcces
{
    public class VotosDataAcces
    {
        private readonly string conexion = "server = CAMILOGOMEZ-PC; database = Ivotos; Integrated Security = True";

        public int insertarVoto(Votos_VTS voto)
        {
            Votos_VTS votos = new Votos_VTS();
            int guardo;

            using (SqlConnection conn = new SqlConnection(conexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("InsertarVoto", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCandidato", voto.IdCandidato);
                cmd.Parameters.AddWithValue("@IdPuestoVotacion", voto.IdPuestoVotacion);
                guardo = cmd.ExecuteNonQuery();

                
                conn.Close();
            }
                return guardo;
        }
    }
}