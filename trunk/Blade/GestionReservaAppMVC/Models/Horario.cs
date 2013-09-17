using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionReservaAppMVC.Models
{
    public class Horario
    {
        public int Codigo { get; set; }
        public EspacioDeportivo EspacioDeportivo { get; set; }
        public Sede  Sede { get; set; }
        public String  Dia { get; set; }
        public String Horainicio { get; set; }
        public String HoraFin { get; set; }
     }
}