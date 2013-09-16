<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GestionReservaAppMVC.Models.ReservaCancelada>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Cancelar
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Cancelar</h2>

    <h3>¿Estas seguro que deseas cancelar la Resera?</h3>
    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Código  : <%: Model.CodReserva %></div>
       

        <div class="display-label">Sede  : <%: Model.Sede.Nombre %></div>
       

        <div class="display-label">EspacioDeportivo  : <%: Model.EspacioDeportivo.Nombre %></div>
        

        <div class="display-label">Actividad  : <%: Model.Actividad.nomActividad %></div>
        
        
        <div class="display-label">FechaReserva  : <%: String.Format("{0:g}", Model.FechaReserva) %></div>
        
        
        <div class="display-label">DiaCorto  : <%: Model.DiaCorto %></div>
                
        <div class="display-label">HoraInicio  : <%: Model.HoraInicio %></div>
        
        
        <div class="display-label">HoraTermino  : <%: Model.HoraTermino %></div>
      
        
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Cancelar" /> |
		        <%: Html.ActionLink("Regresar al listado", "Index") %>
        </p>
    <% } %>

</asp:Content>

