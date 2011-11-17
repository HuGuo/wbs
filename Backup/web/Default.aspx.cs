using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Wbs.Entity;
using Wbs.BLL;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BLLUser bll = new BLLUser();
        DataTable dt = null;
        switch (ddlType.SelectedValue)
        {
            case "0":
                ObjectDataSource1.SelectMethod = "Get";
                break;
            case "1":
                ObjectDataSource1.SelectMethod = "GetByName";
                ObjectDataSource1.SelectParameters.Add(
                    "name", DbType.String, tbValue.Text.Trim());
                break;
            case "2":
                ObjectDataSource1.SelectMethod = "GetByCode";
                ObjectDataSource1.SelectParameters.Add(
                    "code", DbType.String, tbValue.Text.Trim());
                break;
        }

    }
}
