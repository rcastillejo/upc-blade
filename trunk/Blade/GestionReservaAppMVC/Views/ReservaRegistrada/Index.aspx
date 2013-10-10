<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<GestionReservaAppMVC.GestionReservaWS.Reserva>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Reserva Registradas
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Reserva Registradas</h2>
    <%: Html.ValidationSummary(true) %>
    <table>
        <tr>
            <th>
                CodReserva
            </th>
             <th>
                EspacioDeportivo
            </th>
            <th>
                Horas
            </th>
            <th>
                Dia
            </th>
            <th>
                Fecha Inicio
            </th>
            <th>
                Fecha Fin
            </th>
            <th>
                Usuario
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: item.Codigo %>
            </td>
            <td>
                <%: item.CodigoEspacio %>
            </td>
            <td>
                <%: item.CantidadHoras %>
            </td>
            <td>
                <%: item.Dia %>
            </td>
            <td>
                <%: item.FechaInicio %>
            </td>
            <td>
                <%: item.FechaFin %>
            </td>
            <td>
                -
            </td>
        </tr>
    
    <% } %>

    </table>
    
    <p>
        <%: Html.ActionLink("Registrar Reserva", "Create") %> <%: Session["Mensaje"]%>
    </p>

</asp:Content>

