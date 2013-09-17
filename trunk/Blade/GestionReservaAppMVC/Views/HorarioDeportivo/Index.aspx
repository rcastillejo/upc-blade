<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<GestionReservaAppMVC.Models.Horario>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Horarios Deportivos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Horarios Deportivos</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Codigo
            </th>
            <th>
                Espacio Deportivo
            </th>
            <th>
                Sede
            </th>
            <th>
                Dia
            </th>
            <th>
                Horainicio
            </th>
            <th>
                HoraFin
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Editar", "Edit", new { Codigo = item.Codigo })%> |
                <%: Html.ActionLink("Detalles", "Details", new { Codigo = item.Codigo })%> |
                <%: Html.ActionLink("Eliminar", "Delete", new { Codigo = item.Codigo })%>
            </td>
            <td>
                <%: item.Codigo %>
            </td>
            <td>
                <%: item.EspacioDeportivo.Codigo %> - <%: item.EspacioDeportivo.Nombre %>
            </td>
            <td>
                <%: item.Sede.Codigo %> - <%: item.Sede.Nombre %>
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
        <%: Html.ActionLink("Crear", "Create") %>
    </p>

</asp:Content>
