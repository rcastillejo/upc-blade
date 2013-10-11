<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GestionReservaAppMVC.GestionReservaWS.Reserva>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Cancelar
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <%--reserva.Codigo, reserva.CodigoEspacio, reserva.Dia, reserva.CantidadHoras, reserva.FechaInicio, reserva.FechaFin, reserva.Estado--%>
    <h2>Cancelar</h2>

    <h3>¿Estas seguro que deseas cancelar la Resera?</h3>
    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Código  : <%: Model.Codigo %></div>
        <div class="display-label">CodigoEspacio  : <%: Model.CodigoEspacio %></div>
        <div class="display-label">Dia  : <%: Model.Dia %></div>
       <div class="display-label">CantidadHoras  : <%: Model.CantidadHoras %></div>

        <%--<div class="display-label">Sede  : <%: Model.Sede.Nombre %></div>--%>     

       <%-- <div class="display-label">EspacioDeportivo  : <%: Model.EspacioDeportivo.Nombre %></div>--%>        

        <%--<div class="display-label">Actividad  : <%: Model.Actividad.nomActividad %></div>--%>
        
        
        <div class="display-label">FechaInicio  : <%: String.Format("{0:g}", Model.FechaInicio) %></div>
        <div class="display-label">FechaFin  : <%: String.Format("{0:g}", Model.FechaFin) %></div>
        
        
       <%-- <div class="display-label">DiaCorto  : <%: Model.DiaCorto %></div>
                
        <div class="display-label">HoraInicio  : <%: Model.HoraInicio %></div>
        
        
        <div class="display-label">HoraTermino  : <%: Model.HoraTermino %></div>--%>
      
        
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Cancelar" /> |
		        <%: Html.ActionLink("Regresar al listado", "Index") %>
        </p>
    <% } %>

</asp:Content>

