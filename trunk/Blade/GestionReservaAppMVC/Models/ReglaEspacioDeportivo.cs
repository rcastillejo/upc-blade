using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionReservaAppMVC.Models
{
    public class ReglaEspacioDeportivo
    {
        public EspacioDeportivo EspacioDeportivo { get; set; }
        public int MinAnticipacionReservarMinuto{ get; set; }
        public int MaxAnticipacionReservaDia { get; set; }
        public int MinAnticipacionCancelarHora { get; set; }
        public int MaxHoraReservaDia { get; set; }
        public int MaxHoraReservaSemana { get; set; }
        public int MaxNumUsuario{ get; set; }
    }
}