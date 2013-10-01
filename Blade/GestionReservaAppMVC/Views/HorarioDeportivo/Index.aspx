<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<GestionReservaAppMVC.GestionReservaWS.EspacioDeportivo>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Horarios Deportivos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Horarios Deportivos</h2>    
    <%: Html.ValidationSummary(true) %>
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
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Horario", "Details", new { Codigo = item.Codigo })%>
            </td>
            <td>
                <%: item.Codigo %>
            </td>
            <td>
                <%: item.Codigo %> - <%: item.Nombre %>
            </td>
            <td>
                <%: item.Sede.Codigo %> - <%: item.Sede.Nombre %>
            </td>
        </tr>
    
    <% } %>

    </table>
    <p>
     <%: Session["Mensaje"]%>
     </p>

</asp:Content>
