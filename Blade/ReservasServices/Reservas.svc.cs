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
using System.Messaging;

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

            if (!(horaInicio <= fecha.Hour && fecha.Hour <= horaFin))
            {
                throw new WebFaultException<Error>(
                        new Error()
                        {
                            Codigo = "ERR006",
                            Mensaje = "El espacio no se encuentra disponible en este horario"
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
            //loadFromQueue();
            return dao.ListarTodos();
        }


        private void loadFromQueue()
        {


            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:59131/Service1.svc/Service1");
            req.Method = "GET";

            try
            {

                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string reservaObtenidoJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                List<Reserva> reservaObtendidos = js.Deserialize<List<Reserva>>(reservaObtenidoJson);

                foreach (Reserva item in reservaObtendidos)
                {
                    try
                    {
                        RegistrarReserva(item);
                    }
                    catch { 
                    
                    }                    
                }

            }
            catch (WebException e)
            {
                HttpWebResponse resError = (HttpWebResponse)e.Response;//
                StreamReader reader2 = new StreamReader(resError.GetResponseStream());
                string resultado = reader2.ReadToEnd();
                JavaScriptSerializer js2 = new JavaScriptSerializer();
                Error error = js2.Deserialize<Error>(resultado);
                throw new FaultException<Error>(error, new FaultReason(error.Mensaje));
            }
        }


        public string ConfirmarReserva(string codigo)
        {
            Reserva reserva = ObtenerReserva(codigo);


            if (reserva.Estado == Estado.CONFIRMADO)
            {
                throw new WebFaultException<Error>(
                        new Error()
                        {
                            Codigo = "ERR011",
                            Mensaje = "La reserva ya ha sido confirmada"
                        },
                            HttpStatusCode.InternalServerError);

            }


            if (reserva.Estado == Estado.CANCELADO)
            {
                throw new WebFaultException<Error>(
                        new Error()
                        {
                            Codigo = "ERR010",
                            Mensaje = "La reserva ya ha sido cancelada"
                        },
                            HttpStatusCode.InternalServerError);

            }
            reserva.Estado = Estado.CONFIRMADO;

            Reserva reservaActualizada;
            reservaActualizada = dao.Modificar(reserva);
            return "La reserva confirmada exitosamente (" + reservaActualizada.Codigo + ")";
        }

        public string CancelarReserva(string codigo)
        {
            Reserva reserva = ObtenerReserva(codigo);

            if (reserva.Estado == Estado.CANCELADO) {
                throw new WebFaultException<Error>(
                        new Error()
                        {
                            Codigo = "ERR010",
                            Mensaje = "La reserva ya ha sido cancelada"
                        },
                            HttpStatusCode.InternalServerError);
            
            }

            if (reserva.Estado == Estado.CONFIRMADO)
            {
                throw new WebFaultException<Error>(
                        new Error()
                        {
                            Codigo = "ERR011",
                            Mensaje = "La reserva ya ha sido confirmada"
                        },
                            HttpStatusCode.InternalServerError);

            }

            reserva.Estado = Estado.CANCELADO;

            Reserva reservaActualizada;
            reservaActualizada = dao.Modificar(reserva);
            return "La reserva cancelada exitosamente (" + reservaActualizada.Codigo + ")";
        }
    }
}
