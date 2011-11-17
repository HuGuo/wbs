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

public partial class UsersList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BindData();
    }

    private void BindData()
    {
        switch (ddlType.SelectedValue)
        {
            case "0":
                gvCode.Visible = false;
                gvName.Visible = true;
                break;
            case "1":
                gvName.Visible = false;
                gvCode.Visible = true;
                break;
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindData();
    }

}
