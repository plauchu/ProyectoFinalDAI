<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Rodrigofy.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Rodrigofy</title>
</head>
<body style="height: 400px">
    <form id="form1" runat="server">
        <div style="height: 387px; background-color: #FFFF99;">
            <asp:Label ID="LblTítulo" runat="server" Font-Size="XX-Large" style="z-index: 1; left: 320px; top: 67px; position: absolute; height: 61px; width: 339px" Text="Bienvenidos a Rodrigofy"></asp:Label>
            <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate1" style="z-index: 1; left: 318px; top: 114px; position: absolute; height: 132px; width: 264px">
            </asp:Login>
        </div>
    </form>
</body>
</html>
