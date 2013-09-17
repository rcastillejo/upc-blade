<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<GestionReservaAppMVC.EspacioDeportivoWS.EspacioDeportivo>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Espacios Deportivos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Espacios Deportivos</h2>

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
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Editar", "Edit", new {  id=item.Codigo }) %> |
                <%: Html.ActionLink("Detalles", "Details", new {  id=item.Codigo  })%> |
                <%: Html.ActionLink("Eliminar", "Delete", new {  id=item.Codigo })%>
            </td>
            <td>
                <%: item.Codigo %>
            </td>
            <td>
                <%: item.Nombre %>
            </td>
            <td>                
                <%: item.Sede.Codigo %> - <%: item.Sede.Nombre %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Crear Nuevo", "Create") %> <%: Session["Mensaje"]%>
    </p>

</asp:Content>

