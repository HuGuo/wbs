using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Wbs.Entity;
using Wbs.BLL;

public partial class DegreePerson : System.Web.UI.Page
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


    private void BindData()
    {
        BindGrid();
    }

    private void BindGrid()
    {
        BLLUser bll = new BLLUser();
        User user = bll.GetById(int.Parse(Request.QueryString["userId"]));
        tbName.Text = user.Name;
        tbCode.Text = user.Code;
        tbAddress.Text = user.Address;
        BLLPrice bllPrice = new BLLPrice();
        Price price = bllPrice.Get(Request.QueryString["year"], Request.QueryString["mon"]);
        tbPricevalue.Text = price.PriceValue;
        tbYear.Text = price.YearValue;
        tbMon.Text = price.Mon;
        BLLDegree bllDegree = new BLLDegree();
        Degree degree = bllDegree.Get(user.Id, price.YearValue, price.Mon);
        if (degree != null)
            tbDegreevalue.Text = degree.DegreeValue;
        if (degree != null && degree.PreviousDegree != null)
        {
            tbLastdegreevalue.Text = degree.PreviousDegree.DegreeValue;
            tbPayfor.Text = GetDegree(degree.DegreeValue, degree.PreviousDegree.DegreeValue, price.PriceValue);
        }
    }

    private string GetDegree(string degree, string lastDegress, string price)
    {
        string resutl = "";
        if (!string.IsNullOrEmpty(degree) &&
            !string.IsNullOrEmpty(lastDegress) &&
            !string.IsNullOrEmpty(price))
            resutl = ((int.Parse(degree) - int.Parse(lastDegress)) * int.Parse(price)).ToString();
        return resutl;
    }

    public string GetDegreeValue(string degreeValue, string lastDegreeValue, string price)
    {
        return !string.IsNullOrEmpty(degreeValue) &&
               !string.IsNullOrEmpty(lastDegreeValue) &&
               !string.IsNullOrEmpty(price) ?
               ((double.Parse(degreeValue) - double.Parse(lastDegreeValue)) * double.Parse(price)).ToString() : "";
    }
}