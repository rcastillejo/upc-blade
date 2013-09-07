<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GestionReservaAppMVC.Models.EspacioDeportivo>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edición</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Campos</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Codigo) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Codigo) %>
                <%: Html.ValidationMessageFor(model => model.Codigo) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Nombre) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Nombre) %>
                <%: Html.ValidationMessageFor(model => model.Nombre) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Sede)%>
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => model.Sede.Codigo, new SelectList((List<GestionReservaAppMVC.Models.Sede>)Session["sedes"], "Codigo", "Nombre"))%>
                <%: Html.ValidationMessageFor(model => model.Sede.Codigo) %>
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

