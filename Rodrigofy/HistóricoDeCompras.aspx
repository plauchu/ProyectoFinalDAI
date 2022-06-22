<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HistóricoDeCompras.aspx.cs" Inherits="Rodrigofy.HistóricoDeCompras" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 432px; background-color: #339966;">
            <br />
            <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" SelectedDate="10/28/2019 23:26:17" ShowGridLines="True" style="z-index: 1; left: 49px; top: 66px; position: absolute; height: 65px; width: 65px" Width="220px">
                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                <OtherMonthDayStyle ForeColor="#CC9966" />
                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                <SelectorStyle BackColor="#FFCC66" />
                <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
            </asp:Calendar>
            <asp:Calendar ID="Calendar2" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" SelectedDate="10/28/2019 23:27:10" ShowGridLines="True" style="z-index: 1; left: 210px; top: 67px; position: absolute; height: 123px; width: 72px">
                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                <OtherMonthDayStyle ForeColor="#CC9966" />
                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                <SelectorStyle BackColor="#FFCC66" />
                <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
            </asp:Calendar>
            <asp:Label ID="Label1" runat="server" BackColor="#999966" style="z-index: 1; left: 48px; top: 44px; position: absolute; height: 18px; width: 42px;" Text="Desde:"></asp:Label>
            <asp:Label ID="Label2" runat="server" BackColor="#999966" style="z-index: 1; left: 212px; top: 45px; position: absolute" Text="Hasta:"></asp:Label>
            <asp:GridView ID="GrdCompras" runat="server" BackColor="#FFFFCC" style="z-index: 1; left: 511px; top: 86px; position: absolute; height: 133px; width: 187px">
            </asp:GridView>
            <asp:Label ID="lblCompras" runat="server" BackColor="#999966" style="z-index: 1; left: 509px; top: 57px; position: absolute" Text="Compras:"></asp:Label>
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/PáginaDeInicio.aspx" style="z-index: 1; left: 25px; top: 292px; position: absolute; right: 693px">Página de inicio</asp:HyperLink>
            <asp:Button ID="Button1" runat="server" BackColor="#FFFFCC" OnClick="Button1_Click" style="z-index: 1; left: 520px; top: 252px; position: absolute" Text="Consultar" />
            <asp:Button ID="BtnCerrar" runat="server" OnClick="BtnCerrar_Click" style="z-index: 1; left: 224px; top: 295px; position: absolute" Text="Cerrar sesión" />
        </div>
    </form>
</body>
</html>
