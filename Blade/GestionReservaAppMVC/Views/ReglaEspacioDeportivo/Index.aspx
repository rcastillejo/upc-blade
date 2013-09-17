<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<GestionReservaAppMVC.Models.ReglaEspacioDeportivo>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Reglas de Espacios Deportivos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Reglas Espacios Deportivos</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Codigo
            </th>
            <th>
                Nombre
            </th>
            <th>
                Sede
            </th>
            <th>
                Mínimo anticipación de reserva(Minutos)
            </th>
            <th>
                Máximo anticipación de reserva(Días)
            </th>
            <th>
                Máximo anticipación para cancelar(Horas)
            </th>
            <th>
                Máximo horas para reservar por día
            </th>
            <th>
                Máximo horas reservar semanal
            </th>
            <th>
                Máximo número usuario simultaneo
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Editar", "Edit", new {  id=item.EspacioDeportivo.Codigo }) %> |
                <%: Html.ActionLink("Detalles", "Details", new { id = item.EspacioDeportivo.Codigo })%>
            </td>
            <td>
                <%: item.EspacioDeportivo.Codigo%>
            </td>
            <td>
                <%: item.EspacioDeportivo.Nombre%>
            </td>
            <td>                
                <%: item.EspacioDeportivo.Sede.Codigo%> - <%: item.EspacioDeportivo.Sede.Nombre%>
            </td>
            <td>                
                <%: item.MinAnticipacionReservarMinuto%>
            </td>
            <td>                
                <%: item.MaxAnticipacionReservaDia%>
            </td>
            <td>                
                <%: item.MinAnticipacionCancelarHora%>
            </td>
            <td>                
                <%: item.MaxHoraReservaDia%>
            </td>
            <td>                
                <%: item.MaxHoraReservaSemana%>
            </td>
            <td>                
                <%: item.MaxNumUsuario%>
            </td>
        </tr>
    
    <% } %>

    </table>
    
    <p>
        <%: Session["Mensaje"]%>
    </p>
</asp:Content>

