using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GestionReservaServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IGestionReservaService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IGestionReservaService
    {
        [OperationContract]
        EspacioDeportivoWS.EspacioDeportivo obtenerEspacio(int codigo);
        [OperationContract]
        List<EspacioDeportivoWS.EspacioDeportivo> listarEspacio();
        [OperationContract]
        EspacioDeportivoWS.EspacioDeportivo crearEspacio(string nombre, int sede);
        [OperationContract]
        EspacioDeportivoWS.EspacioDeportivo actualizarEspacio(int codigo, string nombre, int sede);
        [OperationContract]
        void eliminarEspacio(int Codigo);


        [OperationContract]
        List<SedeWS.Sede> listarSede();
    }
}
