<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<GestionReservaAppMVC.GestionReservaWS.Reserva>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Cancelar
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Cancelar Reserva</h2>
<%--    reserva.Codigo, reserva.CodigoEspacio, reserva.Dia, reserva.CantidadHoras, reserva.FechaInicio, reserva.FechaFin, reserva.Estado
--%>    <table>
        <tr>
            <th></th>
            <th>
                Codigo
            </th>
            <th>
                CodigoEspacio
            </th>
             
             <th>
                Dia
            </th>
            <th>
                CantidadHoras
            </th>
            <th>
                FechaInicio
            </th>
            <th>
                FechaFin
            </th>
            <th>
                Estado
            </th>
            
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Cancelar", "Cancelar", new { id=item.Codigo})%> |
       <%--         <%: Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ })%> |
                <%: Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ })%>--%>
            </td>
            <td>
                <%: item.Codigo%>
            </td>
            <td>
                <%: item.CodigoEspacio %>
            </td>
            <td>
                <%: item.Dia %>
            </td>
            <td>
                <%: item.CantidadHoras %>
            </td>
           
            <td>
                <%: item.FechaInicio %>
            </td>
            <td>
                <%: item.FechaFin %>
            </td>
           
            <td>
                <%: item.Estado %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Cancelar", "Cancelar") %>
    </p>

</asp:Content>

