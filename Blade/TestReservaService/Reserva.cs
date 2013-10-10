using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservasServices.Dominio
{
    public class Reserva
    {
        public int Codigo { get; set; }

        public int CodigoEspacio { get; set; }

        public string Dia { get; set; }

        public string FechaInicio { get; set; }

        public string FechaFin { get; set; }

        public int CantidadHoras{ get; set; }

        public string Estado { get; set; }

    }
}