using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MensajeriaService.Dominio;

namespace MensajeriaService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IMensajes
    {

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Mensajes", ResponseFormat = WebMessageFormat.Json)]
        void Grabar(Reserva horarioACrear);

        [WebInvoke(Method = "GET", UriTemplate = "Mensajes", ResponseFormat = WebMessageFormat.Json)]
        List<Reserva> Listar();
    }

}
