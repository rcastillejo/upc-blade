<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<GestionReservaAppMVC.Models.ReservaCancelada>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Cancelar
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Cancelar Reserva</h2>

    <table>
        <tr>
            <th></th>
            <th>
                CodReserva
            </th>
            <th>
                Sede
            </th>
             <th>
                EspacioDeportivo
            </th>
             <th>
                Actividad
            </th>
            <th>
                Usuario
            </th>
            <th>
                FechaReserva
            </th>
            <th>
                DiaCorto
            </th>
            <th>
                HoraInicio
            </th>
            <th>
                HoraTermino
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Cancelar", "Cancelar", new { id=item.CodReserva})%> |
       <%--         <%: Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ })%> |
                <%: Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ })%>--%>
            </td>
            <td>
                <%: item.CodReserva %>
            </td>
            <td>
                <%: item.Sede.Codigo %>
            </td>
            <td>
                <%: item.EspacioDeportivo.Nombre %>
            </td>
            <td>
                <%: item.Actividad.nomActividad %>
            </td>
            <td>
                <%: item.Usuario.codUsuario %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.FechaReserva) %>
            </td>
            <td>
                <%: item.DiaCorto %>
            </td>
            <td>
                <%: item.HoraInicio %>
            </td>
            <td>
                <%: item.HoraTermino %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Cancelar", "Cancelar") %>
    </p>

</asp:Content>

