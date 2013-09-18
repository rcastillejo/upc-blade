using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionReservaAppMVC.Models;

namespace GestionReservaAppMVC.Controllers
{
    public class ReservarController : Controller
    {
        //
        // GET: /Reservar/
        private List<Sede> CrearSedes()
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

        private List<EspacioDeportivo> CrearEspacios()
        {
            List<Sede> sedes = CrearSedes();
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


        private Usuario ObtenerUsuario()
        {
            Usuario usuario = new Usuario() { codUsuario = "U201100396", nomCompleto = "Calle Espinoza, Maria Zaira" };

            return usuario;
        }

        private List<ReservaCancelada> ListarReserva()
        {
            List<Sede> sedes = CrearSedes();
            List<EspacioDeportivo> espacioDeportivos = CrearEspacios();
            Usuario usuario = ObtenerUsuario();


            List<ReservaCancelada> ReservaCanceladas = new List<ReservaCancelada>();
            ReservaCanceladas.Add(new ReservaCancelada() { CodReserva = "01", Sede = sedes.ElementAt(0), EspacioDeportivo = espacioDeportivos.ElementAt(0), Usuario = usuario, FechaReserva = new DateTime(2013, 9, 17, 7, 0, 0), DiaCorto = (new DateTime(2013, 9, 17, 7, 0, 0)).ToString("ddd"), HoraInicio = "07:00", HoraTermino = "08:00", Estado = new EstadoReserva() { codEstado = 0, desEstado = "Registrado" } });
            ReservaCanceladas.Add(new ReservaCancelada() { CodReserva = "02", Sede = sedes.ElementAt(2), EspacioDeportivo = espacioDeportivos.ElementAt(1), Usuario = usuario, FechaReserva = new DateTime(2013, 9, 12, 7, 0, 0), DiaCorto = (new DateTime(2013, 9, 12, 7, 0, 0)).ToString("ddd"), HoraInicio = "08:00", HoraTermino = "09:00", Estado = new EstadoReserva() { codEstado = 0, desEstado = "Confirmado" } });
            ReservaCanceladas.Add(new ReservaCancelada() { CodReserva = "03", Sede = sedes.ElementAt(0), EspacioDeportivo = espacioDeportivos.ElementAt(2), Usuario = usuario, FechaReserva = new DateTime(2013, 9, 14, 7, 0, 0), DiaCorto = (new DateTime(2013, 9, 14, 7, 0, 0)).ToString("ddd"), HoraInicio = "09:00", HoraTermino = "10:00", Estado = new EstadoReserva() { codEstado = 0, desEstado = "Registrado" } });
            ReservaCanceladas.Add(new ReservaCancelada() { CodReserva = "04", Sede = sedes.ElementAt(1), EspacioDeportivo = espacioDeportivos.ElementAt(3), Usuario = usuario, FechaReserva = new DateTime(2013, 9, 16, 7, 0, 0), DiaCorto = (new DateTime(2013, 9, 16, 7, 0, 0)).ToString("ddd"), HoraInicio = "07:00", HoraTermino = "08:00", Estado = new EstadoReserva() { codEstado = 0, desEstado = "Cancelado" } });
            ReservaCanceladas.Add(new ReservaCancelada() { CodReserva = "05", Sede = sedes.ElementAt(2), EspacioDeportivo = espacioDeportivos.ElementAt(4), Usuario = usuario, FechaReserva = new DateTime(2013, 9, 13, 7, 0, 0), DiaCorto = (new DateTime(2013, 9, 13, 7, 0, 0)).ToString("ddd"), HoraInicio = "08:00", HoraTermino = "09:00", Estado = new EstadoReserva() { codEstado = 0, desEstado = "Registrado" } });
            return ReservaCanceladas;
        }

        //
        // GET: /EspacioDeportivo/

        public ActionResult Index()
        {

            if (Session["espacios"] == null)
                Session["espacios"] = CrearEspacios();
            if (Session["sedes"] == null)
                Session["sedes"] = CrearSedes();
            CriterioReservar model = new CriterioReservar();
            return View(model);
        }



         // POST: /EspacioDeportivo/Create

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                CriterioReservar model = new CriterioReservar()
                {
                    EspacioDeportivo = obtenerEspacioDeportivo(int.Parse(collection["EspacioDeportivo.Codigo"])),
                    Sede = obtenerSede(int.Parse(collection["Sede.Codigo"])),
                    FechaInicio = collection["FechaInicio"],
                    FechaTermino = collection["FechaTermino"],
                    NumHoras = int.Parse(collection["NumHoras"])
                };

                

                //Session["Mensaje"] = "El espacio deportivo ha sido guardado exitosamente (" + espacio.Codigo + ")";
                return View(model);
            }
            catch
            {
                ViewData["Mensaje"] = "Error al crear el espacio deportivo";
                return View();
            }
        }

    }
}

