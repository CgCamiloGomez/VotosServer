using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiVotos.Models
{
    public class Elector_VTS
    {
        public int    Id        { get; set; }
        public string Documento { get; set; }
        public string Nombre    { get; set; }
        public string Appellido { get; set; }
        public string coreo     { get; set; }
        public string Telefono  { get; set; }
        public string Dirección { get; set; }
        public int    IdBarrio  { get; set; }
        public bool   Voto      { get; set; }
    }
}