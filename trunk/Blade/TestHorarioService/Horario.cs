using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace TestHorarioService
{
    public class Horario
    {
        public int Codigo { get; set; }
        public String Dia { get; set; }
        public String HoraInicio { get; set; }
        public String HoraFin { get; set; }
    }
}