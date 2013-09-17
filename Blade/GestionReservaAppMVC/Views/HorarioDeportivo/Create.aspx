<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GestionReservaAppMVC.Models.Horario>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Registros de Horarios Deportivos</h2>

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
                <%: Html.LabelFor(model => model.EspacioDeportivo) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.EspacioDeportivo.Codigo ) %> <%--, new SelectList((List<GestionReservaAppMVC.EspacioDeportivoWS.EspacioDeportivo>)Session["Espaciodeportivo"],"codigo","nombre"))%> --%>
                <%: Html.ValidationMessageFor(model => model.EspacioDeportivo.Codigo)%>
            </div>

             <div class="editor-label">
                <%: Html.LabelFor(model => model.Sede) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Sede.Codigo)%>
                <%: Html.ValidationMessageFor(model => model.Sede.Codigo)%>
            </div>
            <p>
                <input type="submit" value="Crear" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Regresar a la lista", "Index") %>
    </div>

</asp:Content>

