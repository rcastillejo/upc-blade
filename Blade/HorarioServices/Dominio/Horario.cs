using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace HorarioServices.Dominio
{
    [DataContract]
    public class Horario
    {
        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        public String Dia { get; set; }
        [DataMember]
        public String HoraInicio { get; set; }
        [DataMember]
        public String HoraFin { get; set; }
    }
}