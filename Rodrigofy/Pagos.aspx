<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pagos.aspx.cs" Inherits="Rodrigofy.Pagos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 546px; width: 1108px;">
    <form id="form1" runat="server">
        <div style="height: 529px; background-color: #CC66FF; width: 1095px;">
            <asp:GridView ID="GrdCarro" runat="server" style="position: absolute; z-index: 1; left: 285px; top: 99px; height: 133px; width: 187px; background-color: #999966">
            </asp:GridView>
            <asp:Label ID="LblCarro" runat="server" style="z-index: 1; left: 286px; top: 70px; position: absolute; background-color: #666633" Text="Carrito:"></asp:Label>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/PáginaDeInicio.aspx" style="z-index: 1; left: 477px; top: 305px; position: absolute; right: 180px">Página de inicio</asp:HyperLink>
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/BúsquedaCompra.aspx" style="z-index: 1; top: 300px; position: absolute; left: 45px;">Ir a página de compra/búsqueda</asp:HyperLink>
            <asp:Button ID="BtnPagar" runat="server" PostBackUrl="~/ConfirmaciónDeCompra.aspx" style="z-index: 1; top: 149px; position: absolute; right: 212px" Text="Pagar" Visible="False" />
            <asp:Button ID="BtnConfirmar" runat="server" OnClick="BtnConfirmar_Click" style="z-index: 1; left: 84px; top: 215px; position: absolute" Text="Confirmar" />
            <asp:Label ID="lblStatus" runat="server" style="z-index: 1; left: 585px; top: 211px; position: absolute; background-color: #999966" Text="Status: en espera"></asp:Label>
            <asp:CheckBox ID="CheckBox1" runat="server" style="z-index: 1; left: 107px; top: 114px; position: absolute" Text="Confirmo contenido" />
            <asp:CheckBox ID="CheckBox2" runat="server" style="z-index: 1; left: 108px; top: 154px; position: absolute" Text="Acepto T&amp;C" />
        </div>
    </form>
</body>
</html>
