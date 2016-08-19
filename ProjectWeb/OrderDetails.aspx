<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderDetails.aspx.cs" Inherits="OrderDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Order ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="cbOrderID" runat="server" Height="17px" Width="127px">
        </asp:DropDownList>
        <br />
        Product ID:&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="cbProductID" runat="server" Height="20px" Width="127px">
        </asp:DropDownList>
        <br />
        Unit Price:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtUnitPrice" runat="server"></asp:TextBox>
        <br />
        Quantity:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
        <br />
        Discount:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtDiscount" runat="server"></asp:TextBox>
    
    </div>
        <asp:Button ID="btnAdd" runat="server" Text="Add" Width="60px" />
        <asp:Button ID="btnUpdate" runat="server" Text="Update" />
        <br />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="61px" />
        <asp:Button ID="btnReset" runat="server" Text="Reset" Width="60px" />
        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
