using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Helper
/// </summary>
public class Basepage:System.Web.UI.Page
{
    public Basepage()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void RegisterScript(string script)
    {
        ClientScript.RegisterStartupScript(this.GetType(), null, script, true);
    }

    public void CloseCurrentAndRefreshOpener()
    {
        RegisterScript("window.opener.location.href = window.opener.location.href;window.close();");
    }

    public void Alter(string msg)
    {
        RegisterScript(string.Format("alert('{0}')", msg));
    }
}