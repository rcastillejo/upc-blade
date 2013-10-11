using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionReservaAppMVC.GestionReservaWS;
using GestionReservaAppMVC.Controllers;
using System.Data.SqlClient;
using System.ServiceModel;


namespace GestionReservaAppMVC.Controllers
{
    public class ReservaCanceladaController : Controller
    {

        GestionReservaAppMVC.GestionReservaWS.GestionReservaServiceClient proxy = new GestionReservaAppMVC.GestionReservaWS.GestionReservaServiceClient();

        //
        // GET: /Confirmar/

        private List<Sede> ListarSedes()
        {
            return proxy.listarSede().ToList();
        }

        //private Usuario ObtenerUsuario()
        //{
        //    Usuario usuario = new Usuario() { codUsuario = "U201100396", nomCompleto = "Calle Espinoza, Maria Zaira" };

        //    return usuario;
        //}

        //private List<Actividad> ListarActividad()
        //{
        //    Actividad actividad1 = new Actividad() { codActividad = 1, nomActividad = "Uso del gimnasio" };
        //    Actividad actividad2 = new Actividad() { codActividad = 2, nomActividad = "Uso del piscina" };


        //    List<Actividad> actividades = new List<Actividad>();
        //    actividades.Add(actividad1);
        //    actividades.Add(actividad2);


        //    return actividades;
        //}


        private List<EspacioDeportivo> ListarEspacios()
        {
            return proxy.listarEspacio().ToList();
        }

        private List<Reserva> ListarReservas()
        {
            List<Reserva> reservas = proxy.listarReserva().ToList();
            List<Reserva> Reservas = null;
            if (reservas.Count > 0)
            {

                Reservas = reservas.FindAll(delegate(Reserva reserva)
                {
                    if (reserva.Estado.Equals("RESERVADO"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                });
            }
            return Reservas;
        }

        public ActionResult Index()
        {

            if (Session["sedes"] == null)
                Session["sedes"] = ListarSedes();
            if (Session["actividades"] == null)
                Session["actividades"] = ListarSedes();
            if (Session["espacios"] == null)
                Session["espacios"] = ListarEspacios();
            //if (Session["usuario"] == null)
            //    Session["usuario"] = ObtenerUsuario();
            if (Session["Reservas"] == null)
                Session["Reservas"] = ListarReservas();
            List<Reserva> model = (List<Reserva>)Session["Reservas"];
            return View(model);


        }

        private Reserva obtenerReserva(string Codreserva)
        {
            return proxy.obtenerReserva(int.Parse(Codreserva));
        }


        public ActionResult Cancelar(string id)
        {
            Session["Mensaje"] = "";
            Reserva model = obtenerReserva(id);
            return View(model);
        }
        //
        // POST: /EspacioDeportivo/Delete/5

        [HttpPost]
        public ActionResult Cancelar(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                string mensaje = proxy.cancelarReserva(int.Parse(id));

                //Session["Mensaje"] = "La Resera ha sido cancelada exitosamente";
                Session["Mensaje"] = mensaje;
                Session["Reservas"] = ListarReservas();
                return RedirectToAction("Index");
            }

            catch (FaultException ex)
            {
                ViewData["Mensaje"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        //
        // GET: /Confirmar/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Confirmar/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Confirmar/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Confirmar/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Confirmar/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Confirmar/Delete/5
 
        public ActionResult Delete(string id)
        {
            Session["Mensaje"] = "";
            Reserva model = obtenerReserva(id);
            return View(model);
        }

        //
        // POST: /Confirmar/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
