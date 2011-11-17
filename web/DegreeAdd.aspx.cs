using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Wbs.Entity;
using Wbs.BLL;

public partial class DegreeAdd : Basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitDatetime();
            BindData();
        }
    }



    private void BindData()
    {
        BLLPrice bllPrice = new BLLPrice();
        Price price = bllPrice.Get(ddlYear.SelectedValue, ddlMon.SelectedValue);
        if (price != null)
            lbPrice.Text = price.PriceValue;
        BLLDegree bllDegree = new BLLDegree();
        Degree degree = bllDegree.Get(int.Parse(Request.QueryString["userId"]), ddlYear.SelectedValue, ddlMon.SelectedValue);
        if (degree != null)
            lbPreviousDegrss.Text = degree.DegreeValue;
    }

    public void InitDatetime()
    {
        ddlYear.SelectedValue = DateTime.Now.Year.ToString();
        ddlMon.SelectedValue = DateTime.Now.Month.ToString();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        BLLDegree bll = new BLLDegree();
        Degree degree = new Degree();
        degree.UserId = int.Parse(Request.QueryString["userId"]);
        BLLPrice bllPrice = new BLLPrice();
        Price lastPrice = bllPrice.Get(ddlYear.SelectedValue, ddlMon.SelectedValue);
        if (lastPrice != null)
        {
            degree.PriceId = lastPrice.Id;
            degree.DegreeValue = tbDegree.Text.Trim();
            if (!bll.IsExist(ddlYear.SelectedValue, ddlMon.SelectedValue))
            {
                bll.Add(degree);
                CloseCurrentAndRefreshOpener();
            }
            else
                Alter("该月吨位已经存在");
        }
        else
        {
            Alter("不能添加该月份数据");
        }
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindData();
    }
    protected void ddlMon_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindData();
    }
}