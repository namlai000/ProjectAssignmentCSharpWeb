<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmOrders.aspx.cs" Inherits="FrmOrders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <form id="form1" runat="server">
                
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    OrderID
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lbID" runat="server" Text="Label">ID</asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    Customer
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cbCustID" runat="server"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    Employee
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cbEmpID" runat="server"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    Order date
                </asp:TableCell>
                <asp:TableCell>
             <%--       <asp:Calendar ID="CalOrderDate" runat="server"></asp:Calendar>--%>
                    <asp:TextBox ID="Orderdate" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ForeColor="Red" runat="server" ErrorMessage="This field is required" ControlToValidate="Orderdate"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    Required date
                </asp:TableCell>
                <asp:TableCell>
                    <%--<asp:Calendar ID="CalReqDate" runat="server"></asp:Calendar>--%>
                    <asp:TextBox ID="Reqdate" runat="server"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ForeColor="Red" runat="server" ErrorMessage="This field is required" ControlToValidate="Reqdate"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    Shipped date
                </asp:TableCell>
                <asp:TableCell>
                    <%--<asp:Calendar ID="CalShippDate" runat="server"></asp:Calendar>--%>
                    <asp:TextBox ID="Sdate" runat="server"/>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    ShipperID
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="cbShipperID" runat="server"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    Freight
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtFreight" runat="server"></asp:TextBox> USD
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ControlToValidate="txtFreight" ErrorMessage="This field is required" Display="Dynamic"/>
                    <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Must be digit" ControlToValidate="txtFreight" ForeColor="Red" Display="Dynamic" MinimumValue="0" MaximumValue="9999"></asp:RangeValidator>
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell>
                    ShippName
                </asp:TableCell><asp:TableCell>
                    <asp:TextBox ID="txtShipName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server" ErrorMessage="This field is required" ControlToValidate="txtShipName" />
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell>
                    Ship address
                </asp:TableCell><asp:TableCell>
                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" runat="server" ErrorMessage="This field is required" ControlToValidate="txtAddress" />
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell>
                    Ship city
                </asp:TableCell><asp:TableCell>
                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" runat="server" ErrorMessage="This field is required" ControlToValidate="txtCity" />
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell>
                    Ship region
                </asp:TableCell><asp:TableCell>
                    <asp:TextBox ID="txtRegion" runat="server"></asp:TextBox>
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell>
                    Ship postal code
                </asp:TableCell><asp:TableCell>
                    <asp:TextBox ID="txtPostalCode" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic" ErrorMessage="This field is required"     ControlToValidate="txtPostalCode" ForeColor="Red"/>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" Display="Dynamic" ErrorMessage="Please enter a 5-digit number" ControlToValidate="txtPostalCode" Type="Integer" MaximumValue="99999" MinimumValue="10000" ForeColor="Red"></asp:RangeValidator>
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell>
                    ship Country
                </asp:TableCell><asp:TableCell>
                    <asp:DropDownList ID="cbCountry" runat="server"></asp:DropDownList>
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="btnRemove" runat="server" Text="Remove" OnClick="btnRemove_Click" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                </asp:TableCell><asp:TableCell>
                    <asp:Button ID="btnNew" runat="server" Text="New" OnClick="btnNew_Click" CausesValidation="false"/>
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    Search By OrerID
                </asp:TableCell></asp:TableRow>
            
        </asp:Table>
        <asp:Table ID="searchrable" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:TextBox ID="txtSearchValue" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter number" ControlToValidate="txtSearchValue" Display="Dynamic" ValidationExpression="\d+" ForeColor="Red"></asp:RegularExpressionValidator>
                </asp:TableCell><asp:TableCell>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CausesValidation="false"/>
                </asp:TableCell></asp:TableRow>
        </asp:Table>
        
        <asp:GridView ID="gvOrders" runat="server" OnSelectedIndexChanged="gvOrders_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>

