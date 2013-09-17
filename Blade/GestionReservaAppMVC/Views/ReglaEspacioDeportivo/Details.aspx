<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GestionReservaAppMVC.Models.ReglaEspacioDeportivo>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Espacio Deportivo
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detalles</h2>

    <fieldset>
            <legend>Espacio Deportivo</legend>
            
           <div class="display-label">Codigo</div>
            <div class="display-field"><%: Model.EspacioDeportivo.Codigo %></div>
        
            <div class="display-label">Nombre</div>
            <div class="display-field"><%: Model.EspacioDeportivo.Nombre%></div>

            <div class="display-label">Sede</div>
            <div class="display-field"> <%: Model.EspacioDeportivo.Sede.Codigo%> - <%: Model.EspacioDeportivo.Sede.Nombre%></div>
        </fieldset>

        <fieldset>
            <legend>Reglamento para el uso del campo deportivo</legend>
            
            <div class="display-label">
                Mínimo anticipación de reserva(Minutos)
            </div>
            <div class="display-field">
                <%: Model.MinAnticipacionReservarMinuto%>
            </div>            
            
            <div class="display-label">
                Máximo anticipación de reserva(Días)
            </div>
            <div class="display-field">
                <%: Model.MaxAnticipacionReservaDia%>
            </div>
            <div class="display-label">
                Máximo anticipación para cancelar(Horas)
            </div>
            <div class="display-field">
                <%: Model.MinAnticipacionCancelarHora%>
            </div>
            <div class="display-label">
                Máximo horas para reservar por día
            </div>
            <div class="display-field">
                <%: Model.MaxHoraReservaDia%>
            </div>
            <div class="display-label">
                Máximo horas reservar semanal
            </div>
            <div class="display-field">
                <%: Model.MaxHoraReservaSemana%>
            </div>
            <div class="display-label">
                Máximo número usuario simultaneo
            </div>
            <div class="display-field">
                <%: Model.MaxNumUsuario%>
            </div>
        </fieldset>
    <p>
        <%: Html.ActionLink("Editar", "Edit", new {  id=Model.EspacioDeportivo.Codigo }) %> |
        <%: Html.ActionLink("Regresar al listado", "Index") %>
    </p>

</asp:Content>

