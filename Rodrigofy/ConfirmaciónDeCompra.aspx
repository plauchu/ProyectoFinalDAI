<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmaciónDeCompra.aspx.cs" Inherits="Rodrigofy.ConfirmaciónDeCompra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 418px">
    <form id="form1" runat="server">
        <div style="background-color: #FF9933; height: 405px;">
            <asp:GridView ID="GrdResumen" runat="server" style="z-index: 1; left: 201px; top: 65px; position: absolute; height: 133px; width: 187px; background-color: #999966">
            </asp:GridView>
            <asp:Label ID="lblCarro" runat="server" style="z-index: 1; left: 205px; top: 33px; position: absolute; right: 537px; background-color: #999966" Text="Resumen de compra"></asp:Label>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/PáginaDeInicio.aspx" style="z-index: 1; left: 40px; top: 305px; position: absolute; right: 617px">Página de inicio</asp:HyperLink>
            <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" SelectedDate="2019-11-09" ShowGridLines="True" style="z-index: 1; left: 566px; top: 62px; position: absolute; height: 65px; width: 65px" Width="220px" Visible="False">
                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                <OtherMonthDayStyle ForeColor="#CC9966" />
                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                <SelectorStyle BackColor="#FFCC66" />
                <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
            </asp:Calendar>
            <asp:Label ID="LblStatus" runat="server" style="z-index: 1; left: 201px; top: 241px; position: absolute; background-color: #999966" Text="Status: "></asp:Label>
        </div>
    </form>
</body>
</html>
