using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Name"] != null)
            {
                HLnkLogin.Visible = false;
                HLnkProfile.Visible = true;
                HLnkProfile.Text = (string)Session["Name"];
                LnkSignOut.Visible = true;
            }
        }
        protected void SignOutClick(object sender, EventArgs e)
        {
            
            Session.Clear();
            HLnkLogin.Visible = true;
            HLnkProfile.Visible = false;
            LnkSignOut.Visible = false;
            Response.Redirect("~/Home.aspx");
        }
    }
}