using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Wbs.BLL;
using Wbs.Entity;

public partial class PriceAdd : Basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindData();
    }

    private void BindData()
    {
        DateTime dt = DateTime.Now.AddMonths(-1);
        ddlYear.SelectedValue = dt.Year.ToString();
        ddlMon.SelectedValue = dt.Month.ToString();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Price price = new Price();
        price.YearValue = ddlYear.SelectedValue;
        price.Mon = ddlMon.SelectedValue;
        price.PriceValue = tbPrice.Text.Trim();
        price.Remark = tbRemark.Text.Trim();
        BLLPrice bll = new BLLPrice();
        if (!bll.IsExist(price.YearValue, price.Mon))
        {
            bll.Add(price);
            CloseCurrentAndRefreshOpener();
        }
        else
        {
            Alter("该月份价格已经存在！");
        }
    }
}