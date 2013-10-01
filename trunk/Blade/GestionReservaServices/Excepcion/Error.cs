using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace HorarioServices.Excepcion
{
    [DataContract]
    public class Error
    {
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]
        public string Mensaje { get; set; }

    }
}