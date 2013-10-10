using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using HorarioServices.Dominio;

namespace HorarioServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IHorarios" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IHorarios
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Horarios", ResponseFormat = WebMessageFormat.Json)]
        String RegistrarHorario(Horario horarioACrear);


        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Horarios", ResponseFormat = WebMessageFormat.Json)]
        String ActualizarHorario(Horario horarioACrear);

        //En caso se decida agregar variables, /dni={dni}&nom={nombre}
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Horarios/{codigo}/{dia}", ResponseFormat = WebMessageFormat.Json)]
        Horario ObtenerHorario(string codigo, string dia);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Horarios?codigo={codigo}&fecha={fecha}", ResponseFormat = WebMessageFormat.Json)]
        Horario ObtenerHorarioPorFecha(string codigo, string fecha);
        
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Horarios/{codigo}/{dia}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarHorario(string codigo, string dia);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Horarios/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        List<Horario> ListarHorarios(string codigo);
    }
}
