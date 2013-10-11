using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace MensajeriaService.Dominio
{

    [DataContract]
    public class Reserva
    {
        [DataMember]
        public int Codigo { get; set; }

        [DataMember]
        public int CodigoEspacio { get; set; }

        [DataMember]
        public string Dia { get; set; }

        [DataMember]
        public string FechaInicio { get; set; }

        [DataMember]
        public string FechaFin { get; set; }

        [DataMember]
        public int CantidadHoras { get; set; }

        [DataMember]
        public string Estado { get; set; }

    }
}