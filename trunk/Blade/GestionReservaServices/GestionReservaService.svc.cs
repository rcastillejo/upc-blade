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

        public EspacioDeportivoWS.EspacioDeportivo crearEspacio(string nombre, int sede)
        {
            return proxyEspacio.crear(nombre, sede);
        }

        public EspacioDeportivoWS.EspacioDeportivo actualizarEspacio(int codigo, string nombre, int sede)
        {
            return proxyEspacio.actualizar(codigo, nombre, sede);
        }

        public void eliminarEspacio(int Codigo)
        {
            proxyEspacio.eliminar(Codigo);
        }


        public List<SedeWS.Sede> listarSede()
        {
            return proxySede.listar().ToList();
        }
    }
}
