using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ReservasServices.Persistencia;
using ReservasServices.Dominio;
using System.ServiceModel.Web;
using ReservasServices.Excepcion;
using System.Net;

namespace ReservasServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Reservas" en el código, en svc y en el archivo de configuración a la vez.
    public class Reservas : IReservas
    {


        private ReservaDAO dao = new ReservaDAO();

        public string RegistrarReserva(Reserva reservaACrear)
        {
            List<Reserva> reservaObtenidos = dao.ValidarDisponibilidad(reservaACrear);
            Reserva reservaReservada = null;
            if (reservaObtenidos.Count > 0) {
                reservaReservada = reservaObtenidos.Single(delegate(Reserva reserva)
                {
                    if (reserva.Estado.Equals(Estado.RESERVADO) || reserva.Estado.Equals(Estado.CONFIRMADO))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                });
            }
            

            if (reservaReservada != null)
            {
                throw new WebFaultException<Error>(
                        new Error()
                        {
                            Codigo = "ERR004",
                            Mensaje = "El espacio deportivo ya ha sido reservado"
                        },
                            HttpStatusCode.InternalServerError);
            }

            Reserva reservaRegistrado = null;

            reservaRegistrado = dao.Crear(reservaACrear);

            return "La reserva registrada exitosamente (" + reservaRegistrado.Codigo + ")";
        }

        public string ActualizarReserva(Reserva reservaAModificar)
        {
            Reserva reservaActualizada = null;
            reservaActualizada = dao.Modificar(reservaAModificar);
            return "La reserva registrada exitosamente (" + reservaActualizada.Codigo + ")";
        }

        public Reserva ObtenerReserva(string codigo)
        {
            Reserva reserva = dao.Obtener(int.Parse(codigo));

            if (reserva == null)
            {
                throw new WebFaultException<Error>(
                        new Error()
                        {
                            Codigo = "ERR005",
                            Mensaje = "La reserva no existe"
                        },
                            HttpStatusCode.InternalServerError);
            }

            return reserva;
        }

        public void EliminarReserva(string codigo)
        {
            dao.Eliminar(int.Parse(codigo));
        }

        public List<Reserva> ListarReservas()
        {
            return dao.ListarTodos();
        }
    }
}
