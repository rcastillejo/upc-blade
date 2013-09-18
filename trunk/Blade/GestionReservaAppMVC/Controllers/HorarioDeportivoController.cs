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
       // EspacioDeportivoWS.EspacioDeportivoServiceClient espacioProxy = new EspacioDeportivoWS.EspacioDeportivoServiceClient();

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
            espacios.Add(new EspacioDeportivo() { Codigo = 102, Nombre = "Cancha Futbol", Sede = sedesx.ElementAt(0) });
            espacios.Add(new EspacioDeportivo() { Codigo = 103, Nombre = "Cancha Tenis", Sede = sedesx.ElementAt(1) });
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
 
            List<Horario> Horarios = new List<Horario>();
            Horarios.Add(new Horario() { Codigo = 11, EspacioDeportivo = Espaciosx.ElementAt(0), Sede = Espaciosx.ElementAt(0).Sede  });// , Dia = "Lunes", Horainicio = "08:14", HoraFin = "15:15" });
            Horarios.Add(new Horario() { Codigo = 12, EspacioDeportivo = Espaciosx.ElementAt(1), Sede = Espaciosx.ElementAt(1).Sede  });//, Dia = "Martes", Horainicio = "08:14", HoraFin = "15:15" });
            Horarios.Add(new Horario() { Codigo = 13, EspacioDeportivo = Espaciosx.ElementAt(2), Sede = Espaciosx.ElementAt(2).Sede  });//, Dia = "Lunes", Horainicio = "09:00", HoraFin = "12:15" });
            Horarios.Add(new Horario() { Codigo = 14, EspacioDeportivo = Espaciosx.ElementAt(3), Sede = Espaciosx.ElementAt(3).Sede  });//, Dia = "Lunes", Horainicio = "08:14", HoraFin = "18:00" });
            
            return Horarios;
        }
        
        // *** Creo el detalle de horario   ***********************************************************
        private List<DetalleHorario> CrearDetalleHorario()
        {
            List<Horario> horariosx = CrearHorario();
            List<DetalleHorario> DetHorarios = new List<DetalleHorario>();
            DetHorarios.Add(new DetalleHorario() { Horario = horariosx.ElementAt(0), Dia = "Lunes", Horainicio = "08:14", HoraFin = "15:15" });
            DetHorarios.Add(new DetalleHorario() { Horario = horariosx.ElementAt(0), Dia = "Martes", Horainicio = "08:14", HoraFin = "15:15" });
            DetHorarios.Add(new DetalleHorario() { Horario = horariosx.ElementAt(0), Dia = "Miercoles", Horainicio = "08:14", HoraFin = "15:15" });
            DetHorarios.Add(new DetalleHorario() { Horario = horariosx.ElementAt(0), Dia = "Jueves", Horainicio = "08:14", HoraFin = "15:15" });
            DetHorarios.Add(new DetalleHorario() { Horario = horariosx.ElementAt(0), Dia = "Viernes", Horainicio = "08:14", HoraFin = "15:15" });
            DetHorarios.Add(new DetalleHorario() { Horario = horariosx.ElementAt(1), Dia = "Lunes", Horainicio = "08:14", HoraFin = "15:15" });
            DetHorarios.Add(new DetalleHorario() { Horario = horariosx.ElementAt(1), Dia = "Martes", Horainicio = "08:14", HoraFin = "15:15" });
            DetHorarios.Add(new DetalleHorario() { Horario = horariosx.ElementAt(1), Dia = "Miercoles", Horainicio = "08:14", HoraFin = "15:15" });
            DetHorarios.Add(new DetalleHorario() { Horario = horariosx.ElementAt(2), Dia = "Lunes", Horainicio = "08:14", HoraFin = "15:15" });
            DetHorarios.Add(new DetalleHorario() { Horario = horariosx.ElementAt(2), Dia = "Martes", Horainicio = "08:14", HoraFin = "15:15" });
            DetHorarios.Add(new DetalleHorario() { Horario = horariosx.ElementAt(2), Dia = "Miercoles", Horainicio = "08:14", HoraFin = "15:15" });
            DetHorarios.Add(new DetalleHorario() { Horario = horariosx.ElementAt(2), Dia = "Jueves", Horainicio = "08:14", HoraFin = "15:15" });
            return DetHorarios;
            
        }


        private Horario ObtenerHorario(int codigo)
        {
            List<Horario> Horarios = (List<Horario>)Session["Horarios"];
            Horario model=Horarios.Single(delegate(Horario horario) {
                   if (horario.Codigo == codigo) return true;
            else return false;
            });
            return model;
        }

        // ***  obtengo el detalle de cada horario *****************************************************
          private List<DetalleHorario>  ObtenerdetalleHorario(int codigo)//(int CodigoEspacio, int codsede)
        {
            List<DetalleHorario> detHorarios = CrearDetalleHorario();//List<DetalleHorario> detHorarios =(List<DetalleHorario>)Session["detHorarios"];

           List<DetalleHorario> det = new List<DetalleHorario>();
               for (int index = 0; index < detHorarios.Count; index++)

             {
                    if (detHorarios.ElementAt(index).Horario.Codigo == codigo)
                    {
                    det.Add(new DetalleHorario() { Horario = detHorarios.ElementAt(index).Horario, Dia = detHorarios.ElementAt(index).Dia, Horainicio = detHorarios.ElementAt(index).Horainicio, HoraFin = detHorarios.ElementAt(index).HoraFin });
                    }
            } 
             return det;
        }

          // ******  Va a obtener un registro del detalle **********************************************
        private DetalleHorario ObtenerHorariodeDetalle(int codigo,string dia)
          {
              List<DetalleHorario> detHorarios = (List<DetalleHorario>)Session["detHorarios"];
              DetalleHorario model = detHorarios.Single(delegate(DetalleHorario dethorariodet)
              {
                  if ((dethorariodet.Horario.Codigo == codigo) && (dethorariodet.Dia == dia )) return true;
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
            if (Session["detHorarios"] == null)
                Session["detHorarios"] = CrearDetalleHorario();
            List<Horario> model = (List<Horario>)Session["Horarios"];
            return View(model);
        }


        // GET: /HorarioDeportivo/Details/5
        // ***** Muestra pagina con detalle de un horario de espacio deportivo y sede *****
        public ActionResult Details(int Codigo)//(int CodigoEspacio, int codsede)
        {
            Session["Mensaje"] = "";
            Session["detHorarios"] = ObtenerdetalleHorario(Codigo);
            List<DetalleHorario> modell = (List<DetalleHorario>)Session["detHorarios"];
            return View(modell);
        }

        public ActionResult DetailsItem(int codigo, string dia)
        {
            DetalleHorario model = ObtenerHorariodeDetalle(codigo, dia);
            return View(model);
        }
        


        
        // GET: /HorarioDeportivo/Create
        //******* Muestra pagina para ingresar datos de creacion *******
        public ActionResult Create()
        {
          /*  Session["Mensaje"] = "";
            if (Session["espacio"] == null)
            {
                Session["Mensaje"] = "No existe sedes disponibles";
                return RedirectToAction("Index");
            }
            else
            {*/
          //  if (Session["espacios"] == null)
            //    Session["espacios"] = espacioProxy.lista().ToList();
                return View();
            //}
        } 

        // POST: /HorarioDeportivo/Create
        //******* Recibe los datos del formulario y realiza creacion ********
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                List<Horario> Horarios=(List<Horario>)Session["Horarios"];
                Horarios.Add(new Horario()
                {
                       Codigo =int.Parse(collection["Codigo"]),//(collection["EspacioDeportivo.Codigo"]),
                       EspacioDeportivo = new EspacioDeportivo()
                       {
                           Codigo = int.Parse(collection["EspacioDeportivo.Codigo"]),
                           Nombre=collection["EspacioDeportivo.Nombre"],
                       },
                       
                   Sede =new Sede()
                       {
                           Codigo=int.Parse(collection["Sede.Codigo"]),
                           Nombre=collection["Sede.Nombre"]
                       },
           
                });
                return RedirectToAction("Index");           
              }
           catch
            {
                return View();
            }
        }
        
        

        // GET: /HorarioDeportivo/Edit/5
        public ActionResult Edit(int codigo)//(int codespacio,int codsede)
        {
            //Horario model = ObtenerHorario(codigo);//(codespacio, codsede);
            //return View(model);

           List<DetalleHorario> model = ObtenerdetalleHorario(codigo);
            return View(model);
        }

        // POST: /HorarioDeportivo/Edit/5
        [HttpPost]
        public ActionResult Edit(int codigo, FormCollection collection)
        {
            try
            {
                List<DetalleHorario> model = ObtenerdetalleHorario(codigo);
              //model.EspacioDeportivo=collection["EspacioDeportivo.codigo"];
                // model.Dia = collection["Dia"];
                //model.Horainicio = collection["Horainicio"];
               // model.HoraFin = collection["HoraFin"];
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // *************** Edita item de detalle ********
        public ActionResult EditItem(int codigo,string dia)//(int codespacio,int codsede)
        {
            DetalleHorario model = ObtenerHorariodeDetalle(codigo,dia);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditdatosItem(int codigo, string dia, FormCollection collection)
        {
            try
            {
                DetalleHorario model = ObtenerHorariodeDetalle(codigo, dia);
                model.Horainicio = collection["Horainicio"];
                model.HoraFin=collection["HoraFin"];
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


         
        //
        // GET: /HorarioDeportivo/Delete/5
        public ActionResult Delete(int codigo)
        {
            Horario model = ObtenerHorario(codigo);//(codespacio, codsede);
            return View(model);
        }

        //
        // POST: /HorarioDeportivo/Delete/5

        [HttpPost]
        public ActionResult Delete(int codigo, FormCollection collection)
        {
            try
            {
    List<Horario> Horarios=(List<Horario>)Session["Horarios"];
    Horarios.Remove(ObtenerHorario(codigo));//(ObtenerHorario(codespacio,codsede));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       // public Converter<DetalleHorario, TOutput> converter { get; set; }
    }
}
