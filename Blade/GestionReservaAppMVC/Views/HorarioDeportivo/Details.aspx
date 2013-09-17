<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GestionReservaAppMVC.Models.Horario>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Horarios Deportivos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detalles</h2>

    <fieldset>
        <legend>Campos</legend>
        
        <div class="display-label" style="color:Blue">Codigo</div>
        <div class="display-field"><%: Model.Codigo %></div>

        <div class="display-label"  style="color:Blue">EspacioDeportivo</div>
        <div class="display-field"><%: Model.EspacioDeportivo.Codigo %> - <%: Model.EspacioDeportivo.Nombre%></div>

        <div class="display-label"  style="color:Blue">Sede</div>
        <div class="display-field"><%: Model.Sede.Codigo%> - <%: Model.Sede.Nombre %></div>

        <div class="display-label"  style="color:Blue">Dia</div>
        <div class="display-field"><%: Model.Dia %></div>
        
        <div class="display-label"  style="color:Blue">Horainicio</div>
        <div class="display-field"><%: Model.Horainicio %></div>
        
        <div class="display-label"  style="color:Blue">HoraFin</div>
        <div class="display-field"><%: Model.HoraFin %></div>
        
    </fieldset>
    <p>
        <%: Html.ActionLink("Editar", "Edit", new { id=Model.Codigo }) %> |
        <%: Html.ActionLink("Regresar a la lista", "Index") %>
    </p>

</asp:Content>

