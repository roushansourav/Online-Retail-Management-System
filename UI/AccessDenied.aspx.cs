using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Admin
{
    public partial class AccessDenied : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("<script language=javascript>alert('Admin Access Only');</script>");
            Response.AppendHeader("Refresh", "5;url=Home.aspx");
            RedirectMessage.Text = "You will now be redirected to HomePage in 5 seconds";
            RedirectMessage.Visible = true;
        }
    }
}