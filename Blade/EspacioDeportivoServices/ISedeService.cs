using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using EspacioDeportivoServices.Dominio;

namespace EspacioDeportivoServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ISedeService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ISedeService
    {
        [OperationContract]
        List<Sede> listar();
    }
}
