using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiVotos.DataAcces;
using WebApiVotos.Models;
using System.Web.Http.Cors;

namespace WebApiVotos.Controllers
{
    [EnableCors(origins: "*", headers:"*", methods:"*")]
    public class ElectoresController : ApiController
    {
        //public ICollection<Elector_VTS> GetAllElectores()
        //{
        //    return
        //}
        // GET: api/Prueba/5
        ElectorDataAcces repositorio = new ElectorDataAcces();
        [HttpGet]
        public IHttpActionResult GetdElectorById(string id)
        {
            
            try
            {
                var data = repositorio.ObtenerDatosElectoresPorId(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
