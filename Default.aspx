<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <form id="form1" runat="server">
        Image Path: <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
        Alt Text: <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
        userID: <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br />
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
        <asp:FileUpload ID="FileUpload1" runat="server" />
<asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="Upload" />
<hr />
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" ShowHeader="false">
    <Columns>
        <asp:BoundField DataField="Text" />
        <asp:ImageField DataImageUrlField="Value" ControlStyle-Height="100" ControlStyle-Width="100" />
    </Columns>
</asp:GridView>
    <div>
    
    </div>
    </form>
</body>
</html>