using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Wbs.Entity;
using Wbs.BLL;

public partial class DegreeList : System.Web.UI.Page
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
        ddlMon.SelectedValue = DateTime.Now.Month.ToString();
    }


    private void BindData()
    {
        InItTime();
        BindGrid();
    }

    private void BindGrid()
    {
        BLLUser bll = new BLLUser();
        dlList.DataSource = bll.GetUserDegreePrice(
            ddlYear.SelectedValue,
            ddlMon.SelectedValue);
        dlList.DataBind();
    }

    public string GetDegreeValue(string degreeValue, string lastDegreeValue, string price)
    {
        return !string.IsNullOrEmpty(degreeValue) &&
               !string.IsNullOrEmpty(lastDegreeValue) &&
               !string.IsNullOrEmpty(price) ?
               ((double.Parse(degreeValue) - double.Parse(lastDegreeValue)) * double.Parse(price)).ToString() : "";
    }
}