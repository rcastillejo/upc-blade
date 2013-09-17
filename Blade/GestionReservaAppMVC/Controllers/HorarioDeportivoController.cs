using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionReservaAppMVC.Models;

namespace GestionReservaAppMVC.Controllers
{
    public class HorarioDeportivoController : Controller
    {
        //*** Creo las sedes ***************************************************************************************
        private List<Sede> Sedesparahorario()
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

        //*** Creo los espacios para luego llamarlos en horarios ***************************************************
        private List<EspacioDeportivo> Espaciosparahorarios()
        {
            List<Sede> sedesx = Sedesparahorario();
            List<EspacioDeportivo> espacios = new List<EspacioDeportivo>();
            espacios.Add(new EspacioDeportivo() { Codigo = 101, Nombre = "Piscina", Sede = sedesx.ElementAt(0) });
            espacios.Add(new EspacioDeportivo() { Codigo = 101, Nombre = "Cancha Futbol", Sede = sedesx.ElementAt(2) });
            espacios.Add(new EspacioDeportivo() { Codigo = 103, Nombre = "Cancha Tenis", Sede = sedesx.ElementAt(0) });
            espacios.Add(new EspacioDeportivo() { Codigo = 104, Nombre = "Piscina", Sede = sedesx.ElementAt(1) });
            espacios.Add(new EspacioDeportivo() { Codigo = 105, Nombre = "Cancha Basket", Sede = sedesx.ElementAt(2) });

            return espacios;
        }

        //
        //
        // *** Creo el horario para el espacio deportivo creado  *******************************************************
        private List<Horario> CrearHorario()
        {
            List<EspacioDeportivo> Espaciosx = Espaciosparahorarios();
           /* Sede lince = new Sede() { Codigo = 1, Nombre = "Lince" };
            Sede sanIsidro = new Sede() { Codigo = 2, Nombre = "San Isidro" };
            Sede sanBorja = new Sede() { Codigo = 3, Nombre = "San Borja" };

            EspacioDeportivo Piscina= new EspacioDeportivo() { Codigo = 101, Nombre = "Piscina", Sede=lince };
            EspacioDeportivo CanchaFutbol = new EspacioDeportivo() { Codigo = 102, Nombre = "Cancha Futbol", Sede = sanIsidro};
            EspacioDeportivo CanchaTenis = new EspacioDeportivo() { Codigo = 103, Nombre = "Cancha Tenis", Sede = sanBorja};*/

            List<Horario> Horarios = new List<Horario>();
            Horarios.Add(new Horario() { Codigo = 111, EspacioDeportivo = Espaciosx.ElementAt(0), Sede = Espaciosx.ElementAt(0).Sede , Dia = "Lunes", Horainicio = "08:14", HoraFin = "15:15" });
            Horarios.Add(new Horario() { Codigo = 112, EspacioDeportivo = Espaciosx.ElementAt(0), Sede = Espaciosx.ElementAt(0).Sede, Dia = "Martes", Horainicio = "08:14", HoraFin = "15:15" });
            Horarios.Add(new Horario() { Codigo = 113, EspacioDeportivo = Espaciosx.ElementAt(1), Sede = Espaciosx.ElementAt(1).Sede, Dia = "Lunes", Horainicio = "09:00", HoraFin = "12:15" });
            Horarios.Add(new Horario() { Codigo = 114, EspacioDeportivo = Espaciosx.ElementAt(2), Sede = Espaciosx.ElementAt(2).Sede, Dia = "Lunes", Horainicio = "08:14", HoraFin = "18:00" });
            
            return Horarios;
        }
        private Horario ObtenerHorario(int codigo)//(int CodigoEspacio, int codsede)
        {
            List<Horario> Horarios = (List<Horario>)Session["Horarios"];
            Horario model=Horarios.Single(delegate(Horario horario) {
           // if ((Horario.EspacioDeportivo.Codigo==CodigoEspacio) && (Horario.Sede.Codigo==codsede)) return true;
                if (horario.Codigo == codigo) return true;
            else return false;
            });
            return model;
        }
        
        
        // GET: /HorarioDeportivo/
        // ***** Muestra pagina con listado de Horarios *****
        public ActionResult Index()
        {
            if (Session["Horarios"] == null)
                Session["Horarios"] = CrearHorario();
            List<Horario> model = (List<Horario>)Session["Horarios"];
            return View(model);
        }


        // GET: /HorarioDeportivo/Details/5
        // ***** Muestra pagina con datos de un asesor *****
        public ActionResult Details(int Codigo)//(int CodigoEspacio, int codsede)
        {
            Session["Mensaje"] = "";
            Horario model = ObtenerHorario(Codigo);
            return View(model);
        }

        // GET: /HorarioDeportivo/Create
        //******* Muestra pagina para ingresar datos de creacion *******
        public ActionResult Create()
        {
            return View();
        } 

        // POST: /HorarioDeportivo/Create
        //******* Recibe los datos del formulario y realiza creacion ********
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                List<Horario> Horarios=(List<Horario>)Session["Horarios"];
                Horarios.Add(new Horario()
                {
                   EspacioDeportivo= new EspacioDeportivo()
                   {
                       Codigo =int.Parse(collection["EspacioDeportivo.Codigo"]),
                       Nombre =collection["Nombre"],
                       Sede =new Sede()
                       {
                           Codigo=int.Parse(collection["Sede.Codigo"]),
                           Nombre=collection["Sede.Nombre"]
                       }
                   },

                    Sede =new Sede()
                       {
                           Codigo=int.Parse(collection["Sede.Codigo"]),
                           Nombre=collection["Sede.Nombre"]
                       },
                Dia=collection["Dia"],
                Horainicio=collection["Horainicio"],
                HoraFin=collection["HoraFin"]
                });
                return RedirectToAction("Index");           
              }
           catch
            {
                return View();
            }
        }
        
        //
        // GET: /HorarioDeportivo/Edit/5
        public ActionResult Edit(int codigo)//(int codespacio,int codsede)
        {
            Horario model = ObtenerHorario(codigo);//(codespacio, codsede);
            return View(model);
        }

        //
        // POST: /HorarioDeportivo/Edit/5
        [HttpPost]
        public ActionResult Edit(int codigo, FormCollection collection)//(int codespacio, int codsede, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Horario model = ObtenerHorario(codigo);//(codespacio, codsede);
                model.Dia = collection["Dia"];
                model.Horainicio = collection["Horainicio"];
                model.HoraFin = collection["HoraFin"];
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /HorarioDeportivo/Delete/5
        public ActionResult Delete(int codigo)//(int codespacio, int codsede)
        {
            Horario model = ObtenerHorario(codigo);//(codespacio, codsede);
            return View(model);
        }

        //
        // POST: /HorarioDeportivo/Delete/5

        [HttpPost]
        public ActionResult Delete(int codigo, FormCollection collection)//(int codespacio, int codsede, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 List<Horario> Horarios=(List<Horario>)Session["Horarios"];
 Horarios.Remove(ObtenerHorario(codigo));//(ObtenerHorario(codespacio,codsede));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
