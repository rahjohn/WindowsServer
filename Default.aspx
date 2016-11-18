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
        Text Top: <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox><br />
        Text Bottom: <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox><br />
        Filter: <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>Grayscale</asp:ListItem>
            <asp:ListItem>Sepia</asp:ListItem>
                </asp:DropDownList><br />
                <asp:Button ID="Button2" runat="server" Text="Save Changes" onClick="addText" /><br /><br />
   </form>
</body>
</html>