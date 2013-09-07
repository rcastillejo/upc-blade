<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GestionReservaAppMVC.Models.EspacioDeportivo>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Espacio Deportivo
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detalles</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Codigo</div>
        <div class="display-field"><%: Model.Codigo %></div>
        
        <div class="display-label">Nombre</div>
        <div class="display-field"><%: Model.Nombre %></div>

        <div class="display-label">Sede</div>
        <div class="display-field"> <%: Model.Sede.Codigo %> - <%: Model.Sede.Nombre %></div>
        
    </fieldset>
    <p>
        <%: Html.ActionLink("Editar", "Edit", new {  id=Model.Codigo }) %> |
        <%: Html.ActionLink("Regresar al listado", "Index") %>
    </p>

</asp:Content>

