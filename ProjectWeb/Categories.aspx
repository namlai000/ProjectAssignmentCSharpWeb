﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Categories.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <%--    <SCRIPT LANGUAGE="JavaScript" SRC="http://www.mattkruse.com/javascript/calendarpopup/combined-compact/CalendarPopup.js"></SCRIPT>
--%><%-- <script language="JavaScript" src="js/CalendarPopup.js"></script>

    <script language="JavaScript">
        var cal = new CalendarPopup();
    </script>--%>

    <style type="text/css">
        .auto-style2 {
            width: 20%;
        }
        </style>

    </head>
<body>
    <form id="form1" name="form1" runat="server">
    <div>
        <table width="100%">
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    ID:
                </td>
                <td>
                    <asp:Label ID="lblID" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    Categories name:</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" 
                        ontextchanged="txtFullname_TextChanged" MaxLength="40"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFullname"
                        ErrorMessage="required field." SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="This field is required." ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    Categories description:</td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" MaxLength="30" Height="113px"></asp:TextBox>
                    <%-- <a href="#" onclick="cal.select(document.forms['form1'].txtDateOfBirth,'anchor1','dd/MM/yyyy'); return false;"
                        name="anchor1" id="anchor1">select</a>--%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescription" ErrorMessage="This field is required." ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>c =
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnReset" runat="server" Text="Reset" Width="65px" OnClick="btnReset_Click" />
                    <asp:Button ID="btnAdd" runat="server" Text="Add" Width="63px" 
                        onclick="btnSave_Click" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" Width="68px" 
                        onclick="btnUpdate_Click" Enabled="False" />
                    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click1" Text="Button" />
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>               
                </td>
            </tr>
            
            
        </table>
        
        <br />
        <asp:GridView ID="gvSupplier" runat="server" 
            onselectedindexchanged="gvEmployees_SelectedIndexChanged1" 
            onpageindexchanging="gvEmployees_PageIndexChanging">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <SelectedRowStyle BorderStyle="Solid" />
        </asp:GridView>
    </div>
   
   
   
   
   
   
   
   
    <%--<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    --<asp:TextBox ID="txtMode" runat="server" Visible="False" Text="true"></asp:TextBox>
    <br />
    <asp:Panel ID="pnlSearch" runat="server">
        <table>
            <tr>
                <td>
                    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                </td>
                <td>
                    <asp:Button ID="btnShowAll" runat="server" Text="Show all" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:GridView ID="gvEmployees" runat="server" AutoGenerateSelectButton="True" AllowPaging="True"
        OnPageIndexChanging="gvEmployee_PageIndexChanging" OnSelectedIndexChanged="gvEmployees_SelectedIndexChanged">
    </asp:GridView>--%><%--<asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" 
        DataSourceID="SqlDataSource1">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="FullName" HeaderText="FullName" 
                SortExpression="FullName" />
            <asp:BoundField DataField="DateOfBirth" HeaderText="DateOfBirth" 
                SortExpression="DateOfBirth" />
            <asp:BoundField DataField="Gender" HeaderText="Gender" 
                SortExpression="Gender" />
            <asp:BoundField DataField="National" HeaderText="National" 
                SortExpression="National" />
            <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
            <asp:BoundField DataField="Address" HeaderText="Address" 
                SortExpression="Address" />
            <asp:BoundField DataField="Qualification" HeaderText="Qualification" 
                SortExpression="Qualification" />
            <asp:BoundField DataField="Salary" HeaderText="Salary" 
                SortExpression="Salary" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
        ConnectionString="<%$ ConnectionStrings:SE0864ConnectionString %>" 
        DeleteCommand="DELETE FROM [Employees] WHERE [ID] = @ID" 
        InsertCommand="INSERT INTO [Employees] ([FullName], [DateOfBirth], [Gender], [National], [Phone], [Address], [Qualification], [Salary]) VALUES (@FullName, @DateOfBirth, @Gender, @National, @Phone, @Address, @Qualification, @Salary)" 
        SelectCommand="SELECT * FROM [Employees]" 
        UpdateCommand="UPDATE [Employees] SET [FullName] = @FullName, [DateOfBirth] = @DateOfBirth, [Gender] = @Gender, [National] = @National, [Phone] = @Phone, [Address] = @Address, [Qualification] = @Qualification, [Salary] = @Salary WHERE [ID] = @ID">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="FullName" Type="String" />
            <asp:Parameter Name="DateOfBirth" Type="DateTime" />
            <asp:Parameter Name="Gender" Type="String" />
            <asp:Parameter Name="National" Type="String" />
            <asp:Parameter Name="Phone" Type="String" />
            <asp:Parameter Name="Address" Type="String" />
            <asp:Parameter Name="Qualification" Type="String" />
            <asp:Parameter Name="Salary" Type="Decimal" />
            <asp:Parameter Name="ID" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:ControlParameter ControlID="txtFullname" DbType="String" 
             Name="FullName" />
             <asp:ControlParameter ControlID="txtDateOfBirth" DbType="DateTime" 
             Name="FullName" />
            
            
            
        </InsertParameters>
    </asp:SqlDataSource>--%>
    </form>
</body>
</html>
