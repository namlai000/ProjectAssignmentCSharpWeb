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
    
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbID" runat="server" Text="ID"></asp:Label>
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="Name:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" Text="Supplier:"></asp:Label>
&nbsp;&nbsp;
        <asp:DropDownList ID="cbSupplier" runat="server" Height="16px" Width="125px">
        </asp:DropDownList>
        <br />
        &nbsp;&nbsp;&nbsp; Category:&nbsp;
        <asp:DropDownList ID="cbCategory" runat="server" Height="16px" Width="127px">
        </asp:DropDownList>
        <br />
&nbsp;&nbsp;&nbsp; Price:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp; Discontinued&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="chkDiscon" runat="server" />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" style="height: 26px" />
        <br />
        &nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:GridView ID="GridView1" runat="server" Height="201px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="652px">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
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
