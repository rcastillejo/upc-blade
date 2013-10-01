<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GestionReservaAppMVC.GestionReservaWS.Horario>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	DetailsItem
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Item de Detalle</h2>
    <%: Html.ValidationSummary(true) %>

    <fieldset>
        <legend>Campos</legend>
        
         <div class="display-label" style="color:Blue">Codigo</div>
        <div class="display-field"><%: Model.Codigo %></div>

        <div class="display-label"  style="color:Blue">Dia</div>
        <div class="display-field"><%: Model.Dia %></div>
        
        <div class="display-label"  style="color:Blue" >Hora de Inicio</div>
        <div class="display-field"><%: Model.HoraInicio %></div>
        
        <div class="display-label"  style="color:Blue">Hora de Fin</div>
        <div class="display-field"><%: Model.HoraFin %></div>
        
    </fieldset>
    <p>
        <%: Html.ActionLink("Editar", "EditItem", new { codigo = Model.Codigo, dia = Model.Dia })%> |
        <%: Html.ActionLink("Regresar a la lista", "Details", new { Codigo = Model.Codigo })%>
    </p>

</asp:Content>

