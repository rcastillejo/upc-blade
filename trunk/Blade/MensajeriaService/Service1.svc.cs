using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Messaging;
using MensajeriaService.Dominio;

namespace MensajeriaService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    public class Service1 : IService1
    {
        public void Grabar(Reserva mensaje)
        {
            saveQueue(mensaje);
        }

        private void saveQueue(Reserva mensaje)
        {
            string rutaCola = @".\private$\bladeReserva";
            if (!MessageQueue.Exists(rutaCola))
            {
                MessageQueue.Create(rutaCola);
            }
            MessageQueue cola = new MessageQueue(rutaCola);
            Message msg = new Message();
            msg.Label = "Mensaje";
            msg.Body = mensaje;
            cola.Send(msg);
        }

        public List<Reserva> Listar()
        {
            return loadFromQueue();
        }


        private List<Reserva> loadFromQueue()
        {

            List<Reserva> reservas = new List<Reserva>();
            string rutaCola = @".\private$\bladeReserva";
            if (!MessageQueue.Exists(rutaCola))
            {
                MessageQueue.Create(rutaCola);
            }

            MessageQueue cola = new MessageQueue(rutaCola);
            int cantidadMensajes = cola.GetAllMessages().Count();

            while (cantidadMensajes > 0)
            {

                cola.Formatter = new XmlMessageFormatter(new Type[] { typeof(Reserva) });

                Message mensaje = cola.Receive();

                Reserva reserva = (Reserva)mensaje.Body;
                try
                {
                    reservas.Add(reserva);
                }
                catch
                {

                }

                cantidadMensajes--;
            }

            return reservas;

        }

    }
}
