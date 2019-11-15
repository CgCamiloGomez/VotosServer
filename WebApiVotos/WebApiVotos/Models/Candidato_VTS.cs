using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiVotos.Models
{
    public class Candidato_VTS
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string partido { get; set; }
        public int cantidadvotos { get; set; }
    }
}