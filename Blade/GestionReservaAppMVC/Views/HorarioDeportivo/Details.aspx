<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<GestionReservaAppMVC.Models.DetalleHorario>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detalle Horario Espacios Deportivos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Espacios Deportivos </h2>

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
                <%: Html.ActionLink("Editar", "Edit", new { Codigo = item.Horario.Codigo })%> |
                <%: Html.ActionLink("Eliminar", "Delete", new { Codigo = item.Horario.Codigo })%>
            </td>
            <td>
                <%: item.Horario.Codigo%>
            </td>
            <td>
                <%: item.Dia %>
            </td>
            <td>
                <%: item.Horainicio %> 
            </td>
            <td>
                <%: item.HoraFin %> 
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

