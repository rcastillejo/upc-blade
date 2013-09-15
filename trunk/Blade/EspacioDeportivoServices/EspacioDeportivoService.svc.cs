using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using EspacioDeportivoServices.Dominio;
using EspacioDeportivoServices.Persistencia;

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
            return espacioDeportivoDAO.Obtener(Codigo);
        }

        public List<EspacioDeportivo> lista()
        {
            return (List<EspacioDeportivo>)espacioDeportivoDAO.ListarTodos().ToList();
        }

        public EspacioDeportivo crear(string nombre, int sede)
        {
            Sede sedeExistente = sedeDAO.Obtener(sede);

            EspacioDeportivo espacioDeportivo = new EspacioDeportivo() 
            { 
                Nombre = nombre,
                Sede = sedeExistente
            };

            return espacioDeportivoDAO.Crear(espacioDeportivo);

        }

        public EspacioDeportivo actualizar(int codigo, string nombre, int sede)
        {
            Sede sedeExistente = sedeDAO.Obtener(sede);

            EspacioDeportivo espacioDeportivo = new EspacioDeportivo()
            {
                Codigo = codigo,
                Nombre = nombre,
                Sede = sedeExistente
            };

            return espacioDeportivoDAO.Modificar(espacioDeportivo);
        }

        public void eliminar(int codigo)
        {
            EspacioDeportivo espacioDeportivo = espacioDeportivoDAO.Obtener(codigo);
            espacioDeportivoDAO.Eliminar(espacioDeportivo);
        }
    }
}
