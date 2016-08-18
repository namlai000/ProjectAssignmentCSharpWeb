using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    //bool bMode = true;
    TSQLFundamentals2008Entities Entity = new TSQLFundamentals2008Entities();
    protected void Page_Load(object sender, EventArgs e)
    {
        // Entity.Suppliers.c
        if (this.IsPostBack == false)
        {
            LoadSupplier();
        }

    }

    void InsertSupplier()
    {

        TSQLFundamentals2008Entities Entity = new TSQLFundamentals2008Entities();
        Supplier sup = new Supplier();
        DateTime dt;
        DateTime.TryParse(txtContactName.Text.ToString(), out dt);
        sup.address = txtAddress.Text;
        sup.city = txtCity.Text;
        sup.companyname = txtCity.Text;
        sup.contactname = txtContactName.Text;
        sup.contacttitle = txtTitle.Text;
        sup.country = txtTitle.Text;
        sup.fax = txtFax.Text;
        sup.phone = txtPhone.Text;
        sup.postalcode = txtPostalCode.Text;
        sup.region = txtRegion.Text;
        Entity.Suppliers.Add(sup);
        Entity.SaveChanges();
        LoadSupplier();


    }
    void UpdateSupplier()
    {
        GridViewRow r = gvSupplier.SelectedRow;
        Supplier sup = Entity.Suppliers.Find(int.Parse(lblID.Text));
        
        sup.address = txtAddress.Text;
        sup.city = txtCity.Text;
        sup.companyname = txtName.Text;
        sup.contactname = txtContactName.Text;
        sup.contacttitle = txtTitle.Text;
        sup.country = txtCountry.Text;
        sup.fax = txtFax.Text;
        sup.phone = txtPhone.Text;
        sup.postalcode = txtPostalCode.Text;
        sup.region = txtRegion.Text;
        Entity.SaveChanges();
        
    }
    private void LoadSupplier()
    {

        gvSupplier.DataSource = Entity.Suppliers.ToList();
        gvSupplier.DataBind();
    }




    protected void btnNew_Click1(object sender, EventArgs e)
    {
        txtName.Text = "";
        txtCity.Text = "";
        txtFax.Text = "";
        txtAddress.Text = "";
        txtContactName.Text = "";
        txtCountry.Text = "";
        txtPhone.Text = "";
        txtPostalCode.Text = "";
        txtRegion.Text = "";
        txtTitle.Text = "";
        lblID.Text = "";
        LoadSupplier();
        btnDelete.Enabled = false;
        btnUpdate.Enabled = false;
        btnAdd.Enabled = true;

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        InsertSupplier();
        LoadSupplier();

        string msgScript = "<script>alert('Adding successful');</script>";
        lblMsg.Text = msgScript;
        
        
        //Response.Redirect("");

    }
    protected void gvEmployees_SelectedIndexChanged1(object sender, EventArgs e)
    {
        GridViewRow r = gvSupplier.SelectedRow;

        ///

        btnDelete.Enabled = true;
        btnUpdate.Enabled = true;
        btnAdd.Enabled = false;

        lblID.Text = r.Cells[1].Text;
        txtName.Text = "" + Server.HtmlDecode(r.Cells[2].Text);
        txtContactName.Text = "" + Server.HtmlDecode(r.Cells[3].Text);
        txtAddress.Text = "" + Server.HtmlDecode(r.Cells[5].Text);
        txtCity.Text = "" + Server.HtmlDecode(r.Cells[6].Text);
        if (r.Cells[7].Text == null)
        {
            txtRegion.Text = " ";
        }
        else
        {
            txtRegion.Text = "" + Server.HtmlDecode(r.Cells[7].Text);
        }
        if (r.Cells[11].Text == null)
        {
            txtFax.Text = " ";
        }
        else
        {
            txtFax.Text = "" + Server.HtmlDecode(r.Cells[11].Text);
        }
        if (r.Cells[8].Text == null)
        {
            txtPostalCode.Text = " ";
        }
        else
        {
            txtPostalCode.Text = "" + Server.HtmlDecode(r.Cells[8].Text);
        }
        //txtFax.Text = r.Cells["fax"].Value.ToString();
        txtPhone.Text = "" + Server.HtmlDecode(r.Cells[10].Text);
        //txtPostalCode.Text = r.Cells["postalcode"].Value.ToString();
        //txtRegion.Text = r.Cells["region"].Value.ToString();
        txtTitle.Text = "" + Server.HtmlDecode(r.Cells[4].Text);
        txtCountry.Text = "" + Server.HtmlDecode(r.Cells[9].Text);

        //bMode = false;
        //txtMode.Text = "false";
        //ViewState["bMode"] = false;
    }
    protected void txtFullname_TextChanged(object sender, EventArgs e)
    {

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        UpdateSupplier();
        LoadSupplier();
    }
    protected void gvEmployees_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        GridViewRow r = gvSupplier.SelectedRow;
        Supplier sup = Entity.Suppliers.Find(int.Parse(lblID.Text));
        try
        {


            Entity.Suppliers.Remove(sup);

            Entity.SaveChanges();
        }
        catch (Exception)
        {
            //  message.Show("Please delete the corresponding Product first!");

            Entity.Suppliers.Add(sup);
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtName.Text = "";
        txtCity.Text = "";
        txtFax.Text = "";
        txtAddress.Text = "";
        txtContactName.Text = "";
        txtCountry.Text = "";
        txtPhone.Text = "";
        txtPostalCode.Text = "";
        txtRegion.Text = "";
        txtTitle.Text = "";
        lblID.Text = "";
        LoadSupplier();
        btnDelete.Enabled = false;
        btnUpdate.Enabled = false;
        btnAdd.Enabled = true;
    }
    
    protected void btnDelete_Click1(object sender, EventArgs e)
    {

        GridViewRow r = gvSupplier.SelectedRow;
        Supplier sup = Entity.Suppliers.Find(int.Parse(lblID.Text));
        try
        {


            Entity.Suppliers.Remove(sup);

            Entity.SaveChanges();
            LoadSupplier();
        }
        catch (Exception)
        {
            string msgScript = "Please delete the corresponding product first!";
            lblMsg.Text = msgScript;

            Entity.Suppliers.Add(sup);
        }
    }
}
