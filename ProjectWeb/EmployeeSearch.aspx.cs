using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EmployeeSearch : System.Web.UI.Page
{
    TSQLFundamentals2008Entities entity;

    protected void Page_Load(object sender, EventArgs e)
    {
        entity = new TSQLFundamentals2008Entities();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = entity.Database.SqlQuery<Employee>("SELECT * FROM HR.Employees WHERE lastname LIKE '%" + txtSearch.Text.Trim() + "%'").ToList();
        GridView1.DataBind();
    }
}