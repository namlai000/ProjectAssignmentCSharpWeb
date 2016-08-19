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
            LoadCategories();
        }

    }

    void InsertCategories()
    {

        TSQLFundamentals2008Entities Entity = new TSQLFundamentals2008Entities();
        Category cat = new Category();
        cat.categoryid = int.Parse(lblID.Text);
        cat.categoryname = txtName.Text;
        cat.description = lblID.Text;
        Entity.Categories.Add(cat);
        Entity.SaveChanges();
        LoadCategories();


    }
    void UpdateCategories()
    {
        GridViewRow r = gvSupplier.SelectedRow;
        Category cat = Entity.Categories.Find(int.Parse(lblID.Text));

        cat.categoryname = txtName.Text;
        cat.description = txtDescription.Text;
        Entity.SaveChanges();
        
    }
    private void LoadCategories()
    {

        gvSupplier.DataSource = Entity.Categories.ToList();
        gvSupplier.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        InsertCategories();
        LoadCategories();

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
        txtDescription.Text = "" + Server.HtmlDecode(r.Cells[3].Text);
        
    }
    protected void txtFullname_TextChanged(object sender, EventArgs e)
    {

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        UpdateCategories();
        LoadCategories();
    }
    protected void gvEmployees_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {

        GridViewRow r = gvSupplier.SelectedRow;
        Category cat = Entity.Categories.Find(int.Parse(lblID.Text));
        try
        {


            Entity.Categories.Remove(cat);

            Entity.SaveChanges();
        }
        catch (Exception)
        {
            //  message.Show("Please delete the corresponding Product first!");

            Entity.Categories.Add(cat);
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtName.Text = "";
        txtDescription.Text = "";
        lblID.Text = "";
        LoadCategories();
        btnDelete.Enabled = false;
        btnUpdate.Enabled = false;
        btnAdd.Enabled = true;
    }
    
    protected void btnDelete_Click1(object sender, EventArgs e)
    {

        GridViewRow r = gvSupplier.SelectedRow;
        Category cat = Entity.Categories.Find(int.Parse(lblID.Text));
        try
        {


            Entity.Categories.Remove(cat);

            Entity.SaveChanges();
            LoadCategories();
        }
        catch (Exception)
        {
            string msgScript = "Please delete the corresponding product first!";
            lblMsg.Text = msgScript;

            Entity.Categories.Add(cat);
        }
    }
}
