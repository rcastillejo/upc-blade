using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GestionReservaServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "GestionReservaService" en el código, en svc y en el archivo de configuración a la vez.
    public class GestionReservaService : IGestionReservaService
    {
        EspacioDeportivoWS.EspacioDeportivoServiceClient proxyEspacio = new EspacioDeportivoWS.EspacioDeportivoServiceClient();
        SedeWS.SedeServiceClient proxySede = new SedeWS.SedeServiceClient();


        public EspacioDeportivoWS.EspacioDeportivo obtenerEspacio(int codigo)
        {
            return proxyEspacio.obtener(codigo);
        }


        public List<EspacioDeportivoWS.EspacioDeportivo> listarEspacio()
        {
            return proxyEspacio.lista().ToList();
        }

        public string crearEspacio(string nombre, int sede)
        {
            EspacioDeportivoWS.EspacioDeportivo espacioDeportivoResultado = proxyEspacio.crear(nombre, sede);

            return "El espacio deportivo ha sido guardado exitosamente (" + espacioDeportivoResultado.Codigo + ")";
        }

        public string actualizarEspacio(int codigo, string nombre, int sede)
        {
            EspacioDeportivoWS.EspacioDeportivo espacioDeportivoResultado = proxyEspacio.actualizar(codigo, nombre, sede);
            return "El espacio deportivo ha sido guardado exitosamente (" + espacioDeportivoResultado.Codigo + ")";
        }

        public string eliminarEspacio(int Codigo)
        {
            proxyEspacio.eliminar(Codigo);
            return "El espacio deportivo ha sido eliminado exitosamente";
        }

        public List<SedeWS.Sede> listarSede()
        {
            return proxySede.listar().ToList();
        }
    }
}
