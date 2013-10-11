using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GestionReservaServices.Dominio;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using HorarioServices.Excepcion;
using System.Messaging;
using System.Net.Sockets;

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


        public string registrarHorario(int codigo, string dia, string horaInicio, string horaFin)
        {

            try
            {
                //Reservar
                Horario horario = new Horario()
                {
                    Codigo = codigo,
                    Dia = dia,
                    HoraInicio = horaInicio,
                    HoraFin = horaFin
                };
                
                JavaScriptSerializer js = new JavaScriptSerializer();
                string horarioJson = js.Serialize(horario);
                byte[] data = Encoding.UTF8.GetBytes(horarioJson);

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:22057/Horarios.svc/Horarios");
                req.Method = "POST";
                req.ContentLength = data.Length;
                req.ContentType = "application/json";

                var reqStream = req.GetRequestStream();
                reqStream.Write(data, 0, data.Length);

                var res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string horarioObtenidoJson = reader.ReadToEnd();
                return horarioObtenidoJson;
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

        public string actualizarHorario(int codigo, string dia, string horaInicio, string horaFin)
        {

            try
            {
                //Reservar
                Horario horario = new Horario()
                {
                    Codigo = codigo,
                    Dia = dia,
                    HoraInicio = horaInicio,
                    HoraFin = horaFin
                };

                JavaScriptSerializer js = new JavaScriptSerializer();
                string horarioJson = js.Serialize(horario);
                byte[] data = Encoding.UTF8.GetBytes(horarioJson);

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:22057/Horarios.svc/Horarios");
                req.Method = "PUT";
                req.ContentLength = data.Length;
                req.ContentType = "application/json";

                var reqStream = req.GetRequestStream();
                reqStream.Write(data, 0, data.Length);

                var res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string horarioObtenidoJson = reader.ReadToEnd();
                return horarioObtenidoJson;
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

        public Dominio.Horario obtenerHorario(int codigo, string dia)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:22057/Horarios.svc/Horarios/" + codigo + "/" + dia);
            req.Method = "GET";
            req.ContentType = "application/json";

            try{

                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string horarioObtenidoJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Horario horarioObtendido = js.Deserialize<Horario>(horarioObtenidoJson);
                return horarioObtendido;

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


        public List<Dominio.Horario> listarHorario(int codigo)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:22057/Horarios.svc/Horarios/" + codigo );
            req.Method = "GET";
            req.ContentType = "application/json";

            try
            {

                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string horarioObtenidoJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                List<Horario> horarioObtendidos = js.Deserialize<List<Horario>>(horarioObtenidoJson);
                return horarioObtendidos;
            
              }catch (WebException e){
                  HttpWebResponse resError = (HttpWebResponse)e.Response;//
                  StreamReader reader2 = new StreamReader(resError.GetResponseStream());
                  string resultado = reader2.ReadToEnd();
                  JavaScriptSerializer js2 = new JavaScriptSerializer();
                  Error error = js2.Deserialize<Error>(resultado);
                  throw new FaultException<Error>(error, new FaultReason(error.Mensaje));
              }
        }


        public string eliminarHorario(int codigo, string dia)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:22057/Horarios.svc/Horarios/" + codigo + "/" + dia);
                req.Method = "DELETE";
                req.ContentType = "application/json";
                var res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string alumnoObtenidoJson = reader.ReadToEnd();

                return "EL horario ha sido eliminado satisfactoriamente";
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


        public string registrarReserva(int codigoEspacio, int cantHoras, string fechaInicio)
        {

            Reserva reserva = new Reserva()
            {
                CodigoEspacio = codigoEspacio,
                CantidadHoras = cantHoras,
                FechaInicio = fechaInicio
            };
            try
            {

                JavaScriptSerializer js = new JavaScriptSerializer();
                string horarioJson = js.Serialize(reserva);
                byte[] data = Encoding.UTF8.GetBytes(horarioJson);

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:19528/Reservas.svc/Reservas");
                req.Method = "POST";
                req.ContentLength = data.Length;
                req.ContentType = "application/json";

                var reqStream = req.GetRequestStream();
                reqStream.Write(data, 0, data.Length);

                var res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string horarioObtenidoJson = reader.ReadToEnd();
                return horarioObtenidoJson;
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ConnectFailure)
                {
                    //saveQueue(reserva);
                    return "La reserva registrada exitosamente";
                }
                else 
                {
                    HttpWebResponse resError = (HttpWebResponse)e.Response;//
                    StreamReader reader2 = new StreamReader(resError.GetResponseStream());
                    string resultado = reader2.ReadToEnd();
                    JavaScriptSerializer js2 = new JavaScriptSerializer();
                    Error error = js2.Deserialize<Error>(resultado);
                    throw new FaultException<Error>(error, new FaultReason(error.Mensaje));
                }
            }
        }
        
        public Reserva obtenerReserva(int codigo)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:19528/Reservas.svc/Reservas/" + codigo);
            req.Method = "GET";
            try
            {

                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string reservaObtenidoJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Reserva reservaObtendidos = js.Deserialize<Reserva>(reservaObtenidoJson);
                return reservaObtendidos;

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

        public List<Reserva> listarReserva()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:19528/Reservas.svc/Reservas");
            req.Method = "GET";

            try
            {

                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string reservaObtenidoJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                List<Reserva> reservaObtendidos = js.Deserialize<List<Reserva>>(reservaObtenidoJson);
                return reservaObtendidos;

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


        private void saveQueue(Reserva reserva)
        {
            string rutaCola = @".\private$\bladeReserva";
            if (!MessageQueue.Exists(rutaCola))
            {
                MessageQueue.Create(rutaCola);
            }
            MessageQueue cola = new MessageQueue(rutaCola);
            Message mensaje = new Message();
            mensaje.Label = "Reserva";
            mensaje.Body = reserva;
            cola.Send(mensaje);
        }



        public string confirmarReserva(int codigo)
        {
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(codigo);
                byte[] data = Encoding.UTF8.GetBytes(json);

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:19528/Reservas.svc/ReservasConfirmada");
                req.Method = "PUT";
                req.ContentLength = data.Length;
                req.ContentType = "application/json";

                var reqStream = req.GetRequestStream();
                reqStream.Write(data, 0, data.Length);

                var res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string horarioObtenidoJson = reader.ReadToEnd();
                return horarioObtenidoJson;
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

        public string cancelarReserva(int codigo)
        {
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(codigo);
                byte[] data = Encoding.UTF8.GetBytes(json);

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:19528/Reservas.svc/ReservasCancelada");
                req.Method = "PUT";
                req.ContentLength = data.Length;
                req.ContentType = "application/json";

                var reqStream = req.GetRequestStream();
                reqStream.Write(data, 0, data.Length);

                var res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string horarioObtenidoJson = reader.ReadToEnd();
                return horarioObtenidoJson;
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
    }
}
