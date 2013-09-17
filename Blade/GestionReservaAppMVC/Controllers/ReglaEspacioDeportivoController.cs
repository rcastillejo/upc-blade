using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionReservaAppMVC.Models;

namespace GestionReservaAppMVC.Controllers
{
    public class ReglaEspacioDeportivoController : Controller
    {
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

            List<EspacioDeportivo> espacios = new List<EspacioDeportivo>();
            espacios.Add(new EspacioDeportivo() { Codigo = 101, Nombre = "Piscina", Sede = sedes.ElementAt(0) });
            espacios.Add(new EspacioDeportivo() { Codigo = 102, Nombre = "Cancha Futbol", Sede = sedes.ElementAt(2) });
            espacios.Add(new EspacioDeportivo() { Codigo = 103, Nombre = "Cancha Tenis", Sede = sedes.ElementAt(0) });
            espacios.Add(new EspacioDeportivo() { Codigo = 104, Nombre = "Piscina", Sede = sedes.ElementAt(1) });
            espacios.Add(new EspacioDeportivo() { Codigo = 105, Nombre = "Cancha Basket", Sede = sedes.ElementAt(2) });

            return espacios;
        }


        private List<ReglaEspacioDeportivo> CrearReglaEspacios()
        {
            List<Sede> sedes = CrearSedes();
            List<EspacioDeportivo> espacios = CrearEspacios();

            List<ReglaEspacioDeportivo> reglaEspacios = new List<ReglaEspacioDeportivo>();
            reglaEspacios.Add(new ReglaEspacioDeportivo() { 
                EspacioDeportivo = espacios.ElementAt(0), 
                MinAnticipacionReservarMinuto = 120,
                MaxAnticipacionReservaDia = 30,
                MinAnticipacionCancelarHora = 15,
                MaxHoraReservaDia = 2,
                MaxHoraReservaSemana = 8,
                MaxNumUsuario = 5
            });


            return reglaEspacios;
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


        /*private EspacioDeportivo obtenerEspacioDeportivo(int codigo)
        {
            List<EspacioDeportivo> espacios = (List<EspacioDeportivo>)Session["espacios"];
            EspacioDeportivo model = espacios.Single(delegate(EspacioDeportivo espacio)
            {
                if (espacio.Codigo == codigo) return true;
                else return false;
            });

            return model;
        }*/

        private ReglaEspacioDeportivo obtenerReglaEspacioDeportivo(int codigo)
        {
            List<ReglaEspacioDeportivo> reglaEspacios = (List<ReglaEspacioDeportivo>)Session["reglaEspacios"];
            ReglaEspacioDeportivo model = reglaEspacios.Single(delegate(ReglaEspacioDeportivo reglaEspacio)
            {
                if (reglaEspacio.EspacioDeportivo.Codigo == codigo) return true;
                else return false;
            });

            return model;
        }

        //
        // GET: /EspacioDeportivo/

        public ActionResult Index()
        {

            if (Session["reglaEspacios"] == null)
                Session["reglaEspacios"] = CrearReglaEspacios();
            List<ReglaEspacioDeportivo> model = (List<ReglaEspacioDeportivo>)Session["reglaEspacios"];
            return View(model);
        }

        //
        // GET: /EspacioDeportivo/Details/5

        public ActionResult Details(int id)
        {
            Session["Mensaje"] = "";
            ReglaEspacioDeportivo model = obtenerReglaEspacioDeportivo(id);

            return View(model);
        }


        //
        // GET: /EspacioDeportivo/Edit/5

        public ActionResult Edit(int id)
        {
            Session["Mensaje"] = "";
            ReglaEspacioDeportivo model = obtenerReglaEspacioDeportivo(id);
            return View(model);
        }

        //
        // POST: /EspacioDeportivo/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                ReglaEspacioDeportivo model = obtenerReglaEspacioDeportivo(id);
                model.MaxAnticipacionReservaDia = int.Parse(collection["MaxAnticipacionReservaDia"]);
                model.MaxHoraReservaDia = int.Parse(collection["MaxHoraReservaDia"]);
                model.MaxHoraReservaSemana = int.Parse(collection["MaxHoraReservaSemana"]);
                model.MaxNumUsuario = int.Parse(collection["MaxNumUsuario"]);
                model.MinAnticipacionCancelarHora = int.Parse(collection["MinAnticipacionCancelarHora"]);
                model.MinAnticipacionReservarMinuto = int.Parse(collection["MinAnticipacionReservarMinuto"]);

                Session["Mensaje"] = "La regla del espacio deportivo ha sido guardado exitosamente (" + model.EspacioDeportivo.Codigo + ")";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewData["Mensaje"] = "El regla del espacio deportivo no se encuentra disponible";
                return View();
            }
        }

    }
}
