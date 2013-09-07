using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionReservaAppMVC.Models;

namespace GestionReservaAppMVC.Controllers
{
    public class EspacioDeportivoController : Controller
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
            EspacioDeportivo model = espacios.Single(delegate(EspacioDeportivo espacio){
                if (espacio.Codigo == codigo) return true;
                else return false;
            });

            return model;
        }

        //
        // GET: /EspacioDeportivo/

        public ActionResult Index()
        {
            
            if (Session["espacios"] == null)
                Session["espacios"] = CrearEspacios();
            if (Session["sedes"] == null)
                Session["sedes"] = CrearSedes();
            List<EspacioDeportivo> model = (List<EspacioDeportivo>)Session["espacios"];
            return View(model);
        }

        //
        // GET: /EspacioDeportivo/Details/5

        public ActionResult Details(int id)
        {
            Session["Mensaje"] = "";
            EspacioDeportivo model = obtenerEspacioDeportivo(id);

            return View(model);
        }

        //
        // GET: /EspacioDeportivo/Create

        public ActionResult Create()
        {
            Session["Mensaje"] = "";
            if (Session["sedes"] == null)
            {
                Session["Mensaje"] = "No existe sedes disponibles";
                return RedirectToAction("Index");
            }
            else {
                return View();
            }
            
        } 

        //
        // POST: /EspacioDeportivo/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                List<EspacioDeportivo> espacios = (List<EspacioDeportivo>)Session["espacios"];
                EspacioDeportivo espacio = new EspacioDeportivo()
                {
                    Codigo = int.Parse(collection["Codigo"]),
                    Nombre = collection["Nombre"],
                    Sede = obtenerSede(int.Parse(collection["Sede.Codigo"]))
                };
                espacios.Add(espacio);
                Session["Mensaje"] = "El espacio deportivo ha sido guardado exitosamente ("+espacio.Codigo+")";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewData["Mensaje"] = "Error al crear el espacio deportivo";
                return View();
            }
        }
        
        //
        // GET: /EspacioDeportivo/Edit/5
 
        public ActionResult Edit(int id)
        {
            Session["Mensaje"] = "";
            if (Session["sedes"] == null)
            {
                Session["Mensaje"] = "No existe sedes disponibles";
                return RedirectToAction("Index");
            }
            else
            {
                EspacioDeportivo model = obtenerEspacioDeportivo(id);
                return View(model);
            }
        }

        //
        // POST: /EspacioDeportivo/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {                
                // TODO: Add update logic here
                EspacioDeportivo model = obtenerEspacioDeportivo(id);
                model.Codigo = int.Parse(collection["Codigo"]);
                model.Nombre = collection["Nombre"];
                model.Sede = obtenerSede(int.Parse(collection["Sede.Codigo"]));
                Session["Mensaje"] = "El espacio deportivo ha sido guardado exitosamente (" + model.Codigo + ")";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewData["Mensaje"] = "El espacio deportivo no se encuentra disponible";
                return View();
            }
        }

        //
        // GET: /EspacioDeportivo/Delete/5
 
        public ActionResult Delete(int id)
        {
            Session["Mensaje"] = "";
            EspacioDeportivo model = obtenerEspacioDeportivo(id);
            return View(model);
        }

        //
        // POST: /EspacioDeportivo/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                List<EspacioDeportivo> espacios = (List<EspacioDeportivo>)Session["espacios"];
                espacios.Remove(obtenerEspacioDeportivo(id));
                Session["Mensaje"] = "El espacio deportivo ha sido eliminado exitosamente";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewData["Mensaje"] = "El espacio deportivo no se encuentra disponible";
                return View();
            }
        }
    }
}
