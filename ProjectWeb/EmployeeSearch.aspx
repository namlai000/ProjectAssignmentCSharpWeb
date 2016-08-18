<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeSearch.aspx.cs" Inherits="EmployeeSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <a href="EmployeeWebForm.aspx">Back to employee management system</a>
        <br />
        Search by last name:  <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox> <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
        <br />
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </div>
    </form>
</body>
</html>
