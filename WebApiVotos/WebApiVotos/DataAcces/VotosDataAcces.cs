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
        //private string conexionStringRaps = ConfigurationManager.ConnectionStrings["conectionDataBase"].ConnectionString;
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

        public List<Candidato_VTS> ObtenerVotosCandidatos()
        {
            List<Candidato_VTS> votosCandidatos = new List<Candidato_VTS>();
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("consultarVotos", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader registros = cmd.ExecuteReader();
                while (registros.Read())
                {
                    Candidato_VTS votosCandidato = new Candidato_VTS
                    {

                        nombre = registros["CAN_Nombre"].ToString(),
                        cantidadvotos = (int)registros["CantidadVotos"]
                    };
                    votosCandidatos.Add(votosCandidato);
                }
                conn.Close();
            }
            return votosCandidatos;
        }

        public int ObtenerVotosPuestoVotacion(int id)
        {
            int numVotos = 0;
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("consultarVotosPorPtoVotacion", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPuestoVotacion", id);
                var numeroVotos = cmd.ExecuteScalar();
                numVotos = (int)numeroVotos;
                conn.Close();
            }
            return numVotos;
        }
    }
}