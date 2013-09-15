using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace EspacioDeportivoServices.Dominio
{
    [DataContract]
    public class Sede
    {
        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        public String Nombre { get; set; }
    }
}