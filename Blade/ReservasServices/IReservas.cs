using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using ReservasServices.Dominio;

namespace ReservasServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IReservas" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IReservas
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Reservas", ResponseFormat = WebMessageFormat.Json)]
        string RegistrarReserva(Reserva horarioACrear);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Reservas", ResponseFormat = WebMessageFormat.Json)]
        string ActualizarReserva(Reserva horarioACrear);

        //En caso se decida agregar variables, /dni={dni}&nom={nombre}
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Reservas/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        Reserva ObtenerReserva(string codigo);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Reservas/{codigo}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarReserva(string codigo);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Reservas", ResponseFormat = WebMessageFormat.Json)]
        List<Reserva> ListarReservas();
    }
}
