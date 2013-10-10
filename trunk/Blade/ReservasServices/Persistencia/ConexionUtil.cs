using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservasServices.Persistencia
{
    public class ConexionUtil
    {

        public static string ObtenerCadena()
        {

            return "Server=f4c3a964-6431-4404-ab3c-a23a011a31e3.sqlserver.sequelizer.com;Database=dbf4c3a96464314404ab3ca23a011a31e3;User ID=kmmmddyaybfhqpfe;Password=xJJMsTWfREhDo24n6HSf7JgiEj7ouJcDxgCnEFFMNxTLaBUghaueZgkVBAgiVHSh;";
            //return "Data Source=.\\SQLRCL;Initial Catalog=DB_EspacioDeportivo;Integrated Security=SSPI;User ID=sa; Password=sql;";
        }
    }
}