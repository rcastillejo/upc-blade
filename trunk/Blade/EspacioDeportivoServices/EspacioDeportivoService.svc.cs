using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using EspacioDeportivoServices.Dominio;
using EspacioDeportivoServices.Persistencia;
using EspacioDeportivoServices.Excepcion;

namespace EspacioDeportivoServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "EspacioDeportivoService" en el código, en svc y en el archivo de configuración a la vez.
    public class EspacioDeportivoService : IEspacioDeportivoService
    {
         

        private EspacioDeportivoDAO espacioDeportivoDAO = new EspacioDeportivoDAO();

        /*private EspacioDeportivoDAO EspacioDeportivoDAO
        {
            get
            {
                if (espacioDeportivoDAO == null)
                    espacioDeportivoDAO = new EspacioDeportivoDAO();
                return espacioDeportivoDAO;
            }
        }*/

        private SedeDAO sedeDAO = new SedeDAO();

        /*private SedeDAO SedeDAO
        {
            get
            {
                if (sedeDAO == null)
                    sedeDAO = new SedeDAO();
                return sedeDAO;
            }
        }*/


        public EspacioDeportivo obtener(int Codigo)
        {
            
            EspacioDeportivo espacio = espacioDeportivoDAO.Obtener(Codigo);
            if (espacio == null)
            {
                throw new FaultException<ValidationException>(new ValidationException
                {
                    ValidationError = "El espacio deportivo no se encuentra disponible"
                }, new FaultReason("El espacio deportivo no se encuentra disponible"));
            }
            return espacio;            
        }

        public List<EspacioDeportivo> lista()
        {
            return (List<EspacioDeportivo>)espacioDeportivoDAO.ListarTodos().ToList();
        }

        public EspacioDeportivo crear(string nombre, int sede)
        {
            EspacioDeportivo espacioDeportivo;

            try
            {
                Sede sedeExistente = sedeDAO.Obtener(sede);

                espacioDeportivo = new EspacioDeportivo()
                {
                    Nombre = nombre,
                    Sede = sedeExistente
                };

                EspacioDeportivo espacioDeportivoResultado = espacioDeportivoDAO.Crear(espacioDeportivo);

            }
            catch
            {
                throw new FaultException<ValidationException>(new ValidationException
                {
                    ValidationError = "Error al registrar espacio deportivo"
                }, new FaultReason("Error al registrar espacio deportivo"));

            }
            return espacioDeportivo;
        }

        public EspacioDeportivo actualizar(int codigo, string nombre, int sede)
        {
            EspacioDeportivo espacioDeportivo;
            try
            {
                Sede sedeExistente = sedeDAO.Obtener(sede);

                espacioDeportivo = new EspacioDeportivo()
                {
                    Codigo = codigo,
                    Nombre = nombre,
                    Sede = sedeExistente
                };

                EspacioDeportivo espacioDeportivoResultado = espacioDeportivoDAO.Modificar(espacioDeportivo);
            }
            catch
            {
                throw new FaultException<ValidationException>(new ValidationException
                {
                    ValidationError = "Error al guardar espacio deportivo"
                }, new FaultReason("Error al guardar espacio deportivo"));
            }
            return espacioDeportivo;
        }

        public void eliminar(int codigo)
        {
            try
            {
                EspacioDeportivo espacioDeportivo = espacioDeportivoDAO.Obtener(codigo);
                espacioDeportivoDAO.Eliminar(espacioDeportivo);
            }
            catch
            {
                throw new FaultException<ValidationException>(new ValidationException
                {
                    ValidationError = "Error al eliminar espacio deportivo"
                }, new FaultReason("Error al eliminar espacio deportivo"));
            }

        }
    }
}
