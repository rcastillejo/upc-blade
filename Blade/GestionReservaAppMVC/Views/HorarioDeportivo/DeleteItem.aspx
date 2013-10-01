<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GestionReservaAppMVC.GestionReservaWS.Horario>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Eliminar Horario</h2>
    <%: Html.ValidationSummary(true) %>

    <h3>¿Seguro(a) de eliminar este Horario?</h3>
    <fieldset>
        <legend>Campos</legend>
        
        <div class="display-label">Codigo</div>
        <div class="display-field"><%: Model.Codigo %></div>
        
        <div class="display-label">Dia</div>
        <div class="display-field"><%: Model.Dia%></div>

        <div class="display-label">Hora Inicio</div>
        <div class="display-field"><%: Model.HoraInicio%></div>
        
        <div class="display-label">Hora Fin</div>
        <div class="display-field"><%: Model.HoraFin%></div>
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Delete" /> |
		    <%: Html.ActionLink("Regresar a la lista", "Details", new { Codigo = Model.Codigo })%>
        </p>
    <% } %>

</asp:Content>

