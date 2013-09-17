<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GestionReservaAppMVC.Models.ReglaEspacioDeportivo>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edición</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Espacio Deportivo</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.EspacioDeportivo.Codigo) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.EspacioDeportivo.Codigo, new Dictionary<string, object>() { { "readonly", "true" } })%>
                <%: Html.ValidationMessageFor(model => model.EspacioDeportivo.Codigo)%>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.EspacioDeportivo.Nombre)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.EspacioDeportivo.Nombre, new Dictionary<string, object>() { { "readonly", "true" } })%>
                <%: Html.ValidationMessageFor(model => model.EspacioDeportivo.Nombre)%>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.EspacioDeportivo.Sede)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.EspacioDeportivo.Sede.Nombre, new Dictionary<string, object>() { { "readonly", "true" } })%>
                <%: Html.ValidationMessageFor(model => model.EspacioDeportivo.Sede.Nombre)%>
            </div>
        </fieldset>

        <fieldset>
            <legend>Reglamento para el uso del campo deportivo</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.MinAnticipacionReservarMinuto)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.MinAnticipacionReservarMinuto)%>
                <%: Html.ValidationMessageFor(model => model.MinAnticipacionReservarMinuto)%>
            </div>

            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.MaxAnticipacionReservaDia)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.MaxAnticipacionReservaDia)%>
                <%: Html.ValidationMessageFor(model => model.MaxAnticipacionReservaDia)%>
            </div>
            
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.MinAnticipacionCancelarHora)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.MinAnticipacionCancelarHora)%>
                <%: Html.ValidationMessageFor(model => model.MinAnticipacionCancelarHora)%>
            </div>
            
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.MaxHoraReservaDia)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.MaxHoraReservaDia)%>
                <%: Html.ValidationMessageFor(model => model.MaxHoraReservaDia)%>
            </div>
             
            <div class="editor-label">
                <%: Html.LabelFor(model => model.MaxHoraReservaSemana)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.MaxHoraReservaSemana)%>
                <%: Html.ValidationMessageFor(model => model.MaxHoraReservaSemana)%>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.MaxNumUsuario)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.MaxNumUsuario)%>
                <%: Html.ValidationMessageFor(model => model.MaxNumUsuario)%>
            </div>


            <p>
                <input type="submit" value="Guardar" /> <%: ViewData["Mensaje"] %>
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Regresar al listado", "Index") %>
    </div>

</asp:Content>

