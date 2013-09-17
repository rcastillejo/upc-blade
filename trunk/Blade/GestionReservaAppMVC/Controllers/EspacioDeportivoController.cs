using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionReservaAppMVC.EspacioDeportivoWS;

namespace GestionReservaAppMVC.Controllers
{
    public class EspacioDeportivoController : Controller
    {
        EspacioDeportivoWS.EspacioDeportivoServiceClient espacioProxy = new EspacioDeportivoWS.EspacioDeportivoServiceClient();
        SedeWS.SedeServiceClient sedeProxy = new SedeWS.SedeServiceClient();

        //
        // GET: /EspacioDeportivo/

        public ActionResult Index()
        {
            if (Session["espacios"] == null)
                Session["espacios"] = espacioProxy.lista().ToList();
            if (Session["sedes"] == null)
                Session["sedes"] = sedeProxy.listar().ToList();
            List<EspacioDeportivo> model = (List<EspacioDeportivo>)Session["espacios"];
            return View(model);
        }

        //
        // GET: /EspacioDeportivo/Details/5

        public ActionResult Details(int id)
        {
            Session["Mensaje"] = "";
            EspacioDeportivo model = espacioProxy.obtener(id);

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
                string nombre = collection["Nombre"];
                int sedeCodigo = int.Parse(collection["Sede.Codigo"]);
                EspacioDeportivo espacio = espacioProxy.crear(nombre, sedeCodigo);
                Session["espacios"] = espacioProxy.lista().ToList();
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
                EspacioDeportivo model = espacioProxy.obtener(id);
                if (model == null) {
                    Session["Mensaje"] = "El espacio deportivo no se encuentra disponible";
                    return RedirectToAction("Index");
                }
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
                string nombre = collection["Nombre"];
                int sedeCodigo = int.Parse(collection["Sede.Codigo"]);                 
                EspacioDeportivo model = espacioProxy.actualizar(id, nombre, sedeCodigo);
                Session["espacios"] = espacioProxy.lista().ToList();
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
            EspacioDeportivo model = espacioProxy.obtener(id);
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
                espacioProxy.eliminar(id);
                Session["espacios"] = espacioProxy.lista().ToList();
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
