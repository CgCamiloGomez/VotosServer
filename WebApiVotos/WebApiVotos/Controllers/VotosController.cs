using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiVotos.DataAcces;
using WebApiVotos.Models;

namespace WebApiVotos.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    
    public class VotosController : ApiController
    {
        VotosDataAcces repositorio = new VotosDataAcces();
        [HttpPost]
        public int insertarVoto(Votos_VTS voto)
        {
            return repositorio.insertarVoto(voto);
        }
        [HttpGet]
        public IHttpActionResult ObtenerVotosCandidatos()
        {
            try
            {
               var votos = repositorio.ObtenerVotosCandidatos();
                return Ok(votos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        public IHttpActionResult ObtenerVotosPuestoVotacion(int id)
        {
            try
            {
                var cantidadVotos = repositorio.ObtenerVotosPuestoVotacion(id);
                return Ok(cantidadVotos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
