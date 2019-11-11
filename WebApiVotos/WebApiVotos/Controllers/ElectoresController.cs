using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiVotos.DataAcces;
using WebApiVotos.Models;

namespace WebApiVotos.Controllers
{
    public class ElectoresController : ApiController
    {
        //public ICollection<Elector_VTS> GetAllElectores()
        //{
        //    return
        //}
        // GET: api/Prueba/5
        ElectorDataAcces repositorio = new ElectorDataAcces();

        public Elector_VTS GetdElectorById(string id)
        {
            
            return repositorio.ObtenerDatosElectoresPorId(id);
        }
    }
}
