using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GestionReservaServices.EspacioDeportivoWS;

namespace GestionReservaServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IGestionReservaService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IGestionReservaService
    {
        [FaultContract(typeof(ValidationException))]
        [OperationContract]
        EspacioDeportivoWS.EspacioDeportivo obtenerEspacio(int codigo);

        [FaultContract(typeof(ValidationException))]
        [OperationContract]
        List<EspacioDeportivoWS.EspacioDeportivo> listarEspacio();

        [FaultContract(typeof(ValidationException))]
        [OperationContract]
        String crearEspacio(string nombre, int sede);

        [FaultContract(typeof(ValidationException))]
        [OperationContract]
        String actualizarEspacio(int codigo, string nombre, int sede);

        [FaultContract(typeof(ValidationException))]
        [OperationContract]
        String eliminarEspacio(int Codigo);


        [FaultContract(typeof(ValidationException))]
        [OperationContract]
        List<SedeWS.Sede> listarSede();
    }
}
