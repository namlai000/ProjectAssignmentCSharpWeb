﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h4>Human Resources</h4>
        - <a href="EmployeeWebForm.aspx">Employee Web Form</a><br />
        <br />

        <h4>Production</h4>
        - <a href="ProductWebs.aspx">Product Web</a><br />
        - <a href="Supplier.aspx">Supplier Web</a><br />
        - <a href="Categories.aspx">Categories Web</a><br />
        <br />

        <h4>Sales</h4>
        - <a href="OrderDetails.aspx">Order Details</a><br />
        - <a href="OrderDetails.aspx">Shippers Web</a><br />
        - <a href="FrmOrders.aspx">Orders Web</a><br />
        - <a href="FrmOrders.aspx">Customers Web</a><br />
        <br />
    </div>
    </form>
</body>
</html>
