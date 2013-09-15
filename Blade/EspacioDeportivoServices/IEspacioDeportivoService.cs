using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using EspacioDeportivoServices.Dominio;

namespace EspacioDeportivoServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IEspacioDeportivoService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IEspacioDeportivoService
    {
        [OperationContract]
        EspacioDeportivo obtener(int Codigo);
        [OperationContract]
        List<EspacioDeportivo> lista();
        [OperationContract]
        EspacioDeportivo crear(string nombre, int sede);
        [OperationContract]
        EspacioDeportivo actualizar(int codigo, string nombre, int sede);
        [OperationContract]
        void eliminar(int Codigo);
    }
}
