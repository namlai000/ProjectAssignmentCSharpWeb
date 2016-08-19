using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class FrmOrders : System.Web.UI.Page
{
    TSQLFundamentals2008Entities entity = new TSQLFundamentals2008Entities();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            loadData();
        }
        btnRemove.Enabled = false;
        btnUpdate.Enabled = false;
        //Orderdate.Enabled = false;
        //Sdate.Enabled = false;
        //Reqdate.Enabled = false;
    }
    void loadTable()
    {
        
        gvOrders.DataSource = entity.Orders.ToList();
        gvOrders.DataBind();
    }
    void loadData()
    {
        loadTable();
        List<String> l = getCountryList();
        cbCountry.DataSource = l;
        cbCountry.DataBind();


        cbCustID.DataSource = entity.Database.SqlQuery<cust>("Select custid As id, contactname As name From Sales.Customers").ToList();
        cbCustID.DataTextField = "name";
        cbCustID.DataValueField = "id";
        cbCustID.DataBind();

        cbEmpID.DataSource = entity.Database.SqlQuery<emp>("Select empid As id, (firstname + ' .' +lastname) As name From HR.Employees").ToList();
        cbEmpID.DataTextField= "name";
        cbEmpID.DataValueField = "id";
        cbEmpID.DataBind();

        cbShipperID.DataSource = entity.Shippers.ToList();
        cbShipperID.DataTextField = "shipperid";
        cbShipperID.DataBind();
    }
    
    public static List<String> getCountryList()
    {
        List<String> clist = new List<String>();
        CultureInfo[] getinfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
        foreach (CultureInfo ci in getinfo)
        {
            RegionInfo getRInfo = new RegionInfo(ci.LCID);
            if (!(clist.Contains(getRInfo.EnglishName)))
            {
                clist.Add(getRInfo.EnglishName);
            }
        }
        clist.Sort();
        return clist;
    }
    class cust
    {
        String name;
        public cust() { }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

    }
    class emp
    {
        String name;
        public emp() { }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
    protected void gvOrders_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnAdd.Enabled = false;
        btnRemove.Enabled = true;
        btnUpdate.Enabled = true;
            DateTime dt;
            GridViewRow r = gvOrders.SelectedRow;
            lbID.Text = r.Cells[1].Text;
            cbCustID.Text = r.Cells[2].Text;
            cbEmpID.Text = r.Cells[3].Text;
            //DateTime.TryParse(r.Cells[4].Text, out dt);
            Orderdate.Text = r.Cells[4].Text;
            //DateTime.TryParse(r.Cells[5].Text, out dt);
            Reqdate.Text = r.Cells[5].Text;
            //DateTime.TryParse(r.Cells[6].Text, out dt);
            Sdate.Text = r.Cells[6].Text;
            cbShipperID.Text = r.Cells[7].Text;
            txtFreight.Text = r.Cells[8].Text;
            txtShipName.Text = r.Cells[9].Text;
            txtAddress.Text = Server.HtmlDecode(r.Cells[10].Text);
            txtCity.Text = Server.HtmlDecode(r.Cells[11].Text);
            txtRegion.Text = Server.HtmlDecode(r.Cells[12].Text);
            txtPostalCode.Text = r.Cells[13].Text;
            cbCountry.Text = r.Cells[14].Text;
            
    }
    Boolean validateInput()
    {
        if (RequiredFieldValidator1.IsValid == false || RequiredFieldValidator2.IsValid == false || RequiredFieldValidator4.IsValid == false || RequiredFieldValidator6.IsValid==false)
        {
            return false;
        }
        return true;
    }
    void reset()
    {
        lbID.Text = "ID";
        cbCustID.SelectedIndex = 0;
        cbEmpID.SelectedIndex = 0;
        cbShipperID.SelectedIndex = 0;
        txtAddress.Text = "";
        txtCity.Text = "";
        txtFreight.Text = "";
        txtPostalCode.Text = "";
        txtRegion.Text = "";
        txtShipName.Text = "";
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        btnAdd.Enabled = true;
        btnRemove.Enabled = false;
        btnUpdate.Enabled = false;
        lbID.Text = "ID";
        cbCustID.SelectedIndex = 0;
        cbEmpID.SelectedIndex = 0;
        cbShipperID.SelectedIndex = 0;
        txtAddress.Text = "";
        txtCity.Text = "";
        txtFreight.Text = "";
        txtPostalCode.Text = "";
        txtRegion.Text = "";
        txtShipName.Text = "";
        
    }
    void AddNewOrder()
    {
        Order order = new Order();
        order.custid = int.Parse(cbCustID.Text);
        order.empid = int.Parse(cbEmpID.Text);
        order.freight = decimal.Parse(txtFreight.Text);
        order.orderdate = DateTime.Parse(Orderdate.Text);
        order.requireddate = DateTime.Parse(Reqdate.Text);
        if (Sdate.Text.Trim().Equals("")) 
        {
            order.shippeddate = null;
        }
        else order.shippeddate = DateTime.Parse(Sdate.Text);
        order.shipperid = int.Parse(cbShipperID.Text);
        order.shipcity = txtCity.Text;
        if (!string.IsNullOrEmpty(txtRegion.Text)) order.shipregion = txtRegion.Text;
        else order.shipregion = null;
        order.shipcountry = cbCountry.Text;
        order.shipname = txtShipName.Text;
        order.shipaddress = txtAddress.Text;
        order.shippostalcode = txtPostalCode.Text;
        entity.Orders.Add(order);
        entity.SaveChanges();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (validateInput() == false)
        {
            return;
        }
        else
        {
            AddNewOrder();
            loadTable();
            reset();
            Response.Write("<SCRIPT>alert('Added successfully')</SCRIPT>");
        }
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow r = gvOrders.SelectedRow;
            if (gvOrders.Rows.Count > 0)
            {
                Order order = null;
                foreach (Order o in entity.Orders)
                {
                    if (o.orderid.ToString().Equals(r.Cells[1].Text))
                    {
                        order = o;
                    }
                }
                entity.Orders.Remove(order);
                entity.SaveChanges();
            }
            loadTable();
            Response.Write("<SCRIPT>alert('Order Removed')</SCRIPT>");
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Cannot Delete this order since its still being used')</script>");
            reset();
        }
        
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (validateInput() == false)
        {
            return;
        }
        else
        {
            UpdateOrder();
            loadTable();
            Response.Write("<SCRIPT>alert('Order updated')</SCRIPT>");
        }
    }
    void UpdateOrder()
    {
        GridViewRow r = gvOrders.SelectedRow;
        Order order = null;
        foreach (Order o in entity.Orders)
        {
            if (o.orderid.ToString().Equals(r.Cells[1].Text))
            {
                order = o;
            }
        }
        order.custid = int.Parse(cbCustID.SelectedValue);
        order.empid = int.Parse(cbEmpID.SelectedValue);
        order.freight = decimal.Parse(txtFreight.Text);
        order.orderdate = DateTime.Parse(Orderdate.Text);
        order.requireddate = DateTime.Parse(Reqdate.Text);
        if (Sdate.Text.Trim().Equals(""))
        {
            order.shippeddate = null;
        }
        else order.shippeddate = DateTime.Parse(Sdate.Text);
        order.shipperid = int.Parse(cbShipperID.Text);
        order.shipcity = txtCity.Text;
        order.shipregion = txtRegion.Text;
        order.shipcountry = cbCountry.Text;
        order.shipname = txtShipName.Text;
        order.shipaddress = txtAddress.Text;
        order.shippostalcode = txtPostalCode.Text;
        entity.SaveChanges();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        
            //IEnumerable<Order> list = new List<Order>();
            //int id;
            //bool p2 = int.TryParse(txtSearchValue.Text, out id);
            //if (p2)
            //{
            //    list = entity.Orders.Select(u => u).Where(u => u.orderid.ToString().Contains(id.ToString()));
            //}
            //gvOrders.DataSource = list.ToList();
            //gvOrders.DataBind();
            //ViewState["bSearchMode"] = true;
        gvOrders.DataSource = entity.Orders.SqlQuery("Select * From Sales.Orders Where STR(orderid) LIKE @p0", "%" + txtSearchValue.Text + "%").ToList();
        gvOrders.DataBind();
    }
}