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
using System.Globalization;
using System.IO;
using System.Web.Script.Serialization;

namespace ReservasServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Reservas" en el código, en svc y en el archivo de configuración a la vez.
    public class Reservas : IReservas
    {


        private static string DATEFORMAT = "yyyy-MM-dd HH:mm:ss";
        private ReservaDAO dao = new ReservaDAO();

        
        private string addHour(String s, int hour){
            DateTime date = DateTime.ParseExact(s, DATEFORMAT, CultureInfo.InvariantCulture);
            return date.AddHours(hour).ToString(DATEFORMAT);
        }

        private Horario obtenerHorario(String url){
        
            
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "GET";


            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string reservaObtenidoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Horario obtenido = js.Deserialize<Horario>(reservaObtenidoJson);
            return obtenido;

        }

        private void validarHorario(Reserva reservaACrear)
        {

            Horario horario = obtenerHorario("http://localhost:22057/Horarios.svc/Horarios?codigo=" + reservaACrear.CodigoEspacio + "&fecha=" + reservaACrear.FechaInicio);

            if (horario == null)
            {
                throw new WebFaultException<Error>(
                        new Error()
                        {
                            Codigo = "ERR006",
                            Mensaje = "El espacio no se encuentra disponible en este horario"
                        },
                            HttpStatusCode.InternalServerError);
            }

            DateTime fecha = DateTime.ParseExact(reservaACrear.FechaInicio, DATEFORMAT, CultureInfo.InvariantCulture);
            int horaInicio = int.Parse(horario.HoraInicio.Substring(0,2));
            int minutoInicio = int.Parse(horario.HoraInicio.Substring(3));

            int horaFin = int.Parse(horario.HoraFin.Substring(0,2));
            int minutoFin = int.Parse(horario.HoraFin.Substring(3));

            if (fecha.Hour < horaInicio || horaFin > fecha.Hour)
            {
                throw new WebFaultException<Error>(
                        new Error()
                        {
                            Codigo = "ERR004",
                            Mensaje = "El espacio deportivo ya ha sido reservado"
                        },
                            HttpStatusCode.InternalServerError);
            }
            else if (fecha.Minute < minutoInicio || minutoFin > fecha.Minute) {

                throw new WebFaultException<Error>(
                        new Error()
                        {
                            Codigo = "ERR004",
                            Mensaje = "El espacio deportivo ya ha sido reservado"
                        },
                            HttpStatusCode.InternalServerError);
            }

        }

        public string RegistrarReserva(Reserva reservaACrear)
        {

            validarHorario(reservaACrear);

            reservaACrear.FechaFin = addHour(reservaACrear.FechaInicio, reservaACrear.CantidadHoras);

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
            reservaACrear.Estado = Estado.RESERVADO;

            reservaRegistrado = dao.Crear(reservaACrear);

            return "La reserva registrada exitosamente (" + reservaRegistrado.Codigo + ")";
        }

        public string ActualizarReserva(Reserva reservaAModificar)
        {
            reservaAModificar.FechaFin = addHour(reservaAModificar.FechaInicio, reservaAModificar.CantidadHoras);
            
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
