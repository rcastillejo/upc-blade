using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HoarioServices.Persistencia;
using HorarioServices.Dominio;
using System.ServiceModel.Web;
using HorarioServices.Excepcion;
using System.Net;

namespace HorarioServices
{
    public class Horarios : IHorarios
    {
        private HorarioDAO dao = new HorarioDAO();

        public Horario RegistrarHorario(Horario horarioACrear)
        {
            Horario horarioObtenido = dao.Obtener(horarioACrear.Codigo, horarioACrear.Dia);
            Horario horarioRegistrado = null;
            if (horarioObtenido == null)
            {
                horarioRegistrado = dao.Crear(horarioACrear);
            }
            else 
            {
                horarioRegistrado = dao.Modificar(horarioACrear);
            }

            if (horarioRegistrado == null)
            {
                throw new WebFaultException<Error>(
                     new Error()
                     {
                         Codigo = "ERR002",
                         Mensaje = "No fue posible rewistrar el horario"
                     },
                         HttpStatusCode.InternalServerError);
            }

            return horarioRegistrado;
        }

        public Horario ObtenerHorario(string codigo, string dia)
        {
            Horario horarioObtenido = dao.Obtener(int.Parse(codigo), dia);
            if (horarioObtenido == null) {
                throw new WebFaultException<Error>(
                     new Error()
                     {
                         Codigo = "ERR001",
                         Mensaje = "Horario no disponible"
                     },
                         HttpStatusCode.InternalServerError);
            }
            return dao.Obtener(int.Parse(codigo), dia);
        }


        public void EliminarHorario(string codigo, string dia)
        {
            dao.Eliminar(int.Parse(codigo), dia);
        }

        public List<Horario> ListarHorarios(string codigo)
        {
            return dao.ListarTodos(int.Parse(codigo));
        }
    }
}
