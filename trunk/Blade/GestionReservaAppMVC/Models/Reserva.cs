using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionReservaAppMVC.Models
{
    public class Reserva
    {
        public string CodReserva { get; set; }
          public Sede Sede { get; set; }
          public EspacioDeportivo EspacioDeportivo { get; set; }
          public Actividad Actividad { get; set; }
          public  Usuario Usuario { get; set; }
         public DateTime FechaReserva { get; set; }
         public string DiaCorto { get; set; }
         public string HoraInicio { get; set; }
         public string HoraTermino { get; set; }
         public EstadoReserva Estado { get; set; }
         
          
    }
}