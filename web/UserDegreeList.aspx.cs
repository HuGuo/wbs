using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Wbs.BLL;
using Wbs.Entity;

public partial class UserDegreeList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindData();
    }

    private void BindData()
    {
        BLLDegree bllDegree = new BLLDegree();
        gvList.DataSource = bllDegree.Get(int.Parse(Request.QueryString["userId"]));
        gvList.DataBind();
    }

    public string GetPreviousDegree(string userId,string year,string mon)
    {
        BLLDegree bll = new BLLDegree();
        string degreeValue="";
        DateTime dt = new DateTime(int.Parse(year), int.Parse(mon), 1).AddMonths(-1);
        Degree degree = bll.Get(int.Parse(userId), dt.Year.ToString(),dt.Month.ToString());
        if (degree != null)
            degreeValue = degree.DegreeValue;
        return degreeValue;
    }
    
}