using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionReservaAppMVC.Models
{
    public class DetalleHorario
    {
        public Horario Horario { get; set; }
        public String Dia { get; set; }
        public String Horainicio { get; set; }
        public String HoraFin { get; set; }
    }
}