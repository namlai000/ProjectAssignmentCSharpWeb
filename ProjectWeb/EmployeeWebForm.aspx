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
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    Firstname
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtFirstname" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    Title
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cbTitle" runat="server"></asp:DropDownList>
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
                    <asp:Calendar ID="calBirthdate" runat="server"></asp:Calendar>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    Hiredate
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Calendar ID="calHiredate" runat="server"></asp:Calendar>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    Address
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtAddress" runat="server" Rows="10" Columns="50"></asp:TextBox>
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
                    City
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cbRegion" runat="server"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    City
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtPostalCode" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    City
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
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    Manager
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="cbManager" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <asp:GridView ID="GridView1" runat="server">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
