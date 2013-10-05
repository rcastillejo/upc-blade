<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GestionReservaAppMVC.GestionReservaWS.Horario>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	EditItem
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Editar</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Campos</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Codigo) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Codigo, new Dictionary<string, object>() { { "readonly", "true" } })%>
                <%: Html.ValidationMessageFor(model => model.Codigo)%>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Dia) %>
            </div>
            <div class="editor-field">                
                <%: Html.DropDownListFor(model => model.Dia, new SelectList((List<String>)Session["dias"]), new Dictionary<string, object>() { { "readonly", "true" }, {"disabled", "true"} })%>
                <%: Html.ValidationMessageFor(model => model.Dia)%>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.HoraInicio) %>
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => model.HoraInicio, new SelectList((List<String>)Session["horasInicio"]))%>
                <%: Html.ValidationMessageFor(model => model.HoraInicio)%>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.HoraFin) %>
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => model.HoraFin, new SelectList((List<String>)Session["horasFin"]))%>
                <%: Html.ValidationMessageFor(model => model.HoraFin)%>
            </div>
            
            <p>
                <input type="submit" value="Guardar" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Regresar a la Lista", "Details", new { Codigo = Model.Codigo })%>
    </div>

</asp:Content>

