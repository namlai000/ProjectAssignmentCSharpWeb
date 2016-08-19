using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OrderDetails : System.Web.UI.Page
{
    TSQLFundamentals2008Entities entity = new TSQLFundamentals2008Entities();
    bool addNew = false;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            loadData();
        }
    }
    void loadData()
    {
        entity = new TSQLFundamentals2008Entities();
        List<Order> list1 = entity.Orders.ToList();
        List<Product> list2 =  entity.Products.ToList();
        GridView1.DataSource = list1;
        GridView1.DataBind();

        cbOrderID.DataSource = list1.Select(x => x.orderid).Distinct();
        cbOrderID.DataBind();
        cbProductID.DataSource = list2.Select(x => x.productid).Distinct();
        cbProductID.DataBind();
    }
    void add()
    {
        OrderDetail order = new OrderDetail();
        order.orderid = int.Parse(cbOrderID.Text);
        order.productid = int.Parse(cbProductID.Text);
        order.unitprice = int.Parse(txtUnitPrice.Text);
        order.qty = short.Parse(txtQuantity.Text);
        order.discount = int.Parse(txtDiscount.Text);
        entity.OrderDetails.Add(order);
        entity.SaveChanges();
    }
    void delete()
    {
        OrderDetail order = new OrderDetail();
        entity.OrderDetails.Remove(order);
        entity.SaveChanges();
    }


    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow r = GridView1.SelectedRow;
        int id;
        int.TryParse(r.Cells[1].Text, out id);
        OrderDetail order = entity.OrderDetails.First(x => x.orderid == id);
        cbOrderID.Text = order.orderid.ToString();
        cbProductID.Text = order.productid.ToString();
        txtUnitPrice.Text = order.unitprice.ToString();
        txtQuantity.Text = order.qty.ToString();
        txtDiscount.Text = order.discount.ToString();
    }
}