using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductWeb : System.Web.UI.Page
{
    TSQLFundamentals2008Entities Entity = new TSQLFundamentals2008Entities();
    protected void Page_Load(object sender, EventArgs e)
    {
      
        cbSupplier.DataSource=Entity.Suppliers.ToList();
        
        cbSupplier.DataValueField = "supplierid";
        cbSupplier.DataTextField = "companyname";
        cbSupplier.DataBind();
        cbCategory.DataSource = Entity.Categories.ToList();
      
        cbCategory.DataValueField = "categoryid";
        cbCategory.DataTextField = "categoryname";
        cbCategory.DataBind();
        loadData();
    }
    void loadData()
    {
        GridView1.DataSource = Entity.Products.ToList();
        GridView1.DataBind();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow r = GridView1.SelectedRow;
        lbID.Text = r.Cells[1].Text;
        txtName.Text = r.Cells[2].Text;
        cbSupplier.Text = r.Cells[3].Text;
        cbCategory.Text = r.Cells[4].Text;
        txtPrice.Text = r.Cells[5].Text;
        CheckBox check = r.Cells[6].Controls[0] as CheckBox;
        if (check.Checked==true)
        {
            chkDiscon.Checked = true;
        } 
        else
            chkDiscon.Checked = false;
    }
    void add()
    {
        Product p = new Product();
        p.productname = txtName.Text;
        int supplierid = int.Parse(cbSupplier.SelectedValue.ToString());
        p.supplierid = supplierid;
        p.categoryid = int.Parse(cbCategory.SelectedValue.ToString());
        p.unitprice = decimal.Parse(txtPrice.Text);
        if (chkDiscon.Checked)
        {
            p.discontinued = true;
        }
        else p.discontinued = false;
        Entity.Products.Add(p);
        Entity.SaveChanges();
        
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        add();
        loadData();
    }
    void update()
    {
        int id = int.Parse(lbID.Text);
        Product pro = Entity.Products.First(Product => Product.productid == id);
        pro.productname = txtName.Text;
        pro.supplierid = int.Parse(cbSupplier.SelectedValue.ToString());
        pro.categoryid = int.Parse(cbCategory.SelectedValue.ToString());
        pro.unitprice = decimal.Parse(txtPrice.Text);
        if (chkDiscon.Checked)
        {
            pro.discontinued = true;
        } pro.discontinued = false;
        Entity.SaveChanges();
        loadData();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        update();
        
    }
    void delete(int id)
    {
        Product p = Entity.Products.First(Product => Product.productid == id);
        Entity.Products.Remove(p);
        Entity.SaveChanges();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int id = int.Parse(lbID.Text);
            delete(id);
            loadData();
        }
        catch(Exception ex)
        {
            Response.Write("<script>alert(" + ex.Message + ")</script>");
        }
       
    }
    protected void btnFresh_Click(object sender, EventArgs e)
    {
        txtName.Text = "";
        txtPrice.Text = "";
        lbID.Text = "ID";
        cbSupplier.ClearSelection();
        cbCategory.ClearSelection();
        if (chkDiscon.Checked == true)
        {
            chkDiscon.Checked = false;
        }
    }
}