<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeWebForm.aspx.cs" Inherits="EmployeeWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="Table1" runat="server" Width="40%">
            <asp:TableRow>
                <asp:TableCell>
                    ID
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lbId" runat="server" Text="0"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    Lastname
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtLastname" runat="server"></asp:TextBox> 
                    <asp:Label ID="errorLastname" runat="server" Text=""></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    Firstname
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtFirstname" runat="server"></asp:TextBox>
                    <asp:Label ID="errorFirstname" runat="server" Text=""></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    Title
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cbTitle" runat="server"></asp:DropDownList>
                    <asp:Label ID="errorTitle" runat="server" Text=""></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    Title of courtesy
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem ID="rbMr" runat="server" Text="Mr." Selected="True"></asp:ListItem>
                        <asp:ListItem ID="rbMs" runat="server" Text="Ms."></asp:ListItem>
                        <asp:ListItem ID="rbDr" runat="server" Text="Dr."></asp:ListItem>
                        <asp:ListItem ID="rbMrs" runat="server" Text="Mrs."></asp:ListItem>
                    </asp:RadioButtonList>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    Birthdate
                </asp:TableCell>
                <asp:TableCell>
                    Day <asp:DropDownList ID="cbDay" runat="server"></asp:DropDownList> 
                    Month <asp:DropDownList ID="cbMonth" runat="server"></asp:DropDownList> 
                    Year <asp:DropDownList ID="cbYear" runat="server"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    Hiredate
                </asp:TableCell>
                <asp:TableCell>
                    Day <asp:DropDownList ID="cbDay1" runat="server"></asp:DropDownList> 
                    Month <asp:DropDownList ID="cbMonth1" runat="server"></asp:DropDownList> 
                    Year <asp:DropDownList ID="cbYear1" runat="server"></asp:DropDownList>
                    <asp:Label ID="errorDate" runat="server" Text=""></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    Address
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAddress" runat="server" Rows="10" Columns="50"></asp:TextBox>
                    <asp:Label ID="errorAddress" runat="server" Text=""></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    City
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cbCity" runat="server"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    Region
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cbRegion" runat="server"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    Postal Code
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtPostalCode" runat="server"></asp:TextBox>
                    <asp:Label ID="errorPostalCode" runat="server" Text=""></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    Country
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cbCountry" runat="server"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    Phone
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                    <asp:Label ID="errorPhone" runat="server" Text=""></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    Manager
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cbManager" runat="server"></asp:DropDownList>
                    <asp:Label ID="errorManager" runat="server" Text=""></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />

        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" /> 
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" /> 
        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" /> 
        <asp:Button ID="btnNew" runat="server" Text="New" OnClick="btnNew_Click"/>
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />

        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
