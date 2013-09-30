using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using EspacioDeportivoServices.Persistencia;
using EspacioDeportivoServices.Excepcion;

namespace EspacioDeportivoServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "SedeService" en el código, en svc y en el archivo de configuración a la vez.
    public class SedeService : ISedeService
    {
        private SedeDAO sedeDAO = new SedeDAO();

        
        public List<Dominio.Sede> listar()
        {
            ICollection<Dominio.Sede> sedes = sedeDAO.ListarTodos();
            if (sedes == null) {
                throw new FaultException<ValidationException>(new ValidationException
                {
                    ValidationError = "No existe sedes disponibles"
                }, new FaultReason("No existe sedes disponibles"));
            }
            return (List<Dominio.Sede>)sedes.ToList();
        }
    }
}
