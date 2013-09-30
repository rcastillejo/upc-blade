using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using EspacioDeportivoServices.Dominio;
using EspacioDeportivoServices.Excepcion;

namespace EspacioDeportivoServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IEspacioDeportivoService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IEspacioDeportivoService
    {
        [FaultContract(typeof(ValidationException))]
        [OperationContract]
        EspacioDeportivo obtener(int Codigo);

        [FaultContract(typeof(ValidationException))]
        [OperationContract]
        List<EspacioDeportivo> lista();

        [FaultContract(typeof(ValidationException))]
        [OperationContract]
        EspacioDeportivo crear(string nombre, int sede);

        [FaultContract(typeof(ValidationException))]
        [OperationContract]
        EspacioDeportivo actualizar(int codigo, string nombre, int sede);

        [FaultContract(typeof(ValidationException))]
        [OperationContract]
        void eliminar(int Codigo);
    }
}
