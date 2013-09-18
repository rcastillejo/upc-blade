<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GestionReservaAppMVC.Models.Horario>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Eliminar Programacion de Horario</h2>

    <h3>¿Seguro(a) de eliminar este Horario?</h3>
    <fieldset>
        <legend>Campos</legend>
        
        <div class="display-label">Codigo</div>
        <div class="display-field"><%: Model.Codigo %></div>
        
        <div class="display-label">Espacio Deportivo</div>
        <div class="display-field"><%: Model.EspacioDeportivo.Codigo %> - <%: Model.EspacioDeportivo.Nombre %></div>

        <div class="display-label">Sede</div>
        <div class="display-field"><%: Model.EspacioDeportivo.Sede.Codigo %> - <%: Model.EspacioDeportivo.Sede.Nombre %></div>

    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Delete" /> |
		    <%: Html.ActionLink("Regresar a la lista", "Index") %>
        </p>
    <% } %>

</asp:Content>

