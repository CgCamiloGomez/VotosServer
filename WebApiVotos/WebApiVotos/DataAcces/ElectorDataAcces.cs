using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using WebApiVotos.Models;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace WebApiVotos.DataAcces
{
    public class ElectorDataAcces
    {
        private readonly string conexion = "server = CAMILOGOMEZ-PC; database = Ivotos; Integrated Security = True";

        
        public Elector_VTS ObtenerDatosElectoresPorId(string documento)
        {
            Elector_VTS elector = new Elector_VTS();

            using (SqlConnection conn = new SqlConnection(conexion))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("ObtenerDatosElectoresPorId", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Documento", documento);
                SqlDataReader registros = cmd.ExecuteReader();

                if (registros == null)
                {
                    elector = null;
                }
                else
                {
                    while (registros.Read())
                    {
                        elector.Id = registros.GetInt32(0);
                        elector.Documento = registros.GetString(1);
                        elector.Nombre = registros.GetString(2);
                        elector.Appellido = registros.GetString(3);
                        elector.coreo = registros.GetString(4);
                        elector.Telefono = registros.GetString(5);
                        elector.Dirección = registros.GetString(6);
                        elector.IdBarrio = registros.GetInt32(7);
                        elector.Voto = registros.GetBoolean(8);

                    }
                }
                conn.Close();
            }

            //if (documento == "1024542204")
            //{
            //    elector.Id = 1;
            //    elector.Documento = "1024542204";
            //    elector.Nombre = "Camilo";
            //    elector.Appellido = "Gomez";
            //    elector.coreo = "camilo_0722@hotmail.com";
            //    elector.Telefono = "3023220816";
            //    elector.Dirección = "Calle 70";
            //    elector.IdBarrio = 1;
            //    elector.Voto = false;


            //    return elector;

            //}
            //else
            //{
            //    elector = null;

            //    return elector;
            //}
            return elector;
        }
    }
}