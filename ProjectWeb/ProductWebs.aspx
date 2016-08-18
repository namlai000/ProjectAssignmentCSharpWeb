<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductWebs.aspx.cs" Inherits="ProductWeb" %>

<!DOCTYPE html>
<script runat="server">

    
</script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left: 40px">
    
        <asp:Table ID="Table1" runat="server" Height="62px" Width="422px">
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="Label1" runat="server" Text="ID"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:Label ID="lbID" runat="server" Text="ID"></asp:Label></asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell><asp:Label ID="Label3" runat="server" Text="Name:"></asp:Label></asp:TableCell>
                <asp:TableCell> <asp:TextBox ID="txtName" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell><asp:Label ID="Label4" runat="server" Text="Supplier:"></asp:Label></asp:TableCell>
                <asp:TableCell><asp:DropDownList ID="cbSupplier" runat="server" Height="16px" Width="125px"></asp:DropDownList></asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>Category:</asp:TableCell>
                <asp:TableCell> <asp:DropDownList ID="cbCategory" runat="server" Height="16px" Width="127px">
        </asp:DropDownList></asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>Price:</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="txtPrice" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell> Discontinued</asp:TableCell>
                <asp:TableCell><asp:CheckBox ID="chkDiscon" runat="server" /></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" style="height: 26px" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnFresh" runat="server" OnClick="btnFresh_Click" Text="Refresh" />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;
        
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:GridView ID="GridView1" runat="server" Height="201px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="652px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
