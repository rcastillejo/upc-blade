using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionReservaAppMVC.GestionReservaWS;
using System.ServiceModel;

namespace GestionReservaAppMVC.Controllers
{
    public class ReservaRegistradaController : Controller
    {

        GestionReservaWS.GestionReservaServiceClient proxy = new GestionReservaWS.GestionReservaServiceClient();


        private List<String> CrearDias()
        {
            List<String> dias = new List<String>();
            dias.Add("Lunes");
            dias.Add("Martes");
            dias.Add("Miercoles");
            dias.Add("Jueves");
            dias.Add("Viernes");
            return dias;
        }

        //
        // GET: /Reservar/
        private List<Sede> CrearSedes()
        {
            return proxy.listarSede().ToList();
        }

        private List<EspacioDeportivo> CrearEspacios()
        {
            return proxy.listarEspacio().ToList();
        }

        private Sede obtenerSede(int codigo)
        {
            List<Sede> sedes = (List<Sede>)Session["sedes"];
            Sede model = sedes.Single(delegate(Sede sede)
            {
                if (sede.Codigo == codigo) return true;
                else return false;
            });

            return model;
        }

        private EspacioDeportivo obtenerEspacioDeportivo(int codigo)
        {
            List<EspacioDeportivo> espacios = (List<EspacioDeportivo>)Session["espacios"];
            EspacioDeportivo model = espacios.Single(delegate(EspacioDeportivo espacio)
            {
                if (espacio.Codigo == codigo) return true;
                else return false;
            });

            return model;
        }


        private GestionReservaAppMVC.Models.Usuario ObtenerUsuario()
        {
            GestionReservaAppMVC.Models.Usuario usuario = new GestionReservaAppMVC.Models.Usuario() { codUsuario = "U201100396", nomCompleto = "Calle Espinoza, Maria Zaira" };

            return usuario;
        }

        private List<Reserva> ListarReserva(string estado)
        {
            List<Reserva> reservas = proxy.listarReserva().ToList();
            List<Reserva> reservasFiltradas = null;
            if (reservas.Count > 0) {

                reservasFiltradas = reservas.FindAll(delegate(Reserva reserva)
                {
                    if (reserva.Estado.Equals(estado))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                });
            }
            return reservasFiltradas;
        }


        public ActionResult Index()
        {

            if (Session["espacios"] == null)
                Session["espacios"] = CrearEspacios();
            if (Session["sedes"] == null)
                Session["sedes"] = CrearSedes();
            if (Session["dias"] == null)
                Session["dias"] = CrearDias();
            if (Session["Reservas"] == null)
                Session["Reservas"] = ListarReserva("RESERVADO");
            List<Reserva> model = (List<Reserva>)Session["Reservas"];
            return View(model);
        }



        //
        // GET: /EspacioDeportivo/Create

        public ActionResult Create()
        {
            return View();

        }

        //
        // POST: /EspacioDeportivo/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                int codigoEspacio = int.Parse(collection["CodigoEspacio"]);
                string dia = collection["Dia"];
                int cantHoras = int.Parse(collection["CantidadHoras"]);
                string fecInicio = (collection["FechaInicio"]);
                string fecFin = (collection["FechaFin"]);
                string mensaje = proxy.registrarReserva(codigoEspacio, dia, cantHoras, fecInicio, fecFin);
                Session["Reservas"] = ListarReserva("RESERVADO");
                Session["Mensaje"] = mensaje;
                return RedirectToAction("Index");
            }
            catch (FaultException ex)
            {
                ModelState.AddModelError(String.Empty, "Error: " + ex.Message);
                return View();
            }
        }

    }
}

