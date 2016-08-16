using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EmployeeWebForm : System.Web.UI.Page
{
    TSQLFundamentals2008Entities entity;

    protected void Page_Load(object sender, EventArgs e)
    {
        date();
        loadData();
    }

    void loadData()
    {
        entity = new TSQLFundamentals2008Entities();
        List<Employee> list = entity.Employees.ToList();
        // Table

        GridView1.DataSource = list;
        GridView1.DataBind();

        // Title
        cbTitle.DataSource = list.Select(x => x.title).Distinct();
        cbTitle.DataBind();

        // City
        cbCity.DataSource = list.Select(x => x.city).Distinct();
        cbCity.DataBind();

        // Region
        cbRegion.Items.Clear();
        foreach (Employee emp in list)
        {
            if (!string.IsNullOrEmpty(emp.region)) cbRegion.Items.Add(new ListItem(emp.region));
        }
        cbRegion.Items.Insert(0, new ListItem("Choose a region"));

        // Country
        cbCountry.DataSource = list.Select(x => x.country).Distinct();
        cbCountry.DataBind();

        // Manager
        cbManager.DataSource = list;
        cbManager.DataTextField = "lastname";
        cbManager.DataValueField = "empid";
        cbManager.DataBind();
    }

    void date()
    {
        for (int i = 1; i <= 31; i++)
        {
            cbDay.Items.Add(i.ToString());
            cbDay1.Items.Add(i.ToString());
        }
        for (int i = 1; i <= 12; i++)
        {
            cbMonth.Items.Add(i.ToString());
            cbMonth1.Items.Add(i.ToString());
        }
        for (int i = 1500; i <= 2020; i++)
        {
            cbYear.Items.Add(i.ToString());
            cbYear1.Items.Add(i.ToString());
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow r = GridView1.SelectedRow;
        lbId.Text = r.Cells[1].Text;
        txtLastname.Text = r.Cells[2].Text;
        txtFirstname.Text = r.Cells[3].Text;
        cbTitle.Text = r.Cells[4].Text;

        string cortesy = r.Cells[5].Text;
        if (rbMr.Text.Equals(cortesy)) rbMr.Selected = true;
        else if (rbMs.Text.Equals(cortesy)) rbMs.Selected = true;
        else if (rbDr.Text.Equals(cortesy)) rbDr.Selected = true;
        else rbMrs.Selected = true;

        string date = DateTime.Parse(r.Cells[6].Text).ToShortDateString();
        string[] tmp = date.Split('/');
        cbMonth.Text = tmp[0];
        cbDay.Text = tmp[1];
        cbYear.Text = tmp[2];

        date = DateTime.Parse(r.Cells[7].Text).ToShortDateString();
        tmp = date.Split('/');
        cbMonth1.Text = tmp[0];
        cbDay1.Text = tmp[1];
        cbYear1.Text = tmp[2];

        txtAddress.Text = r.Cells[8].Text;
        cbCity.Text = r.Cells[9].Text;
        if (string.IsNullOrEmpty(r.Cells[10].Text) || r.Cells[10].Text.StartsWith("&"))
        {
            cbRegion.SelectedIndex = 0;
        }
        else
        {
            cbRegion.Text = r.Cells[10].Text;
        }

        txtPostalCode.Text = string.IsNullOrEmpty(r.Cells[11].Text) ? "" : r.Cells[11].Text;
        cbCountry.Text = r.Cells[12].Text;
        txtPhone.Text = r.Cells[13].Text;
        cbManager.Text = r.Cells[14].Text;
    }
}