<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<GestionReservaAppMVC.GestionReservaWS.Horario>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detalle Horario Espacios Deportivos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Espacios Deportivos </h2>    
    <%: Html.ValidationSummary(true) %>
    <table>
        <tr>
            <th></th>
            <th>
                Codigo
            </th>
            <th>
                Dia
            </th>
            <th>
                Hora de Inicio
            </th>
            <th>
                Hora de Fin 
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Editar", "EditItem", new { Codigo = item.Codigo, Dia=item.Dia })%> |
                <%: Html.ActionLink("Detalle", "DetailsItem", new { Codigo = item.Codigo, Dia=item.Dia })%> |
                <%: Html.ActionLink("Eliminar", "DeleteItem", new { Codigo = item.Codigo, Dia = item.Dia })%>
            </td>
            <td>
                <%: item.Codigo%>
            </td>
            <td>
                <%: item.Dia %>
            </td>
            <td>
                <%: item.HoraInicio %> 
            </td>
            <td>
                <%: item.HoraFin %> 
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
    
    <%: Html.ActionLink("Crear", "CreateItem")%>
    <%: Html.ActionLink("Regresar a la lista", "Index") %>
    <%: Session["Mensaje"]%>
    </p>

</asp:Content>

