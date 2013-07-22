<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DtExport2Excel.aspx.cs" Inherits="ExportToExcelFromDataTable.Practice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        <asp:Button runat="server" ID="Btn_Export" Text="Export" OnClick="Btn_Export_Click" />
    </div>
    </form>
</body>
</html>
