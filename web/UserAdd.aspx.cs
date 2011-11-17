using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Wbs.BLL;
using Wbs.Entity;

public partial class UserAdd : Basepage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        BLLUser bll = new BLLUser();
        User user = new User();
        user.Code = tbCode.Text.Trim();
        user.Name = tbName.Text.Trim();
        user.Address = tbAddress.Text.Trim();
        if (!bll.IsExist(user.Code))
        {
            bll.Add(user);
            CloseCurrentAndRefreshOpener();
        }
        else
        {
            Alter("已经存在相同编号的用户");
        }
    }
}