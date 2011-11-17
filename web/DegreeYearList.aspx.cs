using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Wbs.Entity;
using Wbs.BLL;

public partial class DegreeYearList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindData();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGrid();
    }

    private void InItTime()
    {
        ddlYear.SelectedValue = DateTime.Now.Year.ToString();
    }


    private void BindData()
    {
        InItTime();
        BindGrid();
    }

    private void BindGrid()
    {
        BLLUser bll = new BLLUser();
        gvList.DataSource = bll.GetUserDegree(ddlYear.SelectedValue);
        gvList.DataBind();
    }
}