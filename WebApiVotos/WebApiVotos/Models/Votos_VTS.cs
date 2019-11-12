using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiVotos.Models
{
    public class Votos_VTS
    {
        public int IdVoto {get; set;}
        public int IdPuestoVotacion {get; set;}
        public int IdCandidato  { get; set; }
    } 
}