using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionReservaAppMVC.GestionReservaWS;
using System.ServiceModel;

namespace GestionReservaAppMVC.Controllers
{
    public class EspacioDeportivoController : Controller
    {
        GestionReservaWS.GestionReservaServiceClient proxy = new GestionReservaWS.GestionReservaServiceClient();

        //
        // GET: /EspacioDeportivo/

        public ActionResult Index()
        {
            try
            {
                if (Session["espacios"] == null)
                    Session["espacios"] = proxy.listarEspacio().ToList();
                if (Session["sedes"] == null)
                    Session["sedes"] = proxy.listarSede().ToList();
                List<EspacioDeportivo> model = (List<EspacioDeportivo>)Session["espacios"];
                return View(model);
                }
            catch (FaultException ex)
            {
                ViewData["Mensaje"] = ex.Message;
                return View();
            }
        }

        //
        // GET: /EspacioDeportivo/Details/5

        public ActionResult Details(int id)
        {
            Session["Mensaje"] = "";

            try
            {
                EspacioDeportivo model = proxy.obtenerEspacio(id);

                return View(model);
            }
            catch (FaultException ex)
            {
                ViewData["Mensaje"] = ex.Message;
                return View();
            }
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
                string mensaje= proxy.crearEspacio(nombre, sedeCodigo);
                Session["espacios"] = proxy.listarEspacio().ToList();
                Session["Mensaje"] = mensaje;
                return RedirectToAction("Index");
            }
            catch (FaultException ex)
            {
                ViewData["Mensaje"] = ex.Message;
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
                try
                {
                    EspacioDeportivo model = proxy.obtenerEspacio(id);
                    if (model == null)
                    {
                        Session["Mensaje"] = "El espacio deportivo no se encuentra disponible";
                        return RedirectToAction("Index");
                    }
                    return View(model);

                }
                catch (FaultException ex)
                {
                    Session["Mensaje"] = ex.Message;
                    return View();
                }
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
                string mensaje= proxy.actualizarEspacio(id, nombre, sedeCodigo);
                Session["espacios"] = proxy.listarEspacio().ToList();
                Session["Mensaje"] = mensaje;
                return RedirectToAction("Index");
            }
            catch (FaultException ex)
            {
                ViewData["Mensaje"] = ex.Message;
                return View();
            }
        }

        //
        // GET: /EspacioDeportivo/Delete/5
 
        public ActionResult Delete(int id)
        {
            Session["Mensaje"] = "";
            try
            {
                EspacioDeportivo model = proxy.obtenerEspacio(id);
                return View(model);            
            }
            catch (FaultException ex)
            {
                ViewData["Mensaje"] = ex.Message;
                return View();
            }
        }

        //
        // POST: /EspacioDeportivo/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                string mensaje = proxy.eliminarEspacio(id);
                Session["espacios"] = proxy.listarEspacio().ToList();
                Session["Mensaje"] = mensaje;
                return RedirectToAction("Index");
            }
            catch (FaultException ex)
            {
                ViewData["Mensaje"] = ex.Message;
                return View();
            }
        }
    }
}
