<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BúsquedaCompra.aspx.cs" Inherits="Rodrigofy.BúsquedaCompra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            height: 413px;
            width: 889px;
        }
        .auto-style4 {
            z-index: 1;
            left: 570px;
            top: 181px;
            position: absolute;
            height: 153px;
            width: 190px;
        }
    </style>
</head>
<body style="height: 430px; width: 887px;">
    <form id="form1" runat="server">
            
        <div style="background-color: #FF6666; height: 399px; z-index: 1; left: 11px; top: 16px; position: absolute; width: 890px;">
            <br />
            <asp:TextBox ID="txtNomCan" runat="server" style="z-index: 1; left: 135px; top: 57px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtNomArt" runat="server" style="z-index: 1; left: 135px; top: 130px; position: absolute"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" BackColor="#999966" style="z-index: 1; left: 14px; top: 59px; position: absolute" Text="Nombre canción:"></asp:Label>
            <asp:Label ID="Label2" runat="server" BackColor="#999966" style="z-index: 1; left: 14px; top: 131px; position: absolute" Text="Nombre artísta:"></asp:Label>
            <asp:Label ID="lblRes" runat="server" BackColor="#999966" BorderColor="#999966" style="z-index: 1; left: 604px; top: 20px; position: absolute" Text="Resultados:" Visible="False"></asp:Label>
            <asp:Button ID="btnAgregar" runat="server" style="z-index: 1; left: 273px; top: 192px; position: absolute" Text="Agregar al carrito" OnClick="btnAgregar_Click" />
            <asp:Label ID="lblStatus" runat="server" BackColor="#999966" style="z-index: 1; left: 369px; top: 110px; position: absolute" Text="Status:"></asp:Label>
            <asp:GridView ID="GrdCanciones" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" Caption="Carrito" CellPadding="2" CssClass="auto-style4" Enabled="False" ForeColor="Black" OnRowDeleting="GrdAvalan_RowDeleting">
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
                <EditRowStyle BackColor="#669999" />
                <FooterStyle BackColor="Tan" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <SortedAscendingCellStyle BackColor="#FAFAE7" />
                <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                <SortedDescendingCellStyle BackColor="#E1DB9C" />
                <SortedDescendingHeaderStyle BackColor="#C2A47B" />
            </asp:GridView>
            <asp:Button ID="btnCarrito" runat="server" OnClick="btnCarrito_Click" style="z-index: 1; left: 43px; top: 212px; position: absolute; width: 189px" Text="Ver carrito/Actualizar carrito" />
            <asp:GridView ID="GrdBúsqueda" runat="server" style="z-index: 1; left: 598px; top: 47px; position: absolute; height: 133px; width: 187px; background-color: #FFFFCC">
            </asp:GridView>
            <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" style="z-index: 1; left: 362px; top: 59px; position: absolute; bottom: 314px" Text="Buscar" />
            <asp:Label ID="lblCarrito" runat="server" style="z-index: 1; left: 125px; top: 285px; position: absolute; background-color: #999966" Text="Estado del carrito:" Visible="False"></asp:Label>
            <asp:Button ID="btnBorrar" runat="server" style="z-index: 1; left: 276px; top: 229px; position: absolute" Text="Borrar del carrito" OnClick="btnBorrar_Click" />
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Pagos.aspx" style="z-index: 1; top: 327px; position: absolute; right: 617px">Ir a página de pagos</asp:HyperLink>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/PáginaDeInicio.aspx" style="z-index: 1; left: 8px; top: 328px; position: absolute; right: 710px">Página de inicio</asp:HyperLink>
           
            <asp:Button ID="BtnCerrar" runat="server" OnClick="BtnCerrar_Click" style="z-index: 1; left: 746px; top: 15px; position: absolute" Text="Cerrar sesión" />
        </div>
    </form>
</body>
</html>
