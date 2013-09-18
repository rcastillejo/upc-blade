<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GestionReservaAppMVC.Models.CriterioReservar>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Criterios de la Reserva</h2>
    <% using (Html.BeginForm()) { %>
    <fieldset>        
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Sede)%>
        </div>

        <div class="editor-field">
                <%: Html.DropDownListFor(model => model.Sede.Codigo, new SelectList((List<GestionReservaAppMVC.Models.Sede>)Session["sedes"], "Codigo", "Nombre"))%>
                <%: Html.ValidationMessageFor(model => model.Sede.Codigo) %>
        </div>
        
        <div class="editor-label">
            <%: Html.LabelFor(model => model.EspacioDeportivo)%>
        </div>

        <div class="editor-field">
                <%: Html.DropDownListFor(model => model.EspacioDeportivo.Codigo, new SelectList((List<GestionReservaAppMVC.Models.EspacioDeportivo>)Session["espacios"], "Codigo", "Nombre","Sede"))%>
                <%: Html.ValidationMessageFor(model => model.Sede.Codigo) %>
        </div>

        
        <div class="editor-label">
            <%: Html.LabelFor(model => model.NumHoras)%>
        </div>
        <div class="editor-field">
                <%: Html.TextBoxFor(model => model.NumHoras) %>
                <%: Html.ValidationMessageFor(model => model.NumHoras)%>
        </div>

        
        <div class="editor-label">
            <%: Html.LabelFor(model => model.FechaInicio)%>
        </div>
        <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FechaInicio)%>
                <%: Html.ValidationMessageFor(model => model.FechaInicio)%>
        </div>

        
        <div class="editor-label">
            <%: Html.LabelFor(model => model.FechaTermino)%>
        </div>
        <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FechaTermino)%>
                <%: Html.ValidationMessageFor(model => model.FechaTermino)%>
        </div>

        
    </fieldset>
      
            <p>
                <input type="submit" value="Buscar" /> <%: ViewData["Mensaje"] %>
            </p>
    <% } %>


    
    <div>
        <%: Html.ActionLink("Regresar al listado", "Index") %>
    </div>
   
</asp:Content>

