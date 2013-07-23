<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="EGNALMaintain.Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="FuPath" runat="server" />
            <asp:Button ID="BtnUplod" runat="server" Text="Upload" OnClick="BtnUplod_Click" OnClientClick="onupload();"/>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Excel Sheet名默认为Sheet1，上传文件大小应小于10M。"></asp:Label>
            <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
    </form>
</body>
<script lang="javascript">
    function onupload()
    {
        document.getElementById("Label1").innerHTML = "导入数据进行中 ... ";
    }
</script>
</html>
