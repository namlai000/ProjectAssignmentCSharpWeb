﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Text.RegularExpressions;

public partial class EmployeeWebForm : System.Web.UI.Page
{
    TSQLFundamentals2008Entities entity = new TSQLFundamentals2008Entities();
    bool addNew = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            date();
            loadData();
            initiateButton();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
    }

    void initiateButton()
    {
        if (addNew)
        {
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        } else
        {
            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }
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
            if (!string.IsNullOrEmpty(emp.region) && !cbRegion.Items.Contains(new ListItem(emp.region))) cbRegion.Items.Add(new ListItem(emp.region));
        }
        cbRegion.Items.Insert(0, new ListItem("Choose a region"));

        // Country
        cbCountry.DataSource = getCountriesList();
        cbCountry.DataTextField = "Key";
        cbCountry.DataValueField = "Value";
        cbCountry.DataBind();

        // Manager
        cbManager.DataSource = entity.Database.SqlQuery<Emp>("SELECT empid AS id, (lastname + ' ' + firstname) AS name FROM HR.Employees").ToList();
        cbManager.DataTextField = "name";
        cbManager.DataValueField = "id";
        cbManager.DataBind();
        cbManager.Items.Insert(0, new ListItem("Choose a manager", "-1"));
    }

    SortedDictionary<string, string> getCountriesList()
    {
        SortedDictionary<string, string> cultureList = new SortedDictionary<string, string>();

        CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

        foreach (CultureInfo culture in cultures)
        {
            RegionInfo region = new RegionInfo(culture.LCID);

            if (!(cultureList.Keys.Contains(region.EnglishName)))
            {
                cultureList.Add(region.EnglishName, region.TwoLetterISORegionName);
            }
        }

        return cultureList;
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
        for (int i = 1800; i <= 2020; i++)
        {
            cbYear.Items.Add(i.ToString());
            cbYear1.Items.Add(i.ToString());
        }
    }

    void add()
    {
        Employee emp = new Employee();
        emp.lastname = txtLastname.Text;
        emp.firstname = txtFirstname.Text;
        emp.title = cbTitle.Text;
        emp.titleofcourtesy = RadioButtonList1.SelectedItem.Text;
        DateTime date = DateTime.Parse(cbMonth.Text + "/" + cbDay.Text + "/" + cbYear.Text);
        emp.birthdate = date;
        date = DateTime.Parse(cbMonth1.Text + "/" + cbDay1.Text + "/" + cbYear1.Text);
        emp.hiredate = date;
        emp.address = txtAddress.Text;
        emp.city = cbCity.Text;

        if (cbRegion.SelectedIndex != 0) emp.region = cbRegion.Text;
        else emp.region = null;

        if (!string.IsNullOrEmpty(txtPostalCode.Text)) emp.postalcode = txtPostalCode.Text;
        else emp.postalcode = null;

        emp.country = cbCountry.SelectedValue.ToString();
        emp.phone = txtPhone.Text;

        if (int.Parse(cbManager.SelectedValue) > 0) emp.mgrid = int.Parse(cbManager.SelectedValue);
        else emp.mgrid = null;

        entity.Employees.Add(emp);
        entity.SaveChanges();
        addNew = false;
    }

    void delete(int id)
    {
        Employee e = entity.Employees.First(x => x.empid == id);
        entity.Employees.Remove(e);
        entity.SaveChanges();
    }

    void update()
    {
        addNew = false;

        int id = int.Parse(lbId.Text);
        Employee emp = entity.Employees.First(x => x.empid == id);
        emp.lastname = txtLastname.Text;
        emp.firstname = txtFirstname.Text;
        emp.title = cbTitle.Text;
        emp.titleofcourtesy = RadioButtonList1.SelectedItem.Text;
        DateTime date = DateTime.Parse(cbMonth.Text + "/" + cbDay.Text + "/" + cbYear.Text);
        emp.birthdate = date;
        date = DateTime.Parse(cbMonth1.Text + "/" + cbDay1.Text + "/" + cbYear1.Text);
        emp.hiredate = date;
        emp.address = txtAddress.Text;
        emp.city = cbCity.Text;

        if (cbRegion.SelectedIndex != 0) emp.region = cbRegion.Text;
        else emp.region = null;

        if (!string.IsNullOrEmpty(txtPostalCode.Text)) emp.postalcode = txtPostalCode.Text;
        else emp.postalcode = null;

        emp.country = cbCountry.SelectedValue.ToString();
        emp.phone = txtPhone.Text;

        if (int.Parse(cbManager.SelectedValue) > 0) emp.mgrid = int.Parse(cbManager.SelectedValue);
        else emp.mgrid = null;

        entity.SaveChanges();
    }

    bool validate()
    {
        bool val = true;

        if (string.IsNullOrEmpty(txtLastname.Text)) { val = false; errorLastname.Text = "No empty allow"; } else { errorLastname.Text = string.Empty; }
        if (string.IsNullOrEmpty(txtFirstname.Text)) { val = false; errorFirstname.Text = "No empty allow"; } else { errorFirstname.Text = string.Empty; }
        int age = int.Parse(cbYear1.Text) - int.Parse(cbYear.Text);
        if (age < 18) { val = false; errorDate.Text = "Employee must older than equal 18"; } else { errorDate.Text = string.Empty; }
        if (string.IsNullOrEmpty(txtAddress.Text)) { val = false; errorAddress.Text = "No empty allow"; } else { errorAddress.Text = string.Empty; }
        if (string.IsNullOrEmpty(txtPhone.Text)) { val = false; errorPhone.Text = "No empty allow"; } else { errorPhone.Text = string.Empty; }
        if (!string.IsNullOrEmpty(txtPostalCode.Text))
        {
            if (!Regex.IsMatch(txtPostalCode.Text, "\\d+")) { val = false; errorPostalCode.Text = "Invalid postal code"; } else { errorPostalCode.Text = string.Empty; }
        } else
        {
            errorPostalCode.Text = string.Empty;
        }

        return val;
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow r = GridView1.SelectedRow;
        lbId.Text = r.Cells[1].Text;
        txtLastname.Text = r.Cells[2].Text;
        txtFirstname.Text = r.Cells[3].Text;
        cbTitle.Text = r.Cells[4].Text;

        string cortesy = r.Cells[5].Text;
        if (rbMr.Text.Equals(cortesy))
        {
            rbMr.Selected = true;
            rbMs.Selected = false;
            rbDr.Selected = false;
            rbMrs.Selected = false;
        }
        if (rbMs.Text.Equals(cortesy))
        {
            rbMr.Selected = false;
            rbMs.Selected = true;
            rbDr.Selected = false;
            rbMrs.Selected = false;
        }
        if (rbDr.Text.Equals(cortesy))
        {
            rbMr.Selected = false;
            rbMs.Selected = false;
            rbDr.Selected = true;
            rbMrs.Selected = false;
        }
        if (rbMrs.Text.Equals(cortesy))
        {
            rbMr.Selected = false;
            rbMs.Selected = false;
            rbDr.Selected = false;
            rbMrs.Selected = true;
        }

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

        txtPostalCode.Text = string.IsNullOrEmpty(r.Cells[11].Text) || r.Cells[11].Text.StartsWith("&") ? "" : r.Cells[11].Text;

        ListItem item = cbCountry.Items.FindByValue(r.Cells[12].Text);
        cbCountry.SelectedIndex = cbCountry.Items.IndexOf(item);

        txtPhone.Text = r.Cells[13].Text;

        if (string.IsNullOrEmpty(r.Cells[14].Text) || r.Cells[14].Text.StartsWith("&"))
        {
            cbManager.SelectedIndex = 0;
        } else
        {
            ListItem item2 = cbManager.Items.FindByValue(r.Cells[14].Text);
            cbManager.SelectedIndex = cbManager.Items.IndexOf(item2);
            //cbManager.Text = r.Cells[14].Text;
        }

        addNew = false;
        initiateButton();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (validate())
        {
            add();
            loadData();
            initiateButton();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (validate())
        {
            update();
            loadData();
            initiateButton();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int id = int.Parse(lbId.Text);
        delete(id);
        loadData();
        initiateButton();
        btnUpdate.Enabled = false;
        btnDelete.Enabled = false;
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        addNew = true;
        ResetControl();
        initiateButton();
    }

    void ResetControl()
    {
        lbId.Text = string.Empty;
        txtLastname.Text = string.Empty;
        txtFirstname.Text = string.Empty;
        cbTitle.SelectedIndex = 0;
        txtAddress.Text = string.Empty;
        cbCity.SelectedIndex = 0;
        cbRegion.SelectedIndex = 0;
        txtPostalCode.Text = string.Empty;
        cbCountry.SelectedIndex = 0;
        txtPhone.Text = string.Empty;
        cbManager.SelectedIndex = 0;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeeSearch.aspx");
    }
}

class Emp
{
    int id;
    string name;

    public Emp() { }

    public int ID { get; set; }
    public string NAME { get; set; }
}