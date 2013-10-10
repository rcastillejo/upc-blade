using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GestionReservaServices.EspacioDeportivoWS;
using GestionReservaServices.Dominio;

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


        [FaultContract(typeof(ValidationException))]
        [OperationContract]
        string registrarHorario(int codigo, string dia, string horaInicio, string horaFin);

        [FaultContract(typeof(ValidationException))]
        [OperationContract]
        string actualizarHorario(int codigo, string dia, string horaInicio, string horaFin);

        [FaultContract(typeof(ValidationException))]
        [OperationContract]
        Horario obtenerHorario(int codigo, string dia);

        [FaultContract(typeof(ValidationException))]
        [OperationContract]
        string eliminarHorario(int codigo, string dia);

        [FaultContract(typeof(ValidationException))]
        [OperationContract]
        List<Horario> listarHorario(int codigo);


        [FaultContract(typeof(ValidationException))]
        [OperationContract]
        string registrarReserva(int codigoEspacio, int cantHoras, string fechaInicio);


        [FaultContract(typeof(ValidationException))]
        [OperationContract]
        List<Reserva> listarReserva();
    }
}
