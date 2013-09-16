using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionReservaAppMVC.Models;
using GestionReservaAppMVC.Controllers;


namespace GestionReservaCanceladaAppMVC.Controllers
{
    public class ReservaCanceladaController : Controller
    {
        //
        // GET: /Confirmar/

        private List<Sede> ListarSedes()
        {
            Sede lince = new Sede() { Codigo = 1, Nombre = "Lince" };
            Sede sanIsidro = new Sede() { Codigo = 2, Nombre = "San Isidro" };
            Sede sanBorja = new Sede() { Codigo = 3, Nombre = "San Borja" };

            List<Sede> sedes = new List<Sede>();
            sedes.Add(lince);
            sedes.Add(sanIsidro);
            sedes.Add(sanBorja);

            return sedes;
        }

        private Usuario ObtenerUsuario()
        {
            Usuario usuario = new Usuario() { codUsuario = "U201100396", nomCompleto = "Calle Espinoza, Maria Zaira" };

            return usuario;
        }

        private List<Actividad> ListarActividad()
        {
            Actividad actividad1 = new Actividad() { codActividad = 1, nomActividad = "Uso del gimnasio" };
            Actividad actividad2 = new Actividad() { codActividad = 2, nomActividad = "Uso del piscina" };


            List<Actividad> actividades = new List<Actividad>();
            actividades.Add(actividad1);
            actividades.Add(actividad2);


            return actividades;
        }


        private List<EspacioDeportivo> ListarEspacios()
        {
            List<Sede> sedes = ListarSedes();
            //Sede lince = new Sede() { Codigo = 1, Nombre = "Lince" };
            //Sede sanIsidro = new Sede() { Codigo = 2, Nombre = "San Isidro" };
            //Sede sanBorja = new Sede() { Codigo = 3, Nombre = "San Borja" };

            List<EspacioDeportivo> espacios = new List<EspacioDeportivo>();
            espacios.Add(new EspacioDeportivo() { Codigo = 101, Nombre = "Piscina", Sede = sedes.ElementAt(0) });
            espacios.Add(new EspacioDeportivo() { Codigo = 102, Nombre = "Cancha Futbol", Sede = sedes.ElementAt(2) });
            espacios.Add(new EspacioDeportivo() { Codigo = 103, Nombre = "Cancha Tenis", Sede = sedes.ElementAt(0) });
            espacios.Add(new EspacioDeportivo() { Codigo = 104, Nombre = "Piscina", Sede = sedes.ElementAt(1) });
            espacios.Add(new EspacioDeportivo() { Codigo = 105, Nombre = "Cancha Basket", Sede = sedes.ElementAt(2) });

            return espacios;
        }

        private List<ReservaCancelada> ListarReservaCanceladas()
        {
            List<Sede> sedes = ListarSedes();
            List<EspacioDeportivo> espacioDeportivos = ListarEspacios();
            List<Actividad> actividades = ListarActividad();
            Usuario usuario = ObtenerUsuario();


            List<ReservaCancelada> ReservaCanceladas = new List<ReservaCancelada>();
            ReservaCanceladas.Add(new ReservaCancelada() { CodReserva = "01", Sede = sedes.ElementAt(0), EspacioDeportivo = espacioDeportivos.ElementAt(0), Actividad = actividades.ElementAt(0), Usuario = usuario, FechaReserva = new DateTime(2013, 9, 17, 7, 0, 0), DiaCorto = (new DateTime(2013, 9, 17, 7, 0, 0)).ToString("ddd"), HoraInicio = "07:00", HoraTermino = "08:00", Estado = new EstadoReserva() { codEstado = 0, desEstado = "Registrado" } });
            ReservaCanceladas.Add(new ReservaCancelada() { CodReserva = "02", Sede = sedes.ElementAt(2), EspacioDeportivo = espacioDeportivos.ElementAt(1), Actividad = actividades.ElementAt(1), Usuario = usuario, FechaReserva = new DateTime(2013, 9, 12, 7, 0, 0), DiaCorto = (new DateTime(2013, 9, 12, 7, 0, 0)).ToString("ddd"), HoraInicio = "08:00", HoraTermino = "09:00", Estado = new EstadoReserva() { codEstado = 0, desEstado = "Confirmado" } });
            ReservaCanceladas.Add(new ReservaCancelada() { CodReserva = "03", Sede = sedes.ElementAt(0), EspacioDeportivo = espacioDeportivos.ElementAt(2), Actividad = actividades.ElementAt(0), Usuario = usuario, FechaReserva = new DateTime(2013, 9, 14, 7, 0, 0), DiaCorto = (new DateTime(2013, 9, 14, 7, 0, 0)).ToString("ddd"), HoraInicio = "09:00", HoraTermino = "10:00", Estado = new EstadoReserva() { codEstado = 0, desEstado = "Registrado" } });
            ReservaCanceladas.Add(new ReservaCancelada() { CodReserva = "04", Sede = sedes.ElementAt(1), EspacioDeportivo = espacioDeportivos.ElementAt(3), Actividad = actividades.ElementAt(1), Usuario = usuario, FechaReserva = new DateTime(2013, 9, 16, 7, 0, 0), DiaCorto = (new DateTime(2013, 9, 16, 7, 0, 0)).ToString("ddd"), HoraInicio = "07:00", HoraTermino = "08:00", Estado = new EstadoReserva() { codEstado = 0, desEstado = "Cancelado" } });
            ReservaCanceladas.Add(new ReservaCancelada() { CodReserva = "05", Sede = sedes.ElementAt(2), EspacioDeportivo = espacioDeportivos.ElementAt(4), Actividad = actividades.ElementAt(0), Usuario = usuario, FechaReserva = new DateTime(2013, 9, 13, 7, 0, 0), DiaCorto = (new DateTime(2013, 9, 13, 7, 0, 0)).ToString("ddd"), HoraInicio = "08:00", HoraTermino = "09:00", Estado = new EstadoReserva() { codEstado = 0, desEstado = "Registrado" } });
            return ReservaCanceladas;
        }

        public ActionResult Index()
        {

            if (Session["sedes"] == null)
                Session["sedes"] = ListarSedes();
            if (Session["actividades"] == null)
                Session["actividades"] = ListarSedes();
            if (Session["espacios"] == null)
                Session["espacios"] = ListarEspacios();
            if (Session["usuario"] == null)
                Session["usuario"] = ObtenerUsuario();
            if (Session["Reservas"] == null)
                Session["Reservas"] = ListarReservaCanceladas();
            List<ReservaCancelada> model = (List<ReservaCancelada>)Session["Reservas"];
            return View(model);


        }

        private ReservaCancelada obtenerReserva(string Codreserva)
        {
            List<ReservaCancelada> reservas = (List<ReservaCancelada>)Session["Reservas"];
            ReservaCancelada model = reservas.Single(delegate(ReservaCancelada reserva)
            {
                if (reserva.CodReserva == Codreserva) return true;
                else return false;
            });

            return model;
        }


        public ActionResult Cancelar(string id)
        {
            Session["Mensaje"] = "";
            ReservaCancelada model = obtenerReserva(id);
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
                List<ReservaCancelada> espacios = (List<ReservaCancelada>)Session["reservas"];
                espacios.Remove(obtenerReserva(id));
                Session["Mensaje"] = "La Resera ha sido cancelada exitosamente";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewData["Mensaje"] = "La reserva no se encuentra cancelada";
                return View();
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
            ReservaCancelada model = obtenerReserva(id);
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
