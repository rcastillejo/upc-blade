<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GestionReservaAppMVC.Models.DetalleHorario>" %>

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
                <%: Html.LabelFor(model => model.Dia) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Dia) %>
                <%: Html.ValidationMessageFor(model => model.Dia) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Horainicio) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Horainicio) %>
                <%: Html.ValidationMessageFor(model => model.Horainicio) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.HoraFin) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.HoraFin) %>
                <%: Html.ValidationMessageFor(model => model.HoraFin) %>
            </div>
            
            <p>
                <input type="submit" value="Guardar" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Regresar a la Lista", "Index") %>
    </div>

</asp:Content>

