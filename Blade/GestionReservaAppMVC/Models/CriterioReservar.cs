using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionReservaAppMVC.Models
{
    public class CriterioReservar
    {        
        public Sede Sede { get; set; }
        public EspacioDeportivo EspacioDeportivo { get; set; }               
        public int NumHoras { get; set; }
        public string FechaInicio { get; set; }
        public string FechaTermino { get; set; }                 
    }
}