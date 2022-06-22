<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PáginaDeInicio.aspx.cs" Inherits="Rodrigofy.PáginaDeInicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Página de inicio</title>
</head>
<body style="height: 399px">
    <form id="form1" runat="server">
        <div style="height: 382px; background-color: #996600;">
            <asp:GridView ID="GrdTopCanciones" runat="server" BackColor="#999966" BorderStyle="Double" style="z-index: 1; left: 281px; top: 180px; position: absolute; height: 133px; width: 187px">
            </asp:GridView>
            <asp:Label ID="LblBienvenido" runat="server" BackColor="#999966" Font-Size="XX-Large" style="z-index: 1; left: 210px; top: 68px; position: absolute" Text="Bienvenido"></asp:Label>
            <asp:Label ID="LblTop" runat="server" BackColor="#999966" style="z-index: 1; left: 303px; top: 153px; position: absolute" Text="El top 3 de canciones es:"></asp:Label>
            <asp:HyperLink ID="HyperLink1" runat="server" BackColor="#FFFFCC" NavigateUrl="~/HistóricoDeCompras.aspx" style="z-index: 1; left: 117px; top: 174px; position: absolute">Historial</asp:HyperLink>
            <asp:HyperLink ID="HyperLink2" runat="server" BackColor="#FFFFCC" NavigateUrl="~/BúsquedaCompra.aspx" style="z-index: 1; left: 562px; top: 177px; position: absolute">Búsqueda/Compra</asp:HyperLink>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="z-index: 1; left: 658px; top: 291px; position: absolute" Text="Cerrar sesión" />
        </div>
    </form>
</body>
</html>
