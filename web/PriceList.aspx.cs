using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Wbs.Entity;
using Wbs.BLL;

public partial class PriceList : Basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void lbtnSave_Click(object sender, EventArgs e)
    {
        BLLPrice bll = new BLLPrice();
        if (bll.IsExistWhileUpdate(GetPrice()))
            Alter("该月价格已经存在！");
        else
            gvList.UpdateRow(gvList.EditIndex, false);
    }

    private Price GetPrice()
    {
        Price price = new Price();
        GridViewRow gvr = gvList.Rows[gvList.EditIndex];
        price.Id = int.Parse(((Label)gvr.FindControl("lbId")).Text);
        price.Mon = ((TextBox)gvr.FindControl("tbMon")).Text;
        price.YearValue = ((TextBox)gvr.FindControl("tbYear")).Text;
        price.PriceValue = ((TextBox)gvr.FindControl("tbPrice")).Text;
        return price;
    }
}