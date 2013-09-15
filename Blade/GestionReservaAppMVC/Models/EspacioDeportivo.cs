using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionReservaAppMVC.Models
{
    public class EspacioDeportivo
    {
        public int Codigo { get; set; }
        public String Nombre { get; set; }
        public Sede Sede { get; set; }
        public String apellido { get; set; }
    }
}