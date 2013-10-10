<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GestionReservaAppMVC.GestionReservaWS.Reserva>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Registro
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Reserva</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Campos</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.CodigoEspacio) %>
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => model.CodigoEspacio, new SelectList((List<GestionReservaAppMVC.GestionReservaWS.EspacioDeportivo>)Session["espacios"], "Codigo", "Nombre"))%>
                <%: Html.ValidationMessageFor(model => model.CodigoEspacio)%>
            </div>

            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.CantidadHoras) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.CantidadHoras)%>
                <%: Html.ValidationMessageFor(model => model.CantidadHoras)%>
            </div>
            

            <div class="editor-label">
                <%: Html.LabelFor(model => model.FechaInicio) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FechaInicio)%>
                <%: Html.ValidationMessageFor(model => model.FechaInicio)%>
            </div>
            

            <p>
                <input type="submit" value="Crear" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Regresar al listado", "Index") %>
    </div>

</asp:Content>

