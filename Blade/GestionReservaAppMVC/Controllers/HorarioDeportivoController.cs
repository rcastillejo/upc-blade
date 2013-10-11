using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionReservaAppMVC.GestionReservaWS;
using System.Net;

namespace GestionReservaAppMVC.Controllers
{
    public class HorarioDeportivoController : Controller
    {

        GestionReservaWS.GestionReservaServiceClient proxy = new GestionReservaWS.GestionReservaServiceClient();

        private List<String> crearDias()
        {
            List<String> dias = new List<String>();
            dias.Add("Lunes" );
            dias.Add("Martes" );
            dias.Add("Miércoles");
            dias.Add("Jueves" );
            dias.Add("Viernes" );
            return dias;
        }


        private List<String> crearHoras()
        {
            List<String> horas = new List<String>();

            for (int i = 8; i < 23; i++)
            {
                string hora ="0";
                if (i < 10)
                {
                    hora += i;
                }
                else {
                    hora = i+"";
                }
                horas.Add(hora + ":00");
                horas.Add(hora + ":15");
                horas.Add(hora + ":30");
            }
            return horas;
        }


        // GET: /HorarioDeportivo/
        // ***** Muestra pagina con listado de Horarios *****
        public ActionResult Index()
          {
              Session["CodigoCreate"] = "";
            if (Session["espacios"] == null)
                Session["espacios"] = proxy.listarEspacio().ToList();
            if (Session["dias"] == null)
                Session["dias"] = crearDias();
            if (Session["horasInicio"] == null)
                Session["horasInicio"] = crearHoras();
            if (Session["horasFin"] == null)
                Session["horasFin"] = crearHoras();
            List<EspacioDeportivo> model = (List<EspacioDeportivo>)Session["espacios"];
            return View(model);
        }


        // GET: /HorarioDeportivo/Details/5
        // ***** Muestra el listaado de horario *****
        public ActionResult Details(int Codigo)//(int CodigoEspacio, int codsede)
        {
            Session["Mensaje"] = "";
            Session["detHorarios"] = proxy.listarHorario(Codigo).ToList();
            List<Horario> modell = (List<Horario>)Session["detHorarios"];
            Session["CodigoCreate"] = Codigo;
            return View(modell);
        }

        public ActionResult DetailsItem(int codigo, string dia)
        {
            try
            {
                Horario model = proxy.obtenerHorario(codigo, dia);
                return View(model);
            
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, "Error: " + e.Message);
                return View("Details", Session["detHorarios"]);
            }
        }


        // GET: /HorarioDeportivo/Edit/5
        public ActionResult EditItem(int codigo, string dia)//(int codespacio,int codsede)
        {
            Session["Mensaje"] = "";
            try{
                Horario model = proxy.obtenerHorario(codigo, dia);
                return View(model);            
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, "Error: " + e.Message);
                return View("Details", Session["detHorarios"]);
            }
        }

        // POST: /HorarioDeportivo/Edit/5
        [HttpPost]
        public ActionResult EditItem(int codigo, string dia, FormCollection collection)
        {
            Session["Mensaje"] = "";
            try
            {
                string horaInicio= (collection["HoraInicio"]);
                string horaFin = (collection["HoraFin"]);
                string mensaje = proxy.actualizarHorario(codigo, dia, horaInicio, horaFin);
                Session["detHorarios"] = proxy.listarHorario(codigo).ToList();
                Session["Mensaje"] = mensaje;
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, "Error: " + e.Message);
            }
            return View("Details", Session["detHorarios"]);
        }

        
        // GET: /HorarioDeportivo/Create
        //******* Muestra pagina para ingresar datos de creacion *******
        public ActionResult CreateItem()
        {
            Session["Mensaje"] = "";
            int codigo = int.Parse(Session["CodigoCreate"].ToString());
            Horario model = new Horario() { Codigo=codigo};
            return View(model);
        } 

        // POST: /HorarioDeportivo/Create
        [HttpPost]
        public ActionResult CreateItem(FormCollection collection)
        {
            Session["Mensaje"] = "";
            //Session["CodigoCreate"] = "";
            try
            {
                int codigo = int.Parse(collection["Codigo"]);
                string horaInicio = (collection["HoraInicio"]);
                string horaFin = (collection["HoraFin"]);
                string dia = (collection["Dia"]);
                string mensaje = proxy.registrarHorario(codigo, dia, horaInicio, horaFin);
                Session["detHorarios"] = proxy.listarHorario(codigo).ToList();
                Session["Mensaje"] = mensaje;

            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, "Error: " + e.Message);
            }
            return View("Details", Session["detHorarios"]);
        }
        
        //
        // GET: /HorarioDeportivo/Delete/5
        public ActionResult DeleteItem(int codigo,  string dia)
        {
            Session["Mensaje"] = "";
            try
            {
                Horario model = proxy.obtenerHorario(codigo, dia);
                return View(model);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, "Error: " + e.Message);
                return View("Details", Session["detHorarios"]);
            }
        }

        //
        // POST: /HorarioDeportivo/Delete/5

        [HttpPost]
        public ActionResult DeleteItem(int codigo,  string dia, FormCollection collection)
        {
            Session["Mensaje"] = "";
            try
            {
                // TODO: Add delete logic here
                string mensaje = proxy.eliminarHorario(codigo, dia);
                Session["detHorarios"] = proxy.listarHorario(codigo).ToList();
                Session["Mensaje"] = mensaje;
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, "Error: " + e.Message);
            }
            return View("Details", Session["detHorarios"]);
        }


    }
}
