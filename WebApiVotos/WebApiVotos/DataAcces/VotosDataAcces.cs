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
                cmd.Parameters.AddWithValue("@IdElector", voto.IdElector);
                guardo = cmd.ExecuteNonQuery();

                
                conn.Close();
            }
                return guardo;
        }

        public List<Candidato_VTS>  ObtenerVotosPorCandidato()
        {
            List<Candidato_VTS> votosCandidatos = new List<Candidato_VTS>(); 
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("consultarVotos",conn);
                conn.Close();
            }
            return votosCandidatos;
        }

        public int ObtenerVotosPuestoVotacion()
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("consultarVotos", conn);
                conn.Close();
            }
            return 0;
        }
    }
}