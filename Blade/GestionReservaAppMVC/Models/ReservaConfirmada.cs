using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionReservaAppMVC.Models
{
    public class ReservaConfirmada : Reserva
    {

        public ReservaConfirmada() { }
        public ReservaConfirmada(string codReserva, Sede sede, EspacioDeportivo espacioDeportivo, Actividad actividad, Usuario usuario, DateTime fechaReserva, string diaCorto, string horaInicio, string horaTermino, EstadoReserva estado)
    {
        this.CodReserva = codReserva;
        this.Sede = sede;
        this.EspacioDeportivo = espacioDeportivo;
        this.Actividad = actividad;
        this.Usuario = usuario;
        this.FechaReserva = fechaReserva;
        this.DiaCorto = diaCorto;
        this.HoraInicio = horaInicio;
        this.HoraTermino = horaTermino;
        this.Estado = estado;
    }
    }
}